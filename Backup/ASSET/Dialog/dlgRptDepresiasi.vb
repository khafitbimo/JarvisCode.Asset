Public Class dlgRptDepre
    Private DSN As String
    Private sptServer As String
    Private tbl_Print As DataTable = clsDataset.CreateTblViewReportDepre
    Private criteria As String
    Private objDatalistDetil As ArrayList

    Private _CHANNEL As String
    Private depresiasi_id As String
    Private user As String
    Private retCriteria As String

    Private sptChannel_ID As String
    Private sptChannel_namereport As String
    Private sptChannel_address As String
    Private sptBulan As String
    Private sptTahun As Int16
    Private sptBulanRekap As Byte
    Private sptTahunRekap As Int16
    Private rekap As Boolean
    Private locations As Boolean

    Private tbl_print_rekap As DataTable = New DataTable
    Private tbl_print_rekapMonth As DataTable = New DataTable

    Private Sub dlgRptDepre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        If criteria = String.Empty Then
            dtFiller.DataFill(Me.tbl_print_rekap, "as_trnDepresiasi_Select_Header", criteria, Me._CHANNEL)
            If Me.tbl_print_rekap.Rows.Count <= 0 Then
                MsgBox("No data to print preview")
                Exit Sub
            End If
        Else
            If Me.rekap = True Then
                criteria = " AND " & criteria
                dtFiller.DataFill(Me.tbl_print_rekapMonth, "as_TrnDepresiasi_Select", criteria, Me._CHANNEL)
            Else
                dtFiller.DataFill(Me.tbl_Print, "as_TrnDepresiasidetil_Select", criteria)

                If Me.tbl_Print.Rows.Count <= 0 Then
                    MsgBox("No data to print preview")
                    Exit Sub
                End If
            End If
        End If


        GenerateReport()
        Me.rvDepresiasi.RefreshReport()
    End Sub

    Private Function GenerateReport() As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.sptServer)


        If criteria = String.Empty Then
            objDatalistHeader = Me.GenerateDataHeaderRekap()
            objRdsH.Name = "ASSET_DataSource_clsRptDepresiasiRekapReport"
            objRdsH.Value = objDatalistHeader
            objReportH.ReportEmbeddedResource = "ASSET.RptDepreRekap.rdlc"
            objReportH.DataSources.Add(objRdsH)

            Me.sptBulan = Me.sptBulanRekap
            Me.sptTahun = Me.sptTahunRekap
        Else
            If Me.rekap = True Then
                objDatalistHeader = Me.GenerateDataHeaderRekapMonth()
                objRdsH.Name = "ASSET_DataSource_clsRptDepresiasi"
                objRdsH.Value = objDatalistHeader
                objReportH.ReportEmbeddedResource = "ASSET.RptDepreRekapMonth.rdlc"
                objReportH.DataSources.Add(objRdsH)
            Else
                If Me.locations = True Then
                    objDatalistHeader = Me.GenerateDataHeader()
                    objRdsH.Name = "ASSET_DataSource_clsRptDepresiasiDetil"
                    objRdsH.Value = objDatalistHeader
                    objReportH.ReportEmbeddedResource = "ASSET.RptDepresiasi_Location.rdlc"
                    objReportH.DataSources.Add(objRdsH)
                Else
                    objDatalistHeader = Me.GenerateDataHeader()
                    objRdsH.Name = "ASSET_DataSource_clsRptDepresiasiDetil"
                    objRdsH.Value = objDatalistHeader
                    objReportH.ReportEmbeddedResource = "ASSET.RptDepre.rdlc"
                    objReportH.DataSources.Add(objRdsH)
                End If
            End If

        End If

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.sptChannel_ID)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_namereport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        Dim parRptBulan As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("bulan", Me.sptBulan)
        Dim parRptTahun As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tahun", Me.sptTahun)



        'AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing

        objReportViewer.Name = "rvDepresiasi"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True


        If criteria = String.Empty Then
            objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptBulan, parRptTahun})
        Else
            If rekap = True Then
                objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})
            Else
                objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptBulan, parRptTahun})
            End If

        End If


        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.SuspendLayout()
        Me.Controls.Remove(Me.rvDepresiasi)

        Me.rvDepresiasi = Nothing
        Me.rvDepresiasi = objReportViewer
        Me.rvDepresiasi.LocalReport.EnableExternalImages = True

        Me.Controls.Add(Me.rvDepresiasi)
        Me.ResumeLayout()
        Me.rvDepresiasi.Dock = DockStyle.Fill
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptDepresiasiDetil
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            'GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptDepresiasiDetil(Me.DSN)
            With objPrintHeader
                .depresiasi_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depresiasi_id").ToString, String.Empty)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_barcode").ToString, String.Empty)
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id").ToString, String.Empty)
                .depresiasi_thn = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depresiasi_thn"), 0)
                .depresiasi_bln = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depresiasi_bln"), 0)
                .asset_strukturunit = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_strukturunit"), 0)
                .asset_kategori = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_kategori").ToString, String.Empty)
                .kategori_time = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("kategori_time"), 0)
                .Jumlah_depre = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Jumlah_depre"), 0)
                .cost_beginning = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("cost_beginning"), 0)
                .cost_additional = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("cost_additional"), 0)
                .cost_deductional = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("cost_deductional"), 0)
                .cost_ending = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("cost_ending"), 0)
                .depre_beginning = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depre_beginning"), 0)
                .depre_additional = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depre_additional"), 0)
                .depre_deductional = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depre_deductional"), 0)
                .depre_ending = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depre_ending"), 0)
                .NBV = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("NBV"), 0)
                .asset_stdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_stdt"), Now())
                .asset_eddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_eddt"), Now())
                .create_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("create_by").ToString, String.Empty)
                .create_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("create_dt"), Now())
                .edit_by = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("edit_by").ToString, String.Empty)
                .edit_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("edit_dt"), Now())
                .asset_tipedepre = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_tipedepre").ToString, String.Empty)
                .depresiasi_remark = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depresiasi_remark").ToString, String.Empty)
                .depresiasi_kali = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("depresiasi_kali"), 0)
                .asset_golpajak = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_golpajak").ToString, String.Empty)
                .tipeitem_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("tipeitem_id").ToString, String.Empty)
                .brand_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("brand_id").ToString, String.Empty)
                .asset_serial = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_serial").ToString, String.Empty)
                .asset_deskripsi = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_deskripsi").ToString, String.Empty)
                .department = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("department").ToString, String.Empty)
                .location = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("location").ToString, String.Empty)

                Me.sptChannel_ID = .channel_id
                Me.sptChannel_namereport = .channel_namereport
                Me.sptChannel_address = .channel_address
                Me.sptBulan = .bulan_string
                Me.sptTahun = .depresiasi_thn

            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Function GenerateDataHeaderRekap() As ArrayList
        Dim objPrintHeader As DataSource.clsRptDepresiasiRekapReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_print_rekap.Rows.Count - 1
            'GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptDepresiasiRekapReport(Me.DSN)
            With objPrintHeader
                .kategoriasset_id = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("kategoriasset_id").ToString, String.Empty)
                .Cost = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Cost"), 0)
                .Additional = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Additional"), 0)
                .Total = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Total"), 0)
                .Depre_Value = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Depre_Value"), 0)
                .Adjusment = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Adjusment"), 0)
                .Accumulation_Depresiasi = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("Accumulation_Depresiasi"), 0)
                .NBV = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("NBV"), 0)
                .channel_id = clsUtil.IsDbNull(Me.tbl_print_rekap.Rows(i).Item("channel_id").ToString, String.Empty)
            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

    Private Function GenerateDataHeaderRekapMonth() As ArrayList
        Dim objPrintHeader As DataSource.clsRptDepresiasi
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_print_rekapMonth.Rows.Count - 1
            'GenerateDataDetail()
            objPrintHeader = New DataSource.clsRptDepresiasi(Me.DSN)
            With objPrintHeader
                .channel_id = Me._CHANNEL
                .depresiasi_id = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depresiasi_id").ToString, String.Empty)
                .depresiasi_tgl = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depresiasi_tgl"), Now())
                .depresiasi_thn = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depresiasi_thn"), 0)
                .depresiasi_bln = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depresiasi_bln"), 0)
                .kategoriasset_id = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("kategoriasset_id").ToString, String.Empty)
                .kategoriasset_time = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("kategoriasset_time"), 0)
                .kategoriasset_depresiasitime = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("kategoriasset_depresiasitime").ToString, String.Empty)
                .kategoriasset_depresiasivalue = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("kategoriasset_depresiasivalue"), 0)
                .total_item = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("total_item"), 0)
                .total_item_depre = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("total_item_depre"), 0)
                .cost_beginning = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("cost_beginning"), 0)
                .cost_additional = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("cost_additional"), 0)
                .cost_deductional = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("cost_deductional"), 0)
                .cost_ending = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("cost_ending"), 0)
                .depre_beginning = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depre_beginning"), 0)
                .depre_additional = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depre_additional"), 0)
                .depre_deductional = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depre_deductional"), 0)
                .depre_ending = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("depre_ending"), 0)
                .lock = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("lock"), 0)
                .lock_login = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("lock_login").ToString, String.Empty)
                .lock_dt = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("lock_dt"), Now())
                .post = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("post"), 0)
                .post_login = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("post_login").ToString, String.Empty)
                .postdate = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("postdate"), Now())
                .NBV = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("NBV"), 0)
                .create_by = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("create_by").ToString, String.Empty)
                .create_dt = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("create_dt"), Now())
                .edit_by = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("edit_by").ToString, String.Empty)
                .edit_dt = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("edit_dt"), Now())
                .used_by = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("used_by").ToString, String.Empty)
                .used_dt = clsUtil.IsDbNull(Me.tbl_print_rekapMonth.Rows(i).Item("used_dt"), Now())

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

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, _
            ByVal sptChannel As String, ByVal user As String, ByVal strCriteria As String, _
        ByVal sptBulanRekap As Byte, ByVal sptTahunRekap As Int16, ByVal rekap As Boolean, _
        ByVal Location As Boolean)

        DSN = strDSN
        Me.sptServer = sptServer
        Me._CHANNEL = sptChannel
        'Me.depresiasi_id = sptDepresiasi_id
        Me.user = user
        Me.sptBulanRekap = sptBulanRekap
        Me.sptTahunRekap = sptTahunRekap
        Me.retCriteria = strCriteria
        Me.rekap = rekap
        Me.locations = Location

        InitializeComponent()
    End Sub
End Class

