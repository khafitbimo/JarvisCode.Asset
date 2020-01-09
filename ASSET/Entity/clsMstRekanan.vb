Public Class clsMstRekanan

    Private DSN As String
    Private filler As clsDataFiller

    Sub New(ByVal DSN As String)
        Me.DSN = DSN
        Me.filler = New clsDataFiller(Me.DSN)
    End Sub

    Public Sub Retrieve(ByVal objTbl As DataTable, ByVal criteria As String)
        Try
            objTbl.Clear()

            Me.filler.DataFill(objTbl, "ms_MstRekananCombo_Select", criteria)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
