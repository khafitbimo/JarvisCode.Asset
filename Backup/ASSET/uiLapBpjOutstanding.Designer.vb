<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiLapBpjOutstanding
    Inherits ASSET.uiBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RvLaporanPenerimaanAsset = New Microsoft.Reporting.WinForms.ReportViewer
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.cbo_department = New System.Windows.Forms.ComboBox
        Me.chk_department = New System.Windows.Forms.CheckBox
        Me.cbo_rekap = New System.Windows.Forms.ComboBox
        Me.chkSearch_Rekap = New System.Windows.Forms.CheckBox
        Me.cbo_filter = New System.Windows.Forms.ComboBox
        Me.chkSearch_Filter = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chk_EndDate = New System.Windows.Forms.CheckBox
        Me.obj_end_date = New System.Windows.Forms.DateTimePicker
        Me.chk_StartDate = New System.Windows.Forms.CheckBox
        Me.obj_start_date = New System.Windows.Forms.DateTimePicker
        Me.cboSearch_Source = New System.Windows.Forms.ComboBox
        Me.chkSearchDate = New System.Windows.Forms.CheckBox
        Me.cboSearchDate = New System.Windows.Forms.NumericUpDown
        Me.cboSearchRv_No = New System.Windows.Forms.ComboBox
        Me.chkSearchRv_No = New System.Windows.Forms.CheckBox
        Me.chkSearchYear = New System.Windows.Forms.CheckBox
        Me.chkSearchMonth = New System.Windows.Forms.CheckBox
        Me.cboSearchYear = New System.Windows.Forms.NumericUpDown
        Me.cboSearchMonth = New System.Windows.Forms.NumericUpDown
        Me.Panel1.SuspendLayout()
        Me.PnlDfFooter.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        CType(Me.cboSearchDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSearchYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSearchMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.RvLaporanPenerimaanAsset)
        Me.Panel1.Controls.Add(Me.PnlDfMain)
        Me.Panel1.Controls.Add(Me.PnlDfFooter)
        Me.Panel1.Controls.Add(Me.PnlDfSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(753, 523)
        Me.Panel1.TabIndex = 7
        '
        'RvLaporanPenerimaanAsset
        '
        Me.RvLaporanPenerimaanAsset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RvLaporanPenerimaanAsset.Location = New System.Drawing.Point(0, 100)
        Me.RvLaporanPenerimaanAsset.Name = "RvLaporanPenerimaanAsset"
        Me.RvLaporanPenerimaanAsset.Size = New System.Drawing.Size(753, 384)
        Me.RvLaporanPenerimaanAsset.TabIndex = 1
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDfMain.Location = New System.Drawing.Point(0, 100)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(753, 384)
        Me.PnlDfMain.TabIndex = 4
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Controls.Add(Me.Label2)
        Me.PnlDfFooter.Controls.Add(Me.NumericUpDown1)
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(0, 484)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(753, 39)
        Me.PnlDfFooter.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(117, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Record"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(17, 9)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(95, 20)
        Me.NumericUpDown1.TabIndex = 4
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.BackColor = System.Drawing.Color.SkyBlue
        Me.PnlDfSearch.Controls.Add(Me.cbo_department)
        Me.PnlDfSearch.Controls.Add(Me.chk_department)
        Me.PnlDfSearch.Controls.Add(Me.cbo_rekap)
        Me.PnlDfSearch.Controls.Add(Me.chkSearch_Rekap)
        Me.PnlDfSearch.Controls.Add(Me.cbo_filter)
        Me.PnlDfSearch.Controls.Add(Me.chkSearch_Filter)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.chk_EndDate)
        Me.PnlDfSearch.Controls.Add(Me.obj_end_date)
        Me.PnlDfSearch.Controls.Add(Me.chk_StartDate)
        Me.PnlDfSearch.Controls.Add(Me.obj_start_date)
        Me.PnlDfSearch.Controls.Add(Me.cboSearch_Source)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchDate)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchDate)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchRv_No)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchRv_No)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchYear)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchMonth)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchYear)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchMonth)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(0, 0)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(753, 100)
        Me.PnlDfSearch.TabIndex = 1
        '
        'cbo_department
        '
        Me.cbo_department.FormattingEnabled = True
        Me.cbo_department.Items.AddRange(New Object() {"-- Pilih --", "Yes", "No"})
        Me.cbo_department.Location = New System.Drawing.Point(581, 6)
        Me.cbo_department.Name = "cbo_department"
        Me.cbo_department.Size = New System.Drawing.Size(169, 21)
        Me.cbo_department.TabIndex = 55
        '
        'chk_department
        '
        Me.chk_department.AutoSize = True
        Me.chk_department.Checked = True
        Me.chk_department.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_department.Location = New System.Drawing.Point(494, 8)
        Me.chk_department.Name = "chk_department"
        Me.chk_department.Size = New System.Drawing.Size(81, 17)
        Me.chk_department.TabIndex = 54
        Me.chk_department.Text = "Department"
        Me.chk_department.UseVisualStyleBackColor = True
        '
        'cbo_rekap
        '
        Me.cbo_rekap.FormattingEnabled = True
        Me.cbo_rekap.Items.AddRange(New Object() {"-- Pilih --", "Yes", "No"})
        Me.cbo_rekap.Location = New System.Drawing.Point(335, 73)
        Me.cbo_rekap.Name = "cbo_rekap"
        Me.cbo_rekap.Size = New System.Drawing.Size(145, 21)
        Me.cbo_rekap.TabIndex = 53
        '
        'chkSearch_Rekap
        '
        Me.chkSearch_Rekap.AutoSize = True
        Me.chkSearch_Rekap.Checked = True
        Me.chkSearch_Rekap.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearch_Rekap.Enabled = False
        Me.chkSearch_Rekap.Location = New System.Drawing.Point(250, 75)
        Me.chkSearch_Rekap.Name = "chkSearch_Rekap"
        Me.chkSearch_Rekap.Size = New System.Drawing.Size(69, 17)
        Me.chkSearch_Rekap.TabIndex = 52
        Me.chkSearch_Rekap.Text = "Summary"
        Me.chkSearch_Rekap.UseVisualStyleBackColor = True
        '
        'cbo_filter
        '
        Me.cbo_filter.FormattingEnabled = True
        Me.cbo_filter.Items.AddRange(New Object() {"-- Pilih --", "Order Date", "Shooting Date Start", "Shooting Date End"})
        Me.cbo_filter.Location = New System.Drawing.Point(335, 50)
        Me.cbo_filter.Name = "cbo_filter"
        Me.cbo_filter.Size = New System.Drawing.Size(145, 21)
        Me.cbo_filter.TabIndex = 51
        '
        'chkSearch_Filter
        '
        Me.chkSearch_Filter.AutoSize = True
        Me.chkSearch_Filter.Checked = True
        Me.chkSearch_Filter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearch_Filter.Enabled = False
        Me.chkSearch_Filter.Location = New System.Drawing.Point(250, 52)
        Me.chkSearch_Filter.Name = "chkSearch_Filter"
        Me.chkSearch_Filter.Size = New System.Drawing.Size(48, 17)
        Me.chkSearch_Filter.TabIndex = 50
        Me.chkSearch_Filter.Text = "Filter"
        Me.chkSearch_Filter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Report Name"
        '
        'chk_EndDate
        '
        Me.chk_EndDate.AutoSize = True
        Me.chk_EndDate.Checked = True
        Me.chk_EndDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_EndDate.Enabled = False
        Me.chk_EndDate.Location = New System.Drawing.Point(250, 27)
        Me.chk_EndDate.Name = "chk_EndDate"
        Me.chk_EndDate.Size = New System.Drawing.Size(71, 17)
        Me.chk_EndDate.TabIndex = 48
        Me.chk_EndDate.Text = "End Date"
        Me.chk_EndDate.UseVisualStyleBackColor = True
        '
        'obj_end_date
        '
        Me.obj_end_date.CustomFormat = "dd/MM/yyyy"
        Me.obj_end_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_end_date.Location = New System.Drawing.Point(335, 27)
        Me.obj_end_date.Name = "obj_end_date"
        Me.obj_end_date.Size = New System.Drawing.Size(145, 20)
        Me.obj_end_date.TabIndex = 47
        '
        'chk_StartDate
        '
        Me.chk_StartDate.AutoSize = True
        Me.chk_StartDate.Checked = True
        Me.chk_StartDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_StartDate.Enabled = False
        Me.chk_StartDate.Location = New System.Drawing.Point(250, 6)
        Me.chk_StartDate.Name = "chk_StartDate"
        Me.chk_StartDate.Size = New System.Drawing.Size(74, 17)
        Me.chk_StartDate.TabIndex = 46
        Me.chk_StartDate.Text = "Start Date"
        Me.chk_StartDate.UseVisualStyleBackColor = True
        '
        'obj_start_date
        '
        Me.obj_start_date.CustomFormat = "dd/MM/yyyy"
        Me.obj_start_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_start_date.Location = New System.Drawing.Point(335, 5)
        Me.obj_start_date.Name = "obj_start_date"
        Me.obj_start_date.Size = New System.Drawing.Size(145, 20)
        Me.obj_start_date.TabIndex = 45
        '
        'cboSearch_Source
        '
        Me.cboSearch_Source.FormattingEnabled = True
        Me.cboSearch_Source.Items.AddRange(New Object() {"-- Pilih --", "BPJ Outstanding", "BPJ in Transaksi Order"})
        Me.cboSearch_Source.Location = New System.Drawing.Point(89, 6)
        Me.cboSearch_Source.Name = "cboSearch_Source"
        Me.cboSearch_Source.Size = New System.Drawing.Size(145, 21)
        Me.cboSearch_Source.TabIndex = 44
        '
        'chkSearchDate
        '
        Me.chkSearchDate.AutoSize = True
        Me.chkSearchDate.Location = New System.Drawing.Point(250, 5)
        Me.chkSearchDate.Name = "chkSearchDate"
        Me.chkSearchDate.Size = New System.Drawing.Size(49, 17)
        Me.chkSearchDate.TabIndex = 42
        Me.chkSearchDate.Text = "Date"
        Me.chkSearchDate.UseVisualStyleBackColor = True
        '
        'cboSearchDate
        '
        Me.cboSearchDate.Location = New System.Drawing.Point(335, 5)
        Me.cboSearchDate.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.cboSearchDate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.cboSearchDate.Name = "cboSearchDate"
        Me.cboSearchDate.Size = New System.Drawing.Size(54, 20)
        Me.cboSearchDate.TabIndex = 41
        Me.cboSearchDate.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cboSearchRv_No
        '
        Me.cboSearchRv_No.FormattingEnabled = True
        Me.cboSearchRv_No.Location = New System.Drawing.Point(335, 73)
        Me.cboSearchRv_No.Name = "cboSearchRv_No"
        Me.cboSearchRv_No.Size = New System.Drawing.Size(145, 21)
        Me.cboSearchRv_No.TabIndex = 36
        '
        'chkSearchRv_No
        '
        Me.chkSearchRv_No.AutoSize = True
        Me.chkSearchRv_No.Location = New System.Drawing.Point(250, 75)
        Me.chkSearchRv_No.Name = "chkSearchRv_No"
        Me.chkSearchRv_No.Size = New System.Drawing.Size(81, 17)
        Me.chkSearchRv_No.TabIndex = 35
        Me.chkSearchRv_No.Text = "RV Number"
        Me.chkSearchRv_No.UseVisualStyleBackColor = True
        '
        'chkSearchYear
        '
        Me.chkSearchYear.AutoSize = True
        Me.chkSearchYear.Location = New System.Drawing.Point(250, 51)
        Me.chkSearchYear.Name = "chkSearchYear"
        Me.chkSearchYear.Size = New System.Drawing.Size(48, 17)
        Me.chkSearchYear.TabIndex = 32
        Me.chkSearchYear.Text = "Year"
        Me.chkSearchYear.UseVisualStyleBackColor = True
        '
        'chkSearchMonth
        '
        Me.chkSearchMonth.AutoSize = True
        Me.chkSearchMonth.Location = New System.Drawing.Point(250, 27)
        Me.chkSearchMonth.Name = "chkSearchMonth"
        Me.chkSearchMonth.Size = New System.Drawing.Size(56, 17)
        Me.chkSearchMonth.TabIndex = 31
        Me.chkSearchMonth.Text = "Month"
        Me.chkSearchMonth.UseVisualStyleBackColor = True
        '
        'cboSearchYear
        '
        Me.cboSearchYear.Location = New System.Drawing.Point(335, 50)
        Me.cboSearchYear.Maximum = New Decimal(New Integer() {2200, 0, 0, 0})
        Me.cboSearchYear.Minimum = New Decimal(New Integer() {1998, 0, 0, 0})
        Me.cboSearchYear.Name = "cboSearchYear"
        Me.cboSearchYear.Size = New System.Drawing.Size(54, 20)
        Me.cboSearchYear.TabIndex = 28
        Me.cboSearchYear.Value = New Decimal(New Integer() {2008, 0, 0, 0})
        '
        'cboSearchMonth
        '
        Me.cboSearchMonth.Location = New System.Drawing.Point(335, 27)
        Me.cboSearchMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.cboSearchMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.cboSearchMonth.Name = "cboSearchMonth"
        Me.cboSearchMonth.Size = New System.Drawing.Size(54, 20)
        Me.cboSearchMonth.TabIndex = 27
        Me.cboSearchMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'uiLapBpjOutstanding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "uiLapBpjOutstanding"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.PnlDfFooter.ResumeLayout(False)
        Me.PnlDfFooter.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        CType(Me.cboSearchDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSearchYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSearchMonth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents chkSearchYear As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchMonth As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboSearchMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboSearchRv_No As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchRv_No As System.Windows.Forms.CheckBox
    Friend WithEvents RvLaporanPenerimaanAsset As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents chkSearchDate As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchDate As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboSearch_Source As System.Windows.Forms.ComboBox
    Friend WithEvents chk_StartDate As System.Windows.Forms.CheckBox
    Friend WithEvents obj_start_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents chk_EndDate As System.Windows.Forms.CheckBox
    Friend WithEvents obj_end_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_filter As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearch_Filter As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_rekap As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearch_Rekap As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_department As System.Windows.Forms.ComboBox
    Friend WithEvents chk_department As System.Windows.Forms.CheckBox


End Class
