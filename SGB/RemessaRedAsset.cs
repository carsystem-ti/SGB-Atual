using BoletoNet;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BoletoNet.Util;
using System.IO;



namespace SGB
{
    public partial class RemessaRedAsset : Form
    {
		Banco_Daycoval banco = new Banco_Daycoval();
		Cedente c = new Cedente();
		private IBanco _banco;
		CarSystem.BancoDados.Dados _dados;
		public RemessaRedAsset()
        {
            InitializeComponent();
        }
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
		private void cmdPesquisar_Click(object sender, EventArgs e)
        {
            c.Codigo = "050121";
            c.Convenio = 5433328;
            c.Nome = "RED S.A";


            //GeraArquivoCNAB400();
            Boleto boleto = new Boleto();
            GerarHeaderRemessaCNABNew(5433328);
        }
		private void GerarHeaderRemessaCNABNew(long convenio)
		{
			int nr_registro = 0;
			int sequencia = 0;
			int id_remessa = 0;
			Boleto boleto = new Boleto();

			string nameArquivoRef = "Remessa";
			string nomeArquivo = nameArquivoRef.ToString() + ".TXT.txt";
			id_remessa = 10;//; Convert.ToInt32(dsArquivo.Tables[0].Rows[0]["id_remessa"].ToString());
			//"7GY" + DateTime.Now.ToString("ddMM").ToString() + "1.TXT.txt";
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
			header.Append(Utils.FitStringLength(convenio.ToString(), 20, 20, ' ', 0, true, true, false));

			//Nome da empresa 47 á 76
			header.Append(Utils.FitStringLength(this.c.Nome, 30, 30, ' ', 0, true, true, false)); // Nome do cedente

			//Codigo do Banco 77 á 79
			header.Append("707"); // Código do banco

			//Nome do Banco 80 á 94
			header.Append(Utils.FitStringLength("BANCO RED SA", 15, 15, ' ', 0, true, true, false)); // Nome do banco

			//Data da Gravacao 95 á 100
			header.Append(DateTime.Now.ToString("ddMMyy")); // Data

			//Complemento do registro 101 á 394
			header.Append(Utils.FitStringLength(string.Empty, 294, 294, ' ', 0, true, true, false));

			//SEQUENCIAL DO REGISTRO 395 Á 400
			header.Append("000001"); // Sequencial, sempre 1

			var headerFormatado = Utils.SubstituiCaracteresEspeciais(header.ToString());

			gravaLinha.WriteLine(headerFormatado);

			DataSet ds = getBoletos();
			nr_registro = 0;
			///sageBox.Show("Quantidade de Boletos a ser processado : " + ds.Tables.Count.ToString() + " !!!");
			sequencia = 1;
			foreach (DataRow dr in ds.Tables[0].Rows)
			{


				///sequencia = sequencia + 1;
				var detalhe = new StringBuilder();

				nr_registro = 1;// getRangeDaycoval();

				if (nr_registro > 0)
				{
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
					c.CPFCNPJ = "67915785000101";
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

						this._banco = new Bancos(237);
						this._banco.Codigo = 237;
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
					detalhe.Append("237"); // Código do banco

					//Código do Banco 143 á 146
					detalhe.Append(Utils.FitStringLength(string.Empty, 4, 4, '0', 0, true, true, true)); // Agência cobradora

					//Código do Banco 147 á 147
					detalhe.Append("0"); // DAC da agência cobradora

					//Especie 148 á 149
					detalhe.Append(Utils.FitStringLength("12", 2, 2, '0', 0, true, true, true));

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
					detalhe.Append("000000");

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
							Utils.FitStringLength(dr.ItemArray[9].ToString(), 15, 15, ' ', 0, true, true, false)));

					//UF  350 á 351
					///boleto.Sacado.Endereco.UF = dr.ItemArray[12].ToString();
					detalhe.Append(Utils.FitStringLength(dr.ItemArray[12].ToString(), 2, 2, ' ', 0, true, true, false));

					//AVALISTA 352 Á 381 
					//if (boleto.Avalista != null)
					//{
					//boleto.Avalista.Nome = dr.ItemArray[1].ToString();
					detalhe.Append(Utils.FitStringLength("CAR SYSTEM ALARMES LTDA", 30, 30, ' ', 0, true, true, false));
					//}
					//else
					//{
					//detalhe.Append(Utils.FitStringLength("CAR SYSTEM ALARMES LTDA", 30, 30, ' ', 0, true, true, false));
					//}

					//BRANCOS 382 Á 385
					detalhe.Append(Utils.FitStringLength(string.Empty, 4, 4, ' ', 0, true, true, false)); // Brancos


					//BRANCOS 386 Á 391
					detalhe.Append(Utils.FitStringLength(string.Empty, 6, 6, ' ', 0, true, true, false)); // Brancos

					//DIAS 392 Á 393
					detalhe.Append("00"); // Dias para início do protesto

					//MOEDA 394 Á 394
					detalhe.Append(boleto.Moeda == 9 ? 0 : 2);

					//numero registro 394 Á 394
					sequencia = sequencia + 1;
					detalhe.Append(Utils.FitStringLength(sequencia.ToString(), 6, 6, '0', 0, true, true, true));

					var detalheFormatado = detalhe.ToString();

					if (detalheFormatado.Length != 400)
					{
						throw new Exception("Tamanho do registro inválido.");
					}
					else
					{
						gravaLinha.WriteLine(detalheFormatado);

						//var registro = new StringBuilder();

						////Identificacao Posicao 1 á 1 
						//registro.Append("4");

						////Número da Nota Fiscal 2 á 16 
						//registro.Append(Utils.FitStringLength("0", 15, 15, '0', 0, true, true, true));

						////Valor da Nota Fiscal 17 á 29 
						//registro.Append(Utils.FitStringLength(boleto.ValorBoleto.ApenasNumeros(), 13, 13, '0', 0, true, true, true));

						////Data de Emissão da Nota 30 á 37 
						////registro.Append(boleto.DataDocumento.ToString("ddMMyyyy"));
						//registro.Append(Utils.FitStringLength(boleto.DataDocumento.ToString("ddMMyyyy"), 8, 8, '0', 0, true, true, true));


						////Chave de Acesso DANFE  da Nota 38 á 81 
						//registro.Append(Utils.FitStringLength("0", 44, 44, '0', 0, true, true, true));

						////Complemento do registro 82 á 394 
						//registro.Append(Utils.FitStringLength(string.Empty, 313, 313, ' ', 0, true, true, false));

						////Número sequencial do registro 82 á 394 
						//registro.Append(Utils.FitStringLength(sequencia.ToString(), 6, 6, '0', 0, true, true, true));

						//// do registro no arquivo.
						//var registroFormatado = Utils.SubstituiCaracteresEspeciais(registro.ToString());
						//gravaLinha.WriteLine(registroFormatado);



						//nr_registro = nr_registro + 1;
						// setNextRangeDaycoval(boleto.NumeroDocumento, boleto.NossoNumero, nomeArquivo, id_remessa);
					}
				}
				else
				{
					MessageBox.Show("Range de uso terminou!!! " + sequencia.ToString());
				}




			}
			//TRAILER DA REMESSA
			var complemento = new string(' ', 393);
			var trailer = new StringBuilder();

			trailer.Append("9");
			trailer.Append(complemento);
			sequencia = sequencia + 1;
			trailer.Append(Utils.FitStringLength(sequencia.ToString(), 6, 6, '0', 0, true, true, true));

			// Número sequencial do registro no arquivo.
			var trailerFormatado = Utils.SubstituiCaracteresEspeciais(trailer.ToString());
			gravaLinha.WriteLine(trailerFormatado);

			lbl_selecionados.Text = sequencia.ToString();
			MessageBox.Show("Arquivo gerado com sucesso,foram processados: " + sequencia.ToString());
			gravaLinha.Close();
		}
		private DataSet getBoletos()
		{
			DataSet ds = new DataSet();
			dados.Comandos.limpaParametros();
			dados.Comandos.textoComando = "Principal.[webApi].[pro_getCR]";
			dados.Comandos.tipoComando = CommandType.StoredProcedure;
			dados.Comandos.adicionaParametro("@tipo", SqlDbType.VarChar, 12, 4);
			dados.retornaDados = true;
			ds = dados.execute();

			return ds;
		}
	}
}
