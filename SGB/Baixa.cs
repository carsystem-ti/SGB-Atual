using BoletoNet;
using CarSystem.Utilidades.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BaixaTitulos
{
    public partial class Baixa : Form
    {
        delegate void SetTextoCallback(Label lblTexto, string texto);        
        delegate void AddLinhasCallback(DataGridView dgGrid, object[] linhas);

        delegate string GetTextoCbCallback(ComboBox combo);
        delegate object GetSelectedValueCallback(ComboBox combo);

        ContextMenu _menuGrid;
        DataTable _dtBaixa;

        OpenFileDialog dgArquivo;
        CarSystem.Banco.Baixa baixa;
        CarSystem.BancoDados.Dados _dados;

        double valorRecusado = 0;
        double valorBaixado = 0;
        double valorProcessado = 0;

        int qtdRecusado = 0;
        int qtdBaixado = 0;
        int qtdProcessado = 0;

        bool isCarregando = false;
        string[] arquivos;

        CarSystem.Utilidades.baseLayout layouts;

        public Baixa()
        {
            isCarregando = true;
            InitializeComponent();
        }
        void iniciaDados()
        {
            _dados = new CarSystem.BancoDados.Dados();

            _dados.Conexoes.usuario = "usr_sgb";
            _dados.Conexoes.senha = "sgb_usr";

            _dados.Conexoes.servidor = servidor;
            _dados.Conexoes.bancoDados = "sgb";
        }
        CarSystem.Tipos.Servidores servidor
        {
            get
            {
                //switch ((CarSystem.Tipos.empresas)Convert.ToInt32(cbEmpresa.SelectedValue))
                //{
                //    case CarSystem.Tipos.empresas.SatNet:                        
                //        return CarSystem.Tipos.Servidores.SatNetServer;
                //    case CarSystem.Tipos.empresas.CentralSat:
                //    case CarSystem.Tipos.empresas.Panamericano:
                //    case CarSystem.Tipos.empresas.ViaSatelite:
                //    case CarSystem.Tipos.empresas.CarSystem:
                //        return CarSystem.Tipos.Servidores.Fury;
                //    default:

                //}

                //CarSystem.Tipos.empresas empresa;
                //empresa = (CarSystem.Tipos.empresas)Convert.ToInt32(getSelectedValue(cbEmpresa));

				if ( Convert.ToInt32( getSelectedValue( cbEmpresa ) ) == 1 )
					return CarSystem.Tipos.Servidores.Fury;
                   //return CarSystem.Tipos.Servidores.Fury;

                return CarSystem.Tipos.Servidores.Fury;
            }
        }
        public CarSystem.BancoDados.Dados dados
        {
            get
            {
                if (_dados == null)
                    iniciaDados();

                if (Convert.ToInt32(getSelectedValue(cbEmpresa)) == 1 || Convert.ToInt32(getSelectedValue(cbEmpresa)) == 11|| cbEmpresa.Items.Count == 0)
                {
                    _dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
					//_dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
                    _dados.Conexoes.conexao.Close();
                }
                else 
                {
                    _dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
                    _dados.Conexoes.conexao.Close();
                }

                return _dados; 
            }
            set 
            {
                _dados = value; 
            }
        }
        public System.Data.DataTable dtBaixa
        {
            get
            {
                if (_dtBaixa == null)
                {
                    _dtBaixa = new DataTable("baixa");
                    _dtBaixa.Columns.Add(new DataColumn("status", typeof(System.String)));
                    _dtBaixa.Columns.Add(new DataColumn("nossoNumero", typeof(System.String)));
                    _dtBaixa.Columns.Add(new DataColumn("valor", typeof(System.String)));
                    _dtBaixa.Columns.Add(new DataColumn("contrato", typeof(System.String)));
                    //                    _dtBaixa.PrimaryKey = new DataColumn[] { _dtBaixa.Columns["status"] };
                }

                return _dtBaixa;
            }
            set { _dtBaixa = value; }
        }
        public ContextMenu menuGrid
        {
            get
            {
                if (_menuGrid == null)
                    _menuGrid = criaMenu();

                return _menuGrid;
            }
            set { _menuGrid = value; }
        }

        private void dgArquivo_FileOk(object sender, CancelEventArgs e)
        {
            if ( dgArquivo.FileNames.Length > 1 )
                txtArquivo.Text = "<<vários>>";
            else
                txtArquivo.Text = dgArquivo.FileName;

            arquivos = dgArquivo.FileNames;

            dgArquivo = null;
        }
        private void Baixa_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dtEmpresa;

            CarSystem.Tipos.Funcoes.preencheCombo(new CarSystem.Tipos.nomeBanco(), cbBancos);

            dtEmpresa = CarSystem.Empresa.getEmpresas(dados);            
            //CarSystem.Tipos.Funcoes.preencheCombo(new CarSystem.Tipos.empresas(), cbEmpresa);
            CarSystem.Utilidades.Componentes.Combo.preencheCombo(dtEmpresa, cbEmpresa);

            isCarregando = false;
        }
        private void txtArquivo_DoubleClick(object sender, EventArgs e)
        {
            dgArquivo = new OpenFileDialog();

            dgArquivo.FileOk += new CancelEventHandler(dgArquivo_FileOk);
            dgArquivo.Multiselect = true;
            dgArquivo.ShowDialog(this);
        }
    
        private void cmdProcessar_Click(object sender, EventArgs e)
        {
            string nomeFuncao = "BaixaTitulos.Baixa.cmdProcessar_Click";
            System.Threading.Thread threadBaixa;
            try
            {
                if (MessageBox.Show("Executar baixas?\r\n Arquivo: " + txtArquivo.Text + "\r\n Banco: " + getTexto(cbBancos) + "\r\n Empresa: " + getTexto(cbEmpresa),
                    "Tem Certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                dgBaixa.Rows.Clear();
                dtBaixa.Rows.Clear();

                baixa = null;

              
                    baixa = new CarSystem.Banco.Baixa((CarSystem.Tipos.nomeBanco)Convert.ToInt32(cbBancos.SelectedValue));
                    baixa.processoBaixa += new CarSystem.Banco.Baixa.processamentoBaixa(baixa_processoBaixa);
               
                

                valorRecusado = 0;
                valorBaixado = 0;
                valorProcessado = 0;

                qtdRecusado = 0;
                qtdBaixado = 0;
                qtdProcessado = 0;

                if ((CarSystem.Tipos.nomeBanco)Convert.ToInt32(cbBancos.SelectedValue) == CarSystem.Tipos.nomeBanco.HSBC)
                {
                    layouts = new CarSystem.Banco.HSBC.Remessa.RegistroF("RegistroF");
                    threadBaixa = new System.Threading.Thread(this.novoProcessoBaixas);
                }
                else if ((CarSystem.Tipos.nomeBanco)Convert.ToInt32(cbBancos.SelectedValue) == CarSystem.Tipos.nomeBanco.CIELO)
                {
                    layouts = new CarSystem.Banco.Cielo.Remessa.Detalhe("cielo");
                    threadBaixa = new System.Threading.Thread(this.novoProcessoBaixas);
                }
                else if ((CarSystem.Tipos.nomeBanco)Convert.ToInt32(cbBancos.SelectedValue) == CarSystem.Tipos.nomeBanco.Safra)
                {
                    layouts = new CarSystem.Banco.Cielo.Remessa.Detalhe("Safra");
                    threadBaixa = new System.Threading.Thread(this.novoProcessoBaixas);
                }
                else if ((CarSystem.Tipos.nomeBanco)Convert.ToInt32(cbBancos.SelectedValue) == CarSystem.Tipos.nomeBanco.Itau)
                {
                    layouts = new CarSystem.Banco.Itau.Retorno.RegistroDetalhe("Itau");
                    threadBaixa = new System.Threading.Thread(this.novoProcessoBaixas);
                } else if ((CarSystem.Tipos.nomeBanco)Convert.ToInt32( cbBancos.SelectedValue ) == CarSystem.Tipos.nomeBanco.Santander) {
                    layouts = new CarSystem.Banco.Febraban.Registros.RegistroFRetorno( "Santander" );
                    threadBaixa = new System.Threading.Thread( this.novoProcessoBaixas );
                }
                else
                    threadBaixa = new System.Threading.Thread(this.efetuaBaixas);

                threadBaixa.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private void novoProcessoBaixas()
        {
            string nomeFuncao = "BaixaTitulos.Baixa.novoProcessoBaixas";

            try
            {
                dados = null;

                foreach (string arquivo in arquivos)
                    baixa.processaBaixas(arquivo, dados, layouts);

                geraArquivo();

                MessageBox.Show("Processamento Concluído!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }

        private void efetuaBaixas()
        {
            string nomeFuncao = "BaixaTitulos.Baixa.efetuaBaixas";

            try
            {
                dados = null;

                foreach (string arquivo in arquivos)
                {
                    if (getTexto(cbEmpresa) == "TECHNOLOGY")
                        baixa.processaBaixas(arquivo, dados, 10);
                    else if (getTexto(cbEmpresa) == "SATNET")
                        baixa.processaBaixas(arquivo, dados, 8);
                    else
                        baixa.processaBaixas(arquivo, dados, 0);
                }

                geraArquivo();

                MessageBox.Show("Processamento Concluído!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }            
        }
        private void baixa_processoBaixa(CarSystem.Tipos.statusProcessamento status, object[] argumentos)
        {
            string nomeFuncao = "BaixaTitulos.Baixa.baixa_processoBaixa";

            try
            {
                addLinhas(dgBaixa, argumentos);

                if (argumentos[0].ToString() == "já quitado")
                    status = CarSystem.Tipos.statusProcessamento.efetuado;

                switch (status)
                {
                    case CarSystem.Tipos.statusProcessamento.efetuado:
                        valorBaixado += Convert.ToDouble(argumentos[2]);
                        qtdBaixado += 1;
                        break;
                    //case CarSystem.Tipos.statusProcessamento.selecionado:
                    //    valorProcessado += Convert.ToDouble(argumentos[2]);
                    //    break;
                    case CarSystem.Tipos.statusProcessamento.recusado:
                        valorRecusado += Convert.ToDouble(argumentos[2]);
                        qtdRecusado += 1;
                        break;
                    //case CarSystem.Tipos.statusProcessamento.informativo:
                    //    MessageBox.Show(argumentos[0].ToString());
                    //    break;
                }

                valorProcessado += Convert.ToDouble(argumentos[2]);
                qtdProcessado += 1;

                setTexto(lblBaixadosQ, qtdBaixado.ToString());
                setTexto(lblBaixadosR, CarSystem.Utilidades.Formatar.formataReal(valorBaixado));

                setTexto(lblProcessadosQ, qtdProcessado.ToString());
                setTexto(lblProcessadosR, CarSystem.Utilidades.Formatar.formataReal(valorProcessado));

                setTexto(lblRecusadosQ, qtdRecusado.ToString());
                setTexto(lblRecusadosR, CarSystem.Utilidades.Formatar.formataReal(valorRecusado));
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }     
        }
        private void cbEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            string nomeFuncao = "BaixaTitulos.Baixa.cbEmpresa_SelectedValueChanged";

            try
            {
                if (isCarregando)
                    return;

                dgBaixa.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }     
        }
        private void cbBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomeFuncao = "BaixaTitulos.Baixa.cbBancos_SelectedIndexChanged";

            try
            {
                if (isCarregando)
                    return;

                //switch ((CarSystem.Tipos.nomeBanco)cbBancos.SelectedValue)
                //{
                //    case CarSystem.Tipos.nomeBanco.b

                dgBaixa.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }     
            
        }
        private void setTexto(Label lblTexto, string texto) 
        {
            string nomeFuncao = "BaixaTitulos.Baixa.setTexto";

            try
            {

                if (lblTexto.InvokeRequired)
                {
                    SetTextoCallback funcao = new SetTextoCallback(setTexto);
                    this.Invoke(funcao, new object[] { lblTexto, texto });
                }
                else
                {
                    lblTexto.Text = texto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }     
        }
        private void addLinhas(DataGridView dgGrid, object[] argumentos)
        {
            string nomeFuncao = "BaixaTitulos.Baixa.addLinhas";

            try
            {

                if (dgGrid.InvokeRequired)
                {
                    AddLinhasCallback funcao = new AddLinhasCallback(addLinhas);
                    this.Invoke(funcao, new object[] { dgGrid, argumentos });
                }
                else
                {
                    dgGrid.Rows.Add(argumentos);
                    dtBaixa.Rows.Add(argumentos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }             
        }
        private string getTexto(ComboBox combo)
        {
            //string nomeFuncao = "BaixaTitulos.Baixa.getTexto";

            //try
            //{
                if (combo.InvokeRequired)
                {
                    GetTextoCbCallback funcao = new GetTextoCbCallback(getTexto);
                    return (string)this.Invoke(funcao, new object[] { combo });
                }
                else                
                    return combo.Text;
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            //}            
        }

        private object getSelectedValue(ComboBox combo)
        {
            //string nomeFuncao = "BaixaTitulos.Baixa.getTexto";

            //try
            //{
            if (combo.InvokeRequired)
            {
                GetSelectedValueCallback funcao = new GetSelectedValueCallback(getSelectedValue);
                return (object)this.Invoke(funcao, new object[] { combo });
            }
            else
                return combo.SelectedValue;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            //}            
        }

        private object getSelectedText(ComboBox combo)
        {
            //string nomeFuncao = "BaixaTitulos.Baixa.getTexto";

            //try
            //{
            if (combo.InvokeRequired)
            {
                GetSelectedValueCallback funcao = new GetSelectedValueCallback(getSelectedText);
                return (object)this.Invoke(funcao, new object[] { combo });
            }
            else
                return combo.SelectedText;

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            //}            
        }   

        private string geraResultado()
        {
            string nomeFuncao = "BaixaTitulos.Baixa.geraResultado";

            try
            {
                string texto = "";

                foreach (DataGridViewRow linha in dgBaixa.Rows)
                {
                    if (linha.Cells[0].Value == null)
                        continue;

                    foreach (DataGridViewColumn coluna in dgBaixa.Columns)
                        if (linha.Cells[coluna.Index].Value != null)
                            texto += linha.Cells[coluna.Index].Value.ToString() + "\t";
                        else
                            texto += "\t";

                    texto += "\r\n";
                }
                texto += "\r\n";

                texto += "ValorRecusado\t\t" + valorRecusado.ToString("C") + "\t"; // CarSystem.Utilidades.Formatar.formataReal(valorRecusado) + "\t";
                texto += "\tQuantidade\t" + qtdRecusado.ToString() + "\t";

                texto += "\r\n";

                texto += "ValorBaixado\t\t" + valorBaixado.ToString("C") + "\t"; // CarSystem.Utilidades.Formatar.formataReal(valorBaixado) + "\t";
                texto += "Quantidade\t" + qtdBaixado.ToString() + "\t";

                texto += "\r\n";

                texto += "ValorProcessado\t\t" + valorProcessado.ToString("C") + "\t";  //CarSystem.Utilidades.Formatar.formataReal(valorProcessado) + "\t";
                texto += "Quantidade\t" + qtdProcessado.ToString() + "\t";

                texto = "\r\n" + texto;
                texto = "Arquivo: " + arquivos + texto;
                
                return texto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }

            return "";

        }
        private void copiaResultado()
        {
            Clipboard.SetText(geraResultado());
        }
        private void cmdResultado_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Todos os rejeitados?", "Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                carregaGrid(dtBaixa.Select("status<>'baixado' and status<>'já quitado'"));

            if (MessageBox.Show("Gerar arquivo?", "Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                geraArquivo();
            else
                copiaResultado();
        }
        private void dgBaixa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nomeFuncao = "BaixaTitulos.Baixa.dgBaixa_CellDoubleClick";

            try
            {

                if (dgBaixa["status", e.RowIndex].Value.ToString() == "baixado")
                    return;

                //MessageBox.Show(((CarSystem.Tipos.nomeBanco)Convert.ToInt32(cbBancos.SelectedValue)).ToString());
                //MessageBox.Show(((CarSystem.Tipos.empresas)Convert.ToInt32(cbEmpresa.SelectedValue)).ToString());
                //MessageBox.Show(dgBaixa["nossoNumero", e.RowIndex].Value.ToString());
                //MessageBox.Show(dgBaixa["valor", e.RowIndex].Value.ToString());
                //MessageBox.Show(txtArquivo.Text);

                QuitaParcelas qp = new QuitaParcelas(dados,
                                (CarSystem.Tipos.nomeBanco)Convert.ToInt32(cbBancos.SelectedValue),
                                (CarSystem.Tipos.empresas)Convert.ToInt32(cbEmpresa.SelectedValue),
                                dgBaixa["nossoNumero", e.RowIndex].Value.ToString(),
                                Convert.ToDouble(dgBaixa["valor", e.RowIndex].Value.ToString()), txtArquivo.Text);

                qp.retorno = dgBaixa["status", e.RowIndex].Value.ToString();

                qp.ShowDialog();

                dgBaixa["status", e.RowIndex].Value = qp.retorno;

                if (qp.retorno == "baixado manual")
                {
                    valorRecusado -= Convert.ToDouble(dgBaixa["valor", e.RowIndex].Value.ToString());
                    valorBaixado += Convert.ToDouble(dgBaixa["valor", e.RowIndex].Value.ToString());
                    qtdRecusado -= 1;
                    qtdBaixado += 1;
                }

                dgBaixa.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }     
        }
        private void dgBaixa_MouseUp(object sender, MouseEventArgs e)
        {
            string nomeFuncao = "BaixaTitulos.Baixa.dgBaixa_MouseUp";

            try
            {
                if (e.Button == MouseButtons.Right)
                    menuGrid.Show(dgBaixa, new Point(e.X, e.Y));

            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }            
        }
        private ContextMenu criaMenu()
        {
            string nomeFuncao = "BaixaTitulos.Baixa.dgBaixa_MouseUp";

            ContextMenu menu = new ContextMenu();

            try
            {
                MenuItem itemTodos = new MenuItem();
                MenuItem itemQuitados = new MenuItem();
                MenuItem itemRejeitado = new MenuItem();
                MenuItem itemNE = new MenuItem();
                MenuItem itemCopiar = new MenuItem();

                itemRejeitado.Click += new EventHandler(MenuItem_Click);
                itemQuitados.Click += new EventHandler(MenuItem_Click);
                itemTodos.Click += new EventHandler(MenuItem_Click);
                itemCopiar.Click += new EventHandler(MenuItem_Click);
                itemNE.Click += new EventHandler(MenuItem_Click);

                itemQuitados.Text = "Quitados";
                itemRejeitado.Text = "Rejeitados";
                itemNE.Text = "Não Encontrados";                
                itemTodos.Text = "Todos";
                itemCopiar.Text = "Copiar";

                itemRejeitado.RadioCheck = true;
                itemQuitados.RadioCheck = true;
                itemTodos.RadioCheck = true;
                itemNE.RadioCheck = true;

                itemTodos.Checked = true;

                menu.MenuItems.Add(itemTodos);
                menu.MenuItems.Add(itemQuitados);
                menu.MenuItems.Add(itemRejeitado);
                menu.MenuItems.Add(itemNE);
                menu.MenuItems.Add(itemCopiar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }

            return menu;
        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

            if ( item.RadioCheck )
                foreach(MenuItem i in menuGrid.MenuItems)
                    i.Checked = false;
            
            switch (item.Text)
            {
                case "Rejeitados":
                    carregaGrid(dtBaixa.Select("status<>'baixado' and status<>'já quitado'"));
                    item.Checked = true;
                    break;
                case "Quitados":
                    carregaGrid(dtBaixa.Select("status='baixado' or status='já quitado'"));
                    item.Checked = true;
                    break;
                case "Não Encontrados":
                    carregaGrid(dtBaixa.Select("status='não encotrado'"));
                    item.Checked = true;
                    break;
                case "Todos":
                    carregaGrid(dtBaixa.Select());
                    item.Checked = true;
                    break;
                case "Copiar":
                    Clipboard.SetText(dgBaixa.SelectedCells[0].Value.ToString());
                    break;
                    
            }
        }
        private void carregaGrid(DataRow[] linha)
        {
            dgBaixa.Rows.Clear();

            foreach (DataRow dr in linha)
                dgBaixa.Rows.Add(new object[] { dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString() });
        }
        private void geraArquivo()
        {
            //string diretorio = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Baixas - Resultado\" + getTexto(cbEmpresa) + @"\" + getTexto(cbBancos);
            string diretorio = @"E:\Baixas - Resultado\" + getTexto(cbEmpresa) + @"\" + getTexto(cbBancos);
            CarSystem.Utilidades.IO.Arquivo.isExisteDir(diretorio,true);
            
            string arquivo = diretorio + @"\BAIXA_" + DateTime.Today.ToString("ddMMyyyy") + "_" + getTexto(cbEmpresa) + "_" + getTexto(cbBancos) + ".log";
            CarSystem.Utilidades.IO.Arquivo.stringTOtxt(arquivo, geraResultado());
        }

        private void dgBaixa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void cnab240_LinhaDeArquivoLida(object sender, LinhaDeArquivoLidaArgs e)
        {
            MessageBox.Show(e.Linha);
        }
    
        public void ArquivoSafra() {

            var fileContent = string.Empty;
            var filePath = string.Empty;
            Banco bco = new Banco(422);
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {



                    ArquivoRetornoCNAB240 cnab240 = null;
                    if (openFileDialog.CheckFileExists == true)
                    {
                        cnab240 = new ArquivoRetornoCNAB240();
                        cnab240.LinhaDeArquivoLida += new EventHandler<LinhaDeArquivoLidaArgs>(cnab240_LinhaDeArquivoLida);
                        cnab240.LerArquivoRetorno(bco, openFileDialog.OpenFile());
                    }

                    if (cnab240 == null)
                    {
                        MessageBox.Show("Arquivo não processado!");
                        return;
                    }


                    dgBaixa.Rows.Clear();
                   // foreach (DataRow dr in linha)
                       // dgBaixa.Rows.Add(new object[] { dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString() })
                    foreach (DetalheRetornoCNAB240 detalhe in cnab240.ListaDetalhes)
                    {
                        ListViewItem li = new ListViewItem(detalhe.SegmentoT.NomeSacado.Trim());
                        li.Tag = detalhe;
                        dgBaixa.Rows.Add(new object[] { detalhe.SegmentoT.DataVencimento.ToString("dd/MM/yy"), detalhe.SegmentoU.DataCredito.ToString("dd/MM/yy"), detalhe.SegmentoT.ValorTitulo.ToString("###,###.00"), detalhe.SegmentoU.CodigoOcorrenciaSacado.ToString() });

                        //li.SubItems.Add(detalhe.SegmentoT.DataVencimento.ToString("dd/MM/yy"));
                        //li.SubItems.Add(detalhe.SegmentoU.DataCredito.ToString("dd/MM/yy"));
                        //li.SubItems.Add(detalhe.SegmentoT.ValorTitulo.ToString("###,###.00"));
                        //li.SubItems.Add(detalhe.SegmentoU.ValorPagoPeloSacado.ToString("###,###.00"));
                        //li.SubItems.Add(detalhe.SegmentoU.CodigoOcorrenciaSacado.ToString());
                        //li.SubItems.Add("");
                        //li.SubItems.Add(detalhe.SegmentoT.NossoNumero);
                        //dgBaixa.Items.Add(li);
                    }

                    MessageBox.Show("Arquivo aberto com sucesso!");
                }
            }
        }
    }
}