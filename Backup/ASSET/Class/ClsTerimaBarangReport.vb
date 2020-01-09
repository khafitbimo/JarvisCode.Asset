

Public Class clsTrnTerimabarang

    Private mChannel_id As String
    Private mTerimabarang_id As String
    Private mTerimabarang_tgl As Date
    Private mTerimabarang_status As String
    Private mOrder_id As String
    Private mPa_ref As String
    Private mAccount As Decimal
    Private mCdpartner_id_vendor As Decimal
    Private mCdpartner_id_vendor_string As String
    Private mEmployee_id_pemeriksa As String
    Private mEmployee_id_pemeriksa_string As String
    Private mEmployee_id_pemilik As String
    Private mEmployee_id_pemilik_string As String
    Private mStrukturunit_id_pemilik As Decimal
    Private mStrukturunit_id_pemilik_string As String
    Private mEmployee_id_pengguna As String
    Private mEmployee_id_pengguna_string As String
    Private mStrukturunit_id_pengguna As Decimal
    Private mStrukturunit_id_pengguna_string As String
    Private mTerimabarang_confirm As Boolean
    Private mTerimabarang_confirmdt As Date
    Private mTerimabarang_cetakbpb As Integer
    Private mTerimabarang_cetakbkb As Integer
    Private mTerimabarang_username As String
    Private mTerimabarang_inputdt As Date
    Private mTerimabarang_item As Integer


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

    Public Property terimabarang_tgl() As Date
        Get
            Return mTerimabarang_tgl
        End Get
        Set(ByVal value As Date)
            mTerimabarang_tgl = value
        End Set
    End Property

    Public Property terimabarang_status() As String
        Get
            Return mTerimabarang_status
        End Get
        Set(ByVal value As String)
            mTerimabarang_status = value
        End Set
    End Property

    Public Property order_id() As String
        Get
            Return mOrder_id
        End Get
        Set(ByVal value As String)
            mOrder_id = value
        End Set
    End Property

    Public Property pa_ref() As String
        Get
            Return mPa_ref
        End Get
        Set(ByVal value As String)
            mPa_ref = value
        End Set
    End Property

    Public Property account() As Decimal
        Get
            Return mAccount
        End Get
        Set(ByVal value As Decimal)
            mAccount = value
        End Set
    End Property

    Public Property cdpartner_id_vendor() As Decimal
        Get
            Return mCdpartner_id_vendor
        End Get
        Set(ByVal value As Decimal)
            mCdpartner_id_vendor = value
        End Set
    End Property

    Public Property cdpartner_id_vendor_string() As String
        Get
            Return mCdpartner_id_vendor_string
        End Get
        Set(ByVal value As String)
            mCdpartner_id_vendor_string = value
        End Set
    End Property

    Public Property employee_id_pemeriksa() As String
        Get
            Return mEmployee_id_pemeriksa
        End Get
        Set(ByVal value As String)
            mEmployee_id_pemeriksa = value
        End Set
    End Property

    Public Property employee_id_pemeriksa_string() As String
        Get
            Return mEmployee_id_pemeriksa_string
        End Get
        Set(ByVal value As String)
            mEmployee_id_pemeriksa_string = value
        End Set
    End Property

    Public Property employee_id_pemilik() As String
        Get
            Return mEmployee_id_pemilik
        End Get
        Set(ByVal value As String)
            mEmployee_id_pemilik = value
        End Set
    End Property

    Public Property employee_id_pemilik_string() As String
        Get
            Return mEmployee_id_pemilik_string
        End Get
        Set(ByVal value As String)
            mEmployee_id_pemilik_string = value
        End Set
    End Property

    Public Property strukturunit_id_pemilik() As Decimal
        Get
            Return mStrukturunit_id_pemilik
        End Get
        Set(ByVal value As Decimal)
            mStrukturunit_id_pemilik = value
        End Set
    End Property

    Public Property strukturunit_id_pemilik_string() As String
        Get
            Return mStrukturunit_id_pemilik_string
        End Get
        Set(ByVal value As String)
            mStrukturunit_id_pemilik_string = value
        End Set
    End Property

    Public Property employee_id_pengguna() As String
        Get
            Return mEmployee_id_pengguna
        End Get
        Set(ByVal value As String)
            mEmployee_id_pengguna = value
        End Set
    End Property

    Public Property employee_id_pengguna_string() As String
        Get
            Return mEmployee_id_pengguna_string
        End Get
        Set(ByVal value As String)
            mEmployee_id_pengguna_string = value
        End Set
    End Property

    Public Property strukturunit_id_pengguna() As Decimal
        Get
            Return mStrukturunit_id_pengguna
        End Get
        Set(ByVal value As Decimal)
            mStrukturunit_id_pengguna = value
        End Set
    End Property

    Public Property strukturunit_id_pengguna_string() As String
        Get
            Return mStrukturunit_id_pengguna_string
        End Get
        Set(ByVal value As String)
            mStrukturunit_id_pengguna_string = value
        End Set
    End Property

    Public Property terimabarang_confirm() As Boolean
        Get
            Return mTerimabarang_confirm
        End Get
        Set(ByVal value As Boolean)
            mTerimabarang_confirm = value
        End Set
    End Property

    Public Property terimabarang_confirmdt() As Date
        Get
            Return mTerimabarang_confirmdt
        End Get
        Set(ByVal value As Date)
            mTerimabarang_confirmdt = value
        End Set
    End Property

    Public Property terimabarang_cetakbpb() As Integer
        Get
            Return mTerimabarang_cetakbpb
        End Get
        Set(ByVal value As Integer)
            mTerimabarang_cetakbpb = value
        End Set
    End Property

    Public Property terimabarang_cetakbkb() As Integer
        Get
            Return mTerimabarang_cetakbkb
        End Get
        Set(ByVal value As Integer)
            mTerimabarang_cetakbkb = value
        End Set
    End Property

    Public Property terimabarang_username() As String
        Get
            Return mTerimabarang_username
        End Get
        Set(ByVal value As String)
            mTerimabarang_username = value
        End Set
    End Property

    Public Property terimabarang_inputdt() As Date
        Get
            Return mTerimabarang_inputdt
        End Get
        Set(ByVal value As Date)
            mTerimabarang_inputdt = value
        End Set
    End Property

    Public Property terimabarang_item() As Integer
        Get
            Return mTerimabarang_item
        End Get
        Set(ByVal value As Integer)
            mTerimabarang_item = value
        End Set
    End Property



End Class

