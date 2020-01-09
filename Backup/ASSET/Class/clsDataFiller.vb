Public Class clsDataFiller

    Private mDSN As String

#Region " Constructor "

    Public Sub New(ByVal dsn As String)
        Me.mDSN = dsn

    End Sub

#End Region

    Public Function DataFill(ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "", Optional ByVal Top As Integer = 0) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria
        If Top <> 0 Then
            dbCmd.Parameters.Add("@top", Data.OleDb.OleDbType.Integer)
            dbCmd.Parameters("@top").Value = Top
        End If


        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
        End Try

        Return True

    End Function

    Public Function DataFillAsset(ByRef asset_dsn As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "", Optional ByVal Top As Integer = 0) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(asset_dsn)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria
        If Top <> 0 Then
            dbCmd.Parameters.Add("@top", Data.OleDb.OleDbType.Integer)
            dbCmd.Parameters("@top").Value = Top
        End If


        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
        End Try

        Return True

    End Function

    Public Function DataFillKhusus(ByRef datatable As DataTable, ByVal procedure As String, ByVal hariawal As Date, ByVal hariakhir As Date, ByVal kategoriitem_id As String) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        dbCmd.Parameters.Add("@hariawal", Data.OleDb.OleDbType.Date)
        dbCmd.Parameters("@hariawal").Value = hariawal

        dbCmd.Parameters.Add("@hariakhir", Data.OleDb.OleDbType.Date)
        dbCmd.Parameters("@hariakhir").Value = hariakhir

        dbCmd.Parameters.Add("@kategoriitem_id", Data.OleDb.OleDbType.VarWChar)
        dbCmd.Parameters("@kategoriitem_id").Value = kategoriitem_id


        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
        End Try

        Return True

    End Function

    Public Function DataFillDepresiasi(ByRef datatable As DataTable, ByVal procedure As String, ByVal channel_id As String, ByVal thn As Integer, ByVal bln As Integer, ByVal struturunit As Decimal) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id

        dbCmd.Parameters.Add("@thn", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@thn").Value = thn

        dbCmd.Parameters.Add("@bln", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@bln").Value = bln

        dbCmd.Parameters.Add("@strukturunit_id", Data.OleDb.OleDbType.Decimal)
        dbCmd.Parameters("@strukturunit_id").Value = struturunit



        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
        End Try

        Return True

    End Function

    Public Function DataFillBpjInOrder(ByRef datatable As DataTable, ByVal procedure As String, ByVal datestart As String, ByVal dateend As String, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@datestart", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@datestart").Value = datestart
        'If Top <> 0 Then
        dbCmd.Parameters.Add("@dateend", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@dateend").Value = dateend
        'End If


        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
        End Try

        Return True

    End Function
    Public Function DataFillLimit(ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal top As Integer = 0) As Boolean
        Dim dbConn As New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)

        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = criteria

        If top <> 0 Then
            dbCmd.Parameters.Add("@Top", Data.OleDb.OleDbType.Integer)
            dbCmd.Parameters("@Top").Value = top
        End If

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()

            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
        End Try

        Return True
    End Function

    Public Function ComboFill(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = DBNull.Value
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            'MsgBox("masuk")
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Function ComboFillAsset(ByRef asset_dsn As String, ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = DBNull.Value
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            'MsgBox("masuk")
            Me.DataFillAsset(asset_dsn, datatable, procedure, criteria, channel_id)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Function DataFillLineID(ByRef datatable As DataTable, ByVal procedure As String, ByVal request_id As String, ByVal requestdetil_line As Integer, Optional ByVal channel_id As String = "") As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.mDSN)
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand(procedure, dbConn)
        If channel_id <> "" Then
            dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
            dbCmd.Parameters("@channel_id").Value = channel_id
        End If
        dbCmd.Parameters.Add("@order_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@order_id").Value = request_id
        dbCmd.Parameters.Add("@orderdetil_line", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@orderdetil_line").Value = requestdetil_line
        

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Try
            dbConn.Open()
            dbDA.Fill(datatable)
        Catch ex As Exception
            Throw ex
        Finally
            dbConn.Close()
        End Try

        Return True

    End Function


    Public Function ComboFillCharASSET(ByRef asset_dsn As String, ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = ""
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            'MsgBox("masuk")
            Me.DataFillAsset(asset_dsn, datatable, procedure, criteria, channel_id)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Function ComboFillChar(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = ""
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            'MsgBox("masuk")
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Function ComboFillAngka(ByRef asset_dsn As String, ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = 0
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            'MsgBox("masuk")
            Me.DataFillAsset(asset_dsn, datatable, procedure, criteria, channel_id)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Function ComboFillkhusus(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "", Optional ByVal top As Integer = 0) As Boolean

        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = ""
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id, top)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Function DataFillForCombo(ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = 0
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        Return True
    End Function
    Public Function DataFillForComboAsset(ByVal asset_dsn As String, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = 0
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFillAsset(asset_dsn, datatable, procedure, criteria, channel_id)
        End If

        Return True
    End Function

    Public Function DataFillForComboString(ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = ""
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        Return True
    End Function

    Public Function ComboFillStringNull(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = DBNull.Value
        row.Item(displaymember) = "-- PILIH --"
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function

    Public Function ComboLink(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable) As Boolean

        Dim row As System.Data.DataRow

        'datatable.Clear()
        If datatable.Rows.Count > 0 AndAlso datatable.Rows(0)(valuemember) <> "0" Then
            row = datatable.NewRow
            row.Item(valuemember) = DBNull.Value '"0"
            row.Item(displaymember) = "-- PILIH --"
            datatable.Rows.InsertAt(row, 0)

        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

    End Function

    Public Function ComboLink(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal withOption As Boolean) As Boolean
        Dim row As System.Data.DataRow

        If withOption Then
            row = datatable.NewRow
            row.Item(valuemember) = DBNull.Value '"0"
            row.Item(displaymember) = "-- PILIH --"
            datatable.Rows.InsertAt(row, 0)
        End If

        combobox.DataSource = datatable
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember

        Return True
    End Function
    Public Function DataFillForComboAngka(ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Dim row As System.Data.DataRow

        datatable.Clear()
        row = datatable.NewRow
        row.Item(valuemember) = 0
        row.Item(displaymember) = " -- PILIH -- "
        datatable.Rows.InsertAt(row, 0)

        If procedure <> "" Then
            Me.DataFill(datatable, procedure, criteria, channel_id)
        End If

        Return True
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

    Public Shared Function GetDataTable(ByVal strSQL As String, ByVal _sConn As String) As DataTable
        GetDataTable = New DataTable

        Dim oConn As System.Data.OleDb.OleDbConnection
        Dim oCmd As System.Data.OleDb.OleDbCommand
        Dim oDA As System.Data.OleDb.OleDbDataAdapter

        Try

            oConn = New System.Data.OleDb.OleDbConnection(_sConn)
            oCmd = New System.Data.OleDb.OleDbCommand(strSQL, oConn)
            oCmd.CommandType = CommandType.Text


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
