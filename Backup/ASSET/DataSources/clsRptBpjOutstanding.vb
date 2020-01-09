Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptBpjOutstanding
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
        Private mOrder_id As String
        Private mStatus_order As String

        Private mMerk_name As String
        Private mLocation As String
        Private mReceived_by As String
        Private mLocation_header As String
        Private mDelivery_orderNo As String
        Private mReceivedDate As DateTime

        Public Property terimabarang_id() As String
            Get
                Return mTerimabarang_id
            End Get
            Set(ByVal value As String)
                mTerimabarang_id = value
                Me.setDataHeader()
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
                Me.setChannelDesc()
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
                setbarcode()
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
                Me.setMerkName()
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
                setLocation()
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

        Public Property order_id() As String
            Get
                Return mOrder_id
            End Get
            Set(ByVal value As String)
                mOrder_id = value
                Me.setStatus()
            End Set
        End Property

        Public Property status_order() As String
            Get
                Return mStatus_order
            End Get
            Set(ByVal value As String)
                mStatus_order = value
            End Set
        End Property
        Public Property merk_name() As String
            Get
                Return mMerk_name
            End Get
            Set(ByVal value As String)
                mMerk_name = value
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

        Public Property receivedby() As String
            Get
                Return mReceived_by
            End Get
            Set(ByVal value As String)
                mReceived_by = value
            End Set
        End Property
        Public Property receiveddate() As DateTime
            Get
                Return mReceivedDate
            End Get
            Set(ByVal value As DateTime)
                mReceivedDate = value
            End Set
        End Property
        Public Property location_header() As String
            Get
                Return mLocation_header
            End Get
            Set(ByVal value As String)
                mLocation_header = value
            End Set
        End Property
        Public Property delivery_orderno() As String
            Get
                Return mDelivery_orderNo
            End Get
            Set(ByVal value As String)
                mDelivery_orderNo = value
            End Set
        End Property
        Private Sub setStatus()
            Try
                If Left(Me.mOrder_id, 2) = "RO" Then
                    mStatus_order = "RO"
                ElseIf Left(Me.order_id, 2) = "MO" Then
                    mStatus_order = "MO"
                Else
                    mStatus_order = "MANUAL"
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub setbarcode()
            If mAsset_barcode <> "" Then
                Dim tblbarcode As DataTable
                Dim parCriteria As OleDbParameter
                Dim parCriteria1 As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria1 = New OleDbParameter("@channel_id", OleDbType.VarChar, 10)
                    parCriteria1.Value = mChannel_id
                    parCriteria.Value = String.Format(" asset_barcode = '{0}' ", mAsset_barcode)
                    tblbarcode = clsUtil.GetDataTable("as_MstAsset_Select", Me.DSN, parCriteria1, parCriteria)
                    If tblbarcode.Rows.Count > 0 Then
                        Me.mBrand_id = clsUtil.IsDbNull(tblbarcode.Rows(0)("brand_id"), 0)
                        setMerkName()
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Master_Asset")
                Finally
                    parCriteria = Nothing
                    parCriteria1 = Nothing
                    tblbarcode = Nothing
                End Try
            End If
        End Sub
        Private Sub setMerkName()
            If mBrand_id > 0 Then
                Dim tblRequest As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" merk_id = {0} ", mBrand_id)
                    tblRequest = clsUtil.GetDataTable("as_MstMerk_Select", Me.DSN, parCriteria)
                    If tblRequest.Rows.Count > 0 Then
                        Me.mMerk_name = Trim(tblRequest.Rows(0)("merk_name").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving merk name")
                Finally
                    parCriteria = Nothing
                    tblRequest = Nothing
                End Try
            End If
        End Sub
        Private Sub setLocation()
            If mRuang_id <> String.Empty Then
                Dim tblLocation As DataTable
                Dim parCriteria As OleDbParameter
                Dim parcriteriaChannel As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" ruang_id = '{0}' ", mRuang_id)
                    parcriteriaChannel = New OleDbParameter("@channel_id", OleDbType.VarChar, 10)
                    parcriteriaChannel.Value = mChannel_id
                    tblLocation = clsUtil.GetDataTable("as_MstRuangAsset_Select", Me.DSN, parcriteriaChannel, parCriteria)
                    If tblLocation.Rows.Count > 0 Then
                        Me.mLocation = Trim(tblLocation.Rows(0)("keterangan").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving merk name")
                Finally
                    parCriteria = Nothing
                    tblLocation = Nothing
                End Try
            End If
        End Sub

        Private Sub setDataHeader()
            If mTerimabarang_id <> String.Empty Then
                Dim tblDataHeader As DataTable
                Dim parCriteria As OleDbParameter
                Dim parcriteriaChannel As OleDbParameter
                Dim parcriteriaTop As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" AND terimabarang_id = '{0}' ", mTerimabarang_id)
                    parcriteriaChannel = New OleDbParameter("@channel_id", OleDbType.VarChar, 20)
                    parcriteriaChannel.Value = mChannel_id
                    parcriteriaTop = New OleDbParameter("@top", OleDbType.Integer, 4)
                    parcriteriaTop.Value = 10000
                    tblDataHeader = clsUtil.GetDataTable("as_TrnTerimabarang_Select", Me.DSN, parcriteriaChannel, parCriteria, parcriteriaTop)
                    If tblDataHeader.Rows.Count > 0 Then
                        Me.mReceived_by = Trim(tblDataHeader.Rows(0)("employee_id_pemilik_string").ToString)
                        Me.mReceivedDate = tblDataHeader.Rows(0)("terimabarang_tgl").ToString
                        Me.mLocation_header = clsUtil.IsDbNull(tblDataHeader.Rows(0)("location").ToString, String.Empty)
                        Me.mDelivery_orderNo = clsUtil.IsDbNull(tblDataHeader.Rows(0)("no_surat_jalan").ToString, String.Empty)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving merk name")
                Finally
                    parCriteria = Nothing
                    tblDataHeader = Nothing
                End Try
            End If
        End Sub


        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub

        Private Sub setChannelDesc()
            If mChannel_id <> "" Then
                Dim tblTerimaBarang As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" channel_id = '{0}' ", mChannel_id)
                    tblTerimaBarang = clsUtil.GetDataTable("ms_MstChannel_Select", Me.DSN, parCriteria)
                    If tblTerimaBarang.Rows.Count > 0 Then
                        Me.mChannel_namereport = Trim(tblTerimaBarang.Rows(0)("channel_namereport").ToString)
                        Me.mChannel_address = Trim(tblTerimaBarang.Rows(0)("channel_address").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving channel desc.")
                Finally
                    parCriteria = Nothing
                    tblTerimaBarang = Nothing
                End Try
            End If
        End Sub
    End Class
End Namespace
