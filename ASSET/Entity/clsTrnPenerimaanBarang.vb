Public Class clsTrnPenerimaanBarang : Implements IDisposable

    Private ReadOnly ImageFolder As String = "master_asset"
    Private DSN As String

    Enum AssetTypeDetail
        AssetNonProgram
        AssetProgram
        Consumable
        Floating
        Hadiah
        NonAssetNonProgram
        NonAssetProgram
    End Enum

#Region " Constructor "
    Sub New()
    End Sub

    Sub New(ByVal DSN As String)
        Me.DSN = DSN
    End Sub
#End Region

    Public Sub RetrieveHeader(ByVal objTbl As DataTable, ByVal Criteria As String, ByVal channel_id As String, ByVal top As Integer)
        Try
            Using filler As New clsDataFiller(DSN)
                filler.DataFill(objTbl, "as_TrnPenerimaanbarang_Select", Criteria, channel_id, top)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub RetrieveDetail(ByVal objTbl As DataTable, ByVal Criteria As String)
        Try
            Using filler As New clsDataFiller(Me.DSN)
                filler.DataFill(objTbl, "as_TrnPenerimaanbarangdetil_Select", Criteria)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub RetrieveAssetTypeCategory(ByVal objTbl As DataTable, ByVal Criteria As String)
        Try
            Using filler As New clsDataFiller(Me.DSN)
                filler.DataFill(objTbl, "as_MstTipeAssetKategori_Select", Criteria)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub RetrieveDetilUsedRentalWardrobe(ByVal objTbl As DataTable, ByVal request_id As String, ByVal requestdetil_line As Integer, ByVal DSNFrm As String)
        Using dbConn As New OleDb.OleDbConnection(DSNFrm)
            Dim cmd As OleDb.OleDbCommand
            Dim da As OleDb.OleDbDataAdapter
            Dim cookie As Byte() = Nothing
            Try
                cmd = New OleDb.OleDbCommand("as_TrnTerimajasadetilUsed_Select_RentalWardrobe", dbConn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@request_id", request_id)
                cmd.Parameters.AddWithValue("@requestdetil_line", requestdetil_line)

                dbConn.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)
                da = New OleDb.OleDbDataAdapter(cmd)
                da.Fill(objTbl)
            Catch ex As Exception
                Throw ex
            Finally
                If dbConn.State = ConnectionState.Open Then
                    clsApplicationRole.UnsetAppRole(dbConn, cookie)
                    dbConn.Close()
                End If
            End Try
        End Using
    End Sub

    Public Sub RetriveKategoriAssetDepre(ByVal objTbl As DataTable, ByVal Criteria As String)
        Try
            Using filler As New clsDataFiller(Me.DSN)
                filler.DataFill(objTbl, "as_MstKategoriassetdepre_Select", Criteria)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function [SelectHeader](ByVal terimabarang_id As String, ByVal channel_id As String) As DataRow
        Dim objTbl As New DataTable
        Dim criteria As String

        Try
            criteria = String.Format(" and terimabarang_id = '{0}'", terimabarang_id)

            Me.RetrieveHeader(objTbl, criteria, channel_id, 1)

            If objTbl.Rows.Count > 0 Then
                Return objTbl.Rows(0)
            Else
                Throw New Exception("terimabarang_id not found.")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SaveHeader(ByVal objTbl As DataTable, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmdInsert = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24, "terimabarang_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarang_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyitem", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyitem", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyrealization", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyrealization", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_statusrealization", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarang_statusrealization"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_location", System.Data.OleDb.OleDbType.VarWChar, 200, "terimabarang_location"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "terimabarang_notes"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_nosuratjalan", System.Data.OleDb.OleDbType.VarWChar, 70, "terimabarang_nosuratjalan"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_tglsuratjalan", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_tglsuratjalan"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_isdisabled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_createby", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_createby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_createdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_createdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_modifiedby", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_modifiedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_modifieddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appuser"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_appuser_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_appuser_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appspv"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_appspv_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_appspv_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appacc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_appacc_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_appacc_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_cetakbpb", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_cetakbpb"))

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_Update", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24, "terimabarang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarang_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyitem", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyitem", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyrealization", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyrealization", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_statusrealization", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarang_statusrealization"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_location", System.Data.OleDb.OleDbType.VarWChar, 200, "terimabarang_location"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "terimabarang_notes"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_nosuratjalan", System.Data.OleDb.OleDbType.VarWChar, 70, "terimabarang_nosuratjalan"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_tglsuratjalan", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_tglsuratjalan"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_isdisabled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_createby", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_createby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_createdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_createdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_modifiedby", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_modifiedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_modifieddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appuser"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_appuser_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_appuser_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appspv"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_appspv_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_appspv_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appacc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_appacc_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_appacc_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_cetakbpb", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_cetakbpb"))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Try
            dbDA.Update(objTbl)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SaveDetail(ByVal objTbl As DataTable, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_penerimaanbarangdetil
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24, "terimabarang_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_parentline", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_parentline"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_desc", System.Data.OleDb.OleDbType.VarWChar, 510, "terimabarangdetil_desc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarangdetil_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarangdetil_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@assetcategory_id", System.Data.OleDb.OleDbType.VarWChar, 60, "assetcategory_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@assettype_id", System.Data.OleDb.OleDbType.VarWChar, 60, "assettype_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_barcode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_parentbarcode", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_parentbarcode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemcategory_id", System.Data.OleDb.OleDbType.VarWChar, 60, "itemcategory_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemtype_id", System.Data.OleDb.OleDbType.VarWChar, 60, "itemtype_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_serial_no", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_serial_no"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_product_no", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_product_no"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_model", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_model"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@material_id", System.Data.OleDb.OleDbType.VarWChar, 60, "material_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@colour_id", System.Data.OleDb.OleDbType.VarWChar, 60, "colour_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@size_id", System.Data.OleDb.OleDbType.VarWChar, 60, "size_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sex_id", System.Data.OleDb.OleDbType.VarWChar, 30, "sex_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@room_id", System.Data.OleDb.OleDbType.VarWChar, 20, "room_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_rack", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarangdetil_rack"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qtydetail", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_qtydetail"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qtytotal", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_qtytotal"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "unit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimabarangdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimabarangdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_pphforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_pphidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_ppnforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_ppnidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_totalforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_totalforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_totalidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_totalidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_nonfixasset", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarangdetil_nonfixasset"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_golfiskal", System.Data.OleDb.OleDbType.VarWChar, 20, "terimabarangdetil_golfiskal"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_depre_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarangdetil_depre_enddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, "strukturunit_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id_cont", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id_cont"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_eps", System.Data.OleDb.OleDbType.VarWChar, 20, "terimabarangdetil_eps"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 24, "writeoff_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "writeoff_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_by", System.Data.OleDb.OleDbType.VarWChar, 100, "create_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "create_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100, "modified_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "modified_dt"))

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Update", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24, "terimabarang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_parentline", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_parentline"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_desc", System.Data.OleDb.OleDbType.VarWChar, 510, "terimabarangdetil_desc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarangdetil_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarangdetil_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@assetcategory_id", System.Data.OleDb.OleDbType.VarWChar, 60, "assetcategory_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@assettype_id", System.Data.OleDb.OleDbType.VarWChar, 60, "assettype_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_barcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_parentbarcode", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_parentbarcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemcategory_id", System.Data.OleDb.OleDbType.VarWChar, 60, "itemcategory_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemtype_id", System.Data.OleDb.OleDbType.VarWChar, 60, "itemtype_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_serial_no", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_serial_no"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_product_no", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_product_no"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_model", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_model"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@material_id", System.Data.OleDb.OleDbType.VarWChar, 60, "material_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@colour_id", System.Data.OleDb.OleDbType.VarWChar, 60, "colour_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@size_id", System.Data.OleDb.OleDbType.VarWChar, 60, "size_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sex_id", System.Data.OleDb.OleDbType.VarWChar, 30, "sex_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@room_id", System.Data.OleDb.OleDbType.VarWChar, 20, "room_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_rack", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarangdetil_rack"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qtydetail", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_qtydetail"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qtytotal", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_qtytotal"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "unit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimabarangdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimabarangdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_pphforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_pphidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_ppnforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_ppnidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_totalforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_totalforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_totalidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_totalidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_nonfixasset", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarangdetil_nonfixasset"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_golfiskal", System.Data.OleDb.OleDbType.VarWChar, 20, "terimabarangdetil_golfiskal"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_depre_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarangdetil_depre_enddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id_cont", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id_cont"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_eps", System.Data.OleDb.OleDbType.VarWChar, 20, "terimabarangdetil_eps"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 24, "writeoff_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "writeoff_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_by", System.Data.OleDb.OleDbType.VarWChar, 100, "create_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "create_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100, "modified_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "modified_dt"))

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Delete", dbConn, dbTrans)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24, "terimabarang_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_line"))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete

        Try
            dbDA.Update(objTbl)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteHeader(ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_Delete", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDate(ByVal terimabarang_id As String, ByVal terimabarang_date As Date, _
                                ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Try
            Using cmd As New OleDb.OleDbCommand("as_TrnPenerimaanBarang_UpdateDate", dbConn, dbTrans)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
                cmd.Parameters.AddWithValue("@terimabarang_date", terimabarang_date)

                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CreateBarcode(ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection, Optional ByVal dbTrans As OleDb.OleDbTransaction = Nothing)
        Dim cmd As OleDb.OleDbCommand

        Try
            If dbTrans IsNot Nothing Then
                cmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarang_CreateBarcode", dbConn, dbTrans)
            Else
                cmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarang_CreateBarcode", dbConn)
            End If

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ClearBarcode(ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarang_ClearBarcode", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CopyBarcodeToMasterAsset(ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarang_CopyBarcodeToMasterAsset", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteBarcodeFromMasterAsset(ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarang_DeleteBarcodeFromMasterAsset", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UserApproved(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal user_applogin As String, _
                            ByVal dbConnAsset As OleDb.OleDbConnection, ByVal dbTransAsset As OleDb.OleDbTransaction)
        Try
            Using cmd As New OleDb.OleDbCommand("as_TrnPerimaanBarang_UserApproved", dbConnAsset, dbTransAsset)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24).Value = terimabarang_id
                cmd.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = user_applogin
                cmd.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = channel_id
                cmd.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = "approved"

                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Data.OleDb.OleDbException
            Throw ex
        End Try
    End Sub

    Public Sub UserUnapproved(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal user_applogin As String, _
                            ByVal dbConnAsset As OleDb.OleDbConnection, ByVal dbTransAsset As OleDb.OleDbTransaction)
        Try

            Using cmd As New OleDb.OleDbCommand("as_TrnPerimaanBarang_UserApproved", dbConnAsset, dbTransAsset)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24).Value = terimabarang_id
                cmd.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = user_applogin
                cmd.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = channel_id
                cmd.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = "unapproved"

                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Data.OleDb.OleDbException
            Throw ex
        End Try
    End Sub

    Public Sub SpvApproved(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal user_applogin As String, ByVal terimabarang_status As String, _
                            ByVal dbConnAsset As OleDb.OleDbConnection, ByVal dbTransAsset As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarang_SpvApproved", dbConnAsset, dbTransAsset)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
            cmd.Parameters.AddWithValue("@user_applogin", user_applogin)
            cmd.Parameters.AddWithValue("@channel_id", channel_id)
            cmd.Parameters.AddWithValue("@status", terimabarang_status)
            cmd.Parameters.AddWithValue("@status_approved", "approved")

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SpvUnapproved(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal user_applogin As String, ByVal terimabarang_status As String, _
                              ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarang_SpvApproved", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
            cmd.Parameters.AddWithValue("@user_applogin", user_applogin)
            cmd.Parameters.AddWithValue("@channel_id", channel_id)
            cmd.Parameters.AddWithValue("@status", terimabarang_status)
            cmd.Parameters.AddWithValue("@status_approved", "unapproved")


            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AccApproved(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal acc_applogin As String, _
                           ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarang_AccApproved1", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
            cmd.Parameters.AddWithValue("@acc_applogin", acc_applogin)
            cmd.Parameters.AddWithValue("@channel_id", channel_id)
            cmd.Parameters.AddWithValue("@status", "approved") 'approved 'unapproved

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AccUnapproved(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal acc_applogin As String, _
                       ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarang_AccApproved1", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
            cmd.Parameters.AddWithValue("@acc_applogin", acc_applogin)
            cmd.Parameters.AddWithValue("@channel_id", channel_id)
            cmd.Parameters.AddWithValue("@status", "unapproved") 'approved 'unapproved

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub BuildJurnal(ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_BuildJurnal", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetAssetTypeDetail(ByVal rowDetail As DataRow) As AssetTypeDetail
        Select Case rowDetail.Item("assettype_id").ToString().Trim()
            Case "AssetNonProgram"
                Return AssetTypeDetail.AssetNonProgram
            Case "AssetProgram"
                Return AssetTypeDetail.AssetProgram
            Case "Consumable"
                Return AssetTypeDetail.Consumable
            Case "Floating"
                Return AssetTypeDetail.Floating
            Case "Hadiah"
                Return AssetTypeDetail.Hadiah
            Case "NonAssetNonProgram"
                Return AssetTypeDetail.NonAssetProgram
            Case "NonAssetProgram"
                Return AssetTypeDetail.NonAssetProgram
        End Select
    End Function

    Public Function GetImageFromDB(ByVal terimabarang_id As String, ByVal line As Integer, ByVal DSNFile As String) As Byte()
        Dim db As New DataClassesFILESDataContext(DSNFile)

        db.OpenConnectionWithRole()

        Try
            Dim picture = db.transaksi_penerimabarangdetilpictures.Where(Function(p) p.terimabarang_id = terimabarang_id _
                                                                             And line = p.terimabarangdetil_line).FirstOrDefault()

            If picture IsNot Nothing Then
                Return picture.filedata.ToArray()
            Else
                Throw New Exception("Image not found.")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Function

    Public Function GetImage(ByVal terimabarang_id As String, ByVal line As Integer, ByVal DirectoryImage As String) As Byte()
        Dim fileName As String = String.Format("{0}\{1}\{2}_{3}.jpg", DirectoryImage, Me.ImageFolder, terimabarang_id, line.ToString())

        If IO.File.Exists(fileName) Then
            Return clsUtil.GetBytes(fileName)
        Else
            Throw New Exception("Image not found.")
        End If
    End Function

    Public Sub SaveImageToDB(ByVal buffer() As Byte, ByVal terimabarang_id As String, ByVal line As Integer, ByVal DSNFiles As String)
        Dim db As New DataClassesFILESDataContext(DSNFiles)

        db.OpenConnectionWithRole()

        Try
            Dim picture = db.transaksi_penerimabarangdetilpictures.Where(Function(p) p.terimabarang_id = terimabarang_id And _
                                                                             p.terimabarangdetil_line = line).FirstOrDefault()

            If picture IsNot Nothing Then
                db.transaksi_penerimabarangdetilpictures.DeleteOnSubmit(picture)
                db.SubmitChanges()
            End If

            db.as_PenerimaanBarangDetilPicture_Insert(terimabarang_id, line, buffer)
        Catch ex As Exception
            Throw ex
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Sub

    Public Sub SaveImage(ByVal buffer() As Byte, ByVal terimabarang_id As String, ByVal line As Integer, ByVal DirectoryImage As String)
        Try
            Dim fileName As String = String.Format("{0}\{1}\{2}_{3}.jpg", DirectoryImage, Me.ImageFolder, terimabarang_id, line.ToString())
            Dim fileInfo As New IO.FileInfo(fileName)

            If fileInfo.Exists() Then
                fileInfo.Delete()
            End If

            My.Computer.FileSystem.WriteAllBytes(fileName, buffer, False)
            '=============================================================================================================================================
            Dim fileNameKecil As String = String.Format("{0}\{1}\{2}_{3}{4}.jpg", DirectoryImage, Me.ImageFolder + "\images_kecil", terimabarang_id, line.ToString(), "K")

            Dim intType As Integer = 0
            Dim imgSource As Image = Image.FromFile(fileName)
            Dim imgOutput As Image

            Dim intX, intY As Integer
            intX = Int(imgSource.Width / 100 * 6)
            intY = Int(imgSource.Height / 100 * 6)
            Dim bm As Drawing.Bitmap = New System.Drawing.Bitmap(intX, intY)
            Dim g As System.Drawing.Graphics = Drawing.Graphics.FromImage(bm)

            Select Case intType
                Case 0
                    g.InterpolationMode = Drawing.Drawing2D.InterpolationMode.Default
                Case 1
                    g.InterpolationMode = Drawing.Drawing2D.InterpolationMode.High
                Case 2
                    g.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBilinear
                Case 3
                    g.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            End Select

            g.DrawImage(imgSource, 0, 0, intX, intY)
            imgOutput = bm
            imgOutput.Save(fileNameKecil)
            '===============================================================================================================================================
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteImage(ByVal terimabarang_id As String, ByVal line As Integer, ByVal DirectoryImage As String)
        Try
            Dim fileName As String = String.Format("{0}\{1}\{2}_{3}.jpg", DirectoryImage, Me.ImageFolder, terimabarang_id, line.ToString())
            Dim fileInfo As New IO.FileInfo(fileName)

            If fileInfo.Exists() Then
                fileInfo.Delete()
            End If

            Dim fileNameKecil As String = String.Format("{0}\{1}\{2}_{3}{4}.jpg", DirectoryImage, Me.ImageFolder + "\images_kecil", terimabarang_id, line.ToString(), "K")
            Dim fileInfoKecil As New IO.FileInfo(fileNameKecil)

            If fileInfoKecil.Exists() Then
                fileInfoKecil.Delete()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetAccountOth(ByVal budget_id As Decimal, ByVal budgetdetil_id As Decimal) As Decimal
        Dim dbConn As New OleDb.OleDbConnection(Me.DSN)
        Dim cmd As OleDb.OleDbCommand
        Dim result As Object
        Dim cookie As Byte() = Nothing
        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_GetAccountOth", dbConn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@budget_id", budget_id)
            cmd.Parameters.AddWithValue("@budgetdetil_id", budgetdetil_id)

            result = cmd.ExecuteScalar

            If result Is DBNull.Value OrElse result Is Nothing Then
                Return 0
            Else
                Return result
            End If
        Catch ex As Exception
            Return 0
        Finally
            If dbConn.State = ConnectionState.Open Then
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()
            End If
        End Try
    End Function

    Public Sub UpdateRefRequest(ByVal request_id As String, ByVal request_line As Integer, ByVal terimabarang_id As String, _
                                ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Try
            Using cmd As New OleDb.OleDbCommand("as_TrnPenerimaanbarang_UpdateRefRequest", dbConn, dbTrans)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@request_id", request_id)
                cmd.Parameters.AddWithValue("@request_line", request_line)
                cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)

                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ClearRefRequest(ByVal request_id As String, ByVal request_line As Integer, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_ClearRefRequest", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@request_id", request_id)
            cmd.Parameters.AddWithValue("@line", request_line)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ClearRefRequestAll(ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_ClearRefRequestAll", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' ARI MDP2 20151123 Untuk ListRV
    '========================================================================================================================================================================
    Public Sub RetrieveHeaderListRV(ByVal objTbl As DataTable, ByVal Criteria As String, ByVal channel_id As String, ByVal top As Integer)
        Try
            Using filler As New clsDataFiller(DSN)
                filler.DataFill(objTbl, "as_TrnPenerimaanbarang_SelectListRV", Criteria, channel_id, top)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateValueAssetDepre(ByVal terimabarang_id As String, ByVal terimabarangdetil_line As Integer, ByVal isposting As Integer, _
                                     ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction)
        Dim cmd As OleDb.OleDbCommand

        Try
            cmd = New OleDb.OleDbCommand("as_TrnPenerimaanBarang_NewAssetRVListRV", dbConn, dbTrans)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
            cmd.Parameters.AddWithValue("@terimabarangdetil_line", terimabarangdetil_line)
            cmd.Parameters.AddWithValue("@isPosting", isposting)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function CheckingBPBAmountWithDiscPerLine(ByVal objTbl As DataTable, ByVal rv_id As String, ByVal order_id As String, ByVal orderdetil_line As Int32, _
                                                    ByVal AmountNew As Decimal) As Boolean

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand("as_TrnCheckAmountRV_PO_Select", dbConn)
        'If channel_id <> "" Then
        '    dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        '    dbCmd.Parameters("@channel_id").Value = channel_id
        'End If

        dbCmd.Parameters.Add("@rv_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@rv_id").Value = rv_id

        dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@order_id").Value = order_id

        dbCmd.Parameters.Add("@orderdetil_line", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@orderdetil_line").Value = orderdetil_line

        dbCmd.Parameters.Add("@AmountNew", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@AmountNew").Value = AmountNew

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            objTbl.Clear()
            dbDA.Fill(objTbl)
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True
    End Function

    Public Function CheckingBPJAmountWithDiscPerLine(ByVal objTbl As DataTable, ByVal rv_id As String, ByVal order_id As String, ByVal orderdetil_line As Int32, _
                                                    ByVal AmountNew As Decimal) As Boolean

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        dbCmd = New OleDb.OleDbCommand("as_TrnCheckAmountTerimaJasa_Order_Select", dbConn)
        'If channel_id <> "" Then
        '    dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        '    dbCmd.Parameters("@channel_id").Value = channel_id
        'End If

        dbCmd.Parameters.Add("@rv_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@rv_id").Value = rv_id

        dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@order_id").Value = order_id

        dbCmd.Parameters.Add("@orderdetil_line", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@orderdetil_line").Value = orderdetil_line

        dbCmd.Parameters.Add("@AmountNew", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@AmountNew").Value = AmountNew

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            objTbl.Clear()
            dbDA.Fill(objTbl)
        Catch ex As Exception
            Throw ex
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True
    End Function
    '========================================================================================================================================================================

#Region " Print "

    Private Sub RetrieveReportHeader(ByVal objTbl As DataTable, ByVal criteria As String, ByVal channel_id As String, ByVal assetDSN As String)
        Try
            Using filler As New clsDataFiller(assetDSN)
                filler.DataFill(objTbl, "as_RptPenerimaanBarang_Select", criteria, channel_id)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RetrieveReportDetil(ByVal objTbl As DataTable, ByVal criteria As String, ByVal channel_id As String, ByVal assetDSN As String)
        Try
            Using filler As New clsDataFiller(assetDSN)
                filler.DataFill(objTbl, "as_RptPenerimaanBarangDetil_Select", criteria, channel_id)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Print(ByVal terimabarang_id As String, ByVal sptServer As String, ByVal channel_id As String,
                     ByVal keterangan As String, Optional ByVal preview As Boolean = False)
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", sptServer)
        Dim tbl_TrnPenerimaanBarang As DataTable = clsDataset.CreateTblTrnPenerimaanbarang()
        Dim tbl_trnPenerimaanBarangDetil As DataTable = clsDataset.CreateTblTrnPenerimaanbarangdetil()
        Dim criteria As String

        criteria = String.Format("terimabarang_id = '{0}'", terimabarang_id)

        Me.RetrieveReportHeader(tbl_TrnPenerimaanBarang, criteria, channel_id, Me.DSN)
        Me.RetrieveReportDetil(tbl_trnPenerimaanBarangDetil, criteria, channel_id, Me.DSN)

        objDatalistHeader = Me.GenerateDataHeader(tbl_TrnPenerimaanBarang, tbl_trnPenerimaanBarangDetil, DSN)

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.sptChannel_ID)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptTerimaBarang_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("terimabarang_id", Me.sptTerimaBarang_ID)
        Dim parRptDomain As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", Me.sptDomain)
        '===20140226 pts ADD==
        Dim parRptSumTotal As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumtotal", Me.sptSumTotal)
        Dim parRptSumDiscount As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumdiscount", Me.sptSumDiscount)
        Dim parRptSumPPN As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumppn", Me.sptSumPPn)
        Dim parRptSumPPH As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumpph", Me.sptSumPPh)
        Dim parRptSumGrandTotal As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumgrandtotal", Me.sptSumGrandTotal)
        '=====================
        objRdsH.Name = "ASSET_DataSource_clsRptPenerimaanBarang"
        objRdsH.Value = objDatalistHeader
        '
        If keterangan = "Internal" Then
            objReportH.ReportEmbeddedResource = "ASSET.rptPenerimaanBarang.rdlc"
        Else
            objReportH.ReportEmbeddedResource = "ASSET.rptPenerimaanBarangX1.rdlc"
        End If

        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "rvPenerimaanBarang"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID,
                                                                                                        parRptChannel_namereport, parRptChannel_address, parRptTerimaBarang_ID,
                                                                                                        parRptDomain, parRptSumTotal, parRptSumDiscount, parRptSumPPN,
                                                                                                        parRptSumGrandTotal, parRptSumPPH})

        If preview = True Then
            Dim dlg As New Form

            objReportViewer.Dock = DockStyle.Fill

            dlg.Controls.Add(objReportViewer)

            objReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            objReportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
            objReportViewer.ZoomPercent = 25

            dlg.WindowState = FormWindowState.Maximized
            dlg.Show()
        Else
            Using reportPrint As New clsQuickPrint(objReportViewer.LocalReport)
                reportPrint.Print()
            End Using
        End If
    End Sub

    Private Function GenerateDataHeader(ByVal tbl_Print As DataTable, ByVal tbl_PrintDetil As DataTable, ByVal startDSN As String) As ArrayList
        Dim objPrintHeader As DataSource.clsRptPenerimaanBarang
        Dim objDatalistHeader As ArrayList = New ArrayList()

        Dim Total, Discount, SumPPN, SumPPH, SumGrandTotal, SumTotal, SumDiscount As Decimal
        Dim currency As Integer

        SumTotal = 0
        SumDiscount = 0

        currency = tbl_Print.Rows(0).Item("currency_id")

        For a As Integer = 0 To tbl_PrintDetil.Rows.Count - 1
            Total = tbl_PrintDetil.Rows(a).Item("terimabarangdetil_foreign") * tbl_PrintDetil.Rows(a).Item("terimabarangdetil_foreignrate") * tbl_PrintDetil.Rows(a).Item("terimabarangdetil_qty")

            'If currency = 1 Then
            '    Total = Math.Round(tbl_PrintDetil.Rows(a).Item("terimabarangdetil_foreign") * tbl_PrintDetil.Rows(a).Item("terimabarangdetil_foreignrate") * tbl_PrintDetil.Rows(a).Item("terimabarangdetil_qty"))
            'End If

            SumTotal = SumTotal + Total
        Next

        For w As Integer = 0 To tbl_PrintDetil.Rows.Count - 1
            Discount = tbl_PrintDetil.Rows(w).Item("terimabarangdetil_disc") * tbl_PrintDetil.Rows(w).Item("terimabarangdetil_qty") * tbl_PrintDetil.Rows(w).Item("terimabarangdetil_foreignrate")

            'If currency = 1 Then
            '    Discount = Math.Round(Discount)
            'End If
            SumDiscount = SumDiscount + Discount
        Next

        Dim row As DataRow

        For b As Integer = 0 To tbl_PrintDetil.Rows.Count - 1
            row = tbl_PrintDetil.Rows(b)

            SumPPH += (((row.Item("terimabarangdetil_foreign") - row.Item("terimabarangdetil_disc")) * row.Item("terimabarangdetil_foreignrate")) * (row.Item("terimabarangdetil_pphpercent") / 100)) * row.Item("terimabarangdetil_qty")
            SumPPN += (((row.Item("terimabarangdetil_foreign") - row.Item("terimabarangdetil_disc")) * row.Item("terimabarangdetil_foreignrate")) * (row.Item("terimabarangdetil_ppnpercent") / 100)) * row.Item("terimabarangdetil_qty")
        Next

        'SumPPH = Math.Round(SumPPH, 0, MidpointRounding.AwayFromZero)
        'SumPPN = Math.Round(SumPPN, 0, MidpointRounding.AwayFromZero)

        SumGrandTotal = SumTotal - SumDiscount + SumPPN - SumPPH

        Me.sptSumTotal = SumTotal
        Me.sptSumDiscount = SumDiscount
        Me.sptSumPPn = SumPPN
        Me.sptSumPPh = SumPPH
        Me.sptSumGrandTotal = SumGrandTotal
        '=========================================================

        For i As Integer = 0 To tbl_Print.Rows.Count - 1
            GenerateDataDetail(tbl_PrintDetil)
            objPrintHeader = New DataSource.clsRptPenerimaanBarang(startDSN)
            With objPrintHeader
                .terimabarang_id = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("terimabarang_id").ToString, String.Empty)
                .terimabarang_date = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("terimabarang_date"), Now())
                .order_id = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("order_id").ToString, String.Empty)
                .budget_id = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("budget_id"), 0)
                .budget_name = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("budget_name"), String.Empty)
                .rekanan_id = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("rekanan_id"), 0)
                .rekanan_name = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("rekanan_name"), String.Empty)
                .employee_id_owner = StrConv(clsUtil.IsDbNull(tbl_Print.Rows(0).Item("employee_name_owner").ToString, String.Empty), vbProperCase)
                .strukturunit_id = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("strukturunit_id"), 0)
                .department = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("department"), String.Empty)
                .terimabarang_status = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("terimabarang_status").ToString, String.Empty)
                .terimabarang_statusrealization = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("terimabarang_statusrealization").ToString, String.Empty)
                .terimabarang_location = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("terimabarang_location").ToString, String.Empty)
                .terimabarang_notes = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("terimabarang_notes").ToString, String.Empty)
                .channel_id = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
                .terimabarang_appspv_by = clsUtil.IsDbNull(tbl_Print.Rows(0).Item("terimabarang_appspv_name").ToString, String.Empty)

                Me.sptChannel_ID = .channel_id
                Me.sptChannel_nameReport = .channel_namereport
                Me.sptChannel_address = .channel_address
                Me.sptTerimaBarang_ID = .terimabarang_id
                Me.sptDomain = .domain_name
            End With

            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail(ByVal tbl_PrintDetil As DataTable)
        Dim objDetil As DataSource.clsRptPenerimaanBarangDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptPenerimaanBarangDetil()
            With objDetil
                .terimabarang_id = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                .terimabarangdetil_line = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_line"), 0)
                .terimabarangdetil_desc = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_desc").ToString, String.Empty)
                .terimabarang_barcode = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarang_barcode").ToString, String.Empty)
                .itemtype_id = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("itemtype_id").ToString, String.Empty)
                .brand_id = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("brand_id"), 0)
                .brand_name = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("brand_name"), String.Empty)
                .terimabarangdetil_serial_no = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_serial_no").ToString, String.Empty)
                .room_id = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("room_id").ToString, String.Empty)
                .room_name = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("room_name").ToString, String.Empty)
                .terimabarangdetil_qty = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_qty"), 0)
                .terimabarangdetil_foreign = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_foreign"), 0)
                .terimabarangdetil_foreignrate = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_foreignrate"), 0)
                .terimabarangdetil_idrreal = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_idrreal"), 0)
                .terimabarangdetil_pphpercent = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_pphpercent"), 0)
                .terimabarangdetil_ppnpercent = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_ppnpercent"), 0)
                .terimabarangdetil_disc = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_disc"), 0)
                .terimabarangdetil_pphforeign = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_pphforeign"), 0)
                .terimabarangdetil_pphidrreal = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_pphidrreal"), 0)
                .terimabarangdetil_ppnforeign = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_ppnforeign"), 0)
                .terimabarangdetil_ppnidrreal = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_ppnidrreal"), 0)
                .terimabarangdetil_totalforeign = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_totalforeign"), 0)
                .terimabarangdetil_totalidrreal = clsUtil.IsDbNull(tbl_PrintDetil.Rows(i).Item("terimabarangdetil_totalidrreal"), 0)

                Dim ppn_idrreal As Decimal

                ppn_idrreal += .terimabarangdetil_ppnidrreal
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptPenerimaanBarangDetil", objDatalistDetil))
    End Sub

    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptTerimaBarang_ID As String
    Private sptDomain As String
    Private sptSumTotal As String
    Private sptSumDiscount As String
    Private sptSumPPn As String
    Private sptSumPPh As String
    Private sptSumGrandTotal As String
    Private objDatalistDetil As New ArrayList
#End Region

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
