<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgMstAssetConsumable
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
        Me.PnlFooter = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.PnlBody = New System.Windows.Forms.Panel()
        Me.DgvAssetConsumable = New System.Windows.Forms.DataGridView()
        Me.colAssetSerial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.obj_itemdesciption = New System.Windows.Forms.TextBox()
        Me.obj_assetserial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnlFooter.SuspendLayout()
        Me.PnlBody.SuspendLayout()
        CType(Me.DgvAssetConsumable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlFooter
        '
        Me.PnlFooter.Controls.Add(Me.btnOK)
        Me.PnlFooter.Controls.Add(Me.btnCancel)
        Me.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlFooter.Location = New System.Drawing.Point(0, 440)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(445, 29)
        Me.PnlFooter.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(282, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(363, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'PnlBody
        '
        Me.PnlBody.Controls.Add(Me.DgvAssetConsumable)
        Me.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBody.Location = New System.Drawing.Point(0, 66)
        Me.PnlBody.Name = "PnlBody"
        Me.PnlBody.Padding = New System.Windows.Forms.Padding(3)
        Me.PnlBody.Size = New System.Drawing.Size(445, 374)
        Me.PnlBody.TabIndex = 1
        '
        'DgvAssetConsumable
        '
        Me.DgvAssetConsumable.AllowUserToAddRows = False
        Me.DgvAssetConsumable.AllowUserToDeleteRows = False
        Me.DgvAssetConsumable.AllowUserToResizeRows = False
        Me.DgvAssetConsumable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvAssetConsumable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAssetConsumable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAssetSerial, Me.colDescription})
        Me.DgvAssetConsumable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvAssetConsumable.Location = New System.Drawing.Point(3, 3)
        Me.DgvAssetConsumable.MultiSelect = False
        Me.DgvAssetConsumable.Name = "DgvAssetConsumable"
        Me.DgvAssetConsumable.ReadOnly = True
        Me.DgvAssetConsumable.RowHeadersVisible = False
        Me.DgvAssetConsumable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAssetConsumable.Size = New System.Drawing.Size(439, 368)
        Me.DgvAssetConsumable.TabIndex = 0
        '
        'colAssetSerial
        '
        Me.colAssetSerial.DataPropertyName = "asset_serial"
        Me.colAssetSerial.HeaderText = "Serial Number"
        Me.colAssetSerial.Name = "colAssetSerial"
        Me.colAssetSerial.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.DataPropertyName = "asset_description"
        Me.colDescription.HeaderText = "Item Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        Me.colDescription.Width = 300
        '
        'PnlHeader
        '
        Me.PnlHeader.Controls.Add(Me.btnLoad)
        Me.PnlHeader.Controls.Add(Me.obj_itemdesciption)
        Me.PnlHeader.Controls.Add(Me.obj_assetserial)
        Me.PnlHeader.Controls.Add(Me.Label2)
        Me.PnlHeader.Controls.Add(Me.Label1)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(445, 66)
        Me.PnlHeader.TabIndex = 0
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(358, 34)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 4
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'obj_itemdesciption
        '
        Me.obj_itemdesciption.Location = New System.Drawing.Point(101, 36)
        Me.obj_itemdesciption.Name = "obj_itemdesciption"
        Me.obj_itemdesciption.Size = New System.Drawing.Size(251, 20)
        Me.obj_itemdesciption.TabIndex = 3
        '
        'obj_assetserial
        '
        Me.obj_assetserial.Location = New System.Drawing.Point(101, 10)
        Me.obj_assetserial.Name = "obj_assetserial"
        Me.obj_assetserial.Size = New System.Drawing.Size(116, 20)
        Me.obj_assetserial.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Item Description"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Serial Number"
        '
        'DlgMstAssetConsumable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 469)
        Me.Controls.Add(Me.PnlBody)
        Me.Controls.Add(Me.PnlHeader)
        Me.Controls.Add(Me.PnlFooter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgMstAssetConsumable"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Asset Consumable"
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlBody.ResumeLayout(False)
        CType(Me.DgvAssetConsumable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlFooter As System.Windows.Forms.Panel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents PnlBody As System.Windows.Forms.Panel
    Friend WithEvents PnlHeader As System.Windows.Forms.Panel
    Friend WithEvents DgvAssetConsumable As System.Windows.Forms.DataGridView
    Friend WithEvents obj_itemdesciption As System.Windows.Forms.TextBox
    Friend WithEvents obj_assetserial As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents colAssetSerial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
