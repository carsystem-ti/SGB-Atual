using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Retorno = CarSystem.Banco.Bradesco.Retorno;

namespace SGB
{
    public partial class analiseRetorno : Form
    {
        string arquivoSelecionado;

        CarSystem.BancoDados.Dados _dados;

        public CarSystem.BancoDados.Dados dados
        {
            get 
            {
                if (_dados == null)
                {
                    _dados = new CarSystem.BancoDados.Dados();
                    _dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
                    _dados.Conexoes.bancoDados = "principal";
                    _dados.Conexoes.usuario = "usr_sgb";
                    _dados.Conexoes.senha = "sgb_usr";
                }

                return _dados; 
            }
            set { _dados = value; }
        }

        public analiseRetorno()
        {
            InitializeComponent();
        }

        private void retornoBradesco_Load(object sender, EventArgs e)
        {

        }
        private void cmdProcuraArquivo_Click(object sender, EventArgs e)
        {
            //arquivoSelecionado = @"D:\Projetos\VS2005\CarSystem\CarSystemLib\CarSystem.DLL\CB250501.RET"; // "c:\\CB100300.RET";
            //arquivoSelecionado = "c:\\CB100300.RET";
            //carregaTree();
            //return;

            OpenFileDialog dgProcuraArquivo = new OpenFileDialog();
            dgProcuraArquivo.FileOk += new CancelEventHandler(dgProcuraArquivo_FileOk);
            dgProcuraArquivo.Multiselect = false;
            dgProcuraArquivo.ShowDialog(this);
        }

        private void dgProcuraArquivo_FileOk(object sender, CancelEventArgs e)
        {
            if (e.Cancel)
                Application.Exit();

            arquivoSelecionado = ((OpenFileDialog)sender).FileName;
            textArquivoSelecionado.Text = arquivoSelecionado;
        }

        private System.Data.DataTable configuraTabelaArquivo ()
        {
            System.Data.DataTable iTabelaArquivo = new System.Data.DataTable();

            iTabelaArquivo.Columns.Add("Ordem", typeof(int));
            iTabelaArquivo.Columns.Add("NumeroContrato", typeof(string));
            iTabelaArquivo.Columns.Add("Descricao", typeof(string));
            iTabelaArquivo.Columns.Add("NossoNumero", typeof(string));
            iTabelaArquivo.Columns.Add("Valor", typeof(string));            

            return iTabelaArquivo;
        }
        private string criaArquivoLog(System.Data.DataTable pTabelaArquivo, string pNomeArquivo)
        {
            string iContrato = "";
            string iContratoAnterior = "";

            int iOrdenador = 0;

            foreach (System.Data.DataRow iLinha in pTabelaArquivo.Select("", "NumeroContrato asc"))
            {
                iContrato = iLinha["numeroContrato"].ToString();

                if (iContrato != iContratoAnterior && iContratoAnterior != "")
                {
                    iOrdenador = pTabelaArquivo.Select("NumeroContrato = '" + iContratoAnterior + "'").Length + 1;
                    pTabelaArquivo.Rows.Add(new object[] { iOrdenador, iContratoAnterior, "--", "", "" });
                    pTabelaArquivo.Rows.Add(new object[] { iOrdenador + 1, iContratoAnterior, "--------------------", "--------------------", "--------------------" });
                    pTabelaArquivo.Rows.Add(new object[] { iOrdenador + 2, iContratoAnterior, "--", "", "" });
                }

                iContratoAnterior = iContrato;
            }

            // \\10.0.0.210\arb\Baixas bancárias\Débito automático
            string iDiretorio = @"E:\Baixas - Resultado\Débito automático\" + pNomeArquivo;
            CarSystem.Utilidades.IO.Arquivo.isExisteDir(iDiretorio, true);

            string iArquivo = iDiretorio + @"\LOG_" + DateTime.Today.ToString("ddMMyyyy") + "_" + pNomeArquivo + ".log";

            CarSystem.Utilidades.IO.Arquivo.sqlTOtxt(pTabelaArquivo.Select("", "NumeroContrato asc, Ordem asc" ), iArquivo, true);
            CarSystem.Utilidades.IO.Arquivo.fechaEscritor();

            return iArquivo;
        }

