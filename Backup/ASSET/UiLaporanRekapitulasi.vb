Public Class UiLaporanRekapitulasi
    Private Const mUiName As String = "Laporan Rekapitulasi"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_mstKategoriitem As DataTable = clsDataset.CreateTblMstKategoriitem

    Private tbl_Print As DataTable = New DataTable

    Private kondisi As String

    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
   Private objDatalistDetil As ArrayList

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
#End Region

#Region " Overrides "
    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If Me.cboReportName.SelectedItem = "-- Pilih --" Then
            MsgBox("Please choice your report name")
            Me.Cursor = Cursors.Arrow
            Exit Function
        End If
        Me.RvLaporanRekapitulasiAsset.Visible = False
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

    Private Sub uiLaporanPenerimaanAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then

        '    Dim dummyparameter As String = "CHANNEL=TTV;"
        '    objParameters = Me.GetParameterCollection(dummyparameter)
        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
        'End If

        For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
            If tsItem.GetType.ToString = "System.Windows.Forms.ToolStripSeparator" Or (tsItem.Name <> "tbtnLoad") Then
                tsItem.Visible = False
            End If
        Next

        Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", Me.tbl_MstChannelSearch, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'")
        Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_id"

        Me.ComboFill(Me.cboSearchKategori, "kategoriitem_id", "kategoriitem_id", Me.tbl_mstKategoriitem, "as_MstKategoriitem_Select", "  ")
        Me.tbl_mstKategoriitem.DefaultView.Sort = "kategoriitem_id"

        Me.cboSearchChannel.SelectedValue = Me._CHANNEL
        Me.cboSearchKategori.SelectedValue = 0
        Me.cboReportName.SelectedItem = "-- Pilih --"

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
    '    Dim stream As System.IO.Stream = New System.IO.FileStream("C:\TransBrowser\Temp" & name & "." & fileNameExtension, System.IO.FileMode.Create)

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
    '    Dim parRptTgl As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tgl", Format(Me.obj_Bookasset_date.Value, "dd/MM/yyyy"))


    '    Dim criteria As String = String.Empty
    '    kondisi = "Blank"
    '    If Me.cboReportName.SelectedItem = "Rekapitulasi Booking" Then
    '        '--------------criteria Rekapitulasi Booking----------------------------
    '        If chkSearchChannel.Checked = True Then
    '            criteria &= String.Format(" channel_id = '{0}'", Me._CHANNEL)
    '        End If
    '        'Untuk Tanggal
    '        If chkSearchDate.Checked = True Then
    '            If criteria = String.Empty Then
    '                criteria = String.Format(" bookasset_startdt < '{0}' AND bookasset_enddt > '{1}'", Me.obj_Bookasset_date.Value, Me.obj_Bookasset_date.Value)
    '            Else
    '                criteria &= String.Format(" AND bookasset_startdt <= '{0}' AND bookasset_enddt >= '{1}'", Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"), Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"))
    '            End If
    '        End If
    '        'Untuk Program
    '        If chkSearchKategori.Checked = True Then
    '            If criteria = String.Empty Then
    '                criteria = String.Format(" kategori = '{0}'", Me.cboSearchKategori.SelectedValue)
    '            Else
    '                criteria &= String.Format(" AND kategori = '{0}'", Me.cboSearchKategori.SelectedValue)
    '            End If
    '            kondisi = "Not Blank"
    '        End If

    '        If criteria = String.Empty Then
    '            criteria = String.Format(" status = 0")
    '        Else
    '            criteria &= String.Format(" AND status = 0")
    '        End If
    '        '--------------------------------------------------------------------------'
    '    ElseIf Me.cboReportName.SelectedItem = "Summary Rekapitulasi" Then

    '        '--------------Criteria Summary Rekapitulasi----------------------------
    '        If chkSearchChannel.Checked = True Then
    '            criteria &= String.Format(" channel_id = '{0}'", Me._CHANNEL)
    '        End If
    '        'Untuk Tanggal
    '        If chkSearchDate.Checked = True Then
    '            If criteria = String.Empty Then
    '                criteria = String.Format(" outasset_startdt < '{0}' AND outasset_enddt > '{1}'", Me.obj_Bookasset_date.Value, Me.obj_Bookasset_date.Value)
    '            Else
    '                criteria &= String.Format(" AND outasset_startdt <= '{0}' AND outasset_enddt >= '{1}'", Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"), Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"))
    '            End If
    '        End If
    '        'Untuk Program
    '        If chkSearchKategori.Checked = True Then
    '            If criteria = String.Empty Then
    '                criteria = String.Format(" kategoriitem_id = '{0}'", Me.cboSearchKategori.SelectedValue)
    '            Else
    '                criteria &= String.Format(" AND kategoriitem_id = '{0}'", Me.cboSearchKategori.SelectedValue)
    '            End If
    '            kondisi = "Not Blank"
    '        End If
    '        '--------------------------------------------------------------------------'

    '    Else

    '        '--------------criteria Rekapitulasi OutGoing----------------------------
    '        If chkSearchChannel.Checked = True Then
    '            criteria &= String.Format(" channel_id = '{0}'", Me._CHANNEL)
    '        End If
    '        'Untuk Tanggal
    '        If chkSearchDate.Checked = True Then
    '            If criteria = String.Empty Then
    '                criteria = String.Format(" outasset_startdt < '{0}' AND outasset_enddt > '{1}'", Me.obj_Bookasset_date.Value, Me.obj_Bookasset_date.Value)
    '            Else
    '                criteria &= String.Format(" AND outasset_startdt <= '{0}' AND outasset_enddt >= '{1}'", Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"), Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"))
    '            End If
    '        End If
    '        'Untuk Program
    '        If chkSearchKategori.Checked = True Then
    '            If criteria = String.Empty Then
    '                criteria = String.Format(" kategori = '{0}'", Me.cboSearchKategori.SelectedValue)
    '            Else
    '                criteria &= String.Format(" AND kategori = '{0}'", Me.cboSearchKategori.SelectedValue)
    '            End If
    '            kondisi = "Not Blank"
    '        End If
    '        '--------------------------------------------------------------------------'

    '    End If

    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
    '    Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

    '    If Me.cboReportName.SelectedItem = "Rekapitulasi Booking" Then
    '        Me.tbl_Print.Clear()
    '        dtFiller.DataFill(Me.tbl_Print, "as_TrnBookAssetRekap_Select", criteria)
    '    ElseIf Me.cboReportName.SelectedItem = "Summary Rekapitulasi" Then
    '        Me.tbl_Print.Clear()
    '        dtFiller.DataFill(Me.tbl_Print, "as_TrnOutBookingAssetRekap_Select", criteria)
    '    Else
    '        Me.tbl_Print.Clear()
    '        dtFiller.DataFill(Me.tbl_Print, "as_TrnOutAssetRekap_Select", criteria)
    '    End If

    '    If Me.cboReportName.SelectedItem = "Rekapitulasi Booking" Then
    '        objDatalistHeader = Me.GenerateDataHeader()
    '        objRdsH.Name = "ASSET_DataSource_clsRptLaporanRekapitulasiAsset"
    '        objRdsH.Value = objDatalistHeader
    '        objReportH.ReportEmbeddedResource = "ASSET.RptLaporanRekapitulasiAsset.rdlc"
    '        objReportH.DataSources.Add(objRdsH)
    '    ElseIf Me.cboReportName.SelectedItem = "Summary Rekapitulasi" Then
    '        objDatalistHeader = Me.GenerateDataHeaderOutBookingGoing()
    '        objRdsH.Name = "ASSET_DataSource_ClsRptLaporanRekapitulasiOutBookingAsset"
    '        objRdsH.Value = objDatalistHeader
    '        objReportH.ReportEmbeddedResource = "ASSET.RptLaporanRekapitulasiOutBookingAsset.rdlc"
    '        objReportH.DataSources.Add(objRdsH)
    '    Else
    '        objDatalistHeader = Me.GenerateDataHeaderOutGoing()
    '        objRdsH.Name = "ASSET_DataSource_clsRptLaporanRekapitulasiOutGoingAsset"
    '        objRdsH.Value = objDatalistHeader
    '        objReportH.ReportEmbeddedResource = "ASSET.RptLaporanRekapitulasiOutAsset.rdlc"
    '        objReportH.DataSources.Add(objRdsH)
    '    End If

    '    Dim parRptKondisi As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("kondisi", Me.kondisi)

    '    objReportH.EnableExternalImages = True
    '    objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptTgl, parRptKondisi})

    '    Export(objReportH)

    '    m_currentPageIndex = 0
    '    Print()
    'End Function

    Private Function uiLaporanPenerimaanAsset_PrintPreview() As Boolean

        Dim criteria As String = String.Empty
        kondisi = "Blank"
        If Me.cboReportName.SelectedItem = "Rekapitulasi Booking" Then
            '--------------criteria Rekapitulasi Booking----------------------------
            If chkSearchChannel.Checked = True Then
                criteria &= String.Format(" channel_id = '{0}'", Me._CHANNEL)
            End If
            'Untuk Tanggal
            If chkSearchDate.Checked = True Then
                If criteria = String.Empty Then
                    criteria = String.Format(" bookasset_startdt < '{0}' AND bookasset_enddt > '{1}'", Me.obj_Bookasset_date.Value, Me.obj_Bookasset_date.Value)
                Else
                    criteria &= String.Format(" AND bookasset_startdt <= '{0}' AND bookasset_enddt >= '{1}'", Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"), Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"))
                End If
            End If
            'Untuk Program
            If chkSearchKategori.Checked = True Then
                If criteria = String.Empty Then
                    criteria = String.Format(" kategori = '{0}'", Me.cboSearchKategori.SelectedValue)
                Else
                    criteria &= String.Format(" AND kategori = '{0}'", Me.cboSearchKategori.SelectedValue)
                End If
                kondisi = "Not Blank"
            End If

            If criteria = String.Empty Then
                criteria = String.Format(" status = 0")
            Else
                criteria &= String.Format(" AND status = 0")
            End If
            '--------------------------------------------------------------------------'
        ElseIf Me.cboReportName.SelectedItem = "Summary Rekapitulasi" Then

            '--------------Criteria Summary Rekapitulasi----------------------------
            If chkSearchChannel.Checked = True Then
                criteria &= String.Format(" channel_id = '{0}'", Me._CHANNEL)
            End If
            'Untuk Tanggal
            If chkSearchDate.Checked = True Then
                If criteria = String.Empty Then
                    criteria = String.Format(" outasset_startdt < '{0}' AND outasset_enddt > '{1}'", Me.obj_Bookasset_date.Value, Me.obj_Bookasset_date.Value)
                Else
                    criteria &= String.Format(" AND outasset_startdt <= '{0}' AND outasset_enddt >= '{1}'", Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"), Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"))
                End If
            End If
            'Untuk Program
            If chkSearchKategori.Checked = True Then
                If criteria = String.Empty Then
                    criteria = String.Format(" kategoriitem_id = '{0}'", Me.cboSearchKategori.SelectedValue)
                Else
                    criteria &= String.Format(" AND kategoriitem_id = '{0}'", Me.cboSearchKategori.SelectedValue)
                End If
                kondisi = "Not Blank"
            End If
            '--------------------------------------------------------------------------'


        Else

            '--------------criteria Rekapitulasi OutGoing----------------------------
            If chkSearchChannel.Checked = True Then
                criteria &= String.Format(" channel_id = '{0}'", Me._CHANNEL)
            End If
            'Untuk Tanggal
            If chkSearchDate.Checked = True Then
                If criteria = String.Empty Then
                    criteria = String.Format(" outasset_startdt < '{0}' AND outasset_enddt > '{1}'", Me.obj_Bookasset_date.Value, Me.obj_Bookasset_date.Value)
                Else
                    criteria &= String.Format(" AND outasset_startdt <= '{0}' AND outasset_enddt >= '{1}'", Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"), Format(Me.obj_Bookasset_date.Value, "MM/dd/yyyy"))
                End If
            End If
            'Untuk Program
            If chkSearchKategori.Checked = True Then
                If criteria = String.Empty Then
                    criteria = String.Format(" kategori = '{0}'", Me.cboSearchKategori.SelectedValue)
                Else
                    criteria &= String.Format(" AND kategori = '{0}'", Me.cboSearchKategori.SelectedValue)
                End If
                kondisi = "Not Blank"
            End If
            '--------------------------------------------------------------------------'

        End If
        Me.set_printpreview(criteria)
    End Function
    Private Sub set_printpreview(ByVal criteria As String)
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        If Me.cboReportName.SelectedItem = "Rekapitulasi Booking" Then
            Me.tbl_Print.Clear()
            dtFiller.DataFill(Me.tbl_Print, "as_TrnBookAssetRekap_Select", criteria)
        ElseIf Me.cboReportName.SelectedItem = "Summary Rekapitulasi" Then
            Me.tbl_Print.Clear()
            dtFiller.DataFill(Me.tbl_Print, "as_TrnOutBookingAssetRekap_Select", criteria)
        Else
            Me.tbl_Print.Clear()
            dtFiller.DataFill(Me.tbl_Print, "as_TrnOutAssetRekap_Select", criteria)
        End If

        GenerateReport()
        Me.RvLaporanRekapitulasiAsset.RefreshReport()

    End Sub
    Private Function GenerateReport() As Boolean
        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)
        Dim parRptTgl As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("tgl", Format(Me.obj_Bookasset_date.Value, "dd/MM/yyyy"))
        Dim parRptKondisi As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("kondisi", Me.kondisi)

        If Me.cboReportName.SelectedItem = "Rekapitulasi Booking" Then
            objDatalistHeader = Me.GenerateDataHeader()
            objRdsH.Name = "ASSET_DataSource_clsRptLaporanRekapitulasiAsset"
            objRdsH.Value = objDatalistHeader
            objReportH.ReportEmbeddedResource = "ASSET.RptLaporanRekapitulasiAsset.rdlc"
            objReportH.DataSources.Add(objRdsH)
        ElseIf Me.cboReportName.SelectedItem = "Summary Rekapitulasi" Then
            objDatalistHeader = Me.GenerateDataHeaderOutBookingGoing()
            objRdsH.Name = "ASSET_DataSource_ClsRptLaporanRekapitulasiOutBookingAsset"
            objRdsH.Value = objDatalistHeader
            objReportH.ReportEmbeddedResource = "ASSET.RptLaporanRekapitulasiOutBookingAsset.rdlc"
            objReportH.DataSources.Add(objRdsH)
        Else
            objDatalistHeader = Me.GenerateDataHeaderOutGoing()
            objRdsH.Name = "ASSET_DataSource_clsRptLaporanRekapitulasiOutGoingAsset"
            objRdsH.Value = objDatalistHeader
            objReportH.ReportEmbeddedResource = "ASSET.RptLaporanRekapitulasiOutAsset.rdlc"
            objReportH.DataSources.Add(objRdsH)
        End If


        objReportViewer.Name = "RvLaporanRekapitulasiAsset"
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptTgl, parRptKondisi})
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.RefreshReport()

        Me.PnlDfMain.SuspendLayout()
        Me.PnlDfMain.Controls.Remove(Me.RvLaporanRekapitulasiAsset)

        Me.RvLaporanRekapitulasiAsset = Nothing
        Me.RvLaporanRekapitulasiAsset = objReportViewer
        Me.RvLaporanRekapitulasiAsset.LocalReport.EnableExternalImages = True

        Me.PnlDfMain.Controls.Add(Me.RvLaporanRekapitulasiAsset)
        Me.PnlDfMain.ResumeLayout()
        Me.RvLaporanRekapitulasiAsset.Dock = DockStyle.Fill
    End Function
    Private Function GenerateDataHeader() As ArrayList
        Dim objPrintHeader As DataSource.clsRptLaporanRekapitulasiAsset
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            objPrintHeader = New DataSource.clsRptLaporanRekapitulasiAsset(Me.DSN)
            With objPrintHeader
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id").ToString, String.Empty)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("asset_barcode").ToString, String.Empty)
                .desk = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("desk").ToString, String.Empty)
                .bookasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("bookasset_id").ToString, String.Empty)
                .bookasset_inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("bookasset_inputdt"), Now())
                .bookasset_startdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("bookasset_startdt"), Now())
                .bookasset_starttm = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("bookasset_starttm").ToString, String.Empty)
                .bookasset_enddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("bookasset_enddt"), Now())
                .bookasset_endtm = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("bookasset_endtm").ToString, String.Empty)
                .program = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("program").ToString, String.Empty)
                .kategori = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("kategori").ToString, String.Empty)
                .status = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("status"), 0)

            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function
    Private Function GenerateDataHeaderOutGoing() As ArrayList
        Dim objPrintHeader As DataSource.clsRptLaporanRekapitulasiOutGoingAsset
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            objPrintHeader = New DataSource.clsRptLaporanRekapitulasiOutGoingAsset(Me.DSN)
            With objPrintHeader
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id").ToString, String.Empty)
                .barcode = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("barcode").ToString, String.Empty)
                .deskripsi = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("deskripsi").ToString, String.Empty)
                .outasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_id").ToString, String.Empty)
                .outasset_inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_inputdt"), Now())
                .bookasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("bookasset_id").ToString, String.Empty)
                .bookasset_date = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("bookasset_date"), Now())
                .outasset_startdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_startdt"), Now())
                .outasset_starttm = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_starttm").ToString, String.Empty)
                .outasset_enddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_enddt"), Now())
                .outasset_endtm = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_endtm").ToString, String.Empty)
                .program = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("program").ToString, String.Empty)


            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function
    Private Function GenerateDataHeaderOutBookingGoing() As ArrayList
        Dim objPrintHeader As DataSource.ClsRptLaporanRekapitulasiOutBookingAsset
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer

        For i = 0 To Me.tbl_Print.Rows.Count - 1
            objPrintHeader = New DataSource.ClsRptLaporanRekapitulasiOutBookingAsset(Me.DSN)
            With objPrintHeader
                .outasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_id").ToString, String.Empty)
                .outasset_inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_inputdt"), Now())
                .qtyout = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("qtyout"), 0)
                .bookasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("bookasset_id").ToString, String.Empty)
                .book_date = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("book_date"), Now())
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("strukturunit_id"), 0)
                .qtybook = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("qtybook"), 0)
                .outasset_startdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_startdt"), Now())
                .outasset_starttm = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_starttm").ToString, String.Empty)
                .outasset_enddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_enddt"), Now())
                .outasset_endtm = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("outasset_endtm").ToString, String.Empty)
                .program = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("program").ToString, String.Empty)
                .kategoriitem_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("kategoriitem_id").ToString, String.Empty)
                .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id").ToString, String.Empty)

            End With
            objDatalistHeader.Add(objPrintHeader)
        Next

        Return objDatalistHeader
    End Function

End Class
