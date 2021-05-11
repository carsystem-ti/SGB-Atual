using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SGB {
    public partial class DebitoAutomatico : Form {
        CarSystem.BancoDados.Dados dados = new CarSystem.BancoDados.Dados( "SGB" , CarSystem.Tipos.Servidores.Fury , "usr_sgb" , "sgb_usr" );
        aprovaTEF formTEF;

        public DebitoAutomatico ( ) {
            DateTime iDataCalculada;
            iDataCalculada = DateTime.Today.AddDays( -( DateTime.Today.Day - 1 ) ).AddMonths( 1 ).AddDays( -1 );
            InitializeComponent( );

            optEnviarNovamente.Checked = true;
            optCancelarCadastro.Enabled = false;
            optCadastrarContrato.Enabled = false;

            txtDiretorio.Text = diretorioDA( "" );
            mcInicio.TodayDate = DateTime.Today.AddDays( -( DateTime.Today.Day - 1 ) );
            mcInicio.SetDate( mcInicio.TodayDate );

            //mcFim.TodayDate = iDataCalculada;
            //mcFim.SetDate(mcFim.TodayDate);

            dados.Comandos.limpaParametros( );
            dados.Comandos.textoComando = "select Principal.Debito.fun_getValorIGPM(0)";
            dados.Comandos.tipoComando = CommandType.Text;

        }

        private void cmdGeraArquivo_Click ( object sender, EventArgs e ) {

            txtDiretorio.Text = diretorioDA ( "" );

            if( checkBradesco.Checked ) {
                CarSystem.Banco.Bradesco.Funcoes iDaBradesco;
                iDaBradesco = new CarSystem.Banco.Bradesco.Funcoes( dados , "237" , true , false );
                txtArquivo.Text = iDaBradesco.getArquivo ( mcInicio.SelectionStart, mcInicio.SelectionStart, txtDiretorio.Text );
            } else if( checkHSBC.Checked ) {
                CarSystem.Banco.HSBC.Funcoes iDaHSBC;
                iDaHSBC = new CarSystem.Banco.HSBC.Funcoes ( dados, "399", true );
                txtArquivo.Text = iDaHSBC.getArquivo ( txtDiretorio.Text, "DA_399_" + mcInicio.SelectionStart.ToString ( "ddMMyyyy" ), "", CarSystem.Banco.HSBC.Remessa.RegistroE.codigosMovimento.debitoNormal, mcInicio.SelectionStart );

            } else if( checkSantander.Checked ) {
                string iArquivoGerado = "";
                CarSystem.Banco.Febraban.Funcoes iDaSantander;
                iDaSantander = new CarSystem.Banco.Febraban.Funcoes ( dados, "033", true );

                txtArquivo.Text = iDaSantander.getArquivo ( txtDiretorio.Text, "DA_353_" + mcInicio.SelectionStart.ToString ( "ddMMyyyy" ), "", CarSystem.Banco.Febraban.Registros.eDebito.codigosMovimento.debitoNormal, mcInicio.SelectionStart );
                iArquivoGerado = iDaSantander.getArquivoContas ( txtDiretorio.Text, "CC_353_" + mcInicio.SelectionStart.ToString ( "ddMMyyyy" ) );

                MessageBox.Show ( "O arquivo de cadastro\\exclusão de contas foi gerado em:\r\n" +
                    iArquivoGerado + "!!", "Santader", MessageBoxButtons.OK, MessageBoxIcon.Information );
            } else if( checkItau.Checked ) {
                CarSystem.Banco.Itau.Funcoes iDaItau;
                iDaItau = new CarSystem.Banco.Itau.Funcoes ( dados, "341", true );

                txtArquivo.Text = iDaItau.getArquivo ( txtDiretorio.Text, "DA_341_" + mcInicio.SelectionStart.ToString ( "ddMMyyyy" ), "", CarSystem.Banco.Itau.Remessa.RegistroDetalhe.TipoOperacao.inclusaoDebito, mcInicio.SelectionStart );

                MessageBox.Show ( "O arquivo de cadastro\\exclusão de contas foi gerado em:\r\n" +
                    txtArquivo.Text + "!!", "Itau", MessageBoxButtons.OK, MessageBoxIcon.Information );
            } else if( checkCielo.Checked ) {

                DateTime iDataInicio = mcInicio.SelectionStart.AddDays ( -( mcInicio.SelectionStart.Day - 1 ) );
                DateTime iDataFim = iDataInicio.AddMonths ( 1 ).AddDays ( -1 );

                if( formTEF == null || formTEF.IsDisposed ) {
                    formTEF = null;
                    formTEF = new aprovaTEF ( );
                    formTEF.Show ( );
                }

                formTEF.Activate ( );

                /*

                CarSystem.Banco.Cielo.Funcoes iDaCielo;
                iDaCielo = new CarSystem.Banco.Cielo.Funcoes( dados , "CIE" , true );

                txtArquivo.Text = iDaCielo.getArquivo( "" , "V" , iDataInicio , iDataFim , txtDiretorio.Text , "daCielo" );
                */
            }

            if( !checkCielo.Checked )
                MessageBox.Show ( "Operação Concluída!!" );
        }

        private void envioContratoCielo ( ) {
            string iNomeArquivo;
            string iIdentificadorArquivo = "";

            txtDiretorio.Text = @"E:\Baixas bancárias\Débito automático\CIELO\Cancelamento - Reenvio";

            if ( optCancelarDebito.Checked )
                iIdentificadorArquivo = "C";
            else {
                MessageBox.Show( "Apenas Cancelamento pode ser selecionado para a Cielo!" , "Atenção" , MessageBoxButtons.OK , MessageBoxIcon.Stop );
                return;
            }

            iNomeArquivo = textContrato.Text.TrimEnd( );
            iNomeArquivo = iNomeArquivo.TrimStart( );
            iNomeArquivo += " - " + iIdentificadorArquivo;

            CarSystem.Banco.Cielo.Funcoes iDaCielo = new CarSystem.Banco.Cielo.Funcoes( dados , "CIE" , true );
            txtArquivo.Text = iDaCielo.getArquivo( textContrato.Text.TrimEnd( ) , "P" , mcInicio.SelectionStart , mcInicio.SelectionStart , txtDiretorio.Text , iNomeArquivo );

            MessageBox.Show( txtArquivo.Text );
        }

        private void envioContratoSantanderF ( ) {
            string iNomeArquivo;
            string iIdentificadorArquivo = "";
            CarSystem.Banco.Febraban.Registros.eDebito.codigosMovimento iCodigoMovimento = CarSystem.Banco.Febraban.Registros.eDebito.codigosMovimento.debitoNormal;
            CarSystem.Banco.Febraban.Funcoes iSantander;

            txtDiretorio.Text = @"E:\Baixas bancárias\Débito automático\Santander\Cancelamento - Reenvio";

            if ( optCancelarDebito.Checked ) {
                iCodigoMovimento = CarSystem.Banco.Febraban.Registros.eDebito.codigosMovimento.cancelamentoDebito;
                iIdentificadorArquivo = "C";
            } else if ( optEnviarNovamente.Checked ) {
                iCodigoMovimento = CarSystem.Banco.Febraban.Registros.eDebito.codigosMovimento.debitoNormal;
                iIdentificadorArquivo = "R";
            } else if ( optCancelarCadastro.Checked ) {
                iSantander = new CarSystem.Banco.Febraban.Funcoes( dados , "353" , false );

                if ( iSantander.setContaCadastro( textContrato.Text , CarSystem.Banco.Febraban.Registros.bCadastramento.CodigoMovimento.exclusao ) )
                    MessageBox.Show( "Cliente marcado para exclusão do débito automático!!" , "Santader" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                else
                    MessageBox.Show( "PROCEDIMENTO NÃO CONCLUÍDO!!" , "Santader" , MessageBoxButtons.OK , MessageBoxIcon.Error );

                return;
            } else if ( optCadastrarContrato.Checked ) {
                iSantander = new CarSystem.Banco.Febraban.Funcoes( dados , "353" , false );
                if ( iSantander.setContaCadastro( textContrato.Text , CarSystem.Banco.Febraban.Registros.bCadastramento.CodigoMovimento.inclusao ) )
                    MessageBox.Show( "Cliente marcado para cadastro do débito automático!!" , "Santader" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                else
                    MessageBox.Show( "PROCEDIMENTO NÃO CONCLUÍDO!!" , "Santader" , MessageBoxButtons.OK , MessageBoxIcon.Error );

                return;
            } else
                MessageBox.Show( "Uma opção deve ser selecionada!!" );

            iNomeArquivo = textContrato.Text.TrimEnd( );
            iNomeArquivo = iNomeArquivo.TrimStart( );
            iNomeArquivo += " - " + iIdentificadorArquivo;

            iSantander = new CarSystem.Banco.Febraban.Funcoes( dados , "353" , true );
            txtArquivo.Text = iSantander.getArquivo( txtDiretorio.Text , iNomeArquivo , textContrato.Text , iCodigoMovimento , DateTime.Today.AddDays( -1 ) );

        }


        private void envioContratoSantander ( ) {
            string iNomeArquivo;
            string iIdentificadorArquivo = "";
            CarSystem.Banco.Santander.Remessa.RegistroE.codigosMovimento iCodigoMovimento = CarSystem.Banco.Santander.Remessa.RegistroE.codigosMovimento.debitoNormal;
            CarSystem.Banco.Santander.Funcoes iSantander;

            txtDiretorio.Text = @"E:\Baixas bancárias\Débito automático\Santander\Cancelamento - Reenvio";

            if ( optCancelarDebito.Checked ) {
                iCodigoMovimento = CarSystem.Banco.Santander.Remessa.RegistroE.codigosMovimento.cancelamentoDebito;
                iIdentificadorArquivo = "C";
            } else if ( optEnviarNovamente.Checked ) {
                iCodigoMovimento = CarSystem.Banco.Santander.Remessa.RegistroE.codigosMovimento.debitoNormal;
                iIdentificadorArquivo = "R";
            } else if ( optCancelarCadastro.Checked ) {
                iSantander = new CarSystem.Banco.Santander.Funcoes( dados , "353" , false );

                if ( iSantander.setContaCadastro( textContrato.Text , CarSystem.Banco.Santander.Remessa.RegistroB.CodigoMovimento.exclusao ) )
                    MessageBox.Show( "Cliente marcado para exclusão do débito automático!!" , "Santader" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                else
                    MessageBox.Show( "PROCEDIMENTO NÃO CONCLUÍDO!!" , "Santader" , MessageBoxButtons.OK , MessageBoxIcon.Error );

                return;
            } else if ( optCadastrarContrato.Checked ) {
                iSantander = new CarSystem.Banco.Santander.Funcoes( dados , "353" , false );
                if ( iSantander.setContaCadastro( textContrato.Text , CarSystem.Banco.Santander.Remessa.RegistroB.CodigoMovimento.inclusao ) )
                    MessageBox.Show( "Cliente marcado para cadastro do débito automático!!" , "Santader" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                else
                    MessageBox.Show( "PROCEDIMENTO NÃO CONCLUÍDO!!" , "Santader" , MessageBoxButtons.OK , MessageBoxIcon.Error );

                return;
            } else
                MessageBox.Show( "Uma opção deve ser selecionada!!" );

            iNomeArquivo = textContrato.Text.TrimEnd( );
            iNomeArquivo = iNomeArquivo.TrimStart( );
            iNomeArquivo += " - " + iIdentificadorArquivo;

            iSantander = new CarSystem.Banco.Santander.Funcoes( dados , "353" , true );
            txtArquivo.Text = iSantander.getArquivo( txtDiretorio.Text , iNomeArquivo , textContrato.Text , iCodigoMovimento , DateTime.Today.AddDays( -1 ) );

        }
        private void envioContratoItau ( ) {
            string iNomeArquivo;
            string iIdentificadorArquivo = "";
            CarSystem.Banco.Itau.Remessa.RegistroDetalhe.TipoOperacao iCodigoMovimento = CarSystem.Banco.Itau.Remessa.RegistroDetalhe.TipoOperacao.inclusaoDebito;
            CarSystem.Banco.Itau.Funcoes iItau;

            txtDiretorio.Text = @"E:\Baixas bancárias\Débito automático\Itau\Cancelamento - Reenvio";

            if ( optCancelarDebito.Checked ) {
                iCodigoMovimento = CarSystem.Banco.Itau.Remessa.RegistroDetalhe.TipoOperacao.cancelamentoDebito;
                iIdentificadorArquivo = "C";
            } else if ( optEnviarNovamente.Checked ) {
                iCodigoMovimento = CarSystem.Banco.Itau.Remessa.RegistroDetalhe.TipoOperacao.inclusaoDebito;
                iIdentificadorArquivo = "R";
            } else
                MessageBox.Show( "Uma opção deve ser selecionada!!" );

            iNomeArquivo = textContrato.Text.TrimEnd( );
            iNomeArquivo = iNomeArquivo.TrimStart( );
            iNomeArquivo += " - " + iIdentificadorArquivo;

            iItau = new CarSystem.Banco.Itau.Funcoes( dados , "341" , true );
            txtArquivo.Text = iItau.getArquivo( txtDiretorio.Text , iNomeArquivo , textContrato.Text , iCodigoMovimento , DateTime.Today.AddDays( -1 ) );

        }

        private void envioContratoHSBC ( ) {
            string iNomeArquivo;
            string iIdentificadorArquivo = "";
            CarSystem.Banco.HSBC.Remessa.RegistroE.codigosMovimento iCodigoMovimento = CarSystem.Banco.HSBC.Remessa.RegistroE.codigosMovimento.debitoNormal;

            txtDiretorio.Text = @"E:\Baixas bancárias\Débito automático\HSBC\Cancelamento - Reenvio";

            if ( optAlterarVencimento.Checked )
                iIdentificadorArquivo = "V";
            else if ( optCancelarDebito.Checked ) {
                iCodigoMovimento = CarSystem.Banco.HSBC.Remessa.RegistroE.codigosMovimento.cancelamentoDebito;
                iIdentificadorArquivo = "C";
            } else if ( optEnviarNovamente.Checked )
                iIdentificadorArquivo = "N";
            else
                MessageBox.Show( "Uma opção deve ser selecionada!!" );

            iNomeArquivo = textContrato.Text.TrimEnd( );
            iNomeArquivo = iNomeArquivo.TrimStart( );
            iNomeArquivo += " - " + iIdentificadorArquivo;

            CarSystem.Banco.HSBC.Funcoes iDA = new CarSystem.Banco.HSBC.Funcoes( dados , "399" , true );
            txtArquivo.Text = iDA.getArquivo( txtDiretorio.Text , iNomeArquivo , textContrato.Text , iCodigoMovimento , DateTime.Today.AddDays( -1 ) );

        }
        private void envioContratoBradesco ( ) {
            string iNomeArquivo;
            CarSystem.Banco.Bradesco.Remessa.Registro1.CodigosOcorrencia iTipoOcorrencia = CarSystem.Banco.Bradesco.Remessa.Registro1.CodigosOcorrencia.remessa;
            CarSystem.Banco.Bradesco.Funcoes.tipoEnvioDA iTipoEnvioDA = CarSystem.Banco.Bradesco.Funcoes.tipoEnvioDA.Reenvio; ;

            txtDiretorio.Text = @"E:\Baixas bancárias\Débito automático\Bradesco\Cancelamento - Reenvio";

            if ( optAlterarVencimento.Checked ) {
                iTipoOcorrencia = CarSystem.Banco.Bradesco.Remessa.Registro1.CodigosOcorrencia.alteracaoVencimento;
                iTipoEnvioDA = CarSystem.Banco.Bradesco.Funcoes.tipoEnvioDA.Vencimento;
            } else if ( optCancelarDebito.Checked ) {
                iTipoOcorrencia = CarSystem.Banco.Bradesco.Remessa.Registro1.CodigosOcorrencia.pedidoBaixa;
                iTipoEnvioDA = CarSystem.Banco.Bradesco.Funcoes.tipoEnvioDA.Cancelamento;
            } else if ( optEnviarNovamente.Checked ) {
                iTipoOcorrencia = CarSystem.Banco.Bradesco.Remessa.Registro1.CodigosOcorrencia.remessa;
                iTipoEnvioDA = CarSystem.Banco.Bradesco.Funcoes.tipoEnvioDA.Reenvio;
            } else {
                MessageBox.Show( "Uma opção deve ser selecionada!!" );
            }

            iNomeArquivo = textContrato.Text.TrimEnd( );
            iNomeArquivo = iNomeArquivo.TrimStart( );
            iNomeArquivo += " - " + iTipoEnvioDA.ToString( ).Substring( 0 , 1 );

            CarSystem.Banco.Bradesco.Funcoes iDA = new CarSystem.Banco.Bradesco.Funcoes( dados , "237" , true , false );
            txtArquivo.Text = iDA.getArquivo( txtDiretorio.Text , iNomeArquivo , textContrato.Text , iTipoOcorrencia , iTipoEnvioDA );

        }
        private void envioContrato ( object sender , EventArgs e ) {
            cmdLiberarDA.Text = "Aguarde";

            if ( checkBradesco.Checked == true )
                envioContratoBradesco( );
            else if ( checkHSBC.Checked == true )
                envioContratoHSBC( );
            else if ( checkSantander.Checked )
                envioContratoSantanderF( );
            else if ( checkItau.Checked )
                envioContratoItau( );
            else if ( checkCielo.Checked )
                envioContratoCielo( );

            MessageBox.Show( "Operação Concluída!!" );

            cmdLiberarDA.Text = "Gerar";

        }
        private void textContrato_KeyPress ( object sender , KeyPressEventArgs e ) {

        }

        private void textContrato_TextChanged ( object sender , EventArgs e ) {

        }

        private void igpm_Load ( object sender, EventArgs e ) {
            mcInicio.MinDate = DateTime.Today.AddDays ( 7 );
            mcInicio.MaxDate = DateTime.Today.AddDays ( 8 );
        }

        private void cmdFolder_Click ( object sender , EventArgs e ) {

            using ( FolderBrowserDialog dgProcuraFolder = new FolderBrowserDialog( ) ) {
                dgProcuraFolder.Description = "Selecione onde o arquivo deverá ser gravado.";
                dgProcuraFolder.SelectedPath = diretorioDA( "" );
                dgProcuraFolder.ShowNewFolderButton = true;
                dgProcuraFolder.ShowDialog( this );
                if ( !dgProcuraFolder.SelectedPath.EndsWith( @"\" ) )
                    dgProcuraFolder.SelectedPath = dgProcuraFolder.SelectedPath + @"\";

                diretorioDA( dgProcuraFolder.SelectedPath );
                txtDiretorio.Text = dgProcuraFolder.SelectedPath;
            }

        }

        private string diretorioDA ( string pDiretorio ) {
            string iChaveRegistro = "SGB";
            RegistryKey iRegistro;
            iRegistro = Registry.CurrentUser.OpenSubKey( iChaveRegistro , true );

            if ( iRegistro == null ) {
                iRegistro = Registry.CurrentUser.CreateSubKey( iChaveRegistro );
                pDiretorio = @"C:\";
            }

            if ( pDiretorio != "" )
                iRegistro.SetValue( "DAFolder" , pDiretorio );


            return iRegistro.GetValue( "DAFolder" ).ToString( );
        }

        private void mcFim_DateChanged ( object sender , DateRangeEventArgs e ) {
            //txtDataFinal.Text = mcFim.SelectionStart.ToString("dd/MM/yyyy");
            //mcFim.TodayDate = mcFim.SelectionStart;

            txtDataFinal.Text = mcInicio.SelectionStart.ToString( "dd/MM/yyyy" );
            mcInicio.TodayDate = mcInicio.SelectionStart;

        }

        private void mcInicio_DateChanged ( object sender , DateRangeEventArgs e ) {
            txtDataInicial.Text = mcInicio.SelectionStart.ToString( "dd/MM/yyyy" );
            txtDataFinal.Text = mcInicio.SelectionStart.AddDays( 400 ).ToString( "dd/MM/yyyy" );
            mcInicio.TodayDate = mcInicio.SelectionStart;

        }

        private void cmdFechar_Click ( object sender , EventArgs e ) {
            this.Close( );
        }

        private void cmdLiberarDA_Click ( object sender , EventArgs e ) {
            string nomeFuncao = "BloqueioBoletos.executaComandos";

            try {
                if ( MessageBox.Show( "Liberar os registros de " + textContrato.Text + "?" , "Liberar" , MessageBoxButtons.YesNo ,
                    MessageBoxIcon.Question , MessageBoxDefaultButton.Button2 ) == DialogResult.No )
                    return;

                dados.Comandos.limpaParametros( );
                dados.Comandos.textoComando = " update principal..[contas a receber] set fl_DA = 0 " +
                    " where [Docunento do debito] = '" + textContrato.Text + "'" +
                    "  and [situacao da conta] in (0,1) " +
                    "  and fl_DA = 1 ";

                dados.Comandos.tipoComando = CommandType.Text;

                dados.retornaDados = false;

                dados.execute( );

                MessageBox.Show( dados.linhasAfetadas.ToString( ) + " registros foram liberados!" );

            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }
        }

        private void textContrato_TextChanged ( ) {

        }

        private void textContrato_TextChanged_1 ( object sender , EventArgs e ) {

        }
        private void picBradesco_Click ( object sender , EventArgs e ) {
            checkBradesco.Checked = true;
        }
        private void picHSBC_Click ( object sender , EventArgs e ) {
            checkHSBC.Checked = true;
        }

        private void txtDiretorio_TextChanged ( object sender , EventArgs e ) {

        }

        private void optAlterarVencimento_CheckedChanged ( object sender , EventArgs e ) {

        }

        private void picCielo_Click ( object sender , EventArgs e ) {
            checkCielo.Checked = true;
        }

        private void picSantander_Click ( object sender , EventArgs e ) {
            checkSantander.Checked = true;
        }

        private void checkSantander_CheckedChanged ( object sender , EventArgs e ) {
            if ( checkSantander.Checked ) {
                optCancelarCadastro.Enabled = true;
                optCadastrarContrato.Enabled = true;
            } else {
                optEnviarNovamente.Checked = true;
                optCancelarCadastro.Enabled = false;
                optCadastrarContrato.Enabled = false;
            }
        }

        private void picItau_Click ( object sender , EventArgs e ) {
            checkItau.Checked = true;
        }

        private void checkItau_CheckedChanged ( object sender , EventArgs e ) {
            if ( checkItau.Checked ) {
                optCancelarCadastro.Enabled = true;
                optCadastrarContrato.Enabled = true;
            } else {
                optEnviarNovamente.Checked = true;
                optCancelarCadastro.Enabled = false;
                optCadastrarContrato.Enabled = false;
            }

        }
    }
}