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
    public partial class adInad : Form
    {
        CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados("SGB", CarSystem.Tipos.Servidores.Fury, "usr_sgb", "sgb_usr");

        public adInad()
        {
            InitializeComponent();
        }

        private void cmdAlterar_Click(object sender, EventArgs e)
        {
            string nomeFuncao = "geraBoletos.Boletos.gravaParcelasGeradas";

            try
            {
                if (MessageBox.Show("Alterar o contrato '" + textContrato.Text + "'?", "Alterar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                dados.Comandos.textoComando = "sgb.dbo.pro_SGB_setAdimplencia";
                dados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;
                dados.retornaDados = false;

                dados.Comandos.limpaParametros();
                dados.Comandos.adicionaParametro("@numeroContrato", System.Data.SqlDbType.VarChar, 10, textContrato.Text);
                dados.Comandos.adicionaParametro("@nomeUsuario", System.Data.SqlDbType.VarChar, 8, System.Environment.UserName);
                
                dados.execute();

                MessageBox.Show("Alterado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }

        }
    }
}
