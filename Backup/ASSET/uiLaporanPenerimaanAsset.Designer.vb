<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiLaporanPenerimaanAsset
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
        Me.cboSearchLantai = New System.Windows.Forms.ComboBox
        Me.cboSearchGedung = New System.Windows.Forms.ComboBox
        Me.chkSearchGedung = New System.Windows.Forms.CheckBox
        Me.chkSearchLantai = New System.Windows.Forms.CheckBox
        Me.cboSearchDepartment = New System.Windows.Forms.ComboBox
        Me.chkSearchDepartment = New System.Windows.Forms.CheckBox
        Me.chkSearchYear = New System.Windows.Forms.CheckBox
        Me.chkSearchMonth = New System.Windows.Forms.CheckBox
        Me.cboSearchYear = New System.Windows.Forms.NumericUpDown
        Me.cboSearchMonth = New System.Windows.Forms.NumericUpDown
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.PnlDfFooter.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
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
        Me.RvLaporanPenerimaanAsset.Location = New System.Drawing.Point(0, 93)
        Me.RvLaporanPenerimaanAsset.Name = "RvLaporanPenerimaanAsset"
        Me.RvLaporanPenerimaanAsset.Size = New System.Drawing.Size(753, 391)
        Me.RvLaporanPenerimaanAsset.TabIndex = 1
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDfMain.Location = New System.Drawing.Point(0, 93)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(753, 391)
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
        Me.PnlDfSearch.Controls.Add(Me.cboSearchLantai)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchGedung)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchGedung)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchLantai)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchDepartment)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchDepartment)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchYear)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchMonth)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchYear)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchMonth)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(0, 0)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(753, 93)
        Me.PnlDfSearch.TabIndex = 1
        '
        'cboSearchLantai
        '
        Me.cboSearchLantai.FormattingEnabled = True
        Me.cboSearchLantai.Location = New System.Drawing.Point(560, 60)
        Me.cboSearchLantai.Name = "cboSearchLantai"
        Me.cboSearchLantai.Size = New System.Drawing.Size(54, 21)
        Me.cboSearchLantai.TabIndex = 42
        '
        'cboSearchGedung
        '
        Me.cboSearchGedung.FormattingEnabled = True
        Me.cboSearchGedung.Location = New System.Drawing.Point(171, 60)
        Me.cboSearchGedung.Name = "cboSearchGedung"
        Me.cboSearchGedung.Size = New System.Drawing.Size(213, 21)
        Me.cboSearchGedung.TabIndex = 40
        '
        'chkSearchGedung
        '
        Me.chkSearchGedung.AutoSize = True
        Me.chkSearchGedung.Location = New System.Drawing.Point(84, 62)
        Me.chkSearchGedung.Name = "chkSearchGedung"
        Me.chkSearchGedung.Size = New System.Drawing.Size(64, 17)
        Me.chkSearchGedung.TabIndex = 39
        Me.chkSearchGedung.Text = "Gedung"
        Me.chkSearchGedung.UseVisualStyleBackColor = True
        '
        'chkSearchLantai
        '
        Me.chkSearchLantai.AutoSize = True
        Me.chkSearchLantai.Location = New System.Drawing.Point(496, 61)
        Me.chkSearchLantai.Name = "chkSearchLantai"
        Me.chkSearchLantai.Size = New System.Drawing.Size(55, 17)
        Me.chkSearchLantai.TabIndex = 37
        Me.chkSearchLantai.Text = "Lantai"
        Me.chkSearchLantai.UseVisualStyleBackColor = True
        '
        'cboSearchDepartment
        '
        Me.cboSearchDepartment.FormattingEnabled = True
        Me.cboSearchDepartment.Items.AddRange(New Object() {"-- PILIH --", "Art Dept (ART)", "ArtProp(ArP)", "ArtWardrobe(ArW)", "IT Department (ITE)", "Technical Services Dept (TSV)"})
        Me.cboSearchDepartment.Location = New System.Drawing.Point(171, 34)
        Me.cboSearchDepartment.Name = "cboSearchDepartment"
        Me.cboSearchDepartment.Size = New System.Drawing.Size(213, 21)
        Me.cboSearchDepartment.TabIndex = 36
        '
        'chkSearchDepartment
        '
        Me.chkSearchDepartment.AutoSize = True
        Me.chkSearchDepartment.Location = New System.Drawing.Point(84, 36)
        Me.chkSearchDepartment.Name = "chkSearchDepartment"
        Me.chkSearchDepartment.Size = New System.Drawing.Size(81, 17)
        Me.chkSearchDepartment.TabIndex = 35
        Me.chkSearchDepartment.Text = "Department"
        Me.chkSearchDepartment.UseVisualStyleBackColor = True
        '
        'chkSearchYear
        '
        Me.chkSearchYear.AutoSize = True
        Me.chkSearchYear.Location = New System.Drawing.Point(496, 36)
        Me.chkSearchYear.Name = "chkSearchYear"
        Me.chkSearchYear.Size = New System.Drawing.Size(48, 17)
        Me.chkSearchYear.TabIndex = 32
        Me.chkSearchYear.Text = "Year"
        Me.chkSearchYear.UseVisualStyleBackColor = True
        '
        'chkSearchMonth
        '
        Me.chkSearchMonth.AutoSize = True
        Me.chkSearchMonth.Location = New System.Drawing.Point(496, 10)
        Me.chkSearchMonth.Name = "chkSearchMonth"
        Me.chkSearchMonth.Size = New System.Drawing.Size(56, 17)
        Me.chkSearchMonth.TabIndex = 31
        Me.chkSearchMonth.Text = "Month"
        Me.chkSearchMonth.UseVisualStyleBackColor = True
        '
        'cboSearchYear
        '
        Me.cboSearchYear.Location = New System.Drawing.Point(560, 35)
        Me.cboSearchYear.Maximum = New Decimal(New Integer() {2200, 0, 0, 0})
        Me.cboSearchYear.Minimum = New Decimal(New Integer() {1998, 0, 0, 0})
        Me.cboSearchYear.Name = "cboSearchYear"
        Me.cboSearchYear.Size = New System.Drawing.Size(54, 20)
        Me.cboSearchYear.TabIndex = 28
        Me.cboSearchYear.Value = New Decimal(New Integer() {2008, 0, 0, 0})
        '
        'cboSearchMonth
        '
        Me.cboSearchMonth.Location = New System.Drawing.Point(560, 10)
        Me.cboSearchMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.cboSearchMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.cboSearchMonth.Name = "cboSearchMonth"
        Me.cboSearchMonth.Size = New System.Drawing.Size(54, 20)
        Me.cboSearchMonth.TabIndex = 27
        Me.cboSearchMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(171, 8)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(121, 21)
        Me.cboSearchChannel.TabIndex = 3
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Checked = True
        Me.chkSearchChannel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchChannel.Location = New System.Drawing.Point(84, 10)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 2
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'uiLaporanPenerimaanAsset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "uiLaporanPenerimaanAsset"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.PnlDfFooter.ResumeLayout(False)
        Me.PnlDfFooter.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
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
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchYear As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchMonth As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboSearchMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboSearchGedung As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchGedung As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchLantai As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchDepartment As System.Windows.Forms.CheckBox
    Friend WithEvents RvLaporanPenerimaanAsset As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cboSearchLantai As System.Windows.Forms.ComboBox

End Class
