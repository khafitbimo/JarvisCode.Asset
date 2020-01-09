Public Class uiTrnRevaluasi
    Private tbl_MstChannel As DataTable = clsDataset.CreateTblMstChannel()

    Private listBarcode As String

#Region " Window Parameter "
    Private _CHANNEL As String = "TTV"
#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        objParameters = Me.GetParameterCollection(Me.Parameter)

        If Application.ProductName = _ProductName Then
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        End If

        Me.ComboFill(Me.obj_Channel_id, "channel_id", "channel_id", Me.tbl_MstChannel, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'")
        Me.tbl_MstChannel.DefaultView.Sort = "channel_id"

        Me.obj_Channel_id.SelectedValue = Me._CHANNEL

        Me.tbtnNew.Enabled = False
        Me.tbtnSave.Enabled = False
        Me.tbtnPrint.Enabled = False
        Me.tbtnPrintPreview.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = False
        Me.tbtnQuery.Enabled = False
        Me.tbtnRefresh.Enabled = False
        Me.tbtnFirst.Enabled = False
        Me.tbtnPrev.Enabled = False
        Me.tbtnNext.Enabled = False
        Me.tbtnLast.Enabled = False
    End Sub



    Private Sub uiTrnRevaluasi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If
    End Sub

    Private Sub cmdBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBarcode.Click
        Dim param As Integer = 3
        Dim strukturunit As Decimal = 0
        Dim dlg As New dlgListBarangNonFix(Me.DSN, _CHANNEL, param, strukturunit, Me.obj_Asset_barcode.Text)
        listBarcode = dlg.OpenDialog(Me)
        If listBarcode IsNot Nothing Then
            Me.obj_Asset_barcode.Text = listBarcode
            set_kurs()
        Else
            Me.obj_Asset_barcode.Text = ""
            Me.obj_Asset_Kurs.Text = ""
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            Dim dbCmdInsert As OleDb.OleDbCommand
            dbConn.Open()
            dbCmdInsert = New OleDb.OleDbCommand("as_revaluasi_insert", dbConn)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode").Value = Me.obj_Asset_barcode.Text
            dbCmdInsert.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id").Value = Me._CHANNEL
            dbCmdInsert.Parameters.Add("@devaluasi_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "devaluasi_dt").Value = Me.obj_Devaluasi_tgl.Text
            dbCmdInsert.Parameters.Add("@value_new", System.Data.OleDb.OleDbType.Decimal, 18, "value_new").Value = Me.obj_Asset_devaluasiValue.Text
            dbCmdInsert.Parameters.Add("@kurs", System.Data.OleDb.OleDbType.Decimal, 18, "kurs").Value = Me.obj_Asset_Kurs.Text
            dbCmdInsert.Parameters.Add("@value_newidr", System.Data.OleDb.OleDbType.Decimal, 18, "value_newidr").Value = Me.obj_Asset_idrprice.Text
            dbCmdInsert.Parameters.Add("@remark", System.Data.OleDb.OleDbType.VarWChar, 200, "remark").Value = Me.obj_Devaluasi_remark.Text
            dbCmdInsert.Parameters.Add("@input_by", System.Data.OleDb.OleDbType.VarWChar, 32, "input_by").Value = Me.UserName
            dbCmdInsert.Parameters.Add("@input_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "input_dt").Value = Now

            dbCmdInsert.ExecuteNonQuery()
            MsgBox("Data Save")
            dbCmdInsert.Dispose()

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
            Me.Panel1.Enabled = False
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub obj_Asset_devaluasiValue_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Asset_devaluasiValue.Validated
        Dim value As Decimal
        Try
            value = Me.obj_Asset_devaluasiValue.Text
            Me.obj_Asset_devaluasiValue.Text = Format(value, "#,##0.00")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub obj_Asset_Kurs_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Asset_Kurs.Validated
        Dim kurs As Decimal
        Try
            kurs = Me.obj_Asset_Kurs.Text
            Me.obj_Asset_Kurs.Text = Format(kurs, "#,##0.00")
        Catch ex As Exception
        End Try
    End Sub

    
    Private Sub obj_Asset_devaluasiValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles obj_Asset_devaluasiValue.Validating
        Dim value As Decimal
        Dim kurs As Decimal
        Try
            value = Me.obj_Asset_devaluasiValue.Text
            kurs = Me.obj_Asset_Kurs.Text
            Me.obj_Asset_devaluasiValue.Text = Format(value, "#,##0.00")
            Me.obj_Asset_idrprice.Text = Format(value * kurs, "#,##0.00")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub obj_Asset_Kurs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles obj_Asset_Kurs.Validating
        Dim value As Decimal
        Dim kurs As Decimal
        Try
            value = Me.obj_Asset_devaluasiValue.Text
            kurs = Me.obj_Asset_Kurs.Text
            Me.obj_Asset_Kurs.Text = Format(kurs, "#,##0.00")
            Me.obj_Asset_idrprice.Text = Format(value * kurs, "#,##0.00")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub set_kurs()
        Dim currency As Integer
        Dim currency_name As String = String.Empty

        Dim tbl_currency As New DataTable
        Dim tbl_currency_name As New DataTable
        Dim tbl_mst_exrate As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Dim criteria As String = String.Empty
        Dim criteria_name As String = String.Empty

        criteria = String.Format("asset_barcode = '{0}'", Me.obj_Asset_barcode.Text)

        'Try
        tbl_currency.Clear()
        DataFill(tbl_currency, "as_TrnTerimabarang_Select_ListNonFix", criteria, Me._CHANNEL)
        currency = clsUtil.IsDbNull(tbl_currency.Rows(0).Item("currency_id"), 0)


        tbl_currency.Clear()
        DataFill(tbl_currency_name, "ms_MstCurrency_Select", String.Format("currency_id = {0}", currency))
        currency_name = clsUtil.IsDbNull(tbl_currency_name.Rows(0).Item("currency_shortname"), 0)

        tbl_mst_exrate.Clear()
        DataFill(tbl_mst_exrate, "as_MstExRate_Select", String.Format("exrate_currency = '{0}'", currency_name))
        If tbl_mst_exrate.Rows.Count <= 0 Then
            MsgBox("Sorry, currency does not have in database")
            Me.obj_Asset_Kurs.Text = 0
        Else
            Me.obj_Asset_Kurs.Text = Format(tbl_mst_exrate.Rows(0)("exrate_buy"), "#,##0.00")
        End If
    End Sub
End Class


