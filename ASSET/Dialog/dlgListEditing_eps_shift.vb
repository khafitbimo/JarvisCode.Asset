Imports System.Windows.Forms

Public Class dlgListEditing_eps_shift
    Private dsn As String
    Private channel_id As String
    Private terimabarang_id As String
    Private terimabarang_line As Integer
    Private total_days As Integer
    Private isDaysManual As String
    Private isUser As String
    Private isLock As Byte
    Private rekanan_id As Decimal
    Private tbl_trnOrderDetilEps As DataTable = clsDataset.CreateTblTrnTerimajasaepsEditing
    Private retTblOrderEps As DataTable = clsDataset.CreateTblTrnTerimajasaepsEditing
    Private tbl_objective As DataTable
    Private tbl_boot1 As DataTable = New DataTable
    Private tbl_boot2 As DataTable = New DataTable
    Private tbl_boot3 As DataTable = New DataTable
    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider
    Private tbl_bootDetil As DataTable = New DataTable


    Public Sub New(ByVal strDSN As String, ByVal channel_id As String, ByVal terimabarang_id As String, _
            ByVal terimabarang_line As Integer, _
            ByVal isUser As String, ByVal isLock As Byte, ByVal rekanan_id As Decimal)
        Me.dsn = strDSN
        Me.channel_id = channel_id
        Me.terimabarang_id = terimabarang_id
        Me.terimabarang_line = terimabarang_line
        Me.isUser = isUser
        Me.isLock = isLock
        Me.rekanan_id = rekanan_id

        InitializeComponent()
    End Sub
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Integer
        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = String.Empty
        Dim i As Integer
        Dim row_type As DataRow
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)

        criteria = String.Format(" terimabarang_id = '{0}' AND terimabarang_line = {1} AND channel_id = '{2}' ", Me.terimabarang_id, Me.terimabarang_line, Me.channel_id)

        Me.tbl_trnOrderDetilEps.Clear()
        oDataFiller.DataFill(Me.tbl_trnOrderDetilEps, "as_TrnTerimajasashiftediting_Select", criteria)
        Me.DgvListBPJ.DataSource = Me.tbl_trnOrderDetilEps

        Me.tbl_bootDetil = New DataTable
        Me.tbl_bootDetil.Clear()
        oDataFiller.DataFill(Me.tbl_bootDetil, "ms_MstBootdetil_Select", String.Format(" rekanan_id = {0}", Me.rekanan_id))

        Me.tbl_boot1 = New DataTable
        Me.tbl_boot1.Clear()
        Me.tbl_boot1.Columns.Add(New DataColumn("boot1", GetType(System.Decimal)))
        Me.tbl_boot1.Columns.Add(New DataColumn("display_boot", GetType(System.String)))

        For i = 0 To Me.tbl_bootDetil.Rows.Count
            If Me.tbl_boot1.Columns("boot1") IsNot Nothing Then
                If i = 0 Then
                    row_type = Me.tbl_boot1.NewRow
                    row_type.Item("boot1") = i
                    row_type.Item("display_boot") = "-- Pilih --"
                    Me.tbl_boot1.Rows.InsertAt(row_type, i)
                Else
                    row_type = Me.tbl_boot1.NewRow
                    row_type.Item("boot1") = i
                    row_type.Item("display_boot") = i
                    Me.tbl_boot1.Rows.InsertAt(row_type, i)
                End If
            End If
        Next

        Me.tbl_boot2 = Me.tbl_boot1.Copy
        Me.tbl_boot3 = Me.tbl_boot1.Copy

        Me.FormatDgvTrnTerimajasashiftediting(Me.DgvListBPJ)
        ' ''Me.check_EpsIsUse()

        MyBase.ShowDialog(owner)

        Return Me.total_days

    End Function
    Private Function FormatDgvTrnTerimajasashiftediting(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean

        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_date As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShift1 As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cBoot1 As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cShift2 As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cBoot2 As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cShift3 As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cBoot3 As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cEps_usage1_start As New DataGridViewMaskedEditColumn
        Dim cEps_usage1_end As New DataGridViewMaskedEditColumn
        Dim cEps_usage2_start As New DataGridViewMaskedEditColumn
        Dim cEps_usage2_end As New DataGridViewMaskedEditColumn
        Dim cEps_usage3_start As New DataGridViewMaskedEditColumn
        Dim cEps_usage3_end As New DataGridViewMaskedEditColumn
        Dim cTotal_usage As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "ID"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 100
        cTerimabarang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_id.Visible = False
        cTerimabarang_id.ReadOnly = False

        cTerimabarang_line.Name = "terimabarang_line"
        cTerimabarang_line.HeaderText = "Line"
        cTerimabarang_line.DataPropertyName = "terimabarang_line"
        cTerimabarang_line.Width = 50
        cTerimabarang_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_line.Visible = False
        cTerimabarang_line.ReadOnly = False

        cTerimabarang_eps.Name = "terimabarang_eps"
        cTerimabarang_eps.HeaderText = "Eps."
        cTerimabarang_eps.DataPropertyName = "terimabarang_eps"
        cTerimabarang_eps.Width = 60
        cTerimabarang_eps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_eps.Visible = True
        cTerimabarang_eps.ReadOnly = False

        cTerimabarang_date.Name = "terimabarang_date"
        cTerimabarang_date.HeaderText = "Editing Date"
        cTerimabarang_date.DataPropertyName = "terimabarang_date"
        cTerimabarang_date.Width = 100
        cTerimabarang_date.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_date.Visible = True
        cTerimabarang_date.ReadOnly = False

        cTerimabarang_descr.Name = "terimabarang_descr"
        cTerimabarang_descr.HeaderText = "Descr"
        cTerimabarang_descr.DataPropertyName = "terimabarang_descr"
        cTerimabarang_descr.Width = 100
        cTerimabarang_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_descr.Visible = True
        cTerimabarang_descr.ReadOnly = False

        cShift1.Name = "shift1"
        cShift1.HeaderText = "Shift 1"
        cShift1.DataPropertyName = "shift1"
        cShift1.Width = 50
        cShift1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift1.Visible = True
        cShift1.ReadOnly = False

        cBoot1.Name = "boot1"
        cBoot1.HeaderText = "Boot 1"
        cBoot1.DataPropertyName = "boot1"
        cBoot1.Width = 50
        cBoot1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot1.Visible = True
        cBoot1.ReadOnly = False
        cBoot1.DataSource = Me.tbl_boot1
        cBoot1.ValueMember = "boot1"
        cBoot1.DisplayMember = "display_boot"
        cBoot1.DisplayStyleForCurrentCellOnly = True

        cShift2.Name = "shift2"
        cShift2.HeaderText = "Shift 2"
        cShift2.DataPropertyName = "shift2"
        cShift2.Width = 50
        cShift2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift2.Visible = True
        cShift2.ReadOnly = False

        cBoot2.Name = "boot2"
        cBoot2.HeaderText = "Boot 2"
        cBoot2.DataPropertyName = "boot2"
        cBoot2.Width = 50
        cBoot2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot2.Visible = True
        cBoot2.ReadOnly = False
        cBoot2.DataSource = Me.tbl_boot2
        cBoot2.ValueMember = "boot1"
        cBoot2.DisplayMember = "display_boot"
        cBoot2.DisplayStyleForCurrentCellOnly = True

        cShift3.Name = "shift3"
        cShift3.HeaderText = "Shift 3"
        cShift3.DataPropertyName = "shift3"
        cShift3.Width = 50
        cShift3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cShift3.Visible = True
        cShift3.ReadOnly = False

        cBoot3.Name = "boot3"
        cBoot3.HeaderText = "Boot 3"
        cBoot3.DataPropertyName = "boot3"
        cBoot3.Width = 50
        cBoot3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cBoot3.Visible = True
        cBoot3.ReadOnly = False
        cBoot3.DataSource = Me.tbl_boot3
        cBoot3.ValueMember = "boot1"
        cBoot3.DisplayMember = "display_boot"
        cBoot3.DisplayStyleForCurrentCellOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cTerimabarang_check.Name = "terimabarang_check"
        cTerimabarang_check.HeaderText = "Select"
        cTerimabarang_check.DataPropertyName = "terimabarang_check"
        cTerimabarang_check.Width = 50
        cTerimabarang_check.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimabarang_check.Visible = True
        cTerimabarang_check.ReadOnly = False

        cEps_usage1_start.Mask = "##:##"
        cEps_usage1_start.ValidatingType = GetType(DateTime)
        cEps_usage1_start.Name = "eps_usage1_start"
        cEps_usage1_start.HeaderText = "Usage 1 Start"
        cEps_usage1_start.DataPropertyName = "eps_usage1_start"
        cEps_usage1_start.Width = 100
        cEps_usage1_start.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEps_usage1_start.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cEps_usage1_start.ReadOnly = True
        Else
            cEps_usage1_start.ReadOnly = False
        End If

        cEps_usage1_end.Mask = "##:##"
        cEps_usage1_end.ValidatingType = GetType(DateTime)
        cEps_usage1_end.Name = "eps_usage1_end"
        cEps_usage1_end.HeaderText = "Usage 1 End"
        cEps_usage1_end.DataPropertyName = "eps_usage1_end"
        cEps_usage1_end.Width = 100
        cEps_usage1_end.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEps_usage1_end.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cEps_usage1_end.ReadOnly = True
        Else
            cEps_usage1_end.ReadOnly = False
        End If

        cEps_usage2_start.Mask = "##:##"
        cEps_usage2_start.ValidatingType = GetType(DateTime)
        cEps_usage2_start.Name = "eps_usage2_start"
        cEps_usage2_start.HeaderText = "Usage 2 Start"
        cEps_usage2_start.DataPropertyName = "eps_usage2_start"
        cEps_usage2_start.Width = 100
        cEps_usage2_start.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEps_usage2_start.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cEps_usage2_start.ReadOnly = True
        Else
            cEps_usage2_start.ReadOnly = False
        End If

        cEps_usage2_end.Mask = "##:##"
        cEps_usage2_end.ValidatingType = GetType(DateTime)
        cEps_usage2_end.Name = "eps_usage2_end"
        cEps_usage2_end.HeaderText = "Usage 2 End"
        cEps_usage2_end.DataPropertyName = "eps_usage2_end"
        cEps_usage2_end.Width = 100
        cEps_usage2_end.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEps_usage2_end.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cEps_usage2_end.ReadOnly = True
        Else
            cEps_usage2_end.ReadOnly = False
        End If

        cEps_usage3_start.Mask = "##:##"
        cEps_usage3_start.ValidatingType = GetType(DateTime)
        cEps_usage3_start.Name = "eps_usage3_start"
        cEps_usage3_start.HeaderText = "Usage 3 Start"
        cEps_usage3_start.DataPropertyName = "eps_usage3_start"
        cEps_usage3_start.Width = 100
        cEps_usage3_start.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEps_usage3_start.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cEps_usage3_start.ReadOnly = True
        Else
            cEps_usage3_start.ReadOnly = False
        End If

        cEps_usage3_end.Mask = "##:##"
        cEps_usage3_end.ValidatingType = GetType(DateTime)
        cEps_usage3_end.Name = "eps_usage3_end"
        cEps_usage3_end.HeaderText = "Usage 3 End"
        cEps_usage3_end.DataPropertyName = "eps_usage3_end"
        cEps_usage3_end.Width = 100
        cEps_usage3_end.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cEps_usage3_end.Visible = True
        If Me.isUser = "bma" Or Me.isLock = 1 Then
            cEps_usage3_end.ReadOnly = True
        Else
            cEps_usage3_end.ReadOnly = False
        End If

        cTotal_usage.Name = "eps_total_usage"
        cTotal_usage.HeaderText = "Total Usage"
        cTotal_usage.DataPropertyName = "eps_total_usage"
        cTotal_usage.Width = 100
        cTotal_usage.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTotal_usage.Visible = True
        cTotal_usage.ReadOnly = True


        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimabarang_check, cTerimabarang_eps, cTerimabarang_descr, cTerimabarang_date, _
        cShift1, cBoot1, cEps_usage1_start, cEps_usage1_end, _
        cShift2, cBoot2, cEps_usage2_start, cEps_usage2_end, _
        cShift3, cBoot3, cEps_usage3_start, cEps_usage3_end, _
           cTotal_usage, cChannel_id, cTerimabarang_id, cTerimabarang_line})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
    End Function
    Private Sub check_EpsIsUse()
        Dim j As Integer
        Dim count_dgv As Integer

        Me.tbl_trnOrderDetilEps.Columns.Add("select", GetType(System.Boolean))
        Me.tbl_trnOrderDetilEps.Columns("select").DefaultValue = 0

        count_dgv = Me.tbl_trnOrderDetilEps.Rows.Count - 1
        For j = 0 To count_dgv
            If clsUtil.IsDbNull(Me.tbl_trnOrderDetilEps.Rows(j).Item("terimabarang_check"), 0) = 1 Then
                Me.DgvListBPJ.Rows(j).Cells("select").Value = 1
            End If
        Next
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim tbl_trnOrderDetilDays_changes As DataTable = New DataTable
        Dim success As Boolean
        Dim i As Integer
        Dim count_dgv As Integer
        Dim MasterDataState As System.Data.DataRowState
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False
        Dim criteria As String = String.Empty
        Dim table_temps As DataTable = New DataTable
        Dim status As String = String.Empty
        Dim usage1_start As Decimal
        Dim usage1_end As Decimal
        Dim usage2_start As Decimal
        Dim usage2_end As Decimal
        Dim usage3_start As Decimal
        Dim usage3_end As Decimal
        Dim message As String = ""
        Dim message_temp As String = String.Empty
        Dim total_usage As Decimal

        Me.total_days = 0

        '============= untuk cek isi datagridview na =============================
        'cek isi cell
        Dim cell_usage1_start, cell_usage1_end, cell_usage2_start, cell_usage2_end, cell_usage3_start, cell_usage3_end As DataGridViewCell
        Dim dgv_error, row_error As Boolean

        Try


            For i = 0 To Me.DgvListBPJ.Rows.Count - 1
                total_usage = 0
                usage1_start = 0
                usage1_end = 0
                usage2_start = 0
                usage2_end = 0
                usage3_start = 0
                usage3_end = 0

                row_error = False
                If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("terimabarang_check").Value, 0) = 1 Then
                    If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift1").Value, 0) = 1 Then
                        message = "Usage time start diluar shift 1"
                        cell_usage1_start = Me.DgvListBPJ.Rows(i).Cells("eps_usage1_start")
                        usage1_start = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage1_start").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage1_start").Value, 4, 2) / 60)
                        If usage1_start > 17 Or usage1_start < 9 Then
                            cell_usage1_start.ErrorText = message
                            row_error = True
                        Else
                            cell_usage1_start.ErrorText = ""
                        End If

                        message = "Usage time end diluar shift 1"
                        cell_usage1_end = Me.DgvListBPJ.Rows(i).Cells("eps_usage1_end")
                        usage1_end = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage1_end").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage1_end").Value, 4, 2) / 60)
                        If usage1_end > 17 Or usage1_end < 9 Then
                            cell_usage1_end.ErrorText = message
                            row_error = True
                        Else
                            cell_usage1_end.ErrorText = ""
                        End If

                        If usage1_end - usage1_start > 8 Then
                            message_temp = "jumlah jam di shift 1 lebih dari 8 jam"
                        End If
                    End If

                    If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift2").Value, 0) = 1 Then

                        message = "Usage time start diluar shift 2"
                        cell_usage2_start = Me.DgvListBPJ.Rows(i).Cells("eps_usage2_start")
                        usage2_start = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage2_start").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage2_start").Value, 4, 2) / 60)
                        If usage2_start > 25 Or usage2_start < 17 Then
                            cell_usage2_start.ErrorText = message
                            row_error = True
                        Else
                            cell_usage2_start.ErrorText = ""
                        End If

                        message = "Usage time end diluar shift 2"
                        cell_usage2_end = Me.DgvListBPJ.Rows(i).Cells("eps_usage2_end")
                        usage2_end = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage2_end").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage2_end").Value, 4, 2) / 60)
                        If usage2_end > 25 Or usage2_end < 17 Then
                            cell_usage2_end.ErrorText = message
                            row_error = True
                        Else
                            cell_usage2_end.ErrorText = ""
                        End If

                        If usage2_end - usage2_start > 8 Then
                            message_temp &= vbCrLf & " Jumlah jam di shift 2 lebih dari 8 jam"
                        End If

                    End If

                    If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift3").Value, 0) = 1 Then
                        message = "Usage time start diluar shift 3"
                        cell_usage3_start = Me.DgvListBPJ.Rows(i).Cells("eps_usage3_start")
                        usage3_start = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage3_start").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage3_start").Value, 4, 2) / 60)
                        If usage3_start > 33 And usage3_start < 25 Then
                            cell_usage3_start.ErrorText = message
                            row_error = True
                        Else
                            cell_usage3_start.ErrorText = ""
                        End If

                        message = "Usage time end diluar shift 3"
                        cell_usage3_end = Me.DgvListBPJ.Rows(i).Cells("eps_usage3_end")
                        usage3_end = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage3_end").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage3_end").Value, 4, 2) / 60)
                        If usage3_end > 33 And usage3_end < 25 Then
                            cell_usage3_end.ErrorText = message
                            row_error = True
                        Else
                            cell_usage3_end.ErrorText = ""
                        End If

                        If usage3_end - usage3_start > 8 Then
                            message_temp &= vbCrLf & " Jumlah jam di shift 3 lebih dari 8 jam"
                        End If

                    End If

                End If

                total_usage = (usage1_end - usage1_start) + (usage2_end - usage2_start) + (usage3_end - usage3_start)
                Me.DgvListBPJ.Rows(i).Cells("eps_total_usage").Value = CDec(total_usage)

                If row_error Then
                    dgv_error = True
                    Me.DgvListBPJ.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                Else
                    Me.DgvListBPJ.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If

            Next

            If dgv_error Then
                If message_temp = String.Empty Then
                    message_temp = " Data ada yang salah entry "
                End If
                Throw New Exception(message_temp)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgListEditing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        '============= Akhir dari cek isi datagrid na ============================

        ' ''If Me.uiTrnTerimaJasa_FormError() Then
        ' ''    MsgBox("gagal")
        ' ''End If

        count_dgv = Me.DgvListBPJ.Rows.Count - 1
        Me.DgvListBPJ.EndEdit()
        Me.BindingContext(Me.tbl_trnOrderDetilEps).EndCurrentEdit()
        tbl_trnOrderDetilDays_changes = Me.tbl_trnOrderDetilEps.GetChanges()

        For i = 0 To count_dgv
            If clsUtil.IsDbNull(Me.tbl_trnOrderDetilEps.Rows(i).Item("terimabarang_check"), 0) = 1 Then
                Me.total_days += 1
            End If
        Next
        For i = 0 To tbl_trnOrderDetilDays_changes.Rows.Count - 1
            If tbl_trnOrderDetilDays_changes.Rows(i).Item("terimabarang_check") Is DBNull.Value Then
                tbl_trnOrderDetilDays_changes.Rows(i).Item("terimabarang_check") = 0
            End If
            If tbl_trnOrderDetilDays_changes.Rows(i).Item("shift1") Is DBNull.Value Then
                tbl_trnOrderDetilDays_changes.Rows(i).Item("shift1") = 0
            End If
            If tbl_trnOrderDetilDays_changes.Rows(i).Item("shift2") Is DBNull.Value Then
                tbl_trnOrderDetilDays_changes.Rows(i).Item("shift2") = 0
            End If
            If tbl_trnOrderDetilDays_changes.Rows(i).Item("shift3") Is DBNull.Value Then
                tbl_trnOrderDetilDays_changes.Rows(i).Item("shift3") = 0
            End If
        Next

        If tbl_trnOrderDetilDays_changes IsNot Nothing Then
            For i = 0 To tbl_trnOrderDetilDays_changes.Rows.Count - 1
                If tbl_trnOrderDetilDays_changes.Rows(i).RowState = DataRowState.Added Then
                    tbl_trnOrderDetilDays_changes.Rows(i).Item("terimabarang_id") = terimabarang_id
                End If
            Next
            success = Me.save_manual(terimabarang_id, tbl_trnOrderDetilDays_changes, MasterDataState)
            If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnTerimaJasa_SaveDetil(tbl_TrnTerimabarangdetil_Changes)")
            Me.tbl_trnOrderDetilEps.AcceptChanges()
        End If


        ' ''For i = 0 To count_dgv
        ' ''    ' ''If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("select").Value, False) = True Then
        ' ''    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
        ' ''    Try
        ' ''        dbConn.Open()
        ' ''        Dim oCm As New OleDb.OleDbCommand("as_TrnTerimajasashiftediting_Update", dbConn)
        ' ''        oCm.CommandType = CommandType.StoredProcedure
        ' ''        oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_id").Value
        ' ''        oCm.Parameters.Add("@terimabarang_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_line").Value
        ' ''        oCm.Parameters.Add("@terimabarang_eps", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_eps").Value
        ' ''        oCm.Parameters.Add("@terimabarang_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_date").Value
        ' ''        oCm.Parameters.Add("@terimabarang_descr", System.Data.OleDb.OleDbType.VarWChar, 510).Value = Me.DgvListBPJ.Rows(i).Cells("terimabarang_descr").Value
        ' ''        oCm.Parameters.Add("@shift1", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift1").Value, 0)
        ' ''        oCm.Parameters.Add("@shift2", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift2").Value, 0)
        ' ''        oCm.Parameters.Add("@shift3", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift3").Value, 0)
        ' ''        oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvListBPJ.Rows(i).Cells("channel_id").Value
        ' ''        oCm.Parameters.Add("@terimabarang_check", System.Data.OleDb.OleDbType.Boolean, 1).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("select").Value, False)
        ' ''        oCm.Parameters.Add("@boot1", System.Data.OleDb.OleDbType.Decimal, 9).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("boot1").Value, 0)
        ' ''        oCm.Parameters.Add("@boot2", System.Data.OleDb.OleDbType.Decimal, 9).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("boot2").Value, 0)
        ' ''        oCm.Parameters.Add("@boot3", System.Data.OleDb.OleDbType.Decimal, 9).Value = clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("boot3").Value, 0)

        ' ''        oCm.ExecuteNonQuery()
        ' ''        oCm.Dispose()
        ' ''        If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("select").Value, False) = True Then
        ' ''            Me.total_days += 1 'clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift1").Value, 0) + clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift2").Value, 0) + clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift3").Value, 0)
        ' ''        End If
        ' ''    Catch ex As Data.OleDb.OleDbException
        ' ''        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' ''    Catch ex As Exception
        ' ''        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' ''    Finally
        ' ''        dbConn.Close()
        ' ''    End Try
        ' ''    ' ''End If
        ' ''Next

        System.Windows.Forms.Cursor.Current = Cursors.Default
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.total_days = 9999
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DgvListBPJ_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvListBPJ.CellClick
        Dim i As Integer

        For i = 0 To Me.DgvListBPJ.Rows.Count - 1
            If i <> e.RowIndex Then
                Me.DgvListBPJ.Rows(i).Cells("terimabarang_check").Value = False
            End If
        Next
    End Sub

    Private Function save_manual(ByRef terimabarang_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim cookie As Byte() = Nothing

        ' Save data: transaksi_terimajasashiftediting

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnTerimajasashiftediting_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_eps", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_eps"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "terimabarang_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@shift1", System.Data.OleDb.OleDbType.Boolean, 1, "shift1"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@shift2", System.Data.OleDb.OleDbType.Boolean, 1, "shift2"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@shift3", System.Data.OleDb.OleDbType.Boolean, 1, "shift3"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 30, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_check", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_check"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@boot1", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "boot1", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@boot2", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "boot2", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@boot3", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "boot3", System.Data.DataRowVersion.Current, Nothing))
        ' ''dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        ' ''dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@eps_usage1_start", System.Data.OleDb.OleDbType.VarWChar, 10, "eps_usage1_start"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@eps_usage1_end", System.Data.OleDb.OleDbType.VarWChar, 10, "eps_usage1_end"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@eps_usage2_start", System.Data.OleDb.OleDbType.VarWChar, 10, "eps_usage2_start"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@eps_usage2_end", System.Data.OleDb.OleDbType.VarWChar, 10, "eps_usage2_end"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@eps_usage3_start", System.Data.OleDb.OleDbType.VarWChar, 10, "eps_usage3_start"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@eps_usage3_end", System.Data.OleDb.OleDbType.VarWChar, 10, "eps_usage3_end"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@eps_total_usage", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "eps_total_usage", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters("@terimabarang_id").Value = terimabarang_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate

        Try
            dbConn.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            dbConn.Close()
        End Try

        Return True
    End Function

    Private Function uiTrnTerimaJasa_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False
        Dim criteria As String = String.Empty
        Dim table_temps As DataTable = New DataTable
        Dim i As Integer
        Dim status As String = String.Empty
        Dim usage1_start As Decimal
        Dim usage1_end As Decimal
        Dim usage2_start As Decimal
        Dim usage2_end As Decimal
        Dim usage3_start As Decimal
        Dim usage3_end As Decimal
        Dim message As String = ""
        Dim message_temp As String = String.Empty


        'cek isi cell
        Dim cell_usage1_start, cell_usage1_end, cell_usage2_start, cell_usage2_end, cell_usage3_start, cell_usage3_end As DataGridViewCell
        Dim dgv_error, row_error As Boolean

        Try
            For i = 0 To Me.DgvListBPJ.Rows.Count - 1

                If clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("terimabarang_check").Value, 0) = 1 And clsUtil.IsDbNull(Me.DgvListBPJ.Rows(i).Cells("shift1").Value, 0) = 1 Then
                    row_error = False

                    message = "Usage time start diluar shift 1"
                    cell_usage1_start = Me.DgvListBPJ.Rows(i).Cells("eps_usage1_start")
                    usage1_start = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage1_start").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage1_start").Value, 4, 2) / 60)
                    If usage1_start >= 17 Or usage1_start <= 9 Then
                        cell_usage1_start.ErrorText = message
                        row_error = True
                    Else
                        cell_usage1_start.ErrorText = ""
                    End If

                    message = "Usage time end diluar shift 1"
                    cell_usage1_end = Me.DgvListBPJ.Rows(i).Cells("eps_usage1_end")
                    usage1_end = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage1_end").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage1_end").Value, 4, 2) / 60)
                    If usage1_end >= 17 Or usage1_end <= 9 Then
                        cell_usage1_end.ErrorText = message
                        row_error = True
                    Else
                        cell_usage1_end.ErrorText = ""
                    End If

                    If usage1_end - usage1_start > 8 Then
                        message_temp = "jumlah jam di shift 1 lebih dari 8 jam"
                    End If


                    message = "Usage time start diluar shift 2"
                    cell_usage2_start = Me.DgvListBPJ.Rows(i).Cells("eps_usage2_start")
                    usage2_start = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage2_start").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage2_start").Value, 4, 2) / 60)
                    If usage2_start >= 25 Or usage2_start <= 17 Then
                        cell_usage2_start.ErrorText = message
                        row_error = True
                    Else
                        cell_usage2_start.ErrorText = ""
                    End If

                    message = "Usage time end diluar shift 2"
                    cell_usage2_end = Me.DgvListBPJ.Rows(i).Cells("eps_usage2_end")
                    usage2_end = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage2_end").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage2_end").Value, 4, 2) / 60)
                    If usage2_end >= 25 Or usage2_end <= 17 Then
                        cell_usage2_end.ErrorText = message
                        row_error = True
                    Else
                        cell_usage2_end.ErrorText = ""
                    End If

                    If usage2_end - usage2_start > 8 Then
                        message_temp &= vbCrLf & " Jumlah jam di shift 2 lebih dari 8 jam"
                    End If


                    message = "Usage time start diluar shift 3"
                    cell_usage3_start = Me.DgvListBPJ.Rows(i).Cells("eps_usage3_start")
                    usage3_start = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage3_start").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage3_start").Value, 4, 2) / 60)
                    If usage3_start >= 33 And usage3_start <= 25 Then
                        cell_usage3_start.ErrorText = message
                        row_error = True
                    Else
                        cell_usage3_start.ErrorText = ""
                    End If

                    message = "Usage time end diluar shift 3"
                    cell_usage3_end = Me.DgvListBPJ.Rows(i).Cells("eps_usage3_end")
                    usage3_end = CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage3_end").Value, 1, 2)) + CDec(Mid(Me.DgvListBPJ.Rows(i).Cells("eps_usage3_end").Value, 4, 2) / 60)
                    If usage3_end >= 33 And usage3_end <= 25 Then
                        cell_usage3_end.ErrorText = message
                        row_error = True
                    Else
                        cell_usage3_end.ErrorText = ""
                    End If

                    If usage3_end - usage3_start > 8 Then
                        message_temp &= vbCrLf & " Jumlah jam di shift 3 lebih dari 8 jam"
                    End If

                End If

                If row_error Then
                    dgv_error = True
                    Me.DgvListBPJ.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                Else
                    Me.DgvListBPJ.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If

                If dgv_error Then
                    Throw New Exception(message_temp)
                End If
            Next





            ' ''    For i = 0 To Me.tbl_trnOrderDetilEps.Rows.Count - 1
            ' ''        If clsUtil.IsDbNull(Me.tbl_trnOrderDetilEps.Rows(i).Item("terimabarang_check"), 0) = 1 And clsUtil.IsDbNull(Me.tbl_trnOrderDetilEps.Rows(i).Item("shift1"), 0) = 1 Then
            ' ''            usage1_start = CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage1_start"), 1, 2)) + CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage1_start"), 4, 2) / 60)
            ' ''            If usage1_start > 17 And usage1_start < 9 Then

            ' ''            Else
            ' ''                MsgBox("ok")
            ' ''            End If
            ' ''            MsgBox(usage1_start)

            ' ''            usage1_end = CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage1_end"), 1, 2)) + CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage1_end"), 4, 2) / 60)
            ' ''            If usage1_end > 17 And usage1_end < 9 Then
            ' ''                MsgBox("no")
            ' ''            Else
            ' ''                MsgBox("ok")
            ' ''            End If
            ' ''            MsgBox(usage1_end)

            ' ''            If usage1_end - usage1_start > 8 Then
            ' ''                MsgBox("lebih")
            ' ''            Else
            ' ''                MsgBox("mantabs")
            ' ''            End If
            ' ''        End If

            ' ''        If clsUtil.IsDbNull(Me.tbl_trnOrderDetilEps.Rows(i).Item("terimabarang_check"), 0) = 1 And clsUtil.IsDbNull(Me.tbl_trnOrderDetilEps.Rows(i).Item("shift2"), 0) = 1 Then
            ' ''            usage2_start = CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage2_start"), 1, 2)) + CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage2_start"), 4, 2) / 60)
            ' ''            If usage2_start > 25 And usage2_start < 17 Then
            ' ''                MsgBox("no")
            ' ''            Else
            ' ''                MsgBox("ok")
            ' ''            End If
            ' ''            MsgBox(usage2_start)

            ' ''            usage2_end = CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage2_end"), 1, 2)) + CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage2_end"), 4, 2) / 60)
            ' ''            If usage2_end > 25 And usage2_end < 17 Then
            ' ''                MsgBox("no")
            ' ''            Else
            ' ''                MsgBox("ok")
            ' ''            End If
            ' ''            MsgBox(usage2_end)

            ' ''            If usage2_end - usage2_start > 8 Then
            ' ''                MsgBox("lebih")
            ' ''            Else
            ' ''                MsgBox("mantabs")
            ' ''            End If
            ' ''        End If

            ' ''        If clsUtil.IsDbNull(Me.tbl_trnOrderDetilEps.Rows(i).Item("terimabarang_check"), 0) = 1 And clsUtil.IsDbNull(Me.tbl_trnOrderDetilEps.Rows(i).Item("shift3"), 0) = 1 Then
            ' ''            usage3_start = CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage3_start"), 1, 2)) + CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage3_start"), 4, 2) / 60)
            ' ''            If usage3_start > 33 And usage3_start < 25 Then
            ' ''                MsgBox("no")
            ' ''            Else
            ' ''                MsgBox("ok")
            ' ''            End If
            ' ''            MsgBox(usage3_start)

            ' ''            usage3_end = CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage3_end"), 1, 2)) + CDec(Mid(Me.tbl_trnOrderDetilEps.Rows(i).Item("eps_usage3_end"), 4, 2) / 60)
            ' ''            If usage3_end > 33 And usage3_end < 25 Then
            ' ''                MsgBox("no")
            ' ''            Else
            ' ''                MsgBox("ok")
            ' ''            End If
            ' ''            MsgBox(usage3_end)

            ' ''            If usage3_end - usage3_start > 8 Then
            ' ''                MsgBox("lebih")
            ' ''            Else
            ' ''                MsgBox("mantabs")
            ' ''            End If
            ' ''        End If
            ' ''    Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "dlgListEditing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function
End Class
