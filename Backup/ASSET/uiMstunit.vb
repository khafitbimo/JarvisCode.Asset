'================================================== 
' Generated by DWRAD version 1.0.0.0
' BERAK DI CELANA
' TransTV

' Created Date: 3/26/2008 9:05:13 AM
' 


Public Class uiMstunit
    Private Const mUiName As String = "Unit Item"
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

    Private tbl_MstUnit As DataTable = CreateTblMstUnit()
    Private tbl_MstUnit_Temp As DataTable = CreateTblMstUnit()
    Private tbl_MstUnittype As DataTable = clsDataset.CreateTblMstUnittype()

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 

#End Region


#Region " Window Dataset "
    Public Shared Function CreateTblMstUnit() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("unit_id", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("unit_shortname", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unit_name", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unit_type", GetType(System.String)))
        tbl.Columns.Add(New DataColumn("unit_base", GetType(System.Decimal)))
        tbl.Columns.Add(New DataColumn("unit_active", GetType(System.Boolean)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("unit_id").DefaultValue = 0
        tbl.Columns("unit_shortname").DefaultValue = ""
        tbl.Columns("unit_name").DefaultValue = ""
        tbl.Columns("unit_type").DefaultValue = DBNull.Value
        tbl.Columns("unit_base").DefaultValue = 0
        tbl.Columns("unit_active").DefaultValue = 1


        Return tbl
    End Function

#End Region


#Region " Overrides "

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible
        If Me.PnlDfSearch.Visible Then
            FILTER_QUERY_MODE = True
            Me.tbtnQuery.CheckState = CheckState.Checked
        Else
            FILTER_QUERY_MODE = False
            Me.tbtnQuery.CheckState = CheckState.Unchecked
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnNew_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If Me.ftabMain.SelectedIndex = 0 Then
            Me.ftabMain.SelectedIndex = 1
        End If
        Me.uiMstunit_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstunit_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiMstunit_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstunit_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function


    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstunit_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstunit_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstunit_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstunit_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstunit_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstunit_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region


#Region " Layout & Init UI "

    Private Function FormatDgvMstUnit(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvMstUnit Columns 
        Dim cUnit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_shortname As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_base As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUnit_active As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        cUnit_id.Name = "unit_id"
        cUnit_id.HeaderText = "unit_id"
        cUnit_id.DataPropertyName = "unit_id"
        cUnit_id.Width = 100
        cUnit_id.Visible = True
        cUnit_id.ReadOnly = False

        cUnit_shortname.Name = "unit_shortname"
        cUnit_shortname.HeaderText = "unit_shortname"
        cUnit_shortname.DataPropertyName = "unit_shortname"
        cUnit_shortname.Width = 100
        cUnit_shortname.Visible = True
        cUnit_shortname.ReadOnly = False

        cUnit_name.Name = "unit_name"
        cUnit_name.HeaderText = "unit_name"
        cUnit_name.DataPropertyName = "unit_name"
        cUnit_name.Width = 100
        cUnit_name.Visible = True
        cUnit_name.ReadOnly = False

        cUnit_type.Name = "unit_type"
        cUnit_type.HeaderText = "unit_type"
        cUnit_type.DataPropertyName = "unit_type"
        cUnit_type.Width = 100
        cUnit_type.Visible = True
        cUnit_type.ReadOnly = False

        cUnit_base.Name = "unit_base"
        cUnit_base.HeaderText = "unit_base"
        cUnit_base.DataPropertyName = "unit_base"
        cUnit_base.Width = 100
        cUnit_base.Visible = True
        cUnit_base.ReadOnly = False

        cUnit_active.Name = "unit_active"
        cUnit_active.HeaderText = "unit_active"
        cUnit_active.DataPropertyName = "unit_active"
        cUnit_active.Width = 100
        cUnit_active.Visible = True
        cUnit_active.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cUnit_id, cUnit_shortname, cUnit_name, cUnit_type, cUnit_base, cUnit_active})



        ' DgvMstUnit Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function

    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvMstUnit.Dock = DockStyle.Fill

        Me.FormatDgvMstUnit(Me.DgvMstUnit)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Unit_id.DataBindings.clear()
        Me.obj_Unit_shortname.DataBindings.clear()
        Me.obj_Unit_name.DataBindings.clear()
        Me.obj_Unit_type.DataBindings.clear()
        Me.obj_Unit_base.DataBindings.clear()
        Me.obj_Unit_active.DataBindings.clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Unit_id.DataBindings.Add(New Binding("Text", Me.tbl_MstUnit_Temp, "unit_id", True, DataSourceUpdateMode.OnPropertyChanged, 0))
        Me.obj_Unit_shortname.DataBindings.Add(New Binding("Text", Me.tbl_MstUnit_Temp, "unit_shortname"))
        Me.obj_Unit_name.DataBindings.Add(New Binding("Text", Me.tbl_MstUnit_Temp, "unit_name"))
        Me.obj_Unit_type.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstUnit_Temp, "unit_type"))
        Me.obj_Unit_base.DataBindings.Add(New Binding("Text", Me.tbl_MstUnit_Temp, "unit_base", True, DataSourceUpdateMode.OnPropertyChanged, 0))
        Me.obj_Unit_active.DataBindings.Add(New Binding("Checked", Me.tbl_MstUnit_Temp, "unit_active"))
        Return True
    End Function

