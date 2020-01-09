Public Class uiTrnTerimaJasa
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

    Private tbl_TrnTerimabarang As DataTable = clsdataset.CreateTblTrnTerimabarang()
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
    Private tbl_MstChannel_channel_id_search As DataTable = clsdataset.CreateTblMstChannel()
    Private tbl_MstRekanan_rekanan_id_search As DataTable = clsDataset.CreateTblMstRekanan()
    Private tbl_MstStrukturunit_id_search As DataTable = clsDataset.CreateTblStrukturunitPemilik

    '-----End Bikin Tabel untuk combo Data Search-------------------------


    '-----Bikin Tabel untuk Combo Data Detil-------------------------------

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

    Private tbl_retOrderDetilJasa As DataTable = clsDataset.CreateTblTrnOrderdetilJasa
    Private tbl_MstKategorijasa As DataTable = clsDataset.CreateTblMstKategorijasa


    Private tabels_order As DataTable = New DataTable


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
    Private isUser As String
    Private isLock As Byte


    '--- ADDITIONAL BUTTON
    Friend WithEvents btnlock As ToolStripButton = New ToolStripButton
    'Friend WithEvents btnbarcode As ToolStripButton = New ToolStripButton
    'Friend WithEvents btnkain As ToolStripButton = New ToolStripButton
    Friend WithEvents btnHome As ToolStripButton = New ToolStripButton
    'Friend WithEvents btnPicture As ToolStripButton = New ToolStripButton

    '--- TO DO PRINT
    Private tbl_MstSkill As DataTable = clsDataset.CreateTblMstSkill()
    Private tbl_requestdetil As DataTable = clsDataset.CreateTblRequestdetilSelect()
    Private tbl_request As DataTable = clsDataset.CreateTblTrnRequest()
    Private tbl_MstTrnOrder As DataTable = clsDataset.CreateTblTrnOrder()
    Private tbl_requesteps As DataTable = clsDataset.CreateTblTrnRequestdetilEps()
    Private tbl_Print As DataTable = clsDataset.CreateTblTrnTerimabarang
    Private tbl_PrintDetil As DataTable = clsDataset.CreateTblTrnTerimabarangdetil
    Private m_streams As IList(Of System.IO.Stream)
    Private m_currentPageIndex As Integer
    Private objPrintHeader As DataSource.clsRptBarang
    Private objDatalistDetil As ArrayList
    Private order As String
    '------------------------------------------------------------------------------

    Private tbl_MstTrnOrderRO As DataTable = clsDataset.CreateTblTrnOrder()
    Private tbl_MstTrnOrderMO As DataTable = clsDataset.CreateTblTrnOrder()

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

    Private retTblTerimaJasa As DataTable = clsDataset.CreateTblTrnTerimabarang()
    Private total_days As Integer

    Friend Class SelectDaysDialogReturn
        Private m_orderdetil_line As Integer
        Private m_orderdetil_descr As String
        Private m_orderdetil_idr As Decimal
        Private m_orderdetil_qty As Decimal
        Private m_orderdetil_days As Decimal
        Private m_orderdetil_eps As Decimal
        Private m_item_id As String
        Private m_order_utilizeddatestart As Date
        Private m_order_utilizeddateend As Date

        Private m_order_epsstart As Decimal
        Private m_order_epsend As Decimal

        Public Property orderdetil_line() As Integer
            Get
                Return m_orderdetil_line
            End Get
            Set(ByVal value As Integer)
                m_orderdetil_line = value
            End Set
        End Property

        Public Property orderdetil_descr() As String
            Get
                Return m_orderdetil_descr
            End Get
            Set(ByVal value As String)
                m_orderdetil_descr = value
            End Set
        End Property

        Public Property orderdetil_idr() As Decimal
            Get
                Return m_orderdetil_idr
            End Get
            Set(ByVal value As Decimal)
                m_orderdetil_idr = value
            End Set
        End Property

        Public Property orderdetil_days() As Decimal
            Get
                Return m_orderdetil_days
            End Get
            Set(ByVal value As Decimal)
                m_orderdetil_days = value
            End Set
        End Property

        Public Property orderdetil_eps() As Decimal
            Get
                Return m_orderdetil_eps
            End Get
            Set(ByVal value As Decimal)
                m_orderdetil_eps = value
            End Set
        End Property

        Public Property orderdetil_qty() As Decimal
            Get
                Return m_orderdetil_qty
            End Get
            Set(ByVal value As Decimal)
                m_orderdetil_qty = value
            End Set
        End Property


        Public Property item_id() As String
            Get
                Return m_item_id
            End Get
            Set(ByVal value As String)
                m_item_id = value
            End Set
        End Property

        Public Property order_utilizeddatestart() As Date
            Get
                Return m_order_utilizeddatestart
            End Get
            Set(ByVal value As Date)
                m_order_utilizeddatestart = value
            End Set
        End Property

        Public Property order_utilizeddateend() As Date
            Get
                Return m_order_utilizeddateend
            End Get
            Set(ByVal value As Date)
                m_order_utilizeddateend = value
            End Set
        End Property

        Public Property order_epsstart() As Decimal
            Get
                Return m_order_epsstart
            End Get
            Set(ByVal value As Decimal)
                m_order_epsstart = value
            End Set
        End Property

        Public Property order_epsend() As Decimal
            Get
                Return m_order_epsend
            End Get
            Set(ByVal value As Decimal)
                m_order_epsend = value
            End Set
        End Property

    End Class

#Region " Window Parameter "
    Private _CHANNEL As String = "TTV"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False

    Private _STRUKTUR_UNIT As Decimal = 5554 '2610 '2360
    Private _PROCSU As String = "5554"
    Private _CANCHANGESU As Boolean = False
    Private _SU_EMPLOYEE As String = "9004000"

    Private _BM As Boolean = False
    Private _PC As Boolean = False
    Private _US As Boolean = True

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
        Dim newdata_TerimaJasa As dlgNewDataTerimaJasa = New dlgNewDataTerimaJasa(Me.DSN)

        newdata_TerimaJasa.ShowInTaskbar = False
        newdata_TerimaJasa.StartPosition = FormStartPosition.CenterParent
        newdata_TerimaJasa.ShowDialog(Me)

        If newdata_TerimaJasa.DialogResult = DialogResult.OK Then
            If newdata_TerimaJasa.obj_NewDataTerimaJasa.SelectedItem <> "-- Pilih --" Then
                If newdata_TerimaJasa.obj_NewDataTerimaJasa.SelectedItem = "Revision" Then
                    Dim chooseBpj As New dlgListBpj(Me.DSN, Me._CHANNEL, Me._STRUKTUR_UNIT, "JASA")
                    Me.retTblTerimaJasa = chooseBpj.OpenDialog(Me)

                    If retTblTerimaJasa Is Nothing Then
                        MsgBox("You must choose one of row in goods received to revision")
                        Exit Function
                    Else
                        Me.Cursor = Cursors.WaitCursor
                        If Me.ftabMain.SelectedIndex = 0 Then
                            Me.ftabMain.SelectedIndex = 1
                        End If

                        Me.uiTrnTerimaJasa_NewData()
                        Me.Panel3.Enabled = True
                        Me.obj_Terimajasa_status.Enabled = True
                        Me.obj_Terimajasa_location.Text = "GEDUNG TRANSTV - TENDEAN JAKARTA"
                        Me.Btn_Add.Enabled = False
                        Me.btn_bonus.Enabled = False
                        Me.btn_DeleteItem.Enabled = False
                        Me.obj_Status.SelectedItem = "-- Pilih --"
                        If Me.retTblTerimaJasa.Rows(0).Item("terimabarang_status") = "NO RO" Then
                            Me.obj_Terimajasa_status.SelectedItem = "RO"
                        Else
                            Me.obj_Terimajasa_status.SelectedItem = "MO"
                        End If
                        Me.obj_Terimajasa_status.Enabled = False
                        Me.obj_Status_kedatangan_barang.SelectedItem = "-- Pilih --"
                        Me.obj_Pa_ref.Text = Me.retTblTerimaJasa.Rows(0).Item("terimabarang_id")
                        Me.DgvTrnTerimajasadetil.AllowUserToAddRows = False 'True
                        Me.PnlDataMaster.Enabled = True
                        Me.DgvTrnTerimajasadetil.Enabled = False
                        Me.obj_Terimajasa_id.Text = "AUTO"
                        Me.uiTrnTerimaJasa_LoadCombo()
                        Me.uiTrnTerimaJasa_LoadComboBox()
                        Me.uiTrnTerimaJasa_LoadComboSearch()
                        Me.obj_Employee_id_pemilik.Enabled = True
                        Me.obj_Status_kedatangan_barang.Enabled = True
                        Me.obj_Terimajasa_location.Enabled = True
                        Me.obj_Terimajasa_location.ReadOnly = False
                        Me.obj_terimajasa_noSuratJalan.ReadOnly = False
                        Me.obj_Notes.Enabled = True
                        Me.obj_Notes.ReadOnly = False
                        Me.select_nomor_RO_MO()
                    End If
                ElseIf newdata_TerimaJasa.obj_NewDataTerimaJasa.SelectedItem = "New" Then
                    Me.Cursor = Cursors.WaitCursor
                    If Me.ftabMain.SelectedIndex = 0 Then
                        Me.ftabMain.SelectedIndex = 1
                    End If

                    Me.uiTrnTerimaJasa_NewData()
                    Me.Panel3.Enabled = True
                    Me.obj_Terimajasa_status.Enabled = True
                    Me.obj_Terimajasa_location.Text = "GEDUNG TRANSTV - TENDEAN JAKARTA"
                    Me.Btn_Add.Enabled = False
                    Me.btn_bonus.Enabled = False
                    Me.btn_DeleteItem.Enabled = False
                    Me.obj_Status.SelectedItem = "-- Pilih --"
                    Me.obj_Terimajasa_status.SelectedItem = "-- Pilih --"
                    Me.obj_Status_kedatangan_barang.SelectedItem = "-- Pilih --"
                    Me.DgvTrnTerimajasadetil.AllowUserToAddRows = False 'True
                    Me.PnlDataMaster.Enabled = True
                    Me.DgvTrnTerimajasadetil.Enabled = False
                    Me.obj_Terimajasa_id.Text = "AUTO"
                    Me.uiTrnTerimaJasa_LoadCombo()
                    Me.uiTrnTerimaJasa_LoadComboBox()
                    Me.uiTrnTerimaJasa_LoadComboSearch()
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Status_kedatangan_barang.Enabled = True
                    Me.obj_Terimajasa_location.Enabled = True
                    Me.obj_Terimajasa_location.ReadOnly = False
                    Me.obj_terimajasa_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.select_nomor_RO_MO()
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
        Me.uiTrnTerimaJasa_Retrieve()
        Me.uiTrnTerimaJasa_LoadComboBox()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function
    Public Overrides Function btnSave_Click() As Boolean
        If Me.uiTrnTerimaJasa_FormError() Then
            Return True
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Save()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function
    Public Overrides Function btnPrint_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Print()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrint_Click()
    End Function
    Public Overrides Function btnPrintPreview_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_PrintPreview()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrintPreview_Click()
    End Function
    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Delete()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function
    Public Overrides Function btnFirst_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_First()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnFirst_Click()
    End Function
    Public Overrides Function btnPrev_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Prev()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPrev_Click()
    End Function
    Public Overrides Function btnNext_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Next()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNext_Click()
    End Function
    Public Overrides Function btnLast_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnTerimaJasa_Last()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLast_Click()
    End Function

#End Region

