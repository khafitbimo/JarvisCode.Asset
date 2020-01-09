<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRptDepre
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
        Me.rvDepresiasi = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'rvDepresiasi
        '
        Me.rvDepresiasi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvDepresiasi.Location = New System.Drawing.Point(0, 0)
        Me.rvDepresiasi.Name = "rvDepresiasi"
        Me.rvDepresiasi.Size = New System.Drawing.Size(837, 514)
        Me.rvDepresiasi.TabIndex = 0
        '
        'dlgRptDepre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 514)
        Me.Controls.Add(Me.rvDepresiasi)
        Me.Name = "dlgRptDepre"
        Me.Text = "dlgRptDepre"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rvDepresiasi As Microsoft.Reporting.WinForms.ReportViewer
End Class