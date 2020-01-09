Public Class clsRVListPV

    Private DSN As String
    Private filler As clsDataFiller

#Region " Constructor "
    Sub New(ByVal DSN As String)
        Me.DSN = DSN
        Me.filler = New clsDataFiller(Me.DSN)
    End Sub
#End Region

    Public Sub Retrieve(ByVal objTbl As DataTable, ByVal criteria As String)
        Try
            Me.filler.DataFill(objTbl, "act_Trn_PVListAdvance_Select", criteria)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetPVForeignFromJurnal(ByVal pv_id As String) As Decimal
        Dim tbl As New DataTable()
        Dim criteria As String
        Dim val As Decimal = 0

        Try
            criteria = String.Format("jurnal_id = '{0}'", pv_id)

            Me.Retrieve(tbl, criteria)

            If tbl.Rows.Count > 0 Then
                Dim row As DataRow = tbl.Rows(0)

                val = row.Item("foreign")
            ElseIf tbl.Rows.Count <= 0 Then
                Throw New Exception("PV not found in database")
            End If

            Return val
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetPVForeignFromReceive(ByVal pv_id As String, ByVal terimabarang_id As String) As Decimal
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim reader As OleDb.OleDbDataReader
        Dim val As Decimal
        Dim cookie As Byte() = Nothing

        cmd = New OleDb.OleDbCommand("act_Trn_RVListPV_SelectSum", dbConn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@pv_id", pv_id)
        cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            reader = cmd.ExecuteReader
            While reader.Read
                val = reader.Item("terimabarang_amount")
            End While

            reader.Close()

            Return val
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function
End Class
