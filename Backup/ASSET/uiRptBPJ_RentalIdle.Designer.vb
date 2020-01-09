<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiRptBPJ_RentalIdle
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
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.cbo_typePrint = New System.Windows.Forms.ComboBox
        Me.chk_TypePrint = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbo_Group = New System.Windows.Forms.ComboBox
        Me.chkSearch_Group = New System.Windows.Forms.CheckBox
        Me.obj_end_date = New System.Windows.Forms.DateTimePicker
        Me.obj_start_date = New System.Windows.Forms.DateTimePicker
        Me.Panel1.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
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
        Me.RvLaporanPenerimaanAsset.Location = New System.Drawing.Point(0, 56)
        Me.RvLaporanPenerimaanAsset.Name = "RvLaporanPenerimaanAsset"
        Me.RvLaporanPenerimaanAsset.Size = New System.Drawing.Size(753, 452)
        Me.RvLaporanPenerimaanAsset.TabIndex = 1
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDfMain.Location = New System.Drawing.Point(0, 56)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(753, 452)
        Me.PnlDfMain.TabIndex = 4
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(0, 508)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(753, 15)
        Me.PnlDfFooter.TabIndex = 3
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.BackColor = System.Drawing.Color.SkyBlue
        Me.PnlDfSearch.Controls.Add(Me.cbo_typePrint)
        Me.PnlDfSearch.Controls.Add(Me.chk_TypePrint)
        Me.PnlDfSearch.Controls.Add(Me.Label3)
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.cbo_Group)
        Me.PnlDfSearch.Controls.Add(Me.chkSearch_Group)
        Me.PnlDfSearch.Controls.Add(Me.obj_end_date)
        Me.PnlDfSearch.Controls.Add(Me.obj_start_date)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(0, 0)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(753, 56)
        Me.PnlDfSearch.TabIndex = 1
        '
        'cbo_typePrint
        '
        Me.cbo_typePrint.FormattingEnabled = True
        Me.cbo_typePrint.Items.AddRange(New Object() {"-- Pilih --", "Details", "Recap", "Summary Order (Details)", "Summary Order (Recap)"})
        Me.cbo_typePrint.Location = New System.Drawing.Point(359, 3)
        Me.cbo_typePrint.Name = "cbo_typePrint"
        Me.cbo_typePrint.Size = New System.Drawing.Size(124, 21)
        Me.cbo_typePrint.TabIndex = 59
        '
        'chk_TypePrint
        '
        Me.chk_TypePrint.AutoSize = True
        Me.chk_TypePrint.Checked = True
        Me.chk_TypePrint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_TypePrint.Enabled = False
        Me.chk_TypePrint.Location = New System.Drawing.Point(301, 6)
        Me.chk_TypePrint.Name = "chk_TypePrint"
        Me.chk_TypePrint.Size = New System.Drawing.Size(55, 17)
        Me.chk_TypePrint.TabIndex = 58
        Me.chk_TypePrint.Text = "Group"
        Me.chk_TypePrint.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(156, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "And"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Between"
        '
        'cbo_Group
        '
        Me.cbo_Group.FormattingEnabled = True
        Me.cbo_Group.Items.AddRange(New Object() {"-- Pilih --", "Budget", "Department", "Employee", "Rekanan"})
        Me.cbo_Group.Location = New System.Drawing.Point(60, 26)
        Me.cbo_Group.Name = "cbo_Group"
        Me.cbo_Group.Size = New System.Drawing.Size(221, 21)
        Me.cbo_Group.TabIndex = 51
        '
        'chkSearch_Group
        '
        Me.chkSearch_Group.AutoSize = True
        Me.chkSearch_Group.Checked = True
        Me.chkSearch_Group.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearch_Group.Enabled = False
        Me.chkSearch_Group.Location = New System.Drawing.Point(6, 30)
        Me.chkSearch_Group.Name = "chkSearch_Group"
        Me.chkSearch_Group.Size = New System.Drawing.Size(55, 17)
        Me.chkSearch_Group.TabIndex = 50
        Me.chkSearch_Group.Text = "Group"
        Me.chkSearch_Group.UseVisualStyleBackColor = True
        '
        'obj_end_date
        '
        Me.obj_end_date.CustomFormat = "dd/MM/yyyy"
        Me.obj_end_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_end_date.Location = New System.Drawing.Point(188, 4)
        Me.obj_end_date.Name = "obj_end_date"
        Me.obj_end_date.Size = New System.Drawing.Size(93, 20)
        Me.obj_end_date.TabIndex = 47
        '
        'obj_start_date
        '
        Me.obj_start_date.CustomFormat = "dd/MM/yyyy"
        Me.obj_start_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.obj_start_date.Location = New System.Drawing.Point(60, 4)
        Me.obj_start_date.Name = "obj_start_date"
        Me.obj_start_date.Size = New System.Drawing.Size(90, 20)
        Me.obj_start_date.TabIndex = 45
        '
        'uiRptBPJ_RentalIdle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "uiRptBPJ_RentalIdle"
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
    Friend WithEvents RvLaporanPenerimaanAsset As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents obj_start_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents obj_end_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo_Group As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearch_Group As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbo_typePrint As System.Windows.Forms.ComboBox
    Friend WithEvents chk_TypePrint As System.Windows.Forms.CheckBox


End Class
