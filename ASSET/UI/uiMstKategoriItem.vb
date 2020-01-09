Public Class uiMstKategoriItem
    Private Const mUiName As String = "Item Category"
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

    Private tbl_MstKategoriitem As DataTable = CreateTblMstKategoriitem()
    Private tbl_MstKategoriitem_Temp As DataTable = CreateTblMstKategoriitem()

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 

#End Region


#Region " Window Dataset "
    Public Shared Function CreateTblMstKategoriitem() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Clear()
        tbl.Columns.Add(New DataColumn("kategoriitem_id", GetType(System.String)))


        '-------------------------------
        'Default Value: 
        tbl.Columns("kategoriitem_id").DefaultValue = ""


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
        Me.uiMstKategoriItem_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriItem_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiMstKategoriItem_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriItem_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function


    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriItem_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriItem_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriItem_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriItem_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriItem_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiMstKategoriItem_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region


#Region " Layout & Init UI "

    Private Function FormatDgvMstKategoriitem(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvMstKategoriitem Columns 
        Dim cKategoriitem_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cKategoriitem_id.Name = "kategoriitem_id"
        cKategoriitem_id.HeaderText = "kategoriitem_id"
        cKategoriitem_id.DataPropertyName = "kategoriitem_id"
        cKategoriitem_id.Width = 300
        cKategoriitem_id.Visible = True
        cKategoriitem_id.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cKategoriitem_id})



        ' DgvMstKategoriitem Behaviours: 
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
        Me.DgvMstKategoriitem.Dock = DockStyle.Fill

        Me.FormatDgvMstKategoriitem(Me.DgvMstKategoriitem)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Kategoriitem_id.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Kategoriitem_id.DataBindings.Add(New Binding("Text", Me.tbl_MstKategoriitem_Temp, "kategoriitem_id"))
        Return True
    End Function

#End Region


#Region " Dialoged Control "
#End Region


