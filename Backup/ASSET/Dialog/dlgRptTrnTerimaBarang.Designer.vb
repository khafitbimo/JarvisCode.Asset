<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRptTrnTerimaBarang
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
        Me.rvTerimaBarang = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'rvTerimaBarang
        '
        Me.rvTerimaBarang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvTerimaBarang.Location = New System.Drawing.Point(0, 0)
        Me.rvTerimaBarang.Name = "rvTerimaBarang"
        Me.rvTerimaBarang.Size = New System.Drawing.Size(837, 514)
        Me.rvTerimaBarang.TabIndex = 0
        '
        'dlgRptTrnTerimaBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 514)
        Me.Controls.Add(Me.rvTerimaBarang)
        Me.Name = "dlgRptTrnTerimaBarang"
        Me.Text = "dlgRptTrnTerimaBarang"
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents rvTerimaBarang As Microsoft.Reporting.WinForms.ReportViewer
End Class