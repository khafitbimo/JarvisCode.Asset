Public Class dlgUpdateStatusMaintenance
    Private CloseButtonIsPressed As Boolean

    Private status As String
    Private dsn As String
    Private channel As String
    Private line As Integer
    Private maintenance_id As String
    Private statusIncOut As String
    Private tabell As New DataTable
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As String
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = "maintenance_id = '" & Me.maintenance_id & "' and maintenancedetil_line = '" & Me.line & "'"
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
        Try
            tabell.Rows.Clear()
            oDataFiller.DataFill(Me.tabell, "as_TrnMaintenancedetil_Select", criteria)

            If statusIncOut = "INC" Then
                Me.obj_status.Items.Add("AVL")
                Me.obj_status.Items.Add("MISS")
                Me.obj_status.Items.Add("BRK")
                Me.obj_status.SelectedItem = Me.tabell.Rows(0)("maintenancedetil_statusinc")
            Else
                Me.obj_status.Items.Add("AVL")
                Me.obj_status.Items.Add("BRK")
                Me.obj_status.SelectedItem = Me.tabell.Rows(0).Item("maintenancedetil_statusout")
            End If

        Catch ex As Exception
        End Try
        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.status
        Else
            Return Nothing
        End If
    End Function

    Public Sub New(ByVal strDSN As String, ByVal strChannel As String, ByVal line As Integer, ByVal maintenance_id As String, ByVal statusIncOut As String)
        Me.dsn = strDSN
        Me.channel = strChannel
        Me.line = line
        Me.maintenance_id = maintenance_id
        Me.statusIncOut = statusIncOut
        InitializeComponent()
    End Sub

    Private Sub tbtn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtn_OK.Click
        Dim obj As Button = sender

        If obj.Name = "tbtn_OK" Then
            Me.uiTrnMaintenanceAsset_UpdateOutGoingAssetDetil()
            Me.CloseButtonIsPressed = True
        Else
            Me.CloseButtonIsPressed = False
        End If
        Me.Close()
    End Sub

    Private Function uiTrnMaintenanceAsset_UpdateOutGoingAssetDetil() As Boolean

        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
        Try
            Dim dbCmdupdate As OleDb.OleDbCommand
            If statusIncOut = "OUT" Then
                dbConn.Open()
                dbCmdupdate = New OleDb.OleDbCommand("as_TrnMaintenancedetil_Update", dbConn)
                dbCmdupdate.CommandType = CommandType.StoredProcedure
                dbCmdupdate.Parameters.Add("@maintenance_id", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenance_id").Value = Me.tabell.Rows(0).Item("maintenance_id")
                dbCmdupdate.Parameters.Add("@maintenancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "maintenancedetil_line").Value = Me.tabell.Rows(0).Item("maintenancedetil_line")
                dbCmdupdate.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id").Value = Me.tabell.Rows(0).Item("channel_id")
                dbCmdupdate.Parameters.Add("@maintenancedetil_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "maintenancedetil_barcode").Value = Me.tabell.Rows(0).Item("maintenancedetil_barcode")
                dbCmdupdate.Parameters.Add("@maintenancedetil_outdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenancedetil_outdate").Value = Me.tabell.Rows(0).Item("maintenancedetil_outdate")
                dbCmdupdate.Parameters.Add("@maintenancedetil_statusout", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenancedetil_statusout").Value = Me.obj_status.SelectedItem
                dbCmdupdate.Parameters.Add("@maintenance_incdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_incdate").Value = Me.tabell.Rows(0).Item("maintenance_incdate")
                dbCmdupdate.Parameters.Add("@maintenancedetil_statusinc", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenancedetil_statusinc").Value = Me.tabell.Rows(0).Item("maintenancedetil_statusinc")
                dbCmdupdate.Parameters.Add("@document_type", System.Data.OleDb.OleDbType.VarWChar, 6, "document_type").Value = Me.statusIncOut
            Else
                dbConn.Open()
                dbCmdupdate = New OleDb.OleDbCommand("as_TrnMaintenancedetil_Update", dbConn)
                dbCmdupdate.CommandType = CommandType.StoredProcedure
                dbCmdupdate.Parameters.Add("@maintenance_id", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenance_id").Value = Me.tabell.Rows(0).Item("maintenance_id")
                dbCmdupdate.Parameters.Add("@maintenancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "maintenancedetil_line").Value = Me.tabell.Rows(0).Item("maintenancedetil_line")
                dbCmdupdate.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id").Value = Me.tabell.Rows(0).Item("channel_id")
                dbCmdupdate.Parameters.Add("@maintenancedetil_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "maintenancedetil_barcode").Value = Me.tabell.Rows(0).Item("maintenancedetil_barcode")
                dbCmdupdate.Parameters.Add("@maintenancedetil_outdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenancedetil_outdate").Value = Me.tabell.Rows(0).Item("maintenancedetil_outdate")
                dbCmdupdate.Parameters.Add("@maintenancedetil_statusout", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenancedetil_statusout").Value = Me.tabell.Rows(0).Item("maintenancedetil_statusout")
                dbCmdupdate.Parameters.Add("@maintenance_incdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_incdate").Value = Me.tabell.Rows(0).Item("maintenance_incdate")
                dbCmdupdate.Parameters.Add("@maintenancedetil_statusinc", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenancedetil_statusinc").Value = Me.obj_status.SelectedItem
                dbCmdupdate.Parameters.Add("@document_type", System.Data.OleDb.OleDbType.VarWChar, 6, "document_type").Value = Me.statusIncOut
            End If

            dbCmdupdate.ExecuteNonQuery()
            dbCmdupdate.Dispose()
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        Me.Cursor = Cursors.Arrow

    End Function

    Private Sub tbtn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtn_Cancel.Click
        Me.CloseButtonIsPressed = True
        Me.Close()
    End Sub
End Class
