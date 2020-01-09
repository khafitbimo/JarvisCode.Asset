Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptBPJinOrder
        Private DSN As String
        Private mOrder_id As String
        Private mOrder_date As DateTime
        Private mOrder_descr As String
        Private mOrder_note As String
        Private mTerimabarang_id As String
        Private mTerimabarang_appuser As Byte
        Private mTerimabarang_appprc As Byte
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String
        Private mStatus As String
        Private mOrder_utilizeddateend As DateTime
        Private mOrder_utilizeddatestart As DateTime

        Private mDepartment As String
        Private mJumlah_order As Integer
        Private mBpj_approved As Integer
        Private mBpj_not_approved As Integer
        Private mJumlah_bpj As Integer
        Private mJumlah_total As Integer
        Private mPersentase_bpj As Decimal
        Private mJumlah_doc As Integer
        Private mTotal_presentase_bpj As Decimal

        Public Property order_id() As String
            Get
                Return mOrder_id
            End Get
            Set(ByVal value As String)
                mOrder_id = value
            End Set
        End Property
        Public Property order_date() As DateTime
            Get
                Return mOrder_date
            End Get
            Set(ByVal value As DateTime)
                mOrder_date = value
            End Set
        End Property
        Public Property order_descr() As String
            Get
                Return mOrder_descr
            End Get
            Set(ByVal value As String)
                mOrder_descr = value
            End Set
        End Property
        Public Property order_note() As String
            Get
                Return mOrder_note
            End Get
            Set(ByVal value As String)
                mOrder_note = value
            End Set
        End Property

        Public Property terimabarang_id() As String
            Get
                Return mTerimabarang_id
            End Get
            Set(ByVal value As String)
                mTerimabarang_id = value
            End Set
        End Property

        Public Property terimabarang_appuser() As Byte
            Get
                Return mTerimabarang_appuser
            End Get
            Set(ByVal value As Byte)
                mTerimabarang_appuser = value
            End Set
        End Property

        Public Property terimabarang_appprc() As Byte
            Get
                Return mTerimabarang_appprc
            End Get
            Set(ByVal value As Byte)
                mTerimabarang_appprc = value
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

        Public Property status() As String
            Get
                Return mStatus
            End Get
            Set(ByVal value As String)
                mStatus = value
            End Set
        End Property

        Public Property order_utilizeddateend() As DateTime
            Get
                Return mOrder_utilizeddateend
            End Get
            Set(ByVal value As DateTime)
                mOrder_utilizeddateend = value
            End Set
        End Property

        Public Property order_utilizeddatestart() As DateTime
            Get
                Return mOrder_utilizeddatestart
            End Get
            Set(ByVal value As DateTime)
                mOrder_utilizeddatestart = value
            End Set
        End Property

        Public Property department() As String
            Get
                Return mdepartment
            End Get
            Set(ByVal value As String)
                mDepartment = value
            End Set
        End Property
        Public Property jumlah_order() As Integer
            Get
                Return mJumlah_order
            End Get
            Set(ByVal value As Integer)
                mJumlah_order = value
            End Set
        End Property
        Public Property bpj_approved() As Integer
            Get
                Return mBpj_approved
            End Get
            Set(ByVal value As Integer)
                mBpj_approved = value
            End Set
        End Property
        Public Property bpj_not_approved() As Integer
            Get
                Return mBpj_not_approved
            End Get
            Set(ByVal value As Integer)
                mBpj_not_approved = value
            End Set
        End Property

        Public Property jumlah_bpj() As Integer
            Get
                Return mJumlah_bpj
            End Get
            Set(ByVal value As Integer)
                mJumlah_bpj = value
            End Set
        End Property
        Public Property jumlah_doc() As Integer
            Get
                Return mJumlah_doc
            End Get
            Set(ByVal value As Integer)
                mJumlah_doc = value
            End Set
        End Property

        Public Property persentase_bpj() As Decimal
            Get
                Return mPersentase_bpj
            End Get
            Set(ByVal value As Decimal)
                mPersentase_bpj = value
            End Set
        End Property

        Public Property jumlah_total() As Integer
            Get
                Return mJumlah_total
            End Get
            Set(ByVal value As Integer)
                mJumlah_total = value
            End Set
        End Property

        Public Property total_presentase_bpj() As Decimal
            Get
                Return mTotal_presentase_bpj
            End Get
            Set(ByVal value As Decimal)
                mTotal_presentase_bpj = value
            End Set
        End Property


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

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace