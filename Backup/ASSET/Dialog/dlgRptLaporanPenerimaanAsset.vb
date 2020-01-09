Public Class dlgRptLaporanPenerimaanAsset
    Private DSN As String
    Private sptServer As String
    Private tbl_Print As DataTable = clsDataset.CreateTblMstAssetalias
    Private criteria As String
    Private objDatalistDetil As ArrayList

    Private tops As Integer
    Private channel_id As String

    Private Sub dlgRptLaporanPenerimaanAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtFiller.DataFill(Me.tbl_Print, "as_MstAssetAlias_Select", criteria, Me.channel_id, Me.tops)
        'Me.DataFill(Me.tbl_MstAssetAlias, "as_MstAssetAlias_Select", criteria, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)
        
        GenerateReport()
        Me.RvLaporanPenerimaanAsset.RefreshReport()
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
        objRdsH.Name = "ASSET_DataSource_clsRptLaporanPenerimaanAsset"
        objRdsH.Value = objDatalistHeader
        objReportH.ReportEmbeddedResource = "ASSET.RptLaporanPenerimaanAsset.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "RvLaporanPenerimaanAsset"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.RvLaporanPenerimaanAsset)

        Me.RvLaporanPenerimaanAsset = Nothing
        Me.RvLaporanPenerimaanAsset = objReportViewer
        Me.RvLaporanPenerimaanAsset.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.RvLaporanPenerimaanAsset)
        Me.ResumeLayout()
        Me.RvLaporanPenerimaanAsset.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptLaporanPenerimaanAsset
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            'GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptLaporanPenerimaanAsset(Me.DSN)
            With objPrintHeader
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                .asset_line = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_line"), 0)
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id").ToString, String.Empty)
                .asset_tgl = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_tgl"), Now())
                .tipeasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("tipeasset_id").ToString, String.Empty)
                .kategoriasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("kategoriasset_id").ToString, String.Empty)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_barcode").ToString, String.Empty)
                .asset_lineinduk = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_lineinduk"), 0)
                .asset_barcodeinduk = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_barcodeinduk").ToString, String.Empty)
                .asset_serial = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_serial").ToString, String.Empty)
                .asset_produknumber = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_produknumber").ToString, String.Empty)
                .asset_model = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_model").ToString, String.Empty)
                .asset_deskripsi = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_deskripsi").ToString, String.Empty)
                .kategoriitem_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("kategoriitem_id").ToString, String.Empty)
                .tipeitem_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("tipeitem_id").ToString, String.Empty)
                .asset_golfiskal = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_golfiskal").ToString, String.Empty)
                .asset_tipedepre = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_tipedepre").ToString, String.Empty)
                .asset_depre_enddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_depre_enddt"), Now())
                .currency_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("currency_id"), 0)
                .asset_harga = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_harga"), 0)
                .asset_hargabaru = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_hargabaru"), 0)
                .asset_ppn = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_ppn"), 0)
                .asset_pph = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_pph"), 0)
                .asset_disc = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_disc"), 0)
                .asset_depresiasi = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_depresiasi"), 0)
                .asset_akum_val_depre = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_akum_val_depre"), 0)
                .asset_valas = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_valas"), 0)
                .asset_idrprice = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_idrprice"), 0)
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("strukturunit_id"), 0)
                .employee_id_owner = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("employee_id_owner").ToString, String.Empty)
                .brand_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("brand_id"), 0)
                .unit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("unit_id"), 0)
                .asset_qty = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_qty"), 0)
                .material_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("material_id").ToString, String.Empty)
                .warna_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("warna_id").ToString, String.Empty)
                .ukuran_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("ukuran_id").ToString, String.Empty)
                .jeniskelamin_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("jeniskelamin_id").ToString, String.Empty)
                .show_id_cont_item = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("show_id_cont_item").ToString, String.Empty)
                .ruang_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("ruang_id").ToString, String.Empty)
                .asset_rak = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_rak").ToString, String.Empty)
                .is_useable = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("is_useable"), 0)
                .asset_active = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_active"), 0)
                .asset_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_status").ToString, String.Empty)
                .project_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("project_id"), 0)
                .show_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("show_id").ToString, String.Empty)
                .asset_eps = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_eps").ToString, String.Empty)
                .wo_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("wo_id").ToString, String.Empty)
                .inputby = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("inputby").ToString, String.Empty)
                .inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("inputdt"), Now())
                .editby = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("editby").ToString, String.Empty)
                .editdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("editdt"), Now())
                .usedby = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("usedby").ToString, String.Empty)
                .asset_deprebulanan = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_deprebulanan"), 0)
                .asset_stdepre = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_stdepre"), Now())
                .asset_eddepre = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_eddepre"), Now())
                .brand_id_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("brand_id_string").ToString, String.Empty)
                .strukturunit_id_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("strukturunit_id_string").ToString, String.Empty)
                .unit_id_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("unit_id_string").ToString, String.Empty)
                .show_id_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("show_id_string").ToString, String.Empty)
                .project_id_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("project_id_string").ToString, String.Empty)
                .employee_string = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("employee_string").ToString, String.Empty)
                .Gdg = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Gdg").ToString, String.Empty)
                .Lt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Lt"), 0)
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

    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("E_ASSET_DataSource_", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, ByVal sptChannel_id As String, ByVal sptTop As Integer)
        DSN = strDSN
        Me.sptServer = sptServer

        Me.channel_id = sptChannel_id
        Me.tops = sptTop

        InitializeComponent()
    End Sub
End Class

