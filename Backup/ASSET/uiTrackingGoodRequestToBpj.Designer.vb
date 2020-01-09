<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrackingGoodRequestToBpj
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
        Me.RvSearch = New Microsoft.Reporting.WinForms.ReportViewer
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.chkSearch = New System.Windows.Forms.CheckBox
        Me.cbo_rekap = New System.Windows.Forms.ComboBox
        Me.chkSearch_Rekap = New System.Windows.Forms.CheckBox
        Me.cboSearchStrukturunit_ID = New System.Windows.Forms.ComboBox
        Me.chkSearchStrukturunit_ID = New System.Windows.Forms.CheckBox
        Me.obj_tracking_search = New System.Windows.Forms.TextBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.PnlDfMain_Searching = New System.Windows.Forms.Panel
        Me.DgvSearch = New System.Windows.Forms.DataGridView
        Me.PnlDfSearch_Searching = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.CheckBox5 = New System.Windows.Forms.CheckBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        Me.PnlDfSearch.SuspendLayout()
        Me.ftabMain_Data.SuspendLayout()
        Me.PnlDataMaster.SuspendLayout()
        Me.PnlDfMain_Searching.SuspendLayout()
        CType(Me.DgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfSearch_Searching.SuspendLayout()
        Me.PnlDataFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'ftabMain
        '
        Me.ftabMain.Controls.Add(Me.ftabMain_List)
        Me.ftabMain.Controls.Add(Me.ftabMain_Data)
        Me.ftabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ftabMain.Location = New System.Drawing.Point(0, 25)
        Me.ftabMain.myBackColor = System.Drawing.Color.SkyBlue
        Me.ftabMain.Name = "ftabMain"
        Me.ftabMain.SelectedIndex = 0
        Me.ftabMain.Size = New System.Drawing.Size(753, 523)
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
        Me.ftabMain_List.Size = New System.Drawing.Size(745, 494)
        Me.ftabMain_List.TabIndex = 0
        Me.ftabMain_List.Text = "View"
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.RvSearch)
        Me.PnlDfMain.Location = New System.Drawing.Point(24, 126)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 214)
        Me.PnlDfMain.TabIndex = 9
        '
        'RvSearch
        '
        Me.RvSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RvSearch.Location = New System.Drawing.Point(0, 0)
        Me.RvSearch.Name = "RvSearch"
        Me.RvSearch.Size = New System.Drawing.Size(704, 214)
        Me.RvSearch.TabIndex = 2
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 472)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(739, 19)
        Me.PnlDfFooter.TabIndex = 8
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.BackColor = System.Drawing.Color.SkyBlue
        Me.PnlDfSearch.Controls.Add(Me.ComboBox1)
        Me.PnlDfSearch.Controls.Add(Me.CheckBox1)
        Me.PnlDfSearch.Controls.Add(Me.chkSearch)
        Me.PnlDfSearch.Controls.Add(Me.cbo_rekap)
        Me.PnlDfSearch.Controls.Add(Me.chkSearch_Rekap)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchStrukturunit_ID)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchStrukturunit_ID)
        Me.PnlDfSearch.Controls.Add(Me.obj_tracking_search)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(739, 57)
        Me.PnlDfSearch.TabIndex = 7
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(452, 5)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(186, 21)
        Me.ComboBox1.TabIndex = 58
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(388, 7)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(58, 17)
        Me.CheckBox1.TabIndex = 57
        Me.CheckBox1.Text = "Criteria"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'chkSearch
        '
        Me.chkSearch.AutoSize = True
        Me.chkSearch.Location = New System.Drawing.Point(388, 30)
        Me.chkSearch.Name = "chkSearch"
        Me.chkSearch.Size = New System.Drawing.Size(60, 17)
        Me.chkSearch.TabIndex = 56
        Me.chkSearch.Text = "Search"
        Me.chkSearch.UseVisualStyleBackColor = True
        '
        'cbo_rekap
        '
        Me.cbo_rekap.FormattingEnabled = True
        Me.cbo_rekap.Items.AddRange(New Object() {"Entry Goods Request", "Order to Bpj", "No"})
        Me.cbo_rekap.Location = New System.Drawing.Point(111, 28)
        Me.cbo_rekap.Name = "cbo_rekap"
        Me.cbo_rekap.Size = New System.Drawing.Size(205, 21)
        Me.cbo_rekap.TabIndex = 55
        '
        'chkSearch_Rekap
        '
        Me.chkSearch_Rekap.AutoSize = True
        Me.chkSearch_Rekap.Checked = True
        Me.chkSearch_Rekap.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearch_Rekap.Enabled = False
        Me.chkSearch_Rekap.Location = New System.Drawing.Point(24, 30)
        Me.chkSearch_Rekap.Name = "chkSearch_Rekap"
        Me.chkSearch_Rekap.Size = New System.Drawing.Size(69, 17)
        Me.chkSearch_Rekap.TabIndex = 54
        Me.chkSearch_Rekap.Text = "Summary"
        Me.chkSearch_Rekap.UseVisualStyleBackColor = True
        '
        'cboSearchStrukturunit_ID
        '
        Me.cboSearchStrukturunit_ID.FormattingEnabled = True
        Me.cboSearchStrukturunit_ID.Location = New System.Drawing.Point(111, 4)
        Me.cboSearchStrukturunit_ID.Name = "cboSearchStrukturunit_ID"
        Me.cboSearchStrukturunit_ID.Size = New System.Drawing.Size(205, 21)
        Me.cboSearchStrukturunit_ID.TabIndex = 3
        '
        'chkSearchStrukturunit_ID
        '
        Me.chkSearchStrukturunit_ID.AutoSize = True
        Me.chkSearchStrukturunit_ID.Location = New System.Drawing.Point(24, 6)
        Me.chkSearchStrukturunit_ID.Name = "chkSearchStrukturunit_ID"
        Me.chkSearchStrukturunit_ID.Size = New System.Drawing.Size(81, 17)
        Me.chkSearchStrukturunit_ID.TabIndex = 2
        Me.chkSearchStrukturunit_ID.Text = "Department"
        Me.chkSearchStrukturunit_ID.UseVisualStyleBackColor = True
        '
        'obj_tracking_search
        '
        Me.obj_tracking_search.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_tracking_search.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.obj_tracking_search.Location = New System.Drawing.Point(452, 28)
        Me.obj_tracking_search.Name = "obj_tracking_search"
        Me.obj_tracking_search.ReadOnly = True
        Me.obj_tracking_search.Size = New System.Drawing.Size(186, 20)
        Me.obj_tracking_search.TabIndex = 1
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.Ivory
        Me.ftabMain_Data.Controls.Add(Me.PnlDataMaster)
        Me.ftabMain_Data.Controls.Add(Me.PnlDataFooter)
        Me.ftabMain_Data.Location = New System.Drawing.Point(4, 25)
        Me.ftabMain_Data.Name = "ftabMain_Data"
        Me.ftabMain_Data.Padding = New System.Windows.Forms.Padding(3)
        Me.ftabMain_Data.Size = New System.Drawing.Size(745, 494)
        Me.ftabMain_Data.TabIndex = 1
        Me.ftabMain_Data.Text = "Search"
        '
        'PnlDataMaster
        '
        Me.PnlDataMaster.AutoScroll = True
        Me.PnlDataMaster.Controls.Add(Me.PnlDfMain_Searching)
        Me.PnlDataMaster.Controls.Add(Me.PnlDfSearch_Searching)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(739, 430)
        Me.PnlDataMaster.TabIndex = 0
        '
        'PnlDfMain_Searching
        '
        Me.PnlDfMain_Searching.Controls.Add(Me.DgvSearch)
        Me.PnlDfMain_Searching.Location = New System.Drawing.Point(14, 116)
        Me.PnlDfMain_Searching.Name = "PnlDfMain_Searching"
        Me.PnlDfMain_Searching.Size = New System.Drawing.Size(704, 214)
        Me.PnlDfMain_Searching.TabIndex = 10
        '
        'DgvSearch
        '
        Me.DgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvSearch.Location = New System.Drawing.Point(0, 0)
        Me.DgvSearch.MultiSelect = False
        Me.DgvSearch.Name = "DgvSearch"
        Me.DgvSearch.Size = New System.Drawing.Size(704, 214)
        Me.DgvSearch.TabIndex = 7
        '
        'PnlDfSearch_Searching
        '
        Me.PnlDfSearch_Searching.BackColor = System.Drawing.Color.SkyBlue
        Me.PnlDfSearch_Searching.Controls.Add(Me.Label1)
        Me.PnlDfSearch_Searching.Controls.Add(Me.ComboBox4)
        Me.PnlDfSearch_Searching.Controls.Add(Me.CheckBox5)
        Me.PnlDfSearch_Searching.Controls.Add(Me.TextBox1)
        Me.PnlDfSearch_Searching.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch_Searching.Location = New System.Drawing.Point(0, 0)
        Me.PnlDfSearch_Searching.Name = "PnlDfSearch_Searching"
        Me.PnlDfSearch_Searching.Size = New System.Drawing.Size(739, 57)
        Me.PnlDfSearch_Searching.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Search"
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(111, 4)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(205, 21)
        Me.ComboBox4.TabIndex = 3
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(24, 6)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox5.TabIndex = 2
        Me.CheckBox5.Text = "Department"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(111, 29)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(205, 20)
        Me.TextBox1.TabIndex = 1
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Controls.Add(Me.Label18)
        Me.PnlDataFooter.Controls.Add(Me.Label16)
        Me.PnlDataFooter.Controls.Add(Me.Label17)
        Me.PnlDataFooter.Controls.Add(Me.Label14)
        Me.PnlDataFooter.Controls.Add(Me.Label15)
        Me.PnlDataFooter.Controls.Add(Me.Label12)
        Me.PnlDataFooter.Controls.Add(Me.Label13)
        Me.PnlDataFooter.Controls.Add(Me.Label10)
        Me.PnlDataFooter.Controls.Add(Me.Label11)
        Me.PnlDataFooter.Controls.Add(Me.Label8)
        Me.PnlDataFooter.Controls.Add(Me.Label9)
        Me.PnlDataFooter.Controls.Add(Me.Label6)
        Me.PnlDataFooter.Controls.Add(Me.Label7)
        Me.PnlDataFooter.Controls.Add(Me.Label4)
        Me.PnlDataFooter.Controls.Add(Me.Label5)
        Me.PnlDataFooter.Controls.Add(Me.Label3)
        Me.PnlDataFooter.Controls.Add(Me.Label2)
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 433)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(739, 58)
        Me.PnlDataFooter.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 11)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "0 Data"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(124, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(177, 13)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "GOOD REQUEST DOC RECEIVED"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Thistle
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Location = New System.Drawing.Point(103, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(18, 20)
        Me.Label17.TabIndex = 30
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(596, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "BPJ"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Lavender
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Location = New System.Drawing.Point(575, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(18, 20)
        Me.Label15.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(596, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(129, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "ORDER DOC RECEIVED"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(575, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(18, 20)
        Me.Label13.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(511, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "ORDER"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Gainsboro
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Location = New System.Drawing.Point(490, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(18, 20)
        Me.Label11.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(511, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "BMA"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Aquamarine
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Location = New System.Drawing.Point(490, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 20)
        Me.Label9.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(339, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "PROCUREMENT"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Pink
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Location = New System.Drawing.Point(318, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 20)
        Me.Label7.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(339, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "RELATED DEPARTMENT"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Bisque
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(318, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 20)
        Me.Label5.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(124, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "GOOD REQUEST"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Turquoise
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(103, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 20)
        Me.Label2.TabIndex = 16
        '
        'uiTrackingGoodRequestToBpj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uiTrackingGoodRequestToBpj"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.ftabMain_Data.ResumeLayout(False)
        Me.PnlDataMaster.ResumeLayout(False)
        Me.PnlDfMain_Searching.ResumeLayout(False)
        CType(Me.DgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfSearch_Searching.ResumeLayout(False)
        Me.PnlDfSearch_Searching.PerformLayout()
        Me.PnlDataFooter.ResumeLayout(False)
        Me.PnlDataFooter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ftabMain As FlatTabControl.FlatTabControl
    Friend WithEvents ftabMain_List As System.Windows.Forms.TabPage
    Friend WithEvents ftabMain_Data As System.Windows.Forms.TabPage
    Friend WithEvents PnlDataMaster As System.Windows.Forms.Panel
    Friend WithEvents PnlDataFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearch As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_rekap As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearch_Rekap As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchStrukturunit_ID As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchStrukturunit_ID As System.Windows.Forms.CheckBox
    Friend WithEvents obj_tracking_search As System.Windows.Forms.TextBox
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents RvSearch As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents PnlDfSearch_Searching As System.Windows.Forms.Panel
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PnlDfMain_Searching As System.Windows.Forms.Panel
    Friend WithEvents DgvSearch As System.Windows.Forms.DataGridView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label

End Class
