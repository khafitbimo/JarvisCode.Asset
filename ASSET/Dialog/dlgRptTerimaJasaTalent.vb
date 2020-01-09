Public Class dlgRptTerimaJasaTalent
    Private DSN As String
    ' Private AssetDsn As String
    Private sptServer As String
    Private mChannel_id As String
    Private mKet As String

    Private tbl_Print As DataTable = clsDataset.CreateTblTrnTerimajasa
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnTerimajasadetil
    Private criteria As String
    Private objDatalistDetil As ArrayList

    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptTerimaJasa_id As String
    Private sptDomain As String

    Private sptSumTotal As String
    Private sptSumDiscount As String
    Private sptSumPPn As String
    Private sptSumPPh As String
    Private sptSumGrandTotal As String

    Private Sub dlgRptTerimaJasaRental_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim dtFillerAsset As clsDataFiller = New clsDataFiller(Me.DSN)

        dtFillerAsset.DataFillAsset(Me.DSN, Me.tbl_Print, "as_TrnTerimajasa_Select", " AND " & criteria, Me.mChannel_id, 1)
        dtFillerAsset.DataFillAsset(Me.DSN, Me.tbl_PrintDetil, "as_TrnTerimajasadetil_Select", criteria)

        GenerateReport()
        Me.rvTerimaJasaTalent.RefreshReport()
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
        Dim parRptTerimaJasa_id As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("terimajasa_id", Me.sptTerimaJasa_id)
        'Me.sptDomain = Me.sptDomain & "/services/live/solutions/images/" & Me.sptChannel_ID + ".jpg"
        Dim parRptDomain As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_domain_name", Me.sptDomain)
        '

        '===20140226 pts ADD==
        Dim parRptSumTotal As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumtotal", Me.sptSumTotal)
        Dim parRptSumDiscount As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumdiscount", Me.sptSumDiscount)
        Dim parRptSumPPN As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumppn", Me.sptSumPPn)
        Dim parRptSumPPH As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumpph", Me.sptSumPPh)
        Dim parRptSumGrandTotal As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("p_sumgrandtotal", Me.sptSumGrandTotal)
        '=====================
        '
        objRdsH.Name = "ASSET_DataSource_clsRptTerimaJasaTalent"
        objRdsH.Value = objDatalistHeader

        If Me.mKet = "Internal" Then
            'objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasa_Talent.rdlc"
            objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasa_Talent1.rdlc"
        Else
            objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasa_Talentxx1.rdlc"
        End If

        objReportH.DataSources.Add(objRdsH)

        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "rvTerimaJasaTalent"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptTerimaJasa_id, parRptDomain, parRptSumTotal, parRptSumDiscount, parRptSumPPN, parRptSumPPH, parRptSumGrandTotal})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.rvTerimaJasaTalent)

        Me.rvTerimaJasaTalent = Nothing
        Me.rvTerimaJasaTalent = objReportViewer
        Me.rvTerimaJasaTalent.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.rvTerimaJasaTalent)
        Me.ResumeLayout()
        Me.rvTerimaJasaTalent.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptTerimaJasaTalent
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        '=========ADD PTS 20140226==========
        Dim Total, Discount, SumPPN, SumPPH, SumGrandTotal, SumTotal, SumDiscount As Decimal
        SumTotal = 0
        SumDiscount = 0

        For a As Integer = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            Total = Me.tbl_PrintDetil.Rows(a).Item("terimajasadetil_idrreal") * Me.tbl_PrintDetil.Rows(a).Item("terimajasadetil_qty_usage")
            SumTotal = SumTotal + Total
        Next

        For w As Integer = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            Discount = Me.tbl_PrintDetil.Rows(w).Item("terimajasadetil_disc") * Me.tbl_PrintDetil.Rows(w).Item("terimajasadetil_qty_usage") * Me.tbl_PrintDetil.Rows(w).Item("terimajasadetil_foreignrate")
            SumDiscount = SumDiscount + Discount
        Next

        SumPPN = Me.tbl_PrintDetil.Compute("sum(terimajasadetil_ppnidrreal)", "")
        SumPPH = Me.tbl_PrintDetil.Compute("sum(terimajasadetil_pphidrreal)", "")
        SumGrandTotal = Me.tbl_PrintDetil.Compute("sum(terimajasadetil_totalidrreal)", "")

        Me.sptSumTotal = SumTotal
        Me.sptSumDiscount = SumDiscount
        Me.sptSumPPn = SumPPN
        Me.sptSumPPh = SumPPH
        Me.sptSumGrandTotal = SumGrandTotal
        '=========================================================


        For i = 0 To Me.tbl_Print.Rows.Count - 1
            GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptTerimaJasaTalent(Me.DSN)
            With objPrintHeader
                .terimajasa_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_id").ToString, String.Empty)
                .terimajasa_date = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_date"), Now())
                .terimajasa_type = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_type").ToString, String.Empty)
                .order_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_id").ToString, String.Empty)
                .budget_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("budget_id"), 0)
                .rekanan_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_id"), 0)
                .employee_id_owner = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_owner").ToString, String.Empty)
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), 0)
                .terimajasa_qtyitem = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_qtyitem"), 0)
                .terimajasa_qtyrealization = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_qtyrealization"), 0)
                .order_qty = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_qty"), 0)
                .terimajasa_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_status").ToString, String.Empty)
                .terimajasa_statusrealization = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_statusrealization").ToString, String.Empty)
                .terimajasa_location = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_location").ToString, String.Empty)
                .terimajasa_notes = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_notes").ToString, String.Empty)
                .terimajasa_nosuratjalan = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_nosuratjalan").ToString, String.Empty)
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
                .terimajasa_isdisabled = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_isdisabled"), 0)
                .terimajasa_createby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_createby").ToString, String.Empty)
                .terimajasa_createdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_createdt"), Now())
                .terimajasa_modifiedby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_modifiedby").ToString, String.Empty)
                .terimajasa_modifieddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_modifieddt"), Now())
                .terimajasa_appuser = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appuser"), 0)
                .terimajasa_appuser_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appuser_by").ToString, String.Empty)
                .terimajasa_appuser_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appuser_dt"), Now())
                .terimajasa_appspv = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appspv"), 0)
                .terimajasa_appspv_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appspv_by").ToString, String.Empty)
                .terimajasa_appspv_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appspv_dt"), Now())
                .terimajasa_appbma = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appbma"), 0)
                .terimajasa_appbma_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appbma_by").ToString, String.Empty)
                .terimajasa_appbma_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_appbma_dt"), Now())
                .terimajasa_foreign = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_foreign"), 0)
                .currency_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("currency_id"), 0)
                .terimajasa_foreignrate = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_foreignrate"), 0)
                .terimajasa_idrreal = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_idrreal"), 0)
                .terimajasa_pph = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_pph"), 0)
                .terimajasa_ppn = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_ppn"), 0)
                .terimajasa_disc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_disc"), 0)
                .terimajasa_cetakbpj = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimajasa_cetakbpj"), 0)
                .rekanan_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_name"), 0)

                Me.sptChannel_ID = .channel_id
                Me.sptChannel_nameReport = .channel_namereport
                Me.sptChannel_address = .channel_address
                Me.sptTerimaJasa_id = .terimajasa_id
                Me.sptDomain = .domain_name

            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptTerimaJasaTalentDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptTerimaJasaTalentDetil(Me.DSN)
            With objDetil
                .terimajasa_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasa_id").ToString, String.Empty)
                .terimajasadetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_line"), 0)
                .terimajasadetil_desc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_desc").ToString, String.Empty)
                .terimajasadetil_date = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_date"), Now())
                .terimajasadetil_qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_qty"), 0)
                .terimajasadetil_qty_day_eps = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_qty_day_eps"), 0)
                .terimajasadetil_qty_usage = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_qty_usage"), 0)
                .terimajasadetil_type = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_type").ToString, String.Empty)
                .order_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("order_id").ToString, String.Empty)
                .orderdetil_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("orderdetil_line"), 0)
                .item_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("item_id").ToString, String.Empty)
                .kategoriitem_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("kategoriitem_id").ToString, String.Empty)
                .brand_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand_id"), 0)
                .budget_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("budget_id"), 0)
                .budgetdetil_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("budgetdetil_id"), 0)
                .acc_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("acc_id").ToString, String.Empty)
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
                .terimajasadetil_createby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_createby").ToString, String.Empty)
                .terimajasadetil_createdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_createdt"), Now())
                .terimajasadetil_modifiedby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_modifiedby").ToString, String.Empty)
                .terimajasadetil_modifieddt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_modifieddt"), Now())
                .terimajasadetil_foreign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_foreign"), 0)
                .currency_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id"), 0)
                .terimajasadetil_foreignrate = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_foreignrate"), 0)
                .terimajasadetil_idrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_idrreal"), 0)
                .terimajasadetil_pphpersen = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_pphpersen"), 0)
                .terimajasadetil_ppnpersen = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_ppnpersen"), 0)
                .terimajasadetil_disc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_disc"), 0)
                .terimajasadetil_pphforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_pphforeign"), 0)
                .terimajasadetil_pphidrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_pphidrreal"), 0)
                .terimajasadetil_ppnforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_ppnforeign"), 0)
                .terimajasadetil_ppnidrreal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_ppnidrreal"), 0)
                If clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("type_pajak"), 1) = 1 Then
                    .terimajasadetil_totalforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_totalforeign"), 0) + clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_pphforeign"), 0)
                    .terimajasadetil_totalidrreal = (clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_qty_usage"), 0)) + clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_ppnidrreal"), 0) - clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_pphforeign"), 0)
                    .type_pajak = "Ptg"
                    .terimajasadetil_totalincpph = (clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_qty_usage"), 0))
                Else
                    .terimajasadetil_totalforeign = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_totalforeign"), 0) '+ clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_pphforeign"), 0)
                    .terimajasadetil_totalidrreal = (clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_qty_usage"), 0)) + clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_ppnidrreal"), 0) '+ clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_pphidrreal"), 0)
                    .type_pajak = "GU"
                    .terimajasadetil_totalincpph = (clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_idrreal"), 0) * clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_qty_usage"), 0)) + clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimajasadetil_pphidrreal"), 0)
                End If
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptTerimaJasaTalentDetil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, ByVal sptChannel As String, ByVal ket As String)
        Me.DSN = strDSN
        'Me.AssetDsn = strAssetDSN
        Me.sptServer = sptServer
        Me.mChannel_id = sptChannel
        Me.mKet = ket

        InitializeComponent()
    End Sub
End Class

