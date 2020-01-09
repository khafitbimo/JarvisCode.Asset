Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptDepresiasiRekapReport
        Private DSN As String
        Private mKategoriasset_id As String
        Private mCost As Decimal
        Private mAdditional As Decimal
        Private mTotal As Decimal
        Private mDepre_Value As Decimal
        Private mAdjusment As Decimal
        Private mAccumulation_Depresiasi As Decimal
        Private mNBV As Decimal
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Public Property kategoriasset_id() As String
            Get
                Return mKategoriasset_id
            End Get
            Set(ByVal value As String)
                mKategoriasset_id = value
            End Set
        End Property

        Public Property Cost() As Decimal
            Get
                Return mCost
            End Get
            Set(ByVal value As Decimal)
                mCost = value
            End Set
        End Property

        Public Property Additional() As Decimal
            Get
                Return mAdditional
            End Get
            Set(ByVal value As Decimal)
                mAdditional = value
            End Set
        End Property

        Public Property Total() As Decimal
            Get
                Return mTotal
            End Get
            Set(ByVal value As Decimal)
                mTotal = value
            End Set
        End Property

        Public Property Depre_Value() As Decimal
            Get
                Return mDepre_Value
            End Get
            Set(ByVal value As Decimal)
                mDepre_Value = value
            End Set
        End Property

        Public Property Adjusment() As Decimal
            Get
                Return mAdjusment
            End Get
            Set(ByVal value As Decimal)
                mAdjusment = value
            End Set
        End Property

        Public Property Accumulation_Depresiasi() As Decimal
            Get
                Return mAccumulation_Depresiasi
            End Get
            Set(ByVal value As Decimal)
                mAccumulation_Depresiasi = value
            End Set
        End Property

        Public Property NBV() As Decimal
            Get
                Return mNBV
            End Get
            Set(ByVal value As Decimal)
                mNBV = value
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
        Private Sub setChannelDesc()
            If mChannel_id <> "" Then
                Dim tblBookasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" channel_id = '{0}' ", mChannel_id)
                    tblBookasset = clsUtil.GetDataTable("ms_MstChannel_Select", Me.DSN, parCriteria)
                    If tblBookasset.Rows.Count > 0 Then
                        Me.mChannel_namereport = Trim(tblBookasset.Rows(0)("channel_namereport").ToString)
                        Me.mChannel_address = Trim(tblBookasset.Rows(0)("channel_address").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving channel desc.")
                Finally
                    parCriteria = Nothing
                    tblBookasset = Nothing
                End Try
            End If
        End Sub


        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace