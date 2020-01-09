Public Class clsTrnOrder : Implements IDisposable

    Private DSN As String

    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub

    Private Sub RetrieveDetail(ByVal objTbl As DataTable, ByVal criteria As String)
        Try
            Using filler As New clsDataFiller(Me.DSN)
                filler.DataFill(objTbl, "pr_TrnOrderdetil_Select", criteria)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetRateFromDetail(ByVal order_id As String) As Decimal
        Using dbConn As New OleDb.OleDbConnection(Me.DSN)
            Dim cmd As OleDb.OleDbCommand
            Dim result As Object
            Dim cookie As Byte() = Nothing
            Try
                cmd = New OleDb.OleDbCommand("to_TrnOrderdetil_SelectRate", dbConn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@order_id", order_id)

                dbConn.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)
                result = cmd.ExecuteScalar()

                Return result
            Catch ex As Exception
                Throw ex
            Finally
                If dbConn.State = ConnectionState.Open Then
                    clsApplicationRole.UnsetAppRole(dbConn, cookie)
                    dbConn.Close()
                End If
            End Try
        End Using
    End Function

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
