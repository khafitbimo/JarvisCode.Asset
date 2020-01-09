Public Class uiTrnBPBProcurement
    Private Const mUiName As String = "BPB Procurement"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)

    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean

    Private _LOADCOMBOSEARCH As Boolean = False

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_TrnTerimabarang As DataTable = clsDataset.CreateTblTrnTerimabarang()
    Private tbl_TrnTerimabarang_Temp As DataTable = clsDataset.CreateTblTrnTerimabarang()
    Private tbl_TrnTerimabarangdetil As DataTable = clsDataset.CreateTblTrnTerimabarangdetil()
    Private tbl_TrnOrderDetil As DataTable = clsDataset.CreateTblTrnOrderdetil

    Private tbl_MstTrnOrder_search As DataTable = clsDataset.CreateTblTrnOrder()
    Private tbl_TrnTerimabarang_search As DataTable = clsDataset.CreateTblTrnTerimabarang()


    'Friend WithEvents btnlock As ToolStripButton = New ToolStripButton


#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TTV"
    Private _STRUKTUR_UNIT As Decimal = "5554"
#End Region

    'Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlock.Click


    '    If Me.DgvBPBProcurement.Rows.Count <> 0 Then
    '        If Me.DgvBPBProcurement.Rows(Me.DgvBPBProcurement.CurrentRow.Index).Cells("appuser").Value = 1 Then
    '            If Me.DgvBPBProcurement.Rows(Me.DgvBPBProcurement.CurrentRow.Index).Cells("appproc").Value = 0 Then
    '                Me.LockPrcData()
    '            End If
    '        End If

    '    End If
    'End Sub
