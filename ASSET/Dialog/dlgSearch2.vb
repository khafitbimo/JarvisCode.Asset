Public Class dlgSearch2
    Private CloseButtonIsPressed As Boolean
    Private tbl_temps As DataTable = New DataTable
    Private source As String

    Dim retObj As Collection

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window, _
                    ByVal Tbl_temps As DataTable, ByVal source As String) As Object


        Me.tbl_temps = Tbl_temps.Copy
        Me.source = source
        If Me.source = "rekanan" Then
            Me.FormatDgvMstRekanan(Me.DgvSearch)
        ElseIf Me.source = "budget" Then
            Me.FormatDgvMstBudget(Me.DgvSearch)
            Me.Text = "Search Budget"
            Me.tbl_temps.DefaultView.Sort = "budget_id"
        ElseIf Me.source = "budgetdetil" Then
            Me.FormatDgvMstBudgetDetil(Me.DgvSearch)
            Me.tbl_temps.DefaultView.Sort = "budgetdetil_id"
        Else
            Me.FormatDgvMstAccount(Me.DgvSearch)
        End If
        Me.DgvSearch.DataSource = Me.tbl_temps

        MyBase.ShowDialog(owner)
        If Me.CloseButtonIsPressed Then
            Return Me.retObj
        Else
            Return Nothing
        End If
    End Function

    Private Function FormatDgvMstBudget(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_Name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        cBudget_id.Name = "budget_id"
        cBudget_id.HeaderText = "ID"
        cBudget_id.DataPropertyName = "budget_id"
        cBudget_id.Width = 65
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = True

        cBudget_Name.Name = "budget_nameshort"
        cBudget_Name.HeaderText = "Name"
        cBudget_Name.DataPropertyName = "budget_nameshort"
        cBudget_Name.Width = 250
        cBudget_Name.Visible = True
        cBudget_Name.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBudget_id, cBudget_Name})

        ' DgvTrnJurnal Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False

    End Function

    Private Function FormatDgvMstBudgetDetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cBudget_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBudget_Name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cBudget_id.Name = "budgetdetil_id"
        cBudget_id.HeaderText = "ID"
        cBudget_id.DataPropertyName = "budgetdetil_id"
        cBudget_id.Width = 65
        cBudget_id.Visible = True
        cBudget_id.ReadOnly = True

        cBudget_Name.Name = "budget_name"
        cBudget_Name.HeaderText = "Name"
        cBudget_Name.DataPropertyName = "budget_name"
        cBudget_Name.Width = 250
        cBudget_Name.Visible = True
        cBudget_Name.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cBudget_id, cBudget_Name})

        ' DgvTrnJurnal Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False

    End Function

    Private Function FormatDgvMstRekanan(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cRekanan_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_name As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "ID"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 50
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = True

        cRekanan_name.Name = "rekanan_name"
        cRekanan_name.HeaderText = "Name"
        cRekanan_name.DataPropertyName = "rekanan_name"
        cRekanan_name.Width = 250
        cRekanan_name.Visible = True
        cRekanan_name.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cRekanan_id, cRekanan_name})

        ' DgvTrnJurnal Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False



    End Function

    Private Function FormatDgvMstAccount(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cAcc_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcc_nameshort As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "ID"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 65
        cAcc_id.Visible = True
        cAcc_id.ReadOnly = True

        cAcc_nameshort.Name = "acc_nameshort"
        cAcc_nameshort.HeaderText = "Name"
        cAcc_nameshort.DataPropertyName = "acc_nameshort"
        cAcc_nameshort.Width = 250
        cAcc_nameshort.Visible = True
        cAcc_nameshort.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cAcc_id, cAcc_nameshort})

        ' DgvTrnJurnal Behaviours: 
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.MultiSelect = False



    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim retObjTemp As Collection = New Collection

        If Me.DgvSearch.CurrentRow IsNot Nothing Then
            If Me.source = "rekanan" Then
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("rekanan_id").Value, "retId")
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("rekanan_name").Value, "retName")
                Me.retObj = retObjTemp
                Me.CloseButtonIsPressed = True
            ElseIf Me.source = "budget" Then
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("budget_id").Value, "retId")
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("budget_nameshort").Value, "retName")
                Me.retObj = retObjTemp
                Me.CloseButtonIsPressed = True
            ElseIf Me.source = "budgetdetil" Then
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("budgetdetil_id").Value, "retId")
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("budget_name").Value, "retName")
                Me.retObj = retObjTemp
                Me.CloseButtonIsPressed = True
            Else
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("acc_id").Value, "retId")
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("acc_name").Value, "retName")
                Me.retObj = retObjTemp
                Me.CloseButtonIsPressed = True
            End If
        Else
            MsgBox("No Data", MsgBoxStyle.Exclamation, "Exclamation")
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.CloseButtonIsPressed = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub obj_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_search.TextChanged
        Dim filter As String = String.Empty

        Try
            If Me.source = "rekanan" Then
                filter = String.Format("rekanan_name LIKE '%{0}%'", Me.obj_search.Text)
            ElseIf Me.source = "budget" Then
                filter = String.Format("budget_nameshort LIKE '%{0}%'", Me.obj_search.Text)
            ElseIf Me.source = "budgetdetil" Then
                filter = String.Format("budget_name LIKE '%{0}%'", Me.obj_search.Text)
            Else
                filter = String.Format("acc_nameshort LIKE '%{0}%'", Me.obj_search.Text)
            End If
            If Me.obj_search.Text = String.Empty Then
                filter = String.Empty
            End If

            Me.tbl_temps.DefaultView.RowFilter = filter
        Catch ex As Exception
        End Try

    End Sub

    Private Sub DgvSearch_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSearch.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvSearch.CurrentRow IsNot Nothing Then
            Dim retObjTemp As Collection = New Collection
            If Me.source = "rekanan" Then
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("rekanan_id").Value, "retId")
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("rekanan_name").Value, "retName")
                Me.retObj = retObjTemp
                Me.CloseButtonIsPressed = True
            ElseIf Me.source = "budget" Then
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("budget_id").Value, "retId")
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("budget_nameshort").Value, "retName")
                Me.retObj = retObjTemp
                Me.CloseButtonIsPressed = True
            ElseIf Me.source = "budgetdetil" Then
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("budgetdetil_id").Value, "retId")
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("budget_name").Value, "retName")
                Me.retObj = retObjTemp
                Me.CloseButtonIsPressed = True
            Else
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("acc_id").Value, "retId")
                retObjTemp.Add(Me.DgvSearch.CurrentRow.Cells("acc_nameshort").Value, "retName")
                Me.retObj = retObjTemp
                Me.CloseButtonIsPressed = True
            End If
        Else
            MsgBox("No Data", MsgBoxStyle.Exclamation, "Exclamation")
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
End Class
