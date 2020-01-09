Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils
Imports DevExpress.XtraGrid

Public Class uiTrnDepresiasi
    Private Const mUiName As String = "Depresiasi Transaction"

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormAfterNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)

    Private tbl_TrnJurnal As DataTable = clsDataset.CreateTblTrnJurnal()
    Private tbl_TrnJurnal_Temp As DataTable = clsDataset.CreateTblTrnJurnal()
    Private tbl_TrnJurnaldetil_debit As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_TrnJurnaldetil_credit As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_TrnJurnalDetil_Depre As DataTable = clsDataset.CreateTblViewTrnJurnaldetildepre()
    Private tbl_TrnJurnalDetil_Disposal As DataTable = clsDataset.CreateTblViewTrnJurnaldetildisposal()
    Private tbl_MstAcc As DataTable = clsDataset.CreateTblMstAcc()

    Private btnNewClick As Boolean = False

    Enum ModuleType
        User
        SPV
    End Enum

#Region " Window Parameter "
    Private _CHANNEL As String = "TAS"
    Private _JURNAL_SOURCE As String = "JV-Depre"
    Private _MODULE_TYPE As ModuleType = ModuleType.SPV
#End Region

#Region " Overrides "

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor

        Dim res As DialogResult

        If Me.DgvTrnJurnal.FocusedColumn IsNot Nothing Then
            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If res = DialogResult.Yes Then
                uiTrnDepresiasi_DissableJurnal(Me.DgvTrnJurnal.FocusedRowHandle)
            End If
        End If

        Me.Cursor = Cursors.Default
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor

        uiTrnDepresiasi_Retrieve()

        Me.Cursor = Cursors.Default

        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnNew_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor

        Me.btnNewClick = True

        If Me.fTabMain.SelectedTabPageIndex = 0 Then
            Me.fTabMain.SelectedTabPageIndex = 1
        End If

        Me.uiTrnDepresiasi_NewData()

        Me.Cursor = Cursors.Arrow

        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnPosting_Click() As Boolean
        Me.uiTrnDepresiasi_Posting()

        Return MyBase.btnPosting_Click()
    End Function

    Public Overrides Function btnUnposting_Click() As Boolean
        Me.uiTrnDepresiasi_UnPosting()

        Return MyBase.btnUnposting_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim jurnal As New clsTrnJurnal()

            jurnal.Print(Me.obj_jurnal_id.Text, True, Me.DSNFrm, Me.DSNFrm)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try

        Return MyBase.btnPrintPreview_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim jurnal As New clsTrnJurnal()

            jurnal.Print(Me.obj_jurnal_id.Text, False, Me.DSNFrm, Me.DSNFrm)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return MyBase.btnPrint_Click()
    End Function
#End Region