#Region " Additional Overrides "
    Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlock.Click
        If Me.DgvTrnTerimajasa.Rows.Count > 0 Then
           
            If Me._US = True Then
                If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appuser").Value = 0 Then
                    'approve user
                    Me.lockUser("approved")
                    Me.btnlock.Image = Me.ImageList1.Images(7)
                    Me.btnlock.ToolTipText = "UnApproved Transaction"
                ElseIf Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appbma").Value = 1 Then
                    MsgBox("Need BMA UnApproved", MsgBoxStyle.Information)
                ElseIf Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appprc").Value = 1 Then
                    MsgBox("Need Spv / Section Head UnApproved", MsgBoxStyle.Information)
                Else
                    'unapproved user
                    Me.lockUser("unapproved")
                    Me.btnlock.Image = Me.ImageList1.Images(6)
                    Me.btnlock.ToolTipText = "Approved Transaction"
                End If

            ElseIf Me._PC = True Then
                If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appuser").Value = 1 Then
                    If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appprc").Value = 0 Then
                        'approve SPV / procurement
                        Me.LockPrcData("approved")
                        Me.btnlock.Image = Me.ImageList1.Images(7)
                        Me.btnlock.ToolTipText = "UnApproved Transaction"
                    ElseIf Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appbma").Value = 1 Then
                        MsgBox("Need BMA UnApproved", MsgBoxStyle.Information)
                    Else
                        'UnApprove SPV / procurement
                        Me.LockPrcData("unapproved")
                        Me.btnlock.Image = Me.ImageList1.Images(6)
                        Me.btnlock.ToolTipText = "Approved Transaction"
                    End If
                Else
                    MsgBox("Need User Confirmation", MsgBoxStyle.Information)
                End If

            ElseIf Me._BM = True Then
                If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appuser").Value = 0 Then
                    MsgBox("Need User Confirmation", MsgBoxStyle.Information)
                ElseIf Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appprc").Value = 0 Then
                    MsgBox("Need Spv / Section Head Confirmation", MsgBoxStyle.Information)
                Else
                    If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appbma").Value = 0 Then
                        'approve BMA
                        Me.LockDataBMA("approved")
                        Me.btnlock.Image = Me.ImageList1.Images(7)
                        Me.btnlock.ToolTipText = "UnApproved Transaction"
                    Else
                        Dim tbl_refJurnal As DataTable = New DataTable
                        Me.DataFill(tbl_refJurnal, "cp_TrnJurnalReference_SelectLine", String.Format(" jurnal_id_ref = '{0}'", Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)), Me._CHANNEL)
                        'unapprove BMA
                        If tbl_refJurnal.Rows.Count > 0 Then
                            Dim s As Integer
                            Dim message As String = String.Empty
                            For s = 0 To tbl_refJurnal.Rows.Count - 1
                                If message = String.Empty Then
                                    message = " UnApproved dan delete dulu jurnal " & tbl_refJurnal.Rows(s).Item("jurnal_id")
                                Else
                                    message &= ", " & tbl_refJurnal.Rows(s).Item("jurnal_id_ref")
                                End If
                            Next
                            MsgBox(message)
                        Else
                            Me.LockDataBMA("unapproved")
                            Me.btnlock.Image = Me.ImageList1.Images(6)
                            Me.btnlock.ToolTipText = "Approved Transaction"
                        End If
                    End If

                End If
            End If
        End If


        ' ''If Me._US = True And Me.obj_Terimajasa_appuser.Checked = False Then
        ' ''    Me.lockUser()
        ' ''End If
        ' ''If Me._PC = True And Me.obj_Terimajasa_appuser.Checked = True And Me.obj_Terimajasa_appprc.Checked = False Then
        ' ''    Me.LockPrcData()
        ' ''    Exit Sub
        ' ''End If
        ' ''If Me._PC = True And Me._US = False And Me.obj_Terimajasa_appuser.Checked = False Then
        ' ''    MsgBox("Need User Confirmation", MsgBoxStyle.Information)
        ' ''    Exit Sub
        ' ''End If
        ' ''If Me._BM = True And Me.obj_Terimajasa_appuser.Checked = True And Me.obj_Terimajasa_appprc.Checked = True Then
        ' ''    Me.LockDataBMA()
        ' ''    Exit Sub
        ' ''End If
        ' ''If Me._BM = True And (Me._US = False Or Me._PC = False) And (Me.obj_Terimajasa_appuser.Checked = False Or Me.obj_Terimajasa_appprc.Checked = False) Then
        ' ''    MsgBox("Need User Confirmation", MsgBoxStyle.Information)
        ' ''    Exit Sub
        ' ''End If
    End Sub
    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        Me.Panel1.Visible = False
        Me.btnHome.Enabled = False
        Me.tbtnFirst.Enabled = True
        Me.tbtnPrev.Enabled = True
        Me.tbtnNext.Enabled = True
        Me.tbtnLast.Enabled = True

        If Me._BM = True Then
            Me.tbtnNew.Enabled = False
            Me.tbtnSave.Enabled = False
            Me.tbtnPrint.Enabled = False
            Me.tbtnPrintPreview.Enabled = False
            Me.tbtnDel.Enabled = False
        Else
            Me.tbtnNew.Enabled = True
            Me.tbtnSave.Enabled = True
            Me.tbtnPrint.Enabled = True
            Me.tbtnPrintPreview.Enabled = True
            Me.tbtnDel.Enabled = True
        End If

        'Me.btnPicture.Enabled = False

        Me.objFormError.Clear()
    End Sub
    'Private Sub btnPicture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPicture.Click
    '    Dim rNamaFile As String
    '    rNamaFile = Me.obj_asset_Terimajasa_id.Text & "-" & Me.obj_Asset_line.Text
    '    Dim dlg As dlg_addPicture = New dlg_addPicture(Me.DSN, rNamaFile)
    '    dlg.ShowInTaskbar = False
    '    dlg.StartPosition = FormStartPosition.CenterParent
    '    dlg.ShowDialog(Me)
    'End Sub
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
            Dim colterimabarang_appbma As DataGridViewCheckBoxColumn
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
            Dim colasset_Notes As DataGridViewTextBoxColumn



            colchannel_id = clsUtil.CreateColumn("channel_id", "channel_id", "Channel", "TXT10", DataGridViewContentAlignment.MiddleLeft, True)

            colterimabarang_id = clsUtil.CreateColumn("terimabarang_id", "terimabarang_id", "Receive No.", "TXT17", DataGridViewContentAlignment.MiddleLeft, True)

            colterimabarang_tgl = clsUtil.CreateColumn("terimabarang_tgl", "terimabarang_tgl", "Date", "TXT15", DataGridViewContentAlignment.MiddleLeft, True)
            colterimabarang_tgl.DefaultCellStyle.Format = "dd MMMM yyyy"

            'colterimabarang_tgl = clsUtil.CreateColumn("terimabarang_tgl", "terimabarang_tgl", "Date", "TXT15", DataGridViewContentAlignment.MiddleLeft, True)


            colterimabarang_status = clsUtil.CreateColumn("terimabarang_status", "terimabarang_status", "terimabarang_status", "TXT10", DataGridViewContentAlignment.MiddleLeft, True)

            colorder_id = clsUtil.CreateColumn("order_id", "order_id", "Order No.", "TXT13", DataGridViewContentAlignment.MiddleLeft, True)

            colpa_ref = clsUtil.CreateColumn("pa_ref", "pa_ref", "pa_ref", "TXT15", DataGridViewContentAlignment.MiddleLeft, True)

            colrekanan_id = clsUtil.CreateColumn("rekanan_id", "rekanan_id", "rekanan_id", "NUM5.0", DataGridViewContentAlignment.MiddleRight, True)
            colrekanan_id.DefaultCellStyle.Format = "###,##0.00"
            colterimabarang_appbma = clsUtil.CreateColumn("terimabarang_appbma", "terimabarang_appbma", "BMA", 10)

            colemployee_id_pemilik = clsUtil.CreateColumn("employee_id_pemilik", "employee_id_pemilik", "employee_id_pemilik", "TXT15", DataGridViewContentAlignment.MiddleLeft, True)

            colstrukturunit_id_pemilik = clsUtil.CreateColumn("strukturunit_id_pemilik", "strukturunit_id_pemilik", "strukturunit_id_pemilik", "NUM6.0", DataGridViewContentAlignment.MiddleRight, True)
            colstrukturunit_id_pemilik.DefaultCellStyle.Format = "###,##0.00"
            colaccounting_applogin = clsUtil.CreateColumn("accounting_applogin", "accounting_applogin", "accounting_applogin", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)
            colaccounting_appdt = clsUtil.CreateColumn("accounting_appdt", "accounting_appdt", "accounting_appdt", "TXT4", DataGridViewContentAlignment.MiddleLeft, True)
            colterimabarang_appprc = clsUtil.CreateColumn("terimabarang_appprc", "terimabarang_appprc", "SPV", 10)
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

            colterimabarang_appuser = clsUtil.CreateColumn("terimabarang_appuser", "terimabarang_appuser", "User", 10)
            colterimabarang_apploginuser = clsUtil.CreateColumn("user_applogin", "user_applogin", "user_applogin", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)
            colterimabarang_applogindt = clsUtil.CreateColumn("user_appdt", "user_appdt", "user_appdt", "TXT4", DataGridViewContentAlignment.MiddleLeft, True)

            colqty_mother = clsUtil.CreateColumn("qty_mother", "qty_mother", "Qty Mother", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, True)
            colqty_mother.DefaultCellStyle.Format = "###,##0"

            colstatus = clsUtil.CreateColumn("status", "status", "Status", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)

            colqty_po = clsUtil.CreateColumn("qty_po", "qty_po", "Qty RO/MO", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, True)
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
            colasset_Notes = clsUtil.CreateColumn("notes", "notes", "Notes", "TXT50", DataGridViewContentAlignment.MiddleLeft, True)



            objDgv.Columns.Clear()
            objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
            {colterimabarang_appuser, colterimabarang_appprc, colterimabarang_appbma, colchannel_id, colterimabarang_id, _
            colterimabarang_tgl, colstrukturunit_id_pemilik_string, colrekanan_id_String, colqty_mother, _
            colstatus, colqty_po, colorder_id, colasset_Notes})
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
            Dim cTerimaBarangdetil_button_days As System.Windows.Forms.DataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
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
            Dim colstatus_ro As DataGridViewTextBoxColumn
            Dim colUsage As DataGridViewTextBoxColumn

            colterimabarang_id = clsUtil.CreateColumn("terimabarang_id", "terimabarang_id", "ID", "TXT16", DataGridViewContentAlignment.MiddleLeft, True)

            colasset_line = clsUtil.CreateColumn("asset_line", "asset_line", "Line", "NUM10.0", DataGridViewContentAlignment.MiddleCenter, False)
            colasset_line.DefaultCellStyle.Format = "###,##0"
            colchannel_id = clsUtil.CreateColumn("channel_id", "channel_id", "Channel", "TXT10", DataGridViewContentAlignment.MiddleLeft, True)

            colasset_tgl = clsUtil.CreateColumn("asset_tgl", "asset_tgl", "asset_tgl", "TXT4", DataGridViewContentAlignment.MiddleLeft, False)

            coltipeasset_id = clsUtil.CreateColumn("tipeasset_id", "tipeasset_id", "tipeasset_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colkategoriasset_id = clsUtil.CreateColumn("kategoriasset_id", "kategoriasset_id", "kategoriasset_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_barcode = clsUtil.CreateColumn("asset_barcode", "asset_barcode", "Barcode", "TXT20", DataGridViewContentAlignment.MiddleLeft, True)
          
            colasset_lineinduk = clsUtil.CreateColumn("asset_lineinduk", "asset_lineinduk", "Days", "NUM8.0", DataGridViewContentAlignment.MiddleCenter, True)

            colasset_lineinduk.DefaultCellStyle.Format = "###,##0"
            colasset_barcodeinduk = clsUtil.CreateColumn("asset_barcodeinduk", "asset_barcodeinduk", "asset_barcodeinduk", "TXT20", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_serial = clsUtil.CreateColumn("asset_serial", "asset_serial", "asset_serial", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_produknumber = clsUtil.CreateColumn("asset_produknumber", "asset_produknumber", "asset_produknumber", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_model = clsUtil.CreateColumn("asset_model", "asset_model", "asset_model", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            colasset_deskripsi = clsUtil.CreateColumn("asset_deskripsi", "asset_deskripsi", "Description", "TXT90", DataGridViewContentAlignment.MiddleLeft, False)

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
            colasset_qty = clsUtil.CreateColumn("asset_qty", "asset_qty", "Qty", "NUM8.0", DataGridViewContentAlignment.MiddleCenter, True)
            colasset_qty.DefaultCellStyle.Format = "###,##0"
            colmaterial_id = clsUtil.CreateColumn("material_id", "material_id", "material_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, True)

            colwarna_id = clsUtil.CreateColumn("warna_id", "warna_id", "warna_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)

            If Me.obj_Status.SelectedValue = "TO" Then
                colukuran_id = clsUtil.CreateColumn("ukuran_id", "ukuran_id", "ukuran_id", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)
            Else
                colukuran_id = clsUtil.CreateColumn("ukuran_id", "ukuran_id", "Contract No.", "TXT30", DataGridViewContentAlignment.MiddleLeft, False)
            End If

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
            colstatus_ro = clsUtil.CreateColumn("status_ro", "status_ro", "Status", "TXT15", DataGridViewContentAlignment.MiddleCenter, True)
            colUsage = clsUtil.CreateColumn("usage", "usage", "Usage", "TXT5", DataGridViewContentAlignment.MiddleCenter, True)


            cTerimaBarangdetil_button.Text = "..."
            cTerimaBarangdetil_button.Name = "asset_button"
            cTerimaBarangdetil_button.HeaderText = "List"
            cTerimaBarangdetil_button.UseColumnTextForButtonValue = True
            cTerimaBarangdetil_button.CellTemplate.Style.BackColor = Color.Gainsboro
            cTerimaBarangdetil_button.Width = 30
            cTerimaBarangdetil_button.DividerWidth = 3

            cTerimaBarangdetil_button_days.Text = "..."
            cTerimaBarangdetil_button_days.Name = "days_button"
            cTerimaBarangdetil_button_days.HeaderText = ""
            cTerimaBarangdetil_button_days.UseColumnTextForButtonValue = True
            cTerimaBarangdetil_button_days.CellTemplate.Style.BackColor = Color.Gainsboro
            cTerimaBarangdetil_button_days.Width = 30
            cTerimaBarangdetil_button_days.DividerWidth = 3


            objDgv.Columns.Clear()
            If Me.obj_Status.SelectedValue = "TO" Then
                objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                {cTerimaBarangdetil_button, colasset_qty, colasset_lineinduk, cTerimaBarangdetil_button_days, _
                colUsage, colasset_deskripsi, colstatus_ro, colterimabarang_id, colorderdetil_line, colorder_id, colasset_line}) ', colasset_line, colchannel_id
            Else
                objDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                               {cTerimaBarangdetil_button, colasset_qty, colasset_lineinduk, cTerimaBarangdetil_button_days, _
                               colUsage, colasset_deskripsi, colukuran_id, colstatus_ro, colterimabarang_id, colorderdetil_line, colorder_id, colasset_line}) ', colasset_line, colchannel_id
            End If
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
        Me.DgvTrnTerimajasa.Dock = DockStyle.Fill

        Me.FormatDgvTrnTerimabarang(Me.DgvTrnTerimajasa)
        Me.FormatDgvTrnTerimabarangdetil(Me.DgvTrnTerimajasadetil)

    End Function
    Private Function BindingStop() As Boolean
        Me.obj_Channel_id.DataBindings.Clear()
        Me.obj_Terimajasa_id.DataBindings.Clear()
        Me.obj_Terimajasa_tgl.DataBindings.Clear()
        Me.obj_Terimajasa_status.DataBindings.Clear()
        Me.obj_Order_id.DataBindings.Clear()
        Me.obj_Pa_ref.DataBindings.Clear()
        Me.obj_Rekanan_id.DataBindings.Clear()
        Me.obj_Terimajasa_appbma.DataBindings.Clear()
        Me.obj_Employee_id_pemilik.DataBindings.Clear()
        Me.obj_Strukturunit_id_pemilik.DataBindings.Clear()
        Me.obj_BMA_applogin.DataBindings.Clear()
        Me.obj_BMA_appdt.DataBindings.Clear()
        Me.obj_Terimajasa_appprc.DataBindings.Clear()
        Me.obj_Procurement_applogin.DataBindings.Clear()
        Me.obj_Procurement_appdt.DataBindings.Clear()
        Me.obj_Terimajasa_cetakbpb.DataBindings.Clear()
        Me.obj_Terimajasa_cetakbkb.DataBindings.Clear()
        Me.obj_Terimajasa_item.DataBindings.Clear()
        Me.obj_Inputby.DataBindings.Clear()
        Me.obj_Inputdt.DataBindings.Clear()
        Me.obj_Editby.DataBindings.Clear()
        Me.obj_Editdt.DataBindings.Clear()
        Me.obj_Usedby.DataBindings.Clear()
        Me.obj_Useddt.DataBindings.Clear()
        Me.obj_Terimajasa_appuser.DataBindings.Clear()
        Me.obj_USer_applogin.DataBindings.Clear()
        Me.obj_User_appdt.DataBindings.Clear()

        Me.Obj_Qty_Mother.DataBindings.Clear()
        Me.obj_Status.DataBindings.Clear()
        Me.obj_Qty_PO.DataBindings.Clear()
        Me.obj_Terimajasa_type.DataBindings.Clear()

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

        Me.obj_Terimajasa_location.DataBindings.Clear()
        Me.obj_Notes.DataBindings.Clear()
        Me.obj_Status_kedatangan_barang.DataBindings.Clear()
        Me.obj_terimajasa_noSuratJalan.DataBindings.Clear()
        Return True
    End Function
    'start binding
    Private Function BindingStart() As Boolean
        Me.obj_channel_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarang_temp, "channel_id"))
        Me.obj_Terimajasa_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "terimabarang_id"))
        Me.obj_Terimajasa_tgl.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "terimabarang_tgl"))
        Me.obj_Terimajasa_status.DataBindings.Add(New Binding("SelectedItem", Me.tbl_TrnTerimabarang_Temp, "terimabarang_status"))
        Me.obj_Order_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "order_id"))
        Me.obj_Pa_ref.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "pa_ref"))
        Me.obj_rekanan_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarang_temp, "rekanan_id"))
        Me.obj_Terimajasa_appbma.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimabarang, "terimabarang_appbma"))
        Me.obj_Employee_id_pemilik.DataBindings.Add(New Binding("selectedValue", Me.tbl_TrnTerimabarang_Temp, "employee_id_pemilik"))
        Me.obj_Strukturunit_id_pemilik.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarang_Temp, "strukturunit_id_pemilik"))
        Me.obj_Terimajasa_item.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "terimabarang_item"))
        Me.obj_Inputby.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "inputby"))
        Me.obj_inputdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_temp, "inputdt"))
        Me.obj_editby.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_temp, "editby"))
        Me.obj_editdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_temp, "editdt"))
        Me.obj_usedby.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_temp, "usedby"))
        Me.obj_Useddt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "useddt"))
        Me.obj_BMA_applogin.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "bma_applogin"))
        Me.obj_BMA_appdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "bma_appdt"))
        Me.obj_Terimajasa_appprc.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimabarang, "terimabarang_appprc"))
        Me.obj_Procurement_applogin.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "procurement_applogin"))
        Me.obj_Procurement_appdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "procurement_appdt"))
        Me.obj_Terimajasa_cetakbpb.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "terimabarang_cetakbpb"))
        Me.obj_Terimajasa_cetakbkb.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "terimabarang_cetakbkb"))
        Me.obj_Terimajasa_appuser.DataBindings.Add(New Binding("Checked", Me.tbl_TrnTerimabarang, "terimabarang_appuser"))
        Me.obj_USer_applogin.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "user_applogin"))
        Me.obj_User_appdt.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang, "user_appdt"))

        Me.Obj_Qty_Mother.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "qty_mother"))
        Me.obj_Status.DataBindings.Add(New Binding("SelectedItem", Me.tbl_TrnTerimabarang_Temp, "status"))
        Me.obj_Qty_PO.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "qty_po"))
        Me.obj_Terimajasa_type.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "type"))

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

        Me.obj_Terimajasa_location.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "location"))
        Me.obj_Notes.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "notes"))
        Me.obj_Status_kedatangan_barang.DataBindings.Add(New Binding("SelectedItem", Me.tbl_TrnTerimabarang_Temp, "status_kedatangan"))
        Me.obj_terimajasa_noSuratJalan.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarang_Temp, "no_surat_jalan"))
        Return True
    End Function
    Private Function BindingStopAsset() As Boolean

        Me.obj_asset_Terimajasa_id.DataBindings.Clear()
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

        Me.obj_asset_Terimajasa_id.DataBindings.Add(New Binding("Text", Me.tbl_TrnTerimabarangdetil, "terimabarang_id"))
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
        Me.obj_Project_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "project_id"))
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

    Private Function uiTrnTerimaJasa_NewData() As Boolean
        'new data
        RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnTerimabarang_Temp
        Me.tbl_TrnTerimabarang_Temp.Clear()
        Me.tbl_TrnTerimabarang_Temp.Columns("channel_id").DefaultValue = _CHANNEL
        Me.tbl_TrnTerimabarang_Temp.Columns("strukturunit_id_pemilik").DefaultValue = Me._STRUKTUR_UNIT

        ' TODO: Set Default Value for tbl_TrnTerimabarangdetil
        Me.tbl_TrnTerimabarangdetil.Clear()
        Me.tbl_TrnTerimabarangdetil = clsdataset.CreateTblTrnTerimabarangdetil()
        'Me.tbl_TrnTerimabarangdetil.Columns("terimabarang_id").DefaultValue = 0
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").DefaultValue = DBNull.Value
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").AutoIncrement = True
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").AutoIncrementSeed = 1
        Me.tbl_TrnTerimabarangdetil.Columns("asset_line").AutoIncrementStep = 1
        Me.DgvTrnTerimajasadetil.DataSource = Me.tbl_TrnTerimabarangdetil


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

        Me.obj_Terimajasa_status.SelectedIndex = 0
        Try
            Me.BindingContext(Me.tbl_TrnTerimabarang_Temp).AddNew()

        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try

    End Function
    Private Function uiTrnTerimaJasa_Retrieve() As Boolean
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

        If chk_User_search.Checked = True Then
            If Me.cmb_appuser.SelectedItem = "Yes" Then
                criteria &= " and terimabarang_appuser = 1"
            Else
                criteria &= " and terimabarang_appuser = 0"
            End If
        End If

        If chk_orderID_search.Checked = True Then
            criteria &= criteria & String.Format(" AND order_id = '{0}'", Me.obj_orderID_search.Text)
        End If

        If chk_RvID_search.Checked = True Then
            criteria &= criteria & String.Format(" AND terimabarang_id = '{0}'", Me.obj_RvID_search.Text)
        End If

        criteria &= " AND ( terimabarang_status = 'RO' or terimabarang_status = 'MO' or terimabarang_status = 'TO' or terimabarang_status = 'EO' or terimabarang_status = 'NO RO' or terimabarang_status = 'NO MO')"

        Me.tbl_TrnTerimabarang.Clear()
        Try
            Me.btnlock.Enabled = True
            Me.DataFill(Me.tbl_TrnTerimabarang, "as_TrnTerimabarang_Select", criteria, obj_Channel_id_search.SelectedValue, obj_top.Value)
            If Me.DgvTrnTerimajasa.Rows.Count > 0 Then
                If Me._US = True Then
                    If Me.DgvTrnTerimajasa.Rows(0).Cells("terimabarang_appuser").Value = 1 Then
                        Me.btnlock.Image = Me.ImageList1.Images(7)
                        Me.btnlock.ToolTipText = "UnApproved Transaction"
                    Else
                        Me.btnlock.Image = Me.ImageList1.Images(6)
                        Me.btnlock.ToolTipText = "Approved Transaction"
                    End If
                ElseIf Me._PC = True Then
                    If Me.DgvTrnTerimajasa.Rows(0).Cells("terimabarang_appprc").Value = 1 Then
                        Me.btnlock.Image = Me.ImageList1.Images(7)
                        Me.btnlock.ToolTipText = "UnApproved Transaction"
                    Else
                        Me.btnlock.Image = Me.ImageList1.Images(6)
                        Me.btnlock.ToolTipText = "Approved Transaction"
                    End If
                ElseIf Me._BM = True Then
                    If Me.DgvTrnTerimajasa.Rows(0).Cells("terimabarang_appbma").Value = 1 Then
                        Me.btnlock.Image = Me.ImageList1.Images(7)
                        Me.btnlock.ToolTipText = "UnApproved Transaction"
                    Else
                        Me.btnlock.Image = Me.ImageList1.Images(6)
                        Me.btnlock.ToolTipText = "Approved Transaction"
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Function uiTrnTerimaJasa_Save() As Boolean
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

        Me.DgvTrnTerimajasadetil.EndEdit()
        Me.BindingContext(Me.tbl_TrnTerimabarangdetil).EndCurrentEdit()
        tbl_TrnTerimabarangdetil_Changes = Me.tbl_TrnTerimabarangdetil.GetChanges()

        If tbl_TrnTerimabarang_Temp_Changes IsNot Nothing Or tbl_TrnTerimabarangdetil_Changes IsNot Nothing Then
            Try
                MasterDataState = tbl_TrnTerimabarang_Temp.Rows(0).RowState
                terimabarang_id = tbl_TrnTerimabarang_Temp.Rows(0).Item("terimabarang_id")

                If tbl_TrnTerimabarang_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnTerimaJasa_SaveMaster(terimabarang_id, tbl_TrnTerimabarang_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnTerimaJasa_SaveMaster(tbl_TrnTerimabarang_Temp_Changes)")
                    Me.tbl_TrnTerimabarang_Temp.AcceptChanges()
                End If

                If tbl_TrnTerimabarangdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                        If Me.tbl_TrnTerimabarangdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnTerimabarangdetil.Rows(i).Item("terimabarang_id") = terimabarang_id
                        End If
                    Next
                    success = Me.uiTrnTerimaJasa_SaveDetil(terimabarang_id, tbl_TrnTerimabarangdetil_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnTerimaJasa_SaveDetil(tbl_TrnTerimabarangdetil_Changes)")
                    Me.tbl_TrnTerimabarangdetil.AcceptChanges()
                End If

                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.uiTrnTerimaJasa_OpenRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
                    Me.BindingStopAsset()
                    Me.BindingStartAsset()
                    If Me._US = True Then
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
                        Me.DgvTrnTerimajasadetil.Enabled = True
                        Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = False
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
    Private Function uiTrnTerimaJasa_SaveMaster(ByRef terimabarang_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
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
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
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
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
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
    Private Function uiTrnTerimaJasa_SaveDetil(ByRef terimabarang_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
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
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deskripsi", System.Data.OleDb.OleDbType.VarWChar, 300, "asset_deskripsi"))
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
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deskripsi", System.Data.OleDb.OleDbType.VarWChar, 300, "asset_deskripsi"))
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
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@asset_deskripsi", System.Data.OleDb.OleDbType.VarWChar, 300, "asset_deskripsi"))
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
    Private Function uiTrnTerimaJasa_Delete() As Boolean
        Dim res As String = ""
        Dim terimabarang_id As Object = New Object

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeDelete(terimabarang_id)

        Me.Cursor = Cursors.WaitCursor
        If Me.DgvTrnTerimajasa.CurrentRow IsNot Nothing Then

            res = MessageBox.Show("Are you sure want to delete data ?", mUiName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res = DialogResult.Yes Then
                Me.uiTrnTerimaJasa_DeleteRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
            End If

        End If

        RaiseEvent FormAfterDelete(terimabarang_id)
        Me.Cursor = Cursors.Arrow

    End Function
    Private Function uiTrnTerimaJasa_DeleteRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim terimabarang_id As String
        Dim NewRowIndex As Integer

        terimabarang_id = Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimabarang_id").Value

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
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5))
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

            If Me.DgvTrnTerimajasa.Rows.Count > 1 Then

                If rowIndex = 0 Then
                    NewRowIndex = rowIndex + 1
                    Me.uiTrnTerimaJasa_OpenRow(NewRowIndex)
                    Me.tbl_TrnTerimabarang.Rows.RemoveAt(rowIndex)
                ElseIf rowIndex = Me.DgvTrnTerimajasa.Rows.Count - 1 Then
                    NewRowIndex = rowIndex - 1
                    Me.uiTrnTerimaJasa_OpenRow(NewRowIndex)
                    Me.tbl_TrnTerimabarang.Rows.RemoveAt(rowIndex)
                Else
                    Me.tbl_TrnTerimabarang.Rows.RemoveAt(rowIndex)
                    Me.uiTrnTerimaJasa_OpenRow(rowIndex)
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

    Private Function uiTrnTerimaJasa_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim terimabarang_id As String
        Dim channel_id As String
        Dim components As Control
        '-----------------------------------  LOCKING -----------------------------------------
        '-------- UNTUK Locking saat USER sudah APPROVED atau Belum -------
        If Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimabarang_appuser").Value = 1 And Me._US = True Then
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
            Me.DgvTrnTerimajasadetil.AllowUserToAddRows = False

            Me.DgvTrnTerimajasadetil.AllowUserToDeleteRows = False
            Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = True
            Me.Btn_Add.Enabled = False
            Me.btn_bonus.Enabled = False
            Me.btn_DeleteItem.Enabled = False
            Me.Btn_Category.Enabled = False
            Me.Btn_Brand.Enabled = False
            Me.Btn_Type.Enabled = False
        ElseIf Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimabarang_appuser").Value = 0 And Me._US = True Then
            Me.Panel3.Enabled = True
            Me.PnlDataMaster.Enabled = True
            Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = False
            Me.DgvTrnTerimajasadetil.Enabled = True
          
            For Each components In Panel1.Controls
                If components.Name <> "FTabItem" Then
                    If components.Name <> "obj_Order_idDetil" Then
                        If components.Name <> "obj_orderdetil_line" Then
                            components.Enabled = True
                        End If
                    End If
                End If
            Next
            If Me.obj_Status.SelectedItem = "RO" Or Me.obj_Status.SelectedItem = "EO" Or Me.obj_Status.SelectedItem = "TO" Then
                Me.obj_Asset_qty.ReadOnly = True
            Else
                Me.obj_Asset_qty.ReadOnly = False
            End If

            If Me.obj_Status.SelectedItem <> "TO" Then
                Me.obj_Asset_disc.ReadOnly = False
            Else
                Me.obj_Asset_disc.ReadOnly = True
            End If

            Me.obj_Asset_tgl.ReadOnly = False
            Me.obj_Order_idDetil.ReadOnly = True
            Me.obj_orderdetil_line.ReadOnly = True
            Me.obj_Asset_deskripsi.ReadOnly = False
            Me.obj_Asset_lineinduk.ReadOnly = True
            Me.obj_Asset_serial.ReadOnly = False
            Me.obj_Unit_id.Enabled = True
            Me.obj_Kategoriitem_id.Enabled = True
            Me.obj_Brand_id.Enabled = True
            Me.obj_Tipeitem_id.Enabled = True

            Me.btnlock.Enabled = False
            Me.DgvTrnTerimajasadetil.AllowUserToAddRows = False 'True
            Me.DgvTrnTerimajasadetil.AllowUserToDeleteRows = False 'True
            Me.Btn_Category.Enabled = True
            Me.Btn_Type.Enabled = True
            Me.Btn_Brand.Enabled = True

            '-------- UNTUK Locking saat SPV USER sudah APPROVED atau Belum -------
        ElseIf Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimabarang_appprc").Value = 1 And Me._PC = True Then
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
            Me.DgvTrnTerimajasadetil.AllowUserToAddRows = False

            Me.DgvTrnTerimajasadetil.AllowUserToDeleteRows = False
            Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = True
            Me.Btn_Add.Enabled = False
            Me.btn_bonus.Enabled = False
            Me.btn_DeleteItem.Enabled = False
            Me.Btn_Category.Enabled = False
            Me.Btn_Type.Enabled = False
            Me.Btn_Brand.Enabled = False
        ElseIf Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimabarang_appprc").Value = 0 And Me._PC = True Then
            Me.Panel3.Enabled = True
            Me.PnlDataMaster.Enabled = True
            Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = False
            Me.DgvTrnTerimajasadetil.Enabled = True

            For Each components In Panel1.Controls
                If components.Name <> "FTabItem" Then
                    If components.Name <> "obj_Order_idDetil" Then
                        If components.Name <> "obj_orderdetil_line" Then
                            components.Enabled = True
                        End If
                    End If
                End If
            Next
            If Me.obj_Status.SelectedItem = "RO" Or Me.obj_Status.SelectedItem = "EO" Or Me.obj_Status.SelectedItem = "TO" Then
                Me.obj_Asset_qty.ReadOnly = True
            Else
                Me.obj_Asset_qty.ReadOnly = False
            End If
            If Me.obj_Status.SelectedItem <> "TO" Then
                Me.obj_Asset_disc.ReadOnly = False
            Else
                Me.obj_Asset_disc.ReadOnly = True
            End If
            Me.obj_Asset_tgl.ReadOnly = False
            Me.obj_Order_idDetil.ReadOnly = True
            Me.obj_orderdetil_line.ReadOnly = True
            Me.obj_Asset_deskripsi.ReadOnly = False
            Me.obj_Asset_lineinduk.ReadOnly = True
            Me.obj_Asset_serial.ReadOnly = False
            Me.obj_Unit_id.Enabled = True
            Me.obj_Kategoriitem_id.Enabled = True
            Me.obj_Brand_id.Enabled = True
            Me.obj_Tipeitem_id.Enabled = True

            Me.btnlock.Enabled = False
            Me.DgvTrnTerimajasadetil.AllowUserToAddRows = False 'True
            Me.DgvTrnTerimajasadetil.AllowUserToDeleteRows = False 'True
            Me.Btn_Category.Enabled = True
            Me.Btn_Type.Enabled = True
            Me.Btn_Brand.Enabled = True
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
            Me.DgvTrnTerimajasadetil.AllowUserToAddRows = False

            Me.DgvTrnTerimajasadetil.AllowUserToDeleteRows = False
            Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = True
            Me.Btn_Add.Enabled = False
            Me.btn_bonus.Enabled = False
            Me.btn_DeleteItem.Enabled = False
            Me.Btn_Category.Enabled = False
            Me.Btn_Type.Enabled = False
            Me.Btn_Brand.Enabled = False
        End If

        '-------- UNTUK kondisi jika super user yang jalanin  -------
        'If Me._BM = True And Me._PC = True And Me._US = True Then
        '    For Each components In Panel1.Controls
        '        If components.Name <> "obj_Order_idDetil" Then
        '            If components.Name <> "obj_orderdetil_line" Then
        '                components.Enabled = True
        '            End If
        '        End If
        '    Next
        '    Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = False

        '    '-------- UNTUK kondisi jika BMA yang jalanin  -------
        'ElseIf Me._BM = True Then
        '    For Each components In FTabItem.Controls
        '        components.Enabled = True
        '    Next
        '    For Each components In Panel1.Controls
        '        If components.Name <> "FTabItem" Then
        '            components.Enabled = False
        '        End If
        '    Next
        '    Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = True

        '    '-------- UNTUK kondisi jika SUPERVISOR USER yang jalanin  -------
        'ElseIf Me._PC = True Then
        '    'For Each components In Panel1.Controls
        '    '    components.Enabled = True
        '    'Next
        '    'Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = True
        'End If
        '-------------------------------- END LOCKING -----------------------------------

        '--------------------------------- UNTUK OPEN ROW -------------------------------
        terimabarang_id = Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimabarang_id").Value
        channel_id = Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("channel_id").Value

        Me.Cursor = Cursors.WaitCursor
        RaiseEvent FormBeforeOpenRow(terimabarang_id)

        Try
            dbConn.Open()
            Me.uiTrnTerimaJasa_OpenRowMaster(channel_id, terimabarang_id, dbConn)
            Me.uiTrnTerimaJasa_OpenRowDetil(channel_id, terimabarang_id, dbConn)
            Me.uiTrnTerimaJasa_OpenRowJurnalDetil(channel_id, terimabarang_id, dbConn)
            Me.uiTrnTerimaJasa_OpenRowJurnalDetil_pembayaran(channel_id, terimabarang_id, dbConn)
            Me.uiTrnTerimajasa_OpenRowJurnalReference(channel_id, terimabarang_id, dbConn)
            Me.FormatDgvTrnTerimabarangdetil(Me.DgvTrnTerimajasadetil)
            '--------------------------------- END OPEN ROW -------------------------------

            'Kondisi jika sudah ada 1 data di detil yang dimasukkan, maka data di header
            'sudah tidak bisa diubah
            If Me.DgvTrnTerimajasadetil.Rows.Count = 0 Then
                Me.obj_Terimajasa_status.Enabled = True
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
            Else
                Me.obj_Terimajasa_status.Enabled = False
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
            End If

            If Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimabarang_appuser").Value = 0 And Me._US = True Then 'Me.obj_Terimabarang_status.SelectedItem = "PO" And Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appuser").Value = 0 Then
                If Me.DgvTrnTerimajasadetil.RowCount = 0 And (Me.obj_Terimajasa_status.SelectedItem = "RO" Or Me.obj_Terimajasa_status.SelectedItem = "MO" Or Me.obj_Terimajasa_status.SelectedItem = "TO" Or Me.obj_Terimajasa_status.SelectedItem = "EO") Then
                    Me.Btn_Add.Enabled = True
                    Me.btn_bonus.Enabled = True
                    Me.btn_DeleteItem.Enabled = True
                    'Me.obj_Order_id.Enabled = True
                    Me.btn_order.Enabled = True
                    Me.obj_Terimajasa_status.Enabled = True
                    Me.obj_Rekanan_id.Enabled = False
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Terimajasa_location.Enabled = True
                    Me.obj_Terimajasa_location.ReadOnly = False
                    Me.obj_terimajasa_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.obj_Status_kedatangan_barang.Enabled = True
                ElseIf Me.DgvTrnTerimajasadetil.RowCount = 0 And Me.obj_Terimajasa_status.SelectedItem = "NO RO" Then
                    Me.Btn_Add.Enabled = True
                    Me.btn_bonus.Enabled = True
                    Me.btn_DeleteItem.Enabled = True
                    Me.obj_Terimajasa_status.Enabled = True
                    'Me.obj_Order_id.Enabled = False
                    Me.btn_order.Enabled = False
                    Me.obj_Rekanan_id.Enabled = True
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Terimajasa_location.Enabled = True
                    Me.obj_Terimajasa_location.ReadOnly = False
                    Me.obj_terimajasa_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.obj_Status_kedatangan_barang.Enabled = True
                ElseIf Me.DgvTrnTerimajasadetil.RowCount = 0 And Me.obj_Terimajasa_status.SelectedItem = "NO MO" Then
                    Me.Btn_Add.Enabled = True
                    Me.btn_bonus.Enabled = True
                    Me.btn_DeleteItem.Enabled = True
                    Me.obj_Terimajasa_status.Enabled = True
                    'Me.obj_Order_id.Enabled = False
                    Me.btn_order.Enabled = False
                    Me.obj_Rekanan_id.Enabled = True
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Terimajasa_location.Enabled = True
                    Me.obj_Terimajasa_location.ReadOnly = False
                    Me.obj_terimajasa_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.obj_Status_kedatangan_barang.Enabled = True
                Else
                    Me.Btn_Add.Enabled = True
                    Me.btn_bonus.Enabled = True
                    Me.btn_DeleteItem.Enabled = True
                    'Me.obj_Order_id.Enabled = False
                    Me.btn_order.Enabled = False
                    Me.obj_Terimajasa_status.Enabled = False
                    Me.obj_Rekanan_id.Enabled = False
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Terimajasa_location.Enabled = True
                    Me.obj_Terimajasa_location.ReadOnly = False
                    Me.obj_terimajasa_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.obj_Status_kedatangan_barang.Enabled = True
                End If
            ElseIf Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimabarang_appuser").Value = 1 And Me._US = True And Me.DgvTrnTerimajasadetil.RowCount >= 0 Then
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
                Me.obj_Terimajasa_status.Enabled = False
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
                Me.obj_Rekanan_id.Enabled = False
                Me.obj_Employee_id_pemilik.Enabled = False
                Me.obj_Terimajasa_location.Enabled = True
                Me.obj_Terimajasa_location.ReadOnly = True
                Me.obj_terimajasa_noSuratJalan.ReadOnly = True
                Me.obj_Notes.Enabled = True
                Me.obj_Notes.ReadOnly = True
                Me.obj_Order_idDetil.ReadOnly = True
                Me.obj_orderdetil_line.ReadOnly = True
                Me.obj_Status_kedatangan_barang.Enabled = False
            End If

            If Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimabarang_appprc").Value = 0 And Me._PC = True Then 'Me.obj_Terimabarang_status.SelectedItem = "PO" And Me.DgvTrnTerimabarang.Rows(rowIndex).Cells("terimabarang_appuser").Value = 0 Then
                If Me.DgvTrnTerimajasadetil.RowCount = 0 And (Me.obj_Terimajasa_status.SelectedItem = "RO" Or Me.obj_Terimajasa_status.SelectedItem = "MO" Or Me.obj_Terimajasa_status.SelectedItem = "TO" Or Me.obj_Terimajasa_status.SelectedItem = "EO") Then
                    Me.Btn_Add.Enabled = True
                    Me.btn_bonus.Enabled = True
                    Me.btn_DeleteItem.Enabled = True
                    'Me.obj_Order_id.Enabled = True
                    Me.btn_order.Enabled = True
                    Me.obj_Terimajasa_status.Enabled = True
                    Me.obj_Rekanan_id.Enabled = False
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Terimajasa_location.Enabled = True
                    Me.obj_Terimajasa_location.ReadOnly = False
                    Me.obj_terimajasa_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.obj_Status_kedatangan_barang.Enabled = True
                ElseIf Me.DgvTrnTerimajasadetil.RowCount = 0 And Me.obj_Terimajasa_status.SelectedItem = "NO RO" Then
                    Me.Btn_Add.Enabled = True
                    Me.btn_bonus.Enabled = True
                    Me.btn_DeleteItem.Enabled = True
                    Me.obj_Terimajasa_status.Enabled = True
                    'Me.obj_Order_id.Enabled = False
                    Me.btn_order.Enabled = False
                    Me.obj_Rekanan_id.Enabled = True
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Terimajasa_location.Enabled = True
                    Me.obj_Terimajasa_location.ReadOnly = False
                    Me.obj_terimajasa_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.obj_Status_kedatangan_barang.Enabled = True
                ElseIf Me.DgvTrnTerimajasadetil.RowCount = 0 And Me.obj_Terimajasa_status.SelectedItem = "NO MO" Then
                    Me.Btn_Add.Enabled = True
                    Me.btn_bonus.Enabled = True
                    Me.btn_DeleteItem.Enabled = True
                    Me.obj_Terimajasa_status.Enabled = True
                    'Me.obj_Order_id.Enabled = False
                    Me.btn_order.Enabled = False
                    Me.obj_Rekanan_id.Enabled = True
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Terimajasa_location.Enabled = True
                    Me.obj_Terimajasa_location.ReadOnly = False
                    Me.obj_terimajasa_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.obj_Status_kedatangan_barang.Enabled = True
                Else
                    Me.Btn_Add.Enabled = True
                    Me.btn_bonus.Enabled = True
                    Me.btn_DeleteItem.Enabled = True
                    'Me.obj_Order_id.Enabled = False
                    Me.btn_order.Enabled = False
                    Me.obj_Terimajasa_status.Enabled = False
                    Me.obj_Rekanan_id.Enabled = False
                    Me.obj_Employee_id_pemilik.Enabled = True
                    Me.obj_Terimajasa_location.Enabled = True
                    Me.obj_Terimajasa_location.ReadOnly = False
                    Me.obj_terimajasa_noSuratJalan.ReadOnly = False
                    Me.obj_Notes.Enabled = True
                    Me.obj_Notes.ReadOnly = False
                    Me.obj_Status_kedatangan_barang.Enabled = True
                End If
            ElseIf Me.DgvTrnTerimajasa.Rows(rowIndex).Cells("terimabarang_appprc").Value = 1 And Me._PC = True And Me.DgvTrnTerimajasadetil.RowCount >= 0 Then
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
                Me.obj_Terimajasa_status.Enabled = False
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
                Me.obj_Rekanan_id.Enabled = False
                Me.obj_Employee_id_pemilik.Enabled = False
                Me.obj_Terimajasa_location.Enabled = True
                Me.obj_Terimajasa_location.ReadOnly = True
                Me.obj_terimajasa_noSuratJalan.ReadOnly = True
                Me.obj_Notes.Enabled = True
                Me.obj_Notes.ReadOnly = True
                Me.obj_Order_idDetil.ReadOnly = True
                Me.obj_orderdetil_line.ReadOnly = True
                Me.obj_Status_kedatangan_barang.Enabled = False
            End If

            If Me._BM = True Then
                Me.obj_Notes.ReadOnly = True
                Me.obj_Terimajasa_location.ReadOnly = True
                Me.obj_terimajasa_noSuratJalan.ReadOnly = True
                Me.obj_Employee_id_pemilik.Enabled = False
                Me.obj_Status_kedatangan_barang.Enabled = False
                Me.obj_Terimajasa_status.Enabled = False
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
                Me.obj_Status.Enabled = False
                Me.obj_Rekanan_id.Enabled = False
                Me.obj_Strukturunit_id_pemilik.Enabled = False
                Me.DgvTrnTerimajasadetil.AllowUserToDeleteRows = False
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
            End If

            '--------------------------------- END ----------------------------------------
            Me.tampil_status_RO_MO_MANUAL()
            Me.dgvTransaksi_terimajasa_checkDays()

            If Me._US = True Then
                Me.isLock = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appuser").Value
            ElseIf Me._PC = True Then
                Me.isLock = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appprc").Value
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnTerimaJasa_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try

        RaiseEvent FormAfterOpenRow(terimabarang_id)
        Me.Cursor = Cursors.Arrow

        Return True

    End Function

    Private Function uiTrnTerimaJasa_OpenRowMaster(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
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
            Throw New Exception(mUiName & ": uiTrnTerimaJasa_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnTerimaJasa_OpenRowDetil(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        If Me.DgvTrnTerimajasa.Rows.Count > 0 Then
            If Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("order_id").Value, 1, 2) = "TO" Then
                dbCmd = New OleDb.OleDbCommand("as_TrnTerimabarangdetilTO_Select", dbConn)
            ElseIf Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("order_id").Value, 1, 2) = "EO" Then
                dbCmd = New OleDb.OleDbCommand("as_TrnTerimabarangdetilEO_Select", dbConn)
            Else
                dbCmd = New OleDb.OleDbCommand("as_TrnTerimabarangdetil_Select", dbConn)
            End If
        Else
            dbCmd = New OleDb.OleDbCommand("as_TrnTerimabarangdetil_Select", dbConn)
        End If
        dbCmd.Parameters.Add("@channel_id", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format(" and terimabarang_id = '{0}' ", terimabarang_id)
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

        Try
            Me.BindingStopAsset()
            dbDA.Fill(Me.tbl_TrnTerimabarangdetil)
            Me.DgvTrnTerimajasadetil.DataSource = Me.tbl_TrnTerimabarangdetil
            Me.BindingStartAsset()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnTerimaJasa_OpenRowDetil()" & vbCrLf & ex.Message)
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

    Private Function uiTrnTerimaJasa_First() As Boolean
        'goto first record found
        If Me.DgvTrnTerimajasa.SelectedRows.Count <= 0 Then
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
                move = Me.uiTrnTerimaJasa_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnTerimajasa.CurrentCell = Me.DgvTrnTerimajasa(1, 0)
            Me.uiTrnTerimaJasa_RefreshPosition()

        End If
    End Function

    Private Function uiTrnTerimaJasa_Prev() As Boolean
        'goto previous record found
        If Me.DgvTrnTerimajasa.SelectedRows.Count - 1 Then
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
                move = Me.uiTrnTerimaJasa_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnTerimajasa.CurrentCell.RowIndex > 0 Then
                Me.DgvTrnTerimajasa.CurrentCell = Me.DgvTrnTerimajasa(1, DgvTrnTerimajasa.CurrentCell.RowIndex - 1)
                Me.uiTrnTerimaJasa_RefreshPosition()
            End If
        End If
    End Function

    Private Function uiTrnTerimaJasa_Next() As Boolean
        'goto next record found
        If Me.DgvTrnTerimajasa.SelectedRows.Count - 1 Then
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
                move = Me.uiTrnTerimaJasa_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            If Me.DgvTrnTerimajasa.CurrentCell.RowIndex < Me.DgvTrnTerimajasa.Rows.Count - 1 Then
                Me.DgvTrnTerimajasa.CurrentCell = Me.DgvTrnTerimajasa(1, DgvTrnTerimajasa.CurrentCell.RowIndex + 1)
                Me.uiTrnTerimaJasa_RefreshPosition()

            End If
        End If
    End Function

    Private Function uiTrnTerimaJasa_Last() As Boolean
        'goto last record found
        If Me.DgvTrnTerimajasa.SelectedRows.Count - 1 Then
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
                move = Me.uiTrnTerimaJasa_ConfirmSaveBeforeMove(Message)
            End If
        Else
            move = True
        End If

        If move Then
            Me.DgvTrnTerimajasa.CurrentCell = Me.DgvTrnTerimajasa(1, Me.DgvTrnTerimajasa.Rows.Count - 1)
            Me.uiTrnTerimaJasa_RefreshPosition()

        End If
    End Function

    Private Function uiTrnTerimaJasa_RefreshPosition() As Boolean
        'refresh position
        Dim iTab As Integer = Me.ftabMain.SelectedIndex
        If iTab = 1 Then uiTrnTerimaJasa_OpenRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
    End Function

    Private Function uiTrnTerimaJasa_ConfirmSaveBeforeMove(ByVal Message As String) As Boolean
        'confirm saving data changes before move
        Dim tbl_TrnTerimabarang_Temp_Changes As DataTable
        Dim tbl_TrnTerimabarangdetil_Changes As DataTable
        Dim res As System.Windows.Forms.DialogResult
        Dim i As Integer = 0
        Dim terimabarang_id As Object = New Object
        Dim move As Boolean = False
        Dim isTempChanged As Boolean = False

        If Me.DgvTrnTerimajasa.CurrentCell IsNot Nothing Then

            Me.BindingContext(Me.tbl_TrnTerimabarang_Temp).EndCurrentEdit()
            tbl_TrnTerimabarang_Temp_Changes = Me.tbl_TrnTerimabarang_Temp.GetChanges()

            For i = 0 To Me.tbl_TrnTerimabarang_TempStart.Columns.Count - 5
                If clsUtil.IsDbNull(Me.tbl_TrnTerimabarang_TempStart.Rows(0).Item(i), Me.tbl_TrnTerimabarang_TempStart.Columns(i).DefaultValue) <> clsUtil.IsDbNull(Me.tbl_TrnTerimabarang_Temp.Rows(0).Item(i), Me.tbl_TrnTerimabarang_Temp.Columns(i).DefaultValue) Then
                    isTempChanged = True
                    Exit For
                End If
            Next

            Me.DgvTrnTerimajasadetil.EndEdit()
            Me.BindingContext(Me.tbl_TrnTerimabarangdetil).EndCurrentEdit()
            tbl_TrnTerimabarangdetil_Changes = Me.tbl_TrnTerimabarangdetil.GetChanges()

            If isTempChanged Or tbl_TrnTerimabarangdetil_Changes IsNot Nothing Then
                res = MessageBox.Show(Message, mUiName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Select Case res
                    Case DialogResult.Yes
                        RaiseEvent FormBeforeSave(terimabarang_id)
                        Me.uiTrnTerimaJasa_Save()
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

    Private Function uiTrnTerimaJasa_FormError() As Boolean
        Dim ErrorMessage As String = ""
        Dim ErrorFound As Boolean = False
        Dim criteria As String = String.Empty
        Dim table_temps As DataTable = New DataTable
        Dim i As Integer
        Dim status As String = String.Empty

        Try

            If Me.obj_Terimajasa_status.Text = "-- Pilih --" Or Me.obj_Terimajasa_status.Text = String.Empty Then
                ErrorMessage = "PO status cannot be empty"
                Me.objFormError.SetError(Me.obj_Terimajasa_status, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Terimajasa_status, "")
            End If

            If Me.obj_Is_useable.Checked = True And Me.obj_Asset_barcode.Text = "" Then
                ErrorMessage = "Asset barcode cannot be empty"
                Me.objFormError.SetError(Me.obj_Asset_barcode, ErrorMessage)
                Throw New Exception(ErrorMessage)
            Else
                Me.objFormError.SetError(Me.obj_Asset_barcode, "")
            End If

            table_temps.Clear()
            If Me.obj_Order_id.Text = "" Then
                Exit Function
            End If
            criteria = String.Format("AND order_id = '{0}'", Me.obj_Order_id.Text)
            Me.DataFill(table_temps, "as_TrnTerimabarang_Select", criteria, obj_Channel_id_search.SelectedValue, obj_top.Value)

            For i = 0 To table_temps.Rows.Count - 1
                If table_temps.Rows(i).Item("status") = "COMPLETE" Then
                    ErrorMessage = "Data Not Save!!!" & vbCrLf & "Order ID has been complete"
                    Me.objFormError.SetError(Me.obj_Order_id, ErrorMessage)
                    Throw New Exception(ErrorMessage)
                    Exit For
                Else
                    Me.objFormError.SetError(Me.obj_Order_id, "")
                End If

            Next
            ' TODO: Cek Error disini
            ' objFormError.SetError()

            ' Throw New Exception("Error")
        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True
        End Try
        Return False
    End Function
    Private Function uiTrnTerimaJasa_FormErrorValidasi() As Boolean
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
            criteria = String.Format("and terimabarang_id = '{0}'", Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value)
            tabell.Rows.Clear()
            oDataFiller.DataFill(tabell, "as_TrnTerimabarangdetil_selectValidasi", criteria, Me._CHANNEL, 0)

            For i = 0 To tabell.Rows.Count - 1
                tipeAsset = clsUtil.IsDbNull(tabell.Rows(i).Item("tipeasset_id"), String.Empty)
                kategoriAsset = clsUtil.IsDbNull(tabell.Rows(i).Item("kategoriasset_id"), String.Empty)
                line = clsUtil.IsDbNull(tabell.Rows(i).Item("asset_line"), 0)

                If tipeAsset = String.Empty Or tipeAsset = "-- PILIH --" Then
                    ErrorMessage = "Tipe asset in Received Number " & _
                                    Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value & _
                                    " and asset detil Line " & line & " cannot be empty"
                    Me.objFormError.SetError(Me.obj_Tipeasset_id, ErrorMessage)
                    Throw New Exception(ErrorMessage)
                Else
                    Me.objFormError.SetError(Me.obj_Tipeasset_id, "")
                End If

                If kategoriAsset = String.Empty Or kategoriAsset = "-- PILIH --" Then
                    ErrorMessage = "Kategori asset in Received Number " & _
                                    Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value & _
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

    Private Function uiTrnTerimaJasa_ValidasiAsset(ByRef terimabarang_id As Object, ByRef channel_id As Object) As Boolean
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

            Me.uiTrnTerimaJasa_OpenRowDetil(channel_id, terimabarang_id, dbConn)
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

    Private Sub uiTrnTerimaJasa_LoadComboSearch()


        If Me._LOADCOMBOSEARCH = False Then
            '-----Mulai Bikin Tabel untuk combo Data Search-------------------------
            Me.ComboFill(obj_Channel_id_search, "channel_id", "channel_id", tbl_MstChannel_channel_id_search, "as_MstChannel_select", "", "")
            Me.tbl_MstChannel_channel_id_search.DefaultView.Sort = "channel_name"
            ' ''Me.ComboFillAngka(obj_Rekanan_id_search, "rekanan_id", "rekanan_name", tbl_MstRekanan_rekanan_id_search, "as_MstRekanan_select", "rekanantype_id = 1", "")
            Me.ComboFillAngka(Me.ASSET_DSN, obj_Rekanan_id_search, "rekanan_id", "rekanan_name", tbl_MstRekanan_rekanan_id_search, "as_MstRekanan_select", "", "")

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

        
            Me._LOADCOMBOSEARCH = True
        End If

    End Sub

    Private Sub uiTrnTerimaJasa_LoadComboBox()
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
                Me.ComboFill(Me.obj_Employee_id_pemilik, "employee_id", "employee_namalengkap", Me.Tbl_Mstemployeepemilik, "ms_MstEmployee_Select", "")
                'Me.ComboFill(Me.obj_Employee_id_pemilik, "employee_id", "employee_namalengkap", Me.Tbl_Mstemployeepemilik, "ms_MstEmployee_Select", " strukturunit_id = " & Me._SU_EMPLOYEE)
                Me.Tbl_Mstemployeepemilik.DefaultView.Sort = "employee_namalengkap"

                Dim LL As Boolean
                Me.Tbl_Mstemployeeowner = Tbl_Mstemployeepemilik.Copy
                LL = ComboFillFromDataTable(obj_Employee_id_owner, "employee_id", "employee_namalengkap", Tbl_Mstemployeeowner)
                Me.Tbl_Mstemployeeowner.DefaultView.Sort = "employee_namalengkap"

            End If
            Me._LoadComboInLoadData = True
        End If
    End Sub

    Private Sub uiTrnTerimaJasa_LoadCombo()
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
            Me.ComboFill(Me.obj_Kategoriitem_id, "category_name", "category_name", Me.tbl_MstKategorijasa, "as_MstKategorijasa_Select", "  ")
            Me.tbl_MstKategorijasa.DefaultView.Sort = "category_name"
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
            Me.ComboFill(Me.obj_Project_id, "budget_id", "budget_nameshort", Me.tbl_project, "ms_MstBudgetCombo_Select ", " ", _CHANNEL)
            tbl_project.DefaultView.Sort = "budget_name"
            Me.ComboFill(Me.obj_Show_id, "show_id", "show_title", Me.tbl_show, "as_MstShow_Select ", " ", _CHANNEL)
            tbl_show.DefaultView.Sort = "show_title"
            Me.ComboFill(Me.obj_Show_id_cont_item, "show_id", "show_title", Me.tbl_showcont, "as_MstShow_Select ", " ", _CHANNEL)
            tbl_showcont.DefaultView.Sort = "show_title"

            '----------- Untuk Narik PO ------------'
            'Me.ComboFill(Me.obj_Order_id, "order_id", "order_id", Me.tbl_MstTrnOrder, "as_TrnOrder_Select", " strukturunit_id = " & Me._STRUKTUR_UNIT & " AND order_canceled = 0 AND (ordertype_id = 'RO' or ordertype_id = 'MO' )")
            ''Me.ComboFill(Me.obj_Order_id, "order_id", "order_id", Me.tbl_MstTrnOrder, "as_TrnOrder_Select", " strukturunit_id = " & Me._STRUKTUR_UNIT & " AND order_id not in (SELECT order_id from transaksi_terimabarang where status = 'COMPLETE') AND (ordertype_id = 'RO' or ordertype_id = 'MO' )")
            'Me.tbl_MstTrnOrder.DefaultView.Sort = "order_id"

            Me.ftabDataDetil.SelectedIndex = 1
            Me.ftabDataDetil.SelectedIndex = 0


            Me._LOADCOMBO = True
            '-----End Bikin Tabel untuk combo Data  ----------------------------------

            'Ini Untuk Jurnal na'

            oDataFiller.DataFillForCombo("acc_id", "acc_nameshort", Me.tbl_MstAccD, "cp_MstAcc_Select", "")
            Me.tbl_MstAccK = Me.tbl_MstAccD.Copy
            oDataFiller.DataFillForCombo("rekanan_id", "rekanan_name", Me.tbl_MstRekananGrid, "ms_MstRekanan_Select", "")
            oDataFiller.DataFillForCombo("currency_id", "currency_shortname", Me.tbl_MstCurrencyGrid, "ms_MstCurrency_Select", "")
           
            'end dari untuk jurnal'
        End If

    End Sub

#End Region

    Private Sub uiTrnTerimaJasa_FormAfterOpenRow(ByRef id As Object) Handles Me.FormAfterOpenRow
        Me.tbl_TrnTerimabarangdetil.RejectChanges()
        Me.tbl_TrnTerimabarang_TempStart.Clear()
        Me.tbl_TrnTerimabarang_TempStart = Me.tbl_TrnTerimabarang_Temp.Copy
    End Sub

    Private Sub uiTrnTerimaJasa_FormBeforeNew() Handles Me.FormBeforeNew

        Me.objFormError.Clear()
    End Sub

    Private Sub uiTrnTerimaJasa_FormBeforeOpenRow(ByRef id As Object) Handles Me.FormBeforeOpenRow
        Me.objFormError.Clear()
    End Sub
    Public Sub Form_Load(ByVal sender As Object)
        Dim oDataFiller As New clsDataFiller(DSN)
        Me.ToolStrip1.BackgroundImage = Me.ImageList1.Images(5)
        Me.ToolStrip1.BackgroundImageLayout = ImageLayout.Stretch
        Dim components As Control
        Dim objParameters As Collection = New Collection
        'TODO: - Extract Parameter
        '      - Assign parameter
        objParameters = Me.GetParameterCollection(Me.Parameter)

        Me.DgvTrnTerimajasa.DataSource = Me.tbl_TrnTerimabarang
        If Application.ProductName = _ProductName Then
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._STRUKTUR_UNIT = (Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT"))
            Me._CANCHANGESU = Me.GetBolValueFromParameter(objParameters, "CANCHANGESU")
            Me._PROCSU = Me.GetDecValueFromParameter(objParameters, "PROCSU")
            Me._US = Me.GetBolValueFromParameter(objParameters, "US")
            Me._PC = Me.GetBolValueFromParameter(objParameters, "PC")
            Me._BM = Me.GetBolValueFromParameter(objParameters, "BM")
            Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        End If

        'DI COMMENT KETIKA MASUK TRANSBROWSER!!!!
        'If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
        '    Dim dummyparameter As String = "CHANNEL=TTV;STRUKTUR_UNIT=5517;CHANNEL_CANBE_CHANGED=0;CHANNEL_CANBE_BROWSED=0;US=1;PC=1;BM=1;CANCHANGESU=0;PROCSU=5507;SU_EMPLOYEE=9002000;"
        '    objParameters = Me.GetParameterCollection(dummyparameter)
        '    Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
        '    Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_CHANGED")
        '    Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNEL_CANBE_BROWSED")
        '    Me._STRUKTUR_UNIT = Me.GetValueFromParameter(objParameters, "STRUKTUR_UNIT")
        '    Me._CANCHANGESU = Me.GetBolValueFromParameter(objParameters, "CANCHANGESU")
        '    Me._PROCSU = Me.GetValueFromParameter(objParameters, "PROCSU")
        '    Me._US = Me.GetBolValueFromParameter(objParameters, "US")
        '    Me._PC = Me.GetBolValueFromParameter(objParameters, "PC")
        '    Me._BM = Me.GetBolValueFromParameter(objParameters, "BM")
        '    Me._SU_EMPLOYEE = Me.GetValueFromParameter(objParameters, "SU_EMPLOYEE")
        'End If
        '--------------------------------END COMMENT KETIKA TRANSBROWSER------'
        'Dim criteria As String = String.Format(" strukturunit_id = {0}", Me._STRUKTUR_UNIT)
        'oDataFiller.DataFill(tabels_order, "as_BpjOrder_Select", criteria)

        Me.InitLayoutUI()
        Me.BindingStop()
        Me.BindingStart()

        uiTrnTerimaJasa_LoadComboSearch()
        Me.tbtnSave.Enabled = False
        Me.tbtnDel.Enabled = False
        Me.tbtnLoad.Enabled = True
        Me.tbtnQuery.Enabled = True
        Me.btnHome.Enabled = False

        Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").DefaultCellStyle.BackColor = Color.Lavender


        '--- ADDITIONAL IMAGE----
        ' Tambahan Button di toolstrip
        Me.btnlock.ToolTipText = "Lock Transaction"
        Me.ToolStrip1.Items.Add(Me.btnlock)
        Me.btnHome.ToolTipText = "Close"
        Me.ToolStrip1.Items.Add(Me.btnHome)
        Me.btnlock.Image = Me.ImageList1.Images(6)
        Me.btnHome.Image = Me.ImageList1.Images(3)

        '--SETTING DI SEARCH PANEL---'

        Me.chk_Channel_id_search.Enabled = Me._CHANNEL_CANBE_BROWSED
        Me.chk_Channel_id_search.Checked = True
        Me.obj_Channel_id_search.Enabled = Me._CHANNEL_CANBE_BROWSED
        Me.obj_Channel_id_search.SelectedValue = Me._CHANNEL

        Me.obj_Strukturunit_id_pemilik_search.SelectedValue = Me._STRUKTUR_UNIT
        Me.chk_Strukturunit_id_pemilik_search.Checked = True
        Me.chk_Strukturunit_id_pemilik_search.Enabled = Me._CANCHANGESU
        Me.obj_Strukturunit_id_pemilik_search.Enabled = Me._CANCHANGESU


        '--SETTING DI MAIN PANEL---'
        'Me.obj_Channel_id.Enabled = Me._CHANNEL_CANBE_CHANGED
        Me.obj_Channel_id.Enabled = False
        Me.obj_Strukturunit_id_pemilik.Enabled = False

        Me.Panel1.Visible = False
        'Me.Panel2.Enabled = True
        'Me.PnlAccounting.Enabled = False
        'For Each components In FTabItem.Controls
        '    components.Enabled = False
        'Next
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

        Me.btnlock.Enabled = True
        'Me.btnPicture.Enabled = False
        Me.cmb_appuser.SelectedItem = "No"

        If Me._US = True Or Me._PC = True Then
            Me.FTabItem.Visible = False
            Me.ftabDataDetil_Amount.Dispose()
            For Each components In ftabDataDetil_Amount.Controls
                components.Visible = False
            Next
        End If

        'SETTING PROC,USER ATO ACCOUNTING ato SuperUser
        If Me._BM = True And Me._PC = True And Me._US = True Then
            Me.btnlock.Enabled = True
            'Me.PnlAccounting.Enabled = True
            'For Each components In FTabItem.Controls
            '    components.Enabled = True
            'Next
            'Me.PnlUser.Enabled = True
            For Each components In Panel1.Controls
                'If components.Name <> "FTabItem" Then
                If components.Name <> "obj_Order_idDetil" Then
                    If components.Name <> "obj_orderdetil_line" Then
                        components.Enabled = True
                    End If
                End If
                'End If
            Next

            Me.FTabItem.Visible = True
            Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = False
            'Me.obj_Status.Enabled = True
        ElseIf Me._BM = True Then
            Me.FTabItem.Visible = True
            'For Each components In ftabDataDetil_Amount.Controls
            '    components.Enabled = False
            'Next
            Me.FormatDgvTrnJurnaldetil(Me.DgvTrnJurnaldetil)
            Me.FormatDgvTrnJurnaldetil(Me.DgvTrnJurnaldetil_Pembayaran)
            Me.FormatDgvTrnJurnalreference(Me.DgvTrnJurnalreference)
            Me.FormatDgvTrnJurnalreference(Me.DgvTrnJurnalresponse)
            Me.btnlock.Enabled = False
            For Each components In FTabItem.Controls
                components.Enabled = True
            Next
            ''For Each components In Panel1.Controls
            ''    If components.Name <> "FTabItem" Then
            ''        components.Enabled = False
            ''    End If
            ''Next
            Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = True
            Me.DgvTrnTerimajasadetil.AllowUserToAddRows = False
            Me.DgvTrnTerimajasadetil.AllowUserToDeleteRows = False

            Me.chk_User_search.Checked = True
            Me.cmb_appuser.SelectedItem = "Yes"
            Me.obj_Status.Enabled = False
            Me.tbtnNew.Enabled = False
            Me.tbtnPrint.Enabled = False
            Me.tbtnPrintPreview.Enabled = False
        ElseIf Me._PC = True Then
            Me.btnlock.Enabled = True
            'For Each components In Panel1.Controls
            '    components.Enabled = False
            'Next
            Me.DgvTrnTerimajasadetil.Columns("asset_deskripsi").ReadOnly = True
            Me.DgvTrnTerimajasadetil.AllowUserToAddRows = False

            Me.chk_User_search.Checked = False
            Me.cmb_appuser.SelectedItem = "Yes"

            Me.obj_Status.Enabled = False
        End If

        If Me._US = True Then
            Me.isUser = "user"
        ElseIf Me._PC = True Then
            Me.isUser = "proc"
        ElseIf Me._BM = True Then
            Me.isUser = "bma"
        End If
    End Sub


    Private Sub uiTrnTerimaJasa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Lavender
                Me.btnlock.Enabled = True

                If Me._BM = True Then
                    Me.btnlock.Enabled = True
                    Me.tbtnNew.Enabled = False
                ElseIf Me._PC = True Then
                    Me.btnlock.Enabled = True
                End If
            Case 1

                uiTrnTerimaJasa_LoadCombo()
                If Me._BM = True Then
                    Me.tbtnSave.Enabled = False
                    Me.tbtnDel.Enabled = False
                Else
                    Me.tbtnSave.Enabled = True
                    Me.tbtnDel.Enabled = True
                End If
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Lavender
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White

                Me.btnlock.Enabled = False
                Me.btnHome.Enabled = False

                If Me.DgvTrnTerimajasa.CurrentRow IsNot Nothing Then
                    Me.uiTrnTerimaJasa_OpenRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
                Else
                    Me.uiTrnTerimaJasa_NewData()
                    Me.Btn_Add.Enabled = False
                    Me.btn_bonus.Enabled = False
                    Me.btn_DeleteItem.Enabled = False
                End If

                If Me.obj_Terimajasa_id.Text <> "" Then
                    Me.DgvTrnTerimajasadetil.Enabled = True
                Else
                    Me.DgvTrnTerimajasadetil.Enabled = False
                End If

        End Select
    End Sub

    Private Sub DgvTrnTerimajasa_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnTerimajasa.CellClick
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            If Me.DgvTrnTerimajasa.Rows.Count > 0 Then
                If Me._US = True Then
                    If Me.DgvTrnTerimajasa.Rows(e.RowIndex).Cells("terimabarang_appuser").Value = 1 Then
                        Me.btnlock.Image = Me.ImageList1.Images(7)
                        Me.btnlock.ToolTipText = "UnApproved Transaction"
                    Else
                        Me.btnlock.Image = Me.ImageList1.Images(6)
                        Me.btnlock.ToolTipText = "Approved Transaction"
                    End If
                ElseIf Me._PC = True Then
                    If Me.DgvTrnTerimajasa.Rows(e.RowIndex).Cells("terimabarang_appprc").Value = 1 Then
                        Me.btnlock.Image = Me.ImageList1.Images(7)
                        Me.btnlock.ToolTipText = "UnApproved Transaction"
                    Else
                        Me.btnlock.Image = Me.ImageList1.Images(6)
                        Me.btnlock.ToolTipText = "Approved Transaction"
                    End If
                ElseIf Me._BM = True Then
                    If Me.DgvTrnTerimajasa.Rows(e.RowIndex).Cells("terimabarang_appbma").Value = 1 Then
                        Me.btnlock.Image = Me.ImageList1.Images(7)
                        Me.btnlock.ToolTipText = "UnApproved Transaction"
                    Else
                        Me.btnlock.Image = Me.ImageList1.Images(6)
                        Me.btnlock.ToolTipText = "Approved Transaction"
                    End If
                End If
            End If
        End If
    End Sub


    'Private Sub cek_BarcodeButton()
    '    Dim iTab As Integer = Me.ftabMain.SelectedIndex
    '    If iTab = 0 Then
    '        If Me.DgvTrnTerimajasa.Rows.Count > 0 Then
    '            If Me.DgvTrnTerimajasa.CurrentRow.Cells("terimabarang_appbma").Value = 1 Then
    '                Me.btnbarcode.Enabled = True
    '                Me.btnkain.Enabled = True
    '            Else
    '                Me.btnbarcode.Enabled = False
    '                Me.btnkain.Enabled = False
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub DgvTrnTerimajasa_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnTerimajasa.CellDoubleClick
        If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
            Exit Sub
        End If
        If Me.DgvTrnTerimajasa.CurrentRow IsNot Nothing Then
            Me.ftabMain.SelectedIndex = 1
        End If
    End Sub
#Region " barcode detil "
    'Private Sub LoadDetilbarcodekain()
    '    'validasi doeloe
    '    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
    '    Dim FILE_NAME As String

    '    Dim jenis_barcode As String = "KAIN"

    '    Me.filePath_shellPath(jenis_barcode)

    '    FILE_NAME = Me.file_path
    '    Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
    '    If Me.DgvTrnTerimajasa.CurrentRow IsNot Nothing Then
    '        Me.uiTrnTerimaJasa_OpenRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
    '        Dim drNews As DataRow
    '        For Each drNews In tbl_TrnTerimabarangdetil.Rows
    '            objWriter.WriteLine(drNews.Item("asset_barcode").ToString)
    '        Next
    '    Else
    '        MsgBox("Select Receiving Number")
    '    End If
    '    objWriter.Close()

    '    Shell(shell_path, AppWinStyle.NormalFocus)

    '    System.Windows.Forms.Cursor.Current = Cursors.Default
    'End Sub

    'Private Sub btnkain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkain.Click
    '    LoadDetilbarcodekain()
    'End Sub
#End Region
#Region " barcode detil "
    'Private Sub LoadDetilbarcode()
    '    'validasi doeloe
    '    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
    '    Dim FILE_NAME As String
    '    Dim jenis_barcode As String = "BIASA"

    '    Me.filePath_shellPath(jenis_barcode)

    '    FILE_NAME = Me.file_path
    '    Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
    '    If Me.DgvTrnTerimajasa.CurrentRow IsNot Nothing Then
    '        Me.uiTrnTerimaJasa_OpenRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
    '        Dim drNews As DataRow
    '        For Each drNews In tbl_TrnTerimabarangdetil.Rows
    '            objWriter.WriteLine(drNews.Item("asset_barcode").ToString)
    '        Next
    '    Else
    '        MsgBox("Select Receiving Number")
    '    End If
    '    objWriter.Close()

    '    Shell(shell_path, AppWinStyle.NormalFocus)
    '    System.Windows.Forms.Cursor.Current = Cursors.Default
    'End Sub

    'Private Sub btnbarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbarcode.Click
    '    LoadDetilbarcode()
    'End Sub
#End Region
    Private Sub LockDataBMA(ByVal status As String)
        'validasi doeloe

        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            ' ''Dim oCm As New OleDb.OleDbCommand("as_LockBMAtransaksi_terimabarang", dbConn)
            Dim oCm As New OleDb.OleDbCommand("as_TrnTerimabarang_bmaApproved", dbConn)

            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            oCm.Parameters.Add("@bma_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status
            oCm.Parameters.Add("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24).Value = Mid(Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value, 12, 15)

            oCm.ExecuteNonQuery()
            oCm.Dispose()
            If status = "approved" Then
                Me.obj_Terimajasa_appbma.Checked = True
                MessageBox.Show("Data Has Been Post", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DgvTrnTerimajasa.Item("terimabarang_appbma", Me.DgvTrnTerimajasa.CurrentRow.Index).Value = 1
            Else
                Me.obj_Terimajasa_appbma.Checked = False
                MessageBox.Show("Data Has Been UnPost", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DgvTrnTerimajasa.Item("terimabarang_appbma", Me.DgvTrnTerimajasa.CurrentRow.Index).Value = 0
            End If
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        Me.uiTrnTerimaJasa_OpenRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub LockPrcData(ByVal status_approved As String)
        Dim dlg As New dlgStatusTerimaJasa()
        Dim status As String = String.Empty
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If status_approved = "approved" Then

            status = dlg.OpenDialog(Me)

            If status IsNot Nothing Then
                If status = "-- Pilih --" Then
                    MsgBox("Please choose COMPLETE or INCOMPLETE")
                    Exit Sub
                Else

                    ' ''Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                    Try
                        Me.builtJurnal()
                        dbConn.Open()
                        Dim oCm As New OleDb.OleDbCommand("as_TrnTerimabarang_ProcApproved", dbConn)
                        oCm.CommandType = CommandType.StoredProcedure
                        oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value
                        oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
                        oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
                        oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 40).Value = status
                        oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("order_id").Value
                        oCm.Parameters.Add("@status_approved", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status_approved
                        oCm.Parameters.Add("@jurnal_id_rv", System.Data.OleDb.OleDbType.VarWChar, 24).Value = Mid(Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value, 12, 15)
                        oCm.ExecuteNonQuery()
                        oCm.Dispose()
                        Me.obj_Terimajasa_appprc.Checked = True
                        Me.DgvTrnTerimajasa.Item("terimabarang_appprc", DgvTrnTerimajasa.CurrentRow.Index).Value = 1
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
        Else
            Try
                ' ''Me.builtJurnal()

                If Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("order_id").Value, 1, 2) = "TO" Then
                    Me.uiTrnTerimaJasa_ReGenerate_pajakArtis()
                End If
                dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("as_TrnTerimabarang_ProcApproved", dbConn)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value
                oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
                oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
                oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 40).Value = status
                oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("order_id").Value
                oCm.Parameters.Add("@status_approved", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status_approved
                oCm.Parameters.Add("@jurnal_id_rv", System.Data.OleDb.OleDbType.VarWChar, 24).Value = Mid(Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value, 12, 15)
                oCm.ExecuteNonQuery()
                oCm.Dispose()
                Me.obj_Terimajasa_appprc.Checked = True
                Me.DgvTrnTerimajasa.Item("terimabarang_appprc", DgvTrnTerimajasa.CurrentRow.Index).Value = 0
                MessageBox.Show("Data Has Been UnApproved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dbConn.Close()
            End Try
        End If
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    'Private Sub UpdateBarcodeAfterLockData()
    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
    '    Try
    '        dbConn.Open()
    '        Dim oDm As New OleDb.OleDbCommand("as_TrnTerimabarangdetil_update_Barcode", dbConn)
    '        oDm.CommandType = CommandType.StoredProcedure
    '        oDm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value
    '        oDm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
    '        oDm.ExecuteNonQuery()
    '        oDm.Dispose()
    '    Catch ex As Data.OleDb.OleDbException
    '        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Catch ex As Exception
    '        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        dbConn.Close()
    '    End Try

    '    System.Windows.Forms.Cursor.Current = Cursors.Default
    'End Sub
    Private Sub DgvTrnTerimajasadetil_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvTrnTerimajasadetil.CellClick
        'Dim tbl_TrnTerimabarangdetil_Changes As DataTable
        'Dim success As Boolean
        'Dim terimabarang_id As Object = New Object
        'Dim i As Integer = 0
        'Dim MasterDataState As System.Data.DataRowState

        Select Case e.ColumnIndex
            Case Me.DgvTrnTerimajasadetil.Columns("asset_button").Index

                If Trim(Me.DgvTrnTerimajasadetil.Item("asset_deskripsi", Me.DgvTrnTerimajasadetil.CurrentRow.Index).Value) = "" Then
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
                Me.txtUsage.Text = Me.DgvTrnTerimajasadetil.Rows(e.RowIndex).Cells("usage").Value


                If Me._BM = True Then
                    'For Each components In Panel1.Controls
                    '    components.Enabled = False
                    'Next
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
                    Me.DgvTrnTerimajasadetil.AllowUserToAddRows = False
                    Me.DgvTrnTerimajasadetil.AllowUserToDeleteRows = False
                    Exit Sub
                End If

                Try
                    Me.obj_Employee_id_owner.SelectedValue = Me.obj_Employee_id_pemilik.SelectedValue
                    Me.Obj_asset_channel_id.SelectedValue = Me.obj_Channel_id.SelectedValue
                    Me.obj_Strukturunit_id.SelectedValue = Me.obj_Strukturunit_id_pemilik.SelectedValue
                Catch ex As Exception

                End Try

            Case Me.DgvTrnTerimajasadetil.Columns("days_button").Index

                If Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("status_ro").Value = "MANUAL" Then
                    Dim listDaysOrder As New dlgListOrder_days(Me.DSN, Me._CHANNEL, Me.obj_Terimajasa_id.Text, Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value, "MANUAL", _
                            Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_line").Value, Me.isUser, Me.isLock)
                    Me.total_days = listDaysOrder.OpenDialog(Me)

                    If Me.total_days <> 9999 Then
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_lineinduk").Value = Me.total_days
                        Me.uiTrnTerimaJasa_Save()
                    End If

                ElseIf Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("status_ro").Value = "TO" Then
                    Dim dlgEps As New DlgSelectEps(Me.DSN, Me._CHANNEL, Me.obj_Terimajasa_id.Text, Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value, Me.obj_Terimajasa_status.SelectedItem, _
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_line").Value, Me.isUser, Me.isLock)
                    Dim c, total_qty As Integer
                    Me.total_days = dlgEps.OpenDialog(Me)

                    If Me.total_days <> 9999 Then
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_lineinduk").Value = Me.total_days

                        Dim tbl_retOrder As New DataTable
                        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                        Dim criteria As String = String.Empty

                        criteria = String.Format(" tor.order_id = '{0}' AND tb.orderdetil_line = {1}", Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("order_id").Value, Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value)
                        For c = 0 To dlgEps.DgvRequestdetileps.Rows.Count - 1
                            If clsUtil.IsDbNull(dlgEps.DgvRequestdetileps.Rows(c).Cells("terimabarang_check").Value, 0) = 1 Then
                                total_qty += clsUtil.IsDbNull(dlgEps.DgvRequestdetileps.Rows(c).Cells("terimabarang_qty").Value, 0)
                            End If
                        Next
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("usage").Value = total_qty

                        Me.hitung_pajak_artis(total_qty)
                        ' ''tbl_retOrder.Clear()
                        ' ''Try
                        ' ''    Me.DataFill(tbl_retOrder, "as_TrnOrderDetilJasa_SelectTO", criteria)

                        ' ''    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") = Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                        ' ''    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") = Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                        ' ''    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc") = tbl_retOrder.Rows(0).Item("orderdetil_discount")
                        ' ''    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_idrprice") = Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc"))

                        ' ''Catch ex As Exception
                        ' ''    MsgBox(ex.Message)
                        ' ''End Try

                        ' ''Me.uiTrnTerimaJasa_Save()
                    End If

                ElseIf Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("status_ro").Value = "EO" Then
                    Dim dlgEps As New dlgListEditing_eps_shift(Me.DSN, Me._CHANNEL, Me.obj_Terimajasa_id.Text, _
                                           Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value, Me.isUser, Me.isLock, Me.obj_Rekanan_id.SelectedValue)
                    Me.total_days = dlgEps.OpenDialog(Me)

                    If Me.total_days <> 9999 Then
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_lineinduk").Value = Me.total_days

                        Dim tbl_retOrder As New DataTable
                        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                        Dim criteria As String = String.Empty
                        Dim c As Integer
                        Dim total_qty As Decimal = 0

                        criteria = String.Format(" tor.order_id = '{0}' AND orderdetil_line = {1}", Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("order_id").Value, Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value)
                        For c = 0 To dlgEps.DgvListBPJ.Rows.Count - 1
                            If clsUtil.IsDbNull(dlgEps.DgvListBPJ.Rows(c).Cells("terimabarang_check").Value, 0) = 1 Then
                                total_qty += clsUtil.IsDbNull(dlgEps.DgvListBPJ.Rows(c).Cells("eps_total_usage").Value, 0)
                            End If
                        Next

                        tbl_retOrder.Clear()
                        Try
                            Me.DataFill(tbl_retOrder, "as_TrnOrderDetilJasa_SelectEO", criteria)

                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") = (((tbl_retOrder.Rows(0).Item("orderdetil_foreign") / 8) * tbl_retOrder.Rows(0).Item("orderdetil_foreignrate") * total_qty) - tbl_retOrder.Rows(0).Item("orderdetil_discount")) * tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent") / 100
                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") = (((tbl_retOrder.Rows(0).Item("orderdetil_foreign") / 8) * tbl_retOrder.Rows(0).Item("orderdetil_foreignrate") * total_qty) - tbl_retOrder.Rows(0).Item("orderdetil_discount")) * tbl_retOrder.Rows(0).Item("orderdetil_pphpercent") / 100
                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc") = tbl_retOrder.Rows(0).Item("orderdetil_discount")
                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_idrprice") = ((tbl_retOrder.Rows(0).Item("orderdetil_foreign")) / 8) * tbl_retOrder.Rows(0).Item("orderdetil_foreignrate") * total_qty + Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") - Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") - Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc")

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        Me.uiTrnTerimaJasa_Save()
                    End If
                Else

                    Dim ListDaysOrder As New dlgListOrder_days(Me.DSN, Me._CHANNEL, Me.obj_Terimajasa_id.Text, Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value, Me.obj_Terimajasa_status.SelectedItem, _
                            Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_line").Value, Me.isUser, Me.isLock)
                    Dim c As Integer
                    Dim total_qty As Integer

                    Me.total_days = ListDaysOrder.OpenDialog(Me)

                    If Me.total_days <> 9999 Then
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_lineinduk").Value = Me.total_days

                        Dim tbl_retOrder As New DataTable
                        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
                        Dim criteria As String = String.Empty

                        criteria = String.Format(" tor.order_id = '{0}' AND orderdetil_line = {1}", Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("order_id").Value, Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value)
                        For c = 0 To ListDaysOrder.DgvListBPJ.Rows.Count - 1
                            If clsUtil.IsDbNull(ListDaysOrder.DgvListBPJ.Rows(c).Cells("terimabarang_check").Value, 0) = 1 Then
                                total_qty += clsUtil.IsDbNull(ListDaysOrder.DgvListBPJ.Rows(c).Cells("terimabarangused_qty").Value, 0)
                            End If
                        Next
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("usage").Value = Me.total_days


                        tbl_retOrder.Clear()
                        Try
                            Me.DataFill(tbl_retOrder, "as_TrnOrderdetilJasa_Select", criteria)

                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") = ((Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(total_qty)) - Val(tbl_retOrder.Rows(0).Item("orderdetil_discount"))) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") = ((Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(total_qty)) - Val(tbl_retOrder.Rows(0).Item("orderdetil_discount"))) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc") = tbl_retOrder.Rows(0).Item("orderdetil_discount")
                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_idrprice") = Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(total_qty) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc"))

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        Me.uiTrnTerimaJasa_Save()

                    End If
                End If
        End Select
    End Sub
    ' ''Private Sub obj_Asset_harga_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    ' ''    Dim harga As Decimal = Me.obj_Asset_harga.Text
    ' ''    Dim valas As Decimal = Me.obj_Asset_valas.Text

    ' ''    Me.obj_Asset_idrprice.Text = Format(harga * valas, "#,##0.00")
    ' ''End Sub
    ' ''Private Sub obj_Asset_valas_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    ' ''    Dim harga As Decimal = Me.obj_Asset_harga.Text
    ' ''    Dim valas As Decimal = Me.obj_Asset_valas.Text
    ' ''    Me.obj_Asset_idrprice.Text = Format(harga * valas, "#,##0.00")
    ' ''End Sub

#Region " Print Preview & Print "
    Private Function GenerateDataHeader() As ArrayList
        Dim objDatalistHeader As ArrayList = New ArrayList()

        Me.tbl_MstTrnOrder.Clear()
        tbl_Print.Clear()
        tbl_PrintDetil.Clear()
        objPrintHeader = New DataSource.clsRptBarang(Me.DSN)
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        Dim order_id As String
        Dim request_id As String

        DataFill(tbl_Print, "as_TrnTerimabarang_Select", String.Format("and terimabarang_id = '{0}'", DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.SelectedCells.Item(0).RowIndex).Value), Me.obj_Channel_id_search.SelectedValue, Me.obj_top.Value)
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
            .location = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("location").ToString, String.Empty)
            .user_applogin = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("user_applogin").ToString, String.Empty)
            .notes = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("notes").ToString, String.Empty)
            .status_kedatangan = clsUtil.IsDbNull(Me.tbl_Print.Rows(0).Item("status_kedatangan").ToString, String.Empty)
            order_id = String.Format("order_id='{0}'", .order_id)
            If Mid(.order_id, 1, 2) = "TO" Then
                'buat narik shooting date
                dtFiller.DataFillLimit(Me.tbl_MstTrnOrder, "pr_TrnOrder_Select", order_id, 1)
                .shooting_date = clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("order_utilizeddatestart").ToString, String.Empty)

                'buat narik producer dan talent
                request_id = String.Format("request_id='{0}'", clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("request_id").ToString, String.Empty))
                dtFiller.DataFill(Me.tbl_request, " cq_TrnRequest_Select", request_id)
                .user_pic = clsUtil.IsDbNull(Me.tbl_request.Rows(0).Item("request_userpic").ToString, String.Empty)
                .used_by = clsUtil.IsDbNull(Me.tbl_request.Rows(0).Item("request_usedby").ToString, String.Empty)
                .budget_id = clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("budget_id"), String.Empty)

            ElseIf Mid(.order_id, 1, 2) = "EO" Then
                dtFiller.DataFillLimit(Me.tbl_MstTrnOrder, "eo_TrnEditing_Order_Select", order_id, 1)
                .budget_id = clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("budget_id"), String.Empty)

            Else 'If Mid(.order_id, 1, 2) = "MO" Then
                dtFiller.DataFillLimit(Me.tbl_MstTrnOrder, "pr_TrnOrder_Select", order_id, 1)
                .budget_id = clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("budget_id").ToString, String.Empty)
            End If




            Me.order = .order_id
            Me.sptChannel_ID = .channel_id
            Me.sptChannel_nameReport = .channel_namereport
            Me.sptChannel_address = .channel_address
            Me.sptTerimaBarang_ID = .terimabarang_id
            If Mid(Me.order, 1, 2) = "TO" Then
                DataFill(tbl_PrintDetil, "as_TrnTerimabarangdetilTO_select", String.Format("And terimabarang_id = '{0}'", .terimabarang_id), Me.obj_Channel_id_search.SelectedValue, Me.obj_top.Value)
            ElseIf Mid(Me.order, 1, 2) = "EO" Then

                DataFill(tbl_PrintDetil, "as_TrnTerimabarangdetilEO_select", String.Format("And terimabarang_id = '{0}'", .terimabarang_id), Me.obj_Channel_id_search.SelectedValue, Me.obj_top.Value)
            Else

                DataFill(tbl_PrintDetil, "as_TrnTerimabarangdetil_select", String.Format("And terimabarang_id = '{0}'", .terimabarang_id), Me.obj_Channel_id_search.SelectedValue, Me.obj_top.Value)
            End If

            GenerateDataDetail()
        End With
        objDatalistHeader.Add(objPrintHeader)

        Return objDatalistHeader
    End Function
    Private Sub GenerateDataDetail()
        Dim objDetil As DataSource.clsRptBarangDetil
        Dim i, j, episode, qty, k, a, b As Integer
        Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSN)
        'Dim criteria_peran As String
        'Dim code As Integer
        'Dim request_id As String
        'Dim order As String
        'Dim durasi1, durasi2, durasi3 As String
        Dim tbl_eps_talent As DataTable = New DataTable
        Dim tbl_shift_editing As DataTable = New DataTable
        Me.tbl_MstSkill.Clear()
        Me.tbl_MstTrnOrder.Clear()
        Me.tbl_request.Clear()
        Me.tbl_requesteps.Clear()


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
                .ukuran_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("ukuran_id").ToString, String.Empty)
                'count jumlah episode dan qty talent
                If Mid(Me.order, 1, 2) = "TO" Then
                    tbl_eps_talent.Clear()
                    DataFill(tbl_eps_talent, "as_TrnTerimajasaepstalent_Select", String.Format("order_id = '{0}' and orderdetil_line='{1}' and terimabarang_check=1", Me.tbl_PrintDetil.Rows(i).Item("order_id"), Me.tbl_PrintDetil.Rows(i).Item("orderdetil_line")))

                    For j = 0 To tbl_eps_talent.Rows.Count - 1
                        episode = clsUtil.IsDbNull(tbl_eps_talent.Rows(j).Item("terimabarang_check"), 0)
                        qty = clsUtil.IsDbNull(tbl_eps_talent.Rows(j).Item("terimabarang_qty"), 0)
                        .asset_eps += episode
                        .asset_qty += qty
                    Next
                ElseIf Mid(Me.order, 1, 2) = "EO" Then
                    tbl_shift_editing.Clear()
                    tbl_eps_talent.Clear()
                    dtFiller.DataFill(tbl_shift_editing, "as_TrnTerimajasashiftediting_Select", String.Format("order_id = '{0}' and orderdetil_line='{1}' and terimabarang_check=1", Me.tbl_PrintDetil.Rows(i).Item("order_id"), Me.tbl_PrintDetil.Rows(i).Item("orderdetil_line")))
                    dtFiller.DataFill(tbl_eps_talent, "eo_TrnEditing_Orderdetil_Select", String.Format("order_id = '{0}'  and orderdetil_line='{1}' ", tbl_shift_editing.Rows(0).Item("order_id"), tbl_shift_editing.Rows(0).Item("orderdetil_line")))
                    For k = 0 To tbl_shift_editing.Rows.Count - 1
                        .shift1 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("shift1"), 0)
                        .shift2 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("shift2"), 0)
                        .shift3 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("shift3"), 0)
                        .boot1 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("boot1"), 0)
                        .boot2 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("boot2"), 0)
                        .boot3 = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("boot3"), 0)
                        .eps_usage1_start = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage1_start").ToString, String.Empty)
                        .eps_usage1_end = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage1_end").ToString, String.Empty)
                        .eps_usage2_start = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage2_start").ToString, String.Empty)
                        .eps_usage2_end = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage2_end").ToString, String.Empty)
                        .eps_usage3_start = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage3_start").ToString, String.Empty)
                        .eps_usage3_end = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_usage3_end").ToString, String.Empty)
                        .edit_date = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("terimabarang_date").ToString, String.Empty)

                        'durasi1 = TimeDiff(.eps_usage1_start, .eps_usage1_end)
                        'durasi2 = TimeDiff(.eps_usage2_start, .eps_usage2_end)
                        'durasi3 = TimeDiff(.eps_usage3_start, .eps_usage3_end)


                        .eps_usage_total = clsUtil.IsDbNull(tbl_shift_editing.Rows(k).Item("eps_total_usage").ToString, String.Empty)
                        .Episode = clsUtil.IsDbNull(tbl_eps_talent.Rows(0).Item("orderdetil_eps").ToString, String.Empty)
                        b = 0
                        For a = 0 To Len(.Episode)
                            b += 1
                            If IsNumeric(Mid(.Episode, b)) Then
                                .Episode = Mid(.Episode, b)
                            End If
                        Next
                    Next


                Else
                    .asset_eps = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_eps").ToString, String.Empty)
                    .asset_qty = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("asset_qty"), 0)
                End If

                .wo_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("wo_id").ToString, String.Empty)
                .inputby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("inputby").ToString, String.Empty)
                .inputdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("inputdt"), Now())
                .editby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("editby").ToString, String.Empty)
                .editdt = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("editdt"), Now())
                .usedby = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("usedby").ToString, String.Empty)
                .order_id = clsUtil.IsDbNull(Me.tbl_PrintDetil.Rows(i).Item("order_id").ToString, String.Empty)


                'buat narik peran dan episode
                'order = String.Format("order_id='{0}'", .order_id)
                'dtFiller.DataFillLimit(Me.tbl_MstTrnOrder, "pr_TrnOrder_Select", order, 1)
                'request_id = String.Format("request_id='{0}'", clsUtil.IsDbNull(Me.tbl_MstTrnOrder.Rows(0).Item("request_id").ToString, String.Empty))
                'dtFiller.DataFill(Me.tbl_requestdetil, "pr_TrnRequestdetil_Select", request_id)
                'code = clsUtil.IsDbNull(Me.tbl_requestdetil.Rows(0).Item("requestdetil_bal"), 0)
                'criteria_peran = String.Format("code = '{0}' ", code)
                'dtFiller.DataFill(Me.tbl_MstSkill, "ms_MstSkill_Select", criteria_peran)

                'If tbl_MstSkill.Rows.Count = 0 Then
                '    .Peran = String.Empty
                'Else
                '    .Peran = clsUtil.IsDbNull(Me.tbl_MstSkill.Rows(0).Item("name").ToString, String.Empty)
                'End If

                'dtFiller.DataFillLimit(Me.tbl_requesteps, "tq_TrnRequestdetileps_Select", request_id)
                '.Episode = clsUtil.IsDbNull(Me.tbl_requesteps.Rows(0).Item("requestdetil_eps").ToString, String.Empty)
            End With
            objDatalistDetil.Add(objDetil)
        Next

        If Mid(Me.order, 1, 2) = "EO" Then
            'fake data
            For i = 0 To 27 - Me.tbl_PrintDetil.Rows.Count

                objDetil = New DataSource.clsRptBarangDetil(Me.DSN)
                With objDetil

                    .shift1 = 0
                End With
                objDatalistDetil.Add(objDetil)
            Next
        End If
    End Sub
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
        "  <MarginTop>0.2mm</MarginTop>" & _
        "  <MarginLeft>0.2mm</MarginLeft>" & _
        "  <MarginRight>0.2mm</MarginRight>" & _
        "  <MarginBottom>0.2mm</MarginBottom>" & _
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
        New System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory & "Temp\" + _
        name & "." & fileNameExtension, System.IO.FileMode.Create)

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
    Private Function uiTrnTerimaJasa_Print() As Boolean
        If Me.DgvTrnTerimajasa.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appprc").Value = 1 Then
            Dim objRdsH As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
            Dim objReportH As Microsoft.Reporting.WinForms.LocalReport = New Microsoft.Reporting.WinForms.LocalReport
            Dim objDatalistHeader As ArrayList = New ArrayList()
            Dim parRptImageURL As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("imageURL", Me.SptServer)

            objDatalistHeader = Me.GenerateDataHeader()

            Dim parRptChannelID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelID", Me.sptChannel_ID)
            Dim parRptChannel_namereport As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelName", Me.sptChannel_nameReport)
            Dim parRptChannel_address As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("channelAddress", Me.sptChannel_address)
            Dim parRptTerimaBarang_ID As Microsoft.Reporting.WinForms.ReportParameter = New Microsoft.Reporting.WinForms.ReportParameter("terimabarang_id", Me.sptTerimaBarang_ID)

            If Mid(Me.order, 1, 2) = "TO" Then
                objRdsH.Name = "ASSET_DataSource_clsRptBarang"
                objRdsH.Value = objDatalistHeader
                'If Me._BM = True Then
                objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasa_Talent.rdlc"
            ElseIf Mid(Me.order, 1, 2) = "EO" Then
                objRdsH.Name = "ASSET_DataSource_clsRptBarang"
                objRdsH.Value = objDatalistHeader
                'If Me._BM = True Then
                objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasa_Editing.rdlc"
            Else
                objRdsH.Name = "ASSET_DataSource_clsRptBarang"
                objRdsH.Value = objDatalistHeader
                'If Me._BM = True Then
                objReportH.ReportEmbeddedResource = "ASSET.RptTerimaJasa.rdlc"
            End If
            objReportH.DataSources.Add(objRdsH)
            objReportH.EnableExternalImages = True
            objReportH.SetParameters(New Microsoft.Reporting.WinForms.ReportParameter() {parRptImageURL, parRptChannelID, parRptChannel_namereport, parRptChannel_address, parRptTerimaBarang_ID})
            'Else
            'MsgBox("You can't print")
            'Exit Function
            'End If

            AddHandler objReportH.SubreportProcessing, AddressOf SubreportProcessing
            Export(objReportH)

            m_currentPageIndex = 0
            Print()
            'TrnKeberadaanBarang_Print(objDatalistHeader, objRdsH, parRptImageURL)
            updateprintpbb()
        Else
            MsgBox("SPV / Sect. Head approval is required to print this document")
            Exit Function
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
    Private Function uiTrnTerimaJasa_PrintPreview() As Boolean
        If Me.DgvTrnTerimajasa.SelectedRows.Count <= 0 Then
            MsgBox("Belum ada data yang dipilih")
            Exit Function
        End If

        If Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_appprc").Value = 1 Then

            Dim terimabarang_id As String
            terimabarang_id = DgvTrnTerimajasa.CurrentRow.Cells("terimabarang_id").Value

            Dim frmPrintTerima As dlgRptTerimaJasa = New dlgRptTerimaJasa(Me.DSN, Me.SptServer, Me.obj_Channel_id_search.SelectedValue, Me.obj_top.Value, terimabarang_id)
            Dim criteria As String = String.Empty

            frmPrintTerima.ShowInTaskbar = False
            frmPrintTerima.StartPosition = FormStartPosition.CenterParent

            criteria = " AND terimabarang_id = '" & terimabarang_id & "'"

            'If Me._BM = True Then
            frmPrintTerima.SetIDCriteria(criteria)
            frmPrintTerima.ShowDialog(Me)
            'ElseIf Me._US = True Then
            '    frmPrintAda.SetIDCriteria(criteria)
            '    frmPrintAda.ShowDialog(Me)
            'Else
            'MsgBox("you can't print preview")
            'End If
        Else
            MsgBox("SPV / Sect. Head approval is required to print this document")
            Exit Function
        End If

        'Dim terimabarang_id As String
        'terimabarang_id = DgvTrnTerimajasa.CurrentRow.Cells("terimabarang_id").Value

        'Dim frmPrintTerima As dlgRptTerimaJasa = New dlgRptTerimaJasa(Me.DSN, Me.SptServer, Me.obj_Channel_id_search.SelectedValue, Me.obj_top.Value, terimabarang_id)
        'Dim criteria As String = String.Empty

        'frmPrintTerima.ShowInTaskbar = False
        'frmPrintTerima.StartPosition = FormStartPosition.CenterParent

        'criteria = " AND terimabarang_id = '" & terimabarang_id & "'"

        ''If Me._BM = True Then
        'frmPrintTerima.SetIDCriteria(criteria)
        'frmPrintTerima.ShowDialog(Me)
        ''ElseIf Me._US = True Then
        ''    frmPrintAda.SetIDCriteria(criteria)
        ''    frmPrintAda.ShowDialog(Me)
        ''Else
        ''MsgBox("you can't print preview")
        ''End If


    End Function
    Private Sub updateprintpbb()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("as_print_terimabarang", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            If Me._PC = True Then
                oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 2).Value = "AC"
            ElseIf Me._US = True Then
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
    'Private Function TimeDiff(ByVal Time1 As String, ByVal Time2 As String) As String
    '    Dim MinsDiff As String
    '    Dim TheHours As String

    '    MinsDiff = DateDiff("n", Time1, Time2)

    '    'If midnight is between times

    '    MinsDiff = IIf(MinsDiff < 0, MinsDiff + 1440, MinsDiff)
    '    TheHours = Format(Int(MinsDiff / 60), "00")
    '    MinsDiff = Format(MinsDiff Mod 60, "00")
    '    TimeDiff = TheHours & ":" & MinsDiff
    'End Function
    'Private Function TimeTotalEdit(ByVal Time1 As String, ByVal Time2 As String, ByVal Time3 As String) As String

    '    Dim thehours, theminute, totalminute As String
    '    Dim h1, h2, h3, s1, s2, s3 As Integer

    '    'change all value into minute

    '    h1 = Mid(Time1, 1, 2) * 60
    '    h2 = Mid(Time2, 1, 2) * 60
    '    h3 = Mid(Time3, 1, 2) * 60
    '    s1 = Mid(Time1, 4, 5)
    '    s2 = Mid(Time2, 4, 5)
    '    s3 = Mid(Time3, 4, 5)

    '    totalminute = (h1 + h2 + h3) + (s1 + s2 + s3)
    '    thehours = Format(Int(totalminute / 60), "00")
    '    theminute = Format(totalminute Mod 60, "00")
    '    TimeTotalEdit = thehours & ":" & theminute


    'End Function
