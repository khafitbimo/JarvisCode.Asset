<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRptTerimaJasaTalent
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
        Me.rvTerimaJasaTalent = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'rvTerimaJasaTalent
        '
        Me.rvTerimaJasaTalent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvTerimaJasaTalent.Location = New System.Drawing.Point(0, 0)
        Me.rvTerimaJasaTalent.Name = "rvTerimaJasaTalent"
        Me.rvTerimaJasaTalent.Size = New System.Drawing.Size(837, 514)
        Me.rvTerimaJasaTalent.TabIndex = 0
        '
        'dlgRptTerimaJasaTalent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 514)
        Me.Controls.Add(Me.rvTerimaJasaTalent)
        Me.Name = "dlgRptTerimaJasaTalent"
        Me.Text = "dlgRptTerimaJasaTalent"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rvTerimaJasaTalent As Microsoft.Reporting.WinForms.ReportViewer
End Class