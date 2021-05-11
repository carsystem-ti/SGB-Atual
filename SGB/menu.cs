using BoletoNet.Arquivo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGB {
    public partial class Menu : Form {
        BaixaTitulos.Baixa objBaixa;
       

        geracaoRemessa.Formulario.InformacoesRemessa formGeracao;
        tranfereQuitacao.transfPagamentos formTransferencia;
        geraBoletos.OperBoletos formOperBoletos;
        NegativeOption formNegativeOption;
        aprovaTEF formDA;
        adInad formAdInad;
        analiseRetorno formRetornoBradesco;

        BaixaSafra formSafra;
        CSTech formTechnology;

        

        SuperSolicit formSuperSolicit;

        public Menu ( ) {
            InitializeComponent ( );
        }

        private void button1_Click ( object sender, EventArgs e ) {
            if( objBaixa == null || objBaixa.IsDisposed ) {
                objBaixa = null;
                objBaixa = new BaixaTitulos.Baixa ( );
                objBaixa.Show ( );
            }

            objBaixa.Activate ( );
        }

        private void button2_Click ( object sender, EventArgs e ) {
            if( formGeracao == null || formGeracao.IsDisposed ) {
                formGeracao = null;
                formGeracao = new geracaoRemessa.Formulario.InformacoesRemessa ( );
                formGeracao.Show ( );
            }

            formGeracao.Activate ( );

        }

        private void button3_Click ( object sender, EventArgs e ) {
            if( formTransferencia == null || formTransferencia.IsDisposed ) {
                formTransferencia = null;
                formTransferencia = new tranfereQuitacao.transfPagamentos ( );
                formTransferencia.Show ( );
            }

            formTransferencia.Activate ( );

        }

        private void baixaTMK_Click ( object sender, EventArgs e ) {

        }
        /*cmdAtualizarAcordos_Click
		private void cmdAtualizarAcordos_Click( object sender, EventArgs e )
		{
			string nomeFuncao = "TMK.cmdAtualizarAcordos";

			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

				if ( MessageBox.Show( "Atualizar o status dos Acordos?", "Status TMK", MessageBoxButtons.YesNo ) == DialogResult.No )
					return;

				CarSystem.BancoDados.Dados sqlDados = new CarSystem.BancoDados.Dados();

				sqlDados.Conexoes.usuario = "usr_sgb";
				sqlDados.Conexoes.senha = "sgb_usr";
				sqlDados.Conexoes.bancoDados = "principal";
				sqlDados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;

				TMK tmk = new TMK( sqlDados );

				System.Data.DataTable tbStatusAcordo = tmk.getStatusDevedor();

				tmk.setStatusDevedor( tbStatusAcordo ); 

				this.Cursor = System.Windows.Forms.Cursors.Default;

				MessageBox.Show( tbStatusAcordo.Rows.Count.ToString() + " Acordos Atualizados!! ", "Processo Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information );

			}
			catch ( Exception ex )
			{
				MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
			}
        }
        */

        private void cmdOperBoletos_Click ( object sender, EventArgs e ) {
            if( formOperBoletos == null || formOperBoletos.IsDisposed ) {
                formOperBoletos = null;
                formOperBoletos = new geraBoletos.OperBoletos ( );
                formOperBoletos.Show ( );

                formSuperSolicit = new SuperSolicit ( );
                formSuperSolicit.Show ( );

            }

            formOperBoletos.Activate ( );
        }

        private void button4_Click ( object sender, EventArgs e ) {
            if( formNegativeOption == null || formNegativeOption.IsDisposed ) {
                formNegativeOption = null;
                formNegativeOption = new NegativeOption( );
                formNegativeOption.Show ( );
            }

            formNegativeOption.Activate ( );
        }

        private void cmdSair_Click ( object sender, EventArgs e ) {
            Application.Exit ( );
        }

        private void cmdDA_Click(object sender, EventArgs e)
        {

            if (formDA == null || formDA.IsDisposed)
            {
                formDA = null;
                formDA = new aprovaTEF();
                formDA.Show();
            }

            formDA.Activate();
        }

        private void cmdRetornoBradesco_Click ( object sender, EventArgs e ) {
            if( formRetornoBradesco == null || formRetornoBradesco.IsDisposed ) {
                formRetornoBradesco = null;
                formRetornoBradesco = new analiseRetorno ( );
                formRetornoBradesco.Show ( );
            }

            formRetornoBradesco.Activate ( );
        }

        private void cmdAdInad_Click ( object sender, EventArgs e ) {
            if( formAdInad == null || formAdInad.IsDisposed ) {
                formAdInad = null;
                formAdInad = new adInad ( );
                formAdInad.Show ( );
            }

            formAdInad.Activate ( );
        }

        private void cmdTechnology_Click ( object sender, EventArgs e ) {
            if( formTechnology == null || formTechnology.IsDisposed ) {
                formTechnology = null;
                formTechnology = new CSTech ( );
                formTechnology.Show ( );
            }

            formTechnology.Activate ( );

        }

       private void btnSafra_Click(object sender, EventArgs e)
        {
            if (formSafra == null || formSafra.IsDisposed)
            {
                formSafra = null;
                formSafra = new BaixaSafra();
                formSafra.Show();
             
            }
            formSafra.Activate();
        }

       
    }
}



