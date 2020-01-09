Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns

Public Class uiTrnPenerimaanBarangListRV
    Private Const mUiName As String = "Transaksi Rakitan"
    Private Event FormBeforeNew()
    Private btnNewClick As Boolean = False
    Private Const SHOW_SAVE_CONFIRMATION As Boolean = True
    Private FILTER_QUERY_MODE As Boolean

    Private objFormError As Windows.Forms.ErrorProvider = New Windows.Forms.ErrorProvider
    Private tbl_MstRekanan As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private tbl_MstChannel_search As DataTable = clsDataset.CreateTblMstChannel()
    Private tbl_MstRekanan_search As DataTable = clsDataset.CreateTblMstrekananCombo()
    Private tbl_MstStrukturunit_search As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_MstStrukturunit As DataTable = clsDataset.CreateTblStrukturunitPemilik()
    Private tbl_TrnPenerimaanbarang As DataTable = clsDataset.CreateTblTrnPenerimaanbarang()
    Private tbl_TrnPenerimaanbarang_Temp As DataTable = clsDataset.CreateTblTrnPenerimaanbarang()
    Private tbl_TrnPenerimaanbarangdetil As DataTable = CreateTblViewTrnTerimabarangDetil()
    Private tbl_TrnPenerimaanbarangReference As DataTable = CreateTblViewTrnTerimabarangReference()
    Private tbl_TrnJurnal As DataTable = clsDataset.CreateTblTrnJurnal()
    Private tbl_MstPeriodeCombo As DataTable = clsDataset.CreateTblMstPeriodeCombo()
    Private tbl_MstCurrency As DataTable = clsDataset.CreateTblMstCurrency
    Private currency_id As Decimal

    'DgvDetil
    Private tbl_mstKategoriAsset As DataTable = clsDataset.CreateTblMstKategoriasset
    Private tbl_MstTipeAsset As DataTable = clsDataset.CreateTblMstTipeasset
    Private tbl_MstItem As DataTable = clsDataset.CreateTblMstItem
    Private tbl_MstItemCategory As DataTable = clsDataset.CreateTblMstItemcategory
    Private tbl_MstBrand As DataTable = clsDataset.CreateTblMstMerk
    Private tbl_MstTipeitem As DataTable = clsDataset.CreateTblMstTipeitem
    Private tbl_MstMaterial As DataTable = clsDataset.CreateTblMstMaterial
    Private tbl_MstWarna As DataTable = clsDataset.CreateTblMstWarna
    Private tbl_MstUkuran As DataTable = clsDataset.CreateTblMstUkuran
    Private tbl_Mstsex As DataTable = clsDataset.CreateTblMstPilihan
    Private tbl_MstAssetruang As DataTable = clsDataset.CreateTblMstRuangAsset
    Private tbl_MstUnit As DataTable = clsDataset.CreateTblMstUnit
    Private tbl_MstShow As DataTable = clsDataset.CreateTblMstShow
    Private tbl_MstShowcont As DataTable = clsDataset.CreateTblMstShow

    'Detil
    Private tbl_MstTipeAssetDetil As DataTable = clsDataset.CreateTblMstTipeasset
    Private tbl_MstItemDetil As DataTable = clsDataset.CreateTblMstItem
    Private tbl_MstItemCategoryDetil As DataTable = clsDataset.CreateTblMstItemcategory
    Private tbl_MstBrandDetil As DataTable = clsDataset.CreateTblMstMerk
    Private tbl_MstMaterialDetil As DataTable = clsDataset.CreateTblMstMaterial
    Private tbl_MstWarnaDetil As DataTable = clsDataset.CreateTblMstWarna
    Private tbl_MstUkuranDetil As DataTable = clsDataset.CreateTblMstUkuran
    Private tbl_MstsexDetil As DataTable = clsDataset.CreateTblMstPilihan
    Private tbl_MstAssetruangDetil As DataTable = clsDataset.CreateTblMstRuangAsset
    Private tbl_MstUnitDetil As DataTable = clsDataset.CreateTblMstUnit
    Private tbl_MstShowDetil As DataTable = clsDataset.CreateTblMstShow
    Private tbl_MstShowcontDetil As DataTable = clsDataset.CreateTblMstShow

    Private tbl_MstKategoriAssetDepre As DataTable = clsDataset.CreateTblMstKategoriassetdepre()
    Private tbl_TrnJurnaldetil_debet As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_TrnJurnaldetil_kredit As DataTable = clsDataset.CreateTblTrnJurnaldetil()
    Private tbl_JurnalReference As DataTable = clsDataset.CreateTblTrnJurnalreference()
    Private tbl_MstAcc As DataTable = clsDataset.CreateTblMstAccountCombo()

    Private tbl_TrnBudget As DataTable = clsDataset.CreateTblMstBudgetCombo()
    Private tbl_TrnBudgetDetil As DataTable = clsDataset.CreateTblMstBudgetdetilCombo()
    Private terimabarang_id As String = ""

    Enum ModuleType
        PURCHASE
        MANUAL
        LISTPV
        LISTGQ
        LISTRV
    End Enum

    Enum StrukturUnit
        TSV = 5554
        Wardrobe = 5556
        Transmisi = 3130
        Project = 5548
    End Enum

#Region " Window Parameter "
    Private _CHANNEL As String = "TAS"
    Private _CHANNEL_CANBE_CHANGED As Boolean = False
    Private _CHANNEL_CANBE_BROWSED As Boolean = False
    Private _STRUKTUR_UNIT As StrukturUnit = StrukturUnit.Wardrobe
    Private _USERTYPE As String = "acc" '"spv" '"acc"'"user"
    Private _MODULE_TYPE As ModuleType = ModuleType.LISTRV
#End Region


#Region " User Defined Function "
    Public Overrides Function btnNew_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.btnNewClick = True

        If Me.ftabMain.SelectedTabPageIndex = 0 Then
            Me.ftabMain.SelectedTabPageIndex = 1
        End If

        If Me.btnNewClick = True Then
            Me.uiTrnPenerimaanBarang_NewData()
        End If

        Me.tbtnDel.Enabled = True
        Me.tbtnSave.Enabled = True
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnNew_Click()
    End Function

    Public Overrides Function btnLoad_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        Me.uiTrnPenerimaanBarang_Retrieve()
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnLoad_Click()
    End Function

    Public Overrides Function btnQuery_Click() As Boolean
        Me.PnlDfSearch.Visible = Not Me.PnlDfSearch.Visible
        If Me.PnlDfSearch.Visible Then
            FILTER_QUERY_MODE = True
            Me.tbtnQuery.Checked = CheckState.Checked
        Else
            FILTER_QUERY_MODE = False
            Me.tbtnQuery.Checked = CheckState.Unchecked
        End If
        Return MyBase.btnQuery_Click()
    End Function

    Public Overrides Function btnSave_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor

        If Me.uiTrnJurnal_RV_Rakitan_FormError() Then
            System.Windows.Forms.Cursor.Current = Cursors.Default
            Me.Cursor = Cursors.Arrow
            Exit Function
        End If

        Try
            Me.uiTrnPenerimaanBarang_Save()
            Me.uiTrnPenerimaanBarang_Purchase_JurnalSave()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try

        Me.Cursor = Cursors.Arrow
        Return MyBase.btnSave_Click()
    End Function

    Public Overrides Function btnDel_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor

        Try
            Me.uiTrnPenerimaanBarang_Delete()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try

        Me.Cursor = Cursors.Arrow
        Return MyBase.btnDel_Click()
    End Function

    Public Overrides Function btnPosting_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor
        If Me.uiTrnJurnal_RV_Rakitan_FormError() Then
            System.Windows.Forms.Cursor.Current = Cursors.Default
            Me.Cursor = Cursors.Arrow
            Exit Function
        End If

        Me.ApproveDisapprove(Me.txtRvID.Text, 1, Me.UserName)
        Me.Cursor = Cursors.Arrow
        Return MyBase.btnPosting_Click()
    End Function

    Public Overrides Function btnUnposting_Click() As Boolean
        Me.Cursor = Cursors.WaitCursor

        If Me.uiTrnJurnal_RV_RakitanIsDepre_Check(Me.txtRvID.Text) Then
            System.Windows.Forms.Cursor.Current = Cursors.Default
            Me.Cursor = Cursors.Arrow
            Exit Function
        End If

        Try
            Me.ApproveDisapprove(Me.txtRvID.Text, 2, Me.UserName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "ERROR")
        End Try


        Me.Cursor = Cursors.Arrow
        Return MyBase.btnUnposting_Click()
    End Function

    Private Function uiTrnPenerimaanBarang_Retrieve() As Boolean
        'retrieve data
        Dim criteria As String = ""

        ' TODO: Parse Criteria using clsProc.RefParser()
        criteria = " AND terimabarang_type = 'LISTRV' AND terimabarang_isdisabled = 0 "

        If Me.chkSrchDept.Checked = True Then
            criteria = criteria & " AND strukturunit_id = " & Me.lueSrchChannelID.EditValue
        End If

        If Me.chkSrchRekanan.Checked = True Then
            criteria = criteria & " AND rekanan_id = " & CStr(Me.txtSrchRekananID.Text)
        End If

        If Me.chkSrchRvID.Checked = True Then
            criteria &= criteria & String.Format(" AND terimabarang_id = '{0}'", Me.txtSrchRvID.Text)
        End If


        Me.tbl_TrnPenerimaanbarang.Clear()

        Try
            Using receive As New clsTrnPenerimaanBarang(Me.DSNFrm)
                receive.RetrieveHeader(Me.tbl_TrnPenerimaanbarang, criteria, Me._CHANNEL, Me.seRecord.Value)
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Shared Function CreateTblViewTrnTerimabarangDetil() As DataTable
        Dim tbl As DataTable = clsDataset.CreateTblTrnPenerimaanbarangdetil()

        tbl.Columns.Add("budget_name", GetType(String)).DefaultValue = ""
        tbl.Columns.Add("budgetdetil_name", GetType(String)).DefaultValue = ""
        tbl.Columns.Add("ref_id", GetType(String)).DefaultValue = ""
        tbl.Columns.Add("refdetil_line", GetType(Integer)).DefaultValue = 0
        tbl.Columns.Add("is_parent", GetType(Integer)).DefaultValue = 0

        Return tbl
    End Function

    Private Function CreateTblViewTrnTerimabarangReference() As DataTable
        Dim tbl As DataTable = New DataTable

        tbl.Columns.Add("terimabarang_id", GetType(String)).DefaultValue = ""
        tbl.Columns.Add("terimabarangdetil_line", GetType(Integer)).DefaultValue = 0
        tbl.Columns.Add("ref_id", GetType(String)).DefaultValue = ""
        tbl.Columns.Add("refdetil_line", GetType(Integer)).DefaultValue = 0
        tbl.Columns.Add("is_parent", GetType(Integer)).DefaultValue = 0

        Return tbl
    End Function
