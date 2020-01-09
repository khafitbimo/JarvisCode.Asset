<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiMstMerk
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
        Me.DgvMstMerk = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.objsearch = New System.Windows.Forms.TextBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.obj_Merk_id = New System.Windows.Forms.TextBox
        Me.lbl_Merk_id = New System.Windows.Forms.Label
        Me.obj_Merk_name = New System.Windows.Forms.TextBox
        Me.lbl_Merk_name = New System.Windows.Forms.Label
        Me.obj_Merk_active = New System.Windows.Forms.CheckBox
        Me.lbl_Merk_active = New System.Windows.Forms.Label
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvMstMerk, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ftabMain.myBackColor = System.Drawing.Color.OliveDrab
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.MediumSeaGreen
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
        Me.PnlDfMain.Controls.Add(Me.DgvMstMerk)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 131)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 296)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvMstMerk
        '
        Me.DgvMstMerk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMstMerk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMstMerk.Location = New System.Drawing.Point(0, 0)
        Me.DgvMstMerk.Name = "DgvMstMerk"
        Me.DgvMstMerk.Size = New System.Drawing.Size(704, 296)
        Me.DgvMstMerk.TabIndex = 0
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
        Me.PnlDfSearch.Controls.Add(Me.CheckBox2)
        Me.PnlDfSearch.Controls.Add(Me.objsearch)
        Me.PnlDfSearch.Controls.Add(Me.CheckBox1)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 111)
        Me.PnlDfSearch.TabIndex = 0
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(17, 63)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox2.TabIndex = 2
        Me.CheckBox2.Text = "Active"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'objsearch
        '
        Me.objsearch.Location = New System.Drawing.Point(104, 29)
        Me.objsearch.Name = "objsearch"
        Me.objsearch.Size = New System.Drawing.Size(272, 20)
        Me.objsearch.TabIndex = 1
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(17, 31)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(54, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Brand"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.DarkSeaGreen
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
        Me.PnlDataMaster.Controls.Add(Me.obj_Merk_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Merk_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Merk_name)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Merk_name)
        Me.PnlDataMaster.Controls.Add(Me.obj_Merk_active)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Merk_active)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 401)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_Merk_id
        '
        Me.obj_Merk_id.Location = New System.Drawing.Point(198, 29)
        Me.obj_Merk_id.Name = "obj_Merk_id"
        Me.obj_Merk_id.ReadOnly = True
        Me.obj_Merk_id.Size = New System.Drawing.Size(100, 20)
        Me.obj_Merk_id.TabIndex = 2
        '
        'lbl_Merk_id
        '
        Me.lbl_Merk_id.AutoSize = True
        Me.lbl_Merk_id.Location = New System.Drawing.Point(61, 29)
        Me.lbl_Merk_id.Name = "lbl_Merk_id"
        Me.lbl_Merk_id.Size = New System.Drawing.Size(45, 13)
        Me.lbl_Merk_id.TabIndex = 0
        Me.lbl_Merk_id.Text = "Merk_id"
        '
        'obj_Merk_name
        '
        Me.obj_Merk_name.Location = New System.Drawing.Point(198, 55)
        Me.obj_Merk_name.Name = "obj_Merk_name"
        Me.obj_Merk_name.Size = New System.Drawing.Size(325, 20)
        Me.obj_Merk_name.TabIndex = 0
        '
        'lbl_Merk_name
        '
        Me.lbl_Merk_name.AutoSize = True
        Me.lbl_Merk_name.Location = New System.Drawing.Point(61, 55)
        Me.lbl_Merk_name.Name = "lbl_Merk_name"
        Me.lbl_Merk_name.Size = New System.Drawing.Size(63, 13)
        Me.lbl_Merk_name.TabIndex = 0
        Me.lbl_Merk_name.Text = "Merk_name"
        '
        'obj_Merk_active
        '
        Me.obj_Merk_active.AutoSize = True
        Me.obj_Merk_active.Location = New System.Drawing.Point(198, 81)
        Me.obj_Merk_active.Name = "obj_Merk_active"
        Me.obj_Merk_active.Size = New System.Drawing.Size(15, 14)
        Me.obj_Merk_active.TabIndex = 1
        Me.obj_Merk_active.UseVisualStyleBackColor = True
        '
        'lbl_Merk_active
        '
        Me.lbl_Merk_active.AutoSize = True
        Me.lbl_Merk_active.Location = New System.Drawing.Point(61, 81)
        Me.lbl_Merk_active.Name = "lbl_Merk_active"
        Me.lbl_Merk_active.Size = New System.Drawing.Size(66, 13)
        Me.lbl_Merk_active.TabIndex = 0
        Me.lbl_Merk_active.Text = "Merk_active"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 404)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 81)
        Me.PnlDataFooter.TabIndex = 2
        '
        'uiMstMerk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiMstMerk"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvMstMerk, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DgvMstMerk As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Merk_id As System.Windows.Forms.Label
    Friend WithEvents obj_Merk_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Merk_name As System.Windows.Forms.Label
    Friend WithEvents obj_Merk_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Merk_active As System.Windows.Forms.Label
    Friend WithEvents obj_Merk_active As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents objsearch As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class