#End Region

    Private Sub cmdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim param As Integer = 1
        Dim dlg As New dlgListBarangNonFix(Me.DSN, _CHANNEL, param, Me._STRUKTUR_UNIT, Me.obj_Asset_barcodeinduk.Text)

        listBarcode = dlg.OpenDialog(Me)
        If listBarcode IsNot Nothing Then
            Me.obj_Asset_barcode.Text = listBarcode
        End If
    End Sub
    Private Sub cmdMother_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim param As Integer = 2
        Dim dlg As New dlgListBarangNonFix(Me.DSN, _CHANNEL, param, Me._STRUKTUR_UNIT, Me.obj_Asset_barcodeinduk.Text)
        listBarcode = dlg.OpenDialog(Me)
        If listBarcode IsNot Nothing Then
            Me.obj_Asset_barcodeinduk.Text = listBarcode
            Me.obj_Asset_tipedepre.Text = "A"
            Me.obj_Asset_lineinduk.Text = 0
            Me.obj_Asset_lineinduk.ReadOnly = True
        Else
            Me.obj_Asset_lineinduk.ReadOnly = True
            Me.obj_Asset_barcodeinduk.Text = ""
        End If
    End Sub
    Private Sub obj_shadow_tipedepre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub obj_Is_useable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.obj_Is_useable.Checked = True Then
            'Me.obj_Asset_qty.ReadOnly = False
            Me.cmdList.Visible = True
            Me.cmdMother.Visible = False
            Me.obj_Asset_barcodeinduk.Text = ""
            Me.obj_Asset_tipedepre.Text = "N"
            Me.obj_Asset_lineinduk.ReadOnly = True
        Else
            'Me.obj_Asset_qty.ReadOnly = True
            Me.cmdList.Visible = False
            Me.cmdMother.Visible = True
            Me.obj_Asset_barcode.Text = ""
            'Me.obj_Asset_qty.Text = 1
        End If
    End Sub

