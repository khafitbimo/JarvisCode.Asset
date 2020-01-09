Public Class dlgRptTerimaJasa1

    Private DSN As String
    Private sptServer As String
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnTerimabarang
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnTerimabarangdetil
    Private tbl_MstTrnOrder As DataTable = clsDataset.CreateTblTrnOrder()
    Private criteria As String
    Private objDatalistDetil As ArrayList

    Private channel_id As String
    Private terimaBarang_id As String

    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptTerimaBarang_ID As String
    Private tbl_MstSkill As DataTable = clsDataset.CreateTblMstSkill()
    Private tbl_request As DataTable = clsDataset.CreateTblRequestdetilSelect()
    Private tbl_requesteps As DataTable = clsDataset.CreateTblTrnRequestdetilEps()
    'Private sptStrukturUnit As String

    Private Sub dlgRptTrnTerimaBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtFiller.DataFill(Me.tbl_Print, "as_TrnTerimabarang_Select", criteria, channel_id, Top)
        dtFiller.DataFill(Me.tbl_PrintDetil, "as_TrnTerimabarangdetil_select ", criteria, channel_id, Top)

        GenerateReport()
        Me.rvTerimaJasa.RefreshReport()
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
        Dim parRptTerimaBarang_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("terimabarang_id", Me.sptTerimaBarang_ID)
        'Dim parRptStrukturUnit As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("strukturUnit", Me.sptStrukturUnit)

        objRdsH.Name = "ASSET_DataSource_clsRptBarang"
        objRdsH.Value = objDatalistHeader
        objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasa1.rdlc"
        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "rvTerimaBarang"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptTerimaBarang_ID}) ', parRptStrukturUnit})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.rvTerimaJasa)

        Me.rvTerimaJasa = Nothing
        Me.rvTerimaJasa = objReportViewer
        Me.rvTerimaJasa.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.rvTerimaJasa)
        Me.ResumeLayout()
        Me.rvTerimaJasa.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptBarang
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim order As String
        Me.tbl_MstTrnOrder.Clear()
        For i = 0 To Me.tbl_Print.Rows.Count - 1
            GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptBarang(Me.DSN)
            With objPrintHeader
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_id").ToString, String.Empty)
                .terimabarang_tgl = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_tgl"), Now())
                .terimabarang_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_status").ToString, String.Empty)
                .order_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_id").ToString, String.Empty)
                .pa_ref = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("pa_ref").ToString, String.Empty)
                .rekanan_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_id"), 0)
                .terimabarang_appacc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appacc"), 0)
                .employee_id_pemilik = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_pemilik").ToString, String.Empty)
                .strukturunit_id_pemilik = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_pemilik"), 0)
                .accounting_applogin = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("accounting_applogin").ToString, String.Empty)
                .accounting_appdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("accounting_appdt"), Now())
                .terimabarang_appprc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appprc"), 0)
                .procurement_applogin = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("procurement_applogin").ToString, String.Empty)
                .procurement_appdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("procurement_appdt"), Now())
                .terimabarang_cetakbpb = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_cetakbpb"), 0)
                .terimabarang_cetakbkb = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_cetakbkb"), 0)
                .terimabarang_item = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_item"), 0)
                .inputby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("inputby").ToString, String.Empty)
                .inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("inputdt"), Now())
                .editby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("editby").ToString, String.Empty)
                .editdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("editdt"), Now())
                .usedby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("usedby").ToString, String.Empty)
                .useddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("useddt"), Now())
                .user_proc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("user_proc").ToString, String.Empty)
                .user_accounting = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("user_accounting").ToString, String.Empty)
                .location = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("location").ToString, String.Empty)
                .user_applogin = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("user_applogin").ToString, String.Empty)
                .notes = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("notes").ToString, String.Empty)
                .status_kedatangan = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("status_kedatangan").ToString, String.Empty)

                .budget_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("budget_id"), String.Empty)
                .budget_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("budget_name"), String.Empty)

                'buat narik shooting date
                order = String.Format("order_id='{0}'", .order_id)
                dtFiller.DataFillLimit(Me.tbl_MstTrnOrder, "pr_TrnOrder_Select", order, 1)
                .shooting_date = clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("order_utilizeddatestart").ToString, String.Empty)


                Me.sptChannel_ID = .channel_id
                Me.sptChannel_nameReport = .channel_namereport
                Me.sptChannel_address = .channel_address
                Me.sptTerimaBarang_ID = .terimabarang_id
                'Me.sptStrukturUnit = .Moveasset_strukturunit_string
            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptBarangDetil
        Dim i As Integer
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim criteria_peran As String
        Dim code As Integer
        Dim request_id As String
        Dim order As String

        Me.tbl_MstSkill.Clear()
        Me.tbl_MstTrnOrder.Clear()
        Me.tbl_request.Clear()
        Me.tbl_requesteps.Clear()

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptBarangDetil(Me.DSN)
            With objDetil
                Me.tbl_MstSkill.Clear()
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                .asset_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_line"), 0)
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
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
                .currency_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id"), 0)
                .asset_harga = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_harga"), 0)
                .asset_hargabaru = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_hargabaru"), 0)
                .asset_ppn = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_ppn"), 0)
                .asset_pph = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_pph"), 0)
                .asset_disc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_disc"), 0)
                .asset_depresiasi = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_depresiasi"), 0)
                .asset_akum_val_depre = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_akum_val_depre"), 0)
                .asset_valas = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_valas"), 0)
                .asset_idrprice = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_idrprice"), 0)
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_id"), 0)
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
                .order_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("order_id").ToString, String.Empty)


                'buat narik peran dan episode
                order = String.Format("order_id='{0}'", .order_id)
                dtFiller.DataFillLimit(Me.tbl_MstTrnOrder, "pr_TrnOrder_Select", order, 1)
                request_id = String.Format("request_id='{0}'", clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("request_id").ToString, String.Empty))
                dtFiller.DataFill(Me.tbl_request, "pr_TrnRequestdetil_Select", request_id)
                code = clsUtil.IsDbNull(Me.tbl_request.Rows(0).Item("requestdetil_bal"), 0)
                criteria_peran = String.Format("code = '{0}' ", code)
                dtFiller.DataFill(Me.tbl_MstSkill, "ms_MstSkill_Select", criteria_peran)
                If tbl_MstSkill.Rows.Count = 0 Then
                    .Peran = String.Empty
                Else
                    .Peran = clsUtil.IsDbNull(Me.tbl_MstSkill.Rows(0).Item("name").ToString, String.Empty)
                End If

                dtFiller.DataFillLimit(Me.tbl_requesteps, "tq_TrnRequestdetileps_Select", request_id)

                .Episode = clsUtil.IsDbNull(Me.tbl_requesteps.Rows(0).Item("requestdetil_eps").ToString, String.Empty)


            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptBarangDetil", objDatalistDetil))
    End Sub




    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, ByVal channel_id As String, ByVal top As Integer, ByVal retTerimaBarang As String)
        Me.DSN = strDSN
        Me.sptServer = sptServer
        Me.channel_id = channel_id
        Me.Top = top
        Me.terimaBarang_id = retTerimaBarang

        InitializeComponent()
    End Sub
End Class
