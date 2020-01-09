Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptBPJ_RentalIdle
        Private DSN As String
        Private mAmount_idr_idle As Decimal
        Private mTerimajasaused_qty_idle As Int32
        Private mTerimajasa_id As String
        Private mTerimajasadetil_line As Int32
        Private mItem_id As String
        Private mItem_name As String
        Private mBudget_id As Decimal
        Private mBudget_name As String
        Private mRekanan_id As Decimal
        Private mRekanan_name As String
        Private mEmployee_id_owner As String
        Private mEmployee_name As String
        Private mOrder_id As String
        Private mTerimajasa_date As DateTime
        Private mStrukturunit_id As String
        Private mStrukturunit_name As String
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mQty_order As Integer
        Private mQty_RV As Integer

        Public Property amount_idr_idle() As Decimal
            Get
                Return mAmount_idr_idle
            End Get
            Set(ByVal value As Decimal)
                mAmount_idr_idle = value
            End Set
        End Property
        Public Property terimajasaused_qty_idle() As Int32
            Get
                Return mTerimajasaused_qty_idle
            End Get
            Set(ByVal value As Int32)
                mTerimajasaused_qty_idle = value
            End Set
        End Property
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
            End Set
        End Property
        Public Property item_id() As String
            Get
                Return mItem_id
            End Get
            Set(ByVal value As String)
                mItem_id = value
            End Set
        End Property
        Public Property item_named() As String
            Get
                Return mItem_name
            End Get
            Set(ByVal value As String)
                mItem_name = value
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
        Public Property budget_name() As String
            Get
                Return mBudget_name
            End Get
            Set(ByVal value As String)
                mBudget_name = value
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
        Public Property rekanan_name() As String
            Get
                Return mRekanan_name
            End Get
            Set(ByVal value As String)
                mRekanan_name = value
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
        Public Property employee_name() As String
            Get
                Return mEmployee_name
            End Get
            Set(ByVal value As String)
                mEmployee_name = value
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
        Public Property terimajasa_date() As DateTime
            Get
                Return mTerimajasa_date
            End Get
            Set(ByVal value As DateTime)
                mTerimajasa_date = value
            End Set
        End Property
        Public Property strukturunit_id() As String
            Get
                Return mStrukturunit_id
            End Get
            Set(ByVal value As String)
                mStrukturunit_id = value
            End Set
        End Property
        Public Property strukturunit_name() As String
            Get
                Return mStrukturunit_name
            End Get
            Set(ByVal value As String)
                mStrukturunit_name = value
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
        Public Property qty_order() As Integer
            Get
                Return mQty_order
            End Get
            Set(ByVal value As Integer)
                mQty_order = value
            End Set
        End Property
        Public Property qty_rv() As Integer
            Get
                Return mQty_RV
            End Get
            Set(ByVal value As Integer)
                mQty_RV = value
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
