Imports System.Windows.Forms

Public Class dlgAssetCategory_select

    Private channel_id, type_asset_id As String
    Private DSN As String
    Private tbl_AssetCategory As New DataTable

    Private Event AfterRetrieve()

#Region " Constructor "
    Sub New(ByVal channel_id As String, ByVal DSN As String, ByVal type_asset_id As String)
        Me.InitializeComponent()

        Me.channel_id = channel_id
        Me.DSN = DSN
        Me.type_asset_id = type_asset_id
    End Sub
#End Region

    Private Sub Retrieve()
        Dim criteria As String = String.Format("tipeasset_id = '{0}'", type_asset_id)

        If criteria.Trim <> "" Then
            criteria = criteria.Trim(";")
            criteria = criteria.Replace(";", " and ")
        End If

        Try
            Me.tbl_AssetCategory.Clear()

            Using penerimaan As New clsTrnPenerimaanBarang(Me.DSN)
                penerimaan.RetrieveAssetTypeCategory(Me.tbl_AssetCategory, criteria)
            End Using

            RaiseEvent AfterRetrieve()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DlgAssetCategorySelect_AfterRetrieve() Handles Me.AfterRetrieve
        If Me.tbl_AssetCategory.Rows.Count > 0 Then
            Me.btnOK.Enabled = True
        Else
            Me.btnOK.Enabled = False
        End If
    End Sub

    Private Sub DlgAssetCategorySelect_Load(sender As Object, e As EventArgs) Handles Me.Load
        Retrieve()
        Me.DgvAssetConsumable.AutoGenerateColumns = False
        Me.DgvAssetConsumable.DataSource = Me.tbl_AssetCategory
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Me.Retrieve()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DgvAssetConsumable_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAssetConsumable.CellDoubleClick
        If e.ColumnIndex > -1 And e.RowIndex > -1 Then
            Me.btnOK.PerformClick()
        End If
    End Sub

    Private Sub obj_srcCategory_TextChanged(sender As Object, e As EventArgs) Handles obj_srcAssetCategory.TextChanged
        Me.tbl_AssetCategory.DefaultView.RowFilter = String.Format("categoryasset_id LIKE '%{0}%'", Me.obj_srcAssetCategory.Text)
    End Sub
End Class
