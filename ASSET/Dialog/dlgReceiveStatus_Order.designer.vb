<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgReceiveStatus_Order
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.chk_order_id = New DevExpress.XtraEditors.CheckEdit()
        Me.btnLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.obj_order_id_search = New DevExpress.XtraEditors.TextEdit()
        Me.GCOrder = New DevExpress.XtraGrid.GridControl()
        Me.GVOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCheck = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colOrderID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderDescr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrderStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.chk_order_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.obj_order_id_search.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.chk_order_id)
        Me.PanelControl1.Controls.Add(Me.btnLoad)
        Me.PanelControl1.Controls.Add(Me.obj_order_id_search)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(3, 3)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(838, 59)
        Me.PanelControl1.TabIndex = 0
        '
        'chk_order_id
        '
        Me.chk_order_id.EditValue = True
        Me.chk_order_id.Enabled = False
        Me.chk_order_id.Location = New System.Drawing.Point(20, 23)
        Me.chk_order_id.Name = "chk_order_id"
        Me.chk_order_id.Properties.Caption = "Order ID"
        Me.chk_order_id.Size = New System.Drawing.Size(75, 19)
        Me.chk_order_id.TabIndex = 3
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(294, 21)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Text = "Load Data"
        '
        'obj_order_id_search
        '
        Me.obj_order_id_search.Location = New System.Drawing.Point(101, 22)
        Me.obj_order_id_search.Name = "obj_order_id_search"
        Me.obj_order_id_search.Size = New System.Drawing.Size(187, 20)
        Me.obj_order_id_search.TabIndex = 1
        '
        'GCOrder
        '
        Me.GCOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCOrder.Location = New System.Drawing.Point(3, 65)
        Me.GCOrder.MainView = Me.GVOrder
        Me.GCOrder.Name = "GCOrder"
        Me.GCOrder.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCOrder.Size = New System.Drawing.Size(838, 377)
        Me.GCOrder.TabIndex = 1
        Me.GCOrder.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOrder})
        '
        'GVOrder
        '
        Me.GVOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCheck, Me.colOrderID, Me.colOrderDate, Me.colOrderDescr, Me.colOrderStatus})
        Me.GVOrder.GridControl = Me.GCOrder
        Me.GVOrder.Name = "GVOrder"
        Me.GVOrder.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GVOrder.OptionsView.ColumnAutoWidth = False
        Me.GVOrder.OptionsView.ShowGroupPanel = False
        '
        'colCheck
        '
        Me.colCheck.Caption = " "
        Me.colCheck.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.colCheck.FieldName = "check"
        Me.colCheck.Name = "colCheck"
        Me.colCheck.Visible = True
        Me.colCheck.VisibleIndex = 0
        Me.colCheck.Width = 30
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Caption = ""
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'colOrderID
        '
        Me.colOrderID.Caption = "Order ID"
        Me.colOrderID.FieldName = "order_id"
        Me.colOrderID.Name = "colOrderID"
        Me.colOrderID.OptionsColumn.AllowEdit = False
        Me.colOrderID.Visible = True
        Me.colOrderID.VisibleIndex = 1
        Me.colOrderID.Width = 100
        '
        'colOrderDate
        '
        Me.colOrderDate.Caption = "Order Date"
        Me.colOrderDate.FieldName = "order_date"
        Me.colOrderDate.Name = "colOrderDate"
        Me.colOrderDate.OptionsColumn.AllowEdit = False
        Me.colOrderDate.Visible = True
        Me.colOrderDate.VisibleIndex = 2
        Me.colOrderDate.Width = 100
        '
        'colOrderDescr
        '
        Me.colOrderDescr.Caption = "Description"
        Me.colOrderDescr.FieldName = "order_descr"
        Me.colOrderDescr.Name = "colOrderDescr"
        Me.colOrderDescr.OptionsColumn.AllowEdit = False
        Me.colOrderDescr.Visible = True
        Me.colOrderDescr.VisibleIndex = 3
        Me.colOrderDescr.Width = 400
        '
        'colOrderStatus
        '
        Me.colOrderStatus.Caption = "Status"
        Me.colOrderStatus.FieldName = "status"
        Me.colOrderStatus.Name = "colOrderStatus"
        Me.colOrderStatus.OptionsColumn.AllowEdit = False
        Me.colOrderStatus.Visible = True
        Me.colOrderStatus.VisibleIndex = 4
        Me.colOrderStatus.Width = 100
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(677, 6)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(758, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btnOK)
        Me.PanelControl2.Controls.Add(Me.btnCancel)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(3, 445)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(838, 40)
        Me.PanelControl2.TabIndex = 4
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(3, 62)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(838, 3)
        Me.PanelControl3.TabIndex = 5
        '
        'PanelControl4
        '
        Me.PanelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(3, 442)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(838, 3)
        Me.PanelControl4.TabIndex = 6
        '
        'dlgReceiveStatus_Order
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 488)
        Me.Controls.Add(Me.GCOrder)
        Me.Controls.Add(Me.PanelControl4)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgReceiveStatus_Order"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Order"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.chk_order_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.obj_order_id_search.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents obj_order_id_search As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GCOrder As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents colOrderID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderDescr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrderStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents chk_order_id As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents colCheck As DevExpress.XtraGrid.Columns.GridColumn

End Class