#Region " Load data Combobox Detil "
    Private Sub Btn_Brand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Brand.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Brand_id, "merk_id", "merk_name", Me.tbl_brand, "as_MstMerk_Select", " merk_active = 1 ")
        Me.tbl_brand.DefaultView.Sort = "merk_name"
        Me.obj_Brand_id.DataBindings.Clear()
        Me.obj_Brand_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "brand_id"))

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
    Private Sub Btn_Material_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Material_id, "Material_id", "Material_id", Me.tbl_Mstmaterial, "as_MstMaterial_Select", " ")
        Me.tbl_Mstmaterial.DefaultView.Sort = "Material_id"
        Me.obj_Material_id.DataBindings.Clear()
        Me.obj_Material_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "Material_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_Room_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Ruang_id, "ruang_id", "keterangan", Me.tbl_MstAssetruang, "as_MstRuangAsset_Select", "  ", _CHANNEL)
        Me.tbl_MstAssetruang.DefaultView.Sort = "keterangan"
        Me.obj_Ruang_id.DataBindings.Clear()
        Me.obj_Ruang_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "ruang_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_Show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Show_id, "show_id", "show_title", Me.tbl_show, "as_MstShow_Select ", " ", _CHANNEL)
        tbl_show.DefaultView.Sort = "show_title"
        Me.obj_Show_id.DataBindings.Clear()
        Me.obj_Show_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "show_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_Color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Warna_id, "warna_id", "warna_id", Me.tbl_Mstwarna, "as_MstWarna_Select", " ")
        Me.tbl_Mstwarna.DefaultView.Sort = "warna_id"
        Me.obj_Warna_id.DataBindings.Clear()
        Me.obj_Warna_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "warna_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_Size_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Ukuran_id, "ukuran_id", "ukuran_id", Me.tbl_ukuran, "AS_MstUkuran_Select", "  ")
        Me.tbl_ukuran.DefaultView.Sort = "ukuran_id"
        Me.obj_Ukuran_id.DataBindings.Clear()
        Me.obj_Ukuran_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "ukuran_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub Btn_BudgetNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Project_id, "budget_id", "budget_nameshort", Me.tbl_project, "ms_MstBudgetCombo_Select ", " ", _CHANNEL)
        tbl_project.DefaultView.Sort = "budget_name"
        Me.obj_Project_id.DataBindings.Clear()
        Me.obj_Project_id.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "project_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default

        Me.Obj_asset_No_budget.Text = 0
    End Sub
    Private Sub Btn_ContShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Me.ComboFill(Me.obj_Show_id_cont_item, "show_id", "show_title", Me.tbl_showcont, "as_MstShow_Select ", " ", _CHANNEL)
        tbl_showcont.DefaultView.Sort = "show_title"
        Me.obj_Show_id_cont_item.DataBindings.Clear()
        Me.obj_Show_id_cont_item.DataBindings.Add(New Binding("SelectedValue", Me.tbl_TrnTerimabarangdetil, "show_id"))
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
#End Region


    Private Sub obj_Project_id_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Obj_asset_No_budget.Text = clsUtil.IsDbNull(Me.obj_Project_id.SelectedValue, 0)
    End Sub
    Private Sub Obj_asset_No_budget_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
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
    Private Sub obj_Currency_id_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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
    Private Sub obj_Terimajasa_status_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Terimajasa_status.SelectedValueChanged
        Me.select_nomor_RO_MO()
    End Sub

    Private Sub select_nomor_RO_MO()
        Dim criteria As String = String.Empty
        Dim tbl_RO As DataTable = New DataTable

        If Me.obj_Terimajasa_status.SelectedItem = "RO" Then
            'Me.obj_Order_id.Enabled = True
            Me.btn_order.Enabled = True
            Me.obj_Rekanan_id.Enabled = False
            If Me.obj_Terimajasa_id.Text <> "AUTO" Then
                Me.Btn_Add.Enabled = True
                Me.btn_bonus.Enabled = True
                Me.btn_DeleteItem.Enabled = True
            Else
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
            End If
            Me.obj_Terimajasa_type.Text = "RENTAL"
            Me.tbl_MstTrnOrder.DefaultView.RowFilter = "ordertype_id = 'RO'"
        ElseIf Me.obj_Terimajasa_status.SelectedItem = "MO" Then
            'Me.obj_Order_id.Enabled = True
            Me.btn_order.Enabled = True
            Me.obj_Rekanan_id.Enabled = False
            If Me.obj_Terimajasa_id.Text <> "AUTO" Then
                Me.Btn_Add.Enabled = True
                Me.btn_bonus.Enabled = True
                Me.btn_DeleteItem.Enabled = True
            Else
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
            End If
            Me.obj_Terimajasa_type.Text = "MAINTENANCE"
            Me.tbl_MstTrnOrder.DefaultView.RowFilter = "ordertype_id = 'MO'"
        ElseIf Me.obj_Terimajasa_status.SelectedItem = "TO" Then
            'Me.obj_Order_id.Enabled = True
            Me.btn_order.Enabled = True
            Me.obj_Rekanan_id.Enabled = False
            If Me.obj_Terimajasa_id.Text <> "AUTO" Then
                Me.Btn_Add.Enabled = True
                Me.btn_bonus.Enabled = True
                Me.btn_DeleteItem.Enabled = True
            Else
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
            End If
            Me.obj_Terimajasa_type.Text = "TALENT"
            Me.tbl_MstTrnOrder.DefaultView.RowFilter = "ordertype_id = 'TO'"
        ElseIf Me.obj_Terimajasa_status.SelectedItem = "EO" Then
            'Me.obj_Order_id.Enabled = True
            Me.btn_order.Enabled = True
            Me.obj_Rekanan_id.Enabled = False
            If Me.obj_Terimajasa_id.Text <> "AUTO" Then
                Me.Btn_Add.Enabled = True
                Me.btn_bonus.Enabled = True
                Me.btn_DeleteItem.Enabled = True
            Else
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
            End If
            Me.obj_Terimajasa_type.Text = "EDITING"
            Me.tbl_MstTrnOrder.DefaultView.RowFilter = "ordertype_id = 'EO'"
        Else
            Me.obj_Order_id.Text = ""
            'Me.obj_Order_id.Enabled = False
            Me.btn_order.Enabled = False
            Me.obj_Rekanan_id.Enabled = True
            Me.obj_Rekanan_id.SelectedValue = 0

            If Me.obj_Terimajasa_id.Text <> "AUTO" Then
                Me.Btn_Add.Enabled = True
                Me.btn_bonus.Enabled = True
                Me.btn_DeleteItem.Enabled = True
            Else
                Me.Btn_Add.Enabled = False
                Me.btn_bonus.Enabled = False
                Me.btn_DeleteItem.Enabled = False
            End If
            Me.obj_Terimajasa_type.Text = ""
        End If
    End Sub

    ' ''Private Sub obj_Currency_id_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    ' ''    Dim harga As Decimal = Me.obj_Asset_harga.Text
    ' ''    Dim valas As Decimal = Me.obj_Asset_valas.Text

    ' ''    Me.obj_Asset_idrprice.Text = Format(harga * valas, "#,##0.00")
    ' ''End Sub
    Private Sub DgvTrnTerimajasa_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DgvTrnTerimajasa.CellFormatting
        Dim dgv As DataGridView = sender
        Dim objrow As System.Windows.Forms.DataGridViewRow = dgv.Rows(e.RowIndex)
        Try
            If objrow.Cells("terimabarang_appuser").Value = 1 And objrow.Cells("terimabarang_appprc").Value = 1 And objrow.Cells("terimabarang_appbma").Value = 1 Then
                objrow.DefaultCellStyle.BackColor = Color.Bisque
            ElseIf objrow.Cells("terimabarang_appuser").Value = 1 And objrow.Cells("terimabarang_appprc").Value = 1 Then
                objrow.DefaultCellStyle.BackColor = Color.Aquamarine
            ElseIf objrow.Cells("terimabarang_appuser").Value = 1 Then
                objrow.DefaultCellStyle.BackColor = Color.Thistle
            Else
                objrow.DefaultCellStyle.BackColor = Color.White
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

    Private Sub DgvTrnTerimajasadetil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgvTrnTerimajasadetil.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim click As DataGridView.HitTestInfo = Me.DgvTrnTerimajasadetil.HitTest(e.X, e.Y)
            If click.Type = Windows.Forms.DataGrid.HitTestType.Cell Then
                Me.DgvTrnTerimajasadetil.CurrentCell = Me.DgvTrnTerimajasadetil.Rows(click.RowIndex).Cells(click.ColumnIndex)
            End If
        End If
    End Sub

    Private Sub CopyItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyItemToolStripMenuItem.Click
        If Me.obj_Employee_id_pemilik.Enabled = True Then
            Me.copy_induk_child(0)
            Me.tampil_status_RO_MO_MANUAL()
        Else
            MsgBox("Data has been lock")
        End If
    End Sub

    Private Sub CopyWihChildToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.obj_Employee_id_pemilik.Enabled = True Then
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
        criterias = String.Format(" AND terimabarang_id = '{0}' AND asset_line = {1}", Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimabarang_id").Value, _
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_line").Value)
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
            criteria = String.Format("asset_line = {0}", Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_line").Value)
            row_Array = tbl_temporaryInduk.Select(criteria)

            motherTbl.Clear()
            For rowIndex = 0 To row_Array.Length - 1
                row_temps = motherTbl.NewRow
                For colIndex = 0 To tbl_temporaryInduk.Columns.Count - 1
                    Try
                        columnName = tbl_temporaryInduk.Columns(colIndex).ColumnName
                        If columnName = "asset_line" Then
                            row_temps(columnName) = Me.DgvTrnTerimajasadetil.Rows.Count + 1
                        ElseIf columnName = "asset_serial" Or columnName = "asset_produknumber" Or columnName = "asset_model" Or columnName = "asset_barcode" Or columnName = "order_id" Then
                            row_temps(columnName) = ""
                        ElseIf columnName = "orderdetil_line" Or columnName = "asset_lineinduk" Then
                            row_temps(columnName) = 0
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
                criteria = String.Format(" asset_lineinduk = {0}", Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_line").Value)
                row_Array = tbl_temporaryChild.Select(criteria)

                'childTbl.Clear()
                For rowIndex = 0 To row_Array.Length - 1
                    childTbl.Clear()
                    row_temps = childTbl.NewRow
                    For colIndex = 0 To tbl_temporaryChild.Columns.Count - 1
                        Try
                            columnName = tbl_temporaryChild.Columns(colIndex).ColumnName
                            If columnName = "asset_line" Then
                                row_temps(columnName) = Me.DgvTrnTerimajasadetil.Rows.Count + 1
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

    'Private Sub obj_Order_id_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim poNumber As String
    '    Dim tbl_order As New DataTable
    '    Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

    '    'Try
    '    If Me._LOADCOMBO = True Then
    '        If obj_Order_id.Enabled = True Then
    '            poNumber = Me.obj_Order_id.Text
    '            tbl_order.Clear()
    '            DataFill(tbl_order, "as_TrnOrder_Select", String.Format("order_id = '{0}'", poNumber))
    '            If tbl_order.Rows.Count <= 0 Then
    '                MsgBox("Sorry")
    '                Me.obj_Asset_valas.Text = 0
    '            Else
    '                Me.obj_Rekanan_id.SelectedValue = tbl_order.Rows(0)("rekanan_id")
    '            End If
    '        End If
    '    End If
    '    'Catch ex As Exception

    '    'End Try
    'End Sub

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

        If Me.DgvTrnTerimajasadetil.Rows.Count = 1 Then
            criteria = "(" & Me.DgvTrnTerimajasadetil.Rows(i).Cells("orderdetil_line").Value & ")"
            'criteria = "(" & Me.DgvTrnTerimabarangdetil.Rows(i).Cells("orderdetil_line").Value & ")"
        Else
            For i = 0 To Me.DgvTrnTerimajasadetil.Rows.Count - 1
                If criteria = String.Empty Then
                    criteria = clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(i).Cells("orderdetil_line").Value, String.Empty)
                    'criteria = clsUtil.IsDbNull(Me.DgvTrnTerimabarangdetil.Rows(i).Cells("orderdetil_line").Value, String.Empty)
                Else
                    If Me.DgvTrnTerimajasadetil.Rows(i).Cells("orderdetil_line").Value IsNot DBNull.Value Then
                        If Me.DgvTrnTerimajasadetil.Rows(i).Cells("orderdetil_line").Value IsNot Nothing Then
                            criteria &= ", " & Me.DgvTrnTerimajasadetil.Rows(i).Cells("orderdetil_line").Value
                            'criteria &= ", " & Me.DgvTrnTerimabarangdetil.Rows(i).Cells("orderdetil_line").Value
                        End If
                    End If
                End If
            Next
            If criteria <> String.Empty Then
                criteria = "(" & criteria & ")"
            End If
        End If

        Dim dlg As New dlgListPO(Me.DSN, Me.obj_Order_id.Text, criteria, Me.obj_Terimajasa_status.SelectedItem)
        Dim dlg2 As New dlgAddItem_TrmBarang()

        If Me.obj_Terimajasa_status.SelectedItem = "RO" Or Me.obj_Terimajasa_status.SelectedItem = "MO" Or Me.obj_Terimajasa_status.SelectedItem = "TO" Or Me.obj_Terimajasa_status.SelectedItem = "EO" Then
            Me.tbl_retOrderDetilJasa = dlg.OpenDialog(Me)
            If Me.tbl_retOrderDetilJasa IsNot Nothing Then
                Dim count_orderdetil As Integer
                Dim row_index As Integer
                count_orderdetil = Me.tbl_retOrderDetilJasa.Rows.Count - 1

                For row_index = 0 To count_orderdetil
                    Me.obj_orderdetil_line.Text = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_line")
                    Me.obj_Order_idDetil.Text = Me.obj_Order_id.Text

                    rowCount = Me.tbl_TrnTerimabarangdetil.Rows.Count
                    row = Me.tbl_TrnTerimabarangdetil.NewRow
                    Me.tbl_TrnTerimabarangdetil.Rows.Add(row)

                    While Me.tbl_TrnTerimabarangdetil.Rows(rowCount).RowState = DataRowState.Deleted
                        rowCount += 1
                    End While

                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("order_id") = Me.obj_Order_id.Text
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("orderdetil_line") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_line")

                    If Me.obj_Terimajasa_status.SelectedItem = "RO" Then
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_deskripsi") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("item_id_string")
                    ElseIf Me.obj_Terimajasa_status.SelectedItem = "MO" Then
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_deskripsi") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("item_id_string") & "(" & Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_descr") & ")"
                    ElseIf Me.obj_Terimajasa_status.SelectedItem = "EO" Then
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_deskripsi") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_descr")
                    Else
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_deskripsi") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("item_id_string")
                    End If
                    'Me.obj_Qty_PO.Text = Val(Me.obj_Qty_PO.Text) + clsUtil.IsDbNull(CInt(Me.tbl_retOrderDetil.Rows(0).Item("orderdetil_qty")), 0)
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("unit_id") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("unit_id")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("currency_id") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("currency_id")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_discount")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_valas") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")
                    If Me.obj_Terimajasa_status.SelectedItem = "MO" Then
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_ppn") = Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_ppnpercent")) / 100
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_pph") = Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_pphpercent")) / 100
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_idrprice") = Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) + Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_pph"))
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_harga") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")
                    ElseIf Me.obj_Terimajasa_status.SelectedItem = "TO" Then
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_ppn") = 0 'Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("days_valid"), 1)) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_ppnpercent")) / 100
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_pph") = 0 'Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_pphpercent")) 'Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("days_valid"), 1)) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_pphpercent")) / 100
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_idrprice") = 0 'Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_actual")) + Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_pphpercent")) 'Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("days_valid"), 1)) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) + Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_pph"))
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_harga") = Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) 'Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")
                    ElseIf Me.obj_Terimajasa_status.SelectedItem = "RO" Then
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_ppn") = 0 'Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("days_valid"), 1)) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_ppnpercent")) / 100
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_pph") = 0 'Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("days_valid"), 1)) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_pphpercent")) / 100
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_idrprice") = 0 'Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("days_valid"), 1)) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) + Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_pph"))
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_harga") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")
                    Else
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_ppn") = 0 'Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("days_valid"), 1)) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_ppnpercent")) / 100
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_pph") = 0 'Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("days_valid"), 1)) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_pphpercent")) / 100
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_idrprice") = 0 'Val((Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreignrate")) * Val(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.tbl_retOrderDetilJasa.Rows(row_index).Item("days_valid"), 1)) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_disc"))) + Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_pph"))
                        Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_harga") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_foreign") / 8
                    End If
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("project_id") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("budget_id")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_lineinduk") = 0 'Me.tbl_retOrderDetilJasa.Rows(row_index).Item("days_valid")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("asset_qty") = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")
                    Me.tbl_TrnTerimabarangdetil.Rows(rowCount).Item("strukturunit_id") = Me.obj_Strukturunit_id_pemilik.SelectedValue

                    If Me.obj_Terimajasa_status.SelectedItem = "RO" Then
                        Dim temp_table As DataTable = New DataTable
                        Dim criteria_order As String = String.Format("order_id = '{0}'", Me.obj_Order_id.Text)
                        Dim m As Integer

                        Try
                            dbConn.Open()
                            Dim oCm As New OleDb.OleDbCommand("as_terimabarangdetilfromRO1", dbConn)
                            oCm.CommandType = CommandType.StoredProcedure
                            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me._CHANNEL
                            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me.obj_Terimajasa_id.Text
                            oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_line")
                            oCm.Parameters.Add("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4).Value = m
                            oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("order_id")
                            oCm.Parameters.Add("@orderdetil_qty", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")
                            oCm.Parameters.Add("@order_utilizedtimestart", System.Data.OleDb.OleDbType.VarWChar, 10).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("order_utilizedtimestart")
                            oCm.Parameters.Add("@order_utilizedtimeend", System.Data.OleDb.OleDbType.VarWChar, 10).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("order_utilizedtimeend")


                            oCm.ExecuteNonQuery()
                            oCm.Dispose()
                        Catch ex As Data.OleDb.OleDbException
                            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Catch ex As Exception
                            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            dbConn.Close()
                        End Try
                        'Next
                    ElseIf Me.obj_Terimajasa_status.SelectedItem = "TO" Then
                        Dim temp_table As DataTable = New DataTable
                        Dim criteria_order As String = String.Format("order_id = '{0}'", Me.obj_Order_id.Text)
                        'Dim jmlh_tgl As Integer
                        Dim m As Integer

                        Try
                            dbConn.Open()
                            Dim oCm As New OleDb.OleDbCommand("as_terimabarangdetilfromTO", dbConn)
                            oCm.CommandType = CommandType.StoredProcedure
                            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.obj_Terimajasa_id.Text
                            oCm.Parameters.Add("@terimabarang_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_line")
                            oCm.Parameters.Add("@terimabarang_eps", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_line")
                            oCm.Parameters.Add("@terimabarang_descr", System.Data.OleDb.OleDbType.VarWChar, 510).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("item_id_string")
                            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me._CHANNEL
                            oCm.Parameters.Add("@terimabarang_qty", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_qty")
                            oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("order_id")
                            oCm.Parameters.Add("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4).Value = m
                            oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_line")

                            oCm.ExecuteNonQuery()
                            oCm.Dispose()
                        Catch ex As Data.OleDb.OleDbException
                            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Catch ex As Exception
                            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            dbConn.Close()
                        End Try
                        'Next
                    ElseIf Me.obj_Terimajasa_status.SelectedItem = "EO" Then
                        Dim temp_table As DataTable = New DataTable
                        Dim criteria_order As String = String.Format("order_id = '{0}'", Me.obj_Order_id.Text)
                        'Dim jmlh_tgl As Integer
                        Dim m As Integer

                        Try
                            dbConn.Open()
                            Dim oCm As New OleDb.OleDbCommand("as_terimabarangdetilfromEO", dbConn)
                            oCm.CommandType = CommandType.StoredProcedure
                            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.obj_Terimajasa_id.Text
                            oCm.Parameters.Add("@terimabarang_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_line")
                            oCm.Parameters.Add("@terimabarang_eps", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_line")
                            oCm.Parameters.Add("@@terimabarang_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("editing_date")
                            oCm.Parameters.Add("@terimabarang_descr", System.Data.OleDb.OleDbType.VarWChar, 510).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_descr")
                            oCm.Parameters.Add("@shift1", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("shift1")
                            oCm.Parameters.Add("@shift2", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("shift2")
                            oCm.Parameters.Add("@shift3", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("shift3")
                            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me._CHANNEL
                            oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("order_id")
                            oCm.Parameters.Add("@orderdetiluse_line", System.Data.OleDb.OleDbType.Integer, 4).Value = m
                            oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.tbl_retOrderDetilJasa.Rows(row_index).Item("orderdetil_line")

                            oCm.ExecuteNonQuery()
                            oCm.Dispose()
                        Catch ex As Data.OleDb.OleDbException
                            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Catch ex As Exception
                            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            dbConn.Close()
                        End Try
                    End If
                    If Me.DgvTrnTerimajasadetil.Rows.Count <> 0 Then
                        Me.obj_Terimajasa_status.Enabled = False
                        'Me.obj_Order_id.Enabled = False
                        Me.btn_order.Enabled = False
                    End If

                    If Me.DgvTrnTerimajasadetil.Rows.Count = 1 Then
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
                Me.uiTrnTerimaJasa_Save()
            End If
        Else
            desc = dlg2.OpenDialog(Me)
            If desc IsNot Nothing Then
                rowDetil = Me.tbl_TrnTerimabarangdetil.NewRow
                rowDetil("asset_deskripsi") = desc
                Me.tbl_TrnTerimabarangdetil.Rows.Add(rowDetil)

                If Me.DgvTrnTerimajasadetil.RowCount > 0 Then
                    Me.obj_Terimajasa_status.Enabled = False
                    'Me.obj_Order_id.Enabled = False
                    Me.btn_order.Enabled = False
                    'Me.obj_Status.Enabled = False
                    Me.obj_Rekanan_id.Enabled = False
                End If
            End If
        End If
        Me.tampil_status_RO_MO_MANUAL()
    End Sub

    Private Sub lockUser(ByVal status As String)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Try
            dbConn.Open()
            ' ''Dim oCm As New OleDb.OleDbCommand("as_LockUsertransaksi_terimabarang", dbConn)
            Dim oCm As New OleDb.OleDbCommand("as_TrnTerimabarang_UserApproved", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = Me.DgvTrnTerimajasa.Item("terimabarang_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            oCm.Parameters.Add("@user_applogin", System.Data.OleDb.OleDbType.VarWChar, 32).Value = Me.UserName
            oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20).Value = Me.DgvTrnTerimajasa.Item("channel_id", DgvTrnTerimajasa.CurrentRow.Index).Value
            oCm.Parameters.Add("@status", System.Data.OleDb.OleDbType.VarWChar, 20).Value = status
            oCm.ExecuteNonQuery()
            oCm.Dispose()

            If status = "approved" Then
                Me.obj_Terimajasa_appuser.Checked = True
                Me.DgvTrnTerimajasa.Item("terimabarang_appuser", DgvTrnTerimajasa.CurrentRow.Index).Value = 1
                MessageBox.Show("Data Has Been Approved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.obj_Terimajasa_appuser.Checked = False
                Me.DgvTrnTerimajasa.Item("terimabarang_appuser", DgvTrnTerimajasa.CurrentRow.Index).Value = 0
                MessageBox.Show("Data Has Been UnApproved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
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

            If Me.DgvTrnTerimajasadetil.RowCount > 0 Then
                Me.obj_Terimajasa_status.Enabled = False
                'Me.obj_Order_id.Enabled = False
                Me.btn_order.Enabled = False
                'Me.obj_Status.Enabled = False
                Me.obj_Rekanan_id.Enabled = False
            End If
            Me.tampil_status_RO_MO_MANUAL()
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

    Private Sub obj_Asset_lineinduk_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Asset_lineinduk.Validated
        Dim poNumber As String
        Dim tbl_orderdetil_temporary As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        'Try
        poNumber = Me.obj_Order_id.Text
        tbl_orderdetil_temporary.Clear()
        DataFill(tbl_orderdetil_temporary, "as_TrnOrderdetil_Select", String.Format("order_id = '{0}' AND orderdetil_line = {1}", Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("order_id"), Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("orderdetil_line")))

        If tbl_orderdetil_temporary.Rows.Count > 0 Then
            If Me.obj_Asset_lineinduk.Text > tbl_orderdetil_temporary.Rows(0).Item("orderdetil_days") Then
                MsgBox("Your days is over from days in PO")
                Me.obj_Asset_lineinduk.Text = 1
            End If
            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_harga") = Val(tbl_orderdetil_temporary.Rows(0).Item("orderdetil_foreign") / Val(tbl_orderdetil_temporary.Rows(0).Item("orderdetil_days"))) * Val(Me.obj_Asset_lineinduk.Text)
            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") = Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_harga")) * Val(tbl_orderdetil_temporary.Rows(0).Item("orderdetil_foreignrate") * Val(tbl_orderdetil_temporary.Rows(0).Item("orderdetil_ppnpercent")) / 100)
            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") = Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_harga")) * Val(tbl_orderdetil_temporary.Rows(0).Item("orderdetil_foreignrate") * Val(tbl_orderdetil_temporary.Rows(0).Item("orderdetil_pphpercent")) / 100)
            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_idrprice") = Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_harga")) * Val(tbl_orderdetil_temporary.Rows(0).Item("orderdetil_foreignrate")) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc"))
        End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub obj_Asset_qty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Asset_qty.Validated
        Dim tbl_trnOrderdetil_temps As DataTable = New DataTable
        Dim tbl_retOrder As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim criteria As String = String.Empty

        criteria = String.Format(" tor.order_id = '{0}' AND tb.orderdetil_line = {1}", Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("order_id").Value, Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value)

        tbl_retOrder.Clear()
        tbl_trnOrderdetil_temps.Clear()
        tbl_trnOrderdetil_temps.Clear()
        If Me.obj_Terimajasa_status.Text = "MO" Then
            DataFill(tbl_trnOrderdetil_temps, "as_TrnOrderdetil_Select", String.Format("order_id = '{0}' AND orderdetil_line = {1} ", Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("order_id"), Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("orderdetil_line")))
            If tbl_trnOrderdetil_temps.Rows.Count > 0 Then
                If Me.obj_Asset_qty.Text > tbl_trnOrderdetil_temps.Rows(0).Item("orderdetil_qty") Then
                    MsgBox("Your quantity is over from quantity in MO")
                    Try
                        Me.DataFill(tbl_retOrder, "as_TrnOrderdetilJasa_Select", criteria)
                        Me.obj_Asset_qty.Text = tbl_retOrder.Rows(0).Item("orderdetil_qty")
                        Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_qty").Value = tbl_retOrder.Rows(0).Item("orderdetil_qty")
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    Try
                        Me.DataFill(tbl_retOrder, "as_TrnOrderdetilJasa_Select", criteria)
                        Me.obj_Asset_pph.Text = ((Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * CDec(clsUtil.IsDbNull(Me.obj_Asset_qty.Text, 0))) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                        Me.obj_Asset_ppn.Text = ((Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * CDec(clsUtil.IsDbNull(Me.obj_Asset_qty.Text, 0))) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                        Me.obj_Asset_idrprice.Text = Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * CDec(clsUtil.IsDbNull(Me.obj_Asset_qty.Text, 0)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub ftabDataDetil_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ftabDataDetil.SelectedIndexChanged
        If Me._US = True Or Me._PC = True Then
            Select Case ftabDataDetil.SelectedIndex
                Case 0
                    Me.ftabDataDetil.TabPages.Item(0).BackColor = Color.White
                    Me.ftabDataDetil.TabPages.Item(1).BackColor = Color.Lavender
                Case 1
                    Me.ftabDataDetil.TabPages.Item(0).BackColor = Color.Lavender
                    Me.ftabDataDetil.TabPages.Item(1).BackColor = Color.White
            End Select
        End If

        If Me._BM = True Then
            Select Case ftabDataDetil.SelectedIndex
                Case 0
                    Me.ftabDataDetil.TabPages.Item(0).BackColor = Color.White
                    Me.ftabDataDetil.TabPages.Item(1).BackColor = Color.Lavender
                    Me.ftabDataDetil.TabPages.Item(2).BackColor = Color.Lavender
                Case 1
                    Me.ftabDataDetil.TabPages.Item(0).BackColor = Color.Lavender
                    Me.ftabDataDetil.TabPages.Item(1).BackColor = Color.White
                    Me.ftabDataDetil.TabPages.Item(2).BackColor = Color.Lavender
                Case 2
                    Me.ftabDataDetil.TabPages.Item(0).BackColor = Color.Lavender
                    Me.ftabDataDetil.TabPages.Item(1).BackColor = Color.Lavender
                    Me.ftabDataDetil.TabPages.Item(2).BackColor = Color.White

            End Select
        End If
    End Sub

    Private Sub tampil_status_RO_MO_MANUAL()
        Dim i As Integer
        Dim countDgv As Integer

        countDgv = Me.DgvTrnTerimajasadetil.Rows.Count - 1

        For i = 0 To countDgv
            'If Me.tbl_TrnTerimabarangdetil.Rows(i).RowState = DataRowState.Deleted Then
            '    i += 1
            'End If
            If Mid(Me.DgvTrnTerimajasadetil.Rows(i).Cells("order_id").Value, 1, 2) = "RO" Then
                Me.DgvTrnTerimajasadetil.Rows(i).Cells("status_ro").Value = "RO"
            ElseIf Mid(Me.DgvTrnTerimajasadetil.Rows(i).Cells("order_id").Value, 1, 2) = "MO" Then
                Me.DgvTrnTerimajasadetil.Rows(i).Cells("status_ro").Value = "MO"
            ElseIf Mid(Me.DgvTrnTerimajasadetil.Rows(i).Cells("order_id").Value, 1, 2) = "TO" Then
                Me.DgvTrnTerimajasadetil.Rows(i).Cells("status_ro").Value = "TO"
            ElseIf Mid(Me.DgvTrnTerimajasadetil.Rows(i).Cells("order_id").Value, 1, 2) = "EO" Then
                Me.DgvTrnTerimajasadetil.Rows(i).Cells("status_ro").Value = "EO"
            Else
                Me.DgvTrnTerimajasadetil.Rows(i).Cells("status_ro").Value = "MANUAL"
            End If
        Next
    End Sub

    Private Sub btn_DeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DeleteItem.Click
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        If Me.DgvTrnTerimajasadetil.Rows(DgvTrnTerimajasadetil.CurrentRow.Index).Cells("status_ro").Value = "TO" Then
            Try
                dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("as_TrnTerimabarangdetil_deleteItem", dbConn)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimabarang_id").Value
                oCm.Parameters.Add("@asset_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_line").Value
                oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me._CHANNEL
                oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("order_id").Value
                oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value
                oCm.Parameters.Add("@is_bpj", System.Data.OleDb.OleDbType.VarWChar, 20).Value = "TALENT"
                oCm.ExecuteNonQuery()
                oCm.Dispose()
                Me.uiTrnTerimaJasa_OpenRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dbConn.Close()
            End Try
        ElseIf Me.DgvTrnTerimajasadetil.Rows(DgvTrnTerimajasadetil.CurrentRow.Index).Cells("status_ro").Value = "EO" Then
            Try
                dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("as_TrnTerimabarangdetil_deleteItem", dbConn)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimabarang_id").Value
                oCm.Parameters.Add("@asset_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_line").Value
                oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me._CHANNEL
                oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("order_id").Value
                oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value
                oCm.Parameters.Add("@is_bpj", System.Data.OleDb.OleDbType.VarWChar, 20).Value = "EDITING"
                oCm.ExecuteNonQuery()
                oCm.Dispose()
                Me.uiTrnTerimaJasa_OpenRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dbConn.Close()
            End Try
        Else
            Try
                dbConn.Open()
                Dim oCm As New OleDb.OleDbCommand("as_TrnTerimabarangdetil_deleteItem", dbConn)
                oCm.CommandType = CommandType.StoredProcedure
                oCm.Parameters.Add("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("terimabarang_id").Value
                oCm.Parameters.Add("@asset_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_line").Value
                oCm.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 40).Value = Me._CHANNEL
                oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 60).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("order_id").Value
                oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value
                oCm.Parameters.Add("@is_bpj", System.Data.OleDb.OleDbType.VarWChar, 20).Value = "JASA"
                oCm.ExecuteNonQuery()
                oCm.Dispose()
                Me.uiTrnTerimaJasa_OpenRow(Me.DgvTrnTerimajasa.CurrentRow.Index)
            Catch ex As Data.OleDb.OleDbException
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dbConn.Close()
            End Try
        End If

    End Sub


   
    Private Sub btn_order_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_order.Click
        Dim tabels As DataTable = New DataTable
        Dim criteria As String = String.Empty
        Dim names As String = "BPJ Status"


        If obj_Terimajasa_status.SelectedItem = "RO" Then
            criteria = "RO"
        ElseIf obj_Terimajasa_status.SelectedItem = "MO" Then
            criteria = "MO"
        ElseIf obj_Terimajasa_status.SelectedItem = "TO" Then
            criteria = "TO"
        ElseIf obj_Terimajasa_status.SelectedItem = "EO" Then
            criteria = "EO"
        End If


        Dim dlg As New DlgBpjSelectOrder(Me.DSN, criteria, Me._STRUKTUR_UNIT, names)

   
        tabels = dlg.OpenDialog(Me)

        If tabels IsNot Nothing Then
            'MsgBox(tabels.Rows(0).Item("order_id").ToString)
            Me.obj_Order_id.Text = tabels.Rows(0).Item("order_id").ToString
            ' ''Me.search_vendor(tabels.Rows(0).Item("order_id").ToString)
        End If
    End Sub

    Private Sub search_vendor(ByVal order_id_search As String)

        Dim tbl_order As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim oDataFiller As New clsDataFiller(Me.DSN)
        'Try
        If Me._LOADCOMBO = True Then
            If btn_order.Enabled = True Then
                tbl_order.Clear()
                If Mid(order_id_search, 1, 2) = "EO" Then
                    oDataFiller.DataFillLimit(tbl_order, "eo_TrnEditing_Order_Select", String.Format("order_id = '{0}'", order_id_search), 100)
                Else
                    DataFill(tbl_order, "as_TrnOrder_Select", String.Format("order_id = '{0}'", order_id_search))
                End If
                If tbl_order.Rows.Count <= 0 Then
                    Me.obj_Rekanan_id.SelectedValue = 0
                    Me.obj_Asset_valas.Text = 0
                Else
                    Me.obj_Rekanan_id.SelectedValue = tbl_order.Rows(0)("rekanan_id")
                End If
            End If
            End If
            'Catch ex As Exception

            'End Try
    End Sub


    Private Sub dgvTransaksi_terimajasa_checkDays()
        If Mid(Me.obj_Order_id.Text, 1, 2) = "RO" Or Mid(Me.obj_Order_id.Text, 1, 2) = "TO" Or Mid(Me.obj_Order_id.Text, 1, 2) = "EO" Then
            Me.DgvTrnTerimajasadetil.Columns("asset_lineinduk").Visible = True
            Me.DgvTrnTerimajasadetil.Columns("days_button").Visible = True
            Me.DgvTrnTerimajasadetil.Columns("usage").Visible = True
            If Mid(Me.obj_Order_id.Text, 1, 2) = "TO" Then
                Me.DgvTrnTerimajasadetil.Columns("asset_lineinduk").HeaderText = "Eps."
            Else
                Me.DgvTrnTerimajasadetil.Columns("asset_lineinduk").HeaderText = "Days"
            End If
        Else
            Me.DgvTrnTerimajasadetil.Columns("asset_lineinduk").Visible = False
            Me.DgvTrnTerimajasadetil.Columns("days_button").Visible = False
            Me.DgvTrnTerimajasadetil.Columns("usage").Visible = False
        End If
    End Sub
    Private Sub builtJurnal()
        Dim rows_debet, rows_kredit, rows_reference As Integer
        Dim order_id As String
        Dim tbl_orderTemp As DataTable = New DataTable
        Dim tbl_debetTemp As DataTable = New DataTable
        Dim table_mstArtisDetil As DataTable = New DataTable
        Dim tbl_master_artisdetil As DataTable = New DataTable
        Dim tblUsage As DataTable = New DataTable
        Dim total_usage As Integer = 0
        Dim q As Integer = 0
        Dim criteria As String = String.Empty

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim tbl_pajak_pph21 As DataTable = New DataTable
        Dim row_index, g As Integer
        Dim requestdetil_foreignreal, requestdetil_foreignrate, requestdetil_qty, requestdetil_eps As Decimal
        Dim Temp_subtotal As Decimal
        Dim persen As Integer
        Dim temp_perhitungan As Decimal
        Dim pajak_pph23_grossUP_total As Decimal

        Dim jumlah_awal As Decimal = 0
        Dim jumlah_sisa As Decimal = 0
        Dim bayar_artis As Decimal = 0
        Dim bayar_pajak As Decimal = 0
        Dim bayar_total As Decimal = 0
        Dim bayar_sisa As Decimal = 0
        Dim pajak_gross As Decimal = 0
        Dim amountWithTax As Decimal = 0
        Dim object_tax As Decimal = 0

        Dim jumlah_awal_ada As Decimal = 0
        Dim bayar_artis_ada As Decimal = 0
        Dim bayar_pajak_ada As Decimal = 0
        Dim bayar_total_ada As Decimal = 0
        Dim bayar_sisa_ada As Decimal = 0
        Dim pajak_gross_ada As Decimal = 0
        Dim amountWithTax_ada As Decimal = 0
        Dim persen_ada As Integer
        Dim object_tax_ada As Decimal = 0

        Dim persens(10) As Integer
        Dim minimal(10) As Decimal
        Dim maksimal(10) As Decimal
        Dim quota(10) As Decimal
        Dim sisa_quota As Decimal = 0
        Dim tax As Decimal = 0
        Dim z As Integer
        Dim Looping As Integer

        Me.tbl_TrnJurnal.Clear()
        Me.tbl_TrnJurnaldetil.Clear()
        Me.tbl_TrnJurnaldetil_JdwPembayaran.Clear()
        Me.tbl_JurnalReference.Clear()

        Me.uiTrnTerimaJasa_OpenRowJurnalDetil(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("channel_id").Value, Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, dbConn)
        Me.uiTrnTerimaJasa_OpenRowJurnalDetil_pembayaran(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("channel_id").Value, Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, dbConn)

        If Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("order_id").Value, 1, 2) = "TO" Then
            Me.tbl_TrnTerimabarangdetil.Clear()
            Me.DataFill(Me.tbl_TrnTerimabarangdetil, "as_TrnTerimabarangdetilTO_Select", String.Format(" AND terimabarang_id = '{0}'", Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value), Me._CHANNEL, 100%)
            If Me.tbl_TrnTerimabarangdetil.Rows.Count > 0 Then
                Me.DataFill(tbl_debetTemp, "cp_MstAcc_SelectBySource", String.Format("B.source_id = 'RV-ListBpj' AND B.dk = 'K' WHERE B.source_id = 'RV-ListBpj' AND B.dk = 'K'"))

                tbl_pajak_pph21.Clear()
                Me.DataFill(tbl_pajak_pph21, "ms_MstPajakPph21_Select", "")
                For z = 0 To tbl_pajak_pph21.Rows.Count - 1
                    persens(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("persen"), 0)
                    minimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("minimal"), 0)
                    maksimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("maksimal"), 0)
                    quota(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("quota"), 0)
                Next

                For rows_debet = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                    jumlah_awal = 0
                    jumlah_sisa = 0
                    bayar_artis = 0
                    bayar_pajak = 0
                    bayar_total = 0
                    bayar_sisa = 0
                    pajak_gross = 0
                    amountWithTax = 0
                    object_tax = 0

                    jumlah_awal_ada = 0
                    bayar_artis_ada = 0
                    bayar_pajak_ada = 0
                    bayar_total_ada = 0
                    bayar_sisa_ada = 0
                    pajak_gross_ada = 0
                    amountWithTax_ada = 0
                    object_tax_ada = 0

                    order_id = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("order_id")
                    criteria = String.Format(" order_id = '{0}' AND orderdetil_line = {1} ", order_id, Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("orderdetil_line"))
                    tbl_orderTemp.Clear()
                    Me.DataFill(tbl_orderTemp, "to_TrnOrderdetil_Select", criteria)
                    table_mstArtisDetil.Clear()
                    Me.DataFill(table_mstArtisDetil, "ms_MstArtisdetil_Select", String.Format(" code = '{0}' order by line desc", tbl_orderTemp.Rows(0).Item("item_id")))

                    If tbl_orderTemp.Rows(0).Item("kategori_pajak") = 2 Then
                        If tbl_orderTemp.Rows(0).Item("type_pajak") = 1 Then
                            '================= Untuk PPH21 Potong =======================================
                            If table_mstArtisDetil.Rows.Count = 0 Then
                                ' ============= Untuk yang belum ada di table =====================

                                requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                                bayar_sisa = (Temp_subtotal * 0.5) ''''Temp_subtotal
                                object_tax = bayar_sisa ''''(Temp_subtotal * 0.5)
                                If bayar_sisa <= maksimal(0) Then
                                    Looping = 1
                                ElseIf bayar_sisa <= maksimal(1) Then
                                    Looping = 2
                                ElseIf bayar_sisa <= maksimal(2) Then
                                    Looping = 3
                                ElseIf bayar_sisa > maksimal(2) Then
                                    Looping = 4
                                End If

                                For row_index = 0 To Looping - 1
                                    If jumlah_awal <= maksimal(0) Then
                                        If bayar_sisa > quota(0) Then
                                            bayar_sisa = bayar_sisa - quota(0)
                                            bayar_pajak = (quota(0) * (persens(0) / 100))
                                            bayar_artis = quota(0) - (quota(0) * (persens(0) / 100))
                                            bayar_total = bayar_pajak + bayar_artis
                                            persen = 5
                                            jumlah_awal = minimal(1)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(0) / 100)
                                            bayar_artis += Temp_subtotal - (bayar_sisa * (persens(0) / 100))
                                            bayar_total = bayar_pajak + bayar_artis
                                            jumlah_awal = bayar_total
                                            persen = persens(0)
                                            sisa_quota = maksimal(0) - (Temp_subtotal * 0.5) 'bayar_total
                                        End If
                                    ElseIf jumlah_awal <= maksimal(1) Then
                                        If bayar_sisa > quota(1) Then
                                            bayar_sisa = bayar_sisa - quota(1)
                                            bayar_pajak += quota(1) * (persens(1) / 100)
                                            bayar_artis += quota(1) - (quota(1) * (persens(1) / 100))
                                            jumlah_awal = minimal(2)
                                            persen = persens(1)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(1) / 100)
                                            bayar_artis += (bayar_sisa + object_tax) - (bayar_sisa * (persens(1) / 100)) ''''bayar_sisa - (bayar_sisa * (persens(1) / 100))
                                            bayar_total = bayar_pajak + bayar_artis
                                            jumlah_awal = bayar_total
                                            persen = persens(1)
                                            sisa_quota = maksimal(1) - (Temp_subtotal * 0.5) ''''bayar_total
                                        End If
                                    ElseIf jumlah_awal <= maksimal(2) Then
                                        If bayar_sisa > quota(2) Then
                                            bayar_sisa = bayar_sisa - quota(2)
                                            bayar_pajak += quota(2) * (persens(2) / 100)
                                            bayar_artis += quota(2) - (quota(2) * (persens(2) / 100))
                                            jumlah_awal = minimal(3)
                                            persen = persens(2)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(2) / 100)
                                            bayar_artis += (bayar_sisa + object_tax) - (bayar_sisa * (persens(2) / 100)) ''''bayar_sisa - (bayar_sisa * (persens(2) / 100))
                                            bayar_total = bayar_pajak + bayar_artis
                                            jumlah_awal = bayar_total
                                            persen = persens(2)
                                            sisa_quota = maksimal(2) - (Temp_subtotal * 0.5) ''''bayar_total
                                        End If
                                    ElseIf jumlah_awal > maksimal(2) Then
                                        bayar_pajak += bayar_sisa * (persens(3) / 100)
                                        bayar_artis += (bayar_sisa + object_tax) - (bayar_sisa * (persens(3) / 100)) ''''bayar_sisa - (bayar_sisa * (persens(3) / 100))
                                        bayar_total = bayar_pajak + bayar_artis
                                        jumlah_awal = bayar_total
                                        persen = persens(3)
                                        sisa_quota = maksimal(2) + (Temp_subtotal * 0.5) ''''bayar_total
                                    End If
                                Next
                                Try
                                    dbConn.Open()
                                    Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Insert", dbConn)
                                    oCm.CommandType = CommandType.StoredProcedure
                                    oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_orderTemp.Rows(0).Item("item_id")
                                    If table_mstArtisDetil.Rows.Count > 0 Then
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(table_mstArtisDetil.Rows(0).Item("line"), 0) + 10
                                    Else
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = 10
                                    End If
                                    oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_orderTemp.Rows(0).Item("kategori_pajak")
                                    oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_orderTemp.Rows(0).Item("type_pajak")
                                    oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                    oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_pajak
                                    oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                    oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total
                                    oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_artis
                                    oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                                    oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                                    oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = DBNull.Value
                                    oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = String.Empty
                                    oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = persen
                                    oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = sisa_quota
                                    oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total * 0.5
                                    oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
                                    oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_orderTemp.Rows(0).Item("order_id") 'Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("terimabarang_id")
                                    oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_orderTemp.Rows(0).Item("orderdetil_line") 'tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_line")

                                    oCm.ExecuteNonQuery()
                                    oCm.Dispose()
                                Catch ex As Data.OleDb.OleDbException
                                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Catch ex As Exception
                                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Finally
                                    dbConn.Close()
                                End Try

                                '============ Awal dari masukkan data ke tab bagian Debet ===========
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Add()
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("acc_id") = tbl_orderTemp.Rows(0).Item("acc_id")
                                If tbl_orderTemp.Rows(0).Item("currency_id") = 1 Then
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                Else
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                End If
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                                '============ Akhir dari masukkan data ke tab bagian Debet ===========

                                '============ Mulai masukkan data ke tab bagian Kredit Na =======
                                Me.tbl_TrnJurnaldetil.Rows.Add()
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                                If tbl_orderTemp.Rows(0).Item("currency_id") = 1 Then
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                Else
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                End If
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                                '============ Akhir dari masukkan data ke tab bagian Kredit ===========


                                '============ Mulai masukkan data ke tab bagian Reference Na =======
                                Me.tbl_JurnalReference.Rows.Add()
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_ref") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_refline") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                '============ Akhir dari masukkan data ke tab Reference Kredit ===========


                                ' ============= Akhir Untuk yang belum ada di table =====================

                            Else

                                ' ============= Untuk yang udah ada di table =====================
                                ' ''tbl_pajak_pph21.Clear()
                                ' ''Me.DataFill(tbl_pajak_pph21, "ms_MstPajakPph21_Select", "")
                                ' ''For z = 0 To tbl_pajak_pph21.Rows.Count - 1
                                ' ''    persens(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("persen"), 0)
                                ' ''    minimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("minimal"), 0)
                                ' ''    maksimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("maksimal"), 0)
                                ' ''    quota(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("quota"), 0)
                                ' ''Next

                                requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                                Me.DataFill(tbl_master_artisdetil, "ms_MstArtisdetilSUM_Select", String.Format("code = '{0}' ", tbl_orderTemp.Rows(0).Item("item_id")))
                                temp_perhitungan = tbl_master_artisdetil.Rows(0).Item("total_50persen")

                                jumlah_awal_ada = temp_perhitungan
                                bayar_sisa_ada = ((Temp_subtotal * 0.5) + temp_perhitungan)
                                object_tax_ada = bayar_sisa_ada
                                If temp_perhitungan < maksimal(0) Then
                                    If bayar_sisa_ada <= maksimal(0) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada <= maksimal(1) Then
                                        Looping = 2
                                    ElseIf bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 3
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 4
                                    End If
                                ElseIf temp_perhitungan < maksimal(1) Then
                                    If bayar_sisa_ada <= maksimal(1) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 2
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 3
                                    End If
                                ElseIf temp_perhitungan < maksimal(2) Then
                                    If bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 2
                                    End If
                                ElseIf temp_perhitungan >= maksimal(2) Then
                                    Looping = 1
                                End If

                                For g = 0 To Looping - 1
                                    If temp_perhitungan < maksimal(0) Then
                                        If jumlah_awal_ada <= maksimal(0) Then
                                            If bayar_sisa_ada > maksimal(0) Then
                                                bayar_sisa_ada = maksimal(0) - temp_perhitungan
                                                bayar_pajak_ada = (maksimal(0) - temp_perhitungan) * (persens(0) / 100)
                                                bayar_artis_ada = (maksimal(0) - temp_perhitungan) - ((maksimal(0) - temp_perhitungan) * (persens(0) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                persen_ada = persens(0)
                                                jumlah_awal_ada = 50000001
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada 'object_tax_ada - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(0) / 100) 'bayar_sisa_ada * (persens(0) / 100) ''''Temp_subtotal * (persens(0) / 100)
                                                bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(0) / 100)) '(bayar_sisa_ada * (persens(0) / 100)) ''''(Temp_subtotal * (persens(0) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(0)
                                                sisa_quota = maksimal(0) - ((bayar_total_ada * 0.5) + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada <= maksimal(1) Then
                                            If bayar_sisa_ada > quota(1) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(1)
                                                bayar_pajak_ada += quota(1) * (persens(1) / 100)
                                                bayar_artis_ada += quota(1) - (quota(1) * (persens(1) / 100))
                                                jumlah_awal_ada = minimal(2)
                                                persen_ada = persens(1)
                                            Else
                                                bayar_pajak_ada += bayar_sisa_ada * (persens(1) / 100)
                                                ''''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(1) / 100)) '((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(1) / 100)) - temp_perhitungan) ''''bayar_sisa_ada - (bayar_sisa_ada * (persens(1) / 100))
                                                bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(1) / 100)) - temp_perhitungan)
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(1)
                                                sisa_quota = maksimal(1) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > quota(2) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                bayar_pajak_ada += quota(2) * (persens(2) / 100)
                                                bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                                                jumlah_awal_ada = minimal(3)
                                                persen_ada = persens(2)
                                            Else
                                                bayar_pajak_ada += bayar_sisa_ada * (persens(2) / 100)
                                                bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(2) / 100)) - temp_perhitungan)
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)
                                                sisa_quota = maksimal(2) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                                            bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(3) / 100)) - temp_perhitungan)
                                            bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                        End If

                                    ElseIf temp_perhitungan < maksimal(1) Then
                                        If jumlah_awal_ada <= maksimal(1) Then
                                            If bayar_sisa_ada > maksimal(1) Then
                                                bayar_sisa_ada = maksimal(1) - temp_perhitungan
                                                bayar_pajak_ada = (maksimal(1) - temp_perhitungan) * (persens(1) / 100)
                                                bayar_artis_ada = (maksimal(1) - temp_perhitungan) - ((maksimal(1) - temp_perhitungan) * (persens(1) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                persen_ada = persens(1)
                                                jumlah_awal_ada = minimal(2)
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(1) / 100)
                                                bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(1) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(1)
                                                sisa_quota = maksimal(1) - ((Temp_subtotal * 0.5) + temp_perhitungan) ''''(Temp_subtotal + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > quota(2) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                bayar_pajak_ada += quota(2) * (persens(2) / 100)
                                                bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                                                jumlah_awal_ada = minimal(3)
                                                persen_ada = persens(2)
                                            Else
                                                bayar_pajak_ada += bayar_sisa_ada * (persens(2) / 100)
                                                ''''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(2) / 100))
                                                bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(2) / 100)) - temp_perhitungan)
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)
                                                sisa_quota = maksimal(2) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                                            '' ''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(3) / 100))
                                            bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(3) / 100)) - temp_perhitungan)
                                            bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                        End If

                                    ElseIf temp_perhitungan < maksimal(2) Then
                                        If jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > maksimal(2) Then
                                                bayar_sisa_ada = maksimal(2) - temp_perhitungan
                                                bayar_pajak_ada = (maksimal(2) - temp_perhitungan) * (persens(2) / 100)
                                                bayar_artis_ada = (maksimal(2) - temp_perhitungan) - ((maksimal(2) - temp_perhitungan) * (persens(2) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                persen_ada = persens(2)
                                                jumlah_awal_ada = minimal(3)
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(2) / 100)
                                                bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(2) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)
                                                sisa_quota = maksimal(2) - ((Temp_subtotal * 0.5) + temp_perhitungan) ''''(Temp_subtotal + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                                            '' ''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(3) / 100))
                                            bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(3) / 100)) - temp_perhitungan)
                                            bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                        End If
                                    ElseIf temp_perhitungan >= maksimal(2) Then
                                        bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(3) / 100)
                                        bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(3) / 100))
                                        bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                        jumlah_awal_ada = bayar_total_ada
                                        persen_ada = persens(3)
                                        sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                    End If
                                Next
                                Try
                                    dbConn.Open()
                                    Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Insert", dbConn)
                                    oCm.CommandType = CommandType.StoredProcedure
                                    oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_orderTemp.Rows(0).Item("item_id")
                                    If table_mstArtisDetil.Rows.Count > 0 Then
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(table_mstArtisDetil.Rows(0).Item("line"), 0) + 10
                                    Else
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = 10
                                    End If
                                    oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_orderTemp.Rows(0).Item("kategori_pajak")
                                    oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_orderTemp.Rows(0).Item("type_pajak")
                                    oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                    oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_pajak_ada
                                    oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                    oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total_ada
                                    oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_artis_ada
                                    oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                                    oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                                    oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = DBNull.Value
                                    oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = String.Empty
                                    oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = persen_ada
                                    oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = sisa_quota
                                    oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total_ada * 0.5
                                    oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
                                    oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_orderTemp.Rows(0).Item("order_id") 'Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("terimabarang_id")
                                    oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_orderTemp.Rows(0).Item("orderdetil_line") 'tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_line")

                                    oCm.ExecuteNonQuery()
                                    oCm.Dispose()
                                Catch ex As Data.OleDb.OleDbException
                                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Catch ex As Exception
                                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Finally
                                    dbConn.Close()
                                End Try

                                '============ Awal dari masukkan data ke tab bagian Debet ===========
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Add()
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("acc_id") = tbl_orderTemp.Rows(0).Item("acc_id")
                                If tbl_orderTemp.Rows(0).Item("currency_id") = 1 Then
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                Else
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")

                                End If
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                                '============ Akhir dari masukkan data ke tab bagian Debet ===========

                                '============ Mulai masukkan data ke tab bagian Kredit Na =======
                                Me.tbl_TrnJurnaldetil.Rows.Add()
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                                If tbl_orderTemp.Rows(0).Item("currency_id") = 1 Then
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                Else
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                End If
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                                '============ Akhir dari masukkan data ke tab bagian Kredit ===========


                                '============ Mulai masukkan data ke tab bagian Reference Na =======
                                Me.tbl_JurnalReference.Rows.Add()
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_ref") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_refline") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                '============ Akhir dari masukkan data ke tab Reference Kredit ===========

                                '' ''============ Mulai masukkan data ke tabel bagian Header Na =======
                                ' ''If tbl_orderTemp.Rows.Count > 0 Then
                                ' ''    Me.tbl_TrnJurnal.Rows.Add()
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.obj_Notes.Text
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisabled") = 0
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 0
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createby") = Me.UserName
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createdate") = Now()
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifyby") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifydate") = DBNull.Value
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postby") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postdate") = DBNull.Value
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_duedate") = Now.Date
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_faktur") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-ListBpj"
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id") = "RV"
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("channel_id") = Me._CHANNEL
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("region_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("branch_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = 0
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("sub1_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("sub2_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = Mid(Now.Year, 3, 2) & Now.Month
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("acc_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("invoice_descr") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_billdate") = Now.Date
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("account_ca_id") = 0
                                ' ''End If
                                '' ''============ Akhir dari masukkan data ke tabel Header ===========

                                ' ''Me.uiTrnJurnal_Save()
                                ' ============= Akhir Untuk yang udah ada di table =====================
                            End If
                            '================= Akhir Untuk PPH21 Potong =======================================
                        Else
                            '================= Untuk PPH21 Gross UP =======================================
                            If table_mstArtisDetil.Rows.Count = 0 Then
                                ' ============= Untuk yang belum ada di table =====================
                                requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                                bayar_sisa = (Temp_subtotal * 0.5)
                                object_tax = bayar_sisa

                                If bayar_sisa <= maksimal(0) Then
                                    Looping = 1
                                ElseIf bayar_sisa <= maksimal(1) Then
                                    Looping = 2
                                ElseIf bayar_sisa <= maksimal(2) Then
                                    Looping = 3
                                ElseIf bayar_sisa > maksimal(2) Then
                                    Looping = 4
                                End If

                                For row_index = 0 To Looping - 1
                                    If jumlah_awal <= maksimal(0) Then
                                        If bayar_sisa > quota(0) Then
                                            bayar_sisa = bayar_sisa - quota(0)
                                            bayar_pajak = quota(0) * (persens(0) / 100)
                                            bayar_artis = quota(0) '- (quota(0) * (persens(0) / 100))
                                            'bayar_total = bayar_pajak + bayar_artis
                                            persen = 5
                                            jumlah_awal = minimal(1)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(0) / 100)
                                            pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(0))), MidpointRounding.ToEven)
                                            bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                            amountWithTax = bayar_artis - pajak_gross
                                            bayar_total = pajak_gross + bayar_artis
                                            jumlah_awal = bayar_total
                                            persen = persens(0)
                                            sisa_quota = maksimal(0) - ((Temp_subtotal * 0.5) + pajak_gross)  ''''bayar_total
                                        End If

                                    ElseIf jumlah_awal <= maksimal(1) Then
                                        If bayar_sisa > quota(1) Then
                                            bayar_sisa = bayar_sisa - quota(1)
                                            bayar_pajak += quota(1) * (persens(1) / 100)
                                            bayar_artis += quota(1) '- (quota(1) * (persens(1) / 100))
                                            jumlah_awal = minimal(2)
                                            persen = persens(1)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(1) / 100)
                                            pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(1))), MidpointRounding.ToEven)
                                            bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                            amountWithTax = bayar_artis - pajak_gross
                                            bayar_total = pajak_gross + bayar_artis

                                            sisa_quota = maksimal(1) - ((Temp_subtotal * 0.5) + pajak_gross) ''''bayar_total
                                            jumlah_awal = bayar_total
                                            persen = persens(1)
                                        End If

                                    ElseIf jumlah_awal <= maksimal(2) Then
                                        If bayar_sisa > quota(2) Then
                                            bayar_sisa = bayar_sisa - quota(2)
                                            bayar_pajak += quota(2) * (persens(2) / 100)
                                            bayar_artis += quota(2) '- (quota(2) * (persens(2) / 100))
                                            jumlah_awal = minimal(3)
                                            persen = persens(2)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(2) / 100)
                                            pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                            bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                            amountWithTax = bayar_artis - pajak_gross
                                            bayar_total = pajak_gross + bayar_artis
                                            jumlah_awal = bayar_total
                                            persen = persens(2)

                                            sisa_quota = maksimal(2) - ((Temp_subtotal * 0.5) + pajak_gross) ''''bayar_total
                                        End If

                                    ElseIf jumlah_awal > maksimal(2) Then
                                        bayar_pajak += bayar_sisa * (persens(3) / 100)
                                        pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                        bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                        amountWithTax = bayar_artis - pajak_gross
                                        bayar_total = pajak_gross + bayar_artis

                                        jumlah_awal = bayar_total
                                        persen = persens(3)
                                        sisa_quota = maksimal(2) + ((Temp_subtotal * 0.5) + pajak_gross) ''''bayar_total
                                    End If
                                Next
                                Try
                                    dbConn.Open()
                                    Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Insert", dbConn)
                                    oCm.CommandType = CommandType.StoredProcedure
                                    oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_orderTemp.Rows(0).Item("item_id")
                                    If table_mstArtisDetil.Rows.Count > 0 Then
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(table_mstArtisDetil.Rows(0).Item("line"), 0) + 10
                                    Else
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = 10
                                    End If
                                    oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_orderTemp.Rows(0).Item("kategori_pajak")
                                    oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_orderTemp.Rows(0).Item("type_pajak")
                                    oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                    oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = pajak_gross
                                    oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                    oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total
                                    oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_artis
                                    oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                                    oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                                    oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = DBNull.Value
                                    oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = String.Empty
                                    oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = persen
                                    oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = sisa_quota
                                    oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = (Temp_subtotal * 0.5) + pajak_gross
                                    oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
                                    oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_orderTemp.Rows(0).Item("order_id") 'Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("terimabarang_id")
                                    oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_orderTemp.Rows(0).Item("orderdetil_line") 'tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_line")

                                    oCm.ExecuteNonQuery()
                                    oCm.Dispose()
                                Catch ex As Data.OleDb.OleDbException
                                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Catch ex As Exception
                                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Finally
                                    dbConn.Close()
                                End Try

                                '============ Awal dari masukkan data ke tab bagian Debet ===========
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Add()
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("acc_id") = tbl_orderTemp.Rows(0).Item("acc_id")
                                If tbl_orderTemp.Rows(0).Item("currency_id") = 1 Then
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                Else
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                End If
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")

                                '============ Akhir dari masukkan data ke tab bagian Debet ===========

                                '============ Mulai masukkan data ke tab bagian Kredit Na =======
                                Me.tbl_TrnJurnaldetil.Rows.Add()
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                                If tbl_orderTemp.Rows(0).Item("currency_id") = 1 Then
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                Else
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                End If
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                                '============ Akhir dari masukkan data ke tab bagian Kredit ===========


                                '============ Mulai masukkan data ke tab bagian Reference Na =======
                                Me.tbl_JurnalReference.Rows.Add()
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_ref") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_refline") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                '============ Akhir dari masukkan data ke tab Reference Kredit ===========

                                '' ''============ Mulai masukkan data ke tabel bagian Header Na =======
                                ' ''If tbl_orderTemp.Rows.Count > 0 Then
                                ' ''    Me.tbl_TrnJurnal.Rows.Add()
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.obj_Notes.Text
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisabled") = 0
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 0
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createby") = Me.UserName
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createdate") = Now()
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifyby") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifydate") = DBNull.Value
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postby") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postdate") = DBNull.Value
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_duedate") = Now.Date
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_faktur") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-ListBpj"
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id") = "RV"
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("channel_id") = Me._CHANNEL
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("region_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("branch_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = 0
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("sub1_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("sub2_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = Mid(Now.Year, 3, 2) & Now.Month
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("acc_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("invoice_descr") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_billdate") = Now.Date
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("account_ca_id") = 0
                                ' ''End If
                                '' ''============ Akhir dari masukkan data ke tabel Header ===========

                                ' ''Me.uiTrnJurnal_Save()
                                ' ============= Akhir yang belum ada di table =====================
                            Else
                                ' ============= Untuk yang udah ada di table =====================
                                requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                                Me.DataFill(tbl_master_artisdetil, "ms_MstArtisdetilSUM_Select", String.Format("code = '{0}' ", tbl_orderTemp.Rows(0).Item("item_id")))
                                temp_perhitungan = tbl_master_artisdetil.Rows(0).Item("total_50persen")

                                jumlah_awal_ada = temp_perhitungan
                                ''''bayar_sisa_ada = (Temp_subtotal + temp_perhitungan)
                                bayar_sisa_ada = ((Temp_subtotal * 0.5) + temp_perhitungan)
                                object_tax_ada = bayar_sisa_ada

                                If temp_perhitungan < maksimal(0) Then
                                    If bayar_sisa_ada <= maksimal(0) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada <= maksimal(1) Then
                                        Looping = 2
                                    ElseIf bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 3
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 4
                                    End If

                                ElseIf temp_perhitungan < maksimal(1) Then
                                    If bayar_sisa_ada <= maksimal(1) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 2
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 3
                                    End If

                                ElseIf temp_perhitungan < maksimal(2) Then
                                    If bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 2
                                    End If

                                ElseIf temp_perhitungan >= maksimal(2) Then
                                    Looping = 1
                                End If

                                For g = 0 To Looping - 1
                                    If temp_perhitungan < maksimal(0) Then

                                        If jumlah_awal_ada <= maksimal(0) Then
                                            If bayar_sisa_ada > maksimal(0) Then
                                                bayar_sisa_ada = maksimal(0) - temp_perhitungan
                                                bayar_pajak_ada = Math.Round((maksimal(0) - temp_perhitungan) * (persens(0) / 100), MidpointRounding.ToEven)

                                                persen_ada = persens(0)
                                                jumlah_awal_ada = 50000001
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(0) / 100), MidpointRounding.ToEven) ''''Math.Round(Temp_subtotal * (persens(0) / 100), MidpointRounding.ToEven)
                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(0))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal

                                                sisa_quota = maksimal(0) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) '(Temp_subtotal  + temp_perhitungan)
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(0)
                                            End If

                                        ElseIf jumlah_awal_ada <= maksimal(1) Then
                                            If bayar_sisa_ada > quota(1) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(1)
                                                bayar_pajak_ada += Math.Round(quota(1) * (persens(1) / 100), MidpointRounding.ToEven)

                                                jumlah_awal_ada = minimal(2)
                                                persen_ada = persens(1)
                                            Else
                                                bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(1) / 100), MidpointRounding.ToEven)
                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(1))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal

                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(1)
                                                sisa_quota = maksimal(1) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(1) - (bayar_total_ada + temp_perhitungan)
                                            End If

                                        ElseIf jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > quota(2) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                bayar_pajak_ada += Math.Round(quota(2) * (persens(2) / 100), MidpointRounding.ToEven)

                                                jumlah_awal_ada = minimal(3)
                                                persen_ada = persens(2)
                                            Else
                                                bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(2) / 100), MidpointRounding.ToEven)

                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)

                                                sisa_quota = maksimal(2) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) - (bayar_total_ada + temp_perhitungan)
                                            End If

                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                                            pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                            amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                            bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''  maksimal(2) + bayar_sisa_ada
                                        End If

                                    ElseIf temp_perhitungan < maksimal(1) Then
                                        If jumlah_awal_ada <= maksimal(1) Then
                                            If bayar_sisa_ada > maksimal(1) Then
                                                bayar_sisa_ada = maksimal(1) - temp_perhitungan
                                                bayar_pajak_ada = Math.Round((maksimal(1) - temp_perhitungan) * (persens(1) / 100), MidpointRounding.ToEven)

                                                persen_ada = persens(1)
                                                jumlah_awal_ada = minimal(2)
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(1) / 100), MidpointRounding.ToEven) ''''Math.Round((Temp_subtotal) * (persens(1) / 100), MidpointRounding.ToEven)

                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(1))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(1)
                                                sisa_quota = maksimal(1) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(1) - (Temp_subtotal + temp_perhitungan)
                                            End If

                                        ElseIf jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > quota(2) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                bayar_pajak_ada += Math.Round(quota(2) * (persens(2) / 100), MidpointRounding.ToEven)
                                                'bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                                                jumlah_awal_ada = minimal(3)
                                                persen_ada = persens(2)
                                            Else
                                                bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(2) / 100), MidpointRounding.ToEven)

                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)
                                                sisa_quota = maksimal(2) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) - (bayar_total_ada + temp_perhitungan)
                                            End If

                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                                            pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                            amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                            bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                        End If

                                    ElseIf temp_perhitungan < maksimal(2) Then
                                        If jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > maksimal(2) Then
                                                bayar_sisa_ada = maksimal(2) - temp_perhitungan
                                                bayar_pajak_ada = Math.Round((maksimal(2) - temp_perhitungan) * (persens(2) / 100), MidpointRounding.ToEven)

                                                persen_ada = persens(2)
                                                jumlah_awal_ada = minimal(3)
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(2) / 100), MidpointRounding.ToEven) ''''Temp_subtotal * (persens(2) / 100)
                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)
                                                sisa_quota = maksimal(2) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) - (Temp_subtotal + temp_perhitungan)
                                            End If

                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                                            pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                            amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                            bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) + (bayar_total_ada + temp_perhitungan)
                                        End If

                                    ElseIf temp_perhitungan >= maksimal(2) Then
                                        bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(3) / 100), MidpointRounding.ToEven) ''''Temp_subtotal * (persens(3) / 100)
                                        pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                        amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                        bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                        jumlah_awal_ada = bayar_total_ada
                                        persen_ada = persens(3)
                                        sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) + (bayar_total_ada + temp_perhitungan)
                                    End If
                                Next
                                Try
                                    dbConn.Open()
                                    Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Insert", dbConn)
                                    oCm.CommandType = CommandType.StoredProcedure
                                    oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_orderTemp.Rows(0).Item("item_id")
                                    If table_mstArtisDetil.Rows.Count > 0 Then
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(table_mstArtisDetil.Rows(0).Item("line"), 0) + 10
                                    Else
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = 10
                                    End If
                                    oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_orderTemp.Rows(0).Item("kategori_pajak")
                                    oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_orderTemp.Rows(0).Item("type_pajak")
                                    oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                    oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = pajak_gross_ada
                                    oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                    oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total_ada
                                    oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                    oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                                    oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                                    oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = DBNull.Value
                                    oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = String.Empty
                                    oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = persen_ada
                                    oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = sisa_quota
                                    oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = (Temp_subtotal * 0.5) + pajak_gross_ada
                                    oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
                                    oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_orderTemp.Rows(0).Item("order_id") 'Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("terimabarang_id")
                                    oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_orderTemp.Rows(0).Item("orderdetil_line") 'tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_line")

                                    oCm.ExecuteNonQuery()
                                    oCm.Dispose()
                                Catch ex As Data.OleDb.OleDbException
                                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Catch ex As Exception
                                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Finally
                                    dbConn.Close()
                                End Try

                                '============ Awal dari masukkan data ke tab bagian Debet ===========
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Add()
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("acc_id") = tbl_orderTemp.Rows(0).Item("acc_id")
                                If tbl_orderTemp.Rows(0).Item("currency_id") = 1 Then
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                Else
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")

                                End If
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                                '============ Akhir dari masukkan data ke tab bagian Debet ===========

                                '============ Mulai masukkan data ke tab bagian Kredit Na =======
                                Me.tbl_TrnJurnaldetil.Rows.Add()
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                                If tbl_orderTemp.Rows(0).Item("currency_id") = 1 Then
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                Else
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", bayar_total_ada)
                                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                                End If
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                                '============ Akhir dari masukkan data ke tab bagian Kredit ===========

                                '============ Mulai masukkan data ke tab bagian Reference Na =======
                                Me.tbl_JurnalReference.Rows.Add()
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_ref") = tbl_orderTemp.Rows(0).Item("order_id")
                                Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_refline") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                                '============ Akhir dari masukkan data ke tab Reference Kredit ===========

                                '' ''============ Mulai masukkan data ke tabel bagian Header Na =======
                                ' ''If tbl_orderTemp.Rows.Count > 0 Then
                                ' ''    Me.tbl_TrnJurnal.Rows.Add()
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.obj_Notes.Text
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisabled") = 0
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 0
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createby") = Me.UserName
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createdate") = Now()
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifyby") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifydate") = DBNull.Value
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postby") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postdate") = DBNull.Value
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_duedate") = Now.Date
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_faktur") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-ListBpj"
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id") = "RV"
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("channel_id") = Me._CHANNEL
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("region_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("branch_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = 0
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("sub1_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("sub2_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = Mid(Now.Year, 3, 2) & Now.Month
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("acc_id") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("invoice_descr") = String.Empty
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_billdate") = Now.Date
                                ' ''    Me.tbl_TrnJurnal.Rows(0).Item("account_ca_id") = 0
                                ' ''End If
                                '' ''============ Akhir dari masukkan data ke tabel Header ===========

                                ' ''Me.uiTrnJurnal_Save()
                                ' ============= Akhir yang udah ada di table =====================
                            End If
                            '================= Akhir Untuk PPH21 Gross UP =======================================
                        End If

                    ElseIf tbl_orderTemp.Rows(0).Item("kategori_pajak") = 3 Or tbl_orderTemp.Rows(0).Item("kategori_pajak") = 4 Then

                        '===================== Untuk PPh23 dan PPh23 Royalti ===================================================
                        If tbl_orderTemp.Rows(0).Item("type_pajak") = 1 Then
                            requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                            requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                            requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                            requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                            Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                            'dipotong
                            '============ Awal dari masukkan data ke tab bagian Debet ===========
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Add()
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("acc_id") = tbl_orderTemp.Rows(rows_debet).Item("acc_id")
                            If tbl_orderTemp.Rows(rows_debet).Item("currency_id") = 1 Then
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", Temp_subtotal)
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Temp_subtotal)
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                            Else
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", Temp_subtotal)
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Temp_subtotal)
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                            End If
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                            '============ Akhir dari masukkan data ke tab bagian Debet ===========

                            '============ Mulai masukkan data ke tab bagian Kredit Na =======
                            Me.tbl_TrnJurnaldetil.Rows.Add()
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                            If tbl_orderTemp.Rows(rows_debet).Item("currency_id") = 1 Then
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", Temp_subtotal)
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Temp_subtotal)
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                            Else
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", Temp_subtotal)
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Temp_subtotal)
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                            End If
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                            '============ Akhir dari masukkan data ke tab bagian Kredit ===========


                            '============ Mulai masukkan data ke tab bagian Reference Na =======
                            Me.tbl_JurnalReference.Rows.Add()
                            Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                            Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_ref") = tbl_orderTemp.Rows(0).Item("order_id")
                            Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_refline") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                            '============ Akhir dari masukkan data ke tab Reference Kredit ===========


                        ElseIf tbl_orderTemp.Rows(0).Item("type_pajak") = 2 Then
                            'gross up
                            requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                            requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                            requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                            requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                            Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)
                            pajak_pph23_grossUP_total = Temp_subtotal + ((Temp_subtotal * (100 / (100 - tbl_orderTemp.Rows(0).Item("orderdetil_pphpercent")))) - Temp_subtotal)

                            '============ Awal dari masukkan data ke tab bagian Debet ===========
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Add()
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("acc_id") = tbl_orderTemp.Rows(rows_debet).Item("acc_id")
                            If tbl_orderTemp.Rows(rows_debet).Item("currency_id") = 1 Then
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", pajak_pph23_grossUP_total)
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", pajak_pph23_grossUP_total)
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                            Else
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", pajak_pph23_grossUP_total)
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", pajak_pph23_grossUP_total)
                                Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                            End If
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                            '============ Akhir dari masukkan data ke tab bagian Debet ===========

                            '============ Mulai masukkan data ke tab bagian Kredit Na =======
                            Me.tbl_TrnJurnaldetil.Rows.Add()
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                            If tbl_orderTemp.Rows(rows_debet).Item("currency_id") = 1 Then
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", pajak_pph23_grossUP_total)
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", pajak_pph23_grossUP_total)
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                            Else
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", pajak_pph23_grossUP_total)
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", pajak_pph23_grossUP_total)
                                Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                            End If
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                            '============ Akhir dari masukkan data ke tab bagian Kredit ===========


                            '============ Mulai masukkan data ke tab bagian Reference Na =======
                            Me.tbl_JurnalReference.Rows.Add()
                            Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                            Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_ref") = tbl_orderTemp.Rows(0).Item("order_id")
                            Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_refline") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                            '============ Akhir dari masukkan data ke tab Reference Kredit ===========
                        End If
                        '' ''============ Mulai masukkan data ke tabel bagian Header Na =======
                        ' ''If tbl_orderTemp.Rows.Count > 0 Then
                        ' ''    Me.tbl_TrnJurnal.Rows.Add()
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.obj_Notes.Text
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisabled") = 0
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 0
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createby") = Me.UserName
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createdate") = Now()
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifyby") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifydate") = DBNull.Value
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postby") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postdate") = DBNull.Value
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_duedate") = Now.Date
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_faktur") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-ListBpj"
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id") = "RV"
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("channel_id") = Me._CHANNEL
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("region_id") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("branch_id") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = 0
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("sub1_id") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("sub2_id") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = Mid(Now.Year, 3, 2) & Now.Month
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("acc_id") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("invoice_descr") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_billdate") = Now.Date
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("account_ca_id") = 0
                        ' ''End If
                        '============ Akhir dari masukkan data ke tabel Header ===========
                        '===================== Akhir Untuk PPh23 ===================================================
                    ElseIf tbl_orderTemp.Rows(0).Item("kategori_pajak") = 1 Then
                        'No TAX atau Tidak ada pajak
                        requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                        requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                        requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                        requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                        Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                        '============ Awal dari masukkan data ke tab bagian Debet ===========
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Add()
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("acc_id") = tbl_orderTemp.Rows(rows_debet).Item("acc_id")
                        If tbl_orderTemp.Rows(rows_debet).Item("currency_id") = 1 Then
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", Temp_subtotal)
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Temp_subtotal)
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                        Else
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", Temp_subtotal)
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Temp_subtotal)
                            Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                        End If
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                        '============ Akhir dari masukkan data ke tab bagian Debet ===========

                        '============ Mulai masukkan data ke tab bagian Kredit Na =======
                        Me.tbl_TrnJurnaldetil.Rows.Add()
                        Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                        If tbl_orderTemp.Rows(rows_debet).Item("currency_id") = 1 Then
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", Temp_subtotal)
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Temp_subtotal)
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                        Else
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", Temp_subtotal)
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", Temp_subtotal)
                            Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                        End If
                        Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                        Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                        Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("jurnaldetil_foreignrate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                        Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                        Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                        Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                        '============ Akhir dari masukkan data ke tab bagian Kredit ===========


                        '============ Mulai masukkan data ke tab bagian Reference Na =======
                        Me.tbl_JurnalReference.Rows.Add()
                        Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                        Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_ref") = tbl_orderTemp.Rows(0).Item("order_id")
                        Me.tbl_JurnalReference.Rows(rows_debet).Item("jurnal_id_refline") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                        '============ Akhir dari masukkan data ke tab Reference Kredit ===========

                        '' ''============ Mulai masukkan data ke tabel bagian Header Na =======
                        ' ''If tbl_orderTemp.Rows.Count > 0 Then
                        ' ''    Me.tbl_TrnJurnal.Rows.Add()
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.obj_Notes.Text
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isdisabled") = 0
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_isposted") = 0
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createby") = Me.UserName
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_createdate") = Now()
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifyby") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_modifydate") = DBNull.Value
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postby") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_postdate") = DBNull.Value
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_duedate") = Now.Date
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_faktur") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-ListBpj"
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id") = "RV"
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("channel_id") = Me._CHANNEL
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("region_id") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("branch_id") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = 0
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("sub1_id") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("sub2_id") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = Mid(Now.Year, 3, 2) & Now.Month
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("acc_id") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("invoice_descr") = String.Empty
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_billdate") = Now.Date
                        ' ''    Me.tbl_TrnJurnal.Rows(0).Item("account_ca_id") = 0
                        ' ''End If
                        '' ''============ Akhir dari masukkan data ke tabel Header ===========
                    End If

                Next

                '============ Mulai masukkan data ke tabel bagian Header Na =======
                If tbl_orderTemp.Rows.Count > 0 Then
                    Me.tbl_TrnJurnal.Clear()
                    Me.tbl_TrnJurnal.Rows.Add()
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("notes").Value
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
                    Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = Me._STRUKTUR_UNIT
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

                Me.uiTrnJurnal_Save()
            End If
        ElseIf Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("order_id").Value, 1, 2) = "EO" Then

            Me.tbl_TrnTerimabarangdetil.Clear()
            Me.DataFill(Me.tbl_TrnTerimabarangdetil, "as_TrnTerimabarangdetilEO_Select", String.Format(" AND terimabarang_id = '{0}'", Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value), Me._CHANNEL, 100%)
            If Me.tbl_TrnTerimabarangdetil.Rows.Count > 0 Then
                order_id = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("order_id")
               
                tbl_debetTemp.Clear()
                tbl_TrnJurnal.Clear()

                ' ''Me.DataFill(tbl_orderTemp, "as_TrnOrderDetilEditingJurnal_Select", criteria)
                Me.DataFill(tbl_debetTemp, "cp_MstAcc_SelectBySource", String.Format("B.source_id = 'RV-ListBpj' AND B.dk = 'K' WHERE B.source_id = 'RV-ListBpj' AND B.dk = 'K'"))

                '============ Mulai masukkan data ke tab bagian Debet Na =======
                For rows_debet = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                    tbl_orderTemp.Clear()
                    criteria = String.Format(" order_id = '{0}' AND orderdetil_line = {1} ", order_id, Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("orderdetil_line"))
                    Me.DataFill(tbl_orderTemp, "as_TrnOrderDetilEditingJurnal_Select", criteria)
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Add()
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("acc_id") = tbl_orderTemp.Rows(0).Item("acc_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreignrate") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                    If Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("currency_id") = 1 Then
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("usage"), 0))) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("usage"), 0))) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                    Else
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("usage"), 0))) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("usage"), 0))) 'String.Format("{0:#,##0}",(clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                    End If
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("currency_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("currency_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                Next
                '============ Akhir dari masukkan data ke tab bagian Debet ===========

                '============ Mulai masukkan data ke tab bagian Kredit Na =======
                For rows_kredit = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                    Me.tbl_TrnJurnaldetil.Rows.Add()
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreignrate") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_valas")
                    If Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("currency_id") = 1 Then
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("usage"), 0))) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("usage"), 0))) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_deskripsi")
                    Else
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("usage"), 0))) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_valas"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("usage"), 0))) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_valas"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_deskripsi")
                    End If
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("currency_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("currency_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("strukturunit_id")
                Next
                '============ Akhir dari masukkan data ke tab bagian Kredit ===========

                '============ Mulai masukkan data ke tab bagian Reference Na =======
                For rows_reference = 0 To tbl_TrnTerimabarangdetil.Rows.Count - 1
                    Me.tbl_JurnalReference.Rows.Add()
                    Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                    Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_ref") = tbl_TrnTerimabarangdetil.Rows(rows_reference).Item("order_id")
                    Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_refline") = tbl_TrnTerimabarangdetil.Rows(rows_reference).Item("orderdetil_line")
                Next
                '============ Akhir dari masukkan data ke tab Reference Kredit ===========

                '============ Mulai masukkan data ke tabel bagian Header Na =======
                If tbl_orderTemp.Rows.Count > 0 Then
                    Me.tbl_TrnJurnal.Rows.Add()
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("notes").Value
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
                    Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = Me._STRUKTUR_UNIT
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
                        Exit For
                    Else
                        isAcc_ok = "ok"
                    End If
                Next
                If isAcc_ok = "ok" Then
                    Me.uiTrnJurnal_Save()
                End If
            End If
        ElseIf Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("order_id").Value, 1, 2) = "MO" Then
            Me.tbl_TrnTerimabarangdetil.Clear()
            Me.DataFill(Me.tbl_TrnTerimabarangdetil, "as_TrnTerimabarangdetil_Select", String.Format(" AND terimabarang_id = '{0}'", Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value), Me._CHANNEL, 100%)
            If Me.tbl_TrnTerimabarangdetil.Rows.Count > 0 Then
                order_id = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("order_id")

                criteria = String.Format(" order_id = '{0}' AND orderdetil_line in ( {1} )", order_id, criteria)
                tbl_debetTemp.Clear()
                tbl_TrnJurnal.Clear()

                Me.DataFill(tbl_debetTemp, "cp_MstAcc_SelectBySource", String.Format("B.source_id = 'RV-ListBpj' AND B.dk = 'K' WHERE B.source_id = 'RV-ListBpj' AND B.dk = 'K'"))

                '============ Mulai masukkan data ke tab bagian Debet Na =======
                For rows_debet = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                    tbl_orderTemp.Clear()
                    criteria = String.Format(" order_id = '{0}' AND orderdetil_line = {1} ", order_id, Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("orderdetil_line"))
                    Me.DataFill(tbl_orderTemp, "as_TrnOrderDetilJurnal_Select", criteria)
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Add()
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("acc_id") = tbl_orderTemp.Rows(0).Item("acc_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreignrate") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                    If Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("currency_id") = 1 Then
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                    Else
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                    End If
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("currency_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("currency_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                Next
                '============ Akhir dari masukkan data ke tab bagian Debet ===========

                '============ Mulai masukkan data ke tab bagian Kredit Na =======
                For rows_kredit = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                    Me.tbl_TrnJurnaldetil.Rows.Add()
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreignrate") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_valas")
                    If Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("currency_id") = 1 Then
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_deskripsi")
                    Else
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_valas"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_deskripsi")
                    End If
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("currency_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("currency_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                Next
                '============ Akhir dari masukkan data ke tab bagian Kredit ===========

                '============ Mulai masukkan data ke tab bagian Reference Na =======
                For rows_reference = 0 To tbl_TrnTerimabarangdetil.Rows.Count - 1
                    Me.tbl_JurnalReference.Rows.Add()
                    Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                    Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_ref") = tbl_TrnTerimabarangdetil.Rows(rows_reference).Item("order_id")
                    Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_refline") = tbl_TrnTerimabarangdetil.Rows(rows_reference).Item("orderdetil_line")
                Next
                '============ Akhir dari masukkan data ke tab Reference Kredit ===========

                '============ Mulai masukkan data ke tabel bagian Header Na =======
                If tbl_orderTemp.Rows.Count > 0 Then
                    Me.tbl_TrnJurnal.Rows.Add()
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("notes").Value
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
                    Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = Me._STRUKTUR_UNIT
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
                        Exit For
                    Else
                        isAcc_ok = "ok"
                    End If
                Next
                If isAcc_ok = "ok" Then
                    Me.uiTrnJurnal_Save()
                End If
            End If
        Else
            Me.tbl_TrnTerimabarangdetil.Clear()
            Me.DataFill(Me.tbl_TrnTerimabarangdetil, "as_TrnTerimabarangdetil_Select", String.Format(" AND terimabarang_id = '{0}'", Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value), Me._CHANNEL, 100%)
            If Me.tbl_TrnTerimabarangdetil.Rows.Count > 0 Then
                order_id = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("order_id")

                criteria = String.Format(" order_id = '{0}' AND orderdetil_line in ( {1} )", order_id, criteria)
                tbl_debetTemp.Clear()
                tbl_TrnJurnal.Clear()

                Me.DataFill(tbl_debetTemp, "cp_MstAcc_SelectBySource", String.Format("B.source_id = 'RV-ListBpj' AND B.dk = 'K' WHERE B.source_id = 'RV-ListBpj' AND B.dk = 'K'"))

                '============ Mulai masukkan data ke tab bagian Debet Na =======
                For rows_debet = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                    tbl_orderTemp.Clear()
                    tblUsage.Clear()
                    criteria = String.Format(" order_id = '{0}' AND orderdetil_line = {1} ", order_id, Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("orderdetil_line"))
                    Me.DataFill(tbl_orderTemp, "as_TrnOrderDetilJurnal_Select", criteria)
                    Me.DataFill(tblUsage, "as_TrnTerimabarangdetilused_select", String.Format(" AND terimabarang_id = '{0}' AND terimabarang_check = 1 ", Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("terimabarang_id")), Me._CHANNEL)
                    For q = 0 To tblUsage.Rows.Count - 1
                        total_usage += clsUtil.IsDbNull(tblUsage.Rows(q).Item("terimabarangused_qty"), 0)
                    Next
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Add()
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("acc_id") = tbl_orderTemp.Rows(0).Item("acc_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreignrate") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                    If Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("currency_id") = 1 Then
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("usage"), 0)) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("usage"), 0)) ' String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                    Else
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("usage"), 0)) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("usage"), 0)) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_deskripsi")
                    End If
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("currency_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("currency_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                    Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(rows_debet).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("strukturunit_id")
                Next
                '============ Akhir dari masukkan data ke tab bagian Debet ===========

                '============ Mulai masukkan data ke tab bagian Kredit Na =======
                For rows_kredit = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                    Me.tbl_TrnJurnaldetil.Rows.Add()
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("acc_id") = tbl_debetTemp.Rows(0).Item("acc_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreignrate") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_valas")
                    If Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("currency_id") = 1 Then
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("usage"), 0)) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("usage"), 0)) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_deskripsi")
                    Else
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_foreign") = String.Format("{0:#,##0}", clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("usage"), 0)) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_idr") = String.Format("{0:#,##0}", clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_valas"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("usage"), 0)) 'String.Format("{0:#,##0}", (clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_harga"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_valas"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_lineinduk"), 0) * clsUtil.IsDbNull(Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_qty"), 0)))
                        Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("jurnaldetil_descr") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("asset_deskripsi")
                    End If
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("ref_id") = tbl_orderTemp.Rows(0).Item("order_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("ref_line") = tbl_orderTemp.Rows(0).Item("orderdetil_line")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("currency_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("currency_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                    Me.tbl_TrnJurnaldetil.Rows(rows_kredit).Item("strukturunit_id") = Me.tbl_TrnTerimabarangdetil.Rows(rows_kredit).Item("strukturunit_id")
                Next
                '============ Akhir dari masukkan data ke tab bagian Kredit ===========

                '============ Mulai masukkan data ke tab bagian Reference Na =======
                For rows_reference = 0 To tbl_TrnTerimabarangdetil.Rows.Count - 1
                    Me.tbl_JurnalReference.Rows.Add()
                    Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                    Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_ref") = tbl_TrnTerimabarangdetil.Rows(rows_reference).Item("order_id")
                    Me.tbl_JurnalReference.Rows(rows_reference).Item("jurnal_id_refline") = tbl_TrnTerimabarangdetil.Rows(rows_reference).Item("orderdetil_line")
                Next
                '============ Akhir dari masukkan data ke tab Reference Kredit ===========

                '============ Mulai masukkan data ke tabel bagian Header Na =======
                If tbl_orderTemp.Rows.Count > 0 Then
                    Me.tbl_TrnJurnal.Rows.Add()
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 1, 8) & Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value, 12, 4)
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_bookdate") = Now.Date
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_descr") = Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("notes").Value
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
                    Me.tbl_TrnJurnal.Rows(0).Item("strukturunit_id") = Me._STRUKTUR_UNIT
                    Me.tbl_TrnJurnal.Rows(0).Item("rekanan_id") = tbl_orderTemp.Rows(0).Item("rekanan_id")
                    Me.tbl_TrnJurnal.Rows(0).Item("sub1_id") = String.Empty
                    Me.tbl_TrnJurnal.Rows(0).Item("sub2_id") = String.Empty
                    Me.tbl_TrnJurnal.Rows(0).Item("currency_id") = tbl_orderTemp.Rows(0).Item("currency_id")
                    Me.tbl_TrnJurnal.Rows(0).Item("currency_rate") = tbl_orderTemp.Rows(0).Item("orderdetil_foreignrate")
                    Me.tbl_TrnJurnal.Rows(0).Item("periode_id") = String.Format("{0:yyMM}", Now)
                    Me.tbl_TrnJurnal.Rows(0).Item("acc_id") = String.Empty
                    Me.tbl_TrnJurnal.Rows(0).Item("invoice_descr") = String.Empty
                    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_billdate") = Now.Date
                    Me.tbl_TrnJurnal.Rows(0).Item("account_ca_id") = 0
                End If
                '============ Akhir dari masukkan data ke tabel Header ===========
                Dim x As Integer
                Dim isAcc_ok As String
                For x = 0 To Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows.Count - 1
                    If clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_JdwPembayaran.Rows(x).Item("acc_id"), "") = "" Then
                        isAcc_ok = "not"
                        Exit For
                    Else
                        isAcc_ok = "ok"
                    End If
                Next
                If isAcc_ok = "ok" Then
                    Me.uiTrnJurnal_Save()
                End If
            End If
        End If
    End Sub
    
    Private Function uiTrnJurnal_Save() As Boolean
        'save data
        Dim tbl_TrnJurnal_Changes As DataTable = New DataTable
        Dim tbl_JurnalReference_Changes As DataTable = New DataTable
        Dim tbl_TrnJurnaldetil_Changes As DataTable = New DataTable
        Dim tbl_TrnJurnaldetil_Pembayaran_Changes As DataTable = New DataTable
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
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
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
        dbCmdInsert.Parameters("@referencetype").Value = "jurnal Bpj"


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
    Private Sub jurnal_artis()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim i As Integer
        Dim table_order As DataTable = New DataTable
        Dim table_orderTotal_forTalent As DataTable = New DataTable
        Dim table_mstArtisDetil As DataTable = New DataTable

        For i = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
            table_order.Clear()
            table_mstArtisDetil.Clear()
            table_orderTotal_forTalent.Clear()
            Me.DataFill(table_order, "to_TrnOrderdetil_Select", String.Format(" order_id = '{0}' AND orderdetil_line = {1}", Me.tbl_TrnTerimabarangdetil.Rows(i).Item("order_id"), Me.tbl_TrnTerimabarangdetil.Rows(i).Item("orderdetil_line")))
            Me.DataFill(table_mstArtisDetil, "ms_MstArtisdetil_Select", String.Format(" code = '{0}' order by line desc", table_order.Rows(0).Item("item_id")))
            Me.DataFill(table_orderTotal_forTalent, "to_TrnOrderdetil_Select", String.Format(" item_id = '{0}'", table_order.Rows(0).Item("item_id")))
            If table_order.Rows(0).Item("kategori_pajak") = 2 Then
                If table_mstArtisDetil.Rows.Count > 0 Then
                    If clsUtil.IsDbNull(table_order.Rows(i).Item("type_pajak"), 0) = 1 Then
                        Me.uiTalentRequestPph21Potong(table_mstArtisDetil, i, table_order)
                        ' ''Else
                        ' ''    uiTalentRequestPph21GrossUp(table_mstArtisDetil, i, table_order)
                    End If
                Else
                    Try
                        dbConn.Open()
                        Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Insert", dbConn)
                        oCm.CommandType = CommandType.StoredProcedure
                        oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = table_order.Rows(0).Item("item_id")
                        If table_mstArtisDetil.Rows.Count > 0 Then
                            oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(table_mstArtisDetil.Rows(0).Item("line"), 0) + 10
                        Else
                            oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = 10
                        End If
                        oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("kategori_pajak")
                        oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("type_pajak")
                        oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("amount_talent")
                        oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("tax")
                        oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("amount_talent")
                        oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("rodetil_rowtotalforeign_incldisc")
                        oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("amount_forartist")
                        oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                        oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                        oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = DBNull.Value
                        oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = String.Empty
                        oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = table_order.Rows(0).Item("persen")
                        oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("sisa_quota")
                        If table_mstArtisDetil.Rows.Count > 0 Then
                            oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_mstArtisDetil.Rows(0).Item("total_amount_pertahun") + table_order.Rows(0).Item("rodetil_rowtotalforeign_incldisc")
                        Else
                            oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("rodetil_rowtotalforeign_incldisc")
                        End If
                        oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
                        oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = table_order.Rows(0).Item("order_id")
                        oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = table_order.Rows(0).Item("orderdetil_line")

                        oCm.ExecuteNonQuery()
                        oCm.Dispose()
                    Catch ex As Data.OleDb.OleDbException
                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Catch ex As Exception
                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        dbConn.Close()
                    End Try
                End If
            Else

                Try
                    dbConn.Open()
                    Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Insert", dbConn)
                    oCm.CommandType = CommandType.StoredProcedure
                    oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = table_order.Rows(i).Item("item_id")
                    If table_mstArtisDetil.Rows.Count > 0 Then
                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(table_mstArtisDetil.Rows(i).Item("line"), 0) + 10
                    Else
                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = 10
                    End If
                    oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(i).Item("kategori_pajak")
                    oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(i).Item("type_pajak")
                    oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(i).Item("amount_talent")
                    oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(i).Item("tax")
                    oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(i).Item("rodetil_rowtotalforeign_incldisc")
                    oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(i).Item("rodetil_rowtotalforeign_incldisc")
                    oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(i).Item("amount_forartist")
                    oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                    oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                    oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = DBNull.Value
                    oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = String.Empty
                    oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = table_order.Rows(i).Item("persen")
                    oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(i).Item("sisa_quota")
                    If table_mstArtisDetil.Rows.Count > 0 Then
                        oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_mstArtisDetil.Rows(0).Item("total_amount_pertahun") + table_order.Rows(i).Item("rodetil_rowtotalforeign_incldisc")
                    Else
                        oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(i).Item("rodetil_rowtotalforeign_incldisc")
                    End If
                    oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
                    oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = table_order.Rows(i).Item("order_id")
                    oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = table_order.Rows(i).Item("orderdetil_line")

                    oCm.ExecuteNonQuery()
                    oCm.Dispose()
                Catch ex As Data.OleDb.OleDbException
                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    dbConn.Close()
                End Try
            End If
        Next
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

