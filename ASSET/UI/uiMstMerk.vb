Public Class uiMstMerk
    Private Const mUiName As String = "Brand"
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

    Private tbl_MstMerk As DataTable = clsDataset.CreateTblMstMerk()
    Private tbl_MstMerk_Temp As DataTable = clsDataset.CreateTblMstMerk()

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 

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
        Me.uiMstMerk_NewData()
        Me.Cursor = Cursors.Arrow


        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstMerk_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiMstMerk_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstMerk_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function


    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstMerk_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstMerk_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstMerk_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstMerk_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstMerk_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstMerk_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region


#Region " Layout & Init UI "

    Private Function FormatDgvMstMerk(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvMstMerk Columns 
        Dim cMerk_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMerk_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cMerk_active As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        cMerk_id.Name = "merk_id"
        cMerk_id.HeaderText = "merk_id"
        cMerk_id.DataPropertyName = "merk_id"
        cMerk_id.Width = 100
        cMerk_id.Visible = True
        cMerk_id.ReadOnly = False

        cMerk_name.Name = "merk_name"
        cMerk_name.HeaderText = "merk_name"
        cMerk_name.DataPropertyName = "merk_name"
        cMerk_name.Width = 300
        cMerk_name.Visible = True
        cMerk_name.ReadOnly = False

        cMerk_active.Name = "merk_active"
        cMerk_active.HeaderText = "merk_active"
        cMerk_active.DataPropertyName = "merk_active"
        cMerk_active.Width = 100
        cMerk_active.Visible = True
        cMerk_active.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cMerk_id, cMerk_name, cMerk_active})



        ' DgvMstMerk Behaviours: 
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

        Me.ftabMain.TabPages.Item(1).BackColor = Color.DarkSeaGreen
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvMstMerk.Dock = DockStyle.Fill

        Me.FormatDgvMstMerk(Me.DgvMstMerk)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Merk_id.DataBindings.Clear()
        Me.obj_Merk_name.DataBindings.Clear()
        Me.obj_Merk_active.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Merk_id.DataBindings.Add(New Binding("Text", Me.tbl_MstMerk_Temp, "merk_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0"))
        Me.obj_Merk_name.DataBindings.Add(New Binding("Text", Me.tbl_MstMerk_Temp, "merk_name"))
        Me.obj_Merk_active.DataBindings.Add(New Binding("Checked", Me.tbl_MstMerk_Temp, "merk_active"))
        Return True
    End Function

#End Region


#Region " Dialoged Control "
#End Region


