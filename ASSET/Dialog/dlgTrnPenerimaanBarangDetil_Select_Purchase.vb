Public Class dlgTrnPenerimaanBarangDetil_Select_Purchase

    Private mDSN As String
    Private mOrder As String
    Private retObj As Object
    Private order_line As String

    Private mChannel_id As String

    Private myOwner As System.Windows.Forms.IWin32Window

    Private tbl_TrnTerimabarang_Purchase As DataTable = CreateTblTrnPenerimaanBarang_List_PurchaseOrder()

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

    Function CreateTblTrnPenerimaanBarang_List_PurchaseOrder() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()

        tbl.Columns.Add(New DataColumn("order_check", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("po_outstanding", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("po_realisasi", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("item_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("category_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_utilizedtimestart", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_utilizedtimeend", GetType(System.String)))
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
        tbl.Columns.Add(New DataColumn("orderdetilqtyarrived", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_bpj", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("requestdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("isadvance", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("advance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("budgetdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("orderdetil_rowtotalidr_incldisc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_rowtotalforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_rowtotalforeign_incldisc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_rowtotalidr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_ppn", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_rowtotalforeign_incltax", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_rowtotalidr_incltax", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_pphforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_ppnforeign", GetType(System.Decimal)))

        tbl.Columns("order_check").DefaultValue = False
        tbl.Columns("acc_id").DefaultValue = String.Empty
        tbl.Columns("po_outstanding").DefaultValue = 0
        tbl.Columns("po_realisasi").DefaultValue = 0
        tbl.Columns("item_name").DefaultValue = String.Empty
        tbl.Columns("category_id").DefaultValue = String.Empty
        tbl.Columns("order_utilizedtimestart").DefaultValue = String.Empty
        tbl.Columns("order_utilizedtimeend").DefaultValue = String.Empty
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
        tbl.Columns("orderdetilqtyarrived").DefaultValue = 0
        tbl.Columns("orderdetil_bpj").DefaultValue = 0
        tbl.Columns("requestdetil_line").DefaultValue = 0
        tbl.Columns("isadvance").DefaultValue = 0
        tbl.Columns("advance_id").DefaultValue = String.Empty
        tbl.Columns("advancedetil_line").DefaultValue = 0
        tbl.Columns("budgetdetil_line").DefaultValue = 0
        tbl.Columns("orderdetil_rowtotalidr_incldisc").DefaultValue = 0
        tbl.Columns("orderdetil_rowtotalforeign").DefaultValue = 0
        tbl.Columns("orderdetil_rowtotalforeign_incldisc").DefaultValue = 0
        tbl.Columns("orderdetil_rowtotalidr").DefaultValue = 0
        tbl.Columns("orderdetil_pph").DefaultValue = 0
        tbl.Columns("orderdetil_ppn").DefaultValue = 0
        tbl.Columns("orderdetil_rowtotalforeign_incltax").DefaultValue = 0
        tbl.Columns("orderdetil_rowtotalidr_incltax").DefaultValue = 0
        tbl.Columns("orderdetil_pphforeign").DefaultValue = 0
        tbl.Columns("orderdetil_ppnforeign").DefaultValue = 0

        Return tbl
    End Function

    Private Function FormatDgvTrnOrderdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cOrder_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cPo_outstanding As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPo_realisasi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCategory_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

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
        Dim cOrderdetil_qtyarrived As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_bpbj As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        cOrder_check.Name = "order_check"
        cOrder_check.HeaderText = "Pilih"
        cOrder_check.DataPropertyName = "order_check"
        cOrder_check.Width = 40
        cOrder_check.Visible = True
        cOrder_check.ReadOnly = False

        cPo_outstanding.Name = "po_outstanding"
        cPo_outstanding.HeaderText = "Qty Outstanding"
        cPo_outstanding.DataPropertyName = "po_outstanding"
        cPo_outstanding.Width = 120
        cPo_outstanding.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cPo_outstanding.Visible = True
        cPo_outstanding.ReadOnly = True
        cPo_outstanding.DefaultCellStyle.Format = "#,##0"

        cPo_realisasi.Name = "po_realisasi"
        cPo_realisasi.HeaderText = "Qty Realisasi"
        cPo_realisasi.DataPropertyName = "po_realisasi"
        cPo_realisasi.Width = 100
        cPo_realisasi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPo_realisasi.Visible = False
        cPo_realisasi.ReadOnly = False

        cItem_name.Name = "item_name"
        cItem_name.HeaderText = "Name"
        cItem_name.DataPropertyName = "item_name"
        cItem_name.Width = 200
        cItem_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem_name.Visible = True
        cItem_name.ReadOnly = True

        cCategory_id.Name = "category_id"
        cCategory_id.HeaderText = "Category"
        cCategory_id.DataPropertyName = "category_id"
        cCategory_id.Width = 100
        cCategory_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCategory_id.Visible = False
        cCategory_id.ReadOnly = False

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
        cOrderdetil_line.Width = 40
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = True

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
        cOrderdetil_descr.HeaderText = "Description"
        cOrderdetil_descr.DataPropertyName = "orderdetil_descr"
        cOrderdetil_descr.Width = 200
        cOrderdetil_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_descr.Visible = True
        cOrderdetil_descr.ReadOnly = False

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

        cRequestdetil_line.Name = "requestdetil_line"
        cRequestdetil_line.HeaderText = "requestdetil_line"
        cRequestdetil_line.DataPropertyName = "requestdetil_line"
        cRequestdetil_line.Width = 100
        cRequestdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRequestdetil_line.Visible = False
        cRequestdetil_line.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_check, cOrder_id, cOrderdetil_type, cOrderdetil_line, cItem_id, cItem_name, cCategory_id, cUnit_id, cOrderdetil_descr, _
        cOrderdetil_qty, cPo_outstanding, cPo_realisasi, cOrderdetil_days, cOrderdetil_idr, cOrderdetil_foreign, cOrderdetil_foreignrate, _
        cOrderdetil_discount, cOrderdetil_actual, cOrderdetil_actualnote, cCurrency_id, cBudget_id, _
        cBudgetdetil_id, cBudgetaccount_id, cOld_orderdetil_id, cChannel_id, cOrderdetil_pphpercent, _
        cOrderdetil_ppnpercent, cOrderdetil_requestid_ref, cOrderdetil_qtyarrived, cOrderdetil_bpbj, _
        cRequestdetil_line})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
    End Function
#End Region

#Region " User defined function "

    Private Function dlgTrnPenerimaanBarangDetilSelect_Load(ByVal channel_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim criteria = ""
        Dim txtSearchCriteria As String = ""
        Dim txtSQLSearch As String = String.Empty
        Dim cookie As Byte() = Nothing

        criteria = txtSQLSearch

        dbCmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarangdetil_Select_Purchase", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@Criteria").Value = criteria
        dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@order_id").Value = Me.mOrder

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnTerimabarang_Purchase.Clear()

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(Me.tbl_TrnTerimabarang_Purchase)
            If Me.order_line <> String.Empty Then
                Me.tbl_TrnTerimabarang_Purchase.DefaultView.RowFilter = String.Format(" orderdetil_line not in {0}", Me.order_line)
            End If
            Me.DgvPurchaseOrder.DataSource = Me.tbl_TrnTerimabarang_Purchase
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgTrnPenerimaanBarangDetilSelect" & ": dlgTrnPenerimaanBarangDetilSelect_LoadDetil()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

#End Region


    Private Sub dlgTrnPenerimaanBarangDetil_Select_Purchase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor

        Me.FormatDgvTrnOrderdetil(Me.DgvPurchaseOrder)
        Me.DgvPurchaseOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dlgTrnPenerimaanBarangDetilSelect_Load(Me.mChannel_id)
        Me.DgvPurchaseOrder.DataSource = Me.tbl_TrnTerimabarang_Purchase

        Me.Cursor = Cursors.Arrow
    End Sub

    '=============================Button================================================================================================================================================================

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim tblDetil As DataTable = CreateTblTrnPenerimaanBarang_List_PurchaseOrder()
        Dim row As DataRow
        Dim thisRetObj As Collection = New Collection

        Dim tbl_TrnTerimaBarang1 As DataTable = CreateTblTrnPenerimaanBarang_List_PurchaseOrder()
        Dim i, j As Integer
        Dim columnName As String

        tbl_TrnTerimaBarang1.Clear()
        tbl_TrnTerimaBarang1 = Me.tbl_TrnTerimabarang_Purchase.Copy()
        tbl_TrnTerimaBarang1.DefaultView.RowFilter = "order_check = 'True'"

        If Me.DgvPurchaseOrder.CurrentRow IsNot Nothing Then
            If tbl_TrnTerimaBarang1.DefaultView.Count > 0 Then
                For i = 0 To tbl_TrnTerimaBarang1.DefaultView.Count - 1
                    row = tblDetil.NewRow()
                    For j = 0 To tbl_TrnTerimaBarang1.Columns.Count - 1
                        columnName = tbl_TrnTerimaBarang1.Columns(j).ColumnName
                        row.Item(columnName) = tbl_TrnTerimaBarang1.DefaultView.Item(i).Item(columnName)
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

    Private Sub DgvPurchaseOrder_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvPurchaseOrder.CellFormatting
        Dim Selected As Boolean
        Dim obj As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = obj.Rows(e.RowIndex)

        Try

            Selected = CBool(objRow.Cells("order_check").Value)

            If Selected Then
                objRow.DefaultCellStyle.BackColor = Color.LightBlue
            Else
                If objRow.Cells("status").Value = "COMPLETE" Then
                    objRow.DefaultCellStyle.BackColor = Color.Thistle
                ElseIf objRow.Cells("status").Value = "-- Pilih --" Then
                    objRow.DefaultCellStyle.BackColor = Color.Aquamarine
                ElseIf objRow.Cells("status").Value = "INCOMPLETE" Then
                    objRow.DefaultCellStyle.BackColor = Color.Red
                Else
                    objRow.DefaultCellStyle.BackColor = Color.White
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub LinkCheck1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkCheck1.LinkClicked
        Dim i As Integer

        For i = 0 To Me.tbl_TrnTerimabarang_Purchase.Rows.Count - 1
            Me.tbl_TrnTerimabarang_Purchase.Rows(i).Item("order_check") = True
        Next
        Me.DgvPurchaseOrder.DataSource = Me.tbl_TrnTerimabarang_Purchase
    End Sub

    Private Sub LinkClear1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkClear1.LinkClicked
        Dim i As Integer

        For i = 0 To Me.tbl_TrnTerimabarang_Purchase.Rows.Count - 1
            Me.tbl_TrnTerimabarang_Purchase.Rows(i).Item("order_check") = False
        Next
        Me.DgvPurchaseOrder.DataSource = Me.tbl_TrnTerimabarang_Purchase
    End Sub

End Class

