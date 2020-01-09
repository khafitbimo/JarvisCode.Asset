Public Class uiTrnwriteoff
    Private Const mUiName As String = "Write Off"
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

    Private tbl_TrnWriteoff As DataTable = clsDataset.CreateTblTrnWriteoff(_CHANNEL)
    Private tbl_TrnWriteoff_Temp As DataTable = clsDataset.CreateTblTrnWriteoff(_CHANNEL)
    Private tbl_TrnWriteoffdetil As DataTable = clsDataset.CreateTblTrnWriteoffdetil(_CHANNEL)
    Private tbl_MstStrukturunitPelapor As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_MstStrukturunitPelapor_search As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_Mstemployeepelapor As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_Mstemployeeapprove As DataTable = clsDataset.CreateTblemployeepemilik()

    Private tbl_MstEmployeeInternalAudit As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeeProcurement As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeeAccounting As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeeFRMdirector As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeePresdirector As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeeCommissioner As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeeReportByDeptHead As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeeReportByDivHead As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeeReportByDirector As DataTable = clsDataset.CreateTblemployeepemilik

    Private tbl_MstChannel As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()

    Private _LoadComboInLoadData As Boolean = False
    Private suaramenang As String

    Private tbl_Print As DataTable = clsDataset.CreateTblTrnWriteoff(Me._CHANNEL)
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnWriteoffdetil(Me._CHANNEL)
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptTrnWriteoff
    Private objDatalistDetil As ArrayList

    Private tempChannel_ID As String
    Private tempChannel_nameReport As String
    Private tempChannel_address As String
    Private tempWriteOff_id As String

    Friend WithEvents btnlock As ToolStripButton = New ToolStripButton

#Region " Window Parameter "
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
    Private _STRUKTUR_UNIT As Decimal = 5517
    Private _STRUKTUR_UNIT_CANBE_CHANGED As Boolean = False
    Private _STRUKTUR_UNIT_CANDE_BROWSED As Boolean = False
    Private _SU_EMPLOYEE As String = "9002000"
    Private _SU_ACCOUNTING As String = "1001000"
    Private _PRESDIR As String = "EM08020217"
    Private _ACCOUNTING As String = "EM08021293"
    Private _IA As String = "EM08020638"

    ' TODO: Buat variabel untuk menampung parameter window 
#End Region
#Region " Additional Overrides "
    Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlock.Click
        Lock_data()
    End Sub


