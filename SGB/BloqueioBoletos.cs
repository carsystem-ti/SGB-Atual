using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geracaoRemessa.Formulario
{
    public partial class BloqueioBoletos : Form
    {
        CarSystem.Remessas.Remessa remessa;
        System.Data.DataTable tbCarregamento;
        System.Boolean isAtualizando = false;

        ContextMenu _menuGrid;

        public BloqueioBoletos(CarSystem.Remessas.Remessa remessa)
        {
            InitializeComponent();
            this.remessa = remessa;
            atualizaTela();
        }
        private void atualizaTela()
        {
            if (remessa.infoRemessa.codigoEtapa == (int)CarSystem.Tipos.etapasRemessa.leituraBloqueios)
                tbCarregamento = remessa.getResumoClientes(CarSystem.Tipos.bloqueiosDebito.todos);
            else
                tbCarregamento = remessa.getResumoClientes(CarSystem.Tipos.bloqueiosDebito.semCarne);

            tbCarregamento.PrimaryKey = new DataColumn[] { tbCarregamento.Columns["contrato"] };
            carregaListas("", "", "", "");
            carregaListaBloqueios();
        }
        private void BloqueioBoletos_Load(object sender, EventArgs e)
        {

        }
        private void carregaListas(string produto, string status, string valor, string pedido)
        {
            isAtualizando = true;

            string criterio = "";
            System.Data.DataTable dtCarregador = new System.Data.DataTable();

            if (pedido != null && pedido != "")
                criterio = String.Format("contrato = '{0}'", pedido);
            else
            {
                if (produto != null && produto != "")
                    criterio += String.Format("produto = '{0}'", produto);
                else
                    listaProduto.SelectedIndex = -1;

                if (status != null && status != "")
                {
                    if (criterio != "")
                        criterio += " and ";
                    criterio += String.Format("status = '{0}'", status);
                }
                else
                    listaStatus.SelectedIndex = -1;


                if (valor != null && valor != "")
                {
                    if (criterio != "")
                        criterio += " and ";
                    criterio += String.Format("valor = {0}", valor.Replace(',', '.'));
                }
                else
                    listaValor.SelectedIndex = -1;
            }

            listaProduto.DisplayMember = "produto"; listaStatus.DisplayMember = "status"; listaValor.DisplayMember = "valor";

            if (produto != null && (listaProduto.Text != produto || listaProduto.Text == ""))
                listaProduto.DataSource = remessa.dados.tabelaAgrupada("tab", tbCarregamento, "produto", criterio);

            if (status != null && (listaStatus.Text != status || listaStatus.Text == ""))
                listaStatus.DataSource = remessa.dados.tabelaAgrupada("tab", tbCarregamento, "status", criterio);

            if (valor != null && (listaValor.Text != valor || listaValor.Text == ""))
                listaValor.DataSource = remessa.dados.tabelaAgrupada("tab", tbCarregamento, "valor", criterio);

            BindingSource bsCarregador = new BindingSource();
            dtCarregador = tbCarregamento.Copy();
            bsCarregador.DataSource = dtCarregador;
            dg_Filtrados.DataSource = bsCarregador;
            bsCarregador.Filter = criterio;

            lbl_selecionados.Text = bsCarregador.Count.ToString().PadLeft(6, '0');

            isAtualizando = false;

        }
        private void listaProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (isAtualizando)
            //    return;

            //string produto = "";
            //string valor = "";
            //string status = "";

            //if (listaProduto.SelectedIndex != -1)
            //    produto = listaProduto.Text;

            ////if (listaValor.SelectedIndex != -1)
            ////    valor = listaValor.Text;

            ////if (listaStatus.SelectedIndex != -1)
            ////    status = listaStatus.Text;

            //carregaListas(produto, status , valor ,"");

            if (!isAtualizando)
            {
                isAtualizando = true;
                carregaListas(listaProduto.Text, "", "", "");
                listaTodos.BackColor = System.Drawing.Color.White;
                listaTodos.ForeColor = System.Drawing.Color.Black;
                isAtualizando = false;
            }
        }
        private void listaValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isAtualizando)
            {
                isAtualizando = true;
                carregaListas("", "", listaValor.Text, "");
                listaTodos.BackColor = System.Drawing.Color.White;
                listaTodos.ForeColor = System.Drawing.Color.Black;
                isAtualizando = false;
            }
        }
        private void listaStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isAtualizando)
            {
                isAtualizando = true;
                carregaListas("", listaStatus.Text, "", "");
                listaTodos.BackColor = System.Drawing.Color.White;
                listaTodos.ForeColor = System.Drawing.Color.Black;
                isAtualizando = false;
            }
        }
        private DataTable tabelaBloqueios()
        {
            CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados(remessa.dados);

            dados.Comandos.textoComando = "pro_SGB_getBloqueios";
            dados.Comandos.tipoComando = CommandType.StoredProcedure;

            dados.retornaDados = true;

            return dados.execute().Tables[0];
        }

        private void carregaListaBloqueios()
        {

            cb_motivos.ValueMember = "codigo";
            cb_motivos.DisplayMember = "bloqueio";
            cb_motivos.DataSource = tabelaBloqueios();            
        }
        #region efetuaBloqueios
        //private bool efetuaBloqueios(string contrato, bool isPerguntar)
        //{
        //    if ( txt_pedido.Text != "" )
        //        carregaListas("","","",txt_pedido.Text);
        //    if (isPerguntar)
        //        if (MessageBox.Show("Bloquear " + dg_Filtrados.Rows.Count.ToString() + " com o motivo " + cb_motivos.Text + "?", "Bloquear?",
        //                             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
        //            return false;

        //    try
        //    {
        //        foreach (System.Windows.Forms.DataGridViewRow dgrLinha in dg_Filtrados.Rows)
        //            if (dgrLinha.Cells["contrato"].Value.ToString()!= null && dgrLinha.Cells["contrato"].Value.ToString() != "")
        //                remessa.efetuaBloqueio(dgrLinha.Cells["contrato"].Value.ToString(), CarSystem.Tipos.Converter.toBloqueiosDebito(Convert.ToInt32(cb_motivos.SelectedValue)));
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //    return true;
        //}
        #endregion
        private bool executaComandos(string comando, bool isPerguntar)
        {
            string contrato = "";
            string nomeFuncao = "BloqueioBoletos.executaComandos";

            if (txt_pedido.Text != "")
                carregaListas("", "", "", txt_pedido.Text);

            comando = comando.ToUpper();

            try
            {
                foreach (DataGridViewRow dgrLinha in dg_Filtrados.Rows)
                {
                    contrato = dgrLinha.Cells["contrato"].Value.ToString();

                    if (contrato != null && contrato != "")
                    {
                        switch (comando)
                        {
                            case "ALT.VALOR":

                                if (isPerguntar)
                                    if (MessageBox.Show(String.Format("Alterar valores do contrato {0}?", contrato), "Alterar?",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                        return false;

                                double valor = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Qual o novo valor?", "Valores", "", 50, 50).Replace('.', ','));

                                if (remessa.alterarValor(contrato, valor))
                                    MessageBox.Show(String.Format("Os valores do contrato {0}, foram alterados com sucesso!!", contrato),
                                                    "Alteração de valores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show(String.Format("Os valores do contrato {0}, não foram alterados!!", contrato),
                                                    "Alteração de valores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                break;
                            case "BLOQUEAR":
                                if (isPerguntar)
                                    if (MessageBox.Show(String.Format("{0} {1} com o motivo {2}?", comando, dg_Filtrados.Rows.Count, cb_motivos.Text), "Bloquear?",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                        return false;

                                isPerguntar = false;
                                if (remessa.efetuaBloqueio(contrato, CarSystem.Tipos.Converter.toBloqueiosDebito(Convert.ToInt32(cb_motivos.SelectedValue)), cb_motivos.SelectedValue.ToString()))
                                    tbCarregamento.Rows.Find(contrato).Delete();

                                break;
                            case "IMPRIMIR":
                                remessa.imprimeBoleto(contrato);
                                break;
                            case "PIM":
                                string retorno;
                                CarSystem.Cliente cliente = new CarSystem.Cliente(remessa.dados);
                                cliente.getCliente(contrato);
                                cliente.ultimoVencimento = (System.DateTime)dgrLinha.Cells["primeiroVencimento"].Value;
                                /*
                                try
                                {
                                    (new SolicitacoesSGB((CarSystem.BancoDados.Dados)remessa.dados, contrato, remessa.infoRemessa.dataEtapa)).ShowDialog(this);
                                }
                                catch
                                { }
                                */
                                if (cliente.isPodeGerar(out retorno, remessa.infoRemessa.codigoRemessa))
                                {
                                    remessa.efetuaBloqueio(contrato, CarSystem.Tipos.bloqueiosDebito.boletosImpressos,"BOLETOS IMPRESSOS");
                                    if (!remessa.exportaDebitos(contrato))
                                    {
                                        lbl_fundo.BackColor = System.Drawing.Color.Blue;
                                        MessageBox.Show("Cliente não atualizado!");
                                    }
                                    else
                                        lbl_fundo.BackColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    remessa.efetuaBloqueio(contrato, retorno);
                                    lbl_fundo.BackColor = System.Drawing.Color.Red;
                                    MessageBox.Show(String.Format("Separar: {0}", retorno));
                                }
                                txt_pedido.Text = "";
                                break;
                            case "EXPORTAR":

                                string diretorio = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Geracao\";
                                CarSystem.Utilidades.IO.Arquivo.isExisteDir(diretorio, true);

                                string arquivo = diretorio + @"EXP_" + remessa.infoRemessa.nomeRemessa + "_" + DateTime.Today.ToString("ddMMyyyy") + ".txt";

                                MessageBox.Show(String.Format("Arquivo: {0}", CarSystem.Utilidades.IO.Arquivo.gridTOtxt(arquivo, dg_Filtrados)));
                                return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
                return false;
            }

            return true;
        }
        private void txt_pedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && remessa.infoRemessa.codigoEtapa == (int)CarSystem.Tipos.etapasRemessa.leituraBloqueios)
                executaComandos("PIM", false);
            else if (e.KeyChar == (char)Keys.Return)
                executaComandos("BLOQUEAR", true);
        }
        private void listaTodos_Click(object sender, EventArgs e)
        {
            isAtualizando = true;

            carregaListas("", "", "", "");
            txt_pedido.Text = "";

            listaTodos.BackColor = System.Drawing.Color.DarkBlue;
            listaTodos.ForeColor = System.Drawing.Color.White;

            isAtualizando = false;
        }
        private void btn_exportar_Click(object sender, EventArgs e)
        {
            executaComandos("EXPORTAR", false);
            //BindingSource bsCarregador = new BindingSource();
            //bsCarregador.DataSource = dg_Filtrados.DataSource;
            //bsCarregador.Filter = criterio;
            //CarSystem.Utilidades.IO.Arquivo.sqlTOtxt(remessa.infoRemessa.nomeRemessa + ".txt",dg_Filtrados.Bin

        }
        private void btn_bloquear_Click(object sender, EventArgs e)
        {
            if (executaComandos("BLOQUEAR", true))
            {
                MessageBox.Show("Operação concluída!!");
                atualizaTela();
            }
            else
                MessageBox.Show("A Operação falhou!!");
        }
        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            executaComandos("IMPRIMIR", false);
        }
        private void btn_valor_Click(object sender, EventArgs e)
        {
            executaComandos("ALT.VALOR", true);
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Passar para a próxima etapa?", "Etapa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                remessa.passaEtapa();
        }
        private void btn_filtro_Click(object sender, EventArgs e)
        {
            listaProduto_SelectedIndexChanged(null, null);
        }

        private void dg_Filtrados_DoubleClick(object sender, EventArgs e)
        {
            //new infoCliente(dg_Filtrados["contrato",dg_Filtrados.CurrentRow.Index].Value.ToString(), remessa.dados, remessa).Show();
        }

      
        private ContextMenu menuGrid
        {
            get
            {
                string nomeFuncao = "GeracaoRemessa.BloqueioBoletos.CriaMenu";

                if (_menuGrid != null)
                    return _menuGrid;
                
                _menuGrid = new ContextMenu();

                try
                {
                    DataTable dtBloqueios = tabelaBloqueios();

                    if (dtBloqueios.Rows.Count == 0)
                        throw new Exception("Lista de bloqueios inexistente!");

                    MenuItem[] itensMenu = new MenuItem[dtBloqueios.Rows.Count + 1];
                    int contador = 0;

                    foreach (DataRow drLinha in dtBloqueios.Rows)
                    {
                        itensMenu[contador] = new MenuItem();
                        itensMenu[contador].Click += new EventHandler(MenuItem_Click);
                        itensMenu[contador].Text = drLinha["bloqueio"].ToString();
                        itensMenu[contador].Tag = Convert.ToInt32(drLinha["codigo"]);
                        itensMenu[contador].RadioCheck = true;
                        _menuGrid.MenuItems.Add(itensMenu[contador]);
                        contador++;
                    }

                    itensMenu[contador] = new MenuItem();
                    itensMenu[contador].Click += new EventHandler(MenuItem_Click);
                    itensMenu[contador].Text = "Todos";
                    itensMenu[contador].Tag = -1;
                    itensMenu[contador].RadioCheck = true;
                    itensMenu[contador].Checked = true;

                    _menuGrid.MenuItems.Add(itensMenu[contador]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
                }

                return _menuGrid;
            }
        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;

            if (item.RadioCheck)
                foreach (MenuItem i in menuGrid.MenuItems)
                    i.Checked = false;

            dg_Filtrados.DataSource = remessa.getResumoClientes((CarSystem.Tipos.bloqueiosDebito)item.Tag);
        }

        private void dg_Filtrados_MouseUp(object sender, MouseEventArgs e)
        {
            string nomeFuncao = "GeracaoRemessa.Bloqueios.dg_Filtrados_MouseUp";

            try
            {
                if (e.Button == MouseButtons.Right)
                    menuGrid.Show(dg_Filtrados, new Point(e.X, e.Y));

            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }    
        }

        private void txt_pedido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}