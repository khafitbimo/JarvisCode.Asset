Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptTrnWriteoff
        Private DSN As String
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mWriteoff_id As String
        Private mWriteoff_dt As DateTime
        Private mEmployee_id_reportby As String
        Private mEmployee_id_reportby_string As String
        Private mStrukturunit_id_reportby As Decimal
        Private mEmployee_id_approvedby As String
        Private mWriteoff_inputby As String
        Private mWriteoff_date As DateTime
        Private mLock As Byte

        Private mStrukturunit_id_owner As String
        Private mStrukturunit_parent_owner As String
        Private mEmployee_id_owner_string As String

        Private mEmployee_id_internal_audit As String
        Private mEmployee_id_procurement As String
        Private mEmployee_id_accounting As String
        Private mEmployee_id_frm_director As String
        Private mEmployee_id_president_director As String
        Private mEmployee_id_commissioner As String

        Private mEmployee_id_internal_audit_string As String
        Private mEmployee_id_procurement_string As String
        Private mEmployee_id_accounting_string As String
        Private mEmployee_id_frm_director_string As String
        Private mEmployee_id_president_director_string As String
        Private mEmployee_id_commissioner_string As String
        Private mEmployee_id_owner_dept_head_string As String
        Private mEmployee_id_owner_div_head_string As String
        Private mEmployee_id_owner_director_string As String

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
        Public Property writeoff_id() As String
            Get
                Return mWriteoff_id
            End Get
            Set(ByVal value As String)
                mWriteoff_id = value
            End Set
        End Property

        Public Property writeoff_dt() As DateTime
            Get
                Return mWriteoff_dt
            End Get
            Set(ByVal value As DateTime)
                mWriteoff_dt = value
            End Set
        End Property

        Public Property employee_id_reportby() As String
            Get
                Return mEmployee_id_reportby
            End Get
            Set(ByVal value As String)
                mEmployee_id_reportby = value
            End Set
        End Property

        Public Property employee_id_reportby_string() As String
            Get
                Return mEmployee_id_reportby_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_reportby_string = value
            End Set
        End Property

        Public Property strukturunit_id_reportby() As Decimal
            Get
                Return mStrukturunit_id_reportby
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id_reportby = value
            End Set
        End Property

        Public Property employee_id_approvedby() As String
            Get
                Return mEmployee_id_approvedby
            End Get
            Set(ByVal value As String)
                mEmployee_id_approvedby = value
            End Set
        End Property

        Public Property writeoff_inputby() As String
            Get
                Return mWriteoff_inputby
            End Get
            Set(ByVal value As String)
                mWriteoff_inputby = value
            End Set
        End Property

        Public Property writeoff_date() As DateTime
            Get
                Return mWriteoff_date
            End Get
            Set(ByVal value As DateTime)
                mWriteoff_date = value
            End Set
        End Property

        Public Property lock() As Byte
            Get
                Return mLock
            End Get
            Set(ByVal value As Byte)
                mLock = value
            End Set
        End Property

        Public Property strukturunit_id_owner() As String
            Get
                Return mStrukturunit_id_owner
            End Get
            Set(ByVal value As String)
                mStrukturunit_id_owner = value
            End Set
        End Property


        Public Property strukturunit_parent_owner() As String
            Get
                Return mStrukturunit_parent_owner
            End Get
            Set(ByVal value As String)
                mStrukturunit_parent_owner = value
            End Set
        End Property
        Public Property employee_id_owner_string() As String
            Get
                Return mEmployee_id_owner_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_owner_string = value
            End Set
        End Property

        Public Property employee_id_internal_audit() As String
            Get
                Return mEmployee_id_internal_audit
            End Get
            Set(ByVal value As String)
                mEmployee_id_internal_audit = value
            End Set
        End Property

        Public Property employee_id_procurement() As String
            Get
                Return mEmployee_id_procurement
            End Get
            Set(ByVal value As String)
                mEmployee_id_procurement = value
            End Set
        End Property

        Public Property employee_id_accounting() As String
            Get
                Return mEmployee_id_accounting
            End Get
            Set(ByVal value As String)
                mEmployee_id_accounting = value
            End Set
        End Property

        Public Property employee_id_frm_director() As String
            Get
                Return mEmployee_id_frm_director
            End Get
            Set(ByVal value As String)
                mEmployee_id_frm_director = value
            End Set
        End Property

        Public Property employee_id_president_director() As String
            Get
                Return mEmployee_id_president_director
            End Get
            Set(ByVal value As String)
                mEmployee_id_president_director = value
            End Set
        End Property


        Public Property employee_id_commissioner() As String
            Get
                Return mEmployee_id_commissioner
            End Get
            Set(ByVal value As String)
                mEmployee_id_commissioner = value
            End Set
        End Property

        Public Property employee_id_internal_audit_string() As String
            Get
                Return mEmployee_id_internal_audit_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_internal_audit_string = value
            End Set
        End Property

        Public Property employee_id_procurement_string() As String
            Get
                Return mEmployee_id_procurement_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_procurement_string = value
            End Set
        End Property

        Public Property employee_id_accounting_string() As String
            Get
                Return mEmployee_id_accounting_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_accounting_string = value
            End Set
        End Property

        Public Property employee_id_frm_director_string() As String
            Get
                Return mEmployee_id_frm_director_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_frm_director_string = value
            End Set
        End Property

        Public Property employee_id_president_director_string() As String
            Get
                Return mEmployee_id_president_director_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_president_director_string = value
            End Set
        End Property


        Public Property employee_id_commissioner_string() As String
            Get
                Return mEmployee_id_commissioner_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_commissioner_string = value
            End Set
        End Property
        Public Property employee_id_owner_dept_head_string() As String
            Get
                Return mEmployee_id_owner_dept_head_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_owner_dept_head_string = value
            End Set
        End Property
        Public Property employee_id_owner_div_head_string() As String
            Get
                Return mEmployee_id_owner_div_head_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_owner_div_head_string = value
            End Set
        End Property
        Public Property employee_id_owner_director_string() As String
            Get
                Return mEmployee_id_owner_director_string
            End Get
            Set(ByVal value As String)
                mEmployee_id_owner_director_string = value
            End Set
        End Property
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

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
        End Sub
    End Class
End Namespace