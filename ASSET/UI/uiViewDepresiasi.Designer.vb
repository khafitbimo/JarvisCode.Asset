<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiViewDepresiasi
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvDepresiasi = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.chkSearchTahun = New System.Windows.Forms.CheckBox
        Me.chkSearchBulan = New System.Windows.Forms.CheckBox
        Me.cboSearchtahun = New System.Windows.Forms.NumericUpDown
        Me.cboSearchbulan = New System.Windows.Forms.NumericUpDown
        Me.chk_BPB_search = New System.Windows.Forms.CheckBox
        Me.ObjSearch_Category = New System.Windows.Forms.ComboBox
        Me.chk_orderID_search = New System.Windows.Forms.CheckBox
        Me.ObjsearchDepartment = New System.Windows.Forms.ComboBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.DgvDepresiasiDetil = New System.Windows.Forms.DataGridView
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Btn_clearText = New System.Windows.Forms.Button
        Me.obj_barcode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvDepresiasi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        CType(Me.cboSearchtahun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSearchbulan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_Data.SuspendLayout()
        Me.PnlDataFooter.SuspendLayout()
        CType(Me.DgvDepresiasiDetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(3, 28)
        Me.ftabMain.myBackColor = System.Drawing.Color.DarkSeaGreen
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.Ivory
        Me.ftabMain_List.Controls.Add(Me.PnlDfMain)
        Me.ftabMain_List.Controls.Add(Me.PnlDfFooter)
        Me.ftabMain_List.Controls.Add(Me.PnlDfSearch)
        Me.ftabMain_List.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_List.Name = "ftabMain_List"
        Me.ftabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_List.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "List"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvDepresiasi)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 75)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 327)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvDepresiasi
        '
        Me.DgvDepresiasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDepresiasi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvDepresiasi.Location = New System.Drawing.Point(0, 0)
        Me.DgvDepresiasi.MultiSelect = False
        Me.DgvDepresiasi.Name = "DgvDepresiasi"
        Me.DgvDepresiasi.Size = New System.Drawing.Size(704, 327)
        Me.DgvDepresiasi.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 466)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 19)
        Me.PnlDfFooter.TabIndex = 2
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.chkSearchTahun)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchBulan)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchtahun)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchbulan)
        Me.PnlDfSearch.Controls.Add(Me.chk_BPB_search)
        Me.PnlDfSearch.Controls.Add(Me.ObjSearch_Category)
        Me.PnlDfSearch.Controls.Add(Me.chk_orderID_search)
        Me.PnlDfSearch.Controls.Add(Me.ObjsearchDepartment)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 66)
        Me.PnlDfSearch.TabIndex = 0
        '
        'chkSearchTahun
        '
        Me.chkSearchTahun.AutoSize = True
        Me.chkSearchTahun.Checked = True
        Me.chkSearchTahun.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchTahun.Enabled = False
        Me.chkSearchTahun.Location = New System.Drawing.Point(444, 38)
        Me.chkSearchTahun.Name = "chkSearchTahun"
        Me.chkSearchTahun.Size = New System.Drawing.Size(48, 17)
        Me.chkSearchTahun.TabIndex = 21
        Me.chkSearchTahun.Text = "Year"
        Me.chkSearchTahun.UseVisualStyleBackColor = True
        '
        'chkSearchBulan
        '
        Me.chkSearchBulan.AutoSize = True
        Me.chkSearchBulan.Checked = True
        Me.chkSearchBulan.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchBulan.Enabled = False
        Me.chkSearchBulan.Location = New System.Drawing.Point(444, 14)
        Me.chkSearchBulan.Name = "chkSearchBulan"
        Me.chkSearchBulan.Size = New System.Drawing.Size(56, 17)
        Me.chkSearchBulan.TabIndex = 20
        Me.chkSearchBulan.Text = "Month"
        Me.chkSearchBulan.UseVisualStyleBackColor = True
        '
        'cboSearchtahun
        '
        Me.cboSearchtahun.Location = New System.Drawing.Point(520, 36)
        Me.cboSearchtahun.Maximum = New Decimal(New Integer() {2200, 0, 0, 0})
        Me.cboSearchtahun.Minimum = New Decimal(New Integer() {1998, 0, 0, 0})
        Me.cboSearchtahun.Name = "cboSearchtahun"
        Me.cboSearchtahun.Size = New System.Drawing.Size(54, 20)
        Me.cboSearchtahun.TabIndex = 19
        Me.cboSearchtahun.Value = New Decimal(New Integer() {2008, 0, 0, 0})
        '
        'cboSearchbulan
        '
        Me.cboSearchbulan.Location = New System.Drawing.Point(520, 11)
        Me.cboSearchbulan.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.cboSearchbulan.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.cboSearchbulan.Name = "cboSearchbulan"
        Me.cboSearchbulan.Size = New System.Drawing.Size(54, 20)
        Me.cboSearchbulan.TabIndex = 18
        Me.cboSearchbulan.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chk_BPB_search
        '
        Me.chk_BPB_search.AutoSize = True
        Me.chk_BPB_search.Checked = True
        Me.chk_BPB_search.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_BPB_search.Enabled = False
        Me.chk_BPB_search.Location = New System.Drawing.Point(17, 39)
        Me.chk_BPB_search.Name = "chk_BPB_search"
        Me.chk_BPB_search.Size = New System.Drawing.Size(68, 17)
        Me.chk_BPB_search.TabIndex = 10
        Me.chk_BPB_search.TabStop = False
        Me.chk_BPB_search.Text = "Category"
        '
        'ObjSearch_Category
        '
        Me.ObjSearch_Category.Location = New System.Drawing.Point(138, 37)
        Me.ObjSearch_Category.Name = "ObjSearch_Category"
        Me.ObjSearch_Category.Size = New System.Drawing.Size(233, 21)
        Me.ObjSearch_Category.TabIndex = 9
        '
        'chk_orderID_search
        '
        Me.chk_orderID_search.AutoSize = True
        Me.chk_orderID_search.Checked = True
        Me.chk_orderID_search.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_orderID_search.Enabled = False
        Me.chk_orderID_search.Location = New System.Drawing.Point(17, 12)
        Me.chk_orderID_search.Name = "chk_orderID_search"
        Me.chk_orderID_search.Size = New System.Drawing.Size(84, 17)
        Me.chk_orderID_search.TabIndex = 8
        Me.chk_orderID_search.TabStop = False
        Me.chk_orderID_search.Text = "Department."
        '
        'ObjsearchDepartment
        '
        Me.ObjsearchDepartment.Location = New System.Drawing.Point(138, 10)
        Me.ObjsearchDepartment.Name = "ObjsearchDepartment"
        Me.ObjsearchDepartment.Size = New System.Drawing.Size(233, 21)
        Me.ObjsearchDepartment.TabIndex = 7
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.Ivory
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Controls.Add(Me.DgvDepresiasiDetil)
        Me.PnlDataFooter.Controls.Add(Me.Panel3)
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 482)
        Me.PnlDataFooter.TabIndex = 2
        '
        'DgvDepresiasiDetil
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDepresiasiDetil.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvDepresiasiDetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvDepresiasiDetil.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgvDepresiasiDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvDepresiasiDetil.Location = New System.Drawing.Point(0, 33)
        Me.DgvDepresiasiDetil.MultiSelect = False
        Me.DgvDepresiasiDetil.Name = "DgvDepresiasiDetil"
        Me.DgvDepresiasiDetil.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDepresiasiDetil.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvDepresiasiDetil.Size = New System.Drawing.Size(733, 449)
        Me.DgvDepresiasiDetil.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Btn_clearText)
        Me.Panel3.Controls.Add(Me.obj_barcode)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(733, 33)
        Me.Panel3.TabIndex = 73
        '
        'Btn_clearText
        '
        Me.Btn_clearText.BackColor = System.Drawing.Color.Gainsboro
        Me.Btn_clearText.Location = New System.Drawing.Point(228, 6)
        Me.Btn_clearText.Name = "Btn_clearText"
        Me.Btn_clearText.Size = New System.Drawing.Size(47, 21)
        Me.Btn_clearText.TabIndex = 7
        Me.Btn_clearText.Text = "Clear"
        Me.Btn_clearText.UseVisualStyleBackColor = False
        '
        'obj_barcode
        '
        Me.obj_barcode.BackColor = System.Drawing.Color.White
        Me.obj_barcode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.obj_barcode.Location = New System.Drawing.Point(72, 7)
        Me.obj_barcode.Name = "obj_barcode"
        Me.obj_barcode.Size = New System.Drawing.Size(150, 20)
        Me.obj_barcode.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Barcode"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'uiViewDepresiasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiViewDepresiasi"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvDepresiasi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        CType(Me.cboSearchtahun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSearchbulan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.PnlDataFooter.ResumeLayout(False)
        CType(Me.DgvDepresiasiDetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDataFooter As System.Windows.Forms.Panel
    Friend WithEvents DgvDepresiasi As System.Windows.Forms.DataGridView
    Friend WithEvents ObjsearchDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents chk_orderID_search As System.Windows.Forms.CheckBox
    Friend WithEvents chk_BPB_search As System.Windows.Forms.CheckBox
    Friend WithEvents ObjSearch_Category As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DgvDepresiasiDetil As System.Windows.Forms.DataGridView
    Friend WithEvents chkSearchTahun As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchBulan As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchtahun As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboSearchbulan As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Btn_clearText As System.Windows.Forms.Button
    Friend WithEvents obj_barcode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
