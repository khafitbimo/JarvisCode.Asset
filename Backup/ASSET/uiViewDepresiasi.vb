Public Class uiViewDepresiasi
    Private Const mUiName As String = "View Depresiasi"
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

    Private _LOADCOMBOSEARCH As Boolean = False

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_viewDepresiasi As DataTable = clsDataset.CreateTblTrnDepresiasi()
    Private tbl_viewDepresiasi_Temp As DataTable = clsDataset.CreateTblTrnDepresiasi()
    Private tbl_viewDepresiasiDetil As DataTable = clsDataset.CreateTblTrnDepresiasidetil()
    Private tbl_MstStruktur_unit As DataTable = clsDataset.CreateTblMstStrukturunit
    Private tbl_mstKategoriAsset As DataTable = clsDataset.CreateTblMstKategoriasset


#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TTV"
    'Private _STRUKTUR_UNIT As Decimal = "5554"
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
        Me.UiViewDepresiasi_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function
    Public Overrides Function btnLoad_Click() As Boolean
        Me.objFormError.Clear()
        Me.Cursor = Cursors.WaitCursor
        Me.UiViewDepresiasi_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Public Overrides Function btnSave_Click() As Boolean
        Me.objFormError.Clear()
        If Me.UiViewDepresiasi_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        'Me.UiTrnBPBProcurement_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function
    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        MessageBox.Show("Data Cannot Be Deleted", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function
    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiViewDepresiasi_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiViewDepresiasi_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiViewDepresiasi_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiViewDepresiasi_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

#End Region


#Region " Layout & Init UI "

    Private Function FormatDgvTrnDepresiasi(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnDepresiasi Columns 

        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepresiasi_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepresiasi_tgl As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepresiasi_thn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepresiasi_bln As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategoriasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategoriasset_time As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategoriasset_depresiasitime As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategoriasset_depresiasivalue As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTotal_item As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTotal_item_depre As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_beginning As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_additional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_deductional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_ending As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepre_beginning As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepre_additional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepre_deductional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepre_ending As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLock As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cLock_login As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLock_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPost As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPost_login As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPostdate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cNBV As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEdit_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEdit_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUsed_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUsed_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = False

        cDepresiasi_id.Name = "depresiasi_id"
        cDepresiasi_id.HeaderText = "ID"
        cDepresiasi_id.DataPropertyName = "depresiasi_id"
        cDepresiasi_id.Width = 100
        cDepresiasi_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepresiasi_id.Visible = True
        cDepresiasi_id.ReadOnly = False

        cDepresiasi_tgl.Name = "depresiasi_tgl"
        cDepresiasi_tgl.HeaderText = "Date"
        cDepresiasi_tgl.DataPropertyName = "depresiasi_tgl"
        cDepresiasi_tgl.Width = 100
        cDepresiasi_tgl.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepresiasi_tgl.Visible = False
        cDepresiasi_tgl.ReadOnly = False

        cDepresiasi_thn.Name = "depresiasi_thn"
        cDepresiasi_thn.HeaderText = "Year"
        cDepresiasi_thn.DataPropertyName = "depresiasi_thn"
        cDepresiasi_thn.Width = 100
        cDepresiasi_thn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepresiasi_thn.Visible = False
        cDepresiasi_thn.ReadOnly = False

        cDepresiasi_bln.Name = "depresiasi_bln"
        cDepresiasi_bln.HeaderText = "Month"
        cDepresiasi_bln.DataPropertyName = "depresiasi_bln"
        cDepresiasi_bln.Width = 100
        cDepresiasi_bln.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepresiasi_bln.Visible = False
        cDepresiasi_bln.ReadOnly = False

        cKategoriasset_id.Name = "kategoriasset_id"
        cKategoriasset_id.HeaderText = "Category"
        cKategoriasset_id.DataPropertyName = "kategoriasset_id"
        cKategoriasset_id.Width = 250
        cKategoriasset_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriasset_id.Visible = True
        cKategoriasset_id.ReadOnly = False

        cKategoriasset_time.Name = "kategoriasset_time"
        cKategoriasset_time.HeaderText = "kategoriasset_time"
        cKategoriasset_time.DataPropertyName = "kategoriasset_time"
        cKategoriasset_time.Width = 100
        cKategoriasset_time.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriasset_time.Visible = False
        cKategoriasset_time.ReadOnly = False

        cKategoriasset_depresiasitime.Name = "kategoriasset_depresiasitime"
        cKategoriasset_depresiasitime.HeaderText = "kategoriasset_depresiasitime"
        cKategoriasset_depresiasitime.DataPropertyName = "kategoriasset_depresiasitime"
        cKategoriasset_depresiasitime.Width = 100
        cKategoriasset_depresiasitime.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriasset_depresiasitime.Visible = False
        cKategoriasset_depresiasitime.ReadOnly = False

        cKategoriasset_depresiasivalue.Name = "kategoriasset_depresiasivalue"
        cKategoriasset_depresiasivalue.HeaderText = "kategoriasset_depresiasivalue"
        cKategoriasset_depresiasivalue.DataPropertyName = "kategoriasset_depresiasivalue"
        cKategoriasset_depresiasivalue.Width = 100
        cKategoriasset_depresiasivalue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriasset_depresiasivalue.Visible = False
        cKategoriasset_depresiasivalue.ReadOnly = False

        cTotal_item.Name = "total_item"
        cTotal_item.HeaderText = "Item"
        cTotal_item.DataPropertyName = "total_item"
        cTotal_item.Width = 100
        cTotal_item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTotal_item.Visible = False
        cTotal_item.ReadOnly = False

        cTotal_item_depre.Name = "total_item_depre"
        cTotal_item_depre.HeaderText = "Item Depr."
        cTotal_item_depre.DataPropertyName = "total_item_depre"
        cTotal_item_depre.Width = 100
        cTotal_item_depre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTotal_item_depre.Visible = False
        cTotal_item_depre.ReadOnly = False

        cCost_beginning.Name = "cost_beginning"
        cCost_beginning.HeaderText = "Cost Beginning"
        cCost_beginning.DataPropertyName = "cost_beginning"
        cCost_beginning.Width = 150
        cCost_beginning.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_beginning.Visible = True
        cCost_beginning.ReadOnly = False
        cCost_beginning.DefaultCellStyle.Format = "###,##0.00"

        cCost_additional.Name = "cost_additional"
        cCost_additional.HeaderText = "Cost Additional"
        cCost_additional.DataPropertyName = "cost_additional"
        cCost_additional.Width = 150
        cCost_additional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_additional.Visible = True
        cCost_additional.ReadOnly = False
        cCost_additional.DefaultCellStyle.Format = "###,##0.00"

        cCost_deductional.Name = "cost_deductional"
        cCost_deductional.HeaderText = "Cost Deductional"
        cCost_deductional.DataPropertyName = "cost_deductional"
        cCost_deductional.Width = 150
        cCost_deductional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_deductional.Visible = True
        cCost_deductional.ReadOnly = False
        cCost_deductional.DefaultCellStyle.Format = "###,##0.00"

        cCost_ending.Name = "cost_ending"
        cCost_ending.HeaderText = "Cost Ending"
        cCost_ending.DataPropertyName = "cost_ending"
        cCost_ending.Width = 150
        cCost_ending.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_ending.Visible = True
        cCost_ending.ReadOnly = False
        cCost_ending.DefaultCellStyle.Format = "###,##0.00"

        cDepre_beginning.Name = "depre_beginning"
        cDepre_beginning.HeaderText = "Depreciation Beginning"
        cDepre_beginning.DataPropertyName = "depre_beginning"
        cDepre_beginning.Width = 150
        cDepre_beginning.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepre_beginning.Visible = True
        cDepre_beginning.ReadOnly = False
        cDepre_beginning.DefaultCellStyle.Format = "###,##0.00"

        cDepre_additional.Name = "depre_additional"
        cDepre_additional.HeaderText = "Depreciation Additional"
        cDepre_additional.DataPropertyName = "depre_additional"
        cDepre_additional.Width = 150
        cDepre_additional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepre_additional.Visible = True
        cDepre_additional.ReadOnly = False
        cDepre_additional.DefaultCellStyle.Format = "###,##0.00"

        cDepre_deductional.Name = "depre_deductional"
        cDepre_deductional.HeaderText = "Depreciation Deductional"
        cDepre_deductional.DataPropertyName = "depre_deductional"
        cDepre_deductional.Width = 160
        cDepre_deductional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepre_deductional.Visible = True
        cDepre_deductional.ReadOnly = False
        cDepre_deductional.DefaultCellStyle.Format = "###,##0.00"

        cDepre_ending.Name = "depre_ending"
        cDepre_ending.HeaderText = "Depreciation Ending"
        cDepre_ending.DataPropertyName = "depre_ending"
        cDepre_ending.Width = 150
        cDepre_ending.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepre_ending.Visible = True
        cDepre_ending.ReadOnly = False
        cDepre_ending.DefaultCellStyle.Format = "###,##0.00"

        cLock.Name = "lock"
        cLock.HeaderText = "Confirm"
        cLock.DataPropertyName = "lock"
        cLock.Width = 60
        cLock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cLock.Visible = True
        cLock.ReadOnly = False

        cLock_login.Name = "lock_login"
        cLock_login.HeaderText = "Lock By"
        cLock_login.DataPropertyName = "lock_login"
        cLock_login.Width = 100
        cLock_login.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLock_login.Visible = False
        cLock_login.ReadOnly = False

        cLock_dt.Name = "lock_dt"
        cLock_dt.HeaderText = "Lock Date"
        cLock_dt.DataPropertyName = "lock_dt"
        cLock_dt.Width = 100
        cLock_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLock_dt.Visible = False
        cLock_dt.ReadOnly = False

        cPost.Name = "post"
        cPost.HeaderText = "Post"
        cPost.DataPropertyName = "post"
        cPost.Width = 100
        cPost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPost.Visible = False
        cPost.ReadOnly = False

        cPost_login.Name = "post_login"
        cPost_login.HeaderText = "Post By"
        cPost_login.DataPropertyName = "post_login"
        cPost_login.Width = 100
        cPost_login.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPost_login.Visible = False
        cPost_login.ReadOnly = False

        cPostdate.Name = "postdate"
        cPostdate.HeaderText = "Post Date"
        cPostdate.DataPropertyName = "postdate"
        cPostdate.Width = 100
        cPostdate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPostdate.Visible = False
        cPostdate.ReadOnly = False

        cNBV.Name = "NBV"
        cNBV.HeaderText = "NBV"
        cNBV.DataPropertyName = "NBV"
        cNBV.Width = 150
        cNBV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cNBV.Visible = True
        cNBV.ReadOnly = False
        cNBV.DefaultCellStyle.Format = "###,##0.00"

        cCreate_by.Name = "create_by"
        cCreate_by.HeaderText = "Create By"
        cCreate_by.DataPropertyName = "create_by"
        cCreate_by.Width = 100
        cCreate_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCreate_by.Visible = False
        cCreate_by.ReadOnly = False

        cCreate_dt.Name = "create_dt"
        cCreate_dt.HeaderText = "Create Date"
        cCreate_dt.DataPropertyName = "create_dt"
        cCreate_dt.Width = 100
        cCreate_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCreate_dt.Visible = False
        cCreate_dt.ReadOnly = False

        cEdit_by.Name = "edit_by"
        cEdit_by.HeaderText = "Edit By"
        cEdit_by.DataPropertyName = "edit_by"
        cEdit_by.Width = 100
        cEdit_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEdit_by.Visible = False
        cEdit_by.ReadOnly = False

        cEdit_dt.Name = "edit_dt"
        cEdit_dt.HeaderText = "Edit Date"
        cEdit_dt.DataPropertyName = "edit_dt"
        cEdit_dt.Width = 100
        cEdit_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEdit_dt.Visible = False
        cEdit_dt.ReadOnly = False

        cUsed_by.Name = "used_by"
        cUsed_by.HeaderText = "Used By"
        cUsed_by.DataPropertyName = "used_by"
        cUsed_by.Width = 100
        cUsed_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUsed_by.Visible = False
        cUsed_by.ReadOnly = False

        cUsed_dt.Name = "used_dt"
        cUsed_dt.HeaderText = "Used Date"
        cUsed_dt.DataPropertyName = "used_dt"
        cUsed_dt.Width = 100
        cUsed_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUsed_dt.Visible = False
        cUsed_dt.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cLock, cKategoriasset_id, cTotal_item_depre, _
        cCost_beginning, cCost_additional, cCost_deductional, _
        cCost_ending, cDepre_beginning, cDepre_additional, cDepre_deductional, cDepre_ending, _
         cNBV, cChannel_id, cDepresiasi_id, cDepresiasi_tgl, cDepresiasi_thn, _
        cDepresiasi_bln, cKategoriasset_time, _
        cKategoriasset_depresiasitime, cKategoriasset_depresiasivalue, _
        cTotal_item, cLock_login, cLock_dt, cPost, cPost_login, _
        cPostdate, cCreate_by, cCreate_dt, cEdit_by, cEdit_dt, cUsed_by, cUsed_dt})

        ' DgvTrnDepresiasi Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True

        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function
    Private Function FormatDgvTrnDepresiasidetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cDepresiasi_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepresiasi_thn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepresiasi_bln As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_strukturunit As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_kategori As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategori_time As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJumlah_depre As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_beginning As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_additional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_deductional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_ending As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepre_beginning As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepre_additional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepre_deductional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepre_ending As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cNBV As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_stdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_eddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCreate_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEdit_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEdit_dt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_tipedepre As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepresiasi_remark As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepresiasi_kali As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_golpajak As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim casset_deskripsi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepartment As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cDepresiasi_id.Name = "depresiasi_id"
        cDepresiasi_id.HeaderText = "ID"
        cDepresiasi_id.DataPropertyName = "depresiasi_id"
        cDepresiasi_id.Width = 100
        cDepresiasi_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepresiasi_id.Visible = False
        cDepresiasi_id.ReadOnly = False


        cAsset_barcode.Name = "asset_barcode"
        cAsset_barcode.HeaderText = "Barcode"
        cAsset_barcode.DataPropertyName = "asset_barcode"
        cAsset_barcode.Width = 100
        cAsset_barcode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_barcode.Visible = True
        cAsset_barcode.ReadOnly = False
        cAsset_barcode.Frozen = True


        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cDepresiasi_thn.Name = "depresiasi_thn"
        cDepresiasi_thn.HeaderText = "Tahun"
        cDepresiasi_thn.DataPropertyName = "depresiasi_thn"
        cDepresiasi_thn.Width = 100
        cDepresiasi_thn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepresiasi_thn.Visible = False
        cDepresiasi_thn.ReadOnly = False

        cDepresiasi_bln.Name = "depresiasi_bln"
        cDepresiasi_bln.HeaderText = "Bulan"
        cDepresiasi_bln.DataPropertyName = "depresiasi_bln"
        cDepresiasi_bln.Width = 100
        cDepresiasi_bln.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepresiasi_bln.Visible = False
        cDepresiasi_bln.ReadOnly = False

        cAsset_strukturunit.Name = "asset_strukturunit"
        cAsset_strukturunit.HeaderText = "Department"
        cAsset_strukturunit.DataPropertyName = "asset_strukturunit"
        cAsset_strukturunit.Width = 100
        cAsset_strukturunit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_strukturunit.Visible = False
        cAsset_strukturunit.ReadOnly = False

        cAsset_kategori.Name = "asset_kategori"
        cAsset_kategori.HeaderText = "Category"
        cAsset_kategori.DataPropertyName = "asset_kategori"
        cAsset_kategori.Width = 100
        cAsset_kategori.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_kategori.Visible = True
        cAsset_kategori.ReadOnly = False

        cKategori_time.Name = "kategori_time"
        cKategori_time.HeaderText = "Times"
        cKategori_time.DataPropertyName = "kategori_time"
        cKategori_time.Width = 100
        cKategori_time.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategori_time.Visible = True
        cKategori_time.ReadOnly = False

        cJumlah_depre.Name = "Jumlah_depre"
        cJumlah_depre.HeaderText = "Jumlah_depre"
        cJumlah_depre.DataPropertyName = "Jumlah_depre"
        cJumlah_depre.Width = 100
        cJumlah_depre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJumlah_depre.Visible = False
        cJumlah_depre.ReadOnly = False

        cCost_beginning.Name = "cost_beginning"
        cCost_beginning.HeaderText = "Cost Beginning"
        cCost_beginning.DataPropertyName = "cost_beginning"
        cCost_beginning.Width = 150
        cCost_beginning.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_beginning.Visible = True
        cCost_beginning.ReadOnly = False
        cCost_beginning.DefaultCellStyle.Format = "###,##0.00"

        cCost_additional.Name = "cost_additional"
        cCost_additional.HeaderText = "Cost Additional"
        cCost_additional.DataPropertyName = "cost_additional"
        cCost_additional.Width = 150
        cCost_additional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_additional.Visible = True
        cCost_additional.ReadOnly = False
        cCost_additional.DefaultCellStyle.Format = "###,##0.00"

        cCost_deductional.Name = "cost_deductional"
        cCost_deductional.HeaderText = "Cost Deductional"
        cCost_deductional.DataPropertyName = "cost_deductional"
        cCost_deductional.Width = 150
        cCost_deductional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_deductional.Visible = True
        cCost_deductional.ReadOnly = False
        cCost_deductional.DefaultCellStyle.Format = "###,##0.00"

        cCost_ending.Name = "cost_ending"
        cCost_ending.HeaderText = "Cost Ending"
        cCost_ending.DataPropertyName = "cost_ending"
        cCost_ending.Width = 150
        cCost_ending.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_ending.Visible = True
        cCost_ending.ReadOnly = False
        cCost_ending.DefaultCellStyle.Format = "###,##0.00"

        cDepre_beginning.Name = "depre_beginning"
        cDepre_beginning.HeaderText = "Depr. Beginning"
        cDepre_beginning.DataPropertyName = "depre_beginning"
        cDepre_beginning.Width = 150
        cDepre_beginning.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepre_beginning.Visible = True
        cDepre_beginning.ReadOnly = False
        cDepre_beginning.DefaultCellStyle.Format = "###,##0.00"

        cDepre_additional.Name = "depre_additional"
        cDepre_additional.HeaderText = "Depr. Additional"
        cDepre_additional.DataPropertyName = "depre_additional"
        cDepre_additional.Width = 150
        cDepre_additional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepre_additional.Visible = True
        cDepre_additional.ReadOnly = False
        cDepre_additional.DefaultCellStyle.Format = "###,##0.00"

        cDepre_deductional.Name = "depre_deductional"
        cDepre_deductional.HeaderText = "Depr. Deductional"
        cDepre_deductional.DataPropertyName = "depre_deductional"
        cDepre_deductional.Width = 150
        cDepre_deductional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepre_deductional.Visible = True
        cDepre_deductional.ReadOnly = False
        cDepre_deductional.DefaultCellStyle.Format = "###,##0.00"

        cDepre_ending.Name = "depre_ending"
        cDepre_ending.HeaderText = "Depr. Ending"
        cDepre_ending.DataPropertyName = "depre_ending"
        cDepre_ending.Width = 150
        cDepre_ending.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepre_ending.Visible = True
        cDepre_ending.ReadOnly = False
        cDepre_ending.DefaultCellStyle.Format = "###,##0.00"

        cNBV.Name = "NBV"
        cNBV.HeaderText = "NBV"
        cNBV.DataPropertyName = "NBV"
        cNBV.Width = 150
        cNBV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cNBV.Visible = True
        cNBV.ReadOnly = False
        cNBV.DefaultCellStyle.Format = "###,##0.00"

        cAsset_stdt.Name = "asset_stdt"
        cAsset_stdt.HeaderText = "Start"
        cAsset_stdt.DataPropertyName = "asset_stdt"
        cAsset_stdt.Width = 100
        cAsset_stdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_stdt.Visible = True
        cAsset_stdt.ReadOnly = False

        cAsset_eddt.Name = "asset_eddt"
        cAsset_eddt.HeaderText = "End"
        cAsset_eddt.DataPropertyName = "asset_eddt"
        cAsset_eddt.Width = 100
        cAsset_eddt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_eddt.Visible = True
        cAsset_eddt.ReadOnly = False

        cCreate_by.Name = "create_by"
        cCreate_by.HeaderText = "create_by"
        cCreate_by.DataPropertyName = "create_by"
        cCreate_by.Width = 100
        cCreate_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCreate_by.Visible = False
        cCreate_by.ReadOnly = False

        cCreate_dt.Name = "create_dt"
        cCreate_dt.HeaderText = "create_dt"
        cCreate_dt.DataPropertyName = "create_dt"
        cCreate_dt.Width = 100
        cCreate_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCreate_dt.Visible = False
        cCreate_dt.ReadOnly = False

        cEdit_by.Name = "edit_by"
        cEdit_by.HeaderText = "edit_by"
        cEdit_by.DataPropertyName = "edit_by"
        cEdit_by.Width = 100
        cEdit_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEdit_by.Visible = False
        cEdit_by.ReadOnly = False

        cEdit_dt.Name = "edit_dt"
        cEdit_dt.HeaderText = "edit_dt"
        cEdit_dt.DataPropertyName = "edit_dt"
        cEdit_dt.Width = 100
        cEdit_dt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEdit_dt.Visible = False
        cEdit_dt.ReadOnly = False

        cAsset_tipedepre.Name = "asset_tipedepre"
        cAsset_tipedepre.HeaderText = "asset_tipedepre"
        cAsset_tipedepre.DataPropertyName = "asset_tipedepre"
        cAsset_tipedepre.Width = 100
        cAsset_tipedepre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_tipedepre.Visible = False
        cAsset_tipedepre.ReadOnly = False

        cDepresiasi_remark.Name = "depresiasi_remark"
        cDepresiasi_remark.HeaderText = "Remark"
        cDepresiasi_remark.DataPropertyName = "depresiasi_remark"
        cDepresiasi_remark.Width = 100
        cDepresiasi_remark.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepresiasi_remark.Visible = True
        cDepresiasi_remark.ReadOnly = False

        cDepresiasi_kali.Name = "depresiasi_kali"
        cDepresiasi_kali.HeaderText = "depresiasi_kali"
        cDepresiasi_kali.DataPropertyName = "depresiasi_kali"
        cDepresiasi_kali.Width = 100
        cDepresiasi_kali.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepresiasi_kali.Visible = True
        cDepresiasi_kali.ReadOnly = False

        cAsset_golpajak.Name = "asset_golpajak"
        cAsset_golpajak.HeaderText = "Tax"
        cAsset_golpajak.DataPropertyName = "asset_golpajak"
        cAsset_golpajak.Width = 100
        cAsset_golpajak.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_golpajak.Visible = True
        cAsset_golpajak.ReadOnly = False

        casset_deskripsi.Name = "asset_deskripsi"
        casset_deskripsi.HeaderText = "Description"
        casset_deskripsi.DataPropertyName = "asset_deskripsi"
        casset_deskripsi.Width = 200
        casset_deskripsi.Visible = True
        casset_deskripsi.ReadOnly = True
        casset_deskripsi.Frozen = True

        cDepartment.Name = "department"
        cDepartment.HeaderText = "Department"
        cDepartment.DataPropertyName = "department"
        cDepartment.Width = 150
        cDepartment.Visible = True
        cDepartment.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cAsset_barcode, casset_deskripsi, cAsset_stdt, cAsset_eddt, cKategori_time, cAsset_kategori, _
        cJumlah_depre, cCost_beginning, cCost_additional, cCost_deductional, _
        cCost_ending, cDepre_beginning, cDepre_additional, cDepre_deductional, _
        cDepre_ending, cNBV, cCreate_by, cCreate_dt, _
        cDepresiasi_id, cChannel_id, cDepresiasi_thn, _
        cDepresiasi_bln, cAsset_strukturunit, _
        cEdit_by, cEdit_dt, cAsset_tipedepre, cDepresiasi_remark, cDepresiasi_kali, _
        cAsset_golpajak, cDepartment})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
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
        Me.DgvDepresiasi.Dock = DockStyle.Fill
        Me.FormatDgvTrnDepresiasi(Me.DgvDepresiasi)
        Me.FormatDgvTrnDepresiasidetil(Me.DgvDepresiasiDetil)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding

        Return True
    End Function

