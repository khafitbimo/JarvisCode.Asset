
Public Class dlgTrnTerimaJasaDetil_Select_Editing


    Private mDSN As String
    Private mOrder As String
    Private retObj As Object
    Private order_line As String

    Private mChannel_id As String

    Private myOwner As System.Windows.Forms.IWin32Window

    Private tbl_TrnTerimaJasa_Editing As DataTable = CreateTblTrnTerimaJasa_List_EditingOrder()

    Private tbl_MstRekananGrid As DataTable = clsDataset.CreateTblMstrekananCombo



#Region " Properties "

    Public ReadOnly Property DSN() As String
        Get
            Return mDSN
        End Get
    End Property
#End Region

#Region " Constructor & Default Function"

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, _
                ByVal channel_id As String, ByVal dsn As String, ByVal order_id As String, _
                ByVal order_line As String) As Object

        mChannel_id = channel_id
        Me.mDSN = dsn
        Me.mOrder = order_id
        Me.order_line = order_line

        Me.myOwner = owner
        MyBase.ShowDialog(owner)
        Return retObj
    End Function

#End Region

#Region " UI Layout & Format "

    Public Shared Function CreateTblTrnTerimaJasa_List_EditingOrder() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("order_check", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("shift1_outstanding", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("shift2_outstanding", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("shift3_outstanding", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("eo_outstanding", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("eo_realisasi", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("orderdetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_days", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_discount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_actual", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_actualnote", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetaccount_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("old_orderdetil_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_pphpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_ppnpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_requestid_ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("orderdetil_qtyarrived", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_bpbj", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("editing_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("shift1", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("shift2", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("shift3", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("orderdetil_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("boot1", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("boot2", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("boot3", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("editor1", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("editor2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("editor3", GetType(System.String)))

        tbl.Columns("order_check").DefaultValue = False
        tbl.Columns("acc_id").DefaultValue = 0
        tbl.Columns("shift1_outstanding").DefaultValue = 0
        tbl.Columns("shift2_outstanding").DefaultValue = 0
        tbl.Columns("shift3_outstanding").DefaultValue = 0
        tbl.Columns("eo_outstanding").DefaultValue = 0
        tbl.Columns("eo_realisasi").DefaultValue = 0
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_type").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("item_id").DefaultValue = String.Empty
        tbl.Columns("unit_id").DefaultValue = 0
        tbl.Columns("orderdetil_descr").DefaultValue = String.Empty
        tbl.Columns("orderdetil_qty").DefaultValue = 0
        tbl.Columns("orderdetil_days").DefaultValue = 0
        tbl.Columns("orderdetil_idr").DefaultValue = 0
        tbl.Columns("orderdetil_foreign").DefaultValue = 0
        tbl.Columns("orderdetil_foreignrate").DefaultValue = 0
        tbl.Columns("orderdetil_discount").DefaultValue = 0
        tbl.Columns("orderdetil_actual").DefaultValue = 0
        tbl.Columns("orderdetil_actualnote").DefaultValue = String.Empty
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budgetaccount_id").DefaultValue = String.Empty
        tbl.Columns("old_orderdetil_id").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_pphpercent").DefaultValue = 0
        tbl.Columns("orderdetil_ppnpercent").DefaultValue = 0
        tbl.Columns("orderdetil_requestid_ref").DefaultValue = String.Empty
        tbl.Columns("requestdetil_line").DefaultValue = 0
        tbl.Columns("orderdetil_qtyarrived").DefaultValue = 0
        tbl.Columns("orderdetil_bpbj").DefaultValue = 0
        tbl.Columns("editing_date").DefaultValue = Now()
        tbl.Columns("shift1").DefaultValue = 0
        tbl.Columns("shift2").DefaultValue = 0
        tbl.Columns("shift3").DefaultValue = 0
        tbl.Columns("orderdetil_eps").DefaultValue = String.Empty
        tbl.Columns("boot1").DefaultValue = 0
        tbl.Columns("boot2").DefaultValue = 0
        tbl.Columns("boot3").DefaultValue = 0
        tbl.Columns("editor1").DefaultValue = String.Empty
        tbl.Columns("editor2").DefaultValue = String.Empty
        tbl.Columns("editor3").DefaultValue = String.Empty

        Return tbl

    End Function
    Private Function FormatDgvTrnOrderdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cOrder_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShift1_outstanding As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cShift2_outstanding As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cShift3_outstanding As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cEo_outstanding As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEo_realisasi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Dim cRequestdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_qtyarrived As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_bpbj As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEditing_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShift1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShift2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShift3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBoot1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBoot2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBoot3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEditor1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEditor2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEditor3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_check.Name = "order_check"
        cOrder_check.HeaderText = "Pilih"
        cOrder_check.DataPropertyName = "order_check"
        cOrder_check.Width = 40
        cOrder_check.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cOrder_check.Visible = True
        cOrder_check.ReadOnly = False

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "acc_id"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 100
        cAcc_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAcc_id.Visible = False
        cAcc_id.ReadOnly = False

        cShift1_outstanding.Name = "shift1_outstanding"
        cShift1_outstanding.HeaderText = "Shift 1"
        cShift1_outstanding.DataPropertyName = "shift1_outstanding"
        cShift1_outstanding.Width = 55
        cShift1_outstanding.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift1_outstanding.Visible = True
        cShift1_outstanding.ReadOnly = True

        cShift2_outstanding.Name = "shift2_outstanding"
        cShift2_outstanding.HeaderText = "Shift 2"
        cShift2_outstanding.DataPropertyName = "shift2_outstanding"
        cShift2_outstanding.Width = 55
        cShift2_outstanding.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift2_outstanding.Visible = True
        cShift2_outstanding.ReadOnly = True

        cShift3_outstanding.Name = "shift3_outstanding"
        cShift3_outstanding.HeaderText = "Shift 3"
        cShift3_outstanding.DataPropertyName = "shift3_outstanding"
        cShift3_outstanding.Width = 55
        cShift3_outstanding.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift3_outstanding.Visible = True
        cShift3_outstanding.ReadOnly = True

        cEo_outstanding.Name = "eo_outstanding"
        cEo_outstanding.HeaderText = "Shift Outs."
        cEo_outstanding.DataPropertyName = "eo_outstanding"
        cEo_outstanding.Width = 90
        cEo_outstanding.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cEo_outstanding.Visible = True
        cEo_outstanding.ReadOnly = True

        cEo_realisasi.Name = "eo_realisasi"
        cEo_realisasi.HeaderText = "eo_realisasi"
        cEo_realisasi.DataPropertyName = "eo_realisasi"
        cEo_realisasi.Width = 100
        cEo_realisasi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEo_realisasi.Visible = False
        cEo_realisasi.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order_id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = False
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
        cOrderdetil_line.Width = 60
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = False

        cItem_id.Name = "item_id"
        cItem_id.HeaderText = "item_id"
        cItem_id.DataPropertyName = "item_id"
        cItem_id.Width = 100
        cItem_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem_id.Visible = False
        cItem_id.ReadOnly = False

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "unit_id"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 100
        cUnit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUnit_id.Visible = False
        cUnit_id.ReadOnly = False

        cOrderdetil_descr.Name = "orderdetil_descr"
        cOrderdetil_descr.HeaderText = "Descr."
        cOrderdetil_descr.DataPropertyName = "orderdetil_descr"
        cOrderdetil_descr.Width = 100
        cOrderdetil_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_descr.Visible = True
        cOrderdetil_descr.ReadOnly = True

        cOrderdetil_qty.Name = "orderdetil_qty"
        cOrderdetil_qty.HeaderText = "orderdetil_qty"
        cOrderdetil_qty.DataPropertyName = "orderdetil_qty"
        cOrderdetil_qty.Width = 100
        cOrderdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_qty.Visible = False
        cOrderdetil_qty.ReadOnly = False

        cOrderdetil_days.Name = "orderdetil_days"
        cOrderdetil_days.HeaderText = "orderdetil_days"
        cOrderdetil_days.DataPropertyName = "orderdetil_days"
        cOrderdetil_days.Width = 100
        cOrderdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_days.Visible = False
        cOrderdetil_days.ReadOnly = False

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

        cRequestdetil_line.Name = "requestdetil_line"
        cRequestdetil_line.HeaderText = "requestdetil_line"
        cRequestdetil_line.DataPropertyName = "requestdetil_line"
        cRequestdetil_line.Width = 100
        cRequestdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRequestdetil_line.Visible = False
        cRequestdetil_line.ReadOnly = False

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

        cEditing_date.Name = "editing_date"
        cEditing_date.HeaderText = "Editing Date"
        cEditing_date.DataPropertyName = "editing_date"
        cEditing_date.Width = 100
        cEditing_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEditing_date.Visible = True
        cEditing_date.ReadOnly = True

        cShift1.Name = "shift1"
        cShift1.HeaderText = "shift1"
        cShift1.DataPropertyName = "shift1"
        cShift1.Width = 100
        cShift1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cShift1.Visible = False
        cShift1.ReadOnly = False

        cShift2.Name = "shift2"
        cShift2.HeaderText = "shift2"
        cShift2.DataPropertyName = "shift2"
        cShift2.Width = 100
        cShift2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cShift2.Visible = False
        cShift2.ReadOnly = False

        cShift3.Name = "shift3"
        cShift3.HeaderText = "shift3"
        cShift3.DataPropertyName = "shift3"
        cShift3.Width = 100
        cShift3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cShift3.Visible = False
        cShift3.ReadOnly = False

        cOrderdetil_eps.Name = "orderdetil_eps"
        cOrderdetil_eps.HeaderText = "orderdetil_eps"
        cOrderdetil_eps.DataPropertyName = "orderdetil_eps"
        cOrderdetil_eps.Width = 100
        cOrderdetil_eps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_eps.Visible = False
        cOrderdetil_eps.ReadOnly = False

        cBoot1.Name = "boot1"
        cBoot1.HeaderText = "Boot 1"
        cBoot1.DataPropertyName = "boot1"
        cBoot1.Width = 65
        cBoot1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot1.Visible = True
        cBoot1.ReadOnly = True

        cBoot2.Name = "boot2"
        cBoot2.HeaderText = "Boot 2"
        cBoot2.DataPropertyName = "boot2"
        cBoot2.Width = 65
        cBoot2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot2.Visible = True
        cBoot2.ReadOnly = True

        cBoot3.Name = "boot3"
        cBoot3.HeaderText = "Boot 3"
        cBoot3.DataPropertyName = "boot3"
        cBoot3.Width = 65
        cBoot3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot3.Visible = True
        cBoot3.ReadOnly = True

        cEditor1.Name = "editor1"
        cEditor1.HeaderText = "editor1"
        cEditor1.DataPropertyName = "editor1"
        cEditor1.Width = 100
        cEditor1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEditor1.Visible = False
        cEditor1.ReadOnly = False

        cEditor2.Name = "editor2"
        cEditor2.HeaderText = "editor2"
        cEditor2.DataPropertyName = "editor2"
        cEditor2.Width = 100
        cEditor2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEditor2.Visible = False
        cEditor2.ReadOnly = False

        cEditor3.Name = "editor3"
        cEditor3.HeaderText = "editor3"
        cEditor3.DataPropertyName = "editor3"
        cEditor3.Width = 100
        cEditor3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEditor3.Visible = False
        cEditor3.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_check, cOrderdetil_line, cShift1_outstanding, cBoot1, _
        cShift2_outstanding, cBoot2, cShift3_outstanding, cBoot3, cEo_outstanding, _
         cAcc_id, cEo_realisasi, cOrder_id, cOrderdetil_type, cItem_id, _
        cUnit_id, cOrderdetil_descr, cOrderdetil_qty, cOrderdetil_days, cOrderdetil_idr, _
        cOrderdetil_foreign, cOrderdetil_foreignrate, cOrderdetil_discount, cOrderdetil_actual, _
        cOrderdetil_actualnote, cCurrency_id, cBudget_id, cBudgetdetil_id, cBudgetaccount_id, _
        cOld_orderdetil_id, cChannel_id, cOrderdetil_pphpercent, cOrderdetil_ppnpercent, _
        cOrderdetil_requestid_ref, cRequestdetil_line, cOrderdetil_qtyarrived, cOrderdetil_bpbj, _
        cEditing_date, cShift1, cShift2, cShift3, cOrderdetil_eps, cEditor1, _
        cEditor2, cEditor3})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False

    End Function

#End Region

#Region " User defined function "

    Private Function dlgTrnJurnalDetilSelect_Load(ByVal channel_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim criteria = ""
        Dim cookie As Byte() = Nothing


        Dim txtSearchCriteria As String = ""
        Dim txtSQLSearch As String = String.Empty

        ' ''txtSQLSearch = txtSQLSearch & " status <> 'COMPLETE' AND order_canceled = 0 "

        criteria = txtSQLSearch


        dbCmd = New OleDb.OleDbCommand("as_TrnTerimajasadetil_Select_Editing", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@Criteria").Value = criteria
        dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@order_id").Value = Me.mOrder


        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnTerimaJasa_Editing.Clear()

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(Me.tbl_TrnTerimaJasa_Editing)
            If Me.order_line <> String.Empty Then
                Me.tbl_TrnTerimaJasa_Editing.DefaultView.RowFilter = String.Format(" orderdetil_line not in {0}", Me.order_line)
            End If
            Me.DgvEditingOrder.DataSource = Me.tbl_TrnTerimaJasa_Editing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgTrnJurnalSelect" & ": dlgTrnJurnalDetilSelect_LoadDetil()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

#End Region


    Private Sub dlgTrnTerimaJasaDetil_Select_Editing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Cursor = Cursors.WaitCursor
        Me.FormatDgvTrnOrderdetil(Me.DgvEditingOrder)
        Me.DgvEditingOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dlgTrnJurnalDetilSelect_Load(Me.mChannel_id)
        Me.DgvEditingOrder.DataSource = Me.tbl_TrnTerimaJasa_Editing

        Me.Cursor = Cursors.Arrow

    End Sub

    '=============================Button================================================================================================================================================================

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim tblDetil As DataTable = CreateTblTrnTerimaJasa_List_EditingOrder()
        Dim row As DataRow
        Dim thisRetObj As Collection = New Collection

        Dim tbl_TrnTerimaJasa1 As DataTable = CreateTblTrnTerimaJasa_List_EditingOrder()
        Dim i, j As Integer
        Dim columnName As String

        tbl_TrnTerimaJasa1.Clear()
        tbl_TrnTerimaJasa1 = Me.tbl_TrnTerimaJasa_Editing.Copy()
        tbl_TrnTerimaJasa1.DefaultView.RowFilter = "order_check = 'True'"

        If Me.DgvEditingOrder.CurrentRow IsNot Nothing Then
            If tbl_TrnTerimaJasa1.DefaultView.Count > 0 Then
                For i = 0 To tbl_TrnTerimaJasa1.DefaultView.Count - 1
                    row = tblDetil.NewRow()
                    For j = 0 To tbl_TrnTerimaJasa1.Columns.Count - 1
                        columnName = tbl_TrnTerimaJasa1.Columns(j).ColumnName
                        row.Item(columnName) = tbl_TrnTerimaJasa1.DefaultView.Item(i).Item(columnName)
                    Next
                    tblDetil.Rows.Add(row)
                Next

                thisRetObj.Add(tblDetil.Copy(), "tblDetil")
                retObj = thisRetObj

                Me.Close()
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.retObj = Nothing
        Me.Close()
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub LinkCheck1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkCheck1.LinkClicked
        Dim i As Integer

        For i = 0 To Me.tbl_TrnTerimaJasa_Editing.Rows.Count - 1
            Me.tbl_TrnTerimaJasa_Editing.Rows(i).Item("order_check") = True
        Next
        Me.DgvEditingOrder.DataSource = Me.tbl_TrnTerimaJasa_Editing
    End Sub

    Private Sub LinkClear1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkClear1.LinkClicked
        Dim i As Integer

        For i = 0 To Me.tbl_TrnTerimaJasa_Editing.Rows.Count - 1
            Me.tbl_TrnTerimaJasa_Editing.Rows(i).Item("order_check") = False
        Next
        Me.DgvEditingOrder.DataSource = Me.tbl_TrnTerimaJasa_Editing
    End Sub


End Class
