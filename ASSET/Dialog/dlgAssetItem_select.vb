Imports System.Windows.Forms

Public Class dlgAssetItem_select

    Private tbl_AssetItem As New DataTable

    Private Event AfterRetrieve()

#Region " Constructor "
    Sub New(ByVal tbl_AssetItem As DataTable)
        Me.InitializeComponent()

        Me.tbl_AssetItem = tbl_AssetItem
    End Sub
#End Region

    Private Sub DlgAssetCategorySelect_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DgvAssetConsumable.AutoGenerateColumns = False
        Me.DgvAssetConsumable.DataSource = Me.tbl_AssetItem
        If Me.tbl_AssetItem.Rows.Count > 0 Then
            Me.btnOK.Enabled = True
        Else
            Me.btnOK.Enabled = False
        End If
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

    Private Sub obj_srcItem_TextChanged(sender As Object, e As EventArgs) Handles obj_srcItem.TextChanged
        Me.tbl_AssetItem.DefaultView.RowFilter = String.Format("item_name LIKE '%{0}%'", Me.obj_srcItem.Text)

    End Sub
End Class
