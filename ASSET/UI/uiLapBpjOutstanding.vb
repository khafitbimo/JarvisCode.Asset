Public Class uiLapBpjOutstanding
    Private Const mUiName As String = "Laporan Penerimaan Asset"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True
    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider
    Private tbl_MstAssetAlias As DataTable = clsDataset.CreateTblMstAssetalias()
    Private tbl_MstAssetAlias_Temp As DataTable = clsDataset.CreateTblMstAssetalias()
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstAssetruangGedung As DataTable = clsDataset.CreateTblMstRuang()
    Private tbl_MstAssetruangLantai As DataTable = clsDataset.CreateTblMstRuang()
    Private tbl_TrnTerimabarang As DataTable = clsDataset.CreateTblTrnTerimabarang()
    Private tbl_MstStrukturunit_id_search As DataTable = clsDataset.CreateTblMstStrukturunit()

    Private tbl_print_BPJinOrder As New DataTable
    Private tbl_print_BPJinOrder_temps As New DataTable
    Private tbl_print_BPJinOrder_Rekap As New DataTable

    Private tbl_Print As DataTable = clsDataset.CreateTblTrnTerimabarangdetil
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptBpjOutstanding
    Private objDatalistDetil As ArrayList

    Private dataRV As Integer
    Private dataOrder As Integer
    Private dataRVonPercent As Decimal

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
    Private _STRUKTURUNIT As Decimal = 5554
#End Region

#Region " Layout & Init UI "

    Private Function InitLayoutUI() As Boolean
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfMain.Dock = DockStyle.Fill
    End Function
#End Region

