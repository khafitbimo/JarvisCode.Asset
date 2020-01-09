Public Class uiTrnMoveAsset
    Private Const mUiName As String = "Asset Mutation"
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
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstStrukturunitMove As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_MstStrukturunitOld As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_MstStrukturunitNew As DataTable = clsDataset.CreateTblStrukturunitPemilik()

    Private tbl_MstEmployeeMoveReport As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_MstEmployeeMoveAcct As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_MstEmployeeMoveOld As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_MstEmployeeMoveNew As DataTable = clsDataset.CreateTblemployeepemilik()

    Private tbl_MstEmployeeOldDeptHead As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeeOldDivHead As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeeNewDeptHead As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeeNewDivHead As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstEmployeeAcc As DataTable = clsDataset.CreateTblemployeepemilik


    Private tbl_TrnMoveasset As DataTable = clsDataset.CreateTblTrnMoveasset()
    Private tbl_TrnMoveasset_Temp As DataTable = clsDataset.CreateTblTrnMoveasset()
    Private tbl_TrnMoveassetdetil As DataTable = clsDataset.CreateTblTrnMoveassetdetil()

    Private retStrukturunit_id As String
    Private retStrukturunit_idOld, retStrukturunit_idNew As String
    Private retEmployee_OldOwner, retEmployee_NewOwner As String

    Private suaramenang As String

    Private tbl_Print As DataTable = clsDataset.CreateTblTrnMoveasset
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnMoveassetdetil
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptMoveAsset
    Private objDatalistDetil As ArrayList

    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptMoveAsset_ID As String
    Private sptStrukturUnit As String

    Friend WithEvents btnlock As ToolStripButton = New ToolStripButton

#Region " Window Parameter "
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    Private _STRUKTUR_UNIT As Decimal = 5517
    Private _STRUKTUR_UNIT_CANBE_CHANGED As Boolean = False
    Private _SU_EMPLOYEE As String = "9002000"
    Private _SU_ACCOUNTING As String = "1001000"

    ' TODO: Buat variabel untuk menampung parameter window 
