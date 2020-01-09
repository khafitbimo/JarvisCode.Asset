Imports System.Windows.Forms

Public Class dlgRVSelectListRV
    Private tbl_TrnPenerimaanbarangdetil As DataTable = clsDataset.CreateTblViewTrnTerimabarangDetil()
    Private Event AfterRetrieve()
    Private dsn As String
    Private channel_id As String
    Private isParent As Boolean

#Region " Constructor "
    Sub New(ByVal dsn As String, ByVal channel_id As String, ByVal isParent As Boolean)
        Me.InitializeComponent()
        Me.FormatDgvTrnPenerimaanbarangdetil(DgvMstAssetAccounting)
        Me.dsn = dsn
        Me.channel_id = channel_id
        Me.isParent = isParent
    End Sub
#End Region

    Private Function FormatDgvTrnPenerimaanbarangdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnPenerimaanbarangdetil
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_desc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTipeAssetID As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_serial_no As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_product_no As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarangdetil_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cModified_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "ID"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 100
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = False
        cTerimabarang_id.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimabarangdetil_line.Name = "asset_line"
        cTerimabarangdetil_line.HeaderText = "Line"
        cTerimabarangdetil_line.DataPropertyName = "asset_line"
        cTerimabarangdetil_line.Width = 40
        cTerimabarangdetil_line.Visible = True
        cTerimabarangdetil_line.ReadOnly = True
        cTerimabarangdetil_line.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimabarangdetil_desc.Name = "asset_deskripsi"
        cTerimabarangdetil_desc.HeaderText = "Description"
        cTerimabarangdetil_desc.DataPropertyName = "asset_deskripsi"
        cTerimabarangdetil_desc.Width = 150
        cTerimabarangdetil_desc.Visible = True
        cTerimabarangdetil_desc.ReadOnly = False

        cTerimabarang_barcode.Name = "asset_barcode"
        cTerimabarang_barcode.HeaderText = "Barcode"
        cTerimabarang_barcode.DataPropertyName = "asset_barcode"
        cTerimabarang_barcode.Width = 100
        cTerimabarang_barcode.Visible = True
        cTerimabarang_barcode.ReadOnly = True

        cTipeAssetID.Name = "tipeasset_id"
        cTipeAssetID.HeaderText = "Type Asset"
        cTipeAssetID.DataPropertyName = "tipeasset_id"
        cTipeAssetID.Width = 100
        cTipeAssetID.Visible = True
        cTipeAssetID.ReadOnly = True

        cTerimabarangdetil_serial_no.Name = "asset_serial"
        cTerimabarangdetil_serial_no.HeaderText = "Serial No."
        cTerimabarangdetil_serial_no.DataPropertyName = "asset_serial"
        cTerimabarangdetil_serial_no.Width = 100
        cTerimabarangdetil_serial_no.Visible = True
        cTerimabarangdetil_serial_no.ReadOnly = False

        cTerimabarangdetil_product_no.Name = "asset_produknumber"
        cTerimabarangdetil_product_no.HeaderText = "Barcode Type"
        cTerimabarangdetil_product_no.DataPropertyName = "asset_produknumber"
        cTerimabarangdetil_product_no.Width = 100
        cTerimabarangdetil_product_no.Visible = True
        cTerimabarangdetil_product_no.ReadOnly = True

        cTerimabarangdetil_qty.Name = "asset_qty"
        cTerimabarangdetil_qty.HeaderText = "Qty"
        cTerimabarangdetil_qty.DataPropertyName = "asset_qty"
        cTerimabarangdetil_qty.Width = 80
        cTerimabarangdetil_qty.Visible = True
        cTerimabarangdetil_qty.ReadOnly = True
        cTerimabarangdetil_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        cEmployee_id.Name = "employee_id_owner"
        cEmployee_id.HeaderText = "Employee ID"
        cEmployee_id.DataPropertyName = "employee_id_owner"
        cEmployee_id.Width = 100
        cEmployee_id.Visible = False
        cEmployee_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Strukturunit ID"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cTerimabarangdetil_eps.Name = "asset_eps"
        cTerimabarangdetil_eps.HeaderText = "Eps"
        cTerimabarangdetil_eps.DataPropertyName = "asset_eps"
        cTerimabarangdetil_eps.Width = 50
        cTerimabarangdetil_eps.Visible = True
        cTerimabarangdetil_eps.ReadOnly = False

        cWriteoff_id.Name = "wo_id"
        cWriteoff_id.HeaderText = "Writeoff ID"
        cWriteoff_id.DataPropertyName = "wo_id"
        cWriteoff_id.Width = 100
        cWriteoff_id.Visible = False
        cWriteoff_id.ReadOnly = True

        cWriteoff_dt.Name = "wo_date"
        cWriteoff_dt.HeaderText = "Writeoff Date"
        cWriteoff_dt.DataPropertyName = "wo_date"
        cWriteoff_dt.Width = 100
        cWriteoff_dt.Visible = False
        cWriteoff_dt.ReadOnly = True

        cBudget_id.Name = "project_id"
        cBudget_id.HeaderText = "Budget ID"
        cBudget_id.DataPropertyName = "project_id"
        cBudget_id.Width = 100
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cCreate_by.Name = "inputby"
        cCreate_by.HeaderText = "create_by"
        cCreate_by.DataPropertyName = "inputby"
        cCreate_by.Width = 100
        cCreate_by.Visible = False
        cCreate_by.ReadOnly = False

        cCreate_dt.Name = "inputdt"
        cCreate_dt.HeaderText = "create_dt"
        cCreate_dt.DataPropertyName = "inputdt"
        cCreate_dt.Width = 100
        cCreate_dt.Visible = False
        cCreate_dt.ReadOnly = False

        cModified_by.Name = "editby"
        cModified_by.HeaderText = "modified_by"
        cModified_by.DataPropertyName = "editby"
        cModified_by.Width = 100
        cModified_by.Visible = False
        cModified_by.ReadOnly = False

        cModified_dt.Name = "editdt"
        cModified_dt.HeaderText = "modified_dt"
        cModified_dt.DataPropertyName = "editdt"
        cModified_dt.Width = 100
        cModified_dt.Visible = False
        cModified_dt.ReadOnly = False


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimabarang_id, cTerimabarangdetil_line, cTerimabarang_barcode, cTipeAssetID, cTerimabarangdetil_desc, _
         cTerimabarangdetil_serial_no, cTerimabarangdetil_product_no,
        cTerimabarangdetil_eps, cTerimabarangdetil_qty, cEmployee_id, cStrukturunit_id, _
        cWriteoff_id, cWriteoff_dt, cBudget_id, cChannel_id, cCreate_by, cCreate_dt, _
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

    Private Sub DgvAssetConsumable_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMstAssetAccounting.CellDoubleClick
        If e.ColumnIndex > -1 And e.RowIndex > -1 Then
            Me.btnOK.PerformClick()
        End If
    End Sub

    Private Sub obj_srcItem_TextChanged(sender As Object, e As EventArgs) Handles obj_srcItem.TextChanged
        Me.tbl_TrnPenerimaanbarangdetil.DefaultView.RowFilter = String.Format("terimabarang_id LIKE '%{0}%'", Me.obj_srcItem.Text)
    End Sub

    Private Function dlgRetrieve() As Boolean
        Dim filler As New clsDataFiller(Me.dsn)
        'Dim criteria As String = String.Format(" AND channel_id = '{0}'", Me.channel_id)
        Dim criteria As String = String.Empty

        If Me.isParent = True Then
            criteria = String.Format(" AND channel_id = '{0}'", Me.channel_id)
        Else
            criteria = String.Format("C.terimabarang_id IN (SELECT terimabarang_id FROM transaksi_penerimaanbarang WHERE channel_id = '{0}' " + _
                                        "AND terimabarang_type = 'LISTRV' AND terimabarang_isdisabled = 0) AND (ref_id is null OR ref_id = '')", Me.channel_id)
        End If


        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand("as_PenerimaanBarangSelectRVListRV", dbConn)

        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria
        dbCmd.Parameters.Add("@is_parent", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@is_parent").Value = IIf(Me.isParent = True, 1, 0)


        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Fill(Me.tbl_TrnPenerimaanbarangdetil)

            ' filler.DataFill(Me.tbl_TrnPenerimaanbarangdetil, "as_PenerimaanBarangSelectRVListRV", criteria)

            Me.DgvMstAssetAccounting.AutoGenerateColumns = False
            Me.DgvMstAssetAccounting.DataSource = Me.tbl_TrnPenerimaanbarangdetil
            If Me.tbl_TrnPenerimaanbarangdetil.Rows.Count > 0 Then
                Me.btnOK.Enabled = True
            Else
                Me.btnOK.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

    End Function
End Class