#Region " User Defined Function "

    Private Function uiMstKategoriItem_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_MstKategoriitem_Temp
        Me.tbl_MstKategoriitem_Temp.Clear()




        Me.BindingContext(Me.tbl_MstKategoriitem_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_MstKategoriitem_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function uiMstKategoriItem_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()


        Me.tbl_MstKategoriitem.Clear()
        Try
            Me.DataFill(Me.tbl_MstKategoriitem, "as_MstKategoriitem_Select", criteria)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiMstKategoriItem_Save() As Boolean
        'save data
        Dim tbl_MstKategoriitem_Temp_Changes As DataTable
        Dim success As Boolean
        Dim kategoriitem_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(kategoriitem_id)

        Me.BindingContext(Me.tbl_MstKategoriitem_Temp).EndCurrentEdit()
        tbl_MstKategoriitem_Temp_Changes = Me.tbl_MstKategoriitem_Temp.GetChanges()

        If tbl_MstKategoriitem_Temp_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_MstKategoriitem_Temp.Rows(0).RowState
                kategoriitem_id = tbl_MstKategoriitem_Temp.Rows(0).Item("kategoriitem_id")

                If tbl_MstKategoriitem_Temp_Changes IsNot Nothing Then
                    success = Me.uiMstKategoriItem_SaveMaster(kategoriitem_id, tbl_MstKategoriitem_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiMstKategoriItem_SaveMaster(tbl_MstKategoriitem_Temp_Changes)")
                    Me.tbl_MstKategoriitem_Temp.AcceptChanges()
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

        RaiseEvent FormAfterSave(kategoriitem_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiMstKategoriItem_SaveMaster(ByRef kategoriitem_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: master_kategoriitem
        dbCmdInsert = New OleDb.OleDbCommand("as_MstKategoriitem_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriitem_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@edit_by", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdInsert.Parameters("@edit_by").Value = Me.UserName


        dbCmdUpdate = New OleDb.OleDbCommand("as_MstKategoriitem_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriitem_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@edit_by", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdUpdate.Parameters("@edit_by").Value = Me.UserName

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            kategoriitem_id = objTbl.Rows(0).Item("kategoriitem_id")
            Me.tbl_MstKategoriitem_Temp.Clear()
            Me.tbl_MstKategoriitem_Temp.Merge(objTbl)

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
            Me.tbl_MstKategoriitem.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_MstKategoriitem).Position
            Me.tbl_MstKategoriitem.Rows.RemoveAt(curpos)
            Me.tbl_MstKategoriitem.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_MstKategoriitem).Position = Me.BindingContext(Me.tbl_MstKategoriitem).Count

        Return True
    End Function

    Private Function uiMstKategoriItem_Print() As Boolean
        'print data
    End Function

    Private Function uiMstKategoriItem_Delete() As Boolean
        Dim res As String = ""
        Dim kategoriitem_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(kategoriitem_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvMstKategoriitem.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiMstKategoriItem_DeleteRow(Me.DgvMstKategoriitem.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(kategoriitem_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiMstKategoriItem_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim kategoriitem_id As String
        Dim NewRowIndex As Integer

        kategoriitem_id = Me.DgvMstKategoriitem.Rows(rowIndex).Cells("kategoriitem_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_MstKategoriitem_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60))
        dbCmdDelete.Parameters("@kategoriitem_id").Value = kategoriitem_id

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvMstKategoriitem.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiMstKategoriItem_OpenRow(NewRowIndex)
                    Me.tbl_MstKategoriitem.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvMstKategoriitem.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiMstKategoriItem_OpenRow(NewRowIndex)
                    Me.tbl_MstKategoriitem.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_MstKategoriitem.Rows.RemoveAt(rowIndex)
                    Me.uiMstKategoriItem_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_MstKategoriitem_Temp.Clear()
                Me.tbl_MstKategoriitem.Rows.RemoveAt(rowIndex)

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

    Private Function uiMstKategoriItem_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim kategoriitem_id As String

        kategoriitem_id = Me.DgvMstKategoriitem.Rows(rowIndex).Cells("kategoriitem_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(kategoriitem_id)


        Try
            dbConn.Open()
            Me.uiMstKategoriItem_OpenRowMaster(kategoriitem_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiMstKategoriItem_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(kategoriitem_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiMstKategoriItem_OpenRowMaster(ByVal kategoriitem_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_MstKategoriitem_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("kategoriitem_id='{0}'", kategoriitem_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstKategoriitem_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_MstKategoriitem_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiMstKategoriItem_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiMstKategoriItem_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstKategoriItem_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstKategoriitem.CurrentCell = Me.DgvMstKategoriitem(1, 0)
            Me.uiMstKategoriItem_RefreshPosition()
        End If
    End Function

    Private Function uiMstKategoriItem_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstKategoriItem_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstKategoriitem.CurrentCell.RowIndex > 0 Then
                Me.DgvMstKategoriitem.CurrentCell = Me.DgvMstKategoriitem(1, DgvMstKategoriitem.CurrentCell.RowIndex - 1)
                Me.uiMstKategoriItem_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiMstKategoriItem_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstKategoriItem_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstKategoriitem.CurrentCell.RowIndex < Me.DgvMstKategoriitem.Rows.Count - 1 Then
                Me.DgvMstKategoriitem.CurrentCell = Me.DgvMstKategoriitem(1, DgvMstKategoriitem.CurrentCell.RowIndex + 1)
                Me.uiMstKategoriItem_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiMstKategoriItem_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiMstKategoriItem_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstKategoriitem.CurrentCell = Me.DgvMstKategoriitem(1, Me.DgvMstKategoriitem.Rows.Count - 1)
            Me.uiMstKategoriItem_RefreshPosition()
        End If
    End Function

    Private Function uiMstKategoriItem_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiMstKategoriItem_OpenRow(Me.DgvMstKategoriitem.CurrentRow.Index)
    End Function

    Private Function uiMstKategoriItem_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_MstKategoriitem_Temp_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim kategoriitem_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvMstKategoriitem.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_MstKategoriitem_Temp).EndCurrentEdit()
            tbl_MstKategoriitem_Temp_Changes = Me.tbl_MstKategoriitem_Temp.GetChanges()

            If tbl_MstKategoriitem_Temp_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(kategoriitem_id)

                        Try

                            If tbl_MstKategoriitem_Temp_Changes IsNot Nothing Then
                                success = Me.uiMstKategoriItem_SaveMaster(kategoriitem_id, tbl_MstKategoriitem_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_MstKategoriitem_Temp.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(kategoriitem_id, result)

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

    Private Function uiMstKategoriItem_FormError() As Boolean
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

        Me.InitLayoutUI()

        Me.DgvMstKategoriitem.DataSource = Me.tbl_MstKategoriitem
        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....



        End If

        Me.BindingStop()
        Me.BindingStart()

        Me.uiMstKategoriItem_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

    End Sub



    Private Sub uiMstKategoriItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Linen
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Linen

                If Me.DgvMstKategoriitem.CurrentRow IsNot Nothing Then
                    Me.uiMstKategoriItem_OpenRow(Me.DgvMstKategoriitem.CurrentRow.Index)
                Else
                    Me.uiMstKategoriItem_NewData()
                End If


        End Select
    End Sub

    Private Sub DgvMstKategoriitem_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMstKategoriitem.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvMstKategoriitem.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub





End Class