Imports System.Windows.Forms
Public Class DlgSelectEps
    Private dsn As String
    Private channel_id As String
    Private terimabarang_id As String
    Private orderdetil_line As Integer
    Private terimabarang_line As Integer
    Private total_days As Integer
    Private isDaysManual As String
    Private isUser As String
    Private isLock As Byte
    Private tbl_trnOrderDetilDays As DataTable = clsDataset.CreateTblTrnTerimajasaepstalent
    Private retTblOrderDays As DataTable = clsDataset.CreateTblTrnTerimajasaepstalent
    Private tbl_objective As DataTable

#Region " Opener "

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Integer

        Dim oDataFiller As New clsDataFiller(dsn)
        Dim criteria As String = String.Empty
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)

        Me.retTblOrderDays.Clear()
        criteria = String.Format("terimabarang_id = '{0}' AND terimabarang_line = {1} AND channel_id = '{2}'", Me.terimabarang_id, Me.orderdetil_line, Me.channel_id)
        oDataFiller.DataFill(tbl_trnOrderDetilDays, "as_TrnTerimajasaepstalent_Select", criteria)
        Me.DgvRequestdetileps.DataSource = Me.tbl_trnOrderDetilDays

        Me.FormatDgvTrnTerimajasaepstalent(Me.DgvRequestdetileps)
        ' ''Me.check_daysIsUse()
        If tbl_trnOrderDetilDays.Rows.Count > 0 Then
            Me.obj_Item_name.Text = tbl_trnOrderDetilDays.Rows(0).Item("terimabarang_descr")
            Me.obj_Requestdetil_line.Text = tbl_trnOrderDetilDays.Rows(0).Item("terimabarang_line")
            Me.obj_eps_start.Text = tbl_trnOrderDetilDays.Rows(0).Item("terimabarang_eps")
            Me.obj_eps_end.Text = tbl_trnOrderDetilDays.Rows(tbl_trnOrderDetilDays.Rows.Count - 1).Item("terimabarang_eps")
        End If
        ' ''Me.DgvListBPJ.Columns("terimabarang_dt").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_qty").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_usagestart").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_usageend").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_status").DefaultCellStyle.BackColor = Color.Lavender
        ' ''Me.DgvListBPJ.Columns("terimabarangused_remark").DefaultCellStyle.BackColor = Color.Lavender

        MyBase.ShowDialog(owner)

        Return Me.total_days

    End Function

