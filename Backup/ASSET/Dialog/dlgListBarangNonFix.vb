
Public Class dlgListBarangNonFix
    Private CloseButtonIsPressed As Boolean
    Private channel As String
    Private dsn As String
    Private listBarcode As String
    Private param As Integer
    Private strukturUnit_id As Decimal
    Private barcode As String

    Private tbl_MstAsset As DataTable = clsDataset.CreateTblMstAsset(channel)

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As String
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = String.Empty
        Dim tabell As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)

        Dim row As Integer
        Dim maxRow As Integer

        If param = 1 Then
            criteria = String.Format("strukturunit_id = {0} and is_useable = 1", Me.strukturUnit_id)
        ElseIf param = 3 Then
            criteria = String.Format("right(asset_barcode,3) = '000' and is_useable = 0")
        Else
            criteria = String.Format("strukturunit_id = {0} and right(asset_barcode,3) = '000' and is_useable = 0", strukturUnit_id)
            'criteria = String.Format("is_useable = 0")
        End If

        Try
            tabell.Rows.Clear()
            oDataFiller.DataFill(tabell, "as_TrnTerimabarang_Select_ListNonFix", criteria, Me.channel)
            Me.DgvListBarangNonFix.DataSource = tabell
            Me.FormatDgvListBarangNonFix(Me.DgvListBarangNonFix)
            tabell.Columns.Add("select", GetType(System.Boolean))
            tabell.Columns("select").DefaultValue = 0

            If param <> 1 Then
                maxRow = Me.DgvListBarangNonFix.RowCount - 1
                For row = 0 To maxRow
                    If Me.DgvListBarangNonFix.Item("asset_barcode", row).Value = Me.barcode Then
                        Me.DgvListBarangNonFix.Item("select", row).Value = True
                        'Exit For
                    End If
                Next
            End If
        Catch ex As Exception
        End Try

        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.listBarcode
        Else
            Return Nothing
        End If
    End Function
    Private Function FormatDgvListBarangNonFix(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Dim cCurrency_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_harga As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_hargabaru As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategoriitem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTipeitem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBrand_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBrand_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMaterial_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWarna_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUkuran_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJeniskelamin_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id_cont_item As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIs_active As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIs_useable As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_owner As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWo_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRuang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_rak As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_ppn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_pph As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_disc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_depresiasi As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_totdep As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cProject_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cProject_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id_string As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_valas As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_idrprice As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_akum_depre As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_akum_val_depre As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cSelect.Name = "select"
        cSelect.HeaderText = "Select"
        cSelect.DataPropertyName = "select"
        cSelect.Width = 50
        cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cSelect.Frozen = True
        cSelect.Visible = True
        cSelect.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 75
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

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
        cKategoriasset_id.Width = 150
        cKategoriasset_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriasset_id.Visible = False
        cKategoriasset_id.ReadOnly = False

        cAsset_barcode.Name = "asset_barcode"
        cAsset_barcode.HeaderText = "Barcode"
        cAsset_barcode.DataPropertyName = "asset_barcode"
        cAsset_barcode.Width = 130
        cAsset_barcode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_barcode.Visible = True
        cAsset_barcode.ReadOnly = True

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
        cAsset_serial.Width = 150
        cAsset_serial.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_serial.Visible = False
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
        cAsset_deskripsi.Width = 180
        cAsset_deskripsi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_deskripsi.Visible = True
        cAsset_deskripsi.ReadOnly = True

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Currency"
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 50
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

        cKategoriitem_id.Name = "kategoriitem_id"
        cKategoriitem_id.HeaderText = "Kategori"
        cKategoriitem_id.DataPropertyName = "kategoriitem_id"
        cKategoriitem_id.Width = 150
        cKategoriitem_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cKategoriitem_id.Visible = True
        cKategoriitem_id.ReadOnly = True

        cTipeitem_id.Name = "tipeitem_id"
        cTipeitem_id.HeaderText = "Tipe"
        cTipeitem_id.DataPropertyName = "tipeitem_id"
        cTipeitem_id.Width = 130
        cTipeitem_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTipeitem_id.Visible = True
        cTipeitem_id.ReadOnly = True

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 150
        cStrukturunit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cStrukturunit_id_string.Name = "strukturunit_id_string"
        cStrukturunit_id_string.HeaderText = "Struktur Unit"
        cStrukturunit_id_string.DataPropertyName = "strukturunit_id_string"
        cStrukturunit_id_string.Width = 150
        cStrukturunit_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStrukturunit_id_string.Visible = False
        cStrukturunit_id_string.ReadOnly = False

        cBrand_id.Name = "brand_id"
        cBrand_id.HeaderText = "brand_id"
        cBrand_id.DataPropertyName = "brand_id"
        cBrand_id.Width = 100
        cBrand_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBrand_id.Visible = False
        cBrand_id.ReadOnly = False

        cBrand_id_string.Name = "brand_id_string"
        cBrand_id_string.HeaderText = "Brand"
        cBrand_id_string.DataPropertyName = "brand_id_string"
        cBrand_id_string.Width = 100
        cBrand_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBrand_id_string.Visible = False
        cBrand_id_string.ReadOnly = False

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "Unit"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 100
        cUnit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUnit_id.Visible = False
        cUnit_id.ReadOnly = False

        cUnit_id_string.Name = "unit_id_string"
        cUnit_id_string.HeaderText = "Unit"
        cUnit_id_string.DataPropertyName = "unit_id_string"
        cUnit_id_string.Width = 100
        cUnit_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUnit_id_string.Visible = False
        cUnit_id_string.ReadOnly = False

        cAsset_qty.Name = "asset_qty"
        cAsset_qty.HeaderText = "Qty"
        cAsset_qty.DataPropertyName = "asset_qty"
        cAsset_qty.Width = 100
        cAsset_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_qty.Visible = False
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

        cIs_active.Name = "is_active"
        cIs_active.HeaderText = "is_active"
        cIs_active.DataPropertyName = "is_active"
        cIs_active.Width = 100
        cIs_active.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cIs_active.Visible = False
        cIs_active.ReadOnly = False

        cIs_useable.Name = "is_useable"
        cIs_useable.HeaderText = "is_useable"
        cIs_useable.DataPropertyName = "is_useable"
        cIs_useable.Width = 100
        cIs_useable.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cIs_useable.Visible = False
        cIs_useable.ReadOnly = False

        cAsset_status.Name = "asset_status"
        cAsset_status.HeaderText = "Status"
        cAsset_status.DataPropertyName = "asset_status"
        cAsset_status.Width = 100
        cAsset_status.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_status.Visible = False
        cAsset_status.ReadOnly = False

        cEmployee_id_owner.Name = "employee_id_owner"
        cEmployee_id_owner.HeaderText = "Employee"
        cEmployee_id_owner.DataPropertyName = "employee_id_owner"
        cEmployee_id_owner.Width = 100
        cEmployee_id_owner.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEmployee_id_owner.Visible = False
        cEmployee_id_owner.ReadOnly = False

        cWo_id.Name = "wo_id"
        cWo_id.HeaderText = "wo_id"
        cWo_id.DataPropertyName = "wo_id"
        cWo_id.Width = 100
        cWo_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cWo_id.Visible = False
        cWo_id.ReadOnly = False

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

        cAsset_totdep.Name = "asset_totdep"
        cAsset_totdep.HeaderText = "asset_totdep"
        cAsset_totdep.DataPropertyName = "asset_totdep"
        cAsset_totdep.Width = 100
        cAsset_totdep.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_totdep.Visible = False
        cAsset_totdep.ReadOnly = False

        cProject_id.Name = "project_id"
        cProject_id.HeaderText = "project_id"
        cProject_id.DataPropertyName = "project_id"
        cProject_id.Width = 100
        cProject_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProject_id.Visible = False
        cProject_id.ReadOnly = False

        cProject_id_string.Name = "project_id_string"
        cProject_id_string.HeaderText = "Project"
        cProject_id_string.DataPropertyName = "project_id_string"
        cProject_id_string.Width = 100
        cProject_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProject_id_string.Visible = False
        cProject_id_string.ReadOnly = False

        cShow_id.Name = "show_id"
        cShow_id.HeaderText = "show_id"
        cShow_id.DataPropertyName = "show_id"
        cShow_id.Width = 100
        cShow_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cShow_id.Visible = False
        cShow_id.ReadOnly = False

        cShow_id_string.Name = "show_id_string"
        cShow_id_string.HeaderText = "Show"
        cShow_id_string.DataPropertyName = "show_id_string"
        cShow_id_string.Width = 100
        cShow_id_string.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cShow_id_string.Visible = False
        cShow_id_string.ReadOnly = False

        cAsset_eps.Name = "asset_eps"
        cAsset_eps.HeaderText = "asset_eps"
        cAsset_eps.DataPropertyName = "asset_eps"
        cAsset_eps.Width = 100
        cAsset_eps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_eps.Visible = False
        cAsset_eps.ReadOnly = False

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
        cAsset_idrprice.Visible = False
        cAsset_idrprice.ReadOnly = False

        cAsset_akum_depre.Name = "asset_akum_depre"
        cAsset_akum_depre.HeaderText = "asset_akum_depre"
        cAsset_akum_depre.DataPropertyName = "asset_akum_depre"
        cAsset_akum_depre.Width = 100
        cAsset_akum_depre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_akum_depre.Visible = False
        cAsset_akum_depre.ReadOnly = False

        cAsset_akum_val_depre.Name = "asset_akum_val_depre"
        cAsset_akum_val_depre.HeaderText = "asset_akum_val_depre"
        cAsset_akum_val_depre.DataPropertyName = "asset_akum_val_depre"
        cAsset_akum_val_depre.Width = 100
        cAsset_akum_val_depre.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAsset_akum_val_depre.Visible = False
        cAsset_akum_val_depre.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cSelect, cChannel_id, cAsset_line, cAsset_tgl, cTipeasset_id, cKategoriasset_id, cAsset_barcode, cAsset_lineinduk, cAsset_barcodeinduk, cAsset_serial, cAsset_produknumber, cAsset_model, cAsset_deskripsi, cCurrency_id, cAsset_harga, cAsset_hargabaru, cKategoriitem_id, cTipeitem_id, cStrukturunit_id, cStrukturunit_id_string, cBrand_id, cBrand_id_string, cUnit_id, cUnit_id_string, cAsset_qty, cMaterial_id, cWarna_id, cUkuran_id, cJeniskelamin_id, cShow_id_cont_item, cIs_active, cIs_useable, cAsset_status, cEmployee_id_owner, cWo_id, cRuang_id, cAsset_rak, cAsset_ppn, cAsset_pph, cAsset_disc, cAsset_depresiasi, cAsset_totdep, cProject_id, cProject_id_string, cShow_id, cShow_id_string, cAsset_eps, cAsset_valas, cAsset_idrprice, cAsset_akum_depre, cAsset_akum_val_depre, cTerimabarang_id})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim obj As Button = sender
        Dim row As Integer
        Dim maxRow As Integer

        If Me.DgvListBarangNonFix.Rows.Count > 0 Then

            maxRow = Me.DgvListBarangNonFix.RowCount - 1
            For row = 0 To maxRow
                If clsUtil.IsDbNull(Me.DgvListBarangNonFix.Item("select", row).Value, False) = True Then
                    Me.listBarcode = Me.DgvListBarangNonFix.Rows(row).Cells("asset_barcode").Value
                End If
            Next

            Me.CloseButtonIsPressed = True
        Else
            Me.CloseButtonIsPressed = False
        End If
        ' Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal channel As String, ByVal param As Integer, ByVal strukturUnit_id As Decimal, ByVal barcode As String)
        Me.dsn = strDSN
        Me.channel = channel
        Me.param = param
        Me.strukturUnit_id = strukturUnit_id
        Me.barcode = barcode

        InitializeComponent()
    End Sub

    Private Sub DgvListBarangNonFix_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvListBarangNonFix.CellClick
        Dim i As Integer

        For i = 0 To Me.DgvListBarangNonFix.Rows.Count - 1
            If i <> e.RowIndex Then
                Me.DgvListBarangNonFix.Rows(i).Cells("select").Value = False
            End If
        Next
    End Sub

   
End Class
