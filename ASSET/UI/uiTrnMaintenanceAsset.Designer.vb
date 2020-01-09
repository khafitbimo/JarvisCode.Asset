<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnMaintenanceAsset
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnMaintenanceAsset))
        Me.ftabMain = New FlatTabControl.FlatTabControl
        Me.ftabMain_List = New System.Windows.Forms.TabPage
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvTrnMaintenance = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.obj_maintenance_outLock = New System.Windows.Forms.CheckBox
        Me.lbl_maintenance_outLock = New System.Windows.Forms.Label
        Me.obj_maintenance_incLock = New System.Windows.Forms.CheckBox
        Me.lbl_maintenance_incLock = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.ObjSearchmaintenance_id = New System.Windows.Forms.TextBox
        Me.chkSearchMaintenance_id = New System.Windows.Forms.CheckBox
        Me.cmb_Maintenance_Incoming = New System.Windows.Forms.ComboBox
        Me.cmb_Maintenance_Outgoing = New System.Windows.Forms.ComboBox
        Me.chk_Maintenance_OutGoing = New System.Windows.Forms.CheckBox
        Me.chk_Maintenance_Incoming = New System.Windows.Forms.CheckBox
        Me.obj_Strukturunit_id_pemilik_search = New System.Windows.Forms.ComboBox
        Me.chk_Strukturunit_id_pemilik_search = New System.Windows.Forms.CheckBox
        Me.obj_Channel_id_search = New System.Windows.Forms.ComboBox
        Me.chk_Channel_id_search = New System.Windows.Forms.CheckBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.ftabDataDetil = New FlatTabControl.FlatTabControl
        Me.ftabDataDetil_Detil = New System.Windows.Forms.TabPage
        Me.DgvTrnMaintenancedetil = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpdateIncStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UpdateOutStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.obj_Maintenace_itemqty = New System.Windows.Forms.TextBox
        Me.lbl_Maintenace_itemqty = New System.Windows.Forms.Label
        Me.obj_Maintenace_itemqtyret = New System.Windows.Forms.TextBox
        Me.lbl_Maintenace_itemqtyret = New System.Windows.Forms.Label
        Me.ftabDataDetil_UserInfo = New System.Windows.Forms.TabPage
        Me.obj_Channel_id = New System.Windows.Forms.ComboBox
        Me.lbl_Channel_id = New System.Windows.Forms.Label
        Me.obj_Maintenance_usedby = New System.Windows.Forms.TextBox
        Me.lbl_Maintenance_usedby = New System.Windows.Forms.Label
        Me.obj_Maintenance_useddt = New System.Windows.Forms.TextBox
        Me.lbl_Maintenance_useddt = New System.Windows.Forms.Label
        Me.obj_Maintenance_editby = New System.Windows.Forms.TextBox
        Me.lbl_Maintenance_editby = New System.Windows.Forms.Label
        Me.obj_Maintenance_editdt = New System.Windows.Forms.TextBox
        Me.lbl_Maintenance_editdt = New System.Windows.Forms.Label
        Me.obj_Maintenance_inputby = New System.Windows.Forms.TextBox
        Me.lbl_Maintenance_inputby = New System.Windows.Forms.Label
        Me.obj_Maintenance_inputdt = New System.Windows.Forms.TextBox
        Me.lbl_Maintenance_inputdt = New System.Windows.Forms.Label
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.obj_Currency_id = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.obj_Maintenance_outdt = New System.Windows.Forms.MaskedTextBox
        Me.obj_Maintenance_indt = New System.Windows.Forms.MaskedTextBox
        Me.obj_Strukturunit_id = New System.Windows.Forms.ComboBox
        Me.obj_Employee_id = New System.Windows.Forms.ComboBox
        Me.obj_Rekanan_id = New System.Windows.Forms.ComboBox
        Me.obj_Order_id = New System.Windows.Forms.ComboBox
        Me.obj_Maintenance_type = New System.Windows.Forms.ComboBox
        Me.lbl_Maintenance_type = New System.Windows.Forms.Label
        Me.obj_Maintenance_outin = New System.Windows.Forms.CheckBox
        Me.lbl_Maintenance_outin = New System.Windows.Forms.Label
        Me.lbl_Order_id = New System.Windows.Forms.Label
        Me.lbl_Rekanan_id = New System.Windows.Forms.Label
        Me.lbl_Employee_id = New System.Windows.Forms.Label
        Me.lbl_Strukturunit_id = New System.Windows.Forms.Label
        Me.lbl_Maintenance_indt = New System.Windows.Forms.Label
        Me.lbl_Maintenance_outdt = New System.Windows.Forms.Label
        Me.obj_Maintenance_status = New System.Windows.Forms.TextBox
        Me.lbl_Maintenance_status = New System.Windows.Forms.Label
        Me.obj_Maintenance_harga = New System.Windows.Forms.TextBox
        Me.lbl_Maintenance_harga = New System.Windows.Forms.Label
        Me.obj_Maintenance_valas = New System.Windows.Forms.TextBox
        Me.lbl_Maintenance_valas = New System.Windows.Forms.Label
        Me.obj_Maintenance_idrprice = New System.Windows.Forms.TextBox
        Me.lbl_Maintenance_idrprice = New System.Windows.Forms.Label
        Me.pnl_top = New System.Windows.Forms.Panel
        Me.obj_Maintenance_id = New System.Windows.Forms.TextBox
        Me.lbl_Maintenance_id = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvTrnMaintenance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfFooter.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.ftabDataDetil.SuspendLayout()
        Me.ftabDataDetil_Detil.SuspendLayout()
        CType(Me.DgvTrnMaintenancedetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.PnlDataFooter.SuspendLayout()
        Me.ftabDataDetil_UserInfo.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.pnl_top.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Location = New System.Drawing.Point(3, 28)
        Me.ftabMain.myBackColor = System.Drawing.Color.White
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(747, 517)
        Me.ftabMain.TabIndex = 1
        '
        'ftabMain_List
        '
        Me.ftabMain_List.BackColor = System.Drawing.Color.White
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
        Me.PnlDfMain.Controls.Add(Me.DgvTrnMaintenance)
        Me.PnlDfMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDfMain.Location = New System.Drawing.Point(3, 91)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(733, 355)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvTrnMaintenance
        '
        Me.DgvTrnMaintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnMaintenance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnMaintenance.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnMaintenance.MultiSelect = False
        Me.DgvTrnMaintenance.Name = "DgvTrnMaintenance"
        Me.DgvTrnMaintenance.Size = New System.Drawing.Size(733, 355)
        Me.DgvTrnMaintenance.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Controls.Add(Me.obj_maintenance_outLock)
        Me.PnlDfFooter.Controls.Add(Me.lbl_maintenance_outLock)
        Me.PnlDfFooter.Controls.Add(Me.obj_maintenance_incLock)
        Me.PnlDfFooter.Controls.Add(Me.lbl_maintenance_incLock)
        Me.PnlDfFooter.Controls.Add(Me.Label2)
        Me.PnlDfFooter.Controls.Add(Me.NumericUpDown1)
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 446)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 39)
        Me.PnlDfFooter.TabIndex = 2
        '
        'obj_maintenance_outLock
        '
        Me.obj_maintenance_outLock.AutoSize = True
        Me.obj_maintenance_outLock.Enabled = False
        Me.obj_maintenance_outLock.Location = New System.Drawing.Point(260, 13)
        Me.obj_maintenance_outLock.Name = "obj_maintenance_outLock"
        Me.obj_maintenance_outLock.Size = New System.Drawing.Size(15, 14)
        Me.obj_maintenance_outLock.TabIndex = 42
        Me.obj_maintenance_outLock.UseVisualStyleBackColor = True
        '
        'lbl_maintenance_outLock
        '
        Me.lbl_maintenance_outLock.AutoSize = True
        Me.lbl_maintenance_outLock.Location = New System.Drawing.Point(200, 12)
        Me.lbl_maintenance_outLock.Name = "lbl_maintenance_outLock"
        Me.lbl_maintenance_outLock.Size = New System.Drawing.Size(54, 13)
        Me.lbl_maintenance_outLock.TabIndex = 41
        Me.lbl_maintenance_outLock.Text = "Out. Lock"
        '
        'obj_maintenance_incLock
        '
        Me.obj_maintenance_incLock.AutoSize = True
        Me.obj_maintenance_incLock.Enabled = False
        Me.obj_maintenance_incLock.Location = New System.Drawing.Point(380, 14)
        Me.obj_maintenance_incLock.Name = "obj_maintenance_incLock"
        Me.obj_maintenance_incLock.Size = New System.Drawing.Size(15, 14)
        Me.obj_maintenance_incLock.TabIndex = 40
        Me.obj_maintenance_incLock.UseVisualStyleBackColor = True
        '
        'lbl_maintenance_incLock
        '
        Me.lbl_maintenance_incLock.AutoSize = True
        Me.lbl_maintenance_incLock.Location = New System.Drawing.Point(322, 13)
        Me.lbl_maintenance_incLock.Name = "lbl_maintenance_incLock"
        Me.lbl_maintenance_incLock.Size = New System.Drawing.Size(52, 13)
        Me.lbl_maintenance_incLock.TabIndex = 39
        Me.lbl_maintenance_incLock.Text = "Inc. Lock"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(118, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Record"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(17, 9)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(95, 20)
        Me.NumericUpDown1.TabIndex = 7
        Me.NumericUpDown1.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.ObjSearchmaintenance_id)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchMaintenance_id)
        Me.PnlDfSearch.Controls.Add(Me.cmb_Maintenance_Incoming)
        Me.PnlDfSearch.Controls.Add(Me.cmb_Maintenance_Outgoing)
        Me.PnlDfSearch.Controls.Add(Me.chk_Maintenance_OutGoing)
        Me.PnlDfSearch.Controls.Add(Me.chk_Maintenance_Incoming)
        Me.PnlDfSearch.Controls.Add(Me.obj_Strukturunit_id_pemilik_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_Strukturunit_id_pemilik_search)
        Me.PnlDfSearch.Controls.Add(Me.obj_Channel_id_search)
        Me.PnlDfSearch.Controls.Add(Me.chk_Channel_id_search)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 88)
        Me.PnlDfSearch.TabIndex = 0
        '
        'ObjSearchmaintenance_id
        '
        Me.ObjSearchmaintenance_id.Location = New System.Drawing.Point(121, 57)
        Me.ObjSearchmaintenance_id.Name = "ObjSearchmaintenance_id"
        Me.ObjSearchmaintenance_id.Size = New System.Drawing.Size(148, 20)
        Me.ObjSearchmaintenance_id.TabIndex = 18
        '
        'chkSearchMaintenance_id
        '
        Me.chkSearchMaintenance_id.AutoSize = True
        Me.chkSearchMaintenance_id.ForeColor = System.Drawing.Color.Black
        Me.chkSearchMaintenance_id.Location = New System.Drawing.Point(13, 59)
        Me.chkSearchMaintenance_id.Name = "chkSearchMaintenance_id"
        Me.chkSearchMaintenance_id.Size = New System.Drawing.Size(105, 17)
        Me.chkSearchMaintenance_id.TabIndex = 17
        Me.chkSearchMaintenance_id.Text = "Maintenance No"
        Me.chkSearchMaintenance_id.UseVisualStyleBackColor = True
        '
        'cmb_Maintenance_Incoming
        '
        Me.cmb_Maintenance_Incoming.Enabled = False
        Me.cmb_Maintenance_Incoming.Items.AddRange(New Object() {"-- PILIH --", "Yes", "No"})
        Me.cmb_Maintenance_Incoming.Location = New System.Drawing.Point(579, 30)
        Me.cmb_Maintenance_Incoming.Name = "cmb_Maintenance_Incoming"
        Me.cmb_Maintenance_Incoming.Size = New System.Drawing.Size(85, 21)
        Me.cmb_Maintenance_Incoming.TabIndex = 16
        '
        'cmb_Maintenance_Outgoing
        '
        Me.cmb_Maintenance_Outgoing.Enabled = False
        Me.cmb_Maintenance_Outgoing.Items.AddRange(New Object() {"-- PILIH --", "Yes", "No"})
        Me.cmb_Maintenance_Outgoing.Location = New System.Drawing.Point(579, 6)
        Me.cmb_Maintenance_Outgoing.Name = "cmb_Maintenance_Outgoing"
        Me.cmb_Maintenance_Outgoing.Size = New System.Drawing.Size(85, 21)
        Me.cmb_Maintenance_Outgoing.TabIndex = 15
        '
        'chk_Maintenance_OutGoing
        '
        Me.chk_Maintenance_OutGoing.AutoSize = True
        Me.chk_Maintenance_OutGoing.Location = New System.Drawing.Point(438, 6)
        Me.chk_Maintenance_OutGoing.Name = "chk_Maintenance_OutGoing"
        Me.chk_Maintenance_OutGoing.Size = New System.Drawing.Size(134, 17)
        Me.chk_Maintenance_OutGoing.TabIndex = 14
        Me.chk_Maintenance_OutGoing.TabStop = False
        Me.chk_Maintenance_OutGoing.Text = "Maintenance Outgoing"
        '
        'chk_Maintenance_Incoming
        '
        Me.chk_Maintenance_Incoming.AutoSize = True
        Me.chk_Maintenance_Incoming.Location = New System.Drawing.Point(438, 32)
        Me.chk_Maintenance_Incoming.Name = "chk_Maintenance_Incoming"
        Me.chk_Maintenance_Incoming.Size = New System.Drawing.Size(134, 17)
        Me.chk_Maintenance_Incoming.TabIndex = 13
        Me.chk_Maintenance_Incoming.TabStop = False
        Me.chk_Maintenance_Incoming.Text = "Maintenance Incoming"
        '
        'obj_Strukturunit_id_pemilik_search
        '
        Me.obj_Strukturunit_id_pemilik_search.Location = New System.Drawing.Point(121, 30)
        Me.obj_Strukturunit_id_pemilik_search.Name = "obj_Strukturunit_id_pemilik_search"
        Me.obj_Strukturunit_id_pemilik_search.Size = New System.Drawing.Size(233, 21)
        Me.obj_Strukturunit_id_pemilik_search.TabIndex = 10
        '
        'chk_Strukturunit_id_pemilik_search
        '
        Me.chk_Strukturunit_id_pemilik_search.AutoSize = True
        Me.chk_Strukturunit_id_pemilik_search.Location = New System.Drawing.Point(13, 32)
        Me.chk_Strukturunit_id_pemilik_search.Name = "chk_Strukturunit_id_pemilik_search"
        Me.chk_Strukturunit_id_pemilik_search.Size = New System.Drawing.Size(81, 17)
        Me.chk_Strukturunit_id_pemilik_search.TabIndex = 9
        Me.chk_Strukturunit_id_pemilik_search.TabStop = False
        Me.chk_Strukturunit_id_pemilik_search.Text = "Department"
        '
        'obj_Channel_id_search
        '
        Me.obj_Channel_id_search.Location = New System.Drawing.Point(121, 6)
        Me.obj_Channel_id_search.Name = "obj_Channel_id_search"
        Me.obj_Channel_id_search.Size = New System.Drawing.Size(103, 21)
        Me.obj_Channel_id_search.TabIndex = 2
        '
        'chk_Channel_id_search
        '
        Me.chk_Channel_id_search.AutoSize = True
        Me.chk_Channel_id_search.Enabled = False
        Me.chk_Channel_id_search.Location = New System.Drawing.Point(13, 6)
        Me.chk_Channel_id_search.Name = "chk_Channel_id_search"
        Me.chk_Channel_id_search.Size = New System.Drawing.Size(65, 17)
        Me.chk_Channel_id_search.TabIndex = 1
        Me.chk_Channel_id_search.TabStop = False
        Me.chk_Channel_id_search.Text = "Channel"
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
        Me.ftabMain_Data.Controls.Add(Me.ftabDataDetil)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(739, 488)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Data"
        '
        'ftabDataDetil
        '
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_Detil)
        Me.ftabDataDetil.Controls.Add(Me.ftabDataDetil_UserInfo)
        Me.ftabDataDetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabDataDetil.Location = New System.Drawing.Point(3, 201)
        Me.ftabDataDetil.myBackColor = System.Drawing.Color.White
        Me.ftabDataDetil.Name = "ftabDataDetil"
        Me.ftabDataDetil.SelectedIndex = 0
        Me.ftabDataDetil.Size = New System.Drawing.Size(733, 284)
        Me.ftabDataDetil.TabIndex = 3
        '
        'ftabDataDetil_Detil
        '
        Me.ftabDataDetil_Detil.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_Detil.Controls.Add(Me.DgvTrnMaintenancedetil)
        Me.ftabDataDetil_Detil.Controls.Add(Me.PnlDataFooter)
        Me.ftabDataDetil_Detil.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_Detil.Name = "ftabDataDetil_Detil"
        Me.ftabDataDetil_Detil.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_Detil.Size = New System.Drawing.Size(725, 255)
        Me.ftabDataDetil_Detil.TabIndex = 0
        Me.ftabDataDetil_Detil.Text = "Detil"
        '
        'DgvTrnMaintenancedetil
        '
        Me.DgvTrnMaintenancedetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnMaintenancedetil.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DgvTrnMaintenancedetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnMaintenancedetil.Location = New System.Drawing.Point(3, 3)
        Me.DgvTrnMaintenancedetil.MultiSelect = False
        Me.DgvTrnMaintenancedetil.Name = "DgvTrnMaintenancedetil"
        Me.DgvTrnMaintenancedetil.Size = New System.Drawing.Size(719, 220)
        Me.DgvTrnMaintenancedetil.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateIncStatusToolStripMenuItem, Me.UpdateOutStatusToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(176, 48)
        '
        'UpdateIncStatusToolStripMenuItem
        '
        Me.UpdateIncStatusToolStripMenuItem.Name = "UpdateIncStatusToolStripMenuItem"
        Me.UpdateIncStatusToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.UpdateIncStatusToolStripMenuItem.Text = "Update Inc Status"
        '
        'UpdateOutStatusToolStripMenuItem
        '
        Me.UpdateOutStatusToolStripMenuItem.Name = "UpdateOutStatusToolStripMenuItem"
        Me.UpdateOutStatusToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.UpdateOutStatusToolStripMenuItem.Text = "Update Out Status"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Controls.Add(Me.obj_Maintenace_itemqty)
        Me.PnlDataFooter.Controls.Add(Me.lbl_Maintenace_itemqty)
        Me.PnlDataFooter.Controls.Add(Me.obj_Maintenace_itemqtyret)
        Me.PnlDataFooter.Controls.Add(Me.lbl_Maintenace_itemqtyret)
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 223)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(719, 29)
        Me.PnlDataFooter.TabIndex = 3
        '
        'obj_Maintenace_itemqty
        '
        Me.obj_Maintenace_itemqty.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenace_itemqty.Location = New System.Drawing.Point(68, 5)
        Me.obj_Maintenace_itemqty.Name = "obj_Maintenace_itemqty"
        Me.obj_Maintenace_itemqty.ReadOnly = True
        Me.obj_Maintenace_itemqty.Size = New System.Drawing.Size(55, 20)
        Me.obj_Maintenace_itemqty.TabIndex = 4
        Me.obj_Maintenace_itemqty.TabStop = False
        '
        'lbl_Maintenace_itemqty
        '
        Me.lbl_Maintenace_itemqty.AutoSize = True
        Me.lbl_Maintenace_itemqty.Location = New System.Drawing.Point(16, 8)
        Me.lbl_Maintenace_itemqty.Name = "lbl_Maintenace_itemqty"
        Me.lbl_Maintenace_itemqty.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Maintenace_itemqty.TabIndex = 3
        Me.lbl_Maintenace_itemqty.Text = "Item Qty"
        '
        'obj_Maintenace_itemqtyret
        '
        Me.obj_Maintenace_itemqtyret.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenace_itemqtyret.Location = New System.Drawing.Point(224, 5)
        Me.obj_Maintenace_itemqtyret.Name = "obj_Maintenace_itemqtyret"
        Me.obj_Maintenace_itemqtyret.ReadOnly = True
        Me.obj_Maintenace_itemqtyret.Size = New System.Drawing.Size(55, 20)
        Me.obj_Maintenace_itemqtyret.TabIndex = 5
        Me.obj_Maintenace_itemqtyret.TabStop = False
        '
        'lbl_Maintenace_itemqtyret
        '
        Me.lbl_Maintenace_itemqtyret.AutoSize = True
        Me.lbl_Maintenace_itemqtyret.Location = New System.Drawing.Point(137, 7)
        Me.lbl_Maintenace_itemqtyret.Name = "lbl_Maintenace_itemqtyret"
        Me.lbl_Maintenace_itemqtyret.Size = New System.Drawing.Size(81, 13)
        Me.lbl_Maintenace_itemqtyret.TabIndex = 2
        Me.lbl_Maintenace_itemqtyret.Text = "Item Qty Return"
        '
        'ftabDataDetil_UserInfo
        '
        Me.ftabDataDetil_UserInfo.BackColor = System.Drawing.Color.White
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.obj_Channel_id)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.lbl_Channel_id)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.obj_Maintenance_usedby)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.lbl_Maintenance_usedby)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.obj_Maintenance_useddt)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.lbl_Maintenance_useddt)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.obj_Maintenance_editby)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.lbl_Maintenance_editby)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.obj_Maintenance_editdt)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.lbl_Maintenance_editdt)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.obj_Maintenance_inputby)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.lbl_Maintenance_inputby)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.obj_Maintenance_inputdt)
        Me.ftabDataDetil_UserInfo.Controls.Add(Me.lbl_Maintenance_inputdt)
        Me.ftabDataDetil_UserInfo.Location = New System.Drawing.Point(4, 25)
        Me.ftabDataDetil_UserInfo.Name = "ftabDataDetil_UserInfo"
        Me.ftabDataDetil_UserInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabDataDetil_UserInfo.Size = New System.Drawing.Size(178, 0)
        Me.ftabDataDetil_UserInfo.TabIndex = 1
        Me.ftabDataDetil_UserInfo.Text = "User Info"
        '
        'obj_Channel_id
        '
        Me.obj_Channel_id.Enabled = False
        Me.obj_Channel_id.FormattingEnabled = True
        Me.obj_Channel_id.Location = New System.Drawing.Point(486, 8)
        Me.obj_Channel_id.Name = "obj_Channel_id"
        Me.obj_Channel_id.Size = New System.Drawing.Size(147, 21)
        Me.obj_Channel_id.TabIndex = 28
        Me.obj_Channel_id.TabStop = False
        '
        'lbl_Channel_id
        '
        Me.lbl_Channel_id.AutoSize = True
        Me.lbl_Channel_id.Location = New System.Drawing.Point(391, 11)
        Me.lbl_Channel_id.Name = "lbl_Channel_id"
        Me.lbl_Channel_id.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Channel_id.TabIndex = 27
        Me.lbl_Channel_id.Text = "Channel"
        '
        'obj_Maintenance_usedby
        '
        Me.obj_Maintenance_usedby.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenance_usedby.Location = New System.Drawing.Point(135, 95)
        Me.obj_Maintenance_usedby.Name = "obj_Maintenance_usedby"
        Me.obj_Maintenance_usedby.Size = New System.Drawing.Size(198, 20)
        Me.obj_Maintenance_usedby.TabIndex = 23
        '
        'lbl_Maintenance_usedby
        '
        Me.lbl_Maintenance_usedby.AutoSize = True
        Me.lbl_Maintenance_usedby.Location = New System.Drawing.Point(19, 95)
        Me.lbl_Maintenance_usedby.Name = "lbl_Maintenance_usedby"
        Me.lbl_Maintenance_usedby.Size = New System.Drawing.Size(47, 13)
        Me.lbl_Maintenance_usedby.TabIndex = 21
        Me.lbl_Maintenance_usedby.Text = "Used By"
        '
        'obj_Maintenance_useddt
        '
        Me.obj_Maintenance_useddt.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenance_useddt.Location = New System.Drawing.Point(135, 116)
        Me.obj_Maintenance_useddt.Name = "obj_Maintenance_useddt"
        Me.obj_Maintenance_useddt.Size = New System.Drawing.Size(198, 20)
        Me.obj_Maintenance_useddt.TabIndex = 22
        '
        'lbl_Maintenance_useddt
        '
        Me.lbl_Maintenance_useddt.AutoSize = True
        Me.lbl_Maintenance_useddt.Location = New System.Drawing.Point(19, 116)
        Me.lbl_Maintenance_useddt.Name = "lbl_Maintenance_useddt"
        Me.lbl_Maintenance_useddt.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Maintenance_useddt.TabIndex = 20
        Me.lbl_Maintenance_useddt.Text = "Used Date"
        '
        'obj_Maintenance_editby
        '
        Me.obj_Maintenance_editby.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenance_editby.Location = New System.Drawing.Point(135, 53)
        Me.obj_Maintenance_editby.Name = "obj_Maintenance_editby"
        Me.obj_Maintenance_editby.Size = New System.Drawing.Size(198, 20)
        Me.obj_Maintenance_editby.TabIndex = 19
        '
        'lbl_Maintenance_editby
        '
        Me.lbl_Maintenance_editby.AutoSize = True
        Me.lbl_Maintenance_editby.Location = New System.Drawing.Point(19, 53)
        Me.lbl_Maintenance_editby.Name = "lbl_Maintenance_editby"
        Me.lbl_Maintenance_editby.Size = New System.Drawing.Size(40, 13)
        Me.lbl_Maintenance_editby.TabIndex = 17
        Me.lbl_Maintenance_editby.Text = "Edit By"
        '
        'obj_Maintenance_editdt
        '
        Me.obj_Maintenance_editdt.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenance_editdt.Location = New System.Drawing.Point(135, 74)
        Me.obj_Maintenance_editdt.Name = "obj_Maintenance_editdt"
        Me.obj_Maintenance_editdt.Size = New System.Drawing.Size(198, 20)
        Me.obj_Maintenance_editdt.TabIndex = 18
        '
        'lbl_Maintenance_editdt
        '
        Me.lbl_Maintenance_editdt.AutoSize = True
        Me.lbl_Maintenance_editdt.Location = New System.Drawing.Point(19, 74)
        Me.lbl_Maintenance_editdt.Name = "lbl_Maintenance_editdt"
        Me.lbl_Maintenance_editdt.Size = New System.Drawing.Size(51, 13)
        Me.lbl_Maintenance_editdt.TabIndex = 16
        Me.lbl_Maintenance_editdt.Text = "Edit Date"
        '
        'obj_Maintenance_inputby
        '
        Me.obj_Maintenance_inputby.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenance_inputby.Location = New System.Drawing.Point(135, 11)
        Me.obj_Maintenance_inputby.Name = "obj_Maintenance_inputby"
        Me.obj_Maintenance_inputby.Size = New System.Drawing.Size(198, 20)
        Me.obj_Maintenance_inputby.TabIndex = 14
        '
        'lbl_Maintenance_inputby
        '
        Me.lbl_Maintenance_inputby.AutoSize = True
        Me.lbl_Maintenance_inputby.Location = New System.Drawing.Point(19, 11)
        Me.lbl_Maintenance_inputby.Name = "lbl_Maintenance_inputby"
        Me.lbl_Maintenance_inputby.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Maintenance_inputby.TabIndex = 13
        Me.lbl_Maintenance_inputby.Text = "Input By"
        '
        'obj_Maintenance_inputdt
        '
        Me.obj_Maintenance_inputdt.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenance_inputdt.Location = New System.Drawing.Point(135, 32)
        Me.obj_Maintenance_inputdt.Name = "obj_Maintenance_inputdt"
        Me.obj_Maintenance_inputdt.Size = New System.Drawing.Size(198, 20)
        Me.obj_Maintenance_inputdt.TabIndex = 15
        '
        'lbl_Maintenance_inputdt
        '
        Me.lbl_Maintenance_inputdt.AutoSize = True
        Me.lbl_Maintenance_inputdt.Location = New System.Drawing.Point(19, 32)
        Me.lbl_Maintenance_inputdt.Name = "lbl_Maintenance_inputdt"
        Me.lbl_Maintenance_inputdt.Size = New System.Drawing.Size(57, 13)
        Me.lbl_Maintenance_inputdt.TabIndex = 12
        Me.lbl_Maintenance_inputdt.Text = "Input Date"
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.BackColor = System.Drawing.Color.Turquoise
        Me.PnlDataMaster.Controls.Add(Me.obj_Currency_id)
        Me.PnlDataMaster.Controls.Add(Me.Label3)
        Me.PnlDataMaster.Controls.Add(Me.TextBox1)
        Me.PnlDataMaster.Controls.Add(Me.obj_Maintenance_outdt)
        Me.PnlDataMaster.Controls.Add(Me.obj_Maintenance_indt)
        Me.PnlDataMaster.Controls.Add(Me.obj_Strukturunit_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Employee_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Order_id)
        Me.PnlDataMaster.Controls.Add(Me.obj_Maintenance_type)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Maintenance_type)
        Me.PnlDataMaster.Controls.Add(Me.obj_Maintenance_outin)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Maintenance_outin)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Order_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Rekanan_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Employee_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Strukturunit_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Maintenance_indt)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Maintenance_outdt)
        Me.PnlDataMaster.Controls.Add(Me.obj_Maintenance_status)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Maintenance_status)
        Me.PnlDataMaster.Controls.Add(Me.obj_Maintenance_harga)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Maintenance_harga)
        Me.PnlDataMaster.Controls.Add(Me.obj_Maintenance_valas)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Maintenance_valas)
        Me.PnlDataMaster.Controls.Add(Me.obj_Maintenance_idrprice)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Maintenance_idrprice)
        Me.PnlDataMaster.Controls.Add(Me.pnl_top)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 198)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_Currency_id
        '
        Me.obj_Currency_id.Location = New System.Drawing.Point(490, 78)
        Me.obj_Currency_id.Name = "obj_Currency_id"
        Me.obj_Currency_id.Size = New System.Drawing.Size(66, 21)
        Me.obj_Currency_id.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(395, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 237
        Me.Label3.Text = "Maintenance Item"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.DarkRed
        Me.TextBox1.Location = New System.Drawing.Point(490, 169)
        Me.TextBox1.MaxLength = 20
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(216, 22)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Text = "- - Item Maintenance - -"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'obj_Maintenance_outdt
        '
        Me.obj_Maintenance_outdt.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenance_outdt.Location = New System.Drawing.Point(490, 33)
        Me.obj_Maintenance_outdt.Mask = "00/00/0000"
        Me.obj_Maintenance_outdt.Name = "obj_Maintenance_outdt"
        Me.obj_Maintenance_outdt.ReadOnly = True
        Me.obj_Maintenance_outdt.Size = New System.Drawing.Size(216, 20)
        Me.obj_Maintenance_outdt.TabIndex = 235
        Me.obj_Maintenance_outdt.TabStop = False
        '
        'obj_Maintenance_indt
        '
        Me.obj_Maintenance_indt.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenance_indt.Location = New System.Drawing.Point(490, 56)
        Me.obj_Maintenance_indt.Mask = "00/00/0000"
        Me.obj_Maintenance_indt.Name = "obj_Maintenance_indt"
        Me.obj_Maintenance_indt.ReadOnly = True
        Me.obj_Maintenance_indt.Size = New System.Drawing.Size(216, 20)
        Me.obj_Maintenance_indt.TabIndex = 234
        Me.obj_Maintenance_indt.TabStop = False
        '
        'obj_Strukturunit_id
        '
        Me.obj_Strukturunit_id.Enabled = False
        Me.obj_Strukturunit_id.FormattingEnabled = True
        Me.obj_Strukturunit_id.Location = New System.Drawing.Point(139, 100)
        Me.obj_Strukturunit_id.Name = "obj_Strukturunit_id"
        Me.obj_Strukturunit_id.Size = New System.Drawing.Size(198, 21)
        Me.obj_Strukturunit_id.TabIndex = 3
        '
        'obj_Employee_id
        '
        Me.obj_Employee_id.FormattingEnabled = True
        Me.obj_Employee_id.Location = New System.Drawing.Point(139, 78)
        Me.obj_Employee_id.Name = "obj_Employee_id"
        Me.obj_Employee_id.Size = New System.Drawing.Size(198, 21)
        Me.obj_Employee_id.TabIndex = 2
        '
        'obj_Rekanan_id
        '
        Me.obj_Rekanan_id.FormattingEnabled = True
        Me.obj_Rekanan_id.Location = New System.Drawing.Point(139, 122)
        Me.obj_Rekanan_id.Name = "obj_Rekanan_id"
        Me.obj_Rekanan_id.Size = New System.Drawing.Size(198, 21)
        Me.obj_Rekanan_id.TabIndex = 4
        '
        'obj_Order_id
        '
        Me.obj_Order_id.FormattingEnabled = True
        Me.obj_Order_id.Location = New System.Drawing.Point(139, 55)
        Me.obj_Order_id.Name = "obj_Order_id"
        Me.obj_Order_id.Size = New System.Drawing.Size(198, 21)
        Me.obj_Order_id.TabIndex = 1
        '
        'obj_Maintenance_type
        '
        Me.obj_Maintenance_type.FormattingEnabled = True
        Me.obj_Maintenance_type.Items.AddRange(New Object() {"-- PILIH --", "Laundry", "Maintenance"})
        Me.obj_Maintenance_type.Location = New System.Drawing.Point(139, 32)
        Me.obj_Maintenance_type.Name = "obj_Maintenance_type"
        Me.obj_Maintenance_type.Size = New System.Drawing.Size(198, 21)
        Me.obj_Maintenance_type.TabIndex = 0
        '
        'lbl_Maintenance_type
        '
        Me.lbl_Maintenance_type.AutoSize = True
        Me.lbl_Maintenance_type.Location = New System.Drawing.Point(23, 35)
        Me.lbl_Maintenance_type.Name = "lbl_Maintenance_type"
        Me.lbl_Maintenance_type.Size = New System.Drawing.Size(96, 13)
        Me.lbl_Maintenance_type.TabIndex = 0
        Me.lbl_Maintenance_type.Text = "Maintenance Type"
        '
        'obj_Maintenance_outin
        '
        Me.obj_Maintenance_outin.AutoSize = True
        Me.obj_Maintenance_outin.Location = New System.Drawing.Point(139, 167)
        Me.obj_Maintenance_outin.Name = "obj_Maintenance_outin"
        Me.obj_Maintenance_outin.Size = New System.Drawing.Size(15, 14)
        Me.obj_Maintenance_outin.TabIndex = 8
        Me.obj_Maintenance_outin.UseVisualStyleBackColor = True
        '
        'lbl_Maintenance_outin
        '
        Me.lbl_Maintenance_outin.AutoSize = True
        Me.lbl_Maintenance_outin.Location = New System.Drawing.Point(23, 166)
        Me.lbl_Maintenance_outin.Name = "lbl_Maintenance_outin"
        Me.lbl_Maintenance_outin.Size = New System.Drawing.Size(24, 13)
        Me.lbl_Maintenance_outin.TabIndex = 0
        Me.lbl_Maintenance_outin.Text = "Out"
        '
        'lbl_Order_id
        '
        Me.lbl_Order_id.AutoSize = True
        Me.lbl_Order_id.Location = New System.Drawing.Point(23, 58)
        Me.lbl_Order_id.Name = "lbl_Order_id"
        Me.lbl_Order_id.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Order_id.TabIndex = 0
        Me.lbl_Order_id.Text = "Order No."
        '
        'lbl_Rekanan_id
        '
        Me.lbl_Rekanan_id.AutoSize = True
        Me.lbl_Rekanan_id.Location = New System.Drawing.Point(23, 125)
        Me.lbl_Rekanan_id.Name = "lbl_Rekanan_id"
        Me.lbl_Rekanan_id.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Rekanan_id.TabIndex = 0
        Me.lbl_Rekanan_id.Text = "Vendor"
        '
        'lbl_Employee_id
        '
        Me.lbl_Employee_id.AutoSize = True
        Me.lbl_Employee_id.Location = New System.Drawing.Point(23, 81)
        Me.lbl_Employee_id.Name = "lbl_Employee_id"
        Me.lbl_Employee_id.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Employee_id.TabIndex = 0
        Me.lbl_Employee_id.Text = "Employee"
        '
        'lbl_Strukturunit_id
        '
        Me.lbl_Strukturunit_id.AutoSize = True
        Me.lbl_Strukturunit_id.Location = New System.Drawing.Point(23, 103)
        Me.lbl_Strukturunit_id.Name = "lbl_Strukturunit_id"
        Me.lbl_Strukturunit_id.Size = New System.Drawing.Size(62, 13)
        Me.lbl_Strukturunit_id.TabIndex = 0
        Me.lbl_Strukturunit_id.Text = "Department"
        '
        'lbl_Maintenance_indt
        '
        Me.lbl_Maintenance_indt.AutoSize = True
        Me.lbl_Maintenance_indt.Location = New System.Drawing.Point(395, 59)
        Me.lbl_Maintenance_indt.Name = "lbl_Maintenance_indt"
        Me.lbl_Maintenance_indt.Size = New System.Drawing.Size(76, 13)
        Me.lbl_Maintenance_indt.TabIndex = 0
        Me.lbl_Maintenance_indt.Text = "Incoming Date"
        '
        'lbl_Maintenance_outdt
        '
        Me.lbl_Maintenance_outdt.AutoSize = True
        Me.lbl_Maintenance_outdt.Location = New System.Drawing.Point(395, 36)
        Me.lbl_Maintenance_outdt.Name = "lbl_Maintenance_outdt"
        Me.lbl_Maintenance_outdt.Size = New System.Drawing.Size(74, 13)
        Me.lbl_Maintenance_outdt.TabIndex = 0
        Me.lbl_Maintenance_outdt.Text = "Outgoing date"
        '
        'obj_Maintenance_status
        '
        Me.obj_Maintenance_status.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenance_status.Location = New System.Drawing.Point(139, 144)
        Me.obj_Maintenance_status.Name = "obj_Maintenance_status"
        Me.obj_Maintenance_status.ReadOnly = True
        Me.obj_Maintenance_status.Size = New System.Drawing.Size(198, 20)
        Me.obj_Maintenance_status.TabIndex = 1
        Me.obj_Maintenance_status.TabStop = False
        '
        'lbl_Maintenance_status
        '
        Me.lbl_Maintenance_status.AutoSize = True
        Me.lbl_Maintenance_status.Location = New System.Drawing.Point(23, 144)
        Me.lbl_Maintenance_status.Name = "lbl_Maintenance_status"
        Me.lbl_Maintenance_status.Size = New System.Drawing.Size(102, 13)
        Me.lbl_Maintenance_status.TabIndex = 0
        Me.lbl_Maintenance_status.Text = "Maintenance Status"
        '
        'obj_Maintenance_harga
        '
        Me.obj_Maintenance_harga.Location = New System.Drawing.Point(562, 78)
        Me.obj_Maintenance_harga.Name = "obj_Maintenance_harga"
        Me.obj_Maintenance_harga.Size = New System.Drawing.Size(144, 20)
        Me.obj_Maintenance_harga.TabIndex = 6
        Me.obj_Maintenance_harga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Maintenance_harga
        '
        Me.lbl_Maintenance_harga.AutoSize = True
        Me.lbl_Maintenance_harga.Location = New System.Drawing.Point(395, 81)
        Me.lbl_Maintenance_harga.Name = "lbl_Maintenance_harga"
        Me.lbl_Maintenance_harga.Size = New System.Drawing.Size(34, 13)
        Me.lbl_Maintenance_harga.TabIndex = 0
        Me.lbl_Maintenance_harga.Text = "Value"
        '
        'obj_Maintenance_valas
        '
        Me.obj_Maintenance_valas.Location = New System.Drawing.Point(490, 100)
        Me.obj_Maintenance_valas.Name = "obj_Maintenance_valas"
        Me.obj_Maintenance_valas.Size = New System.Drawing.Size(216, 20)
        Me.obj_Maintenance_valas.TabIndex = 7
        Me.obj_Maintenance_valas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Maintenance_valas
        '
        Me.lbl_Maintenance_valas.AutoSize = True
        Me.lbl_Maintenance_valas.Location = New System.Drawing.Point(395, 100)
        Me.lbl_Maintenance_valas.Name = "lbl_Maintenance_valas"
        Me.lbl_Maintenance_valas.Size = New System.Drawing.Size(28, 13)
        Me.lbl_Maintenance_valas.TabIndex = 0
        Me.lbl_Maintenance_valas.Text = "Kurs"
        '
        'obj_Maintenance_idrprice
        '
        Me.obj_Maintenance_idrprice.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenance_idrprice.Location = New System.Drawing.Point(490, 121)
        Me.obj_Maintenance_idrprice.Name = "obj_Maintenance_idrprice"
        Me.obj_Maintenance_idrprice.ReadOnly = True
        Me.obj_Maintenance_idrprice.Size = New System.Drawing.Size(216, 20)
        Me.obj_Maintenance_idrprice.TabIndex = 1
        Me.obj_Maintenance_idrprice.TabStop = False
        Me.obj_Maintenance_idrprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Maintenance_idrprice
        '
        Me.lbl_Maintenance_idrprice.AutoSize = True
        Me.lbl_Maintenance_idrprice.Location = New System.Drawing.Point(395, 124)
        Me.lbl_Maintenance_idrprice.Name = "lbl_Maintenance_idrprice"
        Me.lbl_Maintenance_idrprice.Size = New System.Drawing.Size(56, 13)
        Me.lbl_Maintenance_idrprice.TabIndex = 0
        Me.lbl_Maintenance_idrprice.Text = "IDR Value"
        '
        'pnl_top
        '
        Me.pnl_top.BackColor = System.Drawing.Color.Aquamarine
        Me.pnl_top.Controls.Add(Me.obj_Maintenance_id)
        Me.pnl_top.Controls.Add(Me.lbl_Maintenance_id)
        Me.pnl_top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_top.Location = New System.Drawing.Point(0, 0)
        Me.pnl_top.Name = "pnl_top"
        Me.pnl_top.Size = New System.Drawing.Size(733, 27)
        Me.pnl_top.TabIndex = 4
        '
        'obj_Maintenance_id
        '
        Me.obj_Maintenance_id.BackColor = System.Drawing.Color.PapayaWhip
        Me.obj_Maintenance_id.Location = New System.Drawing.Point(139, 3)
        Me.obj_Maintenance_id.Name = "obj_Maintenance_id"
        Me.obj_Maintenance_id.ReadOnly = True
        Me.obj_Maintenance_id.Size = New System.Drawing.Size(147, 20)
        Me.obj_Maintenance_id.TabIndex = 25
        Me.obj_Maintenance_id.TabStop = False
        '
        'lbl_Maintenance_id
        '
        Me.lbl_Maintenance_id.AutoSize = True
        Me.lbl_Maintenance_id.Location = New System.Drawing.Point(23, 4)
        Me.lbl_Maintenance_id.Name = "lbl_Maintenance_id"
        Me.lbl_Maintenance_id.Size = New System.Drawing.Size(89, 13)
        Me.lbl_Maintenance_id.TabIndex = 23
        Me.lbl_Maintenance_id.Text = "Maintenance No."
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "key.ico")
        '
        'uiTrnMaintenanceAsset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiTrnMaintenanceAsset"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvTrnMaintenance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfFooter.ResumeLayout(False)
        Me.PnlDfFooter.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.ftabDataDetil.ResumeLayout(False)
        Me.ftabDataDetil_Detil.ResumeLayout(False)
        CType(Me.DgvTrnMaintenancedetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.PnlDataFooter.ResumeLayout(False)
        Me.PnlDataFooter.PerformLayout()
        Me.ftabDataDetil_UserInfo.ResumeLayout(False)
        Me.ftabDataDetil_UserInfo.PerformLayout()
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDataMaster.PerformLayout()
        Me.pnl_top.ResumeLayout(False)
        Me.pnl_top.PerformLayout()
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
    Friend WithEvents ftabDataDetil As FlatTabControl.FlatTabControl
    Friend WithEvents ftabDataDetil_Detil As System.Windows.Forms.TabPage
    Friend WithEvents DgvTrnMaintenancedetil As System.Windows.Forms.DataGridView
    Friend WithEvents DgvTrnMaintenance As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Maintenance_type As System.Windows.Forms.Label
    Friend WithEvents lbl_Maintenance_outin As System.Windows.Forms.Label
    Friend WithEvents obj_Maintenance_outin As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Order_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Rekanan_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Employee_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Strukturunit_id As System.Windows.Forms.Label
    Friend WithEvents lbl_Maintenance_indt As System.Windows.Forms.Label
    Friend WithEvents lbl_Maintenance_outdt As System.Windows.Forms.Label
    Friend WithEvents lbl_Maintenance_status As System.Windows.Forms.Label
    Friend WithEvents obj_Maintenance_status As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenance_harga As System.Windows.Forms.Label
    Friend WithEvents obj_Maintenance_harga As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenance_valas As System.Windows.Forms.Label
    Friend WithEvents obj_Maintenance_valas As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenance_idrprice As System.Windows.Forms.Label
    Friend WithEvents obj_Maintenance_idrprice As System.Windows.Forms.TextBox
    Friend WithEvents obj_Strukturunit_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Employee_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Rekanan_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Order_id As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Maintenance_type As System.Windows.Forms.ComboBox
    Friend WithEvents obj_Maintenance_outdt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents obj_Maintenance_indt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents pnl_top As System.Windows.Forms.Panel
    Friend WithEvents obj_Maintenance_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenance_id As System.Windows.Forms.Label
    Friend WithEvents obj_Channel_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Channel_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Strukturunit_id_pemilik_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Strukturunit_id_pemilik_search As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents obj_Currency_id As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UpdateIncStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateOutStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents obj_maintenance_outLock As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_maintenance_outLock As System.Windows.Forms.Label
    Friend WithEvents obj_maintenance_incLock As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_maintenance_incLock As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ftabDataDetil_UserInfo As System.Windows.Forms.TabPage
    Friend WithEvents obj_Maintenance_usedby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenance_usedby As System.Windows.Forms.Label
    Friend WithEvents obj_Maintenance_useddt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenance_useddt As System.Windows.Forms.Label
    Friend WithEvents obj_Maintenance_editby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenance_editby As System.Windows.Forms.Label
    Friend WithEvents obj_Maintenance_editdt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenance_editdt As System.Windows.Forms.Label
    Friend WithEvents obj_Maintenance_inputby As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenance_inputby As System.Windows.Forms.Label
    Friend WithEvents obj_Maintenance_inputdt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenance_inputdt As System.Windows.Forms.Label
    Friend WithEvents PnlDataFooter As System.Windows.Forms.Panel
    Friend WithEvents obj_Maintenace_itemqty As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenace_itemqty As System.Windows.Forms.Label
    Friend WithEvents obj_Maintenace_itemqtyret As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Maintenace_itemqtyret As System.Windows.Forms.Label
    Friend WithEvents obj_Channel_id As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Channel_id As System.Windows.Forms.Label
    Friend WithEvents cmb_Maintenance_Incoming As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_Maintenance_Outgoing As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Maintenance_OutGoing As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Maintenance_Incoming As System.Windows.Forms.CheckBox
    Friend WithEvents ObjSearchmaintenance_id As System.Windows.Forms.TextBox
    Friend WithEvents chkSearchMaintenance_id As System.Windows.Forms.CheckBox

End Class

