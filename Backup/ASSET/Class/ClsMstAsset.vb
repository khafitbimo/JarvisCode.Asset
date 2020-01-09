Public Class clsMstAsset

    Private mChannel_id As String
    Private mTerimabarang_id As String
    Private mAsset_line As Integer
    Private mAsset_tgl As Date
    Private mTipeasset_id As String
    Private mKategoriasset_id As String
    Private mAsset_barcode As String
    Private mAsset_lineinduk As Integer
    Private mAsset_barcodeinduk As String
    Private mAsset_serial As String
    Private mAsset_produknumber As String
    Private mAsset_model As String
    Private mAsset_deskripsi As String
    Private mCurrency_id As Decimal
    Private mAsset_harga As Decimal
    Private mKategoriitem_id As String
    Private mTipeitem_id As String
    Private mStrukturunit_id As Decimal
    Private mBrand_id As Decimal
    Private mUnit_id As Decimal
    Private mAsset_qty As Integer
    Private mMaterial_id As String
    Private mWarna_id As String
    Private mUkuran_id As String
    Private mJeniskelamin_id As String
    Private mShow_id_cont_item As String
    Private mIs_active As Boolean
    Private mIs_useable As Boolean
    Private mAsset_status As String
    Private mEmployee_id_owner As String
    Private mWo_id As String


    Public Property channel_id() As String
        Get
            Return mChannel_id
        End Get
        Set(ByVal value As String)
            mChannel_id = value
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

    Public Property asset_line() As Integer
        Get
            Return mAsset_line
        End Get
        Set(ByVal value As Integer)
            mAsset_line = value
        End Set
    End Property

    Public Property asset_tgl() As Date
        Get
            Return mAsset_tgl
        End Get
        Set(ByVal value As Date)
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

    Public Property asset_lineinduk() As Integer
        Get
            Return mAsset_lineinduk
        End Get
        Set(ByVal value As Integer)
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

    Public Property currency_id() As Decimal
        Get
            Return mCurrency_id
        End Get
        Set(ByVal value As Decimal)
            mCurrency_id = value
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

    Public Property strukturunit_id() As Decimal
        Get
            Return mStrukturunit_id
        End Get
        Set(ByVal value As Decimal)
            mStrukturunit_id = value
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

    Public Property asset_qty() As Integer
        Get
            Return mAsset_qty
        End Get
        Set(ByVal value As Integer)
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

    Public Property is_active() As Boolean
        Get
            Return mIs_active
        End Get
        Set(ByVal value As Boolean)
            mIs_active = value
        End Set
    End Property

    Public Property is_useable() As Boolean
        Get
            Return mIs_useable
        End Get
        Set(ByVal value As Boolean)
            mIs_useable = value
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

    Public Property employee_id_owner() As String
        Get
            Return mEmployee_id_owner
        End Get
        Set(ByVal value As String)
            mEmployee_id_owner = value
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



End Class

