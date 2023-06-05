using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BoletoBr.Bancos.Daycoval;
using BoletoNet;
using CarSystem.BancoDados;
using BoletoBr;
using Microsoft.Win32;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using System.Security;

namespace SGB
{
    public partial class Serasa : Form
    {
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
        public Serasa()
        {
            InitializeComponent();
            PreencheDados();
            chkInseriManual.Enabled = true;
            this.listaRemessa.DrawItem += new DrawItemEventHandler(this.listaRemessa_DrawItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = getDadosRemessaSerasa();
            // dataGridView1.Rows.Add(ds);
            decimal valortotal = 0;
            List<SerasaModel> SerasaLista = new List<SerasaModel>();



            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SerasaModel serasa = new SerasaModel();
                serasa.Documento = ds.Tables[0].Rows[i]["Documento"].ToString();
                serasa.Cliente = ds.Tables[0].Rows[i]["Cliente"].ToString();
                serasa.Parcela = ds.Tables[0].Rows[i]["Parcela"].ToString();
                serasa.CodDebito = ds.Tables[0].Rows[i]["CodDebito"].ToString();
                serasa.Valor = ds.Tables[0].Rows[i]["Valor"].ToString();
                valortotal += Convert.ToDecimal(ds.Tables[0].Rows[i]["Valor"].ToString());
                SerasaLista.Add(serasa);
            }
            //txtTotal.Text = ds.Tables[0].Rows.Count.ToString();
            //txtTotal.Text = valortotal.ToString("C");

            dg_Filtrados.DataSource = SerasaLista;


        }
        private System.Data.DataSet getDadosRemessaSerasa()
        {
            string nomeFuncao = "CarSystem.pro_getDividasNegativacao";

            try
            {
                dados.Comandos.limpaParametros();

                dados.Comandos.textoComando = "Principal.Negativacao.pro_getDividasNegativacao";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;
                dados.retornaDados = true;
                return dados.execute();

            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }


        }
        private void CriaLoteSerasa()
        {

            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "Principal.[Negativacao].[pro_setCriaArquivoEnvioSerasa]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@tipo", SqlDbType.Int, 30, 1);
            dados.retornaDados = true;
            dados.execute();
        }
        private DataSet getRangeSerasa(string remessa)
        {
            DataSet ds = new DataSet();
            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "Principal.[Negativacao].[pro_getLiberaRangeSerasa]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@id_remessa", SqlDbType.VarChar, 30, remessa);
            dados.retornaDados = true;
            ds = dados.execute();
            if (ds.Tables.Count > 0)
            {
                return ds;
                //return ds.Tables[0].Rows[0]["id_remessa"].ToString() + '-' +  ds.Tables[0].Rows[0]["ds_remessa"].ToString();
            }
            else
            {
                return ds;
            }

        }
        private DataSet getBoletos(string remessa,int id_status)
        {
            DataSet ds = new DataSet();
            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "Principal.[Negativacao].[pro_getArquivoRemessa]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@id_remessa", SqlDbType.VarChar, 12, remessa);
            dados.Comandos.adicionaParametro("@id_status", SqlDbType.VarChar, 12, id_status);

            dados.retornaDados = true;
            ds = dados.execute();

            return ds;
        }
        private DataSet getDividasInad(string remessa, int id_status)
        {
            DataSet ds = new DataSet();
            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "Principal.[Negativacao].[pro_getArquivoRemessaInad]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@id_remessa", SqlDbType.VarChar, 12, remessa);
            dados.Comandos.adicionaParametro("@id_status", SqlDbType.VarChar, 12, id_status);

            dados.retornaDados = true;
            ds = dados.execute();

            return ds;
        }
        private DataSet getDadosListaRemessa(int id_remessa, int tipo)
        {
            DataSet ds = new DataSet();
            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "[Negativacao].[pro_getListaRemessa]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@tipo", SqlDbType.Int, 120, tipo);
            dados.Comandos.adicionaParametro("@id_remessa", SqlDbType.VarChar, 30, id_remessa);
            dados.retornaDados = true;
            ds = dados.execute();

            return ds;
        }
        private DataSet getSequencia()
        {
            DataSet ds = new DataSet();
            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "[Negativacao].[pro_getSequencia]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.retornaDados = true;
            ds = dados.execute();

            return ds;
        }
        private void setSequencia(string sequencia)
        {
            DataSet ds = new DataSet();
            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "[Negativacao].[pro_setSequencia]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@sequencia", SqlDbType.VarChar, 6, sequencia);

            dados.retornaDados = true;
            dados.execute();
        }
        private DataSet getDadosListaRemessa(string nr_consulta)
        {
            DataSet ds = new DataSet();
            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "[Negativacao].[pro_getconsultaPorFiltro]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@nr_consulta", SqlDbType.VarChar, 18, nr_consulta);
            dados.retornaDados = true;
            ds = dados.execute();

            return ds;
        }
        private void PreencheDados()
        {
            System.Data.DataSet dtEmpresa;


            dtEmpresa = getArquivo();

            //CarSystem.Tipos.Funcoes.preencheCombo(new CarSystem.Tipos.empresas(), cbEmpresa);
            //cmbarquivo.DataSource = dtEmpresa.Tables[0];


            //cmbarquivo.DisplayMember = "ds_remessa";
            //cmbarquivo.ValueMember = "id_remessa";
            listaRemessa.DataSource = dtEmpresa.Tables[0];
            listaRemessa.DisplayMember = "ds_remessa";
            listaRemessa.ValueMember = "id_remessa";

            txtsequencia.Text = dtEmpresa.Tables[0].Rows[0]["sequencia"].ToString();

        }
        private DataSet getArquivo()
        {
            DataSet ds = new DataSet();
            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "[Negativacao].[pro_getRemessas]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.retornaDados = true;
            ds = dados.execute();

            return ds;
        }
        private void setAlteraParcela(int parcela, int tp, int remessa, string id_erro, int tipo)
        {

            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "Principal.[Negativacao].[pro_seAtualizaParcela]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@tipo", SqlDbType.VarChar, 15, tipo);
            dados.Comandos.adicionaParametro("@id_controle", SqlDbType.VarChar, 15, parcela);
            dados.Comandos.adicionaParametro("@id_status", SqlDbType.VarChar, 12, tp);
            dados.Comandos.adicionaParametro("@usuario", SqlDbType.VarChar, 80, Environment.UserName);
            dados.Comandos.adicionaParametro("@id_remessa", SqlDbType.VarChar, 12, remessa);
            dados.Comandos.adicionaParametro("@cd_erro", SqlDbType.VarChar, 12, id_erro);

            dados.retornaDados = false;
            dados.execute();


        }
        private void setListaNegra(int parcela, int tp, int remessa, string id_erro)
        {

            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "Principal.[Negativacao].[pro_seAtualizaParcela]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@id_parcela", SqlDbType.VarChar, 15, parcela);
            dados.Comandos.adicionaParametro("@id_status", SqlDbType.VarChar, 12, tp);
            dados.Comandos.adicionaParametro("@usuario", SqlDbType.VarChar, 80, Environment.UserName);
            dados.Comandos.adicionaParametro("@id_remessa", SqlDbType.VarChar, 12, remessa);
            dados.Comandos.adicionaParametro("@cd_erro", SqlDbType.VarChar, 12, id_erro);

            dados.retornaDados = false;
            dados.execute();


        }
        private void setListaNegra(string doc)
        {

            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "Principal.[Negativacao].[pro_setBlackList]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@nr_cpf_cnpj", SqlDbType.VarChar, 18, doc);
            dados.Comandos.adicionaParametro("@usuario", SqlDbType.VarChar, 80, Environment.UserName);


            dados.retornaDados = false;
            dados.execute();


        }
        private void btnArquivo_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Você validou a sequência de 6 caracteres a ser utilizada no arquivo?" + Environment.NewLine +
                "Deseja realmente gerar arquivo remessa ? "
                , "Atenção", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataSet dsRegistro = new DataSet();

                //PreencheDados();
                int sequencia = 0;

                string id_remessa = txtRemessa.Text;
                if (id_remessa != "Remessa" && id_remessa != "")
                {
                    //CriaLoteSerasa();
                    dsRegistro = getRangeSerasa(id_remessa);
                    string nomeArquivo = dsRegistro.Tables[0].Rows[0]["ds_remessa"].ToString();
                    id_remessa = dsRegistro.Tables[0].Rows[0]["id_remessa"].ToString();
                    Stream arquivo = File.OpenWrite(@"C:\\TEMP\" + "INCLUSAO-" + nomeArquivo.ToString() + ".txt"); // @"C:\Temp\Mahesh.txt";
                    StreamWriter gravaLinha = new StreamWriter(arquivo);

                    var header = new StringBuilder();

                    #region HEADER

                    //Codigo Registro Posicao 1 
                    header.Append("0");
                    // Console.WriteLine(header.Length);
                    //Número do informante Posicao 2 á 9
                    header.Append("004401579");
                    // Console.WriteLine(header.Length);
                    //Data da movimentação AAAAMMDD Posicao 2 á 9
                    header.Append(Utils.FitStringLength(DateTime.Now.ToString("yyyyMMdd"), 11, 8, ' ', 0, true, true, false));
                    //  Console.WriteLine(header.Length);
                    //Número do DDD do telefone  da Instituiçaõ
                    header.Append(Utils.FitStringLength("0011", 19, 4, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Número do telefone de contato da Instituição
                    header.Append(Utils.FitStringLength("56453377", 23, 8, ' ', 0, true, true, false));
                    //Console.WriteLine(header.Length);

                    //Número do ramal de contato da Instituiçaõ
                    header.Append(Utils.FitStringLength("3377", 31, 4, ' ', ' ', true, true, false));
                    ///Console.WriteLine(header.Length);
                    //Nome do contato da Instituição
                    header.Append(Utils.FitStringLength("CARSYSTEM ALARMES LTDA", 35, 70, ' ', ' ', true, true, false));
                    ///Console.WriteLine(header.Length);
                    //Identificação do arquivo
                    header.Append(Utils.FitStringLength("SERASA-CONVEM04", 105, 15, ' ', 0, true, true, false));
                    //Console.WriteLine(header.Length);
                    //Número de remessa
                    header.Append(Utils.FitStringLength(txtsequencia.Text, 120, 6, '0', 0, true, true, true));
                    //Console.WriteLine(header.Length);
                    //Código de Envio de arquivo
                    header.Append(Utils.FitStringLength("E", 126, 1, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Diferencial remessa
                    header.Append(Utils.FitStringLength("", 127, 4, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Deixar em branco
                    header.Append(Utils.FitStringLength(" ", 131, 3, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Informar o LOGON a ser utilizado
                    header.Append(Utils.FitStringLength(" ", 134, 8, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Deixar em branco
                    header.Append(Utils.FitStringLength(" ", 142, 392, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Deixar em branco
                    header.Append(Utils.FitStringLength(" ", 534, 60, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Sequencia de Codigo
                    header.Append(Utils.FitStringLength("0000001", 594, 7, ' ', ' ', true, true, false));
                    int tamanho = header.Length;
                    //MessageBox.Show(tamanho.ToString());
                    var headerFormatado = Utils.SubstituiCaracteresEspeciais(header.ToString());


                    gravaLinha.WriteLine(headerFormatado);



                    #endregion

                    #region Detalhe

                    //Codigo Registro Posicao 1 



                    DataSet ds = getDividasInad(id_remessa,1);

                    ///sageBox.Show("Quantidade de Boletos a ser processado : " + ds.Tables.Count.ToString() + " !!!");
                    ///sageBox.Show("Quantidade de Boletos a ser processado : " + ds.Tables.Count.ToString() + " !!!");
                    sequencia = 2;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var detalhe = new StringBuilder();
                        //Código do registro (1) 
                        detalhe.Append("1");
                        ////MessageBox.Show("01 DE " + detalhe.Length.ToString());
                        //Código de operação Posicao 2
                        detalhe.Append("I");
                        ////MessageBox.Show("02 DE " + detalhe.Length.ToString());
                        //Filial e Digito do CNPJ  Posicao 3 ?
                        detalhe.Append("000155");
                        // //MessageBox.Show("08 DE " + detalhe.Length.ToString());
                        //Data da Ocorrencia
                        DateTime dt_vencimento = Convert.ToDateTime(dr["dataVencimento"].ToString());
                        detalhe.Append(Utils.FitStringLength(dt_vencimento.ToString("yyyyMMdd"), 9, 8, ' ', 0, true, true, false));
                        //MessageBox.Show("9 A 16 " + detalhe.Length.ToString());
                        DateTime dt_validade = Convert.ToDateTime(dr["dt_validade"].ToString());
                        //Data do termino do contrato
                        detalhe.Append(Utils.FitStringLength(dt_validade.ToString("yyyyMMdd"), 17, 8, ' ', 0, true, true, false));
                        //MessageBox.Show("17 A 24 " + detalhe.Length.ToString());
                        //Código Natureza da operação
                        detalhe.Append(Utils.FitStringLength("VM", 25, 3, ' ', ' ', true, true, false));
                        //MessageBox.Show("25 A 27 " + detalhe.Length.ToString());
                        //Código da praça Embratel
                        detalhe.Append(Utils.FitStringLength("0011", 28, 4, ' ', ' ', true, true, false));
                        //MessageBox.Show("28 A 31 " + detalhe.Length.ToString());
                        //Tipo de Pessoa (F OU J)
                        detalhe.Append(Utils.FitStringLength(dr["tipoPessoa"].ToString(), 32, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("32 A 32 " + detalhe.Length.ToString());
                        //Tipo do primeiro DOC (CNPJ e CPF)
                        detalhe.Append(Utils.FitStringLength(dr["tipoDoc"].ToString(), 33, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("33 A 33 " + detalhe.Length.ToString());
                        //Primeiro documento Principal (CNPJ e CPF)
                        detalhe.Append(dr["numeroDocumento"].ToString());
                        //MessageBox.Show("34 A 48 " + detalhe.Length.ToString());
                        //Motivo da Baixa ver
                        detalhe.Append(Utils.FitStringLength("", 49, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("49 A 49 " + detalhe.Length.ToString());
                        //Tipo do segundo  documento
                        detalhe.Append(Utils.FitStringLength("", 51, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("51 A 51 " + detalhe.Length.ToString());
                        //Tipo do segundo
                        detalhe.Append(Utils.FitStringLength("", 52, 15, ' ', ' ', true, true, false));
                        //MessageBox.Show("52 A 66 " + detalhe.Length.ToString());
                        //UF Quando DOC for RG
                        detalhe.Append(Utils.FitStringLength("", 67, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("67 A 68 " + detalhe.Length.ToString());
                        //Tipo de pessoa do coobrigado
                        //detalhe.Append(Utils.FitStringLength(dr["tipoPessoa"].ToString(), 69, 1, ' ', ' ', true, true, false));
                        detalhe.Append(Utils.FitStringLength("", 69, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("69 A 69 " + detalhe.Length.ToString());
                        //Tipo do primeiro Documento
                        //detalhe.Append(Utils.FitStringLength(dr["tipoDoc"].ToString(), 70, 1, ' ', ' ', true, true, false));
                        detalhe.Append(Utils.FitStringLength("", 70, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("70 A 70 " + detalhe.Length.ToString());
                        //Primeiro Doc do coobrigado
                        //detalhe.Append(Utils.FitStringLength(dr["numeroDocumento"].ToString(), 71, 15, '0', 0, true, true, true));
                        detalhe.Append(Utils.FitStringLength("", 71, 15, ' ', ' ', true, true, false));
                        //MessageBox.Show("71 A 85 " + detalhe.Length.ToString());
                        //Espaços
                        detalhe.Append(Utils.FitStringLength("", 86, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("86 A 87 " + detalhe.Length.ToString());
                        //Espaços
                        detalhe.Append(Utils.FitStringLength("", 88, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("88 A 88 " + detalhe.Length.ToString());
                        //Espaços
                        detalhe.Append(Utils.FitStringLength("", 89, 15, ' ', ' ', true, true, false));
                        //MessageBox.Show("89 A 103 " + detalhe.Length.ToString());
                        //Unidade Federal
                        detalhe.Append(Utils.FitStringLength("", 104, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("104 A 105 " + detalhe.Length.ToString());
                        //Nome do Devedor
                        detalhe.Append(Utils.FitStringLength(dr["nomecliente"].ToString(), 106, 70, ' ', ' ', true, true, false));
                        //MessageBox.Show("106 A 175 " + detalhe.Length.ToString());
                        //Data de Nascimento
                        detalhe.Append(Utils.FitStringLength(dr["dt_nascimento"].ToString(), 176, 8, ' ', ' ', true, true, false));
                        //MessageBox.Show("176 A 183 " + detalhe.Length.ToString());
                        //Nome do Pai
                        detalhe.Append(Utils.FitStringLength("", 184, 70, ' ', ' ', true, true, false));
                        //MessageBox.Show("184 A 253 " + detalhe.Length.ToString());
                        //Nome do Mae
                        detalhe.Append(Utils.FitStringLength("", 254, 70, ' ', ' ', true, true, false));
                        //MessageBox.Show("254 A 253 " + detalhe.Length.ToString());
                        //Endereço completo
                        detalhe.Append(Utils.FitStringLength(dr["logradouro"].ToString(), 324, 45, ' ', ' ', true, true, false));
                        //MessageBox.Show("324 A 368 " + detalhe.Length.ToString());
                        //Bairro completo
                        detalhe.Append(Utils.FitStringLength(dr["bairro"].ToString(), 369, 20, ' ', ' ', true, true, false));
                        //MessageBox.Show("369 A 388 " + detalhe.Length.ToString());
                        //Municipio completo
                        detalhe.Append(Utils.FitStringLength(dr["Cidade"].ToString(), 389, 25, ' ', ' ', true, true, false));
                        //MessageBox.Show("389 A 413 " + detalhe.Length.ToString());
                        //Sigla Unidade Federativa
                        detalhe.Append(Utils.FitStringLength(dr["Uf"].ToString(), 414, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("414 A 415 " + detalhe.Length.ToString());
                        //Código Enderecamento
                        detalhe.Append(Utils.FitStringLength(dr["Cep"].ToString(), 416, 8, ' ', ' ', true, true, false));
                        //MessageBox.Show("416 A 423 " + detalhe.Length.ToString());
                        //Valor 
                        decimal valortotal = Convert.ToDecimal(dr["valor"].ToString());
                        string dValor = String.Format("{0:C}", valortotal).Replace(".","").Replace("R$ ","");
                        dValor = dValor.Replace(",","").PadLeft(15,'0');
                        detalhe.Append(dValor.ToString());
                        //MessageBox.Show("424 A 438 " + detalhe.Length.ToString());
                        //Número do contrato 
                        detalhe.Append(Utils.FitStringLength(dr["numero"].ToString(), 439, 16, ' ', ' ', true, true, false));
                        //MessageBox.Show("439 A 454 " + detalhe.Length.ToString());
                        //Nosso número
                        detalhe.Append(Utils.FitStringLength(dr["numero"].ToString(), 455, 9, ' ', ' ', true, true, false));
                        //MessageBox.Show("455 A 463 " + detalhe.Length.ToString());
                        //Complemento do endereço
                        detalhe.Append(Utils.FitStringLength(dr["Complemento"].ToString(), 464, 25, ' ', ' ', true, true, true));
                        //MessageBox.Show("464 A 488 " + detalhe.Length.ToString());
                        //DDD do telefone
                        detalhe.Append(Utils.FitStringLength("0011", 489, 4, ' ', ' ', true, true, false));
                        //MessageBox.Show("489 A 492 " + detalhe.Length.ToString());
                        //Telefone 
                        detalhe.Append(Utils.FitStringLength(dr["nr_celular"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Substring(2, dr["nr_celular"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Length - 2), 493, 9, ' ', ' ', true, true, false));
                        //MessageBox.Show("493 A 501 " + detalhe.Length.ToString());
                        //Data do compromisso

                        detalhe.Append(Utils.FitStringLength(dt_vencimento.ToString("yyyyMMdd"), 502, 8, ' ', ' ', true, true, false));
                        //MessageBox.Show("502 A 509 " + detalhe.Length.ToString());
                        //Valor do compromisso  
                        detalhe.Append(dValor.ToString());
                        //MessageBox.Show("510 A 524 " + detalhe.Length.ToString());
                        //Indicativo de envio
                        detalhe.Append(Utils.FitStringLength("", 525, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("525 A 525 " + detalhe.Length.ToString());
                        //Deixar em Branco
                        detalhe.Append(Utils.FitStringLength("", 526, 5, ' ', ' ', true, true, false));
                        //MessageBox.Show("526 A 530 " + detalhe.Length.ToString());
                        //Indicativo de tipo de Comunicado
                        detalhe.Append(Utils.FitStringLength("", 531, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("531 A 531 " + detalhe.Length.ToString());
                        //Deixar em Branco
                        detalhe.Append(Utils.FitStringLength("", 532, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("532 A 533 " + detalhe.Length.ToString());
                        //Deixar em Branco
                        detalhe.Append(Utils.FitStringLength("", 534, 60, ' ', ' ', true, true, false));
                        //MessageBox.Show("534 A 593 " + detalhe.Length.ToString());
                        //sequencia 
                        detalhe.Append(Utils.FitStringLength(sequencia.ToString(), 594, 7, '0', 0, true, true, true));
                        //MessageBox.Show("594 A 600 " + detalhe.Length.ToString());
                        var detalheFormatado = Utils.SubstituiCaracteresEspeciais(detalhe.ToString());
                        tamanho = detalhe.Length;
                        if (tamanho > 600 || tamanho < 600)
                        {
                            MessageBox.Show(dr["numeroDocumento"].ToString() + '-' + tamanho.ToString());
                        }

                        gravaLinha.WriteLine(detalheFormatado);
                        setAlteraParcela(Convert.ToInt32(dr["numero"].ToString()), 2, Convert.ToInt32(id_remessa), "", 1);
                        sequencia = sequencia + 1;

                    }

                    #endregion
                    #region Trailler
                    var trailer = new StringBuilder();
                    trailer.Append("9");
                    trailer.Append(Utils.FitStringLength("", 2, 592, ' ', ' ', true, true, false));
                    trailer.Append(Utils.FitStringLength(sequencia.ToString(), 594, 7, '0', 0, true, true, true));
                    var trailerFormatado = Utils.SubstituiCaracteresEspeciais(trailer.ToString());
                    gravaLinha.WriteLine(trailerFormatado);
                    MessageBox.Show("Arquivo gerado com sucesso,foram processados");
                    gravaLinha.Close();
                    AtualizaGrid(id_remessa);
                    #endregion
                }
                else
                {
                    MessageBox.Show("SELECIONE UMA REMESSA ANTES DE TENTAR GERAR ARQUIVO");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("OPERAÇÃO CANCELADA...");
            }



        }
        public void Buscasequencia()
        {

            DataSet ds = getSequencia();
            txtsequencia.Text = ds.Tables[0].Rows[0]["nr_sequencia"].ToString();



        }
        public void BuscaLinhaselecionada(string remessa)
        {
            string id_remessa = remessa.ToString();
            string tipo = "";
            string etapa = "";
            if (id_remessa != "System.Data.DataRowView")
            {
                txtRemessa.Text = id_remessa.ToString();
                DataSet ds = getDadosListaRemessa(Convert.ToInt32(id_remessa), 1);
                tipo = ds.Tables[0].Rows[0]["Etapa"].ToString().Substring(0, 1);
                etapa = ds.Tables[0].Rows[0]["Etapa"].ToString();
                dg_Filtrados.DataSource = ds.Tables[0];
                txtQuantidadeRemessa.Text = ds.Tables[0].Rows.Count.ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    chkErro.Visible = true;
                }
                else
                {
                    chkErro.Visible = false;
                }
                if (tipo == "I")
                {
                    if (etapa == "I-AGUARD. GERAR ARQUIVO")
                    {
                        btnArquivo.Enabled = true;
                        btnretornoInad.Enabled = false;
                    }
                    if (etapa == "I-AGUARDANDO ACEITACAO ARQ")
                    {
                        btnArquivo.Enabled = false;
                        btnretornoInad.Enabled = true;
                    }
                    pnlAdimplente.Enabled = false;
                    pnlInadimplente.Enabled = true;

                }
                else
                {

                    if (etapa == "A-AGUARD. GERAR ARQUIVO")
                    {
                        btnArquivoAdimplencia.Enabled = true;
                        btnarquivoRetornoAd.Enabled = false;
                    }
                    if (etapa == "A-AGUARDANDO ACEITACAO ARQ")
                    {
                        btnArquivoAdimplencia.Enabled = false;
                        btnarquivoRetornoAd.Enabled = true;
                    }

                    pnlAdimplente.Enabled = true;
                    pnlInadimplente.Enabled = false;
                }
            }


        }

        private void listaRemessa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loading load  = new loading();
            chkErro.Checked = false;
            Buscasequencia();
            string id_remessa = listaRemessa.SelectedValue.ToString();
            string tipo = "";
            string etapa = "";
            txtQuantidadeRemessa.Text = "";
            txtRemessa.Text = "";
            txtcontrole.Text = "";
            txtnome.Text = "";
            btnListaNegra.Enabled = false;
            if (id_remessa != "System.Data.DataRowView")
            {
                txtRemessa.Text = id_remessa.ToString();

                DataSet ds = getDadosListaRemessa(Convert.ToInt32(id_remessa), 1);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    tipo = ds.Tables[0].Rows[0]["Etapa"].ToString().Substring(0, 1);
                    etapa = ds.Tables[0].Rows[0]["Etapa"].ToString();
                    dg_Filtrados.DataSource = ds.Tables[0];
                    txtQuantidadeRemessa.Text = ds.Tables[0].Rows.Count.ToString();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        chkErro.Visible = true;
                    }
                    else
                    {
                        chkErro.Visible = false;
                    }

                    if (tipo == "I")
                    {
                        if (etapa == "I-AGUARD. GERAR ARQUIVO")
                        {
                            btnArquivo.Enabled = true;
                            btnretornoInad.Enabled = false;
                            btnRetirar.Visible = true;
                        }
                        if (etapa == "I-AGUARDANDO ACEITACAO ARQ")
                        {
                            btnArquivo.Enabled = false;
                            btnretornoInad.Enabled = true;
                            btnRetirar.Visible = false;
                        }
                        pnlAdimplente.Enabled = false;
                        pnlInadimplente.Enabled = true;
                        if (etapa == "I-ACEITO" || etapa == "INADIMPLÊNCIA RETIRADA")
                        {
                            pnlAdimplente.Enabled = false;
                            pnlInadimplente.Enabled = false;
                            btnRetirar.Visible = false;
                        }

                    }
                    else
                    {

                        if (etapa == "A-AGUARD. GERAR ARQUIVO")
                        {
                            btnArquivoAdimplencia.Enabled = true;
                            btnarquivoRetornoAd.Enabled = false;

                        }
                        else if (etapa == "A-AGUARDANDO ACEITACAO ARQ")
                        {
                            btnArquivoAdimplencia.Enabled = false;
                            btnarquivoRetornoAd.Enabled = true;
                            btnRetirar.Visible = false;
                        }


                        pnlAdimplente.Enabled = true;
                        pnlInadimplente.Enabled = false;
                        if (etapa == "A-ACEITO" || etapa == "INADIMPLÊNCIA RETIRADA")
                        {
                            pnlAdimplente.Enabled = false;
                            pnlInadimplente.Enabled = false;
                            btnRetirar.Visible = false;
                        }
                    }

                }
                else
                {
                    dg_Filtrados.DataSource = null;
                    MessageBox.Show("NÃO HÁ DADOS");
                    btnRetirar.Visible = false;

                }




            }

            pnlAdimplente.Enabled = true;
        }
        public void AtualizaGrid(string id_remessa)
        {
            if (id_remessa != "" && id_remessa != null)
            {
                string tipo = "";
                string etapa = "";
                txtRemessa.Text = id_remessa.ToString();
                DataSet ds = getDadosListaRemessa(Convert.ToInt32(id_remessa), 1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tipo = ds.Tables[0].Rows[0]["Etapa"].ToString().Substring(0, 1);
                    etapa = ds.Tables[0].Rows[0]["Etapa"].ToString();
                    dg_Filtrados.DataSource = ds.Tables[0];
                    txtQuantidadeRemessa.Text = ds.Tables[0].Rows.Count.ToString();
                    if (tipo == "I")
                    {
                        if (etapa == "I-AGUARD. GERAR ARQUIVO")
                        {
                            btnArquivo.Enabled = true;
                            btnretornoInad.Enabled = false;
                        }
                        if (etapa == "I-AGUARDANDO ACEITACAO ARQ")
                        {
                            btnArquivo.Enabled = false;
                            btnretornoInad.Enabled = true;
                        }
                        pnlAdimplente.Enabled = false;
                        pnlInadimplente.Enabled = true;
                        if (etapa == "I-ACEITO")
                        {
                            pnlAdimplente.Enabled = false;
                            pnlInadimplente.Enabled = false;
                        }

                    }
                    else
                    {

                        if (etapa == "A-AGUARD. GERAR ARQUIVO")
                        {
                            btnArquivoAdimplencia.Enabled = true;
                            btnarquivoRetornoAd.Enabled = false;
                        }
                        if (etapa == "A-AGUARDANDO ACEITACAO ARQ")
                        {
                            btnArquivoAdimplencia.Enabled = false;
                            btnarquivoRetornoAd.Enabled = true;
                        }

                        pnlAdimplente.Enabled = true;
                        pnlInadimplente.Enabled = false;
                        if (etapa == "A-ACEITO")
                        {
                            pnlAdimplente.Enabled = false;
                            pnlInadimplente.Enabled = false;
                        }

                    }

                }
                else
                {
                    dg_Filtrados.DataSource = null;
                    btnRetirar.Visible = false;
                    MessageBox.Show("NÃO HÁ DADOS");

                }

            }

        }
        private void btnArquivoAdimplencia_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Você validou a sequência de 6 caracteres a ser utilizada no arquivo?" + Environment.NewLine +
               "Deseja realmente gerar arquivo remessa ? "
               , "Atenção", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                DataSet dsRegistro = new DataSet();

                //PreencheDados();
                int sequencia = 0;

                string id_remessa = txtRemessa.Text;
                if (id_remessa != "Remessa" && id_remessa != "")
                {
                    //CriaLoteSerasa();
                    //dsRegistro = getRangeSerasa(id_remessa);
                    string nomeArquivo = "Exclusao";
                    //dsRegistro.Tables[0].Rows[0]["ds_remessa"].ToString();
                    id_remessa = id_remessa.ToString();
                        //dsRegistro.Tables[0].Rows[0]["id_remessa"].ToString();
                    Stream arquivo = File.OpenWrite(@"C:\\TEMP\" + "EXCLUSAO-" + nomeArquivo.ToString() + ".txt"); // @"C:\Temp\Mahesh.txt";
                    StreamWriter gravaLinha = new StreamWriter(arquivo);

                    var header = new StringBuilder();

                    #region HEADER

                    //Codigo Registro Posicao 1 
                    header.Append("0");
                    // Console.WriteLine(header.Length);
                    //Número do informante Posicao 2 á 9
                    header.Append("004401579");
                    // Console.WriteLine(header.Length);
                    //Data da movimentação AAAAMMDD Posicao 2 á 9
                    header.Append(Utils.FitStringLength(DateTime.Now.ToString("yyyyMMdd"), 11, 8, ' ', 0, true, true, false));
                    //  Console.WriteLine(header.Length);
                    //Número do DDD do telefone  da Instituiçaõ
                    header.Append(Utils.FitStringLength("0011", 19, 4, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Número do telefone de contato da Instituição
                    header.Append(Utils.FitStringLength("56453377", 23, 8, ' ', 0, true, true, false));
                    //Console.WriteLine(header.Length);

                    //Número do ramal de contato da Instituiçaõ
                    header.Append(Utils.FitStringLength("3377", 31, 4, ' ', ' ', true, true, false));
                    ///Console.WriteLine(header.Length);
                    //Nome do contato da Instituição
                    header.Append(Utils.FitStringLength("CARSYSTEM ALARMES LTDA", 35, 70, ' ', ' ', true, true, false));
                    ///Console.WriteLine(header.Length);
                    //Identificação do arquivo
                    header.Append(Utils.FitStringLength("SERASA-CONVEM04", 105, 15, ' ', 0, true, true, false));
                    //Console.WriteLine(header.Length);
                    //Número de remessa
                    header.Append(Utils.FitStringLength(txtsequencia.Text, 120, 6, '0', 0, true, true, true));
                    //Console.WriteLine(header.Length);
                    //Código de Envio de arquivo
                    header.Append(Utils.FitStringLength("E", 126, 1, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Diferencial remessa
                    header.Append(Utils.FitStringLength("", 127, 4, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Deixar em branco
                    header.Append(Utils.FitStringLength(" ", 131, 3, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Informar o LOGON a ser utilizado
                    header.Append(Utils.FitStringLength(" ", 134, 8, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Deixar em branco
                    header.Append(Utils.FitStringLength(" ", 142, 392, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Deixar em branco
                    header.Append(Utils.FitStringLength(" ", 534, 60, ' ', ' ', true, true, false));
                    //Console.WriteLine(header.Length);
                    //Sequencia de Codigo
                    header.Append(Utils.FitStringLength("0000001", 594, 7, ' ', ' ', true, true, false));
                    int tamanho = header.Length;
                    MessageBox.Show(tamanho.ToString());
                    var headerFormatado = Utils.SubstituiCaracteresEspeciais(header.ToString());


                    gravaLinha.WriteLine(headerFormatado);


                    int id_controlealteracao = 0;
                    #endregion

                    #region Detalhe

                    //Codigo Registro Posicao 1 



                    DataSet ds = getBoletos(id_remessa,3);

                    ///sageBox.Show("Quantidade de Boletos a ser processado : " + ds.Tables.Count.ToString() + " !!!");
                    ///sageBox.Show("Quantidade de Boletos a ser processado : " + ds.Tables.Count.ToString() + " !!!");
                    sequencia = 2;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var detalhe = new StringBuilder();
                        id_controlealteracao = Convert.ToInt32(dr["id_controleAlter"].ToString());
                        //Código do registro (1) 
                        detalhe.Append("1");
                        ////MessageBox.Show("01 DE " + detalhe.Length.ToString());
                        //Código de operação Posicao 2
                        detalhe.Append("E");
                        ////MessageBox.Show("02 DE " + detalhe.Length.ToString());
                        //Filial e Digito do CNPJ  Posicao 3 ?
                        detalhe.Append("000155");
                        // //MessageBox.Show("08 DE " + detalhe.Length.ToString());
                        //Data da Ocorrencia
                        DateTime dt_vencimento = Convert.ToDateTime(dr["dataVencimento"].ToString());
                        detalhe.Append(Utils.FitStringLength(dt_vencimento.ToString("yyyyMMdd"), 9, 8, ' ', 0, true, true, false));
                        //MessageBox.Show("9 A 16 " + detalhe.Length.ToString());
                        DateTime dt_validade = Convert.ToDateTime(dr["dt_validade"].ToString());
                        //Data do termino do contrato
                        detalhe.Append(Utils.FitStringLength(dt_validade.ToString("yyyyMMdd"), 17, 8, ' ', 0, true, true, false));
                        //MessageBox.Show("17 A 24 " + detalhe.Length.ToString());
                        //Código Natureza da operação
                        detalhe.Append(Utils.FitStringLength("VM", 25, 3, ' ', ' ', true, true, false));
                        //MessageBox.Show("25 A 27 " + detalhe.Length.ToString());
                        //Código da praça Embratel
                        detalhe.Append(Utils.FitStringLength("0011", 28, 4, ' ', ' ', true, true, false));
                        //MessageBox.Show("28 A 31 " + detalhe.Length.ToString());
                        //Tipo de Pessoa (F OU J)
                        detalhe.Append(Utils.FitStringLength(dr["tipoPessoa"].ToString(), 32, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("32 A 32 " + detalhe.Length.ToString());
                        //Tipo do primeiro DOC (CNPJ e CPF)
                        detalhe.Append(Utils.FitStringLength(dr["tipoDoc"].ToString(), 33, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("33 A 33 " + detalhe.Length.ToString());
                        //Primeiro documento Principal (CNPJ e CPF)
                        detalhe.Append(dr["numeroDocumento"].ToString());
                        //MessageBox.Show("34 A 48 " + detalhe.Length.ToString());
                        //Motivo da Baixa ver
                        detalhe.Append(Utils.FitStringLength("", 49, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("49 A 49 " + detalhe.Length.ToString());
                        //Tipo do segundo  documento
                        detalhe.Append(Utils.FitStringLength("", 51, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("51 A 51 " + detalhe.Length.ToString());
                        //Tipo do segundo
                        detalhe.Append(Utils.FitStringLength("", 52, 15, ' ', ' ', true, true, false));
                        //MessageBox.Show("52 A 66 " + detalhe.Length.ToString());
                        //UF Quando DOC for RG
                        detalhe.Append(Utils.FitStringLength("", 67, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("67 A 68 " + detalhe.Length.ToString());
                        //Tipo de pessoa do coobrigado
                        //detalhe.Append(Utils.FitStringLength(dr["tipoPessoa"].ToString(), 69, 1, ' ', ' ', true, true, false));
                        detalhe.Append(Utils.FitStringLength("", 69, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("69 A 69 " + detalhe.Length.ToString());
                        //Tipo do primeiro Documento
                        //detalhe.Append(Utils.FitStringLength(dr["tipoDoc"].ToString(), 70, 1, ' ', ' ', true, true, false));
                        detalhe.Append(Utils.FitStringLength("", 70, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("70 A 70 " + detalhe.Length.ToString());
                        //Primeiro Doc do coobrigado
                        //detalhe.Append(Utils.FitStringLength(dr["numeroDocumento"].ToString(), 71, 15, '0', 0, true, true, true));
                        detalhe.Append(Utils.FitStringLength("", 71, 15, ' ', ' ', true, true, false));
                        //MessageBox.Show("71 A 85 " + detalhe.Length.ToString());
                        //Espaços
                        detalhe.Append(Utils.FitStringLength("", 86, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("86 A 87 " + detalhe.Length.ToString());
                        //Espaços
                        detalhe.Append(Utils.FitStringLength("", 88, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("88 A 88 " + detalhe.Length.ToString());
                        //Espaços
                        detalhe.Append(Utils.FitStringLength("", 89, 15, ' ', ' ', true, true, false));
                        //MessageBox.Show("89 A 103 " + detalhe.Length.ToString());
                        //Unidade Federal
                        detalhe.Append(Utils.FitStringLength("", 104, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("104 A 105 " + detalhe.Length.ToString());
                        //Nome do Devedor
                        detalhe.Append(Utils.FitStringLength(dr["nomecliente"].ToString(), 106, 70, ' ', ' ', true, true, false));
                        //MessageBox.Show("106 A 175 " + detalhe.Length.ToString());
                        //Data de Nascimento
                        detalhe.Append(Utils.FitStringLength(dr["dt_nascimento"].ToString(), 176, 8, ' ', ' ', true, true, false));
                        //MessageBox.Show("176 A 183 " + detalhe.Length.ToString());
                        //Nome do Pai
                        detalhe.Append(Utils.FitStringLength("", 184, 70, ' ', ' ', true, true, false));
                        //MessageBox.Show("184 A 253 " + detalhe.Length.ToString());
                        //Nome do Mae
                        detalhe.Append(Utils.FitStringLength("", 254, 70, ' ', ' ', true, true, false));
                        //MessageBox.Show("254 A 253 " + detalhe.Length.ToString());
                        //Endereço completo
                        detalhe.Append(Utils.FitStringLength(dr["logradouro"].ToString(), 324, 45, ' ', ' ', true, true, false));
                        //MessageBox.Show("324 A 368 " + detalhe.Length.ToString());
                        //Bairro completo
                        detalhe.Append(Utils.FitStringLength(dr["bairro"].ToString(), 369, 20, ' ', ' ', true, true, false));
                        //MessageBox.Show("369 A 388 " + detalhe.Length.ToString());
                        //Municipio completo
                        detalhe.Append(Utils.FitStringLength(dr["Cidade"].ToString(), 389, 25, ' ', ' ', true, true, false));
                        //MessageBox.Show("389 A 413 " + detalhe.Length.ToString());
                        //Sigla Unidade Federativa
                        detalhe.Append(Utils.FitStringLength(dr["Uf"].ToString(), 414, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("414 A 415 " + detalhe.Length.ToString());
                        //Código Enderecamento
                        detalhe.Append(Utils.FitStringLength(dr["Cep"].ToString(), 416, 8, ' ', ' ', true, true, false));
                        //MessageBox.Show("416 A 423 " + detalhe.Length.ToString());
                        //Valor 
                        double valor = Convert.ToDouble(dr["valor"].ToString().Replace(",", ""));
                        detalhe.Append(Utils.FitStringLength(valor.ToString(), 424, 15, '0', 0, true, true, true));
                        //MessageBox.Show("424 A 438 " + detalhe.Length.ToString());
                        //Número do contrato 
                        detalhe.Append(Utils.FitStringLength(dr["numero"].ToString(), 439, 16, ' ', ' ', true, true, false));
                        //MessageBox.Show("439 A 454 " + detalhe.Length.ToString());
                        //Nosso número
                        detalhe.Append(Utils.FitStringLength(dr["numero"].ToString(), 455, 9, ' ', ' ', true, true, false));
                        //MessageBox.Show("455 A 463 " + detalhe.Length.ToString());
                        //Complemento do endereço
                        detalhe.Append(Utils.FitStringLength(dr["Complemento"].ToString(), 464, 25, ' ', ' ', true, true, false));
                        //MessageBox.Show("464 A 488 " + detalhe.Length.ToString());
                        //DDD do telefone
                        detalhe.Append(Utils.FitStringLength("0011", 489, 4, ' ', ' ', true, true, false));
                        //MessageBox.Show("489 A 492 " + detalhe.Length.ToString());
                        //Telefone 
                        detalhe.Append(Utils.FitStringLength(dr["nr_celular"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Substring(2, dr["nr_celular"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Length - 2), 493, 9, ' ', ' ', true, true, false));
                        //MessageBox.Show("493 A 501 " + detalhe.Length.ToString());
                        //Data do compromisso

                        detalhe.Append(Utils.FitStringLength(dt_vencimento.ToString("yyyyMMdd"), 502, 8, ' ', ' ', true, true, false));
                        //MessageBox.Show("502 A 509 " + detalhe.Length.ToString());
                        //Valor do compromisso  
                        detalhe.Append(Utils.FitStringLength(valor.ToString(), 510, 15, '0', 0, true, true, true));
                        //MessageBox.Show("510 A 524 " + detalhe.Length.ToString());
                        //Indicativo de envio
                        detalhe.Append(Utils.FitStringLength("", 525, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("525 A 525 " + detalhe.Length.ToString());
                        //Deixar em Branco
                        detalhe.Append(Utils.FitStringLength("", 526, 5, ' ', ' ', true, true, false));
                        //MessageBox.Show("526 A 530 " + detalhe.Length.ToString());
                        //Indicativo de tipo de Comunicado
                        detalhe.Append(Utils.FitStringLength("", 531, 1, ' ', ' ', true, true, false));
                        //MessageBox.Show("531 A 531 " + detalhe.Length.ToString());
                        //Deixar em Branco
                        detalhe.Append(Utils.FitStringLength("", 532, 2, ' ', ' ', true, true, false));
                        //MessageBox.Show("532 A 533 " + detalhe.Length.ToString());
                        //Deixar em Branco
                        detalhe.Append(Utils.FitStringLength("", 534, 60, ' ', ' ', true, true, false));
                        //MessageBox.Show("534 A 593 " + detalhe.Length.ToString());
                        //sequencia 
                        detalhe.Append(Utils.FitStringLength(sequencia.ToString(), 594, 7, '0', 0, true, true, true));
                        //MessageBox.Show("594 A 600 " + detalhe.Length.ToString());
                        var detalheFormatado = Utils.SubstituiCaracteresEspeciais(detalhe.ToString());
                        tamanho = detalhe.Length;
                        // MessageBox.Show(tamanho.ToString());
                        gravaLinha.WriteLine(detalheFormatado);
                        setAlteraParcela(id_controlealteracao, 7, Convert.ToInt32(id_remessa), "", 1);
                        sequencia = sequencia + 1;

                    }

                    #endregion
                    #region Trailler
                    var trailer = new StringBuilder();
                    trailer.Append("9");
                    trailer.Append(Utils.FitStringLength("", 2, 592, ' ', ' ', true, true, false));
                    trailer.Append(Utils.FitStringLength(sequencia.ToString(), 594, 7, '0', 0, true, true, true));
                    var trailerFormatado = Utils.SubstituiCaracteresEspeciais(trailer.ToString());
                    gravaLinha.WriteLine(trailerFormatado);
                    MessageBox.Show("Arquivo gerado com sucesso...");
                    gravaLinha.Close();
                    AtualizaGrid(id_remessa);
                    #endregion
                }
                else
                {
                    MessageBox.Show("SELECIONE UMA REMESSA ANTES DE TENTAR GERAR ARQUIVO");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("OPERAÇÃO CANCELADA...");
            }
        }
        public string ExtrairValorDaLinha(string conteudoLinha, int de, int ate)
        {
            int inicio = de - 1;
            return conteudoLinha.Substring(inicio, ate - inicio);
        }
        private void btnarquivoRetornoAd_Click(object sender, EventArgs e)
        {
            string id_remessa = txtRemessa.Text;
            if (id_remessa != "Remessa" && id_remessa != "")
            {
                String linhaAtual;
                ofd1.Title = "Selecione um arquivo de retorno";
                ofd1.Filter = "Arquivos de Retorno (*.ret;*.crt;*.txt)|*.ret;*.crt*.txt|Todos Arquivos (*.*)|*.*";

                if (ofd1.ShowDialog() == DialogResult.OK)
                {
                    if (ofd1.CheckFileExists == true)
                    {
                        // Le os arquivos selecionados 
                        foreach (String arquivo in ofd1.FileNames)
                        {

                            //; ; txtArquivo.Text += arquivo;
                            // cria um PictureBox
                            try
                            {
                                using (StreamReader sr = new StreamReader(ofd1.OpenFile()))
                                {
                                    while ((linhaAtual = sr.ReadLine()) != null)
                                    {
                                        if (ExtrairValorDaLinha(linhaAtual, 1, 1) == "1")
                                        {
                                            //Console.WriteLine(linhaAtual);
                                            //MessageBox.Show(linhaAtual.Substring(533, 3));
                                            //MessageBox.Show(linhaAtual.Substring(438, 15));
                                            //MessageBox.Show(linhaAtual);
                                            if (linhaAtual.Substring(533, 3) != "   ")
                                            {
                                                setAlteraParcela(Convert.ToInt32(linhaAtual.Substring(438, 15)), 11, Convert.ToInt32(id_remessa), linhaAtual.Substring(438, 15), 2);
                                                AtualizaGrid(id_remessa);
                                            }
                                            else
                                            {
                                                setAlteraParcela(Convert.ToInt32(linhaAtual.Substring(438, 15)), 10, Convert.ToInt32(id_remessa), "0", 2);
                                                AtualizaGrid(id_remessa);
                                            }
                                        }
                                        //var lines = File.ReadAllLines(@"C:\\TEMP\Retornoexemplo.TXT");
                                        //foreach (var line in lines)

                                    }

                                }
                            }
                            catch (SecurityException ex)
                            {
                                // O usuário  não possui permissão para ler arquivos
                                MessageBox.Show("Erro de segurança Contate o administrador de segurança da rede.\n\n" +
                                                            "Mensagem : " + ex.Message + "\n\n" +
                                                            "Detalhes (enviar ao suporte):\n\n" + ex.StackTrace);
                            }

                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("SELECIONE UMA REMESSA ANTES DE TENTAR GERAR ARQUIVO");
            }
        }

        private void listaRemessa_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.
            Brush myBrush = Brushes.Black;

            // Determine the color of the brush to draw each item based  
            // on the index of the item to draw. 
            switch (e.Index)
            {
                case 0:
                    myBrush = Brushes.Red;
                    break;
                case 1:
                    myBrush = Brushes.Orange;
                    break;
                case 2:
                    myBrush = Brushes.Purple;
                    break;
            }

            // Draw the current item text based on the current Font  
            // and the custom brush settings.
            e.Graphics.DrawString(listaRemessa.Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void btnretornoInad_Click(object sender, EventArgs e)
        {
            string id_remessa = txtRemessa.Text;
            if (id_remessa != "Remessa" && id_remessa != "")
            {
                String linhaAtual;
                ofd1.Title = "Selecione um arquivo de retorno";
                ofd1.Filter = "Arquivos de Retorno (*.ret;*.crt;*.txt)|*.ret;*.crt*.txt|Todos Arquivos (*.*)|*.*";

                if (ofd1.ShowDialog() == DialogResult.OK)
                {
                    if (ofd1.CheckFileExists == true)
                    {
                        // Le os arquivos selecionados 
                        foreach (String arquivo in ofd1.FileNames)
                        {

                            //; ; txtArquivo.Text += arquivo;
                            // cria um PictureBox
                            try
                            {
                                using (StreamReader sr = new StreamReader(ofd1.OpenFile()))
                                {
                                    while ((linhaAtual = sr.ReadLine()) != null)
                                    {
                                        if (ExtrairValorDaLinha(linhaAtual, 1, 1) == "1")
                                        {
                                            Console.WriteLine(linhaAtual);
                                            //MessageBox.Show(linhaAtual.Substring(533, 3));
                                            //MessageBox.Show(linhaAtual.Substring(438, 15));
                                            //MessageBox.Show(linhaAtual);
                                            if (linhaAtual.Substring(533, 3) != "   ")
                                            {
                                                setAlteraParcela(Convert.ToInt32(linhaAtual.Substring(438, 15)), 12, Convert.ToInt32(id_remessa), linhaAtual.Substring(533, 3).Trim(), 1);
                                                AtualizaGrid(id_remessa);
                                            }
                                            else
                                            {
                                                setAlteraParcela(Convert.ToInt32(linhaAtual.Substring(438, 15)), 3, Convert.ToInt32(id_remessa), "0", 1);
                                                AtualizaGrid(id_remessa);
                                            }
                                        }
                                        //var lines = File.ReadAllLines(@"C:\\TEMP\Retornoexemplo.TXT");
                                        //foreach (var line in lines)

                                    }

                                }
                            }
                            catch (SecurityException ex)
                            {
                                // O usuário  não possui permissão para ler arquivos
                                MessageBox.Show("Erro de segurança Contate o administrador de segurança da rede.\n\n" +
                                                            "Mensagem : " + ex.Message + "\n\n" +
                                                            "Detalhes (enviar ao suporte):\n\n" + ex.StackTrace);
                            }

                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("SELECIONE UMA REMESSA ANTES DE TENTAR GERAR ARQUIVO");
            }
        }

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            string nr_consulta = textFiltro.Text;
            string tipo = "";
            string etapa = "";
            if (nr_consulta != "System.Data.DataRowView")
            {

                DataSet ds = getDadosListaRemessa(nr_consulta);
                tipo = ds.Tables[0].Rows[0]["Etapa"].ToString().Substring(0, 1);
                etapa = ds.Tables[0].Rows[0]["Etapa"].ToString();
                tipo = ds.Tables[0].Rows[0]["Etapa"].ToString().Substring(0, 1);
                etapa = ds.Tables[0].Rows[0]["Etapa"].ToString();
                dg_Filtrados.DataSource = ds.Tables[0];
                txtQuantidadeRemessa.Text = ds.Tables[0].Rows.Count.ToString();
                if (tipo == "I")
                {
                    if (etapa == "I-AGUARD. GERAR ARQUIVO")
                    {
                        btnArquivo.Enabled = true;
                        btnretornoInad.Enabled = false;
                    }
                    if (etapa == "I-AGUARDANDO ACEITACAO ARQ")
                    {
                        btnArquivo.Enabled = false;
                        btnretornoInad.Enabled = true;
                    }
                    pnlAdimplente.Enabled = false;
                    pnlInadimplente.Enabled = true;
                    if (etapa == "I-ACEITO")
                    {
                        pnlAdimplente.Enabled = false;
                        pnlInadimplente.Enabled = false;
                    }

                }
                else
                {

                    if (etapa == "A-AGUARD. GERAR ARQUIVO")
                    {
                        btnArquivoAdimplencia.Enabled = true;
                        btnarquivoRetornoAd.Enabled = false;
                    }
                    if (etapa == "A-AGUARDANDO ACEITACAO ARQ")
                    {
                        btnArquivoAdimplencia.Enabled = false;
                        btnarquivoRetornoAd.Enabled = true;
                    }

                    pnlAdimplente.Enabled = true;
                    pnlInadimplente.Enabled = false;
                    if (etapa == "A-ACEITO")
                    {
                        pnlAdimplente.Enabled = false;
                        pnlInadimplente.Enabled = false;
                    }
                }
            }
        }


        private void dg_Filtrados_Click(object sender, EventArgs e)
        {

            if (dg_Filtrados.SelectedRows.Count != 0)
            {
                string tipo = dg_Filtrados.SelectedRows[0].Cells[6].Value.ToString();


                txtcontrole.Text = dg_Filtrados.SelectedRows[0].Cells[0].Value.ToString();
                txtnome.Text = dg_Filtrados.SelectedRows[0].Cells[3].Value.ToString();
                if (tipo == "I-AGUARD. GERAR ARQUIVO" || tipo == "A-AGUARD. GERAR ARQUIVO")
                {
                    grupoAcoes.Enabled = true;
                    btnListaNegra.Enabled = true;
                }
                else
                {
                    grupoAcoes.Enabled = false;
                    btnListaNegra.Enabled = false;
                }

            }
        }

        private void btnListaNegra_Click(object sender, EventArgs e)
        {

            if (txtcontrole.Text == "0" && chkInseriManual.Checked == true)
            {

                setListaNegra(txtnome.Text);
                MessageBox.Show("CNPJ/CPF inserindo com sucesso!!!");
                txtnome.Text = "";
                lblnome.Text = "Nome";


            }
            else
            {
                if (txtcontrole.Text != "" && txtRemessa.Text != "")
                {
                    setAlteraParcela(Convert.ToInt32(txtcontrole.Text), 13, Convert.ToInt32(txtRemessa.Text), "", 1);
                    AtualizaGrid(txtRemessa.Text);
                }
                else
                {
                    MessageBox.Show("Informe um cliente");
                }
            }



        }



        private void chkInseriManual_Click(object sender, EventArgs e)
        {
            if (chkInseriManual.Checked == true)
            {
                txtcontrole.Text = "0";
                txtnome.Enabled = true;
                grupoAcoes.Enabled = true;
                btnListaNegra.Enabled = true;
                lblnome.Text = "Informe o CPF/CNPJ";
                txtnome.Text = "";


            }
            else
            {
                txtcontrole.Text = "";
                txtnome.Enabled = false;
                btnListaNegra.Enabled = true;
                txtnome.Text = "";
                lblnome.Text = "";
            }
        }

        private void chkErro_CheckedChanged(object sender, EventArgs e)
        {
            if (chkErro.Checked == true)
            {
                ListaComErros(txtRemessa.Text);

            }
            else
            {
                AtualizaGrid(txtRemessa.Text);
            }
        }
        public void ListaComErros(string id_remessa)
        {
            if (id_remessa != "" && id_remessa != null)
            {
                string tipo = "";
                string etapa = "";
                txtRemessa.Text = id_remessa.ToString();
                DataSet ds = getDadosListaRemessa(Convert.ToInt32(id_remessa), 2);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tipo = ds.Tables[0].Rows[0]["Etapa"].ToString().Substring(0, 1);
                    etapa = ds.Tables[0].Rows[0]["Etapa"].ToString();
                    dg_Filtrados.DataSource = ds.Tables[0];
                    txtQuantidadeRemessa.Text = ds.Tables[0].Rows.Count.ToString();
                    btnRetirar.Visible = true;
                    if (tipo == "I")
                    {
                        if (etapa == "I-AGUARD. GERAR ARQUIVO")
                        {
                            btnArquivo.Enabled = true;
                            btnretornoInad.Enabled = false;
                        }
                        if (etapa == "I-AGUARDANDO ACEITACAO ARQ")
                        {
                            btnArquivo.Enabled = false;
                            btnretornoInad.Enabled = true;
                        }
                        pnlAdimplente.Enabled = false;
                        pnlInadimplente.Enabled = true;
                        if (etapa == "I-ACEITO")
                        {
                            pnlAdimplente.Enabled = false;
                            pnlInadimplente.Enabled = false;
                        }

                    }
                    else
                    {

                        if (etapa == "A-AGUARD. GERAR ARQUIVO")
                        {
                            btnArquivoAdimplencia.Enabled = true;
                            btnarquivoRetornoAd.Enabled = false;
                        }
                        if (etapa == "A-AGUARDANDO ACEITACAO ARQ")
                        {
                            btnArquivoAdimplencia.Enabled = false;
                            btnarquivoRetornoAd.Enabled = true;
                        }

                        pnlAdimplente.Enabled = true;
                        pnlInadimplente.Enabled = false;
                        if (etapa == "A-ACEITO")
                        {
                            pnlAdimplente.Enabled = false;
                            pnlInadimplente.Enabled = false;
                        }

                    }
                }
                else
                {
                    dg_Filtrados.DataSource = null;
                    btnRetirar.Visible = false;
                    MessageBox.Show("NÃO HÁ DADOS");
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sequencia = txtsequencia.Text;
            if (sequencia.Length == 6)
            {
                setSequencia(sequencia);
                getSequencia();
                MessageBox.Show("A SEQUÊNCIA ATUALIZADA COM SUCESSO.");

            }
            else
            {
                MessageBox.Show("A SEQUÊNCIA DEVERA CONTER 6 CARACTERES NUMERICOS.");
            }

        }
        private void setRetiraContrato(string id_controle)
        {

            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "Principal.[Negativacao].[pro_setRetiraCliente]";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;
            dados.Comandos.adicionaParametro("@id_controle", SqlDbType.VarChar, 15, id_controle);
            dados.Comandos.adicionaParametro("@usuario", SqlDbType.VarChar, 80, Environment.UserName);
            dados.retornaDados = false;
            dados.execute();


        }
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            if (txtcontrole.Text != "")
            {
                setRetiraContrato(txtcontrole.Text);

                AtualizaGrid(txtRemessa.Text);
            }
            else
            {
                MessageBox.Show("SELECIONE UM CPF/CNPJ.");

            }
        }
    }
}