Public Class clsMstChannel

    Private DSN As String

    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub

    Public Function [Select](ByVal channel_id As String) As DataRow
        Dim objTbl As New DataTable

        Try
            Me.Retrieve(objTbl, String.Format("channel_id = '{0}'", channel_id))

            If objTbl.Rows.Count > 0 Then
                Return objTbl.Rows(0)
            Else
                Throw New Exception("channel_id : " + channel_id + " not found.")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Retrieve(ByVal objTbl As DataTable, ByVal Criteria As String)
        Try
            Using filler As New clsDataFiller(Me.DSN)
                filler.DataFill(objTbl, "ms_MstChannel_Select", Criteria)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
