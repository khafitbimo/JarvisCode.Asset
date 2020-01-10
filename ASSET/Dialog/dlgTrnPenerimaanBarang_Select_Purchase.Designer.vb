<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnPenerimaanBarang_Select_Purchase
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
        Me.obj_Channel_id = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.obj_order_id = New System.Windows.Forms.TextBox
        Me.DgvRentalOrder = New System.Windows.Forms.DataGridView
        Me.LinkClear1 = New System.Windows.Forms.LinkLabel
        Me.LinkCheck1 = New System.Windows.Forms.LinkLabel
        Me.chkRekanan = New System.Windows.Forms.CheckBox
        Me.chkSearchOrderID_Search = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkSearchSource = New System.Windows.Forms.CheckBox
        Me.obj_Source = New System.Windows.Forms.ComboBox
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.obj_Rekanan_id = New System.Windows.Forms.TextBox
        Me.btn_Rekanan = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkSearchTerimaBarangID_Search = New System.Windows.Forms.CheckBox
        Me.obj_terimabarang_id = New System.Windows.Forms.TextBox
        CType(Me.DgvRentalOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(769, 414)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 21)
        Me.btnSelect.TabIndex = 13
        Me.btnSelect.Text = "Ok"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(850, 414)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.Location = New System.Drawing.Point(98, 8)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.ReadOnly = True
        Me.obj_Channel_id.Size = New System.Drawing.Size(62, 20)
        Me.obj_Channel_id.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Company"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(836, 98)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(89, 24)
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = "Load"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'obj_order_id
        '
        Me.obj_order_id.Location = New System.Drawing.Point(98, 31)
        Me.obj_order_id.Multiline = True
        Me.obj_order_id.Name = "obj_order_id"
        Me.obj_order_id.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.obj_order_id.Size = New System.Drawing.Size(270, 61)
        Me.obj_order_id.TabIndex = 24
        '
        'DgvRentalOrder
        '
        Me.DgvRentalOrder.BackgroundColor = System.Drawing.Color.Lavender
        Me.DgvRentalOrder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvRentalOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvRentalOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRentalOrder.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvRentalOrder.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvRentalOrder.GridColor = System.Drawing.Color.Moccasin
        Me.DgvRentalOrder.Location = New System.Drawing.Point(16, 124)
        Me.DgvRentalOrder.Name = "DgvRentalOrder"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvRentalOrder.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvRentalOrder.Size = New System.Drawing.Size(909, 287)
        Me.DgvRentalOrder.TabIndex = 26
        '
        'LinkClear1
        '
        Me.LinkClear1.AutoSize = True
        Me.LinkClear1.Location = New System.Drawing.Point(93, 414)
        Me.LinkClear1.Name = "LinkClear1"
        Me.LinkClear1.Size = New System.Drawing.Size(77, 13)
        Me.LinkClear1.TabIndex = 42
        Me.LinkClear1.TabStop = True
        Me.LinkClear1.Text = "Clear Checked"
        '
        'LinkCheck1
        '
        Me.LinkCheck1.AutoSize = True
        Me.LinkCheck1.Location = New System.Drawing.Point(19, 414)
        Me.LinkCheck1.Name = "LinkCheck1"
        Me.LinkCheck1.Size = New System.Drawing.Size(52, 13)
        Me.LinkCheck1.TabIndex = 41
        Me.LinkCheck1.TabStop = True
        Me.LinkCheck1.Text = "Check All"
        '
        'chkRekanan
        '
        Me.chkRekanan.AutoSize = True
        Me.chkRekanan.Location = New System.Drawing.Point(434, 8)
        Me.chkRekanan.Name = "chkRekanan"
        Me.chkRekanan.Size = New System.Drawing.Size(84, 17)
        Me.chkRekanan.TabIndex = 47
        Me.chkRekanan.Text = "Rekanan ID"
        Me.chkRekanan.UseVisualStyleBackColor = True
        '
        'chkSearchOrderID_Search
        '
        Me.chkSearchOrderID_Search.AutoSize = True
        Me.chkSearchOrderID_Search.Location = New System.Drawing.Point(15, 31)
        Me.chkSearchOrderID_Search.Name = "chkSearchOrderID_Search"
        Me.chkSearchOrderID_Search.Size = New System.Drawing.Size(77, 17)
        Me.chkSearchOrderID_Search.TabIndex = 66
        Me.chkSearchOrderID_Search.Text = "Order ID(s)"
        Me.chkSearchOrderID_Search.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(96, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(263, 12)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'chkSearchSource
        '
        Me.chkSearchSource.AutoSize = True
        Me.chkSearchSource.Checked = True
        Me.chkSearchSource.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchSource.Enabled = False
        Me.chkSearchSource.Location = New System.Drawing.Point(185, 9)
        Me.chkSearchSource.Name = "chkSearchSource"
        Me.chkSearchSource.Size = New System.Drawing.Size(60, 17)
        Me.chkSearchSource.TabIndex = 76
        Me.chkSearchSource.Text = "Source"
        Me.chkSearchSource.UseVisualStyleBackColor = True
        '
        'obj_Source
        '
        Me.obj_Source.FormattingEnabled = True
        Me.obj_Source.Location = New System.Drawing.Point(251, 7)
        Me.obj_Source.Name = "obj_Source"
        Me.obj_Source.Size = New System.Drawing.Size(117, 21)
        Me.obj_Source.TabIndex = 75
        '
        'obj_Rekanan_id
        '
        Me.obj_Rekanan_id.Location = New System.Drawing.Point(560, 6)
        Me.obj_Rekanan_id.Name = "obj_Rekanan_id"
        Me.obj_Rekanan_id.Size = New System.Drawing.Size(108, 20)
        Me.obj_Rekanan_id.TabIndex = 77
        '
        'btn_Rekanan
        '
        Me.btn_Rekanan.Location = New System.Drawing.Point(674, 4)
        Me.btn_Rekanan.Name = "btn_Rekanan"
        Me.btn_Rekanan.Size = New System.Drawing.Size(33, 24)
        Me.btn_Rekanan.TabIndex = 78
        Me.btn_Rekanan.Text = "..."
        Me.btn_Rekanan.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(558, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(263, 12)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'chkSearchTerimaBarangID_Search
        '
        Me.chkSearchTerimaBarangID_Search.AutoSize = True
        Me.chkSearchTerimaBarangID_Search.Location = New System.Drawing.Point(434, 31)
        Me.chkSearchTerimaBarangID_Search.Name = "chkSearchTerimaBarangID_Search"
        Me.chkSearchTerimaBarangID_Search.Size = New System.Drawing.Size(120, 17)
        Me.chkSearchTerimaBarangID_Search.TabIndex = 80
        Me.chkSearchTerimaBarangID_Search.Text = "Terima Barang ID(s)"
        Me.chkSearchTerimaBarangID_Search.UseVisualStyleBackColor = True
        '
        'obj_terimabarang_id
        '
        Me.obj_terimabarang_id.Location = New System.Drawing.Point(560, 29)
        Me.obj_terimabarang_id.Multiline = True
        Me.obj_terimabarang_id.Name = "obj_terimabarang_id"
        Me.obj_terimabarang_id.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.obj_terimabarang_id.Size = New System.Drawing.Size(270, 61)
        Me.obj_terimabarang_id.TabIndex = 79
        '
        'dlgTrnPenerimaanBarang_Select_Purchase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(937, 440)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkSearchTerimaBarangID_Search)
        Me.Controls.Add(Me.obj_terimabarang_id)
        Me.Controls.Add(Me.btn_Rekanan)
        Me.Controls.Add(Me.obj_Rekanan_id)
        Me.Controls.Add(Me.chkSearchSource)
        Me.Controls.Add(Me.obj_Source)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkSearchOrderID_Search)
        Me.Controls.Add(Me.chkRekanan)
        Me.Controls.Add(Me.LinkClear1)
        Me.Controls.Add(Me.LinkCheck1)
        Me.Controls.Add(Me.DgvRentalOrder)
        Me.Controls.Add(Me.obj_order_id)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.obj_Channel_id)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSelect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgTrnPenerimaanBarang_Select_Purchase"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Transaksi Terima Jasa - List Rental Order"
        CType(Me.DgvRentalOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents obj_Channel_id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents obj_order_id As System.Windows.Forms.TextBox
    Friend WithEvents DgvRentalOrder As System.Windows.Forms.DataGridView
    Friend WithEvents LinkClear1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkCheck1 As System.Windows.Forms.LinkLabel
    Friend WithEvents chkRekanan As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchOrderID_Search As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSearchSource As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Source As System.Windows.Forms.ComboBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents obj_Rekanan_id As System.Windows.Forms.TextBox
    Friend WithEvents btn_Rekanan As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkSearchTerimaBarangID_Search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_terimabarang_id As System.Windows.Forms.TextBox
End Class
