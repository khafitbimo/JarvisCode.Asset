Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptMoveAssetDetil
        Private DSN As String
        Private mChannel As String
        Private mMoveasset_id As String
        Private mLine As Int32
        Private mAsset_barcode As String
        Private mEmployee_oldowner As String
        Private mStrukturunit_idold As Decimal
        Private mEmployee_newowner As String
        Private mStrukturunit_idnew As Decimal
        Private mAsset_status As String
        Private mRemark As String

        Private mSn As String
        Private mDesk As String
        Private mTipe As String
        Private mBrand As String

        Public Property channel() As String
            Get
                Return mChannel
            End Get
            Set(ByVal value As String)
                mChannel = value
            End Set
        End Property

        Public Property moveasset_id() As String
            Get
                Return mMoveasset_id
            End Get
            Set(ByVal value As String)
                mMoveasset_id = value
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

        Public Property asset_barcode() As String
            Get
                Return mAsset_barcode
            End Get
            Set(ByVal value As String)
                mAsset_barcode = value
            End Set
        End Property

        Public Property employee_oldowner() As String
            Get
                Return mEmployee_oldowner
            End Get
            Set(ByVal value As String)
                mEmployee_oldowner = value
            End Set
        End Property

        Public Property strukturunit_idold() As Decimal
            Get
                Return mStrukturunit_idold
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_idold = value
            End Set
        End Property

        Public Property employee_newowner() As String
            Get
                Return mEmployee_newowner
            End Get
            Set(ByVal value As String)
                mEmployee_newowner = value
            End Set
        End Property

        Public Property strukturunit_idnew() As Decimal
            Get
                Return mStrukturunit_idnew
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_idnew = value
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

        Public Property remark() As String
            Get
                Return mRemark
            End Get
            Set(ByVal value As String)
                mRemark = value
            End Set
        End Property


        Public Property sn() As String
            Get
                Return mSn
            End Get
            Set(ByVal value As String)
                mSn = value
            End Set
        End Property

        Public Property desk() As String
            Get
                Return mDesk
            End Get
            Set(ByVal value As String)
                mDesk = value
            End Set
        End Property

        Public Property tipe() As String
            Get
                Return mTipe
            End Get
            Set(ByVal value As String)
                mTipe = value
            End Set
        End Property

        Public Property brand() As String
            Get
                Return mBrand
            End Get
            Set(ByVal value As String)
                mBrand = value
            End Set
        End Property

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace
