<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiTrnDepresiasi
    Inherits uiBase2

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uiTrnDepresiasi))
        Me.fTabMain = New DevExpress.XtraTab.XtraTabControl()
        Me.fTabMain_List = New DevExpress.XtraTab.XtraTabPage()
        Me.GCTrnJurnal = New DevExpress.XtraGrid.GridControl()
        Me.DgvTrnJurnal = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colJurnal_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPeriode_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnal_bookdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnal_descr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCreated_by = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCreated_dt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelControl8 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.fTabMain_data = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.fTabMaindetil = New DevExpress.XtraTab.XtraTabControl()
        Me.fTabMaindetil_debit = New DevExpress.XtraTab.XtraTabPage()
        Me.GCTrnJurnalDetilDebit = New DevExpress.XtraGrid.GridControl()
        Me.GVJurnalDetilDebit = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colJurnaldetil_line_debit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccname_debit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colAcc_id_debit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_descr_debit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_foreign_debit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_foreignrate_debit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_idr_debit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_amount_debit = New DevExpress.XtraEditors.TextEdit()
        Me.obj_amount_debitidr = New DevExpress.XtraEditors.TextEdit()
        Me.fTabMaindetil_credit = New DevExpress.XtraTab.XtraTabPage()
        Me.GCTrnJurnaldetilCredit = New DevExpress.XtraGrid.GridControl()
        Me.GVTrnJurnaldetilCredit = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colJurnaldetil_line_credit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccName_credit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colAcc_id_credit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_descr_credit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_foreign_credit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_foreignrate_credit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnaldetil_idr_credit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl6 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_amount_credit = New DevExpress.XtraEditors.TextEdit()
        Me.obj_amount_creditidr = New DevExpress.XtraEditors.TextEdit()
        Me.fTabMaindetil_detil = New DevExpress.XtraTab.XtraTabPage()
        Me.GCTrnJurnaldetilDepre = New DevExpress.XtraGrid.GridControl()
        Me.DgvTrnJurnaldetilDepre = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAsset_barcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAsset_deskripsi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colKategoriasset_id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDepresiasi_depremonth = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl7 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_total_depre = New DevExpress.XtraEditors.TextEdit()
        Me.fTabMaindetil_detildisposal = New DevExpress.XtraTab.XtraTabPage()
        Me.GCTrnJurnaldetilDisposal = New DevExpress.XtraGrid.GridControl()
        Me.DgvTrnJurnalDisposal = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colJurnalDisposalID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDisposalLine = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDisposal_assetbarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDisposal_Asset_descr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDisposal_Category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDisposal_Createby = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDisposal_createdt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDisposal_Postedby = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDisposal_Posteddt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.fTabMaindetil_Info = New DevExpress.XtraTab.XtraTabPage()
        Me.obj_jurnal_isdisabled_dt = New DevExpress.XtraEditors.TextEdit()
        Me.obj_jurnal_isdisabled_by = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_posted_dt = New DevExpress.XtraEditors.TextEdit()
        Me.obj_posted_by = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_created_dt = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_created_by = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.obj_selisih_amountidr = New DevExpress.XtraEditors.TextEdit()
        Me.obj_jumlah_amountidr = New DevExpress.XtraEditors.TextEdit()
        Me.obj_selisih_amount = New DevExpress.XtraEditors.TextEdit()
        Me.obj_jumlah_amount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.obj_jurnal_source = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_jurnal_descr = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.obj_jurnal_bookdate = New DevExpress.XtraEditors.TextEdit()
        Me.obj_periode_id = New DevExpress.XtraEditors.TextEdit()
        Me.obj_jurnal_id = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.fTabMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fTabMain.SuspendLayout()
        Me.fTabMain_List.SuspendLayout()
        CType(Me.GCTrnJurnal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvTrnJurnal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl8.SuspendLayout()
        Me.fTabMain_data.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.fTabMaindetil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fTabMaindetil.SuspendLayout()
        Me.fTabMaindetil_debit.SuspendLayout()
        CType(Me.GCTrnJurnalDetilDebit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVJurnalDetilDebit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.obj_amount_debit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_amount_debitidr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fTabMaindetil_credit.SuspendLayout()
        CType(Me.GCTrnJurnaldetilCredit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVTrnJurnaldetilCredit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl6.SuspendLayout()
        CType(Me.obj_amount_credit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_amount_creditidr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fTabMaindetil_detil.SuspendLayout()
        CType(Me.GCTrnJurnaldetilDepre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvTrnJurnaldetilDepre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl7.SuspendLayout()
        CType(Me.obj_total_depre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fTabMaindetil_detildisposal.SuspendLayout()
        CType(Me.GCTrnJurnaldetilDisposal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvTrnJurnalDisposal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fTabMaindetil_Info.SuspendLayout()
        CType(Me.obj_jurnal_isdisabled_dt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_jurnal_isdisabled_by.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_posted_dt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_posted_by.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_created_dt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_created_by.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.obj_selisih_amountidr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_jumlah_amountidr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_selisih_amount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_jumlah_amount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.obj_jurnal_source.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_jurnal_descr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_jurnal_bookdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_periode_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_jurnal_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fTabMain
        '
        Me.fTabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fTabMain.Location = New System.Drawing.Point(2, 0)
        Me.fTabMain.Name = "fTabMain"
        Me.fTabMain.SelectedTabPage = Me.fTabMain_List
        Me.fTabMain.Size = New System.Drawing.Size(751, 522)
        Me.fTabMain.TabIndex = 4
        Me.fTabMain.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.fTabMain_List, Me.fTabMain_data})
        '
        'fTabMain_List
        '
        Me.fTabMain_List.Controls.Add(Me.GCTrnJurnal)
        Me.fTabMain_List.Controls.Add(Me.Panel1)
        Me.fTabMain_List.Controls.Add(Me.PanelControl8)
        Me.fTabMain_List.Name = "fTabMain_List"
        Me.fTabMain_List.Padding = New System.Windows.Forms.Padding(3)
        Me.fTabMain_List.Size = New System.Drawing.Size(746, 497)
        Me.fTabMain_List.Text = "List"
        '
        'GCTrnJurnal
        '
        Me.GCTrnJurnal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTrnJurnal.Location = New System.Drawing.Point(3, 3)
        Me.GCTrnJurnal.MainView = Me.DgvTrnJurnal
        Me.GCTrnJurnal.Name = "GCTrnJurnal"
        Me.GCTrnJurnal.Size = New System.Drawing.Size(740, 456)
        Me.GCTrnJurnal.TabIndex = 24
        Me.GCTrnJurnal.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DgvTrnJurnal})
        '
        'DgvTrnJurnal
        '
        Me.DgvTrnJurnal.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DgvTrnJurnal.Appearance.EvenRow.Options.UseBackColor = True
        Me.DgvTrnJurnal.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.DgvTrnJurnal.Appearance.OddRow.Options.UseBackColor = True
        Me.DgvTrnJurnal.Appearance.VertLine.BackColor = System.Drawing.Color.Gray
        Me.DgvTrnJurnal.Appearance.VertLine.Options.UseBackColor = True
        Me.DgvTrnJurnal.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colJurnal_id, Me.colPeriode_id, Me.colJurnal_bookdate, Me.colJurnal_descr, Me.colCreated_by, Me.colCreated_dt})
        Me.DgvTrnJurnal.GridControl = Me.GCTrnJurnal
        Me.DgvTrnJurnal.Name = "DgvTrnJurnal"
        Me.DgvTrnJurnal.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.DgvTrnJurnal.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.DgvTrnJurnal.OptionsBehavior.Editable = False
        Me.DgvTrnJurnal.OptionsCustomization.AllowColumnMoving = False
        Me.DgvTrnJurnal.OptionsCustomization.AllowFilter = False
        Me.DgvTrnJurnal.OptionsCustomization.AllowGroup = False
        Me.DgvTrnJurnal.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DgvTrnJurnal.OptionsView.ColumnAutoWidth = False
        Me.DgvTrnJurnal.OptionsView.ShowGroupPanel = False
        Me.DgvTrnJurnal.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.DgvTrnJurnal.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colJurnal_id, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'colJurnal_id
        '
        Me.colJurnal_id.Caption = "Jurnal ID"
        Me.colJurnal_id.FieldName = "jurnal_id"
        Me.colJurnal_id.Name = "colJurnal_id"
        Me.colJurnal_id.Visible = True
        Me.colJurnal_id.VisibleIndex = 0
        Me.colJurnal_id.Width = 107
        '
        'colPeriode_id
        '
        Me.colPeriode_id.Caption = "Periode"
        Me.colPeriode_id.FieldName = "periode_id"
        Me.colPeriode_id.Name = "colPeriode_id"
        Me.colPeriode_id.Visible = True
        Me.colPeriode_id.VisibleIndex = 1
        Me.colPeriode_id.Width = 101
        '
        'colJurnal_bookdate
        '
        Me.colJurnal_bookdate.Caption = "Book Date"
        Me.colJurnal_bookdate.FieldName = "jurnal_bookdate"
        Me.colJurnal_bookdate.Name = "colJurnal_bookdate"
        Me.colJurnal_bookdate.Visible = True
        Me.colJurnal_bookdate.VisibleIndex = 2
        '
        'colJurnal_descr
        '
        Me.colJurnal_descr.Caption = "Description"
        Me.colJurnal_descr.FieldName = "jurnal_descr"
        Me.colJurnal_descr.Name = "colJurnal_descr"
        Me.colJurnal_descr.Visible = True
        Me.colJurnal_descr.VisibleIndex = 3
        Me.colJurnal_descr.Width = 250
        '
        'colCreated_by
        '
        Me.colCreated_by.Caption = "Created By"
        Me.colCreated_by.FieldName = "created_by"
        Me.colCreated_by.Name = "colCreated_by"
        Me.colCreated_by.Visible = True
        Me.colCreated_by.VisibleIndex = 4
        Me.colCreated_by.Width = 230
        '
        'colCreated_dt
        '
        Me.colCreated_dt.Caption = "Created Date"
        Me.colCreated_dt.FieldName = "created_dt"
        Me.colCreated_dt.Name = "colCreated_dt"
        Me.colCreated_dt.Visible = True
        Me.colCreated_dt.VisibleIndex = 5
        Me.colCreated_dt.Width = 185
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 459)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(740, 3)
        Me.Panel1.TabIndex = 26
        '
        'PanelControl8
        '
        Me.PanelControl8.Controls.Add(Me.LabelControl20)
        Me.PanelControl8.Controls.Add(Me.LabelControl19)
        Me.PanelControl8.Controls.Add(Me.Panel3)
        Me.PanelControl8.Controls.Add(Me.Panel2)
        Me.PanelControl8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl8.Location = New System.Drawing.Point(3, 462)
        Me.PanelControl8.Name = "PanelControl8"
        Me.PanelControl8.Size = New System.Drawing.Size(740, 32)
        Me.PanelControl8.TabIndex = 25
        '
        'LabelControl20
        '
        Me.LabelControl20.Location = New System.Drawing.Point(128, 9)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl20.TabIndex = 3
        Me.LabelControl20.Text = "Posting"
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(40, 9)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl19.TabIndex = 2
        Me.LabelControl19.Text = "New"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightGreen
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(169, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(28, 23)
        Me.Panel3.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Location = New System.Drawing.Point(67, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(28, 23)
        Me.Panel2.TabIndex = 0
        '
        'fTabMain_data
        '
        Me.fTabMain_data.Controls.Add(Me.PanelControl3)
        Me.fTabMain_data.Controls.Add(Me.PanelControl2)
        Me.fTabMain_data.Name = "fTabMain_data"
        Me.fTabMain_data.Padding = New System.Windows.Forms.Padding(3)
        Me.fTabMain_data.Size = New System.Drawing.Size(746, 497)
        Me.fTabMain_data.Text = "Data"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.fTabMaindetil)
        Me.PanelControl3.Controls.Add(Me.PanelControl4)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(3, 104)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.PanelControl3.Size = New System.Drawing.Size(740, 390)
        Me.PanelControl3.TabIndex = 7
        '
        'fTabMaindetil
        '
        Me.fTabMaindetil.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fTabMaindetil.Location = New System.Drawing.Point(0, 2)
        Me.fTabMaindetil.Name = "fTabMaindetil"
        Me.fTabMaindetil.SelectedTabPage = Me.fTabMaindetil_debit
        Me.fTabMaindetil.Size = New System.Drawing.Size(740, 326)
        Me.fTabMaindetil.TabIndex = 6
        Me.fTabMaindetil.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.fTabMaindetil_debit, Me.fTabMaindetil_credit, Me.fTabMaindetil_detil, Me.fTabMaindetil_detildisposal, Me.fTabMaindetil_Info})
        '
        'fTabMaindetil_debit
        '
        Me.fTabMaindetil_debit.Controls.Add(Me.GCTrnJurnalDetilDebit)
        Me.fTabMaindetil_debit.Controls.Add(Me.PanelControl5)
        Me.fTabMaindetil_debit.Name = "fTabMaindetil_debit"
        Me.fTabMaindetil_debit.Padding = New System.Windows.Forms.Padding(3)
        Me.fTabMaindetil_debit.Size = New System.Drawing.Size(735, 301)
        Me.fTabMaindetil_debit.Text = "Debit"
        '
        'GCTrnJurnalDetilDebit
        '
        Me.GCTrnJurnalDetilDebit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTrnJurnalDetilDebit.Location = New System.Drawing.Point(3, 3)
        Me.GCTrnJurnalDetilDebit.MainView = Me.GVJurnalDetilDebit
        Me.GCTrnJurnalDetilDebit.Name = "GCTrnJurnalDetilDebit"
        Me.GCTrnJurnalDetilDebit.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit1})
        Me.GCTrnJurnalDetilDebit.Size = New System.Drawing.Size(729, 256)
        Me.GCTrnJurnalDetilDebit.TabIndex = 25
        Me.GCTrnJurnalDetilDebit.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVJurnalDetilDebit})
        '
        'GVJurnalDetilDebit
        '
        Me.GVJurnalDetilDebit.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GVJurnalDetilDebit.Appearance.EvenRow.Options.UseBackColor = True
        Me.GVJurnalDetilDebit.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GVJurnalDetilDebit.Appearance.OddRow.Options.UseBackColor = True
        Me.GVJurnalDetilDebit.Appearance.VertLine.BackColor = System.Drawing.Color.Gray
        Me.GVJurnalDetilDebit.Appearance.VertLine.Options.UseBackColor = True
        Me.GVJurnalDetilDebit.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colJurnaldetil_line_debit, Me.colAccname_debit, Me.colAcc_id_debit, Me.colJurnaldetil_descr_debit, Me.colJurnaldetil_foreign_debit, Me.colJurnaldetil_foreignrate_debit, Me.colJurnaldetil_idr_debit})
        Me.GVJurnalDetilDebit.GridControl = Me.GCTrnJurnalDetilDebit
        Me.GVJurnalDetilDebit.Name = "GVJurnalDetilDebit"
        Me.GVJurnalDetilDebit.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVJurnalDetilDebit.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVJurnalDetilDebit.OptionsBehavior.Editable = False
        Me.GVJurnalDetilDebit.OptionsCustomization.AllowColumnMoving = False
        Me.GVJurnalDetilDebit.OptionsCustomization.AllowFilter = False
        Me.GVJurnalDetilDebit.OptionsCustomization.AllowGroup = False
        Me.GVJurnalDetilDebit.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVJurnalDetilDebit.OptionsView.ColumnAutoWidth = False
        Me.GVJurnalDetilDebit.OptionsView.EnableAppearanceEvenRow = True
        Me.GVJurnalDetilDebit.OptionsView.EnableAppearanceOddRow = True
        Me.GVJurnalDetilDebit.OptionsView.ShowGroupPanel = False
        Me.GVJurnalDetilDebit.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colJurnaldetil_line_debit
        '
        Me.colJurnaldetil_line_debit.AppearanceCell.Options.UseTextOptions = True
        Me.colJurnaldetil_line_debit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colJurnaldetil_line_debit.Caption = "line"
        Me.colJurnaldetil_line_debit.FieldName = "jurnaldetil_line"
        Me.colJurnaldetil_line_debit.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colJurnaldetil_line_debit.Name = "colJurnaldetil_line_debit"
        Me.colJurnaldetil_line_debit.OptionsColumn.FixedWidth = True
        Me.colJurnaldetil_line_debit.Visible = True
        Me.colJurnaldetil_line_debit.VisibleIndex = 0
        Me.colJurnaldetil_line_debit.Width = 35
        '
        'colAccname_debit
        '
        Me.colAccname_debit.Caption = "Account"
        Me.colAccname_debit.ColumnEdit = Me.RepositoryItemLookUpEdit1
        Me.colAccname_debit.FieldName = "acc_id"
        Me.colAccname_debit.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colAccname_debit.Name = "colAccname_debit"
        Me.colAccname_debit.Visible = True
        Me.colAccname_debit.VisibleIndex = 1
        Me.colAccname_debit.Width = 217
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.NullText = ""
        '
        'colAcc_id_debit
        '
        Me.colAcc_id_debit.Caption = "COA"
        Me.colAcc_id_debit.FieldName = "acc_id"
        Me.colAcc_id_debit.Name = "colAcc_id_debit"
        Me.colAcc_id_debit.Visible = True
        Me.colAcc_id_debit.VisibleIndex = 2
        Me.colAcc_id_debit.Width = 89
        '
        'colJurnaldetil_descr_debit
        '
        Me.colJurnaldetil_descr_debit.Caption = "Descr."
        Me.colJurnaldetil_descr_debit.FieldName = "jurnaldetil_descr"
        Me.colJurnaldetil_descr_debit.Name = "colJurnaldetil_descr_debit"
        Me.colJurnaldetil_descr_debit.Visible = True
        Me.colJurnaldetil_descr_debit.VisibleIndex = 3
        Me.colJurnaldetil_descr_debit.Width = 271
        '
        'colJurnaldetil_foreign_debit
        '
        Me.colJurnaldetil_foreign_debit.Caption = "Amount"
        Me.colJurnaldetil_foreign_debit.DisplayFormat.FormatString = "###,###.00"
        Me.colJurnaldetil_foreign_debit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnaldetil_foreign_debit.FieldName = "jurnaldetil_foreign"
        Me.colJurnaldetil_foreign_debit.Name = "colJurnaldetil_foreign_debit"
        Me.colJurnaldetil_foreign_debit.Visible = True
        Me.colJurnaldetil_foreign_debit.VisibleIndex = 4
        Me.colJurnaldetil_foreign_debit.Width = 128
        '
        'colJurnaldetil_foreignrate_debit
        '
        Me.colJurnaldetil_foreignrate_debit.Caption = "Rate"
        Me.colJurnaldetil_foreignrate_debit.DisplayFormat.FormatString = "###,###.00"
        Me.colJurnaldetil_foreignrate_debit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnaldetil_foreignrate_debit.FieldName = "jurnaldetil_foreignrate"
        Me.colJurnaldetil_foreignrate_debit.Name = "colJurnaldetil_foreignrate_debit"
        Me.colJurnaldetil_foreignrate_debit.Visible = True
        Me.colJurnaldetil_foreignrate_debit.VisibleIndex = 5
        '
        'colJurnaldetil_idr_debit
        '
        Me.colJurnaldetil_idr_debit.AppearanceCell.Options.UseTextOptions = True
        Me.colJurnaldetil_idr_debit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colJurnaldetil_idr_debit.Caption = "Amount IDR"
        Me.colJurnaldetil_idr_debit.DisplayFormat.FormatString = "###,###"
        Me.colJurnaldetil_idr_debit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnaldetil_idr_debit.FieldName = "jurnaldetil_idr"
        Me.colJurnaldetil_idr_debit.Name = "colJurnaldetil_idr_debit"
        Me.colJurnaldetil_idr_debit.Visible = True
        Me.colJurnaldetil_idr_debit.VisibleIndex = 6
        Me.colJurnaldetil_idr_debit.Width = 128
        '
        'PanelControl5
        '
        Me.PanelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl5.Controls.Add(Me.LabelControl14)
        Me.PanelControl5.Controls.Add(Me.LabelControl15)
        Me.PanelControl5.Controls.Add(Me.obj_amount_debit)
        Me.PanelControl5.Controls.Add(Me.obj_amount_debitidr)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl5.Location = New System.Drawing.Point(3, 259)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(729, 39)
        Me.PanelControl5.TabIndex = 12
        '
        'LabelControl14
        '
        Me.LabelControl14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl14.Location = New System.Drawing.Point(300, 13)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl14.TabIndex = 10
        Me.LabelControl14.Text = "Amount"
        '
        'LabelControl15
        '
        Me.LabelControl15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl15.Location = New System.Drawing.Point(523, 13)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl15.TabIndex = 11
        Me.LabelControl15.Text = "Amount (IDR)"
        '
        'obj_amount_debit
        '
        Me.obj_amount_debit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_amount_debit.Location = New System.Drawing.Point(343, 9)
        Me.obj_amount_debit.Name = "obj_amount_debit"
        Me.obj_amount_debit.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_amount_debit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_amount_debit.Properties.ReadOnly = True
        Me.obj_amount_debit.Size = New System.Drawing.Size(129, 20)
        Me.obj_amount_debit.TabIndex = 8
        '
        'obj_amount_debitidr
        '
        Me.obj_amount_debitidr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_amount_debitidr.Location = New System.Drawing.Point(595, 9)
        Me.obj_amount_debitidr.Name = "obj_amount_debitidr"
        Me.obj_amount_debitidr.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_amount_debitidr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_amount_debitidr.Properties.ReadOnly = True
        Me.obj_amount_debitidr.Size = New System.Drawing.Size(129, 20)
        Me.obj_amount_debitidr.TabIndex = 9
        '
        'fTabMaindetil_credit
        '
        Me.fTabMaindetil_credit.Controls.Add(Me.GCTrnJurnaldetilCredit)
        Me.fTabMaindetil_credit.Controls.Add(Me.PanelControl6)
        Me.fTabMaindetil_credit.Name = "fTabMaindetil_credit"
        Me.fTabMaindetil_credit.Padding = New System.Windows.Forms.Padding(3)
        Me.fTabMaindetil_credit.Size = New System.Drawing.Size(735, 301)
        Me.fTabMaindetil_credit.Text = "Credit"
        '
        'GCTrnJurnaldetilCredit
        '
        Me.GCTrnJurnaldetilCredit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTrnJurnaldetilCredit.Location = New System.Drawing.Point(3, 3)
        Me.GCTrnJurnaldetilCredit.MainView = Me.GVTrnJurnaldetilCredit
        Me.GCTrnJurnaldetilCredit.Name = "GCTrnJurnaldetilCredit"
        Me.GCTrnJurnaldetilCredit.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit2})
        Me.GCTrnJurnaldetilCredit.Size = New System.Drawing.Size(729, 256)
        Me.GCTrnJurnaldetilCredit.TabIndex = 26
        Me.GCTrnJurnaldetilCredit.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVTrnJurnaldetilCredit})
        '
        'GVTrnJurnaldetilCredit
        '
        Me.GVTrnJurnaldetilCredit.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GVTrnJurnaldetilCredit.Appearance.EvenRow.Options.UseBackColor = True
        Me.GVTrnJurnaldetilCredit.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GVTrnJurnaldetilCredit.Appearance.OddRow.Options.UseBackColor = True
        Me.GVTrnJurnaldetilCredit.Appearance.VertLine.BackColor = System.Drawing.Color.Gray
        Me.GVTrnJurnaldetilCredit.Appearance.VertLine.Options.UseBackColor = True
        Me.GVTrnJurnaldetilCredit.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colJurnaldetil_line_credit, Me.colAccName_credit, Me.colAcc_id_credit, Me.colJurnaldetil_descr_credit, Me.colJurnaldetil_foreign_credit, Me.colJurnaldetil_foreignrate_credit, Me.colJurnaldetil_idr_credit})
        Me.GVTrnJurnaldetilCredit.GridControl = Me.GCTrnJurnaldetilCredit
        Me.GVTrnJurnaldetilCredit.Name = "GVTrnJurnaldetilCredit"
        Me.GVTrnJurnaldetilCredit.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVTrnJurnaldetilCredit.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVTrnJurnaldetilCredit.OptionsBehavior.Editable = False
        Me.GVTrnJurnaldetilCredit.OptionsCustomization.AllowColumnMoving = False
        Me.GVTrnJurnaldetilCredit.OptionsCustomization.AllowFilter = False
        Me.GVTrnJurnaldetilCredit.OptionsCustomization.AllowGroup = False
        Me.GVTrnJurnaldetilCredit.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVTrnJurnaldetilCredit.OptionsView.ColumnAutoWidth = False
        Me.GVTrnJurnaldetilCredit.OptionsView.EnableAppearanceEvenRow = True
        Me.GVTrnJurnaldetilCredit.OptionsView.EnableAppearanceOddRow = True
        Me.GVTrnJurnaldetilCredit.OptionsView.ShowGroupPanel = False
        Me.GVTrnJurnaldetilCredit.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colJurnaldetil_line_credit
        '
        Me.colJurnaldetil_line_credit.AppearanceCell.Options.UseTextOptions = True
        Me.colJurnaldetil_line_credit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colJurnaldetil_line_credit.Caption = "line"
        Me.colJurnaldetil_line_credit.FieldName = "jurnaldetil_line"
        Me.colJurnaldetil_line_credit.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colJurnaldetil_line_credit.Name = "colJurnaldetil_line_credit"
        Me.colJurnaldetil_line_credit.OptionsColumn.FixedWidth = True
        Me.colJurnaldetil_line_credit.Visible = True
        Me.colJurnaldetil_line_credit.VisibleIndex = 0
        Me.colJurnaldetil_line_credit.Width = 35
        '
        'colAccName_credit
        '
        Me.colAccName_credit.Caption = "Account"
        Me.colAccName_credit.ColumnEdit = Me.RepositoryItemLookUpEdit2
        Me.colAccName_credit.FieldName = "acc_id"
        Me.colAccName_credit.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colAccName_credit.Name = "colAccName_credit"
        Me.colAccName_credit.Visible = True
        Me.colAccName_credit.VisibleIndex = 1
        Me.colAccName_credit.Width = 217
        '
        'RepositoryItemLookUpEdit2
        '
        Me.RepositoryItemLookUpEdit2.AutoHeight = False
        Me.RepositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2"
        Me.RepositoryItemLookUpEdit2.NullText = ""
        '
        'colAcc_id_credit
        '
        Me.colAcc_id_credit.Caption = "COA"
        Me.colAcc_id_credit.FieldName = "acc_id"
        Me.colAcc_id_credit.Name = "colAcc_id_credit"
        Me.colAcc_id_credit.Visible = True
        Me.colAcc_id_credit.VisibleIndex = 2
        Me.colAcc_id_credit.Width = 89
        '
        'colJurnaldetil_descr_credit
        '
        Me.colJurnaldetil_descr_credit.Caption = "Descr."
        Me.colJurnaldetil_descr_credit.FieldName = "jurnaldetil_descr"
        Me.colJurnaldetil_descr_credit.Name = "colJurnaldetil_descr_credit"
        Me.colJurnaldetil_descr_credit.Visible = True
        Me.colJurnaldetil_descr_credit.VisibleIndex = 3
        Me.colJurnaldetil_descr_credit.Width = 271
        '
        'colJurnaldetil_foreign_credit
        '
        Me.colJurnaldetil_foreign_credit.Caption = "Amount"
        Me.colJurnaldetil_foreign_credit.DisplayFormat.FormatString = "###,###.00"
        Me.colJurnaldetil_foreign_credit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnaldetil_foreign_credit.FieldName = "jurnaldetil_foreign"
        Me.colJurnaldetil_foreign_credit.Name = "colJurnaldetil_foreign_credit"
        Me.colJurnaldetil_foreign_credit.Visible = True
        Me.colJurnaldetil_foreign_credit.VisibleIndex = 4
        Me.colJurnaldetil_foreign_credit.Width = 128
        '
        'colJurnaldetil_foreignrate_credit
        '
        Me.colJurnaldetil_foreignrate_credit.Caption = "Rate"
        Me.colJurnaldetil_foreignrate_credit.DisplayFormat.FormatString = "###,###.00"
        Me.colJurnaldetil_foreignrate_credit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnaldetil_foreignrate_credit.FieldName = "jurnaldetil_foreignrate"
        Me.colJurnaldetil_foreignrate_credit.Name = "colJurnaldetil_foreignrate_credit"
        Me.colJurnaldetil_foreignrate_credit.Visible = True
        Me.colJurnaldetil_foreignrate_credit.VisibleIndex = 5
        Me.colJurnaldetil_foreignrate_credit.Width = 100
        '
        'colJurnaldetil_idr_credit
        '
        Me.colJurnaldetil_idr_credit.AppearanceCell.Options.UseTextOptions = True
        Me.colJurnaldetil_idr_credit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colJurnaldetil_idr_credit.Caption = "Amount IDR"
        Me.colJurnaldetil_idr_credit.DisplayFormat.FormatString = "###,###.##"
        Me.colJurnaldetil_idr_credit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnaldetil_idr_credit.FieldName = "jurnaldetil_idr"
        Me.colJurnaldetil_idr_credit.Name = "colJurnaldetil_idr_credit"
        Me.colJurnaldetil_idr_credit.Visible = True
        Me.colJurnaldetil_idr_credit.VisibleIndex = 6
        Me.colJurnaldetil_idr_credit.Width = 128
        '
        'PanelControl6
        '
        Me.PanelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl6.Controls.Add(Me.LabelControl16)
        Me.PanelControl6.Controls.Add(Me.LabelControl17)
        Me.PanelControl6.Controls.Add(Me.obj_amount_credit)
        Me.PanelControl6.Controls.Add(Me.obj_amount_creditidr)
        Me.PanelControl6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl6.Location = New System.Drawing.Point(3, 259)
        Me.PanelControl6.Name = "PanelControl6"
        Me.PanelControl6.Size = New System.Drawing.Size(729, 39)
        Me.PanelControl6.TabIndex = 27
        '
        'LabelControl16
        '
        Me.LabelControl16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl16.Location = New System.Drawing.Point(300, 13)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl16.TabIndex = 10
        Me.LabelControl16.Text = "Amount"
        '
        'LabelControl17
        '
        Me.LabelControl17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl17.Location = New System.Drawing.Point(523, 13)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl17.TabIndex = 11
        Me.LabelControl17.Text = "Amount (IDR)"
        '
        'obj_amount_credit
        '
        Me.obj_amount_credit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_amount_credit.Location = New System.Drawing.Point(343, 9)
        Me.obj_amount_credit.Name = "obj_amount_credit"
        Me.obj_amount_credit.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_amount_credit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_amount_credit.Properties.ReadOnly = True
        Me.obj_amount_credit.Size = New System.Drawing.Size(129, 20)
        Me.obj_amount_credit.TabIndex = 8
        '
        'obj_amount_creditidr
        '
        Me.obj_amount_creditidr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_amount_creditidr.Location = New System.Drawing.Point(595, 9)
        Me.obj_amount_creditidr.Name = "obj_amount_creditidr"
        Me.obj_amount_creditidr.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_amount_creditidr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_amount_creditidr.Properties.ReadOnly = True
        Me.obj_amount_creditidr.Size = New System.Drawing.Size(129, 20)
        Me.obj_amount_creditidr.TabIndex = 9
        '
        'fTabMaindetil_detil
        '
        Me.fTabMaindetil_detil.Controls.Add(Me.GCTrnJurnaldetilDepre)
        Me.fTabMaindetil_detil.Controls.Add(Me.PanelControl7)
        Me.fTabMaindetil_detil.Name = "fTabMaindetil_detil"
        Me.fTabMaindetil_detil.Padding = New System.Windows.Forms.Padding(3)
        Me.fTabMaindetil_detil.Size = New System.Drawing.Size(735, 301)
        Me.fTabMaindetil_detil.Text = "Depreciation Items"
        '
        'GCTrnJurnaldetilDepre
        '
        Me.GCTrnJurnaldetilDepre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTrnJurnaldetilDepre.Location = New System.Drawing.Point(3, 3)
        Me.GCTrnJurnaldetilDepre.MainView = Me.DgvTrnJurnaldetilDepre
        Me.GCTrnJurnaldetilDepre.Name = "GCTrnJurnaldetilDepre"
        Me.GCTrnJurnaldetilDepre.Size = New System.Drawing.Size(729, 256)
        Me.GCTrnJurnaldetilDepre.TabIndex = 24
        Me.GCTrnJurnaldetilDepre.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DgvTrnJurnaldetilDepre})
        '
        'DgvTrnJurnaldetilDepre
        '
        Me.DgvTrnJurnaldetilDepre.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DgvTrnJurnaldetilDepre.Appearance.EvenRow.Options.UseBackColor = True
        Me.DgvTrnJurnaldetilDepre.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.DgvTrnJurnaldetilDepre.Appearance.OddRow.Options.UseBackColor = True
        Me.DgvTrnJurnaldetilDepre.Appearance.VertLine.BackColor = System.Drawing.Color.Gray
        Me.DgvTrnJurnaldetilDepre.Appearance.VertLine.Options.UseBackColor = True
        Me.DgvTrnJurnaldetilDepre.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colNumber, Me.colAsset_barcode, Me.colAsset_deskripsi, Me.colKategoriasset_id, Me.colDepresiasi_depremonth})
        Me.DgvTrnJurnaldetilDepre.GridControl = Me.GCTrnJurnaldetilDepre
        Me.DgvTrnJurnaldetilDepre.Name = "DgvTrnJurnaldetilDepre"
        Me.DgvTrnJurnaldetilDepre.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.DgvTrnJurnaldetilDepre.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.DgvTrnJurnaldetilDepre.OptionsBehavior.Editable = False
        Me.DgvTrnJurnaldetilDepre.OptionsCustomization.AllowColumnMoving = False
        Me.DgvTrnJurnaldetilDepre.OptionsCustomization.AllowGroup = False
        Me.DgvTrnJurnaldetilDepre.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DgvTrnJurnaldetilDepre.OptionsView.ColumnAutoWidth = False
        Me.DgvTrnJurnaldetilDepre.OptionsView.EnableAppearanceEvenRow = True
        Me.DgvTrnJurnaldetilDepre.OptionsView.EnableAppearanceOddRow = True
        Me.DgvTrnJurnaldetilDepre.OptionsView.ShowGroupPanel = False
        Me.DgvTrnJurnaldetilDepre.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colNumber
        '
        Me.colNumber.AppearanceCell.Options.UseTextOptions = True
        Me.colNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colNumber.Caption = "No."
        Me.colNumber.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colNumber.Name = "colNumber"
        Me.colNumber.OptionsColumn.FixedWidth = True
        Me.colNumber.Visible = True
        Me.colNumber.VisibleIndex = 0
        Me.colNumber.Width = 35
        '
        'colAsset_barcode
        '
        Me.colAsset_barcode.Caption = "Barcode"
        Me.colAsset_barcode.FieldName = "asset_barcode"
        Me.colAsset_barcode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colAsset_barcode.Name = "colAsset_barcode"
        Me.colAsset_barcode.Visible = True
        Me.colAsset_barcode.VisibleIndex = 1
        Me.colAsset_barcode.Width = 94
        '
        'colAsset_deskripsi
        '
        Me.colAsset_deskripsi.Caption = "Description"
        Me.colAsset_deskripsi.FieldName = "asset_deskripsi"
        Me.colAsset_deskripsi.Name = "colAsset_deskripsi"
        Me.colAsset_deskripsi.Visible = True
        Me.colAsset_deskripsi.VisibleIndex = 2
        Me.colAsset_deskripsi.Width = 259
        '
        'colKategoriasset_id
        '
        Me.colKategoriasset_id.Caption = "Category"
        Me.colKategoriasset_id.FieldName = "kategoriasset_id"
        Me.colKategoriasset_id.Name = "colKategoriasset_id"
        Me.colKategoriasset_id.Visible = True
        Me.colKategoriasset_id.VisibleIndex = 3
        Me.colKategoriasset_id.Width = 271
        '
        'colDepresiasi_depremonth
        '
        Me.colDepresiasi_depremonth.AppearanceCell.Options.UseTextOptions = True
        Me.colDepresiasi_depremonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colDepresiasi_depremonth.Caption = "Depre"
        Me.colDepresiasi_depremonth.DisplayFormat.FormatString = "###,###.##"
        Me.colDepresiasi_depremonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDepresiasi_depremonth.FieldName = "depresiasi_depremonth"
        Me.colDepresiasi_depremonth.Name = "colDepresiasi_depremonth"
        Me.colDepresiasi_depremonth.Visible = True
        Me.colDepresiasi_depremonth.VisibleIndex = 4
        Me.colDepresiasi_depremonth.Width = 138
        '
        'PanelControl7
        '
        Me.PanelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl7.Controls.Add(Me.LabelControl18)
        Me.PanelControl7.Controls.Add(Me.obj_total_depre)
        Me.PanelControl7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl7.Location = New System.Drawing.Point(3, 259)
        Me.PanelControl7.Name = "PanelControl7"
        Me.PanelControl7.Size = New System.Drawing.Size(729, 39)
        Me.PanelControl7.TabIndex = 28
        '
        'LabelControl18
        '
        Me.LabelControl18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl18.Location = New System.Drawing.Point(529, 13)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl18.TabIndex = 10
        Me.LabelControl18.Text = "Total Depre."
        '
        'obj_total_depre
        '
        Me.obj_total_depre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_total_depre.Location = New System.Drawing.Point(595, 10)
        Me.obj_total_depre.Name = "obj_total_depre"
        Me.obj_total_depre.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_total_depre.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_total_depre.Properties.ReadOnly = True
        Me.obj_total_depre.Size = New System.Drawing.Size(129, 20)
        Me.obj_total_depre.TabIndex = 8
        '
        'fTabMaindetil_detildisposal
        '
        Me.fTabMaindetil_detildisposal.Controls.Add(Me.GCTrnJurnaldetilDisposal)
        Me.fTabMaindetil_detildisposal.Name = "fTabMaindetil_detildisposal"
        Me.fTabMaindetil_detildisposal.Padding = New System.Windows.Forms.Padding(3)
        Me.fTabMaindetil_detildisposal.Size = New System.Drawing.Size(735, 301)
        Me.fTabMaindetil_detildisposal.Text = "Disposal Items"
        '
        'GCTrnJurnaldetilDisposal
        '
        Me.GCTrnJurnaldetilDisposal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCTrnJurnaldetilDisposal.Location = New System.Drawing.Point(3, 3)
        Me.GCTrnJurnaldetilDisposal.MainView = Me.DgvTrnJurnalDisposal
        Me.GCTrnJurnaldetilDisposal.Name = "GCTrnJurnaldetilDisposal"
        Me.GCTrnJurnaldetilDisposal.Size = New System.Drawing.Size(729, 295)
        Me.GCTrnJurnaldetilDisposal.TabIndex = 25
        Me.GCTrnJurnaldetilDisposal.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DgvTrnJurnalDisposal})
        '
        'DgvTrnJurnalDisposal
        '
        Me.DgvTrnJurnalDisposal.Appearance.EvenRow.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DgvTrnJurnalDisposal.Appearance.EvenRow.Options.UseBackColor = True
        Me.DgvTrnJurnalDisposal.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.DgvTrnJurnalDisposal.Appearance.OddRow.Options.UseBackColor = True
        Me.DgvTrnJurnalDisposal.Appearance.VertLine.BackColor = System.Drawing.Color.Gray
        Me.DgvTrnJurnalDisposal.Appearance.VertLine.Options.UseBackColor = True
        Me.DgvTrnJurnalDisposal.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colJurnalDisposalID, Me.colJurnalDisposalLine, Me.colJurnalDisposal_assetbarcode, Me.colJurnalDisposal_Asset_descr, Me.colJurnalDisposal_Category, Me.colJurnalDisposal_Createby, Me.colJurnalDisposal_createdt, Me.colJurnalDisposal_Postedby, Me.colJurnalDisposal_Posteddt})
        Me.DgvTrnJurnalDisposal.GridControl = Me.GCTrnJurnaldetilDisposal
        Me.DgvTrnJurnalDisposal.Name = "DgvTrnJurnalDisposal"
        Me.DgvTrnJurnalDisposal.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.DgvTrnJurnalDisposal.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.DgvTrnJurnalDisposal.OptionsBehavior.Editable = False
        Me.DgvTrnJurnalDisposal.OptionsCustomization.AllowColumnMoving = False
        Me.DgvTrnJurnalDisposal.OptionsCustomization.AllowFilter = False
        Me.DgvTrnJurnalDisposal.OptionsCustomization.AllowGroup = False
        Me.DgvTrnJurnalDisposal.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DgvTrnJurnalDisposal.OptionsView.ColumnAutoWidth = False
        Me.DgvTrnJurnalDisposal.OptionsView.EnableAppearanceEvenRow = True
        Me.DgvTrnJurnalDisposal.OptionsView.EnableAppearanceOddRow = True
        Me.DgvTrnJurnalDisposal.OptionsView.ShowGroupPanel = False
        Me.DgvTrnJurnalDisposal.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        '
        'colJurnalDisposalID
        '
        Me.colJurnalDisposalID.Caption = "Jurnal ID"
        Me.colJurnalDisposalID.FieldName = "jurnal_id"
        Me.colJurnalDisposalID.Name = "colJurnalDisposalID"
        Me.colJurnalDisposalID.Visible = True
        Me.colJurnalDisposalID.VisibleIndex = 0
        Me.colJurnalDisposalID.Width = 86
        '
        'colJurnalDisposalLine
        '
        Me.colJurnalDisposalLine.Caption = "Line"
        Me.colJurnalDisposalLine.FieldName = "jurnaldetil_line"
        Me.colJurnalDisposalLine.Name = "colJurnalDisposalLine"
        Me.colJurnalDisposalLine.Visible = True
        Me.colJurnalDisposalLine.VisibleIndex = 1
        '
        'colJurnalDisposal_assetbarcode
        '
        Me.colJurnalDisposal_assetbarcode.Caption = "Barcode"
        Me.colJurnalDisposal_assetbarcode.FieldName = "asset_barcode"
        Me.colJurnalDisposal_assetbarcode.Name = "colJurnalDisposal_assetbarcode"
        Me.colJurnalDisposal_assetbarcode.Visible = True
        Me.colJurnalDisposal_assetbarcode.VisibleIndex = 2
        Me.colJurnalDisposal_assetbarcode.Width = 94
        '
        'colJurnalDisposal_Asset_descr
        '
        Me.colJurnalDisposal_Asset_descr.Caption = "Description"
        Me.colJurnalDisposal_Asset_descr.FieldName = "asset_deskripsi"
        Me.colJurnalDisposal_Asset_descr.Name = "colJurnalDisposal_Asset_descr"
        Me.colJurnalDisposal_Asset_descr.Visible = True
        Me.colJurnalDisposal_Asset_descr.VisibleIndex = 3
        Me.colJurnalDisposal_Asset_descr.Width = 259
        '
        'colJurnalDisposal_Category
        '
        Me.colJurnalDisposal_Category.Caption = "Category"
        Me.colJurnalDisposal_Category.FieldName = "kategoriasset_id"
        Me.colJurnalDisposal_Category.Name = "colJurnalDisposal_Category"
        Me.colJurnalDisposal_Category.Visible = True
        Me.colJurnalDisposal_Category.VisibleIndex = 4
        Me.colJurnalDisposal_Category.Width = 271
        '
        'colJurnalDisposal_Createby
        '
        Me.colJurnalDisposal_Createby.Caption = "Disposal By"
        Me.colJurnalDisposal_Createby.FieldName = "create_by"
        Me.colJurnalDisposal_Createby.Name = "colJurnalDisposal_Createby"
        Me.colJurnalDisposal_Createby.Visible = True
        Me.colJurnalDisposal_Createby.VisibleIndex = 5
        '
        'colJurnalDisposal_createdt
        '
        Me.colJurnalDisposal_createdt.Caption = "Disposal Date"
        Me.colJurnalDisposal_createdt.FieldName = "create_dt"
        Me.colJurnalDisposal_createdt.Name = "colJurnalDisposal_createdt"
        Me.colJurnalDisposal_createdt.Visible = True
        Me.colJurnalDisposal_createdt.VisibleIndex = 6
        '
        'colJurnalDisposal_Postedby
        '
        Me.colJurnalDisposal_Postedby.Caption = "Posted By"
        Me.colJurnalDisposal_Postedby.FieldName = "jurnal_ispostedby"
        Me.colJurnalDisposal_Postedby.Name = "colJurnalDisposal_Postedby"
        Me.colJurnalDisposal_Postedby.Visible = True
        Me.colJurnalDisposal_Postedby.VisibleIndex = 7
        '
        'colJurnalDisposal_Posteddt
        '
        Me.colJurnalDisposal_Posteddt.Caption = "Posted Date"
        Me.colJurnalDisposal_Posteddt.FieldName = "jurnal_isposteddate"
        Me.colJurnalDisposal_Posteddt.Name = "colJurnalDisposal_Posteddt"
        Me.colJurnalDisposal_Posteddt.Visible = True
        Me.colJurnalDisposal_Posteddt.VisibleIndex = 8
        '
        'fTabMaindetil_Info
        '
        Me.fTabMaindetil_Info.Controls.Add(Me.obj_jurnal_isdisabled_dt)
        Me.fTabMaindetil_Info.Controls.Add(Me.obj_jurnal_isdisabled_by)
        Me.fTabMaindetil_Info.Controls.Add(Me.LabelControl9)
        Me.fTabMaindetil_Info.Controls.Add(Me.LabelControl8)
        Me.fTabMaindetil_Info.Controls.Add(Me.obj_posted_dt)
        Me.fTabMaindetil_Info.Controls.Add(Me.obj_posted_by)
        Me.fTabMaindetil_Info.Controls.Add(Me.LabelControl7)
        Me.fTabMaindetil_Info.Controls.Add(Me.LabelControl6)
        Me.fTabMaindetil_Info.Controls.Add(Me.obj_created_dt)
        Me.fTabMaindetil_Info.Controls.Add(Me.LabelControl4)
        Me.fTabMaindetil_Info.Controls.Add(Me.obj_created_by)
        Me.fTabMaindetil_Info.Controls.Add(Me.LabelControl5)
        Me.fTabMaindetil_Info.Name = "fTabMaindetil_Info"
        Me.fTabMaindetil_Info.Size = New System.Drawing.Size(735, 301)
        Me.fTabMaindetil_Info.Text = "Info"
        '
        'obj_jurnal_isdisabled_dt
        '
        Me.obj_jurnal_isdisabled_dt.Location = New System.Drawing.Point(104, 147)
        Me.obj_jurnal_isdisabled_dt.Name = "obj_jurnal_isdisabled_dt"
        Me.obj_jurnal_isdisabled_dt.Properties.ReadOnly = True
        Me.obj_jurnal_isdisabled_dt.Size = New System.Drawing.Size(120, 20)
        Me.obj_jurnal_isdisabled_dt.TabIndex = 19
        '
        'obj_jurnal_isdisabled_by
        '
        Me.obj_jurnal_isdisabled_by.Location = New System.Drawing.Point(104, 121)
        Me.obj_jurnal_isdisabled_by.Name = "obj_jurnal_isdisabled_by"
        Me.obj_jurnal_isdisabled_by.Properties.ReadOnly = True
        Me.obj_jurnal_isdisabled_by.Size = New System.Drawing.Size(120, 20)
        Me.obj_jurnal_isdisabled_by.TabIndex = 18
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(20, 125)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl9.TabIndex = 17
        Me.LabelControl9.Text = "Disable By"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(20, 151)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl8.TabIndex = 16
        Me.LabelControl8.Text = "Disable Date"
        '
        'obj_posted_dt
        '
        Me.obj_posted_dt.Location = New System.Drawing.Point(104, 95)
        Me.obj_posted_dt.Name = "obj_posted_dt"
        Me.obj_posted_dt.Properties.ReadOnly = True
        Me.obj_posted_dt.Size = New System.Drawing.Size(120, 20)
        Me.obj_posted_dt.TabIndex = 15
        '
        'obj_posted_by
        '
        Me.obj_posted_by.Location = New System.Drawing.Point(104, 70)
        Me.obj_posted_by.Name = "obj_posted_by"
        Me.obj_posted_by.Properties.ReadOnly = True
        Me.obj_posted_by.Size = New System.Drawing.Size(120, 20)
        Me.obj_posted_by.TabIndex = 14
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(20, 99)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl7.TabIndex = 12
        Me.LabelControl7.Text = "Posted Date"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(20, 74)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Posted By"
        '
        'obj_created_dt
        '
        Me.obj_created_dt.Location = New System.Drawing.Point(104, 45)
        Me.obj_created_dt.Name = "obj_created_dt"
        Me.obj_created_dt.Properties.ReadOnly = True
        Me.obj_created_dt.Size = New System.Drawing.Size(120, 20)
        Me.obj_created_dt.TabIndex = 10
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(20, 24)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl4.TabIndex = 3
        Me.LabelControl4.Text = "Create By"
        '
        'obj_created_by
        '
        Me.obj_created_by.Location = New System.Drawing.Point(104, 20)
        Me.obj_created_by.Name = "obj_created_by"
        Me.obj_created_by.Properties.ReadOnly = True
        Me.obj_created_by.Size = New System.Drawing.Size(120, 20)
        Me.obj_created_by.TabIndex = 9
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(20, 49)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl5.TabIndex = 4
        Me.LabelControl5.Text = "Create Date"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.obj_selisih_amountidr)
        Me.PanelControl4.Controls.Add(Me.obj_jumlah_amountidr)
        Me.PanelControl4.Controls.Add(Me.obj_selisih_amount)
        Me.PanelControl4.Controls.Add(Me.obj_jumlah_amount)
        Me.PanelControl4.Controls.Add(Me.LabelControl13)
        Me.PanelControl4.Controls.Add(Me.LabelControl11)
        Me.PanelControl4.Controls.Add(Me.LabelControl12)
        Me.PanelControl4.Controls.Add(Me.LabelControl10)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(0, 328)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(740, 62)
        Me.PanelControl4.TabIndex = 7
        '
        'obj_selisih_amountidr
        '
        Me.obj_selisih_amountidr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_selisih_amountidr.Location = New System.Drawing.Point(599, 37)
        Me.obj_selisih_amountidr.Name = "obj_selisih_amountidr"
        Me.obj_selisih_amountidr.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_selisih_amountidr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_selisih_amountidr.Properties.ReadOnly = True
        Me.obj_selisih_amountidr.Size = New System.Drawing.Size(129, 20)
        Me.obj_selisih_amountidr.TabIndex = 5
        '
        'obj_jumlah_amountidr
        '
        Me.obj_jumlah_amountidr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_jumlah_amountidr.Location = New System.Drawing.Point(599, 11)
        Me.obj_jumlah_amountidr.Name = "obj_jumlah_amountidr"
        Me.obj_jumlah_amountidr.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_jumlah_amountidr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_jumlah_amountidr.Properties.ReadOnly = True
        Me.obj_jumlah_amountidr.Size = New System.Drawing.Size(129, 20)
        Me.obj_jumlah_amountidr.TabIndex = 4
        '
        'obj_selisih_amount
        '
        Me.obj_selisih_amount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_selisih_amount.Location = New System.Drawing.Point(347, 37)
        Me.obj_selisih_amount.Name = "obj_selisih_amount"
        Me.obj_selisih_amount.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_selisih_amount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_selisih_amount.Properties.ReadOnly = True
        Me.obj_selisih_amount.Size = New System.Drawing.Size(129, 20)
        Me.obj_selisih_amount.TabIndex = 3
        '
        'obj_jumlah_amount
        '
        Me.obj_jumlah_amount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.obj_jumlah_amount.Location = New System.Drawing.Point(347, 11)
        Me.obj_jumlah_amount.Name = "obj_jumlah_amount"
        Me.obj_jumlah_amount.Properties.Appearance.Options.UseTextOptions = True
        Me.obj_jumlah_amount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.obj_jumlah_amount.Properties.ReadOnly = True
        Me.obj_jumlah_amount.Size = New System.Drawing.Size(129, 20)
        Me.obj_jumlah_amount.TabIndex = 2
        '
        'LabelControl13
        '
        Me.LabelControl13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl13.Location = New System.Drawing.Point(495, 40)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl13.TabIndex = 1
        Me.LabelControl13.Text = "Selisih Amount (IDR)"
        '
        'LabelControl11
        '
        Me.LabelControl11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl11.Location = New System.Drawing.Point(272, 40)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl11.TabIndex = 1
        Me.LabelControl11.Text = "Selisih Amount"
        '
        'LabelControl12
        '
        Me.LabelControl12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl12.Location = New System.Drawing.Point(491, 14)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(102, 13)
        Me.LabelControl12.TabIndex = 0
        Me.LabelControl12.Text = "Jumlah Amount (IDR)"
        '
        'LabelControl10
        '
        Me.LabelControl10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl10.Location = New System.Drawing.Point(268, 14)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl10.TabIndex = 0
        Me.LabelControl10.Text = "Jumlah Amount"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.obj_jurnal_source)
        Me.PanelControl2.Controls.Add(Me.LabelControl22)
        Me.PanelControl2.Controls.Add(Me.obj_jurnal_descr)
        Me.PanelControl2.Controls.Add(Me.LabelControl21)
        Me.PanelControl2.Controls.Add(Me.obj_jurnal_bookdate)
        Me.PanelControl2.Controls.Add(Me.obj_periode_id)
        Me.PanelControl2.Controls.Add(Me.obj_jurnal_id)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(3, 3)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(740, 101)
        Me.PanelControl2.TabIndex = 5
        '
        'obj_jurnal_source
        '
        Me.obj_jurnal_source.Location = New System.Drawing.Point(342, 19)
        Me.obj_jurnal_source.Name = "obj_jurnal_source"
        Me.obj_jurnal_source.Properties.ReadOnly = True
        Me.obj_jurnal_source.Size = New System.Drawing.Size(152, 20)
        Me.obj_jurnal_source.TabIndex = 12
        Me.obj_jurnal_source.TabStop = False
        '
        'LabelControl22
        '
        Me.LabelControl22.Location = New System.Drawing.Point(271, 23)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl22.TabIndex = 11
        Me.LabelControl22.Text = "Source"
        '
        'obj_jurnal_descr
        '
        Me.obj_jurnal_descr.Location = New System.Drawing.Point(342, 45)
        Me.obj_jurnal_descr.Name = "obj_jurnal_descr"
        Me.obj_jurnal_descr.Properties.ReadOnly = True
        Me.obj_jurnal_descr.Size = New System.Drawing.Size(253, 42)
        Me.obj_jurnal_descr.TabIndex = 10
        Me.obj_jurnal_descr.TabStop = False
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(271, 45)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl21.TabIndex = 9
        Me.LabelControl21.Text = "Description"
        '
        'obj_jurnal_bookdate
        '
        Me.obj_jurnal_bookdate.Location = New System.Drawing.Point(104, 65)
        Me.obj_jurnal_bookdate.Name = "obj_jurnal_bookdate"
        Me.obj_jurnal_bookdate.Properties.ReadOnly = True
        Me.obj_jurnal_bookdate.Size = New System.Drawing.Size(76, 20)
        Me.obj_jurnal_bookdate.TabIndex = 8
        '
        'obj_periode_id
        '
        Me.obj_periode_id.Location = New System.Drawing.Point(104, 42)
        Me.obj_periode_id.Name = "obj_periode_id"
        Me.obj_periode_id.Properties.ReadOnly = True
        Me.obj_periode_id.Size = New System.Drawing.Size(121, 20)
        Me.obj_periode_id.TabIndex = 7
        '
        'obj_jurnal_id
        '
        Me.obj_jurnal_id.Location = New System.Drawing.Point(104, 19)
        Me.obj_jurnal_id.Name = "obj_jurnal_id"
        Me.obj_jurnal_id.Properties.ReadOnly = True
        Me.obj_jurnal_id.Size = New System.Drawing.Size(121, 20)
        Me.obj_jurnal_id.TabIndex = 5
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(20, 23)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(11, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "ID"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(20, 46)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Periode"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(20, 69)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Book Date"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.fTabMain)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 26)
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.PanelControl1.Size = New System.Drawing.Size(753, 522)
        Me.PanelControl1.TabIndex = 5
        '
        'uiTrnDepresiasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "uiTrnDepresiasi"
        Me.Controls.SetChildIndex(Me.PanelControl1, 0)
        CType(Me.fTabMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fTabMain.ResumeLayout(False)
        Me.fTabMain_List.ResumeLayout(False)
        CType(Me.GCTrnJurnal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvTrnJurnal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl8.ResumeLayout(False)
        Me.PanelControl8.PerformLayout()
        Me.fTabMain_data.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.fTabMaindetil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fTabMaindetil.ResumeLayout(False)
        Me.fTabMaindetil_debit.ResumeLayout(False)
        CType(Me.GCTrnJurnalDetilDebit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVJurnalDetilDebit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.obj_amount_debit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_amount_debitidr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fTabMaindetil_credit.ResumeLayout(False)
        CType(Me.GCTrnJurnaldetilCredit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVTrnJurnaldetilCredit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl6.ResumeLayout(False)
        Me.PanelControl6.PerformLayout()
        CType(Me.obj_amount_credit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_amount_creditidr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fTabMaindetil_detil.ResumeLayout(False)
        CType(Me.GCTrnJurnaldetilDepre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvTrnJurnaldetilDepre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl7.ResumeLayout(False)
        Me.PanelControl7.PerformLayout()
        CType(Me.obj_total_depre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fTabMaindetil_detildisposal.ResumeLayout(False)
        CType(Me.GCTrnJurnaldetilDisposal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvTrnJurnalDisposal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fTabMaindetil_Info.ResumeLayout(False)
        Me.fTabMaindetil_Info.PerformLayout()
        CType(Me.obj_jurnal_isdisabled_dt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_jurnal_isdisabled_by.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_posted_dt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_posted_by.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_created_dt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_created_by.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.obj_selisih_amountidr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_jumlah_amountidr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_selisih_amount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_jumlah_amount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.obj_jurnal_source.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_jurnal_descr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_jurnal_bookdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_periode_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_jurnal_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fTabMain As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents fTabMain_List As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents fTabMain_data As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCTrnJurnal As DevExpress.XtraGrid.GridControl
    Friend WithEvents DgvTrnJurnal As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colJurnal_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPeriode_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCreated_by As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCreated_dt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents obj_created_dt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_created_by As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_periode_id As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_jurnal_id As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents fTabMaindetil As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents fTabMaindetil_detil As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCTrnJurnaldetilDepre As DevExpress.XtraGrid.GridControl
    Friend WithEvents DgvTrnJurnaldetilDepre As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents colAsset_barcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colKategoriasset_id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDepresiasi_depremonth As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAsset_deskripsi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnal_bookdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents obj_jurnal_bookdate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents fTabMaindetil_debit As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents fTabMaindetil_credit As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCTrnJurnalDetilDebit As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVJurnalDetilDebit As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colJurnaldetil_line_debit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccname_debit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAcc_id_debit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnaldetil_descr_debit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnaldetil_idr_debit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTrnJurnaldetilCredit As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVTrnJurnaldetilCredit As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colJurnaldetil_line_credit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccName_credit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAcc_id_credit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnaldetil_descr_credit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnaldetil_idr_credit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents fTabMaindetil_Info As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents obj_posted_dt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_posted_by As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_jurnal_isdisabled_dt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_jurnal_isdisabled_by As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents fTabMaindetil_detildisposal As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCTrnJurnaldetilDisposal As DevExpress.XtraGrid.GridControl
    Friend WithEvents DgvTrnJurnalDisposal As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colJurnalDisposal_assetbarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDisposal_Asset_descr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDisposal_Category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDisposalLine As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDisposalID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDisposal_Createby As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDisposal_createdt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDisposal_Postedby As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDisposal_Posteddt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents obj_selisih_amountidr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_jumlah_amountidr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_selisih_amount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_jumlah_amount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_amount_debit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_amount_debitidr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl6 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_amount_credit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents obj_amount_creditidr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents colJurnaldetil_foreign_debit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnaldetil_foreign_credit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl7 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_total_depre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents colJurnaldetil_foreignrate_debit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnaldetil_foreignrate_credit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PanelControl8 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents obj_jurnal_descr As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents obj_jurnal_source As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colJurnal_descr As DevExpress.XtraGrid.Columns.GridColumn

End Class