#Region "PPH21 GROSS UP"
    Private Function uiTalentRequestPph21GrossUp(ByVal tbl_master_artisdetil As DataTable, _
                     ByVal rowIndex As Integer, ByVal table_order As DataTable) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim tbl_pajak_pph21 As DataTable = New DataTable
        Dim g As Integer
        Dim requestdetil_foreignreal, requestdetil_foreignrate, requestdetil_qty, requestdetil_eps As Decimal
        Dim Temp_subtotal As Decimal
        Dim persen As Integer
        Dim temp_perhitungan As Decimal

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
        Dim persen_ada As Integer

        Dim persens(10) As Integer
        Dim minimal(10) As Decimal
        Dim maksimal(10) As Decimal
        Dim quota(10) As Decimal
        Dim sisa_quota As Decimal = 0
        Dim tax As Decimal = 0
        Dim z As Integer

        Dim Looping As Integer

        tbl_pajak_pph21.Clear()

        Me.DataFill(tbl_pajak_pph21, "ms_MstPajakPph21_Select", "")
        For z = 0 To tbl_pajak_pph21.Rows.Count - 1
            persens(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("persen"), 0)
            minimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("minimal"), 0)
            maksimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("maksimal"), 0)
            quota(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("quota"), 0)
        Next

        requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rowIndex).Item("asset_harga")
        requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rowIndex).Item("asset_valas")
        requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rowIndex).Item("asset_qty")
        requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rowIndex).Item("asset_lineinduk")

        Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)


        temp_perhitungan = tbl_master_artisdetil.Rows(0).Item("total_amount_pertahun")

        persen = clsUtil.IsDbNull(tbl_master_artisdetil.Rows(0).Item("persen"), 0)

        jumlah_awal_ada = temp_perhitungan
        bayar_sisa_ada = Temp_subtotal + temp_perhitungan

        If temp_perhitungan < maksimal(0) Then
            If bayar_sisa_ada <= maksimal(0) Then
                Looping = 1
            ElseIf bayar_sisa_ada <= maksimal(1) Then
                Looping = 2
            ElseIf bayar_sisa_ada <= maksimal(2) Then
                Looping = 3
            ElseIf bayar_sisa_ada > maksimal(2) Then
                Looping = 4
            End If
        ElseIf temp_perhitungan < maksimal(1) Then
            If bayar_sisa_ada <= maksimal(1) Then
                Looping = 1
            ElseIf bayar_sisa_ada <= maksimal(2) Then
                Looping = 2
            ElseIf bayar_sisa_ada > maksimal(2) Then
                Looping = 3
            End If
        ElseIf temp_perhitungan < maksimal(2) Then
            If bayar_sisa_ada <= maksimal(2) Then
                Looping = 1
            ElseIf bayar_sisa_ada > maksimal(2) Then
                Looping = 2
            End If
        ElseIf temp_perhitungan >= maksimal(2) Then
            Looping = 1
        End If

        For g = 0 To Looping - 1
            If temp_perhitungan < maksimal(0) Then

                If jumlah_awal_ada <= maksimal(0) Then
                    If bayar_sisa_ada > maksimal(0) Then
                        bayar_sisa_ada = maksimal(0) - temp_perhitungan
                        bayar_pajak_ada = Math.Round((maksimal(0) - temp_perhitungan) * (persens(0) / 100), MidpointRounding.ToEven)

                        persen_ada = persens(0)
                        jumlah_awal_ada = 50000001
                        bayar_sisa_ada = Temp_subtotal - bayar_sisa_ada
                    Else
                        bayar_pajak_ada += Math.Round(Temp_subtotal * (persens(0) / 100), MidpointRounding.ToEven)
                        pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(0))), MidpointRounding.ToEven)
                        amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                        bayar_total_ada = pajak_gross_ada + Temp_subtotal

                        sisa_quota = maksimal(0) - (Temp_subtotal + temp_perhitungan)
                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(0)
                    End If
                ElseIf jumlah_awal_ada <= maksimal(1) Then
                    If bayar_sisa_ada > quota(1) Then
                        bayar_sisa_ada = bayar_sisa_ada - quota(1)
                        bayar_pajak_ada += Math.Round(quota(1) * (persens(1) / 100), MidpointRounding.ToEven)

                        jumlah_awal_ada = minimal(2)
                        persen_ada = persens(1)
                    Else
                        bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(1) / 100), MidpointRounding.ToEven)
                        pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(1))), MidpointRounding.ToEven)
                        amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                        bayar_total_ada = pajak_gross_ada + Temp_subtotal

                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(1)
                        sisa_quota = maksimal(1) - (bayar_total_ada + temp_perhitungan)
                    End If
                ElseIf jumlah_awal_ada <= maksimal(2) Then
                    If bayar_sisa_ada > quota(2) Then
                        bayar_sisa_ada = bayar_sisa_ada - quota(2)
                        bayar_pajak_ada += Math.Round(quota(2) * (persens(2) / 100), MidpointRounding.ToEven)

                        jumlah_awal_ada = minimal(3)
                        persen_ada = persens(2)
                    Else
                        bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(2) / 100), MidpointRounding.ToEven)

                        pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                        amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                        bayar_total_ada = pajak_gross_ada + Temp_subtotal
                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(2)

                        sisa_quota = maksimal(2) - (bayar_total_ada + temp_perhitungan)
                    End If
                ElseIf jumlah_awal_ada > maksimal(2) Then
                    bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                    pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                    amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                    bayar_total_ada = pajak_gross_ada + Temp_subtotal
                    jumlah_awal_ada = bayar_total_ada
                    persen_ada = persens(3)
                    sisa_quota = maksimal(2) + bayar_sisa_ada
                End If

            ElseIf temp_perhitungan < maksimal(1) Then
                If jumlah_awal_ada <= maksimal(1) Then
                    If bayar_sisa_ada > maksimal(1) Then
                        bayar_sisa_ada = maksimal(1) - temp_perhitungan
                        bayar_pajak_ada = Math.Round((maksimal(1) - temp_perhitungan) * (persens(1) / 100), MidpointRounding.ToEven)

                        persen_ada = persens(1)
                        jumlah_awal_ada = minimal(2)
                        bayar_sisa_ada = Temp_subtotal - bayar_sisa_ada
                    Else
                        bayar_pajak_ada += Math.Round((Temp_subtotal) * (persens(1) / 100), MidpointRounding.ToEven)

                        pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(1))), MidpointRounding.ToEven)
                        amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                        bayar_total_ada = pajak_gross_ada + Temp_subtotal
                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(1)
                        sisa_quota = maksimal(1) - (Temp_subtotal + temp_perhitungan)
                    End If

                ElseIf jumlah_awal_ada <= maksimal(2) Then
                    If bayar_sisa_ada > quota(2) Then
                        bayar_sisa_ada = bayar_sisa_ada - quota(2)
                        bayar_pajak_ada += Math.Round(quota(2) * (persens(2) / 100), MidpointRounding.ToEven)
                        'bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                        jumlah_awal_ada = minimal(3)
                        persen_ada = persens(2)
                    Else
                        bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(2) / 100), MidpointRounding.ToEven)

                        pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                        amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                        bayar_total_ada = pajak_gross_ada + Temp_subtotal
                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(2)
                        sisa_quota = maksimal(2) - (bayar_total_ada + temp_perhitungan)
                    End If

                ElseIf jumlah_awal_ada > maksimal(2) Then
                    bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                    pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                    amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                    bayar_total_ada = pajak_gross_ada + Temp_subtotal
                    jumlah_awal_ada = bayar_total_ada
                    persen_ada = persens(3)
                    sisa_quota = maksimal(2) + (bayar_total_ada + temp_perhitungan)
                End If

            ElseIf temp_perhitungan < maksimal(2) Then
                If jumlah_awal_ada <= maksimal(2) Then
                    If bayar_sisa_ada > maksimal(2) Then
                        bayar_sisa_ada = maksimal(2) - temp_perhitungan
                        bayar_pajak_ada = Math.Round((maksimal(2) - temp_perhitungan) * (persens(2) / 100), MidpointRounding.ToEven)

                        persen_ada = persens(2)
                        jumlah_awal_ada = minimal(3)
                        bayar_sisa_ada = Temp_subtotal - bayar_sisa_ada
                    Else
                        bayar_pajak_ada += Temp_subtotal * (persens(2) / 100)

                        pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                        amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                        bayar_total_ada = pajak_gross_ada + Temp_subtotal
                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(2)
                        sisa_quota = maksimal(2) - (Temp_subtotal + temp_perhitungan)
                    End If

                ElseIf jumlah_awal_ada > maksimal(2) Then
                    bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                    pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                    amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                    bayar_total_ada = pajak_gross_ada + Temp_subtotal
                    jumlah_awal_ada = bayar_total_ada
                    persen_ada = persens(3)
                    sisa_quota = maksimal(2) + (bayar_total_ada + temp_perhitungan)
                End If

            ElseIf temp_perhitungan >= maksimal(2) Then
                bayar_pajak_ada += Temp_subtotal * (persens(3) / 100)

                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                jumlah_awal_ada = bayar_total_ada
                persen_ada = persens(3)
                sisa_quota = maksimal(2) + (bayar_total_ada + temp_perhitungan)
            End If
        Next

        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Insert", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = table_order.Rows(0).Item("item_id")
            oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(tbl_master_artisdetil.Rows(0).Item("line"), 0) + 10
            oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("kategori_pajak")
            oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("type_pajak")
            oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("amount_talent")
            oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_pajak_ada
            oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total_ada
            oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total_ada
            oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
            oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
            oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
            oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = DBNull.Value
            oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = String.Empty
            oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = persen_ada
            oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = sisa_quota
            oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_master_artisdetil.Rows(0).Item("total_amount_pertahun") + bayar_total_ada
            oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
            oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = table_order.Rows(0).Item("order_id")
            oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = table_order.Rows(0).Item("orderdetil_line")

            oCm.ExecuteNonQuery()
            oCm.Dispose()
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try


    End Function

