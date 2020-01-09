Public Class uiTrnDepresiasiX
    Private Const mUiName As String = "Depresiasi Asset"
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

    Public Shared databulan As Integer
    Public Shared datatahun As Integer

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_TrnDepresiasi As DataTable = clsDataset.CreateTblTrnDepresiasi()
    Private tbl_TrnDepresiasi_Temp As DataTable = clsDataset.CreateTblTrnDepresiasi()
    Private tbl_TrnDepresiasi_TempStart As DataTable = clsDataset.CreateTblTrnDepresiasi()
    Private tbl_TrnDepresiasidetil As DataTable = clsDataset.CreateTblTrnDepresiasidetil()
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_mstKategoriAsset As DataTable = clsDataset.CreateTblMstKategoriasset

    Private tbl_Print As DataTable = clsDataset.CreateTblViewReportDepre
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptDepresiasiDetil
    Private objPrintHeaderRekap As DataSource.clsRptDepresiasiRekapReport
    Private objDatalistDetil As ArrayList

    Private str_depresiasi_id As String
    Private kond As Boolean
    Private rekap As Boolean
    Private retCriteria As String
    Private locations As Boolean

    Private sptChannel_ID As String
    Private sptChannel_namereport As String
    Private sptChannel_address As String
    Private sptBulan As String
    Private sptTahun As Int16
    Private sptBulanRekap As Byte
    Private sptTahunRekap As Int16

    Private temps As String

    Private tbl_print_rekap As DataTable = New DataTable
    Private tbl_print_rekapMonth As DataTable = New DataTable
    ' TOOLSTRIP ADD ON
    Friend WithEvents btnlock As ToolStripButton = New ToolStripButton

#Region " Window Parameter "
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    ' TODO: Buat variabel untuk menampung parameter window 
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
        If Me.ftabMain.SelectedIndex = 1 Then
            Me.ftabMain.SelectedIndex = 0
        End If
        Me.Panel1.Visible = True
        Me.Panel1.Dock = DockStyle.Fill

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = False
        Me.tbtnQuery.Enabled = False
        Me.tbtnFirst.Enabled = False
        Me.tbtnNext.Enabled = False
        Me.tbtnPrev.Enabled = False
        Me.tbtnLast.Enabled = False
        Me.tbtnRefresh.Enabled = False
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = False
        'Me.uiTrnDepresiasi_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function
    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnDepresiasi_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.kondisi_print()
        If kond = True Then
            Me.uiTrnDepresiasi_Print()
            Me.Cursor = Cursors.Arrow
            Return MyBase.btnPrint_Click()
        End If
    End Function
    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.kondisi_print()
        If kond = True Then
            Me.uiTrnDepresiasi_PrintPreview()
            Me.Cursor = Cursors.Arrow
        End If
        Return MyBase.btnPrintPreview_Click()
    End Function
    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        'Me.uiTrnDepresiasi_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function
    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function
    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function
    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function
    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

#End Region

