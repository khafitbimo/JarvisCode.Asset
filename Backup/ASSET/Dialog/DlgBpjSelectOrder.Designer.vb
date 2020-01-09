<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgBpjSelectOrder
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
        Me.DgvBpjSelectOrder = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rb_OrderID_search = New System.Windows.Forms.RadioButton
        Me.rb_Status_bpj = New System.Windows.Forms.RadioButton
        Me.cmb_status = New System.Windows.Forms.ComboBox
        Me.obj_ordrID_Search = New System.Windows.Forms.TextBox
        Me.chk_canceled = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DgvBpjSelectOrder, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(556, 323)
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
        'DgvBpjSelectOrder
        '
        Me.DgvBpjSelectOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvBpjSelectOrder.Location = New System.Drawing.Point(13, 68)
        Me.DgvBpjSelectOrder.MultiSelect = False
        Me.DgvBpjSelectOrder.Name = "DgvBpjSelectOrder"
        Me.DgvBpjSelectOrder.Size = New System.Drawing.Size(689, 249)
        Me.DgvBpjSelectOrder.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chk_canceled)
        Me.Panel1.Controls.Add(Me.rb_OrderID_search)
        Me.Panel1.Controls.Add(Me.rb_Status_bpj)
        Me.Panel1.Controls.Add(Me.cmb_status)
        Me.Panel1.Controls.Add(Me.obj_ordrID_Search)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(714, 62)
        Me.Panel1.TabIndex = 21
        '
        'rb_OrderID_search
        '
        Me.rb_OrderID_search.AutoSize = True
        Me.rb_OrderID_search.Checked = True
        Me.rb_OrderID_search.Location = New System.Drawing.Point(13, 10)
        Me.rb_OrderID_search.Name = "rb_OrderID_search"
        Me.rb_OrderID_search.Size = New System.Drawing.Size(71, 17)
        Me.rb_OrderID_search.TabIndex = 23
        Me.rb_OrderID_search.TabStop = True
        Me.rb_OrderID_search.Text = "Order No."
        Me.rb_OrderID_search.UseVisualStyleBackColor = True
        '
        'rb_Status_bpj
        '
        Me.rb_Status_bpj.AutoSize = True
        Me.rb_Status_bpj.Location = New System.Drawing.Point(13, 36)
        Me.rb_Status_bpj.Name = "rb_Status_bpj"
        Me.rb_Status_bpj.Size = New System.Drawing.Size(77, 17)
        Me.rb_Status_bpj.TabIndex = 22
        Me.rb_Status_bpj.Text = "BPJ Status"
        Me.rb_Status_bpj.UseVisualStyleBackColor = True
        '
        'cmb_status
        '
        Me.cmb_status.Items.AddRange(New Object() {"-- PILIH --", "ALL", "UnProses", "Approved User", "InComplete", "Complete"})
        Me.cmb_status.Location = New System.Drawing.Point(91, 35)
        Me.cmb_status.Name = "cmb_status"
        Me.cmb_status.Size = New System.Drawing.Size(160, 21)
        Me.cmb_status.TabIndex = 20
        '
        'obj_ordrID_Search
        '
        Me.obj_ordrID_Search.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.obj_ordrID_Search.Location = New System.Drawing.Point(91, 9)
        Me.obj_ordrID_Search.Name = "obj_ordrID_Search"
        Me.obj_ordrID_Search.Size = New System.Drawing.Size(160, 20)
        Me.obj_ordrID_Search.TabIndex = 18
        '
        'chk_canceled
        '
        Me.chk_canceled.AutoSize = True
        Me.chk_canceled.Location = New System.Drawing.Point(273, 11)
        Me.chk_canceled.Name = "chk_canceled"
        Me.chk_canceled.Size = New System.Drawing.Size(100, 17)
        Me.chk_canceled.TabIndex = 24
        Me.chk_canceled.Text = "Order Canceled"
        Me.chk_canceled.UseVisualStyleBackColor = True
        '
        'DlgBpjSelectOrder
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(714, 356)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DgvBpjSelectOrder)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgBpjSelectOrder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Order Number"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DgvBpjSelectOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents DgvBpjSelectOrder As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents obj_ordrID_Search As System.Windows.Forms.TextBox
    Friend WithEvents cmb_status As System.Windows.Forms.ComboBox
    Friend WithEvents rb_OrderID_search As System.Windows.Forms.RadioButton
    Friend WithEvents rb_Status_bpj As System.Windows.Forms.RadioButton
    Friend WithEvents chk_canceled As System.Windows.Forms.CheckBox

End Class
