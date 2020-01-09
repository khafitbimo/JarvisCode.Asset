Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class uiTrnReceiveStatus
    Private Const mUiName As String = "Receive Status Transaction"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormAfterNew()
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)

    Private FILTER_QUERY_MODE As Boolean

    Private tbl_TrnReceiveStatus As DataTable = DatabaseUtils.CreateTbl(Of view_transaksi_receivestatus)()
    Private tbl_TrnReceiveStatus_Temp As DataTable = DatabaseUtils.CreateTbl(Of view_transaksi_receivestatus)()
    Private tbl_TrnReceiveStatusAttach As DataTable = DatabaseUtils.CreateTbl(Of transaksi_receivestatusattach)()
    Private tbl_TrnPenerimaanBarang As DataTable = DatabaseUtils.CreateTbl(Of transaksi_penerimaanbarang)()

    Private listAttachmentTemp As New Dictionary(Of Integer, String)

    Private btnNewClick As Boolean = False

    Private WithEvents tbtnReject As DevExpress.XtraBars.BarButtonItem = Me.CreateTbtnReject()

    Enum ModuleType
        User = 1
        SPV = 2
        DeptHead = 3
    End Enum

#Region " Window Parameter "
    Private _CHANNEL As String = "TAS"
    Private _STRUKTURUNIT_ID As Decimal = 5560
    Private _MODULE_TYPE As ModuleType = ModuleType.SPV
#End Region

    Private Function CreateTbtnReject() As DevExpress.XtraBars.BarButtonItem
        Dim btn As New DevExpress.XtraBars.BarButtonItem()

        btn.Caption = "Reject"
        btn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

        Return btn
    End Function

#Region " Overrides "

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible
        If Me.PnlDfSearch.Visible Then
            FILTER_QUERY_MODE = True
            Me.tbtnQuery.Checked = True
        Else
            FILTER_QUERY_MODE = False
            Me.tbtnQuery.Checked = False
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnNew_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor

        Me.btnNewClick = True

        If Me.xTabMain.SelectedTabPageIndex = 0 Then
            Me.xTabMain.SelectedTabPageIndex = 1
        End If

        Me.uiTrnReceiveStatus_NewData()

        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnReceiveStatus_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        'If Me.uiTrnConsumable_FormError() Then
        '    Return True
        'End If

        Me.Cursor = Cursors.WaitCursor

        Me.uiTrnReceiveStatus_Save()

        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnReceiveStatus_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnPosting_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnReceiveStatus_Approve()
        Me.Cursor = Cursors.Default

        Return MyBase.btnPosting_Click()
    End Function

    Public Overrides Function btnUnposting_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor

        Me.uiTrnReceiveStatus_Unapprove()

        Me.Cursor = Cursors.Default

        Return MyBase.btnUnposting_Click()
    End Function

#End Region

