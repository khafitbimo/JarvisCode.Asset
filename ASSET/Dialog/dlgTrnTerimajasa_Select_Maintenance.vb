'================================================== 
' Yanuar Andriyana
' TransTV

' Created Date: 5/23/2010 10:02 PM

Public Class dlgTrnTerimajasa_Select_Maintenance
    Private mDSN As String
    'Private mAssetDSN As String
    Private retObj As Object

    Private mChannel_id As String
    Private SOURCE As String
    Private rekanan_id As Decimal
    Private mStrukturunit_id As Decimal

    Private myOwner As System.Windows.Forms.IWin32Window
    Private tbl_TrnTerimaJasa_Maintenance As DataTable = CreateTblTrnTerimaJasa_List_MaintenanceOrder()
    Private tbl_MstRekananGrid As DataTable = clsDataset.CreateTblMstrekananCombo

#Region " Properties "
#End Region

#Region " Constructor & Default Function"

    Public Sub New(ByVal dsn As String, ByVal rekanan_id As Decimal, _
                ByVal tbl_MstRekananGrid As DataTable, ByVal strukturunit_id As Decimal)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mDSN = dsn
        '    Me.mAssetDSN = asset_dsn
        Me.rekanan_id = rekanan_id
        Me.mStrukturunit_id = strukturunit_id

        Me.tbl_MstRekananGrid = tbl_MstRekananGrid.Copy

    End Sub

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, _
                ByVal channel_id As String, Optional ByVal _SOURCE As String = "") As Object

        mChannel_id = channel_id
        Me.obj_Channel_id.Text = channel_id
        Me.SOURCE = _SOURCE

        Me.myOwner = owner
        MyBase.ShowDialog(owner)
        Return retObj
    End Function

#End Region

