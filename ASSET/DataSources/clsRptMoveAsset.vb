Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptMoveAsset
        Private DSN As String
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mMoveasset_id As String
        Private mMoveasset_tgl As DateTime
        Private mMoveasset_strukturunit As Decimal
        Private mMoveasset_report As String
        Private mMoveasset_acct As String
        Private mEmployee_id_old As String
        Private mStrukturunit_id_old As Decimal
        Private mEmployee_id_new As String
        Private mStrukturunit_id_new As Decimal
        Private mMoveasset_remark As String
        Private mMoveasset_item As Int32

        Private mMoveasset_strukturunit_string As String
        Private mStrukturunit_id_old_string As String
        Private mStrukturunit_id_new_string As String
        Private mMoveasset_report_string As String
        Private mMoveasset_acct_string As String
        Private mEmployee_id_old_string As String
        Private mEmployee_id_new_string As String

        Private mEmployee_old_depthead_string As String
        Private mEmployee_old_divhead_string As String
        Private mEmployee_new_depthead_string As String
        Private mEmployee_new_divhead_string As String
        Private mEmployee_acc_string As String

        Private mStrukturunit_id_old_divisi As String
        Private mStrukturunit_id_new_divisi As String

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

        Public Property moveasset_id() As String
            Get
                Return mMoveasset_id
            End Get
            Set(ByVal value As String)
                mMoveasset_id = value
            End Set
        End Property

        Public Property moveasset_tgl() As DateTime
            Get
                Return mMoveasset_tgl
            End Get
            Set(ByVal value As DateTime)
                mMoveasset_tgl = value
            End Set
        End Property

        Public Property moveasset_strukturunit() As Decimal
            Get
                Return mMoveasset_strukturunit
            End Get
            Set(ByVal value As Decimal)
                mMoveasset_strukturunit = value
                setNameDepartment()
            End Set
        End Property

        Public Property moveasset_report() As String
            Get
                Return mMoveasset_report
            End Get
            Set(ByVal value As String)
                mMoveasset_report = value
                setNameEmployeeReport()
            End Set
        End Property

        Public Property moveasset_acct() As String
            Get
                Return mMoveasset_acct
            End Get
            Set(ByVal value As String)
                mMoveasset_acct = value
                setNameEmployeeAcct()
            End Set
        End Property

        Public Property employee_id_old() As String
            Get
                Return mEmployee_id_old
            End Get
            Set(ByVal value As String)
                mEmployee_id_old = value
                setNameEmployeeOld()
            End Set
        End Property

        Public Property strukturunit_id_old() As Decimal
            Get
                Return mStrukturunit_id_old
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id_old = value
                setNameDepartmentOld()
            End Set
        End Property

        Public Property employee_id_new() As String
            Get
                Return mEmployee_id_new
            End Get
            Set(ByVal value As String)
                mEmployee_id_new = value
                setNameEmployeeNew()
            End Set
        End Property

        Public Property strukturunit_id_new() As Decimal
            Get
                Return mStrukturunit_id_new
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id_new = value
                setNameDepartmentNew()
            End Set
        End Property

        Public Property moveasset_remark() As String
            Get
                Return mMoveasset_remark
            End Get
            Set(ByVal value As String)
                mMoveasset_remark = value
            End Set
        End Property

        Public Property moveasset_item() As Int32
            Get
                Return mMoveasset_item
            End Get
            Set(ByVal value As Int32)
                mMoveasset_item = value
            End Set
        End Property

        Public Property Moveasset_strukturunit_string() As String
            Get
                Return mMoveasset_strukturunit_string
            End Get
            Set(ByVal value As String)
                mMoveasset_strukturunit_string = value
            End Set
        End Property

        Public Property Strukturunit_id_old_string() As String
            Get
                Return mStrukturunit_id_old_string
            End Get
            Set(ByVal value As String)
                mStrukturunit_id_old_string = value
            End Set
        End Property

        Public Property Strukturunit_id_new_string() As String
            Get
                Return mStrukturunit_id_new_string
            End Get
            Set(ByVal value As String)
                mStrukturunit_id_new_string = value
            End Set
        End Property

        Public Property Moveasset_report_string() As String
            Get
                Return mMoveasset_report_string
            End Get
            Set(ByVal value As String)
                mMoveasset_report_string = value
            End Set
        End Property

        Public Property Moveasset_acct_string() As String
            Get
                Return mMoveasset_acct_string
            End Get
            Set(ByVal value As String)
                mMoveasset_acct_string = value
            End Set
        End Property

        Public Property Employee_id_old_string() As String
            Get
                Return mEmployee_id_old_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_old_string = value
            End Set
        End Property

        Public Property Employee_id_new_string() As String
            Get
                Return mEmployee_id_new_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_new_string = value
            End Set
        End Property

        Public Property employee_old_depthead_string() As String
            Get
                Return mEmployee_old_depthead_string
            End Get
            Set(ByVal value As String)
                mEmployee_old_depthead_string = value
            End Set
        End Property
        Public Property employee_old_divhead_string() As String
            Get
                Return mEmployee_old_divhead_string
            End Get
            Set(ByVal value As String)
                mEmployee_old_divhead_string = value
            End Set
        End Property
        Public Property employee_new_depthead_string() As String
            Get
                Return mEmployee_new_depthead_string
            End Get
            Set(ByVal value As String)
                mEmployee_new_depthead_string = value
            End Set
        End Property
        Public Property employee_new_divhead_string() As String
            Get
                Return mEmployee_new_divhead_string
            End Get
            Set(ByVal value As String)
                mEmployee_new_divhead_string = value
            End Set
        End Property
        Public Property employee_acc_string() As String
            Get
                Return mEmployee_acc_string
            End Get
            Set(ByVal value As String)
                mEmployee_acc_string = value
            End Set
        End Property

        Public Property Strukturunit_id_old_divisi() As String
            Get
                Return mStrukturunit_id_old_divisi
            End Get
            Set(ByVal value As String)
                mStrukturunit_id_old_divisi = value
            End Set
        End Property
        Public Property Strukturunit_id_new_divisi() As String
            Get
                Return mStrukturunit_id_new_divisi
            End Get
            Set(ByVal value As String)
                mStrukturunit_id_new_divisi = value
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

        Private Sub setNameDepartment()
            If mMoveasset_strukturunit <> 0 Then
                Dim tblMoveasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" strukturunit_id = '{0}' ", mMoveasset_strukturunit)
                    tblMoveasset = clsUtil.GetDataTable("as_MstStrukturUnit_Select", Me.DSN, parCriteria)
                    If tblMoveasset.Rows.Count > 0 Then
                        Me.mMoveasset_strukturunit_string = Trim(tblMoveasset.Rows(0)("strukturunit_name").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving department name.")
                Finally
                    parCriteria = Nothing
                    tblMoveasset = Nothing
                End Try
            End If
        End Sub

        Private Sub setNameDepartmentOld()
            If mStrukturunit_id_old <> 0 Then
                Dim tblMoveasset As DataTable
                Dim tbl_parent As DataTable
                Dim parCriteria As OleDbParameter
                Dim strukturUnit_parent As Decimal

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" strukturunit_id = '{0}' ", mStrukturunit_id_old)
                    tblMoveasset = clsUtil.GetDataTable("as_MstStrukturUnit_Select", Me.DSN, parCriteria)
                    If tblMoveasset.Rows.Count > 0 Then
                        Me.mStrukturunit_id_old_string = Trim(tblMoveasset.Rows(0)("strukturunit_name").ToString)
                        strukturUnit_parent = tblMoveasset.Rows(0)("strukturunit_parent")

                        If strukturUnit_parent <> 0 Then
                            Try
                                parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                                parCriteria.Value = String.Format(" strukturunit_id = '{0}' ", strukturUnit_parent)
                                tbl_parent = clsUtil.GetDataTable("as_MstStrukturUnit_Select", Me.DSN, parCriteria)
                                If tbl_parent.Rows.Count > 0 Then
                                    Me.mStrukturunit_id_old_divisi = Trim(tbl_parent.Rows(0)("strukturunit_name").ToString)
                                End If

                            Catch ex As Exception
                                MsgBox("Error on retrieving parent department.")
                            End Try
                        End If
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving old department name.")
                Finally
                    parCriteria = Nothing
                    tblMoveasset = Nothing
                End Try
            End If
        End Sub

        Private Sub setNameDepartmentNew()
            If mStrukturunit_id_new <> 0 Then
                Dim tblMoveasset As DataTable
                Dim tbl_parent As DataTable
                Dim parCriteria As OleDbParameter
                Dim strukturUnit_parent As Decimal

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" strukturunit_id = '{0}' ", mStrukturunit_id_new)
                    tblMoveasset = clsUtil.GetDataTable("as_MstStrukturUnit_Select", Me.DSN, parCriteria)
                    If tblMoveasset.Rows.Count > 0 Then
                        Me.mStrukturunit_id_new_string = Trim(tblMoveasset.Rows(0)("strukturunit_name").ToString)
                        strukturUnit_parent = tblMoveasset.Rows(0)("strukturunit_parent")
                        If strukturUnit_parent <> 0 Then
                            Try
                                parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                                parCriteria.Value = String.Format(" strukturunit_id = '{0}' ", strukturUnit_parent)
                                tbl_parent = clsUtil.GetDataTable("as_MstStrukturUnit_Select", Me.DSN, parCriteria)
                                If tbl_parent.Rows.Count > 0 Then
                                    Me.mStrukturunit_id_new_divisi = Trim(tbl_parent.Rows(0)("strukturunit_name").ToString)
                                End If

                            Catch ex As Exception
                                MsgBox("Error on retrieving parent department.")
                            End Try
                        End If
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving new department name.")
                Finally
                    parCriteria = Nothing
                    tblMoveasset = Nothing
                End Try
            End If
        End Sub

        Private Sub setNameEmployeeReport()
            If mMoveasset_report <> "" Then
                Dim tblMoveasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mMoveasset_report)
                    tblMoveasset = clsUtil.GetDataTable("ms_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblMoveasset.Rows.Count > 0 Then
                        Me.mMoveasset_report_string = Trim(tblMoveasset.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving employee report name.")
                Finally
                    parCriteria = Nothing
                    tblMoveasset = Nothing
                End Try
            End If
        End Sub

        Private Sub setNameEmployeeAcct()
            If mMoveasset_acct <> "" Then
                Dim tblMoveasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mMoveasset_acct)
                    tblMoveasset = clsUtil.GetDataTable("ms_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblMoveasset.Rows.Count > 0 Then
                        Me.mMoveasset_acct_string = Trim(tblMoveasset.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving employee accounting name.")
                Finally
                    parCriteria = Nothing
                    tblMoveasset = Nothing
                End Try
            End If
        End Sub

        Private Sub setNameEmployeeOld()
            If mEmployee_id_old <> "" Then
                Dim tblMoveasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mEmployee_id_old)
                    tblMoveasset = clsUtil.GetDataTable("ms_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblMoveasset.Rows.Count > 0 Then
                        Me.mEmployee_id_old_string = Trim(tblMoveasset.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving old employee name.")
                Finally
                    parCriteria = Nothing
                    tblMoveasset = Nothing
                End Try
            End If
        End Sub

        Private Sub setNameEmployeeNew()
            If mEmployee_id_new <> "" Then
                Dim tblMoveasset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mEmployee_id_new)
                    tblMoveasset = clsUtil.GetDataTable("ms_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblMoveasset.Rows.Count > 0 Then
                        Me.mEmployee_id_new_string = Trim(tblMoveasset.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving new employee name.")
                Finally
                    parCriteria = Nothing
                    tblMoveasset = Nothing
                End Try
            End If
        End Sub

        

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace
