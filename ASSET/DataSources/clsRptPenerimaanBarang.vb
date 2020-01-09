Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptPenerimaanBarang
        Private DSN As String
        Private mTerimabarang_id As String
        Private mTerimabarang_date As DateTime
        Private mTerimabarang_type As String
        Private mOrder_id As String
        Private mBudget_id As Decimal
        Private mBudget_name As String
        Private mRekanan_id As Decimal
        Private mRekanan_name As String
        Private mEmployee_id_owner As String
        Private mStrukturunit_id As Decimal
        Private mDepartment As String
        'Private mTerimabarang_qtyitem As Int32
        'Private mTerimabarang_qtyrealization As Int32
        'Private mOrder_qty As Int32

        Private mTerimabarang_qtyitem As Decimal
        Private mTerimabarang_qtyrealization As Decimal
        Private mOrder_qty As Decimal

        Private mTerimabarang_status As String
        Private mTerimabarang_statusrealization As String
        Private mTerimabarang_location As String
        Private mTerimabarang_notes As String
        Private mTerimabarang_nosuratjalan As String
        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String
        Private mDomain_name As String

        Private mTerimabarang_isdisabled As Byte
        Private mTerimabarang_createby As String
        Private mTerimabarang_createdt As DateTime
        Private mTerimabarang_modifiedby As String
        Private mTerimabarang_modifieddt As DateTime
        Private mTerimabarang_appuser As Byte
        Private mTerimabarang_appuser_by As String
        Private mTerimabarang_appuser_dt As DateTime
        Private mTerimabarang_appspv As Byte
        Private mTerimabarang_appspv_by As String
        Private mTerimabarang_appspv_dt As DateTime
        Private mTerimabarang_appacc As Byte
        Private mTerimabarang_appacc_by As String
        Private mTerimabarang_appacc_dt As DateTime
        Private mTerimabarang_foreign As Decimal
        Private mCurrency_id As Decimal
        Private mTerimabarang_foreignrate As Decimal
        Private mTerimabarang_idrreal As Decimal
        Private mTerimabarang_pph As Decimal
        Private mTerimabarang_ppn As Decimal
        Private mTerimabarang_disc As Decimal
        Private mTerimabarang_cetakbpb As Int32

        Public Property terimabarang_id() As String
            Get
                Return mTerimabarang_id
            End Get
            Set(ByVal value As String)
                mTerimabarang_id = value
            End Set
        End Property

        Public Property terimabarang_date() As DateTime
            Get
                Return mTerimabarang_date
            End Get
            Set(ByVal value As DateTime)
                mTerimabarang_date = value
            End Set
        End Property

        Public Property terimabarang_type() As String
            Get
                Return mTerimabarang_type
            End Get
            Set(ByVal value As String)
                mTerimabarang_type = value
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

        Public Property budget_id() As Decimal
            Get
                Return mBudget_id
            End Get
            Set(ByVal value As Decimal)
                mBudget_id = value
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
        Public Property rekanan_id() As Decimal
            Get
                Return mRekanan_id
            End Get
            Set(ByVal value As Decimal)
                mRekanan_id = value
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
        Public Property employee_id_owner() As String
            Get
                Return mEmployee_id_owner
            End Get
            Set(ByVal value As String)
                mEmployee_id_owner = value
            End Set
        End Property

        Public Property strukturunit_id() As Decimal
            Get
                Return mStrukturunit_id
            End Get
            Set(ByVal value As Decimal)
                mStrukturunit_id = value
            End Set
        End Property
        Public Property department() As String
            Get
                Return mDepartment
            End Get
            Set(ByVal value As String)
                mDepartment = value
            End Set
        End Property

        'Public Property terimabarang_qtyitem() As Int32
        '    Get
        '        Return mTerimabarang_qtyitem
        '    End Get
        '    Set(ByVal value As Int32)
        '        mTerimabarang_qtyitem = value
        '    End Set
        'End Property

        'Public Property terimabarang_qtyrealization() As Int32
        '    Get
        '        Return mTerimabarang_qtyrealization
        '    End Get
        '    Set(ByVal value As Int32)
        '        mTerimabarang_qtyrealization = value
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

        Public Property terimabarang_qtyitem() As Decimal
            Get
                Return mTerimabarang_qtyitem
            End Get
            Set(ByVal value As Decimal)
                mTerimabarang_qtyitem = value
            End Set
        End Property

        Public Property terimabarang_qtyrealization() As Decimal
            Get
                Return mTerimabarang_qtyrealization
            End Get
            Set(ByVal value As Decimal)
                mTerimabarang_qtyrealization = value
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

        Public Property terimabarang_status() As String
            Get
                Return mTerimabarang_status
            End Get
            Set(ByVal value As String)
                mTerimabarang_status = value
            End Set
        End Property

        Public Property terimabarang_statusrealization() As String
            Get
                Return mTerimabarang_statusrealization
            End Get
            Set(ByVal value As String)
                mTerimabarang_statusrealization = value
            End Set
        End Property

        Public Property terimabarang_location() As String
            Get
                Return mTerimabarang_location
            End Get
            Set(ByVal value As String)
                mTerimabarang_location = value
            End Set
        End Property

        Public Property terimabarang_notes() As String
            Get
                Return mTerimabarang_notes
            End Get
            Set(ByVal value As String)
                mTerimabarang_notes = value
            End Set
        End Property

        Public Property terimabarang_nosuratjalan() As String
            Get
                Return mTerimabarang_nosuratjalan
            End Get
            Set(ByVal value As String)
                mTerimabarang_nosuratjalan = value
            End Set
        End Property

        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
                Me.setChannelDesc()
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

        Public Property terimabarang_isdisabled() As Byte
            Get
                Return mTerimabarang_isdisabled
            End Get
            Set(ByVal value As Byte)
                mTerimabarang_isdisabled = value
            End Set
        End Property

        Public Property terimabarang_createby() As String
            Get
                Return mTerimabarang_createby
            End Get
            Set(ByVal value As String)
                mTerimabarang_createby = value
            End Set
        End Property

        Public Property terimabarang_createdt() As DateTime
            Get
                Return mTerimabarang_createdt
            End Get
            Set(ByVal value As DateTime)
                mTerimabarang_createdt = value
            End Set
        End Property

        Public Property terimabarang_modifiedby() As String
            Get
                Return mTerimabarang_modifiedby
            End Get
            Set(ByVal value As String)
                mTerimabarang_modifiedby = value
            End Set
        End Property

        Public Property terimabarang_modifieddt() As DateTime
            Get
                Return mTerimabarang_modifieddt
            End Get
            Set(ByVal value As DateTime)
                mTerimabarang_modifieddt = value
            End Set
        End Property

        Public Property terimabarang_appuser() As Byte
            Get
                Return mTerimabarang_appuser
            End Get
            Set(ByVal value As Byte)
                mTerimabarang_appuser = value
            End Set
        End Property

        Public Property terimabarang_appuser_by() As String
            Get
                Return mTerimabarang_appuser_by
            End Get
            Set(ByVal value As String)
                mTerimabarang_appuser_by = value
            End Set
        End Property

        Public Property terimabarang_appuser_dt() As DateTime
            Get
                Return mTerimabarang_appuser_dt
            End Get
            Set(ByVal value As DateTime)
                mTerimabarang_appuser_dt = value
            End Set
        End Property

        Public Property terimabarang_appspv() As Byte
            Get
                Return mTerimabarang_appspv
            End Get
            Set(ByVal value As Byte)
                mTerimabarang_appspv = value
            End Set
        End Property

        Public Property terimabarang_appspv_by() As String
            Get
                Return mTerimabarang_appspv_by
            End Get
            Set(ByVal value As String)
                mTerimabarang_appspv_by = value
            End Set
        End Property

        Public Property terimabarang_appspv_dt() As DateTime
            Get
                Return mTerimabarang_appspv_dt
            End Get
            Set(ByVal value As DateTime)
                mTerimabarang_appspv_dt = value
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

        Public Property terimabarang_appacc_by() As String
            Get
                Return mTerimabarang_appacc_by
            End Get
            Set(ByVal value As String)
                mTerimabarang_appacc_by = value
            End Set
        End Property

        Public Property terimabarang_appacc_dt() As DateTime
            Get
                Return mTerimabarang_appacc_dt
            End Get
            Set(ByVal value As DateTime)
                mTerimabarang_appacc_dt = value
            End Set
        End Property

        Public Property terimabarang_foreign() As Decimal
            Get
                Return mTerimabarang_foreign
            End Get
            Set(ByVal value As Decimal)
                mTerimabarang_foreign = value
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

        Public Property terimabarang_foreignrate() As Decimal
            Get
                Return mTerimabarang_foreignrate
            End Get
            Set(ByVal value As Decimal)
                mTerimabarang_foreignrate = value
            End Set
        End Property

        Public Property terimabarang_idrreal() As Decimal
            Get
                Return mTerimabarang_idrreal
            End Get
            Set(ByVal value As Decimal)
                mTerimabarang_idrreal = value
            End Set
        End Property

        Public Property terimabarang_pph() As Decimal
            Get
                Return mTerimabarang_pph
            End Get
            Set(ByVal value As Decimal)
                mTerimabarang_pph = value
            End Set
        End Property

        Public Property terimabarang_ppn() As Decimal
            Get
                Return mTerimabarang_ppn
            End Get
            Set(ByVal value As Decimal)
                mTerimabarang_ppn = value
            End Set
        End Property

        Public Property terimabarang_disc() As Decimal
            Get
                Return mTerimabarang_disc
            End Get
            Set(ByVal value As Decimal)
                mTerimabarang_disc = value
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
    End Class
End Namespace