
' Yanuar Andriyana Putra

Public Class uiTrnMaintenanceAsset
    Private Const mUiName As String = "Maintenance Asset"
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

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_TrnMaintenance As DataTable = clsDataset.CreateTblTrnMaintenance()
    Private tbl_TrnMaintenance_Temp As DataTable = clsDataset.CreateTblTrnMaintenance()
    Private tbl_TrnMaintenancedetil As DataTable = clsDataset.CreateTblTrnMaintenancedetil()

    Private tbl_MstChannel_channel_id As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstChannel_channel_id_search As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstRekanan_rekanan_id As DataTable = clsDataset.CreateTblMstRekanan()
    Private tbl_MstStrukturunit_id As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_MstStrukturunit_id_search As DataTable = clsDataset.CreateTblStrukturunitPemilik()

    Private tbl_trnOrder As DataTable = clsDataset.CreateTblTrnOrder
    Private tbl_MstCurrency As DataTable = clsDataset.CreateTblMstCurrency

    Private Tbl_Mstemployeepemilik As DataTable = clsDataset.CreateTblemployeepemilik

    Private _LOADCOMBO As Boolean = False
    Private _LOADCOMBOSEARCH As Boolean = False
    Private _LoadComboInLoadData As Boolean = False

    Private tbl_Print As DataTable = clsDataset.CreateTblTrnMaintenance
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnMaintenancedetil
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptMaintenance
    Private objDatalistDetil As ArrayList

    Friend WithEvents btnlock As ToolStripButton = New ToolStripButton

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    Private _STRUKTUR_UNIT As Decimal = "5517"
    Private _CANCHANGESU As Boolean = False
    Private _SU_EMPLOYEE As String = "9002000"

    Private _DOCUMENT_TYPE As String = "OUT"
#End Region

