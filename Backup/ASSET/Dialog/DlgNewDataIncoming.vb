

Public Class DlgNewDataIncoming
    Private DSN As String
    Private channel_id As String
    Private strukturunit_id As Decimal
    Public Sub New(ByVal sDSN As String, ByVal channel_id As String, _
                    ByVal strukturunit_id As Decimal)

        ' This call is required by the Windows Form Designer.
        Me.DSN = sDSN
        Me.channel_id = channel_id
        Me.strukturunit_id = strukturunit_id
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub obj_oto_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        obj_oto.Text = ""
    End Sub

    Private Sub obj_incBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles obj_incBarcode.KeyPress
        If e.KeyChar.ToString = Microsoft.VisualBasic.ChrW(13) Then
            Dim oDataFiller As New clsDataFiller(DSN)
            Dim criteria As String = String.Format("barcode = '{0}' AND outasset_return = 0 AND tot.channel_id = '{1}' AND total_asset.strukturunit_id = '{2}'", Me.obj_incBarcode.Text, Me.channel_id, Me.strukturunit_id)
            Dim tabell As New DataTable
            Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            Try
                tabell.Rows.Clear()
                oDataFiller.DataFill(tabell, "as_TrnOutassetdetil_Select", criteria)
                If tabell.Rows.Count <= 0 Then
                    MsgBox("Sorry. Your Barcode can't be found")
                    Me.obj_oto.Text = String.Empty
                Else
                    Me.obj_oto.Text = tabell.Rows(0).Item("outasset_id")
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class
