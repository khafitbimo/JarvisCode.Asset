Imports System.Windows.Forms

Public Class DlgReceiveStatus_ApproveTo

    Private DSN As String
    Private strukturunit_id As Decimal
    Private moduleType As uiTrnReceiveStatus.ModuleType

    Private tbl_MstUser As DataTable = DatabaseUtils.CreateTbl(Of master_user)()

    Sub New(ByVal DSN As String, ByVal strukturunit_id As Decimal, ByVal moduleType As uiTrnReceiveStatus.ModuleType)
        Me.InitializeComponent()

        Me.DSN = DSN
        Me.strukturunit_id = strukturunit_id
        Me.moduleType = moduleType
    End Sub

    Private Sub Retrieve()
        Dim db As New DataClassesFRMDataContext(Me.DSN)
        Dim query As IQueryable(Of master_user) = Nothing

        db.OpenConnectionWithRole()

        Try
            Select Case Me.moduleType
                Case uiTrnReceiveStatus.ModuleType.User
                    query = db.master_users.Where(Function(p) p.strukturunit_id = Me.strukturunit_id And {20, 30}.Contains(p.user_position) And p.user_isdisabled = 0)
                Case uiTrnReceiveStatus.ModuleType.SPV
                    query = db.master_users.Where(Function(p) p.strukturunit_id = Me.strukturunit_id And p.user_position = 40 And p.user_isdisabled = 0)
            End Select

            Me.tbl_MstUser.Clear()
            DatabaseUtils.DataFill(Me.tbl_MstUser, query)
        Catch ex As Exception
            Throw ex
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Sub

    Private Sub DlgReceiveStatus_ApproveTo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.LUSendTo.Properties.DataSource = Me.tbl_MstUser
        Me.LUSendTo.Properties.ValueMember = "username"
        Me.LUSendTo.Properties.DisplayMember = "user_fullname"

        Me.Retrieve()
    End Sub

    Private Sub LUSendTo_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles LUSendTo.EditValueChanging
        Dim db As New DataClassesFRMDataContext(Me.DSN)
        Dim email As master_useremail

        db.OpenConnectionWithRole()

        Try
            email = db.master_useremails.Where(Function(p) p.username = e.NewValue.ToString() And p.user_emaildefault = 1).FirstOrDefault()

            If email IsNot Nothing Then
                Me.TEEmail.Text = email.user_email

                Me.btnOK.Enabled = True
            Else
                Me.TEEmail.Text = ""
                Me.btnOK.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            db.CloseConnectionWithRole()
        End Try
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