#Region " Overrides "
    Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlock.Click

        If Me._DOCUMENT_TYPE = "INC" Then
            If Me.DgvTrnMaintenance.Rows(Me.DgvTrnMaintenance.CurrentRow.Index).Cells("maintenance_outlock").Value = 0 Then
                MsgBox("Lock Out Maintenance First")
                Exit Sub
            End If
            Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            Try
                dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("as_Locktransaksi_maintenance", dbConn)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@maintenance_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnMaintenance.Item("maintenance_id", DgvTrnMaintenance.CurrentRow.Index).Value
                oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me._CHANNEL
                oCm.Parameters.Add("@document_type", System.Data.OleDb.OleDbType.VarWChar, 6).Value = Me._DOCUMENT_TYPE
                oCm.ExecuteNonQuery()
                oCm.Dispose()
                Me.obj_maintenance_incLock.Checked = True
                MessageBox.Show("Data Has Been Locked", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DgvTrnMaintenance.Item("maintenance_inclock", Me.DgvTrnMaintenance.CurrentRow.Index).Value = 1
            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dbConn.Close()
            End Try
            Me.uiTrnMaintenanceAsset_OpenRow(Me.DgvTrnMaintenance.CurrentRow.Index)
        Else
            Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            Try
                If Me.DgvTrnMaintenance.Rows(Me.DgvTrnMaintenance.CurrentRow.Index).Cells("maintenance_outlock").Value = 1 Then
                    MsgBox("You can't lock incoming in this form")
                    Exit Sub
                End If
                dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("as_Locktransaksi_maintenance", dbConn)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@maintenance_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnMaintenance.Item("maintenance_id", DgvTrnMaintenance.CurrentRow.Index).Value
                oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me._CHANNEL
                oCm.Parameters.Add("@document_type", System.Data.OleDb.OleDbType.VarWChar, 6).Value = Me._DOCUMENT_TYPE
                oCm.ExecuteNonQuery()
                oCm.Dispose()
                Me.obj_maintenance_outLock.Checked = True
                MessageBox.Show("Data Has Been Locked", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DgvTrnMaintenance.Item("maintenance_outlock", Me.DgvTrnMaintenance.CurrentRow.Index).Value = 1
            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dbConn.Close()
            End Try
            Me.uiTrnMaintenanceAsset_OpenRow(Me.DgvTrnMaintenance.CurrentRow.Index)
        End If
    End Sub
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
        Me.uiTrnMaintenanceAsset_NewData()
        Me.obj_Channel_id.SelectedValue = Me._CHANNEL
        Me.obj_Strukturunit_id.SelectedValue = Me._STRUKTUR_UNIT
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceAsset_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnMaintenanceAsset_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceAsset_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function


    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceAsset_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceAsset_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceAsset_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceAsset_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceAsset_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceAsset_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMaintenanceAsset_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnMaintenance(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnMaintenance Columns 
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_outin As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenace_itemqty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenace_itemqtyret As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_indt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_outdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_harga As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_valas As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_idrprice As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_inputby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_inputdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_editby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_editdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_usedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_useddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_inclock As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cMaintenance_outlock As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cStrukturunit_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = False

        cMaintenance_id.Name = "maintenance_id"
        cMaintenance_id.HeaderText = "Maintenance No."
        cMaintenance_id.DataPropertyName = "maintenance_id"
        cMaintenance_id.Width = 120
        cMaintenance_id.Visible = True
        cMaintenance_id.ReadOnly = False

        cMaintenance_type.Name = "maintenance_type"
        cMaintenance_type.HeaderText = "Type"
        cMaintenance_type.DataPropertyName = "maintenance_type"
        cMaintenance_type.Width = 100
        cMaintenance_type.Visible = True
        cMaintenance_type.ReadOnly = False

        cMaintenance_outin.Name = "maintenance_outin"
        cMaintenance_outin.HeaderText = "Out"
        cMaintenance_outin.DataPropertyName = "maintenance_outin"
        cMaintenance_outin.Width = 50
        cMaintenance_outin.Visible = True
        cMaintenance_outin.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order No."
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Vendor"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 150
        cRekanan_id.Visible = False
        cRekanan_id.ReadOnly = False

        cMaintenace_itemqty.Name = "maintenace_itemqty"
        cMaintenace_itemqty.HeaderText = "Qty"
        cMaintenace_itemqty.DataPropertyName = "maintenace_itemqty"
        cMaintenace_itemqty.Width = 75
        cMaintenace_itemqty.Visible = True
        cMaintenace_itemqty.ReadOnly = False

        cMaintenace_itemqtyret.Name = "maintenace_itemqtyret"
        cMaintenace_itemqtyret.HeaderText = "Qty Ret."
        cMaintenace_itemqtyret.DataPropertyName = "maintenace_itemqtyret"
        cMaintenace_itemqtyret.Width = 75
        cMaintenace_itemqtyret.Visible = True
        cMaintenace_itemqtyret.ReadOnly = False

        cEmployee_id.Name = "employee_id"
        cEmployee_id.HeaderText = "Employee"
        cEmployee_id.DataPropertyName = "employee_id"
        cEmployee_id.Width = 200
        cEmployee_id.Visible = False
        cEmployee_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Department"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 150
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cMaintenance_indt.Name = "maintenance_indt"
        cMaintenance_indt.HeaderText = "Incoming Date"
        cMaintenance_indt.DataPropertyName = "maintenance_indt"
        cMaintenance_indt.Width = 120
        cMaintenance_indt.Visible = True
        cMaintenance_indt.ReadOnly = False

        cMaintenance_outdt.Name = "maintenance_outdt"
        cMaintenance_outdt.HeaderText = "Outgoing Date"
        cMaintenance_outdt.DataPropertyName = "maintenance_outdt"
        cMaintenance_outdt.Width = 120
        cMaintenance_outdt.Visible = True
        cMaintenance_outdt.ReadOnly = False

        cMaintenance_status.Name = "maintenance_status"
        cMaintenance_status.HeaderText = "Status"
        cMaintenance_status.DataPropertyName = "maintenance_status"
        cMaintenance_status.Width = 100
        cMaintenance_status.Visible = True
        cMaintenance_status.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cMaintenance_harga.Name = "maintenance_harga"
        cMaintenance_harga.HeaderText = "Value"
        cMaintenance_harga.DataPropertyName = "maintenance_harga"
        cMaintenance_harga.Width = 100
        cMaintenance_harga.Visible = True
        cMaintenance_harga.ReadOnly = False

        cMaintenance_valas.Name = "maintenance_valas"
        cMaintenance_valas.HeaderText = "Kurs"
        cMaintenance_valas.DataPropertyName = "maintenance_valas"
        cMaintenance_valas.Width = 100
        cMaintenance_valas.Visible = True
        cMaintenance_valas.ReadOnly = False

        cMaintenance_idrprice.Name = "maintenance_idrprice"
        cMaintenance_idrprice.HeaderText = "IDR Value"
        cMaintenance_idrprice.DataPropertyName = "maintenance_idrprice"
        cMaintenance_idrprice.Width = 100
        cMaintenance_idrprice.Visible = True
        cMaintenance_idrprice.ReadOnly = False

        cMaintenance_inputby.Name = "maintenance_inputby"
        cMaintenance_inputby.HeaderText = "Input By"
        cMaintenance_inputby.DataPropertyName = "maintenance_inputby"
        cMaintenance_inputby.Width = 100
        cMaintenance_inputby.Visible = False
        cMaintenance_inputby.ReadOnly = False

        cMaintenance_inputdt.Name = "maintenance_inputdt"
        cMaintenance_inputdt.HeaderText = "Input Date"
        cMaintenance_inputdt.DataPropertyName = "maintenance_inputdt"
        cMaintenance_inputdt.Width = 100
        cMaintenance_inputdt.Visible = False
        cMaintenance_inputdt.ReadOnly = False

        cMaintenance_editby.Name = "maintenance_editby"
        cMaintenance_editby.HeaderText = "Edit By"
        cMaintenance_editby.DataPropertyName = "maintenance_editby"
        cMaintenance_editby.Width = 100
        cMaintenance_editby.Visible = False
        cMaintenance_editby.ReadOnly = False

        cMaintenance_editdt.Name = "maintenance_editdt"
        cMaintenance_editdt.HeaderText = "Edit Date"
        cMaintenance_editdt.DataPropertyName = "maintenance_editdt"
        cMaintenance_editdt.Width = 100
        cMaintenance_editdt.Visible = False
        cMaintenance_editdt.ReadOnly = False

        cMaintenance_usedby.Name = "maintenance_usedby"
        cMaintenance_usedby.HeaderText = "Used By"
        cMaintenance_usedby.DataPropertyName = "maintenance_usedby"
        cMaintenance_usedby.Width = 100
        cMaintenance_usedby.Visible = False
        cMaintenance_usedby.ReadOnly = False

        cMaintenance_useddt.Name = "maintenance_useddt"
        cMaintenance_useddt.HeaderText = "Used Date"
        cMaintenance_useddt.DataPropertyName = "maintenance_useddt"
        cMaintenance_useddt.Width = 100
        cMaintenance_useddt.Visible = False
        cMaintenance_useddt.ReadOnly = False

        cMaintenance_inclock.Name = "maintenance_inclock"
        cMaintenance_inclock.HeaderText = "Inc. Lock"
        cMaintenance_inclock.DataPropertyName = "maintenance_inclock"
        cMaintenance_inclock.Width = 100
        If Me._DOCUMENT_TYPE = "INC" Then
            cMaintenance_inclock.Visible = True
        Else
            cMaintenance_inclock.Visible = False
        End If
        cMaintenance_inclock.ReadOnly = False

        cMaintenance_outlock.Name = "maintenance_outlock"
        cMaintenance_outlock.HeaderText = "Out. Lock"
        cMaintenance_outlock.DataPropertyName = "maintenance_outlock"
        cMaintenance_outlock.Width = 100
        If Me._DOCUMENT_TYPE = "OUT" Then
            cMaintenance_outlock.Visible = True
        Else
            cMaintenance_outlock.Visible = False
        End If
        cMaintenance_outlock.ReadOnly = False


        cStrukturunit_id_string.Name = "strukturunit_id_string"
        cStrukturunit_id_string.HeaderText = "Department"
        cStrukturunit_id_string.DataPropertyName = "strukturunit_id_string"
        cStrukturunit_id_string.Width = 150
        cStrukturunit_id_string.Visible = True
        cStrukturunit_id_string.ReadOnly = False

        cEmployee_id_string.Name = "employee_id_string"
        cEmployee_id_string.HeaderText = "Employee"
        cEmployee_id_string.DataPropertyName = "employee_id_string"
        cEmployee_id_string.Width = 200
        cEmployee_id_string.Visible = True
        cEmployee_id_string.ReadOnly = False

        cRekanan.Name = "rekanan"
        cRekanan.HeaderText = "Vendor"
        cRekanan.DataPropertyName = "rekanan"
        cRekanan.Width = 200
        cRekanan.Visible = True
        cRekanan.ReadOnly = False

        cCurrency.Name = "currency"
        cCurrency.HeaderText = "Currency"
        cCurrency.DataPropertyName = "currency"
        cCurrency.Width = 100
        cCurrency.Visible = True
        cCurrency.ReadOnly = False



        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cChannel_id, cMaintenance_id, cMaintenance_type, cMaintenance_outin, _
        cOrder_id, cRekanan_id, cRekanan, cMaintenace_itemqty, cMaintenace_itemqtyret, _
        cEmployee_id, cEmployee_id_string, cStrukturunit_id_string, cStrukturunit_id, cMaintenance_indt, cMaintenance_outdt, _
        cMaintenance_status, cCurrency_id, cCurrency, cMaintenance_harga, cMaintenance_valas, _
        cMaintenance_idrprice, cMaintenance_inputby, cMaintenance_inputdt, _
        cMaintenance_editby, cMaintenance_editdt, cMaintenance_usedby, _
        cMaintenance_useddt, cMaintenance_outlock, cMaintenance_inclock})



        ' DgvTrnMaintenance Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.AutoGenerateColumns = False

    End Function

    Private Function FormatDgvTrnMaintenancedetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnMaintenancedetil
        Dim cMaintenance_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenancedetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenancedetil_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenancedetil_outdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenancedetil_statusout As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenance_incdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaintenancedetil_statusinc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cMaintenance_id.Name = "maintenance_id"
        cMaintenance_id.HeaderText = "Maintenance No."
        cMaintenance_id.DataPropertyName = "maintenance_id"
        cMaintenance_id.Width = 120
        cMaintenance_id.Visible = True
        cMaintenance_id.ReadOnly = False

        cMaintenancedetil_line.Name = "maintenancedetil_line"
        cMaintenancedetil_line.HeaderText = "Line"
        cMaintenancedetil_line.DataPropertyName = "maintenancedetil_line"
        cMaintenancedetil_line.Width = 100
        cMaintenancedetil_line.Visible = True
        cMaintenancedetil_line.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = False

        cMaintenancedetil_barcode.Name = "maintenancedetil_barcode"
        cMaintenancedetil_barcode.HeaderText = "Barcode"
        cMaintenancedetil_barcode.DataPropertyName = "maintenancedetil_barcode"
        cMaintenancedetil_barcode.Width = 100
        cMaintenancedetil_barcode.Visible = True
        cMaintenancedetil_barcode.ReadOnly = False

        cMaintenancedetil_outdate.Name = "maintenancedetil_outdate"
        cMaintenancedetil_outdate.HeaderText = "Out Date"
        cMaintenancedetil_outdate.DataPropertyName = "maintenancedetil_outdate"
        cMaintenancedetil_outdate.Width = 100
        cMaintenancedetil_outdate.Visible = True
        cMaintenancedetil_outdate.ReadOnly = False

        cMaintenancedetil_statusout.Name = "maintenancedetil_statusout"
        cMaintenancedetil_statusout.HeaderText = "Status Out"
        cMaintenancedetil_statusout.DataPropertyName = "maintenancedetil_statusout"
        cMaintenancedetil_statusout.Width = 100
        cMaintenancedetil_statusout.Visible = True
        cMaintenancedetil_statusout.ReadOnly = False

        cMaintenance_incdate.Name = "maintenance_incdate"
        cMaintenance_incdate.HeaderText = "Inc Date"
        cMaintenance_incdate.DataPropertyName = "maintenance_incdate"
        cMaintenance_incdate.Width = 100
        cMaintenance_incdate.Visible = True
        cMaintenance_incdate.ReadOnly = False

        cMaintenancedetil_statusinc.Name = "maintenancedetil_statusinc"
        cMaintenancedetil_statusinc.HeaderText = "Status Inc"
        cMaintenancedetil_statusinc.DataPropertyName = "maintenancedetil_statusinc"
        cMaintenancedetil_statusinc.Width = 100
        cMaintenancedetil_statusinc.Visible = True
        cMaintenancedetil_statusinc.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cMaintenance_id, cMaintenancedetil_line, cChannel_id, cMaintenancedetil_barcode, cMaintenancedetil_outdate, cMaintenancedetil_statusout, cMaintenance_incdate, cMaintenancedetil_statusinc})

        objDgv.AllowUserToAddRows = False
        If Me._DOCUMENT_TYPE = "INC" Then
            objDgv.AllowUserToDeleteRows = False
        Else
            objDgv.AllowUserToDeleteRows = True
        End If
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        
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
        Me.DgvTrnMaintenance.Dock = DockStyle.Fill

        Me.FormatDgvTrnMaintenance(Me.DgvTrnMaintenance)
        Me.FormatDgvTrnMaintenancedetil(Me.DgvTrnMaintenancedetil)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Channel_id.DataBindings.clear()
        Me.obj_Maintenance_id.DataBindings.clear()
        Me.obj_Maintenance_type.DataBindings.clear()
        Me.obj_Maintenance_outin.DataBindings.clear()
        Me.obj_Order_id.DataBindings.clear()
        Me.obj_Rekanan_id.DataBindings.clear()
        Me.obj_Maintenace_itemqty.DataBindings.clear()
        Me.obj_Maintenace_itemqtyret.DataBindings.clear()
        Me.obj_Employee_id.DataBindings.clear()
        Me.obj_Strukturunit_id.DataBindings.clear()
        Me.obj_Maintenance_indt.DataBindings.clear()
        Me.obj_Maintenance_outdt.DataBindings.clear()
        Me.obj_Maintenance_status.DataBindings.Clear()
        Me.obj_Currency_id.DataBindings.Clear()
        Me.obj_Maintenance_harga.DataBindings.clear()
        Me.obj_Maintenance_valas.DataBindings.clear()
        Me.obj_Maintenance_idrprice.DataBindings.clear()
        Me.obj_Maintenance_inputby.DataBindings.clear()
        Me.obj_Maintenance_inputdt.DataBindings.clear()
        Me.obj_Maintenance_editby.DataBindings.clear()
        Me.obj_Maintenance_editdt.DataBindings.clear()
        Me.obj_Maintenance_usedby.DataBindings.clear()
        Me.obj_Maintenance_useddt.DataBindings.Clear()
        Me.obj_maintenance_outLock.DataBindings.Clear()
        Me.obj_maintenance_incLock.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Channel_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMaintenance_Temp, "channel_id"))
        Me.obj_Maintenance_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_id"))
        Me.obj_Maintenance_type.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_type"))
        Me.obj_Maintenance_outin.DataBindings.Add(New Binding("Checked", Me.tbl_TrnMaintenance_Temp, "maintenance_outin"))
        Me.obj_Order_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "order_id"))
        Me.obj_Rekanan_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMaintenance_Temp, "rekanan_id"))
        Me.obj_Maintenace_itemqty.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenace_itemqty"))
        Me.obj_Maintenace_itemqtyret.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenace_itemqtyret"))
        Me.obj_Employee_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMaintenance_Temp, "employee_id"))
        Me.obj_Strukturunit_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMaintenance_Temp, "strukturunit_id"))
        Me.obj_Maintenance_indt.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_indt"))
        Me.obj_Maintenance_outdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_outdt"))
        Me.obj_Maintenance_status.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_status"))
        Me.obj_Currency_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMaintenance_Temp, "currency_id"))
        Me.obj_Maintenance_harga.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_harga", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Maintenance_valas.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_valas", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Maintenance_idrprice.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_idrprice", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Maintenance_inputby.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_inputby"))
        Me.obj_Maintenance_inputdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_inputdt"))
        Me.obj_Maintenance_editby.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_editby"))
        Me.obj_Maintenance_editdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_editdt"))
        Me.obj_Maintenance_usedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_usedby"))
        Me.obj_Maintenance_useddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnMaintenance_Temp, "maintenance_useddt"))
        Me.obj_maintenance_outLock.DataBindings.Add(New Binding("Checked", Me.tbl_TrnMaintenance, "maintenance_outlock"))
        Me.obj_maintenance_incLock.DataBindings.Add(New Binding("Checked", Me.tbl_TrnMaintenance, "maintenance_inclock"))
        Return True
    End Function

