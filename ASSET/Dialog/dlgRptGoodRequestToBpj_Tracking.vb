Public Class dlgRptGoodRequestToBpj_Tracking
    Private DSN As String
    Private sptServer As String
    Private tbl_Print As DataTable = clsDataset.CreateTblViewTrackingGoodRequestToBpj
    'Private tbl_PrintDetil As DataTable = clsDataset.
    Private criteria As String
    Private objDatalistDetil As ArrayList

    Private Sub dlgRptGoodRequestToBpj_Tracking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        'dtFiller.DataFill(Me.tbl_Print, "as_GoodRequest_to_Bpj_Tracking_Select", criteria)
        'dtFiller.DataFill(Me.tbl_PrintDetil, "", criteria)

        GenerateReport()
        Me.RvSearch.RefreshReport()
    End Sub

    Private Function GenerateReport() As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.sptServer)

        objDatalistHeader = Me.GenerateDataHeader()
        objRdsH.Name = "ASSET_DataSource_clsRptGoodRequestToBpj_Tracking"
        objRdsH.Value = objDatalistHeader
        objReportH.ReportEmbeddedResource = "ASSET.RptGoodRequestToBpj_Tracking.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "RvSearch"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.RvSearch)

        Me.RvSearch = Nothing
        Me.RvSearch = objReportViewer
        Me.RvSearch.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.RvSearch)
        Me.ResumeLayout()
        Me.RvSearch.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptGoodRequestToBpj_Tracking
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            'GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptGoodRequestToBpj_Tracking(Me.DSN)
            With objPrintHeader
                .GoodsRequest = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("GoodsRequest").ToString, String.Empty)
                .Department = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Department"), 0)
                .EntryDate1 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("EntryDate1"), Nothing)
                .PrepareDate1 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("PrepareDate1"), Nothing)
                .UseDateFrom1 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("UseDateFrom1"), Nothing)
                .UseDateUntil1 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("UseDateUntil1"), Nothing)
                .Line1 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Line1"), 0)
                .Item1 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Item1").ToString, String.Empty)
                .Quantity1 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Quantity1"), 0)
                .ApprovedDateSpv = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("ApprovedDateSpv"), Nothing)
                .ApprovedSpvBy = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("ApprovedSpvBy").ToString, String.Empty)
                .circulation_GR_date = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("circulation_GR").ToString, String.Empty)
                .circulation_GR_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("circulation_receceived_date_GQ"), Nothing)
                .PurchaseRentalRequest = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("PurchaseRentalRequest").ToString, String.Empty)
                .acara = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("acara").ToString, String.Empty)
                .EntryDate2 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("EntryDate2"), Nothing)
                .PrepareDate2 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("PrepareDate2"), Nothing)
                .UseDateFrom2 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("UseDateFrom2"), Nothing)
                .UseDateUntil2 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("UseDateUntil2"), Nothing)
                .Line2 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Line2"), 0)
                .Item2 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Item2").ToString, String.Empty)
                .Quantity2 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Quantity2"), 0)
                .ApprovedDateDept = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("ApprovedDateDept"), Nothing)
                .request_approved1by = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("request_approved1by").ToString, String.Empty)
                .ApprovedDateDiv = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("ApprovedDateDiv"), Nothing)
                .request_approved2by = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("request_approved2by").ToString, String.Empty)
                .ApprovedDateProc = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("ApprovedDateProc"), Nothing)
                .requestdetil_approvedprocby = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("requestdetil_approvedprocby").ToString, String.Empty)
                .ApprovedDateBMA = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("ApprovedDateBMA"), Nothing)
                
                .requestdetil_approvedbmaby = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("requestdetil_approvedbmaby").ToString, String.Empty)
                .PurchaseRentalOrder = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("PurchaseRentalOrder").ToString, String.Empty)
                .EntryDate3 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("EntryDate3"), Nothing)
                .PrepareDate3 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("PrepareDate3"), Nothing)
                .UseDateFrom3 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("UseDateFrom3"), Nothing)
                .UseDateUntil3 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("UseDateUntil3"), Nothing)
                .Line3 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Line3"), 0)
                .Item3 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Item3").ToString, String.Empty)
                .Quantity3 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Quantity3"), 0)
                .circulation_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("circulation_id").ToString, String.Empty)
                .circulation_receceived_date1 = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("circulation_receceived_date1"), Nothing)
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                .terimabarang_tgl = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimabarang_tgl"), Nothing)
                .ApprovedUser = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("ApprovedUser"), Nothing)
                .user_applogin = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("user_applogin").ToString, String.Empty)
                .ApprovedSPV = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("ApprovedSPV"), Nothing)
                .procurement_applogin = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("procurement_applogin").ToString, String.Empty)
            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    'Private Sub GenerateDataDetail()
    '  Dim objDetil As DataSource.
    '    Dim i As Integer

    '    objDatalistDetil = New ArrayList()
    '    For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
    '     objDetil = New DataSource.(Me.DSN)
    '        With objDetil
    '        End With
    '        objDatalistDetil.Add(objDetil)
    '    Next
    'End Sub

    'Public Function SetIDCriteria(ByVal str As String) As Boolean
    '    Me.criteria = str
    'End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, _
        ByVal tbl_temps As DataTable)
        DSN = strDSN
        Me.sptServer = sptServer
        Me.tbl_Print = tbl_temps

        InitializeComponent()
    End Sub
End Class

