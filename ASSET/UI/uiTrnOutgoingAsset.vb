Public Class uiTrnOutgoingAsset
    Private Const mUiName As String = "Outgoing"
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True

    Private Event FormBeforeOpenRow(ByRef id As Object)
    Private Event FormAfterOpenRow(ByRef id As Object)
    Private Event FormBeforeSave(ByRef id As Object)
    Private Event FormAfterSave(ByRef id As Object, ByVal result As FormSaveResult)
    Private Event FormBeforeNew()
    Private Event FormBeforeDelete(ByRef id As Object)
    Private Event FormAfterDelete(ByRef id As Object)

    Private FILTER_QUERY_MODE As Boolean
    Private DATA_ISLOCKED As Boolean

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider
    Private tbl_MstChannel As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstChannelSearch As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstEmployee As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_MstEmployeecustomer As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_MstEmployeecustomerhead As DataTable = clsDataset.CreateTblemployeePengguna()
    Private tbl_MstStrukturunitcustomer As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_MstStrukturunitOwner As DataTable = clsDataset.CreateTblStrukturunitPengguna()
    Private tbl_project As DataTable = clsDataset.CreateTblMstBudgetCombo
    Private tbl_schStrukturUnit As DataTable = clsDataset.CreateTblStrukturunitPemilik()

    Private tbl_TrnOutasset As DataTable = clsDataset.CreateTblTrnOutasset()
    Private tbl_TrnOutasset_Temp As DataTable = clsDataset.CreateTblTrnOutasset()
    Private tbl_TrnOutassetdetil As DataTable = clsDataset.CreateTblTrnOutassetdetil()
    Private tbl_TrnBookasset As DataTable = clsDataset.CreateTblTrnBookasset()
    Private tbl_TrnBookasset_Temp As DataTable = clsDataset.CreateTblTrnBookasset()
    Private tbl_TrnBookassetdetil As DataTable = clsDataset.CreateTblTrnBookassetdetil()

    Private tbl_MstUnitDgv As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_show As DataTable = clsDataset.CreateTblMstShow

    Private index As Byte
    Private booking_No As String
    Private status As String
    Private param As String
    Private outAsset_No As String
    Private employee As String

    Private tbl_Print As DataTable = clsDataset.CreateTblTrnOutasset
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnOutassetdetil
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptOutAsset
    Private objDatalistDetil As ArrayList

    Private qty As String
    Private str_Outasset_id As String
    Private line As Integer
    Private suaramenang As String

    Private retStrukturunit_id As String
    Private loadcombodata As Boolean

    Private tempChannel_ID As String
    Private tempChannel_nameReport As String
    Private tempChannel_address As String
    Private tempOutAssetID As String
    Private tempStrukturUnit As String

    Private isCheck As Boolean

    'Friend WithEvents btnlock As ToolStripButton = New ToolStripButton

#Region " Window Parameter "
    Private _STRUKTUR_UNIT As Decimal = 5554
    Private _STRUKTUR_UNIT_CANBE_CHANGED As Boolean = False
    Private _STRUKTUR_UNIT_CANBE_BROWSED As Boolean = False

    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    Private _SU_EMPLOYEE As String = "9002000"

    ' TODO: Buat variabel untuk menampung parameter window 

#End Region
#Region " Window Dataset "


#End Region
#Region " Overrides "

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible
        If Me.PnlDfSearch.Visible Then
            FILTER_QUERY_MODE = True
            Me.tbtnQuery.CheckState = CheckState.Checked
        Else
            FILTER_QUERY_MODE = False
            Me.tbtnQuery.CheckState = CheckState.Unchecked
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnNew_Click() As Boolean
        Dim newdata As NewData = New NewData(Me.DSN)
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim components As Control

        newdata.ShowInTaskbar = False
        newdata.StartPosition = FormStartPosition.CenterParent
        newdata.ShowDialog(Me)


        If newdata.DialogResult = DialogResult.OK Then
            If newdata.obj_automatic.Checked = True And newdata.obj_oto.Text <> "" Then

                newdata.Hide()
                booking_No = newdata.obj_oto.Text
                Me.cek_data(booking_No)

                If Me.ftabMain.SelectedIndex = 0 Then
                    Me.ftabMain.SelectedIndex = 1
                    Me.uiTrnOutgoingAsset_NewData()
                    Me.DgvTrnOutassetdetil.DataSource = Me.tbl_TrnBookassetdetil
                    If param = "1" Then
                        obj_Bookasset_id.Text = booking_No
                        obj_Outasset_id.Text = outAsset_No

                        Try
                            dbConn.Open()
                            If Me.obj_Project_id.SelectedValue Is Nothing Then
                                Me.Obj_Asset_No_Project.Text = 0
                            Else
                                Me.Obj_Asset_No_Project.Text = clsUtil.IsDbNull(Me.obj_Project_id.SelectedValue, 0)
                            End If
                            Me.uiTrnOutgoingAsset_OpenRowMaster(_CHANNEL, outAsset_No, dbConn)

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, mUiName & ": uiTrnOutgoingAsset_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            dbConn.Close()
                        End Try

                    End If

                Else
                    Me.uiTrnOutgoingAsset_NewData()
                    Me.Obj_Asset_No_Project.Text = 0
                    'obj_Outasset_id.Text = booking.DgvRequest.Rows(index).Cells("outasset_id").Value
                    Me.DgvTrnOutassetdetil.DataSource = Me.tbl_TrnBookassetdetil


                End If
            Else

                If Me.ftabMain.SelectedIndex = 0 Then
                    Me.ftabMain.SelectedIndex = 1
                End If
                Me.uiTrnOutgoingAsset_NewData()
                Me.Obj_Asset_No_Project.Text = 0


            End If
        Else
            Exit Function


        End If

        Me.Panel2.Enabled = True
        Me.PnlDataMaster.Enabled = True
        For Each components In Panel2.Controls
            If components.Name <> "obj_remark" And components.Name <> "TextBox1" Then
                components.Enabled = True
            End If
        Next

        Return MyBase.btnNew_Click()

    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnOutgoingAsset_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        Me.objFormError.Clear()
        If Me.uiTrnOutgoingAsset_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnOutgoingAsset_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function


    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnOutgoingAsset_Print()

        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnOutgoingAsset_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnOutgoingAsset_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnOutgoingAsset_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnOutgoingAsset_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnOutgoingAsset_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnOutgoingAsset_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region
#Region " Additional Overrides "
    'Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlock.Click
    '    LockData()
    'End Sub


