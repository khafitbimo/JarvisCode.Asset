Imports System.Windows.Forms

Public Class dlgListOrder_days
    Private dsn As String
    Private channel_id As String
    Private terimabarang_id As String
    Private orderdetil_line As Integer
    Private terimabarang_line As Integer
    Private total_days As Integer
    Private isDaysManual As String
    Private isUser As String
    Private isLock As Byte
    Private tbl_trnOrderDetilDays As DataTable = clsDataset.CreateTblTrnTerimabarangused
    Private retTblOrderDays As DataTable = clsDataset.CreateTblTrnTerimabarangused
    Private tbl_objective As DataTable


    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Integer
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = String.Empty
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)

        If isDaysManual = "RO" Then
            Me.Text = "List days Rental Order"
        ElseIf isDaysManual = "MO" Then
            Me.Text = "List days Maintenance Order"

        ElseIf isDaysManual = "TO" Then
            Me.Text = "List Eps Talent Order"
        Else
            Me.Text = "List days manual"
        End If

        If isDaysManual = "MANUAL" Then
            criteria = String.Format(" AND terimabarang_id = '{0}' AND terimabarang_line = {1} ", Me.terimabarang_id, Me.terimabarang_line)
        Else
            criteria = String.Format(" AND terimabarang_id = '{0}' AND terimabarang_line = {1} ", Me.terimabarang_id, Me.orderdetil_line)

        End If

        Dim row_objective As DataRow
        tbl_objective = New DataTable

        tbl_objective.Columns.Add("objective_id")
        tbl_objective.Columns.Add("objective_name")
        row_objective = tbl_objective.NewRow
        row_objective.Item("objective_id") = "-- PILIH --"
        row_objective.Item("objective_name") = "-- PILIH --"
        tbl_objective.Rows.Add(row_objective)
        row_objective = tbl_objective.NewRow
        row_objective.Item("objective_id") = "Good"
        row_objective.Item("objective_name") = "Good"
        tbl_objective.Rows.Add(row_objective)
        row_objective = tbl_objective.NewRow
        row_objective.Item("objective_id") = "Fair"
        row_objective.Item("objective_name") = "Fair"
        tbl_objective.Rows.Add(row_objective)
        row_objective = tbl_objective.NewRow
        row_objective.Item("objective_id") = "Poor"
        row_objective.Item("objective_name") = "Poor"
        tbl_objective.Rows.Add(row_objective)

        Me.tbl_trnOrderDetilDays.Clear()
        oDataFiller.DataFill(Me.tbl_trnOrderDetilDays, "as_TrnTerimabarangdetilused_select", criteria, Me.channel_id)
        Me.DgvListBPJ.DataSource = Me.tbl_trnOrderDetilDays

        
        If isDaysManual = "MANUAL" Then
            Me.FormatDgvTrnTerimabarangusedManual(Me.DgvListBPJ)
        Else
            Me.FormatDgvTrnTerimabarangused(Me.DgvListBPJ)
            ' ''Me.check_daysIsUse()
        End If

        Me.DgvListBPJ.Columns("terimabarang_dt").DefaultCellStyle.BackColor = Color.Gainsboro
        ' ''Me.DgvListBPJ.Columns("terimabarangused_qty").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_usagestart").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_usageend").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_status").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_remark").DefaultCellStyle.BackColor = Color.Lavender

        MyBase.ShowDialog(owner)

        Return Me.total_days
       
    End Function
    Private Function FormatDgvTrnTerimabarangused(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' ''Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_lineday As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_detilused_note As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        Dim cTerimabarangused_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangused_usageStart As New DataGridViewMaskedEditColumn
        Dim cTerimabarangused_usageEnd As New DataGridViewMaskedEditColumn
        Dim cTerimabarangused_status As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cTerimabarangused_remark As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        ' ''cSelect.Name = "select"
        ' ''cSelect.HeaderText = "Select"
        ' ''cSelect.DataPropertyName = "select"
        ' ''cSelect.Width = 50
        ' ''cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' ''cSelect.Frozen = True
        ' ''cSelect.Visible = True
        ' ''If Me.isUser = "bma" Or Me.isLock = 1 Then
        ' ''    cSelect.ReadOnly = True
        ' ''Else
        ' ''    cSelect.ReadOnly = False
        ' ''End If

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = True

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "RV Number"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 120
        cTerimabarang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_id.Visible = False
        cTerimabarang_id.ReadOnly = True

        cTerimabarang_line.Name = "terimabarang_line"
        cTerimabarang_line.HeaderText = "Line"
        cTerimabarang_line.DataPropertyName = "terimabarang_line"
        cTerimabarang_line.Width = 80
        cTerimabarang_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_line.Visible = False
        cTerimabarang_line.ReadOnly = True

        cTerimabarang_lineday.Name = "terimabarang_lineday"
        cTerimabarang_lineday.HeaderText = "Line Days"
        cTerimabarang_lineday.DataPropertyName = "terimabarang_lineday"
        cTerimabarang_lineday.Width = 100
        cTerimabarang_lineday.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_lineday.Visible = False
        cTerimabarang_lineday.ReadOnly = True

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = True

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Order Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = False
        cOrderdetil_line.ReadOnly = True

        cOrderdetiluse_line.Name = "orderdetiluse_line"
        cOrderdetiluse_line.HeaderText = "orderdetiluse_line"
        cOrderdetiluse_line.DataPropertyName = "orderdetiluse_line"
        cOrderdetiluse_line.Width = 100
        cOrderdetiluse_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetiluse_line.Visible = False
        cOrderdetiluse_line.ReadOnly = True

        cTerimabarang_dt.Name = "terimabarang_dt"
        cTerimabarang_dt.HeaderText = "Date"
        cTerimabarang_dt.DataPropertyName = "terimabarang_dt"
        cTerimabarang_dt.Width = 80
        cTerimabarang_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_dt.Visible = True
        cTerimabarang_dt.ReadOnly = True
        cterimabarang_dt.DefaultCellStyle.Format = "dd/MM/yyyy"

        cTerimabarang_detilused_note.Name = "terimabarang_detilused_note"
        cTerimabarang_detilused_note.HeaderText = "terimabarang_detilused_note"
        cTerimabarang_detilused_note.DataPropertyName = "terimabarang_detilused_note"
        cTerimabarang_detilused_note.Width = 100
        cTerimabarang_detilused_note.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_detilused_note.Visible = False
        cTerimabarang_detilused_note.ReadOnly = True

        cTerimabarang_check.Name = "terimabarang_check"
        cTerimabarang_check.HeaderText = "Select"
        cTerimabarang_check.DataPropertyName = "terimabarang_check"
        cTerimabarang_check.Width = 50
        cTerimabarang_check.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimabarang_check.Visible = True
        cTerimabarang_check.ReadOnly = False
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTerimabarang_check.ReadOnly = True
        Else
            cTerimabarang_check.ReadOnly = False
        End If

        cTerimabarangused_qty.Name = "terimabarangused_qty"
        cTerimabarangused_qty.HeaderText = "Qty"
        cTerimabarangused_qty.DataPropertyName = "terimabarangused_qty"
        cTerimabarangused_qty.Width = 60
        cTerimabarangused_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarangused_qty.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTerimabarangused_qty.ReadOnly = True
        Else
            cTerimabarangused_qty.ReadOnly = False
        End If

        cTerimabarangused_usageStart.Mask = "##:##"
        cTerimabarangused_usageStart.ValidatingType = GetType(DateTime)
        cTerimabarangused_usageStart.Name = "terimabarangused_usagestart"
        cTerimabarangused_usageStart.HeaderText = "Usage Start"
        cTerimabarangused_usageStart.DataPropertyName = "terimabarangused_usagestart"
        cTerimabarangused_usageStart.Width = 100
        cTerimabarangused_usageStart.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarangused_usageStart.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTerimabarangused_usageStart.ReadOnly = True
        Else
            cTerimabarangused_usageStart.ReadOnly = False
        End If

        cTerimabarangused_usageEnd.Mask = "##:##"
        cTerimabarangused_usageEnd.ValidatingType = GetType(DateTime)
        cTerimabarangused_usageEnd.Name = "terimabarangused_usageend"
        cTerimabarangused_usageEnd.HeaderText = "Usage End"
        cTerimabarangused_usageEnd.DataPropertyName = "terimabarangused_usageend"
        cTerimabarangused_usageEnd.Width = 100
        cTerimabarangused_usageEnd.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarangused_usageEnd.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTerimabarangused_usageEnd.ReadOnly = True
        Else
            cTerimabarangused_usageEnd.ReadOnly = False
        End If
        cTerimabarangused_status.Name = "terimabarangused_status"
        cTerimabarangused_status.HeaderText = "Status"
        cTerimabarangused_status.DataPropertyName = "terimabarangused_status"
        cTerimabarangused_status.DataSource = Me.tbl_objective
        cTerimabarangused_status.ValueMember = "objective_id"
        cTerimabarangused_status.DisplayMember = "objective_name"
        cTerimabarangused_status.Width = 120
        cTerimabarangused_status.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarangused_status.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTerimabarangused_status.ReadOnly = True
        Else
            cTerimabarangused_status.ReadOnly = False
        End If

        cTerimabarangused_remark.Name = "terimabarangused_remark"
        cTerimabarangused_remark.HeaderText = "Remark"
        cTerimabarangused_remark.DataPropertyName = "terimabarangused_remark"
        cTerimabarangused_remark.Width = 200
        cTerimabarangused_remark.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarangused_remark.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTerimabarangused_remark.ReadOnly = True
        Else
            cTerimabarangused_remark.ReadOnly = False
        End If


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimabarang_check, cTerimabarang_dt, cTerimabarangused_qty, cTerimabarangused_usageStart, cTerimabarangused_usageEnd, _
       cTerimabarangused_status, cTerimabarangused_remark, cChannel_id, cTerimabarang_id, _
         cTerimabarang_line, cTerimabarang_lineday, cOrder_id, _
         cOrderdetil_line, cOrderdetiluse_line, cTerimabarang_detilused_note}) ', cTerimabarang_check})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function
    Private Function FormatDgvTrnTerimabarangusedManual(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_lineday As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_detilused_note As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_check As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTgl As New Calender.CalendarColumn
        Dim cTerimabarangused_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangused_usageStart As New DataGridViewMaskedEditColumn
        Dim cTerimabarangused_usageEnd As New DataGridViewMaskedEditColumn
        Dim cTerimabarangused_status As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cTerimabarangused_remark As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTeri As New DataGridViewMaskedEditColumn

     
        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 80
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = True

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "RV Number"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 120
        cTerimabarang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = True

        cTerimabarang_line.Name = "terimabarang_line"
        cTerimabarang_line.HeaderText = "Line"
        cTerimabarang_line.DataPropertyName = "terimabarang_line"
        cTerimabarang_line.Width = 80
        cTerimabarang_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_line.Visible = True
        cTerimabarang_line.ReadOnly = True

        cTerimabarang_lineday.Name = "terimabarang_lineday"
        cTerimabarang_lineday.HeaderText = "Line days"
        cTerimabarang_lineday.DataPropertyName = "terimabarang_lineday"
        cTerimabarang_lineday.Width = 80
        cTerimabarang_lineday.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_lineday.Visible = True
        cTerimabarang_lineday.ReadOnly = True

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order No."
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = True

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Order Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = False
        cOrderdetil_line.ReadOnly = True

        cOrderdetiluse_line.Name = "orderdetiluse_line"
        cOrderdetiluse_line.HeaderText = "orderdetiluse_line"
        cOrderdetiluse_line.DataPropertyName = "orderdetiluse_line"
        cOrderdetiluse_line.Width = 100
        cOrderdetiluse_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetiluse_line.Visible = False
        cOrderdetiluse_line.ReadOnly = True

        cTerimabarang_dt.Name = "terimabarang_dt"
        cTerimabarang_dt.HeaderText = "Date"
        cTerimabarang_dt.DataPropertyName = "terimabarang_dt"
        cTerimabarang_dt.Width = 100
        cTerimabarang_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_dt.Visible = False
        cTerimabarang_dt.ReadOnly = False
        cTerimabarang_dt.DefaultCellStyle.Format = "dd/MM/yyyy"

        cTgl.Name = "terimabarang_dt"
        cTgl.HeaderText = "Date"
        cTgl.DataPropertyName = "terimabarang_dt"
        cTgl.Width = 100
        cTgl.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTgl.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTgl.ReadOnly = True
        Else
            cTgl.ReadOnly = False
        End If
        cTgl.DefaultCellStyle.Format = "dd/MM/yyyy"


        cTerimabarang_detilused_note.Name = "terimabarang_detilused_note"
        cTerimabarang_detilused_note.HeaderText = "Notes"
        cTerimabarang_detilused_note.DataPropertyName = "terimabarang_detilused_note"
        cTerimabarang_detilused_note.Width = 100
        cTerimabarang_detilused_note.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_detilused_note.Visible = False
        cTerimabarang_detilused_note.ReadOnly = True

        cTerimabarang_check.Name = "terimabarang_check"
        cTerimabarang_check.HeaderText = "Approved"
        cTerimabarang_check.DataPropertyName = "terimabarang_check"
        cTerimabarang_check.Width = 100
        cTerimabarang_check.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_check.Visible = False
        cTerimabarang_check.ReadOnly = True

        cTerimabarangused_qty.Name = "terimabarangused_qty"
        cTerimabarangused_qty.HeaderText = "Qty"
        cTerimabarangused_qty.DataPropertyName = "terimabarangused_qty"
        cTerimabarangused_qty.Width = 60
        cTerimabarangused_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarangused_qty.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTerimabarangused_qty.ReadOnly = True
        Else
            cTerimabarangused_qty.ReadOnly = False
        End If

        cTerimabarangused_usageStart.Mask = "##:##"
        cTerimabarangused_usageStart.ValidatingType = GetType(DateTime)
        cTerimabarangused_usageStart.Name = "terimabarangused_usagestart"
        cTerimabarangused_usageStart.HeaderText = "Usage Start"
        cTerimabarangused_usageStart.DataPropertyName = "terimabarangused_usagestart"
        cTerimabarangused_usageStart.Width = 100
        cTerimabarangused_usageStart.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarangused_usageStart.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTerimabarangused_usageStart.ReadOnly = True
        Else
            cTerimabarangused_usageStart.ReadOnly = False
        End If

        cTerimabarangused_usageEnd.Mask = "##:##"
        cTerimabarangused_usageEnd.ValidatingType = GetType(DateTime)
        cTerimabarangused_usageEnd.Name = "terimabarangused_usageend"
        cTerimabarangused_usageEnd.HeaderText = "Usage End"
        cTerimabarangused_usageEnd.DataPropertyName = "terimabarangused_usageend"
        cTerimabarangused_usageEnd.Width = 100
        cTerimabarangused_usageEnd.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarangused_usageEnd.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTerimabarangused_usageEnd.ReadOnly = True
        Else
            cTerimabarangused_usageEnd.ReadOnly = False
        End If

        cTerimabarangused_status.Name = "terimabarangused_status"
        cTerimabarangused_status.HeaderText = "Status"
        cTerimabarangused_status.DataPropertyName = "terimabarangused_status"
        cTerimabarangused_status.DataSource = Me.tbl_objective
        cTerimabarangused_status.ValueMember = "objective_id"
        cTerimabarangused_status.DisplayMember = "objective_name"
        cTerimabarangused_status.Width = 120
        cTerimabarangused_status.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarangused_status.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTerimabarangused_status.ReadOnly = True
        Else
            cTerimabarangused_status.ReadOnly = False
        End If

        cTerimabarangused_remark.Name = "terimabarangused_remark"
        cTerimabarangused_remark.HeaderText = "Remark"
        cTerimabarangused_remark.DataPropertyName = "terimabarangused_remark"
        cTerimabarangused_remark.Width = 200
        cTerimabarangused_remark.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarangused_remark.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cTerimabarangused_remark.ReadOnly = True
        Else
            cTerimabarangused_remark.ReadOnly = False
        End If

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cChannel_id, cTerimabarang_dt, cTgl, cTerimabarangused_qty, _
        cTerimabarangused_usageStart, cTerimabarangused_usageEnd, cTerimabarangused_status, cTerimabarangused_remark, cTerimabarang_lineday, _
        cTerimabarang_id, cTerimabarang_line, cOrder_id, cOrderdetil_line, _
        cOrderdetiluse_line, cTerimabarang_detilused_note, cTerimabarang_check})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = True
        objDgv.AllowUserToDeleteRows = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim tbl_trnOrderDetilDays_changes As DataTable
        Dim i As Integer
        Dim success As Boolean
        Dim count_dgv As Integer
        Dim MasterDataState As System.Data.DataRowState
        Me.total_days = 0

        count_dgv = Me.tbl_trnOrderDetilDays.Rows.Count - 1

      


        If isDaysManual = "RO" Or isDaysManual = "TO" Then
            Me.DgvListBPJ.EndEdit()
            Me.BindingContext(Me.tbl_trnOrderDetilDays).EndCurrentEdit()
            tbl_trnOrderDetilDays_changes = Me.tbl_trnOrderDetilDays.GetChanges()

            For i = 0 To count_dgv
                If clsUtil.IsDbNull(Me.tbl_trnOrderDetilDays.Rows(i).Item("terimabarang_check"), 0) = 1 Then
                    Me.total_days += 1
                End If
            Next
            For i = 0 To tbl_trnOrderDetilDays_changes.Rows.Count - 1
                If tbl_trnOrderDetilDays_changes.Rows(i).Item("terimabarang_check") Is DBNull.Value Then
                    tbl_trnOrderDetilDays_changes.Rows(i).Item("terimabarang_check") = 0
                End If
            Next

            If tbl_trnOrderDetilDays_changes IsNot Nothing Then
                For i = 0 To tbl_trnOrderDetilDays_changes.Rows.Count - 1
                    If tbl_trnOrderDetilDays_changes.Rows(i).RowState = DataRowState.Added Then
                        tbl_trnOrderDetilDays_changes.Rows(i).Item("terimabarang_id") = terimabarang_id
                    End If
                Next
                success = Me.save_manual(terimabarang_id, tbl_trnOrderDetilDays_changes, MasterDataState)
                If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnTerimaJasa_SaveDetil(tbl_TrnTerimabarangdetil_Changes)")
                Me.tbl_trnOrderDetilDays.AcceptChanges()
            End If
            ' ''For i = 0 To count_dgv
            ' ''    If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("select").Value, False) = True Then
            ' ''        Me.total_days += 1
            ' ''    End If
            ' ''Next

            ' ''Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
            ' ''Try
            ' ''    dbConn.Open()
            ' ''    Dim oCm As New OleDb.OleDbCommand("as_TrnTerimabarangused_Update", dbConn)
            ' ''    oCm.CommandType = CommandType.StoredProcedure
            ' ''    oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me.DgvListBPJ.Rows(i).Cells("channel_id").Value
            ' ''    oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_id").Value
            ' ''    oCm.Parameters.Add("@terimabarang_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_line").Value
            ' ''    oCm.Parameters.Add("@terimabarang_lineday", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_lineday").Value
            ' ''    oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvListBPJ.Rows(i).Cells("order_id").Value
            ' ''    oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvListBPJ.Rows(i).Cells("orderdetil_line").Value
            ' ''    oCm.Parameters.Add("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvListBPJ.Rows(i).Cells("orderdetiluse_line").Value
            ' ''    oCm.Parameters.Add("@terimabarang_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_dt").Value
            ' ''    oCm.Parameters.Add("@terimabarang_detilused_note", System.Data.OleDb.OleDbType.VarWChar, 400).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_detilused_note").Value
            ' ''    oCm.Parameters.Add("@terimabarang_check", System.Data.OleDb.OleDbType.Boolean, 1).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("select").Value, False)
            ' ''    oCm.Parameters.Add("@terimabarangused_qty", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("terimabarangused_qty").Value, 0)
            ' ''    oCm.Parameters.Add("@terimabarangused_usagestart", System.Data.OleDb.OleDbType.VarWChar, 10).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("terimabarangused_usagestart").Value, String.Empty)
            ' ''    oCm.Parameters.Add("@terimabarangused_usageend", System.Data.OleDb.OleDbType.VarWChar, 10).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("terimabarangused_usageend").Value, String.Empty)
            ' ''    oCm.Parameters.Add("@terimabarangused_status", System.Data.OleDb.OleDbType.VarWChar, 40).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("terimabarangused_status").Value, String.Empty)
            ' ''    oCm.Parameters.Add("@terimabarangused_remark", System.Data.OleDb.OleDbType.VarWChar, 100).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("terimabarangused_remark").Value, String.Empty)

            ' ''    oCm.ExecuteNonQuery()
            ' ''    oCm.Dispose()
            ' ''Catch ex As Data.OleDb.OleDbException
            ' ''    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' ''Catch ex As Exception
            ' ''    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' ''Finally
            ' ''    dbConn.Close()
            ' ''End Try
            ' ''Next
        Else

            Me.DgvListBPJ.EndEdit()
            Me.BindingContext(Me.tbl_trnOrderDetilDays).EndCurrentEdit()
            tbl_trnOrderDetilDays_changes = Me.tbl_trnOrderDetilDays.GetChanges()

            If tbl_trnOrderDetilDays_changes IsNot Nothing Then
                For i = 0 To Me.tbl_trnOrderDetilDays.Rows.Count - 1
                    If Me.tbl_trnOrderDetilDays.Rows(i).RowState = DataRowState.Added Then
                        Me.tbl_trnOrderDetilDays.Rows(i).Item("terimabarang_id") = terimabarang_id
                    End If
                Next
                success = Me.save_manual(terimabarang_id, tbl_trnOrderDetilDays_changes, MasterDataState)
                If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnTerimaJasa_SaveDetil(tbl_TrnTerimabarangdetil_Changes)")
                Me.tbl_trnOrderDetilDays.AcceptChanges()
            End If

            'For i = 0 To count_dgv - 1
            '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
            '    Try
            '        dbConn.Open()
            '        Dim oCm As New OleDb.OleDbCommand("as_TrnTerimabarangused_Insert", dbConn)
            '        oCm.CommandType = CommandType.StoredProcedure
            '        oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me.DgvListBPJ.Rows(i).Cells("channel_id").Value
            '        oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_id").Value
            '        oCm.Parameters.Add("@terimabarang_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_line").Value
            '        oCm.Parameters.Add("@terimabarang_lineday", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_lineday").Value
            '        oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvListBPJ.Rows(i).Cells("order_id").Value
            '        oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvListBPJ.Rows(i).Cells("orderdetil_line").Value
            '        oCm.Parameters.Add("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvListBPJ.Rows(i).Cells("orderdetiluse_line").Value
            '        oCm.Parameters.Add("@terimabarang_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_dt").Value
            '        oCm.Parameters.Add("@terimabarang_detilused_note", System.Data.OleDb.OleDbType.VarWChar, 400).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_detilused_note").Value
            '        oCm.Parameters.Add("@terimabarang_check", System.Data.OleDb.OleDbType.Boolean, 1).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_check").Value
            '        oCm.ExecuteNonQuery()
            '        oCm.Dispose()
            '    Catch ex As Data.OleDb.OleDbException
            '        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Catch ex As Exception
            '        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Finally
            '        dbConn.Close()
            '    End Try
            'Next
            Me.total_days = count_dgv
        End If

        System.Windows.Forms.Cursor.Current = Cursors.Default
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.total_days = 9999
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Sub New(ByVal strDSN As String, ByVal channel_id As String, ByVal terimabarang_id As String, _
        ByVal orderdetil_line As Integer, ByVal isDaysManual As String, ByVal terimabarang_line As Integer, _
        ByVal isUser As String, ByVal isLock As Byte)
        Me.dsn = strDSN
        Me.channel_id = channel_id
        Me.terimabarang_id = terimabarang_id
        Me.orderdetil_line = orderdetil_line
        Me.isDaysManual = isDaysManual
        Me.terimabarang_line = terimabarang_line
        Me.isUser = isUser
        Me.isLock = isLock

        If isDaysManual = "MANUAL" Then
            Me.tbl_trnOrderDetilDays.Clear()
            Me.tbl_trnOrderDetilDays = clsDataset.CreateTblTrnTerimabarangused()
            Me.tbl_trnOrderDetilDays.Columns("terimabarang_id").DefaultValue = Me.terimabarang_id
            Me.tbl_trnOrderDetilDays.Columns("channel_id").DefaultValue = Me.channel_id

            Me.tbl_trnOrderDetilDays.Columns("terimabarang_lineday").DefaultValue = DBNull.Value
            Me.tbl_trnOrderDetilDays.Columns("terimabarang_lineday").AutoIncrement = True
            Me.tbl_trnOrderDetilDays.Columns("terimabarang_lineday").AutoIncrementSeed = 10
            Me.tbl_trnOrderDetilDays.Columns("terimabarang_lineday").AutoIncrementStep = 10
            Me.tbl_trnOrderDetilDays.Columns("terimabarang_line").DefaultValue = Me.terimabarang_line
            Me.tbl_trnOrderDetilDays.Columns("order_id").DefaultValue = 0
            Me.tbl_trnOrderDetilDays.Columns("orderdetil_line").DefaultValue = 0
            Me.tbl_trnOrderDetilDays.Columns("terimabarang_check").DefaultValue = 1
            'Me.tbl_trnOrderDetilDays.Columns("terimabarang_dt").DefaultValue = "01/01/1900"
        End If

        InitializeComponent()
    End Sub

    Private Sub check_daysIsUse()
        Dim j As Integer
        Dim count_dgv As Integer

        tbl_trnOrderDetilDays.Columns.Add("select", GetType(System.Boolean))
        tbl_trnOrderDetilDays.Columns("select").DefaultValue = 0

        count_dgv = Me.tbl_trnOrderDetilDays.Rows.Count - 1
        For j = 0 To count_dgv
            If clsUtil.IsDbNull(Me.tbl_trnOrderDetilDays.Rows(j).Item("terimabarang_check"), 0) = 1 Then
                Me.DgvListBPJ.Rows(j).Cells("select").Value = 1
            End If
        Next
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
    Private Function save_manual(ByRef terimabarang_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_terimabarangdetil
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnTerimabarangused_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 40, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarang_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_lineday", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_lineday"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 60, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_detilused_note", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_detilused_note"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_check", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_check"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangused_qty", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangused_qty"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangused_usagestart", System.Data.OleDb.OleDbType.VarWChar, 10, "terimabarangused_usagestart"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangused_usageend", System.Data.OleDb.OleDbType.VarWChar, 10, "terimabarangused_usageend"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangused_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarangused_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangused_remark", System.Data.OleDb.OleDbType.VarWChar, 100, "terimabarangused_remark"))



        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnTerimabarangused_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 40, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_lineday", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_lineday"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 60, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetiluse_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_detilused_note", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_detilused_note"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_check", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_check"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangused_qty", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangused_qty"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangused_usagestart", System.Data.OleDb.OleDbType.VarWChar, 10, "terimabarangused_usagestart"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangused_usageend", System.Data.OleDb.OleDbType.VarWChar, 10, "terimabarangused_usageend"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangused_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarangused_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangused_remark", System.Data.OleDb.OleDbType.VarWChar, 100, "terimabarangused_remark"))


        dbCmdDelete = New OleDb.OleDbCommand("as_TrnTerimabarangused_DeleteManual", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 40, "channel_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarang_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_lineday", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_lineday"))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete

        Try
            dbConn.Open()
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try

        Return True
    End Function


    
End Class
