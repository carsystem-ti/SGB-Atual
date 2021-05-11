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
    public partial class CSTech : Form
    {
        CarSystem.Technology.Funcoes oFuncoes = new CarSystem.Technology.Funcoes
            ("bdCSTech","usr_sgb","sgb_usr",CarSystem.Tipos.Servidores.Fury) ;

        CarSystem.Boletos.Boleto boletos;
        CarSystem.Banco.NetBoleto netBoleto = new CarSystem.Banco.NetBoleto(7);

        public CSTech()
        {
            InitializeComponent();
            carregaComboPesquisa();

            if (Environment.UserName.ToLower() == "carlos.pieren") // 
                textEmail.Text = "carlos.pieren@carsystem.com";

            boletos = new CarSystem.Boletos.Boleto(CarSystem.Tipos.nomeBanco.Santander, oFuncoes.dados);
        }

        private void carregaComboPesquisa()
        {
            comboPesquisa.DataSource = oFuncoes.getTiposPesquisa();
            comboPesquisa.DisplayMember = "ds_pesquisa";
            comboPesquisa.ValueMember = "id_pesquisa";
        }

        private void botaoPesquisar_Click(object sender, EventArgs e)
        {
            TreeNode iTreeNode;
            System.Data.DataTable iTabela = oFuncoes.getPesquisa((int)comboPesquisa.SelectedValue, textPesquisa.Text);

            treeEmpresa.Nodes.Clear();

            foreach (System.Data.DataRow iLinha in iTabela.Rows)
            {
                iTreeNode = treeEmpresa.Nodes.Add(iLinha[0].ToString().ToUpper(), iLinha[1].ToString().ToUpper());

                switch ((int)comboPesquisa.SelectedValue)
                {
                    case 1:
                    case 2:
                        iTreeNode.Nodes.Add("CLIENTE");
                        break;
                    case 3:
                    case 4:
                        iTreeNode.Nodes.Add("EMPRESA");
                        break;
                }
            }
        }


        private void gridPai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void treeEmpresa_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            System.Data.DataTable iTabela;

            if (e.Node.Level != 0)
                return;

            if (e.Node.Nodes[0].Text == "CLIENTE")
                iTabela = oFuncoes.getEmpresasCliente(Convert.ToInt32(e.Node.Name));
            else if (e.Node.Nodes[0].Text == "EMPRESA")
                iTabela = oFuncoes.getEmpresa(Convert.ToInt32(e.Node.Name));
            else
                return;

            e.Node.Nodes.Clear();

            foreach (System.Data.DataRow iLinha in iTabela.Rows)
                e.Node.Nodes.Add(iLinha[0].ToString().ToUpper(), iLinha[1].ToString().ToUpper());

        }

        private void treeEmpresa_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            System.Data.DataTable iTabela;

            if (e.Node.Level == 0)
                iTabela = oFuncoes.getDebitos(Convert.ToInt32(e.Node.Name), false);
            else
                iTabela = oFuncoes.getDebitos(Convert.ToInt32(e.Node.Name), true);

            gridDebitos.DataSource = iTabela;

            //gridDebitos.Columns["inicioApuracao"];
            //gridDebitos.Columns["fimApuracao"] ;
        }

        private void cmdEnviar_Click(object sender, EventArgs e)
        {

            string nomeFuncao = "Technology.cmdEnviar_Click";

            try
            {
                System.Collections.Generic.List<CarSystem.Banco.Boleto.criteriosBoleto> iLista = preparacaoBoleto();

                if (iLista.Count == 0)
                {
                    MessageBox.Show("Nenhum débito selecionado!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //carlos.pieren@carsystem.com
                    return;
                }

                if (((Button)sender).Name == "cmdEnviar")
                    netBoleto.Executa(iLista, new CarSystem.Banco.Boleto.informacoesEmail("financeiro@carsystem.com", textEmail.Text, "Boletos CarSystem Technology", "", "Financeiro CS Tech"), "bdCSTech.SGB.pro_getDebitosByCodigo");
                else
                    netBoleto.Executa(iLista, null, "bdcstech.SGB.pro_getDebitosByCodigo");



                MessageBox.Show("Processo concluído!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }

       private System.Collections.Generic.List<CarSystem.Banco.Boleto.criteriosBoleto> preparacaoBoleto()
        {
            string nomeFuncao = "geraBoletos.Boletos.preparacaoBoleto";            
            System.Collections.Generic.List<CarSystem.Banco.Boleto.criteriosBoleto> iListaBoletos = new List<CarSystem.Banco.Boleto.criteriosBoleto>();
            bool iIsTemBoleto = false;

            try
            {

                foreach (System.Windows.Forms.DataGridViewRow iLinhaGrid in gridDebitos.Rows)
                {
                    if ((bool)iLinhaGrid.Cells["enviarEmail"].Value)
                    {
                        iIsTemBoleto = true;

                        iListaBoletos.Add(new CarSystem.Banco.Boleto.criteriosBoleto(Convert.ToInt64(iLinhaGrid.Cells["codigoFatura"].Value)
                        , 7, Convert.ToDateTime(iLinhaGrid.Cells["dataVencimento"].Value), false,textDemonstrativo.Text));
                    }
                }

                if (!iIsTemBoleto)
                    MessageBox.Show("Nenhum débito selecionado!");
            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }

            return iListaBoletos;
        }

    

        private void gridDebitos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void gridDebitos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool isTituloNecessario = true;

            textDemonstrativo.Text = "";

            foreach (System.Windows.Forms.DataGridViewRow iLinhaGrid in gridDebitos.Rows)
                if ((bool)iLinhaGrid.Cells["enviarEmail"].Value)
                    if (isTituloNecessario)
                        textDemonstrativo.Text = "Monitoramento " + iLinhaGrid.Cells["inicioApuracao"].Value.ToString().Replace("00:00:00", "") + " à " +
                            iLinhaGrid.Cells["fimApuracao"].Value.ToString().Replace("00:00:00", "");
                    else
                        textDemonstrativo.Text += ", " + iLinhaGrid.Cells["inicioApuracao"].Value.ToString().Replace("00:00:00", "") + " à " +
                            iLinhaGrid.Cells["fimApuracao"].Value.ToString().Replace("00:00:00", "");

        }

        private void gridDebitos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (gridDebitos.Columns["enviarEmail"].Index != e.ColumnIndex)
                e.Cancel = true;
        }


    }
}
