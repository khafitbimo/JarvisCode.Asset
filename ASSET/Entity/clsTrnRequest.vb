Public Class clsTrnRequest

    Private DSN As String
    Private filler As clsDataFiller

    Enum Objective
        Wardrobe
        Rental
    End Enum

    Sub New(ByVal DSN As String)
        Me.DSN = DSN
        Me.filler = New clsDataFiller(Me.DSN)
    End Sub

    Public Sub RetrieveRequest(ByVal objTbl As DataTable, ByVal criteria As String, ByVal Objective As Objective)
        Try
            Dim storeProcedure As String = ""

            Select Case Objective
                Case clsTrnRequest.Objective.Rental
                    storeProcedure = "as_TrnPenerimaanbarang_SelectRentalRequest"
                Case clsTrnRequest.Objective.Wardrobe
                    storeProcedure = "as_TrnPenerimaanbarang_SelectRequest"
            End Select

            objTbl.Clear()

            Me.filler.DataFill(objTbl, storeProcedure, criteria)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub RetrieveRequestDetil(ByVal objTbl As DataTable, ByVal Criteria As String, ByVal Objective As Objective)
        Try
            Dim storeProcedure As String = ""

            Select Case Objective
                Case clsTrnRequest.Objective.Rental
                    storeProcedure = "as_TrnPenerimaanbarang_SelectRentalRequestDetil"
                Case clsTrnRequest.Objective.Wardrobe
                    storeProcedure = "as_TrnPenerimaanbarang_SelectRequestDetil"
            End Select

            Using filler As New clsDataFiller(Me.DSN)
                filler.DataFill(objTbl, storeProcedure, Criteria)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
