Imports System.Windows.Forms

Public Class DlgBpjSelectOrder
    Private CloseButtonIsPressed As Boolean

    Private dsn As String
    Private criteria As String
    Private criteria_jasa As String
    Private strukturunit_id As Decimal
    Private names As String

    Private tabel_order As DataTable = clsDataset.CreateTblBpjOrderSelect
    Private tabel_order_ret As DataTable = clsDataset.CreateTblBpjOrderSelect
    Private tabel_order_ret_temps As DataTable = clsDataset.CreateTblBpjOrderSelect
    Public Sub New(ByVal strDSN As String, ByVal criteria As String, ByVal strukturunit_id As Decimal, _
        ByVal names As String)
        Me.dsn = strDSN
        Me.criteria_jasa = criteria
        Me.strukturunit_id = strukturunit_id
        Me.names = names

        InitializeComponent()
    End Sub
    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As DataTable
        Dim oDataFiller As New clsDataFiller(dsn)
        'Dim oDataFiller As New clsDataFiller(dsn)
        Me.tabel_order.Clear()

        If criteria_jasa = "EO" Then
            oDataFiller.DataFill(Me.tabel_order, "as_BpjOrderEditing_Select", criteria)
        Else
            oDataFiller.DataFill(Me.tabel_order, "as_BpjOrder_Select", criteria)
        End If
        If Me.criteria_jasa = "EO" And Me.strukturunit_id = 2610 Then
            Me.criteria = String.Format(" ordertype_id = '{0}' ", Me.criteria_jasa)
        Else
            Me.criteria = String.Format(" ordertype_id = '{0}' AND strukturunit_id = {1}", Me.criteria_jasa, Me.strukturunit_id)
        End If
        Me.chk_canceled.Checked = False
        Me.tabel_order.DefaultView.RowFilter = criteria & " AND order_canceled = 0"
        Me.DgvBpjSelectOrder.DataSource = Me.tabel_order
        Me.FormatDgvBpjSelectOrder(Me.DgvBpjSelectOrder)

        Me.cmb_status.SelectedItem = "-- PILIH --"
        Me.obj_ordrID_Search.Text = ""
        Me.rb_OrderID_search.Checked = True
        Me.cmb_status.Enabled = False
        Me.rb_Status_bpj.Text = names

        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.tabel_order_ret
        Else
            Return Nothing
        End If
    End Function

    Private Function FormatDgvBpjSelectOrder(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cSelect As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStatus As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cVendor As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrdertype_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimabarang_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_canceled As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        cSelect.Name = "select"
        cSelect.HeaderText = "Select"
        cSelect.DataPropertyName = "select"
        cSelect.Width = 50
        cSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cSelect.Frozen = True
        cSelect.Visible = True
        cSelect.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order_id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = True
        cOrder_id.ReadOnly = True

        cStatus.Name = "status"
        cStatus.HeaderText = "status"
        cStatus.DataPropertyName = "status"
        cStatus.Width = 130
        cStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStatus.Visible = True
        cStatus.ReadOnly = True

        cVendor.Name = "vendor"
        cVendor.HeaderText = "Partner"
        cVendor.DataPropertyName = "vendor"
        cVendor.Width = 250
        cVendor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cVendor.Visible = True
        cVendor.ReadOnly = True

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cOrdertype_id.Name = "ordertype_id"
        cOrdertype_id.HeaderText = "ordertype_id"
        cOrdertype_id.DataPropertyName = "ordertype_id"
        cOrdertype_id.Width = 100
        cOrdertype_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrdertype_id.Visible = False
        cOrdertype_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cTerimabarang_id.Name = "terimabarang_id"
        cTerimabarang_id.HeaderText = "RV Number"
        cTerimabarang_id.DataPropertyName = "terimabarang_id"
        cTerimabarang_id.Width = 100
        cTerimabarang_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimabarang_id.Visible = True
        cTerimabarang_id.ReadOnly = True

        cOrder_canceled.Name = "order_canceled"
        cOrder_canceled.HeaderText = "Order Canceled"
        cOrder_canceled.DataPropertyName = "order_canceled"
        cOrder_canceled.Width = 100
        cOrder_canceled.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_canceled.Visible = True
        cOrder_canceled.ReadOnly = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cSelect, cOrder_id, cStatus, cTerimabarang_id, cVendor, cChannel_id, _
        cOrdertype_id, cStrukturunit_id, cOrder_canceled})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim i As Integer
        Dim count_dgv As Integer
        Dim col As Integer
        Dim columnName As String
        Dim row As DataRow

        count_dgv = Me.DgvBpjSelectOrder.Rows.Count - 1

        For i = 0 To count_dgv
            If clsUtil.IsDbNull(Me.DgvBpjSelectOrder.Rows(i).Cells("select").Value, False) = True Then
                row = tabel_order_ret_temps.NewRow
                For col = 0 To DgvBpjSelectOrder.Columns.Count - 4
                    columnName = tabel_order.Columns(col).ColumnName
                    If columnName <> "select" Then
                        row(columnName) = DgvBpjSelectOrder.Rows(i).Cells(columnName).Value
                    End If
                Next
                Me.tabel_order_ret_temps.Rows.Add(row)
                Exit For
            End If
        Next
        Me.tabel_order_ret = Me.tabel_order_ret_temps

        Me.CloseButtonIsPressed = True
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DgvBpjSelectOrder_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvBpjSelectOrder.CellClick
        Dim i As Integer

        For i = 0 To Me.DgvBpjSelectOrder.Rows.Count - 1
            If i <> e.RowIndex Then
                Me.DgvBpjSelectOrder.Rows(i).Cells("select").Value = False
            End If
        Next
    End Sub


    Private Sub DgvBpjSelectOrder_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvBpjSelectOrder.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)
        Try
            If objrow.Cells("status").Value = "COMPLETE" Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            ElseIf objrow.Cells("status").Value = "-- Pilih --" Then
                objrow.DefaultCellStyle.BackColor = Color.Aquamarine
            ElseIf objrow.Cells("status").Value = "INCOMPLETE" Then
                objrow.DefaultCellStyle.BackColor = Color.Red
            Else
                objrow.DefaultCellStyle.BackColor = Color.White
            End If

        Catch ex As Exception
        End Try
    End Sub


    Private Sub rb_Status_bpj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_Status_bpj.Click
        If rb_Status_bpj.Checked = True Then
            filter_search(1)
        End If
    End Sub

    Private Sub filter_search(ByVal filters As Byte)
        If filters = 1 Then
            Me.obj_ordrID_Search.Text = ""
            Me.obj_ordrID_Search.ReadOnly = True
            Me.cmb_status.SelectedItem = "-- PILIH --"
            Me.cmb_status.Enabled = True
        Else
            Me.obj_ordrID_Search.Text = ""
            Me.obj_ordrID_Search.ReadOnly = False
            Me.cmb_status.SelectedItem = "-- PILIH --"
            Me.cmb_status.Enabled = False
        End If
    End Sub

    Private Sub rb_OrderID_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_OrderID_search.Click
        filter_search(0)
    End Sub

    Private Sub obj_ordrID_Search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_ordrID_Search.TextChanged
        Dim criteria_temps As String = String.Empty
        If Me.chk_canceled.Checked = True Then
            criteria_temps = criteria & " AND order_canceled = 1"
        Else
            criteria_temps = criteria & " AND order_canceled = 0"
        End If
        If LTrim(Me.obj_ordrID_Search.Text) = "" Then
            Me.tabel_order.DefaultView.RowFilter = criteria_temps
        Else
            Me.tabel_order.DefaultView.RowFilter = criteria_temps & " AND order_id like '%" & Me.obj_ordrID_Search.Text & "%'"
        End If
        'Me.DgvBpjSelectOrder.DataSource = tabel_order
    End Sub

    Private Sub cmb_status_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_status.SelectionChangeCommitted
        Dim criteria_temps As String = String.Empty
        If Me.chk_canceled.Checked = True Then
            criteria_temps = criteria & " AND order_canceled = 1"
        Else
            criteria_temps = criteria & " AND order_canceled = 0"
        End If

        If cmb_status.SelectedItem = "ALL" Then
            Me.tabel_order.DefaultView.RowFilter = criteria_temps
        ElseIf cmb_status.SelectedItem = "Approved User" Then
            Me.tabel_order.DefaultView.RowFilter = criteria_temps & " AND status = '-- Pilih --'"
        ElseIf cmb_status.SelectedItem = "Complete" Then
            Me.tabel_order.DefaultView.RowFilter = criteria_temps & " AND status = 'COMPLETE'"
        ElseIf cmb_status.SelectedItem = "InComplete" Then
            Me.tabel_order.DefaultView.RowFilter = criteria_temps & " AND status = 'INCOMPLETE'"
        ElseIf cmb_status.SelectedItem = "UnProses" Then
            Me.tabel_order.DefaultView.RowFilter = criteria_temps & " AND status = 'BELUM DIPROSES'"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_canceled.CheckedChanged
        Dim criteria_temps As String = String.Empty
        If Me.chk_canceled.Checked = True Then
            Me.DgvBpjSelectOrder.ReadOnly = True
            criteria_temps = criteria & " AND order_canceled = 1"
        Else
            Me.DgvBpjSelectOrder.ReadOnly = False
            criteria_temps = criteria & " AND order_canceled = 0"
        End If

        If Me.rb_OrderID_search.Checked = True Then
            If LTrim(Me.obj_ordrID_Search.Text) = "" Then
                Me.tabel_order.DefaultView.RowFilter = criteria_temps
            Else
                Me.tabel_order.DefaultView.RowFilter = criteria_temps & " AND order_id like '%" & Me.obj_ordrID_Search.Text & "%'"
            End If
        Else
            If cmb_status.SelectedItem = "ALL" Then
                Me.tabel_order.DefaultView.RowFilter = criteria_temps
            ElseIf cmb_status.SelectedItem = "Approved User" Then
                Me.tabel_order.DefaultView.RowFilter = criteria_temps & " AND status = '-- Pilih --'"
            ElseIf cmb_status.SelectedItem = "Complete" Then
                Me.tabel_order.DefaultView.RowFilter = criteria_temps & " AND status = 'COMPLETE'"
            ElseIf cmb_status.SelectedItem = "InComplete" Then
                Me.tabel_order.DefaultView.RowFilter = criteria_temps & " AND status = 'INCOMPLETE'"
            ElseIf cmb_status.SelectedItem = "UnProses" Then
                Me.tabel_order.DefaultView.RowFilter = criteria_temps & " AND status = 'BELUM DIPROSES'"
            End If
        End If
    End Sub

    Private Sub rb_Status_bpj_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_Status_bpj.CheckedChanged

    End Sub
End Class
