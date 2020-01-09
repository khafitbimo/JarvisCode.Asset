<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewData
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
        Me.btn_ok = New System.Windows.Forms.Button
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.obj_oto = New System.Windows.Forms.TextBox
        Me.obj_manual = New System.Windows.Forms.RadioButton
        Me.obj_automatic = New System.Windows.Forms.RadioButton
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_ok
        '
        Me.btn_ok.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_ok.Location = New System.Drawing.Point(94, 60)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(51, 25)
        Me.btn_ok.TabIndex = 2
        Me.btn_ok.Text = "Ok"
        Me.btn_ok.UseVisualStyleBackColor = False
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_cancel.Location = New System.Drawing.Point(151, 60)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(51, 25)
        Me.btn_cancel.TabIndex = 3
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.Controls.Add(Me.obj_oto)
        Me.Panel1.Controls.Add(Me.obj_manual)
        Me.Panel1.Controls.Add(Me.btn_cancel)
        Me.Panel1.Controls.Add(Me.obj_automatic)
        Me.Panel1.Controls.Add(Me.btn_ok)
        Me.Panel1.Location = New System.Drawing.Point(1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(215, 94)
        Me.Panel1.TabIndex = 4
        '
        'obj_oto
        '
        Me.obj_oto.Enabled = False
        Me.obj_oto.Location = New System.Drawing.Point(94, 31)
        Me.obj_oto.Name = "obj_oto"
        Me.obj_oto.Size = New System.Drawing.Size(108, 20)
        Me.obj_oto.TabIndex = 4
        '
        'obj_manual
        '
        Me.obj_manual.AutoSize = True
        Me.obj_manual.Location = New System.Drawing.Point(9, 13)
        Me.obj_manual.Name = "obj_manual"
        Me.obj_manual.Size = New System.Drawing.Size(60, 17)
        Me.obj_manual.TabIndex = 2
        Me.obj_manual.TabStop = True
        Me.obj_manual.Text = "Manual"
        Me.obj_manual.UseVisualStyleBackColor = True
        '
        'obj_automatic
        '
        Me.obj_automatic.AutoSize = True
        Me.obj_automatic.Location = New System.Drawing.Point(9, 32)
        Me.obj_automatic.Name = "obj_automatic"
        Me.obj_automatic.Size = New System.Drawing.Size(84, 17)
        Me.obj_automatic.TabIndex = 3
        Me.obj_automatic.TabStop = True
        Me.obj_automatic.Text = "Booking No."
        Me.obj_automatic.UseVisualStyleBackColor = True
        '
        'NewData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(211, 91)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "NewData"
        Me.Text = "Order Type"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents obj_manual As System.Windows.Forms.RadioButton
    Friend WithEvents obj_automatic As System.Windows.Forms.RadioButton
    Friend WithEvents obj_oto As System.Windows.Forms.TextBox
End Class
