
Public Class dlgTrnPenerimaanBarang_Select_Header_GQ
    Private DSN As String
    Private channel_id As String
    Private clsTrnRequest As clsTrnRequest
    Private tbl_TrnRequest As DataTable = clsDataset.CreateViewTblTrnPenerimaanbarangSelectRequest()
    Private strukturunit_id As Decimal
    Private requestObjective As clsTrnRequest.Objective

    Sub New(ByVal DSN As String, ByVal channel_id As String, ByVal strukturunit_id As Decimal, ByVal requestObjective As clsTrnRequest.Objective)
        Me.InitializeComponent()

        Me.DSN = DSN
        Me.channel_id = channel_id
        Me.strukturunit_id = strukturunit_id
        Me.requestObjective = requestObjective

        Me.clsTrnRequest = New clsTrnRequest(Me.DSN)
    End Sub

    Private Sub Retrieve()
        Dim Criteria As String = String.Format(" channel_id = '{0}'", Me.channel_id)

        Criteria = Criteria + String.Format(" and strukturunit_id = {0}", strukturunit_id)

        Try
            Me.clsTrnRequest.RetrieveRequest(tbl_TrnRequest, Criteria, Me.requestObjective)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub chk_request_id_CheckedChanged(sender As Object, e As EventArgs) Handles chk_request_id.CheckedChanged
        obj_request_id.Enabled = chk_request_id.Checked
    End Sub

    Private Sub obj_request_id_TextChanged(sender As Object, e As EventArgs) Handles obj_request_id.TextChanged
        Dim filter As String = ""

        filter = String.Format("request_id LIKE '%{0}%'", Me.obj_request_id.Text)

        Me.tbl_TrnRequest.DefaultView.RowFilter = filter
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DgvTrnRequest_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTrnRequest.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If

        Me.btnSelect.PerformClick()
    End Sub

    Private Sub dlgTrnPenerimaanBarang_Select_Header_GQ_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DgvTrnRequest.DataSource = Me.tbl_TrnRequest
        Me.Retrieve()
    End Sub
End Class
