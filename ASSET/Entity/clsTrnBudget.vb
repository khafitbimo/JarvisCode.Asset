Public Class clsTrnBudget : Implements IDisposable

    Private DSN As String

    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub

    Public Function [Select](ByVal budget_id As Decimal) As DataRow
        Dim objTbl As New DataTable

        Try
            Me.Retrieve(objTbl, String.Format("budget_id = {0}", budget_id))

            If objTbl.Rows.Count > 0 Then
                Return objTbl.Rows(0)
            Else
                Throw New Exception("budget_id not found.")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Retrieve(ByVal objTbl As DataTable, ByVal Criteria As String)
        Try
            Using filler As New clsDataFiller(Me.DSN)
                filler.DataFill(objTbl, "bg_TrnBudget_Select3", Criteria)
            End Using
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