#End Region

    Private Function uiTrnJurnal_RV_Rakitan_FormError() As Boolean
        Dim message As String = ""
        Try
            'If Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc") = True Then
            '    Throw New Exception("Data telah diapprove !!")
            'End If

            If Me.tbl_TrnJurnaldetil_debet.Rows.Count <= 0 AndAlso Me.tbl_TrnJurnaldetil_debet Is Nothing Then
                Throw New Exception("Harap isi Jurnal Debit terlebih dahulu !!")
            End If

            If Me.tbl_TrnJurnaldetil_kredit.Rows.Count <= 0 AndAlso Me.tbl_TrnJurnaldetil_kredit Is Nothing Then
                Throw New Exception("Harap isi Jurnal Kredit terlebih dahulu !!")
            End If

            Dim sumKreditIDR As Decimal
            sumKreditIDR = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_kredit.Compute("Sum(jurnaldetil_idr)", ""), 0)
            If sumKreditIDR <> Me.tbl_TrnPenerimaanbarangdetil.Rows(0).Item("terimabarangdetil_idrreal") Then
                Me.tbl_TrnPenerimaanbarangdetil.Rows(0).Item("terimabarangdetil_idrreal") = sumKreditIDR
            End If

            'cek balance
            Dim jumlah, jumlahforeign, selisih, selisihforeign As Decimal
            Dim returnnilai As Tuple(Of Decimal, Decimal, Decimal, Decimal)

            returnnilai = amountCalculate()

            jumlah = returnnilai.Item1
            jumlahforeign = returnnilai.Item2

            selisih = returnnilai.Item3
            selisihforeign = returnnilai.Item4

            If selisih <> 0 Then
                Throw New Exception("IDR Debit Kredit tidak balance !!" + vbCrLf + "Jumlah : " + jumlah.ToString("N0") + vbCrLf + "Selisih : " + selisih.ToString("N2"))
            End If

            If selisihforeign <> 0 Then
                Throw New Exception("Foreign Debit Kredit tidak balance !!" + vbCrLf + "Jumlah : " + jumlahforeign.ToString("N2") + vbCrLf + "Selisih : " + selisihforeign.ToString("N2"))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, mUiName)
            Return True
        End Try
        Return False
    End Function

    Private Function amountCalculate() As Tuple(Of Decimal, Decimal, Decimal, Decimal)
        Dim amountDebitForeign As Decimal
        Dim amountCreditForeign As Decimal
        Dim amountDebit As Decimal
        Dim amountCredit As Decimal
        Dim selisihAmount As Decimal
        Dim selisihAmountIdr As Decimal

        amountDebitForeign = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_debet.Compute("SUM(jurnaldetil_foreign)", ""), 0)
        amountCreditForeign = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_kredit.Compute("SUM(jurnaldetil_foreign)", ""), 0)

        amountDebit = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_debet.Compute("SUM(jurnaldetil_idr)", ""), 0)
        amountCredit = clsUtil.IsDbNull(Me.tbl_TrnJurnaldetil_kredit.Compute("SUM(jurnaldetil_idr)", ""), 0)

        selisihAmount = amountDebitForeign - amountCreditForeign
        selisihAmountIdr = amountDebit - amountCredit

        Return New Tuple(Of Decimal, Decimal, Decimal, Decimal)(amountDebit, amountDebitForeign, selisihAmountIdr, selisihAmount)

        'Me.obj_jumlah_amount.Text = amountDebit.ToString("###,###.00")
        'Me.obj_jumlah_amountidr.Text = amountIdrDebit.ToString("###,###")

        'Me.obj_amount_debit.Text = amountDebit.ToString("###,###.00")
        'Me.obj_amount_debitidr.Text = amountIdrDebit.ToString("###,###.00")

        'Me.obj_amount_credit.Text = amountCredit.ToString("###,###.00")
        'Me.obj_amount_creditidr.Text = amountIdrCredit.ToString("###,###.00")

        'Me.obj_selisih_amount.Text = selisihAmount.ToString("###,###.00")
        'Me.obj_selisih_amountidr.Text = selisihAmountIdr.ToString("###,###.00")
        'Me.obj_total_depre.Text = totalDepre.ToString("###,###.00")
    End Function
 

    Private Function uiTrnJurnal_RV_RakitanIsDepre_Check(ByVal terimabarang_id As String) As Boolean
        Try
            If terimabarang_id = "" Then
                Throw New Exception("Id RV kosong")
                Return True
            End If

            Dim dtCheck As New DataTable
            Dim dtFiller As clsDataFiller = New clsDataFiller(Me.DSNFrm)
            dtFiller.DataFill(dtCheck, "act_JurnalRakitanIsDepre_Check", String.Format("terimabarang_id = '{0}'", terimabarang_id))

            If dtCheck.Rows.Count > 0 Then
                Throw New Exception("Tidak dapat Disapprove !!" + Chr(13) + terimabarang_id + Chr(13) + "Sudah di Depre pada Jurnal Depre : " + Chr(13) + dtCheck.Rows(0).Item("jurnal_id").ToString)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, mUiName)
            Return True
        End Try
        Return False
    End Function

    Private Sub uiTrnPenerimaanBarang_FormBeforeNew() Handles Me.FormBeforeNew
        Me.tbtnPosting.Visibility = True
        Me.tbtnUnposting.Visibility = False
        Me.objFormError.Clear()
    End Sub

    Private Sub uiTrnTerimaBarang_LoadCombo()
        Dim oDataFiller As New clsDataFiller(Me.DSNFrm)

        '-----Mulai Bikin Tabel untuk combo Data Search-------------------------
        Me.ComboFillDX(Me.DSNFrm, Me.lueJurnalCurrency, "Currency_id", "Currency_shortname", Me.tbl_MstCurrency, "ms_MstCurrency_Select", "Currency_active = 1", "")
        Me.tbl_MstCurrency.DefaultView.Sort = "Currency_shortname"

        Me.ComboFillDX(Me.DSNFrm, Me.lueSrchChannelID, "channel_id", "channel_id", tbl_MstChannel_search, "as_MstChannel_select", " channel_id = '" & Me._CHANNEL & "' ", "")
        Me.ComboFillDX(Me.DSNFrm, Me.lueSrchDept, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunit_search, "ms_MstStrukturUnit_Select", "", "")
        Me.tbl_MstStrukturunit_search.DefaultView.Sort = "strukturunit_name"
        Me.tbl_MstStrukturunit = Me.tbl_MstStrukturunit_search.Copy

        Me.ComboFillDXFromDataTable(Me.lueDept, "strukturunit_id", "strukturunit_name", Me.tbl_MstStrukturunit)


        Me.ComboFillDX(Me.DSNFrm, Me.lueJurnalPeriode, "periode_id", "periode_name", Me.tbl_MstPeriodeCombo, "ms_MstPeriodeCombo_Select", " channel_id = '" & Me._CHANNEL & "' ")
        Me.tbl_MstPeriodeCombo.DefaultView.Sort = "periode_name"

        Me.DataFillAsset(Me.DSNFrm, Me.tbl_MstTipeAssetDetil, "as_MstTipeasset_Select", " ")
        Me.tbl_MstTipeAsset = Me.tbl_MstTipeAssetDetil.Copy

        Me.DataFillAsset(Me.DSNFrm, Me.tbl_MstItem, "ms_MstItem_Select", " ")

        Using filler As New clsDataFiller(Me.DSNFrm)
            'TAMBAHAN
            filler.DataFill(tbl_MstTipeitem, "as_MstTipeitem_Select", "")
            filler.DataFillForCombo("kategoriasset_id", "kategoriasset_id", Me.tbl_mstKategoriAsset, "as_MstKategoriasset_Select", "")
            filler.DataFill(Me.tbl_MstKategoriAssetDepre, "as_MstKategoriassetdepre_Select", "")
        End Using

        Me.DataFillAsset(Me.DSNFrm, Me.tbl_MstItemCategory, "ms_MstItemCategory_Select", " ")
        Me.DataFillAsset(Me.DSNFrm, Me.tbl_MstBrand, "as_MstMerk_Select", " merk_active = 1 ")


        Using filler As New clsDataFiller(Me.DSNFrm)
            filler.DataFill(Me.tbl_MstRekanan, "ms_MstRekanan_Select2", "", Me._CHANNEL)
            filler.DataFill(Me.tbl_MstAcc, "ms_MstAccountCombo_Select", "")
            filler.DataFill(Me.tbl_TrnBudget, "ms_MstBudgetCombo_Select", "budget_isactive = 1  and channel_id = '" & Me._CHANNEL & "' ")
            filler.DataFill(Me.tbl_TrnBudgetDetil, "ms_MstBudgetdetilCombo_Select", "")
        End Using


    End Sub

    Private Function InitLayoutUI() As Boolean
        Me.ftabMain.Anchor = AnchorStyles.Bottom
        Me.ftabMain.Anchor += AnchorStyles.Top
        Me.ftabMain.Anchor += AnchorStyles.Right
        Me.ftabMain.Anchor += AnchorStyles.Left

        Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
        Me.PnlDfSearch.Dock = DockStyle.Top
        Me.PnlDfSearch.Visible = False
        Me.cboGVRVDetil()
    End Function

    Private Function cboGVRVDetil() As Boolean
        RepositoryAssetTipe.DataSource = Me.tbl_MstTipeAsset
        RepositoryAssetTipe.DisplayMember = "tipeasset_id"
        RepositoryAssetTipe.ValueMember = "tipeasset_id"

        RepositoryAssetCategory.DataSource = Me.tbl_mstKategoriAsset
        RepositoryAssetCategory.DisplayMember = "kategoriasset_id"
        RepositoryAssetCategory.ValueMember = "kategoriasset_id"

        RepositoryItemId.DataSource = Me.tbl_MstItem
        RepositoryItemId.ValueMember = "item_id"
        RepositoryItemId.DisplayMember = "item_name"

        RepositoryItemCategory.DataSource = Me.tbl_MstItemCategory
        RepositoryItemCategory.DisplayMember = "category_name"
        RepositoryItemCategory.ValueMember = "category_id"

        RepositoryItemTipe.DataSource = Me.tbl_MstTipeitem
        RepositoryItemTipe.DisplayMember = "Tipeitem_id"
        RepositoryItemTipe.ValueMember = "Tipeitem_id"

        RepositoryBrandId.DataSource = Me.tbl_MstBrand
        RepositoryBrandId.ValueMember = "merk_id"
        RepositoryBrandId.DisplayMember = "merk_name"

        RepositoryCatDepre.DataSource = Me.tbl_MstKategoriAssetDepre
        RepositoryCatDepre.ValueMember = "kategoriassetdepre_id"
        RepositoryCatDepre.DisplayMember = "kategoriassetdepre_descr"
    End Function

    Private Function BindingStart() As Boolean
        'start binding
        Me.txtRvID.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_id"))
        Me.txtRvType.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_type"))
        Me.txtLocation.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_location"))
        Me.txtNotes.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_notes"))
        Me.lueDept.DataBindings.Add(New Binding("EditValue", Me.tbl_TrnPenerimaanbarang_Temp, "strukturunit_id"))
        Me.txtCreatedBy.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_createby"))
        Me.txtCreatedDate.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_createdt"))
        Me.txtModifiedBy.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_modifiedby"))
        Me.txtModifiedDate.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_modifieddt"))
        Me.chkAppAcc.DataBindings.Add(New Binding("Checked", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appacc"))
        Me.txtAppAccBy.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appacc_by"))
        Me.txtAppAccDate.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_appacc_dt"))

        Me.lueJurnalCurrency.DataBindings.Add(New Binding("EditValue", Me.tbl_TrnPenerimaanbarang_Temp, "currency_id", True, DataSourceUpdateMode.OnPropertyChanged, 0))
        Me.txtJurnalAmountForeign.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_foreign"))
        Me.txtJurnalRate.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_foreignrate"))
        Me.txtJurnalAmountIDR.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_idrreal"))
        Me.txtJurnalPPH.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_pph", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.txtJurnalPPN.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_ppn", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))
        Me.txtJurnalDisc.DataBindings.Add(New Binding("Text", Me.tbl_TrnPenerimaanbarang_Temp, "terimabarang_disc", True, DataSourceUpdateMode.OnPropertyChanged, 0, "#,##0.00"))

        Return True
    End Function

    Private Function BindingStop() As Boolean
        'stop binding
        Me.txtRvID.DataBindings.Clear()
        Me.txtRvType.DataBindings.Clear()
        Me.txtLocation.DataBindings.Clear()
        Me.txtNotes.DataBindings.Clear()
        Me.lueDept.DataBindings.Clear()
        Me.txtCreatedBy.DataBindings.Clear()
        Me.txtCreatedDate.DataBindings.Clear()
        Me.txtModifiedBy.DataBindings.Clear()
        Me.txtModifiedDate.DataBindings.Clear()
        Me.chkAppAcc.DataBindings.Clear()
        Me.txtAppAccBy.DataBindings.Clear()
        Me.txtAppAccDate.DataBindings.Clear()

        Me.lueJurnalCurrency.DataBindings.Clear()
        Me.txtJurnalAmountForeign.DataBindings.Clear()
        Me.txtJurnalRate.DataBindings.Clear()
        Me.txtJurnalAmountIDR.DataBindings.Clear()
        Me.txtJurnalPPH.DataBindings.Clear()
        Me.txtJurnalPPN.DataBindings.Clear()
        Me.txtJurnalDisc.DataBindings.Clear()

        Return True
    End Function

    Private Function BindingStopJurnal() As Boolean
        Me.dtJurnalBookDate.DataBindings.Clear()
        Me.lueJurnalPeriode.DataBindings.Clear()
        Return True
    End Function

    Private Function BindingStartJurnal() As Boolean
        Me.dtJurnalBookDate.DataBindings.Add(New Binding("EditValue", Me.tbl_TrnJurnal, "jurnal_bookdate", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy"))
        Me.lueJurnalPeriode.DataBindings.Add(New Binding("EditValue", Me.tbl_TrnJurnal, "periode_id"))

        Return True
    End Function

    Private Function uiTrnPenerimaanBarang_NewData() As Boolean
        'new data
        'RaiseEvent FormBeforeNew()

        ' TODO: Set Default Value for tbl_TrnPenerimaanbarang_Temp
        Me.tbl_TrnPenerimaanbarang_Temp.Clear()
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("strukturunit_id").DefaultValue = Me._STRUKTUR_UNIT

        Select Case Me._MODULE_TYPE
            Case ModuleType.LISTRV
                Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_type").DefaultValue = "LISTRV"
                Me.tbl_TrnPenerimaanbarang_Temp.Columns("order_id").DefaultValue = "-"
                Me.tbl_TrnPenerimaanbarang_Temp.Columns("currency_id").DefaultValue = 1
                Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_foreignrate").DefaultValue = 1
        End Select

        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_status").DefaultValue = "-- Pilih --"
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_statusrealization").DefaultValue = "-- Pilih --"
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_date").DefaultValue = Now.Date
        Me.tbl_TrnPenerimaanbarang_Temp.Columns("terimabarang_location").DefaultValue = ""

        ' TODO: Set Default Value for tbl_TrnPenerimaanbarangdetil
        Me.tbl_TrnPenerimaanbarangdetil.Clear()
        Me.tbl_TrnPenerimaanbarangdetil = CreateTblViewTrnTerimabarangDetil()
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarang_id").DefaultValue = 0
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrement = True
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrementStep = 10
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_date").DefaultValue = Now.Date
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_product_no").DefaultValue = "label"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("strukturunit_id").DefaultValue = Me._STRUKTUR_UNIT
        Me.tbl_TrnPenerimaanbarangdetil.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnPenerimaanbarangdetil.Columns("item_id").DefaultValue = "0"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("itemcategory_id").DefaultValue = "0"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("brand_id").DefaultValue = 0
        Me.tbl_TrnPenerimaanbarangdetil.Columns("currency_id").DefaultValue = 1
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_foreignrate").DefaultValue = 1
        Me.tbl_TrnPenerimaanbarangdetil.Columns("is_parent").DefaultValue = 0

        Select Case Me._MODULE_TYPE
            Case ModuleType.LISTRV
                Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_type").DefaultValue = "LISTRV"
        End Select

        Me.tbl_TrnJurnal.Clear()
        Me.tbl_TrnJurnal.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnJurnal.Columns("currency_id").DefaultValue = 1
        Me.tbl_TrnJurnal.Columns("jurnal_source").DefaultValue = "LISTRV"

        Me.tbl_TrnJurnaldetil_kredit.Clear()
        Me.tbl_TrnJurnaldetil_kredit = clsDataset.CreateTblTrnJurnaldetil() 'clsDataset.CreateTblTrnJurnaldetilPembayaran()
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnal_id").DefaultValue = ""
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").AutoIncrementSeed = 5
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_dk").DefaultValue = "K"
        Me.tbl_TrnJurnaldetil_kredit.Columns("currency_id").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_foreignrate").DefaultValue = 1

        Me.tbl_TrnJurnaldetil_debet.Clear()
        Me.tbl_TrnJurnaldetil_debet = clsDataset.CreateTblTrnJurnaldetil()
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnal_id").DefaultValue = ""
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_debet.Columns("acc_id").DefaultValue = ""
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_dk").DefaultValue = "D"
        Me.tbl_TrnJurnaldetil_debet.Columns("currency_id").DefaultValue = 1
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_foreignrate").DefaultValue = 1

        Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).EndCurrentEdit()
        Try
            Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).AddNew()

            Me.BindingStop()
            Me.BindingStart()
            Me.BindingStopJurnal()
            Me.BindingStartJurnal()

            Me.BindingContext(Me.tbl_TrnJurnal).AddNew()
            Me.GCRVDetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil

            'GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            'GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            Me.MenuRVRakitan.Enabled = True

            Me.GCJurnalDebit.DataSource = Me.tbl_TrnJurnaldetil_debet
            Me.GCJurnalKredit.DataSource = Me.tbl_TrnJurnaldetil_kredit
            Me.tbtnPosting.Enabled = True
            Me.tbtnUnposting.Enabled = False

            Me.txtJurnalPPN.Text = 0
            Me.txtJurnalPPH.Text = 0
            Me.txtJurnalDisc.Text = 0
            Me.lueJurnalCurrency.EditValue = 0
            Me.txtJurnalRate.Text = 1

            Me.EnableDisable(True)

        Catch ex As Exception
            MessageBox.Show(ex.Source)
        End Try
    End Function

    Public Sub Form_Load(ByVal sender As Object)
        Dim objParameters As Collection = New Collection
        Dim tbl_Approved As New DataTable

        'TODO: - Extract Parameter
        '      - Assign parameter
        If Me.Browser IsNot Nothing Then
            Dim mType As String

            objParameters = Me.GetParameterCollection(Me.Parameter)
            Me._CHANNEL = Me.GetValueFromParameter(objParameters, "CHANNEL")
            Me._CHANNEL_CANBE_CHANGED = Me.GetBolValueFromParameter(objParameters, "CHANNELCHANGED")
            Me._CHANNEL_CANBE_BROWSED = Me.GetBolValueFromParameter(objParameters, "CHANNELBROWSED")
            Me._STRUKTUR_UNIT = Me.GetDecValueFromParameter(objParameters, "STRUKTUR_UNIT")
            Me._USERTYPE = (Me.GetValueFromParameter(objParameters, "USER_TYPE"))
            mType = Me.GetValueFromParameter(objParameters, "MODULE_TYPE")

            Select Case mType
                Case "PURCHASE"
                    Me._MODULE_TYPE = ModuleType.PURCHASE
                Case "MANUAL"
                    Me._MODULE_TYPE = ModuleType.MANUAL
                Case "LISTPV"
                    Me._MODULE_TYPE = ModuleType.LISTPV
                Case "LISTGQ"
                    Me._MODULE_TYPE = ModuleType.LISTGQ
                Case "LISTRV"
                    Me._MODULE_TYPE = ModuleType.LISTRV
            End Select
        End If

        If (Me.Browser IsNot Nothing And MyBase.Name = _Name) Or (Me.Browser Is Nothing And Application.ProductName <> _ProductName) Then
            'Fill Combobox
            'dan fungsi2 startup lainnya....
            'Me.uiTrnTerimaBarang_isBackgroudWorker()
            Me.uiTrnTerimaBarang_LoadCombo()
            'Me.uiTrnTerimaBarang_LoadStringCollection()
            Me.GCRVRakitan.DataSource = Me.tbl_TrnPenerimaanbarang
            Me.GCRVDetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil
            Me.GCJurnalDebit.DataSource = Me.tbl_TrnJurnaldetil_debet
            Me.GCJurnalKredit.DataSource = Me.tbl_TrnJurnaldetil_kredit

            Me.InitLayoutUI()

            Me.BindingStop()
            Me.BindingStart()
            Me.BindingStopJurnal()
            Me.BindingStartJurnal()

            Me.uiTrnPenerimaanBarang_NewData()

            Me.tbtnSave.Enabled = False
            Me.tbtnDel.Enabled = False
            Me.tbtnLoad.Enabled = True
            Me.tbtnQuery.Enabled = True
            Me.tbtnNew.Enabled = True
            Me.tbtnPrint.Enabled = False
            Me.tbtnPrintPreview.Enabled = False
            Me.tbtnPosting.Enabled = False
            Me.tbtnUnposting.Enabled = False
            Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Me.tbtnPosting.Caption = "Approve"
            Me.tbtnUnposting.Caption = "Disapprove"

            Me.ftabMain.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub btnRekanan_Click(sender As Object, e As EventArgs) Handles btnRekanan.Click
        Dim rekanan_id As String
        Dim dlg As dlgSearch = New dlgSearch()
        Dim retData As String
        retData = dlg.OpenDialog(Me, Me.tbl_MstRekanan.Copy, "rekanan")
        rekanan_id = retData

        If rekanan_id IsNot Nothing Then
            Me.txtSrchRekananID.Text = rekanan_id
        End If
    End Sub

    Private Sub ftabMain_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles ftabMain.SelectedPageChanged
        Select Case ftabMain.SelectedTabPageIndex
            Case 0
                Me.tbtnSave.Enabled = False
                Me.tbtnDel.Enabled = False
                Me.tbtnLoad.Enabled = True
                Me.tbtnQuery.Enabled = True
                Me.btnNewClick = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.White
                Me.ftabMain.TabPages.Item(1).BackColor = Color.Gainsboro
                Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Me.tbtnPosting.Enabled = False
                Me.tbtnUnposting.Enabled = False
            Case 1
                Me.tbtnSave.Enabled = True
                Me.tbtnDel.Enabled = True
                Me.tbtnLoad.Enabled = False
                Me.tbtnQuery.Enabled = False
                Me.ftabMain.TabPages.Item(0).BackColor = Color.Gainsboro
                Me.ftabMain.TabPages.Item(1).BackColor = Color.White
                Me.objFormError.Clear()
                Me.tbtnPosting.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Me.tbtnUnposting.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Me.tbtnPosting.Enabled = True
                Me.tbtnUnposting.Enabled = False

                Me.EnableDisable(True)
                If Me.btnNewClick = True Then
                    Me.uiTrnPenerimaanBarang_NewData()
                Else
                    If Me.GVRVRakitan.FocusedColumn IsNot Nothing Then
                        If GVRVRakitan.RowCount > 0 Then
                            Me.uiTrnPenerimaanBarang_OpenRow(Me.GVRVRakitan.FocusedRowHandle)
                            Me.btnNewClick = False
                        Else
                            Me.btnNewClick = True
                            Me.uiTrnPenerimaanBarang_NewData()
                        End If
                    Else
                        Me.btnNewClick = True
                        Me.uiTrnPenerimaanBarang_NewData()
                    End If
                End If
        End Select
    End Sub

    Private Function uiTrnPenerimaanBarang_OpenRow(ByVal rowIndex As Integer) As Boolean
        Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        'Dim dbConnAsset As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
        Dim terimabarang_id As String
        Dim channel_id As String
        Dim cookie As Byte() = Nothing
        ' Dim cookie1 As Byte() = Nothing
        terimabarang_id = Me.GVRVRakitan.GetRowCellValue(rowIndex, "terimabarang_id")
        channel_id = Me.GVRVRakitan.GetRowCellValue(rowIndex, "channel_id")

        ' If terimabarang_id IsNot Nothing Then
        Me.Cursor = Cursors.WaitCursor

        Try
            dbConn.Open()
            ' dbConnAsset.Open()
            clsApplicationRole.SetAppRole(dbConn, cookie)
            ' clsApplicationRole.SetAppRole(dbConnAsset, cookie1)

            Me.uiTrnPenerimaanBarang_OpenRowMaster(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_OpenRowDetil(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_OpenRowJurnal(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_Purchase_OpenRowJurnalDetil_kredit(channel_id, terimabarang_id, dbConn)
            Me.uiTrnPenerimaanBarang_Purchase_OpenRowJurnalDetil_Debet(channel_id, terimabarang_id, dbConn)

        Catch ex As Exception
            MessageBox.Show(ex.Message, mUiName & ": uiTrnPenerimaanBarang_OpenRow()", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, cookie)
            'clsApplicationRole.UnsetAppRole(dbConnAsset, cookie1)
            dbConn.Close()
            'dbConnAsset.Close()
        End Try

        Me.Cursor = Cursors.Arrow
        '     End If

        Return True

    End Function

    Private Function uiTrnPenerimaanBarang_OpenRowMaster(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim tbl_strukturunitRV As DataTable = New DataTable

        Me.tbl_TrnPenerimaanbarang_Temp.Clear()

        Try
            Me.BindingStop()

            Dim criteria As String = String.Format(" and terimabarang_id='{0}'", terimabarang_id)
            Using receive As New clsTrnPenerimaanBarang(Me.DSNFrm)
                receive.RetrieveHeader(Me.tbl_TrnPenerimaanbarang_Temp, criteria, channel_id, 1)
            End Using

            Me.BindingStart()

            If Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc") = True Then
                Me.tbtnPosting.Enabled = False
                Me.tbtnUnposting.Enabled = True
                Me.EnableDisable(False)
            Else
                Me.tbtnPosting.Enabled = True
                Me.tbtnUnposting.Enabled = False
                Me.EnableDisable(True)
            End If

        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPenerimaanBarang_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try
    End Function

    Private Function uiTrnPenerimaanBarang_OpenRowDetil(ByVal channel_id As String, ByVal terimabarang_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("as_AssetKapitalDetil_Select", dbConn)

        dbCmd.Parameters.Add("@Criteria", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("A.terimabarang_id='{0}'", terimabarang_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnPenerimaanbarangdetil.Clear()

        Me.tbl_TrnPenerimaanbarangdetil = clsDataset.CreateTblViewTrnTerimabarangDetil()
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarang_id").DefaultValue = terimabarang_id
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrement = True
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_line").AutoIncrementStep = 10
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_date").DefaultValue = Now.Date
        Me.tbl_TrnPenerimaanbarangdetil.Columns("terimabarangdetil_type").DefaultValue = "LISTRV"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("channel_id").DefaultValue = Me._CHANNEL
        Me.tbl_TrnPenerimaanbarangdetil.Columns("item_id").DefaultValue = "0"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("itemcategory_id").DefaultValue = "0"
        Me.tbl_TrnPenerimaanbarangdetil.Columns("brand_id").DefaultValue = "0"

        Try
            dbDA.Fill(Me.tbl_TrnPenerimaanbarangdetil)
            Me.GCRVDetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil

            If Me.tbl_TrnPenerimaanbarangdetil.Rows.Count > 0 Then
                'GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                'GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                Me.MenuRVRakitan.Enabled = False
            Else
                'GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                'GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
                Me.MenuRVRakitan.Enabled = True
            End If


        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnPenerimaanBarang_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnPenerimaanBarang_OpenRowJurnal(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        Dim table_budget_temps As DataTable = New DataTable

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnal_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("jurnal_id='{0}'", jurnal_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)
        Me.tbl_TrnJurnal.Clear()

        Try
            Me.BindingStopJurnal()
            dbDA.Fill(Me.tbl_TrnJurnal)
            Me.BindingStartJurnal()
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowMaster()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnPenerimaanBarang_Purchase_OpenRowJurnalDetil_kredit(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnaldetil_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("jurnal_id='{0}' AND jurnaldetil_dk='K'", jurnal_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_TrnJurnaldetil_kredit.Clear()
        Me.tbl_TrnJurnaldetil_kredit = clsDataset.CreateTblTrnJurnaldetil() 'clsDataset.CreateTblTrnJurnaldetilPembayaran()
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnal_id").DefaultValue = Mid(jurnal_id, 1, 8) & Mid(jurnal_id, 12, 4)
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").AutoIncrementSeed = 5
        Me.tbl_TrnJurnaldetil_kredit.Columns("jurnaldetil_line").AutoIncrementStep = 10

        Try
            dbDA.Fill(Me.tbl_TrnJurnaldetil_kredit)
            Me.uiTrnJurnal_TblDetilInverse(Me.tbl_TrnJurnaldetil_kredit)
            Me.tbl_TrnJurnaldetil_kredit.AcceptChanges()
            Me.GCJurnalKredit.DataSource = Me.tbl_TrnJurnaldetil_kredit

        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowDetil_JdwPembayaran()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Function uiTrnPenerimaanBarang_Purchase_OpenRowJurnalDetil_Debet(ByVal channel_id As String, ByVal jurnal_id As String, ByVal dbConn As OleDb.OleDbConnection) As Boolean
        Dim dbCmd As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        dbCmd = New OleDb.OleDbCommand("act_TrnJurnaldetil_Select", dbConn)
        dbCmd.Parameters.Add("@channel_id", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@channel_id").Value = channel_id
        dbCmd.Parameters.Add("@Criteria", System.Data.OleDb.OleDbType.VarChar)
        dbCmd.Parameters("@Criteria").Value = String.Format("jurnal_id='{0}' AND jurnaldetil_dk='D'", jurnal_id)
        dbCmd.CommandType = CommandType.StoredProcedure
        dbDA = New OleDb.OleDbDataAdapter(dbCmd)

        Me.tbl_TrnJurnaldetil_debet.Clear()
        Me.tbl_TrnJurnaldetil_debet = clsDataset.CreateTblTrnJurnaldetil()
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnal_id").DefaultValue = jurnal_id
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").DefaultValue = DBNull.Value
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").AutoIncrement = True
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").AutoIncrementSeed = 10
        Me.tbl_TrnJurnaldetil_debet.Columns("jurnaldetil_line").AutoIncrementStep = 10
        Me.tbl_TrnJurnaldetil_debet.Columns("acc_id").DefaultValue = ""

        Try
            dbDA.Fill(Me.tbl_TrnJurnaldetil_debet)
            Me.GCJurnalDebit.DataSource = Me.tbl_TrnJurnaldetil_debet
        Catch ex As Exception
            Throw New Exception(mUiName & ": uiTrnJurnal_OpenRowDetil()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub GVRVDetil_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVRVDetil.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "terimabarangdetil_idrreal" Then
            If e.RowHandle >= 0 Then
                Me.tbl_TrnPenerimaanbarangdetil.Rows(e.RowHandle).Item("terimabarangdetil_totalidrreal") = e.Value * Me.tbl_TrnPenerimaanbarangdetil.Rows(e.RowHandle).Item("terimabarangdetil_foreignrate")
            End If
        End If
    End Sub

    Private Sub GVRVDetil_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GVRVDetil.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.RowCount >= 1 Then
            view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            view.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        Else
            view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            view.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        End If
    End Sub

    Private Sub GVRVDetil_KeyDown(sender As Object, e As KeyEventArgs) Handles GVRVDetil.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            Dim result As Boolean = False

            If Me.txtRvID.Text <> String.Empty Then
                Exit Sub
            End If

            If (MessageBox.Show("Delete row?", "Confirmation", _
                MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return

            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            view.DeleteRow(view.FocusedRowHandle)
            'view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            'view.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True

        End If
    End Sub

#Region "Save Data"

    Private Function uiTrnPenerimaanBarang_Save() As Boolean
        'save data
        Dim tbl_TrnPenerimaanbarang_Temp_Changes As DataTable
        Dim tbl_TrnPenerimaanbarangdetil_Changes As DataTable
        Dim success As Boolean
        Dim terimabarang_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor

        Me.BindingContext(Me.tbl_TrnPenerimaanbarang_Temp).EndCurrentEdit()
        tbl_TrnPenerimaanbarang_Temp_Changes = Me.tbl_TrnPenerimaanbarang_Temp.GetChanges()

        Me.GVRVDetil.CloseEditor()
        '==============================================================================================================================================================
        Me.BindingContext(Me.tbl_TrnPenerimaanbarangdetil).EndCurrentEdit()
        tbl_TrnPenerimaanbarangdetil_Changes = Me.tbl_TrnPenerimaanbarangdetil.GetChanges()


        If tbl_TrnPenerimaanbarang_Temp_Changes IsNot Nothing Or tbl_TrnPenerimaanbarangdetil_Changes IsNot Nothing Then
            Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
            Dim dbTrans As OleDb.OleDbTransaction = Nothing
            Dim cookie As Byte() = Nothing
            Try
                dbConn.Open()
                dbTrans = dbConn.BeginTransaction
                clsApplicationRole.SetAppRole(dbConn, dbTrans, cookie)

                MasterDataState = tbl_TrnPenerimaanbarang_Temp.Rows(0).RowState
                terimabarang_id = tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_id")

                If tbl_TrnPenerimaanbarang_Temp_Changes IsNot Nothing Then
                    success = Me.uiTrnPenerimaanBarang_SaveMaster(dbConn, dbTrans, terimabarang_id, tbl_TrnPenerimaanbarang_Temp_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnPenerimaanBarang_SaveMaster(tbl_TrnPenerimaanbarang_Temp_Changes)")
                    Me.tbl_TrnPenerimaanbarang_Temp.AcceptChanges()
                End If

                If tbl_TrnPenerimaanbarangdetil_Changes IsNot Nothing Then
                    For i = 0 To Me.tbl_TrnPenerimaanbarangdetil.Rows.Count - 1
                        If Me.tbl_TrnPenerimaanbarangdetil.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnPenerimaanbarangdetil.Rows(i).Item("terimabarang_id") = terimabarang_id
                        End If
                    Next
                    success = Me.uiTrnPenerimaanBarang_SaveDetil(dbConn, dbTrans, terimabarang_id, tbl_TrnPenerimaanbarangdetil_Changes)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnPenerimaanBarang_SaveDetil(tbl_TrnPenerimaanbarangdetil_Changes)")

                    For i = 0 To Me.tbl_TrnPenerimaanbarangdetil.Rows.Count - 1
                        If Me.tbl_TrnPenerimaanbarangdetil.Rows(i).RowState = DataRowState.Added Then
                            Dim terimabarangdetil_line As Integer = Me.GVRVDetil.GetRowCellValue(0, "terimabarangdetil_line")
                            success = uiTrnPenerimaanBarangReference_Save(dbConn, dbTrans, "INSERT", terimabarang_id, terimabarangdetil_line)

                            If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnPenerimaanBarangReference_Save(INSERT)")
                        End If
                    Next

                    Me.tbl_TrnPenerimaanbarangdetil.AcceptChanges()
                End If

                dbTrans.Commit()
                result = FormSaveResult.SaveSuccess

                Me.terimabarang_id = terimabarang_id 'Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_id")

                'If MasterDataState = DataRowState.Added Then
                '    Dim addRows As DataRow = Me.tbl_TrnJurnal.NewRow
                '    addRows("jurnal_id") = Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_id")
                '    addRows("jurnal_source") = "RV-LISTRV"
                '    addRows("jurnaltype_id") = "RV"
                '    Me.tbl_TrnJurnal.Rows.Add(addRows)
                '    'Else
                '    '    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id") = Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_id")
                '    '    Me.tbl_TrnJurnal.Rows(0).Item("jurnal_source") = "RV-LISTRV"
                '    '    Me.tbl_TrnJurnal.Rows(0).Item("jurnaltype_id") = "RV"
                'End If

                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                dbTrans.Rollback()
                result = FormSaveResult.SaveError
                Throw New Exception("Data Cannot Be Saved" & vbCrLf & ex.Message)
                'MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, dbTrans, cookie)
                dbConn.Close()
            End Try
        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        Me.Cursor = Cursors.Arrow
    End Function

    Private Function uiTrnPenerimaanBarang_SaveMaster(ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction, ByRef terimabarang_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_penerimaanbarang
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24, "terimabarang_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarang_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyitem", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyitem", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyrealization", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyrealization", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_status"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_statusrealization", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarang_statusrealization"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_location", System.Data.OleDb.OleDbType.VarWChar, 200, "terimabarang_location"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "terimabarang_notes"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_nosuratjalan", System.Data.OleDb.OleDbType.VarWChar, 70, "terimabarang_nosuratjalan"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_tglsuratjalan", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_tglsuratjalan"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_isdisabled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_createby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_createdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_modifiedby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appuser"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser_by", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appspv"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv_by", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appacc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc_by", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_cetakbpb", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_cetakbpb"))
        dbCmdInsert.Parameters("@terimabarang_createby").Value = Me.UserName
        dbCmdInsert.Parameters("@terimabarang_createdt").Value = Now()
        dbCmdInsert.Parameters("@terimabarang_modifiedby").Value = String.Empty
        dbCmdInsert.Parameters("@terimabarang_modifieddt").Value = DBNull.Value
        dbCmdInsert.Parameters("@terimabarang_appuser_by").Value = String.Empty
        dbCmdInsert.Parameters("@terimabarang_appuser_dt").Value = DBNull.Value
        dbCmdInsert.Parameters("@terimabarang_appspv_by").Value = String.Empty
        dbCmdInsert.Parameters("@terimabarang_appspv_dt").Value = DBNull.Value
        dbCmdInsert.Parameters("@terimabarang_appacc_by").Value = String.Empty
        dbCmdInsert.Parameters("@terimabarang_appacc_dt").Value = DBNull.Value

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnPenerimaanbarang_Update", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24, "terimabarang_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_date", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarang_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id_owner", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id_owner"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyitem", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyitem", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_qtyrealization", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_qtyrealization", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "order_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_status", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_status"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_statusrealization", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarang_statusrealization"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_location", System.Data.OleDb.OleDbType.VarWChar, 200, "terimabarang_location"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_notes", System.Data.OleDb.OleDbType.VarWChar, 4000, "terimabarang_notes"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_nosuratjalan", System.Data.OleDb.OleDbType.VarWChar, 70, "terimabarang_nosuratjalan"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_tglsuratjalan", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_tglsuratjalan"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_isdisabled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_createby", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_createby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_createdt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_createdt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_modifiedby", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_modifieddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appuser"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_appuser_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appuser_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_appuser_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appspv"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_appspv_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appspv_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_appspv_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarang_appacc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc_by", System.Data.OleDb.OleDbType.VarWChar, 32, "terimabarang_appacc_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_appacc_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarang_appacc_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_pph", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_pph", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_ppn", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_ppn", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarang_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_cetakbpb", System.Data.OleDb.OleDbType.Integer, 4, "terimabarang_cetakbpb"))
        dbCmdUpdate.Parameters("@terimabarang_modifiedby").Value = Me.UserName
        dbCmdUpdate.Parameters("@terimabarang_modifieddt").Value = Now()

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert

        Try
            dbDA.Update(objTbl)

            terimabarang_id = objTbl.Rows(0).Item("terimabarang_id")
            Me.tbl_TrnPenerimaanbarang_Temp.Clear()
            Me.tbl_TrnPenerimaanbarang_Temp.Merge(objTbl)

            If MasterDataState = DataRowState.Added Then
                Me.tbl_TrnPenerimaanbarang.Merge(objTbl)

                For i As Integer = 0 To Me.tbl_TrnPenerimaanbarangdetil.Rows.Count - 1
                    If Me.tbl_TrnPenerimaanbarangdetil.Rows(i).Item("terimabarang_id") = terimabarang_id Then
                        Me.GVRVRakitan.FocusedColumn = Me.tbl_TrnPenerimaanbarangdetil.Rows(i).Item("terimabarang_id")
                    End If
                Next
            ElseIf MasterDataState = DataRowState.Modified Then
                'Me.uiTrnPenerimaanBarang_UpdateList()
                Dim Row() As Data.DataRow
                Row = Me.tbl_TrnPenerimaanbarang.Select(String.Format("terimabarang_id = '{0}'", terimabarang_id))
                For Each col As DataColumn In Me.tbl_TrnPenerimaanbarang_Temp.Columns
                    Row(0)(col.ToString) = Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item(col.ToString)
                Next


                'Row(0)("Description") = Description
            End If
            Return True

        Catch ex As System.Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function

    Private Function uiTrnPenerimaanBarang_SaveDetil(ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction, ByRef terimabarang_id As Object, ByVal objTbl As DataTable) As Boolean
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter

        ' Save data: transaksi_penerimaanbarangdetil
        dbCmdInsert = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_parentline", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_parentline"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_desc", System.Data.OleDb.OleDbType.VarWChar, 510, "terimabarangdetil_desc"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_date", System.Data.OleDb.OleDbType.DBDate, 4, "terimabarangdetil_date"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarangdetil_type"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@assetcategory_id", System.Data.OleDb.OleDbType.VarWChar, 60, "assetcategory_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@assettype_id", System.Data.OleDb.OleDbType.VarWChar, 60, "assettype_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_barcode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_parentbarcode", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_parentbarcode"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemcategory_id", System.Data.OleDb.OleDbType.VarWChar, 60, "itemcategory_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemtype_id", System.Data.OleDb.OleDbType.VarWChar, 60, "itemtype_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_serial_no", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_serial_no"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_product_no", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_product_no"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_model", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_model"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@material_id", System.Data.OleDb.OleDbType.VarWChar, 60, "material_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@colour_id", System.Data.OleDb.OleDbType.VarWChar, 60, "colour_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@size_id", System.Data.OleDb.OleDbType.VarWChar, 60, "size_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sex_id", System.Data.OleDb.OleDbType.VarWChar, 30, "sex_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@room_id", System.Data.OleDb.OleDbType.VarWChar, 20, "room_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_rack", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarangdetil_rack"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qtydetail", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_qtydetail"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qtytotal", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_qtytotal"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "unit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimabarangdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimabarangdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_pphforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_pphidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_ppnforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_ppnidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_totalforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_totalforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_totalidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_totalidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_nonfixasset", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarangdetil_nonfixasset"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_golfiskal", System.Data.OleDb.OleDbType.VarWChar, 20, "terimabarangdetil_golfiskal"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_depre_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarangdetil_depre_enddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id_cont", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id_cont"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_eps", System.Data.OleDb.OleDbType.VarWChar, 20, "terimabarangdetil_eps"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 24, "writeoff_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "writeoff_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdInsert.Parameters("@terimabarang_id").Value = terimabarang_id
        dbCmdInsert.Parameters("@strukturunit_id").Value = Me._STRUKTUR_UNIT
        dbCmdInsert.Parameters("@create_by").Value = Me.UserName
        dbCmdInsert.Parameters("@create_dt").Value = Now()
        dbCmdInsert.Parameters("@modified_by").Value = String.Empty
        dbCmdInsert.Parameters("@modified_dt").Value = DBNull.Value

        dbCmdUpdate = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Update", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_parentline", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_parentline"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_desc", System.Data.OleDb.OleDbType.VarWChar, 510, "terimabarangdetil_desc"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_date", System.Data.OleDb.OleDbType.DBDate, 4, "terimabarangdetil_date"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_type", System.Data.OleDb.OleDbType.VarWChar, 30, "terimabarangdetil_type"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@assetcategory_id", System.Data.OleDb.OleDbType.VarWChar, 60, "assetcategory_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@assettype_id", System.Data.OleDb.OleDbType.VarWChar, 60, "assettype_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_barcode", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_barcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_parentbarcode", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarang_parentbarcode"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@item_id", System.Data.OleDb.OleDbType.VarWChar, 60, "item_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemcategory_id", System.Data.OleDb.OleDbType.VarWChar, 60, "itemcategory_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@itemtype_id", System.Data.OleDb.OleDbType.VarWChar, 60, "itemtype_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_serial_no", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_serial_no"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_product_no", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_product_no"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_model", System.Data.OleDb.OleDbType.VarWChar, 60, "terimabarangdetil_model"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@material_id", System.Data.OleDb.OleDbType.VarWChar, 60, "material_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@colour_id", System.Data.OleDb.OleDbType.VarWChar, 60, "colour_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@size_id", System.Data.OleDb.OleDbType.VarWChar, 60, "size_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@sex_id", System.Data.OleDb.OleDbType.VarWChar, 30, "sex_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@room_id", System.Data.OleDb.OleDbType.VarWChar, 20, "room_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_rack", System.Data.OleDb.OleDbType.VarWChar, 40, "terimabarangdetil_rack"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qty", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_qty", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qtydetail", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_qtydetail"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_qtytotal", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_qtytotal"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@unit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "unit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_idrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_idrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphpercent", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimabarangdetil_pphpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnpercent", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(2, Byte), "terimabarangdetil_ppnpercent", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_disc", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_disc", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_pphforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_pphidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_pphidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_ppnforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_ppnidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_ppnidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_totalforeign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "terimabarangdetil_totalforeign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_totalidrreal", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "terimabarangdetil_totalidrreal", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_nonfixasset", System.Data.OleDb.OleDbType.Boolean, 1, "terimabarangdetil_nonfixasset"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_golfiskal", System.Data.OleDb.OleDbType.VarWChar, 20, "terimabarangdetil_golfiskal"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_depre_enddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "terimabarangdetil_depre_enddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@employee_id", System.Data.OleDb.OleDbType.VarWChar, 30, "employee_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@show_id_cont", System.Data.OleDb.OleDbType.VarWChar, 24, "show_id_cont"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_eps", System.Data.OleDb.OleDbType.VarWChar, 20, "terimabarangdetil_eps"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_id", System.Data.OleDb.OleDbType.VarWChar, 24, "writeoff_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@writeoff_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "writeoff_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@order_id", System.Data.OleDb.OleDbType.VarWChar, 24, "order_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@orderdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "orderdetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_by", System.Data.OleDb.OleDbType.VarWChar, 100, "create_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@create_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "create_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4))
        dbCmdUpdate.Parameters("@terimabarang_id").Value = terimabarang_id
        dbCmdUpdate.Parameters("@modified_by").Value = Me.UserName
        dbCmdUpdate.Parameters("@modified_dt").Value = Date.Now

        dbCmdDelete = New OleDb.OleDbCommand("as_TrnPenerimaanbarangdetil_Delete", dbConn, dbTrans)
        dbCmdDelete.CommandType = CommandType.StoredProcedure
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarang_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdDelete.Parameters.Add(New System.Data.OleDb.OleDbParameter("@terimabarangdetil_line", System.Data.OleDb.OleDbType.Integer, 4, "terimabarangdetil_line"))
        dbCmdDelete.Parameters("@terimabarang_id").Value = terimabarang_id

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.UpdateCommand = dbCmdUpdate
        dbDA.InsertCommand = dbCmdInsert
        dbDA.DeleteCommand = dbCmdDelete

        Try
            dbDA.Update(objTbl)
            Return True
        Catch ex As System.Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Function uiTrnPenerimaanBarangReference_Save(ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction, ByVal IsOperate As String, ByVal terimabarang_id As String, ByVal terimabarangdetil_line As Integer) As Boolean
        Dim cmd As OleDb.OleDbCommand
        Dim ref_id As String = Me.GVRVDetil.GetRowCellValue(0, "ref_id")
        Dim refdetil_line As Integer = Me.GVRVDetil.GetRowCellValue(0, "refdetil_line")
        Dim is_parent As Integer = Me.GVRVDetil.GetRowCellValue(0, "is_parent")

        If IsOperate = "INSERT" Then
            Try
                cmd = New OleDb.OleDbCommand("as_TrnAssetKapitalisasiRef_Insert", dbConn, dbTrans)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
                cmd.Parameters.AddWithValue("@terimabarangdetil_line", terimabarangdetil_line)
                cmd.Parameters.AddWithValue("@ref_id", ref_id)
                cmd.Parameters.AddWithValue("@refdetil_line", refdetil_line)
                cmd.Parameters.AddWithValue("@ref_id", is_parent)

                cmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                Return False
                Throw ex
            End Try
        Else
            Try
                cmd = New OleDb.OleDbCommand("as_TrnAssetKapitalisasiRef_Delete", dbConn, dbTrans)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
                cmd.Parameters.AddWithValue("@terimabarangdetil_line", terimabarangdetil_line)
                cmd.Parameters.AddWithValue("@ref_id", ref_id)
                cmd.Parameters.AddWithValue("@refdetil_line", refdetil_line)
                cmd.Parameters.AddWithValue("@ref_id", is_parent)

                cmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                Return False
                Throw ex
            End Try
        End If
    End Function

    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSave() As Boolean
        'save data
        Dim tbl_TrnJurnal_Changes As DataTable = New DataTable
        Dim tbl_JurnalReference_Changes As DataTable = New DataTable
        Dim tbl_TrnJurnaldetil_kredit_Changes As DataTable = New DataTable
        Dim tbl_TrnJurnaldetil_debet_Changes As DataTable = New DataTable
        Dim success As Boolean
        Dim jurnal_id As Object = New Object
        Dim channel_id As Object = New Object
        Dim i As Integer = 0
        Dim MasterDataState As System.Data.DataRowState
        Dim result As FormSaveResult

        Me.Cursor = Cursors.WaitCursor

        Me.BindingContext(Me.tbl_TrnJurnal).EndCurrentEdit()

        Me.GVJurnalKredit.CloseEditor()
        Me.BindingContext(Me.tbl_TrnJurnaldetil_kredit).EndCurrentEdit()
        tbl_TrnJurnaldetil_kredit_Changes = Me.tbl_TrnJurnaldetil_kredit.GetChanges()

        Me.GVJurnalDebit.CloseEditor()
        Me.BindingContext(Me.tbl_TrnJurnaldetil_debet).EndCurrentEdit()
        tbl_TrnJurnaldetil_debet_Changes = Me.tbl_TrnJurnaldetil_debet.GetChanges()

        Me.BindingContext(Me.tbl_TrnJurnal).EndCurrentEdit()
        tbl_TrnJurnal_Changes = Me.tbl_TrnJurnal.GetChanges()

        If tbl_TrnJurnal_Changes IsNot Nothing Or tbl_TrnJurnaldetil_kredit_Changes IsNot Nothing Or tbl_TrnJurnaldetil_debet_Changes IsNot Nothing Then
            Dim dbConn As OleDb.OleDbConnection = New OleDb.OleDbConnection(Me.DSNFrm)
            Dim dbTrans As OleDb.OleDbTransaction = Nothing
            Dim cookie As Byte() = Nothing
            Try
                dbConn.Open()
                dbTrans = dbConn.BeginTransaction
                clsApplicationRole.SetAppRole(dbConn, dbTrans, cookie)
                MasterDataState = tbl_TrnJurnal.Rows(0).RowState
                If MasterDataState = DataRowState.Added Then
                    jurnal_id = Me.terimabarang_id 'Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_id")
                    channel_id = Me._CHANNEL
                    tbl_TrnJurnal_Changes.Rows(0).Item("jurnal_id") = Me.terimabarang_id
                    tbl_TrnJurnal_Changes.Rows(0).Item("created_by") = Me.UserName
                    tbl_TrnJurnal_Changes.Rows(0).Item("created_dt") = Now()
                Else
                    jurnal_id = clsUtil.IsDbNull(Me.tbl_TrnJurnal.Rows(0).Item("jurnal_id"), Me.txtRvID.Text)
                    channel_id = Me.tbl_TrnJurnal.Rows(0).Item("channel_id")
                End If


                If tbl_TrnJurnal_Changes IsNot Nothing Then
                    tbl_TrnJurnal_Changes.Rows(0).Item("modified_by") = Me.UserName
                    tbl_TrnJurnal_Changes.Rows(0).Item("modified_dt") = Now()

                    success = Me.uiTrnPenerimaanBarang_Purchase_JurnalSaveMaster(dbConn, dbTrans, tbl_TrnJurnal_Changes)
                    If Not success Then Throw New Exception("Error: Saving Master Data at Me.uiTrnJurnal_SaveMaster(tbl_TrnJurnal_Temp_Changes)")
                    Me.tbl_TrnJurnal.AcceptChanges()
                End If

                If tbl_TrnJurnaldetil_kredit_Changes IsNot Nothing Then
                    Dim nrow1_GVJurnalKredit = Me.GVJurnalKredit.RowCount

                    For i = 0 To Me.tbl_TrnJurnaldetil_kredit.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_kredit.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnJurnaldetil_kredit.Rows(i).Item("jurnal_id") = jurnal_id
                            Me.tbl_TrnJurnaldetil_kredit.Rows(i).Item("channel_id") = channel_id
                        End If
                    Next

                    Me.uiTrnJurnal_TblDetilInverse(tbl_TrnJurnaldetil_kredit_Changes)
                    success = Me.uiTrnPenerimaanBarang_Purchase_JurnalSaveDetilKredit(dbConn, dbTrans, jurnal_id, tbl_TrnJurnaldetil_kredit_Changes)
                    If Not success Then Throw New Exception("Error: Save Detil Data at Me.uiTrnJurnal_SaveDetil(tbl_TrnJurnaldetil_Changes)")
                    Me.tbl_TrnJurnaldetil_kredit.AcceptChanges()

                    Dim nrow2_GVJurnalKredit = Me.GVJurnalKredit.RowCount
                    Dim nrow As Integer

                    For nrow = nrow1_GVJurnalKredit To nrow2_GVJurnalKredit - 1
                        Me.GVJurnalKredit.DeleteRow(nrow - 1)
                    Next
                End If

                If tbl_TrnJurnaldetil_debet_Changes IsNot Nothing Then

                    Dim nrow1_GVJurnalDebit = Me.GVJurnalDebit.RowCount

                    For i = 0 To Me.tbl_TrnJurnaldetil_debet.Rows.Count - 1
                        If Me.tbl_TrnJurnaldetil_debet.Rows(i).RowState = DataRowState.Added Then
                            Me.tbl_TrnJurnaldetil_debet.Rows(i).Item("jurnal_id") = jurnal_id
                            Me.tbl_TrnJurnaldetil_debet.Rows(i).Item("channel_id") = channel_id
                        End If
                    Next
                    success = Me.uiTrnPenerimaanBarang_Purchase_JurnalSaveDetilDebet(dbConn, dbTrans, jurnal_id, tbl_TrnJurnaldetil_debet_Changes, MasterDataState)
                    If Not success Then Throw New Exception("Error: Save DetilJadwalPembayaran Data at Me.uiTrnJurnal_SaveDetil(tbl_TrnJurnaldetil_Changes)")
                    Me.tbl_TrnJurnaldetil_debet.AcceptChanges()

                    Dim nrow2_DGvJurnalDebit = Me.GVJurnalDebit.RowCount
                    Dim nrow As Integer

                    For nrow = nrow1_GVJurnalDebit To nrow2_DGvJurnalDebit - 1
                        Me.GVJurnalDebit.DeleteRow(nrow - 1)
                    Next
                End If

                dbTrans.Commit()
                result = FormSaveResult.SaveSuccess
                If SHOW_SAVE_CONFIRMATION Then
                    MessageBox.Show("Data Journal Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' ''MessageBox.Show("Data Saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                dbTrans.Rollback()
                result = FormSaveResult.SaveError
                Throw New Exception("Data Journal Cannot Be Save" & vbCrLf & ex.Message)
                'MessageBox.Show("Data Cannot Be Saved" & vbCrLf & ex.Message, mUiName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                clsApplicationRole.UnsetAppRole(dbConn, dbTrans, cookie)
                dbConn.Close()
            End Try
        Else
            result = FormSaveResult.Nochanges
            If SHOW_SAVE_CONFIRMATION Then
                MessageBox.Show("Journal All changes has been saved", mUiName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If


        Me.Cursor = Cursors.Arrow

    End Function

    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSaveMaster(ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction, ByVal objTbl As DataTable) As Boolean
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbDA As OleDb.OleDbDataAdapter
        ' ''Dim curpos As Integer

        ' Save data: transaksi_jurnal
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnalTerimaOrder_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_bookdate", System.Data.OleDb.OleDbType.DBDate, 4, "jurnal_bookdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_duedate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_duedate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_billdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_billdate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnal_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_invoice_id", System.Data.OleDb.OleDbType.VarWChar, 40, "jurnal_invoice_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_invoice_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnal_invoice_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_source", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnal_source"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaltype_id", System.Data.OleDb.OleDbType.VarWChar, 4, "jurnaltype_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@periode_id", System.Data.OleDb.OleDbType.VarWChar, 8, "periode_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "currency_rate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "acc_ca_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advertiser_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "advertiser_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ae_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "ae_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreated", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_iscreated"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreatedby", System.Data.OleDb.OleDbType.VarWChar, 100, "jurnal_iscreatedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreatedate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_iscreatedate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isposted", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isposted"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_ispostedby", System.Data.OleDb.OleDbType.VarWChar, 100, "jurnal_ispostedby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isposteddate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_isposteddate"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isdisabled"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabledby", System.Data.OleDb.OleDbType.VarWChar, 32, "jurnal_isdisabledby"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisableddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_isdisableddt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_by", System.Data.OleDb.OleDbType.VarWChar, 100, "created_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "created_dt"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100, "modified_by"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "modified_dt"))

        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnJurnal_Update", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24, "jurnal_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_bookdate", System.Data.OleDb.OleDbType.DBDate, 4, "jurnal_bookdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_duedate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_duedate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_billdate", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_billdate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnal_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_invoice_id", System.Data.OleDb.OleDbType.VarWChar, 40, "jurnal_invoice_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_invoice_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnal_invoice_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_source", System.Data.OleDb.OleDbType.VarWChar, 60, "jurnal_source"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaltype_id", System.Data.OleDb.OleDbType.VarWChar, 4, "jurnaltype_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@periode_id", System.Data.OleDb.OleDbType.VarWChar, 8, "periode_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_rate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "currency_rate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_ca_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "acc_ca_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@advertiser_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "advertiser_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@brand_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(5, Byte), CType(0, Byte), "brand_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ae_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "ae_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreated", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_iscreated"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreatedby", System.Data.OleDb.OleDbType.VarWChar, 100, "jurnal_iscreatedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_iscreatedate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_iscreatedate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isposted", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isposted"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_ispostedby", System.Data.OleDb.OleDbType.VarWChar, 100, "jurnal_ispostedby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isposteddate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "jurnal_isposteddate"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabled", System.Data.OleDb.OleDbType.Boolean, 1, "jurnal_isdisabled"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisabledby", System.Data.OleDb.OleDbType.VarWChar, 32, "jurnal_isdisabledby"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_isdisableddt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "jurnal_isdisableddt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_by", System.Data.OleDb.OleDbType.VarWChar, 100, "created_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@created_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "created_dt"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_by", System.Data.OleDb.OleDbType.VarWChar, 100, "modified_by"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@modified_dt", System.Data.OleDb.OleDbType.DBTimeStamp, 4, "modified_dt"))

        dbDA = New OleDb.OleDbDataAdapter
        dbDA.InsertCommand = dbCmdInsert
        dbDA.UpdateCommand = dbCmdUpdate

        Try
            dbDA.Update(objTbl)
            Return True
        Catch ex As System.Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function

    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSaveDetilDebet(ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction, ByRef jurnal_id As Object, ByVal objTbl As DataTable, ByVal MasterDataState As System.Data.DataRowState) As Boolean
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDAUpdateDetil As OleDb.OleDbDataAdapter

        ' Save data: Transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnaldetil_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnaldetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_name", System.Data.OleDb.OleDbType.VarWChar, 200, "rekanan_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 24, "ref_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "ref_budgetline"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 100, "budget_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_name", System.Data.OleDb.OleDbType.VarWChar, 200, "budgetdetil_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@jurnaldetil_dk").Value = "D"
        dbCmdInsert.Parameters("@username").Value = Me.UserName
        dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL

        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnJurnaldetil_Update", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnaldetil_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_name", System.Data.OleDb.OleDbType.VarWChar, 200, "rekanan_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 24, "ref_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "ref_budgetline"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 100, "budget_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_name", System.Data.OleDb.OleDbType.VarWChar, 200, "budgetdetil_name"))
        dbCmdUpdate.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdUpdate.Parameters("@jurnaldetil_dk").Value = "D"

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnaldetil_Delete", dbConn, dbTrans)
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
            dbDAUpdateDetil.Update(objTbl)
            Return True
        Catch ex As System.Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Function uiTrnPenerimaanBarang_Purchase_JurnalSaveDetilKredit(ByVal dbConn As OleDb.OleDbConnection, ByVal dbTrans As OleDb.OleDbTransaction, ByRef jurnal_id As Object, ByVal objTbl As DataTable) As Boolean
        Dim dbCmdInsert As OleDb.OleDbCommand
        Dim dbCmdUpdate As OleDb.OleDbCommand
        Dim dbCmdDelete As OleDb.OleDbCommand
        Dim dbDAUpdateDetil As OleDb.OleDbDataAdapter

        ' Save data: Transaksi_jurnaldetil
        dbCmdInsert = New OleDb.OleDbCommand("act_TrnJurnaldetil_Insert", dbConn, dbTrans)
        dbCmdInsert.CommandType = CommandType.StoredProcedure
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnaldetil_descr"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_name", System.Data.OleDb.OleDbType.VarWChar, 200, "rekanan_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 24, "ref_id"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "ref_budgetline"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 100, "budget_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_name", System.Data.OleDb.OleDbType.VarWChar, 200, "budgetdetil_name"))
        dbCmdInsert.Parameters.Add(New System.Data.OleDb.OleDbParameter("@username", System.Data.OleDb.OleDbType.VarWChar, 32))
        dbCmdInsert.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdInsert.Parameters("@jurnaldetil_dk").Value = "K"
        dbCmdInsert.Parameters("@username").Value = Me.UserName
        dbCmdInsert.Parameters("@channel_id").Value = Me._CHANNEL


        dbCmdUpdate = New OleDb.OleDbCommand("act_TrnJurnaldetil_Update", dbConn, dbTrans)
        dbCmdUpdate.CommandType = CommandType.StoredProcedure
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnal_id", System.Data.OleDb.OleDbType.VarWChar, 24))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_line", System.Data.OleDb.OleDbType.Integer, 4, "jurnaldetil_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_dk", System.Data.OleDb.OleDbType.VarWChar, 2))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_descr", System.Data.OleDb.OleDbType.VarWChar, 4000, "jurnaldetil_descr"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_id", System.Data.OleDb.OleDbType.Decimal, 8, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "rekanan_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@rekanan_name", System.Data.OleDb.OleDbType.VarWChar, 200, "rekanan_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@acc_id", System.Data.OleDb.OleDbType.VarWChar, 14, "acc_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@currency_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(3, Byte), CType(0, Byte), "currency_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreign", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreign", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_foreignrate", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "jurnaldetil_foreignrate", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@jurnaldetil_idr", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(0, Byte), "jurnaldetil_idr", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@channel_id", System.Data.OleDb.OleDbType.VarWChar, 20, "channel_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@strukturunit_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(6, Byte), CType(0, Byte), "strukturunit_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_id", System.Data.OleDb.OleDbType.VarWChar, 24, "ref_id"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_line", System.Data.OleDb.OleDbType.Integer, 4, "ref_line"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@ref_budgetline", System.Data.OleDb.OleDbType.Integer, 4, "ref_budgetline"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@region_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "region_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@branch_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(7, Byte), CType(0, Byte), "branch_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_id", System.Data.OleDb.OleDbType.Decimal, 5, System.Data.ParameterDirection.Input, False, CType(8, Byte), CType(0, Byte), "budget_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budget_name", System.Data.OleDb.OleDbType.VarWChar, 100, "budget_name"))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_id", System.Data.OleDb.OleDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(12, Byte), CType(0, Byte), "budgetdetil_id", System.Data.DataRowVersion.Current, Nothing))
        dbCmdUpdate.Parameters.Add(New System.Data.OleDb.OleDbParameter("@budgetdetil_name", System.Data.OleDb.OleDbType.VarWChar, 200, "budgetdetil_name"))
        dbCmdUpdate.Parameters("@jurnal_id").Value = jurnal_id
        dbCmdUpdate.Parameters("@jurnaldetil_dk").Value = "K"

        dbCmdDelete = New OleDb.OleDbCommand("act_TrnJurnaldetil_Delete", dbConn, dbTrans)
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
            dbDAUpdateDetil.Update(objTbl)
            Return True
        Catch ex As System.Data.OleDb.OleDbException
            MessageBox.Show(ex.Message, "OLE DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function

    Private Function uiTrnPenerimaanBarang_Delete() As Boolean
        If Me.tbl_TrnPenerimaanbarang_Temp.Rows.Count > 0 Then
            If Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc") = True Then
                MsgBox("Tidak dapat dihapus !!" + vbCrLf + "Disapprove data terlebih dulu.", MsgBoxStyle.Exclamation, mUiName)
                Exit Function
            End If

            Dim dbConn As New OleDb.OleDbConnection(Me.DSNFrm)
            Dim dbCmdDelete As OleDb.OleDbCommand
            Dim cookie As Byte() = Nothing
            Try
                dbConn.Open()
                clsApplicationRole.SetAppRole(dbConn, cookie)
                Dim terimabarang_id As String = Me.txtRvID.Text
                Dim terimabarangdetil_line As Int16 = Me.GVRVDetil.GetRowCellValue(Me.GVRVDetil.FocusedRowHandle, "terimabarangdetil_line")

                ' Save data: transaksi_penerimaanbarang
                dbCmdDelete = New OleDb.OleDbCommand("as_TrnAsset_RVListRV_DELETE", dbConn)
                dbCmdDelete.CommandType = CommandType.StoredProcedure
                dbCmdDelete.Parameters.AddWithValue("@terimabarang_id", terimabarang_id)
                dbCmdDelete.Parameters.AddWithValue("@@terimabarangdetil_line", terimabarangdetil_line)
                dbCmdDelete.ExecuteNonQuery()
                clsApplicationRole.UnsetAppRole(dbConn, cookie)
                dbConn.Close()

                Me.ftabMain.SelectedTabPageIndex = 0
                Me.tbtnLoad.PerformClick()
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Function

#End Region

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

    Private Sub uiTrnPenerimaanBarang_UpdateList()
        'Dim listRow As DataRow = CType(Me.GVRVRakitan.GetRow(Me.GVRVRakitan.FocusedRowHandle), DataRowView).Row
        'Dim terimabarang_id As String = Me.txtRvID.Text
        'listRow.ItemArray = New clsTrnPenerimaanBarang(Me.DSNAsset).SelectHeader(terimabarang_id, Me._CHANNEL).ItemArray
        'listRow.AcceptChanges()
    End Sub

    Private Sub uiTrnPenerimaanBarangListRV_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.IsDevelopment = True Then Me.Form_Load(sender)
    End Sub

    Private Sub btnAddCipAsset_Click(sender As Object, e As EventArgs) Handles btnAddCipAsset.Click
        If Me.tbl_TrnPenerimaanbarangdetil.Rows.Count <= 0 Then
            MsgBox("Masukan/Isi Data Detail terlebih dahulu !", MsgBoxStyle.Exclamation, mUiName)
            Exit Sub
        End If

        Dim dlg As New dlgAddRV_CIPAsset(Me.DSNFrm, Me._CHANNEL)
        Dim ret As New DataTable
        ret = dlg.OpenDialog(Me)

        If ret IsNot Nothing Then
            Me.Cursor = Cursors.WaitCursor
            For Each dtRows As DataRow In ret.Rows
                Dim ref_id As String = dtRows("jurnal_id")
                Dim ref_line As String = dtRows("jurnaldetil_line")
                'Dim dtCariRV As DataTable = Me.tbl_TrnJurnaldetil_kredit.Select(String.Format("ref_id = '{0}' AND ref_line = '{1}'", ref_id, ref_line)).CopyToDataTable
                Dim dtCariRV() As DataRow = Me.tbl_TrnJurnaldetil_kredit.Select(String.Format("ref_id = '{0}' AND ref_line = '{1}'", ref_id, ref_line))

                If dtCariRV.Length <= 0 Then
                    Dim addRows As DataRow
                    addRows = Me.tbl_TrnJurnaldetil_kredit.NewRow

                    addRows("jurnaldetil_dk") = "K"
                    addRows("jurnaldetil_descr") = dtRows("jurnaldetil_descr")
                    addRows("rekanan_id") = dtRows("rekanan_id")
                    addRows("rekanan_name") = dtRows("rekanan_name")
                    addRows("acc_id") = dtRows("acc_id")
                    addRows("currency_id") = 1 'dtRows("currency_id") SEMUA DIGANTI RUPIAH

                    If dtRows("currency_id") <> 1 Then
                        addRows("jurnaldetil_foreign") = dtRows("jurnaldetil_idr") 'Math.Round((dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate")), 0) 'dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate")
                        addRows("jurnaldetil_foreignrate") = 1
                        addRows("jurnaldetil_idr") = dtRows("jurnaldetil_idr") 'Math.Round((dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate")), 0)
                        'Me.txtJurnalAmountForeign.Text = Me.txtJurnalAmountForeign.Text + (dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate"))
                        'Me.txtJurnalAmountIDR.Text = Math.Round(Me.txtJurnalAmountIDR.Text + (dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate")), 0)
                    Else
                        addRows("jurnaldetil_foreign") = dtRows("jurnaldetil_foreign") 'Math.Round(dtRows("jurnaldetil_foreign"), 0)
                        addRows("jurnaldetil_foreignrate") = dtRows("jurnaldetil_foreignrate")
                        addRows("jurnaldetil_idr") = dtRows("jurnaldetil_idr") 'Math.Round(dtRows("jurnaldetil_idr"), 0)
                        'Me.txtJurnalAmountForeign.Text = Me.txtJurnalAmountForeign.Text + dtRows("jurnaldetil_idr")
                        'Me.txtJurnalAmountIDR.Text = Math.Round(Me.txtJurnalAmountIDR.Text + dtRows("jurnaldetil_idr"), 0)
                    End If

                    addRows("channel_id") = dtRows("channel_id")
                    addRows("strukturunit_id") = dtRows("strukturunit_id")
                    addRows("ref_id") = dtRows("jurnal_id")
                    addRows("ref_line") = dtRows("jurnaldetil_line")
                    ' addRows("ref_budgetline") = dtRows("jurnaldetil_foreignrate")
                    addRows("region_id") = dtRows("region_id")
                    addRows("branch_id") = dtRows("branch_id")
                    addRows("budget_id") = dtRows("budget_id")
                    addRows("budget_name") = dtRows("budget_name")
                    addRows("budgetdetil_id") = dtRows("budgetdetil_id")
                    addRows("budgetdetil_name") = dtRows("budgetdetil_name")
                    Me.tbl_TrnJurnaldetil_kredit.Rows.Add(addRows)

                Else
                    MsgBox("Jurnal ID : " + dtRows("jurnal_id") + Chr(13) + "Line : " + dtRows("jurnaldetil_line").ToString + Chr(13) + "Sudah ditarik sebelumnya !!", MsgBoxStyle.Exclamation, mUiName)
                End If
            Next

            Me.GCJurnalKredit.DataSource = Me.tbl_TrnJurnaldetil_kredit

            Dim sumObject As Object
            Dim sumObjectIDR As Object
            sumObject = tbl_TrnJurnaldetil_kredit.Compute("Sum(jurnaldetil_foreign)", "")
            sumObjectIDR = tbl_TrnJurnaldetil_kredit.Compute("Sum(jurnaldetil_idr)", "")
            Me.txtJurnalAmountForeign.Text = sumObject 'Me.txtJurnalAmountForeign.Text + (dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate"))
            Me.txtJurnalAmountIDR.Text = sumObjectIDR 'Math.Round(Me.txtJurnalAmountIDR.Text + (dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate")), 0)

            Me.GVRVDetil.SetRowCellValue(0, "terimabarangdetil_idrreal", Me.txtJurnalAmountIDR.Text)
            Me.GVRVDetil.SetRowCellValue(0, "terimabarangdetil_totalidrreal", Me.txtJurnalAmountIDR.Text)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub RepositoryBtnRekanan_Click(sender As Object, e As EventArgs) Handles RepositoryBtnRekanan.Click
        Dim dlg As dlgSearch2 = New dlgSearch2()
        Dim retData As Collection
        Dim retObj As Object
        Dim rekanan_id, rekanan_name As String

        retObj = dlg.OpenDialog(Me, Me.tbl_MstRekanan.Copy, "rekanan")
        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            rekanan_id = CType(retData.Item("retId"), Decimal)
            rekanan_name = CType(retData.Item("retName"), String)

            Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "rekanan_id", rekanan_id)
            Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "rekanan_name", rekanan_name)

            'If GVJurnalDebit.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
            '    Dim row As DataRow
            '    row = CType(Me.BindingContext(Me.tbl_TrnJurnaldetil_debet).Current, DataRowView).Row
            '    row.Item("rekanan_id") = rekanan_id
            '    row.Item("rekanan_name") = rekanan_name
            'End If
        End If
    End Sub

    Private Sub RepositoryBtnAccId_Click(sender As Object, e As EventArgs) Handles RepositoryBtnAccId.Click
        Dim dlg As dlgSearch2 = New dlgSearch2()
        Dim retData As Collection
        Dim retObj As Object
        Dim acc_id As String

        retObj = dlg.OpenDialog(Me, Me.tbl_MstAcc.Copy, "account")
        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            acc_id = CType(retData.Item("retId"), Decimal)

            Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "acc_id", acc_id)
        End If

        'Dim dlg As dlgSearch2 = New dlgSearch2()
        'Dim retData As Collection
        'Dim retObj As Object
        'Dim acc_id As String

        'retObj = dlg.OpenDialog(Me, Me.tbl_MstAcc.Copy, "account")
        'If retObj IsNot Nothing Then
        '    retData = CType(retObj, Collection)
        '    acc_id = CType(retData.Item("retId"), Decimal)

        '    Dim rh = GVJurnalDebit.FocusedRowHandle
        '    If GVJurnalDebit.FocusedRowHandle >= 0 Then
        '        ' e.Cancel = True
        '        Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "acc_id", acc_id)
        '    Else
        '        Me.GVJurnalDebit.AddNewRow()
        '        Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "acc_id", acc_id)
        '    End If
        'End If
    End Sub

    Private Sub RepositoryBudget_Click(sender As Object, e As EventArgs) Handles RepositoryBudget.Click
        Dim dlg As dlgSearch2 = New dlgSearch2()
        Dim retData As Collection
        Dim retObj As Object
        Dim budget_id As String
        Dim budget_name As String

        retObj = dlg.OpenDialog(Me, Me.tbl_TrnBudget.Copy, "budget")
        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            budget_id = CType(retData.Item("retId"), Decimal)
            budget_name = CType(retData.Item("retName"), String)

            Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budget_id", budget_id)
            Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budget_name", budget_name)
        End If

        'Dim dlg As dlgSearch2 = New dlgSearch2()
        'Dim retData As Collection
        'Dim retObj As Object
        'Dim budget_id As String
        'Dim budget_name As String

        'retObj = dlg.OpenDialog(Me, Me.tbl_TrnBudget.Copy, "budget")
        'If retObj IsNot Nothing Then
        '    retData = CType(retObj, Collection)
        '    budget_id = CType(retData.Item("retId"), Decimal)
        '    budget_name = CType(retData.Item("retName"), String)

        '    Dim rh = GVJurnalDebit.FocusedRowHandle
        '    If GVJurnalDebit.FocusedRowHandle >= 0 Then
        '        ' e.Cancel = True
        '        Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budget_id", budget_id)
        '        Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budget_name", budget_name)
        '    Else
        '        Me.GVJurnalDebit.AddNewRow()
        '        Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budget_id", budget_id)
        '        Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budget_name", budget_name)
        '    End If
        'End If
    End Sub

    Private Sub RepositoryBudgetDetil_Click(sender As Object, e As EventArgs) Handles RepositoryBudgetDetil.Click
        Dim dlg As dlgSearch2 = New dlgSearch2()
        Dim retData As Collection
        Dim retObj As Object
        Dim budgetdetil_id As String
        Dim budget_name As String

        retObj = dlg.OpenDialog(Me, Me.tbl_TrnBudgetDetil.Copy, "budgetdetil")
        If retObj IsNot Nothing Then
            retData = CType(retObj, Collection)
            budgetdetil_id = CType(retData.Item("retId"), Decimal)
            budget_name = CType(retData.Item("retName"), String)

            Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budgetdetil_id", budgetdetil_id)
            Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budgetdetil_name", budget_name)
        End If

        'Dim dlg As dlgSearch2 = New dlgSearch2()
        'Dim retData As Collection
        'Dim retObj As Object
        'Dim budgetdetil_id As String
        'Dim budget_name As String

        'retObj = dlg.OpenDialog(Me, Me.tbl_TrnBudgetDetil.Copy, "budgetdetil")
        'If retObj IsNot Nothing Then
        '    retData = CType(retObj, Collection)
        '    budgetdetil_id = CType(retData.Item("retId"), Decimal)
        '    budget_name = CType(retData.Item("retName"), String)
        '    Dim rh = GVJurnalDebit.FocusedRowHandle
        '    If GVJurnalDebit.FocusedRowHandle >= 0 Then
        '        ' e.Cancel = True
        '        Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budgetdetil_id", budgetdetil_id)
        '        Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budgetdetil_name", budget_name)
        '    Else
        '        Me.GVJurnalDebit.AddNewRow()
        '        Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budgetdetil_id", budgetdetil_id)
        '        Me.GVJurnalDebit.SetRowCellValue(Me.GVJurnalDebit.FocusedRowHandle, "budgetdetil_name", budget_name)
        '    End If
        'End If
    End Sub

    Private Sub GVJurnalDebit_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GVJurnalDebit.CellValueChanged
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "jurnaldetil_foreign" Then
            Me.tbl_TrnJurnaldetil_debet.Rows(e.RowHandle).Item("jurnaldetil_idr") = e.Value * Me.tbl_TrnJurnaldetil_debet.Rows(e.RowHandle).Item("jurnaldetil_foreignrate")
        End If
    End Sub

    Private Sub GVJurnalDebit_KeyDown(sender As Object, e As KeyEventArgs) Handles GVJurnalDebit.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            view.DeleteRow(view.FocusedRowHandle)
            view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            view.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        End If
    End Sub

    Private Sub GVRVRakitan_DoubleClick(sender As Object, e As EventArgs) Handles GVRVRakitan.DoubleClick
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)

        DoRowDoubleClick(view, pt)
    End Sub

    Private Sub DoRowDoubleClick(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal pt As Point)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)

        If info.InRow OrElse info.InRowCell Then
            If view.FocusedColumn Is Nothing Or view.FocusedRowHandle < 0 Then
                Exit Sub
            End If

            If Me.GVRVRakitan.FocusedColumn IsNot Nothing Then
                Me.ftabMain.SelectedTabPageIndex = 1
            End If
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        'Me.GVJurnalDebit.AddNewRow()
        Me.tbl_TrnJurnaldetil_debet.Rows.Add()
    End Sub

    Private Sub GVJurnalKredit_KeyDown(sender As Object, e As KeyEventArgs) Handles GVJurnalKredit.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            'Me.txtJurnalAmountForeign.Text = Me.txtJurnalAmountForeign.Text - view.GetRowCellValue(view.FocusedRowHandle, "jurnaldetil_foreign")
            'Me.txtJurnalAmountIDR.Text = Me.txtJurnalAmountIDR.Text - view.GetRowCellValue(view.FocusedRowHandle, "jurnaldetil_idr")

            'Me.GVRVDetil.SetRowCellValue(0, "terimabarangdetil_idrreal", Me.txtJurnalAmountIDR.Text)
            'Me.GVRVDetil.SetRowCellValue(0, "terimabarangdetil_totalidrreal", Me.txtJurnalAmountIDR.Text)

            'Me.tbl_TrnJurnaldetil_kredit.Rows(view.FocusedRowHandle).Delete()

            view.DeleteRow(view.FocusedRowHandle)

            Dim sumObject As Object
            Dim sumObjectIDR As Object
            sumObject = tbl_TrnJurnaldetil_kredit.Compute("Sum(jurnaldetil_foreign)", "")
            sumObjectIDR = tbl_TrnJurnaldetil_kredit.Compute("Sum(jurnaldetil_idr)", "")
            Me.txtJurnalAmountForeign.Text = clsUtil.IsDbNull(sumObject, 0) 'Me.txtJurnalAmountForeign.Text + (dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate"))
            Me.txtJurnalAmountIDR.Text = clsUtil.IsDbNull(sumObjectIDR, 0) 'Math.Round(Me.txtJurnalAmountIDR.Text + (dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate")), 0)

            Me.GVRVDetil.SetRowCellValue(0, "terimabarangdetil_idrreal", Me.txtJurnalAmountIDR.Text)
            Me.GVRVDetil.SetRowCellValue(0, "terimabarangdetil_totalidrreal", Me.txtJurnalAmountIDR.Text)

            view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            view.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        End If
    End Sub

    Private Sub ApproveDisapprove(ByVal terimabarang_id As String, ByVal isApprove As Integer, ByVal terimabarang_appacc_by As String)
        If Me.uiTrnJurnal_RV_Rakitan_FormError() Then
            System.Windows.Forms.Cursor.Current = Cursors.Default
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim dbConn As New OleDb.OleDbConnection(Me.DSNFrm)
        Dim dbTrans As OleDb.OleDbTransaction = Nothing
        Dim cookie As Byte() = Nothing
        Try
            dbConn.Open()
            dbTrans = dbConn.BeginTransaction()
            clsApplicationRole.SetAppRole(dbConn, dbTrans, cookie)

            Using receive As New clsTrnPenerimaanBarang()
                If isApprove = 1 Then
                    If Me.tbl_TrnPenerimaanbarangdetil.Rows(0).Item("order_id") = String.Empty And _
                        Me.tbl_TrnPenerimaanbarangdetil.Rows(0).Item("terimabarang_barcode") = String.Empty Then
                        receive.CreateBarcode(terimabarang_id, dbConn, dbTrans)
                    End If
                End If
            End Using
            'dbConn.Close()

            'dbConn.Open()
            'Pakai Transaction
            Using receive2 As New clsTrnPenerimaanBarang(Me.DSNFrm)
                '===============================================================================================
                If isApprove = 1 Then
                    'approved 'unapproved
                    receive2.AccApproved(Me._CHANNEL, terimabarang_id, Me.UserName, dbConn, dbTrans)
                Else
                    receive2.AccUnapproved(Me._CHANNEL, terimabarang_id, Me.UserName, dbConn, dbTrans)
                End If

                receive2.UpdateValueAssetDepre(terimabarang_id, Me.tbl_TrnPenerimaanbarangdetil.Rows(0).Item("terimabarangdetil_line"), IIf(isApprove = 1, 1, 0), dbConn, dbTrans)
                '===============================================================================================
            End Using
            dbTrans.Commit()

            If isApprove = 1 Then
                Me.tbtnPosting.Enabled = False
                Me.tbtnUnposting.Enabled = True
                Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc") = True
                Me.EnableDisable(False)
            Else
                Me.tbtnPosting.Enabled = True
                Me.tbtnUnposting.Enabled = False
                Me.tbl_TrnPenerimaanbarang_Temp.Rows(0).Item("terimabarang_appacc") = False
                Me.EnableDisable(True)
            End If

        Catch ex As OleDb.OleDbException
            dbTrans.Rollback()
            MsgBox("Ole Db Error : " + ex.Message, MsgBoxStyle.Exclamation, mUiName)
        Catch ex As Exception
            dbTrans.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, mUiName)
        Finally
            clsApplicationRole.UnsetAppRole(dbConn, dbTrans, cookie)
            dbConn.Close()
        End Try
    End Sub

    Private Sub EnableDisable(ByVal isDisable As Boolean)
        Me.txtLocation.Enabled = isDisable
        Me.txtNotes.Enabled = isDisable
        Me.lueDept.Enabled = isDisable
        Me.GVRVDetil.OptionsBehavior.Editable = isDisable
        Me.dtJurnalBookDate.Enabled = isDisable
        Me.lueJurnalPeriode.Enabled = isDisable
        Me.GVJurnalDebit.OptionsBehavior.Editable = isDisable
        Me.GVJurnalKredit.OptionsBehavior.Editable = isDisable
        Me.btnAddCipAsset.Enabled = isDisable
    End Sub

    Private Sub AddChildToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddChild.Click
        Me.Cursor = Cursors.WaitCursor
        If Me.tbl_TrnPenerimaanbarangdetil.Rows.Count >= 1 Then
            GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            Me.Cursor = Cursors.Arrow
            Exit Sub
        Else
            GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        End If

        Dim dlg As New dlgRVSelectListRV(Me.DSNFrm, Me._CHANNEL, False)
        If dlg.ShowDialog() = DialogResult.OK Then
            Dim row As DataRow = CType(dlg.DgvMstAssetAccounting.CurrentRow.DataBoundItem, DataRowView).Row

            Dim addRows As DataRow
            addRows = Me.tbl_TrnPenerimaanbarangdetil.NewRow
            addRows("channel_id") = row("channel_id")
            addRows("terimabarangdetil_date") = row("asset_tgl")
            addRows("assettype_id") = row("tipeasset_id")
            addRows("assetcategory_id") = row("kategoriasset_id")
            addRows("terimabarang_barcode") = row("asset_barcode")
            addRows("terimabarangdetil_parentline") = row("asset_lineinduk")
            addRows("terimabarang_parentbarcode") = row("asset_barcodeinduk")
            addRows("terimabarangdetil_serial_no") = row("asset_serial")
            addRows("terimabarangdetil_product_no") = row("asset_produknumber")
            addRows("terimabarangdetil_model") = row("asset_model")
            addRows("terimabarangdetil_desc") = row("asset_deskripsi")
            addRows("itemcategory_id") = row("kategoriitem_id")
            addRows("itemtype_id") = row("tipeitem_id")
            addRows("terimabarangdetil_golfiskal") = row("asset_golfiskal")
            addRows("terimabarangdetil_depre_enddt") = row("asset_depre_enddt")
            addRows("currency_id") = row("currency_id")
            addRows("terimabarangdetil_idrreal") = 0 'row("asset_harga")
            addRows("terimabarangdetil_foreignrate") = 1 'row("asset_valas")
            addRows("terimabarangdetil_totalidrreal") = 0 'row("asset_idrprice")
            addRows("employee_id") = row("employee_id_owner")
            addRows("brand_id") = row("brand_id")
            addRows("unit_id") = row("unit_id")
            addRows("terimabarangdetil_qty") = row("asset_qty")
            addRows("material_id") = row("material_id")
            addRows("colour_id") = row("warna_id")
            addRows("size_id") = row("ukuran_id")
            addRows("sex_id") = row("jeniskelamin_id")
            addRows("show_id_cont") = row("show_id_cont_item")
            addRows("room_id") = row("ruang_id")
            addRows("terimabarangdetil_rack") = row("asset_rak")
            addRows("terimabarangdetil_nonfixasset") = row("is_useable")
            addRows("budget_id") = row("project_id")
            addRows("show_id") = row("show_id")
            addRows("terimabarangdetil_eps") = row("asset_eps")
            addRows("writeoff_id") = row("wo_id")
            addRows("create_by") = row("inputby")
            addRows("create_dt") = row("inputdt")
            addRows("modified_by") = row("editby")
            addRows("modified_dt") = row("editdt")
            addRows("item_id") = row("item_id")
            addRows("order_id") = "" 'row("terimabarang_id")
            addRows("orderdetil_line") = 0 'row("asset_line")
            addRows("ref_id") = row("terimabarang_id")
            addRows("refdetil_line") = row("asset_line")

            Me.tbl_TrnPenerimaanbarangdetil.Rows.Add(addRows)
            Me.GCRVDetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil

            GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AddParentByRVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddParentByRV.Click
        Me.Cursor = Cursors.WaitCursor
        If Me.tbl_TrnPenerimaanbarangdetil.Rows.Count >= 1 Then
            GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            Me.Cursor = Cursors.Arrow
            Exit Sub
        Else
            GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        End If

        Dim dlg As New dlgRVSelectListRV(Me.DSNFrm, Me._CHANNEL, True)
        If dlg.ShowDialog() = DialogResult.OK Then
            Dim row As DataRow = CType(dlg.DgvMstAssetAccounting.CurrentRow.DataBoundItem, DataRowView).Row

            Dim addRows As DataRow
            addRows = Me.tbl_TrnPenerimaanbarangdetil.NewRow
            addRows("channel_id") = row("channel_id")
            addRows("terimabarangdetil_date") = row("asset_tgl")
            addRows("assettype_id") = row("tipeasset_id")
            addRows("assetcategory_id") = row("kategoriasset_id")
            addRows("terimabarang_barcode") = row("asset_barcode")
            addRows("terimabarangdetil_parentline") = row("asset_lineinduk")
            addRows("terimabarang_parentbarcode") = row("asset_barcodeinduk")
            addRows("terimabarangdetil_serial_no") = row("asset_serial")
            addRows("terimabarangdetil_product_no") = row("asset_produknumber")
            addRows("terimabarangdetil_model") = row("asset_model")
            addRows("terimabarangdetil_desc") = row("asset_deskripsi")
            addRows("itemcategory_id") = row("kategoriitem_id")
            addRows("itemtype_id") = row("tipeitem_id")
            addRows("terimabarangdetil_golfiskal") = row("asset_golfiskal")
            addRows("terimabarangdetil_depre_enddt") = row("asset_depre_enddt")
            addRows("currency_id") = row("currency_id")
            addRows("terimabarangdetil_idrreal") = 0 'row("asset_harga")
            addRows("terimabarangdetil_foreignrate") = 1 'row("asset_valas")
            addRows("terimabarangdetil_totalidrreal") = 0 'row("asset_idrprice")
            addRows("employee_id") = row("employee_id_owner")
            addRows("brand_id") = row("brand_id")
            addRows("unit_id") = row("unit_id")
            addRows("terimabarangdetil_qty") = row("asset_qty")
            addRows("material_id") = row("material_id")
            addRows("colour_id") = row("warna_id")
            addRows("size_id") = row("ukuran_id")
            addRows("sex_id") = row("jeniskelamin_id")
            addRows("show_id_cont") = row("show_id_cont_item")
            addRows("room_id") = row("ruang_id")
            addRows("terimabarangdetil_rack") = row("asset_rak")
            addRows("terimabarangdetil_nonfixasset") = row("is_useable")
            addRows("budget_id") = row("project_id")
            addRows("show_id") = row("show_id")
            addRows("terimabarangdetil_eps") = row("asset_eps")
            addRows("writeoff_id") = row("wo_id")
            addRows("create_by") = row("inputby")
            addRows("create_dt") = row("inputdt")
            addRows("modified_by") = row("editby")
            addRows("modified_dt") = row("editdt")
            addRows("item_id") = row("item_id")
            addRows("order_id") = "" 'row("terimabarang_id")
            addRows("orderdetil_line") = 0 'row("asset_line")
            addRows("is_parent") = 1
            addRows("ref_id") = row("terimabarang_id")
            addRows("refdetil_line") = row("asset_line")

            Me.tbl_TrnPenerimaanbarangdetil.Rows.Add(addRows)
            Me.GCRVDetil.DataSource = Me.tbl_TrnPenerimaanbarangdetil

            GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AddParentManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddParentManual.Click

        If Me.tbl_TrnPenerimaanbarangdetil.Rows.Count > 0 Then
            GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
        Else
            Me.GVRVDetil.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            Me.GVRVDetil.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            Me.tbl_TrnPenerimaanbarangdetil.Columns("is_parent").DefaultValue = 1
        End If
    End Sub

    Private Sub AccBiayaLainnya_Click(sender As Object, e As EventArgs) Handles AccPendapatanLainnya.Click
        If Me.tbl_TrnJurnaldetil_kredit.Rows.Count > 0 Then
            Dim dtRows As DataRow = Me.tbl_TrnJurnaldetil_kredit.Rows(0)
            Dim addRows As DataRow
            addRows = Me.tbl_TrnJurnaldetil_kredit.NewRow

            addRows("jurnaldetil_dk") = "K"
            addRows("jurnaldetil_descr") = "(Pendapatan) Lain-lain - Lain-lain"
            addRows("rekanan_id") = 0
            addRows("rekanan_name") = ""
            addRows("acc_id") = 7201210 'account (Pendapatan) Lain-lain - Lain-lain
            addRows("currency_id") = 1 'dtRows("currency_id") SEMUA DIGANTI RUPIAH

            'If dtRows("currency_id") <> 1 Then
            '    addRows("jurnaldetil_foreign") = dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate")
            '    addRows("jurnaldetil_foreignrate") = 1
            '    addRows("jurnaldetil_idr") = Math.Round((dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate")), 0)
            'Else

            addRows("jurnaldetil_foreign") = 0
            addRows("jurnaldetil_foreignrate") = 0 'dtRows("jurnaldetil_foreignrate")
            addRows("jurnaldetil_idr") = 0

            addRows("channel_id") = dtRows("channel_id")
            addRows("strukturunit_id") = dtRows("strukturunit_id")
            addRows("ref_id") = dtRows("jurnal_id")
            addRows("ref_line") = dtRows("jurnaldetil_line")
            addRows("region_id") = dtRows("region_id")
            addRows("branch_id") = dtRows("branch_id")

            Me.tbl_TrnJurnaldetil_kredit.Rows.Add(addRows)
        End If

    End Sub

    Private Sub AccPendLainnya_Click(sender As Object, e As EventArgs) Handles AccPendLainnya.Click
        If Me.tbl_TrnJurnaldetil_debet.Rows.Count > 0 Then
            Dim dtRows As DataRow = Me.tbl_TrnJurnaldetil_debet.Rows(0)

            Dim addRows As DataRow
            addRows = Me.tbl_TrnJurnaldetil_debet.NewRow

            addRows("jurnaldetil_dk") = "D"
            addRows("jurnaldetil_descr") = "Biaya Lain-lain - Biaya - Adm"
            addRows("rekanan_id") = 0
            addRows("rekanan_name") = ""
            addRows("acc_id") = 7101210 'account Biaya Lain-lain - Biaya - Adm
            addRows("currency_id") = 1 'dtRows("currency_id") SEMUA DIGANTI RUPIAH

            'If dtRows("currency_id") <> 1 Then
            '    addRows("jurnaldetil_foreign") = dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate")
            '    addRows("jurnaldetil_foreignrate") = 1
            '    addRows("jurnaldetil_idr") = Math.Round((dtRows("jurnaldetil_foreign") * dtRows("jurnaldetil_foreignrate")), 0)
            'Else

            addRows("jurnaldetil_foreign") = 0
            addRows("jurnaldetil_foreignrate") = 0 'dtRows("jurnaldetil_foreignrate")
            addRows("jurnaldetil_idr") = 0

            ' End If

            addRows("channel_id") = dtRows("channel_id")
            addRows("strukturunit_id") = dtRows("strukturunit_id")
            addRows("ref_id") = dtRows("jurnal_id")
            addRows("ref_line") = dtRows("jurnaldetil_line")
            addRows("region_id") = dtRows("region_id")
            addRows("branch_id") = dtRows("branch_id")

            Me.tbl_TrnJurnaldetil_debet.Rows.Add(addRows)
        End If
    End Sub

    Private Sub GVJurnalKredit_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GVJurnalKredit.ShowingEditor
        'Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'Dim col As GridColumn = view.Columns("acc_id")
        'Dim val As String = Convert.ToString(view.GetRowCellValue(view.FocusedRowHandle, col))

        'If view.FocusedColumn.FieldName = "jurnaldetil_foreign" Then
        '    If val = "7201210" Then
        '        e.Cancel = True
        '    End If
        'End If

        'If view.FocusedColumn.FieldName = "jurnaldetil_foreignrate" Then
        '    If val = "7201210" Then
        '        e.Cancel = True
        '    End If
        'End If

        'If view.FocusedColumn.FieldName = "jurnaldetil_idr" Then
        '    If val = "7201210" Then
        '        'view.Columns("jurnaldetil_idr").ReadOnly = False

        '        e.Cancel = False
        '    End If
        'End If

    End Sub

    Private Sub dtJurnalBookDate_EditValueChanged(sender As Object, e As EventArgs) Handles dtJurnalBookDate.EditValueChanged
        ''
        If Me.dtJurnalBookDate.EditValue IsNot Nothing Then
            Dim periodebookdate As String = String.Empty
            Dim tbl_periode As DataTable = New DataTable
            tbl_periode.Clear()
            Me.DataFill(tbl_periode, "ms_MstPeriodeCombo_Select", String.Format("channel_id = '{0}' AND MONTH(periode_datestart) = MONTH('{1}')AND YEAR(periode_datestart) = YEAR('{1}')", Me._CHANNEL, Format(Me.dtJurnalBookDate.EditValue, "yyyy/MM/dd").ToString))
            If tbl_periode.Rows.Count <> 0 Then
                periodebookdate = tbl_periode.Rows(0).Item("periode_id")
                Me.lueJurnalPeriode.EditValue = periodebookdate
            End If
        End If
        
    End Sub
End Class