#Region " UI Layout & Format "

    Function CreateTblTrnTerimaJasa_List_MaintenanceOrder() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("order_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("terimajasa_check", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("status", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_descr", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("rekanan_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("strukturunit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("terimajasa_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("order_prognm", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("order_canceled", GetType(System.Boolean)))
        tbl.Columns.Add(New DataColumn("rekanan_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("budget_name", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("order_id").DefaultValue = ""
        tbl.Columns("terimajasa_check").DefaultValue = False
        tbl.Columns("status").DefaultValue = ""
        tbl.Columns("order_descr").DefaultValue = ""
        tbl.Columns("rekanan_id").DefaultValue = 0
        tbl.Columns("strukturunit_id").DefaultValue = 0
        tbl.Columns("terimajasa_id").DefaultValue = ""
        tbl.Columns("budget_id").DefaultValue = 0
        tbl.Columns("order_prognm").DefaultValue = ""
        tbl.Columns("order_canceled").DefaultValue = False
        tbl.Columns("rekanan_name").DefaultValue = ""
        tbl.Columns("budget_name").DefaultValue = ""


        Return tbl
    End Function
    Private Function FormatDgvTrnTerimaJasa_Select_MaintenanceOrder(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cStatus As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasa_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_prognm As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_canceled As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cTerimajasa_check.Name = "terimajasa_check"
        cTerimajasa_check.HeaderText = "Pilih"
        cTerimajasa_check.DataPropertyName = "terimajasa_check"
        cTerimajasa_check.Width = 40
        cTerimajasa_check.Visible = True
        cTerimajasa_check.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = True

        cStatus.Name = "status"
        cStatus.HeaderText = "Status"
        cStatus.DataPropertyName = "status"
        cStatus.Width = 120
        cStatus.Visible = True
        cStatus.ReadOnly = True

        cOrder_descr.Name = "order_descr"
        cOrder_descr.HeaderText = "Descr"
        cOrder_descr.DataPropertyName = "order_descr"
        cOrder_descr.Width = 200
        cOrder_descr.Visible = True
        cOrder_descr.ReadOnly = True

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "rekanan_id"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 40
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = True

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 60
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = True

        cTerimajasa_id.Name = "terimajasa_id"
        cTerimajasa_id.HeaderText = "TerimaJasa ID"
        cTerimajasa_id.DataPropertyName = "terimajasa_id"
        cTerimajasa_id.Width = 100
        cTerimajasa_id.Visible = True
        cTerimajasa_id.ReadOnly = True

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "budget_id"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 100
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = True
        cBudget_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudget_id.DefaultCellStyle.Format = "#,##0.00"

        cOrder_prognm.Name = "order_prognm"
        cOrder_prognm.HeaderText = "Program"
        cOrder_prognm.DataPropertyName = "order_prognm"
        cOrder_prognm.Width = 100
        cOrder_prognm.Visible = True
        cOrder_prognm.ReadOnly = True


        cOrder_canceled.Name = "order_canceled"
        cOrder_canceled.HeaderText = "Canceled"
        cOrder_canceled.DataPropertyName = "order_canceled"
        cOrder_canceled.Width = 40
        cOrder_canceled.Visible = True
        cOrder_canceled.ReadOnly = True

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Partner"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 200
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True

        cBudget_name.Name = "budget_name"
        cBudget_name.HeaderText = "Budget Name"
        cBudget_name.DataPropertyName = "budget_name"
        cBudget_name.Width = 200
        cBudget_name.Visible = True
        cBudget_name.ReadOnly = True
        cBudget_name.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cBudget_name.DefaultCellStyle.Format = "#,##0.00"



        objDgv.AutoGenerateColumns = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimajasa_check, cOrder_id, cStatus, cOrder_descr, cRekanan_id, cStrukturunit_id, cBudget_id, _
        cTerimajasa_id, cRekanan_name, cOrder_prognm, cBudget_name, cOrder_canceled})


        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        'objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.CellSelect
        objDgv.MultiSelect = False

    End Function
#End Region

#Region " User defined function "

    Private Function dlgTrnTerimajasa_Select_Maintenance_Load(ByVal channel_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        ' Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mAssetDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim tbl_DetilSA As DataTable = CreateTblTrnTerimaJasa_List_MaintenanceOrder()
        Dim criteria = ""
        Dim cookie As Byte() = Nothing
        Dim cookie1 As Byte() = Nothing


        Dim txtSearchCriteria As String = ""
        Dim txtSQLSearch As String = String.Empty

        txtSQLSearch = txtSQLSearch & " status <> 'COMPLETE' AND order_canceled = 0 "

        '-- Order Search
        If Me.chkSearchOrderID_Search.Checked Then
            txtSearchCriteria = clsUtil.RefParser("order_id", Me.obj_order_id)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        '--END 

        '-- Terima Jasa Search
        If Me.chkSearchTerimaJasaID_Search.Checked Then
            txtSearchCriteria = clsUtil.RefParser("terimajasa_id", Me.obj_terimajasa_id)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        '--END 

        '-- Rekanan Search    
        If Me.chkRekanan.Checked Then
            txtSearchCriteria = String.Format(" rekanan_id = '{0}' ", Me.obj_Rekanan_id.Text)
            If txtSQLSearch = "" Then
                txtSQLSearch = " (" & txtSearchCriteria & ") "
            Else
                txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
            End If
        End If
        '--END 

        criteria = txtSQLSearch


        dbCmd = New OleDb.OleDbCommand("as_TrnTerimajasa_Select_Maintenance", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@Criteria").Value = criteria
        dbCmd.Parameters.Add("@strukturunit_id", Data.OleDb.OleDbType.Decimal)
        dbCmd.Parameters("@strukturunit_id").Value = Me.mStrukturunit_id
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@channel_id").Value = channel_id

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnTerimaJasa_Maintenance.Clear()

        Try
            dbConn.Open()
            ' dbConnAsset.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            ' clsApplicationRole.SetAppRole(dbConnAsset, cookie1)
            dbDA.Fill(Me.tbl_TrnTerimaJasa_Maintenance)

            Me.DgvMaintenanceOrder.DataSource = Me.tbl_TrnTerimaJasa_Maintenance
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgTrnTerimajasa_Select_Maintenance" & ": dlgTrnTerimajasa_Select_Maintenance_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            'clsApplicationRole.UnsetAppRole(dbConnAsset, cookie1)
            dbConn.Close()
            ' dbConnAsset.Close()
        End Try
    End Function

#End Region


    Private Sub dlgTrnTerimajasa_Select_Maintenance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Cursor = Cursors.WaitCursor
        Me.FormatDgvTrnTerimaJasa_Select_MaintenanceOrder(Me.DgvMaintenanceOrder)
        Me.DgvMaintenanceOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.DgvMaintenanceOrder.DataSource = Me.tbl_TrnTerimaJasa_Maintenance

        Me.obj_order_id.Enabled = False
        Me.chkRekanan.Checked = False
        ' ''Me.obj_Rekanan_id.SelectedValue = Me.rekanan_id
        Me.obj_Rekanan_id.Enabled = False

        Me.obj_Source.Items.Add("MAINTENANCE")
        Me.obj_Source.SelectedItem = "MAINTENANCE"
        Me.obj_Source.Enabled = False

        Me.Cursor = Cursors.Arrow

    End Sub

    '=============================Button================================================================================================================================================================
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Me.dlgTrnTerimajasa_Select_Maintenance_Load(Me.mChannel_id)
        Me.DgvMaintenanceOrder.DataSource = Me.tbl_TrnTerimaJasa_Maintenance

    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim tblH As DataTable = CreateTblTrnTerimaJasa_List_MaintenanceOrder()
        Dim row As DataRow
        Dim thisRetObj As Collection = New Collection

        Dim tbl_TrnTerimaJasa1 As DataTable = CreateTblTrnTerimaJasa_List_MaintenanceOrder()
        Dim i, j As Integer
        Dim columnName As String

        tbl_TrnTerimaJasa1.Clear()
        tbl_TrnTerimaJasa1 = Me.tbl_TrnTerimaJasa_Maintenance.Copy()
        tbl_TrnTerimaJasa1.DefaultView.RowFilter = "terimajasa_check = 'True'"

        If Me.DgvMaintenanceOrder.CurrentRow IsNot Nothing Then
            If tbl_TrnTerimaJasa1.DefaultView.Count > 0 Then
                For i = 0 To tbl_TrnTerimaJasa1.DefaultView.Count - 1
                    row = tblH.NewRow()
                    For j = 0 To tbl_TrnTerimaJasa1.Columns.Count - 1
                        columnName = tbl_TrnTerimaJasa1.Columns(j).ColumnName
                        row.Item(columnName) = tbl_TrnTerimaJasa1.DefaultView.Item(i).Item(columnName)
                    Next
                    tblH.Rows.Add(row)
                Next

                thisRetObj.Add(tblH.Copy(), "tblH")
                retObj = thisRetObj

                Me.Close()
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.retObj = Nothing
        Me.Close()
    End Sub

    Private Sub chkRekanan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRekanan.CheckedChanged
        If Me.chkRekanan.Checked = True Then
            Me.obj_Rekanan_id.Enabled = True
        Else
            Me.obj_Rekanan_id.Enabled = False
        End If
    End Sub

    Private Sub DgvMaintenanceOrder_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMaintenanceOrder.CellClick
        Dim i As Integer

        For i = 0 To Me.DgvMaintenanceOrder.Rows.Count - 1
            If i <> e.RowIndex Then
                Me.DgvMaintenanceOrder.Rows(i).Cells("terimajasa_check").Value = False
            End If
        Next
    End Sub



    Private Sub btn_Rekanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Rekanan.Click
        Dim rekanan_id As String
        Dim dlg As dlgSearch = New dlgSearch()
        retObj = dlg.OpenDialog(Me, Me.tbl_MstRekananGrid, "rekanan")
        rekanan_id = retObj

        If rekanan_id IsNot Nothing Then
            Me.obj_Rekanan_id.Text = rekanan_id
        End If

    End Sub


    Private Sub chkSearchOrderID_Search_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchOrderID_Search.CheckedChanged
        If Me.chkSearchOrderID_Search.Checked = True Then
            Me.obj_order_id.Enabled = True
        Else
            Me.obj_order_id.Enabled = False
        End If
    End Sub

    Private Sub chkSearchTerimaJasaID_Search_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchTerimaJasaID_Search.CheckedChanged
        If Me.chkSearchTerimaJasaID_Search.Checked = True Then
            Me.obj_terimajasa_id.Enabled = True
        Else
            Me.obj_terimajasa_id.Enabled = False
        End If
    End Sub

    Private Sub DgvMaintenanceOrder_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvMaintenanceOrder.CellFormatting
        Dim Selected As Boolean
        Dim obj As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = obj.Rows(e.RowIndex)

        Try

            Selected = CBool(objRow.Cells("terimajasa_check").Value)

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
End Class
