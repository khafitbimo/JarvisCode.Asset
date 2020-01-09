<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRptPenerimaanBarang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(Disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rvPenerimaanBarang = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'rvPenerimaanBarang
        '
        Me.rvPenerimaanBarang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvPenerimaanBarang.Location = New System.Drawing.Point(0, 0)
        Me.rvPenerimaanBarang.Name = "rvPenerimaanBarang"
        Me.rvPenerimaanBarang.Size = New System.Drawing.Size(837, 514)
        Me.rvPenerimaanBarang.TabIndex = 0
        '
        'dlgRptPenerimaanBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 514)
        Me.Controls.Add(Me.rvPenerimaanBarang)
        Me.Name = "dlgRptPenerimaanBarang"
        Me.Text = "dlgRptPenerimaanBarang"
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents rvPenerimaanBarang As Microsoft.Reporting.WinForms.ReportViewer
End Class