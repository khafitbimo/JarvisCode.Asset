Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptDepresiasi
        Private DSN As String
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mDepresiasi_id As String
        Private mDepresiasi_tgl As DateTime
        Private mDepresiasi_thn As Int32
        Private mDepresiasi_bln As Int32
        Private mKategoriasset_id As String
        Private mKategoriasset_time As Int32
        Private mKategoriasset_depresiasitime As String
        Private mKategoriasset_depresiasivalue As Decimal
        Private mTotal_item As Decimal
        Private mTotal_item_depre As Decimal
        Private mCost_beginning As Decimal
        Private mCost_additional As Decimal
        Private mCost_deductional As Decimal
        Private mCost_ending As Decimal
        Private mDepre_beginning As Decimal
        Private mDepre_additional As Decimal
        Private mDepre_deductional As Decimal
        Private mDepre_ending As Decimal
        Private mLock As Byte
        Private mLock_login As String
        Private mLock_dt As DateTime
        Private mPost As Byte
        Private mPost_login As String
        Private mPostdate As DateTime
        Private mNBV As Decimal
        Private mCreate_by As String
        Private mCreate_dt As DateTime
        Private mEdit_by As String
        Private mEdit_dt As DateTime
        Private mUsed_by As String
        Private mUsed_dt As DateTime



        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
                setChannelDesc()
            End Set
        End Property

        Public Property channel_namereport() As String
            Get
                Return mChannel_namereport
            End Get
            Set(ByVal value As String)
                mChannel_namereport = value
            End Set
        End Property

        Public Property channel_address() As String
            Get
                Return mChannel_address
            End Get
            Set(ByVal value As String)
                mChannel_address = value
            End Set
        End Property

        Public Property depresiasi_id() As String
            Get
                Return mDepresiasi_id
            End Get
            Set(ByVal value As String)
                mDepresiasi_id = value
            End Set
        End Property

        Public Property depresiasi_tgl() As DateTime
            Get
                Return mDepresiasi_tgl
            End Get
            Set(ByVal value As DateTime)
                mDepresiasi_tgl = value
            End Set
        End Property

        Public Property depresiasi_thn() As Int32
            Get
                Return mDepresiasi_thn
            End Get
            Set(ByVal value As Int32)
                mDepresiasi_thn = value
            End Set
        End Property

        Public Property depresiasi_bln() As Int32
            Get
                Return mDepresiasi_bln
            End Get
            Set(ByVal value As Int32)
                mDepresiasi_bln = value
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

        Public Property kategoriasset_time() As Int32
            Get
                Return mKategoriasset_time
            End Get
            Set(ByVal value As Int32)
                mKategoriasset_time = value
            End Set
        End Property

        Public Property kategoriasset_depresiasitime() As String
            Get
                Return mKategoriasset_depresiasitime
            End Get
            Set(ByVal value As String)
                mKategoriasset_depresiasitime = value
            End Set
        End Property

        Public Property kategoriasset_depresiasivalue() As Decimal
            Get
                Return mKategoriasset_depresiasivalue
            End Get
            Set(ByVal value As Decimal)
                mKategoriasset_depresiasivalue = value
            End Set
        End Property

        Public Property total_item() As Decimal
            Get
                Return mTotal_item
            End Get
            Set(ByVal value As Decimal)
                mTotal_item = value
            End Set
        End Property

        Public Property total_item_depre() As Decimal
            Get
                Return mTotal_item_depre
            End Get
            Set(ByVal value As Decimal)
                mTotal_item_depre = value
            End Set
        End Property

        Public Property cost_beginning() As Decimal
            Get
                Return mCost_beginning
            End Get
            Set(ByVal value As Decimal)
                mCost_beginning = value
            End Set
        End Property

        Public Property cost_additional() As Decimal
            Get
                Return mCost_additional
            End Get
            Set(ByVal value As Decimal)
                mCost_additional = value
            End Set
        End Property

        Public Property cost_deductional() As Decimal
            Get
                Return mCost_deductional
            End Get
            Set(ByVal value As Decimal)
                mCost_deductional = value
            End Set
        End Property

        Public Property cost_ending() As Decimal
            Get
                Return mCost_ending
            End Get
            Set(ByVal value As Decimal)
                mCost_ending = value
            End Set
        End Property

        Public Property depre_beginning() As Decimal
            Get
                Return mDepre_beginning
            End Get
            Set(ByVal value As Decimal)
                mDepre_beginning = value
            End Set
        End Property

        Public Property depre_additional() As Decimal
            Get
                Return mDepre_additional
            End Get
            Set(ByVal value As Decimal)
                mDepre_additional = value
            End Set
        End Property

        Public Property depre_deductional() As Decimal
            Get
                Return mDepre_deductional
            End Get
            Set(ByVal value As Decimal)
                mDepre_deductional = value
            End Set
        End Property

        Public Property depre_ending() As Decimal
            Get
                Return mDepre_ending
            End Get
            Set(ByVal value As Decimal)
                mDepre_ending = value
            End Set
        End Property

        Public Property lock() As Byte
            Get
                Return mLock
            End Get
            Set(ByVal value As Byte)
                mLock = value
            End Set
        End Property

        Public Property lock_login() As String
            Get
                Return mLock_login
            End Get
            Set(ByVal value As String)
                mLock_login = value
            End Set
        End Property

        Public Property lock_dt() As DateTime
            Get
                Return mLock_dt
            End Get
            Set(ByVal value As DateTime)
                mLock_dt = value
            End Set
        End Property

        Public Property post() As Byte
            Get
                Return mPost
            End Get
            Set(ByVal value As Byte)
                mPost = value
            End Set
        End Property

        Public Property post_login() As String
            Get
                Return mPost_login
            End Get
            Set(ByVal value As String)
                mPost_login = value
            End Set
        End Property

        Public Property postdate() As DateTime
            Get
                Return mPostdate
            End Get
            Set(ByVal value As DateTime)
                mPostdate = value
            End Set
        End Property

        Public Property NBV() As Decimal
            Get
                Return mNBV
            End Get
            Set(ByVal value As Decimal)
                mNBV = value
            End Set
        End Property

        Public Property create_by() As String
            Get
                Return mCreate_by
            End Get
            Set(ByVal value As String)
                mCreate_by = value
            End Set
        End Property

        Public Property create_dt() As DateTime
            Get
                Return mCreate_dt
            End Get
            Set(ByVal value As DateTime)
                mCreate_dt = value
            End Set
        End Property

        Public Property edit_by() As String
            Get
                Return mEdit_by
            End Get
            Set(ByVal value As String)
                mEdit_by = value
            End Set
        End Property

        Public Property edit_dt() As DateTime
            Get
                Return mEdit_dt
            End Get
            Set(ByVal value As DateTime)
                mEdit_dt = value
            End Set
        End Property

        Public Property used_by() As String
            Get
                Return mUsed_by
            End Get
            Set(ByVal value As String)
                mUsed_by = value
            End Set
        End Property

        Public Property used_dt() As DateTime
            Get
                Return mUsed_dt
            End Get
            Set(ByVal value As DateTime)
                mUsed_dt = value
            End Set
        End Property


        Private Sub setChannelDesc()
            If mChannel_id <> "" Then
                Dim tblBookasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" channel_id = '{0}' ", mChannel_id)
                    tblBookasset = clsUtil.GetDataTable("ms_MstChannel_Select", Me.DSN, parCriteria)
                    If tblBookasset.Rows.Count > 0 Then
                        Me.mChannel_namereport = Trim(tblBookasset.Rows(0)("channel_namereport").ToString)
                        Me.mChannel_address = Trim(tblBookasset.Rows(0)("channel_address").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving channel desc.")
                Finally
                    parCriteria = Nothing
                    tblBookasset = Nothing
                End Try
            End If
        End Sub

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace