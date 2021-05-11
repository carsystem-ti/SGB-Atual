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
    public partial class acertoValores : Form
    {
        CarSystem.Remessas.Remessa _remessa;

        System.Data.DataTable tabelaAntiga;

        System.Drawing.Point _pontoCarregamento = new System.Drawing.Point(418, 46);
        System.Drawing.Point _pontoEscondido = new System.Drawing.Point(418, 335);

        delegate void setGridEnabled(DataGridView pGrid, bool pValor);
        delegate void setBotaoEnabled(Button pBotao, bool pValor);
        delegate void setPainelLocation(Panel pPainel, System.Drawing.Point pPonto);
        delegate void setBotaoGrid(DataTable pTabela);

        public CarSystem.Remessas.Remessa remessa
        {
            get { return _remessa; }
            set { _remessa = value; }
        }
        public CarSystem.BancoDados.Dados dados
        {
            get { return (CarSystem.BancoDados.Dados)remessa.dados; }
        }

        public acertoValores(CarSystem.Remessas.Remessa pRemessa)
        {
            InitializeComponent();
            remessa = pRemessa;
        }

        private void acertoValores_Load(object sender, EventArgs e)
        {
            carregaGrid(false);
        }
        public void carregaGrid(object pIsReProcessar)
        {
            carregaGrid((bool)pIsReProcessar);
            //gridClientes.Columns["valorCalculado"].CellTemplate
        }
        public void carregaGrid(bool pIsReProcessar)
        {
            string nomeFuncao = "SGB.AcertoValores.carregaGrid";

            try
            {
                setCarregaGrid(remessa.getClientes(pIsReProcessar, false));

                setGrid(gridClientes, true);
                setBotao(cmdReProcessar, true);
                setPainel(painelLoad, _pontoEscondido);
            }
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }

        }

        private void gridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            double iVelhoValor;
            double iNovoValor;
            string iContrato;
            string iProduto;

            double iValorAntigo;

            if (gridClientes.Columns[e.ColumnIndex].Name == "valorCalculado")
                gridClientes.BeginEdit(true);

            if (gridClientes.Columns[e.ColumnIndex].Name == "iBotaoValores")

                foreach (DataGridViewRow iLinhaGrid in gridClientes.Rows)
                {
                    if (Convert.ToBoolean(iLinhaGrid.Cells["isSelecionar"].Value))
                    {
                        iVelhoValor = Convert.ToDouble(iLinhaGrid.Cells["ultimoValor"].Value.ToString());
                        iNovoValor = Convert.ToDouble(iLinhaGrid.Cells["valorCalculado"].Value.ToString());
                        iContrato = iLinhaGrid.Cells["Contrato"].Value.ToString();
                        iProduto = iLinhaGrid.Cells["Produto"].Value.ToString();

                        iValorAntigo = Convert.ToDouble(tabelaAntiga.Rows[iLinhaGrid.Index]["valorCalculado"].ToString());

                        //if (iNovoValor < iValorAntigo)
                        //{
                        //    MessageBox.Show("Valor não pode ser menor que o valor de monitoramento do produto!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    gridClientes[e.ColumnIndex, e.RowIndex].Value = iValorAntigo;
                        //    return;
                        //}

                        //if (Convert.ToDouble(((DataTable)gridClientes.DataSource).Rows[e.RowIndex]["valorCalculado"].ToString()) == iNovoValor)
                        //return;

                        DialogResult iResultadoCaixa = MessageBox.Show("Alterar o valor de " + CarSystem.Utilidades.Formatar.formataReal(iVelhoValor) +
                            " para " + CarSystem.Utilidades.Formatar.formataReal(iNovoValor) + " do contrato " + iContrato + ", produto " +
                            iProduto + " ?", "Alterar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (iResultadoCaixa == DialogResult.Yes)
                            remessa.setNovoValor(iNovoValor, iContrato, false);
                        else if (iResultadoCaixa == DialogResult.Cancel)
                            break;
                    }
                }        
        }
    

        private void cmdReProcessar_Click(object sender, EventArgs e)
        {
            painelLoad.Location = _pontoCarregamento;
            gridClientes.Enabled = false;
            cmdReProcessar.Enabled = false;

            System.Threading.ParameterizedThreadStart parametroThread = new System.Threading.ParameterizedThreadStart(carregaGrid);
            System.Threading.Thread th_processo = new System.Threading.Thread(parametroThread);
            th_processo.Start(true);

        }

        private void setGrid(DataGridView pGrid, bool pValor)
        {
            string nomeFuncao = "SGB.AcertoValores.setEnabled";

            try
            {

                if (pGrid.InvokeRequired)
                {
                    setGridEnabled funcao = new setGridEnabled(setGrid);
                    this.Invoke(funcao, new object[] { pGrid, pValor });
                }
                else
                {
                    pGrid.Enabled = pValor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private void setBotao(Button pBotao, bool pValor)
        {
            string nomeFuncao = "SGB.AcertoValores.setEnabled";

            try
            {

                if (pBotao.InvokeRequired)
                {
                    setBotaoEnabled funcao = new setBotaoEnabled(setBotao);
                    this.Invoke(funcao, new object[] { pBotao, pValor });
                }
                else
                {
                    pBotao.Enabled = pValor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private void setPainel(Panel pPainel, System.Drawing.Point pPonto)
        {
            string nomeFuncao = "SGB.AcertoValores.setEnabled";

            try
            {

                if (pPainel.InvokeRequired)
                {
                    setPainelLocation funcao = new setPainelLocation(setPainel);
                    this.Invoke(funcao, new object[] { pPainel, pPonto });
                }
                else
                {
                    pPainel.Location = pPonto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
            }
        }
        private void setCarregaGrid(DataTable pTabela)
        {
            string nomeFuncao = "SGB.AcertoValores.setBotaoGrid";

            if (gridClientes.InvokeRequired)
            {
                setBotaoGrid funcao = new setBotaoGrid(setCarregaGrid);
                this.Invoke(funcao, new object[] { pTabela });
            }
            else
            {

                DataGridViewButtonColumn iBotao = new DataGridViewButtonColumn();

                try
                {
                    remessa.dados.Comandos.tempoLimite = 6000;
                    remessa.dados.Conexoes.tempoLimite = 6000;

                    gridClientes.DataSource = pTabela;
                    tabelaAntiga = pTabela.Copy();

                    if (!gridClientes.Columns.Contains("iBotaoValores"))
                    {
                        gridClientes.Columns.Add(iBotao);

                        gridClientes.Columns["Produto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        gridClientes.Columns["Contrato"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                        gridClientes.Columns["valorCalculado"].DefaultCellStyle.BackColor = Color.Yellow;

                        iBotao.HeaderText = "Atualizar";
                        iBotao.Text = "Atualizar";
                        iBotao.Name = "iBotaoValores";
                        iBotao.UseColumnTextForButtonValue = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("(" + nomeFuncao + ")" + ex.Message);
                }
            }
        }

        private void gridClientes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (gridClientes.Columns[e.ColumnIndex].Name != "valorCalculado" && gridClientes.Columns[e.ColumnIndex].Name != "isSelecionar")
                e.Cancel = true;
        }

        private void cmdLiberar_Click(object sender, EventArgs e)
        {
            if ( MessageBox.Show("Liberar Remessa?","Liberar",MessageBoxButtons.YesNo,MessageBoxIcon.Question) ==DialogResult.Yes )
            {
                cmdReProcessar_Click(null, null);

                if (gridClientes.Rows.Count > 2)
                    MessageBox.Show("Remessa não liberada, clientes com valores zerados!!", "Remessa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    remessa.setLiberaRemessa();
                    MessageBox.Show("Remessa liberada!!", "Remessa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridClientes_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow iLinhaGrid in gridClientes.Rows)
                iLinhaGrid.Cells["isSelecionar"].Value = !Convert.ToBoolean(iLinhaGrid.Cells["isSelecionar"].Value);
        }


    }
}

