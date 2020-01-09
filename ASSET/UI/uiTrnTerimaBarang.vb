Public Class uiTrnTerimaBarang
    Private Const mUiName As String = "Transaksi Terima Barang"
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

    Private tbl_TrnTerimabarang As DataTable = clsDataset.CreateTblTrnTerimabarang()
    Private tbl_TrnTerimabarang_Temp As DataTable = clsDataset.CreateTblTrnTerimabarang()
    Private tbl_TrnTerimabarang_TempStart As DataTable = clsDataset.CreateTblTrnTerimabarang
    Private tbl_TrnTerimabarangdetil As DataTable = clsDataset.CreateTblTrnTerimabarangdetil()
    '-----Begin Bikin Tabel untuk combo Data-------------------------
    Private tbl_MstChannel_channel_id As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstChannel_channel_id_asset As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstRekanan_rekanan_id As DataTable = clsDataset.CreateTblMstRekanan()
    Private tbl_MstStrukturunit_id As DataTable = clsDataset.CreateTblStrukturunitPemilik


    Private Tbl_Mstemployeepemilik As DataTable = clsDataset.CreateTblemployeepemilik
    '-----End Bikin Tabel untuk combo Data-------------------------
    '-----Mulai Bikin Tabel untuk combo Data Search-------------------------
    Private tbl_MstChannel_channel_id_search As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstRekanan_rekanan_id_search As DataTable = clsDataset.CreateTblMstRekanan()
    Private tbl_MstStrukturunit_id_search As DataTable = clsDataset.CreateTblStrukturunitPemilik

    Private Tbl_Mstemployeeowner As DataTable = clsDataset.CreateTblemployeepemilik
    Private tbl_MstStrukturunitAsset As DataTable = clsDataset.CreateTblStrukturunitPemilik
    Private tbl_MstTipeAsset As DataTable = clsDataset.CreateTblMstTipeasset
    Private tbl_mstKategoriAsset As DataTable = clsDataset.CreateTblMstKategoriasset
    Private tbl_mstKategoriitem As DataTable = clsDataset.CreateTblMstKategoriitem
    Private tbl_msttipeitem As DataTable = clsDataset.CreateTblMstTipeitem
    Private tbl_Mstsex As DataTable = clsDataset.CreateTblMstPilihan()
    Private tbl_Mstwarna As DataTable = clsDataset.CreateTblMstWarna
    Private tbl_Mstmaterial As DataTable = clsDataset.CreateTblMstMaterial
    Private tbl_MstCurrency As DataTable = clsDataset.CreateTblMstCurrency
    Private tbl_MstCurrency_header As DataTable = clsDataset.CreateTblMstCurrency
    Private tbl_Mstowner As DataTable = clsDataset.CreateTblemployeepemilik()
    Private tbl_brand As DataTable = clsDataset.CreateTblMstMerk
    Private tbl_unit As DataTable = clsDataset.CreateTblMstUnit
    Private tbl_ukuran As DataTable = clsDataset.CreateTblMstUkuran
    Private tbl_MstAssetruang As DataTable = clsDataset.CreateTblMstRuangAsset
    Private tbl_project As DataTable = clsDataset.CreateTblMstBudgetCombo
    Private tbl_show As DataTable = clsDataset.CreateTblMstShow
    Private tbl_showcont As DataTable = clsDataset.CreateTblMstShow

    Private tbl_retOrderDetil As DataTable = clsDataset.CreateTblTrnOrderdetil


    '----- End Bikin Tabel untuk Combo data detil---------------------------

    '-----Bikin Tabel untuk Jurnal-------------------------------
    Private tbl_TrnJurnal As DataTable = clsDataset.CreateTblTrnJurnal()
    Private tbl_TrnJurnaldetil As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_TrnJurnaldetil_JdwPembayaran As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_JurnalReference As DataTable = clsDataset.CreateTblTrnJurnalreference()

    Private tbl_MstAccD As DataTable = clsDataset.CreateTblMstAcc()
    Private tbl_MstAccK As DataTable = clsDataset.CreateTblMstAcc()
    Private tbl_MstRekananGrid As DataTable = clsDataset.CreateTblMstRekanan()
    Private tbl_MstCurrencyGrid As DataTable = clsDataset.CreateTblMstCurrency()

    '----- End Bikin Tabel untuk Jurnal---------------------------

    Private listBarcode As String
    Private orderdetil_line As String


    '--- ADDITIONAL BUTTON
    Friend WithEvents btnlock As ToolStripButton = New ToolStripButton
    Friend WithEvents btnbarcode As ToolStripButton = New ToolStripButton
    Friend WithEvents btnkain As ToolStripButton = New ToolStripButton
    Friend WithEvents btnHome As ToolStripButton = New ToolStripButton
    Friend WithEvents btnPicture As ToolStripButton = New ToolStripButton

    '--- TO DO PRINT
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnTerimabarang
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnTerimabarangdetil
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptBarang
    Private objDatalistDetil As ArrayList

    Private tbl_MstTrnOrder As DataTable = clsDataset.CreateTblTrnOrder()

    Private _LOADCOMBO As Boolean = False
    Private _LOADCOMBOSEARCH As Boolean = False
    Private _LoadComboInLoadData As Boolean = False

    Private sptChannel_ID As String
    Private sptChannel_nameReport As String
    Private sptChannel_address As String
    Private sptTerimaBarang_ID As String

    Private file_path As String
    Private shell_path As String

    Private motherTbl As DataTable = clsDataset.CreateTblTrnTerimabarangdetil()
    Private childTbl As DataTable = clsDataset.CreateTblTrnTerimabarangdetil

    Private retTbl_Terimabarang As DataTable = clsDataset.CreateTblTrnTerimabarang()

#Region " Window Parameter "
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    Private _STRUKTUR_UNIT As Decimal = "5560" '"5554"
    Private _PROCSU As String = "5554"
    Private _CANCHANGESU As Boolean = True
    Private _SU_EMPLOYEE As String = "9002000"

    Private _AC As Boolean = True
    Private _PC As Boolean = False
    Private _SP As Boolean = False
    Private _US As Boolean = False



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
        Dim newdata_terimabarang As dlgNewDataTerimaJasa = New dlgNewDataTerimaJasa(Me.DSN)

        newdata_terimabarang.ShowInTaskbar = False
        newdata_terimabarang.StartPosition = FormStartPosition.CenterParent
        newdata_terimabarang.ShowDialog(Me)

        If newdata_terimabarang.DialogResult = DialogResult.OK Then
            If newdata_terimabarang.obj_NewDataTerimaJasa.SelectedItem <> "-- Pilih --" Then
                If newdata_terimabarang.obj_NewDataTerimaJasa.SelectedItem = "Revision" Then
                    Dim chooseBpj As New dlgListBpj(Me.DSN, Me._CHANNEL, Me._STRUKTUR_UNIT, "BARANG")
                    Me.retTbl_Terimabarang = chooseBpj.OpenDialog(Me)
                    If retTbl_Terimabarang Is Nothing Then
                        MsgBox("You must choose one of row in goods received to revision")
                        Exit Function
                    Else
                        Me.Cursor = Cursors.WaitCursor
                        If Me.ftabMain.SelectedIndex = 0 Then
                            Me.ftabMain.SelectedIndex = 1
                        End If

                        Me.uiTrnTerimaBarang_NewData()
                        Me.Panel3.Enabled = True
                        Me.obj_Terimabarang_status.Enabled = True
                        Me.obj_Location.Text = "GEDUNG TRANSTV - TENDEAN JAKARTA"
                        Me.Btn_Add.Enabled = False
                        Me.btn_bonus.Enabled = False
                        Me.btn_DeleteItem.Enabled = False
                        Me.obj_Status.SelectedItem = "-- Pilih --"
                        Me.obj_Terimabarang_status.SelectedItem = "PO"
                        Me.obj_Terimabarang_status.Enabled = False
                        Me.obj_Status_kedatangan_barang.SelectedItem = "-- Pilih --"
                        Me.obj_Pa_ref.Text = Me.retTbl_Terimabarang.Rows(0).Item("terimabarang_id")
                        Me.DgvTrnTerimabarangdetil.AllowUserToAddRows = False 'True
                        Me.PnlDataMaster.Enabled = True
                        Me.DgvTrnTerimabarangdetil.Enabled = False
                        Me.obj_Terimabarang_id.Text = "AUTO"
                        Me.uiTrnTerimaBarang_LoadCombo()
                        Me.uiTrnTerimaBarang_LoadComboBox()
                        Me.uiTrnTerimaBarang_LoadComboSearch()
                        Me.obj_Employee_id_pemilik.Enabled = True
                        Me.obj_Status_kedatangan_barang.Enabled = True
                        Me.obj_Location.Enabled = True
                        Me.obj_Location.ReadOnly = False
                        Me.obj_terimabarang_noSuratJalan.ReadOnly = False
                        Me.obj_Notes.Enabled = True
                        Me.obj_Notes.ReadOnly = False
                        Me.select_nomor_PO()
                    End If
                ElseIf newdata_terimabarang.obj_NewDataTerimaJasa.SelectedItem = "New" Then
                    Me.Cursor = Cursors.WaitCursor
                    If Me.ftabMain.SelectedIndex = 0 Then
                        Me.ftabMain.SelectedIndex = 1
                    End If

                    Me.uiTrnTerimaBarang_NewData()
                    Me.Panel3.Enabled = True
                    Me.obj_Terimabarang_status.Enabled = True
                    Me.obj_Location.Text = "GEDUNG TRANSTV - TENDEAN JAKARTA"
                    Me.Btn_Add.Enabled = False
                    Me.btn_bonus.Enabled = False
                    Me.btn_DeleteItem.Enabled = False
                    Me.obj_Status.SelectedItem = "-- Pilih --"
                    Me.obj_Terimabarang_status.SelectedItem = "-- Pilih --"
                    Me.obj_Status_kedatangan_barang.SelectedItem = "-- Pilih --"
                    Me.DgvTrnTerimabarangdetil.AllowUserToAddRows = False 'True
                    Me.PnlDataMaster.Enabled = True
                    Me.DgvTrnTerimabarangdetil.Enabled = False
                    Me.obj_Terimabarang_id.Text = "AUTO"
                    Me.uiTrnTerimaBarang_LoadCombo()
                    Me.uiTrnTerimaBarang_LoadComboBox()
                    Me.uiTrnTerimaBarang_LoadComboSearch()
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Status_kedatangan_barang.Enabled = True
                    Me.obj_Location.Enabled = True
                    Me.obj_Location.ReadOnly = False
                    Me.obj_terimabarang_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.select_nomor_PO()
                End If
            Else
                If Me.ftabMain.SelectedIndex = 1 Then
                    Me.ftabMain.SelectedIndex = 0
                End If
            End If
        Else
            If Me.ftabMain.SelectedIndex = 1 Then
                Me.ftabMain.SelectedIndex = 0
            End If
        End If
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function
    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaBarang_Retrieve()
        Me.uiTrnTerimaBarang_LoadComboBox()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnTerimaBarang_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaBarang_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaBarang_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function
    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaBarang_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function
    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaBarang_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function
    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaBarang_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function
    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaBarang_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function
    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaBarang_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function
    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaBarang_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

#End Region

