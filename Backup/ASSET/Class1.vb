Option Explicit On
Option Strict On
Module Module1

    Public Declare Function MainkanSuara _
            Lib "winmm.dll" Alias "sndPlaySoundA" _
            (ByVal lpszSoundName As String, _
            ByVal uFlags As Integer) As Integer
    'Mainkan secara ansinkronus
    Public Const SND_ASYNC As Integer = &H1
    'Mainkan secara sinkronus (default)
    Public Const SND_SYNC As Integer = &H0
    'Menunjuk pada file di memori
    Public Const SND_MEMORY As Integer = &H4

    Public Function PanggilSuara _
            (ByVal NamFile As String) As String

        ' Memanggil file suara ke variabel string.
        Dim F As Integer
        Dim Buffer As String
        Dim SoundBuffer As String
        Buffer = Space(1024)
        SoundBuffer = ""
        Try
            F = FreeFile()
            FileOpen(F, NamFile, OpenMode.Binary)
            'Ambil suara dalam potongan 1K 
            Do While Not EOF(F)
                FileGet(1, Buffer, , True)
                SoundBuffer += Buffer
            Loop
            Return Trim(SoundBuffer)
        Catch
            SoundBuffer = ""
        Finally
            FileClose(F)

        End Try
        Return (SoundBuffer)
    End Function



End Module
