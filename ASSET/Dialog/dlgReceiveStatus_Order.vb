Imports System.Windows.Forms

Public Class dlgReceiveStatus_Order

    Private DSN As String
    Private channel_id As String
    Private strukturunit_id As Decimal

    Private tbl_TrnOrder As DataTable = Me.CreateTblTrnOrder()

    Private _value As view_transaksi_order_status

    Private selectedRowHandle As Integer = -1

    Private Function CreateTblTrnOrder() As DataTable
        Dim tbl As DataTable = DatabaseUtils.CreateTbl(Of view_transaksi_order_status)()

        tbl.Columns.Add("check", GetType(Boolean))

        Return tbl
    End Function


    Sub New(ByVal DSN As String, ByVal channel_id As String, ByVal strukturunit_id As Decimal)
        InitializeComponent()

        Me.DSN = DSN
        Me.channel_id = channel_id
        Me.strukturunit_id = strukturunit_id
    End Sub

    Private Sub Retrieve()
        Dim db As New DataClassesFRMDataContext(Me.DSN)
        Dim query As IQueryable(Of view_transaksi_order_status)
        Dim orderTypes As String() = {"PO", "RO", "MO"}
        db.OpenConnectionWithRole()

        query = db.view_transaksi_order_status.Where(Function(p) p.order_canceled = 0 _
                                              And p.strukturunit_id = Me.strukturunit_id _
                                              And p.channel_id = Me.channel_id _
                                              And orderTypes.Contains(p.ordertype_id))

        If chk_order_id.Checked = True Then
            query = query.Where(Function(p) p.order_id = Me.obj_order_id_search.Text)
        End If

        'If chk_order_descr.Checked = True Then
        '    query = query.Where(Function(p) p.order_descr.Contains(Me.obj_order_id_search.Text))
        'End If

        Try
            Me.tbl_TrnOrder.Clear()
            DatabaseUtils.DataFill(Me.tbl_TrnOrder, query)
        Catch ex As Exception
            Throw ex
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Sub

    Private Sub dlgReceiveStatus_Order_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GCOrder.DataSource = Me.tbl_TrnOrder
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Me.Cursor = Cursors.WaitCursor

        Me.Retrieve()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub GVOrder_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVOrder.FocusedRowChanged
        If Me.GVOrder.FocusedRowHandle < 0 Then
            Me.btnOK.Enabled = False
        Else
            Me.btnOK.Enabled = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public ReadOnly Property Value() As view_transaksi_order_status
        Get
            Return Me._value
        End Get
    End Property

    Private Sub RepositoryItemCheckEdit1_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles RepositoryItemCheckEdit1.EditValueChanging
        Select Case e.NewValue
            Case True
                If Me.selectedRowHandle >= 0 Then
                    Me.GVOrder.SetRowCellValue(Me.selectedRowHandle, Me.colCheck, False)
                End If

                Me.selectedRowHandle = Me.GVOrder.FocusedRowHandle
                Me._value = New view_transaksi_order_status()

                clsUtil.DataRowToEntity(Me._value, Me.GVOrder.GetFocusedDataRow())
            Case False
                Me._value = Nothing
                Me.selectedRowHandle = -1
        End Select
    End Sub
End Class
