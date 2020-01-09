<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiMstunit
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
        Me.DgvMstUnit = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.obj_Unit_type = New System.Windows.Forms.ComboBox
        Me.obj_Unit_id = New System.Windows.Forms.TextBox
        Me.lbl_Unit_id = New System.Windows.Forms.Label
        Me.obj_Unit_shortname = New System.Windows.Forms.TextBox
        Me.lbl_Unit_shortname = New System.Windows.Forms.Label
        Me.obj_Unit_name = New System.Windows.Forms.TextBox
        Me.lbl_Unit_name = New System.Windows.Forms.Label
        Me.lbl_Unit_type = New System.Windows.Forms.Label
        Me.obj_Unit_base = New System.Windows.Forms.TextBox
        Me.lbl_Unit_base = New System.Windows.Forms.Label
        Me.obj_Unit_active = New System.Windows.Forms.CheckBox
        Me.lbl_Unit_active = New System.Windows.Forms.Label
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvMstUnit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_Data.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(7, 32)
        Me.ftabMain.myBackColor = System.Drawing.Color.Orange
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.Linen
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
        Me.PnlDfMain.Controls.Add(Me.DgvMstUnit)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 131)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 296)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvMstUnit
        '
        Me.DgvMstUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMstUnit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMstUnit.Location = New System.Drawing.Point(0, 0)
        Me.DgvMstUnit.Name = "DgvMstUnit"
        Me.DgvMstUnit.Size = New System.Drawing.Size(704, 296)
        Me.DgvMstUnit.TabIndex = 0
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
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 111)
        Me.PnlDfSearch.TabIndex = 0
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
        Me.PnlDataMaster.Controls.Add(Me.obj_Unit_type)
        Me.PnlDataMaster.Controls.Add(Me.obj_Unit_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Unit_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Unit_shortname)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Unit_shortname)
        Me.PnlDataMaster.Controls.Add(Me.obj_Unit_name)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Unit_name)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Unit_type)
        Me.PnlDataMaster.Controls.Add(Me.obj_Unit_base)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Unit_base)
        Me.PnlDataMaster.Controls.Add(Me.obj_Unit_active)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Unit_active)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 401)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_Unit_type
        '
        Me.obj_Unit_type.FormattingEnabled = True
        Me.obj_Unit_type.Location = New System.Drawing.Point(160, 100)
        Me.obj_Unit_type.Name = "obj_Unit_type"
        Me.obj_Unit_type.Size = New System.Drawing.Size(235, 21)
        Me.obj_Unit_type.TabIndex = 3
        '
        'obj_Unit_id
        '
        Me.obj_Unit_id.Location = New System.Drawing.Point(160, 23)
        Me.obj_Unit_id.Name = "obj_Unit_id"
        Me.obj_Unit_id.ReadOnly = True
        Me.obj_Unit_id.Size = New System.Drawing.Size(44, 20)
        Me.obj_Unit_id.TabIndex = 1
        '
        'lbl_Unit_id
        '
        Me.lbl_Unit_id.AutoSize = True
        Me.lbl_Unit_id.Location = New System.Drawing.Point(23, 23)
        Me.lbl_Unit_id.Name = "lbl_Unit_id"
        Me.lbl_Unit_id.Size = New System.Drawing.Size(40, 13)
        Me.lbl_Unit_id.TabIndex = 0
        Me.lbl_Unit_id.Text = "Unit_id"
        '
        'obj_Unit_shortname
        '
        Me.obj_Unit_shortname.Location = New System.Drawing.Point(160, 49)
        Me.obj_Unit_shortname.Name = "obj_Unit_shortname"
        Me.obj_Unit_shortname.Size = New System.Drawing.Size(100, 20)
        Me.obj_Unit_shortname.TabIndex = 1
        '
        'lbl_Unit_shortname
        '
        Me.lbl_Unit_shortname.AutoSize = True
        Me.lbl_Unit_shortname.Location = New System.Drawing.Point(23, 49)
        Me.lbl_Unit_shortname.Name = "lbl_Unit_shortname"
        Me.lbl_Unit_shortname.Size = New System.Drawing.Size(81, 13)
        Me.lbl_Unit_shortname.TabIndex = 0
        Me.lbl_Unit_shortname.Text = "Unit_shortname"
        '
        'obj_Unit_name
        '
        Me.obj_Unit_name.Location = New System.Drawing.Point(160, 75)
        Me.obj_Unit_name.Name = "obj_Unit_name"
        Me.obj_Unit_name.Size = New System.Drawing.Size(100, 20)
        Me.obj_Unit_name.TabIndex = 1
        '
        'lbl_Unit_name
        '
        Me.lbl_Unit_name.AutoSize = True
        Me.lbl_Unit_name.Location = New System.Drawing.Point(23, 75)
        Me.lbl_Unit_name.Name = "lbl_Unit_name"
        Me.lbl_Unit_name.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Unit_name.TabIndex = 0
        Me.lbl_Unit_name.Text = "Unit_name"
        '
        'lbl_Unit_type
        '
        Me.lbl_Unit_type.AutoSize = True
        Me.lbl_Unit_type.Location = New System.Drawing.Point(23, 101)
        Me.lbl_Unit_type.Name = "lbl_Unit_type"
        Me.lbl_Unit_type.Size = New System.Drawing.Size(52, 13)
        Me.lbl_Unit_type.TabIndex = 0
        Me.lbl_Unit_type.Text = "Unit_type"
        '
        'obj_Unit_base
        '
        Me.obj_Unit_base.Location = New System.Drawing.Point(160, 127)
        Me.obj_Unit_base.Name = "obj_Unit_base"
        Me.obj_Unit_base.Size = New System.Drawing.Size(100, 20)
        Me.obj_Unit_base.TabIndex = 1
        '
        'lbl_Unit_base
        '
        Me.lbl_Unit_base.AutoSize = True
        Me.lbl_Unit_base.Location = New System.Drawing.Point(23, 127)
        Me.lbl_Unit_base.Name = "lbl_Unit_base"
        Me.lbl_Unit_base.Size = New System.Drawing.Size(55, 13)
        Me.lbl_Unit_base.TabIndex = 0
        Me.lbl_Unit_base.Text = "Unit_base"
        '
        'obj_Unit_active
        '
        Me.obj_Unit_active.AutoSize = True
        Me.obj_Unit_active.Location = New System.Drawing.Point(160, 153)
        Me.obj_Unit_active.Name = "obj_Unit_active"
        Me.obj_Unit_active.Size = New System.Drawing.Size(80, 17)
        Me.obj_Unit_active.TabIndex = 2
        Me.obj_Unit_active.Text = "Unit_active"
        Me.obj_Unit_active.UseVisualStyleBackColor = True
        '
        'lbl_Unit_active
        '
        Me.lbl_Unit_active.AutoSize = True
        Me.lbl_Unit_active.Location = New System.Drawing.Point(23, 153)
        Me.lbl_Unit_active.Name = "lbl_Unit_active"
        Me.lbl_Unit_active.Size = New System.Drawing.Size(61, 13)
        Me.lbl_Unit_active.TabIndex = 0
        Me.lbl_Unit_active.Text = "Unit_active"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 404)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 81)
        Me.PnlDataFooter.TabIndex = 2
        '
        'uiMstunit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.Orange
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiMstunit"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvMstUnit, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DgvMstUnit As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Unit_id As System.Windows.Forms.Label
    Friend WithEvents obj_Unit_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Unit_shortname As System.Windows.Forms.Label
    Friend WithEvents obj_Unit_shortname As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Unit_name As System.Windows.Forms.Label
    Friend WithEvents obj_Unit_name As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Unit_type As System.Windows.Forms.Label
    Friend WithEvents lbl_Unit_base As System.Windows.Forms.Label
    Friend WithEvents obj_Unit_base As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Unit_active As System.Windows.Forms.Label
    Friend WithEvents obj_Unit_active As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Unit_type As System.Windows.Forms.ComboBox

 
End Class