#End Region
#Region " Layout & Init UI "

    Private Function FormatDgvTrnOutasset(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnOutasset Columns 
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_startdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_enddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_starttm As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_endtm As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_customer As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_customer As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_customerhead As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_item As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cProject_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_epsnumber_st As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cShow_epsnumber_ed As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_lock As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim coutasset_delay As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim coutasset_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_purpose As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 80
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "Struktur Unit"
        cStrukturunit_id.DataPropertyName = "strukturunit_id_string"
        cStrukturunit_id.Width = 130
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cEmployee_id_customer.Name = "employee_id_customer"
        cEmployee_id_customer.HeaderText = "Customer"
        cEmployee_id_customer.DataPropertyName = "employee_id_customer_string"
        cEmployee_id_customer.Width = 130
        cEmployee_id_customer.Visible = True
        cEmployee_id_customer.ReadOnly = False

        cStrukturunit_id_customer.Name = "strukturunit_id_customer"
        cStrukturunit_id_customer.HeaderText = "Struktur Unit"
        cStrukturunit_id_customer.DataPropertyName = "strukturunit_id_customer_string"
        cStrukturunit_id_customer.Width = 130
        cStrukturunit_id_customer.Visible = True
        cStrukturunit_id_customer.ReadOnly = False

        cOutasset_id.Name = "outasset_id"
        cOutasset_id.HeaderText = "No. Outgoing"
        cOutasset_id.DataPropertyName = "outasset_id"
        cOutasset_id.Width = 105
        cOutasset_id.Visible = True
        cOutasset_id.ReadOnly = False

        cBookasset_id.Name = "bookasset_id"
        cBookasset_id.HeaderText = "No. Book"
        cBookasset_id.DataPropertyName = "bookasset_id"
        cBookasset_id.Width = 105
        cBookasset_id.Visible = True
        cBookasset_id.ReadOnly = False

        cOutasset_startdt.Name = "outasset_startdt"
        cOutasset_startdt.HeaderText = "Start Date"
        cOutasset_startdt.DataPropertyName = "outasset_startdt"
        'cOutasset_startdt.DefaultCellStyle.Format = "dd-MMM-yy"
        cOutasset_startdt.Width = 100
        cOutasset_startdt.Visible = True
        cOutasset_startdt.ReadOnly = False

        cOutasset_enddt.Name = "outasset_enddt"
        cOutasset_enddt.HeaderText = "End Date"
        cOutasset_enddt.DataPropertyName = "outasset_enddt"
        'cOutasset_enddt.DefaultCellStyle.Format = "dd-MMM-yy"
        cOutasset_enddt.Width = 100
        cOutasset_enddt.Visible = True
        cOutasset_enddt.ReadOnly = False

        cOutasset_starttm.Name = "outasset_starttm"
        cOutasset_starttm.HeaderText = "Start"
        cOutasset_starttm.DataPropertyName = "outasset_starttm"
        cOutasset_starttm.Width = 100
        cOutasset_starttm.Visible = True
        cOutasset_starttm.ReadOnly = False

        cOutasset_endtm.Name = "outasset_endtm"
        cOutasset_endtm.HeaderText = "End"
        cOutasset_endtm.DataPropertyName = "outasset_endtm"
        cOutasset_endtm.Width = 100
        cOutasset_endtm.Visible = True
        cOutasset_endtm.ReadOnly = False

        cEmployee_id_customer.Name = "employee_id_customer"
        cEmployee_id_customer.HeaderText = "Customer"
        cEmployee_id_customer.DataPropertyName = "employee_id_customer_string"
        cEmployee_id_customer.Width = 135
        cEmployee_id_customer.Visible = True
        cEmployee_id_customer.ReadOnly = False

        cOutasset_item.Name = "outasset_item"
        cOutasset_item.HeaderText = "Item"
        cOutasset_item.DataPropertyName = "outasset_item"
        cOutasset_item.Width = 100
        cOutasset_item.Visible = True
        cOutasset_item.ReadOnly = False

        cProject_id.Name = "project_id_string"
        cProject_id.HeaderText = "Project"
        cProject_id.DataPropertyName = "project_id_string"
        cProject_id.Width = 150
        cProject_id.Visible = True
        cProject_id.ReadOnly = False

        cShow_id.Name = "Show_id"
        cShow_id.HeaderText = "Show"
        cShow_id.DataPropertyName = "Show_id_string"
        cShow_id.Width = 150
        cShow_id.Visible = True
        cShow_id.ReadOnly = False

        cShow_epsnumber_st.Name = "show_epsnumber_st"
        cShow_epsnumber_st.HeaderText = "Eps Start"
        cShow_epsnumber_st.DataPropertyName = "show_epsnumber_st"
        cShow_epsnumber_st.Width = 100
        cShow_epsnumber_st.Visible = True
        cShow_epsnumber_st.ReadOnly = False

        cShow_epsnumber_ed.Name = "show_epsnumber_ed"
        cShow_epsnumber_ed.HeaderText = "Eps End"
        cShow_epsnumber_ed.DataPropertyName = "show_epsnumber_ed"
        cShow_epsnumber_ed.Width = 100
        cShow_epsnumber_ed.Visible = True
        cShow_epsnumber_ed.ReadOnly = False

        cOutasset_lock.Name = "outasset_lock"
        cOutasset_lock.HeaderText = "C"
        cOutasset_lock.DataPropertyName = "outasset_lock"
        cOutasset_lock.Width = 35
        cOutasset_lock.Visible = True
        cOutasset_lock.ReadOnly = False

        coutasset_delay.Name = "outasset_delay"
        coutasset_delay.HeaderText = "Delay/Hour"
        coutasset_delay.DataPropertyName = "outasset_delay"
        coutasset_delay.Width = 100
        coutasset_delay.Visible = True
        coutasset_delay.ReadOnly = False

        coutasset_status.Name = "outasset_status"
        coutasset_status.HeaderText = "Status"
        coutasset_status.DataPropertyName = "outasset_status"
        coutasset_status.Width = 100
        coutasset_status.Visible = True
        coutasset_status.ReadOnly = False

        cOutasset_purpose.Name = "outasset_purpose"
        cOutasset_purpose.HeaderText = "Purpose"
        cOutasset_purpose.DataPropertyName = "outasset_purpose"
        cOutasset_purpose.Width = 100
        cOutasset_purpose.Visible = True
        cOutasset_purpose.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cOutasset_lock, cOutasset_id, cBookasset_id, cOutasset_startdt, _
        cOutasset_starttm, cOutasset_enddt, cOutasset_endtm, _
        cEmployee_id_customer, cOutasset_item, cProject_id, cShow_id, _
        cShow_epsnumber_st, cShow_epsnumber_ed, coutasset_delay, _
        coutasset_status, cChannel_id, cStrukturunit_id, cOutasset_purpose})

        ' DgvTrnOutasset Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        objDgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        objDgv.AllowUserToResizeRows = False
        objDgv.AutoGenerateColumns = False
    End Function

    Private Function FormatDgvTrnOutassetdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnOutassetdetil
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBarcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cQty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cNama As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategori As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTipe As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIs_useable As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Dim cincasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim coutasset_return As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cinasset_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn


        cincasset_id.Name = "incasset_id"
        cincasset_id.HeaderText = "incasset_id"
        cincasset_id.DataPropertyName = "incasset_id"
        cincasset_id.Width = 100
        cincasset_id.Visible = False
        cincasset_id.ReadOnly = False

        coutasset_return.Name = "outasset_return"
        coutasset_return.HeaderText = "outasset_return"
        coutasset_return.DataPropertyName = "outasset_return"
        coutasset_return.Width = 100
        coutasset_return.Visible = False
        coutasset_return.ReadOnly = False

        cinasset_status.Name = "inasset_status"
        cinasset_status.HeaderText = "inasset_status"
        cinasset_status.DataPropertyName = "inasset_status"
        cinasset_status.Width = 100
        cinasset_status.Visible = False
        cinasset_status.ReadOnly = False

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "channel_id"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cOutasset_id.Name = "outasset_id"
        cOutasset_id.HeaderText = "outasset_id"
        cOutasset_id.DataPropertyName = "outasset_id"
        cOutasset_id.Width = 100
        cOutasset_id.Visible = False
        cOutasset_id.ReadOnly = False

        cOutasset_line.Name = "outasset_line"
        cOutasset_line.HeaderText = "Line"
        cOutasset_line.DataPropertyName = "outasset_line"
        cOutasset_line.Width = 50
        cOutasset_line.Visible = True
        'cOutasset_line.ReadOnly = False

        cBarcode.Name = "barcode"
        cBarcode.HeaderText = "Barcode"
        cBarcode.DataPropertyName = "barcode"
        cBarcode.Width = 100
        cBarcode.Visible = True
        'cBarcode.ReadOnly = False

        cNama.Name = "asset_deskripsi"
        cNama.HeaderText = "Description"
        cNama.DataPropertyName = "asset_deskripsi"
        cNama.Width = 100
        cNama.Visible = True
        'cBarcode.ReadOnly = False


        'cNama.ValueMember = "asset_barcode"
        'cNama.DisplayMember = "asset_deskripsi"
        'cNama.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        'cNama.DisplayStyleForCurrentCellOnly = True
        'cNama.AutoComplete = True
        'cNama.DataSource = Me.tbl_mstasset

        cSn.Name = "asset_serial"
        cSn.HeaderText = "SN"
        cSn.DataPropertyName = "asset_serial"
        cSn.Width = 100
        cSn.Visible = True

        cKategori.Name = "kategoriitem_id"
        cKategori.HeaderText = "Category"
        cKategori.DataPropertyName = "kategoriitem_id"
        cKategori.Width = 150
        cKategori.Visible = True

        cTipe.Name = "tipeitem_id"
        cTipe.HeaderText = "Type"
        cTipe.DataPropertyName = "tipeitem_id"
        cTipe.Width = 200
        cTipe.Visible = True

        cQty.Name = "qty"
        cQty.HeaderText = "Qty"
        cQty.DataPropertyName = "qty"
        cQty.Width = 50
        cQty.Visible = True
        'cQty.ReadOnly = False

        cIs_useable.Name = "is_useable"
        cIs_useable.HeaderText = "is_useable"
        cIs_useable.DataPropertyName = "is_useable"
        cIs_useable.Width = 100
        cIs_useable.Visible = False
        cIs_useable.ReadOnly = False

        cBookasset_id.Name = "bookasset_id"
        cBookasset_id.HeaderText = "bookasset_id"
        cBookasset_id.DataPropertyName = "bookasset_id"
        cBookasset_id.Width = 100
        cBookasset_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBookasset_id.Visible = False
        cBookasset_id.ReadOnly = False

        cBookasset_status.Name = "bookasset_status"
        cBookasset_status.HeaderText = "bookasset_status"
        cBookasset_status.DataPropertyName = "bookasset_status"
        cBookasset_status.Width = 100
        cBookasset_status.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBookasset_status.Visible = False
        cBookasset_status.ReadOnly = False



        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cChannel_id, cOutasset_id, cBarcode, cSn, cNama, _
        cKategori, cTipe, cQty, cIs_useable, cincasset_id, coutasset_return, _
        cinasset_status, cBookasset_id, cBookasset_status, cOutasset_line})

        DgvTrnOutassetdetil.ReadOnly = True
        objDgv.AutoGenerateColumns = False

    End Function

    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvTrnOutasset.Dock = DockStyle.Fill

        Me.FormatDgvTrnOutasset(Me.DgvTrnOutasset)
        Me.FormatDgvTrnOutassetdetil(Me.DgvTrnOutassetdetil)

    End Function

    Private Function BindingStop() As Boolean
        'stop binding

        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Strukturunit_id.DataBindings.Clear()
        Me.obj_Outasset_id.DataBindings.Clear()
        Me.obj_Bookasset_id.DataBindings.Clear()
        Me.obj_Outasset_startdt.DataBindings.Clear()
        Me.obj_Outasset_enddt.DataBindings.Clear()
        Me.obj_Outasset_starttm.DataBindings.Clear()
        Me.obj_Outasset_endtm.DataBindings.Clear()
        Me.obj_Employee_id_customer.DataBindings.Clear()
        Me.obj_Logistic.DataBindings.Clear()
        Me.obj_Strukturunit_id_customer.DataBindings.Clear()
        Me.obj_Employee_id_customerhead.DataBindings.Clear()
        Me.obj_Outasset_item.DataBindings.Clear()
        Me.obj_Project_id.DataBindings.Clear()
        Me.obj_Show_id.DataBindings.Clear()
        Me.obj_Show_epsnumber_st.DataBindings.Clear()
        Me.obj_Show_epsnumber_ed.DataBindings.Clear()
        Me.Obj_Outasset_status.DataBindings.Clear()
        Me.obj_remark.DataBindings.Clear()
        Me.obj_outAsset_lock.DataBindings.Clear()
        Me.obj_Inputby.DataBindings.Clear()
        Me.obj_Inputdt.DataBindings.Clear()
        Me.obj_Editby.DataBindings.Clear()
        Me.obj_Editdt.DataBindings.Clear()
        Me.obj_Usedby.DataBindings.Clear()
        Me.obj_Useddt.DataBindings.Clear()
        Me.obj_outAsset_purpose.DataBindings.Clear()


        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Channel_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOutasset_Temp, "channel_id"))
        Me.obj_Strukturunit_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOutasset_Temp, "strukturunit_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Outasset_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_id"))
        Me.obj_Bookasset_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "bookasset_id"))
        Me.obj_Outasset_startdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_startdt", True, DataSourceUpdateMode.OnPropertyChanged, "MM/dd/yyyy"))
        Me.obj_Outasset_enddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_enddt", True, DataSourceUpdateMode.OnPropertyChanged, "MM/dd/yyyy"))
        Me.obj_Outasset_starttm.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_starttm"))
        Me.obj_Outasset_endtm.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_endtm"))

        Me.obj_Employee_id_customer.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOutasset_Temp, "employee_id_customer"))
        Me.obj_Logistic.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOutasset_Temp, "outasset_logistik"))
        Me.obj_Strukturunit_id_customer.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOutasset_Temp, "strukturunit_id_customer"))

        'Me.obj_Strukturunit_id_customer.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOutasset_Temp, "strukturunit_id_customer", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Employee_id_customerhead.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOutasset_Temp, "employee_id_customerhead"))
        Me.obj_Outasset_item.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_item"))
        Me.obj_Project_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnOutasset_Temp, "project_id", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Show_id.DataBindings.Add(New Binding("selectedValue", Me.tbl_TrnOutasset_Temp, "show_id"))
        Me.obj_Show_epsnumber_st.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "show_epsnumber_st"))
        Me.obj_Show_epsnumber_ed.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "show_epsnumber_ed"))
        ' Me.obj_Outasset_lock.DataBindings.Add(New Binding("Checked", Me.tbl_TrnOutasset, "outasset_lock"))
        Me.obj_outAsset_lock.DataBindings.Add(New Binding("Checked", Me.tbl_TrnOutasset, "outasset_lock"))
        Me.Obj_Outasset_status.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset, "outasset_status"))
        Me.obj_remark.DataBindings.Add(New Binding("text", Me.tbl_TrnOutasset_Temp, "outasset_remark"))

        Me.obj_Inputby.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_inputby"))
        Me.obj_Inputdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_inputdt"))
        Me.obj_Editby.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_editby"))
        Me.obj_Editdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_editdt"))
        Me.obj_Usedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_usedby"))
        Me.obj_Useddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_useddt"))
        Me.obj_outAsset_purpose.DataBindings.Add(New Binding("Text", Me.tbl_TrnOutasset_Temp, "outasset_purpose"))

        Return True
    End Function

