
Public Class dlgTrnTerimaJasaUsed_EditingEps
    Private retObj As Object
    Private order_id As String
    Private orderdetil_line As Integer
    Private isUser As String

    Private tbl_terimaJasaUsed_temps As DataTable = clsDataset.CreateTblTrnTerimajasausededitingeps

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As Object
        Me.Text = "List Eps. Editing Order"

        Me.tbl_terimaJasaUsed_temps.DefaultView.RowFilter = String.Format(" order_id = '{0}' AND orderdetil_line = {1}", Me.order_id, Me.orderdetil_line)

        Me.DgvListBPJ.DataSource = Me.tbl_terimaJasaUsed_temps

        Me.FormatDgvTrnTerimajasausededitingeps(Me.DgvListBPJ)

        MyBase.ShowDialog(owner)

        Return Me.retObj

    End Function
    Private Function FormatDgvTrnTerimajasausededitingeps(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cTerimajasa_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasadetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrder_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOrderdetiluse_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasause_check As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cTerimajasause_eps As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTerimajasause_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cTerimajasa_id.Name = "terimajasa_id"
        cTerimajasa_id.HeaderText = "terimajasa_id"
        cTerimajasa_id.DataPropertyName = "terimajasa_id"
        cTerimajasa_id.Width = 100
        cTerimajasa_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasa_id.Visible = False
        cTerimajasa_id.ReadOnly = False

        cTerimajasadetil_line.Name = "terimajasadetil_line"
        cTerimajasadetil_line.HeaderText = "terimajasadetil_line"
        cTerimajasadetil_line.DataPropertyName = "terimajasadetil_line"
        cTerimajasadetil_line.Width = 100
        cTerimajasadetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasadetil_line.Visible = False
        cTerimajasadetil_line.ReadOnly = False

        cOrder_id.Name = "order_id"
        cOrder_id.HeaderText = "order_id"
        cOrder_id.DataPropertyName = "order_id"
        cOrder_id.Width = 100
        cOrder_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrder_id.Visible = False
        cOrder_id.ReadOnly = False

        cOrderdetil_line.Name = "orderdetil_line"
        cOrderdetil_line.HeaderText = "orderdetil_line"
        cOrderdetil_line.DataPropertyName = "orderdetil_line"
        cOrderdetil_line.Width = 100
        cOrderdetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetil_line.Visible = False
        cOrderdetil_line.ReadOnly = False

        cOrderdetiluse_line.Name = "orderdetiluse_line"
        cOrderdetiluse_line.HeaderText = "orderdetiluse_line"
        cOrderdetiluse_line.DataPropertyName = "orderdetiluse_line"
        cOrderdetiluse_line.Width = 100
        cOrderdetiluse_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cOrderdetiluse_line.Visible = False
        cOrderdetiluse_line.ReadOnly = False

        cTerimajasause_check.Name = "terimajasause_check"
        cTerimajasause_check.HeaderText = "Select"
        cTerimajasause_check.DataPropertyName = "terimajasause_check"
        cTerimajasause_check.Width = 60
        cTerimajasause_check.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimajasause_check.Visible = True
        cTerimajasause_check.ReadOnly = False

        cTerimajasause_eps.Name = "terimajasause_eps"
        cTerimajasause_eps.HeaderText = "Eps."
        cTerimajasause_eps.DataPropertyName = "terimajasause_eps"
        cTerimajasause_eps.Width = 60
        cTerimajasause_eps.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        cTerimajasause_eps.Visible = True
        cTerimajasause_eps.ReadOnly = True
        cTerimajasause_eps.DefaultCellStyle.BackColor = Color.Gainsboro

        cTerimajasause_descr.Name = "terimajasause_descr"
        cTerimajasause_descr.HeaderText = "Descr"
        cTerimajasause_descr.DataPropertyName = "terimajasause_descr"
        cTerimajasause_descr.Width = 200
        cTerimajasause_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cTerimajasause_descr.Visible = True
        cTerimajasause_descr.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cTerimajasa_id, cTerimajasadetil_line, cOrder_id, cOrderdetil_line, cOrderdetiluse_line, cTerimajasause_check, cTerimajasause_eps, cTerimajasause_descr, cChannel_id})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        If Me.isUser = "bma" Then
            objDgv.ReadOnly = True
        End If
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim thisRetObj As Collection = New Collection
        Dim retTblOrderDays As DataTable = clsDataset.CreateTblTrnTerimajasausededitingeps
        retTblOrderDays = Me.tbl_terimaJasaUsed_temps.Copy
        thisRetObj.Add(Me.tbl_terimaJasaUsed_temps.Copy, "tblUsedEps")
        retObj = thisRetObj
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Sub New(ByVal tbl_terimaJasaUsed_temps As DataTable, ByVal order_id As String, ByVal isUser As String, _
                    ByVal orderdetil_line As Int32)

        Me.tbl_terimaJasaUsed_temps = tbl_terimaJasaUsed_temps
        Me.order_id = order_id
        Me.orderdetil_line = orderdetil_line
        Me.isUser = isUser
        InitializeComponent()
    End Sub
End Class