#End Region

#Region "PPH21 POTONG"
    Private Function uiTalentRequestPph21Potong(ByVal tbl_master_artisdetil As DataTable, _
                     ByVal rowIndex As Integer, ByVal table_order As DataTable) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim tbl_pajak_pph21 As DataTable = New DataTable
        Dim table_mstArtisDetil As DataTable = New DataTable

        Dim g As Integer
        Dim requestdetil_foreignreal, requestdetil_foreignrate, requestdetil_qty, requestdetil_eps As Decimal
        Dim Temp_subtotal As Decimal
        Dim persen As Integer
        Dim temp_perhitungan As Decimal

        Dim jumlah_awal As Decimal = 0
        Dim jumlah_sisa As Decimal = 0
        Dim bayar_artis As Decimal = 0
        Dim bayar_pajak As Decimal = 0
        Dim bayar_total As Decimal = 0
        Dim bayar_sisa As Decimal = 0
        Dim object_tax As Decimal = 0

        Dim jumlah_awal_ada As Decimal = 0
        Dim bayar_artis_ada As Decimal = 0
        Dim bayar_pajak_ada As Decimal = 0
        Dim bayar_total_ada As Decimal = 0
        Dim bayar_sisa_ada As Decimal = 0
        Dim persen_ada As Integer
        Dim object_tax_ada As Decimal = 0

        Dim persens(10) As Integer
        Dim minimal(10) As Decimal
        Dim maksimal(10) As Decimal
        Dim quota(10) As Decimal
        Dim z As Integer
        Dim sisa_quota As Decimal = 0


        Dim Looping As Integer

        tbl_pajak_pph21.Clear()

        Me.DataFill(tbl_pajak_pph21, "ms_MstPajakPph21_Select", "")
        For z = 0 To tbl_pajak_pph21.Rows.Count - 1
            persens(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("persen"), 0)
            minimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("minimal"), 0)
            maksimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("maksimal"), 0)
            quota(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("quota"), 0)
        Next

        requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rowIndex).Item("asset_harga")
        requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rowIndex).Item("asset_valas")
        requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rowIndex).Item("asset_qty")
        requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rowIndex).Item("asset_lineinduk")

        Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

        temp_perhitungan = tbl_master_artisdetil.Rows(0).Item("total_amount_pertahun")

        persen = clsUtil.IsDbNull(tbl_master_artisdetil.Rows(0).Item("persen"), 0)

        jumlah_awal_ada = temp_perhitungan
        bayar_sisa_ada = ((Temp_subtotal * 0.5) + temp_perhitungan)
        object_tax_ada = bayar_sisa_ada
        If temp_perhitungan < maksimal(0) Then
            If bayar_sisa_ada <= maksimal(0) Then
                Looping = 1
            ElseIf bayar_sisa_ada <= maksimal(1) Then
                Looping = 2
            ElseIf bayar_sisa_ada <= maksimal(2) Then
                Looping = 3
            ElseIf bayar_sisa_ada > maksimal(2) Then
                Looping = 4
            End If
        ElseIf temp_perhitungan < maksimal(1) Then
            If bayar_sisa_ada <= maksimal(1) Then
                Looping = 1
            ElseIf bayar_sisa_ada <= maksimal(2) Then
                Looping = 2
            ElseIf bayar_sisa_ada > maksimal(2) Then
                Looping = 3
            End If
        ElseIf temp_perhitungan < maksimal(2) Then
            If bayar_sisa_ada <= maksimal(2) Then
                Looping = 1
            ElseIf bayar_sisa_ada > maksimal(2) Then
                Looping = 2
            End If
        ElseIf temp_perhitungan >= maksimal(2) Then
            Looping = 1
        End If

        For g = 0 To Looping - 1
            If temp_perhitungan < maksimal(0) Then
                If jumlah_awal_ada <= maksimal(0) Then
                    If bayar_sisa_ada > maksimal(0) Then
                        bayar_sisa_ada = maksimal(0) - temp_perhitungan
                        bayar_pajak_ada = (maksimal(0) - temp_perhitungan) * (persens(0) / 100)
                        bayar_artis_ada = (maksimal(0) - temp_perhitungan) - ((maksimal(0) - temp_perhitungan) * (persens(0) / 100))
                        bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                        persen_ada = persens(0)
                        jumlah_awal_ada = 50000001
                        bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada 'object_tax_ada - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                    Else
                        bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(0) / 100) 'bayar_sisa_ada * (persens(0) / 100) ''''Temp_subtotal * (persens(0) / 100)
                        bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(0) / 100)) '(bayar_sisa_ada * (persens(0) / 100)) ''''(Temp_subtotal * (persens(0) / 100))
                        bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(0)
                        sisa_quota = maksimal(0) - ((Temp_subtotal * 0.5) + temp_perhitungan)
                        ' ''sisa_quota = maksimal(0) - ((bayar_total_ada * 0.5) + temp_perhitungan)
                    End If

                ElseIf jumlah_awal_ada <= maksimal(1) Then
                    If bayar_sisa_ada > quota(1) Then
                        bayar_sisa_ada = bayar_sisa_ada - quota(1)
                        bayar_pajak_ada += quota(1) * (persens(1) / 100)
                        bayar_artis_ada += quota(1) - (quota(1) * (persens(1) / 100))
                        jumlah_awal_ada = minimal(2)
                        persen_ada = persens(1)
                    Else
                        bayar_pajak_ada += bayar_sisa_ada * (persens(1) / 100)
                        bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(1) / 100)) - temp_perhitungan) ''''bayar_sisa_ada - (bayar_sisa_ada * (persens(2) / 100))
                        ' ''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(1) / 100)) '((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(1) / 100)) - temp_perhitungan) ''''bayar_sisa_ada - (bayar_sisa_ada * (persens(1) / 100))
                        bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(1)
                        sisa_quota = maksimal(1) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                        ' ''sisa_quota = maksimal(1) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                    End If

                ElseIf jumlah_awal_ada <= maksimal(2) Then
                    If bayar_sisa_ada > quota(2) Then
                        bayar_sisa_ada = bayar_sisa_ada - quota(2)
                        bayar_pajak_ada += quota(2) * (persens(2) / 100)
                        bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                        jumlah_awal_ada = minimal(3)
                        persen_ada = persens(2)
                    Else
                        bayar_pajak_ada += bayar_sisa_ada * (persens(2) / 100)
                        bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(2) / 100)) - temp_perhitungan) ''''bayar_sisa_ada - (bayar_sisa_ada * (persens(2) / 100))
                        bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(2)
                        sisa_quota = maksimal(2) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                    End If

                ElseIf jumlah_awal_ada > maksimal(2) Then
                    bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                    bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(3) / 100)) - temp_perhitungan) ''''bayar_sisa_ada - (bayar_sisa_ada * (persens(3) / 100))
                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                    jumlah_awal_ada = bayar_total_ada
                    persen_ada = persens(3)
                    sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                End If

            ElseIf temp_perhitungan < maksimal(1) Then
                If jumlah_awal_ada <= maksimal(1) Then
                    If bayar_sisa_ada > maksimal(1) Then
                        bayar_sisa_ada = maksimal(1) - temp_perhitungan
                        bayar_pajak_ada = (maksimal(1) - temp_perhitungan) * (persens(1) / 100)
                        bayar_artis_ada = (maksimal(1) - temp_perhitungan) - ((maksimal(1) - temp_perhitungan) * (persens(1) / 100))
                        bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                        persen_ada = persens(1)
                        jumlah_awal_ada = minimal(2)
                        bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada
                    Else
                        bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(1) / 100)
                        bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(1) / 100))
                        bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(1)
                        sisa_quota = maksimal(1) - ((Temp_subtotal * 0.5) + temp_perhitungan) ''''(Temp_subtotal + temp_perhitungan)
                    End If
                ElseIf jumlah_awal_ada <= maksimal(2) Then
                    If bayar_sisa_ada > quota(2) Then
                        bayar_sisa_ada = bayar_sisa_ada - quota(2)
                        bayar_pajak_ada += quota(2) * (persens(2) / 100)
                        bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                        jumlah_awal_ada = minimal(3)
                        persen_ada = persens(2)
                    Else
                        bayar_pajak_ada += bayar_sisa_ada * (persens(2) / 100)
                        bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(2) / 100)) - temp_perhitungan)
                        ' ''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(2) / 100))
                        bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(2)
                        sisa_quota = maksimal(2) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                    End If

                ElseIf jumlah_awal_ada > maksimal(2) Then
                    bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                    bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(3) / 100))
                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                    jumlah_awal_ada = bayar_total_ada
                    persen_ada = persens(3)
                    sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                End If

            ElseIf temp_perhitungan < maksimal(2) Then
                If jumlah_awal_ada <= maksimal(2) Then
                    If bayar_sisa_ada > maksimal(2) Then
                        bayar_sisa_ada = maksimal(2) - temp_perhitungan
                        bayar_pajak_ada = (maksimal(2) - temp_perhitungan) * (persens(2) / 100)
                        bayar_artis_ada = (maksimal(2) - temp_perhitungan) - ((maksimal(2) - temp_perhitungan) * (persens(2) / 100))
                        bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                        persen_ada = persens(2)
                        jumlah_awal_ada = minimal(3)
                        bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada
                    Else
                        bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(2) / 100)
                        bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(2) / 100))
                        bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                        jumlah_awal_ada = bayar_total_ada
                        persen_ada = persens(2)
                        sisa_quota = maksimal(2) - ((Temp_subtotal * 0.5) + temp_perhitungan) ''''(Temp_subtotal + temp_perhitungan)
                    End If
                ElseIf jumlah_awal_ada > maksimal(2) Then
                    bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                    bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(3) / 100))
                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                    jumlah_awal_ada = bayar_total_ada
                    persen_ada = persens(3)
                    sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                End If

            ElseIf temp_perhitungan >= maksimal(2) Then
                bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(3) / 100)
                bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(3) / 100))
                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                jumlah_awal_ada = bayar_total_ada
                persen_ada = persens(3)
                sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
            End If
        Next

        Try
            dbConn.Open()
            Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Insert", dbConn)
            oCm.CommandType = CommandType.StoredProcedure
            oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = table_order.Rows(0).Item("item_id")
            oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = clsUtil.IsDbNull(tbl_master_artisdetil.Rows(0).Item("line"), 0) + 10
            oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("kategori_pajak")
            oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("type_pajak")
            oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = table_order.Rows(0).Item("amount_talent")
            oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_pajak_ada
            oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total_ada
            oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total_ada
            oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_artis_ada
            oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
            oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
            oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = DBNull.Value
            oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = String.Empty
            oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = persen_ada
            oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = sisa_quota
            oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_master_artisdetil.Rows(0).Item("total_amount_pertahun") + (bayar_total_ada * 0.5)
            oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
            oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = table_order.Rows(0).Item("order_id")
            oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = table_order.Rows(0).Item("orderdetil_line")

            oCm.ExecuteNonQuery()
            oCm.Dispose()
        Catch ex As Data.OleDb.OleDbException
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dbConn.Close()
        End Try
    End Function
