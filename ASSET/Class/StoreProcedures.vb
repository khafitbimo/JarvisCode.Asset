Imports System.Data.SqlClient

Public Class StoreProcedures

    Public Shared Sub as_IUDReceiveStatus(ByVal DSN As String,
                                          ByVal channel_id As String,
                                          ByVal transaksi_receivestatus As DataTable,
                                          ByVal transaksi_receivestatusattach As DataTable,
                                          ByVal transaksi_receivestatusattachment As DataTable,
                                          ByRef receivestatus_id As String)
        Dim dbConn As New SqlConnection(DSN)
        Dim cmd As SqlCommand
        Dim cookie() As Byte = Nothing

        dbConn.Open()

        clsApplicationRole.SetAppRoles(dbConn, cookie)
        Try
            cmd = New SqlCommand("as_IUDReceiveStatus", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@channel_id", channel_id)
            cmd.Parameters.AddWithValue("@transaksi_receivestatus", transaksi_receivestatus)
            cmd.Parameters.AddWithValue("@transaksi_receivestatusattach", transaksi_receivestatusattach)
            cmd.Parameters.AddWithValue("@transaksi_receivestatusattachment", transaksi_receivestatusattachment)

            Dim paramReceiveStatus = cmd.Parameters.Add("@receivestatus_id", SqlDbType.NVarChar, 12)

            paramReceiveStatus.Direction = ParameterDirection.InputOutput
            paramReceiveStatus.Value = receivestatus_id

            cmd.ExecuteNonQuery()

            receivestatus_id = paramReceiveStatus.Value
        Catch ex As Exception
            Throw ex
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRoles(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Sub

End Class
