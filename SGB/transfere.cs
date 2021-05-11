using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geraBoletos
{
    public partial class OperBoletos : Form
    {
        CarSystem.Tipos.statusDebito statusDebito = CarSystem.Tipos.statusDebito.aVencer;

        delegate void setStatusCallback(bool value);

        CarSystem.BancoDados.Dados dados;
        CarSystem.Boletos.Boleto boletos;
        CarSystem.Cliente cliente;
        CarSystem.Debitos.Debito debitos;
        System.Boolean _isCarregado = false;

        public OperBoletos()
        {
            string nomeFuncao = "geraBoletos.Boletos.Boletos(construtor)";

            try
            {
                InitializeComponent();               

                dados = new CarSystem.BancoDados.Dados();

                dados.Conexoes.bancoDados = "principal";
                dados.Conexoes.servidor = CarSystem.Tipos.Servidores.BDCServer;
                dados.Conexoes.usuario = "usr_sgb";
                dados.Conexoes.senha = "sgb_usr";

                //if (!isLiberado())
                //{
                //    MessageBox.Show("Sistema Bloqueado!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.Close();
                //}

                statusBotoes(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private bool isLiberado()
        {
            string nomeFuncao = "geraBoletos.Boletos.isLiberado";

            try
            {

                dados.Comandos.limpaParametros();

                dados.Comandos.textoComando = "sgb..pro_SGB_getGeraBoletoLiberado";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.retornaDados = true;

                dados.execute();

                if (dados.linhasAfetadas > 0)
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }


            return false;
        }
        private void statusBotoes(System.Boolean status)
        {
            string nomeFuncao = "geraBoletos.Boletos.statusBotoes";

            try
            {
                if (this.cmdEmail.InvokeRequired)
                {
                    setStatusCallback setStatus = new setStatusCallback(statusBotoes);
                    this.Invoke(setStatus, new Object[] { status });
                }
                else
                {
                    if (status)
                    {
                        cmdEmail.Enabled = status; cmdImprimir.Enabled = status;
                        cmdEmail.Text = "e&Mail"; cmdImprimir.Text = "&Imprimir";
                    }
                    else
                    {
                        cmdEmail.Enabled = status; cmdImprimir.Enabled = status;
                        cmdEmail.Text = "Aguarde"; cmdImprimir.Text = "Aguarde";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private void boletosCarregados(System.Boolean isCarregado) 
        { 
            this.isBoletoCarregado = isCarregado; 
        }
        private void inicializaObjetos()
        {
            string nomeFuncao = "geraBoletos.Boletos.inicializaObjetos";

            try
            {
                if (debitos == null)
                    debitos = new CarSystem.Debitos.Debito(CarSystem.Tipos.tipoEmissao.Producao, dados);

                if (cliente == null)
                    cliente = new CarSystem.Cliente(dados);

                if (boletos == null)
                    boletos = new CarSystem.Boletos.Boleto(dados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }        
        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            string nomeFuncao = "geraBoletos.Boletos.cmdPesquisar_Click";

            try
            {
                inicializaObjetos();

                isBoletoCarregado = false;

                statusBotoes(false);

                if (txtPedido.Text.Length < 5)
                {
                    MessageBox.Show("Pedido inválido!!");
                    return;
                }

                //if (boletos == null)
                //{
                //    boletos = new CarSystem.Boletos.Boleto(CarSystem.Tipos.nomeBanco.Santander, dados);
                //    this.boletos.boletosCarregados += new CarSystem.Boletos.Boleto.carregamentoBoleto(this.boletosCarregados);
                //}

                boletosCarregados(true);
                carregaParcelas(CarSystem.Tipos.statusDebito.todos);
                carregaCliente(txtPedido.Text);
                dtInicioVencimento.Value = cliente.getVencimento(DateTime.Today);

                debitos.limpar();

                //System.Threading.Thread threadBoleto = new System.Threading.Thread(new System.Threading.ThreadStart(boletos.g .getBoletos));
                //threadBoleto.Start();         
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }


        }
        private void carregaParcelas(CarSystem.Tipos.statusDebito statusDebito)
        {
            string nomeFuncao = "geraBoletos.Boletos.carregaParcelas";

            System.Data.DataTable tbDebitos;

            try
            {
                dgParcelas.Columns.Clear();

                this.statusDebito = statusDebito;

                tbDebitos = debitos.tbDebitos(txtPedido.Text, statusDebito);

                dgParcelas.DataSource = tbDebitos.Copy();
                dgParcelas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dgParcelas.Columns[1].Visible = false; dgParcelas.Columns[3].Visible = false;
                dgParcelas.Columns[4].Visible = false; dgParcelas.Columns[7].Visible = false;
                dgParcelas.Columns[8].Visible = false; dgParcelas.Columns[9].Visible = false;

                foreach (System.Windows.Forms.DataGridViewRow dgLinha in dgParcelas.Rows)
                {
                    statusDebito = (CarSystem.Tipos.statusDebito)Convert.ToInt32(dgLinha.Cells[3].Value);
                    switch (statusDebito)
                    {
                        case CarSystem.Tipos.statusDebito.aVencer:
                            dgLinha.Cells[0].Style.ForeColor = Color.DarkBlue ; // .Value = "À Vencer";
                            break;
                        case CarSystem.Tipos.statusDebito.vencido:
                            dgLinha.Cells[0].Style.ForeColor = Color.Red;
                            break;
                        case CarSystem.Tipos.statusDebito.quitado:
                            dgLinha.Cells[0].Style.ForeColor = Color.DarkGreen;
                            break;
                        case CarSystem.Tipos.statusDebito.cancelado:
                            dgLinha.Cells[0].Style.ForeColor = Color.Black;
                            break;
                    }
                }

                
                dgParcelas.Columns["valorDebito"].DefaultCellStyle.Format = "C2";

                dgParcelas.Columns.Add(colunaAcoes());
                dgParcelas.Columns[dgParcelas.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgParcelas.Columns[dgParcelas.Columns.Count - 1].Width = 90;

            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }
            finally
            {
                tbDebitos = null;
            }
        }
        private void carregaCliente(string contrato)
        {
            string nomeFuncao = "geraBoletos.Boletos.carregaCliente";

            try
            {
                if (!cliente.getCliente(contrato))
                {
                    MessageBox.Show("Cliente Inexistente!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtPlaca.Text = cliente.placa;
                txtPedido.Text = cliente.contrato;
                txtProduto.Text = cliente.equipamento.nomeEquipamento;
                txtNome.Text = cliente.nome;
                txtEmail.Text = cliente.email;
            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private void cmdProcessar_Click(object sender, EventArgs e)
        {
            string nomeFuncao = "geraBoletos.Boletos.cmdProcessar_Click";

            try
            {
                MessageBox.Show(geraBoleto(txtPedido.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
            finally
            {
                cmdPesquisar_Click(sender, e);
            }
        }        
        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            string nomeFuncao = "geraBoletos.Boletos.cmdImprimir_Click";

            try
            {
                if (preparaBoleto())
                    boletos.banco.funcoesBoleto.iniciarImpressao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private void cmdEmail_Click(object sender, EventArgs e)
        {
            string nomeFuncao = "geraBoletos.Boletos.cmdEmail_Click";
            System.String nomeArquivo = "";
            string boletoHTML = "";

            try
            {
                CarSystem.Utilidades.Rede.Email.emailEnviado += new CarSystem.Utilidades.Rede.Email.processoEmail(Email_emailEnviado);

                if (preparaBoleto())
                {
                    boletoHTML = boletos.banco.funcoesBoleto.getBoletoHTML();
                    nomeArquivo = System.IO.Path.Combine(Environment.CurrentDirectory, "boletos_" + txtPedido.Text + ".htm");
                    nomeArquivo = CarSystem.Utilidades.IO.Arquivo.stringTOtxt(nomeArquivo, boletoHTML);

                    CarSystem.Utilidades.Rede.Email.enviaEmail("cobranca@carsystem.com", txtEmail.Text, "Boletos CarSystem", "", nomeArquivo);
                }

                //MessageBox.Show("Processo concluído!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }

        void Email_emailEnviado(string erro)
        {
            MessageBox.Show("Processo concluído!" + erro); 
        }

        private void Boletos_Load(object sender, EventArgs e)
        {
        }
        private void dgParcelas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string nomeFuncao = "geraBoletos.Boletos.dgParcelas_CellValueChanged";

            try
            {
                if (e.ColumnIndex == 10)
                {

                    if (dgParcelas[10, e.RowIndex].Value.ToString() == "Imprimir")
                        if ((CarSystem.Tipos.statusDebito)Convert.ToInt32(dgParcelas[3, e.RowIndex].Value) == CarSystem.Tipos.statusDebito.vencido)
                            dgParcelas[0, e.RowIndex] = comboGridCelula(dgParcelas[0, e.RowIndex].Value);

                    if (dgParcelas[10, e.RowIndex].Value.ToString() == "Imprimir todas")
                    {
                        foreach (System.Windows.Forms.DataGridViewRow dgLinha in dgParcelas.Rows)
                        {
                            dgLinha.Cells[10].Value = "Imprimir";
                            if ((CarSystem.Tipos.statusDebito)Convert.ToInt32(dgLinha.Cells[3].Value) == CarSystem.Tipos.statusDebito.vencido)
                                dgLinha.Cells[0] = comboGridCelula(dgLinha.Cells[0].Value);
                        }
                        return;
                    }

                    if (dgParcelas[10, e.RowIndex].Value.ToString() == "Cancelar todas")
                    {
                        foreach (System.Windows.Forms.DataGridViewRow dgLinha in dgParcelas.Rows)
                            dgLinha.Cells[10].Value = "";
                        return;
                    }
                }
                else if (e.ColumnIndex == 0 && dgParcelas[10, e.RowIndex].Value.ToString() == "Imprimir" && dgParcelas[3, e.RowIndex].Value.ToString() == "1")
                {
                    DateTime novoVencimento; 
                    DataGridViewComboBoxCell cbCelula; 
                    DateTime vencimento;
                    double valor;

                    if (dgParcelas.Columns["valorAtualizado"] == null)
                    {
                        dgParcelas.Columns.Add("valorAtualizado", "valorAtualizado");
                        dgParcelas.Columns["valorAtualizado"].DefaultCellStyle.Format = "C2";
                    }

                    //276778                   

                    novoVencimento = Convert.ToDateTime(dgParcelas[0, e.RowIndex].Value);
                    cbCelula = (DataGridViewComboBoxCell)dgParcelas["vencimento", e.RowIndex];
                    vencimento = Convert.ToDateTime(((DataRowView)cbCelula.Items[0]).Row.ItemArray[0].ToString());
                    valor = Convert.ToDouble(dgParcelas["valorDebito", e.RowIndex].Value.ToString());

                    dgParcelas["valorAtualizado", e.RowIndex].Value = CarSystem.Utilidades.Financeiro.Juros.calculaJuros((DateTime)vencimento, novoVencimento, valor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private void optVencer_CheckedChanged(object sender, EventArgs e)
        {
            string nomeFuncao = "geraBoletos.Boletos.optVencer_CheckedChanged";

            try
            {
                carregaParcelas(CarSystem.Tipos.statusDebito.aVencer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
            
        }
        private void optVencidas_CheckedChanged(object sender, EventArgs e)
        {
            string nomeFuncao = "geraBoletos.Boletos.optVencidas_CheckedChanged";

            try
            {
                carregaParcelas(CarSystem.Tipos.statusDebito.vencido);
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }            
        }
        private void optTodas_CheckedChanged(object sender, EventArgs e)
        {
            string nomeFuncao = "geraBoletos.Boletos.optTodas_CheckedChanged";

            try
            {
                carregaParcelas(CarSystem.Tipos.statusDebito.todos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }            
        }
        private System.Boolean preparaBoleto()
        {
            string nomeFuncao = "geraBoletos.Boletos.preparaBoleto";
            System.Boolean isPassou = false;

            try
            {
                if (!isBoletoCarregado)
                    throw new Exception("Boletos não carregados!");

                debitos.getDadosDebito(txtPedido.Text, CarSystem.Tipos.statusDebito.todos);

                foreach (System.Windows.Forms.DataGridViewRow dgLinha in dgParcelas.Rows)
                {
                    if (dgLinha.Cells[10].Value != null && dgLinha.Cells[10].Value.ToString() == "Imprimir")
                    {
                        if (cliente.contrato.ToString() != dgLinha.Cells[1].Value.ToString())
                        {
                            cliente.getCliente(dgLinha.Cells[1].Value.ToString());
                            debitos.getDadosDebito(cliente.contrato, CarSystem.Tipos.statusDebito.todos);
                        }

                        DataGridViewComboBoxCell cbCelula;
                        DateTime vencimento;


                        foreach (CarSystem.Interface.IInformacoesDebito infoDebito in debitos.getDebitos())
                        {
                            if (infoDebito.identificadorDebito == Convert.ToInt64(dgLinha.Cells[7].Value))
                            {
                                if (dgLinha.Cells["statusDebito"].Value.ToString() == "1")
                                {
                                    if (dgParcelas.Columns["valorAtualizado"] != null)
                                        boletos.banco.funcoesBoleto.imprimeBoleto(cliente, infoDebito.nossoNumero, infoDebito.numeroDocumento, Convert.ToDateTime(dgLinha.Cells["vencimento"].Value), Convert.ToDouble(dgLinha.Cells["valorAtualizado"].Value));
                                    else
                                    {
                                        cbCelula = (DataGridViewComboBoxCell)dgLinha.Cells["vencimento"];
                                        vencimento = Convert.ToDateTime(((DataRowView)cbCelula.Items[0]).Row.ItemArray[0].ToString());
                                        boletos.banco.funcoesBoleto.imprimeBoleto(cliente, infoDebito.nossoNumero, infoDebito.numeroDocumento, vencimento, Convert.ToDouble(dgLinha.Cells["valorDebito"].Value));
                                    }
                                }
                                else
                                {
                                    boletos.banco.funcoesBoleto.imprimeBoleto(infoDebito, cliente);
                                }
                                break;
                            }

                            if (infoDebito.codigoBanco != boletos.banco.nomeBanco)
                                boletos.banco.setBanco(infoDebito.codigoBanco, dados);
                        }

                        //boletos.banco.imprimeBoleto(cliente,CarSystem.Tipos.tipoEmissao.Producao,CarSystem.Tipos.statusDebito.aVencer);

                        isPassou = true;
                    }
                }
            }
            //catch (CarSystem.Utilidades.Campos.CampoException)
            //{
            //    boletos.getBoletos();
            //}
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }

            return isPassou;
        }
        private System.String geraBoleto(String contrato)
        {
            string nomeFuncao = "geraBoletos.Boletos.geraBoleto";

            try
            {
                boletos.inicioVencimento = dtInicioVencimento.Value;
                return boletos.geraBoleto(contrato, Convert.ToInt32(nud_Parcelas.Value), Convert.ToInt32(nud_Revisao.Value), Environment.UserName.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private System.Windows.Forms.DataGridViewComboBoxColumn colunaAcoes()
        {
            string nomeFuncao = "geraBoletos.Boletos.colunaAcoes";           

            try
            {
                return CarSystem.Utilidades.Componentes.Grid.comboGridColuna(new string[] { "Imprimir", "Imprimir todas", "Cancelar", "Cancelar todas" },"Ação");
            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }
        }

        private System.Windows.Forms.DataGridViewComboBoxCell comboGridCelula(object valor)
        {

            string nomeFuncao = "geraBoletos.Boletos.comboGridCelula";
            System.Windows.Forms.DataGridViewComboBoxCell cbCelula = new DataGridViewComboBoxCell();

            System.Data.DataTable tbDatas = new DataTable();

            try
            {
                tbDatas.Columns.Add("data");
                tbDatas.Columns["data"].DataType = typeof(string);

                if (valor != null)
                    tbDatas.Rows.Add(((DateTime)valor).ToString("dd/MM/yyyy"));
                    //cbCelula.Items.Add(valor);

                for (int contador = 0; contador < 45; contador++)
                    tbDatas.Rows.Add(DateTime.Today.Date.AddDays(contador).ToString("dd/MM/yyyy"));
                    //cbCelula.Items.Add(DateTime.Today.Date.AddDays(contador).ToString("dd/MM/yyyy"));

                cbCelula.Style.ForeColor = Color.Red;

                cbCelula.DataSource = tbDatas;
                cbCelula.ValueMember = "data";
                cbCelula.DisplayMember = "data";

                return cbCelula;
            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }
        }

        public System.Boolean isBoletoCarregado
        {
            get { return _isCarregado; }
            set { statusBotoes(value); _isCarregado = value; }
        }
        private void dgParcelas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }
        private void dgParcelas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgParcelas[e.ColumnIndex, e.RowIndex].GetType().FullName != typeof(DataGridViewComboBoxCell).FullName
                && dgParcelas.Columns[e.ColumnIndex].GetType().FullName != typeof(DataGridViewComboBoxColumn).FullName)
                e.Cancel = true;

        }


    }
}