#End Region
    Private Sub hitung_pajak_artis(ByVal total_qty As Integer)
        Dim rows_debet As Integer
        Dim order_id As String
        Dim tbl_orderTemp As DataTable = New DataTable
        Dim table_mstArtisDetil As DataTable = New DataTable
        Dim tbl_master_artisdetil As DataTable = New DataTable
        Dim tblUsage As DataTable = New DataTable
        Dim total_usage As Integer = 0
        Dim q As Integer = 0
        Dim criteria As String = String.Empty

        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim tbl_pajak_pph21 As DataTable = New DataTable
        Dim row_index, g As Integer
        Dim requestdetil_foreignreal, requestdetil_foreignrate, requestdetil_qty, requestdetil_eps As Decimal
        Dim Temp_subtotal As Decimal
        Dim persen As Integer
        Dim temp_perhitungan As Decimal
        Dim pajak_pph23_grossUP_total As Decimal

        Dim jumlah_awal As Decimal = 0
        Dim jumlah_sisa As Decimal = 0
        Dim bayar_artis As Decimal = 0
        Dim bayar_pajak As Decimal = 0
        Dim bayar_total As Decimal = 0
        Dim bayar_sisa As Decimal = 0
        Dim pajak_gross As Decimal = 0
        Dim amountWithTax As Decimal = 0
        Dim object_tax As Decimal = 0

        Dim jumlah_awal_ada As Decimal = 0
        Dim bayar_artis_ada As Decimal = 0
        Dim bayar_pajak_ada As Decimal = 0
        Dim bayar_total_ada As Decimal = 0
        Dim bayar_sisa_ada As Decimal = 0
        Dim pajak_gross_ada As Decimal = 0
        Dim amountWithTax_ada As Decimal = 0
        Dim persen_ada As Integer
        Dim object_tax_ada As Decimal = 0

        Dim persens(10) As Integer
        Dim minimal(10) As Decimal
        Dim maksimal(10) As Decimal
        Dim quota(10) As Decimal
        Dim sisa_quota As Decimal = 0
        Dim tax As Decimal = 0
        Dim z As Integer

        Dim Looping As Integer

        If Mid(Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("order_id").Value, 1, 2) = "TO" Then
            ' ''Me.tbl_TrnTerimabarangdetil.Clear()
            ' ''Me.DataFill(Me.tbl_TrnTerimabarangdetil, "as_TrnTerimabarangdetil_Select", String.Format(" AND terimabarang_id = '{0}'", Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value), Me._CHANNEL, 100%)
            If Me.tbl_TrnTerimabarangdetil.Rows.Count > 0 Then

                tbl_pajak_pph21.Clear()
                Me.DataFill(tbl_pajak_pph21, "ms_MstPajakPph21_Select", "")
                For z = 0 To tbl_pajak_pph21.Rows.Count - 1
                    persens(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("persen"), 0)
                    minimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("minimal"), 0)
                    maksimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("maksimal"), 0)
                    quota(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("quota"), 0)
                Next

                For rows_debet = 0 To Me.tbl_TrnTerimabarangdetil.Rows.Count - 1
                    jumlah_awal = 0
                    jumlah_sisa = 0
                    bayar_artis = 0
                    bayar_pajak = 0
                    bayar_total = 0
                    bayar_sisa = 0
                    pajak_gross = 0
                    amountWithTax = 0
                    object_tax = 0

                    jumlah_awal_ada = 0
                    bayar_artis_ada = 0
                    bayar_pajak_ada = 0
                    bayar_total_ada = 0
                    bayar_sisa_ada = 0
                    pajak_gross_ada = 0
                    amountWithTax_ada = 0
                    object_tax_ada = 0

                    order_id = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("order_id")
                    criteria = String.Format(" order_id = '{0}' AND orderdetil_line = {1} ", order_id, Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("orderdetil_line"))
                    tbl_orderTemp.Clear()
                    Me.DataFill(tbl_orderTemp, "to_TrnOrderdetil_Select", criteria)
                    table_mstArtisDetil.Clear()
                    Me.DataFill(table_mstArtisDetil, "ms_MstArtisdetil_Select", String.Format(" code = '{0}' order by line desc", tbl_orderTemp.Rows(0).Item("item_id")))

                    If tbl_orderTemp.Rows(0).Item("kategori_pajak") = 2 Then
                        If tbl_orderTemp.Rows(0).Item("type_pajak") = 1 Then
                            '================= Untuk PPH21 Potong =======================================
                            If table_mstArtisDetil.Rows.Count = 0 Then
                                ' ============= Untuk yang belum ada di table =====================

                                requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                ' ''requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                ' ''requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * total_qty)

                                bayar_sisa = (Temp_subtotal * 0.5) ''''Temp_subtotal
                                object_tax = bayar_sisa ''''(Temp_subtotal * 0.5)
                                If bayar_sisa <= maksimal(0) Then
                                    Looping = 1
                                ElseIf bayar_sisa <= maksimal(1) Then
                                    Looping = 2
                                ElseIf bayar_sisa <= maksimal(2) Then
                                    Looping = 3
                                ElseIf bayar_sisa > maksimal(2) Then
                                    Looping = 4
                                End If

                                For row_index = 0 To Looping - 1
                                    If jumlah_awal <= maksimal(0) Then
                                        If bayar_sisa > quota(0) Then
                                            bayar_sisa = bayar_sisa - quota(0)
                                            bayar_pajak = (quota(0) * (persens(0) / 100))
                                            bayar_artis = quota(0) - (quota(0) * (persens(0) / 100))
                                            bayar_total = bayar_pajak + bayar_artis
                                            persen = 5
                                            jumlah_awal = minimal(1)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(0) / 100)
                                            bayar_artis += Temp_subtotal - (bayar_sisa * (persens(0) / 100))
                                            bayar_total = bayar_pajak + bayar_artis
                                            jumlah_awal = bayar_total
                                            persen = persens(0)
                                            sisa_quota = maksimal(0) - (Temp_subtotal * 0.5) 'bayar_total
                                        End If
                                    ElseIf jumlah_awal <= maksimal(1) Then
                                        If bayar_sisa > quota(1) Then
                                            bayar_sisa = bayar_sisa - quota(1)
                                            bayar_pajak += quota(1) * (persens(1) / 100)
                                            bayar_artis += quota(1) - (quota(1) * (persens(1) / 100))
                                            jumlah_awal = minimal(2)
                                            persen = persens(1)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(1) / 100)
                                            bayar_artis += (bayar_sisa + object_tax) - (bayar_sisa * (persens(1) / 100)) ''''bayar_sisa - (bayar_sisa * (persens(1) / 100))
                                            bayar_total = bayar_pajak + bayar_artis
                                            jumlah_awal = bayar_total
                                            persen = persens(1)
                                            sisa_quota = maksimal(1) - (Temp_subtotal * 0.5) ''''bayar_total
                                        End If
                                    ElseIf jumlah_awal <= maksimal(2) Then
                                        If bayar_sisa > quota(2) Then
                                            bayar_sisa = bayar_sisa - quota(2)
                                            bayar_pajak += quota(2) * (persens(2) / 100)
                                            bayar_artis += quota(2) - (quota(2) * (persens(2) / 100))
                                            jumlah_awal = minimal(3)
                                            persen = persens(2)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(2) / 100)
                                            bayar_artis += (bayar_sisa + object_tax) - (bayar_sisa * (persens(2) / 100)) ''''bayar_sisa - (bayar_sisa * (persens(2) / 100))
                                            bayar_total = bayar_pajak + bayar_artis
                                            jumlah_awal = bayar_total
                                            persen = persens(2)
                                            sisa_quota = maksimal(2) - (Temp_subtotal * 0.5) ''''bayar_total
                                        End If
                                    ElseIf jumlah_awal > maksimal(2) Then
                                        bayar_pajak += bayar_sisa * (persens(3) / 100)
                                        bayar_artis += (bayar_sisa + object_tax) - (bayar_sisa * (persens(3) / 100)) ''''bayar_sisa - (bayar_sisa * (persens(3) / 100))
                                        bayar_total = bayar_pajak + bayar_artis
                                        jumlah_awal = bayar_total
                                        persen = persens(3)
                                        sisa_quota = maksimal(2) + (Temp_subtotal * 0.5) ''''bayar_total
                                    End If
                                Next

                                Try
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") = 0 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") = bayar_pajak 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc") = 0 'tbl_retOrder.Rows(0).Item("orderdetil_discount")
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_idrprice") = bayar_artis 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc"))

                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try

                                Me.uiTrnTerimaJasa_Save()


                                ' ============= Akhir Untuk yang belum ada di table =====================

                            Else

                                requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                                Me.DataFill(tbl_master_artisdetil, "ms_MstArtisdetilSUM_Select", String.Format("code = '{0}' ", tbl_orderTemp.Rows(0).Item("item_id")))
                                temp_perhitungan = tbl_master_artisdetil.Rows(0).Item("total_50persen")

                                jumlah_awal_ada = temp_perhitungan
                                bayar_sisa_ada = ((Temp_subtotal * 0.5) + temp_perhitungan)
                                object_tax_ada = bayar_sisa_ada
                                If temp_perhitungan < maksimal(0) Then
                                    If bayar_sisa_ada <= maksimal(0) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada <= maksimal(1) Then
                                        Looping = 2
                                    ElseIf bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 3
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 4
                                    End If
                                ElseIf temp_perhitungan < maksimal(1) Then
                                    If bayar_sisa_ada <= maksimal(1) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 2
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 3
                                    End If
                                ElseIf temp_perhitungan < maksimal(2) Then
                                    If bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 2
                                    End If
                                ElseIf temp_perhitungan >= maksimal(2) Then
                                    Looping = 1
                                End If

                                For g = 0 To Looping - 1
                                    If temp_perhitungan < maksimal(0) Then
                                        If jumlah_awal_ada <= maksimal(0) Then
                                            If bayar_sisa_ada > maksimal(0) Then
                                                bayar_sisa_ada = maksimal(0) - temp_perhitungan
                                                bayar_pajak_ada = (maksimal(0) - temp_perhitungan) * (persens(0) / 100)
                                                bayar_artis_ada = (maksimal(0) - temp_perhitungan) - ((maksimal(0) - temp_perhitungan) * (persens(0) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                persen_ada = persens(0)
                                                jumlah_awal_ada = 50000001
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada 'object_tax_ada - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(0) / 100) 'bayar_sisa_ada * (persens(0) / 100) ''''Temp_subtotal * (persens(0) / 100)
                                                bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(0) / 100)) '(bayar_sisa_ada * (persens(0) / 100)) ''''(Temp_subtotal * (persens(0) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(0)
                                                sisa_quota = maksimal(0) - ((bayar_total_ada * 0.5) + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada <= maksimal(1) Then
                                            If bayar_sisa_ada > quota(1) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(1)
                                                bayar_pajak_ada += quota(1) * (persens(1) / 100)
                                                bayar_artis_ada += quota(1) - (quota(1) * (persens(1) / 100))
                                                jumlah_awal_ada = minimal(2)
                                                persen_ada = persens(1)
                                            Else
                                                bayar_pajak_ada += bayar_sisa_ada * (persens(1) / 100)
                                                ''''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(1) / 100)) '((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(1) / 100)) - temp_perhitungan) ''''bayar_sisa_ada - (bayar_sisa_ada * (persens(1) / 100))
                                                bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(1) / 100)) - temp_perhitungan)
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(1)
                                                sisa_quota = maksimal(1) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > quota(2) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                bayar_pajak_ada += quota(2) * (persens(2) / 100)
                                                bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                                                jumlah_awal_ada = minimal(3)
                                                persen_ada = persens(2)
                                            Else
                                                bayar_pajak_ada += bayar_sisa_ada * (persens(2) / 100)
                                                bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(2) / 100)) - temp_perhitungan)
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)
                                                sisa_quota = maksimal(2) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                                            bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(3) / 100)) - temp_perhitungan)
                                            bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                        End If

                                    ElseIf temp_perhitungan < maksimal(1) Then
                                        If jumlah_awal_ada <= maksimal(1) Then
                                            If bayar_sisa_ada > maksimal(1) Then
                                                bayar_sisa_ada = maksimal(1) - temp_perhitungan
                                                bayar_pajak_ada = (maksimal(1) - temp_perhitungan) * (persens(1) / 100)
                                                bayar_artis_ada = (maksimal(1) - temp_perhitungan) - ((maksimal(1) - temp_perhitungan) * (persens(1) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                persen_ada = persens(1)
                                                jumlah_awal_ada = minimal(2)
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(1) / 100)
                                                bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(1) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(1)
                                                sisa_quota = maksimal(1) - ((Temp_subtotal * 0.5) + temp_perhitungan) ''''(Temp_subtotal + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > quota(2) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                bayar_pajak_ada += quota(2) * (persens(2) / 100)
                                                bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                                                jumlah_awal_ada = minimal(3)
                                                persen_ada = persens(2)
                                            Else
                                                bayar_pajak_ada += bayar_sisa_ada * (persens(2) / 100)
                                                ''''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(2) / 100))
                                                bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(2) / 100)) - temp_perhitungan)
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)
                                                sisa_quota = maksimal(2) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                                            '' ''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(3) / 100))
                                            bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(3) / 100)) - temp_perhitungan)
                                            bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                        End If

                                    ElseIf temp_perhitungan < maksimal(2) Then
                                        If jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > maksimal(2) Then
                                                bayar_sisa_ada = maksimal(2) - temp_perhitungan
                                                bayar_pajak_ada = (maksimal(2) - temp_perhitungan) * (persens(2) / 100)
                                                bayar_artis_ada = (maksimal(2) - temp_perhitungan) - ((maksimal(2) - temp_perhitungan) * (persens(2) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                persen_ada = persens(2)
                                                jumlah_awal_ada = minimal(3)
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(2) / 100)
                                                bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(2) / 100))
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)
                                                sisa_quota = maksimal(2) - ((Temp_subtotal * 0.5) + temp_perhitungan) ''''(Temp_subtotal + temp_perhitungan)
                                            End If
                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                                            '' ''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(3) / 100))
                                            bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(3) / 100)) - temp_perhitungan)
                                            bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                        End If
                                    ElseIf temp_perhitungan >= maksimal(2) Then
                                        bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(3) / 100)
                                        bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(3) / 100))
                                        bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                        jumlah_awal_ada = bayar_total_ada
                                        persen_ada = persens(3)
                                        sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                    End If
                                Next

                                Try
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") = 0 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") = bayar_pajak_ada 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc") = 0 'tbl_retOrder.Rows(0).Item("orderdetil_discount")
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_idrprice") = bayar_artis_ada 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc"))

                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try

                                Me.uiTrnTerimaJasa_Save()
                                ' ============= Akhir Untuk yang udah ada di table =====================
                            End If
                            '================= Akhir Untuk PPH21 Potong =======================================
                        Else
                            '================= Untuk PPH21 Gross UP =======================================
                            If table_mstArtisDetil.Rows.Count = 0 Then
                                ' ============= Untuk yang belum ada di table =====================
                                requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                                bayar_sisa = (Temp_subtotal * 0.5)
                                object_tax = bayar_sisa

                                If bayar_sisa <= maksimal(0) Then
                                    Looping = 1
                                ElseIf bayar_sisa <= maksimal(1) Then
                                    Looping = 2
                                ElseIf bayar_sisa <= maksimal(2) Then
                                    Looping = 3
                                ElseIf bayar_sisa > maksimal(2) Then
                                    Looping = 4
                                End If

                                For row_index = 0 To Looping - 1
                                    If jumlah_awal <= maksimal(0) Then
                                        If bayar_sisa > quota(0) Then
                                            bayar_sisa = bayar_sisa - quota(0)
                                            bayar_pajak = quota(0) * (persens(0) / 100)
                                            bayar_artis = quota(0) '- (quota(0) * (persens(0) / 100))
                                            'bayar_total = bayar_pajak + bayar_artis
                                            persen = 5
                                            jumlah_awal = minimal(1)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(0) / 100)
                                            pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(0))), MidpointRounding.ToEven)
                                            bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                            amountWithTax = bayar_artis - pajak_gross
                                            bayar_total = pajak_gross + bayar_artis
                                            jumlah_awal = bayar_total
                                            persen = persens(0)
                                            sisa_quota = maksimal(0) - ((Temp_subtotal * 0.5) + pajak_gross)  ''''bayar_total
                                        End If

                                    ElseIf jumlah_awal <= maksimal(1) Then
                                        If bayar_sisa > quota(1) Then
                                            bayar_sisa = bayar_sisa - quota(1)
                                            bayar_pajak += quota(1) * (persens(1) / 100)
                                            bayar_artis += quota(1) '- (quota(1) * (persens(1) / 100))
                                            jumlah_awal = minimal(2)
                                            persen = persens(1)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(1) / 100)
                                            pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(1))), MidpointRounding.ToEven)
                                            bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                            amountWithTax = bayar_artis - pajak_gross
                                            bayar_total = pajak_gross + bayar_artis

                                            sisa_quota = maksimal(1) - ((Temp_subtotal * 0.5) + pajak_gross) ''''bayar_total
                                            jumlah_awal = bayar_total
                                            persen = persens(1)
                                        End If

                                    ElseIf jumlah_awal <= maksimal(2) Then
                                        If bayar_sisa > quota(2) Then
                                            bayar_sisa = bayar_sisa - quota(2)
                                            bayar_pajak += quota(2) * (persens(2) / 100)
                                            bayar_artis += quota(2) '- (quota(2) * (persens(2) / 100))
                                            jumlah_awal = minimal(3)
                                            persen = persens(2)
                                        Else
                                            bayar_pajak += bayar_sisa * (persens(2) / 100)
                                            pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                            bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                            amountWithTax = bayar_artis - pajak_gross
                                            bayar_total = pajak_gross + bayar_artis
                                            jumlah_awal = bayar_total
                                            persen = persens(2)

                                            sisa_quota = maksimal(2) - ((Temp_subtotal * 0.5) + pajak_gross) ''''bayar_total
                                        End If

                                    ElseIf jumlah_awal > maksimal(2) Then
                                        bayar_pajak += bayar_sisa * (persens(3) / 100)
                                        pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                        bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                        amountWithTax = bayar_artis - pajak_gross
                                        bayar_total = pajak_gross + bayar_artis

                                        jumlah_awal = bayar_total
                                        persen = persens(3)
                                        sisa_quota = maksimal(2) + ((Temp_subtotal * 0.5) + pajak_gross) ''''bayar_total
                                    End If
                                Next
                                Try
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") = 0 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") = pajak_gross 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc") = 0 'tbl_retOrder.Rows(0).Item("orderdetil_discount")
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_idrprice") = Temp_subtotal 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc"))

                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try

                                Me.uiTrnTerimaJasa_Save()
                                ' ============= Akhir yang belum ada di table =====================
                            Else
                                ' ============= Untuk yang udah ada di table =====================
                                requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                                Me.DataFill(tbl_master_artisdetil, "ms_MstArtisdetilSUM_Select", String.Format("code = '{0}' ", tbl_orderTemp.Rows(0).Item("item_id")))
                                temp_perhitungan = tbl_master_artisdetil.Rows(0).Item("total_50persen")

                                jumlah_awal_ada = temp_perhitungan
                                ''''bayar_sisa_ada = (Temp_subtotal + temp_perhitungan)
                                bayar_sisa_ada = ((Temp_subtotal * 0.5) + temp_perhitungan)
                                object_tax_ada = bayar_sisa_ada

                                If temp_perhitungan < maksimal(0) Then
                                    If bayar_sisa_ada <= maksimal(0) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada <= maksimal(1) Then
                                        Looping = 2
                                    ElseIf bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 3
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 4
                                    End If

                                ElseIf temp_perhitungan < maksimal(1) Then
                                    If bayar_sisa_ada <= maksimal(1) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 2
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 3
                                    End If

                                ElseIf temp_perhitungan < maksimal(2) Then
                                    If bayar_sisa_ada <= maksimal(2) Then
                                        Looping = 1
                                    ElseIf bayar_sisa_ada > maksimal(2) Then
                                        Looping = 2
                                    End If

                                ElseIf temp_perhitungan >= maksimal(2) Then
                                    Looping = 1
                                End If

                                For g = 0 To Looping - 1
                                    If temp_perhitungan < maksimal(0) Then

                                        If jumlah_awal_ada <= maksimal(0) Then
                                            If bayar_sisa_ada > maksimal(0) Then
                                                bayar_sisa_ada = maksimal(0) - temp_perhitungan
                                                bayar_pajak_ada = Math.Round((maksimal(0) - temp_perhitungan) * (persens(0) / 100), MidpointRounding.ToEven)

                                                persen_ada = persens(0)
                                                jumlah_awal_ada = 50000001
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(0) / 100), MidpointRounding.ToEven) ''''Math.Round(Temp_subtotal * (persens(0) / 100), MidpointRounding.ToEven)
                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(0))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal

                                                sisa_quota = maksimal(0) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) '(Temp_subtotal  + temp_perhitungan)
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(0)
                                            End If

                                        ElseIf jumlah_awal_ada <= maksimal(1) Then
                                            If bayar_sisa_ada > quota(1) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(1)
                                                bayar_pajak_ada += Math.Round(quota(1) * (persens(1) / 100), MidpointRounding.ToEven)

                                                jumlah_awal_ada = minimal(2)
                                                persen_ada = persens(1)
                                            Else
                                                bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(1) / 100), MidpointRounding.ToEven)
                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(1))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal

                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(1)
                                                sisa_quota = maksimal(1) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(1) - (bayar_total_ada + temp_perhitungan)
                                            End If

                                        ElseIf jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > quota(2) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                bayar_pajak_ada += Math.Round(quota(2) * (persens(2) / 100), MidpointRounding.ToEven)

                                                jumlah_awal_ada = minimal(3)
                                                persen_ada = persens(2)
                                            Else
                                                bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(2) / 100), MidpointRounding.ToEven)

                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)

                                                sisa_quota = maksimal(2) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) - (bayar_total_ada + temp_perhitungan)
                                            End If

                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                                            pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                            amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                            bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''  maksimal(2) + bayar_sisa_ada
                                        End If

                                    ElseIf temp_perhitungan < maksimal(1) Then
                                        If jumlah_awal_ada <= maksimal(1) Then
                                            If bayar_sisa_ada > maksimal(1) Then
                                                bayar_sisa_ada = maksimal(1) - temp_perhitungan
                                                bayar_pajak_ada = Math.Round((maksimal(1) - temp_perhitungan) * (persens(1) / 100), MidpointRounding.ToEven)

                                                persen_ada = persens(1)
                                                jumlah_awal_ada = minimal(2)
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(1) / 100), MidpointRounding.ToEven) ''''Math.Round((Temp_subtotal) * (persens(1) / 100), MidpointRounding.ToEven)

                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(1))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(1)
                                                sisa_quota = maksimal(1) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(1) - (Temp_subtotal + temp_perhitungan)
                                            End If

                                        ElseIf jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > quota(2) Then
                                                bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                bayar_pajak_ada += Math.Round(quota(2) * (persens(2) / 100), MidpointRounding.ToEven)
                                                'bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                                                jumlah_awal_ada = minimal(3)
                                                persen_ada = persens(2)
                                            Else
                                                bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(2) / 100), MidpointRounding.ToEven)

                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)
                                                sisa_quota = maksimal(2) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) - (bayar_total_ada + temp_perhitungan)
                                            End If

                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                                            pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                            amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                            bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                        End If

                                    ElseIf temp_perhitungan < maksimal(2) Then
                                        If jumlah_awal_ada <= maksimal(2) Then
                                            If bayar_sisa_ada > maksimal(2) Then
                                                bayar_sisa_ada = maksimal(2) - temp_perhitungan
                                                bayar_pajak_ada = Math.Round((maksimal(2) - temp_perhitungan) * (persens(2) / 100), MidpointRounding.ToEven)

                                                persen_ada = persens(2)
                                                jumlah_awal_ada = minimal(3)
                                                bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                            Else
                                                bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(2) / 100), MidpointRounding.ToEven) ''''Temp_subtotal * (persens(2) / 100)
                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(2)
                                                sisa_quota = maksimal(2) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) - (Temp_subtotal + temp_perhitungan)
                                            End If

                                        ElseIf jumlah_awal_ada > maksimal(2) Then
                                            bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                                            pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                            amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                            bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) + (bayar_total_ada + temp_perhitungan)
                                        End If

                                    ElseIf temp_perhitungan >= maksimal(2) Then
                                        bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(3) / 100), MidpointRounding.ToEven) ''''Temp_subtotal * (persens(3) / 100)
                                        pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                        amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                        bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                        jumlah_awal_ada = bayar_total_ada
                                        persen_ada = persens(3)
                                        sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) + (bayar_total_ada + temp_perhitungan)
                                    End If
                                Next
                                Try
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") = 0 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") = pajak_gross_ada 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc") = 0 'tbl_retOrder.Rows(0).Item("orderdetil_discount")
                                    Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_idrprice") = Temp_subtotal 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc"))

                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try

                                Me.uiTrnTerimaJasa_Save()
                                ' ============= Akhir yang udah ada di table =====================
                            End If
                            '================= Akhir Untuk PPH21 Gross UP =======================================
                        End If

                    ElseIf tbl_orderTemp.Rows(0).Item("kategori_pajak") = 3 Or tbl_orderTemp.Rows(0).Item("kategori_pajak") = 4 Then
                        '===================== Untuk PPh23 dan PPh23 Royalti ===================================================
                        If tbl_orderTemp.Rows(0).Item("type_pajak") = 1 Then
                            requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                            requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                            ' ''requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                            ' ''requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                            Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * total_qty)
                            Try
                                Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") = 0 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                                Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") = Temp_subtotal * Val(tbl_orderTemp.Rows(0).Item("orderdetil_pphpercent") / 100) 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                                Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc") = 0 'tbl_retOrder.Rows(0).Item("orderdetil_discount")
                                Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_idrprice") = Temp_subtotal - (Temp_subtotal * Val(tbl_orderTemp.Rows(0).Item("orderdetil_pphpercent") / 100)) 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc"))

                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try

                            Me.uiTrnTerimaJasa_Save()
                            'dipotong

                        ElseIf tbl_orderTemp.Rows(0).Item("type_pajak") = 2 Then
                            'gross up
                            requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                            requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                            ' ''requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                            ' ''requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                            Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * total_qty)
                            pajak_pph23_grossUP_total = Temp_subtotal + ((Temp_subtotal * (100 / (100 - tbl_orderTemp.Rows(0).Item("orderdetil_pphpercent")))) - Temp_subtotal)

                            Try
                                Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") = 0 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                                Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") = ((Temp_subtotal * (100 / (100 - tbl_orderTemp.Rows(0).Item("orderdetil_pphpercent")))) - Temp_subtotal) 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                                Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc") = 0 'tbl_retOrder.Rows(0).Item("orderdetil_discount")
                                Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_idrprice") = Temp_subtotal 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc"))

                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try

                            Me.uiTrnTerimaJasa_Save()
                        End If

                        '===================== Akhir Untuk PPh23 ===================================================

                    ElseIf tbl_orderTemp.Rows(0).Item("kategori_pajak") = 1 Then
                        'No TAX atau Tidak ada pajak
                        requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                        requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                        ' ''requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                        ' ''requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                        Temp_subtotal = (requestdetil_foreignreal * requestdetil_foreignrate * total_qty)
                        Try
                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn") = 0 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph") = 0 '((Temp_subtotal * (100 / (100 - tbl_orderTemp.Rows(0).Item("orderdetil_pphpercent")))) - Temp_subtotal) 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc") = 0 'tbl_retOrder.Rows(0).Item("orderdetil_discount")
                            Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_idrprice") = Temp_subtotal 'Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_qty")) * Val(clsUtil.IsDbNull(Me.total_days, 1)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_disc"))

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        Me.uiTrnTerimaJasa_Save()
                    End If
                Next


            End If
        End If
    End Sub
    Private Sub obj_Asset_disc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles obj_Asset_disc.TextChanged
        Dim tbl_retOrder As New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)
        Dim criteria As String = String.Empty

        criteria = String.Format(" tor.order_id = '{0}' AND tb.orderdetil_line = {1}", Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("order_id").Value, Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("orderdetil_line").Value)

        tbl_retOrder.Clear()
        Try
            If Me.obj_Asset_disc.Text <> String.Empty And Me.obj_Asset_disc.Text <> "0.00" Then
                If Me.obj_Terimajasa_status.Text = "EO" Then
                    Me.obj_Asset_disc.ReadOnly = False
                    Me.DataFill(tbl_retOrder, "as_TrnOrderDetilJasa_SelectEO", criteria)

                    Me.obj_Asset_pph.Text = ((Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("usage").Value, 0))) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                    Me.obj_Asset_ppn.Text = ((Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("usage").Value, 0))) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                    Me.obj_Asset_idrprice.Text = Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("usage").Value, 0)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))
                ElseIf Me.obj_Terimajasa_status.Text = "MO" Then
                    Me.obj_Asset_disc.ReadOnly = False
                    Me.DataFill(tbl_retOrder, "as_TrnOrderdetilJasa_Select", criteria)

                    Me.obj_Asset_pph.Text = ((Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_qty").Value, 0))) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                    Me.obj_Asset_ppn.Text = ((Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_qty").Value, 0))) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                    Me.obj_Asset_idrprice.Text = Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("asset_qty").Value, 0)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))
                ElseIf Me.obj_Terimajasa_status.Text = "RO" Then
                    Me.obj_Asset_disc.ReadOnly = False
                    Me.DataFill(tbl_retOrder, "as_TrnOrderdetilJasa_Select", criteria)

                    Me.obj_Asset_pph.Text = ((Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("usage").Value, 0))) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))) * Val(tbl_retOrder.Rows(0).Item("orderdetil_pphpercent")) / 100
                    Me.obj_Asset_ppn.Text = ((Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("usage").Value, 0))) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))) * Val(tbl_retOrder.Rows(0).Item("orderdetil_ppnpercent")) / 100
                    Me.obj_Asset_idrprice.Text = Val(tbl_retOrder.Rows(0).Item("orderdetil_foreign")) * Val(tbl_retOrder.Rows(0).Item("orderdetil_foreignrate")) * Val(clsUtil.IsDbNull(Me.DgvTrnTerimajasadetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Cells("usage").Value, 0)) + Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_ppn")) - Val(Me.tbl_TrnTerimabarangdetil.Rows(Me.DgvTrnTerimajasadetil.CurrentRow.Index).Item("asset_pph")) - CDec(clsUtil.IsDbNull(Me.obj_Asset_disc.Text, 0))
                Else
                    Me.obj_Asset_disc.ReadOnly = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub uiTrnTerimaJasa_ReGenerate_pajakArtis()
        Dim x, y As Integer
        Dim tbl_jasaDetil As DataTable = New DataTable
        Dim tbl_artisDetil As DataTable = New DataTable
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSN)

        Dim tbl_orderTemp As DataTable = New DataTable

        Dim tbl_pajak_pph21 As DataTable = New DataTable
        Dim row_index, g As Integer
        Dim Temp_subtotal As Decimal
        Dim persen As Integer
        Dim temp_perhitungan As Decimal

        Dim jumlah_awal As Decimal = 0
        Dim jumlah_sisa As Decimal = 0
        Dim bayar_artis As Decimal = 0
        Dim bayar_pajak As Decimal = 0
        Dim bayar_total As Decimal = 0
        Dim bayar_sisa As Decimal = 0
        Dim pajak_gross As Decimal = 0
        Dim amountWithTax As Decimal = 0
        Dim object_tax As Decimal = 0

        Dim jumlah_awal_ada As Decimal = 0
        Dim bayar_artis_ada As Decimal = 0
        Dim bayar_pajak_ada As Decimal = 0
        Dim bayar_total_ada As Decimal = 0
        Dim bayar_sisa_ada As Decimal = 0
        Dim pajak_gross_ada As Decimal = 0
        Dim amountWithTax_ada As Decimal = 0
        Dim persen_ada As Integer
        Dim object_tax_ada As Decimal = 0

        Dim persens(10) As Integer
        Dim minimal(10) As Decimal
        Dim maksimal(10) As Decimal
        Dim quota(10) As Decimal
        Dim sisa_quota As Decimal = 0
        Dim tax As Decimal = 0
        Dim z As Integer
        Dim total_amount50persen_sementara As Decimal

        Dim Looping As Integer
        Dim artis_id As String = String.Empty
        Dim artis_line As Integer
        Dim tbl_artisDetil_temps As DataTable = New DataTable

        tbl_jasaDetil.Clear()
        Me.DataFill(tbl_jasaDetil, "as_TrnTerimabarangdetilTO_Select", String.Format(" AND terimabarang_id = '{0}'", Me.DgvTrnTerimajasa.Rows(Me.DgvTrnTerimajasa.CurrentRow.Index).Cells("terimabarang_id").Value), Me._CHANNEL, 1)

        tbl_pajak_pph21.Clear()
        Me.DataFill(tbl_pajak_pph21, "ms_MstPajakPph21_Select", "")
        For z = 0 To tbl_pajak_pph21.Rows.Count - 1
            persens(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("persen"), 0)
            minimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("minimal"), 0)
            maksimal(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("maksimal"), 0)
            quota(z) = clsUtil.IsDbNull(tbl_pajak_pph21.Rows(z).Item("quota"), 0)
        Next

        For x = 0 To tbl_jasaDetil.Rows.Count - 1
            tbl_orderTemp.Clear()
            Me.DataFill(tbl_orderTemp, "to_TrnOrderdetil_Select", String.Format(" order_id = '{0}' AND orderdetil_line = {1} ", tbl_jasaDetil.Rows(x).Item("order_id"), tbl_jasaDetil.Rows(x).Item("orderdetil_line")))

            If tbl_orderTemp.Rows.Count > 0 Then
                If tbl_orderTemp.Rows(0).Item("kategori_pajak") = 2 Then
                    tbl_artisDetil.Clear()
                    Me.DataFill(tbl_artisDetil, "ms_MstArtisdetil_Select", String.Format(" order_id = '{0}' AND orderdetil_line = {1} ", tbl_jasaDetil.Rows(x).Item("order_id"), tbl_jasaDetil.Rows(x).Item("orderdetil_line")))
                    Dim cek_ok As String = String.Empty
                    Dim row_artis As Integer = 0

                    artis_id = tbl_artisDetil.Rows(0).Item("code")
                    artis_line = tbl_artisDetil.Rows(0).Item("line")

                    tbl_artisDetil_temps.Clear()
                    Me.DataFill(tbl_artisDetil_temps, "ms_MstArtisdetil_Select", String.Format(" code = '{0}'", artis_id))
                    For y = 0 To tbl_artisDetil_temps.Rows.Count - 1
                        jumlah_awal = 0
                        jumlah_sisa = 0
                        bayar_artis = 0
                        bayar_pajak = 0
                        bayar_total = 0
                        bayar_sisa = 0
                        pajak_gross = 0
                        amountWithTax = 0
                        object_tax = 0

                        jumlah_awal_ada = 0
                        bayar_artis_ada = 0
                        bayar_pajak_ada = 0
                        bayar_total_ada = 0
                        bayar_sisa_ada = 0
                        pajak_gross_ada = 0
                        amountWithTax_ada = 0
                        object_tax_ada = 0

                        row_artis += 1

                        If tbl_artisDetil_temps.Rows(y).Item("code") = artis_id And tbl_artisDetil_temps.Rows(y).Item("line") = artis_line Then
                            Try
                                dbConn.Open()
                                Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Delete", dbConn)
                                oCm.CommandType = CommandType.StoredProcedure
                                oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = artis_id
                                oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = artis_line
                                oCm.ExecuteNonQuery()
                                oCm.Dispose()
                            Catch ex As Data.OleDb.OleDbException
                                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Catch ex As Exception
                                MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally
                                dbConn.Close()
                            End Try

                            cek_ok = "ok"

                        ElseIf cek_ok = "ok" Then
                            If tbl_artisDetil_temps.Rows(y).Item("code_pajak") = 1 Then
                                '================= Untuk PPH21 Potong =======================================
                                If row_artis = 2 Then
                                    'data awal dianggap kosong
                                    ' ============= Untuk yang belum ada di table =====================

                                    ' ''requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                    ' ''requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                    ' ''requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                    ' ''requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                    Temp_subtotal = tbl_artisDetil_temps.Rows(y).Item("amount") '(requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                                    bayar_sisa = (Temp_subtotal * 0.5) ''''Temp_subtotal
                                    object_tax = bayar_sisa ''''(Temp_subtotal * 0.5)
                                    If bayar_sisa <= maksimal(0) Then
                                        Looping = 1
                                    ElseIf bayar_sisa <= maksimal(1) Then
                                        Looping = 2
                                    ElseIf bayar_sisa <= maksimal(2) Then
                                        Looping = 3
                                    ElseIf bayar_sisa > maksimal(2) Then
                                        Looping = 4
                                    End If

                                    For row_index = 0 To Looping - 1
                                        If jumlah_awal <= maksimal(0) Then
                                            If bayar_sisa > quota(0) Then
                                                bayar_sisa = bayar_sisa - quota(0)
                                                bayar_pajak = (quota(0) * (persens(0) / 100))
                                                bayar_artis = quota(0) - (quota(0) * (persens(0) / 100))
                                                bayar_total = bayar_pajak + bayar_artis
                                                persen = 5
                                                jumlah_awal = minimal(1)
                                            Else
                                                bayar_pajak += bayar_sisa * (persens(0) / 100)
                                                bayar_artis += Temp_subtotal - (bayar_sisa * (persens(0) / 100))
                                                bayar_total = bayar_pajak + bayar_artis
                                                jumlah_awal = bayar_total
                                                persen = persens(0)
                                                sisa_quota = maksimal(0) - (Temp_subtotal * 0.5) 'bayar_total
                                            End If
                                        ElseIf jumlah_awal <= maksimal(1) Then
                                            If bayar_sisa > quota(1) Then
                                                bayar_sisa = bayar_sisa - quota(1)
                                                bayar_pajak += quota(1) * (persens(1) / 100)
                                                bayar_artis += quota(1) - (quota(1) * (persens(1) / 100))
                                                jumlah_awal = minimal(2)
                                                persen = persens(1)
                                            Else
                                                bayar_pajak += bayar_sisa * (persens(1) / 100)
                                                bayar_artis += (bayar_sisa + object_tax) - (bayar_sisa * (persens(1) / 100)) ''''bayar_sisa - (bayar_sisa * (persens(1) / 100))
                                                bayar_total = bayar_pajak + bayar_artis
                                                jumlah_awal = bayar_total
                                                persen = persens(1)
                                                sisa_quota = maksimal(1) - (Temp_subtotal * 0.5) ''''bayar_total
                                            End If
                                        ElseIf jumlah_awal <= maksimal(2) Then
                                            If bayar_sisa > quota(2) Then
                                                bayar_sisa = bayar_sisa - quota(2)
                                                bayar_pajak += quota(2) * (persens(2) / 100)
                                                bayar_artis += quota(2) - (quota(2) * (persens(2) / 100))
                                                jumlah_awal = minimal(3)
                                                persen = persens(2)
                                            Else
                                                bayar_pajak += bayar_sisa * (persens(2) / 100)
                                                bayar_artis += (bayar_sisa + object_tax) - (bayar_sisa * (persens(2) / 100)) ''''bayar_sisa - (bayar_sisa * (persens(2) / 100))
                                                bayar_total = bayar_pajak + bayar_artis
                                                jumlah_awal = bayar_total
                                                persen = persens(2)
                                                sisa_quota = maksimal(2) - (Temp_subtotal * 0.5) ''''bayar_total
                                            End If
                                        ElseIf jumlah_awal > maksimal(2) Then
                                            bayar_pajak += bayar_sisa * (persens(3) / 100)
                                            bayar_artis += (bayar_sisa + object_tax) - (bayar_sisa * (persens(3) / 100)) ''''bayar_sisa - (bayar_sisa * (persens(3) / 100))
                                            bayar_total = bayar_pajak + bayar_artis
                                            jumlah_awal = bayar_total
                                            persen = persens(3)
                                            sisa_quota = maksimal(2) + (Temp_subtotal * 0.5) ''''bayar_total
                                        End If
                                    Next
                                    Try
                                        dbConn.Open()
                                        Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Update", dbConn)
                                        oCm.CommandType = CommandType.StoredProcedure
                                        oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_artisDetil_temps.Rows(y).Item("code")
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_artisDetil_temps.Rows(y).Item("line")
                                        oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_artisDetil_temps.Rows(y).Item("category_id")
                                        oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_artisDetil_temps.Rows(y).Item("code_pajak")
                                        oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                        oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_pajak
                                        oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                        oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total
                                        oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_artis
                                        oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                                        oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                                        oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                                        oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                                        oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = persen
                                        oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = sisa_quota
                                        oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total * 0.5
                                        oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
                                        oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_artisDetil_temps.Rows(y).Item("order_id")
                                        oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_artisDetil_temps.Rows(y).Item("orderdetil_line")

                                        oCm.ExecuteNonQuery()
                                        oCm.Dispose()
                                    Catch ex As Data.OleDb.OleDbException
                                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Catch ex As Exception
                                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Finally
                                        dbConn.Close()
                                    End Try

                                    total_amount50persen_sementara += (bayar_total * 0.5)
                                    ' ============= Akhir Untuk yang belum ada di table =====================

                                Else

                                    ' ============= Untuk yang udah ada di table =====================
                                    ' ''requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                    ' ''requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                    ' ''requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                    ' ''requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                    Temp_subtotal = tbl_artisDetil_temps.Rows(y).Item("amount") '(requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                                    ' ''Me.DataFill(tbl_master_artisdetil, "ms_MstArtisdetilSUM_Select", String.Format("code = '{0}' ", artis_id))
                                    temp_perhitungan = total_amount50persen_sementara 'tbl_master_artisdetil.Rows(0).Item("total_50persen")

                                    jumlah_awal_ada = temp_perhitungan
                                    bayar_sisa_ada = ((Temp_subtotal * 0.5) + temp_perhitungan)
                                    object_tax_ada = bayar_sisa_ada
                                    If temp_perhitungan < maksimal(0) Then
                                        If bayar_sisa_ada <= maksimal(0) Then
                                            Looping = 1
                                        ElseIf bayar_sisa_ada <= maksimal(1) Then
                                            Looping = 2
                                        ElseIf bayar_sisa_ada <= maksimal(2) Then
                                            Looping = 3
                                        ElseIf bayar_sisa_ada > maksimal(2) Then
                                            Looping = 4
                                        End If
                                    ElseIf temp_perhitungan < maksimal(1) Then
                                        If bayar_sisa_ada <= maksimal(1) Then
                                            Looping = 1
                                        ElseIf bayar_sisa_ada <= maksimal(2) Then
                                            Looping = 2
                                        ElseIf bayar_sisa_ada > maksimal(2) Then
                                            Looping = 3
                                        End If
                                    ElseIf temp_perhitungan < maksimal(2) Then
                                        If bayar_sisa_ada <= maksimal(2) Then
                                            Looping = 1
                                        ElseIf bayar_sisa_ada > maksimal(2) Then
                                            Looping = 2
                                        End If
                                    ElseIf temp_perhitungan >= maksimal(2) Then
                                        Looping = 1
                                    End If

                                    For g = 0 To Looping - 1
                                        If temp_perhitungan < maksimal(0) Then
                                            If jumlah_awal_ada <= maksimal(0) Then
                                                If bayar_sisa_ada > maksimal(0) Then
                                                    bayar_sisa_ada = maksimal(0) - temp_perhitungan
                                                    bayar_pajak_ada = (maksimal(0) - temp_perhitungan) * (persens(0) / 100)
                                                    bayar_artis_ada = (maksimal(0) - temp_perhitungan) - ((maksimal(0) - temp_perhitungan) * (persens(0) / 100))
                                                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                    persen_ada = persens(0)
                                                    jumlah_awal_ada = 50000001
                                                    bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada 'object_tax_ada - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                                Else
                                                    bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(0) / 100) 'bayar_sisa_ada * (persens(0) / 100) ''''Temp_subtotal * (persens(0) / 100)
                                                    bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(0) / 100)) '(bayar_sisa_ada * (persens(0) / 100)) ''''(Temp_subtotal * (persens(0) / 100))
                                                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(0)
                                                    sisa_quota = maksimal(0) - ((bayar_total_ada * 0.5) + temp_perhitungan)
                                                End If
                                            ElseIf jumlah_awal_ada <= maksimal(1) Then
                                                If bayar_sisa_ada > quota(1) Then
                                                    bayar_sisa_ada = bayar_sisa_ada - quota(1)
                                                    bayar_pajak_ada += quota(1) * (persens(1) / 100)
                                                    bayar_artis_ada += quota(1) - (quota(1) * (persens(1) / 100))
                                                    jumlah_awal_ada = minimal(2)
                                                    persen_ada = persens(1)
                                                Else
                                                    bayar_pajak_ada += bayar_sisa_ada * (persens(1) / 100)
                                                    ''''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(1) / 100)) '((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(1) / 100)) - temp_perhitungan) ''''bayar_sisa_ada - (bayar_sisa_ada * (persens(1) / 100))
                                                    bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(1) / 100)) - temp_perhitungan)
                                                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(1)
                                                    sisa_quota = maksimal(1) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                                End If
                                            ElseIf jumlah_awal_ada <= maksimal(2) Then
                                                If bayar_sisa_ada > quota(2) Then
                                                    bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                    bayar_pajak_ada += quota(2) * (persens(2) / 100)
                                                    bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                                                    jumlah_awal_ada = minimal(3)
                                                    persen_ada = persens(2)
                                                Else
                                                    bayar_pajak_ada += bayar_sisa_ada * (persens(2) / 100)
                                                    bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(2) / 100)) - temp_perhitungan)
                                                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(2)
                                                    sisa_quota = maksimal(2) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                                End If
                                            ElseIf jumlah_awal_ada > maksimal(2) Then
                                                bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                                                bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(3) / 100)) - temp_perhitungan)
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(3)
                                                sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                            End If

                                        ElseIf temp_perhitungan < maksimal(1) Then
                                            If jumlah_awal_ada <= maksimal(1) Then
                                                If bayar_sisa_ada > maksimal(1) Then
                                                    bayar_sisa_ada = maksimal(1) - temp_perhitungan
                                                    bayar_pajak_ada = (maksimal(1) - temp_perhitungan) * (persens(1) / 100)
                                                    bayar_artis_ada = (maksimal(1) - temp_perhitungan) - ((maksimal(1) - temp_perhitungan) * (persens(1) / 100))
                                                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                    persen_ada = persens(1)
                                                    jumlah_awal_ada = minimal(2)
                                                    bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada
                                                Else
                                                    bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(1) / 100)
                                                    bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(1) / 100))
                                                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(1)
                                                    sisa_quota = maksimal(1) - ((Temp_subtotal * 0.5) + temp_perhitungan) ''''(Temp_subtotal + temp_perhitungan)
                                                End If
                                            ElseIf jumlah_awal_ada <= maksimal(2) Then
                                                If bayar_sisa_ada > quota(2) Then
                                                    bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                    bayar_pajak_ada += quota(2) * (persens(2) / 100)
                                                    bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                                                    jumlah_awal_ada = minimal(3)
                                                    persen_ada = persens(2)
                                                Else
                                                    bayar_pajak_ada += bayar_sisa_ada * (persens(2) / 100)
                                                    ''''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(2) / 100))
                                                    bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(2) / 100)) - temp_perhitungan)
                                                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(2)
                                                    sisa_quota = maksimal(2) - ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                                End If
                                            ElseIf jumlah_awal_ada > maksimal(2) Then
                                                bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                                                '' ''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(3) / 100))
                                                bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(3) / 100)) - temp_perhitungan)
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(3)
                                                sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                            End If

                                        ElseIf temp_perhitungan < maksimal(2) Then
                                            If jumlah_awal_ada <= maksimal(2) Then
                                                If bayar_sisa_ada > maksimal(2) Then
                                                    bayar_sisa_ada = maksimal(2) - temp_perhitungan
                                                    bayar_pajak_ada = (maksimal(2) - temp_perhitungan) * (persens(2) / 100)
                                                    bayar_artis_ada = (maksimal(2) - temp_perhitungan) - ((maksimal(2) - temp_perhitungan) * (persens(2) / 100))
                                                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                    persen_ada = persens(2)
                                                    jumlah_awal_ada = minimal(3)
                                                    bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada
                                                Else
                                                    bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(2) / 100)
                                                    bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(2) / 100))
                                                    bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(2)
                                                    sisa_quota = maksimal(2) - ((Temp_subtotal * 0.5) + temp_perhitungan) ''''(Temp_subtotal + temp_perhitungan)
                                                End If
                                            ElseIf jumlah_awal_ada > maksimal(2) Then
                                                bayar_pajak_ada += bayar_sisa_ada * (persens(3) / 100)
                                                '' ''bayar_artis_ada += bayar_sisa_ada - (bayar_sisa_ada * (persens(3) / 100))
                                                bayar_artis_ada += ((bayar_sisa_ada + object_tax_ada) - (bayar_sisa_ada * (persens(3) / 100)) - temp_perhitungan)
                                                bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(3)
                                                sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                            End If
                                        ElseIf temp_perhitungan >= maksimal(2) Then
                                            bayar_pajak_ada += (Temp_subtotal * 0.5) * (persens(3) / 100)
                                            bayar_artis_ada += Temp_subtotal - ((Temp_subtotal * 0.5) * (persens(3) / 100))
                                            bayar_total_ada = bayar_pajak_ada + bayar_artis_ada
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + ((bayar_total_ada * 0.5) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                        End If
                                    Next
                                    Try
                                        dbConn.Open()
                                        Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Update", dbConn)
                                        oCm.CommandType = CommandType.StoredProcedure
                                        oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_artisDetil_temps.Rows(y).Item("code")
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_artisDetil_temps.Rows(y).Item("line")
                                        oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_artisDetil_temps.Rows(y).Item("category_id")
                                        oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_artisDetil_temps.Rows(y).Item("code_pajak")
                                        oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                        oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_pajak_ada
                                        oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                        oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total_ada
                                        oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_artis_ada
                                        oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                                        oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                                        oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                                        oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                                        oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = persen_ada
                                        oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = sisa_quota
                                        oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total_ada * 0.5
                                        oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
                                        oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_artisDetil_temps.Rows(y).Item("order_id")
                                        oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_artisDetil_temps.Rows(y).Item("orderdetil_line")

                                        oCm.ExecuteNonQuery()
                                        oCm.Dispose()
                                    Catch ex As Data.OleDb.OleDbException
                                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Catch ex As Exception
                                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Finally
                                        dbConn.Close()
                                    End Try

                                    total_amount50persen_sementara += (bayar_total_ada * 0.5)
                                    ' ============= Akhir Untuk yang udah ada di table =====================
                                End If
                                '================= Akhir Untuk PPH21 Potong =======================================

                            Else

                                '================= Untuk PPH21 Gross UP =======================================
                                If row_artis = 2 Then
                                    'data awal dianggap kosong
                                    ' ============= Untuk yang belum ada di table =====================
                                    ' ''requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                    ' ''requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                    ' ''requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                    ' ''requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                    Temp_subtotal = tbl_artisDetil_temps.Rows(y).Item("amount") '(requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                                    bayar_sisa = (Temp_subtotal * 0.5)
                                    object_tax = bayar_sisa

                                    If bayar_sisa <= maksimal(0) Then
                                        Looping = 1
                                    ElseIf bayar_sisa <= maksimal(1) Then
                                        Looping = 2
                                    ElseIf bayar_sisa <= maksimal(2) Then
                                        Looping = 3
                                    ElseIf bayar_sisa > maksimal(2) Then
                                        Looping = 4
                                    End If

                                    For row_index = 0 To Looping - 1
                                        If jumlah_awal <= maksimal(0) Then
                                            If bayar_sisa > quota(0) Then
                                                bayar_sisa = bayar_sisa - quota(0)
                                                bayar_pajak = quota(0) * (persens(0) / 100)
                                                bayar_artis = quota(0) '- (quota(0) * (persens(0) / 100))
                                                'bayar_total = bayar_pajak + bayar_artis
                                                persen = 5
                                                jumlah_awal = minimal(1)
                                            Else
                                                bayar_pajak += bayar_sisa * (persens(0) / 100)
                                                pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(0))), MidpointRounding.ToEven)
                                                bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                                amountWithTax = bayar_artis - pajak_gross
                                                bayar_total = pajak_gross + bayar_artis
                                                jumlah_awal = bayar_total
                                                persen = persens(0)
                                                sisa_quota = maksimal(0) - ((Temp_subtotal * 0.5) + pajak_gross)  ''''bayar_total
                                            End If

                                        ElseIf jumlah_awal <= maksimal(1) Then
                                            If bayar_sisa > quota(1) Then
                                                bayar_sisa = bayar_sisa - quota(1)
                                                bayar_pajak += quota(1) * (persens(1) / 100)
                                                bayar_artis += quota(1) '- (quota(1) * (persens(1) / 100))
                                                jumlah_awal = minimal(2)
                                                persen = persens(1)
                                            Else
                                                bayar_pajak += bayar_sisa * (persens(1) / 100)
                                                pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(1))), MidpointRounding.ToEven)
                                                bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                                amountWithTax = bayar_artis - pajak_gross
                                                bayar_total = pajak_gross + bayar_artis

                                                sisa_quota = maksimal(1) - ((Temp_subtotal * 0.5) + pajak_gross) ''''bayar_total
                                                jumlah_awal = bayar_total
                                                persen = persens(1)
                                            End If

                                        ElseIf jumlah_awal <= maksimal(2) Then
                                            If bayar_sisa > quota(2) Then
                                                bayar_sisa = bayar_sisa - quota(2)
                                                bayar_pajak += quota(2) * (persens(2) / 100)
                                                bayar_artis += quota(2) '- (quota(2) * (persens(2) / 100))
                                                jumlah_awal = minimal(3)
                                                persen = persens(2)
                                            Else
                                                bayar_pajak += bayar_sisa * (persens(2) / 100)
                                                pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                                bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                                amountWithTax = bayar_artis - pajak_gross
                                                bayar_total = pajak_gross + bayar_artis
                                                jumlah_awal = bayar_total
                                                persen = persens(2)

                                                sisa_quota = maksimal(2) - ((Temp_subtotal * 0.5) + pajak_gross) ''''bayar_total
                                            End If

                                        ElseIf jumlah_awal > maksimal(2) Then
                                            bayar_pajak += bayar_sisa * (persens(3) / 100)
                                            pajak_gross += Math.Round(bayar_pajak * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                            bayar_artis += bayar_sisa + object_tax ''''bayar_sisa
                                            amountWithTax = bayar_artis - pajak_gross
                                            bayar_total = pajak_gross + bayar_artis

                                            jumlah_awal = bayar_total
                                            persen = persens(3)
                                            sisa_quota = maksimal(2) + ((Temp_subtotal * 0.5) + pajak_gross) ''''bayar_total
                                        End If
                                    Next
                                    Try
                                        dbConn.Open()
                                        Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Update", dbConn)
                                        oCm.CommandType = CommandType.StoredProcedure
                                        oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_artisDetil_temps.Rows(y).Item("code")
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_artisDetil_temps.Rows(y).Item("line")
                                        oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_artisDetil_temps.Rows(y).Item("category_id")
                                        oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_artisDetil_temps.Rows(y).Item("code_pajak")
                                        oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                        oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = pajak_gross
                                        oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                        oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total
                                        oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_artis
                                        oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                                        oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                                        oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                                        oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                                        oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = persen
                                        oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = sisa_quota
                                        oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = (Temp_subtotal * 0.5) + pajak_gross
                                        oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
                                        oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_artisDetil_temps.Rows(y).Item("order_id")
                                        oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_artisDetil_temps.Rows(y).Item("orderdetil_line")

                                        oCm.ExecuteNonQuery()
                                        oCm.Dispose()
                                    Catch ex As Data.OleDb.OleDbException
                                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Catch ex As Exception
                                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Finally
                                        dbConn.Close()
                                    End Try

                                    total_amount50persen_sementara += ((Temp_subtotal * 0.5) + pajak_gross)
                                    ' ============= Akhir yang belum ada di table =====================

                                Else

                                    ' ============= Untuk yang udah ada di table =====================
                                    ' ''requestdetil_foreignreal = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_harga")
                                    ' ''requestdetil_foreignrate = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_valas")
                                    ' ''requestdetil_qty = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_qty")
                                    ' ''requestdetil_eps = Me.tbl_TrnTerimabarangdetil.Rows(rows_debet).Item("asset_lineinduk")

                                    Temp_subtotal = tbl_artisDetil_temps.Rows(y).Item("amount") '(requestdetil_foreignreal * requestdetil_foreignrate * requestdetil_qty * requestdetil_eps)

                                    ' ''Me.DataFill(tbl_master_artisdetil, "ms_MstArtisdetilSUM_Select", String.Format("code = '{0}' ", tbl_orderTemp.Rows(0).Item("item_id")))
                                    temp_perhitungan = total_amount50persen_sementara 'tbl_master_artisdetil.Rows(0).Item("total_50persen")

                                    jumlah_awal_ada = temp_perhitungan
                                    ''''bayar_sisa_ada = (Temp_subtotal + temp_perhitungan)
                                    bayar_sisa_ada = ((Temp_subtotal * 0.5) + temp_perhitungan)
                                    object_tax_ada = bayar_sisa_ada

                                    If temp_perhitungan < maksimal(0) Then
                                        If bayar_sisa_ada <= maksimal(0) Then
                                            Looping = 1
                                        ElseIf bayar_sisa_ada <= maksimal(1) Then
                                            Looping = 2
                                        ElseIf bayar_sisa_ada <= maksimal(2) Then
                                            Looping = 3
                                        ElseIf bayar_sisa_ada > maksimal(2) Then
                                            Looping = 4
                                        End If

                                    ElseIf temp_perhitungan < maksimal(1) Then
                                        If bayar_sisa_ada <= maksimal(1) Then
                                            Looping = 1
                                        ElseIf bayar_sisa_ada <= maksimal(2) Then
                                            Looping = 2
                                        ElseIf bayar_sisa_ada > maksimal(2) Then
                                            Looping = 3
                                        End If

                                    ElseIf temp_perhitungan < maksimal(2) Then
                                        If bayar_sisa_ada <= maksimal(2) Then
                                            Looping = 1
                                        ElseIf bayar_sisa_ada > maksimal(2) Then
                                            Looping = 2
                                        End If

                                    ElseIf temp_perhitungan >= maksimal(2) Then
                                        Looping = 1
                                    End If

                                    For g = 0 To Looping - 1
                                        If temp_perhitungan < maksimal(0) Then

                                            If jumlah_awal_ada <= maksimal(0) Then
                                                If bayar_sisa_ada > maksimal(0) Then
                                                    bayar_sisa_ada = maksimal(0) - temp_perhitungan
                                                    bayar_pajak_ada = Math.Round((maksimal(0) - temp_perhitungan) * (persens(0) / 100), MidpointRounding.ToEven)

                                                    persen_ada = persens(0)
                                                    jumlah_awal_ada = 50000001
                                                    bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                                Else
                                                    bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(0) / 100), MidpointRounding.ToEven) ''''Math.Round(Temp_subtotal * (persens(0) / 100), MidpointRounding.ToEven)
                                                    pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(0))), MidpointRounding.ToEven)
                                                    amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                    bayar_total_ada = pajak_gross_ada + Temp_subtotal

                                                    sisa_quota = maksimal(0) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) '(Temp_subtotal  + temp_perhitungan)
                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(0)
                                                End If

                                            ElseIf jumlah_awal_ada <= maksimal(1) Then
                                                If bayar_sisa_ada > quota(1) Then
                                                    bayar_sisa_ada = bayar_sisa_ada - quota(1)
                                                    bayar_pajak_ada += Math.Round(quota(1) * (persens(1) / 100), MidpointRounding.ToEven)

                                                    jumlah_awal_ada = minimal(2)
                                                    persen_ada = persens(1)
                                                Else
                                                    bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(1) / 100), MidpointRounding.ToEven)
                                                    pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(1))), MidpointRounding.ToEven)
                                                    amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                    bayar_total_ada = pajak_gross_ada + Temp_subtotal

                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(1)
                                                    sisa_quota = maksimal(1) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(1) - (bayar_total_ada + temp_perhitungan)
                                                End If

                                            ElseIf jumlah_awal_ada <= maksimal(2) Then
                                                If bayar_sisa_ada > quota(2) Then
                                                    bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                    bayar_pajak_ada += Math.Round(quota(2) * (persens(2) / 100), MidpointRounding.ToEven)

                                                    jumlah_awal_ada = minimal(3)
                                                    persen_ada = persens(2)
                                                Else
                                                    bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(2) / 100), MidpointRounding.ToEven)

                                                    pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                                    amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                    bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(2)

                                                    sisa_quota = maksimal(2) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) - (bayar_total_ada + temp_perhitungan)
                                                End If

                                            ElseIf jumlah_awal_ada > maksimal(2) Then
                                                bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(3)
                                                sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''  maksimal(2) + bayar_sisa_ada
                                            End If

                                        ElseIf temp_perhitungan < maksimal(1) Then
                                            If jumlah_awal_ada <= maksimal(1) Then
                                                If bayar_sisa_ada > maksimal(1) Then
                                                    bayar_sisa_ada = maksimal(1) - temp_perhitungan
                                                    bayar_pajak_ada = Math.Round((maksimal(1) - temp_perhitungan) * (persens(1) / 100), MidpointRounding.ToEven)

                                                    persen_ada = persens(1)
                                                    jumlah_awal_ada = minimal(2)
                                                    bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                                Else
                                                    bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(1) / 100), MidpointRounding.ToEven) ''''Math.Round((Temp_subtotal) * (persens(1) / 100), MidpointRounding.ToEven)

                                                    pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(1))), MidpointRounding.ToEven)
                                                    amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                    bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(1)
                                                    sisa_quota = maksimal(1) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(1) - (Temp_subtotal + temp_perhitungan)
                                                End If

                                            ElseIf jumlah_awal_ada <= maksimal(2) Then
                                                If bayar_sisa_ada > quota(2) Then
                                                    bayar_sisa_ada = bayar_sisa_ada - quota(2)
                                                    bayar_pajak_ada += Math.Round(quota(2) * (persens(2) / 100), MidpointRounding.ToEven)
                                                    'bayar_artis_ada += quota(2) - (quota(2) * (persens(2) / 100))
                                                    jumlah_awal_ada = minimal(3)
                                                    persen_ada = persens(2)
                                                Else
                                                    bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(2) / 100), MidpointRounding.ToEven)

                                                    pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                                    amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                    bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(2)
                                                    sisa_quota = maksimal(2) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) - (bayar_total_ada + temp_perhitungan)
                                                End If

                                            ElseIf jumlah_awal_ada > maksimal(2) Then
                                                bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(3)
                                                sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''(bayar_total_ada + temp_perhitungan)
                                            End If

                                        ElseIf temp_perhitungan < maksimal(2) Then
                                            If jumlah_awal_ada <= maksimal(2) Then
                                                If bayar_sisa_ada > maksimal(2) Then
                                                    bayar_sisa_ada = maksimal(2) - temp_perhitungan
                                                    bayar_pajak_ada = Math.Round((maksimal(2) - temp_perhitungan) * (persens(2) / 100), MidpointRounding.ToEven)

                                                    persen_ada = persens(2)
                                                    jumlah_awal_ada = minimal(3)
                                                    bayar_sisa_ada = (Temp_subtotal * 0.5) - bayar_sisa_ada ''''Temp_subtotal - bayar_sisa_ada
                                                Else
                                                    bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(2) / 100), MidpointRounding.ToEven) ''''Temp_subtotal * (persens(2) / 100)
                                                    pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(2))), MidpointRounding.ToEven)
                                                    amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                    bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                    jumlah_awal_ada = bayar_total_ada
                                                    persen_ada = persens(2)
                                                    sisa_quota = maksimal(2) - (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) - (Temp_subtotal + temp_perhitungan)
                                                End If

                                            ElseIf jumlah_awal_ada > maksimal(2) Then
                                                bayar_pajak_ada += Math.Round(bayar_sisa_ada * (persens(3) / 100), MidpointRounding.ToEven)

                                                pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                                amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                                bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                                jumlah_awal_ada = bayar_total_ada
                                                persen_ada = persens(3)
                                                sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) + (bayar_total_ada + temp_perhitungan)
                                            End If

                                        ElseIf temp_perhitungan >= maksimal(2) Then
                                            bayar_pajak_ada += Math.Round((Temp_subtotal * 0.5) * (persens(3) / 100), MidpointRounding.ToEven) ''''Temp_subtotal * (persens(3) / 100)
                                            pajak_gross_ada = Math.Round(bayar_pajak_ada * (100 / (100 - persens(3))), MidpointRounding.ToEven)
                                            amountWithTax_ada = Temp_subtotal - pajak_gross_ada
                                            bayar_total_ada = pajak_gross_ada + Temp_subtotal
                                            jumlah_awal_ada = bayar_total_ada
                                            persen_ada = persens(3)
                                            sisa_quota = maksimal(2) + (((Temp_subtotal * 0.5) + pajak_gross_ada) + temp_perhitungan) ''''maksimal(2) + (bayar_total_ada + temp_perhitungan)
                                        End If
                                    Next
                                    Try
                                        dbConn.Open()
                                        Dim oCm As New OleDb.OleDbCommand("ms_MstArtisdetil_Update", dbConn)
                                        oCm.CommandType = CommandType.StoredProcedure
                                        oCm.Parameters.Add("@code", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_artisDetil_temps.Rows(y).Item("code")
                                        oCm.Parameters.Add("@line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_artisDetil_temps.Rows(y).Item("line")
                                        oCm.Parameters.Add("@category_id", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_artisDetil_temps.Rows(y).Item("category_id")
                                        oCm.Parameters.Add("@code_pajak", System.Data.OleDb.OleDbType.Decimal, 9).Value = tbl_artisDetil_temps.Rows(y).Item("code_pajak")
                                        oCm.Parameters.Add("@amount", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                        oCm.Parameters.Add("@amount_tax", System.Data.OleDb.OleDbType.Decimal, 9).Value = pajak_gross_ada
                                        oCm.Parameters.Add("@subtotal", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                        oCm.Parameters.Add("@grand_total", System.Data.OleDb.OleDbType.Decimal, 9).Value = bayar_total_ada
                                        oCm.Parameters.Add("@amount_forartist", System.Data.OleDb.OleDbType.Decimal, 9).Value = Temp_subtotal
                                        oCm.Parameters.Add("@entry_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = Now.Date
                                        oCm.Parameters.Add("@entry_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = Me.UserName
                                        oCm.Parameters.Add("@modified_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4).Value = DBNull.Value
                                        oCm.Parameters.Add("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100).Value = String.Empty
                                        oCm.Parameters.Add("@persen", System.Data.OleDb.OleDbType.Integer, 20).Value = persen_ada
                                        oCm.Parameters.Add("@sisa", System.Data.OleDb.OleDbType.Decimal, 9).Value = sisa_quota
                                        oCm.Parameters.Add("@total_amount_pertahun", System.Data.OleDb.OleDbType.Decimal, 9).Value = (Temp_subtotal * 0.5) + pajak_gross_ada
                                        oCm.Parameters.Add("@persen_tahun", System.Data.OleDb.OleDbType.Integer, 4).Value = Year(Now)
                                        oCm.Parameters.Add("@order_id", System.Data.OleDb.OleDbType.VarWChar, 30).Value = tbl_artisDetil_temps.Rows(y).Item("order_id")
                                        oCm.Parameters.Add("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4).Value = tbl_artisDetil_temps.Rows(y).Item("orderdetil_line")

                                        oCm.ExecuteNonQuery()
                                        oCm.Dispose()
                                    Catch ex As Data.OleDb.OleDbException
                                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Catch ex As Exception
                                        MessageBox.Show("Data Not Saved" & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Finally
                                        dbConn.Close()
                                    End Try

                                    total_amount50persen_sementara += (Temp_subtotal * 0.5) + pajak_gross_ada
                                    ' ============= Akhir yang udah ada di table =====================
                                End If
                                '================= Akhir Untuk PPH21 Gross UP =======================================
                            End If
                        Else
                            total_amount50persen_sementara += tbl_artisDetil_temps.Rows(y).Item("total_amount_pertahun")
                        End If
                    Next
                End If
            End If
        Next
    End Sub
End Class