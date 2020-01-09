
Public Class dlgTrnPenerimaanBarang_Select_Detil_GQ_Jasa
    Private DSN As String
    Private clsTrnRequest As clsTrnRequest
    Private tbl_TrnRequestDetil As DataTable = Me.CreateViewTblTrnTerimajasaSelectRequestDetil()
    Private tbl_MstTipeasset As DataTable = clsDataset.CreateTblMstTipeasset()
    Private request_id, request_lines As String
    Private requestObjective As clsTrnRequest.Objective

#Region " Datasource "
    Private Function CreateViewTblTrnTerimajasaSelectRequestDetil() As DataTable
        Dim tbl As DataTable = clsDataset.CreateViewTblTrnTerimaJasaSelectRequestDetil()

        tbl.Columns.Add("col_pilih", GetType(Boolean))
        tbl.Columns.Add("qty", GetType(Integer)).DefaultValue = 1
        tbl.Columns.Add("asset_type", GetType(String)).DefaultValue = "Non Asset Program"

        Return tbl
    End Function
#End Region

#Region " Constructor & Default Function"

    Sub New(ByVal dsn As String, ByVal request_id As String, ByVal request_lines As String)
        Me.InitializeComponent()

        Me.DSN = dsn
        Me.request_id = request_id
        Me.requestObjective = ASSET.clsTrnRequest.Objective.Rental
        Me.request_lines = request_lines

        'Select Case requestObjective
        '    Case ASSET.clsTrnRequest.Objective.Rental
        Me.colAssetType.Visible = False
        '    Case ASSET.clsTrnRequest.Objective.Wardrobe
        'Me.colAssetType.Visible = True
        'End Select
    End Sub

#End Region

    Private Sub Retrieve()
        Me.clsTrnRequest = New clsTrnRequest(Me.DSN)
        Dim Criteria As String
        If Me.request_lines <> "" Then
            Criteria = String.Format(" request_id = '{0}' AND requestdetil_qtyoutstanding > 0 AND requestdetil_line NOT IN ({1})", Me.request_id, Me.request_lines)
        Else
            Criteria = String.Format(" request_id = '{0}' AND requestdetil_qtyoutstanding > 0 ", Me.request_id)
        End If

        Me.clsTrnRequest.RetrieveRequestDetil(tbl_TrnRequestDetil, Criteria, Me.requestObjective)
    End Sub

    Private Sub dlgTrnPenerimaanBarang_Select_Purchase_GQ_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.requestObjective = ASSET.clsTrnRequest.Objective.Rental Then
            Me.colQty.Visible = False
            Me.colQtyOutstanding.HeaderText = "Qty"
        End If

        Me.DgvTrnRequest.AutoGenerateColumns = False

        Me.colAssetType.DataSource = Me.tbl_MstTipeasset
        Me.colAssetType.ValueMember = "tipeasset_id"
        Me.colAssetType.DisplayMember = "tipeasset_id"

        Me.DgvTrnRequest.DataSource = Me.tbl_TrnRequestDetil

        Using tipeAsset As New clsMstTipeAsset(Me.DSN)
            tipeAsset.Retrieve(Me.tbl_MstTipeasset, "")
        End Using

        Me.Retrieve()
        Me.tbl_TrnRequestDetil.AcceptChanges()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function Form_Error() As Boolean
        For Each viewRow As DataGridViewRow In Me.DgvTrnRequest.Rows
            If viewRow.Cells(colQty.Name).ErrorText <> "" Then
                Return True
            End If
        Next
    End Function

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If Me.Form_Error() Then
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub DgvTrnRequest_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTrnRequest.CellValueChanged
        If Me.DgvTrnRequest.CurrentRow IsNot Nothing Then
            If Me.DgvTrnRequest.Columns(e.ColumnIndex) Is Me.colQty Then
                Dim currentRow As DataRow = CType(Me.DgvTrnRequest.CurrentRow.DataBoundItem, DataRowView).Row
                Dim qtyOutstanding As Integer = currentRow.Item("requestdetil_qtyoutstanding")
                Dim qty As Integer = currentRow.Item("qty")

                If qty > qtyOutstanding Then
                    Me.DgvTrnRequest.CurrentCell.ErrorText = "Qty melebihi qty outstanding."
                Else
                    Me.DgvTrnRequest.CurrentCell.ErrorText = ""
                End If
            End If
        End If

    End Sub
End Class
