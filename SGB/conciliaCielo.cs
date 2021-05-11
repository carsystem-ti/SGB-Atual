using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Cielo = CarSystem.Banco.Cielo.Conciliacao;
namespace SGB
{
    public partial class conciliaCielo : Form
    {
        Microsoft.Office.Interop.Excel.Application _excelApplication; 
        Microsoft.Office.Interop.Excel.Workbook _excelWorkbook;
        Microsoft.Office.Interop.Excel.Worksheet _excelWorksheet;
        Microsoft.Office.Interop.Excel.Range _excelWorkSheetRange;

        public conciliaCielo()
        {
            InitializeComponent();
        }

        public Microsoft.Office.Interop.Excel.Application excelApplication
        {
            get 
            {
                if ( _excelApplication == null )
                    _excelApplication = new Microsoft.Office.Interop.Excel.Application();

                return _excelApplication; 
            }
        }
        public Microsoft.Office.Interop.Excel.Workbook excelWorkbook
        {
            get
            {
                if (_excelWorkbook == null)
                    _excelWorkbook = excelApplication.Workbooks.Add(1);

                return _excelWorkbook;
            }
        }
        public Microsoft.Office.Interop.Excel.Worksheet excelWorksheet
        {
            get 
            {
                if ( _excelWorksheet == null )
                    _excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Sheets[1];
                
                return _excelWorksheet; 
            }
            set { _excelWorksheet = value; }
        }
        public Microsoft.Office.Interop.Excel.Range excelWorkSheetRange
        {
            get { return _excelWorkSheetRange; }
            set { _excelWorkSheetRange = value; }
        }

        private void conciliaCielo_Load(object sender, EventArgs e)
        {
            criarPlanilha(@"C:\EXTVISA09041201.txt");
            Application.Exit();
        }

        public void campoValor(string pConteudo, int pLinha, int pColuna)
        {
            string iCelula = Convert.ToChar(pColuna + 64).ToString() + pLinha.ToString();
             

            criaCelulas(pLinha, pColuna, pConteudo, iCelula, iCelula, 1, Color.White, false, 10, Color.Black, Excel.XlHAlign.xlHAlignCenter
            , Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter, "Verdana");
        }
        public void campoTitulo(string pConteudo, int pLinha, int pColuna)
        {
            string iCelula = Convert.ToChar(pColuna + 64).ToString() + pLinha.ToString();

            criaCelulas(pLinha, pColuna, pConteudo, iCelula, iCelula, 1, Color.LightGray, false, 10, Color.Black, Excel.XlHAlign.xlHAlignCenter
            , Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter, "Verdana");
        }

