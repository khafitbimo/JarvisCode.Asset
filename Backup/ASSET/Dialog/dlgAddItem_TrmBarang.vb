Imports System.Windows.Forms

Public Class dlgAddItem_TrmBarang
    Private CloseButtonIsPressed As Boolean
    Private desc As String

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As String

        'Me.TextBox1.Text = ""
        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.desc
        Else
            Return Nothing
        End If
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        desc = Me.TextBox1.Text

        Me.CloseButtonIsPressed = True
        ' Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()


    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
