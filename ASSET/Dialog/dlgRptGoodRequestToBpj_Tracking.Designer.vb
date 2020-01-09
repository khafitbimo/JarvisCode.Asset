<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgRptGoodRequestToBpj_Tracking
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
        Me.RvSearch = New Microsoft.Reporting.WinForms.ReportViewer
        Me.SuspendLayout()
        '
        'RvSearch
        '
        Me.RvSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RvSearch.Location = New System.Drawing.Point(0, 0)
        Me.RvSearch.Name = "RvSearch"
        Me.RvSearch.Size = New System.Drawing.Size(837, 514)
        Me.RvSearch.TabIndex = 0
        '
        'dlgRptGoodRequestToBpj_Tracking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 514)
        Me.Controls.Add(Me.RvSearch)
        Me.Name = "dlgRptGoodRequestToBpj_Tracking"
        Me.Text = "dlgRptGoodRequestToBpj_Tracking"
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents RvSearch As Microsoft.Reporting.WinForms.ReportViewer
End Class