#End Region
#Region " Dialoged Control "
#End Region
#Region " User Defined Function "

    Private Function uiTrnOutgoingAsset_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnOutasset_Temp
        Me.tbl_TrnOutasset_Temp.Clear()
        Me.tbl_TrnOutasset_Temp.Columns("channel_id").DefaultValue = _CHANNEL
        Me.tbl_TrnOutasset_Temp.Columns("strukturunit_id").DefaultValue = _STRUKTUR_UNIT
        Me.tbl_TrnOutasset_Temp.Columns("outasset_id").DefaultValue = "AUTO"
        Me.tbl_TrnOutasset_Temp.Columns("bookasset_id").DefaultValue = ""
        Me.tbl_TrnOutasset_Temp.Columns("outasset_startdt").DefaultValue = Now
        Me.tbl_TrnOutasset_Temp.Columns("outasset_enddt").DefaultValue = Now
        Me.tbl_TrnOutasset_Temp.Columns("outasset_starttm").DefaultValue = "00:00"
        Me.tbl_TrnOutasset_Temp.Columns("outasset_endtm").DefaultValue = "01:00"
        Me.tbl_TrnOutasset_Temp.Columns("employee_id_customer").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("strukturunit_id_customer").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("employee_id_customerhead").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("outasset_item").DefaultValue = 0
        Me.tbl_TrnOutasset_Temp.Columns("project_id").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("show_id").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("show_epsnumber_st").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("show_epsnumber_ed").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("outasset_remark").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("outasset_logistik").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("outasset_status").DefaultValue = "OUTGOING"
        Me.tbl_TrnOutasset_Temp.Columns("outasset_inputby").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("outasset_inputdt").DefaultValue = Now
        Me.tbl_TrnOutasset_Temp.Columns("outasset_editby").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("outasset_editdt").DefaultValue = Now
        Me.tbl_TrnOutasset_Temp.Columns("outasset_usedby").DefaultValue = DBNull.Value
        Me.tbl_TrnOutasset_Temp.Columns("outasset_useddt").DefaultValue = Now


        ' TODO: Set Default Value for tbl_TrnOutassetdetil
        Me.tbl_TrnOutassetdetil.Clear()
        Me.tbl_TrnOutassetdetil = clsDataset.CreateTblTrnOutassetdetil()
        Me.tbl_TrnOutassetdetil.Columns("outasset_id").DefaultValue = 0
        Me.tbl_TrnOutassetdetil.Columns("outasset_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOutassetdetil.Columns("outasset_line").AutoIncrement = True
        Me.tbl_TrnOutassetdetil.Columns("outasset_line").AutoIncrementSeed = 1
        Me.tbl_TrnOutassetdetil.Columns("outasset_line").AutoIncrementStep = 1
        Me.DgvTrnOutassetdetil.DataSource = Me.tbl_TrnOutassetdetil


        Me.BindingContext(Me.tbl_TrnOutasset_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnOutasset_Temp).AddNew()
            'Me.obj_outAsset_lock.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function uiTrnOutgoingAsset_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""


        ' TODO: Parse Criteria using clsProc.RefParser()
        If chkSearchStrukturUnit_id.Checked = True Then
            criteria = criteria & " and strukturunit_id = " & CStr(cboSearchStrukturunit_id.SelectedValue)
        End If

        If Me.chkStatus.Checked = True Then
            If Me.cboStatus.SelectedItem = "OUTGOING" Then
                criteria &= " AND outasset_status = 'OUTGOING'"
            ElseIf Me.cboStatus.SelectedItem = "INCOMPLETE" Then
                criteria &= " AND outasset_status = 'INCOMPLETE'"
            ElseIf Me.cboStatus.SelectedItem = "COMPLETE" Then
                criteria &= " AND outasset_status = 'COMPLETE'"
            Else
                MsgBox("Please choice item in status box")
                Exit Function
            End If
        End If

        Me.tbl_TrnOutasset.Clear()
        Try
            Me.DataFill(Me.tbl_TrnOutasset, "as_TrnOutasset_Select", criteria, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiTrnOutgoingAsset_Save() As Boolean
        'save data
        Dim tbl_TrnOutasset_Temp_Changes As DataTable
        Dim tbl_TrnOutassetdetil_Changes As DataTable
        Dim success As Boolean
        Dim outasset_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(outasset_id)

        Me.BindingContext(Me.tbl_TrnOutasset_Temp).EndCurrentEdit()
        tbl_TrnOutasset_Temp_Changes = Me.tbl_TrnOutasset_Temp.GetChanges()

        Me.DgvTrnOutassetdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnOutassetdetil).EndCurrentEdit()
        tbl_TrnOutassetdetil_Changes = Me.tbl_TrnOutassetdetil.GetChanges()

        If tbl_TrnOutasset_Temp_Changes IsNot Nothing Or tbl_TrnOutassetdetil_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnOutasset_Temp.Rows(0).RowState
                outasset_id = tbl_TrnOutasset_Temp.Rows(0).Item("outasset_id")

                If tbl_TrnOutasset_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnOutgoingAsset_SaveMaster(outasset_id, tbl_TrnOutasset_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnOutgoingAsset_SaveMaster(tbl_TrnOutasset_Temp_Changes)")
                    Me.tbl_TrnOutasset_Temp.AcceptChanges()
                End If

                If tbl_TrnOutassetdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnOutassetdetil.Rows.Count - 1
                        If Me.tbl_TrnOutassetdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnOutassetdetil.Rows(i).Item("outasset_id") = outasset_id
                        End If
                    Next
                    success = Me.uiTrnOutgoingAsset_SaveDetil(outasset_id, tbl_TrnOutassetdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnOutgoingAsset_SaveDetil(tbl_TrnOutassetdetil_Changes)")
                    Me.tbl_TrnOutassetdetil.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                result = FormSaveResult.SaveError
                MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        RaiseEvent FormAfterSave(outasset_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnOutgoingAsset_SaveMaster(ByRef outasset_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: transaksi_outasset
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnOutasset_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "outasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "bookasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_startdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "outasset_startdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "outasset_enddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_starttm", System.Data.OleDb.OleDbType.VarWChar, 10, "outasset_starttm"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_endtm", System.Data.OleDb.OleDbType.VarWChar, 10, "outasset_endtm"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_customer", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_customer"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_customer", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id_customer", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_customerhead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_customerhead"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_item", System.Data.OleDb.OleDbType.Integer, 4, "outasset_item"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "project_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_st", System.Data.OleDb.OleDbType.VarWChar, 10, "show_epsnumber_st"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_ed", System.Data.OleDb.OleDbType.VarWChar, 10, "show_epsnumber_ed"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_remark", System.Data.OleDb.OleDbType.VarWChar, 150, "outasset_remark"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_logistik", System.Data.OleDb.OleDbType.VarWChar, 15, "outasset_logistik"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_inputby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_editby", System.Data.OleDb.OleDbType.VarWChar, 32, "outasset_editby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "outasset_editdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_usedby", System.Data.OleDb.OleDbType.VarWChar, 32, "outasset_usedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "outasset_useddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_purpose", System.Data.OleDb.OleDbType.VarWChar, 200, "outasset_purpose"))

        dbCmdInsert.Parameters("@outasset_inputby").Value = Me.UserName
        dbCmdInsert.Parameters("@outasset_inputdt").Value = Now



        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_lock", System.Data.OleDb.OleDbType.Boolean, 1, "outasset_lock"))


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnOutasset_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "outasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "bookasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_startdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "outasset_startdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "outasset_enddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_starttm", System.Data.OleDb.OleDbType.VarWChar, 10, "outasset_starttm"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_endtm", System.Data.OleDb.OleDbType.VarWChar, 10, "outasset_endtm"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_customer", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_customer"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_customer", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id_customer", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_customerhead", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_customerhead"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_item", System.Data.OleDb.OleDbType.Integer, 4, "outasset_item"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "project_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_st", System.Data.OleDb.OleDbType.VarWChar, 10, "show_epsnumber_st"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_ed", System.Data.OleDb.OleDbType.VarWChar, 10, "show_epsnumber_ed"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_remark", System.Data.OleDb.OleDbType.VarWChar, 150, "outasset_remark"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_logistik", System.Data.OleDb.OleDbType.VarWChar, 15, "outasset_logistik"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_inputby", System.Data.OleDb.OleDbType.VarWChar, 32, "outasset_inputby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "outasset_inputdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_editby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_usedby", System.Data.OleDb.OleDbType.VarWChar, 32, "outasset_usedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "outasset_useddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_purpose", System.Data.OleDb.OleDbType.VarWChar, 200, "outasset_purpose"))

        dbCmdUpdate.Parameters("@outasset_editby").Value = Me.UserName
        dbCmdUpdate.Parameters("@outasset_editdt").Value = Now


        'dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_lock", System.Data.OleDb.OleDbType.Boolean, 1, "outasset_lock"))


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            outasset_id = objTbl.Rows(0).Item("outasset_id")
            Me.tbl_TrnOutasset_Temp.Clear()
            Me.tbl_TrnOutasset_Temp.Merge(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try


        If MasterDataState = DataRowState.Added Then
            Me.tbl_TrnOutasset.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnOutasset).Position
            Me.tbl_TrnOutasset.Rows.RemoveAt(curpos)
            Me.tbl_TrnOutasset.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnOutasset).Position = Me.BindingContext(Me.tbl_TrnOutasset).Count

        Return True
    End Function

    Private Function uiTrnOutgoingAsset_SaveDetil(ByRef outasset_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        'Save(Data) : transaksi_outassetdetil()
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnOutassetdetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_line", System.Data.OleDb.OleDbType.Integer, 4, "outasset_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "barcode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Integer, 4, "is_useable"))
        dbCmdInsert.Parameters("@outasset_id").Value = outasset_id


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnOutassetdetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_line", System.Data.OleDb.OleDbType.Integer, 4, "outasset_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "barcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Integer, 4, "is_useable"))
        dbCmdUpdate.Parameters("@outasset_id").Value = outasset_id


        dbCmdDelete = New OleDb.OleDbCommand("as_TrnOutassetdetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_line", System.Data.OleDb.OleDbType.Integer, 4, "outasset_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "barcode"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Integer, 4, "is_useable"))
        dbCmdDelete.Parameters("@outasset_id").Value = outasset_id


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try

        Return True
    End Function

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()

        tbl_Print.Clear()
        tbl_PrintDetil.Clear()
        objPrintHeader = New DataSource.clsRptOutAsset(Me.DSN, Me.NumericUpDown1.Value)
        DataFill(tbl_Print, "as_TrnOutasset_Select", "and outasset_id = '" & DgvTrnOutasset.Item("outasset_id", DgvTrnOutasset.SelectedCells.Item(0).RowIndex).Value & "'", _CHANNEL, Me.NumericUpDown1.Value)
        With objPrintHeader
            .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id"), String.Empty)
            .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), 0)
            .outasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_id"), String.Empty)
            .bookasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_id"), String.Empty)
            .outasset_startdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_startdt"), String.Empty)
            .outasset_enddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_enddt"), String.Empty)
            .outasset_starttm = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_starttm"), String.Empty)
            .outasset_endtm = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_endtm"), String.Empty)
            .employee_id_customer = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_customer"), String.Empty)
            .strukturunit_id_customer = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_customer"), 0)
            .employee_id_customerhead = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_customerhead"), String.Empty)
            .outasset_item = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_item"), String.Empty)
            .project_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("project_id"), 0)
            .show_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_id"), String.Empty)
            .show_epsnumber_st = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_epsnumber_st"), String.Empty)
            .show_epsnumber_ed = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("show_epsnumber_ed"), String.Empty)
            .outasset_lock = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_lock"), 0)
            .outasset_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_status"), String.Empty)
            .outasset_remark = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_remark"), String.Empty)
            .employee = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_logistik"), String.Empty)
            .outasset_purpose = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_purpose"), String.Empty)

            .outasset_inputdt = clsUtil.IsDbNull(Format(Me.tbl_Print.Rows(0).Item("outasset_inputdt"), "dd/MM/yyyy"), String.Empty)
            .outasset_inputtm = clsUtil.IsDbNull(Format(Me.tbl_Print.Rows(0).Item("outasset_inputdt"), "HH:mm"), String.Empty)

            Me.tempChannel_ID = .channel_id
            Me.tempChannel_nameReport = .channel_namereport
            Me.tempChannel_address = .channel_address
            Me.tempOutAssetID = .outasset_id
            Me.tempStrukturUnit = .Strukturunit_id_nameReport

            DataFill(tbl_PrintDetil, "as_TrnOutassetdetil_Select", "outasset_id = '" & .outasset_id & "'")
            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptOutAssetDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptOutAssetDetil(Me.DSN)
            With objDetil
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id"), String.Empty)
                .outasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("outasset_id"), String.Empty)
                .outasset_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("outasset_line"), 0)
                .barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("barcode"), String.Empty)
                .qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("qty"), 0)
                .is_useable = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("is_useable"), 0)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptOutAssetDetil", objDatalistDetil))
    End Sub

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)


        Dim deviceInfo As String = _
        "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>8.27in</PageWidth>" & _
        "  <PageHeight>11.69in</PageHeight>" & _
        "  <MarginTop>0.4in</MarginTop>" & _
        "  <MarginLeft>0.4in</MarginLeft>" & _
        "  <MarginRight>0.4in</MarginRight>" & _
        "  <MarginBottom>0.4in</MarginBottom>" & _
        "</DeviceInfo>"
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        m_streams = New List(Of System.IO.Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        Dim stream As System.IO.Stream
        For Each stream In m_streams
            stream.Position = 0
        Next
    End Sub

    Private Function CreateStream _
    (ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As System.Text.Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) _
    As System.IO.Stream
        Dim stream As System.IO.Stream = New System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory & "Temp\" & name & "." & fileNameExtension, System.IO.FileMode.Create)

        m_streams.Add(stream)

        Return stream
    End Function

    Private Sub PrintPage(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
        Dim pageImage As New System.Drawing.Imaging.Metafile(m_streams(m_currentPageIndex))

        ev.Graphics.DrawImage(pageImage, ev.PageBounds)
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Sub Print()
        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        Dim printSet As New System.Drawing.Printing.PrinterSettings
        'Dim printerName As String = printSet.PrinterName
        Const printerName As String = "Microsoft Office Document Image Writer"

        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If
        printDoc.PrinterSettings.PrinterName = printerName
        If Not printDoc.PrinterSettings.IsValid Then
            Dim msg As String = String.Format("Can't find printer ""{0}"".", printerName)
            Console.WriteLine(msg)
            Return
        End If
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()
    End Sub

    Private Function uiTrnOutgoingAsset_Print() As Boolean
        If Me.DgvTrnOutasset.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
        Dim objDatalistHeader As ArrayList = New ArrayList()
        Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)
        Dim parRptUsername As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("username", Me.UserName)

        objDatalistHeader = Me.GenerateDataHeader()

        Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.tempChannel_ID)
        Dim parRptChannel_nameReport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.tempChannel_nameReport)
        Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.tempChannel_address)
        Dim parRptOutAssetID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("outAsset", Me.tempOutAssetID)
        Dim parRptStrukturUnit As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("strukturUnit", Me.tempStrukturUnit)

        objRdsH.Name = "ASSET_DataSource_clsRptOutAsset"
        objRdsH.Value = objDatalistHeader

        objReportH.ReportEmbeddedResource = "ASSET.RptOutAsset.rdlc"
        objReportH.DataSources.Add(objRdsH)
        objReportH.EnableExternalImages = True
        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptUsername, parRptChannelID, parRptChannel_nameReport, parRptChannel_address, parRptOutAssetID, parRptStrukturUnit})

        AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
        Export(objReportH)

        m_currentPageIndex = 0
        Print()
        Me.LockData()
    End Function

    Private Function uiTrnOutgoingAsset_PrintPreview() As Boolean
        If Me.DgvTrnOutasset.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If
        Dim outasset_id As String
        outasset_id = DgvTrnOutasset.CurrentRow.Cells("outasset_id").Value
        Dim frmPrint As dlgRptOutAsset = New dlgRptOutAsset(Me.DSN, Me.SptServer, Me.NumericUpDown1.Value, Me.UserName, _CHANNEL, outasset_id)
        Dim criteria As String = String.Empty

        frmPrint.ShowInTaskbar = False
        frmPrint.StartPosition = FormStartPosition.CenterParent

        criteria = " and outasset_id = '" & outasset_id & "'"

        frmPrint.SetIDCriteria(criteria)
        frmPrint.ShowDialog(Me)
    End Function

    Private Function uiTrnOutgoingAsset_Delete() As Boolean
        Dim res As String = ""
        Dim outasset_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(outasset_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnOutasset.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnOutgoingAsset_DeleteRow(Me.DgvTrnOutasset.CurrentRow.Index)
            End If
        End If
        RaiseEvent FormAfterDelete(outasset_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnOutgoingAsset_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim outasset_id As String
        Dim NewRowIndex As Integer

        outasset_id = Me.DgvTrnOutasset.Rows(rowIndex).Cells("outasset_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnOutasset_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@strukturunit_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@outasset_id").Value = outasset_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@bookasset_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_startdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@outasset_startdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@outasset_enddt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_starttm", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@outasset_starttm").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_endtm", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@outasset_endtm").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_customer", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@employee_id_customer").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_customer", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@strukturunit_id_customer").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_customerhead", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@employee_id_customerhead").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_item", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@outasset_item").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 9))
        dbCmdDelete.Parameters("@project_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@show_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_st", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@show_epsnumber_st").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_epsnumber_ed", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@show_epsnumber_ed").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_lock", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@outasset_lock").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_remark", System.Data.OleDb.OleDbType.VarWChar, 150))
        dbCmdDelete.Parameters("@outasset_remark").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_logistik", System.Data.OleDb.OleDbType.VarWChar, 15))
        dbCmdDelete.Parameters("@outasset_logistik").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnOutasset.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnOutgoingAsset_OpenRow(NewRowIndex)
                    Me.tbl_TrnOutasset.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnOutasset.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnOutgoingAsset_OpenRow(NewRowIndex)
                    Me.tbl_TrnOutasset.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnOutasset.Rows.RemoveAt(rowIndex)
                    Me.uiTrnOutgoingAsset_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_TrnOutasset_Temp.Clear()
                Me.tbl_TrnOutasset.Rows.RemoveAt(rowIndex)

            End If

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Function
        Finally
            dbConn.Close()
        End Try
    End Function

    Private Function uiTrnOutgoingAsset_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim outasset_id As String
        Dim channel_id As String

        Dim components As Control

        outasset_id = Me.DgvTrnOutasset.Rows(rowIndex).Cells("outasset_id").Value
        channel_id = Me.DgvTrnOutasset.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(outasset_id)


        Try
            dbConn.Open()
            Me.uiTrnOutgoingAsset_OpenRowMaster(channel_id, outasset_id, dbConn)
            Me.uiTrnOutgoingAsset_OpenRowDetil(channel_id, outasset_id, dbConn)

            If Me.obj_Project_id.SelectedValue Is Nothing Then
                Me.Obj_Asset_No_Project.Text = 0
            Else
                Me.Obj_Asset_No_Project.Text = clsUtil.IsDbNull(Me.obj_Project_id.SelectedValue, 0)
            End If

            If Me.obj_outAsset_lock.Checked = True Then
                Me.Panel2.Enabled = False
                Me.PnlDataMaster.Enabled = False
            Else
                Me.Panel2.Enabled = True
                Me.PnlDataMaster.Enabled = True
                If Me.DgvTrnOutassetdetil.Rows.Count > 0 Then
                    For Each components In Panel2.Controls
                        If components.Name <> "obj_remark" And components.Name <> "TextBox1" Then
                            components.Enabled = False
                        End If
                        Me.PnlDataMaster.Enabled = False
                    Next
                End If

                'If Me.obj_remark.Enabled = False Then
                '    Me.Panel2.Enabled = True
                '    Me.obj_remark.Enabled = True
                '    Me.TextBox1.Enabled = True
                'End If
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnOutgoingAsset_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(outasset_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiTrnOutgoingAsset_OpenRowMaster(ByVal channel_id As String, ByVal outasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnOutasset_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format(" and outasset_id='{0}'", outasset_id)
        dbCmd.Parameters.Add("@top", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@top").Value = Me.NumericUpDown1.Value

        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOutasset_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnOutasset_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnOutgoingAsset_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function



    Private Function uiTrnOutgoingAsset_OpenRowDetil(ByVal channel_id As String, ByVal outasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnOutassetdetil_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format(" outasset_id='{0}'", outasset_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnOutassetdetil.Clear()

        Me.tbl_TrnOutassetdetil = clsDataset.CreateTblTrnOutassetdetil()
        Me.tbl_TrnOutassetdetil.Columns("channel_id").DefaultValue = _CHANNEL
        Me.tbl_TrnOutassetdetil.Columns("outasset_id").DefaultValue = outasset_id
        Me.tbl_TrnOutassetdetil.Columns("outasset_line").DefaultValue = DBNull.Value
        Me.tbl_TrnOutassetdetil.Columns("outasset_line").AutoIncrement = True
        Me.tbl_TrnOutassetdetil.Columns("outasset_line").AutoIncrementSeed = 1
        Me.tbl_TrnOutassetdetil.Columns("outasset_line").AutoIncrementStep = 1

        Try
            dbDA.Fill(Me.tbl_TrnOutassetdetil)
            Me.DgvTrnOutassetdetil.DataSource = Me.tbl_TrnOutassetdetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnOutgoingAsset_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnOutgoingAsset_First() As Boolean
        'goto first record found
        If Me.DgvTrnOutasset.SelectedRows.Count <= 0 Then
            MsgBox("No data to choice")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnOutgoingAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnOutasset.CurrentCell = Me.DgvTrnOutasset(1, 0)
            Me.uiTrnOutgoingAsset_RefreshPosition()
        End If
    End Function

    Private Function uiTrnOutgoingAsset_Prev() As Boolean
        'goto previous record found
        If Me.DgvTrnOutasset.SelectedRows.Count <= 0 Then
            MsgBox("No data to choice")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnOutgoingAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnOutasset.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnOutasset.CurrentCell = Me.DgvTrnOutasset(1, DgvTrnOutasset.CurrentCell.RowIndex - 1)
                Me.uiTrnOutgoingAsset_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnOutgoingAsset_Next() As Boolean
        'goto next record found
        If Me.DgvTrnOutasset.SelectedRows.Count <= 0 Then
            MsgBox("No data to choice")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnOutgoingAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnOutasset.CurrentCell.RowIndex < Me.DgvTrnOutasset.Rows.Count - 1 Then
                Me.DgvTrnOutasset.CurrentCell = Me.DgvTrnOutasset(1, DgvTrnOutasset.CurrentCell.RowIndex + 1)
                Me.uiTrnOutgoingAsset_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnOutgoingAsset_Last() As Boolean
        'goto last record found
        If Me.DgvTrnOutasset.SelectedRows.Count <= 0 Then
            MsgBox("No data to choice")
            Exit Function
        End If
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnOutgoingAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnOutasset.CurrentCell = Me.DgvTrnOutasset(1, Me.DgvTrnOutasset.Rows.Count - 1)
            Me.uiTrnOutgoingAsset_RefreshPosition()
        End If
    End Function

    Private Function uiTrnOutgoingAsset_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnOutgoingAsset_OpenRow(Me.DgvTrnOutasset.CurrentRow.Index)
    End Function

    Private Function uiTrnOutgoingAsset_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnOutasset_Temp_Changes As DataTable
        Dim tbl_TrnOutassetdetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim outasset_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult


        If Me.DgvTrnOutasset.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnOutasset_Temp).EndCurrentEdit()
            tbl_TrnOutasset_Temp_Changes = Me.tbl_TrnOutasset_Temp.GetChanges()

            Me.DgvTrnOutassetdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnOutassetdetil).EndCurrentEdit()
            tbl_TrnOutassetdetil_Changes = Me.tbl_TrnOutassetdetil.GetChanges()

            If tbl_TrnOutasset_Temp_Changes IsNot Nothing Or tbl_TrnOutassetdetil_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(outasset_id)

                        Try

                            If tbl_TrnOutasset_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnOutgoingAsset_SaveMaster(outasset_id, tbl_TrnOutasset_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_TrnOutasset_Temp.AcceptChanges()
                            End If

                            If tbl_TrnOutassetdetil_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnOutassetdetil.Rows.Count - 1
                                    If Me.tbl_TrnOutassetdetil.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnOutassetdetil.Rows(i).Item("outasset_id") = outasset_id
                                    End If
                                Next
                                success = Me.uiTrnOutgoingAsset_SaveDetil(outasset_id, tbl_TrnOutassetdetil_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_TrnOutassetdetil.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(outasset_id, result)

                    Case DialogResult.No
                        move = True
                    Case DialogResult.Cancel
                        move = False
                End Select
            Else
                move = True
            End If

        End If

        Return move

    End Function

    Private Function uiTrnOutgoingAsset_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")

            If Me.obj_Show_epsnumber_st.Text > Me.obj_Show_epsnumber_ed.Text Then
                ErrorMessage = "Episode to must be greater than episode from"
                Me.objFormError.SetError(Me.obj_Show_epsnumber_st, ErrorMessage)
                Me.objFormError.SetError(Me.obj_Show_epsnumber_ed, ErrorMessage)
                Throw New Exception(ErrorMessage)
            End If

            'If DateDiff(DateInterval.Second, CDate(Me.obj_Outasset_startdt.Value), CDate(Me.obj_Outasset_enddt.Value)) < 0 Then
            If Format(Me.obj_Outasset_startdt.Value, "dd/MM/yyyy") > Format(Me.obj_Outasset_enddt.Value, "dd/MM/yyyy") Then
                ErrorMessage = "End date must greater than start date"
                Me.objFormError.SetError(Me.obj_Outasset_startdt, ErrorMessage)
                Throw New Exception(ErrorMessage)
            ElseIf Format(Me.obj_Outasset_startdt.Value, "dd/MM/yyyy") = Format(Me.obj_Outasset_enddt.Value, "dd/MM/yyyy") Then
                'ElseIf DateDiff(DateInterval.Second, CDate(Me.obj_Outasset_startdt.Value), CDate(Me.obj_Outasset_enddt.Value)) = 0 Then
                If DateDiff(DateInterval.Second, CDate(Me.obj_Outasset_starttm.Text), CDate(Me.obj_Outasset_endtm.Text)) < 0 Then
                    ErrorMessage = "End time must be greater than start time"
                    Me.objFormError.SetError(Me.obj_Outasset_starttm, ErrorMessage)
                    Throw New Exception(ErrorMessage)
                    Me.objFormError.SetError(Me.obj_Outasset_starttm, "")
                End If
            End If

            If Me.obj_Employee_id_customer.SelectedValue Is DBNull.Value Then
                ErrorMessage = "You must choose the customer combobox"
                Me.objFormError.SetError(Me.obj_Employee_id_customer, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Employee_id_customer, "")
            End If

            If Me.obj_Strukturunit_id_customer.SelectedValue Is DBNull.Value Then
                ErrorMessage = "You must choose the department combobox"
                Me.objFormError.SetError(Me.obj_Strukturunit_id_customer, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Strukturunit_id_customer, "")
            End If

            If Me.obj_Employee_id_customerhead.SelectedValue Is DBNull.Value Then
                ErrorMessage = "You must choose the customer head combobox"
                Me.objFormError.SetError(Me.obj_Employee_id_customerhead, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Employee_id_customerhead, "")
            End If

            If Me.obj_Show_id.SelectedValue Is DBNull.Value Then
                ErrorMessage = "You must choose the show combobox"
                Me.objFormError.SetError(Me.obj_Show_id, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Show_id, "")
            End If

            If Me.obj_Project_id.SelectedValue = 0 Then
                ErrorMessage = "You must choose the budget combobox"
                Me.objFormError.SetError(Me.obj_Project_id, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Project_id, "")
            End If

            If Me.obj_Logistic.SelectedValue Is DBNull.Value Then
                ErrorMessage = "You must choose the logistic combobox"
                Me.objFormError.SetError(Me.obj_Logistic, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Logistic, "")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

    Private Sub uiTrnOutgoingAsset_FormBeforeNew() Handles Me.FormBeforeNew
        Me.objFormError.Clear()
    End Sub

    Private Sub uiTrnOutgoingAsset_FormBeforeOpenRow(ByRef id As Object) Handles Me.FormBeforeOpenRow
        Me.objFormError.Clear()
    End Sub

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        Me.DgvTrnOutasset.DataSource = Me.tbl_TrnOutasset
        objParameters = Me.GetParameterCollection(Me.Parameter)

        If Application.ProductName = _ProductName Then
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
            Me._STRUKTUR_UNIT_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CANCHANGEDSU")
            Me._STRUKTUR_UNIT_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CANBROWSEDSU")
            Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        End If

        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
        '    Dim dummyparameter As String = "CHANNEL=TTV; STRUKTUR_UNIT = 5517;CHANNELCHANGED=0;CHANNELBROWSED=0;CANCHANGEDSU=0;CANBROWSEDSU=0;SU_EMPLOYEE=9002000;"   'Fill Combobox
        '    'dan fungsi2 startup lainnya....
        '    objParameters = Me.GetParameterCollection(dummyparameter)

        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")

        '    Me._STRUKTUR_UNIT = Me.GetValueFromParameter(objParameters, "STRUKTUR_UNIT")
        '    Me._STRUKTUR_UNIT_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CANCHANGEDSU")
        '    Me._STRUKTUR_UNIT_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CANBROWSEDSU")

        '    Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        'End If

        loadcombodata = False

        Me.ComboFill(Me.cboSearchStrukturunit_id, "strukturunit_id", "strukturunit_name", Me.tbl_schStrukturUnit, "as_MstStrukturUnit_Select", "  ")
        Me.tbl_schStrukturUnit.DefaultView.Sort = "strukturunit_name"
        Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", Me.tbl_MstChannelSearch, "as_MstChannel_Select", " channel_id = '" & _CHANNEL & "'")
        Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_id"


        Me.InitLayoutUI()
        Me.BindingStop()
        Me.BindingStart()
        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

        'Me.ftabDataDetil.SelectedIndex = 1
        'Me.ftabDataDetil.SelectedIndex = 0

        Me.cboSearchChannel.SelectedValue = _CHANNEL
        Me.cboSearchStrukturunit_id.SelectedValue = Me._STRUKTUR_UNIT

        Me.chkSearchChannel.Checked = True
        Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_CHANGED
        Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
        Me.obj_Channel_id.Enabled = Me._CHANNEL_CANBE_BROWSED

        Me.chkSearchStrukturUnit_id.Checked = True
        Me.chkSearchStrukturUnit_id.Enabled = Me._STRUKTUR_UNIT_CANBE_CHANGED
        Me.cboSearchStrukturunit_id.Enabled = Me._STRUKTUR_UNIT_CANBE_BROWSED
        Me.obj_Strukturunit_id.Enabled = Me._STRUKTUR_UNIT_CANBE_BROWSED

        Me.cboStatus.SelectedItem = "-- PILIH --"

        'setting tanggal
        Dim myCI As New System.Globalization.CultureInfo("en-GB", False)
        Dim myCIclone As System.Globalization.CultureInfo = CType(myCI.Clone(), System.Globalization.CultureInfo)
        myCIclone.DateTimeFormat.AMDesignator = "a.m."
        myCIclone.DateTimeFormat.DateSeparator = "/"
        myCIclone.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        myCIclone.NumberFormat.CurrencySymbol = "$"
        myCIclone.NumberFormat.NumberDecimalDigits = 4
        System.Threading.Thread.CurrentThread.CurrentCulture = myCIclone

        ' TOOLSTRIP ADD ON
        ' Tambahan Button di toolstrip
        'Me.btnlock.ToolTipText = "Lock Transaction"
        'Me.ToolStrip1.Items.Add(Me.btnlock)
        'Me.btnlock.Image = Me.ImageList1.Images(0)
    End Sub



    Private Sub uiTrnOutgoingAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If
    End Sub
    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged
        'Dim components As Control
        Select Case ftabMain.SelectedIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro

            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White
                loadcombo()

                If Me.DgvTrnOutasset.CurrentRow IsNot Nothing Then
                    Me.uiTrnOutgoingAsset_OpenRow(Me.DgvTrnOutasset.CurrentRow.Index)
                Else
                    Me.uiTrnOutgoingAsset_NewData()
                End If


                'If Me.obj_outAsset_lock.Checked = True Then
                '    Me.Panel2.Enabled = False
                '    Me.PnlDataMaster.Enabled = False
                'Else
                '    Me.Panel2.Enabled = True
                '    Me.PnlDataMaster.Enabled = False
                '    'For Each components In Panel2.Controls
                '    '    If components.Name <> "obj_remark" And components.Name <> "TextBox1" Then
                '    '        components.Enabled = False
                '    '    End If
                '    'Next
                'End If


        End Select
    End Sub
    Private Sub DgvTrnOutasset_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnOutasset.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnOutasset.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Function uiTrnoutasset_Saveke2() As Boolean

        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Try
            Dim dbCmdInsert As OleDb.OleDbCommand
            Dim cek As String
            dbConn.Open()
            dbCmdInsert = New OleDb.OleDbCommand("as_TrnOutassetdetil_Insert", dbConn)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id").Value = Me._CHANNEL
            dbCmdInsert.Parameters.Add("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.obj_Outasset_id.Text
            dbCmdInsert.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4, "outasset_line").Value = 1
            dbCmdInsert.Parameters.Add("@barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "barcode").Value = Trim(Me.TextBox1.Text)
            dbCmdInsert.Parameters.Add("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty").Value = 1
            dbCmdInsert.Parameters.Add("@is_useable", System.Data.OleDb.OleDbType.Boolean, 1, "is_useable").Value = 0
            dbCmdInsert.Parameters.Add("@sthari", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Format(obj_Outasset_startdt.Value, "dd/MM/yyyy")
            dbCmdInsert.Parameters.Add("@edhari", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = CDate(obj_Outasset_enddt.Value)
            dbCmdInsert.Parameters.Add("@sttime", System.Data.OleDb.OleDbType.VarWChar, 5).Value = Me.obj_Outasset_starttm.Text
            dbCmdInsert.Parameters.Add("@edtime", System.Data.OleDb.OleDbType.VarWChar, 5).Value = Me.obj_Outasset_endtm.Text
            dbCmdInsert.Parameters.Add("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, "strukturunit_id").Value = Me._STRUKTUR_UNIT 'Me.obj_Strukturunit_id.SelectedValue 'Me.retStrukturunit_id
            dbCmdInsert.Parameters.Add("@stat", System.Data.OleDb.OleDbType.VarWChar, 10).Direction = ParameterDirection.Output
            dbCmdInsert.ExecuteNonQuery()
            cek = CStr(dbCmdInsert.Parameters("@stat").Value)
            'MsgBox(cek)
            If cek = "A" Then
                suaramenang = PanggilSuara(Application.StartupPath & "\Sound\Ok.wav")
                'suaramenang = PanggilSuara("C:\TransBrowser\Sound\Ok.wav")
                MainkanSuara(suaramenang, SND_SYNC Or SND_MEMORY)
                Me.lock()
            Else
                suaramenang = PanggilSuara(Application.StartupPath & "\Sound\Error.wav")
                'suaramenang = PanggilSuara("C:\TransBrowser\Sound\Error.wav")
                MainkanSuara(suaramenang, SND_SYNC Or SND_MEMORY)
            End If
            dbCmdInsert.Dispose()
            Me.uiTrnOutgoingAsset_OpenRowMaster(_CHANNEL, Me.obj_Outasset_id.Text, dbConn)
            Me.uiTrnOutgoingAsset_OpenRowDetil(_CHANNEL, Me.obj_Outasset_id.Text, dbConn)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        Me.Cursor = Cursors.Arrow
    End Function
    Private Function cek_data(ByVal booking_No As String) As Boolean
        Dim criteria As String = booking_No
        Dim tbl As New DataTable
        Dim tbl1 As New DataTable

        Dim jawab As String

        Try

            tbl.Clear()
            Me.DataFill(tbl, "as_statusbookasset", Me._CHANNEL, criteria, Me._STRUKTUR_UNIT)
            status = tbl.Rows(0)("status")

            If status = "Y" Then
                jawab = MsgBox("akan dilanjutkan", MsgBoxStyle.YesNo, "Confirm")
                If jawab = vbNo Then
                    Me.ftabMain.SelectedIndex = 0
                    Exit Function
                Else
                    Me.Cursor = Cursors.WaitCursor
                    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                    Dim dbCmdInsert As OleDb.OleDbCommand
                    dbConn.Open()
                    dbCmdInsert = New OleDb.OleDbCommand("as_movebooktooutgoing", dbConn)
                    dbCmdInsert.CommandType = CommandType.StoredProcedure
                    dbCmdInsert.Parameters.Add("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 20)
                    dbCmdInsert.Parameters("@bookasset_id").Value = criteria
                    dbCmdInsert.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 30)
                    dbCmdInsert.Parameters("@status").Value = status
                    dbCmdInsert.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20)
                    dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL
                    dbCmdInsert.Parameters.Add("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5)
                    dbCmdInsert.Parameters("@strukturunit_id").Value = Me._STRUKTUR_UNIT
                    dbCmdInsert.Parameters.Add("@outasset_inputby", System.Data.OleDb.OleDbType.VarWChar, 32)
                    dbCmdInsert.Parameters("@outasset_inputby").Value = Me.UserName
                    dbCmdInsert.Parameters.Add("@outid", System.Data.OleDb.OleDbType.VarWChar, 30).Direction = ParameterDirection.Output
                    dbCmdInsert.ExecuteNonQuery()

                    outAsset_No = CStr(dbCmdInsert.Parameters("@outid").Value)
                    If outAsset_No <> "" Then
                        param = "1"
                    Else
                        param = "0"
                    End If
                    dbCmdInsert.Dispose()
                    Me.Cursor = Cursors.Arrow
                    Me.ftabMain.SelectedIndex = 0
                    criteria = " outassetid = '" & outAsset_No & "'"
                    uiTrnOutgoingAsset_Retrieve()
                End If
            Else
                MsgBox("transaksi harus secara manual")
                param = "0"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub LockData()
        'validasi doeloe
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_Locktransaksi_outasset", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnOutasset.Item("outasset_id", DgvTrnOutasset.CurrentRow.Index).Value
            oCm.ExecuteNonQuery()
            oCm.Dispose()
            Me.obj_outAsset_lock.Checked = True
            Me.DgvTrnOutasset.Item("outasset_lock", DgvTrnOutasset.CurrentRow.Index).Value = 1
            Me.PnlDataMaster.Enabled = False
            Me.Panel2.Enabled = False
            MessageBox.Show("Data Has Been Locked", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click

        If Me.DgvTrnOutasset.Rows(Me.DgvTrnOutasset.CurrentRow.Index).Cells("outasset_lock").Value = True Then
            MsgBox("Can't Update. Data has been lock")
            Exit Sub
        End If

        Me.str_Outasset_id = Me.obj_Outasset_id.Text
        If Me.DgvTrnOutassetdetil.Rows.Count <= 0 Then
            Exit Sub
        End If
        line = Me.DgvTrnOutassetdetil.CurrentRow.Cells("outasset_line").Value
        Dim dlg As New dlgUpdateOutDetil(Me.DSN, _CHANNEL, Me.str_Outasset_id, line)
        qty = dlg.OpenDialog(Me)
        If qty Is Nothing Then
            Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            Me.uiTrnOutgoingAsset_OpenRowDetil(_CHANNEL, Me.obj_Outasset_id.Text, dbConn)
        End If
    End Sub
    Private Sub DgvTrnOutasset_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnOutasset.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)
        Try
            If objrow.Cells("outasset_status").Value = "OUTGOING" Then
                objrow.DefaultCellStyle.BackColor = Color.PapayaWhip
            ElseIf objrow.Cells("outasset_status").Value = "INCOMPLETE" Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            Else
                objrow.DefaultCellStyle.BackColor = Color.PowderBlue
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DgvTrnOutassetdetil_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnOutassetdetil.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

        Try
            If objrow.Cells("outasset_return").Value = 0 And objrow.Cells("bookasset_id").Value Is DBNull.Value Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            ElseIf objrow.Cells("outasset_return").Value = 1 And objrow.Cells("bookasset_id").Value Is DBNull.Value Then
                objrow.DefaultCellStyle.BackColor = Color.PowderBlue
            ElseIf objrow.Cells("outasset_return").Value = 0 And objrow.Cells("bookasset_id").Value IsNot DBNull.Value Then
                objrow.DefaultCellStyle.BackColor = Color.Linen 'Color.LightGoldenrodYellow
            Else
                objrow.DefaultCellStyle.BackColor = Color.PapayaWhip
            End If
        Catch ex As Exception
        End Try
    End Sub
    'Private Sub coba()
    '    Dim criteria As String = String.Format(" and outasset_id = '{0}'", Me.obj_Outasset_id.Text)
    '    Dim tbl As New DataTable
    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

    '    Try

    '        tbl.Rows.Clear()
    '        DataFill(tbl, "as_TrnOutasset_Select", criteria, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)
    '        retStrukturunit_id = tbl.Rows(0)("strukturunit_id")

    '    Catch ex As Exception

    '    End Try

    'End Sub
    Private Sub loadcombo()
        If loadcombodata = False Then

            loadcombodata = True
            Me.ComboFillAngka(Me.ASSET_DSN, Me.obj_Project_id, "budget_id", "budget_name", Me.tbl_project, "as_MstProject_Select", " ", _CHANNEL)
            Me.tbl_project.DefaultView.Sort = "budget_name"

            Dim copyTbl_channel As Boolean
            Me.tbl_MstChannel = Me.tbl_MstChannelSearch.Copy
            copyTbl_channel = ComboFillFromDataTable(Me.obj_Channel_id, "channel_id", "channel_id", Me.tbl_MstChannel)
            Me.tbl_MstChannel.DefaultView.Sort = "channel_id"

            Me.ComboFill(Me.obj_Logistic, "employee_id", "employee_namalengkap", Me.tbl_MstEmployee, "ms_MstEmployee_Select", " strukturunit_id = " & Me._SU_EMPLOYEE)
            Me.tbl_MstEmployee.DefaultView.Sort = "employee_namalengkap"

            Me.ComboFill(Me.obj_Employee_id_customer, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeecustomer, "ms_MstEmployee_Select", "  ")
            Me.tbl_MstEmployeecustomer.DefaultView.Sort = "employee_namalengkap"
            Dim copyTbl_employee_customer_head As Boolean
            Me.tbl_MstEmployeecustomerhead = Me.tbl_MstEmployeecustomer.Copy
            copyTbl_employee_customer_head = ComboFillFromDataTable(Me.obj_Employee_id_customerhead, "employee_id", "employee_namalengkap", Me.tbl_MstEmployeecustomerhead)
            Me.tbl_MstEmployeecustomerhead.DefaultView.Sort = "employee_namalengkap"

            Dim copyTblStrukturunit_id_customer As Boolean
            Me.tbl_MstStrukturunitcustomer = Me.tbl_schStrukturUnit.Copy
            copyTblStrukturunit_id_customer = ComboFillFromDataTable(Me.obj_Strukturunit_id_customer, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitcustomer)
            Me.tbl_MstStrukturunitcustomer.DefaultView.Sort = "strukturunit_name"
            Dim copyTblStrukturunit_id_customerOwner As Boolean
            Me.tbl_MstStrukturunitOwner = Me.tbl_schStrukturUnit.Copy
            copyTblStrukturunit_id_customerOwner = ComboFillFromDataTable(Me.obj_Strukturunit_id, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitcustomer)
            Me.tbl_MstStrukturunitOwner.DefaultView.Sort = "strukturunit_name"

            Me.ComboFill(Me.obj_Show_id, "show_id", "show_title", Me.tbl_show, "as_MstShow_Select ", " ", _CHANNEL)
            tbl_show.DefaultView.Sort = "show_title"

            'Me.ftabDataDetil.SelectedIndex = 1
            'Me.ftabDataDetil.SelectedIndex = 0

        End If
    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        Me.objFormError.Clear()
        If e.KeyChar.ToString = Microsoft.VisualBasic.ChrW(13) Then

            If Trim(Me.obj_Outasset_id.Text) = "AUTO" Then
                MsgBox("Save Header Transaction First")
                Exit Sub
            End If

            Me.check_before_savedetil()
            If Me.isCheck = False Then
                Exit Sub
            End If
            If Len(Trim(Me.TextBox1.Text)) >= 2 Then
                Me.uiTrnoutasset_Saveke2()
                Me.Cursor = Cursors.Arrow
            Else
                MsgBox("Please Input Item", MsgBoxStyle.Information, "Warning")
                Me.TextBox1.Text = ""
                Me.TextBox1.Focus()
                Exit Sub
            End If
            Me.TextBox1.Text = "- - Item Outgoing - -"
        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Me.TextBox1.Text = "- - Item Outgoing - -"
    End Sub


    Private Sub DgvTrnOutassetdetil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnOutassetdetil.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim click As DataGridView.HitTestInfo = Me.DgvTrnOutassetdetil.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnOutassetdetil.CurrentCell = Me.DgvTrnOutassetdetil.Rows(click.RowIndex).Cells(click.ColumnIndex)
            End If
        End If
    End Sub

    Private Sub DgvTrnOutasset_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DgvTrnOutasset.RowPostPaint
        Using b As SolidBrush = New SolidBrush(DgvTrnOutasset.ColumnHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), _
                                  DgvTrnOutasset.DefaultCellStyle.Font, _
                                  b, _
                                  e.RowBounds.Location.X + 10, _
                                  e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub Obj_Asset_No_Project_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Obj_Asset_No_Project.Validated
        Dim criteria As String = String.Empty
        Dim budget As DataTable = New DataTable

        If Me.Obj_Asset_No_Project.Text = String.Empty Then
            Exit Sub
        End If

        criteria = String.Format(" budget_id = " & Me.Obj_Asset_No_Project.Text)

        Me.DataFill(budget, "as_MstProject_Select", criteria, Me._CHANNEL)

        If budget.Rows.Count <= 0 Then
            Me.Obj_Asset_No_Project.Text = 0
            Me.obj_Project_id.SelectedValue = 0
            Me.obj_Show_epsnumber_st.Text = 0
            Me.obj_Show_epsnumber_ed.Text = 0
        Else
            Me.obj_Project_id.SelectedValue = clsUtil.IsDbNull(budget.Rows(0).Item("budget_id"), 0)
            Me.obj_Show_epsnumber_st.Text = clsUtil.IsDbNull(budget.Rows(0).Item("budget_epsstart"), 0)
            Me.obj_Show_epsnumber_ed.Text = clsUtil.IsDbNull(budget.Rows(0).Item("budget_epsend"), 0)
        End If
    End Sub

    Private Sub obj_Project_id_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Project_id.SelectionChangeCommitted
        Me.Obj_Asset_No_Project.Text = clsUtil.IsDbNull(Me.obj_Project_id.SelectedValue, 0)
        Dim criteria As String = String.Empty
        Dim budget As DataTable = New DataTable

        If Me.obj_Project_id.SelectedValue = 0 Then
            Me.Obj_Asset_No_Project.Text = 0
            Me.obj_Show_epsnumber_st.Text = 0
            Me.obj_Show_epsnumber_ed.Text = 0
            Exit Sub
        End If

        criteria = String.Format(" budget_id = " & Me.obj_Project_id.SelectedValue)

        Me.DataFill(budget, "as_MstProject_Select", criteria, Me._CHANNEL)
        If budget.Rows.Count <= 0 Then
            Me.Obj_Asset_No_Project.Text = 0
            Me.obj_Project_id.SelectedValue = 0
            Me.obj_Show_epsnumber_st.Text = 0
            Me.obj_Show_epsnumber_ed.Text = 0
        Else
            Me.obj_Project_id.SelectedValue = clsUtil.IsDbNull(budget.Rows(0).Item("budget_id"), 0)
            Me.obj_Show_epsnumber_st.Text = clsUtil.IsDbNull(budget.Rows(0).Item("budget_epsstart"), 0)
            Me.obj_Show_epsnumber_ed.Text = clsUtil.IsDbNull(budget.Rows(0).Item("budget_epsend"), 0)
        End If
    End Sub

    Private Sub lock()
        Dim components As Control
        If Me.DgvTrnOutassetdetil.Rows.Count = 0 Then
            Me.PnlDataMaster.Enabled = False
            For Each components In Panel2.Controls
                If components.Name <> "obj_remark" And components.Name <> "TextBox1" Then
                    components.Enabled = False
                End If
            Next
        End If
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        If chkStatus.Checked = True Then
            Me.cboStatus.Enabled = True
            Me.cboStatus.SelectedItem = "-- PILIH --"
        Else
            Me.cboStatus.Enabled = False
        End If
    End Sub

    Private Sub check_before_savedetil()
        Dim ErrorMessage As String = ""
        Dim criteria As String = String.Format(" AND outasset_id = '{0}'", Me.obj_Outasset_id.Text)
        Dim tbl_TrnOuasset_check As DataTable = New DataTable
        tbl_TrnOuasset_check.Clear()
        Me.isCheck = True

        Try
            Me.DataFill(tbl_TrnOuasset_check, "as_TrnOutasset_Select", criteria, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)

            If tbl_TrnOuasset_check.Rows(0).Item("show_epsnumber_st") > tbl_TrnOuasset_check.Rows(0).Item("show_epsnumber_ed") Then
                ErrorMessage = "Episode to must be greater than episode from"
                Me.objFormError.SetError(Me.obj_Show_epsnumber_st, ErrorMessage)
                Me.objFormError.SetError(Me.obj_Show_epsnumber_ed, ErrorMessage)
                Throw New Exception(ErrorMessage)
            End If

            If Format(tbl_TrnOuasset_check.Rows(0).Item("outasset_startdt"), "dd/MM/yyyy") > Format(tbl_TrnOuasset_check.Rows(0).Item("outasset_enddt"), "dd/MM/yyyy") Then
                ErrorMessage = "End date must greater than start date"
                Me.objFormError.SetError(Me.obj_Outasset_startdt, ErrorMessage)
                Throw New Exception(ErrorMessage)
            ElseIf Format(tbl_TrnOuasset_check.Rows(0).Item("outasset_startdt"), "dd/MM/yyyy") > Format(tbl_TrnOuasset_check.Rows(0).Item("outasset_enddt"), "dd/MM/yyyy") Then
                If DateDiff(DateInterval.Second, CDate(tbl_TrnOuasset_check.Rows(0).Item("outasset_starttm")), CDate(tbl_TrnOuasset_check.Rows(0).Item("outasset_endtm"))) Then
                    ErrorMessage = "End time must be greater than start time"
                    Me.objFormError.SetError(Me.obj_Outasset_starttm, ErrorMessage)
                    Throw New Exception(ErrorMessage)
                    Me.objFormError.SetError(Me.obj_Outasset_starttm, "")
                End If
            End If

            If tbl_TrnOuasset_check.Rows(0).Item("employee_id_customer") = "0" Then
                ErrorMessage = "You must choose the customer combobox"
                Me.objFormError.SetError(Me.obj_Employee_id_customer, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Employee_id_customer, "")
            End If

            If tbl_TrnOuasset_check.Rows(0).Item("strukturunit_id_customer") = 0 Then
                ErrorMessage = "You must choose the department combobox"
                Me.objFormError.SetError(Me.obj_Strukturunit_id_customer, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Strukturunit_id_customer, "")
            End If

            If tbl_TrnOuasset_check.Rows(0).Item("employee_id_customerhead") = "0" Then
                ErrorMessage = "You must choose the customer head combobox"
                Me.objFormError.SetError(Me.obj_Employee_id_customerhead, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Employee_id_customerhead, "")
            End If


            If tbl_TrnOuasset_check.Rows(0).Item("show_id") = "0" Then
                ErrorMessage = "You must choose the show combobox"
                Me.objFormError.SetError(Me.obj_Show_id, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Show_id, "")
            End If

            If tbl_TrnOuasset_check.Rows(0).Item("project_id") = 0 Then
                ErrorMessage = "You must choose the budget combobox"
                Me.objFormError.SetError(Me.obj_Project_id, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Project_id, "")
            End If

            If tbl_TrnOuasset_check.Rows(0).Item("outasset_logistik") Is DBNull.Value Then
                ErrorMessage = "You must choose the logistic combobox"
                Me.objFormError.SetError(Me.obj_Logistic, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Logistic, "")
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.isCheck = False
        End Try
    End Sub
End Class


