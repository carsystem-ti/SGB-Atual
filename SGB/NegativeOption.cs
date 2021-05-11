using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGB {
    public partial class NegativeOption : Form {

        delegate void setPropertyCallBack ( object obj, string nomePropriedade, object valor );

        public NegativeOption ( ) {
            InitializeComponent( );
        }

        private void NegativeOption_Load ( object sender, EventArgs e ) {

        }

        private void button1_Click ( object sender, EventArgs e ) {

            if (MessageBox.Show( "Gerar arquivo do dia " + monthCalendar1.SelectionRange.Start.ToString( "dd/MM/yyyy" ) + " até " + monthCalendar2.SelectionRange.Start.ToString( "dd/MM/yyyy" ), "Gerar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 ) == System.Windows.Forms.DialogResult.No)
                return;


            Fury _fury = new Fury( );
            setProperty( this, "Cursor", System.Windows.Forms.Cursors.Default );

            string iDiretorio = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly( ).Location );
            string iPath = iDiretorio + "\\negativeOption_" + monthCalendar1.SelectionRange.Start.ToString( "ddMMyyyy" ) + "_ate_" + monthCalendar2.SelectionRange.Start.ToString( "ddMMyyyy" ) + ".txt";

            using (System.Data.DataTable iTabela = _fury.getTable( System.Data.CommandType.StoredProcedure
                , "Principal.eCommerce.pro_getArquivo"
                , new object[]  {
                                    new object[]{"@dataInicio", monthCalendar1.SelectionRange.Start},
                                    new object[]{"@dataFim ", monthCalendar2.SelectionRange.Start}
                                }
                )
            ) {
                iPath = CarSystem.Utilidades.IO.Arquivo.sqlTOtxt( iPath, iTabela );
            }

            CarSystem.Utilidades.IO.Arquivo.fechaArquivo( );
            label4.Text = iPath;
            MessageBox.Show( "Arquivo criado em:" + iPath );
            setProperty( this, "Cursor", System.Windows.Forms.Cursors.Default );
            
        }

        private void setProperty ( object obj, string nomePropriedade, object valor ) {
            setPropertyCallBack setProperty = new setPropertyCallBack( this.setProperty ); ;

            System.Reflection.PropertyInfo propriedade = obj.GetType( ).GetProperty( nomePropriedade );

            bool invoke = (bool)obj.GetType( ).GetProperty( "InvokeRequired" ).GetValue( obj, null );

            if (invoke)
                this.Invoke( setProperty, new Object[] { obj, nomePropriedade, valor } );
            else
                propriedade.SetValue( obj, valor, null );
        }

        private void button2_Click ( object sender, EventArgs e ) {
            /*
            if (MessageBox.Show( "Gerar arquivo do dia " + monthCalendar1.SelectionRange.Start.ToString( "dd/MM/yyyy" ) + " até " + monthCalendar2.SelectionRange.Start.ToString( "dd/MM/yyyy" ), "Gerar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 ) == System.Windows.Forms.DialogResult.No)
                return;
            

            Fury _fury = new Fury( );
            setProperty( this, "Cursor", System.Windows.Forms.Cursors.WaitCursor );

            //string iDiretorio = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly( ).Location );
            //string iPath = iDiretorio + "\\negativeOption_" + monthCalendar1.SelectionRange.Start.ToString( "ddMMyyyy" ) + "_ate_" + monthCalendar2.SelectionRange.Start.ToString( "ddMMyyyy" ) + ".txt";

            using (System.Data.DataTable iTabela = _fury.getTable( System.Data.CommandType.StoredProcedure
                , "Principal.eCommerce.pro_getArquivo"
                , new object[]  {
                                    new object[]{"@dataInicio", monthCalendar1.SelectionRange.Start},
                                    new object[]{"@dataFim ", monthCalendar2.SelectionRange.Start}
                                }
                )
            ) {
                iPath = CarSystem.Utilidades.IO.Arquivo.sqlTOtxt( iPath, iTabela );
            }

            CarSystem.Utilidades.IO.Arquivo.fechaArquivo( );
            //setProperty( this, "Cursor", System.Windows.Forms.Cursors.Default );
            MessageBox.Show( "Arquivo criado em:" + iPath );*/
        }
    }
}
