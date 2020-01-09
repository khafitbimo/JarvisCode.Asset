
Public Class UiMstAsset
    Private Const mUiName As String = "Master Asset"
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

    Private tbl_MstAsset As DataTable = clsDataset.CreateTblMstAsset(_CHANNEL)
    Private tbl_MstAsset_Temp As DataTable = clsDataset.CreateTblMstAsset(_CHANNEL)

    Private tbl_MstChannel As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstPilihanStatusAsset As DataTable = clsDataset.CreateTblMstPilihan()

    'bagian Struktur unit coy
    Private tbl_MstStrukturunitPemilik As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_MstStrukturunitPengguna As DataTable = clsDataset.CreateTblStrukturunitPengguna()
    Private tbl_Mstemployeepemeriksa As DataTable = clsDataset.CreateTblemployeepemeriksa()
    Private tbl_Mstemployeepemilik As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_MstemployeePengguna As DataTable = clsDataset.CreateTblemployeePengguna()
    'bagian vendor
    Private tbl_Mstrekananterimabarang As DataTable = clsDataset.CreateTblVendor2()

    'untuk bagian asset
    Private tbl_MstStrukturunitAsset As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_MstTipeAsset As DataTable = clsDataset.CreateTblMstTipeasset
    Private tbl_mstKategoriAsset As DataTable = clsDataset.CreateTblMstKategoriasset
    Private tbl_mstKategoriitem As DataTable = clsDataset.CreateTblMstKategoriitem
    Private tbl_msttipeitem As DataTable = clsDataset.CreateTblMstTipeitem
    Private tbl_Mstsex As DataTable = clsDataset.CreateTblMstPilihan()

    Private tbl_Mstwarna As DataTable = clsDataset.CreateTblMstWarna
    Private tbl_Mstmaterial As DataTable = clsDataset.CreateTblMstMaterial
    Private tbl_MstCurrency As DataTable = clsDataset.CreateTblMstCurrency
    Private tbl_Mstowner As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_brand As DataTable = clsDataset.CreateTblMstMerk
    Private tbl_unit As DataTable = clsDataset.CreateTblMstUnit
    Private tbl_ukuran As DataTable = clsDataset.CreateTblMstUkuran
    Private tbl_MstAssetruang As DataTable = clsDataset.CreateTblMstRuangAsset
    Private tbl_showcont As DataTable = clsDataset.CreateTblMstShow


    Private nonFix As Integer

    Friend WithEvents btnAddPicture As ToolStripButton = New ToolStripButton
    Friend WithEvents btnAsk As ToolStripButton = New ToolStripButton

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
        nonFix = 1
        If Me.ftabMain.SelectedIndex = 0 Then
            Me.ftabMain.SelectedIndex = 1
        End If
        Me.obj_Asset_barcode.ReadOnly = False
        Me.UiMstAsset_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function
    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstAsset_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Public Overrides Function btnSave_Click() As Boolean
        If Me.UiMstAsset_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstAsset_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstAsset_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function
    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstAsset_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function
    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstAsset_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function
    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstAsset_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function
    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstAsset_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function
    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstAsset_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

#End Region
#Region " Additional Overrides "
    Private Sub btnAddPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPicture.Click
        addPicture()
    End Sub

    Private Sub btnAsk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAsk.Click
        'Me.ask()
        Me.cek_data()
    End Sub