#Region " Additional Overrides "
    Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlock.Click
        Dim oDataFiller As New clsDataFiller(Me.ASSET_DSN)
        Dim criteria As String = String.Empty
        Dim tabell As New DataTable
        Dim lock_login As String
        Dim lock_dt As String

        If Me.obj_Lock.Checked = True Then
            criteria = String.Format("and depresiasi_id = '{0}'", Me.DgvTrnDepresiasi.Rows(Me.DgvTrnDepresiasi.CurrentRow.Index).Cells("depresiasi_id").Value)
            tabell.Rows.Clear()
            oDataFiller.DataFill(tabell, "as_TrnDepresiasi_Select", criteria, Me._CHANNEL, 0)
            lock_login = clsUtil.IsDbNull(tabell.Rows(0).Item("lock_login").ToString, String.Empty)
            lock_dt = clsUtil.IsDbNull(tabell.Rows(0).Item("lock_dt").ToString, String.Empty)
            MsgBox("Cannot Lock. Data has been Lock By " & lock_login & " At " & lock_dt)
            Exit Sub
        Else
            LockData()
        End If
    End Sub

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
        cDepresiasi_tgl.Visible = True
        cDepresiasi_tgl.ReadOnly = False

        cDepresiasi_thn.Name = "depresiasi_thn"
        cDepresiasi_thn.HeaderText = "Year"
        cDepresiasi_thn.DataPropertyName = "depresiasi_thn"
        cDepresiasi_thn.Width = 100
        cDepresiasi_thn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepresiasi_thn.Visible = True
        cDepresiasi_thn.ReadOnly = False

        cDepresiasi_bln.Name = "depresiasi_bln"
        cDepresiasi_bln.HeaderText = "Month"
        cDepresiasi_bln.DataPropertyName = "depresiasi_bln"
        cDepresiasi_bln.Width = 100
        cDepresiasi_bln.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepresiasi_bln.Visible = True
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
        cKategoriasset_time.Visible = True
        cKategoriasset_time.ReadOnly = False

        cKategoriasset_depresiasitime.Name = "kategoriasset_depresiasitime"
        cKategoriasset_depresiasitime.HeaderText = "kategoriasset_depresiasitime"
        cKategoriasset_depresiasitime.DataPropertyName = "kategoriasset_depresiasitime"
        cKategoriasset_depresiasitime.Width = 100
        cKategoriasset_depresiasitime.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriasset_depresiasitime.Visible = True
        cKategoriasset_depresiasitime.ReadOnly = False

        cKategoriasset_depresiasivalue.Name = "kategoriasset_depresiasivalue"
        cKategoriasset_depresiasivalue.HeaderText = "kategoriasset_depresiasivalue"
        cKategoriasset_depresiasivalue.DataPropertyName = "kategoriasset_depresiasivalue"
        cKategoriasset_depresiasivalue.Width = 100
        cKategoriasset_depresiasivalue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriasset_depresiasivalue.Visible = True
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
        cTotal_item_depre.Visible = True
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
        cNBV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
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
        cCost_ending, cDepre_beginning, cDepre_additional, cDepre_deductional, _
        cDepre_ending, cNBV, cChannel_id, cDepresiasi_id, cDepresiasi_tgl, cDepresiasi_thn, _
        cDepresiasi_bln, cKategoriasset_time, _
        cKategoriasset_depresiasitime, cKategoriasset_depresiasivalue, _
        cTotal_item, cLock_login, cLock_dt, cPost, cPost_login, _
        cPostdate, cCreate_by, cCreate_dt, cEdit_by, cEdit_dt, cUsed_by, cUsed_dt})

        ' DgvTrnDepresiasi Behaviours: 
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
        cAsset_kategori.Visible = False
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
    Private Function FormatDgvPointOfTimes(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cKategoriasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_Beginning As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_Additional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_Deductional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCost_Ending As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepreciation_Beginning As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepreciation_Additional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepreciation_Deductional As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepreciation_Ending As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cNBV As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cKategoriasset_id.Name = "kategoriasset_id"
        cKategoriasset_id.HeaderText = "Category"
        cKategoriasset_id.DataPropertyName = "kategoriasset_id"
        cKategoriasset_id.Width = 200
        cKategoriasset_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriasset_id.Visible = True
        cKategoriasset_id.ReadOnly = False

        cCost_Beginning.Name = "Cost_Beginning"
        cCost_Beginning.HeaderText = "Cost Beginning"
        cCost_Beginning.DataPropertyName = "Cost_Beginning"
        cCost_Beginning.Width = 150
        cCost_Beginning.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_Beginning.Visible = True
        cCost_Beginning.ReadOnly = False
        cCost_Beginning.DefaultCellStyle.Format = "###,##0.00"

        cCost_Additional.Name = "Cost_Additional"
        cCost_Additional.HeaderText = "Cost_Additional"
        cCost_Additional.DataPropertyName = "Cost_Additional"
        cCost_Additional.Width = 150
        cCost_Additional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_Additional.Visible = True
        cCost_Additional.ReadOnly = False

        cCost_Deductional.Name = "Cost_Deductional"
        cCost_Deductional.HeaderText = "Cost Deductional"
        cCost_Deductional.DataPropertyName = "Cost_Deductional"
        cCost_Deductional.Width = 150
        cCost_Deductional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_Deductional.Visible = True
        cCost_Deductional.ReadOnly = False
        cCost_Deductional.DefaultCellStyle.Format = "###,##0.00"

        cCost_Ending.Name = "Cost_Ending"
        cCost_Ending.HeaderText = "Cost Ending"
        cCost_Ending.DataPropertyName = "Cost_Ending"
        cCost_Ending.Width = 150
        cCost_Ending.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cCost_Ending.Visible = True
        cCost_Ending.ReadOnly = False
        cCost_Ending.DefaultCellStyle.Format = "###,##0.00"

        cDepreciation_Beginning.Name = "Depreciation_Beginning"
        cDepreciation_Beginning.HeaderText = "Depreciation Beginning"
        cDepreciation_Beginning.DataPropertyName = "Depreciation_Beginning"
        cDepreciation_Beginning.Width = 150
        cDepreciation_Beginning.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepreciation_Beginning.Visible = True
        cDepreciation_Beginning.ReadOnly = False
        cDepreciation_Beginning.DefaultCellStyle.Format = "###,##0.00"

        cDepreciation_Additional.Name = "Depreciation_Additional"
        cDepreciation_Additional.HeaderText = "Depreciation Additional"
        cDepreciation_Additional.DataPropertyName = "Depreciation_Additional"
        cDepreciation_Additional.Width = 150
        cDepreciation_Additional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepreciation_Additional.Visible = True
        cDepreciation_Additional.ReadOnly = False
        cDepreciation_Additional.DefaultCellStyle.Format = "###,##0.00"

        cDepreciation_Deductional.Name = "Depreciation_Deductional"
        cDepreciation_Deductional.HeaderText = "Depreciation Deductional"
        cDepreciation_Deductional.DataPropertyName = "Depreciation_Deductional"
        cDepreciation_Deductional.Width = 150
        cDepreciation_Deductional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepreciation_Deductional.Visible = True
        cDepreciation_Deductional.ReadOnly = False
        cDepreciation_Deductional.DefaultCellStyle.Format = "###,##0.00"

        cDepreciation_Ending.Name = "Depreciation_Ending"
        cDepreciation_Ending.HeaderText = "Depreciation Ending"
        cDepreciation_Ending.DataPropertyName = "Depreciation_Ending"
        cDepreciation_Ending.Width = 150
        cDepreciation_Ending.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cDepreciation_Ending.Visible = True
        cDepreciation_Ending.ReadOnly = False
        cDepreciation_Ending.DefaultCellStyle.Format = "###,##0.00"

        cNBV.Name = "NBV"
        cNBV.HeaderText = "NBV"
        cNBV.DataPropertyName = "NBV"
        cNBV.Width = 150
        cNBV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cNBV.Visible = True
        cNBV.ReadOnly = False
        cNBV.DefaultCellStyle.Format = "###,##0.00"

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cKategoriasset_id, cCost_Beginning, cCost_Additional, cCost_Deductional, _
        cCost_Ending, cDepreciation_Beginning, cDepreciation_Additional, _
        cDepreciation_Deductional, cDepreciation_Ending, cNBV, cChannel_id})

        objDgv.AutoGenerateColumns = False
        objDgv.ReadOnly = True
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function
    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.ftabMain.TabPages.Item(1).BackColor = Color.LightSteelBlue
        Me.ftabMain.TabPages.Item(2).BackColor = Color.LightSteelBlue
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvTrnDepresiasi.Dock = DockStyle.Fill

        Me.FormatDgvTrnDepresiasi(Me.DgvTrnDepresiasi)
        Me.FormatDgvTrnDepresiasidetil(Me.DgvTrnDepresiasidetil)
        Me.FormatDgvPointOfTimes(Me.DgvPointOfTimes)
        Me.FormatDgvTrnDepresiasi(Me.DgvPointOfTimes_Detil)

    End Function
    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Depresiasi_id.DataBindings.Clear()
        Me.obj_Depresiasi_tgl.DataBindings.Clear()
        Me.obj_Depresiasi_thn.DataBindings.Clear()
        Me.obj_Depresiasi_bln.DataBindings.Clear()
        Me.obj_Kategoriasset_id.DataBindings.Clear()
        Me.obj_Kategoriasset_time.DataBindings.Clear()
        Me.obj_Kategoriasset_depresiasitime.DataBindings.Clear()
        Me.obj_Kategoriasset_depresiasivalue.DataBindings.Clear()
        Me.obj_Total_item.DataBindings.Clear()
        Me.obj_Harga_item.DataBindings.Clear()
        'Me.obj_Besar_depresiasi.DataBindings.Clear()
        Me.obj_Lock.DataBindings.Clear()
        Me.obj_Postdate.DataBindings.Clear()
        Return True
    End Function
    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Channel_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi_Temp, "channel_id"))
        Me.obj_Depresiasi_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi, "depresiasi_id"))
        Me.obj_Depresiasi_tgl.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi_Temp, "depresiasi_tgl"))
        Me.obj_Depresiasi_thn.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi_Temp, "depresiasi_thn"))
        Me.obj_Depresiasi_bln.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi_Temp, "depresiasi_bln"))
        Me.obj_Kategoriasset_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi_Temp, "kategoriasset_id"))
        Me.obj_Kategoriasset_time.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi_Temp, "kategoriasset_time"))
        Me.obj_Kategoriasset_depresiasitime.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi_Temp, "kategoriasset_depresiasitime"))
        Me.obj_Kategoriasset_depresiasivalue.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi_Temp, "kategoriasset_depresiasivalue", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Total_item.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi_Temp, "total_item", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Harga_item.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi_Temp, "cost_ending", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        'Me.obj_Besar_depresiasi.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi_Temp, "besar_depresiasi", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Lock.DataBindings.Add(New Binding("Checked", Me.tbl_TrnDepresiasi, "lock"))
        Me.obj_Postdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnDepresiasi, "postdate"))
        Return True
    End Function