#End Region
#Region " Additional Overrides "
    Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlock.Click
        LockData()
    End Sub


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
        Me.uiTrnMoveAsset_NewData()
        Me.obj_Moveasset_strukturunit.SelectedValue = Me._STRUKTUR_UNIT
        Me.PnlDataMaster.Enabled = True
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function
    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMoveAsset_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnMoveAsset_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMoveAsset_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMoveAsset_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function
    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMoveAsset_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function
    Public Overrides Function btnDel_Click() As Boolean
        'Me.Cursor = Cursors.WaitCursor
        'Me.uiTrnMoveAsset_Delete()
        'Me.Cursor = Cursors.Arrow
        'Return MyBase.btnDel_Click()
    End Function
    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMoveAsset_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function
    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMoveAsset_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function
    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMoveAsset_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function
    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnMoveAsset_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnMoveasset(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnMoveasset Columns 
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_tgl As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_strukturunit As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_report As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_acct As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_old As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_old As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_new As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_new As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_remark As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_item As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_strukturunit_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_report_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_acct_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_old_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_old_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_new_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_new_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_lock As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cMoveasset_inputby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_inputdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_editby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_editdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_usedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_useddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 75
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cMoveasset_id.Name = "moveasset_id"
        cMoveasset_id.HeaderText = "Move Asset No"
        cMoveasset_id.DataPropertyName = "moveasset_id"
        cMoveasset_id.Width = 125
        cMoveasset_id.Visible = True
        cMoveasset_id.ReadOnly = False

        cMoveasset_tgl.Name = "moveasset_tgl"
        cMoveasset_tgl.HeaderText = "Date"
        cMoveasset_tgl.DataPropertyName = "moveasset_tgl"
        cMoveasset_tgl.Width = 125
        cMoveasset_tgl.Visible = True
        cMoveasset_tgl.ReadOnly = False

        cMoveasset_strukturunit.Name = "moveasset_strukturunit"
        cMoveasset_strukturunit.HeaderText = "Department"
        cMoveasset_strukturunit.DataPropertyName = "moveasset_strukturunit"
        cMoveasset_strukturunit.Width = 150
        cMoveasset_strukturunit.Visible = False
        cMoveasset_strukturunit.ReadOnly = False

        cMoveasset_report.Name = "moveasset_report"
        cMoveasset_report.HeaderText = "Report"
        cMoveasset_report.DataPropertyName = "moveasset_report"
        cMoveasset_report.Width = 150
        cMoveasset_report.Visible = False
        cMoveasset_report.ReadOnly = False

        cMoveasset_acct.Name = "moveasset_acct"
        cMoveasset_acct.HeaderText = "Accounting"
        cMoveasset_acct.DataPropertyName = "moveasset_acct"
        cMoveasset_acct.Width = 150
        cMoveasset_acct.Visible = False
        cMoveasset_acct.ReadOnly = False

        cEmployee_id_old.Name = "employee_id_old"
        cEmployee_id_old.HeaderText = "Old Employee"
        cEmployee_id_old.DataPropertyName = "employee_id_old"
        cEmployee_id_old.Width = 150
        cEmployee_id_old.Visible = False
        cEmployee_id_old.ReadOnly = False

        cStrukturunit_id_old.Name = "strukturunit_id_old"
        cStrukturunit_id_old.HeaderText = "Old Department"
        cStrukturunit_id_old.DataPropertyName = "strukturunit_id_old"
        cStrukturunit_id_old.Width = 150
        cStrukturunit_id_old.Visible = False
        cStrukturunit_id_old.ReadOnly = False

        cEmployee_id_new.Name = "employee_id_new"
        cEmployee_id_new.HeaderText = "New Employee"
        cEmployee_id_new.DataPropertyName = "employee_id_new"
        cEmployee_id_new.Width = 150
        cEmployee_id_new.Visible = False
        cEmployee_id_new.ReadOnly = False

        cStrukturunit_id_new.Name = "strukturunit_id_new"
        cStrukturunit_id_new.HeaderText = "Old Department"
        cStrukturunit_id_new.DataPropertyName = "strukturunit_id_new"
        cStrukturunit_id_new.Width = 150
        cStrukturunit_id_new.Visible = False
        cStrukturunit_id_new.ReadOnly = False

        cMoveasset_remark.Name = "moveasset_remark"
        cMoveasset_remark.HeaderText = "Remark"
        cMoveasset_remark.DataPropertyName = "moveasset_remark"
        cMoveasset_remark.Width = 200
        cMoveasset_remark.Visible = True
        cMoveasset_remark.ReadOnly = False

        cMoveasset_item.Name = "moveasset_item"
        cMoveasset_item.HeaderText = "Item"
        cMoveasset_item.DataPropertyName = "moveasset_item"
        cMoveasset_item.Width = 100
        cMoveasset_item.Visible = True
        cMoveasset_item.ReadOnly = False

        cMoveasset_strukturunit_string.Name = "Moveasset_strukturunit_string"
        cMoveasset_strukturunit_string.HeaderText = "Department"
        cMoveasset_strukturunit_string.DataPropertyName = "Moveasset_strukturunit_string"
        cMoveasset_strukturunit_string.Width = 150
        cMoveasset_strukturunit_string.Visible = True
        cMoveasset_strukturunit_string.ReadOnly = False

        cMoveasset_report_string.Name = "Moveasset_report_string"
        cMoveasset_report_string.HeaderText = "Report"
        cMoveasset_report_string.DataPropertyName = "Moveasset_report_string"
        cMoveasset_report_string.Width = 150
        cMoveasset_report_string.Visible = True
        cMoveasset_report_string.ReadOnly = False

        cMoveasset_acct_string.Name = "Moveasset_acct_string"
        cMoveasset_acct_string.HeaderText = "Accounting"
        cMoveasset_acct_string.DataPropertyName = "Moveasset_acct_string"
        cMoveasset_acct_string.Width = 150
        cMoveasset_acct_string.Visible = True
        cMoveasset_acct_string.ReadOnly = False

        cEmployee_id_old_string.Name = "Employee_id_old_string"
        cEmployee_id_old_string.HeaderText = "Old Employee"
        cEmployee_id_old_string.DataPropertyName = "Employee_id_old_string"
        cEmployee_id_old_string.Width = 150
        cEmployee_id_old_string.Visible = True
        cEmployee_id_old_string.ReadOnly = False

        cStrukturunit_id_old_string.Name = "Strukturunit_id_old_string"
        cStrukturunit_id_old_string.HeaderText = "Old Department"
        cStrukturunit_id_old_string.DataPropertyName = "Strukturunit_id_old_string"
        cStrukturunit_id_old_string.Width = 150
        cStrukturunit_id_old_string.Visible = True
        cStrukturunit_id_old_string.ReadOnly = False

        cEmployee_id_new_string.Name = "Employee_id_new_string"
        cEmployee_id_new_string.HeaderText = "New Employee"
        cEmployee_id_new_string.DataPropertyName = "Employee_id_new_string"
        cEmployee_id_new_string.Width = 150
        cEmployee_id_new_string.Visible = True
        cEmployee_id_new_string.ReadOnly = False

        cStrukturunit_id_new_string.Name = "Strukturunit_id_new_string"
        cStrukturunit_id_new_string.HeaderText = "New Department"
        cStrukturunit_id_new_string.DataPropertyName = "Strukturunit_id_new_string"
        cStrukturunit_id_new_string.Width = 150
        cStrukturunit_id_new_string.Visible = True
        cStrukturunit_id_new_string.ReadOnly = False

        cMoveasset_lock.Name = "moveasset_lock"
        cMoveasset_lock.HeaderText = "Lock"
        cMoveasset_lock.DataPropertyName = "moveasset_lock"
        cMoveasset_lock.Width = 35
        cMoveasset_lock.Visible = True
        cMoveasset_lock.ReadOnly = False

        cMoveasset_inputby.Name = "moveasset_inputby"
        cMoveasset_inputby.HeaderText = "Input By"
        cMoveasset_inputby.DataPropertyName = "moveasset_inputby"
        cMoveasset_inputby.Width = 150
        cMoveasset_inputby.Visible = True
        cMoveasset_inputby.ReadOnly = False

        cMoveasset_inputdt.Name = "moveasset_inputdt"
        cMoveasset_inputdt.HeaderText = "Input Date"
        cMoveasset_inputdt.DataPropertyName = "moveasset_inputdt"
        cMoveasset_inputdt.Width = 100
        cMoveasset_inputdt.Visible = True
        cMoveasset_inputdt.ReadOnly = False

        cMoveasset_editby.Name = "moveasset_editby"
        cMoveasset_editby.HeaderText = "Edit By"
        cMoveasset_editby.DataPropertyName = "moveasset_editby"
        cMoveasset_editby.Width = 150
        cMoveasset_editby.Visible = True
        cMoveasset_editby.ReadOnly = False

        cMoveasset_editdt.Name = "moveasset_edtdt"
        cMoveasset_editdt.HeaderText = "Edit Date"
        cMoveasset_editdt.DataPropertyName = "moveasset_edtdt"
        cMoveasset_editdt.Width = 100
        cMoveasset_editdt.Visible = True
        cMoveasset_editdt.ReadOnly = False

        cMoveasset_usedby.Name = "moveasset_usedby"
        cMoveasset_usedby.HeaderText = "Used By"
        cMoveasset_usedby.DataPropertyName = "moveasset_usedby"
        cMoveasset_usedby.Width = 150
        cMoveasset_usedby.Visible = True
        cMoveasset_usedby.ReadOnly = False

        cMoveasset_useddt.Name = "moveasset_useddt"
        cMoveasset_useddt.HeaderText = "Used Date"
        cMoveasset_useddt.DataPropertyName = "moveasset_useddt"
        cMoveasset_useddt.Width = 100
        cMoveasset_useddt.Visible = True
        cMoveasset_useddt.ReadOnly = False



        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cMoveasset_lock, cMoveasset_id, cChannel_id, cMoveasset_tgl, _
        cMoveasset_strukturunit, cMoveasset_report, cMoveasset_acct, _
        cEmployee_id_old, cStrukturunit_id_old, cEmployee_id_new, cStrukturunit_id_new, _
        cMoveasset_strukturunit_string, cMoveasset_report_string, _
        cMoveasset_acct_string, cEmployee_id_old_string, cStrukturunit_id_old_string, _
        cEmployee_id_new_string, cStrukturunit_id_new_string, cMoveasset_remark, _
        cMoveasset_item, cMoveasset_inputby, cMoveasset_inputdt, cMoveasset_editby, _
        cMoveasset_editdt, cMoveasset_usedby, cMoveasset_useddt})

        ' DgvTrnMoveasset Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function
    Private Function FormatDgvTrnMoveassetdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnMoveassetdetil
        Dim cChannel As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMoveasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLine As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_oldowner As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_idold As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_newowner As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_idnew As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRemark As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_olddetil_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_olddetil_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_newdetil_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_newdetil_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim csn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cdesk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim ctipe As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbrand As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cChannel.Name = "channel"
        cChannel.HeaderText = "Channel"
        cChannel.DataPropertyName = "channel"
        cChannel.Width = 75
        cChannel.Visible = False
        cChannel.ReadOnly = False

        cMoveasset_id.Name = "moveasset_id"
        cMoveasset_id.HeaderText = "Move Asset No"
        cMoveasset_id.DataPropertyName = "moveasset_id"
        cMoveasset_id.Width = 125
        cMoveasset_id.Visible = False
        cMoveasset_id.ReadOnly = False

        cLine.Name = "line"
        cLine.HeaderText = "Line"
        cLine.DataPropertyName = "line"
        cLine.Width = 50
        cLine.Visible = True
        cLine.ReadOnly = False

        cAsset_barcode.Name = "asset_barcode"
        cAsset_barcode.HeaderText = "Barcode"
        cAsset_barcode.DataPropertyName = "asset_barcode"
        cAsset_barcode.Width = 130
        cAsset_barcode.Visible = True
        cAsset_barcode.ReadOnly = False

        cEmployee_oldowner.Name = "employee_oldowner"
        cEmployee_oldowner.HeaderText = "Old Employee"
        cEmployee_oldowner.DataPropertyName = "employee_oldowner"
        cEmployee_oldowner.Width = 100
        cEmployee_oldowner.Visible = False
        cEmployee_oldowner.ReadOnly = False

        cStrukturunit_idold.Name = "strukturunit_idold"
        cStrukturunit_idold.HeaderText = "Old Department"
        cStrukturunit_idold.DataPropertyName = "strukturunit_idold"
        cStrukturunit_idold.Width = 100
        cStrukturunit_idold.Visible = False
        cStrukturunit_idold.ReadOnly = False

        cEmployee_newowner.Name = "employee_newowner"
        cEmployee_newowner.HeaderText = "New Employee"
        cEmployee_newowner.DataPropertyName = "employee_newowner"
        cEmployee_newowner.Width = 100
        cEmployee_newowner.Visible = False
        cEmployee_newowner.ReadOnly = False

        cStrukturunit_idnew.Name = "strukturunit_idnew"
        cStrukturunit_idnew.HeaderText = "New Department"
        cStrukturunit_idnew.DataPropertyName = "strukturunit_idnew"
        cStrukturunit_idnew.Width = 100
        cStrukturunit_idnew.Visible = False
        cStrukturunit_idnew.ReadOnly = False

        cAsset_status.Name = "asset_status"
        cAsset_status.HeaderText = "Status"
        cAsset_status.DataPropertyName = "asset_status"
        cAsset_status.Width = 100
        cAsset_status.Visible = True
        cAsset_status.ReadOnly = False

        cRemark.Name = "remark"
        cRemark.HeaderText = "Remark"
        cRemark.DataPropertyName = "remark"
        cRemark.Width = 200
        cRemark.Visible = True
        cRemark.ReadOnly = False

        cEmployee_id_olddetil_string.Name = "Employee_id_olddetil_string"
        cEmployee_id_olddetil_string.HeaderText = "Old Employee"
        cEmployee_id_olddetil_string.DataPropertyName = "Employee_id_olddetil_string"
        cEmployee_id_olddetil_string.Width = 150
        cEmployee_id_olddetil_string.Visible = True
        cEmployee_id_olddetil_string.ReadOnly = False

        cStrukturunit_id_olddetil_string.Name = "Strukturunit_id_olddetil_string"
        cStrukturunit_id_olddetil_string.HeaderText = "Old Departement"
        cStrukturunit_id_olddetil_string.DataPropertyName = "Strukturunit_id_olddetil_string"
        cStrukturunit_id_olddetil_string.Width = 150
        cStrukturunit_id_olddetil_string.Visible = True
        cStrukturunit_id_olddetil_string.ReadOnly = False

        cEmployee_id_newdetil_string.Name = "employee_id_newdetil_string"
        cEmployee_id_newdetil_string.HeaderText = "New Employee"
        cEmployee_id_newdetil_string.DataPropertyName = "employee_id_newdetil_string"
        cEmployee_id_newdetil_string.Width = 150
        cEmployee_id_newdetil_string.Visible = True
        cEmployee_id_newdetil_string.ReadOnly = False

        cStrukturunit_id_newdetil_string.Name = "strukturunit_id_newdetil_string"
        cStrukturunit_id_newdetil_string.HeaderText = "New Departement"
        cStrukturunit_id_newdetil_string.DataPropertyName = "strukturunit_id_newdetil_string"
        cStrukturunit_id_newdetil_string.Width = 150
        cStrukturunit_id_newdetil_string.Visible = True
        cStrukturunit_id_newdetil_string.ReadOnly = False

        csn.Name = "sn"
        csn.HeaderText = "S/N"
        csn.DataPropertyName = "sn"
        csn.Width = 125
        csn.Visible = False
        csn.ReadOnly = False

        cdesk.Name = "desk"
        cdesk.HeaderText = "Description"
        cdesk.DataPropertyName = "desk"
        cdesk.Width = 250
        cdesk.Visible = False
        cdesk.ReadOnly = False

        ctipe.Name = "tipe"
        ctipe.HeaderText = "Type"
        ctipe.DataPropertyName = "tipe"
        ctipe.Width = 150
        ctipe.Visible = False
        ctipe.ReadOnly = False

        cbrand.Name = "brand"
        cbrand.HeaderText = "Brand"
        cbrand.DataPropertyName = "brand"
        cbrand.Width = 200
        cbrand.Visible = False
        cbrand.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cLine, cAsset_barcode, cEmployee_oldowner, cStrukturunit_idold, cEmployee_newowner, _
        cStrukturunit_idnew, cEmployee_id_olddetil_string, _
        cStrukturunit_id_olddetil_string, cEmployee_id_newdetil_string, _
        cChannel, cMoveasset_id, cStrukturunit_id_newdetil_string, cAsset_status, _
        cRemark, csn, cdesk, ctipe, cbrand})

        objDgv.AllowUserToAddRows = True
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = False
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
        Me.DgvTrnMoveasset.Dock = DockStyle.Fill

        Me.FormatDgvTrnMoveasset(Me.DgvTrnMoveasset)
        Me.FormatDgvTrnMoveassetdetil(Me.DgvTrnMoveassetdetil)

    End Function
    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Moveasset_id.DataBindings.Clear()
        Me.obj_Moveasset_tgl.DataBindings.Clear()
        Me.obj_Moveasset_strukturunit.DataBindings.Clear()
        Me.obj_Moveasset_report.DataBindings.Clear()
        Me.obj_Moveasset_acct.DataBindings.Clear()
        Me.obj_Employee_id_old.DataBindings.Clear()
        Me.obj_Strukturunit_id_old.DataBindings.Clear()
        Me.obj_Employee_id_new.DataBindings.Clear()
        Me.obj_Strukturunit_id_new.DataBindings.Clear()
        Me.obj_Moveasset_remark.DataBindings.Clear()
        Me.obj_Moveasset_item.DataBindings.Clear()
        Me.obj_Moveasset_Lock.DataBindings.Clear()
        Me.obj_Moveasset_inputby.DataBindings.Clear()
        Me.obj_Moveasset_inputdt.DataBindings.Clear()
        Me.obj_Moveasset_editby.DataBindings.Clear()
        Me.obj_Moveasset_editdt.DataBindings.Clear()
        Me.obj_Moveasset_usedby.DataBindings.Clear()
        Me.obj_Moveasset_useddt.DataBindings.Clear()
        Me.obj_Employee_deptHead_old.DataBindings.Clear()
        Me.obj_Employee_divHead_old.DataBindings.Clear()
        Me.obj_Employee_deptHead_new.DataBindings.Clear()
        Me.obj_Employee_divHead_new.DataBindings.Clear()
        Me.obj_Employee_Acc.DataBindings.Clear()
        Return True
    End Function
    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Channel_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnMoveasset_Temp, "channel_id"))
        Me.obj_Moveasset_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnMoveasset_Temp, "moveasset_id"))
        Me.obj_Moveasset_tgl.DataBindings.Add(New Binding("Text", Me.tbl_TrnMoveasset_Temp, "moveasset_tgl"))
        Me.obj_Moveasset_strukturunit.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "moveasset_strukturunit", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Moveasset_report.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "moveasset_report"))
        Me.obj_Moveasset_acct.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "moveasset_acct"))
        Me.obj_Employee_id_old.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "employee_id_old"))
        Me.obj_Strukturunit_id_old.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "strukturunit_id_old", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Employee_id_new.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "employee_id_new"))
        Me.obj_Strukturunit_id_new.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "strukturunit_id_new", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Moveasset_remark.DataBindings.Add(New Binding("Text", Me.tbl_TrnMoveasset_Temp, "moveasset_remark"))
        Me.obj_Moveasset_item.DataBindings.Add(New Binding("Text", Me.tbl_TrnMoveasset_Temp, "moveasset_item"))
        Me.obj_Moveasset_Lock.DataBindings.Add(New Binding("Checked", Me.tbl_TrnMoveasset, "moveasset_lock"))
        Me.obj_Moveasset_inputby.DataBindings.Add(New Binding("Text", Me.tbl_TrnMoveasset_Temp, "moveasset_inputby"))
        Me.obj_Moveasset_inputdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnMoveasset_Temp, "moveasset_inputdt"))
        Me.obj_Moveasset_editby.DataBindings.Add(New Binding("Text", Me.tbl_TrnMoveasset_Temp, "moveasset_editby"))
        Me.obj_Moveasset_editdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnMoveasset_Temp, "moveasset_editdt"))
        Me.obj_Moveasset_usedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnMoveasset_Temp, "moveasset_usedby"))
        Me.obj_Moveasset_useddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnMoveasset_Temp, "moveasset_useddt"))
        Me.obj_Employee_deptHead_old.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "employee_old_depthead"))
        Me.obj_Employee_divHead_old.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "employee_old_divhead"))
        Me.obj_Employee_deptHead_new.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "employee_new_depthead"))
        Me.obj_Employee_divHead_new.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "employee_new_divhead"))
        Me.obj_Employee_Acc.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnMoveasset_Temp, "employee_acc"))
        Return True
    End Function

