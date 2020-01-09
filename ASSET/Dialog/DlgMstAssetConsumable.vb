Imports System.Windows.Forms

Public Class DlgMstAssetConsumable

    Private channel_id As String
    Private DSN As String
    Private tbl_MstAssetConsumable As DataTable = clsDataset.CreateTblMstAssetconsumable()

    Private Event AfterRetrieve()

#Region " Constructor "
    Sub New(ByVal channel_id As String, ByVal DSN As String)
        Me.InitializeComponent()

        Me.channel_id = channel_id
        Me.DSN = DSN
    End Sub
#End Region

    Private Sub Retrieve()
        Dim criteria As String = ""

        If Me.obj_assetserial.Text.Trim <> "" Then
            criteria += String.Format("asset_serial = '{0}';", Me.obj_assetserial.Text)
        End If

        If Me.obj_itemdesciption.Text.Trim <> "" Then
            criteria += String.Format("asset_description like '%{0}%';", Me.obj_itemdesciption.Text)
        End If

        If criteria.Trim <> "" Then
            criteria = criteria.Trim(";")
            criteria = criteria.Replace(";", " and ")
        End If

        Try
            Me.tbl_MstAssetConsumable.Clear()

            Using consumable As New clsMstAssetConsumable(Me.channel_id, Me.DSN)
                consumable.Retrieve(Me.tbl_MstAssetConsumable, criteria)
            End Using

            RaiseEvent AfterRetrieve()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DlgMstAssetConsumable_AfterRetrieve() Handles Me.AfterRetrieve
        If Me.tbl_MstAssetConsumable.Rows.Count > 0 Then
            Me.btnOK.Enabled = True
        Else
            Me.btnOK.Enabled = False
        End If
    End Sub

    Private Sub DlgMstAssetConsumable_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DgvAssetConsumable.AutoGenerateColumns = False
        Me.DgvAssetConsumable.DataSource = Me.tbl_MstAssetConsumable
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
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
End Class