#End Region
#Region " Window Dataset "
#End Region

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
        Me.uiTrnwriteoff_NewData()
        Me.PnlDataMaster.Enabled = True
        Me.Panel3.Enabled = True
        Me.DgvTrnWriteoffdetil.AllowUserToDeleteRows = True

        Me.obj_Employee_id_internal_audit.SelectedValue = Me._IA
        Me.obj_Employee_id_PresDirector.SelectedValue = Me._PRESDIR
        Me.obj_Employee_id_Accounting.SelectedValue = Me._ACCOUNTING
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function
    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnwriteoff_Retrieve()
        Me.uiTrnTerimaBarang_LoadComboBox()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnwriteoff_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnwriteoff_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnwriteoff_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnwriteoff_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function
    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnwriteoff_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function
    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnwriteoff_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function
    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnwriteoff_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function
    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnwriteoff_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function
    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnwriteoff_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnWriteoff(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnWriteoff Columns 
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_reportby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_reportby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_approvedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_inputby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLock As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cEmployee_id_reportby_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_reportby_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_approvedby_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cEmployee_id_internal_audit As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_procurement As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_accounting As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_frm_director As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_president_director As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_commissioner As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = False

        cWriteoff_id.Name = "writeoff_id"
        cWriteoff_id.HeaderText = "ID"
        cWriteoff_id.DataPropertyName = "writeoff_id"
        cWriteoff_id.Width = 130
        cWriteoff_id.Visible = True
        cWriteoff_id.ReadOnly = False

        cWriteoff_dt.Name = "writeoff_dt"
        cWriteoff_dt.HeaderText = "Date"
        cWriteoff_dt.DataPropertyName = "writeoff_dt"
        cWriteoff_dt.Width = 100
        cWriteoff_dt.Visible = True
        cWriteoff_dt.ReadOnly = False

        cEmployee_id_reportby.Name = "employee_id_reportby"
        cEmployee_id_reportby.HeaderText = "Report By"
        cEmployee_id_reportby.DataPropertyName = "employee_id_reportby"
        cEmployee_id_reportby.Width = 100
        cEmployee_id_reportby.Visible = False
        cEmployee_id_reportby.ReadOnly = False

        cStrukturunit_id_reportby.Name = "strukturunit_id_reportby"
        cStrukturunit_id_reportby.HeaderText = "Department"
        cStrukturunit_id_reportby.DataPropertyName = "strukturunit_id_reportby"
        cStrukturunit_id_reportby.Width = 100
        cStrukturunit_id_reportby.Visible = False
        cStrukturunit_id_reportby.ReadOnly = False

        cEmployee_id_approvedby.Name = "employee_id_approvedby"
        cEmployee_id_approvedby.HeaderText = "Approved By"
        cEmployee_id_approvedby.DataPropertyName = "employee_id_approvedby"
        cEmployee_id_approvedby.Width = 100
        cEmployee_id_approvedby.Visible = False
        cEmployee_id_approvedby.ReadOnly = False

        cWriteoff_inputby.Name = "writeoff_inputby"
        cWriteoff_inputby.HeaderText = "Input By"
        cWriteoff_inputby.DataPropertyName = "writeoff_inputby"
        cWriteoff_inputby.Width = 100
        cWriteoff_inputby.Visible = True
        cWriteoff_inputby.ReadOnly = False

        cWriteoff_date.Name = "writeoff_date"
        cWriteoff_date.HeaderText = "Input Date"
        cWriteoff_date.DataPropertyName = "writeoff_date"
        cWriteoff_date.Width = 100
        cWriteoff_date.Visible = True
        cWriteoff_date.ReadOnly = False

        cLock.Name = "lock"
        cLock.HeaderText = "Lock"
        cLock.DataPropertyName = "lock"
        cLock.Width = 50
        cLock.Visible = True
        cLock.ReadOnly = False

        cEmployee_id_reportby_string.Name = "employee_id_reportby_string"
        cEmployee_id_reportby_string.HeaderText = "Report By"
        cEmployee_id_reportby_string.DataPropertyName = "employee_id_reportby_string"
        cEmployee_id_reportby_string.Width = 200
        cEmployee_id_reportby_string.Visible = True
        cEmployee_id_reportby_string.ReadOnly = False

        cStrukturunit_id_reportby_string.Name = "strukturunit_id_reportby_string"
        cStrukturunit_id_reportby_string.HeaderText = "Report By"
        cStrukturunit_id_reportby_string.DataPropertyName = "strukturunit_id_reportby_string"
        cStrukturunit_id_reportby_string.Width = 200
        cStrukturunit_id_reportby_string.Visible = True
        cStrukturunit_id_reportby_string.ReadOnly = False

        cEmployee_id_approvedby_string.Name = "employee_id_approvedby_string"
        cEmployee_id_approvedby_string.HeaderText = "Approved By"
        cEmployee_id_approvedby_string.DataPropertyName = "employee_id_approvedby_string"
        cEmployee_id_approvedby_string.Width = 200
        cEmployee_id_approvedby_string.Visible = True
        cEmployee_id_approvedby_string.ReadOnly = False

        cEmployee_id_internal_audit.Name = "employee_id_internal_audit"
        cEmployee_id_internal_audit.HeaderText = "employee_id_internal_audit"
        cEmployee_id_internal_audit.DataPropertyName = "employee_id_internal_audit"
        cEmployee_id_internal_audit.Width = 100
        cEmployee_id_internal_audit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEmployee_id_internal_audit.Visible = False
        cEmployee_id_internal_audit.ReadOnly = False

        cEmployee_id_procurement.Name = "employee_id_procurement"
        cEmployee_id_procurement.HeaderText = "employee_id_procurement"
        cEmployee_id_procurement.DataPropertyName = "employee_id_procurement"
        cEmployee_id_procurement.Width = 100
        cEmployee_id_procurement.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEmployee_id_procurement.Visible = False
        cEmployee_id_procurement.ReadOnly = False

        cEmployee_id_accounting.Name = "employee_id_accounting"
        cEmployee_id_accounting.HeaderText = "employee_id_accounting"
        cEmployee_id_accounting.DataPropertyName = "employee_id_accounting"
        cEmployee_id_accounting.Width = 100
        cEmployee_id_accounting.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEmployee_id_accounting.Visible = False
        cEmployee_id_accounting.ReadOnly = False

        cEmployee_id_frm_director.Name = "employee_id_frm_director"
        cEmployee_id_frm_director.HeaderText = "employee_id_frm_director"
        cEmployee_id_frm_director.DataPropertyName = "employee_id_frm_director"
        cEmployee_id_frm_director.Width = 100
        cEmployee_id_frm_director.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEmployee_id_frm_director.Visible = False
        cEmployee_id_frm_director.ReadOnly = False

        cEmployee_id_president_director.Name = "employee_id_president_director"
        cEmployee_id_president_director.HeaderText = "employee_id_president_director"
        cEmployee_id_president_director.DataPropertyName = "employee_id_president_director"
        cEmployee_id_president_director.Width = 100
        cEmployee_id_president_director.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEmployee_id_president_director.Visible = False
        cEmployee_id_president_director.ReadOnly = False

        cEmployee_id_commissioner.Name = "employee_id_commissioner"
        cEmployee_id_commissioner.HeaderText = "employee_id_commissioner"
        cEmployee_id_commissioner.DataPropertyName = "employee_id_commissioner"
        cEmployee_id_commissioner.Width = 100
        cEmployee_id_commissioner.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEmployee_id_commissioner.Visible = False
        cEmployee_id_commissioner.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cLock, cChannel_id, cWriteoff_id, cWriteoff_dt, cEmployee_id_reportby, cEmployee_id_reportby_string, cStrukturunit_id_reportby, cStrukturunit_id_reportby_string, cEmployee_id_approvedby, cEmployee_id_approvedby_string, cWriteoff_inputby, cWriteoff_date, _
        cEmployee_id_internal_audit, cEmployee_id_procurement, cEmployee_id_accounting, cEmployee_id_frm_director, cEmployee_id_president_director, cEmployee_id_commissioner})

        ' DgvTrnWriteoff Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function
    Private Function FormatDgvTrnWriteoffdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnWriteoffdetil
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_tgl As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_hargaawal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id_akhir As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_hargakhir As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_writeoffby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_writeoffapp As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWriteoff_desc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cstatus_akhir As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim casset_deskripsi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim casset_serial As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim ctipeitem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim ckategoriitem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cStrukturunit_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cemployee_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_awal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_akhir As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLokasi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        casset_deskripsi.Name = "asset_deskripsi"
        casset_deskripsi.HeaderText = "Description"
        casset_deskripsi.DataPropertyName = "asset_deskripsi"
        casset_deskripsi.Width = 200
        casset_deskripsi.Visible = True
        casset_deskripsi.ReadOnly = True

        casset_serial.Name = "asset_serial"
        casset_serial.HeaderText = "S/N"
        casset_serial.DataPropertyName = "asset_serial"
        casset_serial.Width = 100
        casset_serial.Visible = True
        casset_serial.ReadOnly = True

        ctipeitem_id.Name = "tipeitem_id"
        ctipeitem_id.HeaderText = "Type"
        ctipeitem_id.DataPropertyName = "tipeitem_id"
        ctipeitem_id.Width = 130
        ctipeitem_id.Visible = True
        ctipeitem_id.ReadOnly = True

        ckategoriitem_id.Name = "kategoriitem_id"
        ckategoriitem_id.HeaderText = "Category"
        ckategoriitem_id.DataPropertyName = "kategoriitem_id"
        ckategoriitem_id.Width = 130
        ckategoriitem_id.Visible = True
        ckategoriitem_id.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = True

        cWriteoff_id.Name = "writeoff_id"
        cWriteoff_id.HeaderText = "ID"
        cWriteoff_id.DataPropertyName = "writeoff_id"
        cWriteoff_id.Width = 110
        cWriteoff_id.Visible = True
        cWriteoff_id.ReadOnly = True

        cWriteoff_tgl.Name = "writeoff_tgl"
        cWriteoff_tgl.HeaderText = "Date"
        cWriteoff_tgl.DataPropertyName = "writeoff_tgl"
        cWriteoff_tgl.Width = 100
        cWriteoff_tgl.Visible = True
        cWriteoff_tgl.ReadOnly = True

        cWriteoff_barcode.Name = "writeoff_barcode"
        cWriteoff_barcode.HeaderText = "Barcode"
        cWriteoff_barcode.DataPropertyName = "writeoff_barcode"
        cWriteoff_barcode.Width = 80
        cWriteoff_barcode.Visible = True
        cWriteoff_barcode.ReadOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency Awal"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 120
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = True

        cWriteoff_hargaawal.Name = "writeoff_hargaawal"
        cWriteoff_hargaawal.HeaderText = "Harga Awal"
        cWriteoff_hargaawal.DataPropertyName = "writeoff_hargaawal"
        cWriteoff_hargaawal.Width = 120
        cWriteoff_hargaawal.Visible = True
        cWriteoff_hargaawal.ReadOnly = True
        cWriteoff_hargaawal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cWriteoff_hargaawal.DefaultCellStyle.Format = "#,##0"


        cCurrency_id_akhir.Name = "currency_id_akhir"
        cCurrency_id_akhir.HeaderText = "Currency Akhir"
        cCurrency_id_akhir.DataPropertyName = "currency_id_akhir"
        cCurrency_id_akhir.Width = 120
        cCurrency_id_akhir.Visible = False
        cCurrency_id_akhir.ReadOnly = True

        cWriteoff_hargakhir.Name = "writeoff_hargakhir"
        cWriteoff_hargakhir.HeaderText = "Harga Akhir"
        cWriteoff_hargakhir.DataPropertyName = "writeoff_hargakhir"
        cWriteoff_hargakhir.Width = 100
        cWriteoff_hargakhir.Visible = True
        cWriteoff_hargakhir.ReadOnly = True
        cWriteoff_hargakhir.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cWriteoff_hargakhir.DefaultCellStyle.Format = "#,##0"

        cEmployee_id_writeoffby.Name = "employee_id_writeoffby"
        cEmployee_id_writeoffby.HeaderText = "Writeoff By"
        cEmployee_id_writeoffby.DataPropertyName = "employee_id_writeoffby"
        cEmployee_id_writeoffby.Width = 150
        cEmployee_id_writeoffby.Visible = False
        cEmployee_id_writeoffby.ReadOnly = True

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Department"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 120
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = True

        cEmployee_id_writeoffapp.Name = "employee_id_writeoffapp"
        cEmployee_id_writeoffapp.HeaderText = "employee writeoffapp"
        cEmployee_id_writeoffapp.DataPropertyName = "employee_id_writeoffapp"
        cEmployee_id_writeoffapp.Width = 150
        cEmployee_id_writeoffapp.Visible = True
        cEmployee_id_writeoffapp.ReadOnly = True

        cWriteoff_desc.Name = "writeoff_reason"
        cWriteoff_desc.HeaderText = "Reason"
        cWriteoff_desc.DataPropertyName = "writeoff_reason"
        cWriteoff_desc.Width = 100
        cWriteoff_desc.Visible = True
        cWriteoff_desc.ReadOnly = False

        cstatus_akhir.Name = "status_akhir"
        cstatus_akhir.HeaderText = "Status Akhir"
        cstatus_akhir.DataPropertyName = "status_akhir"
        cstatus_akhir.Width = 100
        cstatus_akhir.Visible = True
        cstatus_akhir.ReadOnly = True

        cStrukturunit_id_string.Name = "strukturunit_id_string"
        cStrukturunit_id_string.HeaderText = "Department"
        cStrukturunit_id_string.DataPropertyName = "strukturunit_id_string"
        cStrukturunit_id_string.Width = 140
        cStrukturunit_id_string.Visible = True
        cStrukturunit_id_string.ReadOnly = True

        cemployee_id_string.Name = "employee_id_string"
        cemployee_id_string.HeaderText = "Writeoff By"
        cemployee_id_string.DataPropertyName = "employee_id_string"
        cemployee_id_string.Width = 140
        cemployee_id_string.Visible = True
        cemployee_id_string.ReadOnly = True


        cCurrency_awal.Name = "currency_awal"
        cCurrency_awal.HeaderText = "Currency Awal"
        cCurrency_awal.DataPropertyName = "currency_awal"
        cCurrency_awal.Width = 110
        cCurrency_awal.Visible = True
        cCurrency_awal.ReadOnly = True


        cCurrency_akhir.Name = "currency_akhir"
        cCurrency_akhir.HeaderText = "Currency Akhir"
        cCurrency_akhir.DataPropertyName = "currency_akhir"
        cCurrency_akhir.Width = 110
        cCurrency_akhir.Visible = True
        cCurrency_akhir.ReadOnly = True

        cLokasi.Name = "lokasi"
        cLokasi.HeaderText = "Lokasi"
        cLokasi.DataPropertyName = "lokasi"
        cLokasi.Width = 250
        cLokasi.Visible = True
        cLokasi.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cChannel_id, cWriteoff_id, cWriteoff_tgl, cWriteoff_barcode, _
        cCurrency_id, cCurrency_awal, cWriteoff_hargaawal, cCurrency_akhir, cCurrency_id_akhir, _
        cWriteoff_hargakhir, cEmployee_id_writeoffby, cemployee_id_string, _
        cStrukturunit_id, cStrukturunit_id_string, _
        cEmployee_id_writeoffapp, cWriteoff_desc, cstatus_akhir, _
        casset_deskripsi, casset_serial, ctipeitem_id, ckategoriitem_id, cLokasi})

        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToResizeRows = False
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
        Me.DgvTrnWriteoff.Dock = DockStyle.Fill

        Me.FormatDgvTrnWriteoff(Me.DgvTrnWriteoff)
        Me.FormatDgvTrnWriteoffdetil(Me.DgvTrnWriteoffdetil)

    End Function
    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Writeoff_id.DataBindings.Clear()
        Me.obj_Writeoff_dt.DataBindings.Clear()
        Me.obj_Employee_id_reportby.DataBindings.Clear()
        Me.obj_Strukturunit_id_reportby.DataBindings.Clear()
        Me.obj_Employee_id_approvedby.DataBindings.Clear()
        Me.obj_Writeoff_inputby.DataBindings.Clear()
        Me.obj_Writeoff_date.DataBindings.Clear()
        Me.obj_Writeoff_lock.DataBindings.Clear()
        Me.obj_Employee_id_internal_audit.DataBindings.Clear()
        Me.obj_Employee_id_Procurement.DataBindings.Clear()
        Me.obj_Employee_id_Accounting.DataBindings.Clear()
        Me.obj_Employee_id_FRM_Director.DataBindings.Clear()
        Me.obj_Employee_id_PresDirector.DataBindings.Clear()
        Me.obj_Employee_id_commissioner.DataBindings.Clear()
        Me.obj_Employee_id_reportby_deptHead.DataBindings.Clear()
        Me.obj_Employee_id_reportby_divHead.DataBindings.Clear()
        Me.obj_Employee_id_reportby_director.DataBindings.Clear()


        Return True
    End Function
    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Channel_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "channel_id"))
        Me.obj_Writeoff_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnWriteoff_Temp, "writeoff_id"))
        Me.obj_Writeoff_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnWriteoff_Temp, "writeoff_dt"))
        Me.obj_Employee_id_reportby.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "employee_id_reportby"))
        Me.obj_Strukturunit_id_reportby.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "strukturunit_id_reportby"))
        Me.obj_Employee_id_approvedby.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "employee_id_approvedby"))
        Me.obj_Writeoff_inputby.DataBindings.Add(New Binding("Text", Me.tbl_TrnWriteoff_Temp, "writeoff_inputby"))
        Me.obj_Writeoff_date.DataBindings.Add(New Binding("Text", Me.tbl_TrnWriteoff_Temp, "writeoff_date"))
        Me.obj_Writeoff_lock.DataBindings.Add(New Binding("Checked", Me.tbl_TrnWriteoff, "lock"))
        Me.obj_Employee_id_internal_audit.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "employee_id_internal_audit"))
        Me.obj_Employee_id_Procurement.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "employee_id_procurement"))
        Me.obj_Employee_id_Accounting.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "employee_id_accounting"))
        Me.obj_Employee_id_FRM_Director.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "employee_id_frm_director"))
        Me.obj_Employee_id_PresDirector.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "employee_id_president_director"))
        Me.obj_Employee_id_commissioner.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "employee_id_commissioner"))
        Me.obj_Employee_id_reportby_deptHead.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "employee_id_owner_dept_head"))
        Me.obj_Employee_id_reportby_divHead.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "employee_id_owner_div_head"))
        Me.obj_Employee_id_reportby_director.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnWriteoff_Temp, "employee_id_owner_director"))

        Return True
    End Function

