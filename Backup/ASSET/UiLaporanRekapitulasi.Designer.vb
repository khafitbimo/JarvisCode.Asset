<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UiLaporanRekapitulasi
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
        Me.RvLaporanRekapitulasiAsset = New Microsoft.Reporting.WinForms.ReportViewer
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.cboReportName = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboSearchKategori = New System.Windows.Forms.ComboBox
        Me.chkSearchKategori = New System.Windows.Forms.CheckBox
        Me.chkSearchDate = New System.Windows.Forms.CheckBox
        Me.obj_Bookasset_date = New System.Windows.Forms.DateTimePicker
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.RvLaporanRekapitulasiAsset)
        Me.Panel1.Controls.Add(Me.PnlDfMain)
        Me.Panel1.Controls.Add(Me.PnlDfFooter)
        Me.Panel1.Controls.Add(Me.PnlDfSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(753, 523)
        Me.Panel1.TabIndex = 7
        '
        'RvLaporanRekapitulasiAsset
        '
        Me.RvLaporanRekapitulasiAsset.Location = New System.Drawing.Point(0, 135)
        Me.RvLaporanRekapitulasiAsset.Name = "RvLaporanRekapitulasiAsset"
        Me.RvLaporanRekapitulasiAsset.Size = New System.Drawing.Size(753, 349)
        Me.RvLaporanRekapitulasiAsset.TabIndex = 1
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
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(0, 484)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(753, 39)
        Me.PnlDfFooter.TabIndex = 3
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.BackColor = System.Drawing.Color.SkyBlue
        Me.PnlDfSearch.Controls.Add(Me.cboReportName)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchKategori)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchKategori)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchDate)
        Me.PnlDfSearch.Controls.Add(Me.obj_Bookasset_date)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(0, 0)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(753, 93)
        Me.PnlDfSearch.TabIndex = 1
        '
        'cboReportName
        '
        Me.cboReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportName.FormattingEnabled = True
        Me.cboReportName.Items.AddRange(New Object() {"-- Pilih --", "Rekapitulasi Booking", "Rekapitulasi OutGoing", "Summary Rekapitulasi"})
        Me.cboReportName.Location = New System.Drawing.Point(526, 8)
        Me.cboReportName.Name = "cboReportName"
        Me.cboReportName.Size = New System.Drawing.Size(163, 21)
        Me.cboReportName.TabIndex = 137
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(449, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 136
        Me.Label1.Text = "Report Name"
        '
        'cboSearchKategori
        '
        Me.cboSearchKategori.FormattingEnabled = True
        Me.cboSearchKategori.Location = New System.Drawing.Point(171, 62)
        Me.cboSearchKategori.Name = "cboSearchKategori"
        Me.cboSearchKategori.Size = New System.Drawing.Size(205, 21)
        Me.cboSearchKategori.TabIndex = 47
        '
        'chkSearchKategori
        '
        Me.chkSearchKategori.AutoSize = True
        Me.chkSearchKategori.Location = New System.Drawing.Point(84, 64)
        Me.chkSearchKategori.Name = "chkSearchKategori"
        Me.chkSearchKategori.Size = New System.Drawing.Size(68, 17)
        Me.chkSearchKategori.TabIndex = 46
        Me.chkSearchKategori.Text = "Category"
        Me.chkSearchKategori.UseVisualStyleBackColor = True
        '
        'chkSearchDate
        '
        Me.chkSearchDate.AutoSize = True
        Me.chkSearchDate.Checked = True
        Me.chkSearchDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchDate.Enabled = False
        Me.chkSearchDate.Location = New System.Drawing.Point(84, 38)
        Me.chkSearchDate.Name = "chkSearchDate"
        Me.chkSearchDate.Size = New System.Drawing.Size(49, 17)
        Me.chkSearchDate.TabIndex = 44
        Me.chkSearchDate.Text = "Date"
        Me.chkSearchDate.UseVisualStyleBackColor = True
        '
        'obj_Bookasset_date
        '
        Me.obj_Bookasset_date.CustomFormat = "dd/MM/yyyy"
        Me.obj_Bookasset_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_Bookasset_date.Location = New System.Drawing.Point(171, 36)
        Me.obj_Bookasset_date.Name = "obj_Bookasset_date"
        Me.obj_Bookasset_date.Size = New System.Drawing.Size(121, 20)
        Me.obj_Bookasset_date.TabIndex = 43
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
        Me.chkSearchChannel.Enabled = False
        Me.chkSearchChannel.Location = New System.Drawing.Point(84, 10)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 2
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'UiLaporanRekapitulasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UiLaporanRekapitulasi"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents RvLaporanRekapitulasiAsset As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents chkSearchDate As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Bookasset_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboSearchKategori As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchKategori As System.Windows.Forms.CheckBox
    Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
