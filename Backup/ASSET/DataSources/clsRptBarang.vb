Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptBarang
        Private DSN As String

        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mTerimabarang_id As String
        Private mTerimabarang_tgl As DateTime
        Private mTerimabarang_status As String
        Private mOrder_id As String
        Private mPa_ref As String
        Private mRekanan_id As Decimal
        Private mTerimabarang_appacc As Byte
        Private mEmployee_id_pemilik As String
        Private mStrukturunit_id_pemilik As Decimal
        Private mAccounting_applogin As String
        Private mAccounting_appdt As DateTime
        Private mTerimabarang_appprc As Byte
        Private mProcurement_applogin As String
        Private mProcurement_appdt As DateTime
        Private mTerimabarang_cetakbpb As Int32
        Private mTerimabarang_cetakbkb As Int32
        Private mTerimabarang_item As Int32
        Private mInputby As String
        Private mInputdt As DateTime
        Private mEditby As String
        Private mEditdt As DateTime
        Private mUsedby As String
        Private mUseddt As DateTime
        Private mUser_proc As String
        Private mUser_accounting As String
        Private mLocation As String
        Private mUser_applogin As String
        Private mNotes As String
        Private mStatus_kedatangan As String

        Private mStrukturUnit1_NameReport As String
        Private mStrukturUnit_NameReport As String

        Private mEmployee_name_pemilik As String
        Private mProc_full As String
        Private mUser_pic As String
        Private mUsed_by As String
        Private mBudget_id As String
        Private mBudget_name As String
        Private mshooting_date As Date
        Public Property user_pic() As String

            Get
                Return mUser_pic
            End Get
            Set(ByVal value As String)
                mUser_pic = value

            End Set
        End Property
        Public Property used_by() As String

            Get
                Return mUsed_by
            End Get
            Set(ByVal value As String)
                mUsed_by = value

            End Set
        End Property
        Public Property shooting_date() As Date
            Get
                Return mshooting_date
            End Get
            Set(ByVal value As Date)
                mshooting_date = value
            End Set
        End Property
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

        Public Property terimabarang_id() As String
            Get
                Return mTerimabarang_id
            End Get
            Set(ByVal value As String)
                mTerimabarang_id = value
            End Set
        End Property

        Public Property terimabarang_tgl() As DateTime
            Get
                Return mTerimabarang_tgl
            End Get
            Set(ByVal value As DateTime)
                mTerimabarang_tgl = value
            End Set
        End Property

        Public Property terimabarang_status() As String
            Get
                Return mTerimabarang_status
            End Get
            Set(ByVal value As String)
                mTerimabarang_status = value
            End Set
        End Property

        Public Property order_id() As String
            Get
                Return mOrder_id
            End Get
            Set(ByVal value As String)
                mOrder_id = value
            End Set
        End Property

        Public Property pa_ref() As String
            Get
                Return mPa_ref
            End Get
            Set(ByVal value As String)
                mPa_ref = value
            End Set
        End Property

        Public Property rekanan_id() As Decimal
            Get
                Return mRekanan_id
            End Get
            Set(ByVal value As Decimal)
                mRekanan_id = value
                setRekananName()
            End Set
        End Property

        Public Property terimabarang_appacc() As Byte
            Get
                Return mTerimabarang_appacc
            End Get
            Set(ByVal value As Byte)
                mTerimabarang_appacc = value
            End Set
        End Property

        Public Property employee_id_pemilik() As String
            Get
                Return mEmployee_id_pemilik
            End Get
            Set(ByVal value As String)
                mEmployee_id_pemilik = value
                setNamePemilik()

            End Set
        End Property

        Public Property strukturunit_id_pemilik() As Decimal
            Get
                Return mStrukturunit_id_pemilik
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id_pemilik = value
                setDeptName()
            End Set
        End Property

        Public Property accounting_applogin() As String
            Get
                Return mAccounting_applogin
            End Get
            Set(ByVal value As String)
                mAccounting_applogin = value
            End Set
        End Property

        Public Property accounting_appdt() As DateTime
            Get
                Return mAccounting_appdt
            End Get
            Set(ByVal value As DateTime)
                mAccounting_appdt = value
            End Set
        End Property

        Public Property terimabarang_appprc() As Byte
            Get
                Return mTerimabarang_appprc
            End Get
            Set(ByVal value As Byte)
                mTerimabarang_appprc = value

            End Set
        End Property

        Public Property procurement_applogin() As String
            Get
                Return mProcurement_applogin
            End Get
            Set(ByVal value As String)
                mProcurement_applogin = value
                setProcurement_name()
            End Set
        End Property

        Public Property procurement_appdt() As DateTime
            Get
                Return mProcurement_appdt
            End Get
            Set(ByVal value As DateTime)
                mProcurement_appdt = value
            End Set
        End Property

        Public Property terimabarang_cetakbpb() As Int32
            Get
                Return mTerimabarang_cetakbpb
            End Get
            Set(ByVal value As Int32)
                mTerimabarang_cetakbpb = value
            End Set
        End Property

        Public Property terimabarang_cetakbkb() As Int32
            Get
                Return mTerimabarang_cetakbkb
            End Get
            Set(ByVal value As Int32)
                mTerimabarang_cetakbkb = value
            End Set
        End Property

        Public Property terimabarang_item() As Int32
            Get
                Return mTerimabarang_item
            End Get
            Set(ByVal value As Int32)
                mTerimabarang_item = value
            End Set
        End Property

        Public Property inputby() As String
            Get
                Return mInputby
            End Get
            Set(ByVal value As String)
                mInputby = value
            End Set
        End Property

        Public Property inputdt() As DateTime
            Get
                Return mInputdt
            End Get
            Set(ByVal value As DateTime)
                mInputdt = value
            End Set
        End Property

        Public Property editby() As String
            Get
                Return mEditby
            End Get
            Set(ByVal value As String)
                mEditby = value
            End Set
        End Property

        Public Property editdt() As DateTime
            Get
                Return mEditdt
            End Get
            Set(ByVal value As DateTime)
                mEditdt = value
            End Set
        End Property

        Public Property usedby() As String
            Get
                Return mUsedby
            End Get
            Set(ByVal value As String)
                mUsedby = value
            End Set
        End Property

        Public Property useddt() As DateTime
            Get
                Return mUseddt
            End Get
            Set(ByVal value As DateTime)
                mUseddt = value
            End Set
        End Property
        Public Property user_proc() As String
            Get
                Return mUser_proc
            End Get
            Set(ByVal value As String)
                mUser_proc = value
            End Set
        End Property
        Public Property user_accounting() As String
            Get
                Return mUser_accounting
            End Get
            Set(ByVal value As String)
                mUser_accounting = value
            End Set
        End Property

        Public Property location() As String
            Get
                Return mLocation
            End Get
            Set(ByVal value As String)
                mLocation = value
            End Set
        End Property

        Public Property user_applogin() As String
            Get
                Return mUser_applogin
            End Get
            Set(ByVal value As String)
                mUser_applogin = value
            End Set
        End Property
        Public Property notes() As String
            Get
                Return mNotes
            End Get
            Set(ByVal value As String)
                mNotes = value
            End Set
        End Property
        Public Property status_kedatangan() As String
            Get
                Return mStatus_kedatangan
            End Get
            Set(ByVal value As String)
                mStatus_kedatangan = value
            End Set
        End Property
        Public Property strukturunit1_namereport() As String
            Get
                Return mStrukturUnit1_NameReport
            End Get
            Set(ByVal value As String)
                mStrukturUnit1_NameReport = value
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
        Public Property employee_name_pemilik() As String
            Get
                Return mEmployee_name_pemilik
            End Get
            Set(ByVal value As String)
                mEmployee_name_pemilik = value
            End Set
        End Property

        Public Property proc_full() As String
            Get
                Return mProc_full
            End Get
            Set(ByVal value As String)
                mProc_full = value
            End Set
        End Property

        Public Property budget_id() As String
            Get
                Return mBudget_id
            End Get
            Set(ByVal value As String)
                mBudget_id = value
                setbudgetname()
            End Set
        End Property
        Public Property budget_name() As String
            Get
                Return mBudget_name
            End Get
            Set(ByVal value As String)
                mBudget_name = value

            End Set
        End Property

        Private Sub setbudgetname()
            If mBudget_id <> "" Then
                Dim tblBudget As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" budget_id = {0} ", mBudget_id)
                    tblBudget = clsUtil.GetDataTable("pr_TrnBudget_Select", Me.DSN, parCriteria)
                    If tblBudget.Rows.Count > 0 Then
                        Me.mBudget_name = tblBudget.Rows(0)("budget_name").ToString
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving budget name desc.")
                Finally
                    parCriteria = Nothing
                    tblBudget = Nothing
                End Try
            End If
        End Sub

        Public Sub New(ByVal DSN As String)
            Me.DSN = DSN
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

        Private Sub setRekananName()
            If mRekanan_id > 0 Then
                Dim tblTerimaBarang As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" rekanan_id = {0} ", mRekanan_id)
                    tblTerimaBarang = clsUtil.GetDataTable("as_MstRekanan_select", Me.DSN, parCriteria)
                    If tblTerimaBarang.Rows.Count > 0 Then
                        Me.mStrukturUnit_NameReport = Trim(tblTerimaBarang.Rows(0)("rekanan_name").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving rekanan name")
                Finally
                    parCriteria = Nothing
                    tblTerimaBarang = Nothing
                End Try
            End If
        End Sub

        Private Sub setDeptName()
            If mStrukturUnit_id_pemilik > 0 Then
                Dim tblTerimaBarang As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" strukturunit_id = {0} ", mStrukturUnit_id_pemilik)
                    tblTerimaBarang = clsUtil.GetDataTable("cq_MstStrukturUnitRequest_Select", Me.DSN, parCriteria)
                    If tblTerimaBarang.Rows.Count > 0 Then
                        Me.mStrukturUnit1_NameReport = Trim(tblTerimaBarang.Rows(0)("strukturunit_name").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving dept name")
                Finally
                    parCriteria = Nothing
                    tblTerimaBarang = Nothing
                End Try
            End If
        End Sub

        Private Sub setNamePemilik()
            If mEmployee_id_pemilik <> "" Then
                Dim tblTerimaBarang As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mEmployee_id_pemilik)
                    tblTerimaBarang = clsUtil.GetDataTable("hr_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblTerimaBarang.Rows.Count > 0 Then
                        Me.mEmployee_name_pemilik = Trim(tblTerimaBarang.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving employee name.")
                Finally
                    parCriteria = Nothing
                    tblTerimaBarang = Nothing
                End Try
            End If
        End Sub

        Private Sub setProcurement_name()
            If mProcurement_applogin <> "" Then
                Dim tblProcName As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" username = '{0}' ", mProcurement_applogin)
                    tblProcName = clsUtil.GetDataTable("ms_MstUser_Select", Me.DSN, parCriteria)
                    If tblProcName.Rows.Count > 0 Then
                        Me.mProc_full = Trim(tblProcName.Rows(0)("user_fullname").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving user name.")
                Finally
                    parCriteria = Nothing
                    tblProcName = Nothing
                End Try
            End If
        End Sub
    End Class
End Namespace