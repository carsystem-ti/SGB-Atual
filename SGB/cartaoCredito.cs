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
    public partial class cartaoCredito : Form
    {
        CarSystem.BancoDados.Dados _dados;
        CarSystem.Banco.Cielo.Funcoes _funcoesCielo;

        string[][] _dadosBanco;

        public string[][] dadosBanco
        {
            get { return _dadosBanco; }
            set { _dadosBanco = value; }
        }

        public CarSystem.Banco.Cielo.Funcoes funcoesCielo
        {
            get { return _funcoesCielo; }
            set { _funcoesCielo = value; }
        }

        string _numeroContrato;

        public CarSystem.BancoDados.Dados dados
        {
            get { return _dados; }
            set { _dados = value; }
        }
        public string numeroContrato
        {
            get { return _numeroContrato; }
            set { _numeroContrato = value; }
        }

        public cartaoCredito(CarSystem.BancoDados.Dados pDados)
        {
            InitializeComponent();
            dados = pDados;
        }

        private void comboBanco_MouseClick(object sender, MouseEventArgs e)
        {
            textCartao.MaxLength = Convert.ToInt32(dadosBanco[comboBanco.SelectedIndex][1]);
        }

        private void carregaBancos()
        {

//'Debito.pro_getBancos
            int iContador = 0;
            System.Data.DataTable iTabelaBancos = funcoesCielo.getBancos();

            comboBanco.Items.Clear();
            dadosBanco = new string[iTabelaBancos.Rows.Count][2];

            foreach ( System.Data.DataRow iLinha in iTabelaBancos.Rows)
            {
                if ( (bool)iLinha[0] )
                {
                dadosBanco[iContador][0] = iLinha[0].ToString();
                dadosBanco[iContador][1] = iLinha[2].ToString();
                comboBanco.Items.Add(dadosBanco[iContador][0]);
                }
                iContador++;
            }
if ( comboBanco.Items.Count > 0 )
{
            comboBanco.SelectedIndex = comboBanco.Items.Count - 1;
            comboBanco.Enabled = comboBanco.Items.Count > 1;
}
        }

        private void checkMonitoramento_CheckedChanged(object sender, EventArgs e)
        {
            for (int iLinha = 1; iLinha <= gridParcelas.Rows.Count - 1; iLinha++)
                if (gridParcelas[2, iLinha].Value.ToString().StartsWith("C"))
                    gridParcelas[5, iLinha].Value = gridParcelas[5, 0].ToString() == "Cancelar" ? !checkMonitoramento.Checked : checkMonitoramento.Checked;
        }


        private void carregaCartoes()
        {

            System.Data.DataTable iTabelaCartoes = funcoesCielo.getCartoes(numeroContrato);

            gridCartoes.DataSource = iTabelaCartoes;
            gridCartoes.Columns[gridCartoes.Columns.Count - 1].Visible = false;
            gridCartoes.Columns[gridCartoes.Columns.Count - 2].Visible = false;

        }

        private System.Data.DataTable getClientes(string pNumeroContrato)
        {
            dados.Comandos.textoComando = "Debito.pro_getClientes '" + numeroContrato + "'";
            dados.Comandos.tipoComando = System.Data.CommandType.Text;
            dados.retornaDados = true;

            return dados.execute().Tables[0];
        }

        private void carregaParcelas(int pCodigoCartao, string pNumeroContrato)
        {
            System.Data.DataTable iTabela;

            if (pCodigoCartao == 0)
            {
                iTabela = getClientes(numeroContrato);
                textNome.Text = iTabela.Rows[0]["nome"].ToString();
                textProduto.Text = iTabela.Rows[0]["produto"].ToString();

                gridParcelas.DataSource = funcoesCielo.getDebitosCartao(pCodigoCartao, pNumeroContrato);
            }
            else
            {
                gridParcelas.DataSource = funcoesCielo.getDebitosCartao(pCodigoCartao, "");
            }

                gridParcelas.Columns[gridParcelas.Columns.Count - 1].Visible = false;                  
            }
        }



        //Private Sub cmdAdicionar_Click()

        //On Error GoTo erro_cmdAdicionar_Click

        //    Dim cn As New ADODB.Connection
        //    Dim rs As New ADODB.Recordset

        //    cn.ConnectionString = AbreBancos.StrConectaPrincipal

        //    If Len(numeroContrato) < 3 Then MsgBox ("Um Cliente deve ser selecionado!!"): GoTo Done

        //    If (Len(textValidade.Text) = 4) And IsDate("01/" & Left(textValidade.Text, 2) & "/20" & Right(textValidade.Text, 2)) Then
        //        If CDate("01/" & Left(textValidade.Text, 2) & "/20" & Right(textValidade.Text, 2)) < DateAdd("D", Day(Date) - 1, Date) Then GoTo MENSAGEM
        //    Else
        //MENSAGEM:
        //        MsgBox ("Data inválida!!"): GoTo Done
        //    End If

        //    If Len(textCartao.Text) <> textCartao.MaxLength Then MsgBox ("Número de cartão inválido!!"): GoTo Done

        //    If MsgBox("Criar um novo cartão?", vbQuestion + vbYesNo) = vbYes And (VGPWGrupo = "SGB" Or VGPWGrupo = "ARB" Or VGPWGrupo = "DFC" Or VGPWGrupo = "DRC" Or VGPWGrupo = "GERRENOVA" Or VGPWGrupo = "SUPSAC" Or VGPWGrupo = "CENTRAL") Then

        //        GoTo Cartao
        //    Else
        //        GoTo Done
        //    End If

        //    If gridCartao.Row <> 1 And (VGPWGrupo = "SGB" Or VGPWGrupo = "ARB") Then
        //        If MsgBox("Alterar o cartão **** **** **** " & gridCartao.TextMatrix(gridCartao.Row, 2) + "?", vbQuestion + vbYesNo) = vbNo Then
        //            GoTo Done
        //        End If
        //    Else
        //        GoTo Done
        //    End If

        //Cartao:

        //    Dim sSQL As String

        //    Dim iCodigoCartao As Integer
        //    Dim iNumeroCartao As String
        //    Dim iNumeroSeguranca As String
        //    Dim iCodigoBanco As String
        //    Dim iVvalidade As String
        //    Dim iIsMonitoramento As Boolean

        //    If gridCartao.Row <> 0 Then iCodigoCartao = CInt(gridCartao.TextMatrix(gridCartao.Row, 5)) Else iCodigoCartao = 0

        //    iNumeroCartao = textCartao.Text
        //    iNumeroSeguranca = textSeguranca.Text
        //    iCodigoBanco = cbBanco.Text
        //    iIsMonitoramento = chkMonitoramento.Value = Checked
        //    iValidade = textValidade.Text

        //    sSQL = "exec SGB.Debito.pro_setDadosCartao " & iCodigoCartao & ",'" & iNumeroCartao & "','" & iNumeroSeguranca & "','" _
        //    & iCodigoBanco & "','" & numeroContrato & "'," & IIf(iIsMonitoramento, "1", "0") & ",'" & iValidade & "'"

        //    cn.Open
        //    cn.Execute sSQL

        //    Call carregaCartoes

        //Done:
        //    If rs.State <> 0 Then rs.Close
        //    If cn.State <> 0 Then cn.Close

        //    Exit Sub

        //erro_cmdAdicionar_Click:
        //    MsgBox Err.Description, vbCritical
        //    GoTo Done


        //'alter proc Debito.pro_setDadosCartao ( @idCartao int, @numeroCartao char(16), @numeroSeguranca char(3), @idBanco char(3),@numeroContrato varchar(10), @isMonitoramento bit )

        //End Sub

        //Private Sub cmdIncluir_Click()

        //On Error GoTo erro_cmdIncluir_Click

        //    Dim sSQL As String

        //    Dim cn As New ADODB.Connection
        //    Dim rs As New ADODB.Recordset

        //    cn.ConnectionString = AbreBancos.StrConectaPrincipal
        //    cn.Open

        //    If CInt(gridCartao.TextMatrix(gridCartao.Row, 5)) = 0 Then
        //        MsgBox "Um cartão deve ser selecionado!!", vbCritical
        //        GoTo Done
        //    End If

        //    sSQL = "SGB.Debito.pro_setMonitoramento " & gridCartao.TextMatrix(gridCartao.Row, 5) & "," & IIf(chkMonitoramento.Value = Checked, "1", "0")
        //    cn.Execute sSQL

        //    For iLinha = 1 To gridParcelas.Rows - 1
        //        If gridParcelas.TextMatrix(iLinha, 5) Then
        //            sSQL = "SGB.Debito.pro_setDebitoCartao " & gridCartao.TextMatrix(gridCartao.Row, 5) & "," & gridParcelas.TextMatrix(iLinha, 6) & "," & IIf(gridParcelas.TextMatrix(0, 5) = "Cancelar", "3", "0")
        //            cn.Execute sSQL
        //        End If
        //    Next

        //    chkMonitoramento.Value = Unchecked
        //    Call gridCartao_Click

        //Done:
        //    If rs.State <> 0 Then rs.Close
        //    If cn.State <> 0 Then cn.Close

        //    Exit Sub

        //erro_cmdIncluir_Click:
        //    MsgBox Err.Description, vbCritical
        //    GoTo Done

        //End Sub

        //Private Sub cmdPesquisar_Click()

        //    Call limpaCampos

        //    gridCartao.Rows = 1
        //    gridParcelas.Rows = 1

        //    numeroContrato = textContrato.Text
        //    Call carregaCartoes

        //    gridCartao.Row = 1
        //    Call gridCartao_Click

        //End Sub

        //Private Sub Form_Load()

        //    If VGPWGrupo = "SGB" Or VGPWGrupo = "ARB" Or VGPWGrupo = "BAIXA" Or VGPWGrupo = "EXPEDICAO" Then
        //        cmdAdicionar.Enabled = True
        //    Else
        //        cmdAdicionar.Enabled = False
        //    End If

        //    cmdAdicionar.Enabled = True

        //    Call limpaCampos
        //    Call carregaBancos
        //End Sub

        //Private Sub limpaCampos()

        //textCartao.Text = ""
        //textNome.Text = ""
        //textProduto.Text = ""
        //textSeguranca.Text = ""
        //textValidade.Text = ""
        //textFinalCartao.Text = ""
        //chkMonitoramento.Value = Unchecked
        //gridCartao.Rows = 1
        //gridParcelas.Rows = 1

        //End Sub

        //Private Sub gridCartao_Click()

        //    Dim iLinha As Integer
        //    Dim iValor As Boolean

        //    textFinalCartao.Text = "**** **** **** " & gridCartao.TextMatrix(gridCartao.Row, 2)
        //    cmdIncluir.Caption = "Incluir no Cartão " & textFinalCartao.Text

        //    For iLinha = 1 To gridParcelas.Rows - 1
        //        If gridParcelas.TextMatrix(iLinha, 5) Then Exit Sub
        //    Next

        //    If gridCartao.Row = 0 Then Exit Sub

        //    chkMonitoramento.Value = IIf(gridCartao.TextMatrix(gridCartao.Row, gridCartao.Cols - 1) = True, Checked, Unchecked)

        //    Call carregaParcelas(CInt(gridCartao.TextMatrix(gridCartao.Row, 5)))
        //End Sub

        //Private Sub gridParcelas_AfterEdit(ByVal Row As Long, ByVal Col As Long)

        //Dim iLinha As Integer
        //Dim iValor As Boolean

        //If Not gridParcelas.TextMatrix(Row, 2) Like "C*" Then Exit Sub

        //For iLinha = 1 To gridParcelas.Rows - 1
        //    If gridParcelas.TextMatrix(iLinha, 2) Like "C*" Then gridParcelas.TextMatrix(iLinha, 5) = gridParcelas.TextMatrix(Row, 5)
        //Next

        //    chkMonitoramento.Value = IIf(gridParcelas.TextMatrix(Row, 5), Checked, Unchecked)

        //End Sub

        //Private Sub gridParcelas_BeforeEdit(ByVal Row As Long, ByVal Col As Long, Cancel As Boolean)
        //    If Col <> 5 Then Cancel = True
        //End Sub

        //Private Sub textContrato_KeyPress(KeyAscii As Integer)
        //    If KeyAscii = 13 Then Call cmdPesquisar_Click
        //End Sub

    }
}