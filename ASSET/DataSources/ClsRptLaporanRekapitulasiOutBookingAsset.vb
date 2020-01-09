Imports System.Data.OleDb
Namespace DataSource
    Public Class ClsRptLaporanRekapitulasiOutBookingAsset
        Private DSN As String
        Private mOutasset_id As String
        Private mOutasset_inputdt As DateTime
        Private mQtyout As Int32
        Private mBookasset_id As String
        Private mBook_date As DateTime
        Private mStrukturunit_id As Decimal
        Private mQtybook As Int32
        Private mOutasset_startdt As DateTime
        Private mOutasset_starttm As String
        Private mOutasset_enddt As DateTime
        Private mOutasset_endtm As String
        Private mProgram As String
        Private mKategoriitem_id As String

        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String
        Private mSisa As Integer

        Public Property outasset_id() As String
            Get
                Return mOutasset_id
            End Get
            Set(ByVal value As String)
                mOutasset_id = value
            End Set
        End Property

        Public Property outasset_inputdt() As DateTime
            Get
                Return mOutasset_inputdt
            End Get
            Set(ByVal value As DateTime)
                mOutasset_inputdt = value
            End Set
        End Property

        Public Property qtyout() As Int32
            Get
                Return mQtyout
            End Get
            Set(ByVal value As Int32)
                mQtyout = value
            End Set
        End Property

        Public Property bookasset_id() As String
            Get
                Return mBookasset_id
            End Get
            Set(ByVal value As String)
                mBookasset_id = value
            End Set
        End Property

        Public Property book_date() As DateTime
            Get
                Return mBook_date
            End Get
            Set(ByVal value As DateTime)
                mBook_date = value
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

        Public Property qtybook() As Int32
            Get
                Return mQtybook
            End Get
            Set(ByVal value As Int32)
                mQtybook = value
                Me.cekSisa()
            End Set
        End Property

        Public Property outasset_startdt() As DateTime
            Get
                Return mOutasset_startdt
            End Get
            Set(ByVal value As DateTime)
                mOutasset_startdt = value
            End Set
        End Property

        Public Property outasset_starttm() As String
            Get
                Return mOutasset_starttm
            End Get
            Set(ByVal value As String)
                mOutasset_starttm = value
            End Set
        End Property

        Public Property outasset_enddt() As DateTime
            Get
                Return mOutasset_enddt
            End Get
            Set(ByVal value As DateTime)
                mOutasset_enddt = value
            End Set
        End Property

        Public Property outasset_endtm() As String
            Get
                Return mOutasset_endtm
            End Get
            Set(ByVal value As String)
                mOutasset_endtm = value
            End Set
        End Property

        Public Property program() As String
            Get
                Return mProgram
            End Get
            Set(ByVal value As String)
                mProgram = value
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

        Public Property sisa() As Int32
            Get
                Return mSisa
            End Get
            Set(ByVal value As Int32)
                mSisa = value
            End Set
        End Property
        Private Sub cekSisa()
            If mQtyout <> 0 Then
                mSisa = Math.Abs(mQtyout - mQtybook)
            End If
        End Sub

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