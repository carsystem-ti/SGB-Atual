using BoletoNet;
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
    public partial class ArquivoRemessaSafra : Form
    {
        public ArquivoRemessaSafra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nomeArquivo = "Arquivo" + ".TXT.txt";
            Stream arquivo = File.OpenWrite(@"C:\\TEMP\" + nomeArquivo.ToString()); // @"C:\Temp\Mahesh.txt";
            StreamWriter gravaLinha = new StreamWriter(arquivo);

            var header = new StringBuilder();

            int numeroArquivoRemessa = 0;
            int numeroRegistroGeral = 0;

            var numeroArquivoRemessa3Digitos = numeroArquivoRemessa.ToString().PadLeft(3, '0');
            numeroArquivoRemessa3Digitos = numeroArquivoRemessa3Digitos.Substring(numeroArquivoRemessa3Digitos.Length - 3);
            numeroRegistroGeral++;
            var reg = new TRegistroEDI();
            
            
            //Codigo Registro Posicao 1
            header.Append("0"); // Identificação do registro header, sempre 0
            
            //Identificação Arquivo REMESSA 2
            header.Append("1"); // Identificação do registro header, sempre 0]

            //Identificação Arquivo REMESSA 3 á 9
            header.Append(Utils.FitStringLength("REMESSA", 7, 7, ' ', 0, true, true, false));

            //Código Identificação Do Serviço  10 á 11
            header.Append("01"); // Identificação do registro header, sempre 0

            //Identificação Do Serviço P/ Extenso  12 á 19
            header.Append(Utils.FitStringLength("COBRANCA", 8, 8, ' ', 0, true, true, false));

            //Brancos Extenso  20 á 26
            header.Append(Utils.FitStringLength(string.Empty, 7, 7, ' ', 0, true, true, false));

            //Identificação Empresa No Banco  27 á 40
            header.Append(Utils.FitStringLength("0028", 14, 14, '0', 0, true, true, false));


            // header.Append((TTiposDadoEDI.ediNumericoSemSeparador_, 0002, 001, 0, "1", '0'));
            header.Append((TTiposDadoEDI.ediAlphaAliEsquerda_____, 0003, 007, 0, "REMESSA", ' '));
            header.Append((TTiposDadoEDI.ediNumericoSemSeparador_, 0010, 002, 0, "01", '0'));
            header.Append((TTiposDadoEDI.ediAlphaAliEsquerda_____, 0012, 015, 0, "COBRANCA", ' '));
            header.Append((TTiposDadoEDI.ediNumericoSemSeparador_, 0027, 004, 0, "0028", '0'));// Cedente.ContaBancaria.Agencia
            header.Append((TTiposDadoEDI.ediNumericoSemSeparador_, 0031, 001, 0, "0", '0'));//Cedente.ContaBancaria.DigitoAgencia
            header.Append((TTiposDadoEDI.ediNumericoSemSeparador_, 0032, 002, 0, "0", '0'));
            header.Append((TTiposDadoEDI.ediNumericoSemSeparador_, 0034, 006, 0, "30332", '0'));//Cedente.ContaBancaria.Conta
            header.Append((TTiposDadoEDI.ediNumericoSemSeparador_, 0040, 001, 0, "7", '0'));//Cedente.ContaBancaria.DigitoConta
            header.Append((TTiposDadoEDI.ediAlphaAliEsquerda_____, 0041, 006, 0, String.Empty, ' '));
            header.Append((TTiposDadoEDI.ediAlphaAliEsquerda_____, 0047, 030, 0, "CARSYSTEM ALARMES LTDA - 04.401.579/0001-55", ' '));//Cedente.Nome
            header.Append((TTiposDadoEDI.ediAlphaAliEsquerda_____, 0077, 003, 0, "422", ' '));
            header.Append((TTiposDadoEDI.ediAlphaAliEsquerda_____, 0080, 015, 0, "BANCO SAFRA", ' '));
            header.Append((TTiposDadoEDI.ediDataDDMMAA___________, 0095, 006, 0, DateTime.Now, ' '));
            header.Append((TTiposDadoEDI.ediAlphaAliEsquerda_____, 0101, 291, 0, String.Empty, ' '));
            header.Append((TTiposDadoEDI.ediAlphaAliEsquerda_____, 0392, 003, 0, numeroArquivoRemessa3Digitos, '0'));
            header.Append((TTiposDadoEDI.ediNumericoSemSeparador_, 0395, 006, 0, "000001", '0'));
            var headerFormatado = SubstituiCaracteresEspeciais(header.ToString());
            gravaLinha.WriteLine(headerFormatado);
            gravaLinha.Close();
        }
    }
}
