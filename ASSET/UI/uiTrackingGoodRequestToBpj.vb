Public Class uiTrackingGoodRequestToBpj

    Private tbl_tracking As DataTable = clsDataset.CreateTblViewTrackingGoodRequestToBpj
    Private tbl_tracking_search As DataTable = clsDataset.CreateTblViewTrackingGoodRequestToBpj
    Private tbl_MstStrukturunit_id_search As DataTable = clsDataset.CreateTblStrukturunitPemilik
    Private tbl_MstStrukturunit_id_search_main As DataTable = clsDataset.CreateTblStrukturunitPemilik

    Private tbl_Print As DataTable = clsDataset.CreateTblViewTrackingGoodRequestToBpj

    Private jumlah_data As Integer
    Private jmlh_data_dayLess0 As Integer
    Private jmlh_data_day0to2 As Integer
    Private jmlh_data_day3 As Integer
    Private jmlh_data_day4 As Integer
    Private jmlh_data_day5 As Integer
    Private jmlh_data_greater5 As Integer
    Private jmlh_data_all As Integer


#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
    Private _STRUKTURUNIT As Decimal = 5554
#End Region
    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
            Me._STRUKTURUNIT = Me.GetDecValueFromParameter(objParameters, "STRUKTURUNIT")
        End If

        Me.InitLayoutUI()
        For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
            If tsItem.GetType.ToString = "System.Windows.Forms.ToolStripSeparator" Or (tsItem.Name <> "tbtnLoad") Then
                tsItem.Visible = False
            End If
        Next
        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then

        '    Dim dummyparameter As String = "CHANNEL=TTV;"
        '    objParameters = Me.GetParameterCollection(dummyparameter)
        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
        'End If

        Me.DgvSearch.DataSource = Me.tbl_tracking_search

        Me.ComboFill(Me.cboSearchStrukturunit_ID, "strukturunit_id", "strukturunit_name", tbl_MstStrukturunit_id_search, "ms_MstStrukturUnit_Select", "", "")
        Me.tbl_MstStrukturunit_id_search.DefaultView.Sort = "strukturunit_name"

        Dim LL As Boolean
        Me.tbl_MstStrukturunit_id_search_main = tbl_MstStrukturunit_id_search.Copy
        LL = ComboFillFromDataTable(ComboBox4, "strukturunit_id", "strukturunit_name", tbl_MstStrukturunit_id_search_main)
        Me.tbl_MstStrukturunit_id_search_main.DefaultView.Sort = "strukturunit_name"

        Me.cboSearchStrukturunit_ID.SelectedValue = Me._STRUKTURUNIT
        Me.ComboBox4.SelectedValue = Me._STRUKTURUNIT
        Me.chkSearchStrukturunit_ID.Checked = True
        Me.CheckBox5.Checked = True

        Me.cbo_rekap.SelectedItem = "Entry Goods Request"

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = False
        Me.tbtnNew.Enabled = False
        Me.tbtnFirst.Enabled = False
        Me.tbtnPrev.Enabled = False
        Me.tbtnNext.Enabled = False
        Me.tbtnLast.Enabled = False
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = True


    End Sub

    Private Sub uiTrackingGoodRequestToBpj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If
    End Sub

#Region " Layout & Init UI "
    Private Function InitLayoutUI() As Boolean
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch_Searching.Dock = DockStyle.Top
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.PnlDfMain_Searching.Dock = DockStyle.Fill

        FormatDgvTrnGoodRequest(Me.DgvSearch)
    End Function
#End Region