#End Region
#Region " Layout & Init UI "

    Private Function FormatDgvMstAsset(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_tgl As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTipeasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategoriasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_lineinduk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_barcodeinduk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_serial As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_produknumber As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_model As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_deskripsi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategoriitem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTipeitem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_golfiskal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_tipedepre As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_depre_enddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_harga As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_hargabaru As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_disc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_depresiasi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_akum_val_depre As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_valas As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_idrprice As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_owner As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBrand_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaterial_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWarna_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUkuran_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJeniskelamin_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id_cont_item As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRuang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_rak As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIs_useable As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_active As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cProject_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWo_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWo_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cInputby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cInputdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEditby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEditdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUsedby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_deprebulanan As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_stdepre As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_eddepre As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBrand_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cProject_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cGolongan_pajak As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "terimabarang_id"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 100
        cTerimabarang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_id.Visible = False
        cTerimabarang_id.ReadOnly = False

        cAsset_line.Name = "asset_line"
        cAsset_line.HeaderText = "asset_line"
        cAsset_line.DataPropertyName = "asset_line"
        cAsset_line.Width = 100
        cAsset_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_line.Visible = False
        cAsset_line.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = False

        cAsset_tgl.Name = "asset_tgl"
        cAsset_tgl.HeaderText = "asset_tgl"
        cAsset_tgl.DataPropertyName = "asset_tgl"
        cAsset_tgl.Width = 100
        cAsset_tgl.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_tgl.Visible = False
        cAsset_tgl.ReadOnly = False

        cTipeasset_id.Name = "tipeasset_id"
        cTipeasset_id.HeaderText = "tipeasset_id"
        cTipeasset_id.DataPropertyName = "tipeasset_id"
        cTipeasset_id.Width = 100
        cTipeasset_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTipeasset_id.Visible = False
        cTipeasset_id.ReadOnly = False

        cKategoriasset_id.Name = "kategoriasset_id"
        cKategoriasset_id.HeaderText = "kategoriasset_id"
        cKategoriasset_id.DataPropertyName = "kategoriasset_id"
        cKategoriasset_id.Width = 100
        cKategoriasset_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriasset_id.Visible = False
        cKategoriasset_id.ReadOnly = False

        cAsset_barcode.Name = "asset_barcode"
        cAsset_barcode.HeaderText = "Barcode"
        cAsset_barcode.DataPropertyName = "asset_barcode"
        cAsset_barcode.Width = 100
        cAsset_barcode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_barcode.Visible = True
        cAsset_barcode.ReadOnly = False

        cAsset_lineinduk.Name = "asset_lineinduk"
        cAsset_lineinduk.HeaderText = "asset_lineinduk"
        cAsset_lineinduk.DataPropertyName = "asset_lineinduk"
        cAsset_lineinduk.Width = 100
        cAsset_lineinduk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_lineinduk.Visible = False
        cAsset_lineinduk.ReadOnly = False

        cAsset_barcodeinduk.Name = "asset_barcodeinduk"
        cAsset_barcodeinduk.HeaderText = "asset_barcodeinduk"
        cAsset_barcodeinduk.DataPropertyName = "asset_barcodeinduk"
        cAsset_barcodeinduk.Width = 100
        cAsset_barcodeinduk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_barcodeinduk.Visible = False
        cAsset_barcodeinduk.ReadOnly = False

        cAsset_serial.Name = "asset_serial"
        cAsset_serial.HeaderText = "Serial Number"
        cAsset_serial.DataPropertyName = "asset_serial"
        cAsset_serial.Width = 100
        cAsset_serial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_serial.Visible = True
        cAsset_serial.ReadOnly = False

        cAsset_produknumber.Name = "asset_produknumber"
        cAsset_produknumber.HeaderText = "asset_produknumber"
        cAsset_produknumber.DataPropertyName = "asset_produknumber"
        cAsset_produknumber.Width = 100
        cAsset_produknumber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_produknumber.Visible = False
        cAsset_produknumber.ReadOnly = False

        cAsset_model.Name = "asset_model"
        cAsset_model.HeaderText = "asset_model"
        cAsset_model.DataPropertyName = "asset_model"
        cAsset_model.Width = 100
        cAsset_model.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_model.Visible = False
        cAsset_model.ReadOnly = False

        cAsset_deskripsi.Name = "asset_deskripsi"
        cAsset_deskripsi.HeaderText = "Deskripsi"
        cAsset_deskripsi.DataPropertyName = "asset_deskripsi"
        cAsset_deskripsi.Width = 250
        cAsset_deskripsi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_deskripsi.Visible = True
        cAsset_deskripsi.ReadOnly = False

        cKategoriitem_id.Name = "kategoriitem_id"
        cKategoriitem_id.HeaderText = "Kategori"
        cKategoriitem_id.DataPropertyName = "kategoriitem_id"
        cKategoriitem_id.Width = 200
        cKategoriitem_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriitem_id.Visible = True
        cKategoriitem_id.ReadOnly = False

        cTipeitem_id.Name = "tipeitem_id"
        cTipeitem_id.HeaderText = "Tipe"
        cTipeitem_id.DataPropertyName = "tipeitem_id"
        cTipeitem_id.Width = 200
        cTipeitem_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTipeitem_id.Visible = True
        cTipeitem_id.ReadOnly = False

        cAsset_golfiskal.Name = "asset_golfiskal"
        cAsset_golfiskal.HeaderText = "asset_golfiskal"
        cAsset_golfiskal.DataPropertyName = "asset_golfiskal"
        cAsset_golfiskal.Width = 100
        cAsset_golfiskal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_golfiskal.Visible = False
        cAsset_golfiskal.ReadOnly = False

        cAsset_tipedepre.Name = "asset_tipedepre"
        cAsset_tipedepre.HeaderText = "asset_tipedepre"
        cAsset_tipedepre.DataPropertyName = "asset_tipedepre"
        cAsset_tipedepre.Width = 100
        cAsset_tipedepre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_tipedepre.Visible = False
        cAsset_tipedepre.ReadOnly = False

        cAsset_depre_enddt.Name = "asset_depre_enddt"
        cAsset_depre_enddt.HeaderText = "asset_depre_enddt"
        cAsset_depre_enddt.DataPropertyName = "asset_depre_enddt"
        cAsset_depre_enddt.Width = 100
        cAsset_depre_enddt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_depre_enddt.Visible = False
        cAsset_depre_enddt.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Visible = False
        cCurrency_id.ReadOnly = False

        cAsset_harga.Name = "asset_harga"
        cAsset_harga.HeaderText = "Harga"
        cAsset_harga.DataPropertyName = "asset_harga"
        cAsset_harga.Width = 100
        cAsset_harga.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_harga.Visible = False
        cAsset_harga.ReadOnly = False

        cAsset_hargabaru.Name = "asset_hargabaru"
        cAsset_hargabaru.HeaderText = "asset_hargabaru"
        cAsset_hargabaru.DataPropertyName = "asset_hargabaru"
        cAsset_hargabaru.Width = 100
        cAsset_hargabaru.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_hargabaru.Visible = False
        cAsset_hargabaru.ReadOnly = False

        cAsset_ppn.Name = "asset_ppn"
        cAsset_ppn.HeaderText = "asset_ppn"
        cAsset_ppn.DataPropertyName = "asset_ppn"
        cAsset_ppn.Width = 100
        cAsset_ppn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_ppn.Visible = False
        cAsset_ppn.ReadOnly = False

        cAsset_pph.Name = "asset_pph"
        cAsset_pph.HeaderText = "asset_pph"
        cAsset_pph.DataPropertyName = "asset_pph"
        cAsset_pph.Width = 100
        cAsset_pph.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_pph.Visible = False
        cAsset_pph.ReadOnly = False

        cAsset_disc.Name = "asset_disc"
        cAsset_disc.HeaderText = "asset_disc"
        cAsset_disc.DataPropertyName = "asset_disc"
        cAsset_disc.Width = 100
        cAsset_disc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_disc.Visible = False
        cAsset_disc.ReadOnly = False

        cAsset_depresiasi.Name = "asset_depresiasi"
        cAsset_depresiasi.HeaderText = "asset_depresiasi"
        cAsset_depresiasi.DataPropertyName = "asset_depresiasi"
        cAsset_depresiasi.Width = 100
        cAsset_depresiasi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_depresiasi.Visible = False
        cAsset_depresiasi.ReadOnly = False

        cAsset_akum_val_depre.Name = "asset_akum_val_depre"
        cAsset_akum_val_depre.HeaderText = "asset_akum_val_depre"
        cAsset_akum_val_depre.DataPropertyName = "asset_akum_val_depre"
        cAsset_akum_val_depre.Width = 100
        cAsset_akum_val_depre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_akum_val_depre.Visible = False
        cAsset_akum_val_depre.ReadOnly = False

        cAsset_valas.Name = "asset_valas"
        cAsset_valas.HeaderText = "asset_valas"
        cAsset_valas.DataPropertyName = "asset_valas"
        cAsset_valas.Width = 100
        cAsset_valas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_valas.Visible = False
        cAsset_valas.ReadOnly = False

        cAsset_idrprice.Name = "asset_idrprice"
        cAsset_idrprice.HeaderText = "IDR Price"
        cAsset_idrprice.DataPropertyName = "asset_idrprice"
        cAsset_idrprice.Width = 100
        cAsset_idrprice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_idrprice.Visible = True
        cAsset_idrprice.ReadOnly = False
        cAsset_idrprice.DefaultCellStyle.Format = "#,##0"

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 180
        cStrukturunit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cEmployee_id_owner.Name = "employee_id_owner"
        cEmployee_id_owner.HeaderText = "Employee"
        cEmployee_id_owner.DataPropertyName = "employee_id_owner"
        cEmployee_id_owner.Width = 100
        cEmployee_id_owner.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEmployee_id_owner.Visible = False
        cEmployee_id_owner.ReadOnly = False

        cEmployee_string.Name = "employee_string"
        cEmployee_string.HeaderText = "Employee"
        cEmployee_string.DataPropertyName = "employee_string"
        cEmployee_string.Width = 100
        cEmployee_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEmployee_string.Visible = True
        cEmployee_string.ReadOnly = False

        cBrand_id.Name = "brand_id"
        cBrand_id.HeaderText = "brand_id"
        cBrand_id.DataPropertyName = "brand_id"
        cBrand_id.Width = 100
        cBrand_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBrand_id.Visible = False
        cBrand_id.ReadOnly = False

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "unit_id"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 100
        cUnit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUnit_id.Visible = False
        cUnit_id.ReadOnly = False

        cAsset_qty.Name = "asset_qty"
        cAsset_qty.HeaderText = "Qty"
        cAsset_qty.DataPropertyName = "asset_qty"
        cAsset_qty.Width = 100
        cAsset_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_qty.Visible = True
        cAsset_qty.ReadOnly = False

        cMaterial_id.Name = "material_id"
        cMaterial_id.HeaderText = "material_id"
        cMaterial_id.DataPropertyName = "material_id"
        cMaterial_id.Width = 100
        cMaterial_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cMaterial_id.Visible = False
        cMaterial_id.ReadOnly = False

        cWarna_id.Name = "warna_id"
        cWarna_id.HeaderText = "warna_id"
        cWarna_id.DataPropertyName = "warna_id"
        cWarna_id.Width = 100
        cWarna_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cWarna_id.Visible = False
        cWarna_id.ReadOnly = False

        cUkuran_id.Name = "ukuran_id"
        cUkuran_id.HeaderText = "ukuran_id"
        cUkuran_id.DataPropertyName = "ukuran_id"
        cUkuran_id.Width = 100
        cUkuran_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUkuran_id.Visible = False
        cUkuran_id.ReadOnly = False

        cJeniskelamin_id.Name = "jeniskelamin_id"
        cJeniskelamin_id.HeaderText = "jeniskelamin_id"
        cJeniskelamin_id.DataPropertyName = "jeniskelamin_id"
        cJeniskelamin_id.Width = 100
        cJeniskelamin_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJeniskelamin_id.Visible = False
        cJeniskelamin_id.ReadOnly = False

        cShow_id_cont_item.Name = "show_id_cont_item"
        cShow_id_cont_item.HeaderText = "show_id_cont_item"
        cShow_id_cont_item.DataPropertyName = "show_id_cont_item"
        cShow_id_cont_item.Width = 100
        cShow_id_cont_item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cShow_id_cont_item.Visible = False
        cShow_id_cont_item.ReadOnly = False

        cRuang_id.Name = "ruang_id"
        cRuang_id.HeaderText = "ruang_id"
        cRuang_id.DataPropertyName = "ruang_id"
        cRuang_id.Width = 100
        cRuang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRuang_id.Visible = False
        cRuang_id.ReadOnly = False

        cAsset_rak.Name = "asset_rak"
        cAsset_rak.HeaderText = "asset_rak"
        cAsset_rak.DataPropertyName = "asset_rak"
        cAsset_rak.Width = 100
        cAsset_rak.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_rak.Visible = False
        cAsset_rak.ReadOnly = False

        cIs_useable.Name = "is_useable"
        cIs_useable.HeaderText = "is_useable"
        cIs_useable.DataPropertyName = "is_useable"
        cIs_useable.Width = 100
        cIs_useable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cIs_useable.Visible = False
        cIs_useable.ReadOnly = False

        cAsset_active.Name = "asset_active"
        cAsset_active.HeaderText = "asset_active"
        cAsset_active.DataPropertyName = "asset_active"
        cAsset_active.Width = 100
        cAsset_active.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_active.Visible = False
        cAsset_active.ReadOnly = False

        cAsset_status.Name = "asset_status"
        cAsset_status.HeaderText = "Status"
        cAsset_status.DataPropertyName = "asset_status"
        cAsset_status.Width = 70
        cAsset_status.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_status.Visible = True
        cAsset_status.ReadOnly = False

        cProject_id.Name = "project_id"
        cProject_id.HeaderText = "project_id"
        cProject_id.DataPropertyName = "project_id"
        cProject_id.Width = 100
        cProject_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProject_id.Visible = False
        cProject_id.ReadOnly = False

        cShow_id.Name = "show_id"
        cShow_id.HeaderText = "show_id"
        cShow_id.DataPropertyName = "show_id"
        cShow_id.Width = 100
        cShow_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cShow_id.Visible = False
        cShow_id.ReadOnly = False

        cAsset_eps.Name = "asset_eps"
        cAsset_eps.HeaderText = "asset_eps"
        cAsset_eps.DataPropertyName = "asset_eps"
        cAsset_eps.Width = 100
        cAsset_eps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_eps.Visible = False
        cAsset_eps.ReadOnly = False

        cWo_id.Name = "wo_id"
        cWo_id.HeaderText = "wo_id"
        cWo_id.DataPropertyName = "wo_id"
        cWo_id.Width = 100
        cWo_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cWo_id.Visible = False
        cWo_id.ReadOnly = False

        cWo_date.Name = "wo_date"
        cWo_date.HeaderText = "wo_date"
        cWo_date.DataPropertyName = "wo_date"
        cWo_date.Width = 100
        cWo_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cWo_date.Visible = False
        cWo_date.ReadOnly = False

        cInputby.Name = "inputby"
        cInputby.HeaderText = "inputby"
        cInputby.DataPropertyName = "inputby"
        cInputby.Width = 100
        cInputby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cInputby.Visible = False
        cInputby.ReadOnly = False

        cInputdt.Name = "inputdt"
        cInputdt.HeaderText = "inputdt"
        cInputdt.DataPropertyName = "inputdt"
        cInputdt.Width = 100
        cInputdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cInputdt.Visible = False
        cInputdt.ReadOnly = False

        cEditby.Name = "editby"
        cEditby.HeaderText = "editby"
        cEditby.DataPropertyName = "editby"
        cEditby.Width = 100
        cEditby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEditby.Visible = False
        cEditby.ReadOnly = False

        cEditdt.Name = "editdt"
        cEditdt.HeaderText = "editdt"
        cEditdt.DataPropertyName = "editdt"
        cEditdt.Width = 100
        cEditdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEditdt.Visible = False
        cEditdt.ReadOnly = False

        cUsedby.Name = "usedby"
        cUsedby.HeaderText = "usedby"
        cUsedby.DataPropertyName = "usedby"
        cUsedby.Width = 100
        cUsedby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUsedby.Visible = False
        cUsedby.ReadOnly = False

        cAsset_deprebulanan.Name = "asset_deprebulanan"
        cAsset_deprebulanan.HeaderText = "asset_deprebulanan"
        cAsset_deprebulanan.DataPropertyName = "asset_deprebulanan"
        cAsset_deprebulanan.Width = 100
        cAsset_deprebulanan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_deprebulanan.Visible = False
        cAsset_deprebulanan.ReadOnly = False

        cAsset_stdepre.Name = "asset_stdepre"
        cAsset_stdepre.HeaderText = "asset_stdepre"
        cAsset_stdepre.DataPropertyName = "asset_stdepre"
        cAsset_stdepre.Width = 100
        cAsset_stdepre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_stdepre.Visible = False
        cAsset_stdepre.ReadOnly = False

        cAsset_eddepre.Name = "asset_eddepre"
        cAsset_eddepre.HeaderText = "asset_eddepre"
        cAsset_eddepre.DataPropertyName = "asset_eddepre"
        cAsset_eddepre.Width = 100
        cAsset_eddepre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_eddepre.Visible = False
        cAsset_eddepre.ReadOnly = False

        cStrukturunit_id_string.Name = "strukturunit_id_string"
        cStrukturunit_id_string.HeaderText = "Struktur Unit"
        cStrukturunit_id_string.DataPropertyName = "strukturunit_id_string"
        cStrukturunit_id_string.Width = 180
        cStrukturunit_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStrukturunit_id_string.Visible = True
        cStrukturunit_id_string.ReadOnly = False

        cBrand_id_string.Name = "brand_id_string"
        cBrand_id_string.HeaderText = "Brand"
        cBrand_id_string.DataPropertyName = "brand_id_string"
        cBrand_id_string.Width = 100
        cBrand_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBrand_id_string.Visible = True
        cBrand_id_string.ReadOnly = False

        cUnit_id_string.Name = "unit_id_string"
        cUnit_id_string.HeaderText = "Unit"
        cUnit_id_string.DataPropertyName = "unit_id_string"
        cUnit_id_string.Width = 100
        cUnit_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUnit_id_string.Visible = True
        cUnit_id_string.ReadOnly = False

        cProject_id_string.Name = "project_id_string"
        cProject_id_string.HeaderText = "Project"
        cProject_id_string.DataPropertyName = "project_id_string"
        cProject_id_string.Width = 100
        cProject_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProject_id_string.Visible = True
        cProject_id_string.ReadOnly = False

        cShow_id_string.Name = "show_id_string"
        cShow_id_string.HeaderText = "Show"
        cShow_id_string.DataPropertyName = "show_id_string"
        cShow_id_string.Width = 200
        cShow_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cShow_id_string.Visible = True
        cShow_id_string.ReadOnly = False

        cGolongan_pajak.Name = "golongan_pajak"
        cGolongan_pajak.HeaderText = "golongan_pajak"
        cGolongan_pajak.DataPropertyName = "golongan_pajak"
        cGolongan_pajak.Width = 200
        cGolongan_pajak.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cGolongan_pajak.Visible = True
        cGolongan_pajak.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cChannel_id, cTerimabarang_id, cAsset_line, cAsset_tgl, _
        cTipeasset_id, cKategoriasset_id, _
        cAsset_barcode, cAsset_lineinduk, cAsset_barcodeinduk, _
        cAsset_serial, cAsset_produknumber, cAsset_model, cAsset_deskripsi, _
        cKategoriitem_id, cTipeitem_id, cStrukturunit_id_string, cAsset_golfiskal, cAsset_tipedepre, _
        cBrand_id_string, cUnit_id_string, cAsset_depre_enddt, _
        cCurrency_id, cAsset_harga, cAsset_hargabaru, _
        cAsset_ppn, cAsset_pph, cAsset_disc, cAsset_depresiasi, cAsset_akum_val_depre, _
        cAsset_valas, cStrukturunit_id, cBrand_id, cUnit_id, _
        cAsset_qty, cAsset_status, cEmployee_string, cEmployee_id_owner, cMaterial_id, cWarna_id, cUkuran_id, cJeniskelamin_id, cShow_id_cont_item, _
        cRuang_id, cAsset_rak, cIs_useable, cAsset_active, cProject_id, cShow_id, _
        cAsset_eps, cWo_id, cInputby, cInputdt, cEditby, cEditdt, cUsedby, cAsset_deprebulanan, cAsset_stdepre, cAsset_eddepre, _
          cProject_id_string, _
        cShow_id_string, cAsset_idrprice, cWo_date, cGolongan_pajak})
        objDgv.AutoGenerateColumns = False

        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

    Private Function FormatDgvMstLogasset(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cLogasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLogasset_tanggal As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLogasset_sttm As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLogasset_edtm As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLogasset_transaksi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLogasset_notrans As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLogasset_stat As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cLogasset_id.Name = "logasset_id"
        cLogasset_id.HeaderText = "logasset_id"
        cLogasset_id.DataPropertyName = "logasset_id"
        cLogasset_id.Width = 100
        cLogasset_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLogasset_id.Visible = False
        cLogasset_id.ReadOnly = False

        cAsset_barcode.Name = "asset_barcode"
        cAsset_barcode.HeaderText = "Barcode"
        cAsset_barcode.DataPropertyName = "asset_barcode"
        cAsset_barcode.Width = 100
        cAsset_barcode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_barcode.Visible = True
        cAsset_barcode.ReadOnly = False

        cLogasset_tanggal.Name = "logasset_tanggal"
        cLogasset_tanggal.HeaderText = "Date"
        cLogasset_tanggal.DataPropertyName = "logasset_tanggal"
        cLogasset_tanggal.Width = 100
        cLogasset_tanggal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLogasset_tanggal.Visible = True
        cLogasset_tanggal.ReadOnly = False

        cLogasset_sttm.Name = "logasset_sttm"
        cLogasset_sttm.HeaderText = "Start Time"
        cLogasset_sttm.DataPropertyName = "logasset_sttm"
        cLogasset_sttm.Width = 80
        cLogasset_sttm.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLogasset_sttm.Visible = True
        cLogasset_sttm.ReadOnly = False

        cLogasset_edtm.Name = "logasset_edtm"
        cLogasset_edtm.HeaderText = "End Time"
        cLogasset_edtm.DataPropertyName = "logasset_edtm"
        cLogasset_edtm.Width = 80
        cLogasset_edtm.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLogasset_edtm.Visible = True
        cLogasset_edtm.ReadOnly = False

        cLogasset_transaksi.Name = "logasset_transaksi"
        cLogasset_transaksi.HeaderText = "Transaction"
        cLogasset_transaksi.DataPropertyName = "logasset_transaksi"
        cLogasset_transaksi.Width = 80
        cLogasset_transaksi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLogasset_transaksi.Visible = True
        cLogasset_transaksi.ReadOnly = False

        cLogasset_notrans.Name = "logasset_notrans"
        cLogasset_notrans.HeaderText = "Transaction No."
        cLogasset_notrans.DataPropertyName = "logasset_notrans"
        cLogasset_notrans.Width = 120
        cLogasset_notrans.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLogasset_notrans.Visible = True
        cLogasset_notrans.ReadOnly = False

        cLogasset_stat.Name = "logasset_stat"
        cLogasset_stat.HeaderText = "logasset_stat"
        cLogasset_stat.DataPropertyName = "logasset_stat"
        cLogasset_stat.Width = 100
        cLogasset_stat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLogasset_stat.Visible = False
        cLogasset_stat.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cLogasset_id, cAsset_barcode, cLogasset_tanggal, cLogasset_sttm, cLogasset_edtm, cLogasset_transaksi, cLogasset_notrans, cLogasset_stat})
      
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.ftabMain.TabPages.Item(1).BackColor = Color.DarkSeaGreen
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvMstAsset.Dock = DockStyle.Fill

        Me.FormatDgvMstAsset(Me.DgvMstAsset)
        Me.FormatDgvMstLogasset(Me.dgvLogAsset)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Terimabarang_id.DataBindings.Clear()
        Me.obj_Asset_line.DataBindings.Clear()
        Me.obj_Asset_tgl.DataBindings.Clear()
        Me.obj_Tipeasset_id.DataBindings.Clear()
        Me.obj_Kategoriasset_id.DataBindings.Clear()
        Me.obj_Asset_barcode.DataBindings.Clear()
        'Me.obj_Asset_lineinduk.DataBindings.clear()
        Me.obj_Asset_barcodeinduk.DataBindings.Clear()
        Me.obj_Asset_serial.DataBindings.Clear()
        Me.obj_Asset_produknumber.DataBindings.Clear()
        Me.obj_Asset_model.DataBindings.Clear()
        Me.obj_Asset_deskripsi.DataBindings.Clear()
        Me.obj_Currency_id.DataBindings.Clear()
        Me.obj_Asset_harga.DataBindings.Clear()
        Me.obj_Kategoriitem_id.DataBindings.Clear()
        Me.obj_Tipeitem_id.DataBindings.Clear()
        Me.obj_Strukturunit_id.DataBindings.Clear()
        Me.obj_Brand_id.DataBindings.Clear()
        Me.obj_Unit_id.DataBindings.Clear()
        Me.obj_Asset_qty.DataBindings.Clear()
        Me.obj_Material_id.DataBindings.Clear()
        Me.obj_Warna_id.DataBindings.Clear()
        Me.obj_Ukuran_id.DataBindings.Clear()
        Me.obj_Jeniskelamin_id.DataBindings.Clear()
        Me.obj_Show_id_cont_item.DataBindings.Clear()
        Me.obj_Is_active.DataBindings.Clear()
        Me.obj_Is_useable.DataBindings.Clear()
        Me.obj_Asset_status.DataBindings.Clear()
        Me.obj_Employee_id_owner.DataBindings.Clear()
        Me.obj_Wo_id.DataBindings.Clear()
        Me.obj_asset_wo_date.DataBindings.Clear()
        Me.obj_ruang_id.DataBindings.Clear()
        Me.obj_asset_rak.DataBindings.Clear()
        Me.obj_asset_gol_pajak.DataBindings.Clear()
        Me.obj_MstAsset_useAble.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Channel_id.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "channel_id"))
        Me.obj_Terimabarang_id.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "terimabarang_id"))
        Me.obj_Asset_line.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_line"))
        Me.obj_Asset_tgl.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_tgl"))
        Me.obj_Tipeasset_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "tipeasset_id"))
        Me.obj_Kategoriasset_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "kategoriasset_id"))
        Me.obj_Asset_barcode.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_barcode"))
        'Me.obj_Asset_lineinduk.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_lineinduk"))
        Me.obj_Asset_barcodeinduk.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_barcodeinduk"))
        Me.obj_Asset_serial.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_serial"))
        Me.obj_Asset_produknumber.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_produknumber"))
        Me.obj_Asset_model.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_model"))
        Me.obj_Asset_deskripsi.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_deskripsi"))
        Me.obj_Currency_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "currency_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_harga.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_harga", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Kategoriitem_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "kategoriitem_id"))
        Me.obj_Tipeitem_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "tipeitem_id"))
        Me.obj_Strukturunit_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "strukturunit_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Brand_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "brand_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Unit_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "unit_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_qty.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_qty"))
        Me.obj_Material_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "material_id"))
        Me.obj_Warna_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "warna_id"))
        Me.obj_Ukuran_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "ukuran_id"))
        Me.obj_Jeniskelamin_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "jeniskelamin_id"))
        Me.obj_Show_id_cont_item.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "show_id_cont_item"))
        Me.obj_Is_active.DataBindings.Add(New Binding("Checked", Me.tbl_MstAsset_Temp, "asset_active"))
        Me.obj_Is_useable.DataBindings.Add(New Binding("Checked", Me.tbl_MstAsset_Temp, "is_useable"))
        Me.obj_Asset_status.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_status"))
        Me.obj_Employee_id_owner.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "employee_id_owner"))
        Me.obj_Wo_id.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "wo_id"))
        Me.obj_asset_wo_date.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "wo_date"))
        Me.obj_ruang_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "ruang_id"))
        Me.obj_asset_rak.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_rak"))
        Me.obj_asset_gol_pajak.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "golongan_pajak"))
        Me.obj_MstAsset_useAble.DataBindings.Add(New Binding("Checked", Me.tbl_MstAsset, "is_useable"))
        Return True
    End Function