#Region " Dialoged Control "
#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
            Me._STRUKTURUNIT = Me.GetDecValueFromParameter(objParameters, "STRUKTURUNIT")
        End If

        Me.InitLayoutUI()

        For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
            If tsItem.GetType.ToString = "System.Windows.Forms.ToolStripSeparator" Or (tsItem.Name <> "tbtnLoad") Then
                tsItem.Visible = False
            End If
        Next

        Me.ComboFillkhusus(Me.cboSearchRv_No, "terimabarang_id", "terimabarang_id", Me.tbl_TrnTerimabarang, "as_TrnTerimabarang_select", "", Me._CHANNEL, Me.NumericUpDown1.Value)
        Me.tbl_TrnTerimabarang.DefaultView.Sort = "terimabarang_id"
        Me.ComboFill(Me.cbo_department, "strukturunit_id", "strukturunit_name", tbl_MstStrukturunit_id_search, "ms_MstStrukturUnit_Select", "", "")
        Me.tbl_MstStrukturunit_id_search.DefaultView.Sort = "strukturunit_name"

        Me.cboSearchRv_No.SelectedValue = 0
        Me.cbo_department.SelectedValue = Me._STRUKTURUNIT
        Me.cbo_filter.SelectedItem = "-- Pilih --"
        Me.cboSearch_Source.SelectedItem = "-- Pilih --"
        Me.chk_StartDate.Visible = False
        Me.chk_EndDate.Visible = False
        Me.chkSearch_Filter.Visible = False
        Me.obj_start_date.Visible = False
        Me.obj_end_date.Visible = False
        Me.cbo_filter.Visible = False
        Me.chkSearch_Rekap.Visible = False
        Me.cbo_rekap.Visible = False
        Me.chk_department.Visible = False
        Me.cbo_department.Visible = False
    End Sub

    Private Sub uiLaporanPenerimaanAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If
    End Sub

    Private Function uiLaporanPenerimaanAsset_PrintPreview() As Boolean

        Dim criteria As String = String.Empty

        If Me.cboSearch_Source.SelectedItem = "BPJ Outstanding" Then
            '--------------criteria untuk BPJ Outstanding----------------------------
            criteria = String.Format(" AND order_id = '{0}' AND orderdetil_line = 0", "")
            'Untuk tanggal
            If chkSearchDate.Checked = True Then
                If criteria = String.Empty Then
                    criteria = String.Format(" DAY(asset_tgl) = {0}", Me.cboSearchDate.Value)
                Else
                    criteria &= String.Format(" AND DAY(asset_tgl) = {0}", Me.cboSearchDate.Value)
                End If
            End If
            'Untuk Bulan
            If chkSearchMonth.Checked = True Then
                If criteria = String.Empty Then
                    criteria = String.Format(" MONTH(asset_tgl) = {0}", Me.cboSearchMonth.Value)
                Else
                    criteria &= String.Format(" AND MONTH(asset_tgl) = {0}", Me.cboSearchMonth.Value)
                End If
            End If
            'Untuk Tahun
            If chkSearchYear.Checked = True Then
                If criteria = String.Empty Then
                    criteria = String.Format(" YEAR(asset_tgl) = {0}", Me.cboSearchYear.Value)
                Else
                    criteria &= String.Format(" AND YEAR(asset_tgl) = {0}", Me.cboSearchYear.Value)
                End If
            End If
            'Untuk Terimabarang ID
            If chkSearchRv_No.Checked = True Then
                If criteria = String.Empty Then
                    criteria = String.Format(" terimabarang_id = '{0}'", Me.cboSearchRv_No.SelectedValue)
                Else
                    criteria &= String.Format(" AND terimabarang_id = '{0}'", Me.cboSearchRv_No.SelectedValue)
                End If
            End If
            '-----------------------------------END criteria BPJ Outstanding---------------------------------------'
        Else

            '-------------- Criteria untuk Order in BPJ ----------------------------
            criteria = String.Format(" (left(order_id,2) = 'RO' or left(order_id,2) = 'MO') AND order_canceled = 0")

            If Me.chk_department.Checked = True Then
                criteria &= String.Format(" AND strukturunit_id = {0}", Me.cbo_department.SelectedValue)
            End If

            If Me.cbo_filter.SelectedItem = "Order Date" Then
                '-------------- CRITERIA order_date ----------------------
                If chk_StartDate.Checked = True Then
                    criteria &= String.Format(" AND order_date >= '{0}'", Format(Me.obj_start_date.Value, "MM-dd-yyyy 00:00:00"))
                End If

                If chk_EndDate.Checked = True Then
                    criteria &= String.Format(" AND order_date <= '{0}'", Format(Me.obj_end_date.Value, "MM-dd-yyyy 23:59:59"))
                End If
                '-------------- END CRITERIA Order_date-----------------------------------------------
            ElseIf Me.cbo_filter.SelectedItem = "Shooting Date Start" Then
                '-------------- CRITERIA Shooting Date Start ----------------------
                If chk_StartDate.Checked = True Then
                    criteria &= String.Format(" AND order_utilizeddatestart >= '{0}'", Format(Me.obj_start_date.Value, "MM-dd-yyyy 00:00:00"))
                End If

                If chk_EndDate.Checked = True Then
                    criteria &= String.Format(" AND order_utilizeddatestart <= '{0}'", Format(Me.obj_end_date.Value, "MM-dd-yyyy 23:59:59"))
                End If
                '-------------- END CRITERIA Shooting Date Start-----------------------------------------------

            Else
                '-------------- CRITERIA Shooting Date END ----------------------
                If chk_StartDate.Checked = True Then
                    criteria &= String.Format(" AND order_utilizeddateend >= '{0}'", Format(Me.obj_start_date.Value, "MM-dd-yyyy 00:00:00"))
                End If

                If chk_EndDate.Checked = True Then
                    criteria &= String.Format(" AND order_utilizeddateend <= '{0}'", Format(Me.obj_end_date.Value, "MM-dd-yyyy 23:59:59"))
                End If
                '-------------- END CRITERIA Shooting Date END-----------------------------------------------

            End If

            criteria &= String.Format(" AND strukturunit_id <> 0")

            '-------------- END CRITERIA -----------------------------------------------
        End If
        Me.set_printpreview(criteria)
    End Function

    Private Sub set_printpreview(ByVal criteria As String)
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim found() As DataRow

        Me.tbl_Print.Clear()
        Me.tbl_print_BPJinOrder.Clear()
        Me.tbl_print_BPJinOrder_Rekap.Clear()
        If Me.cboSearch_Source.SelectedItem = "BPJ Outstanding" Then
            dtFiller.DataFill(Me.tbl_Print, "as_TrnTerimabarangdetil_select ", criteria, Me._CHANNEL, Me.NumericUpDown1.Value)
        Else
            dtFiller.DataFillBpjInOrder(Me.tbl_print_BPJinOrder_Rekap, "as_BPJinOrderRekap_Select", Format(Me.obj_start_date.Value, "yyyy-MM-dd 00:00:00"), Format(Me.obj_end_date.Value, "yyyy-MM-dd 23:59:59"), Me._CHANNEL)

            dtFiller.DataFill(Me.tbl_print_BPJinOrder, "as_BPJinOrder_Select", criteria, Me._CHANNEL, Me.NumericUpDown1.Value)
            Me.tbl_print_BPJinOrder_temps = Me.tbl_print_BPJinOrder
            found = Me.tbl_print_BPJinOrder_temps.Select("terimabarang_id <> ''")
            Me.dataRV = found.Length
            Me.dataOrder = Me.tbl_print_BPJinOrder.Rows.Count
            If Me.dataOrder <> 0 Then
                Me.dataRVonPercent = Format((Me.dataRV * 100) / Me.dataOrder, "##0.00")
            Else
                Me.dataRVonPercent = 0.0
            End If
        End If
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
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)
        Dim parRptDataRv As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("dataRV", Me.dataRV)
        Dim parRptDataOrder As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("DataOrder", Me.dataOrder)
        Dim parRptDataRvOnPercent As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("dataRvOnPercent", Me.dataRVonPercent)
        Dim parRptStartDate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("startdate", Format(Me.obj_start_date.Value, "dd MMMM yyyy"))
        Dim parRptEndDate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("enddate", Format(Me.obj_end_date.Value, "dd MMMM yyyy"))

        If Me.cboSearch_Source.SelectedItem = "BPJ Outstanding" Then
            objDatalistHeader = Me.GenerateDataHeader()
            objRdsH.Name = "ASSET_DataSource_clsRptBpjOutstanding"
            objRdsH.Value = objDatalistHeader
            objReportH.ReportEmbeddedResource = "ASSET.RptBpjOutstanding.rdlc"
            objReportH.DataSources.Add(objRdsH)
            objReportViewer.Name = "RvLaporanPenerimaanAsset"
            objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
            objReportViewer.LocalReport.EnableExternalImages = True
            objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})
            objReportViewer.LocalReport.DataSources.Clear()
            objReportViewer.LocalReport.DataSources.Add(objRdsH)
            objReportViewer.RefreshReport()
        Else
            If Me.cbo_rekap.SelectedItem = "Yes" Then
                objDatalistHeader = Me.GenerateDataBPJinOrder()
                objRdsH.Name = "ASSET_DataSource_clsRptBPJinOrder"
                objRdsH.Value = objDatalistHeader
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJinOrderRekap.rdlc"
                objReportH.DataSources.Add(objRdsH)
                objReportViewer.Name = "RvLaporanPenerimaanAsset"
                objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
                objReportViewer.LocalReport.EnableExternalImages = True
                objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptStartDate, parRptEndDate})
                objReportViewer.LocalReport.DataSources.Clear()
                objReportViewer.LocalReport.DataSources.Add(objRdsH)
                objReportViewer.RefreshReport()
            Else
                objDatalistHeader = Me.GenerateDataBPJinOrder()
                objRdsH.Name = "ASSET_DataSource_clsRptBPJinOrder"
                objRdsH.Value = objDatalistHeader
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJinOrder.rdlc"
                objReportH.DataSources.Add(objRdsH)
                objReportViewer.Name = "RvLaporanPenerimaanAsset"
                objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
                objReportViewer.LocalReport.EnableExternalImages = True
                objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptDataRv, parRptDataOrder, parRptDataRvOnPercent})
                objReportViewer.LocalReport.DataSources.Clear()
                objReportViewer.LocalReport.DataSources.Add(objRdsH)
                objReportViewer.RefreshReport()
            End If
        End If


        Me.PnlDfMain.SuspendLayout()
        Me.PnlDfMain.Controls.Remove(Me.RvLaporanPenerimaanAsset)

        Me.RvLaporanPenerimaanAsset = Nothing
        Me.RvLaporanPenerimaanAsset = objReportViewer
        Me.RvLaporanPenerimaanAsset.LocalReport.EnableExternalImages = True

        Me.PnlDfMain.Controls.Add(Me.RvLaporanPenerimaanAsset)
        Me.PnlDfMain.ResumeLayout()
        Me.RvLaporanPenerimaanAsset.Dock = DockStyle.Fill
    End Function
    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptBpjOutstanding
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            objPrintHeader = New DataSource.clsRptBpjOutstanding(Me.DSN)
            With objPrintHeader
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id").ToString, String.Empty)
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                .asset_line = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_line"), 0)
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

            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function
    Private Function GenerateDataBPJinOrder() As ArrayList
        Dim objPrintHeader As DataSource.clsRptBPJinOrder
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        If Me.cbo_rekap.SelectedItem = "Yes" Then
            For i = 0 To Me.tbl_print_BPJinOrder_Rekap.Rows.Count - 1
                objPrintHeader = New DataSource.clsRptBPJinOrder(Me.DSN)
                With objPrintHeader
                    .department = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder_Rekap.Rows(i).Item("department").ToString, String.Empty)
                    .jumlah_order = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder_Rekap.Rows(i).Item("jumlah_order"), 0)
                    .bpj_approved = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder_Rekap.Rows(i).Item("bpj_approved"), 0)
                    .bpj_not_approved = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder_Rekap.Rows(i).Item("bpj_not_approved"), 0)
                    .jumlah_bpj = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder_Rekap.Rows(i).Item("jumlah_bpj"), 0)
                    .jumlah_doc = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder_Rekap.Rows(i).Item("jumlah_doc"), 0)
                    .jumlah_total = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder_Rekap.Rows(i).Item("jumlah_total"), 0)
                    .channel_id = Me._CHANNEL
                    .persentase_bpj = Format(clsUtil.IsDbNull((.jumlah_bpj * 100) / .jumlah_order, 0), "##0.00")
                    .total_presentase_bpj = Format(clsUtil.IsDbNull((Me.dataRV * 100) / .jumlah_total, 0), "##0.00")
                End With
                objDatalistHeader.Add(objPrintHeader)
            Next
        Else
            For i = 0 To Me.tbl_print_BPJinOrder.Rows.Count - 1
                objPrintHeader = New DataSource.clsRptBPJinOrder(Me.DSN)
                With objPrintHeader
                    .order_id = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder.Rows(i).Item("order_id").ToString, String.Empty)
                    .order_date = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder.Rows(i).Item("order_date"), Now())
                    .order_descr = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder.Rows(i).Item("order_descr").ToString, String.Empty)
                    .order_note = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder.Rows(i).Item("order_note").ToString, String.Empty)
                    .terimabarang_id = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                    .terimabarang_appuser = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder.Rows(i).Item("terimabarang_appuser"), 0)
                    .terimabarang_appprc = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder.Rows(i).Item("terimabarang_appprc"), 0)
                    .channel_id = Me._CHANNEL 'clsUtil.IsDbNull(Me.tbl_print_BPJinOrder.Rows(0).Item("channel_id").ToString, String.Empty)
                    .status = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder.Rows(i).Item("status"), String.Empty)
                    .order_utilizeddatestart = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder.Rows(i).Item("order_utilizeddatestart"), Now())
                    .order_utilizeddateend = clsUtil.IsDbNull(Me.tbl_print_BPJinOrder.Rows(i).Item("order_utilizeddateend"), Now())
                End With
                objDatalistHeader.Add(objPrintHeader)
            Next
        End If

        Return objDatalistHeader
    End Function
    Private Sub cboSearch_Source_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearch_Source.SelectionChangeCommitted

        If Me.cboSearch_Source.SelectedItem = "BPJ Outstanding" Then
            Me.chk_StartDate.Visible = False
            Me.chk_EndDate.Visible = False
            Me.obj_start_date.Visible = False
            Me.obj_end_date.Visible = False
            Me.chkSearch_Filter.Visible = False
            Me.cbo_filter.Visible = False
            Me.chkSearch_Rekap.Visible = False
            Me.cbo_rekap.Visible = False
            Me.chk_department.Visible = False
            Me.cbo_department.Visible = False

            Me.chkSearchYear.Visible = True
            Me.cboSearchYear.Visible = True
            Me.chkSearchRv_No.Visible = True
            Me.cboSearchRv_No.Visible = True
            Me.chkSearchDate.Visible = True
            Me.chkSearchMonth.Visible = True
            Me.cboSearchDate.Visible = True
            Me.cboSearchMonth.Visible = True
        Else
            Me.chk_StartDate.Visible = True
            Me.chk_EndDate.Visible = True
            Me.obj_start_date.Visible = True
            Me.obj_end_date.Visible = True
            Me.chkSearch_Filter.Visible = True
            Me.cbo_filter.Visible = True
            Me.cbo_rekap.Visible = True
            Me.chkSearch_Rekap.Visible = True
            Me.cbo_filter.SelectedItem = "-- Pilih --"
            Me.cbo_rekap.SelectedItem = "-- Pilih --"
            Me.chk_department.Visible = True
            Me.cbo_department.Visible = True

            Me.chkSearchYear.Visible = False
            Me.cboSearchYear.Visible = False
            Me.chkSearchRv_No.Visible = False
            Me.cboSearchRv_No.Visible = False
            Me.chkSearchDate.Visible = False
            Me.chkSearchMonth.Visible = False
            Me.cboSearchDate.Visible = False
            Me.cboSearchMonth.Visible = False
        End If
    End Sub

    Private Sub cbo_rekap_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_rekap.SelectionChangeCommitted
        If Me.cbo_rekap.SelectedItem = "-- Pilih --" Or Me.cbo_rekap.SelectedItem = "No" Then
            Me.cbo_filter.Enabled = True
            Me.cbo_department.Enabled = True
            Me.chk_department.Enabled = True
            Me.chk_department.Checked = True
        Else
            Me.cbo_filter.SelectedItem = "-- Pilih --"
            Me.cbo_filter.Enabled = False
            Me.chk_department.Enabled = False
            Me.chk_department.Checked = False
            Me.cbo_department.Enabled = False
        End If
    End Sub

End Class
