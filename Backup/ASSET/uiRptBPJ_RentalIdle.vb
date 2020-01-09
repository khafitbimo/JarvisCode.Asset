Public Class uiRptBPJ_RentalIdle
    Private Const mUiName As String = "Laporan Penerimaan Asset"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider

    Private tbl_Print As DataTable = New DataTable 'clsDataset.CreateTblMstAssetalias
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    ' ''Private objPrintHeader As DataSource.clsRptBPJ_RentalIdle
    Private objDatalistDetil As ArrayList

    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptPrintDate As String

#Region " Window Parameter "
    ' TODO: Buat variabel untuk menampung parameter window 
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
#End Region

#Region " Overrides "
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
        For Each tsItem As ToolStripItem In Me.ToolStrip1.Items
            If tsItem.GetType.ToString = "System.Windows.Forms.ToolStripSeparator" Or (tsItem.Name <> "tbtnLoad") Then
                tsItem.Visible = False
            End If
        Next

        Me.cbo_Group.SelectedItem = "-- Pilih --"
        Me.cbo_typePrint.SelectedItem = "-- Pilih --"
    End Sub

    Private Function uiLaporanPenerimaanAsset_PrintPreview() As Boolean

        Dim criteria As String = String.Empty 'String.Format(" is_useable = 0")
        '--------------criteria----------------------------
        If Me.cbo_typePrint.SelectedItem = "Summary Order (Details)" Or Me.cbo_typePrint.SelectedItem = "Summary Order (Recap)" Then
            criteria = String.Format(" E.terimajasa_date BETWEEN '{0}' AND '{1}'", Format(Me.obj_start_date.Value, "yyyy-MM-dd"), Format(Me.obj_end_date.Value, "yyyy-MM-dd"))
        Else
            criteria = String.Format(" C.terimajasa_date BETWEEN '{0}' AND '{1}'", Format(Me.obj_start_date.Value, "yyyy-MM-dd"), Format(Me.obj_end_date.Value, "yyyy-MM-dd"))
        End If
        '--------------------------------------------------------------------------'

        Me.set_printpreview(criteria)
    End Function
    Private Sub set_printpreview(ByVal criteria As String)
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim storeProcedure As String = String.Empty

        If Me.cbo_typePrint.SelectedItem = "Recap" Then
            If Me.cbo_Group.SelectedItem = "Budget" Then
                storeProcedure = "as_RptTerimaJasaQtyIdle_SelectBudgetRecap"
            ElseIf Me.cbo_Group.SelectedItem = "Rekanan" Then
                storeProcedure = "as_RptTerimaJasaQtyIdle_SelectRekananRecap"
            ElseIf Me.cbo_Group.SelectedItem = "Department" Then
                storeProcedure = "as_RptTerimaJasaQtyIdle_SelectDepartmentRecap"
            ElseIf Me.cbo_Group.SelectedItem = "Employee" Then
                storeProcedure = "as_RptTerimaJasaQtyIdle_SelectEmployeeRecap"
            Else
                MsgBox("Please choose one of the group options that are available", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        ElseIf Me.cbo_typePrint.SelectedItem = "Details" Then
            storeProcedure = "as_RptTerimaJasaQtyIdle_Select"
        ElseIf Me.cbo_typePrint.SelectedItem = "Summary Order (Details)" Then
            storeProcedure = "as_RptTerimaJasaQtyIdleSummary_Select"
        ElseIf Me.cbo_typePrint.SelectedItem = "Summary Order (Recap)" Then
            storeProcedure = "as_RptTerimaJasaQtyIdleSummary_Select"
        Else
            MsgBox("Please choose one of the type options that are available", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

            Me.tbl_Print.Clear()
            dtFiller.DataFill(Me.tbl_Print, storeProcedure, criteria, Me._CHANNEL)

            If Me.tbl_Print.Rows.Count > 0 Then
                Me.sptPrintDate = "Print Date From " & Format(Me.obj_start_date.Value, "dd MMMM yyyy") & " To " & Format(Me.obj_end_date.Value, "dd MMMM yyyy")
                GenerateReport()
            Else
                MsgBox("No Data")
                Exit Sub
            End If

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
        Dim parRptPrintDate As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("print_date", Me.sptPrintDate)
        
        objDatalistHeader = Me.GenerateDataHeader()

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.sptChannel_ID)
        Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
        
        objRdsH.Name = "ASSET_DataSource_clsRptBPJ_RentalIdle"
        objRdsH.Value = objDatalistHeader

        If Me.cbo_typePrint.SelectedItem = "Recap" Then
            If Me.cbo_Group.SelectedItem = "Budget" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_BudgetRecap.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Rekanan" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_RekananRecap.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Department" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_DepartmentRecap.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Employee" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_EmployeeRecap.rdlc"
            Else
                MsgBox("Please choose one of the group options that are available", MsgBoxStyle.Information, "Information")
                Exit Function
            End If
        ElseIf Me.cbo_typePrint.SelectedItem = "Details" Then
            If Me.cbo_Group.SelectedItem = "Budget" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_Budget.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Rekanan" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_Rekanan.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Department" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_Department.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Employee" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_Employee.rdlc"
            Else
                MsgBox("Please choose one of the group options that are available", MsgBoxStyle.Information, "Information")
                Exit Function
            End If
        ElseIf Me.cbo_typePrint.SelectedItem = "Summary Order (Details)" Then
            If Me.cbo_Group.SelectedItem = "Budget" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_BudgetSummary.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Department" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_DepartmentSummary.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Employee" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_EmployeeSummary.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Rekanan" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_RekananSummary.rdlc"
            Else
                MsgBox("Please choose one of the group options that are available", MsgBoxStyle.Information, "Information")
                Exit Function
            End If
        ElseIf Me.cbo_typePrint.SelectedItem = "Summary Order (Recap)" Then
            If Me.cbo_Group.SelectedItem = "Budget" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_BudgetSummaryRecap.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Department" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_DepartmentSummaryRecap.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Employee" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_EmployeeSummaryRecap.rdlc"
            ElseIf Me.cbo_Group.SelectedItem = "Rekanan" Then
                objReportH.ReportEmbeddedResource = "ASSET.RptBPJ_RentalIdle_RekananSummaryRecap.rdlc"
            Else
                MsgBox("Please choose one of the group options that are available", MsgBoxStyle.Information, "Information")
                Exit Function
            End If
        Else
            MsgBox("Please choose one of the type options that are available", MsgBoxStyle.Information, "Information")
            Exit Function
        End If

            objReportH.DataSources.Add(objRdsH)

            objReportViewer.Name = "RvLaporanPenerimaanAsset"
            objReportViewer.LocalReport.ReportEmbeddedResource = objReportH.ReportEmbeddedResource
            objReportViewer.LocalReport.EnableExternalImages = True
            objReportViewer.LocalReport.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, _
                parRptChannel_namereport, parRptChannel_address, parRptPrintDate})
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
        Dim objPrintHeader As DataSource.clsRptBPJ_RentalIdle
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim i As Integer
        If Me.cbo_typePrint.SelectedItem = "Recap" Then
            If Me.cbo_Group.SelectedItem = "Budget" Then
                For i = 0 To Me.tbl_Print.Rows.Count - 1
                    objPrintHeader = New DataSource.clsRptBPJ_RentalIdle(Me.DSN)
                    With objPrintHeader
                        .amount_idr_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Amount_idr_idle"), 0)
                        .terimajasaused_qty_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimajasaused_qty_idle"), 0)
                        .budget_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("budget_id"), 0)
                        .budget_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("budget_name"), String.Empty)
                        .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id"), String.Empty)

                        Me.sptChannel_ID = .channel_id
                        Me.sptChannel_nameReport = .channel_namereport
                        Me.sptChannel_address = .channel_address
                    End With
                    objDatalistHeader.Add(objPrintHeader)
                Next
            ElseIf Me.cbo_Group.SelectedItem = "Department" Then
                For i = 0 To Me.tbl_Print.Rows.Count - 1
                    objPrintHeader = New DataSource.clsRptBPJ_RentalIdle(Me.DSN)
                    With objPrintHeader
                        .amount_idr_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Amount_idr_idle"), 0)
                        .terimajasaused_qty_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimajasaused_qty_idle"), 0)
                        .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("strukturunit_id"), 0)
                        .strukturunit_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("strukturunit_name"), String.Empty)
                        .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id"), String.Empty)

                        Me.sptChannel_ID = .channel_id
                        Me.sptChannel_nameReport = .channel_namereport
                        Me.sptChannel_address = .channel_address
                    End With
                    objDatalistHeader.Add(objPrintHeader)
                Next
            ElseIf Me.cbo_Group.SelectedItem = "Rekanan" Then
                For i = 0 To Me.tbl_Print.Rows.Count - 1
                    objPrintHeader = New DataSource.clsRptBPJ_RentalIdle(Me.DSN)
                    With objPrintHeader
                        .amount_idr_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Amount_idr_idle"), 0)
                        .terimajasaused_qty_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimajasaused_qty_idle"), 0)
                        .rekanan_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("rekanan_id"), 0)
                        .rekanan_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("rekanan_name"), String.Empty)
                        .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id"), String.Empty)

                        Me.sptChannel_ID = .channel_id
                        Me.sptChannel_nameReport = .channel_namereport
                        Me.sptChannel_address = .channel_address
                    End With
                    objDatalistHeader.Add(objPrintHeader)
                Next
            ElseIf Me.cbo_Group.SelectedItem = "Employee" Then
                For i = 0 To Me.tbl_Print.Rows.Count - 1
                    objPrintHeader = New DataSource.clsRptBPJ_RentalIdle(Me.DSN)
                    With objPrintHeader
                        .amount_idr_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Amount_idr_idle"), 0)
                        .terimajasaused_qty_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimajasaused_qty_idle"), 0)
                        .employee_id_owner = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("employee_id_owner"), String.Empty)
                        .employee_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("employee_name"), String.Empty)
                        .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id"), String.Empty)

                        Me.sptChannel_ID = .channel_id
                        Me.sptChannel_nameReport = .channel_namereport
                        Me.sptChannel_address = .channel_address
                    End With
                    objDatalistHeader.Add(objPrintHeader)
                Next
            End If
            
        ElseIf Me.cbo_typePrint.SelectedItem = "Summary Order (Details)" Or Me.cbo_typePrint.SelectedItem = "Summary Order (Recap)" Then
            For i = 0 To Me.tbl_Print.Rows.Count - 1
                objPrintHeader = New DataSource.clsRptBPJ_RentalIdle(Me.DSN)
                With objPrintHeader
                    .amount_idr_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Amount_idr_idle"), 0)
                    .terimajasaused_qty_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimajasaused_qty_idle"), 0)
                    .terimajasa_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("order_id").ToString, String.Empty)
                    .terimajasadetil_line = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("orderdetil_line").ToString, 0)
                    .budget_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("budget_id").ToString, 0)
                    .budget_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("budget_name").ToString, String.Empty)
                    .item_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("item_id").ToString, String.Empty)
                    .item_named = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("item_name").ToString, String.Empty)
                    .rekanan_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("rekanan_id"), String.Empty)
                    .rekanan_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("rekanan_name"), String.Empty)
                    .order_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("order_id"), String.Empty)
                    .terimajasa_date = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimajasa_date"), String.Empty)
                    .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("strukturunit_id"), String.Empty)
                    .strukturunit_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("strukturunit_name"), String.Empty)
                    .employee_id_owner = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("employee_id_owner"), String.Empty)
                    .employee_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("employee_name"), String.Empty)
                    .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id"), String.Empty)
                    .qty_order = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("qty_order"), 0)
                    .qty_rv = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimajasaused_rv"), 0)
                    Me.sptChannel_ID = .channel_id
                    Me.sptChannel_nameReport = .channel_namereport
                    Me.sptChannel_address = .channel_address
                End With
                objDatalistHeader.Add(objPrintHeader)
            Next
        ElseIf Me.cbo_typePrint.SelectedItem = "Details" Then
            For i = 0 To Me.tbl_Print.Rows.Count - 1
                objPrintHeader = New DataSource.clsRptBPJ_RentalIdle(Me.DSN)
                With objPrintHeader
                    .amount_idr_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("Amount_idr_idle"), 0)
                    .terimajasaused_qty_idle = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimajasaused_qty_idle"), 0)
                    .terimajasa_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimajasa_id").ToString, String.Empty)
                    .terimajasadetil_line = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimajasadetil_line").ToString, 0)
                    .budget_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("budget_id").ToString, 0)
                    .budget_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("budget_name").ToString, String.Empty)
                    .item_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("item_id").ToString, String.Empty)
                    .item_named = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("item_name").ToString, String.Empty)
                    .rekanan_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("rekanan_id"), String.Empty)
                    .rekanan_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("rekanan_name"), String.Empty)
                    .order_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("order_id"), String.Empty)
                    .terimajasa_date = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("terimajasa_date"), String.Empty)
                    .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("strukturunit_id"), String.Empty)
                    .strukturunit_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("strukturunit_name"), String.Empty)
                    .employee_id_owner = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("employee_id_owner"), String.Empty)
                    .employee_name = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("employee_name"), String.Empty)
                    .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(i).Item("channel_id"), String.Empty)

                    Me.sptChannel_ID = .channel_id
                    Me.sptChannel_nameReport = .channel_namereport
                    Me.sptChannel_address = .channel_address
                End With
                objDatalistHeader.Add(objPrintHeader)
            Next
        End If
       

        Return objDatalistHeader
    End Function

End Class

