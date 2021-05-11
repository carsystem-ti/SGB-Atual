using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace geraBoletos {
    public partial class OperBoletos : Form {
        CarSystem.Tipos.statusDebito statusDebito = CarSystem.Tipos.statusDebito.aVencer;

        int _acao = 0;  // 0 - CarregaLista // 1 - Equifax

        bool isLista = false;

        System.Collections.ArrayList listaClientes;
        System.Collections.ArrayList listaEquifax;

        OpenFileDialog dgArquivo = new OpenFileDialog( );

        delegate void setStatusCallback( bool value );

        CarSystem.BancoDados.Dados _dados;
        CarSystem.Boletos.Boleto boletos;
        CarSystem.Cliente cliente;
        CarSystem.Debitos.Debito debitos;
        System.Boolean _isCarregado = false;

        string contrato { get; set; }

        private CarSystem.BancoDados.Dados dados {
            get {
                string nomeFuncao = "geraBoletos.Boletos.empresa_CheckedChanged";

                try {
                    if ( _dados == null ) {
                        _dados = new CarSystem.BancoDados.Dados( );


                        if ( radCS.Checked )
                            _dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
                        else if ( radST.Checked )
                            _dados.Conexoes.servidor = CarSystem.Tipos.Servidores.Fury;
                        else
                            throw new Exception( "Empresa não reconhecida!!" );

                        _dados.Conexoes.bancoDados = "principal";
                        _dados.Conexoes.usuario = "usr_sgb";
                        _dados.Conexoes.senha = "sgb_usr";
                    }

                    return _dados;
                } catch ( Exception ex ) {
                    throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
                }
            }
            set {
                _dados = value;
            }
        }

        public OperBoletos() {
            string nomeFuncao = "geraBoletos.Boletos.Boletos(construtor)";

            try {
                InitializeComponent( );

                dtInicioVencimento.Value = DateTime.Today;

                dados = new CarSystem.BancoDados.Dados( );

                dados.Conexoes.bancoDados = "principal";
                dados.Conexoes.servidor = CarSystem.Tipos.Servidores.BDCRio;
                dados.Conexoes.usuario = "usr_sgb";
                dados.Conexoes.senha = "sgb_usr";

                inicializaObjetos( );

                statusBotoes( false );

            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }
        }

        private void statusBotoes( System.Boolean status ) {
            string nomeFuncao = "geraBoletos.Boletos.statusBotoes";

            try {
                if ( this.cmdEmail.InvokeRequired ) {
                    setStatusCallback setStatus = new setStatusCallback( statusBotoes );
                    this.Invoke( setStatus , new Object [ ] { status } );
                } else {
                    cmdEmail.Enabled = status;
                    cmdImprimir.Enabled = status;
                    cmdAlterar.Enabled = status;
                    if ( status ) {
                        cmdEmail.Text = "e&Mail";
                        cmdImprimir.Text = "&Imprimir";
                        cmdAlterar.Text = "al&Terar";
                    } else {
                        cmdEmail.Text = "Aguarde";
                        cmdImprimir.Text = "Aguarde";
                        cmdAlterar.Text = "Aguarde";
                    }
                }
            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }
        }
        private void boletosCarregados( System.Boolean isCarregado ) {
            this.isBoletoCarregado = isCarregado;
        }
        private void inicializaObjetos() {
            string nomeFuncao = "geraBoletos.Boletos.inicializaObjetos";

            try {
                if ( debitos == null )
                    debitos = new CarSystem.Debitos.Debito( CarSystem.Tipos.tipoEmissao.Producao , dados );

                if ( cliente == null )
                    cliente = new CarSystem.Cliente( dados );

                if ( boletos == null )
                    boletos = new CarSystem.Boletos.Boleto( dados );
            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }
        }
        private void cmdPesquisar_Click( object sender , EventArgs e ) {
            string nomeFuncao = "geraBoletos.Boletos.cmdPesquisar_Click";

            txtPedido.Text = txtPedido.Text == "" ? contrato : txtPedido.Text;
            contrato = txtPedido.Text;

            optTodas.CheckedChanged -= optTodas_CheckedChanged;
            optTodas.Checked = true;
            optTodas.CheckedChanged += new EventHandler( optTodas_CheckedChanged );

            try {
                txtPedido.Text = contrato;
                txtPlaca.Text = "";
                txtProduto.Text = "";
                txtNome.Text = "";
                txtEmail.Text = "";
                gridParcelas.DataSource = null;

                isBoletoCarregado = false;

                statusBotoes( false );

                if ( contrato.Length < 3 ) {
                    MessageBox.Show( "Pedido inválido!!" );
                    return;
                }

                //if (boletos == null)
                //{
                //    boletos = new CarSystem.Boletos.Boleto(CarSystem.Tipos.nomeBanco.Santander, dados);
                //    this.boletos.boletosCarregados += new CarSystem.Boletos.Boleto.carregamentoBoleto(this.boletosCarregados);
                //}

                boletosCarregados( true );
                carregaParcelas( CarSystem.Tipos.statusDebito.todos );
                carregaCliente( contrato );
                dtInicioVencimento.Value = cliente.getVencimento( DateTime.Today );

                debitos.limpar( );

                //System.Threading.Thread threadBoleto = new System.Threading.Thread(new System.Threading.ThreadStart(boletos.g .getBoletos));
                //threadBoleto.Start();         
            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }


        }

        private void setFormatoGrid( DataGridView pGrid ) {
            string nomeFuncao = "geraBoletos.Boletos.carregaParcelas";

            try {
                pGrid.Columns [ "valorAtual" ].Visible = false;
                pGrid.Columns [ "contratoDebito" ].Visible = false;
                pGrid.Columns [ "statusDebito" ].Visible = false;
                pGrid.Columns [ "numeroDocumento" ].Visible = false;
                pGrid.Columns [ "identificadorDebito" ].Visible = false;
                pGrid.Columns [ "codigoRemessa" ].Visible = false;
                pGrid.Columns [ "codigoBanco" ].Visible = false;
                pGrid.Columns [ "vencimento" ].Visible = false;

                pGrid.Columns [ "valorDebito" ].DefaultCellStyle.Format = "C2";
                pGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                pGrid.Columns.Add( colunaAcoes );
                pGrid.Columns [ pGrid.Columns.Count - 1 ].Name = "Ação";
                pGrid.Columns [ "Ação" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                pGrid.Columns [ "Ação" ].Width = 180;

                pGrid.Columns.Add( ColunaCalendario );
                pGrid.Columns [ pGrid.Columns.Count - 1 ].Name = "Calendario";
                pGrid.Columns [ "Calendario" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                pGrid.Columns [ "Calendario" ].DisplayIndex = 1;
                pGrid.Columns [ "Calendario" ].HeaderText = "Vencimento";
            } catch ( Exception ex ) {
                throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
            }
        }

        public void carregaParcelas( CarSystem.Tipos.statusDebito pStatusDebito ) {
            string nomeFuncao = "geraBoletos.Boletos.carregaParcelas";

            DataGridView iGrid = gridParcelas;

            try {
                gridParcelas.CellValueChanged -= gridParcelas_CellValueChanged;

                System.Data.DataTable tbDebitos = debitos.tbDebitos( contrato , pStatusDebito );

                iGrid.Columns.Clear( );

                this.statusDebito = pStatusDebito;

                iGrid.DataSource = tbDebitos.Copy( );

                setFormatoGrid( iGrid );

                foreach ( System.Windows.Forms.DataGridViewRow iLinha in iGrid.Rows ) {
                    iLinha.Cells [ "Calendario" ].Value = iLinha.Cells [ "vencimento" ].Value;

                    setCelulaReadOnly( iLinha , true );

                    iLinha.Cells [ "Ação" ].ReadOnly = false;
                    iLinha.Cells [ "valorDebito" ].ReadOnly = false;
                    iLinha.Cells [ "Calendario" ].ReadOnly = false;

                    setOpcoesCombo( iLinha.Cells [ "Ação" ] , ( CarSystem.Tipos.statusDebito ) Convert.ToInt32( iLinha.Cells [ 3 ].Value ) );

                    switch ( ( CarSystem.Tipos.statusDebito ) Convert.ToInt32( iLinha.Cells [ 3 ].Value ) ) {
                        case CarSystem.Tipos.statusDebito.aVencer:
                            iLinha.Cells [ "Calendario" ].Style.ForeColor = Color.DarkBlue; // .Value = "À Vencer";
                            iLinha.Cells [ "valorDebito" ].Style.ForeColor = Color.DarkBlue;
                            break;
                        case CarSystem.Tipos.statusDebito.vencido:
                            iLinha.Cells [ "Calendario" ].Style.ForeColor = Color.Red;
                            iLinha.Cells [ "valorDebito" ].Style.ForeColor = Color.Red;
                            break;
                        case CarSystem.Tipos.statusDebito.quitado:
                            iLinha.Cells [ "Calendario" ].Style.ForeColor = Color.DarkGreen;
                            iLinha.Cells [ "valorDebito" ].Style.ForeColor = Color.DarkGreen;
                            break;
                        case CarSystem.Tipos.statusDebito.cancelado:
                            iLinha.Cells [ "Calendario" ].Style.ForeColor = Color.Black;
                            iLinha.Cells [ "valorDebito" ].Style.ForeColor = Color.Black;
                            iLinha.Cells [ "valorDebito" ].ReadOnly = true;
                            iLinha.Cells [ "Calendario" ].ReadOnly = true;
                            break;
                    }
                }


            } catch ( Exception ex ) {
                throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
            } finally {
                gridParcelas.CellValueChanged += new DataGridViewCellEventHandler( gridParcelas_CellValueChanged );
            }
        }

        void setCelulaReadOnly( DataGridViewRow pLinha , bool pValor ) {
            foreach ( DataGridViewCell iCelula in pLinha.Cells )
                iCelula.ReadOnly = pValor;
        }

        private CarSystem.Utilidades.Componentes.CalendarColumn ColunaCalendario {
            get {
                return new CarSystem.Utilidades.Componentes.CalendarColumn( );
            }
        }

        private void carregaCliente( string contrato ) {
            string nomeFuncao = "geraBoletos.Boletos.carregaCliente";

            try {
                cliente.getCliente( contrato );

                txtPlaca.Text = cliente.placa;
                txtPedido.Text = cliente.contrato;
                txtProduto.Text = cliente.equipamento.nomeEquipamento;
                txtNome.Text = cliente.nome;
                txtEmail.Text = cliente.email;
            } catch ( Exception ex ) {
                throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
            }
        }
        private void cmdProcessar_Click( object sender , EventArgs e ) {
            string nomeFuncao = "geraBoletos.Boletos.cmdProcessar_Click";

            try {
                if ( !isLista )
                    MessageBox.Show( geraBoleto( contrato ) );
                else {
                    if ( _acao == 0 ) {
                        foreach ( DataGridViewRow iLinhaGrid in gridParcelas.Rows )
                            iLinhaGrid.Cells [ "Status" ].Value = geraBoleto( iLinhaGrid.Cells [ "Contrato" ].Value.ToString( ) );
                    } else if ( _acao == 1 ) {
                        double valor;

                        foreach ( DataGridViewRow iLinhaGrid in gridParcelas.Rows ) {
                            Int64 identificaDebito;

                            cliente.dados = dados;
                            cliente.getCliente( iLinhaGrid.Cells [ "contrato" ].Value.ToString( ) );
                            valor = ( double ) iLinhaGrid.Cells [ "valor" ].Value;

                            identificaDebito = boletos.geraBoleto( dtInicioVencimento.Value , cliente.contrato , "VCE" , cliente.nome , valor , Environment.UserName , 237 , 0 , dados , false , false );

                            gravaParcelasGeradas( identificaDebito , ( System.Data.DataTable ) iLinhaGrid.Cells [ "Parcelas" ].Value );

                        }
                    }
                }
            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            } finally {
                if ( !isLista )
                    cmdPesquisar_Click( sender , e );
            }
        }
        private bool gravaParcelasGeradas( Int64 identificadorDebito , System.Data.DataTable dtCheques ) {
            string nomeFuncao = "geraBoletos.Boletos.gravaParcelasGeradas";

            try {
                dados.Comandos.textoComando = "SGB.Divida.pro_setChequesBoleto"; // ( @codigoChequeDevolvido bigint, @codigoDebitoGerado bigint, @usuarioGerador varchar(30) )";
                dados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;
                dados.retornaDados = false;

                foreach ( System.Data.DataRow linhaDeb in dtCheques.Rows ) {
                    dados.Comandos.limpaParametros( );

                    dados.Comandos.adicionaParametro( "@codigoChequeDevolvido" , System.Data.SqlDbType.BigInt , 8 , Convert.ToInt64( linhaDeb [ "identificaParcela" ] ) );
                    dados.Comandos.adicionaParametro( "@codigoDebitoGerado" , System.Data.SqlDbType.BigInt , 8 , identificadorDebito );
                    dados.Comandos.adicionaParametro( "@usuarioGerador" , SqlDbType.VarChar , 30 , Environment.UserName );
                    dados.execute( );
                }

                return true;
            } catch ( Exception ex ) {
                throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
            }
        }
        private void processarLista() {
            bool isProcessarTodas = false;

            string contratoDebito;
            string conteudoCelula;

            foreach ( System.Windows.Forms.DataGridViewRow iLinhaGrid in gridParcelas.Rows ) {
                contratoDebito = ( string ) ( iLinhaGrid.Cells [ "Contrato" ].Value == null ? "" : iLinhaGrid.Cells [ "Contrato" ].Value );
                conteudoCelula = ( string ) ( iLinhaGrid.Cells [ gridParcelas.Columns.Count - 1 ].Value == null ? "" : iLinhaGrid.Cells [ gridParcelas.Columns.Count - 1 ].Value );

                if ( conteudoCelula != null && conteudoCelula == "Processar todos" )
                    isProcessarTodas = true;
                else if ( conteudoCelula != null && conteudoCelula == "Cancelar todas" )
                    break;

                if ( conteudoCelula != "Cancelar" && ( ( conteudoCelula == "" && isProcessarTodas == true ) ||
                    isProcessarTodas == true || conteudoCelula == "Processar" ) )
                    iLinhaGrid.Cells [ "Status" ].Value = geraBoleto( iLinhaGrid.Cells [ "Contrato" ].Value.ToString( ) );
            }

            //boletos.banco.funcoesBoleto.iniciarImpressao(false);
        }

        private void cmdImprimir_Click( object sender , EventArgs e ) {
            string nomeFuncao = "geraBoletos.Boletos.cmdImprimir_Click";

            try {

                using ( CarSystem.Banco.Impressao.visualizaBoleto iForm = new CarSystem.Banco.Impressao.visualizaBoleto( "https://portal.carsystem.com/cliente/ctr/pdf.ashx?" + getCodigos( ) ) )
                    iForm.ShowDialog( );

                //CarSystem.Banco.NetBoleto oBoleto = new CarSystem.Banco.NetBoleto(6);
                //oBoleto.Executa(preparacaoBoleto(), null);

                MessageBox.Show( "Processo concluído!" );
            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }
        }

        //private void imprimirLista() {
        //    bool isImprimirTodas = false;

        //    string contratoDebito;
        //    string conteudoCelula;


        //    statusDebito = CarSystem.Tipos.statusDebito.todos;

        //    if ( optVencer.Checked == true )
        //        statusDebito = CarSystem.Tipos.statusDebito.aVencer;
        //    else if ( optVencidas.Checked == true )
        //        statusDebito = CarSystem.Tipos.statusDebito.vencido;


        //    foreach ( System.Windows.Forms.DataGridViewRow iLinhaGrid in gridParcelas.Rows ) {
        //        contratoDebito = ( string ) ( iLinhaGrid.Cells [ "Contrato" ].Value == null ? "" : iLinhaGrid.Cells [ "Contrato" ].Value );
        //        conteudoCelula = ( string ) ( iLinhaGrid.Cells [ gridParcelas.Columns.Count - 1 ].Value == null ? "" : iLinhaGrid.Cells [ gridParcelas.Columns.Count - 1 ].Value );

        //        if ( conteudoCelula != null && conteudoCelula == "Imprimir todas" )
        //            isImprimirTodas = true;
        //        else if ( conteudoCelula != null && conteudoCelula == "Cancelar todas" )
        //            break;

        //        if (conteudoCelula != "Cancelar" && ((conteudoCelula == "" && isImprimirTodas == true) ||
        //            isImprimirTodas == true || conteudoCelula == "Imprimir"))
        //             boletos.imprimeBoleto(contratoDebito, CarSystem.Tipos.tipoEmissao.Producao, statusDebito, false);
        //    }

        //    boletos.banco.funcoesBoleto.iniciarImpressao(false);
        //}

        private void cmdEmail_Click( object sender , EventArgs e ) {
            string nomeFuncao = "geraBoletos.Boletos.cmdEmail_Click";

            try {

                dados.Comandos.limpaParametros( );

                dados.Comandos.textoComando = "Principal.Mensagens.pro_sendBoletosEmail";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                dados.Comandos.adicionaParametro( "@contratoCliente" , SqlDbType.VarChar , 10 , contrato );
                dados.Comandos.adicionaParametro( "@codigoParcela" , SqlDbType.VarChar , 1000 , getCodigos( ) );
                dados.Comandos.adicionaParametro( "@pDestino" , SqlDbType.VarChar , 100 , txtEmail.Text );

                dados.retornaDados = false;
                dados.execute( );

                //CarSystem.Banco.NetBoleto oBoleto = new CarSystem.Banco.NetBoleto(6);
                //oBoleto.Executa(preparacaoBoleto(), new CarSystem.Banco.Boleto.informacoesEmail("financeiro@carsystem.com", txtEmail.Text, "Boletos Car System", "", "Financeiro Car System"));

                MessageBox.Show( "Processo concluído!" );
            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }
        }
        private void Boletos_Load( object sender , EventArgs e ) {

        }

        private void gridParcelas_CellValueChanged( object sender , DataGridViewCellEventArgs e ) {
            string nomeFuncao = "geraBoletos.Boletos.gridParcelas_CellValueChanged";

            if ( gridParcelas [ "Ação" , e.RowIndex ].Value == null || gridParcelas [ "Ação" , e.RowIndex ].Value.ToString( ) == "" )
                return;

            gridParcelas.CellValueChanged -= gridParcelas_CellValueChanged;

            try {
                string iAcaoSelecionada = gridParcelas [ "Ação" , e.RowIndex ].Value.ToString( );

                switch ( iAcaoSelecionada ) {
                    case "Imprimir com Juros":
                    case "Imprimir":
                        if ( ( CarSystem.Tipos.statusDebito ) Convert.ToInt32( gridParcelas [ 3 , e.RowIndex ].Value ) == CarSystem.Tipos.statusDebito.vencido )
                            if ( iAcaoSelecionada == "Imprimir com Juros" )
                                gridParcelas [ "valorDebito" , e.RowIndex ].Value = CarSystem.Utilidades.Financeiro.Juros.calculaJuros( ( DateTime ) gridParcelas [ "Vencimento" , e.RowIndex ].Value
                                    , DateTime.Today.AddDays( 3 ) , Convert.ToDouble( gridParcelas [ "valorAtual" , e.RowIndex ].Value ) );
                        break;
                    case "Imprimir todas / Juros":
                    case "Imprimir todas":
                        foreach ( System.Windows.Forms.DataGridViewRow iLinhaGrid in gridParcelas.Rows ) {
                            if ( ( CarSystem.Tipos.statusDebito ) Convert.ToInt32( iLinhaGrid.Cells [ "statusDebito" ].Value ) == CarSystem.Tipos.statusDebito.vencido ) {
                                if ( iAcaoSelecionada == "Imprimir todas / Juros" ) {
                                    DateTime iVencimento = ( DateTime ) iLinhaGrid.Cells [ "Vencimento" ].Value;
                                    double iValor = Convert.ToDouble( iLinhaGrid.Cells [ "valorAtual" ].Value );

                                    iLinhaGrid.Cells [ "valorDebito" ].Value = CarSystem.Utilidades.Financeiro.Juros.calculaJuros( iVencimento , DateTime.Today.AddDays( 3 ) , iValor );
                                }
                                iLinhaGrid.Cells [ "Ação" ].Value = "Imprimir com Juros";
                            } else if ( ( CarSystem.Tipos.statusDebito ) Convert.ToInt32( iLinhaGrid.Cells [ "statusDebito" ].Value ) == CarSystem.Tipos.statusDebito.aVencer )
                                iLinhaGrid.Cells [ "Ação" ].Value = "Imprimir";
                        }
                        break;
                    case "Cancelar":
                        gridParcelas [ "valorDebito" , e.RowIndex ].Value = gridParcelas [ "valorAtual" , e.RowIndex ].Value;
                        gridParcelas [ "Calendario" , e.RowIndex ].Value = gridParcelas [ "vencimento" , e.RowIndex ].Value;
                        gridParcelas [ "Ação" , e.RowIndex ].Value = "";
                        break;
                    case "Cancelar todas":

                        foreach ( System.Windows.Forms.DataGridViewRow iLinhaGrid in gridParcelas.Rows ) {
                            iLinhaGrid.Cells [ "valorDebito" ].Value = iLinhaGrid.Cells [ "valorAtual" ].Value;
                            iLinhaGrid.Cells [ "Calendario" ].Value = iLinhaGrid.Cells [ "vencimento" ].Value;
                            iLinhaGrid.Cells [ "Ação" ].Value = "";

                        }
                        break;
                    case "Alterar: Dia Vencimento":
                        int iDiaVencimento = Convert.ToDateTime( gridParcelas [ "Calendario" , e.RowIndex ].Value ).Day;
                        int iMesVencimento;
                        int iAnoVencimento;

                        foreach ( System.Windows.Forms.DataGridViewRow iLinhaGrid in gridParcelas.Rows ) {
                            if ( iLinhaGrid.Index != e.RowIndex && ( ( DataGridViewComboBoxCell ) iLinhaGrid.Cells [ "Ação" ] ).Items.Contains( "Alterar: Dia Vencimento" ) ) {
                                iLinhaGrid.Cells [ "Ação" ].Value = "Alterar: Dia Vencimento";

                                iMesVencimento = Convert.ToDateTime( iLinhaGrid.Cells [ "Calendario" ].Value ).Month;
                                iAnoVencimento = Convert.ToDateTime( iLinhaGrid.Cells [ "Calendario" ].Value ).Year;
                                iLinhaGrid.Cells [ "Vencimento" ].Value = CarSystem.Utilidades.Validar.corrigeData( iDiaVencimento , iMesVencimento , iAnoVencimento );
                                iLinhaGrid.Cells [ "Calendario" ].Value = iLinhaGrid.Cells [ "Vencimento" ].Value;
                            }
                        }
                        break;
                }

            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            } finally {
                gridParcelas.CellValueChanged += new DataGridViewCellEventHandler( gridParcelas_CellValueChanged );
            }
        }

        private void setOpcaoStatus( object sender , EventArgs e ) {
            string nomeFuncao = "geraBoletos.Boletos.optVencer_CheckedChanged";

            try {
                if ( isLista )
                    return;

                switch ( ( ( RadioButton ) sender ).Name ) {
                    case "optVencer":
                        carregaParcelas( CarSystem.Tipos.statusDebito.aVencer );
                        break;
                    case "optVencidas":
                        carregaParcelas( CarSystem.Tipos.statusDebito.vencido );
                        break;
                    case "optTodas":
                        carregaParcelas( CarSystem.Tipos.statusDebito.todos );
                        break;
                }
            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }

        }

        private void optVencer_CheckedChanged( object sender , EventArgs e ) {
            string nomeFuncao = "geraBoletos.Boletos.optVencer_CheckedChanged";

            try {
                if ( isLista )
                    return;

                carregaParcelas( CarSystem.Tipos.statusDebito.aVencer );
            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }

        }
        private void optVencidas_CheckedChanged( object sender , EventArgs e ) {
            string nomeFuncao = "geraBoletos.Boletos.optVencidas_CheckedChanged";

            try {
                if ( isLista )
                    return;

                carregaParcelas( CarSystem.Tipos.statusDebito.vencido );
            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }
        }
        private void optTodas_CheckedChanged( object sender , EventArgs e ) {
            string nomeFuncao = "geraBoletos.Boletos.optTodas_CheckedChanged";

            try {
                if ( isLista )
                    return;

                carregaParcelas( CarSystem.Tipos.statusDebito.todos );
            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }
        }

        /*private System.Boolean preparaBoleto()
        {
            string nomeFuncao = "geraBoletos.Boletos.preparaBoleto";
            System.Boolean isPassou = false;

            try
            {
                if (!isBoletoCarregado)
                    throw new Exception("Boletos não carregados!");

                debitos.getDadosDebito(contrato, CarSystem.Tipos.statusDebito.todos);

                foreach (System.Windows.Forms.DataGridViewRow iLinhaGrid in gridParcelas.Rows)
                {
                    if (iLinhaGrid.Cells["Ação"].Value != null && iLinhaGrid.Cells["Ação"].Value.ToString() == "Imprimir")
                    {
                        if (cliente.contrato.ToString() != iLinhaGrid.Cells[1].Value.ToString())
                        {
                            cliente.getCliente(iLinhaGrid.Cells[1].Value.ToString());
                            debitos.getDadosDebito(cliente.contrato, CarSystem.Tipos.statusDebito.todos);
                        }

                        DataGridViewComboBoxCell cbCelula;
                        DateTime vencimento;


                        foreach (CarSystem.Interface.IInformacoesDebito infoDebito in debitos.getDebitos())
                        {
                            if (infoDebito.identificadorDebito == Convert.ToInt64(iLinhaGrid.Cells[7].Value))
                            {
                                if (iLinhaGrid.Cells["statusDebito"].Value.ToString() == "1")
                                {
                                    if (gridParcelas.Columns["valorAtualizado"] != null)
                                        boletos.banco.funcoesBoleto.imprimeBoleto(cliente,infoDebito.nossoNumero, infoDebito.numeroDocumento, Convert.ToDateTime(iLinhaGrid.Cells["vencimento"].Value), Convert.ToDouble(iLinhaGrid.Cells["valorAtualizado"].Value));
                                    else
                                    {
                                        cbCelula = (DataGridViewComboBoxCell)iLinhaGrid.Cells["vencimento"];
                                        vencimento = Convert.ToDateTime(((DataRowView)cbCelula.Items[0]).Row.ItemArray[0].ToString());
                                        boletos.banco.funcoesBoleto.imprimeBoleto(cliente, infoDebito.nossoNumero, infoDebito.numeroDocumento, vencimento, Convert.ToDouble(iLinhaGrid.Cells["valorDebito"].Value));
                                    }
                                }
                                else
                                {
                                    boletos.banco.funcoesBoleto.imprimeBoletoEndereco(infoDebito, cliente);
                                }
                                break;
                            }

                            if (infoDebito.codigoBanco != boletos.banco.nomeBanco)
                                boletos.banco.setBanco(infoDebito.codigoBanco, dados);
                        }

                        //boletos.banco.imprimeBoleto(cliente,CarSystem.Tipos.tipoEmissao.Producao,CarSystem.Tipos.statusDebito.aVencer);

                        isPassou = true;
                    }
                }
            }
            //catch (CarSystem.Utilidades.Campos.CampoException)
            //{
            //    boletos.getBoletos();
            //}
            catch (Exception ex)
            {
                throw new Exception("(" + nomeFuncao + ")" + ex.Message);
            }

            return isPassou;
        }*/
        private System.String geraBoleto( String contrato ) {
            string nomeFuncao = "geraBoletos.Boletos.geraBoleto";

            try {
                boletos.inicioVencimento = dtInicioVencimento.Value;
                return boletos.geraBoleto( contrato , Convert.ToInt32( nud_Parcelas.Value ) , 0 , Environment.UserName.ToString( ) );
            } catch ( Exception ex ) {
                if ( isLista )
                    return ex.Message;
                else
                    throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
            }
        }
        private System.Windows.Forms.DataGridViewComboBoxColumn colunaAcoes {
            get {
                string nomeFuncao = "geraBoletos.Boletos.colunaAcoes";

                try {

                    return CarSystem.Utilidades.Componentes.Grid.comboGridColuna( null , "Ação" , "Ação" );

                    //if ( isLista )
                    //    return CarSystem.Utilidades.Componentes.Grid.comboGridColuna( new string [ ] { "Imprimir", "Imprimir todas", "Cancelar", "Cancelar todas", "Processar todos",
                    //    "Processar"} , "Ação" );
                    //else
                      //  return CarSystem.Utilidades.Componentes.Grid.comboGridColuna( new string [ ] { "Imprimir", "Imprimir todas", "Cancelar", "Cancelar todas",
                      //  "Alterar Status: AVencer", "Alterar Status: Vencida", "Alterar Status: Cancelada", "Alterar: Vencimento", "Alterar: Dia Vencimento" } , "Ação" );
                } catch ( Exception ex ) {
                    throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
                }
            }
        }

        private System.Windows.Forms.DataGridViewComboBoxCell setOpcoesCombo( DataGridViewCell pCelula , CarSystem.Tipos.statusDebito pStatusDebito ) {
            //string nomeFuncao = "geraBoletos.Boletos.colunaAcoes";           

            DataGridViewComboBoxCell iCombo = ( DataGridViewComboBoxCell ) pCelula;

            if ( isLista ) {
                iCombo.Items.Add( "Imprimir" );
                iCombo.Items.Add( "Imprimir todas" );
                iCombo.Items.Add( "Cancelar" );
                iCombo.Items.Add( "Cancelar todas" );
                iCombo.Items.Add( "Processar todos" );
                iCombo.Items.Add( "Processar" );
            } else {

                switch ( pStatusDebito ) {
                    case CarSystem.Tipos.statusDebito.cancelado:
                        iCombo.Items.Add( "Alterar Status: AVencer" );
                        iCombo.Items.Add( "Alterar Status: Vencida" );
                        break;
                    case CarSystem.Tipos.statusDebito.aVencer:
                        iCombo.Items.Add( "Imprimir" );
                        iCombo.Items.Add( "Imprimir todas" );
                        iCombo.Items.Add( "Cancelar" );
                        iCombo.Items.Add( "Cancelar todas" );
                        iCombo.Items.Add( "Alterar Status: Vencida" );
                        iCombo.Items.Add( "Alterar Status: Cancelada" );
                        iCombo.Items.Add( "Alterar: Vencimento" );
                        iCombo.Items.Add( "Alterar: Dia Vencimento" );
                        break;
                    case CarSystem.Tipos.statusDebito.vencido:
                        iCombo.Items.Add( "Imprimir" );
                        iCombo.Items.Add( "Imprimir com Juros" );
                        iCombo.Items.Add( "Imprimir todas" );
                        iCombo.Items.Add( "Imprimir todas / Juros" );
                        iCombo.Items.Add( "Cancelar" );
                        iCombo.Items.Add( "Cancelar todas" );
                        iCombo.Items.Add( "Alterar Status: AVencer" );
                        iCombo.Items.Add( "Alterar Status: Cancelada" );
                        iCombo.Items.Add( "Alterar: Vencimento" );
                        iCombo.Items.Add( "Alterar: Dia Vencimento" );
                        break;
                    case CarSystem.Tipos.statusDebito.quitado:
                        iCombo.Items.Add( "Alterar Status: AVencer" );
                        break;
                }
            }

            return iCombo;
        }


        private System.Windows.Forms.DataGridViewComboBoxCell comboGridCelula( object valor ) {

            string nomeFuncao = "geraBoletos.Boletos.comboGridCelula";
            System.Windows.Forms.DataGridViewComboBoxCell cbCelula = new DataGridViewComboBoxCell( );

            System.Data.DataTable tbDatas = new DataTable( );

            try {
                tbDatas.Columns.Add( "data" );
                tbDatas.Columns [ "data" ].DataType = typeof( string );

                if ( valor != null )
                    tbDatas.Rows.Add( ( ( DateTime ) valor ).ToString( "dd/MM/yyyy" ) );
                //cbCelula.Items.Add(valor);

                for ( int contador = 0; contador < 45; contador++ )
                    tbDatas.Rows.Add( DateTime.Today.Date.AddDays( contador ).ToString( "dd/MM/yyyy" ) );
                //cbCelula.Items.Add(DateTime.Today.Date.AddDays(contador).ToString("dd/MM/yyyy"));

                cbCelula.Style.ForeColor = Color.Red;

                cbCelula.DataSource = tbDatas;
                cbCelula.ValueMember = "data";
                cbCelula.DisplayMember = "data";

                return cbCelula;
            } catch ( Exception ex ) {
                throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
            }
        }

        public System.Boolean isBoletoCarregado {
            get { return _isCarregado; }
            set { statusBotoes( value ); _isCarregado = value; }
        }
        private void gridParcelas_DataError( object sender , DataGridViewDataErrorEventArgs e ) {
            //throw new Exception("The method or operation is not implemented.");
        }
        private void gridParcelas_CellBeginEdit( object sender , DataGridViewCellCancelEventArgs e ) {
            if ( gridParcelas [ e.ColumnIndex , e.RowIndex ].GetType( ).FullName != typeof( DataGridViewComboBoxCell ).FullName
                && gridParcelas.Columns [ e.ColumnIndex ].GetType( ).FullName != typeof( DataGridViewComboBoxColumn ).FullName
                && isLista && gridParcelas.Columns [ e.ColumnIndex ].Name != "Desconto" )
                e.Cancel = true;
        }
        private System.Collections.ArrayList carregaLista( string arquivo ) {
            string linha;
            System.Collections.ArrayList listaClientes = new System.Collections.ArrayList( );

            CarSystem.Utilidades.IO.Arquivo.abreArquivo( arquivo );

            while ( ( linha = CarSystem.Utilidades.IO.Arquivo.leArquivo( ) ) != null ) {
                listaClientes.Add( new CarSystem.Cliente( dados ) );
                ( ( CarSystem.Cliente ) listaClientes [ listaClientes.Count - 1 ] ).getCliente( linha );
            }

            return listaClientes;
        }
        private System.Collections.ArrayList carregaEquifax( string arquivo ) {
            string linha;
            System.Collections.ArrayList iListaEquifax = new System.Collections.ArrayList( );

            CarSystem.Utilidades.IO.Arquivo.abreArquivo( arquivo );

            while ( ( linha = CarSystem.Utilidades.IO.Arquivo.leArquivo( ) ) != null )
                iListaEquifax.Add( getChequesDocumento( linha ) );

            return iListaEquifax;
        }

        private System.Data.DataSet getChequesDocumento( string documento ) {
            string nomeFuncao = "CarSystem.GeraBoletos.getChequesDocumento";

            try {
                dados.Comandos.limpaParametros( );

                dados.Comandos.textoComando = "SGB.Divida.pro_getChequesDocumento";
                dados.Comandos.tipoComando = CommandType.StoredProcedure;

                documento = ( string ) CarSystem.Utilidades.Formatar.retiraNaoNumericos( documento );

                if ( documento.Length == 11 ) {
                    documento = ( string ) CarSystem.Utilidades.Formatar.formataCPF( documento );
                    dados.Comandos.adicionaParametro( "@cpf" , SqlDbType.Char , 14 , documento );
                    dados.Comandos.adicionaParametro( "@cnpj" , SqlDbType.Char , 18 , "" );
                } else if ( documento.Length == 14 ) {
                    documento = ( string ) CarSystem.Utilidades.Formatar.formataCNPJ( documento );
                    dados.Comandos.adicionaParametro( "@cpf" , SqlDbType.Char , 14 , "" );
                    dados.Comandos.adicionaParametro( "@cnpj" , SqlDbType.Char , 18 , documento );
                }

                dados.retornaDados = true;
                return dados.execute( );

            } catch ( Exception ex ) {
                throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
            }


        }

        private void geraNNDiversos( int quantosNNs ) {
            string NN = "";

            for ( int contador = 1; contador <= quantosNNs; contador++ )
                NN = NN + "\n" + CarSystem.Banco.NetBoleto.getNossoNumero( dados );

            Clipboard.Clear( );
            Clipboard.SetText( NN.ToString( ) );

            MessageBox.Show( "NossosNumeros Gerados!\n" + NN.ToString( ) );
        }

        private void cmdCarregarLista_Click( object sender , EventArgs e ) {
            _acao = 1;

            dgArquivo = new OpenFileDialog( );

            dgArquivo.FileOk += new CancelEventHandler( dgArquivo_FileOk );
            dgArquivo.Multiselect = true;
            dgArquivo.ShowDialog( this );
        }

        private void executaLista( string [ ] arquivos ) {
            string nomeFuncao = "CarSystem.GeraBoletos.executaLista";

            try {
                isLista = true;

                statusBotoes( true );
                cmdEmail.Enabled = false;

                cmdCarregarLista.Enabled = false;
                cmdCancelaLista.Enabled = true;
                dtInicioVencimento.Enabled = true;
                cmdImprimir.Enabled = true;

                listaClientes = carregaLista( arquivos [ 0 ] );

                System.Data.DataTable dtListaClientes = new DataTable( "listaClientes" );

                dtListaClientes.Columns.Add( "Contrato" , typeof( string ) );
                dtListaClientes.Columns.Add( "Nome" , typeof( string ) );
                dtListaClientes.Columns.Add( "Produto" , typeof( string ) );
                dtListaClientes.Columns.Add( "Valor" , typeof( double ) );
                dtListaClientes.Columns.Add( "Desconto" , typeof( double ) );
                dtListaClientes.Columns.Add( "Status" , typeof( string ) );

                foreach ( CarSystem.Cliente iCliente in listaClientes )
                    dtListaClientes.Rows.Add( iCliente.contrato , iCliente.nome , iCliente.produto , iCliente.valorMonitoramento , 0 );

                gridParcelas.DataSource = dtListaClientes;

                gridParcelas.Columns.Add( colunaAcoes );
                gridParcelas.Columns [ gridParcelas.Columns.Count - 1 ].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                gridParcelas.Columns [ "Contrato" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                gridParcelas.Columns [ "Nome" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                gridParcelas.Columns [ "Produto" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                gridParcelas.Columns [ "Valor" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                gridParcelas.Columns [ "Desconto" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                gridParcelas.Columns [ "Status" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            } catch ( Exception ex ) {
                throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
            }
        }
        private void executaEquifax( string [ ] arquivos ) {
            string nomeFuncao = "CarSystem.GeraBoletos.executaLista";

            try {
                isLista = true;

                gridParcelas.DataSource = null;

                statusBotoes( true );
                cmdEmail.Enabled = false;

                cmdCarregarLista.Enabled = false;
                cmdCancelaLista.Enabled = true;
                dtInicioVencimento.Enabled = true;
                cmdImprimir.Enabled = true;

                listaEquifax = carregaEquifax( arquivos [ 0 ] );

                System.Data.DataTable dtListaEquifax = new DataTable( "listaEquifax" );

                dtListaEquifax.Columns.Add( "Contrato" , typeof( string ) );
                dtListaEquifax.Columns.Add( "Parcelas" , typeof( System.Data.DataTable ) );
                dtListaEquifax.Columns.Add( "Valor" , typeof( double ) );
                dtListaEquifax.Columns.Add( "Status" , typeof( string ) );

                foreach ( System.Data.DataSet iConjTabelas in listaEquifax ) {
                    if ( iConjTabelas.Tables [ 0 ].Rows.Count > 0 )
                        dtListaEquifax.Rows.Add( iConjTabelas.Tables [ 0 ].Rows [ 0 ] [ "contrato" ].ToString( ) , iConjTabelas.Tables [ 0 ] ,
                            Convert.ToDouble( iConjTabelas.Tables [ 0 ].Rows [ 0 ] [ "valor" ] ) , "" );
                }

                gridParcelas.DataSource = dtListaEquifax;

                gridParcelas.Columns.Add( colunaAcoes );
                gridParcelas.Columns [ gridParcelas.Columns.Count - 1 ].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                gridParcelas.Columns [ "Contrato" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                gridParcelas.Columns [ "Parcelas" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                gridParcelas.Columns [ "Valor" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                gridParcelas.Columns [ "Status" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgArquivo = null;
            } catch ( Exception ex ) {
                throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
            }
        }

        void dgArquivo_FileOk( object sender , CancelEventArgs e ) {
            if ( _acao == 0 )
                executaLista( dgArquivo.FileNames );
            else if ( _acao == 1 )
                executaEquifax( dgArquivo.FileNames );

            dgArquivo = null;
        }
        private void cmdCancelaLista_Click( object sender , EventArgs e ) {

            isLista = false;

            statusBotoes( false );

            cmdCarregarLista.Enabled = true;
            cmdCancelaLista.Enabled = false;
            dtInicioVencimento.Enabled = false;
            cmdImprimir.Enabled = false;

            gridParcelas.DataSource = null;

        }

        private void cmdEquifax_Click( object sender , EventArgs e ) {
            _acao = 1;

            dgArquivo = new OpenFileDialog( );

            dgArquivo.FileOk += new CancelEventHandler( dgArquivo_FileOk );
            dgArquivo.Multiselect = true;
            dgArquivo.ShowDialog( this );

        }

        private void cmdAlterar_Click( object sender , EventArgs e ) {
            string nomeFuncao = "geraBoletos.Boletos.Boletos(construtor)";

            try {
                foreach ( System.Windows.Forms.DataGridViewRow iLinhaGrid in gridParcelas.Rows ) {
                    if ( iLinhaGrid.Cells [ "Ação" ].Value != null ) {
                        switch ( iLinhaGrid.Cells [ "Ação" ].Value.ToString( ) ) {
                            case "Alterar Status: Vencida":
                                debitos.setStatusParcela( Convert.ToInt64( iLinhaGrid.Cells [ "identificadorDebito" ].Value ) , CarSystem.Tipos.statusDebito.vencido , Environment.UserName );
                                break;
                            case "Alterar Status: Cancelada":
                                debitos.setStatusParcela( Convert.ToInt64( iLinhaGrid.Cells [ "identificadorDebito" ].Value ) , CarSystem.Tipos.statusDebito.cancelado , Environment.UserName );
                                break;
                            case "Alterar Status: AVencer":
                                debitos.setStatusParcela( Convert.ToInt64( iLinhaGrid.Cells [ "identificadorDebito" ].Value ) , CarSystem.Tipos.statusDebito.aVencer , Environment.UserName );
                                break;
                            case "Alterar: Vencimento":
                                debitos.setVencimentoParcela( Convert.ToInt64( iLinhaGrid.Cells [ "identificadorDebito" ].Value ) , Convert.ToDateTime( iLinhaGrid.Cells [ "Calendario" ].Value )
                                    , Environment.UserName );
                                break;
                            case "Alterar: Dia Vencimento":
                                break;
                        }
                    }
                }

                cmdPesquisar_Click( null , null );
            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }

        }

        private void empresa_CheckedChanged( object sender , EventArgs e ) {
            string nomeFuncao = "geraBoletos.Boletos.empresa_CheckedChanged";

            try {
                dados = null;

                debitos = null;
                cliente = null;
                boletos = null;
                inicializaObjetos( );

            } catch ( Exception ex ) {
                MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
            }
        }

        private void gridParcelas_CellClick( object sender , DataGridViewCellEventArgs e ) {
            SendKeys.Send( "{F2}" );
        }

        private void gridParcelas_CellContentClick( object sender , DataGridViewCellEventArgs e ) {

        }

        private void txtPedido_TextChanged( object sender , EventArgs e ) {
            txtPlaca.Text = "";
        }

        private void txtPlaca_TextChanged( object sender , EventArgs e ) {
            txtPedido.Text = "";
        }


        //CarSystem.Banco.NetBoleto oBoleto = new CarSystem.Banco.NetBoleto(6);
        //oBoleto.Executa(preparacaoBoleto(), new CarSystem.Banco.Boleto.informacoesEmail("financeiro@carsystem.com", txtEmail.Text, "Boletos Car System", "", "Financeiro Car System"));

        private string getCodigos() {
            string nomeFuncao = "geraBoletos.Boletos.preparacaoBoleto";
            System.Collections.Generic.List<CarSystem.Banco.Boleto.criteriosBoleto> iListaBoletos = new List<CarSystem.Banco.Boleto.criteriosBoleto>( );
            string iCodigos = "";
            try {
                if ( !isBoletoCarregado )
                    throw new Exception( "Boletos não carregados!" );

                string iAcaoSelecionada = "";

                foreach ( System.Windows.Forms.DataGridViewRow iLinhaGrid in gridParcelas.Rows ) {
                    if ( iLinhaGrid.Cells [ "Ação" ].Value != null && iLinhaGrid.Cells [ "Ação" ].Value.ToString( ).Contains( "Imprimir" ) ) {
                        iAcaoSelecionada = iLinhaGrid.Cells [ "Ação" ].Value.ToString( );
                        /*
                        iListaBoletos.Add(new CarSystem.Banco.Boleto.criteriosBoleto(Convert.ToInt64(iLinhaGrid.Cells["identificadorDebito"].Value)
                        , 6, Convert.ToDateTime(iLinhaGrid.Cells["vencimento"].Value), !iAcaoSelecionada.Contains("Juros")));
                        */

                        iCodigos += ( iCodigos != "" ? ";" : "" ) + iLinhaGrid.Cells [ "identificadorDebito" ].Value.ToString( );

                    }
                }


            } catch ( Exception ex ) {
                throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
            }

            return iCodigos;
        }
        private System.Collections.Generic.List<CarSystem.Banco.Boleto.criteriosBoleto> preparacaoBoleto() {
            string nomeFuncao = "geraBoletos.Boletos.preparacaoBoleto";
            System.Collections.Generic.List<CarSystem.Banco.Boleto.criteriosBoleto> iListaBoletos = new List<CarSystem.Banco.Boleto.criteriosBoleto>( );

            try {
                if ( !isBoletoCarregado )
                    throw new Exception( "Boletos não carregados!" );

                string iAcaoSelecionada = "";

                foreach ( System.Windows.Forms.DataGridViewRow iLinhaGrid in gridParcelas.Rows ) {
                    if ( iLinhaGrid.Cells [ "Ação" ].Value != null && iLinhaGrid.Cells [ "Ação" ].Value.ToString( ).Contains( "Imprimir" ) ) {
                        iAcaoSelecionada = iLinhaGrid.Cells [ "Ação" ].Value.ToString( );

                        iListaBoletos.Add( new CarSystem.Banco.Boleto.criteriosBoleto( Convert.ToInt64( iLinhaGrid.Cells [ "identificadorDebito" ].Value )
                        , 6 , Convert.ToDateTime( iLinhaGrid.Cells [ "vencimento" ].Value ) , !iAcaoSelecionada.Contains( "Juros" ) ) );
                    }
                }
            } catch ( Exception ex ) {
                throw new Exception( "(" + nomeFuncao + ")" + ex.Message );
            }

            return iListaBoletos;
        }

    }
}