#Region "Layout & Init UI"
    Private Function InitLayoutUI() As Boolean
        Me.obj_approval_search.Properties.Items.AddRange(New Object() {"New", "Approve", "Reject"})

        Select Case Me._MODULE_TYPE
            Case ModuleType.User
                Me.tbtnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Me.chk_approval_status.Checked = False
            Case ModuleType.SPV
                Me.tbtnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Me.chk_approval_status.Checked = True
            Case ModuleType.DeptHead
                Me.tbtnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Me.chk_approval_status.Checked = True
        End Select

        Me.obj_approval_search.SelectedIndex = 0

        Me.tbtnPosting.Caption = "Approve"
        Me.tbtnUnposting.Caption = "Unapprove"

        Me.PnlDfSearch.Visible = False

        Me.GCReceiveStatus.DataSource = Me.tbl_TrnReceiveStatus

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True
        Me.tbtnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.tbtnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Function

    Private Function BindingStop() As Boolean
        Me.obj_receivestatus_id.DataBindings.Clear()
        Me.obj_order_id.DataBindings.Clear()
        Me.obj_order_descr.DataBindings.Clear()
        Me.obj_receivestatus_newstatus.DataBindings.Clear()
        Me.obj_receivestatus_oldstatus.DataBindings.Clear()
        Me.obj_receivestatus_descr.DataBindings.Clear()
        Me.obj_create_by.DataBindings.Clear()
        Me.obj_create_dt.DataBindings.Clear()
        Me.obj_approved1_by.DataBindings.Clear()
        Me.obj_approved1_dt.DataBindings.Clear()
        Me.obj_approved2_by.DataBindings.Clear()
        Me.obj_approved2_dt.DataBindings.Clear()
        Me.obj_approved3_by.DataBindings.Clear()
        Me.obj_approved3_dt.DataBindings.Clear()
        Me.obj_rejected_by.DataBindings.Clear()
        Me.obj_rejected_dt.DataBindings.Clear()

        Return True
    End Function

    Private Function BindingStart() As Boolean
        Me.obj_receivestatus_id.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "receivestatus_id")
        Me.obj_order_id.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "order_id")
        Me.obj_order_descr.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "order_descr")
        Me.obj_receivestatus_oldstatus.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "receivestatus_oldstatus")
        Me.obj_receivestatus_newstatus.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "receivestatus_newstatus")
        Me.obj_receivestatus_descr.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "receivestatus_descr")
        Me.obj_create_by.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "create_by_fullname")
        Me.obj_create_dt.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "create_dt", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy HH:mm")
        Me.obj_approved1_by.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "approved1_by_fullname")
        Me.obj_approved1_dt.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "approved1_dt", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy HH:mm")
        Me.obj_approved2_by.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "approved2_by_fullname")
        Me.obj_approved2_dt.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "approved2_dt", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy HH:mm")
        Me.obj_approved3_by.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "approved3_by_fullname")
        Me.obj_approved3_dt.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "approved3_dt", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy HH:mm")
        Me.obj_rejected_by.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "rejected_by_fullname")
        Me.obj_rejected_dt.DataBindings.Add("Text", Me.tbl_TrnReceiveStatus_Temp, "rejected_dt", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy HH:mm")

        Return True
    End Function
#End Region

#Region " User Defined Control "
    Private Function uiTrnReceiveStatus_NewData() As Boolean
        RaiseEvent FormBeforeNew()

        Me.tbl_TrnReceiveStatus_Temp.Clear()
        Me.tbl_TrnReceiveStatus_Temp.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnReceiveStatus_Temp.Columns("strukturunit_id").DefaultValue = Me._STRUKTURUNIT_ID
        Me.tbl_TrnReceiveStatus_Temp.Columns("create_by").DefaultValue = Me.UserName

        Me.tbl_TrnReceiveStatusAttach.Clear()
        Me.tbl_TrnReceiveStatusAttach = DatabaseUtils.CreateTbl(Of transaksi_receivestatusattach)()
        Me.tbl_TrnReceiveStatusAttach.Columns("receivestatus_id").DefaultValue = Me.obj_receivestatus_id.Text
        Me.tbl_TrnReceiveStatusAttach.Columns("line").DefaultValue = DBNull.Value
        Me.tbl_TrnReceiveStatusAttach.Columns("line").AutoIncrement = True
        Me.tbl_TrnReceiveStatusAttach.Columns("line").AutoIncrementSeed = 10
        Me.tbl_TrnReceiveStatusAttach.Columns("line").AutoIncrementStep = 10

        Me.GCAttachment.DataSource = Me.tbl_TrnReceiveStatusAttach

        Me.BindingContext(Me.tbl_TrnReceiveStatus_Temp).EndCurrentEdit()

        Try
            Me.BindingContext(Me.tbl_TrnReceiveStatus_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

        RaiseEvent FormAfterNew()
    End Function

    Private Function uiTrnReceiveStatus_Retrieve() As Boolean
        Dim db As New DataClassesFRMDataContext(Me.DSNLinq)
        Dim query As IQueryable(Of view_transaksi_receivestatus)

        query = db.view_transaksi_receivestatus.Where(Function(p) p.channel_id = Me._CHANNEL And p.canceled = 0 And p.strukturunit_id = Me._STRUKTURUNIT_ID)

        If Me.chk_receivestatus_id_search.Checked Then
            query = query.Where(Function(p) p.receivestatus_id = Me.obj_receivestatus_id_search.Text)
        End If

        If Me.chk_order_id_search.Checked Then
            query = query.Where(Function(p) p.order_id = Me.obj_order_id_search.Text)
        End If

        Select Case Me._MODULE_TYPE
            Case ModuleType.User
                If Me.chk_approval_status.Checked = True Then
                    Select Case Me.obj_approval_search.SelectedIndex
                        Case 0 'New
                            query = query.Where(Function(p) p.approved1 = 0)
                        Case 1 'Approve
                            query = query.Where(Function(p) p.approved1 = 1 And p.rejected = 0)
                        Case 2 'Reject
                            query = query.Where(Function(p) p.rejected = 1)
                    End Select
                End If
            Case ModuleType.SPV
                query = query.Where(Function(p) p.approved1_to = Me.UserName)

                If Me.chk_approval_status.Checked = True Then
                    Select Case Me.obj_approval_search.SelectedIndex
                        Case 0 'New
                            query = query.Where(Function(p) p.approved2 = 0)
                        Case 1 'Approve
                            query = query.Where(Function(p) p.approved2 = 1 And p.rejected = 0)
                        Case 2 'Reject
                            query = query.Where(Function(p) p.rejected = 1)
                    End Select
                End If
            Case ModuleType.DeptHead
                query = query.Where(Function(p) p.approved2_to = Me.UserName)

                If Me.chk_approval_status.Checked = True Then
                    Select Case Me.obj_approval_search.SelectedIndex
                        Case 0 'New
                            query = query.Where(Function(p) p.approved3 = 0)
                        Case 1 'Approve
                            query = query.Where(Function(p) p.approved3 = 1 And p.rejected = 0)
                        Case 2 'Reject
                            query = query.Where(Function(p) p.rejected = 1)
                    End Select
                End If
        End Select

        query = query.OrderByDescending(Function(p) p.receivestatus_id)

        Try
            Me.tbl_TrnReceiveStatus.Clear()

            db.OpenConnectionWithRole()
            DatabaseUtils.DataFill(Me.tbl_TrnReceiveStatus, query)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Function

    Private Function uiTrnReceiveStatus_Save() As Boolean
        ''save data

        Dim tbl_TrnReceiveStatus_Temp_Changes As DataTable
        Dim tbl_TrnReceiveStatusAttach_Changes As DataTable
        Dim receivestatus_id As Object = New Object()
        Dim result As FormSaveResult

        RaiseEvent FormBeforeSave(receivestatus_id)

        Me.BindingContext(Me.tbl_TrnReceiveStatus_Temp).EndCurrentEdit()
        tbl_TrnReceiveStatus_Temp_Changes = Me.tbl_TrnReceiveStatus_Temp.GetChanges()

        Me.GCAttachment.EndUpdate()
        Me.BindingContext(Me.tbl_TrnReceiveStatusAttach).EndCurrentEdit()
        tbl_TrnReceiveStatusAttach_Changes = Me.tbl_TrnReceiveStatusAttach.GetChanges()

        If tbl_TrnReceiveStatus_Temp_Changes IsNot Nothing Or tbl_TrnReceiveStatusAttach_Changes IsNot Nothing Then
            Try
                receivestatus_id = Me.tbl_TrnReceiveStatus_Temp.Rows(0).Item("receivestatus_id")

                Dim objTbl_Temp As DataTable = clsDataset.CreateTblFromUDTableTypes(Me.DSNLinq, "transaksi_receivestatus_list")
                Dim objTbl_Attach As DataTable = clsDataset.CreateTblFromUDTableTypes(Me.DSNLinq, "transaksi_receivestatusattach_list")
                Dim objTbl_Attachment As DataTable = clsDataset.CreateTblFromUDTableTypes(Me.DSNLinq, "transaksi_receivestatusattachment_list")

                If tbl_TrnReceiveStatus_Temp_Changes IsNot Nothing Then
                    clsUtil.CopyToDatatableWithFlag(tbl_TrnReceiveStatus_Temp_Changes, objTbl_Temp)
                End If

                If tbl_TrnReceiveStatusAttach_Changes IsNot Nothing Then
                    clsUtil.CopyToDatatableWithFlag(tbl_TrnReceiveStatusAttach_Changes, objTbl_Attach)

                    Dim newRow As DataRow
                    Dim attachment As New transaksi_receivestatusattachment()
                    Dim fi As IO.FileInfo

                    For Each item In Me.listAttachmentTemp
                        fi = New IO.FileInfo(item.Value)

                        newRow = objTbl_Attachment.NewRow()

                        attachment.receivestatus_id = receivestatus_id
                        attachment.line = item.Key
                        attachment.filedata = New Data.Linq.Binary(My.Computer.FileSystem.ReadAllBytes(fi.FullName))
                        attachment.extension = fi.Extension

                        clsUtil.EntityToDataRow(attachment, newRow)

                        newRow.Item("flag_execute") = 1

                        objTbl_Attachment.Rows.Add(newRow)
                    Next
                End If

                Me.uiTrnReceiveStatus_SaveData(objTbl_Temp, objTbl_Attach, objTbl_Attachment, receivestatus_id)

                Me.tbl_TrnReceiveStatus_Temp.AcceptChanges()
                Me.tbl_TrnReceiveStatusAttach.AcceptChanges()
                Me.listAttachmentTemp.Clear()

                result = FormSaveResult.SaveSuccess

                If SHOW_SAVE_CONFIRMATION = True Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        RaiseEvent FormAfterSave(receivestatus_id, result)

        Me.Cursor = Cursors.Arrow
    End Function

    Private Sub uiTrnReceiveStatus_SaveData(ByVal tbl_TrnReceiveStatus_Temp_Changes As DataTable,
                                            ByVal tbl_TrnReceiveStatusAttach_Changes As DataTable,
                                            ByVal tbl_TrnReceiveStatusAttachment_Changes As DataTable,
                                            ByRef id As Object)

        Dim receivestatus_id As String = id

        StoreProcedures.as_IUDReceiveStatus(Me.DSNLinq,
                                            Me._CHANNEL,
                                            tbl_TrnReceiveStatus_Temp_Changes,
                                            tbl_TrnReceiveStatusAttach_Changes,
                                            tbl_TrnReceiveStatusAttachment_Changes,
                                            receivestatus_id)

        Dim db As New DataClassesFRMDataContext(Me.DSNLinq)
        Dim receivestatus As view_transaksi_receivestatus

        db.OpenConnectionWithRole()

        Try
            'Sinkronisasi data header
            '----------------------------------------------------------------------------------------------------------------
            receivestatus = db.view_transaksi_receivestatus.Where(Function(p) p.receivestatus_id = receivestatus_id).First()

            clsUtil.EntityToDataRow(receivestatus, Me.tbl_TrnReceiveStatus_Temp.Rows(0))
            '----------------------------------------------------------------------------------------------------------------

            id = receivestatus_id

            Dim dataState = Me.tbl_TrnReceiveStatus_Temp.Rows(0).RowState

            Select Case dataState
                Case DataRowState.Added
                    Me.tbl_TrnReceiveStatus.Merge(Me.tbl_TrnReceiveStatus_Temp)

                    For i As Integer = 0 To GVReceiveStatus.RowCount - 1
                        If Me.GVReceiveStatus.GetRowCellValue(i, "receivestatus_id") = receivestatus_id Then
                            Me.GVReceiveStatus.FocusedRowHandle = i
                        End If
                    Next
                Case DataRowState.Modified
                    Me.uiTrnReceveiStatus_UpdateList()
            End Select
        Catch ex As Exception
            Throw ex
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Sub

    Private Function uiTrnReceiveStatus_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim db As New DataClassesFRMDataContext(Me.DSNLinq)
        Dim receivestatus_id As String
        Dim order_id As String
        Dim channel_id As String

        receivestatus_id = Me.GVReceiveStatus.GetDataRow(rowIndex).Item("receivestatus_id") 'Me.GVReceiveStatus.GetFocusedRowCellValue("receivestatus_id")
        order_id = Me.GVReceiveStatus.GetDataRow(rowIndex).Item("order_id") 'Me.GVReceiveStatus.GetFocusedRowCellValue("order_id")
        channel_id = Me.GVReceiveStatus.GetDataRow(rowIndex).Item("channel_id") 'Me.GVReceiveStatus.GetFocusedRowCellValue("channel_id")

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(receivestatus_id)

        Try
            db.OpenConnectionWithRole()

            Me.uiTrnReceiveStatus_OpenRowMaster(channel_id, receivestatus_id, db)
            Me.uiTrnReceiveStatus_OpenRowAttach(channel_id, receivestatus_id, db)
            Me.uiTrnReceiveStatus_OpenRowRV(channel_id, order_id, db)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnReceiveStatus_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            db.CloseConnectionWithRole()
        End Try

        RaiseEvent FormAfterOpenRow(receivestatus_id)
        Me.Cursor = Cursors.Arrow

        Return True
    End Function

    Private Function uiTrnReceiveStatus_OpenRowMaster(ByVal channel_id As String,
                                                      ByVal receivestatus_id As String,
                                                      ByVal db As DataClassesFRMDataContext) As Boolean
        Dim query As IQueryable(Of view_transaksi_receivestatus)

        Me.tbl_TrnReceiveStatus_Temp.Clear()

        Try
            Me.BindingStop()

            query = db.view_transaksi_receivestatus.Where(Function(p) p.receivestatus_id = receivestatus_id)

            DatabaseUtils.DataFill(Me.tbl_TrnReceiveStatus_Temp, query)

            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnConsumable_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function uiTrnReceiveStatus_OpenRowAttach(ByVal channel_id As String, ByVal receivestatus_id As String, ByVal db As DataClassesFRMDataContext) As Boolean
        Dim query As IQueryable(Of transaksi_receivestatusattach)

        Me.tbl_TrnReceiveStatusAttach.Clear()

        Me.tbl_TrnReceiveStatusAttach = DatabaseUtils.CreateTbl(Of transaksi_receivestatusattach)()
        Me.tbl_TrnReceiveStatusAttach.Columns("receivestatus_id").DefaultValue = receivestatus_id
        Me.tbl_TrnReceiveStatusAttach.Columns("line").DefaultValue = DBNull.Value
        Me.tbl_TrnReceiveStatusAttach.Columns("line").AutoIncrement = True
        Me.tbl_TrnReceiveStatusAttach.Columns("line").AutoIncrementSeed = 10
        Me.tbl_TrnReceiveStatusAttach.Columns("line").AutoIncrementStep = 10

        Try
            query = db.transaksi_receivestatusattaches.Where(Function(p) p.receivestatus_id = receivestatus_id)

            DatabaseUtils.DataFill(Me.tbl_TrnReceiveStatusAttach, query)

            Me.GCAttachment.DataSource = Me.tbl_TrnReceiveStatusAttach
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnReceiveStatus_OpenRowAttach()" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function uiTrnReceiveStatus_OpenRowRV(ByVal channel_id As String, ByVal order_id As String, ByVal db As DataClassesFRMDataContext) As Boolean
        Dim query As IQueryable(Of transaksi_penerimaanbarang)

        Try
            query = db.transaksi_penerimaanbarangs.Where(Function(p) p.order_id = order_id And p.terimabarang_isdisabled = 0)

            Me.tbl_TrnPenerimaanBarang.Clear()

            DatabaseUtils.DataFill(Me.tbl_TrnPenerimaanBarang, query)

            Me.GCRV.DataSource = Me.tbl_TrnPenerimaanBarang
        Catch ex As Exception
            Throw New Exception(mUiName & "uiTrnReceiveStatus_OpenRowRV" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Sub uiTrnReceiveStatus_RefreshPosition()
        If Me.xTabMain.SelectedTabPageIndex = 1 Then
            Me.uiTrnReceiveStatus_OpenRow(Me.GVReceiveStatus.FocusedRowHandle)
        End If
    End Sub

    Private Sub uiTrnReceveiStatus_UpdateList()
        Dim currenRow As DataRow = Me.GVReceiveStatus.GetDataRow(Me.GVReceiveStatus.FocusedRowHandle)

        currenRow.ItemArray = Me.tbl_TrnReceiveStatus_Temp.Rows(0).ItemArray
        currenRow.AcceptChanges()
    End Sub

    Private Sub uiTrnReceiveStatus_Approve()
        Dim db As New DataClassesFRMDataContext(Me.DSNLinq)

        db.OpenConnectionWithRole()

        Try
            If Me._MODULE_TYPE = ModuleType.DeptHead Then
                db.as_TrnReceiveStatusApprove(Me.obj_receivestatus_id.Text, Me._MODULE_TYPE, "")

                Me.uiTrnReceiveStatus_RefreshPosition()
            Else
                Dim dlg As New DlgReceiveStatus_ApproveTo(Me.DSNLinq, Me._STRUKTURUNIT_ID, Me._MODULE_TYPE)

                If dlg.ShowDialog() = DialogResult.OK Then
                    db.as_TrnReceiveStatusApprove(Me.obj_receivestatus_id.Text, Me._MODULE_TYPE, dlg.LUSendTo.EditValue)

                    If dlg.LUSendTo.EditValue.ToString() <> "" Then
                        Me.SendEmailApprove(Me.obj_order_id.Text.Trim,
                                     Me.obj_receivestatus_oldstatus.Text,
                                     Me.obj_receivestatus_newstatus.Text,
                                     Me.UserName,
                                     dlg.LUSendTo.EditValue,
                                     db)
                    End If

                    Me.uiTrnReceiveStatus_RefreshPosition()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Sub

    Private Sub SendEmailApprove(ByVal orderID As String,
                          ByVal oldStatus As String,
                          ByVal newStatus As String,
                          ByVal username As String,
                          ByVal userTo As String,
                          ByVal db As DataClassesFRMDataContext)
        Dim emailBody As master_emailbodypath

        Try
            emailBody = db.master_emailbodypaths.Where(Function(p) p.name = "RS_Approval").FirstOrDefault()

            Dim email As New Net.Mail.MailMessage()
            Dim getEmailSubject = Function() As String
                                      Dim subject As String

                                      subject = emailBody.email_subject

                                      subject = subject.Replace("@receive_status", Me.obj_receivestatus_id.Text)

                                      Return subject
                                  End Function
            Dim getEmailBodyPath = Function() As String
                                       Dim body As String
                                       Dim user As master_user

                                       user = db.master_users.Where(Function(p) p.username = username).FirstOrDefault()
                                       body = emailBody.email_bodypath

                                       body = body.Replace("@order_id", orderID)
                                       body = body.Replace("@old_status", oldStatus)
                                       body = body.Replace("@new_status", newStatus)
                                       body = body.Replace("@user", user.user_fullname)

                                       Return body
                                   End Function
            Dim getSendTo = Function() As String
                                Dim user As master_useremail

                                user = db.master_useremails.Where(Function(p) p.username = userTo And p.user_emaildefault = 1).FirstOrDefault()

                                Return user.user_email
                            End Function

            email.From = New Net.Mail.MailAddress(clsEmail.GetGambaEmail())
            email.To.Add(getSendTo())
            email.Subject = getEmailSubject()
            email.Body = getEmailBodyPath()
            email.IsBodyHtml = True

            clsEmail.Send(email, clsEmail.GetGambaEmailCredential())
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub SendEmailRejected(ByVal receive_id As String)
    '    Dim db As New DataClassesFRMDataContext(Me.DSNLinq)

    '    db.OpenConnectionWithRole()

    '    Try
    '        Dim emailBody = db.master_emailbodypaths.Where(Function(p) p.name = "RS_Rejected").FirstOrDefault()
    '        Dim email As New Net.Mail.MailMessage()
    '        Dim getEmailSubject = Function() As String
    '                                  Dim subject As String

    '                                  subject = emailBody.email_subject

    '                                  subject = subject.Replace("@receive_status", Me.obj_receivestatus_id.Text)

    '                                  Return subject
    '                              End Function
    '        Dim getEmailBodyPath = Function() As String
    '                                   Dim body As String
    '                                   Dim user As master_user

    '                                   user = db.master_users.Where(Function(p) p.username = UserName).FirstOrDefault()
    '                                   body = emailBody.email_bodypath

    '                                   body = body.Replace("@order_id", orderID)
    '                                   body = body.Replace("@old_status", oldStatus)
    '                                   body = body.Replace("@new_status", newStatus)
    '                                   body = body.Replace("@user", user.user_fullname)

    '                                   Return body
    '                               End Function
    '        Dim getSendTo = Function() As String
    '                            Dim receive As view_transaksi_receivestatus
    '                            Dim userEmail As master_useremail

    '                            receive = db.view_transaksi_receivestatus.Where(Function(p) p.receivestatus_id = receive_id).FirstOrDefault()
    '                            userEmail = db.master_useremails.Where(Function(p) p.username = receive.create_by And p.user_emaildefault = 1).FirstOrDefault()

    '                            Return userEmail.user_email
    '                        End Function
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        db.CloseConnectionWithRole()
    '    End Try
    'End Sub

    Private Sub uiTrnReceiveStatus_Unapprove()
        Dim db As New DataClassesFRMDataContext(Me.DSNLinq)

        db.OpenConnectionWithRole()
        Try
            db.as_TrnReceiveStatusUnapprove(Me.obj_receivestatus_id.Text.Trim, Me._MODULE_TYPE)

            Me.uiTrnReceiveStatus_RefreshPosition()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Sub

    Private Sub uiTrnReceiveStatus_Reject()
        Dim db As New DataClassesFRMDataContext(Me.DSNLinq)

        db.OpenConnectionWithRole()

        Try
            db.as_TrnReceiveStatusReject(Me.obj_receivestatus_id.Text.Trim)
        Catch ex As Exception
            Throw ex
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Sub

    Private Sub uiTrnReceiveStatus_Delete()
        If Me.GVReceiveStatus.FocusedColumn IsNot Nothing Then
            If MsgBox("Are you sure want to delete data ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, mUiName) = MsgBoxResult.Yes Then
                Dim db As New DataClassesFRMDataContext(Me.DSNLinq)

                db.OpenConnectionWithRole()

                Try
                    db.as_TrnReceiveStatusDelete(Me.obj_receivestatus_id.Text.Trim)

                    Dim rowHandle As Integer

                    rowHandle = Me.GVReceiveStatus.FocusedRowHandle

                    If Me.GVReceiveStatus.RowCount > 1 Then
                        Dim newRowHandle As Integer

                        If rowHandle >= 0 And rowHandle < (Me.GVReceiveStatus.RowCount - 1) Then
                            newRowHandle = rowHandle + 1

                            Me.uiTrnReceiveStatus_OpenRow(newRowHandle)
                            Me.GVReceiveStatus.DeleteRow(rowHandle)
                        ElseIf rowHandle = Me.GVReceiveStatus.RowCount - 1 Then
                            newRowHandle = rowHandle - 1

                            uiTrnReceiveStatus_OpenRow(newRowHandle)
                            Me.GVReceiveStatus.DeleteRow(rowHandle)
                        Else
                            Me.GVReceiveStatus.DeleteRow(rowHandle)
                            uiTrnReceiveStatus_OpenRow(rowHandle)
                        End If
                    Else
                        Me.tbl_TrnReceiveStatus_Temp.Clear()
                        Me.tbl_TrnPenerimaanBarang.Clear()
                        Me.tbl_TrnReceiveStatusAttach.Clear()
                        Me.GVReceiveStatus.DeleteRow(rowHandle)
                        Me.xTabMain.SelectedTabPageIndex = 0
                    End If
                Catch ex As Exception
                    Throw ex
                Finally
                    db.CloseConnectionWithRole()
                End Try
            End If
        End If
    End Sub
#End Region

    Private Sub uiTrnReceiveStatus_FormAfterNew() Handles Me.FormAfterNew
        Dim dlg As New dlgReceiveStatus_Order(Me.DSNLinq, Me._CHANNEL, Me._STRUKTURUNIT_ID)

        If dlg.ShowDialog() = DialogResult.OK Then
            Me.obj_order_id.Text = dlg.Value.order_id
            Me.obj_order_descr.Text = dlg.Value.order_descr
            Me.obj_receivestatus_oldstatus.Text = dlg.Value.status

            If dlg.Value.status = "COMPLETE" Then
                Me.obj_receivestatus_newstatus.Text = "INCOMPLETE"
            Else
                Me.obj_receivestatus_newstatus.Text = "COMPLETE"
            End If

            Dim db As New DataClassesFRMDataContext(Me.DSNLinq)

            db.OpenConnectionWithRole()

            Try
                Me.uiTrnReceiveStatus_OpenRowRV(Me._CHANNEL, dlg.Value.order_id, db)
            Catch ex As Exception
                Throw ex
            Finally
                db.CloseConnectionWithRole()
            End Try
        Else
            Me.xTabMain.SelectedTabPageIndex = 0

            Exit Sub
        End If

        Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.tbtnSave.Enabled = True
        Me.tbtnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.obj_receivestatus_descr.Properties.ReadOnly = False
        Me.obj_receivestatus_descr.TabStop = True
    End Sub

    Private Sub btnAttachmentAdd_Click(sender As Object, e As EventArgs) Handles btnAttachmentAdd.Click
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim dlg As New dlgReceiveStatus_Attachment

            If dlg.ShowDialog() = DialogResult.OK Then
                Dim newRow As DataRow = Me.tbl_TrnReceiveStatusAttach.NewRow()
                Dim newAttach As New transaksi_receivestatusattach

                clsUtil.DataRowToEntity(newAttach, newRow)
                newAttach.receivestatusattach_description = dlg.TEDescription.Text
                clsUtil.EntityToDataRow(newAttach, newRow)
                Me.tbl_TrnReceiveStatusAttach.Rows.Add(newRow)
                clsUtil.DataRowToEntity(newAttach, newRow)

                Me.listAttachmentTemp.Add(newAttach.line, Me.OpenFileDialog1.FileName)
            End If
        End If
    End Sub

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection

        If Me.Browser IsNot Nothing Then
            Dim moduleType As String

            objParameters = Me.GetParameterCollection(Me.Parameter)

            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._STRUKTURUNIT_ID = Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT")

            moduleType = Me.GetValueFromParameter(objParameters, "MODULE_TYPE")

            Select Case moduleType.ToLower()
                Case "user"
                    Me._MODULE_TYPE = uiTrnReceiveStatus.ModuleType.User
                Case "spv"
                    Me._MODULE_TYPE = uiTrnReceiveStatus.ModuleType.SPV
                Case "depthead"
                    Me._MODULE_TYPE = uiTrnReceiveStatus.ModuleType.DeptHead
            End Select
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            Me.InitLayoutUI()

            Me.BindingStop()
            Me.BindingStart()
        End If
    End Sub

    Private Sub uiTrnReceiveStatus_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Dim receivestatus As New view_transaksi_receivestatus()

        clsUtil.DataRowToEntity(receivestatus, Me.tbl_TrnReceiveStatus_Temp.Rows(0))

        If receivestatus.rejected = 1 Then
            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.obj_receivestatus_descr.Properties.ReadOnly = True
            Me.obj_receivestatus_descr.TabStop = False

            Exit Sub
        ElseIf receivestatus.approved1 = 1 Then
            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.obj_receivestatus_descr.Properties.ReadOnly = True
            Me.obj_receivestatus_descr.TabStop = False
        ElseIf receivestatus.approved1 = 0 Then
            Me.tbtnSave.Enabled = True
            Me.tbtnDel.Enabled = True
            Me.obj_receivestatus_descr.Properties.ReadOnly = False
            Me.obj_receivestatus_descr.TabStop = True
        End If

        Select Case Me._MODULE_TYPE
            Case ModuleType.User
                Select Case receivestatus.approved1
                    Case 0
                        Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                        Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    Case 1
                        Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

                        If Me.tbtnReject.Links.Count > 0 Then
                            Me.Toolstrip1.ItemLinks.Remove(Me.tbtnReject.Links(0))
                        End If

                        Me.tbtnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                End Select
            Case ModuleType.SPV
                Select Case receivestatus.approved2
                    Case 0
                        Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                        Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                        If Me.tbtnReject.Links.Count > 0 Then
                            Me.Toolstrip1.ItemLinks.Remove(Me.tbtnReject.Links(0))
                        End If

                        Me.Toolstrip1.ItemLinks.Add(Me.tbtnReject)
                        Me.tbtnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    Case 1
                        Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

                        If Me.tbtnReject.Links.Count > 0 Then
                            Me.tbtnReject.Links.Remove(Me.tbtnReject.Links(0))
                        End If

                        Me.tbtnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    Case 2
                        Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                        If Me.tbtnReject.Links.Count > 0 Then
                            Me.tbtnReject.Links.Remove(Me.tbtnReject.Links(0))
                        End If

                        Me.tbtnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                End Select
            Case ModuleType.DeptHead
                Select Case receivestatus.approved3
                    Case 0
                        Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                        Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                        If Me.tbtnReject.Links.Count > 0 Then
                            Me.Toolstrip1.ItemLinks.Remove(Me.tbtnReject.Links(0))
                        End If

                        Me.Toolstrip1.ItemLinks.Add(Me.tbtnReject)
                        Me.tbtnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    Case 1
                        Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                        If Me.tbtnReject.Links.Count > 0 Then
                            Me.tbtnReject.Links.Remove(Me.tbtnReject.Links(0))
                        End If

                        Me.tbtnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    Case 2
                        Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                        If Me.tbtnReject.Links.Count > 0 Then
                            Me.tbtnReject.Links.Remove(Me.tbtnReject.Links(0))
                        End If

                        Me.tbtnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                End Select
        End Select
    End Sub

    Private Sub uiTrnReceiveStatus_FormAfterSave(ByRef id As Object, result As uiBase2.FormSaveResult) Handles Me.FormAfterSave
        If result = FormSaveResult.SaveSuccess Then
            Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

            Me.uiTrnReceiveStatus_RefreshPosition()
        End If
    End Sub

    Private Sub uiTrnReceiveStatus_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Private Sub xTabMain_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles xTabMain.SelectedPageChanged
        Select Case xTabMain.SelectedTabPageIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.tbtnPrint.Enabled = False
                Me.tbtnPrintPreview.Enabled = False
                Me.btnNewClick = False
                Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Me.tbtnReject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False

                If Me.GVReceiveStatus.FocusedColumn IsNot Nothing And Me.GVReceiveStatus.RowCount > 0 Then
                    Me.uiTrnReceiveStatus_OpenRow(Me.GVReceiveStatus.FocusedRowHandle)
                Else
                    If Me.btnNewClick = False Then
                        Me.uiTrnReceiveStatus_NewData()
                    End If
                End If
        End Select
    End Sub

    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)

        If info.InRow OrElse info.InRowCell Then
            If view.FocusedColumn Is Nothing Or view.FocusedRowHandle < 0 Then
                Exit Sub
            End If

            If Me.GVReceiveStatus.FocusedColumn IsNot Nothing Then
                Me.xTabMain.SelectedTabPageIndex = 1
            End If
        End If
    End Sub

    Private Sub GVReceiveStatus_DoubleClick(sender As Object, e As EventArgs) Handles GVReceiveStatus.DoubleClick
        Dim view As GridView = CType(sender, GridView)

        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)

        DoRowDoubleClick(view, pt)
    End Sub

    Private Sub RepositoryItemButtonEdit_AttachmentOpen_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit_AttachmentOpen.Click
        Me.OpenAttachment()
    End Sub

    Private Sub OpenAttachment()
        Dim dtRow As DataRow = Me.GVAttach.GetDataRow(Me.GVAttach.FocusedRowHandle)
        Dim attach As New transaksi_receivestatusattach

        clsUtil.DataRowToEntity(attach, dtRow)

        If dtRow.RowState = DataRowState.Added Then
            Dim fileName As String = ""

            fileName = Me.listAttachmentTemp.Item(attach.line)

            Process.Start(fileName)
        Else
            Dim db As New DataClassesFILESDataContext(Me.DSNFilesLinq)
            Dim attachment As transaksi_receivestatusattachment
            Dim filename As String = ""

            db.OpenConnectionWithRole()

            Try
                attachment = db.transaksi_receivestatusattachments.Where(Function(p) p.receivestatus_id = attach.receivestatus_id And p.line = attach.line).FirstOrDefault()

                filename = clsUtil.GetTempFilename(attachment.extension)

                IO.File.WriteAllBytes(filename, attachment.filedata.ToArray())

                Process.Start(filename)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                db.CloseConnectionWithRole()
            End Try
        End If
    End Sub

    Private Sub RepositoryItemButtonEditDownload_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEditDownload.Click
        Dim dtRow As DataRow = Me.GVAttach.GetDataRow(Me.GVAttach.FocusedRowHandle)

        If dtRow.RowState = DataRowState.Modified Or dtRow.RowState = DataRowState.Unchanged Then
            Dim attach As New transaksi_receivestatusattach
            Dim db As New DataClassesFILESDataContext(Me.DSNFilesLinq)
            Dim attachment As transaksi_receivestatusattachment

            db.OpenConnectionWithRole()

            clsUtil.DataRowToEntity(attach, dtRow)

            Try
                attachment = db.transaksi_receivestatusattachments.Where(Function(p) p.receivestatus_id = attach.receivestatus_id And p.line = attach.line).FirstOrDefault()

                Me.SaveFileDialog1.Filter = "|*" + attachment.extension

                If Me.SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    IO.File.WriteAllBytes(Me.SaveFileDialog1.FileName, attachment.filedata.ToArray())
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                db.CloseConnectionWithRole()
            End Try
        End If
    End Sub

    Private Sub tbtnReject_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles tbtnReject.ItemClick
        Me.uiTrnReceiveStatus_Reject()
        Me.uiTrnReceiveStatus_RefreshPosition()
    End Sub

    Private Sub GVReceiveStatus_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GVReceiveStatus.RowStyle
        If e.RowHandle < 0 Then
            Exit Sub
        End If

        Dim dtRow As DataRow = Me.GVReceiveStatus.GetDataRow(e.RowHandle)
        Dim newColor As Color = Color.White
        Dim rejectedColor As Color = Color.LightCoral
        Dim approveColor As Color = Color.LightGreen

        Select Case Me._MODULE_TYPE
            Case ModuleType.User
                If dtRow.Item("rejected") = 1 Then
                    e.Appearance.BackColor = rejectedColor
                ElseIf dtRow.Item("approved1") = 0 Then
                    e.Appearance.BackColor = newColor
                ElseIf dtRow.Item("approved1") = 1 Then
                    e.Appearance.BackColor = approveColor
                End If
            Case ModuleType.SPV
                If dtRow.Item("rejected") = 1 Then
                    e.Appearance.BackColor = rejectedColor
                ElseIf dtRow.Item("approved2") = 0 Then
                    e.Appearance.BackColor = newColor
                ElseIf dtRow.Item("approved2") = 1 Then
                    e.Appearance.BackColor = approveColor
                End If
            Case ModuleType.DeptHead
                If dtRow.Item("rejected") = 1 Then
                    e.Appearance.BackColor = rejectedColor
                ElseIf dtRow.Item("approved3") = 0 Then
                    e.Appearance.BackColor = newColor
                ElseIf dtRow.Item("approved3") = 1 Then
                    e.Appearance.BackColor = approveColor
                End If
        End Select

    End Sub
End Class
