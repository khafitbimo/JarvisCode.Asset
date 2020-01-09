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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnPenerimaanBarang))
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblLoading = New System.Windows.Forms.Label
        Me.obj_ProgressBar_backGroundWorker = New System.Windows.Forms.ProgressBar
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvTrnPenerimaanbarang = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.obj_top = New System.Windows.Forms.NumericUpDown
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.obj_Rekanan_id_search = New System.Windows.Forms.TextBox
        Me.btn_Rekanan = New System.Windows.Forms.Button
        Me.obj_RvID_search = New System.Windows.Forms.TextBox
        Me.chk_RvID_search = New System.Windows.Forms.CheckBox
        Me.obj_orderID_search = New System.Windows.Forms.TextBox
        Me.chk_orderID_search = New System.Windows.Forms.CheckBox
        Me.cmb_appuser = New System.Windows.Forms.ComboBox
        Me.chk_User_search = New System.Windows.Forms.CheckBox
        Me.obj_Strukturunit_id_pemilik_search = New System.Windows.Forms.ComboBox
        Me.chk_Strukturunit_id_pemilik_search = New System.Windows.Forms.CheckBox
        Me.chk_Rekanan_id_search = New System.Windows.Forms.CheckBox
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl
        Me.ftabDataDetil_Detil = New System.Windows.Forms.TabPage
        Me.DgvTrnPenerimaanbarangdetil = New System.Windows.Forms.DataGridView
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btnPrintAllBarcode = New System.Windows.Forms.Button
        Me.Btn_Add = New System.Windows.Forms.Button
        Me.ftabDataDetil_Info = New System.Windows.Forms.TabPage
        Me.obj_Strukturunit_id = New System.Windows.Forms.TextBox
        Me.lbl_Strukturunit_id = New System.Windows.Forms.Label
        Me.obj_Terimabarang_isdisabled = New System.Windows.Forms.CheckBox
        Me.obj_Terimabarang_modifiedby = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_modifieddt = New System.Windows.Forms.Label
        Me.obj_Terimabarang_modifieddt = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_modifiedby = New System.Windows.Forms.Label
        Me.lbl_Terimabarang_createdt = New System.Windows.Forms.Label
        Me.obj_Terimabarang_createdt = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_createby = New System.Windows.Forms.Label
        Me.obj_Terimabarang_createby = New System.Windows.Forms.TextBox
        Me.obj_Terimabarang_cetakbpb = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_cetakbpb = New System.Windows.Forms.Label
        Me.obj_Terimabarang_appuser_dt = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_appspv_dt = New System.Windows.Forms.Label
        Me.obj_Terimabarang_appspv_dt = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_appspv_by = New System.Windows.Forms.Label
        Me.obj_Terimabarang_appspv_by = New System.Windows.Forms.TextBox
        Me.obj_Terimabarang_appspv = New System.Windows.Forms.CheckBox
        Me.lbl_Terimabarang_appuser_dt = New System.Windows.Forms.Label
        Me.lbl_Terimabarang_appuser_by = New System.Windows.Forms.Label
        Me.obj_Terimabarang_appuser_by = New System.Windows.Forms.TextBox
        Me.obj_Terimabarang_appuser = New System.Windows.Forms.CheckBox
        Me.obj_Terimabarang_appacc_dt = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_appacc_dt = New System.Windows.Forms.Label
        Me.lbl_Terimabarang_appacc_by = New System.Windows.Forms.Label
        Me.obj_Terimabarang_appacc_by = New System.Windows.Forms.TextBox
        Me.obj_Terimabarang_appacc = New System.Windows.Forms.CheckBox
        Me.ftabDataDetil_jurnal = New System.Windows.Forms.TabPage
        Me.pnlclose3 = New System.Windows.Forms.Panel
        Me.FtabJurnal = New FlatTabControl.FlatTabControl
        Me.ftabDataDetil_Pembayaran = New System.Windows.Forms.TabPage
        Me.DgvTrnJurnaldetil_Pembayaran = New System.Windows.Forms.DataGridView
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.DgvTrnJurnaldetil = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Reference = New System.Windows.Forms.TabPage
        Me.DgvTrnJurnalreference = New System.Windows.Forms.DataGridView
        Me.ftabDataDetil_Response = New System.Windows.Forms.TabPage
        Me.DgvTrnJurnalresponse = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.pnlClose2 = New System.Windows.Forms.Panel
        Me.obj_Jurnal_bookdate = New System.Windows.Forms.DateTimePicker
        Me.lbl_Jurnal_bookdate = New System.Windows.Forms.Label
        Me.obj_Currency_id = New System.Windows.Forms.ComboBox
        Me.obj_Terimabarang_ppn = New System.Windows.Forms.TextBox
        Me.obj_Terimabarang_pph = New System.Windows.Forms.TextBox
        Me.obj_Terimabarang_disc = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_ppn = New System.Windows.Forms.Label
        Me.lbl_Terimabarang_disc = New System.Windows.Forms.Label
        Me.obj_Terimabarang_foreign = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_pph = New System.Windows.Forms.Label
        Me.lbl_Terimabarang_foreign = New System.Windows.Forms.Label
        Me.lbl_Terimabarang_idrreal = New System.Windows.Forms.Label
        Me.lbl_Currency_id = New System.Windows.Forms.Label
        Me.obj_Terimabarang_idrreal = New System.Windows.Forms.TextBox
        Me.obj_Terimabarang_foreignrate = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_foreignrate = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_periode = New System.Windows.Forms.ComboBox
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.obj_Employee_id_owner = New System.Windows.Forms.ComboBox
        Me.obj_Terimabarang_status = New System.Windows.Forms.ComboBox
        Me.obj_Terimabarang_statusrealization = New System.Windows.Forms.ComboBox
        Me.obj_Budget_id = New System.Windows.Forms.ComboBox
        Me.obj_Rekanan_id = New System.Windows.Forms.ComboBox
        Me.btn_order = New System.Windows.Forms.Button
        Me.obj_Terimabarang_date = New System.Windows.Forms.MaskedTextBox
        Me.obj_Terimabarang_id = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_id = New System.Windows.Forms.Label
        Me.lbl_Terimabarang_date = New System.Windows.Forms.Label
        Me.obj_Terimabarang_type = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_type = New System.Windows.Forms.Label
        Me.obj_Order_id = New System.Windows.Forms.TextBox
        Me.lbl_Order_id = New System.Windows.Forms.Label
        Me.lbl_Budget_id = New System.Windows.Forms.Label
        Me.lbl_Rekanan_id = New System.Windows.Forms.Label
        Me.lbl_Employee_id_owner = New System.Windows.Forms.Label
        Me.obj_Terimabarang_qtyitem = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_qtyitem = New System.Windows.Forms.Label
        Me.obj_Terimabarang_qtyrealization = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_qtyrealization = New System.Windows.Forms.Label
        Me.obj_Order_qty = New System.Windows.Forms.TextBox
        Me.lbl_Order_qty = New System.Windows.Forms.Label
        Me.lbl_Terimabarang_status = New System.Windows.Forms.Label
        Me.lbl_Terimabarang_statusrealization = New System.Windows.Forms.Label
        Me.obj_Terimabarang_location = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_location = New System.Windows.Forms.Label
        Me.obj_Terimabarang_notes = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_notes = New System.Windows.Forms.Label
        Me.obj_Terimabarang_nosuratjalan = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_nosuratjalan = New System.Windows.Forms.Label
        Me.obj_Channel_id = New System.Windows.Forms.TextBox
        Me.lbl_Channel_id = New System.Windows.Forms.Label
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyWihChildToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.pnlDetil = New System.Windows.Forms.Panel
        Me.Panel_bawah = New System.Windows.Forms.Panel
        Me.Panel_tutup = New System.Windows.Forms.Panel
        Me.lbl_Currency_iddetil = New System.Windows.Forms.Label
        Me.obj_Currency_iddetil = New System.Windows.Forms.ComboBox
        Me.obj_Terimabarangdetil_totalidrreal = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_totalidrreal = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_totalforeign = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_totalforeign = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_ppnidrreal = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_ppnidrreal = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_ppnforeign = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_ppnforeign = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_pphidrreal = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_pphidrreal = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_pphforeign = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_pphforeign = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_disc = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_disc = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_ppnpercent = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_ppnpercent = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_pphpercent = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_pphpercent = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_idrreal = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_idrreal = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_foreignrate = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_foreignrate = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_foreign = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_foreign = New System.Windows.Forms.Label
        Me.Panel_atas = New System.Windows.Forms.Panel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.obj_Terimabarangdetil_depre_enddt = New System.Windows.Forms.DateTimePicker
        Me.Button14 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.lbl_Acc_id = New System.Windows.Forms.Label
        Me.obj_Acc_id = New System.Windows.Forms.ComboBox
        Me.lbl_Budgetdetil_id = New System.Windows.Forms.Label
        Me.obj_Budgetdetil_id = New System.Windows.Forms.ComboBox
        Me.lbl_Budget_iddetil = New System.Windows.Forms.Label
        Me.obj_Budget_iddetil = New System.Windows.Forms.ComboBox
        Me.obj_Orderdetil_line = New System.Windows.Forms.TextBox
        Me.lbl_Orderdetil_line = New System.Windows.Forms.Label
        Me.obj_Orderdetil_id = New System.Windows.Forms.TextBox
        Me.lbl_Orderdetil_id = New System.Windows.Forms.Label
        Me.obj_Writeoff_dt = New System.Windows.Forms.DateTimePicker
        Me.lbl_Writeoff_dt = New System.Windows.Forms.Label
        Me.obj_Writeoff_id = New System.Windows.Forms.TextBox
        Me.lbl_Writeoff_id = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_eps = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_eps = New System.Windows.Forms.Label
        Me.lbl_Show_id_cont = New System.Windows.Forms.Label
        Me.obj_Show_id_cont = New System.Windows.Forms.ComboBox
        Me.lbl_Show_id = New System.Windows.Forms.Label
        Me.obj_Show_id = New System.Windows.Forms.ComboBox
        Me.lbl_Strukturunitdetil_id = New System.Windows.Forms.Label
        Me.obj_Strukturunitdetil_id = New System.Windows.Forms.ComboBox
        Me.lbl_Employee_id = New System.Windows.Forms.Label
        Me.obj_Employee_id = New System.Windows.Forms.ComboBox
        Me.lbl_Terimabarangdetil_depre_enddt = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_golfiskal = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_golfiskal = New System.Windows.Forms.Label
        Me.lbl_Kategoriasset_id = New System.Windows.Forms.Label
        Me.lbl_Tipeasset_id = New System.Windows.Forms.Label
        Me.obj_Assettype_id = New System.Windows.Forms.ComboBox
        Me.obj_Assetcategory_id = New System.Windows.Forms.ComboBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Btn_Category = New System.Windows.Forms.Button
        Me.lbl_Unit_id = New System.Windows.Forms.Label
        Me.obj_Unit_id = New System.Windows.Forms.ComboBox
        Me.lbl_Terimabarangdetil_qty = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_qty = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_rack = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_rack = New System.Windows.Forms.TextBox
        Me.lbl_Room_id = New System.Windows.Forms.Label
        Me.obj_Room_id = New System.Windows.Forms.ComboBox
        Me.lbl_Sex_id = New System.Windows.Forms.Label
        Me.obj_Sex_id = New System.Windows.Forms.ComboBox
        Me.lbl_Size_id = New System.Windows.Forms.Label
        Me.obj_Size_id = New System.Windows.Forms.ComboBox
        Me.lbl_Colour_id = New System.Windows.Forms.Label
        Me.obj_Colour_id = New System.Windows.Forms.ComboBox
        Me.lbl_Material_id = New System.Windows.Forms.Label
        Me.obj_Material_id = New System.Windows.Forms.ComboBox
        Me.obj_Terimabarangdetil_model = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_model = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_serial_no = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_serial_no = New System.Windows.Forms.Label
        Me.lbl_brand_id = New System.Windows.Forms.Label
        Me.obj_Brand_id = New System.Windows.Forms.ComboBox
        Me.lbl_Itemtype_id = New System.Windows.Forms.Label
        Me.obj_Itemtype_id = New System.Windows.Forms.ComboBox
        Me.lbl_Itemcategory_id = New System.Windows.Forms.Label
        Me.obj_Itemcategory_id = New System.Windows.Forms.ComboBox
        Me.lbl_Item_id = New System.Windows.Forms.Label
        Me.obj_Item_id = New System.Windows.Forms.ComboBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.obj_Terimabarangdetil_product_no = New System.Windows.Forms.ComboBox
        Me.btn_Parent = New System.Windows.Forms.Button
        Me.obj_Terimabarangdetil_line = New System.Windows.Forms.TextBox
        Me.obj_Terimabarang_parentbarcode = New System.Windows.Forms.TextBox
        Me.lbl_Channel_iddetil = New System.Windows.Forms.Label
        Me.obj_Channel_iddetil = New System.Windows.Forms.TextBox
        Me.obj_Terimabarang_barcode = New System.Windows.Forms.TextBox
        Me.lbl_Asset_barcode = New System.Windows.Forms.Label
        Me.lbl_Asset_barcodeinduk = New System.Windows.Forms.Label
        Me.lbl_Terimabarangdetil_type = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_type = New System.Windows.Forms.TextBox
        Me.obj_Terimabarangdetil_date = New System.Windows.Forms.DateTimePicker
        Me.lbl_Terimabarangdetil_date = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_desc = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_desc = New System.Windows.Forms.Label
        Me.lbl_Terimabarangdetil_lineparent = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_parentline = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_line = New System.Windows.Forms.Label
        Me.obj_asset_terimabarangdetil_id = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarangdetil_id = New System.Windows.Forms.Label
        Me.obj_Terimabarangdetil_nonfixasset = New System.Windows.Forms.CheckBox
        Me.lbl_Terimabarangdetil_product_no = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btn_BuiltJurnal = New System.Windows.Forms.ToolStripMenuItem
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
        CType(Me.DgvTrnPenerimaanbarangdetil, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnlDetil.SuspendLayout()
        Me.Panel_bawah.SuspendLayout()
        Me.Panel_atas.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(3, 96)
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
        Me.Panel1.Location = New System.Drawing.Point(191, 111)
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
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 131)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 296)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvTrnPenerimaanbarang
        '
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
        Me.obj_top.Value = New Decimal(New Integer() {100, 0, 0, 0})
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
        Me.Label36.Size = New System.Drawing.Size(79, 13)
        Me.Label36.TabIndex = 63
        Me.Label36.Text = "Approved BMA"
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
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 111)
        Me.PnlDfSearch.TabIndex = 0
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
        Me.obj_RvID_search.Name = "obj_RvID_search"
        Me.obj_RvID_search.Size = New System.Drawing.Size(233, 20)
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
        Me.chkSearchChannel.Location = New System.Drawing.Point(17, 15)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 0
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
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
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 183)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.White
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(733, 217)
        Me.ftabDataDetil.TabIndex = 3
        '
        'ftabDataDetil_Detil
        '
        Me.ftabDataDetil_Detil.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Detil.Controls.Add(Me.DgvTrnPenerimaanbarangdetil)
        Me.ftabDataDetil_Detil.Controls.Add(Me.Panel4)
        Me.ftabDataDetil_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Detil.Name = "ftabDataDetil_Detil"
        Me.ftabDataDetil_Detil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Detil.Size = New System.Drawing.Size(725, 188)
        Me.ftabDataDetil_Detil.TabIndex = 0
        Me.ftabDataDetil_Detil.Text = "Detil"
        '
        'DgvTrnPenerimaanbarangdetil
        '
        Me.DgvTrnPenerimaanbarangdetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnPenerimaanbarangdetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnPenerimaanbarangdetil.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnPenerimaanbarangdetil.Name = "DgvTrnPenerimaanbarangdetil"
        Me.DgvTrnPenerimaanbarangdetil.Size = New System.Drawing.Size(719, 151)
        Me.DgvTrnPenerimaanbarangdetil.TabIndex = 6
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnPrintAllBarcode)
        Me.Panel4.Controls.Add(Me.Btn_Add)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 154)
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
        '
        'lbl_Strukturunit_id
        '
        Me.lbl_Strukturunit_id.AutoSize = True
        Me.lbl_Strukturunit_id.Location = New System.Drawing.Point(12, 204)
        Me.lbl_Strukturunit_id.Name = "lbl_Strukturunit_id"
        Me.lbl_Strukturunit_id.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Strukturunit_id.TabIndex = 0
        Me.lbl_Strukturunit_id.Text = "Department"
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
        '
        'lbl_Terimabarang_cetakbpb
        '
        Me.lbl_Terimabarang_cetakbpb.AutoSize = True
        Me.lbl_Terimabarang_cetakbpb.Location = New System.Drawing.Point(255, 204)
        Me.lbl_Terimabarang_cetakbpb.Name = "lbl_Terimabarang_cetakbpb"
        Me.lbl_Terimabarang_cetakbpb.Size = New System.Drawing.Size(57, 13)
        Me.lbl_Terimabarang_cetakbpb.TabIndex = 0
        Me.lbl_Terimabarang_cetakbpb.Text = "Cetak BPJ"
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
        Me.pnlclose3.Location = New System.Drawing.Point(414, 71)
        Me.pnlclose3.Name = "pnlclose3"
        Me.pnlclose3.Size = New System.Drawing.Size(198, 28)
        Me.pnlclose3.TabIndex = 366
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
        Me.pnlClose2.Location = New System.Drawing.Point(421, 32)
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
        Me.obj_Currency_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Currency_id.Enabled = False
        Me.obj_Currency_id.Items.AddRange(New Object() {"-- Pilih --", "COMPLETE", "INCOMPLETE"})
        Me.obj_Currency_id.Location = New System.Drawing.Point(64, 7)
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
        Me.obj_Terimabarang_pph.BackColor = System.Drawing.SystemColors.Info
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
        Me.obj_Terimabarang_foreign.BackColor = System.Drawing.SystemColors.Info
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
        Me.obj_Terimabarang_idrreal.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_idrreal.Location = New System.Drawing.Point(237, 30)
        Me.obj_Terimabarang_idrreal.Name = "obj_Terimabarang_idrreal"
        Me.obj_Terimabarang_idrreal.ReadOnly = True
        Me.obj_Terimabarang_idrreal.Size = New System.Drawing.Size(116, 20)
        Me.obj_Terimabarang_idrreal.TabIndex = 1
        '
        'obj_Terimabarang_foreignrate
        '
        Me.obj_Terimabarang_foreignrate.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_foreignrate.Location = New System.Drawing.Point(64, 29)
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
        Me.PnlDataMaster.Controls.Add(Me.obj_Employee_id_owner)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_status)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_statusrealization)
        Me.PnlDataMaster.Controls.Add(Me.obj_Budget_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.btn_order)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimabarang_date)
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
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 180)
        Me.PnlDataMaster.TabIndex = 0
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
        Me.obj_Terimabarang_status.Location = New System.Drawing.Point(113, 83)
        Me.obj_Terimabarang_status.Name = "obj_Terimabarang_status"
        Me.obj_Terimabarang_status.Size = New System.Drawing.Size(100, 21)
        Me.obj_Terimabarang_status.TabIndex = 364
        '
        'obj_Terimabarang_statusrealization
        '
        Me.obj_Terimabarang_statusrealization.Items.AddRange(New Object() {"-- Pilih --", "Telat & Sesuai", "Telat & Tidak Sesuai", "Tepat Waktu & Sesuai", "Tepat Waktu & Tidak Sesuai"})
        Me.obj_Terimabarang_statusrealization.Location = New System.Drawing.Point(113, 106)
        Me.obj_Terimabarang_statusrealization.Name = "obj_Terimabarang_statusrealization"
        Me.obj_Terimabarang_statusrealization.Size = New System.Drawing.Size(170, 21)
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
        Me.obj_Rekanan_id.Enabled = False
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
        'obj_Terimabarang_date
        '
        Me.obj_Terimabarang_date.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_date.Location = New System.Drawing.Point(291, 7)
        Me.obj_Terimabarang_date.Mask = "00/00/0000"
        Me.obj_Terimabarang_date.Name = "obj_Terimabarang_date"
        Me.obj_Terimabarang_date.ReadOnly = True
        Me.obj_Terimabarang_date.Size = New System.Drawing.Size(73, 20)
        Me.obj_Terimabarang_date.TabIndex = 42
        Me.obj_Terimabarang_date.TabStop = False
        '
        'obj_Terimabarang_id
        '
        Me.obj_Terimabarang_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_id.Location = New System.Drawing.Point(113, 7)
        Me.obj_Terimabarang_id.Name = "obj_Terimabarang_id"
        Me.obj_Terimabarang_id.ReadOnly = True
        Me.obj_Terimabarang_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Terimabarang_id.TabIndex = 1
        '
        'lbl_Terimabarang_id
        '
        Me.lbl_Terimabarang_id.AutoSize = True
        Me.lbl_Terimabarang_id.Location = New System.Drawing.Point(16, 10)
        Me.lbl_Terimabarang_id.Name = "lbl_Terimabarang_id"
        Me.lbl_Terimabarang_id.Size = New System.Drawing.Size(67, 13)
        Me.lbl_Terimabarang_id.TabIndex = 0
        Me.lbl_Terimabarang_id.Text = "Receive No."
        '
        'lbl_Terimabarang_date
        '
        Me.lbl_Terimabarang_date.AutoSize = True
        Me.lbl_Terimabarang_date.Location = New System.Drawing.Point(219, 10)
        Me.lbl_Terimabarang_date.Name = "lbl_Terimabarang_date"
        Me.lbl_Terimabarang_date.Size = New System.Drawing.Size(73, 13)
        Me.lbl_Terimabarang_date.TabIndex = 0
        Me.lbl_Terimabarang_date.Text = "Receive Date"
        '
        'obj_Terimabarang_type
        '
        Me.obj_Terimabarang_type.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Terimabarang_type.Location = New System.Drawing.Point(113, 39)
        Me.obj_Terimabarang_type.Name = "obj_Terimabarang_type"
        Me.obj_Terimabarang_type.ReadOnly = True
        Me.obj_Terimabarang_type.Size = New System.Drawing.Size(100, 20)
        Me.obj_Terimabarang_type.TabIndex = 1
        '
        'lbl_Terimabarang_type
        '
        Me.lbl_Terimabarang_type.AutoSize = True
        Me.lbl_Terimabarang_type.Location = New System.Drawing.Point(16, 42)
        Me.lbl_Terimabarang_type.Name = "lbl_Terimabarang_type"
        Me.lbl_Terimabarang_type.Size = New System.Drawing.Size(74, 13)
        Me.lbl_Terimabarang_type.TabIndex = 0
        Me.lbl_Terimabarang_type.Text = "Receive Type"
        '
        'obj_Order_id
        '
        Me.obj_Order_id.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Order_id.Location = New System.Drawing.Point(113, 61)
        Me.obj_Order_id.Name = "obj_Order_id"
        Me.obj_Order_id.ReadOnly = True
        Me.obj_Order_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Order_id.TabIndex = 1
        '
        'lbl_Order_id
        '
        Me.lbl_Order_id.AutoSize = True
        Me.lbl_Order_id.Location = New System.Drawing.Point(16, 64)
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
        Me.obj_Terimabarang_qtyrealization.Location = New System.Drawing.Point(113, 152)
        Me.obj_Terimabarang_qtyrealization.Name = "obj_Terimabarang_qtyrealization"
        Me.obj_Terimabarang_qtyrealization.ReadOnly = True
        Me.obj_Terimabarang_qtyrealization.Size = New System.Drawing.Size(55, 20)
        Me.obj_Terimabarang_qtyrealization.TabIndex = 1
        '
        'lbl_Terimabarang_qtyrealization
        '
        Me.lbl_Terimabarang_qtyrealization.AutoSize = True
        Me.lbl_Terimabarang_qtyrealization.Location = New System.Drawing.Point(16, 155)
        Me.lbl_Terimabarang_qtyrealization.Name = "lbl_Terimabarang_qtyrealization"
        Me.lbl_Terimabarang_qtyrealization.Size = New System.Drawing.Size(78, 13)
        Me.lbl_Terimabarang_qtyrealization.TabIndex = 0
        Me.lbl_Terimabarang_qtyrealization.Text = "Qty Realization"
        '
        'obj_Order_qty
        '
        Me.obj_Order_qty.BackColor = System.Drawing.SystemColors.Info
        Me.obj_Order_qty.Location = New System.Drawing.Point(241, 152)
        Me.obj_Order_qty.Name = "obj_Order_qty"
        Me.obj_Order_qty.ReadOnly = True
        Me.obj_Order_qty.Size = New System.Drawing.Size(42, 20)
        Me.obj_Order_qty.TabIndex = 1
        '
        'lbl_Order_qty
        '
        Me.lbl_Order_qty.AutoSize = True
        Me.lbl_Order_qty.Location = New System.Drawing.Point(183, 155)
        Me.lbl_Order_qty.Name = "lbl_Order_qty"
        Me.lbl_Order_qty.Size = New System.Drawing.Size(52, 13)
        Me.lbl_Order_qty.TabIndex = 0
        Me.lbl_Order_qty.Text = "Qty Order"
        '
        'lbl_Terimabarang_status
        '
        Me.lbl_Terimabarang_status.AutoSize = True
        Me.lbl_Terimabarang_status.Location = New System.Drawing.Point(16, 86)
        Me.lbl_Terimabarang_status.Name = "lbl_Terimabarang_status"
        Me.lbl_Terimabarang_status.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Terimabarang_status.TabIndex = 0
        Me.lbl_Terimabarang_status.Text = "Status"
        '
        'lbl_Terimabarang_statusrealization
        '
        Me.lbl_Terimabarang_statusrealization.AutoSize = True
        Me.lbl_Terimabarang_statusrealization.Location = New System.Drawing.Point(16, 108)
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
        Me.obj_Terimabarang_nosuratjalan.Location = New System.Drawing.Point(113, 130)
        Me.obj_Terimabarang_nosuratjalan.Name = "obj_Terimabarang_nosuratjalan"
        Me.obj_Terimabarang_nosuratjalan.Size = New System.Drawing.Size(100, 20)
        Me.obj_Terimabarang_nosuratjalan.TabIndex = 1
        '
        'lbl_Terimabarang_nosuratjalan
        '
        Me.lbl_Terimabarang_nosuratjalan.AutoSize = True
        Me.lbl_Terimabarang_nosuratjalan.Location = New System.Drawing.Point(16, 133)
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
        Me.lbl_Channel_id.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Channel_id.TabIndex = 0
        Me.lbl_Channel_id.Text = "Channel"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 400)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 17)
        Me.PnlDataFooter.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyItemToolStripMenuItem, Me.CopyWihChildToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(162, 48)
        '
        'CopyItemToolStripMenuItem
        '
        Me.CopyItemToolStripMenuItem.Name = "CopyItemToolStripMenuItem"
        Me.CopyItemToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CopyItemToolStripMenuItem.Text = "Copy Item"
        '
        'CopyWihChildToolStripMenuItem
        '
        Me.CopyWihChildToolStripMenuItem.Name = "CopyWihChildToolStripMenuItem"
        Me.CopyWihChildToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CopyWihChildToolStripMenuItem.Text = "Copy With Child"
        '
        'BackgroundWorker1
        '
        '
        'pnlDetil
        '
        Me.pnlDetil.BackColor = System.Drawing.Color.OldLace
        Me.pnlDetil.Controls.Add(Me.Panel_bawah)
        Me.pnlDetil.Controls.Add(Me.Panel_atas)
        Me.pnlDetil.Location = New System.Drawing.Point(277, 32)
        Me.pnlDetil.Name = "pnlDetil"
        Me.pnlDetil.Size = New System.Drawing.Size(690, 517)
        Me.pnlDetil.TabIndex = 2
        Me.pnlDetil.Visible = False
        '
        'Panel_bawah
        '
        Me.Panel_bawah.BackColor = System.Drawing.Color.Linen
        Me.Panel_bawah.Controls.Add(Me.Panel_tutup)
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
        Me.Panel_bawah.Location = New System.Drawing.Point(0, 397)
        Me.Panel_bawah.Name = "Panel_bawah"
        Me.Panel_bawah.Size = New System.Drawing.Size(690, 120)
        Me.Panel_bawah.TabIndex = 369
        '
        'Panel_tutup
        '
        Me.Panel_tutup.BackColor = System.Drawing.Color.OldLace
        Me.Panel_tutup.Location = New System.Drawing.Point(550, 106)
        Me.Panel_tutup.Name = "Panel_tutup"
        Me.Panel_tutup.Size = New System.Drawing.Size(192, 23)
        Me.Panel_tutup.TabIndex = 379
        '
        'lbl_Currency_iddetil
        '
        Me.lbl_Currency_iddetil.AutoSize = True
        Me.lbl_Currency_iddetil.Location = New System.Drawing.Point(5, 37)
        Me.lbl_Currency_iddetil.Name = "lbl_Currency_iddetil"
        Me.lbl_Currency_iddetil.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Currency_iddetil.TabIndex = 378
        Me.lbl_Currency_iddetil.Text = "Currency"
        '
        'obj_Currency_iddetil
        '
        Me.obj_Currency_iddetil.BackColor = System.Drawing.Color.White
        Me.obj_Currency_iddetil.Location = New System.Drawing.Point(78, 33)
        Me.obj_Currency_iddetil.Name = "obj_Currency_iddetil"
        Me.obj_Currency_iddetil.Size = New System.Drawing.Size(73, 21)
        Me.obj_Currency_iddetil.TabIndex = 377
        '
        'obj_Terimabarangdetil_totalidrreal
        '
        Me.obj_Terimabarangdetil_totalidrreal.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_totalidrreal.Location = New System.Drawing.Point(604, 58)
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
        Me.lbl_Terimabarangdetil_totalidrreal.Location = New System.Drawing.Point(504, 63)
        Me.lbl_Terimabarangdetil_totalidrreal.Name = "lbl_Terimabarangdetil_totalidrreal"
        Me.lbl_Terimabarangdetil_totalidrreal.Size = New System.Drawing.Size(98, 13)
        Me.lbl_Terimabarangdetil_totalidrreal.TabIndex = 376
        Me.lbl_Terimabarangdetil_totalidrreal.Text = "Total Amount (IDR)"
        '
        'obj_Terimabarangdetil_totalforeign
        '
        Me.obj_Terimabarangdetil_totalforeign.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_totalforeign.Location = New System.Drawing.Point(356, 59)
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
        Me.lbl_Terimabarangdetil_totalforeign.Location = New System.Drawing.Point(268, 61)
        Me.lbl_Terimabarangdetil_totalforeign.Name = "lbl_Terimabarangdetil_totalforeign"
        Me.lbl_Terimabarangdetil_totalforeign.Size = New System.Drawing.Size(70, 13)
        Me.lbl_Terimabarangdetil_totalforeign.TabIndex = 374
        Me.lbl_Terimabarangdetil_totalforeign.Text = "Total Amount"
        '
        'obj_Terimabarangdetil_ppnidrreal
        '
        Me.obj_Terimabarangdetil_ppnidrreal.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_ppnidrreal.Location = New System.Drawing.Point(604, 34)
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
        Me.lbl_Terimabarangdetil_ppnidrreal.Location = New System.Drawing.Point(504, 37)
        Me.lbl_Terimabarangdetil_ppnidrreal.Name = "lbl_Terimabarangdetil_ppnidrreal"
        Me.lbl_Terimabarangdetil_ppnidrreal.Size = New System.Drawing.Size(96, 13)
        Me.lbl_Terimabarangdetil_ppnidrreal.TabIndex = 372
        Me.lbl_Terimabarangdetil_ppnidrreal.Text = "PPN Amount (IDR)"
        '
        'obj_Terimabarangdetil_ppnforeign
        '
        Me.obj_Terimabarangdetil_ppnforeign.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_ppnforeign.Location = New System.Drawing.Point(356, 34)
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
        Me.lbl_Terimabarangdetil_ppnforeign.Location = New System.Drawing.Point(268, 36)
        Me.lbl_Terimabarangdetil_ppnforeign.Name = "lbl_Terimabarangdetil_ppnforeign"
        Me.lbl_Terimabarangdetil_ppnforeign.Size = New System.Drawing.Size(68, 13)
        Me.lbl_Terimabarangdetil_ppnforeign.TabIndex = 370
        Me.lbl_Terimabarangdetil_ppnforeign.Text = "PPN Amount"
        '
        'obj_Terimabarangdetil_pphidrreal
        '
        Me.obj_Terimabarangdetil_pphidrreal.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_pphidrreal.Location = New System.Drawing.Point(604, 9)
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
        Me.lbl_Terimabarangdetil_pphidrreal.Location = New System.Drawing.Point(504, 12)
        Me.lbl_Terimabarangdetil_pphidrreal.Name = "lbl_Terimabarangdetil_pphidrreal"
        Me.lbl_Terimabarangdetil_pphidrreal.Size = New System.Drawing.Size(94, 13)
        Me.lbl_Terimabarangdetil_pphidrreal.TabIndex = 368
        Me.lbl_Terimabarangdetil_pphidrreal.Text = "PPh Amount (IDR)"
        '
        'obj_Terimabarangdetil_pphforeign
        '
        Me.obj_Terimabarangdetil_pphforeign.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_pphforeign.Location = New System.Drawing.Point(356, 9)
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
        Me.lbl_Terimabarangdetil_pphforeign.Location = New System.Drawing.Point(268, 12)
        Me.lbl_Terimabarangdetil_pphforeign.Name = "lbl_Terimabarangdetil_pphforeign"
        Me.lbl_Terimabarangdetil_pphforeign.Size = New System.Drawing.Size(66, 13)
        Me.lbl_Terimabarangdetil_pphforeign.TabIndex = 366
        Me.lbl_Terimabarangdetil_pphforeign.Text = "PPh Amount"
        '
        'obj_Terimabarangdetil_disc
        '
        Me.obj_Terimabarangdetil_disc.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_disc.Location = New System.Drawing.Point(78, 108)
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
        Me.lbl_Terimabarangdetil_disc.Location = New System.Drawing.Point(4, 107)
        Me.lbl_Terimabarangdetil_disc.Name = "lbl_Terimabarangdetil_disc"
        Me.lbl_Terimabarangdetil_disc.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Terimabarangdetil_disc.TabIndex = 364
        Me.lbl_Terimabarangdetil_disc.Text = "Discount"
        '
        'obj_Terimabarangdetil_ppnpercent
        '
        Me.obj_Terimabarangdetil_ppnpercent.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_ppnpercent.Location = New System.Drawing.Point(193, 83)
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
        Me.lbl_Terimabarangdetil_ppnpercent.Location = New System.Drawing.Point(157, 86)
        Me.lbl_Terimabarangdetil_ppnpercent.Name = "lbl_Terimabarangdetil_ppnpercent"
        Me.lbl_Terimabarangdetil_ppnpercent.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Terimabarangdetil_ppnpercent.TabIndex = 362
        Me.lbl_Terimabarangdetil_ppnpercent.Text = "PPN%"
        '
        'obj_Terimabarangdetil_pphpercent
        '
        Me.obj_Terimabarangdetil_pphpercent.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_pphpercent.Location = New System.Drawing.Point(78, 83)
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
        Me.lbl_Terimabarangdetil_pphpercent.Location = New System.Drawing.Point(5, 86)
        Me.lbl_Terimabarangdetil_pphpercent.Name = "lbl_Terimabarangdetil_pphpercent"
        Me.lbl_Terimabarangdetil_pphpercent.Size = New System.Drawing.Size(35, 13)
        Me.lbl_Terimabarangdetil_pphpercent.TabIndex = 360
        Me.lbl_Terimabarangdetil_pphpercent.Text = "PPh%"
        '
        'obj_Terimabarangdetil_idrreal
        '
        Me.obj_Terimabarangdetil_idrreal.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_idrreal.Location = New System.Drawing.Point(78, 59)
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
        Me.lbl_Terimabarangdetil_idrreal.Location = New System.Drawing.Point(5, 63)
        Me.lbl_Terimabarangdetil_idrreal.Name = "lbl_Terimabarangdetil_idrreal"
        Me.lbl_Terimabarangdetil_idrreal.Size = New System.Drawing.Size(71, 13)
        Me.lbl_Terimabarangdetil_idrreal.TabIndex = 358
        Me.lbl_Terimabarangdetil_idrreal.Text = "Amount (IDR)"
        '
        'obj_Terimabarangdetil_foreignrate
        '
        Me.obj_Terimabarangdetil_foreignrate.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_foreignrate.Location = New System.Drawing.Point(193, 34)
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
        Me.lbl_Terimabarangdetil_foreignrate.Location = New System.Drawing.Point(157, 37)
        Me.lbl_Terimabarangdetil_foreignrate.Name = "lbl_Terimabarangdetil_foreignrate"
        Me.lbl_Terimabarangdetil_foreignrate.Size = New System.Drawing.Size(30, 13)
        Me.lbl_Terimabarangdetil_foreignrate.TabIndex = 356
        Me.lbl_Terimabarangdetil_foreignrate.Text = "Rate"
        '
        'obj_Terimabarangdetil_foreign
        '
        Me.obj_Terimabarangdetil_foreign.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_foreign.Location = New System.Drawing.Point(78, 8)
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
        Me.lbl_Terimabarangdetil_foreign.Location = New System.Drawing.Point(5, 12)
        Me.lbl_Terimabarangdetil_foreign.Name = "lbl_Terimabarangdetil_foreign"
        Me.lbl_Terimabarangdetil_foreign.Size = New System.Drawing.Size(43, 13)
        Me.lbl_Terimabarangdetil_foreign.TabIndex = 354
        Me.lbl_Terimabarangdetil_foreign.Text = "Amount"
        '
        'Panel_atas
        '
        Me.Panel_atas.BackColor = System.Drawing.Color.OldLace
        Me.Panel_atas.Controls.Add(Me.Panel7)
        Me.Panel_atas.Controls.Add(Me.Panel6)
        Me.Panel_atas.Controls.Add(Me.Panel3)
        Me.Panel_atas.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_atas.Location = New System.Drawing.Point(0, 0)
        Me.Panel_atas.Name = "Panel_atas"
        Me.Panel_atas.Size = New System.Drawing.Size(690, 397)
        Me.Panel_atas.TabIndex = 368
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.OldLace
        Me.Panel7.Controls.Add(Me.obj_Terimabarangdetil_depre_enddt)
        Me.Panel7.Controls.Add(Me.Button14)
        Me.Panel7.Controls.Add(Me.Button13)
        Me.Panel7.Controls.Add(Me.Button12)
        Me.Panel7.Controls.Add(Me.Button11)
        Me.Panel7.Controls.Add(Me.Button10)
        Me.Panel7.Controls.Add(Me.Button9)
        Me.Panel7.Controls.Add(Me.lbl_Acc_id)
        Me.Panel7.Controls.Add(Me.obj_Acc_id)
        Me.Panel7.Controls.Add(Me.lbl_Budgetdetil_id)
        Me.Panel7.Controls.Add(Me.obj_Budgetdetil_id)
        Me.Panel7.Controls.Add(Me.lbl_Budget_iddetil)
        Me.Panel7.Controls.Add(Me.obj_Budget_iddetil)
        Me.Panel7.Controls.Add(Me.obj_Orderdetil_line)
        Me.Panel7.Controls.Add(Me.lbl_Orderdetil_line)
        Me.Panel7.Controls.Add(Me.obj_Orderdetil_id)
        Me.Panel7.Controls.Add(Me.lbl_Orderdetil_id)
        Me.Panel7.Controls.Add(Me.obj_Writeoff_dt)
        Me.Panel7.Controls.Add(Me.lbl_Writeoff_dt)
        Me.Panel7.Controls.Add(Me.obj_Writeoff_id)
        Me.Panel7.Controls.Add(Me.lbl_Writeoff_id)
        Me.Panel7.Controls.Add(Me.obj_Terimabarangdetil_eps)
        Me.Panel7.Controls.Add(Me.lbl_Terimabarangdetil_eps)
        Me.Panel7.Controls.Add(Me.lbl_Show_id_cont)
        Me.Panel7.Controls.Add(Me.obj_Show_id_cont)
        Me.Panel7.Controls.Add(Me.lbl_Show_id)
        Me.Panel7.Controls.Add(Me.obj_Show_id)
        Me.Panel7.Controls.Add(Me.lbl_Strukturunitdetil_id)
        Me.Panel7.Controls.Add(Me.obj_Strukturunitdetil_id)
        Me.Panel7.Controls.Add(Me.lbl_Employee_id)
        Me.Panel7.Controls.Add(Me.obj_Employee_id)
        Me.Panel7.Controls.Add(Me.lbl_Terimabarangdetil_depre_enddt)
        Me.Panel7.Controls.Add(Me.obj_Terimabarangdetil_golfiskal)
        Me.Panel7.Controls.Add(Me.lbl_Terimabarangdetil_golfiskal)
        Me.Panel7.Controls.Add(Me.lbl_Kategoriasset_id)
        Me.Panel7.Controls.Add(Me.lbl_Tipeasset_id)
        Me.Panel7.Controls.Add(Me.obj_Assettype_id)
        Me.Panel7.Controls.Add(Me.obj_Assetcategory_id)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 248)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(690, 150)
        Me.Panel7.TabIndex = 449
        '
        'obj_Terimabarangdetil_depre_enddt
        '
        Me.obj_Terimabarangdetil_depre_enddt.CustomFormat = "dd/MM/yyyy"
        Me.obj_Terimabarangdetil_depre_enddt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Terimabarangdetil_depre_enddt.Location = New System.Drawing.Point(356, 9)
        Me.obj_Terimabarangdetil_depre_enddt.Name = "obj_Terimabarangdetil_depre_enddt"
        Me.obj_Terimabarangdetil_depre_enddt.Size = New System.Drawing.Size(99, 20)
        Me.obj_Terimabarangdetil_depre_enddt.TabIndex = 454
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.ForeColor = System.Drawing.Color.Red
        Me.Button14.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button14.Location = New System.Drawing.Point(243, 30)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(19, 19)
        Me.Button14.TabIndex = 485
        Me.Button14.TabStop = False
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.ForeColor = System.Drawing.Color.Red
        Me.Button13.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button13.Location = New System.Drawing.Point(243, 9)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(19, 19)
        Me.Button13.TabIndex = 484
        Me.Button13.TabStop = False
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.Color.Red
        Me.Button12.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button12.Location = New System.Drawing.Point(521, 97)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(19, 19)
        Me.Button12.TabIndex = 483
        Me.Button12.TabStop = False
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.Red
        Me.Button11.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button11.Location = New System.Drawing.Point(521, 75)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(19, 19)
        Me.Button11.TabIndex = 482
        Me.Button11.TabStop = False
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.Red
        Me.Button10.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button10.Location = New System.Drawing.Point(521, 53)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(19, 19)
        Me.Button10.TabIndex = 481
        Me.Button10.TabStop = False
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.Red
        Me.Button9.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button9.Location = New System.Drawing.Point(521, 30)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(19, 19)
        Me.Button9.TabIndex = 480
        Me.Button9.TabStop = False
        Me.Button9.UseVisualStyleBackColor = False
        '
        'lbl_Acc_id
        '
        Me.lbl_Acc_id.AutoSize = True
        Me.lbl_Acc_id.Location = New System.Drawing.Point(547, 56)
        Me.lbl_Acc_id.Name = "lbl_Acc_id"
        Me.lbl_Acc_id.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Acc_id.TabIndex = 479
        Me.lbl_Acc_id.Text = "Account"
        '
        'obj_Acc_id
        '
        Me.obj_Acc_id.BackColor = System.Drawing.Color.White
        Me.obj_Acc_id.Location = New System.Drawing.Point(605, 53)
        Me.obj_Acc_id.Name = "obj_Acc_id"
        Me.obj_Acc_id.Size = New System.Drawing.Size(138, 21)
        Me.obj_Acc_id.TabIndex = 478
        '
        'lbl_Budgetdetil_id
        '
        Me.lbl_Budgetdetil_id.AutoSize = True
        Me.lbl_Budgetdetil_id.Location = New System.Drawing.Point(268, 100)
        Me.lbl_Budgetdetil_id.Name = "lbl_Budgetdetil_id"
        Me.lbl_Budgetdetil_id.Size = New System.Drawing.Size(65, 13)
        Me.lbl_Budgetdetil_id.TabIndex = 477
        Me.lbl_Budgetdetil_id.Text = "Budget Detil"
        '
        'obj_Budgetdetil_id
        '
        Me.obj_Budgetdetil_id.BackColor = System.Drawing.Color.White
        Me.obj_Budgetdetil_id.Location = New System.Drawing.Point(356, 96)
        Me.obj_Budgetdetil_id.Name = "obj_Budgetdetil_id"
        Me.obj_Budgetdetil_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Budgetdetil_id.TabIndex = 476
        '
        'lbl_Budget_iddetil
        '
        Me.lbl_Budget_iddetil.AutoSize = True
        Me.lbl_Budget_iddetil.Location = New System.Drawing.Point(268, 78)
        Me.lbl_Budget_iddetil.Name = "lbl_Budget_iddetil"
        Me.lbl_Budget_iddetil.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Budget_iddetil.TabIndex = 475
        Me.lbl_Budget_iddetil.Text = "Budget"
        '
        'obj_Budget_iddetil
        '
        Me.obj_Budget_iddetil.BackColor = System.Drawing.Color.White
        Me.obj_Budget_iddetil.Location = New System.Drawing.Point(356, 74)
        Me.obj_Budget_iddetil.Name = "obj_Budget_iddetil"
        Me.obj_Budget_iddetil.Size = New System.Drawing.Size(163, 21)
        Me.obj_Budget_iddetil.TabIndex = 474
        '
        'obj_Orderdetil_line
        '
        Me.obj_Orderdetil_line.BackColor = System.Drawing.Color.White
        Me.obj_Orderdetil_line.Location = New System.Drawing.Point(605, 98)
        Me.obj_Orderdetil_line.MaxLength = 20
        Me.obj_Orderdetil_line.Name = "obj_Orderdetil_line"
        Me.obj_Orderdetil_line.ReadOnly = True
        Me.obj_Orderdetil_line.Size = New System.Drawing.Size(138, 20)
        Me.obj_Orderdetil_line.TabIndex = 472
        '
        'lbl_Orderdetil_line
        '
        Me.lbl_Orderdetil_line.AutoSize = True
        Me.lbl_Orderdetil_line.Location = New System.Drawing.Point(547, 101)
        Me.lbl_Orderdetil_line.Name = "lbl_Orderdetil_line"
        Me.lbl_Orderdetil_line.Size = New System.Drawing.Size(56, 13)
        Me.lbl_Orderdetil_line.TabIndex = 473
        Me.lbl_Orderdetil_line.Text = "Order Line"
        '
        'obj_Orderdetil_id
        '
        Me.obj_Orderdetil_id.BackColor = System.Drawing.Color.White
        Me.obj_Orderdetil_id.Location = New System.Drawing.Point(605, 76)
        Me.obj_Orderdetil_id.MaxLength = 20
        Me.obj_Orderdetil_id.Name = "obj_Orderdetil_id"
        Me.obj_Orderdetil_id.ReadOnly = True
        Me.obj_Orderdetil_id.Size = New System.Drawing.Size(138, 20)
        Me.obj_Orderdetil_id.TabIndex = 470
        '
        'lbl_Orderdetil_id
        '
        Me.lbl_Orderdetil_id.AutoSize = True
        Me.lbl_Orderdetil_id.Location = New System.Drawing.Point(547, 79)
        Me.lbl_Orderdetil_id.Name = "lbl_Orderdetil_id"
        Me.lbl_Orderdetil_id.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Orderdetil_id.TabIndex = 471
        Me.lbl_Orderdetil_id.Text = "Order ID"
        '
        'obj_Writeoff_dt
        '
        Me.obj_Writeoff_dt.CustomFormat = "dd/MM/yyyy"
        Me.obj_Writeoff_dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Writeoff_dt.Location = New System.Drawing.Point(605, 31)
        Me.obj_Writeoff_dt.Name = "obj_Writeoff_dt"
        Me.obj_Writeoff_dt.Size = New System.Drawing.Size(99, 20)
        Me.obj_Writeoff_dt.TabIndex = 468
        '
        'lbl_Writeoff_dt
        '
        Me.lbl_Writeoff_dt.AutoSize = True
        Me.lbl_Writeoff_dt.Location = New System.Drawing.Point(547, 35)
        Me.lbl_Writeoff_dt.Name = "lbl_Writeoff_dt"
        Me.lbl_Writeoff_dt.Size = New System.Drawing.Size(52, 13)
        Me.lbl_Writeoff_dt.TabIndex = 469
        Me.lbl_Writeoff_dt.Text = "WO Date"
        '
        'obj_Writeoff_id
        '
        Me.obj_Writeoff_id.BackColor = System.Drawing.Color.White
        Me.obj_Writeoff_id.Location = New System.Drawing.Point(605, 10)
        Me.obj_Writeoff_id.MaxLength = 20
        Me.obj_Writeoff_id.Name = "obj_Writeoff_id"
        Me.obj_Writeoff_id.Size = New System.Drawing.Size(138, 20)
        Me.obj_Writeoff_id.TabIndex = 466
        '
        'lbl_Writeoff_id
        '
        Me.lbl_Writeoff_id.AutoSize = True
        Me.lbl_Writeoff_id.Location = New System.Drawing.Point(547, 13)
        Me.lbl_Writeoff_id.Name = "lbl_Writeoff_id"
        Me.lbl_Writeoff_id.Size = New System.Drawing.Size(31, 13)
        Me.lbl_Writeoff_id.TabIndex = 467
        Me.lbl_Writeoff_id.Text = "W/O"
        '
        'obj_Terimabarangdetil_eps
        '
        Me.obj_Terimabarangdetil_eps.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_eps.Location = New System.Drawing.Point(78, 52)
        Me.obj_Terimabarangdetil_eps.MaxLength = 20
        Me.obj_Terimabarangdetil_eps.Name = "obj_Terimabarangdetil_eps"
        Me.obj_Terimabarangdetil_eps.Size = New System.Drawing.Size(91, 20)
        Me.obj_Terimabarangdetil_eps.TabIndex = 464
        '
        'lbl_Terimabarangdetil_eps
        '
        Me.lbl_Terimabarangdetil_eps.AutoSize = True
        Me.lbl_Terimabarangdetil_eps.Location = New System.Drawing.Point(5, 56)
        Me.lbl_Terimabarangdetil_eps.Name = "lbl_Terimabarangdetil_eps"
        Me.lbl_Terimabarangdetil_eps.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Terimabarangdetil_eps.TabIndex = 465
        Me.lbl_Terimabarangdetil_eps.Text = "Eps"
        '
        'lbl_Show_id_cont
        '
        Me.lbl_Show_id_cont.AutoSize = True
        Me.lbl_Show_id_cont.Location = New System.Drawing.Point(5, 35)
        Me.lbl_Show_id_cont.Name = "lbl_Show_id_cont"
        Me.lbl_Show_id_cont.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Show_id_cont.TabIndex = 463
        Me.lbl_Show_id_cont.Text = "Show(Cont)"
        '
        'obj_Show_id_cont
        '
        Me.obj_Show_id_cont.BackColor = System.Drawing.Color.White
        Me.obj_Show_id_cont.Location = New System.Drawing.Point(78, 30)
        Me.obj_Show_id_cont.Name = "obj_Show_id_cont"
        Me.obj_Show_id_cont.Size = New System.Drawing.Size(163, 21)
        Me.obj_Show_id_cont.TabIndex = 462
        '
        'lbl_Show_id
        '
        Me.lbl_Show_id.AutoSize = True
        Me.lbl_Show_id.Location = New System.Drawing.Point(5, 11)
        Me.lbl_Show_id.Name = "lbl_Show_id"
        Me.lbl_Show_id.Size = New System.Drawing.Size(34, 13)
        Me.lbl_Show_id.TabIndex = 461
        Me.lbl_Show_id.Text = "Show"
        '
        'obj_Show_id
        '
        Me.obj_Show_id.BackColor = System.Drawing.Color.White
        Me.obj_Show_id.Location = New System.Drawing.Point(78, 8)
        Me.obj_Show_id.Name = "obj_Show_id"
        Me.obj_Show_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Show_id.TabIndex = 460
        '
        'lbl_Strukturunitdetil_id
        '
        Me.lbl_Strukturunitdetil_id.AutoSize = True
        Me.lbl_Strukturunitdetil_id.Location = New System.Drawing.Point(268, 56)
        Me.lbl_Strukturunitdetil_id.Name = "lbl_Strukturunitdetil_id"
        Me.lbl_Strukturunitdetil_id.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Strukturunitdetil_id.TabIndex = 459
        Me.lbl_Strukturunitdetil_id.Text = "Department"
        '
        'obj_Strukturunitdetil_id
        '
        Me.obj_Strukturunitdetil_id.BackColor = System.Drawing.Color.White
        Me.obj_Strukturunitdetil_id.Location = New System.Drawing.Point(356, 52)
        Me.obj_Strukturunitdetil_id.Name = "obj_Strukturunitdetil_id"
        Me.obj_Strukturunitdetil_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Strukturunitdetil_id.TabIndex = 458
        '
        'lbl_Employee_id
        '
        Me.lbl_Employee_id.AutoSize = True
        Me.lbl_Employee_id.Location = New System.Drawing.Point(268, 33)
        Me.lbl_Employee_id.Name = "lbl_Employee_id"
        Me.lbl_Employee_id.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Employee_id.TabIndex = 457
        Me.lbl_Employee_id.Text = "Employee"
        '
        'obj_Employee_id
        '
        Me.obj_Employee_id.BackColor = System.Drawing.Color.White
        Me.obj_Employee_id.Location = New System.Drawing.Point(356, 30)
        Me.obj_Employee_id.Name = "obj_Employee_id"
        Me.obj_Employee_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Employee_id.TabIndex = 456
        '
        'lbl_Terimabarangdetil_depre_enddt
        '
        Me.lbl_Terimabarangdetil_depre_enddt.AutoSize = True
        Me.lbl_Terimabarangdetil_depre_enddt.Location = New System.Drawing.Point(268, 13)
        Me.lbl_Terimabarangdetil_depre_enddt.Name = "lbl_Terimabarangdetil_depre_enddt"
        Me.lbl_Terimabarangdetil_depre_enddt.Size = New System.Drawing.Size(87, 13)
        Me.lbl_Terimabarangdetil_depre_enddt.TabIndex = 455
        Me.lbl_Terimabarangdetil_depre_enddt.Text = "End Depre. Date"
        '
        'obj_Terimabarangdetil_golfiskal
        '
        Me.obj_Terimabarangdetil_golfiskal.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_golfiskal.Location = New System.Drawing.Point(78, 97)
        Me.obj_Terimabarangdetil_golfiskal.MaxLength = 20
        Me.obj_Terimabarangdetil_golfiskal.Name = "obj_Terimabarangdetil_golfiskal"
        Me.obj_Terimabarangdetil_golfiskal.Size = New System.Drawing.Size(184, 20)
        Me.obj_Terimabarangdetil_golfiskal.TabIndex = 452
        '
        'lbl_Terimabarangdetil_golfiskal
        '
        Me.lbl_Terimabarangdetil_golfiskal.AutoSize = True
        Me.lbl_Terimabarangdetil_golfiskal.Location = New System.Drawing.Point(5, 101)
        Me.lbl_Terimabarangdetil_golfiskal.Name = "lbl_Terimabarangdetil_golfiskal"
        Me.lbl_Terimabarangdetil_golfiskal.Size = New System.Drawing.Size(63, 13)
        Me.lbl_Terimabarangdetil_golfiskal.TabIndex = 453
        Me.lbl_Terimabarangdetil_golfiskal.Text = "Fiscal Asset"
        '
        'lbl_Kategoriasset_id
        '
        Me.lbl_Kategoriasset_id.AutoSize = True
        Me.lbl_Kategoriasset_id.Location = New System.Drawing.Point(268, 127)
        Me.lbl_Kategoriasset_id.Name = "lbl_Kategoriasset_id"
        Me.lbl_Kategoriasset_id.Size = New System.Drawing.Size(78, 13)
        Me.lbl_Kategoriasset_id.TabIndex = 450
        Me.lbl_Kategoriasset_id.Text = "Asset Category"
        '
        'lbl_Tipeasset_id
        '
        Me.lbl_Tipeasset_id.AutoSize = True
        Me.lbl_Tipeasset_id.Location = New System.Drawing.Point(4, 127)
        Me.lbl_Tipeasset_id.Name = "lbl_Tipeasset_id"
        Me.lbl_Tipeasset_id.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Tipeasset_id.TabIndex = 449
        Me.lbl_Tipeasset_id.Text = "Asset Type"
        '
        'obj_Assettype_id
        '
        Me.obj_Assettype_id.BackColor = System.Drawing.Color.White
        Me.obj_Assettype_id.Location = New System.Drawing.Point(78, 124)
        Me.obj_Assettype_id.Name = "obj_Assettype_id"
        Me.obj_Assettype_id.Size = New System.Drawing.Size(184, 21)
        Me.obj_Assettype_id.TabIndex = 447
        '
        'obj_Assetcategory_id
        '
        Me.obj_Assetcategory_id.BackColor = System.Drawing.Color.White
        Me.obj_Assetcategory_id.Location = New System.Drawing.Point(356, 124)
        Me.obj_Assetcategory_id.Name = "obj_Assetcategory_id"
        Me.obj_Assetcategory_id.Size = New System.Drawing.Size(184, 21)
        Me.obj_Assetcategory_id.TabIndex = 448
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel6.Controls.Add(Me.Button8)
        Me.Panel6.Controls.Add(Me.Button7)
        Me.Panel6.Controls.Add(Me.Button6)
        Me.Panel6.Controls.Add(Me.Button5)
        Me.Panel6.Controls.Add(Me.Button4)
        Me.Panel6.Controls.Add(Me.Button3)
        Me.Panel6.Controls.Add(Me.Button2)
        Me.Panel6.Controls.Add(Me.Button1)
        Me.Panel6.Controls.Add(Me.Btn_Category)
        Me.Panel6.Controls.Add(Me.lbl_Unit_id)
        Me.Panel6.Controls.Add(Me.obj_Unit_id)
        Me.Panel6.Controls.Add(Me.lbl_Terimabarangdetil_qty)
        Me.Panel6.Controls.Add(Me.obj_Terimabarangdetil_qty)
        Me.Panel6.Controls.Add(Me.lbl_Terimabarangdetil_rack)
        Me.Panel6.Controls.Add(Me.obj_Terimabarangdetil_rack)
        Me.Panel6.Controls.Add(Me.lbl_Room_id)
        Me.Panel6.Controls.Add(Me.obj_Room_id)
        Me.Panel6.Controls.Add(Me.lbl_Sex_id)
        Me.Panel6.Controls.Add(Me.obj_Sex_id)
        Me.Panel6.Controls.Add(Me.lbl_Size_id)
        Me.Panel6.Controls.Add(Me.obj_Size_id)
        Me.Panel6.Controls.Add(Me.lbl_Colour_id)
        Me.Panel6.Controls.Add(Me.obj_Colour_id)
        Me.Panel6.Controls.Add(Me.lbl_Material_id)
        Me.Panel6.Controls.Add(Me.obj_Material_id)
        Me.Panel6.Controls.Add(Me.obj_Terimabarangdetil_model)
        Me.Panel6.Controls.Add(Me.lbl_Terimabarangdetil_model)
        Me.Panel6.Controls.Add(Me.obj_Terimabarangdetil_serial_no)
        Me.Panel6.Controls.Add(Me.lbl_Terimabarangdetil_serial_no)
        Me.Panel6.Controls.Add(Me.lbl_brand_id)
        Me.Panel6.Controls.Add(Me.obj_Brand_id)
        Me.Panel6.Controls.Add(Me.lbl_Itemtype_id)
        Me.Panel6.Controls.Add(Me.obj_Itemtype_id)
        Me.Panel6.Controls.Add(Me.lbl_Itemcategory_id)
        Me.Panel6.Controls.Add(Me.obj_Itemcategory_id)
        Me.Panel6.Controls.Add(Me.lbl_Item_id)
        Me.Panel6.Controls.Add(Me.obj_Item_id)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 117)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(690, 131)
        Me.Panel6.TabIndex = 448
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.Red
        Me.Button8.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button8.Location = New System.Drawing.Point(521, 101)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(19, 19)
        Me.Button8.TabIndex = 446
        Me.Button8.TabStop = False
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.Red
        Me.Button7.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button7.Location = New System.Drawing.Point(521, 79)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(19, 19)
        Me.Button7.TabIndex = 445
        Me.Button7.TabStop = False
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.Red
        Me.Button6.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button6.Location = New System.Drawing.Point(521, 58)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(19, 19)
        Me.Button6.TabIndex = 444
        Me.Button6.TabStop = False
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Red
        Me.Button5.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button5.Location = New System.Drawing.Point(521, 35)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(19, 19)
        Me.Button5.TabIndex = 443
        Me.Button5.TabStop = False
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Red
        Me.Button4.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button4.Location = New System.Drawing.Point(521, 13)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(19, 19)
        Me.Button4.TabIndex = 442
        Me.Button4.TabStop = False
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Red
        Me.Button3.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button3.Location = New System.Drawing.Point(243, 78)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(19, 19)
        Me.Button3.TabIndex = 441
        Me.Button3.TabStop = False
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button2.Location = New System.Drawing.Point(243, 56)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(19, 19)
        Me.Button2.TabIndex = 440
        Me.Button2.TabStop = False
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Button1.Location = New System.Drawing.Point(243, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(19, 19)
        Me.Button1.TabIndex = 439
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Btn_Category
        '
        Me.Btn_Category.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Btn_Category.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Category.ForeColor = System.Drawing.Color.Red
        Me.Btn_Category.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Btn_Category.Location = New System.Drawing.Point(243, 12)
        Me.Btn_Category.Name = "Btn_Category"
        Me.Btn_Category.Size = New System.Drawing.Size(19, 19)
        Me.Btn_Category.TabIndex = 438
        Me.Btn_Category.TabStop = False
        Me.Btn_Category.UseVisualStyleBackColor = False
        '
        'lbl_Unit_id
        '
        Me.lbl_Unit_id.AutoSize = True
        Me.lbl_Unit_id.Location = New System.Drawing.Point(659, 15)
        Me.lbl_Unit_id.Name = "lbl_Unit_id"
        Me.lbl_Unit_id.Size = New System.Drawing.Size(26, 13)
        Me.lbl_Unit_id.TabIndex = 437
        Me.lbl_Unit_id.Text = "Unit"
        '
        'obj_Unit_id
        '
        Me.obj_Unit_id.BackColor = System.Drawing.Color.White
        Me.obj_Unit_id.Location = New System.Drawing.Point(691, 12)
        Me.obj_Unit_id.Name = "obj_Unit_id"
        Me.obj_Unit_id.Size = New System.Drawing.Size(61, 21)
        Me.obj_Unit_id.TabIndex = 436
        '
        'lbl_Terimabarangdetil_qty
        '
        Me.lbl_Terimabarangdetil_qty.AutoSize = True
        Me.lbl_Terimabarangdetil_qty.Location = New System.Drawing.Point(547, 15)
        Me.lbl_Terimabarangdetil_qty.Name = "lbl_Terimabarangdetil_qty"
        Me.lbl_Terimabarangdetil_qty.Size = New System.Drawing.Size(23, 13)
        Me.lbl_Terimabarangdetil_qty.TabIndex = 435
        Me.lbl_Terimabarangdetil_qty.Text = "Qty"
        '
        'obj_Terimabarangdetil_qty
        '
        Me.obj_Terimabarangdetil_qty.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_qty.Location = New System.Drawing.Point(604, 12)
        Me.obj_Terimabarangdetil_qty.MaxLength = 30
        Me.obj_Terimabarangdetil_qty.Name = "obj_Terimabarangdetil_qty"
        Me.obj_Terimabarangdetil_qty.Size = New System.Drawing.Size(49, 20)
        Me.obj_Terimabarangdetil_qty.TabIndex = 434
        '
        'lbl_Terimabarangdetil_rack
        '
        Me.lbl_Terimabarangdetil_rack.AutoSize = True
        Me.lbl_Terimabarangdetil_rack.Location = New System.Drawing.Point(547, 103)
        Me.lbl_Terimabarangdetil_rack.Name = "lbl_Terimabarangdetil_rack"
        Me.lbl_Terimabarangdetil_rack.Size = New System.Drawing.Size(33, 13)
        Me.lbl_Terimabarangdetil_rack.TabIndex = 433
        Me.lbl_Terimabarangdetil_rack.Text = "Rack"
        '
        'obj_Terimabarangdetil_rack
        '
        Me.obj_Terimabarangdetil_rack.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_rack.Location = New System.Drawing.Point(604, 100)
        Me.obj_Terimabarangdetil_rack.MaxLength = 30
        Me.obj_Terimabarangdetil_rack.Name = "obj_Terimabarangdetil_rack"
        Me.obj_Terimabarangdetil_rack.Size = New System.Drawing.Size(148, 20)
        Me.obj_Terimabarangdetil_rack.TabIndex = 432
        '
        'lbl_Room_id
        '
        Me.lbl_Room_id.AutoSize = True
        Me.lbl_Room_id.Location = New System.Drawing.Point(268, 103)
        Me.lbl_Room_id.Name = "lbl_Room_id"
        Me.lbl_Room_id.Size = New System.Drawing.Size(35, 13)
        Me.lbl_Room_id.TabIndex = 431
        Me.lbl_Room_id.Text = "Room"
        '
        'obj_Room_id
        '
        Me.obj_Room_id.BackColor = System.Drawing.Color.White
        Me.obj_Room_id.Location = New System.Drawing.Point(356, 100)
        Me.obj_Room_id.Name = "obj_Room_id"
        Me.obj_Room_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Room_id.TabIndex = 430
        '
        'lbl_Sex_id
        '
        Me.lbl_Sex_id.AutoSize = True
        Me.lbl_Sex_id.Location = New System.Drawing.Point(268, 81)
        Me.lbl_Sex_id.Name = "lbl_Sex_id"
        Me.lbl_Sex_id.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Sex_id.TabIndex = 429
        Me.lbl_Sex_id.Text = "Sex"
        '
        'obj_Sex_id
        '
        Me.obj_Sex_id.BackColor = System.Drawing.Color.White
        Me.obj_Sex_id.Location = New System.Drawing.Point(356, 78)
        Me.obj_Sex_id.Name = "obj_Sex_id"
        Me.obj_Sex_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Sex_id.TabIndex = 428
        '
        'lbl_Size_id
        '
        Me.lbl_Size_id.AutoSize = True
        Me.lbl_Size_id.Location = New System.Drawing.Point(268, 59)
        Me.lbl_Size_id.Name = "lbl_Size_id"
        Me.lbl_Size_id.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Size_id.TabIndex = 427
        Me.lbl_Size_id.Text = "Size"
        '
        'obj_Size_id
        '
        Me.obj_Size_id.BackColor = System.Drawing.Color.White
        Me.obj_Size_id.Location = New System.Drawing.Point(356, 56)
        Me.obj_Size_id.Name = "obj_Size_id"
        Me.obj_Size_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Size_id.TabIndex = 426
        '
        'lbl_Colour_id
        '
        Me.lbl_Colour_id.AutoSize = True
        Me.lbl_Colour_id.Location = New System.Drawing.Point(268, 37)
        Me.lbl_Colour_id.Name = "lbl_Colour_id"
        Me.lbl_Colour_id.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Colour_id.TabIndex = 425
        Me.lbl_Colour_id.Text = "Colour"
        '
        'obj_Colour_id
        '
        Me.obj_Colour_id.BackColor = System.Drawing.Color.White
        Me.obj_Colour_id.Location = New System.Drawing.Point(356, 34)
        Me.obj_Colour_id.Name = "obj_Colour_id"
        Me.obj_Colour_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Colour_id.TabIndex = 424
        '
        'lbl_Material_id
        '
        Me.lbl_Material_id.AutoSize = True
        Me.lbl_Material_id.Location = New System.Drawing.Point(268, 15)
        Me.lbl_Material_id.Name = "lbl_Material_id"
        Me.lbl_Material_id.Size = New System.Drawing.Size(44, 13)
        Me.lbl_Material_id.TabIndex = 423
        Me.lbl_Material_id.Text = "Material"
        '
        'obj_Material_id
        '
        Me.obj_Material_id.BackColor = System.Drawing.Color.White
        Me.obj_Material_id.Location = New System.Drawing.Point(356, 12)
        Me.obj_Material_id.Name = "obj_Material_id"
        Me.obj_Material_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Material_id.TabIndex = 422
        '
        'obj_Terimabarangdetil_model
        '
        Me.obj_Terimabarangdetil_model.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_model.Location = New System.Drawing.Point(604, 78)
        Me.obj_Terimabarangdetil_model.MaxLength = 20
        Me.obj_Terimabarangdetil_model.Name = "obj_Terimabarangdetil_model"
        Me.obj_Terimabarangdetil_model.Size = New System.Drawing.Size(148, 20)
        Me.obj_Terimabarangdetil_model.TabIndex = 420
        '
        'lbl_Terimabarangdetil_model
        '
        Me.lbl_Terimabarangdetil_model.AutoSize = True
        Me.lbl_Terimabarangdetil_model.Location = New System.Drawing.Point(547, 81)
        Me.lbl_Terimabarangdetil_model.Name = "lbl_Terimabarangdetil_model"
        Me.lbl_Terimabarangdetil_model.Size = New System.Drawing.Size(36, 13)
        Me.lbl_Terimabarangdetil_model.TabIndex = 421
        Me.lbl_Terimabarangdetil_model.Text = "Model"
        '
        'obj_Terimabarangdetil_serial_no
        '
        Me.obj_Terimabarangdetil_serial_no.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_serial_no.Location = New System.Drawing.Point(78, 100)
        Me.obj_Terimabarangdetil_serial_no.MaxLength = 20
        Me.obj_Terimabarangdetil_serial_no.Name = "obj_Terimabarangdetil_serial_no"
        Me.obj_Terimabarangdetil_serial_no.Size = New System.Drawing.Size(163, 20)
        Me.obj_Terimabarangdetil_serial_no.TabIndex = 416
        '
        'lbl_Terimabarangdetil_serial_no
        '
        Me.lbl_Terimabarangdetil_serial_no.AutoSize = True
        Me.lbl_Terimabarangdetil_serial_no.Location = New System.Drawing.Point(5, 103)
        Me.lbl_Terimabarangdetil_serial_no.Name = "lbl_Terimabarangdetil_serial_no"
        Me.lbl_Terimabarangdetil_serial_no.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Terimabarangdetil_serial_no.TabIndex = 417
        Me.lbl_Terimabarangdetil_serial_no.Text = "Serial No."
        '
        'lbl_brand_id
        '
        Me.lbl_brand_id.AutoSize = True
        Me.lbl_brand_id.Location = New System.Drawing.Point(5, 82)
        Me.lbl_brand_id.Name = "lbl_brand_id"
        Me.lbl_brand_id.Size = New System.Drawing.Size(35, 13)
        Me.lbl_brand_id.TabIndex = 415
        Me.lbl_brand_id.Text = "Brand"
        '
        'obj_Brand_id
        '
        Me.obj_Brand_id.BackColor = System.Drawing.Color.White
        Me.obj_Brand_id.Location = New System.Drawing.Point(78, 78)
        Me.obj_Brand_id.Name = "obj_Brand_id"
        Me.obj_Brand_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Brand_id.TabIndex = 414
        '
        'lbl_Itemtype_id
        '
        Me.lbl_Itemtype_id.AutoSize = True
        Me.lbl_Itemtype_id.Location = New System.Drawing.Point(5, 59)
        Me.lbl_Itemtype_id.Name = "lbl_Itemtype_id"
        Me.lbl_Itemtype_id.Size = New System.Drawing.Size(31, 13)
        Me.lbl_Itemtype_id.TabIndex = 413
        Me.lbl_Itemtype_id.Text = "Type"
        '
        'obj_Itemtype_id
        '
        Me.obj_Itemtype_id.BackColor = System.Drawing.Color.White
        Me.obj_Itemtype_id.Location = New System.Drawing.Point(78, 56)
        Me.obj_Itemtype_id.Name = "obj_Itemtype_id"
        Me.obj_Itemtype_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Itemtype_id.TabIndex = 412
        '
        'lbl_Itemcategory_id
        '
        Me.lbl_Itemcategory_id.AutoSize = True
        Me.lbl_Itemcategory_id.Location = New System.Drawing.Point(5, 37)
        Me.lbl_Itemcategory_id.Name = "lbl_Itemcategory_id"
        Me.lbl_Itemcategory_id.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Itemcategory_id.TabIndex = 411
        Me.lbl_Itemcategory_id.Text = "Category"
        '
        'obj_Itemcategory_id
        '
        Me.obj_Itemcategory_id.BackColor = System.Drawing.Color.White
        Me.obj_Itemcategory_id.Location = New System.Drawing.Point(78, 34)
        Me.obj_Itemcategory_id.Name = "obj_Itemcategory_id"
        Me.obj_Itemcategory_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Itemcategory_id.TabIndex = 410
        '
        'lbl_Item_id
        '
        Me.lbl_Item_id.AutoSize = True
        Me.lbl_Item_id.Location = New System.Drawing.Point(5, 15)
        Me.lbl_Item_id.Name = "lbl_Item_id"
        Me.lbl_Item_id.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Item_id.TabIndex = 409
        Me.lbl_Item_id.Text = "Item"
        '
        'obj_Item_id
        '
        Me.obj_Item_id.BackColor = System.Drawing.Color.White
        Me.obj_Item_id.Location = New System.Drawing.Point(78, 12)
        Me.obj_Item_id.Name = "obj_Item_id"
        Me.obj_Item_id.Size = New System.Drawing.Size(163, 21)
        Me.obj_Item_id.TabIndex = 408
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Snow
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_product_no)
        Me.Panel3.Controls.Add(Me.btn_Parent)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_line)
        Me.Panel3.Controls.Add(Me.obj_Terimabarang_parentbarcode)
        Me.Panel3.Controls.Add(Me.lbl_Channel_iddetil)
        Me.Panel3.Controls.Add(Me.obj_Channel_iddetil)
        Me.Panel3.Controls.Add(Me.obj_Terimabarang_barcode)
        Me.Panel3.Controls.Add(Me.lbl_Asset_barcode)
        Me.Panel3.Controls.Add(Me.lbl_Asset_barcodeinduk)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_type)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_type)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_date)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_date)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_desc)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_desc)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_lineparent)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_parentline)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_line)
        Me.Panel3.Controls.Add(Me.obj_asset_terimabarangdetil_id)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_id)
        Me.Panel3.Controls.Add(Me.obj_Terimabarangdetil_nonfixasset)
        Me.Panel3.Controls.Add(Me.lbl_Terimabarangdetil_product_no)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(690, 117)
        Me.Panel3.TabIndex = 447
        '
        'obj_Terimabarangdetil_product_no
        '
        Me.obj_Terimabarangdetil_product_no.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.obj_Terimabarangdetil_product_no.FormattingEnabled = True
        Me.obj_Terimabarangdetil_product_no.Items.AddRange(New Object() {"Label", "Taffeta"})
        Me.obj_Terimabarangdetil_product_no.Location = New System.Drawing.Point(78, 87)
        Me.obj_Terimabarangdetil_product_no.Name = "obj_Terimabarangdetil_product_no"
        Me.obj_Terimabarangdetil_product_no.Size = New System.Drawing.Size(107, 21)
        Me.obj_Terimabarangdetil_product_no.TabIndex = 453
        '
        'btn_Parent
        '
        Me.btn_Parent.Location = New System.Drawing.Point(469, 36)
        Me.btn_Parent.Name = "btn_Parent"
        Me.btn_Parent.Size = New System.Drawing.Size(50, 20)
        Me.btn_Parent.TabIndex = 452
        Me.btn_Parent.Text = "Parent"
        Me.btn_Parent.UseVisualStyleBackColor = True
        '
        'obj_Terimabarangdetil_line
        '
        Me.obj_Terimabarangdetil_line.BackColor = System.Drawing.Color.AntiqueWhite
        Me.obj_Terimabarangdetil_line.Location = New System.Drawing.Point(213, 12)
        Me.obj_Terimabarangdetil_line.MaxLength = 30
        Me.obj_Terimabarangdetil_line.Name = "obj_Terimabarangdetil_line"
        Me.obj_Terimabarangdetil_line.ReadOnly = True
        Me.obj_Terimabarangdetil_line.Size = New System.Drawing.Size(49, 20)
        Me.obj_Terimabarangdetil_line.TabIndex = 369
        '
        'obj_Terimabarang_parentbarcode
        '
        Me.obj_Terimabarang_parentbarcode.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarang_parentbarcode.Location = New System.Drawing.Point(356, 37)
        Me.obj_Terimabarang_parentbarcode.MaxLength = 20
        Me.obj_Terimabarang_parentbarcode.Name = "obj_Terimabarang_parentbarcode"
        Me.obj_Terimabarang_parentbarcode.ReadOnly = True
        Me.obj_Terimabarang_parentbarcode.Size = New System.Drawing.Size(107, 20)
        Me.obj_Terimabarang_parentbarcode.TabIndex = 384
        Me.obj_Terimabarang_parentbarcode.TabStop = False
        '
        'lbl_Channel_iddetil
        '
        Me.lbl_Channel_iddetil.AutoSize = True
        Me.lbl_Channel_iddetil.Location = New System.Drawing.Point(547, 11)
        Me.lbl_Channel_iddetil.Name = "lbl_Channel_iddetil"
        Me.lbl_Channel_iddetil.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Channel_iddetil.TabIndex = 386
        Me.lbl_Channel_iddetil.Text = "Channel"
        '
        'obj_Channel_iddetil
        '
        Me.obj_Channel_iddetil.BackColor = System.Drawing.Color.White
        Me.obj_Channel_iddetil.Location = New System.Drawing.Point(605, 8)
        Me.obj_Channel_iddetil.MaxLength = 30
        Me.obj_Channel_iddetil.Name = "obj_Channel_iddetil"
        Me.obj_Channel_iddetil.Size = New System.Drawing.Size(49, 20)
        Me.obj_Channel_iddetil.TabIndex = 385
        '
        'obj_Terimabarang_barcode
        '
        Me.obj_Terimabarang_barcode.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarang_barcode.Location = New System.Drawing.Point(78, 61)
        Me.obj_Terimabarang_barcode.MaxLength = 20
        Me.obj_Terimabarang_barcode.Name = "obj_Terimabarang_barcode"
        Me.obj_Terimabarang_barcode.ReadOnly = True
        Me.obj_Terimabarang_barcode.Size = New System.Drawing.Size(107, 20)
        Me.obj_Terimabarang_barcode.TabIndex = 381
        '
        'lbl_Asset_barcode
        '
        Me.lbl_Asset_barcode.AutoSize = True
        Me.lbl_Asset_barcode.Location = New System.Drawing.Point(5, 64)
        Me.lbl_Asset_barcode.Name = "lbl_Asset_barcode"
        Me.lbl_Asset_barcode.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Asset_barcode.TabIndex = 382
        Me.lbl_Asset_barcode.Text = "Barcode"
        '
        'lbl_Asset_barcodeinduk
        '
        Me.lbl_Asset_barcodeinduk.AutoSize = True
        Me.lbl_Asset_barcodeinduk.Location = New System.Drawing.Point(268, 40)
        Me.lbl_Asset_barcodeinduk.Name = "lbl_Asset_barcodeinduk"
        Me.lbl_Asset_barcodeinduk.Size = New System.Drawing.Size(87, 13)
        Me.lbl_Asset_barcodeinduk.TabIndex = 383
        Me.lbl_Asset_barcodeinduk.Text = "Barcode (Parent)"
        '
        'lbl_Terimabarangdetil_type
        '
        Me.lbl_Terimabarangdetil_type.AutoSize = True
        Me.lbl_Terimabarangdetil_type.Location = New System.Drawing.Point(268, 17)
        Me.lbl_Terimabarangdetil_type.Name = "lbl_Terimabarangdetil_type"
        Me.lbl_Terimabarangdetil_type.Size = New System.Drawing.Size(31, 13)
        Me.lbl_Terimabarangdetil_type.TabIndex = 380
        Me.lbl_Terimabarangdetil_type.Text = "Type"
        '
        'obj_Terimabarangdetil_type
        '
        Me.obj_Terimabarangdetil_type.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_type.Location = New System.Drawing.Point(356, 14)
        Me.obj_Terimabarangdetil_type.MaxLength = 30
        Me.obj_Terimabarangdetil_type.Name = "obj_Terimabarangdetil_type"
        Me.obj_Terimabarangdetil_type.Size = New System.Drawing.Size(107, 20)
        Me.obj_Terimabarangdetil_type.TabIndex = 379
        '
        'obj_Terimabarangdetil_date
        '
        Me.obj_Terimabarangdetil_date.CustomFormat = "dd/MM/yyyy"
        Me.obj_Terimabarangdetil_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Terimabarangdetil_date.Location = New System.Drawing.Point(78, 36)
        Me.obj_Terimabarangdetil_date.Name = "obj_Terimabarangdetil_date"
        Me.obj_Terimabarangdetil_date.Size = New System.Drawing.Size(99, 20)
        Me.obj_Terimabarangdetil_date.TabIndex = 377
        '
        'lbl_Terimabarangdetil_date
        '
        Me.lbl_Terimabarangdetil_date.AutoSize = True
        Me.lbl_Terimabarangdetil_date.Location = New System.Drawing.Point(5, 40)
        Me.lbl_Terimabarangdetil_date.Name = "lbl_Terimabarangdetil_date"
        Me.lbl_Terimabarangdetil_date.Size = New System.Drawing.Size(30, 13)
        Me.lbl_Terimabarangdetil_date.TabIndex = 378
        Me.lbl_Terimabarangdetil_date.Text = "Date"
        '
        'obj_Terimabarangdetil_desc
        '
        Me.obj_Terimabarangdetil_desc.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_desc.Location = New System.Drawing.Point(604, 37)
        Me.obj_Terimabarangdetil_desc.MaxLength = 20
        Me.obj_Terimabarangdetil_desc.Multiline = True
        Me.obj_Terimabarangdetil_desc.Name = "obj_Terimabarangdetil_desc"
        Me.obj_Terimabarangdetil_desc.ReadOnly = True
        Me.obj_Terimabarangdetil_desc.Size = New System.Drawing.Size(148, 44)
        Me.obj_Terimabarangdetil_desc.TabIndex = 375
        '
        'lbl_Terimabarangdetil_desc
        '
        Me.lbl_Terimabarangdetil_desc.AutoSize = True
        Me.lbl_Terimabarangdetil_desc.Location = New System.Drawing.Point(547, 40)
        Me.lbl_Terimabarangdetil_desc.Name = "lbl_Terimabarangdetil_desc"
        Me.lbl_Terimabarangdetil_desc.Size = New System.Drawing.Size(32, 13)
        Me.lbl_Terimabarangdetil_desc.TabIndex = 376
        Me.lbl_Terimabarangdetil_desc.Text = "Desc"
        '
        'lbl_Terimabarangdetil_lineparent
        '
        Me.lbl_Terimabarangdetil_lineparent.AutoSize = True
        Me.lbl_Terimabarangdetil_lineparent.Location = New System.Drawing.Point(268, 64)
        Me.lbl_Terimabarangdetil_lineparent.Name = "lbl_Terimabarangdetil_lineparent"
        Me.lbl_Terimabarangdetil_lineparent.Size = New System.Drawing.Size(67, 13)
        Me.lbl_Terimabarangdetil_lineparent.TabIndex = 374
        Me.lbl_Terimabarangdetil_lineparent.Text = "Line (Parent)"
        '
        'obj_Terimabarangdetil_parentline
        '
        Me.obj_Terimabarangdetil_parentline.BackColor = System.Drawing.Color.White
        Me.obj_Terimabarangdetil_parentline.Location = New System.Drawing.Point(356, 60)
        Me.obj_Terimabarangdetil_parentline.MaxLength = 30
        Me.obj_Terimabarangdetil_parentline.Name = "obj_Terimabarangdetil_parentline"
        Me.obj_Terimabarangdetil_parentline.Size = New System.Drawing.Size(49, 20)
        Me.obj_Terimabarangdetil_parentline.TabIndex = 373
        '
        'lbl_Terimabarangdetil_line
        '
        Me.lbl_Terimabarangdetil_line.AutoSize = True
        Me.lbl_Terimabarangdetil_line.Location = New System.Drawing.Point(188, 15)
        Me.lbl_Terimabarangdetil_line.Name = "lbl_Terimabarangdetil_line"
        Me.lbl_Terimabarangdetil_line.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Terimabarangdetil_line.TabIndex = 372
        Me.lbl_Terimabarangdetil_line.Text = "Line"
        '
        'obj_asset_terimabarangdetil_id
        '
        Me.obj_asset_terimabarangdetil_id.BackColor = System.Drawing.Color.AntiqueWhite
        Me.obj_asset_terimabarangdetil_id.Location = New System.Drawing.Point(78, 12)
        Me.obj_asset_terimabarangdetil_id.MaxLength = 20
        Me.obj_asset_terimabarangdetil_id.Name = "obj_asset_terimabarangdetil_id"
        Me.obj_asset_terimabarangdetil_id.ReadOnly = True
        Me.obj_asset_terimabarangdetil_id.Size = New System.Drawing.Size(107, 20)
        Me.obj_asset_terimabarangdetil_id.TabIndex = 370
        '
        'lbl_Terimabarangdetil_id
        '
        Me.lbl_Terimabarangdetil_id.AutoSize = True
        Me.lbl_Terimabarangdetil_id.Location = New System.Drawing.Point(5, 15)
        Me.lbl_Terimabarangdetil_id.Name = "lbl_Terimabarangdetil_id"
        Me.lbl_Terimabarangdetil_id.Size = New System.Drawing.Size(18, 13)
        Me.lbl_Terimabarangdetil_id.TabIndex = 371
        Me.lbl_Terimabarangdetil_id.Text = "ID"
        '
        'obj_Terimabarangdetil_nonfixasset
        '
        Me.obj_Terimabarangdetil_nonfixasset.AutoSize = True
        Me.obj_Terimabarangdetil_nonfixasset.BackColor = System.Drawing.Color.OldLace
        Me.obj_Terimabarangdetil_nonfixasset.Location = New System.Drawing.Point(440, 61)
        Me.obj_Terimabarangdetil_nonfixasset.Name = "obj_Terimabarangdetil_nonfixasset"
        Me.obj_Terimabarangdetil_nonfixasset.Size = New System.Drawing.Size(91, 17)
        Me.obj_Terimabarangdetil_nonfixasset.TabIndex = 451
        Me.obj_Terimabarangdetil_nonfixasset.TabStop = False
        Me.obj_Terimabarangdetil_nonfixasset.Text = "Non Fix Asset"
        Me.obj_Terimabarangdetil_nonfixasset.UseVisualStyleBackColor = False
        '
        'lbl_Terimabarangdetil_product_no
        '
        Me.lbl_Terimabarangdetil_product_no.AutoSize = True
        Me.lbl_Terimabarangdetil_product_no.Location = New System.Drawing.Point(5, 91)
        Me.lbl_Terimabarangdetil_product_no.Name = "lbl_Terimabarangdetil_product_no"
        Me.lbl_Terimabarangdetil_product_no.Size = New System.Drawing.Size(74, 13)
        Me.lbl_Terimabarangdetil_product_no.TabIndex = 419
        Me.lbl_Terimabarangdetil_product_no.Text = "Barcode Type"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Spell.ico")
        Me.ImageList1.Images.SetKeyName(1, "Stop 2.ico")
        Me.ImageList1.Images.SetKeyName(2, "home.ico")
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_BuiltJurnal})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(133, 26)
        '
        'btn_BuiltJurnal
        '
        Me.btn_BuiltJurnal.Name = "btn_BuiltJurnal"
        Me.btn_BuiltJurnal.Size = New System.Drawing.Size(132, 22)
        Me.btn_BuiltJurnal.Text = "Built Jurnal"
        '
        'uiTrnPenerimaanBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.pnlDetil)
        Me.Controls.Add(Me.ftabMain)
        Me.DSN = resources.GetString("$this.DSN")
        Me.Name = "uiTrnPenerimaanBarang"
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
        CType(Me.DgvTrnPenerimaanbarangdetil, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnlDetil.ResumeLayout(False)
        Me.Panel_bawah.ResumeLayout(False)
        Me.Panel_bawah.PerformLayout()
        Me.Panel_atas.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
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
    Friend WithEvents PnlDataFooter As System.Windows.Forms.Panel
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
    Friend WithEvents DgvTrnPenerimaanbarangdetil As System.Windows.Forms.DataGridView
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
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyWihChildToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents Panel_atas As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents obj_Terimabarangdetil_depre_enddt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents lbl_Acc_id As System.Windows.Forms.Label
    Friend WithEvents obj_Acc_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Budgetdetil_id As System.Windows.Forms.Label
    Friend WithEvents obj_Budgetdetil_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Budget_iddetil As System.Windows.Forms.Label
    Friend WithEvents obj_Budget_iddetil As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Orderdetil_line As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Orderdetil_line As System.Windows.Forms.Label
    Friend WithEvents obj_Orderdetil_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Orderdetil_id As System.Windows.Forms.Label
    Friend WithEvents obj_Writeoff_dt As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Writeoff_dt As System.Windows.Forms.Label
    Friend WithEvents obj_Writeoff_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Writeoff_id As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_eps As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_eps As System.Windows.Forms.Label
    Friend WithEvents lbl_Show_id_cont As System.Windows.Forms.Label
    Friend WithEvents obj_Show_id_cont As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Show_id As System.Windows.Forms.Label
    Friend WithEvents obj_Show_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Strukturunitdetil_id As System.Windows.Forms.Label
    Friend WithEvents obj_Strukturunitdetil_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Employee_id As System.Windows.Forms.Label
    Friend WithEvents obj_Employee_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Terimabarangdetil_depre_enddt As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_golfiskal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_golfiskal As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_nonfixasset As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Kategoriasset_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Tipeasset_id As System.Windows.Forms.Label
    Friend WithEvents obj_Assettype_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Assetcategory_id As System.Windows.Forms.ComboBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Btn_Category As System.Windows.Forms.Button
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
    Friend WithEvents obj_Itemtype_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Itemcategory_id As System.Windows.Forms.Label
    Friend WithEvents obj_Itemcategory_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Item_id As System.Windows.Forms.Label
    Friend WithEvents obj_Item_id As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents obj_Terimabarang_parentbarcode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Channel_iddetil As System.Windows.Forms.Label
    Friend WithEvents obj_Channel_iddetil As System.Windows.Forms.TextBox
    Friend WithEvents obj_Terimabarang_barcode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_barcode As System.Windows.Forms.Label
    Friend WithEvents lbl_Asset_barcodeinduk As System.Windows.Forms.Label
    Friend WithEvents lbl_Terimabarangdetil_type As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_type As System.Windows.Forms.TextBox
    Friend WithEvents obj_Terimabarangdetil_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Terimabarangdetil_date As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_desc As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_desc As System.Windows.Forms.Label
    Friend WithEvents lbl_Terimabarangdetil_lineparent As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_parentline As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_line As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarangdetil_line As System.Windows.Forms.TextBox
    Friend WithEvents obj_asset_terimabarangdetil_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimabarangdetil_id As System.Windows.Forms.Label
    Friend WithEvents Panel_tutup As System.Windows.Forms.Panel
    Friend WithEvents btn_Parent As System.Windows.Forms.Button
    Friend WithEvents pnlclose3 As System.Windows.Forms.Panel
    Friend WithEvents obj_Jurnal_bookdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Jurnal_bookdate As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btn_BuiltJurnal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_periode As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Terimabarangdetil_product_no As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrintAllBarcode As System.Windows.Forms.Button

End Class

