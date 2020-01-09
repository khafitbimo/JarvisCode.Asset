Imports System.Net.Mail

Public Class clsEmail : Implements IDisposable

    Private Shared myHost As String = "mailserver.netmedia.co.id"
    Private Shared smtp As New Net.Mail.SmtpClient

    Public Shared Function GetGambaEmailCredential() As Net.NetworkCredential
        Return New Net.NetworkCredential(clsEmail.GetGambaEmail, clsEmail.GetGambaPassword())
    End Function

    Public Shared Function GetGambaEmail() As String
        Return "gamba@netmedia.co.id"
    End Function

    Private Shared Function GetGambaPassword() As String
        Return "GA123$%^"
    End Function

    Public Shared Sub Send(ByVal myMail As Net.Mail.MailMessage, ByVal myCredential As Net.NetworkCredential)
        Dim credCache As New Net.CredentialCache

        credCache.Add(myHost, "35", "Basic", myCredential)
        credCache.Add(myHost, "45", "NTLM", myCredential)

        smtp.Host = myHost

        myMail.DeliveryNotificationOptions = DeliveryNotificationOptions.None

        smtp.EnableSsl = True
        smtp.UseDefaultCredentials = False
        smtp.Credentials = credCache.GetCredential(myHost, "45", "NTLM")

        Try
            smtp.Send(myMail)
        Catch exfailed As SmtpFailedRecipientsException

        End Try
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
