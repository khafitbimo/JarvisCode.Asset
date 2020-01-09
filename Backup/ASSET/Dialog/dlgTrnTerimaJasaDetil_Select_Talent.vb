

Public Class dlgTrnTerimaJasaDetil_Select_Talent

    Private mDSN As String
    Private mOrder As String
    Private retObj As Object
    Private order_line As String

    Private mChannel_id As String

    Private myOwner As System.Windows.Forms.IWin32Window

    Private tbl_TrnTerimaJasa_Talent As DataTable = CreateTblTrnTerimaJasa_List_TalentOrder()

    Private tbl_MstRekananGrid As DataTable = clsDataset.CreateTblMstrekananCombo



#Region " Properties "

    Public ReadOnly Property DSN() As String
        Get
            Return mDSN
        End Get
    End Property
#End Region

#Region " Constructor & Default Function"

    ' ''Public Sub New(ByVal dsn As String, ByVal rekanan_id As Decimal, _
    ' ''            ByVal tbl_MstRekananGrid As DataTable)
    ' ''    ' This call is required by the Windows Form Designer.
    ' ''    InitializeComponent()

    ' ''    ' Add any initialization after the InitializeComponent() call.
    ' ''    Me.mDSN = dsn
    ' ''    Me.rekanan_id = rekanan_id

    ' ''    Me.tbl_MstRekananGrid = tbl_MstRekananGrid.Copy

    ' ''End Sub

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

    Public Shared Function CreateTblTrnTerimaJasa_List_TalentOrder() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()

        tbl.Columns.Add(New DataColumn("order_check", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("to_outstanding", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("to_realisasi", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("item_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("category_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_utilizedtimestart", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_utilizedtimeend", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("type_pajak", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("kategori_pajak", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("persen", GetType(System.Int32)))
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
        tbl.Columns("to_outstanding").DefaultValue = 0
        tbl.Columns("to_realisasi").DefaultValue = 0
        tbl.Columns("item_name").DefaultValue = String.Empty
        tbl.Columns("category_id").DefaultValue = String.Empty
        tbl.Columns("order_utilizedtimestart").DefaultValue = String.Empty
        tbl.Columns("order_utilizedtimeend").DefaultValue = String.Empty
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_type").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("item_id").DefaultValue = String.Empty
        tbl.Columns("type_pajak").DefaultValue = 0
        tbl.Columns("kategori_pajak").DefaultValue = 0
        tbl.Columns("persen").DefaultValue = 0
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
        Dim cTo_outstanding As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cOrder_check.Name = "order_check"
        cOrder_check.HeaderText = "Pilih"
        cOrder_check.DataPropertyName = "order_check"
        cOrder_check.Width = 40
        cOrder_check.Visible = True
        cOrder_check.ReadOnly = False

        cTo_outstanding.Name = "to_outstanding"
        cTo_outstanding.HeaderText = "Qty Outstanding"
        cTo_outstanding.DataPropertyName = "to_outstanding"
        cTo_outstanding.Width = 120
        cTo_outstanding.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTo_outstanding.Visible = True
        cTo_outstanding.ReadOnly = True
        cTo_outstanding.DefaultCellStyle.Format = "#,##0"

        cItem_name.Name = "item_name"
        cItem_name.HeaderText = "Artis Name"
        cItem_name.DataPropertyName = "item_name"
        cItem_name.Width = 200
        cItem_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem_name.Visible = True
        cItem_name.ReadOnly = True

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 40
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = True

        cOrderdetil_descr.Name = "orderdetil_descr"
        cOrderdetil_descr.HeaderText = "Description"
        cOrderdetil_descr.DataPropertyName = "orderdetil_descr"
        cOrderdetil_descr.Width = 200
        cOrderdetil_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_descr.Visible = True
        cOrderdetil_descr.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOrder_check, cOrderdetil_line, cItem_name, cOrderdetil_descr, cTo_outstanding})
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


        Dim txtSearchCriteria As String = ""
        Dim txtSQLSearch As String = String.Empty

        ' ''txtSQLSearch = txtSQLSearch & " status <> 'COMPLETE' AND order_canceled = 0 "

        criteria = txtSQLSearch


        ''dbCmd = New OleDb.OleDbCommand("as_TrnTerimajasadetil_Select_Talent", dbConn)
        dbCmd = New OleDb.OleDbCommand("as_TrnTerimajasadetil_Select_Talent", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@Criteria").Value = criteria
        dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@order_id").Value = Me.mOrder


        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnTerimaJasa_Talent.Clear()

        Try
            dbConn.Open()
            dbDA.Fill(Me.tbl_TrnTerimaJasa_Talent)
            If Me.order_line <> String.Empty Then
                Me.tbl_TrnTerimaJasa_Talent.DefaultView.RowFilter = String.Format(" orderdetil_line not in {0}", Me.order_line)
            End If
            Me.DgvTalentOrder.DataSource = Me.tbl_TrnTerimaJasa_Talent
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgTrnJurnalSelect" & ": dlgTrnJurnalDetilSelect_LoadDetil()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
    End Function

#End Region


    Private Sub dlgTrnTerimaJasaDetil_Select_Talent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Cursor = Cursors.WaitCursor
        Me.FormatDgvTrnOrderdetil(Me.DgvTalentOrder)
        Me.DgvTalentOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dlgTrnJurnalDetilSelect_Load(Me.mChannel_id)
        Me.DgvTalentOrder.DataSource = Me.tbl_TrnTerimaJasa_Talent

        Me.Cursor = Cursors.Arrow

    End Sub

    '=============================Button================================================================================================================================================================

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim tblDetil As DataTable = CreateTblTrnTerimaJasa_List_TalentOrder()
        Dim row As DataRow
        Dim thisRetObj As Collection = New Collection

        Dim tbl_TrnTerimaJasa1 As DataTable = CreateTblTrnTerimaJasa_List_TalentOrder()
        Dim i, j As Integer
        Dim columnName As String

        tbl_TrnTerimaJasa1.Clear()
        tbl_TrnTerimaJasa1 = Me.tbl_TrnTerimaJasa_Talent.Copy()
        tbl_TrnTerimaJasa1.DefaultView.RowFilter = "order_check = 'True'"

        If Me.DgvTalentOrder.CurrentRow IsNot Nothing Then
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

        For i = 0 To Me.tbl_TrnTerimaJasa_Talent.Rows.Count - 1
            Me.tbl_TrnTerimaJasa_Talent.Rows(i).Item("order_check") = True
        Next
        Me.DgvTalentOrder.DataSource = Me.tbl_TrnTerimaJasa_Talent
    End Sub

    Private Sub LinkClear1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkClear1.LinkClicked
        Dim i As Integer

        For i = 0 To Me.tbl_TrnTerimaJasa_Talent.Rows.Count - 1
            Me.tbl_TrnTerimaJasa_Talent.Rows(i).Item("order_check") = False
        Next
        Me.DgvTalentOrder.DataSource = Me.tbl_TrnTerimaJasa_Talent
    End Sub

End Class
