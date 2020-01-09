Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptTrnBookasset
        Private DSN As String

        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mBookasset_id As String

        Private mStrukturunit_id As Decimal
        Private mStrukturunit_name As String

        Private mBookasset_startdt As Date
        Private mBookasset_enddt As Date
        Private mBookasset_starttm As String
        Private mBookasset_endtm As String

        Private mEmployee_id_bookby As String
        Private mEmployee_name_bookby As String

        Private mStruktur_unit_bookby As Decimal
        Private mStruktur_unit_bookby_name As String

        Private mEmployee_id_customerhead As String
        Private mEmployee_name_customerhead As String

        Private mBookasset_item As Int32
        Private mBudget_id As Decimal
        Private mShow_id As String
        Private mShow_epsnumber_st As String
        Private mShow_epsnumber_ed As String
        Private mUsername_inputby As String
        Private mBookasset_inputdt As DateTime
        Private mBookasset_active As Boolean
        Private mOutasset_id As String
        Private mBookasset_remark As String
        Private mBookasset_purpose As String

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

        Public Property bookasset_id() As String
            Get
                Return mBookasset_id
            End Get
            Set(ByVal value As String)
                mBookasset_id = value
            End Set
        End Property

        Public Property strukturunit_id() As Decimal
            Get
                Return mStrukturunit_id
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id = value
                setDeptName()
            End Set
        End Property

        Public Property strukturunit_name() As String
            Get
                Return mStrukturunit_name
            End Get
            Set(ByVal value As String)
                mStrukturunit_name = value
            End Set
        End Property

        Public Property bookasset_startdt() As Date
            Get
                Return mBookasset_startdt
            End Get
            Set(ByVal value As DateTime)
                mBookasset_startdt = value
            End Set
        End Property

        Public Property bookasset_enddt() As Date
            Get
                Return mBookasset_enddt
            End Get
            Set(ByVal value As DateTime)
                mBookasset_enddt = value
            End Set
        End Property

        Public Property bookasset_starttm() As String
            Get
                Return mBookasset_starttm
            End Get
            Set(ByVal value As String)
                mBookasset_starttm = value
            End Set
        End Property

        Public Property bookasset_endtm() As String
            Get
                Return mBookasset_endtm
            End Get
            Set(ByVal value As String)
                mBookasset_endtm = value
            End Set
        End Property

        Public Property employee_id_bookby() As String
            Get
                Return mEmployee_id_bookby
            End Get
            Set(ByVal value As String)
                mEmployee_id_bookby = value
                setNameCustomer()
            End Set
        End Property

        Public Property employee_name_bookby() As String
            Get
                Return mEmployee_name_bookby
            End Get
            Set(ByVal value As String)
                mEmployee_name_bookby = value
            End Set
        End Property

        Public Property struktur_unit_bookby() As Decimal
            Get
                Return mStruktur_unit_bookby
            End Get
            Set(ByVal value As Decimal)
                mStruktur_unit_bookby = value
                setDeptName_BookBy()
            End Set
        End Property

        Public Property struktur_unit_bookby_name() As String
            Get
                Return mStruktur_unit_bookby_name
            End Get
            Set(ByVal value As String)
                mStruktur_unit_bookby_name = value
            End Set
        End Property

        Public Property employee_id_customerhead() As String
            Get
                Return mEmployee_id_customerhead
            End Get
            Set(ByVal value As String)
                mEmployee_id_customerhead = value
                setNameCustomerHead()
            End Set
        End Property

        Public Property employee_name_customerhead() As String
            Get
                Return mEmployee_name_customerhead
            End Get
            Set(ByVal value As String)
                mEmployee_name_customerhead = value
            End Set
        End Property

        Public Property bookasset_item() As Int32
            Get
                Return mBookasset_item
            End Get
            Set(ByVal value As Int32)
                mBookasset_item = value
            End Set
        End Property

        Public Property budget_id() As Decimal
            Get
                Return mBudget_id
            End Get
            Set(ByVal value As Decimal)
                mBudget_id = value
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

        Public Property username_inputby() As String
            Get
                Return mUsername_inputby
            End Get
            Set(ByVal value As String)
                mUsername_inputby = value
            End Set
        End Property

        Public Property bookasset_inputdt() As Date
            Get
                Return mBookasset_inputdt
            End Get
            Set(ByVal value As DateTime)
                mBookasset_inputdt = value
            End Set
        End Property

        Public Property bookasset_active() As Boolean
            Get
                Return mBookasset_active
            End Get
            Set(ByVal value As Boolean)
                mBookasset_active = value
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

        Public Property bookasset_remark() As String
            Get
                Return mBookasset_remark
            End Get
            Set(ByVal value As String)
                mBookasset_remark = value
            End Set
        End Property

        Public Property bookasset_purpose() As String
            Get
                Return mBookasset_purpose
            End Get
            Set(ByVal value As String)
                mBookasset_purpose = value
            End Set
        End Property


        Private Sub setChannelDesc()
            If mChannel_id <> "" Then
                Dim tblBookasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" channel_id = '{0}' ", mChannel_id)
                    tblBookasset = clsUtil.GetDataTable("ms_MstChannel_Select", Me.DSN, parCriteria)
                    If tblBookasset.Rows.Count > 0 Then
                        Me.mChannel_namereport = Trim(tblBookasset.Rows(0)("channel_namereport").ToString)
                        Me.mChannel_address = Trim(tblBookasset.Rows(0)("channel_address").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving channel desc.")
                Finally
                    parCriteria = Nothing
                    tblBookasset = Nothing
                End Try
            End If
        End Sub

        Private Sub setNameCustomer()
            If mEmployee_id_bookby <> "" Then
                Dim tblBookasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mEmployee_id_bookby)
                    tblBookasset = clsUtil.GetDataTable("hr_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblBookasset.Rows.Count > 0 Then
                        Me.mEmployee_name_bookby = Trim(tblBookasset.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving employee name.")
                Finally
                    parCriteria = Nothing
                    tblBookasset = Nothing
                End Try
            End If
        End Sub

        Private Sub setNameCustomerHead()
            If mEmployee_id_customerhead <> "" Then
                Dim tblBookasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mEmployee_id_customerhead)
                    tblBookasset = clsUtil.GetDataTable("hr_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblBookasset.Rows.Count > 0 Then
                        Me.mEmployee_name_customerhead = Trim(tblBookasset.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving employee name.")
                Finally
                    parCriteria = Nothing
                    tblBookasset = Nothing
                End Try
            End If
        End Sub

        Private Sub setDeptName()
            If mStrukturunit_id > 0 Then
                Dim tblBookasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" strukturunit_id = {0} ", mStrukturunit_id)
                    tblBookasset = clsUtil.GetDataTable("cq_MstStrukturUnitRequest_Select", Me.DSN, parCriteria)
                    If tblBookasset.Rows.Count > 0 Then
                        Me.mStrukturunit_name = Trim(tblBookasset.Rows(0)("strukturunit_name").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving dept name")
                Finally
                    parCriteria = Nothing
                    tblBookasset = Nothing
                End Try
            End If
        End Sub

        Private Sub setDeptName_BookBy()
            If mStruktur_unit_bookby > 0 Then
                Dim tblBookasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" strukturunit_id = {0} ", mStruktur_unit_bookby)
                    tblBookasset = clsUtil.GetDataTable("cq_MstStrukturUnitRequest_Select", Me.DSN, parCriteria)
                    If tblBookasset.Rows.Count > 0 Then
                        Me.mStruktur_unit_bookby_name = Trim(tblBookasset.Rows(0)("strukturunit_name").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving dept name")
                Finally
                    parCriteria = Nothing
                    tblBookasset = Nothing
                End Try
            End If
        End Sub

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace