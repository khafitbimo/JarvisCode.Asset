Public Class dlgUpdateOutDetil
    Public ret_Outasset_id As String
    Private dsn As String
    Private channel As String
    Private tbl_TrnOutAssetdetil As DataTable = clsDataset.CreateTblTrnOutassetdetil()
    Private retNomor As String
    Private CloseButtonIsPressed As Boolean
    Private asset As String
    Private qty As String
    Private mLine As String
    Private cChannel, cOutasset_id, cLine, cBarcode, cQty, cIs_useable As String



    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As String
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = "outasset_id = '" & Me.ret_Outasset_id & "' and outasset_line = '" & Me.mLine & "'"

        Dim tabell As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)

        Try
            tabell.Rows.Clear()
            oDataFiller.DataFill(tabell, "as_TrnOutassetdetil_Select", criteria)

            Me.cChannel = tabell.Rows(0)("channel_id")
            Me.cOutasset_id = tabell.Rows(0)("outasset_id")
            Me.cBarcode = tabell.Rows(0)("barcode")
            Me.cQty = tabell.Rows(0)("qty")
            Me.cIs_useable = tabell.Rows(0)("is_useable")

            Me.NumericUpDown1.Value = Me.cQty


        Catch ex As Exception

        End Try


        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.qty
        Else
            Return Nothing
        End If
    End Function


    Private Sub cmd_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click
        Dim obj As Button = sender

        If obj.Name = "cmd_ok" Then
            Me.uiTrnOutGoingAsset_UpdateOutGoingAssetDetil()
            Me.CloseButtonIsPressed = True
        Else
            Me.CloseButtonIsPressed = False
        End If
        Me.Close()

    End Sub
    Public Sub New(ByVal strDSN As String, ByVal strChannel As String, ByVal str_Outasset_id As String, ByVal str_line As String)
        Me.dsn = strDSN
        Me.channel = strChannel
        Me.ret_Outasset_id = str_Outasset_id
        Me.mLine = str_line
        InitializeComponent()
    End Sub


    Private Function uiTrnOutGoingAsset_UpdateOutGoingAssetDetil() As Boolean

        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
        Dim cookie As Byte() = Nothing

        Try
            Dim dbCmdupdate As OleDb.OleDbCommand



            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbCmdupdate = New OleDb.OleDbCommand("as_TrnOutassetdetil_Update", dbConn)
            dbCmdupdate.CommandType = CommandType.StoredProcedure
            dbCmdupdate.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id").Value = Me.cChannel
            dbCmdupdate.Parameters.Add("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "outasset_id").Value = Me.cOutasset_id
            dbCmdupdate.Parameters.Add("@outasset_line", System.Data.OleDb.OleDbType.Integer, 4, "outasset_line").Value = Me.mLine
            dbCmdupdate.Parameters.Add("@barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "barcode").Value = Me.cBarcode
            dbCmdupdate.Parameters.Add("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty").Value = Me.NumericUpDown1.Value
            dbCmdupdate.Parameters.Add("@is_useable", System.Data.OleDb.OleDbType.Integer, 4, "is_useable").Value = Me.cIs_useable
            dbCmdupdate.Parameters.Add("@stat", System.Data.OleDb.OleDbType.VarWChar, 2).Direction = ParameterDirection.Output



            dbCmdupdate.ExecuteNonQuery()

            dbCmdupdate.Dispose()


        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
        Me.Cursor = Cursors.Arrow

    End Function


End Class
