<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UiMstwarna
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
        Me.DgvMstWarna = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Objsearch = New System.Windows.Forms.TextBox
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.obj_Warna_id = New System.Windows.Forms.TextBox
        Me.lbl_Warna_id = New System.Windows.Forms.Label
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvMstWarna, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PnlDfMain.Controls.Add(Me.DgvMstWarna)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 131)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 327)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvMstWarna
        '
        Me.DgvMstWarna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMstWarna.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvMstWarna.Location = New System.Drawing.Point(0, 0)
        Me.DgvMstWarna.Name = "DgvMstWarna"
        Me.DgvMstWarna.Size = New System.Drawing.Size(704, 327)
        Me.DgvMstWarna.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 464)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 21)
        Me.PnlDfFooter.TabIndex = 2
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.Controls.Add(Me.Label1)
        Me.PnlDfSearch.Controls.Add(Me.Objsearch)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 122)
        Me.PnlDfSearch.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Warna"
        '
        'Objsearch
        '
        Me.Objsearch.Location = New System.Drawing.Point(73, 31)
        Me.Objsearch.Name = "Objsearch"
        Me.Objsearch.Size = New System.Drawing.Size(195, 20)
        Me.Objsearch.TabIndex = 0
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.Ivory
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
        Me.PnlDataMaster.Controls.Add(Me.obj_Warna_id)
        Me.PnlDataMaster.Controls.Add(Me.lbl_Warna_id)
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 401)
        Me.PnlDataMaster.TabIndex = 0
        '
        'obj_Warna_id
        '
        Me.obj_Warna_id.Location = New System.Drawing.Point(104, 65)
        Me.obj_Warna_id.Name = "obj_Warna_id"
        Me.obj_Warna_id.Size = New System.Drawing.Size(240, 20)
        Me.obj_Warna_id.TabIndex = 1
        '
        'lbl_Warna_id
        '
        Me.lbl_Warna_id.AutoSize = True
        Me.lbl_Warna_id.Location = New System.Drawing.Point(29, 68)
        Me.lbl_Warna_id.Name = "lbl_Warna_id"
        Me.lbl_Warna_id.Size = New System.Drawing.Size(53, 13)
        Me.lbl_Warna_id.TabIndex = 0
        Me.lbl_Warna_id.Text = "Warna_id"
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 404)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 81)
        Me.PnlDataFooter.TabIndex = 2
        '
        'UiMstwarna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "UiMstwarna"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvMstWarna, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DgvMstWarna As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Warna_id As System.Windows.Forms.Label
    Friend WithEvents obj_Warna_id As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Objsearch As System.Windows.Forms.TextBox

End Class