#End Region


#Region " Dialoged Control "
#End Region


#Region " User Defined Function "

    Private Function uiMstunit_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_MstUnit_Temp
        Me.tbl_MstUnit_Temp.Clear()

        'Me.obj_Unit_id.Text = "Auto"
        'Me.obj_Unit_active.Checked = True





        Me.BindingContext(Me.tbl_MstUnit_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_MstUnit_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function uiMstunit_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()


        Me.tbl_MstUnit.Clear()
        Try
            Me.DataFill(Me.tbl_MstUnit, "AS_MstUnit_Select", criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiMstunit_Save() As Boolean
        'save data
        Dim tbl_MstUnit_Temp_Changes As DataTable
        Dim success As Boolean
        Dim unit_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(unit_id)

        Me.BindingContext(Me.tbl_MstUnit_Temp).EndCurrentEdit()
        tbl_MstUnit_Temp_Changes = Me.tbl_MstUnit_Temp.GetChanges()

        If tbl_MstUnit_Temp_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_MstUnit_Temp.Rows(0).RowState
                'MsgBox(CStr(MasterDataState))
                unit_id = tbl_MstUnit_Temp.Rows(0).Item("unit_id")

                If tbl_MstUnit_Temp_Changes IsNot Nothing Then
                    success = Me.uiMstunit_SaveMaster(unit_id, tbl_MstUnit_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiMstunit_SaveMaster(tbl_MstUnit_Temp_Changes)")
                    Me.tbl_MstUnit_Temp.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbcrlf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        RaiseEvent FormAfterSave(unit_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiMstunit_SaveMaster(ByRef unit_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: master_unit
        dbCmdInsert = New OleDb.OleDbCommand("AS_MstUnit_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure


        'dbCmdInsert.Parameters.Add("@unit_id", SqlDbType.Decimal, 5).Direction = ParameterDirection.Output
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "unit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_shortname", System.Data.OleDb.OleDbType.VarWChar, 20, "unit_shortname"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_name", System.Data.OleDb.OleDbType.VarWChar, 100, "unit_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_type", System.Data.OleDb.OleDbType.VarWChar, 100, "unit_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_base", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "unit_base", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_active", System.Data.OleDb.OleDbType.Boolean, 1, "unit_active"))
        'unit_id = dbCmdInsert.Parameters("@unit_id").Value

        dbCmdUpdate = New OleDb.OleDbCommand("AS_MstUnit_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "unit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_shortname", System.Data.OleDb.OleDbType.VarWChar, 20, "unit_shortname"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_name", System.Data.OleDb.OleDbType.VarWChar, 100, "unit_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_type", System.Data.OleDb.OleDbType.VarWChar, 100, "unit_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_base", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(1, Byte), CType(0, Byte), "unit_base", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_active", System.Data.OleDb.OleDbType.Boolean, 1, "unit_active"))


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            unit_id = objTbl.Rows(0).Item("unit_id")
            Me.tbl_MstUnit_Temp.Clear()
            Me.tbl_MstUnit_Temp.Merge(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try


        If MasterDataState = DataRowState.Added Then
            Me.tbl_MstUnit.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curPos = Me.BindingContext(Me.tbl_MstUnit).Position
            Me.tbl_MstUnit.Rows.RemoveAt(curPos)
            Me.tbl_MstUnit.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_MstUnit).Position = Me.BindingContext(Me.tbl_MstUnit).Count

        Return True
    End Function

    Private Function uiMstunit_Print() As Boolean
        'print data
    End Function

    Private Function uiMstunit_Delete() As Boolean
        Dim res As String = ""
        Dim unit_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(unit_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvMstUnit.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiMstunit_DeleteRow(Me.DgvMstUnit.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(unit_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiMstunit_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim unit_id As String
        Dim NewRowIndex As Integer

        unit_id = Me.DgvMstUnit.Rows(rowIndex).Cells("unit_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("AS_MstUnit_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@unit_id").Value = unit_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_shortname", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@unit_shortname").Value = DBNULL.value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_name", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@unit_name").Value = DBNULL.value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_type", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@unit_type").Value = DBNULL.value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_base", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@unit_base").Value = DBNULL.value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_active", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@unit_active").Value = DBNULL.value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvMstUnit.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiMstunit_OpenRow(NewRowIndex)
                    Me.tbl_MstUnit.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvMstUnit.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiMstunit_OpenRow(NewRowIndex)
                    Me.tbl_MstUnit.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_MstUnit.Rows.RemoveAt(rowIndex)
                    Me.uiMstunit_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_MstUnit_Temp.Clear()
                Me.tbl_MstUnit.Rows.RemoveAt(rowIndex)

            End If

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Function
        Finally
            dbConn.Close()
        End Try
    End Function

    Private Function uiMstunit_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim unit_id As String

        unit_id = Me.DgvMstUnit.Rows(rowIndex).Cells("unit_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(unit_id)


        Try
            dbConn.Open()
            Me.uiMstunit_OpenRowMaster(unit_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiMstunit_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(unit_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiMstunit_OpenRowMaster(ByVal unit_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("AS_MstUnit_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("unit_id='{0}'", unit_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstUnit_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_MstUnit_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiMstunit_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiMstunit_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstunit_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstUnit.CurrentCell = Me.DgvMstUnit(1, 0)
            Me.uiMstunit_RefreshPosition()
        End If
    End Function

    Private Function uiMstunit_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstunit_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstUnit.CurrentCell.RowIndex > 0 Then
                Me.DgvMstUnit.CurrentCell = Me.DgvMstUnit(1, DgvMstUnit.CurrentCell.RowIndex - 1)
                Me.uiMstunit_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiMstunit_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstunit_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstUnit.CurrentCell.RowIndex < Me.DgvMstUnit.Rows.Count - 1 Then
                Me.DgvMstUnit.CurrentCell = Me.DgvMstUnit(1, DgvMstUnit.CurrentCell.RowIndex + 1)
                Me.uiMstunit_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiMstunit_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstunit_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstUnit.CurrentCell = Me.DgvMstUnit(1, Me.DgvMstUnit.Rows.Count - 1)
            Me.uiMstunit_RefreshPosition()
        End If
    End Function

    Private Function uiMstunit_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiMstunit_OpenRow(Me.DgvMstUnit.CurrentRow.Index)
    End Function

    Private Function uiMstunit_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_MstUnit_Temp_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim unit_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvMstUnit.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_MstUnit_Temp).EndCurrentEdit()
            tbl_MstUnit_Temp_Changes = Me.tbl_MstUnit_Temp.GetChanges()

            If tbl_MstUnit_Temp_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(unit_id)

                        Try

                            If tbl_MstUnit_Temp_Changes IsNot Nothing Then
                                success = Me.uiMstunit_SaveMaster(unit_id, tbl_MstUnit_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_MstUnit_Temp.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(unit_id, result)

                    Case DialogResult.No
                        move = True
                    Case DialogResult.Cancel
                        move = False
                End Select
            Else
                move = True
            End If

        End If

        Return move

    End Function

    Private Function uiMstunit_FormError() As Boolean
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



    Private Sub uiMstunit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objParameters As Collection = New Collection


        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
        End If

        Me.InitLayoutUI()

        Me.DgvMstUnit.DataSource = Me.tbl_MstUnit
        If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....

            Me.ComboFillStringNull(Me.obj_Unit_type, "name", "name", Me.tbl_MstUnittype, "as_MstUnittype_Select", "  ")
            Me.tbl_MstUnittype.DefaultView.Sort = "name"



        End If

        Me.BindingStop()
        Me.BindingStart()

        Me.uiMstunit_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True


    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Linen
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Linen

                If Me.DgvMstUnit.CurrentRow IsNot Nothing Then
                    Me.uiMstunit_OpenRow(Me.DgvMstUnit.CurrentRow.Index)
                Else
                    Me.uiMstunit_NewData()
                End If


        End Select
    End Sub

    Private Sub DgvMstUnit_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMstUnit.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvMstUnit.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub





End Class