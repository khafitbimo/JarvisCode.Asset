<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uibangsat
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
        Me.DgvTrnTerimabarangdetil = New System.Windows.Forms.DataGridView
        Me.PnlDfFooter = New System.Windows.Forms.Panel
        Me.obj_top = New System.Windows.Forms.NumericUpDown
        Me.PnlDfSearch = New System.Windows.Forms.Panel
        Me.ftabMain_Data = New System.Windows.Forms.TabPage
        Me.PnlDataMaster = New System.Windows.Forms.Panel
        Me.PnlDataFooter = New System.Windows.Forms.Panel
        Me.ftabMain.SuspendLayout()
        Me.ftabMain_List.SuspendLayout()
        Me.PnlDfMain.SuspendLayout()
        CType(Me.DgvTrnTerimabarangdetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDfFooter.SuspendLayout()
        CType(Me.obj_top, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ftabMain_Data.SuspendLayout()
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
        Me.PnlDfMain.Controls.Add(Me.DgvTrnTerimabarangdetil)
        Me.PnlDfMain.Location = New System.Drawing.Point(20, 131)
        Me.PnlDfMain.Name = "PnlDfMain"
        Me.PnlDfMain.Size = New System.Drawing.Size(704, 296)
        Me.PnlDfMain.TabIndex = 1
        '
        'DgvTrnTerimabarangdetil
        '
        Me.DgvTrnTerimabarangdetil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTrnTerimabarangdetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvTrnTerimabarangdetil.Location = New System.Drawing.Point(0, 0)
        Me.DgvTrnTerimabarangdetil.Name = "DgvTrnTerimabarangdetil"
        Me.DgvTrnTerimabarangdetil.Size = New System.Drawing.Size(704, 296)
        Me.DgvTrnTerimabarangdetil.TabIndex = 0
        '
        'PnlDfFooter
        '
        Me.PnlDfFooter.Controls.Add(Me.obj_top)
        Me.PnlDfFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDfFooter.Location = New System.Drawing.Point(3, 446)
        Me.PnlDfFooter.Name = "PnlDfFooter"
        Me.PnlDfFooter.Size = New System.Drawing.Size(733, 39)
        Me.PnlDfFooter.TabIndex = 2
        '
        'obj_top
        '
        Me.obj_top.Location = New System.Drawing.Point(20, 11)
        Me.obj_top.Name = "obj_top"
        Me.obj_top.Size = New System.Drawing.Size(120, 20)
        Me.obj_top.TabIndex = 0
        Me.obj_top.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'PnlDfSearch
        '
        Me.PnlDfSearch.AutoScroll = True
        Me.PnlDfSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlDfSearch.Location = New System.Drawing.Point(3, 3)
        Me.PnlDfSearch.Name = "PnlDfSearch"
        Me.PnlDfSearch.Size = New System.Drawing.Size(733, 111)
        Me.PnlDfSearch.TabIndex = 0
        '
        'ftabMain_Data
        '
        Me.ftabMain_Data.BackColor = System.Drawing.Color.White
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
        Me.PnlDataMaster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDataMaster.Location = New System.Drawing.Point(3, 3)
        Me.PnlDataMaster.Name = "PnlDataMaster"
        Me.PnlDataMaster.Size = New System.Drawing.Size(733, 401)
        Me.PnlDataMaster.TabIndex = 0
        '
        'PnlDataFooter
        '
        Me.PnlDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlDataFooter.Location = New System.Drawing.Point(3, 404)
        Me.PnlDataFooter.Name = "PnlDataFooter"
        Me.PnlDataFooter.Size = New System.Drawing.Size(733, 81)
        Me.PnlDataFooter.TabIndex = 2
        '
        'uibangsat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.ftabMain)
        Me.Name = "uibangsat"
        Me.Controls.SetChildIndex(Me.ftabMain, 0)
        Me.ftabMain.ResumeLayout(False)
        Me.ftabMain_List.ResumeLayout(False)
        Me.PnlDfMain.ResumeLayout(False)
        CType(Me.DgvTrnTerimabarangdetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDfFooter.ResumeLayout(False)
        CType(Me.obj_top, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ftabMain_Data.ResumeLayout(False)
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
    Friend WithEvents DgvTrnTerimabarangdetil As System.Windows.Forms.DataGridView
    Friend WithEvents obj_Terimabarang_id_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Terimabarang_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_line_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_line_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Channel_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Channel_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_tgl_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_tgl_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Tipeasset_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Tipeasset_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Kategoriasset_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Kategoriasset_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_barcode_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_barcode_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_lineinduk_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_lineinduk_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_barcodeinduk_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_barcodeinduk_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_serial_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_serial_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_produknumber_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_produknumber_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_model_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_model_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_deskripsi_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_deskripsi_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Kategoriitem_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Kategoriitem_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Tipeitem_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Tipeitem_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_golfiskal_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_golfiskal_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_tipedepre_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_tipedepre_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Currency_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Currency_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_harga_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_harga_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_hargabaru_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_hargabaru_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_ppn_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_ppn_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_pph_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_pph_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_disc_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_disc_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_depresiasi_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_depresiasi_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_akum_val_depre_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_akum_val_depre_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_valas_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_valas_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_idrprice_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_idrprice_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Strukturunit_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Strukturunit_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Employee_id_owner_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Employee_id_owner_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Brand_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Brand_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Unit_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Unit_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_qty_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Asset_qty_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Material_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Material_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Warna_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Warna_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Ukuran_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Ukuran_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Jeniskelamin_id_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Jeniskelamin_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Show_id_cont_item_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Show_id_cont_item_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Ruang_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Ruang_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_rak_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_rak_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Is_useable_search As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Is_useable_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_active_search As System.Windows.Forms.CheckBox
    Friend WithEvents chk_Asset_active_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_status_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_status_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Project_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Project_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Show_id_search As System.Windows.Forms.ComboBox
    Friend WithEvents chk_Show_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Asset_eps_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Asset_eps_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Wo_id_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Wo_id_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Inputby_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Inputby_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Inputdt_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Inputdt_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Editby_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Editby_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Editdt_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Editdt_search As System.Windows.Forms.CheckBox
    Friend WithEvents obj_Usedby_search As System.Windows.Forms.TextBox
    Friend WithEvents chk_Usedby_search As System.Windows.Forms.CheckBox
    'OBJECT
    'DEKLARASI SI TOP
    Friend WithEvents obj_top As System.Windows.Forms.NumericUpDown

End Class