#Region " Overrides "

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible
        If Me.PnlDfSearch.Visible Then
            FILTER_QUERY_MODE = True
            Me.tbtnQuery.CheckState = CheckState.Checked
        Else
            FILTER_QUERY_MODE = False
            Me.tbtnQuery.CheckState = CheckState.Unchecked
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnNew_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If Me.ftabMain.SelectedIndex = 0 Then
            Me.ftabMain.SelectedIndex = 1
        End If
        Me.UiTrnBPBProcurement_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.objFormError.Clear()
        Me.Cursor = Cursors.WaitCursor
        Me.UiTrnBPBProcurement_Retrieve()
        Me.UiTrnBPBProcurement_LoadComboSearch()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        Me.objFormError.Clear()
        If Me.UiTrnBPBProcurement_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        'Me.UiTrnBPBProcurement_Save()
        'Me.update_status()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        'Me.UiTrnBPBProcurement_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        MessageBox.Show("Data Cannot Be Deleted", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiTrnBPBProcurement_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiTrnBPBProcurement_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiTrnBPBProcurement_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiTrnBPBProcurement_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region


#Region " Layout & Init UI "

    Private Function FormatDgvTrnBPBProcurement(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cAppuser As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cAppproc As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cVendor As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cQty_po As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cQty_bpj As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDays_po As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDays_bpj As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStatus As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cNotes As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cAppuser.Name = "appuser"
        cAppuser.HeaderText = "User"
        cAppuser.DataPropertyName = "appuser"
        cAppuser.Width = 50
        cAppuser.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cAppuser.Visible = True
        cAppuser.ReadOnly = False

        cAppproc.Name = "appproc"
        cAppproc.HeaderText = "Proc"
        cAppproc.DataPropertyName = "appproc"
        cAppproc.Width = 50
        cAppproc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cAppproc.Visible = True
        cAppproc.ReadOnly = False

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "Terimabarang No."
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 130
        cTerimabarang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order No."
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Order Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "rekanan_id"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = False

        cVendor.Name = "vendor"
        cVendor.HeaderText = "Vendor"
        cVendor.DataPropertyName = "vendor"
        cVendor.Width = 200
        cVendor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cVendor.Visible = True
        cVendor.ReadOnly = False

        cQty_po.Name = "qty_po"
        cQty_po.HeaderText = "Qty PO"
        cQty_po.DataPropertyName = "qty_po"
        cQty_po.Width = 80
        cQty_po.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cQty_po.Visible = True
        cQty_po.ReadOnly = False

        cQty_bpj.Name = "qty_bpj"
        cQty_bpj.HeaderText = "Qty BPB"
        cQty_bpj.DataPropertyName = "qty_bpj"
        cQty_bpj.Width = 80
        cQty_bpj.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cQty_bpj.Visible = True
        cQty_bpj.ReadOnly = False

        cDays_po.Name = "days_po"
        cDays_po.HeaderText = "Days PO"
        cDays_po.DataPropertyName = "days_po"
        cDays_po.Width = 80
        cDays_po.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDays_po.Visible = True
        cDays_po.ReadOnly = False
        cDays_po.DefaultCellStyle.Format = "###,##0"

        cDays_bpj.Name = "days_bpj"
        cDays_bpj.HeaderText = "Days BPJ"
        cDays_bpj.DataPropertyName = "days_bpj"
        cDays_bpj.Width = 80
        cDays_bpj.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDays_bpj.Visible = True
        cDays_bpj.ReadOnly = False

        cStatus.Name = "status"
        cStatus.HeaderText = "Status"
        cStatus.DataPropertyName = "status"
        cStatus.Width = 100
        cStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStatus.Visible = True
        cStatus.ReadOnly = False

        cNotes.Name = "notes"
        cNotes.HeaderText = "Notes"
        cNotes.DataPropertyName = "notes"
        cNotes.Width = 200
        cNotes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cNotes.Visible = True
        cNotes.ReadOnly = False


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cAppuser, cAppproc, cOrder_id, cTerimabarang_id, cOrderdetil_line, cRekanan_id, cVendor, cQty_po, cQty_bpj, cDays_po, cDays_bpj, cStatus, cNotes})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.ReadOnly = True


    End Function

    Private Function FormatDgvTrnOrderdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_itemmigrasi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_days As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_discount As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_actual As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_actualnote As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetaccount_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOld_orderdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_pphpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_ppnpercent As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_requestid_ref As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_qtyarrived As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_bpbj As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order No."
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False

        cOrderdetil_type.Name = "orderdetil_type"
        cOrderdetil_type.HeaderText = "orderdetil_type"
        cOrderdetil_type.DataPropertyName = "orderdetil_type"
        cOrderdetil_type.Width = 100
        cOrderdetil_type.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_type.Visible = False
        cOrderdetil_type.ReadOnly = False

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 40
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = False

        cItem_id.Name = "item_id"
        cItem_id.HeaderText = "item_id"
        cItem_id.DataPropertyName = "item_id"
        cItem_id.Width = 100
        cItem_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem_id.Visible = False
        cItem_id.ReadOnly = False

        cItem_id_string.Name = "item_id_string"
        cItem_id_string.HeaderText = "Item Name"
        cItem_id_string.DataPropertyName = "item_id_string"
        cItem_id_string.Width = 200
        cItem_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem_id_string.Visible = True
        cItem_id_string.ReadOnly = False

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "unit_id"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 100
        cUnit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUnit_id.Visible = False
        cUnit_id.ReadOnly = False

        cOrderdetil_itemmigrasi.Name = "orderdetil_itemmigrasi"
        cOrderdetil_itemmigrasi.HeaderText = "orderdetil_itemmigrasi"
        cOrderdetil_itemmigrasi.DataPropertyName = "orderdetil_itemmigrasi"
        cOrderdetil_itemmigrasi.Width = 100
        cOrderdetil_itemmigrasi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_itemmigrasi.Visible = False
        cOrderdetil_itemmigrasi.ReadOnly = False

        cOrderdetil_descr.Name = "orderdetil_descr"
        cOrderdetil_descr.HeaderText = "Description"
        cOrderdetil_descr.DataPropertyName = "orderdetil_descr"
        cOrderdetil_descr.Width = 400
        cOrderdetil_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_descr.Visible = True
        cOrderdetil_descr.ReadOnly = False

        cOrderdetil_qty.Name = "orderdetil_qty"
        cOrderdetil_qty.HeaderText = "Qty"
        cOrderdetil_qty.DataPropertyName = "orderdetil_qty"
        cOrderdetil_qty.Width = 50
        cOrderdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_qty.Visible = True
        cOrderdetil_qty.ReadOnly = False
        cOrderdetil_qty.DefaultCellStyle.Format = "###,##0"

        cOrderdetil_days.Name = "orderdetil_days"
        cOrderdetil_days.HeaderText = "Days"
        cOrderdetil_days.DataPropertyName = "orderdetil_days"
        cOrderdetil_days.Width = 50
        cOrderdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_days.Visible = True
        cOrderdetil_days.ReadOnly = False
        cOrderdetil_days.DefaultCellStyle.Format = "###,##0"

        cOrderdetil_idr.Name = "orderdetil_idr"
        cOrderdetil_idr.HeaderText = "orderdetil_idr"
        cOrderdetil_idr.DataPropertyName = "orderdetil_idr"
        cOrderdetil_idr.Width = 100
        cOrderdetil_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_idr.Visible = False
        cOrderdetil_idr.ReadOnly = False

        cOrderdetil_foreign.Name = "orderdetil_foreign"
        cOrderdetil_foreign.HeaderText = "orderdetil_foreign"
        cOrderdetil_foreign.DataPropertyName = "orderdetil_foreign"
        cOrderdetil_foreign.Width = 100
        cOrderdetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_foreign.Visible = False
        cOrderdetil_foreign.ReadOnly = False

        cOrderdetil_foreignrate.Name = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.HeaderText = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.DataPropertyName = "orderdetil_foreignrate"
        cOrderdetil_foreignrate.Width = 100
        cOrderdetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_foreignrate.Visible = False
        cOrderdetil_foreignrate.ReadOnly = False

        cOrderdetil_discount.Name = "orderdetil_discount"
        cOrderdetil_discount.HeaderText = "orderdetil_discount"
        cOrderdetil_discount.DataPropertyName = "orderdetil_discount"
        cOrderdetil_discount.Width = 100
        cOrderdetil_discount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_discount.Visible = False
        cOrderdetil_discount.ReadOnly = False

        cOrderdetil_actual.Name = "orderdetil_actual"
        cOrderdetil_actual.HeaderText = "orderdetil_actual"
        cOrderdetil_actual.DataPropertyName = "orderdetil_actual"
        cOrderdetil_actual.Width = 100
        cOrderdetil_actual.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_actual.Visible = False
        cOrderdetil_actual.ReadOnly = False

        cOrderdetil_actualnote.Name = "orderdetil_actualnote"
        cOrderdetil_actualnote.HeaderText = "orderdetil_actualnote"
        cOrderdetil_actualnote.DataPropertyName = "orderdetil_actualnote"
        cOrderdetil_actualnote.Width = 100
        cOrderdetil_actualnote.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_actualnote.Visible = False
        cOrderdetil_actualnote.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "budget_id"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = False

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "budgetdetil_id"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 100
        cBudgetdetil_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetdetil_id.Visible = False
        cBudgetdetil_id.ReadOnly = False

        cBudgetaccount_id.Name = "budgetaccount_id"
        cBudgetaccount_id.HeaderText = "budgetaccount_id"
        cBudgetaccount_id.DataPropertyName = "budgetaccount_id"
        cBudgetaccount_id.Width = 100
        cBudgetaccount_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBudgetaccount_id.Visible = False
        cBudgetaccount_id.ReadOnly = False

        cOld_orderdetil_id.Name = "old_orderdetil_id"
        cOld_orderdetil_id.HeaderText = "old_orderdetil_id"
        cOld_orderdetil_id.DataPropertyName = "old_orderdetil_id"
        cOld_orderdetil_id.Width = 100
        cOld_orderdetil_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOld_orderdetil_id.Visible = False
        cOld_orderdetil_id.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cOrderdetil_pphpercent.Name = "orderdetil_pphpercent"
        cOrderdetil_pphpercent.HeaderText = "orderdetil_pphpercent"
        cOrderdetil_pphpercent.DataPropertyName = "orderdetil_pphpercent"
        cOrderdetil_pphpercent.Width = 100
        cOrderdetil_pphpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_pphpercent.Visible = False
        cOrderdetil_pphpercent.ReadOnly = False

        cOrderdetil_ppnpercent.Name = "orderdetil_ppnpercent"
        cOrderdetil_ppnpercent.HeaderText = "orderdetil_ppnpercent"
        cOrderdetil_ppnpercent.DataPropertyName = "orderdetil_ppnpercent"
        cOrderdetil_ppnpercent.Width = 100
        cOrderdetil_ppnpercent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_ppnpercent.Visible = False
        cOrderdetil_ppnpercent.ReadOnly = False

        cOrderdetil_requestid_ref.Name = "orderdetil_requestid_ref"
        cOrderdetil_requestid_ref.HeaderText = "orderdetil_requestid_ref"
        cOrderdetil_requestid_ref.DataPropertyName = "orderdetil_requestid_ref"
        cOrderdetil_requestid_ref.Width = 100
        cOrderdetil_requestid_ref.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_requestid_ref.Visible = False
        cOrderdetil_requestid_ref.ReadOnly = False

        cOrderdetil_qtyarrived.Name = "orderdetil_qtyarrived"
        cOrderdetil_qtyarrived.HeaderText = "orderdetil_qtyarrived"
        cOrderdetil_qtyarrived.DataPropertyName = "orderdetil_qtyarrived"
        cOrderdetil_qtyarrived.Width = 100
        cOrderdetil_qtyarrived.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_qtyarrived.Visible = False
        cOrderdetil_qtyarrived.ReadOnly = False

        cOrderdetil_bpbj.Name = "orderdetil_bpbj"
        cOrderdetil_bpbj.HeaderText = "orderdetil_bpbj"
        cOrderdetil_bpbj.DataPropertyName = "orderdetil_bpbj"
        cOrderdetil_bpbj.Width = 100
        cOrderdetil_bpbj.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_bpbj.Visible = False
        cOrderdetil_bpbj.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_id, cOrderdetil_line, cOrderdetil_type, cItem_id, cUnit_id, cOrderdetil_itemmigrasi, cOrderdetil_descr, cItem_id_string, cOrderdetil_qty, cOrderdetil_days, cOrderdetil_idr, cOrderdetil_foreign, cOrderdetil_foreignrate, cOrderdetil_discount, cOrderdetil_actual, cOrderdetil_actualnote, cCurrency_id, cBudget_id, cBudgetdetil_id, cBudgetaccount_id, cOld_orderdetil_id, cChannel_id, cOrderdetil_pphpercent, cOrderdetil_ppnpercent, cOrderdetil_requestid_ref, cOrderdetil_qtyarrived, cOrderdetil_bpbj})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

    Private Function FormatDgvTrnTerimabarangdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_tgl As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTipeasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategoriasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_lineinduk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_barcodeinduk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_serial As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_produknumber As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_model As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_deskripsi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategoriitem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTipeitem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_golfiskal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_tipedepre As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_depre_enddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_harga As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_hargabaru As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_disc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_depresiasi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_akum_val_depre As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_valas As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_idrprice As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_owner As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBrand_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaterial_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWarna_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUkuran_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJeniskelamin_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id_cont_item As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRuang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_rak As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIs_useable As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_active As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cProject_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWo_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cInputby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cInputdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEditby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEditdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUsedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "Terimabarang No."
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 130
        cTerimabarang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = False

        cAsset_line.Name = "asset_line"
        cAsset_line.HeaderText = "asset_line"
        cAsset_line.DataPropertyName = "asset_line"
        cAsset_line.Width = 100
        cAsset_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_line.Visible = False
        cAsset_line.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cAsset_tgl.Name = "asset_tgl"
        cAsset_tgl.HeaderText = "asset_tgl"
        cAsset_tgl.DataPropertyName = "asset_tgl"
        cAsset_tgl.Width = 100
        cAsset_tgl.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_tgl.Visible = False
        cAsset_tgl.ReadOnly = False

        cTipeasset_id.Name = "tipeasset_id"
        cTipeasset_id.HeaderText = "tipeasset_id"
        cTipeasset_id.DataPropertyName = "tipeasset_id"
        cTipeasset_id.Width = 100
        cTipeasset_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTipeasset_id.Visible = False
        cTipeasset_id.ReadOnly = False

        cKategoriasset_id.Name = "kategoriasset_id"
        cKategoriasset_id.HeaderText = "kategoriasset_id"
        cKategoriasset_id.DataPropertyName = "kategoriasset_id"
        cKategoriasset_id.Width = 100
        cKategoriasset_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriasset_id.Visible = False
        cKategoriasset_id.ReadOnly = False

        cAsset_barcode.Name = "asset_barcode"
        cAsset_barcode.HeaderText = "asset_barcode"
        cAsset_barcode.DataPropertyName = "asset_barcode"
        cAsset_barcode.Width = 100
        cAsset_barcode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_barcode.Visible = False
        cAsset_barcode.ReadOnly = False

        cAsset_lineinduk.Name = "asset_lineinduk"
        cAsset_lineinduk.HeaderText = "Days"
        cAsset_lineinduk.DataPropertyName = "asset_lineinduk"
        cAsset_lineinduk.Width = 100
        cAsset_lineinduk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_lineinduk.Visible = True
        cAsset_lineinduk.ReadOnly = False

        cAsset_barcodeinduk.Name = "asset_barcodeinduk"
        cAsset_barcodeinduk.HeaderText = "asset_barcodeinduk"
        cAsset_barcodeinduk.DataPropertyName = "asset_barcodeinduk"
        cAsset_barcodeinduk.Width = 100
        cAsset_barcodeinduk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_barcodeinduk.Visible = False
        cAsset_barcodeinduk.ReadOnly = False

        cAsset_serial.Name = "asset_serial"
        cAsset_serial.HeaderText = "asset_serial"
        cAsset_serial.DataPropertyName = "asset_serial"
        cAsset_serial.Width = 100
        cAsset_serial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_serial.Visible = False
        cAsset_serial.ReadOnly = False

        cAsset_produknumber.Name = "asset_produknumber"
        cAsset_produknumber.HeaderText = "asset_produknumber"
        cAsset_produknumber.DataPropertyName = "asset_produknumber"
        cAsset_produknumber.Width = 100
        cAsset_produknumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_produknumber.Visible = False
        cAsset_produknumber.ReadOnly = False

        cAsset_model.Name = "asset_model"
        cAsset_model.HeaderText = "asset_model"
        cAsset_model.DataPropertyName = "asset_model"
        cAsset_model.Width = 100
        cAsset_model.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_model.Visible = False
        cAsset_model.ReadOnly = False

        cAsset_deskripsi.Name = "asset_deskripsi"
        cAsset_deskripsi.HeaderText = "Description"
        cAsset_deskripsi.DataPropertyName = "asset_deskripsi"
        cAsset_deskripsi.Width = 400
        cAsset_deskripsi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_deskripsi.Visible = True
        cAsset_deskripsi.ReadOnly = False

        cKategoriitem_id.Name = "kategoriitem_id"
        cKategoriitem_id.HeaderText = "kategoriitem_id"
        cKategoriitem_id.DataPropertyName = "kategoriitem_id"
        cKategoriitem_id.Width = 100
        cKategoriitem_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriitem_id.Visible = False
        cKategoriitem_id.ReadOnly = False

        cTipeitem_id.Name = "tipeitem_id"
        cTipeitem_id.HeaderText = "tipeitem_id"
        cTipeitem_id.DataPropertyName = "tipeitem_id"
        cTipeitem_id.Width = 100
        cTipeitem_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTipeitem_id.Visible = False
        cTipeitem_id.ReadOnly = False

        cAsset_golfiskal.Name = "asset_golfiskal"
        cAsset_golfiskal.HeaderText = "asset_golfiskal"
        cAsset_golfiskal.DataPropertyName = "asset_golfiskal"
        cAsset_golfiskal.Width = 100
        cAsset_golfiskal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_golfiskal.Visible = False
        cAsset_golfiskal.ReadOnly = False

        cAsset_tipedepre.Name = "asset_tipedepre"
        cAsset_tipedepre.HeaderText = "asset_tipedepre"
        cAsset_tipedepre.DataPropertyName = "asset_tipedepre"
        cAsset_tipedepre.Width = 100
        cAsset_tipedepre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_tipedepre.Visible = False
        cAsset_tipedepre.ReadOnly = False

        cAsset_depre_enddt.Name = "asset_depre_enddt"
        cAsset_depre_enddt.HeaderText = "asset_depre_enddt"
        cAsset_depre_enddt.DataPropertyName = "asset_depre_enddt"
        cAsset_depre_enddt.Width = 100
        cAsset_depre_enddt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_depre_enddt.Visible = False
        cAsset_depre_enddt.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "currency_id"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cAsset_harga.Name = "asset_harga"
        cAsset_harga.HeaderText = "asset_harga"
        cAsset_harga.DataPropertyName = "asset_harga"
        cAsset_harga.Width = 100
        cAsset_harga.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_harga.Visible = False
        cAsset_harga.ReadOnly = False

        cAsset_hargabaru.Name = "asset_hargabaru"
        cAsset_hargabaru.HeaderText = "asset_hargabaru"
        cAsset_hargabaru.DataPropertyName = "asset_hargabaru"
        cAsset_hargabaru.Width = 100
        cAsset_hargabaru.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_hargabaru.Visible = False
        cAsset_hargabaru.ReadOnly = False

        cAsset_ppn.Name = "asset_ppn"
        cAsset_ppn.HeaderText = "asset_ppn"
        cAsset_ppn.DataPropertyName = "asset_ppn"
        cAsset_ppn.Width = 100
        cAsset_ppn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_ppn.Visible = False
        cAsset_ppn.ReadOnly = False

        cAsset_pph.Name = "asset_pph"
        cAsset_pph.HeaderText = "asset_pph"
        cAsset_pph.DataPropertyName = "asset_pph"
        cAsset_pph.Width = 100
        cAsset_pph.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_pph.Visible = False
        cAsset_pph.ReadOnly = False

        cAsset_disc.Name = "asset_disc"
        cAsset_disc.HeaderText = "asset_disc"
        cAsset_disc.DataPropertyName = "asset_disc"
        cAsset_disc.Width = 100
        cAsset_disc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_disc.Visible = False
        cAsset_disc.ReadOnly = False

        cAsset_depresiasi.Name = "asset_depresiasi"
        cAsset_depresiasi.HeaderText = "asset_depresiasi"
        cAsset_depresiasi.DataPropertyName = "asset_depresiasi"
        cAsset_depresiasi.Width = 100
        cAsset_depresiasi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_depresiasi.Visible = False
        cAsset_depresiasi.ReadOnly = False

        cAsset_akum_val_depre.Name = "asset_akum_val_depre"
        cAsset_akum_val_depre.HeaderText = "asset_akum_val_depre"
        cAsset_akum_val_depre.DataPropertyName = "asset_akum_val_depre"
        cAsset_akum_val_depre.Width = 100
        cAsset_akum_val_depre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_akum_val_depre.Visible = False
        cAsset_akum_val_depre.ReadOnly = False

        cAsset_valas.Name = "asset_valas"
        cAsset_valas.HeaderText = "asset_valas"
        cAsset_valas.DataPropertyName = "asset_valas"
        cAsset_valas.Width = 100
        cAsset_valas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_valas.Visible = False
        cAsset_valas.ReadOnly = False

        cAsset_idrprice.Name = "asset_idrprice"
        cAsset_idrprice.HeaderText = "asset_idrprice"
        cAsset_idrprice.DataPropertyName = "asset_idrprice"
        cAsset_idrprice.Width = 100
        cAsset_idrprice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_idrprice.Visible = False
        cAsset_idrprice.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cEmployee_id_owner.Name = "employee_id_owner"
        cEmployee_id_owner.HeaderText = "employee_id_owner"
        cEmployee_id_owner.DataPropertyName = "employee_id_owner"
        cEmployee_id_owner.Width = 100
        cEmployee_id_owner.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEmployee_id_owner.Visible = False
        cEmployee_id_owner.ReadOnly = False

        cBrand_id.Name = "brand_id"
        cBrand_id.HeaderText = "brand_id"
        cBrand_id.DataPropertyName = "brand_id"
        cBrand_id.Width = 100
        cBrand_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBrand_id.Visible = False
        cBrand_id.ReadOnly = False

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "unit_id"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 100
        cUnit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUnit_id.Visible = False
        cUnit_id.ReadOnly = False

        cAsset_qty.Name = "asset_qty"
        cAsset_qty.HeaderText = "Qty"
        cAsset_qty.DataPropertyName = "asset_qty"
        cAsset_qty.Width = 50
        cAsset_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_qty.Visible = True
        cAsset_qty.ReadOnly = False

        cMaterial_id.Name = "material_id"
        cMaterial_id.HeaderText = "material_id"
        cMaterial_id.DataPropertyName = "material_id"
        cMaterial_id.Width = 100
        cMaterial_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cMaterial_id.Visible = False
        cMaterial_id.ReadOnly = False

        cWarna_id.Name = "warna_id"
        cWarna_id.HeaderText = "warna_id"
        cWarna_id.DataPropertyName = "warna_id"
        cWarna_id.Width = 100
        cWarna_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cWarna_id.Visible = False
        cWarna_id.ReadOnly = False

        cUkuran_id.Name = "ukuran_id"
        cUkuran_id.HeaderText = "ukuran_id"
        cUkuran_id.DataPropertyName = "ukuran_id"
        cUkuran_id.Width = 100
        cUkuran_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUkuran_id.Visible = False
        cUkuran_id.ReadOnly = False

        cJeniskelamin_id.Name = "jeniskelamin_id"
        cJeniskelamin_id.HeaderText = "jeniskelamin_id"
        cJeniskelamin_id.DataPropertyName = "jeniskelamin_id"
        cJeniskelamin_id.Width = 100
        cJeniskelamin_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJeniskelamin_id.Visible = False
        cJeniskelamin_id.ReadOnly = False

        cShow_id_cont_item.Name = "show_id_cont_item"
        cShow_id_cont_item.HeaderText = "show_id_cont_item"
        cShow_id_cont_item.DataPropertyName = "show_id_cont_item"
        cShow_id_cont_item.Width = 100
        cShow_id_cont_item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cShow_id_cont_item.Visible = False
        cShow_id_cont_item.ReadOnly = False

        cRuang_id.Name = "ruang_id"
        cRuang_id.HeaderText = "ruang_id"
        cRuang_id.DataPropertyName = "ruang_id"
        cRuang_id.Width = 100
        cRuang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRuang_id.Visible = False
        cRuang_id.ReadOnly = False

        cAsset_rak.Name = "asset_rak"
        cAsset_rak.HeaderText = "asset_rak"
        cAsset_rak.DataPropertyName = "asset_rak"
        cAsset_rak.Width = 100
        cAsset_rak.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_rak.Visible = False
        cAsset_rak.ReadOnly = False

        cIs_useable.Name = "is_useable"
        cIs_useable.HeaderText = "is_useable"
        cIs_useable.DataPropertyName = "is_useable"
        cIs_useable.Width = 100
        cIs_useable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cIs_useable.Visible = False
        cIs_useable.ReadOnly = False

        cAsset_active.Name = "asset_active"
        cAsset_active.HeaderText = "asset_active"
        cAsset_active.DataPropertyName = "asset_active"
        cAsset_active.Width = 100
        cAsset_active.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_active.Visible = False
        cAsset_active.ReadOnly = False

        cAsset_status.Name = "asset_status"
        cAsset_status.HeaderText = "asset_status"
        cAsset_status.DataPropertyName = "asset_status"
        cAsset_status.Width = 100
        cAsset_status.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_status.Visible = False
        cAsset_status.ReadOnly = False

        cProject_id.Name = "project_id"
        cProject_id.HeaderText = "project_id"
        cProject_id.DataPropertyName = "project_id"
        cProject_id.Width = 100
        cProject_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProject_id.Visible = False
        cProject_id.ReadOnly = False

        cShow_id.Name = "show_id"
        cShow_id.HeaderText = "show_id"
        cShow_id.DataPropertyName = "show_id"
        cShow_id.Width = 100
        cShow_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cShow_id.Visible = False
        cShow_id.ReadOnly = False

        cAsset_eps.Name = "asset_eps"
        cAsset_eps.HeaderText = "asset_eps"
        cAsset_eps.DataPropertyName = "asset_eps"
        cAsset_eps.Width = 100
        cAsset_eps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_eps.Visible = False
        cAsset_eps.ReadOnly = False

        cWo_id.Name = "wo_id"
        cWo_id.HeaderText = "wo_id"
        cWo_id.DataPropertyName = "wo_id"
        cWo_id.Width = 100
        cWo_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cWo_id.Visible = False
        cWo_id.ReadOnly = False

        cInputby.Name = "inputby"
        cInputby.HeaderText = "inputby"
        cInputby.DataPropertyName = "inputby"
        cInputby.Width = 100
        cInputby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cInputby.Visible = False
        cInputby.ReadOnly = False

        cInputdt.Name = "inputdt"
        cInputdt.HeaderText = "inputdt"
        cInputdt.DataPropertyName = "inputdt"
        cInputdt.Width = 100
        cInputdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cInputdt.Visible = False
        cInputdt.ReadOnly = False

        cEditby.Name = "editby"
        cEditby.HeaderText = "editby"
        cEditby.DataPropertyName = "editby"
        cEditby.Width = 100
        cEditby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEditby.Visible = False
        cEditby.ReadOnly = False

        cEditdt.Name = "editdt"
        cEditdt.HeaderText = "editdt"
        cEditdt.DataPropertyName = "editdt"
        cEditdt.Width = 100
        cEditdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEditdt.Visible = False
        cEditdt.ReadOnly = False

        cUsedby.Name = "usedby"
        cUsedby.HeaderText = "usedby"
        cUsedby.DataPropertyName = "usedby"
        cUsedby.Width = 100
        cUsedby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUsedby.Visible = False
        cUsedby.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order No."
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Order Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = False

        cJurnal.Name = "jurnal"
        cJurnal.HeaderText = "jurnal"
        cJurnal.DataPropertyName = "jurnal"
        cJurnal.Width = 100
        cJurnal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal.Visible = False
        cJurnal.ReadOnly = False

        cJurnal_by.Name = "jurnal_by"
        cJurnal_by.HeaderText = "jurnal_by"
        cJurnal_by.DataPropertyName = "jurnal_by"
        cJurnal_by.Width = 100
        cJurnal_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_by.Visible = False
        cJurnal_by.ReadOnly = False

        cJurnal_dt.Name = "jurnal_dt"
        cJurnal_dt.HeaderText = "jurnal_dt"
        cJurnal_dt.DataPropertyName = "jurnal_dt"
        cJurnal_dt.Width = 100
        cJurnal_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_dt.Visible = False
        cJurnal_dt.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimabarang_id, cOrder_id, cOrderdetil_line, cAsset_line, cChannel_id, cAsset_tgl, cTipeasset_id, _
        cKategoriasset_id, cAsset_barcode, cAsset_barcodeinduk, _
        cAsset_serial, cAsset_produknumber, cAsset_model, cAsset_deskripsi, _
        cKategoriitem_id, cTipeitem_id, cAsset_golfiskal, cAsset_tipedepre, _
        cAsset_depre_enddt, cCurrency_id, cAsset_harga, cAsset_hargabaru, _
        cAsset_ppn, cAsset_pph, cAsset_disc, cAsset_depresiasi, cAsset_akum_val_depre, _
        cAsset_valas, cAsset_idrprice, cStrukturunit_id, cEmployee_id_owner, cBrand_id, _
        cUnit_id, cAsset_qty, cAsset_lineinduk, cMaterial_id, cWarna_id, cUkuran_id, cJeniskelamin_id, _
        cShow_id_cont_item, cRuang_id, cAsset_rak, cIs_useable, cAsset_active, _
        cAsset_status, cProject_id, cShow_id, cAsset_eps, cWo_id, cInputby, _
        cInputdt, cEditby, cEditdt, cUsedby, cJurnal, _
        cJurnal_by, cJurnal_dt})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvBPBProcurement.Dock = DockStyle.Fill
        Me.FormatDgvTrnBPBProcurement(Me.DgvBPBProcurement)
        Me.FormatDgvTrnOrderdetil(Me.DgvTrnOrderdetil)
        Me.FormatDgvTrnTerimabarangdetil(Me.DgvBPB)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Notes.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Notes.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "notes"))
        
       Return True
    End Function

