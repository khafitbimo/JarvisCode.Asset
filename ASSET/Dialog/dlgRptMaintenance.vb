Public Class dlgRptMaintenance
    Private DSN As String
    Private sptServer As String
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnMaintenance
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnMaintenancedetil
    Private criteria As String
    Private objDatalistDetil As ArrayList

    Private channel_id As String
    Private maintenance_id As String

    Private Sub dlgRptMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtFiller.DataFill(Me.tbl_Print, "as_TrnMaintenance_Select", criteria, Me.channel_id, Me.Top)
        Me.criteria = String.Format(" maintenance_id = '{0}'", Me.maintenance_id)
        dtFiller.DataFill(Me.tbl_PrintDetil, "as_TrnMaintenancedetil_Select", criteria)

        GenerateReport()
        Me.rvMaintenanceAsset.RefreshReport()
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
        objRdsH.Name = "ASSET_DataSource_clsRptMaintenance"
        objRdsH.Value = objDatalistHeader
        objReportH.ReportEmbeddedResource = "ASSET.RptMaintenance.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "rvMaintenanceAsset"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.rvMaintenanceAsset)

        Me.rvMaintenanceAsset = Nothing
        Me.rvMaintenanceAsset = objReportViewer
        Me.rvMaintenanceAsset.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.rvMaintenanceAsset)
        Me.ResumeLayout()
        Me.rvMaintenanceAsset.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptMaintenance
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptMaintenance(Me.DSN)
            With objPrintHeader
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
                .maintenance_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_id").ToString, String.Empty)
                .maintenance_type = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_type").ToString, String.Empty)
                .maintenance_outin = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_outin"), 0)
                .order_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_id").ToString, String.Empty)
                .rekanan_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_id"), 0)
                .maintenace_itemqty = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenace_itemqty"), 0)
                .maintenace_itemqtyret = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenace_itemqtyret"), 0)
                .employee_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id").ToString, String.Empty)
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), 0)
                .maintenance_indt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_indt"), Now())
                .maintenance_outdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_outdt"), Now())
                .maintenance_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_status").ToString, String.Empty)
                .currency_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_id"), 0)
                .maintenance_harga = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_harga"), 0)
                .maintenance_valas = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_valas"), 0)
                .maintenance_idrprice = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_idrprice"), 0)
                .maintenance_inputby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_inputby").ToString, String.Empty)
                .maintenance_inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_inputdt"), Now())
                .maintenance_editby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_editby").ToString, String.Empty)
                .maintenance_editdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_editdt"), Now())
                .maintenance_usedby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_usedby").ToString, String.Empty)
                .maintenance_useddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_useddt"), Now())
                .maintenance_outlock = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_outlock"), 0)
                .maintenance_inclock = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("maintenance_inclock"), 0)
            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptMaintenanceDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptMaintenanceDetil(Me.DSN)
            With objDetil
                .maintenance_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenance_id").ToString, String.Empty)
                .maintenancedetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenancedetil_line"), 0)
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
                .maintenancedetil_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenancedetil_barcode").ToString, String.Empty)
                .maintenancedetil_outdate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenancedetil_outdate"), Now())
                .maintenancedetil_statusout = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenancedetil_statusout").ToString, String.Empty)
                .maintenance_incdate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenance_incdate"), Now())
                .maintenancedetil_statusinc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("maintenancedetil_statusinc").ToString, String.Empty)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptMaintenanceDetil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, ByVal channel As String, _
                    ByVal maintenance_id As String)
        DSN = strDSN
        Me.sptServer = sptServer
        Me.channel_id = channel
        Me.maintenance_id = maintenance_id

        InitializeComponent()
    End Sub
End Class