#Region " Layout and Init UI"
    Private Function InitLayoutUI() As Boolean
        Me.tbtnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.tbtnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.tbtnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.tbtnQuery.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        Me.GCTrnJurnal.DataSource = Me.tbl_TrnJurnal
        Me.GCTrnJurnalDetilDebit.DataSource = Me.tbl_TrnJurnaldetil_debit
        Me.GCTrnJurnaldetilCredit.DataSource = Me.tbl_TrnJurnaldetil_credit
        Me.GCTrnJurnaldetilDepre.DataSource = Me.tbl_TrnJurnalDetil_Depre
        Me.GCTrnJurnaldetilDisposal.DataSource = Me.tbl_TrnJurnalDetil_Disposal

        Me.RepositoryItemLookUpEdit1.DataSource = Me.tbl_MstAcc
        Me.RepositoryItemLookUpEdit1.DisplayMember = "acc_name"
        Me.RepositoryItemLookUpEdit1.ValueMember = "acc_id"

        Me.RepositoryItemLookUpEdit2.DataSource = Me.tbl_MstAcc
        Me.RepositoryItemLookUpEdit2.DisplayMember = "acc_name"
        Me.RepositoryItemLookUpEdit2.ValueMember = "acc_id"
    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.obj_jurnal_id.DataBindings.Clear()
        Me.obj_periode_id.DataBindings.Clear()
        Me.obj_jurnal_bookdate.DataBindings.Clear()
        Me.obj_created_by.DataBindings.Clear()
        Me.obj_created_dt.DataBindings.Clear()
        Me.obj_posted_by.DataBindings.Clear()
        Me.obj_posted_dt.DataBindings.Clear()
        Me.obj_jurnal_isdisabled_by.DataBindings.Clear()
        Me.obj_jurnal_isdisabled_dt.DataBindings.Clear()
        Me.obj_jurnal_descr.DataBindings.Clear()
        Me.obj_jurnal_source.DataBindings.Clear()

        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_jurnal_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_id"))
        Me.obj_periode_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "periode_id"))
        Me.obj_jurnal_bookdate.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_bookdate", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy"))
        Me.obj_created_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "created_by"))
        Me.obj_created_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "created_dt"))
        Me.obj_posted_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_ispostedby"))
        Me.obj_posted_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_isposteddate", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy"))
        Me.obj_jurnal_isdisabled_by.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_isdisabledby"))
        Me.obj_jurnal_isdisabled_dt.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_isdisableddt", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy"))
        Me.obj_jurnal_descr.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_descr"))
        Me.obj_jurnal_source.DataBindings.Add(New Binding("Text", Me.tbl_TrnJurnal_Temp, "jurnal_source"))

        Return True
    End Function

    Private Function uiTrnDepresiasi_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.fTabMain.SelectedTabPageIndex
        If iTab = 1 Then uiTrnDepresiasi_OpenRow(Me.DgvTrnJurnal.FocusedRowHandle)
    End Function
#End Region

