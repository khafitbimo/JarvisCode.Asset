Public Class uiTrnBookasset
    Private Const mUiName As String = "Transaksi Booking Asset"
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
    Private tbl_TrnBookasset As DataTable = clsDataset.CreateTblTrnBookasset()
    Private tbl_TrnBookasset_Temp As DataTable = clsDataset.CreateTblTrnBookasset()
    Private tbl_TrnBookassetdetil As DataTable = clsDataset.CreateTblTrnBookassetdetil()

    Private tbl_MstChannel As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstEmployeebook As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_MstEmployeecustomerhead As DataTable = clsDataset.CreateTblemployeePengguna()
    Private tbl_MstStrukturunitBook As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_schStrukturUnit As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_MstEmployeebookSearch As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_schStrukturUnitBookBy As DataTable = clsDataset.CreateTblStrukturunitPemilik()

    Private tbl_MstStrukturunitOwner As DataTable = clsDataset.CreateTblStrukturunitPengguna()
    Private tbl_project As DataTable = clsDataset.CreateTblMstBudgetCombo
    Private tbl_show As DataTable = clsDataset.CreateTblMstShow

    Private tbl_Print As DataTable = clsDataset.CreateTblTrnBookasset
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnBookassetdetilView
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptTrnBookasset
    Private objDatalistDetil As ArrayList
    Private suaramenang As String
    Private retStrukturunit_id As Decimal
    Private loadcombodata As Boolean

    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptBookAsset_ID As String
    Private sptStrukturUnit As String

    Friend WithEvents btnlock As ToolStripButton = New ToolStripButton


