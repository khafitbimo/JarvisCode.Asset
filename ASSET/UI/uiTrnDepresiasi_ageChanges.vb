Public Class uiTrnDepresiasi_ageChanges
    Private Const mUiName As String = "Transaksi Depresiasi Age Changes"
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

    Private tbl_MstAsset As DataTable = clsDataset.CreateTblMstAsset(Me._CHANNEL)
    Private tbl_MstAsset_Temp As DataTable = clsDataset.CreateTblMstAsset(Me._CHANNEL)

    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_mstKategoriAsset As DataTable = clsDataset.CreateTblMstKategoriasset
    Private tbl_mstCurrency As DataTable = clsDataset.CreateTblMstCurrency


#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TTV"
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
        Me.uiTrnDepresiasi_ageChanges_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_ageChanges_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        hitung_jumlahDeprePerbulan_baru()
        If Me.uiTrnDepresiasi_ageChanges_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_ageChanges_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_ageChanges_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_ageChanges_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_ageChanges_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_ageChanges_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_ageChanges_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnDepresiasi_ageChanges_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region


#Region " Layout & Init UI "

    Private Function FormatDgvMstAsset(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvMstAsset Columns 
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
        Dim cIs_useable As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cAsset_active As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
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
        Dim cGolongan_pajak As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "Terimabarang ID"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 120
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = False

        cAsset_line.Name = "asset_line"
        cAsset_line.HeaderText = "asset_line"
        cAsset_line.DataPropertyName = "asset_line"
        cAsset_line.Width = 100
        cAsset_line.Visible = False
        cAsset_line.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = False

        cAsset_tgl.Name = "asset_tgl"
        cAsset_tgl.HeaderText = "asset_tgl"
        cAsset_tgl.DataPropertyName = "asset_tgl"
        cAsset_tgl.Width = 100
        cAsset_tgl.Visible = False
        cAsset_tgl.ReadOnly = False

        cTipeasset_id.Name = "tipeasset_id"
        cTipeasset_id.HeaderText = "tipeasset_id"
        cTipeasset_id.DataPropertyName = "tipeasset_id"
        cTipeasset_id.Width = 100
        cTipeasset_id.Visible = False
        cTipeasset_id.ReadOnly = False

        cKategoriasset_id.Name = "kategoriasset_id"
        cKategoriasset_id.HeaderText = "Kategori Asset"
        cKategoriasset_id.DataPropertyName = "kategoriasset_id"
        cKategoriasset_id.Width = 120
        cKategoriasset_id.Visible = True
        cKategoriasset_id.ReadOnly = False

        cAsset_barcode.Name = "asset_barcode"
        cAsset_barcode.HeaderText = "Barcode"
        cAsset_barcode.DataPropertyName = "asset_barcode"
        cAsset_barcode.Width = 100
        cAsset_barcode.Visible = True
        cAsset_barcode.ReadOnly = False

        cAsset_lineinduk.Name = "asset_lineinduk"
        cAsset_lineinduk.HeaderText = "asset_lineinduk"
        cAsset_lineinduk.DataPropertyName = "asset_lineinduk"
        cAsset_lineinduk.Width = 100
        cAsset_lineinduk.Visible = False
        cAsset_lineinduk.ReadOnly = False

        cAsset_barcodeinduk.Name = "asset_barcodeinduk"
        cAsset_barcodeinduk.HeaderText = "asset_barcodeinduk"
        cAsset_barcodeinduk.DataPropertyName = "asset_barcodeinduk"
        cAsset_barcodeinduk.Width = 100
        cAsset_barcodeinduk.Visible = False
        cAsset_barcodeinduk.ReadOnly = False

        cAsset_serial.Name = "asset_serial"
        cAsset_serial.HeaderText = "asset_serial"
        cAsset_serial.DataPropertyName = "asset_serial"
        cAsset_serial.Width = 100
        cAsset_serial.Visible = False
        cAsset_serial.ReadOnly = False

        cAsset_produknumber.Name = "asset_produknumber"
        cAsset_produknumber.HeaderText = "asset_produknumber"
        cAsset_produknumber.DataPropertyName = "asset_produknumber"
        cAsset_produknumber.Width = 100
        cAsset_produknumber.Visible = False
        cAsset_produknumber.ReadOnly = False

        cAsset_model.Name = "asset_model"
        cAsset_model.HeaderText = "asset_model"
        cAsset_model.DataPropertyName = "asset_model"
        cAsset_model.Width = 100
        cAsset_model.Visible = False
        cAsset_model.ReadOnly = False

        cAsset_deskripsi.Name = "asset_deskripsi"
        cAsset_deskripsi.HeaderText = "Deskripsi"
        cAsset_deskripsi.DataPropertyName = "asset_deskripsi"
        cAsset_deskripsi.Width = 200
        cAsset_deskripsi.Visible = True
        cAsset_deskripsi.ReadOnly = False

        cKategoriitem_id.Name = "kategoriitem_id"
        cKategoriitem_id.HeaderText = "kategoriitem_id"
        cKategoriitem_id.DataPropertyName = "kategoriitem_id"
        cKategoriitem_id.Width = 100
        cKategoriitem_id.Visible = False
        cKategoriitem_id.ReadOnly = False

        cTipeitem_id.Name = "tipeitem_id"
        cTipeitem_id.HeaderText = "tipeitem_id"
        cTipeitem_id.DataPropertyName = "tipeitem_id"
        cTipeitem_id.Width = 100
        cTipeitem_id.Visible = False
        cTipeitem_id.ReadOnly = False

        cAsset_golfiskal.Name = "asset_golfiskal"
        cAsset_golfiskal.HeaderText = "asset_golfiskal"
        cAsset_golfiskal.DataPropertyName = "asset_golfiskal"
        cAsset_golfiskal.Width = 100
        cAsset_golfiskal.Visible = False
        cAsset_golfiskal.ReadOnly = False

        cAsset_tipedepre.Name = "asset_tipedepre"
        cAsset_tipedepre.HeaderText = "asset_tipedepre"
        cAsset_tipedepre.DataPropertyName = "asset_tipedepre"
        cAsset_tipedepre.Width = 100
        cAsset_tipedepre.Visible = False
        cAsset_tipedepre.ReadOnly = False

        cAsset_depre_enddt.Name = "asset_depre_enddt"
        cAsset_depre_enddt.HeaderText = "End Depre"
        cAsset_depre_enddt.DataPropertyName = "asset_depre_enddt"
        cAsset_depre_enddt.Width = 100
        cAsset_depre_enddt.Visible = False
        cAsset_depre_enddt.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = False

        cAsset_harga.Name = "asset_harga"
        cAsset_harga.HeaderText = "asset_harga"
        cAsset_harga.DataPropertyName = "asset_harga"
        cAsset_harga.Width = 100
        cAsset_harga.Visible = False
        cAsset_harga.ReadOnly = False

        cAsset_hargabaru.Name = "asset_hargabaru"
        cAsset_hargabaru.HeaderText = "Amount After Depre."
        cAsset_hargabaru.DataPropertyName = "asset_hargabaru"
        cAsset_hargabaru.Width = 150
        cAsset_hargabaru.Visible = True
        cAsset_hargabaru.ReadOnly = False
        cAsset_hargabaru.DefaultCellStyle.Format = "#,##0.00"

        cAsset_ppn.Name = "asset_ppn"
        cAsset_ppn.HeaderText = "asset_ppn"
        cAsset_ppn.DataPropertyName = "asset_ppn"
        cAsset_ppn.Width = 100
        cAsset_ppn.Visible = True
        cAsset_ppn.ReadOnly = False

        cAsset_pph.Name = "asset_pph"
        cAsset_pph.HeaderText = "asset_pph"
        cAsset_pph.DataPropertyName = "asset_pph"
        cAsset_pph.Width = 100
        cAsset_pph.Visible = False
        cAsset_pph.ReadOnly = False

        cAsset_disc.Name = "asset_disc"
        cAsset_disc.HeaderText = "asset_disc"
        cAsset_disc.DataPropertyName = "asset_disc"
        cAsset_disc.Width = 100
        cAsset_disc.Visible = False
        cAsset_disc.ReadOnly = False

        cAsset_depresiasi.Name = "asset_depresiasi"
        cAsset_depresiasi.HeaderText = "Times"
        cAsset_depresiasi.DataPropertyName = "asset_depresiasi"
        cAsset_depresiasi.Width = 100
        cAsset_depresiasi.Visible = True
        cAsset_depresiasi.ReadOnly = False

        cAsset_akum_val_depre.Name = "asset_akum_val_depre"
        cAsset_akum_val_depre.HeaderText = "Amount Depre. Sum"
        cAsset_akum_val_depre.DataPropertyName = "asset_akum_val_depre"
        cAsset_akum_val_depre.Width = 130
        cAsset_akum_val_depre.Visible = True
        cAsset_akum_val_depre.ReadOnly = False
        cAsset_akum_val_depre.DefaultCellStyle.Format = "#,##0.00"

        cAsset_valas.Name = "asset_valas"
        cAsset_valas.HeaderText = "Rate"
        cAsset_valas.DataPropertyName = "asset_valas"
        cAsset_valas.Width = 100
        cAsset_valas.Visible = True
        cAsset_valas.ReadOnly = False

        cAsset_idrprice.Name = "asset_idrprice"
        cAsset_idrprice.HeaderText = "Amount"
        cAsset_idrprice.DataPropertyName = "asset_idrprice"
        cAsset_idrprice.Width = 130
        cAsset_idrprice.Visible = True
        cAsset_idrprice.ReadOnly = False
        cAsset_idrprice.DefaultCellStyle.Format = "#,##0.00"

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cEmployee_id_owner.Name = "employee_id_owner"
        cEmployee_id_owner.HeaderText = "employee_id_owner"
        cEmployee_id_owner.DataPropertyName = "employee_id_owner"
        cEmployee_id_owner.Width = 100
        cEmployee_id_owner.Visible = False
        cEmployee_id_owner.ReadOnly = False

        cBrand_id.Name = "brand_id"
        cBrand_id.HeaderText = "brand_id"
        cBrand_id.DataPropertyName = "brand_id"
        cBrand_id.Width = 100
        cBrand_id.Visible = False
        cBrand_id.ReadOnly = False

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "unit_id"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 100
        cUnit_id.Visible = False
        cUnit_id.ReadOnly = False

        cAsset_qty.Name = "asset_qty"
        cAsset_qty.HeaderText = "asset_qty"
        cAsset_qty.DataPropertyName = "asset_qty"
        cAsset_qty.Width = 100
        cAsset_qty.Visible = False
        cAsset_qty.ReadOnly = False

        cMaterial_id.Name = "material_id"
        cMaterial_id.HeaderText = "material_id"
        cMaterial_id.DataPropertyName = "material_id"
        cMaterial_id.Width = 100
        cMaterial_id.Visible = False
        cMaterial_id.ReadOnly = False

        cWarna_id.Name = "warna_id"
        cWarna_id.HeaderText = "warna_id"
        cWarna_id.DataPropertyName = "warna_id"
        cWarna_id.Width = 100
        cWarna_id.Visible = False
        cWarna_id.ReadOnly = False

        cUkuran_id.Name = "ukuran_id"
        cUkuran_id.HeaderText = "ukuran_id"
        cUkuran_id.DataPropertyName = "ukuran_id"
        cUkuran_id.Width = 100
        cUkuran_id.Visible = False
        cUkuran_id.ReadOnly = False

        cJeniskelamin_id.Name = "jeniskelamin_id"
        cJeniskelamin_id.HeaderText = "jeniskelamin_id"
        cJeniskelamin_id.DataPropertyName = "jeniskelamin_id"
        cJeniskelamin_id.Width = 100
        cJeniskelamin_id.Visible = False
        cJeniskelamin_id.ReadOnly = False

        cShow_id_cont_item.Name = "show_id_cont_item"
        cShow_id_cont_item.HeaderText = "show_id_cont_item"
        cShow_id_cont_item.DataPropertyName = "show_id_cont_item"
        cShow_id_cont_item.Width = 100
        cShow_id_cont_item.Visible = False
        cShow_id_cont_item.ReadOnly = False

        cRuang_id.Name = "ruang_id"
        cRuang_id.HeaderText = "ruang_id"
        cRuang_id.DataPropertyName = "ruang_id"
        cRuang_id.Width = 100
        cRuang_id.Visible = False
        cRuang_id.ReadOnly = False

        cAsset_rak.Name = "asset_rak"
        cAsset_rak.HeaderText = "asset_rak"
        cAsset_rak.DataPropertyName = "asset_rak"
        cAsset_rak.Width = 100
        cAsset_rak.Visible = False
        cAsset_rak.ReadOnly = False

        cIs_useable.Name = "is_useable"
        cIs_useable.HeaderText = "is_useable"
        cIs_useable.DataPropertyName = "is_useable"
        cIs_useable.Width = 100
        cIs_useable.Visible = False
        cIs_useable.ReadOnly = False

        cAsset_active.Name = "asset_active"
        cAsset_active.HeaderText = "IsActive"
        cAsset_active.DataPropertyName = "asset_active"
        cAsset_active.Width = 100
        cAsset_active.Visible = True
        cAsset_active.ReadOnly = False

        cAsset_status.Name = "asset_status"
        cAsset_status.HeaderText = "asset_status"
        cAsset_status.DataPropertyName = "asset_status"
        cAsset_status.Width = 100
        cAsset_status.Visible = False
        cAsset_status.ReadOnly = False

        cProject_id.Name = "project_id"
        cProject_id.HeaderText = "project_id"
        cProject_id.DataPropertyName = "project_id"
        cProject_id.Width = 100
        cProject_id.Visible = False
        cProject_id.ReadOnly = False

        cShow_id.Name = "show_id"
        cShow_id.HeaderText = "show_id"
        cShow_id.DataPropertyName = "show_id"
        cShow_id.Width = 100
        cShow_id.Visible = False
        cShow_id.ReadOnly = False

        cAsset_eps.Name = "asset_eps"
        cAsset_eps.HeaderText = "asset_eps"
        cAsset_eps.DataPropertyName = "asset_eps"
        cAsset_eps.Width = 100
        cAsset_eps.Visible = False
        cAsset_eps.ReadOnly = False

        cWo_id.Name = "wo_id"
        cWo_id.HeaderText = "wo_id"
        cWo_id.DataPropertyName = "wo_id"
        cWo_id.Width = 100
        cWo_id.Visible = False
        cWo_id.ReadOnly = False

        cWo_date.Name = "wo_date"
        cWo_date.HeaderText = "wo_date"
        cWo_date.DataPropertyName = "wo_date"
        cWo_date.Width = 100
        cWo_date.Visible = False
        cWo_date.ReadOnly = False

        cInputby.Name = "inputby"
        cInputby.HeaderText = "inputby"
        cInputby.DataPropertyName = "inputby"
        cInputby.Width = 100
        cInputby.Visible = False
        cInputby.ReadOnly = False

        cInputdt.Name = "inputdt"
        cInputdt.HeaderText = "inputdt"
        cInputdt.DataPropertyName = "inputdt"
        cInputdt.Width = 100
        cInputdt.Visible = False
        cInputdt.ReadOnly = False

        cEditby.Name = "editby"
        cEditby.HeaderText = "editby"
        cEditby.DataPropertyName = "editby"
        cEditby.Width = 100
        cEditby.Visible = False
        cEditby.ReadOnly = False

        cEditdt.Name = "editdt"
        cEditdt.HeaderText = "editdt"
        cEditdt.DataPropertyName = "editdt"
        cEditdt.Width = 100
        cEditdt.Visible = False
        cEditdt.ReadOnly = False

        cUsedby.Name = "usedby"
        cUsedby.HeaderText = "usedby"
        cUsedby.DataPropertyName = "usedby"
        cUsedby.Width = 100
        cUsedby.Visible = False
        cUsedby.ReadOnly = False

        cAsset_deprebulanan.Name = "asset_deprebulanan"
        cAsset_deprebulanan.HeaderText = "Depre / Mounth"
        cAsset_deprebulanan.DataPropertyName = "asset_deprebulanan"
        cAsset_deprebulanan.Width = 130
        cAsset_deprebulanan.Visible = True
        cAsset_deprebulanan.ReadOnly = False
        cAsset_deprebulanan.DefaultCellStyle.Format = "#,##0.00"

        cAsset_stdepre.Name = "asset_stdepre"
        cAsset_stdepre.HeaderText = "Start Depre"
        cAsset_stdepre.DataPropertyName = "asset_stdepre"
        cAsset_stdepre.Width = 100
        cAsset_stdepre.Visible = True
        cAsset_stdepre.ReadOnly = False

        cAsset_eddepre.Name = "asset_eddepre"
        cAsset_eddepre.HeaderText = "End Depre"
        cAsset_eddepre.DataPropertyName = "asset_eddepre"
        cAsset_eddepre.Width = 100
        cAsset_eddepre.Visible = True
        cAsset_eddepre.ReadOnly = False

        cGolongan_pajak.Name = "golongan_pajak"
        cGolongan_pajak.HeaderText = "golongan_pajak"
        cGolongan_pajak.DataPropertyName = "golongan_pajak"
        cGolongan_pajak.Width = 100
        cGolongan_pajak.Visible = False
        cGolongan_pajak.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimabarang_id, cAsset_line, cChannel_id, cAsset_tgl, cTipeasset_id, cKategoriasset_id, cAsset_barcode, cAsset_lineinduk, cAsset_barcodeinduk, cAsset_serial, cAsset_produknumber, cAsset_model, cAsset_deskripsi, cKategoriitem_id, cTipeitem_id, cAsset_golfiskal, cAsset_tipedepre, cAsset_depre_enddt, cCurrency_id, cAsset_harga, cAsset_hargabaru, cAsset_ppn, cAsset_pph, cAsset_disc, cAsset_depresiasi, cAsset_akum_val_depre, cAsset_valas, cAsset_idrprice, cStrukturunit_id, cEmployee_id_owner, cBrand_id, cUnit_id, cAsset_qty, cMaterial_id, cWarna_id, cUkuran_id, cJeniskelamin_id, cShow_id_cont_item, cRuang_id, cAsset_rak, cIs_useable, cAsset_active, cAsset_status, cProject_id, cShow_id, cAsset_eps, cWo_id, cWo_date, cInputby, cInputdt, cEditby, cEditdt, cUsedby, cAsset_deprebulanan, cAsset_stdepre, cAsset_eddepre, cGolongan_pajak})

        ' DgvMstAsset Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False

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
        Me.DgvMstAsset.Dock = DockStyle.Fill

        Me.FormatDgvMstAsset(Me.DgvMstAsset)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Terimabarang_id.DataBindings.Clear()
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Kategoriasset_id.DataBindings.Clear()
        Me.obj_Asset_barcode.DataBindings.Clear()
        Me.obj_Asset_deskripsi.DataBindings.Clear()
        Me.obj_Currency_id.DataBindings.Clear()
        Me.obj_Asset_hargabaru.DataBindings.Clear()
        Me.obj_Asset_depresiasi.DataBindings.Clear()
        Me.obj_Asset_akum_val_depre.DataBindings.Clear()
        Me.obj_Asset_valas.DataBindings.Clear()
        Me.obj_Asset_idrprice.DataBindings.Clear()
        Me.obj_Asset_active.DataBindings.Clear()
        Me.obj_Asset_deprebulanan.DataBindings.Clear()
        Me.obj_Asset_stdepre.DataBindings.Clear()
        Me.obj_Asset_eddepre.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Terimabarang_id.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "terimabarang_id"))
        Me.obj_Channel_id.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "channel_id"))
        Me.obj_Kategoriasset_id.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "kategoriasset_id"))
        Me.obj_Asset_barcode.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_barcode"))
        Me.obj_Asset_deskripsi.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_deskripsi"))
        Me.obj_Currency_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstAsset_Temp, "currency_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_hargabaru.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_hargabaru", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_depresiasi.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_depresiasi"))
        Me.obj_Asset_akum_val_depre.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_akum_val_depre", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_valas.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_valas", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_idrprice.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_idrprice", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_active.DataBindings.Add(New Binding("Checked", Me.tbl_MstAsset_Temp, "asset_active"))
        Me.obj_Asset_deprebulanan.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_deprebulanan", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_stdepre.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_stdepre"))
        Me.obj_Asset_eddepre.DataBindings.Add(New Binding("Text", Me.tbl_MstAsset_Temp, "asset_eddepre"))
        Return True
    End Function