#Region " User Defined Function "

    Private Function uiMstMerk_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_MstMerk_Temp
        Me.tbl_MstMerk_Temp.Clear()

        Me.BindingContext(Me.tbl_MstMerk_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_MstMerk_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function uiMstMerk_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()
        If Me.CheckBox1.Checked = True Then
            criteria = " merk_name like '" & Me.objsearch.Text & "'"
            If Me.CheckBox2.Checked = True Then
                criteria = criteria & " and merk_active  = 1"
            End If
            If Me.CheckBox2.Checked = False Then
                criteria = criteria & " and merk_active  = 0"
            End If
        End If


        If Me.CheckBox1.Checked = False And Me.CheckBox2.Checked = True Then
            If Me.CheckBox2.Checked = False Then
                criteria = "  merk_active  = 1"
            End If
        End If





        Me.tbl_MstMerk.Clear()
        Try
            Me.DataFill(Me.tbl_MstMerk, "as_MstMerk_Select", criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiMstMerk_Save() As Boolean
        'save data
        Dim tbl_MstMerk_Temp_Changes As DataTable
        Dim success As Boolean
        Dim merk_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(merk_id)

        Me.BindingContext(Me.tbl_MstMerk_Temp).EndCurrentEdit()
        tbl_MstMerk_Temp_Changes = Me.tbl_MstMerk_Temp.GetChanges()

        If tbl_MstMerk_Temp_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_MstMerk_Temp.Rows(0).RowState
                merk_id = tbl_MstMerk_Temp.Rows(0).Item("merk_id")

                If tbl_MstMerk_Temp_Changes IsNot Nothing Then
                    success = Me.uiMstMerk_SaveMaster(merk_id, tbl_MstMerk_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiMstMerk_SaveMaster(tbl_MstMerk_Temp_Changes)")
                    Me.tbl_MstMerk_Temp.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        RaiseEvent FormAfterSave(merk_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiMstMerk_SaveMaster(ByRef merk_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: master_merk
        dbCmdInsert = New OleDb.OleDbCommand("as_MstMerk_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        'dbCmdInsert.Parameters.Add("@Code", SqlDbType.Decimal, 5).Direction = ParameterDirection.Output
        'Code = dbCmdInsert.Parameters("@Code").Value
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@merk_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "merk_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@merk_name", System.Data.OleDb.OleDbType.VarWChar, 100, "merk_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@merk_active", System.Data.OleDb.OleDbType.Boolean, 1, "merk_active"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@edit_by", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters("@edit_by").Value = Me.UserName


        dbCmdUpdate = New OleDb.OleDbCommand("as_MstMerk_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@merk_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(4, Byte), CType(0, Byte), "merk_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@merk_name", System.Data.OleDb.OleDbType.VarWChar, 100, "merk_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@merk_active", System.Data.OleDb.OleDbType.Boolean, 1, "merk_active"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@edit_by", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdUpdate.Parameters("@edit_by").Value = Me.UserName

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            merk_id = objTbl.Rows(0).Item("merk_id")
            Me.tbl_MstMerk_Temp.Clear()
            Me.tbl_MstMerk_Temp.Merge(objTbl)

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
            Me.tbl_MstMerk.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_MstMerk).Position
            Me.tbl_MstMerk.Rows.RemoveAt(curpos)
            Me.tbl_MstMerk.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_MstMerk).Position = Me.BindingContext(Me.tbl_MstMerk).Count

        Return True
    End Function

    Private Function uiMstMerk_Print() As Boolean
        'print data
    End Function

    Private Function uiMstMerk_Delete() As Boolean
        'Dim res As String = ""
        'Dim merk_id As Object = New Object

        'Me.Cursor = Cursors.WaitCursor
        'RaiseEvent FormBeforeDelete(merk_id)

        'Me.Cursor = Cursors.WaitCursor
        'If Me.DgvMstMerk.CurrentRow IsNot Nothing Then

        '    res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    If res = DialogResult.Yes Then
        '        Me.uiMstMerk_DeleteRow(Me.DgvMstMerk.CurrentRow.Index)
        '    End If

        'End If

        'RaiseEvent FormAfterDelete(merk_id)
        'Me.Cursor = Cursors.Arrow
        MsgBox("Data Cannot Be Deleted", MsgBoxStyle.Information)

    End Function

    Private Function uiMstMerk_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim merk_id As String
        Dim NewRowIndex As Integer

        merk_id = Me.DgvMstMerk.Rows(rowIndex).Cells("merk_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_MstMerk_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@merk_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@merk_id").Value = merk_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@merk_name", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@merk_name").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@merk_active", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@merk_active").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvMstMerk.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiMstMerk_OpenRow(NewRowIndex)
                    Me.tbl_MstMerk.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvMstMerk.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiMstMerk_OpenRow(NewRowIndex)
                    Me.tbl_MstMerk.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_MstMerk.Rows.RemoveAt(rowIndex)
                    Me.uiMstMerk_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_MstMerk_Temp.Clear()
                Me.tbl_MstMerk.Rows.RemoveAt(rowIndex)

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

    Private Function uiMstMerk_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim merk_id As String

        merk_id = Me.DgvMstMerk.Rows(rowIndex).Cells("merk_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(merk_id)


        Try
            dbConn.Open()
            Me.uiMstMerk_OpenRowMaster(merk_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiMstMerk_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(merk_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiMstMerk_OpenRowMaster(ByVal merk_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_MstMerk_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("merk_id='{0}'", merk_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstMerk_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_MstMerk_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiMstMerk_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiMstMerk_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstMerk_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstMerk.CurrentCell = Me.DgvMstMerk(1, 0)
            Me.uiMstMerk_RefreshPosition()
        End If
    End Function

    Private Function uiMstMerk_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstMerk_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstMerk.CurrentCell.RowIndex > 0 Then
                Me.DgvMstMerk.CurrentCell = Me.DgvMstMerk(1, DgvMstMerk.CurrentCell.RowIndex - 1)
                Me.uiMstMerk_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiMstMerk_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstMerk_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstMerk.CurrentCell.RowIndex < Me.DgvMstMerk.Rows.Count - 1 Then
                Me.DgvMstMerk.CurrentCell = Me.DgvMstMerk(1, DgvMstMerk.CurrentCell.RowIndex + 1)
                Me.uiMstMerk_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiMstMerk_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstMerk_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstMerk.CurrentCell = Me.DgvMstMerk(1, Me.DgvMstMerk.Rows.Count - 1)
            Me.uiMstMerk_RefreshPosition()
        End If
    End Function

    Private Function uiMstMerk_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiMstMerk_OpenRow(Me.DgvMstMerk.CurrentRow.Index)
    End Function

    Private Function uiMstMerk_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_MstMerk_Temp_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim merk_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvMstMerk.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_MstMerk_Temp).EndCurrentEdit()
            tbl_MstMerk_Temp_Changes = Me.tbl_MstMerk_Temp.GetChanges()

            If tbl_MstMerk_Temp_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(merk_id)

                        Try

                            If tbl_MstMerk_Temp_Changes IsNot Nothing Then
                                success = Me.uiMstMerk_SaveMaster(merk_id, tbl_MstMerk_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_MstMerk_Temp.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(merk_id, result)

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

    Private Function uiMstMerk_FormError() As Boolean
        Try
            Dim ErrorMessage As String = ""

            If Trim(Me.obj_Merk_name.Text) = "" Then
                ErrorMessage = "Brand Text Must Be Filled"
                Me.objFormError.SetError(Me.obj_Merk_name, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Merk_name, "")
            End If
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

        Me.InitLayoutUI()

        Me.DgvMstMerk.DataSource = Me.tbl_MstMerk
        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....



        End If

        Me.BindingStop()
        Me.BindingStart()

        Me.uiMstMerk_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

    End Sub


    Private Sub uiMstMerk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If


    End Sub

    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(1).BackColor = Color.DarkSeaGreen
                Me.ftabMain.TabPages.Item(0).BackColor = Color.MintCream

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(1).BackColor = Color.MintCream
                Me.ftabMain.TabPages.Item(0).BackColor = Color.DarkSeaGreen

                If Me.DgvMstMerk.CurrentRow IsNot Nothing Then
                    Me.uiMstMerk_OpenRow(Me.DgvMstMerk.CurrentRow.Index)
                Else
                    Me.uiMstMerk_NewData()
                End If


        End Select
    End Sub

    Private Sub DgvMstMerk_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMstMerk.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvMstMerk.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub





End Class
