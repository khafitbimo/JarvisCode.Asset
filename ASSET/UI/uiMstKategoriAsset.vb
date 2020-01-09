Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid

Public Class uiMstKategoriAsset
    Private Const mUiName As String = "Asset Category "
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)

    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_MstKategoriasset As DataTable = CreateTblMstKategoriasset()
    Private tbl_MstKategoriasset_Temp As DataTable = CreateTblMstKategoriasset()
    Private tbl_MstKategoriAssetRVAcc As DataTable = CreateTblMstKategoriAssetAccount()
    Private tbl_MstKategoriAssetDisposalAcc As DataTable = CreateTblMstKategoriAssetAccount()
    Private tbl_MstKategoriAssetDepreAcc As DataTable = CreateTblMstKategoriAssetAccount()
    Private tbl_MstKategoriassetpilihan As DataTable = clsDataset.CreateTblMstPilihan
    Private tbl_MstAcc As DataTable = CreateTblMstAccount()


#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 

#End Region

#Region " Window Dataset "
    Public Shared Function CreateTblMstKategoriasset() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_time", GetType(System.Int64)))
        tbl.Columns.Add(New DataColumn("kategoriasset_depresiasitime", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("kategoriasset_depresiasivalue", GetType(System.Decimal)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("kategoriasset_id").DefaultValue = ""
        tbl.Columns("kategoriasset_time").DefaultValue = 0
        tbl.Columns("kategoriasset_depresiasitime").DefaultValue = ""
        tbl.Columns("kategoriasset_depresiasivalue").DefaultValue = 0

        Return tbl
    End Function

    Public Shared Function CreateTblMstKategoriAssetAccount() As DataTable
        Dim tbl As DataTable = New DataTable
        tbl.Columns.Clear()

        tbl.Columns.Add(New DataColumn("kategoriasset_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("modul", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("debit_acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("credit_acc_id", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("kategoriasset_id").DefaultValue = ""
        tbl.Columns("modul").DefaultValue = ""
        tbl.Columns("debit_acc_id").DefaultValue = ""
        tbl.Columns("credit_acc_id").DefaultValue = ""

        Return tbl
    End Function

    Public Shared Function CreateTblMstAccount() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("acc_id", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("acc_name", GetType(System.String)))

        '-------------------------------
        'Default Value: 
        tbl.Columns("acc_id").DefaultValue = ""
        tbl.Columns("acc_name").DefaultValue = ""

        Return tbl
    End Function

#End Region


#Region " Overrides "

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible
        If Me.PnlDfSearch.Visible Then
            FILTER_QUERY_MODE = True
            Me.tbtnQuery.Checked = CheckState.Checked
        Else
            FILTER_QUERY_MODE = False
            Me.tbtnQuery.Checked = CheckState.Unchecked
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnNew_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If Me.ftabMain.SelectedTabPageIndex = 0 Then
            Me.ftabMain.SelectedTabPageIndex = 1
        End If
        Me.uiMstKategoriAsset_NewData()
        Me.obj_Kategoriasset_id.Focus()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriAsset_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiMstKategoriAsset_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriAsset_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriAsset_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriAsset_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriAsset_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriAsset_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriAsset_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriAsset_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

#End Region


#Region " Layout & Init UI "

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Kategoriasset_id.DataBindings.Clear()
        Me.obj_Kategoriasset_time.DataBindings.Clear()
        Me.obj_Kategoriasset_depresiasitime.DataBindings.Clear()
        Me.obj_Kategoriasset_depresiasivalue.DataBindings.Clear()

        Me.objRVDebet.DataBindings.Clear()
        Me.objRVKredit.DataBindings.Clear()
        Me.objDisposalDebet.DataBindings.Clear()
        Me.objDisposalKredit.DataBindings.Clear()
        Me.objDepreDebet.DataBindings.Clear()
        Me.objDepreKredit.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Kategoriasset_id.DataBindings.Add(New Binding("Text", Me.tbl_MstKategoriasset_Temp, "kategoriasset_id"))
        Me.obj_Kategoriasset_time.DataBindings.Add(New Binding("Text", Me.tbl_MstKategoriasset_Temp, "kategoriasset_time"))
        Me.obj_Kategoriasset_depresiasitime.DataBindings.Add(New Binding("EditValue", Me.tbl_MstKategoriasset_Temp, "kategoriasset_depresiasitime"))
        Me.obj_Kategoriasset_depresiasivalue.DataBindings.Add(New Binding("Text", Me.tbl_MstKategoriasset_Temp, "kategoriasset_depresiasivalue", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))

        If Me.tbl_MstKategoriAssetRVAcc.Rows.Count > 0 Then
            Me.objRVDebet.DataBindings.Add(New Binding("EditValue", Me.tbl_MstKategoriAssetRVAcc, "debit_acc_id"))
            Me.objRVKredit.DataBindings.Add(New Binding("EditValue", Me.tbl_MstKategoriAssetRVAcc, "credit_acc_id"))
        Else
            Me.objRVDebet.ItemIndex = 0
            Me.objRVKredit.ItemIndex = 0
        End If

        If Me.tbl_MstKategoriAssetDisposalAcc.Rows.Count > 0 Then
            Me.objDisposalDebet.DataBindings.Add(New Binding("EditValue", Me.tbl_MstKategoriAssetDisposalAcc, "debit_acc_id"))
            Me.objDisposalKredit.DataBindings.Add(New Binding("EditValue", Me.tbl_MstKategoriAssetDisposalAcc, "credit_acc_id"))
        Else
            Me.objDisposalDebet.ItemIndex = 0
            Me.objDisposalKredit.ItemIndex = 0
        End If

        If Me.tbl_MstKategoriAssetDepreAcc.Rows.Count > 0 Then
            Me.objDepreDebet.DataBindings.Add(New Binding("EditValue", Me.tbl_MstKategoriAssetDepreAcc, "debit_acc_id"))
            Me.objDepreKredit.DataBindings.Add(New Binding("EditValue", Me.tbl_MstKategoriAssetDepreAcc, "credit_acc_id"))
        Else
            Me.objDepreDebet.ItemIndex = 0
            Me.objDepreKredit.ItemIndex = 0
        End If
        Return True
    End Function

#End Region


#Region " Dialoged Control "
#End Region


#Region " User Defined Function "

    Private Function uiMstKategoriAsset_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_MstKategoriasset_Temp
        Me.tbl_MstKategoriasset_Temp.Clear()

        Me.BindingContext(Me.tbl_MstKategoriasset_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_MstKategoriasset_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function uiMstKategoriAsset_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser() 

        'untuk query

        If Me.chkSearchCategory.Checked = True Then
            If criteria = "" Then
                criteria &= criteria & String.Format(" kategoriasset_id LIKE '%{0}%'", Me.objSearchCategory.Text)
            Else
                criteria &= String.Format(" AND kategoriasset_id LIKE '%{0}%'", Me.objSearchCategory.Text)
            End If
        End If

        If Me.chkSearchAnnual.Checked = True Then
            If criteria = "" Then
                criteria &= criteria & String.Format(" kategoriasset_time = '{0}'", Me.objSearchAnnual.Text)
            Else
                criteria &= String.Format(" AND kategoriasset_time = '{0}'", Me.objSearchAnnual.Text)
            End If
        End If

        If Me.chkSearchTime.Checked = True Then
            If criteria = "" Then
                criteria &= criteria & String.Format(" kategoriasset_depresiasitime = '{0}'", Me.cboSearchTime.EditValue)
            Else
                criteria &= String.Format(" AND kategoriasset_depresiasitime = '{0}'", Me.cboSearchTime.EditValue)
            End If
        End If

        Try
            Me.tbl_MstKategoriasset.Clear()
            Me.DataFill(Me.tbl_MstKategoriasset, "as_MstKategoriasset_Select", criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiMstKategoriAsset_Save() As Boolean
        'save data
        Dim tbl_MstKategoriasset_Temp_Changes As DataTable

        Dim success As Boolean
        Dim kategoriasset_id As Object = New Object
        Dim modul As String
        Dim debit_acc_id As String
        Dim credit_acc_id As String
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(kategoriasset_id)

        Me.BindingContext(Me.tbl_MstKategoriasset_Temp).EndCurrentEdit()
        tbl_MstKategoriasset_Temp_Changes = Me.tbl_MstKategoriasset_Temp.GetChanges()


        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbTrans As OleDb.OleDbTransaction
        Dim cookie As Byte() = Nothing

        Try
            dbConn.Open()
            dbTrans = dbConn.BeginTransaction()
            clsApplicationRole.SetAppRole(dbConn, dbTrans, cookie)

            MasterDataState = Me.tbl_MstKategoriasset_Temp.Rows(0).RowState
            kategoriasset_id = Me.tbl_MstKategoriasset_Temp.Rows(0).Item("kategoriasset_id")

            If tbl_MstKategoriasset_Temp_Changes IsNot Nothing Then
                success = Me.uiMstKategoriAsset_SaveMaster(kategoriasset_id, tbl_MstKategoriasset_Temp_Changes, MasterDataState, dbConn, dbTrans)
                If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiMstKategoriAsset_SaveMaster(tbl_MstKategoriasset_Temp_Changes)")
                Me.tbl_MstKategoriasset_Temp.AcceptChanges()
            End If

            '=====================================================================================================================================================
            ' Hapus Semua data sesuai kategoriasset_id sebelum di simpan
            '-----------------------------------------------------------------------------------------------------------------------------------------------------
            Me.uiMstKategoriAssetAcc_Delete(kategoriasset_id, dbConn, dbTrans)
            '-----------------------------------------------------------------------------------------------------------------------------------------------------
            modul = "RV-BPB"
            debit_acc_id = Me.objRVDebet.EditValue
            credit_acc_id = Me.objRVKredit.EditValue

            success = Me.uiMstKategoriAssetAcc_SaveMaster(kategoriasset_id, modul, debit_acc_id, credit_acc_id, dbConn, dbTrans)
            If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiMstKategoriAsset_SaveMaster(tbl_MstKategoriasset_Temp_Changes)")
            Me.tbl_MstKategoriAssetRVAcc.AcceptChanges()
            '-----------------------------------------------------------------------------------------------------------------------------------------------------

            '-----------------------------------------------------------------------------------------------------------------------------------------------------
            modul = "DISPOSAL"
            debit_acc_id = Me.objDisposalDebet.EditValue
            credit_acc_id = Me.objDisposalKredit.EditValue

            success = Me.uiMstKategoriAssetAcc_SaveMaster(kategoriasset_id, modul, debit_acc_id, credit_acc_id, dbConn, dbTrans)
            If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiMstKategoriAsset_SaveMaster(tbl_MstKategoriasset_Temp_Changes)")
            Me.tbl_MstKategoriAssetDisposalAcc.AcceptChanges()
            '-----------------------------------------------------------------------------------------------------------------------------------------------------

            '-----------------------------------------------------------------------------------------------------------------------------------------------------

            modul = "DEPRESIASI"
            debit_acc_id = Me.objDepreDebet.EditValue
            credit_acc_id = Me.objDepreKredit.EditValue

            success = Me.uiMstKategoriAssetAcc_SaveMaster(kategoriasset_id, modul, debit_acc_id, credit_acc_id, dbConn, dbTrans)
            If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiMstKategoriAsset_SaveMaster(tbl_MstKategoriasset_Temp_Changes)")
            Me.tbl_MstKategoriAssetDepreAcc.AcceptChanges()
            '-----------------------------------------------------------------------------------------------------------------------------------------
            '=====================================================================================================================================================

            result = FormSaveResult.SaveSuccess
            If SHOW_SAVE_CONFIRMATION Then
                dbTrans.Commit()
                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            dbTrans.Rollback()
            result = FormSaveResult.SaveError
            MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, dbTrans, cookie)
            dbConn.Close()
        End Try

        RaiseEvent FormAfterSave(kategoriasset_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiMstKategoriAsset_SaveMaster(ByRef kategoriasset_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState, _
                                                   ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction) As Boolean
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: master_kategoriasset
        dbCmdInsert = New OleDb.OleDbCommand("as_MstKategoriasset_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_time", System.Data.OleDb.OleDbType.Integer, 4, "kategoriasset_time"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_depresiasitime", System.Data.OleDb.OleDbType.VarWChar, 100, "kategoriasset_depresiasitime"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_depresiasivalue", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "kategoriasset_depresiasivalue", System.Data.DataRowVersion.Current, Nothing))


        dbCmdUpdate = New OleDb.OleDbCommand("as_MstKategoriasset_Update", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_time", System.Data.OleDb.OleDbType.Integer, 4, "kategoriasset_time"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_depresiasitime", System.Data.OleDb.OleDbType.VarWChar, 100, "kategoriasset_depresiasitime"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_depresiasivalue", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "kategoriasset_depresiasivalue", System.Data.DataRowVersion.Current, Nothing))


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbDA.Update(objTbl)

            kategoriasset_id = objTbl.Rows(0).Item("kategoriasset_id")
            Me.tbl_MstKategoriasset_Temp.Clear()
            Me.tbl_MstKategoriasset_Temp.Merge(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

        If MasterDataState = DataRowState.Added Then
            Me.tbl_MstKategoriasset.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_MstKategoriasset).Position
            Me.tbl_MstKategoriasset.Rows.RemoveAt(curpos)
            Me.tbl_MstKategoriasset.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_MstKategoriasset).Position = Me.BindingContext(Me.tbl_MstKategoriasset).Count

        Return True
    End Function

    Private Function uiMstKategoriAssetAcc_SaveMaster(ByVal kategoriasset_id As Object, ByVal modul As Object, ByVal debit_acc_id As Object, _
                                                      ByVal credit_acc_id As Object, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction) As Boolean
        Dim dbCmdInsert As OleDb.OleDbCommand

        dbCmdInsert = New OleDb.OleDbCommand("as_MstKategoriAssetAccount_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdInsert.Parameters("@kategoriasset_id").Value = kategoriasset_id
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modul", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdInsert.Parameters("@modul").Value = modul
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@debit_acc_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdInsert.Parameters("@debit_acc_id").Value = debit_acc_id
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@credit_acc_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdInsert.Parameters("@credit_acc_id").Value = credit_acc_id

        Try
            dbCmdInsert.ExecuteNonQuery()

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function uiMstKategoriAssetAcc_Delete(ByRef kategoriasset_id As Object, ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction) As Boolean
        Dim dbCmdDelete As OleDb.OleDbCommand

        dbCmdDelete = New OleDb.OleDbCommand("as_MstKategoriAssetAccount_Delete", dbConn, dbTrans)
        dbCmdDelete.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmdDelete.Parameters("@Criteria").Value = String.Format("kategoriasset_id='{0}'", kategoriasset_id)
        dbCmdDelete.CommandType = CommandType.StoredProcedure

        Try
            dbCmdDelete.ExecuteNonQuery()

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

        Return True
    End Function

    Private Function uiMstKategoriAsset_Print() As Boolean
        'print data
    End Function

    Private Function uiMstKategoriAsset_Delete() As Boolean
        Dim res As String = ""
        Dim kategoriasset_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(kategoriasset_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.GvMstKategoriAsset.FocusedColumn IsNot Nothing Then

            'res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            'If res = DialogResult.Yes Then
            '    Me.uiMstKategoriAsset_DeleteRow(Me.GvMstKategoriAsset.FocusedRowHandle)
            'End If

        End If

        RaiseEvent FormAfterDelete(kategoriasset_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiMstKategoriAsset_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim kategoriasset_id As String
        Dim NewRowIndex As Integer
        Dim cookie As Byte() = Nothing

        kategoriasset_id = Me.GvMstKategoriAsset.GetRowCellValue(rowIndex, "kategoriasset_id")

        dbCmdDelete = New OleDb.OleDbCommand("as_MstKategoriasset_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@kategoriasset_id").Value = kategoriasset_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_time", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@kategoriasset_time").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_depresiasitime", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@kategoriasset_depresiasitime").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_depresiasivalue", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@kategoriasset_depresiasivalue").Value = DBNull.Value

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbCmdDelete.ExecuteNonQuery()

            If Me.GvMstKategoriAsset.RowCount > 1 Then
                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiMstKategoriAsset_OpenRow(NewRowIndex)
                    Me.tbl_MstKategoriasset.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.GvMstKategoriAsset.RowCount - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiMstKategoriAsset_OpenRow(NewRowIndex)
                    Me.tbl_MstKategoriasset.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_MstKategoriasset.Rows.RemoveAt(rowIndex)
                    Me.uiMstKategoriAsset_OpenRow(rowIndex)
                End If

            Else
                Me.tbl_MstKategoriasset_Temp.Clear()
                Me.tbl_MstKategoriasset.Rows.RemoveAt(rowIndex)
            End If

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Function
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try
    End Function

    Private Function uiMstKategoriAsset_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim kategoriasset_id As String
        Dim cookie As Byte() = Nothing
        kategoriasset_id = Me.GvMstKategoriAsset.GetRowCellValue(rowIndex, "kategoriasset_id")

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(kategoriasset_id)


        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            Me.BindingStop()
            Me.uiMstKategoriAsset_OpenRowMaster(kategoriasset_id, dbConn)
            Me.uiMstKategoriAsset_OpenRowRVAcc(kategoriasset_id, dbConn)
            Me.uiMstKategoriAsset_OpenRowDisposalAcc(kategoriasset_id, dbConn)
            Me.uiMstKategoriAsset_OpenRowDepreAcc(kategoriasset_id, dbConn)
            Me.BindingStart()
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiMstKategoriAsset_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(kategoriasset_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiMstKategoriAsset_OpenRowMaster(ByVal kategoriasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_MstKategoriasset_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("kategoriasset_id='{0}'", kategoriasset_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstKategoriasset_Temp.Clear()

        Try
            dbDA.Fill(Me.tbl_MstKategoriasset_Temp)
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiMstKategoriAsset_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function uiMstKategoriAsset_OpenRowRVAcc(ByVal kategoriasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_MstKategoriAssetAccount_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("kategoriasset_id = '{0}' AND modul = '{1}'", kategoriasset_id, "RV-BPB")
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstKategoriAssetRVAcc.Clear()

        Try
            dbDA.Fill(Me.tbl_MstKategoriAssetRVAcc)
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiMstKategoriAsset_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function uiMstKategoriAsset_OpenRowDisposalAcc(ByVal kategoriasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_MstKategoriAssetAccount_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("kategoriasset_id = '{0}' AND modul = '{1}'", kategoriasset_id, "DISPOSAL")
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstKategoriAssetDisposalAcc.Clear()

        Try
            dbDA.Fill(Me.tbl_MstKategoriAssetDisposalAcc)
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiMstKategoriAsset_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function uiMstKategoriAsset_OpenRowDepreAcc(ByVal kategoriasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_MstKategoriAssetAccount_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("kategoriasset_id = '{0}' AND modul = '{1}'", kategoriasset_id, "DEPRESIASI")
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstKategoriAssetDepreAcc.Clear()

        Try
            dbDA.Fill(Me.tbl_MstKategoriAssetDepreAcc)
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiMstKategoriAsset_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function uiMstKategoriAsset_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedTabPageIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstKategoriAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            ' Me.DgvMstKategoriasset.CurrentCell = Me.DgvMstKategoriasset(1, 0)
            Me.uiMstKategoriAsset_RefreshPosition()
        End If
    End Function

    Private Function uiMstKategoriAsset_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedTabPageIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstKategoriAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            'If Me.DgvMstKategoriasset.CurrentCell.RowIndex > 0 Then
            '    Me.DgvMstKategoriasset.CurrentCell = Me.DgvMstKategoriasset(1, DgvMstKategoriasset.CurrentCell.RowIndex - 1)
            '    Me.uiMstKategoriAsset_RefreshPosition()
            'End If
        End If
    End Function

    Private Function uiMstKategoriAsset_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedTabPageIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstKategoriAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            'If Me.DgvMstKategoriasset.CurrentCell.RowIndex < Me.DgvMstKategoriasset.Rows.Count - 1 Then
            '    Me.DgvMstKategoriasset.CurrentCell = Me.DgvMstKategoriasset(1, DgvMstKategoriasset.CurrentCell.RowIndex + 1)
            '    Me.uiMstKategoriAsset_RefreshPosition()
            'End If
        End If
    End Function

    Private Function uiMstKategoriAsset_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedTabPageIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstKategoriAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        'If move Then
        '    Me.DgvMstKategoriasset.CurrentCell = Me.DgvMstKategoriasset(1, Me.DgvMstKategoriasset.Rows.Count - 1)
        '    Me.uiMstKategoriAsset_RefreshPosition()
        'End If
    End Function

    Private Function uiMstKategoriAsset_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedTabPageIndex
        ' If iTab = 1 Then uiMstKategoriAsset_OpenRow(Me.DgvMstKategoriasset.CurrentRow.Index)
    End Function

    Private Function uiMstKategoriAsset_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_MstKategoriasset_Temp_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim kategoriasset_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        'If Me.DgvMstKategoriasset.CurrentCell IsNot Nothing Then

        '    Me.BindingContext(Me.tbl_MstKategoriasset_Temp).EndCurrentEdit()
        '    tbl_MstKategoriasset_Temp_Changes = Me.tbl_MstKategoriasset_Temp.GetChanges()

        '    If tbl_MstKategoriasset_Temp_Changes IsNot Nothing Then

        '        res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        '        Select Case res
        '            Case DialogResult.Yes

        '                RaiseEvent FormBeforeSave(kategoriasset_id)

        '                Try

        '                    If tbl_MstKategoriasset_Temp_Changes IsNot Nothing Then
        '                        success = Me.uiMstKategoriAsset_SaveMaster(kategoriasset_id, tbl_MstKategoriasset_Temp_Changes, MasterDataState)
        '                        If Not success Then Throw New Exception("Cannot Save Master Data")
        '                        Me.tbl_MstKategoriasset_Temp.AcceptChanges()
        '                    End If

        '                    result = FormSaveResult.SaveSuccess
        '                    If SHOW_SAVE_CONFIRMATION Then
        '                        MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    End If

        '                Catch ex As Exception
        '                    result = FormSaveResult.SaveError
        '                    MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                End Try

        '                RaiseEvent FormAfterSave(kategoriasset_id, result)

        '            Case DialogResult.No
        '                move = True
        '            Case DialogResult.Cancel
        '                move = False
        '        End Select
        '    Else
        '        move = True
        '    End If

        'End If

        Return move

    End Function

    Private Function uiMstKategoriAsset_FormError() As Boolean
        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
        End If

        'Me.InitLayoutUI()

        Me.GCMstKategoriAsset.DataSource = Me.tbl_MstKategoriasset
        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....
            Me.ComboFillDX(Me.cboSearchTime, "Pilihan", "Pilihan", Me.tbl_MstKategoriassetpilihan, "as_pilihanMstKategoriasset_Select", " kategori = 'Mstkategoriasset' and is_disable = 0")
            Me.ComboFillDX(Me.obj_Kategoriasset_depresiasitime, "Pilihan", "Pilihan", Me.tbl_MstKategoriassetpilihan, "as_pilihanMstKategoriasset_Select", " kategori = 'Mstkategoriasset' and is_disable = 0")
            Me.ComboFillDX(Me.DSNFrm, Me.objRVDebet, "acc_id", "acc_name", Me.tbl_MstAcc, "cp_MstAcc_Select", " acc_isdisabled = 0")
            Me.ComboFillDX(Me.DSNFrm, Me.objRVKredit, "acc_id", "acc_name", Me.tbl_MstAcc, "cp_MstAcc_Select", " acc_isdisabled = 0")
            Me.ComboFillDX(Me.DSNFrm, Me.objDisposalDebet, "acc_id", "acc_name", Me.tbl_MstAcc, "cp_MstAcc_Select", " acc_isdisabled = 0")
            Me.ComboFillDX(Me.DSNFrm, Me.objDisposalKredit, "acc_id", "acc_name", Me.tbl_MstAcc, "cp_MstAcc_Select", " acc_isdisabled = 0")
            Me.ComboFillDX(Me.DSNFrm, Me.objDepreDebet, "acc_id", "acc_name", Me.tbl_MstAcc, "cp_MstAcc_Select", " acc_isdisabled = 0")
            Me.ComboFillDX(Me.DSNFrm, Me.objDepreKredit, "acc_id", "acc_name", Me.tbl_MstAcc, "cp_MstAcc_Select", " acc_isdisabled = 0")

            'Me.obj_Kategoriasset_depresiasitime.de.Sort = "pilihan"

        End If

        'Me.BindingStop()
        'Me.BindingStart()

        Me.uiMstKategoriAsset_NewData()

        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = False
        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True
    End Sub

    Private Sub uiMstKategoriAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If
    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedPageChanged
        Select Case ftabMain.SelectedTabPageIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Linen
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White
            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Linen
                'MsgBox(Me.DgvMstKategoriasset.Item(0, Me.DgvMstKategoriasset.CurrentRow.Index).Value)
                If Me.GvMstKategoriAsset.FocusedColumn IsNot Nothing Then
                    Me.uiMstKategoriAsset_OpenRow(Me.GvMstKategoriAsset.FocusedRowHandle)
                Else
                    Me.uiMstKategoriAsset_NewData()
                End If
        End Select
    End Sub

    Private Sub DgvMstKategoriasset_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        'If Me.DgvMstKategoriasset.CurrentRow IsNot Nothing Then
        '    Me.ftabMain.SelectedTabPageIndex = 1
        'End If
    End Sub

    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)

        If info.InRow OrElse info.InRowCell Then
            If view.FocusedColumn Is Nothing Or view.FocusedRowHandle < 0 Then
                Exit Sub
            End If

            If Me.GvMstKategoriAsset.FocusedColumn IsNot Nothing Then
                Me.ftabMain.SelectedTabPageIndex = 1
            End If
        End If
    End Sub

    Private Sub GvMstKategoriAsset_DoubleClick(sender As Object, e As EventArgs) Handles GvMstKategoriAsset.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)

        DoRowDoubleClick(view, pt)
    End Sub

    Private Sub chkSearchCategory_CheckedChanged(sender As Object, e As EventArgs) Handles chkSearchCategory.CheckedChanged
        Me.objSearchCategory.Enabled = Not Me.objSearchCategory.Enabled
        Me.objSearchCategory.Focus()
    End Sub

    Private Sub chkSearchAnnual_CheckedChanged(sender As Object, e As EventArgs) Handles chkSearchAnnual.CheckedChanged
        Me.objSearchAnnual.Enabled = Not Me.objSearchAnnual.Enabled
        Me.objSearchAnnual.Focus()
    End Sub

    Private Sub chkSearchTime_CheckedChanged(sender As Object, e As EventArgs) Handles chkSearchTime.CheckedChanged
        Me.cboSearchTime.Enabled = Not Me.cboSearchTime.Enabled
        Me.cboSearchTime.Focus()
    End Sub

    Private Sub objDepreKredit_EditValueChanged(sender As Object, e As EventArgs) Handles objDepreKredit.EditValueChanged

    End Sub
End Class