#End Region

#Region " Dialoged Control "
#End Region

#Region " User Defined Function "

    Private Function uiTrnDepresiasi_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnDepresiasi_Temp
        Me.tbl_TrnDepresiasi_Temp.Clear()

        ' TODO: Set Default Value for tbl_TrnDepresiasidetil
        Me.tbl_TrnDepresiasidetil.Clear()
        Me.tbl_TrnDepresiasidetil = clsDataset.CreateTblTrnDepresiasidetil()
        Me.tbl_TrnDepresiasidetil.Columns("depresiasi_id").DefaultValue = "AUTO"
        Me.DgvTrnDepresiasidetil.DataSource = Me.tbl_TrnDepresiasidetil

        Me.BindingContext(Me.tbl_TrnDepresiasi_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnDepresiasi_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function
    Private Function uiTrnDepresiasi_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""
        Dim txtSearchCriteria As String
        Dim tbl_rekapitulasi As DataTable = New DataTable
        Dim odatafiller As clsDataFiller = New clsDataFiller(Me.ASSET_DSN)
        ' TODO: Parse Criteria using clsProc.RefParser()

        ' criteria = " AND is_active = 0  "

        'untuk criteria bung
        If Me.chkSearchCategory.Checked Then
            txtSearchCriteria = "kategoriasset_id = '" & Me.cboSearchkategori.SelectedValue & "'"
            criteria = criteria & " AND " & " (" & txtSearchCriteria & ") "
        End If

        'depresiasi_thn
        If Me.chkSearchTahun.Checked Then
            criteria = criteria & " AND " & " ( depresiasi_thn = " & Me.cboSearchtahun.Value & ") "
        End If


        If Me.chkSearchBulan.Checked Then
            criteria = criteria & " AND " & " ( depresiasi_bln = " & Me.cboSearchbulan.Value & ") "
        End If

        criteria = criteria

        Me.tbl_TrnDepresiasi.Clear()

        Try
            odatafiller.DataFill(Me.tbl_TrnDepresiasi, "as_TrnDepresiasi_Select", criteria, Me._CHANNEL)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Try
        '    Me.DataFill(tbl_rekapitulasi, "as_trnDepresiasi_Select_Header", criteria, Me._CHANNEL)
        '    Me.DgvPointOfTimes.DataSource = tbl_rekapitulasi
        'Catch ex As Exception

        'End Try

    End Function
    Private Function uiTrnDepresiasi_Save() As Boolean
        'save data
        Dim tbl_TrnDepresiasi_Temp_Changes As DataTable
        Dim tbl_TrnDepresiasidetil_Changes As DataTable
        Dim success As Boolean
        Dim depresiasi_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(depresiasi_id)

        Me.BindingContext(Me.tbl_TrnDepresiasi_Temp).EndCurrentEdit()
        tbl_TrnDepresiasi_Temp_Changes = Me.tbl_TrnDepresiasi_Temp.GetChanges()

        Me.DgvTrnDepresiasidetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnDepresiasidetil).EndCurrentEdit()
        tbl_TrnDepresiasidetil_Changes = Me.tbl_TrnDepresiasidetil.GetChanges()

        If tbl_TrnDepresiasi_Temp_Changes IsNot Nothing Or tbl_TrnDepresiasidetil_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnDepresiasi_Temp.Rows(0).RowState
                depresiasi_id = tbl_TrnDepresiasi_Temp.Rows(0).Item("depresiasi_id")

                If tbl_TrnDepresiasi_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnDepresiasi_SaveMaster(depresiasi_id, tbl_TrnDepresiasi_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnDepresiasi_SaveMaster(tbl_TrnDepresiasi_Temp_Changes)")
                    Me.tbl_TrnDepresiasi_Temp.AcceptChanges()
                End If

                If tbl_TrnDepresiasidetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnDepresiasidetil.Rows.Count - 1
                        If Me.tbl_TrnDepresiasidetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnDepresiasidetil.Rows(i).Item("depresiasi_id") = depresiasi_id
                        End If
                    Next
                    success = Me.uiTrnDepresiasi_SaveDetil(depresiasi_id, tbl_TrnDepresiasidetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnDepresiasi_SaveDetil(tbl_TrnDepresiasidetil_Changes)")
                    Me.tbl_TrnDepresiasidetil.AcceptChanges()
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

        RaiseEvent FormAfterSave(depresiasi_id, result)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnDepresiasi_SaveMaster(ByRef depresiasi_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: transaksi_depresiasi
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnDepresiasi_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@depresiasi_thn", System.Data.OleDb.OleDbType.Integer, 4, "depresiasi_thn"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@depresiasi_bln", System.Data.OleDb.OleDbType.Integer, 4, "depresiasi_bln"))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            depresiasi_id = objTbl.Rows(0).Item("depresiasi_id")
            Me.tbl_TrnDepresiasi_Temp.Clear()
            Me.tbl_TrnDepresiasi_Temp.Merge(objTbl)

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
            Me.tbl_TrnDepresiasi.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnDepresiasi).Position
            Me.tbl_TrnDepresiasi.Rows.RemoveAt(curpos)
            Me.tbl_TrnDepresiasi.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnDepresiasi).Position = Me.BindingContext(Me.tbl_TrnDepresiasi).Count
        '
        Return True
    End Function
    Private Function uiTrnDepresiasi_SaveDetil(ByRef depresiasi_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)

        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnDepresiasidetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@depresiasi_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 80, "asset_barcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@depresiasi_total", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "nilai_depre", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@depresiasi_adjust", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "depresiasi_adjust", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@edit_by", System.Data.OleDb.OleDbType.VarWChar, 64))
        dbCmdUpdate.Parameters("@depresiasi_id").Value = depresiasi_id
        dbCmdUpdate.Parameters("@edit_by").Value = Me.UserName

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate

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
    Private Function uiTrnDepresiasi_Delete() As Boolean
        Dim res As String = ""
        Dim depresiasi_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(depresiasi_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnDepresiasi.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnDepresiasi_DeleteRow(Me.DgvTrnDepresiasi.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(depresiasi_id)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnDepresiasi_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim depresiasi_id As String
        Dim NewRowIndex As Integer

        depresiasi_id = Me.DgvTrnDepresiasi.Rows(rowIndex).Cells("depresiasi_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnDepresiasi_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@depresiasi_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@depresiasi_id").Value = depresiasi_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@depresiasi_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@depresiasi_tgl").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@depresiasi_thn", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@depresiasi_thn").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@depresiasi_bln", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@depresiasi_bln").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@kategoriasset_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_time", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@kategoriasset_time").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_depresiasitime", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@kategoriasset_depresiasitime").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_depresiasivalue", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@kategoriasset_depresiasivalue").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@total_item", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@total_item").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@harga_item", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@harga_item").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@besar_depresiasi", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@besar_depresiasi").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@lock", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@lock").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@postdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@postdate").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnDepresiasi.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnDepresiasi_OpenRow(NewRowIndex)
                    Me.tbl_TrnDepresiasi.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnDepresiasi.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnDepresiasi_OpenRow(NewRowIndex)
                    Me.tbl_TrnDepresiasi.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnDepresiasi.Rows.RemoveAt(rowIndex)
                    Me.uiTrnDepresiasi_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_TrnDepresiasi_Temp.Clear()
                Me.tbl_TrnDepresiasi.Rows.RemoveAt(rowIndex)

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
    Private Function uiTrnDepresiasi_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim depresiasi_id As String
        Dim channel_id As String

        depresiasi_id = Me.DgvTrnDepresiasi.Rows(rowIndex).Cells("depresiasi_id").Value
        channel_id = Me.DgvTrnDepresiasi.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(depresiasi_id)

        Try
            dbConn.Open()
            Me.uiTrnDepresiasi_OpenRowMaster(channel_id, depresiasi_id, dbConn)
            Me.uiTrnDepresiasi_OpenRowDetil(channel_id, depresiasi_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnDepresiasi_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(depresiasi_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function
    Private Function uiTrnDepresiasi_OpenRowMaster(ByVal channel_id As String, ByVal depresiasi_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnDepresiasi_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format(" and depresiasi_id='{0}'", depresiasi_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnDepresiasi_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnDepresiasi_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnDepresiasi_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnDepresiasi_OpenRowDetil(ByVal channel_id As String, ByVal depresiasi_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnDepresiasidetil_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("depresiasi_id='{0}'", depresiasi_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnDepresiasidetil.Clear()

        Me.tbl_TrnDepresiasidetil = clsDataset.CreateTblTrnDepresiasidetil()

        Try
            dbDA.Fill(Me.tbl_TrnDepresiasidetil)
            Me.DgvTrnDepresiasidetil.DataSource = Me.tbl_TrnDepresiasidetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnDepresiasi_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnDepresiasi_First() As Boolean
        'goto first record found
        If Me.DgvTrnDepresiasi.SelectedRows.Count <= 0 Then
            MsgBox("No Data")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnDepresiasi_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnDepresiasi.CurrentCell = Me.DgvTrnDepresiasi(1, 0)
            Me.uiTrnDepresiasi_RefreshPosition()
            'cek_Columns_depresiasiAdjust_readOnly()
        End If
    End Function
    Private Function uiTrnDepresiasi_Prev() As Boolean
        'goto previous record found
        If Me.DgvTrnDepresiasi.SelectedRows.Count <= 0 Then
            MsgBox("No Data")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnDepresiasi_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnDepresiasi.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnDepresiasi.CurrentCell = Me.DgvTrnDepresiasi(1, DgvTrnDepresiasi.CurrentCell.RowIndex - 1)
                Me.uiTrnDepresiasi_RefreshPosition()
                'cek_Columns_depresiasiAdjust_readOnly()
            End If
        End If
    End Function
    Private Function uiTrnDepresiasi_Next() As Boolean
        'goto next record found
        If Me.DgvTrnDepresiasi.SelectedRows.Count <= 0 Then
            MsgBox("No Data")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnDepresiasi_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnDepresiasi.CurrentCell.RowIndex < Me.DgvTrnDepresiasi.Rows.Count - 1 Then
                Me.DgvTrnDepresiasi.CurrentCell = Me.DgvTrnDepresiasi(1, DgvTrnDepresiasi.CurrentCell.RowIndex + 1)
                Me.uiTrnDepresiasi_RefreshPosition()
                'cek_Columns_depresiasiAdjust_readOnly()
            End If
        End If
    End Function
    Private Function uiTrnDepresiasi_Last() As Boolean
        'goto last record found
        If Me.DgvTrnDepresiasi.SelectedRows.Count <= 0 Then
            MsgBox("No Data")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnDepresiasi_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnDepresiasi.CurrentCell = Me.DgvTrnDepresiasi(1, Me.DgvTrnDepresiasi.Rows.Count - 1)
            Me.uiTrnDepresiasi_RefreshPosition()
            'cek_Columns_depresiasiAdjust_readOnly()
        End If
    End Function
    Private Function uiTrnDepresiasi_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnDepresiasi_OpenRow(Me.DgvTrnDepresiasi.CurrentRow.Index)
    End Function
    Private Function uiTrnDepresiasi_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnDepresiasi_Temp_Changes As DataTable
        Dim tbl_TrnDepresiasidetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim i As Integer = 0
        Dim depresiasi_id As Object = New Object
        Dim move As Boolean = False
        Dim isTempChanged As Boolean = False

        If Me.DgvTrnDepresiasi.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnDepresiasi_Temp).EndCurrentEdit()
            tbl_TrnDepresiasi_Temp_Changes = Me.tbl_TrnDepresiasi_Temp.GetChanges()

            For i = 0 To Me.tbl_TrnDepresiasi_TempStart.Columns.Count - 3
                If clsUtil.IsDbNull(Me.tbl_TrnDepresiasi_TempStart.Rows(0).Item(i), Me.tbl_TrnDepresiasi_TempStart.Columns(i).DefaultValue) <> clsUtil.IsDbNull(Me.tbl_TrnDepresiasi_Temp.Rows(0).Item(i), Me.tbl_TrnDepresiasi_Temp.Columns(i).DefaultValue) Then
                    isTempChanged = True
                    Exit For
                End If
            Next

            Me.DgvTrnDepresiasidetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnDepresiasidetil).EndCurrentEdit()
            tbl_TrnDepresiasidetil_Changes = Me.tbl_TrnDepresiasidetil.GetChanges()

            If isTempChanged Or tbl_TrnDepresiasidetil_Changes IsNot Nothing Then
                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes
                        RaiseEvent FormBeforeSave(depresiasi_id)
                        Me.uiTrnDepresiasi_Save()
                        move = True
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
    Private Function uiTrnDepresiasi_FormError() As Boolean
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

#Region " Individual Defined Function "
    Private Sub saveawal()
        Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            Dim dbCmdInsert As OleDb.OleDbCommand
            dbConn.Open()
            dbCmdInsert = New OleDb.OleDbCommand("as_TrnDepresiasi_Insert", dbConn)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 10).Value = Me._CHANNEL
            dbCmdInsert.Parameters.Add("@depresiasi_thn", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.obj_newThn.Value
            dbCmdInsert.Parameters.Add("@depresiasi_bln", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.obj_newBln.Value
            dbCmdInsert.Parameters.Add("@login", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName


            dbCmdInsert.ExecuteNonQuery()
            dbCmdInsert.Dispose()
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            'MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try




        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub LockData()
        'validasi doeloe

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_Locktransaksi_depresiasi", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@depresiasi_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnDepresiasi.Item("depresiasi_id", DgvTrnDepresiasi.CurrentRow.Index).Value
            oCm.Parameters.Add("@lock_login", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            oCm.Parameters.Add("@lock_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now

            oCm.ExecuteNonQuery()
            oCm.Dispose()
            Me.obj_Lock.Checked = True
            Me.DgvTrnDepresiasi.Item("lock", DgvTrnDepresiasi.CurrentRow.Index).Value = 1
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

#End Region

    Private Sub uiTrnDepresiasi_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Me.tbl_TrnDepresiasidetil.RejectChanges()
        Me.tbl_TrnDepresiasi_TempStart.Clear()
        Me.tbl_TrnDepresiasi_TempStart = Me.tbl_TrnDepresiasi_Temp.Copy
    End Sub
    Private Sub uiTrnDepresiasi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If databulan <> 0 And datatahun <> 0 Then
            saveawal()
            chkSearchBulan.Checked = True
            chkSearchTahun.Checked = True
            cboSearchtahun.Value = datatahun
            cboSearchbulan.Value = databulan
            uiTrnDepresiasi_Retrieve()
            databulan = 0
            datatahun = 0
            Exit Sub
        End If
    End Sub

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            '========================= add PTS 20140806 =====================
            Dim odatafiller As clsDataFiller = New clsDataFiller(Me.ASSET_DSN)
            '================================================================

            Me.DgvTrnDepresiasi.DataSource = Me.tbl_TrnDepresiasi

            odatafiller.ComboFill(Me.cboSearchkategori, "kategoriasset_id", "kategoriasset_id", Me.tbl_mstKategoriAsset, "as_MstKategoriasset_Select", "  ")
            Me.tbl_mstKategoriAsset.DefaultView.Sort = "kategoriasset_id"

            Me.InitLayoutUI()
            Me.BindingStop()
            Me.BindingStart()

            Me.uiTrnDepresiasi_NewData()

            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = True
            Me.tbtnQuery.Enabled = True

            Me.btnlock.ToolTipText = "Lock Transaction"
            Me.ToolStrip1.Items.Add(Me.btnlock)
            Me.btnlock.Image = ImageList1.Images(0)

            databulan = 0
            datatahun = 0
        End If

    End Sub

    Private Sub uiTrnDepresiasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub
    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(1).BackColor = Color.LightSteelBlue
                Me.ftabMain.TabPages.Item(2).BackColor = Color.LightSteelBlue
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.btnlock.Enabled = True

            Case 1
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(2).BackColor = Color.LightSteelBlue
                Me.ftabMain.TabPages.Item(0).BackColor = Color.LightSteelBlue
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White
                Me.cmb_search_detil.SelectedItem = "Barcode"
                Me.obj_barcode.Text = ""

                If Me.DgvTrnDepresiasi.CurrentRow IsNot Nothing Then
                    Me.uiTrnDepresiasi_OpenRow(Me.DgvTrnDepresiasi.CurrentRow.Index)
                Else
                    ftabMain.SelectedIndex = 0
                End If
                Me.btnlock.Enabled = True
                'cek_Columns_depresiasiAdjust_readOnly()
                'Me.hitung_NBV()

            Case 2

                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(1).BackColor = Color.LightSteelBlue
                Me.ftabMain.TabPages.Item(2).BackColor = Color.White
                Me.ftabMain.TabPages.Item(0).BackColor = Color.LightSteelBlue
                Me.btnlock.Enabled = False
                Me.Load_Rekapitulasi()



        End Select
    End Sub
    Public Sub createnewdpresiasi()
        saveawal()
    End Sub
    Private Sub DgvTrnDepresiasidetil_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        With DgvTrnDepresiasidetil
            Select Case e.ColumnIndex
                Case .Columns("depresiasi_adjust").Index
                    .Rows(e.RowIndex).Cells("NBV").Value = (.Rows(e.RowIndex).Cells("asset_hargaakhir").Value) - (.Rows(e.RowIndex).Cells("nilai_depre").Value) - (.Rows(e.RowIndex).Cells("depresiasi_adjust").Value) '* (.Rows(e.RowIndex).Cells("jumlah").Value)) - (.Rows(e.RowIndex).Cells("depresiasi_adjust").Value)
            End Select

        End With

    End Sub
    Private Function GenerateDataHeader(ByVal temp As String) As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        tbl_Print.Clear()
        DataFill(tbl_Print, "as_TrnDepresiasidetil_Select", retCriteria)

        If Me.tbl_Print.Rows.Count <= 0 Then
            MsgBox("No data to print")
            temps = "Kosong"
        Else
            temps = "Ada"
        End If

        'tbl_PrintDetil.Clear()
        For i = 0 To Me.tbl_Print.Rows.Count - 1
            objPrintHeader = New DataSource.clsRptDepresiasiDetil(Me.DSN)
            'DataFill(tbl_Print, "as_TrnDepresiasiReport_Select", "depresiasi_id = '" & DgvTrnDepresiasi.Item("depresiasi_id", DgvTrnDepresiasi.SelectedCells.Item(0).RowIndex).Value & "'")
            With objPrintHeader
                .depresiasi_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depresiasi_id").ToString, String.Empty)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_barcode").ToString, String.Empty)
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id").ToString, String.Empty)
                .depresiasi_thn = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depresiasi_thn"), 0)
                .depresiasi_bln = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depresiasi_bln"), 0)
                .asset_strukturunit = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_strukturunit"), 0)
                .asset_kategori = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_kategori").ToString, String.Empty)
                .kategori_time = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("kategori_time"), 0)
                .Jumlah_depre = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Jumlah_depre"), 0)
                .cost_beginning = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("cost_beginning"), 0)
                .cost_additional = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("cost_additional"), 0)
                .cost_deductional = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("cost_deductional"), 0)
                .cost_ending = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("cost_ending"), 0)
                .depre_beginning = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depre_beginning"), 0)
                .depre_additional = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depre_additional"), 0)
                .depre_deductional = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depre_deductional"), 0)
                .depre_ending = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depre_ending"), 0)
                .NBV = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("NBV"), 0)
                .asset_stdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_stdt"), Now())
                .asset_eddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_eddt"), Now())
                .create_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("create_by").ToString, String.Empty)
                .create_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("create_dt"), Now())
                .edit_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("edit_by").ToString, String.Empty)
                .edit_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("edit_dt"), Now())
                .asset_tipedepre = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_tipedepre").ToString, String.Empty)
                .depresiasi_remark = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depresiasi_remark").ToString, String.Empty)
                .depresiasi_kali = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depresiasi_kali"), 0)
                .asset_golpajak = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_golpajak").ToString, String.Empty)
                .tipeitem_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("tipeitem_id").ToString, String.Empty)
                .brand_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("brand_id").ToString, String.Empty)
                .asset_serial = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_serial").ToString, String.Empty)
                .asset_deskripsi = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_deskripsi").ToString, String.Empty)
                .department = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("department").ToString, String.Empty)
                .location = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("location").ToString, String.Empty)
                Me.sptChannel_ID = .channel_id
                Me.sptChannel_namereport = .channel_namereport
                Me.sptChannel_address = .channel_address
                Me.sptBulan = .bulan_string
                Me.sptTahun = .depresiasi_thn
                'DataFill(tbl_PrintDetil, "", " = '" & . & "'")
                'GenerateDataDetail()
            End With
            objDatalistHeader.Add(objPrintHeader)
        Next
        Return objDatalistHeader
    End Function

    Private Function GenerateDataHeaderRekap() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        tbl_print_rekap.Clear()
        DataFill(tbl_print_rekap, "as_trnDepresiasi_Select_Header", retCriteria, Me._CHANNEL)

        For i = 0 To Me.tbl_print_rekap.Rows.Count - 1
            objPrintHeaderRekap = New DataSource.clsRptDepresiasiRekapReport(Me.DSN)
            With objPrintHeaderRekap
                .kategoriasset_id = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("kategoriasset_id").ToString, String.Empty)
                .Cost = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Cost"), 0)
                .Additional = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Additional"), 0)
                .Total = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Total"), 0)
                .Depre_Value = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Depre_Value"), 0)
                .Adjusment = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Adjusment"), 0)
                .Accumulation_Depresiasi = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Accumulation_Depresiasi"), 0)
                .NBV = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("NBV"), 0)
                .channel_id = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("channel_id").ToString, String.Empty)

                'DataFill(tbl_PrintDetil, "", " = '" & . & "'")
                'GenerateDataDetail()
            End With
            objDatalistHeader.Add(objPrintHeaderRekap)
        Next
        Return objDatalistHeader
    End Function
    Private Function GenerateDataHeaderRekapMonth() As ArrayList
        Dim objPrintHeader As DataSource.clsRptDepresiasi
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        retCriteria = " AND " & retCriteria

        tbl_print_rekapMonth.Clear()
        DataFill(tbl_print_rekapMonth, "as_trnDepresiasi_Select", retCriteria, Me._CHANNEL)

        For i = 0 To Me.tbl_print_rekapMonth.Rows.Count - 1
            'GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptDepresiasi(Me.DSN)
            With objPrintHeader
                .channel_id = Me._CHANNEL
                .depresiasi_id = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depresiasi_id").ToString, String.Empty)
                .depresiasi_tgl = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depresiasi_tgl"), Now())
                .depresiasi_thn = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depresiasi_thn"), 0)
                .depresiasi_bln = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depresiasi_bln"), 0)
                .kategoriasset_id = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("kategoriasset_id").ToString, String.Empty)
                .kategoriasset_time = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("kategoriasset_time"), 0)
                .kategoriasset_depresiasitime = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("kategoriasset_depresiasitime").ToString, String.Empty)
                .kategoriasset_depresiasivalue = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("kategoriasset_depresiasivalue"), 0)
                .total_item = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("total_item"), 0)
                .total_item_depre = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("total_item_depre"), 0)
                .cost_beginning = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("cost_beginning"), 0)
                .cost_additional = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("cost_additional"), 0)
                .cost_deductional = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("cost_deductional"), 0)
                .cost_ending = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("cost_ending"), 0)
                .depre_beginning = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depre_beginning"), 0)
                .depre_additional = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depre_additional"), 0)
                .depre_deductional = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depre_deductional"), 0)
                .depre_ending = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depre_ending"), 0)
                .lock = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("lock"), 0)
                .lock_login = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("lock_login").ToString, String.Empty)
                .lock_dt = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("lock_dt"), Now())
                .post = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("post"), 0)
                .post_login = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("post_login").ToString, String.Empty)
                .postdate = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("postdate"), Now())
                .NBV = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("NBV"), 0)
                .create_by = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("create_by").ToString, String.Empty)
                .create_dt = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("create_dt"), Now())
                .edit_by = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("edit_by").ToString, String.Empty)
                .edit_dt = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("edit_dt"), Now())
                .used_by = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("used_by").ToString, String.Empty)
                .used_dt = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("used_dt"), Now())
            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function
    ' Private Sub GenerateDataDetail()
    'Dim objDetil As DataSource.
    '     Dim i As Integer

    '     objDatalistDetil = New ArrayList()
    '     For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
    'objDetil = New DataSource.(Me.DSN)
    '         With objDetil
    '         End With
    '         objDatalistDetil.Add(objDetil)
    '     Next
    ' End Sub
    'Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
    '    e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("E_ASSET_DataSource_", objDatalistDetil))
    'End Sub
    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        Dim stream As System.IO.Stream
        Dim deviceInfo As String = _
        "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>11.69in</PageWidth>" & _
        "  <PageHeight>8.5in</PageHeight>" & _
        "  <MarginTop>0.4in</MarginTop>" & _
        "  <MarginLeft>0.2in</MarginLeft>" & _
        "  <MarginRight>0.2in</MarginRight>" & _
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
        'Dim printerName As String = "Microsoft Office Document Image Writer"
        Dim printerName As String = printSet.PrinterName

        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If
        printDoc.PrinterSettings.PrinterName = printerName
        printDoc.DefaultPageSettings.Landscape = True
        If Not printDoc.PrinterSettings.IsValid Then
            Dim msg As String = String.Format("Can't find printer ""{0}"".", printerName)
            Console.WriteLine(msg)
            Return
        End If
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()
    End Sub
    Private Function uiTrnDepresiasi_Print() As Boolean
        If Me.DgvTrnDepresiasi.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)

        If retCriteria = String.Empty Then
            objDatalistHeader = Me.GenerateDataHeaderRekap
            Me.sptBulan = Me.sptBulanRekap
            Me.sptTahun = Me.sptTahunRekap
        Else
            If Me.rekap = True Then
                objDatalistHeader = Me.GenerateDataHeaderRekapMonth
            Else
                objDatalistHeader = Me.GenerateDataHeader(temps)
                If temps = "Kosong" Then
                    Exit Function
                End If
            End If
        End If
        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.sptChannel_ID)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_namereport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptBulan As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("bulan", Me.sptBulan)
        Dim parRptTahun As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tahun", Me.sptTahun)

        If retCriteria = String.Empty Then
            objRdsH.Name = "ASSET_DataSource_clsRptDepresiasiRekapReport"
            objRdsH.Value = objDatalistHeader
            objReportH.ReportEmbeddedResource = "ASSET.RptDepreRekap.rdlc"
            objReportH.DataSources.Add(objRdsH)
            objReportH.EnableExternalImages = True

            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptBulan, parRptTahun})
        Else
            If Me.rekap = True Then
                objRdsH.Name = "ASSET_DataSource_clsRptDepresiasi"
                objRdsH.Value = objDatalistHeader
                objReportH.ReportEmbeddedResource = "ASSET.RptDepreRekapMonth.rdlc"
                objReportH.DataSources.Add(objRdsH)
                objReportH.EnableExternalImages = True
                objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})
            Else
                If Me.locations = True Then
                    'objDatalistHeader = Me.GenerateDataHeader()
                    objRdsH.Name = "ASSET_DataSource_clsRptDepresiasiDetil"
                    objRdsH.Value = objDatalistHeader
                    objReportH.ReportEmbeddedResource = "ASSET.RptDepresiasi_Location.rdlc"
                    objReportH.DataSources.Add(objRdsH)
                    objReportH.EnableExternalImages = True
                    objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptBulan, parRptTahun})
                Else
                    objRdsH.Name = "ASSET_DataSource_clsRptDepresiasiDetil"
                    objRdsH.Value = objDatalistHeader
                    objReportH.ReportEmbeddedResource = "ASSET.RptDepre.rdlc"
                    objReportH.DataSources.Add(objRdsH)
                    objReportH.EnableExternalImages = True
                    objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptBulan, parRptTahun})
                End If
            End If
        End If

        'AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
        Export(objReportH)

        m_currentPageIndex = 0
        Print()
    End Function
    Private Function uiTrnDepresiasi_PrintPreview() As Boolean
        Dim frmPrint As dlgRptDepre = New dlgRptDepre(Me.DSN, Me.SptServer, Me._CHANNEL, Me.UserName, Me.retCriteria, Me.sptBulanRekap, Me.sptTahunRekap, Me.rekap, Me.locations)
        Dim criteria As String = String.Empty
        criteria = retCriteria

        frmPrint.ShowInTaskbar = False
        frmPrint.StartPosition = FormStartPosition.CenterParent
        frmPrint.SetIDCriteria(criteria)
        frmPrint.ShowDialog(Me)
    End Function
    Private Sub kondisi_print()
        Dim dlg As dlgKondisiDepresiasi = New dlgKondisiDepresiasi(Me.DSN)
        retCriteria = dlg.OpenDialog(Me)
        If retCriteria Is Nothing Then
            kond = False
        Else
            If dlg.chkPrint_RekapitulasiMonth.Checked = True Then
                rekap = True
            Else
                rekap = False
            End If

            If dlg.chkSearchLocation.Checked = True Then
                locations = True
            Else
                locations = False
            End If
            kond = True
            sptBulanRekap = dlg.cboSearchbulan.Value
            sptTahunRekap = dlg.cboSearchtahun.Value
        End If
    End Sub
    Private Sub hitung_NBV()
        'Dim i As Integer
        'For i = 0 To Me.DgvTrnDepresiasidetil.Rows.Count - 1
        '    Me.DgvTrnDepresiasidetil.Rows(i).Cells("NBV").Value = _
        '        Me.DgvTrnDepresiasidetil.Rows(i).Cells("asset_hargaakhir").Value - _
        '        Me.DgvTrnDepresiasidetil.Rows(i).Cells("nilai_depre").Value - _
        '        Me.DgvTrnDepresiasidetil.Rows(i).Cells("depresiasi_adjust").Value
        'Next
    End Sub

    'Private Sub cek_Columns_depresiasiAdjust_readOnly()

    '    If Me.DgvTrnDepresiasi.CurrentRow.Cells("lock").Value = 1 Then
    '        Me.DgvTrnDepresiasidetil.Columns("depresiasi_adjust").ReadOnly = True
    '    Else
    '        Me.DgvTrnDepresiasidetil.Columns("depresiasi_adjust").ReadOnly = False
    '    End If

    'End Sub
    Private Sub DgvTrnDepresiasi_CellDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnDepresiasi.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnDepresiasi.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub
    Private Sub Load_Rekapitulasi()
        Dim criteria As String = String.Empty
        Dim tbl_Rekapitulasi As DataTable = New DataTable
        '========================= add PTS 20140806 =====================
        Dim odatafiller As clsDataFiller = New clsDataFiller(Me.ASSET_DSN)
        '================================================================
        tbl_Rekapitulasi.Clear()
        Try
            odatafiller.DataFill(tbl_Rekapitulasi, "as_trnDepresiasi_Select_Header", criteria, Me._CHANNEL)
            Me.DgvPointOfTimes.DataSource = tbl_Rekapitulasi
            Me.Load_Rekapitulasi_Detil()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DgvPointOfTimes_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPointOfTimes.CellClick
        Me.Load_Rekapitulasi_Detil()
    End Sub
    Private Sub Load_Rekapitulasi_Detil()
        Dim criteria As String = String.Empty
        Dim tbl_rekapitulasi_detil As DataTable = New DataTable
        '========================= add PTS 20140806 =====================
        Dim odatafiller As clsDataFiller = New clsDataFiller(Me.ASSET_DSN)
        '================================================================
        criteria = String.Format("AND kategoriasset_id = '{0}'", Me.DgvPointOfTimes.Rows(Me.DgvPointOfTimes.CurrentRow.Index).Cells("kategoriasset_id").Value)

        tbl_rekapitulasi_detil.Clear()
        Try
            odatafiller.DataFill(tbl_rekapitulasi_detil, "as_trnDepresiasi_Select", criteria, Me._CHANNEL)
            Me.DgvPointOfTimes_Detil.DataSource = tbl_rekapitulasi_detil
            FormatDgvTrnDepresiasi(Me.DgvPointOfTimes_Detil)

            Me.ftabDataDetil_Detil.Text = "Detil " & Me.DgvPointOfTimes.Rows(Me.DgvPointOfTimes.CurrentRow.Index).Cells("kategoriasset_id").Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DgvPointOfTimes_Detil_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvPointOfTimes_Detil.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)
        Try
            If objrow.Cells("lock").Value = 0 Then
                objrow.DefaultCellStyle.BackColor = Color.White
            Else
                objrow.DefaultCellStyle.BackColor = Color.Bisque
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DgvPointOfTimes_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvPointOfTimes.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)
        Try
            If e.RowIndex Mod 2 = 0 Then
                objrow.DefaultCellStyle.BackColor = Color.White
            Else
                objrow.DefaultCellStyle.BackColor = Color.Gainsboro
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DgvTrnDepresiasi_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnDepresiasi.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)
        Try
            If objrow.Cells("lock").Value = 0 Then
                objrow.DefaultCellStyle.BackColor = Color.White
            Else
                objrow.DefaultCellStyle.BackColor = Color.Bisque
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim x As Boolean

        Dim criteria_before As String = String.Empty
        Dim criteria_now As String = String.Empty
        Dim criteria_mstAsset As String = String.Empty
        Dim tbl_temps_before As DataTable = New DataTable
        Dim tbl_temps_now As DataTable = New DataTable
        Dim tbl_temps_mstAsset As DataTable = New DataTable
        Dim bln_temps As Integer
        Dim thn_temps As Integer
        Dim i As Integer
        Dim total_rows_before As Integer
        Dim total_rows_now As Integer
        '========================= add PTS 20140806 =====================
        Dim odatafiller As clsDataFiller = New clsDataFiller(Me.ASSET_DSN)
        '================================================================
        If Me.obj_newBln.Value = 1 Then
            bln_temps = 12
            thn_temps = Me.obj_newThn.Value - 1
        Else
            bln_temps = Me.obj_newBln.Value - 1
            thn_temps = Me.obj_newThn.Value
        End If

        criteria_before = String.Format(" AND depresiasi_bln = {0} AND depresiasi_thn = {1} AND lock = 1", bln_temps, thn_temps)
        criteria_now = String.Format(" AND depresiasi_bln = {0} AND depresiasi_thn = {1}", Me.obj_newBln.Value, Me.obj_newThn.Value)
        criteria_mstAsset = " asset_depresiasi < 0"
        tbl_temps_before.Clear()
        tbl_temps_now.Clear()
        Try
            odatafiller.DataFill(tbl_temps_before, "as_TrnDepresiasi_Select", criteria_before, Me._CHANNEL)
            odatafiller.DataFill(tbl_temps_now, "as_TrnDepresiasi_Select", criteria_now, Me._CHANNEL)
            odatafiller.DataFill(tbl_temps_mstAsset, "as_MstAssetFinance_Select", criteria_mstAsset, Me._CHANNEL)
            total_rows_before = tbl_temps_before.Rows.Count
            total_rows_now = tbl_temps_now.Rows.Count

            If total_rows_now <> 0 Then
                MsgBox("Can't build new depresiasi. Depresiasi month " & Me.obj_newBln.Value & " year " & Me.obj_newThn.Value & " has been build.")
                Exit Try
            ElseIf total_rows_before = 0 Then
                MsgBox("Can't build new depresiasi. Please contact your administrator")
                Exit Try
            ElseIf tbl_temps_mstAsset.Rows.Count <> 0 Then
                MsgBox("Can't build new depresiasi. Check approval accounting in transaction received of goods")
                Exit Try
            Else
                For i = 0 To total_rows_before - 1
                    If tbl_temps_before.Rows(i).Item("lock") = 0 Then
                        MsgBox("Can't build new depresiasi. Please contact your administrator")
                        Exit Try
                    End If
                Next
                Me.saveawal()
                Me.cboSearchtahun.Value = Me.obj_newThn.Value
                Me.cboSearchbulan.Value = Me.obj_newBln.Value
                Me.chkSearchTahun.Checked = True
                Me.chkSearchBulan.Checked = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

        Me.tbtnFirst.Enabled = True
        Me.tbtnNext.Enabled = True
        Me.tbtnPrev.Enabled = True
        Me.tbtnLast.Enabled = True
        Me.tbtnRefresh.Enabled = True
        Me.tbtnPrint.Enabled = True
        Me.tbtnPrintPreview.Enabled = True

        'saveawal()
        Me.Panel1.Visible = False
        Me.DgvTrnDepresiasi.Focus()
        x = Me.uiTrnDepresiasi_Retrieve()

        ' Me.uiTrnDepresiasi_Retrieve()

    End Sub

    Private Sub DgvTrnDepresiasidetil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnDepresiasidetil.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim click As DataGridView.HitTestInfo = Me.DgvTrnDepresiasidetil.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnDepresiasidetil.CurrentCell = Me.DgvTrnDepresiasidetil.Rows(click.RowIndex).Cells(click.ColumnIndex)
            End If
        End If
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        Dim depresiasi_id As String = String.Empty
        Dim asset_barcode As String = String.Empty
        Dim deskripsi As String = String.Empty
        Dim tahun As Integer
        Dim bulan As Integer

        Dim status As New DataTable

        If Me.DgvTrnDepresiasidetil.Rows.Count <= 0 Then
            Exit Sub
        End If

        depresiasi_id = Me.DgvTrnDepresiasi.CurrentRow.Cells("depresiasi_id").Value
        asset_barcode = Me.DgvTrnDepresiasidetil.CurrentRow.Cells("asset_barcode").Value
        deskripsi = Me.DgvTrnDepresiasidetil.CurrentRow.Cells("asset_deskripsi").Value
        tahun = Me.DgvTrnDepresiasi.CurrentRow.Cells("depresiasi_thn").Value
        bulan = Me.DgvTrnDepresiasi.CurrentRow.Cells("depresiasi_bln").Value

        Dim dlg As New dlgUpdateDepresiasiDetil(Me.DSN, Me._CHANNEL, depresiasi_id, asset_barcode, deskripsi, Me.UserName, tahun, bulan)

        status = dlg.OpenDialog(Me)
        'Me.uiTrnDepresiasi_Retrieve()
        Me.uiTrnDepresiasi_OpenRow(Me.DgvTrnDepresiasi.CurrentRow.Index)
        'If status Is Nothing Then
        '    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        '    '    Me.uiTrnIncomingAsset_OpenRowDetil(_CHANNEL, Me.obj_Incasset_id.Text, dbConn)
        'End If
    End Sub

    Private Sub obj_barcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_barcode.TextChanged
        If cmb_search_detil.SelectedItem = "Barcode" Then
            Me.tbl_TrnDepresiasidetil.DefaultView.RowFilter = String.Format("asset_barcode like  '%{0}%'", Me.obj_barcode.Text)
        Else
            Me.tbl_TrnDepresiasidetil.DefaultView.RowFilter = String.Format("asset_deskripsi like '%{0}%'", Me.obj_barcode.Text)
        End If
    End Sub

    Private Sub Btn_clearText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_clearText.Click
        Me.obj_barcode.Text = ""
    End Sub

    Private Sub cmb_search_detil_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_search_detil.SelectionChangeCommitted
        Me.obj_barcode.Text = ""
    End Sub

End Class