        private void carregaTree()
        {
            if (checkBradesco.Checked)
                getBradesco();
            else if (checkHSBC.Checked)
                getHSBC();
            else if (checkCielo.Checked)
                getCielo();
            else if (checkItau.Checked)
                getItau();
            else if (checkSantander.Checked)
                getFebraban( );


        }
        private void getBradesco()
        {
            string iDescricaoCampo = "";
            string iValor;
            string iContrato = "";

            int iOrdenador;

            System.Collections.Queue iDescricoesCodigos;

            System.Data.DataTable iTabelaConteudo;

            System.Data.DataTable iTabelaTransitoria;

            System.Data.DataTable iTabelaConfirmados = configuraTabelaArquivo();
            System.Data.DataTable iTabelaRejeitados = configuraTabelaArquivo();
            

            TreeNode[] iGalho;
            TreeNode[] iGalhosSubCodigo;
            TreeNode[] iGalhoContrato;

            bool isSemCodigo = false;

            try
            {

                treeRetorno.Nodes.Clear();

                CarSystem.Banco.Bradesco.Retorno.newRegistro1 iRegistro = new CarSystem.Banco.Bradesco.Retorno.newRegistro1("Registro");

                iTabelaConteudo = iRegistro.getTabelaConteudo(arquivoSelecionado);

                barraProgresso.Minimum = 0;
                barraProgresso.Maximum = iTabelaConteudo.Rows.Count;

                barraProgresso.Value = 0;

                //iArquivoLog = arquivoSelecionado.Replace(".ret", "_LOG.txt");
                //CarSystem.Utilidades.IO.Arquivo.criaArquivo(ref iArquivoLog);

                foreach (System.Data.DataRow iLinha in iTabelaConteudo.Rows)
                {
                    barraProgresso.Value++;
                    iContrato = getContrato(iLinha["identificacaoTituloBanco_001"].ToString());

                    if (iContrato == "")
                        iContrato = "SEM CONTRATO";

                    iDescricoesCodigos = iRegistro.getDescricoesIdentificacaoOcorrencia(iLinha);

                    if (iDescricoesCodigos.Count == 0)
                        continue;
                    iDescricaoCampo = ""; 
                    while ( iDescricoesCodigos.Count > 0 ) {
                        if ( iDescricaoCampo == "" )
                            iDescricaoCampo = " ( "  + iDescricoesCodigos.Dequeue( ).ToString( );
                        else
                            iDescricaoCampo += " \\ " + iDescricoesCodigos.Dequeue( ).ToString( );
                    }
                    iDescricaoCampo += " ) ";
                    iGalho = treeRetorno.Nodes.Find(iDescricaoCampo, false);

                    if (iGalho.Length == 0)
                    {
                        iGalho = new TreeNode[1];
                        iGalho[0] = treeRetorno.Nodes.Add(iDescricaoCampo, iDescricaoCampo);
                    }

                    isSemCodigo = true;

                    while (iDescricoesCodigos.Count > 0 || isSemCodigo)
                    {
                        iValor = iLinha["valorTitulo"].ToString().Insert(iLinha["valorTitulo"].ToString().Length - 2, ",");
                        iValor = CarSystem.Utilidades.Formatar.formataReal(Convert.ToDouble(iValor));

                        iGalhoContrato = iGalho[0].Nodes.Find(iContrato, false);

                        if (iGalhoContrato.Length == 0)
                        {
                            iGalhoContrato = new TreeNode[1];
                            iGalhoContrato[0] = iGalho[0].Nodes.Add(iContrato, iContrato);
                        }

                        if (iDescricoesCodigos.Count > 0)
                            iGalhosSubCodigo = iGalhoContrato[0].Nodes.Find(iLinha["identificacaoTituloBanco_001"].ToString() + " - " + iValor, true);
                        else
                            iGalhosSubCodigo = treeRetorno.Nodes.Find(iLinha["identificacaoTituloBanco_001"].ToString() + " - " + iValor, false);

                        if (iDescricoesCodigos.Count > 0)
                        {
                            iDescricaoCampo = iDescricoesCodigos.Dequeue().ToString();

                            if (iGalhosSubCodigo.Length == 0)
                            {
                                iGalhosSubCodigo = new TreeNode[1];
                                iGalhosSubCodigo[0] = iGalhoContrato[0].Nodes.Add(iLinha["identificacaoTituloBanco_001"].ToString() + " - " + iValor, iLinha["identificacaoTituloBanco_001"].ToString() + " - " + iValor);
                            }

                            if (iDescricaoCampo.IndexOf("02 -") >= 0)
                                iTabelaTransitoria = iTabelaConfirmados;
                            else
                                iTabelaTransitoria = iTabelaRejeitados;

                            iOrdenador = iTabelaTransitoria.Select("NumeroContrato = '" + iContrato + "'").Length + 1;

                            if (iTabelaTransitoria.Select("NumeroContrato = '" + iContrato
                                    + "' and Descricao = '" + iDescricaoCampo
                                    + "' and NossoNumero = '" + iLinha["identificacaoTituloBanco_001"].ToString() + "'").Length == 0)
                                iTabelaTransitoria.Rows.Add(new object[] { iOrdenador, iContrato, iDescricaoCampo, iLinha["identificacaoTituloBanco_001"].ToString(), iValor });

                            iGalhosSubCodigo[0].Nodes.Add(iDescricaoCampo, iDescricaoCampo);
                        }
                        isSemCodigo = false;
                    }

                    treeRetorno.Refresh();

                    iGalho = null;
                }

                MessageBox.Show("Log gravado em: " + criaArquivoLog(iTabelaConfirmados, "CONFIRMADOS"));
                MessageBox.Show("Log gravado em: " + criaArquivoLog(iTabelaRejeitados, "REJEITADOS")); 

                CarSystem.Utilidades.IO.Arquivo.fechaEscritor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERRO",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void getHSBC()
        {
            string iDescricaoCampo = "";
            string iValor;
            string iContrato = "";

            int iOrdenador;

            System.Collections.Queue iDescricoesCodigos;

            System.Data.DataTable iTabelaConteudo;

            System.Data.DataTable iTabelaTransitoria;

            System.Data.DataTable iTabelaConfirmados = configuraTabelaArquivo();
            System.Data.DataTable iTabelaRejeitados = configuraTabelaArquivo();

            TreeNode[] iGalho;
            TreeNode[] iGalhosSubCodigo;
            TreeNode[] iGalhoContrato;

            bool isSemCodigo = false;

            try
            {

                treeRetorno.Nodes.Clear();

                CarSystem.Banco.HSBC.Remessa.RegistroF iRegistro = new CarSystem.Banco.HSBC.Remessa.RegistroF("RegistroF");

                iTabelaConteudo = iRegistro.getTabelaConteudo(arquivoSelecionado);

                barraProgresso.Minimum = 0;
                barraProgresso.Maximum = iTabelaConteudo.Rows.Count;

                barraProgresso.Value = 0;

                //iArquivoLog = arquivoSelecionado.Replace(".ret", "_LOG.txt");
                //CarSystem.Utilidades.IO.Arquivo.criaArquivo(ref iArquivoLog);

                foreach (System.Data.DataRow iLinha in iTabelaConteudo.Rows)
                {
                    barraProgresso.Value++;
                    iContrato = getContrato(iLinha[iRegistro.campoNossoNumero].ToString());

                    if (iContrato == "")
                        iContrato = "SEM CONTRATO";

                    iDescricoesCodigos = new System.Collections.Queue();
                    iDescricoesCodigos.Enqueue(iRegistro.getDescricaoCodigoRetorno(iLinha[iRegistro.campoCodigoRetorno].ToString()));

                    if (iDescricoesCodigos.Count == 0)
                        continue;

                    iDescricaoCampo = iDescricoesCodigos.Dequeue().ToString();
                    iGalho = treeRetorno.Nodes.Find(iDescricaoCampo, false);

                    if (iGalho.Length == 0)
                    {
                        iGalho = new TreeNode[1];
                        iGalho[0] = treeRetorno.Nodes.Add(iDescricaoCampo, iDescricaoCampo);
                    }

                    isSemCodigo = true;

                    while (iDescricoesCodigos.Count > 0 || isSemCodigo)
                    {
                        iValor = iLinha[iRegistro.campoValorPago].ToString().Insert(iLinha[iRegistro.campoValorPago].ToString().Length - 2, ",");
                        iValor = CarSystem.Utilidades.Formatar.formataReal(Convert.ToDouble(iValor));

                        iGalhoContrato = iGalho[0].Nodes.Find(iContrato, false);

                        if (iGalhoContrato.Length == 0)
                        {
                            iGalhoContrato = new TreeNode[1];
                            iGalhoContrato[0] = iGalho[0].Nodes.Add(iContrato, iContrato);
                        }

                        if (iDescricoesCodigos.Count > 0)
                            iGalhosSubCodigo = iGalhoContrato[0].Nodes.Find(iLinha[iRegistro.campoNossoNumero].ToString() + " - " + iValor, true);
                        else
                            iGalhosSubCodigo = treeRetorno.Nodes.Find(iLinha[iRegistro.campoNossoNumero].ToString() + " - " + iValor, false);


                        if (iGalhosSubCodigo.Length == 0)
                        {
                            iGalhosSubCodigo = new TreeNode[1];
                            iGalhosSubCodigo[0] = iGalhoContrato[0].Nodes.Add(iLinha[iRegistro.campoNossoNumero].ToString() + " - " + iValor, iLinha[iRegistro.campoNossoNumero].ToString() + " - " + iValor);
                        }

                        if (iDescricaoCampo.IndexOf("00 -") >= 0 || iDescricaoCampo.IndexOf("55 -") >= 0)
                            iTabelaTransitoria = iTabelaConfirmados;
                        else
                            iTabelaTransitoria = iTabelaRejeitados;

                        iOrdenador = iTabelaTransitoria.Select("NumeroContrato = '" + iContrato + "'").Length + 1;

                        iTabelaTransitoria.Rows.Add(new object[] { iOrdenador, iContrato, iDescricaoCampo, iLinha[iRegistro.campoNossoNumero].ToString(), iValor });

                        iGalhosSubCodigo[0].Nodes.Add(iDescricaoCampo, iDescricaoCampo);

                        isSemCodigo = false;
                    }

                    treeRetorno.Refresh();

                    iGalho = null;
                }

                MessageBox.Show("Log gravado em: " + criaArquivoLog(iTabelaConfirmados, "HSBC_CONFIRMADOS"));
                MessageBox.Show("Log gravado em: " + criaArquivoLog(iTabelaRejeitados, "HSBC_REJEITADOS"));

                CarSystem.Utilidades.IO.Arquivo.fechaEscritor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void getCielo()
        {
            string iDescricaoCampo = "";
            string iValor;
            string iContrato = "";

            string iIdentificador = "";

            int iOrdenador;

            System.Collections.Queue iDescricoesCodigos;

            System.Data.DataTable iTabelaConteudo;

            System.Data.DataTable iTabelaTransitoria;

            System.Data.DataTable iTabelaConfirmados = configuraTabelaArquivo();
            System.Data.DataTable iTabelaRejeitados = configuraTabelaArquivo();

            TreeNode[] iGalho;
            TreeNode[] iGalhosSubCodigo;
            TreeNode[] iGalhoContrato;

            bool isSemCodigo = false;

            try
            {
                treeRetorno.Nodes.Clear();

                CarSystem.Banco.Cielo.Remessa.Detalhe iRegistro = new CarSystem.Banco.Cielo.Remessa.Detalhe("DetalheCielo");

                iTabelaConteudo = iRegistro.getTabelaConteudo(arquivoSelecionado, false);

                barraProgresso.Minimum = 0;
                barraProgresso.Maximum = iTabelaConteudo.Rows.Count;

                barraProgresso.Value = 0;

                //iArquivoLog = arquivoSelecionado.Replace(".ret", "_LOG.txt");
                //CarSystem.Utilidades.IO.Arquivo.criaArquivo(ref iArquivoLog);

                foreach (System.Data.DataRow iLinha in iTabelaConteudo.Rows)
                {
                    barraProgresso.Value++;

                    iIdentificador = iLinha[iRegistro.campoNossoNumero].ToString();

                    iContrato = getContrato(iIdentificador.Length == 0 ? 0 : Convert.ToInt64(iLinha[iRegistro.campoNossoNumero]));

                    if (iContrato == "")
                        iContrato = "SEM CONTRATO";

                    iDescricoesCodigos = new System.Collections.Queue();
                    iDescricoesCodigos.Enqueue(iRegistro.getErro(iLinha));

                    if (iDescricoesCodigos.Count == 0)
                        continue;

                    iDescricaoCampo = iDescricoesCodigos.Dequeue().ToString();
                    iGalho = treeRetorno.Nodes.Find(iDescricaoCampo, false);

                    if (iGalho.Length == 0)
                    {
                        iGalho = new TreeNode[1];
                        iGalho[0] = treeRetorno.Nodes.Add(iDescricaoCampo, iDescricaoCampo);
                    }

                    isSemCodigo = true;

                    while (iDescricoesCodigos.Count > 0 || isSemCodigo)
                    {
                        iValor = iLinha[iRegistro.campoValorPago].ToString().Insert(iLinha[iRegistro.campoValorPago].ToString().Length - 2, ",");
                        iValor = CarSystem.Utilidades.Formatar.formataReal(Convert.ToDouble(iValor));

                        iGalhoContrato = iGalho[0].Nodes.Find(iContrato, false);

                        if (iGalhoContrato.Length == 0)
                        {
                            iGalhoContrato = new TreeNode[1];
                            iGalhoContrato[0] = iGalho[0].Nodes.Add(iContrato, iContrato);
                        }

                        if (iDescricoesCodigos.Count > 0)
                            iGalhosSubCodigo = iGalhoContrato[0].Nodes.Find(iLinha[iRegistro.campoNossoNumero].ToString() + " - " + iValor, true);
                        else
                            iGalhosSubCodigo = treeRetorno.Nodes.Find(iLinha[iRegistro.campoNossoNumero].ToString() + " - " + iValor, false);

                        if (iGalhosSubCodigo.Length == 0)
                        {
                            iGalhosSubCodigo = new TreeNode[1];
                            iGalhosSubCodigo[0] = iGalhoContrato[0].Nodes.Add(iLinha[iRegistro.campoNossoNumero].ToString() + " - " + iValor, iLinha[iRegistro.campoNossoNumero].ToString() + " - " + iValor);
                        }

                        if (iDescricaoCampo.IndexOf("00") >= 0)
                            iTabelaTransitoria = iTabelaConfirmados;
                        else
                            iTabelaTransitoria = iTabelaRejeitados;

                        iOrdenador = iTabelaTransitoria.Select("NumeroContrato = '" + iContrato + "'").Length + 1;

                        iTabelaTransitoria.Rows.Add(new object[] { iOrdenador, iContrato, iDescricaoCampo, iLinha[iRegistro.campoNossoNumero].ToString(), iValor });

                        iGalhosSubCodigo[0].Nodes.Add(iDescricaoCampo, iDescricaoCampo);

                        isSemCodigo = false;
                    }

                    treeRetorno.Refresh();

                    iGalho = null;
                }

                MessageBox.Show("Log gravado em: " + criaArquivoLog(iTabelaConfirmados, "CIELO_CONFIRMADOS"));
                MessageBox.Show("Log gravado em: " + criaArquivoLog(iTabelaRejeitados, "CIELO_REJEITADOS"));

                CarSystem.Utilidades.IO.Arquivo.fechaEscritor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string getContrato(string pNossoNumero)
        {
            System.Data.DataTable iTabela;

            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "SGB.Debito.pro_getContrato";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@nossoNumero", SqlDbType.VarChar, 12, pNossoNumero);
            dados.retornaDados = true;

            iTabela = dados.execute().Tables[0];

            if (iTabela.Rows.Count > 0)
                return iTabela.Rows[0][0].ToString();

            return "";
        }
        private string getContrato(Int64 pCodigoParcela)
        {
            System.Data.DataTable iTabela;

            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "SGB.Debito.pro_getContrato";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@nossoNumero", SqlDbType.VarChar, 12, DBNull.Value);
            dados.Comandos.adicionaParametro("@codigoParcela", SqlDbType.BigInt, 8, pCodigoParcela);
            dados.retornaDados = true;

            iTabela = dados.execute().Tables[0];

            if (iTabela.Rows.Count > 0)
                return iTabela.Rows[0][0].ToString();

            return "";
        }

        private void cmdSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private string getArquivoLog()
        {
            using (SaveFileDialog dgSalvarArquivo = new SaveFileDialog())
            {
                dgSalvarArquivo.FileOk += new CancelEventHandler(dgSalvarArquivo_FileOk);
                dgSalvarArquivo.InitialDirectory = textArquivoSelecionado.Text.Substring(0, arquivoSelecionado.LastIndexOf("\\"));
                dgSalvarArquivo.ShowDialog(this);
            }

            return arquivoSelecionado;
        }

        private void dgSalvarArquivo_FileOk(object sender, CancelEventArgs e)
        {
            if (e.Cancel)
                throw new Exception("O Arquivo deve ser selecionado!!");

            arquivoSelecionado = ((SaveFileDialog)sender).FileName;            
        }

        private void cmdCarregar_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(arquivoSelecionado))
                MessageBox.Show("O arquivo selecionado não existe!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                carregaTree();
                this.Cursor = System.Windows.Forms.Cursors.Arrow;
                MessageBox.Show("Carregamento Concluído!!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void treeRetorno_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picHSBC_Click(object sender, EventArgs e)
        {
            checkHSBC.Checked = true;
        }

        private void checkHSBC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void picCielo_Click(object sender, EventArgs e)
        {
            checkCielo.Checked = true;
        }

        private void picSantander_Click(object sender, EventArgs e)
        {
            checkSantander.Checked = true;
        }
        private TreeNode setGalho(TreeNode pGalhoPai, string pChave, string pTexto, bool pAdicionar)
        {
            TreeNode[] iGalhos; 
            
            if ( pGalhoPai != null )
                iGalhos = pGalhoPai.Nodes.Find(pChave, true);
            else
                iGalhos = treeRetorno.Nodes.Find(pChave, true);

            if ( iGalhos.Length > 0 && !pAdicionar)
                return iGalhos[0];

            if ( pGalhoPai != null )
                return pGalhoPai.Nodes.Add(pChave,pTexto);

            return treeRetorno.Nodes.Add(pChave,pTexto);
        }
        private void getItau()
        {
            string iDescricaoCampo = "";
            string iValor;
            string iContrato = "";
            string iIdentificador = "";

            int iOrdenador;
            int iCodigoTabela;

            System.Data.DataTable iTabelaConteudo;
            System.Data.DataTable[] iTabelas = new System.Data.DataTable[5];

            try
            {
                treeRetorno.Nodes.Clear();

                CarSystem.Banco.Itau.Retorno.RegistroDetalhe iRegistro = new CarSystem.Banco.Itau.Retorno.RegistroDetalhe("DetalheCielo");

                iTabelaConteudo = iRegistro.getTabelaConteudo(arquivoSelecionado, false);

                barraProgresso.Minimum = 0;
                barraProgresso.Maximum = iTabelaConteudo.Rows.Count;

                barraProgresso.Value = 0;

                //iArquivoLog = arquivoSelecionado.Replace(".ret", "_LOG.txt");
                //CarSystem.Utilidades.IO.Arquivo.criaArquivo(ref iArquivoLog);

                foreach (System.Data.DataRow iLinha in iTabelaConteudo.Rows)
                {
                    barraProgresso.Value++;

                    iIdentificador = iLinha[iRegistro.campoNossoNumero].ToString();

                    //iContrato = getContrato(iIdentificador.Length == 0 ? 0 : Convert.ToInt64(iLinha[iRegistro.campoNossoNumero]));
                    iContrato = getContrato(iIdentificador.Length == 0 ? "" : iLinha[iRegistro.campoNossoNumero].ToString());

                    if (iContrato == "")
                        iContrato = "SEM CONTRATO";

                    foreach (string iConteudo in iRegistro.getCodigosOcorrencia(iLinha))
                    {

                        iValor = iLinha[iRegistro.campoValorPago].ToString().Insert(iLinha[iRegistro.campoValorPago].ToString().Length - 2, ",");
                        iValor = CarSystem.Utilidades.Formatar.formataReal(Convert.ToDouble(iValor));

                        iDescricaoCampo = iRegistro.getDescricaoOcorrencia(iConteudo);

                        if (iConteudo == "00")
                        {
                            setGalho(setGalho(null, "EFETUADO", "EFETUADO", false), iContrato, iDescricaoCampo + " - " + iValor, true);
                            iCodigoTabela = 0;
                        }
                        else if (iConteudo == "02")
                        {
                            setGalho(setGalho(null, "CANCELADO", "CANCELADO", false), iContrato, iDescricaoCampo + " - " + iValor, true);
                            iCodigoTabela = 1;
                        }
                        else if (iConteudo == "03")
                        {
                            setGalho(setGalho(null, "AUTORIZADO", "AUTORIZADO", false), iContrato, iDescricaoCampo + " - " + iValor, true);
                            iCodigoTabela = 2;
                        }
                        else if (iConteudo == "BD")
                        {
                            setGalho(setGalho(null, "CONFIRMADO", "CONFIRMADO", false), iContrato, iDescricaoCampo + " - " + iValor, true);
                            iCodigoTabela = 3;
                        }
                        else
                        {
                            setGalho(setGalho(null, "REJEITADO", "REJEITADO", false), iContrato, iDescricaoCampo + " - " + iValor, true);
                            iCodigoTabela = 4;
                        }

                        if (iTabelas[iCodigoTabela] == null)
                            iTabelas[iCodigoTabela] = configuraTabelaArquivo();

                        iOrdenador = iTabelas[iCodigoTabela].Select("NumeroContrato = '" + iContrato + "'").Length + 1;


                        iTabelas[iCodigoTabela].Rows.Add(new object[] { iOrdenador, iContrato, iDescricaoCampo, iLinha[iRegistro.campoNossoNumero].ToString(), iValor });

                    }

                    treeRetorno.Refresh();

                }

                if (iTabelas[0] != null)
                    MessageBox.Show("Log gravado em: " + criaArquivoLog(iTabelas[0], "ITAU_EFETUADO"));
                if (iTabelas[1] != null)
                    MessageBox.Show("Log gravado em: " + criaArquivoLog(iTabelas[1], "ITAU_CANCELADO"));
                if (iTabelas[2] != null)
                    MessageBox.Show("Log gravado em: " + criaArquivoLog(iTabelas[2], "ITAU_AUTORIZADO"));
                if (iTabelas[3] != null)
                    MessageBox.Show("Log gravado em: " + criaArquivoLog(iTabelas[3], "ITAU_CONFIRMADO"));
                if (iTabelas[4] != null)
                    MessageBox.Show("Log gravado em: " + criaArquivoLog(iTabelas[4], "ITAU_REJEITADO"));

                CarSystem.Utilidades.IO.Arquivo.fechaEscritor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picItau_Click(object sender, EventArgs e)
        {
            checkItau.Checked = true;
        }

        private void getFebraban ( ) {
            string iValor;
            string iContrato = "";

            int iOrdenador;

            string[] iDescricoesCodigos;

            System.Data.DataTable iTabelaConteudo;

            System.Data.DataTable iTabelaTransitoria;

            System.Data.DataTable iTabelaConfirmados = configuraTabelaArquivo( );
            System.Data.DataTable iTabelaRejeitados = configuraTabelaArquivo( );


            TreeNode[] iGalho;
            TreeNode[] iGalhosSubCodigo;
            TreeNode[] iGalhoContrato;

            string iNossoNumero = "";

            try {

                treeRetorno.Nodes.Clear( );

                CarSystem.Banco.Febraban.Registros.RegistroFRetorno iRegistro = new CarSystem.Banco.Febraban.Registros.RegistroFRetorno( "Santander" );

                iTabelaConteudo = iRegistro.getTabelaConteudo( arquivoSelecionado );

                barraProgresso.Minimum = 0;
                barraProgresso.Maximum = iTabelaConteudo.Rows.Count;

                barraProgresso.Value = 0;

                //iArquivoLog = arquivoSelecionado.Replace(".ret", "_LOG.txt");
                //CarSystem.Utilidades.IO.Arquivo.criaArquivo(ref iArquivoLog);

                foreach (System.Data.DataRow iLinha in iTabelaConteudo.Rows) {
                    barraProgresso.Value++;
                    iNossoNumero = iLinha[CarSystem.Banco.Febraban.Registros.RegistroFRetorno.RegistroF.UsoEmpresa.ToString( )].ToString( );
                    iContrato = getContrato( iNossoNumero );

                    if (iContrato == "")
                        iContrato = "SEM CONTRATO";

                    iDescricoesCodigos = CarSystem.Banco.Febraban.Funcoes.getDescricaoCodigoRetorno( iLinha[CarSystem.Banco.Febraban.Registros.RegistroFRetorno.RegistroF.CodigoRetorno.ToString( )].ToString( ) );

                    iGalho = treeRetorno.Nodes.Find( iDescricoesCodigos[0], false );

                    if (iGalho.Length == 0) {
                        iGalho = new TreeNode[1];
                        iGalho[0] = treeRetorno.Nodes.Add( iDescricoesCodigos[0], iDescricoesCodigos[0] );
                    }

                    iValor = iLinha[CarSystem.Banco.Febraban.Registros.RegistroFRetorno.RegistroF.ValorOriginalDebitado.ToString( )].ToString( ).Insert( iLinha[CarSystem.Banco.Febraban.Registros.RegistroFRetorno.RegistroF.ValorOriginalDebitado.ToString( )].ToString( ).Length - 2, "," );
                    iValor = CarSystem.Utilidades.Formatar.formataReal( Convert.ToDouble( iValor ) );

                    iGalhoContrato = iGalho[0].Nodes.Find( iContrato, false );

                    if (iGalhoContrato.Length == 0) {
                        iGalhoContrato = new TreeNode[1];
                        iGalhoContrato[0] = iGalho[0].Nodes.Add( iContrato, iContrato );
                    }

                    iGalhosSubCodigo = iGalhoContrato[0].Nodes.Find( iNossoNumero + " - " + iValor, true );

                    if (iGalhosSubCodigo.Length == 0) {
                        iGalhosSubCodigo = new TreeNode[1];
                        iGalhosSubCodigo[0] = iGalhoContrato[0].Nodes.Add( iNossoNumero + " - " + iValor, iNossoNumero + " - " + iValor );
                    }

                    if (iLinha[CarSystem.Banco.Febraban.Registros.RegistroFRetorno.RegistroF.CodigoRetorno.ToString( )].ToString( ).IndexOf( "00" ) >= 0
                        || iLinha[CarSystem.Banco.Febraban.Registros.RegistroFRetorno.RegistroF.CodigoRetorno.ToString( )].ToString( ).IndexOf( "31" ) >= 0
                        )
                        iTabelaTransitoria = iTabelaConfirmados;
                    else
                        iTabelaTransitoria = iTabelaRejeitados;

                    iOrdenador = iTabelaTransitoria.Select( "NumeroContrato = '" + iContrato + "'" ).Length + 1;

                    if (iTabelaTransitoria.Select( "NumeroContrato = '" + iContrato
                            + "' and Descricao = '" + iDescricoesCodigos[1]
                            + "' and NossoNumero = '" + iNossoNumero + "'" ).Length == 0)
                        iTabelaTransitoria.Rows.Add( new object[] { iOrdenador, iContrato, iDescricoesCodigos[1], iNossoNumero, iValor } );

                    iGalhosSubCodigo[0].Nodes.Add( iDescricoesCodigos[1], iDescricoesCodigos[1] );
                }

                treeRetorno.Refresh( );

                iGalho = null;


                MessageBox.Show( "Log gravado em: " + criaArquivoLog( iTabelaConfirmados, "CONFIRMADOS" ) );
                MessageBox.Show( "Log gravado em: " + criaArquivoLog( iTabelaRejeitados, "REJEITADOS" ) );

                CarSystem.Utilidades.IO.Arquivo.fechaEscritor( );
            } catch (Exception ex) {
                MessageBox.Show( ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

       
    }
}
