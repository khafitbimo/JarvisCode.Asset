<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgNewDataIncoming
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
        Me.lbl_incBarcode = New System.Windows.Forms.Label
        Me.obj_incBarcode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_oto = New System.Windows.Forms.TextBox
        Me.btn_cancel = New System.Windows.Forms.Button
        Me.btn_ok = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lbl_incBarcode
        '
        Me.lbl_incBarcode.AutoSize = True
        Me.lbl_incBarcode.Location = New System.Drawing.Point(12, 59)
        Me.lbl_incBarcode.Name = "lbl_incBarcode"
        Me.lbl_incBarcode.Size = New System.Drawing.Size(47, 13)
        Me.lbl_incBarcode.TabIndex = 14
        Me.lbl_incBarcode.Text = "Barcode"
        '
        'obj_incBarcode
        '
        Me.obj_incBarcode.Location = New System.Drawing.Point(117, 56)
        Me.obj_incBarcode.Name = "obj_incBarcode"
        Me.obj_incBarcode.Size = New System.Drawing.Size(100, 20)
        Me.obj_incBarcode.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "OutGoing Number"
        '
        'obj_oto
        '
        Me.obj_oto.Location = New System.Drawing.Point(117, 6)
        Me.obj_oto.Name = "obj_oto"
        Me.obj_oto.Size = New System.Drawing.Size(100, 20)
        Me.obj_oto.TabIndex = 11
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_cancel.Location = New System.Drawing.Point(167, 28)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(50, 23)
        Me.btn_cancel.TabIndex = 10
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'btn_ok
        '
        Me.btn_ok.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_ok.Location = New System.Drawing.Point(117, 28)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(44, 23)
        Me.btn_ok.TabIndex = 9
        Me.btn_ok.Text = "Ok"
        Me.btn_ok.UseVisualStyleBackColor = False
        '
        'DlgNewDataIncoming
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(222, 80)
        Me.Controls.Add(Me.lbl_incBarcode)
        Me.Controls.Add(Me.obj_incBarcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.obj_oto)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_ok)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgNewDataIncoming"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_incBarcode As System.Windows.Forms.Label
    Friend WithEvents obj_incBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_oto As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_ok As System.Windows.Forms.Button

End Class
