<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UiMstRuang
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
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvMstRuang = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.cboSearchChannel = New System.Windows.Forms.ComboBox
        Me.chkSearchChannel = New System.Windows.Forms.CheckBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.obj_Channel_id = New System.Windows.Forms.ComboBox
        Me.obj_Ruang_id = New System.Windows.Forms.TextBox
        Me.lbl_Ruang_id = New System.Windows.Forms.Label
        Me.obj_Gedung_name = New System.Windows.Forms.TextBox
        Me.lbl_Gedung_name = New System.Windows.Forms.Label
        Me.obj_Ruang_name = New System.Windows.Forms.TextBox
        Me.lbl_Ruang_name = New System.Windows.Forms.Label
        Me.obj_Ruang_lantai = New System.Windows.Forms.TextBox
        Me.lbl_Ruang_lantai = New System.Windows.Forms.Label
        Me.lbl_Channel_id = New System.Windows.Forms.Label
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.obj_wilayah_name = New System.Windows.Forms.TextBox
        Me.lbl_wilayah_name = New System.Windows.Forms.Label
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvMstRuang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(3, 28)
        Me.ftabMain.myBackColor = System.Drawing.Color.PeachPuff
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.PeachPuff
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
        Me.PnlDfMain.Controls.Add(Me.DgvMstRuang)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 131)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 296)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvMstRuang
        '
        Me.DgvMstRuang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMstRuang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMstRuang.Location = New System.Drawing.Point(0, 0)
        Me.DgvMstRuang.Name = "DgvMstRuang"
        Me.DgvMstRuang.Size = New System.Drawing.Size(704, 296)
        Me.DgvMstRuang.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 446)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 39)
        Me.PnlDfFooter.TabIndex = 2
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.cboSearchChannel)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchChannel)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 111)
        Me.PnlDfSearch.TabIndex = 0
        '
        'cboSearchChannel
        '
        Me.cboSearchChannel.FormattingEnabled = True
        Me.cboSearchChannel.Location = New System.Drawing.Point(104, 13)
        Me.cboSearchChannel.Name = "cboSearchChannel"
        Me.cboSearchChannel.Size = New System.Drawing.Size(121, 21)
        Me.cboSearchChannel.TabIndex = 1
        '
        'chkSearchChannel
        '
        Me.chkSearchChannel.AutoSize = True
        Me.chkSearchChannel.Location = New System.Drawing.Point(17, 15)
        Me.chkSearchChannel.Name = "chkSearchChannel"
        Me.chkSearchChannel.Size = New System.Drawing.Size(65, 17)
        Me.chkSearchChannel.TabIndex = 0
        Me.chkSearchChannel.Text = "Channel"
        Me.chkSearchChannel.UseVisualStyleBackColor = True
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.Controls.Add(Me.obj_wilayah_name)
        Me.PnlDataMaster.Controls.Add(Me.lbl_wilayah_name)
        Me.PnlDataMaster.Controls.Add(Me.obj_Channel_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Ruang_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Ruang_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Gedung_name)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Gedung_name)
        Me.PnlDataMaster.Controls.Add(Me.obj_Ruang_name)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Ruang_name)
        Me.PnlDataMaster.Controls.Add(Me.obj_Ruang_lantai)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Ruang_lantai)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Channel_id)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 401)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.FormattingEnabled = True
        Me.obj_Channel_id.Location = New System.Drawing.Point(160, 153)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.Size = New System.Drawing.Size(79, 21)
        Me.obj_Channel_id.TabIndex = 2
        '
        'obj_Ruang_id
        '
        Me.obj_Ruang_id.Location = New System.Drawing.Point(160, 23)
        Me.obj_Ruang_id.Name = "obj_Ruang_id"
        Me.obj_Ruang_id.Size = New System.Drawing.Size(73, 20)
        Me.obj_Ruang_id.TabIndex = 1
        '
        'lbl_Ruang_id
        '
        Me.lbl_Ruang_id.AutoSize = True
        Me.lbl_Ruang_id.Location = New System.Drawing.Point(23, 23)
        Me.lbl_Ruang_id.Name = "lbl_Ruang_id"
        Me.lbl_Ruang_id.Size = New System.Drawing.Size(75, 13)
        Me.lbl_Ruang_id.TabIndex = 0
        Me.lbl_Ruang_id.Text = "Room Number"
        '
        'obj_Gedung_name
        '
        Me.obj_Gedung_name.Location = New System.Drawing.Point(160, 75)
        Me.obj_Gedung_name.Name = "obj_Gedung_name"
        Me.obj_Gedung_name.Size = New System.Drawing.Size(276, 20)
        Me.obj_Gedung_name.TabIndex = 1
        '
        'lbl_Gedung_name
        '
        Me.lbl_Gedung_name.AutoSize = True
        Me.lbl_Gedung_name.Location = New System.Drawing.Point(25, 78)
        Me.lbl_Gedung_name.Name = "lbl_Gedung_name"
        Me.lbl_Gedung_name.Size = New System.Drawing.Size(44, 13)
        Me.lbl_Gedung_name.TabIndex = 0
        Me.lbl_Gedung_name.Text = "Building"
        '
        'obj_Ruang_name
        '
        Me.obj_Ruang_name.Location = New System.Drawing.Point(160, 101)
        Me.obj_Ruang_name.Name = "obj_Ruang_name"
        Me.obj_Ruang_name.Size = New System.Drawing.Size(276, 20)
        Me.obj_Ruang_name.TabIndex = 1
        '
        'lbl_Ruang_name
        '
        Me.lbl_Ruang_name.AutoSize = True
        Me.lbl_Ruang_name.Location = New System.Drawing.Point(23, 104)
        Me.lbl_Ruang_name.Name = "lbl_Ruang_name"
        Me.lbl_Ruang_name.Size = New System.Drawing.Size(66, 13)
        Me.lbl_Ruang_name.TabIndex = 0
        Me.lbl_Ruang_name.Text = "Room Name"
        '
        'obj_Ruang_lantai
        '
        Me.obj_Ruang_lantai.Location = New System.Drawing.Point(160, 127)
        Me.obj_Ruang_lantai.Name = "obj_Ruang_lantai"
        Me.obj_Ruang_lantai.Size = New System.Drawing.Size(41, 20)
        Me.obj_Ruang_lantai.TabIndex = 1
        '
        'lbl_Ruang_lantai
        '
        Me.lbl_Ruang_lantai.AutoSize = True
        Me.lbl_Ruang_lantai.Location = New System.Drawing.Point(23, 130)
        Me.lbl_Ruang_lantai.Name = "lbl_Ruang_lantai"
        Me.lbl_Ruang_lantai.Size = New System.Drawing.Size(30, 13)
        Me.lbl_Ruang_lantai.TabIndex = 0
        Me.lbl_Ruang_lantai.Text = "Floor"
        '
        'lbl_Channel_id
        '
        Me.lbl_Channel_id.AutoSize = True
        Me.lbl_Channel_id.Location = New System.Drawing.Point(23, 156)
        Me.lbl_Channel_id.Name = "lbl_Channel_id"
        Me.lbl_Channel_id.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Channel_id.TabIndex = 0
        Me.lbl_Channel_id.Text = "Channel"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 404)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 81)
        Me.PnlDataFooter.TabIndex = 2
        '
        'obj_wilayah_name
        '
        Me.obj_wilayah_name.Location = New System.Drawing.Point(160, 49)
        Me.obj_wilayah_name.Name = "obj_wilayah_name"
        Me.obj_wilayah_name.Size = New System.Drawing.Size(73, 20)
        Me.obj_wilayah_name.TabIndex = 4
        '
        'lbl_wilayah_name
        '
        Me.lbl_wilayah_name.AutoSize = True
        Me.lbl_wilayah_name.Location = New System.Drawing.Point(23, 52)
        Me.lbl_wilayah_name.Name = "lbl_wilayah_name"
        Me.lbl_wilayah_name.Size = New System.Drawing.Size(48, 13)
        Me.lbl_wilayah_name.TabIndex = 3
        Me.lbl_wilayah_name.Text = "Location"
        '
        'UiMstRuang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.DarkOrange
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "UiMstRuang"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvMstRuang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDataMaster As System.Windows.Forms.Panel
    Friend WithEvents PnlDataFooter As System.Windows.Forms.Panel
    Friend WithEvents DgvMstRuang As System.Windows.Forms.DataGridView
    Friend WithEvents chkSearchChannel As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Ruang_id As System.Windows.Forms.Label
    Friend WithEvents obj_Ruang_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Gedung_name As System.Windows.Forms.Label
    Friend WithEvents obj_Gedung_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Ruang_name As System.Windows.Forms.Label
    Friend WithEvents obj_Ruang_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Ruang_lantai As System.Windows.Forms.Label
    Friend WithEvents obj_Ruang_lantai As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Channel_id As System.Windows.Forms.Label
    Friend WithEvents obj_Channel_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_wilayah_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_wilayah_name As System.Windows.Forms.Label

End Class