#Region " untuk tab Searching "

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor

        If ftabMain.SelectedIndex = 0 Then
            Me.uiTrackingGoodRequestToBpj_PrintPreview()
        Else
            Me.uiTrackingGoodRequestToBpj_Retrieve()
            If Me.DgvSearch.Rows.Count <> 0 Then
                Me.TextBox1.ReadOnly = False
            Else
                Me.TextBox1.ReadOnly = True
            End If
        End If
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Private Function uiTrackingGoodRequestToBpj_Retrieve() As Boolean
        Dim criteria As String = String.Empty

        If Me.chkSearchStrukturunit_ID.Checked = True Then
            If criteria = String.Empty Then
                criteria = String.Format(" Department = {0} ", Me.ComboBox4.SelectedValue)
            Else
                criteria &= String.Format(" AND Department = {0} ", Me.ComboBox4.SelectedValue)
            End If
        End If

        criteria &= " AND LEFT(PurchaseRentalOrder,2) = 'RO'"
        Me.tbl_tracking.Clear()
        Try
            Me.DataFill(Me.tbl_tracking_search, "as_GoodRequest_to_Bpj_Tracking_Select", criteria)
            Me.Label18.Text = Me.tbl_tracking_search.Rows.Count & " Data"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Function FormatDgvTrnGoodRequest(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cGoodsRequest As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cDepartment As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEntryDate1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPrepareDate1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUseDateFrom1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUseDateUntil1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLine1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cQuantity1 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApprovedDateSpv As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApprovedSpvBy As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_GR As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_receceived_date_GQ As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPurchaseRentalRequest As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAcara As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEntryDate2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPrepareDate2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUseDateFrom2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUseDateUntil2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLine2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cQuantity2 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApprovedDateDept As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_approved1by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApprovedDateDiv As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequest_approved2by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApprovedDateProc As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_approvedprocby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApprovedDateBMA As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRequestdetil_approvedbmaby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPurchaseRentalOrder As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEntryDate3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cPrepareDate3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUseDateFrom3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUseDateUntil3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLine3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cItem3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cQuantity3 As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cVendor As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_receceived_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_OrderDel_by As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCirculation_OrderDel_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_tgl As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApprovedUser As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUser_applogin As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cApprovedSPV As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cProcurement_applogin As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cGoodsRequest.Name = "GoodsRequest"
        cGoodsRequest.HeaderText = "No."
        cGoodsRequest.DataPropertyName = "GoodsRequest"
        cGoodsRequest.Width = 120
        cGoodsRequest.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cGoodsRequest.Visible = True
        cGoodsRequest.ReadOnly = False
        cGoodsRequest.DefaultCellStyle.BackColor = Color.Turquoise

        cDepartment.Name = "Department"
        cDepartment.HeaderText = "Department"
        cDepartment.DataPropertyName = "Department"
        cDepartment.Width = 120
        cDepartment.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cDepartment.Visible = False
        cDepartment.ReadOnly = False
        cDepartment.DefaultCellStyle.BackColor = Color.Turquoise

        cEntryDate1.Name = "EntryDate1"
        cEntryDate1.HeaderText = "Entry Date"
        cEntryDate1.DataPropertyName = "EntryDate1"
        cEntryDate1.Width = 130
        cEntryDate1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEntryDate1.Visible = True
        cEntryDate1.ReadOnly = False
        cEntryDate1.DefaultCellStyle.BackColor = Color.Turquoise

        cPrepareDate1.Name = "PrepareDate1"
        cPrepareDate1.HeaderText = "Prepare Date"
        cPrepareDate1.DataPropertyName = "PrepareDate1"
        cPrepareDate1.Width = 130
        cPrepareDate1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPrepareDate1.Visible = True
        cPrepareDate1.ReadOnly = False
        cPrepareDate1.DefaultCellStyle.BackColor = Color.Turquoise

        cUseDateFrom1.Name = "UseDateFrom1"
        cUseDateFrom1.HeaderText = "Use Date From"
        cUseDateFrom1.DataPropertyName = "UseDateFrom1"
        cUseDateFrom1.Width = 130
        cUseDateFrom1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUseDateFrom1.Visible = True
        cUseDateFrom1.ReadOnly = False
        cUseDateFrom1.DefaultCellStyle.BackColor = Color.Turquoise

        cUseDateUntil1.Name = "UseDateUntil1"
        cUseDateUntil1.HeaderText = "Use Date Until"
        cUseDateUntil1.DataPropertyName = "UseDateUntil1"
        cUseDateUntil1.Width = 130
        cUseDateUntil1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUseDateUntil1.Visible = True
        cUseDateUntil1.ReadOnly = False
        cUseDateUntil1.DefaultCellStyle.BackColor = Color.Turquoise

        cLine1.Name = "Line1"
        cLine1.HeaderText = "Line1"
        cLine1.DataPropertyName = "Line1"
        cLine1.Width = 100
        cLine1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLine1.Visible = False
        cLine1.ReadOnly = False

        cItem1.Name = "Item1"
        cItem1.HeaderText = "Item Name"
        cItem1.DataPropertyName = "Item1"
        cItem1.Width = 200
        cItem1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem1.Visible = True
        cItem1.ReadOnly = False
        cItem1.DefaultCellStyle.BackColor = Color.Turquoise

        cQuantity1.Name = "Quantity1"
        cQuantity1.HeaderText = "Quantity1"
        cQuantity1.DataPropertyName = "Quantity1"
        cQuantity1.Width = 100
        cQuantity1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cQuantity1.Visible = False
        cQuantity1.ReadOnly = False

        cApprovedDateSpv.Name = "ApprovedDateSpv"
        cApprovedDateSpv.HeaderText = "Approved Date"
        cApprovedDateSpv.DataPropertyName = "ApprovedDateSpv"
        cApprovedDateSpv.Width = 130
        cApprovedDateSpv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cApprovedDateSpv.Visible = True
        cApprovedDateSpv.ReadOnly = False
        cApprovedDateSpv.DefaultCellStyle.BackColor = Color.Turquoise

        cApprovedSpvBy.Name = "ApprovedSpvBy"
        cApprovedSpvBy.HeaderText = "Approved By"
        cApprovedSpvBy.DataPropertyName = "ApprovedSpvBy"
        cApprovedSpvBy.Width = 200
        cApprovedSpvBy.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cApprovedSpvBy.Visible = True
        cApprovedSpvBy.ReadOnly = False
        cApprovedSpvBy.DefaultCellStyle.BackColor = Color.Turquoise

        cCirculation_GR.Name = "circulation_GR_by"
        cCirculation_GR.HeaderText = "Document No."
        cCirculation_GR.DataPropertyName = "circulation_GR_by"
        cCirculation_GR.Width = 130
        cCirculation_GR.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_GR.Visible = True
        cCirculation_GR.ReadOnly = False
        cCirculation_GR.DefaultCellStyle.BackColor = Color.Thistle

        cCirculation_receceived_date_GQ.Name = "circulation_GR_date"
        cCirculation_receceived_date_GQ.HeaderText = "Doc.Received Date"
        cCirculation_receceived_date_GQ.DataPropertyName = "circulation_GR_date"
        cCirculation_receceived_date_GQ.Width = 130
        cCirculation_receceived_date_GQ.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_receceived_date_GQ.Visible = True
        cCirculation_receceived_date_GQ.ReadOnly = False
        cCirculation_receceived_date_GQ.DefaultCellStyle.BackColor = Color.Thistle

        cCirculation_OrderDel_by.Name = "orderDelivery_by"
        cCirculation_OrderDel_by.HeaderText = "Order Delv. By"
        cCirculation_OrderDel_by.DataPropertyName = "orderDelivery_by"
        cCirculation_OrderDel_by.Width = 130
        cCirculation_OrderDel_by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_OrderDel_by.Visible = True
        cCirculation_OrderDel_by.ReadOnly = False
        cCirculation_OrderDel_by.DefaultCellStyle.BackColor = Color.Thistle

        cCirculation_OrderDel_date.Name = "orderDelivery_date"
        cCirculation_OrderDel_date.HeaderText = "Order Delv. Date"
        cCirculation_OrderDel_date.DataPropertyName = "orderDelivery_date"
        cCirculation_OrderDel_date.Width = 130
        cCirculation_OrderDel_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_OrderDel_date.Visible = True
        cCirculation_OrderDel_date.ReadOnly = False
        cCirculation_OrderDel_date.DefaultCellStyle.BackColor = Color.Thistle

        cPurchaseRentalRequest.Name = "PurchaseRentalRequest"
        cPurchaseRentalRequest.HeaderText = "No."
        cPurchaseRentalRequest.DataPropertyName = "PurchaseRentalRequest"
        cPurchaseRentalRequest.Width = 120
        cPurchaseRentalRequest.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPurchaseRentalRequest.Visible = True
        cPurchaseRentalRequest.ReadOnly = False
        cPurchaseRentalRequest.DefaultCellStyle.BackColor = Color.Bisque

        cAcara.Name = "acara"
        cAcara.HeaderText = "Programme Name"
        cAcara.DataPropertyName = "acara"
        cAcara.Width = 200
        cAcara.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAcara.Visible = True
        cAcara.ReadOnly = False
        cAcara.DefaultCellStyle.BackColor = Color.Turquoise

        cEntryDate2.Name = "EntryDate2"
        cEntryDate2.HeaderText = "Entry Date"
        cEntryDate2.DataPropertyName = "EntryDate2"
        cEntryDate2.Width = 130
        cEntryDate2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEntryDate2.Visible = True
        cEntryDate2.ReadOnly = False
        cEntryDate2.DefaultCellStyle.BackColor = Color.Bisque

        cPrepareDate2.Name = "PrepareDate2"
        cPrepareDate2.HeaderText = "Prepare Date"
        cPrepareDate2.DataPropertyName = "PrepareDate2"
        cPrepareDate2.Width = 130
        cPrepareDate2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPrepareDate2.Visible = False
        cPrepareDate2.ReadOnly = False

        cUseDateFrom2.Name = "UseDateFrom2"
        cUseDateFrom2.HeaderText = "Use Date From"
        cUseDateFrom2.DataPropertyName = "UseDateFrom2"
        cUseDateFrom2.Width = 130
        cUseDateFrom2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUseDateFrom2.Visible = False
        cUseDateFrom2.ReadOnly = False

        cUseDateUntil2.Name = "UseDateUntil2"
        cUseDateUntil2.HeaderText = "Use Date Until"
        cUseDateUntil2.DataPropertyName = "UseDateUntil2"
        cUseDateUntil2.Width = 100
        cUseDateUntil2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUseDateUntil2.Visible = False
        cUseDateUntil2.ReadOnly = False

        cLine2.Name = "Line2"
        cLine2.HeaderText = "Line2"
        cLine2.DataPropertyName = "Line2"
        cLine2.Width = 100
        cLine2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLine2.Visible = False
        cLine2.ReadOnly = False

        cItem2.Name = "Item2"
        cItem2.HeaderText = "Item2"
        cItem2.DataPropertyName = "Item2"
        cItem2.Width = 100
        cItem2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem2.Visible = False
        cItem2.ReadOnly = False

        cQuantity2.Name = "Quantity2"
        cQuantity2.HeaderText = "Quantity2"
        cQuantity2.DataPropertyName = "Quantity2"
        cQuantity2.Width = 100
        cQuantity2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cQuantity2.Visible = False
        cQuantity2.ReadOnly = False

        cApprovedDateDept.Name = "ApprovedDateDept"
        cApprovedDateDept.HeaderText = "Approved Date KaDept"
        cApprovedDateDept.DataPropertyName = "ApprovedDateDept"
        cApprovedDateDept.Width = 150
        cApprovedDateDept.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cApprovedDateDept.Visible = True
        cApprovedDateDept.ReadOnly = False
        cApprovedDateDept.DefaultCellStyle.BackColor = Color.Bisque

        cRequest_approved1by.Name = "request_approved1by"
        cRequest_approved1by.HeaderText = "Approved KaDept By"
        cRequest_approved1by.DataPropertyName = "request_approved1by"
        cRequest_approved1by.Width = 200
        cRequest_approved1by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRequest_approved1by.Visible = True
        cRequest_approved1by.ReadOnly = False
        cRequest_approved1by.DefaultCellStyle.BackColor = Color.Bisque

        cApprovedDateDiv.Name = "ApprovedDateDiv"
        cApprovedDateDiv.HeaderText = "Approved Date KaDiv"
        cApprovedDateDiv.DataPropertyName = "ApprovedDateDiv"
        cApprovedDateDiv.Width = 150
        cApprovedDateDiv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cApprovedDateDiv.Visible = True
        cApprovedDateDiv.ReadOnly = False
        cApprovedDateDiv.DefaultCellStyle.BackColor = Color.Bisque

        cRequest_approved2by.Name = "request_approved2by"
        cRequest_approved2by.HeaderText = "Approved KaDiv By"
        cRequest_approved2by.DataPropertyName = "request_approved2by"
        cRequest_approved2by.Width = 200
        cRequest_approved2by.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRequest_approved2by.Visible = True
        cRequest_approved2by.ReadOnly = False
        cRequest_approved2by.DefaultCellStyle.BackColor = Color.Bisque

        cApprovedDateProc.Name = "ApprovedDateProc"
        cApprovedDateProc.HeaderText = "Date Procrument"
        cApprovedDateProc.DataPropertyName = "ApprovedDateProc"
        cApprovedDateProc.Width = 130
        cApprovedDateProc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cApprovedDateProc.Visible = True
        cApprovedDateProc.ReadOnly = False
        cApprovedDateProc.DefaultCellStyle.BackColor = Color.Pink

        cRequestdetil_approvedprocby.Name = "requestdetil_approvedprocby"
        cRequestdetil_approvedprocby.HeaderText = "Procurement By"
        cRequestdetil_approvedprocby.DataPropertyName = "requestdetil_approvedprocby"
        cRequestdetil_approvedprocby.Width = 200
        cRequestdetil_approvedprocby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRequestdetil_approvedprocby.Visible = True
        cRequestdetil_approvedprocby.ReadOnly = False
        cRequestdetil_approvedprocby.DefaultCellStyle.BackColor = Color.Pink

        cApprovedDateBMA.Name = "ApprovedDateBMA"
        cApprovedDateBMA.HeaderText = "Date BMA"
        cApprovedDateBMA.DataPropertyName = "ApprovedDateBMA"
        cApprovedDateBMA.Width = 130
        cApprovedDateBMA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cApprovedDateBMA.Visible = True
        cApprovedDateBMA.ReadOnly = False
        cApprovedDateBMA.DefaultCellStyle.BackColor = Color.Aquamarine

        cRequestdetil_approvedbmaby.Name = "requestdetil_approvedbmaby"
        cRequestdetil_approvedbmaby.HeaderText = "BMA By"
        cRequestdetil_approvedbmaby.DataPropertyName = "requestdetil_approvedbmaby"
        cRequestdetil_approvedbmaby.Width = 200
        cRequestdetil_approvedbmaby.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRequestdetil_approvedbmaby.Visible = True
        cRequestdetil_approvedbmaby.ReadOnly = False
        cRequestdetil_approvedbmaby.DefaultCellStyle.BackColor = Color.Aquamarine

        cPurchaseRentalOrder.Name = "PurchaseRentalOrder"
        cPurchaseRentalOrder.HeaderText = "No."
        cPurchaseRentalOrder.DataPropertyName = "PurchaseRentalOrder"
        cPurchaseRentalOrder.Width = 130
        cPurchaseRentalOrder.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPurchaseRentalOrder.Visible = True
        cPurchaseRentalOrder.ReadOnly = False
        cPurchaseRentalOrder.DefaultCellStyle.BackColor = Color.Gainsboro

        cEntryDate3.Name = "EntryDate3"
        cEntryDate3.HeaderText = "Entry Date"
        cEntryDate3.DataPropertyName = "EntryDate3"
        cEntryDate3.Width = 130
        cEntryDate3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEntryDate3.Visible = True
        cEntryDate3.ReadOnly = False
        cEntryDate3.DefaultCellStyle.BackColor = Color.Gainsboro

        cPrepareDate3.Name = "PrepareDate3"
        cPrepareDate3.HeaderText = "PrepareDate3"
        cPrepareDate3.DataPropertyName = "PrepareDate3"
        cPrepareDate3.Width = 100
        cPrepareDate3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cPrepareDate3.Visible = False
        cPrepareDate3.ReadOnly = False

        cUseDateFrom3.Name = "UseDateFrom3"
        cUseDateFrom3.HeaderText = "UseDateFrom3"
        cUseDateFrom3.DataPropertyName = "UseDateFrom3"
        cUseDateFrom3.Width = 100
        cUseDateFrom3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUseDateFrom3.Visible = False
        cUseDateFrom3.ReadOnly = False

        cUseDateUntil3.Name = "UseDateUntil3"
        cUseDateUntil3.HeaderText = "UseDateUntil3"
        cUseDateUntil3.DataPropertyName = "UseDateUntil3"
        cUseDateUntil3.Width = 100
        cUseDateUntil3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUseDateUntil3.Visible = False
        cUseDateUntil3.ReadOnly = False

        cLine3.Name = "Line3"
        cLine3.HeaderText = "Line3"
        cLine3.DataPropertyName = "Line3"
        cLine3.Width = 100
        cLine3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cLine3.Visible = False
        cLine3.ReadOnly = False

        cItem3.Name = "Item3"
        cItem3.HeaderText = "Item3"
        cItem3.DataPropertyName = "Item3"
        cItem3.Width = 100
        cItem3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cItem3.Visible = False
        cItem3.ReadOnly = False

        cQuantity3.Name = "Quantity3"
        cQuantity3.HeaderText = "Quantity3"
        cQuantity3.DataPropertyName = "Quantity3"
        cQuantity3.Width = 100
        cQuantity3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cQuantity3.Visible = False
        cQuantity3.ReadOnly = False

        cVendor.Name = "Vendor"
        cVendor.HeaderText = "Vendor"
        cVendor.DataPropertyName = "Vendor"
        cVendor.Width = 200
        cvendor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cVendor.Visible = True
        cVendor.ReadOnly = False
        cVendor.DefaultCellStyle.BackColor = Color.Gainsboro

        cCirculation_id.Name = "circulation_id"
        cCirculation_id.HeaderText = "Document by."
        cCirculation_id.DataPropertyName = "circulation_id"
        cCirculation_id.Width = 130
        cCirculation_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_id.Visible = True
        cCirculation_id.ReadOnly = False
        cCirculation_id.DefaultCellStyle.BackColor = Color.White

        cCirculation_receceived_date.Name = "circulation_receceived_date1"
        cCirculation_receceived_date.HeaderText = "Doc.Received Date"
        cCirculation_receceived_date.DataPropertyName = "circulation_receceived_date1"
        cCirculation_receceived_date.Width = 130
        cCirculation_receceived_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCirculation_receceived_date.Visible = True
        cCirculation_receceived_date.ReadOnly = False
        cCirculation_receceived_date.DefaultCellStyle.BackColor = Color.White

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "BPJ No."
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 130
        cTerimabarang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = False
        cTerimabarang_id.DefaultCellStyle.BackColor = Color.Lavender

        cTerimabarang_tgl.Name = "terimabarang_tgl"
        cTerimabarang_tgl.HeaderText = "Entry Date"
        cTerimabarang_tgl.DataPropertyName = "terimabarang_tgl"
        cTerimabarang_tgl.Width = 130
        cTerimabarang_tgl.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_tgl.Visible = True
        cTerimabarang_tgl.ReadOnly = False
        cTerimabarang_tgl.DefaultCellStyle.BackColor = Color.Lavender

        cApprovedUser.Name = "ApprovedUser"
        cApprovedUser.HeaderText = "ApprovedUser"
        cApprovedUser.DataPropertyName = "ApprovedUser"
        cApprovedUser.Width = 100
        cApprovedUser.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cApprovedUser.Visible = False
        cApprovedUser.ReadOnly = False

        cUser_applogin.Name = "user_applogin"
        cUser_applogin.HeaderText = "user_applogin"
        cUser_applogin.DataPropertyName = "user_applogin"
        cUser_applogin.Width = 100
        cUser_applogin.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cUser_applogin.Visible = False
        cUser_applogin.ReadOnly = False

        cApprovedSPV.Name = "ApprovedSPV"
        cApprovedSPV.HeaderText = "Approved Spv"
        cApprovedSPV.DataPropertyName = "ApprovedSPV"
        cApprovedSPV.Width = 130
        cApprovedSPV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cApprovedSPV.Visible = True
        cApprovedSPV.ReadOnly = False
        cApprovedSPV.DefaultCellStyle.BackColor = Color.Lavender

        cProcurement_applogin.Name = "procurement_applogin"
        cProcurement_applogin.HeaderText = "Spv By"
        cProcurement_applogin.DataPropertyName = "procurement_applogin"
        cProcurement_applogin.Width = 200
        cProcurement_applogin.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cProcurement_applogin.Visible = True
        cProcurement_applogin.ReadOnly = False
        cProcurement_applogin.DefaultCellStyle.BackColor = Color.Lavender

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cGoodsRequest, cDepartment, cAcara, cItem1, cEntryDate1, cPrepareDate1, cUseDateFrom1, cUseDateUntil1, _
        cLine1, cQuantity1, cApprovedDateSpv, cApprovedSpvBy, _
        cCirculation_GR, cCirculation_receceived_date_GQ, cPurchaseRentalRequest, cEntryDate2, cPrepareDate2, cUseDateFrom2, _
        cUseDateUntil2, cLine2, cItem2, cQuantity2, cApprovedDateDept, _
        cRequest_approved1by, cApprovedDateDiv, cRequest_approved2by, _
        cApprovedDateProc, cRequestdetil_approvedprocby, cApprovedDateBMA, _
        cRequestdetil_approvedbmaby, cPurchaseRentalOrder, cEntryDate3, cPrepareDate3, _
        cUseDateFrom3, cUseDateUntil3, cLine3, cItem3, cQuantity3, cVendor, cCirculation_id, _
        cCirculation_receceived_date, cCirculation_OrderDel_by, cCirculation_OrderDel_date, cTerimabarang_id, cTerimabarang_tgl, _
        cApprovedUser, cUser_applogin, cApprovedSPV, cProcurement_applogin})

        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If Me.tbl_tracking_search.Rows.Count <> 0 Then
            If Mid(Me.TextBox1.Text, 1, 2) = "GQ" Then
                Me.tbl_tracking_search.DefaultView.RowFilter = " GoodsRequest like '%" & Me.TextBox1.Text & "%'"
            ElseIf Mid(Me.TextBox1.Text, 1, 2) = "RQ" Then
                Me.tbl_tracking_search.DefaultView.RowFilter = " PurchaseRentalRequest like '%" & Me.TextBox1.Text & "%'"
            ElseIf Mid(Me.TextBox1.Text, 1, 2) = "RO" Then
                Me.tbl_tracking_search.DefaultView.RowFilter = " PurchaseRentalOrder like '%" & Me.TextBox1.Text & "%'"
            ElseIf Mid(Me.TextBox1.Text, 1, 2) = "RV" Then
                Me.tbl_tracking_search.DefaultView.RowFilter = " terimabarang_id like '%" & Me.TextBox1.Text & "%'"
            ElseIf Mid(Me.TextBox1.Text, 1, 2) = "CR" Then
                Me.tbl_tracking_search.DefaultView.RowFilter = " circulation_id like '%" & Me.TextBox1.Text & "%'"
            ElseIf LTrim(Me.TextBox1.Text) = "" Then
                Me.tbl_tracking_search.DefaultView.RowFilter = ""
            Else
                Me.tbl_tracking_search.DefaultView.RowFilter = " circulation_id like '%" & Me.TextBox1.Text & "%'"
            End If

            Me.Label18.Text = Me.DgvSearch.Rows.Count & " Data"
        Else
            MsgBox("No Data")
        End If
    End Sub

