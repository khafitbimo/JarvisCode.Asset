Imports System.Windows.Forms

Public Class dlgTrnTerimaJasaUsed_Rental_Wardrobe

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

    Private tbl_terimaJasaUsed_temps As DataTable = clsDataset.CreateTblTrnTerimajasaused

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider


    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = String.Empty
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)


        Me.Text = "List days Rental Order"

        criteria = String.Format(" terimajasa_id = '{0}' AND terimajasa_line = {1} ", Me.terimabarang_id, Me.orderdetil_line)

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

        Me.tbl_terimaJasaUsed_temps.DefaultView.RowFilter = String.Format(" order_id = '{0}' AND orderdetil_line = {1}", Me.order_id, Me.orderdetil_line)

        Me.DgvListBPJ.DataSource = Me.tbl_terimaJasaUsed_temps '.DefaultView
        ' ''Me.DgvListBPJ.DataSource = Me.tbl_trnTerimaJasaUsed


        If isDaysManual = "MANUAL" Then
            Me.FormatDgvTrnTerimabarangusedManual(Me.DgvListBPJ)
        Else
            Me.FormatDgvTrnTerimajasaused(Me.DgvListBPJ)

        End If

        ' ''Me.DgvListBPJ.Columns("terimabarang_dt").DefaultCellStyle.BackColor = Color.Gainsboro
        ' ''Me.DgvListBPJ.Columns("terimabarangused_qty").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_usagestart").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_usageend").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_status").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_remark").DefaultCellStyle.BackColor = Color.Lavender

        MyBase.ShowDialog(owner)

        Return Me.retObj

    End Function

    Private Function FormatDgvTrnTerimajasaused(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_lineday As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_detilused_note As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasaused_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_qty_idle As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasaused_usagestart As New DataGridViewMaskedEditColumn
        Dim cTerimajasaused_usgaeend As New DataGridViewMaskedEditColumn
        Dim cTerimajasaused_status As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cTerimajasaused_remark As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

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

        cTerimajasa_lineday.Name = "terimajasa_lineday"
        cTerimajasa_lineday.HeaderText = "terimajasa_lineday"
        cTerimajasa_lineday.DataPropertyName = "terimajasa_lineday"
        cTerimajasa_lineday.Width = 100
        cTerimajasa_lineday.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_lineday.Visible = False
        cTerimajasa_lineday.ReadOnly = False

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

        cTerimajasa_date.Name = "terimajasa_date"
        cTerimajasa_date.HeaderText = "Date"
        cTerimajasa_date.DataPropertyName = "terimajasa_date"
        cTerimajasa_date.Width = 100
        cTerimajasa_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_date.Visible = True
        cTerimajasa_date.ReadOnly = True
        cTerimajasa_date.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimajasa_detilused_note.Name = "terimajasa_detilused_note"
        cTerimajasa_detilused_note.HeaderText = "terimajasa_detilused_note"
        cTerimajasa_detilused_note.DataPropertyName = "terimajasa_detilused_note"
        cTerimajasa_detilused_note.Width = 100
        cTerimajasa_detilused_note.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_detilused_note.Visible = False
        cTerimajasa_detilused_note.ReadOnly = False

        cTerimajasa_check.Name = "terimajasa_check"
        cTerimajasa_check.HeaderText = "Select"
        cTerimajasa_check.DataPropertyName = "terimajasa_check"
        cTerimajasa_check.Width = 40
        cTerimajasa_check.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimajasa_check.Visible = True
        cTerimajasa_check.ReadOnly = False

        cTerimajasaused_qty.Name = "terimajasaused_qty"
        cTerimajasaused_qty.HeaderText = "Qty"
        cTerimajasaused_qty.DataPropertyName = "terimajasaused_qty"
        cTerimajasaused_qty.Width = 75
        cTerimajasaused_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimajasaused_qty.Visible = True
        cTerimajasaused_qty.ReadOnly = False
        cTerimajasaused_qty.DefaultCellStyle.Format = "#,##0"

        cTerimajasaused_qty_idle.Name = "terimajasaused_qty_idle"
        cTerimajasaused_qty_idle.HeaderText = "Qty Idle"
        cTerimajasaused_qty_idle.DataPropertyName = "terimajasaused_qty_idle"
        cTerimajasaused_qty_idle.Width = 75
        cTerimajasaused_qty_idle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimajasaused_qty_idle.Visible = True
        cTerimajasaused_qty_idle.ReadOnly = False
        cTerimajasaused_qty_idle.DefaultCellStyle.Format = "#,##0"

        cTerimajasaused_usagestart.Mask = "##:##"
        cTerimajasaused_usagestart.ValidatingType = GetType(DateTime)
        cTerimajasaused_usagestart.Name = "terimajasaused_usagestart"
        cTerimajasaused_usagestart.HeaderText = "Usage Start"
        cTerimajasaused_usagestart.DataPropertyName = "terimajasaused_usagestart"
        cTerimajasaused_usagestart.Width = 100
        cTerimajasaused_usagestart.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usagestart.ReadOnly = False

        cTerimajasaused_usgaeend.Mask = "##:##"
        cTerimajasaused_usgaeend.ValidatingType = GetType(DateTime)
        cTerimajasaused_usgaeend.Name = "terimajasaused_usgaeend"
        cTerimajasaused_usgaeend.HeaderText = "Usage Start"
        cTerimajasaused_usgaeend.DataPropertyName = "terimajasaused_usgaeend"
        cTerimajasaused_usgaeend.Width = 100
        cTerimajasaused_usgaeend.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_usgaeend.ReadOnly = False

        cTerimajasaused_status.Name = "terimajasaused_status"
        cTerimajasaused_status.HeaderText = "Status"
        cTerimajasaused_status.DataPropertyName = "terimajasaused_status"
        cTerimajasaused_status.DataSource = Me.tbl_objective
        cTerimajasaused_status.ValueMember = "objective_id"
        cTerimajasaused_status.DisplayMember = "objective_name"
        cTerimajasaused_status.Width = 75
        cTerimajasaused_status.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_status.Visible = True
        cTerimajasaused_status.ReadOnly = False


        cTerimajasaused_remark.Name = "terimajasaused_remark"
        cTerimajasaused_remark.HeaderText = "Remark"
        cTerimajasaused_remark.DataPropertyName = "terimajasaused_remark"
        cTerimajasaused_remark.Width = 150
        cTerimajasaused_remark.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasaused_remark.Visible = True
        cTerimajasaused_remark.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimajasa_check, cTerimajasa_date, cTerimajasaused_qty, cTerimajasaused_qty_idle, _
        cTerimajasaused_usagestart, cTerimajasaused_usgaeend, _
        cTerimajasaused_status, cTerimajasaused_remark, cChannel_id, cTerimajasa_id, _
        cTerimajasa_line, cTerimajasa_lineday, _
        cOrder_id, cOrderdetil_line, cOrderdetiluse_line, cTerimajasa_detilused_note})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        If Me.isUser = "bma" Then
            objDgv.ReadOnly = True
        End If
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
        If Me.isUser = "bma" Then
            objDgv.ReadOnly = True
        End If
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.dlgTrnTerimaJasaUsed_Rental_FormError() = False Then
            Exit Sub
        End If

        Dim thisRetObj As Collection = New Collection
        Dim retTblOrderDays As DataTable = clsDataset.CreateTblTrnTerimabarangused

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

    Private Function GetOutstandingDetilUseWardrobe(ByVal request_id As String,
                                                    ByVal requestdetil_line As Integer,
                                                    ByVal requestdetiluse_date As Date,
                                                    ByVal terimajasa_id As String,
                                                    ByVal terimajasa_line As Integer,
                                                    ByVal terimajasa_lineday As Integer) As Decimal
        Using dbConn As New OleDb.OleDbConnection(Me.dsn)
            Dim cmd As OleDb.OleDbCommand
            Dim result As Decimal
            Dim cookie As Byte() = Nothing

            Try
                cmd = New OleDb.OleDbCommand("as_TrnTerimajasaused_qtyOutstandingErr_Wardrobe", dbConn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@request_id", request_id)
                cmd.Parameters.AddWithValue("@requestdetil_line", requestdetil_line)
                cmd.Parameters.AddWithValue("@requestdetiluse_date", requestdetiluse_date)
                cmd.Parameters.AddWithValue("@terimajasa_id", terimajasa_id)
                cmd.Parameters.AddWithValue("@terimajasa_line", terimajasa_line)
                cmd.Parameters.AddWithValue("@terimajasa_lineday", terimajasa_lineday)

                dbConn.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)
                result = cmd.ExecuteScalar()

                Return result
            Catch ex As Exception
                Throw ex
            Finally
                If dbConn.State = ConnectionState.Open Then
                    clsApplicationRole.UnsetAppRole(dbConn, cookie)
                    dbConn.Close()
                End If
            End Try
        End Using
    End Function

    Private Function dlgTrnTerimaJasaUsed_Rental_FormError() As Boolean
        Try
            Dim request_id As String
            Dim requestdetil_line As Integer
            Dim requestdetiluse_date As Date
            Dim terimajasaused_qty As Integer
            Dim terimajasa_id As String
            Dim terimajasa_line As Integer
            Dim terimajasa_lineday As Integer
            Dim row As DataRow

            For Each viewRow As DataGridViewRow In Me.DgvListBPJ.Rows
                If clsUtil.IsDbNull(viewRow.Cells("terimajasa_check").Value, 0) = 1 Then
                    row = CType(viewRow.DataBoundItem, DataRowView).Row

                    request_id = row.Item("order_id")
                    requestdetil_line = row.Item("orderdetil_line")
                    requestdetiluse_date = row.Item("terimajasa_date")
                    terimajasaused_qty = row.Item("terimajasaused_qty")
                    terimajasa_id = row.Item("terimajasa_id")
                    terimajasa_line = row.Item("terimajasa_line")
                    terimajasa_lineday = row.Item("terimajasa_lineday")

                    Try
                        If terimajasaused_qty > Me.GetOutstandingDetilUseWardrobe(request_id,
                                                                                  requestdetil_line,
                                                                                  requestdetiluse_date,
                                                                                  terimajasa_id,
                                                                                  terimajasa_line,
                                                                                  terimajasa_lineday) Then
                            viewRow.ErrorText = "Qty Bpj melebihi Qty Request"
                            viewRow.DefaultCellStyle.BackColor = Color.Coral

                            Throw New Exception("Data ada yang salah isi!")
                        Else
                            viewRow.ErrorText = ""
                            viewRow.DefaultCellStyle.BackColor = Nothing
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Exclamation" & ": List Days Rental Request()", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End Try
                End If
            Next

            'For i = 0 To Me.tbl_terimaJasaUsed_temps.DefaultView.Count - 1
            '    If clsUtil.IsDbNull(Me.tbl_terimaJasaUsed_temps.DefaultView.Item(i).Item("terimajasa_check"), 0) = 1 Then

            '        dbCmd = New OleDb.OleDbCommand("as_TrnTerimajasaused_qtyOutstandingErr", dbConn)
            '        dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarWChar)
            '        dbCmd.Parameters("@order_id").Value = Me.tbl_terimaJasaUsed_temps.DefaultView.Item(i).Item("order_id")
            '        dbCmd.Parameters.Add("@orderdetil_line", Data.OleDb.OleDbType.Integer)
            '        dbCmd.Parameters("@orderdetil_line").Value = Me.tbl_terimaJasaUsed_temps.DefaultView.Item(i).Item("orderdetil_line")
            '        dbCmd.Parameters.Add("@orderdetiluse_line", Data.OleDb.OleDbType.Integer)
            '        dbCmd.Parameters("@orderdetiluse_line").Value = Me.tbl_terimaJasaUsed_temps.DefaultView.Item(i).Item("orderdetiluse_line")
            '        dbCmd.Parameters.Add("@terimajasa_id", Data.OleDb.OleDbType.VarWChar)
            '        dbCmd.Parameters("@terimajasa_id").Value = Me.tbl_terimaJasaUsed_temps.DefaultView.Item(i).Item("terimajasa_id")
            '        dbCmd.CommandType = CommandType.StoredProcedure
            '        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
            '        tbl_err.Clear()

            '        Try
            '            dbConn.Open()
            '            dbDA.Fill(tbl_err)
            '            If tbl_err.Rows.Count > 0 Then
            '                row_error = False
            '                message = "Qty Bpj melebihi Qty Order"
            '                cell_qty = Me.DgvListBPJ.Rows(i).Cells("terimajasaused_qty")
            '                If cell_qty.Value - clsUtil.IsDbNull(tbl_err.Rows(0).Item("qty_total"), 0) > 0 Then
            '                    cell_qty.ErrorText = message
            '                    row_error = True
            '                Else
            '                    cell_qty.ErrorText = ""
            '                End If
            '            End If

            '            message = "Qty Idle melebihi Qty Bpj"
            '            cell_qty = Me.DgvListBPJ.Rows(i).Cells("terimajasaused_qty")
            '            cell_qty_idle = Me.DgvListBPJ.Rows(i).Cells("terimajasaused_qty_idle")
            '            If cell_qty_idle.Value - cell_qty.Value > 0 Then
            '                cell_qty_idle.ErrorText = message
            '                row_error = True
            '            Else
            '                cell_qty_idle.ErrorText = ""
            '            End If


            '            If row_error Then
            '                dgv_error = True
            '                Me.DgvListBPJ.Rows(i).DefaultCellStyle.BackColor = Color.Coral
            '            Else
            '                Me.DgvListBPJ.Rows(i).DefaultCellStyle.BackColor = Color.White
            '            End If

            '            If dgv_error Then
            '                Throw New Exception("Data ada yang salah isi!")
            '            End If

            '        Catch ex As Exception
            '            MessageBox.Show(ex.Message, "Exclamation" & ": List Days Rental Order()", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '            Return False
            '        Finally
            '            dbConn.Close()
            '        End Try
            '    End If
            'Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgTrnTerimaJasaUsed_Rental", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
        Return True
    End Function
End Class
