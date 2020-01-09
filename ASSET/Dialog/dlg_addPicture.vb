Imports System.ComponentModel
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Data
Imports System.Data.SqlClient


Public Class dlg_addPicture
    Private DSN As String
    Private namafile As String
    Private filter As String = "Jpeg(.jpg)|*.jpg" '|Bitmaps(.bmp)|*.bmp"
    Private attach_temp As String
    Private srvDir As String = "\\aplikasi\INSOSYS\asset\"
    'Private srvDir As String = "E:\temp\"
    Private fi_src As System.IO.FileInfo
    Private fi_dest As System.IO.FileInfo

    Private filename As String = String.Empty
    Private request_newid As String = String.Empty

    Private retNamafile As String

    Public Sub New(ByVal sDSN As String, ByVal strNamaFile As String)

        ' This call is required by the Windows Form Designer.
        Me.DSN = sDSN
        Me.retNamafile = strNamaFile
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    
    Private Sub cmd_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_add.Click

        attach_temp = ""

        'Me.object_attach_dlg.Filter = "Text Document|*.txt| Word Document|*.doc"
        Me.OpenFileDialog1.Multiselect = False
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            'Me.wb_attach_viewer.Navigate(Me.obj_Request_pathfile.Text)
            Me.obj_Request_pathfile.Text = Me.OpenFileDialog1.FileName
            Dim theImage As New Bitmap(OpenFileDialog1.FileName)
            PictureBox1.Image = theImage
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage


            Dim FI As FileInfo
            FI = New FileInfo(OpenFileDialog1.FileName)
            Me.Label1.Text = CStr(FI.Length / 1000)

        End If

    End Sub

    Private Sub cmd_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_save.Click
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        'Dim dbCmdInsert As OleDb.OleDbCommand
        'Dim dbCmdUpdate As OleDb.OleDbCommand
        'Dim dbDA As OleDb.OleDbDataAdapter
        'Dim curpos As Integer

        If CDbl(Me.Label1.Text) > 300 Then
            MsgBox("Sorry, Can't Save. File Too Big", MsgBoxStyle.Critical, "ERRORs")
            Exit Sub
        End If

        'wb_attach_viewer.Navigate("")
        PictureBox1.ImageLocation = ""
        
        filename = retNamafile
        If filename = "" Then filename = request_newid

        If Me.obj_Request_pathfile.Text = "" Then
            fi_src = New System.IO.FileInfo("dummy")
            fi_dest = New System.IO.FileInfo(srvDir & filename & fi_src.Extension)
        Else
            fi_src = New System.IO.FileInfo(obj_Request_pathfile.Text)
            fi_dest = New System.IO.FileInfo(srvDir & filename & fi_src.Extension)
        End If


        If attach_temp <> "" Then
            fi_dest = New System.IO.FileInfo(attach_temp)

            If fi_dest.Exists Then
                fi_dest.Delete()
            End If
            Me.obj_Request_pathfile.Text = ""
            'wb_attach_viewer.Navigate("")
        ElseIf fi_src.Name <> fi_dest.Name Then
            If fi_dest.Exists Then
                fi_dest.Delete()
            End If

            If Me.obj_Request_pathfile.Text <> "" Then
                fi_src.CopyTo(srvDir & fi_dest.Name)
            End If

            'wb_attach_viewer.Navigate(srvDir & fi_dest.Name)
            PictureBox1.ImageLocation = srvDir & fi_dest.Name
            MsgBox("Image Save", MsgBoxStyle.Exclamation, "SUCCESs")
            cmd_add.Enabled = False
            cmd_save.Enabled = False
        End If

    End Sub

   

    
    Private Sub dlg_addPicture_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

        filename = retNamafile

            fi_dest = New System.IO.FileInfo(srvDir & filename & ".jpg")
            PictureBox1.ImageLocation = srvDir & fi_dest.Name
            Dim FI As FileInfo
            FI = New FileInfo(srvDir & fi_dest.Name)
            Me.Label1.Text = CStr(FI.Length / 1000)
            cmd_add.Enabled = False
            cmd_save.Enabled = False
        Catch ex As Exception
            MsgBox("Please Insert the Picture")
        End Try

    End Sub

   
    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
