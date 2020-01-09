
Public Class dlgTrnTerimaJasaUsed_Editing

    Private dsn As String
    Private channel_id As String
    Private terimabarang_id As String
    Private orderdetil_line As Integer
    Private terimabarang_line As Integer
    Private total_days As Integer
    Private isDaysManual As String
    Private isUser As String
    Private isLock As Byte
    Private rekanan As Decimal

    Private tbl_objective As DataTable
    Private tbl_editingOrderDetilErr As DataTable = New DataTable
    Private order_id As String

    Private retObj As Object

    Private tbl_terimaJasaUsed_temps As DataTable = clsDataset.CreateTblTrnTerimajasausedediting

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)


        Me.Text = "List Shift Editing Order"

        Me.tbl_terimaJasaUsed_temps.DefaultView.RowFilter = String.Format(" order_id = '{0}' AND orderdetil_line = {1}", Me.order_id, Me.orderdetil_line)

        Me.DgvListBPJ.DataSource = Me.tbl_terimaJasaUsed_temps '.DefaultView
        ' ''Me.DgvListBPJ.DataSource = Me.tbl_trnTerimaJasaUsed
        oDataFiller.DataFill(tbl_editingOrderDetilErr, "as_TrnOrderDetilBpjEditingErr_Select", String.Format("order_id = '{0}'", Me.order_id))

        Me.FormatDgvTrnTerimajasausedediting(Me.DgvListBPJ)

        MyBase.ShowDialog(owner)

        Return Me.retObj

    End Function
    Private Function FormatDgvTrnTerimajasausedediting(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShift1 As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cShift2 As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cShift3 As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasaused_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cBoot1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBoot2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBoot3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_usage1_start As New DataGridViewMaskedEditColumn
        Dim cTerimajasaused_usage1_end As New DataGridViewMaskedEditColumn
        Dim cTerimajasaused_usage2_start As New DataGridViewMaskedEditColumn
        Dim cTerimajasaused_usage2_end As New DataGridViewMaskedEditColumn
        Dim cTerimajasaused_usage3_start As New DataGridViewMaskedEditColumn
        Dim cTerimajasaused_usage3_end As New DataGridViewMaskedEditColumn
        Dim cTerimajasaused_usagetotal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_usageepstotal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

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

        cTerimajasaused_date.Name = "terimajasaused_date"
        cTerimajasaused_date.HeaderText = "Editing Date"
        cTerimajasaused_date.DataPropertyName = "terimajasaused_date"
        cTerimajasaused_date.Width = 100
        cTerimajasaused_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_date.Visible = True
        cTerimajasaused_date.ReadOnly = True
        cTerimajasaused_date.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimajasa_descr.Name = "terimajasa_descr"
        cTerimajasa_descr.HeaderText = "Descr"
        cTerimajasa_descr.DataPropertyName = "terimajasa_descr"
        cTerimajasa_descr.Width = 100
        cTerimajasa_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_descr.Visible = True
        cTerimajasa_descr.ReadOnly = False

        cShift1.Name = "shift1"
        cShift1.HeaderText = "Shift 1"
        cShift1.DataPropertyName = "shift1"
        cShift1.Width = 60
        cShift1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift1.Visible = True
        cShift1.ReadOnly = False

        cShift2.Name = "shift2"
        cShift2.HeaderText = "Shift 2"
        cShift2.DataPropertyName = "shift2"
        cShift2.Width = 60
        cShift2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift2.Visible = True
        cShift2.ReadOnly = False

        cShift3.Name = "shift3"
        cShift3.HeaderText = "Shift 3"
        cShift3.DataPropertyName = "shift3"
        cShift3.Width = 60
        cShift3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift3.Visible = True
        cShift3.ReadOnly = False

        cTerimajasaused_check.Name = "terimajasaused_check"
        cTerimajasaused_check.HeaderText = "Select"
        cTerimajasaused_check.DataPropertyName = "terimajasaused_check"
        cTerimajasaused_check.Width = 50
        cTerimajasaused_check.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimajasaused_check.Visible = True
        cTerimajasaused_check.ReadOnly = False

        cBoot1.Name = "boot1"
        cBoot1.HeaderText = "Boot 1"
        cBoot1.DataPropertyName = "boot1"
        cBoot1.Width = 70
        cBoot1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot1.Visible = True
        cBoot1.ReadOnly = False

        cBoot2.Name = "boot2"
        cBoot2.HeaderText = "Boot 2"
        cBoot2.DataPropertyName = "boot2"
        cBoot2.Width = 70
        cBoot2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot2.Visible = True
        cBoot2.ReadOnly = False

        cBoot3.Name = "boot3"
        cBoot3.HeaderText = "Boot 3"
        cBoot3.DataPropertyName = "boot3"
        cBoot3.Width = 70
        cBoot3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot3.Visible = True
        cBoot3.ReadOnly = False

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

        cTerimajasaused_usage1_start.Name = "terimajasaused_usage1_start"
        cTerimajasaused_usage1_start.HeaderText = "Usage 1 Start"
        cTerimajasaused_usage1_start.DataPropertyName = "terimajasaused_usage1_start"
        cTerimajasaused_usage1_start.Mask = "##:##"
        cTerimajasaused_usage1_start.ValidatingType = GetType(DateTime)
        cTerimajasaused_usage1_start.Width = 100
        cTerimajasaused_usage1_start.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usage1_start.Visible = True
        cTerimajasaused_usage1_start.ReadOnly = False

        cTerimajasaused_usage1_end.Name = "terimajasaused_usage1_end"
        cTerimajasaused_usage1_end.HeaderText = "Usage 1 End"
        cTerimajasaused_usage1_end.DataPropertyName = "terimajasaused_usage1_end"
        cTerimajasaused_usage1_end.Mask = "##:##"
        cTerimajasaused_usage1_end.ValidatingType = GetType(DateTime)
        cTerimajasaused_usage1_end.Width = 100
        cTerimajasaused_usage1_end.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usage1_end.Visible = True
        cTerimajasaused_usage1_end.ReadOnly = False

        cTerimajasaused_usage2_start.Name = "terimajasaused_usage2_start"
        cTerimajasaused_usage2_start.HeaderText = "Usage 2 Start"
        cTerimajasaused_usage2_start.DataPropertyName = "terimajasaused_usage2_start"
        cTerimajasaused_usage2_start.Mask = "##:##"
        cTerimajasaused_usage2_start.ValidatingType = GetType(DateTime)
        cTerimajasaused_usage2_start.Width = 100
        cTerimajasaused_usage2_start.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usage2_start.Visible = True
        cTerimajasaused_usage2_start.ReadOnly = False

        cTerimajasaused_usage2_end.Name = "terimajasaused_usage2_end"
        cTerimajasaused_usage2_end.HeaderText = "Usage 2 End"
        cTerimajasaused_usage2_end.DataPropertyName = "terimajasaused_usage2_end"
        cTerimajasaused_usage2_end.Mask = "##:##"
        cTerimajasaused_usage2_end.ValidatingType = GetType(DateTime)
        cTerimajasaused_usage2_end.Width = 100
        cTerimajasaused_usage2_end.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usage2_end.Visible = True
        cTerimajasaused_usage2_end.ReadOnly = False

        cTerimajasaused_usage3_start.Name = "terimajasaused_usage3_start"
        cTerimajasaused_usage3_start.HeaderText = "Usage 3 Start"
        cTerimajasaused_usage3_start.DataPropertyName = "terimajasaused_usage3_start"
        cTerimajasaused_usage3_start.Mask = "##:##"
        cTerimajasaused_usage3_start.ValidatingType = GetType(DateTime)
        cTerimajasaused_usage3_start.Width = 100
        cTerimajasaused_usage3_start.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usage3_start.Visible = True
        cTerimajasaused_usage3_start.ReadOnly = False

        cTerimajasaused_usage3_end.Name = "terimajasaused_usage3_end"
        cTerimajasaused_usage3_end.HeaderText = "Usage 3 End"
        cTerimajasaused_usage3_end.DataPropertyName = "terimajasaused_usage3_end"
        cTerimajasaused_usage3_end.Mask = "##:##"
        cTerimajasaused_usage3_end.ValidatingType = GetType(DateTime)
        cTerimajasaused_usage3_end.Width = 100
        cTerimajasaused_usage3_end.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usage3_end.Visible = True
        cTerimajasaused_usage3_end.ReadOnly = False

        cTerimajasaused_usagetotal.Name = "terimajasaused_usagetotal"
        cTerimajasaused_usagetotal.HeaderText = "Total Usage"
        cTerimajasaused_usagetotal.DataPropertyName = "terimajasaused_usagetotal"
        cTerimajasaused_usagetotal.Width = 100
        cTerimajasaused_usagetotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usagetotal.Visible = True
        cTerimajasaused_usagetotal.ReadOnly = True
        cTerimajasaused_usagetotal.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimajasaused_usageepstotal.Name = "terimajasaused_usageepstotal"
        cTerimajasaused_usageepstotal.HeaderText = "Eps. Total"
        cTerimajasaused_usageepstotal.DataPropertyName = "terimajasaused_usageepstotal"
        cTerimajasaused_usageepstotal.Width = 80
        cTerimajasaused_usageepstotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usageepstotal.Visible = True
        cTerimajasaused_usageepstotal.ReadOnly = True
        cTerimajasaused_usageepstotal.DefaultCellStyle.BackColor = Color.Gainsboro

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimajasaused_check, cTerimajasaused_date, cTerimajasa_descr, _
         cShift1, cBoot1, cTerimajasaused_usage1_start, cTerimajasaused_usage1_end, _
         cShift2, cBoot2, cTerimajasaused_usage2_start, cTerimajasaused_usage2_end, _
         cShift3, cBoot3, cTerimajasaused_usage3_start, cTerimajasaused_usage3_end, _
          cTerimajasaused_usagetotal, cTerimajasaused_usageepstotal, _
         cChannel_id, cTerimajasa_id, cTerimajasa_line, cOrder_id, cOrderdetil_line})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        If Me.isUser = "bma" Then
            objDgv.ReadOnly = True
        End If
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.dlgTrnTerimaJasaUsed_editing_FormError() = False Then
            Exit Sub
        End If

        Dim thisRetObj As Collection = New Collection
        Dim retTblOrderDays As DataTable = clsDataset.CreateTblTrnTerimajasausedediting
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
        ByVal order_id As String, ByVal rekanan_id As Decimal)
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
        Me.rekanan = rekanan_id

        InitializeComponent()
    End Sub

    Private Function dlgTrnTerimaJasaUsed_editing_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False
        Dim criteria As String = String.Empty
        Dim table_temps As DataTable = New DataTable
        Dim i As Integer
        Dim status As String = String.Empty
        Dim usage1_start As Decimal
        Dim usage1_end As Decimal
        Dim usage2_start As Decimal
        Dim usage2_end As Decimal
        Dim usage3_start As Decimal
        Dim usage3_end As Decimal
        Dim message As String = ""
        Dim message_temp As String = String.Empty
        Dim total_usage As Decimal

        'cek isi cell
        Dim cell_usage1_start, cell_usage1_end, cell_usage2_start, cell_usage2_end, cell_usage3_start, cell_usage3_end As DataGridViewCell
        Dim cell_shift1, cell_shift2, cell_shift3, cell_boot1, cell_boot2, cell_boot3 As DataGridViewCell
        Dim dgv_error, row_error As Boolean

        Try


            For i = 0 To Me.DgvListBPJ.Rows.Count - 1
                total_usage = 0
                usage1_start = 0
                usage1_end = 0
                usage2_start = 0
                usage2_end = 0
                usage3_start = 0
                usage3_end = 0

                row_error = False
                If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_check").Value, 0) = 1 Then
                    Me.tbl_editingOrderDetilErr.DefaultView.RowFilter = String.Empty
                    Me.tbl_editingOrderDetilErr.DefaultView.RowFilter = String.Format("order_id = '{0}' AND orderdetil_line = '{1}'", Me.DgvListBPJ.Rows(i).Cells("order_id").Value, Me.DgvListBPJ.Rows(i).Cells("orderdetil_line").Value)

                    If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift1").Value, 0) = 1 Then

                        message = "Shift 1 tidak pernah di order"
                        cell_shift1 = Me.DgvListBPJ.Rows(i).Cells("shift1")
                        cell_boot1 = Me.DgvListBPJ.Rows(i).Cells("boot1")
                        If cell_shift1.Value = Me.tbl_editingOrderDetilErr.DefaultView.Item(0).Item("shift1") Then
                            cell_shift1.ErrorText = ""
                        Else
                            cell_shift1.ErrorText = message
                            row_error = True
                        End If

                        message = "Boot ini tidak pernah di order"
                        If cell_boot1.Value = Me.tbl_editingOrderDetilErr.DefaultView.Item(0).Item("boot1") Then
                            cell_boot1.ErrorText = ""
                        Else
                            cell_boot1.ErrorText = message
                            row_error = True
                        End If

                        message = "Usage time start diluar shift 1"
                        cell_usage1_start = Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage1_start")
                        usage1_start = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage1_start").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage1_start").Value, 4, 2) / 60)
                        If Me.rekanan <> 3485 And Me.rekanan <> 237 Then
                            If usage1_start >= 9 Or usage1_start <= 17 Then
                                cell_usage1_start.ErrorText = ""
                            Else
                                cell_usage1_start.ErrorText = message
                                row_error = True
                            End If
                        End If

                        message = "Usage time end diluar shift 1"
                        cell_usage1_end = Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage1_end")
                        usage1_end = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage1_end").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage1_end").Value, 4, 2) / 60)
                        If Me.rekanan <> 3485 And Me.rekanan <> 237 Then
                            If usage1_end >= 9 Or usage1_end <= 17 Then
                                cell_usage1_end.ErrorText = ""
                            Else
                                cell_usage1_end.ErrorText = message
                                row_error = True
                            End If
                        End If

                        If usage1_end - usage1_start > 8 Then
                            message_temp = "jumlah jam di shift 1 lebih dari 8 jam"
                            row_error = True
                        End If
                    End If

                    If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift2").Value, 0) = 1 Then
                        message = "Shift 2 tidak pernah di order"
                        cell_shift2 = Me.DgvListBPJ.Rows(i).Cells("shift2")
                        cell_boot2 = Me.DgvListBPJ.Rows(i).Cells("boot2")
                        If cell_shift2.Value = Me.tbl_editingOrderDetilErr.DefaultView.Item(0).Item("shift2") Then
                            cell_shift2.ErrorText = ""
                        Else
                            cell_shift2.ErrorText = message
                            row_error = True
                        End If

                        message = "Boot ini tidak pernah di order"
                        If cell_boot2.Value = Me.tbl_editingOrderDetilErr.DefaultView.Item(0).Item("boot2") Then
                            cell_boot2.ErrorText = ""
                        Else
                            cell_boot2.ErrorText = message
                            row_error = True
                        End If

                        message = "Usage time start diluar shift 2"
                        cell_usage2_start = Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage2_start")
                        usage2_start = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage2_start").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage2_start").Value, 4, 2) / 60)
                        If Me.rekanan <> 3485 And Me.rekanan <> 237 Then
                            If usage2_start >= 17 Or usage2_start <= 25 Then
                                cell_usage2_start.ErrorText = ""
                            Else
                                cell_usage2_start.ErrorText = message
                                row_error = True
                            End If
                        End If

                        message = "Usage time end diluar shift 2"
                        cell_usage2_end = Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage2_end")
                        usage2_end = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage2_end").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage2_end").Value, 4, 2) / 60)
                        If Me.rekanan <> 3485 And Me.rekanan <> 237 Then
                            If usage2_end >= 17 Or usage2_end <= 25 Then
                                cell_usage2_end.ErrorText = ""
                            Else
                                cell_usage2_end.ErrorText = message
                                row_error = True
                            End If
                        End If
                        If usage2_end - usage2_start > 8 Then
                            message_temp &= vbCrLf & " Jumlah jam di shift 2 lebih dari 8 jam"
                            row_error = True
                        End If

                    End If

                    If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift3").Value, 0) = 1 Then
                     
                        message = "Shift 3 tidak pernah di order"
                        cell_shift3 = Me.DgvListBPJ.Rows(i).Cells("shift3")
                        cell_boot3 = Me.DgvListBPJ.Rows(i).Cells("boot3")
                        If cell_shift3.Value = Me.tbl_editingOrderDetilErr.DefaultView.Item(0).Item("shift3") Then
                            cell_shift3.ErrorText = ""
                        Else
                            cell_shift3.ErrorText = message
                            row_error = True
                        End If

                        message = "Boot ini tidak pernah di order"
                        If cell_boot3.Value = Me.tbl_editingOrderDetilErr.DefaultView.Item(0).Item("boot3") Then
                            cell_boot3.ErrorText = ""
                        Else
                            cell_boot3.ErrorText = message
                            row_error = True
                        End If

                        message = "Usage time start diluar shift 3"
                        cell_usage3_start = Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage3_start")
                        usage3_start = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage3_start").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage3_start").Value, 4, 2) / 60)
                        If Me.rekanan <> 3485 And Me.rekanan <> 237 Then
                            If usage3_start >= 25 And usage3_start <= 33 Then
                                cell_usage3_start.ErrorText = ""
                            Else
                                cell_usage3_start.ErrorText = message
                                row_error = True
                            End If
                        End If

                        message = "Usage time end diluar shift 3"
                        cell_usage3_end = Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage3_end")
                        usage3_end = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage3_end").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usage3_end").Value, 4, 2) / 60)
                        If Me.rekanan <> 3485 And Me.rekanan <> 237 Then
                            If usage3_end >= 25 And usage3_end <= 33 Then
                                cell_usage3_end.ErrorText = ""
                            Else
                                cell_usage3_end.ErrorText = message
                                row_error = True
                            End If
                        End If
                        If usage3_end - usage3_start > 8 Then
                            message_temp &= vbCrLf & " Jumlah jam di shift 3 lebih dari 8 jam"
                            row_error = True
                        End If

                    End If
                End If

                total_usage = (usage1_end - usage1_start) + (usage2_end - usage2_start) + (usage3_end - usage3_start)
                Me.DgvListBPJ.Rows(i).Cells("terimajasaused_usagetotal").Value = CDec(total_usage)

                If row_error Then
                    dgv_error = True
                    Me.DgvListBPJ.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                Else
                    Me.DgvListBPJ.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If

            Next

            If dgv_error Then
                If message_temp = String.Empty Then
                    message_temp = " Data ada yang salah entry "
                End If
                Throw New Exception(message_temp)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgListEditing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
        Return True
    End Function

End Class