#End Region
#Region " Dialoged Control "
#End Region
#Region " User Defined Function "

    Private Function UiMstAsset_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_MstAsset_Temp
        Me.tbl_MstAsset_Temp.Clear()
        Me.tbl_MstAsset_Temp.Columns("is_useable").DefaultValue = 1
        Me.tbl_MstAsset_Temp.Columns("terimabarang_id").DefaultValue = "NO RV"
        Me.tbl_MstAsset_Temp.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_MstAsset_Temp.Columns("asset_status").DefaultValue = "AVL"
        Me.BindingContext(Me.tbl_MstAsset_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_MstAsset_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function UiMstAsset_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""
        Dim ASSETFILL As New clsDataFiller(Me.ASSET_DSN)
        ' TODO: Parse Criteria using clsProc.RefParser()
        Me.tbl_MstAsset.Clear()
        Try
            ASSETFILL.DataFill(Me.tbl_MstAsset, "as_MstAssetAlias_Select", criteria, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function UiMstAsset_Save() As Boolean
        'save data
        Dim tbl_MstAsset_Temp_Changes As DataTable
        Dim success As Boolean
        Dim asset_barcode As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(asset_barcode)

        Me.BindingContext(Me.tbl_MstAsset_Temp).EndCurrentEdit()
        tbl_MstAsset_Temp_Changes = Me.tbl_MstAsset_Temp.GetChanges()

        If tbl_MstAsset_Temp_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_MstAsset_Temp.Rows(0).RowState
                asset_barcode = tbl_MstAsset_Temp.Rows(0).Item("asset_barcode")

                If tbl_MstAsset_Temp_Changes IsNot Nothing Then
                    success = Me.UiMstAsset_SaveMaster(asset_barcode, tbl_MstAsset_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.UiMstAsset_SaveMaster(tbl_MstAsset_Temp_Changes)")
                    Me.tbl_MstAsset_Temp.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.obj_Asset_barcode.ReadOnly = True
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

        RaiseEvent FormAfterSave(asset_barcode, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function UiMstAsset_SaveMaster(ByRef asset_barcode As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: master_asset
        dbCmdInsert = New OleDb.OleDbCommand("as_MstAssetNonFix_insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_line", System.Data.OleDb.OleDbType.Integer, 4, "asset_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_tgl"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "tipeasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_lineinduk", System.Data.OleDb.OleDbType.Integer, 4, "asset_lineinduk"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcodeinduk", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcodeinduk"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_serial", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_serial"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_produknumber", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_produknumber"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_model", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_model"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deskripsi", System.Data.OleDb.OleDbType.VarWChar, 400, "asset_deskripsi"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriitem_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "tipeitem_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_golfiskal", System.Data.OleDb.OleDbType.VarWChar, 10, "asset_golfiskal"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tipedepre", System.Data.OleDb.OleDbType.VarWChar, 2, "asset_tipedepre"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_depre_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_depre_enddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_harga", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_harga", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_hargabaru", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_hargabaru", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_depresiasi", System.Data.OleDb.OleDbType.Integer, 4, "asset_depresiasi"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_akum_val_depre", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_akum_val_depre", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_valas", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_valas", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_idrprice", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_idrprice", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "unit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_qty", System.Data.OleDb.OleDbType.Integer, 4, "asset_qty"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@material_id", System.Data.OleDb.OleDbType.VarWChar, 60, "material_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@warna_id", System.Data.OleDb.OleDbType.VarWChar, 60, "warna_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ukuran_id", System.Data.OleDb.OleDbType.VarWChar, 60, "ukuran_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jeniskelamin_id", System.Data.OleDb.OleDbType.VarWChar, 20, "jeniskelamin_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id_cont_item", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id_cont_item"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_id", System.Data.OleDb.OleDbType.VarWChar, 20, "ruang_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_rak", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_rak"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Boolean, 1, "is_useable"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_active", System.Data.OleDb.OleDbType.Boolean, 1, "asset_active"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "project_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_eps", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_eps"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wo_id", System.Data.OleDb.OleDbType.VarWChar, 30, "wo_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wo_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "wo_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editby", System.Data.OleDb.OleDbType.VarWChar, 100, "editby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "editdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@usedby", System.Data.OleDb.OleDbType.VarWChar, 100, "usedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deprebulanan", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_deprebulanan", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_stdepre", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_stdepre"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_eddepre", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_eddepre"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@golongan_pajak", System.Data.OleDb.OleDbType.VarWChar, 20, "golongan_pajak"))
        dbCmdInsert.Parameters("@terimabarang_id").Value = String.Empty
        dbCmdInsert.Parameters("@inputby").Value = Me.UserName
        dbCmdInsert.Parameters("@inputdt").Value = Now



        dbCmdUpdate = New OleDb.OleDbCommand("as_MstAssetNonfix_update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_line", System.Data.OleDb.OleDbType.Integer, 4, "asset_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_tgl"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "tipeasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_lineinduk", System.Data.OleDb.OleDbType.Integer, 4, "asset_lineinduk"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcodeinduk", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcodeinduk"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_serial", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_serial"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_produknumber", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_produknumber"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_model", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_model"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deskripsi", System.Data.OleDb.OleDbType.VarWChar, 400, "asset_deskripsi"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriitem_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "tipeitem_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_golfiskal", System.Data.OleDb.OleDbType.VarWChar, 10, "asset_golfiskal"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tipedepre", System.Data.OleDb.OleDbType.VarWChar, 2, "asset_tipedepre"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_depre_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_depre_enddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_harga", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_harga", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_hargabaru", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_hargabaru", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_depresiasi", System.Data.OleDb.OleDbType.Integer, 4, "asset_depresiasi"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_akum_val_depre", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_akum_val_depre", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_valas", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_valas", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_idrprice", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_idrprice", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "unit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_qty", System.Data.OleDb.OleDbType.Integer, 4, "asset_qty"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@material_id", System.Data.OleDb.OleDbType.VarWChar, 60, "material_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@warna_id", System.Data.OleDb.OleDbType.VarWChar, 60, "warna_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ukuran_id", System.Data.OleDb.OleDbType.VarWChar, 60, "ukuran_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jeniskelamin_id", System.Data.OleDb.OleDbType.VarWChar, 20, "jeniskelamin_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id_cont_item", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id_cont_item"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_id", System.Data.OleDb.OleDbType.VarWChar, 20, "ruang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_rak", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_rak"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Boolean, 1, "is_useable"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_active", System.Data.OleDb.OleDbType.Boolean, 1, "asset_active"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "project_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_eps", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_eps"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wo_id", System.Data.OleDb.OleDbType.VarWChar, 30, "wo_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wo_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "wo_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputby", System.Data.OleDb.OleDbType.VarWChar, 100, "inputby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "inputdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@usedby", System.Data.OleDb.OleDbType.VarWChar, 100, "usedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deprebulanan", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_deprebulanan", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_stdepre", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_stdepre"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_eddepre", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_eddepre"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@golongan_pajak", System.Data.OleDb.OleDbType.VarWChar, 20, "golongan_pajak"))
        dbCmdUpdate.Parameters("@editby").Value = Me.UserName
        dbCmdUpdate.Parameters("@editdt").Value = Now

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            asset_barcode = objTbl.Rows(0).Item("asset_barcode")
            Me.tbl_MstAsset_Temp.Clear()
            Me.tbl_MstAsset_Temp.Merge(objTbl)

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
            Me.tbl_MstAsset.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_MstAsset).Position
            Me.tbl_MstAsset.Rows.RemoveAt(curpos)
            Me.tbl_MstAsset.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_MstAsset).Position = Me.BindingContext(Me.tbl_MstAsset).Count

        Return True
    End Function

    Private Function UiMstAsset_Print() As Boolean
        'print data
    End Function

    Private Function UiMstAsset_Delete() As Boolean
        Dim res As String = ""
        Dim asset_barcode As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(asset_barcode)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvMstAsset.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.UiMstAsset_DeleteRow(Me.DgvMstAsset.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(asset_barcode)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function UiMstAsset_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim asset_barcode As String
        Dim NewRowIndex As Integer

        asset_barcode = Me.DgvMstAsset.Rows(rowIndex).Cells("asset_barcode").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_MstAsset_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@terimabarang_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_line", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@asset_line").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@asset_tgl").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeasset_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@tipeasset_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@kategoriasset_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters("@asset_barcode").Value = asset_barcode
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_lineinduk", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@asset_lineinduk").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcodeinduk", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters("@asset_barcodeinduk").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_serial", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@asset_serial").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_produknumber", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@asset_produknumber").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_model", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@asset_model").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deskripsi", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@asset_deskripsi").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@currency_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_harga", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@asset_harga").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@kategoriitem_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeitem_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@tipeitem_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@strukturunit_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@brand_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@unit_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_qty", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@asset_qty").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@material_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@material_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@warna_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@warna_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ukuran_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@ukuran_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jeniskelamin_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@jeniskelamin_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id_cont_item", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@show_id_cont_item").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_active", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@is_active").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@is_useable").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@asset_status").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@employee_id_owner").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wo_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@wo_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@ruang_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_rak", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters("@asset_rak").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvMstAsset.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.UiMstAsset_OpenRow(NewRowIndex)
                    Me.tbl_MstAsset.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvMstAsset.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.UiMstAsset_OpenRow(NewRowIndex)
                    Me.tbl_MstAsset.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_MstAsset.Rows.RemoveAt(rowIndex)
                    Me.UiMstAsset_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_MstAsset_Temp.Clear()
                Me.tbl_MstAsset.Rows.RemoveAt(rowIndex)

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

    Private Function UiMstAsset_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim asset_barcode As String
        Dim channel_id As String

        asset_barcode = Me.DgvMstAsset.Rows(rowIndex).Cells("asset_barcode").Value
        channel_id = Me.DgvMstAsset.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(asset_barcode)


        Try
            dbConn.Open()
            Me.UiMstAsset_OpenRowMaster(channel_id, asset_barcode, dbConn)
            Me.to_ReadOnly()
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": UiMstAsset_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(asset_barcode)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function UiMstAsset_OpenRowMaster(ByVal channel_id As String, ByVal asset_barcode As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_MstAssetAlias_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("asset_barcode='{0}'", asset_barcode)
        dbCmd.Parameters.Add("@top", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@top").Value = Me.NumericUpDown1.Value
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstAsset_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_MstAsset_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": UiMstAsset_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function UiMstAsset_First() As Boolean
        'goto first record found
        If Me.DgvMstAsset.SelectedRows.Count <= 0 Then
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
                move = Me.UiMstAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstAsset.CurrentCell = Me.DgvMstAsset(0, 0)
            Me.UiMstAsset_RefreshPosition()
        End If
    End Function
    Private Function UiMstAsset_Prev() As Boolean
        'goto previous record found
        If Me.DgvMstAsset.SelectedRows.Count <= 0 Then
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
                move = Me.UiMstAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstAsset.CurrentCell.RowIndex > 0 Then
                Me.DgvMstAsset.CurrentCell = Me.DgvMstAsset(0, DgvMstAsset.CurrentCell.RowIndex - 1)
                Me.UiMstAsset_RefreshPosition()
            End If
        End If
    End Function
    Private Function UiMstAsset_Next() As Boolean
        'goto next record found
        If Me.DgvMstAsset.SelectedRows.Count <= 0 Then
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
                move = Me.UiMstAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstAsset.CurrentCell.RowIndex < Me.DgvMstAsset.Rows.Count - 1 Then
                Me.DgvMstAsset.CurrentCell = Me.DgvMstAsset(0, DgvMstAsset.CurrentCell.RowIndex + 1)
                Me.UiMstAsset_RefreshPosition()
            End If
        End If
    End Function
    Private Function UiMstAsset_Last() As Boolean
        'goto last record found
        If Me.DgvMstAsset.SelectedRows.Count <= 0 Then
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
                move = Me.UiMstAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstAsset.CurrentCell = Me.DgvMstAsset(0, Me.DgvMstAsset.Rows.Count - 1)
            Me.UiMstAsset_RefreshPosition()
        End If
    End Function
    Private Function UiMstAsset_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then UiMstAsset_OpenRow(Me.DgvMstAsset.CurrentRow.Index)
    End Function

    Private Function UiMstAsset_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_MstAsset_Temp_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim asset_barcode As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvMstAsset.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_MstAsset_Temp).EndCurrentEdit()
            tbl_MstAsset_Temp_Changes = Me.tbl_MstAsset_Temp.GetChanges()

            If tbl_MstAsset_Temp_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(asset_barcode)

                        Try

                            If tbl_MstAsset_Temp_Changes IsNot Nothing Then
                                success = Me.UiMstAsset_SaveMaster(asset_barcode, tbl_MstAsset_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_MstAsset_Temp.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(asset_barcode, result)

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

    Private Function UiMstAsset_FormError() As Boolean
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

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        Dim ASSETFill As New clsDataFiller(Me.ASSET_DSN)

        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
        End If


        Me.DgvMstAsset.DataSource = Me.tbl_MstAsset  'buat jebak pas jalan di browser
        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
        '    Dim dummyparameter As String = "CHANNEL_ID=TTV;"
        '    objParameters = Me.GetParameterCollection(dummyparameter)
        '    'objParameters = Me.GetParameterCollection(Me.Parameter)
        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL_ID")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
        'End If

        Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", Me.tbl_MstChannelSearch, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'")
        Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_id"


        ' Sekarang bagian yang asset
        Me.ComboFill(Me.obj_Strukturunit_id, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitAsset, "ms_MstStrukturUnit_Select", "  ")
        Me.tbl_MstStrukturunitAsset.DefaultView.Sort = "strukturunit_name"
        ASSETFill.ComboFill(Me.obj_Tipeasset_id, "tipeasset_id", "tipeasset_id", Me.tbl_MstTipeAsset, "as_MstTipeasset_Select", "  ")
        Me.tbl_MstTipeAsset.DefaultView.Sort = "tipeasset_id"
        ASSETFill.ComboFill(Me.obj_Kategoriasset_id, "kategoriasset_id", "kategoriasset_id", Me.tbl_mstKategoriAsset, "as_MstKategoriasset_Select", "  ")
        Me.tbl_mstKategoriAsset.DefaultView.Sort = "kategoriasset_id"
        ASSETFill.ComboFill(Me.obj_Tipeitem_id, "tipeitem_id", "tipeitem_id", Me.tbl_msttipeitem, "as_MstTipeitem_Select", "  ")
        Me.tbl_msttipeitem.DefaultView.Sort = "tipeitem_id"
        ASSETFill.ComboFill(Me.obj_Kategoriitem_id, "kategoriitem_id", "kategoriitem_id", Me.tbl_mstKategoriitem, "as_MstKategoriitem_Select", "  ")
        Me.tbl_mstKategoriitem.DefaultView.Sort = "kategoriitem_id"
        ASSETFill.ComboFill(Me.obj_Jeniskelamin_id, "Pilihan", "Pilihan", Me.tbl_Mstsex, "as_MstPilihan_Select", " Kategori = 'MstsexAsset' and is_disable = 0")
        Me.tbl_Mstsex.DefaultView.Sort = "Pilihan"
        Me.ComboFill(Me.obj_Currency_id, "Currency_id", "Currency_shortname", Me.tbl_MstCurrency, "ms_MstCurrency_Select", "  Currency_active = 1")
        Me.tbl_MstCurrency.DefaultView.Sort = "Currency_shortname"
        ASSETFill.ComboFill(Me.obj_Warna_id, "warna_id", "warna_id", Me.tbl_Mstwarna, "as_MstWarna_Select", " ")
        Me.tbl_Mstwarna.DefaultView.Sort = "warna_id"
        ASSETFill.ComboFill(Me.obj_Material_id, "Material_id", "Material_id", Me.tbl_Mstmaterial, "as_MstMaterial_Select", " ")
        Me.tbl_Mstmaterial.DefaultView.Sort = "Material_id"
        ASSETFill.ComboFill(Me.obj_Employee_id_owner, "employee_id", "employee_namalengkap", Me.tbl_Mstowner, "ms_MstEmployee_Select", "  ")
        Me.tbl_Mstowner.DefaultView.Sort = "employee_namalengkap"
        ASSETFill.ComboFill(Me.obj_Brand_id, "merk_id", "merk_name", Me.tbl_brand, "as_MstMerk_Select", " merk_active = 1 ")
        Me.tbl_brand.DefaultView.Sort = "merk_name"
        ASSETFill.ComboFill(Me.obj_Unit_id, "unit_id", "unit_shortname", Me.tbl_unit, "AS_MstUnit_Select", " unit_active = 1 ")
        Me.tbl_unit.DefaultView.Sort = "unit_shortname"
        ASSETFill.ComboFill(Me.obj_Ukuran_id, "ukuran_id", "ukuran_id", Me.tbl_ukuran, "AS_MstUkuran_Select", "  ")
        Me.tbl_ukuran.DefaultView.Sort = "ukuran_id"

        ASSETFill.ComboFill(Me.obj_Show_id_cont_item, "show_id", "show_title", Me.tbl_showcont, "as_MstShow_Select ", " ", _CHANNEL)
        tbl_showcont.DefaultView.Sort = "show_title"

        ASSETFill.ComboFill(Me.obj_ruang_id, "ruang_id", "keterangan", Me.tbl_MstAssetruang, "as_MstRuangAsset_Select", "  ", _CHANNEL)
        Me.tbl_MstAssetruang.DefaultView.Sort = "keterangan"

        'Me._CHANNEL = "TTV"
        Me.cboSearchChannel.SelectedValue = Me._CHANNEL

        Me.InitLayoutUI()
        Me.BindingStop()
        Me.BindingStart()

        Me.UiMstAsset_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.btnAddPicture.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

        Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_CHANGED
        Me.chkSearchChannel.Checked = True
        Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED

        ' Tambahan Button di toolstrip
        Me.btnAddPicture.ToolTipText = "Add Picture"
        Me.ToolStrip1.Items.Add(Me.btnAddPicture)
        Me.btnAddPicture.Image = Me.ImageList1.Images(0)


        Me.btnAsk.ToolTipText = "Where is it"
        Me.ToolStrip1.Items.Add(Me.btnAsk)
        Me.btnAsk.Image = Me.ImageList1.Images(1)
    End Sub



    Private Sub UiMstAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If

    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

        Select Case ftabMain.SelectedIndex
            Case 0
                nonFix = 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.btnAddPicture.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Ivory
                Me.ftabMain.TabPages.Item(1).BackColor = Color.DarkSeaGreen
                Me.ftabMain.TabPages.Item(2).BackColor = Color.DarkSeaGreen
                Me.ftabMain.TabPages.Item(3).BackColor = Color.DarkSeaGreen

                Me.obj_Asset_barcode.ReadOnly = True

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.btnAddPicture.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.DarkSeaGreen
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Ivory
                Me.ftabMain.TabPages.Item(2).BackColor = Color.DarkSeaGreen
                Me.ftabMain.TabPages.Item(3).BackColor = Color.DarkSeaGreen


                If Me.DgvMstAsset.CurrentRow IsNot Nothing Then
                    Me.UiMstAsset_OpenRow(Me.DgvMstAsset.CurrentRow.Index)
                Else
                    Me.UiMstAsset_NewData()
                End If

                Me.to_ReadOnly()

            Case 2
                Me.history_maintenance()
                Me.ftabMain.TabPages.Item(0).BackColor = Color.DarkSeaGreen
                Me.ftabMain.TabPages.Item(1).BackColor = Color.DarkSeaGreen
                Me.ftabMain.TabPages.Item(2).BackColor = Color.Ivory
                Me.ftabMain.TabPages.Item(3).BackColor = Color.DarkSeaGreen
            Case 3
                Me.ftabMain.TabPages.Item(0).BackColor = Color.DarkSeaGreen
                Me.ftabMain.TabPages.Item(1).BackColor = Color.DarkSeaGreen
                Me.ftabMain.TabPages.Item(2).BackColor = Color.DarkSeaGreen
                Me.ftabMain.TabPages.Item(3).BackColor = Color.Ivory

                Me.Log_Asset()


        End Select
    End Sub

    Private Sub DgvMstAsset_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMstAsset.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvMstAsset.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub addPicture()
        Dim rNamaFile As String
        If Me.obj_Asset_barcode.Text <> "" Then
            rNamaFile = Me.obj_Asset_barcode.Text & "-" & Me.obj_Asset_line.Text
            Dim dlg As dlg_addPicture = New dlg_addPicture(Me.DSN, rNamaFile)

            dlg.ShowInTaskbar = False
            dlg.StartPosition = FormStartPosition.CenterParent
            dlg.ShowDialog(Me)
        Else
            MsgBox("No Data Selected", MsgBoxStyle.Critical, "ERRORs")
            Exit Sub
        End If
    End Sub

    Private Sub to_ReadOnly()
        If nonFix = 1 Or Me.obj_MstAsset_useAble.Checked = True Then
            Me.obj_Asset_barcode.Enabled = True
            Me.obj_Asset_produknumber.Enabled = True
            Me.obj_Asset_model.Enabled = True
            Me.obj_Asset_model.Enabled = True
            Me.obj_Asset_qty.Enabled = True
            Me.obj_Asset_deskripsi.Enabled = True
            Me.obj_asset_rak.Enabled = True
            Me.obj_Wo_id.Enabled = True
            Me.obj_Tipeasset_id.Enabled = True
            Me.obj_Kategoriasset_id.Enabled = True
            Me.obj_Tipeitem_id.Enabled = True
            Me.obj_Kategoriitem_id.Enabled = True
            Me.obj_Unit_id.Enabled = True
            Me.obj_Currency_id.Enabled = True
            Me.obj_Brand_id.Enabled = True
            Me.obj_Material_id.Enabled = True
            Me.obj_Warna_id.Enabled = True
            Me.obj_Ukuran_id.Enabled = True
            Me.obj_Strukturunit_id.Enabled = True
            Me.obj_Employee_id_owner.Enabled = True
            Me.obj_Jeniskelamin_id.Enabled = True
            Me.obj_ruang_id.Enabled = True
            Me.obj_Show_id_cont_item.Enabled = True
            Me.obj_Asset_harga.Enabled = True
            Me.obj_Asset_barcodeinduk.Enabled = True
            Me.obj_Asset_serial.Enabled = True
        Else
            Me.obj_Asset_barcode.Enabled = False
            Me.obj_Asset_produknumber.Enabled = False
            Me.obj_Asset_model.Enabled = False
            Me.obj_Asset_model.Enabled = False
            Me.obj_Asset_qty.Enabled = False
            Me.obj_Asset_deskripsi.Enabled = False
            Me.obj_asset_rak.Enabled = True
            Me.obj_Wo_id.Enabled = False
            Me.obj_Tipeasset_id.Enabled = False
            Me.obj_Kategoriasset_id.Enabled = False
            Me.obj_Tipeitem_id.Enabled = False
            Me.obj_Kategoriitem_id.Enabled = False
            Me.obj_Unit_id.Enabled = False
            Me.obj_Currency_id.Enabled = False
            Me.obj_Brand_id.Enabled = False
            Me.obj_Material_id.Enabled = False
            Me.obj_Warna_id.Enabled = False
            Me.obj_Ukuran_id.Enabled = False
            Me.obj_Strukturunit_id.Enabled = False
            Me.obj_Employee_id_owner.Enabled = False
            Me.obj_Jeniskelamin_id.Enabled = False
            Me.obj_ruang_id.Enabled = True
            Me.obj_Show_id_cont_item.Enabled = True
            Me.obj_Asset_harga.Enabled = False
            Me.obj_Asset_barcodeinduk.Enabled = False
            Me.obj_Asset_serial.Enabled = False
        End If
    End Sub


    Private Sub history_maintenance()
        Dim maintenance_induk As DataTable = New DataTable
        Dim asset_barcode As String = String.Empty
        If DgvMstAsset.Rows.Count <= 0 Then
            Exit Sub
        End If
        asset_barcode = Me.DgvMstAsset.Rows(Me.DgvMstAsset.CurrentRow.Index).Cells("asset_barcode").Value
        Me.DgvTrnMaintenanceAsset.DataSource = ""
        If Me.obj_MstAsset_useAble.Checked = False Then
            If Mid(asset_barcode, 9, 3) = 0 Then
                'MsgBox("induk")
                maintenance_induk.Clear()
                Try
                    Me.DataFill(maintenance_induk, "as_MstAsset_historimaintenance", Me._CHANNEL, asset_barcode)
                    Me.DgvTrnMaintenanceAsset.DataSource = maintenance_induk

                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    'Private Sub ask()
    '    Dim tbl_ask As DataTable = New DataTable
    '    Dim criteria As String = String.Empty
    '    Dim status As String = String.Empty
    '    Dim tbl_ruang As DataTable = New DataTable
    '    Dim criteria_ruang As String = String.Empty

    '    Dim tbl_logasset As DataTable = New DataTable
    '    Dim criteria_logasset As String = String.Empty

    '    Dim logasset_notrans As String = String.Empty

    '    Dim tbl_TrnBookasset As DataTable = New DataTable
    '    Dim criteria_book As String = String.Empty
    '    Dim outasset_id As String = String.Empty
    '    Dim tbl_trnOutasset As DataTable = New DataTable
    '    Dim criteria_outasset As String = String.Empty

    '    Dim tbl_show As DataTable = New DataTable
    '    Dim criteria_show As String = String.Empty

    '    Dim acara As String = String.Empty


    '    If Me.DgvMstAsset.Rows.Count > 0 Then

    '        criteria = String.Format(" asset_barcode = '{0}'", Me.DgvMstAsset.Rows(Me.DgvMstAsset.CurrentRow.Index).Cells("asset_barcode").Value)

    '        tbl_ask.Clear()
    '        Try
    '            Me.DataFill(tbl_ask, "as_MstAssetAlias_Select", criteria, Me._CHANNEL, Me.NumericUpDown1.Value)
    '            If tbl_ask.Rows.Count > 0 Then
    '                If tbl_ask.Rows(0).Item("asset_status").ToString = "AVL" Then
    '                    Try
    '                        criteria_ruang = String.Format(" ruang_id = '{0}'", tbl_ask.Rows(0).Item("ruang_id"))
    '                        Me.DataFill(tbl_ruang, "as_MstRuang_Select", criteria_ruang, Me._CHANNEL)

    '                        MsgBox("Goods is available in the room : " & vbCrLf & Trim(tbl_ruang.Rows(0).Item("ruang_name")) & _
    '                            " On the Floor " & tbl_ruang.Rows(0).Item("ruang_lantai") & vbCrLf & _
    '                            "In Rack : " & vbCrLf & tbl_ask.Rows(0).Item("asset_rak"))

    '                    Catch ex As Exception
    '                    End Try
    '                Else
    '                    Try
    '                        criteria_logasset = String.Format(" asset_barcode = '{0}' AND logasset_tanggal = '{1}' AND logasset_stat = 'Y'", _
    '                                            Me.DgvMstAsset.Rows(Me.DgvMstAsset.CurrentRow.Index).Cells("asset_barcode").Value, Format(Now, "MM/dd/yyyy"))
    '                        Me.DataFill(tbl_logasset, "as_MstLogAsset_Select", criteria_logasset)
    '                        If tbl_logasset.Rows.Count > 0 Then
    '                            If Mid(tbl_logasset.Rows(0).Item("logasset_notrans"), 1, 2) = "BO" Then
    '                                criteria_book = String.Format(" AND bookasset_id = '{0}'", tbl_logasset.Rows(0).Item("logasset_notrans"))
    '                                Me.DataFill(tbl_TrnBookasset, "as_TrnBookasset_Select", criteria_book, Me._CHANNEL, Me.NumericUpDown1.Value)
    '                                criteria_outasset = String.Format("AND outasset_id = '{0}'", tbl_TrnBookasset.Rows(0).Item("outasset_id"))
    '                                outasset_id = tbl_TrnBookasset.Rows(0).Item("outasset_id")
    '                            Else
    '                                criteria_outasset = String.Format("AND outasset_id = '{0}'", tbl_logasset.Rows(0).Item("logasset_notrans"))
    '                                outasset_id = tbl_logasset.Rows(0).Item("logasset_notrans")
    '                            End If
    '                            Me.DataFill(tbl_trnOutasset, "as_TrnOutasset_Select", criteria_outasset, Me._CHANNEL, Me.NumericUpDown1.Value)

    '                            If tbl_trnOutasset.Rows.Count > 0 Then
    '                                criteria_show = String.Format(" show_id = '{0}'", tbl_trnOutasset.Rows(0).Item("show_id"))
    '                                Me.DataFill(tbl_show, "as_MstShow_Select", criteria_show, Me._CHANNEL)
    '                            End If

    '                            MsgBox("Goods in use to show : " & vbCrLf & tbl_show.Rows(0).Item("show_title") & vbCrLf & _
    '                                    "On outgoing asset number : " & vbCrLf & outasset_id)
    '                        End If

    '                    Catch ex As Exception

    '                    End Try

    '                End If
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    End If
    'End Sub

    Private Sub Log_Asset()
        Dim tbl_logasset As DataTable = New DataTable
        Dim criteria As String = String.Empty

        If DgvMstAsset.Rows.Count <= 0 Then
            Exit Sub
        End If
        criteria = String.Format(" asset_barcode = '{0}'", Me.DgvMstAsset.Rows(Me.DgvMstAsset.CurrentRow.Index).Cells("asset_barcode").Value)
        Me.dgvLogAsset.DataSource = ""
        tbl_logasset.Clear()
        Try
            Me.DataFill(tbl_logasset, "as_MstLogAsset_Select30", criteria)
            Me.dgvLogAsset.DataSource = tbl_logasset

        Catch ex As Exception

        End Try
    End Sub



    Private Function cek_data() As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdSelect As OleDb.OleDbCommand

        Try
            dbConn.Open()
            dbCmdSelect = New OleDb.OleDbCommand("as_MstAssetStatus_Select", dbConn)
            dbCmdSelect.CommandType = CommandType.StoredProcedure
            dbCmdSelect.Parameters.Add("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40)
            dbCmdSelect.Parameters("@asset_barcode").Value = Me.DgvMstAsset.Rows(Me.DgvMstAsset.CurrentRow.Index).Cells("asset_barcode").Value
            dbCmdSelect.Parameters.Add("@ruang_name_out", System.Data.OleDb.OleDbType.VarWChar, 100).Direction = ParameterDirection.Output
            dbCmdSelect.Parameters.Add("@ruang_lantai_out", System.Data.OleDb.OleDbType.Integer).Direction = ParameterDirection.Output
            dbCmdSelect.Parameters.Add("@asset_rak_out", System.Data.OleDb.OleDbType.VarWChar, 40).Direction = ParameterDirection.Output
            dbCmdSelect.Parameters.Add("@show_title_out", System.Data.OleDb.OleDbType.VarWChar, 100).Direction = ParameterDirection.Output
            dbCmdSelect.Parameters.Add("@outasset_id_out", System.Data.OleDb.OleDbType.VarWChar, 30).Direction = ParameterDirection.Output
            dbCmdSelect.ExecuteNonQuery()

            If dbCmdSelect.Parameters("@outasset_id_out").Value = String.Empty Then
                MsgBox("Goods is available in the room : " & vbCrLf & Trim(dbCmdSelect.Parameters("@ruang_name_out").Value) & _
                    " On the Floor " & dbCmdSelect.Parameters("@ruang_lantai_out").Value & vbCrLf & vbCrLf & _
                    "In Rack : " & vbCrLf & dbCmdSelect.Parameters("@asset_rak_out").Value)
            Else
                MsgBox("Goods in use to show : " & vbCrLf & dbCmdSelect.Parameters("@show_title_out").Value & vbCrLf & vbCrLf & _
                                       "On outgoing asset number : " & vbCrLf & dbCmdSelect.Parameters("@outasset_id_out").Value)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


End Class