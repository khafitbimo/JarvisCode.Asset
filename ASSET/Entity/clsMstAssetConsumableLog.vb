Public Class clsMstAssetConsumableLog

    Private channel_id As String

#Region " Constructor "
    Sub New(ByVal channel_id As String)
        Me.channel_id = channel_id
    End Sub
#End Region

    Public Sub Delete(ByVal terimabarang_id As String, ByVal terimabarang_line As Integer, _
                      ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("inv_MstAssetconsumableLog_Delete", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
            cmd.Parameters.AddWithValue("@terimabarang_line", terimabarang_line)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Insert(ByVal terimabarang_id As String, ByVal terimabarang_line As Integer, _
                      ByVal asset_barcode As String, ByVal asset_serial As String, ByVal asset_qty As Integer, _
                      ByVal asset_qtydetil As Integer, ByVal asset_qtytotal As Integer, ByVal strukturunit_id As Decimal, _
                      ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)

        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("inv_MstAssetconsumableLog_Insert", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@channel_id", Me.channel_id)
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
            cmd.Parameters.AddWithValue("@terimabarang_line", terimabarang_line)
            cmd.Parameters.AddWithValue("@asset_barcode", asset_barcode)
            cmd.Parameters.AddWithValue("@asset_serial", asset_serial)
            cmd.Parameters.AddWithValue("@asset_qty", asset_qty)
            cmd.Parameters.AddWithValue("@asset_qtydetail", asset_qtydetil)
            cmd.Parameters.AddWithValue("@asset_qtytotal", asset_qtytotal)
            cmd.Parameters.AddWithValue("@strukturunit_id", strukturunit_id)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
