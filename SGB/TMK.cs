using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGB
{
	class TMK
	{
		CarSystem.BancoDados.Dados _sqlDados = new CarSystem.BancoDados.Dados();

		public TMK( CarSystem.BancoDados.Dados sqlDados )
		{
			this.sqlDados = sqlDados;
		}
		public CarSystem.BancoDados.Dados sqlDados
		{
			get { return _sqlDados; }
			set { _sqlDados = value; }
		}

		public int setBaixas( System.Data.DataTable tabBaixas )
		{

			string nomeFuncao = "TMK.setBaixas";

			try
			{
				sqlDados.Comandos.textoComando = "dw.Tmk.pro_getParcelasPagas";
				sqlDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;
				sqlDados.retornaDados = false;

				sqlDados.Comandos.adicionaParametro( "@tabelaParcelasPagas", System.Data.SqlDbType.Structured, 0, tabBaixas );
				sqlDados.Comandos.adicionaParametro( "@codigoEmpresa", System.Data.SqlDbType.Int, 8, 1 );

				sqlDados.execute();

				return ( int )sqlDados.linhasAfetadas;
			}
			catch ( Exception ex )
			{
				System.Windows.Forms.MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
			}

			return 0;

		}
		public System.Data.DataTable setQuitacoes()
		{

			string nomeFuncao = "TMK.setQuitacoes";

			try
			{
				sqlDados.Comandos.textoComando = "dw.Tmk.pro_setQuitacoes";
				sqlDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;
				sqlDados.retornaDados = true;

				return sqlDados.execute().Tables[0];
			}
			catch ( Exception ex )
			{
				System.Windows.Forms.MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
			}

			return null;

		}
		public System.Data.DataTable getBaixas()
		{

			string nomeFuncao = "TMK.getBaixas";

			try
			{
				tmkService.TmkServicosSoapClient servTMK = new tmkService.TmkServicosSoapClient();
				tmkService.CarSystemPC[] tabTMK;

				System.Data.DataTable dtCarsystem = new System.Data.DataTable( "tbl_CarSystem" );
				System.Data.DataRow drLinhaCarsystem;

				dtCarsystem.Columns.Add( "codigoEmpresa", typeof( int ) );
				dtCarsystem.Columns.Add( "Idparcela", typeof( int ) );
				dtCarsystem.Columns.Add( "tp_forma", typeof( int ) );
				dtCarsystem.Columns.Add( "Valor", typeof( double ) );
				dtCarsystem.Columns.Add( "Juros", typeof( double ) );
				dtCarsystem.Columns.Add( "Desconto", typeof( double ) );
				dtCarsystem.Columns.Add( "ValorPago", typeof( double ) );

				tabTMK = servTMK.GetCarSystemPC( "tmk", "EB43CC31-609D-11D3-A9DC-0080C7AB1CA7" );

				foreach ( tmkService.CarSystemPC parcelaCliente in tabTMK )
				{
					drLinhaCarsystem = dtCarsystem.NewRow();
					drLinhaCarsystem["codigoEmpresa"] = parcelaCliente.CdEmpresa;
					drLinhaCarsystem["Idparcela"] = parcelaCliente.IdParcela;
					drLinhaCarsystem["tp_forma"] = parcelaCliente.TpForma;
					drLinhaCarsystem["Valor"] = parcelaCliente.Valor;
					drLinhaCarsystem["Juros"] = parcelaCliente.ValorJuros;
					drLinhaCarsystem["Desconto"] = parcelaCliente.ValorDesconto;
					drLinhaCarsystem["ValorPago"] = parcelaCliente.TotalPago;

					dtCarsystem.Rows.Add( drLinhaCarsystem );
				}

				return dtCarsystem;
			}

			catch ( Exception ex )
			{
				System.Windows.Forms.MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
			}

			return null;
		}
		public bool setCargaOK()
		{

			string nomeFuncao = "TMK.setCargaOK";

			try
			{
				tmkService.TmkServicosSoapClient servTMK = new tmkService.TmkServicosSoapClient();

				servTMK.SetReadCarSystemPC( "tmk", "EB43CC31-609D-11D3-A9DC-0080C7AB1CA7" );

				return true;
			}

			catch ( Exception ex )
			{
				System.Windows.Forms.MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
			}

			return false;
		}

		public System.Data.DataTable getStatusDevedor()
		{
			// [Tmk].[pro_setStatusDevedores] ( @tabelaStatusDevedores as Tmk.ttb_statusDevedores readonly )
			string nomeFuncao = "TMK.getStatusDevedor";

			try
			{
				tmkService.TmkServicosSoapClient servTMK = new tmkService.TmkServicosSoapClient();
				tmkService.CarSystemStatusDevedor[] tabTMK;

				System.Data.DataTable dtCarsystem = new System.Data.DataTable( "tbl_CarSystem" );
				System.Data.DataRow drLinhaCarsystem;

				dtCarsystem.Columns.Add( "codigoCliente", typeof( int ) );
				dtCarsystem.Columns.Add( "codigoDevedor", typeof( int ) );
				dtCarsystem.Columns.Add( "Contrato", typeof( string ) );
				dtCarsystem.Columns.Add( "dataAcordo", typeof( DateTime ) );
				dtCarsystem.Columns.Add( "dataGera", typeof( DateTime ) );
				dtCarsystem.Columns.Add( "formaPagamento", typeof( string ) );
				dtCarsystem.Columns.Add( "observacao", typeof( string ) );
				dtCarsystem.Columns.Add( "statusAcordo", typeof( string ) );
				dtCarsystem.Columns.Add( "valotTotalAcordo", typeof( double ) );
				dtCarsystem.Columns.Add( "vencimentoAcordo", typeof( DateTime ) );

				tabTMK = servTMK.GetCarSystem_StatusDevedor ("tmk", "EB43CC31-609D-11D3-A9DC-0080C7AB1CA7", 1 );

				foreach ( tmkService.CarSystemStatusDevedor Cliente in tabTMK )
				{
					drLinhaCarsystem = dtCarsystem.NewRow();

					drLinhaCarsystem[ "codigoCliente" ] = Cliente.CodCliente; //int
					drLinhaCarsystem[ "codigoDevedor" ] = Cliente.CodDevedor; //int
					drLinhaCarsystem[ "Contrato" ] = Cliente.Contrato; // string
					drLinhaCarsystem[ "dataAcordo" ] = Cliente.DtAcordo; //DateTime
					drLinhaCarsystem[ "dataGera" ] = Cliente.DtGera; //DateTime
					drLinhaCarsystem[ "formaPagamento" ] = Cliente.Forma; //string
					drLinhaCarsystem[ "observacao" ] = Cliente.Obs; //string
					drLinhaCarsystem[ "statusAcordo" ] = Cliente.Status; //string
					drLinhaCarsystem[ "valotTotalAcordo" ] = Cliente.ValTotalAcordo;; //double
					drLinhaCarsystem["vencimentoAcordo"] = Cliente.VencAcordo; //DateTime

					dtCarsystem.Rows.Add( drLinhaCarsystem );
				}

				return dtCarsystem;
			}

			catch ( Exception ex )
			{
				System.Windows.Forms.MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
			}

			return null;
		}

		public int setStatusDevedor( System.Data.DataTable tabBaixas )
		{

			string nomeFuncao = "TMK.setStatusDevedor";

			try
			{
				sqlDados.Comandos.textoComando = "dw.Tmk.pro_setStatusDevedores";
				sqlDados.Comandos.tipoComando = System.Data.CommandType.StoredProcedure;
				sqlDados.retornaDados = false;

				sqlDados.Comandos.adicionaParametro( "@tabelaStatusDevedores", System.Data.SqlDbType.Structured, 0, tabBaixas );

				sqlDados.execute();

				return ( int )sqlDados.linhasAfetadas;
			}
			catch ( Exception ex )
			{
				System.Windows.Forms.MessageBox.Show( "(" + nomeFuncao + ")" + ex.Message );
			}

			return 0;

		}

	}
}
	

