Public Class clsMstKategoriAssetAcc

    Public Structure Account
        Public Debet As String
        Public Credit As String
    End Structure

    Private DSN As String

    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub

    Public Sub Retrieve()
        Try
            Using filler As New clsDataFiller(Me.DSN)

            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetAccount() As Account

    End Function

End Class
