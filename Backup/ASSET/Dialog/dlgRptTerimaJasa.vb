Public Class dlgRptTerimaJasa

    Private DSN As String
    Private sptServer As String

    Private criteria As String
    Private objDatalistDetil As ArrayList
    Private order As String
    Private channel_id As String
    Private terimaBarang_id As String

    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptTerimaBarang_ID As String

    Private tbl_MstSkill As DataTable = clsDataset.CreateTblMstSkill()
    Private tbl_requestdetil As DataTable = clsDataset.CreateTblRequestdetilSelect()
    Private tbl_request As DataTable = clsDataset.CreateTblTrnRequest()
    Private tbl_requesteps As DataTable = clsDataset.CreateTblTrnRequestdetilEps()
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnTerimabarang
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnTerimabarangdetil
    Private tbl_MstTrnOrder As DataTable = clsDataset.CreateTblTrnOrder()
    'Private sptStrukturUnit As String

    Private Sub dlgRptTrnTerimaBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        dtFiller.DataFill(Me.tbl_Print, "as_TrnTerimabarang_Select", criteria, channel_id, Top)

        GenerateReport()
        Me.rvTerimaJasa.RefreshReport()
    End Sub

    Private Function GenerateReport() As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.sptServer)
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Dim objDatalistHeader As ArrayList = New ArrayList()



        objDatalistHeader = Me.GenerateDataHeader()

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.sptChannel_ID)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptTerimaBarang_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("terimabarang_id", Me.sptTerimaBarang_ID)
        'Dim parRptStrukturUnit As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("strukturUnit", Me.sptStrukturUnit)
        If Mid(Me.order, 1, 2) = "TO" Then
            objRdsH.Name = "ASSET_DataSource_clsRptBarang"
            objRdsH.Value = objDatalistHeader
            objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasa_Talent.rdlc"
            objReportH.DataSources.Add(objRdsH)
        ElseIf Mid(Me.order, 1, 2) = "EO" Then
            objRdsH.Name = "ASSET_DataSource_clsRptBarang"
            objRdsH.Value = objDatalistHeader
            objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasa_Editing.rdlc"
            objReportH.DataSources.Add(objRdsH)
        Else
            objRdsH.Name = "ASSET_DataSource_clsRptBarang"
            objRdsH.Value = objDatalistHeader
            objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasa.rdlc"
            objReportH.DataSources.Add(objRdsH)
        End If

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
        Dim i As Integer
        Dim order_id As String
        Dim request_id As String
        Dim objPrintHeader As DataSource.clsRptBarang
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)




        Me.tbl_MstTrnOrder.Clear()
        For i = 0 To Me.tbl_Print.Rows.Count - 1

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
                order_id = String.Format("order_id='{0}'", .order_id)
                If Mid(.order_id, 1, 2) = "TO" Then
                    'buat narik shooting date

                    dtFiller.DataFillLimit(Me.tbl_MstTrnOrder, "pr_TrnOrder_Select", order_id, 1)
                    .shooting_date = clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("order_utilizeddatestart").ToString, String.Empty)

                    'buat narik producer dan talent
                    request_id = String.Format("request_id='{0}'", clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("request_id").ToString, String.Empty))
                    dtFiller.DataFill(Me.tbl_request, " cq_TrnRequest_Select", request_id)
                    .user_pic = clsUtil.IsDbNull(Me.tbl_request.Rows(0).Item("request_userpic").ToString, String.Empty)
                    .used_by = clsUtil.IsDbNull(Me.tbl_request.Rows(0).Item("request_usedby").ToString, String.Empty)
                    .budget_id = clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("budget_id"), String.Empty)

                ElseIf Mid(.order_id, 1, 2) = "EO" Then
                    dtFiller.DataFillLimit(Me.tbl_MstTrnOrder, "eo_TrnEditing_Order_Select", order_id, 1)
                    .budget_id = clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("budget_id"), String.Empty)

                Else 'If Mid(.order_id, 1, 2) = "MO" Then
                    dtFiller.DataFillLimit(Me.tbl_MstTrnOrder, "pr_TrnOrder_Select", order_id, 1)
                    .budget_id = clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("budget_id").ToString, String.Empty)
                End If


                '.budget_name = clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("budget_name"), String.Empty)

                Me.sptChannel_ID = .channel_id
                Me.sptChannel_nameReport = .channel_namereport
                Me.sptChannel_address = .channel_address
                Me.sptTerimaBarang_ID = .terimabarang_id
                Me.order = .order_id



                If Mid(.order_id, 1, 2) = "TO" Or Mid(.order_id, 1, 2) = "TQ" Then
                    dtFiller.DataFill(Me.tbl_PrintDetil, "as_TrnTerimabarangdetilTO_select ", criteria, channel_id, Top)
                ElseIf Mid(.order_id, 1, 2) = "EO" Or Mid(.order_id, 1, 2) = "EQ" Then
                    dtFiller.DataFill(Me.tbl_PrintDetil, "as_TrnTerimabarangdetilEO_select ", criteria, channel_id, Top)
                Else
                    dtFiller.DataFill(Me.tbl_PrintDetil, "as_TrnTerimabarangdetil_select ", criteria, channel_id, Top)
                End If
                GenerateDataDetail()
            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptBarangDetil
        Dim i, k, a, b As Integer
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim tbl_eps_talent As DataTable = New DataTable
        Dim tbl_shift_editing As DataTable = New DataTable
        'Dim durasi1, durasi2, durasi3 As String


        'Dim criteria_peran As String
        'Dim code As Integer
        'Dim request_id As String
        'Dim order As String


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
                .ukuran_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ukuran_id").ToString, String.Empty)
                .asset_eps = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("usage"), 0)
                .asset_qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_qty"), 0)
                'count jumlah episode dan qty talent
                If Mid(Me.order, 1, 2) = "TO" Then
                    tbl_eps_talent.Clear()
                    dtFiller.DataFill(tbl_eps_talent, "as_TrnTerimajasaepstalent_Select", String.Format("order_id = '{0}' and orderdetil_line='{1}' and terimabarang_check=1", Me.tbl_PrintDetil.Rows(i).Item("order_id"), Me.tbl_PrintDetil.Rows(i).Item("orderdetil_line")))
                    ' ''For j = 0 To tbl_eps_talent.Rows.Count - 1
                    ' ''    episode = clsUtil.IsDbNull(tbl_eps_talent.Rows(j).Item("terimabarang_check"), 0)
                    ' ''    qty = clsUtil.IsDbNull(tbl_eps_talent.Rows(j).Item("terimabarang_qty"), 0)
                    ' ''    .asset_eps += episode
                    ' ''    .asset_qty += qty
                    ' ''Next

                    'untuk editing order
                ElseIf Mid(Me.order, 1, 2) = "EO" Then
                    tbl_shift_editing.Clear()
                    tbl_eps_talent.Clear()
                    dtFiller.DataFill(tbl_shift_editing, "as_TrnTerimajasashiftediting_Select", String.Format("order_id = '{0}' and orderdetil_line='{1}' and terimabarang_check=1", Me.tbl_PrintDetil.Rows(i).Item("order_id"), Me.tbl_PrintDetil.Rows(i).Item("orderdetil_line")))
                    dtFiller.DataFill(tbl_eps_talent, "eo_TrnEditing_Orderdetil_Select", String.Format("order_id = '{0}'  and orderdetil_line='{1}' ", tbl_shift_editing.Rows(0).Item("order_id"), tbl_shift_editing.Rows(0).Item("orderdetil_line")))
                    For k = 0 To tbl_shift_editing.Rows.Count - 1
                        .shift1 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("shift1"), 0)
                        .shift2 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("shift2"), 0)
                        .shift3 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("shift3"), 0)
                        .boot1 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("boot1"), 0)
                        .boot2 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("boot2"), 0)
                        .boot3 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("boot3"), 0)
                        .eps_usage1_start = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage1_start").ToString, String.Empty)
                        .eps_usage1_end = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage1_end").ToString, String.Empty)
                        .eps_usage2_start = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage2_start").ToString, String.Empty)
                        .eps_usage2_end = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage2_end").ToString, String.Empty)
                        .eps_usage3_start = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage3_start").ToString, String.Empty)
                        .eps_usage3_end = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage3_end").ToString, String.Empty)
                        .edit_date = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("terimabarang_date").ToString, String.Empty)

                        'durasi1 = TimeDiff(.eps_usage1_start, .eps_usage1_end)
                        'durasi2 = TimeDiff(.eps_usage2_start, .eps_usage2_end)
                        'durasi3 = TimeDiff(.eps_usage3_start, .eps_usage3_end)


                        .eps_usage_total = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_total_usage").ToString, String.Empty)
                        .Episode = clsUtil.IsDbNull(tbl_eps_talent.Rows(0).Item("orderdetil_eps").ToString, String.Empty)
                        b = 0
                        For a = 0 To Len(.Episode)
                            b += 1
                            If IsNumeric(Mid(.Episode, b)) Then
                                .Episode = Mid(.Episode, b)
                            End If
                        Next
                    Next
                Else
                    .asset_eps = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_eps").ToString, String.Empty)
                    .asset_qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_qty"), 0)
                End If

                .wo_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("wo_id").ToString, String.Empty)
                .inputby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("inputby").ToString, String.Empty)
                .inputdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("inputdt"), Now())
                .editby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("editby").ToString, String.Empty)
                .editdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("editdt"), Now())
                .usedby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("usedby").ToString, String.Empty)
                .order_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("order_id").ToString, String.Empty)

                'buat narik peran 
                'order = String.Format("order_id='{0}'", .order_id)
                'dtFiller.DataFillLimit(Me.tbl_MstTrnOrder, "pr_TrnOrder_Select", order, 1)
                'request_id = String.Format("request_id='{0}'", clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("request_id").ToString, String.Empty))
                'dtFiller.DataFill(Me.tbl_requestdetil, "pr_TrnRequestdetil_Select", request_id)
                'code = clsUtil.IsDbNull(Me.tbl_requestdetil.Rows(0).Item("requestdetil_bal"), 0)
                'criteria_peran = String.Format("code = '{0}' ", code)
                'dtFiller.DataFill(Me.tbl_MstSkill, "ms_MstSkill_Select", criteria_peran)
                'If tbl_MstSkill.Rows.Count = 0 Then
                '    .Peran = String.Empty
                'Else
                '    .Peran = clsUtil.IsDbNull(Me.tbl_MstSkill.Rows(0).Item("name").ToString, String.Empty)
                'End If

                'dtFiller.DataFillLimit(Me.tbl_requesteps, "tq_TrnRequestdetileps_Select", request_id)

                '.Episode = clsUtil.IsDbNull(Me.tbl_requesteps.Rows(0).Item("requestdetil_eps").ToString, String.Empty)

            End With
            objDatalistDetil.Add(objDetil)
        Next
        If Mid(Me.order, 1, 2) = "EO" Then
            'fake data
            For i = 0 To 27 - Me.tbl_PrintDetil.Rows.Count

                objDetil = New DataSource.clsRptBarangDetil(Me.DSN)
                With objDetil

                    .shift1 = 0
                End With
                objDatalistDetil.Add(objDetil)
            Next
        End If

    End Sub

    'Private Function TimeDiff(ByVal Time1 As String, ByVal Time2 As String) As String
    '    Dim MinsDiff As String
    '    Dim TheHours As String

    '    MinsDiff = DateDiff("n", Time1, Time2)

    '    'If midnight is between times

    '    MinsDiff = IIf(MinsDiff < 0, MinsDiff + 1440, MinsDiff)

    '    TheHours = Format(Int(MinsDiff / 60), "00")

    '    MinsDiff = Format(MinsDiff Mod 60, "00")

    '    TimeDiff = TheHours & ":" & MinsDiff

    'End Function
    'Private Function TimeTotalEdit(ByVal Time1 As String, ByVal Time2 As String, ByVal Time3 As String) As String
    '    Dim thehours, theminute, totalminute As String
    '    Dim h1, h2, h3, s1, s2, s3 As Integer

    '    'change all value into minute

    '    h1 = Mid(Time1, 1, 2) * 60
    '    h2 = Mid(Time2, 1, 2) * 60
    '    h3 = Mid(Time3, 1, 2) * 60
    '    s1 = Mid(Time1, 4, 5)
    '    s2 = Mid(Time2, 4, 5)
    '    s3 = Mid(Time3, 4, 5)

    '    totalminute = (h1 + h2 + h3) + (s1 + s2 + s3)
    '    thehours = Format(Int(totalminute / 60), "00")
    '    theminute = Format(totalminute Mod 60, "00")
    '    TimeTotalEdit = thehours & ":" & theminute
    'End Function
    Public Function SetIDCriteria(ByVal str As String) As Boolean
        Me.criteria = str
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptBarangDetil", objDatalistDetil))
    End Sub

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, ByVal channel_id As String, ByVal top As Integer, ByVal retTerimaBarang As String)

        Me.Top = top
        Me.DSN = strDSN
        Me.sptServer = sptServer
        Me.channel_id = channel_id
        Me.terimaBarang_id = retTerimaBarang

        InitializeComponent()
    End Sub
End Class
