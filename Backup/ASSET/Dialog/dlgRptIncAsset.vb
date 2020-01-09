Public Class dlgRptIncAsset
    Private DSN As String
    Private sptServer As String
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnIncasset
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnIncassetDetil
    Private criteria As String
    Private objDatalistDetil As ArrayList
    Private user As String
    Private _CHANNEL As String
    Private incasset_id As String
    Private tempChannel_ID As String
    Private tempChannel_nameReport As String
    Private tempChannel_address As String
    Private tempIncAssetID As String
    Private tempStrukturUnit As String

    Private Sub dlgRptIncAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtFiller.DataFill(Me.tbl_Print, "as_TrnIncasset_Select", criteria, Me._CHANNEL, Me.top)
        criteria = " incasset_id = '" & incasset_id & "'"
        dtFiller.DataFill(Me.tbl_PrintDetil, "as_TrnIncassetdetil_Select", criteria)

        GenerateReport()
        Me.rvIncAsset.RefreshReport()
    End Sub

    Private Function GenerateReport() As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.sptServer)
        Dim parRptUsername As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("username", Me.user)

        objDatalistHeader = Me.GenerateDataHeader()

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.tempChannel_ID)
        Dim parRptChannel_nameReport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.tempChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.tempChannel_address)
        Dim parRptIncAssetID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("incAsset", Me.tempIncAssetID)
        Dim parRptStrukturUnit As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("strukturUnit", Me.tempStrukturUnit)

        objRdsH.Name = "ASSET_DataSource_clsRptIncAsset"
        objRdsH.Value = objDatalistHeader
        objReportH.ReportEmbeddedResource = "ASSET.RptIncAsset.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "rvIncAsset"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptUsername, parRptChannelID, parRptChannel_nameReport, parRptChannel_address, parRptIncAssetID, parRptStrukturUnit})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.rvIncAsset)

        Me.rvIncAsset = Nothing
        Me.rvIncAsset = objReportViewer
        Me.rvIncAsset.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.rvIncAsset)
        Me.ResumeLayout()
        Me.rvIncAsset.Dock = DockStyle.Fill
    End Function
    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptIncAsset
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptIncAsset(Me.DSN, Me.top)
            With objPrintHeader
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id"), String.Empty)
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), String.Empty)
                .incasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("incasset_id"), String.Empty)
                .outasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_id"), String.Empty)
                .bookasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_id"), String.Empty)
                .incasset_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("incasset_status"), String.Empty)
                .outasset_startdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_startdt"), Now)
                .outasset_enddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_enddt"), Now)
                .incasset_actreturn = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("incasset_actreturn"), Now)
                .outasset_item = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_item"), 0)
                .incasset_returnitem = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("incasset_returnitem"), 0)
                .employee_id_returnby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_returnby"), String.Empty)
                .strukturunit_id_returnby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_returnby"), String.Empty)
                .username_inputby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("username_inputby"), String.Empty)
                .incasset_inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("incasset_inputdt"), Now)
                .inasset_remark = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("inasset_remark"), String.Empty)
                .inasset_logistik = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("inasset_logistik"), String.Empty)
                .inasset_lock = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("inasset_lock"), 0)

                Me.tempChannel_ID = .channel_id
                Me.tempChannel_nameReport = .channel_namereport
                Me.tempChannel_address = .channel_address
                Me.tempIncAssetID = .incasset_id
                Me.tempStrukturUnit = .Strukturunit_id_nameReport

            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptIncAssetDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptIncAssetDetil(Me.DSN)
            With objDetil
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id"), String.Empty)
                .incasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("incasset_id"), String.Empty)
                .line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("line"), 0)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcode"), String.Empty)
                .qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("qty"), 0)
                .is_useable = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("is_useable"), 0)
                .asset_status = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_status"), String.Empty)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptIncAssetDetil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, ByVal user As String, ByVal strChannel As String, ByVal strIncasset_id As String)
        DSN = strDSN
        Me.sptServer = sptServer
        Me.Top = Top
        Me.user = user
        Me._CHANNEL = strChannel
        Me.incasset_id = strIncasset_id
        InitializeComponent()
    End Sub
End Class

