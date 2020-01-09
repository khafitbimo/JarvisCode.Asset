<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgSelectEps
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.obj_eps_end = New System.Windows.Forms.TextBox
        Me.obj_eps_start = New System.Windows.Forms.TextBox
        Me.obj_Item_name = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.obj_Requestdetil_descr = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_Requestdetil_line = New System.Windows.Forms.TextBox
        Me.lnkClearAll = New System.Windows.Forms.LinkLabel
        Me.lnkCheckAll = New System.Windows.Forms.LinkLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DgvRequestdetileps = New System.Windows.Forms.DataGridView
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvRequestdetileps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.obj_eps_end)
        Me.GroupBox3.Controls.Add(Me.obj_eps_start)
        Me.GroupBox3.Controls.Add(Me.obj_Item_name)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.obj_Requestdetil_descr)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.obj_Requestdetil_line)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(379, 86)
        Me.GroupBox3.TabIndex = 60
        Me.GroupBox3.TabStop = False
        '
        'obj_eps_end
        '
        Me.obj_eps_end.BackColor = System.Drawing.Color.White
        Me.obj_eps_end.Location = New System.Drawing.Point(63, 60)
        Me.obj_eps_end.Name = "obj_eps_end"
        Me.obj_eps_end.ReadOnly = True
        Me.obj_eps_end.Size = New System.Drawing.Size(98, 20)
        Me.obj_eps_end.TabIndex = 81
        '
        'obj_eps_start
        '
        Me.obj_eps_start.BackColor = System.Drawing.Color.White
        Me.obj_eps_start.Location = New System.Drawing.Point(63, 38)
        Me.obj_eps_start.Name = "obj_eps_start"
        Me.obj_eps_start.ReadOnly = True
        Me.obj_eps_start.Size = New System.Drawing.Size(98, 20)
        Me.obj_eps_start.TabIndex = 80
        '
        'obj_Item_name
        '
        Me.obj_Item_name.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_Item_name.Location = New System.Drawing.Point(228, 15)
        Me.obj_Item_name.Name = "obj_Item_name"
        Me.obj_Item_name.Size = New System.Drawing.Size(140, 20)
        Me.obj_Item_name.TabIndex = 79
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(169, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Descr"
        '
        'obj_Requestdetil_descr
        '
        Me.obj_Requestdetil_descr.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_Requestdetil_descr.Location = New System.Drawing.Point(228, 38)
        Me.obj_Requestdetil_descr.Multiline = True
        Me.obj_Requestdetil_descr.Name = "obj_Requestdetil_descr"
        Me.obj_Requestdetil_descr.Size = New System.Drawing.Size(140, 41)
        Me.obj_Requestdetil_descr.TabIndex = 77
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(169, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Artis Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Line"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Eps End"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Eps Start"
        '
        'obj_Requestdetil_line
        '
        Me.obj_Requestdetil_line.BackColor = System.Drawing.Color.Gainsboro
        Me.obj_Requestdetil_line.Location = New System.Drawing.Point(63, 15)
        Me.obj_Requestdetil_line.Name = "obj_Requestdetil_line"
        Me.obj_Requestdetil_line.ReadOnly = True
        Me.obj_Requestdetil_line.Size = New System.Drawing.Size(98, 20)
        Me.obj_Requestdetil_line.TabIndex = 67
        Me.obj_Requestdetil_line.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lnkClearAll
        '
        Me.lnkClearAll.AutoSize = True
        Me.lnkClearAll.Location = New System.Drawing.Point(73, 229)
        Me.lnkClearAll.Name = "lnkClearAll"
        Me.lnkClearAll.Size = New System.Drawing.Size(45, 13)
        Me.lnkClearAll.TabIndex = 58
        Me.lnkClearAll.TabStop = True
        Me.lnkClearAll.Text = "Clear All"
        '
        'lnkCheckAll
        '
        Me.lnkCheckAll.AutoSize = True
        Me.lnkCheckAll.Location = New System.Drawing.Point(7, 229)
        Me.lnkCheckAll.Name = "lnkCheckAll"
        Me.lnkCheckAll.Size = New System.Drawing.Size(52, 13)
        Me.lnkCheckAll.TabIndex = 57
        Me.lnkCheckAll.TabStop = True
        Me.lnkCheckAll.Text = "Check All"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lnkClearAll)
        Me.GroupBox2.Controls.Add(Me.lnkCheckAll)
        Me.GroupBox2.Controls.Add(Me.DgvRequestdetileps)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 93)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(379, 249)
        Me.GroupBox2.TabIndex = 61
        Me.GroupBox2.TabStop = False
        '
        'DgvRequestdetileps
        '
        Me.DgvRequestdetileps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRequestdetileps.Location = New System.Drawing.Point(10, 15)
        Me.DgvRequestdetileps.Name = "DgvRequestdetileps"
        Me.DgvRequestdetileps.Size = New System.Drawing.Size(358, 207)
        Me.DgvRequestdetileps.TabIndex = 54
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(293, 13)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnOK)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 343)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(379, 43)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(212, 13)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'DlgSelectEps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 393)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "DlgSelectEps"
        Me.Text = "Select Eps"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DgvRequestdetileps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents obj_Item_name As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents obj_Requestdetil_descr As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_Requestdetil_line As System.Windows.Forms.TextBox
    Friend WithEvents lnkClearAll As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkCheckAll As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DgvRequestdetileps As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents obj_eps_end As System.Windows.Forms.TextBox
    Friend WithEvents obj_eps_start As System.Windows.Forms.TextBox
End Class
