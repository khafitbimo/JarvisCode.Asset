Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptMaintenance
        Private DSN As String
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mMaintenance_id As String
        Private mMaintenance_type As String
        Private mMaintenance_outin As Byte
        Private mOrder_id As String
        Private mRekanan_id As Decimal
        Private mMaintenace_itemqty As Int32
        Private mMaintenace_itemqtyret As Int32
        Private mEmployee_id As String
        Private mStrukturunit_id As Decimal
        Private mMaintenance_indt As DateTime
        Private mMaintenance_outdt As DateTime
        Private mMaintenance_status As String
        Private mCurrency_id As Decimal
        Private mMaintenance_harga As Decimal
        Private mMaintenance_valas As Decimal
        Private mMaintenance_idrprice As Decimal
        Private mMaintenance_inputby As String
        Private mMaintenance_inputdt As DateTime
        Private mMaintenance_editby As String
        Private mMaintenance_editdt As DateTime
        Private mMaintenance_usedby As String
        Private mMaintenance_useddt As DateTime
        Private mMaintenance_outlock As Byte
        Private mMaintenance_inclock As Byte

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

        Public Property maintenance_id() As String
            Get
                Return mMaintenance_id
            End Get
            Set(ByVal value As String)
                mMaintenance_id = value
            End Set
        End Property

        Public Property maintenance_type() As String
            Get
                Return mMaintenance_type
            End Get
            Set(ByVal value As String)
                mMaintenance_type = value
            End Set
        End Property

        Public Property maintenance_outin() As Byte
            Get
                Return mMaintenance_outin
            End Get
            Set(ByVal value As Byte)
                mMaintenance_outin = value
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

        Public Property rekanan_id() As Decimal
            Get
                Return mRekanan_id
            End Get
            Set(ByVal value As Decimal)
                mRekanan_id = value
            End Set
        End Property

        Public Property maintenace_itemqty() As Int32
            Get
                Return mMaintenace_itemqty
            End Get
            Set(ByVal value As Int32)
                mMaintenace_itemqty = value
            End Set
        End Property

        Public Property maintenace_itemqtyret() As Int32
            Get
                Return mMaintenace_itemqtyret
            End Get
            Set(ByVal value As Int32)
                mMaintenace_itemqtyret = value
            End Set
        End Property

        Public Property employee_id() As String
            Get
                Return mEmployee_id
            End Get
            Set(ByVal value As String)
                mEmployee_id = value
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

        Public Property maintenance_indt() As DateTime
            Get
                Return mMaintenance_indt
            End Get
            Set(ByVal value As DateTime)
                mMaintenance_indt = value
            End Set
        End Property

        Public Property maintenance_outdt() As DateTime
            Get
                Return mMaintenance_outdt
            End Get
            Set(ByVal value As DateTime)
                mMaintenance_outdt = value
            End Set
        End Property

        Public Property maintenance_status() As String
            Get
                Return mMaintenance_status
            End Get
            Set(ByVal value As String)
                mMaintenance_status = value
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

        Public Property maintenance_harga() As Decimal
            Get
                Return mMaintenance_harga
            End Get
            Set(ByVal value As Decimal)
                mMaintenance_harga = value
            End Set
        End Property

        Public Property maintenance_valas() As Decimal
            Get
                Return mMaintenance_valas
            End Get
            Set(ByVal value As Decimal)
                mMaintenance_valas = value
            End Set
        End Property

        Public Property maintenance_idrprice() As Decimal
            Get
                Return mMaintenance_idrprice
            End Get
            Set(ByVal value As Decimal)
                mMaintenance_idrprice = value
            End Set
        End Property

        Public Property maintenance_inputby() As String
            Get
                Return mMaintenance_inputby
            End Get
            Set(ByVal value As String)
                mMaintenance_inputby = value
            End Set
        End Property

        Public Property maintenance_inputdt() As DateTime
            Get
                Return mMaintenance_inputdt
            End Get
            Set(ByVal value As DateTime)
                mMaintenance_inputdt = value
            End Set
        End Property

        Public Property maintenance_editby() As String
            Get
                Return mMaintenance_editby
            End Get
            Set(ByVal value As String)
                mMaintenance_editby = value
            End Set
        End Property

        Public Property maintenance_editdt() As DateTime
            Get
                Return mMaintenance_editdt
            End Get
            Set(ByVal value As DateTime)
                mMaintenance_editdt = value
            End Set
        End Property

        Public Property maintenance_usedby() As String
            Get
                Return mMaintenance_usedby
            End Get
            Set(ByVal value As String)
                mMaintenance_usedby = value
            End Set
        End Property

        Public Property maintenance_useddt() As DateTime
            Get
                Return mMaintenance_useddt
            End Get
            Set(ByVal value As DateTime)
                mMaintenance_useddt = value
            End Set
        End Property

        Public Property maintenance_outlock() As Byte
            Get
                Return mMaintenance_outlock
            End Get
            Set(ByVal value As Byte)
                mMaintenance_outlock = value
            End Set
        End Property

        Public Property maintenance_inclock() As Byte
            Get
                Return mMaintenance_inclock
            End Get
            Set(ByVal value As Byte)
                mMaintenance_inclock = value
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