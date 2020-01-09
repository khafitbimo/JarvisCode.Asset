Public Class Sequencer
    Enum SequencerType
        BO
        OT
        [IN]
    End Enum

    Public Shared Function CreateSeq(ByVal channel_id As String, ByVal type As SequencerType, ByVal frm As DataClassesFRMDataContext) As String
        Dim id As String = ""

        frm.as_sequencer_asset(channel_id, type.ToString().ToUpper, id)

        Return id
    End Function
End Class
