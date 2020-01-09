Public Class clsUtil

    Public Shared Function SetLocalization() As Boolean
        Dim myCI As New System.Globalization.CultureInfo("en-GB", False)
        Dim myCIclone As System.Globalization.CultureInfo = CType(myCI.Clone(), System.Globalization.CultureInfo)
        myCIclone.DateTimeFormat.AMDesignator = "a.m."
        myCIclone.DateTimeFormat.DateSeparator = "/"
        myCIclone.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        myCIclone.NumberFormat.CurrencySymbol = "$"
        myCIclone.NumberFormat.NumberDecimalDigits = 4
        System.Threading.Thread.CurrentThread.CurrentCulture = myCIclone
    End Function

    Public Shared Function IsEmptyText(ByVal value As String, ByVal value_if_empty As String) As String
        If value <> "" Then
            Return value
        Else
            Return value_if_empty
        End If
    End Function

    Public Shared Function IsNol(ByVal value As Decimal, ByVal value_if_nol As Decimal) As Decimal
        If value > 0 Then
            Return value
        Else
            Return value_if_nol
        End If

    End Function


    Public Shared Function IsDbNull(ByRef value As Object, ByVal value_if_null As Object) As Object
        If value IsNot Nothing Then
            If value Is DBNull.Value Then
                Return value_if_null
            Else
                Return value
            End If
        Else
            Return value_if_null
        End If
    End Function
    Public Shared Function Terbilang(ByVal x As Double) As String
        Dim xstr, major, minor, negatifsign As String
        Dim axstr(2) As String
        Dim t As String

        If x = 0 Then
            Return "nol"
        End If


        negatifsign = ""

        If x < 0 Then
            x = -1 * x
            negatifsign = "Negatif "
        Else
            negatifsign = ""
        End If

        x = Math.Round(x, 2)
        xstr = CType(x, String)
        axstr = xstr.Split(".")
        major = axstr(0)


        If axstr.Length > 1 Then
            minor = axstr(1)
            t = negatifsign & " " & Num2Word(CType(major, Long)) & " koma " & Num2Word(CType(minor, Long))
        Else
            t = negatifsign & " " & Num2Word(CType(major, Long))
        End If

        Return t

    End Function


    Public Shared Function Num2Word(ByVal x As Long) As String
        Dim bilangan As String() = {"", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas"}
        Dim temp As String = ""


        If x < 12 Then
            temp = " " + bilangan(x)
        ElseIf x < 20 Then
            temp = Num2Word(x - 10).ToString + " belas"
        ElseIf x < 100 Then
            temp = Num2Word(Math.Floor(x / 10)) + " puluh" + Num2Word(x Mod 10)
        ElseIf x < 200 Then
            temp = " seratus" + Num2Word(x - 100)
        ElseIf x < 1000 Then
            temp = Num2Word(Math.Floor(x / 100)) + " ratus" + Num2Word(x Mod 100)
        ElseIf x < 2000 Then
            temp = " seribu" + Num2Word(x - 1000)
        ElseIf x < 1000000 Then
            temp = Num2Word(Math.Floor(x / 1000)) + " ribu" + Num2Word(x Mod 1000)
        ElseIf x < 1000000000 Then
            temp = Num2Word(Math.Floor(x / 1000000)) + " juta" + Num2Word(x Mod 1000000)
        ElseIf x < 1000000000000 Then
            temp = Num2Word(Math.Floor(x / 1000000000)) + " milyard" + Num2Word(x Mod 1000000000)
        End If

        Return temp

    End Function


    Public Shared Function RefParser(ByVal txtField As String, ByVal txtSearchRef As TextBox) As String
        Dim i, j As Integer
        Dim txtTempLineSearchText As String
        Dim txtTempSearchText As String
        Dim txtSearchCriteria As String = ""
        Dim arrSearchText() As String
        Dim txtSQLSearch As String = ""


        For i = 0 To txtSearchRef.Lines.Length - 1
            txtTempLineSearchText = txtSearchRef.Lines(i)
            arrSearchText = Nothing
            arrSearchText = txtTempLineSearchText.Split(";")
            For j = 0 To arrSearchText.Length - 1
                txtTempSearchText = Trim(arrSearchText(j))
                If txtTempSearchText <> "" Then
                    txtSearchCriteria = txtTempSearchText & ";" & txtSearchCriteria
                End If
            Next
        Next

        arrSearchText = Nothing
        arrSearchText = txtSearchCriteria.Split(";")



        For i = 0 To arrSearchText.Length - 1
            If i > 0 Then
                If arrSearchText(i) <> "" Then
                    txtSearchCriteria = txtSearchCriteria & " OR " & txtField & " = '" & arrSearchText(i) & "' "
                End If
            Else
                txtSearchCriteria = txtField & " = '" & arrSearchText(0) & "' "
            End If
        Next


        Return txtSearchCriteria

        'If txtSQLSearch = "" Then
        '    txtSQLSearch = " (" & txtSearchCriteria & ") "
        'Else
        '    txtSQLSearch = txtSQLSearch & " AND " & " (" & txtSearchCriteria & ") "
        'End If
    End Function


    '-- Function utk mengenerate column ---------------------------------------
    '-- Penggunaan : Dim colName as DataGridViewTextBoxColumn("column_nama", _
    '--                                                       "column_nama", _
    '--                                                       "NAMA", _
    '--                                                       "TXT10")
    '-- Artinya mengenerate column dgn column dari datasource kolom "column_nama"
    '-- header column = "NAMA", lebar kolom 10 karakter(dg font default), 
    '-- tipe isi kolom text(bs jg utk numeric, atau kolom checkbox)
    Public Shared Function CreateColumn(ByVal ColumnName As String, _
            ByVal DataPropertyName As String, _
            ByVal HeaderText As String, _
            ByVal TypePanjang As String, _
            Optional ByVal Alignment As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleCenter, _
            Optional ByVal IsreadOnly As Boolean = True, _
            Optional ByVal IsHidden As Boolean = False, _
            Optional ByVal SortMode As DataGridViewColumnSortMode = DataGridViewColumnSortMode.NotSortable) As DataGridViewTextBoxColumn

        Try
            CreateColumn = New DataGridViewTextBoxColumn
            CreateColumn.Name = ColumnName
            CreateColumn.DataPropertyName = DataPropertyName
            CreateColumn.HeaderText = HeaderText
            CreateColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            CreateColumn.DefaultCellStyle.Alignment = Alignment
            CreateColumn.ReadOnly = IsreadOnly
            CreateColumn.Visible = Not IsHidden
            CreateColumn.SortMode = SortMode

            TypePanjang = Trim(TypePanjang)
            Select Case UCase(Mid(TypePanjang, 1, 3))
                Case "TXT"
                    If Len(HeaderText) >= Val(Right(TypePanjang, Len(TypePanjang) - 3)) Then
                        CreateColumn.Width = Val(Right(TypePanjang, Len(TypePanjang) - 3)) * 6.0075 + 10 + 10
                    Else
                        CreateColumn.Width = Val(Right(TypePanjang, Len(TypePanjang) - 3)) * 6.0075 + 10
                    End If
                Case "NUM"
                    Dim arrsTemp(1) As String
                    Dim sDecimal As String
                    Dim i As Integer

                    arrsTemp = Right(TypePanjang, Len(TypePanjang) - 3).Split(".")

                    If Val(arrsTemp(1)) > 0 Then
                        CreateColumn.Width = (Val(arrsTemp(0)) + Val(arrsTemp(1)) + 1) * 6.0075 + 10
                        sDecimal = ""
                        If Val(Len(arrsTemp(1))) > 1 Then
                            For i = 2 To Val(Len(arrsTemp(1)))
                                sDecimal = sDecimal & "#"
                            Next
                        End If
                        sDecimal = sDecimal + "0"

                        CreateColumn.DefaultCellStyle.Format = "#." + sDecimal
                    Else
                        CreateColumn.Width = (Val(arrsTemp(0))) * 6.0075 + 10
                        CreateColumn.DefaultCellStyle.Format = "#0"
                    End If

                Case "CHK"
            End Select

            Return CreateColumn

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Shared Function CreateColumn(ByVal ColumnName As String, _
            ByVal DataPropertyName As String, _
            ByVal HeaderText As String, _
            ByVal Width As Integer, _
            Optional ByVal IsreadOnly As Boolean = True, _
            Optional ByVal IsHidden As Boolean = False, _
            Optional ByVal SortMode As DataGridViewColumnSortMode = DataGridViewColumnSortMode.NotSortable) As DataGridViewCheckBoxColumn

        Try
            CreateColumn = New DataGridViewCheckBoxColumn
            CreateColumn.Name = ColumnName
            CreateColumn.DataPropertyName = DataPropertyName
            CreateColumn.HeaderText = HeaderText
            CreateColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            CreateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            CreateColumn.ReadOnly = IsreadOnly
            CreateColumn.Visible = Not IsHidden
            CreateColumn.SortMode = SortMode

            CreateColumn.Width = Width * 6.0075 + 10
            Return CreateColumn

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Shared Function CreateColumn(ByVal ColumnName As String, _
                    ByVal DataPropertyName As String, _
                    ByVal HeaderText As String, _
                    ByVal Panjang As Long, _
                    ByVal ValueMember As String, _
                    ByVal DisplayMember As String, _
                    ByVal DataSource As DataTable, _
                    Optional ByVal AutoComplete As Boolean = True, _
                    Optional ByVal DisplayStyle As DataGridViewComboBoxDisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox, _
                    Optional ByVal Alignment As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleCenter, _
                    Optional ByVal DisplayStyleForCurrentCellOnly As Boolean = True, _
                    Optional ByVal IsreadOnly As Boolean = True, _
                    Optional ByVal IsHidden As Boolean = False, _
                    Optional ByVal SortMode As DataGridViewColumnSortMode = DataGridViewColumnSortMode.NotSortable) As DataGridViewComboBoxColumn

        Try

            CreateColumn = New DataGridViewComboBoxColumn

            CreateColumn.Name = ColumnName
            CreateColumn.DataPropertyName = DataPropertyName
            CreateColumn.HeaderText = HeaderText
            CreateColumn.ValueMember = ValueMember
            CreateColumn.DisplayMember = DisplayMember
            CreateColumn.DataSource = DataSource

            CreateColumn.DefaultCellStyle.Alignment = Alignment
            CreateColumn.ReadOnly = IsreadOnly
            CreateColumn.Visible = Not IsHidden
            CreateColumn.Width = Panjang * 6.0075 + 10
            CreateColumn.SortMode = SortMode

            Return CreateColumn

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function


    Public Shared Function GetDataTable(ByVal _sStoredProcedureName As String, ByVal _sConn As String, ByVal ParamArray _Params() As System.Data.OleDb.OleDbParameter) As DataTable
        GetDataTable = New DataTable

        Dim oConn As System.Data.OleDb.OleDbConnection
        Dim oCmd As System.Data.OleDb.OleDbCommand
        Dim oDA As System.Data.OleDb.OleDbDataAdapter

        Try

            oConn = New System.Data.OleDb.OleDbConnection(_sConn)
            oCmd = New System.Data.OleDb.OleDbCommand(_sStoredProcedureName, oConn)
            oCmd.CommandType = CommandType.StoredProcedure
            oCmd.Parameters.AddRange(_Params)


            oDA = New System.Data.OleDb.OleDbDataAdapter(oCmd)
            oDA.Fill(GetDataTable)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            oConn = Nothing
            oCmd = Nothing
            oDA = Nothing
        End Try

        Return GetDataTable
    End Function
End Class