#Region " User Defined and Function"
    Private Function uiTrnDepresiasi_Posting() As Boolean
        Dim jurnal As New clsTrnJurnal()
        Dim jurnalItem As DataRow
        Dim jurnal_id As String = Me.obj_jurnal_id.Text.ToString()

        jurnalItem = jurnal.Select(jurnal_id, DSNFrm)

        If jurnalItem IsNot Nothing Then
            If jurnalItem.Item("jurnal_isposted") = 0 Then
                Try
                    jurnal.Posting(jurnal_id, Me.UserName, Me.DSNFrm)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            End If

            Me.uiTrnDepresiasi_RefreshPosition()
        End If
    End Function

    Private Function uiTrnDepresiasi_UnPosting() As Boolean
        Dim jurnal As New clsTrnJurnal()
        Dim jurnalItem As DataRow
        Dim jurnal_id As String = Me.obj_jurnal_id.Text.ToString()

        jurnalItem = jurnal.Select(jurnal_id, Me.DSNFrm)

        If jurnalItem IsNot Nothing Then
            If jurnalItem.Item("jurnal_isposted") = 1 Then
                Try
                    jurnal.UnPosting(jurnal_id, Me.UserName, Me.DSNFrm)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            End If

            Me.uiTrnDepresiasi_RefreshPosition()
        End If
    End Function

    Private Function uiTrnDepresiasi_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        Me.tbl_TrnJurnal_Temp.Clear()
        Me.tbl_TrnJurnalDetil_Depre.Clear()
        Me.tbl_TrnJurnaldetil_credit.Clear()
        Me.tbl_TrnJurnaldetil_debit.Clear()
        Me.tbl_TrnJurnalDetil_Disposal.Clear()

        Me.BindingContext(Me.tbl_TrnJurnal_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnJurnal_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

        RaiseEvent FormAfterNew()
    End Function

    Private Function uiTrnDepresiasi_DissableJurnal(ByVal rowIndex As Integer) As Boolean
        Dim jurnal_id As String = Me.DgvTrnJurnal.GetRowCellValue(rowIndex, "jurnal_id")
        Dim NewRowIndex As Integer

        Try
            Using jurnal As New clsTrnJurnal()
                jurnal.DeleteDepresiasi(jurnal_id, Me.DSNFrm)
            End Using

            If Me.DgvTrnJurnal.RowCount > 1 Then
                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnDepresiasi_OpenRow(NewRowIndex)
                    Me.DgvTrnJurnal.DeleteRow(rowIndex)
                ElseIf rowIndex = Me.DgvTrnJurnal.RowCount - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnDepresiasi_OpenRow(NewRowIndex)
                    Me.DgvTrnJurnal.DeleteRow(rowIndex)
                Else
                    Me.DgvTrnJurnal.DeleteRow(rowIndex)
                    Me.uiTrnDepresiasi_OpenRow(rowIndex)
                End If
            Else
                Me.tbl_TrnJurnal_Temp.Clear()
                Me.DgvTrnJurnal.DeleteRow(rowIndex)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Private Function uiTrnDepresiasi_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim jurnal_id As String

        jurnal_id = Me.DgvTrnJurnal.GetRowCellValue(rowIndex, "jurnal_id")

        Me.Cursor = Cursors.WaitCursor

        RaiseEvent FormBeforeOpenRow(jurnal_id)

        Try
            Me.uiTrnDepresiasi_OpenRowMaster(jurnal_id)
            Me.uiTrnDepresiasi_OpenRowDetilDebit(jurnal_id)
            Me.uiTrnDepresiasi_OpenRowDetilCredit(jurnal_id)
            Me.uiTrnDepresiasi_OpenRowDetilDepre(jurnal_id)
            Me.uiTrnDepresiasi_OpenRowDetilDisposal(jurnal_id)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnDepresiasi_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        RaiseEvent FormAfterOpenRow(jurnal_id)
        Me.Cursor = Cursors.Arrow

        Return True
    End Function

    Private Sub uiTrnDepresiasi_OpenRowMaster(ByVal jurnal_id As String)
        Me.tbl_TrnJurnal_Temp.Clear()

        Try
            Me.BindingStop()

            Using jurnal As New clsTrnJurnal()
                jurnal.RetrieveHeader(Me.tbl_TrnJurnal_Temp, String.Format("jurnal_id='{0}'", jurnal_id), Me.DSNFrm)
            End Using

            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnDepresiasi_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub uiTrnDepresiasi_OpenRowDetilDebit(ByVal jurnal_id As String)
        Me.tbl_TrnJurnaldetil_debit.Clear()

        Try
            Dim criteria As String

            criteria = String.Format("jurnal_id = '{0}' and jurnaldetil_dk =  'D'", jurnal_id)

            Using jurnal As New clsTrnJurnal()
                jurnal.RetrieveDetail(Me.tbl_TrnJurnaldetil_debit, criteria, Me._CHANNEL, Me.DSNFrm)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub uiTrnDepresiasi_OpenRowDetilCredit(ByVal jurnal_id As String)
        Me.tbl_TrnJurnaldetil_credit.Clear()

        Try
            Dim criteria As String

            criteria = String.Format("jurnal_id = '{0}' and jurnaldetil_dk =  'K'", jurnal_id)

            Using jurnal As New clsTrnJurnal()
                jurnal.RetrieveDetail(Me.tbl_TrnJurnaldetil_credit, criteria, Me._CHANNEL, Me.DSNFrm)
            End Using

            For Each row As DataRow In Me.tbl_TrnJurnaldetil_credit.Rows
                row.Item("jurnaldetil_foreign") = -row.Item("jurnaldetil_foreign")
                row.Item("jurnaldetil_idr") = -row.Item("jurnaldetil_idr")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub uiTrnDepresiasi_OpenRowDetilDepre(ByVal jurnal_id As String)
        Me.tbl_TrnJurnalDetil_Depre.Clear()

        Try
            Dim criteria As String

            criteria = String.Format("jurnal_id = '{0}'", jurnal_id)

            Using jurnal As New clsTrnJurnal()
                jurnal.RetrieveDetailDepre(Me.tbl_TrnJurnalDetil_Depre, criteria, Me.DSNFrm)
            End Using
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnDepresiasi_OpenRowDetilDepre()" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub uiTrnDepresiasi_OpenRowDetilDisposal(ByVal jurnal_id As String)
        Me.tbl_TrnJurnalDetil_Disposal.Clear()

        Try
            Dim criteria As String

            criteria = String.Format("asset_barcode in (select asset_barcode from transaksi_jurnaldetildepre where jurnal_id = '{0}') and jurnal_isposted = 1", jurnal_id)

            Using jurnal As New clsTrnJurnal()
                jurnal.RetrieveViewDetailDisposal(Me.tbl_TrnJurnalDetil_Disposal, criteria, Me.DSNFrm)
            End Using
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnDepresiasi_OpenRowDetilDisposal()" & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

    Private Function uiTrnDepresiasi_Retrieve() As Boolean
        Me.tbl_TrnJurnal.Clear()

        Try
            Using jurnal As New clsTrnJurnal()
                Dim criteria As String

                criteria = String.Format("channel_id = '{0}' and jurnal_source = '{1}' and jurnal_isdisabled = 0", Me._CHANNEL, Me._JURNAL_SOURCE)
                jurnal.RetrieveHeader(Me.tbl_TrnJurnal, criteria, Me.DSNFrm)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub uiTrnDepresiasi_FormAfterNew() Handles Me.FormAfterNew
        Dim dlg As New dlgDepresiasiNew(Me._CHANNEL, Me.UserName, Me.DSNFrm)

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim jurnal_id As String

            jurnal_id = dlg.GetJurnalID()

            Me.tbl_TrnJurnal.ImportRow(New clsTrnJurnal().Select(jurnal_id, DSNFrm))

            For i As Integer = 0 To Me.DgvTrnJurnal.RowCount - 1
                If Me.DgvTrnJurnal.GetRowCellValue(i, "jurnal_id") = jurnal_id Then
                    Me.DgvTrnJurnal.FocusedRowHandle = i
                End If
            Next

            Me.uiTrnDepresiasi_RefreshPosition()
        Else
            Me.fTabMain.SelectedTabPageIndex = 0
        End If
    End Sub

    Private Sub uiTrnDepresiasi_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Dim jurnal As New clsTrnJurnal()

        Select Case Me._MODULE_TYPE
            Case ModuleType.User
                Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Case ModuleType.SPV
                If jurnal.Select(id, DSNFrm).Item("jurnal_isposted") = 1 Then
                    Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Else
                    Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                End If
        End Select

        If jurnal.Select(id, DSNFrm).Item("jurnal_isposted") = 1 Then
            Me.tbtnDel.Enabled = False
        Else
            Me.tbtnDel.Enabled = True
        End If

        Me.amountCalculate()
    End Sub

    Private Sub uiTrnDepresiasi_FormBeforeNew() Handles Me.FormBeforeNew
        Me.clearText()
    End Sub

    Private Sub uiTrnDepresiasi_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If
    End Sub

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            Dim moduleType As String

            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")

            moduleType = Me.GetValueFromParameter(objParameters, "MODULE_TYPE")

            If moduleType.ToLower() = "user" Then
                Me._MODULE_TYPE = uiTrnDepresiasi.ModuleType.User
            ElseIf moduleType.ToLower() = "spv" Then
                Me._MODULE_TYPE = uiTrnDepresiasi.ModuleType.SPV
            End If
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Me.InitLayoutUI()

            Me.BindingStop()
            Me.BindingStart()

            Using acc As New clsMstAcc(Me.DSNFrm)
                acc.Retrieve(Me.tbl_MstAcc, "")
            End Using

            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = True
            Me.tbtnQuery.Enabled = True
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True
        End If
    End Sub

    Private Sub DgvTrnDepreiasi_DoubleClick(sender As Object, e As EventArgs) Handles DgvTrnJurnal.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)

        Dim info As GridHitInfo = view.CalcHitInfo(pt)

        If info.InRow OrElse info.InRowCell Then
            If view.FocusedColumn Is Nothing Or view.FocusedRowHandle < 0 Then
                Exit Sub
            End If

            If Me.DgvTrnJurnal.FocusedColumn IsNot Nothing Then
                Me.fTabMain.SelectedTabPageIndex = 1
            End If
        End If
    End Sub

    Private Sub fTabMain_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles fTabMain.SelectedPageChanged
        Select Case fTabMain.SelectedTabPageIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.btnNewClick = False
                Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Case 1
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.tbtnDel.Enabled = True


                If Me.btnNewClick = False Then
                    If Me.DgvTrnJurnal.FocusedColumn IsNot Nothing And DgvTrnJurnal.RowCount > 0 Then
                        Me.uiTrnDepresiasi_OpenRow(Me.DgvTrnJurnal.FocusedRowHandle)
                    Else
                        Me.uiTrnDepresiasi_NewData()
                    End If
                End If
        End Select
    End Sub

    Private Sub amountCalculate()
        Dim amountDebit As Decimal
        Dim amountCredit As Decimal
        Dim amountIdrDebit As Decimal
        Dim amountIdrCredit As Decimal
        Dim selisihAmount As Decimal
        Dim selisihAmountIdr As Decimal
        Dim totalDepre As Decimal

        amountDebit = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_debit.Compute("SUM(jurnaldetil_foreign)", ""), 0)
        amountCredit = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_credit.Compute("SUM(jurnaldetil_foreign)", ""), 0)
        amountIdrDebit = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_debit.Compute("SUM(jurnaldetil_idr)", ""), 0)
        amountIdrCredit = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_credit.Compute("SUM(jurnaldetil_idr)", ""), 0)
        totalDepre = Me.getTotalDepre() 'clsUtil.IsDbNull(Me.tbl_TrnJurnalDetil_Depre.Compute("SUM(depresiasi_depremonth)", ""), 0)

        selisihAmount = amountDebit - amountCredit
        selisihAmountIdr = amountIdrDebit - amountIdrCredit

        Me.obj_jumlah_amount.Text = amountDebit.ToString("###,###.00")
        Me.obj_jumlah_amountidr.Text = amountIdrDebit.ToString("###,###")

        Me.obj_amount_debit.Text = amountDebit.ToString("###,###.00")
        Me.obj_amount_debitidr.Text = amountIdrDebit.ToString("###,###.00")

        Me.obj_amount_credit.Text = amountCredit.ToString("###,###.00")
        Me.obj_amount_creditidr.Text = amountIdrCredit.ToString("###,###.00")

        Me.obj_selisih_amount.Text = selisihAmount.ToString("###,###.00")
        Me.obj_selisih_amountidr.Text = selisihAmountIdr.ToString("###,###.00")
        Me.obj_total_depre.Text = totalDepre.ToString("###,###.00")
    End Sub

    Private Sub clearText()
        Me.obj_jumlah_amount.Text = 0
        Me.obj_jumlah_amountidr.Text = 0
        Me.obj_amount_debit.Text = 0
        Me.obj_amount_debitidr.Text = 0
        Me.obj_amount_credit.Text = 0
        Me.obj_amount_creditidr.Text = 0
        Me.obj_selisih_amount.Text = 0
        Me.obj_selisih_amountidr.Text = 0
        Me.obj_total_depre.Text = 0
    End Sub

    Private Function getTotalDepre() As Double
        Dim total As Double = 0

        For i As Integer = 0 To Me.DgvTrnJurnaldetilDepre.RowCount - 1
            total += Me.DgvTrnJurnaldetilDepre.GetRowCellValue(i, "depresiasi_depremonth")
        Next

        Return total
    End Function

    Private Sub DgvTrnJurnaldetilDepre_ColumnFilterChanged(sender As Object, e As EventArgs) Handles DgvTrnJurnaldetilDepre.ColumnFilterChanged
        Me.obj_total_depre.Text = Me.getTotalDepre.ToString("###,###.00")
    End Sub

    Private Sub DgvTrnDepresiasiDetil_CustomColumnDisplayText(sender As Object, e As Views.Base.CustomColumnDisplayTextEventArgs) Handles DgvTrnJurnaldetilDepre.CustomColumnDisplayText
        If e.Column Is colNumber Then
            e.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub DgvTrnJurnal_RowStyle(sender As Object, e As RowStyleEventArgs) Handles DgvTrnJurnal.RowStyle
        Dim view As GridView = sender

        If e.RowHandle >= 0 Then
            Dim approve As Object = view.GetDataRow(e.RowHandle).Item("jurnal_isposted")

            If approve = False Then
                e.Appearance.BackColor = Nothing
            ElseIf approve = True Then
                e.Appearance.BackColor = Color.LightGreen
            End If
        End If
    End Sub

End Class