#End Region

#Region " Dialoged Control "
#End Region

#Region " User Defined Function "

    Private Function uiTrnMoveAsset_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnMoveasset_Temp
        Me.tbl_TrnMoveasset_Temp.Clear()

        Me.tbl_TrnMoveasset_Temp.Columns("channel_id").DefaultValue = _CHANNEL
        Me.tbl_TrnMoveasset_Temp.Columns("moveasset_id").DefaultValue = "AUTO"
        Me.tbl_TrnMoveasset_Temp.Columns("moveasset_tgl").DefaultValue = Now
        Me.tbl_TrnMoveasset_Temp.Columns("moveasset_strukturunit").DefaultValue = 0
        Me.tbl_TrnMoveasset_Temp.Columns("moveasset_report").DefaultValue = "0"
        Me.tbl_TrnMoveasset_Temp.Columns("moveasset_acct").DefaultValue = "0"
        Me.tbl_TrnMoveasset_Temp.Columns("employee_id_old").DefaultValue = "0"
        Me.tbl_TrnMoveasset_Temp.Columns("strukturunit_id_old").DefaultValue = 0
        Me.tbl_TrnMoveasset_Temp.Columns("employee_id_new").DefaultValue = "0"
        Me.tbl_TrnMoveasset_Temp.Columns("strukturunit_id_new").DefaultValue = 0
        Me.tbl_TrnMoveasset_Temp.Columns("moveasset_remark").DefaultValue = String.Empty
        Me.tbl_TrnMoveasset_Temp.Columns("moveasset_item").DefaultValue = 0

        ' TODO: Set Default Value for tbl_TrnMoveassetdetil
        Me.tbl_TrnMoveassetdetil.Clear()
        Me.tbl_TrnMoveassetdetil = clsDataset.CreateTblTrnMoveassetdetil()
        Me.tbl_TrnMoveassetdetil.Columns("moveasset_id").DefaultValue = 0
        Me.tbl_TrnMoveassetdetil.Columns("line").DefaultValue = DBNull.Value
        Me.tbl_TrnMoveassetdetil.Columns("line").AutoIncrement = True
        Me.tbl_TrnMoveassetdetil.Columns("line").AutoIncrementSeed = 1
        Me.tbl_TrnMoveassetdetil.Columns("line").AutoIncrementStep = 1

        Me.DgvTrnMoveassetdetil.DataSource = Me.tbl_TrnMoveassetdetil

        Me.FormatDgvTrnMoveassetdetil(Me.DgvTrnMoveassetdetil)

        Me.obj_Employee_id_old.Enabled = True
        Me.obj_Strukturunit_id_old.Enabled = True
        Me.obj_Strukturunit_id_new.Enabled = True
        Me.obj_Employee_id_new.Enabled = True

        Me.BindingContext(Me.tbl_TrnMoveasset_Temp).EndCurrentEdit()

        Try
            Me.BindingContext(Me.tbl_TrnMoveasset_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function
    Private Function uiTrnMoveAsset_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        'criteria = string.Format("

        If Me.chkStatus.Checked = True Then
            If Me.cboStatus.SelectedItem = "LOCK" Then
                criteria = " AND moveasset_lock = 1"
            ElseIf Me.cboStatus.SelectedItem = "NOT LOCK" Then
                criteria = " AND moveasset_lock = 0"
            Else
                MsgBox("Please choice item in status box")
            End If
        End If

        ' TODO: Parse Criteria using clsProc.RefParser()
        Me.tbl_TrnMoveasset.Clear()
        Try
            Me.DataFill(Me.tbl_TrnMoveasset, "as_TrnMoveasset_Select", criteria, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Function uiTrnMoveAsset_Save() As Boolean
        'save data
        Dim tbl_TrnMoveasset_Temp_Changes As DataTable
        Dim tbl_TrnMoveassetdetil_Changes As DataTable
        Dim success As Boolean
        Dim moveasset_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(moveasset_id)

        Me.BindingContext(Me.tbl_TrnMoveasset_Temp).EndCurrentEdit()
        tbl_TrnMoveasset_Temp_Changes = Me.tbl_TrnMoveasset_Temp.GetChanges()

        Me.DgvTrnMoveassetdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnMoveassetdetil).EndCurrentEdit()
        tbl_TrnMoveassetdetil_Changes = Me.tbl_TrnMoveassetdetil.GetChanges()

        If tbl_TrnMoveasset_Temp_Changes IsNot Nothing Or tbl_TrnMoveassetdetil_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnMoveasset_Temp.Rows(0).RowState
                moveasset_id = tbl_TrnMoveasset_Temp.Rows(0).Item("moveasset_id")

                If tbl_TrnMoveasset_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnMoveAsset_SaveMaster(moveasset_id, tbl_TrnMoveasset_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnMoveAsset_SaveMaster(tbl_TrnMoveasset_Temp_Changes)")
                    Me.tbl_TrnMoveasset_Temp.AcceptChanges()
                End If

                If tbl_TrnMoveassetdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnMoveassetdetil.Rows.Count - 1
                        If Me.tbl_TrnMoveassetdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnMoveassetdetil.Rows(i).Item("moveasset_id") = moveasset_id
                        End If
                    Next
                    success = Me.uiTrnMoveAsset_SaveDetil(moveasset_id, tbl_TrnMoveassetdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnMoveAsset_SaveDetil(tbl_TrnMoveassetdetil_Changes)")
                    Me.tbl_TrnMoveassetdetil.AcceptChanges()
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

        RaiseEvent FormAfterSave(moveasset_id, result)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnMoveAsset_SaveMaster(ByRef moveasset_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: transaksi_moveasset
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnMoveasset_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "moveasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "moveasset_tgl"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_strukturunit", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "moveasset_strukturunit", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_report", System.Data.OleDb.OleDbType.VarWChar, 30, "moveasset_report"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_acct", System.Data.OleDb.OleDbType.VarWChar, 30, "moveasset_acct"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_old", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_old"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_old", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "strukturunit_id_old", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_new", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_new"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_new", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id_new", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_remark", System.Data.OleDb.OleDbType.VarWChar, 100, "moveasset_remark"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_item", System.Data.OleDb.OleDbType.Integer, 4, "moveasset_item"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_inputby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_editby", System.Data.OleDb.OleDbType.VarWChar, 100, "moveasset_editby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "moveasset_editdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_usedby", System.Data.OleDb.OleDbType.VarWChar, 100, "moveasset_usedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "moveasset_useddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_old_depthead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_old_depthead"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_old_divhead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_old_divhead"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_new_depthead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_new_depthead"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_new_divhead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_new_divhead"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_acc", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_acc"))
        dbCmdInsert.Parameters("@moveasset_inputby").Value = Me.UserName
        dbCmdInsert.Parameters("@moveasset_inputdt").Value = Now

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnMoveasset_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "moveasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "moveasset_tgl"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_strukturunit", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "moveasset_strukturunit", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_report", System.Data.OleDb.OleDbType.VarWChar, 30, "moveasset_report"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_acct", System.Data.OleDb.OleDbType.VarWChar, 30, "moveasset_acct"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_old", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_old"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_old", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "strukturunit_id_old", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_new", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_new"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_new", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id_new", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_remark", System.Data.OleDb.OleDbType.VarWChar, 100, "moveasset_remark"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_item", System.Data.OleDb.OleDbType.Integer, 4, "moveasset_item"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_inputby", System.Data.OleDb.OleDbType.VarWChar, 100, "moveasset_inputby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "moveasset_inputdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_editby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_usedby", System.Data.OleDb.OleDbType.VarWChar, 100, "moveasset_usedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "moveasset_useddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_old_depthead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_old_depthead"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_old_divhead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_old_divhead"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_new_depthead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_new_depthead"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_new_divhead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_new_divhead"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_acc", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_acc"))
        dbCmdUpdate.Parameters("@moveasset_editby").Value = Me.UserName
        dbCmdUpdate.Parameters("@moveasset_editdt").Value = Now

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            moveasset_id = objTbl.Rows(0).Item("moveasset_id")
            Me.tbl_TrnMoveasset_Temp.Clear()
            Me.tbl_TrnMoveasset_Temp.Merge(objTbl)

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
            Me.tbl_TrnMoveasset.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnMoveasset).Position
            Me.tbl_TrnMoveasset.Rows.RemoveAt(curpos)
            Me.tbl_TrnMoveasset.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnMoveasset).Position = Me.BindingContext(Me.tbl_TrnMoveasset).Count

        Return True
    End Function
    Private Function uiTrnMoveAsset_SaveDetil(ByRef moveasset_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_moveassetdetil
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnMoveassetdetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel", System.Data.OleDb.OleDbType.VarWChar, 20, "channel"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_oldowner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_oldowner"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_idold", System.Data.OleDb.OleDbType.VarWChar, 30, "strukturunit_idold"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_newowner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_newowner"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_idnew", System.Data.OleDb.OleDbType.VarWChar, 30, "strukturunit_idnew"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@remark", System.Data.OleDb.OleDbType.VarWChar, 200, "remark"))
        dbCmdInsert.Parameters("@moveasset_id").Value = moveasset_id

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnMoveassetdetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel", System.Data.OleDb.OleDbType.VarWChar, 20, "channel"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_oldowner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_oldowner"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_idold", System.Data.OleDb.OleDbType.VarWChar, 30, "strukturunit_idold"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_newowner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_newowner"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_idnew", System.Data.OleDb.OleDbType.VarWChar, 30, "strukturunit_idnew"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@remark", System.Data.OleDb.OleDbType.VarWChar, 200, "remark"))
        dbCmdUpdate.Parameters("@moveasset_id").Value = moveasset_id

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnMoveassetdetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel", System.Data.OleDb.OleDbType.VarWChar, 20, "channel"))
        dbCmdDelete.Parameters("@moveasset_id").Value = moveasset_id

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
    Private Function uiTrnMoveAsset_Delete() As Boolean
        Dim res As String = ""
        Dim moveasset_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(moveasset_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnMoveasset.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnMoveAsset_DeleteRow(Me.DgvTrnMoveasset.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(moveasset_id)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnMoveAsset_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim moveasset_id As String
        Dim NewRowIndex As Integer

        moveasset_id = Me.DgvTrnMoveasset.Rows(rowIndex).Cells("moveasset_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnMoveasset_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@moveasset_id").Value = moveasset_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@moveasset_tgl").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_strukturunit", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@moveasset_strukturunit").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_report", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@moveasset_report").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_acct", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@moveasset_acct").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_old", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@employee_id_old").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_old", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@strukturunit_id_old").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_new", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@employee_id_new").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_new", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@strukturunit_id_new").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_remark", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@moveasset_remark").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@moveasset_item", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@moveasset_item").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnMoveasset.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnMoveAsset_OpenRow(NewRowIndex)
                    Me.tbl_TrnMoveasset.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnMoveasset.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnMoveAsset_OpenRow(NewRowIndex)
                    Me.tbl_TrnMoveasset.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnMoveasset.Rows.RemoveAt(rowIndex)
                    Me.uiTrnMoveAsset_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_TrnMoveasset_Temp.Clear()
                Me.tbl_TrnMoveasset.Rows.RemoveAt(rowIndex)

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
    Private Function uiTrnMoveAsset_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim moveasset_id As String
        Dim channel_id As String

        moveasset_id = Me.DgvTrnMoveasset.Rows(rowIndex).Cells("moveasset_id").Value
        channel_id = Me.DgvTrnMoveasset.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(moveasset_id)

        Try
            dbConn.Open()
            Me.uiTrnMoveAsset_OpenRowMaster(channel_id, moveasset_id, dbConn)
            Me.uiTrnMoveAsset_OpenRowDetil(channel_id, moveasset_id, dbConn)

            If Me.obj_Moveasset_Lock.Checked = True Then
                Me.PnlDataMaster.Enabled = False
                Me.DgvTrnMoveassetdetil.AllowUserToDeleteRows = False
            Else
                Me.PnlDataMaster.Enabled = True
                Me.DgvTrnMoveassetdetil.AllowUserToDeleteRows = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnMoveAsset_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(moveasset_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function
    Private Function uiTrnMoveAsset_OpenRowMaster(ByVal channel_id As String, ByVal moveasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnMoveasset_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("and moveasset_id='{0}'", moveasset_id)
        dbCmd.Parameters.Add("@top", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@top").Value = Me.NumericUpDown1.Value
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnMoveasset_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnMoveasset_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnMoveAsset_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnMoveAsset_OpenRowDetil(ByVal channel_id As String, ByVal moveasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnMoveassetdetil_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("moveasset_id='{0}'", moveasset_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnMoveassetdetil.Clear()

        Me.tbl_TrnMoveassetdetil = clsDataset.CreateTblTrnMoveassetdetil()
        Me.tbl_TrnMoveassetdetil.Columns("moveasset_id").DefaultValue = moveasset_id
        Me.tbl_TrnMoveassetdetil.Columns("line").DefaultValue = DBNull.Value
        Me.tbl_TrnMoveassetdetil.Columns("line").AutoIncrement = True
        Me.tbl_TrnMoveassetdetil.Columns("line").AutoIncrementSeed = 1
        Me.tbl_TrnMoveassetdetil.Columns("line").AutoIncrementStep = 1

        Try
            dbDA.Fill(Me.tbl_TrnMoveassetdetil)
            Me.DgvTrnMoveassetdetil.DataSource = Me.tbl_TrnMoveassetdetil
            If Me.tbl_TrnMoveassetdetil.Rows.Count = 0 Then
                Me.obj_Employee_id_old.Enabled = True
                Me.obj_Strukturunit_id_old.Enabled = True
                Me.obj_Strukturunit_id_new.Enabled = True
                Me.obj_Employee_id_new.Enabled = True
            Else
                Me.obj_Employee_id_old.Enabled = False
                Me.obj_Strukturunit_id_old.Enabled = False
                Me.obj_Strukturunit_id_new.Enabled = False
                Me.obj_Employee_id_new.Enabled = False
            End If
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnMoveAsset_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnMoveAsset_First() As Boolean
        'goto first record found
        If Me.DgvTrnMoveasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnMoveAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnMoveasset.CurrentCell = Me.DgvTrnMoveasset(1, 0)
            Me.uiTrnMoveAsset_RefreshPosition()
        End If
    End Function
    Private Function uiTrnMoveAsset_Prev() As Boolean
        'goto previous record found
        If Me.DgvTrnMoveasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnMoveAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnMoveasset.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnMoveasset.CurrentCell = Me.DgvTrnMoveasset(1, DgvTrnMoveasset.CurrentCell.RowIndex - 1)
                Me.uiTrnMoveAsset_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnMoveAsset_Next() As Boolean
        'goto next record found
        If Me.DgvTrnMoveasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnMoveAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnMoveasset.CurrentCell.RowIndex < Me.DgvTrnMoveasset.Rows.Count - 1 Then
                Me.DgvTrnMoveasset.CurrentCell = Me.DgvTrnMoveasset(1, DgvTrnMoveasset.CurrentCell.RowIndex + 1)
                Me.uiTrnMoveAsset_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnMoveAsset_Last() As Boolean
        'goto last record found
        If Me.DgvTrnMoveasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnMoveAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnMoveasset.CurrentCell = Me.DgvTrnMoveasset(1, Me.DgvTrnMoveasset.Rows.Count - 1)
            Me.uiTrnMoveAsset_RefreshPosition()
        End If
    End Function
    Private Function uiTrnMoveAsset_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnMoveAsset_OpenRow(Me.DgvTrnMoveasset.CurrentRow.Index)
    End Function
    Private Function uiTrnMoveAsset_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnMoveasset_Temp_Changes As DataTable
        Dim tbl_TrnMoveassetdetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim moveasset_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult

        If Me.DgvTrnMoveasset.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnMoveasset_Temp).EndCurrentEdit()
            tbl_TrnMoveasset_Temp_Changes = Me.tbl_TrnMoveasset_Temp.GetChanges()

            Me.DgvTrnMoveassetdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnMoveassetdetil).EndCurrentEdit()
            tbl_TrnMoveassetdetil_Changes = Me.tbl_TrnMoveassetdetil.GetChanges()

            If tbl_TrnMoveasset_Temp_Changes IsNot Nothing Or tbl_TrnMoveassetdetil_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(moveasset_id)

                        Try

                            If tbl_TrnMoveasset_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnMoveAsset_SaveMaster(moveasset_id, tbl_TrnMoveasset_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_TrnMoveasset_Temp.AcceptChanges()
                            End If

                            If tbl_TrnMoveassetdetil_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnMoveassetdetil.Rows.Count - 1
                                    If Me.tbl_TrnMoveassetdetil.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnMoveassetdetil.Rows(i).Item("moveasset_id") = moveasset_id
                                    End If
                                Next
                                success = Me.uiTrnMoveAsset_SaveDetil(moveasset_id, tbl_TrnMoveassetdetil_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_TrnMoveassetdetil.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(moveasset_id, result)

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
    Private Function uiTrnMoveAsset_FormError() As Boolean
        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error") 
            Dim i As Integer
            Dim message As String = ""
            Dim cell_barcode As DataGridViewCell
            Dim dgv_error, row_error As Boolean
            Me.DgvTrnMoveassetdetil.AllowUserToAddRows = False
            For i = 0 To Me.DgvTrnMoveassetdetil.Rows.Count - 1
                row_error = False
                message = "Barcode belum diisi"
                cell_barcode = Me.DgvTrnMoveassetdetil.Rows(i).Cells("asset_barcode")
                If cell_barcode.Value IsNot DBNull.Value Then
                    If cell_barcode.Value = "" Then
                        cell_barcode.ErrorText = message
                        row_error = True
                    Else
                        cell_barcode.ErrorText = ""
                    End If
                Else
                    cell_barcode.ErrorText = message
                    row_error = True
                End If


                If row_error Then
                    dgv_error = True
                    Me.DgvTrnMoveassetdetil.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                Else
                    Me.DgvTrnMoveassetdetil.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")

            Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
            Me._STRUKTUR_UNIT_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CANCHANGEDSU")
            Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
            Me._SU_ACCOUNTING = Me.GetValueFromParameter(objParameters, "SU_ACCOUNTING")
        End If

        Me.DgvTrnMoveasset.DataSource = Me.tbl_TrnMoveasset
        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
        '    'Fill Combobox
        '    'dan fungsi2 startup lainnya....
        '    Dim dummyparameter As String = "CHANNEL_ID=TTV;CHANNELCHANGED=0;CHANNELBROWSED=0;STRUKTUR_UNIT=5517;CANCHANGEDSU=0;SU_EMPLOYEE=9002000;SU_ACCOUNTING=1001000;"
        '    objParameters = Me.GetParameterCollection(dummyparameter)
        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL_ID")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
        '    Me._STRUKTUR_UNIT = Me.GetValueFromParameter(objParameters, "STRUKTUR_UNIT")
        '    Me._STRUKTUR_UNIT_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CANCHANGEDSU")
        '    Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        '    Me._SU_ACCOUNTING = Me.GetValueFromParameter(objParameters, "SU_ACCOUNTING")

        'End If

        Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", Me.tbl_MstChannelSearch, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'")
        Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_id"

        Me.ComboFill(Me.obj_Moveasset_strukturunit, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitMove, "as_MstStrukturUnit_Select", "  ")
        Me.tbl_MstStrukturunitMove.DefaultView.Sort = "strukturunit_name"
        Me.ComboFill(Me.obj_Strukturunit_id_old, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitOld, "as_MstStrukturUnit_Select", "  ")
        Me.tbl_MstStrukturunitOld.DefaultView.Sort = "strukturunit_name"
        Me.ComboFill(Me.obj_Strukturunit_id_new, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitNew, "as_MstStrukturUnit_Select", "  ")
        Me.tbl_MstStrukturunitNew.DefaultView.Sort = "strukturunit_name"

        Me.ComboFill(Me.obj_Moveasset_report, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeMoveReport, "ms_MstEmployee_Select", " strukturunit_id = " & Me._SU_EMPLOYEE)
        Me.tbl_MstEmployeeMoveReport.DefaultView.Sort = "employee_namalengkap"
        Me.ComboFill(Me.obj_Moveasset_acct, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeMoveAcct, "ms_MstEmployee_Select", " strukturunit_id = " & Me._SU_ACCOUNTING)
        Me.tbl_MstEmployeeMoveAcct.DefaultView.Sort = "employee_namalengkap"
        Me.ComboFill(Me.obj_Employee_id_old, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeMoveOld, "ms_MstEmployee_Select", "  ")
        Me.tbl_MstEmployeeMoveOld.DefaultView.Sort = "employee_namalengkap"
        Me.ComboFill(Me.obj_Employee_id_new, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeMoveNew, "ms_MstEmployee_Select", "  ")
        Me.tbl_MstEmployeeMoveNew.DefaultView.Sort = "employee_namalengkap"

        Dim dept_head_old As Boolean
        Me.tbl_MstEmployeeOldDeptHead = tbl_MstEmployeeMoveOld.Copy
        dept_head_old = ComboFillFromDataTable(Me.obj_Employee_deptHead_old, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeOldDeptHead)
        Me.tbl_MstEmployeeOldDeptHead.DefaultView.Sort = "employee_namalengkap"

        Dim div_head_old As Boolean
        Me.tbl_MstEmployeeOldDivHead = tbl_MstEmployeeMoveOld.Copy
        div_head_old = ComboFillFromDataTable(Me.obj_Employee_divHead_old, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeOldDivHead)
        Me.tbl_MstEmployeeOldDivHead.DefaultView.Sort = "employee_namalengkap"

        Dim dept_head_new As Boolean
        Me.tbl_MstEmployeeNewDeptHead = tbl_MstEmployeeMoveOld.Copy
        dept_head_new = ComboFillFromDataTable(Me.obj_Employee_deptHead_new, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeNewDeptHead)
        Me.tbl_MstEmployeeNewDeptHead.DefaultView.Sort = "employee_namalengkap"

        Dim div_head_new As Boolean
        Me.tbl_MstEmployeeNewDivHead = tbl_MstEmployeeMoveOld.Copy
        div_head_new = ComboFillFromDataTable(Me.obj_Employee_divHead_new, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeNewDivHead)
        Me.tbl_MstEmployeeNewDivHead.DefaultView.Sort = "employee_namalengkap"

        Dim acc As Boolean
        Me.tbl_MstEmployeeAcc = tbl_MstEmployeeMoveOld.Copy
        acc = ComboFillFromDataTable(Me.obj_Employee_Acc, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeeAcc)
        Me.tbl_MstEmployeeAcc.DefaultView.Sort = "employee_namalengkap"

        Me.cboSearchChannel.SelectedValue = Me._CHANNEL

        Me.InitLayoutUI()
        Me.BindingStop()
        Me.BindingStart()

        Me.uiTrnMoveAsset_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

        Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_CHANGED
        Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED

        Me.obj_Moveasset_strukturunit.Enabled = Me._STRUKTUR_UNIT_CANBE_CHANGED

        Dim myCI As New System.Globalization.CultureInfo("en-GB", False)
        Dim myCIclone As System.Globalization.CultureInfo = CType(myCI.Clone(), System.Globalization.CultureInfo)
        myCIclone.DateTimeFormat.AMDesignator = "a.m."
        myCIclone.DateTimeFormat.DateSeparator = "/"
        myCIclone.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        myCIclone.NumberFormat.CurrencySymbol = "$"
        myCIclone.NumberFormat.NumberDecimalDigits = 4
        System.Threading.Thread.CurrentThread.CurrentCulture = myCIclone


        Me.btnlock.ToolTipText = "Lock Transaction"
        Me.ToolStrip1.Items.Add(Me.btnlock)
        Me.btnlock.Image = Me.ImageList1.Images(0)
    End Sub



    Private Sub uiTrnMoveAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White

                If Me.DgvTrnMoveasset.CurrentRow IsNot Nothing Then
                    Me.uiTrnMoveAsset_OpenRow(Me.DgvTrnMoveasset.CurrentRow.Index)
                Else
                    Me.uiTrnMoveAsset_NewData()
                End If

        End Select
    End Sub
    Private Sub DgvTrnMoveasset_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnMoveasset.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnMoveasset.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.Text = ""
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar.ToString = Microsoft.VisualBasic.ChrW(13) Then
            If Trim(Me.obj_Moveasset_id.Text) = "AUTO" Then
                MsgBox("Save Header Transaction First")
                Exit Sub
            End If

            If Len(Trim(Me.TextBox1.Text)) >= 2 Then
                Me.coba()
                Me.uiTrnMoveasset_Saveke2()
                Me.Cursor = Cursors.Arrow
            Else
                MsgBox("Please Input Item", MsgBoxStyle.Information, "Warning")
                Me.TextBox1.Text = ""
                Me.TextBox1.Focus()
                Exit Sub
            End If
            Me.TextBox1.Text = "- - Item Move Asset - -"
        End If
    End Sub
    Private Function uiTrnMoveasset_Saveke2() As Boolean

        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Try
            Dim dbCmdInsert As OleDb.OleDbCommand
            Dim kafir As String
            dbConn.Open()
            dbCmdInsert = New OleDb.OleDbCommand("as_TrnMoveassetdetil_Insert", dbConn)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 10, "channel_id").Value = _CHANNEL
            dbCmdInsert.Parameters.Add("@moveasset_id", System.Data.OleDb.OleDbType.VarWChar, 20, "moveasset_id").Value = Me.obj_Moveasset_id.Text
            dbCmdInsert.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4, "line").Value = 1
            dbCmdInsert.Parameters.Add("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_barcode").Value = Trim(Me.TextBox1.Text)
            dbCmdInsert.Parameters.Add("@employee_id_old", System.Data.OleDb.OleDbType.VarWChar, 15, "employee_id_old").Value = Me.retEmployee_OldOwner
            dbCmdInsert.Parameters.Add("@strukturunit_id_old", System.Data.OleDb.OleDbType.Decimal, 5, "strukturunit_id_old").Value = Me.retStrukturunit_idOld
            dbCmdInsert.Parameters.Add("@employee_id_new", System.Data.OleDb.OleDbType.VarWChar, 15, "employee_id_new").Value = Me.retEmployee_NewOwner
            dbCmdInsert.Parameters.Add("@strukturunit_id_new", System.Data.OleDb.OleDbType.Decimal, 5, "strukturunit_id_new").Value = Me.retStrukturunit_idNew
            dbCmdInsert.Parameters.Add("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 10, "asset_status").Value = ""
            dbCmdInsert.Parameters.Add("@remark", System.Data.OleDb.OleDbType.VarWChar, 100, "remark").Value = Me.obj_Moveasset_remark.Text
            dbCmdInsert.Parameters.Add("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, "strukturunit_id").Value = Me.retStrukturunit_id
            dbCmdInsert.Parameters.Add("@stat", System.Data.OleDb.OleDbType.VarWChar, 10).Direction = ParameterDirection.Output
            dbCmdInsert.ExecuteNonQuery()
            kafir = CStr(dbCmdInsert.Parameters("@stat").Value)
            'MsgBox(kafir)
            If kafir = "A" Then
                Me.obj_Employee_id_old.Enabled = False
                Me.obj_Strukturunit_id_old.Enabled = False
                Me.obj_Strukturunit_id_new.Enabled = False
                Me.obj_Employee_id_new.Enabled = False
                suaramenang = PanggilSuara(Application.StartupPath & "\Sound\Ok.wav")
                'suaramenang = PanggilSuara("C:\TransBrowser\Sound\Ok.wav")
                MainkanSuara(suaramenang, SND_SYNC Or SND_MEMORY)
            Else
                suaramenang = PanggilSuara(Application.StartupPath & "\Sound\Error.wav")
                'suaramenang = PanggilSuara("C:\TransBrowser\Sound\Error.wav")
                MainkanSuara(suaramenang, SND_SYNC Or SND_MEMORY)
            End If
            dbCmdInsert.Dispose()
            Me.uiTrnMoveAsset_OpenRowMaster(_CHANNEL, Me.obj_Moveasset_id.Text, dbConn)
            Me.uiTrnMoveAsset_OpenRowDetil(_CHANNEL, Me.obj_Moveasset_id.Text, dbConn)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        Me.Cursor = Cursors.Arrow
    End Function
    Private Sub coba()
        Dim criteria As String = String.Format(" and moveasset_id = '{0}'", Me.obj_Moveasset_id.Text)
        Dim tbl As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Try
            tbl.Rows.Clear()
            DataFill(tbl, "as_TrnMoveasset_Select", criteria, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)
            retStrukturunit_id = tbl.Rows(0)("moveasset_strukturunit")
            retEmployee_OldOwner = tbl.Rows(0)("employee_id_old")
            retStrukturunit_idOld = tbl.Rows(0)("strukturunit_id_Old")
            retEmployee_NewOwner = tbl.Rows(0)("employee_id_new")
            retStrukturunit_idNew = tbl.Rows(0)("strukturunit_id_new")
        Catch ex As Exception
        End Try

    End Sub
    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()

        tbl_Print.Clear()
        tbl_PrintDetil.Clear()
        objPrintHeader = New DataSource.clsRptMoveAsset(Me.DSN)
        DataFill(tbl_Print, "as_TrnMoveasset_Select", "and moveasset_id = '" & DgvTrnMoveasset.Item("moveasset_id", DgvTrnMoveasset.SelectedCells.Item(0).RowIndex).Value & "'", Me._CHANNEL, NumericUpDown1.Value)
        With objPrintHeader
            .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
            .moveasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_id").ToString, String.Empty)
            .moveasset_tgl = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_tgl"), Now())
            .moveasset_strukturunit = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_strukturunit"), 0)
            .moveasset_report = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_report").ToString, String.Empty)
            .moveasset_acct = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_acct").ToString, String.Empty)
            .employee_id_old = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_old").ToString, String.Empty)
            .strukturunit_id_old = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_old"), 0)
            .employee_id_new = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_new").ToString, String.Empty)
            .strukturunit_id_new = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_new"), 0)
            .moveasset_remark = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_remark").ToString, String.Empty)
            .moveasset_item = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_item"), 0)
            .employee_old_depthead_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_old_depthead_string"), String.Empty)
            .employee_old_divhead_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_old_divhead_string"), String.Empty)
            .employee_new_depthead_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_new_depthead_string"), String.Empty)
            .employee_new_divhead_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_new_divhead_string"), String.Empty)
            .employee_acc_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_acc_string"), String.Empty)

            Me.sptChannel_ID = .channel_id
            Me.sptChannel_nameReport = .channel_namereport
            Me.sptChannel_address = .channel_address
            Me.sptMoveAsset_ID = .moveasset_id
            Me.sptStrukturUnit = .Moveasset_strukturunit_string

            DataFill(tbl_PrintDetil, "as_TrnMoveassetdetil_Select", "moveasset_id = '" & .moveasset_id & "'")
            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function
    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptMoveAssetDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptMoveAssetDetil(Me.DSN)
            With objDetil
                .channel = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel").ToString, String.Empty)
                .moveasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("moveasset_id").ToString, String.Empty)
                .line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("line"), 0)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcode").ToString, String.Empty)
                .employee_oldowner = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_oldowner").ToString, String.Empty)
                .strukturunit_idold = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_idold"), 0)
                .employee_newowner = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_newowner").ToString, String.Empty)
                .strukturunit_idnew = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_idnew"), 0)
                .asset_status = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_status").ToString, String.Empty)
                .remark = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("remark").ToString, String.Empty)
                .sn = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("sn"), String.Empty)
                .desk = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("desk"), String.Empty)
                .tipe = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("tipe"), String.Empty)
                .brand = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand"), String.Empty)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub
    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptMoveAssetDetil", objDatalistDetil))
    End Sub
    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        Dim stream As System.IO.Stream
        Dim deviceInfo As String = _
        "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>8.27in</PageWidth>" & _
        "  <PageHeight>11.69in</PageHeight>" & _
        "  <MarginTop>0.4in</MarginTop>" & _
        "  <MarginLeft>0.4in</MarginLeft>" & _
        "  <MarginRight>0.4in</MarginRight>" & _
        "  <MarginBottom>0.4in</MarginBottom>" & _
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
        'Dim printername As String = printSet.PrinterName
        Const printerName As String = "Microsoft Office Document Image Writer"

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
    Private Function uiTrnMoveAsset_Print() As Boolean
        If Me.DgvTrnMoveasset.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)

        objDatalistHeader = Me.GenerateDataHeader()

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.sptChannel_ID)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptMoveAsset_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("moveAssetID", Me.sptMoveAsset_ID)
        Dim parRptStrukturUnit As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("strukturUnit", Me.sptStrukturUnit)

        objRdsH.Name = "ASSET_DataSource_clsRptMoveAsset"
        objRdsH.Value = objDatalistHeader

        objReportH.ReportEmbeddedResource = "ASSET.RptMoveAsset.rdlc"
        objReportH.DataSources.Add(objRdsH)
        objReportH.EnableExternalImages = True
        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptMoveAsset_ID, parRptStrukturUnit})

        AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
        Export(objReportH)

        m_currentPageIndex = 0
        Print()
    End Function
    Private Function uiTrnMoveAsset_PrintPreview() As Boolean
        If Me.DgvTrnMoveasset.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If
        Dim moveasset_id As String
        moveasset_id = DgvTrnMoveasset.CurrentRow.Cells("moveasset_id").Value
        Dim frmPrint As dlgRptMoveAsset = New dlgRptMoveAsset(Me.DSN, Me.SptServer, Me._CHANNEL, NumericUpDown1.Value, moveasset_id)
        Dim criteria As String = String.Empty

        frmPrint.ShowInTaskbar = False
        frmPrint.StartPosition = FormStartPosition.CenterParent

        criteria = " and moveasset_id = '" & moveasset_id & "'"

        frmPrint.SetIDCriteria(criteria)
        frmPrint.ShowDialog(Me)
    End Function
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Me.TextBox1.Text = "- - Item Move Asset - -"
    End Sub

    Private Sub LockData()


        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor


        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_Locktransaksi_moveasset", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@moveasset_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnMoveasset.Item("moveasset_id", DgvTrnMoveasset.CurrentRow.Index).Value
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me._CHANNEL
            oCm.ExecuteNonQuery()
            oCm.Dispose()

            Me.obj_Moveasset_Lock.Checked = True
            Me.DgvTrnMoveasset.Item("moveasset_lock", DgvTrnMoveasset.CurrentRow.Index).Value = 1
            Me.PnlDataMaster.Enabled = False
            Me.DgvTrnMoveassetdetil.AllowUserToDeleteRows = False
            MessageBox.Show("Data Has Been Locked", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub DgvTrnMoveasset_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnMoveasset.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

        Try
            If objrow.Cells("moveasset_lock").Value = 0 Then
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