#End Region
    Private Function FormatDgvTrnTerimajasaepstalent(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' ''Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimabarang_qty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        ' ''cSelect.Name = "select"
        ' ''cSelect.HeaderText = "Select"
        ' ''cSelect.DataPropertyName = "select"
        ' ''cSelect.Width = 40
        ' ''cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' ''cSelect.Visible = True
        ' ''cSelect.ReadOnly = False

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "RV ID"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 100
        cTerimabarang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = False

        cTerimabarang_line.Name = "terimabarang_line"
        cTerimabarang_line.HeaderText = "terimabarang_line"
        cTerimabarang_line.DataPropertyName = "terimabarang_line"
        cTerimabarang_line.Width = 100
        cTerimabarang_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_line.Visible = False
        cTerimabarang_line.ReadOnly = False

        cTerimabarang_eps.Name = "terimabarang_eps"
        cTerimabarang_eps.HeaderText = "Eps."
        cTerimabarang_eps.DataPropertyName = "terimabarang_eps"
        cTerimabarang_eps.Width = 100
        cTerimabarang_eps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_eps.Visible = True
        cTerimabarang_eps.ReadOnly = False

        cTerimabarang_descr.Name = "terimabarang_descr"
        cTerimabarang_descr.HeaderText = "Descr"
        cTerimabarang_descr.DataPropertyName = "terimabarang_descr"
        cTerimabarang_descr.Width = 100
        cTerimabarang_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_descr.Visible = True
        cTerimabarang_descr.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = True
        cChannel_id.ReadOnly = False

        cTerimabarang_check.Name = "terimabarang_check"
        cTerimabarang_check.HeaderText = "Select"
        cTerimabarang_check.DataPropertyName = "terimabarang_check"
        cTerimabarang_check.Width = 50
        cTerimabarang_check.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimabarang_check.Visible = True
        cTerimabarang_check.ReadOnly = False

        cTerimabarang_qty.Name = "terimabarang_qty"
        cTerimabarang_qty.HeaderText = "Qty"
        cTerimabarang_qty.DataPropertyName = "terimabarang_qty"
        cTerimabarang_qty.Width = 60
        cTerimabarang_qty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_qty.Visible = True
        cTerimabarang_qty.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "Order ID"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = False


        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "Line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 60
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = True
        cOrderdetil_line.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimabarang_check, cTerimabarang_id, cTerimabarang_line, cTerimabarang_eps, cTerimabarang_qty, _
        cTerimabarang_descr, cChannel_id, cOrder_id, cOrderdetil_line})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function
    Public Sub New(ByVal strDSN As String, ByVal channel_id As String, ByVal terimabarang_id As String, _
        ByVal orderdetil_line As Integer, ByVal isDaysManual As String, ByVal terimabarang_line As Integer, _
        ByVal isUser As String, ByVal isLock As Byte)
        Me.dsn = strDSN
        Me.channel_id = channel_id
        Me.terimabarang_id = terimabarang_id
        Me.orderdetil_line = orderdetil_line
        Me.isDaysManual = isDaysManual
        Me.terimabarang_line = terimabarang_line
        Me.isUser = isUser
        Me.isLock = isLock

        InitializeComponent()
    End Sub

    Private Sub DgvRequestdetiluse_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvRequestdetileps.CellFormatting
        Dim used As Boolean
        Dim obj As DataGridView = sender
        Dim objRow As System.Windows.Forms.DataGridViewRow = obj.Rows(e.RowIndex)

        Try
            used = CType(objRow.Cells("select").Value, Boolean)
            If used Then
                objRow.DefaultCellStyle.BackColor = Color.LavenderBlush
                objRow.Cells("requestdetil_eps").Style.BackColor = Color.LightPink
            Else
                objRow.DefaultCellStyle.BackColor = Color.White
                objRow.Cells("requestdetil_eps").Style.BackColor = Color.Gainsboro
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub lnkCheckAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkCheckAll.LinkClicked
        Dim i As Integer

        For i = 0 To Me.DgvRequestdetileps.Rows.Count - 1
            Me.DgvRequestdetileps.Rows(i).Cells("select").Value = True
        Next
    End Sub

    Private Sub lnkClearAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClearAll.LinkClicked
        Dim i As Integer

        For i = 0 To Me.DgvRequestdetileps.Rows.Count - 1
            Me.DgvRequestdetileps.Rows(i).Cells("select").Value = False
        Next
    End Sub


    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnCancel.Click
        Dim obj As Button = sender
        If obj.Name = "btnOK" Then
            Dim i As Integer
            Dim count_dgv As Integer
            Me.total_days = 0

            count_dgv = Me.DgvRequestdetileps.Rows.Count - 1

            For i = 0 To count_dgv
                If clsUtil.IsDbNull(Me.DgvRequestdetileps.Rows(i).Cells("terimabarang_check").Value, 0) = 1 Then
                    Me.total_days += 1
                End If
                Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.dsn)
                Try
                    dbConn.Open()
                    Dim oCm As New OleDb.OleDbCommand("as_TrnTerimajasaepstalent_Update", dbConn)
                    oCm.CommandType = CommandType.StoredProcedure

                    oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvRequestdetileps.Rows(i).Cells("terimabarang_id").Value
                    oCm.Parameters.Add("@terimabarang_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvRequestdetileps.Rows(i).Cells("terimabarang_line").Value
                    oCm.Parameters.Add("@terimabarang_eps", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvRequestdetileps.Rows(i).Cells("terimabarang_eps").Value
                    oCm.Parameters.Add("@terimabarang_descr", System.Data.OleDb.OleDbType.VarWChar, 510).Value = Me.DgvRequestdetileps.Rows(i).Cells("terimabarang_descr").Value
                    oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvRequestdetileps.Rows(i).Cells("channel_id").Value
                    oCm.Parameters.Add("@terimabarang_check", System.Data.OleDb.OleDbType.Boolean, 1).Value = clsUtil.IsDbNull(Me.DgvRequestdetileps.Rows(i).Cells("terimabarang_check").Value, 0)
                    oCm.Parameters.Add("@terimabarang_eps", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvRequestdetileps.Rows(i).Cells("terimabarang_qty").Value
                    oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvRequestdetileps.Rows(i).Cells("order_id").Value
                    oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvRequestdetileps.Rows(i).Cells("orderdetil_line").Value

                    oCm.ExecuteNonQuery()
                    oCm.Dispose()
                Catch ex As Data.OleDb.OleDbException
                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    dbConn.Close()
                End Try
            Next

            System.Windows.Forms.Cursor.Current = Cursors.Default
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Me.total_days = 9999
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

        Me.Close()
    End Sub

End Class