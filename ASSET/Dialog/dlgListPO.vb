Imports System.Windows.Forms

Public Class dlgListPO

    Private CloseButtonIsPressed As Boolean
    Private order_id As String
    Private dsn As String
    Private orderdetil_line As Integer
    Private list_id As String

    Private isJasa As String
    
    Private tbl_MstTrnOrderdetil As DataTable = clsDataset.CreateTblTrnOrderdetil()
    Private tbl_MstTrnOrder_temps As DataTable = clsDataset.CreateTblTrnOrderdetil()
    Private tbl_trnOrderdetilJasa As DataTable = clsDataset.CreateTblTrnOrderdetilJasa()
    Private tbl_TrnOrderdetilJasa_temps As DataTable = clsDataset.CreateTblTrnOrderdetilJasa()
    Private rettbl As DataTable = clsDataset.CreateTblTrnOrderdetil()
    Private retTblJasa As DataTable = clsDataset.CreateTblTrnOrderdetilJasa()


    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As DataTable
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = String.Empty
        'Dim tabell As New DataTable
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)

        'Dim row As Integer
        'Dim maxRow As Integer

        Try
            If isJasa = "PO" Then
                If Me.list_id = String.Empty Then
                    criteria = String.Format("order_id = '{0}' AND orderdetil_type = 'Item' AND orderdetil_bpbj = 0", Me.order_id)
                Else
                    criteria = String.Format("order_id = '{0}' AND orderdetil_type = 'Item' AND orderdetil_line not in {1} AND orderdetil_bpbj = 0", Me.order_id, Me.list_id)
                End If
            Else
                If Me.list_id = String.Empty Then
                    criteria = String.Format("tb.order_id = '{0}' AND tb.orderdetil_type = 'Item' AND tb.orderdetil_bpbj = 0", Me.order_id)
                Else
                    criteria = String.Format("tb.order_id = '{0}' AND tb.orderdetil_type = 'Item' AND tb.orderdetil_line not in {1} AND tb.orderdetil_bpbj = 0", Me.order_id, Me.list_id)
                End If
            End If

            If isJasa = "RO" Then
                Me.Text = "List Rental Order"
            ElseIf isJasa = "MO" Then
                Me.Text = "LIst Maintenance Order"
            ElseIf isJasa = "TO" Then
                Me.Text = "LIst Talent Order"
            ElseIf isJasa = "EO" Then
                Me.Text = "List Editing Order"
            Else
                Me.Text = "List Purchase Order"
            End If

            Me.tbl_trnOrderdetilJasa.Columns.Add(New DataColumn("select", GetType(System.Byte)))
            Me.tbl_trnOrderdetilJasa.Columns("select").DefaultValue = 0

            If isJasa = "RO" Or isJasa = "MO" Then
                Me.tbl_trnOrderdetilJasa.Clear()
                oDataFiller.DataFill(Me.tbl_trnOrderdetilJasa, "as_TrnOrderdetilJasa_Select", criteria)
                Me.DgvListPO.DataSource = Me.tbl_trnOrderdetilJasa
                Me.FormatDgvTrnOrderdetilJasa(Me.DgvListPO)
                tbl_MstTrnOrderdetil.Columns.Add("select", GetType(System.Boolean))
                tbl_MstTrnOrderdetil.Columns("select").DefaultValue = 0
            ElseIf isJasa = "TO" Then
                Me.tbl_trnOrderdetilJasa.Clear()
                oDataFiller.DataFill(Me.tbl_trnOrderdetilJasa, "as_TrnOrderdetilJasa_SelectTO", criteria)
                Me.DgvListPO.DataSource = Me.tbl_trnOrderdetilJasa
                Me.FormatDgvTrnOrderdetilJasa(Me.DgvListPO)
                tbl_MstTrnOrderdetil.Columns.Add("select", GetType(System.Boolean))
                tbl_MstTrnOrderdetil.Columns("select").DefaultValue = 0
            ElseIf isJasa = "EO" Then
                Me.tbl_trnOrderdetilJasa.Clear()
                oDataFiller.DataFill(Me.tbl_trnOrderdetilJasa, "as_TrnOrderDetilJasa_SelectEO", criteria)
                Me.DgvListPO.DataSource = Me.tbl_trnOrderdetilJasa
                Me.FormatDgvTrnOrderdetilJasaEditing(Me.DgvListPO)
                tbl_MstTrnOrderdetil.Columns.Add("select", GetType(System.Boolean))
                tbl_MstTrnOrderdetil.Columns("select").DefaultValue = 0
            Else

                Me.tbl_MstTrnOrderdetil.Clear()
                ' ''oDataFiller.DataFill(tbl_MstTrnOrderdetil, "as_TrnOrderDetilJasa_Select", criteria)
                oDataFiller.DataFill(tbl_MstTrnOrderdetil, "as_TrnOrderdetil_Select", criteria)
                Me.DgvListPO.DataSource = tbl_MstTrnOrderdetil
                Me.FormatDgvTrnOrderdetil(Me.DgvListPO)
                tbl_MstTrnOrderdetil.Columns.Add("select", GetType(System.Boolean))
                tbl_MstTrnOrderdetil.Columns("select").DefaultValue = 0
            End If

        Catch ex As Exception
        End Try

        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            If isJasa = "RO" Or isJasa = "MO" Or isJasa = "TO" Or isJasa = "EO" Then
                Return Me.retTblJasa
            Else
                Return Me.rettbl
            End If
        Else
            Return Nothing
        End If
    End Function
    Private Function FormatDgvTrnOrderdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
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

        cSelect.Name = "select"
        cSelect.HeaderText = "Select"
        cSelect.DataPropertyName = "select"
        cSelect.Width = 50
        cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cSelect.Frozen = True
        cSelect.Visible = True
        cSelect.ReadOnly = False

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
        cOrderdetil_line.Width = 70
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
        cOrderdetil_descr.Width = 300
        cOrderdetil_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_descr.Visible = True
        cOrderdetil_descr.ReadOnly = True

        cOrderdetil_qty.Name = "orderdetil_qty"
        cOrderdetil_qty.HeaderText = "Qty"
        cOrderdetil_qty.DataPropertyName = "orderdetil_qty"
        cOrderdetil_qty.Width = 70
        cOrderdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_qty.Visible = True
        cOrderdetil_qty.ReadOnly = True

        cOrderdetil_days.Name = "orderdetil_days"
        cOrderdetil_days.HeaderText = "Days"
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

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cSelect, cOrderdetil_descr, cOrder_id, cOrderdetil_type, cOrderdetil_line, cItem_id, cUnit_id, cOrderdetil_itemmigrasi, cOrderdetil_qty, cOrderdetil_days, cOrderdetil_idr, cOrderdetil_foreign, cOrderdetil_foreignrate, cOrderdetil_discount, cOrderdetil_actual, cOrderdetil_actualnote, cCurrency_id, cBudget_id, cBudgetdetil_id, cBudgetaccount_id, cOld_orderdetil_id, cChannel_id, cOrderdetil_pphpercent, cOrderdetil_ppnpercent, cOrderdetil_requestid_ref})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function
    Private Function FormatDgvTrnOrderdetilJasa(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Dim cItem_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cSelect.Name = "select"
        cSelect.HeaderText = "Select"
        cSelect.DataPropertyName = "select"
        cSelect.Width = 50
        cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cSelect.Frozen = True
        cSelect.Visible = True
        cSelect.ReadOnly = False

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
        cOrderdetil_line.Width = 70
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

        cOrderdetil_itemmigrasi.Name = "orderdetil_itemmigrasi"
        cOrderdetil_itemmigrasi.HeaderText = "orderdetil_itemmigrasi"
        cOrderdetil_itemmigrasi.DataPropertyName = "orderdetil_itemmigrasi"
        cOrderdetil_itemmigrasi.Width = 100
        cOrderdetil_itemmigrasi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_itemmigrasi.Visible = False
        cOrderdetil_itemmigrasi.ReadOnly = False

        cOrderdetil_descr.Name = "orderdetil_descr"
        cOrderdetil_descr.HeaderText = "Descr. Item"
        cOrderdetil_descr.DataPropertyName = "orderdetil_descr"
        cOrderdetil_descr.Width = 200
        cOrderdetil_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_descr.Visible = True
        cOrderdetil_descr.ReadOnly = True

        cOrderdetil_qty.Name = "orderdetil_qty"
        cOrderdetil_qty.HeaderText = "Qty"
        cOrderdetil_qty.DataPropertyName = "orderdetil_qty"
        cOrderdetil_qty.Width = 50
        cOrderdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_qty.Visible = True
        cOrderdetil_qty.ReadOnly = True
        cOrderdetil_qty.DefaultCellStyle.Format = "###,##0"

        cOrderdetil_days.Name = "days_valid"
        If Me.isJasa = "TO" Then
            cOrderdetil_days.HeaderText = "Eps."
        Else
            cOrderdetil_days.HeaderText = "Days"
        End If
        cOrderdetil_days.DataPropertyName = "days_valid"
        cOrderdetil_days.Width = 50
        cOrderdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_days.Visible = True
        cOrderdetil_days.ReadOnly = True
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

        cItem_id_string.Name = "item_id_string"
        cItem_id_string.HeaderText = "Description"
        cItem_id_string.DataPropertyName = "item_id_string"
        cItem_id_string.Width = 300
        cItem_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem_id_string.Visible = True
        cItem_id_string.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cSelect, cItem_id_string, cOrder_id, cOrderdetil_type, cOrderdetil_line, cItem_id, cUnit_id, cOrderdetil_itemmigrasi, cOrderdetil_descr, cOrderdetil_qty, cOrderdetil_days, cOrderdetil_idr, cOrderdetil_foreign, cOrderdetil_foreignrate, cOrderdetil_discount, cOrderdetil_actual, cOrderdetil_actualnote, cCurrency_id, cBudget_id, cBudgetdetil_id, cBudgetaccount_id, cOld_orderdetil_id, cChannel_id, cOrderdetil_pphpercent, cOrderdetil_ppnpercent, cOrderdetil_requestid_ref})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function
    Private Function FormatDgvTrnOrderdetilJasaEditing(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Dim cItem_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShift1 As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cBoot1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShift2 As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cBoot2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShift3 As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cBoot3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEditing_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cSelect.Name = "select"
        cSelect.HeaderText = "Select"
        cSelect.DataPropertyName = "select"
        cSelect.Width = 50
        cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cSelect.Frozen = True
        cSelect.Visible = True
        cSelect.ReadOnly = False

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
        cOrderdetil_line.Width = 70
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

        cOrderdetil_itemmigrasi.Name = "orderdetil_itemmigrasi"
        cOrderdetil_itemmigrasi.HeaderText = "orderdetil_itemmigrasi"
        cOrderdetil_itemmigrasi.DataPropertyName = "orderdetil_itemmigrasi"
        cOrderdetil_itemmigrasi.Width = 100
        cOrderdetil_itemmigrasi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_itemmigrasi.Visible = False
        cOrderdetil_itemmigrasi.ReadOnly = False

        cOrderdetil_descr.Name = "orderdetil_descr"
        cOrderdetil_descr.HeaderText = "Descr. Item"
        cOrderdetil_descr.DataPropertyName = "orderdetil_descr"
        cOrderdetil_descr.Width = 200
        cOrderdetil_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_descr.Visible = True
        cOrderdetil_descr.ReadOnly = True

        cOrderdetil_qty.Name = "orderdetil_qty"
        cOrderdetil_qty.HeaderText = "Qty"
        cOrderdetil_qty.DataPropertyName = "orderdetil_qty"
        cOrderdetil_qty.Width = 50
        cOrderdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_qty.Visible = True
        cOrderdetil_qty.ReadOnly = True
        cOrderdetil_qty.DefaultCellStyle.Format = "###,##0"

        cOrderdetil_days.Name = "days_valid"
        cOrderdetil_days.HeaderText = "Shift"
        cOrderdetil_days.DataPropertyName = "days_valid"
        cOrderdetil_days.Width = 50
        cOrderdetil_days.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_days.Visible = True
        cOrderdetil_days.ReadOnly = True
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

        cItem_id_string.Name = "item_id_string"
        cItem_id_string.HeaderText = "Description"
        cItem_id_string.DataPropertyName = "item_id_string"
        cItem_id_string.Width = 300
        cItem_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem_id_string.Visible = True
        cItem_id_string.ReadOnly = True

        cShift1.Name = "shift1"
        cShift1.HeaderText = "Shift 1"
        cShift1.DataPropertyName = "shift1"
        cShift1.Width = 50
        cShift1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift1.Visible = True
        cShift1.ReadOnly = True

        cBoot1.Name = "boot1"
        cBoot1.HeaderText = "Boot 1"
        cBoot1.DataPropertyName = "boot1"
        cBoot1.Width = 50
        cBoot1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot1.Visible = True
        cBoot1.ReadOnly = True

        cShift2.Name = "shift2"
        cShift2.HeaderText = "Shift 2"
        cShift2.DataPropertyName = "shift2"
        cShift2.Width = 50
        cShift2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift2.Visible = True
        cShift2.ReadOnly = True

        cBoot2.Name = "boot2"
        cBoot2.HeaderText = "Boot 2"
        cBoot2.DataPropertyName = "boot2"
        cBoot2.Width = 50
        cBoot2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot2.Visible = True
        cBoot2.ReadOnly = True

        cShift3.Name = "shift3"
        cShift3.HeaderText = "Shift 3"
        cShift3.DataPropertyName = "shift3"
        cShift3.Width = 50
        cShift3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift3.Visible = True
        cShift3.ReadOnly = True

        cBoot3.Name = "boot3"
        cBoot3.HeaderText = "Boot 3"
        cBoot3.DataPropertyName = "boot3"
        cBoot3.Width = 50
        cBoot3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot3.Visible = True
        cBoot3.ReadOnly = True

        cEditing_date.Name = "editing_date"
        cEditing_date.HeaderText = "Editing Date"
        cEditing_date.DataPropertyName = "editing_date"
        cEditing_date.Width = 100
        cEditing_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEditing_date.Visible = True
        cEditing_date.ReadOnly = True


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cSelect, cOrder_id, cOrderdetil_type, cOrderdetil_line, cItem_id, cUnit_id, _
        cOrderdetil_itemmigrasi, cOrderdetil_descr, cShift1, cBoot1, cShift2, cBoot2, cShift3, cBoot3, _
        cEditing_date, cItem_id_string, cOrderdetil_qty, cOrderdetil_days, cOrderdetil_idr, _
        cOrderdetil_foreign, cOrderdetil_foreignrate, cOrderdetil_discount, cOrderdetil_actual, _
        cOrderdetil_actualnote, cCurrency_id, cBudget_id, cBudgetdetil_id, _
        cBudgetaccount_id, cOld_orderdetil_id, cChannel_id, cOrderdetil_pphpercent, _
        cOrderdetil_ppnpercent, cOrderdetil_requestid_ref})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim obj As Button = sender
        Dim row As DataRow
        Dim maxRow As Integer = DgvListPO.RowCount

        If Me.DgvListPO.Rows.Count > 0 Then

            maxRow = Me.DgvListPO.RowCount - 1
            'For row = 0 To maxRow
            '    If clsUtil.IsDbNull(Me.DgvListPO.Item("select", row).Value, False) = True Then
            '        Me.orderdetil_line = Me.DgvListPO.Rows(row).Cells("orderdetil_line").Value
            '    End If
            'Next


            Dim rowInt As Integer = 0
            
            Dim thisRetObj As Collection = New Collection
            Dim i As Integer
            Dim col As Integer
            Dim columnName As String

            If isJasa = "RO" Or isJasa = "MO" Or isJasa = "TO" Or isJasa = "EO" Then
                ' ''For i = 0 To DgvListPO.RowCount - 1
                For i = 0 To tbl_trnOrderdetilJasa.Rows.Count - 1
                    If clsUtil.IsDbNull(Me.tbl_trnOrderdetilJasa.Rows(i).Item("select"), 0) = 1 Then
                        row = tbl_TrnOrderdetilJasa_temps.NewRow
                        For col = 0 To tbl_trnOrderdetilJasa.Columns.Count - 1
                            columnName = tbl_trnOrderdetilJasa.Columns(col).ColumnName
                            If columnName <> "select" Then
                                row(columnName) = tbl_trnOrderdetilJasa.Rows(i).Item(columnName)
                            End If
                        Next
                        Me.tbl_TrnOrderdetilJasa_temps.Rows.Add(row)
                    End If
                Next
                retTblJasa = tbl_TrnOrderdetilJasa_temps
            Else
                ' ''For i = 0 To DgvListPO.RowCount - 1
                For i = 0 To tbl_trnOrderdetilJasa.Rows.Count - 1
                    If clsUtil.IsDbNull(Me.tbl_trnOrderdetilJasa.Rows(i).Item("select"), 0) = 1 Then
                        row = tbl_MstTrnOrder_temps.NewRow
                        For col = 0 To tbl_MstTrnOrderdetil.Columns.Count - 1
                            columnName = tbl_MstTrnOrderdetil.Columns(col).ColumnName
                            If columnName <> "select" Then
                                row(columnName) = tbl_MstTrnOrderdetil.Rows(i).Item(columnName)
                            End If
                        Next
                        Me.tbl_MstTrnOrder_temps.Rows.Add(row)
                    End If
                Next
                rettbl = tbl_MstTrnOrder_temps
            End If

            Me.CloseButtonIsPressed = True
        Else
            Me.CloseButtonIsPressed = False
        End If
            ' Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal order_id As String, _
                        ByVal list_id As String, ByVal isJasa As String)
        Me.dsn = strDSN
        Me.order_id = order_id
        Me.list_id = list_id
        Me.isJasa = isJasa

        InitializeComponent()
    End Sub

    Private Sub DgvListPO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvListPO.CellClick
        'Dim i As Integer

        'For i = 0 To Me.DgvListPO.Rows.Count - 1
        '    If i <> e.RowIndex Then
        '        Me.DgvListPO.Rows(i).Cells("select").Value = False
        '    End If
        'Next
    End Sub


End Class
