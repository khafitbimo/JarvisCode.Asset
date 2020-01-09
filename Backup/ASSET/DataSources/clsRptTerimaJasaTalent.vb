Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptTerimaJasaTalent
        Private DSN As String
        Private mTerimajasa_id As String
        Private mTerimajasa_date As DateTime
        Private mTerimajasa_type As String
        Private mOrder_id As String
        Private mBudget_id As Decimal
        Private mRekanan_id As Decimal
        Private mEmployee_id_owner As String
        Private mStrukturunit_id As Decimal
        'Private mTerimajasa_qtyitem As Int32
        'Private mTerimajasa_qtyrealization As Int32
        'Private mOrder_qty As Int32

        Private mTerimajasa_qtyitem As Decimal
        Private mTerimajasa_qtyrealization As Decimal
        Private mOrder_qty As Decimal

        Private mTerimajasa_status As String
        Private mTerimajasa_statusrealization As String
        Private mTerimajasa_location As String
        Private mTerimajasa_notes As String
        Private mTerimajasa_nosuratjalan As String
        Private mChannel_id As String
        Private mTerimajasa_isdisabled As Byte
        Private mTerimajasa_createby As String
        Private mTerimajasa_createdt As DateTime
        Private mTerimajasa_modifiedby As String
        Private mTerimajasa_modifieddt As DateTime
        Private mTerimajasa_appuser As Byte
        Private mTerimajasa_appuser_by As String
        Private mTerimajasa_appuser_dt As DateTime
        Private mTerimajasa_appspv As Byte
        Private mTerimajasa_appspv_by As String
        Private mTerimajasa_appspv_dt As DateTime
        Private mTerimajasa_appbma As Byte
        Private mTerimajasa_appbma_by As String
        Private mTerimajasa_appbma_dt As DateTime
        Private mTerimajasa_foreign As Decimal
        Private mCurrency_id As Decimal
        Private mTerimajasa_foreignrate As Decimal
        Private mTerimajasa_idrreal As Decimal
        Private mTerimajasa_pph As Decimal
        Private mTerimajasa_ppn As Decimal
        Private mTerimajasa_disc As Decimal
        Private mTerimajasa_cetakbpj As Int32

        'View
        Private mBudget_name As String
        Private mProgram_name As String
        Private mChannel_namereport As String
        Private mChannel_address As String
        Private mDomain_name As String
        Private mRekanan_name As String
        Private mStrukturunit_name As String
        Private mEmployee_name As String
        Private mTerimajasa_appspv_by_name As String

        Private mShootingdate_start As Date
        Private mShootingdate_end As Date

        Private mRequest_id As String
        Private mProducer As String
        Private mUser_by As String


        Public Property terimajasa_id() As String
            Get
                Return mTerimajasa_id
            End Get
            Set(ByVal value As String)
                mTerimajasa_id = value
            End Set
        End Property

        Public Property terimajasa_date() As DateTime
            Get
                Return mTerimajasa_date
            End Get
            Set(ByVal value As DateTime)
                mTerimajasa_date = value
            End Set
        End Property

        Public Property terimajasa_type() As String
            Get
                Return mTerimajasa_type
            End Get
            Set(ByVal value As String)
                mTerimajasa_type = value
            End Set
        End Property

        Public Property order_id() As String
            Get
                Return mOrder_id

            End Get
            Set(ByVal value As String)
                mOrder_id = value
                setProgramName()
                setProducerName()
            End Set
        End Property

        Public Property budget_id() As Decimal
            Get
                Return mBudget_id

            End Get
            Set(ByVal value As Decimal)
                mBudget_id = value
                setbudgetname()
            End Set
        End Property

        Public Property rekanan_id() As Decimal
            Get
                Return mRekanan_id
            End Get
            Set(ByVal value As Decimal)
                mRekanan_id = value
            End Set
        End Property

        Public Property employee_id_owner() As String
            Get
                Return mEmployee_id_owner
            End Get
            Set(ByVal value As String)
                mEmployee_id_owner = value
                setNamePemilik()
            End Set
        End Property

        Public Property strukturunit_id() As Decimal
            Get
                Return mStrukturunit_id
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id = value
                setStrukturunitName()
            End Set
        End Property

        'Public Property terimajasa_qtyitem() As Int32
        '    Get
        '        Return mTerimajasa_qtyitem
        '    End Get
        '    Set(ByVal value As Int32)
        '        mTerimajasa_qtyitem = value
        '    End Set
        'End Property

        'Public Property terimajasa_qtyrealization() As Int32
        '    Get
        '        Return mTerimajasa_qtyrealization
        '    End Get
        '    Set(ByVal value As Int32)
        '        mTerimajasa_qtyrealization = value
        '    End Set
        'End Property

        'Public Property order_qty() As Int32
        '    Get
        '        Return mOrder_qty
        '    End Get
        '    Set(ByVal value As Int32)
        '        mOrder_qty = value
        '    End Set
        'End Property

        Public Property terimajasa_qtyitem() As Decimal
            Get
                Return mTerimajasa_qtyitem
            End Get
            Set(ByVal value As Decimal)
                mTerimajasa_qtyitem = value
            End Set
        End Property

        Public Property terimajasa_qtyrealization() As Decimal
            Get
                Return mTerimajasa_qtyrealization
            End Get
            Set(ByVal value As Decimal)
                mTerimajasa_qtyrealization = value
            End Set
        End Property

        Public Property order_qty() As Decimal
            Get
                Return mOrder_qty
            End Get
            Set(ByVal value As Decimal)
                mOrder_qty = value
            End Set
        End Property

        Public Property terimajasa_status() As String
            Get
                Return mTerimajasa_status
            End Get
            Set(ByVal value As String)
                mTerimajasa_status = value
            End Set
        End Property

        Public Property terimajasa_statusrealization() As String
            Get
                Return mTerimajasa_statusrealization
            End Get
            Set(ByVal value As String)
                mTerimajasa_statusrealization = value
            End Set
        End Property

        Public Property terimajasa_location() As String
            Get
                Return mTerimajasa_location
            End Get
            Set(ByVal value As String)
                mTerimajasa_location = value
            End Set
        End Property

        Public Property terimajasa_notes() As String
            Get
                Return mTerimajasa_notes
            End Get
            Set(ByVal value As String)
                mTerimajasa_notes = value
            End Set
        End Property

        Public Property terimajasa_nosuratjalan() As String
            Get
                Return mTerimajasa_nosuratjalan
            End Get
            Set(ByVal value As String)
                mTerimajasa_nosuratjalan = value
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

        Public Property terimajasa_isdisabled() As Byte
            Get
                Return mTerimajasa_isdisabled
            End Get
            Set(ByVal value As Byte)
                mTerimajasa_isdisabled = value
            End Set
        End Property

        Public Property terimajasa_createby() As String
            Get
                Return mTerimajasa_createby
            End Get
            Set(ByVal value As String)
                mTerimajasa_createby = value
            End Set
        End Property

        Public Property terimajasa_createdt() As DateTime
            Get
                Return mTerimajasa_createdt
            End Get
            Set(ByVal value As DateTime)
                mTerimajasa_createdt = value
            End Set
        End Property

        Public Property terimajasa_modifiedby() As String
            Get
                Return mTerimajasa_modifiedby
            End Get
            Set(ByVal value As String)
                mTerimajasa_modifiedby = value
            End Set
        End Property

        Public Property terimajasa_modifieddt() As DateTime
            Get
                Return mTerimajasa_modifieddt
            End Get
            Set(ByVal value As DateTime)
                mTerimajasa_modifieddt = value
            End Set
        End Property

        Public Property terimajasa_appuser() As Byte
            Get
                Return mTerimajasa_appuser
            End Get
            Set(ByVal value As Byte)
                mTerimajasa_appuser = value
            End Set
        End Property

        Public Property terimajasa_appuser_by() As String
            Get
                Return mTerimajasa_appuser_by
            End Get
            Set(ByVal value As String)
                mTerimajasa_appuser_by = value
            End Set
        End Property

        Public Property terimajasa_appuser_dt() As DateTime
            Get
                Return mTerimajasa_appuser_dt
            End Get
            Set(ByVal value As DateTime)
                mTerimajasa_appuser_dt = value
            End Set
        End Property

        Public Property terimajasa_appspv() As Byte
            Get
                Return mTerimajasa_appspv
            End Get
            Set(ByVal value As Byte)
                mTerimajasa_appspv = value
            End Set
        End Property

        Public Property terimajasa_appspv_by() As String
            Get
                Return mTerimajasa_appspv_by
            End Get
            Set(ByVal value As String)
                mTerimajasa_appspv_by = value
                setApproved_name()
            End Set
        End Property

        Public Property terimajasa_appspv_dt() As DateTime
            Get
                Return mTerimajasa_appspv_dt
            End Get
            Set(ByVal value As DateTime)
                mTerimajasa_appspv_dt = value
            End Set
        End Property

        Public Property terimajasa_appbma() As Byte
            Get
                Return mTerimajasa_appbma
            End Get
            Set(ByVal value As Byte)
                mTerimajasa_appbma = value
            End Set
        End Property

        Public Property terimajasa_appbma_by() As String
            Get
                Return mTerimajasa_appbma_by
            End Get
            Set(ByVal value As String)
                mTerimajasa_appbma_by = value
            End Set
        End Property

        Public Property terimajasa_appbma_dt() As DateTime
            Get
                Return mTerimajasa_appbma_dt
            End Get
            Set(ByVal value As DateTime)
                mTerimajasa_appbma_dt = value
            End Set
        End Property

        Public Property terimajasa_foreign() As Decimal
            Get
                Return mTerimajasa_foreign
            End Get
            Set(ByVal value As Decimal)
                mTerimajasa_foreign = value
            End Set
        End Property

        Public Property currency_id() As Decimal
            Get
                Return mCurrency_id
            End Get
            Set(ByVal value As Decimal)
                mCurrency_id = value
            End Set
        End Property

        Public Property terimajasa_foreignrate() As Decimal
            Get
                Return mTerimajasa_foreignrate
            End Get
            Set(ByVal value As Decimal)
                mTerimajasa_foreignrate = value
            End Set
        End Property

        Public Property terimajasa_idrreal() As Decimal
            Get
                Return mTerimajasa_idrreal
            End Get
            Set(ByVal value As Decimal)
                mTerimajasa_idrreal = value
            End Set
        End Property

        Public Property terimajasa_pph() As Decimal
            Get
                Return mTerimajasa_pph
            End Get
            Set(ByVal value As Decimal)
                mTerimajasa_pph = value
            End Set
        End Property

        Public Property terimajasa_ppn() As Decimal
            Get
                Return mTerimajasa_ppn
            End Get
            Set(ByVal value As Decimal)
                mTerimajasa_ppn = value
            End Set
        End Property

        Public Property terimajasa_disc() As Decimal
            Get
                Return mTerimajasa_disc
            End Get
            Set(ByVal value As Decimal)
                mTerimajasa_disc = value
            End Set
        End Property

        Public Property terimajasa_cetakbpj() As Int32
            Get
                Return mTerimajasa_cetakbpj
            End Get
            Set(ByVal value As Int32)
                mTerimajasa_cetakbpj = value
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

        Public Property program_name() As String
            Get
                Return mProgram_name
            End Get
            Set(ByVal value As String)
                mProgram_name = value
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

        Public Property domain_name() As String
            Get
                Return mDomain_name
            End Get
            Set(ByVal value As String)
                mDomain_name = value
            End Set
        End Property

        Public Property rekanan_name() As String
            Get
                Return mRekanan_name
            End Get
            Set(ByVal value As String)
                mRekanan_name = value
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

        Public Property employee_name() As String
            Get
                Return mEmployee_name
            End Get
            Set(ByVal value As String)
                mEmployee_name = value
            End Set
        End Property

        Public Property terimajasa_appspv_by_name() As String
            Get
                Return mTerimajasa_appspv_by_name
            End Get
            Set(ByVal value As String)
                mTerimajasa_appspv_by_name = value
            End Set
        End Property

        Public Property shooting_start() As Date
            Get
                Return mShootingdate_start
            End Get
            Set(ByVal value As Date)
                mShootingdate_start = value
            End Set
        End Property

        Public Property shooting_end() As Date
            Get
                Return mShootingdate_end
            End Get
            Set(ByVal value As Date)
                mShootingdate_end = value
            End Set
        End Property

        Public Property request_id() As String
            Get
                Return mRequest_id
            End Get
            Set(ByVal value As String)
                mRequest_id = value
            End Set
        End Property

        Public Property producer() As String
            Get
                Return mProducer
            End Get
            Set(ByVal value As String)
                mProducer = value
            End Set
        End Property

        Public Property userby() As String
            Get
                Return mUser_by
            End Get
            Set(ByVal value As String)
                mUser_by = value
            End Set
        End Property

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

                        Me.mDomain_name = Trim(tblTerimaBarang.Rows(0)("channel_domainname").ToString)

                        '---------------tambahan buat insosys baru 2012-- 19 April 2012---------------
                        Me.mDomain_name = Me.mDomain_name.Replace("\", "/")
                        Me.mDomain_name = "file:///" & Me.mDomain_name
                        '---------------------------------------------------------------

                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving channel desc.")
                Finally
                    parCriteria = Nothing
                    tblTerimaBarang = Nothing
                End Try
            End If
        End Sub
        Private Sub setbudgetname()
            If mBudget_id <> 0 Then
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

        Private Sub setProgramName()
            If mOrder_id <> "" Then
                Dim tblProgram As DataTable
                Dim parCriteria As OleDbParameter
                Dim parCriteria2 As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" order_id = '{0}' ", mOrder_id)
                    parCriteria2 = New OleDbParameter("@Limit", OleDbType.Integer, 4)
                    parCriteria2.Value = 1
                    tblProgram = clsUtil.GetDataTable("pr_TrnOrder_Select", Me.DSN, parCriteria, parCriteria2)
                    If tblProgram.Rows.Count > 0 Then
                        Me.mProgram_name = tblProgram.Rows(0)("order_prognm").ToString
                        Me.mShootingdate_start = tblProgram.Rows(0).Item("order_utilizeddatestart")
                        Me.mShootingdate_end = tblProgram.Rows(0).Item("order_utilizeddateend")
                        Me.mRequest_id = clsUtil.IsDbNull(tblProgram.Rows(0).Item("request_id"), "")
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Program And Shooting Date.")
                Finally
                    parCriteria = Nothing
                    tblProgram = Nothing
                End Try
            End If
        End Sub

        Private Sub setProducerName()
            If Me.mRequest_id <> "" Then
                Dim tblRequest As DataTable
                Dim parCriteria As OleDbParameter
                Dim parCriteria2 As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" request_id = '{0}' ", mRequest_id)
                    parCriteria2 = New OleDbParameter("@Top", OleDbType.Integer, 4)
                    parCriteria2.Value = 1
                    tblRequest = clsUtil.GetDataTable("cq_TrnRequest_Select", Me.DSN, parCriteria, parCriteria2)
                    If tblRequest.Rows.Count > 0 Then
                        Me.mProducer = tblRequest.Rows(0)("request_userpic").ToString
                        Me.mUser_by = tblRequest.Rows(0)("request_usedby").ToString
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Producer.")
                Finally
                    parCriteria = Nothing
                    tblRequest = Nothing
                End Try

            End If
        End Sub

        Private Sub setStrukturunitName()
            If mStrukturunit_id <> 0 Then
                Dim tblDepartment As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" strukturunit_id = '{0}' ", mStrukturunit_id)

                    tblDepartment = clsUtil.GetDataTable("ms_MstStrukturUnit_Select", Me.DSN, parCriteria)
                    If tblDepartment.Rows.Count > 0 Then
                        Me.mStrukturunit_name = tblDepartment.Rows(0)("strukturunit_name").ToString
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Despartment name.")
                Finally
                    parCriteria = Nothing
                    tblDepartment = Nothing
                End Try
            End If
        End Sub
        Private Sub setApproved_name()
            If mTerimajasa_appspv_by <> "" Then
                Dim tblAppName As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" username = '{0}' ", mTerimajasa_appspv_by)
                    tblAppName = clsUtil.GetDataTable("ms_MstUserInsosys_Select", Me.DSN, parCriteria)
                    If tblAppName.Rows.Count > 0 Then
                        Me.mTerimajasa_appspv_by_name = Trim(tblAppName.Rows(0)("user_fullname").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving user name.")
                Finally
                    parCriteria = Nothing
                    tblAppName = Nothing
                End Try
            End If
        End Sub
        Private Sub setNamePemilik()
            If mEmployee_id_owner <> "" Then
                Dim tblEmployeeName As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mEmployee_id_owner)
                    tblEmployeeName = clsUtil.GetDataTable("hr_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblEmployeeName.Rows.Count > 0 Then
                        Me.mEmployee_name = Trim(tblEmployeeName.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving employee name.")
                Finally
                    parCriteria = Nothing
                    tblEmployeeName = Nothing
                End Try
            End If
        End Sub
    End Class
End Namespace