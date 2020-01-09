<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRptTerimaJasaEditing
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
        Me.rvTerimaJasaEditing = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'rvTerimaJasaEditing
        '
        Me.rvTerimaJasaEditing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvTerimaJasaEditing.Location = New System.Drawing.Point(0, 0)
        Me.rvTerimaJasaEditing.Name = "rvTerimaJasaEditing"
        Me.rvTerimaJasaEditing.Size = New System.Drawing.Size(837, 514)
        Me.rvTerimaJasaEditing.TabIndex = 0
        '
        'dlgRptTerimaJasaEditing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 514)
        Me.Controls.Add(Me.rvTerimaJasaEditing)
        Me.Name = "dlgRptTerimaJasaEditing"
        Me.Text = "dlgRptTerimaJasaEditing"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rvTerimaJasaEditing As Microsoft.Reporting.WinForms.ReportViewer
End Class