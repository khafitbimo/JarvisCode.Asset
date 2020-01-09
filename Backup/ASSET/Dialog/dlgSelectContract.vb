Public Class dlgSelectContract
    Private mDSN As String
    Private mRequestID As String
    Private mRequestdetilLine As Integer
    Private tbl_SelectContract As DataTable = clsDataset.CreateTblViewContractSrtis

#Region " Layout & Init UI "
    Private Function FormatDgvRincianRequest(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cOrder_id As New DataGridViewTextBoxColumn
        Dim cOrderdetil_line As New DataGridViewTextBoxColumn
        Dim cRequest_id As New DataGridViewTextBoxColumn
        Dim cRequestdetil_line As New DataGridViewTextBoxColumn
        Dim cId_legal As New DataGridViewTextBoxColumn
        Dim cContract_id As New DataGridViewTextBoxColumn
        Dim cTotal As New DataGridViewTextBoxColumn
        Dim cApp_legal As New DataGridViewCheckBoxColumn
        Dim cApp_legalby As New DataGridViewTextBoxColumn
        Dim cApp_legaldt As New DataGridViewTextBoxColumn
        Dim cApp_artis As New DataGridViewCheckBoxColumn
        Dim cApp_artisby As New DataGridViewTextBoxColumn
        Dim cApp_artisdt As New DataGridViewTextBoxColumn
        Dim cApp_dept As New DataGridViewCheckBoxColumn
        Dim cApp_deptby As New DataGridViewTextBoxColumn
        Dim cApp_deptdt As New DataGridViewTextBoxColumn
        Dim cApp_finance As New DataGridViewCheckBoxColumn
        Dim cApp_financeby As New DataGridViewTextBoxColumn
        Dim cApp_financedt As New DataGridViewTextBoxColumn
        Dim cArtis_name As New DataGridViewTextBoxColumn

        Dim cEps_start As New DataGridViewTextBoxColumn
        Dim cEps_end As New DataGridViewTextBoxColumn
        Dim cEps_list As New DataGridViewTextBoxColumn
        Dim cShooting_start As New DataGridViewTextBoxColumn
        Dim cShooting_end As New DataGridViewTextBoxColumn
        Dim cShooting_list As New DataGridViewTextBoxColumn

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.ReadOnly = True
        cOrder_id.Visible = False

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Order Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.ReadOnly = True
        cOrderdetil_line.Visible = False

        cRequest_id.Name = "request_id"
        cRequest_id.HeaderText = "Request ID"
        cRequest_id.DataPropertyName = "request_id"
        cRequest_id.Width = 100
        cRequest_id.ReadOnly = True
        cRequest_id.Visible = True

        cRequestdetil_line.Name = "requestdetil_line"
        cRequestdetil_line.HeaderText = "Line"
        cRequestdetil_line.DataPropertyName = "requestdetil_line"
        cRequestdetil_line.Width = 35
        cRequestdetil_line.ReadOnly = True
        cRequestdetil_line.Visible = True

        cId_legal.Name = "id_legal"
        cId_legal.HeaderText = "ID"
        cId_legal.DataPropertyName = "id_legal"
        cId_legal.Width = 100
        cId_legal.ReadOnly = True
        cId_legal.Visible = False

        cContract_id.Name = "contract_id"
        cContract_id.HeaderText = "Contract ID"
        cContract_id.DataPropertyName = "contract_id"
        cContract_id.Width = 100
        cContract_id.ReadOnly = True
        cContract_id.Visible = True

        cTotal.Name = "total"
        cTotal.HeaderText = "Subtotal"
        cTotal.DataPropertyName = "total"
        cTotal.Width = 150
        cTotal.DefaultCellStyle.Format = "#,###,##0.00"
        cTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cTotal.ReadOnly = True
        cTotal.Visible = True

        cApp_legal.Name = "app_legal"
        cApp_legal.HeaderText = "App. Legal"
        cApp_legal.DataPropertyName = "app_legal"
        cApp_legal.Width = 50
        cApp_legal.ReadOnly = True
        cApp_legal.Visible = True

        cApp_legalby.Name = "app_legalby"
        cApp_legalby.HeaderText = "App. Legal By"
        cApp_legalby.DataPropertyName = "app_legalby"
        cApp_legalby.Width = 100
        cApp_legalby.ReadOnly = True
        cApp_legalby.Visible = True

        cApp_legaldt.Name = "app_legaldt"
        cApp_legaldt.HeaderText = "App. Legal Date"
        cApp_legaldt.DataPropertyName = "app_legaldt"
        cApp_legaldt.DefaultCellStyle.Format = "dd/MM/yyyy"
        cApp_legaldt.Width = 100
        cApp_legaldt.ReadOnly = True
        cApp_legaldt.Visible = True

        cApp_artis.Name = "app_artis"
        cApp_artis.HeaderText = "App. Artis"
        cApp_artis.DataPropertyName = "app_artis"
        cApp_artis.Width = 50
        cApp_artis.ReadOnly = True
        cApp_artis.Visible = True

        cApp_artisby.Name = "app_artisby"
        cApp_artisby.HeaderText = "App. Artis By"
        cApp_artisby.DataPropertyName = "app_artisby"
        cApp_artisby.Width = 100
        cApp_artisby.ReadOnly = True
        cApp_artisby.Visible = True

        cApp_artisdt.Name = "app_artisdt"
        cApp_artisdt.HeaderText = "App. Artis Date"
        cApp_artisdt.DataPropertyName = "app_artisdt"
        cApp_artisdt.DefaultCellStyle.Format = "dd/MM/yyyy"
        cApp_artisdt.Width = 100
        cApp_artisdt.ReadOnly = True
        cApp_artisdt.Visible = True

        cApp_dept.Name = "app_dept"
        cApp_dept.HeaderText = "App. Dept"
        cApp_dept.DataPropertyName = "app_dept"
        cApp_dept.Width = 50
        cApp_dept.ReadOnly = True
        cApp_dept.Visible = True

        cApp_deptby.Name = "app_deptby"
        cApp_deptby.HeaderText = "App. Dept By"
        cApp_deptby.DataPropertyName = "app_deptby"
        cApp_deptby.Width = 100
        cApp_deptby.ReadOnly = True
        cApp_deptby.Visible = True

        cApp_deptdt.Name = "app_deptdt"
        cApp_deptdt.HeaderText = "App. Dept Date"
        cApp_deptdt.DataPropertyName = "app_deptdt"
        cApp_deptdt.DefaultCellStyle.Format = "dd/MM/yyyy"
        cApp_deptdt.Width = 100
        cApp_deptdt.ReadOnly = True
        cApp_deptdt.Visible = True

        cApp_finance.Name = "app_finance"
        cApp_finance.HeaderText = "App. Finance"
        cApp_finance.DataPropertyName = "app_finance"
        cApp_finance.Width = 50
        cApp_finance.ReadOnly = True
        cApp_finance.Visible = False

        cApp_financeby.Name = "app_finanaceby"
        cApp_financeby.HeaderText = "App. Finance By"
        cApp_financeby.DataPropertyName = "app_financeby"
        cApp_financeby.Width = 100
        cApp_financeby.ReadOnly = True
        cApp_financeby.Visible = False

        cApp_financedt.Name = "app_financedt"
        cApp_financedt.HeaderText = "App. Finance Date"
        cApp_financedt.DataPropertyName = "app_financedt"
        cApp_financedt.DefaultCellStyle.Format = "dd/MM/yyyy"
        cApp_financedt.Width = 100
        cApp_financedt.ReadOnly = True
        cApp_financedt.Visible = False

        cArtis_name.Name = "artis_name"
        cArtis_name.HeaderText = "Artist Name"
        cArtis_name.DataPropertyName = "artis_name"
        cArtis_name.Width = 200
        cArtis_name.ReadOnly = True
        cArtis_name.Visible = True

        cEps_start.Name = "eps_start"
        cEps_start.HeaderText = "Eps.Start"
        cEps_start.DataPropertyName = "eps_start"
        cEps_start.Width = 100
        cEps_start.ReadOnly = True
        cEps_start.Visible = True

        cEps_end.Name = "eps_end"
        cEps_end.HeaderText = "Eps.End"
        cEps_end.DataPropertyName = "eps_end"
        cEps_end.Width = 100
        cEps_end.ReadOnly = True
        cEps_end.Visible = True

        cEps_list.Name = "episode_list"
        cEps_list.HeaderText = "Eps.List"
        cEps_list.DataPropertyName = "episode_list"
        cEps_list.Width = 100
        cEps_list.ReadOnly = True
        cEps_list.Visible = True

        cShooting_start.Name = "shooting_startdt"
        cShooting_start.HeaderText = "Shooting Start"
        cShooting_start.DataPropertyName = "shooting_startdt"
        cShooting_start.Width = 100
        cShooting_start.DefaultCellStyle.Format = "dd/MM/yyyy"
        cShooting_start.ReadOnly = True
        cShooting_start.Visible = True

        cShooting_end.Name = "shooting_enddt"
        cShooting_end.HeaderText = "Shooting End"
        cShooting_end.DataPropertyName = "shooting_enddt"
        cShooting_end.Width = 100
        cShooting_end.DefaultCellStyle.Format = "dd/MM/yyyy"
        cShooting_end.ReadOnly = True
        cShooting_end.Visible = True

        cShooting_list.Name = "shooting_list"
        cShooting_list.HeaderText = "Shooting List"
        cShooting_list.DataPropertyName = "shooting_list"
        cShooting_list.Width = 100
        cShooting_list.DefaultCellStyle.Format = "dd/MM/yyyy"
        cShooting_list.ReadOnly = True
        cShooting_list.Visible = True

        objDgv.Columns.Clear()
        objDgv.AllowUserToAddRows = False
        objDgv.Columns.AddRange(New DataGridViewColumn() _
        {cOrder_id, cOrderdetil_line, cRequest_id, cRequestdetil_line, _
        cArtis_name, cId_legal, _
        cContract_id, _
        cEps_start, cEps_end, cEps_list, _
        cShooting_start, cShooting_end, cShooting_list, _
        cTotal, _
        cApp_legal, cApp_legalby, cApp_legaldt, _
        cApp_artis, cApp_artisby, cApp_artisdt, _
        cApp_dept, cApp_deptby, cApp_deptdt, _
        cApp_finance, cApp_financeby, cApp_financedt})
        objDgv.AutoGenerateColumns = True
        objDgv.AllowUserToResizeColumns = True
        objDgv.AllowUserToResizeRows = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

    Private Function InitUI() As Boolean
        Dim oDataFiller As New clsDataFiller(Me.mDSN)

        Me.FormatDgvRincianRequest(Me.dgvRincianOrder)
        'Me.tsStatusBudget.Text = String.Format("Budget : {0}", Me.mRequestID)
        'Me.tsStatusBudgetDetail.Text = String.Format("Budget Detail : {0}", Me.mRequestdetilLine)
        oDataFiller.DataFillLineID(Me.tbl_SelectContract, "as_ViewContract_Select", Me.mRequestID, Me.mRequestdetilLine)
        Me.dgvRincianOrder.DataSource = Me.tbl_SelectContract
        Me.FormatDgvRincianRequest(Me.dgvRincianOrder)
        'If Me.dgvRincianOrder.RowCount = 0 Then
        '    Me.tbTotalAmount.Text = "0.00"
        'Else
        '    Me.tbTotalAmount.Text = Format(Me.tbl_SelectContract.Compute("SUM(requestdetil_idrreal)", ""), "#,###,##0.00")
        'End If
        Me.Cursor = Cursors.Arrow

        Return True
    End Function
#End Region

#Region " Opener "
    Public Shadows Function OpenDialog(ByVal owner As IWin32Window, ByVal RequestID As String, ByVal RequestdetilLine As Integer) As Object

        Me.mRequestID = RequestID
        Me.mRequestdetilLine = RequestdetilLine

        Me.InitUI()
        MyBase.ShowDialog(owner)

        Return True
    End Function
#End Region

    Public Sub New(ByVal DSN As String)
        InitializeComponent()
        Me.mDSN = DSN
    End Sub

End Class