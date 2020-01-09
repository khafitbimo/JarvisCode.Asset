Public Class clsMstAssetConsumableClosing

    Private DSN As String
    Private channel_id As String

#Region " Constructor "
    Sub New(ByVal channel_id As String, ByVal DSN As String)
        Me.channel_id = channel_id
        Me.DSN = DSN
    End Sub
#End Region

    Public Sub Insert(ByVal asset_serial As String, ByVal strukturunit_id As Decimal, ByVal asset_totalqty As Integer, _
                      ByVal is_closing As Int16, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("inv_MstAssetConsumableClosing_Insert", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@channel_id", Me.channel_id)
            cmd.Parameters.AddWithValue("@asset_serial", asset_serial)
            cmd.Parameters.AddWithValue("@strukturunit_id", strukturunit_id)
            cmd.Parameters.AddWithValue("@asset_totalqty", asset_totalqty)
            cmd.Parameters.AddWithValue("@is_closing", is_closing)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function IsClosing(ByVal asset_serial As String, ByVal strukturunit_id As String) As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim res As Integer
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            cmd = New OleDb.OleDbCommand("inv_MstAssetConsumableClosing_IsClosing", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@channel_id", Me.channel_id)
            cmd.Parameters.AddWithValue("@asset_serial", asset_serial)
            cmd.Parameters.AddWithValue("@strukturunit_id", strukturunit_id)

            res = cmd.ExecuteScalar()

            If res = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function
End Class