#End Region


#Region " Dialoged Control "
#End Region


#Region " User Defined Function "

    Private Function uiTrnDepresiasi_ageChanges_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_MstAsset_Temp
        Me.tbl_MstAsset_Temp.Clear()




        Me.BindingContext(Me.tbl_MstAsset_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_MstAsset_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function uiTrnDepresiasi_ageChanges_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = " asset_active = 1"

        ' TODO: Parse Criteria using clsProc.RefParser()

        If Me.chkSearchChannel.Checked = True Then
            If criteria = String.Empty Then
                criteria = String.Format(" channel_id = '{0}'", Me.cboSearchChannel.SelectedValue)
            Else
                criteria &= String.Format(" AND channel_id = '{0}'", Me.cboSearchChannel.SelectedValue)
            End If
        End If

        If Me.chkSearchCategory.Checked = True Then
            If criteria = String.Empty Then
                criteria = String.Format(" kategoriasset_id = '{0}'", Me.cboSearchkategori.SelectedValue)
            Else
                criteria &= String.Format(" AND kategoriasset_id = '{0}'", Me.cboSearchkategori.SelectedValue)
            End If
        End If

        If Me.chkSearchBarcode.Checked = True Then
            If criteria = String.Empty Then
                criteria = String.Format(" asset_barcode = '{0}'", Me.txtSearchBarcode.Text)
            Else
                criteria &= String.Format(" AND asset_barcode = '{0}'", Me.txtSearchBarcode.Text)
            End If
        End If
        Me.tbl_MstAsset.Clear()
        Try
            Me.DataFill(Me.tbl_MstAsset, "as_MstAssetFinance_Select", criteria, Me._CHANNEL)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiTrnDepresiasi_ageChanges_Save() As Boolean
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
                    success = Me.uiTrnDepresiasi_ageChanges_SaveMaster(asset_barcode, tbl_MstAsset_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnDepresiasi_ageChanges_SaveMaster(tbl_MstAsset_Temp_Changes)")
                    Me.tbl_MstAsset_Temp.AcceptChanges()
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

        RaiseEvent FormAfterSave(asset_barcode, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnDepresiasi_ageChanges_SaveMaster(ByRef asset_barcode As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: master_asset_finance
        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnDepresiasiAgeChanges_Insert", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deskripsi", System.Data.OleDb.OleDbType.VarWChar, 400, "asset_deskripsi"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_hargabaru", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_hargabaru", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_depresiasi", System.Data.OleDb.OleDbType.Integer, 4, "asset_depresiasi"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_akum_val_depre", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_akum_val_depre", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_valas", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_valas", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_idrprice", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_idrprice", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_active", System.Data.OleDb.OleDbType.Boolean, 1, "asset_active"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deprebulanan", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_deprebulanan", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_stdepre", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_stdepre"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_eddepre", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_eddepre"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modify_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters("@modify_by").Value = Me.UserName
        dbCmdUpdate.Parameters("@modify_date").Value = Now.Date

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate


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

    Private Function uiTrnDepresiasi_ageChanges_Print() As Boolean
        'print data
    End Function

    Private Function uiTrnDepresiasi_ageChanges_Delete() As Boolean
        Dim res As String = ""
        Dim asset_barcode As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(asset_barcode)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvMstAsset.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnDepresiasi_ageChanges_DeleteRow(Me.DgvMstAsset.CurrentRow.Index)
            End If
        End If

        RaiseEvent FormAfterDelete(asset_barcode)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnDepresiasi_ageChanges_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim asset_barcode As String
        Dim NewRowIndex As Integer

        asset_barcode = Me.DgvMstAsset.Rows(rowIndex).Cells("asset_barcode").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_MstAsset_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@terimabarang_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_line", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@asset_line").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
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
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deskripsi", System.Data.OleDb.OleDbType.VarWChar, 400))
        dbCmdDelete.Parameters("@asset_deskripsi").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@kategoriitem_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeitem_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@tipeitem_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_golfiskal", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@asset_golfiskal").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tipedepre", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdDelete.Parameters("@asset_tipedepre").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_depre_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@asset_depre_enddt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@currency_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_harga", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@asset_harga").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_hargabaru", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@asset_hargabaru").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_ppn", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@asset_ppn").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_pph", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@asset_pph").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_disc", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@asset_disc").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_depresiasi", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@asset_depresiasi").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_akum_val_depre", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@asset_akum_val_depre").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_valas", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@asset_valas").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_idrprice", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@asset_idrprice").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@strukturunit_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@employee_id_owner").Value = DBNull.Value
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
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@ruang_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_rak", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters("@asset_rak").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@is_useable").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_active", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@asset_active").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@asset_status").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@project_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@show_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_eps", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@asset_eps").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wo_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@wo_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wo_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@wo_date").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@inputby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@inputdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@editby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@editdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@usedby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@usedby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deprebulanan", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@asset_deprebulanan").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_stdepre", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@asset_stdepre").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_eddepre", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@asset_eddepre").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@golongan_pajak", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@golongan_pajak").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvMstAsset.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnDepresiasi_ageChanges_OpenRow(NewRowIndex)
                    Me.tbl_MstAsset.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvMstAsset.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnDepresiasi_ageChanges_OpenRow(NewRowIndex)
                    Me.tbl_MstAsset.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_MstAsset.Rows.RemoveAt(rowIndex)
                    Me.uiTrnDepresiasi_ageChanges_OpenRow(rowIndex)
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

    Private Function uiTrnDepresiasi_ageChanges_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim asset_barcode As String

        asset_barcode = Me.DgvMstAsset.Rows(rowIndex).Cells("asset_barcode").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(asset_barcode)


        Try
            dbConn.Open()
            Me.uiTrnDepresiasi_ageChanges_OpenRowMaster(Me._CHANNEL, asset_barcode, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnDepresiasi_ageChanges_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(asset_barcode)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiTrnDepresiasi_ageChanges_OpenRowMaster(ByVal channel_id As String, ByVal asset_barcode As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_MstAssetFinance_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("asset_barcode = '{0}'", asset_barcode)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstAsset_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_MstAsset_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnDepresiasi_ageChanges_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnDepresiasi_ageChanges_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnDepresiasi_ageChanges_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstAsset.CurrentCell = Me.DgvMstAsset(1, 0)
            Me.uiTrnDepresiasi_ageChanges_RefreshPosition()
        End If
    End Function

    Private Function uiTrnDepresiasi_ageChanges_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnDepresiasi_ageChanges_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstAsset.CurrentCell.RowIndex > 0 Then
                Me.DgvMstAsset.CurrentCell = Me.DgvMstAsset(1, DgvMstAsset.CurrentCell.RowIndex - 1)
                Me.uiTrnDepresiasi_ageChanges_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnDepresiasi_ageChanges_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnDepresiasi_ageChanges_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstAsset.CurrentCell.RowIndex < Me.DgvMstAsset.Rows.Count - 1 Then
                Me.DgvMstAsset.CurrentCell = Me.DgvMstAsset(1, DgvMstAsset.CurrentCell.RowIndex + 1)
                Me.uiTrnDepresiasi_ageChanges_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnDepresiasi_ageChanges_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnDepresiasi_ageChanges_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstAsset.CurrentCell = Me.DgvMstAsset(1, Me.DgvMstAsset.Rows.Count - 1)
            Me.uiTrnDepresiasi_ageChanges_RefreshPosition()
        End If
    End Function

    Private Function uiTrnDepresiasi_ageChanges_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnDepresiasi_ageChanges_OpenRow(Me.DgvMstAsset.CurrentRow.Index)
    End Function

    Private Function uiTrnDepresiasi_ageChanges_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
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
                                success = Me.uiTrnDepresiasi_ageChanges_SaveMaster(asset_barcode, tbl_MstAsset_Temp_Changes, MasterDataState)
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

    Private Function uiTrnDepresiasi_ageChanges_FormError() As Boolean
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


        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        End If

        Me.InitLayoutUI()

        Me.DgvMstAsset.DataSource = Me.tbl_MstAsset
        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....

            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", Me.tbl_MstChannelSearch, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'")
            Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_id"
            Me.ComboFill(Me.cboSearchkategori, "kategoriasset_id", "kategoriasset_id", Me.tbl_mstKategoriAsset, "as_MstKategoriasset_Select", "  ")
            Me.tbl_mstKategoriAsset.DefaultView.Sort = "kategoriasset_id"
            Me.ComboFill(Me.obj_Currency_id, "Currency_id", "Currency_shortname", Me.tbl_mstCurrency, "ms_MstCurrency_Select", "  Currency_active = 1")
            Me.tbl_mstCurrency.DefaultView.Sort = "Currency_shortname"

        End If

        Me.BindingStop()
        Me.BindingStart()

        Me.chkSearchChannel.Checked = True
        Me.chkSearchChannel.Enabled = False
        Me.cboSearchChannel.SelectedValue = Me._CHANNEL
        Me.cboSearchChannel.Enabled = False

        Me.uiTrnDepresiasi_ageChanges_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True
    End Sub



    Private Sub uiTrnDepresiasi_ageChanges_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White

                If Me.DgvMstAsset.CurrentRow IsNot Nothing Then
                    Me.uiTrnDepresiasi_ageChanges_OpenRow(Me.DgvMstAsset.CurrentRow.Index)
                Else
                    Me.uiTrnDepresiasi_ageChanges_NewData()
                End If
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

    Private Sub obj_Asset_eddepre_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Asset_eddepre.Validated
        hitung_jumlahDeprePerbulan_baru()
    End Sub
    Private Sub hitung_jumlahDeprePerbulan_baru()
        Try
            Dim ssql As String
            Dim da As OleDb.OleDbDataAdapter
            Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            Dim tbl_depresiasidetil_temps As DataTable = New DataTable

            Dim jumlahTanggal As Integer

            ssql = String.Format("SELECT * FROM ASSET.E_ASSET.dbo.transaksi_depresiasidetil WHERE asset_barcode = '{0}' ORDER BY create_dt DESC", _
                           obj_Asset_barcode.Text)
            Try
                da = New OleDb.OleDbDataAdapter(ssql, dbConn)
                tbl_depresiasidetil_temps.Clear()
                da.Fill(tbl_depresiasidetil_temps)
                If tbl_depresiasidetil_temps.Rows.Count > 0 Then
                    jumlahTanggal = (DateDiff(DateInterval.Month, obj_Asset_stdepre.Value, obj_Asset_eddepre.Value))
                    obj_Asset_deprebulanan.Text = Format(CDec(Me.obj_Asset_idrprice.Text) / jumlahTanggal, "#,##0.00")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class