#End Region


#Region " Dialoged Control "
#End Region

#Region " User Defined Function "

    Private Function UiViewDepresiasi_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        Me.tbl_viewDepresiasi_Temp.Clear()

        Me.BindingContext(Me.tbl_viewDepresiasi_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_viewDepresiasi_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function UiViewDepresiasi_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = String.Empty

        Me.tbl_viewDepresiasi.Clear()
        Try
            Me.DataFillViewDepresiasi(Me.tbl_viewDepresiasi, "as_transaksi_depresiasi_strukturunit", Me._CHANNEL, Me.cboSearchtahun.Value, Me.cboSearchbulan.Value, Me.ObjsearchDepartment.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function UiViewDepresiasi_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim depresiasi_id As String
        Me.objFormError.Clear()
        depresiasi_id = Me.DgvDepresiasi.Rows(rowIndex).Cells("depresiasi_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(depresiasi_id)

        Try
            dbConn.Open()
            Me.UiViewDepresiasi_OpenRowDetil(depresiasi_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": UiTrnBPBProcurement_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(depresiasi_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function UiViewDepresiasi_OpenRowDetil(ByVal depresiasi_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnDepresiasidetil_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("depresiasi_id ='{0}' AND asset_strukturunit = {1}", depresiasi_id, Me.ObjsearchDepartment.SelectedValue)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_viewDepresiasiDetil.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_viewDepresiasiDetil)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": UiMstwarna_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function UiViewDepresiasi_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvDepresiasi.CurrentCell = Me.DgvDepresiasi(1, 0)
            Me.UiViewDepresiasi_RefreshPosition()
        End If
    End Function
    Private Function UiViewDepresiasi_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvDepresiasi.CurrentCell.RowIndex > 0 Then
                Me.DgvDepresiasi.CurrentCell = Me.DgvDepresiasi(1, DgvDepresiasi.CurrentCell.RowIndex - 1)
                Me.UiViewDepresiasi_RefreshPosition()
            End If
        End If
    End Function
    Private Function UiViewDepresiasi_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvDepresiasi.CurrentCell.RowIndex < Me.DgvDepresiasi.Rows.Count - 1 Then
                Me.DgvDepresiasi.CurrentCell = Me.DgvDepresiasi(1, DgvDepresiasi.CurrentCell.RowIndex + 1)
                Me.UiViewDepresiasi_RefreshPosition()
            End If
        End If
    End Function
    Private Function UiViewDepresiasi_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvDepresiasi.CurrentCell = Me.DgvDepresiasi(1, Me.DgvDepresiasi.Rows.Count - 1)
            Me.UiViewDepresiasi_RefreshPosition()
        End If
    End Function
    Private Function UiViewDepresiasi_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then UiViewDepresiasi_OpenRow(Me.DgvDepresiasi.CurrentRow.Index)
    End Function

    Private Function UiViewDepresiasi_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

    Private Sub UiViewDepresiasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objParameters As Collection = New Collection


        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
        End If

        Me.InitLayoutUI()

        Me.DgvDepresiasi.DataSource = Me.tbl_viewDepresiasi
        Me.DgvDepresiasiDetil.DataSource = Me.tbl_viewDepresiasiDetil
        If Application.ProductName = "TransBrowser" Then
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            'Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
        End If

        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
        '    'Fill Combobox
        '    'dan fungsi2 startup lainnya....

        'End If


        Me.BindingStop()
        Me.BindingStart()

        Me.UiViewDepresiasi_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnSave.Visible = False
        Me.tbtnDel.Enabled = False
        Me.tbtnDel.Visible = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True
        Me.tbtnNew.Enabled = False
        Me.tbtnNew.Visible = False
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrint.Visible = False
        Me.tbtnPrintPreview.Enabled = False
        Me.tbtnPrintPreview.Visible = False

        Me.UiViewDepresiasi_LoadComboSearch()
        Me.ObjsearchDepartment.SelectedValue = 3130
        Me.ObjSearch_Category.SelectedValue = 0

    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                'Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                'Me.btnlock.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Ivory
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                Me.tbtnSave.Enabled = False
                'Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                'Me.btnlock.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Ivory

                If Me.DgvDepresiasi.CurrentRow IsNot Nothing Then
                    Me.UiViewDepresiasi_OpenRow(Me.DgvDepresiasi.CurrentRow.Index)
                Else
                    Me.UiViewDepresiasi_NewData()
                End If
        End Select
    End Sub

    Private Sub DgvBPBProcurement_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDepresiasi.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvDepresiasi.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub UiViewDepresiasi_LoadComboSearch()
        If Me._LOADCOMBOSEARCH = False Then
            '-----Mulai Bikin Tabel untuk combo Data Search-------------------------
            Me.ComboFill(Me.ObjsearchDepartment, "strukturunit_id", "strukturunit_name", Me.tbl_MstStruktur_unit, "ms_MstStrukturUnit_Select", " ")
            Me.tbl_MstStruktur_unit.DefaultView.Sort = "strukturunit_id"

            Me.ComboFill(Me.ObjSearch_Category, "kategoriasset_id", "kategoriasset_id", Me.tbl_mstKategoriAsset, "as_MstKategoriasset_Select", "  ")
            Me.tbl_mstKategoriAsset.DefaultView.Sort = "kategoriasset_id"

            Me._LOADCOMBOSEARCH = True
        End If

    End Sub

    Private Sub DgvDepresiasi_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvDepresiasi.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)
        Try
            If objrow.Cells("lock").Value = 0 Then
                objrow.DefaultCellStyle.BackColor = Color.White
            Else
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub obj_barcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_barcode.TextChanged
        Me.tbl_viewDepresiasiDetil.DefaultView.RowFilter = String.Format("asset_barcode like '%{0}%'", Me.obj_barcode.Text)
    End Sub

    Private Sub Btn_clearText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_clearText.Click
        Me.obj_barcode.Text = ""
    End Sub
End Class
