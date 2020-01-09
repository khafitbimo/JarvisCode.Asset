<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRptBookasset
    Inherits System.Windows.Forms.Form

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
        Me.RvBookasset = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'RvBookasset
        '
        Me.RvBookasset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RvBookasset.Location = New System.Drawing.Point(0, 0)
        Me.RvBookasset.Name = "RvBookasset"
        Me.RvBookasset.Size = New System.Drawing.Size(837, 514)
        Me.RvBookasset.TabIndex = 0
        '
        'dlgRptBookasset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 514)
        Me.Controls.Add(Me.RvBookasset)
        Me.Name = "dlgRptBookasset"
        Me.Text = "dlgRptBookasset"
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents RvBookasset As Microsoft.Reporting.WinForms.ReportViewer
End Class