#Region " Window Parameter "
    Private _STRUKTUR_UNIT As Decimal = 5554 '5565                 'tambahan
    Private _STRUKTUR_UNIT_ID_CANBE_CHANGED As Boolean = False
    Private _STRUKTUR_UNIT_ID_CANBE_BROWSED As Boolean = False

    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    Private _SU_EMPLOYEE As String = "9002000"
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

        Me.uiTrnBookasset_NewData()
        Me.Obj_Asset_No_Project.Text = 0
        Me.PnlDataMaster.Enabled = True
        Me.Cursor = Cursors.Arrow

        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnBookasset_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        Me.objFormError.Clear()
        If Me.uiTrnBookasset_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnBookasset_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnBookasset_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnBookasset_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnBookasset_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnBookasset_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnBookasset_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnBookasset_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnBookasset_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnBookasset(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnBookasset Columns 
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_startdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_enddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_starttm As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_endtm As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_bookby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStruktur_unit_bookby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_customerhead As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_item As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_epsnumber_st As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_epsnumber_ed As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUsername_inputby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_inputdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_lock As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cOutasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_purpose As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 75
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cBookasset_id.Name = "bookasset_id"
        cBookasset_id.HeaderText = "Book Asset No"
        cBookasset_id.DataPropertyName = "bookasset_id"
        cBookasset_id.Width = 125
        cBookasset_id.Visible = True
        cBookasset_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Struktur Unit"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 200
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cStrukturunit_id_string.Name = "strukturunit_id_string"
        cStrukturunit_id_string.HeaderText = "Struktur Unit"
        cStrukturunit_id_string.DataPropertyName = "strukturunit_id_string"
        cStrukturunit_id_string.Width = 200
        cStrukturunit_id_string.Visible = False
        cStrukturunit_id_string.ReadOnly = False

        cBookasset_startdt.Name = "bookasset_startdt"
        cBookasset_startdt.HeaderText = "Start Date"
        cBookasset_startdt.DataPropertyName = "bookasset_startdt"
        cBookasset_startdt.Width = 85
        cBookasset_startdt.Visible = True
        cBookasset_startdt.ReadOnly = False

        cBookasset_enddt.Name = "bookasset_enddt"
        cBookasset_enddt.HeaderText = "End Date"
        cBookasset_enddt.DataPropertyName = "bookasset_enddt"
        cBookasset_enddt.Width = 85
        cBookasset_enddt.Visible = True
        cBookasset_enddt.ReadOnly = False

        cBookasset_starttm.Name = "bookasset_starttm"
        cBookasset_starttm.HeaderText = "Start"
        cBookasset_starttm.DataPropertyName = "bookasset_starttm"
        cBookasset_starttm.Width = 50
        cBookasset_starttm.Visible = True
        cBookasset_starttm.ReadOnly = False

        cBookasset_endtm.Name = "bookasset_endtm"
        cBookasset_endtm.HeaderText = "End"
        cBookasset_endtm.DataPropertyName = "bookasset_endtm"
        cBookasset_endtm.Width = 50
        cBookasset_endtm.Visible = True
        cBookasset_endtm.ReadOnly = False

        cEmployee_id_bookby.Name = "employee_id_bookby"
        cEmployee_id_bookby.HeaderText = "Book By"
        cEmployee_id_bookby.DataPropertyName = "employee_id_bookby_string"
        cEmployee_id_bookby.Width = 200
        cEmployee_id_bookby.Visible = True
        cEmployee_id_bookby.ReadOnly = False

        cStruktur_unit_bookby.Name = "struktur_unit_bookby"
        cStruktur_unit_bookby.HeaderText = "Department Book By"
        cStruktur_unit_bookby.DataPropertyName = "struktur_unit_bookby_string"
        cStruktur_unit_bookby.Width = 200
        cStruktur_unit_bookby.Visible = True
        cStruktur_unit_bookby.ReadOnly = False

        cEmployee_id_customerhead.Name = "employee_id_customerhead"
        cEmployee_id_customerhead.HeaderText = "Head"
        cEmployee_id_customerhead.DataPropertyName = "employee_id_customerhead_string"
        cEmployee_id_customerhead.Width = 200
        cEmployee_id_customerhead.Visible = True
        cEmployee_id_customerhead.ReadOnly = False

        cBookasset_item.Name = "bookasset_item"
        cBookasset_item.HeaderText = "Item"
        cBookasset_item.DataPropertyName = "bookasset_item"
        cBookasset_item.Width = 60
        cBookasset_item.Visible = True
        cBookasset_item.ReadOnly = False

        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "Project"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 150
        cBudget_id.Visible = False
        cBudget_id.ReadOnly = False

        cShow_id.Name = "show_id"
        cShow_id.HeaderText = "Show"
        cShow_id.DataPropertyName = "show_id_string"
        cShow_id.Width = 150
        cShow_id.Visible = True
        cShow_id.ReadOnly = False

        cShow_epsnumber_st.Name = "show_epsnumber_st"
        cShow_epsnumber_st.HeaderText = "Eps Start"
        cShow_epsnumber_st.DataPropertyName = "show_epsnumber_st"
        cShow_epsnumber_st.Width = 95
        cShow_epsnumber_st.Visible = True
        cShow_epsnumber_st.ReadOnly = False

        cShow_epsnumber_ed.Name = "show_epsnumber_ed"
        cShow_epsnumber_ed.HeaderText = "Eps End"
        cShow_epsnumber_ed.DataPropertyName = "show_epsnumber_ed"
        cShow_epsnumber_ed.Width = 75
        cShow_epsnumber_ed.Visible = True
        cShow_epsnumber_ed.ReadOnly = False

        cUsername_inputby.Name = "username_inputby"
        cUsername_inputby.HeaderText = "Input By"
        cUsername_inputby.DataPropertyName = "username_inputby"
        cUsername_inputby.Width = 200
        cUsername_inputby.Visible = True
        cUsername_inputby.ReadOnly = False

        cBookasset_inputdt.Name = "bookasset_inputdt"
        cBookasset_inputdt.HeaderText = "Input Date"
        cBookasset_inputdt.DataPropertyName = "bookasset_inputdt"
        cBookasset_inputdt.Width = 125
        cBookasset_inputdt.Visible = True
        cBookasset_inputdt.ReadOnly = False

        cBookasset_lock.Name = "bookasset_lock"
        cBookasset_lock.HeaderText = "C"
        cBookasset_lock.DataPropertyName = "bookasset_lock"
        cBookasset_lock.Width = 35
        cBookasset_lock.Visible = True
        cBookasset_lock.ReadOnly = False

        cOutasset_id.Name = "outasset_id"
        cOutasset_id.HeaderText = "Outgoing Number"
        cOutasset_id.DataPropertyName = "outasset_id"
        cOutasset_id.Width = 125
        cOutasset_id.Visible = True
        cOutasset_id.ReadOnly = False

        cBookasset_purpose.Name = "bookasset_purpose"
        cBookasset_purpose.HeaderText = "Purpose"
        cBookasset_purpose.DataPropertyName = "bookasset_purpose"
        cBookasset_purpose.Width = 125
        cBookasset_purpose.Visible = True
        cBookasset_purpose.ReadOnly = False

        cBudget_id_string.Name = "budget_id_string"
        cBudget_id_string.HeaderText = "Project"
        cBudget_id_string.DataPropertyName = "budget_id_string"
        cBudget_id_string.Width = 100
        cBudget_id_string.Visible = True
        cBudget_id_string.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBookasset_lock, cBookasset_id, cOutasset_id, _
         cBookasset_startdt, cBookasset_starttm, cBookasset_enddt, cBookasset_endtm, _
       cBookasset_item, _
        cEmployee_id_bookby, cStruktur_unit_bookby, cStrukturunit_id_string, cStrukturunit_id, _
        cEmployee_id_customerhead, cBudget_id, cBudget_id_string, _
        cShow_id, cShow_epsnumber_st, cShow_epsnumber_ed, _
        cUsername_inputby, cBookasset_inputdt, cBookasset_purpose, cChannel_id})

        ' DgvTrnBookasset Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.AutoGenerateColumns = False

    End Function

    Private Function FormatDgvTrnBookassetdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnBookassetdetil
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLine As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cQty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStatus As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn


        Dim csn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cdesk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim ctipe As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cbrand As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        csn.Name = "sn"
        csn.HeaderText = "S/N"
        csn.DataPropertyName = "sn"
        csn.Width = 125
        csn.Visible = True
        csn.ReadOnly = False

        cdesk.Name = "desk"
        cdesk.HeaderText = "Description"
        cdesk.DataPropertyName = "desk"
        cdesk.Width = 250
        cdesk.Visible = True
        cdesk.ReadOnly = False

        ctipe.Name = "tipe"
        ctipe.HeaderText = "Type"
        ctipe.DataPropertyName = "tipe"
        ctipe.Width = 150
        ctipe.Visible = True
        ctipe.ReadOnly = False

        cbrand.Name = "brand"
        cbrand.HeaderText = "Brand"
        cbrand.DataPropertyName = "brand"
        cbrand.Width = 200
        cbrand.Visible = True
        cbrand.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cBookasset_id.Name = "bookasset_id"
        cBookasset_id.HeaderText = "bookasset_id"
        cBookasset_id.DataPropertyName = "bookasset_id"
        cBookasset_id.Width = 100
        cBookasset_id.Visible = False
        cBookasset_id.ReadOnly = False

        cLine.Name = "line"
        cLine.HeaderText = "line"
        cLine.DataPropertyName = "line"
        cLine.Width = 100
        cLine.Visible = False
        cLine.ReadOnly = False

        cAsset_barcode.Name = "asset_barcode"
        cAsset_barcode.HeaderText = "Barcode"
        cAsset_barcode.DataPropertyName = "asset_barcode"
        cAsset_barcode.Width = 120
        cAsset_barcode.Visible = True
        cAsset_barcode.ReadOnly = False

        cQty.Name = "qty"
        cQty.HeaderText = "qty"
        cQty.DataPropertyName = "qty"
        cQty.Width = 100
        cQty.Visible = False
        cQty.ReadOnly = False

        cStatus.Name = "status"
        cStatus.HeaderText = "Status"
        cStatus.DataPropertyName = "status"
        cStatus.Width = 100
        cStatus.Visible = True
        cStatus.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cChannel_id, cBookasset_id, cLine, cAsset_barcode, csn, cdesk, ctipe, cbrand, cQty, cStatus})

        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = True
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True

    End Function

    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        ' Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvTrnBookasset.Dock = DockStyle.Fill

        Me.FormatDgvTrnBookasset(Me.DgvTrnBookasset)
        Me.FormatDgvTrnBookassetdetil(Me.DgvTrnBookassetdetil)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Bookasset_id.DataBindings.Clear()
        Me.obj_Strukturunit_id.DataBindings.Clear()
        Me.obj_Bookasset_startdt.DataBindings.Clear()
        Me.obj_Bookasset_enddt.DataBindings.Clear()
        Me.obj_Bookasset_starttm.DataBindings.Clear()
        Me.obj_Bookasset_endtm.DataBindings.Clear()
        Me.obj_Employee_id_bookby.DataBindings.Clear()
        Me.obj_Struktur_unit_bookby.DataBindings.Clear()
        Me.obj_Employee_id_customerhead.DataBindings.Clear()
        Me.obj_Bookasset_item.DataBindings.Clear()
        Me.obj_Project_id.DataBindings.Clear()
        'Me.obj_Project_id_code.DataBindings.Clear()
        Me.obj_Show_id.DataBindings.Clear()
        Me.obj_Show_epsnumber_st.DataBindings.Clear()
        Me.obj_Show_epsnumber_ed.DataBindings.Clear()
        Me.obj_Username_inputby.DataBindings.Clear()
        Me.obj_Bookasset_inputdt.DataBindings.Clear()
        Me.obj_Bookasset_lock.DataBindings.Clear()
        'obj_Terimabarang_confirm.DataBindings.Clear()
        Me.obj_Outasset_id.DataBindings.Clear()
        Me.obj_bookasset_remark.DataBindings.Clear()

        Me.obj_Editby.DataBindings.Clear()
        Me.obj_Editdt.DataBindings.Clear()
        Me.obj_Usedby.DataBindings.Clear()
        Me.obj_Useddt.DataBindings.Clear()
        Me.obj_bookasset_purpose.DataBindings.Clear()

        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding

        Me.obj_Channel_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnBookasset_Temp, "channel_id"))
        Me.obj_Bookasset_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_id"))
        Me.obj_Strukturunit_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnBookasset_Temp, "strukturunit_id"))
        Me.obj_Bookasset_startdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_startdt", True, DataSourceUpdateMode.OnPropertyChanged, "MM/dd/yyyy"))
        Me.obj_Bookasset_enddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_enddt", True, DataSourceUpdateMode.OnPropertyChanged, "MM/dd/yyyy"))
        Me.obj_Bookasset_starttm.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_starttm"))
        Me.obj_Bookasset_endtm.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_endtm"))
        Me.obj_Employee_id_bookby.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnBookasset_Temp, "employee_id_bookby"))
        Me.obj_Struktur_unit_bookby.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnBookasset_Temp, "struktur_unit_bookby"))
        Me.obj_Employee_id_customerhead.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnBookasset_Temp, "employee_id_customerhead"))
        Me.obj_Bookasset_item.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_item"))
        Me.obj_Project_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnBookasset_Temp, "budget_id"))

        'Me.obj_Project_id_code.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "budget_id"))
        Me.obj_Show_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnBookasset_Temp, "show_id"))
        Me.obj_Show_epsnumber_st.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "show_epsnumber_st"))
        Me.obj_Show_epsnumber_ed.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "show_epsnumber_ed"))
        Me.obj_Username_inputby.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "username_inputby"))
        Me.obj_Bookasset_inputdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_inputdt"))
        Me.obj_Bookasset_lock.DataBindings.Add(New Binding("Checked", Me.tbl_TrnBookasset, "bookasset_lock"))
        Me.obj_bookasset_remark.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_remark"))

        ' obj_Terimabarang_confirm.DataBindings.Add(New Binding("Checked", Me.tbl_TrnBookasset_Temp, "bookasset_active"))
        Me.obj_Outasset_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "outasset_id"))

        Me.obj_Editby.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_editby"))
        Me.obj_Editdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_editdt"))
        Me.obj_Usedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_usedby"))
        Me.obj_Useddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_useddt"))

        Me.obj_bookasset_purpose.DataBindings.Add(New Binding("Text", Me.tbl_TrnBookasset_Temp, "bookasset_purpose"))
        Return True
    End Function

