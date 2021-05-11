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
    public partial class SuperSolicit : Form
    {

        CarSystem.BancoDados.Dados _dados;
        CarSystem.SGB.Solicitacoes _oSolicitacoes;

        public CarSystem.SGB.Solicitacoes oSolicitacoes
        {
            get 
            {
                if (_oSolicitacoes == null)
                    _oSolicitacoes = new CarSystem.SGB.Solicitacoes(dados);

                return _oSolicitacoes; 
            }
            set { _oSolicitacoes = value; }
        }


        private CarSystem.BancoDados.Dados dados
        {
            get
            {
                string nomeFuncao = "geraBoletos.Boletos.empresa_CheckedChanged";

                try
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
                catch (Exception ex)
                {
                    throw new Exception("(" + nomeFuncao + ")" + ex.Message);
                }
            }
            set
            {
                _dados = value;
            }
        }

        public SuperSolicit()
        {
            InitializeComponent();
            dtpInicio.Value = DateTime.Today.AddDays(-5);
            dtpFim.Value = DateTime.Today;
        }

        private void carregaGrid()
        {
            int iIndexColuna = 0;

            gridSolicitacoes.DataSource = null;

            gridSolicitacoes.Columns.Clear();
            gridSolicitacoes.DataSource = oSolicitacoes.getSolicitacoesByDepartamento(0,dtpInicio.Value, dtpFim.Value);

            gridSolicitacoes.Columns["intstatus"].Visible = false;
            iIndexColuna = gridSolicitacoes.Columns.Add(new DataGridViewColumn(gridSolicitacoes.Rows[0].Cells[0]));
            gridSolicitacoes.Columns[iIndexColuna].Width = 30;
            gridSolicitacoes.Columns[iIndexColuna].DisplayIndex = 0;

            foreach (System.Windows.Forms.DataGridViewRow iLinhaGrid in gridSolicitacoes.Rows)
            {
                iLinhaGrid.Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                switch (Convert.ToInt32(iLinhaGrid.Cells["intstatus"].Value))
                {
                    case 0:
                        iLinhaGrid.Cells[iIndexColuna].Style.BackColor = Color.Yellow;
                        break;
                    case 1:
                        iLinhaGrid.Cells[iIndexColuna].Style.BackColor = Color.Red;
                        break;
                    case 2:
                        iLinhaGrid.Cells[iIndexColuna].Style.BackColor = Color.Green;
                        break;
                    case 3:
                        iLinhaGrid.Cells[iIndexColuna].Style.BackColor = Color.Yellow;
                        break;
                    case 4:
                        iLinhaGrid.Cells[iIndexColuna].Style.BackColor = Color.LightCoral;
                        break;
                }
            }
        }

        private void gridSolicitacoes_DataSourceChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            carregaGrid();
        }

        private void SuperSolicit_Load(object sender, EventArgs e)
        {
            listaDepartamento.DataSource = oSolicitacoes.getDepartamentos();
            listaDepartamento.ValueMember = "id_departamento";
            listaDepartamento.DisplayMember = "ds_departamento";

            carregaGrid();

            listaUsuario.DataSource = ((System.Data.DataTable)gridSolicitacoes.DataSource).DefaultView.ToTable(true, "solicitante");
            listaUsuario.ValueMember = "solicitante";


        }

        private void botaoOK_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            geracaoRemessa.Formulario.SolicitacoesSGB a = new geracaoRemessa.Formulario.SolicitacoesSGB(dados, "60640", 82214);
            a.Show();
       }
    }
}