        public void criarPlanilha(string pArquivo)
        {
            string iConteudo;

            int iLinha = 0;
            int iLinhaValor = 0;

            int iColuna = 0;

            iLinha++;
            criaCelulas(iLinha, 1, "Arquivo", "A1", "M1", 13, Color.LightGray, true, 12, Color.Black, Excel.XlHAlign.xlHAlignCenter
            , Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter, "Verdana");

            iLinha++;
            criaCelulas(iLinha, 1, pArquivo, "A2", "M2", 20, Color.White, false, 12, Color.Black, Excel.XlHAlign.xlHAlignCenter
            , Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter, "Verdana");



            #region cabecalho

            CarSystem.Banco.Cielo.Conciliacao.Header iHeader = new CarSystem.Banco.Cielo.Conciliacao.Header("Cabeçalho");
            System.Data.DataTable iTabelaHeader = iHeader.getTabelaConteudo(pArquivo, false);

            iLinha++;
            criaCelulas(iLinha, 1, "Cabeçalho", "A" + iLinha.ToString(), "M" + iLinha.ToString(), 13, Color.LightGray, true, 12, Color.Black, Excel.XlHAlign.xlHAlignCenter
            , Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter, "Verdana");

            Cielo.Header.CamposHeader iCampoHeader;

            iLinha++;
            iLinhaValor = iLinha + 1;
            iColuna = 1;

            iCampoHeader = Cielo.Header.CamposHeader.empresaAdquirente;
            iConteudo = iCampoHeader.ToString();
            campoTitulo(iConteudo, iLinha, iColuna);

            iConteudo = iTabelaHeader.Rows[0][iConteudo].ToString();
            campoValor(iConteudo, iLinhaValor, iColuna);

            iColuna++;

            iCampoHeader = Cielo.Header.CamposHeader.opcaoExtrato;
            iConteudo = iCampoHeader.ToString();
            campoTitulo(iConteudo, iLinha, iColuna);

            iConteudo = Cielo.Header.getOpcaoExtrato(iTabelaHeader.Rows[0][iConteudo].ToString());
            campoValor(iConteudo, iLinhaValor, iColuna);

            iColuna++;

            iCampoHeader = Cielo.Header.CamposHeader.van;
            iConteudo = iCampoHeader.ToString();
            campoTitulo(iConteudo, iLinha, iColuna);

            iConteudo = Cielo.Header.getVan(iTabelaHeader.Rows[0][iConteudo].ToString());
            campoValor(iConteudo, iLinhaValor, iColuna);

            iColuna++;

            iCampoHeader = Cielo.Header.CamposHeader.caixaPostal;
            iConteudo = iCampoHeader.ToString();
            campoTitulo(iConteudo, iLinha, iColuna);

            iConteudo = iTabelaHeader.Rows[0][iConteudo].ToString();
            campoValor(iConteudo, iLinhaValor, iColuna);

            iColuna++;

            iCampoHeader = Cielo.Header.CamposHeader.versaoLayout;
            iConteudo = iCampoHeader.ToString();
            campoTitulo(iConteudo, iLinha, iColuna);

            iConteudo = iTabelaHeader.Rows[0][iConteudo].ToString();
            campoValor(iConteudo, iLinhaValor, iColuna);

            #endregion
            #region DetalheRO

            iLinha++;
            CarSystem.Banco.Cielo.Conciliacao.DetalheRO iDetalheRO = new CarSystem.Banco.Cielo.Conciliacao.DetalheRO("DetalheRO");
            System.Data.DataTable iTabelaDetalheRO = iDetalheRO.getTabelaConteudo(pArquivo, false);

            iLinha++;
            criaCelulas(iLinha, 1, "DetalheRO", "A" + iLinha.ToString(), "O" + iLinha.ToString(), 15, Color.LightGray, true, 12, Color.Black, Excel.XlHAlign.xlHAlignCenter
            , Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter, "Verdana");

            iLinha++;
            iColuna = 0;

            iColuna++;
            campoValor(Cielo.DetalheRO.CamposDetalheRO.parcela.ToString(), iLinha, iColuna);

            iColuna++;
            campoValor(Cielo.DetalheRO.CamposDetalheRO.plano.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.tipoTransacao.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.statusPagamento.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.identificadorProduto.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.origemAjuste.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.identificadorProdutoFinanceiro.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.numeroOperacaoFinanceira.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.codigoBandeira.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.numeroUnicoRo.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.taxaComissao.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.tarifa.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.taxaGarantia.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.meioCaptura.ToString(), iLinha, iColuna);

            iColuna++;
            campoTitulo(Cielo.DetalheRO.CamposDetalheRO.numeroLogicoTerminal.ToString(), iLinha, iColuna);

            iLinhaValor = iLinha + 1;
            foreach (System.Data.DataRow iLinhaDetalheRO in iTabelaDetalheRO.Rows)
            {
                iLinhaValor++;
                iColuna = 0;

                iColuna++;
                campoValor(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.parcela.ToString()].ToString(), iLinhaValor, iColuna);

                iColuna++;
                campoValor(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.plano.ToString()].ToString(), iLinhaValor, iColuna);

                iColuna++;
                campoValor(Cielo.DetalheRO.getTipoTransacao(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.tipoTransacao.ToString()].ToString()), iLinhaValor, iColuna);

