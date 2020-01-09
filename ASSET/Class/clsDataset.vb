
Public Class clsDataset
    Private Shared m_channel As String

    Public Shared Function CreateTblFromUDTableTypes(ByVal DSN As String, ByVal table_name As String) As DataTable
        Try
            Dim objTbl As DataTable = DatabaseUtils.CreateTbl(Of view_structure_tabletype)()
            Dim db As New DataClassesFRMDataContext(DSN)
            Dim queryStructure As IQueryable(Of view_structure_tabletype)

            db.OpenConnectionWithRole()

            queryStructure = db.view_structure_tabletypes.Where(Function(p) p.table_name = table_name)
            DatabaseUtils.DataFill(objTbl, queryStructure)
            db.CloseConnectionWithRole()

            Dim newTable As DataTable = New DataTable

            newTable.Columns.Clear()

            For Each dtRow As DataRow In objTbl.Rows
                If dtRow.Item("type_data").ToString = "bigint" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Int64)))
                ElseIf dtRow.Item("type_data").ToString = "binary" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Byte)))
                ElseIf dtRow.Item("type_data").ToString = "bit" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Boolean)))
                ElseIf dtRow.Item("type_data").ToString = "date" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Date)))
                ElseIf dtRow.Item("type_data").ToString = "bit" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Boolean)))
                ElseIf dtRow.Item("type_data").ToString = "decimal" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Decimal)))
                ElseIf dtRow.Item("type_data").ToString = "float" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Double)))
                ElseIf dtRow.Item("type_data").ToString = "int" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Int32)))
                ElseIf dtRow.Item("type_data").ToString = "money" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Decimal)))
                ElseIf dtRow.Item("type_data").ToString = "nchar" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(String)))
                ElseIf dtRow.Item("type_data").ToString = "ntext" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(String)))
                ElseIf dtRow.Item("type_data").ToString = "numeric" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Decimal)))
                ElseIf dtRow.Item("type_data").ToString = "nvarchar" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(String)))
                ElseIf dtRow.Item("type_data").ToString = "smalldatetime" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(DateTime)))
                ElseIf dtRow.Item("type_data").ToString = "datetime" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(DateTime)))
                ElseIf dtRow.Item("type_data").ToString = "smallint" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Int16)))
                ElseIf dtRow.Item("type_data").ToString = "text" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(String)))
                ElseIf dtRow.Item("type_data").ToString = "timestamp" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Byte)))
                ElseIf dtRow.Item("type_data").ToString = "tinyint" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Byte)))
                ElseIf dtRow.Item("type_data").ToString = "real" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Single)))
                ElseIf dtRow.Item("type_data").ToString = "smallmoney" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Decimal)))
                ElseIf dtRow.Item("type_data").ToString = "time" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(TimeSpan)))
                ElseIf dtRow.Item("type_data").ToString = "varbinary" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Byte())))
                ElseIf dtRow.Item("type_data").ToString = "varchar" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(String)))
                ElseIf dtRow.Item("type_data").ToString = "uniqueidentifier" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Guid)))
                ElseIf dtRow.Item("type_data").ToString = "sql_variant" Then
                    newTable.Columns.Add(New DataColumn(dtRow.Item("column_name").ToString, GetType(Object)))
                End If
            Next

            Return newTable
        Catch ex As Exception
            Throw ex
        End Try
        '-------------------------------
        'Default Value: 
        'tbl.Columns("warn_id").DefaultValue = ""
        'tbl.Columns("warnemailscheduled_line").DefaultValue = 0
        'tbl.Columns("warn_date").DefaultValue = DBNull.Value
    End Function

    Public Shared Function CreateTblTrnPenerimaanbarang() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimabarang_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_owner", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_qtyitem", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_qtyrealization", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_statusrealization", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_location", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_notes", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_nosuratjalan", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_tglsuratjalan", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("terimabarang_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_createdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimabarang_modifiedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_modifieddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimabarang_appuser", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("terimabarang_appuser_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_appuser_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimabarang_appspv", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("terimabarang_appspv_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_appspv_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimabarang_appacc", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("terimabarang_appacc_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_appacc_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimabarang_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_ppn", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_cetakbpb", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(String)))
        tbl.Columns.Add(New DataColumn("employee_name", GetType(String)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("terimabarang_id").DefaultValue = ""
        tbl.Columns("terimabarang_date").DefaultValue = Now()
        tbl.Columns("terimabarang_type").DefaultValue = ""
        tbl.Columns("order_id").DefaultValue = ""
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("employee_id_owner").DefaultValue = DBNull.Value
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("terimabarang_qtyitem").DefaultValue = 0
        tbl.Columns("terimabarang_qtyrealization").DefaultValue = 0
        tbl.Columns("order_qty").DefaultValue = 0
        tbl.Columns("terimabarang_status").DefaultValue = ""
        tbl.Columns("terimabarang_statusrealization").DefaultValue = ""
        tbl.Columns("terimabarang_location").DefaultValue = ""
        tbl.Columns("terimabarang_notes").DefaultValue = ""
        tbl.Columns("terimabarang_nosuratjalan").DefaultValue = ""
        tbl.Columns("terimabarang_tglsuratjalan").DefaultValue = DBNull.Value 'Now
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("terimabarang_isdisabled").DefaultValue = 0
        tbl.Columns("terimabarang_createby").DefaultValue = ""
        tbl.Columns("terimabarang_createdt").DefaultValue = DBNull.Value 'Now()
        tbl.Columns("terimabarang_modifiedby").DefaultValue = ""
        tbl.Columns("terimabarang_modifieddt").DefaultValue = DBNull.Value 'Now()
        tbl.Columns("terimabarang_appuser").DefaultValue = 0
        tbl.Columns("terimabarang_appuser_by").DefaultValue = ""
        tbl.Columns("terimabarang_appuser_dt").DefaultValue = DBNull.Value 'Now()
        tbl.Columns("terimabarang_appspv").DefaultValue = 0
        tbl.Columns("terimabarang_appspv_by").DefaultValue = ""
        tbl.Columns("terimabarang_appspv_dt").DefaultValue = DBNull.Value 'Now()
        tbl.Columns("terimabarang_appacc").DefaultValue = 0
        tbl.Columns("terimabarang_appacc_by").DefaultValue = ""
        tbl.Columns("terimabarang_appacc_dt").DefaultValue = DBNull.Value 'Now()
        tbl.Columns("terimabarang_foreign").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("terimabarang_foreignrate").DefaultValue = 0
        tbl.Columns("terimabarang_idrreal").DefaultValue = 0
        tbl.Columns("terimabarang_pph").DefaultValue = 0
        tbl.Columns("terimabarang_ppn").DefaultValue = 0
        tbl.Columns("terimabarang_disc").DefaultValue = 0
        tbl.Columns("terimabarang_cetakbpb").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblTrnPenerimaanbarangdetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_parentline", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_desc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("assetcategory_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("assettype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_parentbarcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("itemcategory_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("itemtype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_serial_no", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_product_no", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_model", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("material_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("colour_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("size_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("sex_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("room_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_rack", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_qtydetail", GetType(Int32)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_qtytotal", GetType(Int32)))
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_pphpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_ppnpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_pphforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_pphidrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_ppnforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_ppnidrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_totalforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_totalidrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_nonfixasset", GetType(System.Boolean)))

        tbl.Columns.Add(New DataColumn("terimabarangdetil_golfiskal", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("terimabarangdetil_depre_enddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("employee_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_id_cont", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarangdetil_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("writeoff_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("writeoff_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("create_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("create_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modified_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modified_dt", GetType(System.DateTime)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("terimabarang_id").DefaultValue = ""
        tbl.Columns("terimabarangdetil_line").DefaultValue = 0
        tbl.Columns("terimabarangdetil_parentline").DefaultValue = 0
        tbl.Columns("terimabarangdetil_desc").DefaultValue = ""
        tbl.Columns("terimabarangdetil_date").DefaultValue = DBNull.Value
        tbl.Columns("terimabarangdetil_type").DefaultValue = ""
        tbl.Columns("assetcategory_id").DefaultValue = "-- PILIH --"
        tbl.Columns("assettype_id").DefaultValue = "-- PILIH --"
        tbl.Columns("terimabarang_barcode").DefaultValue = ""
        tbl.Columns("terimabarang_parentbarcode").DefaultValue = ""
        tbl.Columns("item_id").DefaultValue = ""
        tbl.Columns("itemcategory_id").DefaultValue = ""
        tbl.Columns("itemtype_id").DefaultValue = "-- PILIH --"
        tbl.Columns("brand_id").DefaultValue = 0
        tbl.Columns("terimabarangdetil_serial_no").DefaultValue = ""
        tbl.Columns("terimabarangdetil_product_no").DefaultValue = ""
        tbl.Columns("terimabarangdetil_model").DefaultValue = ""
        tbl.Columns("material_id").DefaultValue = "-- PILIH --"
        tbl.Columns("colour_id").DefaultValue = "-- PILIH --"
        tbl.Columns("size_id").DefaultValue = "-- PILIH --"
        tbl.Columns("sex_id").DefaultValue = "-- PILIH --"
        tbl.Columns("room_id").DefaultValue = ""
        tbl.Columns("terimabarangdetil_rack").DefaultValue = ""
        tbl.Columns("terimabarangdetil_qty").DefaultValue = 1
        tbl.Columns("terimabarangdetil_qtydetail").DefaultValue = 1
        tbl.Columns("terimabarangdetil_qtytotal").DefaultValue = 1
        tbl.Columns("unit_id").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("terimabarangdetil_foreign").DefaultValue = 0
        tbl.Columns("terimabarangdetil_foreignrate").DefaultValue = 0
        tbl.Columns("terimabarangdetil_idrreal").DefaultValue = 0
        tbl.Columns("terimabarangdetil_pphpercent").DefaultValue = 0
        tbl.Columns("terimabarangdetil_ppnpercent").DefaultValue = 0
        tbl.Columns("terimabarangdetil_disc").DefaultValue = 0
        tbl.Columns("terimabarangdetil_pphforeign").DefaultValue = 0
        tbl.Columns("terimabarangdetil_pphidrreal").DefaultValue = 0
        tbl.Columns("terimabarangdetil_ppnforeign").DefaultValue = 0
        tbl.Columns("terimabarangdetil_ppnidrreal").DefaultValue = 0
        tbl.Columns("terimabarangdetil_totalforeign").DefaultValue = 0
        tbl.Columns("terimabarangdetil_totalidrreal").DefaultValue = 0
        tbl.Columns("terimabarangdetil_nonfixasset").DefaultValue = False
        tbl.Columns("terimabarangdetil_golfiskal").DefaultValue = "0"
        tbl.Columns("terimabarangdetil_depre_enddt").DefaultValue = Now.Date
        tbl.Columns("employee_id").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("show_id").DefaultValue = ""
        tbl.Columns("show_id_cont").DefaultValue = ""
        tbl.Columns("terimabarangdetil_eps").DefaultValue = ""
        tbl.Columns("writeoff_id").DefaultValue = ""
        tbl.Columns("writeoff_dt").DefaultValue = DBNull.Value
        tbl.Columns("order_id").DefaultValue = ""
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("acc_id").DefaultValue = ""
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("create_by").DefaultValue = ""
        tbl.Columns("create_dt").DefaultValue = Now()
        tbl.Columns("modified_by").DefaultValue = ""
        tbl.Columns("modified_dt").DefaultValue = Now()

        Return tbl
    End Function

    Public Shared Function CreateTblViewTrnTerimabarangDetil() As DataTable
        Dim tbl As DataTable = clsDataset.CreateTblTrnPenerimaanbarangdetil()

        tbl.Columns.Add("budget_name", GetType(String)).DefaultValue = ""
        tbl.Columns.Add("budgetdetil_name", GetType(String)).DefaultValue = ""

        Return tbl
    End Function

    Public Shared Function CreateTblTrnTerimabarang() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_tgl", GetType(System.Datetime)))
        tbl.Columns.Add(New DataColumn("terimabarang_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("pa_ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_appacc", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("employee_id_pemilik", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id_pemilik", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("accounting_applogin", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("accounting_appdt", GetType(System.Datetime)))
        tbl.Columns.Add(New DataColumn("terimabarang_appprc", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("procurement_applogin", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("procurement_appdt", GetType(System.Datetime)))
        tbl.Columns.Add(New DataColumn("terimabarang_cetakbpb", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("terimabarang_cetakbkb", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("terimabarang_item", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("inputby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inputdt", GetType(System.Datetime)))
        tbl.Columns.Add(New DataColumn("editby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("editdt", GetType(System.Datetime)))
        tbl.Columns.Add(New DataColumn("usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("useddt", GetType(System.Datetime)))
        tbl.Columns.Add(New DataColumn("channel_id_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id_pemilik_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_appuser", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("user_applogin", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("user_appdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("qty_mother", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("qty_po", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_harga", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_hargabaru", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_ppn", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_idrprice", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_insurancecost", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_transportationcost", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_operatorcost", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_othercost", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_appbma", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("bma_applogin", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bma_appdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimabarang_jurnal", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("jurnal_login", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimabarang_posting", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("posting_login", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("posting_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("location", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("notes", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("status_kedatangan", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("no_surat_jalan", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("terimabarang_id").DefaultValue = ""
        tbl.Columns("terimabarang_tgl").DefaultValue = now()
        tbl.Columns("terimabarang_status").DefaultValue = ""
        tbl.Columns("order_id").DefaultValue = ""
        tbl.Columns("pa_ref").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("terimabarang_appacc").DefaultValue = 0
        tbl.Columns("employee_id_pemilik").DefaultValue = DBNull.Value
        tbl.Columns("strukturunit_id_pemilik").DefaultValue = 0
        tbl.Columns("accounting_applogin").DefaultValue = ""
        tbl.Columns("accounting_appdt").DefaultValue = now()
        tbl.Columns("terimabarang_appprc").DefaultValue = 0
        tbl.Columns("procurement_applogin").DefaultValue = ""
        tbl.Columns("procurement_appdt").DefaultValue = now()
        tbl.Columns("terimabarang_cetakbpb").DefaultValue = 0
        tbl.Columns("terimabarang_cetakbkb").DefaultValue = 0
        tbl.Columns("terimabarang_item").DefaultValue = 0
        tbl.Columns("inputby").DefaultValue = ""
        tbl.Columns("inputdt").DefaultValue = now()
        tbl.Columns("editby").DefaultValue = ""
        tbl.Columns("editdt").DefaultValue = now()
        tbl.Columns("usedby").DefaultValue = ""
        tbl.Columns("useddt").DefaultValue = now()
        tbl.Columns("channel_id_string").DefaultValue = ""
        tbl.Columns("rekanan_id_string").DefaultValue = ""
        tbl.Columns("strukturunit_id_pemilik_string").DefaultValue = ""
        tbl.Columns("terimabarang_appuser").DefaultValue = 0
        tbl.Columns("user_applogin").DefaultValue = ""
        tbl.Columns("user_appdt").DefaultValue = Now()
        tbl.Columns("qty_mother").DefaultValue = 0
        tbl.Columns("status").DefaultValue = String.Empty
        tbl.Columns("qty_po").DefaultValue = 0
        tbl.Columns("type").DefaultValue = String.Empty
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("asset_harga").DefaultValue = 0
        tbl.Columns("asset_hargabaru").DefaultValue = 0
        tbl.Columns("asset_ppn").DefaultValue = 0
        tbl.Columns("asset_pph").DefaultValue = 0
        tbl.Columns("asset_disc").DefaultValue = 0
        tbl.Columns("asset_valas").DefaultValue = 0
        tbl.Columns("asset_idrprice").DefaultValue = 0
        tbl.Columns("order_insurancecost").DefaultValue = 0
        tbl.Columns("order_transportationcost").DefaultValue = 0
        tbl.Columns("order_operatorcost").DefaultValue = 0
        tbl.Columns("order_othercost").DefaultValue = 0
        tbl.Columns("terimabarang_appbma").DefaultValue = 0
        tbl.Columns("bma_applogin").DefaultValue = String.Empty
        tbl.Columns("bma_appdt").DefaultValue = Now()
        tbl.Columns("terimabarang_jurnal").DefaultValue = 0
        tbl.Columns("jurnal_login").DefaultValue = String.Empty
        tbl.Columns("jurnal_dt").DefaultValue = Now()
        tbl.Columns("terimabarang_posting").DefaultValue = 0
        tbl.Columns("posting_login").DefaultValue = String.Empty
        tbl.Columns("posting_dt").DefaultValue = Now()
        tbl.Columns("location").DefaultValue = "GEDUNG TRANSTV - TENDEAN JAKARTA"
        tbl.Columns("notes").DefaultValue = String.Empty
        tbl.Columns("status_kedatangan").DefaultValue = "-- Pilih --"
        tbl.Columns("no_surat_jalan").DefaultValue = String.Empty

        tbl.Columns("budget_id").DefaultValue = String.Empty
        tbl.Columns("budget_name").DefaultValue = String.Empty


        Return tbl
    End Function
    Public Shared Function CreateTblMstSkill() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("code", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("note", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("entry_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("entry_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modified_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modified_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("active", GetType(System.Byte)))

        tbl.Columns("code").DefaultValue = String.Empty
        tbl.Columns("name").DefaultValue = String.Empty
        tbl.Columns("note").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("entry_by").DefaultValue = String.Empty
        tbl.Columns("entry_date").DefaultValue = Now()
        tbl.Columns("modified_by").DefaultValue = String.Empty
        tbl.Columns("modified_date").DefaultValue = Now()
        tbl.Columns("active").DefaultValue = 0

        Return tbl
    End Function






    Public Shared Function CreateTblTrnTerimabarangdetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_tgl", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("tipeasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_lineinduk", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_barcodeinduk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_serial", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_produknumber", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_model", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_deskripsi", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tipeitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_golfiskal", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_tipedepre", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_depre_enddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_harga", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_hargabaru", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_ppn", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_depresiasi", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_akum_val_depre", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_idrprice", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_owner", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_qty", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("material_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("warna_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ukuran_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jeniskelamin_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_id_cont_item", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ruang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_rak", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("is_useable", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_active", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("project_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("wo_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inputby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inputdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("editby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("editdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("jurnal", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("jurnal_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_dt", GetType(System.DateTime)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("terimabarang_id").DefaultValue = ""
        tbl.Columns("asset_line").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = DBNull.Value
        tbl.Columns("asset_tgl").DefaultValue = Now()
        tbl.Columns("tipeasset_id").DefaultValue = DBNull.Value
        tbl.Columns("kategoriasset_id").DefaultValue = DBNull.Value
        tbl.Columns("asset_barcode").DefaultValue = ""
        tbl.Columns("asset_lineinduk").DefaultValue = 0
        tbl.Columns("asset_barcodeinduk").DefaultValue = ""
        tbl.Columns("asset_serial").DefaultValue = ""
        tbl.Columns("asset_produknumber").DefaultValue = ""
        tbl.Columns("asset_model").DefaultValue = ""
        tbl.Columns("asset_deskripsi").DefaultValue = ""
        tbl.Columns("kategoriitem_id").DefaultValue = DBNull.Value
        tbl.Columns("tipeitem_id").DefaultValue = DBNull.Value
        tbl.Columns("asset_golfiskal").DefaultValue = ""
        tbl.Columns("asset_tipedepre").DefaultValue = "N"
        tbl.Columns("asset_depre_enddt").DefaultValue = Now()
        tbl.Columns("currency_id").DefaultValue = 1
        tbl.Columns("asset_harga").DefaultValue = 0
        tbl.Columns("asset_hargabaru").DefaultValue = 0
        tbl.Columns("asset_ppn").DefaultValue = 0
        tbl.Columns("asset_pph").DefaultValue = 0
        tbl.Columns("asset_disc").DefaultValue = 0
        tbl.Columns("asset_depresiasi").DefaultValue = 0
        tbl.Columns("asset_akum_val_depre").DefaultValue = 0
        tbl.Columns("asset_valas").DefaultValue = 1
        tbl.Columns("asset_idrprice").DefaultValue = 0
        tbl.Columns("strukturunit_id").DefaultValue = DBNull.Value
        tbl.Columns("employee_id_owner").DefaultValue = DBNull.Value
        tbl.Columns("brand_id").DefaultValue = DBNull.Value
        tbl.Columns("unit_id").DefaultValue = 11
        tbl.Columns("asset_qty").DefaultValue = 1
        tbl.Columns("material_id").DefaultValue = DBNull.Value
        tbl.Columns("warna_id").DefaultValue = 0
        tbl.Columns("ukuran_id").DefaultValue = DBNull.Value
        tbl.Columns("jeniskelamin_id").DefaultValue = DBNull.Value
        tbl.Columns("show_id_cont_item").DefaultValue = DBNull.Value
        tbl.Columns("ruang_id").DefaultValue = DBNull.Value
        tbl.Columns("asset_rak").DefaultValue = ""
        tbl.Columns("is_useable").DefaultValue = 0
        tbl.Columns("asset_active").DefaultValue = 1
        tbl.Columns("asset_status").DefaultValue = "AVL"
        tbl.Columns("project_id").DefaultValue = DBNull.Value
        tbl.Columns("show_id").DefaultValue = DBNull.Value
        tbl.Columns("asset_eps").DefaultValue = ""
        tbl.Columns("wo_id").DefaultValue = ""
        tbl.Columns("inputby").DefaultValue = ""
        tbl.Columns("inputdt").DefaultValue = Now()
        tbl.Columns("editby").DefaultValue = ""
        tbl.Columns("editdt").DefaultValue = Now()
        tbl.Columns("usedby").DefaultValue = ""
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("jurnal").DefaultValue = 0
        tbl.Columns("jurnal_by").DefaultValue = String.Empty
        tbl.Columns("jurnal_dt").DefaultValue = Now()

        Return tbl
    End Function



    Public Shared Function CreateTblMstRekanan() As DataTable
        Dim tblvendor As DataTable = New DataTable

        tblvendor.Columns.Clear()
        tblvendor.Columns.Add(New DataColumn("rekanan_id", GetType(System.Int64)))
        tblvendor.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))

        'Default Value: 
        tblvendor.Columns("rekanan_id").DefaultValue = 0
        tblvendor.Columns("rekanan_name").DefaultValue = ""
        Return tblvendor
    End Function




    Public Shared Function CreateTblMstAsset(ByVal schannel As String) As DataTable
        m_channel = schannel
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_tgl", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("tipeasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_lineinduk", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("asset_barcodeinduk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_serial", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_produknumber", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_model", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_deskripsi", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tipeitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_golfiskal", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_tipedepre", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_depre_enddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_harga", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_hargabaru", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_ppn", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_depresiasi", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("asset_akum_val_depre", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_idrprice", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_owner", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_qty", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("material_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("warna_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ukuran_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jeniskelamin_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_id_cont_item", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ruang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_rak", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("is_useable", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("asset_active", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("asset_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("project_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("wo_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("wo_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("inputby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inputdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("editby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("editdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_deprebulanan", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_stdepre", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("asset_eddepre", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("golongan_pajak", GetType(System.String)))

        tbl.Columns("terimabarang_id").DefaultValue = String.Empty
        tbl.Columns("asset_line").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("asset_tgl").DefaultValue = Now()
        tbl.Columns("tipeasset_id").DefaultValue = String.Empty
        tbl.Columns("kategoriasset_id").DefaultValue = String.Empty
        tbl.Columns("asset_barcode").DefaultValue = String.Empty
        tbl.Columns("asset_lineinduk").DefaultValue = 0
        tbl.Columns("asset_barcodeinduk").DefaultValue = String.Empty
        tbl.Columns("asset_serial").DefaultValue = String.Empty
        tbl.Columns("asset_produknumber").DefaultValue = String.Empty
        tbl.Columns("asset_model").DefaultValue = String.Empty
        tbl.Columns("asset_deskripsi").DefaultValue = String.Empty
        tbl.Columns("kategoriitem_id").DefaultValue = String.Empty
        tbl.Columns("tipeitem_id").DefaultValue = String.Empty
        tbl.Columns("asset_golfiskal").DefaultValue = String.Empty
        tbl.Columns("asset_tipedepre").DefaultValue = String.Empty
        tbl.Columns("asset_depre_enddt").DefaultValue = Now()
        tbl.Columns("currency_id").DefaultValue = 1
        tbl.Columns("asset_harga").DefaultValue = 1
        tbl.Columns("asset_hargabaru").DefaultValue = 0
        tbl.Columns("asset_ppn").DefaultValue = 0
        tbl.Columns("asset_pph").DefaultValue = 0
        tbl.Columns("asset_disc").DefaultValue = 0
        tbl.Columns("asset_depresiasi").DefaultValue = 0
        tbl.Columns("asset_akum_val_depre").DefaultValue = 0
        tbl.Columns("asset_valas").DefaultValue = 0
        tbl.Columns("asset_idrprice").DefaultValue = 0
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("employee_id_owner").DefaultValue = String.Empty
        tbl.Columns("brand_id").DefaultValue = 0
        tbl.Columns("unit_id").DefaultValue = 0
        tbl.Columns("asset_qty").DefaultValue = 0
        tbl.Columns("material_id").DefaultValue = String.Empty
        tbl.Columns("warna_id").DefaultValue = String.Empty
        tbl.Columns("ukuran_id").DefaultValue = String.Empty
        tbl.Columns("jeniskelamin_id").DefaultValue = String.Empty
        tbl.Columns("show_id_cont_item").DefaultValue = String.Empty
        tbl.Columns("ruang_id").DefaultValue = String.Empty
        tbl.Columns("asset_rak").DefaultValue = String.Empty
        tbl.Columns("is_useable").DefaultValue = 0
        tbl.Columns("asset_active").DefaultValue = 1
        tbl.Columns("asset_status").DefaultValue = String.Empty
        tbl.Columns("project_id").DefaultValue = 0
        tbl.Columns("show_id").DefaultValue = String.Empty
        tbl.Columns("asset_eps").DefaultValue = String.Empty
        tbl.Columns("wo_id").DefaultValue = String.Empty
        tbl.Columns("wo_date").DefaultValue = DBNull.Value
        tbl.Columns("inputby").DefaultValue = String.Empty
        tbl.Columns("inputdt").DefaultValue = Now()
        tbl.Columns("editby").DefaultValue = String.Empty
        tbl.Columns("editdt").DefaultValue = Now()
        tbl.Columns("usedby").DefaultValue = String.Empty
        tbl.Columns("asset_deprebulanan").DefaultValue = 0
        tbl.Columns("asset_stdepre").DefaultValue = Now()
        tbl.Columns("asset_eddepre").DefaultValue = Now()
        tbl.Columns("golongan_pajak").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblMstAssetoperasional() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_tgl", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("tipeasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_lineinduk", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("asset_barcodeinduk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_serial", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_produknumber", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_model", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_deskripsi", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tipeitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_golfiskal", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_tipedepre", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_depre_enddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_harga", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_hargabaru", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_ppn", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_depresiasi", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("asset_akum_val_depre", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_idrprice", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_owner", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_qty", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("material_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("warna_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ukuran_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jeniskelamin_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_id_cont_item", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ruang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_rak", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("is_useable", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("asset_active", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("asset_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("project_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("wo_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inputby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inputdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("editby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("editdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_deprebulanan", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_stdepre", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("asset_eddepre", GetType(System.DateTime)))

        tbl.Columns("terimabarang_id").DefaultValue = String.Empty
        tbl.Columns("asset_line").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("asset_tgl").DefaultValue = Now()
        tbl.Columns("tipeasset_id").DefaultValue = String.Empty
        tbl.Columns("kategoriasset_id").DefaultValue = String.Empty
        tbl.Columns("asset_barcode").DefaultValue = String.Empty
        tbl.Columns("asset_lineinduk").DefaultValue = 0
        tbl.Columns("asset_barcodeinduk").DefaultValue = String.Empty
        tbl.Columns("asset_serial").DefaultValue = String.Empty
        tbl.Columns("asset_produknumber").DefaultValue = String.Empty
        tbl.Columns("asset_model").DefaultValue = String.Empty
        tbl.Columns("asset_deskripsi").DefaultValue = String.Empty
        tbl.Columns("kategoriitem_id").DefaultValue = String.Empty
        tbl.Columns("tipeitem_id").DefaultValue = String.Empty
        tbl.Columns("asset_golfiskal").DefaultValue = String.Empty
        tbl.Columns("asset_tipedepre").DefaultValue = String.Empty
        tbl.Columns("asset_depre_enddt").DefaultValue = Now()
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("asset_harga").DefaultValue = 0
        tbl.Columns("asset_hargabaru").DefaultValue = 0
        tbl.Columns("asset_ppn").DefaultValue = 0
        tbl.Columns("asset_pph").DefaultValue = 0
        tbl.Columns("asset_disc").DefaultValue = 0
        tbl.Columns("asset_depresiasi").DefaultValue = 0
        tbl.Columns("asset_akum_val_depre").DefaultValue = 0
        tbl.Columns("asset_valas").DefaultValue = 0
        tbl.Columns("asset_idrprice").DefaultValue = 0
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("employee_id_owner").DefaultValue = String.Empty
        tbl.Columns("brand_id").DefaultValue = 0
        tbl.Columns("unit_id").DefaultValue = 0
        tbl.Columns("asset_qty").DefaultValue = 0
        tbl.Columns("material_id").DefaultValue = String.Empty
        tbl.Columns("warna_id").DefaultValue = String.Empty
        tbl.Columns("ukuran_id").DefaultValue = String.Empty
        tbl.Columns("jeniskelamin_id").DefaultValue = String.Empty
        tbl.Columns("show_id_cont_item").DefaultValue = String.Empty
        tbl.Columns("ruang_id").DefaultValue = String.Empty
        tbl.Columns("asset_rak").DefaultValue = String.Empty
        tbl.Columns("is_useable").DefaultValue = 0
        tbl.Columns("asset_active").DefaultValue = 0
        tbl.Columns("asset_status").DefaultValue = String.Empty
        tbl.Columns("project_id").DefaultValue = 0
        tbl.Columns("show_id").DefaultValue = String.Empty
        tbl.Columns("asset_eps").DefaultValue = String.Empty
        tbl.Columns("wo_id").DefaultValue = String.Empty
        tbl.Columns("inputby").DefaultValue = String.Empty
        tbl.Columns("inputdt").DefaultValue = Now()
        tbl.Columns("editby").DefaultValue = String.Empty
        tbl.Columns("editdt").DefaultValue = Now()
        tbl.Columns("usedby").DefaultValue = String.Empty
        tbl.Columns("asset_deprebulanan").DefaultValue = 0
        tbl.Columns("asset_stdepre").DefaultValue = Now()
        tbl.Columns("asset_eddepre").DefaultValue = Now()

        Return tbl
    End Function

    Public Shared Function CreateTblMstAssetAllFix(ByVal schannel As String) As DataTable
        m_channel = schannel
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_tgl", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("tipeasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_lineinduk", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_barcodeinduk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_serial", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_produknumber", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_model", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_deskripsi", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_harga", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("kategoriitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tipeitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_qty", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("material_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("warna_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ukuran_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jeniskelamin_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_id_cont_item", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("is_active", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("is_useable", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("asset_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_owner", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("wo_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ruang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_rak", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_ppn", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_depresiasi", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_totdep", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("project_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_idrprice", GetType(System.Decimal)))




        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = m_channel
        tbl.Columns("terimabarang_id").DefaultValue = ""
        tbl.Columns("asset_line").DefaultValue = 0
        tbl.Columns("asset_tgl").DefaultValue = Now()
        tbl.Columns("tipeasset_id").DefaultValue = DBNull.Value
        tbl.Columns("kategoriasset_id").DefaultValue = DBNull.Value
        tbl.Columns("asset_barcode").DefaultValue = ""
        tbl.Columns("asset_lineinduk").DefaultValue = 0
        tbl.Columns("asset_barcodeinduk").DefaultValue = ""
        tbl.Columns("asset_serial").DefaultValue = ""
        tbl.Columns("asset_produknumber").DefaultValue = ""
        tbl.Columns("asset_model").DefaultValue = ""
        tbl.Columns("asset_deskripsi").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = DBNull.Value
        tbl.Columns("asset_harga").DefaultValue = 0
        tbl.Columns("kategoriitem_id").DefaultValue = DBNull.Value
        tbl.Columns("tipeitem_id").DefaultValue = DBNull.Value
        tbl.Columns("strukturunit_id").DefaultValue = DBNull.Value
        tbl.Columns("brand_id").DefaultValue = DBNull.Value
        tbl.Columns("unit_id").DefaultValue = DBNull.Value
        tbl.Columns("asset_qty").DefaultValue = DBNull.Value
        tbl.Columns("material_id").DefaultValue = DBNull.Value
        tbl.Columns("warna_id").DefaultValue = DBNull.Value
        tbl.Columns("ukuran_id").DefaultValue = DBNull.Value
        tbl.Columns("jeniskelamin_id").DefaultValue = DBNull.Value
        tbl.Columns("show_id_cont_item").DefaultValue = DBNull.Value
        tbl.Columns("is_active").DefaultValue = 1
        tbl.Columns("is_useable").DefaultValue = 0
        tbl.Columns("asset_status").DefaultValue = ""
        tbl.Columns("employee_id_owner").DefaultValue = ""
        tbl.Columns("wo_id").DefaultValue = ""
        tbl.Columns("ruang_id").DefaultValue = ""
        tbl.Columns("asset_rak").DefaultValue = ""
        tbl.Columns("asset_ppn").DefaultValue = 0
        tbl.Columns("asset_pph").DefaultValue = 0
        tbl.Columns("asset_disc").DefaultValue = 0
        tbl.Columns("asset_depresiasi").DefaultValue = 0
        tbl.Columns("asset_totdep").DefaultValue = 0
        tbl.Columns("project_id").DefaultValue = 0
        tbl.Columns("show_id").DefaultValue = ""
        tbl.Columns("asset_eps").DefaultValue = ""
        tbl.Columns("asset_valas").DefaultValue = 0
        tbl.Columns("asset_idrprice").DefaultValue = 0
        Return tbl
    End Function

    Public Shared Function CreateTblVendor() As DataTable
        Dim tblvendor As DataTable = New DataTable

        tblvendor.Columns.Clear()
        tblvendor.Columns.Add(New DataColumn("code", GetType(System.Int64)))
        tblvendor.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))

        'Default Value: 
        tblvendor.Columns("channel_id").DefaultValue = ""
        tblvendor.Columns("terimabarang_id").DefaultValue = ""
        Return tblvendor
    End Function

    Public Shared Function CreateTblVendor2() As DataTable
        Dim tblvendor2 As DataTable = New DataTable

        tblvendor2.Columns.Clear()
        tblvendor2.Columns.Add(New DataColumn("rekanan_id", GetType(System.Int64)))
        tblvendor2.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))

        'Default Value: 
        tblvendor2.Columns("rekanan_id").DefaultValue = 0
        tblvendor2.Columns("rekanan_name").DefaultValue = ""
        Return tblvendor2
    End Function

    Public Shared Function CreateTblMstWarna() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("warna_id", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("warna_id").DefaultValue = DBNull.Value
        Return tbl
    End Function

    Public Shared Function CreateTblMstMaterial() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("material_id", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("material_id").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblMstKategoriitem() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("kategoriitem_id", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("kategoriitem_id").DefaultValue = DBNull.Value


        Return tbl
    End Function

    Public Shared Function CreateTblMstChannel() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_number", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_namereport", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_address", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_telp1", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_telp2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_telp3", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_fax", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_defrex", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_isdisabled", GetType(System.Boolean)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("channel_name").DefaultValue = ""
        tbl.Columns("channel_number").DefaultValue = ""
        tbl.Columns("channel_namereport").DefaultValue = ""
        tbl.Columns("channel_address").DefaultValue = ""
        tbl.Columns("channel_telp1").DefaultValue = ""
        tbl.Columns("channel_telp2").DefaultValue = ""
        tbl.Columns("channel_telp3").DefaultValue = ""
        tbl.Columns("channel_fax").DefaultValue = ""
        tbl.Columns("channel_defrex").DefaultValue = ""
        tbl.Columns("channel_isdisabled").DefaultValue = 0


        Return tbl
    End Function

    Public Shared Function CreateTblMstPilihan() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("Kategori", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Pilihan", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("is_disable", GetType(System.Int64)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("Kategori").DefaultValue = ""
        tbl.Columns("Pilihan").DefaultValue = ""
        tbl.Columns("is_disable").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblemployeepemeriksa() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("employee_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_namalengkap", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("employee_id").DefaultValue = ""
        tbl.Columns("employee_namalengkap").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblemployeepemilik() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("employee_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_namalengkap", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("employee_id").DefaultValue = ""
        tbl.Columns("employee_namalengkap").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = ""
        Return tbl
    End Function

    Public Shared Function CreateTblStrukturunitPemilik() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_nameshort", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_namereport", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_parent", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_path", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_isgroup", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("strukturunit_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("strukturlevel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("costcenter_id", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("strukturunit_name").DefaultValue = ""
        tbl.Columns("strukturunit_nameshort").DefaultValue = ""
        tbl.Columns("strukturunit_namereport").DefaultValue = ""
        tbl.Columns("strukturunit_parent").DefaultValue = ""
        tbl.Columns("strukturunit_path").DefaultValue = ""
        tbl.Columns("strukturunit_isgroup").DefaultValue = 0
        tbl.Columns("strukturunit_isdisabled").DefaultValue = 0
        tbl.Columns("strukturlevel_id").DefaultValue = ""
        tbl.Columns("costcenter_id").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblemployeePengguna() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("employee_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_namalengkap", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("employee_id").DefaultValue = ""
        tbl.Columns("employee_namalengkap").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = ""
        Return tbl
    End Function

    Public Shared Function CreateTblStrukturunitPengguna() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("strukturunit_id").DefaultValue = ""
        tbl.Columns("strukturunit_name").DefaultValue = ""
        Return tbl
    End Function

    Public Shared Function CreateTblMstMerk() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("merk_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("merk_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("merk_active", GetType(System.Boolean)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("merk_id").DefaultValue = 0
        tbl.Columns("merk_name").DefaultValue = ""
        tbl.Columns("merk_active").DefaultValue = 1


        Return tbl
    End Function


    Public Shared Function CreateTblMstTipeitem() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("Tipeitem_id", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("Tipeitem_id").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblMstKategoriasset() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_time", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("kategoriasset_depresiasitime", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_depresiasivalue", GetType(System.Decimal)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("kategoriasset_id").DefaultValue = ""
        tbl.Columns("kategoriasset_time").DefaultValue = 0
        tbl.Columns("kategoriasset_depresiasitime").DefaultValue = ""
        tbl.Columns("kategoriasset_depresiasivalue").DefaultValue = 0


        Return tbl
    End Function

    Public Shared Function CreateTblMstTipeasset() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("tipeasset_id", GetType(System.String)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("tipeasset_id").DefaultValue = ""
        Return tbl
    End Function

    Public Shared Function CreateTblMstCurrency() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("Currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("Currency_shortname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Currency_Name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Currency_Country", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Currency_Active", GetType(System.Boolean)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("Currency_id").DefaultValue = 0
        tbl.Columns("Currency_shortname").DefaultValue = ""
        tbl.Columns("Currency_Name").DefaultValue = ""
        tbl.Columns("Currency_Country").DefaultValue = ""
        tbl.Columns("Currency_Active").DefaultValue = 1


        Return tbl
    End Function

    Public Shared Function CreateTblMstCurrencyJurnal() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_shortname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_isdisabled", GetType(System.Boolean)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_name").DefaultValue = ""
        tbl.Columns("currency_shortname").DefaultValue = ""
        tbl.Columns("currency_isdisabled").DefaultValue = 0


        Return tbl
    End Function

    Public Shared Function CreateTblMstUnit() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("unit_shortname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unit_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unit_base", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("unit_active", GetType(System.Decimal)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("unit_id").DefaultValue = 0
        tbl.Columns("unit_shortname").DefaultValue = ""
        tbl.Columns("unit_name").DefaultValue = ""
        tbl.Columns("unit_type").DefaultValue = DBNull.Value
        tbl.Columns("unit_base").DefaultValue = 0
        tbl.Columns("unit_active").DefaultValue = 1


        Return tbl
    End Function

    Public Shared Function CreateTblMstUnittype() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("name", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("name").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblMstUkuran() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("ukuran_id", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("ukuran_id").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblTrnWriteoff(ByVal schannel As String) As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("writeoff_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("writeoff_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("employee_id_reportby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id_reportby", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_approvedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("writeoff_inputby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("writeoff_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("lock", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("employee_id_internal_audit", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_procurement", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_accounting", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_frm_director", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_president_director", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_commissioner", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_owner_dept_head", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_owner_div_head", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_owner_director", GetType(System.String)))

        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("writeoff_id").DefaultValue = String.Empty
        tbl.Columns("writeoff_dt").DefaultValue = Now()
        tbl.Columns("employee_id_reportby").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id_reportby").DefaultValue = 0
        tbl.Columns("employee_id_approvedby").DefaultValue = String.Empty
        tbl.Columns("writeoff_inputby").DefaultValue = String.Empty
        tbl.Columns("writeoff_date").DefaultValue = Now()
        tbl.Columns("lock").DefaultValue = 0
        tbl.Columns("employee_id_internal_audit").DefaultValue = String.Empty
        tbl.Columns("employee_id_procurement").DefaultValue = String.Empty
        tbl.Columns("employee_id_accounting").DefaultValue = String.Empty
        tbl.Columns("employee_id_frm_director").DefaultValue = String.Empty
        tbl.Columns("employee_id_president_director").DefaultValue = String.Empty
        tbl.Columns("employee_id_commissioner").DefaultValue = String.Empty
        tbl.Columns("employee_id_owner_dept_head").DefaultValue = String.Empty
        tbl.Columns("employee_id_owner_div_head").DefaultValue = String.Empty
        tbl.Columns("employee_id_owner_director").DefaultValue = String.Empty



        Return tbl
    End Function

    Public Shared Function CreateTblTrnWriteoffdetil(ByVal schannel As String) As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("writeoff_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("writeoff_tgl", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("writeoff_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("writeoff_hargaawal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id_akhir", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("writeoff_hargakhir", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_writeoffby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_writeoffapp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("writeoff_desc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("status_akhir", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("asset_deskripsi", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_serial", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tipeitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriitem_id", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = schannel
        tbl.Columns("writeoff_id").DefaultValue = "AUTO"
        tbl.Columns("writeoff_tgl").DefaultValue = Now()
        tbl.Columns("writeoff_barcode").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("writeoff_hargaawal").DefaultValue = 0
        tbl.Columns("currency_id_akhir").DefaultValue = 0
        tbl.Columns("writeoff_hargakhir").DefaultValue = 0
        tbl.Columns("employee_id_writeoffby").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("employee_id_writeoffapp").DefaultValue = ""
        tbl.Columns("writeoff_desc").DefaultValue = ""
        tbl.Columns("status_akhir").DefaultValue = ""

        tbl.Columns("asset_deskripsi").DefaultValue = ""
        tbl.Columns("asset_serial").DefaultValue = ""
        tbl.Columns("tipeitem_id").DefaultValue = ""
        tbl.Columns("kategoriitem_id").DefaultValue = ""

        Return tbl
    End Function

    Public Shared Function CreateTblMstRuang() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("ruang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("wilayah_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("gedung_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ruang_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ruang_lantai", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))

        tbl.Columns("ruang_id").DefaultValue = String.Empty
        tbl.Columns("wilayah_name").DefaultValue = String.Empty
        tbl.Columns("gedung_name").DefaultValue = String.Empty
        tbl.Columns("ruang_name").DefaultValue = String.Empty
        tbl.Columns("ruang_lantai").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblMstRuangAsset() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("ruang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ruang_lantai", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("keterangan", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("ruang_id").DefaultValue = ""
        tbl.Columns("ruang_lantai").DefaultValue = 0
        tbl.Columns("keterangan").DefaultValue = ""
        tbl.Columns("channel_id").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblTrnBookasset() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("bookasset_startdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bookasset_enddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bookasset_starttm", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_endtm", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_bookby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("struktur_unit_bookby", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_customerhead", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_item", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_epsnumber_st", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_epsnumber_ed", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("username_inputby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_inputdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bookasset_active", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("outasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_remark", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_lock", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("bookasset_editby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_editdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bookasset_usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_useddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("bookasset_purpose", GetType(System.String)))

        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("bookasset_id").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("bookasset_startdt").DefaultValue = Now()
        tbl.Columns("bookasset_enddt").DefaultValue = Now()
        tbl.Columns("bookasset_starttm").DefaultValue = String.Empty
        tbl.Columns("bookasset_endtm").DefaultValue = String.Empty
        tbl.Columns("employee_id_bookby").DefaultValue = String.Empty
        tbl.Columns("struktur_unit_bookby").DefaultValue = 0
        tbl.Columns("employee_id_customerhead").DefaultValue = String.Empty
        tbl.Columns("bookasset_item").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("show_id").DefaultValue = String.Empty
        tbl.Columns("show_epsnumber_st").DefaultValue = String.Empty
        tbl.Columns("show_epsnumber_ed").DefaultValue = String.Empty
        tbl.Columns("username_inputby").DefaultValue = String.Empty
        tbl.Columns("bookasset_inputdt").DefaultValue = Now()
        tbl.Columns("bookasset_active").DefaultValue = 0
        tbl.Columns("outasset_id").DefaultValue = String.Empty
        tbl.Columns("bookasset_remark").DefaultValue = String.Empty
        tbl.Columns("bookasset_lock").DefaultValue = 0
        tbl.Columns("bookasset_editby").DefaultValue = String.Empty
        tbl.Columns("bookasset_editdt").DefaultValue = Now()
        tbl.Columns("bookasset_usedby").DefaultValue = String.Empty
        tbl.Columns("bookasset_useddt").DefaultValue = Now()
        tbl.Columns("bookasset_purpose").DefaultValue = String.Empty

        Return tbl

    End Function

    Public Shared Function CreateTblTrnBookassetdetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("qty", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("status", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("sn", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("desk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tipe", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("brand", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("bookasset_id").DefaultValue = ""
        tbl.Columns("line").DefaultValue = 0
        tbl.Columns("asset_barcode").DefaultValue = ""
        tbl.Columns("qty").DefaultValue = 0
        tbl.Columns("status").DefaultValue = 0
        tbl.Columns("sn").DefaultValue = String.Empty
        tbl.Columns("desk").DefaultValue = String.Empty
        tbl.Columns("tipe").DefaultValue = String.Empty
        tbl.Columns("brand").DefaultValue = String.Empty


        Return tbl
    End Function

    Public Shared Function CreateTblTrnBookassetdetilView() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("sn", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("desk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tipe", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("brand", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("bookasset_id").DefaultValue = String.Empty
        tbl.Columns("line").DefaultValue = 0
        tbl.Columns("asset_barcode").DefaultValue = String.Empty
        tbl.Columns("sn").DefaultValue = String.Empty
        tbl.Columns("desk").DefaultValue = String.Empty
        tbl.Columns("tipe").DefaultValue = String.Empty
        tbl.Columns("brand").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblMstBudgetCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_nameshort", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = ""
        tbl.Columns("budget_nameshort").DefaultValue = ""

        Return tbl
    End Function

    Public Shared Function CreateTblMstBudgetdetilCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_desc", GetType(System.String)))

        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_desc").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblTrnOutasset() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()


        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("outasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_startdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("outasset_enddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("outasset_starttm", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_endtm", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_customer", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id_customer", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_customerhead", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_item", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("project_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_epsnumber_st", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_epsnumber_ed", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_lock", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("outasset_remark", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_logistik", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_delay", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("outasset_inputby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_inputdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("outasset_editby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_editdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("outasset_usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_useddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("outasset_purpose", GetType(System.String)))

        'tbl.Columns.Add(New DataColumn("strukturunit_id_string", GetType(System.String)))
        'tbl.Columns.Add(New DataColumn("employee_id_customer_string", GetType(System.String)))
        'tbl.Columns.Add(New DataColumn("struktur_unit_customer_string", GetType(System.String)))
        'tbl.Columns.Add(New DataColumn("employee_id_customerhead_string", GetType(System.String)))
        'tbl.Columns.Add(New DataColumn("show_id_string", GetType(System.String)))
        'tbl.Columns.Add(New DataColumn("project_id_string", GetType(System.String)))



        '    '-------------------------------
        '    'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("outasset_id").DefaultValue = ""
        tbl.Columns("bookasset_id").DefaultValue = ""
        tbl.Columns("outasset_startdt").DefaultValue = Now()
        tbl.Columns("outasset_enddt").DefaultValue = Now()
        tbl.Columns("outasset_starttm").DefaultValue = ""
        tbl.Columns("outasset_endtm").DefaultValue = ""
        tbl.Columns("employee_id_customer").DefaultValue = ""
        tbl.Columns("strukturunit_id_customer").DefaultValue = 0
        tbl.Columns("employee_id_customerhead").DefaultValue = ""
        tbl.Columns("outasset_item").DefaultValue = 0
        tbl.Columns("project_id").DefaultValue = 0
        tbl.Columns("show_id").DefaultValue = ""
        tbl.Columns("show_epsnumber_st").DefaultValue = ""
        tbl.Columns("show_epsnumber_ed").DefaultValue = ""
        tbl.Columns("outasset_lock").DefaultValue = 0
        tbl.Columns("outasset_remark").DefaultValue = ""
        tbl.Columns("outasset_logistik").DefaultValue = ""
        tbl.Columns("outasset_status").DefaultValue = "OUTGOING"
        tbl.Columns("outasset_delay").DefaultValue = 0
        tbl.Columns("outasset_inputby").DefaultValue = ""
        tbl.Columns("outasset_inputdt").DefaultValue = Now
        tbl.Columns("outasset_editby").DefaultValue = ""
        tbl.Columns("outasset_editdt").DefaultValue = Now
        tbl.Columns("outasset_usedby").DefaultValue = ""
        tbl.Columns("outasset_useddt").DefaultValue = Now
        tbl.Columns("outasset_purpose").DefaultValue = String.Empty




        'tbl.Columns("strukturunit_id_string").DefaultValue = ""
        'tbl.Columns("employee_id_customer_string").DefaultValue = ""
        'tbl.Columns("struktur_unit_customer_string").DefaultValue = ""
        'tbl.Columns("employee_id_customerhead_string").DefaultValue = ""
        'tbl.Columns("show_id_string").DefaultValue = ""
        'tbl.Columns("project_id_string").DefaultValue = ""




        Return tbl
    End Function

    Public Shared Function CreateTblTrnOutassetdetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("qty", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("is_useable", GetType(System.Int64)))

        tbl.Columns.Add(New DataColumn("incasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_return", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("inasset_status", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("outasset_id").DefaultValue = ""
        tbl.Columns("outasset_line").DefaultValue = 0
        tbl.Columns("barcode").DefaultValue = ""
        tbl.Columns("qty").DefaultValue = 0
        tbl.Columns("is_useable").DefaultValue = 0

        tbl.Columns("incasset_id").DefaultValue = ""
        tbl.Columns("outasset_return").DefaultValue = 0
        tbl.Columns("inasset_status").DefaultValue = ""


        Return tbl
    End Function
    
    Public Shared Function CreateTblTrnDepresiasi_backup() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("depresiasi_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("depresiasi_tgl", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("depresiasi_thn", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("depresiasi_bln", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_time", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("kategoriasset_depresiasitime", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_depresiasivalue", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("total_item", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("harga_item_awal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("harga_item", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("besar_depresiasi", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("depresiasi_adjust", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("depresiasi_add", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("depresiasi_akum", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("lock", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("lock_login", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("lock_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("post", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("post_login", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("postdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("NBV", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("create_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("create_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("edit_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("edit_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("used_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("used_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("additional_item_value", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("reklas_item_value", GetType(System.Decimal)))

        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("depresiasi_id").DefaultValue = String.Empty
        tbl.Columns("depresiasi_tgl").DefaultValue = Now()
        tbl.Columns("depresiasi_thn").DefaultValue = 0
        tbl.Columns("depresiasi_bln").DefaultValue = 0
        tbl.Columns("kategoriasset_id").DefaultValue = String.Empty
        tbl.Columns("kategoriasset_time").DefaultValue = 0
        tbl.Columns("kategoriasset_depresiasitime").DefaultValue = String.Empty
        tbl.Columns("kategoriasset_depresiasivalue").DefaultValue = 0
        tbl.Columns("total_item").DefaultValue = 0
        tbl.Columns("harga_item_awal").DefaultValue = 0
        tbl.Columns("harga_item").DefaultValue = 0
        tbl.Columns("besar_depresiasi").DefaultValue = 0
        tbl.Columns("depresiasi_adjust").DefaultValue = 0
        tbl.Columns("depresiasi_add").DefaultValue = 0
        tbl.Columns("depresiasi_akum").DefaultValue = 0
        tbl.Columns("lock").DefaultValue = 0
        tbl.Columns("lock_login").DefaultValue = String.Empty
        tbl.Columns("lock_dt").DefaultValue = Now()
        tbl.Columns("post").DefaultValue = 0
        tbl.Columns("post_login").DefaultValue = String.Empty
        tbl.Columns("postdate").DefaultValue = Now()
        tbl.Columns("NBV").DefaultValue = 0
        tbl.Columns("create_by").DefaultValue = String.Empty
        tbl.Columns("create_dt").DefaultValue = Now()
        tbl.Columns("edit_by").DefaultValue = String.Empty
        tbl.Columns("edit_dt").DefaultValue = Now()
        tbl.Columns("used_by").DefaultValue = String.Empty
        tbl.Columns("used_dt").DefaultValue = Now()
        tbl.Columns("additional_item_value").DefaultValue = 0
        tbl.Columns("reklas_item_value").DefaultValue = 0

        Return tbl
    End Function

    'Public Shared Function CreateTblTrnDepresiasi() As DataTable
    '    Dim tbl As DataTable = New DataTable

    '    tbl.Columns.Clear()
    '    tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("depresiasi_id", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("depresiasi_tgl", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("depresiasi_thn", GetType(System.Int32)))
    '    tbl.Columns.Add(New DataColumn("depresiasi_bln", GetType(System.Int32)))
    '    tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("kategoriasset_time", GetType(System.Int32)))
    '    tbl.Columns.Add(New DataColumn("kategoriasset_depresiasitime", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("kategoriasset_depresiasivalue", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("total_item", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("total_item_depre", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("cost_beginning", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("cost_additional", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("cost_deductional", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("cost_ending", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("depre_beginning", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("depre_additional", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("depre_deductional", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("depre_ending", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("lock", GetType(System.Byte)))
    '    tbl.Columns.Add(New DataColumn("lock_login", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("lock_dt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("post", GetType(System.Byte)))
    '    tbl.Columns.Add(New DataColumn("post_login", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("postdate", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("NBV", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("create_by", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("create_dt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("edit_by", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("edit_dt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("used_by", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("used_dt", GetType(System.DateTime)))

    '    tbl.Columns("channel_id").DefaultValue = String.Empty
    '    tbl.Columns("depresiasi_id").DefaultValue = String.Empty
    '    tbl.Columns("depresiasi_tgl").DefaultValue = Now()
    '    tbl.Columns("depresiasi_thn").DefaultValue = 0
    '    tbl.Columns("depresiasi_bln").DefaultValue = 0
    '    tbl.Columns("kategoriasset_id").DefaultValue = String.Empty
    '    tbl.Columns("kategoriasset_time").DefaultValue = 0
    '    tbl.Columns("kategoriasset_depresiasitime").DefaultValue = String.Empty
    '    tbl.Columns("kategoriasset_depresiasivalue").DefaultValue = 0
    '    tbl.Columns("total_item").DefaultValue = 0
    '    tbl.Columns("total_item_depre").DefaultValue = 0
    '    tbl.Columns("cost_beginning").DefaultValue = 0
    '    tbl.Columns("cost_additional").DefaultValue = 0
    '    tbl.Columns("cost_deductional").DefaultValue = 0
    '    tbl.Columns("cost_ending").DefaultValue = 0
    '    tbl.Columns("depre_beginning").DefaultValue = 0
    '    tbl.Columns("depre_additional").DefaultValue = 0
    '    tbl.Columns("depre_deductional").DefaultValue = 0
    '    tbl.Columns("depre_ending").DefaultValue = 0
    '    tbl.Columns("lock").DefaultValue = 0
    '    tbl.Columns("lock_login").DefaultValue = String.Empty
    '    tbl.Columns("lock_dt").DefaultValue = Now()
    '    tbl.Columns("post").DefaultValue = 0
    '    tbl.Columns("post_login").DefaultValue = String.Empty
    '    tbl.Columns("postdate").DefaultValue = Now()
    '    tbl.Columns("NBV").DefaultValue = 0
    '    tbl.Columns("create_by").DefaultValue = String.Empty
    '    tbl.Columns("create_dt").DefaultValue = Now()
    '    tbl.Columns("edit_by").DefaultValue = String.Empty
    '    tbl.Columns("edit_dt").DefaultValue = Now()
    '    tbl.Columns("used_by").DefaultValue = String.Empty
    '    tbl.Columns("used_dt").DefaultValue = Now()

    '    Return tbl
    'End Function
    'Public Shared Function CreateTblTrnDepresiasidetil() As DataTable
    '    Dim tbl As DataTable = New DataTable

    '    tbl.Columns.Clear()
    '    tbl.Columns.Add(New DataColumn("depresiasi_id", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("depresiasi_thn", GetType(System.Int32)))
    '    tbl.Columns.Add(New DataColumn("depresiasi_bln", GetType(System.Int32)))
    '    tbl.Columns.Add(New DataColumn("asset_strukturunit", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("asset_kategori", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("kategori_time", GetType(System.Int32)))
    '    tbl.Columns.Add(New DataColumn("Jumlah_depre", GetType(System.Int32)))
    '    tbl.Columns.Add(New DataColumn("cost_beginning", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("cost_additional", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("cost_deductional", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("cost_ending", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("depre_beginning", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("depre_additional", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("depre_deductional", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("depre_ending", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("NBV", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("asset_stdt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("asset_eddt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("create_by", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("create_dt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("edit_by", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("edit_dt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("asset_tipedepre", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("depresiasi_remark", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("depresiasi_kali", GetType(System.Int32)))
    '    tbl.Columns.Add(New DataColumn("asset_golpajak", GetType(System.String)))

    '    tbl.Columns("depresiasi_id").DefaultValue = String.Empty
    '    tbl.Columns("asset_barcode").DefaultValue = String.Empty
    '    tbl.Columns("channel_id").DefaultValue = String.Empty
    '    tbl.Columns("depresiasi_thn").DefaultValue = 0
    '    tbl.Columns("depresiasi_bln").DefaultValue = 0
    '    tbl.Columns("asset_strukturunit").DefaultValue = 0
    '    tbl.Columns("asset_kategori").DefaultValue = String.Empty
    '    tbl.Columns("kategori_time").DefaultValue = 0
    '    tbl.Columns("Jumlah_depre").DefaultValue = 0
    '    tbl.Columns("cost_beginning").DefaultValue = 0
    '    tbl.Columns("cost_additional").DefaultValue = 0
    '    tbl.Columns("cost_deductional").DefaultValue = 0
    '    tbl.Columns("cost_ending").DefaultValue = 0
    '    tbl.Columns("depre_beginning").DefaultValue = 0
    '    tbl.Columns("depre_additional").DefaultValue = 0
    '    tbl.Columns("depre_deductional").DefaultValue = 0
    '    tbl.Columns("depre_ending").DefaultValue = 0
    '    tbl.Columns("NBV").DefaultValue = 0
    '    tbl.Columns("asset_stdt").DefaultValue = Now()
    '    tbl.Columns("asset_eddt").DefaultValue = Now()
    '    tbl.Columns("create_by").DefaultValue = String.Empty
    '    tbl.Columns("create_dt").DefaultValue = Now()
    '    tbl.Columns("edit_by").DefaultValue = String.Empty
    '    tbl.Columns("edit_dt").DefaultValue = Now()
    '    tbl.Columns("asset_tipedepre").DefaultValue = String.Empty
    '    tbl.Columns("depresiasi_remark").DefaultValue = String.Empty
    '    tbl.Columns("depresiasi_kali").DefaultValue = 0
    '    tbl.Columns("asset_golpajak").DefaultValue = String.Empty


    '    Return tbl
    'End Function

    Public Shared Function CreateTblTrnIncasset() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("incasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("bookasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("incasset_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("outasset_startdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("outasset_enddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("incasset_actreturn", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("outasset_item", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("incasset_returnitem", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("employee_id_returnby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id_returnby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("username_inputby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("incasset_inputdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("inasset_remark", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inasset_logistik", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inasset_lock", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("incasset_editby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("incasset_editdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("incasset_usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("incasset_useddt", GetType(System.DateTime)))

        tbl.Columns.Add(New DataColumn("strukturunit_id_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_return_by_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("struktur_unit_id_returnby_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inasset_logistik_string", GetType(System.String)))





        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = ""
        tbl.Columns("incasset_id").DefaultValue = ""
        tbl.Columns("outasset_id").DefaultValue = ""
        tbl.Columns("bookasset_id").DefaultValue = ""
        tbl.Columns("incasset_status").DefaultValue = ""
        tbl.Columns("outasset_startdt").DefaultValue = Now()
        tbl.Columns("outasset_enddt").DefaultValue = Now()
        tbl.Columns("incasset_actreturn").DefaultValue = Now()
        tbl.Columns("outasset_item").DefaultValue = 0
        tbl.Columns("incasset_returnitem").DefaultValue = 0
        tbl.Columns("employee_id_returnby").DefaultValue = ""
        tbl.Columns("strukturunit_id_returnby").DefaultValue = ""
        tbl.Columns("username_inputby").DefaultValue = ""
        tbl.Columns("incasset_inputdt").DefaultValue = Now()
        tbl.Columns("inasset_remark").DefaultValue = ""
        tbl.Columns("inasset_logistik").DefaultValue = ""
        tbl.Columns("inasset_lock").DefaultValue = 0
        tbl.Columns("incasset_editby").DefaultValue = ""
        tbl.Columns("incasset_editdt").DefaultValue = Now
        tbl.Columns("incasset_usedby").DefaultValue = ""
        tbl.Columns("incasset_useddt").DefaultValue = Now

        tbl.Columns("strukturunit_id_string").DefaultValue = ""
        tbl.Columns("employee_id_return_by_string").DefaultValue = ""
        tbl.Columns("struktur_unit_id_returnby_string").DefaultValue = ""
        tbl.Columns("inasset_logistik_string").DefaultValue = ""



        Return tbl
    End Function

    Public Shared Function CreateTblTrnIncassetdetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("incasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("qty", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("is_useable", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_status", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("incasset_id").DefaultValue = ""
        tbl.Columns("line").DefaultValue = 0
        tbl.Columns("asset_barcode").DefaultValue = ""
        tbl.Columns("qty").DefaultValue = 0
        tbl.Columns("is_useable").DefaultValue = 0
        tbl.Columns("asset_status").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblMstProject() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("project_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("project_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("project_nameshort", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("project_ispilot", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("showcategory_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("showtype_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("prodtype_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("project_isactive", GetType(System.Boolean)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("project_id").DefaultValue = 0
        tbl.Columns("project_name").DefaultValue = ""
        tbl.Columns("project_nameshort").DefaultValue = ""
        tbl.Columns("project_ispilot").DefaultValue = 0
        tbl.Columns("showcategory_id").DefaultValue = 0
        tbl.Columns("showtype_id").DefaultValue = 0
        tbl.Columns("prodtype_id").DefaultValue = 0
        tbl.Columns("project_isactive").DefaultValue = 0


        Return tbl
    End Function

    Public Shared Function CreateTblMstShow() As DataTable

        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("fokus_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("distributor_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Package_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_title", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_eps", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("show_run", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("show_dur", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("show_startdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("show_enddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("banner_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tipeshow_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("category1_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("category2_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_lokal", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_sinopsisEng", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_sinopsisIna", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("amortisasi_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("show_amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_kw", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_kwdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("show_active", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("show_lasttx", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("cass_id", GetType(System.String)))

        'Default Value: 
        tbl.Columns("show_id").DefaultValue = ""
        tbl.Columns("fokus_id").DefaultValue = ""
        tbl.Columns("distributor_id").DefaultValue = ""
        tbl.Columns("Package_id").DefaultValue = ""
        tbl.Columns("show_title").DefaultValue = ""
        tbl.Columns("show_eps").DefaultValue = 0
        tbl.Columns("show_run").DefaultValue = 0
        tbl.Columns("show_dur").DefaultValue = 0
        tbl.Columns("show_startdt").DefaultValue = Now()
        tbl.Columns("show_enddt").DefaultValue = Now()
        tbl.Columns("banner_id").DefaultValue = ""
        tbl.Columns("tipeshow_id").DefaultValue = ""
        tbl.Columns("category1_id").DefaultValue = ""
        tbl.Columns("category2_id").DefaultValue = ""
        tbl.Columns("show_lokal").DefaultValue = ""
        tbl.Columns("show_sinopsisEng").DefaultValue = ""
        tbl.Columns("show_sinopsisIna").DefaultValue = ""
        tbl.Columns("amortisasi_id").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("show_amount").DefaultValue = 0
        tbl.Columns("show_valas").DefaultValue = 0
        tbl.Columns("show_kw").DefaultValue = ""
        tbl.Columns("show_kwdate").DefaultValue = Now()
        tbl.Columns("show_active").DefaultValue = 0
        tbl.Columns("show_lasttx").DefaultValue = Now()
        tbl.Columns("cass_id").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblTrnMoveasset() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("moveasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("moveasset_tgl", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("moveasset_strukturunit", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("moveasset_report", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("moveasset_acct", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_id_old", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id_old", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_new", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id_new", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("moveasset_remark", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("moveasset_item", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("moveasset_lock", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("moveasset_inputby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("moveasset_inputdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("moveasset_editby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("moveasset_editdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("moveasset_usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("moveasset_useddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("employee_old_depthead", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_old_divhead", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_new_depthead", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_new_divhead", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_acc", GetType(System.String)))




        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("moveasset_id").DefaultValue = ""
        tbl.Columns("moveasset_tgl").DefaultValue = Now()
        tbl.Columns("moveasset_strukturunit").DefaultValue = 0
        tbl.Columns("moveasset_report").DefaultValue = ""
        tbl.Columns("moveasset_acct").DefaultValue = ""
        tbl.Columns("employee_id_old").DefaultValue = ""
        tbl.Columns("strukturunit_id_old").DefaultValue = 0
        tbl.Columns("employee_id_new").DefaultValue = ""
        tbl.Columns("strukturunit_id_new").DefaultValue = 0
        tbl.Columns("moveasset_remark").DefaultValue = ""
        tbl.Columns("moveasset_item").DefaultValue = 0
        tbl.Columns("moveasset_lock").DefaultValue = 0
        tbl.Columns("moveasset_inputby").DefaultValue = String.Empty
        tbl.Columns("moveasset_inputdt").DefaultValue = Now()
        tbl.Columns("moveasset_editby").DefaultValue = String.Empty
        tbl.Columns("moveasset_editdt").DefaultValue = Now()
        tbl.Columns("moveasset_usedby").DefaultValue = String.Empty
        tbl.Columns("moveasset_useddt").DefaultValue = Now()
        tbl.Columns("employee_old_depthead").DefaultValue = String.Empty
        tbl.Columns("employee_old_divhead").DefaultValue = String.Empty
        tbl.Columns("employee_new_depthead").DefaultValue = String.Empty
        tbl.Columns("employee_new_divhead").DefaultValue = String.Empty
        tbl.Columns("employee_acc").DefaultValue = String.Empty



        Return tbl
    End Function

    Public Shared Function CreateTblTrnMoveassetdetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("moveasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_oldowner", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_idold", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_newowner", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_idnew", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("remark", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("channel").DefaultValue = ""
        tbl.Columns("moveasset_id").DefaultValue = ""
        tbl.Columns("line").DefaultValue = 0
        tbl.Columns("asset_barcode").DefaultValue = ""
        tbl.Columns("employee_oldowner").DefaultValue = ""
        tbl.Columns("strukturunit_idold").DefaultValue = 0
        tbl.Columns("employee_newowner").DefaultValue = ""
        tbl.Columns("strukturunit_idnew").DefaultValue = 0
        tbl.Columns("asset_status").DefaultValue = ""
        tbl.Columns("remark").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblMstUser() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("username", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("user_password", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("user_fullname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("user_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("user_default_channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("user_can_change_channel", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("user_can_browse_channel", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("user_systemuser", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("login_user_erp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("user_position", GetType(System.Decimal)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("username").DefaultValue = ""
        tbl.Columns("user_password").DefaultValue = ""
        tbl.Columns("user_fullname").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("user_isdisabled").DefaultValue = 0
        tbl.Columns("user_default_channel_id").DefaultValue = ""
        tbl.Columns("user_can_change_channel").DefaultValue = 0
        tbl.Columns("user_can_browse_channel").DefaultValue = 0
        tbl.Columns("user_systemuser").DefaultValue = 0
        tbl.Columns("login_user_erp").DefaultValue = ""
        tbl.Columns("user_position").DefaultValue = 0


        Return tbl
    End Function

    Public Shared Function CreateTblMstStrukturunit() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_nameshort", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_namereport", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_parent", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_path", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_isgroup", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("strukturunit_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("strukturlevel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("costcenter_id", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("strukturunit_name").DefaultValue = ""
        tbl.Columns("strukturunit_nameshort").DefaultValue = ""
        tbl.Columns("strukturunit_namereport").DefaultValue = ""
        tbl.Columns("strukturunit_parent").DefaultValue = ""
        tbl.Columns("strukturunit_path").DefaultValue = ""
        tbl.Columns("strukturunit_isgroup").DefaultValue = 0
        tbl.Columns("strukturunit_isdisabled").DefaultValue = 0
        tbl.Columns("strukturlevel_id").DefaultValue = ""
        tbl.Columns("costcenter_id").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblTrnA() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("Channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("A_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("A_Lock", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("A_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("A_editby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("A_editdt", GetType(System.Datetime)))
        tbl.Columns.Add(New DataColumn("Channel_id_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id_string", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("Channel_id").DefaultValue = ""
        tbl.Columns("A_id").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("A_Lock").DefaultValue = 1
        tbl.Columns("A_createby").DefaultValue = ""
        tbl.Columns("A_editby").DefaultValue = ""
        tbl.Columns("A_editdt").DefaultValue = now()
        tbl.Columns("Channel_id_string").DefaultValue = ""
        tbl.Columns("strukturunit_id_string").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblTrnAdetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Out_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Out_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("Harga", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("Asset_Return", GetType(System.Int64)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("Out_id").DefaultValue = ""
        tbl.Columns("Out_line").DefaultValue = 0
        tbl.Columns("Harga").DefaultValue = 0
        tbl.Columns("Asset_Return").DefaultValue = 1


        Return tbl
    End Function

    Public Shared Function CreateTblViewReportDepre() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("depresiasi_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("depresiasi_thn", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("depresiasi_bln", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategori_time", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("harga_item_awal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_hargaawal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_hargaakhir", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jumlah_depre", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("akum_val_depre", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("nilai_depre", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("depresiasi_adjust", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("depresiasi_add", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("NBV", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_stdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("asset_eddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("asset_tipedepre", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tipeitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_deskripsi", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_serial", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("location", GetType(System.String)))

        tbl.Columns("kategoriasset_id").DefaultValue = String.Empty
        tbl.Columns("depresiasi_id").DefaultValue = String.Empty
        tbl.Columns("depresiasi_thn").DefaultValue = 0
        tbl.Columns("depresiasi_bln").DefaultValue = 0
        tbl.Columns("asset_barcode").DefaultValue = String.Empty
        tbl.Columns("kategori_time").DefaultValue = 0
        tbl.Columns("harga_item_awal").DefaultValue = 0
        tbl.Columns("asset_hargaawal").DefaultValue = 0
        tbl.Columns("asset_hargaakhir").DefaultValue = 0
        tbl.Columns("jumlah_depre").DefaultValue = 0
        tbl.Columns("akum_val_depre").DefaultValue = 0
        tbl.Columns("nilai_depre").DefaultValue = 0
        tbl.Columns("depresiasi_adjust").DefaultValue = 0
        tbl.Columns("depresiasi_add").DefaultValue = 0
        tbl.Columns("NBV").DefaultValue = 0
        tbl.Columns("asset_stdt").DefaultValue = Now()
        tbl.Columns("asset_eddt").DefaultValue = Now()
        tbl.Columns("asset_tipedepre").DefaultValue = String.Empty
        tbl.Columns("tipeitem_id").DefaultValue = String.Empty
        tbl.Columns("asset_deskripsi").DefaultValue = String.Empty
        tbl.Columns("asset_serial").DefaultValue = String.Empty
        tbl.Columns("brand_id").DefaultValue = String.Empty
        tbl.Columns("location").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblTrnPO() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("vendor", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("dely_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("dely_addr1", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("dely_addr2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("dely_addr3", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("dely_telp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("dely_fax", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("entry_by", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("entry_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("appr_by", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("appr_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("status", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("active", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("versi", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ni_ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("appr_auth", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("appr_ver", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("appr_req", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("remark", GetType(System.Byte)))

        tbl.Columns("ref").DefaultValue = String.Empty
        tbl.Columns("descr").DefaultValue = String.Empty
        tbl.Columns("dt").DefaultValue = Now()
        tbl.Columns("vendor").DefaultValue = 0
        tbl.Columns("amount").DefaultValue = 0
        tbl.Columns("currency").DefaultValue = 0
        tbl.Columns("valas").DefaultValue = 0
        tbl.Columns("dely_name").DefaultValue = String.Empty
        tbl.Columns("dely_addr1").DefaultValue = String.Empty
        tbl.Columns("dely_addr2").DefaultValue = String.Empty
        tbl.Columns("dely_addr3").DefaultValue = String.Empty
        tbl.Columns("dely_telp").DefaultValue = String.Empty
        tbl.Columns("dely_fax").DefaultValue = String.Empty
        tbl.Columns("entry_by").DefaultValue = 0
        tbl.Columns("entry_dt").DefaultValue = Now()
        tbl.Columns("appr_by").DefaultValue = 0
        tbl.Columns("appr_dt").DefaultValue = Now()
        tbl.Columns("status").DefaultValue = 0
        tbl.Columns("active").DefaultValue = 0
        tbl.Columns("versi").DefaultValue = 0
        tbl.Columns("ni_ref").DefaultValue = String.Empty
        tbl.Columns("appr_auth").DefaultValue = 0
        tbl.Columns("appr_ver").DefaultValue = 0
        tbl.Columns("appr_req").DefaultValue = 0
        tbl.Columns("remark").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblMstExrate() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("exrate_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("exrate_insertdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("exrate_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("exrate_currency", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("exrate_value", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("exrate_sell", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("exrate_buy", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("exrate_mid", GetType(System.Decimal)))

        tbl.Columns("exrate_id").DefaultValue = 0
        tbl.Columns("exrate_insertdate").DefaultValue = Now()
        tbl.Columns("exrate_date").DefaultValue = Now()
        tbl.Columns("exrate_currency").DefaultValue = String.Empty
        tbl.Columns("exrate_value").DefaultValue = 0
        tbl.Columns("exrate_sell").DefaultValue = 0
        tbl.Columns("exrate_buy").DefaultValue = 0
        tbl.Columns("exrate_mid").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblMstAssetalias() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_tgl", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("tipeasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_lineinduk", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("asset_barcodeinduk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_serial", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_produknumber", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_model", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_deskripsi", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("tipeitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_golfiskal", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_tipedepre", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_depre_enddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_harga", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_hargabaru", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_ppn", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_depresiasi", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("asset_akum_val_depre", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_idrprice", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_owner", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_qty", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("material_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("warna_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ukuran_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jeniskelamin_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_id_cont_item", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ruang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_rak", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("is_useable", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("asset_active", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("asset_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("project_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("show_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("wo_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inputby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("inputdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("editby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("editdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_deprebulanan", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("asset_stdepre", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("asset_eddepre", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("brand_id_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unit_id_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("show_id_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("project_id_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Gdg", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Lt", GetType(System.Int32)))

        tbl.Columns("terimabarang_id").DefaultValue = String.Empty
        tbl.Columns("asset_line").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("asset_tgl").DefaultValue = Now()
        tbl.Columns("tipeasset_id").DefaultValue = String.Empty
        tbl.Columns("kategoriasset_id").DefaultValue = String.Empty
        tbl.Columns("asset_barcode").DefaultValue = String.Empty
        tbl.Columns("asset_lineinduk").DefaultValue = 0
        tbl.Columns("asset_barcodeinduk").DefaultValue = String.Empty
        tbl.Columns("asset_serial").DefaultValue = String.Empty
        tbl.Columns("asset_produknumber").DefaultValue = String.Empty
        tbl.Columns("asset_model").DefaultValue = String.Empty
        tbl.Columns("asset_deskripsi").DefaultValue = String.Empty
        tbl.Columns("kategoriitem_id").DefaultValue = String.Empty
        tbl.Columns("tipeitem_id").DefaultValue = String.Empty
        tbl.Columns("asset_golfiskal").DefaultValue = String.Empty
        tbl.Columns("asset_tipedepre").DefaultValue = String.Empty
        tbl.Columns("asset_depre_enddt").DefaultValue = Now()
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("asset_harga").DefaultValue = 0
        tbl.Columns("asset_hargabaru").DefaultValue = 0
        tbl.Columns("asset_ppn").DefaultValue = 0
        tbl.Columns("asset_pph").DefaultValue = 0
        tbl.Columns("asset_disc").DefaultValue = 0
        tbl.Columns("asset_depresiasi").DefaultValue = 0
        tbl.Columns("asset_akum_val_depre").DefaultValue = 0
        tbl.Columns("asset_valas").DefaultValue = 0
        tbl.Columns("asset_idrprice").DefaultValue = 0
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("employee_id_owner").DefaultValue = String.Empty
        tbl.Columns("brand_id").DefaultValue = 0
        tbl.Columns("unit_id").DefaultValue = 0
        tbl.Columns("asset_qty").DefaultValue = 0
        tbl.Columns("material_id").DefaultValue = String.Empty
        tbl.Columns("warna_id").DefaultValue = String.Empty
        tbl.Columns("ukuran_id").DefaultValue = String.Empty
        tbl.Columns("jeniskelamin_id").DefaultValue = String.Empty
        tbl.Columns("show_id_cont_item").DefaultValue = String.Empty
        tbl.Columns("ruang_id").DefaultValue = String.Empty
        tbl.Columns("asset_rak").DefaultValue = String.Empty
        tbl.Columns("is_useable").DefaultValue = 0
        tbl.Columns("asset_active").DefaultValue = 0
        tbl.Columns("asset_status").DefaultValue = String.Empty
        tbl.Columns("project_id").DefaultValue = 0
        tbl.Columns("show_id").DefaultValue = String.Empty
        tbl.Columns("asset_eps").DefaultValue = String.Empty
        tbl.Columns("wo_id").DefaultValue = String.Empty
        tbl.Columns("inputby").DefaultValue = String.Empty
        tbl.Columns("inputdt").DefaultValue = Now()
        tbl.Columns("editby").DefaultValue = String.Empty
        tbl.Columns("editdt").DefaultValue = Now()
        tbl.Columns("usedby").DefaultValue = String.Empty
        tbl.Columns("asset_deprebulanan").DefaultValue = 0
        tbl.Columns("asset_stdepre").DefaultValue = Now()
        tbl.Columns("asset_eddepre").DefaultValue = Now()
        tbl.Columns("brand_id_string").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id_string").DefaultValue = String.Empty
        tbl.Columns("unit_id_string").DefaultValue = String.Empty
        tbl.Columns("show_id_string").DefaultValue = String.Empty
        tbl.Columns("project_id_string").DefaultValue = String.Empty
        tbl.Columns("employee_string").DefaultValue = String.Empty
        tbl.Columns("Gdg").DefaultValue = String.Empty
        tbl.Columns("Lt").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblTrnMaintenance() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("maintenance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("maintenance_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("maintenance_outin", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("maintenace_itemqty", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("maintenace_itemqtyret", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("employee_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("maintenance_indt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("maintenance_outdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("maintenance_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("maintenance_harga", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("maintenance_valas", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("maintenance_idrprice", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("maintenance_inputby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("maintenance_inputdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("maintenance_editby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("maintenance_editdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("maintenance_usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("maintenance_useddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("maintenance_outlock", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("maintenance_inclock", GetType(System.Byte)))

        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("maintenance_id").DefaultValue = String.Empty
        tbl.Columns("maintenance_type").DefaultValue = String.Empty
        tbl.Columns("maintenance_outin").DefaultValue = 0
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("maintenace_itemqty").DefaultValue = 0
        tbl.Columns("maintenace_itemqtyret").DefaultValue = 0
        tbl.Columns("employee_id").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("maintenance_indt").DefaultValue = Now()
        tbl.Columns("maintenance_outdt").DefaultValue = Now()
        tbl.Columns("maintenance_status").DefaultValue = String.Empty
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("maintenance_harga").DefaultValue = 0
        tbl.Columns("maintenance_valas").DefaultValue = 0
        tbl.Columns("maintenance_idrprice").DefaultValue = 0
        tbl.Columns("maintenance_inputby").DefaultValue = String.Empty
        tbl.Columns("maintenance_inputdt").DefaultValue = Now()
        tbl.Columns("maintenance_editby").DefaultValue = String.Empty
        tbl.Columns("maintenance_editdt").DefaultValue = Now()
        tbl.Columns("maintenance_usedby").DefaultValue = String.Empty
        tbl.Columns("maintenance_useddt").DefaultValue = Now()
        tbl.Columns("maintenance_outlock").DefaultValue = 0
        tbl.Columns("maintenance_inclock").DefaultValue = 0

        Return tbl
    End Function


    Public Shared Function CreateTblTrnMaintenancedetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("maintenance_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("maintenancedetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("maintenancedetil_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("maintenancedetil_outdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("maintenancedetil_statusout", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("maintenance_incdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("maintenancedetil_statusinc", GetType(System.String)))

        tbl.Columns("maintenance_id").DefaultValue = String.Empty
        tbl.Columns("maintenancedetil_line").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("maintenancedetil_barcode").DefaultValue = String.Empty
        tbl.Columns("maintenancedetil_outdate").DefaultValue = Now()
        tbl.Columns("maintenancedetil_statusout").DefaultValue = String.Empty
        tbl.Columns("maintenance_incdate").DefaultValue = Now()
        tbl.Columns("maintenancedetil_statusinc").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblTrnOrder() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_note", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_intref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_prognm", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_progsch", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("order_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_setdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_settime", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_setlocation", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_utilizeddatestart", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_utilizeddateend", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_utilizedtimestart", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_utilizedtimeend", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_utilizedlocation", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_pph_percent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_ppn_percent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_insurancecost", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_transportationcost", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_operatorcost", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_othercost", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_authname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_authposition", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_authname2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_authposition2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_canceled", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("order_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_createdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_modifyby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_modifydate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_discount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_source", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ordertype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_revno", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_revdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("order_revdesc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_approved", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_spkrequired", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("order_spkworktype", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_spkdesc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_dlvrname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_dlvraddr1", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_dlvraddr2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_dlvraddr3", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_dlvrtelp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_dlvrfax", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_dlvrhp", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("old_program_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("old_category_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("old_apref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_programtype", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_episodenum", GetType(System.Int16)))
        tbl.Columns.Add(New DataColumn("order_singlebudget", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("order_epsstart", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_epsend", GetType(System.Decimal)))

        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("order_date").DefaultValue = Now()
        tbl.Columns("order_descr").DefaultValue = String.Empty
        tbl.Columns("order_note").DefaultValue = String.Empty
        tbl.Columns("order_intref").DefaultValue = String.Empty
        tbl.Columns("request_id").DefaultValue = String.Empty
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("order_prognm").DefaultValue = String.Empty
        tbl.Columns("order_progsch").DefaultValue = String.Empty
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("order_eps").DefaultValue = String.Empty
        tbl.Columns("order_setdate").DefaultValue = Now()
        tbl.Columns("order_settime").DefaultValue = String.Empty
        tbl.Columns("order_setlocation").DefaultValue = String.Empty
        tbl.Columns("order_utilizeddatestart").DefaultValue = Now()
        tbl.Columns("order_utilizeddateend").DefaultValue = Now()
        tbl.Columns("order_utilizedtimestart").DefaultValue = String.Empty
        tbl.Columns("order_utilizedtimeend").DefaultValue = String.Empty
        tbl.Columns("order_utilizedlocation").DefaultValue = String.Empty
        tbl.Columns("order_pph_percent").DefaultValue = 0
        tbl.Columns("order_ppn_percent").DefaultValue = 0
        tbl.Columns("order_insurancecost").DefaultValue = 0
        tbl.Columns("order_transportationcost").DefaultValue = 0
        tbl.Columns("order_operatorcost").DefaultValue = 0
        tbl.Columns("order_othercost").DefaultValue = 0
        tbl.Columns("order_authname").DefaultValue = String.Empty
        tbl.Columns("order_authposition").DefaultValue = String.Empty
        tbl.Columns("order_authname2").DefaultValue = String.Empty
        tbl.Columns("order_authposition2").DefaultValue = String.Empty
        tbl.Columns("order_canceled").DefaultValue = 0
        tbl.Columns("order_createby").DefaultValue = String.Empty
        tbl.Columns("order_createdate").DefaultValue = Now()
        tbl.Columns("order_modifyby").DefaultValue = String.Empty
        tbl.Columns("order_modifydate").DefaultValue = Now()
        tbl.Columns("order_discount").DefaultValue = 0
        tbl.Columns("order_source").DefaultValue = String.Empty
        tbl.Columns("ordertype_id").DefaultValue = String.Empty
        tbl.Columns("order_revno").DefaultValue = String.Empty
        tbl.Columns("order_revdate").DefaultValue = Now()
        tbl.Columns("order_revdesc").DefaultValue = String.Empty
        tbl.Columns("order_approved").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("periode_id").DefaultValue = String.Empty
        tbl.Columns("order_spkrequired").DefaultValue = 0
        tbl.Columns("order_spkworktype").DefaultValue = String.Empty
        tbl.Columns("order_spkdesc").DefaultValue = String.Empty
        tbl.Columns("order_dlvrname").DefaultValue = String.Empty
        tbl.Columns("order_dlvraddr1").DefaultValue = String.Empty
        tbl.Columns("order_dlvraddr2").DefaultValue = String.Empty
        tbl.Columns("order_dlvraddr3").DefaultValue = String.Empty
        tbl.Columns("order_dlvrtelp").DefaultValue = String.Empty
        tbl.Columns("order_dlvrfax").DefaultValue = String.Empty
        tbl.Columns("order_dlvrhp").DefaultValue = String.Empty
        tbl.Columns("old_program_id").DefaultValue = 0
        tbl.Columns("old_category_id").DefaultValue = String.Empty
        tbl.Columns("old_apref").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("order_programtype").DefaultValue = String.Empty
        tbl.Columns("order_episodenum").DefaultValue = 0
        tbl.Columns("order_singlebudget").DefaultValue = 0
        tbl.Columns("order_epsstart").DefaultValue = 0
        tbl.Columns("order_epsend").DefaultValue = 0

        Return tbl
    End Function


    Public Shared Function CreateTblTrnOrderdetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("orderdetil_itemmigrasi", GetType(System.String)))
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
        tbl.Columns.Add(New DataColumn("orderdetil_qtyarrived", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_bpbj", GetType(System.Int16)))

        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_type").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("item_id").DefaultValue = String.Empty
        tbl.Columns("unit_id").DefaultValue = 0
        tbl.Columns("orderdetil_itemmigrasi").DefaultValue = String.Empty
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
        tbl.Columns("orderdetil_qtyarrived").DefaultValue = 0
        tbl.Columns("orderdetil_bpbj").DefaultValue = 0

        Return tbl
    End Function
    Public Shared Function CreateTblTrnEditing_Orderdetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Decimal)))
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
        tbl.Columns.Add(New DataColumn("old_orderdetil_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_pphpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_ppnpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_pphpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_ppnpercent", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_requestid_ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_line", GetType(System.Int64)))

        tbl.Columns.Add(New DataColumn("editing_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("shift1", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("shift2", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("shift3", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("orderdetil_eps", GetType(System.String)))

        'additional_viewonly
        tbl.Columns.Add(New DataColumn("category_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rodetil_rowtotalforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rodetil_rowtotalforeign_incldisc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rodetil_rowtotalidr_incldisc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("podetil_rowtotalforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("podetil_rowtotalforeign_incldisc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("podetil_rowtotalidr_incldisc", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("podetil_pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("podetil_ppn", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("podetil_rowtotalforeign_incltax", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("podetil_rowtotalidr_incltax", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("boot1", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("boot2", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("boot3", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("editor1", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("editor2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("editor3", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("order_id").DefaultValue = ""
        tbl.Columns("orderdetil_type").DefaultValue = ""
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("item_id").DefaultValue = ""
        tbl.Columns("unit_id").DefaultValue = 0
        tbl.Columns("orderdetil_descr").DefaultValue = ""
        tbl.Columns("orderdetil_qty").DefaultValue = 0
        tbl.Columns("orderdetil_days").DefaultValue = 0
        tbl.Columns("orderdetil_idr").DefaultValue = 0
        tbl.Columns("orderdetil_foreign").DefaultValue = 0
        tbl.Columns("orderdetil_foreignrate").DefaultValue = 0
        tbl.Columns("orderdetil_discount").DefaultValue = 0
        tbl.Columns("orderdetil_actual").DefaultValue = 0
        tbl.Columns("orderdetil_actualnote").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budgetaccount_id").DefaultValue = ""
        tbl.Columns("old_orderdetil_id").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("orderdetil_pphpercent").DefaultValue = 0
        tbl.Columns("orderdetil_ppnpercent").DefaultValue = 0
        tbl.Columns("amount_pphpercent").DefaultValue = 0
        tbl.Columns("amount_ppnpercent").DefaultValue = 0
        tbl.Columns("orderdetil_requestid_ref").DefaultValue = ""
        tbl.Columns("requestdetil_line").DefaultValue = 0

        'additional_viewonly
        tbl.Columns("category_name").DefaultValue = ""
        tbl.Columns("rodetil_rowtotalforeign").DefaultValue = 0
        tbl.Columns("rodetil_rowtotalforeign_incldisc").DefaultValue = 0
        tbl.Columns("rodetil_rowtotalidr_incldisc").DefaultValue = 0
        tbl.Columns("podetil_rowtotalforeign").DefaultValue = 0
        tbl.Columns("podetil_rowtotalforeign_incldisc").DefaultValue = 0
        tbl.Columns("podetil_rowtotalidr_incldisc").DefaultValue = 0

        tbl.Columns("podetil_pph").DefaultValue = 0
        tbl.Columns("podetil_ppn").DefaultValue = 0

        tbl.Columns("podetil_rowtotalforeign_incltax").DefaultValue = 0
        tbl.Columns("podetil_rowtotalidr_incltax").DefaultValue = 0

        tbl.Columns("editing_date").DefaultValue = Now()
        tbl.Columns("shift1").DefaultValue = 0
        tbl.Columns("shift2").DefaultValue = 0
        tbl.Columns("shift3").DefaultValue = 0
        tbl.Columns("orderdetil_eps").DefaultValue = String.Empty

        tbl.Columns("boot1").DefaultValue = 0
        tbl.Columns("boot2").DefaultValue = 0
        tbl.Columns("boot3").DefaultValue = 0
        tbl.Columns("editor1").DefaultValue = "0"
        tbl.Columns("editor2").DefaultValue = "0"
        tbl.Columns("editor3").DefaultValue = "0"
        Return tbl
    End Function
    Public Shared Function CreateTblTrnOrderdetilJasa() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("orderdetil_itemmigrasi", GetType(System.String)))
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
        tbl.Columns.Add(New DataColumn("orderdetil_qtyarrived", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("orderdetil_bpbj", GetType(System.Int16)))
        tbl.Columns.Add(New DataColumn("item_id_string", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("days_valid", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("order_utilizedtimestart", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_utilizedtimeend", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_epsstart", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_epsend", GetType(System.Decimal)))
        'Tambahan
        tbl.Columns.Add(New DataColumn("shift1", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("boot1", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("shift2", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("boot2", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("shift3", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("boot3", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("editing_date", GetType(System.DateTime)))
        


       
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_type").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("item_id").DefaultValue = String.Empty
        tbl.Columns("unit_id").DefaultValue = 0
        tbl.Columns("orderdetil_itemmigrasi").DefaultValue = String.Empty
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
        tbl.Columns("orderdetil_qtyarrived").DefaultValue = 0
        tbl.Columns("orderdetil_bpbj").DefaultValue = 0
        tbl.Columns("item_id_string").DefaultValue = String.Empty
        tbl.Columns("days_valid").DefaultValue = 0
        tbl.Columns("order_utilizedtimestart").DefaultValue = String.Empty
        tbl.Columns("order_utilizedtimeend").DefaultValue = String.Empty
        tbl.Columns("order_epsstart").DefaultValue = 0
        tbl.Columns("order_epsend").DefaultValue = 0
        'Tambahan
        tbl.Columns("shift1").DefaultValue = 0
        tbl.Columns("boot1").DefaultValue = 0
        tbl.Columns("shift2").DefaultValue = 0
        tbl.Columns("boot2").DefaultValue = 0
        tbl.Columns("shift3").DefaultValue = 0
        tbl.Columns("boot3").DefaultValue = 0
        tbl.Columns("editing_date").DefaultValue = Now.Date
        ' ''tbl.Columns("amount_forartist").DefaultValue = 0
        ' ''tbl.Columns("amount_pph21").DefaultValue = 0
        Return tbl
    End Function

    Public Shared Function CreateTblMstKategorijasa() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("category_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("category_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("group_id", GetType(System.String)))

        tbl.Columns("category_id").DefaultValue = String.Empty
        tbl.Columns("category_name").DefaultValue = String.Empty
        tbl.Columns("group_id").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblTrnBpb_procurement() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("appuser", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("appproc", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("vendor", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("qty_po", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("qty_bpb", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("notes", GetType(System.String)))

        tbl.Columns("appuser").DefaultValue = 0
        tbl.Columns("appproc").DefaultValue = 0
        tbl.Columns("terimabarang_id").DefaultValue = String.Empty
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("vendor").DefaultValue = String.Empty
        tbl.Columns("qty_po").DefaultValue = 0
        tbl.Columns("qty_bpb").DefaultValue = 0
        tbl.Columns("notes").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblTrnTerimabarangused() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimabarang_lineday", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("orderdetiluse_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimabarang_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimabarang_detilused_note", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_check", GetType(System.Byte)))


        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("terimabarang_id").DefaultValue = String.Empty
        tbl.Columns("terimabarang_line").DefaultValue = 0
        tbl.Columns("terimabarang_lineday").DefaultValue = 0
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("orderdetiluse_line").DefaultValue = 0
        tbl.Columns("terimabarang_dt").DefaultValue = Now()
        tbl.Columns("terimabarang_detilused_note").DefaultValue = String.Empty
        tbl.Columns("terimabarang_check").DefaultValue = 0


        Return tbl
    End Function

    Public Shared Function CreateTblBpjOrderSelect() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("vendor", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ordertype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_canceled", GetType(System.Byte)))

        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("status").DefaultValue = String.Empty
        tbl.Columns("vendor").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("ordertype_id").DefaultValue = String.Empty
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("terimabarang_id").DefaultValue = String.Empty
        tbl.Columns("order_canceled").DefaultValue = 0


        Return tbl
    End Function

    Public Shared Function CreateTblViewTrackingGoodRequestToBpj() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("GoodsRequest", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Department", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("EntryDate1", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("PrepareDate1", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("UseDateFrom1", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("UseDateUntil1", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("Line1", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("Item1", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Quantity1", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("ApprovedDateSpv", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("ApprovedSpvBy", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("circulation_GR_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("circulation_GR_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("PurchaseRentalRequest", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acara", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("EntryDate2", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("PrepareDate2", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("UseDateFrom2", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("UseDateUntil2", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("Line2", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("Item2", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Quantity2", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("ApprovedDateDept", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_approved1by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ApprovedDateDiv", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_approved2by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ApprovedDateProc", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("requestdetil_approvedprocby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ApprovedDateBMA", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("requestdetil_approvedbmaby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("PurchaseRentalOrder", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("EntryDate3", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("PrepareDate3", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("UseDateFrom3", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("UseDateUntil3", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("Line3", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("Item3", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("Quantity3", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("circulation_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("circulation_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderDelivery_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("orderDelivery_by", GetType(System.String)))

        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_tgl", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("ApprovedUser", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("user_applogin", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ApprovedSPV", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("procurement_applogin", GetType(System.String)))

        tbl.Columns("GoodsRequest").DefaultValue = String.Empty
        tbl.Columns("Department").DefaultValue = 0
        tbl.Columns("EntryDate1").DefaultValue = DBNull.Value
        tbl.Columns("PrepareDate1").DefaultValue = DBNull.Value
        tbl.Columns("UseDateFrom1").DefaultValue = DBNull.Value
        tbl.Columns("UseDateUntil1").DefaultValue = DBNull.Value
        tbl.Columns("Line1").DefaultValue = 0
        tbl.Columns("Item1").DefaultValue = String.Empty
        tbl.Columns("Quantity1").DefaultValue = 0
        tbl.Columns("ApprovedDateSpv").DefaultValue = DBNull.Value
        tbl.Columns("ApprovedSpvBy").DefaultValue = String.Empty
        tbl.Columns("circulation_GR_date").DefaultValue = DBNull.Value
        tbl.Columns("circulation_GR_by").DefaultValue = String.Empty
        tbl.Columns("PurchaseRentalRequest").DefaultValue = String.Empty
        tbl.Columns("acara").DefaultValue = String.Empty
        tbl.Columns("EntryDate2").DefaultValue = DBNull.Value
        tbl.Columns("PrepareDate2").DefaultValue = DBNull.Value
        tbl.Columns("UseDateFrom2").DefaultValue = DBNull.Value
        tbl.Columns("UseDateUntil2").DefaultValue = DBNull.Value
        tbl.Columns("Line2").DefaultValue = 0
        tbl.Columns("Item2").DefaultValue = String.Empty
        tbl.Columns("Quantity2").DefaultValue = 0
        tbl.Columns("ApprovedDateDept").DefaultValue = DBNull.Value
        tbl.Columns("request_approved1by").DefaultValue = String.Empty
        tbl.Columns("ApprovedDateDiv").DefaultValue = DBNull.Value
        tbl.Columns("request_approved2by").DefaultValue = String.Empty
        tbl.Columns("ApprovedDateProc").DefaultValue = DBNull.Value
        tbl.Columns("requestdetil_approvedprocby").DefaultValue = String.Empty
        tbl.Columns("ApprovedDateBMA").DefaultValue = DBNull.Value
        tbl.Columns("requestdetil_approvedbmaby").DefaultValue = String.Empty
        tbl.Columns("PurchaseRentalOrder").DefaultValue = String.Empty
        tbl.Columns("EntryDate3").DefaultValue = DBNull.Value
        tbl.Columns("PrepareDate3").DefaultValue = DBNull.Value
        tbl.Columns("UseDateFrom3").DefaultValue = DBNull.Value
        tbl.Columns("UseDateUntil3").DefaultValue = DBNull.Value
        tbl.Columns("Line3").DefaultValue = 0
        tbl.Columns("Item3").DefaultValue = String.Empty
        tbl.Columns("Quantity3").DefaultValue = 0
        tbl.Columns("circulation_date").DefaultValue = DBNull.Value
        tbl.Columns("circulation_by").DefaultValue = String.Empty
        tbl.Columns("orderDelivery_date").DefaultValue = DBNull.Value
        tbl.Columns("orderDelivery_by").DefaultValue = String.Empty
        tbl.Columns("terimabarang_id").DefaultValue = String.Empty
        tbl.Columns("terimabarang_tgl").DefaultValue = DBNull.Value
        tbl.Columns("ApprovedUser").DefaultValue = DBNull.Value
        tbl.Columns("user_applogin").DefaultValue = String.Empty
        tbl.Columns("ApprovedSPV").DefaultValue = DBNull.Value
        tbl.Columns("procurement_applogin").DefaultValue = String.Empty



        Return tbl
    End Function


#Region "Untuk Jurnal"
    Public Shared Function CreateTblTrnJurnal() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_bookdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_duedate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_billdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_invoice_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_invoice_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_source", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaltype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("periode_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_rate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("acc_ca_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advertiser_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ae_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnal_iscreated", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_iscreatedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_iscreatedate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_isposted", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_ispostedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_isposteddate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("jurnal_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("jurnal_isdisabledby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_isdisableddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("created_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("created_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modified_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modified_dt", GetType(System.DateTime)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnal_bookdate").DefaultValue = Now()
        tbl.Columns("jurnal_duedate").DefaultValue = Now()
        tbl.Columns("jurnal_billdate").DefaultValue = Now()
        tbl.Columns("jurnal_descr").DefaultValue = ""
        tbl.Columns("jurnal_invoice_id").DefaultValue = ""
        tbl.Columns("jurnal_invoice_descr").DefaultValue = ""
        tbl.Columns("jurnal_source").DefaultValue = ""
        tbl.Columns("jurnaltype_id").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("periode_id").DefaultValue = ""
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_rate").DefaultValue = 0
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("acc_ca_id").DefaultValue = 0
        tbl.Columns("region_id").DefaultValue = 0
        tbl.Columns("branch_id").DefaultValue = 0
        tbl.Columns("advertiser_id").DefaultValue = 0
        tbl.Columns("brand_id").DefaultValue = 0
        tbl.Columns("ae_id").DefaultValue = 0
        tbl.Columns("jurnal_iscreated").DefaultValue = 0
        tbl.Columns("jurnal_iscreatedby").DefaultValue = ""
        tbl.Columns("jurnal_iscreatedate").DefaultValue = Now()
        tbl.Columns("jurnal_isposted").DefaultValue = 0
        tbl.Columns("jurnal_ispostedby").DefaultValue = ""
        tbl.Columns("jurnal_isposteddate").DefaultValue = Now()
        tbl.Columns("jurnal_isdisabled").DefaultValue = 0
        tbl.Columns("jurnal_isdisabledby").DefaultValue = ""
        tbl.Columns("jurnal_isdisableddt").DefaultValue = Now()
        tbl.Columns("created_by").DefaultValue = ""
        tbl.Columns("created_dt").DefaultValue = Now()
        tbl.Columns("modified_by").DefaultValue = ""
        tbl.Columns("modified_dt").DefaultValue = Now()


        Return tbl
    End Function
    Public Shared Function CreateTblTrnJurnaldetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_dk", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("ref_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("ref_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("ref_budgetline", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_name", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("jurnaldetil_dk").DefaultValue = ""
        tbl.Columns("jurnaldetil_descr").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = "-- PILIH --"
        tbl.Columns("acc_id").DefaultValue = "0"
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreign").DefaultValue = 0
        tbl.Columns("jurnaldetil_foreignrate").DefaultValue = 0
        tbl.Columns("jurnaldetil_idr").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("ref_id").DefaultValue = ""
        tbl.Columns("ref_line").DefaultValue = 0
        tbl.Columns("ref_budgetline").DefaultValue = 0
        tbl.Columns("region_id").DefaultValue = 0
        tbl.Columns("branch_id").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budget_name").DefaultValue = "-- PILIH --"
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("budgetdetil_name").DefaultValue = "-- PILIH --"

        Return tbl
    End Function
    Public Shared Function CreateTblMstAcc() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_nameshort", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_isgroup", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("acc_parent", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_path", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_isdisabled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("acc_ismonetary", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("acc_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_createdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("accsubgroup_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("accaging_type", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("acc_id").DefaultValue = ""
        tbl.Columns("acc_name").DefaultValue = ""
        tbl.Columns("acc_nameshort").DefaultValue = ""
        tbl.Columns("acc_descr").DefaultValue = ""
        tbl.Columns("acc_isgroup").DefaultValue = 0
        tbl.Columns("acc_parent").DefaultValue = "0"
        tbl.Columns("acc_path").DefaultValue = ""
        tbl.Columns("acc_isdisabled").DefaultValue = 0
        tbl.Columns("acc_ismonetary").DefaultValue = 0
        tbl.Columns("acc_createby").DefaultValue = ""
        tbl.Columns("acc_createdate").DefaultValue = Now.Date()
        tbl.Columns("accsubgroup_id").DefaultValue = 0
        tbl.Columns("accaging_type").DefaultValue = ""

        Return tbl
    End Function

    Public Shared Function CreateTblJurnalReference() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("bookdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("foreigns", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        'tbl.Columns.Add(New DataColumn("referencetype", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("sub1_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("sub2_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("salesorder_ext_ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("salesorder_traffic_id", GetType(System.String)))
        'tbl.Columns.Add(New DataColumn("modifyby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_duedate", GetType(System.DateTime)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("ref").DefaultValue = ""
        tbl.Columns("line").DefaultValue = 0
        tbl.Columns("bookdate").DefaultValue = Now.Date
        tbl.Columns("descr").DefaultValue = ""
        tbl.Columns("idr").DefaultValue = 0
        tbl.Columns("foreigns").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("region_id").DefaultValue = "0"
        tbl.Columns("branch_id").DefaultValue = "0"
        tbl.Columns("strukturunit_id").DefaultValue = "0"
        tbl.Columns("rekanan_id").DefaultValue = 0
        'tbl.Columns("referencetype").DefaultValue = ""
        tbl.Columns("sub1_id").DefaultValue = "0"
        tbl.Columns("sub2_id").DefaultValue = "0"
        tbl.Columns("salesorder_ext_ref").DefaultValue = String.Empty
        tbl.Columns("salesorder_traffic_id").DefaultValue = String.Empty
        'tbl.Columns("modifyby").DefaultValue = ""
        tbl.Columns("jurnal_duedate").DefaultValue = Now.Date

        Return tbl
    End Function
    Public Shared Function CreateTblTrnJurnalreference() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("jurnal_id_ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnal_id_refline", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("jurnal_id_budgetline", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("referencetype", GetType(System.String)))

        tbl.Columns("jurnal_id").DefaultValue = String.Empty
        tbl.Columns("jurnaldetil_line").DefaultValue = 0
        tbl.Columns("jurnal_id_ref").DefaultValue = String.Empty
        tbl.Columns("jurnal_id_refline").DefaultValue = 0
        tbl.Columns("jurnal_id_budgetline").DefaultValue = 0
        tbl.Columns("referencetype").DefaultValue = String.Empty

        Return tbl
    End Function
    Public Shared Function CreateTblJurnalResponseRV() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("ref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("advancedetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advancedetil_foreignreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("advancedetil_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("book_dt", GetType(System.DateTime)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("ref").DefaultValue = ""
        tbl.Columns("line").DefaultValue = 0
        tbl.Columns("descr").DefaultValue = ""
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("currency_name").DefaultValue = ""
        tbl.Columns("advancedetil_foreignrate").DefaultValue = 0
        tbl.Columns("advancedetil_foreignreal").DefaultValue = 0
        tbl.Columns("advancedetil_idrreal").DefaultValue = 0
        tbl.Columns("strukturunit_id").DefaultValue = "0"
        tbl.Columns("strukturunit_name").DefaultValue = ""
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("book_dt").DefaultValue = DBNull.Value

        Return tbl
    End Function
#End Region
    'Public Shared Function CreateTblTrnRequest() As DataTable
    '    Dim tbl As DataTable = New DataTable

    '    tbl.Columns.Clear()
    '    tbl.Columns.Add(New DataColumn("request_id", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_idref", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_bookdt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("request_duedt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("request_preparedt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("request_prepareby", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_descr", GetType(System.String)))

    '    tbl.Columns.Add(New DataColumn("request_usedby", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_checkdt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("request_checkby", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_modifieddt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("request_modifiedby", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_postdt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("request_postby", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_formid", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("strukturunit_id_dest", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_useddt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("request_useddt2", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("request_acara", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_season", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_eps", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_prepareloc", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_usedloc", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_userpic", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_status", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_jurnalisposted", GetType(System.Byte)))
    '    tbl.Columns.Add(New DataColumn("request_jurnalsource", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("jurnaltype_id", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_regionid", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_brandid", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_sub1", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_sub2", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("periode_id", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("acctype_id", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_idr", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_foreignrate", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_foreign", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_entrydt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("request_entryby", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_idrreal", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_foreignratereal", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_foreignreal", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_idrsaldo", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_foreignratesaldo", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_foreignsaldo", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_mark", GetType(System.Byte)))
    '    tbl.Columns.Add(New DataColumn("request_pathfile", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_markasset", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_descrproc", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_amountadv", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_valasadv", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_apprauth", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_apprrev", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_apprreq", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_ordered", GetType(System.Byte)))
    '    tbl.Columns.Add(New DataColumn("request_programtype", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_epsstart", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_epsend", GetType(System.Decimal)))
    '    tbl.Columns.Add(New DataColumn("request_singlebudget", GetType(System.Byte)))
    '    tbl.Columns.Add(New DataColumn("request_approved1", GetType(System.Byte)))
    '    tbl.Columns.Add(New DataColumn("request_approved1dt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("request_approved1by", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_approved2", GetType(System.Byte)))
    '    tbl.Columns.Add(New DataColumn("request_approved2dt", GetType(System.DateTime)))
    '    tbl.Columns.Add(New DataColumn("request_approved2by", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_canceled", GetType(System.Byte)))
    '    tbl.Columns.Add(New DataColumn("request_reference", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_latereason", GetType(System.String)))
    '    tbl.Columns.Add(New DataColumn("request_approvedproc", GetType(System.Byte)))
    '    tbl.Columns.Add(New DataColumn("request_approvedbma", GetType(System.Byte)))
    '    tbl.Columns.Add(New DataColumn("request_timeremain", GetType(System.String)))

    '    tbl.Columns("request_id").DefaultValue = String.Empty
    '    tbl.Columns("request_idref").DefaultValue = String.Empty
    '    tbl.Columns("request_bookdt").DefaultValue = Now()
    '    tbl.Columns("request_duedt").DefaultValue = Now()
    '    tbl.Columns("request_preparedt").DefaultValue = Now()
    '    tbl.Columns("request_prepareby").DefaultValue = String.Empty
    '    tbl.Columns("request_descr").DefaultValue = String.Empty

    '    tbl.Columns("request_usedby").DefaultValue = String.Empty
    '    tbl.Columns("request_checkdt").DefaultValue = Now()
    '    tbl.Columns("request_checkby").DefaultValue = String.Empty
    '    tbl.Columns("request_modifieddt").DefaultValue = Now()
    '    tbl.Columns("request_modifiedby").DefaultValue = String.Empty
    '    tbl.Columns("request_postdt").DefaultValue = Now()
    '    tbl.Columns("request_postby").DefaultValue = String.Empty
    '    tbl.Columns("request_formid").DefaultValue = String.Empty
    '    tbl.Columns("strukturunit_id_dest").DefaultValue = 0
    '    tbl.Columns("request_useddt").DefaultValue = Now()
    '    tbl.Columns("request_useddt2").DefaultValue = Now()
    '    tbl.Columns("request_acara").DefaultValue = "0"
    '    tbl.Columns("request_season").DefaultValue = String.Empty
    '    tbl.Columns("request_eps").DefaultValue = String.Empty
    '    tbl.Columns("budget_id").DefaultValue = 0
    '    tbl.Columns("request_prepareloc").DefaultValue = String.Empty
    '    tbl.Columns("request_usedloc").DefaultValue = String.Empty
    '    tbl.Columns("request_userpic").DefaultValue = String.Empty
    '    tbl.Columns("request_status").DefaultValue = "BARU"
    '    tbl.Columns("request_jurnalisposted").DefaultValue = 0
    '    tbl.Columns("request_jurnalsource").DefaultValue = String.Empty
    '    tbl.Columns("jurnaltype_id").DefaultValue = String.Empty
    '    tbl.Columns("channel_id").DefaultValue = String.Empty
    '    tbl.Columns("request_regionid").DefaultValue = String.Empty
    '    tbl.Columns("request_brandid").DefaultValue = String.Empty
    '    tbl.Columns("strukturunit_id").DefaultValue = 0
    '    tbl.Columns("rekanan_id").DefaultValue = 0
    '    tbl.Columns("request_sub1").DefaultValue = 0
    '    tbl.Columns("request_sub2").DefaultValue = 0
    '    tbl.Columns("periode_id").DefaultValue = String.Empty
    '    tbl.Columns("acctype_id").DefaultValue = String.Empty
    '    tbl.Columns("request_idr").DefaultValue = 0
    '    tbl.Columns("currency_id").DefaultValue = 0
    '    tbl.Columns("request_foreignrate").DefaultValue = 1
    '    tbl.Columns("request_foreign").DefaultValue = 0
    '    tbl.Columns("request_entrydt").DefaultValue = Now()
    '    tbl.Columns("request_entryby").DefaultValue = String.Empty
    '    tbl.Columns("request_idrreal").DefaultValue = 0
    '    tbl.Columns("request_foreignratereal").DefaultValue = 0
    '    tbl.Columns("request_foreignreal").DefaultValue = 0
    '    tbl.Columns("request_idrsaldo").DefaultValue = 0
    '    tbl.Columns("request_foreignratesaldo").DefaultValue = 0
    '    tbl.Columns("request_foreignsaldo").DefaultValue = 0
    '    tbl.Columns("request_mark").DefaultValue = 0
    '    tbl.Columns("request_pathfile").DefaultValue = String.Empty
    '    tbl.Columns("request_markasset").DefaultValue = "ASSET"
    '    tbl.Columns("request_descrproc").DefaultValue = String.Empty
    '    tbl.Columns("request_amountadv").DefaultValue = 0
    '    tbl.Columns("request_valasadv").DefaultValue = 0
    '    tbl.Columns("request_apprauth").DefaultValue = 0
    '    tbl.Columns("request_apprrev").DefaultValue = 0
    '    tbl.Columns("request_apprreq").DefaultValue = 0
    '    tbl.Columns("request_ordered").DefaultValue = 0
    '    tbl.Columns("request_programtype").DefaultValue = String.Empty
    '    tbl.Columns("request_epsstart").DefaultValue = 0
    '    tbl.Columns("request_epsend").DefaultValue = 0
    '    tbl.Columns("request_singlebudget").DefaultValue = 1
    '    tbl.Columns("request_approved1").DefaultValue = 0
    '    tbl.Columns("request_approved1dt").DefaultValue = Now()
    '    tbl.Columns("request_approved1by").DefaultValue = String.Empty
    '    tbl.Columns("request_approved2").DefaultValue = 0
    '    tbl.Columns("request_approved2dt").DefaultValue = Now()
    '    tbl.Columns("request_approved2by").DefaultValue = String.Empty
    '    tbl.Columns("request_canceled").DefaultValue = 0
    '    tbl.Columns("request_reference").DefaultValue = String.Empty
    '    tbl.Columns("request_latereason").DefaultValue = String.Empty
    '    tbl.Columns("request_approvedproc").DefaultValue = 0
    '    tbl.Columns("request_approvedbma").DefaultValue = 0
    '    tbl.Columns("request_timeremain").DefaultValue = String.Empty

    '    Return tbl
    'End Function
    Public Shared Function CreateTblTrnRequestdetilEps() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("request_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_line", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_eps", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetiluse_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_objective", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("request_id").DefaultValue = String.Empty
        tbl.Columns("requestdetil_line").DefaultValue = 0
        tbl.Columns("requestdetil_eps").DefaultValue = 0
        tbl.Columns("requestdetiluse_descr").DefaultValue = String.Empty
        tbl.Columns("requestdetil_objective").DefaultValue = String.Empty

        Return tbl
    End Function


    Public Shared Function CreateTblRequestdetilSelect() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("request_id", GetType(System.String)))
        '
        tbl.Columns.Add(New DataColumn("request_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_descrproc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_bookdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_preparedt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_useddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_useddt2", GetType(System.DateTime)))
        '
        tbl.Columns.Add(New DataColumn("requestdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("requestdetil_nomor", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_seq", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_type", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_mother", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("requestdetil_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_seasons", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_days", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("region_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("branch_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_sub1", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_sub2", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_foreignreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_discount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_foreignratereal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_idrsaldo", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_foreignsaldo", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_foreignratesaldo", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_kategoriname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_itemdetilacct", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_itemdetilid", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_itemdescr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_condition", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("requestdetil_remark", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_amountbgt", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_valasbgt", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_needby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_needdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("requestdetil_Qtypo", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_bal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_idbgt", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_idbid", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_amountbid", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_valasbid", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_idpo", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_amountpo", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_valaspo", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("requestdetil_statusproc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_statusbma", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_approvedbma", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("requestdetil_approveddescr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_refreference", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_ordered", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("requestdetil_selected", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("requestdetil_added", GetType(System.Boolean)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("request_id").DefaultValue = ""
        '
        tbl.Columns("request_descr").DefaultValue = ""
        tbl.Columns("request_descrproc").DefaultValue = ""
        tbl.Columns("request_bookdt").DefaultValue = Now()
        tbl.Columns("request_preparedt").DefaultValue = Now()
        tbl.Columns("request_useddt").DefaultValue = Now()
        tbl.Columns("request_useddt2").DefaultValue = Now()
        '
        tbl.Columns("requestdetil_line").DefaultValue = 0
        tbl.Columns("requestdetil_nomor").DefaultValue = 0
        tbl.Columns("requestdetil_seq").DefaultValue = 0
        tbl.Columns("requestdetil_type").DefaultValue = 0
        tbl.Columns("requestdetil_mother").DefaultValue = 0
        tbl.Columns("item_id").DefaultValue = ""
        tbl.Columns("requestdetil_qty").DefaultValue = 0
        tbl.Columns("unit_id").DefaultValue = 0
        tbl.Columns("requestdetil_descr").DefaultValue = ""
        tbl.Columns("requestdetil_idr").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("requestdetil_foreign").DefaultValue = 0
        tbl.Columns("requestdetil_foreignrate").DefaultValue = 0
        tbl.Columns("requestdetil_seasons").DefaultValue = ""
        tbl.Columns("requestdetil_eps").DefaultValue = ""
        tbl.Columns("requestdetil_days").DefaultValue = 0
        tbl.Columns("acc_id").DefaultValue = ""
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("region_id").DefaultValue = ""
        tbl.Columns("branch_id").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("requestdetil_sub1").DefaultValue = 0
        tbl.Columns("requestdetil_sub2").DefaultValue = 0
        tbl.Columns("requestdetil_idrreal").DefaultValue = 0
        tbl.Columns("requestdetil_foreignreal").DefaultValue = 0
        tbl.Columns("requestdetil_discount").DefaultValue = 0
        tbl.Columns("requestdetil_foreignratereal").DefaultValue = 0
        tbl.Columns("requestdetil_idrsaldo").DefaultValue = 0
        tbl.Columns("requestdetil_foreignsaldo").DefaultValue = 0
        tbl.Columns("requestdetil_foreignratesaldo").DefaultValue = 0
        tbl.Columns("requestdetil_kategoriname").DefaultValue = ""
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("requestdetil_itemdetilacct").DefaultValue = 0
        tbl.Columns("requestdetil_itemdetilid").DefaultValue = ""
        tbl.Columns("requestdetil_itemdescr").DefaultValue = ""
        tbl.Columns("requestdetil_condition").DefaultValue = 0
        tbl.Columns("requestdetil_remark").DefaultValue = 0
        tbl.Columns("requestdetil_amountbgt").DefaultValue = 0
        tbl.Columns("requestdetil_valasbgt").DefaultValue = 0
        tbl.Columns("requestdetil_needby").DefaultValue = ""
        tbl.Columns("requestdetil_needdt").DefaultValue = Now()
        tbl.Columns("requestdetil_Qtypo").DefaultValue = 0
        tbl.Columns("requestdetil_bal").DefaultValue = 0
        tbl.Columns("currency_idbgt").DefaultValue = 0
        tbl.Columns("currency_idbid").DefaultValue = 0
        tbl.Columns("requestdetil_amountbid").DefaultValue = 0
        tbl.Columns("requestdetil_valasbid").DefaultValue = 0
        tbl.Columns("currency_idpo").DefaultValue = 0
        tbl.Columns("requestdetil_amountpo").DefaultValue = 0
        tbl.Columns("requestdetil_valaspo").DefaultValue = 0
        tbl.Columns("requestdetil_statusproc").DefaultValue = ""
        tbl.Columns("requestdetil_statusbma").DefaultValue = ""
        tbl.Columns("requestdetil_approvedbma").DefaultValue = 0
        tbl.Columns("requestdetil_approveddescr").DefaultValue = ""
        tbl.Columns("requestdetil_refreference").DefaultValue = ""
        tbl.Columns("requestdetil_ordered").DefaultValue = 0
        tbl.Columns("requestdetil_selected").DefaultValue = 0
        tbl.Columns("requestdetil_added").DefaultValue = 0

        Return tbl
    End Function
    Public Shared Function CreateTblMstArtis() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("code", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("address", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("sex", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("active", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("entry_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("entry_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modified_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modified_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("type_id", GetType(System.String)))

        tbl.Columns("code").DefaultValue = String.Empty
        tbl.Columns("name").DefaultValue = String.Empty
        tbl.Columns("address").DefaultValue = String.Empty
        tbl.Columns("sex").DefaultValue = String.Empty
        tbl.Columns("active").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("entry_by").DefaultValue = String.Empty
        tbl.Columns("entry_date").DefaultValue = Now()
        tbl.Columns("modified_by").DefaultValue = String.Empty
        tbl.Columns("modified_date").DefaultValue = Now()
        tbl.Columns("type_id").DefaultValue = String.Empty


        Return tbl
    End Function
    Public Shared Function CreateTblMstItem() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("item_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("item_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("category_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("category_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("group_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("group_name", GetType(System.String)))

        tbl.Columns("item_id").DefaultValue = String.Empty
        tbl.Columns("item_name").DefaultValue = String.Empty
        tbl.Columns("item_descr").DefaultValue = String.Empty
        tbl.Columns("category_id").DefaultValue = String.Empty
        tbl.Columns("category_name").DefaultValue = String.Empty
        tbl.Columns("group_id").DefaultValue = String.Empty
        tbl.Columns("group_name").DefaultValue = String.Empty

        Return tbl
    End Function
    Public Shared Function CreateTblMstItemcategory() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("category_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("category_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("group_id", GetType(System.String)))

        tbl.Columns("category_id").DefaultValue = String.Empty
        tbl.Columns("category_name").DefaultValue = String.Empty
        tbl.Columns("group_id").DefaultValue = String.Empty

        Return tbl
    End Function
    Public Shared Function CreateTblTrnTerimajasaepstalent() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimabarang_eps", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimabarang_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_check", GetType(System.Byte)))

        tbl.Columns("terimabarang_id").DefaultValue = String.Empty
        tbl.Columns("terimabarang_line").DefaultValue = 0
        tbl.Columns("terimabarang_eps").DefaultValue = 0
        tbl.Columns("terimabarang_descr").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("terimabarang_check").DefaultValue = 0

        Return tbl
    End Function
    Public Shared Function CreateTblTrnTerimajasaepsEditing() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimabarang_eps", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimabarang_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimabarang_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("shift1", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("shift2", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("shift3", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_check", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("eps_usage1_start", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("eps_usage1_end", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("eps_usage2_start", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("eps_usage2_end", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("eps_usage3_start", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("eps_usage3_end", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("eps_total_usage", GetType(System.Decimal)))


        tbl.Columns("terimabarang_id").DefaultValue = String.Empty
        tbl.Columns("terimabarang_line").DefaultValue = 0
        tbl.Columns("terimabarang_eps").DefaultValue = 0
        tbl.Columns("terimabarang_date").DefaultValue = Now()
        tbl.Columns("terimabarang_descr").DefaultValue = String.Empty
        tbl.Columns("shift1").DefaultValue = 0
        tbl.Columns("shift2").DefaultValue = 0
        tbl.Columns("shift3").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("terimabarang_check").DefaultValue = 0
        tbl.Columns("eps_usage1_start").DefaultValue = "00:00"
        tbl.Columns("eps_usage1_end").DefaultValue = "00:00"
        tbl.Columns("eps_usage2_start").DefaultValue = "00:00"
        tbl.Columns("eps_usage2_end").DefaultValue = "00:00"
        tbl.Columns("eps_usage3_start").DefaultValue = "00:00"
        tbl.Columns("eps_usage3_end").DefaultValue = "00:00"
        tbl.Columns("eps_total_usage").DefaultValue = 0


        Return tbl
    End Function
    Public Shared Function CreateTblTrnTerimajasausededitingeps() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimajasa_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("orderdetiluse_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasause_check", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasause_eps", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasause_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))

        tbl.Columns("terimajasa_id").DefaultValue = String.Empty
        tbl.Columns("terimajasadetil_line").DefaultValue = 0
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("orderdetiluse_line").DefaultValue = 0
        tbl.Columns("terimajasause_check").DefaultValue = 0
        tbl.Columns("terimajasause_eps").DefaultValue = 0
        tbl.Columns("terimajasause_descr").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblTrnTerimajasa() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimajasa_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_owner", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        'tbl.Columns.Add(New DataColumn("terimajasa_qtyitem", GetType(System.Int32)))
        'tbl.Columns.Add(New DataColumn("terimajasa_qtyrealization", GetType(System.Int32)))
        'tbl.Columns.Add(New DataColumn("order_qty", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasa_qtyitem", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_qtyrealization", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_qty", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("terimajasa_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_statusrealization", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_location", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_notes", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_nosuratjalan", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_isdisabled", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasa_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_createdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_modifiedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_modifieddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_appuser", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasa_appuser_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_appuser_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_appspv", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasa_appspv_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_appspv_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_appbma", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasa_appbma_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_appbma_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_ppn", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_cetakbpj", GetType(System.Int32)))

        'view
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))


        tbl.Columns("terimajasa_id").DefaultValue = String.Empty
        tbl.Columns("terimajasa_date").DefaultValue = Now()
        tbl.Columns("terimajasa_type").DefaultValue = String.Empty
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("employee_id_owner").DefaultValue = DBNull.Value
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("terimajasa_qtyitem").DefaultValue = 0
        tbl.Columns("terimajasa_qtyrealization").DefaultValue = 0
        tbl.Columns("order_qty").DefaultValue = 0
        tbl.Columns("terimajasa_status").DefaultValue = String.Empty
        tbl.Columns("terimajasa_statusrealization").DefaultValue = String.Empty
        tbl.Columns("terimajasa_location").DefaultValue = String.Empty
        tbl.Columns("terimajasa_notes").DefaultValue = String.Empty
        tbl.Columns("terimajasa_nosuratjalan").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("terimajasa_isdisabled").DefaultValue = 0
        tbl.Columns("terimajasa_createby").DefaultValue = String.Empty
        tbl.Columns("terimajasa_createdt").DefaultValue = Now()
        tbl.Columns("terimajasa_modifiedby").DefaultValue = String.Empty
        tbl.Columns("terimajasa_modifieddt").DefaultValue = Now()
        tbl.Columns("terimajasa_appuser").DefaultValue = 0
        tbl.Columns("terimajasa_appuser_by").DefaultValue = String.Empty
        tbl.Columns("terimajasa_appuser_dt").DefaultValue = Now()
        tbl.Columns("terimajasa_appspv").DefaultValue = 0
        tbl.Columns("terimajasa_appspv_by").DefaultValue = String.Empty
        tbl.Columns("terimajasa_appspv_dt").DefaultValue = Now()
        tbl.Columns("terimajasa_appbma").DefaultValue = 0
        tbl.Columns("terimajasa_appbma_by").DefaultValue = String.Empty
        tbl.Columns("terimajasa_appbma_dt").DefaultValue = Now()
        tbl.Columns("terimajasa_foreign").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("terimajasa_foreignrate").DefaultValue = 0
        tbl.Columns("terimajasa_idrreal").DefaultValue = 0
        tbl.Columns("terimajasa_pph").DefaultValue = 0
        tbl.Columns("terimajasa_ppn").DefaultValue = 0
        tbl.Columns("terimajasa_disc").DefaultValue = 0
        tbl.Columns("terimajasa_cetakbpj").DefaultValue = 0

        'view
        tbl.Columns("rekanan_name").DefaultValue = String.Empty
        tbl.Columns("employee_name").DefaultValue = String.Empty
        tbl.Columns("budget_name").DefaultValue = String.Empty

        Return tbl
    End Function
    Public Shared Function CreateTblTrnTerimajasadetil() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimajasa_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_desc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_date", GetType(System.DateTime)))
        'tbl.Columns.Add(New DataColumn("terimajasadetil_qty", GetType(System.Int32)))
        'tbl.Columns.Add(New DataColumn("terimajasadetil_qty_day_eps", GetType(System.Int32)))
        'tbl.Columns.Add(New DataColumn("terimajasadetil_qty_usage", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_qty_day_eps", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_qty_usage", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("item_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("budgetdetil_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_createdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_modifiedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_modifieddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("type_pajak", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("kategori_pajak", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_pphpersen", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_ppnpersen", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_pphforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_pphidrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_ppnforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_ppnidrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_totalforeign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasadetil_totalidrreal", GetType(System.Decimal)))

        'Khusus View di Rental ajah
        tbl.Columns.Add(New DataColumn("terimajasadetil_qty_usage_idle", GetType(System.Int32)))

        ''''tbl.Columns.Add(New DataColumn("amount_artis", GetType(System.Decimal)))

        tbl.Columns("terimajasa_id").DefaultValue = String.Empty
        tbl.Columns("terimajasadetil_line").DefaultValue = 0
        tbl.Columns("terimajasadetil_desc").DefaultValue = String.Empty
        tbl.Columns("terimajasadetil_date").DefaultValue = Now()
        tbl.Columns("terimajasadetil_qty").DefaultValue = 0
        tbl.Columns("terimajasadetil_qty_day_eps").DefaultValue = 0
        tbl.Columns("terimajasadetil_qty_usage").DefaultValue = 0
        tbl.Columns("terimajasadetil_type").DefaultValue = String.Empty
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("item_id").DefaultValue = String.Empty
        tbl.Columns("kategoriitem_id").DefaultValue = String.Empty
        tbl.Columns("brand_id").DefaultValue = 0
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("budgetdetil_id").DefaultValue = 0
        tbl.Columns("acc_id").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("terimajasadetil_createby").DefaultValue = String.Empty
        tbl.Columns("terimajasadetil_createdt").DefaultValue = Now()
        tbl.Columns("terimajasadetil_modifiedby").DefaultValue = String.Empty
        tbl.Columns("terimajasadetil_modifieddt").DefaultValue = Now()
        tbl.Columns("type_pajak").DefaultValue = 0
        tbl.Columns("kategori_pajak").DefaultValue = 0
        tbl.Columns("terimajasadetil_foreign").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("terimajasadetil_foreignrate").DefaultValue = 0
        tbl.Columns("terimajasadetil_idrreal").DefaultValue = 0
        tbl.Columns("terimajasadetil_pphpersen").DefaultValue = 0
        tbl.Columns("terimajasadetil_ppnpersen").DefaultValue = 0
        tbl.Columns("terimajasadetil_disc").DefaultValue = 0
        tbl.Columns("terimajasadetil_pphforeign").DefaultValue = 0
        tbl.Columns("terimajasadetil_pphidrreal").DefaultValue = 0
        tbl.Columns("terimajasadetil_ppnforeign").DefaultValue = 0
        tbl.Columns("terimajasadetil_ppnidrreal").DefaultValue = 0
        tbl.Columns("terimajasadetil_totalforeign").DefaultValue = 0
        tbl.Columns("terimajasadetil_totalidrreal").DefaultValue = 0

        'Khusus View di Rental ajah
        tbl.Columns("terimajasadetil_qty_usage_idle").DefaultValue = 0


        '''' tbl.Columns("amount_artis").DefaultValue = 0

        Return tbl
    End Function
    Public Shared Function CreateTblTrnTerimajasaused() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasa_lineday", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("orderdetiluse_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasa_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_detilused_note", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_check", GetType(System.Byte)))
        'tbl.Columns.Add(New DataColumn("terimajasaused_qty", GetType(System.Int32)))
        'tbl.Columns.Add(New DataColumn("terimajasaused_qty_idle", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasaused_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasaused_qty_idle", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasaused_usagestart", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasaused_usgaeend", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasaused_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasaused_remark", GetType(System.String)))

        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("terimajasa_id").DefaultValue = String.Empty
        tbl.Columns("terimajasa_line").DefaultValue = 0
        tbl.Columns("terimajasa_lineday").DefaultValue = 0
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("orderdetiluse_line").DefaultValue = 0
        tbl.Columns("terimajasa_date").DefaultValue = Now()
        tbl.Columns("terimajasa_detilused_note").DefaultValue = String.Empty
        tbl.Columns("terimajasa_check").DefaultValue = 0
        tbl.Columns("terimajasaused_qty").DefaultValue = 0
        tbl.Columns("terimajasaused_qty_idle").DefaultValue = 0
        tbl.Columns("terimajasaused_usagestart").DefaultValue = String.Empty
        tbl.Columns("terimajasaused_usgaeend").DefaultValue = String.Empty
        tbl.Columns("terimajasaused_status").DefaultValue = String.Empty
        tbl.Columns("terimajasaused_remark").DefaultValue = String.Empty

        Return tbl
    End Function
    Public Shared Function CreateTblTrnTerimajasausedTalent() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasa_lineeps", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("orderdetiluse_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasa_eps", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasaused_check", GetType(System.Byte)))
        'tbl.Columns.Add(New DataColumn("terimajasaused_qty", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasaused_qty", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasaused_descr", GetType(System.String)))

        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("terimajasa_id").DefaultValue = String.Empty
        tbl.Columns("terimajasa_line").DefaultValue = 0
        tbl.Columns("terimajasa_lineeps").DefaultValue = 0
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("orderdetiluse_line").DefaultValue = 0
        tbl.Columns("terimajasa_eps").DefaultValue = 0
        tbl.Columns("terimajasaused_check").DefaultValue = 0
        tbl.Columns("terimajasaused_qty").DefaultValue = 0
        tbl.Columns("terimajasaused_descr").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblTrnTerimajasausedediting() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasaused_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("shift1", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("shift2", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("shift3", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasaused_check", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("boot1", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("boot2", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("boot3", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("orderdetiluse_line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasaused_usage1_start", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasaused_usage1_end", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasaused_usage2_start", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasaused_usage2_end", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasaused_usage3_start", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasaused_usage3_end", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasaused_usagetotal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasaused_usageepstotal", GetType(System.Int32)))

        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("terimajasa_id").DefaultValue = String.Empty
        tbl.Columns("terimajasa_line").DefaultValue = 0
        tbl.Columns("terimajasaused_date").DefaultValue = Now()
        tbl.Columns("terimajasa_descr").DefaultValue = String.Empty
        tbl.Columns("shift1").DefaultValue = 0
        tbl.Columns("shift2").DefaultValue = 0
        tbl.Columns("shift3").DefaultValue = 0
        tbl.Columns("terimajasaused_check").DefaultValue = 0
        tbl.Columns("boot1").DefaultValue = 0
        tbl.Columns("boot2").DefaultValue = 0
        tbl.Columns("boot3").DefaultValue = 0
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("orderdetiluse_line").DefaultValue = 0
        tbl.Columns("terimajasaused_usage1_start").DefaultValue = String.Empty
        tbl.Columns("terimajasaused_usage1_end").DefaultValue = String.Empty
        tbl.Columns("terimajasaused_usage2_start").DefaultValue = String.Empty
        tbl.Columns("terimajasaused_usage2_end").DefaultValue = String.Empty
        tbl.Columns("terimajasaused_usage3_start").DefaultValue = String.Empty
        tbl.Columns("terimajasaused_usage3_end").DefaultValue = String.Empty
        tbl.Columns("terimajasaused_usagetotal").DefaultValue = 0
        tbl.Columns("terimajasaused_usageepstotal").DefaultValue = 0

        Return tbl
    End Function
    Public Shared Function CreateTblMstrekananCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanantype_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_active", GetType(System.Decimal)))


        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("rekanan_name").DefaultValue = String.Empty
        tbl.Columns("rekanantype_id").DefaultValue = 0
        tbl.Columns("rekanan_active").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblMstAccountCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_nameshort", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_isdisabled", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("acc_isgroup", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("acc_name", GetType(String)))

        tbl.Columns("acc_id").DefaultValue = String.Empty
        tbl.Columns("acc_nameshort").DefaultValue = String.Empty
        tbl.Columns("acc_isdisabled").DefaultValue = 0
        tbl.Columns("acc_isgroup").DefaultValue = 0
        tbl.Columns("acc_name").DefaultValue = ""

        Return tbl
    End Function

    Public Shared Function CreateTblMstPajak_type() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("code_pajak", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("pajak_name", GetType(System.String)))

        tbl.Columns("code_pajak").DefaultValue = 0
        tbl.Columns("pajak_name").DefaultValue = String.Empty

        Return tbl
    End Function
    Public Shared Function CreateTblMstPajakKategori() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("category_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("category_name", GetType(System.String)))

        tbl.Columns("category_id").DefaultValue = 0
        tbl.Columns("category_name").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblMstPeriode() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("periode_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_datestart", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("periode_dateend", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("periode_isclosed", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("periode_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_createdate", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("periode_allowsaldoawalentry", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("periode_id").DefaultValue = ""
        tbl.Columns("periode_name").DefaultValue = ""
        tbl.Columns("periode_datestart").DefaultValue = Now()
        tbl.Columns("periode_dateend").DefaultValue = Now()
        tbl.Columns("periode_isclosed").DefaultValue = 0
        tbl.Columns("periode_createby").DefaultValue = ""
        tbl.Columns("periode_createdate").DefaultValue = Now()
        tbl.Columns("periode_allowsaldoawalentry").DefaultValue = 0
        tbl.Columns("channel_id").DefaultValue = ""


        Return tbl
    End Function

    Public Shared Function CreateTblMstPeriodeCombo() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("periode_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("periode_datestart", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("periode_dateend", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("periode_isclosed", GetType(System.Boolean)))
        '-------------------------------
        'Default Value: 
        tbl.Columns("periode_id").DefaultValue = ""
        tbl.Columns("periode_name").DefaultValue = ""
        tbl.Columns("periode_datestart").DefaultValue = Now()
        tbl.Columns("periode_dateend").DefaultValue = Now()
        tbl.Columns("periode_isclosed").DefaultValue = False
        Return tbl
    End Function

    Public Shared Function CreateTblViewContractSrtis() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("request_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("requestdetil_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("id_legal", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("contract_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("total", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("app_legal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("app_legalby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("app_legaldt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("app_artis", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("app_artisby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("app_artisdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("app_dept", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("app_deptby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("app_deptdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("app_finance", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("app_financeby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("app_financedt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("artis_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("eps_start", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("eps_end", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("episode_list", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("shooting_startdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("shooting_enddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("shooting_list", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0
        tbl.Columns("request_id").DefaultValue = String.Empty
        tbl.Columns("requestdetil_line").DefaultValue = 0
        tbl.Columns("id_legal").DefaultValue = String.Empty
        tbl.Columns("contract_id").DefaultValue = String.Empty
        tbl.Columns("total").DefaultValue = 0
        tbl.Columns("app_legal").DefaultValue = 0
        tbl.Columns("app_legalby").DefaultValue = String.Empty
        tbl.Columns("app_legaldt").DefaultValue = DBNull.Value
        tbl.Columns("app_artis").DefaultValue = 0
        tbl.Columns("app_artisby").DefaultValue = String.Empty
        tbl.Columns("app_artisdt").DefaultValue = DBNull.Value
        tbl.Columns("app_dept").DefaultValue = 0
        tbl.Columns("app_deptby").DefaultValue = String.Empty
        tbl.Columns("app_deptdt").DefaultValue = DBNull.Value
        tbl.Columns("app_finance").DefaultValue = 0
        tbl.Columns("app_financeby").DefaultValue = String.Empty
        tbl.Columns("app_financedt").DefaultValue = DBNull.Value
        tbl.Columns("artis_name").DefaultValue = String.Empty
        tbl.Columns("eps_start").DefaultValue = 0
        tbl.Columns("eps_end").DefaultValue = 0
        tbl.Columns("episode_list").DefaultValue = String.Empty
        tbl.Columns("shooting_startdt").DefaultValue = DBNull.Value
        tbl.Columns("shooting_enddt").DefaultValue = DBNull.Value
        tbl.Columns("shooting_list").DefaultValue = String.Empty

        Return tbl
    End Function

    Public Shared Function CreateTblMstArtisDetilPPH21() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("code", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("line", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("category_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("code_pajak", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_tax", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("subtotal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("grand_total", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("amount_forartist", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("entry_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("entry_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modified_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modified_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("persen", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("sisa", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("total_amount_pertahun", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("persen_tahun", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("orderdetil_line", GetType(System.Int32)))

        tbl.Columns("code").DefaultValue = String.Empty
        tbl.Columns("line").DefaultValue = 0
        tbl.Columns("category_id").DefaultValue = 0
        tbl.Columns("code_pajak").DefaultValue = 0
        tbl.Columns("amount").DefaultValue = 0
        tbl.Columns("amount_tax").DefaultValue = 0
        tbl.Columns("subtotal").DefaultValue = 0
        tbl.Columns("grand_total").DefaultValue = 0
        tbl.Columns("amount_forartist").DefaultValue = 0
        tbl.Columns("entry_date").DefaultValue = Now()
        tbl.Columns("entry_by").DefaultValue = String.Empty
        tbl.Columns("modified_date").DefaultValue = Now()
        tbl.Columns("modified_by").DefaultValue = String.Empty
        tbl.Columns("persen").DefaultValue = 0
        tbl.Columns("sisa").DefaultValue = 0
        tbl.Columns("total_amount_pertahun").DefaultValue = 0
        tbl.Columns("persen_tahun").DefaultValue = 0
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("orderdetil_line").DefaultValue = 0

        Return tbl
    End Function

    '===================ADD PTS 20130423 ================================
    Public Shared Function CreateTblTrnTerimajasaTalent() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("terimajasa_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("employee_id_owner", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        'tbl.Columns.Add(New DataColumn("terimajasa_qtyitem", GetType(System.Int32)))
        'tbl.Columns.Add(New DataColumn("terimajasa_qtyrealization", GetType(System.Int32)))
        'tbl.Columns.Add(New DataColumn("order_qty", GetType(System.Int32)))
        tbl.Columns.Add(New DataColumn("terimajasa_qtyitem", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_qtyrealization", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_qty", GetType(System.Decimal)))

        tbl.Columns.Add(New DataColumn("terimajasa_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_statusrealization", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_location", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_notes", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_nosuratjalan", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_isdisabled", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasa_createby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_createdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_modifiedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_modifieddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_appuser", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasa_appuser_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_appuser_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_appspv", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasa_appspv_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_appspv_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_appbma", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasa_appbma_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_appbma_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("terimajasa_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_pph", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_ppn", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_disc", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_cetakbpj", GetType(System.Int32)))

        'view
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("employee_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))

        'Add
        tbl.Columns.Add(New DataColumn("terimajasa_bmacek", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasa_bmacek_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_bmacek_date", GetType(System.DateTime)))


        tbl.Columns("terimajasa_id").DefaultValue = String.Empty
        tbl.Columns("terimajasa_date").DefaultValue = Now()
        tbl.Columns("terimajasa_type").DefaultValue = String.Empty
        tbl.Columns("order_id").DefaultValue = String.Empty
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("employee_id_owner").DefaultValue = DBNull.Value
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("terimajasa_qtyitem").DefaultValue = 0
        tbl.Columns("terimajasa_qtyrealization").DefaultValue = 0
        tbl.Columns("order_qty").DefaultValue = 0
        tbl.Columns("terimajasa_status").DefaultValue = String.Empty
        tbl.Columns("terimajasa_statusrealization").DefaultValue = String.Empty
        tbl.Columns("terimajasa_location").DefaultValue = String.Empty
        tbl.Columns("terimajasa_notes").DefaultValue = String.Empty
        tbl.Columns("terimajasa_nosuratjalan").DefaultValue = String.Empty
        tbl.Columns("channel_id").DefaultValue = String.Empty
        tbl.Columns("terimajasa_isdisabled").DefaultValue = 0
        tbl.Columns("terimajasa_createby").DefaultValue = String.Empty
        tbl.Columns("terimajasa_createdt").DefaultValue = Now()
        tbl.Columns("terimajasa_modifiedby").DefaultValue = String.Empty
        tbl.Columns("terimajasa_modifieddt").DefaultValue = Now()
        tbl.Columns("terimajasa_appuser").DefaultValue = 0
        tbl.Columns("terimajasa_appuser_by").DefaultValue = String.Empty
        tbl.Columns("terimajasa_appuser_dt").DefaultValue = Now()
        tbl.Columns("terimajasa_appspv").DefaultValue = 0
        tbl.Columns("terimajasa_appspv_by").DefaultValue = String.Empty
        tbl.Columns("terimajasa_appspv_dt").DefaultValue = Now()
        tbl.Columns("terimajasa_appbma").DefaultValue = 0
        tbl.Columns("terimajasa_appbma_by").DefaultValue = String.Empty
        tbl.Columns("terimajasa_appbma_dt").DefaultValue = Now()
        tbl.Columns("terimajasa_foreign").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("terimajasa_foreignrate").DefaultValue = 0
        tbl.Columns("terimajasa_idrreal").DefaultValue = 0
        tbl.Columns("terimajasa_pph").DefaultValue = 0
        tbl.Columns("terimajasa_ppn").DefaultValue = 0
        tbl.Columns("terimajasa_disc").DefaultValue = 0
        tbl.Columns("terimajasa_cetakbpj").DefaultValue = 0

        'view
        tbl.Columns("rekanan_name").DefaultValue = String.Empty
        tbl.Columns("employee_name").DefaultValue = String.Empty
        tbl.Columns("budget_name").DefaultValue = String.Empty

        'Add
        tbl.Columns("terimajasa_bmacek").DefaultValue = 0
        tbl.Columns("terimajasa_bmacek_by").DefaultValue = String.Empty
        tbl.Columns("terimajasa_bmacek_date").DefaultValue = Now()

        Return tbl
    End Function

    Public Shared Function CreateTblTrnTerimajasa_BMACek() As DataTable
        Dim tbl As DataTable = New DataTable
        'Add
        tbl.Columns.Add(New DataColumn("terimajasa_bmacek", GetType(System.Byte)))
        tbl.Columns.Add(New DataColumn("terimajasa_bmacek_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_bmacek_date", GetType(System.DateTime)))
        'Add
        tbl.Columns("terimajasa_bmacek").DefaultValue = 0
        tbl.Columns("terimajasa_bmacek_by").DefaultValue = String.Empty
        tbl.Columns("terimajasa_bmacek_date").DefaultValue = Now()
        Return tbl
    End Function

    Public Shared Function CreateTblMstAssetconsumable() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_serial", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_description", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("category_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("brand_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("tipeitem_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("asset_totalqty", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_price", GetType(System.Decimal)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("asset_serial").DefaultValue = ""
        tbl.Columns("asset_description").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("category_id").DefaultValue = ""
        tbl.Columns("brand_id").DefaultValue = 0
        tbl.Columns("tipeitem_id").DefaultValue = ""
        tbl.Columns("asset_totalqty").DefaultValue = 0
        tbl.Columns("asset_price").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblTrnJurnaldetildepre() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("jurnal_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaldetildepre_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("terimabarang_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimabarang_line", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("asset_barcode", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("depresiasi_depremonth", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("create_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("create_dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("modify_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modify_dt", GetType(System.DateTime)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("jurnal_id").DefaultValue = ""
        tbl.Columns("jurnaldetildepre_line").DefaultValue = 0
        tbl.Columns("terimabarang_id").DefaultValue = ""
        tbl.Columns("terimabarang_line").DefaultValue = 0
        tbl.Columns("asset_barcode").DefaultValue = ""
        tbl.Columns("kategoriasset_id").DefaultValue = ""
        tbl.Columns("depresiasi_depremonth").DefaultValue = 0
        tbl.Columns("create_by").DefaultValue = ""
        tbl.Columns("create_dt").DefaultValue = Now()
        tbl.Columns("modify_by").DefaultValue = ""
        tbl.Columns("modify_dt").DefaultValue = Now()


        Return tbl
    End Function

    Public Shared Function CreateTblViewTrnJurnaldetildepre() As DataTable
        Dim tbl As DataTable = clsDataset.CreateTblTrnJurnaldetildepre()

        tbl.Columns.Add("asset_deskripsi", GetType(String)).DefaultValue = ""

        Return tbl
    End Function

    Public Shared Function CreateTblViewTrnJurnaldetildisposal() As DataTable
        Dim tbl As New DataTable

        tbl.Columns.Add("jurnal_id", GetType(String))
        tbl.Columns.Add("jurnaldetil_line", GetType(Integer))
        tbl.Columns.Add("asset_barcode", GetType(String))
        tbl.Columns.Add("asset_deskripsi", GetType(String))
        tbl.Columns.Add("kategoriasset_id", GetType(String))
        tbl.Columns.Add("created_by", GetType(String))
        tbl.Columns.Add("create_dt", GetType(Date))
        tbl.Columns.Add("jurnal_isposted", GetType(Boolean))
        tbl.Columns.Add("jurnal_ispostedby", GetType(String))
        tbl.Columns.Add("jurnal_isposteddt", GetType(String))

        Return tbl
    End Function

    Public Shared Function CreateTblTrnRequest() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("request_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_idref", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_bookdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_duedt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_preparedt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_prepareby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_usedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_checkdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_checkby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_modifieddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_modifiedby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_postdt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_postby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_formid", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id_dest", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_useddt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_useddt2", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_acara", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_season", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_eps", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_prepareloc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_usedloc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_userpic", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_jurnalisposted", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("request_jurnalsource", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("jurnaltype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("channel_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_regionid", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_brandid", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_sub1", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_sub2", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("periode_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acctype_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_idr", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("currency_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_foreignrate", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_foreign", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_entrydt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_entryby", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_idrreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_foreignratereal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_foreignreal", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_idrsaldo", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_foreignratesaldo", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_foreignsaldo", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_mark", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("request_pathfile", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_markasset", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_descrproc", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_amountadv", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_valasadv", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_apprauth", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_apprrev", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_apprreq", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_ordered", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("request_programtype", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_epsstart", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_epsend", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("request_singlebudget", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("request_approved1", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("request_approved1dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_approved1by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_approved2", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("request_approved2dt", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("request_approved2by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_canceled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("request_reference", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("request_latereason", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("receivedDoc_by", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("receivedDoc_date", GetType(System.DateTime)))
        tbl.Columns.Add(New DataColumn("receivedDoc_app", GetType(System.Boolean)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("request_id").DefaultValue = ""
        tbl.Columns("request_idref").DefaultValue = ""
        tbl.Columns("request_bookdt").DefaultValue = Now()
        tbl.Columns("request_duedt").DefaultValue = Now()
        tbl.Columns("request_preparedt").DefaultValue = Now()
        tbl.Columns("request_prepareby").DefaultValue = ""
        tbl.Columns("request_descr").DefaultValue = ""
        tbl.Columns("request_usedby").DefaultValue = ""
        tbl.Columns("request_checkdt").DefaultValue = Now()
        tbl.Columns("request_checkby").DefaultValue = ""
        tbl.Columns("request_modifieddt").DefaultValue = Now()
        tbl.Columns("request_modifiedby").DefaultValue = ""
        tbl.Columns("request_postdt").DefaultValue = Now()
        tbl.Columns("request_postby").DefaultValue = ""
        tbl.Columns("request_formid").DefaultValue = ""
        tbl.Columns("strukturunit_id_dest").DefaultValue = 0
        tbl.Columns("request_useddt").DefaultValue = Now()
        tbl.Columns("request_useddt2").DefaultValue = Now()
        tbl.Columns("request_acara").DefaultValue = ""
        tbl.Columns("request_season").DefaultValue = ""
        tbl.Columns("request_eps").DefaultValue = ""
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("request_prepareloc").DefaultValue = ""
        tbl.Columns("request_usedloc").DefaultValue = ""
        tbl.Columns("request_userpic").DefaultValue = ""
        tbl.Columns("request_status").DefaultValue = ""
        tbl.Columns("request_jurnalisposted").DefaultValue = 0
        tbl.Columns("request_jurnalsource").DefaultValue = ""
        tbl.Columns("jurnaltype_id").DefaultValue = ""
        tbl.Columns("channel_id").DefaultValue = ""
        tbl.Columns("request_regionid").DefaultValue = ""
        tbl.Columns("request_brandid").DefaultValue = ""
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("request_sub1").DefaultValue = 0
        tbl.Columns("request_sub2").DefaultValue = 0
        tbl.Columns("periode_id").DefaultValue = ""
        tbl.Columns("acctype_id").DefaultValue = ""
        tbl.Columns("request_idr").DefaultValue = 0
        tbl.Columns("currency_id").DefaultValue = 0
        tbl.Columns("request_foreignrate").DefaultValue = 0
        tbl.Columns("request_foreign").DefaultValue = 0
        tbl.Columns("request_entrydt").DefaultValue = Now()
        tbl.Columns("request_entryby").DefaultValue = ""
        tbl.Columns("request_idrreal").DefaultValue = 0
        tbl.Columns("request_foreignratereal").DefaultValue = 0
        tbl.Columns("request_foreignreal").DefaultValue = 0
        tbl.Columns("request_idrsaldo").DefaultValue = 0
        tbl.Columns("request_foreignratesaldo").DefaultValue = 0
        tbl.Columns("request_foreignsaldo").DefaultValue = 0
        tbl.Columns("request_mark").DefaultValue = 0
        tbl.Columns("request_pathfile").DefaultValue = ""
        tbl.Columns("request_markasset").DefaultValue = ""
        tbl.Columns("request_descrproc").DefaultValue = ""
        tbl.Columns("request_amountadv").DefaultValue = 0
        tbl.Columns("request_valasadv").DefaultValue = 0
        tbl.Columns("request_apprauth").DefaultValue = 0
        tbl.Columns("request_apprrev").DefaultValue = 0
        tbl.Columns("request_apprreq").DefaultValue = 0
        tbl.Columns("request_ordered").DefaultValue = 0
        tbl.Columns("request_programtype").DefaultValue = ""
        tbl.Columns("request_epsstart").DefaultValue = 0
        tbl.Columns("request_epsend").DefaultValue = 0
        tbl.Columns("request_singlebudget").DefaultValue = 0
        tbl.Columns("request_approved1").DefaultValue = 0
        tbl.Columns("request_approved1dt").DefaultValue = Now()
        tbl.Columns("request_approved1by").DefaultValue = ""
        tbl.Columns("request_approved2").DefaultValue = 0
        tbl.Columns("request_approved2dt").DefaultValue = Now()
        tbl.Columns("request_approved2by").DefaultValue = ""
        tbl.Columns("request_canceled").DefaultValue = 0
        tbl.Columns("request_reference").DefaultValue = ""
        tbl.Columns("request_latereason").DefaultValue = ""
        tbl.Columns("receivedDoc_by").DefaultValue = ""
        tbl.Columns("receivedDoc_date").DefaultValue = Now()
        tbl.Columns("receivedDoc_app").DefaultValue = 0


        Return tbl
    End Function

    Public Shared Function CreateViewTblTrnPenerimaanbarangSelectRequest() As DataTable
        Dim tbl As New DataTable

        tbl.Columns.Add("channel_id", GetType(String))
        tbl.Columns.Add("request_id", GetType(String))
        tbl.Columns.Add("request_descr", GetType(String))
        tbl.Columns.Add("request_userpic", GetType(String))
        tbl.Columns.Add("show_title", GetType(String))
        tbl.Columns.Add("budget_id", GetType(Decimal))
        tbl.Columns.Add("budget_name", GetType(String))
        tbl.Columns.Add("strukturunit_id", GetType(Decimal))

        Return tbl
    End Function

    Public Shared Function CreateViewTblTrnPenerimaanbarangSelectRequestDetil() As DataTable
        Dim tbl As New DataTable

        tbl.Columns.Add("channel_id", GetType(String))
        tbl.Columns.Add("request_id", GetType(String))
        tbl.Columns.Add("requestdetil_line", GetType(String))
        tbl.Columns.Add("requestdetil_descr", GetType(String))
        tbl.Columns.Add("request_userpic", GetType(String))
        tbl.Columns.Add("request_acara", GetType(String))
        tbl.Columns.Add("show_title", GetType(String))
        tbl.Columns.Add("item_id", GetType(String))
        tbl.Columns.Add("item_name", GetType(String))
        tbl.Columns.Add("category_id", GetType(String))
        tbl.Columns.Add("budget_id", GetType(String))
        tbl.Columns.Add("budget_name", GetType(String))
        tbl.Columns.Add("budgetdetil_id", GetType(Decimal))
        tbl.Columns.Add("budgetdetil_desc", GetType(String))
        tbl.Columns.Add("requestdetil_qty", GetType(Decimal))
        tbl.Columns.Add("requestdetil_qtyoutstanding", GetType(Decimal))

        Return tbl
    End Function

    Public Shared Function CreateViewTblTrnTerimaJasaSelectRequestDetil() As DataTable
        Dim tbl As New DataTable

        tbl.Columns.Add("channel_id", GetType(String))
        tbl.Columns.Add("request_id", GetType(String))
        tbl.Columns.Add("requestdetil_line", GetType(String))
        tbl.Columns.Add("requestdetil_descr", GetType(String))
        tbl.Columns.Add("request_userpic", GetType(String))
        tbl.Columns.Add("request_acara", GetType(String))
        tbl.Columns.Add("show_title", GetType(String))
        tbl.Columns.Add("item_id", GetType(String))
        tbl.Columns.Add("item_name", GetType(String))
        tbl.Columns.Add("category_id", GetType(String))
        tbl.Columns.Add("budget_id", GetType(String))
        tbl.Columns.Add("budget_name", GetType(String))
        tbl.Columns.Add("budgetdetil_id", GetType(Decimal))
        tbl.Columns.Add("budgetdetil_desc", GetType(String))
        tbl.Columns.Add("acc_id", GetType(String))
        tbl.Columns.Add("requestdetil_qty", GetType(Decimal))
        tbl.Columns.Add("requestdetil_qtyoutstanding", GetType(Decimal))

        Return tbl
    End Function

    Public Shared Function CreateTblMstKategoriassetdepre() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Add("kategoriassetdepre_id", GetType(String))
        tbl.Columns.Add("kategoriassetdepre_descr", GetType(String))

        Return tbl
    End Function

    Public Shared Function CreateTblMstCategoryArtis() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Add("categoryartis_id", GetType(Decimal))
        tbl.Columns.Add("categoryartis_name", GetType(String))

        Return tbl
    End Function
End Class
