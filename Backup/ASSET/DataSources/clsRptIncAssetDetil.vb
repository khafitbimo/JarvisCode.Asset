Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptIncAssetDetil
        Private DSN As String
        Private mChannel_id As String
        Private mIncasset_id As String
        Private mLine As Int32
        Private mAsset_barcode As String
        Private mQty As Int32
        Private mIs_useable As Int32
        Private mAsset_status As String

        Private mSenum As String
        Private mDesc As String
        Private mType As String
        Private mBrand_id As String
        Private mBrand_Name As String

        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
            End Set
        End Property

        Public Property incasset_id() As String
            Get
                Return mIncasset_id
            End Get
            Set(ByVal value As String)
                mIncasset_id = value
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
                setbarcode()
            End Set
        End Property

        Public Property qty() As Int32
            Get
                Return mQty
            End Get
            Set(ByVal value As Int32)
                mQty = value
            End Set
        End Property

        Public Property is_useable() As Int32
            Get
                Return mIs_useable
            End Get
            Set(ByVal value As Int32)
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
        Public Property senum() As String
            Get
                Return mSenum
            End Get
            Set(ByVal value As String)
                mSenum = value
            End Set
        End Property
        Public Property desc() As String
            Get
                Return mDesc
            End Get
            Set(ByVal value As String)
                mDesc = value
            End Set
        End Property

        Public Property type() As String
            Get
                Return mType
            End Get
            Set(ByVal value As String)
                mType = value
            End Set
        End Property
        Public Property Brand() As String
            Get
                Return mBrand_id
            End Get
            Set(ByVal value As String)
                mBrand_id = value
            End Set
        End Property
        Public Property Brand_Name() As String
            Get
                Return mBrand_name
            End Get
            Set(ByVal value As String)
                mBrand_Name = value
            End Set
        End Property
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
                        Me.mDesc = Trim(tblbarcode.Rows(0)("asset_deskripsi").ToString)
                        Me.mType = Trim(tblbarcode.Rows(0)("tipeitem_id").ToString)
                        Me.mSenum = Trim(tblbarcode.Rows(0)("asset_serial").ToString)
                        Me.mBrand_id = Trim(tblbarcode.Rows(0)("brand_id").ToString)

                        setbrand()
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

        Private Sub setbrand()
            If mBrand_id <> "" Then
                Dim tblbrand_id As DataTable
                Dim parCriteria As OleDbParameter


                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format("merk_id = '{0}' ", mBrand_id)
                    tblbrand_id = clsUtil.GetDataTable("as_MstMerk_Select", Me.DSN, parCriteria)
                    If tblbrand_id.Rows.Count > 0 Then
                        Me.mBrand_name = Trim(tblbrand_id.Rows(0)("merk_name").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Master_Asset")
                Finally
                    parCriteria = Nothing
                    tblbrand_id = Nothing
                End Try
            End If
        End Sub



        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace