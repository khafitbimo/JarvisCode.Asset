Public Class uiTrnIncomingAsset
    Private Const mUiName As String = "Pengembalian Asset"
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
    Private tbl_MstStrukturunitOwner As DataTable = clsDataset.CreateTblStrukturunitPengguna()
    Private tbl_MstStrukturunitReturn As DataTable = clsDataset.CreateTblStrukturunitPengguna()
    Private tbl_MstEmployee As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_MstEmployee_return As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_MstStrukturunitcustomer As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_schStrukturUnit As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_TrnOutasset As DataTable = clsDataset.CreateTblTrnOutasset()

    Private tbl_TrnIncasset As DataTable = clsDataset.CreateTblTrnIncasset()
    Private tbl_TrnIncasset_Temp As DataTable = clsDataset.CreateTblTrnIncasset()
    Private tbl_TrnIncassetdetil As DataTable = clsDataset.CreateTblTrnIncassetdetil()

    Private status, bookAsset_id, outAsset_startDt, outAsset_endDt, outasset_starttm, outasset_endtm As String
    Private outAsset_item, outasset_itemreturn As Integer

    Private tbl_Print As DataTable = clsDataset.CreateTblTrnIncasset
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnIncassetdetil
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptIncAsset
    Private objDatalistDetil As ArrayList
    Private suaramenang As String

    Private str_IncAsset_id, qty As String
    Private line As Integer
    Private combodata As Boolean

    Private tempChannel_ID As String
    Private tempChannel_nameReport As String
    Private tempChannel_address As String
    Private tempIncAssetID As String
    Private tempStrukturUnit As String
    Private temps_conditions As String

    Friend WithEvents btnlock As ToolStripButton = New ToolStripButton

#Region " Window Parameter "

    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    Private _STRUKTUR_UNIT As Decimal = 5554           'tambahan
    Private _SU_EMPLOYEE As String = "9002000"

    ' TODO: Buat variabel untuk menampung parameter window 

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
        Dim newdata_incoming As DlgNewDataIncoming = New DlgNewDataIncoming(Me.DSN, Me._CHANNEL, Me._STRUKTUR_UNIT)
        Dim param As String

        Me.temps_conditions = String.Empty


        newdata_incoming.ShowInTaskbar = False
        newdata_incoming.StartPosition = FormStartPosition.CenterParent
        newdata_incoming.ShowDialog(Me)

        If newdata_incoming.DialogResult = DialogResult.OK Then
            If newdata_incoming.obj_oto.Text = "" Then
                MsgBox("Masukkan dulu nomor Outgoing Anda")
            Else
                newdata_incoming.Hide()
                param = newdata_incoming.obj_oto.Text
                Me.cek_data(param)
                If Me.temps_conditions = String.Empty Then
                    If Me.outAsset_item = Me.outasset_itemreturn Then
                        MsgBox("Your transaction is complete")
                        Exit Function
                    End If
                End If
                If status = "N" Then
                    Exit Function
                Else
                    If Me.ftabMain.SelectedIndex = 0 Then
                        Me.ftabMain.SelectedIndex = 1
                    End If
                    Me.uiTrnIncomingAsset_NewData()
                    Me.obj_Bookasset_id.Text = Me.bookAsset_id
                    Me.obj_Outasset_id.Text = param
                    Me.obj_Outasset_startdt.Text = Me.outAsset_startDt
                    Me.obj_Outasset_enddt.Text = Me.outAsset_endDt
                    Me.obj_Username_inputby.Text = UserName
                    Me.obj_Incasset_id.Text = "AUTO"
                    Me.obj_Outasset_item.Text = Me.outAsset_item
                    Me.obj_Incasset_returnitem.Text = Me.outasset_itemreturn

                    If Me.outasset_itemreturn <> 0 Then
                        Me.obj_Incasset_status.Text = "INCOMPLETE"
                    End If

                    Me.Panel2.Enabled = True
                End If
            End If
        End If

        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnIncomingAsset_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnIncomingAsset_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnIncomingAsset_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnIncomingAsset_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function

    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnIncomingAsset_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnIncomingAsset_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnIncomingAsset_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function

    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnIncomingAsset_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function

    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnIncomingAsset_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function

    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnIncomingAsset_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function


#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnIncasset(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' Format DgvTrnIncasset Columns 
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIncasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBookasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIncasset_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_startdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_enddt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIncasset_actreturn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cOutasset_item As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIncasset_returnitem As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cEmployee_id_returnby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id_returnby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cUsername_inputby As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIncasset_inputdt As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cInasset_remark As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cInasset_logistik As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cInasset_lock As System.Windows.Forms.DataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cStrukturunit_id.Name = "Strukturunit_id"
        cStrukturunit_id.HeaderText = "Department"
        cStrukturunit_id.DataPropertyName = "strukturunit_id_string"
        cStrukturunit_id.Width = 150
        cStrukturunit_id.Visible = True
        cStrukturunit_id.ReadOnly = False

        cIncasset_id.Name = "incasset_id"
        cIncasset_id.HeaderText = "No. Incoming"
        cIncasset_id.DataPropertyName = "incasset_id"
        cIncasset_id.Width = 100
        cIncasset_id.Visible = True
        cIncasset_id.ReadOnly = False

        cOutasset_id.Name = "outasset_id"
        cOutasset_id.HeaderText = "No. Outgoing"
        cOutasset_id.DataPropertyName = "outasset_id"
        cOutasset_id.Width = 100
        cOutasset_id.Visible = True
        cOutasset_id.ReadOnly = False

        cBookasset_id.Name = "bookasset_id"
        cBookasset_id.HeaderText = "No. Booking"
        cBookasset_id.DataPropertyName = "bookasset_id"
        cBookasset_id.Width = 100
        cBookasset_id.Visible = True
        cBookasset_id.ReadOnly = False

        cIncasset_status.Name = "incasset_status"
        cIncasset_status.HeaderText = "Status"
        cIncasset_status.DataPropertyName = "incasset_status"
        cIncasset_status.Width = 100
        cIncasset_status.Visible = True
        cIncasset_status.ReadOnly = False

        cOutasset_startdt.Name = "outasset_startdt"
        cOutasset_startdt.HeaderText = "Start Date"
        cOutasset_startdt.DataPropertyName = "outasset_startdt"
        cOutasset_startdt.Width = 100
        cOutasset_startdt.DefaultCellStyle.Format = "dd-MM-yy"
        cOutasset_startdt.Visible = True
        cOutasset_startdt.ReadOnly = False

        cOutasset_enddt.Name = "outasset_enddt"
        cOutasset_enddt.HeaderText = "End Date"
        cOutasset_enddt.DataPropertyName = "outasset_enddt"
        cOutasset_enddt.Width = 100
        cOutasset_startdt.DefaultCellStyle.Format = "dd-MMMM-yy"
        cOutasset_enddt.Visible = True
        cOutasset_enddt.ReadOnly = False

        cIncasset_actreturn.Name = "incasset_actreturn"
        cIncasset_actreturn.HeaderText = "Return Date"
        cIncasset_actreturn.DataPropertyName = "incasset_actreturn"
        cIncasset_actreturn.Width = 100
        cOutasset_startdt.DefaultCellStyle.Format = "dd-MMMM-yy"
        cIncasset_actreturn.Visible = True
        cIncasset_actreturn.ReadOnly = False

        cOutasset_item.Name = "outasset_item"
        cOutasset_item.HeaderText = "Item"
        cOutasset_item.DataPropertyName = "outasset_item"
        cOutasset_item.Width = 60
        cOutasset_item.Visible = True
        cOutasset_item.ReadOnly = False

        cIncasset_returnitem.Name = "incasset_returnitem"
        cIncasset_returnitem.HeaderText = "Return"
        cIncasset_returnitem.DataPropertyName = "incasset_returnitem"
        cIncasset_returnitem.Width = 75
        cIncasset_returnitem.Visible = True
        cIncasset_returnitem.ReadOnly = False

        cEmployee_id_returnby.Name = "employee_id_return_by"
        cEmployee_id_returnby.HeaderText = "Return By"
        cEmployee_id_returnby.DataPropertyName = "employee_id_return_by_string"
        cEmployee_id_returnby.Width = 130
        cEmployee_id_returnby.Visible = True
        cEmployee_id_returnby.ReadOnly = False


        cStrukturunit_id_returnby.Name = "strukturunit_id_returnby"
        cStrukturunit_id_returnby.HeaderText = "Struktur Unit"
        cStrukturunit_id_returnby.DataPropertyName = "struktur_unit_id_returnby_string"
        cStrukturunit_id_returnby.Width = 130
        cStrukturunit_id_returnby.Visible = False
        cStrukturunit_id_returnby.ReadOnly = False

        cUsername_inputby.Name = "username_inputby"
        cUsername_inputby.HeaderText = "Input By"
        cUsername_inputby.DataPropertyName = "username_inputby"
        cUsername_inputby.Width = 100
        cUsername_inputby.Visible = True
        cUsername_inputby.ReadOnly = False

        cIncasset_inputdt.Name = "incasset_inputdt"
        cIncasset_inputdt.HeaderText = "incasset_inputdt"
        cIncasset_inputdt.DataPropertyName = "incasset_inputdt"
        cIncasset_inputdt.Width = 100
        cIncasset_inputdt.Visible = False
        cIncasset_inputdt.ReadOnly = False

        cInasset_remark.Name = "inasset_remark"
        cInasset_remark.HeaderText = "Remark"
        cInasset_remark.DataPropertyName = "inasset_remark"
        cInasset_remark.Width = 150
        cInasset_remark.Visible = True
        cInasset_remark.ReadOnly = False

        cInasset_logistik.Name = "inasset_logistik"
        cInasset_logistik.HeaderText = "Logistic"
        cInasset_logistik.DataPropertyName = "inasset_logistik_string"
        cInasset_logistik.Width = 130
        cInasset_logistik.Visible = True
        cInasset_logistik.ReadOnly = False

        cInasset_lock.Name = "inasset_lock"
        cInasset_lock.HeaderText = "C"
        cInasset_lock.DataPropertyName = "inasset_lock"
        cInasset_lock.Width = 30
        cInasset_lock.Visible = True
        cInasset_lock.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cInasset_lock, cChannel_id, cIncasset_id, cOutasset_id, cBookasset_id, cStrukturunit_id, _
        cIncasset_status, cOutasset_startdt, cOutasset_enddt, cIncasset_actreturn, _
        cOutasset_item, cIncasset_returnitem, cEmployee_id_returnby, _
        cStrukturunit_id_returnby, cUsername_inputby, cIncasset_inputdt, _
        cInasset_remark, cInasset_logistik})

        ' DgvTrnIncasset Behaviours: 
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
        objDgv.AllowUserToResizeRows = False
        objDgv.ReadOnly = True
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Function

    Private Function FormatDgvTrnIncassetdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        ' formating DgvTrnIncassetdetil
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIncasset_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cLine As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_barcode As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cQty As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cIs_useable As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cAsset_status As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cNama As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSn As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cKategori As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cTipe As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cIncasset_id.Name = "incasset_id"
        cIncasset_id.HeaderText = "Incoming ID"
        cIncasset_id.DataPropertyName = "incasset_id"
        cIncasset_id.Width = 100
        cIncasset_id.Visible = False
        cIncasset_id.ReadOnly = False

        cLine.Name = "line"
        cLine.HeaderText = "Line"
        cLine.DataPropertyName = "line"
        cLine.Width = 50
        cLine.Visible = True
        cLine.ReadOnly = False

        cAsset_barcode.Name = "asset_barcode"
        cAsset_barcode.HeaderText = "Barcode"
        cAsset_barcode.DataPropertyName = "asset_barcode"
        cAsset_barcode.Width = 100
        cAsset_barcode.Visible = True
        cAsset_barcode.ReadOnly = False

        cQty.Name = "qty"
        cQty.HeaderText = "Qty"
        cQty.DataPropertyName = "qty"
        cQty.Width = 50
        cQty.Visible = True
        cQty.ReadOnly = False

        cIs_useable.Name = "is_useable"
        cIs_useable.HeaderText = "Use Able"
        cIs_useable.DataPropertyName = "is_useable"
        cIs_useable.Width = 80
        cIs_useable.Visible = False
        cIs_useable.ReadOnly = False

        cAsset_status.Name = "asset_status"
        cAsset_status.HeaderText = "Status"
        cAsset_status.DataPropertyName = "asset_status"
        cAsset_status.Width = 100
        cAsset_status.Visible = True
        cAsset_status.ReadOnly = False

        cNama.Name = "asset_deskripsi"
        cNama.HeaderText = "Description"
        cNama.DataPropertyName = "asset_deskripsi"
        cNama.Width = 200
        cNama.Visible = True

        cSn.Name = "asset_serial"
        cSn.HeaderText = "S/N"
        cSn.DataPropertyName = "asset_serial"
        cSn.Width = 150
        cSn.Visible = True

        cKategori.Name = "kategoriitem_id"
        cKategori.HeaderText = "Category"
        cKategori.DataPropertyName = "kategoriitem_id"
        cKategori.Width = 150
        cKategori.Visible = True

        cTipe.Name = "tipeitem_id"
        cTipe.HeaderText = "Type"
        cTipe.DataPropertyName = "tipeitem_id"
        cTipe.Width = 150
        cTipe.Visible = True

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cChannel_id, cIncasset_id, cAsset_barcode, cSn, cNama, cTipe, cKategori, _
         cQty, cIs_useable, cAsset_status, cLine})

        objDgv.ReadOnly = True
        objDgv.AutoGenerateColumns = False
        objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
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
        Me.DgvTrnIncasset.Dock = DockStyle.Fill

        Me.FormatDgvTrnIncasset(Me.DgvTrnIncasset)
        Me.FormatDgvTrnIncassetdetil(Me.DgvTrnIncassetdetil)

    End Function

    Private Function BindingStop() As Boolean

        'stop binding
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Strukturunit_id.DataBindings.Clear()
        Me.obj_Incasset_id.DataBindings.Clear()
        Me.obj_Outasset_id.DataBindings.Clear()
        Me.obj_Bookasset_id.DataBindings.Clear()

        Me.obj_Incasset_status.DataBindings.Clear()
        Me.obj_Outasset_startdt.DataBindings.Clear()
        Me.obj_Outasset_enddt.DataBindings.Clear()
        Me.obj_incasset_inputDate.DataBindings.Clear()
        Me.obj_Outasset_item.DataBindings.Clear()

        Me.obj_Incasset_returnitem.DataBindings.Clear()
        Me.obj_Employee_id_returnby.DataBindings.Clear()
        Me.obj_Strukturunit_id_returnby.DataBindings.Clear()
        Me.obj_Username_inputby.DataBindings.Clear()
        Me.obj_Incasset_inputdt.DataBindings.Clear()

        Me.obj_Inasset_remark.DataBindings.Clear()
        Me.obj_Inasset_logistik.DataBindings.Clear()
        Me.obj_Inasset_lock.DataBindings.Clear()

        Me.obj_Editby.DataBindings.Clear()
        Me.obj_Editdt.DataBindings.Clear()
        Me.obj_Usedby.DataBindings.Clear()
        Me.obj_Useddt.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.obj_Channel_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnIncasset_Temp, "channel_id"))
        Me.obj_Strukturunit_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnIncasset_Temp, "strukturunit_id"))
        Me.obj_Incasset_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "incasset_id"))
        Me.obj_Outasset_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "outasset_id"))
        Me.obj_Bookasset_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "bookasset_id"))

        Me.obj_Incasset_status.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "incasset_status"))
        Me.obj_Outasset_startdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "outasset_startdt"))
        Me.obj_Outasset_enddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "outasset_enddt"))
        Me.obj_Incasset_inputdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "incasset_actreturn"))
        Me.obj_Outasset_item.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "outasset_item"))

        Me.obj_Incasset_returnitem.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "incasset_returnitem"))
        Me.obj_Employee_id_returnby.DataBindings.Add(New Binding("selectedValue", Me.tbl_TrnIncasset_Temp, "employee_id_returnby"))
        Me.obj_Strukturunit_id_returnby.DataBindings.Add(New Binding("selectedValue", Me.tbl_TrnIncasset_Temp, "strukturunit_id_returnby"))
        Me.obj_Username_inputby.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "username_inputby"))
        Me.obj_incasset_inputDate.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "incasset_inputdt"))

        Me.obj_Inasset_remark.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "inasset_remark"))
        Me.obj_Inasset_logistik.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnIncasset_Temp, "inasset_logistik"))
        Me.obj_Inasset_lock.DataBindings.Add(New Binding("Checked", Me.tbl_TrnIncasset, "inasset_lock"))

        Me.obj_Editby.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "incasset_editby"))
        Me.obj_Editdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "incasset_editdt"))
        Me.obj_Usedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "incasset_usedby"))
        Me.obj_Useddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnIncasset_Temp, "incasset_useddt"))

        Return True
    End Function

#End Region

#Region " Dialoged Control "
#End Region


#Region " User Defined Function "

    Private Function uiTrnIncomingAsset_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnIncasset_Temp
        Me.tbl_TrnIncasset_Temp.Clear()
        Me.tbl_TrnIncasset_Temp.Columns("channel_id").DefaultValue = _CHANNEL
        Me.tbl_TrnIncasset_Temp.Columns("strukturunit_id").DefaultValue = _STRUKTUR_UNIT
        Me.tbl_TrnIncasset_Temp.Columns("incasset_id").DefaultValue = DBNull.Value
        Me.tbl_TrnIncasset_Temp.Columns("outasset_id").DefaultValue = DBNull.Value
        Me.tbl_TrnIncasset_Temp.Columns("bookasset_id").DefaultValue = DBNull.Value
        Me.tbl_TrnIncasset_Temp.Columns("incasset_status").DefaultValue = DBNull.Value
        Me.tbl_TrnIncasset_Temp.Columns("outasset_startdt").DefaultValue = Now
        Me.tbl_TrnIncasset_Temp.Columns("outasset_enddt").DefaultValue = Now
        Me.tbl_TrnIncasset_Temp.Columns("incasset_actreturn").DefaultValue = Now
        Me.tbl_TrnIncasset_Temp.Columns("outasset_item").DefaultValue = 0
        Me.tbl_TrnIncasset_Temp.Columns("incasset_returnitem").DefaultValue = 0
        Me.tbl_TrnIncasset_Temp.Columns("employee_id_returnby").DefaultValue = DBNull.Value
        Me.tbl_TrnIncasset_Temp.Columns("strukturunit_id_returnby").DefaultValue = DBNull.Value
        Me.tbl_TrnIncasset_Temp.Columns("username_inputby").DefaultValue = DBNull.Value
        Me.tbl_TrnIncasset_Temp.Columns("incasset_inputdt").DefaultValue = Now
        Me.tbl_TrnIncasset_Temp.Columns("inasset_remark").DefaultValue = DBNull.Value
        Me.tbl_TrnIncasset_Temp.Columns("inasset_logistik").DefaultValue = DBNull.Value
        Me.tbl_TrnIncasset_Temp.Columns("inasset_lock").DefaultValue = 0

        ' TODO: Set Default Value for tbl_TrnIncassetdetil
        Me.tbl_TrnIncassetdetil.Clear()
        Me.tbl_TrnIncassetdetil = clsDataset.CreateTblTrnIncassetdetil()
        Me.tbl_TrnIncassetdetil.Columns("incasset_id").DefaultValue = 0
        Me.tbl_TrnIncassetdetil.Columns("line").DefaultValue = DBNull.Value
        Me.tbl_TrnIncassetdetil.Columns("line").AutoIncrement = True
        Me.tbl_TrnIncassetdetil.Columns("line").AutoIncrementSeed = 10
        Me.tbl_TrnIncassetdetil.Columns("line").AutoIncrementStep = 10
        Me.DgvTrnIncassetdetil.DataSource = Me.tbl_TrnIncassetdetil

        Me.BindingContext(Me.tbl_TrnIncasset_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnIncasset_Temp).AddNew()
            Me.obj_Channel_id.SelectedValue = _CHANNEL
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function

    Private Function uiTrnIncomingAsset_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()

        If chkSearchStrukturUnit_id.Checked = True Then
            criteria = criteria & " and strukturunit_id = " & CStr(cboSearchStrukturunit_id.SelectedValue)
        End If

        If chkSearchIncasset_id.Checked = True Then
            criteria &= String.Format(" AND incasset_id = '{0}'", Me.ObjSearchIncasset_id.Text)
        End If

        If chkSearchOutasset_id.Checked = True Then
            criteria &= String.Format(" AND outasset_id = '{0}'", Me.ObjSearchOutasset_id.Text)
        End If

        If chkStatus.Checked = True Then
            If Me.cboStatus.SelectedItem = "INCOMPLETE" Then
                criteria &= " AND incasset_status = 'INCOMPLETE'"
            ElseIf Me.cboStatus.SelectedItem = "COMPLETE" Then
                criteria &= " AND incasset_status = 'COMPLETE'"
            Else
                MsgBox("Please choice item in status box")
                Exit Function
            End If

        End If


        Me.tbl_TrnIncasset.Clear()
        Try
            Me.DataFill(Me.tbl_TrnIncasset, "as_TrnIncasset_Select", criteria, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Private Function uiTrnIncomingAsset_Save() As Boolean
        'save data
        Dim tbl_TrnIncasset_Temp_Changes As DataTable
        Dim tbl_TrnIncassetdetil_Changes As DataTable
        Dim success As Boolean
        Dim incasset_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(incasset_id)

        Me.BindingContext(Me.tbl_TrnIncasset_Temp).EndCurrentEdit()
        tbl_TrnIncasset_Temp_Changes = Me.tbl_TrnIncasset_Temp.GetChanges()

        Me.DgvTrnIncassetdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnIncassetdetil).EndCurrentEdit()
        tbl_TrnIncassetdetil_Changes = Me.tbl_TrnIncassetdetil.GetChanges()

        If tbl_TrnIncasset_Temp_Changes IsNot Nothing Or tbl_TrnIncassetdetil_Changes IsNot Nothing Then
            Try
                MasterDataState = tbl_TrnIncasset_Temp.Rows(0).RowState
                incasset_id = tbl_TrnIncasset_Temp.Rows(0).Item("incasset_id")

                If tbl_TrnIncasset_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnIncomingAsset_SaveMaster(incasset_id, tbl_TrnIncasset_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnIncomingAsset_SaveMaster(tbl_TrnIncasset_Temp_Changes)")
                    Me.tbl_TrnIncasset_Temp.AcceptChanges()
                End If

                If tbl_TrnIncassetdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnIncassetdetil.Rows.Count - 1
                        If Me.tbl_TrnIncassetdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnIncassetdetil.Rows(i).Item("incasset_id") = incasset_id
                        End If
                    Next
                    success = Me.uiTrnIncomingAsset_SaveDetil(incasset_id, tbl_TrnIncassetdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnIncomingAsset_SaveDetil(tbl_TrnIncassetdetil_Changes)")
                    Me.tbl_TrnIncassetdetil.AcceptChanges()
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

        RaiseEvent FormAfterSave(incasset_id, result)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnIncomingAsset_SaveMaster(ByRef incasset_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: transaksi_incasset
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnIncasset_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 100, "strukturunit_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_id", System.Data.OleDb.OleDbType.VarWChar, 40, "incasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "outasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "bookasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_status", System.Data.OleDb.OleDbType.VarWChar, 30, "incasset_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_startdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters("@outasset_startdt").Value = Me.outAsset_startDt
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters("@outasset_enddt").Value = Me.outAsset_endDt
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_actreturn", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "incasset_actreturn"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_item", System.Data.OleDb.OleDbType.Integer, 4, "outasset_item"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_returnitem", System.Data.OleDb.OleDbType.Integer, 4, "incasset_returnitem"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_returnby", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_returnby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_returnby", System.Data.OleDb.OleDbType.VarWChar, 14, "strukturunit_id_returnby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username_inputby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inasset_remark", System.Data.OleDb.OleDbType.VarWChar, 300, "inasset_remark"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inasset_logistik", System.Data.OleDb.OleDbType.VarWChar, 30, "inasset_logistik"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inasset_lock", System.Data.OleDb.OleDbType.Boolean, 1, "inasset_lock"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_editby", System.Data.OleDb.OleDbType.VarWChar, 32, "incasset_editby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "incasset_editdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_usedby", System.Data.OleDb.OleDbType.VarWChar, 32, "incasset_usedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "incasset_useddt"))
        dbCmdInsert.Parameters("@username_inputby").Value = Me.UserName
        dbCmdInsert.Parameters("@incasset_inputdt").Value = Now


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnIncasset_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 100, "strukturunit_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_id", System.Data.OleDb.OleDbType.VarWChar, 40, "incasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "outasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "bookasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_status", System.Data.OleDb.OleDbType.VarWChar, 30, "incasset_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_startdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "outasset_startdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "outasset_enddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_actreturn", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "incasset_actreturn"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_item", System.Data.OleDb.OleDbType.Integer, 4, "outasset_item"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_returnitem", System.Data.OleDb.OleDbType.Integer, 4, "incasset_returnitem"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_returnby", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_returnby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_returnby", System.Data.OleDb.OleDbType.VarWChar, 14, "strukturunit_id_returnby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username_inputby", System.Data.OleDb.OleDbType.VarWChar, 32, "username_inputby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "incasset_inputdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inasset_remark", System.Data.OleDb.OleDbType.VarWChar, 300, "inasset_remark"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inasset_logistik", System.Data.OleDb.OleDbType.VarWChar, 30, "inasset_logistik"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inasset_lock", System.Data.OleDb.OleDbType.Boolean, 1, "inasset_lock"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_editby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_usedby", System.Data.OleDb.OleDbType.VarWChar, 32, "incasset_usedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "incasset_useddt"))
        dbCmdUpdate.Parameters("@incasset_editby").Value = Me.UserName
        dbCmdUpdate.Parameters("@incasset_editdt").Value = Now


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            incasset_id = objTbl.Rows(0).Item("incasset_id")
            Me.tbl_TrnIncasset_Temp.Clear()
            Me.tbl_TrnIncasset_Temp.Merge(objTbl)
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
            Me.tbl_TrnIncasset.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnIncasset).Position
            Me.tbl_TrnIncasset.Rows.RemoveAt(curpos)
            Me.tbl_TrnIncasset.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnIncasset).Position = Me.BindingContext(Me.tbl_TrnIncasset).Count

        Return True
    End Function

    Private Function uiTrnIncomingAsset_SaveDetil(ByRef incasset_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_incassetdetil
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnIncassetdetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_id", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Integer, 4, "is_useable"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 10, "asset_status"))
        dbCmdInsert.Parameters("@incasset_id").Value = incasset_id

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnIncassetdetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_id", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Integer, 4, "is_useable"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 10, "asset_status"))
        dbCmdUpdate.Parameters("@incasset_id").Value = incasset_id

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnIncassetdetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_id", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@line", System.Data.OleDb.OleDbType.Integer, 4, "line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty", System.Data.OleDb.OleDbType.Integer, 4, "qty"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Integer, 4, "is_useable"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 10, "asset_status"))
        dbCmdDelete.Parameters("@incasset_id").Value = incasset_id

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

    Private Function uiTrnIncomingAsset_Delete() As Boolean
        Dim res As String = ""
        Dim incasset_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(incasset_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnIncasset.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnIncomingAsset_DeleteRow(Me.DgvTrnIncasset.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(incasset_id)
        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnIncomingAsset_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim incasset_id As String
        Dim NewRowIndex As Integer

        incasset_id = Me.DgvTrnIncasset.Rows(rowIndex).Cells("incasset_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnIncasset_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdDelete.Parameters("@strukturunit_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_id", System.Data.OleDb.OleDbType.VarWChar, 40))
        dbCmdDelete.Parameters("@incasset_id").Value = incasset_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@outasset_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@bookasset_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_status", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@incasset_status").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_startdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@outasset_startdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@outasset_enddt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_actreturn", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@incasset_actreturn").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@outasset_item", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@outasset_item").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_returnitem", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@incasset_returnitem").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_returnby", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@employee_id_returnby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_returnby", System.Data.OleDb.OleDbType.VarWChar, 14))
        dbCmdDelete.Parameters("@strukturunit_id_returnby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username_inputby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdDelete.Parameters("@username_inputby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@incasset_inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@incasset_inputdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inasset_remark", System.Data.OleDb.OleDbType.VarWChar, 300))
        dbCmdDelete.Parameters("@inasset_remark").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inasset_logistik", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@inasset_logistik").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inasset_lock", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@inasset_lock").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnIncasset.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnIncomingAsset_OpenRow(NewRowIndex)
                    Me.tbl_TrnIncasset.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnIncasset.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnIncomingAsset_OpenRow(NewRowIndex)
                    Me.tbl_TrnIncasset.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnIncasset.Rows.RemoveAt(rowIndex)
                    Me.uiTrnIncomingAsset_OpenRow(rowIndex)
                End If
            Else
                Me.tbl_TrnIncasset_Temp.Clear()
                Me.tbl_TrnIncasset.Rows.RemoveAt(rowIndex)
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

    Private Function uiTrnIncomingAsset_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim incasset_id As String
        Dim channel_id As String

        incasset_id = Me.DgvTrnIncasset.Rows(rowIndex).Cells("incasset_id").Value
        channel_id = Me.DgvTrnIncasset.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(incasset_id)

        Try
            dbConn.Open()
            Me.uiTrnIncomingAsset_OpenRowMaster(channel_id, incasset_id, dbConn)
            Me.uiTrnIncomingAsset_OpenRowDetil(channel_id, incasset_id, dbConn)
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnIncomingAsset_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(incasset_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiTrnIncomingAsset_OpenRowMaster(ByVal channel_id As String, ByVal incasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnIncasset_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("and incasset_id='{0}'", incasset_id)
        dbCmd.Parameters.Add("@top", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@top").Value = Me.NumericUpDown1.Value
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnIncasset_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnIncasset_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnIncomingAsset_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnIncomingAsset_OpenRowDetil(ByVal channel_id As String, ByVal incasset_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnIncassetdetil_Select", dbConn)
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("incasset_id='{0}'", incasset_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnIncassetdetil.Clear()

        Me.tbl_TrnIncassetdetil = clsDataset.CreateTblTrnIncassetdetil()
        Me.tbl_TrnIncassetdetil.Columns("incasset_id").DefaultValue = incasset_id
        Me.tbl_TrnIncassetdetil.Columns("line").DefaultValue = DBNull.Value
        Me.tbl_TrnIncassetdetil.Columns("line").AutoIncrement = True
        Me.tbl_TrnIncassetdetil.Columns("line").AutoIncrementSeed = 10
        Me.tbl_TrnIncassetdetil.Columns("line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnIncassetdetil)
            Me.DgvTrnIncassetdetil.DataSource = Me.tbl_TrnIncassetdetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnIncomingAsset_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnIncomingAsset_First() As Boolean
        'goto first record found
        If Me.DgvTrnIncasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnIncomingAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnIncasset.CurrentCell = Me.DgvTrnIncasset(1, 0)
            Me.uiTrnIncomingAsset_RefreshPosition()
        End If
    End Function

    Private Function uiTrnIncomingAsset_Prev() As Boolean
        'goto previous record found
        If Me.DgvTrnIncasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnIncomingAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnIncasset.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnIncasset.CurrentCell = Me.DgvTrnIncasset(1, DgvTrnIncasset.CurrentCell.RowIndex - 1)
                Me.uiTrnIncomingAsset_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnIncomingAsset_Next() As Boolean
        'goto next record found
        If Me.DgvTrnIncasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnIncomingAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnIncasset.CurrentCell.RowIndex < Me.DgvTrnIncasset.Rows.Count - 1 Then
                Me.DgvTrnIncasset.CurrentCell = Me.DgvTrnIncasset(1, DgvTrnIncasset.CurrentCell.RowIndex + 1)
                Me.uiTrnIncomingAsset_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnIncomingAsset_Last() As Boolean
        'goto last record found
        If Me.DgvTrnIncasset.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnIncomingAsset_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnIncasset.CurrentCell = Me.DgvTrnIncasset(1, Me.DgvTrnIncasset.Rows.Count - 1)
            Me.uiTrnIncomingAsset_RefreshPosition()
        End If
    End Function

    Private Function uiTrnIncomingAsset_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnIncomingAsset_OpenRow(Me.DgvTrnIncasset.CurrentRow.Index)
    End Function

    Private Function uiTrnIncomingAsset_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnIncasset_Temp_Changes As DataTable
        Dim tbl_TrnIncassetdetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim success As Boolean
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim incasset_id As Object = New Object
        Dim move As Boolean = False
        Dim result As FormSaveResult

        If Me.DgvTrnIncasset.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnIncasset_Temp).EndCurrentEdit()
            tbl_TrnIncasset_Temp_Changes = Me.tbl_TrnIncasset_Temp.GetChanges()

            Me.DgvTrnIncassetdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnIncassetdetil).EndCurrentEdit()
            tbl_TrnIncassetdetil_Changes = Me.tbl_TrnIncassetdetil.GetChanges()

            If tbl_TrnIncasset_Temp_Changes IsNot Nothing Or tbl_TrnIncassetdetil_Changes IsNot Nothing Then

                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes

                        RaiseEvent FormBeforeSave(incasset_id)

                        Try

                            If tbl_TrnIncasset_Temp_Changes IsNot Nothing Then
                                success = Me.uiTrnIncomingAsset_SaveMaster(incasset_id, tbl_TrnIncasset_Temp_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Master Data")
                                Me.tbl_TrnIncasset_Temp.AcceptChanges()
                            End If

                            If tbl_TrnIncassetdetil_Changes IsNot Nothing Then
                                For i = 0 To Me.tbl_TrnIncassetdetil.Rows.Count - 1
                                    If Me.tbl_TrnIncassetdetil.Rows(i).RowState = DataRowState.Added Then
                                        Me.tbl_TrnIncassetdetil.Rows(i).Item("incasset_id") = incasset_id
                                    End If
                                Next
                                success = Me.uiTrnIncomingAsset_SaveDetil(incasset_id, tbl_TrnIncassetdetil_Changes, MasterDataState)
                                If Not success Then Throw New Exception("Cannot Save Detil Data")
                                Me.tbl_TrnIncassetdetil.AcceptChanges()
                            End If

                            result = FormSaveResult.SaveSuccess
                            If SHOW_SAVE_CONFIRMATION Then
                                MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Catch ex As Exception
                            result = FormSaveResult.SaveError
                            MessageBox.Show(ex.Message & vbCrLf & "Data Cannot Be Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                        RaiseEvent FormAfterSave(incasset_id, result)

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

    Private Function uiTrnIncomingAsset_FormError() As Boolean
        Try
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        Dim criteria As String = ""
        'TODO: - Extract Parameter
        '      - Assign parameter

        Me.DgvTrnIncasset.DataSource = Me.tbl_TrnIncasset

        objParameters = Me.GetParameterCollection(Me.Parameter)
        If Application.ProductName = _ProductName Then
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
            Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        End If

        'buat jebak pas jalan di browser
        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
        '    Dim dummyparameter As String = "CHANNEL=TTV;STRUKTUR_UNIT=5517;CHANNELCHANGED=0;CHANNELBROWSED=0;SU_EMPLOYEE=9002000;"
        '    objParameters = Me.GetParameterCollection(dummyparameter)
        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
        '    Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
        '    Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        'End If

        combodata = False

        Me.ComboFill(Me.cboSearchChannel, "channel_id", "channel_id", Me.tbl_MstChannelSearch, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'")
        Me.tbl_MstChannelSearch.DefaultView.Sort = "channel_id"
        Me.ComboFill(Me.cboSearchStrukturunit_id, "strukturunit_id", "strukturunit_name", Me.tbl_schStrukturUnit, "as_MstStrukturUnit_Select", "  ")
        Me.tbl_schStrukturUnit.DefaultView.Sort = "strukturunit_name"

        Me.cboSearchChannel.SelectedValue = Me._CHANNEL
        Me.chkSearchStrukturUnit_id.Checked = True
        Me.chkSearchStrukturUnit_id.Enabled = False
        Me.cboSearchStrukturunit_id.SelectedValue = _STRUKTUR_UNIT
        Me.obj_Strukturunit_id.Enabled = False

        Me.InitLayoutUI()
        Me.BindingStop()
        Me.BindingStart()

        Me.uiTrnIncomingAsset_NewData()

        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True

        Me.chkSearchChannel.Enabled = Me._CHANNEL_CANBE_CHANGED
        Me.cboSearchChannel.Enabled = Me._CHANNEL_CANBE_BROWSED
        Me.obj_Channel_id.Enabled = Me._CHANNEL_CANBE_BROWSED

        'Me.ftabDataDetil.SelectedIndex = 1
        'Me.ftabDataDetil.SelectedIndex = 0

        Me.chkSearchStrukturUnit_id.Checked = True
        Me.chkSearchChannel.Checked = True

        Dim myCI As New System.Globalization.CultureInfo("en-GB", False)
        Dim myCIclone As System.Globalization.CultureInfo = CType(myCI.Clone(), System.Globalization.CultureInfo)
        myCIclone.DateTimeFormat.AMDesignator = "a.m."
        myCIclone.DateTimeFormat.DateSeparator = "/"
        myCIclone.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        myCIclone.NumberFormat.CurrencySymbol = "$"
        myCIclone.NumberFormat.NumberDecimalDigits = 4
        System.Threading.Thread.CurrentThread.CurrentCulture = myCIclone
    End Sub


    Private Sub uiTrnIncomingAsset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.IsDevelopment = True Then
            Me.Form_Load(sender)
        End If
    End Sub
    Private Sub ftabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabMain.SelectedIndexChanged

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

                If Me.DgvTrnIncasset.CurrentRow IsNot Nothing Then
                    Me.uiTrnIncomingAsset_OpenRow(Me.DgvTrnIncasset.CurrentRow.Index)
                Else
                    Me.uiTrnIncomingAsset_NewData()
                End If

                If Me.obj_Inasset_lock.Checked = True Then
                    Me.Panel2.Enabled = False
                Else
                    Me.Panel2.Enabled = True
                End If

        End Select
    End Sub
    Private Sub DgvTrnIncasset_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnIncasset.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnIncasset.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub
    Private Function cek_data(ByVal param As String) As Boolean
        Dim criteria As String = param
        Dim tbl As New DataTable
        Dim tbl1 As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand

        Try
            dbConn.Open()
            dbCmdInsert = New OleDb.OleDbCommand("as_cekoutoing", dbConn)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20)
            dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL
            dbCmdInsert.Parameters.Add("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30)
            dbCmdInsert.Parameters("@outasset_id").Value = criteria
            dbCmdInsert.Parameters.Add("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5)
            dbCmdInsert.Parameters("@strukturunit_id").Value = Me._STRUKTUR_UNIT
            dbCmdInsert.Parameters.Add("@bookasset_id", System.Data.OleDb.OleDbType.VarWChar, 30).Direction = ParameterDirection.Output
            dbCmdInsert.Parameters.Add("@outasset_item", System.Data.OleDb.OleDbType.Integer).Direction = ParameterDirection.Output
            dbCmdInsert.Parameters.Add("@outasset_itemreturn", System.Data.OleDb.OleDbType.Integer).Direction = ParameterDirection.Output
            dbCmdInsert.Parameters.Add("@outasset_startdt", System.Data.OleDb.OleDbType.Date).Direction = ParameterDirection.Output
            dbCmdInsert.Parameters("@outasset_startdt").Value = Now
            dbCmdInsert.Parameters.Add("@outasset_enddt", System.Data.OleDb.OleDbType.Date).Direction = ParameterDirection.Output
            dbCmdInsert.Parameters("@outasset_enddt").Value = Now
            dbCmdInsert.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 2).Direction = ParameterDirection.Output
            dbCmdInsert.ExecuteNonQuery()

            status = CStr(dbCmdInsert.Parameters("@status").Value)
            If status = "N" Then
                MsgBox("OutGoing number not valid / Not register")
                Me.temps_conditions = "unregister"
                Exit Function
            Else
                Me.bookAsset_id = CStr(dbCmdInsert.Parameters("@bookasset_id").Value)
                Me.obj_Outasset_id.Text = param
                Me.outAsset_item = dbCmdInsert.Parameters("@outasset_item").Value
                Me.outasset_itemreturn = dbCmdInsert.Parameters("@outasset_itemreturn").Value

                Dim criterias As String = String.Format("and outasset_id = '{0}'", param)
                Me.tbl_TrnOutasset.Clear()
                Try
                    Me.DataFill(Me.tbl_TrnOutasset, "as_TrnOutasset_Select", criterias, Me.cboSearchChannel.SelectedValue, Me.NumericUpDown1.Value)
                    Me.outAsset_startDt = Me.tbl_TrnOutasset.Rows(0).Item("outasset_startdt") & " " & Me.tbl_TrnOutasset.Rows(0).Item("outasset_starttm") & ":00"
                    Me.outAsset_endDt = Me.tbl_TrnOutasset.Rows(0).Item("outasset_enddt") & " " & Me.tbl_TrnOutasset.Rows(0).Item("outasset_endtm") & ":00"
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar.ToString = Microsoft.VisualBasic.ChrW(13) Then
            If Trim(Me.obj_Incasset_id.Text) = "AUTO" Then
                MsgBox("Save Header Transaction First")
                Exit Sub
            End If

            If Len(Trim(Me.TextBox1.Text)) >= 2 Then
                Me.Cursor = Cursors.WaitCursor
                Me.uiTrnincasset_Saveke2()
                Me.Cursor = Cursors.Arrow
            Else
                MsgBox("Please Input Item", MsgBoxStyle.Information, "Warning")
                Me.TextBox1.Text = ""
                Me.TextBox1.Focus()
                Exit Sub
            End If
            Me.TextBox1.Text = "- - Item Incoming - -"
        End If
    End Sub
    Private Function uiTrnincasset_Saveke2() As Boolean

        Me.Cursor = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Try
            Dim dbCmdInsert As OleDb.OleDbCommand

            dbConn.Open()
            dbCmdInsert = New OleDb.OleDbCommand("as_TrnIncassetdetil_Insert", dbConn)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id").Value = Me._CHANNEL
            dbCmdInsert.Parameters.Add("@incasset_id", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me.obj_Incasset_id.Text
            dbCmdInsert.Parameters.Add("@outasset_id", System.Data.OleDb.OleDbType.VarWChar, 30, "outasset_id").Value = Me.obj_Outasset_id.Text
            dbCmdInsert.Parameters.Add("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode").Value = Trim(Me.TextBox1.Text)
            dbCmdInsert.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 2).Direction = ParameterDirection.Output
            dbCmdInsert.ExecuteNonQuery()
            status = CStr(dbCmdInsert.Parameters("@status").Value)
            'MsgBox(status)
            If status = "Y" Then
                suaramenang = PanggilSuara(Application.StartupPath & "\Sound\Ok.wav")
                'suaramenang = PanggilSuara("C:\TransBrowser\Sound\Ok.wav")
                MainkanSuara(suaramenang, SND_SYNC Or SND_MEMORY)
            Else
                suaramenang = PanggilSuara(Application.StartupPath & "\Sound\Error.wav")
                'suaramenang = PanggilSuara("C:\TransBrowser\Sound\Error.wav")
                MainkanSuara(suaramenang, SND_SYNC Or SND_MEMORY)
            End If
            dbCmdInsert.Dispose()
            Me.uiTrnIncomingAsset_OpenRow(Me.DgvTrnIncasset.CurrentRow.Index)
            'Me.uiTrnIncomingAsset_OpenRowMaster(Me._CHANNEL, Me.obj_Incasset_id.Text, dbConn)
            'Me.uiTrnIncomingAsset_OpenRowDetil(_CHANNEL, Me.obj_Incasset_id.Text, dbConn)

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        Me.Cursor = Cursors.Arrow
    End Function
    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()

        tbl_Print.Clear()
        tbl_PrintDetil.Clear()
        objPrintHeader = New DataSource.clsRptIncAsset(Me.DSN, Me.NumericUpDown1.Value)
        DataFill(tbl_Print, "as_TrnIncasset_Select", "and incasset_id = '" & DgvTrnIncasset.Item("incasset_id", DgvTrnIncasset.SelectedCells.Item(0).RowIndex).Value & "'", Me._CHANNEL, Me.NumericUpDown1.Value)
        With objPrintHeader
            .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id"), String.Empty)
            .strukturunit_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id"), String.Empty)
            .incasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("incasset_id"), String.Empty)
            .outasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_id"), String.Empty)
            .bookasset_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("bookasset_id"), String.Empty)
            .incasset_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("incasset_status"), String.Empty)
            .outasset_startdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_startdt"), String.Empty)
            .outasset_enddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_enddt"), String.Empty)
            .incasset_actreturn = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("incasset_actreturn"), String.Empty)
            .outasset_item = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("outasset_item"), 0)
            .incasset_returnitem = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("incasset_returnitem"), 0)
            .employee_id_returnby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_returnby"), String.Empty)
            .strukturunit_id_returnby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_returnby"), String.Empty)
            .username_inputby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("username_inputby"), String.Empty)
            .incasset_inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("incasset_inputdt"), String.Empty)
            .inasset_remark = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("inasset_remark"), String.Empty)
            .inasset_logistik = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("inasset_logistik"), String.Empty)
            .inasset_lock = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("inasset_lock"), 0)

            DataFill(tbl_PrintDetil, "as_TrnIncassetdetil_Select", "incasset_id = '" & .incasset_id & "'")

            Me.tempChannel_ID = .channel_id
            Me.tempChannel_nameReport = .channel_namereport
            Me.tempChannel_address = .channel_address
            Me.tempIncAssetID = .incasset_id
            Me.tempStrukturUnit = .Strukturunit_id_nameReport

            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function
    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptIncAssetDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptIncAssetDetil(Me.DSN)
            With objDetil
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id"), String.Empty)
                .incasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("incasset_id"), String.Empty)
                .line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("line"), 0)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcode"), String.Empty)
                .qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("qty"), 0)
                .is_useable = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("is_useable"), 0)
                .asset_status = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_status"), String.Empty)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub
    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptIncAssetDetil", objDatalistDetil))
    End Sub
    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        Dim stream As System.IO.Stream
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

        m_streams = New List(Of System.IO.Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
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
        Dim printdoc As New System.Drawing.Printing.PrintDocument()
        Dim printset As New System.Drawing.Printing.PrinterSettings()
        'Dim printername As String = printset.PrinterName
        Const printerName As String = "Microsoft Office Document Image Writer"

        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If
        printdoc.PrinterSettings.PrinterName = printerName
        If Not printdoc.PrinterSettings.IsValid Then
            Dim msg As String = String.Format("Can't find printer ""{0}"".", printerName)
            Console.WriteLine(msg)
            Return
        End If
        AddHandler printdoc.PrintPage, AddressOf PrintPage
        printdoc.Print()

    End Sub
    Private Function uiTrnIncomingAsset_Print() As Boolean
        If Me.DgvTrnIncasset.SelectedRows.Count <= 0 Then
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
        Dim parRptIncAssetID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("incAsset", Me.tempIncAssetID)
        Dim parRptStrukturUnit As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("strukturUnit", Me.tempStrukturUnit)


        objRdsH.Name = "ASSET_DataSource_clsRptIncAsset"
        objRdsH.Value = objDatalistHeader

        objReportH.ReportEmbeddedResource = "ASSET.RptIncAsset.rdlc"
        objReportH.DataSources.Add(objRdsH)
        objReportH.EnableExternalImages = True
        objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptUsername, parRptChannelID, parRptChannel_nameReport, parRptChannel_address, parRptIncAssetID, parRptStrukturUnit})

        AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
        Export(objReportH)

        m_currentPageIndex = 0
        Print()
        Me.uiTrnIncomingAsset_lockData()
    End Function
    Private Function uiTrnIncomingAsset_PrintPreview() As Boolean
        If Me.DgvTrnIncasset.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        Dim incasset_id As String
        incasset_id = DgvTrnIncasset.CurrentRow.Cells("incasset_id").Value

        Dim frmPrint As dlgRptIncAsset = New dlgRptIncAsset(Me.DSN, Me.SptServer, Me.UserName, Me._CHANNEL, incasset_id)
        Dim criteria As String = String.Empty

        frmPrint.ShowInTaskbar = False
        frmPrint.StartPosition = FormStartPosition.CenterParent

        criteria = " and incasset_id = '" & incasset_id & "'"

        frmPrint.SetIDCriteria(criteria)
        frmPrint.ShowDialog(Me)
    End Function
    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click

        If Me.DgvTrnIncasset.Rows(Me.DgvTrnIncasset.CurrentRow.Index).Cells("inasset_lock").Value = True Then
            MsgBox("Can't Update. Data has been lock")
            Exit Sub
        End If

        Me.str_IncAsset_id = Me.obj_Incasset_id.Text
        If Me.DgvTrnIncassetdetil.Rows.Count <= 0 Then
            Exit Sub
        End If

        line = Me.DgvTrnIncassetdetil.CurrentRow.Cells("line").Value

        Dim dlg As New UpdateIncDetil(Me.DSN, Me._CHANNEL, Me.str_IncAsset_id, line)

        qty = dlg.OpenDialog(Me)
        If qty Is Nothing Then
            Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
            Me.uiTrnIncomingAsset_OpenRowDetil(_CHANNEL, Me.obj_Incasset_id.Text, dbConn)
        End If
    End Sub
    Private Sub loadcombo()
        If Me.combodata = False Then
            Me.ComboFill(Me.obj_Channel_id, "channel_id", "channel_id", Me.tbl_MstChannel, "as_MstChannel_Select", " channel_id = '" & Me._CHANNEL & "'")
            Me.tbl_MstChannel.DefaultView.Sort = "channel_id"
            'Me.ComboFill(Me.obj_Employee_id_returnby, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitOwner, "as_MstStrukturUnit_Select", "  ")
            Me.ComboFill(Me.obj_Strukturunit_id_returnby, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitReturn, "ms_MstStrukturUnit_Select", "  ")
            Me.tbl_MstStrukturunitReturn.DefaultView.Sort = "strukturunit_name"
            Me.ComboFill(obj_Inasset_logistik, "employee_id", "employee_namalengkap", Me.tbl_MstEmployee, "ms_MstEmployee_Select", " strukturunit_id = " & Me._SU_EMPLOYEE)
            Me.tbl_MstEmployee.DefaultView.Sort = "employee_namalengkap"
            Me.ComboFill(obj_Employee_id_returnby, "employee_id", "employee_namalengkap", Me.tbl_MstEmployee_return, "ms_MstEmployee_Select", "  ")
            Me.tbl_MstEmployee_return.DefaultView.Sort = "employee_namalengkap"
            Me.ComboFill(Me.obj_Strukturunit_id, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitOwner, "ms_MstStrukturUnit_Select", "  ")
            Me.tbl_MstStrukturunitcustomer.DefaultView.Sort = "strukturunit_name"
            Me.combodata = True
        End If
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        Me.TextBox1.Text = "- - Item Incoming - -"
    End Sub
    Private Sub DgvTrnIncassetdetil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnIncassetdetil.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim click As DataGridView.HitTestInfo = Me.DgvTrnIncassetdetil.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnIncassetdetil.CurrentCell = Me.DgvTrnIncassetdetil.Rows(click.RowIndex).Cells(click.ColumnIndex)
            End If
        End If
    End Sub

    Private Sub uiTrnIncomingAsset_lockData()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_Locktransaksi_incasset", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@incasset_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnIncasset.Item("incasset_id", DgvTrnIncasset.CurrentRow.Index).Value

            oCm.ExecuteNonQuery()
            oCm.Dispose()
            Me.obj_Inasset_lock.Checked = True
            Me.DgvTrnIncasset.Item("inasset_lock", DgvTrnIncasset.CurrentRow.Index).Value = 1
            Me.Panel2.Enabled = False
            Me.DgvTrnIncassetdetil.ReadOnly = True
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

    Private Sub DgvTrnIncasset_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnIncasset.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

        Try
            If objrow.Cells("incasset_status").Value = "INCOMPLETE" Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            ElseIf objrow.Cells("incasset_status").Value = "COMPLETE" Then
                objrow.DefaultCellStyle.BackColor = Color.Bisque
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        If chkStatus.Checked = True Then
            Me.cboStatus.Enabled = True
            Me.cboStatus.SelectedItem = "-- PILIH --"
        Else
            Me.cboStatus.Enabled = False
        End If
    End Sub

    Private Sub chkSearchIncasset_id_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchIncasset_id.CheckedChanged
        If chkSearchIncasset_id.Checked = True Then
            Me.ObjSearchIncasset_id.Enabled = True
        Else
            Me.ObjSearchIncasset_id.Enabled = False
        End If
    End Sub

    Private Sub chkSearchOutasset_id_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSearchOutasset_id.CheckedChanged
        If Me.chkSearchOutasset_id.Checked = True Then
            Me.ObjSearchOutasset_id.Enabled = True
        Else
            Me.ObjSearchOutasset_id.Enabled = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class