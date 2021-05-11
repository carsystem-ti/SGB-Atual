using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGB
{
    public partial class igpm : Form
    {
        CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados("SGB", CarSystem.Tipos.Servidores.Fury, "usr_sgb", "sgb_usr");

        public igpm()
        {
            InitializeComponent();

            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "select Principal.Debito.fun_getValorIGPM(0)";
            dados.Comandos.tipoComando = CommandType.Text;

            textBox1.Text = dados.execute().Tables[0].Rows[0][0].ToString();
        }

        private void cmdIGMP_Click(object sender, EventArgs e)
        {
            dados.Comandos.limpaParametros();
            dados.Comandos.textoComando = "Principal.Debito.pro_setValorIGPM " + textBox1.Text.Replace(',','.') ;
            dados.Comandos.tipoComando = CommandType.Text;
            dados.retornaDados = false;

            dados.execute();

            MessageBox.Show("IGPM Atualizado!!");


        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char a = e.KeyChar;
            char b = ',';
            char c = Convert.ToChar(8);

            if (textBox1.Text.Contains(',') && e.KeyChar == b)
            {
                e.Handled = true;
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                if ( e.KeyChar != b && e.KeyChar != c )
                    e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
