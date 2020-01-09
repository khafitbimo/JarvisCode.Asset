<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlg_addPicture
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.cmd_add = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.cmd_save = New System.Windows.Forms.Button
        Me.obj_Request_pathfile = New System.Windows.Forms.TextBox
        Me.obj_Request_id = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OK_Button = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'cmd_add
        '
        Me.cmd_add.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmd_add.Location = New System.Drawing.Point(74, 248)
        Me.cmd_add.Name = "cmd_add"
        Me.cmd_add.Size = New System.Drawing.Size(67, 23)
        Me.cmd_add.TabIndex = 1
        Me.cmd_add.Text = "Add"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(340, 224)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'cmd_save
        '
        Me.cmd_save.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmd_save.Location = New System.Drawing.Point(147, 248)
        Me.cmd_save.Name = "cmd_save"
        Me.cmd_save.Size = New System.Drawing.Size(67, 23)
        Me.cmd_save.TabIndex = 3
        Me.cmd_save.Text = "Save"
        '
        'obj_Request_pathfile
        '
        Me.obj_Request_pathfile.BackColor = System.Drawing.Color.MistyRose
        Me.obj_Request_pathfile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.obj_Request_pathfile.Cursor = System.Windows.Forms.Cursors.Default
        Me.obj_Request_pathfile.Enabled = False
        Me.obj_Request_pathfile.ForeColor = System.Drawing.Color.MistyRose
        Me.obj_Request_pathfile.Location = New System.Drawing.Point(569, 15)
        Me.obj_Request_pathfile.Multiline = True
        Me.obj_Request_pathfile.Name = "obj_Request_pathfile"
        Me.obj_Request_pathfile.Size = New System.Drawing.Size(14, 20)
        Me.obj_Request_pathfile.TabIndex = 19
        '
        'obj_Request_id
        '
        Me.obj_Request_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obj_Request_id.Location = New System.Drawing.Point(472, 41)
        Me.obj_Request_id.Name = "obj_Request_id"
        Me.obj_Request_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Request_id.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(469, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 23)
        Me.Label1.TabIndex = 23
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(220, 248)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 24
        Me.OK_Button.Text = "Close"
        '
        'dlg_addPicture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(361, 275)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.obj_Request_id)
        Me.Controls.Add(Me.obj_Request_pathfile)
        Me.Controls.Add(Me.cmd_save)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmd_add)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlg_addPicture"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlg_addPicture"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmd_add As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmd_save As System.Windows.Forms.Button
    Friend WithEvents obj_Request_pathfile As System.Windows.Forms.TextBox
    Friend WithEvents obj_Request_id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OK_Button As System.Windows.Forms.Button

End Class