                iColuna++;
                campoValor(Cielo.DetalheRO.getStatusPagamento(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.statusPagamento.ToString()].ToString()), iLinhaValor, iColuna);

                iColuna++;
                campoValor(Cielo.DetalheRO.getIdentificadorProduto(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.identificadorProduto.ToString()].ToString()), iLinhaValor, iColuna);

                iColuna++;
                campoValor(Cielo.DetalheRO.getOrigemAjuste(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.origemAjuste.ToString()].ToString()), iLinhaValor, iColuna);

                iColuna++;
                campoValor(Cielo.DetalheRO.getIdentificadorProdutoFinanceiro(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.identificadorProdutoFinanceiro.ToString()].ToString()), iLinhaValor, iColuna);

                iColuna++;
                campoValor(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.numeroOperacaoFinanceira.ToString()].ToString(), iLinhaValor, iColuna);

                iColuna++;
                campoValor(Cielo.DetalheRO.getCodigoBandeira(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.codigoBandeira.ToString()].ToString()), iLinhaValor, iColuna);

                iColuna++;
                campoValor(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.numeroUnicoRo.ToString()].ToString(), iLinhaValor, iColuna);

                iColuna++;
                campoValor(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.taxaComissao.ToString()].ToString(), iLinhaValor, iColuna);

                iColuna++;
                campoValor(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.tarifa.ToString()].ToString(), iLinhaValor, iColuna);

                iColuna++;
                campoValor(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.taxaGarantia.ToString()].ToString(), iLinhaValor, iColuna);

                iColuna++;
                campoValor(Cielo.DetalheRO.getMeioCaptura(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.meioCaptura.ToString()].ToString()), iLinhaValor, iColuna);

                iColuna++;
                campoValor(iLinhaDetalheRO[Cielo.DetalheRO.CamposDetalheRO.numeroLogicoTerminal.ToString()].ToString(), iLinhaValor, iColuna);
            }

            #endregion


            /*


-----DetalheCV
Motivo da rejeição 
	001   
	…   
	999   
TID  
Valor total da venda no caso de Parcelado Loja 
Valor da próxima parcela  
Código do país emissor do cartão 
Referência / código do pedido 
Hora da transação 
Número único da transação 
Indicador PP 
*/



            excelApplication.Visible = true;

            //_excelApplication.Save("c:\teste.xls");
        }

        public void criaCelulas(int pLinha, int pColuna, string pTexto, string pCelula1, string pCelula2, int pColunasMerge, 
            System.Drawing.Color pCorFundo, bool pNegrito, int pTamanhoCelula, System.Drawing.Color pCorLetra, Excel.XlHAlign pAlinhamentoH, 
            Excel.XlVAlign pAlinhamentoV, string pNomeFonte)
        {
            
            excelWorkSheetRange = excelWorksheet.get_Range(pCelula1, pCelula2);
            excelWorkSheetRange.Merge(pColunasMerge);

            excelWorkSheetRange.NumberFormat = "@";
            excelWorksheet.Cells[pLinha, pColuna] = pTexto;
            excelWorkSheetRange.VerticalAlignment = pAlinhamentoV;
            excelWorkSheetRange.HorizontalAlignment = pAlinhamentoH;

            excelWorkSheetRange.Interior.Color = pCorFundo.ToArgb();

            excelWorkSheetRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
            excelWorkSheetRange.Font.Bold = pNegrito;
            excelWorkSheetRange.Font.Name = pNomeFonte;
            excelWorkSheetRange.ColumnWidth = pTamanhoCelula;
            
            excelWorkSheetRange.Font.Color = pCorLetra.ToArgb();
        }

        public void addData(int row, int col, string data,
            string cell1, string cell2, string format, int pColunaMerge)
        {
            _excelWorkSheetRange.Merge(pColunaMerge);
            _excelWorksheet.Cells[row, col] = data;
            _excelWorkSheetRange = _excelWorksheet.get_Range(cell1, cell2);
            _excelWorkSheetRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
            _excelWorkSheetRange.NumberFormat = format;
        }
    }
}

