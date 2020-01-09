<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAssetCategory_select
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PnlFooter = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.obj_srcAssetCategory = New System.Windows.Forms.TextBox()
        Me.DgvAssetConsumable = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnlFooter.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        CType(Me.DgvAssetConsumable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlFooter
        '
        Me.PnlFooter.Controls.Add(Me.btnOK)
        Me.PnlFooter.Controls.Add(Me.btnCancel)
        Me.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlFooter.Location = New System.Drawing.Point(0, 385)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(323, 29)
        Me.PnlFooter.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(160, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(241, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'PnlBody
        '
        Me.PnlBody.Controls.Add(Me.Label1)
        Me.PnlBody.Controls.Add(Me.obj_srcAssetCategory)
        Me.PnlBody.Controls.Add(Me.DgvAssetConsumable)
        Me.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBody.Location = New System.Drawing.Point(0, 0)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Padding = New System.Windows.Forms.Padding(3)
        Me.PnlBody.Size = New System.Drawing.Size(323, 385)
        Me.PnlBody.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search"
        '
        'obj_srcAssetCategory
        '
        Me.obj_srcAssetCategory.Location = New System.Drawing.Point(70, 12)
        Me.obj_srcAssetCategory.Name = "obj_srcAssetCategory"
        Me.obj_srcAssetCategory.Size = New System.Drawing.Size(247, 20)
        Me.obj_srcAssetCategory.TabIndex = 0
        '
        'DgvAssetConsumable
        '
        Me.DgvAssetConsumable.AllowUserToAddRows = False
        Me.DgvAssetConsumable.AllowUserToDeleteRows = False
        Me.DgvAssetConsumable.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DgvAssetConsumable.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvAssetConsumable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvAssetConsumable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAssetConsumable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDescription})
        Me.DgvAssetConsumable.Location = New System.Drawing.Point(3, 49)
        Me.DgvAssetConsumable.MultiSelect = False
        Me.DgvAssetConsumable.Name = "DgvAssetConsumable"
        Me.DgvAssetConsumable.ReadOnly = True
        Me.DgvAssetConsumable.RowHeadersVisible = False
        Me.DgvAssetConsumable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAssetConsumable.Size = New System.Drawing.Size(317, 333)
        Me.DgvAssetConsumable.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "kategoriasset_id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Category Asset"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDescription.DataPropertyName = "kategoriasset_id"
        Me.colDescription.HeaderText = "Asset Category "
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        '
        'dlgAssetCategory_select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 414)
        Me.Controls.Add(Me.PnlBody)
        Me.Controls.Add(Me.PnlFooter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAssetCategory_select"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlBody.ResumeLayout(False)
        Me.PnlBody.PerformLayout()
        CType(Me.DgvAssetConsumable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlFooter As System.Windows.Forms.Panel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents DgvAssetConsumable As System.Windows.Forms.DataGridView
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents obj_srcAssetCategory As System.Windows.Forms.TextBox

End Class
