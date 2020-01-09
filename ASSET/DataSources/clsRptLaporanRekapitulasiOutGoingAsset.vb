Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptLaporanRekapitulasiOutGoingAsset
        Private DSN As String
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mBarcode As String
        Private mDeskripsi As String
        Private mOutasset_id As String
        Private mOutasset_inputdt As DateTime
        Private mBookasset_id As String
        Private mBookasset_date As DateTime
        Private mOutasset_startdt As DateTime
        Private mOutasset_starttm As String
        Private mOutasset_enddt As DateTime
        Private mOutasset_endtm As String
        Private mProgram As String
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
        Public Property barcode() As String
            Get
                Return mBarcode
            End Get
            Set(ByVal value As String)
                mBarcode = value
            End Set
        End Property

        Public Property deskripsi() As String
            Get
                Return mDeskripsi
            End Get
            Set(ByVal value As String)
                mDeskripsi = value
            End Set
        End Property

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

        Public Property bookasset_id() As String
            Get
                Return mBookasset_id
            End Get
            Set(ByVal value As String)
                mBookasset_id = value
            End Set
        End Property

        Public Property bookasset_date() As DateTime
            Get
                Return mBookasset_date
            End Get
            Set(ByVal value As DateTime)
                mBookasset_date = value
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