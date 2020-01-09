Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptDepresiasiReport
        Private DSN As String
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mKategoriasset_id As String
        Private mDepresiasi_id As String
        Private mDepresiasi_thn As Int32
        Private mDepresiasi_bln As Int32
        Private mAsset_barcode As String
        Private mKategori_time As Int32
        Private mHarga_item_awal As Decimal
        Private mAsset_hargaawal As Decimal
        Private mCost As Decimal
        Private mAsset_hargaakhir As Decimal
        Private mJumlah_depre As Int32
        Private mAkum_val_depre As Decimal
        Private mNilai_depre As Decimal
        Private mDepresiasi_adjust As Decimal
        Private mDepresiasi_add As Decimal
        Private mDepresiasi_additional As Decimal

        Private mNBV As Decimal
        Private mAsset_stdt As DateTime
        Private mAsset_eddt As DateTime
        Private mAsset_tipedepre As String
        Private mTipeitem_id As String
        Private mAsset_deskripsi As String
        Private mAsset_serial As String
        Private mBrand_id As String



        Private mBulan_String As String
        Private mTotal As String

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

        Public Property kategoriasset_id() As String
            Get
                Return mKategoriasset_id
            End Get
            Set(ByVal value As String)
                mKategoriasset_id = value
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
                setBulan()
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

        Public Property kategori_time() As Int32
            Get
                Return mKategori_time
            End Get
            Set(ByVal value As Int32)
                mKategori_time = value
            End Set
        End Property

        Public Property harga_item_awal() As Decimal
            Get
                Return mHarga_item_awal
            End Get
            Set(ByVal value As Decimal)
                mHarga_item_awal = value
            End Set
        End Property

        Public Property asset_hargaawal() As Decimal
            Get
                Return mAsset_hargaawal
            End Get
            Set(ByVal value As Decimal)
                mAsset_hargaawal = value
            End Set
        End Property

        Public Property cost() As Decimal
            Get
                Return mCost
            End Get
            Set(ByVal value As Decimal)
                mCost = value
            End Set
        End Property

        Public Property asset_hargaakhir() As Decimal
            Get
                Return mAsset_hargaakhir
            End Get
            Set(ByVal value As Decimal)
                mAsset_hargaakhir = value
            End Set
        End Property

        Public Property jumlah_depre() As Int32
            Get
                Return mJumlah_depre
            End Get
            Set(ByVal value As Int32)
                mJumlah_depre = value
            End Set
        End Property

        Public Property akum_val_depre() As Decimal
            Get
                Return mAkum_val_depre
            End Get
            Set(ByVal value As Decimal)
                mAkum_val_depre = value
            End Set
        End Property

        Public Property nilai_depre() As Decimal
            Get
                Return mNilai_depre
            End Get
            Set(ByVal value As Decimal)
                mNilai_depre = value
            End Set
        End Property

        Public Property depresiasi_adjust() As Decimal
            Get
                Return mDepresiasi_adjust
            End Get
            Set(ByVal value As Decimal)
                mDepresiasi_adjust = value
            End Set
        End Property

        Public Property depresiasi_add() As Decimal
            Get
                Return mDepresiasi_add
            End Get
            Set(ByVal value As Decimal)
                mDepresiasi_add = value
            End Set
        End Property

        Public Property depresiasi_additional() As Decimal
            Get
                Return mDepresiasi_additional
            End Get
            Set(ByVal value As Decimal)
                mDepresiasi_additional = value
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

        Public Property asset_tipedepre() As String
            Get
                Return mAsset_tipedepre
            End Get
            Set(ByVal value As String)
                mAsset_tipedepre = value
                Me.cek_depresiasi_add()
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

        Public Property asset_deskripsi() As String
            Get
                Return mAsset_deskripsi
            End Get
            Set(ByVal value As String)
                mAsset_deskripsi = value
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

        Public Property brand_id() As String
            Get
                Return mBrand_id
            End Get
            Set(ByVal value As String)
                mBrand_id = value
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
        Public Property total() As Decimal
            Get
                Return mTotal
            End Get
            Set(ByVal value As Decimal)
                mTotal = value
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

        Private Sub cek_depresiasi_add()

            If mDepresiasi_add <> 0 Then
                If mAsset_tipedepre = "N" Then
                    mDepresiasi_additional = 0
                Else
                    mDepresiasi_additional = mDepresiasi_add
                End If
            End If

            If mAsset_hargaawal <> 0 Then
                If mAsset_tipedepre = "A" Then
                    mCost = 0
                Else
                    mCost = mAsset_hargaawal
                End If
            End If

            mTotal = mCost + mDepresiasi_additional
        End Sub
        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace