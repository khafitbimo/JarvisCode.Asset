<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnPenerimaanBarang
    Inherits ASSET.uiBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnPenerimaanBarang))
        Me.ftabMain = New FlatTabControl.FlatTabControl()
        Me.ftabMain_List = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.obj_ProgressBar_backGroundWorker = New System.Windows.Forms.ProgressBar()
        Me.PnlDfMain = New System.Windows.Forms.Panel()
        Me.DgvTrnPenerimaanbarang = New System.Windows.Forms.DataGridView()
        Me.PnlDfFooter = New System.Windows.Forms.Panel()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.obj_top = New System.Windows.Forms.NumericUpDown()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.PnlDfSearch = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.obj_Rekanan_id_search = New System.Windows.Forms.TextBox()
        Me.btn_Rekanan = New System.Windows.Forms.Button()
        Me.obj_RvID_search = New System.Windows.Forms.TextBox()
        Me.chk_RvID_search = New System.Windows.Forms.CheckBox()
        Me.obj_orderID_search = New System.Windows.Forms.TextBox()
        Me.chk_orderID_search = New System.Windows.Forms.CheckBox()
        Me.cmb_appuser = New System.Windows.Forms.ComboBox()
        Me.chk_User_search = New System.Windows.Forms.CheckBox()
        Me.obj_Strukturunit_id_pemilik_search = New System.Windows.Forms.ComboBox()
        Me.chk_Strukturunit_id_pemilik_search = New System.Windows.Forms.CheckBox()
        Me.chk_Rekanan_id_search = New System.Windows.Forms.CheckBox()
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox()
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox()
        Me.ftabMain_Data = New System.Windows.Forms.TabPage()
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl()
        Me.ftabDataDetil_Detil = New System.Windows.Forms.TabPage()
        Me.TLTrnPenerimaanBarangDetil = New DevExpress.XtraTreeList.TreeList()
        Me.select_detail = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.btnBrowseDetil = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.cterimabarang_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_line = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarang_barcode = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cprint_barcode = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryItemButtonPrint = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.cprint_barcodekain = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_desc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_type = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_parentline = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarang_parentbarcode = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_nonfixasset = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_date = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cassettype_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryAssetType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cassetcategory_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryAssetCategory = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cterimabarangdetil_golfiskal = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryCatDepre = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.citem_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryItemId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.citemcategory_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryItemCategoryId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.citemtype_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cbrand_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryBrandId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cterimabarangdetil_serial_no = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_product_no = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_model = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cmaterial_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryMaterialId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ccolour_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryColourId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.csize_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositorySizeId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.csex_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositorySexId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.croom_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryRoomId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cterimabarangdetil_rack = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cshow_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryShowId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cShow_id_cont = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryShowIdCont = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cterimabarangdetil_eps = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_qty = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cunit_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryUnitId = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ccurrency_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryCurrency = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cterimabarangdetil_foreign = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_foreignrate = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_idrreal = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_pphpercent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_ppnpercent = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_disc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_pphforeign = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_pphidrreal = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_ppnforeign = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_ppnidrreal = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_totalforeign = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_totalidrreal = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cterimabarangdetil_depre_enddt = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cemployee_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cstrukturunit_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cwriteoff_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cwriteoff_dt = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.corder_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.corderdetil_line = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cbudget_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cbudgetdetil_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cacc_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cchannel_id = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ccreate_by = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ccreate_dt = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cmodified_by = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cmodified_dt = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnPrintAllBarcode = New System.Windows.Forms.Button()
        Me.Btn_Add = New System.Windows.Forms.Button()
        Me.ftabDataDetil_Info = New System.Windows.Forms.TabPage()
        Me.obj_Strukturunit_id = New System.Windows.Forms.TextBox()
        Me.lbl_Strukturunit_id = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_isdisabled = New System.Windows.Forms.CheckBox()
        Me.obj_Terimabarang_modifiedby = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_modifieddt = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_modifieddt = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_modifiedby = New System.Windows.Forms.Label()
        Me.lbl_Terimabarang_createdt = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_createdt = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_createby = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_createby = New System.Windows.Forms.TextBox()
        Me.obj_Terimabarang_cetakbpb = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_cetakbpb = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_appuser_dt = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_appspv_dt = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_appspv_dt = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_appspv_by = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_appspv_by = New System.Windows.Forms.TextBox()
        Me.obj_Terimabarang_appspv = New System.Windows.Forms.CheckBox()
        Me.lbl_Terimabarang_appuser_dt = New System.Windows.Forms.Label()
        Me.lbl_Terimabarang_appuser_by = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_appuser_by = New System.Windows.Forms.TextBox()
        Me.obj_Terimabarang_appuser = New System.Windows.Forms.CheckBox()
        Me.obj_Terimabarang_appacc_dt = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_appacc_dt = New System.Windows.Forms.Label()
        Me.lbl_Terimabarang_appacc_by = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_appacc_by = New System.Windows.Forms.TextBox()
        Me.obj_Terimabarang_appacc = New System.Windows.Forms.CheckBox()
        Me.ftabDataDetil_jurnal = New System.Windows.Forms.TabPage()
        Me.pnlclose3 = New System.Windows.Forms.Panel()
        Me.FtabJurnal = New FlatTabControl.FlatTabControl()
        Me.ftabDataDetil_Pembayaran = New System.Windows.Forms.TabPage()
        Me.DgvTrnJurnaldetil_Pembayaran = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.DgvTrnJurnaldetil = New System.Windows.Forms.DataGridView()
        Me.ftabDataDetil_Reference = New System.Windows.Forms.TabPage()
        Me.DgvTrnJurnalreference = New System.Windows.Forms.DataGridView()
        Me.ftabDataDetil_Response = New System.Windows.Forms.TabPage()
        Me.DgvTrnJurnalresponse = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlClose2 = New System.Windows.Forms.Panel()
        Me.obj_Jurnal_bookdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Jurnal_bookdate = New System.Windows.Forms.Label()
        Me.obj_Currency_id = New System.Windows.Forms.ComboBox()
        Me.obj_Terimabarang_ppn = New System.Windows.Forms.TextBox()
        Me.obj_Terimabarang_pph = New System.Windows.Forms.TextBox()
        Me.obj_Terimabarang_disc = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_ppn = New System.Windows.Forms.Label()
        Me.lbl_Terimabarang_disc = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_foreign = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_pph = New System.Windows.Forms.Label()
        Me.lbl_Terimabarang_foreign = New System.Windows.Forms.Label()
        Me.lbl_Terimabarang_idrreal = New System.Windows.Forms.Label()
        Me.lbl_Currency_id = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_idrreal = New System.Windows.Forms.TextBox()
        Me.obj_Terimabarang_foreignrate = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_foreignrate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_periode = New System.Windows.Forms.ComboBox()
        Me.PnlDataMaster = New System.Windows.Forms.Panel()
        Me.obj_terimabarang_tglsuratjalan = New DevExpress.XtraEditors.DateEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.obj_strukturunit_name = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.obj_Employee_id_owner = New System.Windows.Forms.ComboBox()
        Me.obj_Terimabarang_status = New System.Windows.Forms.ComboBox()
        Me.obj_Terimabarang_statusrealization = New System.Windows.Forms.ComboBox()
        Me.obj_Budget_id = New System.Windows.Forms.ComboBox()
        Me.obj_Rekanan_id = New System.Windows.Forms.ComboBox()
        Me.btn_order = New System.Windows.Forms.Button()
        Me.obj_Terimabarang_id = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_id = New System.Windows.Forms.Label()
        Me.lbl_Terimabarang_date = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_type = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_type = New System.Windows.Forms.Label()
        Me.obj_Order_id = New System.Windows.Forms.TextBox()
        Me.lbl_Order_id = New System.Windows.Forms.Label()
        Me.lbl_Budget_id = New System.Windows.Forms.Label()
        Me.lbl_Rekanan_id = New System.Windows.Forms.Label()
        Me.lbl_Employee_id_owner = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_qtyitem = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_qtyitem = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_qtyrealization = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_qtyrealization = New System.Windows.Forms.Label()
        Me.obj_Order_qty = New System.Windows.Forms.TextBox()
        Me.lbl_Order_qty = New System.Windows.Forms.Label()
        Me.lbl_Terimabarang_status = New System.Windows.Forms.Label()
        Me.lbl_Terimabarang_statusrealization = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_location = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_location = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_notes = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_notes = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_nosuratjalan = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarang_nosuratjalan = New System.Windows.Forms.Label()
        Me.obj_Channel_id = New System.Windows.Forms.TextBox()
        Me.lbl_Channel_id = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_date = New System.Windows.Forms.MaskedTextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.pnlDetil = New System.Windows.Forms.Panel()
        Me.FlatTabControl1 = New FlatTabControl.FlatTabControl()
        Me.TabDetail = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.obj_Terimabarangdetil_golfiskal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCaptureCancel = New System.Windows.Forms.Button()
        Me.btnCapture = New System.Windows.Forms.Button()
        Me.PnlFoto = New System.Windows.Forms.Panel()
        Me.obj_photo = New System.Windows.Forms.PictureBox()
        Me.VideoCapture = New VidGrab.VideoGrabber()
        Me.obj_budgetdetil_name = New System.Windows.Forms.TextBox()
        Me.btnItemCategorySelect = New System.Windows.Forms.Button()
        Me.btnItemSelect = New System.Windows.Forms.Button()
        Me.btnCategory = New System.Windows.Forms.Button()
        Me.btnSerial = New System.Windows.Forms.Button()
        Me.obj_budget_name = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblQtyTotal = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_depre_enddt = New System.Windows.Forms.DateTimePicker()
        Me.obj_Terimabarangdetil_qtytotal = New System.Windows.Forms.TextBox()
        Me.lbl_Acc_id = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_product_no = New System.Windows.Forms.ComboBox()
        Me.obj_Acc_id = New System.Windows.Forms.ComboBox()
        Me.obj_Terimabarangdetil_qtydetail = New System.Windows.Forms.TextBox()
        Me.obj_Orderdetil_line = New System.Windows.Forms.TextBox()
        Me.btn_Parent = New System.Windows.Forms.Button()
        Me.lbl_Orderdetil_line = New System.Windows.Forms.Label()
        Me.lblQtyDetail = New System.Windows.Forms.Label()
        Me.obj_Orderdetil_id = New System.Windows.Forms.TextBox()
        Me.obj_Terimabarangdetil_line = New System.Windows.Forms.TextBox()
        Me.lbl_Orderdetil_id = New System.Windows.Forms.Label()
        Me.obj_Itemtype_id = New System.Windows.Forms.TextBox()
        Me.obj_Terimabarang_parentbarcode = New System.Windows.Forms.TextBox()
        Me.lbl_Unit_id = New System.Windows.Forms.Label()
        Me.obj_Terimabarang_barcode = New System.Windows.Forms.TextBox()
        Me.obj_Unit_id = New System.Windows.Forms.ComboBox()
        Me.obj_Terimabarangdetil_eps = New System.Windows.Forms.TextBox()
        Me.lbl_Asset_barcode = New System.Windows.Forms.Label()
        Me.lbl_Terimabarangdetil_eps = New System.Windows.Forms.Label()
        Me.lbl_Terimabarangdetil_qty = New System.Windows.Forms.Label()
        Me.lbl_Show_id_cont = New System.Windows.Forms.Label()
        Me.lbl_Asset_barcodeinduk = New System.Windows.Forms.Label()
        Me.obj_Show_id_cont = New System.Windows.Forms.ComboBox()
        Me.obj_Terimabarangdetil_qty = New System.Windows.Forms.TextBox()
        Me.lbl_Show_id = New System.Windows.Forms.Label()
        Me.obj_Show_id = New System.Windows.Forms.ComboBox()
        Me.obj_Terimabarangdetil_desc = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_depre_enddt = New System.Windows.Forms.Label()
        Me.lbl_Terimabarangdetil_rack = New System.Windows.Forms.Label()
        Me.lbl_Terimabarangdetil_desc = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_rack = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_lineparent = New System.Windows.Forms.Label()
        Me.lbl_Room_id = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_parentline = New System.Windows.Forms.TextBox()
        Me.obj_Room_id = New System.Windows.Forms.ComboBox()
        Me.lbl_Terimabarangdetil_line = New System.Windows.Forms.Label()
        Me.lbl_Sex_id = New System.Windows.Forms.Label()
        Me.obj_asset_terimabarangdetil_id = New System.Windows.Forms.TextBox()
        Me.obj_Sex_id = New System.Windows.Forms.ComboBox()
        Me.lbl_Terimabarangdetil_id = New System.Windows.Forms.Label()
        Me.lbl_Size_id = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_nonfixasset = New System.Windows.Forms.CheckBox()
        Me.obj_Size_id = New System.Windows.Forms.ComboBox()
        Me.lbl_Terimabarangdetil_product_no = New System.Windows.Forms.Label()
        Me.lbl_Colour_id = New System.Windows.Forms.Label()
        Me.obj_Assettype_id = New System.Windows.Forms.ComboBox()
        Me.obj_Colour_id = New System.Windows.Forms.ComboBox()
        Me.lbl_Tipeasset_id = New System.Windows.Forms.Label()
        Me.lbl_Material_id = New System.Windows.Forms.Label()
        Me.lbl_Kategoriasset_id = New System.Windows.Forms.Label()
        Me.obj_Material_id = New System.Windows.Forms.ComboBox()
        Me.obj_Assetcategory_id = New System.Windows.Forms.TextBox()
        Me.obj_Terimabarangdetil_model = New System.Windows.Forms.TextBox()
        Me.lbl_Item_id = New System.Windows.Forms.Label()
        Me.lbl_Terimabarangdetil_model = New System.Windows.Forms.Label()
        Me.obj_Item_id = New System.Windows.Forms.ComboBox()
        Me.obj_Terimabarangdetil_serial_no = New System.Windows.Forms.TextBox()
        Me.obj_Itemcategory_id = New System.Windows.Forms.ComboBox()
        Me.lbl_Terimabarangdetil_serial_no = New System.Windows.Forms.Label()
        Me.lbl_Itemcategory_id = New System.Windows.Forms.Label()
        Me.lbl_brand_id = New System.Windows.Forms.Label()
        Me.lbl_Itemtype_id = New System.Windows.Forms.Label()
        Me.obj_Brand_id = New System.Windows.Forms.ComboBox()
        Me.TabAccounting = New System.Windows.Forms.TabPage()
        Me.Panel_bawah = New System.Windows.Forms.Panel()
        Me.lbl_Currency_iddetil = New System.Windows.Forms.Label()
        Me.obj_Currency_iddetil = New System.Windows.Forms.ComboBox()
        Me.obj_Terimabarangdetil_totalidrreal = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_totalidrreal = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_totalforeign = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_totalforeign = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_ppnidrreal = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_ppnidrreal = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_ppnforeign = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_ppnforeign = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_pphidrreal = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_pphidrreal = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_pphforeign = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_pphforeign = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_disc = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_disc = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_ppnpercent = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_ppnpercent = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_pphpercent = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_pphpercent = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_idrreal = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_idrreal = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_foreignrate = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_foreignrate = New System.Windows.Forms.Label()
        Me.obj_Terimabarangdetil_foreign = New System.Windows.Forms.TextBox()
        Me.lbl_Terimabarangdetil_foreign = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvTrnPenerimaanbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfFooter.SuspendLayout()
        CType(Me.obj_top, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Detil.SuspendLayout()
        CType(Me.TLTrnPenerimaanBarangDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnBrowseDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryAssetType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryAssetCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCatDepre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCategoryId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryBrandId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryMaterialId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryColourId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySizeId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySexId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryRoomId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryShowId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryShowIdCont, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryUnitId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.ftabDataDetil_Info.SuspendLayout()
        Me.ftabDataDetil_jurnal.SuspendLayout()
        Me.FtabJurnal.SuspendLayout()
        Me.ftabDataDetil_Pembayaran.SuspendLayout()
        CType(Me.DgvTrnJurnaldetil_Pembayaran, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.DgvTrnJurnaldetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Reference.SuspendLayout()
        CType(Me.DgvTrnJurnalreference, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabDataDetil_Response.SuspendLayout()
        CType(Me.DgvTrnJurnalresponse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        CType(Me.obj_terimabarang_tglsuratjalan.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_terimabarang_tglsuratjalan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetil.SuspendLayout()
        Me.FlatTabControl1.SuspendLayout()
        Me.TabDetail.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PnlFoto.SuspendLayout()
        CType(Me.obj_photo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAccounting.SuspendLayout()
        Me.Panel_bawah.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(17, 51)
        Me.ftabMain.myBackColor = System.Drawing.Color.White
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 449)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.White
        Me.ftabMain_List.Controls.Add(Me.Panel1)
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_List.Controls.Add(Me.PnlDfFooter)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(739, 420)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Moccasin
        Me.Panel1.Controls.Add(Me.lblLoading)
        Me.Panel1.Controls.Add(Me.obj_ProgressBar_backGroundWorker)
        Me.Panel1.Location = New System.Drawing.Point(191, 198)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(360, 82)
        Me.Panel1.TabIndex = 5
        Me.Panel1.UseWaitCursor = True
        Me.Panel1.Visible = False
        '
        'lblLoading
        '
        Me.lblLoading.AutoSize = True
        Me.lblLoading.Location = New System.Drawing.Point(55, 41)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(147, 13)
        Me.lblLoading.TabIndex = 59
        Me.lblLoading.Text = "Please Wait... Loading data..."
        Me.lblLoading.UseWaitCursor = True
        '
        'obj_ProgressBar_backGroundWorker
        '
        Me.obj_ProgressBar_backGroundWorker.ForeColor = System.Drawing.Color.Magenta
        Me.obj_ProgressBar_backGroundWorker.Location = New System.Drawing.Point(59, 29)
        Me.obj_ProgressBar_backGroundWorker.Name = "obj_ProgressBar_backGroundWorker"
        Me.obj_ProgressBar_backGroundWorker.RightToLeftLayout = True
        Me.obj_ProgressBar_backGroundWorker.Size = New System.Drawing.Size(252, 12)
        Me.obj_ProgressBar_backGroundWorker.Step = 5
        Me.obj_ProgressBar_backGroundWorker.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.obj_ProgressBar_backGroundWorker.TabIndex = 58
        Me.obj_ProgressBar_backGroundWorker.UseWaitCursor = True
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvTrnPenerimaanbarang)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 193)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 296)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvTrnPenerimaanbarang
        '
        Me.DgvTrnPenerimaanbarang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvTrnPenerimaanbarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnPenerimaanbarang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnPenerimaanbarang.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnPenerimaanbarang.Name = "DgvTrnPenerimaanbarang"
        Me.DgvTrnPenerimaanbarang.Size = New System.Drawing.Size(704, 296)
        Me.DgvTrnPenerimaanbarang.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Controls.Add(Me.Label43)
        Me.PnlDfFooter.Controls.Add(Me.Label41)
        Me.PnlDfFooter.Controls.Add(Me.obj_top)
        Me.PnlDfFooter.Controls.Add(Me.Label39)
        Me.PnlDfFooter.Controls.Add(Me.Label38)
        Me.PnlDfFooter.Controls.Add(Me.Label36)
        Me.PnlDfFooter.Controls.Add(Me.Label35)
        Me.PnlDfFooter.Controls.Add(Me.Label34)
        Me.PnlDfFooter.Controls.Add(Me.Label33)
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 380)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 37)
        Me.PnlDfFooter.TabIndex = 2
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Location = New System.Drawing.Point(185, 13)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(73, 13)
        Me.Label43.TabIndex = 68
        Me.Label43.Text = "Not Approved"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(18, 14)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(42, 13)
        Me.Label41.TabIndex = 67
        Me.Label41.Text = "Record"
        '
        'obj_top
        '
        Me.obj_top.Location = New System.Drawing.Point(66, 9)
        Me.obj_top.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.obj_top.Name = "obj_top"
        Me.obj_top.Size = New System.Drawing.Size(71, 20)
        Me.obj_top.TabIndex = 66
        Me.obj_top.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Location = New System.Drawing.Point(430, 11)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(153, 13)
        Me.Label39.TabIndex = 65
        Me.Label39.Text = "Approved SPV / Section Head"
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Aquamarine
        Me.Label38.Location = New System.Drawing.Point(409, 10)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(15, 15)
        Me.Label38.TabIndex = 64
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Location = New System.Drawing.Point(615, 11)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(110, 13)
        Me.Label36.TabIndex = 63
        Me.Label36.Text = "Approved Accounting"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Location = New System.Drawing.Point(304, 11)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(78, 13)
        Me.Label35.TabIndex = 62
        Me.Label35.Text = "Approved User"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Bisque
        Me.Label34.Location = New System.Drawing.Point(594, 10)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(15, 15)
        Me.Label34.TabIndex = 61
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Thistle
        Me.Label33.Location = New System.Drawing.Point(286, 11)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(15, 15)
        Me.Label33.TabIndex = 60
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.Label6)
        Me.PnlDfSearch.Controls.Add(Me.obj_Rekanan_id_search)
        Me.PnlDfSearch.Controls.Add(Me.btn_Rekanan)
        Me.PnlDfSearch.Controls.Add(Me.obj_RvID_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_RvID_search)
        Me.PnlDfSearch.Controls.Add(Me.obj_orderID_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_orderID_search)
        Me.PnlDfSearch.Controls.Add(Me.cmb_appuser)
        Me.PnlDfSearch.Controls.Add(Me.chk_User_search)
        Me.PnlDfSearch.Controls.Add(Me.obj_Strukturunit_id_pemilik_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_Strukturunit_id_pemilik_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_Rekanan_id_search)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 178)
        Me.PnlDfSearch.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(485, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(258, 12)
        Me.Label6.TabIndex = 217
        Me.Label6.Text = "Use semicolon (;) to enter more than one references in textbox"
        '
        'obj_Rekanan_id_search
        '
        Me.obj_Rekanan_id_search.Location = New System.Drawing.Point(104, 38)
        Me.obj_Rekanan_id_search.Name = "obj_Rekanan_id_search"
        Me.obj_Rekanan_id_search.Size = New System.Drawing.Size(121, 20)
        Me.obj_Rekanan_id_search.TabIndex = 216
        '
        'btn_Rekanan
        '
        Me.btn_Rekanan.Location = New System.Drawing.Point(231, 39)
        Me.btn_Rekanan.Name = "btn_Rekanan"
        Me.btn_Rekanan.Size = New System.Drawing.Size(24, 20)
        Me.btn_Rekanan.TabIndex = 215
        Me.btn_Rekanan.Text = "..."
        Me.btn_Rekanan.UseVisualStyleBackColor = True
        '
        'obj_RvID_search
        '
        Me.obj_RvID_search.Location = New System.Drawing.Point(488, 63)
        Me.obj_RvID_search.Multiline = True
        Me.obj_RvID_search.Name = "obj_RvID_search"
        Me.obj_RvID_search.Size = New System.Drawing.Size(233, 91)
        Me.obj_RvID_search.TabIndex = 214
        '
        'chk_RvID_search
        '
        Me.chk_RvID_search.AutoSize = True
        Me.chk_RvID_search.Location = New System.Drawing.Point(384, 66)
        Me.chk_RvID_search.Name = "chk_RvID_search"
        Me.chk_RvID_search.Size = New System.Drawing.Size(61, 17)
        Me.chk_RvID_search.TabIndex = 213
        Me.chk_RvID_search.TabStop = False
        Me.chk_RvID_search.Text = "RV No."
        '
        'obj_orderID_search
        '
        Me.obj_orderID_search.Location = New System.Drawing.Point(104, 63)
        Me.obj_orderID_search.Name = "obj_orderID_search"
        Me.obj_orderID_search.Size = New System.Drawing.Size(233, 20)
        Me.obj_orderID_search.TabIndex = 212
        '
        'chk_orderID_search
        '
        Me.chk_orderID_search.AutoSize = True
        Me.chk_orderID_search.Location = New System.Drawing.Point(17, 65)
        Me.chk_orderID_search.Name = "chk_orderID_search"
        Me.chk_orderID_search.Size = New System.Drawing.Size(72, 17)
        Me.chk_orderID_search.TabIndex = 211
        Me.chk_orderID_search.TabStop = False
        Me.chk_orderID_search.Text = "Order No."
        '
        'cmb_appuser
        '
        Me.cmb_appuser.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmb_appuser.Location = New System.Drawing.Point(488, 38)
        Me.cmb_appuser.Name = "cmb_appuser"
        Me.cmb_appuser.Size = New System.Drawing.Size(85, 21)
        Me.cmb_appuser.TabIndex = 210
        '
        'chk_User_search
        '
        Me.chk_User_search.AutoSize = True
        Me.chk_User_search.Location = New System.Drawing.Point(384, 40)
        Me.chk_User_search.Name = "chk_User_search"
        Me.chk_User_search.Size = New System.Drawing.Size(97, 17)
        Me.chk_User_search.TabIndex = 209
        Me.chk_User_search.TabStop = False
        Me.chk_User_search.Text = "Approved User"
        '
        'obj_Strukturunit_id_pemilik_search
        '
        Me.obj_Strukturunit_id_pemilik_search.Location = New System.Drawing.Point(488, 13)
        Me.obj_Strukturunit_id_pemilik_search.Name = "obj_Strukturunit_id_pemilik_search"
        Me.obj_Strukturunit_id_pemilik_search.Size = New System.Drawing.Size(233, 21)
        Me.obj_Strukturunit_id_pemilik_search.TabIndex = 208
        '
        'chk_Strukturunit_id_pemilik_search
        '
        Me.chk_Strukturunit_id_pemilik_search.AutoSize = True
        Me.chk_Strukturunit_id_pemilik_search.Location = New System.Drawing.Point(384, 15)
        Me.chk_Strukturunit_id_pemilik_search.Name = "chk_Strukturunit_id_pemilik_search"
        Me.chk_Strukturunit_id_pemilik_search.Size = New System.Drawing.Size(81, 17)
        Me.chk_Strukturunit_id_pemilik_search.TabIndex = 207
        Me.chk_Strukturunit_id_pemilik_search.TabStop = False
        Me.chk_Strukturunit_id_pemilik_search.Text = "Department"
        '
        'chk_Rekanan_id_search
        '
        Me.chk_Rekanan_id_search.AutoSize = True
        Me.chk_Rekanan_id_search.Location = New System.Drawing.Point(17, 40)
        Me.chk_Rekanan_id_search.Name = "chk_Rekanan_id_search"
        Me.chk_Rekanan_id_search.Size = New System.Drawing.Size(70, 17)
        Me.chk_Rekanan_id_search.TabIndex = 206
        Me.chk_Rekanan_id_search.TabStop = False
        Me.chk_Rekanan_id_search.Text = "Rekanan"
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(104, 13)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(121, 21)
        Me.cboSearchChannel.TabIndex = 1
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Checked = True
        Me.chkSearchChannel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchChannel.Location = New System.Drawing.Point(17, 15)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(70, 17)
        Me.chkSearchChannel.TabIndex = 0
        Me.chkSearchChannel.Text = "Company"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 420)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Detil)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Info)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_jurnal)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 220)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.White
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(733, 197)
        Me.ftabDataDetil.TabIndex = 3
        '
        'ftabDataDetil_Detil
        '
        Me.ftabDataDetil_Detil.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Detil.Controls.Add(Me.TLTrnPenerimaanBarangDetil)
        Me.ftabDataDetil_Detil.Controls.Add(Me.Panel4)
        Me.ftabDataDetil_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Detil.Name = "ftabDataDetil_Detil"
        Me.ftabDataDetil_Detil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Detil.Size = New System.Drawing.Size(725, 168)
        Me.ftabDataDetil_Detil.TabIndex = 0
        Me.ftabDataDetil_Detil.Text = "Detil"
        '
        'TLTrnPenerimaanBarangDetil
        '
        Me.TLTrnPenerimaanBarangDetil.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver
        Me.TLTrnPenerimaanBarangDetil.Appearance.HorzLine.Options.UseBackColor = True
        Me.TLTrnPenerimaanBarangDetil.Appearance.TreeLine.BackColor = System.Drawing.Color.Silver
        Me.TLTrnPenerimaanBarangDetil.Appearance.TreeLine.Options.UseBackColor = True
        Me.TLTrnPenerimaanBarangDetil.Appearance.VertLine.BackColor = System.Drawing.Color.Silver
        Me.TLTrnPenerimaanBarangDetil.Appearance.VertLine.Options.UseBackColor = True
        Me.TLTrnPenerimaanBarangDetil.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.select_detail, Me.cterimabarang_id, Me.cterimabarangdetil_line, Me.cterimabarang_barcode, Me.cprint_barcode, Me.cprint_barcodekain, Me.cterimabarangdetil_desc, Me.cterimabarangdetil_type, Me.cterimabarangdetil_parentline, Me.cterimabarang_parentbarcode, Me.cterimabarangdetil_nonfixasset, Me.cterimabarangdetil_date, Me.cassettype_id, Me.cassetcategory_id, Me.cterimabarangdetil_golfiskal, Me.citem_id, Me.citemcategory_id, Me.citemtype_id, Me.cbrand_id, Me.cterimabarangdetil_serial_no, Me.cterimabarangdetil_product_no, Me.cterimabarangdetil_model, Me.cmaterial_id, Me.ccolour_id, Me.csize_id, Me.csex_id, Me.croom_id, Me.cterimabarangdetil_rack, Me.cshow_id, Me.cShow_id_cont, Me.cterimabarangdetil_eps, Me.cterimabarangdetil_qty, Me.cunit_id, Me.ccurrency_id, Me.cterimabarangdetil_foreign, Me.cterimabarangdetil_foreignrate, Me.cterimabarangdetil_idrreal, Me.cterimabarangdetil_pphpercent, Me.cterimabarangdetil_ppnpercent, Me.cterimabarangdetil_disc, Me.cterimabarangdetil_pphforeign, Me.cterimabarangdetil_pphidrreal, Me.cterimabarangdetil_ppnforeign, Me.cterimabarangdetil_ppnidrreal, Me.cterimabarangdetil_totalforeign, Me.cterimabarangdetil_totalidrreal, Me.cterimabarangdetil_depre_enddt, Me.cemployee_id, Me.cstrukturunit_id, Me.cwriteoff_id, Me.cwriteoff_dt, Me.corder_id, Me.corderdetil_line, Me.cbudget_id, Me.cbudgetdetil_id, Me.cacc_id, Me.cchannel_id, Me.ccreate_by, Me.ccreate_dt, Me.cmodified_by, Me.cmodified_dt})
        Me.TLTrnPenerimaanBarangDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLTrnPenerimaanBarangDetil.HorzScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Always
        Me.TLTrnPenerimaanBarangDetil.Location = New System.Drawing.Point(3, 3)
        Me.TLTrnPenerimaanBarangDetil.Name = "TLTrnPenerimaanBarangDetil"
        Me.TLTrnPenerimaanBarangDetil.OptionsBehavior.KeepSelectedOnClick = False
        Me.TLTrnPenerimaanBarangDetil.OptionsBehavior.MoveOnEdit = False
        Me.TLTrnPenerimaanBarangDetil.OptionsBehavior.PopulateServiceColumns = True
        Me.TLTrnPenerimaanBarangDetil.OptionsPrint.UsePrintStyles = True
        Me.TLTrnPenerimaanBarangDetil.OptionsSelection.MultiSelect = True
        Me.TLTrnPenerimaanBarangDetil.OptionsView.AutoWidth = False
        Me.TLTrnPenerimaanBarangDetil.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.btnBrowseDetil, Me.RepositoryItemButtonPrint, Me.RepositoryItemCategoryId, Me.RepositoryAssetCategory, Me.RepositoryAssetType, Me.RepositoryItemId, Me.RepositoryMaterialId, Me.RepositoryBrandId, Me.RepositoryColourId, Me.RepositorySizeId, Me.RepositorySexId, Me.RepositoryRoomId, Me.RepositoryShowId, Me.RepositoryShowIdCont, Me.RepositoryUnitId, Me.RepositoryCurrency, Me.RepositoryItemButtonEdit1, Me.RepositoryCatDepre})
        Me.TLTrnPenerimaanBarangDetil.Size = New System.Drawing.Size(719, 131)
        Me.TLTrnPenerimaanBarangDetil.TabIndex = 8
        Me.TLTrnPenerimaanBarangDetil.VertScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Always
        '
        'select_detail
        '
        Me.select_detail.AppearanceHeader.Options.UseTextOptions = True
        Me.select_detail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.select_detail.Caption = " "
        Me.select_detail.ColumnEdit = Me.btnBrowseDetil
        Me.select_detail.FieldName = "select_detail"
        Me.select_detail.Name = "select_detail"
        Me.select_detail.Visible = True
        Me.select_detail.VisibleIndex = 0
        Me.select_detail.Width = 63
        '
        'btnBrowseDetil
        '
        Me.btnBrowseDetil.AutoHeight = False
        Me.btnBrowseDetil.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "...", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.btnBrowseDetil.Name = "btnBrowseDetil"
        Me.btnBrowseDetil.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'cterimabarang_id
        '
        Me.cterimabarang_id.Caption = "terimabarang_id"
        Me.cterimabarang_id.FieldName = "terimabarang_id"
        Me.cterimabarang_id.Name = "cterimabarang_id"
        '
        'cterimabarangdetil_line
        '
        Me.cterimabarangdetil_line.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cterimabarangdetil_line.AppearanceCell.Options.UseBackColor = True
        Me.cterimabarangdetil_line.Caption = "Line"
        Me.cterimabarangdetil_line.FieldName = "terimabarangdetil_line"
        Me.cterimabarangdetil_line.Name = "cterimabarangdetil_line"
        Me.cterimabarangdetil_line.OptionsColumn.AllowEdit = False
        Me.cterimabarangdetil_line.Visible = True
        Me.cterimabarangdetil_line.VisibleIndex = 1
        Me.cterimabarangdetil_line.Width = 50
        '
        'cterimabarang_barcode
        '
        Me.cterimabarang_barcode.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cterimabarang_barcode.AppearanceCell.Options.UseBackColor = True
        Me.cterimabarang_barcode.Caption = "Barcode"
        Me.cterimabarang_barcode.FieldName = "terimabarang_barcode"
        Me.cterimabarang_barcode.Name = "cterimabarang_barcode"
        Me.cterimabarang_barcode.OptionsColumn.AllowEdit = False
        Me.cterimabarang_barcode.OptionsColumn.ReadOnly = True
        Me.cterimabarang_barcode.Visible = True
        Me.cterimabarang_barcode.VisibleIndex = 2
        Me.cterimabarang_barcode.Width = 103
        '
        'cprint_barcode
        '
        Me.cprint_barcode.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cprint_barcode.AppearanceCell.Options.UseBackColor = True
        Me.cprint_barcode.AppearanceHeader.Options.UseTextOptions = True
        Me.cprint_barcode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cprint_barcode.Caption = "Print"
        Me.cprint_barcode.ColumnEdit = Me.RepositoryItemButtonPrint
        Me.cprint_barcode.FieldName = "Print"
        Me.cprint_barcode.Name = "cprint_barcode"
        Me.cprint_barcode.Visible = True
        Me.cprint_barcode.VisibleIndex = 3
        Me.cprint_barcode.Width = 42
        '
        'RepositoryItemButtonPrint
        '
        Me.RepositoryItemButtonPrint.AutoHeight = False
        SerializableAppearanceObject2.BackColor = System.Drawing.Color.Gainsboro
        SerializableAppearanceObject2.Options.UseBackColor = True
        Me.RepositoryItemButtonPrint.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "Print", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.RepositoryItemButtonPrint.Name = "RepositoryItemButtonPrint"
        Me.RepositoryItemButtonPrint.NullText = "Print"
        Me.RepositoryItemButtonPrint.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'cprint_barcodekain
        '
        Me.cprint_barcodekain.Caption = "print_barcodekain"
        Me.cprint_barcodekain.FieldName = "print_barcodekain"
        Me.cprint_barcodekain.Name = "cprint_barcodekain"
        '
        'cterimabarangdetil_desc
        '
        Me.cterimabarangdetil_desc.Caption = "Description"
        Me.cterimabarangdetil_desc.FieldName = "terimabarangdetil_desc"
        Me.cterimabarangdetil_desc.Name = "cterimabarangdetil_desc"
        Me.cterimabarangdetil_desc.Visible = True
        Me.cterimabarangdetil_desc.VisibleIndex = 4
        Me.cterimabarangdetil_desc.Width = 150
        '
        'cterimabarangdetil_type
        '
        Me.cterimabarangdetil_type.Caption = "terimabarangdetil_type"
        Me.cterimabarangdetil_type.FieldName = "terimabarangdetil_type"
        Me.cterimabarangdetil_type.Name = "cterimabarangdetil_type"
        '
        'cterimabarangdetil_parentline
        '
        Me.cterimabarangdetil_parentline.Caption = "terimabarangdetil_parentline"
        Me.cterimabarangdetil_parentline.FieldName = "terimabarangdetil_parentline"
        Me.cterimabarangdetil_parentline.Name = "cterimabarangdetil_parentline"
        '
        'cterimabarang_parentbarcode
        '
        Me.cterimabarang_parentbarcode.Caption = "terimabarang_parentbarcode"
        Me.cterimabarang_parentbarcode.FieldName = "terimabarang_parentbarcode"
        Me.cterimabarang_parentbarcode.Name = "cterimabarang_parentbarcode"
        '
        'cterimabarangdetil_nonfixasset
        '
        Me.cterimabarangdetil_nonfixasset.Caption = "Not Printed"
        Me.cterimabarangdetil_nonfixasset.FieldName = "terimabarangdetil_nonfixasset"
        Me.cterimabarangdetil_nonfixasset.Name = "cterimabarangdetil_nonfixasset"
        Me.cterimabarangdetil_nonfixasset.OptionsColumn.AllowEdit = False
        Me.cterimabarangdetil_nonfixasset.OptionsColumn.ReadOnly = True
        Me.cterimabarangdetil_nonfixasset.Visible = True
        Me.cterimabarangdetil_nonfixasset.VisibleIndex = 5
        '
        'cterimabarangdetil_date
        '
        Me.cterimabarangdetil_date.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cterimabarangdetil_date.AppearanceCell.Options.UseBackColor = True
        Me.cterimabarangdetil_date.Caption = "Date"
        Me.cterimabarangdetil_date.FieldName = "terimabarangdetil_date"
        Me.cterimabarangdetil_date.Format.FormatString = "dd/MM/yyyy"
        Me.cterimabarangdetil_date.Format.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cterimabarangdetil_date.Name = "cterimabarangdetil_date"
        Me.cterimabarangdetil_date.OptionsColumn.AllowEdit = False
        Me.cterimabarangdetil_date.OptionsColumn.ReadOnly = True
        Me.cterimabarangdetil_date.Width = 100
        '
        'cassettype_id
        '
        Me.cassettype_id.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cassettype_id.AppearanceCell.Options.UseBackColor = True
        Me.cassettype_id.AppearanceCell.Options.UseTextOptions = True
        Me.cassettype_id.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisPath
        Me.cassettype_id.Caption = "Asset Type"
        Me.cassettype_id.ColumnEdit = Me.RepositoryAssetType
        Me.cassettype_id.FieldName = "assettype_id"
        Me.cassettype_id.Name = "cassettype_id"
        Me.cassettype_id.OptionsColumn.AllowEdit = False
        Me.cassettype_id.Visible = True
        Me.cassettype_id.VisibleIndex = 6
        Me.cassettype_id.Width = 200
        '
        'RepositoryAssetType
        '
        Me.RepositoryAssetType.AutoHeight = False
        Me.RepositoryAssetType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryAssetType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("tipeasset_id", "Name6")})
        Me.RepositoryAssetType.Name = "RepositoryAssetType"
        Me.RepositoryAssetType.NullText = "-- PILIH --"
        Me.RepositoryAssetType.ShowFooter = False
        Me.RepositoryAssetType.ShowHeader = False
        '
        'cassetcategory_id
        '
        Me.cassetcategory_id.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cassetcategory_id.AppearanceCell.Options.UseBackColor = True
        Me.cassetcategory_id.Caption = "Asset Category"
        Me.cassetcategory_id.ColumnEdit = Me.RepositoryAssetCategory
        Me.cassetcategory_id.FieldName = "assetcategory_id"
        Me.cassetcategory_id.Name = "cassetcategory_id"
        Me.cassetcategory_id.OptionsColumn.AllowEdit = False
        Me.cassetcategory_id.Visible = True
        Me.cassetcategory_id.VisibleIndex = 7
        Me.cassetcategory_id.Width = 200
        '
        'RepositoryAssetCategory
        '
        Me.RepositoryAssetCategory.AutoHeight = False
        Me.RepositoryAssetCategory.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryAssetCategory.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("kategoriasset_id", "Name1")})
        Me.RepositoryAssetCategory.Name = "RepositoryAssetCategory"
        Me.RepositoryAssetCategory.NullText = "-- PILIH --"
        Me.RepositoryAssetCategory.ShowFooter = False
        Me.RepositoryAssetCategory.ShowHeader = False
        '
        'cterimabarangdetil_golfiskal
        '
        Me.cterimabarangdetil_golfiskal.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cterimabarangdetil_golfiskal.AppearanceCell.Options.UseBackColor = True
        Me.cterimabarangdetil_golfiskal.Caption = "Asset Cat. Depre"
        Me.cterimabarangdetil_golfiskal.ColumnEdit = Me.RepositoryCatDepre
        Me.cterimabarangdetil_golfiskal.FieldName = "terimabarangdetil_golfiskal"
        Me.cterimabarangdetil_golfiskal.Name = "cterimabarangdetil_golfiskal"
        Me.cterimabarangdetil_golfiskal.OptionsColumn.AllowEdit = False
        Me.cterimabarangdetil_golfiskal.Visible = True
        Me.cterimabarangdetil_golfiskal.VisibleIndex = 8
        Me.cterimabarangdetil_golfiskal.Width = 100
        '
        'RepositoryCatDepre
        '
        Me.RepositoryCatDepre.AutoHeight = False
        Me.RepositoryCatDepre.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryCatDepre.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("kategoriassetdepre_descr", "Name7")})
        Me.RepositoryCatDepre.Name = "RepositoryCatDepre"
        Me.RepositoryCatDepre.NullText = "-- PILIH --"
        Me.RepositoryCatDepre.ShowFooter = False
        Me.RepositoryCatDepre.ShowHeader = False
        '
        'citem_id
        '
        Me.citem_id.Caption = "Item"
        Me.citem_id.ColumnEdit = Me.RepositoryItemId
        Me.citem_id.FieldName = "item_id"
        Me.citem_id.Name = "citem_id"
        Me.citem_id.Visible = True
        Me.citem_id.VisibleIndex = 9
        Me.citem_id.Width = 150
        '
        'RepositoryItemId
        '
        Me.RepositoryItemId.AutoHeight = False
        Me.RepositoryItemId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("item_name", "Name3")})
        Me.RepositoryItemId.Name = "RepositoryItemId"
        Me.RepositoryItemId.NullText = "-- PILIH --"
        Me.RepositoryItemId.ShowFooter = False
        Me.RepositoryItemId.ShowHeader = False
        '
        'citemcategory_id
        '
        Me.citemcategory_id.Caption = "Category"
        Me.citemcategory_id.ColumnEdit = Me.RepositoryItemCategoryId
        Me.citemcategory_id.FieldName = "itemcategory_id"
        Me.citemcategory_id.Name = "citemcategory_id"
        Me.citemcategory_id.Visible = True
        Me.citemcategory_id.VisibleIndex = 10
        Me.citemcategory_id.Width = 130
        '
        'RepositoryItemCategoryId
        '
        Me.RepositoryItemCategoryId.AutoHeight = False
        Me.RepositoryItemCategoryId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCategoryId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("category_name", "Name5")})
        Me.RepositoryItemCategoryId.Name = "RepositoryItemCategoryId"
        Me.RepositoryItemCategoryId.NullText = "-- PILIH --"
        Me.RepositoryItemCategoryId.ShowFooter = False
        Me.RepositoryItemCategoryId.ShowHeader = False
        '
        'citemtype_id
        '
        Me.citemtype_id.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.citemtype_id.AppearanceCell.Options.UseBackColor = True
        Me.citemtype_id.Caption = "Type"
        Me.citemtype_id.FieldName = "itemtype_id"
        Me.citemtype_id.Name = "citemtype_id"
        Me.citemtype_id.OptionsColumn.AllowEdit = False
        Me.citemtype_id.Visible = True
        Me.citemtype_id.VisibleIndex = 11
        Me.citemtype_id.Width = 130
        '
        'cbrand_id
        '
        Me.cbrand_id.Caption = "Brand"
        Me.cbrand_id.ColumnEdit = Me.RepositoryBrandId
        Me.cbrand_id.FieldName = "brand_id"
        Me.cbrand_id.Name = "cbrand_id"
        Me.cbrand_id.Visible = True
        Me.cbrand_id.VisibleIndex = 12
        Me.cbrand_id.Width = 130
        '
        'RepositoryBrandId
        '
        Me.RepositoryBrandId.AutoHeight = False
        Me.RepositoryBrandId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryBrandId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("merk_name", "Name8")})
        Me.RepositoryBrandId.Name = "RepositoryBrandId"
        Me.RepositoryBrandId.NullText = "-- PILIH --"
        Me.RepositoryBrandId.ShowFooter = False
        Me.RepositoryBrandId.ShowHeader = False
        '
        'cterimabarangdetil_serial_no
        '
        Me.cterimabarangdetil_serial_no.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cterimabarangdetil_serial_no.AppearanceCell.Options.UseBackColor = True
        Me.cterimabarangdetil_serial_no.Caption = "Serial No."
        Me.cterimabarangdetil_serial_no.FieldName = "terimabarangdetil_serial_no"
        Me.cterimabarangdetil_serial_no.Name = "cterimabarangdetil_serial_no"
        Me.cterimabarangdetil_serial_no.OptionsColumn.AllowEdit = False
        Me.cterimabarangdetil_serial_no.Visible = True
        Me.cterimabarangdetil_serial_no.VisibleIndex = 13
        Me.cterimabarangdetil_serial_no.Width = 100
        '
        'cterimabarangdetil_product_no
        '
        Me.cterimabarangdetil_product_no.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cterimabarangdetil_product_no.AppearanceCell.Options.UseBackColor = True
        Me.cterimabarangdetil_product_no.Caption = "Barcode Type"
        Me.cterimabarangdetil_product_no.FieldName = "terimabarangdetil_product_no"
        Me.cterimabarangdetil_product_no.Name = "cterimabarangdetil_product_no"
        Me.cterimabarangdetil_product_no.OptionsColumn.AllowEdit = False
        Me.cterimabarangdetil_product_no.OptionsColumn.ReadOnly = True
        Me.cterimabarangdetil_product_no.Visible = True
        Me.cterimabarangdetil_product_no.VisibleIndex = 14
        Me.cterimabarangdetil_product_no.Width = 100
        '
        'cterimabarangdetil_model
        '
        Me.cterimabarangdetil_model.Caption = "terimabarangdetil_model"
        Me.cterimabarangdetil_model.FieldName = "terimabarangdetil_model"
        Me.cterimabarangdetil_model.Name = "cterimabarangdetil_model"
        '
        'cmaterial_id
        '
        Me.cmaterial_id.Caption = "material_id"
        Me.cmaterial_id.ColumnEdit = Me.RepositoryMaterialId
        Me.cmaterial_id.FieldName = "material_id"
        Me.cmaterial_id.Name = "cmaterial_id"
        '
        'RepositoryMaterialId
        '
        Me.RepositoryMaterialId.AutoHeight = False
        Me.RepositoryMaterialId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryMaterialId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Material_id", "Name9")})
        Me.RepositoryMaterialId.Name = "RepositoryMaterialId"
        Me.RepositoryMaterialId.ShowFooter = False
        Me.RepositoryMaterialId.ShowHeader = False
        '
        'ccolour_id
        '
        Me.ccolour_id.Caption = "colour_id"
        Me.ccolour_id.ColumnEdit = Me.RepositoryColourId
        Me.ccolour_id.FieldName = "colour_id"
        Me.ccolour_id.Name = "ccolour_id"
        '
        'RepositoryColourId
        '
        Me.RepositoryColourId.AutoHeight = False
        Me.RepositoryColourId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryColourId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("warna_id", "Name10")})
        Me.RepositoryColourId.Name = "RepositoryColourId"
        Me.RepositoryColourId.ShowFooter = False
        Me.RepositoryColourId.ShowHeader = False
        '
        'csize_id
        '
        Me.csize_id.Caption = "size_id"
        Me.csize_id.ColumnEdit = Me.RepositorySizeId
        Me.csize_id.FieldName = "size_id"
        Me.csize_id.Name = "csize_id"
        '
        'RepositorySizeId
        '
        Me.RepositorySizeId.AutoHeight = False
        Me.RepositorySizeId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySizeId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ukuran_id", "Name11")})
        Me.RepositorySizeId.Name = "RepositorySizeId"
        Me.RepositorySizeId.ShowFooter = False
        Me.RepositorySizeId.ShowHeader = False
        '
        'csex_id
        '
        Me.csex_id.Caption = "sex_id"
        Me.csex_id.ColumnEdit = Me.RepositorySexId
        Me.csex_id.FieldName = "sex_id"
        Me.csex_id.Name = "csex_id"
        '
        'RepositorySexId
        '
        Me.RepositorySexId.AutoHeight = False
        Me.RepositorySexId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySexId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Pilihan", "Name12")})
        Me.RepositorySexId.Name = "RepositorySexId"
        Me.RepositorySexId.ShowFooter = False
        Me.RepositorySexId.ShowHeader = False
        '
        'croom_id
        '
        Me.croom_id.Caption = "room_id"
        Me.croom_id.ColumnEdit = Me.RepositoryRoomId
        Me.croom_id.FieldName = "room_id"
        Me.croom_id.Name = "croom_id"
        '
        'RepositoryRoomId
        '
        Me.RepositoryRoomId.AutoHeight = False
        Me.RepositoryRoomId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryRoomId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("keterangan", "Name13")})
        Me.RepositoryRoomId.Name = "RepositoryRoomId"
        Me.RepositoryRoomId.ShowFooter = False
        Me.RepositoryRoomId.ShowHeader = False
        '
        'cterimabarangdetil_rack
        '
        Me.cterimabarangdetil_rack.Caption = "terimabarangdetil_rack"
        Me.cterimabarangdetil_rack.FieldName = "terimabarangdetil_rack"
        Me.cterimabarangdetil_rack.Name = "cterimabarangdetil_rack"
        '
        'cshow_id
        '
        Me.cshow_id.Caption = "show_id"
        Me.cshow_id.ColumnEdit = Me.RepositoryShowId
        Me.cshow_id.FieldName = "show_id"
        Me.cshow_id.Name = "cshow_id"
        '
        'RepositoryShowId
        '
        Me.RepositoryShowId.AutoHeight = False
        Me.RepositoryShowId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryShowId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("show_title", "Name16")})
        Me.RepositoryShowId.Name = "RepositoryShowId"
        Me.RepositoryShowId.ShowFooter = False
        Me.RepositoryShowId.ShowHeader = False
        '
        'cShow_id_cont
        '
        Me.cShow_id_cont.Caption = "show_id_cont"
        Me.cShow_id_cont.ColumnEdit = Me.RepositoryShowIdCont
        Me.cShow_id_cont.FieldName = "show_id_cont"
        Me.cShow_id_cont.Name = "cShow_id_cont"
        '
        'RepositoryShowIdCont
        '
        Me.RepositoryShowIdCont.AutoHeight = False
        Me.RepositoryShowIdCont.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryShowIdCont.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("show_title", "Name17")})
        Me.RepositoryShowIdCont.Name = "RepositoryShowIdCont"
        Me.RepositoryShowIdCont.ShowFooter = False
        Me.RepositoryShowIdCont.ShowHeader = False
        '
        'cterimabarangdetil_eps
        '
        Me.cterimabarangdetil_eps.Caption = "Eps"
        Me.cterimabarangdetil_eps.FieldName = "terimabarangdetil_eps"
        Me.cterimabarangdetil_eps.Name = "cterimabarangdetil_eps"
        Me.cterimabarangdetil_eps.Width = 50
        '
        'cterimabarangdetil_qty
        '
        Me.cterimabarangdetil_qty.Caption = "Qty"
        Me.cterimabarangdetil_qty.FieldName = "terimabarangdetil_qty"
        Me.cterimabarangdetil_qty.Format.FormatString = "#,##0.00"
        Me.cterimabarangdetil_qty.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cterimabarangdetil_qty.Name = "cterimabarangdetil_qty"
        Me.cterimabarangdetil_qty.Visible = True
        Me.cterimabarangdetil_qty.VisibleIndex = 15
        Me.cterimabarangdetil_qty.Width = 80
        '
        'cunit_id
        '
        Me.cunit_id.Caption = "Unit"
        Me.cunit_id.ColumnEdit = Me.RepositoryUnitId
        Me.cunit_id.FieldName = "unit_id"
        Me.cunit_id.Name = "cunit_id"
        Me.cunit_id.Visible = True
        Me.cunit_id.VisibleIndex = 16
        '
        'RepositoryUnitId
        '
        Me.RepositoryUnitId.AutoHeight = False
        Me.RepositoryUnitId.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryUnitId.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("unit_shortname", "Name14")})
        Me.RepositoryUnitId.Name = "RepositoryUnitId"
        Me.RepositoryUnitId.NullText = "-- PILIH --"
        Me.RepositoryUnitId.ShowFooter = False
        Me.RepositoryUnitId.ShowHeader = False
        '
        'ccurrency_id
        '
        Me.ccurrency_id.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.ccurrency_id.AppearanceCell.Options.UseBackColor = True
        Me.ccurrency_id.Caption = "Curr."
        Me.ccurrency_id.ColumnEdit = Me.RepositoryCurrency
        Me.ccurrency_id.FieldName = "currency_id"
        Me.ccurrency_id.Name = "ccurrency_id"
        Me.ccurrency_id.OptionsColumn.AllowEdit = False
        Me.ccurrency_id.OptionsColumn.ReadOnly = True
        Me.ccurrency_id.Visible = True
        Me.ccurrency_id.VisibleIndex = 17
        Me.ccurrency_id.Width = 60
        '
        'RepositoryCurrency
        '
        Me.RepositoryCurrency.AutoHeight = False
        Me.RepositoryCurrency.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryCurrency.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Currency_shortname", "Name15")})
        Me.RepositoryCurrency.Name = "RepositoryCurrency"
        Me.RepositoryCurrency.NullText = "-- PILIH --"
        Me.RepositoryCurrency.ShowFooter = False
        Me.RepositoryCurrency.ShowHeader = False
        '
        'cterimabarangdetil_foreign
        '
        Me.cterimabarangdetil_foreign.Caption = "Amount"
        Me.cterimabarangdetil_foreign.FieldName = "terimabarangdetil_foreign"
        Me.cterimabarangdetil_foreign.Format.FormatString = "#,##0.00"
        Me.cterimabarangdetil_foreign.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cterimabarangdetil_foreign.Name = "cterimabarangdetil_foreign"
        Me.cterimabarangdetil_foreign.Visible = True
        Me.cterimabarangdetil_foreign.VisibleIndex = 18
        Me.cterimabarangdetil_foreign.Width = 100
        '
        'cterimabarangdetil_foreignrate
        '
        Me.cterimabarangdetil_foreignrate.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cterimabarangdetil_foreignrate.AppearanceCell.Options.UseBackColor = True
        Me.cterimabarangdetil_foreignrate.Caption = "Rate"
        Me.cterimabarangdetil_foreignrate.FieldName = "terimabarangdetil_foreignrate"
        Me.cterimabarangdetil_foreignrate.Format.FormatString = "#,##0.00"
        Me.cterimabarangdetil_foreignrate.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cterimabarangdetil_foreignrate.Name = "cterimabarangdetil_foreignrate"
        Me.cterimabarangdetil_foreignrate.OptionsColumn.AllowEdit = False
        Me.cterimabarangdetil_foreignrate.OptionsColumn.ReadOnly = True
        Me.cterimabarangdetil_foreignrate.Visible = True
        Me.cterimabarangdetil_foreignrate.VisibleIndex = 19
        Me.cterimabarangdetil_foreignrate.Width = 100
        '
        'cterimabarangdetil_idrreal
        '
        Me.cterimabarangdetil_idrreal.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cterimabarangdetil_idrreal.AppearanceCell.Options.UseBackColor = True
        Me.cterimabarangdetil_idrreal.Caption = "Amount (IDR)"
        Me.cterimabarangdetil_idrreal.FieldName = "terimabarangdetil_idrreal"
        Me.cterimabarangdetil_idrreal.Format.FormatString = "#,##0.00"
        Me.cterimabarangdetil_idrreal.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cterimabarangdetil_idrreal.Name = "cterimabarangdetil_idrreal"
        Me.cterimabarangdetil_idrreal.OptionsColumn.AllowEdit = False
        Me.cterimabarangdetil_idrreal.OptionsColumn.ReadOnly = True
        Me.cterimabarangdetil_idrreal.Visible = True
        Me.cterimabarangdetil_idrreal.VisibleIndex = 20
        Me.cterimabarangdetil_idrreal.Width = 100
        '
        'cterimabarangdetil_pphpercent
        '
        Me.cterimabarangdetil_pphpercent.Caption = "Pph %"
        Me.cterimabarangdetil_pphpercent.FieldName = "terimabarangdetil_pphpercent"
        Me.cterimabarangdetil_pphpercent.Format.FormatString = "#,##0.00"
        Me.cterimabarangdetil_pphpercent.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cterimabarangdetil_pphpercent.Name = "cterimabarangdetil_pphpercent"
        Me.cterimabarangdetil_pphpercent.Visible = True
        Me.cterimabarangdetil_pphpercent.VisibleIndex = 21
        Me.cterimabarangdetil_pphpercent.Width = 100
        '
        'cterimabarangdetil_ppnpercent
        '
        Me.cterimabarangdetil_ppnpercent.Caption = "PPN %"
        Me.cterimabarangdetil_ppnpercent.FieldName = "terimabarangdetil_ppnpercent"
        Me.cterimabarangdetil_ppnpercent.Format.FormatString = "#,##0.00"
        Me.cterimabarangdetil_ppnpercent.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cterimabarangdetil_ppnpercent.Name = "cterimabarangdetil_ppnpercent"
        Me.cterimabarangdetil_ppnpercent.Visible = True
        Me.cterimabarangdetil_ppnpercent.VisibleIndex = 22
        Me.cterimabarangdetil_ppnpercent.Width = 100
        '
        'cterimabarangdetil_disc
        '
        Me.cterimabarangdetil_disc.Caption = "Disc"
        Me.cterimabarangdetil_disc.FieldName = "terimabarangdetil_disc"
        Me.cterimabarangdetil_disc.Format.FormatString = "#,##0.00"
        Me.cterimabarangdetil_disc.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cterimabarangdetil_disc.Name = "cterimabarangdetil_disc"
        Me.cterimabarangdetil_disc.Visible = True
        Me.cterimabarangdetil_disc.VisibleIndex = 23
        Me.cterimabarangdetil_disc.Width = 100
        '
        'cterimabarangdetil_pphforeign
        '
        Me.cterimabarangdetil_pphforeign.Caption = "terimabarangdetil_pphforeign"
        Me.cterimabarangdetil_pphforeign.FieldName = "terimabarangdetil_pphforeign"
        Me.cterimabarangdetil_pphforeign.Name = "cterimabarangdetil_pphforeign"
        '
        'cterimabarangdetil_pphidrreal
        '
        Me.cterimabarangdetil_pphidrreal.Caption = "terimabarangdetil_pphidrreal"
        Me.cterimabarangdetil_pphidrreal.FieldName = "terimabarangdetil_pphidrreal"
        Me.cterimabarangdetil_pphidrreal.Name = "cterimabarangdetil_pphidrreal"
        '
        'cterimabarangdetil_ppnforeign
        '
        Me.cterimabarangdetil_ppnforeign.Caption = "terimabarangdetil_ppnforeign"
        Me.cterimabarangdetil_ppnforeign.FieldName = "terimabarangdetil_ppnforeign"
        Me.cterimabarangdetil_ppnforeign.Name = "cterimabarangdetil_ppnforeign"
        '
        'cterimabarangdetil_ppnidrreal
        '
        Me.cterimabarangdetil_ppnidrreal.Caption = "terimabarangdetil_ppnidrreal"
        Me.cterimabarangdetil_ppnidrreal.FieldName = "terimabarangdetil_ppnidrreal"
        Me.cterimabarangdetil_ppnidrreal.Name = "cterimabarangdetil_ppnidrreal"
        '
        'cterimabarangdetil_totalforeign
        '
        Me.cterimabarangdetil_totalforeign.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cterimabarangdetil_totalforeign.AppearanceCell.Options.UseBackColor = True
        Me.cterimabarangdetil_totalforeign.Caption = "Total Amount"
        Me.cterimabarangdetil_totalforeign.FieldName = "terimabarangdetil_totalforeign"
        Me.cterimabarangdetil_totalforeign.Format.FormatString = "#,##0.00"
        Me.cterimabarangdetil_totalforeign.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cterimabarangdetil_totalforeign.Name = "cterimabarangdetil_totalforeign"
        Me.cterimabarangdetil_totalforeign.OptionsColumn.AllowEdit = False
        Me.cterimabarangdetil_totalforeign.OptionsColumn.ReadOnly = True
        Me.cterimabarangdetil_totalforeign.Visible = True
        Me.cterimabarangdetil_totalforeign.VisibleIndex = 24
        Me.cterimabarangdetil_totalforeign.Width = 100
        '
        'cterimabarangdetil_totalidrreal
        '
        Me.cterimabarangdetil_totalidrreal.AppearanceCell.BackColor = System.Drawing.Color.Gainsboro
        Me.cterimabarangdetil_totalidrreal.AppearanceCell.Options.UseBackColor = True
        Me.cterimabarangdetil_totalidrreal.Caption = "Total Amount (IDR)"
        Me.cterimabarangdetil_totalidrreal.FieldName = "terimabarangdetil_totalidrreal"
        Me.cterimabarangdetil_totalidrreal.Format.FormatString = "#,##0.00"
        Me.cterimabarangdetil_totalidrreal.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cterimabarangdetil_totalidrreal.Name = "cterimabarangdetil_totalidrreal"
        Me.cterimabarangdetil_totalidrreal.OptionsColumn.AllowEdit = False
        Me.cterimabarangdetil_totalidrreal.OptionsColumn.ReadOnly = True
        Me.cterimabarangdetil_totalidrreal.Visible = True
        Me.cterimabarangdetil_totalidrreal.VisibleIndex = 25
        Me.cterimabarangdetil_totalidrreal.Width = 130
        '
        'cterimabarangdetil_depre_enddt
        '
        Me.cterimabarangdetil_depre_enddt.Caption = "terimabarangdetil_depre_enddt"
        Me.cterimabarangdetil_depre_enddt.FieldName = "terimabarangdetil_depre_enddt"
        Me.cterimabarangdetil_depre_enddt.Name = "cterimabarangdetil_depre_enddt"
        '
        'cemployee_id
        '
        Me.cemployee_id.Caption = "employee_id"
        Me.cemployee_id.FieldName = "employee_id"
        Me.cemployee_id.Name = "cemployee_id"
        '
        'cstrukturunit_id
        '
        Me.cstrukturunit_id.Caption = "strukturunit_id"
        Me.cstrukturunit_id.FieldName = "strukturunit_id"
        Me.cstrukturunit_id.Name = "cstrukturunit_id"
        '
        'cwriteoff_id
        '
        Me.cwriteoff_id.Caption = "writeoff_id"
        Me.cwriteoff_id.FieldName = "writeoff_id"
        Me.cwriteoff_id.Name = "cwriteoff_id"
        '
        'cwriteoff_dt
        '
        Me.cwriteoff_dt.Caption = "writeoff_dt"
        Me.cwriteoff_dt.FieldName = "writeoff_dt"
        Me.cwriteoff_dt.Name = "cwriteoff_dt"
        '
        'corder_id
        '
        Me.corder_id.Caption = "order_id"
        Me.corder_id.FieldName = "order_id"
        Me.corder_id.Name = "corder_id"
        '
        'corderdetil_line
        '
        Me.corderdetil_line.Caption = "orderdetil_line"
        Me.corderdetil_line.FieldName = "orderdetil_line"
        Me.corderdetil_line.Name = "corderdetil_line"
        '
        'cbudget_id
        '
        Me.cbudget_id.Caption = "budget_id"
        Me.cbudget_id.FieldName = "budget_id"
        Me.cbudget_id.Name = "cbudget_id"
        '
        'cbudgetdetil_id
        '
        Me.cbudgetdetil_id.Caption = "budgetdetil_id"
        Me.cbudgetdetil_id.FieldName = "budgetdetil_id"
        Me.cbudgetdetil_id.Name = "cbudgetdetil_id"
        '
        'cacc_id
        '
        Me.cacc_id.Caption = "acc_id"
        Me.cacc_id.FieldName = "acc_id"
        Me.cacc_id.Name = "cacc_id"
        '
        'cchannel_id
        '
        Me.cchannel_id.Caption = "channel_id"
        Me.cchannel_id.FieldName = "channel_id"
        Me.cchannel_id.Name = "cchannel_id"
        '
        'ccreate_by
        '
        Me.ccreate_by.Caption = "create_by"
        Me.ccreate_by.FieldName = "create_by"
        Me.ccreate_by.Name = "ccreate_by"
        '
        'ccreate_dt
        '
        Me.ccreate_dt.Caption = "create_dt"
        Me.ccreate_dt.FieldName = "create_dt"
        Me.ccreate_dt.Name = "ccreate_dt"
        '
        'cmodified_by
        '
        Me.cmodified_by.Caption = "modified_by"
        Me.cmodified_by.FieldName = "modified_by"
        Me.cmodified_by.Name = "cmodified_by"
        '
        'cmodified_dt
        '
        Me.cmodified_dt.Caption = "modified_dt"
        Me.cmodified_dt.FieldName = "modified_dt"
        Me.cmodified_dt.Name = "cmodified_dt"
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Test", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "", Nothing, Nothing, True)})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnPrintAllBarcode)
        Me.Panel4.Controls.Add(Me.Btn_Add)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 134)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.Panel4.Size = New System.Drawing.Size(719, 31)
        Me.Panel4.TabIndex = 5
        '
        'btnPrintAllBarcode
        '
        Me.btnPrintAllBarcode.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPrintAllBarcode.Location = New System.Drawing.Point(110, 3)
        Me.btnPrintAllBarcode.Name = "btnPrintAllBarcode"
        Me.btnPrintAllBarcode.Size = New System.Drawing.Size(105, 25)
        Me.btnPrintAllBarcode.TabIndex = 67
        Me.btnPrintAllBarcode.Text = "Print Barcode"
        Me.btnPrintAllBarcode.UseVisualStyleBackColor = True
        '
        'Btn_Add
        '
        Me.Btn_Add.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Add.Location = New System.Drawing.Point(3, 3)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(107, 25)
        Me.Btn_Add.TabIndex = 66
        Me.Btn_Add.Text = "[+] Item Order"
        Me.Btn_Add.UseVisualStyleBackColor = True
        '
        'ftabDataDetil_Info
        '
        Me.ftabDataDetil_Info.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Strukturunit_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Strukturunit_id)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_isdisabled)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_modifiedby)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Terimabarang_modifieddt)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_modifieddt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Terimabarang_modifiedby)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Terimabarang_createdt)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_createdt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Terimabarang_createby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_createby)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_cetakbpb)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Terimabarang_cetakbpb)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_appuser_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Terimabarang_appspv_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_appspv_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Terimabarang_appspv_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_appspv_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_appspv)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Terimabarang_appuser_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Terimabarang_appuser_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_appuser_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_appuser)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_appacc_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Terimabarang_appacc_dt)
        Me.ftabDataDetil_Info.Controls.Add(Me.lbl_Terimabarang_appacc_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_appacc_by)
        Me.ftabDataDetil_Info.Controls.Add(Me.obj_Terimabarang_appacc)
        Me.ftabDataDetil_Info.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Info.Name = "ftabDataDetil_Info"
        Me.ftabDataDetil_Info.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Info.TabIndex = 1
        Me.ftabDataDetil_Info.Text = "Info"
        '
        'obj_Strukturunit_id
        '
        Me.obj_Strukturunit_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Strukturunit_id.Location = New System.Drawing.Point(109, 201)
        Me.obj_Strukturunit_id.Name = "obj_Strukturunit_id"
        Me.obj_Strukturunit_id.ReadOnly = True
        Me.obj_Strukturunit_id.Size = New System.Drawing.Size(122, 20)
        Me.obj_Strukturunit_id.TabIndex = 1
        Me.obj_Strukturunit_id.Visible = False
        '
        'lbl_Strukturunit_id
        '
        Me.lbl_Strukturunit_id.AutoSize = True
        Me.lbl_Strukturunit_id.Location = New System.Drawing.Point(12, 204)
        Me.lbl_Strukturunit_id.Name = "lbl_Strukturunit_id"
        Me.lbl_Strukturunit_id.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Strukturunit_id.TabIndex = 0
        Me.lbl_Strukturunit_id.Text = "Department"
        Me.lbl_Strukturunit_id.Visible = False
        '
        'obj_Terimabarang_isdisabled
        '
        Me.obj_Terimabarang_isdisabled.AutoSize = True
        Me.obj_Terimabarang_isdisabled.Enabled = False
        Me.obj_Terimabarang_isdisabled.Location = New System.Drawing.Point(390, 203)
        Me.obj_Terimabarang_isdisabled.Name = "obj_Terimabarang_isdisabled"
        Me.obj_Terimabarang_isdisabled.Size = New System.Drawing.Size(67, 17)
        Me.obj_Terimabarang_isdisabled.TabIndex = 2
        Me.obj_Terimabarang_isdisabled.Text = "Disabled"
        Me.obj_Terimabarang_isdisabled.UseVisualStyleBackColor = True
        Me.obj_Terimabarang_isdisabled.Visible = False
        '
        'obj_Terimabarang_modifiedby
        '
        Me.obj_Terimabarang_modifiedby.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_modifiedby.Location = New System.Drawing.Point(109, 53)
        Me.obj_Terimabarang_modifiedby.Name = "obj_Terimabarang_modifiedby"
        Me.obj_Terimabarang_modifiedby.ReadOnly = True
        Me.obj_Terimabarang_modifiedby.Size = New System.Drawing.Size(122, 20)
        Me.obj_Terimabarang_modifiedby.TabIndex = 1
        '
        'lbl_Terimabarang_modifieddt
        '
        Me.lbl_Terimabarang_modifieddt.AutoSize = True
        Me.lbl_Terimabarang_modifieddt.Location = New System.Drawing.Point(12, 78)
        Me.lbl_Terimabarang_modifieddt.Name = "lbl_Terimabarang_modifieddt"
        Me.lbl_Terimabarang_modifieddt.Size = New System.Drawing.Size(73, 13)
        Me.lbl_Terimabarang_modifieddt.TabIndex = 0
        Me.lbl_Terimabarang_modifieddt.Text = "Modified Date"
        '
        'obj_Terimabarang_modifieddt
        '
        Me.obj_Terimabarang_modifieddt.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_modifieddt.Location = New System.Drawing.Point(109, 75)
        Me.obj_Terimabarang_modifieddt.Name = "obj_Terimabarang_modifieddt"
        Me.obj_Terimabarang_modifieddt.ReadOnly = True
        Me.obj_Terimabarang_modifieddt.Size = New System.Drawing.Size(122, 20)
        Me.obj_Terimabarang_modifieddt.TabIndex = 1
        '
        'lbl_Terimabarang_modifiedby
        '
        Me.lbl_Terimabarang_modifiedby.AutoSize = True
        Me.lbl_Terimabarang_modifiedby.Location = New System.Drawing.Point(12, 56)
        Me.lbl_Terimabarang_modifiedby.Name = "lbl_Terimabarang_modifiedby"
        Me.lbl_Terimabarang_modifiedby.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Terimabarang_modifiedby.TabIndex = 0
        Me.lbl_Terimabarang_modifiedby.Text = "Modified By"
        '
        'lbl_Terimabarang_createdt
        '
        Me.lbl_Terimabarang_createdt.AutoSize = True
        Me.lbl_Terimabarang_createdt.Location = New System.Drawing.Point(12, 34)
        Me.lbl_Terimabarang_createdt.Name = "lbl_Terimabarang_createdt"
        Me.lbl_Terimabarang_createdt.Size = New System.Drawing.Size(64, 13)
        Me.lbl_Terimabarang_createdt.TabIndex = 0
        Me.lbl_Terimabarang_createdt.Text = "Create Date"
        '
        'obj_Terimabarang_createdt
        '
        Me.obj_Terimabarang_createdt.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_createdt.Location = New System.Drawing.Point(109, 31)
        Me.obj_Terimabarang_createdt.Name = "obj_Terimabarang_createdt"
        Me.obj_Terimabarang_createdt.ReadOnly = True
        Me.obj_Terimabarang_createdt.Size = New System.Drawing.Size(122, 20)
        Me.obj_Terimabarang_createdt.TabIndex = 1
        '
        'lbl_Terimabarang_createby
        '
        Me.lbl_Terimabarang_createby.AutoSize = True
        Me.lbl_Terimabarang_createby.Location = New System.Drawing.Point(12, 11)
        Me.lbl_Terimabarang_createby.Name = "lbl_Terimabarang_createby"
        Me.lbl_Terimabarang_createby.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Terimabarang_createby.TabIndex = 0
        Me.lbl_Terimabarang_createby.Text = "Create By"
        '
        'obj_Terimabarang_createby
        '
        Me.obj_Terimabarang_createby.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_createby.Location = New System.Drawing.Point(109, 8)
        Me.obj_Terimabarang_createby.Name = "obj_Terimabarang_createby"
        Me.obj_Terimabarang_createby.ReadOnly = True
        Me.obj_Terimabarang_createby.Size = New System.Drawing.Size(122, 20)
        Me.obj_Terimabarang_createby.TabIndex = 1
        '
        'obj_Terimabarang_cetakbpb
        '
        Me.obj_Terimabarang_cetakbpb.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_cetakbpb.Location = New System.Drawing.Point(335, 201)
        Me.obj_Terimabarang_cetakbpb.Name = "obj_Terimabarang_cetakbpb"
        Me.obj_Terimabarang_cetakbpb.ReadOnly = True
        Me.obj_Terimabarang_cetakbpb.Size = New System.Drawing.Size(49, 20)
        Me.obj_Terimabarang_cetakbpb.TabIndex = 1
        Me.obj_Terimabarang_cetakbpb.Visible = False
        '
        'lbl_Terimabarang_cetakbpb
        '
        Me.lbl_Terimabarang_cetakbpb.AutoSize = True
        Me.lbl_Terimabarang_cetakbpb.Location = New System.Drawing.Point(255, 204)
        Me.lbl_Terimabarang_cetakbpb.Name = "lbl_Terimabarang_cetakbpb"
        Me.lbl_Terimabarang_cetakbpb.Size = New System.Drawing.Size(57, 13)
        Me.lbl_Terimabarang_cetakbpb.TabIndex = 0
        Me.lbl_Terimabarang_cetakbpb.Text = "Cetak BPJ"
        Me.lbl_Terimabarang_cetakbpb.Visible = False
        '
        'obj_Terimabarang_appuser_dt
        '
        Me.obj_Terimabarang_appuser_dt.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_appuser_dt.Location = New System.Drawing.Point(109, 150)
        Me.obj_Terimabarang_appuser_dt.Name = "obj_Terimabarang_appuser_dt"
        Me.obj_Terimabarang_appuser_dt.ReadOnly = True
        Me.obj_Terimabarang_appuser_dt.Size = New System.Drawing.Size(122, 20)
        Me.obj_Terimabarang_appuser_dt.TabIndex = 1
        '
        'lbl_Terimabarang_appspv_dt
        '
        Me.lbl_Terimabarang_appspv_dt.AutoSize = True
        Me.lbl_Terimabarang_appspv_dt.Location = New System.Drawing.Point(255, 56)
        Me.lbl_Terimabarang_appspv_dt.Name = "lbl_Terimabarang_appspv_dt"
        Me.lbl_Terimabarang_appspv_dt.Size = New System.Drawing.Size(74, 13)
        Me.lbl_Terimabarang_appspv_dt.TabIndex = 0
        Me.lbl_Terimabarang_appspv_dt.Text = "App Spv Date"
        '
        'obj_Terimabarang_appspv_dt
        '
        Me.obj_Terimabarang_appspv_dt.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_appspv_dt.Location = New System.Drawing.Point(335, 53)
        Me.obj_Terimabarang_appspv_dt.Name = "obj_Terimabarang_appspv_dt"
        Me.obj_Terimabarang_appspv_dt.ReadOnly = True
        Me.obj_Terimabarang_appspv_dt.Size = New System.Drawing.Size(122, 20)
        Me.obj_Terimabarang_appspv_dt.TabIndex = 1
        '
        'lbl_Terimabarang_appspv_by
        '
        Me.lbl_Terimabarang_appspv_by.AutoSize = True
        Me.lbl_Terimabarang_appspv_by.Location = New System.Drawing.Point(255, 34)
        Me.lbl_Terimabarang_appspv_by.Name = "lbl_Terimabarang_appspv_by"
        Me.lbl_Terimabarang_appspv_by.Size = New System.Drawing.Size(63, 13)
        Me.lbl_Terimabarang_appspv_by.TabIndex = 0
        Me.lbl_Terimabarang_appspv_by.Text = "App Spv By"
        '
        'obj_Terimabarang_appspv_by
        '
        Me.obj_Terimabarang_appspv_by.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_appspv_by.Location = New System.Drawing.Point(335, 31)
        Me.obj_Terimabarang_appspv_by.Name = "obj_Terimabarang_appspv_by"
        Me.obj_Terimabarang_appspv_by.ReadOnly = True
        Me.obj_Terimabarang_appspv_by.Size = New System.Drawing.Size(122, 20)
        Me.obj_Terimabarang_appspv_by.TabIndex = 1
        '
        'obj_Terimabarang_appspv
        '
        Me.obj_Terimabarang_appspv.AutoSize = True
        Me.obj_Terimabarang_appspv.Enabled = False
        Me.obj_Terimabarang_appspv.Location = New System.Drawing.Point(335, 11)
        Me.obj_Terimabarang_appspv.Name = "obj_Terimabarang_appspv"
        Me.obj_Terimabarang_appspv.Size = New System.Drawing.Size(67, 17)
        Me.obj_Terimabarang_appspv.TabIndex = 2
        Me.obj_Terimabarang_appspv.Text = "App Spv"
        Me.obj_Terimabarang_appspv.UseVisualStyleBackColor = True
        '
        'lbl_Terimabarang_appuser_dt
        '
        Me.lbl_Terimabarang_appuser_dt.AutoSize = True
        Me.lbl_Terimabarang_appuser_dt.Location = New System.Drawing.Point(12, 153)
        Me.lbl_Terimabarang_appuser_dt.Name = "lbl_Terimabarang_appuser_dt"
        Me.lbl_Terimabarang_appuser_dt.Size = New System.Drawing.Size(77, 13)
        Me.lbl_Terimabarang_appuser_dt.TabIndex = 0
        Me.lbl_Terimabarang_appuser_dt.Text = "App User Date"
        '
        'lbl_Terimabarang_appuser_by
        '
        Me.lbl_Terimabarang_appuser_by.AutoSize = True
        Me.lbl_Terimabarang_appuser_by.Location = New System.Drawing.Point(12, 130)
        Me.lbl_Terimabarang_appuser_by.Name = "lbl_Terimabarang_appuser_by"
        Me.lbl_Terimabarang_appuser_by.Size = New System.Drawing.Size(66, 13)
        Me.lbl_Terimabarang_appuser_by.TabIndex = 0
        Me.lbl_Terimabarang_appuser_by.Text = "App User By"
        '
        'obj_Terimabarang_appuser_by
        '
        Me.obj_Terimabarang_appuser_by.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_appuser_by.Location = New System.Drawing.Point(109, 127)
        Me.obj_Terimabarang_appuser_by.Name = "obj_Terimabarang_appuser_by"
        Me.obj_Terimabarang_appuser_by.ReadOnly = True
        Me.obj_Terimabarang_appuser_by.Size = New System.Drawing.Size(122, 20)
        Me.obj_Terimabarang_appuser_by.TabIndex = 1
        '
        'obj_Terimabarang_appuser
        '
        Me.obj_Terimabarang_appuser.AutoSize = True
        Me.obj_Terimabarang_appuser.Enabled = False
        Me.obj_Terimabarang_appuser.Location = New System.Drawing.Point(109, 109)
        Me.obj_Terimabarang_appuser.Name = "obj_Terimabarang_appuser"
        Me.obj_Terimabarang_appuser.Size = New System.Drawing.Size(70, 17)
        Me.obj_Terimabarang_appuser.TabIndex = 2
        Me.obj_Terimabarang_appuser.Text = "App User"
        Me.obj_Terimabarang_appuser.UseVisualStyleBackColor = True
        '
        'obj_Terimabarang_appacc_dt
        '
        Me.obj_Terimabarang_appacc_dt.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_appacc_dt.Location = New System.Drawing.Point(335, 150)
        Me.obj_Terimabarang_appacc_dt.Name = "obj_Terimabarang_appacc_dt"
        Me.obj_Terimabarang_appacc_dt.ReadOnly = True
        Me.obj_Terimabarang_appacc_dt.Size = New System.Drawing.Size(122, 20)
        Me.obj_Terimabarang_appacc_dt.TabIndex = 1
        '
        'lbl_Terimabarang_appacc_dt
        '
        Me.lbl_Terimabarang_appacc_dt.AutoSize = True
        Me.lbl_Terimabarang_appacc_dt.Location = New System.Drawing.Point(255, 153)
        Me.lbl_Terimabarang_appacc_dt.Name = "lbl_Terimabarang_appacc_dt"
        Me.lbl_Terimabarang_appacc_dt.Size = New System.Drawing.Size(74, 13)
        Me.lbl_Terimabarang_appacc_dt.TabIndex = 0
        Me.lbl_Terimabarang_appacc_dt.Text = "App Acc Date"
        '
        'lbl_Terimabarang_appacc_by
        '
        Me.lbl_Terimabarang_appacc_by.AutoSize = True
        Me.lbl_Terimabarang_appacc_by.Location = New System.Drawing.Point(255, 130)
        Me.lbl_Terimabarang_appacc_by.Name = "lbl_Terimabarang_appacc_by"
        Me.lbl_Terimabarang_appacc_by.Size = New System.Drawing.Size(63, 13)
        Me.lbl_Terimabarang_appacc_by.TabIndex = 0
        Me.lbl_Terimabarang_appacc_by.Text = "App Acc By"
        '
        'obj_Terimabarang_appacc_by
        '
        Me.obj_Terimabarang_appacc_by.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_appacc_by.Location = New System.Drawing.Point(335, 127)
        Me.obj_Terimabarang_appacc_by.Name = "obj_Terimabarang_appacc_by"
        Me.obj_Terimabarang_appacc_by.ReadOnly = True
        Me.obj_Terimabarang_appacc_by.Size = New System.Drawing.Size(122, 20)
        Me.obj_Terimabarang_appacc_by.TabIndex = 1
        '
        'obj_Terimabarang_appacc
        '
        Me.obj_Terimabarang_appacc.AutoSize = True
        Me.obj_Terimabarang_appacc.Enabled = False
        Me.obj_Terimabarang_appacc.Location = New System.Drawing.Point(335, 109)
        Me.obj_Terimabarang_appacc.Name = "obj_Terimabarang_appacc"
        Me.obj_Terimabarang_appacc.Size = New System.Drawing.Size(67, 17)
        Me.obj_Terimabarang_appacc.TabIndex = 2
        Me.obj_Terimabarang_appacc.Text = "App Acc"
        Me.obj_Terimabarang_appacc.UseVisualStyleBackColor = True
        '
        'ftabDataDetil_jurnal
        '
        Me.ftabDataDetil_jurnal.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabDataDetil_jurnal.Controls.Add(Me.pnlclose3)
        Me.ftabDataDetil_jurnal.Controls.Add(Me.FtabJurnal)
        Me.ftabDataDetil_jurnal.Controls.Add(Me.Panel2)
        Me.ftabDataDetil_jurnal.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_jurnal.Name = "ftabDataDetil_jurnal"
        Me.ftabDataDetil_jurnal.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_jurnal.TabIndex = 2
        Me.ftabDataDetil_jurnal.Text = "Jurnal"
        '
        'pnlclose3
        '
        Me.pnlclose3.BackColor = System.Drawing.Color.White
        Me.pnlclose3.Location = New System.Drawing.Point(395, 79)
        Me.pnlclose3.Name = "pnlclose3"
        Me.pnlclose3.Size = New System.Drawing.Size(198, 28)
        Me.pnlclose3.TabIndex = 367
        '
        'FtabJurnal
        '
        Me.FtabJurnal.Controls.Add(Me.ftabDataDetil_Pembayaran)
        Me.FtabJurnal.Controls.Add(Me.TabPage1)
        Me.FtabJurnal.Controls.Add(Me.ftabDataDetil_Reference)
        Me.FtabJurnal.Controls.Add(Me.ftabDataDetil_Response)
        Me.FtabJurnal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FtabJurnal.Location = New System.Drawing.Point(0, 79)
        Me.FtabJurnal.myBackColor = System.Drawing.Color.WhiteSmoke
        Me.FtabJurnal.Name = "FtabJurnal"
        Me.FtabJurnal.SelectedIndex = 0
        Me.FtabJurnal.Size = New System.Drawing.Size(178, 0)
        Me.FtabJurnal.TabIndex = 352
        '
        'ftabDataDetil_Pembayaran
        '
        Me.ftabDataDetil_Pembayaran.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Pembayaran.Controls.Add(Me.DgvTrnJurnaldetil_Pembayaran)
        Me.ftabDataDetil_Pembayaran.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Pembayaran.Name = "ftabDataDetil_Pembayaran"
        Me.ftabDataDetil_Pembayaran.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Pembayaran.Size = New System.Drawing.Size(170, 0)
        Me.ftabDataDetil_Pembayaran.TabIndex = 4
        Me.ftabDataDetil_Pembayaran.Text = "Penerimaan (D)"
        '
        'DgvTrnJurnaldetil_Pembayaran
        '
        Me.DgvTrnJurnaldetil_Pembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnaldetil_Pembayaran.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnaldetil_Pembayaran.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnJurnaldetil_Pembayaran.Name = "DgvTrnJurnaldetil_Pembayaran"
        Me.DgvTrnJurnaldetil_Pembayaran.Size = New System.Drawing.Size(164, 0)
        Me.DgvTrnJurnaldetil_Pembayaran.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.LavenderBlush
        Me.TabPage1.Controls.Add(Me.Panel5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(184, 0)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pembayaran (K)"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.DgvTrnJurnaldetil)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(178, 0)
        Me.Panel5.TabIndex = 1
        '
        'DgvTrnJurnaldetil
        '
        Me.DgvTrnJurnaldetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnaldetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnaldetil.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnJurnaldetil.Name = "DgvTrnJurnaldetil"
        Me.DgvTrnJurnaldetil.Size = New System.Drawing.Size(178, 0)
        Me.DgvTrnJurnaldetil.TabIndex = 0
        '
        'ftabDataDetil_Reference
        '
        Me.ftabDataDetil_Reference.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabDataDetil_Reference.Controls.Add(Me.DgvTrnJurnalreference)
        Me.ftabDataDetil_Reference.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Reference.Name = "ftabDataDetil_Reference"
        Me.ftabDataDetil_Reference.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Reference.Size = New System.Drawing.Size(184, 0)
        Me.ftabDataDetil_Reference.TabIndex = 1
        Me.ftabDataDetil_Reference.Text = "Reference"
        '
        'DgvTrnJurnalreference
        '
        Me.DgvTrnJurnalreference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnalreference.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnalreference.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnJurnalreference.Name = "DgvTrnJurnalreference"
        Me.DgvTrnJurnalreference.Size = New System.Drawing.Size(178, 0)
        Me.DgvTrnJurnalreference.TabIndex = 1
        '
        'ftabDataDetil_Response
        '
        Me.ftabDataDetil_Response.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabDataDetil_Response.Controls.Add(Me.DgvTrnJurnalresponse)
        Me.ftabDataDetil_Response.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Response.Name = "ftabDataDetil_Response"
        Me.ftabDataDetil_Response.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Response.Size = New System.Drawing.Size(184, 0)
        Me.ftabDataDetil_Response.TabIndex = 2
        Me.ftabDataDetil_Response.Text = "Response"
        '
        'DgvTrnJurnalresponse
        '
        Me.DgvTrnJurnalresponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnalresponse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnalresponse.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnJurnalresponse.Name = "DgvTrnJurnalresponse"
        Me.DgvTrnJurnalresponse.Size = New System.Drawing.Size(178, 0)
        Me.DgvTrnJurnalresponse.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlClose2)
        Me.Panel2.Controls.Add(Me.obj_Jurnal_bookdate)
        Me.Panel2.Controls.Add(Me.lbl_Jurnal_bookdate)
        Me.Panel2.Controls.Add(Me.obj_Currency_id)
        Me.Panel2.Controls.Add(Me.obj_Terimabarang_ppn)
        Me.Panel2.Controls.Add(Me.obj_Terimabarang_pph)
        Me.Panel2.Controls.Add(Me.obj_Terimabarang_disc)
        Me.Panel2.Controls.Add(Me.lbl_Terimabarang_ppn)
        Me.Panel2.Controls.Add(Me.lbl_Terimabarang_disc)
        Me.Panel2.Controls.Add(Me.obj_Terimabarang_foreign)
        Me.Panel2.Controls.Add(Me.lbl_Terimabarang_pph)
        Me.Panel2.Controls.Add(Me.lbl_Terimabarang_foreign)
        Me.Panel2.Controls.Add(Me.lbl_Terimabarang_idrreal)
        Me.Panel2.Controls.Add(Me.lbl_Currency_id)
        Me.Panel2.Controls.Add(Me.obj_Terimabarang_idrreal)
        Me.Panel2.Controls.Add(Me.obj_Terimabarang_foreignrate)
        Me.Panel2.Controls.Add(Me.lbl_Terimabarang_foreignrate)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cbo_periode)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(178, 79)
        Me.Panel2.TabIndex = 351
        '
        'pnlClose2
        '
        Me.pnlClose2.BackColor = System.Drawing.Color.White
        Me.pnlClose2.Location = New System.Drawing.Point(438, 32)
        Me.pnlClose2.Name = "pnlClose2"
        Me.pnlClose2.Size = New System.Drawing.Size(125, 18)
        Me.pnlClose2.TabIndex = 352
        '
        'obj_Jurnal_bookdate
        '
        Me.obj_Jurnal_bookdate.CustomFormat = "dd/MM/yyyy"
        Me.obj_Jurnal_bookdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Jurnal_bookdate.Location = New System.Drawing.Point(238, 51)
        Me.obj_Jurnal_bookdate.Name = "obj_Jurnal_bookdate"
        Me.obj_Jurnal_bookdate.Size = New System.Drawing.Size(100, 20)
        Me.obj_Jurnal_bookdate.TabIndex = 358
        '
        'lbl_Jurnal_bookdate
        '
        Me.lbl_Jurnal_bookdate.AutoSize = True
        Me.lbl_Jurnal_bookdate.Location = New System.Drawing.Point(161, 55)
        Me.lbl_Jurnal_bookdate.Name = "lbl_Jurnal_bookdate"
        Me.lbl_Jurnal_bookdate.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Jurnal_bookdate.TabIndex = 357
        Me.lbl_Jurnal_bookdate.Text = "&Book Date"
        '
        'obj_Currency_id
        '
        Me.obj_Currency_id.Enabled = False
        Me.obj_Currency_id.Items.AddRange(New Object() {"-- Pilih --", "COMPLETE", "INCOMPLETE"})
        Me.obj_Currency_id.Location = New System.Drawing.Point(66, 6)
        Me.obj_Currency_id.Name = "obj_Currency_id"
        Me.obj_Currency_id.Size = New System.Drawing.Size(76, 21)
        Me.obj_Currency_id.TabIndex = 350
        '
        'obj_Terimabarang_ppn
        '
        Me.obj_Terimabarang_ppn.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_ppn.Location = New System.Drawing.Point(437, 30)
        Me.obj_Terimabarang_ppn.Name = "obj_Terimabarang_ppn"
        Me.obj_Terimabarang_ppn.ReadOnly = True
        Me.obj_Terimabarang_ppn.Size = New System.Drawing.Size(117, 20)
        Me.obj_Terimabarang_ppn.TabIndex = 1
        '
        'obj_Terimabarang_pph
        '
        Me.obj_Terimabarang_pph.Location = New System.Drawing.Point(437, 8)
        Me.obj_Terimabarang_pph.Name = "obj_Terimabarang_pph"
        Me.obj_Terimabarang_pph.ReadOnly = True
        Me.obj_Terimabarang_pph.Size = New System.Drawing.Size(117, 20)
        Me.obj_Terimabarang_pph.TabIndex = 1
        '
        'obj_Terimabarang_disc
        '
        Me.obj_Terimabarang_disc.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_disc.Location = New System.Drawing.Point(593, 8)
        Me.obj_Terimabarang_disc.Name = "obj_Terimabarang_disc"
        Me.obj_Terimabarang_disc.ReadOnly = True
        Me.obj_Terimabarang_disc.Size = New System.Drawing.Size(118, 20)
        Me.obj_Terimabarang_disc.TabIndex = 1
        '
        'lbl_Terimabarang_ppn
        '
        Me.lbl_Terimabarang_ppn.AutoSize = True
        Me.lbl_Terimabarang_ppn.Location = New System.Drawing.Point(365, 34)
        Me.lbl_Terimabarang_ppn.Name = "lbl_Terimabarang_ppn"
        Me.lbl_Terimabarang_ppn.Size = New System.Drawing.Size(68, 13)
        Me.lbl_Terimabarang_ppn.TabIndex = 0
        Me.lbl_Terimabarang_ppn.Text = "PPN Amount"
        '
        'lbl_Terimabarang_disc
        '
        Me.lbl_Terimabarang_disc.AutoSize = True
        Me.lbl_Terimabarang_disc.Location = New System.Drawing.Point(559, 11)
        Me.lbl_Terimabarang_disc.Name = "lbl_Terimabarang_disc"
        Me.lbl_Terimabarang_disc.Size = New System.Drawing.Size(28, 13)
        Me.lbl_Terimabarang_disc.TabIndex = 0
        Me.lbl_Terimabarang_disc.Text = "Disc"
        '
        'obj_Terimabarang_foreign
        '
        Me.obj_Terimabarang_foreign.Location = New System.Drawing.Point(237, 8)
        Me.obj_Terimabarang_foreign.Name = "obj_Terimabarang_foreign"
        Me.obj_Terimabarang_foreign.ReadOnly = True
        Me.obj_Terimabarang_foreign.Size = New System.Drawing.Size(116, 20)
        Me.obj_Terimabarang_foreign.TabIndex = 1
        '
        'lbl_Terimabarang_pph
        '
        Me.lbl_Terimabarang_pph.AutoSize = True
        Me.lbl_Terimabarang_pph.Location = New System.Drawing.Point(365, 11)
        Me.lbl_Terimabarang_pph.Name = "lbl_Terimabarang_pph"
        Me.lbl_Terimabarang_pph.Size = New System.Drawing.Size(66, 13)
        Me.lbl_Terimabarang_pph.TabIndex = 0
        Me.lbl_Terimabarang_pph.Text = "PPh Amount"
        '
        'lbl_Terimabarang_foreign
        '
        Me.lbl_Terimabarang_foreign.AutoSize = True
        Me.lbl_Terimabarang_foreign.Location = New System.Drawing.Point(160, 11)
        Me.lbl_Terimabarang_foreign.Name = "lbl_Terimabarang_foreign"
        Me.lbl_Terimabarang_foreign.Size = New System.Drawing.Size(43, 13)
        Me.lbl_Terimabarang_foreign.TabIndex = 0
        Me.lbl_Terimabarang_foreign.Text = "Amount"
        '
        'lbl_Terimabarang_idrreal
        '
        Me.lbl_Terimabarang_idrreal.AutoSize = True
        Me.lbl_Terimabarang_idrreal.Location = New System.Drawing.Point(160, 32)
        Me.lbl_Terimabarang_idrreal.Name = "lbl_Terimabarang_idrreal"
        Me.lbl_Terimabarang_idrreal.Size = New System.Drawing.Size(71, 13)
        Me.lbl_Terimabarang_idrreal.TabIndex = 0
        Me.lbl_Terimabarang_idrreal.Text = "Amount (IDR)"
        '
        'lbl_Currency_id
        '
        Me.lbl_Currency_id.AutoSize = True
        Me.lbl_Currency_id.Location = New System.Drawing.Point(11, 10)
        Me.lbl_Currency_id.Name = "lbl_Currency_id"
        Me.lbl_Currency_id.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Currency_id.TabIndex = 0
        Me.lbl_Currency_id.Text = "Currency"
        '
        'obj_Terimabarang_idrreal
        '
        Me.obj_Terimabarang_idrreal.Location = New System.Drawing.Point(237, 30)
        Me.obj_Terimabarang_idrreal.Name = "obj_Terimabarang_idrreal"
        Me.obj_Terimabarang_idrreal.ReadOnly = True
        Me.obj_Terimabarang_idrreal.Size = New System.Drawing.Size(116, 20)
        Me.obj_Terimabarang_idrreal.TabIndex = 1
        '
        'obj_Terimabarang_foreignrate
        '
        Me.obj_Terimabarang_foreignrate.Location = New System.Drawing.Point(66, 29)
        Me.obj_Terimabarang_foreignrate.Name = "obj_Terimabarang_foreignrate"
        Me.obj_Terimabarang_foreignrate.ReadOnly = True
        Me.obj_Terimabarang_foreignrate.Size = New System.Drawing.Size(76, 20)
        Me.obj_Terimabarang_foreignrate.TabIndex = 1
        '
        'lbl_Terimabarang_foreignrate
        '
        Me.lbl_Terimabarang_foreignrate.AutoSize = True
        Me.lbl_Terimabarang_foreignrate.Location = New System.Drawing.Point(11, 32)
        Me.lbl_Terimabarang_foreignrate.Name = "lbl_Terimabarang_foreignrate"
        Me.lbl_Terimabarang_foreignrate.Size = New System.Drawing.Size(30, 13)
        Me.lbl_Terimabarang_foreignrate.TabIndex = 0
        Me.lbl_Terimabarang_foreignrate.Text = "Rate"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(366, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 359
        Me.Label1.Text = "&Period"
        '
        'cbo_periode
        '
        Me.cbo_periode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbo_periode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_periode.BackColor = System.Drawing.Color.Honeydew
        Me.cbo_periode.FormattingEnabled = True
        Me.cbo_periode.Location = New System.Drawing.Point(437, 51)
        Me.cbo_periode.Name = "cbo_periode"
        Me.cbo_periode.Size = New System.Drawing.Size(176, 21)
        Me.cbo_periode.TabIndex = 360
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.Controls.Add(Me.obj_terimabarang_tglsuratjalan)
        Me.PnlDataMaster.Controls.Add(Me.Label7)
        Me.PnlDataMaster.Controls.Add(Me.obj_strukturunit_name)
        Me.PnlDataMaster.Controls.Add(Me.Label3)
        Me.PnlDataMaster.Controls.Add(Me.obj_Employee_id_owner)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_status)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_statusrealization)
        Me.PnlDataMaster.Controls.Add(Me.obj_Budget_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.btn_order)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimabarang_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimabarang_date)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_type)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimabarang_type)
        Me.PnlDataMaster.Controls.Add(Me.obj_Order_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Order_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Budget_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Employee_id_owner)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_qtyitem)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimabarang_qtyitem)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_qtyrealization)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimabarang_qtyrealization)
        Me.PnlDataMaster.Controls.Add(Me.obj_Order_qty)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Order_qty)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimabarang_status)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimabarang_statusrealization)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_location)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimabarang_location)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_notes)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimabarang_notes)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_nosuratjalan)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimabarang_nosuratjalan)
        Me.PnlDataMaster.Controls.Add(Me.obj_Channel_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Channel_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_date)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 217)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_terimabarang_tglsuratjalan
        '
        Me.obj_terimabarang_tglsuratjalan.EditValue = Nothing
        Me.obj_terimabarang_tglsuratjalan.Location = New System.Drawing.Point(119, 152)
        Me.obj_terimabarang_tglsuratjalan.Name = "obj_terimabarang_tglsuratjalan"
        Me.obj_terimabarang_tglsuratjalan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.obj_terimabarang_tglsuratjalan.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.obj_terimabarang_tglsuratjalan.Size = New System.Drawing.Size(100, 20)
        Me.obj_terimabarang_tglsuratjalan.TabIndex = 372
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 369
        Me.Label7.Text = "Delivery Order Date"
        '
        'obj_strukturunit_name
        '
        Me.obj_strukturunit_name.Location = New System.Drawing.Point(441, 174)
        Me.obj_strukturunit_name.Name = "obj_strukturunit_name"
        Me.obj_strukturunit_name.ReadOnly = True
        Me.obj_strukturunit_name.Size = New System.Drawing.Size(272, 20)
        Me.obj_strukturunit_name.TabIndex = 367
        Me.obj_strukturunit_name.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(370, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 366
        Me.Label3.Text = "Department"
        '
        'obj_Employee_id_owner
        '
        Me.obj_Employee_id_owner.Location = New System.Drawing.Point(441, 61)
        Me.obj_Employee_id_owner.Name = "obj_Employee_id_owner"
        Me.obj_Employee_id_owner.Size = New System.Drawing.Size(217, 21)
        Me.obj_Employee_id_owner.TabIndex = 365
        '
        'obj_Terimabarang_status
        '
        Me.obj_Terimabarang_status.Enabled = False
        Me.obj_Terimabarang_status.Items.AddRange(New Object() {"-- Pilih --", "COMPLETE", "INCOMPLETE"})
        Me.obj_Terimabarang_status.Location = New System.Drawing.Point(119, 83)
        Me.obj_Terimabarang_status.Name = "obj_Terimabarang_status"
        Me.obj_Terimabarang_status.Size = New System.Drawing.Size(94, 21)
        Me.obj_Terimabarang_status.TabIndex = 364
        '
        'obj_Terimabarang_statusrealization
        '
        Me.obj_Terimabarang_statusrealization.Items.AddRange(New Object() {"-- Pilih --", "Telat & Sesuai", "Telat & Tidak Sesuai", "Tepat Waktu & Sesuai", "Tepat Waktu & Tidak Sesuai"})
        Me.obj_Terimabarang_statusrealization.Location = New System.Drawing.Point(119, 106)
        Me.obj_Terimabarang_statusrealization.Name = "obj_Terimabarang_statusrealization"
        Me.obj_Terimabarang_statusrealization.Size = New System.Drawing.Size(164, 21)
        Me.obj_Terimabarang_statusrealization.TabIndex = 363
        '
        'obj_Budget_id
        '
        Me.obj_Budget_id.Enabled = False
        Me.obj_Budget_id.Location = New System.Drawing.Point(441, 105)
        Me.obj_Budget_id.Name = "obj_Budget_id"
        Me.obj_Budget_id.Size = New System.Drawing.Size(217, 21)
        Me.obj_Budget_id.TabIndex = 362
        '
        'obj_Rekanan_id
        '
        Me.obj_Rekanan_id.Location = New System.Drawing.Point(441, 38)
        Me.obj_Rekanan_id.Name = "obj_Rekanan_id"
        Me.obj_Rekanan_id.Size = New System.Drawing.Size(272, 21)
        Me.obj_Rekanan_id.TabIndex = 360
        '
        'btn_order
        '
        Me.btn_order.BackColor = System.Drawing.Color.AntiqueWhite
        Me.btn_order.Font = New System.Drawing.Font("Verdana", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_order.ForeColor = System.Drawing.Color.Red
        Me.btn_order.Location = New System.Drawing.Point(219, 63)
        Me.btn_order.Name = "btn_order"
        Me.btn_order.Size = New System.Drawing.Size(28, 19)
        Me.btn_order.TabIndex = 348
        Me.btn_order.TabStop = False
        Me.btn_order.Text = "PO"
        Me.btn_order.UseVisualStyleBackColor = False
        '
        'obj_Terimabarang_id
        '
        Me.obj_Terimabarang_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_id.Location = New System.Drawing.Point(119, 7)
        Me.obj_Terimabarang_id.Name = "obj_Terimabarang_id"
        Me.obj_Terimabarang_id.ReadOnly = True
        Me.obj_Terimabarang_id.Size = New System.Drawing.Size(94, 20)
        Me.obj_Terimabarang_id.TabIndex = 1
        '
        'lbl_Terimabarang_id
        '
        Me.lbl_Terimabarang_id.AutoSize = True
        Me.lbl_Terimabarang_id.Location = New System.Drawing.Point(17, 10)
        Me.lbl_Terimabarang_id.Name = "lbl_Terimabarang_id"
        Me.lbl_Terimabarang_id.Size = New System.Drawing.Size(67, 13)
        Me.lbl_Terimabarang_id.TabIndex = 0
        Me.lbl_Terimabarang_id.Text = "Receive No."
        '
        'lbl_Terimabarang_date
        '
        Me.lbl_Terimabarang_date.AutoSize = True
        Me.lbl_Terimabarang_date.Location = New System.Drawing.Point(73, 10)
        Me.lbl_Terimabarang_date.Name = "lbl_Terimabarang_date"
        Me.lbl_Terimabarang_date.Size = New System.Drawing.Size(73, 13)
        Me.lbl_Terimabarang_date.TabIndex = 0
        Me.lbl_Terimabarang_date.Text = "Receive Date"
        Me.lbl_Terimabarang_date.Visible = False
        '
        'obj_Terimabarang_type
        '
        Me.obj_Terimabarang_type.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_type.Location = New System.Drawing.Point(119, 39)
        Me.obj_Terimabarang_type.Name = "obj_Terimabarang_type"
        Me.obj_Terimabarang_type.ReadOnly = True
        Me.obj_Terimabarang_type.Size = New System.Drawing.Size(94, 20)
        Me.obj_Terimabarang_type.TabIndex = 1
        '
        'lbl_Terimabarang_type
        '
        Me.lbl_Terimabarang_type.AutoSize = True
        Me.lbl_Terimabarang_type.Location = New System.Drawing.Point(17, 42)
        Me.lbl_Terimabarang_type.Name = "lbl_Terimabarang_type"
        Me.lbl_Terimabarang_type.Size = New System.Drawing.Size(74, 13)
        Me.lbl_Terimabarang_type.TabIndex = 0
        Me.lbl_Terimabarang_type.Text = "Receive Type"
        '
        'obj_Order_id
        '
        Me.obj_Order_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Order_id.Location = New System.Drawing.Point(119, 61)
        Me.obj_Order_id.Name = "obj_Order_id"
        Me.obj_Order_id.ReadOnly = True
        Me.obj_Order_id.Size = New System.Drawing.Size(94, 20)
        Me.obj_Order_id.TabIndex = 1
        '
        'lbl_Order_id
        '
        Me.lbl_Order_id.AutoSize = True
        Me.lbl_Order_id.Location = New System.Drawing.Point(17, 64)
        Me.lbl_Order_id.Name = "lbl_Order_id"
        Me.lbl_Order_id.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Order_id.TabIndex = 0
        Me.lbl_Order_id.Text = "Order No."
        '
        'lbl_Budget_id
        '
        Me.lbl_Budget_id.AutoSize = True
        Me.lbl_Budget_id.Location = New System.Drawing.Point(370, 109)
        Me.lbl_Budget_id.Name = "lbl_Budget_id"
        Me.lbl_Budget_id.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Budget_id.TabIndex = 0
        Me.lbl_Budget_id.Text = "Budget"
        '
        'lbl_Rekanan_id
        '
        Me.lbl_Rekanan_id.AutoSize = True
        Me.lbl_Rekanan_id.Location = New System.Drawing.Point(370, 42)
        Me.lbl_Rekanan_id.Name = "lbl_Rekanan_id"
        Me.lbl_Rekanan_id.Size = New System.Drawing.Size(51, 13)
        Me.lbl_Rekanan_id.TabIndex = 0
        Me.lbl_Rekanan_id.Text = "Rekanan"
        '
        'lbl_Employee_id_owner
        '
        Me.lbl_Employee_id_owner.AutoSize = True
        Me.lbl_Employee_id_owner.Location = New System.Drawing.Point(370, 65)
        Me.lbl_Employee_id_owner.Name = "lbl_Employee_id_owner"
        Me.lbl_Employee_id_owner.Size = New System.Drawing.Size(68, 13)
        Me.lbl_Employee_id_owner.TabIndex = 0
        Me.lbl_Employee_id_owner.Text = "Received By"
        '
        'obj_Terimabarang_qtyitem
        '
        Me.obj_Terimabarang_qtyitem.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_qtyitem.Location = New System.Drawing.Point(441, 7)
        Me.obj_Terimabarang_qtyitem.Name = "obj_Terimabarang_qtyitem"
        Me.obj_Terimabarang_qtyitem.ReadOnly = True
        Me.obj_Terimabarang_qtyitem.Size = New System.Drawing.Size(51, 20)
        Me.obj_Terimabarang_qtyitem.TabIndex = 1
        '
        'lbl_Terimabarang_qtyitem
        '
        Me.lbl_Terimabarang_qtyitem.AutoSize = True
        Me.lbl_Terimabarang_qtyitem.Location = New System.Drawing.Point(370, 10)
        Me.lbl_Terimabarang_qtyitem.Name = "lbl_Terimabarang_qtyitem"
        Me.lbl_Terimabarang_qtyitem.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Terimabarang_qtyitem.TabIndex = 0
        Me.lbl_Terimabarang_qtyitem.Text = "Qty Item"
        '
        'obj_Terimabarang_qtyrealization
        '
        Me.obj_Terimabarang_qtyrealization.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_qtyrealization.Location = New System.Drawing.Point(119, 178)
        Me.obj_Terimabarang_qtyrealization.Name = "obj_Terimabarang_qtyrealization"
        Me.obj_Terimabarang_qtyrealization.ReadOnly = True
        Me.obj_Terimabarang_qtyrealization.Size = New System.Drawing.Size(55, 20)
        Me.obj_Terimabarang_qtyrealization.TabIndex = 1
        '
        'lbl_Terimabarang_qtyrealization
        '
        Me.lbl_Terimabarang_qtyrealization.AutoSize = True
        Me.lbl_Terimabarang_qtyrealization.Location = New System.Drawing.Point(17, 181)
        Me.lbl_Terimabarang_qtyrealization.Name = "lbl_Terimabarang_qtyrealization"
        Me.lbl_Terimabarang_qtyrealization.Size = New System.Drawing.Size(78, 13)
        Me.lbl_Terimabarang_qtyrealization.TabIndex = 0
        Me.lbl_Terimabarang_qtyrealization.Text = "Qty Realization"
        '
        'obj_Order_qty
        '
        Me.obj_Order_qty.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Order_qty.Location = New System.Drawing.Point(247, 178)
        Me.obj_Order_qty.Name = "obj_Order_qty"
        Me.obj_Order_qty.ReadOnly = True
        Me.obj_Order_qty.Size = New System.Drawing.Size(42, 20)
        Me.obj_Order_qty.TabIndex = 1
        '
        'lbl_Order_qty
        '
        Me.lbl_Order_qty.AutoSize = True
        Me.lbl_Order_qty.Location = New System.Drawing.Point(189, 181)
        Me.lbl_Order_qty.Name = "lbl_Order_qty"
        Me.lbl_Order_qty.Size = New System.Drawing.Size(52, 13)
        Me.lbl_Order_qty.TabIndex = 0
        Me.lbl_Order_qty.Text = "Qty Order"
        '
        'lbl_Terimabarang_status
        '
        Me.lbl_Terimabarang_status.AutoSize = True
        Me.lbl_Terimabarang_status.Location = New System.Drawing.Point(17, 86)
        Me.lbl_Terimabarang_status.Name = "lbl_Terimabarang_status"
        Me.lbl_Terimabarang_status.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Terimabarang_status.TabIndex = 0
        Me.lbl_Terimabarang_status.Text = "Status"
        '
        'lbl_Terimabarang_statusrealization
        '
        Me.lbl_Terimabarang_statusrealization.AutoSize = True
        Me.lbl_Terimabarang_statusrealization.Location = New System.Drawing.Point(17, 108)
        Me.lbl_Terimabarang_statusrealization.Name = "lbl_Terimabarang_statusrealization"
        Me.lbl_Terimabarang_statusrealization.Size = New System.Drawing.Size(92, 13)
        Me.lbl_Terimabarang_statusrealization.TabIndex = 0
        Me.lbl_Terimabarang_statusrealization.Text = "Realization Status"
        '
        'obj_Terimabarang_location
        '
        Me.obj_Terimabarang_location.Location = New System.Drawing.Point(441, 83)
        Me.obj_Terimabarang_location.Name = "obj_Terimabarang_location"
        Me.obj_Terimabarang_location.Size = New System.Drawing.Size(272, 20)
        Me.obj_Terimabarang_location.TabIndex = 1
        '
        'lbl_Terimabarang_location
        '
        Me.lbl_Terimabarang_location.AutoSize = True
        Me.lbl_Terimabarang_location.Location = New System.Drawing.Point(370, 86)
        Me.lbl_Terimabarang_location.Name = "lbl_Terimabarang_location"
        Me.lbl_Terimabarang_location.Size = New System.Drawing.Size(48, 13)
        Me.lbl_Terimabarang_location.TabIndex = 0
        Me.lbl_Terimabarang_location.Text = "Location"
        '
        'obj_Terimabarang_notes
        '
        Me.obj_Terimabarang_notes.Location = New System.Drawing.Point(441, 130)
        Me.obj_Terimabarang_notes.Multiline = True
        Me.obj_Terimabarang_notes.Name = "obj_Terimabarang_notes"
        Me.obj_Terimabarang_notes.Size = New System.Drawing.Size(272, 42)
        Me.obj_Terimabarang_notes.TabIndex = 1
        '
        'lbl_Terimabarang_notes
        '
        Me.lbl_Terimabarang_notes.AutoSize = True
        Me.lbl_Terimabarang_notes.Location = New System.Drawing.Point(370, 133)
        Me.lbl_Terimabarang_notes.Name = "lbl_Terimabarang_notes"
        Me.lbl_Terimabarang_notes.Size = New System.Drawing.Size(35, 13)
        Me.lbl_Terimabarang_notes.TabIndex = 0
        Me.lbl_Terimabarang_notes.Text = "Notes"
        '
        'obj_Terimabarang_nosuratjalan
        '
        Me.obj_Terimabarang_nosuratjalan.Location = New System.Drawing.Point(119, 130)
        Me.obj_Terimabarang_nosuratjalan.Name = "obj_Terimabarang_nosuratjalan"
        Me.obj_Terimabarang_nosuratjalan.Size = New System.Drawing.Size(100, 20)
        Me.obj_Terimabarang_nosuratjalan.TabIndex = 1
        '
        'lbl_Terimabarang_nosuratjalan
        '
        Me.lbl_Terimabarang_nosuratjalan.AutoSize = True
        Me.lbl_Terimabarang_nosuratjalan.Location = New System.Drawing.Point(17, 133)
        Me.lbl_Terimabarang_nosuratjalan.Name = "lbl_Terimabarang_nosuratjalan"
        Me.lbl_Terimabarang_nosuratjalan.Size = New System.Drawing.Size(94, 13)
        Me.lbl_Terimabarang_nosuratjalan.TabIndex = 0
        Me.lbl_Terimabarang_nosuratjalan.Text = "Delivery Order No."
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Channel_id.Location = New System.Drawing.Point(558, 7)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.ReadOnly = True
        Me.obj_Channel_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Channel_id.TabIndex = 1
        '
        'lbl_Channel_id
        '
        Me.lbl_Channel_id.AutoSize = True
        Me.lbl_Channel_id.Location = New System.Drawing.Point(506, 10)
        Me.lbl_Channel_id.Name = "lbl_Channel_id"
        Me.lbl_Channel_id.Size = New System.Drawing.Size(51, 13)
        Me.lbl_Channel_id.TabIndex = 0
        Me.lbl_Channel_id.Text = "Company"
        '
        'obj_Terimabarang_date
        '
        Me.obj_Terimabarang_date.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_date.Location = New System.Drawing.Point(137, 7)
        Me.obj_Terimabarang_date.Mask = "00/00/0000"
        Me.obj_Terimabarang_date.Name = "obj_Terimabarang_date"
        Me.obj_Terimabarang_date.ReadOnly = True
        Me.obj_Terimabarang_date.Size = New System.Drawing.Size(73, 20)
        Me.obj_Terimabarang_date.TabIndex = 42
        Me.obj_Terimabarang_date.TabStop = False
        '
        'BackgroundWorker1
        '
        '
        'pnlDetil
        '
        Me.pnlDetil.BackColor = System.Drawing.Color.OldLace
        Me.pnlDetil.Controls.Add(Me.FlatTabControl1)
        Me.pnlDetil.Location = New System.Drawing.Point(628, 28)
        Me.pnlDetil.Name = "pnlDetil"
        Me.pnlDetil.Size = New System.Drawing.Size(977, 591)
        Me.pnlDetil.TabIndex = 2
        Me.pnlDetil.Visible = False
        '
        'FlatTabControl1
        '
        Me.FlatTabControl1.Controls.Add(Me.TabDetail)
        Me.FlatTabControl1.Controls.Add(Me.TabAccounting)
        Me.FlatTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlatTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlatTabControl1.myBackColor = System.Drawing.SystemColors.Control
        Me.FlatTabControl1.Name = "FlatTabControl1"
        Me.FlatTabControl1.SelectedIndex = 0
        Me.FlatTabControl1.Size = New System.Drawing.Size(977, 591)
        Me.FlatTabControl1.TabIndex = 448
        '
        'TabDetail
        '
        Me.TabDetail.Controls.Add(Me.Panel3)
        Me.TabDetail.Location = New System.Drawing.Point(4, 25)
        Me.TabDetail.Name = "TabDetail"
        Me.TabDetail.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDetail.Size = New System.Drawing.Size(969, 562)
        Me.TabDetail.TabIndex = 0
        Me.TabDetail.Text = "Detail"
        Me.TabDetail.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_golfiskal)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.btnCaptureCancel)
        Me.Panel3.Controls.Add(Me.btnCapture)
        Me.Panel3.Controls.Add(Me.PnlFoto)
        Me.Panel3.Controls.Add(Me.obj_budgetdetil_name)
        Me.Panel3.Controls.Add(Me.btnItemCategorySelect)
        Me.Panel3.Controls.Add(Me.btnItemSelect)
        Me.Panel3.Controls.Add(Me.btnCategory)
        Me.Panel3.Controls.Add(Me.btnSerial)
        Me.Panel3.Controls.Add(Me.obj_budget_name)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.lblQtyTotal)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_depre_enddt)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_qtytotal)
        Me.Panel3.Controls.Add(Me.lbl_Acc_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_product_no)
        Me.Panel3.Controls.Add(Me.obj_Acc_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_qtydetail)
        Me.Panel3.Controls.Add(Me.obj_Orderdetil_line)
        Me.Panel3.Controls.Add(Me.btn_Parent)
        Me.Panel3.Controls.Add(Me.lbl_Orderdetil_line)
        Me.Panel3.Controls.Add(Me.lblQtyDetail)
        Me.Panel3.Controls.Add(Me.obj_Orderdetil_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_line)
        Me.Panel3.Controls.Add(Me.lbl_Orderdetil_id)
        Me.Panel3.Controls.Add(Me.obj_Itemtype_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarang_parentbarcode)
        Me.Panel3.Controls.Add(Me.lbl_Unit_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarang_barcode)
        Me.Panel3.Controls.Add(Me.obj_Unit_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_eps)
        Me.Panel3.Controls.Add(Me.lbl_Asset_barcode)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_eps)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_qty)
        Me.Panel3.Controls.Add(Me.lbl_Show_id_cont)
        Me.Panel3.Controls.Add(Me.lbl_Asset_barcodeinduk)
        Me.Panel3.Controls.Add(Me.obj_Show_id_cont)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_qty)
        Me.Panel3.Controls.Add(Me.lbl_Show_id)
        Me.Panel3.Controls.Add(Me.obj_Show_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_desc)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_depre_enddt)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_rack)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_desc)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_rack)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_lineparent)
        Me.Panel3.Controls.Add(Me.lbl_Room_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_parentline)
        Me.Panel3.Controls.Add(Me.obj_Room_id)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_line)
        Me.Panel3.Controls.Add(Me.lbl_Sex_id)
        Me.Panel3.Controls.Add(Me.obj_asset_terimabarangdetil_id)
        Me.Panel3.Controls.Add(Me.obj_Sex_id)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_id)
        Me.Panel3.Controls.Add(Me.lbl_Size_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_nonfixasset)
        Me.Panel3.Controls.Add(Me.obj_Size_id)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_product_no)
        Me.Panel3.Controls.Add(Me.lbl_Colour_id)
        Me.Panel3.Controls.Add(Me.obj_Assettype_id)
        Me.Panel3.Controls.Add(Me.obj_Colour_id)
        Me.Panel3.Controls.Add(Me.lbl_Tipeasset_id)
        Me.Panel3.Controls.Add(Me.lbl_Material_id)
        Me.Panel3.Controls.Add(Me.lbl_Kategoriasset_id)
        Me.Panel3.Controls.Add(Me.obj_Material_id)
        Me.Panel3.Controls.Add(Me.obj_Assetcategory_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_model)
        Me.Panel3.Controls.Add(Me.lbl_Item_id)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_model)
        Me.Panel3.Controls.Add(Me.obj_Item_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_serial_no)
        Me.Panel3.Controls.Add(Me.obj_Itemcategory_id)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_serial_no)
        Me.Panel3.Controls.Add(Me.lbl_Itemcategory_id)
        Me.Panel3.Controls.Add(Me.lbl_brand_id)
        Me.Panel3.Controls.Add(Me.lbl_Itemtype_id)
        Me.Panel3.Controls.Add(Me.obj_Brand_id)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(963, 556)
        Me.Panel3.TabIndex = 447
        '
        'obj_Terimabarangdetil_golfiskal
        '
        Me.obj_Terimabarangdetil_golfiskal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Terimabarangdetil_golfiskal.FormattingEnabled = True
        Me.obj_Terimabarangdetil_golfiskal.Location = New System.Drawing.Point(95, 138)
        Me.obj_Terimabarangdetil_golfiskal.Name = "obj_Terimabarangdetil_golfiskal"
        Me.obj_Terimabarangdetil_golfiskal.Size = New System.Drawing.Size(162, 21)
        Me.obj_Terimabarangdetil_golfiskal.TabIndex = 488
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 487
        Me.Label2.Text = "Asset Cat.Depre"
        '
        'btnCaptureCancel
        '
        Me.btnCaptureCancel.Location = New System.Drawing.Point(732, 301)
        Me.btnCaptureCancel.Name = "btnCaptureCancel"
        Me.btnCaptureCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCaptureCancel.TabIndex = 486
        Me.btnCaptureCancel.Text = "Cancel"
        Me.btnCaptureCancel.UseVisualStyleBackColor = True
        Me.btnCaptureCancel.Visible = False
        '
        'btnCapture
        '
        Me.btnCapture.Location = New System.Drawing.Point(586, 301)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(143, 23)
        Me.btnCapture.TabIndex = 485
        Me.btnCapture.Text = "Start Preview"
        Me.btnCapture.UseVisualStyleBackColor = True
        '
        'PnlFoto
        '
        Me.PnlFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlFoto.Controls.Add(Me.obj_photo)
        Me.PnlFoto.Controls.Add(Me.VideoCapture)
        Me.PnlFoto.Location = New System.Drawing.Point(587, 12)
        Me.PnlFoto.Name = "PnlFoto"
        Me.PnlFoto.Padding = New System.Windows.Forms.Padding(3)
        Me.PnlFoto.Size = New System.Drawing.Size(373, 286)
        Me.PnlFoto.TabIndex = 484
        '
        'obj_photo
        '
        Me.obj_photo.BackColor = System.Drawing.Color.DimGray
        Me.obj_photo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.obj_photo.Location = New System.Drawing.Point(31, 49)
        Me.obj_photo.Name = "obj_photo"
        Me.obj_photo.Size = New System.Drawing.Size(159, 102)
        Me.obj_photo.TabIndex = 487
        Me.obj_photo.TabStop = False
        '
        'VideoCapture
        '
        Me.VideoCapture.AdjustOverlayAspectRatio = True
        Me.VideoCapture.AdjustPixelAspectRatio = True
        Me.VideoCapture.Aero = VidGrab.TAero.ae_Default
        Me.VideoCapture.AnalogVideoStandard = -1
        Me.VideoCapture.ApplicationPriority = VidGrab.TApplicationPriority.ap_default
        Me.VideoCapture.ASFAudioBitRate = -1
        Me.VideoCapture.ASFAudioChannels = -1
        Me.VideoCapture.ASFBufferWindow = -1
        Me.VideoCapture.ASFDeinterlaceMode = VidGrab.TASFDeinterlaceMode.adm_NotInterlaced
        Me.VideoCapture.ASFFixedFrameRate = True
        Me.VideoCapture.ASFMediaServerPublishingPoint = ""
        Me.VideoCapture.ASFMediaServerRemovePublishingPointAfterDisconnect = False
        Me.VideoCapture.ASFMediaServerTemplatePublishingPoint = ""
        Me.VideoCapture.ASFNetworkMaxUsers = 5
        Me.VideoCapture.ASFNetworkPort = 0
        Me.VideoCapture.ASFProfile = -1
        Me.VideoCapture.ASFProfileFromCustomFile = ""
        Me.VideoCapture.ASFProfileVersion = VidGrab.TASFProfileVersion.apv_ProfileVersion_8
        Me.VideoCapture.ASFVideoBitRate = -1
        Me.VideoCapture.ASFVideoFrameRate = 0.0R
        Me.VideoCapture.ASFVideoHeight = -1
        Me.VideoCapture.ASFVideoMaxKeyFrameSpacing = -1
        Me.VideoCapture.ASFVideoQuality = 80
        Me.VideoCapture.ASFVideoWidth = -1
        Me.VideoCapture.AspectRatioToUse = -1.0R
        Me.VideoCapture.AssociateAudioAndVideoDevices = False
        Me.VideoCapture.AudioBalance = 0
        Me.VideoCapture.AudioChannelRenderMode = VidGrab.TAudioChannelRenderMode.acrm_Normal
        Me.VideoCapture.AudioCompressor = 0
        Me.VideoCapture.AudioDevice = -1
        Me.VideoCapture.AudioDeviceRendering = False
        Me.VideoCapture.AudioFormat = VidGrab.TAudioFormat.af_default
        Me.VideoCapture.AudioInput = -1
        Me.VideoCapture.AudioInputBalance = 0
        Me.VideoCapture.AudioInputLevel = 65535
        Me.VideoCapture.AudioInputMono = False
        Me.VideoCapture.AudioPeakEvent = False
        Me.VideoCapture.AudioRecording = False
        Me.VideoCapture.AudioRenderer = -1
        Me.VideoCapture.AudioSource = VidGrab.TAudioSource.as_Default
        Me.VideoCapture.AudioStreamNumber = -1
        Me.VideoCapture.AudioSyncAdjustment = 0
        Me.VideoCapture.AudioSyncAdjustmentEnabled = False
        Me.VideoCapture.AudioVolume = 32767
        Me.VideoCapture.AutoConnectRelatedPins = True
        Me.VideoCapture.AutoFileName = VidGrab.TAutoFileName.fn_Sequential
        Me.VideoCapture.AutoFileNameDateTimeFormat = "yymmdd_hhmmss_zzz"
        Me.VideoCapture.AutoFileNameMinDigits = 6
        Me.VideoCapture.AutoFilePrefix = "vg"
        Me.VideoCapture.AutoRefreshPreview = False
        Me.VideoCapture.AutoStartPlayer = True
        Me.VideoCapture.AVIDurationUpdated = True
        Me.VideoCapture.AVIFormatOpenDML = True
        Me.VideoCapture.AVIFormatOpenDMLCompatibilityIndex = True
        Me.VideoCapture.BackColor = System.Drawing.Color.DarkGray
        Me.VideoCapture.BackgroundColor = 0
        Me.VideoCapture.BufferCount = -1
        Me.VideoCapture.BurstCount = 3
        Me.VideoCapture.BurstInterval = 0
        Me.VideoCapture.BurstMode = False
        Me.VideoCapture.BurstType = VidGrab.TFrameCaptureDest.fc_JpegFile
        Me.VideoCapture.BusyCursor = VidGrab.TCursors.cr_HourGlass
        Me.VideoCapture.CameraControlSettings = True
        Me.VideoCapture.CaptureFileExt = ""
        Me.VideoCapture.ColorKey = 1048592
        Me.VideoCapture.ColorKeyEnabled = False
        Me.VideoCapture.CompressionMode = VidGrab.TCompressionMode.cm_NoCompression
        Me.VideoCapture.CompressionType = VidGrab.TCompressionType.ct_Video
        Me.VideoCapture.Cropping_Enabled = False
        Me.VideoCapture.Cropping_Height = 120
        Me.VideoCapture.Cropping_Outbounds = True
        Me.VideoCapture.Cropping_Width = 160
        Me.VideoCapture.Cropping_X = 0
        Me.VideoCapture.Cropping_Y = 0
        Me.VideoCapture.Cropping_Zoom = 1.0R
        Me.VideoCapture.Display_Active = True
        Me.VideoCapture.Display_AlphaBlendEnabled = False
        Me.VideoCapture.Display_AlphaBlendValue = 180
        Me.VideoCapture.Display_AspectRatio = VidGrab.TAspectRatio.ar_Stretch
        Me.VideoCapture.Display_AutoSize = False
        Me.VideoCapture.Display_Embedded = True
        Me.VideoCapture.Display_FullScreen = False
        Me.VideoCapture.Display_Height = 240
        Me.VideoCapture.Display_Left = 10
        Me.VideoCapture.Display_Monitor = 0
        Me.VideoCapture.Display_MouseMovesWindow = True
        Me.VideoCapture.Display_PanScanRatio = 50
        Me.VideoCapture.Display_StayOnTop = False
        Me.VideoCapture.Display_Top = 10
        Me.VideoCapture.Display_TransparentColorEnabled = False
        Me.VideoCapture.Display_TransparentColorValue = 255
        Me.VideoCapture.Display_VideoPortEnabled = True
        Me.VideoCapture.Display_Visible = True
        Me.VideoCapture.Display_Width = 320
        Me.VideoCapture.DoubleBuffered = False
        Me.VideoCapture.DroppedFramesPollingInterval = -1
        Me.VideoCapture.DualDisplay_Active = False
        Me.VideoCapture.DualDisplay_AlphaBlendEnabled = False
        Me.VideoCapture.DualDisplay_AlphaBlendValue = 180
        Me.VideoCapture.DualDisplay_AspectRatio = VidGrab.TAspectRatio.ar_Stretch
        Me.VideoCapture.DualDisplay_AutoSize = False
        Me.VideoCapture.DualDisplay_Embedded = False
        Me.VideoCapture.DualDisplay_FullScreen = False
        Me.VideoCapture.DualDisplay_Height = 240
        Me.VideoCapture.DualDisplay_Left = 20
        Me.VideoCapture.DualDisplay_Monitor = 0
        Me.VideoCapture.DualDisplay_MouseMovesWindow = True
        Me.VideoCapture.DualDisplay_PanScanRatio = 50
        Me.VideoCapture.DualDisplay_StayOnTop = False
        Me.VideoCapture.DualDisplay_Top = 400
        Me.VideoCapture.DualDisplay_TransparentColorEnabled = False
        Me.VideoCapture.DualDisplay_TransparentColorValue = 255
        Me.VideoCapture.DualDisplay_VideoPortEnabled = False
        Me.VideoCapture.DualDisplay_Visible = True
        Me.VideoCapture.DualDisplay_Width = 320
        Me.VideoCapture.DVDateTimeEnabled = True
        Me.VideoCapture.DVDiscontinuityMinimumInterval = 3
        Me.VideoCapture.DVDTitle = 0
        Me.VideoCapture.DVEncoder_VideoFormat = VidGrab.TDVVideoFormat.dvf_DVSD
        Me.VideoCapture.DVEncoder_VideoResolution = VidGrab.TDVSize.dv_Full
        Me.VideoCapture.DVEncoder_VideoStandard = VidGrab.TDVVideoStandard.dvs_Default
        Me.VideoCapture.DVRecordingInNativeFormatSeparatesStreams = False
        Me.VideoCapture.DVReduceFrameRate = False
        Me.VideoCapture.DVRgb219 = False
        Me.VideoCapture.DVTimeCodeEnabled = True
        Me.VideoCapture.EventNotificationSynchrone = True
        Me.VideoCapture.FixFlickerOrBlackCapture = False
        Me.VideoCapture.FrameCaptureHeight = -1
        Me.VideoCapture.FrameCaptureWidth = -1
        Me.VideoCapture.FrameCaptureWithoutOverlay = False
        Me.VideoCapture.FrameCaptureZoomSize = 100
        Me.VideoCapture.FrameGrabber = VidGrab.TFrameGrabber.fg_BothStreams
        Me.VideoCapture.FrameGrabberRGBFormat = VidGrab.TFrameGrabberRGBFormat.fgf_Default
        Me.VideoCapture.FrameNumberStartsFromZero = False
        Me.VideoCapture.FrameRate = 0.0R
        Me.VideoCapture.HoldRecording = False
        Me.VideoCapture.ImageOverlay_AlphaBlend = False
        Me.VideoCapture.ImageOverlay_AlphaBlendValue = 180
        Me.VideoCapture.ImageOverlay_ChromaKey = False
        Me.VideoCapture.ImageOverlay_ChromaKeyLeewayPercent = 25
        Me.VideoCapture.ImageOverlay_ChromaKeyRGBColor = 0
        Me.VideoCapture.ImageOverlay_Height = -1
        Me.VideoCapture.ImageOverlay_LeftLocation = 10
        Me.VideoCapture.ImageOverlay_RotationAngle = 0.0R
        Me.VideoCapture.ImageOverlay_StretchToVideoSize = False
        Me.VideoCapture.ImageOverlay_TopLocation = 10
        Me.VideoCapture.ImageOverlay_Transparent = False
        Me.VideoCapture.ImageOverlay_TransparentColorValue = 0
        Me.VideoCapture.ImageOverlay_UseTransparentColor = False
        Me.VideoCapture.ImageOverlay_Width = -1
        Me.VideoCapture.ImageOverlayEnabled = False
        Me.VideoCapture.ImageOverlaySelector = 0
        Me.VideoCapture.IPCameraURL = ""
        Me.VideoCapture.JPEGPerformance = VidGrab.TJPEGPerformance.jpBestQuality
        Me.VideoCapture.JPEGProgressiveDisplay = False
        Me.VideoCapture.JPEGQuality = 100
        Me.VideoCapture.LicenseString = "N/A"
        Me.VideoCapture.Location = New System.Drawing.Point(221, 3)
        Me.VideoCapture.LogoDisplayed = False
        Me.VideoCapture.LogoLayout = VidGrab.TLogoLayout.lg_Stretched
        Me.VideoCapture.MixAudioSamples_CurrentSourceLevel = 100
        Me.VideoCapture.MixAudioSamples_ExternalSourceLevel = 100
        Me.VideoCapture.Mixer_MosaicColumns = 1
        Me.VideoCapture.Mixer_MosaicLines = 1
        Me.VideoCapture.MotionDetector_CompareBlue = True
        Me.VideoCapture.MotionDetector_CompareGreen = True
        Me.VideoCapture.MotionDetector_CompareRed = True
        Me.VideoCapture.MotionDetector_Enabled = False
        Me.VideoCapture.MotionDetector_GreyScale = False
        Me.VideoCapture.MotionDetector_Grid = "5555555555 5555555555 5555555555 5555555555 5555555555 5555555555 5555555555 5555" & _
    "555555 5555555555 5555555555"
        Me.VideoCapture.MotionDetector_MaxDetectionsPerSecond = 0.0R
        Me.VideoCapture.MotionDetector_ReduceCPULoad = 1
        Me.VideoCapture.MotionDetector_ReduceVideoNoise = False
        Me.VideoCapture.MotionDetector_Triggered = False
        Me.VideoCapture.MouseWheelEventEnabled = True
        Me.VideoCapture.MpegStreamType = VidGrab.TMpegStreamType.mpst_Default
        Me.VideoCapture.MultiplexedInputEmulation = True
        Me.VideoCapture.MultiplexedRole = VidGrab.TMultiplexedRole.mr_NotMultiplexed
        Me.VideoCapture.MultiplexedStabilizationDelay = 100
        Me.VideoCapture.MultiplexedSwitchDelay = 0
        Me.VideoCapture.Multiplexer = -1
        Me.VideoCapture.MuteAudioRendering = False
        Me.VideoCapture.Name = "VideoCapture"
        Me.VideoCapture.NetworkStreaming = VidGrab.TNetworkStreaming.ns_Disabled
        Me.VideoCapture.NetworkStreamingType = VidGrab.TNetworkStreamingType.nst_AudioVideoStreaming
        Me.VideoCapture.NormalCursor = VidGrab.TCursors.cr_Default
        Me.VideoCapture.NotificationMethod = VidGrab.TNotificationMethod.nm_Thread
        Me.VideoCapture.NotificationPriority = VidGrab.TThreadPriority.tpNormal
        Me.VideoCapture.NotificationSleepTime = -1
        Me.VideoCapture.OnFrameBitmapEventSynchrone = False
        Me.VideoCapture.OverlayAfterTransform = False
        Me.VideoCapture.OwnerObject = Nothing
        Me.VideoCapture.PlayerAudioRendering = True
        Me.VideoCapture.PlayerDuration = CType(1, Long)
        Me.VideoCapture.PlayerDVSize = VidGrab.TDVSize.dv_Full
        Me.VideoCapture.PlayerFastSeekSpeedRatio = 4
        Me.VideoCapture.PlayerFileName = ""
        Me.VideoCapture.PlayerForcedCodec = ""
        Me.VideoCapture.PlayerFramePosition = CType(1, Long)
        Me.VideoCapture.PlayerRefreshPausedDisplay = False
        Me.VideoCapture.PlayerRefreshPausedDisplayFrameRate = 0.0R
        Me.VideoCapture.PlayerSpeedRatio = 1.0R
        Me.VideoCapture.PlayerTimePosition = CType(0, Long)
        Me.VideoCapture.PlayerTrackBarSynchrone = False
        Me.VideoCapture.PlaylistIndex = 0
        Me.VideoCapture.PreallocCapFileCopiedAfterRecording = True
        Me.VideoCapture.PreallocCapFileEnabled = False
        Me.VideoCapture.PreallocCapFileName = ""
        Me.VideoCapture.PreallocCapFileSizeInMB = 100
        Me.VideoCapture.PreviewZoomSize = 100
        Me.VideoCapture.QuickDeviceInitialization = False
        Me.VideoCapture.RawAudioSampleCapture = False
        Me.VideoCapture.RawCaptureAsyncEvent = True
        Me.VideoCapture.RawSampleCaptureLocation = VidGrab.TRawSampleCaptureLocation.rl_SourceFormat
        Me.VideoCapture.RawVideoSampleCapture = False
        Me.VideoCapture.RecordingAudioBitRate = -1
        Me.VideoCapture.RecordingBacktimedFramesCount = 0
        Me.VideoCapture.RecordingCanPause = False
        Me.VideoCapture.RecordingFileName = ""
        Me.VideoCapture.RecordingInNativeFormat = True
        Me.VideoCapture.RecordingMethod = VidGrab.TRecordingMethod.rm_AVI
        Me.VideoCapture.RecordingOnMotion_Enabled = False
        Me.VideoCapture.RecordingOnMotion_MotionThreshold = 0.0R
        Me.VideoCapture.RecordingOnMotion_NoMotionPauseDelayMs = 5000
        Me.VideoCapture.RecordingPauseCreatesNewFile = False
        Me.VideoCapture.RecordingSize = VidGrab.TRecordingSize.rs_Default
        Me.VideoCapture.RecordingTimer = VidGrab.TRecordingTimer.rt_Disabled
        Me.VideoCapture.RecordingTimerInterval = 0
        Me.VideoCapture.RecordingVideoBitRate = -1
        Me.VideoCapture.Reencoding_IncludeAudioStream = True
        Me.VideoCapture.Reencoding_IncludeVideoStream = True
        Me.VideoCapture.Reencoding_Method = VidGrab.TRecordingMethod.rm_ASF
        Me.VideoCapture.Reencoding_NewVideoClip = ""
        Me.VideoCapture.Reencoding_SourceVideoClip = ""
        Me.VideoCapture.Reencoding_StartFrame = CType(-1, Long)
        Me.VideoCapture.Reencoding_StartTime = CType(-1, Long)
        Me.VideoCapture.Reencoding_StopFrame = CType(-1, Long)
        Me.VideoCapture.Reencoding_StopTime = CType(-1, Long)
        Me.VideoCapture.Reencoding_UseAudioCompressor = False
        Me.VideoCapture.Reencoding_UseFrameGrabber = True
        Me.VideoCapture.Reencoding_UseVideoCompressor = False
        Me.VideoCapture.Reencoding_WMVOutput = False
        Me.VideoCapture.ScreenRecordingLayeredWindows = False
        Me.VideoCapture.ScreenRecordingMonitor = 0
        Me.VideoCapture.ScreenRecordingNonVisibleWindows = False
        Me.VideoCapture.ScreenRecordingThroughClipboard = False
        Me.VideoCapture.ScreenRecordingWithCursor = True
        Me.VideoCapture.SendToDV_DeviceIndex = -1
        Me.VideoCapture.Size = New System.Drawing.Size(147, 278)
        Me.VideoCapture.SpeakerBalance = 0
        Me.VideoCapture.SpeakerControl = False
        Me.VideoCapture.SpeakerVolume = 65535
        Me.VideoCapture.StoragePath = "C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE"
        Me.VideoCapture.StoreDeviceSettingsInRegistry = True
        Me.VideoCapture.SyncCommands = True
        Me.VideoCapture.SynchronizationRole = VidGrab.TSynchronizationRole.sr_Master
        Me.VideoCapture.Synchronized = False
        Me.VideoCapture.SyncPreview = VidGrab.TSyncPreview.sp_Auto
        Me.VideoCapture.TabIndex = 486
        Me.VideoCapture.TextOverlay_Align = VidGrab.TTextOverlayAlign.tf_Left
        Me.VideoCapture.TextOverlay_BkColor = 16777215
        Me.VideoCapture.TextOverlay_Enabled = False
        'TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
        Me.VideoCapture.TextOverlay_FontColor = 16776960
        Me.VideoCapture.TextOverlay_Left = 0
        Me.VideoCapture.TextOverlay_Right = -1
        Me.VideoCapture.TextOverlay_Scrolling = False
        Me.VideoCapture.TextOverlay_ScrollingSpeed = 1
        Me.VideoCapture.TextOverlay_Selector = 0
        Me.VideoCapture.TextOverlay_Shadow = True
        Me.VideoCapture.TextOverlay_ShadowColor = 0
        Me.VideoCapture.TextOverlay_ShadowDirection = VidGrab.TCardinalDirection.cd_NorthWest
        Me.VideoCapture.TextOverlay_String = resources.GetString("VideoCapture.TextOverlay_String")
        Me.VideoCapture.TextOverlay_Top = 0
        Me.VideoCapture.TextOverlay_Transparent = True
        Me.VideoCapture.ThirdPartyDeinterlacer = ""
        Me.VideoCapture.TranslateMouseCoordinates = True
        Me.VideoCapture.TunerFrequency = -1
        Me.VideoCapture.TunerMode = VidGrab.TTunerMode.tm_TVTuner
        Me.VideoCapture.TVChannel = 0
        Me.VideoCapture.TVCountryCode = 0
        Me.VideoCapture.TVTunerInputType = VidGrab.TTunerInputType.TunerInputCable
        Me.VideoCapture.TVUseFrequencyOverrides = False
        Me.VideoCapture.UseClock = True
        Me.VideoCapture.VCRHorizontalLocking = False
        Me.VideoCapture.Version = "v8.8.4.1 (build 131004) - Copyright ©2013 Datastead"
        Me.VideoCapture.VideoCompression_DataRate = -1
        Me.VideoCapture.VideoCompression_KeyFrameRate = 15
        Me.VideoCapture.VideoCompression_PFramesPerKeyFrame = 0
        Me.VideoCapture.VideoCompression_Quality = 1.0R
        Me.VideoCapture.VideoCompression_WindowSize = -1
        Me.VideoCapture.VideoCompressor = 0
        Me.VideoCapture.VideoControlSettings = True
        Me.VideoCapture.VideoCursor = VidGrab.TCursors.cr_Default
        Me.VideoCapture.VideoDevice = -1
        Me.VideoCapture.VideoFormat = -1
        Me.VideoCapture.VideoFromImages_BitmapsSortedBy = VidGrab.TFileSort.fs_TimeAsc
        Me.VideoCapture.VideoFromImages_RepeatIndefinitely = False
        Me.VideoCapture.VideoFromImages_SourceDirectory = "C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE"
        Me.VideoCapture.VideoFromImages_TemporaryFile = "SetOfBitmaps01.dat"
        Me.VideoCapture.VideoInput = -1
        Me.VideoCapture.VideoProcessing_Brightness = 0
        Me.VideoCapture.VideoProcessing_Contrast = 0
        Me.VideoCapture.VideoProcessing_Deinterlacing = VidGrab.TVideoDeinterlacing.di_Disabled
        Me.VideoCapture.VideoProcessing_FlipHorizontal = False
        Me.VideoCapture.VideoProcessing_FlipVertical = False
        Me.VideoCapture.VideoProcessing_GrayScale = False
        Me.VideoCapture.VideoProcessing_Hue = 0
        Me.VideoCapture.VideoProcessing_InvertColors = False
        Me.VideoCapture.VideoProcessing_Pixellization = 1
        Me.VideoCapture.VideoProcessing_Rotation = VidGrab.TVideoRotation.rt_0_deg
        Me.VideoCapture.VideoProcessing_RotationCustomAngle = 45.5R
        Me.VideoCapture.VideoProcessing_Saturation = 0
        Me.VideoCapture.VideoQualitySettings = True
        Me.VideoCapture.VideoRenderer = VidGrab.TVideoRenderer.vr_AutoSelect
        Me.VideoCapture.VideoRendererExternal = VidGrab.TVideoRendererExternal.vre_None
        Me.VideoCapture.VideoRendererExternalIndex = -1
        Me.VideoCapture.VideoSize = -1
        Me.VideoCapture.VideoSource = VidGrab.TVideoSource.vs_VideoCaptureDevice
        Me.VideoCapture.VideoSource_FileOrURL = ""
        Me.VideoCapture.VideoSource_FileOrURL_StartTime = CType(-1, Long)
        Me.VideoCapture.VideoSource_FileOrURL_StopTime = CType(-1, Long)
        Me.VideoCapture.VideoSubtype = -1
        Me.VideoCapture.VideoVisibleWhenStopped = False
        Me.VideoCapture.VirtualAudioStreamControl = -1
        Me.VideoCapture.VirtualVideoStreamControl = -1
        Me.VideoCapture.VuMeter = VidGrab.TVuMeter.vu_Disabled
        Me.VideoCapture.WebcamStillCaptureButton = VidGrab.TWebcamStillCaptureButton.wb_Disabled
        Me.VideoCapture.ZoomCoeff = 1000
        Me.VideoCapture.ZoomXCenter = 0
        Me.VideoCapture.ZoomYCenter = 0
        '
        'obj_budgetdetil_name
        '
        Me.obj_budgetdetil_name.Location = New System.Drawing.Point(402, 461)
        Me.obj_budgetdetil_name.Multiline = True
        Me.obj_budgetdetil_name.Name = "obj_budgetdetil_name"
        Me.obj_budgetdetil_name.ReadOnly = True
        Me.obj_budgetdetil_name.Size = New System.Drawing.Size(193, 63)
        Me.obj_budgetdetil_name.TabIndex = 483
        Me.obj_budgetdetil_name.TabStop = False
        '
        'btnItemCategorySelect
        '
        Me.btnItemCategorySelect.Location = New System.Drawing.Point(264, 258)
        Me.btnItemCategorySelect.Name = "btnItemCategorySelect"
        Me.btnItemCategorySelect.Size = New System.Drawing.Size(34, 23)
        Me.btnItemCategorySelect.TabIndex = 452
        Me.btnItemCategorySelect.Text = "..."
        Me.btnItemCategorySelect.UseVisualStyleBackColor = True
        '
        'btnItemSelect
        '
        Me.btnItemSelect.Location = New System.Drawing.Point(264, 233)
        Me.btnItemSelect.Name = "btnItemSelect"
        Me.btnItemSelect.Size = New System.Drawing.Size(34, 23)
        Me.btnItemSelect.TabIndex = 452
        Me.btnItemSelect.Text = "..."
        Me.btnItemSelect.UseVisualStyleBackColor = True
        '
        'btnCategory
        '
        Me.btnCategory.Location = New System.Drawing.Point(263, 112)
        Me.btnCategory.Name = "btnCategory"
        Me.btnCategory.Size = New System.Drawing.Size(34, 23)
        Me.btnCategory.TabIndex = 452
        Me.btnCategory.Text = "..."
        Me.btnCategory.UseVisualStyleBackColor = True
        '
        'btnSerial
        '
        Me.btnSerial.Location = New System.Drawing.Point(264, 333)
        Me.btnSerial.Name = "btnSerial"
        Me.btnSerial.Size = New System.Drawing.Size(34, 23)
        Me.btnSerial.TabIndex = 452
        Me.btnSerial.Text = "..."
        Me.btnSerial.UseVisualStyleBackColor = True
        '
        'obj_budget_name
        '
        Me.obj_budget_name.Location = New System.Drawing.Point(402, 436)
        Me.obj_budget_name.Name = "obj_budget_name"
        Me.obj_budget_name.ReadOnly = True
        Me.obj_budget_name.Size = New System.Drawing.Size(193, 20)
        Me.obj_budget_name.TabIndex = 482
        Me.obj_budget_name.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(315, 465)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 481
        Me.Label5.Text = "Budget Detil"
        '
        'lblQtyTotal
        '
        Me.lblQtyTotal.AutoSize = True
        Me.lblQtyTotal.Location = New System.Drawing.Point(315, 188)
        Me.lblQtyTotal.Name = "lblQtyTotal"
        Me.lblQtyTotal.Size = New System.Drawing.Size(50, 13)
        Me.lblQtyTotal.TabIndex = 451
        Me.lblQtyTotal.Text = "Qty Total"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(315, 440)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 480
        Me.Label4.Text = "Budget"
        '
        'obj_Terimabarangdetil_depre_enddt
        '
        Me.obj_Terimabarangdetil_depre_enddt.CustomFormat = "dd/MM/yyyy"
        Me.obj_Terimabarangdetil_depre_enddt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Terimabarangdetil_depre_enddt.Location = New System.Drawing.Point(505, 476)
        Me.obj_Terimabarangdetil_depre_enddt.Name = "obj_Terimabarangdetil_depre_enddt"
        Me.obj_Terimabarangdetil_depre_enddt.Size = New System.Drawing.Size(33, 20)
        Me.obj_Terimabarangdetil_depre_enddt.TabIndex = 454
        '
        'obj_Terimabarangdetil_qtytotal
        '
        Me.obj_Terimabarangdetil_qtytotal.Location = New System.Drawing.Point(403, 184)
        Me.obj_Terimabarangdetil_qtytotal.Name = "obj_Terimabarangdetil_qtytotal"
        Me.obj_Terimabarangdetil_qtytotal.Size = New System.Drawing.Size(62, 20)
        Me.obj_Terimabarangdetil_qtytotal.TabIndex = 450
        Me.obj_Terimabarangdetil_qtytotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Acc_id
        '
        Me.lbl_Acc_id.AutoSize = True
        Me.lbl_Acc_id.Location = New System.Drawing.Point(315, 361)
        Me.lbl_Acc_id.Name = "lbl_Acc_id"
        Me.lbl_Acc_id.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Acc_id.TabIndex = 479
        Me.lbl_Acc_id.Text = "Account"
        '
        'obj_Terimabarangdetil_product_no
        '
        Me.obj_Terimabarangdetil_product_no.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Terimabarangdetil_product_no.FormattingEnabled = True
        Me.obj_Terimabarangdetil_product_no.Items.AddRange(New Object() {"Label", "Taffeta"})
        Me.obj_Terimabarangdetil_product_no.Location = New System.Drawing.Point(94, 62)
        Me.obj_Terimabarangdetil_product_no.Name = "obj_Terimabarangdetil_product_no"
        Me.obj_Terimabarangdetil_product_no.Size = New System.Drawing.Size(107, 21)
        Me.obj_Terimabarangdetil_product_no.TabIndex = 453
        '
        'obj_Acc_id
        '
        Me.obj_Acc_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Acc_id.Location = New System.Drawing.Point(403, 357)
        Me.obj_Acc_id.Name = "obj_Acc_id"
        Me.obj_Acc_id.Size = New System.Drawing.Size(375, 21)
        Me.obj_Acc_id.TabIndex = 478
        '
        'obj_Terimabarangdetil_qtydetail
        '
        Me.obj_Terimabarangdetil_qtydetail.Location = New System.Drawing.Point(403, 160)
        Me.obj_Terimabarangdetil_qtydetail.Name = "obj_Terimabarangdetil_qtydetail"
        Me.obj_Terimabarangdetil_qtydetail.Size = New System.Drawing.Size(62, 20)
        Me.obj_Terimabarangdetil_qtydetail.TabIndex = 449
        Me.obj_Terimabarangdetil_qtydetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'obj_Orderdetil_line
        '
        Me.obj_Orderdetil_line.Location = New System.Drawing.Point(403, 410)
        Me.obj_Orderdetil_line.MaxLength = 20
        Me.obj_Orderdetil_line.Name = "obj_Orderdetil_line"
        Me.obj_Orderdetil_line.ReadOnly = True
        Me.obj_Orderdetil_line.Size = New System.Drawing.Size(138, 20)
        Me.obj_Orderdetil_line.TabIndex = 472
        '
        'btn_Parent
        '
        Me.btn_Parent.Location = New System.Drawing.Point(516, 37)
        Me.btn_Parent.Name = "btn_Parent"
        Me.btn_Parent.Size = New System.Drawing.Size(50, 20)
        Me.btn_Parent.TabIndex = 452
        Me.btn_Parent.Text = "Parent"
        Me.btn_Parent.UseVisualStyleBackColor = True
        '
        'lbl_Orderdetil_line
        '
        Me.lbl_Orderdetil_line.AutoSize = True
        Me.lbl_Orderdetil_line.Location = New System.Drawing.Point(315, 414)
        Me.lbl_Orderdetil_line.Name = "lbl_Orderdetil_line"
        Me.lbl_Orderdetil_line.Size = New System.Drawing.Size(56, 13)
        Me.lbl_Orderdetil_line.TabIndex = 473
        Me.lbl_Orderdetil_line.Text = "Order Line"
        '
        'lblQtyDetail
        '
        Me.lblQtyDetail.AutoSize = True
        Me.lblQtyDetail.Location = New System.Drawing.Point(315, 164)
        Me.lblQtyDetail.Name = "lblQtyDetail"
        Me.lblQtyDetail.Size = New System.Drawing.Size(53, 13)
        Me.lblQtyDetail.TabIndex = 448
        Me.lblQtyDetail.Text = "Qty Detail"
        '
        'obj_Orderdetil_id
        '
        Me.obj_Orderdetil_id.Location = New System.Drawing.Point(403, 384)
        Me.obj_Orderdetil_id.MaxLength = 20
        Me.obj_Orderdetil_id.Name = "obj_Orderdetil_id"
        Me.obj_Orderdetil_id.ReadOnly = True
        Me.obj_Orderdetil_id.Size = New System.Drawing.Size(138, 20)
        Me.obj_Orderdetil_id.TabIndex = 470
        '
        'obj_Terimabarangdetil_line
        '
        Me.obj_Terimabarangdetil_line.Location = New System.Drawing.Point(403, 12)
        Me.obj_Terimabarangdetil_line.MaxLength = 30
        Me.obj_Terimabarangdetil_line.Name = "obj_Terimabarangdetil_line"
        Me.obj_Terimabarangdetil_line.ReadOnly = True
        Me.obj_Terimabarangdetil_line.Size = New System.Drawing.Size(49, 20)
        Me.obj_Terimabarangdetil_line.TabIndex = 369
        '
        'lbl_Orderdetil_id
        '
        Me.lbl_Orderdetil_id.AutoSize = True
        Me.lbl_Orderdetil_id.Location = New System.Drawing.Point(315, 388)
        Me.lbl_Orderdetil_id.Name = "lbl_Orderdetil_id"
        Me.lbl_Orderdetil_id.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Orderdetil_id.TabIndex = 471
        Me.lbl_Orderdetil_id.Text = "Order ID"
        '
        'obj_Itemtype_id
        '
        Me.obj_Itemtype_id.Location = New System.Drawing.Point(95, 283)
        Me.obj_Itemtype_id.Name = "obj_Itemtype_id"
        Me.obj_Itemtype_id.Size = New System.Drawing.Size(163, 20)
        Me.obj_Itemtype_id.TabIndex = 447
        '
        'obj_Terimabarang_parentbarcode
        '
        Me.obj_Terimabarang_parentbarcode.Location = New System.Drawing.Point(403, 37)
        Me.obj_Terimabarang_parentbarcode.MaxLength = 20
        Me.obj_Terimabarang_parentbarcode.Name = "obj_Terimabarang_parentbarcode"
        Me.obj_Terimabarang_parentbarcode.ReadOnly = True
        Me.obj_Terimabarang_parentbarcode.Size = New System.Drawing.Size(107, 20)
        Me.obj_Terimabarang_parentbarcode.TabIndex = 384
        Me.obj_Terimabarang_parentbarcode.TabStop = False
        '
        'lbl_Unit_id
        '
        Me.lbl_Unit_id.AutoSize = True
        Me.lbl_Unit_id.Location = New System.Drawing.Point(470, 140)
        Me.lbl_Unit_id.Name = "lbl_Unit_id"
        Me.lbl_Unit_id.Size = New System.Drawing.Size(26, 13)
        Me.lbl_Unit_id.TabIndex = 437
        Me.lbl_Unit_id.Text = "Unit"
        '
        'obj_Terimabarang_barcode
        '
        Me.obj_Terimabarang_barcode.Location = New System.Drawing.Point(94, 37)
        Me.obj_Terimabarang_barcode.MaxLength = 20
        Me.obj_Terimabarang_barcode.Name = "obj_Terimabarang_barcode"
        Me.obj_Terimabarang_barcode.ReadOnly = True
        Me.obj_Terimabarang_barcode.Size = New System.Drawing.Size(107, 20)
        Me.obj_Terimabarang_barcode.TabIndex = 381
        Me.obj_Terimabarang_barcode.TabStop = False
        '
        'obj_Unit_id
        '
        Me.obj_Unit_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Unit_id.Location = New System.Drawing.Point(502, 136)
        Me.obj_Unit_id.Name = "obj_Unit_id"
        Me.obj_Unit_id.Size = New System.Drawing.Size(61, 21)
        Me.obj_Unit_id.TabIndex = 436
        '
        'obj_Terimabarangdetil_eps
        '
        Me.obj_Terimabarangdetil_eps.Location = New System.Drawing.Point(95, 435)
        Me.obj_Terimabarangdetil_eps.MaxLength = 20
        Me.obj_Terimabarangdetil_eps.Name = "obj_Terimabarangdetil_eps"
        Me.obj_Terimabarangdetil_eps.Size = New System.Drawing.Size(91, 20)
        Me.obj_Terimabarangdetil_eps.TabIndex = 464
        '
        'lbl_Asset_barcode
        '
        Me.lbl_Asset_barcode.AutoSize = True
        Me.lbl_Asset_barcode.Location = New System.Drawing.Point(5, 41)
        Me.lbl_Asset_barcode.Name = "lbl_Asset_barcode"
        Me.lbl_Asset_barcode.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Asset_barcode.TabIndex = 382
        Me.lbl_Asset_barcode.Text = "Barcode"
        '
        'lbl_Terimabarangdetil_eps
        '
        Me.lbl_Terimabarangdetil_eps.AutoSize = True
        Me.lbl_Terimabarangdetil_eps.Location = New System.Drawing.Point(6, 439)
        Me.lbl_Terimabarangdetil_eps.Name = "lbl_Terimabarangdetil_eps"
        Me.lbl_Terimabarangdetil_eps.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Terimabarangdetil_eps.TabIndex = 465
        Me.lbl_Terimabarangdetil_eps.Text = "Eps"
        '
        'lbl_Terimabarangdetil_qty
        '
        Me.lbl_Terimabarangdetil_qty.AutoSize = True
        Me.lbl_Terimabarangdetil_qty.Location = New System.Drawing.Point(315, 140)
        Me.lbl_Terimabarangdetil_qty.Name = "lbl_Terimabarangdetil_qty"
        Me.lbl_Terimabarangdetil_qty.Size = New System.Drawing.Size(23, 13)
        Me.lbl_Terimabarangdetil_qty.TabIndex = 435
        Me.lbl_Terimabarangdetil_qty.Text = "Qty"
        '
        'lbl_Show_id_cont
        '
        Me.lbl_Show_id_cont.AutoSize = True
        Me.lbl_Show_id_cont.Location = New System.Drawing.Point(6, 413)
        Me.lbl_Show_id_cont.Name = "lbl_Show_id_cont"
        Me.lbl_Show_id_cont.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Show_id_cont.TabIndex = 463
        Me.lbl_Show_id_cont.Text = "Show(Cont)"
        '
        'lbl_Asset_barcodeinduk
        '
        Me.lbl_Asset_barcodeinduk.AutoSize = True
        Me.lbl_Asset_barcodeinduk.Location = New System.Drawing.Point(315, 41)
        Me.lbl_Asset_barcodeinduk.Name = "lbl_Asset_barcodeinduk"
        Me.lbl_Asset_barcodeinduk.Size = New System.Drawing.Size(87, 13)
        Me.lbl_Asset_barcodeinduk.TabIndex = 383
        Me.lbl_Asset_barcodeinduk.Text = "Barcode (Parent)"
        '
        'obj_Show_id_cont
        '
        Me.obj_Show_id_cont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Show_id_cont.Location = New System.Drawing.Point(95, 409)
        Me.obj_Show_id_cont.Name = "obj_Show_id_cont"
        Me.obj_Show_id_cont.Size = New System.Drawing.Size(163, 21)
        Me.obj_Show_id_cont.TabIndex = 462
        '
        'obj_Terimabarangdetil_qty
        '
        Me.obj_Terimabarangdetil_qty.Location = New System.Drawing.Point(403, 136)
        Me.obj_Terimabarangdetil_qty.MaxLength = 30
        Me.obj_Terimabarangdetil_qty.Name = "obj_Terimabarangdetil_qty"
        Me.obj_Terimabarangdetil_qty.Size = New System.Drawing.Size(62, 20)
        Me.obj_Terimabarangdetil_qty.TabIndex = 434
        Me.obj_Terimabarangdetil_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Show_id
        '
        Me.lbl_Show_id.AutoSize = True
        Me.lbl_Show_id.Location = New System.Drawing.Point(6, 386)
        Me.lbl_Show_id.Name = "lbl_Show_id"
        Me.lbl_Show_id.Size = New System.Drawing.Size(34, 13)
        Me.lbl_Show_id.TabIndex = 461
        Me.lbl_Show_id.Text = "Show"
        '
        'obj_Show_id
        '
        Me.obj_Show_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Show_id.Location = New System.Drawing.Point(95, 382)
        Me.obj_Show_id.Name = "obj_Show_id"
        Me.obj_Show_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Show_id.TabIndex = 460
        '
        'obj_Terimabarangdetil_desc
        '
        Me.obj_Terimabarangdetil_desc.Location = New System.Drawing.Point(95, 165)
        Me.obj_Terimabarangdetil_desc.MaxLength = 255
        Me.obj_Terimabarangdetil_desc.Multiline = True
        Me.obj_Terimabarangdetil_desc.Name = "obj_Terimabarangdetil_desc"
        Me.obj_Terimabarangdetil_desc.ReadOnly = True
        Me.obj_Terimabarangdetil_desc.Size = New System.Drawing.Size(215, 46)
        Me.obj_Terimabarangdetil_desc.TabIndex = 375
        '
        'lbl_Terimabarangdetil_depre_enddt
        '
        Me.lbl_Terimabarangdetil_depre_enddt.AutoSize = True
        Me.lbl_Terimabarangdetil_depre_enddt.Location = New System.Drawing.Point(417, 480)
        Me.lbl_Terimabarangdetil_depre_enddt.Name = "lbl_Terimabarangdetil_depre_enddt"
        Me.lbl_Terimabarangdetil_depre_enddt.Size = New System.Drawing.Size(87, 13)
        Me.lbl_Terimabarangdetil_depre_enddt.TabIndex = 455
        Me.lbl_Terimabarangdetil_depre_enddt.Text = "End Depre. Date"
        '
        'lbl_Terimabarangdetil_rack
        '
        Me.lbl_Terimabarangdetil_rack.AutoSize = True
        Me.lbl_Terimabarangdetil_rack.Location = New System.Drawing.Point(315, 335)
        Me.lbl_Terimabarangdetil_rack.Name = "lbl_Terimabarangdetil_rack"
        Me.lbl_Terimabarangdetil_rack.Size = New System.Drawing.Size(33, 13)
        Me.lbl_Terimabarangdetil_rack.TabIndex = 433
        Me.lbl_Terimabarangdetil_rack.Text = "Rack"
        '
        'lbl_Terimabarangdetil_desc
        '
        Me.lbl_Terimabarangdetil_desc.AutoSize = True
        Me.lbl_Terimabarangdetil_desc.Location = New System.Drawing.Point(6, 166)
        Me.lbl_Terimabarangdetil_desc.Name = "lbl_Terimabarangdetil_desc"
        Me.lbl_Terimabarangdetil_desc.Size = New System.Drawing.Size(32, 13)
        Me.lbl_Terimabarangdetil_desc.TabIndex = 376
        Me.lbl_Terimabarangdetil_desc.Text = "Desc"
        '
        'obj_Terimabarangdetil_rack
        '
        Me.obj_Terimabarangdetil_rack.Location = New System.Drawing.Point(403, 331)
        Me.obj_Terimabarangdetil_rack.MaxLength = 30
        Me.obj_Terimabarangdetil_rack.Name = "obj_Terimabarangdetil_rack"
        Me.obj_Terimabarangdetil_rack.Size = New System.Drawing.Size(164, 20)
        Me.obj_Terimabarangdetil_rack.TabIndex = 432
        '
        'lbl_Terimabarangdetil_lineparent
        '
        Me.lbl_Terimabarangdetil_lineparent.AutoSize = True
        Me.lbl_Terimabarangdetil_lineparent.Location = New System.Drawing.Point(315, 66)
        Me.lbl_Terimabarangdetil_lineparent.Name = "lbl_Terimabarangdetil_lineparent"
        Me.lbl_Terimabarangdetil_lineparent.Size = New System.Drawing.Size(67, 13)
        Me.lbl_Terimabarangdetil_lineparent.TabIndex = 374
        Me.lbl_Terimabarangdetil_lineparent.Text = "Line (Parent)"
        '
        'lbl_Room_id
        '
        Me.lbl_Room_id.AutoSize = True
        Me.lbl_Room_id.Location = New System.Drawing.Point(315, 285)
        Me.lbl_Room_id.Name = "lbl_Room_id"
        Me.lbl_Room_id.Size = New System.Drawing.Size(35, 13)
        Me.lbl_Room_id.TabIndex = 431
        Me.lbl_Room_id.Text = "Room"
        '
        'obj_Terimabarangdetil_parentline
        '
        Me.obj_Terimabarangdetil_parentline.Location = New System.Drawing.Point(403, 62)
        Me.obj_Terimabarangdetil_parentline.MaxLength = 30
        Me.obj_Terimabarangdetil_parentline.Name = "obj_Terimabarangdetil_parentline"
        Me.obj_Terimabarangdetil_parentline.Size = New System.Drawing.Size(49, 20)
        Me.obj_Terimabarangdetil_parentline.TabIndex = 373
        '
        'obj_Room_id
        '
        Me.obj_Room_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Room_id.Location = New System.Drawing.Point(403, 281)
        Me.obj_Room_id.Name = "obj_Room_id"
        Me.obj_Room_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Room_id.TabIndex = 430
        '
        'lbl_Terimabarangdetil_line
        '
        Me.lbl_Terimabarangdetil_line.AutoSize = True
        Me.lbl_Terimabarangdetil_line.Location = New System.Drawing.Point(315, 16)
        Me.lbl_Terimabarangdetil_line.Name = "lbl_Terimabarangdetil_line"
        Me.lbl_Terimabarangdetil_line.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Terimabarangdetil_line.TabIndex = 372
        Me.lbl_Terimabarangdetil_line.Text = "Line"
        '
        'lbl_Sex_id
        '
        Me.lbl_Sex_id.AutoSize = True
        Me.lbl_Sex_id.Location = New System.Drawing.Point(315, 261)
        Me.lbl_Sex_id.Name = "lbl_Sex_id"
        Me.lbl_Sex_id.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Sex_id.TabIndex = 429
        Me.lbl_Sex_id.Text = "Sex"
        '
        'obj_asset_terimabarangdetil_id
        '
        Me.obj_asset_terimabarangdetil_id.Location = New System.Drawing.Point(94, 12)
        Me.obj_asset_terimabarangdetil_id.MaxLength = 20
        Me.obj_asset_terimabarangdetil_id.Name = "obj_asset_terimabarangdetil_id"
        Me.obj_asset_terimabarangdetil_id.ReadOnly = True
        Me.obj_asset_terimabarangdetil_id.Size = New System.Drawing.Size(107, 20)
        Me.obj_asset_terimabarangdetil_id.TabIndex = 370
        '
        'obj_Sex_id
        '
        Me.obj_Sex_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Sex_id.Location = New System.Drawing.Point(403, 257)
        Me.obj_Sex_id.Name = "obj_Sex_id"
        Me.obj_Sex_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Sex_id.TabIndex = 428
        '
        'lbl_Terimabarangdetil_id
        '
        Me.lbl_Terimabarangdetil_id.AutoSize = True
        Me.lbl_Terimabarangdetil_id.Location = New System.Drawing.Point(5, 16)
        Me.lbl_Terimabarangdetil_id.Name = "lbl_Terimabarangdetil_id"
        Me.lbl_Terimabarangdetil_id.Size = New System.Drawing.Size(67, 13)
        Me.lbl_Terimabarangdetil_id.TabIndex = 371
        Me.lbl_Terimabarangdetil_id.Text = "Receive No."
        '
        'lbl_Size_id
        '
        Me.lbl_Size_id.AutoSize = True
        Me.lbl_Size_id.Location = New System.Drawing.Point(315, 237)
        Me.lbl_Size_id.Name = "lbl_Size_id"
        Me.lbl_Size_id.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Size_id.TabIndex = 427
        Me.lbl_Size_id.Text = "Size"
        '
        'obj_Terimabarangdetil_nonfixasset
        '
        Me.obj_Terimabarangdetil_nonfixasset.AutoSize = True
        Me.obj_Terimabarangdetil_nonfixasset.Location = New System.Drawing.Point(403, 89)
        Me.obj_Terimabarangdetil_nonfixasset.Name = "obj_Terimabarangdetil_nonfixasset"
        Me.obj_Terimabarangdetil_nonfixasset.Size = New System.Drawing.Size(79, 17)
        Me.obj_Terimabarangdetil_nonfixasset.TabIndex = 451
        Me.obj_Terimabarangdetil_nonfixasset.TabStop = False
        Me.obj_Terimabarangdetil_nonfixasset.Text = "Not Printed"
        Me.obj_Terimabarangdetil_nonfixasset.UseVisualStyleBackColor = False
        '
        'obj_Size_id
        '
        Me.obj_Size_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Size_id.Location = New System.Drawing.Point(403, 233)
        Me.obj_Size_id.Name = "obj_Size_id"
        Me.obj_Size_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Size_id.TabIndex = 426
        '
        'lbl_Terimabarangdetil_product_no
        '
        Me.lbl_Terimabarangdetil_product_no.AutoSize = True
        Me.lbl_Terimabarangdetil_product_no.Location = New System.Drawing.Point(5, 66)
        Me.lbl_Terimabarangdetil_product_no.Name = "lbl_Terimabarangdetil_product_no"
        Me.lbl_Terimabarangdetil_product_no.Size = New System.Drawing.Size(74, 13)
        Me.lbl_Terimabarangdetil_product_no.TabIndex = 419
        Me.lbl_Terimabarangdetil_product_no.Text = "Barcode Type"
        '
        'lbl_Colour_id
        '
        Me.lbl_Colour_id.AutoSize = True
        Me.lbl_Colour_id.Location = New System.Drawing.Point(315, 213)
        Me.lbl_Colour_id.Name = "lbl_Colour_id"
        Me.lbl_Colour_id.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Colour_id.TabIndex = 425
        Me.lbl_Colour_id.Text = "Colour"
        '
        'obj_Assettype_id
        '
        Me.obj_Assettype_id.BackColor = System.Drawing.Color.White
        Me.obj_Assettype_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Assettype_id.Location = New System.Drawing.Point(94, 87)
        Me.obj_Assettype_id.Name = "obj_Assettype_id"
        Me.obj_Assettype_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Assettype_id.TabIndex = 447
        '
        'obj_Colour_id
        '
        Me.obj_Colour_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Colour_id.Location = New System.Drawing.Point(403, 209)
        Me.obj_Colour_id.Name = "obj_Colour_id"
        Me.obj_Colour_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Colour_id.TabIndex = 424
        '
        'lbl_Tipeasset_id
        '
        Me.lbl_Tipeasset_id.AutoSize = True
        Me.lbl_Tipeasset_id.Location = New System.Drawing.Point(5, 91)
        Me.lbl_Tipeasset_id.Name = "lbl_Tipeasset_id"
        Me.lbl_Tipeasset_id.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Tipeasset_id.TabIndex = 449
        Me.lbl_Tipeasset_id.Text = "Asset Type"
        '
        'lbl_Material_id
        '
        Me.lbl_Material_id.AutoSize = True
        Me.lbl_Material_id.Location = New System.Drawing.Point(6, 361)
        Me.lbl_Material_id.Name = "lbl_Material_id"
        Me.lbl_Material_id.Size = New System.Drawing.Size(44, 13)
        Me.lbl_Material_id.TabIndex = 423
        Me.lbl_Material_id.Text = "Material"
        '
        'lbl_Kategoriasset_id
        '
        Me.lbl_Kategoriasset_id.AutoSize = True
        Me.lbl_Kategoriasset_id.Location = New System.Drawing.Point(5, 116)
        Me.lbl_Kategoriasset_id.Name = "lbl_Kategoriasset_id"
        Me.lbl_Kategoriasset_id.Size = New System.Drawing.Size(78, 13)
        Me.lbl_Kategoriasset_id.TabIndex = 450
        Me.lbl_Kategoriasset_id.Text = "Asset Category"
        '
        'obj_Material_id
        '
        Me.obj_Material_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Material_id.Location = New System.Drawing.Point(95, 357)
        Me.obj_Material_id.Name = "obj_Material_id"
        Me.obj_Material_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Material_id.TabIndex = 422
        '
        'obj_Assetcategory_id
        '
        Me.obj_Assetcategory_id.Location = New System.Drawing.Point(94, 113)
        Me.obj_Assetcategory_id.MaxLength = 20
        Me.obj_Assetcategory_id.Name = "obj_Assetcategory_id"
        Me.obj_Assetcategory_id.ReadOnly = True
        Me.obj_Assetcategory_id.Size = New System.Drawing.Size(164, 20)
        Me.obj_Assetcategory_id.TabIndex = 420
        '
        'obj_Terimabarangdetil_model
        '
        Me.obj_Terimabarangdetil_model.Location = New System.Drawing.Point(403, 307)
        Me.obj_Terimabarangdetil_model.MaxLength = 20
        Me.obj_Terimabarangdetil_model.Name = "obj_Terimabarangdetil_model"
        Me.obj_Terimabarangdetil_model.Size = New System.Drawing.Size(164, 20)
        Me.obj_Terimabarangdetil_model.TabIndex = 420
        '
        'lbl_Item_id
        '
        Me.lbl_Item_id.AutoSize = True
        Me.lbl_Item_id.Location = New System.Drawing.Point(6, 239)
        Me.lbl_Item_id.Name = "lbl_Item_id"
        Me.lbl_Item_id.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Item_id.TabIndex = 409
        Me.lbl_Item_id.Text = "Item"
        '
        'lbl_Terimabarangdetil_model
        '
        Me.lbl_Terimabarangdetil_model.AutoSize = True
        Me.lbl_Terimabarangdetil_model.Location = New System.Drawing.Point(315, 311)
        Me.lbl_Terimabarangdetil_model.Name = "lbl_Terimabarangdetil_model"
        Me.lbl_Terimabarangdetil_model.Size = New System.Drawing.Size(36, 13)
        Me.lbl_Terimabarangdetil_model.TabIndex = 421
        Me.lbl_Terimabarangdetil_model.Text = "Model"
        '
        'obj_Item_id
        '
        Me.obj_Item_id.BackColor = System.Drawing.SystemColors.Control
        Me.obj_Item_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.obj_Item_id.Enabled = False
        Me.obj_Item_id.Location = New System.Drawing.Point(95, 235)
        Me.obj_Item_id.Name = "obj_Item_id"
        Me.obj_Item_id.Size = New System.Drawing.Size(164, 21)
        Me.obj_Item_id.TabIndex = 408
        '
        'obj_Terimabarangdetil_serial_no
        '
        Me.obj_Terimabarangdetil_serial_no.Location = New System.Drawing.Point(95, 333)
        Me.obj_Terimabarangdetil_serial_no.MaxLength = 20
        Me.obj_Terimabarangdetil_serial_no.Name = "obj_Terimabarangdetil_serial_no"
        Me.obj_Terimabarangdetil_serial_no.Size = New System.Drawing.Size(163, 20)
        Me.obj_Terimabarangdetil_serial_no.TabIndex = 416
        '
        'obj_Itemcategory_id
        '
        Me.obj_Itemcategory_id.BackColor = System.Drawing.SystemColors.Control
        Me.obj_Itemcategory_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.obj_Itemcategory_id.Enabled = False
        Me.obj_Itemcategory_id.Location = New System.Drawing.Point(95, 259)
        Me.obj_Itemcategory_id.Name = "obj_Itemcategory_id"
        Me.obj_Itemcategory_id.Size = New System.Drawing.Size(164, 21)
        Me.obj_Itemcategory_id.TabIndex = 410
        '
        'lbl_Terimabarangdetil_serial_no
        '
        Me.lbl_Terimabarangdetil_serial_no.AutoSize = True
        Me.lbl_Terimabarangdetil_serial_no.Location = New System.Drawing.Point(6, 337)
        Me.lbl_Terimabarangdetil_serial_no.Name = "lbl_Terimabarangdetil_serial_no"
        Me.lbl_Terimabarangdetil_serial_no.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Terimabarangdetil_serial_no.TabIndex = 417
        Me.lbl_Terimabarangdetil_serial_no.Text = "Serial No."
        '
        'lbl_Itemcategory_id
        '
        Me.lbl_Itemcategory_id.AutoSize = True
        Me.lbl_Itemcategory_id.Location = New System.Drawing.Point(6, 263)
        Me.lbl_Itemcategory_id.Name = "lbl_Itemcategory_id"
        Me.lbl_Itemcategory_id.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Itemcategory_id.TabIndex = 411
        Me.lbl_Itemcategory_id.Text = "Category"
        '
        'lbl_brand_id
        '
        Me.lbl_brand_id.AutoSize = True
        Me.lbl_brand_id.Location = New System.Drawing.Point(6, 311)
        Me.lbl_brand_id.Name = "lbl_brand_id"
        Me.lbl_brand_id.Size = New System.Drawing.Size(35, 13)
        Me.lbl_brand_id.TabIndex = 415
        Me.lbl_brand_id.Text = "Brand"
        '
        'lbl_Itemtype_id
        '
        Me.lbl_Itemtype_id.AutoSize = True
        Me.lbl_Itemtype_id.Location = New System.Drawing.Point(6, 287)
        Me.lbl_Itemtype_id.Name = "lbl_Itemtype_id"
        Me.lbl_Itemtype_id.Size = New System.Drawing.Size(31, 13)
        Me.lbl_Itemtype_id.TabIndex = 413
        Me.lbl_Itemtype_id.Text = "Type"
        '
        'obj_Brand_id
        '
        Me.obj_Brand_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Brand_id.Location = New System.Drawing.Point(95, 307)
        Me.obj_Brand_id.Name = "obj_Brand_id"
        Me.obj_Brand_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Brand_id.TabIndex = 414
        '
        'TabAccounting
        '
        Me.TabAccounting.Controls.Add(Me.Panel_bawah)
        Me.TabAccounting.Location = New System.Drawing.Point(4, 25)
        Me.TabAccounting.Name = "TabAccounting"
        Me.TabAccounting.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAccounting.Size = New System.Drawing.Size(969, 562)
        Me.TabAccounting.TabIndex = 1
        Me.TabAccounting.Text = "Accounting"
        Me.TabAccounting.UseVisualStyleBackColor = True
        '
        'Panel_bawah
        '
        Me.Panel_bawah.Controls.Add(Me.lbl_Currency_iddetil)
        Me.Panel_bawah.Controls.Add(Me.obj_Currency_iddetil)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_totalidrreal)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_totalidrreal)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_totalforeign)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_totalforeign)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_ppnidrreal)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_ppnidrreal)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_ppnforeign)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_ppnforeign)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_pphidrreal)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_pphidrreal)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_pphforeign)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_pphforeign)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_disc)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_disc)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_ppnpercent)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_ppnpercent)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_pphpercent)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_pphpercent)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_idrreal)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_idrreal)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_foreignrate)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_foreignrate)
        Me.Panel_bawah.Controls.Add(Me.obj_Terimabarangdetil_foreign)
        Me.Panel_bawah.Controls.Add(Me.lbl_Terimabarangdetil_foreign)
        Me.Panel_bawah.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_bawah.Location = New System.Drawing.Point(3, 3)
        Me.Panel_bawah.Name = "Panel_bawah"
        Me.Panel_bawah.Size = New System.Drawing.Size(963, 556)
        Me.Panel_bawah.TabIndex = 369
        '
        'lbl_Currency_iddetil
        '
        Me.lbl_Currency_iddetil.AutoSize = True
        Me.lbl_Currency_iddetil.Location = New System.Drawing.Point(17, 40)
        Me.lbl_Currency_iddetil.Name = "lbl_Currency_iddetil"
        Me.lbl_Currency_iddetil.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Currency_iddetil.TabIndex = 378
        Me.lbl_Currency_iddetil.Text = "Currency"
        '
        'obj_Currency_iddetil
        '
        Me.obj_Currency_iddetil.BackColor = System.Drawing.Color.White
        Me.obj_Currency_iddetil.Location = New System.Drawing.Point(101, 37)
        Me.obj_Currency_iddetil.Name = "obj_Currency_iddetil"
        Me.obj_Currency_iddetil.Size = New System.Drawing.Size(73, 21)
        Me.obj_Currency_iddetil.TabIndex = 377
        '
        'obj_Terimabarangdetil_totalidrreal
        '
        Me.obj_Terimabarangdetil_totalidrreal.Location = New System.Drawing.Point(684, 61)
        Me.obj_Terimabarangdetil_totalidrreal.MaxLength = 20
        Me.obj_Terimabarangdetil_totalidrreal.Name = "obj_Terimabarangdetil_totalidrreal"
        Me.obj_Terimabarangdetil_totalidrreal.ReadOnly = True
        Me.obj_Terimabarangdetil_totalidrreal.Size = New System.Drawing.Size(138, 20)
        Me.obj_Terimabarangdetil_totalidrreal.TabIndex = 375
        Me.obj_Terimabarangdetil_totalidrreal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_totalidrreal
        '
        Me.lbl_Terimabarangdetil_totalidrreal.AutoSize = True
        Me.lbl_Terimabarangdetil_totalidrreal.Location = New System.Drawing.Point(584, 66)
        Me.lbl_Terimabarangdetil_totalidrreal.Name = "lbl_Terimabarangdetil_totalidrreal"
        Me.lbl_Terimabarangdetil_totalidrreal.Size = New System.Drawing.Size(98, 13)
        Me.lbl_Terimabarangdetil_totalidrreal.TabIndex = 376
        Me.lbl_Terimabarangdetil_totalidrreal.Text = "Total Amount (IDR)"
        '
        'obj_Terimabarangdetil_totalforeign
        '
        Me.obj_Terimabarangdetil_totalforeign.Location = New System.Drawing.Point(397, 62)
        Me.obj_Terimabarangdetil_totalforeign.MaxLength = 20
        Me.obj_Terimabarangdetil_totalforeign.Name = "obj_Terimabarangdetil_totalforeign"
        Me.obj_Terimabarangdetil_totalforeign.ReadOnly = True
        Me.obj_Terimabarangdetil_totalforeign.Size = New System.Drawing.Size(133, 20)
        Me.obj_Terimabarangdetil_totalforeign.TabIndex = 373
        Me.obj_Terimabarangdetil_totalforeign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_totalforeign
        '
        Me.lbl_Terimabarangdetil_totalforeign.AutoSize = True
        Me.lbl_Terimabarangdetil_totalforeign.Location = New System.Drawing.Point(311, 64)
        Me.lbl_Terimabarangdetil_totalforeign.Name = "lbl_Terimabarangdetil_totalforeign"
        Me.lbl_Terimabarangdetil_totalforeign.Size = New System.Drawing.Size(70, 13)
        Me.lbl_Terimabarangdetil_totalforeign.TabIndex = 374
        Me.lbl_Terimabarangdetil_totalforeign.Text = "Total Amount"
        '
        'obj_Terimabarangdetil_ppnidrreal
        '
        Me.obj_Terimabarangdetil_ppnidrreal.Location = New System.Drawing.Point(684, 37)
        Me.obj_Terimabarangdetil_ppnidrreal.MaxLength = 20
        Me.obj_Terimabarangdetil_ppnidrreal.Name = "obj_Terimabarangdetil_ppnidrreal"
        Me.obj_Terimabarangdetil_ppnidrreal.ReadOnly = True
        Me.obj_Terimabarangdetil_ppnidrreal.Size = New System.Drawing.Size(138, 20)
        Me.obj_Terimabarangdetil_ppnidrreal.TabIndex = 371
        Me.obj_Terimabarangdetil_ppnidrreal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_ppnidrreal
        '
        Me.lbl_Terimabarangdetil_ppnidrreal.AutoSize = True
        Me.lbl_Terimabarangdetil_ppnidrreal.Location = New System.Drawing.Point(584, 40)
        Me.lbl_Terimabarangdetil_ppnidrreal.Name = "lbl_Terimabarangdetil_ppnidrreal"
        Me.lbl_Terimabarangdetil_ppnidrreal.Size = New System.Drawing.Size(96, 13)
        Me.lbl_Terimabarangdetil_ppnidrreal.TabIndex = 372
        Me.lbl_Terimabarangdetil_ppnidrreal.Text = "PPN Amount (IDR)"
        '
        'obj_Terimabarangdetil_ppnforeign
        '
        Me.obj_Terimabarangdetil_ppnforeign.Location = New System.Drawing.Point(397, 37)
        Me.obj_Terimabarangdetil_ppnforeign.MaxLength = 20
        Me.obj_Terimabarangdetil_ppnforeign.Name = "obj_Terimabarangdetil_ppnforeign"
        Me.obj_Terimabarangdetil_ppnforeign.ReadOnly = True
        Me.obj_Terimabarangdetil_ppnforeign.Size = New System.Drawing.Size(133, 20)
        Me.obj_Terimabarangdetil_ppnforeign.TabIndex = 369
        Me.obj_Terimabarangdetil_ppnforeign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_ppnforeign
        '
        Me.lbl_Terimabarangdetil_ppnforeign.AutoSize = True
        Me.lbl_Terimabarangdetil_ppnforeign.Location = New System.Drawing.Point(311, 39)
        Me.lbl_Terimabarangdetil_ppnforeign.Name = "lbl_Terimabarangdetil_ppnforeign"
        Me.lbl_Terimabarangdetil_ppnforeign.Size = New System.Drawing.Size(68, 13)
        Me.lbl_Terimabarangdetil_ppnforeign.TabIndex = 370
        Me.lbl_Terimabarangdetil_ppnforeign.Text = "PPN Amount"
        '
        'obj_Terimabarangdetil_pphidrreal
        '
        Me.obj_Terimabarangdetil_pphidrreal.Location = New System.Drawing.Point(684, 12)
        Me.obj_Terimabarangdetil_pphidrreal.MaxLength = 20
        Me.obj_Terimabarangdetil_pphidrreal.Name = "obj_Terimabarangdetil_pphidrreal"
        Me.obj_Terimabarangdetil_pphidrreal.ReadOnly = True
        Me.obj_Terimabarangdetil_pphidrreal.Size = New System.Drawing.Size(138, 20)
        Me.obj_Terimabarangdetil_pphidrreal.TabIndex = 367
        Me.obj_Terimabarangdetil_pphidrreal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_pphidrreal
        '
        Me.lbl_Terimabarangdetil_pphidrreal.AutoSize = True
        Me.lbl_Terimabarangdetil_pphidrreal.Location = New System.Drawing.Point(584, 15)
        Me.lbl_Terimabarangdetil_pphidrreal.Name = "lbl_Terimabarangdetil_pphidrreal"
        Me.lbl_Terimabarangdetil_pphidrreal.Size = New System.Drawing.Size(94, 13)
        Me.lbl_Terimabarangdetil_pphidrreal.TabIndex = 368
        Me.lbl_Terimabarangdetil_pphidrreal.Text = "PPh Amount (IDR)"
        '
        'obj_Terimabarangdetil_pphforeign
        '
        Me.obj_Terimabarangdetil_pphforeign.Location = New System.Drawing.Point(397, 12)
        Me.obj_Terimabarangdetil_pphforeign.MaxLength = 20
        Me.obj_Terimabarangdetil_pphforeign.Name = "obj_Terimabarangdetil_pphforeign"
        Me.obj_Terimabarangdetil_pphforeign.ReadOnly = True
        Me.obj_Terimabarangdetil_pphforeign.Size = New System.Drawing.Size(133, 20)
        Me.obj_Terimabarangdetil_pphforeign.TabIndex = 365
        Me.obj_Terimabarangdetil_pphforeign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_pphforeign
        '
        Me.lbl_Terimabarangdetil_pphforeign.AutoSize = True
        Me.lbl_Terimabarangdetil_pphforeign.Location = New System.Drawing.Point(311, 15)
        Me.lbl_Terimabarangdetil_pphforeign.Name = "lbl_Terimabarangdetil_pphforeign"
        Me.lbl_Terimabarangdetil_pphforeign.Size = New System.Drawing.Size(66, 13)
        Me.lbl_Terimabarangdetil_pphforeign.TabIndex = 366
        Me.lbl_Terimabarangdetil_pphforeign.Text = "PPh Amount"
        '
        'obj_Terimabarangdetil_disc
        '
        Me.obj_Terimabarangdetil_disc.Location = New System.Drawing.Point(101, 112)
        Me.obj_Terimabarangdetil_disc.MaxLength = 20
        Me.obj_Terimabarangdetil_disc.Name = "obj_Terimabarangdetil_disc"
        Me.obj_Terimabarangdetil_disc.ReadOnly = True
        Me.obj_Terimabarangdetil_disc.Size = New System.Drawing.Size(184, 20)
        Me.obj_Terimabarangdetil_disc.TabIndex = 363
        Me.obj_Terimabarangdetil_disc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_disc
        '
        Me.lbl_Terimabarangdetil_disc.AutoSize = True
        Me.lbl_Terimabarangdetil_disc.Location = New System.Drawing.Point(16, 110)
        Me.lbl_Terimabarangdetil_disc.Name = "lbl_Terimabarangdetil_disc"
        Me.lbl_Terimabarangdetil_disc.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Terimabarangdetil_disc.TabIndex = 364
        Me.lbl_Terimabarangdetil_disc.Text = "Discount"
        '
        'obj_Terimabarangdetil_ppnpercent
        '
        Me.obj_Terimabarangdetil_ppnpercent.Location = New System.Drawing.Point(216, 87)
        Me.obj_Terimabarangdetil_ppnpercent.MaxLength = 20
        Me.obj_Terimabarangdetil_ppnpercent.Name = "obj_Terimabarangdetil_ppnpercent"
        Me.obj_Terimabarangdetil_ppnpercent.ReadOnly = True
        Me.obj_Terimabarangdetil_ppnpercent.Size = New System.Drawing.Size(69, 20)
        Me.obj_Terimabarangdetil_ppnpercent.TabIndex = 361
        Me.obj_Terimabarangdetil_ppnpercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_ppnpercent
        '
        Me.lbl_Terimabarangdetil_ppnpercent.AutoSize = True
        Me.lbl_Terimabarangdetil_ppnpercent.Location = New System.Drawing.Point(180, 90)
        Me.lbl_Terimabarangdetil_ppnpercent.Name = "lbl_Terimabarangdetil_ppnpercent"
        Me.lbl_Terimabarangdetil_ppnpercent.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Terimabarangdetil_ppnpercent.TabIndex = 362
        Me.lbl_Terimabarangdetil_ppnpercent.Text = "PPN%"
        '
        'obj_Terimabarangdetil_pphpercent
        '
        Me.obj_Terimabarangdetil_pphpercent.Location = New System.Drawing.Point(101, 87)
        Me.obj_Terimabarangdetil_pphpercent.MaxLength = 20
        Me.obj_Terimabarangdetil_pphpercent.Name = "obj_Terimabarangdetil_pphpercent"
        Me.obj_Terimabarangdetil_pphpercent.ReadOnly = True
        Me.obj_Terimabarangdetil_pphpercent.Size = New System.Drawing.Size(73, 20)
        Me.obj_Terimabarangdetil_pphpercent.TabIndex = 359
        Me.obj_Terimabarangdetil_pphpercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_pphpercent
        '
        Me.lbl_Terimabarangdetil_pphpercent.AutoSize = True
        Me.lbl_Terimabarangdetil_pphpercent.Location = New System.Drawing.Point(17, 89)
        Me.lbl_Terimabarangdetil_pphpercent.Name = "lbl_Terimabarangdetil_pphpercent"
        Me.lbl_Terimabarangdetil_pphpercent.Size = New System.Drawing.Size(35, 13)
        Me.lbl_Terimabarangdetil_pphpercent.TabIndex = 360
        Me.lbl_Terimabarangdetil_pphpercent.Text = "PPh%"
        '
        'obj_Terimabarangdetil_idrreal
        '
        Me.obj_Terimabarangdetil_idrreal.Location = New System.Drawing.Point(101, 63)
        Me.obj_Terimabarangdetil_idrreal.MaxLength = 20
        Me.obj_Terimabarangdetil_idrreal.Name = "obj_Terimabarangdetil_idrreal"
        Me.obj_Terimabarangdetil_idrreal.ReadOnly = True
        Me.obj_Terimabarangdetil_idrreal.Size = New System.Drawing.Size(184, 20)
        Me.obj_Terimabarangdetil_idrreal.TabIndex = 357
        Me.obj_Terimabarangdetil_idrreal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_idrreal
        '
        Me.lbl_Terimabarangdetil_idrreal.AutoSize = True
        Me.lbl_Terimabarangdetil_idrreal.Location = New System.Drawing.Point(17, 66)
        Me.lbl_Terimabarangdetil_idrreal.Name = "lbl_Terimabarangdetil_idrreal"
        Me.lbl_Terimabarangdetil_idrreal.Size = New System.Drawing.Size(71, 13)
        Me.lbl_Terimabarangdetil_idrreal.TabIndex = 358
        Me.lbl_Terimabarangdetil_idrreal.Text = "Amount (IDR)"
        '
        'obj_Terimabarangdetil_foreignrate
        '
        Me.obj_Terimabarangdetil_foreignrate.Location = New System.Drawing.Point(216, 38)
        Me.obj_Terimabarangdetil_foreignrate.MaxLength = 20
        Me.obj_Terimabarangdetil_foreignrate.Name = "obj_Terimabarangdetil_foreignrate"
        Me.obj_Terimabarangdetil_foreignrate.ReadOnly = True
        Me.obj_Terimabarangdetil_foreignrate.Size = New System.Drawing.Size(69, 20)
        Me.obj_Terimabarangdetil_foreignrate.TabIndex = 355
        Me.obj_Terimabarangdetil_foreignrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_foreignrate
        '
        Me.lbl_Terimabarangdetil_foreignrate.AutoSize = True
        Me.lbl_Terimabarangdetil_foreignrate.Location = New System.Drawing.Point(180, 41)
        Me.lbl_Terimabarangdetil_foreignrate.Name = "lbl_Terimabarangdetil_foreignrate"
        Me.lbl_Terimabarangdetil_foreignrate.Size = New System.Drawing.Size(30, 13)
        Me.lbl_Terimabarangdetil_foreignrate.TabIndex = 356
        Me.lbl_Terimabarangdetil_foreignrate.Text = "Rate"
        '
        'obj_Terimabarangdetil_foreign
        '
        Me.obj_Terimabarangdetil_foreign.Location = New System.Drawing.Point(101, 12)
        Me.obj_Terimabarangdetil_foreign.MaxLength = 20
        Me.obj_Terimabarangdetil_foreign.Name = "obj_Terimabarangdetil_foreign"
        Me.obj_Terimabarangdetil_foreign.ReadOnly = True
        Me.obj_Terimabarangdetil_foreign.Size = New System.Drawing.Size(184, 20)
        Me.obj_Terimabarangdetil_foreign.TabIndex = 353
        Me.obj_Terimabarangdetil_foreign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Terimabarangdetil_foreign
        '
        Me.lbl_Terimabarangdetil_foreign.AutoSize = True
        Me.lbl_Terimabarangdetil_foreign.Location = New System.Drawing.Point(17, 15)
        Me.lbl_Terimabarangdetil_foreign.Name = "lbl_Terimabarangdetil_foreign"
        Me.lbl_Terimabarangdetil_foreign.Size = New System.Drawing.Size(43, 13)
        Me.lbl_Terimabarangdetil_foreign.TabIndex = 354
        Me.lbl_Terimabarangdetil_foreign.Text = "Amount"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Spell.ico")
        Me.ImageList1.Images.SetKeyName(1, "Stop 2.ico")
        Me.ImageList1.Images.SetKeyName(2, "home.ico")
        '
        'uiTrnPenerimaanBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.pnlDetil)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiTrnPenerimaanBarang"
        Me.Size = New System.Drawing.Size(990, 548)
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.Controls.SetChildIndex(Me.pnlDetil, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvTrnPenerimaanbarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfFooter.ResumeLayout(False)
        Me.PnlDfFooter.PerformLayout()
        CType(Me.obj_top, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Detil.ResumeLayout(False)
        CType(Me.TLTrnPenerimaanBarangDetil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnBrowseDetil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryAssetType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryAssetCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCatDepre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCategoryId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryBrandId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryMaterialId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryColourId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySizeId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySexId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryRoomId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryShowId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryShowIdCont, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryUnitId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ftabDataDetil_Info.ResumeLayout(False)
        Me.ftabDataDetil_Info.PerformLayout()
        Me.ftabDataDetil_jurnal.ResumeLayout(False)
        Me.FtabJurnal.ResumeLayout(False)
        Me.ftabDataDetil_Pembayaran.ResumeLayout(False)
        CType(Me.DgvTrnJurnaldetil_Pembayaran, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.DgvTrnJurnaldetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Reference.ResumeLayout(False)
        CType(Me.DgvTrnJurnalreference, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabDataDetil_Response.ResumeLayout(False)
        CType(Me.DgvTrnJurnalresponse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        CType(Me.obj_terimabarang_tglsuratjalan.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_terimabarang_tglsuratjalan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetil.ResumeLayout(False)
        Me.FlatTabControl1.ResumeLayout(False)
        Me.TabDetail.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PnlFoto.ResumeLayout(False)
        CType(Me.obj_photo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAccounting.ResumeLayout(False)
        Me.Panel_bawah.ResumeLayout(False)
        Me.Panel_bawah.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDataMaster As System.Windows.Forms.Panel
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Detil As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnPenerimaanbarang As System.Windows.Forms.DataGridView
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Terimabarang_id As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_date As System.Windows.Forms.Label
    Friend WithEvents lbl_Terimabarang_type As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_type As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_id As System.Windows.Forms.Label
    Friend WithEvents obj_Order_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Budget_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Rekanan_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Employee_id_owner As System.Windows.Forms.Label
    Friend WithEvents lbl_Strukturunit_id As System.Windows.Forms.Label
    Friend WithEvents obj_Strukturunit_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_qtyitem As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_qtyitem As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_qtyrealization As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_qtyrealization As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Order_qty As System.Windows.Forms.Label
    Friend WithEvents obj_Order_qty As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_status As System.Windows.Forms.Label
    Friend WithEvents lbl_Terimabarang_statusrealization As System.Windows.Forms.Label
    Friend WithEvents lbl_Terimabarang_location As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_location As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_notes As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_notes As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_nosuratjalan As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_nosuratjalan As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Channel_id As System.Windows.Forms.Label
    Friend WithEvents obj_Channel_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_Terimabarang_isdisabled As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Terimabarang_createby As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_createby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_createdt As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_createdt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_modifiedby As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_modifiedby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_modifieddt As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_modifieddt As System.Windows.Forms.TextBox
    Friend WithEvents obj_Terimabarang_appuser As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Terimabarang_appuser_by As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_appuser_by As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_appuser_dt As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_appuser_dt As System.Windows.Forms.TextBox
    Friend WithEvents obj_Terimabarang_appspv As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Terimabarang_appspv_by As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_appspv_by As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_appspv_dt As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_appspv_dt As System.Windows.Forms.TextBox
    Friend WithEvents obj_Terimabarang_appacc As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Terimabarang_appacc_by As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_appacc_by As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_appacc_dt As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_appacc_dt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_foreign As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_foreign As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Currency_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Terimabarang_foreignrate As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_foreignrate As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_idrreal As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_idrreal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_pph As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_pph As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_ppn As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_ppn As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_disc As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_disc As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarang_cetakbpb As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_cetakbpb As System.Windows.Forms.TextBox
    Friend WithEvents ftabDataDetil_Info As System.Windows.Forms.TabPage
    Friend WithEvents ftabDataDetil_jurnal As System.Windows.Forms.TabPage
    Friend WithEvents obj_Terimabarang_date As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btn_order As System.Windows.Forms.Button
    Friend WithEvents obj_Rekanan_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Budget_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Terimabarang_status As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Terimabarang_statusrealization As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Employee_id_owner As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Currency_id As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents obj_top As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblLoading As System.Windows.Forms.Label
    Friend WithEvents obj_ProgressBar_backGroundWorker As System.Windows.Forms.ProgressBar
    Friend WithEvents obj_Rekanan_id_search As System.Windows.Forms.TextBox
    Friend WithEvents btn_Rekanan As System.Windows.Forms.Button
    Friend WithEvents obj_RvID_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_RvID_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_orderID_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_orderID_search As System.Windows.Forms.CheckBox
    Friend WithEvents cmb_appuser As System.Windows.Forms.ComboBox
    Friend WithEvents chk_User_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Strukturunit_id_pemilik_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Strukturunit_id_pemilik_search As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Rekanan_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Btn_Add As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlClose2 As System.Windows.Forms.Panel
    Friend WithEvents FtabJurnal As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Pembayaran As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnJurnaldetil_Pembayaran As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents DgvTrnJurnaldetil As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataDetil_Reference As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnJurnalreference As System.Windows.Forms.DataGridView
    Friend WithEvents ftabDataDetil_Response As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnJurnalresponse As System.Windows.Forms.DataGridView
    Friend WithEvents pnlDetil As System.Windows.Forms.Panel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel_bawah As System.Windows.Forms.Panel
    Friend WithEvents lbl_Currency_iddetil As System.Windows.Forms.Label
    Friend WithEvents obj_Currency_iddetil As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Terimabarangdetil_totalidrreal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_totalidrreal As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_totalforeign As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_totalforeign As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_ppnidrreal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_ppnidrreal As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_ppnforeign As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_ppnforeign As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_pphidrreal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_pphidrreal As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_pphforeign As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_pphforeign As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_disc As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_disc As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_ppnpercent As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_ppnpercent As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_pphpercent As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_pphpercent As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_idrreal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_idrreal As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_foreignrate As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_foreignrate As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_foreign As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_foreign As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_depre_enddt As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Acc_id As System.Windows.Forms.Label
    Friend WithEvents obj_Acc_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Orderdetil_line As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Orderdetil_line As System.Windows.Forms.Label
    Friend WithEvents obj_Orderdetil_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Orderdetil_id As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_eps As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_eps As System.Windows.Forms.Label
    Friend WithEvents lbl_Show_id_cont As System.Windows.Forms.Label
    Friend WithEvents obj_Show_id_cont As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Show_id As System.Windows.Forms.Label
    Friend WithEvents obj_Show_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Terimabarangdetil_depre_enddt As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_nonfixasset As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Kategoriasset_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Tipeasset_id As System.Windows.Forms.Label
    Friend WithEvents obj_Assettype_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Unit_id As System.Windows.Forms.Label
    Friend WithEvents obj_Unit_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Terimabarangdetil_qty As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_qty As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_rack As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_rack As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Room_id As System.Windows.Forms.Label
    Friend WithEvents obj_Room_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Sex_id As System.Windows.Forms.Label
    Friend WithEvents obj_Sex_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Size_id As System.Windows.Forms.Label
    Friend WithEvents obj_Size_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Colour_id As System.Windows.Forms.Label
    Friend WithEvents obj_Colour_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Material_id As System.Windows.Forms.Label
    Friend WithEvents obj_Material_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Terimabarangdetil_model As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_model As System.Windows.Forms.Label
    Friend WithEvents lbl_Terimabarangdetil_product_no As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_serial_no As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_serial_no As System.Windows.Forms.Label
    Friend WithEvents lbl_brand_id As System.Windows.Forms.Label
    Friend WithEvents obj_Brand_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Itemtype_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Itemcategory_id As System.Windows.Forms.Label
    Friend WithEvents obj_Itemcategory_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Item_id As System.Windows.Forms.Label
    Friend WithEvents obj_Item_id As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents obj_Terimabarang_parentbarcode As System.Windows.Forms.TextBox
    Friend WithEvents obj_Terimabarang_barcode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_barcode As System.Windows.Forms.Label
    Friend WithEvents lbl_Asset_barcodeinduk As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_desc As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_desc As System.Windows.Forms.Label
    Friend WithEvents lbl_Terimabarangdetil_lineparent As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_parentline As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_line As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_line As System.Windows.Forms.TextBox
    Friend WithEvents obj_asset_terimabarangdetil_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_id As System.Windows.Forms.Label
    Friend WithEvents btn_Parent As System.Windows.Forms.Button
    Friend WithEvents obj_Jurnal_bookdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Jurnal_bookdate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_periode As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Terimabarangdetil_product_no As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrintAllBarcode As System.Windows.Forms.Button
    Friend WithEvents obj_Itemtype_id As System.Windows.Forms.TextBox
    Friend WithEvents lblQtyTotal As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_qtytotal As System.Windows.Forms.TextBox
    Friend WithEvents obj_Terimabarangdetil_qtydetail As System.Windows.Forms.TextBox
    Friend WithEvents lblQtyDetail As System.Windows.Forms.Label
    Friend WithEvents btnSerial As System.Windows.Forms.Button
    Friend WithEvents obj_strukturunit_name As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents obj_budgetdetil_name As System.Windows.Forms.TextBox
    Friend WithEvents obj_budget_name As System.Windows.Forms.TextBox
    Friend WithEvents FlatTabControl1 As FlatTabControl.FlatTabControl
    Friend WithEvents TabDetail As System.Windows.Forms.TabPage
    Friend WithEvents TabAccounting As System.Windows.Forms.TabPage
    Friend WithEvents PnlFoto As System.Windows.Forms.Panel
    Friend WithEvents btnCapture As System.Windows.Forms.Button
    Friend WithEvents VideoCapture As VidGrab.VideoGrabber
    Friend WithEvents obj_photo As System.Windows.Forms.PictureBox
    Friend WithEvents btnCaptureCancel As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCategory As System.Windows.Forms.Button
    Friend WithEvents obj_Assetcategory_id As System.Windows.Forms.TextBox
    Friend WithEvents btnItemCategorySelect As System.Windows.Forms.Button
    Friend WithEvents btnItemSelect As System.Windows.Forms.Button
    Friend WithEvents TLTrnPenerimaanBarangDetil As DevExpress.XtraTreeList.TreeList
    Friend WithEvents cterimabarang_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarang_barcode As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cprint_barcode As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryItemButtonPrint As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents cprint_barcodekain As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_desc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_type As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_parentline As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarang_parentbarcode As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_nonfixasset As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_date As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cassettype_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryAssetType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cassetcategory_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryAssetCategory As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents citem_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryItemId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents citemcategory_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryItemCategoryId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents citemtype_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cbrand_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryBrandId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cterimabarangdetil_serial_no As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_product_no As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_model As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cmaterial_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryMaterialId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ccolour_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryColourId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents csize_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositorySizeId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents csex_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositorySexId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents croom_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryRoomId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cterimabarangdetil_rack As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cshow_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryShowId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cShow_id_cont As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryShowIdCont As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cterimabarangdetil_eps As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_qty As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cunit_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryUnitId As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ccurrency_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryCurrency As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cterimabarangdetil_foreign As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_foreignrate As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_idrreal As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_pphpercent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_ppnpercent As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_disc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_pphforeign As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_pphidrreal As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_ppnforeign As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_ppnidrreal As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_totalforeign As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_totalidrreal As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_golfiskal As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cterimabarangdetil_depre_enddt As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cemployee_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cstrukturunit_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cwriteoff_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cwriteoff_dt As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents corder_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents corderdetil_line As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cbudget_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cbudgetdetil_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cacc_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cchannel_id As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ccreate_by As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ccreate_dt As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cmodified_by As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cmodified_dt As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents select_detail As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents btnBrowseDetil As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents cterimabarangdetil_line As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents obj_Terimabarangdetil_golfiskal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents pnlclose3 As System.Windows.Forms.Panel
    Friend WithEvents obj_terimabarang_tglsuratjalan As DevExpress.XtraEditors.DateEdit
    Friend WithEvents RepositoryCatDepre As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class

