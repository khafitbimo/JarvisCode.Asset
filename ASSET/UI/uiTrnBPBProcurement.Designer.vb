<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnBPBProcurement
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnBPBProcurement))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvBPBProcurement = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.obj_Notes = New System.Windows.Forms.TextBox
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.chk_BPB_search = New System.Windows.Forms.CheckBox
        Me.ObjBPB = New System.Windows.Forms.ComboBox
        Me.chk_orderID_search = New System.Windows.Forms.CheckBox
        Me.Objsearch = New System.Windows.Forms.ComboBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl
        Me.ftabDataDetil_Detil = New System.Windows.Forms.TabPage
        Me.DgvBPB = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.FlatTabControl1 = New FlatTabControl.FlatTabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.DgvTrnOrderdetil = New System.Windows.Forms.DataGridView
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvBPBProcurement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfFooter.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Detil.SuspendLayout()
        CType(Me.DgvBPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDataFooter.SuspendLayout()
        Me.FlatTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DgvTrnOrderdetil, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PnlDfMain.Controls.Add(Me.DgvBPBProcurement)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 75)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 327)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvBPBProcurement
        '
        Me.DgvBPBProcurement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvBPBProcurement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvBPBProcurement.Location = New System.Drawing.Point(0, 0)
        Me.DgvBPBProcurement.MultiSelect = False
        Me.DgvBPBProcurement.Name = "DgvBPBProcurement"
        Me.DgvBPBProcurement.Size = New System.Drawing.Size(704, 327)
        Me.DgvBPBProcurement.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Controls.Add(Me.Label2)
        Me.PnlDfFooter.Controls.Add(Me.obj_Notes)
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 408)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 77)
        Me.PnlDfFooter.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Notes"
        '
        'obj_Notes
        '
        Me.obj_Notes.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_Notes.Location = New System.Drawing.Point(78, 9)
        Me.obj_Notes.Multiline = True
        Me.obj_Notes.Name = "obj_Notes"
        Me.obj_Notes.ReadOnly = True
        Me.obj_Notes.Size = New System.Drawing.Size(195, 60)
        Me.obj_Notes.TabIndex = 2
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.chk_BPB_search)
        Me.PnlDfSearch.Controls.Add(Me.ObjBPB)
        Me.PnlDfSearch.Controls.Add(Me.chk_orderID_search)
        Me.PnlDfSearch.Controls.Add(Me.Objsearch)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 66)
        Me.PnlDfSearch.TabIndex = 0
        '
        'chk_BPB_search
        '
        Me.chk_BPB_search.AutoSize = True
        Me.chk_BPB_search.Location = New System.Drawing.Point(17, 39)
        Me.chk_BPB_search.Name = "chk_BPB_search"
        Me.chk_BPB_search.Size = New System.Drawing.Size(115, 17)
        Me.chk_BPB_search.TabIndex = 10
        Me.chk_BPB_search.TabStop = False
        Me.chk_BPB_search.Text = "Terima Barang No."
        '
        'ObjBPB
        '
        Me.ObjBPB.Location = New System.Drawing.Point(138, 37)
        Me.ObjBPB.Name = "ObjBPB"
        Me.ObjBPB.Size = New System.Drawing.Size(233, 21)
        Me.ObjBPB.TabIndex = 9
        '
        'chk_orderID_search
        '
        Me.chk_orderID_search.AutoSize = True
        Me.chk_orderID_search.Location = New System.Drawing.Point(17, 12)
        Me.chk_orderID_search.Name = "chk_orderID_search"
        Me.chk_orderID_search.Size = New System.Drawing.Size(72, 17)
        Me.chk_orderID_search.TabIndex = 8
        Me.chk_orderID_search.TabStop = False
        Me.chk_orderID_search.Text = "Order No."
        '
        'Objsearch
        '
        Me.Objsearch.Location = New System.Drawing.Point(138, 10)
        Me.Objsearch.Name = "Objsearch"
        Me.Objsearch.Size = New System.Drawing.Size(233, 21)
        Me.Objsearch.TabIndex = 7
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.Ivory
        Me.ftabMain_Data.Controls.Add(Me.Panel1)
        Me.ftabMain_Data.Controls.Add(Me.Panel2)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ftabDataDetil)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 256)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(733, 220)
        Me.Panel1.TabIndex = 5
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Detil)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Location = New System.Drawing.Point(0, 0)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.Ivory
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(733, 220)
        Me.ftabDataDetil.TabIndex = 32
        '
        'ftabDataDetil_Detil
        '
        Me.ftabDataDetil_Detil.BackColor = System.Drawing.Color.Ivory
        Me.ftabDataDetil_Detil.Controls.Add(Me.DgvBPB)
        Me.ftabDataDetil_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Detil.Name = "ftabDataDetil_Detil"
        Me.ftabDataDetil_Detil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Detil.Size = New System.Drawing.Size(725, 191)
        Me.ftabDataDetil_Detil.TabIndex = 0
        Me.ftabDataDetil_Detil.Text = "Transaksi Terima Jasa"
        '
        'DgvBPB
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvBPB.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvBPB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvBPB.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvBPB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvBPB.Location = New System.Drawing.Point(3, 3)
        Me.DgvBPB.MultiSelect = False
        Me.DgvBPB.Name = "DgvBPB"
        Me.DgvBPB.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvBPB.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvBPB.Size = New System.Drawing.Size(719, 185)
        Me.DgvBPB.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 240)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(733, 16)
        Me.Panel2.TabIndex = 4
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Controls.Add(Me.FlatTabControl1)
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 237)
        Me.PnlDataFooter.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "key.ico")
        '
        'FlatTabControl1
        '
        Me.FlatTabControl1.Controls.Add(Me.TabPage1)
        Me.FlatTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlatTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlatTabControl1.myBackColor = System.Drawing.Color.Ivory
        Me.FlatTabControl1.Name = "FlatTabControl1"
        Me.FlatTabControl1.SelectedIndex = 0
        Me.FlatTabControl1.Size = New System.Drawing.Size(733, 237)
        Me.FlatTabControl1.TabIndex = 33
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Ivory
        Me.TabPage1.Controls.Add(Me.DgvTrnOrderdetil)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(725, 208)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Transaksi Order"
        '
        'DgvTrnOrderdetil
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnOrderdetil.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvTrnOrderdetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTrnOrderdetil.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgvTrnOrderdetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnOrderdetil.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnOrderdetil.MultiSelect = False
        Me.DgvTrnOrderdetil.Name = "DgvTrnOrderdetil"
        Me.DgvTrnOrderdetil.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnOrderdetil.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgvTrnOrderdetil.Size = New System.Drawing.Size(719, 202)
        Me.DgvTrnOrderdetil.TabIndex = 0
        '
        'uiTrnBPBProcurement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiTrnBPBProcurement"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvBPBProcurement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfFooter.ResumeLayout(False)
        Me.PnlDfFooter.PerformLayout()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Detil.ResumeLayout(False)
        CType(Me.DgvBPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDataFooter.ResumeLayout(False)
        Me.FlatTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DgvTrnOrderdetil, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DgvBPBProcurement As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents obj_Notes As System.Windows.Forms.TextBox
    Friend WithEvents Objsearch As System.Windows.Forms.ComboBox
    Friend WithEvents chk_orderID_search As System.Windows.Forms.CheckBox
    Friend WithEvents chk_BPB_search As System.Windows.Forms.CheckBox
    Friend WithEvents ObjBPB As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Detil As System.Windows.Forms.TabPage
    Friend WithEvents DgvBPB As System.Windows.Forms.DataGridView
    Friend WithEvents FlatTabControl1 As FlatTabControl.FlatTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnOrderdetil As System.Windows.Forms.DataGridView

End Class
