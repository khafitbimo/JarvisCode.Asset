<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgUpdateStatusMaintenance
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
        Me.tbtn_OK = New System.Windows.Forms.Button
        Me.tbtn_Cancel = New System.Windows.Forms.Button
        Me.obj_status = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'tbtn_OK
        '
        Me.tbtn_OK.Location = New System.Drawing.Point(16, 43)
        Me.tbtn_OK.Name = "tbtn_OK"
        Me.tbtn_OK.Size = New System.Drawing.Size(50, 23)
        Me.tbtn_OK.TabIndex = 0
        Me.tbtn_OK.Text = "OK"
        Me.tbtn_OK.UseVisualStyleBackColor = True
        '
        'tbtn_Cancel
        '
        Me.tbtn_Cancel.Location = New System.Drawing.Point(86, 43)
        Me.tbtn_Cancel.Name = "tbtn_Cancel"
        Me.tbtn_Cancel.Size = New System.Drawing.Size(49, 23)
        Me.tbtn_Cancel.TabIndex = 1
        Me.tbtn_Cancel.Text = "Cancel"
        Me.tbtn_Cancel.UseVisualStyleBackColor = True
        '
        'obj_status
        '
        Me.obj_status.Location = New System.Drawing.Point(16, 16)
        Me.obj_status.Name = "obj_status"
        Me.obj_status.Size = New System.Drawing.Size(119, 21)
        Me.obj_status.TabIndex = 11
        '
        'dlgUpdateStatusMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(149, 78)
        Me.Controls.Add(Me.obj_status)
        Me.Controls.Add(Me.tbtn_Cancel)
        Me.Controls.Add(Me.tbtn_OK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgUpdateStatusMaintenance"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlgUpdateStatusMaintenance"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbtn_OK As System.Windows.Forms.Button
    Friend WithEvents tbtn_Cancel As System.Windows.Forms.Button
    Friend WithEvents obj_status As System.Windows.Forms.ComboBox

End Class
