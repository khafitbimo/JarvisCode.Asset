Public Class dlgRptJurnal

    Private DSN As String
    Private jurnal_id As String
    Private SptServer As String
    Private channel_id As String

    Private parJurnalType_id As String
    Private parJurnal_Source As String
    Private parJurnal_BookDate As String
    Private parPeriode_Name As String
    Private parCurrency_Name As String
    Private parJurnal_AmountForeign As String
    Private parRekanan_Name As String
    Private parJurnal_Desc As String

    Private objPrintDetil As DataSource.clsRptJurnal_Detil
    Private objDatalistDetil As ArrayList

    Private tbl_TrnJurnal As DataTable = clsDataset.CreateTblTrnJurnal()
    Private tbl_TrnJurnalDetil As DataTable = clsDataset.CreateTblTrnJurnaldetil()


#Region " Constructor "

    Public Sub New(ByVal strDSN As String, ByVal sptServer As String, _
                    ByVal jurnal_id As String, ByVal channel_id As String)
        Me.DSN = strDSN
        Me.SptServer = sptServer
        Me.jurnal_id = jurnal_id
        Me.channel_id = channel_id

        InitializeComponent()
    End Sub

#End Region

    Private Function GenerateReport() As Boolean

        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objRdsD As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportD As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objReportViewer As Microsoft.Reporting.WinForms.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer

        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer & "/Solutions/images/" & Me.channel_id & ".jpg")
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_name", CStr(Me.tbl_TrnJurnal.Rows(0).Item("channel_name")))
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channel_address", CStr(Me.tbl_TrnJurnal.Rows(0).Item("channel_address")))
        Dim parRptJurnalID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_id", Me.jurnal_id)

        objDatalistHeader = Me.GenerateDataHeader()

        Dim parRptJurnalTypeID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnaltype_id", Me.parJurnalType_id)
        Dim parRptJurnal_Source As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_source", Me.parJurnal_Source)
        Dim parRptJurnal_BookDate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_bookdate", Me.parJurnal_BookDate)
        Dim parRptPeriodeName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("periode_name", Me.parPeriode_Name)
        Dim parRptCurrencyName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("currency_name", Me.parCurrency_Name)
        Dim parRptJurnal_AmountForeign As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_amountforeign", Me.parJurnal_AmountForeign)
        Dim parRptRekananName As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("rekanan_name", Me.parRekanan_Name)
        Dim parRptJurnal_Desc As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("jurnal_descr", Me.parJurnal_Desc)

        objRdsH.Name = "NEWACT_DataSource_clsRptJurnal_Header"
        objRdsH.Value = objDatalistHeader

        If Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-ListBPB" Then
            objReportH.ReportEmbeddedResource = "ASSET.rptJurnal_Penerimaanbarang_Header.rdlc"
        End If

        objReportH.DataSources.Add(objRdsH)
        AddHandler objReportViewer.LocalReport.SubreportProcessing, AddressOf SubreportProcessing
        objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
        objReportViewer.Name = "ReportViewer1"
        objReportViewer.LocalReport.EnableExternalImages = True
        objReportViewer.LocalReport.DataSources.Clear()
        objReportViewer.LocalReport.DataSources.Add(objRdsH)
        objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannel_namereport, parRptChannel_address, parRptJurnalID, _
            parRptJurnalTypeID, parRptJurnal_Source, parRptJurnal_BookDate, parRptPeriodeName, _
            parRptCurrencyName, parRptCurrencyName, parRptJurnal_AmountForeign, parRptRekananName, _
            parRptJurnal_Desc})

        objReportViewer.RefreshReport()
        Me.SuspendLayout()
        Me.Controls.Remove(Me.ReportViewer1)
        Me.ReportViewer1 = Nothing
        Me.ReportViewer1 = objReportViewer
        Me.Controls.Add(Me.ReportViewer1)
        Me.ResumeLayout()
        Me.ReportViewer1.Dock = DockStyle.Fill

    End Function
    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim objPrintHeader As DataSource.clsRptJurnal_Header

        objPrintHeader = New DataSource.clsRptJurnal_Header
        With objPrintHeader
            .jurnal_id = clsUtil.IsDbNull(Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id"), String.Empty)
            Me.parJurnalType_id = clsUtil.IsDbNull(Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id"), String.Empty)
            Me.parJurnal_Source = clsUtil.IsDbNull(Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source"), String.Empty)
            Me.parJurnal_BookDate = clsUtil.IsDbNull(Format(Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate"), "dd/MMM/yyyy"), Now.Date)
            Me.parPeriode_Name = clsUtil.IsDbNull(Me.tbl_TrnJurnal.Rows(0).Item("periode_name"), String.Empty)
            Me.parJurnal_Desc = clsUtil.IsDbNull(Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr"), String.Empty)
            Me.parRekanan_Name = clsUtil.IsDbNull(Trim(Me.tbl_TrnJurnal.Rows(0).Item("rekanan_name")), String.Empty)
            Me.parCurrency_Name = clsUtil.IsDbNull(Trim(Me.tbl_TrnJurnal.Rows(0).Item("currency_name")), String.Empty)
            Me.parJurnal_AmountForeign = clsUtil.IsDbNull(Format(Me.tbl_TrnJurnal.Rows(0).Item("jurnal_amountforeign"), "#,##0"), 0)
            .jurnal_createby = clsUtil.IsDbNull(Me.tbl_TrnJurnal.Rows(0).Item("created_by_name"), String.Empty)
            .jurnal_createdate = clsUtil.IsDbNull(Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createdate"), Now.Date)
            .jurnal_postby = clsUtil.IsDbNull(Me.tbl_TrnJurnal.Rows(0).Item("post_by_name"), String.Empty)
            .jurnal_postdate = clsUtil.IsDbNull(Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postdate"), Now)

            Me.GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function
    Private Function GenerateDataDetail() As ArrayList
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_TrnJurnalDetil.Rows.Count - 1
            objPrintDetil = New DataSource.clsRptJurnal_Detil(Me.DSN)
            With objPrintDetil
                .jurnal_id = clsUtil.IsDbNull(Me.tbl_TrnJurnalDetil.Rows(i).Item("jurnal_id"), String.Empty)
                .acc_id = clsUtil.IsDbNull(Me.tbl_TrnJurnalDetil.Rows(i).Item("acc_id"), String.Empty)
                .acc_name = clsUtil.IsDbNull(Me.tbl_TrnJurnalDetil.Rows(i).Item("acc_name"), String.Empty)
                .rekanan_id = clsUtil.IsDbNull(Me.tbl_TrnJurnalDetil.Rows(i).Item("rekanan_id"), String.Empty)
                .rekanan_name = clsUtil.IsDbNull(Me.tbl_TrnJurnalDetil.Rows(i).Item("rekanan_name"), String.Empty)
                .jurnaldetil_descr = clsUtil.IsDbNull(Me.tbl_TrnJurnalDetil.Rows(i).Item("jurnaldetil_descr"), String.Empty)
                .ref_id = clsUtil.IsDbNull(Me.tbl_TrnJurnalDetil.Rows(i).Item("ref_id"), String.Empty)
                .jurnaldetil_foreignrate = clsUtil.IsDbNull(Me.tbl_TrnJurnalDetil.Rows(i).Item("jurnaldetil_foreignrate"), 0)
                .jurnaldetil_foreign = clsUtil.IsDbNull(Me.tbl_TrnJurnalDetil.Rows(i).Item("jurnaldetil_foreign"), 0)
                .jurnaldetil_idr = clsUtil.IsDbNull(Me.tbl_TrnJurnalDetil.Rows(i).Item("jurnaldetil_idr"), 0)
            End With
            objDatalistDetil.Add(objPrintDetil)
        Next

        Return objDatalistDetil
    End Function

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        'e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("NEWACT_DataSource_clsRptJurnal_Detil", objDatalistDetil))
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptJurnal_Detil", objDatalistDetil))
    End Sub

    Private Sub dlgTrnJurnalPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        Me.tbl_TrnJurnal.Clear()
        Me.tbl_TrnJurnalDetil.Clear()

        oDataFiller.DataFill(Me.tbl_TrnJurnal, "cp_RptJurnal_SelectHeader", String.Format("jurnal_id='{0}' AND channel_id = '{1}'", Me.jurnal_id, Me.channel_id))
        oDataFiller.DataFill(Me.tbl_TrnJurnalDetil, "cp_RptJurnal_SelectDetil", String.Format("jurnal_id='{0}' AND channel_id = '{1}'", Me.jurnal_id, Me.channel_id))

        If Me.tbl_TrnJurnal.Rows.Count = 0 Then
            MsgBox("No data")
            Me.Close()
        End If

        Me.GenerateReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
