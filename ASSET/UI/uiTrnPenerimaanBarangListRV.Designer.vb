<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnPenerimaanBarangListRV
    Inherits uiBase2

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.ftabMain = New DevExpress.XtraTab.XtraTabControl()
        Me.ftabMain_List = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRVRakitan = New DevExpress.XtraGrid.GridControl()
        Me.GVRVRakitan = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTerimabarang_appacc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrder_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarangBudget_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarangRekanan_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmployee_id_owner = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarangStrukturunit_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_qtyitem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_qtyrealization = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrder_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_statusrealization = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_location = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_notes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_nosuratjalan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarangChannel_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_isdisabled = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_createby = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_createdt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_modifiedby = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_modifieddt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_appuser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_appuser_by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_appuser_dt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_appspv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_appspv_by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_appspv_dt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_appacc_by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_appacc_dt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_foreign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarangCurrency_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_foreignrate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_idrreal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_pph = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_ppn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_disc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarang_cetakbpb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTerimabarangRekanan_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmployee_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PnlDfSearch = New DevExpress.XtraEditors.PanelControl()
        Me.lueSrchDept = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbRecord = New DevExpress.XtraEditors.LabelControl()
        Me.seRecord = New DevExpress.XtraEditors.SpinEdit()
        Me.txtSrchRvID = New DevExpress.XtraEditors.TextEdit()
        Me.chkSrchRvID = New DevExpress.XtraEditors.CheckEdit()
        Me.btnRekanan = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSrchRekananID = New DevExpress.XtraEditors.TextEdit()
        Me.chkSrchDept = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSrchRekanan = New DevExpress.XtraEditors.CheckEdit()
        Me.lueSrchChannelID = New DevExpress.XtraEditors.LookUpEdit()
        Me.chkSrchChannel = New DevExpress.XtraEditors.CheckEdit()
        Me.ftabMain_Data = New DevExpress.XtraTab.XtraTabPage()
        Me.ftabDataDetil = New DevExpress.XtraTab.XtraTabControl()
        Me.ftabDataDetil_Detil = New DevExpress.XtraTab.XtraTabPage()
        Me.GCRVDetil = New DevExpress.XtraGrid.GridControl()
        Me.MenuRVRakitan = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddParentManual = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddParentByRV = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddChild = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVRVDetil = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colLine = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPrint = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNotPrinted = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAssetType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryAssetTipe = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colAssetCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryAssetCategory = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colCatDepre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryCatDepre = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCategory = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTipe = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colBrand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryBrandId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSerialNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBarcodeType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUnit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIsParent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRefID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRefDetil_Line = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAmountIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotalAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotalAmountIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryAssetType = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.ftabDataDetil_Jurnal = New DevExpress.XtraTab.XtraTabPage()
        Me.ftabJurnal = New DevExpress.XtraTab.XtraTabControl()
        Me.ftabJurnalDebit = New DevExpress.XtraTab.XtraTabPage()
        Me.GCJurnalDebit = New DevExpress.XtraGrid.GridControl()
        Me.msJurnalDebit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccPendLainnya = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVJurnalDebit = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colJurnal_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_line = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_dk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_descr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRekanan_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRekanan_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSelectRekanan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryBtnRekanan = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.colAcc_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSelectAccId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryBtnAccId = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.colCurrency_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryCurrencyId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colJurnaldetil_Foreign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_Foreignrate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_Idr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChannel_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStrukturunit_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryStrukturunit_Id = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colRef_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cRef_line = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRef_BudgetLine = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRegion_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBranch_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBudget_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBudget_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSelect_Budget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryBudget = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colBudgetdetil_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBudgetdetil_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSelect_Budget_Detil = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryBudgetDetil = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryAccId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ftabJurnalKredit = New DevExpress.XtraTab.XtraTabPage()
        Me.GCJurnalKredit = New DevExpress.XtraGrid.GridControl()
        Me.msJurnalKredit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AccPendapatanLainnya = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVJurnalKredit = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryRekanan = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.pnlJurnalFooter = New DevExpress.XtraEditors.PanelControl()
        Me.btnAddCipAsset = New DevExpress.XtraEditors.SimpleButton()
        Me.ftabJurnalReference = New DevExpress.XtraTab.XtraTabPage()
        Me.GCJurnalReference = New DevExpress.XtraGrid.GridControl()
        Me.GVJurnalReference = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colJurnalReference_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnal_Id_Ref = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnal_Id_RefLine = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReferenceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ftabResponse = New DevExpress.XtraTab.XtraTabPage()
        Me.GCJurnalResponse = New DevExpress.XtraGrid.GridControl()
        Me.GVJurnalResponse = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colJurnalResponse_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalResponse_Line = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnal_descr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrency_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilResponse_ForeignRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilResponse_Idr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilResponse_Foreign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStrukturunit_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRekananResponse_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChannelRepsonse_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBook_dt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pnlJurnalHeader = New DevExpress.XtraEditors.PanelControl()
        Me.lueJurnalCurrency = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtJurnalDisc = New DevExpress.XtraEditors.TextEdit()
        Me.lbJurnalDisc = New DevExpress.XtraEditors.LabelControl()
        Me.lueJurnalPeriode = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbPeriod = New DevExpress.XtraEditors.LabelControl()
        Me.txtJurnalPPN = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtJurnalPPH = New DevExpress.XtraEditors.TextEdit()
        Me.lbJurnalPPh = New DevExpress.XtraEditors.LabelControl()
        Me.dtJurnalBookDate = New DevExpress.XtraEditors.DateEdit()
        Me.lbBookDate = New DevExpress.XtraEditors.LabelControl()
        Me.txtJurnalAmountIDR = New DevExpress.XtraEditors.TextEdit()
        Me.lbAmountIDR = New DevExpress.XtraEditors.LabelControl()
        Me.txtJurnalAmountForeign = New DevExpress.XtraEditors.TextEdit()
        Me.lbAmount = New DevExpress.XtraEditors.LabelControl()
        Me.txtJurnalRate = New DevExpress.XtraEditors.TextEdit()
        Me.lbRate = New DevExpress.XtraEditors.LabelControl()
        Me.lbCurrency = New DevExpress.XtraEditors.LabelControl()
        Me.ftabDataDetil_Info = New DevExpress.XtraTab.XtraTabPage()
        Me.chkAppAcc = New DevExpress.XtraEditors.CheckEdit()
        Me.lbAppAccDate = New DevExpress.XtraEditors.LabelControl()
        Me.txtAppAccDate = New DevExpress.XtraEditors.TextEdit()
        Me.lbAppAccBy = New DevExpress.XtraEditors.LabelControl()
        Me.txtAppAccBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtModifiedDate = New DevExpress.XtraEditors.TextEdit()
        Me.lblModifiedBy = New DevExpress.XtraEditors.LabelControl()
        Me.txtModifiedBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCreatedDate = New DevExpress.XtraEditors.TextEdit()
        Me.lbCreatedBy = New DevExpress.XtraEditors.LabelControl()
        Me.txtCreatedBy = New DevExpress.XtraEditors.TextEdit()
        Me.PnlDataMaster = New DevExpress.XtraEditors.PanelControl()
        Me.lueDept = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbDepartement = New DevExpress.XtraEditors.LabelControl()
        Me.txtNotes = New DevExpress.XtraEditors.MemoEdit()
        Me.lbNote = New DevExpress.XtraEditors.LabelControl()
        Me.txtLocation = New DevExpress.XtraEditors.TextEdit()
        Me.lbLocation = New DevExpress.XtraEditors.LabelControl()
        Me.lbReceiveType = New DevExpress.XtraEditors.LabelControl()
        Me.txtRvType = New DevExpress.XtraEditors.TextEdit()
        Me.lbReceivedNo = New DevExpress.XtraEditors.LabelControl()
        Me.txtRvID = New DevExpress.XtraEditors.TextEdit()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.ftabMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        CType(Me.GCRVRakitan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRVRakitan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PnlDfSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        CType(Me.lueSrchDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seRecord.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSrchRvID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSrchRvID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSrchRekananID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSrchDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSrchRekanan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueSrchChannelID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSrchChannel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_Data.SuspendLayout()
        CType(Me.ftabDataDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Detil.SuspendLayout()
        CType(Me.GCRVDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuRVRakitan.SuspendLayout()
        CType(Me.GVRVDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryAssetTipe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryAssetCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCatDepre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTipe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryBrandId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryAssetType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Jurnal.SuspendLayout()
        CType(Me.ftabJurnal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabJurnal.SuspendLayout()
        Me.ftabJurnalDebit.SuspendLayout()
        CType(Me.GCJurnalDebit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msJurnalDebit.SuspendLayout()
        CType(Me.GVJurnalDebit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryBtnRekanan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryBtnAccId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCurrencyId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryStrukturunit_Id, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryBudget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryBudgetDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryAccId, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabJurnalKredit.SuspendLayout()
        CType(Me.GCJurnalKredit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.msJurnalKredit.SuspendLayout()
        CType(Me.GVJurnalKredit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryRekanan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlJurnalFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlJurnalFooter.SuspendLayout()
        Me.ftabJurnalReference.SuspendLayout()
        CType(Me.GCJurnalReference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVJurnalReference, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabResponse.SuspendLayout()
        CType(Me.GCJurnalResponse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVJurnalResponse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlJurnalHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlJurnalHeader.SuspendLayout()
        CType(Me.lueJurnalCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJurnalDisc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueJurnalPeriode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJurnalPPN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJurnalPPH.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtJurnalBookDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtJurnalBookDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJurnalAmountIDR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJurnalAmountForeign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJurnalRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Info.SuspendLayout()
        CType(Me.chkAppAcc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAppAccDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAppAccBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModifiedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModifiedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreatedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PnlDataMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDataMaster.SuspendLayout()
        CType(Me.lueDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRvType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRvID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabMain.Location = New System.Drawing.Point(0, 26)
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedTabPage = Me.ftabMain_List
        Me.ftabMain.Size = New System.Drawing.Size(753, 522)
        Me.ftabMain.TabIndex = 4
        Me.ftabMain.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.ftabMain_List, Me.ftabMain_Data})
        '
        'ftabMain_List
        '
        Me.ftabMain_List.Controls.Add(Me.GCRVRakitan)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Size = New System.Drawing.Size(748, 497)
        Me.ftabMain_List.Text = "List"
        '
        'GCRVRakitan
        '
        Me.GCRVRakitan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRVRakitan.Location = New System.Drawing.Point(0, 97)
        Me.GCRVRakitan.MainView = Me.GVRVRakitan
        Me.GCRVRakitan.Name = "GCRVRakitan"
        Me.GCRVRakitan.Size = New System.Drawing.Size(748, 400)
        Me.GCRVRakitan.TabIndex = 1
        Me.GCRVRakitan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRVRakitan})
        '
        'GVRVRakitan
        '
        Me.GVRVRakitan.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTerimabarang_appacc, Me.colTerimabarang_id, Me.colTerimabarang_date, Me.colTerimabarang_type, Me.colOrder_Id, Me.colTerimabarangBudget_id, Me.colTerimabarangRekanan_id, Me.colEmployee_id_owner, Me.colTerimabarangStrukturunit_id, Me.colTerimabarang_qtyitem, Me.colTerimabarang_qtyrealization, Me.colOrder_qty, Me.colTerimabarang_status, Me.colTerimabarang_statusrealization, Me.colTerimabarang_location, Me.colTerimabarang_notes, Me.colTerimabarang_nosuratjalan, Me.colTerimabarangChannel_id, Me.colTerimabarang_isdisabled, Me.colTerimabarang_createby, Me.colTerimabarang_createdt, Me.colTerimabarang_modifiedby, Me.colTerimabarang_modifieddt, Me.colTerimabarang_appuser, Me.colTerimabarang_appuser_by, Me.colTerimabarang_appuser_dt, Me.colTerimabarang_appspv, Me.colTerimabarang_appspv_by, Me.colTerimabarang_appspv_dt, Me.colTerimabarang_appacc_by, Me.colTerimabarang_appacc_dt, Me.colTerimabarang_foreign, Me.colTerimabarangCurrency_id, Me.colTerimabarang_foreignrate, Me.colTerimabarang_idrreal, Me.colTerimabarang_pph, Me.colTerimabarang_ppn, Me.colTerimabarang_disc, Me.colTerimabarang_cetakbpb, Me.colTerimabarangRekanan_name, Me.colEmployee_name})
        Me.GVRVRakitan.GridControl = Me.GCRVRakitan
        Me.GVRVRakitan.Name = "GVRVRakitan"
        Me.GVRVRakitan.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVRVRakitan.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVRVRakitan.OptionsBehavior.Editable = False
        Me.GVRVRakitan.OptionsBehavior.ReadOnly = True
        Me.GVRVRakitan.OptionsView.ColumnAutoWidth = False
        Me.GVRVRakitan.OptionsView.ShowGroupPanel = False
        '
        'colTerimabarang_appacc
        '
        Me.colTerimabarang_appacc.AppearanceHeader.Options.UseTextOptions = True
        Me.colTerimabarang_appacc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colTerimabarang_appacc.Caption = "ACC"
        Me.colTerimabarang_appacc.FieldName = "terimabarang_appacc"
        Me.colTerimabarang_appacc.Name = "colTerimabarang_appacc"
        Me.colTerimabarang_appacc.Visible = True
        Me.colTerimabarang_appacc.VisibleIndex = 0
        Me.colTerimabarang_appacc.Width = 50
        '
        'colTerimabarang_id
        '
        Me.colTerimabarang_id.Caption = "Receive No."
        Me.colTerimabarang_id.FieldName = "terimabarang_id"
        Me.colTerimabarang_id.Name = "colTerimabarang_id"
        Me.colTerimabarang_id.Visible = True
        Me.colTerimabarang_id.VisibleIndex = 1
        Me.colTerimabarang_id.Width = 100
        '
        'colTerimabarang_date
        '
        Me.colTerimabarang_date.Caption = "Date"
        Me.colTerimabarang_date.FieldName = "terimabarang_date"
        Me.colTerimabarang_date.Name = "colTerimabarang_date"
        Me.colTerimabarang_date.Visible = True
        Me.colTerimabarang_date.VisibleIndex = 2
        '
        'colTerimabarang_type
        '
        Me.colTerimabarang_type.Caption = "Type"
        Me.colTerimabarang_type.FieldName = "terimabarang_type"
        Me.colTerimabarang_type.Name = "colTerimabarang_type"
        Me.colTerimabarang_type.Visible = True
        Me.colTerimabarang_type.VisibleIndex = 3
        '
        'colOrder_Id
        '
        Me.colOrder_Id.Caption = "Order ID"
        Me.colOrder_Id.FieldName = "order_id"
        Me.colOrder_Id.Name = "colOrder_Id"
        '
        'colTerimabarangBudget_id
        '
        Me.colTerimabarangBudget_id.Caption = "budget_id"
        Me.colTerimabarangBudget_id.FieldName = "budget_id"
        Me.colTerimabarangBudget_id.Name = "colTerimabarangBudget_id"
        '
        'colTerimabarangRekanan_id
        '
        Me.colTerimabarangRekanan_id.Caption = "rekanan_id"
        Me.colTerimabarangRekanan_id.FieldName = "rekanan_id"
        Me.colTerimabarangRekanan_id.Name = "colTerimabarangRekanan_id"
        '
        'colEmployee_id_owner
        '
        Me.colEmployee_id_owner.Caption = "employee_id_owner"
        Me.colEmployee_id_owner.FieldName = "employee_id_owner"
        Me.colEmployee_id_owner.Name = "colEmployee_id_owner"
        '
        'colTerimabarangStrukturunit_id
        '
        Me.colTerimabarangStrukturunit_id.Caption = "strukturunit_id"
        Me.colTerimabarangStrukturunit_id.FieldName = "strukturunit_id"
        Me.colTerimabarangStrukturunit_id.Name = "colTerimabarangStrukturunit_id"
        '
        'colTerimabarang_qtyitem
        '
        Me.colTerimabarang_qtyitem.Caption = "terimabarang_qtyitem"
        Me.colTerimabarang_qtyitem.FieldName = "terimabarang_qtyitem"
        Me.colTerimabarang_qtyitem.Name = "colTerimabarang_qtyitem"
        '
        'colTerimabarang_qtyrealization
        '
        Me.colTerimabarang_qtyrealization.Caption = "terimabarang_qtyrealization"
        Me.colTerimabarang_qtyrealization.FieldName = "terimabarang_qtyrealization"
        Me.colTerimabarang_qtyrealization.Name = "colTerimabarang_qtyrealization"
        '
        'colOrder_qty
        '
        Me.colOrder_qty.Caption = "order_qty"
        Me.colOrder_qty.FieldName = "order_qty"
        Me.colOrder_qty.Name = "colOrder_qty"
        '
        'colTerimabarang_status
        '
        Me.colTerimabarang_status.Caption = "Status"
        Me.colTerimabarang_status.FieldName = "terimabarang_status"
        Me.colTerimabarang_status.Name = "colTerimabarang_status"
        Me.colTerimabarang_status.Visible = True
        Me.colTerimabarang_status.VisibleIndex = 4
        '
        'colTerimabarang_statusrealization
        '
        Me.colTerimabarang_statusrealization.Caption = "terimabarang_statusrealization"
        Me.colTerimabarang_statusrealization.FieldName = "terimabarang_statusrealization"
        Me.colTerimabarang_statusrealization.Name = "colTerimabarang_statusrealization"
        '
        'colTerimabarang_location
        '
        Me.colTerimabarang_location.Caption = "terimabarang_location"
        Me.colTerimabarang_location.FieldName = "terimabarang_location"
        Me.colTerimabarang_location.Name = "colTerimabarang_location"
        '
        'colTerimabarang_notes
        '
        Me.colTerimabarang_notes.Caption = "Notes"
        Me.colTerimabarang_notes.FieldName = "terimabarang_notes"
        Me.colTerimabarang_notes.Name = "colTerimabarang_notes"
        Me.colTerimabarang_notes.Visible = True
        Me.colTerimabarang_notes.VisibleIndex = 5
        '
        'colTerimabarang_nosuratjalan
        '
        Me.colTerimabarang_nosuratjalan.Caption = "terimabarang_nosuratjalan"
        Me.colTerimabarang_nosuratjalan.FieldName = "terimabarang_nosuratjalan"
        Me.colTerimabarang_nosuratjalan.Name = "colTerimabarang_nosuratjalan"
        '
        'colTerimabarangChannel_id
        '
        Me.colTerimabarangChannel_id.Caption = "channel_id"
        Me.colTerimabarangChannel_id.FieldName = "channel_id"
        Me.colTerimabarangChannel_id.Name = "colTerimabarangChannel_id"
        '
        'colTerimabarang_isdisabled
        '
        Me.colTerimabarang_isdisabled.Caption = "terimabarang_isdisabled"
        Me.colTerimabarang_isdisabled.FieldName = "terimabarang_isdisabled"
        Me.colTerimabarang_isdisabled.Name = "colTerimabarang_isdisabled"
        '
        'colTerimabarang_createby
        '
        Me.colTerimabarang_createby.Caption = "terimabarang_createby"
        Me.colTerimabarang_createby.FieldName = "terimabarang_createby"
        Me.colTerimabarang_createby.Name = "colTerimabarang_createby"
        '
        'colTerimabarang_createdt
        '
        Me.colTerimabarang_createdt.Caption = "terimabarang_createdt"
        Me.colTerimabarang_createdt.FieldName = "terimabarang_createdt"
        Me.colTerimabarang_createdt.Name = "colTerimabarang_createdt"
        '
        'colTerimabarang_modifiedby
        '
        Me.colTerimabarang_modifiedby.Caption = "terimabarang_modifiedby"
        Me.colTerimabarang_modifiedby.FieldName = "terimabarang_modifiedby"
        Me.colTerimabarang_modifiedby.Name = "colTerimabarang_modifiedby"
        '
        'colTerimabarang_modifieddt
        '
        Me.colTerimabarang_modifieddt.Caption = "terimabarang_modifieddt"
        Me.colTerimabarang_modifieddt.FieldName = "terimabarang_modifieddt"
        Me.colTerimabarang_modifieddt.Name = "colTerimabarang_modifieddt"
        '
        'colTerimabarang_appuser
        '
        Me.colTerimabarang_appuser.Caption = "terimabarang_appuser"
        Me.colTerimabarang_appuser.FieldName = "terimabarang_appuser"
        Me.colTerimabarang_appuser.Name = "colTerimabarang_appuser"
        '
        'colTerimabarang_appuser_by
        '
        Me.colTerimabarang_appuser_by.Caption = "terimabarang_appuser_by"
        Me.colTerimabarang_appuser_by.FieldName = "terimabarang_appuser_by"
        Me.colTerimabarang_appuser_by.Name = "colTerimabarang_appuser_by"
        '
        'colTerimabarang_appuser_dt
        '
        Me.colTerimabarang_appuser_dt.Caption = "terimabarang_appuser_dt"
        Me.colTerimabarang_appuser_dt.FieldName = "terimabarang_appuser_dt"
        Me.colTerimabarang_appuser_dt.Name = "colTerimabarang_appuser_dt"
        '
        'colTerimabarang_appspv
        '
        Me.colTerimabarang_appspv.Caption = "terimabarang_appspv"
        Me.colTerimabarang_appspv.FieldName = "terimabarang_appspv"
        Me.colTerimabarang_appspv.Name = "colTerimabarang_appspv"
        '
        'colTerimabarang_appspv_by
        '
        Me.colTerimabarang_appspv_by.Caption = "terimabarang_appspv_by"
        Me.colTerimabarang_appspv_by.FieldName = "terimabarang_appspv_by"
        Me.colTerimabarang_appspv_by.Name = "colTerimabarang_appspv_by"
        '
        'colTerimabarang_appspv_dt
        '
        Me.colTerimabarang_appspv_dt.Caption = "terimabarang_appspv_dt"
        Me.colTerimabarang_appspv_dt.FieldName = "terimabarang_appspv_dt"
        Me.colTerimabarang_appspv_dt.Name = "colTerimabarang_appspv_dt"
        '
        'colTerimabarang_appacc_by
        '
        Me.colTerimabarang_appacc_by.Caption = "terimabarang_appacc_by"
        Me.colTerimabarang_appacc_by.FieldName = "terimabarang_appacc_by"
        Me.colTerimabarang_appacc_by.Name = "colTerimabarang_appacc_by"
        '
        'colTerimabarang_appacc_dt
        '
        Me.colTerimabarang_appacc_dt.Caption = "terimabarang_appacc_dt"
        Me.colTerimabarang_appacc_dt.FieldName = "terimabarang_appacc_dt"
        Me.colTerimabarang_appacc_dt.Name = "colTerimabarang_appacc_dt"
        '
        'colTerimabarang_foreign
        '
        Me.colTerimabarang_foreign.Caption = "terimabarang_foreign"
        Me.colTerimabarang_foreign.FieldName = "terimabarang_foreign"
        Me.colTerimabarang_foreign.Name = "colTerimabarang_foreign"
        '
        'colTerimabarangCurrency_id
        '
        Me.colTerimabarangCurrency_id.Caption = "currency_id"
        Me.colTerimabarangCurrency_id.FieldName = "currency_id"
        Me.colTerimabarangCurrency_id.Name = "colTerimabarangCurrency_id"
        '
        'colTerimabarang_foreignrate
        '
        Me.colTerimabarang_foreignrate.Caption = "terimabarang_foreignrate"
        Me.colTerimabarang_foreignrate.FieldName = "terimabarang_foreignrate"
        Me.colTerimabarang_foreignrate.Name = "colTerimabarang_foreignrate"
        '
        'colTerimabarang_idrreal
        '
        Me.colTerimabarang_idrreal.Caption = "terimabarang_idrreal"
        Me.colTerimabarang_idrreal.FieldName = "terimabarang_idrreal"
        Me.colTerimabarang_idrreal.Name = "colTerimabarang_idrreal"
        '
        'colTerimabarang_pph
        '
        Me.colTerimabarang_pph.Caption = "terimabarang_pph"
        Me.colTerimabarang_pph.FieldName = "terimabarang_pph"
        Me.colTerimabarang_pph.Name = "colTerimabarang_pph"
        '
        'colTerimabarang_ppn
        '
        Me.colTerimabarang_ppn.Caption = "terimabarang_ppn"
        Me.colTerimabarang_ppn.FieldName = "terimabarang_ppn"
        Me.colTerimabarang_ppn.Name = "colTerimabarang_ppn"
        '
        'colTerimabarang_disc
        '
        Me.colTerimabarang_disc.Caption = "terimabarang_disc"
        Me.colTerimabarang_disc.FieldName = "terimabarang_disc"
        Me.colTerimabarang_disc.Name = "colTerimabarang_disc"
        '
        'colTerimabarang_cetakbpb
        '
        Me.colTerimabarang_cetakbpb.Caption = "terimabarang_cetakbpb"
        Me.colTerimabarang_cetakbpb.FieldName = "terimabarang_cetakbpb"
        Me.colTerimabarang_cetakbpb.Name = "colTerimabarang_cetakbpb"
        '
        'colTerimabarangRekanan_name
        '
        Me.colTerimabarangRekanan_name.Caption = "Rekanan"
        Me.colTerimabarangRekanan_name.FieldName = "rekanan_name"
        Me.colTerimabarangRekanan_name.Name = "colTerimabarangRekanan_name"
        Me.colTerimabarangRekanan_name.Visible = True
        Me.colTerimabarangRekanan_name.VisibleIndex = 6
        '
        'colEmployee_name
        '
        Me.colEmployee_name.Caption = "Employee"
        Me.colEmployee_name.FieldName = "employee_name"
        Me.colEmployee_name.Name = "colEmployee_name"
        Me.colEmployee_name.Visible = True
        Me.colEmployee_name.VisibleIndex = 7
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.lueSrchDept)
        Me.PnlDfSearch.Controls.Add(Me.lbRecord)
        Me.PnlDfSearch.Controls.Add(Me.seRecord)
        Me.PnlDfSearch.Controls.Add(Me.txtSrchRvID)
        Me.PnlDfSearch.Controls.Add(Me.chkSrchRvID)
        Me.PnlDfSearch.Controls.Add(Me.btnRekanan)
        Me.PnlDfSearch.Controls.Add(Me.txtSrchRekananID)
        Me.PnlDfSearch.Controls.Add(Me.chkSrchDept)
        Me.PnlDfSearch.Controls.Add(Me.chkSrchRekanan)
        Me.PnlDfSearch.Controls.Add(Me.lueSrchChannelID)
        Me.PnlDfSearch.Controls.Add(Me.chkSrchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(0, 0)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(748, 97)
        Me.PnlDfSearch.TabIndex = 0
        '
        'lueSrchDept
        '
        Me.lueSrchDept.Location = New System.Drawing.Point(105, 65)
        Me.lueSrchDept.Name = "lueSrchDept"
        Me.lueSrchDept.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueSrchDept.Properties.NullText = ""
        Me.lueSrchDept.Size = New System.Drawing.Size(234, 20)
        Me.lueSrchDept.TabIndex = 11
        '
        'lbRecord
        '
        Me.lbRecord.Location = New System.Drawing.Point(357, 40)
        Me.lbRecord.Name = "lbRecord"
        Me.lbRecord.Size = New System.Drawing.Size(34, 13)
        Me.lbRecord.TabIndex = 10
        Me.lbRecord.Text = "Record"
        '
        'seRecord
        '
        Me.seRecord.EditValue = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.seRecord.Location = New System.Drawing.Point(397, 37)
        Me.seRecord.Name = "seRecord"
        Me.seRecord.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seRecord.Size = New System.Drawing.Size(53, 20)
        Me.seRecord.TabIndex = 9
        '
        'txtSrchRvID
        '
        Me.txtSrchRvID.Location = New System.Drawing.Point(397, 8)
        Me.txtSrchRvID.Name = "txtSrchRvID"
        Me.txtSrchRvID.Size = New System.Drawing.Size(188, 20)
        Me.txtSrchRvID.TabIndex = 8
        '
        'chkSrchRvID
        '
        Me.chkSrchRvID.Location = New System.Drawing.Point(339, 9)
        Me.chkSrchRvID.Name = "chkSrchRvID"
        Me.chkSrchRvID.Properties.Caption = "RV ID"
        Me.chkSrchRvID.Size = New System.Drawing.Size(67, 19)
        Me.chkSrchRvID.TabIndex = 7
        '
        'btnRekanan
        '
        Me.btnRekanan.Location = New System.Drawing.Point(183, 36)
        Me.btnRekanan.Name = "btnRekanan"
        Me.btnRekanan.Size = New System.Drawing.Size(31, 23)
        Me.btnRekanan.TabIndex = 5
        Me.btnRekanan.Text = "..."
        '
        'txtSrchRekananID
        '
        Me.txtSrchRekananID.Enabled = False
        Me.txtSrchRekananID.Location = New System.Drawing.Point(105, 37)
        Me.txtSrchRekananID.Name = "txtSrchRekananID"
        Me.txtSrchRekananID.Properties.ReadOnly = True
        Me.txtSrchRekananID.Size = New System.Drawing.Size(74, 20)
        Me.txtSrchRekananID.TabIndex = 4
        '
        'chkSrchDept
        '
        Me.chkSrchDept.Location = New System.Drawing.Point(5, 65)
        Me.chkSrchDept.Name = "chkSrchDept"
        Me.chkSrchDept.Properties.Caption = "Departement"
        Me.chkSrchDept.Size = New System.Drawing.Size(88, 19)
        Me.chkSrchDept.TabIndex = 3
        '
        'chkSrchRekanan
        '
        Me.chkSrchRekanan.Location = New System.Drawing.Point(5, 37)
        Me.chkSrchRekanan.Name = "chkSrchRekanan"
        Me.chkSrchRekanan.Properties.Caption = "Rekanan ID"
        Me.chkSrchRekanan.Size = New System.Drawing.Size(88, 19)
        Me.chkSrchRekanan.TabIndex = 2
        '
        'lueSrchChannelID
        '
        Me.lueSrchChannelID.Location = New System.Drawing.Point(105, 9)
        Me.lueSrchChannelID.Name = "lueSrchChannelID"
        Me.lueSrchChannelID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueSrchChannelID.Properties.NullText = ""
        Me.lueSrchChannelID.Properties.ReadOnly = True
        Me.lueSrchChannelID.Size = New System.Drawing.Size(217, 20)
        Me.lueSrchChannelID.TabIndex = 1
        '
        'chkSrchChannel
        '
        Me.chkSrchChannel.EditValue = True
        Me.chkSrchChannel.Enabled = False
        Me.chkSrchChannel.Location = New System.Drawing.Point(5, 11)
        Me.chkSrchChannel.Name = "chkSrchChannel"
        Me.chkSrchChannel.Properties.Caption = "Company"
        Me.chkSrchChannel.Size = New System.Drawing.Size(75, 19)
        Me.chkSrchChannel.TabIndex = 0
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Size = New System.Drawing.Size(748, 497)
        Me.ftabMain_Data.Text = "Data"
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Location = New System.Drawing.Point(0, 197)
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedTabPage = Me.ftabDataDetil_Detil
        Me.ftabDataDetil.Size = New System.Drawing.Size(748, 300)
        Me.ftabDataDetil.TabIndex = 1
        Me.ftabDataDetil.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.ftabDataDetil_Detil, Me.ftabDataDetil_Jurnal, Me.ftabDataDetil_Info})
        '
        'ftabDataDetil_Detil
        '
        Me.ftabDataDetil_Detil.Controls.Add(Me.GCRVDetil)
        Me.ftabDataDetil_Detil.Controls.Add(Me.PanelControl1)
        Me.ftabDataDetil_Detil.Name = "ftabDataDetil_Detil"
        Me.ftabDataDetil_Detil.Size = New System.Drawing.Size(743, 275)
        Me.ftabDataDetil_Detil.Text = "Detil"
        '
        'GCRVDetil
        '
        Me.GCRVDetil.ContextMenuStrip = Me.MenuRVRakitan
        Me.GCRVDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRVDetil.Location = New System.Drawing.Point(0, 0)
        Me.GCRVDetil.MainView = Me.GVRVDetil
        Me.GCRVDetil.Name = "GCRVDetil"
        Me.GCRVDetil.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryAssetType, Me.RepositoryAssetTipe, Me.RepositoryAssetCategory, Me.RepositoryItemId, Me.RepositoryItemCategory, Me.RepositoryItemTipe, Me.RepositoryBrandId, Me.RepositoryCatDepre})
        Me.GCRVDetil.Size = New System.Drawing.Size(743, 235)
        Me.GCRVDetil.TabIndex = 0
        Me.GCRVDetil.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRVDetil})
        '
        'MenuRVRakitan
        '
        Me.MenuRVRakitan.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddParentManual, Me.AddParentByRV, Me.AddChild})
        Me.MenuRVRakitan.Name = "MenuRVRakitan"
        Me.MenuRVRakitan.Size = New System.Drawing.Size(177, 70)
        '
        'AddParentManual
        '
        Me.AddParentManual.Name = "AddParentManual"
        Me.AddParentManual.Size = New System.Drawing.Size(176, 22)
        Me.AddParentManual.Text = "Add Parent Manual"
        '
        'AddParentByRV
        '
        Me.AddParentByRV.Name = "AddParentByRV"
        Me.AddParentByRV.Size = New System.Drawing.Size(176, 22)
        Me.AddParentByRV.Text = "Add Parent By RV"
        '
        'AddChild
        '
        Me.AddChild.Name = "AddChild"
        Me.AddChild.Size = New System.Drawing.Size(176, 22)
        Me.AddChild.Text = "Add Child"
        '
        'GVRVDetil
        '
        Me.GVRVDetil.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colLine, Me.colBarcode, Me.colPrint, Me.colDesc, Me.colNotPrinted, Me.colDate, Me.colAssetType, Me.colAssetCategory, Me.colCatDepre, Me.colItem, Me.colCategory, Me.colType, Me.colBrand, Me.colSerialNo, Me.colBarcodeType, Me.colQty, Me.colUnit, Me.colIsParent, Me.colRefID, Me.colRefDetil_Line, Me.colCurrency, Me.colAmount, Me.colRate, Me.colAmountIDR, Me.colTotalAmount, Me.colTotalAmountIDR})
        Me.GVRVDetil.GridControl = Me.GCRVDetil
        Me.GVRVDetil.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVRVDetil.Name = "GVRVDetil"
        Me.GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVRVDetil.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVRVDetil.OptionsSelection.MultiSelect = True
        Me.GVRVDetil.OptionsView.ColumnAutoWidth = False
        Me.GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GVRVDetil.OptionsView.ShowGroupPanel = False
        Me.GVRVDetil.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colLine
        '
        Me.colLine.Caption = "Line"
        Me.colLine.FieldName = "terimabarangdetil_line"
        Me.colLine.Name = "colLine"
        Me.colLine.OptionsColumn.AllowEdit = False
        Me.colLine.OptionsColumn.ReadOnly = True
        Me.colLine.Visible = True
        Me.colLine.VisibleIndex = 0
        Me.colLine.Width = 53
        '
        'colBarcode
        '
        Me.colBarcode.Caption = "Barcode"
        Me.colBarcode.FieldName = "terimabarang_barcode"
        Me.colBarcode.Name = "colBarcode"
        Me.colBarcode.OptionsColumn.AllowEdit = False
        Me.colBarcode.OptionsColumn.ReadOnly = True
        Me.colBarcode.Visible = True
        Me.colBarcode.VisibleIndex = 1
        '
        'colPrint
        '
        Me.colPrint.Caption = "Print"
        Me.colPrint.Name = "colPrint"
        '
        'colDesc
        '
        Me.colDesc.Caption = "Description"
        Me.colDesc.FieldName = "terimabarangdetil_desc"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.Visible = True
        Me.colDesc.VisibleIndex = 2
        Me.colDesc.Width = 133
        '
        'colNotPrinted
        '
        Me.colNotPrinted.Caption = "Not Printed"
        Me.colNotPrinted.Name = "colNotPrinted"
        '
        'colDate
        '
        Me.colDate.Caption = "Date"
        Me.colDate.FieldName = "terimabarangdetil_date"
        Me.colDate.Name = "colDate"
        Me.colDate.Visible = True
        Me.colDate.VisibleIndex = 3
        '
        'colAssetType
        '
        Me.colAssetType.Caption = "Asset Type"
        Me.colAssetType.ColumnEdit = Me.RepositoryAssetTipe
        Me.colAssetType.FieldName = "assettype_id"
        Me.colAssetType.Name = "colAssetType"
        Me.colAssetType.Visible = True
        Me.colAssetType.VisibleIndex = 4
        '
        'RepositoryAssetTipe
        '
        Me.RepositoryAssetTipe.AutoHeight = False
        Me.RepositoryAssetTipe.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryAssetTipe.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tipeasset_id", " ")})
        Me.RepositoryAssetTipe.Name = "RepositoryAssetTipe"
        Me.RepositoryAssetTipe.NullText = "-- PILIH --"
        '
        'colAssetCategory
        '
        Me.colAssetCategory.Caption = "Asset Category"
        Me.colAssetCategory.ColumnEdit = Me.RepositoryAssetCategory
        Me.colAssetCategory.FieldName = "assetcategory_id"
        Me.colAssetCategory.Name = "colAssetCategory"
        Me.colAssetCategory.Visible = True
        Me.colAssetCategory.VisibleIndex = 5
        Me.colAssetCategory.Width = 92
        '
        'RepositoryAssetCategory
        '
        Me.RepositoryAssetCategory.AutoHeight = False
        Me.RepositoryAssetCategory.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryAssetCategory.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("kategoriasset_id", " ")})
        Me.RepositoryAssetCategory.Name = "RepositoryAssetCategory"
        Me.RepositoryAssetCategory.NullText = "-- PILIH --"
        '
        'colCatDepre
        '
        Me.colCatDepre.Caption = "Asset Depre"
        Me.colCatDepre.ColumnEdit = Me.RepositoryCatDepre
        Me.colCatDepre.FieldName = "terimabarangdetil_golfiskal"
        Me.colCatDepre.Name = "colCatDepre"
        Me.colCatDepre.Visible = True
        Me.colCatDepre.VisibleIndex = 6
        Me.colCatDepre.Width = 113
        '
        'RepositoryCatDepre
        '
        Me.RepositoryCatDepre.AutoHeight = False
        Me.RepositoryCatDepre.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryCatDepre.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("kategoriassetdepre_descr", " ")})
        Me.RepositoryCatDepre.Name = "RepositoryCatDepre"
        Me.RepositoryCatDepre.NullText = "-- PILIH --"
        '
        'colItem
        '
        Me.colItem.Caption = "Item"
        Me.colItem.ColumnEdit = Me.RepositoryItemId
        Me.colItem.FieldName = "item_id"
        Me.colItem.Name = "colItem"
        Me.colItem.Visible = True
        Me.colItem.VisibleIndex = 7
        '
        'RepositoryItemId
        '
        Me.RepositoryItemId.AutoHeight = False
        Me.RepositoryItemId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("item_name", " ")})
        Me.RepositoryItemId.Name = "RepositoryItemId"
        Me.RepositoryItemId.NullText = "-- PILIH --"
        '
        'colCategory
        '
        Me.colCategory.Caption = "Category"
        Me.colCategory.ColumnEdit = Me.RepositoryItemCategory
        Me.colCategory.FieldName = "itemcategory_id"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.Visible = True
        Me.colCategory.VisibleIndex = 8
        '
        'RepositoryItemCategory
        '
        Me.RepositoryItemCategory.AutoHeight = False
        Me.RepositoryItemCategory.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCategory.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("category_name", " ")})
        Me.RepositoryItemCategory.Name = "RepositoryItemCategory"
        Me.RepositoryItemCategory.NullText = "-- PILIH --"
        '
        'colType
        '
        Me.colType.Caption = "Type"
        Me.colType.ColumnEdit = Me.RepositoryItemTipe
        Me.colType.FieldName = "itemtype_id"
        Me.colType.Name = "colType"
        Me.colType.Visible = True
        Me.colType.VisibleIndex = 9
        Me.colType.Width = 112
        '
        'RepositoryItemTipe
        '
        Me.RepositoryItemTipe.AutoHeight = False
        Me.RepositoryItemTipe.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTipe.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Tipeitem_id", " ")})
        Me.RepositoryItemTipe.Name = "RepositoryItemTipe"
        Me.RepositoryItemTipe.NullText = "-- PILIH --"
        '
        'colBrand
        '
        Me.colBrand.Caption = "Brand"
        Me.colBrand.ColumnEdit = Me.RepositoryBrandId
        Me.colBrand.FieldName = "brand_id"
        Me.colBrand.Name = "colBrand"
        Me.colBrand.Visible = True
        Me.colBrand.VisibleIndex = 10
        '
        'RepositoryBrandId
        '
        Me.RepositoryBrandId.AutoHeight = False
        Me.RepositoryBrandId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryBrandId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("merk_name", " ")})
        Me.RepositoryBrandId.Name = "RepositoryBrandId"
        Me.RepositoryBrandId.NullText = "-- PILIH --"
        '
        'colSerialNo
        '
        Me.colSerialNo.Caption = "Serial No."
        Me.colSerialNo.FieldName = "terimabarangdetil_serial_no"
        Me.colSerialNo.Name = "colSerialNo"
        Me.colSerialNo.Visible = True
        Me.colSerialNo.VisibleIndex = 11
        '
        'colBarcodeType
        '
        Me.colBarcodeType.Caption = "Barcode Type"
        Me.colBarcodeType.FieldName = "terimabarangdetil_product_no"
        Me.colBarcodeType.Name = "colBarcodeType"
        '
        'colQty
        '
        Me.colQty.Caption = "Qty"
        Me.colQty.FieldName = "terimabarangdetil_qty"
        Me.colQty.Name = "colQty"
        Me.colQty.Visible = True
        Me.colQty.VisibleIndex = 12
        '
        'colUnit
        '
        Me.colUnit.Caption = "Unit"
        Me.colUnit.FieldName = "unit_id"
        Me.colUnit.Name = "colUnit"
        Me.colUnit.Visible = True
        Me.colUnit.VisibleIndex = 13
        '
        'colIsParent
        '
        Me.colIsParent.Caption = "Is Parent"
        Me.colIsParent.FieldName = "is_parent"
        Me.colIsParent.Name = "colIsParent"
        Me.colIsParent.OptionsColumn.ReadOnly = True
        Me.colIsParent.Visible = True
        Me.colIsParent.VisibleIndex = 14
        '
        'colRefID
        '
        Me.colRefID.Caption = "Ref ID"
        Me.colRefID.FieldName = "ref_id"
        Me.colRefID.Name = "colRefID"
        Me.colRefID.OptionsColumn.ReadOnly = True
        Me.colRefID.Visible = True
        Me.colRefID.VisibleIndex = 15
        Me.colRefID.Width = 100
        '
        'colRefDetil_Line
        '
        Me.colRefDetil_Line.Caption = "Ref Detil Line"
        Me.colRefDetil_Line.FieldName = "refdetil_line"
        Me.colRefDetil_Line.Name = "colRefDetil_Line"
        Me.colRefDetil_Line.OptionsColumn.ReadOnly = True
        Me.colRefDetil_Line.Visible = True
        Me.colRefDetil_Line.VisibleIndex = 16
        '
        'colCurrency
        '
        Me.colCurrency.Caption = "Currency"
        Me.colCurrency.FieldName = "currency_id"
        Me.colCurrency.Name = "colCurrency"
        Me.colCurrency.OptionsColumn.ReadOnly = True
        '
        'colAmount
        '
        Me.colAmount.Caption = "Amount"
        Me.colAmount.Name = "colAmount"
        '
        'colRate
        '
        Me.colRate.Caption = "Rate"
        Me.colRate.FieldName = "terimabarangdetil_foreignrate"
        Me.colRate.Name = "colRate"
        '
        'colAmountIDR
        '
        Me.colAmountIDR.Caption = "Amount (IDR)"
        Me.colAmountIDR.DisplayFormat.FormatString = "#,##0.00"
        Me.colAmountIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAmountIDR.FieldName = "terimabarangdetil_idrreal"
        Me.colAmountIDR.Name = "colAmountIDR"
        Me.colAmountIDR.Visible = True
        Me.colAmountIDR.VisibleIndex = 17
        '
        'colTotalAmount
        '
        Me.colTotalAmount.Caption = "Total Amount"
        Me.colTotalAmount.Name = "colTotalAmount"
        '
        'colTotalAmountIDR
        '
        Me.colTotalAmountIDR.Caption = "Total Amount (IDR)"
        Me.colTotalAmountIDR.DisplayFormat.FormatString = "#,##0.00"
        Me.colTotalAmountIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colTotalAmountIDR.FieldName = "terimabarangdetil_totalidrreal"
        Me.colTotalAmountIDR.Name = "colTotalAmountIDR"
        Me.colTotalAmountIDR.OptionsColumn.ReadOnly = True
        Me.colTotalAmountIDR.Visible = True
        Me.colTotalAmountIDR.VisibleIndex = 18
        '
        'RepositoryAssetType
        '
        Me.RepositoryAssetType.AutoHeight = False
        Me.RepositoryAssetType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryAssetType.Name = "RepositoryAssetType"
        Me.RepositoryAssetType.NullText = "-- PILIH --"
        '
        'PanelControl1
        '
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 235)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(743, 40)
        Me.PanelControl1.TabIndex = 1
        '
        'ftabDataDetil_Jurnal
        '
        Me.ftabDataDetil_Jurnal.Controls.Add(Me.ftabJurnal)
        Me.ftabDataDetil_Jurnal.Controls.Add(Me.pnlJurnalHeader)
        Me.ftabDataDetil_Jurnal.Name = "ftabDataDetil_Jurnal"
        Me.ftabDataDetil_Jurnal.Size = New System.Drawing.Size(743, 275)
        Me.ftabDataDetil_Jurnal.Text = "Jurnal"
        '
        'ftabJurnal
        '
        Me.ftabJurnal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabJurnal.Location = New System.Drawing.Point(0, 90)
        Me.ftabJurnal.Name = "ftabJurnal"
        Me.ftabJurnal.SelectedTabPage = Me.ftabJurnalDebit
        Me.ftabJurnal.Size = New System.Drawing.Size(743, 185)
        Me.ftabJurnal.TabIndex = 2
        Me.ftabJurnal.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.ftabJurnalDebit, Me.ftabJurnalKredit, Me.ftabJurnalReference, Me.ftabResponse})
        '
        'ftabJurnalDebit
        '
        Me.ftabJurnalDebit.Controls.Add(Me.GCJurnalDebit)
        Me.ftabJurnalDebit.Name = "ftabJurnalDebit"
        Me.ftabJurnalDebit.Size = New System.Drawing.Size(738, 160)
        Me.ftabJurnalDebit.Text = "Penerimaan (D)"
        '
        'GCJurnalDebit
        '
        Me.GCJurnalDebit.ContextMenuStrip = Me.msJurnalDebit
        Me.GCJurnalDebit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCJurnalDebit.Location = New System.Drawing.Point(0, 0)
        Me.GCJurnalDebit.MainView = Me.GVJurnalDebit
        Me.GCJurnalDebit.Name = "GCJurnalDebit"
        Me.GCJurnalDebit.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryBtnRekanan, Me.RepositoryAccId, Me.RepositoryCurrencyId, Me.RepositoryStrukturunit_Id, Me.RepositoryBudget, Me.RepositoryBudgetDetil, Me.RepositoryBtnAccId})
        Me.GCJurnalDebit.Size = New System.Drawing.Size(738, 160)
        Me.GCJurnalDebit.TabIndex = 0
        Me.GCJurnalDebit.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVJurnalDebit})
        '
        'msJurnalDebit
        '
        Me.msJurnalDebit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.AccPendLainnya})
        Me.msJurnalDebit.Name = "msJurnalDebit"
        Me.msJurnalDebit.Size = New System.Drawing.Size(177, 48)
        Me.msJurnalDebit.Text = "Add "
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'AccPendLainnya
        '
        Me.AccPendLainnya.Enabled = False
        Me.AccPendLainnya.Name = "AccPendLainnya"
        Me.AccPendLainnya.Size = New System.Drawing.Size(176, 22)
        Me.AccPendLainnya.Text = "Add Biaya Lain-lain"
        Me.AccPendLainnya.Visible = False
        '
        'GVJurnalDebit
        '
        Me.GVJurnalDebit.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colJurnal_Id, Me.colJurnaldetil_line, Me.colJurnaldetil_dk, Me.colJurnaldetil_descr, Me.colRekanan_Id, Me.colRekanan_Name, Me.colSelectRekanan, Me.colAcc_id, Me.colSelectAccId, Me.colCurrency_Id, Me.colJurnaldetil_Foreign, Me.colJurnaldetil_Foreignrate, Me.colJurnaldetil_Idr, Me.colChannel_Id, Me.colStrukturunit_Id, Me.colRef_Id, Me.cRef_line, Me.colRef_BudgetLine, Me.colRegion_Id, Me.colBranch_Id, Me.colBudget_Id, Me.colBudget_Name, Me.colSelect_Budget, Me.colBudgetdetil_Id, Me.colBudgetdetil_Name, Me.colSelect_Budget_Detil})
        Me.GVJurnalDebit.GridControl = Me.GCJurnalDebit
        Me.GVJurnalDebit.Name = "GVJurnalDebit"
        Me.GVJurnalDebit.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVJurnalDebit.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVJurnalDebit.OptionsSelection.MultiSelect = True
        Me.GVJurnalDebit.OptionsView.ColumnAutoWidth = False
        Me.GVJurnalDebit.OptionsView.ShowGroupPanel = False
        '
        'colJurnal_Id
        '
        Me.colJurnal_Id.Caption = "Jurnal ID"
        Me.colJurnal_Id.FieldName = "jurnal_id"
        Me.colJurnal_Id.Name = "colJurnal_Id"
        '
        'colJurnaldetil_line
        '
        Me.colJurnaldetil_line.Caption = "Line"
        Me.colJurnaldetil_line.FieldName = "jurnaldetil_line"
        Me.colJurnaldetil_line.Name = "colJurnaldetil_line"
        Me.colJurnaldetil_line.OptionsColumn.AllowEdit = False
        Me.colJurnaldetil_line.OptionsColumn.ReadOnly = True
        Me.colJurnaldetil_line.Visible = True
        Me.colJurnaldetil_line.VisibleIndex = 0
        Me.colJurnaldetil_line.Width = 50
        '
        'colJurnaldetil_dk
        '
        Me.colJurnaldetil_dk.Caption = "jurnaldetil_dk"
        Me.colJurnaldetil_dk.FieldName = "jurnaldetil_dk"
        Me.colJurnaldetil_dk.Name = "colJurnaldetil_dk"
        '
        'colJurnaldetil_descr
        '
        Me.colJurnaldetil_descr.Caption = "Description"
        Me.colJurnaldetil_descr.FieldName = "jurnaldetil_descr"
        Me.colJurnaldetil_descr.Name = "colJurnaldetil_descr"
        Me.colJurnaldetil_descr.Visible = True
        Me.colJurnaldetil_descr.VisibleIndex = 1
        Me.colJurnaldetil_descr.Width = 150
        '
        'colRekanan_Id
        '
        Me.colRekanan_Id.Caption = "Vendor ID"
        Me.colRekanan_Id.FieldName = "rekanan_id"
        Me.colRekanan_Id.Name = "colRekanan_Id"
        Me.colRekanan_Id.OptionsColumn.AllowEdit = False
        Me.colRekanan_Id.OptionsColumn.ReadOnly = True
        Me.colRekanan_Id.Visible = True
        Me.colRekanan_Id.VisibleIndex = 2
        '
        'colRekanan_Name
        '
        Me.colRekanan_Name.Caption = "Vendor Name"
        Me.colRekanan_Name.FieldName = "rekanan_name"
        Me.colRekanan_Name.Name = "colRekanan_Name"
        Me.colRekanan_Name.OptionsColumn.AllowEdit = False
        Me.colRekanan_Name.OptionsColumn.ReadOnly = True
        Me.colRekanan_Name.Visible = True
        Me.colRekanan_Name.VisibleIndex = 3
        Me.colRekanan_Name.Width = 100
        '
        'colSelectRekanan
        '
        Me.colSelectRekanan.Caption = " "
        Me.colSelectRekanan.ColumnEdit = Me.RepositoryBtnRekanan
        Me.colSelectRekanan.Name = "colSelectRekanan"
        Me.colSelectRekanan.Visible = True
        Me.colSelectRekanan.VisibleIndex = 4
        Me.colSelectRekanan.Width = 40
        '
        'RepositoryBtnRekanan
        '
        Me.RepositoryBtnRekanan.AutoHeight = False
        Me.RepositoryBtnRekanan.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, " ... ", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.RepositoryBtnRekanan.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.RepositoryBtnRekanan.Name = "RepositoryBtnRekanan"
        Me.RepositoryBtnRekanan.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'colAcc_id
        '
        Me.colAcc_id.Caption = "Account"
        Me.colAcc_id.FieldName = "acc_id"
        Me.colAcc_id.Name = "colAcc_id"
        Me.colAcc_id.Visible = True
        Me.colAcc_id.VisibleIndex = 5
        '
        'colSelectAccId
        '
        Me.colSelectAccId.ColumnEdit = Me.RepositoryBtnAccId
        Me.colSelectAccId.Name = "colSelectAccId"
        Me.colSelectAccId.Visible = True
        Me.colSelectAccId.VisibleIndex = 6
        Me.colSelectAccId.Width = 40
        '
        'RepositoryBtnAccId
        '
        Me.RepositoryBtnAccId.AutoHeight = False
        Me.RepositoryBtnAccId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, " ... ", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.RepositoryBtnAccId.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.RepositoryBtnAccId.Name = "RepositoryBtnAccId"
        Me.RepositoryBtnAccId.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'colCurrency_Id
        '
        Me.colCurrency_Id.Caption = "Curr."
        Me.colCurrency_Id.ColumnEdit = Me.RepositoryCurrencyId
        Me.colCurrency_Id.FieldName = "currency_id"
        Me.colCurrency_Id.Name = "colCurrency_Id"
        '
        'RepositoryCurrencyId
        '
        Me.RepositoryCurrencyId.AutoHeight = False
        Me.RepositoryCurrencyId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryCurrencyId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency_shortname", " ")})
        Me.RepositoryCurrencyId.Name = "RepositoryCurrencyId"
        Me.RepositoryCurrencyId.NullText = "-- PILIH --"
        '
        'colJurnaldetil_Foreign
        '
        Me.colJurnaldetil_Foreign.Caption = "Amount"
        Me.colJurnaldetil_Foreign.DisplayFormat.FormatString = "#,##0.00"
        Me.colJurnaldetil_Foreign.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colJurnaldetil_Foreign.FieldName = "jurnaldetil_foreign"
        Me.colJurnaldetil_Foreign.Name = "colJurnaldetil_Foreign"
        Me.colJurnaldetil_Foreign.Visible = True
        Me.colJurnaldetil_Foreign.VisibleIndex = 7
        Me.colJurnaldetil_Foreign.Width = 100
        '
        'colJurnaldetil_Foreignrate
        '
        Me.colJurnaldetil_Foreignrate.Caption = "Rate"
        Me.colJurnaldetil_Foreignrate.DisplayFormat.FormatString = "#,##0.00"
        Me.colJurnaldetil_Foreignrate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colJurnaldetil_Foreignrate.FieldName = "jurnaldetil_foreignrate"
        Me.colJurnaldetil_Foreignrate.Name = "colJurnaldetil_Foreignrate"
        Me.colJurnaldetil_Foreignrate.OptionsColumn.AllowEdit = False
        Me.colJurnaldetil_Foreignrate.OptionsColumn.ReadOnly = True
        Me.colJurnaldetil_Foreignrate.Visible = True
        Me.colJurnaldetil_Foreignrate.VisibleIndex = 8
        Me.colJurnaldetil_Foreignrate.Width = 50
        '
        'colJurnaldetil_Idr
        '
        Me.colJurnaldetil_Idr.Caption = "Amount (IDR)"
        Me.colJurnaldetil_Idr.DisplayFormat.FormatString = "#,##0"
        Me.colJurnaldetil_Idr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colJurnaldetil_Idr.FieldName = "jurnaldetil_idr"
        Me.colJurnaldetil_Idr.Name = "colJurnaldetil_Idr"
        Me.colJurnaldetil_Idr.Visible = True
        Me.colJurnaldetil_Idr.VisibleIndex = 9
        Me.colJurnaldetil_Idr.Width = 100
        '
        'colChannel_Id
        '
        Me.colChannel_Id.Caption = "channel_id"
        Me.colChannel_Id.FieldName = "channel_id"
        Me.colChannel_Id.Name = "colChannel_Id"
        '
        'colStrukturunit_Id
        '
        Me.colStrukturunit_Id.Caption = "Department"
        Me.colStrukturunit_Id.ColumnEdit = Me.RepositoryStrukturunit_Id
        Me.colStrukturunit_Id.FieldName = "strukturunit_id"
        Me.colStrukturunit_Id.Name = "colStrukturunit_Id"
        '
        'RepositoryStrukturunit_Id
        '
        Me.RepositoryStrukturunit_Id.AutoHeight = False
        Me.RepositoryStrukturunit_Id.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryStrukturunit_Id.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("strukturunit_name", " ")})
        Me.RepositoryStrukturunit_Id.Name = "RepositoryStrukturunit_Id"
        Me.RepositoryStrukturunit_Id.NullText = "-- PILIH --"
        '
        'colRef_Id
        '
        Me.colRef_Id.Caption = "Ref. ID"
        Me.colRef_Id.FieldName = "ref_id"
        Me.colRef_Id.Name = "colRef_Id"
        Me.colRef_Id.Width = 100
        '
        'cRef_line
        '
        Me.cRef_line.Caption = "Ref. Line"
        Me.cRef_line.FieldName = "ref_line"
        Me.cRef_line.Name = "cRef_line"
        '
        'colRef_BudgetLine
        '
        Me.colRef_BudgetLine.Caption = "Ref.BudgetLn"
        Me.colRef_BudgetLine.FieldName = "ref_budgetline"
        Me.colRef_BudgetLine.Name = "colRef_BudgetLine"
        '
        'colRegion_Id
        '
        Me.colRegion_Id.Caption = "region_id"
        Me.colRegion_Id.FieldName = "region_id"
        Me.colRegion_Id.Name = "colRegion_Id"
        '
        'colBranch_Id
        '
        Me.colBranch_Id.Caption = "branch_id"
        Me.colBranch_Id.FieldName = "branch_id"
        Me.colBranch_Id.Name = "colBranch_Id"
        '
        'colBudget_Id
        '
        Me.colBudget_Id.Caption = "Budget ID"
        Me.colBudget_Id.FieldName = "budget_id"
        Me.colBudget_Id.Name = "colBudget_Id"
        '
        'colBudget_Name
        '
        Me.colBudget_Name.Caption = "Budget Name"
        Me.colBudget_Name.FieldName = "budget_name"
        Me.colBudget_Name.Name = "colBudget_Name"
        Me.colBudget_Name.Width = 150
        '
        'colSelect_Budget
        '
        Me.colSelect_Budget.ColumnEdit = Me.RepositoryBudget
        Me.colSelect_Budget.Name = "colSelect_Budget"
        Me.colSelect_Budget.Width = 40
        '
        'RepositoryBudget
        '
        Me.RepositoryBudget.AutoHeight = False
        Me.RepositoryBudget.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, " ... ", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "", Nothing, Nothing, False)})
        Me.RepositoryBudget.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.RepositoryBudget.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("budget_name", " ")})
        Me.RepositoryBudget.Name = "RepositoryBudget"
        Me.RepositoryBudget.NullText = "-- PILIH --"
        Me.RepositoryBudget.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'colBudgetdetil_Id
        '
        Me.colBudgetdetil_Id.Caption = "Budget Detil ID"
        Me.colBudgetdetil_Id.FieldName = "budgetdetil_id"
        Me.colBudgetdetil_Id.Name = "colBudgetdetil_Id"
        '
        'colBudgetdetil_Name
        '
        Me.colBudgetdetil_Name.Caption = "Budget Detil Name"
        Me.colBudgetdetil_Name.FieldName = "budgetdetil_name"
        Me.colBudgetdetil_Name.Name = "colBudgetdetil_Name"
        Me.colBudgetdetil_Name.Width = 150
        '
        'colSelect_Budget_Detil
        '
        Me.colSelect_Budget_Detil.ColumnEdit = Me.RepositoryBudgetDetil
        Me.colSelect_Budget_Detil.Name = "colSelect_Budget_Detil"
        Me.colSelect_Budget_Detil.Width = 40
        '
        'RepositoryBudgetDetil
        '
        Me.RepositoryBudgetDetil.AutoHeight = False
        Me.RepositoryBudgetDetil.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, " ... ", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, "", Nothing, Nothing, True)})
        Me.RepositoryBudgetDetil.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.RepositoryBudgetDetil.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("budgetdetil_name", " ")})
        Me.RepositoryBudgetDetil.Name = "RepositoryBudgetDetil"
        Me.RepositoryBudgetDetil.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'RepositoryAccId
        '
        Me.RepositoryAccId.AutoHeight = False
        Me.RepositoryAccId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryAccId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("acc_name", " ")})
        Me.RepositoryAccId.Name = "RepositoryAccId"
        Me.RepositoryAccId.NullText = "-- PILIH --"
        '
        'ftabJurnalKredit
        '
        Me.ftabJurnalKredit.Controls.Add(Me.GCJurnalKredit)
        Me.ftabJurnalKredit.Controls.Add(Me.pnlJurnalFooter)
        Me.ftabJurnalKredit.Name = "ftabJurnalKredit"
        Me.ftabJurnalKredit.Size = New System.Drawing.Size(738, 160)
        Me.ftabJurnalKredit.Text = "Pembayaran (K)"
        '
        'GCJurnalKredit
        '
        Me.GCJurnalKredit.ContextMenuStrip = Me.msJurnalKredit
        Me.GCJurnalKredit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCJurnalKredit.Location = New System.Drawing.Point(0, 0)
        Me.GCJurnalKredit.MainView = Me.GVJurnalKredit
        Me.GCJurnalKredit.Name = "GCJurnalKredit"
        Me.GCJurnalKredit.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryRekanan, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemLookUpEdit2, Me.RepositoryItemLookUpEdit3, Me.RepositoryItemLookUpEdit4, Me.RepositoryItemLookUpEdit5})
        Me.GCJurnalKredit.Size = New System.Drawing.Size(738, 123)
        Me.GCJurnalKredit.TabIndex = 4
        Me.GCJurnalKredit.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVJurnalKredit})
        '
        'msJurnalKredit
        '
        Me.msJurnalKredit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AccPendapatanLainnya})
        Me.msJurnalKredit.Name = "msJurnalDebit"
        Me.msJurnalKredit.Size = New System.Drawing.Size(220, 26)
        Me.msJurnalKredit.Text = "Add "
        '
        'AccPendapatanLainnya
        '
        Me.AccPendapatanLainnya.Enabled = False
        Me.AccPendapatanLainnya.Name = "AccPendapatanLainnya"
        Me.AccPendapatanLainnya.Size = New System.Drawing.Size(219, 22)
        Me.AccPendapatanLainnya.Text = "Add (Pendapatan) Lain-lain"
        Me.AccPendapatanLainnya.Visible = False
        '
        'GVJurnalKredit
        '
        Me.GVJurnalKredit.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25})
        Me.GVJurnalKredit.GridControl = Me.GCJurnalKredit
        Me.GVJurnalKredit.Name = "GVJurnalKredit"
        Me.GVJurnalKredit.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVJurnalKredit.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVJurnalKredit.OptionsSelection.MultiSelect = True
        Me.GVJurnalKredit.OptionsView.ColumnAutoWidth = False
        Me.GVJurnalKredit.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Jurnal ID"
        Me.GridColumn1.FieldName = "jurnal_id"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Line"
        Me.GridColumn2.FieldName = "jurnaldetil_line"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 50
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "jurnaldetil_dk"
        Me.GridColumn3.FieldName = "jurnaldetil_dk"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Description"
        Me.GridColumn4.FieldName = "jurnaldetil_descr"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 150
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Vendor ID"
        Me.GridColumn5.FieldName = "rekanan_id"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Vendor Name"
        Me.GridColumn6.FieldName = "rekanan_name"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 3
        Me.GridColumn6.Width = 100
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = " "
        Me.GridColumn7.ColumnEdit = Me.RepositoryRekanan
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        '
        'RepositoryRekanan
        '
        Me.RepositoryRekanan.AutoHeight = False
        Me.RepositoryRekanan.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryRekanan.Name = "RepositoryRekanan"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Account"
        Me.GridColumn8.FieldName = "acc_id"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 4
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Curr."
        Me.GridColumn9.ColumnEdit = Me.RepositoryItemLookUpEdit2
        Me.GridColumn9.FieldName = "currency_id"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemLookUpEdit2
        '
        Me.RepositoryItemLookUpEdit2.AutoHeight = False
        Me.RepositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit2.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency_shortname", " ")})
        Me.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2"
        Me.RepositoryItemLookUpEdit2.NullText = "-- PILIH --"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Amount"
        Me.GridColumn10.DisplayFormat.FormatString = "#,##0.00"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumn10.FieldName = "jurnaldetil_foreign"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 5
        Me.GridColumn10.Width = 100
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Rate"
        Me.GridColumn11.DisplayFormat.FormatString = "#,##0.00"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumn11.FieldName = "jurnaldetil_foreignrate"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 6
        Me.GridColumn11.Width = 50
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Amount (IDR)"
        Me.GridColumn12.DisplayFormat.FormatString = "#,##0"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumn12.FieldName = "jurnaldetil_idr"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 7
        Me.GridColumn12.Width = 100
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "channel_id"
        Me.GridColumn13.FieldName = "channel_id"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.ReadOnly = True
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Department"
        Me.GridColumn14.ColumnEdit = Me.RepositoryItemLookUpEdit3
        Me.GridColumn14.FieldName = "strukturunit_id"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemLookUpEdit3
        '
        Me.RepositoryItemLookUpEdit3.AutoHeight = False
        Me.RepositoryItemLookUpEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit3.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("strukturunit_name", " ")})
        Me.RepositoryItemLookUpEdit3.Name = "RepositoryItemLookUpEdit3"
        Me.RepositoryItemLookUpEdit3.NullText = "-- PILIH --"
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Ref. ID"
        Me.GridColumn15.FieldName = "ref_id"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.ReadOnly = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 8
        Me.GridColumn15.Width = 100
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Ref. Line"
        Me.GridColumn16.FieldName = "ref_line"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.ReadOnly = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 9
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Ref.BudgetLn"
        Me.GridColumn17.FieldName = "ref_budgetline"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.ReadOnly = True
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "region_id"
        Me.GridColumn18.FieldName = "region_id"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.ReadOnly = True
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "branch_id"
        Me.GridColumn19.FieldName = "branch_id"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.ReadOnly = True
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Budget ID"
        Me.GridColumn20.FieldName = "budget_id"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.ReadOnly = True
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Budget Name"
        Me.GridColumn21.FieldName = "budget_name"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.ReadOnly = True
        Me.GridColumn21.Width = 150
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Select Budget"
        Me.GridColumn22.ColumnEdit = Me.RepositoryItemLookUpEdit4
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemLookUpEdit4
        '
        Me.RepositoryItemLookUpEdit4.AutoHeight = False
        Me.RepositoryItemLookUpEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit4.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("budget_name", " ")})
        Me.RepositoryItemLookUpEdit4.Name = "RepositoryItemLookUpEdit4"
        Me.RepositoryItemLookUpEdit4.NullText = "-- PILIH --"
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Budget Detil ID"
        Me.GridColumn23.FieldName = "budgetdetil_id"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Width = 100
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Budget Detil Name"
        Me.GridColumn24.FieldName = "budgetdetil_name"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Width = 150
        '
        'GridColumn25
        '
        Me.GridColumn25.ColumnEdit = Me.RepositoryItemLookUpEdit5
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemLookUpEdit5
        '
        Me.RepositoryItemLookUpEdit5.AutoHeight = False
        Me.RepositoryItemLookUpEdit5.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit5.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("budgetdetil_name", " ")})
        Me.RepositoryItemLookUpEdit5.Name = "RepositoryItemLookUpEdit5"
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("acc_name", " ")})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.NullText = "-- PILIH --"
        '
        'pnlJurnalFooter
        '
        Me.pnlJurnalFooter.Controls.Add(Me.btnAddCipAsset)
        Me.pnlJurnalFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlJurnalFooter.Location = New System.Drawing.Point(0, 123)
        Me.pnlJurnalFooter.Name = "pnlJurnalFooter"
        Me.pnlJurnalFooter.Size = New System.Drawing.Size(738, 37)
        Me.pnlJurnalFooter.TabIndex = 3
        '
        'btnAddCipAsset
        '
        Me.btnAddCipAsset.Location = New System.Drawing.Point(5, 6)
        Me.btnAddCipAsset.Name = "btnAddCipAsset"
        Me.btnAddCipAsset.Size = New System.Drawing.Size(100, 23)
        Me.btnAddCipAsset.TabIndex = 0
        Me.btnAddCipAsset.Text = "ADD CIP - ASSET"
        '
        'ftabJurnalReference
        '
        Me.ftabJurnalReference.Controls.Add(Me.GCJurnalReference)
        Me.ftabJurnalReference.Name = "ftabJurnalReference"
        Me.ftabJurnalReference.PageVisible = False
        Me.ftabJurnalReference.Size = New System.Drawing.Size(738, 160)
        Me.ftabJurnalReference.Text = "Reference"
        '
        'GCJurnalReference
        '
        Me.GCJurnalReference.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCJurnalReference.Location = New System.Drawing.Point(0, 0)
        Me.GCJurnalReference.MainView = Me.GVJurnalReference
        Me.GCJurnalReference.Name = "GCJurnalReference"
        Me.GCJurnalReference.Size = New System.Drawing.Size(738, 160)
        Me.GCJurnalReference.TabIndex = 1
        Me.GCJurnalReference.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVJurnalReference})
        '
        'GVJurnalReference
        '
        Me.GVJurnalReference.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colJurnalReference_Id, Me.colJurnal_Id_Ref, Me.colJurnal_Id_RefLine, Me.colReferenceType})
        Me.GVJurnalReference.GridControl = Me.GCJurnalReference
        Me.GVJurnalReference.Name = "GVJurnalReference"
        Me.GVJurnalReference.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVJurnalReference.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVJurnalReference.OptionsBehavior.Editable = False
        Me.GVJurnalReference.OptionsBehavior.ReadOnly = True
        Me.GVJurnalReference.OptionsSelection.MultiSelect = True
        Me.GVJurnalReference.OptionsView.ColumnAutoWidth = False
        Me.GVJurnalReference.OptionsView.ShowGroupPanel = False
        '
        'colJurnalReference_Id
        '
        Me.colJurnalReference_Id.Caption = "Jurnal ID"
        Me.colJurnalReference_Id.FieldName = "jurnal_id"
        Me.colJurnalReference_Id.Name = "colJurnalReference_Id"
        Me.colJurnalReference_Id.Visible = True
        Me.colJurnalReference_Id.VisibleIndex = 0
        '
        'colJurnal_Id_Ref
        '
        Me.colJurnal_Id_Ref.Caption = "Ref."
        Me.colJurnal_Id_Ref.FieldName = "jurnal_id_ref"
        Me.colJurnal_Id_Ref.Name = "colJurnal_Id_Ref"
        Me.colJurnal_Id_Ref.Visible = True
        Me.colJurnal_Id_Ref.VisibleIndex = 1
        '
        'colJurnal_Id_RefLine
        '
        Me.colJurnal_Id_RefLine.Caption = "Ref. Line"
        Me.colJurnal_Id_RefLine.FieldName = "jurnal_id_refline"
        Me.colJurnal_Id_RefLine.Name = "colJurnal_Id_RefLine"
        Me.colJurnal_Id_RefLine.Visible = True
        Me.colJurnal_Id_RefLine.VisibleIndex = 2
        '
        'colReferenceType
        '
        Me.colReferenceType.Caption = "referencetype"
        Me.colReferenceType.FieldName = "referencetype"
        Me.colReferenceType.Name = "colReferenceType"
        Me.colReferenceType.Visible = True
        Me.colReferenceType.VisibleIndex = 3
        '
        'ftabResponse
        '
        Me.ftabResponse.Controls.Add(Me.GCJurnalResponse)
        Me.ftabResponse.Name = "ftabResponse"
        Me.ftabResponse.PageVisible = False
        Me.ftabResponse.Size = New System.Drawing.Size(738, 160)
        Me.ftabResponse.Text = "Response"
        '
        'GCJurnalResponse
        '
        Me.GCJurnalResponse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCJurnalResponse.Location = New System.Drawing.Point(0, 0)
        Me.GCJurnalResponse.MainView = Me.GVJurnalResponse
        Me.GCJurnalResponse.Name = "GCJurnalResponse"
        Me.GCJurnalResponse.Size = New System.Drawing.Size(738, 160)
        Me.GCJurnalResponse.TabIndex = 2
        Me.GCJurnalResponse.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVJurnalResponse})
        '
        'GVJurnalResponse
        '
        Me.GVJurnalResponse.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colJurnalResponse_Id, Me.colJurnalResponse_Line, Me.colJurnal_descr, Me.colCurrency_Name, Me.colJurnalDetilResponse_ForeignRate, Me.colJurnalDetilResponse_Idr, Me.colJurnalDetilResponse_Foreign, Me.colStrukturunit_Name, Me.colRekananResponse_Name, Me.colChannelRepsonse_Id, Me.colBook_dt})
        Me.GVJurnalResponse.GridControl = Me.GCJurnalResponse
        Me.GVJurnalResponse.Name = "GVJurnalResponse"
        Me.GVJurnalResponse.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVJurnalResponse.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVJurnalResponse.OptionsBehavior.Editable = False
        Me.GVJurnalResponse.OptionsBehavior.ReadOnly = True
        Me.GVJurnalResponse.OptionsSelection.MultiSelect = True
        Me.GVJurnalResponse.OptionsView.ColumnAutoWidth = False
        Me.GVJurnalResponse.OptionsView.ShowGroupPanel = False
        '
        'colJurnalResponse_Id
        '
        Me.colJurnalResponse_Id.Caption = "Ref."
        Me.colJurnalResponse_Id.FieldName = "ref"
        Me.colJurnalResponse_Id.Name = "colJurnalResponse_Id"
        Me.colJurnalResponse_Id.Visible = True
        Me.colJurnalResponse_Id.VisibleIndex = 0
        '
        'colJurnalResponse_Line
        '
        Me.colJurnalResponse_Line.Caption = "Line"
        Me.colJurnalResponse_Line.FieldName = "line"
        Me.colJurnalResponse_Line.Name = "colJurnalResponse_Line"
        Me.colJurnalResponse_Line.Visible = True
        Me.colJurnalResponse_Line.VisibleIndex = 1
        '
        'colJurnal_descr
        '
        Me.colJurnal_descr.Caption = "Descr."
        Me.colJurnal_descr.FieldName = "descr"
        Me.colJurnal_descr.Name = "colJurnal_descr"
        Me.colJurnal_descr.Visible = True
        Me.colJurnal_descr.VisibleIndex = 2
        '
        'colCurrency_Name
        '
        Me.colCurrency_Name.Caption = "Curr."
        Me.colCurrency_Name.FieldName = "currency_name"
        Me.colCurrency_Name.Name = "colCurrency_Name"
        Me.colCurrency_Name.Visible = True
        Me.colCurrency_Name.VisibleIndex = 3
        '
        'colJurnalDetilResponse_ForeignRate
        '
        Me.colJurnalDetilResponse_ForeignRate.Caption = "Rate"
        Me.colJurnalDetilResponse_ForeignRate.DisplayFormat.FormatString = "#,##0.00"
        Me.colJurnalDetilResponse_ForeignRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colJurnalDetilResponse_ForeignRate.FieldName = "jurnaldetil_foreignrate"
        Me.colJurnalDetilResponse_ForeignRate.Name = "colJurnalDetilResponse_ForeignRate"
        Me.colJurnalDetilResponse_ForeignRate.Visible = True
        Me.colJurnalDetilResponse_ForeignRate.VisibleIndex = 4
        '
        'colJurnalDetilResponse_Idr
        '
        Me.colJurnalDetilResponse_Idr.Caption = "Amount"
        Me.colJurnalDetilResponse_Idr.DisplayFormat.FormatString = "#,##0"
        Me.colJurnalDetilResponse_Idr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colJurnalDetilResponse_Idr.FieldName = "jurnaldetil_idr"
        Me.colJurnalDetilResponse_Idr.Name = "colJurnalDetilResponse_Idr"
        Me.colJurnalDetilResponse_Idr.Visible = True
        Me.colJurnalDetilResponse_Idr.VisibleIndex = 5
        '
        'colJurnalDetilResponse_Foreign
        '
        Me.colJurnalDetilResponse_Foreign.Caption = "Foreign"
        Me.colJurnalDetilResponse_Foreign.DisplayFormat.FormatString = "#,##0"
        Me.colJurnalDetilResponse_Foreign.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colJurnalDetilResponse_Foreign.FieldName = "jurnaldetil_foreign"
        Me.colJurnalDetilResponse_Foreign.Name = "colJurnalDetilResponse_Foreign"
        Me.colJurnalDetilResponse_Foreign.Visible = True
        Me.colJurnalDetilResponse_Foreign.VisibleIndex = 6
        '
        'colStrukturunit_Name
        '
        Me.colStrukturunit_Name.Caption = "Departement"
        Me.colStrukturunit_Name.FieldName = "strukturunit_name"
        Me.colStrukturunit_Name.Name = "colStrukturunit_Name"
        Me.colStrukturunit_Name.Visible = True
        Me.colStrukturunit_Name.VisibleIndex = 7
        '
        'colRekananResponse_Name
        '
        Me.colRekananResponse_Name.Caption = "Rekanan"
        Me.colRekananResponse_Name.FieldName = "rekanan_name"
        Me.colRekananResponse_Name.Name = "colRekananResponse_Name"
        Me.colRekananResponse_Name.Visible = True
        Me.colRekananResponse_Name.VisibleIndex = 8
        '
        'colChannelRepsonse_Id
        '
        Me.colChannelRepsonse_Id.Caption = "Channel"
        Me.colChannelRepsonse_Id.FieldName = "channel_id"
        Me.colChannelRepsonse_Id.Name = "colChannelRepsonse_Id"
        Me.colChannelRepsonse_Id.Visible = True
        Me.colChannelRepsonse_Id.VisibleIndex = 9
        '
        'colBook_dt
        '
        Me.colBook_dt.Caption = "Book Date"
        Me.colBook_dt.FieldName = "book_dt"
        Me.colBook_dt.Name = "colBook_dt"
        Me.colBook_dt.Visible = True
        Me.colBook_dt.VisibleIndex = 10
        '
        'pnlJurnalHeader
        '
        Me.pnlJurnalHeader.Controls.Add(Me.lueJurnalCurrency)
        Me.pnlJurnalHeader.Controls.Add(Me.txtJurnalDisc)
        Me.pnlJurnalHeader.Controls.Add(Me.lbJurnalDisc)
        Me.pnlJurnalHeader.Controls.Add(Me.lueJurnalPeriode)
        Me.pnlJurnalHeader.Controls.Add(Me.lbPeriod)
        Me.pnlJurnalHeader.Controls.Add(Me.txtJurnalPPN)
        Me.pnlJurnalHeader.Controls.Add(Me.LabelControl3)
        Me.pnlJurnalHeader.Controls.Add(Me.txtJurnalPPH)
        Me.pnlJurnalHeader.Controls.Add(Me.lbJurnalPPh)
        Me.pnlJurnalHeader.Controls.Add(Me.dtJurnalBookDate)
        Me.pnlJurnalHeader.Controls.Add(Me.lbBookDate)
        Me.pnlJurnalHeader.Controls.Add(Me.txtJurnalAmountIDR)
        Me.pnlJurnalHeader.Controls.Add(Me.lbAmountIDR)
        Me.pnlJurnalHeader.Controls.Add(Me.txtJurnalAmountForeign)
        Me.pnlJurnalHeader.Controls.Add(Me.lbAmount)
        Me.pnlJurnalHeader.Controls.Add(Me.txtJurnalRate)
        Me.pnlJurnalHeader.Controls.Add(Me.lbRate)
        Me.pnlJurnalHeader.Controls.Add(Me.lbCurrency)
        Me.pnlJurnalHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlJurnalHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlJurnalHeader.Name = "pnlJurnalHeader"
        Me.pnlJurnalHeader.Size = New System.Drawing.Size(743, 90)
        Me.pnlJurnalHeader.TabIndex = 1
        '
        'lueJurnalCurrency
        '
        Me.lueJurnalCurrency.Enabled = False
        Me.lueJurnalCurrency.Location = New System.Drawing.Point(56, 6)
        Me.lueJurnalCurrency.Name = "lueJurnalCurrency"
        Me.lueJurnalCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueJurnalCurrency.Properties.NullText = ""
        Me.lueJurnalCurrency.Size = New System.Drawing.Size(100, 20)
        Me.lueJurnalCurrency.TabIndex = 18
        '
        'txtJurnalDisc
        '
        Me.txtJurnalDisc.Location = New System.Drawing.Point(578, 6)
        Me.txtJurnalDisc.Name = "txtJurnalDisc"
        Me.txtJurnalDisc.Properties.Mask.EditMask = "n2"
        Me.txtJurnalDisc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtJurnalDisc.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtJurnalDisc.Properties.ReadOnly = True
        Me.txtJurnalDisc.Size = New System.Drawing.Size(100, 20)
        Me.txtJurnalDisc.TabIndex = 17
        '
        'lbJurnalDisc
        '
        Me.lbJurnalDisc.Location = New System.Drawing.Point(531, 9)
        Me.lbJurnalDisc.Name = "lbJurnalDisc"
        Me.lbJurnalDisc.Size = New System.Drawing.Size(19, 13)
        Me.lbJurnalDisc.TabIndex = 16
        Me.lbJurnalDisc.Text = "Disc"
        '
        'lueJurnalPeriode
        '
        Me.lueJurnalPeriode.Location = New System.Drawing.Point(419, 60)
        Me.lueJurnalPeriode.Name = "lueJurnalPeriode"
        Me.lueJurnalPeriode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueJurnalPeriode.Properties.NullText = ""
        Me.lueJurnalPeriode.Size = New System.Drawing.Size(131, 20)
        Me.lueJurnalPeriode.TabIndex = 15
        '
        'lbPeriod
        '
        Me.lbPeriod.Location = New System.Drawing.Point(372, 63)
        Me.lbPeriod.Name = "lbPeriod"
        Me.lbPeriod.Size = New System.Drawing.Size(36, 13)
        Me.lbPeriod.TabIndex = 14
        Me.lbPeriod.Text = "Periode"
        '
        'txtJurnalPPN
        '
        Me.txtJurnalPPN.Location = New System.Drawing.Point(419, 32)
        Me.txtJurnalPPN.Name = "txtJurnalPPN"
        Me.txtJurnalPPN.Properties.Mask.EditMask = "n2"
        Me.txtJurnalPPN.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtJurnalPPN.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtJurnalPPN.Properties.ReadOnly = True
        Me.txtJurnalPPN.Size = New System.Drawing.Size(100, 20)
        Me.txtJurnalPPN.TabIndex = 13
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(372, 35)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl3.TabIndex = 12
        Me.LabelControl3.Text = "PPN"
        '
        'txtJurnalPPH
        '
        Me.txtJurnalPPH.Location = New System.Drawing.Point(419, 6)
        Me.txtJurnalPPH.Name = "txtJurnalPPH"
        Me.txtJurnalPPH.Properties.Mask.EditMask = "n2"
        Me.txtJurnalPPH.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtJurnalPPH.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtJurnalPPH.Properties.ReadOnly = True
        Me.txtJurnalPPH.Size = New System.Drawing.Size(100, 20)
        Me.txtJurnalPPH.TabIndex = 11
        '
        'lbJurnalPPh
        '
        Me.lbJurnalPPh.Location = New System.Drawing.Point(372, 9)
        Me.lbJurnalPPh.Name = "lbJurnalPPh"
        Me.lbJurnalPPh.Size = New System.Drawing.Size(19, 13)
        Me.lbJurnalPPh.TabIndex = 10
        Me.lbJurnalPPh.Text = "PPH"
        '
        'dtJurnalBookDate
        '
        Me.dtJurnalBookDate.EditValue = Nothing
        Me.dtJurnalBookDate.Location = New System.Drawing.Point(257, 60)
        Me.dtJurnalBookDate.Name = "dtJurnalBookDate"
        Me.dtJurnalBookDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtJurnalBookDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtJurnalBookDate.Size = New System.Drawing.Size(100, 20)
        Me.dtJurnalBookDate.TabIndex = 9
        '
        'lbBookDate
        '
        Me.lbBookDate.Location = New System.Drawing.Point(181, 63)
        Me.lbBookDate.Name = "lbBookDate"
        Me.lbBookDate.Size = New System.Drawing.Size(49, 13)
        Me.lbBookDate.TabIndex = 8
        Me.lbBookDate.Text = "Book Date"
        '
        'txtJurnalAmountIDR
        '
        Me.txtJurnalAmountIDR.Location = New System.Drawing.Point(257, 32)
        Me.txtJurnalAmountIDR.Name = "txtJurnalAmountIDR"
        Me.txtJurnalAmountIDR.Properties.Mask.EditMask = "n0"
        Me.txtJurnalAmountIDR.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtJurnalAmountIDR.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtJurnalAmountIDR.Properties.ReadOnly = True
        Me.txtJurnalAmountIDR.Size = New System.Drawing.Size(100, 20)
        Me.txtJurnalAmountIDR.TabIndex = 7
        '
        'lbAmountIDR
        '
        Me.lbAmountIDR.Location = New System.Drawing.Point(181, 35)
        Me.lbAmountIDR.Name = "lbAmountIDR"
        Me.lbAmountIDR.Size = New System.Drawing.Size(66, 13)
        Me.lbAmountIDR.TabIndex = 6
        Me.lbAmountIDR.Text = "Amount (IDR)"
        '
        'txtJurnalAmountForeign
        '
        Me.txtJurnalAmountForeign.Location = New System.Drawing.Point(257, 6)
        Me.txtJurnalAmountForeign.Name = "txtJurnalAmountForeign"
        Me.txtJurnalAmountForeign.Properties.Mask.EditMask = "n2"
        Me.txtJurnalAmountForeign.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtJurnalAmountForeign.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtJurnalAmountForeign.Properties.ReadOnly = True
        Me.txtJurnalAmountForeign.Size = New System.Drawing.Size(100, 20)
        Me.txtJurnalAmountForeign.TabIndex = 5
        '
        'lbAmount
        '
        Me.lbAmount.Location = New System.Drawing.Point(181, 9)
        Me.lbAmount.Name = "lbAmount"
        Me.lbAmount.Size = New System.Drawing.Size(37, 13)
        Me.lbAmount.TabIndex = 4
        Me.lbAmount.Text = "Amount"
        '
        'txtJurnalRate
        '
        Me.txtJurnalRate.Location = New System.Drawing.Point(56, 32)
        Me.txtJurnalRate.Name = "txtJurnalRate"
        Me.txtJurnalRate.Properties.Mask.EditMask = "n2"
        Me.txtJurnalRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtJurnalRate.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtJurnalRate.Properties.ReadOnly = True
        Me.txtJurnalRate.Size = New System.Drawing.Size(100, 20)
        Me.txtJurnalRate.TabIndex = 2
        '
        'lbRate
        '
        Me.lbRate.Location = New System.Drawing.Point(6, 35)
        Me.lbRate.Name = "lbRate"
        Me.lbRate.Size = New System.Drawing.Size(23, 13)
        Me.lbRate.TabIndex = 1
        Me.lbRate.Text = "Rate"
        '
        'lbCurrency
        '
        Me.lbCurrency.Location = New System.Drawing.Point(6, 9)
        Me.lbCurrency.Name = "lbCurrency"
        Me.lbCurrency.Size = New System.Drawing.Size(44, 13)
        Me.lbCurrency.TabIndex = 0
        Me.lbCurrency.Text = "Currency"
        '
        'ftabDataDetil_Info
        '
        Me.ftabDataDetil_Info.Controls.Add(Me.chkAppAcc)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbAppAccDate)
        Me.ftabDataDetil_Info.Controls.Add(Me.txtAppAccDate)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbAppAccBy)
        Me.ftabDataDetil_Info.Controls.Add(Me.txtAppAccBy)
        Me.ftabDataDetil_Info.Controls.Add(Me.LabelControl2)
        Me.ftabDataDetil_Info.Controls.Add(Me.txtModifiedDate)
        Me.ftabDataDetil_Info.Controls.Add(Me.lblModifiedBy)
        Me.ftabDataDetil_Info.Controls.Add(Me.txtModifiedBy)
        Me.ftabDataDetil_Info.Controls.Add(Me.LabelControl1)
        Me.ftabDataDetil_Info.Controls.Add(Me.txtCreatedDate)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbCreatedBy)
        Me.ftabDataDetil_Info.Controls.Add(Me.txtCreatedBy)
        Me.ftabDataDetil_Info.Name = "ftabDataDetil_Info"
        Me.ftabDataDetil_Info.Size = New System.Drawing.Size(743, 275)
        Me.ftabDataDetil_Info.Text = "Info"
        '
        'chkAppAcc
        '
        Me.chkAppAcc.Enabled = False
        Me.chkAppAcc.Location = New System.Drawing.Point(96, 117)
        Me.chkAppAcc.Name = "chkAppAcc"
        Me.chkAppAcc.Properties.Caption = "Is App Acc"
        Me.chkAppAcc.Size = New System.Drawing.Size(75, 19)
        Me.chkAppAcc.TabIndex = 16
        '
        'lbAppAccDate
        '
        Me.lbAppAccDate.Location = New System.Drawing.Point(15, 171)
        Me.lbAppAccDate.Name = "lbAppAccDate"
        Me.lbAppAccDate.Size = New System.Drawing.Size(65, 13)
        Me.lbAppAccDate.TabIndex = 15
        Me.lbAppAccDate.Text = "App Acc Date"
        '
        'txtAppAccDate
        '
        Me.txtAppAccDate.Enabled = False
        Me.txtAppAccDate.Location = New System.Drawing.Point(98, 168)
        Me.txtAppAccDate.Name = "txtAppAccDate"
        Me.txtAppAccDate.Properties.ReadOnly = True
        Me.txtAppAccDate.Size = New System.Drawing.Size(182, 20)
        Me.txtAppAccDate.TabIndex = 14
        '
        'lbAppAccBy
        '
        Me.lbAppAccBy.Location = New System.Drawing.Point(15, 145)
        Me.lbAppAccBy.Name = "lbAppAccBy"
        Me.lbAppAccBy.Size = New System.Drawing.Size(54, 13)
        Me.lbAppAccBy.TabIndex = 13
        Me.lbAppAccBy.Text = "App Acc By"
        '
        'txtAppAccBy
        '
        Me.txtAppAccBy.Enabled = False
        Me.txtAppAccBy.Location = New System.Drawing.Point(98, 142)
        Me.txtAppAccBy.Name = "txtAppAccBy"
        Me.txtAppAccBy.Properties.ReadOnly = True
        Me.txtAppAccBy.Size = New System.Drawing.Size(182, 20)
        Me.txtAppAccBy.TabIndex = 12
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(15, 95)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl2.TabIndex = 11
        Me.LabelControl2.Text = "Modified Date"
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.Enabled = False
        Me.txtModifiedDate.Location = New System.Drawing.Point(98, 92)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.Properties.ReadOnly = True
        Me.txtModifiedDate.Size = New System.Drawing.Size(182, 20)
        Me.txtModifiedDate.TabIndex = 10
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.Location = New System.Drawing.Point(15, 69)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Size = New System.Drawing.Size(55, 13)
        Me.lblModifiedBy.TabIndex = 9
        Me.lblModifiedBy.Text = "Modified By"
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.Enabled = False
        Me.txtModifiedBy.Location = New System.Drawing.Point(98, 66)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.Properties.ReadOnly = True
        Me.txtModifiedBy.Size = New System.Drawing.Size(182, 20)
        Me.txtModifiedBy.TabIndex = 8
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(15, 43)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl1.TabIndex = 7
        Me.LabelControl1.Text = "Created Date"
        '
        'txtCreatedDate
        '
        Me.txtCreatedDate.Enabled = False
        Me.txtCreatedDate.Location = New System.Drawing.Point(98, 40)
        Me.txtCreatedDate.Name = "txtCreatedDate"
        Me.txtCreatedDate.Properties.ReadOnly = True
        Me.txtCreatedDate.Size = New System.Drawing.Size(182, 20)
        Me.txtCreatedDate.TabIndex = 6
        '
        'lbCreatedBy
        '
        Me.lbCreatedBy.Location = New System.Drawing.Point(15, 17)
        Me.lbCreatedBy.Name = "lbCreatedBy"
        Me.lbCreatedBy.Size = New System.Drawing.Size(54, 13)
        Me.lbCreatedBy.TabIndex = 5
        Me.lbCreatedBy.Text = "Created By"
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.Enabled = False
        Me.txtCreatedBy.Location = New System.Drawing.Point(98, 14)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.Properties.ReadOnly = True
        Me.txtCreatedBy.Size = New System.Drawing.Size(182, 20)
        Me.txtCreatedBy.TabIndex = 4
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.Controls.Add(Me.lueDept)
        Me.PnlDataMaster.Controls.Add(Me.lbDepartement)
        Me.PnlDataMaster.Controls.Add(Me.txtNotes)
        Me.PnlDataMaster.Controls.Add(Me.lbNote)
        Me.PnlDataMaster.Controls.Add(Me.txtLocation)
        Me.PnlDataMaster.Controls.Add(Me.lbLocation)
        Me.PnlDataMaster.Controls.Add(Me.lbReceiveType)
        Me.PnlDataMaster.Controls.Add(Me.txtRvType)
        Me.PnlDataMaster.Controls.Add(Me.lbReceivedNo)
        Me.PnlDataMaster.Controls.Add(Me.txtRvID)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(0, 0)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(748, 197)
        Me.PnlDataMaster.TabIndex = 0
        '
        'lueDept
        '
        Me.lueDept.Location = New System.Drawing.Point(88, 166)
        Me.lueDept.Name = "lueDept"
        Me.lueDept.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lueDept.Properties.NullText = ""
        Me.lueDept.Size = New System.Drawing.Size(328, 20)
        Me.lueDept.TabIndex = 9
        '
        'lbDepartement
        '
        Me.lbDepartement.Location = New System.Drawing.Point(5, 169)
        Me.lbDepartement.Name = "lbDepartement"
        Me.lbDepartement.Size = New System.Drawing.Size(63, 13)
        Me.lbDepartement.TabIndex = 8
        Me.lbDepartement.Text = "Departement"
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(88, 82)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(328, 78)
        Me.txtNotes.TabIndex = 7
        '
        'lbNote
        '
        Me.lbNote.Location = New System.Drawing.Point(5, 85)
        Me.lbNote.Name = "lbNote"
        Me.lbNote.Size = New System.Drawing.Size(28, 13)
        Me.lbNote.TabIndex = 6
        Me.lbNote.Text = "Notes"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(88, 56)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(328, 20)
        Me.txtLocation.TabIndex = 5
        '
        'lbLocation
        '
        Me.lbLocation.Location = New System.Drawing.Point(5, 59)
        Me.lbLocation.Name = "lbLocation"
        Me.lbLocation.Size = New System.Drawing.Size(40, 13)
        Me.lbLocation.TabIndex = 4
        Me.lbLocation.Text = "Location"
        '
        'lbReceiveType
        '
        Me.lbReceiveType.Location = New System.Drawing.Point(5, 34)
        Me.lbReceiveType.Name = "lbReceiveType"
        Me.lbReceiveType.Size = New System.Drawing.Size(65, 13)
        Me.lbReceiveType.TabIndex = 3
        Me.lbReceiveType.Text = "Receive Type"
        '
        'txtRvType
        '
        Me.txtRvType.Location = New System.Drawing.Point(88, 31)
        Me.txtRvType.Name = "txtRvType"
        Me.txtRvType.Properties.ReadOnly = True
        Me.txtRvType.Size = New System.Drawing.Size(100, 20)
        Me.txtRvType.TabIndex = 2
        '
        'lbReceivedNo
        '
        Me.lbReceivedNo.Location = New System.Drawing.Point(5, 8)
        Me.lbReceivedNo.Name = "lbReceivedNo"
        Me.lbReceivedNo.Size = New System.Drawing.Size(58, 13)
        Me.lbReceivedNo.TabIndex = 1
        Me.lbReceivedNo.Text = "Receive No."
        '
        'txtRvID
        '
        Me.txtRvID.Location = New System.Drawing.Point(88, 5)
        Me.txtRvID.Name = "txtRvID"
        Me.txtRvID.Properties.ReadOnly = True
        Me.txtRvID.Size = New System.Drawing.Size(100, 20)
        Me.txtRvID.TabIndex = 0
        '
        'PopupMenu1
        '
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'uiTrnPenerimaanBarangListRV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiTrnPenerimaanBarangListRV"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        CType(Me.ftabMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        CType(Me.GCRVRakitan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRVRakitan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PnlDfSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        CType(Me.lueSrchDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seRecord.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSrchRvID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSrchRvID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSrchRekananID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSrchDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSrchRekanan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueSrchChannelID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSrchChannel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_Data.ResumeLayout(False)
        CType(Me.ftabDataDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Detil.ResumeLayout(False)
        CType(Me.GCRVDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuRVRakitan.ResumeLayout(False)
        CType(Me.GVRVDetil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryAssetTipe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryAssetCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCatDepre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTipe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryBrandId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryAssetType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Jurnal.ResumeLayout(False)
        CType(Me.ftabJurnal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabJurnal.ResumeLayout(False)
        Me.ftabJurnalDebit.ResumeLayout(False)
        CType(Me.GCJurnalDebit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msJurnalDebit.ResumeLayout(False)
        CType(Me.GVJurnalDebit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryBtnRekanan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryBtnAccId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCurrencyId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryStrukturunit_Id, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryBudget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryBudgetDetil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryAccId, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabJurnalKredit.ResumeLayout(False)
        CType(Me.GCJurnalKredit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.msJurnalKredit.ResumeLayout(False)
        CType(Me.GVJurnalKredit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryRekanan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlJurnalFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlJurnalFooter.ResumeLayout(False)
        Me.ftabJurnalReference.ResumeLayout(False)
        CType(Me.GCJurnalReference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVJurnalReference, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabResponse.ResumeLayout(False)
        CType(Me.GCJurnalResponse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVJurnalResponse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlJurnalHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlJurnalHeader.ResumeLayout(False)
        Me.pnlJurnalHeader.PerformLayout()
        CType(Me.lueJurnalCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJurnalDisc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueJurnalPeriode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJurnalPPN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJurnalPPH.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtJurnalBookDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtJurnalBookDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJurnalAmountIDR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJurnalAmountForeign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJurnalRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Info.ResumeLayout(False)
        Me.ftabDataDetil_Info.PerformLayout()
        CType(Me.chkAppAcc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAppAccDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAppAccBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModifiedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModifiedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreatedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PnlDataMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        CType(Me.lueDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRvType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRvID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ftabMain As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents ftabMain_List As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ftabMain_Data As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PnlDfSearch As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCRVRakitan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRVRakitan As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PnlDataMaster As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lbNote As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtLocation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbLocation As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbReceiveType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRvType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbReceivedNo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRvID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNotes As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lueDept As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbDepartement As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ftabDataDetil As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents ftabDataDetil_Detil As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ftabDataDetil_Jurnal As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ftabDataDetil_Info As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCRVDetil As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRVDetil As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlJurnalHeader As DevExpress.XtraEditors.PanelControl
    Friend WithEvents ftabJurnal As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents ftabJurnalDebit As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ftabJurnalKredit As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ftabJurnalReference As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents ftabResponse As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCJurnalDebit As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVJurnalDebit As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCJurnalReference As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVJurnalReference As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCJurnalResponse As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVJurnalResponse As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkSrchDept As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSrchRekanan As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lueSrchChannelID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents chkSrchChannel As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnRekanan As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtSrchRekananID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkSrchRvID As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtSrchRvID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtModifiedDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblModifiedBy As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtModifiedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCreatedDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbCreatedBy As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCreatedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbAppAccDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAppAccDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbAppAccBy As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAppAccBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkAppAcc As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents seRecord As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lbRecord As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colLine As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPrint As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNotPrinted As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAssetType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAssetCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBrand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSerialNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBarcodeType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmountIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotalAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotalAmountIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents pnlJurnalFooter As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAddCipAsset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtJurnalRate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCurrency As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtJurnalAmountForeign As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbAmount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtJurnalAmountIDR As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbAmountIDR As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtJurnalBookDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbBookDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtJurnalDisc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbJurnalDisc As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lueJurnalPeriode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbPeriod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtJurnalPPN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtJurnalPPH As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbJurnalPPh As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lueJurnalCurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents RepositoryAssetType As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryAssetTipe As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryAssetCategory As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemCategory As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemTipe As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryBrandId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colJurnal_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnaldetil_line As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnaldetil_dk As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnaldetil_descr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRekanan_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRekanan_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSelectRekanan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryBtnRekanan As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents colAcc_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryAccId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colCurrency_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryCurrencyId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colJurnaldetil_Foreign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnaldetil_Foreignrate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnaldetil_Idr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChannel_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStrukturunit_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryStrukturunit_Id As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colRef_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cRef_line As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRef_BudgetLine As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRegion_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBranch_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBudget_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBudget_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSelect_Budget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryBudget As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colBudgetdetil_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBudgetdetil_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSelect_Budget_Detil As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryBudgetDetil As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GCJurnalKredit As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVJurnalKredit As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryRekanan As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colJurnalReference_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnal_Id_Ref As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnal_Id_RefLine As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReferenceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalResponse_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalResponse_Line As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnal_descr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrency_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilResponse_ForeignRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilResponse_Idr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilResponse_Foreign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStrukturunit_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRekananResponse_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChannelRepsonse_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBook_dt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_appacc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrder_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarangBudget_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarangRekanan_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmployee_id_owner As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarangStrukturunit_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_qtyitem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_qtyrealization As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrder_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_statusrealization As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_location As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_notes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_nosuratjalan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarangChannel_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_isdisabled As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_createby As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_createdt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_modifiedby As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_modifieddt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_appuser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_appuser_by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_appuser_dt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_appspv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_appspv_by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_appspv_dt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_appacc_by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_appacc_dt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_foreign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarangCurrency_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_foreignrate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_idrreal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_pph As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_ppn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_disc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarang_cetakbpb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTerimabarangRekanan_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmployee_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lueSrchDept As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents colSelectAccId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryBtnAccId As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents msJurnalDebit As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colRefID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRefDetil_Line As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCatDepre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryCatDepre As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colIsParent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MenuRVRakitan As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddParentManual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddParentByRV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddChild As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccPendLainnya As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msJurnalKredit As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AccPendapatanLainnya As System.Windows.Forms.ToolStripMenuItem

End Class
