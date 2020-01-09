Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptTrnWriteoffDetil
        Private DSN As String
        Private mChannel_id As String
        Private mWriteoff_id As String
        Private mWriteoff_tgl As DateTime
        Private mWriteoff_barcode As String
        Private mCurrency_id As Decimal
        Private mWriteoff_hargaawal As Decimal
        Private mCurrency_id_akhir As Decimal
        Private mWriteoff_hargakhir As Decimal
        Private mEmployee_id_writeoffby As String
        Private mStrukturunit_id As Decimal
        Private mEmployee_id_writeoffapp As String
        Private mWriteoff_reason As String
        Private mStatus_akhir As String
        Private mTerimabarang_id As String
        Private mAsset_line As Int32
        Private mChannel_id1 As String
        Private mAsset_tgl As DateTime
        Private mTipeasset_id As String
        Private mKategoriasset_id As String
        Private mAsset_barcode As String
        Private mAsset_lineinduk As Int32
        Private mAsset_barcodeinduk As String
        Private mAsset_serial As String
        Private mAsset_produknumber As String
        Private mAsset_model As String
        Private mAsset_deskripsi As String
        Private mKategoriitem_id As String
        Private mTipeitem_id As String
        Private mAsset_golfiskal As String
        Private mAsset_tipedepre As String
        Private mAsset_depre_enddt As DateTime
        Private mCurrency_id1 As Decimal
        Private mAsset_harga As Decimal
        Private mAsset_hargabaru As Decimal
        Private mAsset_ppn As Decimal
        Private mAsset_pph As Decimal
        Private mAsset_disc As Decimal
        Private mAsset_depresiasi As Int32
        Private mAsset_akum_val_depre As Decimal
        Private mAsset_valas As Decimal
        Private mAsset_idrprice As Decimal
        Private mStrukturunit_id1 As Decimal
        Private mEmployee_id_owner As String
        Private mBrand_id As Decimal
        Private mUnit_id As Decimal
        Private mAsset_qty As Int32
        Private mMaterial_id As String
        Private mWarna_id As String
        Private mUkuran_id As String
        Private mJeniskelamin_id As String
        Private mShow_id_cont_item As String
        Private mRuang_id As String
        Private mAsset_rak As String
        Private mIs_useable As Byte
        Private mAsset_active As Byte
        Private mAsset_status As String
        Private mProject_id As Decimal
        Private mShow_id As String
        Private mAsset_eps As String
        Private mWo_id As String
        Private mInputby As String
        Private mInputdt As DateTime
        Private mEditby As String
        Private mEditdt As DateTime
        Private mUsedby As String
        Private mAsset_deprebulanan As Decimal
        Private mAsset_stdepre As DateTime
        Private mAsset_eddepre As DateTime
        Private mAsset_deskripsi1 As String
        Private mAsset_serial1 As String
        Private mTipeitem_id1 As String
        Private mKategoriitem_id1 As String
        Private mStrukturunit_id_string As String
        Private mEmployee_id_string As String
        Private mCurrency_awal As String
        Private mCurrency_akhir As String
        Private mLokasi As String

        Private mLine As Int32
        Private mTimes As Int32
        Private mNbv As Decimal

        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
            End Set
        End Property

        Public Property writeoff_id() As String
            Get
                Return mWriteoff_id
            End Get
            Set(ByVal value As String)
                mWriteoff_id = value
            End Set
        End Property

        Public Property writeoff_tgl() As DateTime
            Get
                Return mWriteoff_tgl
            End Get
            Set(ByVal value As DateTime)
                mWriteoff_tgl = value
            End Set
        End Property

        Public Property writeoff_barcode() As String
            Get
                Return mWriteoff_barcode
            End Get
            Set(ByVal value As String)
                mWriteoff_barcode = value
            End Set
        End Property

        Public Property currency_id() As Decimal
            Get
                Return mCurrency_id
            End Get
            Set(ByVal value As Decimal)
                mCurrency_id = value
            End Set
        End Property

        Public Property writeoff_hargaawal() As Decimal
            Get
                Return mWriteoff_hargaawal
            End Get
            Set(ByVal value As Decimal)
                mWriteoff_hargaawal = value
            End Set
        End Property

        Public Property currency_id_akhir() As Decimal
            Get
                Return mCurrency_id_akhir
            End Get
            Set(ByVal value As Decimal)
                mCurrency_id_akhir = value
            End Set
        End Property

        Public Property writeoff_hargakhir() As Decimal
            Get
                Return mWriteoff_hargakhir
            End Get
            Set(ByVal value As Decimal)
                mWriteoff_hargakhir = value
            End Set
        End Property

        Public Property employee_id_writeoffby() As String
            Get
                Return mEmployee_id_writeoffby
            End Get
            Set(ByVal value As String)
                mEmployee_id_writeoffby = value
            End Set
        End Property

        Public Property strukturunit_id() As Decimal
            Get
                Return mStrukturunit_id
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id = value
            End Set
        End Property

        Public Property employee_id_writeoffapp() As String
            Get
                Return mEmployee_id_writeoffapp
            End Get
            Set(ByVal value As String)
                mEmployee_id_writeoffapp = value
            End Set
        End Property

        Public Property writeoff_reason() As String
            Get
                Return mWriteoff_reason
            End Get
            Set(ByVal value As String)
                mWriteoff_reason = value
            End Set
        End Property

        Public Property status_akhir() As String
            Get
                Return mStatus_akhir
            End Get
            Set(ByVal value As String)
                mStatus_akhir = value
            End Set
        End Property

        Public Property terimabarang_id() As String
            Get
                Return mTerimabarang_id
            End Get
            Set(ByVal value As String)
                mTerimabarang_id = value
            End Set
        End Property

        Public Property asset_line() As Int32
            Get
                Return mAsset_line
            End Get
            Set(ByVal value As Int32)
                mAsset_line = value
            End Set
        End Property

        Public Property channel_id1() As String
            Get
                Return mChannel_id1
            End Get
            Set(ByVal value As String)
                mChannel_id1 = value
            End Set
        End Property

        Public Property asset_tgl() As DateTime
            Get
                Return mAsset_tgl
            End Get
            Set(ByVal value As DateTime)
                mAsset_tgl = value
            End Set
        End Property

        Public Property tipeasset_id() As String
            Get
                Return mTipeasset_id
            End Get
            Set(ByVal value As String)
                mTipeasset_id = value
            End Set
        End Property

        Public Property kategoriasset_id() As String
            Get
                Return mKategoriasset_id
            End Get
            Set(ByVal value As String)
                mKategoriasset_id = value
            End Set
        End Property

        Public Property asset_barcode() As String
            Get
                Return mAsset_barcode
            End Get
            Set(ByVal value As String)
                mAsset_barcode = value
            End Set
        End Property

        Public Property asset_lineinduk() As Int32
            Get
                Return mAsset_lineinduk
            End Get
            Set(ByVal value As Int32)
                mAsset_lineinduk = value
            End Set
        End Property

        Public Property asset_barcodeinduk() As String
            Get
                Return mAsset_barcodeinduk
            End Get
            Set(ByVal value As String)
                mAsset_barcodeinduk = value
            End Set
        End Property

        Public Property asset_serial() As String
            Get
                Return mAsset_serial
            End Get
            Set(ByVal value As String)
                mAsset_serial = value
            End Set
        End Property

        Public Property asset_produknumber() As String
            Get
                Return mAsset_produknumber
            End Get
            Set(ByVal value As String)
                mAsset_produknumber = value
            End Set
        End Property

        Public Property asset_model() As String
            Get
                Return mAsset_model
            End Get
            Set(ByVal value As String)
                mAsset_model = value
            End Set
        End Property

        Public Property asset_deskripsi() As String
            Get
                Return mAsset_deskripsi
            End Get
            Set(ByVal value As String)
                mAsset_deskripsi = value
            End Set
        End Property

        Public Property kategoriitem_id() As String
            Get
                Return mKategoriitem_id
            End Get
            Set(ByVal value As String)
                mKategoriitem_id = value
            End Set
        End Property

        Public Property tipeitem_id() As String
            Get
                Return mTipeitem_id
            End Get
            Set(ByVal value As String)
                mTipeitem_id = value
            End Set
        End Property

        Public Property asset_golfiskal() As String
            Get
                Return mAsset_golfiskal
            End Get
            Set(ByVal value As String)
                mAsset_golfiskal = value
            End Set
        End Property

        Public Property asset_tipedepre() As String
            Get
                Return mAsset_tipedepre
            End Get
            Set(ByVal value As String)
                mAsset_tipedepre = value
            End Set
        End Property

        Public Property asset_depre_enddt() As DateTime
            Get
                Return mAsset_depre_enddt
            End Get
            Set(ByVal value As DateTime)
                mAsset_depre_enddt = value
            End Set
        End Property

        Public Property currency_id1() As Decimal
            Get
                Return mCurrency_id1
            End Get
            Set(ByVal value As Decimal)
                mCurrency_id1 = value
            End Set
        End Property

        Public Property asset_harga() As Decimal
            Get
                Return mAsset_harga
            End Get
            Set(ByVal value As Decimal)
                mAsset_harga = value
            End Set
        End Property

        Public Property asset_hargabaru() As Decimal
            Get
                Return mAsset_hargabaru
            End Get
            Set(ByVal value As Decimal)
                mAsset_hargabaru = value
            End Set
        End Property

        Public Property asset_ppn() As Decimal
            Get
                Return mAsset_ppn
            End Get
            Set(ByVal value As Decimal)
                mAsset_ppn = value
            End Set
        End Property

        Public Property asset_pph() As Decimal
            Get
                Return mAsset_pph
            End Get
            Set(ByVal value As Decimal)
                mAsset_pph = value
            End Set
        End Property

        Public Property asset_disc() As Decimal
            Get
                Return mAsset_disc
            End Get
            Set(ByVal value As Decimal)
                mAsset_disc = value
            End Set
        End Property

        Public Property asset_depresiasi() As Int32
            Get
                Return mAsset_depresiasi
            End Get
            Set(ByVal value As Int32)
                mAsset_depresiasi = value
            End Set
        End Property

        Public Property asset_akum_val_depre() As Decimal
            Get
                Return mAsset_akum_val_depre
            End Get
            Set(ByVal value As Decimal)
                mAsset_akum_val_depre = value
            End Set
        End Property

        Public Property asset_valas() As Decimal
            Get
                Return mAsset_valas
            End Get
            Set(ByVal value As Decimal)
                mAsset_valas = value
            End Set
        End Property

        Public Property asset_idrprice() As Decimal
            Get
                Return mAsset_idrprice
            End Get
            Set(ByVal value As Decimal)
                mAsset_idrprice = value
            End Set
        End Property

        Public Property strukturunit_id1() As Decimal
            Get
                Return mStrukturunit_id1
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id1 = value
            End Set
        End Property

        Public Property employee_id_owner() As String
            Get
                Return mEmployee_id_owner
            End Get
            Set(ByVal value As String)
                mEmployee_id_owner = value
            End Set
        End Property

        Public Property brand_id() As Decimal
            Get
                Return mBrand_id
            End Get
            Set(ByVal value As Decimal)
                mBrand_id = value
            End Set
        End Property

        Public Property unit_id() As Decimal
            Get
                Return mUnit_id
            End Get
            Set(ByVal value As Decimal)
                mUnit_id = value
            End Set
        End Property

        Public Property asset_qty() As Int32
            Get
                Return mAsset_qty
            End Get
            Set(ByVal value As Int32)
                mAsset_qty = value
            End Set
        End Property

        Public Property material_id() As String
            Get
                Return mMaterial_id
            End Get
            Set(ByVal value As String)
                mMaterial_id = value
            End Set
        End Property

        Public Property warna_id() As String
            Get
                Return mWarna_id
            End Get
            Set(ByVal value As String)
                mWarna_id = value
            End Set
        End Property

        Public Property ukuran_id() As String
            Get
                Return mUkuran_id
            End Get
            Set(ByVal value As String)
                mUkuran_id = value
            End Set
        End Property

        Public Property jeniskelamin_id() As String
            Get
                Return mJeniskelamin_id
            End Get
            Set(ByVal value As String)
                mJeniskelamin_id = value
            End Set
        End Property

        Public Property show_id_cont_item() As String
            Get
                Return mShow_id_cont_item
            End Get
            Set(ByVal value As String)
                mShow_id_cont_item = value
            End Set
        End Property

        Public Property ruang_id() As String
            Get
                Return mRuang_id
            End Get
            Set(ByVal value As String)
                mRuang_id = value
            End Set
        End Property

        Public Property asset_rak() As String
            Get
                Return mAsset_rak
            End Get
            Set(ByVal value As String)
                mAsset_rak = value
            End Set
        End Property

        Public Property is_useable() As Byte
            Get
                Return mIs_useable
            End Get
            Set(ByVal value As Byte)
                mIs_useable = value
            End Set
        End Property

        Public Property asset_active() As Byte
            Get
                Return mAsset_active
            End Get
            Set(ByVal value As Byte)
                mAsset_active = value
            End Set
        End Property

        Public Property asset_status() As String
            Get
                Return mAsset_status
            End Get
            Set(ByVal value As String)
                mAsset_status = value
            End Set
        End Property

        Public Property project_id() As Decimal
            Get
                Return mProject_id
            End Get
            Set(ByVal value As Decimal)
                mProject_id = value
            End Set
        End Property

        Public Property show_id() As String
            Get
                Return mShow_id
            End Get
            Set(ByVal value As String)
                mShow_id = value
            End Set
        End Property

        Public Property asset_eps() As String
            Get
                Return mAsset_eps
            End Get
            Set(ByVal value As String)
                mAsset_eps = value
            End Set
        End Property

        Public Property wo_id() As String
            Get
                Return mWo_id
            End Get
            Set(ByVal value As String)
                mWo_id = value
            End Set
        End Property

        Public Property inputby() As String
            Get
                Return mInputby
            End Get
            Set(ByVal value As String)
                mInputby = value
            End Set
        End Property

        Public Property inputdt() As DateTime
            Get
                Return mInputdt
            End Get
            Set(ByVal value As DateTime)
                mInputdt = value
            End Set
        End Property

        Public Property editby() As String
            Get
                Return mEditby
            End Get
            Set(ByVal value As String)
                mEditby = value
            End Set
        End Property

        Public Property editdt() As DateTime
            Get
                Return mEditdt
            End Get
            Set(ByVal value As DateTime)
                mEditdt = value
            End Set
        End Property

        Public Property usedby() As String
            Get
                Return mUsedby
            End Get
            Set(ByVal value As String)
                mUsedby = value
            End Set
        End Property

        Public Property asset_deprebulanan() As Decimal
            Get
                Return mAsset_deprebulanan
            End Get
            Set(ByVal value As Decimal)
                mAsset_deprebulanan = value
            End Set
        End Property

        Public Property asset_stdepre() As DateTime
            Get
                Return mAsset_stdepre
            End Get
            Set(ByVal value As DateTime)
                mAsset_stdepre = value
            End Set
        End Property

        Public Property asset_eddepre() As DateTime
            Get
                Return mAsset_eddepre
            End Get
            Set(ByVal value As DateTime)
                mAsset_eddepre = value
            End Set
        End Property

        Public Property asset_deskripsi1() As String
            Get
                Return mAsset_deskripsi1
            End Get
            Set(ByVal value As String)
                mAsset_deskripsi1 = value
            End Set
        End Property

        Public Property asset_serial1() As String
            Get
                Return mAsset_serial1
            End Get
            Set(ByVal value As String)
                mAsset_serial1 = value
            End Set
        End Property

        Public Property tipeitem_id1() As String
            Get
                Return mTipeitem_id1
            End Get
            Set(ByVal value As String)
                mTipeitem_id1 = value
            End Set
        End Property

        Public Property kategoriitem_id1() As String
            Get
                Return mKategoriitem_id1
            End Get
            Set(ByVal value As String)
                mKategoriitem_id1 = value
            End Set
        End Property

        Public Property strukturunit_id_string() As String
            Get
                Return mStrukturunit_id_string
            End Get
            Set(ByVal value As String)
                mStrukturunit_id_string = value
            End Set
        End Property

        Public Property employee_id_string() As String
            Get
                Return mEmployee_id_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_string = value
            End Set
        End Property

        Public Property currency_awal() As String
            Get
                Return mCurrency_awal
            End Get
            Set(ByVal value As String)
                mCurrency_awal = value
            End Set
        End Property

        Public Property currency_akhir() As String
            Get
                Return mCurrency_akhir
            End Get
            Set(ByVal value As String)
                mCurrency_akhir = value
            End Set
        End Property
        Public Property lokasi() As String
            Get
                Return mLokasi
            End Get
            Set(ByVal value As String)
                mLokasi = value
            End Set
        End Property


        Public Property line() As Int32
            Get
                Return mLine
            End Get
            Set(ByVal value As Int32)
                mLine = value
            End Set
        End Property

        Public Property times() As Int32
            Get
                Return mTimes
            End Get
            Set(ByVal value As Int32)
                mTimes = value
            End Set
        End Property

        Public Property nbv() As Decimal
            Get
                Return mNbv
            End Get
            Set(ByVal value As Decimal)
                mNbv = value
            End Set
        End Property

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace