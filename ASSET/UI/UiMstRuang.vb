Public Class UiMstRuang
    Private Const mUiName As String = "Tabel Ruang"
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

    Private tbl_MstRuang As DataTable = clsDataset.CreateTblMstRuang()
    Private tbl_MstRuang_Temp As DataTable = clsDataset.CreateTblMstRuang()
    Private tbl_MstChannel As DataTable = clsDataset.CreateTblMstChannel
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel



#Region " Window Parameter "
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

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
        Me.UiMstRuang_NewData()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstRuang_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.UiMstRuang_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstRuang_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function


    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstRuang_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstRuang_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstRuang_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstRuang_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstRuang_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.UiMstRuang_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region


#Region " Layout & Init UI "

    Private Function FormatDgvMstRuang(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvMstRuang Columns 
        Dim cRuang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cWilayah_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cGedung_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRuang_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRuang_lantai As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cRuang_id.Name = "ruang_id"
        cRuang_id.HeaderText = "Room Number"
        cRuang_id.DataPropertyName = "ruang_id"
        cRuang_id.Width = 100
        cRuang_id.Visible = True
        cRuang_id.ReadOnly = False

        cWilayah_name.Name = "wilayah_name"
        cWilayah_name.HeaderText = "Location"
        cWilayah_name.DataPropertyName = "wilayah_name"
        cWilayah_name.Width = 100
        cWilayah_name.Visible = True
        cWilayah_name.ReadOnly = False

        cGedung_name.Name = "gedung_name"
        cGedung_name.HeaderText = "Building"
        cGedung_name.DataPropertyName = "gedung_name"
        cGedung_name.Width = 120
        cGedung_name.Visible = True
        cGedung_name.ReadOnly = False

        cRuang_name.Name = "ruang_name"
        cRuang_name.HeaderText = "Room Name"
        cRuang_name.DataPropertyName = "ruang_name"
        cRuang_name.Width = 300
        cRuang_name.Visible = True
        cRuang_name.ReadOnly = False

        cRuang_lantai.Name = "ruang_lantai"
        cRuang_lantai.HeaderText = "Floor"
        cRuang_lantai.DataPropertyName = "ruang_lantai"
        cRuang_lantai.Width = 50
        cRuang_lantai.Visible = True
        cRuang_lantai.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 75
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cRuang_id, cWilayah_name, cGedung_name, cRuang_name, cRuang_lantai, cChannel_id})



        ' DgvMstRuang Behaviours: 
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
        Me.DgvMstRuang.Dock = DockStyle.Fill

        Me.FormatDgvMstRuang(Me.DgvMstRuang)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_Ruang_id.DataBindings.Clear()
        Me.obj_wilayah_name.DataBindings.Clear()
        Me.obj_Gedung_name.DataBindings.Clear()
        Me.obj_Ruang_name.DataBindings.Clear()
        Me.obj_Ruang_lantai.DataBindings.Clear()
        Me.obj_Channel_id.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Ruang_id.DataBindings.Add(New Binding("Text", Me.tbl_MstRuang_Temp, "ruang_id"))
        Me.obj_wilayah_name.DataBindings.Add(New Binding("Text", Me.tbl_MstRuang_Temp, "wilayah_name"))
        Me.obj_Gedung_name.DataBindings.Add(New Binding("Text", Me.tbl_MstRuang_Temp, "gedung_name"))
        Me.obj_Ruang_name.DataBindings.Add(New Binding("Text", Me.tbl_MstRuang_Temp, "ruang_name"))
        Me.obj_Ruang_lantai.DataBindings.Add(New Binding("Text", Me.tbl_MstRuang_Temp, "ruang_lantai"))
        Me.obj_Channel_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_MstRuang_Temp, "channel_id"))
        Return True
    End Function

#End Region


#Region " Dialoged Control "
#End Region