#End Region

#Region " Dialoged Control "
#End Region

#Region " User Defined Function "

    Private Function uiTrnwriteoff_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnWriteoff_Temp
        Me.tbl_TrnWriteoff_Temp.Clear()
        Me.tbl_TrnWriteoff_Temp.Columns("writeoff_inputby").DefaultValue = Me.UserName
        Me.tbl_TrnWriteoff_Temp.Columns("strukturunit_id_reportby").DefaultValue = Me._STRUKTUR_UNIT

        ' TODO: Set Default Value for tbl_TrnWriteoffdetil
        Me.tbl_TrnWriteoffdetil.Clear()
        Me.tbl_TrnWriteoffdetil = clsDataset.CreateTblTrnWriteoffdetil(Me._CHANNEL)
        Me.tbl_TrnWriteoffdetil.Columns("writeoff_id").DefaultValue = "AUTO"
        Me.DgvTrnWriteoffdetil.DataSource = Me.tbl_TrnWriteoffdetil

        Me.BindingContext(Me.tbl_TrnWriteoff_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnWriteoff_Temp).AddNew()
            Me.obj_Channel_id.SelectedValue = _CHANNEL
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function
    Private Function uiTrnwriteoff_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()
        criteria = String.Format(" strukturunit_id_reportby = {0}", Me._STRUKTUR_UNIT)

        If Me.chkStatus.Checked = True Then
            If Me.cboStatus.SelectedItem = "LOCK" Then
                criteria &= " AND lock = 1"
            ElseIf Me.cboStatus.SelectedItem = "NOT LOCK" Then
                criteria &= " AND lock = 0"
            Else
                MsgBox("Please choice item in status box")
            End If
        End If

        Me.tbl_TrnWriteoff.Clear()
        Try
            Me.DataFill(Me.tbl_TrnWriteoff, "as_TrnWriteoff_Select", criteria, Me.cboSearchChannel.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Function uiTrnwriteoff_Save() As Boolean
        'save data
        Dim tbl_TrnWriteoff_Temp_Changes As DataTable
        Dim tbl_TrnWriteoffdetil_Changes As DataTable
        Dim success As Boolean
        Dim writeoff_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(writeoff_id)

        Me.BindingContext(Me.tbl_TrnWriteoff_Temp).EndCurrentEdit()
        tbl_TrnWriteoff_Temp_Changes = Me.tbl_TrnWriteoff_Temp.GetChanges()

        Me.DgvTrnWriteoffdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnWriteoffdetil).EndCurrentEdit()
        tbl_TrnWriteoffdetil_Changes = Me.tbl_TrnWriteoffdetil.GetChanges()

        If tbl_TrnWriteoff_Temp_Changes IsNot Nothing Or tbl_TrnWriteoffdetil_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnWriteoff_Temp.Rows(0).RowState
                writeoff_id = tbl_TrnWriteoff_Temp.Rows(0).Item("writeoff_id")

                If tbl_TrnWriteoff_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnwriteoff_SaveMaster(writeoff_id, tbl_TrnWriteoff_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnwriteoff_SaveMaster(tbl_TrnWriteoff_Temp_Changes)")
                    Me.tbl_TrnWriteoff_Temp.AcceptChanges()
                End If

                If tbl_TrnWriteoffdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnWriteoffdetil.Rows.Count - 1
                        If Me.tbl_TrnWriteoffdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnWriteoffdetil.Rows(i).Item("writeoff_id") = writeoff_id
                        End If
                    Next
                    success = Me.uiTrnwriteoff_SaveDetil(writeoff_id, tbl_TrnWriteoffdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnwriteoff_SaveDetil(tbl_TrnWriteoffdetil_Changes)")
                    Me.tbl_TrnWriteoffdetil.AcceptChanges()
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

        RaiseEvent FormAfterSave(writeoff_id, result)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnwriteoff_SaveMaster(ByRef writeoff_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: transaksi_writeoff
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnWriteoff_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 30, "writeoff_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "writeoff_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_reportby", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_reportby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_reportby", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id_reportby", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_approvedby", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_approvedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_inputby", System.Data.OleDb.OleDbType.VarWChar, 30, "writeoff_inputby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "writeoff_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_internal_audit", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_internal_audit"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_procurement", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_procurement"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_accounting", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_accounting"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_frm_director", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_frm_director"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_president_director", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_president_director"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_commissioner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_commissioner"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner_dept_head", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner_dept_head"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner_div_head", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner_div_head"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner_director", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner_director"))
        dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnWriteoff_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 30, "writeoff_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "writeoff_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_reportby", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_reportby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_reportby", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id_reportby", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_approvedby", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_approvedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_inputby", System.Data.OleDb.OleDbType.VarWChar, 30, "writeoff_inputby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "writeoff_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_internal_audit", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_internal_audit"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_procurement", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_procurement"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_accounting", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_accounting"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_frm_director", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_frm_director"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_president_director", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_president_director"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_commissioner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_commissioner"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner_dept_head", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner_dept_head"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner_div_head", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner_div_head"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner_director", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner_director"))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            writeoff_id = objTbl.Rows(0).Item("writeoff_id")
            Me.tbl_TrnWriteoff_Temp.Clear()
            Me.tbl_TrnWriteoff_Temp.Merge(objTbl)

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
            Me.tbl_TrnWriteoff.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnWriteoff).Position
            Me.tbl_TrnWriteoff.Rows.RemoveAt(curpos)
            Me.tbl_TrnWriteoff.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnWriteoff).Position = Me.BindingContext(Me.tbl_TrnWriteoff).Count

        Return True
    End Function
    Private Function uiTrnwriteoff_SaveDetil(ByRef writeoff_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_writeoffdetil
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnWriteoffdetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "writeoff_tgl"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "writeoff_barcode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_hargaawal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "writeoff_hargaawal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id_akhir", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id_akhir", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_hargakhir", System.Data.OleDb.OleDbType.VarWChar, 10, "writeoff_hargakhir"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_writeoffby", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_writeoffby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_writeoffapp", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_writeoffapp"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_desc", System.Data.OleDb.OleDbType.VarWChar, 200, "writeoff_desc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@status_akhir", System.Data.OleDb.OleDbType.VarWChar, 10, "status_akhir"))
        dbCmdInsert.Parameters("@writeoff_id").Value = writeoff_id


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnWriteoffdetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "writeoff_tgl"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "writeoff_barcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_hargaawal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "writeoff_hargaawal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id_akhir", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id_akhir", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_hargakhir", System.Data.OleDb.OleDbType.VarWChar, 10, "writeoff_hargakhir"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_writeoffby", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_writeoffby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_writeoffapp", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_writeoffapp"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_reason", System.Data.OleDb.OleDbType.VarWChar, 200, "writeoff_reason"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@status_akhir", System.Data.OleDb.OleDbType.VarWChar, 10, "status_akhir"))
        dbCmdUpdate.Parameters("@writeoff_id").Value = writeoff_id


        dbCmdDelete = New OleDb.OleDbCommand("as_TrnWriteoffdetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "writeoff_barcode"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdDelete.Parameters("@writeoff_id").Value = writeoff_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


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

    Private Function uiTrnwriteoff_Delete() As Boolean
        Dim res As String = ""
        Dim writeoff_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(writeoff_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnWriteoff.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnwriteoff_DeleteRow(Me.DgvTrnWriteoff.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(writeoff_id)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnwriteoff_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim writeoff_id As String
        Dim NewRowIndex As Integer

        writeoff_id = Me.DgvTrnWriteoff.Rows(rowIndex).Cells("writeoff_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnWriteoff_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@writeoff_id").Value = writeoff_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@writeoff_dt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_reportby", System.Data.OleDb.OleDbType.VarWChar, 14))
        dbCmdDelete.Parameters("@employee_id_reportby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_reportby", System.Data.OleDb.OleDbType.VarWChar, 14))
        dbCmdDelete.Parameters("@strukturunit_id_reportby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_approvedby", System.Data.OleDb.OleDbType.VarWChar, 14))
        dbCmdDelete.Parameters("@employee_id_approvedby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_inputby", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@writeoff_inputby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@writeoff_date").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnWriteoff.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnwriteoff_OpenRow(NewRowIndex)
                    Me.tbl_TrnWriteoff.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnWriteoff.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnwriteoff_OpenRow(NewRowIndex)
                    Me.tbl_TrnWriteoff.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnWriteoff.Rows.RemoveAt(rowIndex)
                    Me.uiTrnwriteoff_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_TrnWriteoff_Temp.Clear()
                Me.tbl_TrnWriteoff.Rows.RemoveAt(rowIndex)

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
    Private Function uiTrnwriteoff_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim writeoff_id As String
        Dim channel_id As String

        writeoff_id = Me.DgvTrnWriteoff.Rows(rowIndex).Cells("writeoff_id").Value
        channel_id = Me.DgvTrnWriteoff.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(writeoff_id)

        If Me.obj_Writeoff_lock.Checked = True Then
            Me.PnlDataMaster.Enabled = False
            Me.Panel3.Enabled = False
            DgvTrnWriteoffdetil.AllowUserToDeleteRows = False
            Me.DgvTrnWriteoffdetil.Columns("writeoff_reason").ReadOnly = True
            Me.DgvTrnWriteoffdetil.Columns("writeoff_reason").DefaultCellStyle.BackColor = Color.White

        Else
            Me.PnlDataMaster.Enabled = True
            Me.Panel3.Enabled = True
            DgvTrnWriteoffdetil.AllowUserToDeleteRows = True
            Me.DgvTrnWriteoffdetil.Columns("writeoff_reason").ReadOnly = False
            Me.DgvTrnWriteoffdetil.Columns("writeoff_reason").DefaultCellStyle.BackColor = Color.Thistle

        End If

        Try
            dbConn.Open()
            Me.uiTrnwriteoff_OpenRowMaster(channel_id, writeoff_id, dbConn)
            Me.uiTrnwriteoff_OpenRowDetil(channel_id, writeoff_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnwriteoff_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(writeoff_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function
    Private Function uiTrnwriteoff_OpenRowMaster(ByVal channel_id As String, ByVal writeoff_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnWriteoff_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("writeoff_id='{0}'", writeoff_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnWriteoff_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnWriteoff_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnwriteoff_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnwriteoff_OpenRowDetil(ByVal channel_id As String, ByVal writeoff_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnWriteoffdetil_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("writeoff_id='{0}'", writeoff_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_TrnWriteoffdetil.Clear()
        Me.tbl_TrnWriteoffdetil = clsDataset.CreateTblTrnWriteoffdetil(_CHANNEL)
        Me.tbl_TrnWriteoffdetil.Columns("writeoff_id").DefaultValue = writeoff_id
        Me.tbl_TrnWriteoffdetil.Columns("writeoff_barcode").DefaultValue = "AUTO"

        Try
            dbDA.Fill(Me.tbl_TrnWriteoffdetil)
            Me.DgvTrnWriteoffdetil.DataSource = Me.tbl_TrnWriteoffdetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnwriteoff_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnwriteoff_First() As Boolean
        'goto first record found
        If Me.DgvTrnWriteoff.SelectedRows.Count <= 0 Then
            MsgBox("No data to choice")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnwriteoff_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnWriteoff.CurrentCell = Me.DgvTrnWriteoff(1, 0)
            Me.uiTrnwriteoff_RefreshPosition()
        End If
    End Function
    Private Function uiTrnwriteoff_Prev() As Boolean
        'goto previous record found
        If Me.DgvTrnWriteoff.SelectedRows.Count <= 0 Then
            MsgBox("No data to choice")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnwriteoff_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnWriteoff.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnWriteoff.CurrentCell = Me.DgvTrnWriteoff(1, DgvTrnWriteoff.CurrentCell.RowIndex - 1)
                Me.uiTrnwriteoff_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnwriteoff_Next() As Boolean
        'goto next record found
        If Me.DgvTrnWriteoff.SelectedRows.Count <= 0 Then
            MsgBox("No data to choice")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnwriteoff_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnWriteoff.CurrentCell.RowIndex < Me.DgvTrnWriteoff.Rows.Count - 1 Then
                Me.DgvTrnWriteoff.CurrentCell = Me.DgvTrnWriteoff(1, DgvTrnWriteoff.CurrentCell.RowIndex + 1)
                Me.uiTrnwriteoff_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnwriteoff_Last() As Boolean
        'goto last record found
        If Me.DgvTrnWriteoff.SelectedRows.Count <= 0 Then
            MsgBox("No data to choice")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnwriteoff_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnWriteoff.CurrentCell = Me.DgvTrnWriteoff(1, Me.DgvTrnWriteoff.Rows.Count - 1)
            Me.uiTrnwriteoff_RefreshPosition()
        End If
    End Function
    Private Function uiTrnwriteoff_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnwriteoff_OpenRow(Me.DgvTrnWriteoff.CurrentRow.Index)
    End Function
    Private Function uiTrnwriteoff_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnWriteoff_Temp_Changes As DataTable
        Dim tbl_TrnWriteoffdetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim writeoff_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult

        If Me.DgvTrnWriteoff.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnWriteoff_Temp).EndCurrentEdit()
            tbl_TrnWriteoff_Temp_Changes = Me.tbl_TrnWriteoff_Temp.GetChanges()

            Me.DgvTrnWriteoffdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnWriteoffdetil).EndCurrentEdit()
            tbl_TrnWriteoffdetil_Changes = Me.tbl_TrnWriteoffdetil.GetChanges()

            If tbl_TrnWriteoff_Temp_Changes IsNot Nothing Or tbl_TrnWriteoffdetil_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(writeoff_id)

                        Try

                            If tbl_TrnWriteoff_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnwriteoff_SaveMaster(writeoff_id, tbl_TrnWriteoff_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_TrnWriteoff_Temp.AcceptChanges()
                            End If

                            If tbl_TrnWriteoffdetil_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnWriteoffdetil.Rows.Count - 1
                                    If Me.tbl_TrnWriteoffdetil.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnWriteoffdetil.Rows(i).Item("writeoff_id") = writeoff_id
                                    End If
                                Next
                                success = Me.uiTrnwriteoff_SaveDetil(writeoff_id, tbl_TrnWriteoffdetil_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_TrnWriteoffdetil.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(writeoff_id, result)

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
    Private Function uiTrnwriteoff_FormError() As Boolean
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

#Region " Other User Defined Function "

    Private Function uiTrnBookasset_Saveke2() As Boolean

        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Try
            Dim dbCmdInsert As OleDb.OleDbCommand
            Dim kafir As String
            dbConn.Open()
            dbCmdInsert = New OleDb.OleDbCommand("as_TrnWriteoffdetil_Insert", dbConn)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 100).Value = _CHANNEL
            dbCmdInsert.Parameters.Add("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Trim(Me.DgvTrnWriteoff.Rows(Me.DgvTrnWriteoff.CurrentRow.Index).Cells("writeoff_id").Value)
            dbCmdInsert.Parameters.Add("@writeoff_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = CDate(Now)
            dbCmdInsert.Parameters.Add("@writeoff_barcode", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Trim(Me.TextBox1.Text)
            dbCmdInsert.Parameters.Add("@employee_id_writeoffapp", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.obj_Employee_id_approvedby.SelectedValue
            dbCmdInsert.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 2).Direction = ParameterDirection.Output
            dbCmdInsert.ExecuteNonQuery()
            kafir = CStr(dbCmdInsert.Parameters("@status").Value)
            'MsgBox(kafir)
            If kafir = "A" Then
                suaramenang = PanggilSuara(Application.StartupPath & "\Sound\Ok.wav")
                'suaramenang = PanggilSuara("C:\TransBrowser\Sound\Ok.wav")
                MainkanSuara(suaramenang, SND_SYNC Or SND_MEMORY)
            Else
                suaramenang = PanggilSuara(Application.StartupPath & "\Sound\Error.wav")
                'suaramenang = PanggilSuara("C:\TransBrowser\Sound\Error.wav")
                MainkanSuara(suaramenang, SND_SYNC Or SND_MEMORY)
            End If
            dbCmdInsert.Dispose()
            Me.uiTrnwriteoff_OpenRow(Me.DgvTrnWriteoff.CurrentRow.Index)
            'Me.uiTrnwriteoff_OpenRowDetil(_CHANNEL, Me.obj_Writeoff_id.Text, dbConn)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        Me.Cursor = Cursors.Arrow
    End Function

#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        Me.DgvTrnWriteoff.DataSource = Me.tbl_TrnWriteoff

        objParameters = Me.GetParameterCollection(Me.Parameter)
        If Application.ProductName = _ProductName Then
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
            Me._STRUKTUR_UNIT_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CANCHANGEDSU")
            Me._STRUKTUR_UNIT_CANDE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CANBROWSEDSU")
            Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
            Me._SU_ACCOUNTING = Me.GetValueFromParameter(objParameters, "SU_ACCOUNTING")
        End If
        'buat jebak pas jalan di browser
        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
        '    Dim dummyparameter As String = "CHANNEL_ID=TTV;STRUKTUR_UNIT=5565;CHANNELCHANGED=0;CHANNELBROWSED=0;CANCHANGEDSU=0;CANBROWSEDSU=0;SU_EMPLOYEE=9002000;SU_ACCOUNTING=1001000;"
        '    objParameters = Me.GetParameterCollection(dummyparameter)
        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL_ID")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
        '    Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
        '    Me._STRUKTUR_UNIT_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CANCHANGEDSU")
        '    Me._STRUKTUR_UNIT_CANDE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CANBROWSEDSU")
        '    Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        '    Me._SU_ACCOUNTING = Me.GetValueFromParameter(objParameters, "SU_ACCOUNTING")
        'End If

        ''Loading Buat ComboBox
        'Me.ComboFill(Me.obj_Channel_id, "channel_id", "channel_id", Me.tbl_MstChannel, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'", "")
        'Me.tbl_MstChannel.DefaultView.Sort = "channel_id"

        'bagian channel search 
        Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", Me.tbl_MstChannelSearch, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'")
        Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_id"

        ''bagian Struktur unit search coy
        Me.ComboFill(Me.obj_Strukturunit_id_pemilik_search, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitPelapor_search, "as_MstStrukturUnit_Select", "  ")
        Me.tbl_MstStrukturunitPelapor_search.DefaultView.Sort = "strukturunit_name"

        'Me.ComboFill(Me.obj_Employee_id_reportby, "employee_id", "employee_namalengkap", Me.tbl_Mstemployeepelapor, "ms_MstEmployee_Select", "  ")
        'Me.tbl_Mstemployeepelapor.DefaultView.Sort = "employee_namalengkap"
        'Me.ComboFill(Me.obj_Employee_id_approvedby, "employee_id", "employee_namalengkap", Me.tbl_Mstemployeeapprove, "ms_MstEmployee_Select", " strukturunit_id = " & Me._SU_ACCOUNTING)
        'Me.tbl_Mstemployeeapprove.DefaultView.Sort = "employee_namalengkap"


        Me.cboSearchChannel.SelectedValue = Me._CHANNEL
        Me.obj_Channel_id.SelectedValue = Me._CHANNEL
        Me.chkSearchChannel.Checked = True

        Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_CHANGED
        Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
        Me.obj_Channel_id.Enabled = Me._CHANNEL_CANBE_BROWSED

        Me.obj_Strukturunit_id_pemilik_search.SelectedValue = Me._STRUKTUR_UNIT
        Me.obj_Strukturunit_id_pemilik_search.Enabled = Me._STRUKTUR_UNIT_CANDE_BROWSED
        Me.chk_Strukturunit_id_pemilik_search.Enabled = Me._STRUKTUR_UNIT_CANBE_CHANGED
        Me.chk_Strukturunit_id_pemilik_search.Checked = True

        Me.obj_Strukturunit_id_reportby.Enabled = Me._STRUKTUR_UNIT_CANDE_BROWSED

        Me.InitLayoutUI()
        Me.BindingStop()
        Me.BindingStart()

        Me.uiTrnwriteoff_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

        Me.btnlock.ToolTipText = "Lock Transaction"
        Me.ToolStrip1.Items.Add(Me.btnlock)
        Me.btnlock.Image = Me.ImageList1.Images(0)

    End Sub

    Private Sub uiTrnwriteoff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If

    End Sub
    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.SeaShell
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.SeaShell

                If Me.DgvTrnWriteoff.CurrentRow IsNot Nothing Then
                    Me.uiTrnwriteoff_OpenRow(Me.DgvTrnWriteoff.CurrentRow.Index)
                Else
                    Me.uiTrnwriteoff_NewData()
                End If

        End Select
    End Sub
    Private Sub DgvTrnWriteoff_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnWriteoff.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnWriteoff.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar.ToString = Microsoft.VisualBasic.ChrW(13) Then

            If Trim(Me.obj_Writeoff_dt.Text) = "AUTO" Then
                MsgBox("Save Header Transaction First")
                Me.TextBox1.Text = "- - Item WriteOff - -"
                Exit Sub
            End If

            If Len(Trim(Me.TextBox1.Text)) >= 2 Then
                Me.Cursor = Cursors.WaitCursor
                Me.uiTrnBookasset_Saveke2()
                Me.Cursor = Cursors.Arrow
            Else
                MsgBox("Please Input Item", MsgBoxStyle.Information, "Warning")
                Me.TextBox1.Text = ""
                Me.TextBox1.Focus()
                Exit Sub
            End If
        End If
    End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        Me.TextBox1.Text = ""
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Me.TextBox1.Text = "- - Item WriteOff - -"
    End Sub
    Private Sub uiTrnTerimaBarang_LoadComboBox()
        'Sekarang bagian Header
        If Me._LoadComboInLoadData = False Then
            'Loading Buat ComboBox
            Me.ComboFill(Me.obj_Channel_id, "channel_id", "channel_id", Me.tbl_MstChannel, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'", "")
            Me.tbl_MstChannel.DefaultView.Sort = "channel_id"

            'bagian Struktur unit coy
            Me.ComboFill(Me.obj_Strukturunit_id_reportby, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitPelapor, "as_MstStrukturUnit_Select", "  ")
            Me.tbl_MstStrukturunitPelapor.DefaultView.Sort = "strukturunit_name"

            Me.ComboFill(Me.obj_Employee_id_reportby, "employee_id", "employee_namalengkap", Me.tbl_Mstemployeepelapor, "ms_MstEmployee_Select", " strukturunit_id = " & Me._SU_EMPLOYEE)
            Me.tbl_Mstemployeepelapor.DefaultView.Sort = "employee_namalengkap"
            Me.ComboFill(Me.obj_Employee_id_approvedby, "employee_id", "employee_namalengkap", Me.tbl_Mstemployeeapprove, "ms_MstEmployee_Select", " strukturunit_id = " & Me._SU_ACCOUNTING)
            Me.tbl_Mstemployeeapprove.DefaultView.Sort = "employee_namalengkap"

            Me.ComboFill(Me.obj_Employee_id_internal_audit, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeInternalAudit, "ms_MstEmployee_Select", " ")
            Me.tbl_MstEmployeeInternalAudit.DefaultView.Sort = "employee_namalengkap"


            Dim proc As Boolean
            Me.tbl_MstEmployeeProcurement = tbl_MstEmployeeInternalAudit.Copy
            proc = ComboFillFromDataTable(Me.obj_Employee_id_Procurement, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeProcurement)
            Me.tbl_MstEmployeeProcurement.DefaultView.Sort = "employee_namalengkap"

            Dim acc As Boolean
            Me.tbl_MstEmployeeAccounting = tbl_MstEmployeeInternalAudit.Copy
            acc = ComboFillFromDataTable(Me.obj_Employee_id_Accounting, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeAccounting)
            Me.tbl_MstEmployeeAccounting.DefaultView.Sort = "employee_namalengkap"

            Dim frmDirec As Boolean
            Me.tbl_MstEmployeeFRMdirector = tbl_MstEmployeeInternalAudit.Copy
            frmDirec = ComboFillFromDataTable(Me.obj_Employee_id_FRM_Director, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeFRMdirector)
            Me.tbl_MstEmployeeFRMdirector.DefaultView.Sort = "employee_namalengkap"

            Dim presDirec As Boolean
            Me.tbl_MstEmployeePresdirector = tbl_MstEmployeeInternalAudit.Copy
            presDirec = ComboFillFromDataTable(Me.obj_Employee_id_PresDirector, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeePresdirector)
            Me.tbl_MstEmployeePresdirector.DefaultView.Sort = "employee_namalengkap"

            Dim comm As Boolean
            Me.tbl_MstEmployeeCommissioner = tbl_MstEmployeeInternalAudit.Copy
            comm = ComboFillFromDataTable(Me.obj_Employee_id_commissioner, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeCommissioner)
            Me.tbl_MstEmployeeCommissioner.DefaultView.Sort = "employee_namalengkap"

            Dim dept_head As Boolean
            Me.tbl_MstEmployeeReportByDeptHead = tbl_MstEmployeeInternalAudit.Copy
            dept_head = ComboFillFromDataTable(Me.obj_Employee_id_reportby_deptHead, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeReportByDeptHead)
            Me.tbl_MstEmployeeReportByDeptHead.DefaultView.Sort = "employee_namalengkap"

            Dim div_head As Boolean
            Me.tbl_MstEmployeeReportByDivHead = tbl_MstEmployeeInternalAudit.Copy
            div_head = ComboFillFromDataTable(Me.obj_Employee_id_reportby_divHead, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeReportByDivHead)
            Me.tbl_MstEmployeeReportByDivHead.DefaultView.Sort = "employee_namalengkap"

            Dim director As Boolean
            Me.tbl_MstEmployeeReportByDirector = tbl_MstEmployeeInternalAudit.Copy
            director = ComboFillFromDataTable(Me.obj_Employee_id_reportby_director, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeReportByDirector)
            Me.tbl_MstEmployeeReportByDirector.DefaultView.Sort = "employee_namalengkap"

            Me._LoadComboInLoadData = True
        End If
    End Sub


    Private Sub Lock_data()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor


        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_Locktransaksi_writeoff", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnWriteoff.Rows(Me.DgvTrnWriteoff.CurrentRow.Index).Cells("writeoff_id").Value
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me._CHANNEL

            oCm.ExecuteNonQuery()
            oCm.Dispose()
            Me.obj_Writeoff_lock.Checked = True
            Me.DgvTrnWriteoff.Item("lock", DgvTrnWriteoff.CurrentRow.Index).Value = 1
            Me.PnlDataMaster.Enabled = False
            Me.Panel3.Enabled = False
            Me.DgvTrnWriteoffdetil.AllowUserToDeleteRows = False
            Me.uiTrnwriteoff_OpenRow(Me.DgvTrnWriteoff.CurrentRow.Index)
            MessageBox.Show("Data Has Been Locked", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Lock" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Lock" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub



    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()

        tbl_Print.Clear()
        tbl_PrintDetil.Clear()
        objPrintHeader = New DataSource.clsRptTrnWriteoff(Me.DSN)
        DataFill(tbl_Print, "as_TrnWriteoffReport_Select", " writeoff_id = '" & DgvTrnWriteoff.Item("writeoff_id", DgvTrnWriteoff.SelectedCells.Item(0).RowIndex).Value & "'", Me._CHANNEL)
        With objPrintHeader
            .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
            .writeoff_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("writeoff_id").ToString, String.Empty)
            .writeoff_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("writeoff_dt"), Now())
            .employee_id_reportby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_reportby").ToString, String.Empty)
            .strukturunit_id_reportby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_reportby"), 0)
            .employee_id_approvedby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_approvedby").ToString, String.Empty)
            .writeoff_inputby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("writeoff_inputby").ToString, String.Empty)
            .writeoff_date = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("writeoff_date"), Now())
            .lock = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("lock"), 0)

            .employee_id_internal_audit_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_internal_audit_string").ToString, String.Empty)
            .employee_id_procurement_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_procurement_string").ToString, String.Empty)
            .employee_id_accounting_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_accounting_string").ToString, String.Empty)
            .employee_id_frm_director_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_frm_director_string").ToString, String.Empty)
            .employee_id_president_director_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_president_director_string").ToString, String.Empty)
            .employee_id_commissioner_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_commissioner_string").ToString, String.Empty)
            .employee_id_reportby_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_reportby_string").ToString, String.Empty)
            .employee_id_owner_dept_head_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_owner_dept_head_string").ToString, String.Empty)
            .employee_id_owner_div_head_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_owner_div_head_string").ToString, String.Empty)
            .employee_id_owner_director_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_owner_director_string").ToString, String.Empty)


            DataFill(tbl_PrintDetil, "as_TrnWriteoffdetil_Select", "writeoff_id = '" & .writeoff_id & "'")

            Me.tempChannel_ID = .channel_id
            Me.tempChannel_nameReport = .channel_namereport
            Me.tempChannel_address = .channel_address
            Me.tempWriteOff_id = .writeoff_id

            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptTrnWriteoffDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptTrnWriteoffDetil(Me.DSN)
            With objDetil
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
                .writeoff_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_id").ToString, String.Empty)
                .writeoff_tgl = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_tgl"), Now())
                .writeoff_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_barcode").ToString, String.Empty)
                .currency_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id"), 0)
                .writeoff_hargaawal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_hargaawal"), 0)
                .currency_id_akhir = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id_akhir"), 0)
                .writeoff_hargakhir = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_hargakhir"), 0)
                .employee_id_writeoffby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_id_writeoffby").ToString, String.Empty)
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_id"), 0)
                .employee_id_writeoffapp = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_id_writeoffapp").ToString, String.Empty)
                .writeoff_reason = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_reason").ToString, String.Empty)
                .status_akhir = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("status_akhir").ToString, String.Empty)
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                .asset_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_line"), 0)
                .channel_id1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id1").ToString, String.Empty)
                .asset_tgl = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_tgl"), Now())
                .tipeasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("tipeasset_id").ToString, String.Empty)
                .kategoriasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("kategoriasset_id").ToString, String.Empty)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcode").ToString, String.Empty)
                .asset_lineinduk = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_lineinduk"), 0)
                .asset_barcodeinduk = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcodeinduk").ToString, String.Empty)
                .asset_serial = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_serial").ToString, String.Empty)
                .asset_produknumber = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_produknumber").ToString, String.Empty)
                .asset_model = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_model").ToString, String.Empty)
                .asset_deskripsi = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_deskripsi").ToString, String.Empty)
                .kategoriitem_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("kategoriitem_id").ToString, String.Empty)
                .tipeitem_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("tipeitem_id").ToString, String.Empty)
                .asset_golfiskal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_golfiskal").ToString, String.Empty)
                .asset_tipedepre = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_tipedepre").ToString, String.Empty)
                .asset_depre_enddt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_depre_enddt"), Now())
                .currency_id1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id1"), 0)
                .asset_harga = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_harga"), 0)
                .asset_hargabaru = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_hargabaru"), 0)
                .asset_ppn = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_ppn"), 0)
                .asset_pph = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_pph"), 0)
                .asset_disc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_disc"), 0)
                .asset_depresiasi = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_depresiasi"), 0)
                .asset_akum_val_depre = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_akum_val_depre"), 0)
                .asset_valas = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_valas"), 0)
                .asset_idrprice = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_idrprice"), 0)
                .strukturunit_id1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_id1"), 0)
                .employee_id_owner = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_id_owner").ToString, String.Empty)
                .brand_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand_id"), 0)
                .unit_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("unit_id"), 0)
                .asset_qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_qty"), 0)
                .material_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("material_id").ToString, String.Empty)
                .warna_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("warna_id").ToString, String.Empty)
                .ukuran_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ukuran_id").ToString, String.Empty)
                .jeniskelamin_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jeniskelamin_id").ToString, String.Empty)
                .show_id_cont_item = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("show_id_cont_item").ToString, String.Empty)
                .ruang_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ruang_id").ToString, String.Empty)
                .asset_rak = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_rak").ToString, String.Empty)
                .is_useable = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("is_useable"), 0)
                .asset_active = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_active"), 0)
                .asset_status = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_status").ToString, String.Empty)
                .project_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("project_id"), 0)
                .show_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("show_id").ToString, String.Empty)
                .asset_eps = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_eps").ToString, String.Empty)
                .wo_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("wo_id").ToString, String.Empty)
                .inputby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("inputby").ToString, String.Empty)
                .inputdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("inputdt"), Now())
                .editby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("editby").ToString, String.Empty)
                .editdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("editdt"), Now())
                .usedby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("usedby").ToString, String.Empty)
                .asset_deprebulanan = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_deprebulanan"), 0)
                .asset_stdepre = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_stdepre"), Now())
                .asset_eddepre = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_eddepre"), Now())
                .asset_deskripsi1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_deskripsi1").ToString, String.Empty)
                .asset_serial1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_serial1").ToString, String.Empty)
                .tipeitem_id1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("tipeitem_id1").ToString, String.Empty)
                .kategoriitem_id1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("kategoriitem_id1").ToString, String.Empty)
                .strukturunit_id_string = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_id_string").ToString, String.Empty)
                .employee_id_string = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_id_string").ToString, String.Empty)
                .currency_awal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_awal").ToString, String.Empty)
                .currency_akhir = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_akhir").ToString, String.Empty)
                .lokasi = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("lokasi").ToString, String.Empty)
                .line = (i + 1)
                .times = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("times"), 0)
                .nbv = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("nbv"), 0)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptTrnWriteoffDetil", objDatalistDetil))
    End Sub

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        Dim stream As System.IO.Stream
        Dim deviceInfo As String = _
        "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>8.5in</PageWidth>" & _
        "  <PageHeight>11.69in</PageHeight>" & _
        "  <MarginTop>0.5in</MarginTop>" & _
        "  <MarginLeft>0.2in</MarginLeft>" & _
        "  <MarginRight>0.2in</MarginRight>" & _
        "  <MarginBottom>0.5in</MarginBottom>" & _
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
        Dim stream As System.IO.Stream = New System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory & "Temp\" & name & "." & fileNameExtension, System.IO.FileMode.Create)

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
        'Const printerName As String = "Microsoft Office Document Image Writer"
        Dim printerName As String = printSet.PrinterName

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

    Private Function uiTrnwriteoff_Print() As Boolean
        If Me.DgvTrnWriteoff.SelectedRows.Count <= 0 Then
            MsgBox("No data selected")
            Exit Function
        End If

        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)

        objDatalistHeader = Me.GenerateDataHeader()

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.tempChannel_ID)
        Dim parRptChannel_nameReport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.tempChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.tempChannel_address)
        Dim parRptWrite_off As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("writeoffID", Me.tempWriteOff_id)

        objRdsH.Name = "ASSET_DataSource_clsRptTrnWriteoff"
        objRdsH.Value = objDatalistHeader

        objReportH.ReportEmbeddedResource = "ASSET.RptWriteOff.rdlc"
        objReportH.DataSources.Add(objRdsH)
        objReportH.EnableExternalImages = True
        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_nameReport, parRptChannel_address, parRptWrite_off})

        AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
        Export(objReportH)

        m_currentPageIndex = 0
        Print()
    End Function

    Private Function uiTrnwriteoff_PrintPreview() As Boolean
        If Me.DgvTrnWriteoff.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim writeoff_id As String
        writeoff_id = DgvTrnWriteoff.CurrentRow.Cells("writeoff_id").Value

        Dim frmPrint As dlgRptWriteOff = New dlgRptWriteOff(Me.DSN, Me.SptServer, Me._CHANNEL, Me.DgvTrnWriteoff.Rows(Me.DgvTrnWriteoff.CurrentRow.Index).Cells("writeoff_id").Value)
        Dim criteria As String = String.Empty

        frmPrint.ShowInTaskbar = False
        frmPrint.StartPosition = FormStartPosition.CenterParent

        criteria = " writeoff_id = '" & writeoff_id & "'"

        frmPrint.SetIDCriteria(criteria)
        frmPrint.ShowDialog(Me)
    End Function

    Private Sub DgvTrnWriteoff_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnWriteoff.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

        Try
            If objrow.Cells("lock").Value = 0 Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            Else
                objrow.DefaultCellStyle.BackColor = Color.Bisque
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        If chkStatus.Checked = True Then
            Me.cboStatus.Enabled = True
            Me.cboStatus.SelectedItem = "-- PILIH --"
        Else
            Me.cboStatus.Enabled = False
        End If
    End Sub
End Class
