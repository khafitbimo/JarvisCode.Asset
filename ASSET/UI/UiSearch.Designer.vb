<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UiSearch
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
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.ObjSearchTanggalAwal = New System.Windows.Forms.MaskedTextBox
        Me.ObjSearchTanggalAkhir = New System.Windows.Forms.MaskedTextBox
        Me.chkSearchTanggalAkhir = New System.Windows.Forms.CheckBox
        Me.chkSearchTanggalAwal = New System.Windows.Forms.CheckBox
        Me.cboSearchType = New System.Windows.Forms.ComboBox
        Me.chkSearchType = New System.Windows.Forms.CheckBox
        Me.cboSearchKategori = New System.Windows.Forms.ComboBox
        Me.chkSearchKategori = New System.Windows.Forms.CheckBox
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.PnlDfMain = New System.Windows.Forms.Panel
        Me.DgvSearch = New System.Windows.Forms.DataGridView
        Me.PnlDfSearch.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.BackColor = System.Drawing.Color.SkyBlue
        Me.PnlDfSearch.Controls.Add(Me.ObjSearchTanggalAwal)
        Me.PnlDfSearch.Controls.Add(Me.ObjSearchTanggalAkhir)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchTanggalAkhir)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchTanggalAwal)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchType)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchType)
        Me.PnlDfSearch.Controls.Add(Me.cboSearchKategori)
        Me.PnlDfSearch.Controls.Add(Me.chkSearchKategori)
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(0, 25)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(753, 72)
        Me.PnlDfSearch.TabIndex = 2
        '
        'ObjSearchTanggalAwal
        '
        Me.ObjSearchTanggalAwal.Enabled = False
        Me.ObjSearchTanggalAwal.Location = New System.Drawing.Point(533, 10)
        Me.ObjSearchTanggalAwal.Mask = "00/00/0000"
        Me.ObjSearchTanggalAwal.Name = "ObjSearchTanggalAwal"
        Me.ObjSearchTanggalAwal.Size = New System.Drawing.Size(75, 20)
        Me.ObjSearchTanggalAwal.TabIndex = 5
        '
        'ObjSearchTanggalAkhir
        '
        Me.ObjSearchTanggalAkhir.Enabled = False
        Me.ObjSearchTanggalAkhir.Location = New System.Drawing.Point(533, 37)
        Me.ObjSearchTanggalAkhir.Mask = "00/00/0000"
        Me.ObjSearchTanggalAkhir.Name = "ObjSearchTanggalAkhir"
        Me.ObjSearchTanggalAkhir.Size = New System.Drawing.Size(75, 20)
        Me.ObjSearchTanggalAkhir.TabIndex = 7
        '
        'chkSearchTanggalAkhir
        '
        Me.chkSearchTanggalAkhir.AutoSize = True
        Me.chkSearchTanggalAkhir.ForeColor = System.Drawing.Color.Black
        Me.chkSearchTanggalAkhir.Location = New System.Drawing.Point(453, 39)
        Me.chkSearchTanggalAkhir.Name = "chkSearchTanggalAkhir"
        Me.chkSearchTanggalAkhir.Size = New System.Drawing.Size(71, 17)
        Me.chkSearchTanggalAkhir.TabIndex = 6
        Me.chkSearchTanggalAkhir.Text = "End Date"
        Me.chkSearchTanggalAkhir.UseVisualStyleBackColor = True
        '
        'chkSearchTanggalAwal
        '
        Me.chkSearchTanggalAwal.AutoSize = True
        Me.chkSearchTanggalAwal.ForeColor = System.Drawing.Color.Black
        Me.chkSearchTanggalAwal.Location = New System.Drawing.Point(453, 13)
        Me.chkSearchTanggalAwal.Name = "chkSearchTanggalAwal"
        Me.chkSearchTanggalAwal.Size = New System.Drawing.Size(74, 17)
        Me.chkSearchTanggalAwal.TabIndex = 4
        Me.chkSearchTanggalAwal.Text = "Start Date"
        Me.chkSearchTanggalAwal.UseVisualStyleBackColor = True
        '
        'cboSearchType
        '
        Me.cboSearchType.Enabled = False
        Me.cboSearchType.FormattingEnabled = True
        Me.cboSearchType.Location = New System.Drawing.Point(153, 37)
        Me.cboSearchType.Name = "cboSearchType"
        Me.cboSearchType.Size = New System.Drawing.Size(205, 21)
        Me.cboSearchType.TabIndex = 3
        '
        'chkSearchType
        '
        Me.chkSearchType.AutoSize = True
        Me.chkSearchType.Location = New System.Drawing.Point(66, 39)
        Me.chkSearchType.Name = "chkSearchType"
        Me.chkSearchType.Size = New System.Drawing.Size(50, 17)
        Me.chkSearchType.TabIndex = 2
        Me.chkSearchType.Text = "Type"
        Me.chkSearchType.UseVisualStyleBackColor = True
        '
        'cboSearchKategori
        '
        Me.cboSearchKategori.Enabled = False
        Me.cboSearchKategori.FormattingEnabled = True
        Me.cboSearchKategori.Location = New System.Drawing.Point(153, 10)
        Me.cboSearchKategori.Name = "cboSearchKategori"
        Me.cboSearchKategori.Size = New System.Drawing.Size(205, 21)
        Me.cboSearchKategori.TabIndex = 1
        '
        'chkSearchKategori
        '
        Me.chkSearchKategori.AutoSize = True
        Me.chkSearchKategori.Location = New System.Drawing.Point(66, 12)
        Me.chkSearchKategori.Name = "chkSearchKategori"
        Me.chkSearchKategori.Size = New System.Drawing.Size(68, 17)
        Me.chkSearchKategori.TabIndex = 0
        Me.chkSearchKategori.Text = "Category"
        Me.chkSearchKategori.UseVisualStyleBackColor = True
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(0, 515)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(753, 33)
        Me.PnlDfFooter.TabIndex = 4
        '
        'PnlDfMain
        '
        Me.PnlDfMain.Controls.Add(Me.DgvSearch)
        Me.PnlDfMain.Location = New System.Drawing.Point(24, 126)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 214)
        Me.PnlDfMain.TabIndex = 6
        '
        'DgvSearch
        '
        Me.DgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvSearch.Location = New System.Drawing.Point(0, 0)
        Me.DgvSearch.MultiSelect = False
        Me.DgvSearch.Name = "DgvSearch"
        Me.DgvSearch.Size = New System.Drawing.Size(704, 214)
        Me.DgvSearch.TabIndex = 6
        '
        'UiSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.PnlDfMain)
        Me.Controls.Add(Me.PnlDfFooter)
        Me.Controls.Add(Me.PnlDfSearch)
        Me.Name = "UiSearch"
        Me.Controls.SetChildIndex(Me.PnlDfSearch, 0)
        Me.Controls.SetChildIndex(Me.PnlDfFooter, 0)
        Me.Controls.SetChildIndex(Me.PnlDfMain, 0)
        Me.PnlDfSearch.ResumeLayout(False)
        Me.PnlDfSearch.PerformLayout()
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PnlDfSearch As System.Windows.Forms.Panel
    Friend WithEvents cboSearchKategori As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchKategori As System.Windows.Forms.CheckBox
    Friend WithEvents PnlDfFooter As System.Windows.Forms.Panel
    Friend WithEvents chkSearchType As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchType As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchTanggalAwal As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchTanggalAkhir As System.Windows.Forms.CheckBox
    Friend WithEvents ObjSearchTanggalAkhir As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ObjSearchTanggalAwal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents PnlDfMain As System.Windows.Forms.Panel
    Friend WithEvents DgvSearch As System.Windows.Forms.DataGridView

End Class
