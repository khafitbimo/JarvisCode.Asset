Public Class clsMstAssetConsumable : Implements IDisposable

    Private _DSN As String
    Private _channel_id As String

    Private filler As clsDataFiller

#Region " Constructor "
    Sub New(ByVal channel_id As String, ByVal DSN As String)
        Me._DSN = DSN
        Me._channel_id = channel_id

        Me.filler = New clsDataFiller(Me._DSN)
    End Sub
#End Region

    Public Sub Retrieve(ByVal objTbl As DataTable, ByVal criteria As String)
        Try
            Me.filler.DataFill(objTbl, "inv_MstAssetconsumable_Select", criteria)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Retrieve(ByVal objTbl As DataTable, ByVal criteria As String, _
                        ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Try
            Me.filler.DataFill(objTbl, "inv_MstAssetconsumable_Select", criteria, dbConn, dbTrans)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub RetrieveViewMasterAssetConsumable(ByVal objTbl As DataTable, ByVal criteria As String)
        Try
            Me.filler.DataFill(objTbl, "inv_ViewMstAssetconsumable_Select", criteria)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Exists(ByVal asset_serial As String, ByVal strukturunit_id As Decimal, _
                           ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim tbl As New DataTable()
        Dim criteria As String

        criteria = String.Format("channel_id = '{0}' and asset_serial = '{1}' and strukturunit_id = '{2}'", Me._channel_id, asset_serial, strukturunit_id)

        Me.Retrieve(tbl, criteria, dbConn, dbTrans)

        If tbl.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Exists(ByVal asset_serial As String, ByVal strukturunit_id As Decimal) As Boolean
        Dim tbl As New DataTable()

        Me.Retrieve(tbl, String.Format("channel_id = '{0}' and asset_serial = '{1}' and strukturunit_id = '{2}'", Me._channel_id, asset_serial, strukturunit_id))

        If tbl.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub UpdateQty(ByVal asset_serial As String, ByVal qty As Integer, ByVal strukturunit_id As Decimal, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand
        Try
            cmd = New OleDb.OleDbCommand("inv_MstBarangConsumable_UpdateQty", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@channel_id", Me._channel_id)
            cmd.Parameters.AddWithValue("@strukturunit_id", strukturunit_id)
            cmd.Parameters.AddWithValue("@asset_serial", asset_serial)
            cmd.Parameters.AddWithValue("@qty", qty)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Insert(ByVal asset_serial As String, ByVal asset_description As String, ByVal strukturunit_id As Decimal, _
                      ByVal category_id As String, ByVal brand_id As Integer, ByVal tipeitem_id As String, _
                      ByVal asset_totalqty As Integer, ByVal asset_price As Decimal, ByVal dbConn As OleDb.OleDbConnection, _
                      ByVal dbTrans As OleDb.OleDbTransaction)

        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("inv_MstAssetconsumable_Insert", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@channel_id", Me._channel_id)
            cmd.Parameters.AddWithValue("@asset_serial", asset_serial)
            cmd.Parameters.AddWithValue("@asset_description", asset_description)
            cmd.Parameters.AddWithValue("@strukturunit_id", strukturunit_id)
            cmd.Parameters.AddWithValue("@category_id", category_id)
            cmd.Parameters.AddWithValue("@brand_id", brand_id)
            cmd.Parameters.AddWithValue("@tipeitem_id", tipeitem_id)
            cmd.Parameters.AddWithValue("@asset_totalqty", asset_totalqty)
            cmd.Parameters.AddWithValue("@asset_price", asset_price)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
