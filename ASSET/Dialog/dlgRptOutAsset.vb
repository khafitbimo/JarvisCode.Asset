Public Class dlgRptOutAsset
    Private DSN As String
    Private sptServer As String
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnOutasset
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnOutassetDetil
    Private criteria As String
    Private objDatalistDetil As ArrayList
    Private Shadows top As Integer
    Private user As String
    Private _CHANNEL As String ' = "TTV"
    Private outasset_id As String

    Private tempChannel_ID As String
    Private tempChannel_nameReport As String
    Private tempChannel_address As String
    Private tempOutAssetID As String
    Private tempStrukturUnit As String

    Private Sub dlgRptOutAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtFiller.DataFill(Me.tbl_Print, "as_TrnOutasset_Select", criteria, Me._CHANNEL, Me.top)
        criteria = " outasset_id = '" & outasset_id & "'"
        dtFiller.DataFill(Me.tbl_PrintDetil, "as_TrnOutassetdetil_Select", criteria)

        GenerateReport()
        Me.rvOutAsset.RefreshReport()
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
        Dim parRptOutAssetID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("outAsset", Me.tempOutAssetID)
        Dim parRptStrukturUnit As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("strukturUnit", Me.tempStrukturUnit)

        objRdsH.Name = "ASSET_DataSource_clsRptOutAsset"
        objRdsH.Value = objDatalistHeader
        objReportH.ReportEmbeddedResource = "ASSET.RptOutAsset.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "rvOutAsset"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptUsername, parRptChannelID, parRptChannel_nameReport, parRptChannel_address, parRptOutAssetID, parRptStrukturUnit})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.rvOutAsset)

        Me.rvOutAsset = Nothing
        Me.rvOutAsset = objReportViewer
        Me.rvOutAsset.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.rvOutAsset)
        Me.ResumeLayout()
        Me.rvOutAsset.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptOutAsset
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptOutAsset(Me.DSN, Me.top)
            With objPrintHeader
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id"), String.Empty)
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), 0)
                .outasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_id"), String.Empty)
                .bookasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_id"), String.Empty)
                .outasset_startdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_startdt"), String.Empty)
                .outasset_enddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_enddt"), String.Empty)
                .outasset_starttm = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_starttm"), String.Empty)
                .outasset_endtm = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_endtm"), String.Empty)
                .employee_id_customer = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_customer"), String.Empty)
                .strukturunit_id_customer = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_customer"), 0)
                .employee_id_customerhead = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_customerhead"), String.Empty)
                .outasset_item = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_item"), 0)
                .project_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("project_id"), 0)
                .show_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_id"), String.Empty)
                .show_epsnumber_st = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_epsnumber_st"), String.Empty)
                .show_epsnumber_ed = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_epsnumber_ed"), String.Empty)
                '.outasset_lock = Me.tbl_Print.Rows(0).Item("outasset_lock").ToString
                .outasset_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_status"), String.Empty)
                .outasset_remark = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_remark"), String.Empty)
                .employee = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_logistik"), String.Empty)
                .outasset_inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_inputdt"), String.Empty)
                .outasset_inputtm = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_inputdt"), String.Empty)
                .outasset_purpose = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_purpose"), String.Empty)

                Me.tempChannel_ID = .channel_id
                Me.tempChannel_nameReport = .channel_namereport
                Me.tempChannel_address = .channel_address
                Me.tempOutAssetID = .outasset_id
                Me.tempStrukturUnit = .Strukturunit_id_nameReport
            End With

            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptOutAssetDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptOutAssetDetil(Me.DSN)
            With objDetil
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id"), String.Empty)
                .outasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("outasset_id"), String.Empty)
                .outasset_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("outasset_line"), 0)
                .barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("barcode"), String.Empty)
                .qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("qty"), 0)
                .is_useable = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("is_useable"), 0)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptOutAssetDetil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, ByVal top As Integer, ByVal user As String, ByVal strChannel As String, ByVal strOutAsset_id As String)
        DSN = strDSN
        Me.sptServer = sptServer
        Me.top = top
        Me.user = user
        Me._CHANNEL = strChannel
        Me.outasset_id = strOutAsset_id

        InitializeComponent()
    End Sub
End Class