#End Region

#Region " untuk tab Preview "
    Private Sub chkSearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearch.CheckedChanged
        If chkSearch.Checked = True Then
            Me.obj_tracking_search.ReadOnly = False
        Else
            Me.obj_tracking_search.ReadOnly = True
            Me.obj_tracking_search.Text = String.Empty
        End If
    End Sub
    Private Sub cbo_rekap_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_rekap.SelectedValueChanged
        Me.ComboBox1.Items.Clear()
        If Me.cbo_rekap.SelectedItem = "Entry Goods Request" Then
            Me.chkSearch.Checked = False
            Me.chkSearch.Enabled = False
            Me.obj_tracking_search.ReadOnly = True
            Me.obj_tracking_search.Text = String.Empty
            Me.ComboBox1.Enabled = True
            Me.ComboBox1.Items.Add("All")
            Me.ComboBox1.Items.Add("Day < 0")
            Me.ComboBox1.Items.Add("Day between 0 to 2")
            Me.ComboBox1.Items.Add("Day = 3")
            Me.ComboBox1.Items.Add("Day = 4")
            Me.ComboBox1.Items.Add("Day = 5")
            Me.ComboBox1.Items.Add("Day > 5")

            Me.ComboBox1.SelectedItem = "Day < 0"
            Me.CheckBox1.Checked = True

        ElseIf Me.cbo_rekap.SelectedItem = "Order to Bpj" Then
            Me.ComboBox1.Enabled = True
            Me.ComboBox1.Items.Add("All")
            Me.ComboBox1.Items.Add("Nothing Document, Have Bpj")
            Me.ComboBox1.Items.Add("Nothing Document, Nothing Bpj")
            Me.ComboBox1.Items.Add("Have Document, Have Bpj")
            Me.ComboBox1.Items.Add("Have Document, Nothing Bpj")

            Me.ComboBox1.SelectedItem = "Nothing Document, Have Bpj"
            Me.CheckBox1.Checked = True

        Else
            Me.ComboBox1.Text = String.Empty
            Me.chkSearch.Enabled = True
            Me.ComboBox1.Enabled = False
            Me.CheckBox1.Checked = False
        End If
    End Sub
    Private Sub uiTrackingGoodRequestToBpj_PrintPreview()
        Dim criteria As String = String.Empty
        If Me.cbo_rekap.SelectedItem = "No" Then
            If Me.chkSearch.Checked = True Then
                If Mid(Me.obj_tracking_search.Text, 1, 2) = "GQ" Then
                    criteria = String.Format(" GoodsRequest = '{0}'", Me.obj_tracking_search.Text)
                ElseIf Mid(Me.obj_tracking_search.Text, 1, 2) = "RQ" Then
                    criteria = String.Format(" PurchaseRentalRequest = '{0}'", Me.obj_tracking_search.Text)
                ElseIf Mid(Me.obj_tracking_search.Text, 1, 2) = "RO" Then
                    criteria = String.Format(" PurchaseRentalOrder = '{0}'", Me.obj_tracking_search.Text)
                ElseIf Mid(Me.obj_tracking_search.Text, 1, 2) = "RV" Then
                    criteria = String.Format(" terimabarang_id = '{0}'", Me.obj_tracking_search.Text)
                ElseIf Mid(Me.obj_tracking_search.Text, 1, 2) = "CR" Then
                    criteria = String.Format(" circulation_id = '{0}'", Me.obj_tracking_search.Text)
                Else
                    criteria = String.Empty
                End If
            End If
        ElseIf Me.cbo_rekap.SelectedItem = "Entry Goods Request" Then
            If Me.ComboBox1.SelectedItem = "Day < 0" Then
                criteria = " datediff(day,EntryDate1,PrepareDate1) < 0 "
            ElseIf Me.ComboBox1.SelectedItem = "Day between 0 to 2" Then
                criteria = " datediff(day,EntryDate1,PrepareDate1) >= 0 AND datediff(day, EntryDate1, PrepareDate1) < 3 "
            ElseIf Me.ComboBox1.SelectedItem = "Day = 3" Then
                criteria = " datediff(day,EntryDate1,PrepareDate1) = 3 "
            ElseIf Me.ComboBox1.SelectedItem = "Day = 4" Then
                criteria = " datediff(day,EntryDate1,PrepareDate1) = 4 "
            ElseIf Me.ComboBox1.SelectedItem = "Day = 5" Then
                criteria = " datediff(day,EntryDate1,PrepareDate1) = 5 "
            ElseIf Me.ComboBox1.SelectedItem = "Day > 5" Then
                criteria = " datediff(day,EntryDate1,PrepareDate1) > 5 "
            Else
                criteria = String.Empty
            End If
        Else
            If Me.ComboBox1.SelectedItem = "Nothing Document, Have Bpj" Then
                criteria = " LTRIM(PurchaseRentalOrder) <> '' AND circulation_id is NULL AND terimabarang_id is NOT NULL "
            ElseIf Me.ComboBox1.SelectedItem = "Nothing Document, Nothing Bpj" Then
                criteria = " LTRIM(PurchaseRentalOrder) <> '' AND circulation_id is NULL AND terimabarang_id is NULL "
            ElseIf Me.ComboBox1.SelectedItem = "Have Document, Have Bpj" Then
                criteria = " LTRIM(PurchaseRentalOrder) <> '' AND circulation_id is NOT NULL AND terimabarang_id is NOT NULL "
            ElseIf Me.ComboBox1.SelectedItem = "Have Document, Nothing Bpj" Then
                criteria = " LTRIM(PurchaseRentalOrder) <> '' AND circulation_id is NOT NULL AND terimabarang_id is NULL "
            Else
                criteria = String.Empty
            End If


        End If
        If Me.chkSearchStrukturunit_ID.Checked = True Then
            If criteria = String.Empty Then
                criteria = String.Format(" Department = {0} ", Me.cboSearchStrukturunit_ID.SelectedValue)
            Else
                criteria &= String.Format(" AND Department = {0} ", Me.cboSearchStrukturunit_ID.SelectedValue)
            End If
        End If


        criteria &= " AND LEFT(PurchaseRentalOrder,2) = 'RO'"
        Me.tbl_tracking.Clear()
        Try
            If Me.cbo_rekap.SelectedItem = "No" Then
                Me.DataFill(Me.tbl_tracking, "as_GoodRequest_to_Bpj_Tracking_Select", criteria)
            Else
                Me.DataFill(Me.tbl_tracking, "as_GoodRequest_to_Bpj_TrackingRekap_Select", criteria)
            End If

            If Me.cbo_rekap.SelectedItem = "Entry Goods Request" Then
                Dim tabl As DataTable = New DataTable
                tabl.Clear()
                If Me.ComboBox1.SelectedItem = "All" Then
                    Me.DataFill(tabl, "as_GoodRequest_to_Bpj_Tracking_EntryCount_Select", "All")
                    Me.jmlh_data_dayLess0 = tabl.Rows(0).Item("jmlh")
                    Me.jmlh_data_day0to2 = tabl.Rows(1).Item("jmlh")
                    Me.jmlh_data_day3 = tabl.Rows(2).Item("jmlh")
                    Me.jmlh_data_day4 = tabl.Rows(3).Item("jmlh")
                    Me.jmlh_data_day5 = tabl.Rows(4).Item("jmlh")
                    Me.jmlh_data_greater5 = tabl.Rows(5).Item("jmlh")

                Else
                    Me.DataFill(tabl, "as_GoodRequest_to_Bpj_Tracking_EntryCount_Select", "Once")
                    Me.jmlh_data_all = tabl.Rows(0).Item("jmlh")
                End If
            End If

            If Me.cbo_rekap.SelectedItem = "Order to Bpj" Then
                Dim tabl As DataTable = New DataTable
                tabl.Clear()
                If Me.ComboBox1.SelectedItem = "All" Then
                    Me.DataFill(tabl, "as_GoodRequest_to_Bpj_Tracking_RoBpjCount_Select", "All")
                    Me.jmlh_data_dayLess0 = tabl.Rows(0).Item("jmlh")
                    Me.jmlh_data_day0to2 = tabl.Rows(1).Item("jmlh")
                    Me.jmlh_data_day3 = tabl.Rows(2).Item("jmlh")
                    Me.jmlh_data_day4 = tabl.Rows(3).Item("jmlh")
                Else
                    Me.DataFill(tabl, "as_GoodRequest_to_Bpj_Tracking_RoBpjCount_Select", "Once")
                    Me.jmlh_data_all = tabl.Rows(0).Item("jmlh")
                End If
            End If

            GenerateReport()
            Me.RvSearch.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function GenerateReport() As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)
        Dim parRptname_report As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("name_report", Me.ComboBox1.Text)
        Dim parRptDay1 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("day1", Me.jmlh_data_dayLess0)
        Dim parRptDay2 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("day2", Me.jmlh_data_day0to2)
        Dim parRptDay3 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("day3", Me.jmlh_data_day3)
        Dim parRptDay4 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("day4", Me.jmlh_data_day4)
        Dim parRptDay5 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("day5", Me.jmlh_data_day5)
        Dim parRptDay6 As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("day6", Me.jmlh_data_greater5)

        objDatalistHeader = Me.GenerateDataHeader()
        Dim parRptJumlahData As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jumlah_data", Me.jumlah_data)
        Dim parRptJmlh_data_All As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jmlh_data_all", Me.jmlh_data_all)


        objRdsH.Name = "ASSET_DataSource_clsRptGoodRequestToBpj_Tracking"
        objRdsH.Value = objDatalistHeader
        If Me.cbo_rekap.SelectedItem = "Entry Goods Request" Then
            objReportH.ReportEmbeddedResource = "ASSET.RptGoodRequestToBpj_Tracking_EntryGR.rdlc"
        ElseIf Me.cbo_rekap.SelectedItem = "Order to Bpj" Then
            objReportH.ReportEmbeddedResource = "ASSET.RptGoodRequestToBpj_Tracking_RoToBpj.rdlc"
        Else
            objReportH.ReportEmbeddedResource = "ASSET.RptGoodRequestToBpj_Tracking.rdlc"
        End If
        objReportH.DataSources.Add(objRdsH)

        'AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "RvSearch"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        If Me.cbo_rekap.SelectedItem = "Entry Goods Request" Then
            objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptJumlahData, parRptJmlh_data_All, parRptname_report, parRptDay1, parRptDay2, parRptDay3, parRptDay4, parRptDay5, parRptDay6})
        ElseIf Me.cbo_rekap.SelectedItem = "Order to Bpj" Then
            objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptJumlahData, parRptJmlh_data_All, parRptname_report, parRptDay1, parRptDay2, parRptDay3, parRptDay4})
        Else
            objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})
        End If
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.PnlDfMain.SuspendLayout()
        Me.PnlDfMain.Controls.Remove(Me.RvSearch)
        'Me.SuspendLayout()
        'Me.Controls.Remove(Me.RvSearch)

        Me.RvSearch = Nothing
        Me.RvSearch = objReportViewer
        Me.RvSearch.LocalReport.EnableExternalImages = True

        'Me.Controls.Add(Me.RvSearch)
        'Me.ResumeLayout()
        'Me.RvSearch.Dock = DockStyle.Fill

        Me.PnlDfMain.Controls.Add(Me.RvSearch)
        Me.PnlDfMain.ResumeLayout()
        Me.RvSearch.Dock = DockStyle.Fill
    End Function
    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptGoodRequestToBpj_Tracking
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer
        Me.jumlah_data = Me.tbl_tracking.Rows.Count
        If Me.ComboBox1.SelectedItem = "All" Then
            Me.jmlh_data_all = Me.jumlah_data
        End If
        For i = 0 To jumlah_data - 1
            'GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptGoodRequestToBpj_Tracking(Me.DSN)
            With objPrintHeader
                .GoodsRequest = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("GoodsRequest").ToString, String.Empty)
                .Department = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("Department"), 0)
                .EntryDate1 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("EntryDate1"), Nothing)
                .PrepareDate1 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("PrepareDate1"), Nothing)
                .UseDateFrom1 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("UseDateFrom1"), Nothing)
                .UseDateUntil1 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("UseDateUntil1"), Nothing)
                .Line1 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("Line1"), 0)
                .Item1 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("Item1").ToString, String.Empty)
                .Quantity1 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("Quantity1"), 0)
                .ApprovedDateSpv = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("ApprovedDateSpv"), Nothing)
                .ApprovedSpvBy = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("ApprovedSpvBy").ToString, String.Empty)
                .circulation_GR_date = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("circulation_GR_date"), Nothing)
                .circulation_GR_by = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("circulation_GR_by").ToString, String.Empty)
                .PurchaseRentalRequest = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("PurchaseRentalRequest").ToString, String.Empty)
                .acara = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("acara").ToString, String.Empty)
                .EntryDate2 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("EntryDate2"), Nothing)
                .PrepareDate2 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("PrepareDate2"), Nothing)
                .UseDateFrom2 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("UseDateFrom2"), Nothing)
                .UseDateUntil2 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("UseDateUntil2"), Nothing)
                .Line2 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("Line2"), 0)
                .Item2 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("Item2").ToString, String.Empty)
                .Quantity2 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("Quantity2"), 0)
                .ApprovedDateDept = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("ApprovedDateDept"), Nothing)
                .request_approved1by = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("request_approved1by").ToString, String.Empty)
                .ApprovedDateDiv = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("ApprovedDateDiv"), Nothing)
                .request_approved2by = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("request_approved2by").ToString, String.Empty)
                .ApprovedDateProc = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("ApprovedDateProc"), Nothing)
                .requestdetil_approvedprocby = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("requestdetil_approvedprocby").ToString, String.Empty)
                .ApprovedDateBMA = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("ApprovedDateBMA"), Nothing)

                .requestdetil_approvedbmaby = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("requestdetil_approvedbmaby").ToString, String.Empty)
                .PurchaseRentalOrder = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("PurchaseRentalOrder").ToString, String.Empty)
                .EntryDate3 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("EntryDate3"), Nothing)
                .PrepareDate3 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("PrepareDate3"), Nothing)
                .UseDateFrom3 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("UseDateFrom3"), Nothing)
                .UseDateUntil3 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("UseDateUntil3"), Nothing)
                .Line3 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("Line3"), 0)
                .Item3 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("Item3").ToString, String.Empty)
                .Quantity3 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("Quantity3"), 0)
                .circulation_id = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("circulation_id").ToString, String.Empty)
                .circulation_receceived_date1 = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("circulation_receceived_date1"), Nothing)
                .orderDelivery_date = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("orderDelivery_date"), Nothing)
                .orderDelivery_by = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("orderDelivery_by"), String.Empty)
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                .terimabarang_tgl = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("terimabarang_tgl"), Nothing)
                .ApprovedUser = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("ApprovedUser"), Nothing)
                .user_applogin = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("user_applogin").ToString, String.Empty)
                .ApprovedSPV = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("ApprovedSPV"), Nothing)
                .procurement_applogin = clsUtil.IsDbNull(Me.tbl_tracking.Rows(i).Item("procurement_applogin").ToString, String.Empty)
            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function
#End Region

End Class
