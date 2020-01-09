Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptOutAsset
        Private DSN As String
        Private top As Integer

        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mStrukturunit_id As Decimal
        Private mOutasset_id As String
        Private mBookasset_id As String
        Private mOutasset_startdt As DateTime
        Private mOutasset_enddt As DateTime
        Private mOutasset_starttm As String
        Private mOutasset_endtm As String
        Private mEmployee_id_customer As String
        Private mStrukturunit_id_customer As Decimal
        Private mEmployee_id_customerhead As String
        Private mEmployee As String
        Private mOutasset_item As Int32
        Private mProject_id As Decimal
        Private mShow_id As String
        Private mShow_epsnumber_st As String
        Private mShow_epsnumber_ed As String
        Private mOutasset_lock As Byte
        Private mOutasset_status As String
        Private mOutasset_remark As String
        Private mOutasset_inputdt As DateTime
        Private mOutasset_inputtm As DateTime
        Private mOutasset_purpose As String



        Private mStrukturUnit_NameReport As String
        Private mEmployee_id_customerhead_NameReport As String
        Private mProject_id_NameReport As String
        Private mStrukturunit_id_nameReport As String
        Private mEmployee_id_customer_nameReport As String
        Private mEmployee_namereport As String
        Private mBookasset_InputDt As DateTime
        Private mBookasset_InputTm As DateTime


        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
                setChannelDesc()
            End Set
        End Property
        Public Property channel_namereport() As String
            Get
                Return mChannel_namereport
            End Get
            Set(ByVal value As String)
                mChannel_namereport = value
            End Set
        End Property

        Public Property channel_address() As String
            Get
                Return mChannel_address
            End Get
            Set(ByVal value As String)
                mChannel_address = value
            End Set
        End Property

        Public Property strukturunit_id() As Decimal
            Get
                Return mStrukturunit_id
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id = value
                setstrukturunit_id()
            End Set
        End Property

        Public Property outasset_id() As String
            Get
                Return mOutasset_id
            End Get
            Set(ByVal value As String)
                mOutasset_id = value
            End Set
        End Property

        Public Property bookasset_id() As String
            Get
                Return mBookasset_id
            End Get
            Set(ByVal value As String)
                mBookasset_id = value
                setbookasset_id()
            End Set
        End Property

        Public Property outasset_startdt() As DateTime
            Get
                Return mOutasset_startdt
            End Get
            Set(ByVal value As DateTime)
                mOutasset_startdt = value
            End Set
        End Property

        Public Property outasset_enddt() As DateTime
            Get
                Return mOutasset_enddt
            End Get
            Set(ByVal value As DateTime)
                mOutasset_enddt = value
            End Set
        End Property

        Public Property outasset_starttm() As String
            Get
                Return mOutasset_starttm
            End Get
            Set(ByVal value As String)
                mOutasset_starttm = value
            End Set
        End Property

        Public Property outasset_endtm() As String
            Get
                Return mOutasset_endtm
            End Get
            Set(ByVal value As String)
                mOutasset_endtm = value
            End Set
        End Property

        Public Property employee_id_customer() As String
            Get
                Return mEmployee_id_customer
            End Get
            Set(ByVal value As String)
                mEmployee_id_customer = value
                setEmployee_id_customer()
            End Set
        End Property

        Public Property strukturunit_id_customer() As Decimal
            Get
                Return mStrukturunit_id_customer
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id_customer = value
                setDeptName()
            End Set
        End Property

        Public Property employee_id_customerhead() As String
            Get
                Return mEmployee_id_customerhead
            End Get
            Set(ByVal value As String)
                mEmployee_id_customerhead = value
                setEmployee_head()
            End Set
        End Property
        Public Property employee() As String
            Get
                Return mEmployee
            End Get
            Set(ByVal value As String)
                mEmployee = value
                setEmployee_name()
            End Set
        End Property
        Public Property outasset_item() As Int32
            Get
                Return mOutasset_item
            End Get
            Set(ByVal value As Int32)
                mOutasset_item = value
            End Set
        End Property

        Public Property project_id() As Decimal
            Get
                Return mProject_id
            End Get
            Set(ByVal value As Decimal)
                mProject_id = value
                setProject_name()
            End Set
        End Property

        Public Property show_id() As String
            Get
                Return mShow_id
            End Get
            Set(ByVal value As String)
                mShow_id = value
            End Set
        End Property

        Public Property show_epsnumber_st() As String
            Get
                Return mShow_epsnumber_st
            End Get
            Set(ByVal value As String)
                mShow_epsnumber_st = value
            End Set
        End Property

        Public Property show_epsnumber_ed() As String
            Get
                Return mShow_epsnumber_ed
            End Get
            Set(ByVal value As String)
                mShow_epsnumber_ed = value
            End Set
        End Property

        Public Property outasset_lock() As Byte
            Get
                Return mOutasset_lock
            End Get
            Set(ByVal value As Byte)
                mOutasset_lock = value
            End Set
        End Property

        Public Property outasset_status() As String
            Get
                Return mOutasset_status
            End Get
            Set(ByVal value As String)
                mOutasset_status = value
            End Set
        End Property
        Public Property outasset_remark() As String
            Get
                Return mOutasset_remark
            End Get
            Set(ByVal value As String)
                mOutasset_remark = value
            End Set
        End Property

        Public Property outasset_inputdt() As DateTime
            Get
                Return mOutasset_inputdt
            End Get
            Set(ByVal value As DateTime)
                mOutasset_inputdt = value
            End Set
        End Property

        Public Property outasset_inputtm() As DateTime
            Get
                Return mOutasset_inputtm
            End Get
            Set(ByVal value As DateTime)
                mOutasset_inputtm = value
            End Set
        End Property
        Public Property outasset_purpose() As String
            Get
                Return mOutasset_purpose
            End Get
            Set(ByVal value As String)
                mOutasset_purpose = value
            End Set
        End Property

        Public Property strukturunit_namereport() As String
            Get
                Return mStrukturUnit_NameReport
            End Get
            Set(ByVal value As String)
                mStrukturUnit_NameReport = value
            End Set
        End Property

        Public Property Employee_id_customerhead_NameReport() As String
            Get
                Return mEmployee_id_customerhead_NameReport
            End Get
            Set(ByVal value As String)
                mEmployee_id_customerhead_NameReport = value
            End Set
        End Property
        Public Property Project_id_NameReport() As String
            Get
                Return mProject_id_NameReport
            End Get
            Set(ByVal value As String)
                mProject_id_NameReport = value
                setProject_name()
            End Set
        End Property

        Public Property Strukturunit_id_nameReport() As String
            Get
                Return mStrukturunit_id_nameReport
            End Get
            Set(ByVal value As String)
                mStrukturunit_id_nameReport = value

            End Set
        End Property
        Public Property employee_id_customer_nameReport() As String
            Get
                Return mEmployee_id_customer_nameReport
            End Get
            Set(ByVal value As String)
                mEmployee_id_customer_nameReport = value

            End Set
        End Property
        Public Property employee_namereport() As String
            Get
                Return mEmployee_namereport
            End Get
            Set(ByVal value As String)
                mEmployee_namereport = value

            End Set
        End Property
        Public Property Bookasset_InputDt() As DateTime
            Get
                Return mBookasset_InputDt
            End Get
            Set(ByVal value As DateTime)
                mBookasset_InputDt = value

            End Set
        End Property

        Public Property Bookasset_InputTm() As DateTime
            Get
                Return mBookasset_InputTm
            End Get
            Set(ByVal value As DateTime)
                mBookasset_InputTm = value

            End Set
        End Property


        Public Sub New(ByVal DSN As String, ByVal top As Integer)
            Me.DSN = DSN
            Me.top = top
        End Sub

        Private Sub setChannelDesc()
            If mChannel_id <> "" Then
                Dim tblTerimaBarang As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" channel_id = '{0}' ", mChannel_id)
                    tblTerimaBarang = clsUtil.GetDataTable("ms_MstChannel_Select", Me.DSN, parCriteria)
                    If tblTerimaBarang.Rows.Count > 0 Then
                        Me.mChannel_namereport = Trim(tblTerimaBarang.Rows(0)("channel_namereport").ToString)
                        Me.mChannel_address = Trim(tblTerimaBarang.Rows(0)("channel_address").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving channel desc.")
                Finally
                    parCriteria = Nothing
                    tblTerimaBarang = Nothing
                End Try
            End If
        End Sub

        Private Sub setDeptName()
            If mStrukturunit_id_customer > 0 Then
                Dim tblTerimaBarang As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" strukturunit_id = {0} ", mStrukturunit_id_customer)
                    tblTerimaBarang = clsUtil.GetDataTable("ms_MstStrukturUnit_Select", Me.DSN, parCriteria)
                    If tblTerimaBarang.Rows.Count > 0 Then
                        Me.mStrukturUnit_NameReport = Trim(tblTerimaBarang.Rows(0)("strukturunit_name").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Master_StukturUnit")
                Finally
                    parCriteria = Nothing
                    tblTerimaBarang = Nothing
                End Try
            End If
        End Sub
        Private Sub setEmployee_head()
            If mEmployee_id_customerhead <> "" Then
                Dim tblempoyee As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mEmployee_id_customerhead)
                    tblempoyee = clsUtil.GetDataTable("ms_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblempoyee.Rows.Count > 0 Then
                        Me.mEmployee_id_customerhead_NameReport = Trim(tblempoyee.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Master_Employee")
                Finally
                    parCriteria = Nothing
                    tblempoyee = Nothing
                End Try
            End If
        End Sub

        Private Sub setProject_name()
            If mProject_id > 0 Then
                Dim tblProject As DataTable
                Dim parCriteria As OleDbParameter
                Dim parcriteria1 As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@channel_id", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(mChannel_id)

                    parcriteria1 = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parcriteria1.Value = String.Format(" budget_id = {0} ", mProject_id)
                    tblProject = clsUtil.GetDataTable("as_MstProject_Select", Me.DSN, parCriteria, parcriteria1)
                    If tblProject.Rows.Count > 0 Then
                        Me.mProject_id_NameReport = Trim(tblProject.Rows(0)("budget_name").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Master_Project")
                Finally
                    parCriteria = Nothing
                    tblProject = Nothing
                End Try
            End If
        End Sub

        Private Sub setstrukturunit_id()

            If mStrukturunit_id > 0 Then
                Dim tblstrukturunit_id As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" strukturunit_id = {0} ", mStrukturunit_id)
                    tblstrukturunit_id = clsUtil.GetDataTable("as_MstStrukturUnit_Select", Me.DSN, parCriteria)
                    If tblstrukturunit_id.Rows.Count > 0 Then
                        Me.mStrukturunit_id_nameReport = Trim(tblstrukturunit_id.Rows(0)("strukturunit_name").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Master_Project")
                Finally
                    parCriteria = Nothing
                    tblstrukturunit_id = Nothing
                End Try
            End If
        End Sub

        Private Sub setEmployee_id_customer()
            If mEmployee_id_customer <> "" Then
                Dim tblempoyee As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mEmployee_id_customer)
                    tblempoyee = clsUtil.GetDataTable("ms_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblempoyee.Rows.Count > 0 Then
                        Me.mEmployee_id_customer_nameReport = Trim(tblempoyee.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Master_Employee")
                Finally
                    parCriteria = Nothing
                    tblempoyee = Nothing
                End Try
            End If
        End Sub
        Private Sub setEmployee_name()
            If mEmployee <> "" Then
                Dim tblempoyee As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mEmployee)
                    tblempoyee = clsUtil.GetDataTable("ms_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblempoyee.Rows.Count > 0 Then
                        Me.mEmployee_namereport = Trim(tblempoyee.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Master_Employee")
                Finally
                    parCriteria = Nothing
                    tblempoyee = Nothing
                End Try
            End If
        End Sub
        Private Sub setbookasset_id()
            If mBookasset_id <> "" Then
                Dim tblBookAsset_id As DataTable
                Dim parCriteria As OleDbParameter
                Dim parchannel As OleDbParameter
                Dim partop As OleDbParameter

                Try
                    parchannel = New OleDbParameter("@channel_id", OleDbType.VarChar, 10)
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    partop = New OleDbParameter("@top", OleDbType.Integer)
                    parchannel.Value = mChannel_id
                    parCriteria.Value = String.Format(" and bookasset_id = '{0}' ", mBookasset_id)
                    partop.Value = Me.top
                    tblBookAsset_id = clsUtil.GetDataTable("as_TrnBookasset_Select", Me.DSN, parchannel, parCriteria, partop)
                    If tblBookAsset_id.Rows.Count > 0 Then
                        Me.mBookasset_InputDt = tblBookAsset_id.Rows(0)("bookasset_inputdt")
                        Me.mBookasset_InputTm = tblBookAsset_id.Rows(0)("bookasset_inputdt")
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Master_Project")
                Finally
                    parCriteria = Nothing
                    tblBookAsset_id = Nothing
                End Try
            End If
        End Sub
    End Class
End Namespace