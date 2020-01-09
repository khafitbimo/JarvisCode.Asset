<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgDepresiasiNew
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.obj_periode_id = New DevExpress.XtraEditors.LookUpEdit()
        Me.obj_start = New DevExpress.XtraEditors.TextEdit()
        Me.obj_end = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_bookdate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_kategoriasset_depre = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.obj_periode_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_start.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_end.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_bookdate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_bookdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_kategoriasset_depre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(34, 33)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Periode"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(34, 59)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Days"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(126, 145)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(207, 145)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        '
        'obj_periode_id
        '
        Me.obj_periode_id.Location = New System.Drawing.Point(89, 29)
        Me.obj_periode_id.Name = "obj_periode_id"
        Me.obj_periode_id.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.obj_periode_id.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("periode_id", "ID"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("periode_name", "Name")})
        Me.obj_periode_id.Properties.NullText = ""
        Me.obj_periode_id.Size = New System.Drawing.Size(74, 20)
        Me.obj_periode_id.TabIndex = 8
        '
        'obj_start
        '
        Me.obj_start.Location = New System.Drawing.Point(89, 55)
        Me.obj_start.Name = "obj_start"
        Me.obj_start.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_start.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.obj_start.Properties.ReadOnly = True
        Me.obj_start.Size = New System.Drawing.Size(29, 20)
        Me.obj_start.TabIndex = 9
        '
        'obj_end
        '
        Me.obj_end.Location = New System.Drawing.Point(134, 55)
        Me.obj_end.Name = "obj_end"
        Me.obj_end.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_end.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.obj_end.Properties.ReadOnly = True
        Me.obj_end.Size = New System.Drawing.Size(29, 20)
        Me.obj_end.TabIndex = 10
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(124, 59)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl3.TabIndex = 11
        Me.LabelControl3.Text = "-"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(34, 85)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl4.TabIndex = 12
        Me.LabelControl4.Text = "Book Date"
        '
        'obj_bookdate
        '
        Me.obj_bookdate.EditValue = Nothing
        Me.obj_bookdate.Location = New System.Drawing.Point(89, 81)
        Me.obj_bookdate.Name = "obj_bookdate"
        Me.obj_bookdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.obj_bookdate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.obj_bookdate.Size = New System.Drawing.Size(100, 20)
        Me.obj_bookdate.TabIndex = 13
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(34, 111)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl5.TabIndex = 14
        Me.LabelControl5.Text = "Type"
        '
        'obj_kategoriasset_depre
        '
        Me.obj_kategoriasset_depre.Location = New System.Drawing.Point(89, 107)
        Me.obj_kategoriasset_depre.Name = "obj_kategoriasset_depre"
        Me.obj_kategoriasset_depre.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.obj_kategoriasset_depre.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("kategoriassetdepre_descr", "Descr.")})
        Me.obj_kategoriasset_depre.Properties.NullText = ""
        Me.obj_kategoriasset_depre.Size = New System.Drawing.Size(194, 20)
        Me.obj_kategoriasset_depre.TabIndex = 15
        '
        'dlgDepresiasiNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 180)
        Me.Controls.Add(Me.obj_kategoriasset_depre)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.obj_bookdate)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.obj_end)
        Me.Controls.Add(Me.obj_start)
        Me.Controls.Add(Me.obj_periode_id)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgDepresiasiNew"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create New"
        CType(Me.obj_periode_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_start.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_end.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_bookdate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_bookdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_kategoriasset_depre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents obj_periode_id As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents obj_start As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_end As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_bookdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_kategoriasset_depre As DevExpress.XtraEditors.LookUpEdit

End Class
