Public Class dlgAddRV_CIPAsset 
    Private tbl_TrnJurnaldetil As DataTable = CreateTblTrnJurnalRvCIPAsset()
    Private dsn As String
    Private channel_id As String
    Private CloseButtonIsPressed As Boolean = False
    Private dtReturn As DataTable

#Region " Constructor "
    Sub New(ByVal dsn As String, ByVal channel_id As String)
        Me.InitializeComponent()
        Me.dsn = dsn
        Me.channel_id = channel_id
    End Sub
#End Region

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As DataTable
        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return dtReturn
        Else
            Return Nothing
        End If
    End Function

    Private Function CreateTblTrnJurnalRvCIPAsset()
        Dim tbl As DataTable = clsDataset.CreateTblTrnJurnaldetil()

        tbl.Columns.Add(New DataColumn("pilih", GetType(System.Boolean)))
        tbl.Columns("pilih").DefaultValue = False

        Return tbl
    End Function

    Private Function LoadDataRVCIPAsset() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim filler As New clsDataFiller(Me.dsn)
            Dim criteria As String = String.Format(" channel_id = '{0}'", Me.channel_id)

            If Me.chkSrchRV.Checked = True Then
                If criteria <> String.Empty Then
                    criteria = criteria + " AND (" + clsUtil.RefParserDX(" jurnal_id", Me.txtRVID).ToString + ")"
                Else
                    criteria = "(" + clsUtil.RefParserDX(" jurnal_id", Me.txtRVID).ToString + ")"
                End If
                'criteria = IIf(criteria <> String.Empty, criteria + " AND (" + clsUtil.RefParserDX(" jurnal_id", Me.txtRVID).ToString + ")", "(" + clsUtil.RefParserDX(" jurnal_id", Me.txtRVID).ToString + ")")
            End If

            Me.tbl_TrnJurnaldetil.Clear()
            filler.DataFill(Me.tbl_TrnJurnaldetil, "act_JurnalRVCIP_ASSETSelect", criteria)
            GCRvListCIP.DataSource = Me.tbl_TrnJurnaldetil

            If Me.tbl_TrnJurnaldetil.Rows.Count > 0 Then
                Me.btnOk.Enabled = True
            Else
                Me.btnOk.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        Finally
            Me.Cursor = Cursors.Arrow
        End Try
    End Function

    Private Sub btnLoadData_Click(sender As Object, e As EventArgs) Handles btnLoadData.Click
        LoadDataRVCIPAsset()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            Me.dtReturn = Me.tbl_TrnJurnaldetil.Select(" pilih = 1", "jurnal_id").CopyToDataTable
            Me.CloseButtonIsPressed = True
            Me.Close()
        Catch ex As Exception
            If ex.Message = "The source contains no DataRows." Then
                MsgBox("Belum ada data yang dipilih !!")
            Else
                MsgBox(ex.Message)
            End If
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSelectALL_Click(sender As Object, e As EventArgs) Handles btnSelectALL.Click
        If Me.btnSelectALL.Text = "Select ALL" Then
            For Each dtRow As DataRow In Me.tbl_TrnJurnaldetil.Rows
                dtRow("pilih") = 1
            Next
            Me.btnSelectALL.Text = "Deselect ALL"
        Else
            For Each dtRow As DataRow In Me.tbl_TrnJurnaldetil.Rows
                dtRow("pilih") = 0
            Next
            Me.btnSelectALL.Text = "Select ALL"
        End If

    End Sub
End Class