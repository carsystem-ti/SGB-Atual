using BoletoNet;
using BoletoNet.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGB
{
    public partial class Remessa : Form
    {
		Banco_Daycoval banco = new Banco_Daycoval();
		Cedente c = new Cedente();
		private IBanco _banco;
		CarSystem.BancoDados.Dados _dados;
	//	private string _arquivo = null;
		//private int _id_retorno = 0;
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
		public Remessa()
        {
            InitializeComponent();
        }
		private void buscadados()
        {
			string fileName = @"C:\Temp\Mahesh.txt";
			StreamWriter writer = new StreamWriter(fileName);

			//GeraArquivoCNAB400Itau(writer);
		}
		private DataSet getBoletos()
		{
			DataSet ds = new DataSet();
			dados.Comandos.limpaParametros();
			dados.Comandos.textoComando = "Principal.[webApi].[pro_getCR]";
			dados.Comandos.tipoComando = CommandType.StoredProcedure;
			dados.Comandos.adicionaParametro("@tipo", SqlDbType.VarChar, 12, 4);
			dados.retornaDados = true;
			ds  = dados.execute();

			return ds;
		}
		private void btnGerar_Click(object sender, EventArgs e)
        {
            c.Codigo = "050121";
            c.Convenio = 1906905012100;
            c.Nome = "CARSYSTEM ALARMES LTDA";
			
			
			//GeraArquivoCNAB400();
			Boleto boleto = new Boleto();
			GerarHeaderRemessaCNABNew(190605012100);
	

			//Dados da Empresa
			//int tamanhoRegistro = 400;

			//StreamWriter arquivoRemessa = new StreamWriter(stream, Encoding.GetEncoding("ISO-8859-1"));
			//string strline = string.Empty;
			/////StringBuilder header = new StringBuilder();
			//string diretorio = @"Z:\arquivo\" + @"\" + "Day";

			//CarSystem.Utilidades.IO.Arquivo.isExisteDir(diretorio, true);
			//string arquivo = diretorio + @"\Arquivo_" + DateTime.Today.ToString("ddMMyyyy") + "_" + "Carsystem" + "_" + "Safra" + ".log";


			//arquivoRemessa.WriteLine(header);




			//CarSystem.Utilidades.IO.Arquivo.stringTOtxt(arquivo, header);
			//CarSystem.Utilidades.IO.Arquivo.stringTOtxt(arquivo, header);
			//StreamWriter sw = new StreamWriter("C:\\TEMP\Test.txt");
			//Write a line of text
			//sw.WriteLine("Hello World!!");
			//Write a second line of text
			//sw.WriteLine("From the StreamWriter class");
			//Close the file
			//sw.Close();
			//	var detalhe = GerarHeaderRemessaCNAB400("teste");
			//var detalhe = GerarDetalheRemessaCNAB400("teste");

		}
		private void GerarHeaderRemessaCNABNew(long convenio)
		{
			int contador = 0;
			int nr_registro = 0;
			int sequencia = 0;

			Boleto boleto = new Boleto();
			string nomeArquivo = "7GY" + DateTime.Now.ToString("ddMM").ToString() + "1.txt";
			Stream arquivo = File.OpenWrite(@"C:\\TEMP\" + nomeArquivo.ToString()); // @"C:\Temp\Mahesh.txt";
			StreamWriter gravaLinha = new StreamWriter(arquivo);
		
			var header = new StringBuilder();

			//Codigo Registro Posicao 1
			header.Append("0"); // Identificação do registro header, sempre 0
			
			//Codigo Remessa Posicao 2
			header.Append("1"); // Código da remessa, sempre 1
			
			//Remessa Posicao 3 á 9
			header.Append("REMESSA"); // Literal de remessa
			
			//Código de serviço Posicao 10 á 11
			header.Append("01"); // Código do serviço, sempre 01
			
			//Tipo  de serviço 12 á 26
			header.Append(Utils.FitStringLength("COBRANCA", 15, 15, ' ', 0, true, true, false));
			
			//Indentificação da empresa 27 á 46
			header.Append(Utils.FitStringLength(convenio.ToString(), 12, 12, ' ', 0, true, true, false));

			//Nome da empresa 47 á 76
			header.Append(Utils.FitStringLength(this.c.Nome, 30, 30, ' ', 0, true, true, false)); // Nome do cedente
			
			//Codigo do Banco 77 á 79
			header.Append("707"); // Código do banco
			
			//Nome do Banco 80 á 94
			header.Append(Utils.FitStringLength("BANCO DAYCOVAL", 15, 15, ' ', 0, true, true, false)); // Nome do banco
			
			//Data da Gravacao 95 á 100
			header.Append(DateTime.Now.ToString("ddMMyy")); // Data
			
			//Complemento do registro 101 á 394
			header.Append(Utils.FitStringLength(string.Empty, 294, 294, ' ', 0, true, true, false));
			
			//SEQUENCIAL DO REGISTRO 395 Á 400
			header.Append("000001"); // Sequencial, sempre 1

			var headerFormatado = Utils.SubstituiCaracteresEspeciais(header.ToString());

			gravaLinha.WriteLine(headerFormatado);

			DataSet ds = getBoletos();
			nr_registro = 84580106;
			///sageBox.Show("Quantidade de Boletos a ser processado : " + ds.Tables.Count.ToString() + " !!!");
			
			foreach (DataRow dr in ds.Tables[0].Rows)
            {
				sequencia = sequencia + 1;
				var detalhe = new StringBuilder();

			
				Cedente c = new Cedente();
				//c.CPFCNPJ = "04.401.579/0001-55";
				//c.Nome = "Carsystem Alarmes Ltda";
				//c.Carteira = "121";
				//c.ContaBancaria. = "748363-7";
				//c.Codigo = "7";
				// Identificação do tipo de inscrição da empresa
				// 01 - CPF do cedente
				// 02 - CNPJ do cedente
				// 03 - CPF do Sacador
				// 04 - CNPJ Sacador


				// Identificação do registro, sempre 1 Posição 01
				detalhe.Append("1");
				boleto.Cedente = c;
				// Identificação Sacador, sempre 1 Posição 02 á 03
				c.CPFCNPJ = "04401579000155";
				c.Convenio = convenio;
				detalhe.Append(c.CPFCNPJ.Length == 11 ? "01" : "02");
				
				
				// CPF/CNPJ da empresa ou sacador Posicao 04 á 17
				detalhe.Append(Utils.FitStringLength(c.CPFCNPJ, 14, 14, '0', 0, true, true, true));
				
				//Código da empresa da empresa Posicao 18 á 37
				boleto.Cedente.Convenio = convenio;
				detalhe.Append(Utils.FitStringLength(c.Convenio.ToString(), 20, 20, ' ', 0, true, true, false));

				// Número documento, fornecido pelo banco Posição 38 á 62
				boleto.NumeroDocumento = dr.ItemArray[1].ToString();
				detalhe.Append(Utils.FitStringLength(boleto.NumeroDocumento, 25, 25, ' ', 0, true, true, true));

				// Nosso Numero, fornecido pelo banco Posição 63 á 70
				boleto.NossoNumero = nr_registro.ToString();
				detalhe.Append(Utils.FitStringLength(boleto.NossoNumero, 8, 8, '0', 0, true, true, true)); // Nosso número
				
				//Brancos 71 á 83
				detalhe.Append(Utils.FitStringLength(string.Empty, 13, 13, ' ', 0, true, true, true));

				// Nosso número do correspondente, mesmo do boleto
				if (this._banco == null)
				{
					
					this._banco = new Banco(707);
					this._banco.Codigo = 707;
				}

				//this._banco.ValidaBoleto(boleto);
				//Brancos 84 á 107
				detalhe.Append(Utils.FitStringLength(string.Empty, 24, 24, ' ', 0, true, true, false)); // Uso do banco

				//Código de remessa 108 á 108
				detalhe.Append("6");
				
				//Código de ocorrência 109 á 110
				detalhe.Append("01");
				
				//Código de ocorrência 111 á 120
				detalhe.Append(Utils.FitStringLength(boleto.NumeroDocumento, 10, 10, ' ', 0, true, true, false)); // Seu número
				
				//Data Vencimento 121 á 126
				boleto.DataVencimento = Convert.ToDateTime(dr.ItemArray[3].ToString());
				detalhe.Append(boleto.DataVencimento.ToString("ddMMyy"));

				//Valor do titulo 127 á 139
				boleto.ValorBoleto = Convert.ToDecimal(dr.ItemArray[4].ToString());
				detalhe.Append(Utils.FitStringLength(boleto.ValorBoleto.ApenasNumeros(), 13, 13, '0', 0, true, true, true));

				//Código do Banco 140 á 142
				detalhe.Append("707"); // Código do banco
				
				//Código do Banco 143 á 146
				detalhe.Append(Utils.FitStringLength(string.Empty, 4, 4, '0', 0, true, true, true)); // Agência cobradora

				//Código do Banco 147 á 147
				detalhe.Append("0"); // DAC da agência cobradora
				
				//Especie 148 á 149
				detalhe.Append(Utils.FitStringLength("01", 2, 2, '0', 0, true, true, true));
				
				//Aceite 150 á 150
				detalhe.Append("N"); // Indicação de aceite do título, sempre N

				//Data documento 151 á 156
				boleto.DataDocumento = DateTime.Now;
				detalhe.Append(boleto.DataDocumento.ToString("ddMMyy"));

				//Data documento 157 á 160
				detalhe.Append(Utils.FitStringLength(string.Empty, 4, 4, '0', 0, true, true, true)); // Zeros
				
				//Juros 161 á 173																		 // detalhe.Append(Utils.FitStringLength(boleto.JurosMora.ApenasNumeros(), 13, 13, '0', 0, true, true, true));
				detalhe.Append(Utils.FitStringLength("0", 13, 13, '0', 0, true, true, true));

				//Data desconto 174 á 179	
				boleto.DataDesconto = Convert.ToDateTime(dr.ItemArray[3].ToString());
				detalhe.Append(boleto.DataDesconto == DateTime.MinValue ? "000000" : boleto.DataDesconto.ToString("ddMMyy"));

				//Valor Desconto 180 á 192
				boleto.ValorDesconto = 0;
				detalhe.Append(Utils.FitStringLength(boleto.ValorDesconto.ApenasNumeros(), 13, 13, '0', 0, true, true, true));

				//Valor de Abatimento 193 á 205
				boleto.ValorDesconto = 0;
				detalhe.Append(Utils.FitStringLength(boleto.ValorDesconto.ApenasNumeros(), 13, 13, '0', 0, true, true, true));



				//Uso em Branco 206 á 218
				boleto.ValorDesconto = 0;
				detalhe.Append(Utils.FitStringLength(boleto.ValorDesconto.ApenasNumeros(), 13, 13, '0', 0, true, true, true));
				
				//Codigo de Incricao 219 á 220
				detalhe.Append(dr.ItemArray[6].ToString().Length == 11 ? "01" : "02");

				//Numero de incricão 221 á 234
				detalhe.Append(Utils.FitStringLength(dr.ItemArray[6].ToString(), 14, 14, '0', 0, true, true, true));


				//Nome  do sacado 235 á 264
//				boleto.Sacado.Nome = dr.ItemArray[0].ToString();
				detalhe.Append(
					Utils.SubstituiCaracteresEspeciais(Utils.FitStringLength(dr.ItemArray[0].ToString(), 30, 30, ' ', 0, true, true, false)));
				
				//Complemento do Registro 265 á 274
				detalhe.Append(Utils.FitStringLength(string.Empty, 10, 10, ' ', 0, true, true, false));

				//Endereço completo 275 á 314
				//boleto.Sacado.Endereco.End= ;
				detalhe.Append(
					Utils.SubstituiCaracteresEspeciais(
						Utils.FitStringLength(dr.ItemArray[7].ToString(), 40, 40, ' ', 0, true, true, false)));


				//BAIRRO  315 á 326
				///boleto.Sacado.Endereco.Bairro = dr.ItemArray[8].ToString();
				detalhe.Append(
					Utils.SubstituiCaracteresEspeciais(
						Utils.FitStringLength(dr.ItemArray[8].ToString(), 12, 12, ' ', 0, true, true, false)));

				//CEP  327 á 334
				//boleto.Sacado.Endereco.CEP =  dr.ItemArray[10].ToString();
				detalhe.Append(Utils.FitStringLength(dr.ItemArray[10].ToString(), 8, 8, '0', 0, true, true, true));

				//cidade  335 á 349
				///boleto.Sacado.Endereco.Cidade = dr.ItemArray[11].ToString();
				detalhe.Append(
					Utils.SubstituiCaracteresEspeciais(
						Utils.FitStringLength(dr.ItemArray[11].ToString(), 15, 15, ' ', 0, true, true, false)));

				//UF  350 á 351
				///boleto.Sacado.Endereco.UF = dr.ItemArray[12].ToString();
				detalhe.Append(Utils.FitStringLength(dr.ItemArray[12].ToString(), 2, 2, ' ', 0, true, true, false));
				
				//AVALISTA 352 Á 381 
				if (boleto.Avalista != null)
				{
					//boleto.Avalista.Nome = dr.ItemArray[1].ToString();
					detalhe.Append(Utils.FitStringLength(dr.ItemArray[1].ToString(), 30, 30, ' ', 0, true, true, false));
				}
				else
				{
					detalhe.Append(Utils.FitStringLength(string.Empty, 30, 30, ' ', 0, true, true, false));
				}

				//BRANCOS 382 Á 385
				detalhe.Append(Utils.FitStringLength(string.Empty, 4, 4, ' ', 0, true, true, false)); // Brancos


				//BRANCOS 386 Á 391
				detalhe.Append(Utils.FitStringLength(string.Empty, 6, 6, ' ', 0, true, true, false)); // Brancos

				//DIAS 392 Á 393
				detalhe.Append("00"); // Dias para início do protesto
				
				//MOEDA 394 Á 394
				detalhe.Append(boleto.Moeda == 9 ? 0 : 2);
				
				//numero registro 394 Á 394
				detalhe.Append(Utils.FitStringLength(sequencia.ToString(), 6, 6, '0', 0, true, true, true));

				var detalheFormatado = detalhe.ToString();

				if (detalheFormatado.Length != 400)
				{
					throw new Exception("Tamanho do registro inválido.");
				}
				else
				{
					gravaLinha.WriteLine(detalheFormatado);

					var registro = new StringBuilder();

					//Identificacao Posicao 1 á 1 
					registro.Append("4");

					//Número da Nota Fiscal 2 á 16 
					registro.Append(Utils.FitStringLength("0", 15, 15, '0', 0, true, true, true));
					
					//Valor da Nota Fiscal 17 á 29 
					registro.Append(Utils.FitStringLength(boleto.ValorBoleto.ApenasNumeros(), 13, 13, '0', 0, true, true, true));

					//Data de Emissão da Nota 30 á 37 
					//registro.Append(boleto.DataDocumento.ToString("ddMMyyyy"));
					registro.Append(Utils.FitStringLength(boleto.DataDocumento.ToString("ddMMyyyy"), 8, 8, '0', 0, true, true, true));


					//Chave de Acesso DANFE  da Nota 38 á 81 
					registro.Append(Utils.FitStringLength("0", 44, 44, '0', 0, true, true, true));

					//Complemento do registro 82 á 394 
					registro.Append(Utils.FitStringLength(string.Empty, 313, 313, ' ', 0, true, true, false));
					
					//Número sequencial do registro 82 á 394 
					registro.Append(Utils.FitStringLength(sequencia.ToString(), 6, 6, '0', 0, true, true, true));
					
					// do registro no arquivo.
					var registroFormatado = Utils.SubstituiCaracteresEspeciais(registro.ToString());
					gravaLinha.WriteLine(registroFormatado);



					nr_registro = nr_registro + 1;
				}


			}
			//TRAILER DA REMESSA
			var complemento = new string(' ', 393);
			var trailer = new StringBuilder();

			trailer.Append("9");
			trailer.Append(complemento);
			trailer.Append(Utils.FitStringLength(sequencia.ToString(), 6, 6, '0', 0, true, true, true));

			// Número sequencial do registro no arquivo.
			var trailerFormatado = Utils.SubstituiCaracteresEspeciais(trailer.ToString());
			gravaLinha.WriteLine(trailerFormatado);

			lbl_selecionados.Text = sequencia.ToString();
			MessageBox.Show(sequencia.ToString());
			gravaLinha.Close();
		}
		public void GeraArquivoCNAB400()
		{
			try
			{
				Stream arquivo = File.OpenWrite(@"C:\\TEMP\Test.txt"); // @"C:\Temp\Mahesh.txt";
				StreamWriter gravaLinha = new StreamWriter(arquivo);

				#region Variáveis

				string _header;
				string _detalhe1;
				string _detalhe2;
				string _detalhe3;
				string _trailer;

				string n275 = new string(' ', 275);
				string n025 = new string(' ', 25);
				string n023 = new string(' ', 23);
				string n039 = new string('0', 39);
				string n026 = new string('0', 26);
				string n090 = new string(' ', 90);
				string n160 = new string(' ', 160);

				#endregion

				#region HEADER

				_header = "02RETORNO01COBRANCA       347700232610        ALLMATECH TECNOLOGIA DA INFORM341BANCO ITAU SA  ";
				_header += "08010800000BPI00000201207";
				_header += n275;
				_header += "000001";






				gravaLinha.WriteLine(_header);

				#endregion

				#region DETALHE

				_detalhe1 = "10201645738000250097700152310        " + n025 + "00000001            112000000000             ";
				_detalhe1 += "I06201207000000000100000000            261207000000002000034134770010000000000500" + n025 + " ";
				_detalhe1 += n039 + "0000000020000" + n026 + "   2112070000      0000000000000POLITEC LTDA                  " + n023 + "               ";
				_detalhe1 += "AA000002";

				gravaLinha.WriteLine(_detalhe1);

				_detalhe2 = "10201645738000250097700152310        " + n025 + "00000002            112000000000             ";
				_detalhe2 += "I06201207000000000100000000            261207000000002000034134770010000000000500" + n025 + " ";
				_detalhe2 += n039 + "0000000020000" + n026 + "   2112070000      0000000000000POLITEC LTDA                  " + n023 + "               ";
				_detalhe2 += "AA000003";

				gravaLinha.WriteLine(_detalhe2);

				_detalhe3 = "10201645738000250097700152310        " + n025 + "00000003            112000000000             ";
				_detalhe3 += "I06201207000000000100000000            261207000000002000034134770010000000000500" + n025 + " ";
				_detalhe3 += n039 + "0000000020000" + n026 + "   2112070000      0000000000000POLITEC LTDA                  " + n023 + "               ";
				_detalhe3 += "AA000004";

				gravaLinha.WriteLine(_detalhe3);

				#endregion

				#region TRAILER

				_trailer = "9201341          0000000300000000060000                  0000000000000000000000        ";
				_trailer += n090 + "0000000000000000000000        000010000000300000000060000" + n160 + "000005";
				;

				gravaLinha.WriteLine(_trailer);

				#endregion

				gravaLinha.Close();

			}
			catch (Exception ex)
			{
				throw new Exception("Erro ao criar arquivo.", ex);
			}
		}
		//private string FormataLinhaArquivoCNAB(string strLinha, int tamanhoRegistro)
		//{
		//	strLinha = strLinha.ToUpper();
		//	if (_banco.GerarTrailerRemessaComDetalhes)
		//	{
		//		strLinha = Utils.SubstituiCaracteresEspeciais(strLinha);
		//	}
		//	if (tamanhoRegistro != 0)
		//	{
		//		string[] strLinhas = strLinha.Split('\n');
		//		foreach (string s in strLinhas)
		//		{
		//			if (s.Replace("\r", "").Length != tamanhoRegistro)
		//				throw new Exception("Registro com tamanho incorreto:" + s.Replace("\r", "").Length.ToString() + " - " + s);
		//		}
		//	}
		//	return strLinha.ToUpper();
		//}
		private string GerarHeaderRemessaCNAB400(string convenio)
		{

			var header = new StringBuilder();

			header.Append("0"); // Identificação do registro header, sempre 0
			header.Append("1"); // Código da remessa, sempre 1
			header.Append("REMESSA"); // Literal de remessa
			header.Append("01"); // Código do serviço, sempre 01
			header.Append(Utils.FitStringLength("COBRANCA", 15, 15, ' ', 0, true, true, false));

			// Identificação por extenso do tipo de serviço
			header.Append(Utils.FitStringLength(convenio, 12, 12, ' ', 0, true, true, false));

			// Código da empresa, fornecido pelo banco
			header.Append(new string(' ', 8)); // BRANCOS
			header.Append(Utils.FitStringLength(this.c.Nome, 30, 30, ' ', 0, true, true, false)); // Nome do cedente
			header.Append("707"); // Código do banco
			header.Append(Utils.FitStringLength("BANCO DAYCOVAL", 15, 15, ' ', 0, true, true, false)); // Nome do banco
			header.Append(DateTime.Now.ToString("ddMMyy")); // Data
			header.Append(Utils.FitStringLength(string.Empty, 294, 294, ' ', 0, true, true, false));
			header.Append("000001"); // Sequencial, sempre 1

			var headerFormatado = Utils.SubstituiCaracteresEspeciais(header.ToString());

			return headerFormatado;
		}
		private string GerarDetalheRemessaCNAB400(Boleto boleto, int numeroRegistro)
		{
			
			var detalhe = new StringBuilder();

			detalhe.Append("1"); // Identificação do registro, sempre 1

			// Identificação do tipo de inscrição da empresa
			// 01 - CPF do cedente
			// 02 - CNPJ do cedente
			// 03 - CPF do Sacador
			// 04 - CNPJ Sacador
			detalhe.Append(boleto.Cedente.CPFCNPJ.Length == 11 ? "01" : "02");

			// CPF/CNPJ da empresa ou sacador
			detalhe.Append(Utils.FitStringLength(boleto.Cedente.CPFCNPJ, 14, 14, '0', 0, true, true, true));

			detalhe.Append(Utils.FitStringLength(boleto.Cedente.Convenio.ToString(), 20, 20, ' ', 0, true, true, false));

			// Código da empresea, fornecido pelo banco
			detalhe.Append(Utils.FitStringLength(boleto.NumeroDocumento, 25, 25, ' ', 0, true, true, true));

			detalhe.Append(Utils.FitStringLength(boleto.NossoNumero, 8, 8, '0', 0, true, true, true)); // Nosso número
			detalhe.Append(Utils.FitStringLength(boleto.NossoNumero, 13, 13, '0', 0, true, true, true));

			// Nosso número do correspondente, mesmo do boleto
			if (this._banco == null)
			{
				this._banco = boleto.Banco;
			}

			this._banco.ValidaBoleto(boleto);

			detalhe.Append(Utils.FitStringLength(string.Empty, 24, 24, ' ', 0, true, true, false)); // Uso do banco
			detalhe.Append("4"); // TODO: Código de remessa
			detalhe.Append("01"); // TODO: Código de ocorrência
			detalhe.Append(Utils.FitStringLength(boleto.NumeroDocumento, 10, 10, ' ', 0, true, true, false)); // Seu número
			detalhe.Append(boleto.DataVencimento.ToString("ddMMyy"));
			detalhe.Append(Utils.FitStringLength(boleto.ValorBoleto.ApenasNumeros(), 13, 13, '0', 0, true, true, true));
			detalhe.Append("707"); // Código do banco
			detalhe.Append(Utils.FitStringLength(string.Empty, 4, 4, '0', 0, true, true, true)); // Agência cobradora
			detalhe.Append("0"); // DAC da agência cobradora
			detalhe.Append(Utils.FitStringLength(boleto.EspecieDocumento.Codigo, 2, 2, '0', 0, true, true, true));
			detalhe.Append("N"); // Indicação de aceite do título, sempre N
			detalhe.Append(boleto.DataDocumento.ToString("ddMMyy"));
			detalhe.Append(Utils.FitStringLength(string.Empty, 4, 4, '0', 0, true, true, true)); // Zeros
																								 // detalhe.Append(Utils.FitStringLength(boleto.JurosMora.ApenasNumeros(), 13, 13, '0', 0, true, true, true));
			detalhe.Append(Utils.FitStringLength("0", 13, 13, '0', 0, true, true, true));
			detalhe.Append(boleto.DataDesconto == DateTime.MinValue ? "000000" : boleto.DataDesconto.ToString("ddMMyy"));
			detalhe.Append(Utils.FitStringLength(boleto.ValorDesconto.ApenasNumeros(), 13, 13, '0', 0, true, true, true));
			detalhe.Append(Utils.FitStringLength(boleto.IOF.ApenasNumeros(), 26, 26, '0', 0, true, true, true));
			detalhe.Append(boleto.Sacado.CPFCNPJ.Length == 11 ? "01" : "02");
			detalhe.Append(Utils.FitStringLength(boleto.Sacado.CPFCNPJ, 14, 14, '0', 0, true, true, true));
			detalhe.Append(
				Utils.SubstituiCaracteresEspeciais(Utils.FitStringLength(boleto.Sacado.Nome, 30, 30, ' ', 0, true, true, false)));
			detalhe.Append(Utils.FitStringLength(string.Empty, 10, 10, ' ', 0, true, true, false));
			detalhe.Append(
				Utils.SubstituiCaracteresEspeciais(
					Utils.FitStringLength(boleto.Sacado.Endereco.EndComNumeroEComplemento, 40, 40, ' ', 0, true, true, false)));
			detalhe.Append(
				Utils.SubstituiCaracteresEspeciais(
					Utils.FitStringLength(boleto.Sacado.Endereco.Bairro, 12, 12, ' ', 0, true, true, false)));
			detalhe.Append(Utils.FitStringLength(boleto.Sacado.Endereco.CEP, 8, 8, '0', 0, true, true, true));
			detalhe.Append(
				Utils.SubstituiCaracteresEspeciais(
					Utils.FitStringLength(boleto.Sacado.Endereco.Cidade, 15, 15, ' ', 0, true, true, false)));
			detalhe.Append(Utils.FitStringLength(boleto.Sacado.Endereco.UF, 2, 2, ' ', 0, true, true, false));
			if (boleto.Avalista != null)
			{
				detalhe.Append(Utils.FitStringLength(boleto.Avalista.Nome, 30, 30, ' ', 0, true, true, false));
			}
			else
			{
				detalhe.Append(Utils.FitStringLength(string.Empty, 30, 30, ' ', 0, true, true, false));
			}

			detalhe.Append(Utils.FitStringLength(string.Empty, 10, 10, ' ', 0, true, true, false)); // Brancos
			detalhe.Append("00"); // Dias para início do protesto
			detalhe.Append(boleto.Moeda == 9 ? 0 : 2);
			detalhe.Append(Utils.FitStringLength(numeroRegistro.ToString(), 6, 6, '0', 0, true, true, true));

			var detalheFormatado = detalhe.ToString();

			if (detalheFormatado.Length != 400)
			{
				throw new Exception("Tamanho do registro inválido.");
			}

			return detalheFormatado;
		}

		private string GerarTrailerRemessa400(int numeroRegistro)
		{
			try
			{
				var complemento = new string(' ', 393);
				var trailer = new StringBuilder();

				trailer.Append("9");
				trailer.Append(complemento);
				trailer.Append(Utils.FitStringLength(numeroRegistro.ToString(), 6, 6, '0', 0, true, true, true));

				// Número sequencial do registro no arquivo.
				var trailerFormatado = Utils.SubstituiCaracteresEspeciais(trailer.ToString());

				return trailerFormatado;
			}
			catch (Exception ex)
			{
				throw new Exception("Erro durante a geração do registro TRAILER do arquivo de REMESSA.", ex);
			}
		}

        private void cmdPesquisar_Click(object sender, EventArgs e)
        {
			c.Codigo = "050121";
			c.Convenio = 1906905012100;
			c.Nome = "CARSYSTEM ALARMES LTDA";


			//GeraArquivoCNAB400();
			Boleto boleto = new Boleto();
			GerarHeaderRemessaCNABNew(190605012100);
		}
    }
}
