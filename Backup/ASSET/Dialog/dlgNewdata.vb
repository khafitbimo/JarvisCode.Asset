
Public Class NewData
    Private DSN As String
    Public Sub New(ByVal sDSN As String)

        ' This call is required by the Windows Form Designer.
        Me.DSN = sDSN
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub obj_automatic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_automatic.CheckedChanged
        If obj_automatic.Checked = True Then
            obj_oto.Enabled = True
            obj_oto.Focus()
        Else
            obj_oto.Enabled = False
        End If
    End Sub

End Class