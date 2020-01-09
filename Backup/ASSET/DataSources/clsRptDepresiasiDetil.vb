Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptDepresiasiDetil
        Private DSN As String
        Private mDepresiasi_id As String
        Private mAsset_barcode As String

        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mDepresiasi_thn As Int32
        Private mDepresiasi_bln As Int32
        Private mAsset_strukturunit As Decimal
        Private mAsset_kategori As String
        Private mKategori_time As Int32
        Private mJumlah_depre As Int32
        Private mCost_beginning As Decimal
        Private mCost_additional As Decimal
        Private mCost_deductional As Decimal
        Private mCost_ending As Decimal
        Private mDepre_beginning As Decimal
        Private mDepre_additional As Decimal
        Private mDepre_deductional As Decimal
        Private mDepre_ending As Decimal
        Private mNBV As Decimal
        Private mAsset_stdt As DateTime
        Private mAsset_eddt As DateTime
        Private mCreate_by As String
        Private mCreate_dt As DateTime
        Private mEdit_by As String
        Private mEdit_dt As DateTime
        Private mAsset_tipedepre As String
        Private mDepresiasi_remark As String
        Private mDepresiasi_kali As Int32
        Private mAsset_golpajak As String
        Private mTipeitem_id As String
        Private mBrand_id As String
        Private mAsset_serial As String
        Private mAsset_deskripsi As String
        Private mDepartment As String
        Private mLocation As String


        Private mBulan_String As String

        Public Property depresiasi_id() As String
            Get
                Return mDepresiasi_id
            End Get
            Set(ByVal value As String)
                mDepresiasi_id = value
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
                Me.setBulan()
            End Set
        End Property

        Public Property asset_strukturunit() As Decimal
            Get
                Return mAsset_strukturunit
            End Get
            Set(ByVal value As Decimal)
                mAsset_strukturunit = value
            End Set
        End Property

        Public Property asset_kategori() As String
            Get
                Return mAsset_kategori
            End Get
            Set(ByVal value As String)
                mAsset_kategori = value
            End Set
        End Property

        Public Property kategori_time() As Int32
            Get
                Return mKategori_time
            End Get
            Set(ByVal value As Int32)
                mKategori_time = value
            End Set
        End Property

        Public Property Jumlah_depre() As Int32
            Get
                Return mJumlah_depre
            End Get
            Set(ByVal value As Int32)
                mJumlah_depre = value
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

        Public Property NBV() As Decimal
            Get
                Return mNBV
            End Get
            Set(ByVal value As Decimal)
                mNBV = value
            End Set
        End Property

        Public Property asset_stdt() As DateTime
            Get
                Return mAsset_stdt
            End Get
            Set(ByVal value As DateTime)
                mAsset_stdt = value
            End Set
        End Property

        Public Property asset_eddt() As DateTime
            Get
                Return mAsset_eddt
            End Get
            Set(ByVal value As DateTime)
                mAsset_eddt = value
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

        Public Property asset_tipedepre() As String
            Get
                Return mAsset_tipedepre
            End Get
            Set(ByVal value As String)
                mAsset_tipedepre = value
            End Set
        End Property

        Public Property depresiasi_remark() As String
            Get
                Return mDepresiasi_remark
            End Get
            Set(ByVal value As String)
                mDepresiasi_remark = value
            End Set
        End Property

        Public Property depresiasi_kali() As Int32
            Get
                Return mDepresiasi_kali
            End Get
            Set(ByVal value As Int32)
                mDepresiasi_kali = value
            End Set
        End Property

        Public Property asset_golpajak() As String
            Get
                Return mAsset_golpajak
            End Get
            Set(ByVal value As String)
                mAsset_golpajak = value
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

        Public Property brand_id() As String
            Get
                Return mBrand_id
            End Get
            Set(ByVal value As String)
                mBrand_id = value
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

        Public Property asset_deskripsi() As String
            Get
                Return mAsset_deskripsi
            End Get
            Set(ByVal value As String)
                mAsset_deskripsi = value
            End Set
        End Property

        Public Property department() As String
            Get
                Return mDepartment
            End Get
            Set(ByVal value As String)
                mDepartment = value
            End Set
        End Property

        Public Property location() As String
            Get
                Return mLocation
            End Get
            Set(ByVal value As String)
                mLocation = value
            End Set
        End Property

        Public Property bulan_string() As String
            Get
                Return mBulan_String
            End Get
            Set(ByVal value As String)
                mBulan_String = value
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

        Private Sub setBulan()
            If mDepresiasi_bln <> 0 Then
                Select Case mDepresiasi_bln
                    Case 1
                        mBulan_String = "January"
                    Case 2
                        mBulan_String = "February"
                    Case 3
                        mBulan_String = "March"
                    Case 4
                        mBulan_String = "April"
                    Case 5
                        mBulan_String = "May"
                    Case 6
                        mBulan_String = "June"
                    Case 7
                        mBulan_String = "July"
                    Case 8
                        mBulan_String = "August"
                    Case 9
                        mBulan_String = "September"
                    Case 10
                        mBulan_String = "October"
                    Case 11
                        mBulan_String = "November"
                    Case 12
                        mBulan_String = "December"
                End Select

            End If
        End Sub

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub

    End Class
End Namespace