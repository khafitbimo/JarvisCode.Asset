<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgKondisiDepresiasi
    Inherits System.Windows.Forms.Form

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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.cboSearchkategori = New System.Windows.Forms.ComboBox
        Me.chkSearchCategory = New System.Windows.Forms.CheckBox
        Me.chkSearchTahun = New System.Windows.Forms.CheckBox
        Me.chkSearchBulan = New System.Windows.Forms.CheckBox
        Me.cboSearchtahun = New System.Windows.Forms.NumericUpDown
        Me.cboSearchbulan = New System.Windows.Forms.NumericUpDown
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.chkPrint_RekapitulasiMonth = New System.Windows.Forms.CheckBox
        Me.chkPrint_Rekapitulasi = New System.Windows.Forms.CheckBox
        Me.cboSearchLocation = New System.Windows.Forms.ComboBox
        Me.chkSearchLocation = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.cboSearchtahun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSearchbulan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(306, 183)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'cboSearchkategori
        '
        Me.cboSearchkategori.FormattingEnabled = True
        Me.cboSearchkategori.Location = New System.Drawing.Point(99, 55)
        Me.cboSearchkategori.Name = "cboSearchkategori"
        Me.cboSearchkategori.Size = New System.Drawing.Size(353, 21)
        Me.cboSearchkategori.TabIndex = 25
        '
        'chkSearchCategory
        '
        Me.chkSearchCategory.AutoSize = True
        Me.chkSearchCategory.Location = New System.Drawing.Point(12, 57)
        Me.chkSearchCategory.Name = "chkSearchCategory"
        Me.chkSearchCategory.Size = New System.Drawing.Size(68, 17)
        Me.chkSearchCategory.TabIndex = 24
        Me.chkSearchCategory.Text = "Category"
        Me.chkSearchCategory.UseVisualStyleBackColor = True
        '
        'chkSearchTahun
        '
        Me.chkSearchTahun.AutoSize = True
        Me.chkSearchTahun.Checked = True
        Me.chkSearchTahun.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchTahun.Enabled = False
        Me.chkSearchTahun.Location = New System.Drawing.Point(12, 33)
        Me.chkSearchTahun.Name = "chkSearchTahun"
        Me.chkSearchTahun.Size = New System.Drawing.Size(48, 17)
        Me.chkSearchTahun.TabIndex = 23
        Me.chkSearchTahun.Text = "Year"
        Me.chkSearchTahun.UseVisualStyleBackColor = True
        '
        'chkSearchBulan
        '
        Me.chkSearchBulan.AutoSize = True
        Me.chkSearchBulan.Checked = True
        Me.chkSearchBulan.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchBulan.Enabled = False
        Me.chkSearchBulan.Location = New System.Drawing.Point(12, 12)
        Me.chkSearchBulan.Name = "chkSearchBulan"
        Me.chkSearchBulan.Size = New System.Drawing.Size(56, 17)
        Me.chkSearchBulan.TabIndex = 22
        Me.chkSearchBulan.Text = "Month"
        Me.chkSearchBulan.UseVisualStyleBackColor = True
        '
        'cboSearchtahun
        '
        Me.cboSearchtahun.Location = New System.Drawing.Point(99, 32)
        Me.cboSearchtahun.Maximum = New Decimal(New Integer() {2200, 0, 0, 0})
        Me.cboSearchtahun.Minimum = New Decimal(New Integer() {1998, 0, 0, 0})
        Me.cboSearchtahun.Name = "cboSearchtahun"
        Me.cboSearchtahun.Size = New System.Drawing.Size(54, 20)
        Me.cboSearchtahun.TabIndex = 21
        Me.cboSearchtahun.Value = New Decimal(New Integer() {2008, 0, 0, 0})
        '
        'cboSearchbulan
        '
        Me.cboSearchbulan.Location = New System.Drawing.Point(99, 9)
        Me.cboSearchbulan.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.cboSearchbulan.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.cboSearchbulan.Name = "cboSearchbulan"
        Me.cboSearchbulan.Size = New System.Drawing.Size(54, 20)
        Me.cboSearchbulan.TabIndex = 20
        Me.cboSearchbulan.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.chkPrint_RekapitulasiMonth)
        Me.Panel1.Controls.Add(Me.chkPrint_Rekapitulasi)
        Me.Panel1.Location = New System.Drawing.Point(0, 119)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(469, 50)
        Me.Panel1.TabIndex = 27
        '
        'chkPrint_RekapitulasiMonth
        '
        Me.chkPrint_RekapitulasiMonth.AutoSize = True
        Me.chkPrint_RekapitulasiMonth.Location = New System.Drawing.Point(12, 23)
        Me.chkPrint_RekapitulasiMonth.Name = "chkPrint_RekapitulasiMonth"
        Me.chkPrint_RekapitulasiMonth.Size = New System.Drawing.Size(149, 17)
        Me.chkPrint_RekapitulasiMonth.TabIndex = 28
        Me.chkPrint_RekapitulasiMonth.Text = "Print Rekapitulasi / Month"
        Me.chkPrint_RekapitulasiMonth.UseVisualStyleBackColor = True
        '
        'chkPrint_Rekapitulasi
        '
        Me.chkPrint_Rekapitulasi.AutoSize = True
        Me.chkPrint_Rekapitulasi.Location = New System.Drawing.Point(12, 4)
        Me.chkPrint_Rekapitulasi.Name = "chkPrint_Rekapitulasi"
        Me.chkPrint_Rekapitulasi.Size = New System.Drawing.Size(122, 17)
        Me.chkPrint_Rekapitulasi.TabIndex = 27
        Me.chkPrint_Rekapitulasi.Text = "Print Rekapitulasi All"
        Me.chkPrint_Rekapitulasi.UseVisualStyleBackColor = True
        '
        'cboSearchLocation
        '
        Me.cboSearchLocation.FormattingEnabled = True
        Me.cboSearchLocation.Location = New System.Drawing.Point(99, 79)
        Me.cboSearchLocation.Name = "cboSearchLocation"
        Me.cboSearchLocation.Size = New System.Drawing.Size(353, 21)
        Me.cboSearchLocation.TabIndex = 29
        '
        'chkSearchLocation
        '
        Me.chkSearchLocation.AutoSize = True
        Me.chkSearchLocation.Location = New System.Drawing.Point(12, 81)
        Me.chkSearchLocation.Name = "chkSearchLocation"
        Me.chkSearchLocation.Size = New System.Drawing.Size(67, 17)
        Me.chkSearchLocation.TabIndex = 28
        Me.chkSearchLocation.Text = "Location"
        Me.chkSearchLocation.UseVisualStyleBackColor = True
        '
        'dlgKondisiDepresiasi
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(459, 217)
        Me.Controls.Add(Me.cboSearchLocation)
        Me.Controls.Add(Me.chkSearchLocation)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cboSearchkategori)
        Me.Controls.Add(Me.chkSearchCategory)
        Me.Controls.Add(Me.chkSearchTahun)
        Me.Controls.Add(Me.chkSearchBulan)
        Me.Controls.Add(Me.cboSearchtahun)
        Me.Controls.Add(Me.cboSearchbulan)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgKondisiDepresiasi"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlgKondisiDepresiasi"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.cboSearchtahun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSearchbulan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cboSearchkategori As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchCategory As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchTahun As System.Windows.Forms.CheckBox
    Friend WithEvents chkSearchBulan As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchtahun As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboSearchbulan As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkPrint_Rekapitulasi As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrint_RekapitulasiMonth As System.Windows.Forms.CheckBox
    Friend WithEvents cboSearchLocation As System.Windows.Forms.ComboBox
    Friend WithEvents chkSearchLocation As System.Windows.Forms.CheckBox

End Class
