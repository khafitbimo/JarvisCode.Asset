Public Class uiLaporanPenerimaanAsset
    Private Const mUiName As String = "Laporan Penerimaan Asset"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True


    
    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_MstAssetAlias As DataTable = clsDataset.CreateTblMstAssetalias()
    Private tbl_MstAssetAlias_Temp As DataTable = clsDataset.CreateTblMstAssetalias()

    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstAssetruangGedung As DataTable = clsDataset.CreateTblMstRuang()
    Private tbl_MstAssetruangLantai As DataTable = clsDataset.CreateTblMstRuang()


    Private tbl_Print As DataTable = clsDataset.CreateTblMstAssetalias
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptLaporanPenerimaanAsset
    Private objDatalistDetil As ArrayList

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
#End Region

#Region " Overrides "
    'Public Overrides Function btnPrint_Click() As Boolean
    '    Me.Cursor = Cursors.WaitCursor
    '    Me.uiLaporanPenerimaanAsset_Print()
    '    Me.Cursor = Cursors.Arrow
    '    Return MyBase.btnPrint_Click()
    'End Function
    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.RvLaporanPenerimaanAsset.Visible = False
        Me.uiLaporanPenerimaanAsset_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
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
        End If

        Me.InitLayoutUI()
        For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
            If tsItem.GetType.ToString = "System.Windows.Forms.ToolStripSeparator" Or (tsItem.Name <> "tbtnLoad") Then
                tsItem.Visible = False
            End If
        Next
        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then

        '    Dim dummyparameter As String = "CHANNEL=TTV;"
        '    objParameters = Me.GetParameterCollection(dummyparameter)
        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
        'End If

        Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", Me.tbl_MstChannelSearch, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'")
        Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_id"
        Me.ComboFill(Me.cboSearchGedung, "gedung_name", "gedung_name", Me.tbl_MstAssetruangGedung, "as_MstRuang_SelectGedung", _CHANNEL)
        Me.tbl_MstAssetruangGedung.DefaultView.Sort = "gedung_name"
        Me.ComboFillAngka(Me.ASSET_DSN, Me.cboSearchLantai, "ruang_lantai", "ruang_lantai", Me.tbl_MstAssetruangLantai, "as_MstRuang_SelectLantai", _CHANNEL)
        Me.tbl_MstAssetruangLantai.DefaultView.Sort = "ruang_lantai"

        Me.cboSearchChannel.SelectedValue = Me._CHANNEL
        Me.cboSearchDepartment.SelectedItem = "-- PILIH --"

    End Sub



    Private Sub uiLaporanPenerimaanAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If

    End Sub

    'Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
    '    Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
    '    Dim stream As System.IO.Stream
    '    Dim deviceInfo As String = _
    '    "<DeviceInfo>" & _
    '    "  <OutputFormat>EMF</OutputFormat>" & _
    '    "  <PageWidth>11.69in</PageWidth>" & _
    '    "  <PageHeight>8.27in</PageHeight>" & _
    '    "  <MarginTop>0.4in</MarginTop>" & _
    '    "  <MarginLeft>0.2in</MarginLeft>" & _
    '    "  <MarginRight>0.2in</MarginRight>" & _
    '    "  <MarginBottom>0.4in</MarginBottom>" & _
    '    "</DeviceInfo>"

    '    m_streams = New List(Of System.IO.Stream)()
    '    report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
    '    For Each stream In m_streams
    '        stream.Position = 0
    '    Next
    'End Sub
    'Private Function CreateStream _
    '(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As System.Text.Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) _
    'As System.IO.Stream
    '    Dim stream As System.IO.Stream = New System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory & "Temp" & name & "." & fileNameExtension, System.IO.FileMode.Create)

    '    m_streams.Add(stream)

    '    Return stream
    'End Function
    'Private Sub PrintPage(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
    '    Dim pageImage As New System.Drawing.Imaging.Metafile(m_streams(m_currentPageIndex))

    '    ev.Graphics.DrawImage(pageImage, ev.PageBounds)
    '    m_currentPageIndex += 1
    '    ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    'End Sub
    'Private Sub Print()
    '    Dim printDoc As New System.Drawing.Printing.PrintDocument()
    '    Dim printSet As New System.Drawing.Printing.PrinterSettings
    '    'Const printerName As String = "Microsoft Office Document Image Writer"
    '    Dim printerName As String = printSet.PrinterName

    '    If m_streams Is Nothing Or m_streams.Count = 0 Then
    '        Return
    '    End If
    '    printDoc.PrinterSettings.PrinterName = printerName
    '    printDoc.DefaultPageSettings.Landscape = True
    '    If Not printDoc.PrinterSettings.IsValid Then
    '        Dim msg As String = String.Format("Can't find printer ""{0}"".", printerName)
    '        Console.WriteLine(msg)
    '        Return
    '    End If
    '    AddHandler printDoc.PrintPage, AddressOf PrintPage
    '    printDoc.Print()
    'End Sub
    'Private Function uiLaporanPenerimaanAsset_Print() As Boolean

    '    Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
    '    Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
    '    Dim objDatalistHeader As ArrayList = New ArrayList()
    '    Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)


    '    Dim criteria As String = String.Empty


    '    '--------------criteria----------------------------
    '    If chkSearchChannel.Checked = True Then
    '        criteria = String.Format(" channel_id = '{0}'", Me._CHANNEL)
    '    End If

    '    'Untuk Bulan
    '    If chkSearchMonth.Checked = True Then
    '        If criteria = String.Empty Then
    '            criteria = String.Format(" MONTH(asset_tgl) = {0}", Me.cboSearchMonth.Value)
    '        Else
    '            criteria &= String.Format(" AND MONTH(asset_tgl) = {0}", Me.cboSearchMonth.Value)
    '        End If
    '    End If

    '    'Untuk Tahun
    '    If chkSearchYear.Checked = True Then
    '        If criteria = String.Empty Then
    '            criteria = String.Format(" YEAR(asset_tgl) = {0}", Me.cboSearchYear.Value)
    '        Else
    '            criteria &= String.Format(" AND YEAR(asset_tgl) = {0}", Me.cboSearchYear.Value)
    '        End If
    '    End If

    '    'Untuk lantai
    '    If chkSearchLantai.Checked = True Then
    '        If criteria = String.Empty Then
    '            criteria = String.Format(" Lt = {0}", Me.cboSearchLantai.SelectedValue)
    '        Else
    '            criteria &= String.Format(" AND Lt = {0}", Me.cboSearchLantai.SelectedValue)
    '        End If
    '    End If

    '    'Untuk gedung
    '    If chkSearchGedung.Checked = True Then
    '        If criteria = String.Empty Then
    '            criteria = String.Format(" Gdg = '{0}'", Me.cboSearchGedung.SelectedValue)
    '        Else
    '            criteria &= String.Format(" AND Gdg = '{0}'", Me.cboSearchGedung.SelectedValue)
    '        End If
    '    End If

    '    'Untuk department
    '    If chkSearchDepartment.Checked = True Then
    '        Dim strukturunit_id As Decimal = 0

    '        If Me.cboSearchDepartment.SelectedItem = "Art Dept(ART)" Then
    '            strukturunit_id = "5555"
    '        ElseIf Me.cboSearchDepartment.SelectedItem = "ArtProp(ArP)" Then
    '            strukturunit_id = "5566"
    '        ElseIf Me.cboSearchDepartment.SelectedItem = "ArtWardrobe(ArW)" Then
    '            strukturunit_id = "5565"
    '        ElseIf Me.cboSearchDepartment.SelectedItem = "IT(Department(ITE)" Then
    '            strukturunit_id = "5517"
    '        ElseIf Me.cboSearchDepartment.SelectedItem = "Technical Services Dept (TSV)" Then
    '            strukturunit_id = "5554"
    '        Else
    '            strukturunit_id = "0"
    '        End If

    '        If criteria = String.Empty Then
    '            criteria = String.Format(" strukturunit_id = {0}", strukturunit_id)
    '        Else
    '            criteria &= String.Format(" AND strukturunit_id = {0}", strukturunit_id)
    '        End If
    '    End If

    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
    '    Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

    '    Me.tbl_Print.Clear()
    '    dtFiller.DataFill(Me.tbl_Print, "as_MstAssetAlias_Select", criteria, Me._CHANNEL, Me.NumericUpDown1.Value)

    '    objDatalistHeader = Me.GenerateDataHeader()

    '    objRdsH.Name = "ASSET_DataSource_clsRptLaporanPenerimaanAsset"
    '    objRdsH.Value = objDatalistHeader

    '    objReportH.ReportEmbeddedResource = "ASSET.RptLaporanPenerimaanAsset.rdlc"
    '    objReportH.DataSources.Add(objRdsH)
    '    objReportH.EnableExternalImages = True
    '    objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})

    '    Export(objReportH)

    '    m_currentPageIndex = 0
    '    Print()
    'End Function

    Private Function uiLaporanPenerimaanAsset_PrintPreview() As Boolean

        Dim criteria As String = String.Format(" is_useable = 0")


        '--------------criteria----------------------------
        If chkSearchChannel.Checked = True Then
            criteria &= String.Format(" AND channel_id = '{0}'", Me._CHANNEL)
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

        'Untuk lantai
        If chkSearchLantai.Checked = True Then
            If criteria = String.Empty Then
                criteria = String.Format(" Lt = {0}", Me.cboSearchLantai.SelectedValue)
            Else
                criteria &= String.Format(" AND Lt = {0}", Me.cboSearchLantai.SelectedValue)
            End If
        End If

        'Untuk gedung
        If chkSearchGedung.Checked = True Then
            If criteria = String.Empty Then
                criteria = String.Format(" Gdg = '{0}'", Me.cboSearchGedung.SelectedValue)
            Else
                criteria &= String.Format(" AND Gdg = '{0}'", Me.cboSearchGedung.SelectedValue)
            End If
        End If

        'Untuk department
        If chkSearchDepartment.Checked = True Then
            Dim strukturunit_id As Decimal = 0

            If Me.cboSearchDepartment.SelectedItem = "Art Dept (ART)" Then
                strukturunit_id = "5555"
            ElseIf Me.cboSearchDepartment.SelectedItem = "ArtProp(ArP)" Then
                strukturunit_id = "5566"
            ElseIf Me.cboSearchDepartment.SelectedItem = "ArtWardrobe(ArW)" Then
                strukturunit_id = "5565"
            ElseIf Me.cboSearchDepartment.SelectedItem = "IT Department (ITE)" Then
                strukturunit_id = "5517"
            ElseIf Me.cboSearchDepartment.SelectedItem = "Technical Services Dept (TSV)" Then
                strukturunit_id = "5554"
            Else
                strukturunit_id = "0"
            End If

            If criteria = String.Empty Then
                criteria = String.Format(" strukturunit_id = {0}", strukturunit_id)
            Else
                criteria &= String.Format(" AND strukturunit_id = {0}", strukturunit_id)
            End If
        End If



        '--------------------------------------------------------------------------'

        Me.set_printpreview(criteria)
    End Function
    Private Sub set_printpreview(ByVal criteria As String)
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        Me.tbl_Print.Clear()
        dtFiller.DataFill(Me.tbl_Print, "as_MstAssetAlias_Select", criteria, Me._CHANNEL, Me.NumericUpDown1.Value)

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


        objDatalistHeader = Me.GenerateDataHeader()
        objRdsH.Name = "ASSET_DataSource_clsRptLaporanPenerimaanAsset"
        objRdsH.Value = objDatalistHeader
        objReportH.ReportEmbeddedResource = "ASSET.RptLaporanPenerimaanAsset.rdlc"
        objReportH.DataSources.Add(objRdsH)

        objReportViewer.Name = "RvLaporanPenerimaanAsset"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

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
        Dim objPrintHeader As DataSource.clsRptLaporanPenerimaanAsset
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
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
                .start_depre_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("start_depre_dt"), Now())
                .end_depre_dt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("end_depre_dt"), Now())
            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

End Class