#End Region

#Region " Dialoged Control "
#End Region

#Region " User Defined Function "

    Private Function uiTrnMaintenanceAsset_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnMaintenance_Temp
        Me.tbl_TrnMaintenance_Temp.Clear()
        Me.tbl_TrnMaintenance_Temp.Columns("maintenance_indt").DefaultValue = DBNull.Value
        Me.tbl_TrnMaintenance_Temp.Columns("maintenance_id").DefaultValue = "AUTO"

        ' TODO: Set Default Value for tbl_TrnMaintenancedetil
        Me.tbl_TrnMaintenancedetil.Clear()
        Me.tbl_TrnMaintenancedetil = clsDataset.CreateTblTrnMaintenancedetil()
        Me.tbl_TrnMaintenancedetil.Columns("maintenance_id").DefaultValue = 0
        Me.tbl_TrnMaintenancedetil.Columns("maintenancedetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnMaintenancedetil.Columns("maintenancedetil_line").AutoIncrement = True
        Me.tbl_TrnMaintenancedetil.Columns("maintenancedetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnMaintenancedetil.Columns("maintenancedetil_line").AutoIncrementStep = 10
        Me.DgvTrnMaintenancedetil.DataSource = Me.tbl_TrnMaintenancedetil

        Me.BindingContext(Me.tbl_TrnMaintenance_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnMaintenance_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function uiTrnMaintenanceAsset_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = String.Empty

        ' TODO: Parse Criteria using clsProc.RefParser()
        If Me.chk_Strukturunit_id_pemilik_search.Checked = True Then
            criteria = " AND strukturunit_id = " & CStr(Me.obj_Strukturunit_id_pemilik_search.SelectedValue)
        End If

        If Me.chkSearchMaintenance_id.Checked = True Then
            criteria = String.Format(" AND maintenance_id = '{0}'", Me.ObjSearchmaintenance_id.Text)
        End If

        Me.tbl_TrnMaintenance.Clear()
        Try
            Me.DataFill(Me.tbl_TrnMaintenance, "as_TrnMaintenance_Select", criteria, Me.obj_Channel_id_search.SelectedValue, Me.NumericUpDown1.Value)
            Me.uiTrnMaintenanceAsset_LoadComboBox()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiTrnMaintenanceAsset_Save() As Boolean
        'save data
        Dim tbl_TrnMaintenance_Temp_Changes As DataTable
        Dim tbl_TrnMaintenancedetil_Changes As DataTable
        Dim success As Boolean
        Dim maintenance_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(maintenance_id)

        Me.BindingContext(Me.tbl_TrnMaintenance_Temp).EndCurrentEdit()
        tbl_TrnMaintenance_Temp_Changes = Me.tbl_TrnMaintenance_Temp.GetChanges()

        Me.DgvTrnMaintenancedetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnMaintenancedetil).EndCurrentEdit()
        tbl_TrnMaintenancedetil_Changes = Me.tbl_TrnMaintenancedetil.GetChanges()

        If tbl_TrnMaintenance_Temp_Changes IsNot Nothing Or tbl_TrnMaintenancedetil_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnMaintenance_Temp.Rows(0).RowState
                maintenance_id = tbl_TrnMaintenance_Temp.Rows(0).Item("maintenance_id")

                If tbl_TrnMaintenance_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnMaintenanceAsset_SaveMaster(maintenance_id, tbl_TrnMaintenance_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnMaintenanceAsset_SaveMaster(tbl_TrnMaintenance_Temp_Changes)")
                    Me.tbl_TrnMaintenance_Temp.AcceptChanges()
                End If

                If tbl_TrnMaintenancedetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnMaintenancedetil.Rows.Count - 1
                        If Me.tbl_TrnMaintenancedetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnMaintenancedetil.Rows(i).Item("maintenance_id") = maintenance_id
                        End If
                    Next
                    success = Me.uiTrnMaintenanceAsset_SaveDetil(maintenance_id, tbl_TrnMaintenancedetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnMaintenanceAsset_SaveDetil(tbl_TrnMaintenancedetil_Changes)")
                    Me.tbl_TrnMaintenancedetil.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        RaiseEvent FormAfterSave(maintenance_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnMaintenanceAsset_SaveMaster(ByRef maintenance_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: transaksi_maintenance
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnMaintenance_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_id", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenance_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_type", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenance_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_outin", System.Data.OleDb.OleDbType.Boolean, 1, "maintenance_outin"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenace_itemqty", System.Data.OleDb.OleDbType.Integer, 4, "maintenace_itemqty"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenace_itemqtyret", System.Data.OleDb.OleDbType.Integer, 4, "maintenace_itemqtyret"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_indt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_indt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_outdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_outdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_status", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenance_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_harga", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "maintenance_harga", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_valas", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "maintenance_valas", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_idrprice", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "maintenance_idrprice", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_inputby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_editby", System.Data.OleDb.OleDbType.VarWChar, 100, "maintenance_editby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_editdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_usedby", System.Data.OleDb.OleDbType.VarWChar, 100, "maintenance_usedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_useddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_outlock", System.Data.OleDb.OleDbType.Boolean, 1, "maintenance_outlock"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_inclock", System.Data.OleDb.OleDbType.Boolean, 1, "maintenance_inclock"))
        dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL
        dbCmdInsert.Parameters("@maintenance_inputby").Value = Me.UserName
        dbCmdInsert.Parameters("@maintenance_inputdt").Value = Now()

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnMaintenance_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_id", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenance_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_type", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenance_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_outin", System.Data.OleDb.OleDbType.Boolean, 1, "maintenance_outin"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenace_itemqty", System.Data.OleDb.OleDbType.Integer, 4, "maintenace_itemqty"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenace_itemqtyret", System.Data.OleDb.OleDbType.Integer, 4, "maintenace_itemqtyret"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_indt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_indt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_outdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_outdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_status", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenance_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_harga", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "maintenance_harga", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_valas", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "maintenance_valas", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_idrprice", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "maintenance_idrprice", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_inputby", System.Data.OleDb.OleDbType.VarWChar, 100, "maintenance_inputby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_inputdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_editby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_usedby", System.Data.OleDb.OleDbType.VarWChar, 100, "maintenance_usedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_useddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_outlock", System.Data.OleDb.OleDbType.Boolean, 1, "maintenance_outlock"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_inclock", System.Data.OleDb.OleDbType.Boolean, 1, "maintenance_inclock"))
        dbCmdUpdate.Parameters("@maintenance_editby").Value = Me.UserName
        dbCmdUpdate.Parameters("@maintenance_editdt").Value = Now()


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            maintenance_id = objTbl.Rows(0).Item("maintenance_id")
            Me.tbl_TrnMaintenance_Temp.Clear()
            Me.tbl_TrnMaintenance_Temp.Merge(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try


        If MasterDataState = DataRowState.Added Then
            Me.tbl_TrnMaintenance.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnMaintenance).Position
            Me.tbl_TrnMaintenance.Rows.RemoveAt(curpos)
            Me.tbl_TrnMaintenance.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnMaintenance).Position = Me.BindingContext(Me.tbl_TrnMaintenance).Count

        Return True
    End Function

    Private Function uiTrnMaintenanceAsset_SaveDetil(ByRef maintenance_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbcmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_maintenancedetil
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnMaintenancedetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "maintenancedetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenancedetil_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "maintenancedetil_barcode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenancedetil_outdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenancedetil_outdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenancedetil_statusout", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenancedetil_statusout"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_incdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_incdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenancedetil_statusinc", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenancedetil_statusinc"))
        dbCmdInsert.Parameters("@maintenance_id").Value = maintenance_id


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnMaintenancedetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "maintenancedetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenancedetil_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "maintenancedetil_barcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenancedetil_outdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenancedetil_outdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenancedetil_statusout", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenancedetil_statusout"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_incdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_incdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenancedetil_statusinc", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenancedetil_statusinc"))
        dbCmdUpdate.Parameters("@maintenance_id").Value = maintenance_id

        dbcmdDelete = New OleDb.OleDbCommand("as_TrnMaintenancedetil_delete", dbConn)
        dbcmdDelete.CommandType = CommandType.StoredProcedure
        dbcmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbcmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenancedetil_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "maintenancedetil_barcode"))
        dbcmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbcmdDelete.Parameters("@maintenance_id").Value = maintenance_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbcmdDelete



        Try
            dbConn.Open()
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTrnMaintenanceAsset_Delete() As Boolean
        Dim res As String = ""
        Dim maintenance_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(maintenance_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnMaintenance.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnMaintenanceAsset_DeleteRow(Me.DgvTrnMaintenance.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(maintenance_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnMaintenanceAsset_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim maintenance_id As String
        Dim NewRowIndex As Integer

        maintenance_id = Me.DgvTrnMaintenance.Rows(rowIndex).Cells("maintenance_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnMaintenance_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@maintenance_id").Value = maintenance_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_type", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@maintenance_type").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_outin", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@maintenance_outin").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@order_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@rekanan_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenace_itemqty", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@maintenace_itemqty").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenace_itemqtyret", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@maintenace_itemqtyret").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@employee_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@strukturunit_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_indt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@maintenance_indt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_outdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@maintenance_outdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_status", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@maintenance_status").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_harga", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@maintenance_harga").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_valas", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@maintenance_valas").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_idrprice", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@maintenance_idrprice").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_inputby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@maintenance_inputby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@maintenance_inputdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_editby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@maintenance_editby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@maintenance_editdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_usedby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@maintenance_usedby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@maintenance_useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@maintenance_useddt").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnMaintenance.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnMaintenanceAsset_OpenRow(NewRowIndex)
                    Me.tbl_TrnMaintenance.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnMaintenance.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnMaintenanceAsset_OpenRow(NewRowIndex)
                    Me.tbl_TrnMaintenance.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnMaintenance.Rows.RemoveAt(rowIndex)
                    Me.uiTrnMaintenanceAsset_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_TrnMaintenance_Temp.Clear()
                Me.tbl_TrnMaintenance.Rows.RemoveAt(rowIndex)

            End If

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Function
        Finally
            dbConn.Close()
        End Try
    End Function

    Private Function uiTrnMaintenanceAsset_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim maintenance_id As String
        Dim channel_id As String

        Dim components As Control

        maintenance_id = Me.DgvTrnMaintenance.Rows(rowIndex).Cells("maintenance_id").Value
        channel_id = Me.DgvTrnMaintenance.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(maintenance_id)

        If Me._DOCUMENT_TYPE = "OUT" Then
            If Me.DgvTrnMaintenance.Rows(Me.DgvTrnMaintenance.CurrentRow.Index).Cells("maintenance_outlock").Value = 1 Then
                For Each components In PnlDataMaster.Controls
                    components.Enabled = False
                Next
            Else
                For Each components In PnlDataMaster.Controls
                    components.Enabled = True
                Next
            End If
        End If

        If Me._DOCUMENT_TYPE = "INC" Then
            If Me.DgvTrnMaintenance.Rows(Me.DgvTrnMaintenance.CurrentRow.Index).Cells("maintenance_inclock").Value = 0 Then
                Me.TextBox1.Enabled = True
            Else
                Me.TextBox1.Enabled = False
            End If
        End If


        Try
            dbConn.Open()
            Me.uiTrnMaintenanceAsset_OpenRowMaster(channel_id, maintenance_id, dbConn)
            Me.uiTrnMaintenanceAsset_OpenRowDetil(channel_id, maintenance_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnMaintenanceAsset_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(maintenance_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiTrnMaintenanceAsset_OpenRowMaster(ByVal channel_id As String, ByVal maintenance_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnMaintenance_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("and maintenance_id='{0}'", maintenance_id)
        dbCmd.Parameters.Add("@top", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@top").Value = Me.NumericUpDown1.Value
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnMaintenance_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnMaintenance_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnMaintenanceAsset_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnMaintenanceAsset_OpenRowDetil(ByVal channel_id As String, ByVal maintenance_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnMaintenancedetil_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("maintenance_id='{0}'", maintenance_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnMaintenancedetil.Clear()

        Me.tbl_TrnMaintenancedetil = clsDataset.CreateTblTrnMaintenancedetil()
        Me.tbl_TrnMaintenancedetil.Columns("maintenance_id").DefaultValue = maintenance_id
        Me.tbl_TrnMaintenancedetil.Columns("maintenancedetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnMaintenancedetil.Columns("maintenancedetil_line").AutoIncrement = True
        Me.tbl_TrnMaintenancedetil.Columns("maintenancedetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnMaintenancedetil.Columns("maintenancedetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnMaintenancedetil)
            Me.DgvTrnMaintenancedetil.DataSource = Me.tbl_TrnMaintenancedetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnMaintenanceAsset_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnMaintenanceAsset_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnMaintenanceAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnMaintenance.CurrentCell = Me.DgvTrnMaintenance(1, 0)
            Me.uiTrnMaintenanceAsset_RefreshPosition()
        End If
    End Function

    Private Function uiTrnMaintenanceAsset_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnMaintenanceAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnMaintenance.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnMaintenance.CurrentCell = Me.DgvTrnMaintenance(1, DgvTrnMaintenance.CurrentCell.RowIndex - 1)
                Me.uiTrnMaintenanceAsset_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnMaintenanceAsset_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnMaintenanceAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnMaintenance.CurrentCell.RowIndex < Me.DgvTrnMaintenance.Rows.Count - 1 Then
                Me.DgvTrnMaintenance.CurrentCell = Me.DgvTrnMaintenance(1, DgvTrnMaintenance.CurrentCell.RowIndex + 1)
                Me.uiTrnMaintenanceAsset_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnMaintenanceAsset_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnMaintenanceAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnMaintenance.CurrentCell = Me.DgvTrnMaintenance(1, Me.DgvTrnMaintenance.Rows.Count - 1)
            Me.uiTrnMaintenanceAsset_RefreshPosition()
        End If
    End Function

    Private Function uiTrnMaintenanceAsset_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnMaintenanceAsset_OpenRow(Me.DgvTrnMaintenance.CurrentRow.Index)
    End Function

    Private Function uiTrnMaintenanceAsset_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnMaintenance_Temp_Changes As DataTable
        Dim tbl_TrnMaintenancedetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim maintenance_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvTrnMaintenance.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnMaintenance_Temp).EndCurrentEdit()
            tbl_TrnMaintenance_Temp_Changes = Me.tbl_TrnMaintenance_Temp.GetChanges()

            Me.DgvTrnMaintenancedetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnMaintenancedetil).EndCurrentEdit()
            tbl_TrnMaintenancedetil_Changes = Me.tbl_TrnMaintenancedetil.GetChanges()

            If tbl_TrnMaintenance_Temp_Changes IsNot Nothing Or tbl_TrnMaintenancedetil_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(maintenance_id)

                        Try

                            If tbl_TrnMaintenance_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnMaintenanceAsset_SaveMaster(maintenance_id, tbl_TrnMaintenance_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_TrnMaintenance_Temp.AcceptChanges()
                            End If

                            If tbl_TrnMaintenancedetil_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnMaintenancedetil.Rows.Count - 1
                                    If Me.tbl_TrnMaintenancedetil.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnMaintenancedetil.Rows(i).Item("maintenance_id") = maintenance_id
                                    End If
                                Next
                                success = Me.uiTrnMaintenanceAsset_SaveDetil(maintenance_id, tbl_TrnMaintenancedetil_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_TrnMaintenancedetil.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(maintenance_id, result)

                    Case DialogResult.No
                        move = True
                    Case DialogResult.Cancel
                        move = False
                End Select
            Else
                move = True
            End If

        End If

        Return move

    End Function

    Private Function uiTrnMaintenanceAsset_FormError() As Boolean
        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

    Private Sub uiTrnMaintenanceAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objParameters As Collection = New Collection
        objParameters = Me.GetParameterCollection(Me.Parameter)
        Dim components As Control
        'TODO: - Extract Parameter
        '      - Assign parameter
        Me.DgvTrnMaintenance.DataSource = Me.tbl_TrnMaintenance
        If Application.ProductName = "TransBrowser" Then
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._STRUKTUR_UNIT = Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT")
            Me._CANCHANGESU = Me.GetBolValueFromParameter(objParameters, "CANCHANGESU")
            Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
            Me._DOCUMENT_TYPE = Me.GetValueFromParameter(objParameters, "DOCUMENT_TYPE")
        End If
        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
        '    Dim dummyparameter As String = "CHANNEL=TTV;STRUKTUR_UNIT=5517;CHANNEL_CANBE_CHANGED=0;CHANNEL_CANBE_BROWSED=0;US=1;PC=1;AC=1;CANCHANGESU=0;PROCSU=5507;SU_EMPLOYEE=9002000;DOCUMENT_TYPE=OUT"
        '    objParameters = Me.GetParameterCollection(dummyparameter)
        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
        '    Me._STRUKTUR_UNIT = Me.GetValueFromParameter(objParameters, "STRUKTUR_UNIT")
        '    Me._CANCHANGESU = Me.GetBolValueFromParameter(objParameters, "CANCHANGESU")
        '    Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        '    Me._DOCUMENT_TYPE = Me.GetValueFromParameter(objParameters, "DOCUMENT_TYPE")
        'End If
        Me.InitLayoutUI()

        Me.BindingStop()
        Me.BindingStart()

        Me.uiTrnMaintenanceAsset_NewData()

        uiTrnMaintenanceAsset_LoadComboSearch()

        If Me._DOCUMENT_TYPE = "INC" Then
            For Each components In PnlDataMaster.Controls
                If components.Name <> "TextBox1" Then
                    components.Enabled = False
                End If
            Next
        End If

        Me.obj_Channel_id_search.SelectedValue = Me._CHANNEL
        Me.chk_Channel_id_search.Checked = True
        Me.chk_Channel_id_search.Enabled = Me._CHANNEL_CANBE_BROWSED
        Me.obj_Channel_id_search.Enabled = Me._CHANNEL_CANBE_BROWSED

        Me.obj_Strukturunit_id_pemilik_search.SelectedValue = Me._STRUKTUR_UNIT

        Me.cmb_Maintenance_Incoming.SelectedItem = "-- PILIH --"
        Me.cmb_Maintenance_Outgoing.SelectedItem = "-- PILIH --"

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

        Me.btnlock.ToolTipText = "Lock Transaction"
        Me.ToolStrip1.Items.Add(Me.btnlock)
        Me.btnlock.Image = Me.ImageList1.Images(0)


    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                Me.uiTrnMaintenanceAsset_LoadCombo()
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White

                If Me.DgvTrnMaintenance.CurrentRow IsNot Nothing Then
                    Me.uiTrnMaintenanceAsset_OpenRow(Me.DgvTrnMaintenance.CurrentRow.Index)
                Else
                    Me.uiTrnMaintenanceAsset_NewData()
                End If


        End Select
    End Sub

    Private Sub DgvTrnMaintenance_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnMaintenance.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnMaintenance.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub uiTrnMaintenanceAsset_LoadComboSearch()


        If Me._LOADCOMBOSEARCH = False Then
            '-----Mulai Bikin Tabel untuk combo Data Search-------------------------
            Me.ComboFill(obj_Channel_id_search, "channel_id", "channel_id", tbl_MstChannel_channel_id_search, "as_MstChannel_select", "", "")
            Me.tbl_MstChannel_channel_id_search.DefaultView.Sort = "channel_name"

            Me.ComboFill(Me.obj_Strukturunit_id_pemilik_search, "strukturunit_id", "strukturunit_name", tbl_MstStrukturunit_id_search, "ms_MstStrukturUnit_Select", "", "")
            Me.tbl_MstStrukturunit_id_search.DefaultView.Sort = "strukturunit_name"


            Me.ComboFill(obj_Rekanan_id, "rekanan_id", "rekanan_name", tbl_MstRekanan_rekanan_id, "as_MstRekanan_select", "rekanantype_id = 1", "")
            Me.tbl_MstRekanan_rekanan_id.DefaultView.Sort = "rekanan_name"

            '-----End Bikin Tabel untuk combo Data  Search----------------------------------
            '---Copy tabel yang sama buat combo--------'
            Dim LL As Boolean
            Me.tbl_MstChannel_channel_id = tbl_MstChannel_channel_id_search.Copy
            LL = ComboFillFromDataTable(obj_Channel_id, "channel_id", "channel_id", tbl_MstChannel_channel_id)
            Me.tbl_MstChannel_channel_id.DefaultView.Sort = "channel_name"

            Me.tbl_MstStrukturunit_id = Me.tbl_MstStrukturunit_id_search.Copy
            LL = ComboFillFromDataTable(Me.obj_Strukturunit_id, "strukturunit_id", "strukturunit_name", tbl_MstStrukturunit_id)
            Me.tbl_MstStrukturunit_id.DefaultView.Sort = "strukturunit_name"

            '---End Copy tabel yang sama buat combo--------'

            Me.ftabDataDetil.SelectedIndex = 1
            Me.ftabDataDetil.SelectedIndex = 0

            Me._LOADCOMBOSEARCH = True
        End If

    End Sub

    Private Sub uiTrnMaintenanceAsset_LoadComboBox()
        'Sekarang bagian Header
        If Me._LoadComboInLoadData = False Then
            If Me._SU_EMPLOYEE = String.Empty Then
                Me.ComboFill(Me.obj_Employee_id, "employee_id", "employee_namalengkap", Me.Tbl_Mstemployeepemilik, "ms_MstEmployee_Select", " ")
                Me.Tbl_Mstemployeepemilik.DefaultView.Sort = "employee_namalengkap"
            Else
                Me.ComboFill(Me.obj_Employee_id, "employee_id", "employee_namalengkap", Me.Tbl_Mstemployeepemilik, "ms_MstEmployee_Select", " strukturunit_id = " & Me._SU_EMPLOYEE)
                Me.Tbl_Mstemployeepemilik.DefaultView.Sort = "employee_namalengkap"
            End If

            Me.ComboFill(Me.obj_Currency_id, "Currency_id", "Currency_shortname", Me.tbl_MstCurrency, "ms_MstCurrency_Select", "  Currency_active = 1")
            Me.tbl_MstCurrency.DefaultView.Sort = "Currency_shortname"
            Me._LoadComboInLoadData = True
        End If
    End Sub

    Private Sub uiTrnMaintenanceAsset_LoadCombo()

        '-----Mulai Bikin Tabel untuk combo Data -------------------------
        If Me._LOADCOMBO = False Then

            Me.ComboFill(Me.obj_Order_id, "order_id", "order_id", Me.tbl_trnOrder, "prg_TrnOrder_Select", " ")
            Me.tbl_trnOrder.DefaultView.Sort = "order_id"

            Me._LOADCOMBO = True
            '-----End Bikin Tabel untuk combo Data  ----------------------------------
        End If

    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar.ToString = Microsoft.VisualBasic.ChrW(13) Then

            If Trim(Me.obj_Maintenance_id.Text) = "AUTO" Then
                MsgBox("Save Header Transaction First")
                Exit Sub
            End If

            If Me._DOCUMENT_TYPE = "INC" Then
                If Me.DgvTrnMaintenance.Rows(Me.DgvTrnMaintenance.CurrentRow.Index).Cells("maintenance_outlock").Value = 0 Then
                    MsgBox("Lock Out Maintenance First")
                    Exit Sub
                End If
            End If
            If Len(Trim(Me.TextBox1.Text)) >= 2 Then
                Me.uiTrnMaintenanceAsset_SaveBarcode()
                Me.Cursor = Cursors.Arrow
            Else
                MsgBox("Please Input Item", MsgBoxStyle.Information, "Warning")
                Me.TextBox1.Text = ""
                Me.TextBox1.Focus()
                Exit Sub
            End If
            Me.TextBox1.Text = "- - Item Maintenance - -"
        End If

    End Sub

    Private Function uiTrnMaintenanceAsset_SaveBarcode() As Boolean

        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Try
            Dim dbCmdInsert As OleDb.OleDbCommand
            'Dim cek As String

            dbConn.Open()
            dbCmdInsert = New OleDb.OleDbCommand("as_TrnMaintenancedetil_Insert", dbConn)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add("@maintenance_id", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenance_id").Value = Me.obj_Maintenance_id.Text
            dbCmdInsert.Parameters.Add("@maintenancedetil_line", System.Data.OleDb.OleDbType.Integer, 4, "maintenancedetil_line").Value = 1
            dbCmdInsert.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id").Value = Me._CHANNEL
            dbCmdInsert.Parameters.Add("@maintenancedetil_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "maintenancedetil_barcode").Value = Trim(Me.TextBox1.Text)
            dbCmdInsert.Parameters.Add("@maintenancedetil_outdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenancedetil_outdate").Value = Now
            dbCmdInsert.Parameters.Add("@maintenancedetil_statusout", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenancedetil_statusout").Value = "AVL"
            dbCmdInsert.Parameters.Add("@maintenance_incdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "maintenance_incdate").Value = DBNull.Value
            dbCmdInsert.Parameters.Add("@maintenancedetil_statusinc", System.Data.OleDb.OleDbType.VarWChar, 30, "maintenancedetil_statusinc").Value = DBNull.Value
            dbCmdInsert.Parameters.Add("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, "strukturunit_id").Value = Me.obj_Strukturunit_id.SelectedValue
            dbCmdInsert.Parameters.Add("@document_type", System.Data.OleDb.OleDbType.VarWChar, 3, "document_type").Value = Me._DOCUMENT_TYPE
            dbCmdInsert.ExecuteNonQuery()
            dbCmdInsert.Dispose()
            Me.uiTrnMaintenanceAsset_OpenRow(Me.DgvTrnMaintenance.CurrentRow.Index)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        Me.Cursor = Cursors.Arrow
    End Function

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Me.TextBox1.Text = "- - Item Maintenance - -"
    End Sub

    Private Sub obj_Currency_id_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Currency_id.Validated
        Dim harga As Decimal = Me.obj_Maintenance_harga.Text
        Dim valas As Decimal = Me.obj_Maintenance_valas.Text

        Dim currency As String
        Dim tbl_mst_exrate As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        'Try
        If Me._LoadComboInLoadData = True Then
            currency = Me.obj_Currency_id.Text
            tbl_mst_exrate.Clear()
            DataFill(tbl_mst_exrate, "as_MstExRate_Select", String.Format("exrate_currency = '{0}'", currency))
            If tbl_mst_exrate.Rows.Count <= 0 Then
                MsgBox("Sorry")
                Me.obj_Maintenance_valas.Text = 0
            Else
                Me.obj_Maintenance_valas.Text = Format(tbl_mst_exrate.Rows(0)("exrate_buy"), "#,##0.00")
            End If
        End If

        Me.obj_Maintenance_idrprice.Text = Format(harga * valas, "#,##0.00")
    End Sub

    Private Sub obj_Maintenance_harga_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Maintenance_harga.Validated
        Dim harga As Decimal = Me.obj_Maintenance_harga.Text
        Dim valas As Decimal = Me.obj_Maintenance_valas.Text

        Me.obj_Maintenance_idrprice.Text = Format(harga * valas, "#,##0.00")
    End Sub

    Private Sub obj_Maintenance_valas_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Maintenance_valas.Validated
        Dim harga As Decimal = Me.obj_Maintenance_harga.Text
        Dim valas As Decimal = Me.obj_Maintenance_valas.Text

        Me.obj_Maintenance_idrprice.Text = Format(harga * valas, "#,##0.00")
    End Sub

    Private Sub UpdateIncStatusToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateIncStatusToolStripMenuItem.Click
        Dim line As Integer
        Dim status As String
        If Me._DOCUMENT_TYPE = "INC" Then
            If Me.DgvTrnMaintenance.Rows(Me.DgvTrnMaintenance.CurrentRow.Index).Cells("maintenance_inclock").Value = 1 Then
                MsgBox("Data has been lock")
                Exit Sub
            End If
            If Me.DgvTrnMaintenancedetil.Rows.Count <= 0 Then
                Exit Sub
            End If
            line = Me.DgvTrnMaintenancedetil.CurrentRow.Cells("maintenancedetil_line").Value
            Dim dlg As New dlgUpdateStatusMaintenance(Me.DSN, _CHANNEL, line, Me.obj_Maintenance_id.Text, "INC")
            status = dlg.OpenDialog(Me)
            If status Is Nothing Then
                Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                Me.uiTrnMaintenanceAsset_OpenRowDetil(_CHANNEL, Me.obj_Maintenance_id.Text, dbConn)
            End If
        End If
    End Sub

    Private Sub UpdateOutStatusToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateOutStatusToolStripMenuItem.Click
        Dim line As Integer
        Dim status As String
        If Me._DOCUMENT_TYPE = "OUT" Then
            If Me.DgvTrnMaintenance.Rows(Me.DgvTrnMaintenance.CurrentRow.Index).Cells("maintenance_outlock").Value = 1 Then
                MsgBox("Data has been lock")
                Exit Sub
            End If
            If Me.DgvTrnMaintenancedetil.Rows.Count <= 0 Then
                Exit Sub
            End If
            line = Me.DgvTrnMaintenancedetil.CurrentRow.Cells("maintenancedetil_line").Value
            Dim dlg As New dlgUpdateStatusMaintenance(Me.DSN, _CHANNEL, line, Me.obj_Maintenance_id.Text, "OUT")
            status = dlg.OpenDialog(Me)
            If status Is Nothing Then
                Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                Me.uiTrnMaintenanceAsset_OpenRowDetil(_CHANNEL, Me.obj_Maintenance_id.Text, dbConn)
            End If
        End If
    End Sub

    Private Sub DgvTrnMaintenancedetil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnMaintenancedetil.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim click As DataGridView.HitTestInfo = Me.DgvTrnMaintenancedetil.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnMaintenancedetil.CurrentCell = Me.DgvTrnMaintenancedetil.Rows(click.RowIndex).Cells(click.ColumnIndex)
            End If
        End If
    End Sub

    Private Sub DgvTrnMaintenance_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnMaintenance.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

        Try
            If objrow.Cells("maintenance_outlock").Value = 0 And objrow.Cells("maintenance_inclock").Value = 0 Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            ElseIf objrow.Cells("maintenance_outlock").Value = 1 And objrow.Cells("maintenance_inclock").Value = 1 Then
                objrow.DefaultCellStyle.BackColor = Color.Bisque
            Else
                objrow.DefaultCellStyle.BackColor = Color.PowderBlue

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chk_Maintenance_OutGoing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Maintenance_OutGoing.CheckedChanged
        If chk_Maintenance_OutGoing.Checked = True Then
            Me.cmb_Maintenance_Outgoing.Enabled = True
            Me.cmb_Maintenance_Outgoing.SelectedItem = "-- PILIH --"
        Else
            Me.cmb_Maintenance_Outgoing.Enabled = False
        End If
    End Sub

    Private Sub chk_Maintenance_Incoming_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_Maintenance_Incoming.CheckedChanged
        If Me.chk_Maintenance_Incoming.Checked = True Then
            Me.cmb_Maintenance_Incoming.Enabled = True
            Me.cmb_Maintenance_Incoming.SelectedItem = "-- PILIH --"
        Else
            Me.cmb_Maintenance_Incoming.Enabled = False
        End If
    End Sub

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()

        tbl_Print.Clear()
        tbl_PrintDetil.Clear()
        objPrintHeader = New DataSource.clsRptMaintenance(Me.DSN)
        DataFill(tbl_Print, "as_TrnMaintenance_Select", " AND maintenance_id = '" & DgvTrnMaintenance.Item("maintenance_id", DgvTrnMaintenance.SelectedCells.Item(0).RowIndex).Value & "'", Me._CHANNEL, Me.NumericUpDown1.Value)
        With objPrintHeader
            .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
            .maintenance_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_id").ToString, String.Empty)
            .maintenance_type = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_type").ToString, String.Empty)
            .maintenance_outin = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_outin"), 0)
            .order_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_id").ToString, String.Empty)
            .rekanan_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_id"), 0)
            .maintenace_itemqty = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenace_itemqty"), 0)
            .maintenace_itemqtyret = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenace_itemqtyret"), 0)
            .employee_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id").ToString, String.Empty)
            .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), 0)
            .maintenance_indt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_indt"), Now())
            .maintenance_outdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_outdt"), Now())
            .maintenance_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_status").ToString, String.Empty)
            .currency_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_id"), 0)
            .maintenance_harga = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_harga"), 0)
            .maintenance_valas = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_valas"), 0)
            .maintenance_idrprice = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_idrprice"), 0)
            .maintenance_inputby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_inputby").ToString, String.Empty)
            .maintenance_inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_inputdt"), Now())
            .maintenance_editby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_editby").ToString, String.Empty)
            .maintenance_editdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_editdt"), Now())
            .maintenance_usedby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_usedby").ToString, String.Empty)
            .maintenance_useddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_useddt"), Now())
            .maintenance_outlock = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_outlock"), 0)
            .maintenance_inclock = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_inclock"), 0)
            DataFill(tbl_PrintDetil, "as_TrnMaintenancedetil_Select", " maintenance_id = '" & .maintenance_id & "'")
            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptMaintenanceDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptMaintenanceDetil(Me.DSN)
            With objDetil
                .maintenance_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenance_id").ToString, String.Empty)
                .maintenancedetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenancedetil_line"), 0)
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
                .maintenancedetil_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenancedetil_barcode").ToString, String.Empty)
                .maintenancedetil_outdate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenancedetil_outdate"), Now())
                .maintenancedetil_statusout = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenancedetil_statusout").ToString, String.Empty)
                .maintenance_incdate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenance_incdate"), Now())
                .maintenancedetil_statusinc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenancedetil_statusinc").ToString, String.Empty)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptMaintenanceDetil", objDatalistDetil))
    End Sub

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        Dim stream As System.IO.Stream
        Dim deviceInfo As String = _
        "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>8.27in</PageWidth>" & _
        "  <PageHeight>11.69in</PageHeight>" & _
        "  <MarginTop>9.8mm</MarginTop>" & _
        "  <MarginLeft>10mm</MarginLeft>" & _
        "  <MarginRight>10mm</MarginRight>" & _
        "  <MarginBottom>9.8mm</MarginBottom>" & _
        "</DeviceInfo>"

        m_streams = New List(Of System.IO.Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream In m_streams
            stream.Position = 0
        Next
    End Sub

    Private Function CreateStream _
    (ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As System.Text.Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) _
    As System.IO.Stream
        Dim stream As System.IO.Stream = New System.IO.FileStream("C:\TransBrowser\Temp" & Name & "." & fileNameExtension, System.IO.FileMode.Create)

        m_streams.Add(stream)

        Return stream
    End Function

    Private Sub PrintPage(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        Dim pageImage As New System.Drawing.Imaging.Metafile(m_streams(m_currentPageIndex))

        ev.Graphics.DrawImage(pageImage, ev.PageBounds)
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Sub Print()
        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        Dim printSet As New System.Drawing.Printing.PrinterSettings
        Const printerName As String = "Microsoft Office Document Image Writer"
        'Dim printerName As String = printSet.PrinterName

        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If
        printDoc.PrinterSettings.PrinterName = printerName
        If Not printDoc.PrinterSettings.IsValid Then
            Dim msg As String = String.Format("Can't find printer ""{0}"".", printerName)
            Console.WriteLine(msg)
            Return
        End If
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()
    End Sub

    Private Function uiTrnMaintenanceAsset_Print() As Boolean
        If Me.DgvTrnMaintenance.SelectedRows.Count <= 0 Then
            MsgBox("No data selected")
            Exit Function
        End If

        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)

        objDatalistHeader = Me.GenerateDataHeader()

        objRdsH.Name = "ASSET_DataSource_clsRptMaintenance"
        objRdsH.Value = objDatalistHeader

        objReportH.ReportEmbeddedResource = "ASSET.RptMaintenance.rdlc"
        objReportH.DataSources.Add(objRdsH)
        objReportH.EnableExternalImages = True
        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})

        AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
        Export(objReportH)

        m_currentPageIndex = 0
        Print()
    End Function

    Private Function uiTrnMaintenanceAsset_PrintPreview() As Boolean
        If Me.DgvTrnMaintenance.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If
        Dim maintenance_id As String
        maintenance_id = Me.DgvTrnMaintenance.CurrentRow.Cells("maintenance_id").Value
        Dim frmPrint As dlgRptMaintenance = New dlgRptMaintenance(Me.DSN, Me.SptServer, Me._CHANNEL, maintenance_id)
        Dim criteria As String = String.Empty

        frmPrint.ShowInTaskbar = False
        frmPrint.StartPosition = FormStartPosition.CenterParent

        criteria = " and maintenance_id = '" & maintenance_id & "'"

        frmPrint.SetIDCriteria(criteria)
        frmPrint.ShowDialog(Me)

    End Function

End Class