#End Region


#Region " Dialoged Control "
#End Region


#Region " User Defined Function "

    Private Function UiTrnBPBProcurement_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_MstWarna_Temp
        Me.tbl_TrnTerimabarang_Temp.Clear()




        Me.BindingContext(Me.tbl_TrnTerimabarang_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnTerimabarang_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function UiTrnBPBProcurement_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = String.Empty
        ' TODO: Parse Criteria using clsProc.RefParser()
        'criteria = " warna_id like '" + Me.Objsearch.Text + "%'"

        If Me.chk_orderID_search.Checked = True Then
            criteria = String.Format(" order_id = '{0}'", Me.Objsearch.SelectedValue)
        End If

        If Me.chk_BPB_search.Checked = True Then
            If criteria = String.Empty Then
                criteria = String.Format(" terimabarang_id = '{0}'", Me.ObjBPB.SelectedValue)
            Else
                criteria &= String.Format(" AND terimabarang_id = '{0}'", Me.ObjBPB.SelectedValue)
            End If
        End If

        'If Me.chk_Procurement_search.Checked = True Then
        '    If criteria = String.Empty Then
        '        If Me.cmb_appprc.SelectedItem = "Yes" Then
        '            criteria = String.Format(" appproc = 1 ")
        '        Else
        '            criteria = String.Format(" appproc = 0 ")
        '        End If
        '    Else
        '        If Me.cmb_appprc.SelectedItem = "Yes" Then
        '            criteria &= String.Format(" AND appproc = 1 ")
        '        Else
        '            criteria &= String.Format(" AND appproc = 0 ")
        '        End If
        '    End If
        'End If

        If criteria = String.Empty Then
            criteria = String.Format(" orderdetil_line <> 0") '(" appuser = 1 AND orderdetil_line <> 0")
        Else
            criteria &= String.Format(" AND orderdetil_line <> 0")
        End If

        If criteria = String.Empty Then
            criteria = String.Format(" strukturunit_id = {0} AND (LEFT(order_id, 2) = 'RO' or LEFT(order_id, 2) = 'MO')", Me._STRUKTUR_UNIT)
        Else
            criteria &= String.Format(" AND strukturunit_id = {0} AND (LEFT (order_id, 2) = 'RO' or LEFT(order_id, 2) = 'MO')", Me._STRUKTUR_UNIT)
        End If

        Me.tbl_TrnTerimabarang.Clear()
        Try
            Me.DataFill(Me.tbl_TrnTerimabarang, "as_buktiPenerimaanJasa_Select", criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function UiTrnBPBProcurement_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim order_id As String
        Me.objFormError.Clear()
        order_id = Me.DgvBPBProcurement.Rows(rowIndex).Cells("order_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(order_id)

        Try
            dbConn.Open()
            Me.UiTrnBPBProcurement_OpenRowMaster(order_id, dbConn)
            Me.UiTrnBPBProcurement_OpenRowBPBdetil(order_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": UiTrnBPBProcurement_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(order_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function UiTrnBPBProcurement_OpenRowMaster(ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnOrderdetilJasa_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("order_id ='{0}' AND orderdetil_type = 'Item' ", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOrderDetil.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnOrderDetil)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": UiMstwarna_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function UiTrnBPBProcurement_OpenRowBPBdetil(ByVal order_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnBPBdetil_select ", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("transaksi_terimabarang.order_id ='{0}' ", order_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnTerimabarangdetil.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnTerimabarangdetil)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": UiMstwarna_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function UiTrnBPBProcurement_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                'move = Me.UiMstwarna_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvBPBProcurement.CurrentCell = Me.DgvBPBProcurement(1, 0)
            Me.UiTrnBPBProcurement_RefreshPosition()
        End If
    End Function
    Private Function UiTrnBPBProcurement_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                'move = Me.UiMstwarna_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvBPBProcurement.CurrentCell.RowIndex > 0 Then
                Me.DgvBPBProcurement.CurrentCell = Me.DgvBPBProcurement(1, DgvBPBProcurement.CurrentCell.RowIndex - 1)
                Me.UiTrnBPBProcurement_RefreshPosition()
            End If
        End If
    End Function
    Private Function UiTrnBPBProcurement_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                'move = Me.UiMstwarna_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvBPBProcurement.CurrentCell.RowIndex < Me.DgvBPBProcurement.Rows.Count - 1 Then
                Me.DgvBPBProcurement.CurrentCell = Me.DgvBPBProcurement(1, DgvBPBProcurement.CurrentCell.RowIndex + 1)
                Me.UiTrnBPBProcurement_RefreshPosition()
            End If
        End If
    End Function
    Private Function UiTrnBPBProcurement_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                'move = Me.UiMstwarna_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvBPBProcurement.CurrentCell = Me.DgvBPBProcurement(1, Me.DgvBPBProcurement.Rows.Count - 1)
            Me.UiTrnBPBProcurement_RefreshPosition()
        End If
    End Function
    Private Function UiTrnBPBProcurement_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then UiTrnBPBProcurement_OpenRow(Me.DgvBPBProcurement.CurrentRow.Index)
    End Function

    'Private Function UiMstwarna_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
    '    'confirm saving data changes before move
    '    Dim tbl_MstWarna_Temp_Changes As DataTable
    '    Dim res As System.Windows.Forms.DialogResult
    '    Dim success As Boolean
    '    Dim i As Integer = 0
    '    Dim MasterDataState As System.Data.DataRowState
    '    Dim warna_id As Object = New Object
    '    Dim move As Boolean = False
    '    Dim result As FormSaveResult


    '    If Me.DgvBPBProcurement.CurrentCell IsNot Nothing Then

    '        Me.BindingContext(Me.tbl_TrnTerimabarang_Temp).EndCurrentEdit()
    '        tbl_MstWarna_Temp_Changes = Me.tbl_TrnTerimabarang_Temp.GetChanges()

    '        If tbl_MstWarna_Temp_Changes IsNot Nothing Then

    '            res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
    '            Select Case res
    '                Case DialogResult.Yes

    '                    RaiseEvent FormBeforeSave(warna_id)

    '                    Try

    '                        If tbl_MstWarna_Temp_Changes IsNot Nothing Then
    '                            success = Me.UiTrnBPBProcurement_SaveMaster(warna_id, tbl_MstWarna_Temp_Changes, MasterDataState)
    '                            If Not success Then Throw New Exception("Cannot Save Master Data")
    '                            Me.tbl_TrnTerimabarang_Temp.AcceptChanges()
    '                        End If

    '                        result = FormSaveResult.SaveSuccess
    '                        If SHOW_SAVE_CONFIRMATION Then
    '                            MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        End If

    '                    Catch ex As Exception
    '                        result = FormSaveResult.SaveError
    '                        MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    End Try

    '                    RaiseEvent FormAfterSave(warna_id, result)

    '                Case DialogResult.No
    '                    move = True
    '                Case DialogResult.Cancel
    '                    move = False
    '            End Select
    '        Else
    '            move = True
    '        End If

    '    End If

    '    Return move

    'End Function

    Private Function UiTrnBPBProcurement_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False
        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")
            'If Me.obj_Status.Text = "-- Pilih --" Or Me.obj_Status.Text = String.Empty Then
            '    ErrorMessage = "You must choose the status first"
            '    Me.objFormError.SetError(Me.obj_Status, ErrorMessage)
            '    Throw New Exception(ErrorMessage)
            'Else
            '    Me.objFormError.SetError(Me.obj_Status, "")
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection


        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
        End If

        Me.InitLayoutUI()

        Me.DgvBPBProcurement.DataSource = Me.tbl_TrnTerimabarang
        Me.DgvTrnOrderdetil.DataSource = Me.tbl_TrnOrderDetil
        Me.DgvBPB.DataSource = Me.tbl_TrnTerimabarangdetil
        If Application.ProductName = _ProductName Then
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
        End If

        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
        '    'Fill Combobox
        '    'dan fungsi2 startup lainnya....

        'End If

        Me.ComboFill(Me.ObjBPB, "terimabarang_id", "terimabarang_id", Me.tbl_TrnTerimabarang_search, "as_TrnTerimabarang_selectSearch ", " strukturunit_id = " & Me._STRUKTUR_UNIT & " AND (LEFT(order_id, 2) = 'RO' or LEFT(order_id, 2) = 'MO')")
        Me.tbl_TrnTerimabarang_search.DefaultView.Sort = "terimabarang_id"

        Me.Objsearch.SelectedValue = 0
        Me.ObjBPB.SelectedValue = 0
        'Me.obj_Status.SelectedItem = "-- Pilih --"
        'Me.cmb_appprc.SelectedItem = "Yes"

        Me.BindingStop()
        Me.BindingStart()

        Me.UiTrnBPBProcurement_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True
        Me.tbtnNew.Enabled = False
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = False

        'Me.btnlock.ToolTipText = "Lock Transaction"
        'Me.ToolStrip1.Items.Add(Me.btnlock)
        'Me.btnlock.Image = Me.ImageList1.Images(0)
    End Sub


    Private Sub UiTrnBPBProcurement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                'Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                'Me.btnlock.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Ivory
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                Me.tbtnSave.Enabled = False
                'Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                'Me.btnlock.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Ivory

                If Me.DgvBPBProcurement.CurrentRow IsNot Nothing Then
                    Me.UiTrnBPBProcurement_OpenRow(Me.DgvBPBProcurement.CurrentRow.Index)
                Else
                    Me.UiTrnBPBProcurement_NewData()
                End If
        End Select
    End Sub

    Private Sub DgvBPBProcurement_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvBPBProcurement.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvBPBProcurement.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub LockPrcData()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_Lockprctransaksi_terimabarang", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvBPBProcurement.Item("terimabarang_id", DgvBPBProcurement.CurrentRow.Index).Value
            oCm.Parameters.Add("@procurement_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me._CHANNEL  'Me.DgvBPBProcurement.Item("channel_id", DgvBPBProcurement.CurrentRow.Index).Value
            oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me.DgvBPBProcurement.Item("status", DgvBPBProcurement.CurrentRow.Index).Value
            If Me.DgvBPBProcurement.Rows(Me.DgvBPBProcurement.CurrentRow.Index).Cells("order_id").Value = String.Empty Then
                oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = 1
            Else
                oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvBPBProcurement.Rows(Me.DgvBPBProcurement.CurrentRow.Index).Cells("order_id").Value
            End If
            oCm.ExecuteNonQuery()
            oCm.Dispose()
            Me.DgvBPBProcurement.Item("appuser", DgvBPBProcurement.CurrentRow.Index).Value = 1
            MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    'Private Sub update_status()

    '    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
    '    Try
    '        dbConn.Open()
    '        Dim oDm As New OleDb.OleDbCommand("as_UpdateTransaksi_BPBProc", dbConn)
    '        oDm.CommandType = CommandType.StoredProcedure
    '        oDm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvBPBProcurement.Item("terimabarang_id", DgvBPBProcurement.CurrentRow.Index).Value
    '        oDm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me.obj_Status.SelectedItem
    '        oDm.ExecuteNonQuery()
    '        oDm.Dispose()
    '        MessageBox.Show("Data Has Been Update", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Me.UiTrnBPBProcurement_Retrieve()
    '        'Me.obj_Status.SelectedItem = "-- Pilih --"
    '    Catch ex As Data.OleDb.OleDbException
    '        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Catch ex As Exception
    '        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        dbConn.Close()
    '    End Try
    '    System.Windows.Forms.Cursor.Current = Cursors.Default
    'End Sub
    Private Sub UiTrnBPBProcurement_LoadComboSearch()


        If Me._LOADCOMBOSEARCH = False Then
            '-----Mulai Bikin Tabel untuk combo Data Search-------------------------
            Me.ComboFill(Me.Objsearch, "order_id", "order_id", Me.tbl_MstTrnOrder_search, "as_TrnOrder_Select", " strukturunit_id = " & Me._STRUKTUR_UNIT & " AND (ordertype_id = 'RO' or ordertype_id = 'MO') ")
            Me.tbl_MstTrnOrder_search.DefaultView.Sort = "order_id"

            Me._LOADCOMBOSEARCH = True
        End If

    End Sub

    Private Sub DgvBPB_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

        Try
            If objrow.Cells("orderdetil_line").Value = 0 Then
                objrow.DefaultCellStyle.BackColor = Color.White
            Else
                objrow.DefaultCellStyle.BackColor = Color.Gainsboro
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DgvBPBProcurement_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvBPBProcurement.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)
        Try
            If objrow.Cells("appuser").Value = 0 And objrow.Cells("appproc").Value = 0 Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            ElseIf objrow.Cells("appuser").Value = 1 And objrow.Cells("appproc").Value = 0 Then
                objrow.DefaultCellStyle.BackColor = Color.Aquamarine
            Else
                objrow.DefaultCellStyle.BackColor = Color.Bisque
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
