Public Class DataGridViewMaskedEditColumn
    Inherits DataGridViewColumn
    Private pPromptChar As Char = "_"c
    Private pValidatingType As Type = GetType(String)
    Private pMask As String = ""
    Public Sub New()
        MyBase.New(New DataGridViewMaskedEditCell())
    End Sub
    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            ' Ensure that the cell used for the template is a MaskedEditCell
            If Not (value Is Nothing) And Not value.GetType().IsAssignableFrom( _
            GetType(DataGridViewMaskedEditCell)) Then
                Throw New InvalidCastException("Must be a DataGridViewMaskedEditCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
    '
    ' New properties required by the MaskedTextBox control
    '
    Public Property Mask() As String
        Get
            Return pMask
        End Get
        Set(ByVal value As String)
            pMask = value
        End Set
    End Property
    Public Property PromptChar() As Char
        Get
            Return pPromptChar
        End Get
        Set(ByVal value As Char)
            pPromptChar = value
        End Set
    End Property
    Public Property ValidatingType() As Type
        Get
            Return pValidatingType
        End Get
        Set(ByVal value As Type)
            pValidatingType = value
        End Set
    End Property
End Class

Public Class DataGridViewMaskedEditCell
    Inherits DataGridViewTextBoxCell
    Dim pColumn As DataGridViewMaskedEditColumn
    Public Sub New()
    End Sub
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal _
    initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        pColumn = CType(Me.OwningColumn, DataGridViewMaskedEditColumn)
        Dim ctl As MaskedEditEditingControl = CType(DataGridView.EditingControl, _
        MaskedEditEditingControl)
        ' copy over the properties of the column
        If Not IsNothing(Me.Value) Then
            ctl.Text = Me.Value.ToString
        Else
            ctl.Text = ""
        End If
        ctl.ValidatingType = pColumn.ValidatingType
        ctl.Mask = pColumn.Mask
        ctl.PromptChar = pColumn.PromptChar
    End Sub
    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that MaskedEditEditingControl uses.
            Return GetType(MaskedEditEditingControl)
        End Get
    End Property
    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that MaskedEditEditingControl contains.
            Return pColumn.ValidatingType
        End Get
    End Property
    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            Return ""
        End Get
    End Property
End Class


Class MaskedEditEditingControl
    Inherits MaskedTextBox
    Implements IDataGridViewEditingControl
    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer
    Public Sub New()
    End Sub
    Public Property EditingControlFormattedValue() As Object Implements _
    IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.valueIsChanged.ToString
        End Get
        Set(ByVal value As Object)
            If TypeOf value Is [String] Then
                Me.Text = value.ToString
            End If
        End Set
    End Property
    Public Function GetEditingControlFormattedValue(ByVal context As _
    DataGridViewDataErrorContexts) As Object Implements _
    IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return Me.Text
    End Function
    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
    DataGridViewCellStyle) Implements _
    IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.BackColor = dataGridViewCellStyle.BackColor
    End Sub
    Public Property EditingControlRowIndex() As Integer Implements _
    IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set
    End Property
    Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal _
    dataGridViewWantsInputKey As Boolean) As Boolean Implements _
    IDataGridViewEditingControl.EditingControlWantsInputKey
        Return True
    End Function
    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements _
    IDataGridViewEditingControl.PrepareEditingControlForEdit
        ' No preparation needs to be done.
    End Sub
    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean _
    Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property
    Public Property EditingControlDataGridView() As DataGridView Implements _
    IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set
    End Property
    Public Property EditingControlValueChanged() As Boolean Implements _
    IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set
    End Property
    Public ReadOnly Property EditingPanelCursor() As Cursor Implements _
    IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property
    Protected Overrides Sub OnTextChanged(ByVal eventargs As EventArgs)
        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnTextChanged(eventargs)
    End Sub

End Class
