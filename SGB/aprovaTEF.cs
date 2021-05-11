using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Net;
using System.IO;

namespace SGB
{
    public partial class aprovaTEF : Form {
        public aprovaTEF ( ) {
            InitializeComponent ( );
        }

        public DateTime? iDataInicio = null;
        public DateTime? iDataFim = null;

        private void button1_Click ( object sender, EventArgs e ) {

        }

        private void aprovaTEF_Load ( object sender, EventArgs e ) {
            mcInicio.MaxDate = DateTime.Today;

            txtFim.Text = DateTime.Today.ToString ( "dd/MM/yyyy" ); ;
            txtInicio.Text = DateTime.Today.AddDays ( -3 ).ToString ( "dd/MM/yyyy" );

            carregaGrid ( );
        }

        private void carregaGrid (  ) {

            dgvDebitos.DataSource = getArquivos ( );

            foreach( DataGridViewColumn iColuna in dgvDebitos.Columns ) {

                iColuna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if( iColuna.Name.IndexOf ( "*" ) > -1 )
                    iColuna.Visible = false;
            }

            DataGridViewButtonColumn iBotao = new DataGridViewButtonColumn();

            if (!dgvDebitos.Columns.Contains("isEnviar"))
            {
                dgvDebitos.Columns.Add(iBotao);

                iBotao.HeaderText = "";
                iBotao.Text = "Enviar";
                iBotao.Name = "isEnviar";
                iBotao.UseColumnTextForButtonValue = true;
            }

        }

        private void dgvDebitos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvDebitos.Columns[e.ColumnIndex].Name != "valorCalculado")
                e.Cancel = true;       
        }
        
        private System.Data.DataTable getArquivos ( ) {
            try {
                using( System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection ( Fury.connection ) ) {
                    conn.Open ( );

                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SGB.Debito.pro_getListaArquivos", conn);

                    cmd.CommandTimeout = 160;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter ( cmd );
                    System.Data.DataTable iTabela = new System.Data.DataTable ( );
                    da.Fill ( iTabela );

                    return iTabela;
                }
            } catch( Exception ex ) {
                throw new Exception ( this.GetType ( ).Name + "\n" + System.Reflection.MethodBase.GetCurrentMethod ( ).Name, ex );
            }
        }

        private void btnProcessar_Click ( object sender, EventArgs e ) {

           
        }

        private void button1_Click_1 ( object sender, EventArgs e ) {

        }

        private void mcInicio_DateChanged ( object sender, DateRangeEventArgs e ) {

            DateTime iDataInicio = ((MonthCalendar)sender).SelectionStart;

            if( iDataInicio.Equals ( DateTime.Today ) ) {
                iDataInicio = DateTime.Today.AddDays ( -3 );
            }

            txtInicio.Text = iDataInicio.ToString ( "dd/MM/yyyy" );
            txtFim.Text = iDataInicio.AddDays ( 3 ).ToString ( "dd/MM/yyyy" );

            carregaGrid ( );
        }
        //Debito.pro_setEnvioArquivo( @pCodigoArquivo int, @pUsuario varchar(100))

        private void dgvDebitos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDebitos.Columns[e.ColumnIndex].Name != "isEnviar")
                return;

            setEnvio(Convert.ToInt32(dgvDebitos.Rows[e.RowIndex].Cells["Código"].Value)); ;
            carregaGrid();
        }

        private void setEnvio(int pCodigoArquivo)
        {
            try
            {

                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Fury.connection))
                {
                    conn.Open();

                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SGB.Debito.pro_setEnvioArquivo", conn);

                    cmd.CommandTimeout = 160;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pCodigoArquivo", pCodigoArquivo);
                    cmd.Parameters.AddWithValue("@pUsuario", Environment.UserName);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(this.GetType().Name + "\n" + System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}