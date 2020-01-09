Public Class dlgRptPenerimaanBarang
    Private DSN As String
    Private AssetDSN As String

    Private sptServer As String
    Private channel_id As String
    Private mKet As String

    Private tbl_Print As DataTable = clsDataset.CreateTblTrnPenerimaanbarang
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnPenerimaanbarangdetil
    Private criteria As String
    Private objDatalistDetil As ArrayList

    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptTerimaBarang_ID As String
    Private sptDomain As String


    Private Sub dlgRptPenerimaanBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim dtFiller2 As clsDataFiller = New clsDataFiller(Me.AssetDSN)

        dtFiller2.DataFillAsset(Me.AssetDSN, Me.tbl_Print, "as_RptPenerimaanBarang_Select", criteria, Me.channel_id)
        dtFiller2.DataFillAsset(Me.AssetDSN, Me.tbl_PrintDetil, "as_RptPenerimaanBarangDetil_Select", criteria, Me.channel_id)

        GenerateReport()
        Me.rvPenerimaanBarang.RefreshReport()
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
        Dim parRptDomain As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", Me.sptDomain)

        objRdsH.Name = "ASSET_DataSource_clsRptPenerimaanBarang"
        objRdsH.Value = objDatalistHeader

        If Me.mKet = "Internal" Then
            objReportH.ReportEmbeddedResource = "ASSET.rptPenerimaanBarang.rdlc"
        Else
            objReportH.ReportEmbeddedResource = "ASSET.rptPenerimaanBarangX.rdlc"
        End If

        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "rvPenerimaanBarang"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptTerimaBarang_ID, parRptDomain}) ', parRptStrukturUnit})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.rvPenerimaanBarang)

        Me.rvPenerimaanBarang = Nothing
        Me.rvPenerimaanBarang = objReportViewer
        Me.rvPenerimaanBarang.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.rvPenerimaanBarang)
        Me.ResumeLayout()
        Me.rvPenerimaanBarang.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptPenerimaanBarang
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptPenerimaanBarang(Me.DSN)
            With objPrintHeader
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_id").ToString, String.Empty)
                .terimabarang_date = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_date"), Now())
                ' ''.terimabarang_type = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_type").ToString, String.Empty)
                .order_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_id").ToString, String.Empty)
                .budget_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("budget_id"), 0)
                .budget_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("budget_name"), String.Empty)
                .rekanan_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_id"), 0)
                .rekanan_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_name"), String.Empty)
                .employee_id_owner = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_name_owner").ToString, String.Empty)
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), 0)
                .department = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("department"), String.Empty)

                ' ''.terimabarang_qtyitem = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_qtyitem"), 0)
                ' ''.terimabarang_qtyrealization = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_qtyrealization"), 0)
                ' ''.order_qty = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_qty"), 0)
                .terimabarang_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_status").ToString, String.Empty)
                .terimabarang_statusrealization = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_statusrealization").ToString, String.Empty)
                .terimabarang_location = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_location").ToString, String.Empty)
                .terimabarang_notes = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_notes").ToString, String.Empty)
                ' ''.terimabarang_nosuratjalan = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_nosuratjalan").ToString, String.Empty)
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
                ' ''.terimabarang_isdisabled = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_isdisabled"), 0)
                ' ''.terimabarang_createby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_createby").ToString, String.Empty)
                ' ''.terimabarang_createdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_createdt"), Now())
                ' ''.terimabarang_modifiedby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_modifiedby").ToString, String.Empty)
                ' ''.terimabarang_modifieddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_modifieddt"), Now())
                ' ''.terimabarang_appuser = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appuser"), 0)
                ' ''.terimabarang_appuser_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appuser_by").ToString, String.Empty)
                ' ''.terimabarang_appuser_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appuser_dt"), Now())
                ' ''.terimabarang_appspv = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appspv"), 0)
                .terimabarang_appspv_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appspv_name").ToString, String.Empty)
                ' ''.terimabarang_appspv_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appspv_dt"), Now())
                ' ''.terimabarang_appacc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appacc"), 0)
                ' ''.terimabarang_appacc_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appacc_by").ToString, String.Empty)
                ' ''.terimabarang_appacc_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appacc_dt"), Now())
                ' ''.terimabarang_foreign = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_foreign"), 0)
                ' ''.currency_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_id"), 0)
                ' ''.terimabarang_foreignrate = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_foreignrate"), 0)
                ' ''.terimabarang_idrreal = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_idrreal"), 0)
                ' ''.terimabarang_pph = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_pph"), 0)
                ' ''.terimabarang_ppn = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_ppn"), 0)
                ' ''.terimabarang_disc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_disc"), 0)
                ' ''.terimabarang_cetakbpb = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_cetakbpb"), 0)

                Me.sptChannel_ID = .channel_id
                Me.sptChannel_nameReport = .channel_namereport
                Me.sptChannel_address = .channel_address
                Me.sptTerimaBarang_ID = .terimabarang_id
                Me.sptDomain = .domain_name

            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptPenerimaanBarangDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptPenerimaanBarangDetil(Me.DSN, Me.AssetDSN)
            With objDetil
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                .terimabarangdetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_line"), 0)
                ' ''.terimabarangdetil_parentline = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_parentline"), 0)
                .terimabarangdetil_desc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_desc").ToString, String.Empty)
                ' ''.terimabarangdetil_date = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_date"), Now())
                ' ''.terimabarangdetil_type = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_type").ToString, String.Empty)
                ' ''.assetcategory_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("assetcategory_id").ToString, String.Empty)
                ' ''.assettype_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("assettype_id").ToString, String.Empty)
                .terimabarang_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarang_barcode").ToString, String.Empty)
                ' ''.terimabarang_parentbarcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarang_parentbarcode").ToString, String.Empty)
                ' ''.item_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("item_id").ToString, String.Empty)
                ' ''.itemcategory_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("itemcategory_id").ToString, String.Empty)
                .itemtype_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("itemtype_id").ToString, String.Empty)
                .brand_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand_id"), 0)
                .brand_name = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand_name"), String.Empty)
                .terimabarangdetil_serial_no = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_serial_no").ToString, String.Empty)
                ' ''.terimabarangdetil_product_no = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_product_no").ToString, String.Empty)
                ' ''.terimabarangdetil_model = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_model").ToString, String.Empty)
                ' ''.material_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("material_id").ToString, String.Empty)
                ' ''.colour_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("colour_id").ToString, String.Empty)
                ' ''.size_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("size_id").ToString, String.Empty)
                ' ''.sex_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("sex_id").ToString, String.Empty)
                .room_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("room_id").ToString, String.Empty)
                .room_name = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("room_name").ToString, String.Empty)
                ' ''.terimabarangdetil_rack = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_rack").ToString, String.Empty)
                .terimabarangdetil_qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_qty"), 0)
                ' ''.unit_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("unit_id"), 0)
                ' ''.currency_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id"), 0)
                .terimabarangdetil_foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_foreign"), 0)
                .terimabarangdetil_foreignrate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_foreignrate"), 0)
                .terimabarangdetil_idrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_idrreal"), 0)
                .terimabarangdetil_pphpercent = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_pphpercent"), 0)
                .terimabarangdetil_ppnpercent = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_ppnpercent"), 0)
                .terimabarangdetil_disc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_disc"), 0)
                .terimabarangdetil_pphforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_pphforeign"), 0)
                .terimabarangdetil_pphidrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_pphidrreal"), 0)
                .terimabarangdetil_ppnforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_ppnforeign"), 0)
                .terimabarangdetil_ppnidrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_ppnidrreal"), 0)
                .terimabarangdetil_totalforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_totalforeign"), 0)
                .terimabarangdetil_totalidrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_totalidrreal"), 0)
                ' ''.terimabarangdetil_nonfixasset = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_nonfixasset"), 0)
                ' ''.terimabarangdetil_golfiskal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_golfiskal").ToString, String.Empty)
                ' ''.terimabarangdetil_depre_enddt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_depre_enddt"), Now())
                ' ''.employee_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_id").ToString, String.Empty)
                ' ''.strukturunit_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_id"), 0)
                ' ''.show_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("show_id").ToString, String.Empty)
                ' ''.show_id_cont = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("show_id_cont").ToString, String.Empty)
                ' ''.terimabarangdetil_eps = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarangdetil_eps").ToString, String.Empty)
                ' ''.writeoff_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_id").ToString, String.Empty)
                ' ''.writeoff_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("writeoff_dt"), Now())
                ' ''.order_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("order_id").ToString, String.Empty)
                ' ''.orderdetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("orderdetil_line"), 0)
                ' ''.budget_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("budget_id"), 0)
                ' ''.budgetdetil_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("budgetdetil_id"), 0)
                ' ''.acc_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_id").ToString, String.Empty)
                ' ''.channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
                ' ''.create_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("create_by").ToString, String.Empty)
                ' ''.create_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("create_dt"), Now())
                ' ''.modified_by = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("modified_by").ToString, String.Empty)
                ' ''.modified_dt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("modified_dt"), Now())

                Dim ppn_idrreal As Decimal

                ppn_idrreal += .terimabarangdetil_ppnidrreal
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptPenerimaanBarangDetil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal AssetDSN As String, ByVal sptServer As String, ByVal channel_id As String, ByVal ket As String)
        Me.DSN = strDSN
        Me.AssetDSN = AssetDSN
        Me.sptServer = sptServer
        Me.channel_id = channel_id
        Me.mKet = ket

        InitializeComponent()
    End Sub
End Class

