<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRptIncAsset
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
        Me.rvIncAsset = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'rvIncAsset
        '
        Me.rvIncAsset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvIncAsset.Location = New System.Drawing.Point(0, 0)
        Me.rvIncAsset.Name = "rvIncAsset"
        Me.rvIncAsset.Size = New System.Drawing.Size(806, 483)
        Me.rvIncAsset.TabIndex = 1
        '
        'dlgRptIncAsset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 483)
        Me.Controls.Add(Me.rvIncAsset)
        Me.Name = "dlgRptIncAsset"
        Me.Text = "dlgRptIncAsset"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvIncAsset As Microsoft.Reporting.WinForms.ReportViewer

End Class