#Region " Additional Overrides "
    Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlock.Click
        If Me._SP = True And Me.obj_Terimabarang_appuser.Checked = False Then
            Me.lockUser()
        End If
        If Me._PC = True And Me.obj_Terimabarang_appuser.Checked = True And Me.obj_Terimabarang_appprc.Checked = False Then
            Me.LockPrcData()
            Exit Sub
        End If
        If Me._PC = True And Me._US = False And Me.obj_Terimabarang_appuser.Checked = False Then
            MsgBox("Need Spv Confirmation", MsgBoxStyle.Information)
            Exit Sub
        End If

        If Me._AC = True And Me.obj_Terimabarang_appacc.Checked = False And Me.obj_Terimabarang_appprc.Checked = True Then
            builtJurnal()
            LockData()
            Me.uiTrnTerimabarang_Acc_update_masterAsset(tbl_TrnTerimabarangdetil)
            'uiTrnTerimaBarang_ValidasiAsset(tbl_TrnTerimabarang.Rows(0).Item("terimabarang_id"), _CHANNEL)
            Exit Sub
        End If
        If Me._AC = True And Me._PC = False And Me.obj_Terimabarang_appprc.Checked = False Then
            MsgBox("Need Procurement Confirmation", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Private Sub btnbarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbarcode.Click
        LoadDetilbarcode()
    End Sub

    Private Sub btnkain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkain.Click
        LoadDetilbarcodekain()
    End Sub

    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        Me.Panel1.Visible = False
        Me.btnHome.Enabled = False
        Me.tbtnFirst.Enabled = True
        Me.tbtnPrev.Enabled = True
        Me.tbtnNext.Enabled = True
        Me.tbtnLast.Enabled = True

        If Me._SP Or Me._US Then

            Me.tbtnNew.Enabled = True
            Me.tbtnSave.Enabled = True
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True
            Me.tbtnDel.Enabled = True
            Me.btnPicture.Enabled = False
        ElseIf Me._AC = True Then
            Me.tbtnNew.Enabled = False
            Me.tbtnSave.Enabled = True
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True
            Me.tbtnDel.Enabled = False
            Me.btnPicture.Enabled = False
        Else
            Me.tbtnNew.Enabled = False
            Me.tbtnSave.Enabled = False
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True
            Me.tbtnDel.Enabled = False
            Me.btnPicture.Enabled = False

        End If

        Me.objFormError.Clear()
    End Sub

    Private Sub btnPicture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPicture.Click
        Dim rNamaFile As String
        rNamaFile = Me.obj_asset_terimabarang_id.Text & "-" & Me.obj_Asset_line.Text
        Dim dlg As dlg_addPicture = New dlg_addPicture(Me.DSN, rNamaFile)
        dlg.ShowInTaskbar = False
        dlg.StartPosition = FormStartPosition.CenterParent
        dlg.ShowDialog(Me)
    End Sub
#End Region

#Region " Layout & Init UI "

    Private Function FormatDgvTrnTerimabarang(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Try
            Dim colchannel_id As DataGridViewTextBoxColumn
            Dim colterimabarang_id As DataGridViewTextBoxColumn
            Dim colterimabarang_tgl As DataGridViewTextBoxColumn
            Dim colterimabarang_status As DataGridViewTextBoxColumn
            Dim colorder_id As DataGridViewTextBoxColumn
            Dim colpa_ref As DataGridViewTextBoxColumn
            Dim colrekanan_id As DataGridViewTextBoxColumn
            Dim colterimabarang_appacc As DataGridViewCheckBoxColumn
            Dim colemployee_id_pemilik As DataGridViewTextBoxColumn
            Dim colstrukturunit_id_pemilik As DataGridViewTextBoxColumn
            Dim colaccounting_applogin As DataGridViewTextBoxColumn
            Dim colaccounting_appdt As DataGridViewTextBoxColumn

            Dim colterimabarang_appprc As DataGridViewCheckBoxColumn


            Dim colprocurement_applogin As DataGridViewTextBoxColumn
            Dim colprocurement_appdt As DataGridViewTextBoxColumn
            Dim colterimabarang_cetakbpb As DataGridViewTextBoxColumn
            Dim colterimabarang_cetakbkb As DataGridViewTextBoxColumn
            Dim colterimabarang_item As DataGridViewTextBoxColumn
            Dim colinputby As DataGridViewTextBoxColumn
            Dim colinputdt As DataGridViewTextBoxColumn
            Dim coleditby As DataGridViewTextBoxColumn
            Dim coleditdt As DataGridViewTextBoxColumn
            Dim colusedby As DataGridViewTextBoxColumn
            Dim coluseddt As DataGridViewTextBoxColumn
            Dim colchannel_id_String As DataGridViewTextBoxColumn
            Dim colrekanan_id_String As DataGridViewTextBoxColumn
            Dim colstrukturunit_id_pemilik_string As DataGridViewTextBoxColumn

            Dim colterimabarang_appuser As DataGridViewCheckBoxColumn
            Dim colterimabarang_apploginuser As DataGridViewTextBoxColumn
            Dim colterimabarang_applogindt As DataGridViewTextBoxColumn

            Dim colqty_mother As DataGridViewTextBoxColumn
            Dim colstatus As DataGridViewTextBoxColumn
            Dim colqty_po As DataGridViewTextBoxColumn

            Dim colcurrency_id As DataGridViewTextBoxColumn
            Dim colasset_harga As DataGridViewTextBoxColumn
            Dim colasset_ppn As DataGridViewTextBoxColumn
            Dim colasset_pph As DataGridViewTextBoxColumn
            Dim colasset_disc As DataGridViewTextBoxColumn
            Dim colasset_valas As DataGridViewTextBoxColumn
            Dim colasset_idrprice As DataGridViewTextBoxColumn

            Dim colasset_insurance As DataGridViewTextBoxColumn
            Dim colasset_transport As DataGridViewTextBoxColumn
            Dim colasset_operator As DataGridViewTextBoxColumn
            Dim colasset_other As DataGridViewTextBoxColumn


            colchannel_id = clsUtil.CreateColumn("channel_id", "channel_id", "Channel", "TXT10", DataGridViewContentAlignment.MiddleLeft, True)

            colterimabarang_id = clsUtil.CreateColumn("terimabarang_id", "terimabarang_id", "Receive No.", "TXT17", DataGridViewContentAlignment.MiddleLeft, True)

            colterimabarang_tgl = clsUtil.CreateColumn("terimabarang_tgl", "terimabarang_tgl", "Receive Date", "TXT12", DataGridViewContentAlignment.MiddleLeft, True)
            colterimabarang_tgl.DefaultCellStyle.Format = "dd-MMM-yyyy"


            colterimabarang_status = clsUtil.CreateColumn("terimabarang_status", "terimabarang_status", "terimabarang_status", "TXT10", DataGridViewContentAlignment.MiddleLeft, True)

            colorder_id = clsUtil.CreateColumn("order_id", "order_id", "order_id", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)

            colpa_ref = clsUtil.CreateColumn("pa_ref", "pa_ref", "pa_ref", "TXT15", DataGridViewContentAlignment.MiddleLeft, True)

            colrekanan_id = clsUtil.CreateColumn("rekanan_id", "rekanan_id", "rekanan_id", "NUM5.0", DataGridViewContentAlignment.MiddleRight, True)
            colrekanan_id.DefaultCellStyle.Format = "###,##0.00"
            colterimabarang_appacc = clsUtil.CreateColumn("terimabarang_appacc", "terimabarang_appacc", "Act", 10)

            colemployee_id_pemilik = clsUtil.CreateColumn("employee_id_pemilik", "employee_id_pemilik", "employee_id_pemilik", "TXT15", DataGridViewContentAlignment.MiddleLeft, True)

            colstrukturunit_id_pemilik = clsUtil.CreateColumn("strukturunit_id_pemilik", "strukturunit_id_pemilik", "strukturunit_id_pemilik", "NUM6.0", DataGridViewContentAlignment.MiddleRight, True)
            colstrukturunit_id_pemilik.DefaultCellStyle.Format = "###,##0.00"
            colaccounting_applogin = clsUtil.CreateColumn("accounting_applogin", "accounting_applogin", "accounting_applogin", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)
            colaccounting_appdt = clsUtil.CreateColumn("accounting_appdt", "accounting_appdt", "accounting_appdt", "TXT4", DataGridViewContentAlignment.MiddleLeft, True)
            colterimabarang_appprc = clsUtil.CreateColumn("terimabarang_appprc", "terimabarang_appprc", "Proc", 15)
            colprocurement_applogin = clsUtil.CreateColumn("procurement_applogin", "procurement_applogin", "procurement_applogin", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)

            colprocurement_appdt = clsUtil.CreateColumn("procurement_appdt", "procurement_appdt", "procurement_appdt", "TXT4", DataGridViewContentAlignment.MiddleLeft, True)

            colterimabarang_cetakbpb = clsUtil.CreateColumn("terimabarang_cetakbpb", "terimabarang_cetakbpb", "terimabarang_cetakbpb", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, True)
            colterimabarang_cetakbpb.DefaultCellStyle.Format = "###,##0"
            colterimabarang_cetakbkb = clsUtil.CreateColumn("terimabarang_cetakbkb", "terimabarang_cetakbkb", "terimabarang_cetakbkb", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, True)
            colterimabarang_cetakbkb.DefaultCellStyle.Format = "###,##0"
            colterimabarang_item = clsUtil.CreateColumn("terimabarang_item", "terimabarang_item", "terimabarang_item", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, True)
            colterimabarang_item.DefaultCellStyle.Format = "###,##0"
            colinputby = clsUtil.CreateColumn("inputby", "inputby", "inputby", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)

            colinputdt = clsUtil.CreateColumn("inputdt", "inputdt", "inputdt", "TXT4", DataGridViewContentAlignment.MiddleLeft, True)

            coleditby = clsUtil.CreateColumn("editby", "editby", "editby", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)

            coleditdt = clsUtil.CreateColumn("editdt", "editdt", "editdt", "TXT4", DataGridViewContentAlignment.MiddleLeft, True)

            colusedby = clsUtil.CreateColumn("usedby", "usedby", "usedby", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)

            coluseddt = clsUtil.CreateColumn("useddt", "useddt", "useddt", "TXT4", DataGridViewContentAlignment.MiddleLeft, True)

            colchannel_id_String = clsUtil.CreateColumn("channel_id_String", "channel_id_String", "channel_id", "TXT20", DataGridViewContentAlignment.MiddleLeft)
            colrekanan_id_String = clsUtil.CreateColumn("rekanan_id_String", "rekanan_id_String", "Vendor", "TXT80", DataGridViewContentAlignment.MiddleLeft)

            colstrukturunit_id_pemilik_string = clsUtil.CreateColumn("strukturunit_id_pemilik_string", "strukturunit_id_pemilik_string", "Department", "TXT25", DataGridViewContentAlignment.MiddleLeft)

            colterimabarang_appuser = clsUtil.CreateColumn("terimabarang_appuser", "terimabarang_appuser", "Spv", 10)
            colterimabarang_apploginuser = clsUtil.CreateColumn("user_applogin", "user_applogin", "user_applogin", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)
            colterimabarang_applogindt = clsUtil.CreateColumn("user_appdt", "user_appdt", "user_appdt", "TXT4", DataGridViewContentAlignment.MiddleLeft, True)

            colqty_mother = clsUtil.CreateColumn("qty_mother", "qty_mother", "Qty Mother", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, True)
            colqty_mother.DefaultCellStyle.Format = "###,##0"

            colstatus = clsUtil.CreateColumn("status", "status", "Status", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)

            colqty_po = clsUtil.CreateColumn("qty_po", "qty_po", "Qty PO", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, True)
            colqty_po.DefaultCellStyle.Format = "###,##0"

            colcurrency_id = clsUtil.CreateColumn("currency_id", "currency_id", "currency_id", "NUM5.0", DataGridViewContentAlignment.MiddleRight, False)
            colcurrency_id.DefaultCellStyle.Format = "###,##0.00"
            colasset_harga = clsUtil.CreateColumn("asset_harga", "asset_harga", "asset_harga", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_harga.DefaultCellStyle.Format = "###,##0.00"
            colasset_ppn = clsUtil.CreateColumn("asset_ppn", "asset_ppn", "asset_ppn", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_ppn.DefaultCellStyle.Format = "###,##0.00"
            colasset_pph = clsUtil.CreateColumn("asset_pph", "asset_pph", "asset_pph", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_pph.DefaultCellStyle.Format = "###,##0.00"
            colasset_disc = clsUtil.CreateColumn("asset_disc", "asset_disc", "asset_disc", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_disc.DefaultCellStyle.Format = "###,##0.00"
            colasset_valas = clsUtil.CreateColumn("asset_valas", "asset_valas", "asset_valas", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_valas.DefaultCellStyle.Format = "###,##0.00"
            colasset_idrprice = clsUtil.CreateColumn("asset_idrprice", "asset_idrprice", "asset_idrprice", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_idrprice.DefaultCellStyle.Format = "###,##0.00"

            colasset_insurance = clsUtil.CreateColumn("order_insurancecost", "order_insurancecost", "order_insurancecost", "NUM18.2", DataGridViewContentAlignment.MiddleRight, False)
            colasset_insurance.DefaultCellStyle.Format = "###,##0.00"
            colasset_transport = clsUtil.CreateColumn("order_transportationcost", "order_transportationcost", "order_transportationcost", "NUM18.2", DataGridViewContentAlignment.MiddleRight, False)
            colasset_transport.DefaultCellStyle.Format = "###,##0.00"
            colasset_operator = clsUtil.CreateColumn("order_operatorcost", "order_operatorcost", "order_operatorcost", "NUM18.2", DataGridViewContentAlignment.MiddleRight, False)
            colasset_operator.DefaultCellStyle.Format = "###,##0.00"
            colasset_other = clsUtil.CreateColumn("order_othercost", "order_othercost", "order_othercost", "NUM18.2", DataGridViewContentAlignment.MiddleRight, False)
            colasset_other.DefaultCellStyle.Format = "###,##0.00"


            objDgv.Columns.Clear()
            objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
            {colterimabarang_appuser, colterimabarang_appprc, colterimabarang_appacc, colterimabarang_id, colterimabarang_tgl, colstrukturunit_id_pemilik_string, colrekanan_id_String, colqty_mother, colstatus, colqty_po, colorder_id, colchannel_id})
            '{colchannel_id, colterimabarang_id, colterimabarang_tgl, colterimabarang_status, colorder_id, colpa_ref, colrekanan_id, , colemployee_id_pemilik, colstrukturunit_id_pemilik, colaccounting_applogin, colaccounting_appdt, , colprocurement_applogin, colprocurement_appdt, colterimabarang_cetakbpb, colterimabarang_cetakbkb, colterimabarang_item, colinputby, colinputdt, coleditby, coleditdt, colusedby, coluseddt, colchannel_id_String, , colstrukturunit_id_pemilik_string})
            objDgv.AllowUserToAddRows = False
            objDgv.AllowUserToDeleteRows = False
            objDgv.AllowUserToResizeRows = True
            objDgv.ReadOnly = True
            objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            objDgv.AutoGenerateColumns = False
        Catch ex As Exception
            MsgBox("Error on formating datagridview")
        Finally
        End Try
    End Function
    Private Function FormatDgvTrnTerimabarangdetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Try
            Dim cTerimaBarangdetil_button As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
            ' Dim cTerimaBarangdetil_buttonAdd As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn

            Dim colterimabarang_id As DataGridViewTextBoxColumn
            Dim colasset_line As DataGridViewTextBoxColumn
            Dim colchannel_id As DataGridViewTextBoxColumn
            Dim colasset_tgl As DataGridViewTextBoxColumn
            Dim coltipeasset_id As DataGridViewTextBoxColumn
            Dim colkategoriasset_id As DataGridViewTextBoxColumn
            Dim colasset_barcode As DataGridViewTextBoxColumn
            Dim colasset_lineinduk As DataGridViewTextBoxColumn
            Dim colasset_barcodeinduk As DataGridViewTextBoxColumn
            Dim colasset_serial As DataGridViewTextBoxColumn
            Dim colasset_produknumber As DataGridViewTextBoxColumn
            Dim colasset_model As DataGridViewTextBoxColumn
            Dim colasset_deskripsi As DataGridViewTextBoxColumn
            Dim colkategoriitem_id As DataGridViewTextBoxColumn
            Dim coltipeitem_id As DataGridViewTextBoxColumn
            Dim colasset_golfiskal As DataGridViewTextBoxColumn
            Dim colasset_tipedepre As DataGridViewTextBoxColumn
            Dim colcurrency_id As DataGridViewTextBoxColumn
            Dim colasset_harga As DataGridViewTextBoxColumn
            Dim colasset_hargabaru As DataGridViewTextBoxColumn
            Dim colasset_ppn As DataGridViewTextBoxColumn
            Dim colasset_pph As DataGridViewTextBoxColumn
            Dim colasset_disc As DataGridViewTextBoxColumn
            Dim colasset_depresiasi As DataGridViewTextBoxColumn
            Dim colasset_akum_val_depre As DataGridViewTextBoxColumn
            Dim colasset_valas As DataGridViewTextBoxColumn
            Dim colasset_idrprice As DataGridViewTextBoxColumn
            Dim colstrukturunit_id As DataGridViewTextBoxColumn
            Dim colemployee_id_owner As DataGridViewTextBoxColumn
            Dim colbrand_id As DataGridViewTextBoxColumn
            Dim colunit_id As DataGridViewTextBoxColumn
            Dim colasset_qty As DataGridViewTextBoxColumn
            Dim colmaterial_id As DataGridViewTextBoxColumn
            Dim colwarna_id As DataGridViewTextBoxColumn
            Dim colukuran_id As DataGridViewTextBoxColumn
            Dim coljeniskelamin_id As DataGridViewTextBoxColumn
            Dim colshow_id_cont_item As DataGridViewTextBoxColumn
            Dim colruang_id As DataGridViewTextBoxColumn
            Dim colasset_rak As DataGridViewTextBoxColumn
            Dim colis_useable As DataGridViewCheckBoxColumn
            Dim colasset_active As DataGridViewCheckBoxColumn
            Dim colasset_status As DataGridViewTextBoxColumn
            Dim colproject_id As DataGridViewTextBoxColumn
            Dim colshow_id As DataGridViewTextBoxColumn
            Dim colasset_eps As DataGridViewTextBoxColumn
            Dim colwo_id As DataGridViewTextBoxColumn
            Dim colinputby As DataGridViewTextBoxColumn
            Dim colinputdt As DataGridViewTextBoxColumn
            Dim coleditby As DataGridViewTextBoxColumn
            Dim coleditdt As DataGridViewTextBoxColumn
            Dim colusedby As DataGridViewTextBoxColumn
            Dim colorder_id As DataGridViewTextBoxColumn
            Dim colorderdetil_line As DataGridViewTextBoxColumn
            Dim colstatus_po As DataGridViewTextBoxColumn

            colterimabarang_id = clsUtil.CreateColumn("terimabarang_id", "terimabarang_id", "ID", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)

            colasset_line = clsUtil.CreateColumn("asset_line", "asset_line", "Line", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, False)
            colasset_line.DefaultCellStyle.Format = "###,##0"
            colchannel_id = clsUtil.CreateColumn("channel_id", "channel_id", "Channel", "TXT10", DataGridViewContentAlignment.MiddleLeft, True)

            colasset_tgl = clsUtil.CreateColumn("asset_tgl", "asset_tgl", "asset_tgl", "TXT4", DataGridViewContentAlignment.MiddleLeft, False)

            coltipeasset_id = clsUtil.CreateColumn("tipeasset_id", "tipeasset_id", "tipeasset_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colkategoriasset_id = clsUtil.CreateColumn("kategoriasset_id", "kategoriasset_id", "kategoriasset_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_barcode = clsUtil.CreateColumn("asset_barcode", "asset_barcode", "Barcode", "TXT20", DataGridViewContentAlignment.MiddleLeft, True)

            colasset_lineinduk = clsUtil.CreateColumn("asset_lineinduk", "asset_lineinduk", "Line Mother", "NUM12.0", DataGridViewContentAlignment.MiddleCenter, True)
            colasset_lineinduk.DefaultCellStyle.Format = "###,##0"
            colasset_barcodeinduk = clsUtil.CreateColumn("asset_barcodeinduk", "asset_barcodeinduk", "asset_barcodeinduk", "TXT20", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_serial = clsUtil.CreateColumn("asset_serial", "asset_serial", "asset_serial", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_produknumber = clsUtil.CreateColumn("asset_produknumber", "asset_produknumber", "asset_produknumber", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_model = clsUtil.CreateColumn("asset_model", "asset_model", "asset_model", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_deskripsi = clsUtil.CreateColumn("asset_deskripsi", "asset_deskripsi", "Deskripsi", "TXT90", DataGridViewContentAlignment.MiddleLeft, False)

            colkategoriitem_id = clsUtil.CreateColumn("kategoriitem_id", "kategoriitem_id", "kategoriitem_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            coltipeitem_id = clsUtil.CreateColumn("tipeitem_id", "tipeitem_id", "tipeitem_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_golfiskal = clsUtil.CreateColumn("asset_golfiskal", "asset_golfiskal", "asset_golfiskal", "TXT10", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_tipedepre = clsUtil.CreateColumn("asset_tipedepre", "asset_tipedepre", "asset_tipedepre", "TXT1", DataGridViewContentAlignment.MiddleLeft, False)

            colcurrency_id = clsUtil.CreateColumn("currency_id", "currency_id", "currency_id", "NUM5.0", DataGridViewContentAlignment.MiddleRight, False)
            colcurrency_id.DefaultCellStyle.Format = "###,##0.00"
            colasset_harga = clsUtil.CreateColumn("asset_harga", "asset_harga", "asset_harga", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_harga.DefaultCellStyle.Format = "###,##0.00"
            colasset_hargabaru = clsUtil.CreateColumn("asset_hargabaru", "asset_hargabaru", "asset_hargabaru", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_hargabaru.DefaultCellStyle.Format = "###,##0.00"
            colasset_ppn = clsUtil.CreateColumn("asset_ppn", "asset_ppn", "asset_ppn", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_ppn.DefaultCellStyle.Format = "###,##0.00"
            colasset_pph = clsUtil.CreateColumn("asset_pph", "asset_pph", "asset_pph", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_pph.DefaultCellStyle.Format = "###,##0.00"
            colasset_disc = clsUtil.CreateColumn("asset_disc", "asset_disc", "asset_disc", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_disc.DefaultCellStyle.Format = "###,##0.00"
            colasset_depresiasi = clsUtil.CreateColumn("asset_depresiasi", "asset_depresiasi", "asset_depresiasi", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, False)
            colasset_depresiasi.DefaultCellStyle.Format = "###,##0"
            colasset_akum_val_depre = clsUtil.CreateColumn("asset_akum_val_depre", "asset_akum_val_depre", "asset_akum_val_depre", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_akum_val_depre.DefaultCellStyle.Format = "###,##0.00"
            colasset_valas = clsUtil.CreateColumn("asset_valas", "asset_valas", "asset_valas", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_valas.DefaultCellStyle.Format = "###,##0.00"
            colasset_idrprice = clsUtil.CreateColumn("asset_idrprice", "asset_idrprice", "asset_idrprice", "NUM18.3", DataGridViewContentAlignment.MiddleRight, False)
            colasset_idrprice.DefaultCellStyle.Format = "###,##0.00"
            colstrukturunit_id = clsUtil.CreateColumn("strukturunit_id", "strukturunit_id", "strukturunit_id", "NUM6.0", DataGridViewContentAlignment.MiddleRight, False)
            colstrukturunit_id.DefaultCellStyle.Format = "###,##0.00"
            colemployee_id_owner = clsUtil.CreateColumn("employee_id_owner", "employee_id_owner", "employee_id_owner", "TXT15", DataGridViewContentAlignment.MiddleLeft, False)

            colbrand_id = clsUtil.CreateColumn("brand_id", "brand_id", "brand_id", "NUM5.0", DataGridViewContentAlignment.MiddleRight, False)
            colbrand_id.DefaultCellStyle.Format = "###,##0.00"
            colunit_id = clsUtil.CreateColumn("unit_id", "unit_id", "unit_id", "NUM5.0", DataGridViewContentAlignment.MiddleRight, False)
            colunit_id.DefaultCellStyle.Format = "###,##0.00"
            colasset_qty = clsUtil.CreateColumn("asset_qty", "asset_qty", "Qty", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, False)
            colasset_qty.DefaultCellStyle.Format = "###,##0"
            colmaterial_id = clsUtil.CreateColumn("material_id", "material_id", "material_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colwarna_id = clsUtil.CreateColumn("warna_id", "warna_id", "warna_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colukuran_id = clsUtil.CreateColumn("ukuran_id", "ukuran_id", "ukuran_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            coljeniskelamin_id = clsUtil.CreateColumn("jeniskelamin_id", "jeniskelamin_id", "jeniskelamin_id", "TXT10", DataGridViewContentAlignment.MiddleLeft, False)

            colshow_id_cont_item = clsUtil.CreateColumn("show_id_cont_item", "show_id_cont_item", "show_id_cont_item", "TXT12", DataGridViewContentAlignment.MiddleLeft, False)

            colruang_id = clsUtil.CreateColumn("ruang_id", "ruang_id", "ruang_id", "TXT10", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_rak = clsUtil.CreateColumn("asset_rak", "asset_rak", "asset_rak", "TXT20", DataGridViewContentAlignment.MiddleLeft, False)

            colis_useable = clsUtil.CreateColumn("is_useable", "is_useable", "is_useable", 10)

            colasset_active = clsUtil.CreateColumn("asset_active", "asset_active", "asset_active", 10)

            colasset_status = clsUtil.CreateColumn("asset_status", "asset_status", "asset_status", "TXT10", DataGridViewContentAlignment.MiddleLeft, False)

            colproject_id = clsUtil.CreateColumn("project_id", "project_id", "project_id", "NUM5.0", DataGridViewContentAlignment.MiddleRight, False)
            colproject_id.DefaultCellStyle.Format = "###,##0.00"
            colshow_id = clsUtil.CreateColumn("show_id", "show_id", "show_id", "TXT12", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_eps = clsUtil.CreateColumn("asset_eps", "asset_eps", "asset_eps", "TXT10", DataGridViewContentAlignment.MiddleLeft, False)

            colwo_id = clsUtil.CreateColumn("wo_id", "wo_id", "wo_id", "TXT15", DataGridViewContentAlignment.MiddleLeft, False)

            colinputby = clsUtil.CreateColumn("inputby", "inputby", "inputby", "TXT50", DataGridViewContentAlignment.MiddleLeft, False)

            colinputdt = clsUtil.CreateColumn("inputdt", "inputdt", "inputdt", "TXT4", DataGridViewContentAlignment.MiddleLeft, False)

            coleditby = clsUtil.CreateColumn("editby", "editby", "editby", "TXT50", DataGridViewContentAlignment.MiddleLeft, False)

            coleditdt = clsUtil.CreateColumn("editdt", "editdt", "editdt", "TXT4", DataGridViewContentAlignment.MiddleLeft, False)

            colusedby = clsUtil.CreateColumn("usedby", "usedby", "usedby", "TXT50", DataGridViewContentAlignment.MiddleLeft, False)
            colorder_id = clsUtil.CreateColumn("order_id", "order_id", "Order No.", "TXT20", DataGridViewContentAlignment.MiddleCenter, True)
            colorderdetil_line = clsUtil.CreateColumn("orderdetil_line", "orderdetil_line", "Order Line", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, True)
            colstatus_po = clsUtil.CreateColumn("status_po", "status_po", "Status", "TXT15", DataGridViewContentAlignment.MiddleCenter, True)

            cTerimaBarangdetil_button.Text = "..."
            cTerimaBarangdetil_button.Name = "asset_button"
            cTerimaBarangdetil_button.HeaderText = "List"
            cTerimaBarangdetil_button.UseColumnTextForButtonValue = True
            cTerimaBarangdetil_button.CellTemplate.Style.BackColor = Color.Gainsboro
            cTerimaBarangdetil_button.Width = 30
            cTerimaBarangdetil_button.DividerWidth = 3

            'cTerimaBarangdetil_buttonAdd.Text = "..."
            'cTerimaBarangdetil_buttonAdd.Name = "asset_button_add"
            'cTerimaBarangdetil_buttonAdd.HeaderText = "Add"
            'cTerimaBarangdetil_buttonAdd.UseColumnTextForButtonValue = True
            'cTerimaBarangdetil_buttonAdd.CellTemplate.Style.BackColor = Color.Gainsboro
            'cTerimaBarangdetil_buttonAdd.Width = 35
            'cTerimaBarangdetil_buttonAdd.DividerWidth = 3
            'cOrderdetil_daysbutton.FlatStyle = FlatStyle.Flat

            objDgv.Columns.Clear()
            objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
            {cTerimaBarangdetil_button, colasset_qty, colasset_barcode, colasset_lineinduk, colasset_deskripsi, colstatus_po, colterimabarang_id, colorderdetil_line, colorder_id, colasset_line})

            'cTerimaBarangdetil_button
            '{colterimabarang_id, colasset_line, colchannel_id, colasset_tgl, coltipeasset_id, colkategoriasset_id, colasset_barcode, colasset_lineinduk, colasset_barcodeinduk, colasset_serial, colasset_produknumber, colasset_model, colasset_deskripsi, colkategoriitem_id, coltipeitem_id, colasset_golfiskal, colasset_tipedepre, colcurrency_id, colasset_harga, colasset_hargabaru, colasset_ppn, colasset_pph, colasset_disc, colasset_depresiasi, colasset_akum_val_depre, colasset_valas, colasset_idrprice, colstrukturunit_id, colemployee_id_owner, colbrand_id, colunit_id, colasset_qty, colmaterial_id, colwarna_id, colukuran_id, coljeniskelamin_id, colshow_id_cont_item, colruang_id, colasset_rak, colis_useable, colasset_active, colasset_status, colproject_id, colshow_id, colasset_eps, colwo_id, colinputby, colinputdt, coleditby, coleditdt, colusedby})
            objDgv.AllowUserToAddRows = False 'True
            objDgv.AllowUserToDeleteRows = False 'True
            objDgv.AllowUserToResizeRows = True
            objDgv.ReadOnly = False
            objDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            objDgv.AutoGenerateColumns = False
        Catch ex As Exception
            MsgBox("Error on formating datagridview")
        Finally
        End Try
    End Function

#Region "Untuk Jurnal"
    Private Function FormatDgvTrnJurnaldetil(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_dk As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_descr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_idr As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_foreign As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_foreignrate As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRef_line As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cCurrency_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cAcc_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cChannel_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRegion_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cBranch_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cStrukturunit_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cRekanan_id As System.Windows.Forms.DataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        Dim cSub1_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cSub2_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnaldetil_type As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "jurnal_id"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_id.Visible = False
        cJurnal_id.ReadOnly = False

        cJurnaldetil_line.Name = "jurnaldetil_line"
        cJurnaldetil_line.HeaderText = "Line"
        cJurnaldetil_line.DataPropertyName = "jurnaldetil_line"
        cJurnaldetil_line.Width = 50
        cJurnaldetil_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnaldetil_line.Visible = True
        cJurnaldetil_line.ReadOnly = False

        cJurnaldetil_dk.Name = "jurnaldetil_dk"
        cJurnaldetil_dk.HeaderText = "jurnaldetil_dk"
        cJurnaldetil_dk.DataPropertyName = "jurnaldetil_dk"
        cJurnaldetil_dk.Width = 100
        cJurnaldetil_dk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnaldetil_dk.Visible = False
        cJurnaldetil_dk.ReadOnly = False

        cJurnaldetil_descr.Name = "jurnaldetil_descr"
        cJurnaldetil_descr.HeaderText = "Description"
        cJurnaldetil_descr.DataPropertyName = "jurnaldetil_descr"
        cJurnaldetil_descr.Width = 100
        cJurnaldetil_descr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnaldetil_descr.Visible = True
        cJurnaldetil_descr.ReadOnly = False

        cJurnaldetil_idr.Name = "jurnaldetil_idr"
        cJurnaldetil_idr.HeaderText = "Amount IDR"
        cJurnaldetil_idr.DataPropertyName = "jurnaldetil_idr"
        cJurnaldetil_idr.Width = 120
        cJurnaldetil_idr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        cJurnaldetil_idr.Visible = True
        cJurnaldetil_idr.ReadOnly = False
        cJurnaldetil_idr.DefaultCellStyle.Format = "#,##0"

        cJurnaldetil_foreign.Name = "jurnaldetil_foreign"
        cJurnaldetil_foreign.HeaderText = "Foreign"
        cJurnaldetil_foreign.DataPropertyName = "jurnaldetil_foreign"
        cJurnaldetil_foreign.Width = 100
        cJurnaldetil_foreign.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnaldetil_foreign.Visible = True
        cJurnaldetil_foreign.ReadOnly = False
        cJurnaldetil_foreign.DefaultCellStyle.Format = "#,##0"

        cJurnaldetil_foreignrate.Name = "jurnaldetil_foreignrate"
        cJurnaldetil_foreignrate.HeaderText = "Rate"
        cJurnaldetil_foreignrate.DataPropertyName = "jurnaldetil_foreignrate"
        cJurnaldetil_foreignrate.Width = 50
        cJurnaldetil_foreignrate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnaldetil_foreignrate.Visible = True
        cJurnaldetil_foreignrate.ReadOnly = False

        cRef_id.Name = "ref_id"
        cRef_id.HeaderText = "ref_id"
        cRef_id.DataPropertyName = "ref_id"
        cRef_id.Width = 100
        cRef_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRef_id.Visible = True
        cRef_id.ReadOnly = False

        cRef_line.Name = "ref_line"
        cRef_line.HeaderText = "ref_line"
        cRef_line.DataPropertyName = "ref_line"
        cRef_line.Width = 100
        cRef_line.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRef_line.Visible = True
        cRef_line.ReadOnly = False

        cCurrency_id.Name = "currency_id"
        cCurrency_id.HeaderText = "Curr."
        cCurrency_id.DataPropertyName = "currency_id"
        cCurrency_id.Width = 100
        cCurrency_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cCurrency_id.Visible = True
        cCurrency_id.ReadOnly = False
        cCurrency_id.DisplayMember = "currency_shortname"
        cCurrency_id.ValueMember = "currency_id"
        cCurrency_id.DataSource = Me.tbl_MstCurrencyGrid

        cAcc_id.Name = "acc_id"
        cAcc_id.HeaderText = "Account"
        cAcc_id.DataPropertyName = "acc_id"
        cAcc_id.Width = 100
        cAcc_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cAcc_id.Visible = True
        cAcc_id.ReadOnly = False
        cAcc_id.DisplayMember = "acc_nameshort"
        cAcc_id.ValueMember = "acc_id"
        cAcc_id.DataSource = Me.tbl_MstAccD

        cChannel_id.Name = "channel_id"
        cChannel_id.HeaderText = "Channel"
        cChannel_id.DataPropertyName = "channel_id"
        cChannel_id.Width = 100
        cChannel_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cChannel_id.Visible = False
        cChannel_id.ReadOnly = False

        cRegion_id.Name = "region_id"
        cRegion_id.HeaderText = "region_id"
        cRegion_id.DataPropertyName = "region_id"
        cRegion_id.Width = 100
        cRegion_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRegion_id.Visible = False
        cRegion_id.ReadOnly = False

        cBranch_id.Name = "branch_id"
        cBranch_id.HeaderText = "branch_id"
        cBranch_id.DataPropertyName = "branch_id"
        cBranch_id.Width = 100
        cBranch_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cBranch_id.Visible = False
        cBranch_id.ReadOnly = False

        cStrukturunit_id.Name = "strukturunit_id"
        cStrukturunit_id.HeaderText = "strukturunit_id"
        cStrukturunit_id.DataPropertyName = "strukturunit_id"
        cStrukturunit_id.Width = 100
        cStrukturunit_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cStrukturunit_id.Visible = False
        cStrukturunit_id.ReadOnly = False

        cRekanan_id.Name = "rekanan_id"
        cRekanan_id.HeaderText = "Rekanan"
        cRekanan_id.DataPropertyName = "rekanan_id"
        cRekanan_id.Width = 100
        cRekanan_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cRekanan_id.Visible = True
        cRekanan_id.ReadOnly = False
        cRekanan_id.DisplayMember = "rekanan_name"
        cRekanan_id.ValueMember = "rekanan_id"
        cRekanan_id.DataSource = Me.tbl_MstRekananGrid

        cSub1_id.Name = "sub1_id"
        cSub1_id.HeaderText = "sub1_id"
        cSub1_id.DataPropertyName = "sub1_id"
        cSub1_id.Width = 100
        cSub1_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSub1_id.Visible = False
        cSub1_id.ReadOnly = False

        cSub2_id.Name = "sub2_id"
        cSub2_id.HeaderText = "sub2_id"
        cSub2_id.DataPropertyName = "sub2_id"
        cSub2_id.Width = 100
        cSub2_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cSub2_id.Visible = False
        cSub2_id.ReadOnly = False

        cJurnaldetil_type.Name = "jurnaldetil_type"
        cJurnaldetil_type.HeaderText = "jurnaldetil_type"
        cJurnaldetil_type.DataPropertyName = "jurnaldetil_type"
        cJurnaldetil_type.Width = 100
        cJurnaldetil_type.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnaldetil_type.Visible = False
        cJurnaldetil_type.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
        {cJurnal_id, cJurnaldetil_line, cJurnaldetil_dk, cAcc_id, cJurnaldetil_descr, _
        cCurrency_id, cJurnaldetil_idr, cJurnaldetil_foreign, cJurnaldetil_foreignrate, _
        cRegion_id, cBranch_id, cStrukturunit_id, cRekanan_id, cRef_id, cRef_line, _
        cSub1_id, cSub2_id, cChannel_id, cJurnaldetil_type})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = True
        objDgv.AllowUserToDeleteRows = False
    End Function
    Private Function FormatDgvTrnJurnalreference(ByRef objDgv As System.Windows.Forms.DataGridView) As Boolean
        Dim cJurnal_id As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_id_ref As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cJurnal_id_refline As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Dim cReferencetype As System.Windows.Forms.DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        cJurnal_id.Name = "jurnal_id"
        cJurnal_id.HeaderText = "Jurnal ID"
        cJurnal_id.DataPropertyName = "jurnal_id"
        cJurnal_id.Width = 100
        cJurnal_id.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_id.Visible = True
        cJurnal_id.ReadOnly = False

        cJurnal_id_ref.Name = "jurnal_id_ref"
        cJurnal_id_ref.HeaderText = "Ref"
        cJurnal_id_ref.DataPropertyName = "jurnal_id_ref"
        cJurnal_id_ref.Width = 100
        cJurnal_id_ref.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_id_ref.Visible = True
        cJurnal_id_ref.ReadOnly = False

        cJurnal_id_refline.Name = "jurnal_id_refline"
        cJurnal_id_refline.HeaderText = "Ref Line"
        cJurnal_id_refline.DataPropertyName = "jurnal_id_refline"
        cJurnal_id_refline.Width = 100
        cJurnal_id_refline.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cJurnal_id_refline.Visible = True
        cJurnal_id_refline.ReadOnly = False

        cReferencetype.Name = "referencetype"
        cReferencetype.HeaderText = "referencetype"
        cReferencetype.DataPropertyName = "referencetype"
        cReferencetype.Width = 100
        cReferencetype.DefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet
        cReferencetype.Visible = False
        cReferencetype.ReadOnly = False

        objDgv.Columns.Clear()
        objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
         {cJurnal_id_ref, cJurnal_id_refline, cJurnal_id, cReferencetype})
        objDgv.AutoGenerateColumns = False
        objDgv.AllowUserToAddRows = False
        objDgv.AllowUserToDeleteRows = False
    End Function
#End Region

    Private Function InitLayoutUI() As Boolean

        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.PnlDfMain.Dock = DockStyle.Fill
        Me.DgvTrnTerimabarang.Dock = DockStyle.Fill

        Me.FormatDgvTrnTerimabarang(Me.DgvTrnTerimabarang)
        Me.FormatDgvTrnTerimabarangdetil(Me.DgvTrnTerimabarangdetil)

    End Function
    Private Function BindingStop() As Boolean
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Terimabarang_id.DataBindings.Clear()
        Me.obj_Terimabarang_tgl.DataBindings.Clear()
        Me.obj_Terimabarang_status.DataBindings.Clear()
        Me.obj_Order_id.DataBindings.Clear()
        Me.obj_Pa_ref.DataBindings.Clear()
        Me.obj_Rekanan_id.DataBindings.Clear()
        Me.obj_Terimabarang_appacc.DataBindings.Clear()
        Me.obj_Employee_id_pemilik.DataBindings.Clear()
        Me.obj_Strukturunit_id_pemilik.DataBindings.Clear()
        Me.obj_Accounting_applogin.DataBindings.Clear()
        Me.obj_Accounting_appdt.DataBindings.Clear()
        Me.obj_Terimabarang_appprc.DataBindings.Clear()
        Me.obj_Procurement_applogin.DataBindings.Clear()
        Me.obj_Procurement_appdt.DataBindings.Clear()
        Me.obj_Terimabarang_cetakbpb.DataBindings.Clear()
        Me.obj_Terimabarang_cetakbkb.DataBindings.Clear()
        Me.obj_Terimabarang_item.DataBindings.Clear()
        Me.obj_Inputby.DataBindings.Clear()
        Me.obj_Inputdt.DataBindings.Clear()
        Me.obj_Editby.DataBindings.Clear()
        Me.obj_Editdt.DataBindings.Clear()
        Me.obj_Usedby.DataBindings.Clear()
        Me.obj_Useddt.DataBindings.Clear()
        Me.obj_Terimabarang_appuser.DataBindings.Clear()
        Me.obj_USer_applogin.DataBindings.Clear()
        Me.obj_User_appdt.DataBindings.Clear()

        Me.Obj_Qty_Mother.DataBindings.Clear()
        Me.obj_Status.DataBindings.Clear()
        Me.obj_Qty_PO.DataBindings.Clear()
        Me.obj_Terimabarang_type.DataBindings.Clear()

        Me.obj_Currency_id_header.DataBindings.Clear()
        Me.obj_Asset_harga_header.DataBindings.Clear()
        Me.obj_Asset_ppn_header.DataBindings.Clear()
        Me.obj_Asset_pph_header.DataBindings.Clear()
        Me.obj_Asset_disc_header.DataBindings.Clear()
        Me.obj_Asset_valas_header.DataBindings.Clear()
        Me.obj_Asset_idrprice_header.DataBindings.Clear()

        Me.obj_Asset_Insurance_header.DataBindings.Clear()
        Me.obj_Asset_Transport_header.DataBindings.Clear()
        Me.obj_Asset_Operator_header.DataBindings.Clear()
        Me.obj_Asset_Other_header.DataBindings.Clear()
        Me.obj_Location.DataBindings.Clear()
        Me.obj_Notes.DataBindings.Clear()

        Me.obj_Status_kedatangan_barang.DataBindings.Clear()
        Me.obj_terimabarang_noSuratJalan.DataBindings.Clear()


        Return True
    End Function
    'start binding
    Private Function BindingStart() As Boolean
        Me.obj_Channel_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarang_Temp, "channel_id"))
        Me.obj_Terimabarang_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "terimabarang_id"))
        Me.obj_Terimabarang_tgl.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "terimabarang_tgl"))
        Me.obj_Terimabarang_status.DataBindings.Add(New Binding("SelectedItem", Me.tbl_TrnTerimabarang_Temp, "terimabarang_status"))
        Me.obj_Order_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "order_id"))
        Me.obj_Pa_ref.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "pa_ref"))
        Me.obj_Rekanan_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarang_Temp, "rekanan_id"))
        Me.obj_Terimabarang_appacc.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimabarang, "terimabarang_appacc"))
        Me.obj_Employee_id_pemilik.DataBindings.Add(New Binding("selectedValue", Me.tbl_TrnTerimabarang_Temp, "employee_id_pemilik"))
        Me.obj_Strukturunit_id_pemilik.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarang_Temp, "strukturunit_id_pemilik"))
        Me.obj_Terimabarang_item.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "terimabarang_item"))
        Me.obj_Inputby.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "inputby"))
        Me.obj_Inputdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "inputdt"))
        Me.obj_Editby.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "editby"))
        Me.obj_Editdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "editdt"))
        Me.obj_Usedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "usedby"))
        Me.obj_Useddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "useddt"))
        Me.obj_Accounting_applogin.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "accounting_applogin"))
        Me.obj_Accounting_appdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "accounting_appdt"))
        Me.obj_Terimabarang_appprc.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimabarang, "terimabarang_appprc"))
        Me.obj_Procurement_applogin.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "procurement_applogin"))
        Me.obj_Procurement_appdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "procurement_appdt"))
        Me.obj_Terimabarang_cetakbpb.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "terimabarang_cetakbpb"))
        Me.obj_Terimabarang_cetakbkb.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "terimabarang_cetakbkb"))
        Me.obj_Terimabarang_appuser.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimabarang, "terimabarang_appuser"))
        Me.obj_USer_applogin.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "user_applogin"))
        Me.obj_User_appdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "user_appdt"))

        Me.Obj_Qty_Mother.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "qty_mother"))
        Me.obj_Status.DataBindings.Add(New Binding("SelectedItem", Me.tbl_TrnTerimabarang_Temp, "status"))
        Me.obj_Qty_PO.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "qty_po"))
        Me.obj_Terimabarang_type.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "type"))

        Me.obj_Currency_id_header.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarang_Temp, "currency_id"))
        Me.obj_Asset_harga_header.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "asset_harga", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_ppn_header.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "asset_ppn", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_pph_header.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "asset_pph", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_disc_header.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "asset_disc", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_valas_header.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "asset_valas", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_idrprice_header.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "asset_idrprice", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))

        Me.obj_Asset_Insurance_header.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "order_insurancecost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_Transport_header.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "order_transportationcost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_Operator_header.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "order_operatorcost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_Other_header.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "order_othercost", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))

        Me.obj_Location.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "location"))
        Me.obj_Notes.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "notes"))
        Me.obj_Status_kedatangan_barang.DataBindings.Add(New Binding("SelectedItem", Me.tbl_TrnTerimabarang_Temp, "status_kedatangan"))
        Me.obj_terimabarang_noSuratJalan.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "no_surat_jalan"))
        Return True
    End Function
    Private Function BindingStopAsset() As Boolean

        Me.obj_asset_terimabarang_id.DataBindings.Clear()
        Me.obj_Asset_line.DataBindings.Clear()
        Me.Obj_asset_channel_id.DataBindings.Clear()
        Me.obj_Asset_tgl.DataBindings.Clear()
        Me.obj_Tipeasset_id.DataBindings.Clear()
        Me.obj_Kategoriasset_id.DataBindings.Clear()
        Me.obj_Asset_barcode.DataBindings.Clear()
        Me.obj_Asset_lineinduk.DataBindings.Clear()
        Me.obj_Asset_barcodeinduk.DataBindings.Clear()
        Me.obj_Asset_serial.DataBindings.Clear()
        Me.obj_Asset_produknumber.DataBindings.Clear()
        Me.obj_Asset_model.DataBindings.Clear()
        Me.obj_Asset_deskripsi.DataBindings.Clear()
        Me.obj_Kategoriitem_id.DataBindings.Clear()
        Me.obj_Tipeitem_id.DataBindings.Clear()
        Me.obj_Asset_golfiskal.DataBindings.Clear()
        Me.obj_Asset_tipedepre.DataBindings.Clear()
        Me.obj_asset_depre_enddt.DataBindings.Clear()
        Me.obj_Currency_id.DataBindings.Clear()
        Me.obj_Asset_harga.DataBindings.Clear()
        Me.obj_Asset_hargabaru.DataBindings.Clear()
        Me.obj_Asset_ppn.DataBindings.Clear()
        Me.obj_Asset_pph.DataBindings.Clear()
        Me.obj_Asset_disc.DataBindings.Clear()
        Me.obj_Asset_depresiasi.DataBindings.Clear()
        Me.obj_Asset_akum_val_depre.DataBindings.Clear()
        Me.obj_Asset_valas.DataBindings.Clear()
        Me.obj_Asset_idrprice.DataBindings.Clear()
        Me.obj_Strukturunit_id.DataBindings.Clear()
        Me.obj_Employee_id_owner.DataBindings.Clear()
        Me.obj_Brand_id.DataBindings.Clear()
        Me.obj_Unit_id.DataBindings.Clear()
        Me.obj_Asset_qty.DataBindings.Clear()
        Me.obj_Material_id.DataBindings.Clear()
        Me.obj_Warna_id.DataBindings.Clear()
        Me.obj_Ukuran_id.DataBindings.Clear()
        Me.obj_Jeniskelamin_id.DataBindings.Clear()
        Me.obj_Show_id_cont_item.DataBindings.Clear()
        Me.obj_Ruang_id.DataBindings.Clear()
        Me.obj_Asset_rak.DataBindings.Clear()
        Me.obj_Is_useable.DataBindings.Clear()
        Me.obj_Asset_active.DataBindings.Clear()
        Me.obj_Asset_status.DataBindings.Clear()
        Me.obj_Project_id.DataBindings.Clear()
        Me.obj_Show_id.DataBindings.Clear()
        Me.obj_Asset_eps.DataBindings.Clear()
        Me.obj_Wo_id.DataBindings.Clear()
        Me.obj_asset_inputby.DataBindings.Clear()
        Me.obj_asset_inputdt.DataBindings.Clear()
        Me.obj_asset_editby.DataBindings.Clear()
        Me.obj_asset_editdt.DataBindings.Clear()
        Me.obj_asset_usedby.DataBindings.Clear()
        Me.obj_Order_idDetil.DataBindings.Clear()
        Me.obj_orderdetil_line.DataBindings.Clear()
        Return True
    End Function
    'start binding
    Private Function BindingStartAsset() As Boolean

        Me.obj_asset_terimabarang_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "terimabarang_id"))
        Me.obj_Asset_line.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_line"))
        Me.Obj_asset_channel_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "channel_id"))
        Me.obj_Asset_tgl.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_tgl"))
        Me.obj_Tipeasset_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "tipeasset_id"))
        Me.obj_Kategoriasset_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "kategoriasset_id"))
        Me.obj_Asset_barcode.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_barcode"))
        Me.obj_Asset_lineinduk.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_lineinduk"))
        Me.obj_Asset_barcodeinduk.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_barcodeinduk"))
        Me.obj_Asset_serial.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_serial"))
        Me.obj_Asset_produknumber.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_produknumber"))
        Me.obj_Asset_model.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_model"))
        Me.obj_Asset_deskripsi.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_deskripsi"))
        Me.obj_Kategoriitem_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "kategoriitem_id"))
        Me.obj_Tipeitem_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "tipeitem_id"))
        Me.obj_Asset_golfiskal.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_golfiskal"))
        Me.obj_Asset_tipedepre.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_tipedepre"))
        Me.obj_asset_depre_enddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_depre_enddt"))
        Me.obj_Currency_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "currency_id"))
        Me.obj_Asset_harga.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_harga", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_hargabaru.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_hargabaru", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_ppn.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_ppn", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_pph.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_pph", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_disc.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_disc", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_depresiasi.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_depresiasi"))
        Me.obj_Asset_akum_val_depre.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_akum_val_depre", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_valas.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_valas", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Asset_idrprice.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_idrprice", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.obj_Strukturunit_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "strukturunit_id"))
        Me.obj_Employee_id_owner.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "employee_id_owner"))
        Me.obj_Brand_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "brand_id"))
        Me.obj_Unit_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "unit_id"))
        Me.obj_Asset_qty.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_qty"))
        Me.obj_Material_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "material_id"))
        Me.obj_Warna_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "warna_id"))
        Me.obj_Ukuran_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "ukuran_id"))
        Me.obj_Jeniskelamin_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "jeniskelamin_id"))
        Me.obj_Show_id_cont_item.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "show_id_cont_item"))
        Me.obj_Ruang_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "ruang_id"))
        Me.obj_Asset_rak.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_rak"))
        Me.obj_Is_useable.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimabarangdetil, "is_useable"))
        Me.obj_Asset_active.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimabarangdetil, "asset_active"))
        Me.obj_Asset_status.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_status"))
        'Me.obj_Project_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "project_id"))
        Me.obj_Show_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "show_id"))
        Me.obj_Asset_eps.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "asset_eps"))
        Me.obj_Wo_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "wo_id"))
        Me.obj_asset_inputby.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "inputby"))
        Me.obj_asset_inputdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "inputdt"))
        Me.obj_asset_editby.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "editby"))
        Me.obj_asset_editdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "editdt"))
        Me.obj_asset_usedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "usedby"))
        Me.obj_Order_idDetil.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "order_id"))
        Me.obj_orderdetil_line.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "orderdetil_line"))
        Return True
    End Function

