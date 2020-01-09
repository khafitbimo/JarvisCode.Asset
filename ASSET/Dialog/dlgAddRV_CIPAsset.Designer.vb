<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAddRV_CIPAsset
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.pnlHeader = New DevExpress.XtraEditors.PanelControl()
        Me.lblket = New DevExpress.XtraEditors.LabelControl()
        Me.btnLoadData = New DevExpress.XtraEditors.SimpleButton()
        Me.txtRVID = New DevExpress.XtraEditors.MemoEdit()
        Me.chkSrchRV = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlFooter = New DevExpress.XtraEditors.PanelControl()
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.GCRvListCIP = New DevExpress.XtraGrid.GridControl()
        Me.GVRvListCIP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPilih = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryPilih = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colJurnalID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalLine = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilDK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilDescr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRekananID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRekananName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCurrencyID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJurnalDetilIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBudgetId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBudgetName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBudgetDetilId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBudgetDetilName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnSelectALL = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.pnlHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        CType(Me.txtRVID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSrchRV.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFooter.SuspendLayout()
        CType(Me.GCRvListCIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVRvListCIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPilih, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblket)
        Me.pnlHeader.Controls.Add(Me.btnLoadData)
        Me.pnlHeader.Controls.Add(Me.txtRVID)
        Me.pnlHeader.Controls.Add(Me.chkSrchRV)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(819, 100)
        Me.pnlHeader.TabIndex = 0
        '
        'lblket
        '
        Me.lblket.Location = New System.Drawing.Point(71, 77)
        Me.lblket.Name = "lblket"
        Me.lblket.Size = New System.Drawing.Size(310, 13)
        Me.lblket.TabIndex = 3
        Me.lblket.Text = "Use semicolone (;) to enter more than one references in textbox"
        '
        'btnLoadData
        '
        Me.btnLoadData.Location = New System.Drawing.Point(417, 5)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadData.TabIndex = 2
        Me.btnLoadData.Text = "Load &Data"
        '
        'txtRVID
        '
        Me.txtRVID.Location = New System.Drawing.Point(68, 5)
        Me.txtRVID.Name = "txtRVID"
        Me.txtRVID.Size = New System.Drawing.Size(343, 66)
        Me.txtRVID.TabIndex = 1
        '
        'chkSrchRV
        '
        Me.chkSrchRV.Location = New System.Drawing.Point(12, 5)
        Me.chkSrchRV.Name = "chkSrchRV"
        Me.chkSrchRV.Properties.Caption = "RV ID"
        Me.chkSrchRV.Size = New System.Drawing.Size(50, 19)
        Me.chkSrchRV.TabIndex = 0
        '
        'pnlFooter
        '
        Me.pnlFooter.Controls.Add(Me.btnSelectALL)
        Me.pnlFooter.Controls.Add(Me.btnOk)
        Me.pnlFooter.Controls.Add(Me.btnCancel)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 349)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(819, 46)
        Me.pnlFooter.TabIndex = 1
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(651, 11)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "&OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(732, 11)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "&Cancel"
        '
        'GCRvListCIP
        '
        Me.GCRvListCIP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCRvListCIP.Location = New System.Drawing.Point(0, 100)
        Me.GCRvListCIP.MainView = Me.GVRvListCIP
        Me.GCRvListCIP.Name = "GCRvListCIP"
        Me.GCRvListCIP.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryPilih})
        Me.GCRvListCIP.Size = New System.Drawing.Size(819, 249)
        Me.GCRvListCIP.TabIndex = 2
        Me.GCRvListCIP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVRvListCIP})
        '
        'GVRvListCIP
        '
        Me.GVRvListCIP.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPilih, Me.colJurnalID, Me.colJurnalLine, Me.colJurnalDetilDK, Me.colJurnalDetilDescr, Me.colRekananID, Me.colRekananName, Me.colAccId, Me.colCurrencyID, Me.colJurnalDetilIDR, Me.colBudgetId, Me.colBudgetName, Me.colBudgetDetilId, Me.colBudgetDetilName})
        Me.GVRvListCIP.GridControl = Me.GCRvListCIP
        Me.GVRvListCIP.Name = "GVRvListCIP"
        Me.GVRvListCIP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVRvListCIP.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GVRvListCIP.OptionsView.ColumnAutoWidth = False
        Me.GVRvListCIP.OptionsView.ShowGroupPanel = False
        '
        'colPilih
        '
        Me.colPilih.AppearanceHeader.Options.UseTextOptions = True
        Me.colPilih.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colPilih.Caption = "Pilih"
        Me.colPilih.ColumnEdit = Me.RepositoryPilih
        Me.colPilih.FieldName = "pilih"
        Me.colPilih.Name = "colPilih"
        Me.colPilih.OptionsColumn.AllowSize = False
        Me.colPilih.ShowUnboundExpressionMenu = True
        Me.colPilih.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        Me.colPilih.Visible = True
        Me.colPilih.VisibleIndex = 0
        Me.colPilih.Width = 40
        '
        'RepositoryPilih
        '
        Me.RepositoryPilih.AutoHeight = False
        Me.RepositoryPilih.Name = "RepositoryPilih"
        Me.RepositoryPilih.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'colJurnalID
        '
        Me.colJurnalID.Caption = "Jurnal ID"
        Me.colJurnalID.FieldName = "jurnal_id"
        Me.colJurnalID.Name = "colJurnalID"
        Me.colJurnalID.OptionsColumn.AllowEdit = False
        Me.colJurnalID.OptionsColumn.ReadOnly = True
        Me.colJurnalID.Visible = True
        Me.colJurnalID.VisibleIndex = 1
        Me.colJurnalID.Width = 93
        '
        'colJurnalLine
        '
        Me.colJurnalLine.Caption = "Line"
        Me.colJurnalLine.FieldName = "jurnaldetil_line"
        Me.colJurnalLine.Name = "colJurnalLine"
        Me.colJurnalLine.OptionsColumn.AllowEdit = False
        Me.colJurnalLine.OptionsColumn.ReadOnly = True
        Me.colJurnalLine.Visible = True
        Me.colJurnalLine.VisibleIndex = 2
        Me.colJurnalLine.Width = 93
        '
        'colJurnalDetilDK
        '
        Me.colJurnalDetilDK.FieldName = "jurnaldetil_dk"
        Me.colJurnalDetilDK.Name = "colJurnalDetilDK"
        Me.colJurnalDetilDK.OptionsColumn.AllowEdit = False
        Me.colJurnalDetilDK.OptionsColumn.ReadOnly = True
        '
        'colJurnalDetilDescr
        '
        Me.colJurnalDetilDescr.Caption = "Description"
        Me.colJurnalDetilDescr.FieldName = "jurnaldetil_descr"
        Me.colJurnalDetilDescr.Name = "colJurnalDetilDescr"
        Me.colJurnalDetilDescr.OptionsColumn.AllowEdit = False
        Me.colJurnalDetilDescr.OptionsColumn.ReadOnly = True
        Me.colJurnalDetilDescr.Visible = True
        Me.colJurnalDetilDescr.VisibleIndex = 3
        Me.colJurnalDetilDescr.Width = 93
        '
        'colRekananID
        '
        Me.colRekananID.Caption = "Rekanan ID"
        Me.colRekananID.FieldName = "rekanan_id"
        Me.colRekananID.Name = "colRekananID"
        Me.colRekananID.OptionsColumn.AllowEdit = False
        Me.colRekananID.OptionsColumn.ReadOnly = True
        '
        'colRekananName
        '
        Me.colRekananName.Caption = "Rekanan Name"
        Me.colRekananName.FieldName = "rekanan_name"
        Me.colRekananName.Name = "colRekananName"
        Me.colRekananName.OptionsColumn.AllowEdit = False
        Me.colRekananName.OptionsColumn.ReadOnly = True
        Me.colRekananName.Visible = True
        Me.colRekananName.VisibleIndex = 4
        Me.colRekananName.Width = 93
        '
        'colAccId
        '
        Me.colAccId.Caption = "Acc ID"
        Me.colAccId.FieldName = "acc_id"
        Me.colAccId.Name = "colAccId"
        Me.colAccId.OptionsColumn.AllowEdit = False
        Me.colAccId.OptionsColumn.ReadOnly = True
        Me.colAccId.Visible = True
        Me.colAccId.VisibleIndex = 5
        Me.colAccId.Width = 93
        '
        'colCurrencyID
        '
        Me.colCurrencyID.Caption = "Currency ID"
        Me.colCurrencyID.FieldName = "currency_id"
        Me.colCurrencyID.Name = "colCurrencyID"
        Me.colCurrencyID.OptionsColumn.AllowEdit = False
        Me.colCurrencyID.OptionsColumn.ReadOnly = True
        Me.colCurrencyID.Visible = True
        Me.colCurrencyID.VisibleIndex = 9
        '
        'colJurnalDetilIDR
        '
        Me.colJurnalDetilIDR.Caption = "Amount (IDR)"
        Me.colJurnalDetilIDR.DisplayFormat.FormatString = "n2"
        Me.colJurnalDetilIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colJurnalDetilIDR.FieldName = "jurnaldetil_idr"
        Me.colJurnalDetilIDR.Name = "colJurnalDetilIDR"
        Me.colJurnalDetilIDR.OptionsColumn.AllowEdit = False
        Me.colJurnalDetilIDR.OptionsColumn.ReadOnly = True
        Me.colJurnalDetilIDR.Visible = True
        Me.colJurnalDetilIDR.VisibleIndex = 6
        Me.colJurnalDetilIDR.Width = 93
        '
        'colBudgetId
        '
        Me.colBudgetId.Caption = "Budget ID"
        Me.colBudgetId.FieldName = "budget_id"
        Me.colBudgetId.Name = "colBudgetId"
        Me.colBudgetId.OptionsColumn.AllowEdit = False
        Me.colBudgetId.OptionsColumn.ReadOnly = True
        '
        'colBudgetName
        '
        Me.colBudgetName.Caption = "Budget Name"
        Me.colBudgetName.FieldName = "budget_name"
        Me.colBudgetName.Name = "colBudgetName"
        Me.colBudgetName.OptionsColumn.AllowEdit = False
        Me.colBudgetName.OptionsColumn.ReadOnly = True
        Me.colBudgetName.Visible = True
        Me.colBudgetName.VisibleIndex = 7
        Me.colBudgetName.Width = 93
        '
        'colBudgetDetilId
        '
        Me.colBudgetDetilId.Caption = "Budget Detil ID"
        Me.colBudgetDetilId.FieldName = "budgetdetil_id"
        Me.colBudgetDetilId.Name = "colBudgetDetilId"
        Me.colBudgetDetilId.OptionsColumn.AllowEdit = False
        Me.colBudgetDetilId.OptionsColumn.ReadOnly = True
        '
        'colBudgetDetilName
        '
        Me.colBudgetDetilName.Caption = "Budget Detil Name"
        Me.colBudgetDetilName.FieldName = "budgetdetil_name"
        Me.colBudgetDetilName.Name = "colBudgetDetilName"
        Me.colBudgetDetilName.OptionsColumn.AllowEdit = False
        Me.colBudgetDetilName.OptionsColumn.ReadOnly = True
        Me.colBudgetDetilName.Visible = True
        Me.colBudgetDetilName.VisibleIndex = 8
        Me.colBudgetDetilName.Width = 107
        '
        'btnSelectALL
        '
        Me.btnSelectALL.Location = New System.Drawing.Point(14, 9)
        Me.btnSelectALL.Name = "btnSelectALL"
        Me.btnSelectALL.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectALL.TabIndex = 2
        Me.btnSelectALL.Text = "Select ALL"
        '
        'dlgAddRV_CIPAsset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 395)
        Me.Controls.Add(Me.GCRvListCIP)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "dlgAddRV_CIPAsset"
        Me.Text = "RV List CIP Asset"
        CType(Me.pnlHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.txtRVID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSrchRV.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFooter.ResumeLayout(False)
        CType(Me.GCRvListCIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVRvListCIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPilih, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtRVID As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents chkSrchRV As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnLoadData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblket As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlFooter As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCRvListCIP As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVRvListCIP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colJurnalID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalLine As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilDK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilDescr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRekananID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRekananName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCurrencyID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJurnalDetilIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBudgetId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBudgetName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBudgetDetilId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBudgetDetilName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPilih As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryPilih As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents btnSelectALL As DevExpress.XtraEditors.SimpleButton
End Class
