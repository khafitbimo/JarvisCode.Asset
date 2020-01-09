Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptTerimaJasaTalentDetil
        Private DSN As String
        'Private AssetDSN As String
        Private mTerimajasa_id As String
        Private mTerimajasadetil_line As Int32
        Private mTerimajasadetil_desc As String
        Private mTerimajasadetil_date As DateTime
        'Private mTerimajasadetil_qty As Int32
        'Private mTerimajasadetil_qty_day_eps As Int32
        'Private mTerimajasadetil_qty_usage As Int32

        Private mTerimajasadetil_qty As Decimal
        Private mTerimajasadetil_qty_day_eps As Decimal
        Private mTerimajasadetil_qty_usage As Decimal

        Private mTerimajasadetil_type As String
        Private mOrder_id As String
        Private mOrderdetil_line As Int32
        Private mItem_id As String
        Private mKategoriitem_id As String
        Private mBrand_id As Decimal
        Private mBudget_id As Decimal
        Private mBudgetdetil_id As Decimal
        Private mAcc_id As String
        Private mChannel_id As String
        Private mTerimajasadetil_createby As String
        Private mTerimajasadetil_createdt As DateTime
        Private mTerimajasadetil_modifiedby As String
        Private mTerimajasadetil_modifieddt As DateTime
        Private mTerimajasadetil_foreign As Decimal
        Private mCurrency_id As Decimal
        Private mTerimajasadetil_foreignrate As Decimal
        Private mTerimajasadetil_idrreal As Decimal
        Private mTerimajasadetil_pphpersen As Decimal
        Private mTerimajasadetil_ppnpersen As Decimal
        Private mTerimajasadetil_disc As Decimal
        Private mTerimajasadetil_pphforeign As Decimal
        Private mTerimajasadetil_pphidrreal As Decimal
        Private mTerimajasadetil_ppnforeign As Decimal
        Private mTerimajasadetil_ppnidrreal As Decimal
        Private mTerimajasadetil_totalforeign As Decimal
        Private mTerimajasadetil_totalidrreal As Decimal
        Private mTerimajasadetil_totalIncPPh As Decimal
        Private mTypePajak As String

        'view
        Private mItem_name As String
        Private mBrand_name As String
        Private mKategori_name As String

        Private mEpisode As Int32

        Public Property terimajasa_id() As String
            Get
                Return mTerimajasa_id
            End Get
            Set(ByVal value As String)
                mTerimajasa_id = value
            End Set
        End Property

        Public Property terimajasadetil_line() As Int32
            Get
                Return mTerimajasadetil_line
            End Get
            Set(ByVal value As Int32)
                mTerimajasadetil_line = value
                SetEps()
            End Set
        End Property

        Public Property terimajasadetil_desc() As String
            Get
                Return mTerimajasadetil_desc
            End Get
            Set(ByVal value As String)
                mTerimajasadetil_desc = value
            End Set
        End Property

        Public Property terimajasadetil_date() As DateTime
            Get
                Return mTerimajasadetil_date
            End Get
            Set(ByVal value As DateTime)
                mTerimajasadetil_date = value
            End Set
        End Property

        'Public Property terimajasadetil_qty() As Int32
        '    Get
        '        Return mTerimajasadetil_qty
        '    End Get
        '    Set(ByVal value As Int32)
        '        mTerimajasadetil_qty = value
        '    End Set
        'End Property

        'Public Property terimajasadetil_qty_day_eps() As Int32
        '    Get
        '        Return mTerimajasadetil_qty_day_eps
        '    End Get
        '    Set(ByVal value As Int32)
        '        mTerimajasadetil_qty_day_eps = value
        '    End Set
        'End Property

        'Public Property terimajasadetil_qty_usage() As Int32
        '    Get
        '        Return mTerimajasadetil_qty_usage
        '    End Get
        '    Set(ByVal value As Int32)
        '        mTerimajasadetil_qty_usage = value
        '    End Set
        'End Property

        Public Property terimajasadetil_qty() As Decimal
            Get
                Return mTerimajasadetil_qty
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_qty = value
            End Set
        End Property

        Public Property terimajasadetil_qty_day_eps() As Decimal
            Get
                Return mTerimajasadetil_qty_day_eps
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_qty_day_eps = value
            End Set
        End Property

        Public Property terimajasadetil_qty_usage() As Decimal
            Get
                Return mTerimajasadetil_qty_usage
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_qty_usage = value
            End Set
        End Property

        Public Property terimajasadetil_type() As String
            Get
                Return mTerimajasadetil_type
            End Get
            Set(ByVal value As String)
                mTerimajasadetil_type = value
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

        Public Property orderdetil_line() As Int32
            Get
                Return mOrderdetil_line
            End Get
            Set(ByVal value As Int32)
                mOrderdetil_line = value
            End Set
        End Property

        Public Property item_id() As String
            Get
                Return mItem_id
            End Get
            Set(ByVal value As String)
                mItem_id = value
                setItemName()
            End Set
        End Property

        Public Property kategoriitem_id() As String
            Get
                Return mKategoriitem_id
            End Get
            Set(ByVal value As String)
                mKategoriitem_id = value
                setKategoriName()
            End Set
        End Property

        Public Property brand_id() As Decimal
            Get
                Return mBrand_id
            End Get
            Set(ByVal value As Decimal)
                mBrand_id = value
                setBrandName()
            End Set
        End Property

        Public Property budget_id() As Decimal
            Get
                Return mBudget_id
            End Get
            Set(ByVal value As Decimal)
                mBudget_id = value
            End Set
        End Property

        Public Property budgetdetil_id() As Decimal
            Get
                Return mBudgetdetil_id
            End Get
            Set(ByVal value As Decimal)
                mBudgetdetil_id = value
            End Set
        End Property

        Public Property acc_id() As String
            Get
                Return mAcc_id
            End Get
            Set(ByVal value As String)
                mAcc_id = value
            End Set
        End Property

        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
            End Set
        End Property

        Public Property terimajasadetil_createby() As String
            Get
                Return mTerimajasadetil_createby
            End Get
            Set(ByVal value As String)
                mTerimajasadetil_createby = value
            End Set
        End Property

        Public Property terimajasadetil_createdt() As DateTime
            Get
                Return mTerimajasadetil_createdt
            End Get
            Set(ByVal value As DateTime)
                mTerimajasadetil_createdt = value
            End Set
        End Property

        Public Property terimajasadetil_modifiedby() As String
            Get
                Return mTerimajasadetil_modifiedby
            End Get
            Set(ByVal value As String)
                mTerimajasadetil_modifiedby = value
            End Set
        End Property

        Public Property terimajasadetil_modifieddt() As DateTime
            Get
                Return mTerimajasadetil_modifieddt
            End Get
            Set(ByVal value As DateTime)
                mTerimajasadetil_modifieddt = value
            End Set
        End Property

        Public Property terimajasadetil_foreign() As Decimal
            Get
                Return mTerimajasadetil_foreign
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_foreign = value
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

        Public Property terimajasadetil_foreignrate() As Decimal
            Get
                Return mTerimajasadetil_foreignrate
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_foreignrate = value
            End Set
        End Property

        Public Property terimajasadetil_idrreal() As Decimal
            Get
                Return mTerimajasadetil_idrreal
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_idrreal = value
            End Set
        End Property

        Public Property terimajasadetil_pphpersen() As Decimal
            Get
                Return mTerimajasadetil_pphpersen
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_pphpersen = value
            End Set
        End Property

        Public Property terimajasadetil_ppnpersen() As Decimal
            Get
                Return mTerimajasadetil_ppnpersen
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_ppnpersen = value
            End Set
        End Property

        Public Property terimajasadetil_disc() As Decimal
            Get
                Return mTerimajasadetil_disc
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_disc = value
            End Set
        End Property

        Public Property terimajasadetil_pphforeign() As Decimal
            Get
                Return mTerimajasadetil_pphforeign
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_pphforeign = value
            End Set
        End Property

        Public Property terimajasadetil_pphidrreal() As Decimal
            Get
                Return mTerimajasadetil_pphidrreal
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_pphidrreal = value
            End Set
        End Property

        Public Property terimajasadetil_ppnforeign() As Decimal
            Get
                Return mTerimajasadetil_ppnforeign
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_ppnforeign = value
            End Set
        End Property

        Public Property terimajasadetil_ppnidrreal() As Decimal
            Get
                Return mTerimajasadetil_ppnidrreal
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_ppnidrreal = value
            End Set
        End Property

        Public Property terimajasadetil_totalforeign() As Decimal
            Get
                Return mTerimajasadetil_totalforeign
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_totalforeign = value
            End Set
        End Property

        Public Property terimajasadetil_totalidrreal() As Decimal
            Get
                Return mTerimajasadetil_totalidrreal
            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_totalidrreal = value
            End Set
        End Property
        Public Property terimajasadetil_totalincpph() As Decimal
            Get
                Return mTerimajasadetil_totalIncPPh

            End Get
            Set(ByVal value As Decimal)
                mTerimajasadetil_totalIncPPh = value
            End Set
        End Property


        Public Property type_pajak() As String
            Get
                Return mTypePajak
            End Get
            Set(ByVal value As String)
                mTypePajak = value
            End Set
        End Property
        Public Property item_name() As String
            Get
                Return mItem_name
            End Get
            Set(ByVal value As String)
                mItem_name = value
            End Set
        End Property

        Public Property brand_name() As String
            Get
                Return mBrand_name
            End Get
            Set(ByVal value As String)
                mBrand_name = value
            End Set
        End Property

        Public Property kategori_name() As String
            Get
                Return mKategori_name
            End Get
            Set(ByVal value As String)
                mKategori_name = value
            End Set
        End Property

        Public Property episode() As Int32
            Get
                Return mEpisode
            End Get
            Set(ByVal value As Int32)
                mEpisode = value
            End Set
        End Property

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
            ' Me.AssetDSN = assetDSN
        End Sub

        Private Sub setItemName()
            If mItem_id <> "0" Then
                Dim tblItem As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" code = '{0}' ", mItem_id)

                    tblItem = clsUtil.GetDataTable("ms_MstArtis_Select", Me.DSN, parCriteria)
                    If tblItem.Rows.Count > 0 Then
                        Me.mItem_name = tblItem.Rows(0)("name").ToString
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Item name.")
                Finally
                    parCriteria = Nothing
                    tblItem = Nothing
                End Try
            End If
        End Sub
        Private Sub setBrandName()
            If mBrand_id <> 0 Then
                Dim tblBrand As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" merk_id = '{0}' ", mBrand_id)

                    tblBrand = clsUtil.GetDataTable("as_MstMerk_Select", Me.DSN, parCriteria)
                    If tblBrand.Rows.Count > 0 Then
                        Me.mBrand_name = tblBrand.Rows(0)("merk_name").ToString
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Merk name.")
                Finally
                    parCriteria = Nothing
                    tblBrand = Nothing
                End Try
            End If
        End Sub
        Private Sub setKategoriName()
            If mKategoriitem_id <> "" Then
                Dim tblKategori As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" category_id = '{0}' ", mKategoriitem_id)

                    tblKategori = clsUtil.GetDataTable("ms_MstItemCategory_Select", Me.DSN, parCriteria)
                    If tblKategori.Rows.Count > 0 Then
                        Me.mKategori_name = tblKategori.Rows(0)("category_name").ToString
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Category Name.")
                Finally
                    parCriteria = Nothing
                    tblKategori = Nothing
                End Try
            End If
        End Sub

        Private Sub SetEps()
            If mTerimajasa_id <> "" Then
                Dim tblEpisode As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" terimajasa_id = '{0}' AND terimajasa_line = {1} AND terimajasaused_check = 1", mTerimajasa_id, mTerimajasadetil_line)

                    tblEpisode = clsUtil.GetDataTable("as_TrnTerimajasausedtalent_Select", Me.DSN, parCriteria)
                    If tblEpisode.Rows.Count > 0 Then
                        Me.mEpisode = tblEpisode.Compute("SUM(terimajasaused_check)", "")
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Episode")
                Finally
                    parCriteria = Nothing
                    tblEpisode = Nothing
                End Try
            End If

        End Sub
    End Class
End Namespace