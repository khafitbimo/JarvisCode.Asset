Public Class dlgRptBookasset
    Private DSN As String
    Private sptServer As String
    Private channel As String
    Private Shadows top As Integer
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnBookasset
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnBookassetdetilView
    Private criteria As String
    Private objDatalistDetil As ArrayList
    Private bookAsset_ID As String

    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptBookAsset_ID As String
    Private sptStrukturUnit As String

    Private Sub dlgRptBookasset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtFiller.DataFill(Me.tbl_Print, "as_TrnBookasset_Select", criteria, Me.channel, Me.top)
        criteria = " bookasset_id = '" & bookAsset_ID & "'"
        dtFiller.DataFill(Me.tbl_PrintDetil, "as_TrnBookassetDetilView_Select", criteria)

        GenerateReport()
        Me.RvBookasset.RefreshReport()
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

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.sptChannel_ID)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_namereport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptBookAsset_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("bookAssetID", Me.sptBookAsset_ID)
        Dim parRptStrukturUnit As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("strukturUnit", Me.sptStrukturUnit)

        objRdsH.Name = "ASSET_DataSource_clsRptTrnBookasset"
        objRdsH.Value = objDatalistHeader
        objReportH.ReportEmbeddedResource = "ASSET.RptBookasset.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "RvBookasset"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptBookAsset_ID, parRptStrukturUnit})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.RvBookasset)

        Me.RvBookasset = Nothing
        Me.RvBookasset = objReportViewer
        Me.RvBookasset.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.RvBookasset)
        Me.ResumeLayout()
        Me.RvBookasset.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptTrnBookasset
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptTrnBookasset(Me.DSN)
            With objPrintHeader
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id"), String.Empty)
                .bookasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_id"), String.Empty)
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), 0)
                .bookasset_startdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_startdt"), String.Empty)
                .bookasset_enddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_enddt"), String.Empty)
                .bookasset_starttm = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_starttm"), String.Empty)
                .bookasset_endtm = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_endtm"), String.Empty)
                .employee_id_bookby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_bookby"), String.Empty)
                .struktur_unit_bookby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("struktur_unit_bookby"), 0)
                .employee_id_customerhead = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_customerhead"), String.Empty)
                .bookasset_item = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_item"), 0)
                .budget_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("budget_id"), 0)
                .show_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_id"), String.Empty)
                .show_epsnumber_st = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_epsnumber_st"), String.Empty)
                .show_epsnumber_ed = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_epsnumber_ed"), String.Empty)
                .username_inputby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("username_inputby"), String.Empty)
                .bookasset_inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_inputdt"), String.Empty)
                .bookasset_active = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_active"), String.Empty)
                .outasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_id"), String.Empty)
                .bookasset_remark = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_remark"), String.Empty)
                .bookasset_purpose = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_purpose"), String.Empty)

                Me.sptChannel_ID = .channel_id
                Me.sptChannel_nameReport = .channel_namereport
                Me.sptChannel_address = .channel_address
                Me.sptBookAsset_ID = .bookasset_id
                Me.sptStrukturUnit = .strukturunit_name

            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptTrnBookassetDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptTrnBookassetDetil(Me.DSN)
            With objDetil
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id"), String.Empty)
                .bookasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("bookasset_id"), String.Empty)
                .line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("line"), 0)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcode"), String.Empty)
                .sn = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("sn"), String.Empty)
                .desk = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("desk"), String.Empty)
                .tipe = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("tipe"), String.Empty)
                .brand = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand"), String.Empty)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptTrnBookassetDetil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, ByVal channel As String, ByVal top As Integer, ByVal strBookAsset_id As String)
        DSN = strDSN
        Me.sptServer = sptServer
        Me.channel = channel
        Me.top = top
        Me.bookAsset_ID = strBookAsset_id

        InitializeComponent()
    End Sub
End Class