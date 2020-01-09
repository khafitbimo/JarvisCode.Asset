<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnDepresiasi_ageChanges
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
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvMstAsset = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.txtSearchBarcode = New System.Windows.Forms.TextBox
        Me.chkSearchBarcode = New System.Windows.Forms.CheckBox
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox
        Me.cboSearchkategori = New System.Windows.Forms.ComboBox
        Me.chkSearchCategory = New System.Windows.Forms.CheckBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.obj_Asset_akum_val_depre = New System.Windows.Forms.TextBox
        Me.lbl_Asset_idrprice = New System.Windows.Forms.Label
        Me.obj_Asset_idrprice = New System.Windows.Forms.TextBox
        Me.obj_Asset_active = New System.Windows.Forms.CheckBox
        Me.obj_Currency_id = New System.Windows.Forms.ComboBox
        Me.lbl_Asset_valas = New System.Windows.Forms.Label
        Me.obj_Terimabarang_id = New System.Windows.Forms.TextBox
        Me.obj_Asset_valas = New System.Windows.Forms.TextBox
        Me.lbl_Terimabarang_id = New System.Windows.Forms.Label
        Me.lbl_Asset_akum_val_depre = New System.Windows.Forms.Label
        Me.obj_Channel_id = New System.Windows.Forms.TextBox
        Me.lbl_Asset_depresiasi = New System.Windows.Forms.Label
        Me.lbl_Channel_id = New System.Windows.Forms.Label
        Me.obj_Asset_depresiasi = New System.Windows.Forms.TextBox
        Me.obj_Kategoriasset_id = New System.Windows.Forms.TextBox
        Me.lbl_Asset_hargabaru = New System.Windows.Forms.Label
        Me.lbl_Kategoriasset_id = New System.Windows.Forms.Label
        Me.obj_Asset_hargabaru = New System.Windows.Forms.TextBox
        Me.obj_Asset_barcode = New System.Windows.Forms.TextBox
        Me.lbl_Currency_id = New System.Windows.Forms.Label
        Me.lbl_Asset_barcode = New System.Windows.Forms.Label
        Me.lbl_Asset_deskripsi = New System.Windows.Forms.Label
        Me.obj_Asset_deskripsi = New System.Windows.Forms.TextBox
        Me.obj_Asset_eddepre = New System.Windows.Forms.DateTimePicker
        Me.obj_Asset_stdepre = New System.Windows.Forms.DateTimePicker
        Me.obj_Asset_deprebulanan = New System.Windows.Forms.TextBox
        Me.lbl_Asset_deprebulanan = New System.Windows.Forms.Label
        Me.lbl_Asset_stdepre = New System.Windows.Forms.Label
        Me.lbl_Asset_eddepre = New System.Windows.Forms.Label
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvMstAsset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(3, 28)
        Me.ftabMain.myBackColor = System.Drawing.Color.White
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.White
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_List.Controls.Add(Me.PnlDfFooter)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvMstAsset)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 131)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 296)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvMstAsset
        '
        Me.DgvMstAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMstAsset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMstAsset.Location = New System.Drawing.Point(0, 0)
        Me.DgvMstAsset.Name = "DgvMstAsset"
        Me.DgvMstAsset.Size = New System.Drawing.Size(704, 296)
        Me.DgvMstAsset.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 446)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 39)
        Me.PnlDfFooter.TabIndex = 2
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.txtSearchBarcode)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchBarcode)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchkategori)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchCategory)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 71)
        Me.PnlDfSearch.TabIndex = 0
        '
        'txtSearchBarcode
        '
        Me.txtSearchBarcode.Location = New System.Drawing.Point(335, 8)
        Me.txtSearchBarcode.Name = "txtSearchBarcode"
        Me.txtSearchBarcode.Size = New System.Drawing.Size(139, 20)
        Me.txtSearchBarcode.TabIndex = 29
        '
        'chkSearchBarcode
        '
        Me.chkSearchBarcode.AutoSize = True
        Me.chkSearchBarcode.ForeColor = System.Drawing.Color.Black
        Me.chkSearchBarcode.Location = New System.Drawing.Point(263, 11)
        Me.chkSearchBarcode.Name = "chkSearchBarcode"
        Me.chkSearchBarcode.Size = New System.Drawing.Size(66, 17)
        Me.chkSearchBarcode.TabIndex = 28
        Me.chkSearchBarcode.Text = "Barcode"
        Me.chkSearchBarcode.UseVisualStyleBackColor = True
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(104, 9)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(121, 21)
        Me.cboSearchChannel.TabIndex = 27
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.ForeColor = System.Drawing.Color.Black
        Me.chkSearchChannel.Location = New System.Drawing.Point(17, 11)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 26
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'cboSearchkategori
        '
        Me.cboSearchkategori.FormattingEnabled = True
        Me.cboSearchkategori.Location = New System.Drawing.Point(104, 36)
        Me.cboSearchkategori.Name = "cboSearchkategori"
        Me.cboSearchkategori.Size = New System.Drawing.Size(370, 21)
        Me.cboSearchkategori.TabIndex = 25
        '
        'chkSearchCategory
        '
        Me.chkSearchCategory.AutoSize = True
        Me.chkSearchCategory.Location = New System.Drawing.Point(17, 38)
        Me.chkSearchCategory.Name = "chkSearchCategory"
        Me.chkSearchCategory.Size = New System.Drawing.Size(68, 17)
        Me.chkSearchCategory.TabIndex = 24
        Me.chkSearchCategory.Text = "Category"
        Me.chkSearchCategory.UseVisualStyleBackColor = True
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.Controls.Add(Me.Panel1)
        Me.PnlDataMaster.Controls.Add(Me.obj_Asset_eddepre)
        Me.PnlDataMaster.Controls.Add(Me.obj_Asset_stdepre)
        Me.PnlDataMaster.Controls.Add(Me.obj_Asset_deprebulanan)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Asset_deprebulanan)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Asset_stdepre)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Asset_eddepre)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 459)
        Me.PnlDataMaster.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.Controls.Add(Me.obj_Asset_akum_val_depre)
        Me.Panel1.Controls.Add(Me.lbl_Asset_idrprice)
        Me.Panel1.Controls.Add(Me.obj_Asset_idrprice)
        Me.Panel1.Controls.Add(Me.obj_Asset_active)
        Me.Panel1.Controls.Add(Me.obj_Currency_id)
        Me.Panel1.Controls.Add(Me.lbl_Asset_valas)
        Me.Panel1.Controls.Add(Me.obj_Terimabarang_id)
        Me.Panel1.Controls.Add(Me.obj_Asset_valas)
        Me.Panel1.Controls.Add(Me.lbl_Terimabarang_id)
        Me.Panel1.Controls.Add(Me.lbl_Asset_akum_val_depre)
        Me.Panel1.Controls.Add(Me.obj_Channel_id)
        Me.Panel1.Controls.Add(Me.lbl_Asset_depresiasi)
        Me.Panel1.Controls.Add(Me.lbl_Channel_id)
        Me.Panel1.Controls.Add(Me.obj_Asset_depresiasi)
        Me.Panel1.Controls.Add(Me.obj_Kategoriasset_id)
        Me.Panel1.Controls.Add(Me.lbl_Asset_hargabaru)
        Me.Panel1.Controls.Add(Me.lbl_Kategoriasset_id)
        Me.Panel1.Controls.Add(Me.obj_Asset_hargabaru)
        Me.Panel1.Controls.Add(Me.obj_Asset_barcode)
        Me.Panel1.Controls.Add(Me.lbl_Currency_id)
        Me.Panel1.Controls.Add(Me.lbl_Asset_barcode)
        Me.Panel1.Controls.Add(Me.lbl_Asset_deskripsi)
        Me.Panel1.Controls.Add(Me.obj_Asset_deskripsi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(733, 211)
        Me.Panel1.TabIndex = 46
        '
        'obj_Asset_akum_val_depre
        '
        Me.obj_Asset_akum_val_depre.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_akum_val_depre.Location = New System.Drawing.Point(449, 180)
        Me.obj_Asset_akum_val_depre.Name = "obj_Asset_akum_val_depre"
        Me.obj_Asset_akum_val_depre.ReadOnly = True
        Me.obj_Asset_akum_val_depre.Size = New System.Drawing.Size(130, 20)
        Me.obj_Asset_akum_val_depre.TabIndex = 1
        '
        'lbl_Asset_idrprice
        '
        Me.lbl_Asset_idrprice.AutoSize = True
        Me.lbl_Asset_idrprice.Location = New System.Drawing.Point(22, 182)
        Me.lbl_Asset_idrprice.Name = "lbl_Asset_idrprice"
        Me.lbl_Asset_idrprice.Size = New System.Drawing.Size(43, 13)
        Me.lbl_Asset_idrprice.TabIndex = 0
        Me.lbl_Asset_idrprice.Text = "Amount"
        '
        'obj_Asset_idrprice
        '
        Me.obj_Asset_idrprice.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_idrprice.Location = New System.Drawing.Point(127, 179)
        Me.obj_Asset_idrprice.Name = "obj_Asset_idrprice"
        Me.obj_Asset_idrprice.ReadOnly = True
        Me.obj_Asset_idrprice.Size = New System.Drawing.Size(130, 20)
        Me.obj_Asset_idrprice.TabIndex = 1
        '
        'obj_Asset_active
        '
        Me.obj_Asset_active.AutoSize = True
        Me.obj_Asset_active.Enabled = False
        Me.obj_Asset_active.Location = New System.Drawing.Point(643, 183)
        Me.obj_Asset_active.Name = "obj_Asset_active"
        Me.obj_Asset_active.Size = New System.Drawing.Size(64, 17)
        Me.obj_Asset_active.TabIndex = 2
        Me.obj_Asset_active.Text = "IsActive"
        Me.obj_Asset_active.UseVisualStyleBackColor = True
        '
        'obj_Currency_id
        '
        Me.obj_Currency_id.Enabled = False
        Me.obj_Currency_id.FormattingEnabled = True
        Me.obj_Currency_id.Location = New System.Drawing.Point(127, 129)
        Me.obj_Currency_id.Name = "obj_Currency_id"
        Me.obj_Currency_id.Size = New System.Drawing.Size(100, 21)
        Me.obj_Currency_id.TabIndex = 28
        '
        'lbl_Asset_valas
        '
        Me.lbl_Asset_valas.AutoSize = True
        Me.lbl_Asset_valas.Location = New System.Drawing.Point(22, 157)
        Me.lbl_Asset_valas.Name = "lbl_Asset_valas"
        Me.lbl_Asset_valas.Size = New System.Drawing.Size(30, 13)
        Me.lbl_Asset_valas.TabIndex = 0
        Me.lbl_Asset_valas.Text = "Rate"
        '
        'obj_Terimabarang_id
        '
        Me.obj_Terimabarang_id.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Terimabarang_id.Location = New System.Drawing.Point(127, 24)
        Me.obj_Terimabarang_id.Name = "obj_Terimabarang_id"
        Me.obj_Terimabarang_id.ReadOnly = True
        Me.obj_Terimabarang_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Terimabarang_id.TabIndex = 1
        '
        'obj_Asset_valas
        '
        Me.obj_Asset_valas.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_valas.Location = New System.Drawing.Point(127, 154)
        Me.obj_Asset_valas.Name = "obj_Asset_valas"
        Me.obj_Asset_valas.ReadOnly = True
        Me.obj_Asset_valas.Size = New System.Drawing.Size(100, 20)
        Me.obj_Asset_valas.TabIndex = 1
        '
        'lbl_Terimabarang_id
        '
        Me.lbl_Terimabarang_id.AutoSize = True
        Me.lbl_Terimabarang_id.Location = New System.Drawing.Point(21, 24)
        Me.lbl_Terimabarang_id.Name = "lbl_Terimabarang_id"
        Me.lbl_Terimabarang_id.Size = New System.Drawing.Size(86, 13)
        Me.lbl_Terimabarang_id.TabIndex = 0
        Me.lbl_Terimabarang_id.Text = "Terimabarang ID"
        '
        'lbl_Asset_akum_val_depre
        '
        Me.lbl_Asset_akum_val_depre.AutoSize = True
        Me.lbl_Asset_akum_val_depre.Location = New System.Drawing.Point(312, 184)
        Me.lbl_Asset_akum_val_depre.Name = "lbl_Asset_akum_val_depre"
        Me.lbl_Asset_akum_val_depre.Size = New System.Drawing.Size(119, 13)
        Me.lbl_Asset_akum_val_depre.TabIndex = 0
        Me.lbl_Asset_akum_val_depre.Text = "Amount Depresiasi Sum"
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Channel_id.Location = New System.Drawing.Point(449, 25)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.ReadOnly = True
        Me.obj_Channel_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Channel_id.TabIndex = 1
        '
        'lbl_Asset_depresiasi
        '
        Me.lbl_Asset_depresiasi.AutoSize = True
        Me.lbl_Asset_depresiasi.Location = New System.Drawing.Point(312, 158)
        Me.lbl_Asset_depresiasi.Name = "lbl_Asset_depresiasi"
        Me.lbl_Asset_depresiasi.Size = New System.Drawing.Size(87, 13)
        Me.lbl_Asset_depresiasi.TabIndex = 0
        Me.lbl_Asset_depresiasi.Text = "Depresiasi Times"
        '
        'lbl_Channel_id
        '
        Me.lbl_Channel_id.AutoSize = True
        Me.lbl_Channel_id.Location = New System.Drawing.Point(312, 25)
        Me.lbl_Channel_id.Name = "lbl_Channel_id"
        Me.lbl_Channel_id.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Channel_id.TabIndex = 0
        Me.lbl_Channel_id.Text = "Channel ID"
        '
        'obj_Asset_depresiasi
        '
        Me.obj_Asset_depresiasi.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_depresiasi.Location = New System.Drawing.Point(449, 155)
        Me.obj_Asset_depresiasi.Name = "obj_Asset_depresiasi"
        Me.obj_Asset_depresiasi.ReadOnly = True
        Me.obj_Asset_depresiasi.Size = New System.Drawing.Size(100, 20)
        Me.obj_Asset_depresiasi.TabIndex = 1
        '
        'obj_Kategoriasset_id
        '
        Me.obj_Kategoriasset_id.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Kategoriasset_id.Location = New System.Drawing.Point(127, 50)
        Me.obj_Kategoriasset_id.Name = "obj_Kategoriasset_id"
        Me.obj_Kategoriasset_id.ReadOnly = True
        Me.obj_Kategoriasset_id.Size = New System.Drawing.Size(130, 20)
        Me.obj_Kategoriasset_id.TabIndex = 1
        '
        'lbl_Asset_hargabaru
        '
        Me.lbl_Asset_hargabaru.AutoSize = True
        Me.lbl_Asset_hargabaru.Location = New System.Drawing.Point(312, 133)
        Me.lbl_Asset_hargabaru.Name = "lbl_Asset_hargabaru"
        Me.lbl_Asset_hargabaru.Size = New System.Drawing.Size(117, 13)
        Me.lbl_Asset_hargabaru.TabIndex = 0
        Me.lbl_Asset_hargabaru.Text = "Amount after depresiasi"
        '
        'lbl_Kategoriasset_id
        '
        Me.lbl_Kategoriasset_id.AutoSize = True
        Me.lbl_Kategoriasset_id.Location = New System.Drawing.Point(21, 50)
        Me.lbl_Kategoriasset_id.Name = "lbl_Kategoriasset_id"
        Me.lbl_Kategoriasset_id.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Kategoriasset_id.TabIndex = 0
        Me.lbl_Kategoriasset_id.Text = "Kategori ID"
        '
        'obj_Asset_hargabaru
        '
        Me.obj_Asset_hargabaru.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_hargabaru.Location = New System.Drawing.Point(449, 130)
        Me.obj_Asset_hargabaru.Name = "obj_Asset_hargabaru"
        Me.obj_Asset_hargabaru.ReadOnly = True
        Me.obj_Asset_hargabaru.Size = New System.Drawing.Size(130, 20)
        Me.obj_Asset_hargabaru.TabIndex = 1
        '
        'obj_Asset_barcode
        '
        Me.obj_Asset_barcode.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_barcode.Location = New System.Drawing.Point(449, 51)
        Me.obj_Asset_barcode.Name = "obj_Asset_barcode"
        Me.obj_Asset_barcode.ReadOnly = True
        Me.obj_Asset_barcode.Size = New System.Drawing.Size(100, 20)
        Me.obj_Asset_barcode.TabIndex = 1
        '
        'lbl_Currency_id
        '
        Me.lbl_Currency_id.AutoSize = True
        Me.lbl_Currency_id.Location = New System.Drawing.Point(21, 132)
        Me.lbl_Currency_id.Name = "lbl_Currency_id"
        Me.lbl_Currency_id.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Currency_id.TabIndex = 0
        Me.lbl_Currency_id.Text = "Currency"
        '
        'lbl_Asset_barcode
        '
        Me.lbl_Asset_barcode.AutoSize = True
        Me.lbl_Asset_barcode.Location = New System.Drawing.Point(312, 51)
        Me.lbl_Asset_barcode.Name = "lbl_Asset_barcode"
        Me.lbl_Asset_barcode.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Asset_barcode.TabIndex = 0
        Me.lbl_Asset_barcode.Text = "Barcode"
        '
        'lbl_Asset_deskripsi
        '
        Me.lbl_Asset_deskripsi.AutoSize = True
        Me.lbl_Asset_deskripsi.Location = New System.Drawing.Point(21, 76)
        Me.lbl_Asset_deskripsi.Name = "lbl_Asset_deskripsi"
        Me.lbl_Asset_deskripsi.Size = New System.Drawing.Size(60, 13)
        Me.lbl_Asset_deskripsi.TabIndex = 0
        Me.lbl_Asset_deskripsi.Text = "Description"
        '
        'obj_Asset_deskripsi
        '
        Me.obj_Asset_deskripsi.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_deskripsi.Location = New System.Drawing.Point(127, 76)
        Me.obj_Asset_deskripsi.Multiline = True
        Me.obj_Asset_deskripsi.Name = "obj_Asset_deskripsi"
        Me.obj_Asset_deskripsi.ReadOnly = True
        Me.obj_Asset_deskripsi.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.obj_Asset_deskripsi.Size = New System.Drawing.Size(452, 47)
        Me.obj_Asset_deskripsi.TabIndex = 1
        '
        'obj_Asset_eddepre
        '
        Me.obj_Asset_eddepre.CustomFormat = "dd/MM/yyyy"
        Me.obj_Asset_eddepre.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Asset_eddepre.Location = New System.Drawing.Point(449, 243)
        Me.obj_Asset_eddepre.Name = "obj_Asset_eddepre"
        Me.obj_Asset_eddepre.Size = New System.Drawing.Size(130, 20)
        Me.obj_Asset_eddepre.TabIndex = 45
        '
        'obj_Asset_stdepre
        '
        Me.obj_Asset_stdepre.CustomFormat = "dd/MM/yyyy"
        Me.obj_Asset_stdepre.Enabled = False
        Me.obj_Asset_stdepre.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Asset_stdepre.Location = New System.Drawing.Point(449, 220)
        Me.obj_Asset_stdepre.Name = "obj_Asset_stdepre"
        Me.obj_Asset_stdepre.Size = New System.Drawing.Size(130, 20)
        Me.obj_Asset_stdepre.TabIndex = 44
        '
        'obj_Asset_deprebulanan
        '
        Me.obj_Asset_deprebulanan.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Asset_deprebulanan.Location = New System.Drawing.Point(127, 221)
        Me.obj_Asset_deprebulanan.Name = "obj_Asset_deprebulanan"
        Me.obj_Asset_deprebulanan.ReadOnly = True
        Me.obj_Asset_deprebulanan.Size = New System.Drawing.Size(130, 20)
        Me.obj_Asset_deprebulanan.TabIndex = 1
        '
        'lbl_Asset_deprebulanan
        '
        Me.lbl_Asset_deprebulanan.AutoSize = True
        Me.lbl_Asset_deprebulanan.Location = New System.Drawing.Point(21, 224)
        Me.lbl_Asset_deprebulanan.Name = "lbl_Asset_deprebulanan"
        Me.lbl_Asset_deprebulanan.Size = New System.Drawing.Size(97, 13)
        Me.lbl_Asset_deprebulanan.TabIndex = 0
        Me.lbl_Asset_deprebulanan.Text = "Depresiasi / Month"
        '
        'lbl_Asset_stdepre
        '
        Me.lbl_Asset_stdepre.AutoSize = True
        Me.lbl_Asset_stdepre.Location = New System.Drawing.Point(312, 224)
        Me.lbl_Asset_stdepre.Name = "lbl_Asset_stdepre"
        Me.lbl_Asset_stdepre.Size = New System.Drawing.Size(81, 13)
        Me.lbl_Asset_stdepre.TabIndex = 0
        Me.lbl_Asset_stdepre.Text = "Start Depresiasi"
        '
        'lbl_Asset_eddepre
        '
        Me.lbl_Asset_eddepre.AutoSize = True
        Me.lbl_Asset_eddepre.Location = New System.Drawing.Point(312, 247)
        Me.lbl_Asset_eddepre.Name = "lbl_Asset_eddepre"
        Me.lbl_Asset_eddepre.Size = New System.Drawing.Size(78, 13)
        Me.lbl_Asset_eddepre.TabIndex = 0
        Me.lbl_Asset_eddepre.Text = "End Depresiasi"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 462)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 23)
        Me.PnlDataFooter.TabIndex = 2
        '
        'uiTrnDepresiasi_ageChanges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiTrnDepresiasi_ageChanges"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvMstAsset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents DgvMstAsset As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Terimabarang_id As System.Windows.Forms.Label
    Friend WithEvents obj_Terimabarang_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Channel_id As System.Windows.Forms.Label
    Friend WithEvents obj_Channel_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Kategoriasset_id As System.Windows.Forms.Label
    Friend WithEvents obj_Kategoriasset_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_barcode As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_barcode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_deskripsi As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_deskripsi As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Currency_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Asset_hargabaru As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_hargabaru As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_depresiasi As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_depresiasi As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_akum_val_depre As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_akum_val_depre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_valas As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_valas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_idrprice As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_idrprice As System.Windows.Forms.TextBox
    Friend WithEvents obj_Asset_active As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Asset_deprebulanan As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_deprebulanan As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_stdepre As System.Windows.Forms.Label
    Friend WithEvents lbl_Asset_eddepre As System.Windows.Forms.Label
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchkategori As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchCategory As System.Windows.Forms.CheckBox
    Friend WithEvents txtSearchBarcode As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchBarcode As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Currency_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Asset_eddepre As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_Asset_stdepre As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class

