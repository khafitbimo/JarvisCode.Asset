Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptLaporanRekapitulasiAsset
        Private DSN As String
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mAsset_barcode As String
        Private mDesk As String
        Private mBookasset_id As String
        Private mBookasset_inputdt As DateTime
        Private mBookasset_startdt As DateTime
        Private mBookasset_starttm As String
        Private mBookasset_enddt As DateTime
        Private mBookasset_endtm As String
        Private mProgram As String
        Private mKategori As String
        Private mStatus As Byte

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

        Public Property asset_barcode() As String
            Get
                Return mAsset_barcode
            End Get
            Set(ByVal value As String)
                mAsset_barcode = value
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

        Public Property bookasset_id() As String
            Get
                Return mBookasset_id
            End Get
            Set(ByVal value As String)
                mBookasset_id = value
            End Set
        End Property

        Public Property bookasset_inputdt() As DateTime
            Get
                Return mBookasset_inputdt
            End Get
            Set(ByVal value As DateTime)
                mBookasset_inputdt = value
            End Set
        End Property

        Public Property bookasset_startdt() As DateTime
            Get
                Return mBookasset_startdt
            End Get
            Set(ByVal value As DateTime)
                mBookasset_startdt = value
            End Set
        End Property

        Public Property bookasset_starttm() As String
            Get
                Return mBookasset_starttm
            End Get
            Set(ByVal value As String)
                mBookasset_starttm = value
            End Set
        End Property

        Public Property bookasset_enddt() As DateTime
            Get
                Return mBookasset_enddt
            End Get
            Set(ByVal value As DateTime)
                mBookasset_enddt = value
            End Set
        End Property

        Public Property bookasset_endtm() As String
            Get
                Return mBookasset_endtm
            End Get
            Set(ByVal value As String)
                mBookasset_endtm = value
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

        Public Property kategori() As String
            Get
                Return mKategori
            End Get
            Set(ByVal value As String)
                mKategori = value
            End Set
        End Property

        Public Property status() As Byte
            Get
                Return mStatus
            End Get
            Set(ByVal value As Byte)
                mStatus = value
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