#Region " User Defined Function "

    Private Function UiMstRuang_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_MstRuang_Temp
        Me.tbl_MstRuang_Temp.Clear()




        Me.BindingContext(Me.tbl_MstRuang_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_MstRuang_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function UiMstRuang_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()


        Me.tbl_MstRuang.Clear()
        Try
            Me.DataFill(Me.tbl_MstRuang, "as_MstRuang_Select", criteria, Me.cboSearchChannel.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function UiMstRuang_Save() As Boolean
        'save data
        Dim tbl_MstRuang_Temp_Changes As DataTable
        Dim success As Boolean
        Dim ruang_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(ruang_id)

        Me.BindingContext(Me.tbl_MstRuang_Temp).EndCurrentEdit()
        tbl_MstRuang_Temp_Changes = Me.tbl_MstRuang_Temp.GetChanges()

        If tbl_MstRuang_Temp_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_MstRuang_Temp.Rows(0).RowState
                ruang_id = tbl_MstRuang_Temp.Rows(0).Item("ruang_id")

                If tbl_MstRuang_Temp_Changes IsNot Nothing Then
                    success = Me.UiMstRuang_SaveMaster(ruang_id, tbl_MstRuang_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.UiMstRuang_SaveMaster(tbl_MstRuang_Temp_Changes)")
                    Me.tbl_MstRuang_Temp.AcceptChanges()
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

        RaiseEvent FormAfterSave(ruang_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function UiMstRuang_SaveMaster(ByRef ruang_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: master_ruang
        dbCmdInsert = New OleDb.OleDbCommand("as_MstRuang_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_id", System.Data.OleDb.OleDbType.VarWChar, 20, "ruang_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wilayah_name", System.Data.OleDb.OleDbType.VarWChar, 100, "wilayah_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@gedung_name", System.Data.OleDb.OleDbType.VarWChar, 40, "gedung_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_name", System.Data.OleDb.OleDbType.VarWChar, 100, "ruang_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_lantai", System.Data.OleDb.OleDbType.Integer, 4, "ruang_lantai"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))


        dbCmdUpdate = New OleDb.OleDbCommand("as_MstRuang_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_id", System.Data.OleDb.OleDbType.VarWChar, 20, "ruang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wilayah_name", System.Data.OleDb.OleDbType.VarWChar, 100, "wilayah_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@gedung_name", System.Data.OleDb.OleDbType.VarWChar, 40, "gedung_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_name", System.Data.OleDb.OleDbType.VarWChar, 100, "ruang_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_lantai", System.Data.OleDb.OleDbType.Integer, 4, "ruang_lantai"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            ruang_id = objTbl.Rows(0).Item("ruang_id")
            Me.tbl_MstRuang_Temp.Clear()
            Me.tbl_MstRuang_Temp.Merge(objTbl)

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
            Me.tbl_MstRuang.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_MstRuang).Position
            Me.tbl_MstRuang.Rows.RemoveAt(curpos)
            Me.tbl_MstRuang.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_MstRuang).Position = Me.BindingContext(Me.tbl_MstRuang).Count

        Return True
    End Function

    Private Function UiMstRuang_Print() As Boolean
        'print data
    End Function

    Private Function UiMstRuang_Delete() As Boolean
        Dim res As String = ""
        Dim ruang_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(ruang_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvMstRuang.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.UiMstRuang_DeleteRow(Me.DgvMstRuang.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(ruang_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function UiMstRuang_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim ruang_id As String
        Dim NewRowIndex As Integer

        ruang_id = Me.DgvMstRuang.Rows(rowIndex).Cells("ruang_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_MstRuang_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@ruang_id").Value = ruang_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wilayah_name", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@wilayah_name").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@gedung_name", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters("@gedung_name").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_name", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@ruang_name").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_lantai", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@ruang_lantai").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvMstRuang.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.UiMstRuang_OpenRow(NewRowIndex)
                    Me.tbl_MstRuang.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvMstRuang.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.UiMstRuang_OpenRow(NewRowIndex)
                    Me.tbl_MstRuang.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_MstRuang.Rows.RemoveAt(rowIndex)
                    Me.UiMstRuang_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_MstRuang_Temp.Clear()
                Me.tbl_MstRuang.Rows.RemoveAt(rowIndex)

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

    Private Function UiMstRuang_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.ASSET_DSN)
        Dim ruang_id As String
        Dim channel_id As String

        ruang_id = Me.DgvMstRuang.Rows(rowIndex).Cells("ruang_id").Value
        channel_id = Me.DgvMstRuang.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(ruang_id)


        Try
            dbConn.Open()
            Me.UiMstRuang_OpenRowMaster(channel_id, ruang_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": UiMstRuang_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(ruang_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function UiMstRuang_OpenRowMaster(ByVal channel_id As String, ByVal ruang_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_MstRuang_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("ruang_id='{0}'", ruang_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_MstRuang_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_MstRuang_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": UiMstRuang_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function UiMstRuang_First() As Boolean
        'goto first record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.UiMstRuang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstRuang.CurrentCell = Me.DgvMstRuang(1, 0)
            Me.UiMstRuang_RefreshPosition()
        End If
    End Function

    Private Function UiMstRuang_Prev() As Boolean
        'goto previous record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.UiMstRuang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstRuang.CurrentCell.RowIndex > 0 Then
                Me.DgvMstRuang.CurrentCell = Me.DgvMstRuang(1, DgvMstRuang.CurrentCell.RowIndex - 1)
                Me.UiMstRuang_RefreshPosition()
            End If
        End If
    End Function

    Private Function UiMstRuang_Next() As Boolean
        'goto next record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.UiMstRuang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvMstRuang.CurrentCell.RowIndex < Me.DgvMstRuang.Rows.Count - 1 Then
                Me.DgvMstRuang.CurrentCell = Me.DgvMstRuang(1, DgvMstRuang.CurrentCell.RowIndex + 1)
                Me.UiMstRuang_RefreshPosition()
            End If
        End If
    End Function

    Private Function UiMstRuang_Last() As Boolean
        'goto last record found
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.UiMstRuang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvMstRuang.CurrentCell = Me.DgvMstRuang(1, Me.DgvMstRuang.Rows.Count - 1)
            Me.UiMstRuang_RefreshPosition()
        End If
    End Function

    Private Function UiMstRuang_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then UiMstRuang_OpenRow(Me.DgvMstRuang.CurrentRow.Index)
    End Function

    Private Function UiMstRuang_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_MstRuang_Temp_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim ruang_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvMstRuang.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_MstRuang_Temp).EndCurrentEdit()
            tbl_MstRuang_Temp_Changes = Me.tbl_MstRuang_Temp.GetChanges()

            If tbl_MstRuang_Temp_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(ruang_id)

                        Try

                            If tbl_MstRuang_Temp_Changes IsNot Nothing Then
                                success = Me.UiMstRuang_SaveMaster(ruang_id, tbl_MstRuang_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_MstRuang_Temp.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(ruang_id, result)

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

    Private Function UiMstRuang_FormError() As Boolean
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

        Me.DgvMstRuang.DataSource = Me.tbl_MstRuang
        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Dim dummyparameter As String = "CHANNEL_ID=TTV;"

            objParameters = Me.GetParameterCollection(dummyparameter)
            'objParameters = Me.GetParameterCollection(Me.Parameter)

            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL_ID")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")

            Me.ComboFill(Me.obj_Channel_id, "channel_id", "channel_id", Me.tbl_MstChannel, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'", "")
            Me.tbl_MstChannel.DefaultView.Sort = "channel_id"
            Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", Me.tbl_MstChannelSearch, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'")
            Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_id"

        End If

        'Me._CHANNEL = "TTV"
        Me.cboSearchChannel.SelectedValue = Me._CHANNEL

        Me.InitLayoutUI()
        Me.BindingStop()
        Me.BindingStart()

        Me.UiMstRuang_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

        Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_CHANGED
        Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
    End Sub



    Private Sub UiMstRuang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

                If Me.DgvMstRuang.CurrentRow IsNot Nothing Then
                    Me.UiMstRuang_OpenRow(Me.DgvMstRuang.CurrentRow.Index)
                Else
                    Me.UiMstRuang_NewData()
                End If


        End Select
    End Sub

    Private Sub DgvMstRuang_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMstRuang.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvMstRuang.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub





End Class