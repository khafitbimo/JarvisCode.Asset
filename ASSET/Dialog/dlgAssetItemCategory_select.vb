Imports System.Windows.Forms

Public Class dlgAssetItemCategory_select

    Private tbl_ItemCategory As New DataTable

    Private Event AfterRetrieve()

#Region " Constructor "
    Sub New(ByVal tbl_ItemCategory As DataTable)
        Me.InitializeComponent()
        Me.tbl_ItemCategory = tbl_ItemCategory
    End Sub
#End Region

    Private Sub DlgAssetCategorySelect_AfterRetrieve() Handles Me.AfterRetrieve
        If Me.tbl_ItemCategory.Rows.Count > 0 Then
            Me.btnOK.Enabled = True
        Else
            Me.btnOK.Enabled = False
        End If
    End Sub

    Private Sub DlgAssetCategorySelect_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DgvAssetConsumable.AutoGenerateColumns = False
        Me.DgvAssetConsumable.DataSource = Me.tbl_ItemCategory
        If Me.tbl_ItemCategory.Rows.Count > 0 Then
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

    Private Sub obj_srcAssetCategory_TextChanged(sender As Object, e As EventArgs) Handles obj_srcItemCategory.TextChanged
        Me.tbl_ItemCategory.DefaultView.RowFilter = String.Format("category_name LIKE '%{0}%'", Me.obj_srcItemCategory.Text)
    End Sub
End Class
