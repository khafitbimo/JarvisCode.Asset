<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnTerimaJasa1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnTerimaJasa1))
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvTrnTerimajasa = New System.Windows.Forms.DataGridView
        Me.obj_USer_applogin = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.obj_Procurement_applogin = New System.Windows.Forms.TextBox
        Me.obj_User_appdt = New System.Windows.Forms.TextBox
        Me.obj_BMA_appdt = New System.Windows.Forms.TextBox
        Me.obj_Terimajasa_appuser = New System.Windows.Forms.CheckBox
        Me.lbl_Accounting_applogin = New System.Windows.Forms.Label
        Me.lbl_Terimajasa_appuser = New System.Windows.Forms.Label
        Me.obj_BMA_applogin = New System.Windows.Forms.TextBox
        Me.lbl_Terimajasa_appacc = New System.Windows.Forms.Label
        Me.obj_Terimajasa_appprc = New System.Windows.Forms.CheckBox
        Me.obj_Terimajasa_appbma = New System.Windows.Forms.CheckBox
        Me.lbl_Terimajasa_appprc = New System.Windows.Forms.Label
        Me.lbl_Terimajasa_cetakbkb = New System.Windows.Forms.Label
        Me.obj_Terimajasa_cetakbkb = New System.Windows.Forms.TextBox
        Me.lbl_Procurement_applogin = New System.Windows.Forms.Label
        Me.lbl_Terimajasa_cetakbpb = New System.Windows.Forms.Label
        Me.obj_Procurement_appdt = New System.Windows.Forms.TextBox
        Me.obj_Terimajasa_cetakbpb = New System.Windows.Forms.TextBox
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.Label41 = New System.Windows.Forms.Label
        Me.obj_top = New System.Windows.Forms.NumericUpDown
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.obj_RvID_search = New System.Windows.Forms.TextBox
        Me.chk_RvID_search = New System.Windows.Forms.CheckBox
        Me.obj_orderID_search = New System.Windows.Forms.TextBox
        Me.chk_orderID_search = New System.Windows.Forms.CheckBox
        Me.cmb_appuser = New System.Windows.Forms.ComboBox
        Me.chk_User_search = New System.Windows.Forms.CheckBox
        Me.obj_Strukturunit_id_pemilik_search = New System.Windows.Forms.ComboBox
        Me.chk_Strukturunit_id_pemilik_search = New System.Windows.Forms.CheckBox
        Me.obj_Channel_id_search = New System.Windows.Forms.ComboBox
        Me.chk_Channel_id_search = New System.Windows.Forms.CheckBox
        Me.obj_Rekanan_id_search = New System.Windows.Forms.ComboBox
        Me.chk_Rekanan_id_search = New System.Windows.Forms.CheckBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl
        Me.ftabDataDetil_Detil = New System.Windows.Forms.TabPage
        Me.DgvTrnTerimajasadetil = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btn_DeleteItem = New System.Windows.Forms.Button
        Me.btn_bonus = New System.Windows.Forms.Button
        Me.Btn_Add = New System.Windows.Forms.Button
        Me.ftabDataDetil_Amount = New System.Windows.Forms.TabPage
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
        Me.obj_Asset_ppn_header = New System.Windows.Forms.TextBox
        Me.obj_Asset_Transport_header = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.obj_Asset_disc_header = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.obj_Asset_Insurance_header = New System.Windows.Forms.TextBox
        Me.obj_Asset_pph_header = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.obj_Asset_Other_header = New System.Windows.Forms.TextBox
        Me.obj_Asset_harga_header = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.obj_Asset_Operator_header = New System.Windows.Forms.TextBox
        Me.obj_Currency_id_header = New System.Windows.Forms.ComboBox
        Me.obj_Asset_valas_header = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.obj_Asset_idrprice_header = New System.Windows.Forms.TextBox
        Me.ftabDataDetil_UserManagement = New System.Windows.Forms.TabPage
        Me.obj_Usedby = New System.Windows.Forms.TextBox
        Me.lbl_Useddt = New System.Windows.Forms.Label
        Me.obj_Useddt = New System.Windows.Forms.TextBox
        Me.lbl_Usedby = New System.Windows.Forms.Label
        Me.obj_Editdt = New System.Windows.Forms.TextBox
        Me.lbl_Editdt = New System.Windows.Forms.Label
        Me.lbl_Editby = New System.Windows.Forms.Label
        Me.obj_Editby = New System.Windows.Forms.TextBox
        Me.lbl_Inputdt = New System.Windows.Forms.Label
        Me.obj_Inputdt = New System.Windows.Forms.TextBox
        Me.lbl_Inputby = New System.Windows.Forms.Label
        Me.obj_Inputby = New System.Windows.Forms.TextBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.obj_Order_id = New System.Windows.Forms.TextBox
        Me.btn_order = New System.Windows.Forms.Button
        Me.obj_terimajasa_noSuratJalan = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.obj_Status_kedatangan_barang = New System.Windows.Forms.ComboBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.obj_Notes = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.obj_Terimajasa_location = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.obj_Status = New System.Windows.Forms.ComboBox
        Me.lbl_Status = New System.Windows.Forms.Label
        Me.obj_Qty_PO = New System.Windows.Forms.TextBox
        Me.lbl_Qty_PO = New System.Windows.Forms.Label
        Me.Obj_Qty_Mother = New System.Windows.Forms.TextBox
        Me.lbl_Qty_Mother = New System.Windows.Forms.Label
        Me.obj_Terimajasa_status = New System.Windows.Forms.ComboBox
        Me.obj_Employee_id_pemilik = New System.Windows.Forms.ComboBox
        Me.obj_Strukturunit_id_pemilik = New System.Windows.Forms.ComboBox
        Me.lbl_Terimajasa_status = New System.Windows.Forms.Label
        Me.lbl_Order_id = New System.Windows.Forms.Label
        Me.obj_Pa_ref = New System.Windows.Forms.TextBox
        Me.lbl_Pa_ref = New System.Windows.Forms.Label
        Me.obj_Rekanan_id = New System.Windows.Forms.ComboBox
        Me.lbl_Rekanan_id = New System.Windows.Forms.Label
        Me.lbl_Employee_id_pemilik = New System.Windows.Forms.Label
        Me.lbl_Strukturunit_id_pemilik = New System.Windows.Forms.Label
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.obj_Terimajasa_type = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.obj_Terimajasa_tgl = New System.Windows.Forms.MaskedTextBox
        Me.obj_Terimajasa_item = New System.Windows.Forms.TextBox
        Me.lbl_Terimajasa_item = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.obj_Channel_id = New System.Windows.Forms.ComboBox
        Me.lbl_Channel_id = New System.Windows.Forms.Label
        Me.obj_Terimajasa_id = New System.Windows.Forms.TextBox
        Me.lbl_Terimajasa_id = New System.Windows.Forms.Label
        Me.lbl_Terimajasa_tgl = New System.Windows.Forms.Label
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.FTabItem = New FlatTabControl.FlatTabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.obj_Asset_golfiskal = New System.Windows.Forms.TextBox
        Me.lbl_Asset_golfiskal = New System.Windows.Forms.Label
        Me.obj_Asset_idrprice = New System.Windows.Forms.TextBox
        Me.lbl_Asset_idrprice = New System.Windows.Forms.Label
        Me.obj_Asset_ppn = New System.Windows.Forms.TextBox
        Me.lbl_Asset_ppn = New System.Windows.Forms.Label
        Me.obj_Asset_pph = New System.Windows.Forms.TextBox
        Me.lbl_Asset_pph = New System.Windows.Forms.Label
        Me.obj_Asset_tipedepre = New System.Windows.Forms.TextBox
        Me.lbl_Asset_tipedepre = New System.Windows.Forms.Label
        Me.obj_shadow_tipedepre = New System.Windows.Forms.ComboBox
        Me.obj_Asset_valas = New System.Windows.Forms.TextBox
        Me.lbl_Asset_valas = New System.Windows.Forms.Label
        Me.obj_Asset_disc = New System.Windows.Forms.TextBox
        Me.lbl_Asset_disc = New System.Windows.Forms.Label
        Me.obj_Currency_id = New System.Windows.Forms.ComboBox
        Me.lbl_Currency_id = New System.Windows.Forms.Label
        Me.obj_Asset_harga = New System.Windows.Forms.TextBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.obj_Asset_tgl = New System.Windows.Forms.MaskedTextBox
        Me.Btn_Type = New System.Windows.Forms.Button
        Me.lbl_Asset_lineinduk = New System.Windows.Forms.Label
        Me.Btn_Brand = New System.Windows.Forms.Button
        Me.obj_Asset_lineinduk = New System.Windows.Forms.TextBox
        Me.Btn_Category = New System.Windows.Forms.Button
        Me.lbl_Asset_tgl = New System.Windows.Forms.Label
        Me.lbl_Asset_qty = New System.Windows.Forms.Label
        Me.obj_Asset_qty = New System.Windows.Forms.TextBox
        Me.obj_orderdetil_line = New System.Windows.Forms.TextBox
        Me.obj_Unit_id = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.lbl_Brand_id = New System.Windows.Forms.Label
        Me.obj_Order_idDetil = New System.Windows.Forms.TextBox
        Me.obj_Brand_id = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.lbl_Tipeitem_id = New System.Windows.Forms.Label
        Me.obj_Tipeitem_id = New System.Windows.Forms.ComboBox
        Me.obj_Asset_deskripsi = New System.Windows.Forms.TextBox
        Me.lbl_Kategoriitem_id = New System.Windows.Forms.Label
        Me.lbl_Asset_deskripsi = New System.Windows.Forms.Label
        Me.obj_Kategoriitem_id = New System.Windows.Forms.ComboBox
        Me.obj_Tipeasset_id = New System.Windows.Forms.ComboBox
        Me.lbl_Tipeasset_id = New System.Windows.Forms.Label
        Me.obj_Kategoriasset_id = New System.Windows.Forms.ComboBox
        Me.lbl_Kategoriasset_id = New System.Windows.Forms.Label
        Me.obj_Asset_serial = New System.Windows.Forms.TextBox
        Me.lbl_Asset_serial = New System.Windows.Forms.Label
        Me.obj_Asset_produknumber = New System.Windows.Forms.TextBox
        Me.lbl_Asset_produknumber = New System.Windows.Forms.Label
        Me.obj_Asset_model = New System.Windows.Forms.TextBox
        Me.lbl_Asset_model = New System.Windows.Forms.Label
        Me.obj_Asset_active = New System.Windows.Forms.CheckBox
        Me.obj_asset_depre_enddt = New System.Windows.Forms.TextBox
        Me.lbl_Asset_active = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.obj_Asset_depresiasi = New System.Windows.Forms.TextBox
        Me.lbl_Asset_depresiasi = New System.Windows.Forms.Label
        Me.obj_Asset_akum_val_depre = New System.Windows.Forms.TextBox
        Me.lbl_Asset_akum_val_depre = New System.Windows.Forms.Label
        Me.obj_Asset_hargabaru = New System.Windows.Forms.TextBox
        Me.lbl_Asset_hargabaru = New System.Windows.Forms.Label
        Me.obj_asset_Terimajasa_id = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_Asset_line = New System.Windows.Forms.TextBox
        Me.lbl_Asset_line = New System.Windows.Forms.Label
        Me.Obj_asset_channel_id = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Obj_asset_No_budget = New System.Windows.Forms.TextBox
        Me.Btn_Show = New System.Windows.Forms.Button
        Me.Btn_Room = New System.Windows.Forms.Button
        Me.Btn_Color = New System.Windows.Forms.Button
        Me.Btn_Material = New System.Windows.Forms.Button
        Me.obj_Show_id_cont_item = New System.Windows.Forms.ComboBox
        Me.obj_Jeniskelamin_id = New System.Windows.Forms.ComboBox
        Me.lbl_Show_id_cont_item = New System.Windows.Forms.Label
        Me.obj_Asset_status = New System.Windows.Forms.TextBox
        Me.lbl_Asset_status = New System.Windows.Forms.Label
        Me.obj_Wo_id = New System.Windows.Forms.TextBox
        Me.lbl_Wo_id = New System.Windows.Forms.Label
        Me.obj_Strukturunit_id = New System.Windows.Forms.ComboBox
        Me.lbl_Strukturunit_id = New System.Windows.Forms.Label
        Me.obj_Employee_id_owner = New System.Windows.Forms.ComboBox
        Me.lbl_Employee_id_owner = New System.Windows.Forms.Label
        Me.lbl_Jeniskelamin_id = New System.Windows.Forms.Label
        Me.obj_Ruang_id = New System.Windows.Forms.ComboBox
        Me.lbl_Ruang_id = New System.Windows.Forms.Label
        Me.obj_Asset_rak = New System.Windows.Forms.TextBox
        Me.lbl_Asset_rak = New System.Windows.Forms.Label
        Me.obj_Project_id = New System.Windows.Forms.ComboBox
        Me.lbl_Project_id = New System.Windows.Forms.Label
        Me.obj_Show_id = New System.Windows.Forms.ComboBox
        Me.lbl_Show_id = New System.Windows.Forms.Label
        Me.obj_Asset_eps = New System.Windows.Forms.TextBox
        Me.lbl_Asset_eps = New System.Windows.Forms.Label
        Me.obj_Material_id = New System.Windows.Forms.ComboBox
        Me.lbl_Material_id = New System.Windows.Forms.Label
        Me.obj_Warna_id = New System.Windows.Forms.ComboBox
        Me.lbl_Warna_id = New System.Windows.Forms.Label
        Me.obj_Ukuran_id = New System.Windows.Forms.ComboBox
        Me.lbl_Ukuran_id = New System.Windows.Forms.Label
        Me.cmdMother = New System.Windows.Forms.Button
        Me.cmdList = New System.Windows.Forms.Button
        Me.obj_Asset_barcodeinduk = New System.Windows.Forms.TextBox
        Me.lbl_Asset_barcodeinduk = New System.Windows.Forms.Label
        Me.obj_Is_useable = New System.Windows.Forms.CheckBox
        Me.lbl_Is_useable = New System.Windows.Forms.Label
        Me.obj_Asset_barcode = New System.Windows.Forms.TextBox
        Me.lbl_Asset_barcode = New System.Windows.Forms.Label
        Me.obj_asset_usedby = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.obj_asset_editdt = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.obj_asset_editby = New System.Windows.Forms.TextBox
        Me.obj_asset_inputdt = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.obj_asset_inputby = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvTrnTerimajasa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfFooter.SuspendLayout()
        CType(Me.obj_top, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Detil.SuspendLayout()
        CType(Me.DgvTrnTerimajasadetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.ftabDataDetil_Amount.SuspendLayout()
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
        Me.ftabDataDetil_UserManagement.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.FTabItem.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabMain.Location = New System.Drawing.Point(0, 25)
        Me.ftabMain.myBackColor = System.Drawing.Color.SteelBlue
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(781, 549)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.Lavender
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_List.Controls.Add(Me.PnlDfFooter)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(773, 520)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvTrnTerimajasa)
        Me.PnlDfMain.Controls.Add(Me.obj_USer_applogin)
        Me.PnlDfMain.Controls.Add(Me.Label29)
        Me.PnlDfMain.Controls.Add(Me.obj_Procurement_applogin)
        Me.PnlDfMain.Controls.Add(Me.obj_User_appdt)
        Me.PnlDfMain.Controls.Add(Me.obj_BMA_appdt)
        Me.PnlDfMain.Controls.Add(Me.obj_Terimajasa_appuser)
        Me.PnlDfMain.Controls.Add(Me.lbl_Accounting_applogin)
        Me.PnlDfMain.Controls.Add(Me.lbl_Terimajasa_appuser)
        Me.PnlDfMain.Controls.Add(Me.obj_BMA_applogin)
        Me.PnlDfMain.Controls.Add(Me.lbl_Terimajasa_appacc)
        Me.PnlDfMain.Controls.Add(Me.obj_Terimajasa_appprc)
        Me.PnlDfMain.Controls.Add(Me.obj_Terimajasa_appbma)
        Me.PnlDfMain.Controls.Add(Me.lbl_Terimajasa_appprc)
        Me.PnlDfMain.Controls.Add(Me.lbl_Terimajasa_cetakbkb)
        Me.PnlDfMain.Controls.Add(Me.obj_Terimajasa_cetakbkb)
        Me.PnlDfMain.Controls.Add(Me.lbl_Procurement_applogin)
        Me.PnlDfMain.Controls.Add(Me.lbl_Terimajasa_cetakbpb)
        Me.PnlDfMain.Controls.Add(Me.obj_Procurement_appdt)
        Me.PnlDfMain.Controls.Add(Me.obj_Terimajasa_cetakbpb)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 95)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(747, 312)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvTrnTerimajasa
        '
        Me.DgvTrnTerimajasa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnTerimajasa.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnTerimajasa.MultiSelect = False
        Me.DgvTrnTerimajasa.Name = "DgvTrnTerimajasa"
        Me.DgvTrnTerimajasa.Size = New System.Drawing.Size(747, 241)
        Me.DgvTrnTerimajasa.TabIndex = 0
        '
        'obj_USer_applogin
        '
        Me.obj_USer_applogin.Location = New System.Drawing.Point(317, 184)
        Me.obj_USer_applogin.MaxLength = 16
        Me.obj_USer_applogin.Name = "obj_USer_applogin"
        Me.obj_USer_applogin.ReadOnly = True
        Me.obj_USer_applogin.Size = New System.Drawing.Size(183, 20)
        Me.obj_USer_applogin.TabIndex = 48
        Me.obj_USer_applogin.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(180, 187)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(78, 13)
        Me.Label29.TabIndex = 49
        Me.Label29.Text = "User Check By"
        '
        'obj_Procurement_applogin
        '
        Me.obj_Procurement_applogin.Location = New System.Drawing.Point(317, 140)
        Me.obj_Procurement_applogin.MaxLength = 16
        Me.obj_Procurement_applogin.Name = "obj_Procurement_applogin"
        Me.obj_Procurement_applogin.ReadOnly = True
        Me.obj_Procurement_applogin.Size = New System.Drawing.Size(183, 20)
        Me.obj_Procurement_applogin.TabIndex = 28
        Me.obj_Procurement_applogin.TabStop = False
        '
        'obj_User_appdt
        '
        Me.obj_User_appdt.Location = New System.Drawing.Point(506, 184)
        Me.obj_User_appdt.MaxLength = 2
        Me.obj_User_appdt.Name = "obj_User_appdt"
        Me.obj_User_appdt.ReadOnly = True
        Me.obj_User_appdt.Size = New System.Drawing.Size(141, 20)
        Me.obj_User_appdt.TabIndex = 50
        Me.obj_User_appdt.TabStop = False
        '
        'obj_BMA_appdt
        '
        Me.obj_BMA_appdt.Location = New System.Drawing.Point(506, 162)
        Me.obj_BMA_appdt.MaxLength = 2
        Me.obj_BMA_appdt.Name = "obj_BMA_appdt"
        Me.obj_BMA_appdt.ReadOnly = True
        Me.obj_BMA_appdt.Size = New System.Drawing.Size(141, 20)
        Me.obj_BMA_appdt.TabIndex = 17
        Me.obj_BMA_appdt.TabStop = False
        '
        'obj_Terimajasa_appuser
        '
        Me.obj_Terimajasa_appuser.AutoSize = True
        Me.obj_Terimajasa_appuser.Enabled = False
        Me.obj_Terimajasa_appuser.Location = New System.Drawing.Point(139, 189)
        Me.obj_Terimajasa_appuser.Name = "obj_Terimajasa_appuser"
        Me.obj_Terimajasa_appuser.Size = New System.Drawing.Size(15, 14)
        Me.obj_Terimajasa_appuser.TabIndex = 44
        Me.obj_Terimajasa_appuser.UseVisualStyleBackColor = True
        '
        'lbl_Accounting_applogin
        '
        Me.lbl_Accounting_applogin.AutoSize = True
        Me.lbl_Accounting_applogin.Location = New System.Drawing.Point(180, 165)
        Me.lbl_Accounting_applogin.Name = "lbl_Accounting_applogin"
        Me.lbl_Accounting_applogin.Size = New System.Drawing.Size(79, 13)
        Me.lbl_Accounting_applogin.TabIndex = 14
        Me.lbl_Accounting_applogin.Text = "BMA Check By"
        '
        'lbl_Terimajasa_appuser
        '
        Me.lbl_Terimajasa_appuser.AutoSize = True
        Me.lbl_Terimajasa_appuser.Location = New System.Drawing.Point(21, 189)
        Me.lbl_Terimajasa_appuser.Name = "lbl_Terimajasa_appuser"
        Me.lbl_Terimajasa_appuser.Size = New System.Drawing.Size(78, 13)
        Me.lbl_Terimajasa_appuser.TabIndex = 42
        Me.lbl_Terimajasa_appuser.Text = "User Approved"
        '
        'obj_BMA_applogin
        '
        Me.obj_BMA_applogin.Location = New System.Drawing.Point(317, 162)
        Me.obj_BMA_applogin.MaxLength = 16
        Me.obj_BMA_applogin.Name = "obj_BMA_applogin"
        Me.obj_BMA_applogin.ReadOnly = True
        Me.obj_BMA_applogin.Size = New System.Drawing.Size(183, 20)
        Me.obj_BMA_applogin.TabIndex = 15
        Me.obj_BMA_applogin.TabStop = False
        '
        'lbl_Terimajasa_appacc
        '
        Me.lbl_Terimajasa_appacc.AutoSize = True
        Me.lbl_Terimajasa_appacc.Location = New System.Drawing.Point(21, 164)
        Me.lbl_Terimajasa_appacc.Name = "lbl_Terimajasa_appacc"
        Me.lbl_Terimajasa_appacc.Size = New System.Drawing.Size(79, 13)
        Me.lbl_Terimajasa_appacc.TabIndex = 12
        Me.lbl_Terimajasa_appacc.Text = "BMA Approved"
        '
        'obj_Terimajasa_appprc
        '
        Me.obj_Terimajasa_appprc.AutoSize = True
        Me.obj_Terimajasa_appprc.Enabled = False
        Me.obj_Terimajasa_appprc.Location = New System.Drawing.Point(139, 142)
        Me.obj_Terimajasa_appprc.Name = "obj_Terimajasa_appprc"
        Me.obj_Terimajasa_appprc.Size = New System.Drawing.Size(15, 14)
        Me.obj_Terimajasa_appprc.TabIndex = 38
        Me.obj_Terimajasa_appprc.UseVisualStyleBackColor = True
        '
        'obj_Terimajasa_appbma
        '
        Me.obj_Terimajasa_appbma.AutoSize = True
        Me.obj_Terimajasa_appbma.Enabled = False
        Me.obj_Terimajasa_appbma.Location = New System.Drawing.Point(139, 165)
        Me.obj_Terimajasa_appbma.Name = "obj_Terimajasa_appbma"
        Me.obj_Terimajasa_appbma.Size = New System.Drawing.Size(15, 14)
        Me.obj_Terimajasa_appbma.TabIndex = 13
        Me.obj_Terimajasa_appbma.UseVisualStyleBackColor = True
        '
        'lbl_Terimajasa_appprc
        '
        Me.lbl_Terimajasa_appprc.AutoSize = True
        Me.lbl_Terimajasa_appprc.Location = New System.Drawing.Point(21, 141)
        Me.lbl_Terimajasa_appprc.Name = "lbl_Terimajasa_appprc"
        Me.lbl_Terimajasa_appprc.Size = New System.Drawing.Size(116, 13)
        Me.lbl_Terimajasa_appprc.TabIndex = 27
        Me.lbl_Terimajasa_appprc.Text = "Procurement Approved"
        '
        'lbl_Terimajasa_cetakbkb
        '
        Me.lbl_Terimajasa_cetakbkb.AutoSize = True
        Me.lbl_Terimajasa_cetakbkb.Location = New System.Drawing.Point(459, 121)
        Me.lbl_Terimajasa_cetakbkb.Name = "lbl_Terimajasa_cetakbkb"
        Me.lbl_Terimajasa_cetakbkb.Size = New System.Drawing.Size(28, 13)
        Me.lbl_Terimajasa_cetakbkb.TabIndex = 34
        Me.lbl_Terimajasa_cetakbkb.Text = "BKB"
        '
        'obj_Terimajasa_cetakbkb
        '
        Me.obj_Terimajasa_cetakbkb.Location = New System.Drawing.Point(506, 116)
        Me.obj_Terimajasa_cetakbkb.MaxLength = 2
        Me.obj_Terimajasa_cetakbkb.Name = "obj_Terimajasa_cetakbkb"
        Me.obj_Terimajasa_cetakbkb.ReadOnly = True
        Me.obj_Terimajasa_cetakbkb.Size = New System.Drawing.Size(39, 20)
        Me.obj_Terimajasa_cetakbkb.TabIndex = 35
        Me.obj_Terimajasa_cetakbkb.TabStop = False
        '
        'lbl_Procurement_applogin
        '
        Me.lbl_Procurement_applogin.AutoSize = True
        Me.lbl_Procurement_applogin.Location = New System.Drawing.Point(180, 140)
        Me.lbl_Procurement_applogin.Name = "lbl_Procurement_applogin"
        Me.lbl_Procurement_applogin.Size = New System.Drawing.Size(116, 13)
        Me.lbl_Procurement_applogin.TabIndex = 29
        Me.lbl_Procurement_applogin.Text = "Procurement Check By"
        '
        'lbl_Terimajasa_cetakbpb
        '
        Me.lbl_Terimajasa_cetakbpb.AutoSize = True
        Me.lbl_Terimajasa_cetakbpb.Location = New System.Drawing.Point(180, 120)
        Me.lbl_Terimajasa_cetakbpb.Name = "lbl_Terimajasa_cetakbpb"
        Me.lbl_Terimajasa_cetakbpb.Size = New System.Drawing.Size(28, 13)
        Me.lbl_Terimajasa_cetakbpb.TabIndex = 32
        Me.lbl_Terimajasa_cetakbpb.Text = "BPB"
        '
        'obj_Procurement_appdt
        '
        Me.obj_Procurement_appdt.Location = New System.Drawing.Point(506, 140)
        Me.obj_Procurement_appdt.MaxLength = 2
        Me.obj_Procurement_appdt.Name = "obj_Procurement_appdt"
        Me.obj_Procurement_appdt.ReadOnly = True
        Me.obj_Procurement_appdt.Size = New System.Drawing.Size(141, 20)
        Me.obj_Procurement_appdt.TabIndex = 30
        Me.obj_Procurement_appdt.TabStop = False
        '
        'obj_Terimajasa_cetakbpb
        '
        Me.obj_Terimajasa_cetakbpb.Location = New System.Drawing.Point(317, 117)
        Me.obj_Terimajasa_cetakbpb.MaxLength = 2
        Me.obj_Terimajasa_cetakbpb.Name = "obj_Terimajasa_cetakbpb"
        Me.obj_Terimajasa_cetakbpb.ReadOnly = True
        Me.obj_Terimajasa_cetakbpb.Size = New System.Drawing.Size(39, 20)
        Me.obj_Terimajasa_cetakbpb.TabIndex = 33
        Me.obj_Terimajasa_cetakbpb.TabStop = False
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.AutoScroll = True
        Me.PnlDfFooter.Controls.Add(Me.Label41)
        Me.PnlDfFooter.Controls.Add(Me.obj_top)
        Me.PnlDfFooter.Controls.Add(Me.Label39)
        Me.PnlDfFooter.Controls.Add(Me.Label38)
        Me.PnlDfFooter.Controls.Add(Me.Label36)
        Me.PnlDfFooter.Controls.Add(Me.Label35)
        Me.PnlDfFooter.Controls.Add(Me.Label34)
        Me.PnlDfFooter.Controls.Add(Me.Label33)
        Me.PnlDfFooter.Controls.Add(Me.Label10)
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 486)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(767, 31)
        Me.PnlDfFooter.TabIndex = 2
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(14, 11)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(42, 13)
        Me.Label41.TabIndex = 47
        Me.Label41.Text = "Record"
        '
        'obj_top
        '
        Me.obj_top.Location = New System.Drawing.Point(62, 6)
        Me.obj_top.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.obj_top.Name = "obj_top"
        Me.obj_top.Size = New System.Drawing.Size(71, 20)
        Me.obj_top.TabIndex = 46
        Me.obj_top.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Location = New System.Drawing.Point(331, 9)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(78, 13)
        Me.Label39.TabIndex = 45
        Me.Label39.Text = "Approved User"
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Aquamarine
        Me.Label38.Location = New System.Drawing.Point(310, 8)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(15, 15)
        Me.Label38.TabIndex = 44
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Location = New System.Drawing.Point(474, 9)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(153, 13)
        Me.Label36.TabIndex = 43
        Me.Label36.Text = "Approved SPV / Section Head"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Location = New System.Drawing.Point(197, 9)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(73, 13)
        Me.Label35.TabIndex = 42
        Me.Label35.Text = "Not Approved"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Bisque
        Me.Label34.Location = New System.Drawing.Point(453, 8)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(15, 15)
        Me.Label34.TabIndex = 41
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Thistle
        Me.Label33.Location = New System.Drawing.Point(179, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(15, 15)
        Me.Label33.TabIndex = 40
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(692, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 13)
        Me.Label10.TabIndex = 39
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.AutoScroll = True
        Me.PnlDfSearch.Controls.Add(Me.obj_RvID_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_RvID_search)
        Me.PnlDfSearch.Controls.Add(Me.obj_orderID_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_orderID_search)
        Me.PnlDfSearch.Controls.Add(Me.cmb_appuser)
        Me.PnlDfSearch.Controls.Add(Me.chk_User_search)
        Me.PnlDfSearch.Controls.Add(Me.obj_Strukturunit_id_pemilik_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_Strukturunit_id_pemilik_search)
        Me.PnlDfSearch.Controls.Add(Me.obj_Channel_id_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_Channel_id_search)
        Me.PnlDfSearch.Controls.Add(Me.obj_Rekanan_id_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_Rekanan_id_search)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(767, 81)
        Me.PnlDfSearch.TabIndex = 0
        '
        'obj_RvID_search
        '
        Me.obj_RvID_search.Location = New System.Drawing.Point(491, 57)
        Me.obj_RvID_search.Name = "obj_RvID_search"
        Me.obj_RvID_search.Size = New System.Drawing.Size(233, 20)
        Me.obj_RvID_search.TabIndex = 18
        '
        'chk_RvID_search
        '
        Me.chk_RvID_search.AutoSize = True
        Me.chk_RvID_search.Location = New System.Drawing.Point(387, 60)
        Me.chk_RvID_search.Name = "chk_RvID_search"
        Me.chk_RvID_search.Size = New System.Drawing.Size(61, 17)
        Me.chk_RvID_search.TabIndex = 17
        Me.chk_RvID_search.TabStop = False
        Me.chk_RvID_search.Text = "RV No."
        '
        'obj_orderID_search
        '
        Me.obj_orderID_search.Location = New System.Drawing.Point(116, 57)
        Me.obj_orderID_search.Name = "obj_orderID_search"
        Me.obj_orderID_search.Size = New System.Drawing.Size(233, 20)
        Me.obj_orderID_search.TabIndex = 16
        '
        'chk_orderID_search
        '
        Me.chk_orderID_search.AutoSize = True
        Me.chk_orderID_search.Location = New System.Drawing.Point(23, 60)
        Me.chk_orderID_search.Name = "chk_orderID_search"
        Me.chk_orderID_search.Size = New System.Drawing.Size(72, 17)
        Me.chk_orderID_search.TabIndex = 15
        Me.chk_orderID_search.TabStop = False
        Me.chk_orderID_search.Text = "Order No."
        '
        'cmb_appuser
        '
        Me.cmb_appuser.Items.AddRange(New Object() {"Yes", "No"})
        Me.cmb_appuser.Location = New System.Drawing.Point(491, 33)
        Me.cmb_appuser.Name = "cmb_appuser"
        Me.cmb_appuser.Size = New System.Drawing.Size(85, 21)
        Me.cmb_appuser.TabIndex = 14
        '
        'chk_User_search
        '
        Me.chk_User_search.AutoSize = True
        Me.chk_User_search.Location = New System.Drawing.Point(387, 35)
        Me.chk_User_search.Name = "chk_User_search"
        Me.chk_User_search.Size = New System.Drawing.Size(97, 17)
        Me.chk_User_search.TabIndex = 13
        Me.chk_User_search.TabStop = False
        Me.chk_User_search.Text = "Approved User"
        '
        'obj_Strukturunit_id_pemilik_search
        '
        Me.obj_Strukturunit_id_pemilik_search.Location = New System.Drawing.Point(491, 8)
        Me.obj_Strukturunit_id_pemilik_search.Name = "obj_Strukturunit_id_pemilik_search"
        Me.obj_Strukturunit_id_pemilik_search.Size = New System.Drawing.Size(233, 21)
        Me.obj_Strukturunit_id_pemilik_search.TabIndex = 8
        '
        'chk_Strukturunit_id_pemilik_search
        '
        Me.chk_Strukturunit_id_pemilik_search.AutoSize = True
        Me.chk_Strukturunit_id_pemilik_search.Location = New System.Drawing.Point(387, 8)
        Me.chk_Strukturunit_id_pemilik_search.Name = "chk_Strukturunit_id_pemilik_search"
        Me.chk_Strukturunit_id_pemilik_search.Size = New System.Drawing.Size(81, 17)
        Me.chk_Strukturunit_id_pemilik_search.TabIndex = 7
        Me.chk_Strukturunit_id_pemilik_search.TabStop = False
        Me.chk_Strukturunit_id_pemilik_search.Text = "Department"
        '
        'obj_Channel_id_search
        '
        Me.obj_Channel_id_search.Location = New System.Drawing.Point(116, 8)
        Me.obj_Channel_id_search.Name = "obj_Channel_id_search"
        Me.obj_Channel_id_search.Size = New System.Drawing.Size(85, 21)
        Me.obj_Channel_id_search.TabIndex = 0
        '
        'chk_Channel_id_search
        '
        Me.chk_Channel_id_search.AutoSize = True
        Me.chk_Channel_id_search.Enabled = False
        Me.chk_Channel_id_search.Location = New System.Drawing.Point(23, 8)
        Me.chk_Channel_id_search.Name = "chk_Channel_id_search"
        Me.chk_Channel_id_search.Size = New System.Drawing.Size(65, 17)
        Me.chk_Channel_id_search.TabIndex = 0
        Me.chk_Channel_id_search.TabStop = False
        Me.chk_Channel_id_search.Text = "Channel"
        '
        'obj_Rekanan_id_search
        '
        Me.obj_Rekanan_id_search.Location = New System.Drawing.Point(116, 32)
        Me.obj_Rekanan_id_search.Name = "obj_Rekanan_id_search"
        Me.obj_Rekanan_id_search.Size = New System.Drawing.Size(233, 21)
        Me.obj_Rekanan_id_search.TabIndex = 6
        '
        'chk_Rekanan_id_search
        '
        Me.chk_Rekanan_id_search.AutoSize = True
        Me.chk_Rekanan_id_search.Location = New System.Drawing.Point(23, 35)
        Me.chk_Rekanan_id_search.Name = "chk_Rekanan_id_search"
        Me.chk_Rekanan_id_search.Size = New System.Drawing.Size(60, 17)
        Me.chk_Rekanan_id_search.TabIndex = 6
        Me.chk_Rekanan_id_search.TabStop = False
        Me.chk_Rekanan_id_search.Text = "Vendor"
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.Panel3)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(773, 520)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Detil)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Amount)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_UserManagement)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 217)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.White
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(767, 290)
        Me.ftabDataDetil.TabIndex = 3
        '
        'ftabDataDetil_Detil
        '
        Me.ftabDataDetil_Detil.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Detil.Controls.Add(Me.DgvTrnTerimajasadetil)
        Me.ftabDataDetil_Detil.Controls.Add(Me.Panel4)
        Me.ftabDataDetil_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Detil.Name = "ftabDataDetil_Detil"
        Me.ftabDataDetil_Detil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Detil.Size = New System.Drawing.Size(759, 261)
        Me.ftabDataDetil_Detil.TabIndex = 0
        Me.ftabDataDetil_Detil.Text = "Detil"
        '
        'DgvTrnTerimajasadetil
        '
        Me.DgvTrnTerimajasadetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnTerimajasadetil.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DgvTrnTerimajasadetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnTerimajasadetil.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnTerimajasadetil.MultiSelect = False
        Me.DgvTrnTerimajasadetil.Name = "DgvTrnTerimajasadetil"
        Me.DgvTrnTerimajasadetil.Size = New System.Drawing.Size(753, 228)
        Me.DgvTrnTerimajasadetil.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyItemToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(136, 26)
        '
        'CopyItemToolStripMenuItem
        '
        Me.CopyItemToolStripMenuItem.Name = "CopyItemToolStripMenuItem"
        Me.CopyItemToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.CopyItemToolStripMenuItem.Text = "Copy Item"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btn_DeleteItem)
        Me.Panel4.Controls.Add(Me.btn_bonus)
        Me.Panel4.Controls.Add(Me.Btn_Add)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 231)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(753, 27)
        Me.Panel4.TabIndex = 3
        '
        'btn_DeleteItem
        '
        Me.btn_DeleteItem.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_DeleteItem.Location = New System.Drawing.Point(212, 0)
        Me.btn_DeleteItem.Name = "btn_DeleteItem"
        Me.btn_DeleteItem.Size = New System.Drawing.Size(105, 27)
        Me.btn_DeleteItem.TabIndex = 69
        Me.btn_DeleteItem.Text = "[-] Item"
        Me.btn_DeleteItem.UseVisualStyleBackColor = True
        '
        'btn_bonus
        '
        Me.btn_bonus.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_bonus.Location = New System.Drawing.Point(107, 0)
        Me.btn_bonus.Name = "btn_bonus"
        Me.btn_bonus.Size = New System.Drawing.Size(105, 27)
        Me.btn_bonus.TabIndex = 68
        Me.btn_bonus.Text = "[+] Item Manual"
        Me.btn_bonus.UseVisualStyleBackColor = True
        '
        'Btn_Add
        '
        Me.Btn_Add.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Add.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(107, 27)
        Me.Btn_Add.TabIndex = 66
        Me.Btn_Add.Text = "[+] Item Order"
        Me.Btn_Add.UseVisualStyleBackColor = True
        '
        'ftabDataDetil_Amount
        '
        Me.ftabDataDetil_Amount.Controls.Add(Me.FtabJurnal)
        Me.ftabDataDetil_Amount.Controls.Add(Me.Panel2)
        Me.ftabDataDetil_Amount.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Amount.Name = "ftabDataDetil_Amount"
        Me.ftabDataDetil_Amount.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Amount.Size = New System.Drawing.Size(759, 261)
        Me.ftabDataDetil_Amount.TabIndex = 1
        Me.ftabDataDetil_Amount.Text = "Amount"
        Me.ftabDataDetil_Amount.UseVisualStyleBackColor = True
        '
        'FtabJurnal
        '
        Me.FtabJurnal.Controls.Add(Me.ftabDataDetil_Pembayaran)
        Me.FtabJurnal.Controls.Add(Me.TabPage1)
        Me.FtabJurnal.Controls.Add(Me.ftabDataDetil_Reference)
        Me.FtabJurnal.Controls.Add(Me.ftabDataDetil_Response)
        Me.FtabJurnal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FtabJurnal.Location = New System.Drawing.Point(3, 108)
        Me.FtabJurnal.myBackColor = System.Drawing.Color.WhiteSmoke
        Me.FtabJurnal.Name = "FtabJurnal"
        Me.FtabJurnal.SelectedIndex = 0
        Me.FtabJurnal.Size = New System.Drawing.Size(753, 150)
        Me.FtabJurnal.TabIndex = 235
        '
        'ftabDataDetil_Pembayaran
        '
        Me.ftabDataDetil_Pembayaran.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Pembayaran.Controls.Add(Me.DgvTrnJurnaldetil_Pembayaran)
        Me.ftabDataDetil_Pembayaran.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Pembayaran.Name = "ftabDataDetil_Pembayaran"
        Me.ftabDataDetil_Pembayaran.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Pembayaran.Size = New System.Drawing.Size(164, 0)
        Me.ftabDataDetil_Pembayaran.TabIndex = 4
        Me.ftabDataDetil_Pembayaran.Text = "Penerimaan (D)"
        '
        'DgvTrnJurnaldetil_Pembayaran
        '
        Me.DgvTrnJurnaldetil_Pembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnaldetil_Pembayaran.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnaldetil_Pembayaran.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnJurnaldetil_Pembayaran.Name = "DgvTrnJurnaldetil_Pembayaran"
        Me.DgvTrnJurnaldetil_Pembayaran.Size = New System.Drawing.Size(158, 0)
        Me.DgvTrnJurnaldetil_Pembayaran.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.LavenderBlush
        Me.TabPage1.Controls.Add(Me.Panel5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(745, 121)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pembayaran (K)"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.DgvTrnJurnaldetil)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(739, 115)
        Me.Panel5.TabIndex = 1
        '
        'DgvTrnJurnaldetil
        '
        Me.DgvTrnJurnaldetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnaldetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnaldetil.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnJurnaldetil.Name = "DgvTrnJurnaldetil"
        Me.DgvTrnJurnaldetil.Size = New System.Drawing.Size(739, 115)
        Me.DgvTrnJurnaldetil.TabIndex = 0
        '
        'ftabDataDetil_Reference
        '
        Me.ftabDataDetil_Reference.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabDataDetil_Reference.Controls.Add(Me.DgvTrnJurnalreference)
        Me.ftabDataDetil_Reference.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Reference.Name = "ftabDataDetil_Reference"
        Me.ftabDataDetil_Reference.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Reference.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Reference.TabIndex = 1
        Me.ftabDataDetil_Reference.Text = "Reference"
        '
        'DgvTrnJurnalreference
        '
        Me.DgvTrnJurnalreference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnalreference.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnalreference.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnJurnalreference.Name = "DgvTrnJurnalreference"
        Me.DgvTrnJurnalreference.Size = New System.Drawing.Size(172, 0)
        Me.DgvTrnJurnalreference.TabIndex = 1
        '
        'ftabDataDetil_Response
        '
        Me.ftabDataDetil_Response.BackColor = System.Drawing.Color.LavenderBlush
        Me.ftabDataDetil_Response.Controls.Add(Me.DgvTrnJurnalresponse)
        Me.ftabDataDetil_Response.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Response.Name = "ftabDataDetil_Response"
        Me.ftabDataDetil_Response.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Response.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_Response.TabIndex = 2
        Me.ftabDataDetil_Response.Text = "Response"
        '
        'DgvTrnJurnalresponse
        '
        Me.DgvTrnJurnalresponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnJurnalresponse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnJurnalresponse.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnJurnalresponse.Name = "DgvTrnJurnalresponse"
        Me.DgvTrnJurnalresponse.Size = New System.Drawing.Size(172, 0)
        Me.DgvTrnJurnalresponse.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.obj_Asset_ppn_header)
        Me.Panel2.Controls.Add(Me.obj_Asset_Transport_header)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.Label27)
        Me.Panel2.Controls.Add(Me.obj_Asset_disc_header)
        Me.Panel2.Controls.Add(Me.Label28)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.obj_Asset_Insurance_header)
        Me.Panel2.Controls.Add(Me.obj_Asset_pph_header)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.obj_Asset_Other_header)
        Me.Panel2.Controls.Add(Me.obj_Asset_harga_header)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.obj_Asset_Operator_header)
        Me.Panel2.Controls.Add(Me.obj_Currency_id_header)
        Me.Panel2.Controls.Add(Me.obj_Asset_valas_header)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.obj_Asset_idrprice_header)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(753, 105)
        Me.Panel2.TabIndex = 234
        '
        'obj_Asset_ppn_header
        '
        Me.obj_Asset_ppn_header.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_ppn_header.Location = New System.Drawing.Point(288, 55)
        Me.obj_Asset_ppn_header.MaxLength = 20
        Me.obj_Asset_ppn_header.Name = "obj_Asset_ppn_header"
        Me.obj_Asset_ppn_header.ReadOnly = True
        Me.obj_Asset_ppn_header.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_ppn_header.TabIndex = 217
        '
        'obj_Asset_Transport_header
        '
        Me.obj_Asset_Transport_header.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_Transport_header.Location = New System.Drawing.Point(499, 31)
        Me.obj_Asset_Transport_header.MaxLength = 20
        Me.obj_Asset_Transport_header.Name = "obj_Asset_Transport_header"
        Me.obj_Asset_Transport_header.ReadOnly = True
        Me.obj_Asset_Transport_header.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_Transport_header.TabIndex = 233
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(234, 35)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 13)
        Me.Label24.TabIndex = 221
        Me.Label24.Text = "Disc"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(427, 82)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(33, 13)
        Me.Label27.TabIndex = 231
        Me.Label27.Text = "Other"
        '
        'obj_Asset_disc_header
        '
        Me.obj_Asset_disc_header.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_disc_header.Location = New System.Drawing.Point(288, 32)
        Me.obj_Asset_disc_header.MaxLength = 20
        Me.obj_Asset_disc_header.Name = "obj_Asset_disc_header"
        Me.obj_Asset_disc_header.ReadOnly = True
        Me.obj_Asset_disc_header.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_disc_header.TabIndex = 215
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(427, 59)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(48, 13)
        Me.Label28.TabIndex = 232
        Me.Label28.Text = "Operator"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(33, 58)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(29, 13)
        Me.Label23.TabIndex = 220
        Me.Label23.Text = "PPH"
        '
        'obj_Asset_Insurance_header
        '
        Me.obj_Asset_Insurance_header.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_Insurance_header.Location = New System.Drawing.Point(499, 8)
        Me.obj_Asset_Insurance_header.MaxLength = 20
        Me.obj_Asset_Insurance_header.Name = "obj_Asset_Insurance_header"
        Me.obj_Asset_Insurance_header.ReadOnly = True
        Me.obj_Asset_Insurance_header.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_Insurance_header.TabIndex = 225
        '
        'obj_Asset_pph_header
        '
        Me.obj_Asset_pph_header.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_pph_header.Location = New System.Drawing.Point(105, 55)
        Me.obj_Asset_pph_header.MaxLength = 20
        Me.obj_Asset_pph_header.Name = "obj_Asset_pph_header"
        Me.obj_Asset_pph_header.ReadOnly = True
        Me.obj_Asset_pph_header.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_pph_header.TabIndex = 216
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(429, 12)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(54, 13)
        Me.Label25.TabIndex = 230
        Me.Label25.Text = "Insurance"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(234, 58)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 13)
        Me.Label22.TabIndex = 219
        Me.Label22.Text = "PPN"
        '
        'obj_Asset_Other_header
        '
        Me.obj_Asset_Other_header.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_Other_header.Location = New System.Drawing.Point(499, 78)
        Me.obj_Asset_Other_header.MaxLength = 20
        Me.obj_Asset_Other_header.Name = "obj_Asset_Other_header"
        Me.obj_Asset_Other_header.ReadOnly = True
        Me.obj_Asset_Other_header.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_Other_header.TabIndex = 228
        '
        'obj_Asset_harga_header
        '
        Me.obj_Asset_harga_header.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_harga_header.Location = New System.Drawing.Point(177, 9)
        Me.obj_Asset_harga_header.MaxLength = 20
        Me.obj_Asset_harga_header.Name = "obj_Asset_harga_header"
        Me.obj_Asset_harga_header.ReadOnly = True
        Me.obj_Asset_harga_header.Size = New System.Drawing.Size(222, 20)
        Me.obj_Asset_harga_header.TabIndex = 213
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(427, 35)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(52, 13)
        Me.Label26.TabIndex = 229
        Me.Label26.Text = "Transport"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(33, 11)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 13)
        Me.Label21.TabIndex = 218
        Me.Label21.Text = "Amount"
        '
        'obj_Asset_Operator_header
        '
        Me.obj_Asset_Operator_header.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_Operator_header.Location = New System.Drawing.Point(499, 55)
        Me.obj_Asset_Operator_header.MaxLength = 20
        Me.obj_Asset_Operator_header.Name = "obj_Asset_Operator_header"
        Me.obj_Asset_Operator_header.ReadOnly = True
        Me.obj_Asset_Operator_header.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_Operator_header.TabIndex = 226
        '
        'obj_Currency_id_header
        '
        Me.obj_Currency_id_header.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Currency_id_header.Enabled = False
        Me.obj_Currency_id_header.Location = New System.Drawing.Point(105, 8)
        Me.obj_Currency_id_header.Name = "obj_Currency_id_header"
        Me.obj_Currency_id_header.Size = New System.Drawing.Size(66, 21)
        Me.obj_Currency_id_header.TabIndex = 212
        '
        'obj_Asset_valas_header
        '
        Me.obj_Asset_valas_header.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_valas_header.Location = New System.Drawing.Point(105, 31)
        Me.obj_Asset_valas_header.MaxLength = 20
        Me.obj_Asset_valas_header.Name = "obj_Asset_valas_header"
        Me.obj_Asset_valas_header.ReadOnly = True
        Me.obj_Asset_valas_header.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_valas_header.TabIndex = 214
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(33, 81)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 13)
        Me.Label20.TabIndex = 223
        Me.Label20.Text = "IDR Value"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(33, 35)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 13)
        Me.Label19.TabIndex = 222
        Me.Label19.Text = "Kurs"
        '
        'obj_Asset_idrprice_header
        '
        Me.obj_Asset_idrprice_header.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_idrprice_header.Location = New System.Drawing.Point(105, 78)
        Me.obj_Asset_idrprice_header.MaxLength = 0
        Me.obj_Asset_idrprice_header.Name = "obj_Asset_idrprice_header"
        Me.obj_Asset_idrprice_header.ReadOnly = True
        Me.obj_Asset_idrprice_header.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_idrprice_header.TabIndex = 224
        Me.obj_Asset_idrprice_header.TabStop = False
        '
        'ftabDataDetil_UserManagement
        '
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.obj_Usedby)
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.lbl_Useddt)
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.obj_Useddt)
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.lbl_Usedby)
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.obj_Editdt)
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.lbl_Editdt)
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.lbl_Editby)
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.obj_Editby)
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.lbl_Inputdt)
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.obj_Inputdt)
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.lbl_Inputby)
        Me.ftabDataDetil_UserManagement.Controls.Add(Me.obj_Inputby)
        Me.ftabDataDetil_UserManagement.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_UserManagement.Name = "ftabDataDetil_UserManagement"
        Me.ftabDataDetil_UserManagement.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_UserManagement.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_UserManagement.TabIndex = 2
        Me.ftabDataDetil_UserManagement.Text = "User Management"
        Me.ftabDataDetil_UserManagement.UseVisualStyleBackColor = True
        '
        'obj_Usedby
        '
        Me.obj_Usedby.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Usedby.Location = New System.Drawing.Point(111, 118)
        Me.obj_Usedby.MaxLength = 16
        Me.obj_Usedby.Name = "obj_Usedby"
        Me.obj_Usedby.ReadOnly = True
        Me.obj_Usedby.Size = New System.Drawing.Size(166, 20)
        Me.obj_Usedby.TabIndex = 29
        Me.obj_Usedby.TabStop = False
        '
        'lbl_Useddt
        '
        Me.lbl_Useddt.AutoSize = True
        Me.lbl_Useddt.Location = New System.Drawing.Point(19, 147)
        Me.lbl_Useddt.Name = "lbl_Useddt"
        Me.lbl_Useddt.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Useddt.TabIndex = 30
        Me.lbl_Useddt.Text = "Used Date"
        '
        'obj_Useddt
        '
        Me.obj_Useddt.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Useddt.Location = New System.Drawing.Point(111, 144)
        Me.obj_Useddt.MaxLength = 2
        Me.obj_Useddt.Name = "obj_Useddt"
        Me.obj_Useddt.ReadOnly = True
        Me.obj_Useddt.Size = New System.Drawing.Size(166, 20)
        Me.obj_Useddt.TabIndex = 31
        Me.obj_Useddt.TabStop = False
        '
        'lbl_Usedby
        '
        Me.lbl_Usedby.AutoSize = True
        Me.lbl_Usedby.Location = New System.Drawing.Point(19, 121)
        Me.lbl_Usedby.Name = "lbl_Usedby"
        Me.lbl_Usedby.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Usedby.TabIndex = 28
        Me.lbl_Usedby.Text = "Used By"
        '
        'obj_Editdt
        '
        Me.obj_Editdt.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Editdt.Location = New System.Drawing.Point(111, 92)
        Me.obj_Editdt.MaxLength = 2
        Me.obj_Editdt.Name = "obj_Editdt"
        Me.obj_Editdt.ReadOnly = True
        Me.obj_Editdt.Size = New System.Drawing.Size(166, 20)
        Me.obj_Editdt.TabIndex = 26
        Me.obj_Editdt.TabStop = False
        '
        'lbl_Editdt
        '
        Me.lbl_Editdt.AutoSize = True
        Me.lbl_Editdt.Location = New System.Drawing.Point(19, 95)
        Me.lbl_Editdt.Name = "lbl_Editdt"
        Me.lbl_Editdt.Size = New System.Drawing.Size(51, 13)
        Me.lbl_Editdt.TabIndex = 27
        Me.lbl_Editdt.Text = "Edit Date"
        '
        'lbl_Editby
        '
        Me.lbl_Editby.AutoSize = True
        Me.lbl_Editby.Location = New System.Drawing.Point(19, 69)
        Me.lbl_Editby.Name = "lbl_Editby"
        Me.lbl_Editby.Size = New System.Drawing.Size(40, 13)
        Me.lbl_Editby.TabIndex = 24
        Me.lbl_Editby.Text = "Edit By"
        '
        'obj_Editby
        '
        Me.obj_Editby.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Editby.Location = New System.Drawing.Point(111, 66)
        Me.obj_Editby.MaxLength = 16
        Me.obj_Editby.Name = "obj_Editby"
        Me.obj_Editby.ReadOnly = True
        Me.obj_Editby.Size = New System.Drawing.Size(166, 20)
        Me.obj_Editby.TabIndex = 25
        Me.obj_Editby.TabStop = False
        '
        'lbl_Inputdt
        '
        Me.lbl_Inputdt.AutoSize = True
        Me.lbl_Inputdt.Location = New System.Drawing.Point(19, 43)
        Me.lbl_Inputdt.Name = "lbl_Inputdt"
        Me.lbl_Inputdt.Size = New System.Drawing.Size(57, 13)
        Me.lbl_Inputdt.TabIndex = 22
        Me.lbl_Inputdt.Text = "Input Date"
        '
        'obj_Inputdt
        '
        Me.obj_Inputdt.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Inputdt.Location = New System.Drawing.Point(111, 40)
        Me.obj_Inputdt.MaxLength = 2
        Me.obj_Inputdt.Name = "obj_Inputdt"
        Me.obj_Inputdt.ReadOnly = True
        Me.obj_Inputdt.Size = New System.Drawing.Size(166, 20)
        Me.obj_Inputdt.TabIndex = 23
        Me.obj_Inputdt.TabStop = False
        '
        'lbl_Inputby
        '
        Me.lbl_Inputby.AutoSize = True
        Me.lbl_Inputby.Location = New System.Drawing.Point(19, 17)
        Me.lbl_Inputby.Name = "lbl_Inputby"
        Me.lbl_Inputby.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Inputby.TabIndex = 20
        Me.lbl_Inputby.Text = "Input By"
        '
        'obj_Inputby
        '
        Me.obj_Inputby.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Inputby.Location = New System.Drawing.Point(111, 14)
        Me.obj_Inputby.MaxLength = 16
        Me.obj_Inputby.Name = "obj_Inputby"
        Me.obj_Inputby.ReadOnly = True
        Me.obj_Inputby.Size = New System.Drawing.Size(166, 20)
        Me.obj_Inputby.TabIndex = 21
        Me.obj_Inputby.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Lavender
        Me.Panel3.Controls.Add(Me.obj_Order_id)
        Me.Panel3.Controls.Add(Me.btn_order)
        Me.Panel3.Controls.Add(Me.obj_terimajasa_noSuratJalan)
        Me.Panel3.Controls.Add(Me.Label40)
        Me.Panel3.Controls.Add(Me.obj_Status_kedatangan_barang)
        Me.Panel3.Controls.Add(Me.Label37)
        Me.Panel3.Controls.Add(Me.obj_Notes)
        Me.Panel3.Controls.Add(Me.Label32)
        Me.Panel3.Controls.Add(Me.obj_Terimajasa_location)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.obj_Status)
        Me.Panel3.Controls.Add(Me.lbl_Status)
        Me.Panel3.Controls.Add(Me.obj_Qty_PO)
        Me.Panel3.Controls.Add(Me.lbl_Qty_PO)
        Me.Panel3.Controls.Add(Me.Obj_Qty_Mother)
        Me.Panel3.Controls.Add(Me.lbl_Qty_Mother)
        Me.Panel3.Controls.Add(Me.obj_Terimajasa_status)
        Me.Panel3.Controls.Add(Me.obj_Employee_id_pemilik)
        Me.Panel3.Controls.Add(Me.obj_Strukturunit_id_pemilik)
        Me.Panel3.Controls.Add(Me.lbl_Terimajasa_status)
        Me.Panel3.Controls.Add(Me.lbl_Order_id)
        Me.Panel3.Controls.Add(Me.obj_Pa_ref)
        Me.Panel3.Controls.Add(Me.lbl_Pa_ref)
        Me.Panel3.Controls.Add(Me.obj_Rekanan_id)
        Me.Panel3.Controls.Add(Me.lbl_Rekanan_id)
        Me.Panel3.Controls.Add(Me.lbl_Employee_id_pemilik)
        Me.Panel3.Controls.Add(Me.lbl_Strukturunit_id_pemilik)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 35)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(767, 182)
        Me.Panel3.TabIndex = 4
        '
        'obj_Order_id
        '
        Me.obj_Order_id.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Order_id.Location = New System.Drawing.Point(122, 59)
        Me.obj_Order_id.MaxLength = 15
        Me.obj_Order_id.Name = "obj_Order_id"
        Me.obj_Order_id.ReadOnly = True
        Me.obj_Order_id.Size = New System.Drawing.Size(170, 20)
        Me.obj_Order_id.TabIndex = 347
        Me.obj_Order_id.TabStop = False
        '
        'btn_order
        '
        Me.btn_order.BackColor = System.Drawing.Color.AntiqueWhite
        Me.btn_order.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_order.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_order.ForeColor = System.Drawing.Color.Red
        Me.btn_order.Image = Global.ASSET.My.Resources.Resources.loading
        Me.btn_order.Location = New System.Drawing.Point(298, 61)
        Me.btn_order.Name = "btn_order"
        Me.btn_order.Size = New System.Drawing.Size(19, 19)
        Me.btn_order.TabIndex = 346
        Me.btn_order.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btn_order, "Load Order Number")
        Me.btn_order.UseVisualStyleBackColor = False
        '
        'obj_terimajasa_noSuratJalan
        '
        Me.obj_terimajasa_noSuratJalan.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_terimajasa_noSuratJalan.Location = New System.Drawing.Point(122, 129)
        Me.obj_terimajasa_noSuratJalan.MaxLength = 0
        Me.obj_terimajasa_noSuratJalan.Name = "obj_terimajasa_noSuratJalan"
        Me.obj_terimajasa_noSuratJalan.Size = New System.Drawing.Size(170, 20)
        Me.obj_terimajasa_noSuratJalan.TabIndex = 4
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(23, 132)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(94, 13)
        Me.Label40.TabIndex = 76
        Me.Label40.Text = "Delivery Order No."
        '
        'obj_Status_kedatangan_barang
        '
        Me.obj_Status_kedatangan_barang.Items.AddRange(New Object() {"-- Pilih --", "Telat & Sesuai", "Telat & Tidak Sesuai", "Tepat Waktu & Sesuai", "Tepat Waktu & Tidak Sesuai"})
        Me.obj_Status_kedatangan_barang.Location = New System.Drawing.Point(122, 106)
        Me.obj_Status_kedatangan_barang.Name = "obj_Status_kedatangan_barang"
        Me.obj_Status_kedatangan_barang.Size = New System.Drawing.Size(170, 21)
        Me.obj_Status_kedatangan_barang.TabIndex = 3
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(23, 109)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(69, 13)
        Me.Label37.TabIndex = 74
        Me.Label37.Text = "Arrival Status"
        '
        'obj_Notes
        '
        Me.obj_Notes.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Notes.Location = New System.Drawing.Point(426, 108)
        Me.obj_Notes.Multiline = True
        Me.obj_Notes.Name = "obj_Notes"
        Me.obj_Notes.Size = New System.Drawing.Size(325, 63)
        Me.obj_Notes.TabIndex = 9
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(334, 111)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(35, 13)
        Me.Label32.TabIndex = 72
        Me.Label32.Text = "Notes"
        '
        'obj_Terimajasa_location
        '
        Me.obj_Terimajasa_location.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Terimajasa_location.Location = New System.Drawing.Point(426, 85)
        Me.obj_Terimajasa_location.MaxLength = 0
        Me.obj_Terimajasa_location.Name = "obj_Terimajasa_location"
        Me.obj_Terimajasa_location.Size = New System.Drawing.Size(324, 20)
        Me.obj_Terimajasa_location.TabIndex = 8
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(334, 88)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(48, 13)
        Me.Label31.TabIndex = 67
        Me.Label31.Text = "Location"
        '
        'obj_Status
        '
        Me.obj_Status.Enabled = False
        Me.obj_Status.Items.AddRange(New Object() {"-- Pilih --", "COMPLETE", "INCOMPLETE"})
        Me.obj_Status.Location = New System.Drawing.Point(122, 83)
        Me.obj_Status.Name = "obj_Status"
        Me.obj_Status.Size = New System.Drawing.Size(170, 21)
        Me.obj_Status.TabIndex = 2
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Location = New System.Drawing.Point(23, 88)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Status.TabIndex = 64
        Me.lbl_Status.Text = "Status"
        '
        'obj_Qty_PO
        '
        Me.obj_Qty_PO.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Qty_PO.Location = New System.Drawing.Point(250, 151)
        Me.obj_Qty_PO.MaxLength = 2
        Me.obj_Qty_PO.Name = "obj_Qty_PO"
        Me.obj_Qty_PO.ReadOnly = True
        Me.obj_Qty_PO.Size = New System.Drawing.Size(42, 20)
        Me.obj_Qty_PO.TabIndex = 61
        Me.obj_Qty_PO.TabStop = False
        '
        'lbl_Qty_PO
        '
        Me.lbl_Qty_PO.AutoSize = True
        Me.lbl_Qty_PO.Location = New System.Drawing.Point(179, 154)
        Me.lbl_Qty_PO.Name = "lbl_Qty_PO"
        Me.lbl_Qty_PO.Size = New System.Drawing.Size(70, 13)
        Me.lbl_Qty_PO.TabIndex = 62
        Me.lbl_Qty_PO.Text = "Qty RO / MO"
        '
        'Obj_Qty_Mother
        '
        Me.Obj_Qty_Mother.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Obj_Qty_Mother.Location = New System.Drawing.Point(122, 151)
        Me.Obj_Qty_Mother.MaxLength = 2
        Me.Obj_Qty_Mother.Name = "Obj_Qty_Mother"
        Me.Obj_Qty_Mother.ReadOnly = True
        Me.Obj_Qty_Mother.Size = New System.Drawing.Size(39, 20)
        Me.Obj_Qty_Mother.TabIndex = 59
        Me.Obj_Qty_Mother.TabStop = False
        '
        'lbl_Qty_Mother
        '
        Me.lbl_Qty_Mother.AutoSize = True
        Me.lbl_Qty_Mother.Location = New System.Drawing.Point(23, 154)
        Me.lbl_Qty_Mother.Name = "lbl_Qty_Mother"
        Me.lbl_Qty_Mother.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Qty_Mother.TabIndex = 60
        Me.lbl_Qty_Mother.Text = "Qty Item"
        '
        'obj_Terimajasa_status
        '
        Me.obj_Terimajasa_status.Items.AddRange(New Object() {"-- Pilih --", "NO RO", "NO MO", "RO", "MO", "TO", "EO"})
        Me.obj_Terimajasa_status.Location = New System.Drawing.Point(122, 12)
        Me.obj_Terimajasa_status.Name = "obj_Terimajasa_status"
        Me.obj_Terimajasa_status.Size = New System.Drawing.Size(170, 21)
        Me.obj_Terimajasa_status.TabIndex = 0
        '
        'obj_Employee_id_pemilik
        '
        Me.obj_Employee_id_pemilik.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Employee_id_pemilik.FormattingEnabled = True
        Me.obj_Employee_id_pemilik.Location = New System.Drawing.Point(426, 36)
        Me.obj_Employee_id_pemilik.Name = "obj_Employee_id_pemilik"
        Me.obj_Employee_id_pemilik.Size = New System.Drawing.Size(325, 21)
        Me.obj_Employee_id_pemilik.TabIndex = 6
        '
        'obj_Strukturunit_id_pemilik
        '
        Me.obj_Strukturunit_id_pemilik.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Strukturunit_id_pemilik.FormattingEnabled = True
        Me.obj_Strukturunit_id_pemilik.Location = New System.Drawing.Point(426, 61)
        Me.obj_Strukturunit_id_pemilik.Name = "obj_Strukturunit_id_pemilik"
        Me.obj_Strukturunit_id_pemilik.Size = New System.Drawing.Size(325, 21)
        Me.obj_Strukturunit_id_pemilik.TabIndex = 7
        '
        'lbl_Terimajasa_status
        '
        Me.lbl_Terimajasa_status.AutoSize = True
        Me.lbl_Terimajasa_status.Location = New System.Drawing.Point(23, 16)
        Me.lbl_Terimajasa_status.Name = "lbl_Terimajasa_status"
        Me.lbl_Terimajasa_status.Size = New System.Drawing.Size(84, 13)
        Me.lbl_Terimajasa_status.TabIndex = 42
        Me.lbl_Terimajasa_status.Text = "Status RO / MO"
        '
        'lbl_Order_id
        '
        Me.lbl_Order_id.AutoSize = True
        Me.lbl_Order_id.Location = New System.Drawing.Point(23, 62)
        Me.lbl_Order_id.Name = "lbl_Order_id"
        Me.lbl_Order_id.Size = New System.Drawing.Size(71, 13)
        Me.lbl_Order_id.TabIndex = 43
        Me.lbl_Order_id.Text = "RO / MO No."
        '
        'obj_Pa_ref
        '
        Me.obj_Pa_ref.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Pa_ref.Location = New System.Drawing.Point(122, 36)
        Me.obj_Pa_ref.MaxLength = 15
        Me.obj_Pa_ref.Name = "obj_Pa_ref"
        Me.obj_Pa_ref.ReadOnly = True
        Me.obj_Pa_ref.Size = New System.Drawing.Size(170, 20)
        Me.obj_Pa_ref.TabIndex = 1
        Me.obj_Pa_ref.TabStop = False
        '
        'lbl_Pa_ref
        '
        Me.lbl_Pa_ref.AutoSize = True
        Me.lbl_Pa_ref.Location = New System.Drawing.Point(23, 39)
        Me.lbl_Pa_ref.Name = "lbl_Pa_ref"
        Me.lbl_Pa_ref.Size = New System.Drawing.Size(65, 13)
        Me.lbl_Pa_ref.TabIndex = 46
        Me.lbl_Pa_ref.Text = "RV Ref. No."
        '
        'obj_Rekanan_id
        '
        Me.obj_Rekanan_id.Location = New System.Drawing.Point(426, 12)
        Me.obj_Rekanan_id.Name = "obj_Rekanan_id"
        Me.obj_Rekanan_id.Size = New System.Drawing.Size(325, 21)
        Me.obj_Rekanan_id.TabIndex = 5
        '
        'lbl_Rekanan_id
        '
        Me.lbl_Rekanan_id.AutoSize = True
        Me.lbl_Rekanan_id.Location = New System.Drawing.Point(334, 16)
        Me.lbl_Rekanan_id.Name = "lbl_Rekanan_id"
        Me.lbl_Rekanan_id.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Rekanan_id.TabIndex = 47
        Me.lbl_Rekanan_id.Text = "Vendor"
        '
        'lbl_Employee_id_pemilik
        '
        Me.lbl_Employee_id_pemilik.AutoSize = True
        Me.lbl_Employee_id_pemilik.Location = New System.Drawing.Point(334, 39)
        Me.lbl_Employee_id_pemilik.Name = "lbl_Employee_id_pemilik"
        Me.lbl_Employee_id_pemilik.Size = New System.Drawing.Size(68, 13)
        Me.lbl_Employee_id_pemilik.TabIndex = 49
        Me.lbl_Employee_id_pemilik.Text = "Received By"
        '
        'lbl_Strukturunit_id_pemilik
        '
        Me.lbl_Strukturunit_id_pemilik.AutoSize = True
        Me.lbl_Strukturunit_id_pemilik.Location = New System.Drawing.Point(334, 62)
        Me.lbl_Strukturunit_id_pemilik.Name = "lbl_Strukturunit_id_pemilik"
        Me.lbl_Strukturunit_id_pemilik.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Strukturunit_id_pemilik.TabIndex = 51
        Me.lbl_Strukturunit_id_pemilik.Text = "Department"
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimajasa_type)
        Me.PnlDataMaster.Controls.Add(Me.Label30)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimajasa_tgl)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimajasa_item)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimajasa_item)
        Me.PnlDataMaster.Controls.Add(Me.Label9)
        Me.PnlDataMaster.Controls.Add(Me.obj_Channel_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Channel_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Terimajasa_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimajasa_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Terimajasa_tgl)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(767, 32)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_Terimajasa_type
        '
        Me.obj_Terimajasa_type.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Terimajasa_type.Location = New System.Drawing.Point(537, 5)
        Me.obj_Terimajasa_type.MaxLength = 2
        Me.obj_Terimajasa_type.Name = "obj_Terimajasa_type"
        Me.obj_Terimajasa_type.ReadOnly = True
        Me.obj_Terimajasa_type.Size = New System.Drawing.Size(92, 20)
        Me.obj_Terimajasa_type.TabIndex = 41
        Me.obj_Terimajasa_type.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(503, 8)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(31, 13)
        Me.Label30.TabIndex = 42
        Me.Label30.Text = "Type"
        '
        'obj_Terimajasa_tgl
        '
        Me.obj_Terimajasa_tgl.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Terimajasa_tgl.Location = New System.Drawing.Point(426, 5)
        Me.obj_Terimajasa_tgl.Mask = "00/00/0000"
        Me.obj_Terimajasa_tgl.Name = "obj_Terimajasa_tgl"
        Me.obj_Terimajasa_tgl.ReadOnly = True
        Me.obj_Terimajasa_tgl.Size = New System.Drawing.Size(73, 20)
        Me.obj_Terimajasa_tgl.TabIndex = 40
        Me.obj_Terimajasa_tgl.TabStop = False
        '
        'obj_Terimajasa_item
        '
        Me.obj_Terimajasa_item.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Terimajasa_item.Location = New System.Drawing.Point(263, 5)
        Me.obj_Terimajasa_item.MaxLength = 2
        Me.obj_Terimajasa_item.Name = "obj_Terimajasa_item"
        Me.obj_Terimajasa_item.ReadOnly = True
        Me.obj_Terimajasa_item.Size = New System.Drawing.Size(29, 20)
        Me.obj_Terimajasa_item.TabIndex = 38
        Me.obj_Terimajasa_item.TabStop = False
        '
        'lbl_Terimajasa_item
        '
        Me.lbl_Terimajasa_item.AutoSize = True
        Me.lbl_Terimajasa_item.Location = New System.Drawing.Point(234, 8)
        Me.lbl_Terimajasa_item.Name = "lbl_Terimajasa_item"
        Me.lbl_Terimajasa_item.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Terimajasa_item.TabIndex = 39
        Me.lbl_Terimajasa_item.Text = "Item"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(287, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 26
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.Enabled = False
        Me.obj_Channel_id.Location = New System.Drawing.Point(682, 4)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.Size = New System.Drawing.Size(68, 21)
        Me.obj_Channel_id.TabIndex = 0
        Me.obj_Channel_id.TabStop = False
        '
        'lbl_Channel_id
        '
        Me.lbl_Channel_id.AutoSize = True
        Me.lbl_Channel_id.Location = New System.Drawing.Point(633, 8)
        Me.lbl_Channel_id.Name = "lbl_Channel_id"
        Me.lbl_Channel_id.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Channel_id.TabIndex = 0
        Me.lbl_Channel_id.Text = "Channel"
        '
        'obj_Terimajasa_id
        '
        Me.obj_Terimajasa_id.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Terimajasa_id.Location = New System.Drawing.Point(122, 5)
        Me.obj_Terimajasa_id.MaxLength = 15
        Me.obj_Terimajasa_id.Name = "obj_Terimajasa_id"
        Me.obj_Terimajasa_id.ReadOnly = True
        Me.obj_Terimajasa_id.Size = New System.Drawing.Size(106, 20)
        Me.obj_Terimajasa_id.TabIndex = 1
        Me.obj_Terimajasa_id.TabStop = False
        '
        'lbl_Terimajasa_id
        '
        Me.lbl_Terimajasa_id.AutoSize = True
        Me.lbl_Terimajasa_id.Location = New System.Drawing.Point(23, 8)
        Me.lbl_Terimajasa_id.Name = "lbl_Terimajasa_id"
        Me.lbl_Terimajasa_id.Size = New System.Drawing.Size(67, 13)
        Me.lbl_Terimajasa_id.TabIndex = 1
        Me.lbl_Terimajasa_id.Text = "Receive No."
        '
        'lbl_Terimajasa_tgl
        '
        Me.lbl_Terimajasa_tgl.AutoSize = True
        Me.lbl_Terimajasa_tgl.Location = New System.Drawing.Point(334, 8)
        Me.lbl_Terimajasa_tgl.Name = "lbl_Terimajasa_tgl"
        Me.lbl_Terimajasa_tgl.Size = New System.Drawing.Size(73, 13)
        Me.lbl_Terimajasa_tgl.TabIndex = 2
        Me.lbl_Terimajasa_tgl.Text = "Receive Date"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 507)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(767, 10)
        Me.PnlDataFooter.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "key.ico")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "warnamenuterimabarang.JPG")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.Controls.Add(Me.FTabItem)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.obj_Tipeasset_id)
        Me.Panel1.Controls.Add(Me.lbl_Tipeasset_id)
        Me.Panel1.Controls.Add(Me.obj_Kategoriasset_id)
        Me.Panel1.Controls.Add(Me.lbl_Kategoriasset_id)
        Me.Panel1.Controls.Add(Me.obj_Asset_serial)
        Me.Panel1.Controls.Add(Me.lbl_Asset_serial)
        Me.Panel1.Controls.Add(Me.obj_Asset_produknumber)
        Me.Panel1.Controls.Add(Me.lbl_Asset_produknumber)
        Me.Panel1.Controls.Add(Me.obj_Asset_model)
        Me.Panel1.Controls.Add(Me.lbl_Asset_model)
        Me.Panel1.Controls.Add(Me.obj_Asset_active)
        Me.Panel1.Controls.Add(Me.obj_asset_depre_enddt)
        Me.Panel1.Controls.Add(Me.lbl_Asset_active)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.obj_Asset_depresiasi)
        Me.Panel1.Controls.Add(Me.lbl_Asset_depresiasi)
        Me.Panel1.Controls.Add(Me.obj_Asset_akum_val_depre)
        Me.Panel1.Controls.Add(Me.lbl_Asset_akum_val_depre)
        Me.Panel1.Controls.Add(Me.obj_Asset_hargabaru)
        Me.Panel1.Controls.Add(Me.lbl_Asset_hargabaru)
        Me.Panel1.Controls.Add(Me.obj_asset_Terimajasa_id)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.obj_Asset_line)
        Me.Panel1.Controls.Add(Me.lbl_Asset_line)
        Me.Panel1.Controls.Add(Me.Obj_asset_channel_id)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Obj_asset_No_budget)
        Me.Panel1.Controls.Add(Me.Btn_Show)
        Me.Panel1.Controls.Add(Me.Btn_Room)
        Me.Panel1.Controls.Add(Me.Btn_Color)
        Me.Panel1.Controls.Add(Me.Btn_Material)
        Me.Panel1.Controls.Add(Me.obj_Show_id_cont_item)
        Me.Panel1.Controls.Add(Me.obj_Jeniskelamin_id)
        Me.Panel1.Controls.Add(Me.lbl_Show_id_cont_item)
        Me.Panel1.Controls.Add(Me.obj_Asset_status)
        Me.Panel1.Controls.Add(Me.lbl_Asset_status)
        Me.Panel1.Controls.Add(Me.obj_Wo_id)
        Me.Panel1.Controls.Add(Me.lbl_Wo_id)
        Me.Panel1.Controls.Add(Me.obj_Strukturunit_id)
        Me.Panel1.Controls.Add(Me.lbl_Strukturunit_id)
        Me.Panel1.Controls.Add(Me.obj_Employee_id_owner)
        Me.Panel1.Controls.Add(Me.lbl_Employee_id_owner)
        Me.Panel1.Controls.Add(Me.lbl_Jeniskelamin_id)
        Me.Panel1.Controls.Add(Me.obj_Ruang_id)
        Me.Panel1.Controls.Add(Me.lbl_Ruang_id)
        Me.Panel1.Controls.Add(Me.obj_Asset_rak)
        Me.Panel1.Controls.Add(Me.lbl_Asset_rak)
        Me.Panel1.Controls.Add(Me.obj_Project_id)
        Me.Panel1.Controls.Add(Me.lbl_Project_id)
        Me.Panel1.Controls.Add(Me.obj_Show_id)
        Me.Panel1.Controls.Add(Me.lbl_Show_id)
        Me.Panel1.Controls.Add(Me.obj_Asset_eps)
        Me.Panel1.Controls.Add(Me.lbl_Asset_eps)
        Me.Panel1.Controls.Add(Me.obj_Material_id)
        Me.Panel1.Controls.Add(Me.lbl_Material_id)
        Me.Panel1.Controls.Add(Me.obj_Warna_id)
        Me.Panel1.Controls.Add(Me.lbl_Warna_id)
        Me.Panel1.Controls.Add(Me.obj_Ukuran_id)
        Me.Panel1.Controls.Add(Me.lbl_Ukuran_id)
        Me.Panel1.Controls.Add(Me.cmdMother)
        Me.Panel1.Controls.Add(Me.cmdList)
        Me.Panel1.Controls.Add(Me.obj_Asset_barcodeinduk)
        Me.Panel1.Controls.Add(Me.lbl_Asset_barcodeinduk)
        Me.Panel1.Controls.Add(Me.obj_Is_useable)
        Me.Panel1.Controls.Add(Me.lbl_Is_useable)
        Me.Panel1.Controls.Add(Me.obj_Asset_barcode)
        Me.Panel1.Controls.Add(Me.lbl_Asset_barcode)
        Me.Panel1.Controls.Add(Me.obj_asset_usedby)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.obj_asset_editdt)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.obj_asset_editby)
        Me.Panel1.Controls.Add(Me.obj_asset_inputdt)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.obj_asset_inputby)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(27, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(754, 549)
        Me.Panel1.TabIndex = 2
        '
        'FTabItem
        '
        Me.FTabItem.Controls.Add(Me.TabPage3)
        Me.FTabItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FTabItem.Location = New System.Drawing.Point(0, 159)
        Me.FTabItem.myBackColor = System.Drawing.Color.Lavender
        Me.FTabItem.Name = "FTabItem"
        Me.FTabItem.SelectedIndex = 0
        Me.FTabItem.Size = New System.Drawing.Size(754, 390)
        Me.FTabItem.TabIndex = 245
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TabPage3.Controls.Add(Me.obj_Asset_golfiskal)
        Me.TabPage3.Controls.Add(Me.lbl_Asset_golfiskal)
        Me.TabPage3.Controls.Add(Me.obj_Asset_idrprice)
        Me.TabPage3.Controls.Add(Me.lbl_Asset_idrprice)
        Me.TabPage3.Controls.Add(Me.obj_Asset_ppn)
        Me.TabPage3.Controls.Add(Me.lbl_Asset_ppn)
        Me.TabPage3.Controls.Add(Me.obj_Asset_pph)
        Me.TabPage3.Controls.Add(Me.lbl_Asset_pph)
        Me.TabPage3.Controls.Add(Me.obj_Asset_tipedepre)
        Me.TabPage3.Controls.Add(Me.lbl_Asset_tipedepre)
        Me.TabPage3.Controls.Add(Me.obj_shadow_tipedepre)
        Me.TabPage3.Controls.Add(Me.obj_Asset_valas)
        Me.TabPage3.Controls.Add(Me.lbl_Asset_valas)
        Me.TabPage3.Controls.Add(Me.obj_Asset_disc)
        Me.TabPage3.Controls.Add(Me.lbl_Asset_disc)
        Me.TabPage3.Controls.Add(Me.obj_Currency_id)
        Me.TabPage3.Controls.Add(Me.lbl_Currency_id)
        Me.TabPage3.Controls.Add(Me.obj_Asset_harga)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(746, 361)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "Accounting/BMA"
        '
        'obj_Asset_golfiskal
        '
        Me.obj_Asset_golfiskal.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_golfiskal.Location = New System.Drawing.Point(463, 92)
        Me.obj_Asset_golfiskal.MaxLength = 20
        Me.obj_Asset_golfiskal.Name = "obj_Asset_golfiskal"
        Me.obj_Asset_golfiskal.ReadOnly = True
        Me.obj_Asset_golfiskal.Size = New System.Drawing.Size(145, 20)
        Me.obj_Asset_golfiskal.TabIndex = 218
        '
        'lbl_Asset_golfiskal
        '
        Me.lbl_Asset_golfiskal.AutoSize = True
        Me.lbl_Asset_golfiskal.Location = New System.Drawing.Point(391, 95)
        Me.lbl_Asset_golfiskal.Name = "lbl_Asset_golfiskal"
        Me.lbl_Asset_golfiskal.Size = New System.Drawing.Size(63, 13)
        Me.lbl_Asset_golfiskal.TabIndex = 219
        Me.lbl_Asset_golfiskal.Text = "Fiscal Asset"
        '
        'obj_Asset_idrprice
        '
        Me.obj_Asset_idrprice.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_idrprice.Location = New System.Drawing.Point(463, 69)
        Me.obj_Asset_idrprice.MaxLength = 0
        Me.obj_Asset_idrprice.Name = "obj_Asset_idrprice"
        Me.obj_Asset_idrprice.ReadOnly = True
        Me.obj_Asset_idrprice.Size = New System.Drawing.Size(145, 20)
        Me.obj_Asset_idrprice.TabIndex = 217
        Me.obj_Asset_idrprice.TabStop = False
        '
        'lbl_Asset_idrprice
        '
        Me.lbl_Asset_idrprice.AutoSize = True
        Me.lbl_Asset_idrprice.Location = New System.Drawing.Point(391, 72)
        Me.lbl_Asset_idrprice.Name = "lbl_Asset_idrprice"
        Me.lbl_Asset_idrprice.Size = New System.Drawing.Size(56, 13)
        Me.lbl_Asset_idrprice.TabIndex = 216
        Me.lbl_Asset_idrprice.Text = "IDR Value"
        '
        'obj_Asset_ppn
        '
        Me.obj_Asset_ppn.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_ppn.Location = New System.Drawing.Point(463, 47)
        Me.obj_Asset_ppn.MaxLength = 20
        Me.obj_Asset_ppn.Name = "obj_Asset_ppn"
        Me.obj_Asset_ppn.ReadOnly = True
        Me.obj_Asset_ppn.Size = New System.Drawing.Size(145, 20)
        Me.obj_Asset_ppn.TabIndex = 213
        '
        'lbl_Asset_ppn
        '
        Me.lbl_Asset_ppn.AutoSize = True
        Me.lbl_Asset_ppn.Location = New System.Drawing.Point(391, 50)
        Me.lbl_Asset_ppn.Name = "lbl_Asset_ppn"
        Me.lbl_Asset_ppn.Size = New System.Drawing.Size(29, 13)
        Me.lbl_Asset_ppn.TabIndex = 214
        Me.lbl_Asset_ppn.Text = "PPN"
        '
        'obj_Asset_pph
        '
        Me.obj_Asset_pph.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_pph.Location = New System.Drawing.Point(463, 24)
        Me.obj_Asset_pph.MaxLength = 20
        Me.obj_Asset_pph.Name = "obj_Asset_pph"
        Me.obj_Asset_pph.ReadOnly = True
        Me.obj_Asset_pph.Size = New System.Drawing.Size(145, 20)
        Me.obj_Asset_pph.TabIndex = 212
        '
        'lbl_Asset_pph
        '
        Me.lbl_Asset_pph.AutoSize = True
        Me.lbl_Asset_pph.Location = New System.Drawing.Point(391, 26)
        Me.lbl_Asset_pph.Name = "lbl_Asset_pph"
        Me.lbl_Asset_pph.Size = New System.Drawing.Size(29, 13)
        Me.lbl_Asset_pph.TabIndex = 215
        Me.lbl_Asset_pph.Text = "PPH"
        '
        'obj_Asset_tipedepre
        '
        Me.obj_Asset_tipedepre.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_tipedepre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.obj_Asset_tipedepre.Location = New System.Drawing.Point(152, 95)
        Me.obj_Asset_tipedepre.MaxLength = 20
        Me.obj_Asset_tipedepre.Multiline = True
        Me.obj_Asset_tipedepre.Name = "obj_Asset_tipedepre"
        Me.obj_Asset_tipedepre.ReadOnly = True
        Me.obj_Asset_tipedepre.Size = New System.Drawing.Size(98, 13)
        Me.obj_Asset_tipedepre.TabIndex = 130
        '
        'lbl_Asset_tipedepre
        '
        Me.lbl_Asset_tipedepre.AutoSize = True
        Me.lbl_Asset_tipedepre.Location = New System.Drawing.Point(37, 95)
        Me.lbl_Asset_tipedepre.Name = "lbl_Asset_tipedepre"
        Me.lbl_Asset_tipedepre.Size = New System.Drawing.Size(94, 13)
        Me.lbl_Asset_tipedepre.TabIndex = 131
        Me.lbl_Asset_tipedepre.Text = "Depreciation Type"
        '
        'obj_shadow_tipedepre
        '
        Me.obj_shadow_tipedepre.Enabled = False
        Me.obj_shadow_tipedepre.Items.AddRange(New Object() {"N", "A", "D", "R"})
        Me.obj_shadow_tipedepre.Location = New System.Drawing.Point(149, 91)
        Me.obj_shadow_tipedepre.Name = "obj_shadow_tipedepre"
        Me.obj_shadow_tipedepre.Size = New System.Drawing.Size(120, 21)
        Me.obj_shadow_tipedepre.TabIndex = 132
        '
        'obj_Asset_valas
        '
        Me.obj_Asset_valas.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_valas.Location = New System.Drawing.Point(149, 46)
        Me.obj_Asset_valas.MaxLength = 20
        Me.obj_Asset_valas.Name = "obj_Asset_valas"
        Me.obj_Asset_valas.ReadOnly = True
        Me.obj_Asset_valas.Size = New System.Drawing.Size(200, 20)
        Me.obj_Asset_valas.TabIndex = 45
        '
        'lbl_Asset_valas
        '
        Me.lbl_Asset_valas.AutoSize = True
        Me.lbl_Asset_valas.Location = New System.Drawing.Point(37, 50)
        Me.lbl_Asset_valas.Name = "lbl_Asset_valas"
        Me.lbl_Asset_valas.Size = New System.Drawing.Size(28, 13)
        Me.lbl_Asset_valas.TabIndex = 48
        Me.lbl_Asset_valas.Text = "Kurs"
        '
        'obj_Asset_disc
        '
        Me.obj_Asset_disc.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_disc.Location = New System.Drawing.Point(149, 69)
        Me.obj_Asset_disc.MaxLength = 20
        Me.obj_Asset_disc.Name = "obj_Asset_disc"
        Me.obj_Asset_disc.ReadOnly = True
        Me.obj_Asset_disc.Size = New System.Drawing.Size(200, 20)
        Me.obj_Asset_disc.TabIndex = 46
        '
        'lbl_Asset_disc
        '
        Me.lbl_Asset_disc.AutoSize = True
        Me.lbl_Asset_disc.Location = New System.Drawing.Point(37, 72)
        Me.lbl_Asset_disc.Name = "lbl_Asset_disc"
        Me.lbl_Asset_disc.Size = New System.Drawing.Size(28, 13)
        Me.lbl_Asset_disc.TabIndex = 47
        Me.lbl_Asset_disc.Text = "Disc"
        '
        'obj_Currency_id
        '
        Me.obj_Currency_id.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Currency_id.Enabled = False
        Me.obj_Currency_id.Location = New System.Drawing.Point(149, 20)
        Me.obj_Currency_id.Name = "obj_Currency_id"
        Me.obj_Currency_id.Size = New System.Drawing.Size(66, 21)
        Me.obj_Currency_id.TabIndex = 42
        '
        'lbl_Currency_id
        '
        Me.lbl_Currency_id.AutoSize = True
        Me.lbl_Currency_id.Location = New System.Drawing.Point(37, 23)
        Me.lbl_Currency_id.Name = "lbl_Currency_id"
        Me.lbl_Currency_id.Size = New System.Drawing.Size(43, 13)
        Me.lbl_Currency_id.TabIndex = 44
        Me.lbl_Currency_id.Text = "Amount"
        '
        'obj_Asset_harga
        '
        Me.obj_Asset_harga.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_harga.Location = New System.Drawing.Point(221, 21)
        Me.obj_Asset_harga.MaxLength = 20
        Me.obj_Asset_harga.Name = "obj_Asset_harga"
        Me.obj_Asset_harga.ReadOnly = True
        Me.obj_Asset_harga.Size = New System.Drawing.Size(128, 20)
        Me.obj_Asset_harga.TabIndex = 43
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.obj_Asset_tgl)
        Me.Panel6.Controls.Add(Me.Btn_Type)
        Me.Panel6.Controls.Add(Me.lbl_Asset_lineinduk)
        Me.Panel6.Controls.Add(Me.Btn_Brand)
        Me.Panel6.Controls.Add(Me.obj_Asset_lineinduk)
        Me.Panel6.Controls.Add(Me.Btn_Category)
        Me.Panel6.Controls.Add(Me.lbl_Asset_tgl)
        Me.Panel6.Controls.Add(Me.lbl_Asset_qty)
        Me.Panel6.Controls.Add(Me.obj_Asset_qty)
        Me.Panel6.Controls.Add(Me.obj_orderdetil_line)
        Me.Panel6.Controls.Add(Me.obj_Unit_id)
        Me.Panel6.Controls.Add(Me.Label17)
        Me.Panel6.Controls.Add(Me.lbl_Brand_id)
        Me.Panel6.Controls.Add(Me.obj_Order_idDetil)
        Me.Panel6.Controls.Add(Me.obj_Brand_id)
        Me.Panel6.Controls.Add(Me.Label18)
        Me.Panel6.Controls.Add(Me.lbl_Tipeitem_id)
        Me.Panel6.Controls.Add(Me.obj_Tipeitem_id)
        Me.Panel6.Controls.Add(Me.obj_Asset_deskripsi)
        Me.Panel6.Controls.Add(Me.lbl_Kategoriitem_id)
        Me.Panel6.Controls.Add(Me.lbl_Asset_deskripsi)
        Me.Panel6.Controls.Add(Me.obj_Kategoriitem_id)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(754, 159)
        Me.Panel6.TabIndex = 348
        '
        'obj_Asset_tgl
        '
        Me.obj_Asset_tgl.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_tgl.Location = New System.Drawing.Point(307, 22)
        Me.obj_Asset_tgl.Mask = "00/00/0000"
        Me.obj_Asset_tgl.Name = "obj_Asset_tgl"
        Me.obj_Asset_tgl.Size = New System.Drawing.Size(74, 20)
        Me.obj_Asset_tgl.TabIndex = 2
        '
        'Btn_Type
        '
        Me.Btn_Type.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Btn_Type.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Type.ForeColor = System.Drawing.Color.Red
        Me.Btn_Type.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Btn_Type.Location = New System.Drawing.Point(707, 96)
        Me.Btn_Type.Name = "Btn_Type"
        Me.Btn_Type.Size = New System.Drawing.Size(19, 19)
        Me.Btn_Type.TabIndex = 347
        Me.Btn_Type.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Btn_Type, "Load Item Type Into ComboBox")
        Me.Btn_Type.UseVisualStyleBackColor = False
        '
        'lbl_Asset_lineinduk
        '
        Me.lbl_Asset_lineinduk.AutoSize = True
        Me.lbl_Asset_lineinduk.Location = New System.Drawing.Point(419, 26)
        Me.lbl_Asset_lineinduk.Name = "lbl_Asset_lineinduk"
        Me.lbl_Asset_lineinduk.Size = New System.Drawing.Size(31, 13)
        Me.lbl_Asset_lineinduk.TabIndex = 279
        Me.lbl_Asset_lineinduk.Text = "Days"
        '
        'Btn_Brand
        '
        Me.Btn_Brand.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Btn_Brand.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Brand.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Brand.ForeColor = System.Drawing.Color.Red
        Me.Btn_Brand.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Btn_Brand.Location = New System.Drawing.Point(707, 69)
        Me.Btn_Brand.Name = "Btn_Brand"
        Me.Btn_Brand.Size = New System.Drawing.Size(19, 19)
        Me.Btn_Brand.TabIndex = 346
        Me.Btn_Brand.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Btn_Brand, "Load Item Brand Into ComboBox")
        Me.Btn_Brand.UseVisualStyleBackColor = False
        '
        'obj_Asset_lineinduk
        '
        Me.obj_Asset_lineinduk.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_lineinduk.Enabled = False
        Me.obj_Asset_lineinduk.Location = New System.Drawing.Point(486, 23)
        Me.obj_Asset_lineinduk.MaxLength = 2
        Me.obj_Asset_lineinduk.Name = "obj_Asset_lineinduk"
        Me.obj_Asset_lineinduk.ReadOnly = True
        Me.obj_Asset_lineinduk.Size = New System.Drawing.Size(46, 20)
        Me.obj_Asset_lineinduk.TabIndex = 4
        Me.obj_Asset_lineinduk.TabStop = False
        '
        'Btn_Category
        '
        Me.Btn_Category.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Btn_Category.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Category.ForeColor = System.Drawing.Color.Red
        Me.Btn_Category.Image = Global.ASSET.My.Resources.Resources.btnrefresh
        Me.Btn_Category.Location = New System.Drawing.Point(707, 44)
        Me.Btn_Category.Name = "Btn_Category"
        Me.Btn_Category.Size = New System.Drawing.Size(19, 19)
        Me.Btn_Category.TabIndex = 345
        Me.Btn_Category.TabStop = False
        Me.ToolTip1.SetToolTip(Me.Btn_Category, "Load Item Category Into ComboBox")
        Me.Btn_Category.UseVisualStyleBackColor = False
        '
        'lbl_Asset_tgl
        '
        Me.lbl_Asset_tgl.AutoSize = True
        Me.lbl_Asset_tgl.Location = New System.Drawing.Point(223, 25)
        Me.lbl_Asset_tgl.Name = "lbl_Asset_tgl"
        Me.lbl_Asset_tgl.Size = New System.Drawing.Size(73, 13)
        Me.lbl_Asset_tgl.TabIndex = 317
        Me.lbl_Asset_tgl.Text = "Receive Date"
        '
        'lbl_Asset_qty
        '
        Me.lbl_Asset_qty.AutoSize = True
        Me.lbl_Asset_qty.Location = New System.Drawing.Point(13, 26)
        Me.lbl_Asset_qty.Name = "lbl_Asset_qty"
        Me.lbl_Asset_qty.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Asset_qty.TabIndex = 321
        Me.lbl_Asset_qty.Text = "Qty / Unit"
        '
        'obj_Asset_qty
        '
        Me.obj_Asset_qty.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_qty.Location = New System.Drawing.Point(97, 23)
        Me.obj_Asset_qty.Name = "obj_Asset_qty"
        Me.obj_Asset_qty.Size = New System.Drawing.Size(40, 20)
        Me.obj_Asset_qty.TabIndex = 0
        '
        'obj_orderdetil_line
        '
        Me.obj_orderdetil_line.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_orderdetil_line.Location = New System.Drawing.Point(306, 46)
        Me.obj_orderdetil_line.MaxLength = 20
        Me.obj_orderdetil_line.Name = "obj_orderdetil_line"
        Me.obj_orderdetil_line.Size = New System.Drawing.Size(75, 20)
        Me.obj_orderdetil_line.TabIndex = 330
        Me.obj_orderdetil_line.TabStop = False
        '
        'obj_Unit_id
        '
        Me.obj_Unit_id.Location = New System.Drawing.Point(139, 22)
        Me.obj_Unit_id.Name = "obj_Unit_id"
        Me.obj_Unit_id.Size = New System.Drawing.Size(75, 21)
        Me.obj_Unit_id.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(223, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 13)
        Me.Label17.TabIndex = 331
        Me.Label17.Text = "Order Line"
        '
        'lbl_Brand_id
        '
        Me.lbl_Brand_id.AutoSize = True
        Me.lbl_Brand_id.Location = New System.Drawing.Point(419, 72)
        Me.lbl_Brand_id.Name = "lbl_Brand_id"
        Me.lbl_Brand_id.Size = New System.Drawing.Size(35, 13)
        Me.lbl_Brand_id.TabIndex = 322
        Me.lbl_Brand_id.Text = "Brand"
        '
        'obj_Order_idDetil
        '
        Me.obj_Order_idDetil.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Order_idDetil.Location = New System.Drawing.Point(96, 46)
        Me.obj_Order_idDetil.MaxLength = 10
        Me.obj_Order_idDetil.Name = "obj_Order_idDetil"
        Me.obj_Order_idDetil.Size = New System.Drawing.Size(118, 20)
        Me.obj_Order_idDetil.TabIndex = 200
        Me.obj_Order_idDetil.TabStop = False
        '
        'obj_Brand_id
        '
        Me.obj_Brand_id.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Brand_id.Location = New System.Drawing.Point(486, 70)
        Me.obj_Brand_id.Name = "obj_Brand_id"
        Me.obj_Brand_id.Size = New System.Drawing.Size(217, 21)
        Me.obj_Brand_id.TabIndex = 5
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 49)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 13)
        Me.Label18.TabIndex = 332
        Me.Label18.Text = "Order ID"
        '
        'lbl_Tipeitem_id
        '
        Me.lbl_Tipeitem_id.AutoSize = True
        Me.lbl_Tipeitem_id.Location = New System.Drawing.Point(419, 96)
        Me.lbl_Tipeitem_id.Name = "lbl_Tipeitem_id"
        Me.lbl_Tipeitem_id.Size = New System.Drawing.Size(31, 13)
        Me.lbl_Tipeitem_id.TabIndex = 325
        Me.lbl_Tipeitem_id.Text = "Type"
        '
        'obj_Tipeitem_id
        '
        Me.obj_Tipeitem_id.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Tipeitem_id.Location = New System.Drawing.Point(486, 93)
        Me.obj_Tipeitem_id.Name = "obj_Tipeitem_id"
        Me.obj_Tipeitem_id.Size = New System.Drawing.Size(217, 21)
        Me.obj_Tipeitem_id.TabIndex = 6
        '
        'obj_Asset_deskripsi
        '
        Me.obj_Asset_deskripsi.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_deskripsi.Location = New System.Drawing.Point(96, 69)
        Me.obj_Asset_deskripsi.MaxLength = 50
        Me.obj_Asset_deskripsi.Multiline = True
        Me.obj_Asset_deskripsi.Name = "obj_Asset_deskripsi"
        Me.obj_Asset_deskripsi.Size = New System.Drawing.Size(285, 45)
        Me.obj_Asset_deskripsi.TabIndex = 3
        '
        'lbl_Kategoriitem_id
        '
        Me.lbl_Kategoriitem_id.AutoSize = True
        Me.lbl_Kategoriitem_id.Location = New System.Drawing.Point(419, 46)
        Me.lbl_Kategoriitem_id.Name = "lbl_Kategoriitem_id"
        Me.lbl_Kategoriitem_id.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Kategoriitem_id.TabIndex = 324
        Me.lbl_Kategoriitem_id.Text = "Category"
        '
        'lbl_Asset_deskripsi
        '
        Me.lbl_Asset_deskripsi.AutoSize = True
        Me.lbl_Asset_deskripsi.Location = New System.Drawing.Point(12, 70)
        Me.lbl_Asset_deskripsi.Name = "lbl_Asset_deskripsi"
        Me.lbl_Asset_deskripsi.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Asset_deskripsi.TabIndex = 323
        Me.lbl_Asset_deskripsi.Text = "Description"
        '
        'obj_Kategoriitem_id
        '
        Me.obj_Kategoriitem_id.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Kategoriitem_id.Location = New System.Drawing.Point(486, 46)
        Me.obj_Kategoriitem_id.Name = "obj_Kategoriitem_id"
        Me.obj_Kategoriitem_id.Size = New System.Drawing.Size(217, 21)
        Me.obj_Kategoriitem_id.TabIndex = 4
        '
        'obj_Tipeasset_id
        '
        Me.obj_Tipeasset_id.Location = New System.Drawing.Point(115, 276)
        Me.obj_Tipeasset_id.Name = "obj_Tipeasset_id"
        Me.obj_Tipeasset_id.Size = New System.Drawing.Size(217, 21)
        Me.obj_Tipeasset_id.TabIndex = 334
        Me.obj_Tipeasset_id.Visible = False
        '
        'lbl_Tipeasset_id
        '
        Me.lbl_Tipeasset_id.AutoSize = True
        Me.lbl_Tipeasset_id.Location = New System.Drawing.Point(10, 279)
        Me.lbl_Tipeasset_id.Name = "lbl_Tipeasset_id"
        Me.lbl_Tipeasset_id.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Tipeasset_id.TabIndex = 333
        Me.lbl_Tipeasset_id.Text = "Asset Type"
        Me.lbl_Tipeasset_id.Visible = False
        '
        'obj_Kategoriasset_id
        '
        Me.obj_Kategoriasset_id.Location = New System.Drawing.Point(464, 276)
        Me.obj_Kategoriasset_id.Name = "obj_Kategoriasset_id"
        Me.obj_Kategoriasset_id.Size = New System.Drawing.Size(284, 21)
        Me.obj_Kategoriasset_id.TabIndex = 305
        Me.obj_Kategoriasset_id.Visible = False
        '
        'lbl_Kategoriasset_id
        '
        Me.lbl_Kategoriasset_id.AutoSize = True
        Me.lbl_Kategoriasset_id.Location = New System.Drawing.Point(380, 279)
        Me.lbl_Kategoriasset_id.Name = "lbl_Kategoriasset_id"
        Me.lbl_Kategoriasset_id.Size = New System.Drawing.Size(78, 13)
        Me.lbl_Kategoriasset_id.TabIndex = 306
        Me.lbl_Kategoriasset_id.Text = "Asset Category"
        Me.lbl_Kategoriasset_id.Visible = False
        '
        'obj_Asset_serial
        '
        Me.obj_Asset_serial.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_serial.Location = New System.Drawing.Point(464, 224)
        Me.obj_Asset_serial.MaxLength = 30
        Me.obj_Asset_serial.Name = "obj_Asset_serial"
        Me.obj_Asset_serial.Size = New System.Drawing.Size(217, 20)
        Me.obj_Asset_serial.TabIndex = 5
        Me.obj_Asset_serial.TabStop = False
        Me.obj_Asset_serial.Visible = False
        '
        'lbl_Asset_serial
        '
        Me.lbl_Asset_serial.AutoSize = True
        Me.lbl_Asset_serial.Location = New System.Drawing.Point(397, 227)
        Me.lbl_Asset_serial.Name = "lbl_Asset_serial"
        Me.lbl_Asset_serial.Size = New System.Drawing.Size(50, 13)
        Me.lbl_Asset_serial.TabIndex = 318
        Me.lbl_Asset_serial.Text = "Serial No"
        Me.lbl_Asset_serial.Visible = False
        '
        'obj_Asset_produknumber
        '
        Me.obj_Asset_produknumber.Location = New System.Drawing.Point(115, 250)
        Me.obj_Asset_produknumber.MaxLength = 30
        Me.obj_Asset_produknumber.Name = "obj_Asset_produknumber"
        Me.obj_Asset_produknumber.Size = New System.Drawing.Size(217, 20)
        Me.obj_Asset_produknumber.TabIndex = 307
        Me.obj_Asset_produknumber.Visible = False
        '
        'lbl_Asset_produknumber
        '
        Me.lbl_Asset_produknumber.AutoSize = True
        Me.lbl_Asset_produknumber.Location = New System.Drawing.Point(10, 253)
        Me.lbl_Asset_produknumber.Name = "lbl_Asset_produknumber"
        Me.lbl_Asset_produknumber.Size = New System.Drawing.Size(64, 13)
        Me.lbl_Asset_produknumber.TabIndex = 319
        Me.lbl_Asset_produknumber.Text = "Product No."
        Me.lbl_Asset_produknumber.Visible = False
        '
        'obj_Asset_model
        '
        Me.obj_Asset_model.Location = New System.Drawing.Point(464, 252)
        Me.obj_Asset_model.MaxLength = 30
        Me.obj_Asset_model.Name = "obj_Asset_model"
        Me.obj_Asset_model.Size = New System.Drawing.Size(284, 20)
        Me.obj_Asset_model.TabIndex = 315
        Me.obj_Asset_model.Visible = False
        '
        'lbl_Asset_model
        '
        Me.lbl_Asset_model.AutoSize = True
        Me.lbl_Asset_model.Location = New System.Drawing.Point(380, 255)
        Me.lbl_Asset_model.Name = "lbl_Asset_model"
        Me.lbl_Asset_model.Size = New System.Drawing.Size(56, 13)
        Me.lbl_Asset_model.TabIndex = 320
        Me.lbl_Asset_model.Text = "Model No."
        Me.lbl_Asset_model.Visible = False
        '
        'obj_Asset_active
        '
        Me.obj_Asset_active.AutoSize = True
        Me.obj_Asset_active.Enabled = False
        Me.obj_Asset_active.Location = New System.Drawing.Point(727, 511)
        Me.obj_Asset_active.Name = "obj_Asset_active"
        Me.obj_Asset_active.Size = New System.Drawing.Size(15, 14)
        Me.obj_Asset_active.TabIndex = 255
        Me.obj_Asset_active.UseVisualStyleBackColor = True
        Me.obj_Asset_active.Visible = False
        '
        'obj_asset_depre_enddt
        '
        Me.obj_asset_depre_enddt.Location = New System.Drawing.Point(109, 508)
        Me.obj_asset_depre_enddt.MaxLength = 1
        Me.obj_asset_depre_enddt.Name = "obj_asset_depre_enddt"
        Me.obj_asset_depre_enddt.ReadOnly = True
        Me.obj_asset_depre_enddt.Size = New System.Drawing.Size(103, 20)
        Me.obj_asset_depre_enddt.TabIndex = 246
        Me.obj_asset_depre_enddt.Visible = False
        '
        'lbl_Asset_active
        '
        Me.lbl_Asset_active.AutoSize = True
        Me.lbl_Asset_active.Location = New System.Drawing.Point(653, 511)
        Me.lbl_Asset_active.Name = "lbl_Asset_active"
        Me.lbl_Asset_active.Size = New System.Drawing.Size(68, 13)
        Me.lbl_Asset_active.TabIndex = 254
        Me.lbl_Asset_active.Text = "Asset_active"
        Me.lbl_Asset_active.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 511)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 13)
        Me.Label8.TabIndex = 253
        Me.Label8.Text = "Depresiasi End Date"
        Me.Label8.Visible = False
        '
        'obj_Asset_depresiasi
        '
        Me.obj_Asset_depresiasi.Location = New System.Drawing.Point(301, 507)
        Me.obj_Asset_depresiasi.MaxLength = 2
        Me.obj_Asset_depresiasi.Name = "obj_Asset_depresiasi"
        Me.obj_Asset_depresiasi.ReadOnly = True
        Me.obj_Asset_depresiasi.Size = New System.Drawing.Size(25, 20)
        Me.obj_Asset_depresiasi.TabIndex = 250
        Me.obj_Asset_depresiasi.TabStop = False
        Me.obj_Asset_depresiasi.Visible = False
        '
        'lbl_Asset_depresiasi
        '
        Me.lbl_Asset_depresiasi.AutoSize = True
        Me.lbl_Asset_depresiasi.Location = New System.Drawing.Point(233, 511)
        Me.lbl_Asset_depresiasi.Name = "lbl_Asset_depresiasi"
        Me.lbl_Asset_depresiasi.Size = New System.Drawing.Size(56, 13)
        Me.lbl_Asset_depresiasi.TabIndex = 249
        Me.lbl_Asset_depresiasi.Text = "Depresiasi"
        Me.lbl_Asset_depresiasi.Visible = False
        '
        'obj_Asset_akum_val_depre
        '
        Me.obj_Asset_akum_val_depre.Location = New System.Drawing.Point(458, 508)
        Me.obj_Asset_akum_val_depre.MaxLength = 4
        Me.obj_Asset_akum_val_depre.Name = "obj_Asset_akum_val_depre"
        Me.obj_Asset_akum_val_depre.ReadOnly = True
        Me.obj_Asset_akum_val_depre.Size = New System.Drawing.Size(103, 20)
        Me.obj_Asset_akum_val_depre.TabIndex = 252
        Me.obj_Asset_akum_val_depre.TabStop = False
        Me.obj_Asset_akum_val_depre.Visible = False
        '
        'lbl_Asset_akum_val_depre
        '
        Me.lbl_Asset_akum_val_depre.AutoSize = True
        Me.lbl_Asset_akum_val_depre.Location = New System.Drawing.Point(352, 508)
        Me.lbl_Asset_akum_val_depre.Name = "lbl_Asset_akum_val_depre"
        Me.lbl_Asset_akum_val_depre.Size = New System.Drawing.Size(90, 13)
        Me.lbl_Asset_akum_val_depre.TabIndex = 251
        Me.lbl_Asset_akum_val_depre.Text = "Accum val .depre"
        Me.lbl_Asset_akum_val_depre.Visible = False
        '
        'obj_Asset_hargabaru
        '
        Me.obj_Asset_hargabaru.Location = New System.Drawing.Point(271, 485)
        Me.obj_Asset_hargabaru.MaxLength = 4
        Me.obj_Asset_hargabaru.Name = "obj_Asset_hargabaru"
        Me.obj_Asset_hargabaru.ReadOnly = True
        Me.obj_Asset_hargabaru.Size = New System.Drawing.Size(26, 20)
        Me.obj_Asset_hargabaru.TabIndex = 248
        Me.obj_Asset_hargabaru.TabStop = False
        Me.obj_Asset_hargabaru.Visible = False
        '
        'lbl_Asset_hargabaru
        '
        Me.lbl_Asset_hargabaru.AutoSize = True
        Me.lbl_Asset_hargabaru.Location = New System.Drawing.Point(233, 489)
        Me.lbl_Asset_hargabaru.Name = "lbl_Asset_hargabaru"
        Me.lbl_Asset_hargabaru.Size = New System.Drawing.Size(61, 13)
        Me.lbl_Asset_hargabaru.TabIndex = 247
        Me.lbl_Asset_hargabaru.Text = "Harga Baru"
        Me.lbl_Asset_hargabaru.Visible = False
        '
        'obj_asset_Terimajasa_id
        '
        Me.obj_asset_Terimajasa_id.Location = New System.Drawing.Point(109, 457)
        Me.obj_asset_Terimajasa_id.MaxLength = 15
        Me.obj_asset_Terimajasa_id.Name = "obj_asset_Terimajasa_id"
        Me.obj_asset_Terimajasa_id.ReadOnly = True
        Me.obj_asset_Terimajasa_id.Size = New System.Drawing.Size(135, 20)
        Me.obj_asset_Terimajasa_id.TabIndex = 257
        Me.obj_asset_Terimajasa_id.TabStop = False
        Me.obj_asset_Terimajasa_id.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 460)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 256
        Me.Label1.Text = "Receive No."
        Me.Label1.Visible = False
        '
        'obj_Asset_line
        '
        Me.obj_Asset_line.Location = New System.Drawing.Point(634, 455)
        Me.obj_Asset_line.MaxLength = 2
        Me.obj_Asset_line.Name = "obj_Asset_line"
        Me.obj_Asset_line.ReadOnly = True
        Me.obj_Asset_line.Size = New System.Drawing.Size(108, 20)
        Me.obj_Asset_line.TabIndex = 259
        Me.obj_Asset_line.TabStop = False
        Me.obj_Asset_line.Visible = False
        '
        'lbl_Asset_line
        '
        Me.lbl_Asset_line.AutoSize = True
        Me.lbl_Asset_line.Location = New System.Drawing.Point(587, 458)
        Me.lbl_Asset_line.Name = "lbl_Asset_line"
        Me.lbl_Asset_line.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Asset_line.TabIndex = 258
        Me.lbl_Asset_line.Text = "Line"
        Me.lbl_Asset_line.Visible = False
        '
        'Obj_asset_channel_id
        '
        Me.Obj_asset_channel_id.Enabled = False
        Me.Obj_asset_channel_id.Location = New System.Drawing.Point(410, 455)
        Me.Obj_asset_channel_id.Name = "Obj_asset_channel_id"
        Me.Obj_asset_channel_id.Size = New System.Drawing.Size(102, 21)
        Me.Obj_asset_channel_id.TabIndex = 261
        Me.Obj_asset_channel_id.TabStop = False
        Me.Obj_asset_channel_id.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(332, 459)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 260
        Me.Label2.Text = "Channel_id"
        Me.Label2.Visible = False
        '
        'Obj_asset_No_budget
        '
        Me.Obj_asset_No_budget.Enabled = False
        Me.Obj_asset_No_budget.Location = New System.Drawing.Point(466, 471)
        Me.Obj_asset_No_budget.Name = "Obj_asset_No_budget"
        Me.Obj_asset_No_budget.Size = New System.Drawing.Size(41, 20)
        Me.Obj_asset_No_budget.TabIndex = 274
        Me.Obj_asset_No_budget.TabStop = False
        Me.Obj_asset_No_budget.Visible = False
        '
        'Btn_Show
        '
        Me.Btn_Show.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Btn_Show.Enabled = False
        Me.Btn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Show.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Show.ForeColor = System.Drawing.Color.Red
        Me.Btn_Show.Location = New System.Drawing.Point(338, 472)
        Me.Btn_Show.Name = "Btn_Show"
        Me.Btn_Show.Size = New System.Drawing.Size(16, 19)
        Me.Btn_Show.TabIndex = 304
        Me.Btn_Show.TabStop = False
        Me.Btn_Show.Text = "!"
        Me.ToolTip1.SetToolTip(Me.Btn_Show, "Load Show Into ComboBox")
        Me.Btn_Show.UseVisualStyleBackColor = False
        Me.Btn_Show.Visible = False
        '
        'Btn_Room
        '
        Me.Btn_Room.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Btn_Room.Enabled = False
        Me.Btn_Room.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Room.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Room.ForeColor = System.Drawing.Color.Red
        Me.Btn_Room.Location = New System.Drawing.Point(338, 450)
        Me.Btn_Room.Name = "Btn_Room"
        Me.Btn_Room.Size = New System.Drawing.Size(16, 19)
        Me.Btn_Room.TabIndex = 303
        Me.Btn_Room.TabStop = False
        Me.Btn_Room.Text = "!"
        Me.ToolTip1.SetToolTip(Me.Btn_Room, "Load Room Into ComboBox")
        Me.Btn_Room.UseVisualStyleBackColor = False
        Me.Btn_Room.Visible = False
        '
        'Btn_Color
        '
        Me.Btn_Color.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Btn_Color.Enabled = False
        Me.Btn_Color.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Color.ForeColor = System.Drawing.Color.Red
        Me.Btn_Color.Location = New System.Drawing.Point(580, 402)
        Me.Btn_Color.Name = "Btn_Color"
        Me.Btn_Color.Size = New System.Drawing.Size(16, 19)
        Me.Btn_Color.TabIndex = 302
        Me.Btn_Color.TabStop = False
        Me.Btn_Color.Text = "!"
        Me.ToolTip1.SetToolTip(Me.Btn_Color, "Load Colour Into ComboBox")
        Me.Btn_Color.UseVisualStyleBackColor = False
        Me.Btn_Color.Visible = False
        '
        'Btn_Material
        '
        Me.Btn_Material.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Btn_Material.Enabled = False
        Me.Btn_Material.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Material.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Material.ForeColor = System.Drawing.Color.Red
        Me.Btn_Material.Location = New System.Drawing.Point(338, 427)
        Me.Btn_Material.Name = "Btn_Material"
        Me.Btn_Material.Size = New System.Drawing.Size(16, 19)
        Me.Btn_Material.TabIndex = 301
        Me.Btn_Material.TabStop = False
        Me.Btn_Material.Text = "!"
        Me.ToolTip1.SetToolTip(Me.Btn_Material, "Load Material Into ComboBox")
        Me.Btn_Material.UseVisualStyleBackColor = False
        Me.Btn_Material.Visible = False
        '
        'obj_Show_id_cont_item
        '
        Me.obj_Show_id_cont_item.Enabled = False
        Me.obj_Show_id_cont_item.Location = New System.Drawing.Point(466, 493)
        Me.obj_Show_id_cont_item.Name = "obj_Show_id_cont_item"
        Me.obj_Show_id_cont_item.Size = New System.Drawing.Size(284, 21)
        Me.obj_Show_id_cont_item.TabIndex = 276
        Me.obj_Show_id_cont_item.TabStop = False
        Me.obj_Show_id_cont_item.Visible = False
        '
        'obj_Jeniskelamin_id
        '
        Me.obj_Jeniskelamin_id.Enabled = False
        Me.obj_Jeniskelamin_id.FormattingEnabled = True
        Me.obj_Jeniskelamin_id.Location = New System.Drawing.Point(466, 425)
        Me.obj_Jeniskelamin_id.Name = "obj_Jeniskelamin_id"
        Me.obj_Jeniskelamin_id.Size = New System.Drawing.Size(284, 21)
        Me.obj_Jeniskelamin_id.TabIndex = 272
        Me.obj_Jeniskelamin_id.TabStop = False
        Me.obj_Jeniskelamin_id.Visible = False
        '
        'lbl_Show_id_cont_item
        '
        Me.lbl_Show_id_cont_item.AutoSize = True
        Me.lbl_Show_id_cont_item.Location = New System.Drawing.Point(394, 496)
        Me.lbl_Show_id_cont_item.Name = "lbl_Show_id_cont_item"
        Me.lbl_Show_id_cont_item.Size = New System.Drawing.Size(59, 13)
        Me.lbl_Show_id_cont_item.TabIndex = 296
        Me.lbl_Show_id_cont_item.Text = "Cont Show"
        Me.lbl_Show_id_cont_item.Visible = False
        '
        'obj_Asset_status
        '
        Me.obj_Asset_status.Location = New System.Drawing.Point(112, 520)
        Me.obj_Asset_status.MaxLength = 10
        Me.obj_Asset_status.Name = "obj_Asset_status"
        Me.obj_Asset_status.ReadOnly = True
        Me.obj_Asset_status.Size = New System.Drawing.Size(108, 20)
        Me.obj_Asset_status.TabIndex = 298
        Me.obj_Asset_status.Visible = False
        '
        'lbl_Asset_status
        '
        Me.lbl_Asset_status.AutoSize = True
        Me.lbl_Asset_status.Location = New System.Drawing.Point(40, 521)
        Me.lbl_Asset_status.Name = "lbl_Asset_status"
        Me.lbl_Asset_status.Size = New System.Drawing.Size(67, 13)
        Me.lbl_Asset_status.TabIndex = 297
        Me.lbl_Asset_status.Text = "Asset_status"
        Me.lbl_Asset_status.Visible = False
        '
        'obj_Wo_id
        '
        Me.obj_Wo_id.Location = New System.Drawing.Point(304, 521)
        Me.obj_Wo_id.MaxLength = 15
        Me.obj_Wo_id.Name = "obj_Wo_id"
        Me.obj_Wo_id.ReadOnly = True
        Me.obj_Wo_id.Size = New System.Drawing.Size(284, 20)
        Me.obj_Wo_id.TabIndex = 300
        Me.obj_Wo_id.TabStop = False
        Me.obj_Wo_id.Visible = False
        '
        'lbl_Wo_id
        '
        Me.lbl_Wo_id.AutoSize = True
        Me.lbl_Wo_id.Location = New System.Drawing.Point(234, 523)
        Me.lbl_Wo_id.Name = "lbl_Wo_id"
        Me.lbl_Wo_id.Size = New System.Drawing.Size(38, 13)
        Me.lbl_Wo_id.TabIndex = 299
        Me.lbl_Wo_id.Text = "Wo_id"
        Me.lbl_Wo_id.Visible = False
        '
        'obj_Strukturunit_id
        '
        Me.obj_Strukturunit_id.Enabled = False
        Me.obj_Strukturunit_id.Location = New System.Drawing.Point(466, 379)
        Me.obj_Strukturunit_id.Name = "obj_Strukturunit_id"
        Me.obj_Strukturunit_id.Size = New System.Drawing.Size(284, 21)
        Me.obj_Strukturunit_id.TabIndex = 269
        Me.obj_Strukturunit_id.TabStop = False
        Me.obj_Strukturunit_id.Visible = False
        '
        'lbl_Strukturunit_id
        '
        Me.lbl_Strukturunit_id.AutoSize = True
        Me.lbl_Strukturunit_id.Location = New System.Drawing.Point(394, 382)
        Me.lbl_Strukturunit_id.Name = "lbl_Strukturunit_id"
        Me.lbl_Strukturunit_id.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Strukturunit_id.TabIndex = 288
        Me.lbl_Strukturunit_id.Text = "Department"
        Me.lbl_Strukturunit_id.Visible = False
        '
        'obj_Employee_id_owner
        '
        Me.obj_Employee_id_owner.Enabled = False
        Me.obj_Employee_id_owner.Location = New System.Drawing.Point(116, 399)
        Me.obj_Employee_id_owner.Name = "obj_Employee_id_owner"
        Me.obj_Employee_id_owner.Size = New System.Drawing.Size(217, 21)
        Me.obj_Employee_id_owner.TabIndex = 264
        Me.obj_Employee_id_owner.TabStop = False
        Me.obj_Employee_id_owner.Visible = False
        '
        'lbl_Employee_id_owner
        '
        Me.lbl_Employee_id_owner.AutoSize = True
        Me.lbl_Employee_id_owner.Location = New System.Drawing.Point(11, 402)
        Me.lbl_Employee_id_owner.Name = "lbl_Employee_id_owner"
        Me.lbl_Employee_id_owner.Size = New System.Drawing.Size(38, 13)
        Me.lbl_Employee_id_owner.TabIndex = 289
        Me.lbl_Employee_id_owner.Text = "Owner"
        Me.lbl_Employee_id_owner.Visible = False
        '
        'lbl_Jeniskelamin_id
        '
        Me.lbl_Jeniskelamin_id.AutoSize = True
        Me.lbl_Jeniskelamin_id.Location = New System.Drawing.Point(394, 428)
        Me.lbl_Jeniskelamin_id.Name = "lbl_Jeniskelamin_id"
        Me.lbl_Jeniskelamin_id.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Jeniskelamin_id.TabIndex = 290
        Me.lbl_Jeniskelamin_id.Text = "Sex"
        Me.lbl_Jeniskelamin_id.Visible = False
        '
        'obj_Ruang_id
        '
        Me.obj_Ruang_id.Enabled = False
        Me.obj_Ruang_id.Location = New System.Drawing.Point(116, 449)
        Me.obj_Ruang_id.Name = "obj_Ruang_id"
        Me.obj_Ruang_id.Size = New System.Drawing.Size(217, 21)
        Me.obj_Ruang_id.TabIndex = 266
        Me.obj_Ruang_id.TabStop = False
        Me.obj_Ruang_id.Visible = False
        '
        'lbl_Ruang_id
        '
        Me.lbl_Ruang_id.AutoSize = True
        Me.lbl_Ruang_id.Location = New System.Drawing.Point(11, 451)
        Me.lbl_Ruang_id.Name = "lbl_Ruang_id"
        Me.lbl_Ruang_id.Size = New System.Drawing.Size(35, 13)
        Me.lbl_Ruang_id.TabIndex = 291
        Me.lbl_Ruang_id.Text = "Room"
        Me.lbl_Ruang_id.Visible = False
        '
        'obj_Asset_rak
        '
        Me.obj_Asset_rak.Enabled = False
        Me.obj_Asset_rak.Location = New System.Drawing.Point(466, 448)
        Me.obj_Asset_rak.MaxLength = 20
        Me.obj_Asset_rak.Name = "obj_Asset_rak"
        Me.obj_Asset_rak.Size = New System.Drawing.Size(284, 20)
        Me.obj_Asset_rak.TabIndex = 273
        Me.obj_Asset_rak.TabStop = False
        Me.obj_Asset_rak.Visible = False
        '
        'lbl_Asset_rak
        '
        Me.lbl_Asset_rak.AutoSize = True
        Me.lbl_Asset_rak.Location = New System.Drawing.Point(394, 451)
        Me.lbl_Asset_rak.Name = "lbl_Asset_rak"
        Me.lbl_Asset_rak.Size = New System.Drawing.Size(33, 13)
        Me.lbl_Asset_rak.TabIndex = 292
        Me.lbl_Asset_rak.Text = "Rack"
        Me.lbl_Asset_rak.Visible = False
        '
        'obj_Project_id
        '
        Me.obj_Project_id.Enabled = False
        Me.obj_Project_id.Location = New System.Drawing.Point(509, 471)
        Me.obj_Project_id.Name = "obj_Project_id"
        Me.obj_Project_id.Size = New System.Drawing.Size(241, 21)
        Me.obj_Project_id.TabIndex = 275
        Me.obj_Project_id.TabStop = False
        Me.obj_Project_id.Visible = False
        '
        'lbl_Project_id
        '
        Me.lbl_Project_id.AutoSize = True
        Me.lbl_Project_id.Location = New System.Drawing.Point(394, 474)
        Me.lbl_Project_id.Name = "lbl_Project_id"
        Me.lbl_Project_id.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Project_id.TabIndex = 293
        Me.lbl_Project_id.Text = "Budget No"
        Me.lbl_Project_id.Visible = False
        '
        'obj_Show_id
        '
        Me.obj_Show_id.Enabled = False
        Me.obj_Show_id.Location = New System.Drawing.Point(116, 472)
        Me.obj_Show_id.Name = "obj_Show_id"
        Me.obj_Show_id.Size = New System.Drawing.Size(217, 21)
        Me.obj_Show_id.TabIndex = 267
        Me.obj_Show_id.TabStop = False
        Me.obj_Show_id.Visible = False
        '
        'lbl_Show_id
        '
        Me.lbl_Show_id.AutoSize = True
        Me.lbl_Show_id.Location = New System.Drawing.Point(11, 475)
        Me.lbl_Show_id.Name = "lbl_Show_id"
        Me.lbl_Show_id.Size = New System.Drawing.Size(34, 13)
        Me.lbl_Show_id.TabIndex = 294
        Me.lbl_Show_id.Text = "Show"
        Me.lbl_Show_id.Visible = False
        '
        'obj_Asset_eps
        '
        Me.obj_Asset_eps.Enabled = False
        Me.obj_Asset_eps.Location = New System.Drawing.Point(116, 495)
        Me.obj_Asset_eps.MaxLength = 10
        Me.obj_Asset_eps.Name = "obj_Asset_eps"
        Me.obj_Asset_eps.Size = New System.Drawing.Size(217, 20)
        Me.obj_Asset_eps.TabIndex = 268
        Me.obj_Asset_eps.TabStop = False
        Me.obj_Asset_eps.Visible = False
        '
        'lbl_Asset_eps
        '
        Me.lbl_Asset_eps.AutoSize = True
        Me.lbl_Asset_eps.Location = New System.Drawing.Point(11, 498)
        Me.lbl_Asset_eps.Name = "lbl_Asset_eps"
        Me.lbl_Asset_eps.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Asset_eps.TabIndex = 295
        Me.lbl_Asset_eps.Text = "Eps"
        Me.lbl_Asset_eps.Visible = False
        '
        'obj_Material_id
        '
        Me.obj_Material_id.Enabled = False
        Me.obj_Material_id.Location = New System.Drawing.Point(116, 426)
        Me.obj_Material_id.Name = "obj_Material_id"
        Me.obj_Material_id.Size = New System.Drawing.Size(217, 21)
        Me.obj_Material_id.TabIndex = 265
        Me.obj_Material_id.TabStop = False
        Me.obj_Material_id.Visible = False
        '
        'lbl_Material_id
        '
        Me.lbl_Material_id.AutoSize = True
        Me.lbl_Material_id.Location = New System.Drawing.Point(11, 429)
        Me.lbl_Material_id.Name = "lbl_Material_id"
        Me.lbl_Material_id.Size = New System.Drawing.Size(44, 13)
        Me.lbl_Material_id.TabIndex = 285
        Me.lbl_Material_id.Text = "Material"
        Me.lbl_Material_id.Visible = False
        '
        'obj_Warna_id
        '
        Me.obj_Warna_id.Enabled = False
        Me.obj_Warna_id.Location = New System.Drawing.Point(466, 402)
        Me.obj_Warna_id.Name = "obj_Warna_id"
        Me.obj_Warna_id.Size = New System.Drawing.Size(108, 21)
        Me.obj_Warna_id.TabIndex = 270
        Me.obj_Warna_id.TabStop = False
        Me.obj_Warna_id.Visible = False
        '
        'lbl_Warna_id
        '
        Me.lbl_Warna_id.AutoSize = True
        Me.lbl_Warna_id.Location = New System.Drawing.Point(394, 405)
        Me.lbl_Warna_id.Name = "lbl_Warna_id"
        Me.lbl_Warna_id.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Warna_id.TabIndex = 286
        Me.lbl_Warna_id.Text = "Colour"
        Me.lbl_Warna_id.Visible = False
        '
        'obj_Ukuran_id
        '
        Me.obj_Ukuran_id.Enabled = False
        Me.obj_Ukuran_id.Location = New System.Drawing.Point(642, 402)
        Me.obj_Ukuran_id.Name = "obj_Ukuran_id"
        Me.obj_Ukuran_id.Size = New System.Drawing.Size(108, 21)
        Me.obj_Ukuran_id.TabIndex = 271
        Me.obj_Ukuran_id.TabStop = False
        Me.obj_Ukuran_id.Visible = False
        '
        'lbl_Ukuran_id
        '
        Me.lbl_Ukuran_id.AutoSize = True
        Me.lbl_Ukuran_id.Location = New System.Drawing.Point(609, 406)
        Me.lbl_Ukuran_id.Name = "lbl_Ukuran_id"
        Me.lbl_Ukuran_id.Size = New System.Drawing.Size(27, 13)
        Me.lbl_Ukuran_id.TabIndex = 287
        Me.lbl_Ukuran_id.Text = "Size"
        Me.lbl_Ukuran_id.Visible = False
        '
        'cmdMother
        '
        Me.cmdMother.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.cmdMother.Enabled = False
        Me.cmdMother.Location = New System.Drawing.Point(579, 355)
        Me.cmdMother.Name = "cmdMother"
        Me.cmdMother.Size = New System.Drawing.Size(48, 20)
        Me.cmdMother.TabIndex = 284
        Me.cmdMother.TabStop = False
        Me.cmdMother.Text = "Mother"
        Me.cmdMother.UseVisualStyleBackColor = False
        Me.cmdMother.Visible = False
        '
        'cmdList
        '
        Me.cmdList.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.cmdList.Enabled = False
        Me.cmdList.Location = New System.Drawing.Point(137, 350)
        Me.cmdList.Name = "cmdList"
        Me.cmdList.Size = New System.Drawing.Size(31, 20)
        Me.cmdList.TabIndex = 283
        Me.cmdList.TabStop = False
        Me.cmdList.Text = "List"
        Me.cmdList.UseVisualStyleBackColor = False
        Me.cmdList.Visible = False
        '
        'obj_Asset_barcodeinduk
        '
        Me.obj_Asset_barcodeinduk.Location = New System.Drawing.Point(466, 356)
        Me.obj_Asset_barcodeinduk.MaxLength = 20
        Me.obj_Asset_barcodeinduk.Name = "obj_Asset_barcodeinduk"
        Me.obj_Asset_barcodeinduk.ReadOnly = True
        Me.obj_Asset_barcodeinduk.Size = New System.Drawing.Size(109, 20)
        Me.obj_Asset_barcodeinduk.TabIndex = 281
        Me.obj_Asset_barcodeinduk.TabStop = False
        Me.obj_Asset_barcodeinduk.Visible = False
        '
        'lbl_Asset_barcodeinduk
        '
        Me.lbl_Asset_barcodeinduk.AutoSize = True
        Me.lbl_Asset_barcodeinduk.Location = New System.Drawing.Point(383, 359)
        Me.lbl_Asset_barcodeinduk.Name = "lbl_Asset_barcodeinduk"
        Me.lbl_Asset_barcodeinduk.Size = New System.Drawing.Size(83, 13)
        Me.lbl_Asset_barcodeinduk.TabIndex = 280
        Me.lbl_Asset_barcodeinduk.Text = "Barcode Mother"
        Me.lbl_Asset_barcodeinduk.Visible = False
        '
        'obj_Is_useable
        '
        Me.obj_Is_useable.AutoSize = True
        Me.obj_Is_useable.Enabled = False
        Me.obj_Is_useable.Location = New System.Drawing.Point(116, 353)
        Me.obj_Is_useable.Name = "obj_Is_useable"
        Me.obj_Is_useable.Size = New System.Drawing.Size(15, 14)
        Me.obj_Is_useable.TabIndex = 277
        Me.obj_Is_useable.TabStop = False
        Me.obj_Is_useable.UseVisualStyleBackColor = True
        Me.obj_Is_useable.Visible = False
        '
        'lbl_Is_useable
        '
        Me.lbl_Is_useable.AutoSize = True
        Me.lbl_Is_useable.Location = New System.Drawing.Point(11, 353)
        Me.lbl_Is_useable.Name = "lbl_Is_useable"
        Me.lbl_Is_useable.Size = New System.Drawing.Size(72, 13)
        Me.lbl_Is_useable.TabIndex = 282
        Me.lbl_Is_useable.Text = "Non Fix Asset"
        Me.lbl_Is_useable.Visible = False
        '
        'obj_Asset_barcode
        '
        Me.obj_Asset_barcode.Location = New System.Drawing.Point(116, 373)
        Me.obj_Asset_barcode.MaxLength = 20
        Me.obj_Asset_barcode.Name = "obj_Asset_barcode"
        Me.obj_Asset_barcode.ReadOnly = True
        Me.obj_Asset_barcode.Size = New System.Drawing.Size(152, 20)
        Me.obj_Asset_barcode.TabIndex = 262
        Me.obj_Asset_barcode.Visible = False
        '
        'lbl_Asset_barcode
        '
        Me.lbl_Asset_barcode.AutoSize = True
        Me.lbl_Asset_barcode.Location = New System.Drawing.Point(11, 373)
        Me.lbl_Asset_barcode.Name = "lbl_Asset_barcode"
        Me.lbl_Asset_barcode.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Asset_barcode.TabIndex = 278
        Me.lbl_Asset_barcode.Text = "Barcode"
        Me.lbl_Asset_barcode.Visible = False
        '
        'obj_asset_usedby
        '
        Me.obj_asset_usedby.Location = New System.Drawing.Point(393, 306)
        Me.obj_asset_usedby.MaxLength = 50
        Me.obj_asset_usedby.Name = "obj_asset_usedby"
        Me.obj_asset_usedby.ReadOnly = True
        Me.obj_asset_usedby.Size = New System.Drawing.Size(111, 20)
        Me.obj_asset_usedby.TabIndex = 344
        Me.obj_asset_usedby.TabStop = False
        Me.obj_asset_usedby.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(349, 309)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 343
        Me.Label7.Text = "Usedby"
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(195, 331)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 341
        Me.Label6.Text = "Editdt"
        Me.Label6.Visible = False
        '
        'obj_asset_editdt
        '
        Me.obj_asset_editdt.Location = New System.Drawing.Point(235, 328)
        Me.obj_asset_editdt.MaxLength = 2
        Me.obj_asset_editdt.Name = "obj_asset_editdt"
        Me.obj_asset_editdt.ReadOnly = True
        Me.obj_asset_editdt.Size = New System.Drawing.Size(97, 20)
        Me.obj_asset_editdt.TabIndex = 342
        Me.obj_asset_editdt.TabStop = False
        Me.obj_asset_editdt.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 331)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 339
        Me.Label5.Text = "Editby"
        Me.Label5.Visible = False
        '
        'obj_asset_editby
        '
        Me.obj_asset_editby.Location = New System.Drawing.Point(62, 328)
        Me.obj_asset_editby.MaxLength = 50
        Me.obj_asset_editby.Name = "obj_asset_editby"
        Me.obj_asset_editby.ReadOnly = True
        Me.obj_asset_editby.Size = New System.Drawing.Size(122, 20)
        Me.obj_asset_editby.TabIndex = 340
        Me.obj_asset_editby.TabStop = False
        Me.obj_asset_editby.Visible = False
        '
        'obj_asset_inputdt
        '
        Me.obj_asset_inputdt.Location = New System.Drawing.Point(235, 306)
        Me.obj_asset_inputdt.MaxLength = 2
        Me.obj_asset_inputdt.Name = "obj_asset_inputdt"
        Me.obj_asset_inputdt.ReadOnly = True
        Me.obj_asset_inputdt.Size = New System.Drawing.Size(97, 20)
        Me.obj_asset_inputdt.TabIndex = 338
        Me.obj_asset_inputdt.TabStop = False
        Me.obj_asset_inputdt.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 309)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 335
        Me.Label3.Text = "Inputby"
        Me.Label3.Visible = False
        '
        'obj_asset_inputby
        '
        Me.obj_asset_inputby.Location = New System.Drawing.Point(62, 306)
        Me.obj_asset_inputby.MaxLength = 50
        Me.obj_asset_inputby.Name = "obj_asset_inputby"
        Me.obj_asset_inputby.ReadOnly = True
        Me.obj_asset_inputby.Size = New System.Drawing.Size(122, 20)
        Me.obj_asset_inputby.TabIndex = 336
        Me.obj_asset_inputby.TabStop = False
        Me.obj_asset_inputby.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(195, 309)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 337
        Me.Label4.Text = "Inputdt"
        Me.Label4.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(304, 39)
        Me.TextBox1.MaxLength = 2
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(166, 20)
        Me.TextBox1.TabIndex = 21
        Me.TextBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(251, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Editdt"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(251, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Editby"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(304, 13)
        Me.TextBox2.MaxLength = 16
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(166, 20)
        Me.TextBox2.TabIndex = 20
        Me.TextBox2.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Inputdt"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(61, 39)
        Me.TextBox3.MaxLength = 2
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(166, 20)
        Me.TextBox3.TabIndex = 19
        Me.TextBox3.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Inputby"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(61, 13)
        Me.TextBox4.MaxLength = 16
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(166, 20)
        Me.TextBox4.TabIndex = 18
        Me.TextBox4.TabStop = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(549, 13)
        Me.TextBox5.MaxLength = 16
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(166, 20)
        Me.TextBox5.TabIndex = 22
        Me.TextBox5.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(492, 42)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Useddt"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(549, 39)
        Me.TextBox6.MaxLength = 2
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(166, 20)
        Me.TextBox6.TabIndex = 23
        Me.TextBox6.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(492, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Usedby"
        '
        'uiTrnTerimaJasa1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiTrnTerimaJasa1"
        Me.Size = New System.Drawing.Size(781, 574)
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        Me.PnlDfMain.PerformLayout()
        CType(Me.DgvTrnTerimajasa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfFooter.ResumeLayout(False)
        Me.PnlDfFooter.PerformLayout()
        CType(Me.obj_top, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Detil.ResumeLayout(False)
        CType(Me.DgvTrnTerimajasadetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ftabDataDetil_Amount.ResumeLayout(False)
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
        Me.ftabDataDetil_UserManagement.ResumeLayout(False)
        Me.ftabDataDetil_UserManagement.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.FTabItem.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
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
    Friend WithEvents DgvTrnTerimajasadetil As System.Windows.Forms.DataGridView
    Friend WithEvents obj_Channel_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Channel_id_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Terimajasa_id_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Terimajasa_id_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Terimajasa_tgl_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Terimajasa_tgl_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Terimajasa_status_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Terimajasa_status_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Order_id_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Order_id_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Pa_ref_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Pa_ref_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Rekanan_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Rekanan_id_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Terimajasa_appacc_search As System.Windows.Forms.CheckBox
    'Friend WithEvents chk_Terimajasa_appacc_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Employee_id_pemilik_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Employee_id_pemilik_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Strukturunit_id_pemilik_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Strukturunit_id_pemilik_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Accounting_applogin_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Accounting_applogin_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Accounting_appdt_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Accounting_appdt_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Terimajasa_appprc_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Terimajasa_appprc_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Procurement_applogin_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Procurement_applogin_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Procurement_appdt_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Procurement_appdt_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Terimajasa_cetakbpb_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Terimajasa_cetakbpb_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Terimajasa_cetakbkb_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Terimajasa_cetakbkb_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Terimajasa_item_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Terimajasa_item_search As System.Windows.Forms.CheckBox
    ''Friend WithEvents obj_Inputby_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Inputby_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Inputdt_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Inputdt_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Editby_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Editby_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Editdt_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Editdt_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Usedby_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Usedby_search As System.Windows.Forms.CheckBox
    'Friend WithEvents obj_Useddt_search As System.Windows.Forms.TextBox
    'Friend WithEvents chk_Useddt_search As System.Windows.Forms.CheckBox
    'OBJECT
    Friend WithEvents obj_Channel_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Channel_id As System.Windows.Forms.Label
    Friend WithEvents obj_Terimajasa_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimajasa_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Terimajasa_tgl As System.Windows.Forms.Label
    'DEKLARASI SI TOP
    Friend WithEvents obj_Strukturunit_id_pemilik_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Strukturunit_id_pemilik_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Terimajasa_appbma As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Terimajasa_appacc As System.Windows.Forms.Label
    Friend WithEvents obj_BMA_applogin As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Accounting_applogin As System.Windows.Forms.Label
    Friend WithEvents obj_BMA_appdt As System.Windows.Forms.TextBox
    Friend WithEvents obj_Terimajasa_appprc As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Terimajasa_appprc As System.Windows.Forms.Label
    Friend WithEvents obj_Procurement_applogin As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Procurement_applogin As System.Windows.Forms.Label
    Friend WithEvents obj_Procurement_appdt As System.Windows.Forms.TextBox
    Friend WithEvents obj_Terimajasa_cetakbpb As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimajasa_cetakbpb As System.Windows.Forms.Label
    Friend WithEvents obj_Terimajasa_cetakbkb As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimajasa_cetakbkb As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents obj_Terimajasa_item As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Terimajasa_item As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents obj_Terimajasa_tgl As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents obj_Terimajasa_status As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Employee_id_pemilik As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Strukturunit_id_pemilik As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Terimajasa_status As System.Windows.Forms.Label
    Friend WithEvents lbl_Order_id As System.Windows.Forms.Label
    Friend WithEvents obj_Pa_ref As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Pa_ref As System.Windows.Forms.Label
    Friend WithEvents obj_Rekanan_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Rekanan_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Employee_id_pemilik As System.Windows.Forms.Label
    Friend WithEvents lbl_Strukturunit_id_pemilik As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DgvTrnTerimajasa As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_Terimajasa_appuser As System.Windows.Forms.Label
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents obj_Qty_PO As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Qty_PO As System.Windows.Forms.Label
    Friend WithEvents Obj_Qty_Mother As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Qty_Mother As System.Windows.Forms.Label
    Friend WithEvents obj_Terimajasa_appuser As System.Windows.Forms.CheckBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Btn_Add As System.Windows.Forms.Button
    Friend WithEvents ftabDataDetil_Amount As System.Windows.Forms.TabPage
    Friend WithEvents obj_Asset_valas_header As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_idrprice_header As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents obj_Currency_id_header As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_harga_header As System.Windows.Forms.TextBox
    Friend WithEvents obj_Asset_ppn_header As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_pph_header As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_disc_header As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_Insurance_header As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_Other_header As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_Operator_header As System.Windows.Forms.TextBox
    Friend WithEvents obj_USer_applogin As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents obj_User_appdt As System.Windows.Forms.TextBox
    Friend WithEvents obj_Status As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Terimajasa_type As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_Transport_header As System.Windows.Forms.TextBox
    Friend WithEvents obj_Terimajasa_location As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmb_appuser As System.Windows.Forms.ComboBox
    Friend WithEvents chk_User_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Notes As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btn_bonus As System.Windows.Forms.Button
    Friend WithEvents ftabDataDetil_UserManagement As System.Windows.Forms.TabPage
    Friend WithEvents obj_Usedby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Useddt As System.Windows.Forms.Label
    Friend WithEvents obj_Useddt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Usedby As System.Windows.Forms.Label
    Friend WithEvents obj_Editdt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Editdt As System.Windows.Forms.Label
    Friend WithEvents lbl_Editby As System.Windows.Forms.Label
    Friend WithEvents obj_Editby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Inputdt As System.Windows.Forms.Label
    Friend WithEvents obj_Inputdt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Inputby As System.Windows.Forms.Label
    Friend WithEvents obj_Inputby As System.Windows.Forms.TextBox
    Friend WithEvents FTabItem As FlatTabControl.FlatTabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents obj_Asset_golfiskal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_golfiskal As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_idrprice As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_idrprice As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_ppn As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_ppn As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_pph As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_pph As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_tipedepre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_tipedepre As System.Windows.Forms.Label
    Friend WithEvents obj_shadow_tipedepre As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Asset_valas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_valas As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_disc As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_disc As System.Windows.Forms.Label
    Friend WithEvents obj_Currency_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Currency_id As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_harga As System.Windows.Forms.TextBox
    Friend WithEvents obj_Asset_active As System.Windows.Forms.CheckBox
    Friend WithEvents obj_asset_depre_enddt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_active As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_depresiasi As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_depresiasi As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_akum_val_depre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_akum_val_depre As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_hargabaru As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_hargabaru As System.Windows.Forms.Label
    Friend WithEvents obj_asset_Terimajasa_id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_line As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_line As System.Windows.Forms.Label
    Friend WithEvents Obj_asset_channel_id As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents obj_Tipeasset_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Tipeasset_id As System.Windows.Forms.Label
    Friend WithEvents obj_orderdetil_line As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents obj_Order_idDetil As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_tgl As System.Windows.Forms.MaskedTextBox
    Friend WithEvents obj_Asset_deskripsi As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_deskripsi As System.Windows.Forms.Label
    Friend WithEvents obj_Kategoriitem_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Kategoriasset_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Kategoriasset_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Kategoriitem_id As System.Windows.Forms.Label
    Friend WithEvents obj_Tipeitem_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Tipeitem_id As System.Windows.Forms.Label
    Friend WithEvents obj_Brand_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Brand_id As System.Windows.Forms.Label
    Friend WithEvents obj_Unit_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Asset_qty As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_qty As System.Windows.Forms.Label
    Friend WithEvents lbl_Asset_tgl As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_serial As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_serial As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_produknumber As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_produknumber As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_model As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_model As System.Windows.Forms.Label
    Friend WithEvents Obj_asset_No_budget As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Show As System.Windows.Forms.Button
    Friend WithEvents Btn_Room As System.Windows.Forms.Button
    Friend WithEvents Btn_Color As System.Windows.Forms.Button
    Friend WithEvents Btn_Material As System.Windows.Forms.Button
    Friend WithEvents obj_Show_id_cont_item As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Jeniskelamin_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Show_id_cont_item As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_status As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_status As System.Windows.Forms.Label
    Friend WithEvents obj_Wo_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Wo_id As System.Windows.Forms.Label
    Friend WithEvents obj_Strukturunit_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Strukturunit_id As System.Windows.Forms.Label
    Friend WithEvents obj_Employee_id_owner As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Employee_id_owner As System.Windows.Forms.Label
    Friend WithEvents lbl_Jeniskelamin_id As System.Windows.Forms.Label
    Friend WithEvents obj_Ruang_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Ruang_id As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_rak As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_rak As System.Windows.Forms.Label
    Friend WithEvents obj_Project_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Project_id As System.Windows.Forms.Label
    Friend WithEvents obj_Show_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Show_id As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_eps As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_eps As System.Windows.Forms.Label
    Friend WithEvents obj_Material_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Material_id As System.Windows.Forms.Label
    Friend WithEvents obj_Warna_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Warna_id As System.Windows.Forms.Label
    Friend WithEvents obj_Ukuran_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Ukuran_id As System.Windows.Forms.Label
    Friend WithEvents cmdMother As System.Windows.Forms.Button
    Friend WithEvents cmdList As System.Windows.Forms.Button
    Friend WithEvents obj_Asset_barcodeinduk As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_barcodeinduk As System.Windows.Forms.Label
    Friend WithEvents obj_Is_useable As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Is_useable As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_barcode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_barcode As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_lineinduk As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_lineinduk As System.Windows.Forms.Label
    Friend WithEvents obj_asset_usedby As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents obj_asset_editdt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents obj_asset_editby As System.Windows.Forms.TextBox
    Friend WithEvents obj_asset_inputdt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents obj_asset_inputby As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Btn_Category As System.Windows.Forms.Button
    Friend WithEvents Btn_Type As System.Windows.Forms.Button
    Friend WithEvents Btn_Brand As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents obj_Status_kedatangan_barang As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents btn_DeleteItem As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents obj_terimajasa_noSuratJalan As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents obj_top As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents btn_order As System.Windows.Forms.Button
    Friend WithEvents obj_Order_id As System.Windows.Forms.TextBox
    Friend WithEvents obj_orderID_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_orderID_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_RvID_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_RvID_search As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
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
    Friend WithEvents Panel6 As System.Windows.Forms.Panel

End Class