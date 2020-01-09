
Public Class dlgUpdateDepresiasiDetil
    Private tabell As New DataTable
    Private CloseButtonIsPressed As Boolean
    Private dsn As String
    Private status As New DataTable

    Private channel_id As String
    Private depresiasi_id As String
    Private asset_barcode As String
    Private deskripsi As String
    Private username As String

    Private nilai_depre As Decimal
    Private tahun As Integer
    Private bulan As Integer
    Private cost_begining As Decimal
    Private depre_beginning As Decimal
    Private cost_additional As Decimal
    Private depre_addtional As Decimal


    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As DataTable
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = String.Format(" depresiasi_id = '{0}' AND td.asset_barcode = '{1}'", Me.depresiasi_id, Me.asset_barcode) '"depre_id = '" & Me.maintenance_id & "' and maintenancedetil_line = '" & Me.line & "'"
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
        Try
            tabell.Rows.Clear()
            oDataFiller.DataFill(Me.tabell, "as_TrnDepresiasidetil_Select", criteria)

            If Me.tabell.Rows.Count > 0 Then
                Me.obj_barcode.Text = Me.tabell.Rows(0).Item("asset_barcode")
                Me.obj_description.Text = Me.deskripsi
                Me.obj_cost_deductional.Text = Format(Me.tabell.Rows(0).Item("cost_deductional"), "###,##0.00")
                Me.obj_depre_deductional.Text = Format(Me.tabell.Rows(0).Item("depre_deductional"), "###,##0.00")
                Me.obj_cost_ending.Text = Format(Me.tabell.Rows(0).Item("cost_ending"), "###,##0.00")
                Me.obj_depre_ending.Text = Format(Me.tabell.Rows(0).Item("depre_ending"), "###,##0.00")
                Me.cost_begining = Format(Me.tabell.Rows(0).Item("cost_beginning"), "###,##0.00")
                Me.depre_beginning = Format(Me.tabell.Rows(0).Item("depre_beginning"), "###,##0.00")
                Me.cost_additional = Format(Me.tabell.Rows(0).Item("cost_additional"), "###,##0.00")
                Me.depre_addtional = Format(Me.tabell.Rows(0).Item("depre_additional"), "###,##0.00")
                Me.obj_remark.Text = clsUtil.IsDbNull(Me.tabell.Rows(0).Item("depresiasi_remark"), "")
                Me.obj_depre_additional.Text = Format(Me.tabell.Rows(0).Item("depre_additional"), "###,##0.00")
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

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.obj_depre_ending.Text = String.Empty Or Me.obj_depre_ending.Text = "" Then
            MsgBox("Remark box cannot be empty")
            Exit Sub
        End If

        Me.Update_depreValue()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.CloseButtonIsPressed = True
        Me.Close()
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal strChannel As String, ByVal str_Depresiasi_id As String, _
                    ByVal str_Barcode As String, ByVal str_deskripsi As String, _
                    ByVal username As String, ByVal tahun As Integer, ByVal bulan As Integer)

        Me.dsn = strDSN
        Me.channel_id = strChannel
        Me.depresiasi_id = str_Depresiasi_id
        Me.asset_barcode = str_Barcode
        Me.deskripsi = str_deskripsi
        Me.username = username
        Me.tahun = tahun
        Me.bulan = bulan

        InitializeComponent()
    End Sub

    Private Function Update_depreValue() As Boolean
        Dim cost_deductional As Decimal
        Dim depre_deductional As Decimal
        Dim cost_ending As Decimal
        Dim depre_ending As Decimal

        cost_deductional = Me.obj_cost_deductional.Text
        depre_deductional = Me.obj_depre_deductional.Text
        cost_ending = Me.cost_begining + Me.cost_additional - cost_deductional
        depre_ending = Me.depre_beginning + Me.depre_addtional - depre_deductional

        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
        Dim cookie As Byte() = Nothing

        Try
            Dim dbCmdupdate As OleDb.OleDbCommand

            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbCmdupdate = New OleDb.OleDbCommand("as_TrnDepresiasidetil_Update", dbConn)
            dbCmdupdate.CommandType = CommandType.StoredProcedure
            dbCmdupdate.Parameters.Add("@depresiasi_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.depresiasi_id
            dbCmdupdate.Parameters.Add("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me.obj_barcode.Text
            dbCmdupdate.Parameters.Add("@cost_deductional", System.Data.OleDb.OleDbType.Numeric, 9).Value = cost_deductional
            dbCmdupdate.Parameters.Add("@depre_deductional", System.Data.OleDb.OleDbType.Numeric, 9).Value = depre_deductional
            dbCmdupdate.Parameters.Add("@cost_ending", System.Data.OleDb.OleDbType.Numeric, 9).Value = cost_ending
            dbCmdupdate.Parameters.Add("@depre_ending", System.Data.OleDb.OleDbType.Numeric, 9).Value = depre_ending
            dbCmdupdate.Parameters.Add("@depresiasi_remark", System.Data.OleDb.OleDbType.VarWChar, 200).Value = Me.obj_remark.Text
            dbCmdupdate.Parameters.Add("@edit_by", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.username

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


    Private Sub obj_depre_deductional_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_depre_deductional.Validated
        Dim a As Decimal = clsUtil.IsDbNull(Me.obj_depre_deductional.Text, 0)
        Me.obj_depre_deductional.Text = Format(a, "###,##0.00")
    End Sub

    Private Sub obj_cost_deductional_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_cost_deductional.Validated
        Dim a As Decimal = clsUtil.IsDbNull(Me.obj_cost_deductional.Text, 0)
        Me.obj_cost_deductional.Text = Format(a, "###,##0.00")
    End Sub
End Class
