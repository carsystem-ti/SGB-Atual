using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaixaTitulos
{
    public partial class QuitaParcelas : Form
    {
        CarSystem.BancoDados.Dados _dados;
        CarSystem.SGB.Quitacao _quitacao;
        CarSystem.Banco.Baixa _baixa;
        CarSystem.Tipos.nomeBanco _banco;
        CarSystem.Tipos.empresas _empresa;

        string _retorno = "";

        string _nossoNumero;
        double _valor;
        string _arquivo;

        public QuitaParcelas()
        {
            InitializeComponent();
        }

        public QuitaParcelas(CarSystem.BancoDados.Dados dados, CarSystem.Tipos.nomeBanco banco, 
                            CarSystem.Tipos.empresas empresa,string nossoNumero, double valor,
                            string arquivo) : this()
        {
            //this.dados = new CarSystem.BancoDados.Dados("principal", CarSystem.Tipos.Servidores.Fury, "usr_sgb", "sgb_usr");

            this.dados = dados;

            this.banco = banco; this.empresa = empresa; this.nossoNumero = nossoNumero;
            this.valor = valor; this.arquivo = arquivo;

            lblBanco.Text = this.banco.ToString();
            lblEmpresa.Text = this.empresa.ToString();
            lblNossoNumero.Text = this.nossoNumero;
            lblValor.Text = CarSystem.Utilidades.Formatar.formataReal(this.valor);
            lblArquivo.Text = this.arquivo;

            preencheGrid();
        }

        public CarSystem.BancoDados.Dados dados
        {
            get
            {
                if (empresa == CarSystem.Tipos.empresas.CarSystem && _dados.Conexoes.stringConexao.ToLower().Contains("satnet"))
                {
                    _dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
                    _dados.Conexoes.conexao.Close();
                }

                else if (empresa == CarSystem.Tipos.empresas.SatNet && _dados.Conexoes.stringConexao.ToLower().Contains("Fury"))
                {
                    _dados.Conexoes.servidor = CarSystem.Tipos.Servidores.SatNetServer;
                    _dados.Conexoes.conexao.Close();
                }


                return _dados;
            }
            set { _dados = value; }
        }
        public CarSystem.SGB.Quitacao quitacao
        {
            get 
            { 
                if (_quitacao == null )
                    _quitacao = new CarSystem.SGB.Quitacao(dados);

                return _quitacao; 
            }
            set { _quitacao = value; }
        }
        public CarSystem.Banco.Baixa baixa
        {
            get 
            {
                if (_baixa == null)
                {
                    _baixa = new CarSystem.Banco.Baixa(banco);
                    _baixa.dados = this.dados;
                }

                return _baixa; 
            }
            set { _baixa = value; }
        }
        public CarSystem.Tipos.nomeBanco banco
        {
            get { return _banco; }
            set { _banco = value; }
        }
        public CarSystem.Tipos.empresas empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        public string nossoNumero
        {
            get { return _nossoNumero; }
            set { _nossoNumero = value; }
        }
        public double valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public string arquivo
        {
            get { return _arquivo; }
            set { _arquivo = value; }
        }

        private void preencheGrid()
        {
            quitacao.dados = dados;

            DataTable dtQuitacao = quitacao.getNnSemelhantes(nossoNumero);

            dtQuitacao.Columns.Add("NNGerado", typeof(System.String));

            gridParcelas.DataSource = dtQuitacao;

            organizaGrid();

            foreach (DataGridViewRow linha in gridParcelas.Rows)
                if (linha.Cells["nossoNumero"].Value != null)
                    linha.Cells["NNGerado"].Value = CarSystem.Banco.NetBoleto.getDigitoVerificador(linha.Cells["nossoNumero"].Value.ToString().Substring(0, nossoNumero.Length - 1), dados, 237);

            gridParcelas.Refresh();
        }

        private void organizaGrid()
        {
            modificaColuna("contratoDebito","Contrato",0);
            modificaColuna("nossoNumero", "NossoNúmero", 1);
            modificaColuna("valorDebito", "Valor", 2);
            modificaColuna("codigoDebito", "Cód. Débito", 3); 
            modificaColuna("vencimento","Vencimento",4);
            modificaColuna("NNGerado", "NNExemplo",5);
            modificaColuna("statusDebito","Status",6);
            modificaColuna("numeroDocumento",false);
            modificaColuna("identificadorDebito",false);
            modificaColuna("codigoRemessa","",false);
            modificaColuna("codigoBanco","Banco",7);
        }
        private void modificaColuna(string nomeColuna, bool isVisible)
        {
            modificaColuna(nomeColuna, "", -1, isVisible);
        }
        private void modificaColuna(string nomeColuna, string tituloColuna, bool isVisible)
        {
            modificaColuna(nomeColuna, tituloColuna, -1, isVisible);
        }
        private void modificaColuna(string nomeColuna, string tituloColuna, int posicaoColuna)
        {
            modificaColuna(nomeColuna, tituloColuna, posicaoColuna, true);
        }
        private void modificaColuna(string nomeColuna, string tituloColuna, int posicaoColuna, bool isVisible)
        {
            string nomeFuncao = "BaixaTitulos.QuitaParcelas.modificaColuna";

            try
            {
                if ( posicaoColuna >= 0 )
                    gridParcelas.Columns[nomeColuna].DisplayIndex = posicaoColuna;

                gridParcelas.Columns[nomeColuna].HeaderText = tituloColuna;
                gridParcelas.Columns[nomeColuna].Visible = isVisible;
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }

        }
        private void QuitaParcelas_Load(object sender, EventArgs e)
        {

        }

        private void gridParcelas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (MessageBox.Show("Quitar a parcela: " + gridParcelas["nossoNumero", e.RowIndex].Value.ToString() + "?", "Quitar?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            retorno = baixa.getDescricaoRetornoBaixa(baixa.efetuaBaixaCodigo(dados, Convert.ToInt32(gridParcelas["identificadorDebito", e.RowIndex].Value), valor, nossoNumero));
            retorno += " manual";

            MessageBox.Show(retorno);

            this.Close();            
        }

        private void gridParcelas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public string retorno
        {
            get { return _retorno; }
            set { _retorno = value; }
        }

        private void QuitaParcelas_FormClosing(object sender, FormClosingEventArgs e)
        {
            dados.Conexoes.close();
            dados = null;
        }

        private void lblEmpresa_Click(object sender, EventArgs e)
        {

        }

		private void lblFundo_Click( object sender, EventArgs e )
		{

		}

        private void cmdQuitar_Click(object sender, EventArgs e)
        {

        }

    }
}