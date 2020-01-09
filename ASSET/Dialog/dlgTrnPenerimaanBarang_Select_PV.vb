Imports System.Windows.Forms

Public Class dlgTrnPenerimaanBarang_Select_PV


    Private tblJurnalPV As DataTable = Me.CreateTblJurnalPV()
    Private receive_id As String
    Private DSN As String
    Private filler As clsDataFiller
    Private listPV As clsRVListPV

#Region " Dataset "
    Private Function CreateTblJurnalPV() As DataTable
        Dim tbl As New DataTable

        tbl.Columns.Add("jurnal_id", GetType(String)).DefaultValue = ""
        tbl.Columns.Add("jurnaldetil_descr", GetType(String)).DefaultValue = ""
        tbl.Columns.Add("foreign", GetType(Decimal)).DefaultValue = 0
        tbl.Columns.Add("idr", GetType(Decimal)).DefaultValue = 0
        tbl.Columns.Add("rekanan_id", GetType(Decimal)).DefaultValue = 0
        tbl.Columns.Add("rekanan_name", GetType(String)).DefaultValue = ""
        tbl.Columns.Add("budget_name", GetType(String)).DefaultValue = ""
        tbl.Columns.Add("currency_id", GetType(String)).DefaultValue = ""

        Return tbl
    End Function
#End Region

#Region " Constructor "
    Sub New(ByVal receive_id As String, ByVal DSN As String)
        Me.InitializeComponent()

        Me.receive_id = receive_id
        Me.DSN = DSN
        Me.filler = New clsDataFiller(Me.DSN)
        Me.listPV = New clsRVListPV(Me.DSN)
    End Sub
#End Region

    Private Sub Retrieve()
        Dim criteria As String = ""

        If Me.obj_rekanan_id.Text.Trim <> "" Then
            criteria = criteria & String.Format(" rekanan_id = {0}", Me.obj_rekanan_id.Text)
        End If

        Me.tblJurnalPV.Clear()

        Try
            Me.listPV.Retrieve(Me.tblJurnalPV, criteria)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgTrnPenerimaanBarang_Select_PV_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DgvPV.AutoGenerateColumns = False
        Me.DgvPV.DataSource = Me.tblJurnalPV
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Me.Retrieve()
    End Sub

    Private Sub DgvPV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPV.CellDoubleClick
        If e.ColumnIndex > -1 And e.RowIndex > -1 Then
            Me.OK_Button.PerformClick()
        End If
    End Sub

    Private Sub btnRekanan_Click(sender As Object, e As EventArgs) Handles btnRekanan.Click
        Dim rekanan_id As String
        Dim dlg As dlgSearch = New dlgSearch()
        Dim retData As String
        Dim tbl_MstRekanan As New DataTable
        Dim rekanan As New clsMstRekanan(Me.DSN)

        rekanan.Retrieve(tbl_MstRekanan, "")
        retData = dlg.OpenDialog(Me, tbl_MstRekanan, "rekanan")
        rekanan_id = retData

        If rekanan_id IsNot Nothing Then
            Me.obj_rekanan_id.Text = rekanan_id
        End If
    End Sub
End Class
