<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgUpdateDepresiasiDetil
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
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.obj_barcode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_description = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.obj_cost_deductional = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.obj_depre_deductional = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.obj_cost_ending = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.obj_depre_ending = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.obj_depre_additional = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.obj_remark = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.OK_Button.Location = New System.Drawing.Point(156, 252)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 2
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(238, 252)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 3
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'obj_barcode
        '
        Me.obj_barcode.BackColor = System.Drawing.Color.LemonChiffon
        Me.obj_barcode.Location = New System.Drawing.Point(114, 12)
        Me.obj_barcode.Name = "obj_barcode"
        Me.obj_barcode.ReadOnly = True
        Me.obj_barcode.Size = New System.Drawing.Size(191, 20)
        Me.obj_barcode.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Barcode"
        '
        'obj_description
        '
        Me.obj_description.BackColor = System.Drawing.Color.LemonChiffon
        Me.obj_description.Location = New System.Drawing.Point(114, 35)
        Me.obj_description.Multiline = True
        Me.obj_description.Name = "obj_description"
        Me.obj_description.ReadOnly = True
        Me.obj_description.Size = New System.Drawing.Size(191, 46)
        Me.obj_description.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Description"
        '
        'obj_cost_deductional
        '
        Me.obj_cost_deductional.Location = New System.Drawing.Point(114, 106)
        Me.obj_cost_deductional.Name = "obj_cost_deductional"
        Me.obj_cost_deductional.Size = New System.Drawing.Size(191, 20)
        Me.obj_cost_deductional.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Cost Deductional"
        '
        'obj_depre_deductional
        '
        Me.obj_depre_deductional.Location = New System.Drawing.Point(114, 129)
        Me.obj_depre_deductional.Name = "obj_depre_deductional"
        Me.obj_depre_deductional.Size = New System.Drawing.Size(191, 20)
        Me.obj_depre_deductional.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Depr. Deductional"
        '
        'obj_cost_ending
        '
        Me.obj_cost_ending.BackColor = System.Drawing.Color.LemonChiffon
        Me.obj_cost_ending.Location = New System.Drawing.Point(114, 152)
        Me.obj_cost_ending.Name = "obj_cost_ending"
        Me.obj_cost_ending.ReadOnly = True
        Me.obj_cost_ending.Size = New System.Drawing.Size(191, 20)
        Me.obj_cost_ending.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Cost Ending"
        '
        'obj_depre_ending
        '
        Me.obj_depre_ending.BackColor = System.Drawing.Color.LemonChiffon
        Me.obj_depre_ending.Location = New System.Drawing.Point(114, 175)
        Me.obj_depre_ending.Name = "obj_depre_ending"
        Me.obj_depre_ending.ReadOnly = True
        Me.obj_depre_ending.Size = New System.Drawing.Size(191, 20)
        Me.obj_depre_ending.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Depr. Ending"
        '
        'obj_depre_additional
        '
        Me.obj_depre_additional.BackColor = System.Drawing.Color.LemonChiffon
        Me.obj_depre_additional.Location = New System.Drawing.Point(114, 84)
        Me.obj_depre_additional.Name = "obj_depre_additional"
        Me.obj_depre_additional.ReadOnly = True
        Me.obj_depre_additional.Size = New System.Drawing.Size(191, 20)
        Me.obj_depre_additional.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Depr. Additional"
        '
        'obj_remark
        '
        Me.obj_remark.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_remark.Location = New System.Drawing.Point(114, 198)
        Me.obj_remark.Multiline = True
        Me.obj_remark.Name = "obj_remark"
        Me.obj_remark.Size = New System.Drawing.Size(191, 46)
        Me.obj_remark.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 198)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Remark"
        '
        'dlgUpdateDepresiasiDetil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(326, 281)
        Me.Controls.Add(Me.obj_remark)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.obj_depre_additional)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.obj_depre_ending)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.obj_cost_ending)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.obj_depre_deductional)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.obj_cost_deductional)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.obj_description)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.obj_barcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Cancel_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgUpdateDepresiasiDetil"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlgUpdateDepresiasiDetil"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents obj_barcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_description As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents obj_cost_deductional As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents obj_depre_deductional As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents obj_cost_ending As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents obj_depre_ending As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents obj_depre_additional As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents obj_remark As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
