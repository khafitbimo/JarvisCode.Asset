Imports System.Windows.Forms

Public Class dlgStatusTerimaJasa
    Private retStatus As String = String.Empty

    Private CloseButtonIsPressed As Boolean
 

    Public Shadows Function OpenDialog(ByVal owner As System.Windows.Forms.IWin32Window) As String

        'Me.TextBox1.Text = ""
        Me.obj_Status.SelectedItem = "-- Pilih --"
        MyBase.ShowDialog(owner)

        If Me.CloseButtonIsPressed Then
            Return Me.retStatus
        Else
            Return Nothing
        End If
    End Function
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Me.retStatus = Me.obj_Status.SelectedItem

        Me.CloseButtonIsPressed = True
        Me.Close()
    End Sub
End Class
