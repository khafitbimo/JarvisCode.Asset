Public Class dlgTrnTerimaJasaUsed_Talent
    Private dsn As String
    Private channel_id As String
    Private terimabarang_id As String
    Private orderdetil_line As Integer
    Private terimabarang_line As Integer
    Private total_days As Integer
    Private isDaysManual As String
    Private isUser As String
    Private isLock As Byte

    Private tbl_objective As DataTable
    Private order_id As String

    Private retObj As Object

    Private tbl_terimaJasaUsed_temps As DataTable = clsDataset.CreateTblTrnTerimajasausedTalent

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = String.Empty
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)


        Me.Text = "List Episode Talent Order"

        criteria = String.Format(" terimajasa_id = '{0}' AND terimajasa_line = {1} ", Me.terimabarang_id, Me.orderdetil_line)

        Me.tbl_terimaJasaUsed_temps.DefaultView.RowFilter = String.Format(" order_id = '{0}' AND orderdetil_line = {1}", Me.order_id, Me.orderdetil_line)

        Me.DgvListBPJ.DataSource = Me.tbl_terimaJasaUsed_temps '.DefaultView
        ' ''Me.DgvListBPJ.DataSource = Me.tbl_trnTerimaJasaUsed


        Me.FormatDgvTrnTerimajasaused(Me.DgvListBPJ)

        MyBase.ShowDialog(owner)

        Return Me.retObj

    End Function
    Private Function FormatDgvTrnTerimajasaused(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_lineeps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasaused_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cTerimajasa_id.Name = "terimajasa_id"
        cTerimajasa_id.HeaderText = "terimajasa_id"
        cTerimajasa_id.DataPropertyName = "terimajasa_id"
        cTerimajasa_id.Width = 100
        cTerimajasa_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_id.Visible = False
        cTerimajasa_id.ReadOnly = False

        cTerimajasa_line.Name = "terimajasa_line"
        cTerimajasa_line.HeaderText = "terimajasa_line"
        cTerimajasa_line.DataPropertyName = "terimajasa_line"
        cTerimajasa_line.Width = 100
        cTerimajasa_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_line.Visible = False
        cTerimajasa_line.ReadOnly = False

        cTerimajasa_lineeps.Name = "terimajasa_lineeps"
        cTerimajasa_lineeps.HeaderText = "terimajasa_lineeps"
        cTerimajasa_lineeps.DataPropertyName = "terimajasa_lineeps"
        cTerimajasa_lineeps.Width = 100
        cTerimajasa_lineeps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_lineeps.Visible = False
        cTerimajasa_lineeps.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order_id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = False

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "orderdetil_line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = False
        cOrderdetil_line.ReadOnly = False

        cOrderdetiluse_line.Name = "orderdetiluse_line"
        cOrderdetiluse_line.HeaderText = "orderdetiluse_line"
        cOrderdetiluse_line.DataPropertyName = "orderdetiluse_line"
        cOrderdetiluse_line.Width = 100
        cOrderdetiluse_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetiluse_line.Visible = False
        cOrderdetiluse_line.ReadOnly = False

        cTerimajasa_eps.Name = "terimajasa_eps"
        cTerimajasa_eps.HeaderText = "Eps."
        cTerimajasa_eps.DataPropertyName = "terimajasa_eps"
        cTerimajasa_eps.Width = 50
        cTerimajasa_eps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimajasa_eps.Visible = True
        cTerimajasa_eps.ReadOnly = True
        cTerimajasa_eps.DefaultCellStyle.Format = "#,##0"
        cTerimajasa_eps.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimajasaused_check.Name = "terimajasaused_check"
        cTerimajasaused_check.HeaderText = "Select"
        cTerimajasaused_check.DataPropertyName = "terimajasaused_check"
        cTerimajasaused_check.Width = 40
        cTerimajasaused_check.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimajasaused_check.Visible = True
        cTerimajasaused_check.ReadOnly = False

        cTerimajasaused_qty.Name = "terimajasaused_qty"
        cTerimajasaused_qty.HeaderText = "Qty"
        cTerimajasaused_qty.DataPropertyName = "terimajasaused_qty"
        cTerimajasaused_qty.Width = 75
        cTerimajasaused_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTerimajasaused_qty.Visible = True
        cTerimajasaused_qty.ReadOnly = False
        cTerimajasaused_qty.DefaultCellStyle.Format = "#,##0"

        cTerimajasaused_descr.Name = "terimajasaused_descr"
        cTerimajasaused_descr.HeaderText = "Description"
        cTerimajasaused_descr.DataPropertyName = "terimajasaused_descr"
        cTerimajasaused_descr.Width = 200
        cTerimajasaused_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_descr.Visible = True
        cTerimajasaused_descr.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimajasaused_check, cTerimajasa_eps, cTerimajasaused_qty, cTerimajasaused_descr, _
        cChannel_id, cTerimajasa_id, cTerimajasa_line, cTerimajasa_lineeps, cOrder_id, _
        cOrderdetil_line, cOrderdetiluse_line})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        If Me.isUser = "bma" Then
            objDgv.ReadOnly = True
        End If
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.dlgTrnTerimaJasaUsed_Talent_FormError() = False Then
            Exit Sub
        End If

        Dim thisRetObj As Collection = New Collection
        Dim retTblOrderDays As DataTable = clsDataset.CreateTblTrnTerimajasausedTalent

        For i As Integer = 0 To Me.tbl_terimaJasaUsed_temps.Rows.Count - 1
            If Me.tbl_terimaJasaUsed_temps.Rows(i).Item("terimajasaused_check") Is DBNull.Value Then
                Me.tbl_terimaJasaUsed_temps.Rows(i).Item("terimajasaused_check") = 0
            End If
        Next

        retTblOrderDays = Me.tbl_terimaJasaUsed_temps.Copy
        thisRetObj.Add(Me.tbl_terimaJasaUsed_temps.Copy, "tblUsed")
        retObj = thisRetObj
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.total_days = 9999
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Sub New(ByVal strDSN As String, ByVal channel_id As String, ByVal terimabarang_id As String, _
        ByVal orderdetil_line As Integer, ByVal isDaysManual As String, ByVal terimabarang_line As Integer, _
        ByVal isUser As String, ByVal isLock As Byte, ByVal tbl_terimaJasaUsed_temps As DataTable, _
        ByVal order_id As String)
        Me.dsn = strDSN
        Me.channel_id = channel_id
        Me.terimabarang_id = terimabarang_id
        Me.orderdetil_line = orderdetil_line
        Me.isDaysManual = isDaysManual
        Me.terimabarang_line = terimabarang_line
        Me.isUser = isUser
        Me.isLock = isLock
        Me.tbl_terimaJasaUsed_temps = tbl_terimaJasaUsed_temps
        Me.order_id = order_id

        InitializeComponent()
    End Sub

    Private Sub DgvListBPJ_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DgvListBPJ.CellValidating
        If DgvListBPJ.Columns(e.ColumnIndex).Name <> "terimabarang_dt" Then
            Exit Sub
        End If

        Try
            Dim strError As String
            strError = "ERROR"

            Dim tanggal As String
            Dim tgl As Byte
            Dim max_tgl As Byte
            Dim bln As Byte
            Dim thn As Integer

            tanggal = e.FormattedValue
            tgl = Mid(tanggal, 1, 2)
            bln = Mid(tanggal, 4, 2)
            thn = Mid(tanggal, 7, 4)
            max_tgl = Date.DaysInMonth(thn, bln)

            If Len(thn) <> 4 Then
                DgvListBPJ.Rows(e.RowIndex).ErrorText = strError
                e.Cancel = True
                MsgBox("Wrong year")
                Exit Sub
            Else
                DgvListBPJ.Rows(e.RowIndex).ErrorText = String.Empty
                e.Cancel = False
            End If

            If bln <= 0 Or bln > 12 Then
                DgvListBPJ.Rows(e.RowIndex).ErrorText = strError
                e.Cancel = True
                MsgBox("Wrong month")
                Exit Sub
            Else
                DgvListBPJ.Rows(e.RowIndex).ErrorText = String.Empty
                e.Cancel = False
            End If

            If tgl <= 0 Or tgl > max_tgl Then
                DgvListBPJ.Rows(e.RowIndex).ErrorText = strError
                e.Cancel = True
                MsgBox("Wrong date")
            Else
                DgvListBPJ.Rows(e.RowIndex).ErrorText = String.Empty
                e.Cancel = False
            End If

        Catch ex As Exception
            Dim strError As String
            strError = "ERROR"
            DgvListBPJ.Rows(e.RowIndex).ErrorText = strError
            e.Cancel = True
            MsgBox("Wrong format date")
        End Try

    End Sub
    Private Function dlgTrnTerimaJasaUsed_Talent_FormError() As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_err As DataTable = New DataTable
        Dim i As Integer
        Dim cell_qty As DataGridViewCell
        Dim dgv_error, row_error As Boolean
        Dim message As String = ""
        Dim cookie As Byte() = Nothing

        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")
            For i = 0 To Me.tbl_terimaJasaUsed_temps.DefaultView.Count - 1
                If clsUtil.IsDbNull(Me.tbl_terimaJasaUsed_temps.DefaultView.Item(i).Item("terimajasaused_check"), 0) = 1 Then

                    dbCmd = New OleDb.OleDbCommand("as_TrnTerimajasausedTalent_qtyOutstandingErr", dbConn)
                    dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarWChar)
                    dbCmd.Parameters("@order_id").Value = Me.tbl_terimaJasaUsed_temps.DefaultView.Item(i).Item("order_id")
                    dbCmd.Parameters.Add("@orderdetil_line", Data.OleDb.OleDbType.Integer)
                    dbCmd.Parameters("@orderdetil_line").Value = Me.tbl_terimaJasaUsed_temps.DefaultView.Item(i).Item("orderdetil_line")
                    dbCmd.Parameters.Add("@orderdetiluse_line", Data.OleDb.OleDbType.Integer)
                    dbCmd.Parameters("@orderdetiluse_line").Value = Me.tbl_terimaJasaUsed_temps.DefaultView.Item(i).Item("orderdetiluse_line")
                    dbCmd.Parameters.Add("@terimajasa_id", Data.OleDb.OleDbType.VarWChar)
                    dbCmd.Parameters("@terimajasa_id").Value = Me.tbl_terimaJasaUsed_temps.DefaultView.Item(i).Item("terimajasa_id")
                    dbCmd.CommandType = CommandType.StoredProcedure
                    dbDA = New OleDb.OleDbDataAdapter(dbCmd)
                    tbl_err.Clear()

                    Try
                        dbConn.Open()
                        clsApplicationRole.SetAppRole(dbConn, cookie)
                        dbDA.Fill(tbl_err)
                        If tbl_err.Rows.Count > 0 Then
                            row_error = False
                            message = "Qty Bpj melebihi Qty Order"
                            cell_qty = Me.DgvListBPJ.Rows(i).Cells("terimajasaused_qty")
                            If cell_qty.Value - clsUtil.IsDbNull(tbl_err.Rows(0).Item("qty_total"), 0) > 0 Then
                                cell_qty.ErrorText = message
                                row_error = True
                            Else
                                cell_qty.ErrorText = ""
                            End If
                        End If

                        If row_error Then
                            dgv_error = True
                            Me.DgvListBPJ.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                        Else
                            Me.DgvListBPJ.Rows(i).DefaultCellStyle.BackColor = Color.White
                        End If

                        If dgv_error Then
                            Throw New Exception("Data ada yang salah isi!")
                        End If

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Exclamation" & ": List Days Talent Order()", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    Finally
                        clsApplicationRole.UnsetAppRole(dbConn, cookie)
                        dbConn.Close()
                    End Try
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgTrnTerimaJasaUsed_Talent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
        Return True
    End Function
End Class
