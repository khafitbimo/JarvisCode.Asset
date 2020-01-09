<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRptWriteOff
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
        Me.rvTrnWriteoff = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'rvTrnWriteoff
        '
        Me.rvTrnWriteoff.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvTrnWriteoff.Location = New System.Drawing.Point(0, 0)
        Me.rvTrnWriteoff.Name = "rvTrnWriteoff"
        Me.rvTrnWriteoff.Size = New System.Drawing.Size(837, 514)
        Me.rvTrnWriteoff.TabIndex = 0
        '
        'dlgRptWriteOff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 514)
        Me.Controls.Add(Me.rvTrnWriteoff)
        Me.Name = "dlgRptWriteOff"
        Me.Text = "dlgRptWriteOff"
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents rvTrnWriteoff As Microsoft.Reporting.WinForms.ReportViewer
End Class