#End Region

#Region " Dialoged Control "
#End Region

#Region " User Defined Function "

    Private Function uiTrnBookasset_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnBookasset_Temp
        Me.tbl_TrnBookasset_Temp.Clear()
        Me.tbl_TrnBookasset_Temp.Columns("channel_id").DefaultValue = _CHANNEL
        Me.tbl_TrnBookasset_Temp.Columns("bookasset_id").DefaultValue = "AUTO"
        Me.tbl_TrnBookasset_Temp.Columns("strukturunit_id").DefaultValue = _STRUKTUR_UNIT
        Me.tbl_TrnBookasset_Temp.Columns("bookasset_startdt").DefaultValue = Now
        Me.tbl_TrnBookasset_Temp.Columns("bookasset_enddt").DefaultValue = Now
        Me.tbl_TrnBookasset_Temp.Columns("bookasset_starttm").DefaultValue = "00:00"
        Me.tbl_TrnBookasset_Temp.Columns("bookasset_endtm").DefaultValue = "01:00"
        Me.tbl_TrnBookasset_Temp.Columns("employee_id_bookby").DefaultValue = DBNull.Value
        Me.tbl_TrnBookasset_Temp.Columns("struktur_unit_bookby").DefaultValue = DBNull.Value
        Me.tbl_TrnBookasset_Temp.Columns("employee_id_customerhead").DefaultValue = DBNull.Value
        Me.tbl_TrnBookasset_Temp.Columns("bookasset_item").DefaultValue = 0
        Me.tbl_TrnBookasset_Temp.Columns("budget_id").DefaultValue = 0
        Me.tbl_TrnBookasset_Temp.Columns("show_id").DefaultValue = DBNull.Value
        Me.tbl_TrnBookasset_Temp.Columns("show_epsnumber_st").DefaultValue = DBNull.Value
        Me.tbl_TrnBookasset_Temp.Columns("show_epsnumber_ed").DefaultValue = DBNull.Value
        Me.tbl_TrnBookasset_Temp.Columns("username_inputby").DefaultValue = Me.UserName
        Me.tbl_TrnBookasset_Temp.Columns("bookasset_inputdt").DefaultValue = Now
        Me.tbl_TrnBookasset_Temp.Columns("bookasset_lock").DefaultValue = 1
        Me.tbl_TrnBookasset_Temp.Columns("outasset_id").DefaultValue = DBNull.Value
        Me.tbl_TrnBookasset_Temp.Columns("bookasset_purpose").DefaultValue = DBNull.Value
        Me.obj_Bookasset_lock.DataBindings.Clear()
        Me.obj_Bookasset_lock.DataBindings.Add(New Binding("Checked", Me.tbl_TrnBookasset, "bookasset_lock"))


        ' TODO: Set Default Value for tbl_TrnBookassetdetil
        Me.tbl_TrnBookassetdetil.Clear()
        Me.tbl_TrnBookassetdetil = clsDataset.CreateTblTrnBookassetdetil()
        Me.tbl_TrnBookassetdetil.Columns("bookasset_id").DefaultValue = "Auto"
        Me.tbl_TrnBookassetdetil.Columns("line").DefaultValue = DBNull.Value
        Me.tbl_TrnBookassetdetil.Columns("line").AutoIncrement = True
        Me.tbl_TrnBookassetdetil.Columns("line").AutoIncrementSeed = 1
        Me.tbl_TrnBookassetdetil.Columns("line").AutoIncrementStep = 1
        Me.DgvTrnBookassetdetil.DataSource = Me.tbl_TrnBookassetdetil


        Me.BindingContext(Me.tbl_TrnBookasset_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnBookasset_Temp).AddNew()
            Me.obj_Bookasset_lock.Checked = True
            Me.obj_Bookasset_enddt.Enabled = True
            Me.obj_Bookasset_endtm.ReadOnly = False
            Me.obj_Bookasset_startdt.Enabled = True
            Me.obj_Bookasset_starttm.ReadOnly = False

        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function
    Private Function uiTrnBookasset_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()
        If chkSearchStrukturUnit_id.Checked = True Then
            criteria = criteria & " and strukturunit_id = " & CStr(Me.cboSearchStrukturunit_id.SelectedValue)
        End If

        If chkSearchBookBy.Checked = True Then
            criteria &= String.Format(" and employee_id_bookby = '{0}'", Me.cboSearchBookBy.SelectedValue)
        End If

        If chkSearchDeparment.Checked = True Then
            criteria &= String.Format(" and struktur_unit_bookby = '{0}'", Me.cboSearchDepartmentBookBy.SelectedValue)
        End If

        If chkSearchBookingNo.Checked = True Then
            criteria &= String.Format(" and bookasset_id = '{0}'", Me.objSearchBookingNo.Text)
        End If

        If chkSearchOutGoingNo.Checked = True Then
            criteria &= String.Format(" and outasset_id = '{0}'", Me.obj_SearchOutGoingNo.Text)
        End If

        Me.tbl_TrnBookasset.Clear()
        Try
            Me.DataFill(Me.tbl_TrnBookasset, "as_TrnBookasset_Select", criteria, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)
            '            Me.DataFill(Me.tbl_TrnTerimabarang, "as_TrnTerimabarang_Select", criteria, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)
            Me.obj_Bookasset_lock.DataBindings.Clear()
            Me.obj_Bookasset_lock.DataBindings.Add(New Binding("Checked", Me.tbl_TrnBookasset, "bookasset_lock"))

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Function uiTrnBookasset_Save() As Boolean
        'save data
        Dim tbl_TrnBookasset_Temp_Changes As DataTable
        Dim tbl_TrnBookassetdetil_Changes As DataTable
        Dim success As Boolean
        Dim bookasset_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(bookasset_id)

        Me.BindingContext(Me.tbl_TrnBookasset_Temp).EndCurrentEdit()
        tbl_TrnBookasset_Temp_Changes = Me.tbl_TrnBookasset_Temp.GetChanges()

        Me.DgvTrnBookassetdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnBookassetdetil).EndCurrentEdit()
        tbl_TrnBookassetdetil_Changes = Me.tbl_TrnBookassetdetil.GetChanges()

        If tbl_TrnBookasset_Temp_Changes IsNot Nothing Or tbl_TrnBookassetdetil_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnBookasset_Temp.Rows(0).RowState
                bookasset_id = tbl_TrnBookasset_Temp.Rows(0).Item("bookasset_id")

                If tbl_TrnBookasset_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnBookasset_SaveMaster(bookasset_id, tbl_TrnBookasset_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnBookasset_SaveMaster(tbl_TrnBookasset_Temp_Changes)")
                    Me.tbl_TrnBookasset_Temp.AcceptChanges()
                End If

                If tbl_TrnBookassetdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnBookassetdetil.Rows.Count - 1
                        If Me.tbl_TrnBookassetdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnBookassetdetil.Rows(i).Item("bookasset_id") = bookasset_id
                        End If
                    Next
                    success = Me.uiTrnBookasset_SaveDetil(bookasset_id, tbl_TrnBookassetdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnBookasset_SaveDetil(tbl_TrnBookassetdetil_Changes)")
                    Me.tbl_TrnBookassetdetil.AcceptChanges()
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

        Me.uiTrnBookasset_OpenRow(Me.DgvTrnBookasset.CurrentRow.Index)

        RaiseEvent FormAfterSave(bookasset_id, result)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnBookasset_SaveMaster(ByRef bookasset_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: transaksi_bookasset
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnBookasset_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "bookasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_startdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bookasset_startdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bookasset_enddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_starttm", System.Data.OleDb.OleDbType.VarWChar, 10, "bookasset_starttm"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_endtm", System.Data.OleDb.OleDbType.VarWChar, 10, "bookasset_endtm"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_bookby", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_bookby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@struktur_unit_bookby", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "struktur_unit_bookby", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_customerhead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_customerhead"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_item", System.Data.OleDb.OleDbType.Integer, 4, "bookasset_item"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_st", System.Data.OleDb.OleDbType.VarWChar, 10, "show_epsnumber_st"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_ed", System.Data.OleDb.OleDbType.VarWChar, 10, "show_epsnumber_ed"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username_inputby", System.Data.OleDb.OleDbType.VarWChar, 16, "username_inputby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bookasset_inputdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_lock", System.Data.OleDb.OleDbType.Boolean, 1, "bookasset_lock"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "outasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_remark", System.Data.OleDb.OleDbType.VarWChar, 200, "bookasset_remark"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_editby", System.Data.OleDb.OleDbType.VarWChar, 32, "bookasset_editby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bookasset_editdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_usedby", System.Data.OleDb.OleDbType.VarWChar, 32, "bookasset_usedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bookasset_useddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_purpose", System.Data.OleDb.OleDbType.VarWChar, 200, "bookasset_purpose"))


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnBookasset_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "bookasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_startdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bookasset_startdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bookasset_enddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_starttm", System.Data.OleDb.OleDbType.VarWChar, 10, "bookasset_starttm"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_endtm", System.Data.OleDb.OleDbType.VarWChar, 10, "bookasset_endtm"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_bookby", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_bookby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@struktur_unit_bookby", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "struktur_unit_bookby", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_customerhead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_customerhead"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_item", System.Data.OleDb.OleDbType.Integer, 4, "bookasset_item"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_st", System.Data.OleDb.OleDbType.VarWChar, 10, "show_epsnumber_st"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_ed", System.Data.OleDb.OleDbType.VarWChar, 10, "show_epsnumber_ed"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username_inputby", System.Data.OleDb.OleDbType.VarWChar, 16, "username_inputby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bookasset_inputdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_lock", System.Data.OleDb.OleDbType.Boolean, 1, "bookasset_lock"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "outasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_remark", System.Data.OleDb.OleDbType.VarWChar, 200, "bookasset_remark"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_editby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_usedby", System.Data.OleDb.OleDbType.VarWChar, 32, "bookasset_usedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bookasset_useddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_purpose", System.Data.OleDb.OleDbType.VarWChar, 200, "bookasset_purpose"))
        dbCmdUpdate.Parameters("@bookasset_editby").Value = Me.UserName
        dbCmdUpdate.Parameters("@bookasset_editdt").Value = Now



        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            bookasset_id = objTbl.Rows(0).Item("bookasset_id")
            Me.tbl_TrnBookasset_Temp.Clear()
            Me.tbl_TrnBookasset_Temp.Merge(objTbl)

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
            Me.tbl_TrnBookasset.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnBookasset).Position
            Me.tbl_TrnBookasset.Rows.RemoveAt(curpos)
            Me.tbl_TrnBookasset.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnBookasset).Position = Me.BindingContext(Me.tbl_TrnBookasset).Count

        Return True
    End Function

    Private Function uiTrnBookasset_SaveDetil(ByRef bookasset_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        'Dim dbCmdInsert As OleDb.OleDbCommand
        'Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        'Dim kafir As String

        '' Save data: transaksi_bookassetdetil
        'dbCmdInsert = New OleDb.OleDbCommand("as_TrnBookassetdetil_Insert", dbConn)
        'dbCmdInsert.CommandType = CommandType.StoredProcedure
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 40))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@status", System.Data.OleDb.OleDbType.Integer, 1, "status"))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sthari", System.Data.OleDb.OleDbType.DBTimeStamp, 4)).Value = CDate(obj_Bookasset_startdt.Value)
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@edhari", System.Data.OleDb.OleDbType.DBTimeStamp, 4)).Value = CDate(obj_Bookasset_enddt.Value)
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sttime", System.Data.OleDb.OleDbType.VarWChar, 10)).Value = obj_Bookasset_starttm.Text
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@edtime", System.Data.OleDb.OleDbType.VarWChar, 10)).Value = obj_Bookasset_endtm.Text
        ''dbCmdInsert.Parameters.Add("@stat", OleDb.OleDbType.VarWChar, 10).Direction = ParameterDirection.Output
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@stat", System.Data.OleDb.OleDbType.VarWChar, 10)).Direction = ParameterDirection.Output




        ''System.Data.OleDb.OleDbType.VarWChar

        ''dbCmdInsert.Parameters("@rekanan_id").Value

        'kafir = dbCmdInsert.Parameters("@stat").Value
        'MsgBox(kafir)
        'dbCmdInsert.Parameters("@bookasset_id").Value = bookasset_id


        'dbCmdUpdate = New OleDb.OleDbCommand("as_TrnBookassetdetil_Update", dbConn)
        'dbCmdUpdate.CommandType = CommandType.StoredProcedure
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 100, "channel_id"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty"))
        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@status", System.Data.OleDb.OleDbType.Boolean, 1, "status"))
        'dbCmdUpdate.Parameters("@bookasset_id").Value = bookasset_id


        dbCmdDelete = New OleDb.OleDbCommand("as_TrnBookassetdetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 100, "channel_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@status", System.Data.OleDb.OleDbType.Boolean, 1, "status"))
        dbCmdDelete.Parameters("@bookasset_id").Value = bookasset_id


        dbDA = New OleDb.OleDbDataAdapter
        'dbDA.UpdateCommand = dbCmdUpdate
        'dbDA.InsertCommand = dbCmdInsert
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

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()

        tbl_Print.Clear()
        tbl_PrintDetil.Clear()
        objPrintHeader = New DataSource.clsRptTrnBookasset(Me.DSN)
        DataFill(tbl_Print, "as_TrnBookasset_Select", " and bookasset_id = '" & DgvTrnBookasset.Item("bookasset_id", DgvTrnBookasset.SelectedCells.Item(0).RowIndex).Value & "'", Me._CHANNEL, NumericUpDown1.Value)
        With objPrintHeader
            .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id"), String.Empty)
            .bookasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_id"), String.Empty)
            .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), 0)
            .bookasset_startdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_startdt"), String.Empty)
            .bookasset_enddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_enddt"), String.Empty)
            .bookasset_starttm = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_starttm"), String.Empty)
            .bookasset_endtm = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_endtm"), String.Empty)
            .employee_id_bookby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_bookby"), String.Empty)
            .struktur_unit_bookby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("struktur_unit_bookby"), 0)
            .employee_id_customerhead = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_customerhead"), String.Empty)
            .bookasset_item = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_item"), 0)
            .budget_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("budget_id"), 0)
            .show_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_id"), String.Empty)
            .show_epsnumber_st = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_epsnumber_st"), String.Empty)
            .show_epsnumber_ed = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_epsnumber_ed"), String.Empty)
            .username_inputby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("username_inputby"), String.Empty)
            .bookasset_inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_inputdt"), String.Empty)
            .bookasset_active = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_lock"), 0)
            .outasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_id"), String.Empty)
            .bookasset_remark = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_remark"), String.Empty)
            .bookasset_purpose = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_purpose"), String.Empty)

            Me.sptChannel_ID = .channel_id
            Me.sptChannel_nameReport = .channel_namereport
            Me.sptChannel_address = .channel_address
            Me.sptBookAsset_ID = .bookasset_id
            Me.sptStrukturUnit = .strukturunit_name
            DataFill(tbl_PrintDetil, "as_TrnBookassetDetilView_Select", "bookasset_id = '" & .bookasset_id & "'")
            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptTrnBookassetDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptTrnBookassetDetil(Me.DSN)
            With objDetil
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id"), String.Empty)
                .bookasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("bookasset_id"), String.Empty)
                .line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("line"), 0)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcode"), String.Empty)
                .sn = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("sn"), String.Empty)
                .desk = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("desk"), String.Empty)
                .tipe = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("tipe"), String.Empty)
                .brand = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand"), String.Empty)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptTrnBookassetDetil", objDatalistDetil))
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
        Dim printset As New System.Drawing.Printing.PrinterSettings()
        Dim printerName As String = printset.PrinterName
        'Const printerName As String = "Microsoft Office Document Image Writer"

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

    Private Function uiTrnBookasset_Print() As Boolean
        If Me.DgvTrnBookasset.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If
        If Me.DgvTrnBookasset.CurrentRow.Cells("bookasset_lock").Value = -1 Then
            MsgBox("Anda harus melakukan Locking terlebih dahulu sebelum melakukan print", MsgBoxStyle.Critical, "ERRORs")
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
        Dim parRptBookAsset_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("bookAssetID", Me.sptBookAsset_ID)
        Dim parRptStrukturUnit As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("strukturUnit", Me.sptStrukturUnit)

        objRdsH.Name = "ASSET_DataSource_clsRptTrnBookasset"
        objRdsH.Value = objDatalistHeader

        objReportH.ReportEmbeddedResource = "ASSET.RptBookasset.rdlc"
        objReportH.DataSources.Add(objRdsH)
        objReportH.EnableExternalImages = True
        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptBookAsset_ID, parRptStrukturUnit})

        AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
        Export(objReportH)

        m_currentPageIndex = 0
        Print()
    End Function

    Private Function uiTrnBookasset_PrintPreview() As Boolean
        If Me.DgvTrnBookasset.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If
        Dim bookasset_id As String
        bookasset_id = DgvTrnBookasset.CurrentRow.Cells("bookasset_id").Value
        Dim frmPrint As dlgRptBookasset = New dlgRptBookasset(Me.DSN, Me.SptServer, Me._CHANNEL, NumericUpDown1.Value, bookasset_id)
        Dim criteria As String = String.Empty

        frmPrint.ShowInTaskbar = False
        frmPrint.StartPosition = FormStartPosition.CenterParent

        criteria = " and bookasset_id = '" & bookasset_id & "'"

        frmPrint.SetIDCriteria(criteria)
        frmPrint.ShowDialog(Me)
    End Function

    Private Function uiTrnBookasset_Delete() As Boolean
        Dim res As String = ""
        Dim bookasset_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(bookasset_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnBookasset.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnBookasset_DeleteRow(Me.DgvTrnBookasset.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(bookasset_id)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnBookasset_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim bookasset_id As String
        Dim NewRowIndex As Integer

        bookasset_id = Me.DgvTrnBookasset.Rows(rowIndex).Cells("bookasset_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnBookasset_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@bookasset_id").Value = bookasset_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@strukturunit_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_startdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@bookasset_startdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@bookasset_enddt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_starttm", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@bookasset_starttm").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_endtm", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@bookasset_endtm").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_bookby", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@employee_id_bookby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@struktur_unit_bookby", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@struktur_unit_bookby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_customerhead", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@employee_id_customerhead").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_item", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@bookasset_item").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@project_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@show_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_st", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@show_epsnumber_st").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_ed", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@show_epsnumber_ed").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username_inputby", System.Data.OleDb.OleDbType.VarWChar, 16))
        dbCmdDelete.Parameters("@username_inputby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@bookasset_inputdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_lock", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@bookasset_lock").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@outasset_id").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnBookasset.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnBookasset_OpenRow(NewRowIndex)
                    Me.tbl_TrnBookasset.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnBookasset.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnBookasset_OpenRow(NewRowIndex)
                    Me.tbl_TrnBookasset.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnBookasset.Rows.RemoveAt(rowIndex)
                    Me.uiTrnBookasset_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_TrnBookasset_Temp.Clear()
                Me.tbl_TrnBookasset.Rows.RemoveAt(rowIndex)

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
    Private Function uiTrnBookasset_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim bookasset_id As String
        Dim channel_id As String

        bookasset_id = Me.DgvTrnBookasset.Rows(rowIndex).Cells("bookasset_id").Value
        channel_id = Me.DgvTrnBookasset.Rows(rowIndex).Cells("channel_id").Value
        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(bookasset_id)

        Try
            dbConn.Open()
            Me.uiTrnBookasset_OpenRowMaster(channel_id, bookasset_id, dbConn)
            Me.uiTrnBookasset_OpenRowDetil(channel_id, bookasset_id, dbConn)

            If Me.DgvTrnBookassetdetil.Rows.Count = 0 Then
                Me.obj_Bookasset_startdt.Enabled = True
                Me.obj_Bookasset_starttm.ReadOnly = False
                Me.obj_Bookasset_enddt.Enabled = True
                Me.obj_Bookasset_endtm.ReadOnly = False
            Else
                Me.obj_Bookasset_startdt.Enabled = False
                Me.obj_Bookasset_starttm.ReadOnly = True
                Me.obj_Bookasset_enddt.Enabled = False
                Me.obj_Bookasset_endtm.ReadOnly = True
            End If

            If Me.obj_Project_id.SelectedValue Is Nothing Then
                Me.Obj_Asset_No_Project.Text = 0
            Else
                Me.Obj_Asset_No_Project.Text = clsUtil.IsDbNull(Me.obj_Project_id.SelectedValue, 0)
            End If

            If Me.obj_Bookasset_lock.Checked = True Then
                Me.PnlDataMaster.Enabled = False
                Me.DgvTrnBookassetdetil.AllowUserToDeleteRows = False
            Else
                Me.PnlDataMaster.Enabled = True
                Me.DgvTrnBookassetdetil.AllowUserToDeleteRows = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnBookasset_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(bookasset_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function
    Private Function uiTrnBookasset_OpenRowMaster(ByVal channel_id As String, ByVal bookasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        dbCmd = New OleDb.OleDbCommand("as_TrnBookasset_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format(" and bookasset_id='{0}'", bookasset_id)
        dbCmd.Parameters.Add("@top", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@top").Value = Me.NumericUpDown1.Value
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnBookasset_Temp.Clear()
        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnBookasset_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnBookasset_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnBookasset_OpenRowDetil(ByVal channel_id As String, ByVal bookasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnBookassetdetil_Select", dbConn)
        'dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        'dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format(" bookasset_id='{0}'", bookasset_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnBookassetdetil.Clear()

        Me.tbl_TrnBookassetdetil = clsDataset.CreateTblTrnBookassetdetil()
        Me.tbl_TrnBookassetdetil.Columns("channel_id").DefaultValue = _CHANNEL
        Me.tbl_TrnBookassetdetil.Columns("bookasset_id").DefaultValue = bookasset_id
        Me.tbl_TrnBookassetdetil.Columns("line").DefaultValue = DBNull.Value
        Me.tbl_TrnBookassetdetil.Columns("line").AutoIncrement = True
        Me.tbl_TrnBookassetdetil.Columns("line").AutoIncrementSeed = 1
        Me.tbl_TrnBookassetdetil.Columns("line").AutoIncrementStep = 1

        Try
            dbDA.Fill(Me.tbl_TrnBookassetdetil)
            Me.DgvTrnBookassetdetil.DataSource = Me.tbl_TrnBookassetdetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnBookasset_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnBookasset_First() As Boolean
        'goto first record found
        If Me.DgvTrnBookasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnBookasset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnBookasset.CurrentCell = Me.DgvTrnBookasset(1, 0)
            Me.uiTrnBookasset_RefreshPosition()
        End If
    End Function
    Private Function uiTrnBookasset_Prev() As Boolean
        'goto previous record found
        If Me.DgvTrnBookasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnBookasset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnBookasset.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnBookasset.CurrentCell = Me.DgvTrnBookasset(1, DgvTrnBookasset.CurrentCell.RowIndex - 1)
                Me.uiTrnBookasset_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnBookasset_Next() As Boolean
        'goto next record found
        If Me.DgvTrnBookasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnBookasset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnBookasset.CurrentCell.RowIndex < Me.DgvTrnBookasset.Rows.Count - 1 Then
                Me.DgvTrnBookasset.CurrentCell = Me.DgvTrnBookasset(1, DgvTrnBookasset.CurrentCell.RowIndex + 1)
                Me.uiTrnBookasset_RefreshPosition()
            End If
        End If
    End Function
    Private Function uiTrnBookasset_Last() As Boolean
        'goto last record found
        If Me.DgvTrnBookasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnBookasset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnBookasset.CurrentCell = Me.DgvTrnBookasset(1, Me.DgvTrnBookasset.Rows.Count - 1)
            Me.uiTrnBookasset_RefreshPosition()
        End If
    End Function
    Private Function uiTrnBookasset_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnBookasset_OpenRow(Me.DgvTrnBookasset.CurrentRow.Index)
    End Function
    Private Function uiTrnBookasset_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnBookasset_Temp_Changes As DataTable
        Dim tbl_TrnBookassetdetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim bookasset_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvTrnBookasset.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnBookasset_Temp).EndCurrentEdit()
            tbl_TrnBookasset_Temp_Changes = Me.tbl_TrnBookasset_Temp.GetChanges()

            Me.DgvTrnBookassetdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnBookassetdetil).EndCurrentEdit()
            tbl_TrnBookassetdetil_Changes = Me.tbl_TrnBookassetdetil.GetChanges()

            If tbl_TrnBookasset_Temp_Changes IsNot Nothing Or tbl_TrnBookassetdetil_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(bookasset_id)

                        Try

                            If tbl_TrnBookasset_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnBookasset_SaveMaster(bookasset_id, tbl_TrnBookasset_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_TrnBookasset_Temp.AcceptChanges()
                            End If

                            If tbl_TrnBookassetdetil_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnBookassetdetil.Rows.Count - 1
                                    If Me.tbl_TrnBookassetdetil.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnBookassetdetil.Rows(i).Item("bookasset_id") = bookasset_id
                                    End If
                                Next
                                success = Me.uiTrnBookasset_SaveDetil(bookasset_id, tbl_TrnBookassetdetil_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_TrnBookassetdetil.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(bookasset_id, result)

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
    Private Function uiTrnBookasset_FormError() As Boolean
        Dim ErrorMessage As String = ""
        'Dim ErrorFound As Boolean = False
        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")

            If Me.obj_Show_epsnumber_st.Text > Me.obj_Show_epsnumber_ed.Text Then
                ErrorMessage = "Episode to must be greater than episode from"
                Me.objFormError.SetError(Me.obj_Show_epsnumber_st, ErrorMessage)
                Me.objFormError.SetError(Me.obj_Show_epsnumber_ed, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Show_epsnumber_st, "")
            End If

            'If Me.obj_Bookasset_startdt.Text > Me.obj_Bookasset_enddt.Text Then
            If DateDiff(DateInterval.Second, CDate(Me.obj_Bookasset_startdt.Value), CDate(Me.obj_Bookasset_enddt.Value)) < 0 Then
                ErrorMessage = "End date must greater than start date"
                Me.objFormError.SetError(Me.obj_Bookasset_startdt, ErrorMessage)
                Throw New Exception(ErrorMessage)
            ElseIf DateDiff(DateInterval.Second, CDate(Me.obj_Bookasset_startdt.Value), CDate(Me.obj_Bookasset_enddt.Value)) = 0 Then
                If DateDiff(DateInterval.Second, CDate(Me.obj_Bookasset_starttm.Text), CDate(Me.obj_Bookasset_endtm.Text)) < 0 Then
                    ErrorMessage = "End time must be greater than start time"
                    Me.objFormError.SetError(Me.obj_Bookasset_starttm, ErrorMessage)
                    Throw New Exception(ErrorMessage)
                    Me.objFormError.SetError(Me.obj_Bookasset_starttm, "")
                End If
            End If

            If Me.obj_Employee_id_bookby.SelectedValue Is DBNull.Value Then
                ErrorMessage = "You must choose the book by combobox"
                Me.objFormError.SetError(Me.obj_Employee_id_bookby, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Employee_id_bookby, "")
            End If

            If Me.obj_Struktur_unit_bookby.SelectedValue Is DBNull.Value Then
                ErrorMessage = "You must choose the depatment combobox"
                Me.objFormError.SetError(Me.obj_Struktur_unit_bookby, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Struktur_unit_bookby, "")
            End If

            If Me.obj_Employee_id_customerhead.SelectedValue Is DBNull.Value Then
                ErrorMessage = "You must choose the cust. head combobox"
                Me.objFormError.SetError(Me.obj_Employee_id_customerhead, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Employee_id_customerhead, "")
            End If

            If Me.obj_Show_id.SelectedValue Is DBNull.Value Then
                ErrorMessage = "You must choose the program combobox"
                Me.objFormError.SetError(Me.obj_Show_id, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Show_id, "")
            End If

            If Me.obj_Project_id.SelectedValue = 0 Then
                ErrorMessage = "You must choose the budget combobox"
                Me.objFormError.SetError(Me.obj_Project_id, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Project_id, "")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

#Region " Individual Function "

    Private Function CheckItem() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnBookasset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnBookasset.CurrentCell = Me.DgvTrnBookasset(1, 0)
            Me.uiTrnBookasset_RefreshPosition()
        End If
    End Function

    Private Function uiTrnBookasset_Saveke2() As Boolean

        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)


        Try
            Dim dbCmdInsert As OleDb.OleDbCommand
            Dim kafir As String
            dbConn.Open()
            dbCmdInsert = New OleDb.OleDbCommand("as_TrnBookassetdetil_Insert", dbConn)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 100, "channel_id").Value = Me._CHANNEL
            dbCmdInsert.Parameters.Add("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.obj_Bookasset_id.Text
            dbCmdInsert.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4, "line").Value = 1
            dbCmdInsert.Parameters.Add("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode").Value = Trim(Me.TextBox1.Text)
            dbCmdInsert.Parameters.Add("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty").Value = 1
            dbCmdInsert.Parameters.Add("@status", System.Data.OleDb.OleDbType.Boolean, 1, "status").Value = 0
            dbCmdInsert.Parameters.Add("@sthari", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = CDate(obj_Bookasset_startdt.Value)
            dbCmdInsert.Parameters.Add("@edhari", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = CDate(obj_Bookasset_enddt.Value)
            dbCmdInsert.Parameters.Add("@sttime", System.Data.OleDb.OleDbType.VarWChar, 5).Value = Me.obj_Bookasset_starttm.Text
            dbCmdInsert.Parameters.Add("@edtime", System.Data.OleDb.OleDbType.VarWChar, 5).Value = Me.obj_Bookasset_endtm.Text
            dbCmdInsert.Parameters.Add("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, "strukturunit_id").Value = Me._STRUKTUR_UNIT 'Me.obj_Strukturunit_id.SelectedValue 'Me.retStrukturunit_id
            dbCmdInsert.Parameters.Add("@stat", System.Data.OleDb.OleDbType.VarWChar, 1).Direction = ParameterDirection.Output
            dbCmdInsert.ExecuteNonQuery()
            kafir = CStr(dbCmdInsert.Parameters("@stat").Value)
            'MsgBox(kafir)
            'Select Case kafir
            '    Case "A"
            '        MsgBox("Goods available")
            '    Case "N"
            '        MsgBox("Goods Unavailable")
            '    Case "U"
            '        MsgBox("Goods has been in list")
            'End Select

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
            Me.uiTrnBookasset_OpenRowMaster(_CHANNEL, Me.obj_Bookasset_id.Text, dbConn)
            Me.uiTrnBookasset_OpenRowDetil(_CHANNEL, Me.obj_Bookasset_id.Text, dbConn)

            If Me.DgvTrnBookassetdetil.Rows.Count = 0 Then
                Me.obj_Bookasset_startdt.Enabled = True
                Me.obj_Bookasset_starttm.ReadOnly = False
                Me.obj_Bookasset_enddt.Enabled = True
                Me.obj_Bookasset_endtm.ReadOnly = False
            Else
                Me.obj_Bookasset_startdt.Enabled = False
                Me.obj_Bookasset_starttm.ReadOnly = True
                Me.obj_Bookasset_enddt.Enabled = False
                Me.obj_Bookasset_endtm.ReadOnly = True
            End If

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

    Private Sub uiTrnBookasset_FormBeforeNew() Handles Me.FormBeforeNew
        Me.objFormError.Clear()
    End Sub

    Private Sub uiTrnBookasset_FormBeforeOpenRow(ByRef id As Object) Handles Me.FormBeforeOpenRow
        Me.objFormError.Clear()
    End Sub
    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        objParameters = Me.GetParameterCollection(Me.Parameter)

        Me.DgvTrnBookasset.DataSource = Me.tbl_TrnBookasset

        If Application.ProductName = _ProductName Then
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
            Me._STRUKTUR_UNIT_ID_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CANCHANGEDSU")
            Me._STRUKTUR_UNIT_ID_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CANBROWSEDSU")
            Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        End If

        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
        '    Dim dummyparameter As String = "CHANNEL=TTV; STRUKTUR_UNIT_ID = 5517;SU_EMPLOYEE=9002000;"   'Fill Combobox
        '    'dan fungsi2 startup lainnya....
        '    objParameters = Me.GetParameterCollection(dummyparameter)

        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")

        '    Me._STRUKTUR_UNIT = Me.GetValueFromParameter(objParameters, "STRUKTUR_UNIT_ID")
        '    Me._STRUKTUR_UNIT_ID_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CANCHANGEDSU")
        '    Me._STRUKTUR_UNIT_ID_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CANBROWSEDSU")
        '    Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        'End If


        loadcombodata = False

        Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", Me.tbl_MstChannelSearch, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'")
        Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_id"

        Me.ComboFill(Me.cboSearchStrukturunit_id, "strukturunit_id", "strukturunit_name", Me.tbl_schStrukturUnit, "as_MstStrukturUnit_Select", "  ")
        Me.tbl_schStrukturUnit.DefaultView.Sort = "strukturunit_name"
        Dim copyTbl_DepartmentSearch
        Me.tbl_schStrukturUnitBookBy = Me.tbl_schStrukturUnit.Copy
        copyTbl_DepartmentSearch = ComboFillFromDataTable(cboSearchDepartmentBookBy, "strukturunit_id", "strukturunit_name", Me.tbl_schStrukturUnitBookBy)
        'Me.ComboFill(Me.cboSearchDepartmentBookBy, "strukturunit_id", "strukturunit_name", Me.tbl_schStrukturUnitBookBy, "as_MstStrukturUnit_Select", "  ")
        Me.tbl_schStrukturUnitBookBy.DefaultView.Sort = "strukturunit_name"

        Me.ComboFill(Me.cboSearchBookBy, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeebookSearch, "ms_MstEmployee_Select", " ") 'strukturunit_id = " & Me._SU_EMPLOYEE)
        Me.tbl_MstEmployeebookSearch.DefaultView.Sort = "employee_namalengkap"


        Me.cboSearchChannel.SelectedValue = Me._CHANNEL
        Me.cboSearchStrukturunit_id.SelectedValue = Me._STRUKTUR_UNIT

        Me.InitLayoutUI()
        Me.BindingStop()
        Me.BindingStart()

        Me.uiTrnBookasset_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

        ' kunci dari parameter

        Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_CHANGED
        Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
        Me.obj_Channel_id.Enabled = Me._CHANNEL_CANBE_BROWSED

        Me.chkSearchStrukturUnit_id.Enabled = Me._STRUKTUR_UNIT_ID_CANBE_CHANGED
        Me.cboSearchStrukturunit_id.Enabled = Me._STRUKTUR_UNIT_ID_CANBE_BROWSED
        Me.obj_Strukturunit_id.Enabled = Me._STRUKTUR_UNIT_ID_CANBE_BROWSED

        Me.chkSearchStrukturUnit_id.Checked = True
        Me.chkSearchChannel.Checked = True

        'Me.ftabDataDetil.SelectedIndex = 1
        'Me.ftabDataDetil.SelectedIndex = 0

        Me.obj_Channel_id.Enabled = Me._CHANNEL_CANBE_CHANGED
        Me.obj_Strukturunit_id.Enabled = False

        Dim myCI As New System.Globalization.CultureInfo("en-GB", False)
        Dim myCIclone As System.Globalization.CultureInfo = CType(myCI.Clone(), System.Globalization.CultureInfo)
        myCIclone.DateTimeFormat.AMDesignator = "a.m."
        myCIclone.DateTimeFormat.DateSeparator = "/"
        myCIclone.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        myCIclone.NumberFormat.CurrencySymbol = "$"
        myCIclone.NumberFormat.NumberDecimalDigits = 4
        System.Threading.Thread.CurrentThread.CurrentCulture = myCIclone

        Me.btnlock.ToolTipText = "Lock Transaction"
        Me.ToolStrip1.Items.Add(Me.btnlock)
        Me.btnlock.Image = Me.ImageList1.Images(0)
    End Sub

    Private Sub uiTrnBookasset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                'Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                'Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
                Me.btnlock.Enabled = True

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.btnlock.Enabled = False
                'Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                'Me.ftabMain.TabPages.Item(1).BackColor = Color.White
                loadcombo()

                If Me.DgvTrnBookasset.CurrentRow IsNot Nothing Then
                    Me.uiTrnBookasset_OpenRow(Me.DgvTrnBookasset.CurrentRow.Index)
                    'Me.obj_Bookasset_enddt.Enabled = False
                    'Me.obj_Bookasset_endtm.ReadOnly = True
                    'Me.obj_Bookasset_startdt.Enabled = False
                    'Me.obj_Bookasset_starttm.ReadOnly = True
                Else
                    Me.uiTrnBookasset_NewData()
                End If

                If Me.obj_Bookasset_lock.Checked = True Then
                    PnlDataMaster.Enabled = False
                Else
                    PnlDataMaster.Enabled = True
                End If
        End Select
    End Sub
    Private Sub DgvTrnBookasset_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnBookasset.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnBookasset.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        Me.TextBox1.Text = ""
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar.ToString = Microsoft.VisualBasic.ChrW(13) Then

            If Trim(Me.obj_Bookasset_id.Text) = "AUTO" Then
                MsgBox("Save Header Transaction First")
                Exit Sub
            End If

            If Len(Trim(Me.TextBox1.Text)) >= 2 Then

                Me.uiTrnBookasset_Saveke2()
                Me.Cursor = Cursors.Arrow

            Else
                MsgBox("Please Input Item", MsgBoxStyle.Information, "Warning")
                Me.TextBox1.Text = ""
                Me.TextBox1.Focus()
                Exit Sub
            End If
            Me.TextBox1.Text = "- - Item Booking - -"
        End If
    End Sub
    Private Sub LockData()


        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor


        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_Locktransaksi_booking", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnBookasset.Item("bookasset_id", DgvTrnBookasset.CurrentRow.Index).Value

            oCm.ExecuteNonQuery()
            oCm.Dispose()
            Me.obj_Bookasset_lock.Checked = True
            Me.DgvTrnBookasset.Item("bookasset_lock", DgvTrnBookasset.CurrentRow.Index).Value = 1
            Me.PnlDataMaster.Enabled = False
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
    'Private Sub coba()
    '    Dim criteria As String = String.Format(" and bookasset_id = '{0}'", Me.obj_Bookasset_id.Text)
    '    Dim tbl As New DataTable
    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

    '    Try
    '        tbl.Rows.Clear()
    '        DataFill(tbl, "as_TrnBookasset_Select", criteria, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)
    '        retStrukturunit_id = tbl.Rows(0)("strukturunit_id")

    '    Catch ex As Exception

    '    End Try

    'End Sub
    Private Sub loadcombo()
        If Me.loadcombodata = False Then
            Me.ComboFill(Me.obj_Channel_id, "channel_id", "channel_id", Me.tbl_MstChannel, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'", "")
            Me.tbl_MstChannel.DefaultView.Sort = "channel_id"

            Dim copyTbl_employee_search As Boolean
            Me.tbl_MstEmployeebook = tbl_MstEmployeebookSearch.Copy
            copyTbl_employee_search = ComboFillFromDataTable(obj_Employee_id_bookby, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeebook)
            'Me.ComboFill(Me.obj_Employee_id_bookby, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeebook, "ms_MstEmployee_Select", " ") 'strukturunit_id = " & Me._SU_EMPLOYEE)
            Me.tbl_MstEmployeebook.DefaultView.Sort = "employee_namalengkap"
            Dim CopyTbl_Employee As Boolean
            Me.tbl_MstEmployeecustomerhead = tbl_MstEmployeebookSearch.Copy
            CopyTbl_Employee = ComboFillFromDataTable(obj_Employee_id_customerhead, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeecustomerhead)
            Me.tbl_MstEmployeecustomerhead.DefaultView.Sort = "employee_namalengkap"

            Dim copyTbl_department_search As Boolean
            Me.tbl_MstStrukturunitBook = Me.tbl_schStrukturUnit.Copy
            copyTbl_department_search = ComboFillFromDataTable(Me.obj_Struktur_unit_bookby, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitBook)
            'Me.ComboFill(Me.obj_Struktur_unit_bookby, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitBook, "as_MstStrukturUnit_Select", "  ")
            Me.tbl_MstStrukturunitBook.DefaultView.Sort = "strukturunit_name"
            Dim CopyTbl_Department As Boolean
            Me.tbl_MstStrukturunitOwner = tbl_schStrukturUnit.Copy
            CopyTbl_Department = ComboFillFromDataTable(Me.obj_Strukturunit_id, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitOwner)
            Me.tbl_MstStrukturunitOwner.DefaultView.Sort = "strukturunit_name"

            Me.ComboFill(Me.obj_Show_id, "show_id", "show_title", Me.tbl_show, "as_MstShow_Select ", " show_active = 1 ", _CHANNEL)
            tbl_show.DefaultView.Sort = "show_title"

            Me.ComboFillAngka(Me.ASSET_DSN, Me.obj_Project_id, "budget_id", "budget_name", Me.tbl_project, "as_MstProject_Select", "  ", _CHANNEL)
            Me.tbl_project.DefaultView.Sort = "budget_name"


            'Me.ftabDataDetil.SelectedIndex = 1
            'Me.ftabDataDetil.SelectedIndex = 0
            loadcombodata = True
        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Me.TextBox1.Text = "- - Item Booking - -"
    End Sub

    Private Sub Obj_Asset_No_Project_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Obj_Asset_No_Project.Validated
        Dim criteria As String = String.Empty
        Dim budget As DataTable = New DataTable

        If Me.Obj_Asset_No_Project.Text = String.Empty Then
            Exit Sub
        End If
        criteria = String.Format(" budget_id = " & Me.Obj_Asset_No_Project.Text)
        Me.DataFill(budget, "as_MstProject_Select", criteria, Me._CHANNEL)

        If budget.Rows.Count <= 0 Then
            Me.obj_Project_id.SelectedValue = 0
            Me.Obj_Asset_No_Project.Text = 0
            Me.obj_Show_epsnumber_st.Text = 0
            Me.obj_Show_epsnumber_ed.Text = 0
        Else
            Me.obj_Project_id.SelectedValue = clsUtil.IsDbNull(budget.Rows(0).Item("budget_id"), 0)
            Me.obj_Show_epsnumber_st.Text = clsUtil.IsDbNull(budget.Rows(0).Item("budget_epsstart"), 0)
            Me.obj_Show_epsnumber_ed.Text = clsUtil.IsDbNull(budget.Rows(0).Item("budget_epsend"), 0)
        End If
    End Sub

    Private Sub obj_Project_id_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Project_id.SelectionChangeCommitted
        'Me.Obj_Asset_No_Project.Text = clsUtil.IsDbNull(Me.obj_Project_id.SelectedValue, 0)
        Dim criteria As String = String.Empty
        Dim budget As DataTable = New DataTable

        If Me.obj_Project_id.SelectedValue = 0 Then
            Me.Obj_Asset_No_Project.Text = 0
            Me.obj_Show_epsnumber_st.Text = 0
            Me.obj_Show_epsnumber_ed.Text = 0
            Exit Sub
        End If
        criteria = String.Format(" budget_id = " & Me.obj_Project_id.SelectedValue)
        Me.DataFill(budget, "as_MstProject_Select", criteria, Me._CHANNEL)

        If budget.Rows.Count <= 0 Then
            Me.obj_Project_id.SelectedValue = 0
            Me.Obj_Asset_No_Project.Text = 0
            Me.obj_Show_epsnumber_st.Text = 0
            Me.obj_Show_epsnumber_ed.Text = 0
        Else
            Me.Obj_Asset_No_Project.Text = clsUtil.IsDbNull(budget.Rows(0).Item("budget_id"), 0)
            Me.obj_Show_epsnumber_st.Text = clsUtil.IsDbNull(budget.Rows(0).Item("budget_epsstart"), 0)
            Me.obj_Show_epsnumber_ed.Text = clsUtil.IsDbNull(budget.Rows(0).Item("budget_epsend"), 0)
        End If

    End Sub



    Private Sub DgvTrnBookasset_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnBookasset.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

        Try
            If objrow.Cells("bookasset_lock").Value = 0 And objrow.Cells("outasset_id").Value Is DBNull.Value Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            ElseIf objrow.Cells("bookasset_lock").Value = True And objrow.Cells("outasset_id").Value Is DBNull.Value Then
                objrow.DefaultCellStyle.BackColor = Color.Bisque
            ElseIf objrow.Cells("bookasset_lock").Value = True And objrow.Cells("outasset_id").Value IsNot DBNull.Value Then
                objrow.DefaultCellStyle.BackColor = Color.PowderBlue
            Else
                objrow.DefaultCellStyle.BackColor = Color.Aqua

            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub obj_Project_id_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Project_id.SelectedIndexChanged

    End Sub
End Class