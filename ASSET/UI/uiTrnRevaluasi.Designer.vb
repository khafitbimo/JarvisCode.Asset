<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnRevaluasi
    Inherits ASSET.uiBase

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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.obj_Asset_idrprice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.obj_Asset_Kurs = New System.Windows.Forms.TextBox
        Me.lbl_Asset_valas = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.obj_Devaluasi_remark = New System.Windows.Forms.TextBox
        Me.lbl_Devaluasi_Remark = New System.Windows.Forms.Label
        Me.obj_Asset_devaluasiValue = New System.Windows.Forms.TextBox
        Me.lbl_Asset_idrprice = New System.Windows.Forms.Label
        Me.obj_Devaluasi_tgl = New System.Windows.Forms.MaskedTextBox
        Me.lbl_Terimabarang_tgl = New System.Windows.Forms.Label
        Me.cmdBarcode = New System.Windows.Forms.Button
        Me.obj_Asset_barcode = New System.Windows.Forms.TextBox
        Me.lbl_Asset_barcode = New System.Windows.Forms.Label
        Me.obj_Channel_id = New System.Windows.Forms.ComboBox
        Me.lbl_Channel_id = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.obj_Asset_idrprice)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.obj_Asset_Kurs)
        Me.Panel1.Controls.Add(Me.lbl_Asset_valas)
        Me.Panel1.Controls.Add(Me.cmdOK)
        Me.Panel1.Controls.Add(Me.obj_Devaluasi_remark)
        Me.Panel1.Controls.Add(Me.lbl_Devaluasi_Remark)
        Me.Panel1.Controls.Add(Me.obj_Asset_devaluasiValue)
        Me.Panel1.Controls.Add(Me.lbl_Asset_idrprice)
        Me.Panel1.Controls.Add(Me.obj_Devaluasi_tgl)
        Me.Panel1.Controls.Add(Me.lbl_Terimabarang_tgl)
        Me.Panel1.Controls.Add(Me.cmdBarcode)
        Me.Panel1.Controls.Add(Me.obj_Asset_barcode)
        Me.Panel1.Controls.Add(Me.lbl_Asset_barcode)
        Me.Panel1.Controls.Add(Me.obj_Channel_id)
        Me.Panel1.Controls.Add(Me.lbl_Channel_id)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(753, 523)
        Me.Panel1.TabIndex = 4
        '
        'obj_Asset_idrprice
        '
        Me.obj_Asset_idrprice.Location = New System.Drawing.Point(146, 177)
        Me.obj_Asset_idrprice.MaxLength = 0
        Me.obj_Asset_idrprice.Name = "obj_Asset_idrprice"
        Me.obj_Asset_idrprice.ReadOnly = True
        Me.obj_Asset_idrprice.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_idrprice.TabIndex = 233
        Me.obj_Asset_idrprice.TabStop = False
        Me.obj_Asset_idrprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 180)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 232
        Me.Label1.Text = "IDR Value"
        '
        'obj_Asset_Kurs
        '
        Me.obj_Asset_Kurs.Location = New System.Drawing.Point(146, 151)
        Me.obj_Asset_Kurs.MaxLength = 20
        Me.obj_Asset_Kurs.Name = "obj_Asset_Kurs"
        Me.obj_Asset_Kurs.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_Kurs.TabIndex = 5
        Me.obj_Asset_Kurs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Asset_valas
        '
        Me.lbl_Asset_valas.AutoSize = True
        Me.lbl_Asset_valas.Location = New System.Drawing.Point(62, 155)
        Me.lbl_Asset_valas.Name = "lbl_Asset_valas"
        Me.lbl_Asset_valas.Size = New System.Drawing.Size(28, 13)
        Me.lbl_Asset_valas.TabIndex = 231
        Me.lbl_Asset_valas.Text = "Kurs"
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.cmdOK.Location = New System.Drawing.Point(310, 275)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(64, 22)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'obj_Devaluasi_remark
        '
        Me.obj_Devaluasi_remark.Location = New System.Drawing.Point(146, 203)
        Me.obj_Devaluasi_remark.MaxLength = 50
        Me.obj_Devaluasi_remark.Multiline = True
        Me.obj_Devaluasi_remark.Name = "obj_Devaluasi_remark"
        Me.obj_Devaluasi_remark.Size = New System.Drawing.Size(228, 58)
        Me.obj_Devaluasi_remark.TabIndex = 6
        '
        'lbl_Devaluasi_Remark
        '
        Me.lbl_Devaluasi_Remark.AutoSize = True
        Me.lbl_Devaluasi_Remark.Location = New System.Drawing.Point(62, 230)
        Me.lbl_Devaluasi_Remark.Name = "lbl_Devaluasi_Remark"
        Me.lbl_Devaluasi_Remark.Size = New System.Drawing.Size(44, 13)
        Me.lbl_Devaluasi_Remark.TabIndex = 229
        Me.lbl_Devaluasi_Remark.Text = "Remark"
        '
        'obj_Asset_devaluasiValue
        '
        Me.obj_Asset_devaluasiValue.Location = New System.Drawing.Point(146, 125)
        Me.obj_Asset_devaluasiValue.MaxLength = 0
        Me.obj_Asset_devaluasiValue.Name = "obj_Asset_devaluasiValue"
        Me.obj_Asset_devaluasiValue.Size = New System.Drawing.Size(111, 20)
        Me.obj_Asset_devaluasiValue.TabIndex = 4
        Me.obj_Asset_devaluasiValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Asset_idrprice
        '
        Me.lbl_Asset_idrprice.AutoSize = True
        Me.lbl_Asset_idrprice.Location = New System.Drawing.Point(62, 128)
        Me.lbl_Asset_idrprice.Name = "lbl_Asset_idrprice"
        Me.lbl_Asset_idrprice.Size = New System.Drawing.Size(34, 13)
        Me.lbl_Asset_idrprice.TabIndex = 226
        Me.lbl_Asset_idrprice.Text = "Value"
        '
        'obj_Devaluasi_tgl
        '
        Me.obj_Devaluasi_tgl.Location = New System.Drawing.Point(146, 99)
        Me.obj_Devaluasi_tgl.Mask = "00/00/0000"
        Me.obj_Devaluasi_tgl.Name = "obj_Devaluasi_tgl"
        Me.obj_Devaluasi_tgl.Size = New System.Drawing.Size(111, 20)
        Me.obj_Devaluasi_tgl.TabIndex = 3
        '
        'lbl_Terimabarang_tgl
        '
        Me.lbl_Terimabarang_tgl.AutoSize = True
        Me.lbl_Terimabarang_tgl.Location = New System.Drawing.Point(62, 102)
        Me.lbl_Terimabarang_tgl.Name = "lbl_Terimabarang_tgl"
        Me.lbl_Terimabarang_tgl.Size = New System.Drawing.Size(80, 13)
        Me.lbl_Terimabarang_tgl.TabIndex = 224
        Me.lbl_Terimabarang_tgl.Text = "Devaluasi Date"
        '
        'cmdBarcode
        '
        Me.cmdBarcode.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.cmdBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBarcode.Location = New System.Drawing.Point(346, 73)
        Me.cmdBarcode.Name = "cmdBarcode"
        Me.cmdBarcode.Size = New System.Drawing.Size(28, 20)
        Me.cmdBarcode.TabIndex = 2
        Me.cmdBarcode.Text = "..."
        Me.cmdBarcode.UseVisualStyleBackColor = False
        '
        'obj_Asset_barcode
        '
        Me.obj_Asset_barcode.Location = New System.Drawing.Point(146, 73)
        Me.obj_Asset_barcode.MaxLength = 20
        Me.obj_Asset_barcode.Name = "obj_Asset_barcode"
        Me.obj_Asset_barcode.ReadOnly = True
        Me.obj_Asset_barcode.Size = New System.Drawing.Size(194, 20)
        Me.obj_Asset_barcode.TabIndex = 1
        '
        'lbl_Asset_barcode
        '
        Me.lbl_Asset_barcode.AutoSize = True
        Me.lbl_Asset_barcode.Location = New System.Drawing.Point(62, 73)
        Me.lbl_Asset_barcode.Name = "lbl_Asset_barcode"
        Me.lbl_Asset_barcode.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Asset_barcode.TabIndex = 222
        Me.lbl_Asset_barcode.Text = "Barcode"
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.BackColor = System.Drawing.Color.Linen
        Me.obj_Channel_id.Enabled = False
        Me.obj_Channel_id.FormattingEnabled = True
        Me.obj_Channel_id.Location = New System.Drawing.Point(146, 46)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.Size = New System.Drawing.Size(228, 21)
        Me.obj_Channel_id.TabIndex = 0
        Me.obj_Channel_id.TabStop = False
        '
        'lbl_Channel_id
        '
        Me.lbl_Channel_id.AutoSize = True
        Me.lbl_Channel_id.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Channel_id.Location = New System.Drawing.Point(62, 50)
        Me.lbl_Channel_id.Name = "lbl_Channel_id"
        Me.lbl_Channel_id.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Channel_id.TabIndex = 219
        Me.lbl_Channel_id.Text = "Channel"
        '
        'uiTrnRevaluasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "uiTrnRevaluasi"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents obj_Devaluasi_remark As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Devaluasi_Remark As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_devaluasiValue As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_idrprice As System.Windows.Forms.Label
    Friend WithEvents obj_Devaluasi_tgl As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lbl_Terimabarang_tgl As System.Windows.Forms.Label
    Friend WithEvents cmdBarcode As System.Windows.Forms.Button
    Friend WithEvents obj_Asset_barcode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_barcode As System.Windows.Forms.Label
    Friend WithEvents obj_Channel_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Channel_id As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_Kurs As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Asset_valas As System.Windows.Forms.Label
    Friend WithEvents obj_Asset_idrprice As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
