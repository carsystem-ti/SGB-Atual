using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tranfereQuitacao
{
    public partial class transfPagamentos : Form
    {
        CarSystem.BancoDados.Dados _dados;
        CarSystem.Debitos.Debito _debitos;
        
		CarSystem.Tipos.Servidores servidor = CarSystem.Tipos.Servidores.Fury;

        DataGridViewCell _celula;

        public transfPagamentos()
        {
             string nomeFuncao = "tranfereQuitacao.transfPagamentos(construtor)";

             try
             {
                 InitializeComponent();
                 cbEmpresa.SelectedIndex = 0;
                 configuraGrid();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("(" + nomeFuncao + ")" + ex.Message, "Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
             }

        }
        public transfPagamentos(CarSystem.BancoDados.Dados dados): base()
        {
            this.dados = dados;
        }

        #region PROPRIEDADES

        public CarSystem.BancoDados.Dados dados
        {
            get 
            {
                if (_dados == null)
                    _dados = new CarSystem.BancoDados.Dados("SGB", servidor, "usr_sgb", "sgb_usr");

                return _dados; 
            }
            set 
            { 
                _dados = value; 
            }
        }
        public CarSystem.Debitos.Debito debitos
        {
            get 
            {
                if (_debitos == null)
                    _debitos = new CarSystem.Debitos.Debito(CarSystem.Tipos.tipoEmissao.Producao, dados);

                return _debitos; 
            }
            set 
            { 
                _debitos = value; 
            }
        }

        #endregion 

        private void configuraGrid()
        {
            string nomeFuncao = "tranfereQuitacao.transfPagamentos.configuraGrid";

            try
            {
                gridParcelas.Columns.Clear();
                gridParcelas.Rows.Clear();
                
                gridParcelas.Columns.Add("pedidoDe", "Pedido De");
                gridParcelas.Rows.Add(1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private System.Windows.Forms.DataGridViewComboBoxCell comboGridCelula(string contrato, CarSystem.Tipos.statusDebito statusDebito)
        {
            string nomeFuncao = "tranfereQuitacao.transfPagamentos.comboGridCelula";

            System.Windows.Forms.DataGridViewComboBoxCell cbCelula = new DataGridViewComboBoxCell();            

            try
            {
                string coluna;

                if ( statusDebito == CarSystem.Tipos.statusDebito.naoPagos )
                    coluna = "pedidoPara";
                else
                    coluna = "pedidoDe";

                foreach (DataGridViewRow iLinhaGrid in gridParcelas.Rows)
                {
                    if (iLinhaGrid.Cells[coluna].ToString() == contrato)
                    {
                        cbCelula.DataSource = ((DataTable)((DataGridViewComboBoxCell)_celula).DataSource).Copy();
                        break;
                    }
                }

                debitos.dados = dados;

                if ( cbCelula.DataSource == null )
                    cbCelula.DataSource = debitos.tbDebitos(contrato,statusDebito).Copy();

                cbCelula.ValueMember = "identificadorDebito";
                cbCelula.DisplayMember = "vencimento";

                return cbCelula;
            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private void gridParcelas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nomeFuncao = "tranfereQuitacao.transfPagamentos.gridParcelas_CellEndEdit";

            try
            {
                _celula = gridParcelas[e.ColumnIndex, e.RowIndex];

                escondeLista();

                if (gridParcelas[e.ColumnIndex, e.RowIndex].Value == null)
                    return;

                DataGridViewComboBoxCell cbCelula;

                switch (gridParcelas.Columns[e.ColumnIndex].Name)
                {
                    case "pedidoDe":

                        if (!gridParcelas.Columns.Contains("parcelaDe"))
                            gridParcelas.Columns.Add("parcelaDe", "Parcela De");

                        cbCelula = comboGridCelula(gridParcelas[e.ColumnIndex, e.RowIndex].Value.ToString(), CarSystem.Tipos.statusDebito.quitado);
                        cbCelula.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

                        gridParcelas["parcelaDe", e.RowIndex] = cbCelula;

                        if (!gridParcelas.Columns.Contains("pedidoPara"))
                            gridParcelas.Columns.Add("pedidoPara", "Pedido Para");

                        gridParcelas["pedidoDe", e.RowIndex].Selected = true;

                        break;
                    case "pedidoPara":

                        if (!gridParcelas.Columns.Contains("parcelaPara"))
                            gridParcelas.Columns.Add("parcelaPara", "Parcela Para");

                        cbCelula = comboGridCelula(gridParcelas[e.ColumnIndex, e.RowIndex].Value.ToString(), CarSystem.Tipos.statusDebito.naoPagos);
                        cbCelula.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

                        gridParcelas["parcelaPara", e.RowIndex] = cbCelula;

                        if (!gridParcelas.Columns.Contains("acao"))
                            gridParcelas.Columns.Add(CarSystem.Utilidades.Componentes.Grid.comboGridColuna(new string[] { "Transferir", "Copiar","Cancelar" }, "Ação", "acao"));

                        gridParcelas["acao", e.RowIndex].Value = "Transferir";

                        gridParcelas["pedidoPara", e.RowIndex].Selected = true;

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message, "Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void gridParcelas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            string nomeFuncao = "tranfereQuitacao.transfPagamentos.gridParcelas_CellBeginEdit";

            try
            {
                _celula = gridParcelas[e.ColumnIndex, e.RowIndex];

                escondeLista();

                if (e.ColumnIndex != 1 && e.ColumnIndex != 3)
                    return;

                DataTable tbTabela = ((DataTable)((DataGridViewComboBoxCell)gridParcelas[e.ColumnIndex, e.RowIndex]).DataSource).Copy();

                tbTabela.Columns.Remove("contratoDebito");
                tbTabela.Columns.Remove("numeroDocumento");
                tbTabela.Columns.Remove("nossoNumero");
                tbTabela.Columns.Remove("codigoRemessa");
                tbTabela.Columns.Remove("codigoBanco");

                adicionaItens(tbTabela);

                lvParcelas.Top = gridParcelas.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Bottom + 13;
                lvParcelas.Left = gridParcelas.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Left + 11;
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message, "Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void escondeLista()
        {
            escondeLista(false);
        }
        private void escondeLista(bool isOverride)
        {
            string nomeFuncao = "tranfereQuitacao.transfPagamentos.escondeLista";

            try
            {
                if (isOverride && (_celula.ColumnIndex == 1 || _celula.ColumnIndex == 3))
                    return;

                lvParcelas.Top = -lvParcelas.Height;
                lvParcelas.Left = -lvParcelas.Width;
            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private void adicionaItens(DataTable dtItens)
        {
            string nomeFuncao = "tranfereQuitacao.transfPagamentos.adicionaItens";

            try
            {
                string conteudo;

                lvParcelas.Items.Clear();
                lvParcelas.Columns.Clear();

                foreach (System.Data.DataRow drLinha in dtItens.Rows)
                {
                    System.Windows.Forms.ListViewItem itemLv = new System.Windows.Forms.ListViewItem();

                    itemLv.SubItems.Clear();

                    for (int contador = 0; contador < dtItens.Columns.Count; contador++)
                    {
                        conteudo = drLinha[contador].ToString();

                        switch (dtItens.Columns[contador].ColumnName)
                        {
                            case "valorDebito":

                                if (!lvParcelas.Columns.ContainsKey("Valor"))
                                    lvParcelas.Columns.Add("Valor", "Valor", 75);

                                conteudo = Convert.ToDouble(conteudo).ToString("C");
                                break;

                            case "vencimento":

                                if (!lvParcelas.Columns.ContainsKey("Vencimento"))
                                    lvParcelas.Columns.Add("Vencimento", "Vencimento", 75);

                                conteudo = Convert.ToDateTime(conteudo).ToString("dd/MM/yyyy");
                                break;

                            case "statusDebito":

                                if (!lvParcelas.Columns.ContainsKey("Status"))
                                    lvParcelas.Columns.Add("Status", "Status", 75);

                                conteudo = ((CarSystem.Tipos.statusDebito)Convert.ToInt32(conteudo)).ToString().ToUpper();
                                break;
                            case "identificadorDebito":

                                if (!lvParcelas.Columns.ContainsKey("identificadorDebito"))
                                    lvParcelas.Columns.Add("identificadorDebito", "identificadorDebito", 1);

                                break;
                            case "codigoDebito":

                                if (!lvParcelas.Columns.ContainsKey("Código"))
                                    lvParcelas.Columns.Add("Código", "Código", 40);
                                break;

                        }

                        if (contador == 0)
                            itemLv.SubItems[contador].Text = conteudo;
                        else
                            itemLv.SubItems.Add(conteudo);
                    }

                    lvParcelas.Items.Add(itemLv);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private void lvParcelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomeFuncao = "tranfereQuitacao.transfPagamentos.lvParcelas_SelectedIndexChanged";

             try
             {
                 DataGridViewComboBoxCell comboCelula = (DataGridViewComboBoxCell)gridParcelas[_celula.ColumnIndex, _celula.RowIndex];

                 if (lvParcelas.SelectedItems.Count <= 0)
                     return;

                 Object formattedValue;
                 DataGridViewCellStyle cellStyle;

                 formattedValue = lvParcelas.SelectedItems[0].SubItems[0].Text;
                 cellStyle = comboCelula.Style;

                 comboCelula.Value = comboCelula.ParseFormattedValue(formattedValue, cellStyle, null, null);

                 foreach (DataGridViewRow iLinhaGrid in gridParcelas.Rows)
                 {
                     if (iLinhaGrid.Cells[_celula.ColumnIndex].Value != null && iLinhaGrid.Cells[_celula.ColumnIndex].Value.ToString() == comboCelula.Value.ToString()
                         && iLinhaGrid.Index != comboCelula.RowIndex)
                     {
                         comboCelula.Value = null;
                         throw new Exception("Esta parcela já foi escolhida!");
                     }
                 }

                 escondeLista(true);
             }
             catch (Exception ex)
             {
                 MessageBox.Show("(" + nomeFuncao + ")" + ex.Message, "Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
             }
        }
        private void gridParcelas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }
        private void cmdTransfer_Click(object sender, EventArgs e)
        {
            string nomeFuncao = "tranfereQuitacao.transfPagamentos.cmdTransfer_Click";

            try
            {
                DialogResult resultMsg;

                resultMsg = MessageBox.Show("Efetuar transferências?", "Transferir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultMsg == DialogResult.No)
                    return;

                DataGridViewComboBoxCell comboCelula;
                System.Data.SqlClient.SqlTransaction tranTranferPagtos;

                dados.Comandos.textoComando = "sgb..pro_SGB_setTransferenciaPagamento";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                foreach (DataGridViewRow iLinhaGrid in gridParcelas.Rows)
                {
                    if (iLinhaGrid.Cells["PedidoDe"].Value == null || !validacoes(iLinhaGrid.Index))
                        continue;

                    tranTranferPagtos = dados.Conexoes.conexao.BeginTransaction(IsolationLevel.RepeatableRead, "tranTranferPgtos");
                    dados.Comandos.comando.Transaction = tranTranferPagtos;

                    dados.Comandos.limpaParametros();

                    comboCelula = (DataGridViewComboBoxCell)iLinhaGrid.Cells["parcelaDe"];
                    dados.Comandos.adicionaParametro("@codigoDE", SqlDbType.BigInt, 8, Convert.ToInt64(comboCelula.Value));

                    comboCelula = (DataGridViewComboBoxCell)iLinhaGrid.Cells["parcelaPara"];
                    dados.Comandos.adicionaParametro("@codigoPARA", SqlDbType.BigInt, 8, Convert.ToInt64(comboCelula.Value));

                    if (iLinhaGrid.Cells["acao"].Value.ToString() == "Copiar")
                    {
                        dados.Comandos.adicionaParametro("@contratoDe", SqlDbType.VarChar, 10, iLinhaGrid.Cells["PedidoDe"].Value.ToString());
                        dados.Comandos.adicionaParametro("@contratoPara", SqlDbType.VarChar, 10, iLinhaGrid.Cells["PedidoPara"].Value.ToString());
                    }

                    dados.retornaDados = false;

                    dados.execute();

                    if (dados.linhasAfetadas != 3 && dados.linhasAfetadas != 2)
                        tranTranferPagtos.Rollback();
                    else
                        tranTranferPagtos.Commit();

                    comboCelula = null;
                }

                configuraGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }

        }
        private bool validacoes(int linha)
        {
            string nomeFuncao = "tranfereQuitacao.transfPagamentos.validacoes";

            try
            {

                DataTable tbTabela;

                try
                {
                    if (!gridParcelas.Columns.Contains("pedidoDe") || !gridParcelas.Columns.Contains("parcelaDe"))
                        throw new Exception("");

                    tbTabela = ((DataTable)((DataGridViewComboBoxCell)gridParcelas["parcelaDe", linha]).DataSource);
                }
                catch
                {
                    throw new Exception("Os dados de origem são inválidos");
                }

                if (tbTabela == null || tbTabela.Rows.Count <= 0 || ((DataGridViewComboBoxCell)gridParcelas["parcelaDe", linha]).Value == null)
                    throw new Exception("Não existem parcela(s) de origem");

                tbTabela = null;

                try
                {

                    if (!gridParcelas.Columns.Contains("pedidoPara") || !gridParcelas.Columns.Contains("parcelaPara"))
                        throw new Exception("Os dados de destino são inválidos");

                    tbTabela = ((DataTable)((DataGridViewComboBoxCell)gridParcelas["parcelaPara", linha]).DataSource);
                }
                catch
                {
                    throw new Exception("Os dados de origem são inválidos");
                }

                if ( (tbTabela == null || tbTabela.Rows.Count <= 0 || ((DataGridViewComboBoxCell)gridParcelas["parcelaPara", linha]).Value == null ) &&
                    gridParcelas["acao", linha].Value.ToString() != "Copiar")
                    throw new Exception("Não existem parcela(s) de destino");

                tbTabela = null;

                if (gridParcelas["acao", linha].Value == null || ( gridParcelas["acao", linha].Value.ToString() != "Transferir" &&
                    gridParcelas["acao", linha].Value.ToString() != "Copiar") )
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }
        }

        private void gridParcelas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbEmpresa_TextChanged(object sender, EventArgs e)
        {
            dados = null;

            switch (cbEmpresa.Text)
            {
                case "CarSystem":
                    servidor = CarSystem.Tipos.Servidores.Fury;
                    break;
                case "SatNet":
                    servidor = CarSystem.Tipos.Servidores.SatNetServer;
                    break;
            }
        }

    }
}
