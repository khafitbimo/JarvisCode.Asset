Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptLaporanPenerimaanAsset
        Private DSN As String
        Private mTerimabarang_id As String
        Private mAsset_line As Int32

        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String


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
        Private mCurrency_id As Decimal
        Private mAsset_harga As Decimal
        Private mAsset_hargabaru As Decimal
        Private mAsset_ppn As Decimal
        Private mAsset_pph As Decimal
        Private mAsset_disc As Decimal
        Private mAsset_depresiasi As Int32
        Private mAsset_akum_val_depre As Decimal
        Private mAsset_valas As Decimal
        Private mAsset_idrprice As Decimal
        Private mStrukturunit_id As Decimal
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
        Private mBrand_id_string As String
        Private mStrukturunit_id_string As String
        Private mUnit_id_string As String
        Private mShow_id_string As String
        Private mProject_id_string As String
        Private mEmployee_string As String
        Private mGdg As String
        Private mLt As Int32
        Private mStart_depre_dt As DateTime
        Private mEnd_depre_dt As DateTime

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

        Public Property strukturunit_id() As Decimal
            Get
                Return mStrukturunit_id
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id = value
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

        Public Property brand_id_string() As String
            Get
                Return mBrand_id_string
            End Get
            Set(ByVal value As String)
                mBrand_id_string = value
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

        Public Property unit_id_string() As String
            Get
                Return mUnit_id_string
            End Get
            Set(ByVal value As String)
                mUnit_id_string = value
            End Set
        End Property

        Public Property show_id_string() As String
            Get
                Return mShow_id_string
            End Get
            Set(ByVal value As String)
                mShow_id_string = value
            End Set
        End Property

        Public Property project_id_string() As String
            Get
                Return mProject_id_string
            End Get
            Set(ByVal value As String)
                mProject_id_string = value
            End Set
        End Property

        Public Property employee_string() As String
            Get
                Return mEmployee_string
            End Get
            Set(ByVal value As String)
                mEmployee_string = value
            End Set
        End Property

        Public Property Gdg() As String
            Get
                Return mGdg
            End Get
            Set(ByVal value As String)
                mGdg = value
            End Set
        End Property

        Public Property Lt() As Int32
            Get
                Return mLt
            End Get
            Set(ByVal value As Int32)
                mLt = value
            End Set
        End Property

        Public Property start_depre_dt() As DateTime
            Get
                Return mStart_depre_dt
            End Get
            Set(ByVal value As DateTime)
                mStart_depre_dt = value
            End Set
        End Property

        Public Property end_depre_dt() As DateTime
            Get
                Return mEnd_depre_dt
            End Get
            Set(ByVal value As DateTime)
                mEnd_depre_dt = value
            End Set
        End Property
        Private Sub setChannelDesc()
            If mChannel_id <> "" Then
                Dim tblIncAsset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" channel_id = '{0}' ", mChannel_id)
                    tblIncAsset = clsUtil.GetDataTable("ms_MstChannel_Select", Me.DSN, parCriteria)
                    If tblIncAsset.Rows.Count > 0 Then
                        Me.mChannel_namereport = Trim(tblIncAsset.Rows(0)("channel_namereport").ToString)
                        Me.mChannel_address = Trim(tblIncAsset.Rows(0)("channel_address").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving channel desc.")
                Finally
                    parCriteria = Nothing
                    tblIncAsset = Nothing
                End Try
            End If
        End Sub


        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace