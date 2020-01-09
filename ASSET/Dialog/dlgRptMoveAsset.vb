Public Class dlgRptMoveAsset
    Private DSN As String
    Private sptServer As String
    Private channel As String
    Private Shadows top As Integer
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnMoveasset
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnMoveassetdetil
    Private criteria As String
    Private objDatalistDetil As ArrayList
    Private moveAsset_ID As String

    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptMoveAsset_ID As String
    Private sptStrukturUnit As String

    Private Sub dlgRptMoveAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtFiller.DataFill(Me.tbl_Print, "as_TrnMoveasset_Select", criteria, Me.channel, Me.top)
        criteria = " moveasset_id = '" & moveAsset_ID & "'"
        dtFiller.DataFill(Me.tbl_PrintDetil, "as_TrnMoveassetdetil_Select", criteria)

        GenerateReport()
        Me.rvMoveAsset.RefreshReport()
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
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptMoveAsset_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("moveAssetID", Me.sptMoveAsset_ID)
        Dim parRptStrukturUnit As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("strukturUnit", Me.sptStrukturUnit)

        objRdsH.Name = "ASSET_DataSource_clsRptMoveAsset"
        objRdsH.Value = objDatalistHeader
        objReportH.ReportEmbeddedResource = "ASSET.RptMoveAsset.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "rvMoveAsset"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptMoveAsset_ID, parRptStrukturUnit})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.rvMoveAsset)

        Me.rvMoveAsset = Nothing
        Me.rvMoveAsset = objReportViewer
        Me.rvMoveAsset.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.rvMoveAsset)
        Me.ResumeLayout()
        Me.rvMoveAsset.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptMoveAsset
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptMoveAsset(Me.DSN)
            With objPrintHeader
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
                .moveasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_id").ToString, String.Empty)
                .moveasset_tgl = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_tgl"), Now())
                .moveasset_strukturunit = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_strukturunit"), 0)
                .moveasset_report = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_report").ToString, String.Empty)
                .moveasset_acct = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_acct").ToString, String.Empty)
                .employee_id_old = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_old").ToString, String.Empty)
                .strukturunit_id_old = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_old"), 0)
                .employee_id_new = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_new").ToString, String.Empty)
                .strukturunit_id_new = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_new"), 0)
                .moveasset_remark = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_remark").ToString, String.Empty)
                .moveasset_item = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("moveasset_item"), 0)
                .employee_old_depthead_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_old_depthead_string"), String.Empty)
                .employee_old_divhead_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_old_divhead_string"), String.Empty)
                .employee_new_depthead_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_new_depthead_string"), String.Empty)
                .employee_new_divhead_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_new_divhead_string"), String.Empty)
                .employee_acc_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_acc_string"), String.Empty)


                Me.sptChannel_ID = .channel_id
                Me.sptChannel_nameReport = .channel_namereport
                Me.sptChannel_address = .channel_address
                Me.sptMoveAsset_ID = .moveasset_id
                Me.sptStrukturUnit = .Moveasset_strukturunit_string
            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptMoveAssetDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptMoveAssetDetil(Me.DSN)
            With objDetil
                .channel = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel").ToString, String.Empty)
                .moveasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("moveasset_id").ToString, String.Empty)
                .line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("line"), 0)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcode").ToString, String.Empty)
                .employee_oldowner = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_oldowner").ToString, String.Empty)
                .strukturunit_idold = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_idold"), 0)
                .employee_newowner = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_newowner").ToString, String.Empty)
                .strukturunit_idnew = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_idnew"), 0)
                .asset_status = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_status").ToString, String.Empty)
                .remark = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("remark").ToString, String.Empty)
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
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptMoveAssetDetil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, ByVal channel As String, ByVal top As Integer, ByVal strMoveAsset_id As String)
        DSN = strDSN
        Me.sptServer = sptServer
        Me.channel = channel
        Me.top = top
        Me.moveAsset_ID = strMoveAsset_id


        InitializeComponent()
    End Sub
End Class