#End Region

#Region " Dialoged Control "
#End Region

#Region " User Defined Function "

    Private Function uiTrnTerimaBarang_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnTerimabarang_Temp
        Me.tbl_TrnTerimabarang_Temp.Clear()
        Me.tbl_TrnTerimabarang_Temp.Columns("channel_id").DefaultValue = _CHANNEL
        Me.tbl_TrnTerimabarang_Temp.Columns("strukturunit_id_pemilik").DefaultValue = Me._STRUKTUR_UNIT

        ' TODO: Set Default Value for tbl_TrnTerimabarangdetil
        Me.tbl_TrnTerimabarangdetil.Clear()
        Me.tbl_TrnTerimabarangdetil = clsDataset.CreateTblTrnTerimabarangdetil()
        'Me.tbl_TrnTerimabarangdetil.Columns("terimabarang_id").DefaultValue = 0
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").DefaultValue = DBNull.Value
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").AutoIncrement = True
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").AutoIncrementSeed = 1
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").AutoIncrementStep = 1
        Me.tbl_TrnTerimabarangdetil.Columns("strukturunit_id").DefaultValue = Me._STRUKTUR_UNIT

        Me.DgvTrnTerimabarangdetil.DataSource = Me.tbl_TrnTerimabarangdetil


        ' TODO: Set Default Value for tbl_TrnJurnaldetil
        Me.tbl_TrnJurnaldetil.Clear()
        Me.tbl_TrnJurnaldetil = clsDataset.CreateTblTrnJurnaldetil()
        ' ''Me.tbl_TrnJurnaldetil.Columns("jurnal_id").DefaultValue = jurnal_id
        Me.tbl_TrnJurnaldetil.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil.Columns("jurnaldetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnJurnaldetil.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil.Columns("acc_id").DefaultValue = ""
        Me.DgvTrnJurnaldetil.DataSource = Me.tbl_TrnJurnaldetil

        ' TODO: Set Default Value for tbl_TrnJurnaldetil_JdwPembayaran
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Clear()
        Me.tbl_TrnJurnaldetil_JdwPembayaran = clsDataset.CreateTblTrnJurnaldetil()
        ' ''Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("jurnal_id").DefaultValue = jurnal_id
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("jurnaldetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("acc_id").DefaultValue = ""
        Me.DgvTrnJurnaldetil_Pembayaran.DataSource = Me.tbl_TrnJurnaldetil_JdwPembayaran


        Me.BindingContext(Me.tbl_TrnTerimabarang_Temp).EndCurrentEdit()

        Me.obj_Terimabarang_status.SelectedIndex = 0
        Try
            Me.BindingContext(Me.tbl_TrnTerimabarang_Temp).AddNew()
        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function
    Private Function uiTrnTerimaBarang_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()

        If chk_Rekanan_id_search.Checked = True Then
            If Me.obj_Rekanan_id_search.SelectedValue IsNot DBNull.Value Then
                criteria = criteria & " and rekanan_id = " & CStr(obj_Rekanan_id_search.SelectedValue)
            Else
                criteria = ""
            End If
        End If

        If chk_Strukturunit_id_pemilik_search.Checked = True Then
            criteria = criteria & " and strukturunit_id_pemilik = " & CStr(obj_Strukturunit_id_pemilik_search.SelectedValue)
        End If

        If chk_Procurement_search.Checked = True Then
            If Me.cmb_appprc.SelectedItem = "Yes" Then
                criteria &= " and terimabarang_appprc = 1"
            Else
                criteria &= " and terimabarang_appprc = 0"
            End If
        End If

        If chk_Accounting_search.Checked = True Then
            If Me.cmb_appacc.SelectedItem = "Yes" Then
                criteria &= " and terimabarang_appacc = 1"
            Else
                criteria &= " and terimabarang_appacc = 0"
            End If
        End If

        If chk_User_search.Checked = True Then
            If Me.cmb_appuser.SelectedItem = "Yes" Then
                criteria &= " and terimabarang_appuser = 1"
            Else
                criteria &= " and terimabarang_appuser = 0"
            End If
        End If

        criteria &= " AND ( terimabarang_status = 'NO PO' or terimabarang_status = 'PO') "

        Me.tbl_TrnTerimabarang.Clear()
        Try
            Me.DataFill(Me.tbl_TrnTerimabarang, "as_TrnTerimabarang_Select", criteria, obj_Channel_id_search.SelectedValue, obj_top.Value)
            If Me.tbl_TrnTerimabarang.Rows.Count > 0 Then
                cek_BarcodeButton()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Function uiTrnTerimaBarang_Save() As Boolean
        'save data
        Dim components As Control
        Dim tbl_TrnTerimabarang_Temp_Changes As DataTable
        Dim tbl_TrnTerimabarangdetil_Changes As DataTable
        Dim success As Boolean
        Dim terimabarang_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(terimabarang_id)

        Me.BindingContext(Me.tbl_TrnTerimabarang_Temp).EndCurrentEdit()
        tbl_TrnTerimabarang_Temp_Changes = Me.tbl_TrnTerimabarang_Temp.GetChanges()

        Me.DgvTrnTerimabarangdetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnTerimabarangdetil).EndCurrentEdit()
        tbl_TrnTerimabarangdetil_Changes = Me.tbl_TrnTerimabarangdetil.GetChanges()

        If tbl_TrnTerimabarang_Temp_Changes IsNot Nothing Or tbl_TrnTerimabarangdetil_Changes IsNot Nothing Then
            Try
                MasterDataState = tbl_TrnTerimabarang_Temp.Rows(0).RowState
                terimabarang_id = tbl_TrnTerimabarang_Temp.Rows(0).Item("terimabarang_id")

                Dim x As Integer
                Dim order_temps As DataTable = New DataTable
                Dim ppn_persen As Integer
                Dim pph_persen As Integer
                Dim asset_harga As Decimal
                Dim asset_rate As Decimal
                Dim asset_idr As Decimal
                Dim asset_qty As Integer
                If tbl_TrnTerimabarangdetil_Changes IsNot Nothing Then
                    For x = 0 To tbl_TrnTerimabarangdetil_Changes.Rows.Count - 1
                        If clsUtil.IsDbNull(tbl_TrnTerimabarangdetil_Changes.Rows(x).Item("asset_lineinduk"), 1) = 0 Then
                            order_temps.Clear()
                            Me.DataFill(order_temps, "as_TrnOrderDetil_Select", String.Format(" order_id = '{0}' and orderdetil_line = {1}", Me.tbl_TrnTerimabarangdetil.Rows(x).Item("order_id"), Me.tbl_TrnTerimabarangdetil.Rows(x).Item("orderdetil_line")))
                            ppn_persen = clsUtil.IsDbNull(order_temps.Rows(0).Item("orderdetil_ppnpercent"), 0)
                            pph_persen = clsUtil.IsDbNull(order_temps.Rows(0).Item("orderdetil_pphpercent"), 0)
                            asset_harga = clsUtil.IsDbNull(tbl_TrnTerimabarangdetil_Changes.Rows(x).Item("asset_harga"), 0)
                            asset_rate = clsUtil.IsDbNull(tbl_TrnTerimabarangdetil_Changes.Rows(x).Item("asset_valas"), 0)
                            asset_qty = clsUtil.IsDbNull(tbl_TrnTerimabarangdetil_Changes.Rows(x).Item("asset_qty"), 0)
                            asset_idr = (asset_harga * asset_rate * asset_qty)
                            tbl_TrnTerimabarangdetil_Changes.Rows(x).Item("asset_ppn") = Format(asset_idr * (ppn_persen / 100), "#,##0.00")
                            tbl_TrnTerimabarangdetil_Changes.Rows(x).Item("asset_pph") = Format(asset_idr * (pph_persen / 100), "#,##0.00")
                            tbl_TrnTerimabarangdetil_Changes.Rows(x).Item("asset_idrprice") = Format(asset_idr, "#,##0.00")
                        End If
                    Next
                End If
                If tbl_TrnTerimabarang_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnTerimaBarang_SaveMaster(terimabarang_id, tbl_TrnTerimabarang_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnTerimaBarang_SaveMaster(tbl_TrnTerimabarang_Temp_Changes)")
                    Me.tbl_TrnTerimabarang_Temp.AcceptChanges()
                End If

                If tbl_TrnTerimabarangdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                        If Me.tbl_TrnTerimabarangdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnTerimabarangdetil.Rows(i).Item("terimabarang_id") = terimabarang_id
                        End If
                    Next

                    success = Me.uiTrnTerimaBarang_SaveDetil(terimabarang_id, tbl_TrnTerimabarangdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnTerimaBarang_SaveDetil(tbl_TrnTerimabarangdetil_Changes)")
                    Me.tbl_TrnTerimabarangdetil.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.uiTrnTerimaBarang_OpenRow(Me.DgvTrnTerimabarang.CurrentRow.Index)
                    Me.BindingStopAsset()
                    Me.BindingStartAsset()
                    If Me._US = True Or Me._SP = True Then
                        'Me.PnlUser.Enabled = True
                        For Each components In Panel1.Controls
                            If components.Name <> "FTabItem" Then
                                If components.Name <> "obj_Order_idDetil" Then
                                    If components.Name <> "obj_orderdetil_line" Then
                                        components.Enabled = True
                                    End If
                                End If
                            End If
                        Next
                        Me.DgvTrnTerimabarangdetil.Enabled = True
                        Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = False
                    End If
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

        RaiseEvent FormAfterSave(terimabarang_id, result)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnTerimaBarang_SaveMaster(ByRef terimabarang_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim curpos As Integer

        ' Save data: transaksi_terimabarang
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnTerimabarang_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarang_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_tgl"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_status", System.Data.OleDb.OleDbType.VarWChar, 20, "terimabarang_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pa_ref", System.Data.OleDb.OleDbType.VarWChar, 30, "pa_ref"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appacc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_pemilik", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_pemilik"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_pemilik", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id_pemilik", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@accounting_applogin", System.Data.OleDb.OleDbType.VarWChar, 32, "accounting_applogin"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@accounting_appdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "accounting_appdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appprc", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appprc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@procurement_applogin", System.Data.OleDb.OleDbType.VarWChar, 32, "procurement_applogin"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@procurement_appdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "procurement_appdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_cetakbpb", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_cetakbpb"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_cetakbkb", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_cetakbkb"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_item", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_item"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editby", System.Data.OleDb.OleDbType.VarWChar, 32, "editby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "editdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@usedby", System.Data.OleDb.OleDbType.VarWChar, 32, "usedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "useddt"))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appuser"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32, "user_applogin"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@user_appdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "user_appdt"))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty_mother", System.Data.OleDb.OleDbType.Integer, 4, "qty_mother"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@status", System.Data.OleDb.OleDbType.VarWChar, 40, "status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty_po", System.Data.OleDb.OleDbType.Integer, 4, "qty_po"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@type", System.Data.OleDb.OleDbType.VarWChar, 60, "type"))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_harga", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_harga", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_ppn", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_pph", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_disc", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_valas", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_valas", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_idrprice", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_idrprice", System.Data.DataRowVersion.Current, Nothing))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_insurancecost", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_insurancecost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_transportationcost", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_transportationcost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_operatorcost", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_operatorcost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_othercost", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_othercost", System.Data.DataRowVersion.Current, Nothing))


        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appbma", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appbma"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bma_applogin", System.Data.OleDb.OleDbType.VarWChar, 32, "bma_applogin"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bma_appdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bma_appdt"))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_jurnal", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_jurnal"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_login", System.Data.OleDb.OleDbType.VarWChar, 32, "jurnal_login"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_dt"))

        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_posting", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_posting"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posting_login", System.Data.OleDb.OleDbType.VarWChar, 32, "posting_login"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posting_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "posting_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@location", System.Data.OleDb.OleDbType.VarWChar, 200, "location"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@notes", System.Data.OleDb.OleDbType.VarWChar, 1000, "notes"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@status_kedatangan", System.Data.OleDb.OleDbType.VarWChar, 60, "status_kedatangan"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@no_surat_jalan", System.Data.OleDb.OleDbType.VarWChar, 70, "no_surat_jalan"))
        dbCmdInsert.Parameters("@inputby").Value = Me.UserName
        dbCmdInsert.Parameters("@inputdt").Value = Now


        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnTerimabarang_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_tgl"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_status", System.Data.OleDb.OleDbType.VarWChar, 20, "terimabarang_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pa_ref", System.Data.OleDb.OleDbType.VarWChar, 30, "pa_ref"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appacc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_pemilik", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_pemilik"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_pemilik", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id_pemilik", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@accounting_applogin", System.Data.OleDb.OleDbType.VarWChar, 32, "accounting_applogin"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@accounting_appdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "accounting_appdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appprc", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appprc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@procurement_applogin", System.Data.OleDb.OleDbType.VarWChar, 32, "procurement_applogin"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@procurement_appdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "procurement_appdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_cetakbpb", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_cetakbpb"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_cetakbkb", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_cetakbkb"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_item", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_item"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputby", System.Data.OleDb.OleDbType.VarWChar, 32, "inputby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "inputdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@usedby", System.Data.OleDb.OleDbType.VarWChar, 32, "usedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "useddt"))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appuser"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32, "user_applogin"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@user_appdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "user_appdt"))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty_mother", System.Data.OleDb.OleDbType.Integer, 4, "qty_mother"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@status", System.Data.OleDb.OleDbType.VarWChar, 40, "status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@qty_po", System.Data.OleDb.OleDbType.Integer, 4, "qty_po"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@type", System.Data.OleDb.OleDbType.VarWChar, 60, "type"))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_harga", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_harga", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_ppn", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_pph", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_disc", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_valas", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_valas", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_idrprice", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_idrprice", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_insurancecost", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_insurancecost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_transportationcost", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_transportationcost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_operatorcost", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_operatorcost", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_othercost", System.Data.OleDb.OleDbType.Decimal, 18, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_othercost", System.Data.DataRowVersion.Current, Nothing))


        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appbma", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appbma"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bma_applogin", System.Data.OleDb.OleDbType.VarWChar, 32, "bma_applogin"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@bma_appdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "bma_appdt"))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_jurnal", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_jurnal"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_login", System.Data.OleDb.OleDbType.VarWChar, 32, "jurnal_login"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_dt"))

        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_posting", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_posting"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posting_login", System.Data.OleDb.OleDbType.VarWChar, 32, "posting_login"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@posting_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "posting_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@location", System.Data.OleDb.OleDbType.VarWChar, 200, "location"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@notes", System.Data.OleDb.OleDbType.VarWChar, 1000, "notes"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@status_kedatangan", System.Data.OleDb.OleDbType.VarWChar, 60, "status_kedatangan"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@no_surat_jalan", System.Data.OleDb.OleDbType.VarWChar, 70, "no_surat_jalan"))

        dbCmdUpdate.Parameters("@editby").Value = Me.UserName
        dbCmdUpdate.Parameters("@editdt").Value = Now


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert


        Try
            dbConn.Open()
            dbDA.Update(objTbl)

            terimabarang_id = objTbl.Rows(0).Item("terimabarang_id")
            Me.tbl_TrnTerimabarang_Temp.Clear()
            Me.tbl_TrnTerimabarang_Temp.Merge(objTbl)

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
            Me.tbl_TrnTerimabarang.Merge(objTbl)
        ElseIf MasterDataState = DataRowState.Modified Then
            curpos = Me.BindingContext(Me.tbl_TrnTerimabarang).Position
            Me.tbl_TrnTerimabarang.Rows.RemoveAt(curpos)
            Me.tbl_TrnTerimabarang.Merge(objTbl)
        End If

        Me.BindingContext(Me.tbl_TrnTerimabarang).Position = Me.BindingContext(Me.tbl_TrnTerimabarang).Count

        Return True
    End Function
    Private Function uiTrnTerimaBarang_SaveDetil(ByRef terimabarang_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_terimabarangdetil
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnTerimabarangdetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_line", System.Data.OleDb.OleDbType.Integer, 4, "asset_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_tgl"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "tipeasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriasset_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_lineinduk", System.Data.OleDb.OleDbType.Integer, 4, "asset_lineinduk"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcodeinduk", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcodeinduk"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_serial", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_serial"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_produknumber", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_produknumber"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_model", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_model"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deskripsi", System.Data.OleDb.OleDbType.VarWChar, 600, "asset_deskripsi"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriitem_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "tipeitem_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_golfiskal", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_golfiskal"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tipedepre", System.Data.OleDb.OleDbType.VarWChar, 2, "asset_tipedepre"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_harga", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_harga", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_hargabaru", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_hargabaru", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_depresiasi", System.Data.OleDb.OleDbType.Integer, 4, "asset_depresiasi"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_akum_val_depre", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_akum_val_depre", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_valas", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_valas", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_idrprice", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_idrprice", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "unit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_qty", System.Data.OleDb.OleDbType.Integer, 4, "asset_qty"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@material_id", System.Data.OleDb.OleDbType.VarWChar, 60, "material_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@warna_id", System.Data.OleDb.OleDbType.VarWChar, 60, "warna_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ukuran_id", System.Data.OleDb.OleDbType.VarWChar, 60, "ukuran_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jeniskelamin_id", System.Data.OleDb.OleDbType.VarWChar, 20, "jeniskelamin_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id_cont_item", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id_cont_item"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_id", System.Data.OleDb.OleDbType.VarWChar, 20, "ruang_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_rak", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_rak"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Boolean, 1, "is_useable"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_active", System.Data.OleDb.OleDbType.Boolean, 1, "asset_active"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "project_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_eps", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_eps"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wo_id", System.Data.OleDb.OleDbType.VarWChar, 30, "wo_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editby", System.Data.OleDb.OleDbType.VarWChar, 100, "editby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "editdt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@usedby", System.Data.OleDb.OleDbType.VarWChar, 100, "usedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdInsert.Parameters("@terimabarang_id").Value = terimabarang_id
        dbCmdInsert.Parameters("@inputby").Value = Me.UserName
        dbCmdInsert.Parameters("@inputdt").Value = Now

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnTerimabarangdetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_line", System.Data.OleDb.OleDbType.Integer, 4, "asset_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_tgl"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "tipeasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriasset_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_lineinduk", System.Data.OleDb.OleDbType.Integer, 4, "asset_lineinduk"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcodeinduk", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcodeinduk"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_serial", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_serial"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_produknumber", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_produknumber"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_model", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_model"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deskripsi", System.Data.OleDb.OleDbType.VarWChar, 600, "asset_deskripsi"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriitem_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "tipeitem_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_golfiskal", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_golfiskal"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tipedepre", System.Data.OleDb.OleDbType.VarWChar, 2, "asset_tipedepre"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_harga", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_harga", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_hargabaru", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_hargabaru", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_depresiasi", System.Data.OleDb.OleDbType.Integer, 4, "asset_depresiasi"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_akum_val_depre", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_akum_val_depre", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_valas", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_valas", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_idrprice", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_idrprice", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "unit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_qty", System.Data.OleDb.OleDbType.Integer, 4, "asset_qty"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@material_id", System.Data.OleDb.OleDbType.VarWChar, 60, "material_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@warna_id", System.Data.OleDb.OleDbType.VarWChar, 60, "warna_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ukuran_id", System.Data.OleDb.OleDbType.VarWChar, 60, "ukuran_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jeniskelamin_id", System.Data.OleDb.OleDbType.VarWChar, 20, "jeniskelamin_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id_cont_item", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id_cont_item"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_id", System.Data.OleDb.OleDbType.VarWChar, 20, "ruang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_rak", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_rak"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Boolean, 1, "is_useable"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_active", System.Data.OleDb.OleDbType.Boolean, 1, "asset_active"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "project_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_eps", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_eps"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wo_id", System.Data.OleDb.OleDbType.VarWChar, 30, "wo_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputby", System.Data.OleDb.OleDbType.VarWChar, 100, "inputby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "inputdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editby", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@usedby", System.Data.OleDb.OleDbType.VarWChar, 100, "usedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))

        dbCmdUpdate.Parameters("@terimabarang_id").Value = terimabarang_id
        dbCmdUpdate.Parameters("@editby").Value = Me.UserName
        dbCmdUpdate.Parameters("@editdt").Value = Now

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnTerimabarangdetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_line", System.Data.OleDb.OleDbType.Integer, 4, "asset_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "asset_tgl"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "tipeasset_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriasset_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcode"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_lineinduk", System.Data.OleDb.OleDbType.Integer, 4, "asset_lineinduk"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_barcodeinduk", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_barcodeinduk"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_serial", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_serial"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_produknumber", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_produknumber"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_model", System.Data.OleDb.OleDbType.VarWChar, 60, "asset_model"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deskripsi", System.Data.OleDb.OleDbType.VarWChar, 600, "asset_deskripsi"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@kategoriitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "kategoriitem_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@tipeitem_id", System.Data.OleDb.OleDbType.VarWChar, 60, "tipeitem_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_golfiskal", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_golfiskal"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_tipedepre", System.Data.OleDb.OleDbType.VarWChar, 2, "asset_tipedepre"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_harga", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_harga", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_hargabaru", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_hargabaru", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_depresiasi", System.Data.OleDb.OleDbType.Integer, 4, "asset_depresiasi"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_akum_val_depre", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_akum_val_depre", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_valas", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_valas", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_idrprice", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "asset_idrprice", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "unit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_qty", System.Data.OleDb.OleDbType.Integer, 4, "asset_qty"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@material_id", System.Data.OleDb.OleDbType.VarWChar, 60, "material_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@warna_id", System.Data.OleDb.OleDbType.VarWChar, 60, "warna_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ukuran_id", System.Data.OleDb.OleDbType.VarWChar, 60, "ukuran_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jeniskelamin_id", System.Data.OleDb.OleDbType.VarWChar, 20, "jeniskelamin_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id_cont_item", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id_cont_item"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ruang_id", System.Data.OleDb.OleDbType.VarWChar, 20, "ruang_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_rak", System.Data.OleDb.OleDbType.VarWChar, 40, "asset_rak"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@is_useable", System.Data.OleDb.OleDbType.Boolean, 1, "is_useable"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_active", System.Data.OleDb.OleDbType.Boolean, 1, "asset_active"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_status", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_status"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@project_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "project_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_eps", System.Data.OleDb.OleDbType.VarWChar, 20, "asset_eps"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@wo_id", System.Data.OleDb.OleDbType.VarWChar, 30, "wo_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputby", System.Data.OleDb.OleDbType.VarWChar, 100, "inputby"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "inputdt"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editby", System.Data.OleDb.OleDbType.VarWChar, 100, "editby"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "editdt"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@usedby", System.Data.OleDb.OleDbType.VarWChar, 100, "usedby"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30, "order_id"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))

        dbCmdDelete.Parameters("@terimabarang_id").Value = terimabarang_id


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

    Private Sub uiTrnTerimabarang_Acc_update_masterAsset(ByVal tbl_temp As DataTable)
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim row_index As Integer
        Dim tbl_temp_count As Integer

        tbl_temp_count = tbl_temp.Rows.Count
        For row_index = 0 To tbl_temp_count - 1
            Try
                dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("as_TrnTerimabarangdetil_Acc_update_masterAsset", dbConn)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_temp.Rows(row_index).Item("terimabarang_id")
                oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = tbl_temp.Rows(row_index).Item("channel_id")
                oCm.Parameters.Add("@kategoriasset_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = tbl_temp.Rows(row_index).Item("kategoriasset_id")
                oCm.Parameters.Add("@asset_barcode", System.Data.OleDb.OleDbType.VarWChar, 40).Value = tbl_temp.Rows(row_index).Item("asset_barcode")
                oCm.Parameters.Add("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5).Value = tbl_temp.Rows(row_index).Item("currency_id")
                oCm.Parameters.Add("@asset_harga", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_temp.Rows(row_index).Item("asset_harga")
                oCm.Parameters.Add("@asset_hargabaru", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_temp.Rows(row_index).Item("asset_hargabaru")
                oCm.Parameters.Add("@asset_ppn", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_temp.Rows(row_index).Item("asset_ppn")
                oCm.Parameters.Add("@asset_pph", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_temp.Rows(row_index).Item("asset_pph")
                oCm.Parameters.Add("@asset_disc", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_temp.Rows(row_index).Item("asset_disc")
                oCm.Parameters.Add("@asset_depresiasi", System.Data.OleDb.OleDbType.Integer, 4).Value = 0
                oCm.Parameters.Add("@asset_akum_val_depre", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_temp.Rows(row_index).Item("asset_akum_val_depre")
                oCm.Parameters.Add("@asset_valas", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_temp.Rows(row_index).Item("asset_valas")
                oCm.Parameters.Add("@asset_idrprice", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_temp.Rows(row_index).Item("asset_idrprice")

                oCm.ExecuteNonQuery()
                oCm.Dispose()

            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show("Data Not Saved (master asset)" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Data Not Saved (master asset)" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dbConn.Close()
            End Try
        Next
    End Sub


    Private Function uiTrnTerimaBarang_Delete() As Boolean
        Dim res As String = ""
        Dim terimabarang_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(terimabarang_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnTerimabarang.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnTerimaBarang_DeleteRow(Me.DgvTrnTerimabarang.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(terimabarang_id)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnTerimaBarang_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim terimabarang_id As String
        Dim NewRowIndex As Integer

        terimabarang_id = Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_id").Value

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnTerimabarang_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@channel_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@terimabarang_id").Value = terimabarang_id
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_tgl", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@terimabarang_tgl").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_status", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdDelete.Parameters("@terimabarang_status").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters("@order_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@pa_ref", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@pa_ref").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8))
        dbCmdDelete.Parameters("@rekanan_id").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc", System.Data.OleDb.OleDbType.Boolean, 1))
        dbCmdDelete.Parameters("@terimabarang_appacc").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_pemilik", System.Data.OleDb.OleDbType.VarWChar, 30))
        dbCmdDelete.Parameters("@employee_id_pemilik").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id_pemilik", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdDelete.Parameters("@strukturunit_id_pemilik").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@accounting_applogin", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdDelete.Parameters("@accounting_applogin").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@accounting_appdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@accounting_appdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appprc", System.Data.OleDb.OleDbType.VarWChar, 10))
        dbCmdDelete.Parameters("@terimabarang_appprc").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@procurement_applogin", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdDelete.Parameters("@procurement_applogin").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@procurement_appdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@procurement_appdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_cetakbpb", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@terimabarang_cetakbpb").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_cetakbkb", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@terimabarang_cetakbkb").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_item", System.Data.OleDb.OleDbType.Integer, 4))
        dbCmdDelete.Parameters("@terimabarang_item").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdDelete.Parameters("@inputby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@inputdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@inputdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdDelete.Parameters("@editby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@editdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@editdt").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@usedby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdDelete.Parameters("@usedby").Value = DBNull.Value
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@useddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdDelete.Parameters("@useddt").Value = DBNull.Value

        Try
            dbConn.Open()
            dbCmdDelete.ExecuteNonQuery()

            If Me.DgvTrnTerimabarang.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnTerimaBarang_OpenRow(NewRowIndex)
                    Me.tbl_TrnTerimabarang.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnTerimabarang.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnTerimaBarang_OpenRow(NewRowIndex)
                    Me.tbl_TrnTerimabarang.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnTerimabarang.Rows.RemoveAt(rowIndex)
                    Me.uiTrnTerimaBarang_OpenRow(rowIndex)
                End If

            Else

                Me.tbl_TrnTerimabarang_Temp.Clear()
                Me.tbl_TrnTerimabarang.Rows.RemoveAt(rowIndex)

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


    Private Function uiTrnTerimaBarang_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim terimabarang_id As String
        Dim channel_id As String
        '-----------------------------------  LOCKING -----------------------------------------
        '-------- UNTUK Locking saat USER sudah APPROVED atau Belum -------
        If Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appuser").Value = 1 And (Me._US = True Or Me._SP = True) Then
            Me.obj_Asset_qty.ReadOnly = True
            Me.obj_Asset_tgl.ReadOnly = True
            Me.obj_Order_idDetil.ReadOnly = True
            Me.obj_orderdetil_line.ReadOnly = True
            Me.obj_Asset_deskripsi.ReadOnly = True
            Me.obj_Asset_lineinduk.ReadOnly = True
            Me.obj_Asset_serial.ReadOnly = True
            Me.obj_Unit_id.Enabled = False
            Me.obj_Kategoriitem_id.Enabled = False
            Me.obj_Brand_id.Enabled = False
            Me.obj_Tipeitem_id.Enabled = False
            Me.DgvTrnTerimabarangdetil.AllowUserToAddRows = False
            Me.DgvTrnTerimabarangdetil.AllowUserToDeleteRows = False
            Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = True
            Me.Btn_Add.Enabled = False
            Me.btn_bonus.Enabled = False
            Me.btn_DeleteItem.Enabled = False
            Me.cmdList.Enabled = False
            Me.obj_Is_useable.Enabled = False
            Me.cmdMother.Enabled = False
            Me.obj_Tipeasset_id.Enabled = False
            Me.obj_Kategoriasset_id.Enabled = False
            Me.Btn_Category.Enabled = False
            Me.Btn_Brand.Enabled = False
            Me.Btn_Type.Enabled = False

            '--------di ftabitem--------
            Me.obj_Asset_produknumber.ReadOnly = True
            Me.obj_Material_id.Enabled = False
            Me.obj_Ruang_id.Enabled = False
            Me.obj_Show_id.Enabled = False
            Me.obj_Asset_eps.ReadOnly = True
            Me.obj_Warna_id.Enabled = False
            Me.obj_Asset_model.ReadOnly = True
            Me.obj_Jeniskelamin_id.Enabled = False
            Me.obj_Asset_rak.ReadOnly = True
            Me.obj_Show_id_cont_item.Enabled = False
            Me.obj_Ukuran_id.Enabled = False
            Me.Btn_Material.Enabled = False
            Me.Btn_Show.Enabled = False
            Me.Btn_Room.Enabled = False
            Me.Btn_Color.Enabled = False
            Me.Btn_ContShow.Enabled = False
            Me.Btn_Size.Enabled = False
        ElseIf Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appuser").Value = 0 And (Me._US = True Or Me._SP = True) Then
            Me.Panel3.Enabled = True
            Me.PnlDataMaster.Enabled = True
            Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = False
            Me.DgvTrnTerimabarangdetil.Enabled = True

            Me.obj_Asset_qty.ReadOnly = False
            Me.obj_Asset_tgl.ReadOnly = False
            Me.obj_Order_idDetil.ReadOnly = True
            Me.obj_orderdetil_line.ReadOnly = True
            Me.obj_Asset_deskripsi.ReadOnly = False
            Me.obj_Asset_lineinduk.ReadOnly = False
            Me.obj_Asset_serial.ReadOnly = False
            Me.obj_Unit_id.Enabled = True
            Me.obj_Kategoriitem_id.Enabled = True
            Me.obj_Brand_id.Enabled = True
            Me.obj_Tipeitem_id.Enabled = True
            Me.btnlock.Enabled = False
            Me.DgvTrnTerimabarangdetil.AllowUserToAddRows = False 'True
            Me.DgvTrnTerimabarangdetil.AllowUserToDeleteRows = False 'True
            Me.Btn_Add.Enabled = False
            Me.btn_bonus.Enabled = False

            '--------di ftabitem--------
            Me.obj_Asset_produknumber.ReadOnly = False
            Me.obj_Material_id.Enabled = True
            Me.obj_Ruang_id.Enabled = True
            Me.obj_Show_id.Enabled = True
            Me.obj_Asset_eps.ReadOnly = False
            Me.obj_Warna_id.Enabled = True
            Me.obj_Asset_model.ReadOnly = False
            Me.obj_Jeniskelamin_id.Enabled = True
            Me.obj_Asset_rak.ReadOnly = False
            Me.obj_Show_id_cont_item.Enabled = True
            Me.obj_Ukuran_id.Enabled = True
            Me.Btn_Material.Enabled = True
            Me.Btn_Show.Enabled = True
            Me.Btn_Room.Enabled = True
            Me.Btn_Color.Enabled = True
            Me.Btn_ContShow.Enabled = True
            Me.Btn_Size.Enabled = True

            '-------- UNTUK Locking saat Procurement sudah APPROVED atau Belum -------
        ElseIf Me._PC = True Then 'Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appprc").Value = 1 And Me._PC = True Then
            Me.obj_Asset_qty.ReadOnly = True
            Me.obj_Asset_tgl.ReadOnly = True
            Me.obj_Order_idDetil.ReadOnly = True
            Me.obj_orderdetil_line.ReadOnly = True
            Me.obj_Asset_deskripsi.ReadOnly = True
            Me.obj_Asset_lineinduk.ReadOnly = True
            Me.obj_Asset_serial.ReadOnly = True
            Me.obj_Unit_id.Enabled = False
            Me.obj_Kategoriitem_id.Enabled = False
            Me.obj_Brand_id.Enabled = False
            Me.obj_Tipeitem_id.Enabled = False
            Me.DgvTrnTerimabarangdetil.AllowUserToAddRows = False
            Me.DgvTrnTerimabarangdetil.AllowUserToDeleteRows = False
            Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = True
            Me.Btn_Add.Enabled = False
            Me.btn_bonus.Enabled = False
            Me.btn_DeleteItem.Enabled = False
            Me.cmdList.Enabled = False
            Me.obj_Is_useable.Enabled = False
            Me.cmdMother.Enabled = False
            Me.obj_Tipeasset_id.Enabled = False
            Me.obj_Kategoriasset_id.Enabled = False
            Me.Btn_Category.Enabled = False
            Me.Btn_Brand.Enabled = False
            Me.Btn_Type.Enabled = False

            '--------di ftabitem--------
            Me.obj_Asset_produknumber.ReadOnly = True
            Me.obj_Material_id.Enabled = False
            Me.obj_Ruang_id.Enabled = False
            Me.obj_Show_id.Enabled = False
            Me.obj_Asset_eps.ReadOnly = True
            Me.obj_Warna_id.Enabled = False
            Me.obj_Asset_model.ReadOnly = True
            Me.obj_Jeniskelamin_id.Enabled = False
            Me.obj_Asset_rak.ReadOnly = True
            Me.obj_Show_id_cont_item.Enabled = False
            Me.obj_Ukuran_id.Enabled = False
            Me.Btn_Material.Enabled = False
            Me.Btn_Show.Enabled = False
            Me.Btn_Room.Enabled = False
            Me.Btn_Color.Enabled = False
            Me.Btn_ContShow.Enabled = False
            Me.Btn_Size.Enabled = False
            'ElseIf Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appprc").Value = 0 And Me._PC = True Then
            '    Me.Panel3.Enabled = True
            '    Me.PnlDataMaster.Enabled = True
            '    Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = False
            '    Me.DgvTrnTerimabarangdetil.Enabled = True

            '    Me.obj_Asset_qty.ReadOnly = False
            '    Me.obj_Asset_tgl.ReadOnly = False
            '    Me.obj_Order_idDetil.ReadOnly = True
            '    Me.obj_orderdetil_line.ReadOnly = True
            '    Me.obj_Asset_deskripsi.ReadOnly = False
            '    Me.obj_Asset_lineinduk.ReadOnly = False
            '    Me.obj_Asset_serial.ReadOnly = False
            '    Me.obj_Unit_id.Enabled = True
            '    Me.obj_Kategoriitem_id.Enabled = True
            '    Me.obj_Brand_id.Enabled = True
            '    Me.obj_Tipeitem_id.Enabled = True
            '    Me.btnlock.Enabled = False
            '    Me.DgvTrnTerimabarangdetil.AllowUserToAddRows = False 'True
            '    Me.DgvTrnTerimabarangdetil.AllowUserToDeleteRows = False 'True

            '    '--------di ftabitem--------
            '    Me.obj_Asset_produknumber.ReadOnly = False
            '    Me.obj_Material_id.Enabled = True
            '    Me.obj_Ruang_id.Enabled = True
            '    Me.obj_Show_id.Enabled = True
            '    Me.obj_Asset_eps.ReadOnly = False
            '    Me.obj_Warna_id.Enabled = True
            '    Me.obj_Asset_model.ReadOnly = False
            '    Me.obj_Jeniskelamin_id.Enabled = True
            '    Me.obj_Asset_rak.ReadOnly = False
            '    Me.obj_Show_id_cont_item.Enabled = True
            '    Me.obj_Ukuran_id.Enabled = True
            '    Me.Btn_Material.Enabled = True
            '    Me.Btn_Show.Enabled = True
            '    Me.Btn_Room.Enabled = True
            '    Me.Btn_Color.Enabled = True
            '    Me.Btn_ContShow.Enabled = True
            '    Me.Btn_Size.Enabled = True

            '-------- UNTUK Locking selain Procurement sudah APPROVED atau Belum -------
        Else
            Me.obj_Asset_qty.ReadOnly = True
            Me.obj_Asset_tgl.ReadOnly = True
            Me.obj_Order_idDetil.ReadOnly = True
            Me.obj_orderdetil_line.ReadOnly = True
            Me.obj_Asset_deskripsi.ReadOnly = True
            Me.obj_Asset_lineinduk.ReadOnly = True
            Me.obj_Asset_serial.ReadOnly = True
            Me.obj_Unit_id.Enabled = False
            Me.obj_Kategoriitem_id.Enabled = False
            Me.obj_Brand_id.Enabled = False
            Me.obj_Tipeitem_id.Enabled = False
            Me.DgvTrnTerimabarangdetil.AllowUserToAddRows = False
            Me.DgvTrnTerimabarangdetil.AllowUserToDeleteRows = False
            Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = True
            Me.Btn_Add.Enabled = False
            Me.btn_bonus.Enabled = False
            Me.btn_DeleteItem.Enabled = False
            Me.cmdList.Enabled = False
            Me.obj_Is_useable.Enabled = False
            Me.cmdMother.Enabled = False
            Me.obj_Tipeasset_id.Enabled = False
            Me.obj_Kategoriasset_id.Enabled = False
            Me.Btn_Category.Enabled = False
            Me.Btn_Brand.Enabled = False
            Me.Btn_Type.Enabled = False

            '--------di ftabitem--------
            Me.obj_Asset_produknumber.ReadOnly = True
            Me.obj_Material_id.Enabled = False
            Me.obj_Ruang_id.Enabled = False
            Me.obj_Show_id.Enabled = False
            Me.obj_Asset_eps.ReadOnly = True
            Me.obj_Warna_id.Enabled = False
            Me.obj_Asset_model.ReadOnly = True
            Me.obj_Jeniskelamin_id.Enabled = False
            Me.obj_Asset_rak.ReadOnly = True
            Me.obj_Show_id_cont_item.Enabled = False
            Me.obj_Ukuran_id.Enabled = False
            Me.Btn_Material.Enabled = False
            Me.Btn_Show.Enabled = False
            Me.Btn_Room.Enabled = False
            Me.Btn_Color.Enabled = False
            Me.Btn_ContShow.Enabled = False
            Me.Btn_Size.Enabled = False
        End If




        '-------------------------------- END LOCKING -----------------------------------


        ' ''If Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appacc").Value = 1 Then
        ' ''    If Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appprc").Value = 1 Then
        ' ''        Me.Panel3.Enabled = False
        ' ''        Me.PnlDataMaster.Enabled = False
        ' ''        Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = True
        ' ''        Me.DgvTrnTerimabarangdetil.Enabled = True
        ' ''        'Me.PnlAccounting.Enabled = False
        ' ''        For Each components In TabPage3.Controls
        ' ''            components.Enabled = False
        ' ''        Next
        ' ''        Me.DgvTrnTerimabarangdetil.AllowUserToAddRows = False
        ' ''        Me.DgvTrnTerimabarangdetil.AllowUserToDeleteRows = False
        ' ''    End If
        ' ''Else
        ' ''    'Me.PnlAccounting.Enabled = True
        ' ''    For Each components In TabPage3.Controls
        ' ''        components.Enabled = True
        ' ''    Next
        ' ''    Me.Panel3.Enabled = True
        ' ''End If
        '' '' ''Else
        '' '' ''Me.Panel3.Enabled = True
        '' '' ''Me.PnlDataMaster.Enabled = True
        '' '' ''Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = False
        '' '' ''Me.DgvTrnTerimabarangdetil.Enabled = True
        ' '' '' ''Me.PnlAccounting.Enabled = False
        '' '' ''For Each components In TabPage3.Controls
        '' '' ''    components.Enabled = False
        '' '' ''Next
        ' '' '' ''Me.PnlUser.Enabled = True
        '' '' ''Me.btnlock.Enabled = False
        '' '' ''Me.DgvTrnTerimabarangdetil.AllowUserToAddRows = False 'True
        '' '' ''Me.DgvTrnTerimabarangdetil.AllowUserToDeleteRows = False 'True
        '' '' ''End If

        ' ''If Me._AC = True And Me._PC = True And Me._US = True Then
        ' ''    'Me.PnlAccounting.Enabled = True
        ' ''    For Each components In TabPage3.Controls
        ' ''        components.Enabled = True
        ' ''    Next
        ' ''    'Me.PnlUser.Enabled = True
        ' ''    Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = False
        ' ''ElseIf Me._AC = True Then
        ' ''    'Me.PnlAccounting.Enabled = True
        ' ''    For Each components In TabPage3.Controls
        ' ''        components.Enabled = True
        ' ''    Next
        ' ''    'Me.PnlUser.Enabled = False
        ' ''    Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = True
        ' ''ElseIf Me._PC = True Then
        ' ''    'Me.PnlAccounting.Enabled = False
        ' ''    For Each components In TabPage3.Controls
        ' ''        components.Enabled = False
        ' ''    Next
        ' ''    'Me.PnlUser.Enabled = False
        ' ''    Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = True
        ' ''    If Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appprc").Value = 1 Then
        ' ''        Me.obj_Status.Enabled = False
        ' ''    Else
        ' ''        Me.obj_Status.Enabled = True
        ' ''    End If
        ' ''End If

        '--------------------------------- UNTUK OPEN ROW -------------------------------
        terimabarang_id = Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_id").Value
        channel_id = Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(terimabarang_id)

        Try
            dbConn.Open()
            Me.uiTrnTerimaBarang_OpenRowMaster(channel_id, terimabarang_id, dbConn)
            Me.uiTrnTerimaBarang_OpenRowDetil(channel_id, terimabarang_id, dbConn)
            Me.uiTrnTerimaJasa_OpenRowJurnalDetil(channel_id, terimabarang_id, dbConn)
            Me.uiTrnTerimaJasa_OpenRowJurnalDetil_pembayaran(channel_id, terimabarang_id, dbConn)
            Me.uiTrnTerimajasa_OpenRowJurnalReference(channel_id, terimabarang_id, dbConn)
            '--------------------------------- END OPEN ROW -------------------------------

            'Kondisi jika sudah ada 1 data di detil yang dimasukkan, maka data di header
            'sudah tidak bisa diubah
            If Me.DgvTrnTerimabarangdetil.Rows.Count = 0 Then
                Me.obj_Terimabarang_status.Enabled = True
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
            Else
                Me.obj_Terimabarang_status.Enabled = False
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
            End If

            If Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appuser").Value = 0 And (Me._US = True Or Me._SP = True) Then 'Me.obj_Terimabarang_status.SelectedItem = "PO" And Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appuser").Value = 0 Then
                If Me.DgvTrnTerimabarangdetil.RowCount = 0 And Me.obj_Terimabarang_status.SelectedItem = "PO" Then
                    Me.Btn_Add.Enabled = True
                    Me.btn_bonus.Enabled = True
                    Me.btn_DeleteItem.Enabled = True
                    'Me.obj_Order_id.Enabled = True
                    Me.btn_order.Enabled = True
                    Me.obj_Terimabarang_status.Enabled = True
                    Me.obj_Rekanan_id.Enabled = False
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Location.Enabled = True
                    Me.obj_Location.ReadOnly = False
                    Me.obj_terimabarang_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.obj_Status_kedatangan_barang.Enabled = True
                ElseIf Me.DgvTrnTerimabarangdetil.RowCount = 0 And Me.obj_Terimabarang_status.SelectedItem = "NO PO" Then
                    Me.Btn_Add.Enabled = True
                    Me.btn_bonus.Enabled = True
                    Me.btn_DeleteItem.Enabled = True
                    Me.obj_Terimabarang_status.Enabled = True
                    'Me.obj_Order_id.Enabled = False
                    Me.btn_order.Enabled = False
                    Me.obj_Rekanan_id.Enabled = True
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Location.Enabled = True
                    Me.obj_Location.ReadOnly = False
                    Me.obj_terimabarang_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.obj_Status_kedatangan_barang.Enabled = True
                Else
                    Me.Btn_Add.Enabled = True
                    Me.btn_bonus.Enabled = True
                    Me.btn_DeleteItem.Enabled = True
                    'Me.obj_Order_id.Enabled = False
                    Me.btn_order.Enabled = False
                    Me.obj_Terimabarang_status.Enabled = False
                    Me.obj_Rekanan_id.Enabled = False
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Location.Enabled = True
                    Me.obj_Location.ReadOnly = False
                    Me.obj_terimabarang_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.obj_Status_kedatangan_barang.Enabled = True
                End If
            ElseIf Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appuser").Value = 1 And (Me._US = True Or Me._SP = True) And Me.DgvTrnTerimabarangdetil.RowCount >= 0 Then
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
                Me.obj_Terimabarang_status.Enabled = False
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
                Me.obj_Rekanan_id.Enabled = False
                Me.obj_Employee_id_pemilik.Enabled = False
                Me.obj_Location.Enabled = True
                Me.obj_Location.ReadOnly = True
                Me.obj_terimabarang_noSuratJalan.ReadOnly = True
                Me.obj_Notes.Enabled = True
                Me.obj_Notes.ReadOnly = True
                Me.obj_Order_idDetil.ReadOnly = True
                Me.obj_orderdetil_line.ReadOnly = True
                Me.obj_Status_kedatangan_barang.Enabled = False
            End If

            'If Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appprc").Value = 0 And Me._PC = True Then 'Me.obj_Terimabarang_status.SelectedItem = "PO" And Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appuser").Value = 0 Then
            '    If Me.DgvTrnTerimabarangdetil.RowCount = 0 And (Me.obj_Terimabarang_status.SelectedItem = "PO") Then
            '        Me.Btn_Add.Enabled = True
            '        Me.btn_bonus.Enabled = True
            '        Me.btn_DeleteItem.Enabled = True
            '        'Me.obj_Order_id.Enabled = True
            '        Me.btn_order.Enabled = True
            '        Me.obj_Terimabarang_status.Enabled = True
            '        Me.obj_Rekanan_id.Enabled = False
            '        Me.obj_Employee_id_pemilik.Enabled = True
            '        Me.obj_Location.Enabled = True
            '        Me.obj_Location.ReadOnly = False
            '        Me.obj_terimabarang_noSuratJalan.ReadOnly = False
            '        Me.obj_Notes.Enabled = True
            '        Me.obj_Notes.ReadOnly = False
            '        Me.obj_Status_kedatangan_barang.Enabled = True
            '    ElseIf Me.DgvTrnTerimabarangdetil.RowCount = 0 And Me.obj_Terimabarang_status.SelectedItem = "NO PO" Then
            '        Me.Btn_Add.Enabled = True
            '        Me.btn_bonus.Enabled = True
            '        Me.btn_DeleteItem.Enabled = True
            '        Me.obj_Terimabarang_status.Enabled = True
            '        'Me.obj_Order_id.Enabled = False
            '        Me.btn_order.Enabled = False
            '        Me.obj_Rekanan_id.Enabled = True
            '        Me.obj_Employee_id_pemilik.Enabled = True
            '        Me.obj_Location.Enabled = True
            '        Me.obj_Location.ReadOnly = False
            '        Me.obj_terimabarang_noSuratJalan.ReadOnly = False
            '        Me.obj_Notes.Enabled = True
            '        Me.obj_Notes.ReadOnly = False
            '        Me.obj_Status_kedatangan_barang.Enabled = True
            '    Else
            '        Me.Btn_Add.Enabled = True
            '        Me.btn_bonus.Enabled = True
            '        Me.btn_DeleteItem.Enabled = True
            '        'Me.obj_Order_id.Enabled = False
            '        Me.btn_order.Enabled = False
            '        Me.obj_Terimabarang_status.Enabled = False
            '        Me.obj_Rekanan_id.Enabled = False
            '        Me.obj_Employee_id_pemilik.Enabled = True
            '        Me.obj_Location.Enabled = True
            '        Me.obj_Location.ReadOnly = False
            '        Me.obj_terimabarang_noSuratJalan.ReadOnly = False
            '        Me.obj_Notes.Enabled = True
            '        Me.obj_Notes.ReadOnly = False
            '        Me.obj_Status_kedatangan_barang.Enabled = True
            '    End If
            'ElseIf Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appprc").Value = 1 And Me._PC = True And Me.DgvTrnTerimabarangdetil.RowCount >= 0 Then
            If Me._PC = True Then
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
                Me.obj_Terimabarang_status.Enabled = False
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
                Me.obj_Rekanan_id.Enabled = False
                Me.obj_Employee_id_pemilik.Enabled = False
                Me.obj_Location.Enabled = True
                Me.obj_Location.ReadOnly = True
                Me.obj_terimabarang_noSuratJalan.ReadOnly = True
                Me.obj_Notes.Enabled = True
                Me.obj_Notes.ReadOnly = True
                Me.obj_Order_idDetil.ReadOnly = True
                Me.obj_orderdetil_line.ReadOnly = True
                Me.obj_Status_kedatangan_barang.Enabled = False
            End If

            If Me._AC = True Then
                Me.obj_Notes.ReadOnly = True
                Me.obj_Location.ReadOnly = True
                Me.obj_terimabarang_noSuratJalan.ReadOnly = True
                Me.obj_Employee_id_pemilik.Enabled = False
                Me.obj_Status_kedatangan_barang.Enabled = False
                Me.obj_Terimabarang_status.Enabled = False
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
                Me.obj_Status.Enabled = False
                Me.obj_Rekanan_id.Enabled = False
                Me.obj_Strukturunit_id_pemilik.Enabled = False
                Me.DgvTrnTerimabarangdetil.AllowUserToDeleteRows = False
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
            End If

            '-------- UNTUK Locking Accounting -------

            If Me._AC = True Then
                Me.obj_Currency_id.Enabled = False
                Me.obj_Asset_harga.ReadOnly = True
                Me.obj_Asset_pph.ReadOnly = True
                Me.obj_Asset_ppn.ReadOnly = True
                Me.obj_Asset_valas.ReadOnly = True
                Me.obj_Asset_disc.ReadOnly = True
                Me.obj_Asset_idrprice.ReadOnly = True
                Me.obj_Asset_golfiskal.ReadOnly = True
                Me.obj_shadow_tipedepre.Enabled = False
            End If

            '------------ END Locking -----------------

            Me.tampil_status_PO_MANUAL()
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnTerimaBarang_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(terimabarang_id)
        Me.Cursor = Cursors.Arrow
        Return True
    End Function

    Private Function uiTrnTerimaBarang_OpenRowMaster(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnTerimabarang_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format(" and terimabarang_id ='{0}' ", terimabarang_id)
        dbCmd.Parameters.Add("@Top", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@Top").Value = 1
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnTerimabarang_Temp.Clear()

        Try
            Me.BindingStop()
            dbDA.Fill(Me.tbl_TrnTerimabarang_Temp)
            Me.BindingStart()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnTerimaBarang_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnTerimaBarang_OpenRowDetil(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_TrnTerimabarangdetil_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format(" and terimabarang_id='{0}'", terimabarang_id)
        dbCmd.Parameters.Add("@Top", Data.OleDb.OleDbType.Integer)
        dbCmd.Parameters("@Top").Value = 0
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnTerimabarangdetil.Clear()
        Me.tbl_TrnTerimabarangdetil = clsDataset.CreateTblTrnTerimabarangdetil()
        Me.tbl_TrnTerimabarangdetil.Columns("terimabarang_id").DefaultValue = terimabarang_id
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").DefaultValue = DBNull.Value
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").AutoIncrement = True
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").AutoIncrementSeed = 1
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").AutoIncrementStep = 1
        Me.tbl_TrnTerimabarangdetil.Columns("asset_valas").DefaultValue = 1
        Me.tbl_TrnTerimabarangdetil.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnTerimabarangdetil.Columns("strukturunit_id").DefaultValue = Me._STRUKTUR_UNIT

        Try
            Me.BindingStopAsset()
            dbDA.Fill(Me.tbl_TrnTerimabarangdetil)
            Me.DgvTrnTerimabarangdetil.DataSource = Me.tbl_TrnTerimabarangdetil

            Me.BindingStartAsset()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnTerimaBarang_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnTerimaJasa_OpenRowJurnalDetil_pembayaran(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("cp_TrnJurnaldetil_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("jurnal_id='{0}' AND jurnaldetil_dk='D'", Mid(jurnal_id, 1, 8) & Mid(jurnal_id, 12, 4))
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Clear()

        Me.tbl_TrnJurnaldetil_JdwPembayaran = clsDataset.CreateTblTrnJurnaldetil()
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("jurnal_id").DefaultValue = jurnal_id
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("jurnaldetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Columns("acc_id").DefaultValue = ""

        Try
            dbDA.Fill(Me.tbl_TrnJurnaldetil_JdwPembayaran)
            Me.DgvTrnJurnaldetil_Pembayaran.DataSource = Me.tbl_TrnJurnaldetil_JdwPembayaran
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnTerimaJasa_OpenRowJurnalDetil(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("cp_TrnJurnaldetil_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("jurnal_id='{0}' AND jurnaldetil_dk='K'", Mid(jurnal_id, 1, 8) & Mid(jurnal_id, 12, 4))
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_TrnJurnaldetil.Clear()

        Me.tbl_TrnJurnaldetil = clsDataset.CreateTblTrnJurnaldetil() 'clsDataset.CreateTblTrnJurnaldetilPembayaran()
        Me.tbl_TrnJurnaldetil.Columns("jurnal_id").DefaultValue = Mid(jurnal_id, 1, 8) & Mid(jurnal_id, 12, 4)
        Me.tbl_TrnJurnaldetil.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil.Columns("jurnaldetil_line").AutoIncrementSeed = 5
        Me.tbl_TrnJurnaldetil.Columns("jurnaldetil_line").AutoIncrementStep = 10


        Try
            dbDA.Fill(Me.tbl_TrnJurnaldetil)
            Me.uiTrnJurnal_TblDetilInverse(Me.tbl_TrnJurnaldetil)
            Me.DgvTrnJurnaldetil.DataSource = Me.tbl_TrnJurnaldetil
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowDetil_JdwPembayaran()" & vbCrLf & ex.Message)
        End Try

    End Function
    Private Function uiTrnTerimajasa_OpenRowJurnalReference(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("cp_TrnJurnalReference_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@jurnal_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@jurnal_id").Value = Mid(jurnal_id, 1, 8) & Mid(jurnal_id, 12, 4)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_JurnalReference.Clear()

        Try
            dbDA.Fill(Me.tbl_JurnalReference)
            Me.DgvTrnJurnalreference.DataSource = Me.tbl_JurnalReference
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowReference()" & vbCrLf & ex.Message)
        End Try

    End Function


    Private Function uiTrnTerimaBarang_First() As Boolean
        'goto first record found
        If Me.DgvTrnTerimabarang.SelectedRows.Count <= 0 Then
            MsgBox("No Data")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to first record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnTerimaBarang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnTerimabarang.CurrentCell = Me.DgvTrnTerimabarang(1, 0)
            Me.uiTrnTerimaBarang_RefreshPosition()
            cek_BarcodeButton()
        End If
    End Function

    Private Function uiTrnTerimaBarang_Prev() As Boolean
        'goto previous record found
        If Me.DgvTrnTerimabarang.SelectedRows.Count - 1 Then
            MsgBox("No Data")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to previous record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnTerimaBarang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnTerimabarang.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnTerimabarang.CurrentCell = Me.DgvTrnTerimabarang(1, DgvTrnTerimabarang.CurrentCell.RowIndex - 1)
                Me.uiTrnTerimaBarang_RefreshPosition()
                cek_BarcodeButton()
            End If
        End If
    End Function

    Private Function uiTrnTerimaBarang_Next() As Boolean
        'goto next record found
        If Me.DgvTrnTerimabarang.SelectedRows.Count - 1 Then
            MsgBox("No Data")
            Exit Function
        End If
        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnTerimaBarang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnTerimabarang.CurrentCell.RowIndex < Me.DgvTrnTerimabarang.Rows.Count - 1 Then
                Me.DgvTrnTerimabarang.CurrentCell = Me.DgvTrnTerimabarang(1, DgvTrnTerimabarang.CurrentCell.RowIndex + 1)
                Me.uiTrnTerimaBarang_RefreshPosition()
                cek_BarcodeButton()
            End If
        End If
    End Function

    Private Function uiTrnTerimaBarang_Last() As Boolean
        'goto last record found
        If Me.DgvTrnTerimabarang.SelectedRows.Count - 1 Then
            MsgBox("No Data")
            Exit Function
        End If

        Dim move As Boolean
        Dim Message As String = "Data has been changed. " & vbCrLf & "Save data changes before move to next record ?"
        Dim iTab As Integer = Me.ftabMain.SelectedIndex

        If iTab = 1 Then
            If Me.DATA_ISLOCKED Then
                move = True
            Else
                move = Me.uiTrnTerimaBarang_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnTerimabarang.CurrentCell = Me.DgvTrnTerimabarang(1, Me.DgvTrnTerimabarang.Rows.Count - 1)
            Me.uiTrnTerimaBarang_RefreshPosition()
            cek_BarcodeButton()
        End If
    End Function

    Private Function uiTrnTerimaBarang_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnTerimaBarang_OpenRow(Me.DgvTrnTerimabarang.CurrentRow.Index)
    End Function

    Private Function uiTrnTerimaBarang_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnTerimabarang_Temp_Changes As DataTable
        Dim tbl_TrnTerimabarangdetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim i As Integer = 0
        Dim terimabarang_id As Object = New Object
        Dim move As Boolean = False
        Dim isTempChanged As Boolean = False

        If Me.DgvTrnTerimabarang.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnTerimabarang_Temp).EndCurrentEdit()
            tbl_TrnTerimabarang_Temp_Changes = Me.tbl_TrnTerimabarang_Temp.GetChanges()

            For i = 0 To Me.tbl_TrnTerimabarang_TempStart.Columns.Count - 3
                If clsUtil.IsDbNull(Me.tbl_TrnTerimabarang_TempStart.Rows(0).Item(i), Me.tbl_TrnTerimabarang_TempStart.Columns(i).DefaultValue) <> clsUtil.IsDbNull(Me.tbl_TrnTerimabarang_Temp.Rows(0).Item(i), Me.tbl_TrnTerimabarang_Temp.Columns(i).DefaultValue) Then
                    isTempChanged = True
                    Exit For
                End If
            Next

            Me.DgvTrnTerimabarangdetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnTerimabarangdetil).EndCurrentEdit()
            tbl_TrnTerimabarangdetil_Changes = Me.tbl_TrnTerimabarangdetil.GetChanges()

            If isTempChanged Or tbl_TrnTerimabarangdetil_Changes IsNot Nothing Then
                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes
                        RaiseEvent FormBeforeSave(terimabarang_id)
                        Me.uiTrnTerimaBarang_Save()
                        move = True
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

    Private Function uiTrnTerimaBarang_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False

        Try
            If Me.obj_Terimabarang_status.Text = "-- Pilih --" Or Me.obj_Terimabarang_status.Text = String.Empty Then
                ErrorMessage = "PO status cannot be empty"
                Me.objFormError.SetError(Me.obj_Terimabarang_status, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Terimabarang_status, "")
            End If

            If Me.obj_Is_useable.Checked = True And Me.obj_Asset_barcode.Text = "" Then
                ErrorMessage = "Asset barcode cannot be empty"
                Me.objFormError.SetError(Me.obj_Asset_barcode, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Asset_barcode, "")
            End If
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function
    Private Function uiTrnTerimaBarang_FormErrorValidasi() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False
        Dim oDataFiller As New clsDataFiller(DSN)
        Dim criteria As String = String.Empty
        Dim tabell As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Dim i As Integer
        Dim tipeAsset As String
        Dim kategoriAsset As String
        Dim line As Integer

        Try
            criteria = String.Format("and terimabarang_id = '{0}'", Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_id").Value)
            tabell.Rows.Clear()
            oDataFiller.DataFill(tabell, "as_TrnTerimabarangdetil_selectValidasi", criteria, Me._CHANNEL, 0)

            For i = 0 To tabell.Rows.Count - 1
                tipeAsset = clsUtil.IsDbNull(tabell.Rows(i).Item("tipeasset_id"), String.Empty)
                kategoriAsset = clsUtil.IsDbNull(tabell.Rows(i).Item("kategoriasset_id"), String.Empty)
                line = clsUtil.IsDbNull(tabell.Rows(i).Item("asset_line"), 0)

                If tipeAsset = String.Empty Or tipeAsset = "-- PILIH --" Then
                    ErrorMessage = "Tipe asset in Received Number " & _
                                    Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_id").Value & _
                                    " and asset detil Line " & line & " cannot be empty"
                    Me.objFormError.SetError(Me.obj_Tipeasset_id, ErrorMessage)
                    Throw New Exception(ErrorMessage)
                Else
                    Me.objFormError.SetError(Me.obj_Tipeasset_id, "")
                End If

                If kategoriAsset = String.Empty Or kategoriAsset = "-- PILIH --" Then
                    ErrorMessage = "Kategori asset in Received Number " & _
                                    Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_id").Value & _
                                    " and asset detil Line " & line & " cannot be empty"
                    Me.objFormError.SetError(Me.obj_Kategoriasset_id, ErrorMessage)
                    Throw New Exception(ErrorMessage)
                Else
                    Me.objFormError.SetError(Me.obj_Kategoriasset_id, "")
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function

#End Region

#Region " Other User Defined Function "

    Private Function uiTrnTerimaBarang_ValidasiAsset(ByRef terimabarang_id As Object, ByRef channel_id As Object) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Try
            dbConn.Open()
            dbCmdInsert = New OleDb.OleDbCommand("as_ValidasiAsset", dbConn)
            dbCmdInsert.CommandType = CommandType.StoredProcedure
            dbCmdInsert.Parameters.Add("@channel_id", OleDb.OleDbType.VarWChar, 20).Value = Trim(Me._CHANNEL)
            dbCmdInsert.Parameters.Add("@terimabarang_id", OleDb.OleDbType.VarWChar, 40).Value = CStr(terimabarang_id)
            dbCmdInsert.ExecuteNonQuery()
            dbCmdInsert.Dispose()

            Me.uiTrnTerimaBarang_OpenRowDetil(channel_id, terimabarang_id, dbConn)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            dbConn.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default

        Return True
    End Function

#End Region

#Region " Combo and Lock "

    Private Sub uiTrnTerimaBarang_LoadComboSearch()


        If Me._LOADCOMBOSEARCH = False Then
            '-----Mulai Bikin Tabel untuk combo Data Search-------------------------
            Me.ComboFill(obj_Channel_id_search, "channel_id", "channel_id", tbl_MstChannel_channel_id_search, "as_MstChannel_select", "", "")
            Me.tbl_MstChannel_channel_id_search.DefaultView.Sort = "channel_name"
            Me.ComboFillAngka(Me.ASSET_DSN, obj_Rekanan_id_search, "rekanan_id", "rekanan_name", tbl_MstRekanan_rekanan_id_search, "as_MstRekanan_select", "rekanantype_id = 1", "")
            Me.tbl_MstRekanan_rekanan_id_search.DefaultView.Sort = "rekanan_name"

            Me.ComboFill(Me.obj_Strukturunit_id_pemilik_search, "strukturunit_id", "strukturunit_name", tbl_MstStrukturunit_id_search, "ms_MstStrukturUnit_Select", "", "")
            Me.tbl_MstStrukturunit_id_search.DefaultView.Sort = "strukturunit_name"


            '-----End Bikin Tabel untuk combo Data  Search----------------------------------
            '---Copy tabel yang sama buat combo--------'
            Dim LL As Boolean
            Me.tbl_MstChannel_channel_id = tbl_MstChannel_channel_id_search.Copy
            LL = ComboFillFromDataTable(obj_Channel_id, "channel_id", "channel_id", tbl_MstChannel_channel_id)
            Me.tbl_MstChannel_channel_id.DefaultView.Sort = "channel_name"

            Me.tbl_MstChannel_channel_id_asset = tbl_MstChannel_channel_id_search.Copy
            LL = ComboFillFromDataTable(Obj_asset_channel_id, "channel_id", "channel_id", tbl_MstChannel_channel_id_asset)
            Me.tbl_MstChannel_channel_id_asset.DefaultView.Sort = "channel_name"

            Me.tbl_MstRekanan_rekanan_id = Me.tbl_MstRekanan_rekanan_id_search.Copy
            LL = ComboFillFromDataTable(obj_Rekanan_id, "rekanan_id", "rekanan_name", tbl_MstRekanan_rekanan_id)
            Me.tbl_MstRekanan_rekanan_id.DefaultView.Sort = "rekanan_name"

            Me.tbl_MstStrukturunit_id = Me.tbl_MstStrukturunit_id_search.Copy
            LL = ComboFillFromDataTable(Me.obj_Strukturunit_id_pemilik, "strukturunit_id", "strukturunit_name", tbl_MstStrukturunit_id)
            Me.tbl_MstStrukturunit_id.DefaultView.Sort = "strukturunit_name"

            '---End Copy tabel yang sama buat combo--------'

            '----------- Untuk Narik PO ------------'
            'Me.ComboFill(Me.obj_Order_id, "order_id", "order_id", Me.tbl_MstTrnOrder, "as_TrnOrder_Select", " strukturunit_id = " & Me._STRUKTUR_UNIT & " AND order_canceled = 0 AND (ordertype_id = 'PO')")
            ''Me.ComboFill(Me.obj_Order_id, "order_id", "order_id", Me.tbl_MstTrnOrder, "as_TrnOrder_Select", " order_id not in (SELECT order_id from transaksi_terimabarang where status = 'COMPLETE') AND ordertype_id = 'PO'")
            'Me.tbl_MstTrnOrder.DefaultView.Sort = "order_id"
            Me._LOADCOMBOSEARCH = True
        End If

    End Sub

    Private Sub uiTrnTerimaBarang_LoadComboBox()
        'Sekarang bagian Header
        If Me._LoadComboInLoadData = False Then
            If Me._SU_EMPLOYEE = String.Empty Then

                Me.ComboFill(Me.obj_Employee_id_pemilik, "employee_id", "employee_namalengkap", Me.Tbl_Mstemployeepemilik, "ms_MstEmployee_Select", " ")
                Me.Tbl_Mstemployeepemilik.DefaultView.Sort = "employee_namalengkap"

                Dim LL As Boolean
                Me.Tbl_Mstemployeeowner = Tbl_Mstemployeepemilik.Copy
                LL = ComboFillFromDataTable(obj_Employee_id_owner, "employee_id", "employee_namalengkap", Tbl_Mstemployeeowner)
                Me.Tbl_Mstemployeeowner.DefaultView.Sort = "employee_namalengkap"
            Else
                Me.ComboFill(Me.obj_Employee_id_pemilik, "employee_id", "employee_namalengkap", Me.Tbl_Mstemployeepemilik, "ms_MstEmployee_Select", " strukturunit_id = " & Me._SU_EMPLOYEE)
                Me.Tbl_Mstemployeepemilik.DefaultView.Sort = "employee_namalengkap"

                Dim LL As Boolean
                Me.Tbl_Mstemployeeowner = Tbl_Mstemployeepemilik.Copy
                LL = ComboFillFromDataTable(obj_Employee_id_owner, "employee_id", "employee_namalengkap", Tbl_Mstemployeeowner)
                Me.Tbl_Mstemployeeowner.DefaultView.Sort = "employee_namalengkap"

            End If
            Me._LoadComboInLoadData = True
        End If
    End Sub

    Private Sub uiTrnTerimaBarang_LoadCombo()
        Dim oDataFiller As New clsDataFiller(Me.DSN)

        '-----Mulai Bikin Tabel untuk combo Data -------------------------
        If Me._LOADCOMBO = False Then

            ' Sekarang bagian yang detil
            Me.ComboFill(Me.obj_Strukturunit_id, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunitAsset, "ms_MstStrukturUnit_Select", "  ")
            Me.tbl_MstStrukturunitAsset.DefaultView.Sort = "strukturunit_name"
            Me.ComboFill(Me.obj_Tipeasset_id, "tipeasset_id", "tipeasset_id", Me.tbl_MstTipeAsset, "as_MstTipeasset_Select", "  ")
            Me.tbl_MstTipeAsset.DefaultView.Sort = "tipeasset_id"
            Me.ComboFill(Me.obj_Kategoriasset_id, "kategoriasset_id", "kategoriasset_id", Me.tbl_mstKategoriAsset, "as_MstKategoriasset_Select", "  ")
            Me.tbl_mstKategoriAsset.DefaultView.Sort = "kategoriasset_id"
            Me.ComboFill(Me.obj_Tipeitem_id, "tipeitem_id", "tipeitem_id", Me.tbl_msttipeitem, "as_MstTipeitem_Select", "  ")
            Me.tbl_msttipeitem.DefaultView.Sort = "tipeitem_id"
            Me.ComboFill(Me.obj_Kategoriitem_id, "kategoriitem_id", "kategoriitem_id", Me.tbl_mstKategoriitem, "as_MstKategoriitem_Select", "  ")
            Me.tbl_mstKategoriitem.DefaultView.Sort = "kategoriitem_id"
            Me.ComboFill(Me.obj_Jeniskelamin_id, "Pilihan", "Pilihan", Me.tbl_Mstsex, "as_MstPilihan_Select", " Kategori = 'MstsexAsset' and is_disable = 0")
            Me.tbl_Mstsex.DefaultView.Sort = "Pilihan"

            Me.ComboFill(Me.obj_Currency_id, "Currency_id", "Currency_shortname", Me.tbl_MstCurrency, "ms_MstCurrency_Select", "  Currency_active = 1")
            Me.tbl_MstCurrency.DefaultView.Sort = "Currency_shortname"

            Dim currency As Boolean
            Me.tbl_MstCurrency_header = tbl_MstCurrency.Copy
            currency = ComboFillFromDataTable(obj_Currency_id_header, "Currency_id", "Currency_shortname", tbl_MstCurrency_header)
            Me.tbl_MstCurrency_header.DefaultView.Sort = "Currency_shortname"

            Me.ComboFill(Me.obj_Warna_id, "warna_id", "warna_id", Me.tbl_Mstwarna, "as_MstWarna_Select", " ")
            Me.tbl_Mstwarna.DefaultView.Sort = "warna_id"
            Me.ComboFill(Me.obj_Material_id, "Material_id", "Material_id", Me.tbl_Mstmaterial, "as_MstMaterial_Select", " ")
            Me.tbl_Mstmaterial.DefaultView.Sort = "Material_id"

            Me.ComboFill(Me.obj_Brand_id, "merk_id", "merk_name", Me.tbl_brand, "as_MstMerk_Select", " merk_active = 1 ")
            Me.tbl_brand.DefaultView.Sort = "merk_name"

            Me.ComboFill(Me.obj_Unit_id, "unit_id", "unit_shortname", Me.tbl_unit, "AS_MstUnit_Select", " unit_active = 1 ")
            Me.tbl_unit.DefaultView.Sort = "unit_shortname"
            Me.ComboFill(Me.obj_Ukuran_id, "ukuran_id", "ukuran_id", Me.tbl_ukuran, "AS_MstUkuran_Select", "  ")
            Me.tbl_ukuran.DefaultView.Sort = "ukuran_id"
            Me.ComboFill(Me.obj_Ruang_id, "ruang_id", "keterangan", Me.tbl_MstAssetruang, "as_MstRuangAsset_Select", "  ", _CHANNEL)
            Me.tbl_MstAssetruang.DefaultView.Sort = "keterangan"
            'Me.ComboFill(Me.obj_Project_id, "budget_id", "budget_name", Me.tbl_project, "as_MstProject_Select ", " ", _CHANNEL)
            'tbl_project.DefaultView.Sort = "budget_name"
            Me.ComboFill(Me.obj_Show_id, "show_id", "show_title", Me.tbl_show, "as_MstShow_Select ", " ", _CHANNEL)
            tbl_show.DefaultView.Sort = "show_title"
            Me.ComboFill(Me.obj_Show_id_cont_item, "show_id", "show_title", Me.tbl_showcont, "as_MstShow_Select ", " ", _CHANNEL)
            tbl_showcont.DefaultView.Sort = "show_title"

            Me.ftabDataDetil.SelectedIndex = 1
            Me.ftabDataDetil.SelectedIndex = 0


            'Ini Untuk Jurnal na'

            oDataFiller.DataFillForCombo("acc_id", "acc_nameshort", Me.tbl_MstAccD, "cp_MstAcc_Select", "")
            Me.tbl_MstAccK = Me.tbl_MstAccD.Copy
            oDataFiller.DataFillForCombo("rekanan_id", "rekanan_name", Me.tbl_MstRekananGrid, "ms_MstRekanan_Select", "")
            oDataFiller.DataFillForCombo("currency_id", "currency_shortname", Me.tbl_MstCurrencyGrid, "ms_MstCurrency_Select", "")

            'end dari untuk jurnal'

            Me._LOADCOMBO = True
            '-----End Bikin Tabel untuk combo Data  ----------------------------------
        End If

    End Sub

#End Region

#Region " Buat Printing "

    Public Sub SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        e.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ASSET_DataSource_clsRptBarangDetil", objDatalistDetil))
    End Sub

    Private Sub Export(ByVal report As Microsoft.Reporting.WinForms.LocalReport)
        Dim warnings() As Microsoft.Reporting.WinForms.Warning = Nothing
        Dim stream As System.IO.Stream
        Dim deviceInfo As String = _
        "<DeviceInfo>" & _
        "  <OutputFormat>EMF</OutputFormat>" & _
        "  <PageWidth>8.27in</PageWidth>" & _
        "  <PageHeight>11.69in</PageHeight>" & _
        "  <MarginTop>0.5mm</MarginTop>" & _
        "  <MarginLeft>0.2mm</MarginLeft>" & _
        "  <MarginRight>0.2mm</MarginRight>" & _
        "  <MarginBottom>0.5mm</MarginBottom>" & _
        "</DeviceInfo>"

        m_streams = New List(Of System.IO.Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream In m_streams
            stream.Position = 0
        Next
    End Sub

    Private Function CreateStream _
    (ByVal name As String, ByVal fileNameExtension As String, _
    ByVal encoding As System.Text.Encoding, _
    ByVal mimeType As String, _
    ByVal willSeek As Boolean) As System.IO.Stream
        Dim stream As System.IO.Stream = _
        New System.IO.FileStream("AppDomain.CurrentDomain.BaseDirectory" & "Temp\" + _Name & "." & fileNameExtension, System.IO.FileMode.Create)

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
        Dim printerName As String = printSet.PrinterName
        'Dim printerName As String = "Microsoft Office Document Image Writer"

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

    Private Function uiTrnTerimaBarang_Print() As Boolean
        If Me.DgvTrnTerimabarang.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        If Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_appuser").Value = 1 Then
            Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
            Dim objDatalistHeader As ArrayList = New ArrayList()
            Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)

            objDatalistHeader = Me.GenerateDataHeader()

            Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.sptChannel_ID)
            Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
            Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
            Dim parRptTerimaBarang_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("terimabarang_id", Me.sptTerimaBarang_ID)


            objRdsH.Name = "ASSET_DataSource_clsRptBarang"
            objRdsH.Value = objDatalistHeader
            'If Me._AC = True Then
            objReportH.ReportEmbeddedResource = "ASSET.RptTerimaBarang.rdlc"
            objReportH.DataSources.Add(objRdsH)
            objReportH.EnableExternalImages = True
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptTerimaBarang_ID})

            'ElseIf Me._US Then
            '    objReportH.ReportEmbeddedResource = "ASSET.RptAdaBarang.rdlc"
            '    objReportH.DataSources.Add(objRdsH)
            '    objReportH.EnableExternalImages = True
            '    objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})

            'Else
            '    MsgBox("You can't print")
            '    Exit Function
            'End If

            AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
            Export(objReportH)

            m_currentPageIndex = 0
            Print()
            'TrnKeberadaanBarang_Print(objDatalistHeader, objRdsH, parRptImageURL)
            updateprintpbb()
        Else
            MsgBox("SPV / Sect. Head approval is required to print this document")
        End If
    End Function
    Private Function TrnKeberadaanBarang_Print() As Boolean

        '    Private Function TrnKeberadaanBarang_Print(ByVal objDatalistHeader As ArrayList, ByVal objRdsH As Microsoft.Reporting.WinForms.ReportDataSource, ByVal parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter) As Boolean
        'Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport

        'objReportH.ReportEmbeddedResource = "ASSET.RptAdaBarang.rdlc"
        'objReportH.DataSources.Add(objRdsH)
        'objReportH.EnableExternalImages = True
        'objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL})

        'AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
        'Export(objReportH)

        'm_currentPageIndex = 0
        'Print()

    End Function


    Private Function uiTrnTerimaBarang_PrintPreview() As Boolean
        If Me.DgvTrnTerimabarang.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        If Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_appuser").Value = 1 Then
            Dim terimabarang_id As String
            terimabarang_id = DgvTrnTerimabarang.CurrentRow.Cells("terimabarang_id").Value


            Dim frmPrintTerima As dlgRptTrnTerimaBarang = New dlgRptTrnTerimaBarang(Me.DSN, Me.SptServer, Me.obj_Channel_id_search.SelectedValue, Me.obj_top.Value, terimabarang_id)
            Dim frmPrintAda As dlgRptTrnAdaBarang = New dlgRptTrnAdaBarang(Me.DSN, Me.SptServer, Me.obj_Channel_id_search.SelectedValue, Me.obj_top.Value, terimabarang_id)

            Dim criteria As String = String.Empty


            frmPrintTerima.ShowInTaskbar = False
            frmPrintTerima.StartPosition = FormStartPosition.CenterParent
            frmPrintAda.ShowInTaskbar = False
            frmPrintAda.StartPosition = FormStartPosition.CenterParent

            criteria = " AND terimabarang_id = '" & terimabarang_id & "'"

            'If Me._AC = True Then
            frmPrintTerima.SetIDCriteria(criteria)
            frmPrintTerima.ShowDialog(Me)
            'ElseIf Me._US = True Then
            '    frmPrintAda.SetIDCriteria(criteria)
            '    frmPrintAda.ShowDialog(Me)
            'Else
            '    MsgBox("you can't print preview")
            'End If
        Else
            MsgBox("SPV / Sect. Head approval is required to print this document")
        End If
    End Function
#End Region

    Private Sub uiTrnTerimaBarang_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Me.tbl_TrnTerimabarangdetil.RejectChanges()
        Me.tbl_TrnTerimabarang_TempStart.Clear()
        Me.tbl_TrnTerimabarang_TempStart = Me.tbl_TrnTerimabarang_Temp.Copy
    End Sub
    Private Sub uiTrnTerimaBarang_FormBeforeNew() Handles Me.FormBeforeNew
        Me.objFormError.Clear()
    End Sub
    Private Sub uiTrnTerimaBarang_FormBeforeOpenRow(ByRef id As Object) Handles Me.FormBeforeOpenRow
        Me.objFormError.Clear()
    End Sub
    Public Sub Form_Load(ByVal sender As Object)
        Me.ToolStrip1.BackgroundImage = Me.ImageList1.Images(5)
        Me.ToolStrip1.BackgroundImageLayout = ImageLayout.Stretch

        Dim components As Control
        Dim objParameters As Collection = New Collection
        'TODO: - Extract Parameter
        '      - Assign parameter
        objParameters = Me.GetParameterCollection(Me.Parameter)

        Me.DgvTrnTerimabarang.DataSource = Me.tbl_TrnTerimabarang
        If Application.ProductName = _ProductName Then
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
            Me._CANCHANGESU = Me.GetBolValueFromParameter(objParameters, "CANCHANGESU")
            Me._PROCSU = Me.GetDecValueFromParameter(objParameters, "PROCSU")
            Me._US = Me.GetBolValueFromParameter(objParameters, "US")
            Me._SP = Me.GetBolValueFromParameter(objParameters, "SP")
            Me._PC = Me.GetBolValueFromParameter(objParameters, "PC")
            Me._AC = Me.GetBolValueFromParameter(objParameters, "AC")
            Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        End If

        'DI COMMENT KETIKA MASUK TRANSBROWSER!!!!
        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
        '    Dim dummyparameter As String = "CHANNEL=TTV;STRUKTUR_UNIT=5517;CHANNEL_CANBE_CHANGED=0;CHANNEL_CANBE_BROWSED=0;US=1;PC=1;AC=1;CANCHANGESU=0;PROCSU=5507;SU_EMPLOYEE=9002000;"
        '    objParameters = Me.GetParameterCollection(dummyparameter)
        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
        '    Me._STRUKTUR_UNIT = Me.GetValueFromParameter(objParameters, "STRUKTUR_UNIT")
        '    Me._CANCHANGESU = Me.GetBolValueFromParameter(objParameters, "CANCHANGESU")
        '    Me._PROCSU = Me.GetValueFromParameter(objParameters, "PROCSU")
        '    Me._US = Me.GetBolValueFromParameter(objParameters, "US")
        '    Me._PC = Me.GetBolValueFromParameter(objParameters, "PC")
        '    Me._AC = Me.GetBolValueFromParameter(objParameters, "AC")
        '    Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        'End If
        '--------------------------------END COMMENT KETIKA TRANSBROWSER------'

        Me.InitLayoutUI()
        Me.BindingStop()
        Me.BindingStart()

        uiTrnTerimaBarang_LoadComboSearch()
        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True
        Me.btnHome.Enabled = False

        Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").DefaultCellStyle.BackColor = Color.Lavender


        '--- ADDITIONAL IMAGE----
        ' Tambahan Button di toolstrip
        Me.btnlock.ToolTipText = "Lock Transaction"
        Me.ToolStrip1.Items.Add(Me.btnlock)
        Me.btnbarcode.ToolTipText = "Barcode"
        Me.ToolStrip1.Items.Add(Me.btnbarcode)
        Me.btnkain.ToolTipText = "Cloth Barcode"
        Me.ToolStrip1.Items.Add(Me.btnkain)
        Me.btnHome.ToolTipText = "Close"
        Me.ToolStrip1.Items.Add(Me.btnHome)
        Me.btnPicture.ToolTipText = "Picture"
        Me.ToolStrip1.Items.Add(Me.btnPicture)
        Me.btnlock.Image = Me.ImageList1.Images(0)
        Me.btnbarcode.Image = Me.ImageList1.Images(1)
        Me.btnkain.Image = Me.ImageList1.Images(2)
        Me.btnHome.Image = Me.ImageList1.Images(3)
        Me.btnPicture.Image = Me.ImageList1.Images(4)

        '--SETTING DI SEARCH PANEL---'

        Me.chk_Channel_id_search.Enabled = Me._CHANNEL_CANBE_BROWSED
        Me.chk_Channel_id_search.Checked = True
        Me.obj_Channel_id_search.Enabled = Me._CHANNEL_CANBE_BROWSED
        Me.obj_Channel_id_search.SelectedValue = Me._CHANNEL

        Me.obj_Strukturunit_id_pemilik_search.SelectedValue = Me._STRUKTUR_UNIT
        Me.chk_Strukturunit_id_pemilik_search.Checked = Not (Me._CANCHANGESU)
        Me.chk_Strukturunit_id_pemilik_search.Enabled = Me._CANCHANGESU
        Me.obj_Strukturunit_id_pemilik_search.Enabled = Me._CANCHANGESU


        '--SETTING DI MAIN PANEL---'
        'Me.obj_Channel_id.Enabled = Me._CHANNEL_CANBE_CHANGED
        Me.obj_Channel_id.Enabled = False
        Me.obj_Strukturunit_id_pemilik.Enabled = False
        Me.Panel1.Visible = False
        Me.btnlock.Enabled = False
        Me.btnPicture.Enabled = False

        Me.cmb_appprc.SelectedItem = "No"
        Me.cmb_appacc.SelectedItem = "No"
        Me.cmb_appuser.SelectedItem = "No"

        If Me._US = True Or Me._SP = True Or Me._PC = True Then
            Me.FTabItem.Visible = True
            Me.ftabDataDetil_Amount.Dispose()
            Me.TabPage3.Dispose()
            For Each components In ftabDataDetil_Amount.Controls
                components.Visible = False
            Next
        End If

        'SETTING PROC,USER ATO ACCOUNTING ATO SPV ATO SUPERUSER
        If Me._AC = True And Me._PC = True And Me._US = True And Me._SP = True Then
            Me.btnlock.Enabled = True
            For Each components In Panel1.Controls
                If components.Name <> "obj_Order_idDetil" Then
                    If components.Name <> "obj_orderdetil_line" Then
                        components.Enabled = True
                    End If
                End If
            Next
            Me.FTabItem.Visible = True
            Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = False

        ElseIf Me._AC = True Then
            Me.FTabItem.Visible = True
            Me.btnlock.Enabled = True
            Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = True
            Me.DgvTrnTerimabarangdetil.AllowUserToAddRows = False
            Me.cmb_appacc.SelectedItem = "No"
            Me.chk_Accounting_search.Checked = False
            Me.chk_Procurement_search.Checked = True
            Me.cmb_appprc.SelectedItem = "Yes"
            Me.chk_User_search.Checked = True
            Me.cmb_appuser.SelectedItem = "Yes"
            Me.obj_Status.Enabled = False
            Me.tbtnNew.Enabled = False
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True

            '---------- di ftabDataDetil_Amount -----------
            Me.obj_Currency_id_header.Enabled = False
            Me.obj_Asset_harga_header.ReadOnly = True
            Me.obj_Asset_valas_header.ReadOnly = True
            Me.obj_Asset_disc_header.ReadOnly = True
            Me.obj_Asset_pph_header.ReadOnly = True
            Me.obj_Asset_ppn_header.ReadOnly = True
            Me.obj_Asset_Insurance_header.ReadOnly = True
            Me.obj_Asset_Operator_header.ReadOnly = True
            Me.obj_Asset_Transport_header.ReadOnly = True
            Me.obj_Asset_Other_header.ReadOnly = True

            Me.FormatDgvTrnJurnaldetil(Me.DgvTrnJurnaldetil)
            Me.FormatDgvTrnJurnaldetil(Me.DgvTrnJurnaldetil_Pembayaran)
            Me.FormatDgvTrnJurnalreference(Me.DgvTrnJurnalreference)
            Me.FormatDgvTrnJurnalreference(Me.DgvTrnJurnalresponse)

        ElseIf Me._PC = True Then
            Me.btnlock.Enabled = True
            Me.DgvTrnTerimabarangdetil.Columns("asset_deskripsi").ReadOnly = True
            Me.DgvTrnTerimabarangdetil.AllowUserToAddRows = False
            Me.cmb_appprc.SelectedItem = "No"
            Me.chk_Procurement_search.Checked = False
            Me.chk_User_search.Checked = True
            Me.cmb_appuser.SelectedItem = "Yes"
            Me.obj_Status.Enabled = False
            Me.tbtnNew.Enabled = False
        ElseIf Me._SP = True Then
            Me.btnlock.Enabled = True
        End If
    End Sub

    Private Sub uiTrnTerimaBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                cek_BarcodeButton()
                'Me.btnlock.Enabled = True

                If Me._AC = True And Me._PC = True And Me._US = True And Me._SP = True Then
                    Me.btnlock.Enabled = True
                ElseIf Me._US = False Then
                    Me.btnlock.Enabled = True
                Else
                    Me.btnlock.Enabled = False
                End If

            Case 1

                uiTrnTerimaBarang_LoadCombo()
                If Me._PC = True Then
                    Me.tbtnSave.Enabled = False
                    Me.tbtnDel.Enabled = False
                ElseIf Me._AC = True Then
                    Me.tbtnDel.Enabled = False
                    Me.tbtnSave.Enabled = True
                Else
                    Me.tbtnSave.Enabled = True
                    Me.tbtnDel.Enabled = True
                End If
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White

                Me.btnlock.Enabled = False
                Me.btnbarcode.Enabled = False
                Me.btnkain.Enabled = False
                Me.btnHome.Enabled = False

                If Me.DgvTrnTerimabarang.CurrentRow IsNot Nothing Then
                    Me.uiTrnTerimaBarang_OpenRow(Me.DgvTrnTerimabarang.CurrentRow.Index)
                Else
                    Me.uiTrnTerimaBarang_NewData()
                End If

                If Me.obj_Terimabarang_id.Text <> "" Then
                    Me.DgvTrnTerimabarangdetil.Enabled = True
                Else
                    Me.DgvTrnTerimabarangdetil.Enabled = False
                    Me.Btn_Add.Enabled = False
                    Me.btn_DeleteItem.Enabled = False
                    Me.btn_bonus.Enabled = False
                End If

        End Select
    End Sub

    Private Sub DgvTrnTerimabarang_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnTerimabarang.CellClick
        Me.cek_BarcodeButton()
    End Sub

    Private Sub DgvTrnTerimabarang_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnTerimabarang.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnTerimabarang.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub

    Private Sub LoadDetilbarcodekain()
        'validasi doeloe
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim FILE_NAME As String

        Dim jenis_barcode As String = "KAIN"

        Me.filePath_shellPath(jenis_barcode)
        'If _CHANNEL = "TTV" Then
        '    FILE_NAME = Me.file_path '"G:\Wardrobe.txt"
        'Else
        '    'If _CHANNEL = "TV7" Then
        '    FILE_NAME = Me.file_path '"G:\Wardrobe2.txt"
        'End If

        FILE_NAME = Me.file_path
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
        If Me.DgvTrnTerimabarang.CurrentRow IsNot Nothing Then
            Me.uiTrnTerimaBarang_OpenRow(Me.DgvTrnTerimabarang.CurrentRow.Index)
            Dim drNews As DataRow
            For Each drNews In tbl_TrnTerimabarangdetil.Rows
                objWriter.WriteLine(drNews.Item("asset_barcode").ToString)
            Next
        Else
            MsgBox("Select Receiving Number")
        End If
        objWriter.Close()
        'If _CHANNEL = "TTV" Then
        '    Shell(shell_path, AppWinStyle.NormalFocus)
        '    'Shell("H:\Dari G part 2\Barcode Logistik\Cetak Barcode.exe", AppWinStyle.NormalFocus)
        'End If
        'If _CHANNEL = "TV7" Then
        '    Shell(shell_path, AppWinStyle.NormalFocus)
        '    'Shell("H:\Dari G part 2\Barcode Logistik\Cetak Barcode.exe", AppWinStyle.NormalFocus)
        'End If
        Shell(shell_path, AppWinStyle.NormalFocus)

        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub LoadDetilbarcode()
        'validasi doeloe
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim FILE_NAME As String
        Dim jenis_barcode As String = "BIASA"

        Me.filePath_shellPath(jenis_barcode)

        'If _CHANNEL = "TTV" Then
        '    FILE_NAME = Me.file_path '"G:\Wardrobe.txt"
        'Else
        '    'If _CHANNEL = "TV7" Then
        '    FILE_NAME = Me.file_path
        'End If

        FILE_NAME = Me.file_path
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
        If Me.DgvTrnTerimabarang.CurrentRow IsNot Nothing Then
            Me.uiTrnTerimaBarang_OpenRow(Me.DgvTrnTerimabarang.CurrentRow.Index)
            Dim drNews As DataRow
            For Each drNews In tbl_TrnTerimabarangdetil.Rows
                objWriter.WriteLine(drNews.Item("asset_barcode").ToString)
            Next
        Else
            MsgBox("Select Receiving Number")
        End If
        objWriter.Close()
        'If _CHANNEL = "TTV" Then
        '    Shell(shell_path, AppWinStyle.NormalFocus)
        '    'Shell("H:\Dari G part 2\Barcode Logistik\Cetak Barcode.exe", AppWinStyle.NormalFocus)
        'End If
        'If _CHANNEL = "TV7" Then
        '    Shell(shell_path, AppWinStyle.NormalFocus)
        '    'Shell("H:\Dari G part 2\Barcode Logistik\Cetak Barcode.exe", AppWinStyle.NormalFocus)
        'End If

        Shell(shell_path, AppWinStyle.NormalFocus)
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub LockData()
        'validasi doeloe

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        'Dim success As Boolean

        ''If Me.uiTrnTerimaBarang_FormErrorValidasi() Then
        ''    Exit Sub
        ''End If

        'success = uiTrnTerimaBarang_ValidasiAsset(Me.DgvTrnTerimabarang.Item("terimabarang_id", DgvTrnTerimabarang.CurrentRow.Index).Value, Me.DgvTrnTerimabarang.Item("channel_id", DgvTrnTerimabarang.CurrentRow.Index).Value)

        'If success = False Then
        '    Throw New Exception("Error: Barcoding Item  ")
        '    Exit Sub
        'End If

        'Me.UpdateBarcodeAfterLockData()
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_Locktransaksi_terimabarang", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimabarang.Item("terimabarang_id", DgvTrnTerimabarang.CurrentRow.Index).Value
            oCm.Parameters.Add("@accounting_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimabarang.Item("channel_id", DgvTrnTerimabarang.CurrentRow.Index).Value

            oCm.ExecuteNonQuery()
            oCm.Dispose()
            Me.obj_Terimabarang_appacc.Checked = True
            MessageBox.Show("Data Has Been Locked", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DgvTrnTerimabarang.Item("terimabarang_appacc", Me.DgvTrnTerimabarang.CurrentRow.Index).Value = 1
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        Me.uiTrnTerimaBarang_OpenRow(Me.DgvTrnTerimabarang.CurrentRow.Index)
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub LockPrcData()
        If Me.uiTrnTerimaBarang_FormErrorValidasi() Then
            Exit Sub
        End If
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_Lockprctransaksi_terimabarang_bpb", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimabarang.Item("terimabarang_id", DgvTrnTerimabarang.CurrentRow.Index).Value
            oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimabarang.Item("channel_id", DgvTrnTerimabarang.CurrentRow.Index).Value
            oCm.ExecuteNonQuery()
            oCm.Dispose()
            Me.obj_Terimabarang_appprc.Checked = True
            Me.DgvTrnTerimabarang.Item("terimabarang_appprc", DgvTrnTerimabarang.CurrentRow.Index).Value = 1
            MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default




        'Dim dlg As New dlgStatusTerimaJasa()
        'Dim status As String

        'status = dlg.OpenDialog(Me)

        'If status IsNot Nothing Then
        '    If status = "-- Pilih --" Then
        '        MsgBox("Please choose COMPLETE or INCOMPLETE")
        '        Exit Sub
        '    Else
        '        Dim success As Boolean

        '        If Me.uiTrnTerimaBarang_FormErrorValidasi() Then
        '            Exit Sub
        '        End If

        '        success = uiTrnTerimaBarang_ValidasiAsset(Me.DgvTrnTerimabarang.Item("terimabarang_id", DgvTrnTerimabarang.CurrentRow.Index).Value, Me.DgvTrnTerimabarang.Item("channel_id", DgvTrnTerimabarang.CurrentRow.Index).Value)
        '        If success = False Then
        '            Throw New Exception("Error: Barcoding Item  ")
        '            Exit Sub
        '        End If
        '        Me.UpdateBarcodeAfterLockData()

        '        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        '        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        '        Try
        '            dbConn.Open()
        '            Dim oCm As New OleDb.OleDbCommand("as_Lockprctransaksi_terimabarang", dbConn)
        '            oCm.CommandType = CommandType.StoredProcedure
        '            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimabarang.Item("terimabarang_id", DgvTrnTerimabarang.CurrentRow.Index).Value
        '            oCm.Parameters.Add("@procurement_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
        '            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimabarang.Item("channel_id", DgvTrnTerimabarang.CurrentRow.Index).Value
        '            oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 30).Value = status 'Me.DgvTrnTerimabarang.Item("status", DgvTrnTerimabarang.CurrentRow.Index).Value
        '            oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("order_id").Value
        '            oCm.ExecuteNonQuery()
        '            oCm.Dispose()
        '            Me.obj_Terimabarang_appprc.Checked = True
        '            Me.DgvTrnTerimabarang.Item("terimabarang_appprc", DgvTrnTerimabarang.CurrentRow.Index).Value = 1
        '            MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Catch ex As Data.OleDb.OleDbException
        '            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Catch ex As Exception
        '            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Finally
        '            dbConn.Close()
        '        End Try
        '    End If
        'End If
        'System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub lockUser()
        Dim dlg As New dlgStatusTerimaJasa()
        Dim status As String

        status = dlg.OpenDialog(Me)

        If status IsNot Nothing Then
            If status = "-- Pilih --" Then
                MsgBox("Please choose COMPLETE or INCOMPLETE")
                Exit Sub
            Else
                Dim success As Boolean

                If Me.uiTrnTerimaBarang_FormErrorValidasi() Then
                    Exit Sub
                End If

                success = uiTrnTerimaBarang_ValidasiAsset(Me.DgvTrnTerimabarang.Item("terimabarang_id", DgvTrnTerimabarang.CurrentRow.Index).Value, Me.DgvTrnTerimabarang.Item("channel_id", DgvTrnTerimabarang.CurrentRow.Index).Value)
                If success = False Then
                    Throw New Exception("Error: Barcoding Item  ")
                    Exit Sub
                End If
                Me.UpdateBarcodeAfterLockData()

                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
                Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                Try
                    dbConn.Open()
                    Dim oCm As New OleDb.OleDbCommand("as_LockUsertransaksi_terimabarang_bpb", dbConn)
                    oCm.CommandType = CommandType.StoredProcedure
                    oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimabarang.Item("terimabarang_id", DgvTrnTerimabarang.CurrentRow.Index).Value
                    oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
                    oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimabarang.Item("channel_id", DgvTrnTerimabarang.CurrentRow.Index).Value
                    oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 30).Value = status 'Me.DgvTrnTerimabarang.Item("status", DgvTrnTerimabarang.CurrentRow.Index).Value
                    oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("order_id").Value
                    oCm.ExecuteNonQuery()
                    oCm.Dispose()
                    Me.obj_Terimabarang_appuser.Checked = True
                    Me.DgvTrnTerimabarang.Item("terimabarang_appuser", DgvTrnTerimabarang.CurrentRow.Index).Value = 1
                    MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Data.OleDb.OleDbException
                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    dbConn.Close()
                End Try
            End If
        End If
        System.Windows.Forms.Cursor.Current = Cursors.Default


        'If Me.uiTrnTerimaBarang_FormErrorValidasi() Then
        '    Exit Sub
        'End If
        'System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        'Try
        '    dbConn.Open()
        '    Dim oCm As New OleDb.OleDbCommand("as_LockUsertransaksi_terimabarang", dbConn)
        '    oCm.CommandType = CommandType.StoredProcedure
        '    oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimabarang.Item("terimabarang_id", DgvTrnTerimabarang.CurrentRow.Index).Value
        '    oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
        '    oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimabarang.Item("channel_id", DgvTrnTerimabarang.CurrentRow.Index).Value
        '    oCm.ExecuteNonQuery()
        '    oCm.Dispose()
        '    Me.obj_Terimabarang_appuser.Checked = True
        '    Me.DgvTrnTerimabarang.Item("terimabarang_appuser", DgvTrnTerimabarang.CurrentRow.Index).Value = 1
        '    MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Catch ex As Data.OleDb.OleDbException
        '    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Catch ex As Exception
        '    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    dbConn.Close()
        'End Try
        'System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub UpdateBarcodeAfterLockData()
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oDm As New OleDb.OleDbCommand("as_TrnTerimabarangdetil_update_Barcode", dbConn)
            oDm.CommandType = CommandType.StoredProcedure
            oDm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimabarang.Item("terimabarang_id", DgvTrnTerimabarang.CurrentRow.Index).Value
            oDm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimabarang.Item("channel_id", DgvTrnTerimabarang.CurrentRow.Index).Value
            oDm.ExecuteNonQuery()
            oDm.Dispose()
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub DgvTrnTerimabarangdetil_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnTerimabarangdetil.CellClick
        Select Case e.ColumnIndex
            Case Me.DgvTrnTerimabarangdetil.Columns("asset_button").Index

                If Trim(Me.DgvTrnTerimabarangdetil.Item("asset_deskripsi", Me.DgvTrnTerimabarangdetil.CurrentRow.Index).Value) = "" Then
                    MsgBox("Insert Asset Description", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Me.Panel1.Visible = True
                Me.btnHome.Enabled = True
                Me.Panel1.Dock = DockStyle.Fill
                Me.tbtnFirst.Enabled = False
                Me.tbtnPrev.Enabled = False
                Me.tbtnNext.Enabled = False
                Me.tbtnLast.Enabled = False

                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnPrint.Enabled = False
                Me.tbtnPrintPreview.Enabled = False
                Me.tbtnNew.Enabled = False

                Me.btnPicture.Enabled = True

                If Me._AC = True Then
                    If Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_appacc").Value = 1 Then
                        Me.obj_Currency_id.Enabled = False
                        Me.obj_Asset_harga.ReadOnly = True
                        Me.obj_Asset_valas.ReadOnly = True
                        Me.obj_Asset_disc.ReadOnly = True
                        Me.obj_shadow_tipedepre.Enabled = False
                        Me.obj_Asset_ppn.ReadOnly = True
                        Me.obj_Asset_pph.ReadOnly = True
                        Me.obj_Asset_idrprice.ReadOnly = True
                        Me.obj_Asset_golfiskal.ReadOnly = True

                    Else
                        Me.obj_Currency_id.Enabled = True
                        Me.obj_Asset_harga.ReadOnly = False
                        Me.obj_Asset_valas.ReadOnly = False
                        Me.obj_Asset_disc.ReadOnly = False
                        Me.obj_shadow_tipedepre.Enabled = True
                        Me.obj_Asset_ppn.ReadOnly = False
                        Me.obj_Asset_pph.ReadOnly = False
                        Me.obj_Asset_idrprice.ReadOnly = False
                        Me.obj_Asset_golfiskal.ReadOnly = False
                    End If
                End If

                Try
                    Me.obj_Employee_id_owner.SelectedValue = Me.obj_Employee_id_pemilik.SelectedValue
                    Me.Obj_asset_channel_id.SelectedValue = Me.obj_Channel_id.SelectedValue
                    Me.obj_Strukturunit_id.SelectedValue = Me.obj_Strukturunit_id_pemilik.SelectedValue
                Catch ex As Exception

                End Try


        End Select
    End Sub

    Private Sub obj_Asset_harga_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Asset_harga.Validated
        Dim harga As Decimal = Me.obj_Asset_harga.Text
        Dim valas As Decimal = Me.obj_Asset_valas.Text
        Dim qty As Integer = Me.obj_Asset_qty.Text

        Me.obj_Asset_idrprice.Text = Format(harga * valas * qty, "#,##0.00")
    End Sub

    Private Sub obj_Asset_valas_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Asset_valas.Validated
        Dim harga As Decimal = Me.obj_Asset_harga.Text
        Dim valas As Decimal = Me.obj_Asset_valas.Text
        Dim qty As Integer = Me.obj_Asset_qty.Text

        Me.obj_Asset_idrprice.Text = Format(harga * valas * qty, "#,##0.00")
    End Sub

    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()

        tbl_Print.Clear()
        tbl_PrintDetil.Clear()
        objPrintHeader = New DataSource.clsRptBarang(Me.DSN)
        DataFill(tbl_Print, "as_TrnTerimabarang_Select", String.Format("and terimabarang_id = '{0}'", DgvTrnTerimabarang.Item("terimabarang_id", DgvTrnTerimabarang.SelectedCells.Item(0).RowIndex).Value), Me.obj_Channel_id_search.SelectedValue, Me.obj_top.Value)
        With objPrintHeader
            .channel_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("channel_id").ToString, String.Empty)
            .terimabarang_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_id").ToString, String.Empty)
            .terimabarang_tgl = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_tgl"), Now())
            .terimabarang_status = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_status").ToString, String.Empty)
            .order_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("order_id").ToString, String.Empty)
            .pa_ref = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("pa_ref").ToString, String.Empty)
            .rekanan_id = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("rekanan_id"), 0)
            .terimabarang_appacc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appacc"), 0)
            .employee_id_pemilik = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("employee_id_pemilik").ToString, String.Empty)
            .strukturunit_id_pemilik = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("strukturunit_id_pemilik"), 0)
            .accounting_applogin = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("accounting_applogin").ToString, String.Empty)
            .accounting_appdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("accounting_appdt"), Now())
            .terimabarang_appprc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_appprc"), 0)
            .procurement_applogin = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("procurement_applogin").ToString, String.Empty)
            .procurement_appdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("procurement_appdt"), Now())
            .terimabarang_cetakbpb = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_cetakbpb"), 0)
            .terimabarang_cetakbkb = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_cetakbkb"), 0)
            .terimabarang_item = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("terimabarang_item"), 0)
            .inputby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("inputby").ToString, String.Empty)
            .inputdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("inputdt"), Now())
            .editby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("editby").ToString, String.Empty)
            .editdt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("editdt"), Now())
            .usedby = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("usedby").ToString, String.Empty)
            .useddt = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("useddt"), Now())
            .user_proc = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("user_proc").ToString, String.Empty)
            .user_accounting = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("user_accounting").ToString, String.Empty)

            Me.sptChannel_ID = .channel_id
            Me.sptChannel_nameReport = .channel_namereport
            Me.sptChannel_address = .channel_address
            Me.sptTerimaBarang_ID = .terimabarang_id

            DataFill(tbl_PrintDetil, "as_TrnTerimabarangdetil_select", String.Format("And terimabarang_id = '{0}'", .terimabarang_id), Me.obj_Channel_id_search.SelectedValue, Me.obj_top.Value)
            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function

    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptBarangDetil
        Dim i As Integer

        objDatalistDetil = New ArrayList()
        For i = 0 To Me.tbl_PrintDetil.Rows.Count - 1
            objDetil = New DataSource.clsRptBarangDetil(Me.DSN)
            With objDetil
                .terimabarang_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("terimabarang_id").ToString, String.Empty)
                .asset_line = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_line"), 0)
                .channel_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("channel_id").ToString, String.Empty)
                .asset_tgl = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_tgl"), Now())
                .tipeasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("tipeasset_id").ToString, String.Empty)
                .kategoriasset_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("kategoriasset_id").ToString, String.Empty)
                .asset_barcode = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcode").ToString, String.Empty)
                .asset_lineinduk = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_lineinduk"), 0)
                .asset_barcodeinduk = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_barcodeinduk").ToString, String.Empty)
                .asset_serial = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_serial").ToString, String.Empty)
                .asset_produknumber = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_produknumber").ToString, String.Empty)
                .asset_model = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_model").ToString, String.Empty)
                .asset_deskripsi = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_deskripsi").ToString, String.Empty)
                .kategoriitem_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("kategoriitem_id").ToString, String.Empty)
                .tipeitem_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("tipeitem_id").ToString, String.Empty)
                .asset_golfiskal = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_golfiskal").ToString, String.Empty)
                .asset_tipedepre = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_tipedepre").ToString, String.Empty)
                .asset_depre_enddt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_depre_enddt"), Now())
                .currency_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("currency_id"), 0)
                .asset_harga = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_harga"), 0)
                .asset_hargabaru = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_hargabaru"), 0)
                .asset_ppn = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_ppn"), 0)
                .asset_pph = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_pph"), 0)
                .asset_disc = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_disc"), 0)
                .asset_depresiasi = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_depresiasi"), 0)
                .asset_akum_val_depre = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_akum_val_depre"), 0)
                .asset_valas = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_valas"), 0)
                .asset_idrprice = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_idrprice"), 0)
                .strukturunit_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("strukturunit_id"), 0)
                .employee_id_owner = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("employee_id_owner").ToString, String.Empty)
                .brand_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("brand_id"), 0)
                .unit_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("unit_id"), 0)
                .asset_qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_qty"), 0)
                .material_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("material_id").ToString, String.Empty)
                .warna_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("warna_id").ToString, String.Empty)
                .ukuran_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ukuran_id").ToString, String.Empty)
                .jeniskelamin_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("jeniskelamin_id").ToString, String.Empty)
                .show_id_cont_item = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("show_id_cont_item").ToString, String.Empty)
                .ruang_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ruang_id").ToString, String.Empty)
                .asset_rak = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_rak").ToString, String.Empty)
                .is_useable = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("is_useable"), 0)
                .asset_active = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_active"), 0)
                .asset_status = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_status").ToString, String.Empty)
                .project_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("project_id"), 0)
                .show_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("show_id").ToString, String.Empty)
                .asset_eps = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_eps").ToString, String.Empty)
                .wo_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("wo_id").ToString, String.Empty)
                .inputby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("inputby").ToString, String.Empty)
                .inputdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("inputdt"), Now())
                .editby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("editby").ToString, String.Empty)
                .editdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("editdt"), Now())
                .usedby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("usedby").ToString, String.Empty)
            End With
            objDatalistDetil.Add(objDetil)
        Next
    End Sub

    Private Sub updateprintpbb()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_print_terimabarang", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimabarang.Item("terimabarang_id", DgvTrnTerimabarang.CurrentRow.Index).Value
            If Me._AC = True Then
                oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 2).Value = "AC"
            ElseIf Me._US = True Or Me._SP = True Then
                oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 2).Value = "US"
            End If
            oCm.ExecuteNonQuery()
            oCm.Dispose()
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdList.Click
        Dim param As Integer = 1
        Dim dlg As New dlgListBarangNonFix(Me.DSN, _CHANNEL, param, Me._STRUKTUR_UNIT, Me.obj_Asset_barcodeinduk.Text)

        listBarcode = dlg.OpenDialog(Me)
        If listBarcode IsNot Nothing Then
            Me.obj_Asset_barcode.Text = listBarcode
            Me.obj_Asset_qty.ReadOnly = False

        End If
    End Sub
    Private Sub cmdMother_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMother.Click
        Dim param As Integer = 2
        Dim dlg As New dlgListBarangNonFix(Me.DSN, _CHANNEL, param, Me._STRUKTUR_UNIT, Me.obj_Asset_barcodeinduk.Text)
        listBarcode = dlg.OpenDialog(Me)
        If listBarcode IsNot Nothing Then
            Me.obj_Asset_barcodeinduk.Text = listBarcode
            Me.obj_Asset_tipedepre.Text = "A"
            Me.obj_Asset_lineinduk.Text = 0
            Me.obj_Asset_lineinduk.ReadOnly = True
        Else
            Me.obj_Asset_lineinduk.ReadOnly = False
            Me.obj_Asset_barcodeinduk.Text = ""
        End If
    End Sub
    Private Sub obj_shadow_tipedepre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_shadow_tipedepre.SelectedIndexChanged
        Dim a As Integer
        a = Me.obj_shadow_tipedepre.SelectedIndex
        Select Case a
            Case 0
                Me.obj_Asset_tipedepre.Text = "N"
            Case 1
                Me.obj_Asset_tipedepre.Text = "A"
            Case 2
                Me.obj_Asset_tipedepre.Text = "D"
            Case 3
                Me.obj_Asset_tipedepre.Text = "R"
        End Select
    End Sub
    Private Sub obj_Is_useable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_Is_useable.CheckedChanged
        If Me.obj_Is_useable.Checked = True Then
            Me.obj_Asset_qty.ReadOnly = False
            Me.cmdList.Visible = True
            Me.cmdMother.Visible = False
            Me.obj_Asset_barcodeinduk.Text = ""
            Me.obj_Asset_tipedepre.Text = "N"
            Me.obj_Asset_lineinduk.ReadOnly = False
        Else
            Me.obj_Asset_qty.ReadOnly = True
            Me.cmdList.Visible = False
            Me.cmdMother.Visible = True
            Me.obj_Asset_barcode.Text = ""
            Me.obj_Asset_qty.Text = 1
        End If
    End Sub

    Private Sub Btn_Category_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Category.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Kategoriitem_id, "kategoriitem_id", "kategoriitem_id", Me.tbl_mstKategoriitem, "as_MstKategoriitem_Select", "  ")
        Me.tbl_mstKategoriitem.DefaultView.Sort = "kategoriitem_id"
        Me.obj_Kategoriitem_id.DataBindings.Clear()
        Me.obj_Kategoriitem_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "kategoriitem_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_Brand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Brand.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Brand_id, "merk_id", "merk_name", Me.tbl_brand, "as_MstMerk_Select", " merk_active = 1 ")
        Me.tbl_brand.DefaultView.Sort = "merk_name"
        Me.obj_Brand_id.DataBindings.Clear()
        Me.obj_Brand_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "brand_id"))

        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_Material_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Material.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Material_id, "Material_id", "Material_id", Me.tbl_Mstmaterial, "as_MstMaterial_Select", " ")
        Me.tbl_Mstmaterial.DefaultView.Sort = "Material_id"
        Me.obj_Material_id.DataBindings.Clear()
        Me.obj_Material_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "Material_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_Room_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Room.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Ruang_id, "ruang_id", "keterangan", Me.tbl_MstAssetruang, "as_MstRuangAsset_Select", "  ", _CHANNEL)
        Me.tbl_MstAssetruang.DefaultView.Sort = "keterangan"
        Me.obj_Ruang_id.DataBindings.Clear()
        Me.obj_Ruang_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "ruang_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_Show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Show.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Show_id, "show_id", "show_title", Me.tbl_show, "as_MstShow_Select ", " ", _CHANNEL)
        tbl_show.DefaultView.Sort = "show_title"
        Me.obj_Show_id.DataBindings.Clear()
        Me.obj_Show_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "show_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_Type_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Type.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Tipeitem_id, "tipeitem_id", "tipeitem_id", Me.tbl_msttipeitem, "as_MstTipeitem_Select", "  ")
        Me.tbl_msttipeitem.DefaultView.Sort = "tipeitem_id"
        Me.obj_Tipeitem_id.DataBindings.Clear()
        Me.obj_Tipeitem_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "tipeitem_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Color.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Warna_id, "warna_id", "warna_id", Me.tbl_Mstwarna, "as_MstWarna_Select", " ")
        Me.tbl_Mstwarna.DefaultView.Sort = "warna_id"
        Me.obj_Warna_id.DataBindings.Clear()
        Me.obj_Warna_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "warna_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_Size_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Size.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Ukuran_id, "ukuran_id", "ukuran_id", Me.tbl_ukuran, "AS_MstUkuran_Select", "  ")
        Me.tbl_ukuran.DefaultView.Sort = "ukuran_id"
        Me.obj_Ukuran_id.DataBindings.Clear()
        Me.obj_Ukuran_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "ukuran_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_BudgetNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BudgetNo.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Project_id, "budget_id", "budget_name", Me.tbl_project, "as_MstProject_Select ", " ", _CHANNEL)
        tbl_project.DefaultView.Sort = "budget_name"
        Me.obj_Project_id.DataBindings.Clear()
        Me.obj_Project_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "project_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default

        Me.Obj_asset_No_budget.Text = 0
    End Sub
    Private Sub Btn_ContShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ContShow.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Show_id_cont_item, "show_id", "show_title", Me.tbl_showcont, "as_MstShow_Select ", " ", _CHANNEL)
        tbl_showcont.DefaultView.Sort = "show_title"
        Me.obj_Show_id_cont_item.DataBindings.Clear()
        Me.obj_Show_id_cont_item.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "show_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub


    Private Sub obj_Project_id_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Project_id.SelectionChangeCommitted
        Me.Obj_asset_No_budget.Text = clsUtil.IsDbNull(Me.obj_Project_id.SelectedValue, 0)
    End Sub

    Private Sub Obj_asset_No_budget_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Obj_asset_No_budget.Validated
        Dim criteria As String = String.Empty
        Dim budget As DataTable = New DataTable

        If Me.Obj_asset_No_budget.Text = String.Empty Then
            Exit Sub
        End If
        criteria = String.Format("and budget_id = " & Me.Obj_asset_No_budget.Text)
        Me.DataFill(budget, "as_MstProject_Select", criteria, Me._CHANNEL)

        If budget.Rows.Count <= 0 Then
            Me.obj_Project_id.SelectedValue = 0
            Me.Obj_asset_No_budget.Text = 0
        Else
            Me.obj_Project_id.SelectedValue = clsUtil.IsDbNull(budget.Rows(0).Item("budget_id"), 0)
        End If

    End Sub

    Private Sub cek_BarcodeButton()
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 0 Then
            If Me.DgvTrnTerimabarang.Rows.Count > 0 Then
                If Me.DgvTrnTerimabarang.CurrentRow.Cells("terimabarang_appacc").Value = 1 Then
                    Me.btnbarcode.Enabled = True
                    Me.btnkain.Enabled = True
                Else
                    Me.btnbarcode.Enabled = False
                    Me.btnkain.Enabled = False
                End If
            End If
        End If


    End Sub

    Private Sub obj_Currency_id_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Currency_id.SelectedValueChanged

    End Sub

    Private Sub obj_Terimabarang_status_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Terimabarang_status.SelectedValueChanged
        Me.select_nomor_PO()
    End Sub

    Private Sub select_nomor_PO()
        Dim criteria As String = String.Empty
        Dim tbl_RO As DataTable = New DataTable

        If Me.obj_Terimabarang_status.SelectedItem = "PO" Then
            'Me.obj_Order_id.Enabled = True
            Me.btn_order.Enabled = True
            Me.obj_Rekanan_id.Enabled = False
            If Me.obj_Terimabarang_id.Text <> "AUTO" Then
                Me.Btn_Add.Enabled = True
                Me.btn_bonus.Enabled = True
                Me.btn_DeleteItem.Enabled = True
            Else
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
            End If
            Me.obj_Terimabarang_type.Text = "PURCHASE"
        Else
            Me.obj_Order_id.Text = String.Empty
            'Me.obj_Order_id.Enabled = False
            Me.btn_order.Enabled = False
            Me.obj_Rekanan_id.Enabled = True
            Me.obj_Rekanan_id.SelectedValue = 0
            If Me.obj_Terimabarang_id.Text <> "AUTO" Then
                Me.Btn_Add.Enabled = True
                Me.btn_bonus.Enabled = True
                Me.btn_DeleteItem.Enabled = True
            Else
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
            End If
            Me.obj_Terimabarang_type.Text = ""
        End If
    End Sub

    Private Sub obj_Currency_id_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Currency_id.SelectionChangeCommitted
        Dim currency As String
        Dim tbl_mst_exrate As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        'Try
        If Me._LOADCOMBO = True Then
            If Panel1.Visible = True Then
                currency = Me.obj_Currency_id.Text
                tbl_mst_exrate.Clear()
                DataFill(tbl_mst_exrate, "as_MstExRate_Select", String.Format("exrate_currency = '{0}'", currency))
                If tbl_mst_exrate.Rows.Count <= 0 Then
                    MsgBox("Sorry")
                    Me.obj_Asset_valas.Text = 0
                Else
                    Me.obj_Asset_valas.Text = Format(tbl_mst_exrate.Rows(0)("exrate_buy"), "#,##0.00")
                End If
            End If
        End If
        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub obj_Currency_id_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Currency_id.Validated
        Dim harga As Decimal = Me.obj_Asset_harga.Text
        Dim valas As Decimal = Me.obj_Asset_valas.Text

        Me.obj_Asset_idrprice.Text = Format(harga * valas, "#,##0.00")
    End Sub

    Private Sub DgvTrnTerimabarang_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnTerimabarang.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)

        Try
            If objrow.Cells("terimabarang_appprc").Value = 0 And objrow.Cells("terimabarang_appacc").Value = 0 Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            ElseIf objrow.Cells("terimabarang_appprc").Value = 1 And objrow.Cells("terimabarang_appacc").Value = 1 Then
                objrow.DefaultCellStyle.BackColor = Color.PowderBlue
            Else
                objrow.DefaultCellStyle.BackColor = Color.Bisque
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub filePath_shellPath(ByVal jenis_barcode As String)
        Dim criteria As String = String.Empty
        Dim tbl_setting_path As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        criteria = String.Format("  channel_id = '{0}' AND jenis_barcode = '{1}'", Me._CHANNEL, jenis_barcode)
        Try
            tbl_setting_path.Clear()
            DataFill(tbl_setting_path, "as_Setting_Path_Select", criteria)
            If tbl_setting_path.Rows.Count > 0 Then
                file_path = clsUtil.IsDbNull(tbl_setting_path.Rows(0).Item("file_path"), String.Empty)
                shell_path = clsUtil.IsDbNull(tbl_setting_path.Rows(0).Item("shell_path"), String.Empty)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DgvTrnTerimabarangdetil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnTerimabarangdetil.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim click As DataGridView.HitTestInfo = Me.DgvTrnTerimabarangdetil.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnTerimabarangdetil.CurrentCell = Me.DgvTrnTerimabarangdetil.Rows(click.RowIndex).Cells(click.ColumnIndex)
            End If
        End If
    End Sub

    Private Sub CopyItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyItemToolStripMenuItem.Click
        If Panel3.Enabled = True Then
            Me.copy_induk_child(0)
        Else
            MsgBox("Data has been lock")
        End If
    End Sub

    Private Sub CopyWihChildToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyWihChildToolStripMenuItem.Click
        If Panel3.Enabled = True Then
            Me.copy_induk_child(1)
        Else
            MsgBox("Data has been lock")
        End If
    End Sub

    Private Sub copy_induk_child(ByVal isChild As Byte)
        Dim tbl_trnTerimabarangdetil_temps As DataTable = New DataTable
        Dim criteria As String = String.Empty
        Dim row_Array() As DataRow
        Dim row_temps As DataRow
        Dim rowIndex, colIndex As Integer
        Dim columnName As String
        Dim oDataFiller As clsDataFiller = New clsDataFiller(Me.DSN)

        'Untuk ngecek ini data dari tabel atau dataset
        Dim criterias As String = String.Empty
        Dim tabel_temps As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        criterias = String.Format(" AND terimabarang_id = '{0}' AND asset_line = {1}", Me.DgvTrnTerimabarangdetil.Rows(Me.DgvTrnTerimabarangdetil.CurrentRow.Index).Cells("terimabarang_id").Value, _
                        Me.DgvTrnTerimabarangdetil.Rows(Me.DgvTrnTerimabarangdetil.CurrentRow.Index).Cells("asset_line").Value)
        Try
            tabel_temps.Clear()
            DataFill(tabel_temps, "as_TrnTerimabarangdetil_Select", criterias, Me._CHANNEL, obj_top.Value)
        Catch ex As Exception
        End Try

        Dim tbl_temporaryInduk As DataTable = New DataTable
        Dim tbl_temporaryChild As DataTable = New DataTable

        tbl_trnTerimabarangdetil_temps.Clear()
        tbl_trnTerimabarangdetil_temps = Me.tbl_TrnTerimabarangdetil.GetChanges()

        tbl_temporaryInduk.Clear()
        If tabel_temps.Rows.Count > 0 Then
            tbl_temporaryInduk = tbl_TrnTerimabarangdetil
        ElseIf tbl_trnTerimabarangdetil_temps IsNot Nothing Then
            tbl_temporaryInduk = tbl_trnTerimabarangdetil_temps
        Else
            Exit Sub
        End If

        'Buat masukkin data Mother(induk na)
        If tbl_temporaryInduk.Rows.Count > 0 Then
            criteria = String.Format("asset_line = {0}", Me.DgvTrnTerimabarangdetil.Rows(Me.DgvTrnTerimabarangdetil.CurrentRow.Index).Cells("asset_line").Value)
            row_Array = tbl_temporaryInduk.Select(criteria)

            motherTbl.Clear()
            For rowIndex = 0 To row_Array.Length - 1
                row_temps = motherTbl.NewRow
                For colIndex = 0 To tbl_temporaryInduk.Columns.Count - 1
                    Try
                        columnName = tbl_temporaryInduk.Columns(colIndex).ColumnName
                        If columnName = "asset_line" Then
                            row_temps(columnName) = tbl_temporaryInduk.Rows(tbl_temporaryInduk.Rows.Count - 1).Item("asset_line") + 1
                        ElseIf columnName = "asset_serial" Or columnName = "asset_produknumber" Or columnName = "asset_model" Or columnName = "asset_barcode" Then
                            row_temps(columnName) = ""
                        Else
                            row_temps(columnName) = row_Array(rowIndex).Item(colIndex)
                        End If
                    Catch ex As Exception
                    End Try
                Next
                motherTbl.Rows.Add(row_temps)
            Next
            Me.tbl_TrnTerimabarangdetil.Merge(motherTbl, False)
        End If

        'Buat Masukkan data semua anak-anak na dari induk yang dicopy
        If isChild = 1 Then
            tbl_temporaryChild.Clear()
            If tabel_temps.Rows.Count > 0 Then
                tbl_temporaryChild = tbl_TrnTerimabarangdetil
            ElseIf tbl_trnTerimabarangdetil_temps IsNot Nothing Then
                tbl_temporaryChild = tbl_trnTerimabarangdetil_temps
            Else
                Exit Sub
            End If

            If tbl_temporaryChild.Rows.Count > 0 Then
                criteria = String.Format(" asset_lineinduk = {0}", Me.DgvTrnTerimabarangdetil.Rows(Me.DgvTrnTerimabarangdetil.CurrentRow.Index).Cells("asset_line").Value)
                row_Array = tbl_temporaryChild.Select(criteria)

                'childTbl.Clear()
                For rowIndex = 0 To row_Array.Length - 1
                    childTbl.Clear()
                    row_temps = childTbl.NewRow
                    For colIndex = 0 To tbl_temporaryChild.Columns.Count - 1
                        Try
                            columnName = tbl_temporaryChild.Columns(colIndex).ColumnName
                            If columnName = "asset_line" Then
                                row_temps(columnName) = tbl_temporaryChild.Rows(tbl_temporaryChild.Rows.Count - 1).Item("asset_line") + 1
                            ElseIf columnName = "asset_lineinduk" Then
                                row_temps(columnName) = Me.motherTbl.Rows(0).Item("asset_line")
                            ElseIf columnName = "asset_serial" Or columnName = "asset_produknumber" Or columnName = "asset_model" Then
                                row_temps(columnName) = ""
                            Else
                                row_temps(columnName) = row_Array(rowIndex).Item(colIndex)
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    childTbl.Rows.Add(row_temps)
                    Me.tbl_TrnTerimabarangdetil.Merge(childTbl)
                Next
                'Me.tbl_TrnTerimabarangdetil.Merge(childTbl)
            End If
        End If

    End Sub

    Private Sub obj_Order_id_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim poNumber As String
        'Dim tbl_order As New DataTable
        'Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        ''Try
        'If Me._LOADCOMBO = True Then
        '    If obj_Order_id.Enabled = True Then
        '        poNumber = Me.obj_Order_id.SelectedValue
        '        tbl_order.Clear()
        '        DataFill(tbl_order, "as_TrnOrder_Select", String.Format("order_id = '{0}'", poNumber))
        '        If tbl_order.Rows.Count <= 0 Then
        '            MsgBox("Sorry")
        '            Me.obj_Asset_valas.Text = 0
        '        Else
        '            Me.obj_Rekanan_id.SelectedValue = tbl_order.Rows(0)("rekanan_id")
        '        End If
        '    End If
        'End If
        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub Btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Add.Click
        Dim criteria As String = String.Empty
        Dim i As Integer
        Dim row As DataRow
        Dim rowCount As Integer

        Dim poNumber As String
        Dim tbl_TrnOrder As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim desc As String
        Dim rowDetil As DataRow

        If Me.DgvTrnTerimabarangdetil.Rows.Count = 1 Then
            criteria = "(" & Me.tbl_TrnTerimabarangdetil.Rows(i).Item("orderdetil_line") & ")"
            'criteria = "(" & Me.DgvTrnTerimabarangdetil.Rows(i).Cells("orderdetil_line").Value & ")"
        Else
            For i = 0 To Me.DgvTrnTerimabarangdetil.Rows.Count - 1
                If criteria = String.Empty Then
                    criteria = clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(i).Item("orderdetil_line"), String.Empty)
                    'criteria = clsUtil.IsDbNull(Me.DgvTrnTerimabarangdetil.Rows(i).Cells("orderdetil_line").Value, String.Empty)
                Else
                    If Me.tbl_TrnTerimabarangdetil.Rows(i).Item("orderdetil_line") IsNot DBNull.Value Then
                        If Me.DgvTrnTerimabarangdetil.Rows(i).Cells("orderdetil_line").Value IsNot DBNull.Value Or _
                            Me.DgvTrnTerimabarangdetil.Rows(i).Cells("orderdetil_line").Value IsNot Nothing Then
                            'If Me.tbl_TrnTerimabarangdetil.Rows(i).Item("orderdetil_line") IsNot Nothing Then
                            criteria &= ", " & Me.tbl_TrnTerimabarangdetil.Rows(i).Item("orderdetil_line")
                            'criteria &= ", " & Me.DgvTrnTerimabarangdetil.Rows(i).Cells("orderdetil_line").Value
                        End If
                    End If
                End If
            Next
            If criteria <> String.Empty Then
                criteria = "(" & criteria & ")"
            End If
        End If


        Dim dlg As New dlgListPO(Me.DSN, Me.obj_Order_id.Text, criteria, "PO")
        Dim dlg2 As New dlgAddItem_TrmBarang()

        If Me.obj_Terimabarang_status.SelectedItem = "PO" Then
            Me.tbl_retOrderDetil = dlg.OpenDialog(Me)
            If Me.tbl_retOrderDetil IsNot Nothing Then
                Dim count_orderdetil As Integer
                Dim row_index As Integer
                count_orderdetil = Me.tbl_retOrderDetil.Rows.Count - 1

                For row_index = 0 To count_orderdetil
                    Me.obj_orderdetil_line.Text = Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_line")
                    Me.obj_Order_idDetil.Text = Me.obj_Order_id.Text

                    rowCount = Me.DgvTrnTerimabarangdetil.Rows.Count
                    row = Me.tbl_TrnTerimabarangdetil.NewRow
                    Me.tbl_TrnTerimabarangdetil.Rows.Add(row)

                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("order_id") = Me.obj_Order_id.Text
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("orderdetil_line") = Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_line")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_deskripsi") = Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_descr")

                    'Me.obj_Qty_PO.Text = Val(Me.obj_Qty_PO.Text) + clsUtil.IsDbNull(CInt(Me.tbl_retOrderDetil.Rows(0).Item("orderdetil_qty")), 0)
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("unit_id") = Me.tbl_retOrderDetil.Rows(row_index).Item("unit_id")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("currency_id") = Me.tbl_retOrderDetil.Rows(row_index).Item("currency_id")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc") = Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_discount")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_ppn") = Val((Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_days") * Val(Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_qty"))) * Val((Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_foreignrate")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc")))) * Val(Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_ppnpercent")) / 100
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_pph") = Val((Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_days") * Val(Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_qty"))) * Val((Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_foreignrate")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc")))) * Val(Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_pphpercent")) / 100
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_valas") = Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_foreignrate")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_idrprice") = Val((Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_days") * Val(Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_qty"))) * Val((Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_foreignrate")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc")))) + Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_pph"))
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_harga") = Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_foreign")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("project_id") = Me.tbl_retOrderDetil.Rows(row_index).Item("budget_id")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_qty") = Me.tbl_retOrderDetil.Rows(row_index).Item("orderdetil_qty")

                    If Me.DgvTrnTerimabarangdetil.Rows.Count <> 0 Then
                        Me.obj_Terimabarang_status.Enabled = False
                        'Me.obj_Order_id.Enabled = False
                        Me.btn_order.Enabled = False
                    End If

                    If Me.DgvTrnTerimabarangdetil.Rows.Count = 1 Then
                        poNumber = Me.obj_Order_id.Text
                        tbl_TrnOrder.Clear()
                        DataFill(tbl_TrnOrder, "as_TrnOrder_Select", String.Format("order_id = '{0}'", poNumber))
                        If tbl_TrnOrder.Rows.Count > 0 Then
                            Me.obj_Asset_Insurance_header.Text = Format(tbl_TrnOrder.Rows(row_index).Item("order_insurancecost"), "#,##0.00")
                            Me.obj_Asset_Transport_header.Text = Format(tbl_TrnOrder.Rows(row_index).Item("order_transportationcost"), "#,##0.00")
                            Me.obj_Asset_Operator_header.Text = Format(tbl_TrnOrder.Rows(row_index).Item("order_operatorcost"), "#,##0.00")
                            Me.obj_Asset_Other_header.Text = Format(tbl_TrnOrder.Rows(row_index).Item("order_othercost"), "#,##0.00")
                        End If
                    End If
                Next
                Me.uiTrnTerimaBarang_Save()
            End If
        Else
            desc = dlg2.OpenDialog(Me)
            If desc IsNot Nothing Then
                rowDetil = Me.tbl_TrnTerimabarangdetil.NewRow
                rowDetil("asset_deskripsi") = desc
                Me.tbl_TrnTerimabarangdetil.Rows.Add(rowDetil)

                If Me.DgvTrnTerimabarangdetil.RowCount > 0 Then
                    Me.obj_Terimabarang_status.Enabled = False
                    'Me.obj_Order_id.Enabled = False
                    Me.btn_order.Enabled = False
                    'Me.obj_Status.Enabled = False
                    Me.obj_Rekanan_id.Enabled = False
                End If
            End If
        End If
        Me.tampil_status_PO_MANUAL()
    End Sub



    Private Sub btn_bonus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bonus.Click
        Dim dlg2 As New dlgAddItem_TrmBarang()
        Dim desc As String
        Dim rowDetil As DataRow

        desc = dlg2.OpenDialog(Me)
        If desc IsNot Nothing Then
            rowDetil = Me.tbl_TrnTerimabarangdetil.NewRow
            rowDetil("asset_deskripsi") = desc
            Me.tbl_TrnTerimabarangdetil.Rows.Add(rowDetil)

            If Me.DgvTrnTerimabarangdetil.RowCount > 0 Then
                Me.obj_Terimabarang_status.Enabled = False
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
                'Me.obj_Status.Enabled = False
                Me.obj_Rekanan_id.Enabled = False
            End If
            Me.tampil_status_PO_MANUAL()
        End If
    End Sub


    Private Sub obj_Asset_qty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Asset_qty.Validated
        If Me.obj_Is_useable.Checked = True Then
            Dim tbl_trnOrderdetil_temps As DataTable = New DataTable

            tbl_trnOrderdetil_temps.Clear()
            tbl_trnOrderdetil_temps.Clear()
            DataFill(tbl_trnOrderdetil_temps, "as_TrnOrderdetil_Select", String.Format("order_id = '{0}' AND orderdetil_line = {1} ", Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimabarangdetil.CurrentRow.Index).Item("order_id"), Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimabarangdetil.CurrentRow.Index).Item("orderdetil_line")))
            If tbl_trnOrderdetil_temps.Rows.Count > 0 Then
                If Me.obj_Asset_qty.Text > tbl_trnOrderdetil_temps.Rows(0).Item("orderdetil_qty") Then
                    MsgBox("Your quantity is over from quantity in PO")
                    Me.obj_Asset_qty.Text = 1
                End If
            End If

        End If
    End Sub

    Private Sub FTabItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FTabItem.SelectedIndexChanged
        If Me._AC = True Then
            Select Case FTabItem.SelectedIndex
                Case 0
                    Me.FTabItem.TabPages.Item(0).BackColor = Color.LightSkyBlue
                    Me.FTabItem.TabPages.Item(1).BackColor = Color.Gainsboro
                Case 1
                    Me.FTabItem.TabPages.Item(0).BackColor = Color.Gainsboro
                    Me.FTabItem.TabPages.Item(1).BackColor = Color.LightSkyBlue
            End Select
        End If
    End Sub


    Private Sub btn_DeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DeleteItem.Click
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_TrnTerimabarangdetil_deleteItem", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvTrnTerimabarangdetil.Rows(Me.DgvTrnTerimabarangdetil.CurrentRow.Index).Cells("terimabarang_id").Value
            oCm.Parameters.Add("@asset_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvTrnTerimabarangdetil.Rows(Me.DgvTrnTerimabarangdetil.CurrentRow.Index).Cells("asset_line").Value
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me._CHANNEL
            oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvTrnTerimabarangdetil.Rows(Me.DgvTrnTerimabarangdetil.CurrentRow.Index).Cells("order_id").Value
            oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvTrnTerimabarangdetil.Rows(Me.DgvTrnTerimabarangdetil.CurrentRow.Index).Cells("orderdetil_line").Value
            oCm.Parameters.Add("@is_bpj", System.Data.OleDb.OleDbType.VarWChar, 20).Value = "BARANG"
            oCm.ExecuteNonQuery()
            oCm.Dispose()
            Me.uiTrnTerimaBarang_OpenRow(Me.DgvTrnTerimabarang.CurrentRow.Index)
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
    End Sub


    Private Sub tampil_status_PO_MANUAL()
        Dim i As Integer
        Dim countDgv As Integer

        countDgv = Me.DgvTrnTerimabarangdetil.Rows.Count - 1

        For i = 0 To countDgv

            If Mid(Me.DgvTrnTerimabarangdetil.Rows(i).Cells("order_id").Value, 1, 2) = "PO" Then
                Me.DgvTrnTerimabarangdetil.Rows(i).Cells("status_po").Value = "PO"
            Else
                Me.DgvTrnTerimabarangdetil.Rows(i).Cells("status_ro").Value = "MANUAL"
            End If
        Next
    End Sub


    Private Sub btn_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_order.Click
        Dim tabels As DataTable = New DataTable
        Dim criteria As String = String.Empty
        Dim names As String = "BPB Status"


        criteria = "PO"
        Dim dlg As New DlgBpjSelectOrder(Me.DSN, criteria, Me._STRUKTUR_UNIT, names)

        tabels = dlg.OpenDialog(Me)

        If tabels IsNot Nothing Then
            'MsgBox(tabels.Rows(0).Item("order_id").ToString)
            Me.obj_Order_id.Text = tabels.Rows(0).Item("order_id").ToString
            Me.search_vendor(tabels.Rows(0).Item("order_id").ToString)
        End If
    End Sub
    Private Sub search_vendor(ByVal order_id_search As String)

        Dim tbl_order As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        'Try
        If Me._LOADCOMBO = True Then
            If btn_order.Enabled = True Then
                tbl_order.Clear()
                DataFill(tbl_order, "as_TrnOrder_Select", String.Format("order_id = '{0}'", order_id_search))
                If tbl_order.Rows.Count <= 0 Then
                    MsgBox("Sorry")
                    Me.obj_Asset_valas.Text = 0
                Else
                    Me.obj_Rekanan_id.SelectedValue = tbl_order.Rows(0)("rekanan_id")
                End If
            End If
        End If
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub builtJurnal()
        Dim rows_debet, rows_kredit, rows_reference As Integer
        Dim order_id As String
        Dim tbl_orderTemp As DataTable = New DataTable
        Dim tbl_debetTemp As DataTable = New DataTable
        Dim table_mstArtisDetil As DataTable = New DataTable
        Dim criteria As String = String.Empty

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim tbl_pajak_pph21 As DataTable = New DataTable
        ' ''Dim g As Integer
        ' ''Dim requestdetil_foreignreal, requestdetil_foreignrate, requestdetil_qty, requestdetil_eps As Decimal
        ' ''Dim Temp_subtotal As Decimal
        ' ''Dim persen As Integer
        ' ''Dim temp_perhitungan As Decimal

        Dim jumlah_awal As Decimal = 0
        Dim jumlah_sisa As Decimal = 0
        Dim bayar_artis As Decimal = 0
        Dim bayar_pajak As Decimal = 0
        Dim bayar_total As Decimal = 0
        Dim bayar_sisa As Decimal = 0
        Dim pajak_gross As Decimal = 0
        Dim amountWithTax As Decimal = 0

        Dim jumlah_awal_ada As Decimal = 0
        Dim bayar_artis_ada As Decimal = 0
        Dim bayar_pajak_ada As Decimal = 0
        Dim bayar_total_ada As Decimal = 0
        Dim bayar_sisa_ada As Decimal = 0
        Dim pajak_gross_ada As Decimal = 0
        Dim amountWithTax_ada As Decimal = 0
        ' ''Dim persen_ada As Integer

        Dim persens(10) As Integer
        Dim minimal(10) As Decimal
        Dim maksimal(10) As Decimal
        Dim quota(10) As Decimal
        Dim sisa_quota As Decimal = 0
        Dim tax As Decimal = 0
        ' ''Dim z As Integer

        ' ''Dim Looping As Integer

        Me.uiTrnTerimaJasa_OpenRowJurnalDetil(Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("channel_id").Value, Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_id").Value, dbConn)
        Me.uiTrnTerimaJasa_OpenRowJurnalDetil_pembayaran(Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("channel_id").Value, Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_id").Value, dbConn)


        Me.tbl_TrnTerimabarangdetil.Clear()
        Me.DataFill(Me.tbl_TrnTerimabarangdetil, "as_TrnTerimabarangdetil_Select", String.Format(" AND terimabarang_id = '{0}'", Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_id").Value), Me._CHANNEL, 100%)
        If Me.tbl_TrnTerimabarangdetil.Rows.Count > 0 Then
            order_id = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("order_id")
            For rows_debet = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                If criteria = String.Empty Then
                    criteria = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("orderdetil_line")
                Else
                    criteria &= ", " & Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("orderdetil_line")
                End If
            Next

            criteria = String.Format(" order_id = '{0}' AND orderdetil_line in ( {1} )", order_id, criteria)
            tbl_orderTemp.Clear()
            tbl_debetTemp.Clear()
            tbl_TrnJurnal.Clear()

            Me.DataFill(tbl_orderTemp, "as_TrnOrderDetilJurnalBPB_Select", criteria)
            Me.DataFill(tbl_debetTemp, "cp_MstAcc_SelectBySource", String.Format("B.source_id = 'RV-ListBpj' AND B.dk = 'K' WHERE B.source_id = 'RV-ListBpj' AND B.dk = 'K'"))

            '============ Mulai masukkan data ke tab bagian Debet Na =======
            For rows_debet = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                tbl_orderTemp.Clear()
                criteria = String.Format(" order_id = '{0}' AND orderdetil_line = {1} ", order_id, Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("orderdetil_line"))
                Me.DataFill(tbl_orderTemp, "as_TrnOrderDetilJurnalBPB_Select", criteria)
                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Add()
                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("acc_id") = tbl_orderTemp.Rows(0).Item("acc_id")
                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreignrate") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                If Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("currency_id") = 1 Then
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_idrprice"))
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_idrprice"))
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi") & " " & Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_barcode")
                Else
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"))
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", String.Format("{0:#,##0}", tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_idrprice")))
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi") & " " & Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_barcode")
                End If
                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("currency_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("currency_id")
                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
            Next
            '============ Akhir dari masukkan data ke tab bagian Debet ===========

            '============ Mulai masukkan data ke tab bagian Kredit Na =======
            For rows_kredit = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                Me.tbl_TrnJurnaldetil.Rows.Add()
                Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreignrate") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_valas")
                If Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("currency_id") = 1 Then
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_idrprice"))
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_idrprice"))
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_deskripsi") & " " & Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_barcode")
                Else
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"))
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_idrprice"))
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_deskripsi") & " " & Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_barcode")
                End If
                Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("currency_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("currency_id")
                Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
            Next
            '============ Akhir dari masukkan data ke tab bagian Kredit ===========

            '============ Mulai masukkan data ke tab bagian Reference Na =======
            For rows_reference = 0 To tbl_orderTemp.Rows.Count - 1
                Me.tbl_JurnalReference.Rows.Add()
                Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id") = Mid(Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_ref") = tbl_orderTemp.Rows(rows_reference).Item("order_id")
                Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_refline") = tbl_orderTemp.Rows(rows_reference).Item("orderdetil_line")
            Next
            '============ Akhir dari masukkan data ke tab Reference Kredit ===========

            '============ Mulai masukkan data ke tabel bagian Header Na =======
            If tbl_orderTemp.Rows.Count > 0 Then
                Me.tbl_TrnJurnal.Rows.Add()
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Mid(Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimabarang.Rows(Me.DgvTrnTerimabarang.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.obj_Notes.Text
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisabled") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createby") = Me.UserName
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createdate") = Now()
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifyby") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifydate") = DBNull.Value
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postby") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postdate") = DBNull.Value
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_duedate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_faktur") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-ListBpj"
                Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id") = "RV"
                Me.tbl_TrnJurnal.Rows(0).Item("channel_id") = Me._CHANNEL
                Me.tbl_TrnJurnal.Rows(0).Item("region_id") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("branch_id") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = 0
                Me.tbl_TrnJurnal.Rows(0).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                Me.tbl_TrnJurnal.Rows(0).Item("sub1_id") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("sub2_id") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = String.Format("{0:yyMM}", Now)
                Me.tbl_TrnJurnal.Rows(0).Item("acc_id") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("invoice_descr") = String.Empty
                Me.tbl_TrnJurnal.Rows(0).Item("jurnal_billdate") = Now.Date
                Me.tbl_TrnJurnal.Rows(0).Item("acc_ca_id") = 0
            End If
            '============ Akhir dari masukkan data ke tabel Header ===========
            Dim x As Integer
            Dim isAcc_ok As String
            For x = 0 To Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Count - 1
                If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(x).Item("acc_id"), "") = "" Then
                    isAcc_ok = "not"
                Else
                    isAcc_ok = "ok"
                End If
            Next
            If isAcc_ok = "ok" Then
                Me.uiTrnJurnal_Save()
            End If
        End If

    End Sub

    Private Function uiTrnJurnal_Save() As Boolean
        'save data
        Dim tbl_TrnJurnal_Changes As DataTable
        Dim tbl_JurnalReference_Changes As DataTable
        Dim tbl_TrnJurnaldetil_Changes As DataTable
        Dim tbl_TrnJurnaldetil_Pembayaran_Changes As DataTable
        Dim success As Boolean
        Dim jurnal_id As Object = New Object
        Dim channel_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeSave(jurnal_id)

        Me.BindingContext(Me.tbl_TrnJurnal).EndCurrentEdit()

        Me.DgvTrnJurnaldetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnJurnaldetil).EndCurrentEdit()
        tbl_TrnJurnaldetil_Changes = Me.tbl_TrnJurnaldetil.GetChanges()

        Me.DgvTrnJurnaldetil_Pembayaran.EndEdit()
        Me.BindingContext(Me.tbl_TrnJurnaldetil_JdwPembayaran).EndCurrentEdit()
        tbl_TrnJurnaldetil_Pembayaran_Changes = Me.tbl_TrnJurnaldetil_JdwPembayaran.GetChanges()

        Me.BindingContext(Me.tbl_TrnJurnal).EndCurrentEdit()
        tbl_TrnJurnal_Changes = Me.tbl_TrnJurnal.GetChanges()

        Me.BindingContext(Me.tbl_JurnalReference).EndCurrentEdit()
        tbl_JurnalReference_Changes = Me.tbl_JurnalReference.GetChanges()

        If tbl_TrnJurnal_Changes IsNot Nothing Or tbl_JurnalReference_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Changes IsNot Nothing Or tbl_TrnJurnaldetil_Pembayaran_Changes IsNot Nothing Then

            Try

                MasterDataState = tbl_TrnJurnal.Rows(0).RowState
                jurnal_id = Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id")
                channel_id = Me.tbl_TrnJurnal.Rows(0).Item("channel_id")
                If tbl_TrnJurnal_Changes IsNot Nothing Then
                    tbl_TrnJurnal_Changes.Rows(0).Item("jurnal_modifyby") = Me.UserName
                    tbl_TrnJurnal_Changes.Rows(0).Item("jurnal_modifydate") = Now()
                    success = Me.uiTrnJurnal_SaveMaster(jurnal_id, tbl_TrnJurnal_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnJurnal_SaveMaster(tbl_TrnJurnal_Temp_Changes)")
                    Me.tbl_TrnJurnal.AcceptChanges()
                End If

                If tbl_TrnJurnaldetil_Changes IsNot Nothing Then

                    Dim nrow1_DgvTrnJurnaldetil = Me.DgvTrnJurnaldetil.Rows.Count

                    For i = 0 To Me.tbl_TrnJurnaldetil.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnJurnaldetil.Rows(i).Item("jurnal_id") = jurnal_id
                            Me.tbl_TrnJurnaldetil.Rows(i).Item("channel_id") = channel_id
                        End If
                    Next
                    Me.uiTrnJurnal_TblDetilInverse(tbl_TrnJurnaldetil_Changes)
                    success = Me.uiTrnJurnal_SaveDetil(jurnal_id, tbl_TrnJurnaldetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_SaveDetil(tbl_TrnJurnaldetil_Changes)")
                    Me.tbl_TrnJurnaldetil.AcceptChanges()

                    Dim nrow2_DgvTrnJurnaldetil = Me.DgvTrnJurnaldetil.Rows.Count
                    Dim nrow As Integer
                    Dim dgvrow As DataGridViewRow

                    For nrow = nrow1_DgvTrnJurnaldetil To nrow2_DgvTrnJurnaldetil - 1
                        dgvrow = Me.DgvTrnJurnaldetil.Rows(nrow - 1)
                        Me.DgvTrnJurnaldetil.Rows.Remove(dgvrow)
                    Next
                End If

                If tbl_JurnalReference_Changes IsNot Nothing Then
                    success = Me.uiTrnJurnal_SaveReference(jurnal_id, tbl_JurnalReference_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Reference Data at Me.uiTrnJurnal_SaveMaster(tbl_TrnJurnal_Temp_Changes)")
                    Me.tbl_JurnalReference.AcceptChanges()
                End If

                If tbl_TrnJurnaldetil_Pembayaran_Changes IsNot Nothing Then

                    Dim nrow1_DgvTrnJurnaldetil_Pembayaran = Me.DgvTrnJurnaldetil_Pembayaran.Rows.Count

                    For i = 0 To Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(i).Item("jurnal_id") = jurnal_id
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(i).Item("channel_id") = channel_id
                        End If
                    Next
                    success = Me.uiTrnJurnal_SaveDetil_Pembayaran(jurnal_id, tbl_TrnJurnaldetil_Pembayaran_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save DetilJadwalPembayaran Data at Me.uiTrnJurnal_SaveDetil(tbl_TrnJurnaldetil_Changes)")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.AcceptChanges()

                    Dim nrow2_DgvTrnJurnaldetil_Pembayaran = Me.DgvTrnJurnaldetil_Pembayaran.Rows.Count
                    Dim nrow As Integer
                    Dim dgvrow As DataGridViewRow

                    For nrow = nrow1_DgvTrnJurnaldetil_Pembayaran To nrow2_DgvTrnJurnaldetil_Pembayaran - 1
                        dgvrow = Me.DgvTrnJurnaldetil_Pembayaran.Rows(nrow - 1)
                        Me.DgvTrnJurnaldetil_Pembayaran.Rows.Remove(dgvrow)
                    Next
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

        RaiseEvent FormAfterSave(jurnal_id, result)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnJurnal_SaveMaster(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        ' ''Dim curpos As Integer

        ' Save data: transaksi_jurnal
        dbCmdInsert = New OleDb.OleDbCommand("cp_TrnJurnalBpj_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_bookdate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_bookdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "jurnal_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isdisabled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isposted", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isposted"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_createby", System.Data.OleDb.OleDbType.VarWChar, 32, "jurnal_createby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_createdate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_createdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_modifyby", System.Data.OleDb.OleDbType.VarWChar, 32, "jurnal_modifyby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_modifydate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_modifydate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_postby", System.Data.OleDb.OleDbType.VarWChar, 32, "jurnal_postby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_postdate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_postdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_duedate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_duedate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_faktur", System.Data.OleDb.OleDbType.VarWChar, 40, "jurnal_faktur"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_source", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnal_source"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaltype_id", System.Data.OleDb.OleDbType.VarWChar, 4, "jurnaltype_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.VarWChar, 10, "region_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.VarWChar, 14, "branch_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 14, "strukturunit_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub1_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub1_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub2_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub2_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "currency_rate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@periode_id", System.Data.OleDb.OleDbType.VarWChar, 8, "periode_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@invoice_descr", System.Data.OleDb.OleDbType.VarWChar, 400, "invoice_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_billdate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_billdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@account_ca_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "account_ca_id", System.Data.DataRowVersion.Current, Nothing))

        dbCmdUpdate = New OleDb.OleDbCommand("cp_TrnJurnal_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_bookdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_bookdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "jurnal_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isdisabled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isposted", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isposted"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_createby", System.Data.OleDb.OleDbType.VarWChar, 32, "jurnal_createby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_createdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_createdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_modifyby", System.Data.OleDb.OleDbType.VarWChar, 32, "jurnal_modifyby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_modifydate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_modifydate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_postby", System.Data.OleDb.OleDbType.VarWChar, 32, "jurnal_postby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_postdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_postdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_duedate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_duedate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_faktur", System.Data.OleDb.OleDbType.VarWChar, 40, "jurnal_faktur"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_source", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnal_source"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaltype_id", System.Data.OleDb.OleDbType.VarWChar, 4, "jurnaltype_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.VarWChar, 10, "region_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.VarWChar, 14, "branch_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 14, "strukturunit_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub1_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub1_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub2_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub2_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "currency_rate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@periode_id", System.Data.OleDb.OleDbType.VarWChar, 8, "periode_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@invoice_descr", System.Data.OleDb.OleDbType.VarWChar, 400, "invoice_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_billdate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_billdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@account_ca_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "account_ca_id", System.Data.DataRowVersion.Current, Nothing))


        dbDA = New OleDb.OleDbDataAdapter
        dbDA.InsertCommand = dbCmdInsert
        dbDA.UpdateCommand = dbCmdUpdate

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
    Private Function uiTrnJurnal_SaveDetil(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDAUpdateDetil As OleDb.OleDbDataAdapter

        ' Save data: transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("cp_TrnJurnaldetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "jurnaldetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 12, "ref_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.VarWChar, 10, "region_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.VarWChar, 14, "branch_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 14, "strukturunit_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, "rekanan_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub1_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub1_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub2_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub2_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_type", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(2, Byte), CType(0, Byte), "jurnaldetil_type", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@jurnaldetil_dk").Value = "K"
        dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL
        'dbCmdInsert.Parameters("@rekanan_id").Value = rekanan_id


        dbCmdUpdate = New OleDb.OleDbCommand("cp_TrnJurnaldetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "jurnaldetil_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 12, "ref_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.VarWChar, 10, "region_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.VarWChar, 14, "branch_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 14, "strukturunit_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub1_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub1_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub2_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub2_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_type", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(2, Byte), CType(0, Byte), "jurnaldetil_type", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdUpdate.Parameters("@jurnaldetil_dk").Value = "K"


        dbCmdDelete = New OleDb.OleDbCommand("cp_TrnJurnaldetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2, "jurnaldetil_dk"))
        dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id


        dbDAUpdateDetil = New OleDb.OleDbDataAdapter
        dbDAUpdateDetil.UpdateCommand = dbCmdUpdate
        dbDAUpdateDetil.InsertCommand = dbCmdInsert
        dbDAUpdateDetil.DeleteCommand = dbCmdDelete


        Try
            dbConn.Open()
            dbDAUpdateDetil.Update(objTbl)

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
    Private Function uiTrnJurnal_SaveDetil_Pembayaran(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDAUpdateDetil As OleDb.OleDbDataAdapter

        ' Save data: transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("cp_TrnJurnaldetil_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "jurnaldetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 12, "ref_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.VarWChar, 10, "region_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.VarWChar, 14, "branch_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 14, "strukturunit_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, "rekanan_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub1_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub1_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub2_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub2_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_type", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(2, Byte), CType(0, Byte), "jurnaldetil_type", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@jurnaldetil_dk").Value = "D"
        dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL


        dbCmdUpdate = New OleDb.OleDbCommand("cp_TrnJurnaldetil_Update", dbConn)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 510, "jurnaldetil_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 12, "ref_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.VarWChar, 20, "currency_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.VarWChar, 10, "region_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.VarWChar, 14, "branch_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.VarWChar, 14, "strukturunit_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub1_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub1_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sub2_id", System.Data.OleDb.OleDbType.VarWChar, 14, "sub2_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_type", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(2, Byte), CType(0, Byte), "jurnaldetil_type", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdUpdate.Parameters("@jurnaldetil_dk").Value = "D"


        dbCmdDelete = New OleDb.OleDbCommand("cp_TrnJurnaldetil_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2, "jurnaldetil_dk"))
        dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id

        dbDAUpdateDetil = New OleDb.OleDbDataAdapter
        dbDAUpdateDetil.UpdateCommand = dbCmdUpdate
        dbDAUpdateDetil.InsertCommand = dbCmdInsert
        dbDAUpdateDetil.DeleteCommand = dbCmdDelete


        Try
            dbConn.Open()
            dbDAUpdateDetil.Update(objTbl)

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
    Private Function uiTrnJurnal_SaveReference(ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter


        ' Save data: transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("cp_TrnJurnalreference_Insert", dbConn)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_ref", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id_ref"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_refline", System.Data.OleDb.OleDbType.Integer, 4, "jurnal_id_refline"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@referencetype", System.Data.OleDb.OleDbType.VarWChar, 30))
        'dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modifyby", System.Data.OleDb.OleDbType.VarWChar, 16))
        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@referencetype").Value = "jurnal BPB"


        dbCmdDelete = New OleDb.OleDbCommand("cp_TrnJurnalreference_Delete", dbConn)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_ref", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id_ref"))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id_refline", System.Data.OleDb.OleDbType.Integer, 4, "jurnal_id_refline"))
        dbCmdDelete.Parameters("@jurnal_id").Value = jurnal_id


        dbDA = New OleDb.OleDbDataAdapter
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
    Private Function uiTrnJurnal_TblDetilInverse(ByVal tbl As DataTable) As Boolean
        Dim i As Integer
        For i = 0 To tbl.Rows.Count - 1
            If tbl.Rows(i).RowState <> DataRowState.Deleted Then
                tbl.Rows(i).Item("jurnaldetil_idr") = -tbl.Rows(i).Item("jurnaldetil_idr")
                tbl.Rows(i).Item("jurnaldetil_foreign") = -tbl.Rows(i).Item("jurnaldetil_foreign")
            End If
        Next
        Return True
    End Function
    Private Sub FtabJurnal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FtabJurnal.SelectedIndexChanged
        Dim i, activetab As Byte

        For i = 0 To (Me.FtabJurnal.TabCount - 1)
            Me.FtabJurnal.TabPages.Item(i).BackColor = Color.LavenderBlush
        Next
        activetab = Me.FtabJurnal.SelectedIndex
        Me.FtabJurnal.TabPages.Item(activetab).BackColor = Color.White
    End Sub

End Class