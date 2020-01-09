Imports System.Windows.Forms

Public Class dlgRVSelect

    Private tbl_TrnPenerimaanbarangdetil As DataTable = clsDataset.CreateTblViewTrnTerimabarangDetil()
    Private Event AfterRetrieve()
    Private dsn As String
    Private channel_id As String

#Region " Constructor "
    Sub New(ByVal dsn As String, ByVal channel_id As String)
        Me.InitializeComponent()
        Me.FormatDgvTrnPenerimaanbarangdetil(DgvTrnPenerimaanbarangdetil)
        Me.dsn = dsn
        Me.channel_id = channel_id
    End Sub
#End Region

    Private Function FormatDgvTrnPenerimaanbarangdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnPenerimaanbarangdetil
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_desc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_serial_no As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_product_no As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudgetdetil_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "Line"
        cTerimabarang_id.HeaderText = "ID"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 100
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = False
        cTerimabarang_id.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimabarangdetil_line.Name = "terimabarangdetil_line"
        cTerimabarangdetil_line.HeaderText = "Line"
        cTerimabarangdetil_line.DataPropertyName = "terimabarangdetil_line"
        cTerimabarangdetil_line.Width = 40
        cTerimabarangdetil_line.Visible = True
        cTerimabarangdetil_line.ReadOnly = True
        cTerimabarangdetil_line.DefaultCellStyle.BackColor = Color.Gainsboro

       
        cTerimabarangdetil_desc.Name = "terimabarangdetil_desc"
        cTerimabarangdetil_desc.HeaderText = "Description"
        cTerimabarangdetil_desc.DataPropertyName = "terimabarangdetil_desc"
        cTerimabarangdetil_desc.Width = 150
        cTerimabarangdetil_desc.Visible = True
        cTerimabarangdetil_desc.ReadOnly = False

        cTerimabarang_barcode.Name = "terimabarang_barcode"
        cTerimabarang_barcode.HeaderText = "Barcode"
        cTerimabarang_barcode.DataPropertyName = "terimabarang_barcode"
        cTerimabarang_barcode.Width = 100
        cTerimabarang_barcode.Visible = True
        cTerimabarang_barcode.ReadOnly = True

        
        cTerimabarangdetil_serial_no.Name = "terimabarangdetil_serial_no"
        cTerimabarangdetil_serial_no.HeaderText = "Serial No."
        cTerimabarangdetil_serial_no.DataPropertyName = "terimabarangdetil_serial_no"
        cTerimabarangdetil_serial_no.Width = 100
        cTerimabarangdetil_serial_no.Visible = True
        cTerimabarangdetil_serial_no.ReadOnly = False

        cTerimabarangdetil_product_no.Name = "terimabarangdetil_product_no"
        cTerimabarangdetil_product_no.HeaderText = "Barcode Type"
        cTerimabarangdetil_product_no.DataPropertyName = "terimabarangdetil_product_no"
        cTerimabarangdetil_product_no.Width = 100
        cTerimabarangdetil_product_no.Visible = True
        cTerimabarangdetil_product_no.ReadOnly = True

       
        cTerimabarangdetil_qty.Name = "terimabarangdetil_qty"
        cTerimabarangdetil_qty.HeaderText = "Qty"
        cTerimabarangdetil_qty.DataPropertyName = "terimabarangdetil_qty"
        cTerimabarangdetil_qty.Width = 80
        cTerimabarangdetil_qty.Visible = True
        cTerimabarangdetil_qty.ReadOnly = True
        cTerimabarangdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


    
        cEmployee_id.Name = "employee_id"
        cEmployee_id.HeaderText = "employee_id"
        cEmployee_id.DataPropertyName = "employee_id"
        cEmployee_id.Width = 100
        cEmployee_id.Visible = False
        cEmployee_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cTerimabarangdetil_eps.Name = "terimabarangdetil_eps"
        cTerimabarangdetil_eps.HeaderText = "Eps"
        cTerimabarangdetil_eps.DataPropertyName = "terimabarangdetil_eps"
        cTerimabarangdetil_eps.Width = 50
        cTerimabarangdetil_eps.Visible = True
        cTerimabarangdetil_eps.ReadOnly = False

        cWriteoff_id.Name = "writeoff_id"
        cWriteoff_id.HeaderText = "Writeoff ID"
        cWriteoff_id.DataPropertyName = "writeoff_id"
        cWriteoff_id.Width = 100
        cWriteoff_id.Visible = False
        cWriteoff_id.ReadOnly = True

        cWriteoff_dt.Name = "writeoff_dt"
        cWriteoff_dt.HeaderText = "Writeoff Date"
        cWriteoff_dt.DataPropertyName = "writeoff_dt"
        cWriteoff_dt.Width = 100
        cWriteoff_dt.Visible = False
        cWriteoff_dt.ReadOnly = True

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order_id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = False

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "orderdetil_line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.Visible = False
        cOrderdetil_line.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "budget_id"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = False

        cBudgetdetil_id.Name = "budgetdetil_id"
        cBudgetdetil_id.HeaderText = "budgetdetil_id"
        cBudgetdetil_id.DataPropertyName = "budgetdetil_id"
        cBudgetdetil_id.Width = 100
        cBudgetdetil_id.Visible = False
        cBudgetdetil_id.ReadOnly = False

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "acc_id"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 100
        cAcc_id.Visible = False
        cAcc_id.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cCreate_by.Name = "create_by"
        cCreate_by.HeaderText = "create_by"
        cCreate_by.DataPropertyName = "create_by"
        cCreate_by.Width = 100
        cCreate_by.Visible = False
        cCreate_by.ReadOnly = False

        cCreate_dt.Name = "create_dt"
        cCreate_dt.HeaderText = "create_dt"
        cCreate_dt.DataPropertyName = "create_dt"
        cCreate_dt.Width = 100
        cCreate_dt.Visible = False
        cCreate_dt.ReadOnly = False

        cModified_by.Name = "modified_by"
        cModified_by.HeaderText = "modified_by"
        cModified_by.DataPropertyName = "modified_by"
        cModified_by.Width = 100
        cModified_by.Visible = False
        cModified_by.ReadOnly = False

        cModified_dt.Name = "modified_dt"
        cModified_dt.HeaderText = "modified_dt"
        cModified_dt.DataPropertyName = "modified_dt"
        cModified_dt.Width = 100
        cModified_dt.Visible = False
        cModified_dt.ReadOnly = False


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimabarang_id, cTerimabarangdetil_line, cTerimabarang_barcode, cTerimabarangdetil_desc, _
         cTerimabarangdetil_serial_no, cTerimabarangdetil_product_no,
        cTerimabarangdetil_eps, cTerimabarangdetil_qty, cEmployee_id, cStrukturunit_id, _
        cWriteoff_id, cWriteoff_dt, cOrder_id, _
        cOrderdetil_line, cBudget_id, cBudgetdetil_id, cAcc_id, cChannel_id, cCreate_by, cCreate_dt, _
        cModified_by, cModified_dt})

        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = True
        objDgv.AutoGenerateColumns = False
        objDgv.MultiSelect = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

    Private Sub DlgAssetCategorySelect_Load(sender As Object, e As EventArgs) Handles Me.Load, Button1.Click
        dlgRetrieve()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DgvAssetConsumable_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTrnPenerimaanbarangdetil.CellDoubleClick
        If e.ColumnIndex > -1 And e.RowIndex > -1 Then
            Me.btnOK.PerformClick()
        End If
    End Sub

    Private Sub obj_srcItem_TextChanged(sender As Object, e As EventArgs) Handles obj_srcItem.TextChanged
        Me.tbl_TrnPenerimaanbarangdetil.DefaultView.RowFilter = String.Format("terimabarang_id LIKE '%{0}%'", Me.obj_srcItem.Text)

    End Sub

    Private Function dlgRetrieve() As Boolean
        Dim filler As New clsDataFiller(Me.dsn)
        Dim criteria As String = String.Format("b.terimabarang_appuser = 0 AND b.terimabarang_appspv = 0 AND b.terimabarang_appacc = 0 and b.channel_id = '{0}'", Me.channel_id)
        filler.DataFill(Me.tbl_TrnPenerimaanbarangdetil, "as_PenerimaanBarangSelectRV", criteria)
        Me.DgvTrnPenerimaanbarangdetil.AutoGenerateColumns = False
        Me.DgvTrnPenerimaanbarangdetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil
        If Me.tbl_TrnPenerimaanbarangdetil.Rows.Count > 0 Then
            Me.btnOK.Enabled = True
        Else
            Me.btnOK.Enabled = False
        End If
    End Function
End Class
