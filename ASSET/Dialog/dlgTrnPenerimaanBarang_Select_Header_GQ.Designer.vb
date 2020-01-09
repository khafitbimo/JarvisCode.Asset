<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgTrnPenerimaanBarang_Select_Header_GQ
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.DgvTrnRequest = New System.Windows.Forms.DataGridView()
        Me.col_channel_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.request_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.request_descr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.request_userpic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.show_title = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.budget_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.obj_request_id = New System.Windows.Forms.TextBox()
        Me.chk_request_id = New System.Windows.Forms.CheckBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvTrnRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(769, 387)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 21)
        Me.btnSelect.TabIndex = 13
        Me.btnSelect.Text = "Ok"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(850, 387)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(836, 98)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(89, 24)
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = "Load"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'DgvTrnRequest
        '
        Me.DgvTrnRequest.AllowUserToAddRows = False
        Me.DgvTrnRequest.AllowUserToDeleteRows = False
        Me.DgvTrnRequest.BackgroundColor = System.Drawing.Color.Lavender
        Me.DgvTrnRequest.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnRequest.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvTrnRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnRequest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_channel_id, Me.request_id, Me.request_descr, Me.request_userpic, Me.show_title, Me.budget_name})
        Me.DgvTrnRequest.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvTrnRequest.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvTrnRequest.GridColor = System.Drawing.Color.Moccasin
        Me.DgvTrnRequest.Location = New System.Drawing.Point(5, 53)
        Me.DgvTrnRequest.MultiSelect = False
        Me.DgvTrnRequest.Name = "DgvTrnRequest"
        Me.DgvTrnRequest.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkViolet
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvTrnRequest.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvTrnRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvTrnRequest.Size = New System.Drawing.Size(920, 313)
        Me.DgvTrnRequest.TabIndex = 26
        '
        'col_channel_id
        '
        Me.col_channel_id.DataPropertyName = "channel_id"
        Me.col_channel_id.HeaderText = "channel_id"
        Me.col_channel_id.Name = "col_channel_id"
        Me.col_channel_id.ReadOnly = True
        Me.col_channel_id.Visible = False
        '
        'request_id
        '
        Me.request_id.DataPropertyName = "request_id"
        Me.request_id.HeaderText = "ID"
        Me.request_id.Name = "request_id"
        Me.request_id.ReadOnly = True
        Me.request_id.Width = 120
        '
        'request_descr
        '
        Me.request_descr.DataPropertyName = "request_descr"
        Me.request_descr.HeaderText = "Desc."
        Me.request_descr.Name = "request_descr"
        Me.request_descr.ReadOnly = True
        Me.request_descr.Width = 250
        '
        'request_userpic
        '
        Me.request_userpic.DataPropertyName = "request_userpic"
        Me.request_userpic.HeaderText = "PIC"
        Me.request_userpic.Name = "request_userpic"
        Me.request_userpic.ReadOnly = True
        Me.request_userpic.Width = 150
        '
        'show_title
        '
        Me.show_title.DataPropertyName = "show_title"
        Me.show_title.HeaderText = "Programme"
        Me.show_title.Name = "show_title"
        Me.show_title.ReadOnly = True
        Me.show_title.Width = 200
        '
        'budget_name
        '
        Me.budget_name.DataPropertyName = "budget_name"
        Me.budget_name.HeaderText = "Budget"
        Me.budget_name.Name = "budget_name"
        Me.budget_name.ReadOnly = True
        Me.budget_name.Width = 200
        '
        'obj_request_id
        '
        Me.obj_request_id.Enabled = False
        Me.obj_request_id.Location = New System.Drawing.Point(121, 12)
        Me.obj_request_id.Name = "obj_request_id"
        Me.obj_request_id.Size = New System.Drawing.Size(178, 20)
        Me.obj_request_id.TabIndex = 27
        '
        'chk_request_id
        '
        Me.chk_request_id.AutoSize = True
        Me.chk_request_id.Location = New System.Drawing.Point(26, 14)
        Me.chk_request_id.Name = "chk_request_id"
        Me.chk_request_id.Size = New System.Drawing.Size(80, 17)
        Me.chk_request_id.TabIndex = 28
        Me.chk_request_id.Text = "Request ID"
        Me.chk_request_id.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "request_id"
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "Request ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "requestdetil_descr"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "request_userpic"
        Me.DataGridViewTextBoxColumn3.HeaderText = "User PIC"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "show_title"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Program"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "budget_name"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Budget Name"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 230
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "budget_name"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Budget"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 200
        '
        'dlgTrnPenerimaanBarang_Select_Header_GQ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(937, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.chk_request_id)
        Me.Controls.Add(Me.obj_request_id)
        Me.Controls.Add(Me.DgvTrnRequest)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSelect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgTrnPenerimaanBarang_Select_Header_GQ"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Transaksi Penerimaan Barang - List GQ"
        CType(Me.DgvTrnRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DgvTrnRequest As System.Windows.Forms.DataGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents obj_request_id As System.Windows.Forms.TextBox
    Friend WithEvents chk_request_id As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_channel_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents request_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents request_descr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents request_userpic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents show_title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents budget_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
