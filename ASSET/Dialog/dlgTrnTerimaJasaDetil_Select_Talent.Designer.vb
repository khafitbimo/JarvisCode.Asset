<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnTerimaJasaDetil_Select_Talent
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnSelect = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.DgvTalentOrder = New System.Windows.Forms.DataGridView
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.LinkClear1 = New System.Windows.Forms.LinkLabel
        Me.LinkCheck1 = New System.Windows.Forms.LinkLabel
        CType(Me.DgvTalentOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(516, 417)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 21)
        Me.btnSelect.TabIndex = 13
        Me.btnSelect.Text = "Ok"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(597, 417)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'DgvTalentOrder
        '
        Me.DgvTalentOrder.BackgroundColor = System.Drawing.Color.Lavender
        Me.DgvTalentOrder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTalentOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvTalentOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTalentOrder.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTalentOrder.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvTalentOrder.GridColor = System.Drawing.Color.Moccasin
        Me.DgvTalentOrder.Location = New System.Drawing.Point(16, 12)
        Me.DgvTalentOrder.Name = "DgvTalentOrder"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTalentOrder.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvTalentOrder.Size = New System.Drawing.Size(656, 399)
        Me.DgvTalentOrder.TabIndex = 26
        '
        'LinkClear1
        '
        Me.LinkClear1.AutoSize = True
        Me.LinkClear1.Location = New System.Drawing.Point(85, 414)
        Me.LinkClear1.Name = "LinkClear1"
        Me.LinkClear1.Size = New System.Drawing.Size(77, 13)
        Me.LinkClear1.TabIndex = 44
        Me.LinkClear1.TabStop = True
        Me.LinkClear1.Text = "Clear Checked"
        '
        'LinkCheck1
        '
        Me.LinkCheck1.AutoSize = True
        Me.LinkCheck1.Location = New System.Drawing.Point(13, 414)
        Me.LinkCheck1.Name = "LinkCheck1"
        Me.LinkCheck1.Size = New System.Drawing.Size(52, 13)
        Me.LinkCheck1.TabIndex = 43
        Me.LinkCheck1.TabStop = True
        Me.LinkCheck1.Text = "Check All"
        '
        'dlgTrnTerimaJasaDetil_Select_Talent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(685, 440)
        Me.ControlBox = False
        Me.Controls.Add(Me.LinkClear1)
        Me.Controls.Add(Me.LinkCheck1)
        Me.Controls.Add(Me.DgvTalentOrder)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSelect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgTrnTerimaJasaDetil_Select_Talent"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Transaksi Terima Jasa - List Talent Order"
        CType(Me.DgvTalentOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DgvTalentOrder As System.Windows.Forms.DataGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents LinkClear1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkCheck1 As System.Windows.Forms.LinkLabel
End Class
