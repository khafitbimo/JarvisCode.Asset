
Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptJurnal_Header
        Private DSN As String
        Private mJurnal_id As String
        Private mJurnal_bookdate As DateTime
        Private mJurnal_descr As String
        Private mJurnal_createby As String
        Private mJurnal_createdate As DateTime
        Private mJurnal_modifyby As String
        Private mJurnal_modifydate As DateTime
        Private mJurnal_postby As String
        Private mJurnal_postdate As DateTime
        Private mJurnal_duedate As DateTime
        Private mJurnal_source As String
        Private mJurnaltype_id As String
        Private mChannel_id As String
        Private mRekanan_id As Decimal
        Private mRekanan_name As String
        Private mCurrency_id As String
        Private mCurrency_name As String
        Private mPeriode_id As String
        Private mPeriode_name As String
        Private mInvoice_descr As String
        Private mJurnal_amountIdr As Decimal
        Private mJurnal_amountForeign As Decimal
        Private mChannel_namereport As String
        Private mChannel_address As String

        Public Property jurnal_id() As String
            Get
                Return mJurnal_id
            End Get
            Set(ByVal value As String)
                mJurnal_id = value
            End Set
        End Property
        Public Property jurnal_bookdate() As DateTime
            Get
                Return mJurnal_bookdate
            End Get
            Set(ByVal value As DateTime)
                mJurnal_bookdate = value
            End Set
        End Property
        Public Property jurnal_descr() As String
            Get
                Return mJurnal_descr
            End Get
            Set(ByVal value As String)
                mJurnal_descr = value
            End Set
        End Property
        Public Property jurnal_createby() As String
            Get
                Return mJurnal_createby
            End Get
            Set(ByVal value As String)
                mJurnal_createby = value
            End Set
        End Property
        Public Property jurnal_createdate() As DateTime
            Get
                Return mJurnal_createdate
            End Get
            Set(ByVal value As DateTime)
                mJurnal_createdate = value
            End Set
        End Property
        Public Property jurnal_modifyby() As String
            Get
                Return mJurnal_modifyby
            End Get
            Set(ByVal value As String)
                mJurnal_modifyby = value
            End Set
        End Property
        Public Property jurnal_modifydate() As DateTime
            Get
                Return mJurnal_modifydate
            End Get
            Set(ByVal value As DateTime)
                mJurnal_modifydate = value
            End Set
        End Property
        Public Property jurnal_postby() As String
            Get
                Return mJurnal_postby
            End Get
            Set(ByVal value As String)
                mJurnal_postby = value
            End Set
        End Property
        Public Property jurnal_postdate() As DateTime
            Get
                Return mJurnal_postdate
            End Get
            Set(ByVal value As DateTime)
                mJurnal_postdate = value
            End Set
        End Property
        Public Property jurnal_duedate() As DateTime
            Get
                Return mJurnal_duedate
            End Get
            Set(ByVal value As DateTime)
                mJurnal_duedate = value
            End Set
        End Property
        Public Property jurnal_source() As String
            Get
                Return mJurnal_source
            End Get
            Set(ByVal value As String)
                mJurnal_source = value
            End Set
        End Property
        Public Property jurnaltype_id() As String
            Get
                Return mJurnaltype_id
            End Get
            Set(ByVal value As String)
                mJurnaltype_id = value
            End Set
        End Property
        Public Property channel_id() As String
            Get
                Return mChannel_id
            End Get
            Set(ByVal value As String)
                mChannel_id = value
                ' ''setChannelDesc()
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
        Public Property currency_id() As String
            Get
                Return mCurrency_id
            End Get
            Set(ByVal value As String)
                mCurrency_id = value
                ' ''Me.setCurrencyName()
            End Set
        End Property
        Public Property currency_name() As String
            Get
                Return mCurrency_name
            End Get
            Set(ByVal value As String)
                mCurrency_name = value
            End Set
        End Property
        Public Property periode_id() As String
            Get
                Return mPeriode_id
            End Get
            Set(ByVal value As String)
                mPeriode_id = value
                ' ''Me.setPeriodeName()
            End Set
        End Property
        Public Property periode_name() As String
            Get
                Return mPeriode_name
            End Get
            Set(ByVal value As String)
                mPeriode_name = value

            End Set
        End Property
        Public Property invoice_descr() As String
            Get
                Return mInvoice_descr
            End Get
            Set(ByVal value As String)
                mInvoice_descr = value
            End Set
        End Property
        Public Property jurnal_amountidr() As Decimal
            Get
                Return mJurnal_amountIdr
            End Get
            Set(ByVal value As Decimal)
                mJurnal_amountIdr = value
            End Set
        End Property
        Public Property jurnal_amountforeign() As Decimal
            Get
                Return mJurnal_amountForeign
            End Get
            Set(ByVal value As Decimal)
                mJurnal_amountForeign = value
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

        ' ''Public Sub New(ByVal DSN As String)
        ' ''    Me.DSN = DSN
        ' ''End Sub

        ''Private Sub setChannelDesc()
        ''    If mChannel_id <> "" Then
        ''        Dim tblChannel As DataTable
        ''        Dim parCriteria As OleDbParameter

        ''        Try
        ''            parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
        ''            parCriteria.Value = String.Format(" channel_id = '{0}' ", mChannel_id)
        ''            tblChannel = clsUtil.GetDataTable("ms_MstChannel_Select", Me.DSN, parCriteria)
        ''            If tblChannel.Rows.Count > 0 Then
        ''                Me.mChannel_namereport = Trim(tblChannel.Rows(0)("channel_namereport").ToString)
        ''                Me.mChannel_address = Trim(tblChannel.Rows(0)("channel_address").ToString)

        ''            End If

        ''        Catch ex As Exception
        ''            MsgBox("error on retrieving channel desc.")
        ''        Finally
        ''            parCriteria = Nothing
        ''            tblChannel = Nothing
        ''        End Try
        ''    End If
        ''End Sub

        ''Private Sub setPeriodeName()
        ''    If mPeriode_id <> "" Then
        ''        Dim tblPeriode As DataTable
        ''        Dim parCriteria As OleDbParameter

        ''        Try
        ''            parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
        ''            parCriteria.Value = String.Format(" periode_id = '{0}' ", mPeriode_id)
        ''            tblPeriode = clsUtil.GetDataTable("cp_MstPeriode_Select", Me.DSN, parCriteria)
        ''            If tblPeriode.Rows.Count > 0 Then
        ''                Me.mPeriode_name = Trim(tblPeriode.Rows(0)("periode_name").ToString)
        ''            End If

        ''        Catch ex As Exception
        ''            MsgBox("error on retrieving Periode")
        ''        Finally
        ''            parCriteria = Nothing
        ''            tblPeriode = Nothing
        ''        End Try
        ''    End If
        ''End Sub

        ''Private Sub setCurrencyName()
        ''    If mCurrency_id <> "" Then
        ''        Dim tblCurrency As DataTable
        ''        Dim parCriteria As OleDbParameter

        ''        Try
        ''            parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
        ''            parCriteria.Value = String.Format(" currency_id = '{0}' ", mCurrency_id)
        ''            tblCurrency = clsUtil.GetDataTable("ms_MstCurrency_Select", Me.DSN, parCriteria)
        ''            If tblCurrency.Rows.Count > 0 Then
        ''                Me.mCurrency_name = Trim(tblCurrency.Rows(0)("currency_shortname").ToString)
        ''            End If

        ''        Catch ex As Exception
        ''            MsgBox("error on retrieving Currency")
        ''        Finally
        ''            parCriteria = Nothing
        ''            tblCurrency = Nothing
        ''        End Try
        ''    End If
        ''End Sub
    End Class
End Namespace

