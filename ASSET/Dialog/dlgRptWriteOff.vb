Public Class dlgRptWriteOff
    Private DSN As String
    Private sptServer As String
    Private channel_id As String
    Private writeoff_id As String
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnWriteoff(Me.channel_id)
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnWriteoffdetil(Me.channel_id)
    Private criteria As String
    Private objDatalistDetil As ArrayList


    Private tempChannel_ID As String
    Private tempChannel_nameReport As String
    Private tempChannel_address As String

    Private Sub dlgRptWriteOff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtFiller.DataFill(Me.tbl_Print, "as_TrnWriteoffReport_Select", criteria, Me.channel_id)
        criteria = " writeoff_id = '" & writeoff_id & "'"
        dtFiller.DataFill(Me.tbl_PrintDetil, "as_TrnWriteoffdetil_Select", criteria)

        GenerateReport()
        Me.rvTrnWriteoff.RefreshReport()
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

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.tempChannel_ID)
        Dim parRptChannel_nameReport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.tempChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.tempChannel_address)
        Dim parRptWrite_off As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("writeoffID", Me.writeoff_id)

        objRdsH.Name = "ASSET_DataSource_clsRptTrnWriteoff"
        objRdsH.Value = objDatalistHeader
        objReportH.ReportEmbeddedResource = "ASSET.RptWriteOff.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "rvTrnWriteoff"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_nameReport, parRptChannel_address, parRptWrite_off})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.rvTrnWriteoff)

        Me.rvTrnWriteoff = Nothing
        Me.rvTrnWriteoff = objReportViewer
        Me.rvTrnWriteoff.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.rvTrnWriteoff)
        Me.ResumeLayout()
        Me.rvTrnWriteoff.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptTrnWriteoff
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptTrnWriteoff(Me.DSN)
            With objPrintHeader
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
                .writeoff_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("writeoff_id").ToString, String.Empty)
                .writeoff_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("writeoff_dt"), Now())
                .employee_id_reportby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_reportby").ToString, String.Empty)
                .strukturunit_id_reportby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_reportby"), 0)
                .employee_id_approvedby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_approvedby").ToString, String.Empty)
                .writeoff_inputby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("writeoff_inputby").ToString, String.Empty)
                .writeoff_date = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("writeoff_date"), Now())
                .lock = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("lock"), 0)
                .employee_id_owner_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_owner_string").ToString, String.Empty)
                .strukturunit_id_owner = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_owner").ToString, String.Empty)
                .strukturunit_parent_owner = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_parent_owner").ToString, String.Empty)

                .employee_id_internal_audit_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_internal_audit_string").ToString, String.Empty)
                .employee_id_procurement_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_procurement_string").ToString, String.Empty)
                .employee_id_accounting_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_accounting_string").ToString, String.Empty)
                .employee_id_frm_director_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_frm_director_string").ToString, String.Empty)
                .employee_id_president_director_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_president_director_string").ToString, String.Empty)
                .employee_id_commissioner_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_commissioner_string").ToString, String.Empty)
                .employee_id_reportby_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_reportby_string").ToString, String.Empty)
                .employee_id_owner_dept_head_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_owner_dept_head_string").ToString, String.Empty)
                .employee_id_owner_div_head_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_owner_div_head_string").ToString, String.Empty)
                .employee_id_owner_director_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_owner_director_string").ToString, String.Empty)


                Me.tempChannel_ID = .channel_id
                Me.tempChannel_nameReport = .channel_namereport
                Me.tempChannel_address = .channel_address
            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptTrnWriteoffDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptTrnWriteoffDetil(Me.DSN)
            With objDetil
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
                .writeoff_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_id").ToString, String.Empty)
                .writeoff_tgl = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_tgl"), Now())
                .writeoff_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_barcode").ToString, String.Empty)
                .currency_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id"), 0)
                .writeoff_hargaawal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_hargaawal"), 0)
                .currency_id_akhir = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id_akhir"), 0)
                .writeoff_hargakhir = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_hargakhir"), 0)
                .employee_id_writeoffby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_id_writeoffby").ToString, String.Empty)
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_id"), 0)
                .employee_id_writeoffapp = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_id_writeoffapp").ToString, String.Empty)
                .writeoff_reason = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_reason").ToString, String.Empty)
                .status_akhir = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("status_akhir").ToString, String.Empty)
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                .asset_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_line"), 0)
                .channel_id1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id1").ToString, String.Empty)
                .asset_tgl = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_tgl"), Now())
                .tipeasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("tipeasset_id").ToString, String.Empty)
                .kategoriasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("kategoriasset_id").ToString, String.Empty)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcode").ToString, String.Empty)
                .asset_lineinduk = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_lineinduk"), 0)
                .asset_barcodeinduk = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcodeinduk").ToString, String.Empty)
                .asset_serial = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_serial").ToString, String.Empty)
                .asset_produknumber = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_produknumber").ToString, String.Empty)
                .asset_model = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_model").ToString, String.Empty)
                .asset_deskripsi = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_deskripsi").ToString, String.Empty)
                .kategoriitem_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("kategoriitem_id").ToString, String.Empty)
                .tipeitem_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("tipeitem_id").ToString, String.Empty)
                .asset_golfiskal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_golfiskal").ToString, String.Empty)
                .asset_tipedepre = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_tipedepre").ToString, String.Empty)
                .asset_depre_enddt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_depre_enddt"), Now())
                .currency_id1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id1"), 0)
                .asset_harga = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_harga"), 0)
                .asset_hargabaru = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_hargabaru"), 0)
                .asset_ppn = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_ppn"), 0)
                .asset_pph = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_pph"), 0)
                .asset_disc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_disc"), 0)
                .asset_depresiasi = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_depresiasi"), 0)
                .asset_akum_val_depre = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_akum_val_depre"), 0)
                .asset_valas = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_valas"), 0)
                .asset_idrprice = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_idrprice"), 0)
                .strukturunit_id1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_id1"), 0)
                .employee_id_owner = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_id_owner").ToString, String.Empty)
                .brand_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand_id"), 0)
                .unit_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("unit_id"), 0)
                .asset_qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_qty"), 0)
                .material_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("material_id").ToString, String.Empty)
                .warna_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("warna_id").ToString, String.Empty)
                .ukuran_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ukuran_id").ToString, String.Empty)
                .jeniskelamin_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jeniskelamin_id").ToString, String.Empty)
                .show_id_cont_item = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("show_id_cont_item").ToString, String.Empty)
                .ruang_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ruang_id").ToString, String.Empty)
                .asset_rak = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_rak").ToString, String.Empty)
                .is_useable = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("is_useable"), 0)
                .asset_active = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_active"), 0)
                .asset_status = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_status").ToString, String.Empty)
                .project_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("project_id"), 0)
                .show_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("show_id").ToString, String.Empty)
                .asset_eps = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_eps").ToString, String.Empty)
                .wo_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("wo_id").ToString, String.Empty)
                .inputby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("inputby").ToString, String.Empty)
                .inputdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("inputdt"), Now())
                .editby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("editby").ToString, String.Empty)
                .editdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("editdt"), Now())
                .usedby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("usedby").ToString, String.Empty)
                .asset_deprebulanan = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_deprebulanan"), 0)
                .asset_stdepre = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_stdepre"), Now())
                .asset_eddepre = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_eddepre"), Now())
                .asset_deskripsi1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_deskripsi1").ToString, String.Empty)
                .asset_serial1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_serial1").ToString, String.Empty)
                .tipeitem_id1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("tipeitem_id1").ToString, String.Empty)
                .kategoriitem_id1 = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("kategoriitem_id1").ToString, String.Empty)
                .strukturunit_id_string = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_id_string").ToString, String.Empty)
                .employee_id_string = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_id_string").ToString, String.Empty)
                .currency_awal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_awal").ToString, String.Empty)
                .currency_akhir = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_akhir").ToString, String.Empty)
                .lokasi = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("lokasi").ToString, String.Empty)
                .line = (i + 1)
                .times = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("times"), 0)
                .nbv = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("nbv"), 0)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptTrnWriteoffDetil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, _
    ByVal channel_id As String, ByVal writeoff_id As String)
        DSN = strDSN
        Me.sptServer = sptServer
        Me.channel_id = channel_id
        Me.writeoff_id = writeoff_id

        InitializeComponent()
    End Sub
End Class

