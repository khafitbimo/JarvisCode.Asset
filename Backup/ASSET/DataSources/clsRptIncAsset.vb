Imports System.Data.OleDb
Namespace DataSource
    Public Class clsRptIncAsset
        Private DSN As String
        Private top As Integer

        Private mChannel_id As String
        Private mChannel_namereport As String
        Private mChannel_address As String

        Private mStrukturunit_id As String
        Private mIncasset_id As String
        Private mOutasset_id As String
        Private mBookasset_id As String
        Private mIncasset_status As String
        Private mOutasset_startdt As DateTime
        Private mOutasset_enddt As DateTime
        Private mIncasset_actreturn As DateTime
        Private mOutasset_item As Int32
        Private mIncasset_returnitem As Int32
        Private mEmployee_id_returnby As String
        Private mStrukturunit_id_returnby As String
        Private mUsername_inputby As String
        Private mIncasset_inputdt As DateTime
        Private mInasset_remark As String
        Private mInasset_logistik As String
        Private mInasset_lock As Byte

        Private mStrukturunit_id_nameReport As String
        Private mStrukturunit_id_returnby_nameReport As String
        Private mEmployee_nameReport As String
        Private mlogistik_namereport As String
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

        Public Property strukturunit_id() As String
            Get
                Return mStrukturunit_id
            End Get
            Set(ByVal value As String)
                mStrukturunit_id = value
                setstrukturunit_id()
            End Set
        End Property

        Public Property incasset_id() As String
            Get
                Return mIncasset_id
            End Get
            Set(ByVal value As String)
                mIncasset_id = value
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
                Me.setbookasset_id()
            End Set
        End Property

        Public Property incasset_status() As String
            Get
                Return mIncasset_status
            End Get
            Set(ByVal value As String)
                mIncasset_status = value
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
        Public Property outasset_enddt() As DateTime
            Get
                Return mOutasset_enddt
            End Get
            Set(ByVal value As DateTime)
                mOutasset_enddt = value
            End Set
        End Property

        Public Property incasset_actreturn() As DateTime
            Get
                Return mIncasset_actreturn
            End Get
            Set(ByVal value As DateTime)
                mIncasset_actreturn = value
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

        Public Property incasset_returnitem() As Int32
            Get
                Return mIncasset_returnitem
            End Get
            Set(ByVal value As Int32)
                mIncasset_returnitem = value
            End Set
        End Property

        Public Property employee_id_returnby() As String
            Get
                Return mEmployee_id_returnby
            End Get
            Set(ByVal value As String)
                mEmployee_id_returnby = value
                setEmployee_id_customer()
            End Set
        End Property

        Public Property strukturunit_id_returnby() As String
            Get
                Return mStrukturunit_id_returnby
            End Get
            Set(ByVal value As String)
                mStrukturunit_id_returnby = value
                setstrukturunit_id_return()
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

        Public Property incasset_inputdt() As DateTime
            Get
                Return mIncasset_inputdt
            End Get
            Set(ByVal value As DateTime)
                mIncasset_inputdt = value
            End Set
        End Property

        Public Property inasset_remark() As String
            Get
                Return mInasset_remark
            End Get
            Set(ByVal value As String)
                mInasset_remark = value
            End Set
        End Property

        Public Property inasset_logistik() As String
            Get
                Return mInasset_logistik
            End Get
            Set(ByVal value As String)
                mInasset_logistik = value
                setLogistik_id_customer()
            End Set
        End Property

        Public Property inasset_lock() As Byte
            Get
                Return mInasset_lock
            End Get
            Set(ByVal value As Byte)
                mInasset_lock = value
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

        Public Property strukturunit_id_returnby_nameReport() As String
            Get
                Return mStrukturunit_id_returnby_nameReport
            End Get
            Set(ByVal value As String)
                mStrukturunit_id_nameReport = value
            End Set
        End Property
        Public Property Employee_nameReport() As String
            Get
                Return mEmployee_nameReport
            End Get
            Set(ByVal value As String)
                mEmployee_nameReport = value

            End Set
        End Property
        Public Property logistik_namereport() As String
            Get
                Return mlogistik_namereport
            End Get
            Set(ByVal value As String)
                mlogistik_namereport = value

            End Set
        End Property
        Private Sub setChannelDesc()
            If mChannel_id <> "" Then
                Dim tblIncAsset As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" channel_id = '{0}' ", mChannel_id)
                    tblIncAsset = clsUtil.GetDataTable("ms_MstChannel_Select", Me.DSN, parCriteria)
                    If tblIncAsset.Rows.Count > 0 Then
                        Me.mChannel_namereport = Trim(tblIncAsset.Rows(0)("channel_namereport").ToString)
                        Me.mChannel_address = Trim(tblIncAsset.Rows(0)("channel_address").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving channel desc.")
                Finally
                    parCriteria = Nothing
                    tblIncAsset = Nothing
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

        Private Sub setstrukturunit_id_return()

            If mStrukturunit_id_returnby > 0 Then
                Dim tblstrukturunit_id As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" strukturunit_id = {0} ", mStrukturunit_id_returnby)
                    tblstrukturunit_id = clsUtil.GetDataTable("as_MstStrukturUnit_Select", Me.DSN, parCriteria)
                    If tblstrukturunit_id.Rows.Count > 0 Then
                        Me.mStrukturunit_id_returnby_nameReport = Trim(tblstrukturunit_id.Rows(0)("strukturunit_name").ToString)

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
            If mEmployee_id_returnby <> "" Then
                Dim tblempoyee As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mEmployee_id_returnby)
                    tblempoyee = clsUtil.GetDataTable("ms_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblempoyee.Rows.Count > 0 Then
                        Me.mEmployee_nameReport = Trim(tblempoyee.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Master_Employee")
                Finally
                    parCriteria = Nothing
                    tblempoyee = Nothing
                End Try
            End If
        End Sub

        Private Sub setLogistik_id_customer()
            If mInasset_logistik <> "" Then
                Dim tblempoyee As DataTable
                Dim parCriteria As OleDbParameter

                Try
                    parCriteria = New OleDbParameter("@Criteria", OleDbType.VarChar, 1024)
                    parCriteria.Value = String.Format(" employee_id = '{0}' ", mInasset_logistik)
                    tblempoyee = clsUtil.GetDataTable("ms_MstEmployee_Select", Me.DSN, parCriteria)
                    If tblempoyee.Rows.Count > 0 Then
                        Me.mlogistik_namereport = Trim(tblempoyee.Rows(0)("employee_namalengkap").ToString)
                    End If

                Catch ex As Exception
                    MsgBox("error on retrieving Master_Employee")
                Finally
                    parCriteria = Nothing
                    tblempoyee = Nothing
                End Try
            End If
        End Sub

        Public Sub New(ByVal DSN As String, ByVal top As Integer)
            Me.DSN = DSN
            Me.top = top
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
            Else
                mBookasset_InputDt = CDate("10/05/2006 10:00")
            End If
        End Sub
    End Class
End Namespace